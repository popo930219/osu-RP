﻿using System.Collections.Generic;
using osu.Framework.Graphics;
using osu.Game.Rulesets.RP.SkinManager;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.CommonDwawablePiece;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Calculator.Height;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Calculator.Position;
using OpenTK;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Template.RpContainer.RpContainerLine
{

    /// <summary>
    /// </summary>
    public class RpContainerLineTemplate : RpContainableTemplate<DrawableBaseRpHitableObject>
    {
        public new DrawableRpContainerLine DrawablehitObject
        {
            get { return (DrawableRpContainerLine)base.DrawablehitObject; }
        }

        public new Objects.RpContainerLine HitObject
        {
            get { return (Objects.RpContainerLine)base.HitObject; }
        }

        /// <summary>
        ///     負責計算物件在時間點該有的位置
        /// </summary>
        private readonly ContainerLayoutPositionCounter _positionCounter = new ContainerLayoutPositionCounter();

        /// <summary>
        ///     計算物件皁E��關高度和Height位置
        /// </summary>
        private readonly ContainerLayoutHeightCalculator _heightCalculator = new ContainerLayoutHeightCalculator();

        /// <summary>
        ///     顯示單行背景
        /// </summary>
        private RectanglePiece _rpRectanglePiece;

        /// <summary>
        ///     顯示單行背景
        /// </summary>
        private RectanglePiece _linePiece;


        public RpContainerLineTemplate(DrawableRpContainerLine drawablehitObject)
            : base(drawablehitObject)
        {
            //
            InitialLinePiece();
            //初始化樣板
            InitialTemplate();
            //初始化物件
            InitialHitObject();
            //更新物件
            UpdateHitObject();
            //
            InitialChild();
        }

        /// <summary>
        ///     增加物件
        /// </summary>
        /// <param name="drawableHitObject"></param>
        public override void AddObject(DrawableBaseRpHitableObject drawableHitObject)
        {
            drawableHitObject.Position = GetTargetObjectPosition(drawableHitObject);
            base.AddObject(drawableHitObject);
        }

        /// <summary>
        ///     取得原點座樁E
        /// </summary>
        /// <returns></returns>
        public Vector2 GetRowPosition()
        {
            return HitObject.Position + Position;
        }

        public override void FadeIn(double time = 0)
        {
            base.FadeIn(time);
            _linePiece.ScaleTo(new Vector2(1, 1), time, EasingTypes.InOutElastic);
            _rpRectanglePiece.ScaleTo(new Vector2(1, 1), time, EasingTypes.InOutElastic);
        }

        public override void FadeOut(double time = 0)
        {
            base.FadeOut(time);
            _linePiece.ScaleTo(new Vector2(1, 0), time, EasingTypes.OutElastic);
            _rpRectanglePiece.ScaleTo(new Vector2(1, 0), time, EasingTypes.OutElastic);
        }

        /// <summary>
        ///     隨時更新位置
        /// </summary>
        protected override void Update()
        {
            _linePiece.Position = CalculatePosition(Time.Current);
            base.Update();
        }

        private void InitialLinePiece()
        {
            //背景物件
            _linePiece = new RectanglePiece(2000, _heightCalculator.GetLayoutHeight())
            {
                Origin = Anchor.CentreRight,
                Scale = new Vector2(1.0f, 0f),
                Colour = RpTextureColorManager.GetCoopJudgementLineColor(HitObject.Coop)
            };
        }

        /// <summary>
        /// </summary>
        private void InitialTemplate()
        {
            //背景物件
            _rpRectanglePiece = new RectanglePiece(2000, _heightCalculator.GetLayoutHeight())
            {
                Scale = new Vector2(1.0f, 0f),
                Alpha = 0.5f,
                Colour = RpTextureColorManager.GetCoopLayoutColor(HitObject.Coop)
            };
        }

        /// <summary>
        ///     初始化Layout
        /// </summary>
        private void InitialHitObject()
        {
        }

        /// <summary>
        ///     更新物件
        /// </summary>
        private void UpdateHitObject()
        {
            foreach (var hitObject in ListContainObject)
                hitObject.Position = new Vector2(0, 20);
        }

        private void InitialChild()
        {
            var list = new List<Framework.Graphics.Containers.Container>();
            //背景
            list.Add(_rpRectanglePiece);
            list.Add(_linePiece);
            //打擊物件
            //list.AddRange(ListContainObject);
            //加入子物件
            Children = list;
        }

        public override Vector2 GetTargetObjectPosition(DrawableBaseRpHitableObject dragObject)
        {
            //TODO : :impliment
            return CalculatePosition(dragObject.HitObject.StartTime) + GetRowPosition(); ;
        }

        public override float GetTargetObjectScale(DrawableBaseRpHitableObject dragObject)
        {
            //return 1;
            return 1;
        }

        /// <summary>
        ///     根據時間點計算物件位置
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public Vector2 CalculatePosition(double time)
        {
            return new Vector2(_positionCounter.GetPosition(time - HitObject.StartTime, HitObject.Velocity), 0);
        }
    }
}
