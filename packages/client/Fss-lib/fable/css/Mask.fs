namespace Fss

open Fable.Core

[<AutoOpen>]
module Mask =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/mask-clip
    let private stringifyClip (clip: FssTypes.IMaskClip) =
        match clip with
        | :? FssTypes.Mask.Clip as m -> Utilities.Helpers.duToKebab m
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown mask-clip"

    let private maskClipValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.MaskClip
    let private maskClipValue' = stringifyClip >> maskClipValue

    [<Erase>]
    /// Specifies which area is affected by a mask.
    type MaskClip =
        static member value (clip: FssTypes.IMaskClip) = clip |> maskClipValue'
        static member value (clips: FssTypes.Mask.Clip list) =
            clips
            |> Utilities.Helpers.combineComma stringifyClip
            |> maskClipValue
        static member contentBox = FssTypes.Mask.Clip.ContentBox |> maskClipValue'
        static member paddingBox = FssTypes.Mask.Clip.PaddingBox |> maskClipValue'
        static member borderBox = FssTypes.Mask.Clip.BorderBox |> maskClipValue'
        static member marginBox = FssTypes.Mask.Clip.MarginBox |> maskClipValue'
        static member fillBox = FssTypes.Mask.Clip.FillBox |> maskClipValue'
        static member strokeBox = FssTypes.Mask.Clip.StrokeBox |> maskClipValue'
        static member viewBox = FssTypes.Mask.Clip.ViewBox |> maskClipValue'
        static member noClip = FssTypes.Mask.Clip.NoClip |> maskClipValue'
        static member border = FssTypes.Mask.Clip.Border |> maskClipValue'
        static member padding = FssTypes.Mask.Clip.Padding |> maskClipValue'
        static member content = FssTypes.Mask.Clip.Content |> maskClipValue'
        static member text = FssTypes.Mask.Clip.Text |> maskClipValue'
        static member inherit' = FssTypes.Inherit |> maskClipValue'
        static member initial = FssTypes.Initial |> maskClipValue'
        static member unset = FssTypes.Unset |> maskClipValue'

    /// Specifies which area is affected by a mask.
    /// Valid parameters:
    /// - MaskClip
    /// - Inherit
    /// - Initial
    /// - Unset
    let MaskClip': (FssTypes.IMaskClip -> FssTypes.CssProperty) = MaskClip.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/mask-composite
    let private stringifyComposite (composite: FssTypes.IMaskComposite) =
        match composite with
        | :? FssTypes.Mask.Composite as m -> Utilities.Helpers.duToLowercase m
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown mask-composite"

    let private maskCompositeValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.MaskComposite
    let private maskCompositeValue' = stringifyComposite >> maskCompositeValue

    [<Erase>]
    /// Allows composing of masks with masks under it.
    type MaskComposite =
        static member value (clip: FssTypes.IMaskComposite) = clip |> maskCompositeValue'
        static member value (clips: FssTypes.Mask.Composite list) =
            clips
            |> Utilities.Helpers.combineComma stringifyComposite
            |> maskCompositeValue
        static member add = FssTypes.Mask.Composite.Add |> maskCompositeValue'
        static member subtract = FssTypes.Mask.Composite.Subtract |> maskCompositeValue'
        static member intersect = FssTypes.Mask.Composite.Intersect |> maskCompositeValue'
        static member exclude = FssTypes.Mask.Composite.Exclude |> maskCompositeValue'
        static member inherit' = FssTypes.Inherit |> maskCompositeValue'
        static member initial = FssTypes.Initial |> maskCompositeValue'
        static member unset = FssTypes.Unset |> maskCompositeValue'

    /// Allows composing of masks with masks under it.
    /// Valid parameters:
    /// - MaskComposite
    /// - Inherit
    /// - Initial
    /// - Unset
    let MaskComposite': (FssTypes.IMaskComposite -> FssTypes.CssProperty) = MaskComposite.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/mask-image
    let private imageSourceToString (imageSource: FssTypes.IMaskImage) =
        match imageSource with
        | :? FssTypes.None' -> FssTypes.masterTypeHelpers.none
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown mask image"

    let private imageValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.MaskImage
    let private imageValue' = imageSourceToString >> imageValue

    [<Erase>]
    /// Specifies width of border image.
    let MaskImage = FssTypes.Mask.MaskImage(imageValue, imageValue')

    /// Specifies width of border image.
    /// Valid parameters:
    /// - Image
    /// - Inherit
    /// - Initial
    /// - Unset
    /// - None
    let MaskImage' = MaskImage.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/mask-mode
    let private stringifyMode (composite: FssTypes.IMaskMode) =
        match composite with
        | :? FssTypes.Mask.Mode as m -> Utilities.Helpers.duToKebab m
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown mask mode"

    let private maskModeValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.MaskMode
    let private maskModeValue' = stringifyMode >> maskModeValue

    [<Erase>]
    /// Allows composing of masks with masks under it.
    type MaskMode =
        static member value (mode: FssTypes.IMaskMode) = mode |> maskModeValue'
        static member value (modes: FssTypes.Mask.Mode list) =
            modes
            |> Utilities.Helpers.combineComma stringifyMode
            |> maskModeValue
        static member alpha = FssTypes.Mask.Alpha |> maskModeValue'
        static member luminance = FssTypes.Mask.Luminance |> maskModeValue'
        static member matchSource = FssTypes.Mask.MatchSource |> maskModeValue'
        static member inherit' = FssTypes.Inherit |> maskModeValue'
        static member initial = FssTypes.Initial |> maskModeValue'
        static member unset = FssTypes.Unset |> maskModeValue'

    /// Allows composing of masks with masks under it.
    /// Valid parameters:
    /// - MaskMode
    /// - Inherit
    /// - Initial
    /// - Unset
    let MaskMode': (FssTypes.IMaskMode -> FssTypes.CssProperty) = MaskMode.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/mask-origin
    let private stringifyOrigin (composite: FssTypes.IMaskOrigin) =
        match composite with
        | :? FssTypes.Mask.Origin as m -> Utilities.Helpers.duToKebab m
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown mask mode"

    let private maskOriginValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.MaskOrigin
    let maskOriginValue' = stringifyOrigin >> maskOriginValue

    [<Erase>]
    /// Specifies origin of masks.
    type MaskOrigin =
        static member value (origin: FssTypes.IMaskOrigin) = origin |> maskOriginValue'
        static member value (origins: FssTypes.Mask.Origin list) =
            origins
            |> Utilities.Helpers.combineComma stringifyOrigin
            |> maskOriginValue
        static member contentBox = FssTypes.Mask.Origin.ContentBox |> maskOriginValue'
        static member paddingBox = FssTypes.Mask.Origin.PaddingBox |> maskOriginValue'
        static member borderBox = FssTypes.Mask.Origin.BorderBox |> maskOriginValue'
        static member marginBox = FssTypes.Mask.Origin.MarginBox |> maskOriginValue'
        static member fillBox = FssTypes.Mask.Origin.FillBox |> maskOriginValue'
        static member strokeBox = FssTypes.Mask.Origin.StrokeBox |> maskOriginValue'
        static member viewBox = FssTypes.Mask.Origin.ViewBox |> maskOriginValue'
        static member content = FssTypes.Mask.Origin.Content |> maskOriginValue'
        static member padding = FssTypes.Mask.Origin.Padding |> maskOriginValue'
        static member border = FssTypes.Mask.Origin.Border |> maskOriginValue'

        static member inherit' = FssTypes.Inherit |> maskOriginValue'
        static member initial = FssTypes.Initial |> maskOriginValue'
        static member unset = FssTypes.Unset |> maskOriginValue'

    /// Specifies origin of masks.
    /// Valid parameters:
    /// - MaskOrigin
    /// - Inherit
    /// - Initial
    /// - Unset
    let MaskOrigin': (FssTypes.IMaskOrigin -> FssTypes.CssProperty) = MaskOrigin.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/mask-position
    let private stringifyPosition (composite: FssTypes.IMaskPosition) =
        match composite with
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown mask position"

    let private maskPositionValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.MaskPosition
    let private maskPositionValue' = stringifyPosition >> maskPositionValue

    let private stringifyPixelPositions ps =
        let (x, y) = ps
        $"{FssTypes.unitHelpers.sizeToString x} {FssTypes.unitHelpers.sizeToString y}"

    let private stringifyPercentPositions ps =
        let (x, y) = ps
        $"{FssTypes.unitHelpers.percentToString x} {FssTypes.unitHelpers.percentToString y}"

    [<Erase>]
    /// Specifies position of masks.
    type MaskPosition =
        static member value (x: FssTypes.Length, y: FssTypes.Length) =
            stringifyPixelPositions(x,y)
            |> maskPositionValue
        static member value (positions: (FssTypes.Length * FssTypes.Length) list ) =
            positions
            |> Utilities.Helpers.combineComma stringifyPixelPositions
            |> maskPositionValue
        static member value (x: FssTypes.Percent, y: FssTypes.Percent) =
            stringifyPercentPositions(x,y)
            |> maskPositionValue
        static member value (positions: (FssTypes.Percent * FssTypes.Percent) list ) =
            positions
            |> Utilities.Helpers.combineComma stringifyPercentPositions
            |> maskPositionValue
        static member inherit' = FssTypes.Inherit |> maskPositionValue'
        static member initial = FssTypes.Initial |> maskPositionValue'
        static member unset = FssTypes.Unset |> maskPositionValue'

    /// Specifies position of masks.
    /// Valid parameters:
    /// Units.Length * Units.Length
    let MaskPosition': (FssTypes.Length * FssTypes.Length -> FssTypes.CssProperty) = MaskPosition.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/mask-repeat
    let private stringifyRepeat (composite: FssTypes.IMaskRepeat) =
        match composite with
        | :? FssTypes.Mask.Repeat as r ->
            match r with
            | FssTypes.Mask.Repeat -> "repeat"
            | _ -> Utilities.Helpers.duToKebab r
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown mask repeat"

    let private maskRepeatValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.MaskRepeat
    let private maskRepeatValue' = stringifyRepeat >> maskRepeatValue

    let private repeatValue (x: FssTypes.Mask.Repeat, y: FssTypes.Mask.Repeat) =
        $"{stringifyRepeat x} {stringifyRepeat y}"

    [<Erase>]
    type MaskRepeat =
        static member value (repeat: FssTypes.IMaskRepeat) =
            repeat
            |> maskRepeatValue'
        static member value (repeatX: FssTypes.IMaskRepeat, repeatY: FssTypes.IMaskRepeat) =
            $"{stringifyRepeat repeatX} {stringifyRepeat repeatY}"
            |> maskRepeatValue
        static member value(repeats: (FssTypes.Mask.Repeat * FssTypes.Mask.Repeat) list) =
            repeats
            |> Utilities.Helpers.combineComma repeatValue
            |> maskRepeatValue
        static member repeatX = FssTypes.Mask.RepeatX |> maskRepeatValue'
        static member repeatY = FssTypes.Mask.RepeatY |> maskRepeatValue'
        static member repeat = FssTypes.Mask.Repeat |> maskRepeatValue'
        static member space = FssTypes.Mask.Space |> maskRepeatValue'
        static member round = FssTypes.Mask.Round |> maskRepeatValue'
        static member noRepeat = FssTypes.Mask.NoRepeat |> maskRepeatValue'
        static member inherit' = FssTypes.Inherit |> maskRepeatValue'
        static member initial = FssTypes.Initial |> maskRepeatValue'
        static member unset = FssTypes.Unset |> maskRepeatValue'

    /// Specifies how masks are repeated.
    /// Valid parameters:
    /// - MaskRepeat
    /// - Inherit
    /// - Initial
    /// - Unset
    let MaskRepeat': (FssTypes.IMaskRepeat -> FssTypes.CssProperty) = MaskRepeat.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/mask-size
    let private stringifySize (size: FssTypes.IMaskSize) =
        match size with
        | :? FssTypes.Mask.Size as s -> Utilities.Helpers.duToKebab s
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | :? FssTypes.Percent as p -> FssTypes.unitHelpers.percentToString p
        | :? FssTypes.Length as s -> FssTypes.unitHelpers.sizeToString s
        | _ -> "Unknown mask size"

    let private maskSizeValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.MaskSize
    let private maskSizeValue' = stringifySize >> maskSizeValue

    [<Erase>]
    /// Specifies size of mask images.
    type MaskSize =
        static member value (size: FssTypes.IMaskSize) = size |> maskSizeValue'
        static member value (sizeX: FssTypes.IMaskSize, sizeY: FssTypes.IMaskSize) =
            $"{stringifySize sizeX} {stringifySize sizeY}"
            |> maskSizeValue
        static member values(sizes: FssTypes.IMaskSize list) =
            sizes
            |> Utilities.Helpers.combineComma stringifySize
            |> maskSizeValue
        static member cover = FssTypes.Mask.Cover |> maskSizeValue'
        static member contain = FssTypes.Mask.Contain |> maskSizeValue'
        static member auto = FssTypes.Auto |> maskSizeValue'
        static member inherit' = FssTypes.Inherit |> maskSizeValue'
        static member initial = FssTypes.Initial |> maskSizeValue'
        static member unset = FssTypes.Unset |> maskSizeValue'

    /// Specifies size of mask images.
    /// Valid parameters
    /// - MaskSize
    /// - Auto
    /// - Inherit
    /// - Initial
    /// - Unset
    let MaskSize': (FssTypes.IMaskSize -> FssTypes.CssProperty) = MaskSize.value