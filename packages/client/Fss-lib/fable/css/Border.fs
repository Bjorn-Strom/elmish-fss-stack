namespace Fss

open Fable.Core

[<AutoOpen>]
module Border =

    let private radiusToString (radius: FssTypes.IBorderRadius) =
        match radius with
        | :? FssTypes.Length as s -> FssTypes.unitHelpers.sizeToString s
        | :? FssTypes.Percent as p -> FssTypes.unitHelpers.percentToString p
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "unknown border radius"

    let private widthToString (width: FssTypes.IBorderWidth) =
        match width with
            | :? FssTypes.Border.Width as b -> Utilities.Helpers.duToLowercase b
            | :? FssTypes.Length as s -> FssTypes.unitHelpers.sizeToString s
            | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
            | _ -> "unknown border width"

    let private styleToString (style: FssTypes.IBorderStyle) =
        match style with
        | :? FssTypes.Border.Style as b -> Utilities.Helpers.duToLowercase b
        | :? FssTypes.None' -> FssTypes.masterTypeHelpers.none
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown border style"

    let private collapseToString (collapse: FssTypes.IBorderCollapse) =
        match collapse with
        | :? FssTypes.Border.Collapse as c -> Utilities.Helpers.duToLowercase c
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "unknown border collapse"
    let private imageOutsetToString (imageOutset: FssTypes.IBorderImageOutset) =
        let stringifyOutset (FssTypes.Border.ImageOutset v) = string v

        match imageOutset with
        | :? FssTypes.Length as s -> FssTypes.unitHelpers.sizeToString s
        | :? FssTypes.Percent as p -> FssTypes.unitHelpers.percentToString p
        | :? FssTypes.Border.ImageOutset as i -> stringifyOutset i
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "unknown border image outset"

    let private repeatToString (repeat: FssTypes.IBorderRepeat) =
        match repeat with
        | :? FssTypes.Border.ImageRepeat as b -> Utilities.Helpers.duToLowercase b
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "unknown border repeat"

    let private imageSliceToString (imageSlice: FssTypes.IBorderImageSlice) =
        let stringifySlice =
            function
                | FssTypes.Border.ImageSlice.Value i -> string i
                | FssTypes.Border.ImageSlice.Fill -> "fill"

        match imageSlice with
        | :? FssTypes.Border.ImageSlice as i -> stringifySlice i
        | :? FssTypes.Length as s -> FssTypes.unitHelpers.sizeToString s
        | :? FssTypes.Percent as p -> FssTypes.unitHelpers.percentToString p
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown border image slice"

    let private borderColorToString (borderColor: FssTypes.IBorderColor) =
        match borderColor with
        | :? FssTypes.Color.ColorType as c -> FssTypes.Color.colorHelpers.colorToString c
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown border color"

    let private spacingToString (spacing: FssTypes.IBorderSpacing) =
        match spacing with
        | :? FssTypes.Length as s -> FssTypes.unitHelpers.sizeToString s
        | :? FssTypes.Percent as p -> FssTypes.unitHelpers.percentToString p
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown border spacing"

    let private imageWidthToString (imageWidth: FssTypes.IBorderImageWidth) =
        match imageWidth with
        | :? FssTypes.CssFloat as f -> FssTypes.masterTypeHelpers.FloatToString f
        | :? FssTypes.Length as s -> FssTypes.unitHelpers.sizeToString s
        | :? FssTypes.Percent as p -> FssTypes.unitHelpers.percentToString p
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | _ -> "Unknown border image width"

    let private imageSourceToString (imageSource: FssTypes.IBorderImageSource) =
        match imageSource with
        | :? FssTypes.None' -> FssTypes.masterTypeHelpers.none
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | _ -> "Unknown border image source"

    let private borderToString (border: FssTypes.IBorder) =
            match border with
            | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
            | :? FssTypes.None' -> FssTypes.masterTypeHelpers.none
            | _ -> "Unknown border"

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border
    let private borderValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.Border
    let private borderValue' = borderToString >> borderValue

    [<Erase>]
    /// Resets border.
    type Border =
        static member value (border: FssTypes.IBorder) = border |> borderValue'
        static member none = FssTypes.None' |> borderValue'
        static member inherit' = FssTypes.Inherit |> borderValue'
        static member initial = FssTypes.Initial |> borderValue'
        static member unset = FssTypes.Unset |> borderValue'

    /// Resets border.
    /// Valid parameters:
    /// - Inherit
    /// - Initial
    /// - Unset
    /// - None
    let Border' = Border.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-radius
    let private radiusValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderRadius
    let private radiusValue' = radiusToString >> radiusValue

    [<Erase>]
    /// Specifies roundness of border edge.
    type BorderRadius =
        static member value (radius: FssTypes.IBorderRadius) =
            sprintf "%s"
                (radiusToString radius)
                |> radiusValue
        static member value (topLeftBottomRight: FssTypes.IBorderRadius, topRightBottomLeft: FssTypes.IBorderRadius) =
            sprintf "%s %s"
                (radiusToString topLeftBottomRight)
                (radiusToString topRightBottomLeft)
                |> radiusValue
        static member value (topLeft: FssTypes.IBorderRadius, topRightBottomLeft: FssTypes.IBorderRadius, bottomRight: FssTypes.IBorderRadius) =
            sprintf "%s %s %s"
                (radiusToString topLeft)
                (radiusToString topRightBottomLeft)
                (radiusToString bottomRight)
                |> radiusValue
        static member value (topLeft: FssTypes.IBorderRadius, topRight: FssTypes.IBorderRadius, bottomRight: FssTypes.IBorderRadius, bottomLeft: FssTypes.IBorderRadius) =
            sprintf "%s %s %s %s"
                (radiusToString topLeft)
                (radiusToString topRight)
                (radiusToString bottomRight)
                (radiusToString bottomLeft)
                |> radiusValue

        static member inherit' = FssTypes.Inherit |> radiusValue'
        static member initial = FssTypes.Initial |> radiusValue'
        static member unset = FssTypes.Unset |> radiusValue'

    /// Specifies roundness of border edge.
    /// Valid parameters:
    /// - Units.Size
    /// - Units.Percent
    /// - Inherit
    /// - Initial
    /// - Unset
    let BorderRadius' = BorderRadius.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-bottom-left-radius
    let private bottomLeftRadiusValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderBottomLeftRadius
    let private bottomLeftRadiusValue' = radiusToString >> bottomLeftRadiusValue

    [<Erase>]
    /// Specifies roundness of bottom left corner.
    type BorderBottomLeftRadius =
        static member value (horizontal: FssTypes.IBorderRadius) =
            sprintf "%s" (radiusToString horizontal) |> bottomLeftRadiusValue
        static member value (horizontal: FssTypes.IBorderRadius, vertical: FssTypes.IBorderRadius) =
            sprintf "%s %s" (radiusToString horizontal) (radiusToString vertical) |> bottomLeftRadiusValue
        static member inherit' = FssTypes.Inherit |> bottomLeftRadiusValue'
        static member initial = FssTypes.Initial |> bottomLeftRadiusValue'
        static member unset = FssTypes.Unset |> bottomLeftRadiusValue'

    /// Specifies roundness of bottom left corner.
    /// Valid parameters:
    /// - Units.Size
    /// - Units.Percent
    /// - Inherit
    /// - Initial
    /// - Unset
    let BorderBottomLeftRadius' = BorderBottomLeftRadius.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-bottom-right-radius
    let private bottomRightRadiusValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderBottomRightRadius
    let private bottomRightRadiusValue' = radiusToString >> bottomRightRadiusValue

    [<Erase>]
    /// Specifies roundness of bottom right corner.
    type BorderBottomRightRadius =
        static member value (horizontal: FssTypes.IBorderRadius) =
            sprintf "%s" (radiusToString horizontal) |> bottomRightRadiusValue
        static member value (horizontal: FssTypes.IBorderRadius, vertical: FssTypes.IBorderRadius) =
            sprintf "%s %s" (radiusToString horizontal) (radiusToString vertical) |> bottomRightRadiusValue
        static member inherit' = FssTypes.Inherit |> bottomRightRadiusValue'
        static member initial = FssTypes.Initial |> bottomRightRadiusValue'
        static member unset = FssTypes.Unset |> bottomRightRadiusValue'

    /// Specifies roundness of bottom right corner.
    /// Valid parameters:
    /// - Units.Size
    /// - Units.Percent
    /// - Inherit
    /// - Initial
    /// - Unset
    let BorderBottomRightRadius' = BorderBottomRightRadius.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-top-left-radius
    let private topLeftRadiusValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderTopLeftRadius
    let private topLeftRadiusValue' = radiusToString >> topLeftRadiusValue

    [<Erase>]
    /// Specifies roundness of top left corner.
    type BorderTopLeftRadius =
        static member value (horizontal: FssTypes.IBorderRadius) =
            sprintf "%s" (radiusToString horizontal) |> topLeftRadiusValue
        static member value (horizontal: FssTypes.IBorderRadius, vertical: FssTypes.IBorderRadius) =
            sprintf "%s %s" (radiusToString horizontal) (radiusToString vertical) |> topLeftRadiusValue
        static member inherit' = FssTypes.Inherit |> topLeftRadiusValue'
        static member initial = FssTypes.Initial |> topLeftRadiusValue'
        static member unset = FssTypes.Unset |> topLeftRadiusValue'

    /// Specifies roundness of top left corner.
    /// Valid parameters:
    /// - Units.Size
    /// - Units.Percent
    /// - Inherit
    /// - Initial
    /// - Unset
    let BorderTopLeftRadius' = BorderTopLeftRadius.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-top-right-radius
    let private topRightRadiusValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderTopRightRadius
    let private topRightRadiusValue' = radiusToString >> topRightRadiusValue

    [<Erase>]
    /// Specifies roundness of top right corner.
    type BorderTopRightRadius =
        static member value (horizontal: FssTypes.IBorderRadius) =
            sprintf "%s" (radiusToString horizontal) |> topRightRadiusValue
        static member value (horizontal: FssTypes.IBorderRadius, vertical: FssTypes.IBorderRadius) =
            sprintf "%s %s" (radiusToString horizontal) (radiusToString vertical) |> topRightRadiusValue
        static member inherit' = FssTypes.Inherit |> topRightRadiusValue'
        static member initial = FssTypes.Initial |> topRightRadiusValue'
        static member unset = FssTypes.Unset |> topRightRadiusValue'

    /// Specifies roundness of top right corner.
    /// Valid parameters.
    /// - Units.Size
    /// - Units.Percent
    /// - Inherit
    /// - Initial
    /// - Unset
    let BorderTopRightRadius' = BorderTopRightRadius.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-width
    let private widthValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderWidth
    let private widthValue': (FssTypes.IBorderWidth -> FssTypes.CssProperty) = widthToString >> widthValue

    [<Erase>]
    /// Specifies width of border.
    type BorderWidth =
        static member value (width: FssTypes.IBorderWidth) = widthValue (widthToString width)
        static member value (vertical: FssTypes.IBorderWidth, horizontal: FssTypes.IBorderWidth) =
            sprintf "%s %s"
                (widthToString vertical)
                (widthToString horizontal)
            |> widthValue
        static member value (top: FssTypes.IBorderWidth, horizontal: FssTypes.IBorderWidth, bottom: FssTypes.IBorderWidth) =
            sprintf "%s %s %s"
                (widthToString top)
                (widthToString horizontal)
                (widthToString bottom)
            |> widthValue
        static member value (top: FssTypes.IBorderWidth, right: FssTypes.IBorderWidth, bottom: FssTypes.IBorderWidth, left: FssTypes.IBorderWidth) =
            sprintf "%s %s %s %s"
                (widthToString top)
                (widthToString right)
                (widthToString bottom)
                (widthToString left)
            |> widthValue

        static member thin = FssTypes.Border.Width.Thin |> widthValue'
        static member medium = FssTypes.Border.Width.Medium |> widthValue'
        static member thick = FssTypes.Border.Width.Thick |> widthValue'

        static member inherit' = FssTypes.Inherit |> widthValue'
        static member initial = FssTypes.Initial |> widthValue'
        static member unset = FssTypes.Unset |> widthValue'

    /// Specifies width of border.
    /// Valid parameters:
    /// - BorderWidth
    /// - None
    /// - Inherit
    /// - Initial
    /// - Unset
    let BorderWidth' = BorderWidth.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-top-width
    let internal topWidthValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderTopWidth
    let internal topWidthValue' = widthToString >> topWidthValue

    /// Specifies width of top border.
    let BorderTopWidth = FssTypes.Border.BorderValue(topWidthValue')

    /// Specifies width of top border.
    /// Valid parameters:
    /// - BorderWidth
    /// - None
    /// - Inherit
    /// - Initial
    /// - Unset
    let BorderTopWidth' = BorderTopWidth.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-right-width
    let private rightWidthValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderRightWidth
    let private rightWidthValue' = widthToString >> rightWidthValue

    /// Specifies width of right border.
    let BorderRightWidth = FssTypes.Border.BorderValue(rightWidthValue')

    /// Specifies width of right border.
    /// - BorderWidth
    /// - None
    /// - Inherit
    /// - Initial
    /// - Unset
    let BorderRightWidth' = BorderRightWidth.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-bottom-width
    let private bottomWidthValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderBottomWidth
    let private bottomWidthValue' = widthToString >> bottomWidthValue

    /// Specifies width of bottom border.
    let BorderBottomWidth = FssTypes.Border.BorderValue(bottomWidthValue')

    /// Specifies width of bottom border.
    /// Valid parameters:
    /// - BorderWidth
    /// - None
    /// - Inherit
    /// - Initial
    /// - Unset
    let BorderBottomWidth' = BorderBottomWidth.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-left-width
    let private leftWidthValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderLeftWidth
    let private leftWidthValue' = widthToString >> leftWidthValue

    /// Specifies width of left border.
    let BorderLeftWidth = FssTypes.Border.BorderValue(leftWidthValue')

    /// Specifies width of left border.
    /// Valid parameters:
    /// - BorderWidth
    /// - None
    /// - Inherit
    /// - Initial
    /// - Unset
    let BorderLeftWidth' = BorderLeftWidth.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-style
    let private styleValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderStyle
    let private styleValue' = styleToString >> styleValue

    /// Specifies style of border.
    let BorderStyle = FssTypes.Border.BorderStyle(styleToString, styleValue, styleValue')

    /// Specifies style of border.
    /// Valid parameters:
    /// - BorderStyle
    /// - None
    /// - Inherit
    /// - Initial
    /// - Unset
    let BorderStyle' = BorderStyle.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-top-style
    let private topStyleValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderTopStyle
    let private topStyleValue' = styleToString >> topStyleValue

    /// Specifies style of top border.
    let BorderTopStyle = FssTypes.Border.BorderSideStyle(topStyleValue')

    /// Specifies style of top border.
    /// Valid parameters:
    /// - BorderStyle
    /// - None
    /// - Inherit
    /// - Initial
    /// - Unset
    let BorderTopStyle' = BorderTopStyle.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-right-style
    let private rightStyleValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderRightStyle
    let private rightStyleValue' = styleToString >> rightStyleValue

    /// Specifies style of right border.
    let BorderRightStyle = FssTypes.Border.BorderSideStyle(rightStyleValue')

    /// Specifies style of right border.
    /// Valid parameters:
    /// - BorderStyle
    /// - None
    /// - Inherit
    /// - Initial
    /// - Unset
    let BorderRightStyle' = BorderRightStyle.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-bottom-style
    let private bottomStyleValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderBottomStyle
    let private bottomStyleValue' = styleToString >> bottomStyleValue

    /// Specifies style of bottom border.
    let BorderBottomStyle = FssTypes.Border.BorderSideStyle(bottomStyleValue')

    /// Specifies style of bottom border.
    /// Valid parameters:
    /// - BorderStyle
    /// - None
    /// - Inherit
    /// - Initial
    /// - Unset
    let BorderBottomStyle' = BorderBottomStyle.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-left-style
    let private leftStyleValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderLeftStyle
    let private leftStyleValue' = styleToString >> leftStyleValue

    let BorderLeftStyle = FssTypes.Border.BorderSideStyle(leftStyleValue')

    /// Specifies style of left border.
    /// Valid parameters:
    /// - BorderStyle
    /// - None
    /// - Inherit
    /// - Initial
    /// - Unset
    let BorderLeftStyle' = BorderLeftStyle.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-collapse
    let private collapseValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderCollapse
    let private collapseValue' = collapseToString >> collapseValue

    [<Erase>]
    type BorderCollapse =
        static member value (collapse: FssTypes.IBorderCollapse) = collapse |> collapseValue'
        static member collapse = FssTypes.Border.Collapse |> collapseValue'
        static member separate = FssTypes.Border.Separate |> collapseValue'

        static member inherit' = FssTypes.Inherit |> collapseValue'
        static member initial = FssTypes.Initial |> collapseValue'
        static member unset = FssTypes.Unset |> collapseValue'

    /// Specifies whether cells inside a table have shared borders.
    /// Valid parameters:
    /// - BorderCollapse
    /// - Inherit
    /// - Initial
    /// - Unset
    let BorderCollapse' =  BorderCollapse.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-image-outset
    let private imageOutsetValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderImageOutset
    let private imageOutsetValue' = imageOutsetToString >> imageOutsetValue

    [<Erase>]
    /// Specifies distance between elements border and border box.
    type BorderImageOutset =
        static member value (outset: FssTypes.IBorderImageOutset) = outset |> imageOutsetValue'
        static member value (vertical: FssTypes.IBorderImageOutset, horizontal: FssTypes.IBorderImageOutset) =
            sprintf "%s %s" (imageOutsetToString vertical) (imageOutsetToString horizontal) |> imageOutsetValue
        static member value (top: FssTypes.IBorderImageOutset, horizontal: FssTypes.IBorderImageOutset, bottom: FssTypes.IBorderImageOutset) =
            sprintf "%s %s %s"
                (imageOutsetToString top)
                (imageOutsetToString horizontal)
                (imageOutsetToString bottom)
            |> imageOutsetValue
        static member value (top: FssTypes.IBorderImageOutset, right: FssTypes.IBorderImageOutset, bottom: FssTypes.IBorderImageOutset, left: FssTypes.IBorderImageOutset) =
            sprintf "%s %s %s %s"
                (imageOutsetToString top)
                (imageOutsetToString right)
                (imageOutsetToString bottom)
                (imageOutsetToString left)
            |> imageOutsetValue

        static member inherit' = FssTypes.Inherit |> imageOutsetValue'
        static member initial = FssTypes.Initial |> imageOutsetValue'
        static member unset = FssTypes.Unset |> imageOutsetValue'

    /// Specifies distance between elements border and border box.
    /// Valid parameters:
    /// - Units.Size
    /// - Units.Percent
    /// - BorderImageOutset
    /// - Inherit
    /// - Initial
    /// - Unset
    let BorderImageOutset' = BorderImageOutset.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-image-repeat
    let private imageRepeatValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderImageRepeat
    let private imageRepeatValue' = repeatToString >> imageRepeatValue

    [<Erase>]
    /// Specifies how border image surrounds border box.
    type BorderImageRepeat =
        static member value (repeat: FssTypes.IBorderRepeat) = repeat |> imageRepeatValue'
        static member value (vertical: FssTypes.IBorderRepeat, horizontal: FssTypes.IBorderRepeat) =
            sprintf "%s %s" (repeatToString vertical) (repeatToString horizontal)
            |> imageRepeatValue
        static member stretch = FssTypes.Border.ImageRepeat.Stretch |> imageRepeatValue'
        static member repeat = FssTypes.Border.ImageRepeat.Repeat |> imageRepeatValue'
        static member round = FssTypes.Border.ImageRepeat.Round |> imageRepeatValue'
        static member space = FssTypes.Border.ImageRepeat.Space |> imageRepeatValue'

        static member inherit' = FssTypes.Inherit |> imageRepeatValue'
        static member initial = FssTypes.Initial |> imageRepeatValue'
        static member unset = FssTypes.Unset |> imageRepeatValue'

    /// Specifies how border image surrounds border box.
    /// Valid parameters:
    /// - BorderImageRepeat
    /// - Inherit
    /// - Initial
    /// - Unset
    let BorderImageRepeat' = BorderImageRepeat.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-image-slice
    let private imageSliceValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderImageSlice
    let private imageSliceValue': (FssTypes.IBorderImageSlice -> FssTypes.CssProperty) = imageSliceToString >> imageSliceValue

    [<Erase>]
    /// Specifies how border image is divided into regions.
    type BorderImageSlice =
        static member fill = FssTypes.Border.ImageSlice.Fill |> imageSliceValue'
        static member value (imageSlice: FssTypes.IBorderImageSlice) = imageSlice |> imageSliceValue'
        static member value (vertical: FssTypes.IBorderImageSlice, horizontal: FssTypes.IBorderImageSlice) =
            sprintf "%s %s" (imageSliceToString vertical) (imageSliceToString horizontal) |> imageSliceValue
        static member value (w1: FssTypes.IBorderImageSlice, w2: FssTypes.IBorderImageSlice, w3: FssTypes.IBorderImageSlice) =
            sprintf "%s %s %s"
                (imageSliceToString w1)
                (imageSliceToString w2)
                (imageSliceToString w3)
            |> imageSliceValue
        static member value (w1: FssTypes.IBorderImageSlice, w2: FssTypes.IBorderImageSlice, w3: FssTypes.IBorderImageSlice, w4: FssTypes.IBorderImageSlice) =
            sprintf "%s %s %s %s"
                (imageSliceToString w1)
                (imageSliceToString w2)
                (imageSliceToString w3)
                (imageSliceToString w4)
            |> imageSliceValue

        static member inherit' = FssTypes.Inherit |> imageSliceValue'
        static member initial = FssTypes.Initial |> imageSliceValue'
        static member unset = FssTypes.Unset |> imageSliceValue'

    /// Specifies how border image is divided into regions.
    /// Valid parameters:
    /// - BorderImageSlice
    /// - Units.Size
    /// - Units.Percent
    /// - Inherit
    /// - Initial
    /// - Unset
    let BorderImageSlice' = BorderImageSlice.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-color
    let private borderColorValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderColor
    let private borderColorValue' = borderColorToString >> borderColorValue

    /// Specifies color of border.
    let BorderColor = FssTypes.Border.BorderColor (borderColorToString, borderColorValue, borderColorValue')

    /// Specifies color of border.
    /// Valid parameters:
    /// - FssTypes.ColorType</c>
    /// - Inherit
    /// - Initial
    /// - Unset
    let BorderColor' = BorderColor.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-top-color
    let private topColorValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderTopColor
    let private topColorValue' = borderColorToString >> topColorValue

    /// Specifies color of top border.
    let BorderTopColor = FssTypes.Border.BorderSideColor(topColorValue')

    /// Specifies color of top border.
    /// Valid parameters:
    /// - Color
    /// - Inherit
    /// - Initial
    /// - Unset
    let BorderTopColor' = BorderTopColor.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-right-color
    let private rightColorValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderRightColor
    let private rightColorValue' = borderColorToString >> rightColorValue
    let BorderRightColor = FssTypes.Border.BorderSideColor(rightColorValue')

    /// Specifies color of right border.
    /// Valid parameters:
    /// - Color
    /// - Inherit
    /// - Initial
    /// - Unset
    let BorderRightColor' = BorderRightColor.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-bottom-color
    let private bottomColorValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderBottomColor
    let private bottomColorValue' = borderColorToString >> bottomColorValue

    /// Specifies color of bottom border.
    let BorderBottomColor = FssTypes.Border.BorderSideColor(bottomColorValue')

    /// Specifies color of bottom border.
    /// Valid parameters:
    /// - Color
    /// - Inherit
    /// - Initial
    /// - Unset
    let BorderBottomColor' = BorderBottomColor.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-left-color
    let private leftColorValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderLeftColor
    let private leftColorValue' = borderColorToString >> leftColorValue

    /// Specifies color of left border.
    let BorderLeftColor = FssTypes.Border.BorderSideColor(leftColorValue')

    /// Specifies color of left border.
    /// Valid parameters:
    /// - ColorType
    /// - Inherit
    /// - Initial
    /// - Unset
    let BorderLeftColor' = BorderLeftColor.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-spacing
    let private spacingValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderSpacing
    let private spacingValue' = spacingToString >> spacingValue

    [<Erase>]
    /// Specifies distance borders of table cells.
    type BorderSpacing =
        static member value (width: FssTypes.IBorderSpacing) =
            spacingValue (spacingToString width)
        static member value (w1: FssTypes.IBorderSpacing, w2: FssTypes.IBorderSpacing) =
            sprintf "%s %s"
                (spacingToString w1)
                (spacingToString w2)
            |> spacingValue
        static member inherit' = FssTypes.Inherit |> spacingValue'
        static member initial = FssTypes.Initial |> spacingValue'
        static member unset = FssTypes.Unset |> spacingValue'

    /// Specifies distance borders of table cells.
    /// Valid parameters:
    /// - Units.Size
    /// - Units.Percent
    /// - Inherit
    /// - Initial
    /// - Unset
    let BorderSpacing' = BorderSpacing.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-image-width
    let private imageWidthValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderImageWidth
    let private imageWidthValue' = imageWidthToString >> imageWidthValue

    [<Erase>]
    /// Specifies width of border image.
    type BorderImageWidth =
        static member value (width: FssTypes.IBorderImageWidth) = width |> imageWidthValue'
        static member value (w1: FssTypes.IBorderImageWidth, w2: FssTypes.IBorderImageWidth) =
            sprintf "%s %s"
                (imageWidthToString w1)
                (imageWidthToString w2)
            |> imageWidthValue
        static member value (w1: FssTypes.IBorderImageWidth, w2: FssTypes.IBorderImageWidth, w3: FssTypes.IBorderImageWidth) =
            sprintf "%s %s %s"
                (imageWidthToString w1)
                (imageWidthToString w2)
                (imageWidthToString w3)
            |> imageWidthValue
        static member value (w1: FssTypes.IBorderImageWidth, w2: FssTypes.IBorderImageWidth, w3: FssTypes.IBorderImageWidth, w4: FssTypes.IBorderImageWidth) =
            sprintf "%s %s %s %s"
                (imageWidthToString w1)
                (imageWidthToString w2)
                (imageWidthToString w3)
                (imageWidthToString w4)
            |> imageWidthValue

        static member auto = FssTypes.Auto |> imageWidthValue'
        static member inherit' = FssTypes.Inherit |> imageWidthValue'
        static member initial = FssTypes.Initial |> imageWidthValue'
        static member unset = FssTypes.Unset |> imageWidthValue'

    /// Specifies width of border image.
    /// Valid parameters:
    /// - CssFloat
    /// - Units.Size
    /// - Units.Percent
    /// - Inherit
    /// - Initial
    /// - Unset
    /// - Auto
    let BorderImageWidth' = BorderImageWidth.value

    // https://developer.mozilla.org/en-US/docs/Web/CSS/border-image-source
    let private imageValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.BorderImageSource
    let private imageValue' = imageSourceToString >> imageValue

    /// Specifies width of border image.
    let BorderImageSource = FssTypes.Border.BorderImage(imageValue, imageValue')

    /// Specifies width of border image.
    /// Valid parameters:
    /// - Image
    /// - Inherit
    /// - Initial
    /// - Unset
    /// - None
    let BorderImageSource' = BorderImageSource.value