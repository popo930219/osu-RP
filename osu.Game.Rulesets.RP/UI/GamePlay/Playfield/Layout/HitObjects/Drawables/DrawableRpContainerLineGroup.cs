﻿using osu.Framework.Graphics;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.RP.Objects;
using osu.Game.Rulesets.RP.Scoreing;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Template.RpContainer.RpContainerLineGroup;
using OpenTK;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables
{
    /// <summary>
    ///     匁E��RP物件
    /// </summary>
    public class DrawableRpContainerLineGroup : DrawableBaseContainableObject<DrawableRpContainerLine> 
    {
        /// <summary>
        /// </summary>
        public new RpContainerLineGroup HitObject
        {
            get { return (RpContainerLineGroup)base.HitObject; }
        }

        /// <summary>
        ///     template
        /// </summary>
        public new RpContainerLineGroupTemplate Template
        {
            get { return (RpContainerLineGroupTemplate)base.Template; }
            set { base.Template = value; }
        }

        private bool _startFadeont;

        /// <summary>
        /// </summary>
        /// <param name="hitObject"></param>
        public DrawableRpContainerLineGroup(BaseRpObject hitObject) : base(hitObject)
        {

        }

        public override void InitialTemplate()
        {
            Template = new RpContainerLineGroupTemplate(HitObject)
            {
                Position = new Vector2(0, 0),
                Alpha = 1
            };
        }

        public override void InitialChild()
        {
            Children = new Drawable[]
            {
                Template
            };
        }


        /// <summary>
        ///     更新初始狀慁E
        /// </summary>
        protected override void UpdateInitialState()
        {
            base.UpdateInitialState();

            //sane defaults
            //ring.Alpha = _detectPress.Alpha = number.Alpha = glow.Alpha = 1;
            //初始化持E��E
            Template.Initial();
            //explode.Alpha = 0;
        }

        /// <summary>
        ///     這裡估計會一直更新
        /// </summary>
        protected override void UpdatePreemptState()
        {
            //RpDrawBaseObjectTemplate single = (RpDrawBaseObjectTemplate)Template;
            //FadeIn(FadeInTime);
            //開始特效
            //Template.FadeIn(FadeInTime);

            base.UpdatePreemptState();
        }

        /// <summary>
        ///     持續一直更新物件
        /// </summary>
        protected override void Update()
        {
            base.Update();

            //如果時間趁E��就執衁E
            if (HitObject.EndTime < Time.Current && !_startFadeont)
            {
                _startFadeont = true;
                FadeOut(FadeOutTime);
                Template.FadeOut(FadeOutTime);
            }
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        protected override RpJudgement CreateJudgement()
        {
            return new RpJudgement();
        }

        /// <summary>
        ///     從這邊去更新狀慁E
        /// </summary>
        /// <param name="userTriggered"></param>
        protected override void CheckJudgement(bool userTriggered)
        {

        }

        /// <summary>
        ///     更新
        /// </summary>
        /// <param name="state"></param>
        protected override void UpdateState(ArmedState state)
        {
            base.UpdateState(state);
            Delay(HitObject.Duration + PreemptTime + FadeOutTime);

            if (state == ArmedState.Hit)
            {
            }
        }
    }
}
