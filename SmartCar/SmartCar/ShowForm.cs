using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Timer = System.Windows.Forms.Timer;

namespace SmartCar {
    public class ShowForm {
        public static void hideAndShow(Form formToHide, Form formToShow, int step = 10, int sleepTime = 100) {
            if (formToHide == formToShow || formToHide == null && formToShow == null) {
                return;
            }
            ShowFormInfo info = new ShowFormInfo(formToHide, formToShow, step, sleepTime);

            new Thread(new ParameterizedThreadStart(changeShow)).Start(info);
        }

        static void changeShow(Object info) {
            ShowFormInfo sInfo = (ShowFormInfo)info;
            for (int i = 0; i < sInfo.step; ++i) {
                if (sInfo.formToHide != null) {
                    sInfo.formToHide.Invoke(sInfo.changeHide, i);
                }
                if (sInfo.formToShow != null) {
                    sInfo.formToShow.Invoke(sInfo.changeShow, i);
                }
            }
        }

    }

    public class ShowFormInfo {
        public Form formToHide;
        public Form formToShow;
        public int step;
        public int sleepTime;
        public ShowFormInfo(Form formToHide, Form formToShow, int step, int sleepTime) {
            this.formToHide = formToHide;
            this.formToShow = formToShow;
            this.step = step;
            this.sleepTime = sleepTime;

            changeHide = new change(setStepHide);
            changeShow = new change(setStepShow);
        }

        public delegate void change(int curStep);
        public change changeHide;
        public change changeShow;
        public void setStepHide(int curStep) {
            // change Opacity here
            if (formToHide != null) {
                formToHide.Opacity = 1 - 1.0 / step * curStep;
            }
            if (curStep == 0 && formToHide != null) {
                formToHide.Visible = false;
            }
        }
        public void setStepShow(int curStep) {
            if (curStep == 0 && formToShow != null) {
                formToShow.Opacity = 0;
                formToShow.Visible = true;
            }
            if (formToShow != null) {
                formToShow.Opacity = 1.0 / step * curStep;
            }
            // wait for a while
            Thread.Sleep(sleepTime);
        }
    }

}
