﻿// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using System.Collections.Generic;
using osu.Game.Beatmaps;
using osu.Game.Rulesets.Objects;
using osu.Game.Rulesets.Empty.Objects;
using osu.Game.Rulesets.Objects.Types;
using osuTK;

namespace osu.Game.Rulesets.Empty.Beatmaps
{
    public class EmptyBeatmapConverter : BeatmapConverter<EmptyHitObject>
    {
        protected override IEnumerable<Type> ValidConversionTypes { get; } = new[]
        {
            // todo: Populate with conversion types that should be supported other than position (ie. typeof(IHasCurve))
            // https://github.com/ppy/osu/tree/master/osu.Game/Rulesets/Objects/Types
            typeof(IHasPosition)
        };

        public EmptyBeatmapConverter(IBeatmap beatmap)
            : base(beatmap)
        {
        }

        protected override IEnumerable<EmptyHitObject> ConvertHitObject(HitObject original, IBeatmap beatmap)
        {
            yield return new EmptyHitObject
            {
                Samples = original.Samples,
                StartTime = original.StartTime,
                Position = (original as IHasPosition)?.Position ?? Vector2.Zero,
            };
        }
    }
}
