namespace Fss

open Fable.Core

[<AutoOpen>]
module Background =
    let private backgroundClipToString (clip: FssTypes.IBackgroundClip) =
        match clip with
        | :? FssTypes.Background.Clip as b -> Utilities.Helpers.duToKebab b
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown background clip"

    let private backgroundOriginToString (clip: FssTypes.IBackgroundOrigin) =
        match clip with
        | :? FssTypes.Background.Origin as b -> Utilities.Helpers.duToKebab b
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "unknown background origin"

    let private repeatToString (repeat: FssTypes.IBackgroundRepeat) =
        match repeat with
        | :? FssTypes.Background.Repeat as b -> Utilities.Helpers.duToKebab b
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "unknown background repeat"

    let private sizeToString (size: FssTypes.IBackgroundSize) =
        match size with
        | :? FssTypes.Background.Size as b -> Utilities.Helpers.duToLowercase b
        | :? FssTypes.Length as s -> FssTypes.unitHelpers.sizeToString s
        | :? FssTypes.Percent as p -> FssTypes.unitHelpers.percentToString p
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | _ -> "Unknown background size"

    let private attachmentToString (attachment: FssTypes.IBackgroundAttachment) =
        match attachment with
        | :? FssTypes.Background.Attachment as b -> Utilities.Helpers.duToLowercase b
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown background attachment"

    let private positionToString (position: FssTypes.IBackgroundPosition) =
        match position with
        | :? FssTypes.Background.Position as b -> Utilities.Helpers.duToLowercase b
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | :? FssTypes.Length as s -> FssTypes.unitHelpers.sizeToString s
        | :? FssTypes.Percent as p -> FssTypes.unitHelpers.percentToString p
        | _ -> "Unknown background position"

    let private blendModeToString (blendMode: FssTypes.IBackgroundBlendMode) =
        match blendMode with
        | :? FssTypes.Background.BlendMode as b ->
            match b with
            | FssTypes.Background.Color -> "color"
            | _ -> Utilities.Helpers.duToKebab b
        | :? FssTypes.Normal -> FssTypes.masterTypeHelpers.normal
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown background blend mode"

    let private isolationToString (isolation: FssTypes.IIsolation) =
        match isolation with
        | :? FssTypes.Background.Isolation as i -> "isolate"
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | _ -> "Unknown isolation"

    let private backgroundColorToString (backgroundColor: FssTypes.IBackgroundColor) =
        match backgroundColor with
        | :? FssTypes.Color.ColorType as c -> FssTypes.Color.colorHelpers.colorToString c
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown background color"

    let private backgroundImageToString (backgroundColor: FssTypes.IBackgroundImage) =
        match backgroundColor with
        | :? FssTypes.None' -> FssTypes.masterTypeHelpers.none
        | _ -> "Unknown background image"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-clip
    let private clipValue value = FssTypes.propertyHelpers.cssValue FssTypes.Property.BackgroundClip value
    let private clipValue' value =
        value
        |> backgroundClipToString
        |> clipValue

    [<Erase>]
    /// Specifies how an element's background extends.
    type BackgroundClip =
        static member value (clip: FssTypes.IBackgroundClip) = clip |> clipValue'
        static member borderBox = FssTypes.Background.Clip.BorderBox |> clipValue'
        static member paddingBox = FssTypes.Background.Clip.PaddingBox |> clipValue'
        static member contentBox = FssTypes.Background.Clip.ContentBox |> clipValue'
        static member text = FssTypes.Background.Clip.Text |> clipValue'

        static member inherit' = FssTypes.Inherit |> clipValue'
        static member initial = FssTypes.Initial |> clipValue'
        static member unset = FssTypes.Unset |> clipValue'

    /// Specifies how an element's background extends.
    /// Valid parameters:
    /// - BackgroundClip
    /// - Inherit
    /// - Initial
    /// - Unset
    let BackgroundClip' = BackgroundClip.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-origin
    let private originValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BackgroundOrigin
    let private originValue' = backgroundOriginToString >> originValue

    [<Erase>]
    /// Sets background origin.
    type BackgroundOrigin =
       static member value (origin: FssTypes.IBackgroundOrigin) = origin |> originValue'
       static member borderBox = FssTypes.Background.Origin.BorderBox |> originValue'
       static member paddingBox = FssTypes.Background.Origin.PaddingBox |> originValue'
       static member contentBox = FssTypes.Background.Origin.ContentBox |> originValue'

       static member inherit' = FssTypes.Inherit |> originValue'
       static member initial = FssTypes.Initial |> originValue'
       static member unset = FssTypes.Unset |> originValue'

    /// Sets background origin.
    /// Valid parameters:
    /// - BackgroundOrigin
    /// - Inherit
    /// - Initial
    /// - Unset
    let BackgroundOrigin' = BackgroundOrigin.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-repeat
    let private repeatValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BackgroundRepeat
    let private repeatValue' = repeatToString >> repeatValue

    [<Erase>]
    /// Specifies how background is repeated.
    type BackgroundRepeat =
        static member value (repeat: FssTypes.IBackgroundRepeat) = repeat |> repeatValue'
        static member value (v1: FssTypes.IBackgroundRepeat, v2: FssTypes.IBackgroundRepeat) =
            sprintf "%s %s" (repeatToString v1) (repeatToString v2)
            |> repeatValue
        static member repeatX = FssTypes.Background.RepeatX |> repeatValue'
        static member repeatY = FssTypes.Background.RepeatY |> repeatValue'
        static member repeat = FssTypes.Background.Repeat |> repeatValue'
        static member space = FssTypes.Background.Space |> repeatValue'
        static member round = FssTypes.Background.Round |> repeatValue'
        static member noRepeat = FssTypes.Background.NoRepeat |> repeatValue'

        static member inherit' = FssTypes.Inherit |> repeatValue'
        static member initial = FssTypes.Initial |> repeatValue'
        static member unset = FssTypes.Unset |> repeatValue'

    /// Specifies how background is repeated.
    /// Valid parameters:
    /// - BackgroundRepeat
    /// - Inherit
    /// - Initial
    /// - Unset
    let BackgroundRepeat' = BackgroundRepeat.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-size
    let private sizeValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BackgroundSize
    let private sizeValue' = sizeToString >> sizeValue

    [<Erase>]
    /// Specifies size of background.
    type BackgroundSize =
        static member value (size: FssTypes.IBackgroundSize) = size |> sizeValue'
        static member value (s1: FssTypes.IBackgroundSize, s2: FssTypes.IBackgroundSize) =
            sprintf "%s %s" (sizeToString s1) (sizeToString s2)
                |> sizeValue

        static member cover = FssTypes.Background.Size.Cover |> sizeValue'
        static member contain = FssTypes.Background.Size.Contain |> sizeValue'

        static member auto = FssTypes.Auto |> sizeValue'
        static member inherit' = FssTypes.Inherit |> sizeValue'
        static member initial = FssTypes.Initial |> sizeValue'
        static member unset = FssTypes.Unset |> sizeValue'

    /// Specifies size of background.
    /// Valid parameters:
    /// - BackgroundSize
    /// - Units.Size
    /// - Units.Percent
    /// - Inherit
    /// - Initial
    /// - Unset
    /// - Auto
    let BackgroundSize' = BackgroundSize.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-attachment
    let private attachmentValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BackgroundAttachment
    let private attachmentValue' = attachmentToString >> attachmentValue

    [<Erase>]
    /// Specifies how background is fixed within viewport.
    type BackgroundAttachment =
        static member value (attachment: FssTypes.IBackgroundAttachment) = attachment |> attachmentValue'
        static member scroll = FssTypes.Background.Attachment.Scroll |> attachmentValue'
        static member fixed' = FssTypes.Background.Attachment.Fixed |> attachmentValue'
        static member local = FssTypes.Background.Attachment.Local |> attachmentValue'

        static member inherit' = FssTypes.Inherit |> attachmentValue'
        static member initial = FssTypes.Initial |> attachmentValue'
        static member unset = FssTypes.Unset |> attachmentValue'

    /// Specifies how background is fixed within viewport.
    /// Valid parameters:
    /// - BackgroundAttachment
    /// - Inherit
    /// - Initial
    /// - Unset
    let BackgroundAttachment' = BackgroundAttachment.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-color
    let private backgroundValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BackgroundColor
    let private backgroundValue' = backgroundColorToString >> backgroundValue

    /// Specifies the background color.
    type BackgroundColorClass (valueFunction: FssTypes.IBackgroundColor -> FssTypes.CssProperty) =
        inherit FssTypes.Color.ColorBase<FssTypes.CssProperty>(valueFunction)
        member this.value color = color |> valueFunction
        member this.inherit' = FssTypes.Inherit |> valueFunction
        member this.initial = FssTypes.Initial |> valueFunction
        member this.unset = FssTypes.Unset |> valueFunction

    let BackgroundColor = BackgroundColorClass(backgroundValue')

    /// Specifies the background color.
    /// Valid parameters:
    /// Color
    let BackgroundColor' = BackgroundColor.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-image
    let private imageValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BackgroundImage
    let private imageValue' = backgroundImageToString >> imageValue

    let BackgroundImage = FssTypes.Background.BackgroundImage(imageValue, imageValue')

    /// Draws background image on element.
    /// Valid parameters:
    /// - Image
    let BackgroundImage' = BackgroundImage.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-position
    let private positionCssValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BackgroundPosition
    let private positionCssValue': (FssTypes.IBackgroundPosition -> FssTypes.CssProperty) = positionToString >> positionCssValue

    [<Erase>]
    /// Specifies the position of a background.
    type BackgroundPosition =
        static member top = FssTypes.Background.Position.Top |> positionCssValue'
        static member bottom = FssTypes.Background.Position.Bottom |> positionCssValue'
        static member left = FssTypes.Background.Position.Left |> positionCssValue'
        static member right = FssTypes.Background.Position.Right |> positionCssValue'
        static member center = FssTypes.Background.Position.Center |> positionCssValue'

        static member value (value: FssTypes.IBackgroundPosition) = value |> positionCssValue'
        static member values (v1: FssTypes.IBackgroundPosition, v2: FssTypes.IBackgroundPosition) =
            sprintf "%s %s" (positionToString v1) (positionToString v2) |> positionCssValue
        static member values (v1: FssTypes.IBackgroundPosition, v2: FssTypes.IBackgroundPosition, v3: FssTypes.IBackgroundPosition) =
            sprintf "%s %s %s" (positionToString v1) (positionToString v2) (positionToString v3) |> positionCssValue
        static member values (v1: FssTypes.IBackgroundPosition, v2: FssTypes.IBackgroundPosition, v3: FssTypes.IBackgroundPosition, v4: FssTypes.IBackgroundPosition) =
            sprintf "%s %s %s %s" (positionToString v1) (positionToString v2) (positionToString v3) (positionToString v4) |> positionCssValue

        static member inherit' = FssTypes.Inherit |> positionCssValue'
        static member initial = FssTypes.Initial |> positionCssValue'
        static member unset = FssTypes.Unset |> positionCssValue'

    /// Specifies the position of a background.
    /// Valid parameters:
    /// - BackgroundPosition
    /// - Inherit
    /// - Initial
    /// - Unset
    /// - Units.Size
    /// - Units.Percent
    let BackgroundPosition' = BackgroundPosition.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/background-blend-mode
    let private blendModeCssValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BackgroundBlendMode
    let private blendModeCssValue' = blendModeToString >> blendModeCssValue

    let private blendModeValues = Utilities.Helpers.combineComma blendModeToString >> blendModeCssValue

    [<Erase>]
    /// Specifies how an elements background image should interact with its background color.
    type BackgroundBlendMode =
        static member value(blendMode: FssTypes.IBackgroundBlendMode) = blendMode |> blendModeCssValue'
        static member values(blendModes: FssTypes.Background.BlendMode list) = blendModeValues blendModes

        static member multiply = FssTypes.Background.BlendMode.Multiply |> blendModeCssValue'
        static member screen = FssTypes.Background.BlendMode.Screen |> blendModeCssValue'
        static member overlay = FssTypes.Background.BlendMode.Overlay |> blendModeCssValue'
        static member darken = FssTypes.Background.BlendMode.Darken |> blendModeCssValue'
        static member lighten = FssTypes.Background.BlendMode.Lighten |> blendModeCssValue'
        static member colorDodge = FssTypes.Background.BlendMode.ColorDodge |> blendModeCssValue'
        static member colorBurn = FssTypes.Background.BlendMode.ColorBurn |> blendModeCssValue'
        static member hardLight = FssTypes.Background.BlendMode.HardLight |> blendModeCssValue'
        static member softLight = FssTypes.Background.BlendMode.SoftLight |> blendModeCssValue'
        static member difference = FssTypes.Background.BlendMode.Difference |> blendModeCssValue'
        static member exclusion = FssTypes.Background.BlendMode.Exclusion |> blendModeCssValue'
        static member hue = FssTypes.Background.BlendMode.Hue |> blendModeCssValue'
        static member saturation = FssTypes.Background.BlendMode.Saturation |> blendModeCssValue'
        static member color = FssTypes.Background.BlendMode.Color |> blendModeCssValue'
        static member luminosity = FssTypes.Background.BlendMode.Luminosity |> blendModeCssValue'

        static member normal = FssTypes.Normal |> blendModeCssValue'
        static member inherit' = FssTypes.Inherit |> blendModeCssValue'
        static member initial = FssTypes.Initial |> blendModeCssValue'
        static member unset = FssTypes.Unset |> blendModeCssValue'

    /// Specifies how an elements background image should interact with its background color.
    /// Valid parameters:
    /// - BackgroundBlendMode
    /// - Normal
    /// - Inherit
    /// - Initial
    /// - Unset
    let BackgroundBlendMode'  = BackgroundBlendMode.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/isolation
    let private isolationValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.Isolation
    let private isolationValue' = isolationToString >> isolationValue

    [<Erase>]
    /// Specifies how an element is blended with backdrop.
    type Isolation =
        static member value(isolation: FssTypes.IIsolation) = isolation |> isolationValue'

        static member isolate = FssTypes.Background.Isolate |> isolationValue'
        static member auto = FssTypes.Auto |> isolationValue'
        static member inherit' = FssTypes.Inherit |> isolationValue'
        static member initial = FssTypes.Initial |> isolationValue'
        static member unset = FssTypes.Unset |> isolationValue'

    /// Specifies how an element is blended with backdrop.
    /// Valid parameters:
    /// - Isolation
    /// - Auto
    /// - Inherit
    /// - Initial
    /// - Unset
    let Isolation' = Isolation.value

[<AutoOpen>]
module BoxDecorationBreak =
    let private boxDecorationBreakToString (boxDecoration: FssTypes.IBoxDecorationBreak) =
        match boxDecoration with
        | :? FssTypes.Background.BoxDecorationBreak as b -> Utilities.Helpers.duToLowercase b
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown box decoration break"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/box-decoration-break
    let private boxDecorationBreakValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BoxDecorationBreak
    let private boxDecorationBreakValue' = boxDecorationBreakToString >> boxDecorationBreakValue

    [<Erase>]
    /// Specifies how an element is blended with backdrop.
    type BoxDecorationBreak =
        static member value(boxDecorationBreak: FssTypes.IBoxDecorationBreak) = boxDecorationBreak |> boxDecorationBreakValue'

        static member slice = FssTypes.Background.Slice |> boxDecorationBreakValue'
        static member clone = FssTypes.Background.Clone |> boxDecorationBreakValue'
        static member inherit' = FssTypes.Inherit |> boxDecorationBreakValue'
        static member initial = FssTypes.Initial |> boxDecorationBreakValue'
        static member unset = FssTypes.Unset |> boxDecorationBreakValue'


    /// Specifies how an element is blended with backdrop.
    /// Valid parameters:
    /// - BoxDecorationBreak
    /// - Auto
    /// - Inherit
    /// - Initial
    /// - Unset
    let BoxDecorationBreak' = BoxDecorationBreak.value


