using System;
using System.Collections.Generic;
using osu.Game.Rulesets.RP.SkinManager;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.CommonDwawablePiece;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Calculator.Height;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Component.Common;
using OpenTK;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables.Component.RpContainer
{
    /// <summary>
    ///     εδ»θκyp
    /// </summary>
    internal class ContainerBeatLineComponent : BaseContainerComponent, IChangeableContainerComponent, IComponentHasStartTime,IComponentHasEndTime,IComponentHasBpm
    {
        /// <summary>
        ///     ΤIί
        /// </summary>
        private readonly List<ImagePicec> _containerBeatDecisionLineComponent = new List<ImagePicec>();

        /// <summary>
        ///     vZ¨IθxaHeightΚu
        /// </summary>
        private ContainerLayoutHeightCalculator _heightCalculator = new ContainerLayoutHeightCalculator();

        public ContainerBeatLineComponent(Objects.RpContainerLineGroup hitObject)
            : base(hitObject)
        {
        }

        /// <summary>
        ///     Cό¨x
        /// </summary>
        /// <param name="newHeight"></param>
        public void ChangeHeight(float newHeight)
        {
        }

        /// <summary>
        ///     n»θϋ¦
        /// </summary>
        protected override void InitialObject(int layerCount = 0)
        {
            InitialBeat();
        }


        protected override void InitialChild()
        {
            Children = _containerBeatDecisionLineComponent;
        }

        /// <summary>
        ///     n»ίκy
        /// </summary>
        private void InitialBeat()
        {
            for (var i = 0; i < 20; i++)
            {
                if (_positionCounter.GetPosition(i * GetDeltaBeatTime(), HitObject.Velocity) > _positionCounter.GetPosition(HitObject.EndTime - HitObject.StartTime, HitObject.Velocity))
                    break;

                //¨
                var line = new ImagePicec(RpTexturePathManager.GetBeatLineTexture());
                line.Scale = new Vector2(0.6f);
                //έθΚu
                line.Position = CalculatePosition(i * GetDeltaBeatTime());
                //Αό
                _containerBeatDecisionLineComponent.Add(line);
            }
        }

        public void SetStartTime(double startTime)
        {
            throw new NotImplementedException();
        }

        public void SetEndTime(double time)
        {
            throw new NotImplementedException();
        }

        public void ChangeBPM(double newBpm)
        {
            throw new NotImplementedException();
        }
    }
}
