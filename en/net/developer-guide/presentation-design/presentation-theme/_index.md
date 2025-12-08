---
title: Manage Presentation Themes in .NET
linktitle: Presentation Theme
type: docs
weight: 10
url: /net/presentation-theme/
keywords:
- PowerPoint theme
- presentation theme
- slide theme
- set theme
- change theme
- manage theme
- theme color
- additional palette
- theme font
- theme style
- theme effect
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Master presentation themes in Aspose.Slides for .NET to create, customize and convert PowerPoint files with consistent branding."
---

A presentation theme defines the properties of design elements. When you select a presentation theme, you are essentially choosing a specific set of visual elements and their properties.

In PowerPoint, a theme comprises colors, [fonts](/slides/net/powerpoint-fonts/), [background styles](/slides/net/presentation-background/), and effects.

![theme-constituents](theme-constituents.png)

## **Change Theme Color**

A PowerPoint theme uses a specific set of colors for different elements on a slide. If you don't like the colors, you change them colors by applying new colors for the theme. To allow you select a new theme color, Aspose.Slides provides values under the [SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/schemecolor/) enumeration.

This C# code shows you how to change the accent color for a theme:

```c#
using (Presentation pres = new Presentation())
    
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
}
```

You can determine the resulting color's effective value this way:

```c#
var fillEffective = shape.FillFormat.GetEffective();

Console.WriteLine($"{fillEffective.SolidFillColor.Name} ({fillEffective.SolidFillColor})"); // ff8064a2 (Color [A=255, R=128, G=100, B=162])
```

To further demonstrate the color change operation, we create another element and assign the accent color (from the initial operation) to it. Then we change the color in the theme:

```c#
IAutoShape otherShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.FillFormat.FillType = FillType.Solid;

otherShape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

pres.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
```

The new color is applied automatically on both elements.

### **Set Theme Color from an Additional Palette**

When you apply luminance transformations to the main theme color(1), colors from the additional palette(2) are formed. You can then set and get those theme colors. 

![additional-palette-colors](additional-palette-colors.png)

**1** - Main theme colors

**2** - Colors from the additional palette.

This C# code demonstrates an operation where additional palette colors are obtained from the main theme color and then used in shapes:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Accent 4
    IShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

    // Accent 4, Lighter 80%
    IShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.8f);

    // Accent 4, Lighter 60%
    IShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.6f);

    // Accent 4, Lighter 40%
    IShape shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.FillFormat.FillType = FillType.Solid;
    shape4.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.4f);

    // Accent 4, Darker 25%
    IShape shape5 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.FillFormat.FillType = FillType.Solid;
    shape5.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape5.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // Accent 4, Darker 50%
    IShape shape6 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.FillFormat.FillType = FillType.Solid;
    shape6.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
    shape6.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.Save("example.pptx", SaveFormat.Pptx);
}
```

## **Change Theme Font**

To allow you select fonts for themes and other purposes, Aspose.Slides uses these special identifiers (similar to those used in PowerPoint):

* **+mn-lt** - Body Font Latin (Minor Latin Font)
* **+mj-lt** -Heading Font Latin (Major Latin Font)
* **+mn-ea** - Body Font East Asian (Minor East Asian Font)
* **+mj-ea** - Body Font East Asian (Minor East Asian Font)

This C# code shows you how to assign the Latin font to a theme element:

```c#
IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Theme text format");

paragraph.Portions.Add(portion);

shape.TextFrame.Paragraphs.Add(paragraph);

portion.PortionFormat.LatinFont = new FontData("+mn-lt");
```

This C# code shows you how to change the presentation theme font:

```c#
pres.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");
```

The font in all text boxes will be updated.

{{% alert color="primary" title="TIP" %}} 

You may want to see [PowerPoint fonts](/slides/net/powerpoint-fonts/).

{{% /alert %}}

## **Change Theme Background Style**

By default, the PowerPoint app provides 12 predefined backgrounds but only 3 from those 12 backgrounds are saved in a typical presentation. 

![todo:image_alt_text](presentation-design_8.png)

For example, after you save a presentation in the PowerPoint app, you can run this C# code to find out the number predefined backgrounds in the presentation:

```c#
using (Presentation pres = new Presentation("pres.pptx"))

{
    int numberOfBackgroundFills = pres.MasterTheme.FormatScheme.BackgroundFillStyles.Count;

    Console.WriteLine($"Number of background fill styles for theme is {numberOfBackgroundFills}");
}
```

{{% alert color="warning" %}} 

Using the [BackgroundFillStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) property from the [FormatScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/) class, you can add or access the background style in a PowerPoint theme. 

{{% /alert %}}

This C# code shows you how to set the background for a presentation:

```c#
pres.Masters[0].Background.StyleIndex = 2;
```

**Index guide**: 0 is used for no fill. The index starts from 1.

{{% alert color="primary" title="TIP" %}} 

You may want to see [PowerPoint Background](/slides/net/presentation-background/).

{{% /alert %}}

## **Change Theme Effect**

A PowerPoint theme usually contains 3 values for each style array. Those arrays are combined into these 3 effects: subtle, moderate, and intense. For example, this is the outcome when the effects are applied to a specific shape:

![todo:image_alt_text](presentation-design_10.png)

Using 3 properties ([FillStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/fillstyles), [LineStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/linestyles), [EffectStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/effectstyles)) from the [FormatScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme) class you can change the elements in a theme (even more flexibly than the options in PowerPoint).

This C# code shows you how to change a theme effect by altering parts of elements:

```c#
using (Presentation pres = new Presentation("Subtle_Moderate_Intense.pptx"))
{
    pres.MasterTheme.FormatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = Color.Red;

    pres.MasterTheme.FormatScheme.FillStyles[2].FillType = FillType.Solid;

    pres.MasterTheme.FormatScheme.FillStyles[2].SolidFillColor.Color = Color.ForestGreen;

    pres.MasterTheme.FormatScheme.EffectStyles[2].EffectFormat.OuterShadowEffect.Distance = 10f;

    pres.Save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat.Pptx);
}
```

The resulting changes in fill color, fill type, shadow effect, etc:

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

**Can I apply a theme to a single slide without changing the master?**

Yes. Aspose.Slides support slide-level theme overrides, so you can apply a local theme to just that slide while keeping the master theme intact (via the [SlideThemeManager](https://reference.aspose.com/slides/net/aspose.slides.theme/slidethememanager/)).

**What’s the safest way to carry a theme from one presentation to another?**

[Clone slides](/slides/net/clone-slides/) together with their master into the target presentation. This preserves the original master, layouts, and the associated theme so the appearance remains consistent.

**How can I see the "effective" values after all inheritance and overrides?**

Use the API’s ["effective" views](/slides/net/shape-effective-properties/) for theme/color/font/effect. These return the resolved, final properties after applying the master plus any local overrides.
