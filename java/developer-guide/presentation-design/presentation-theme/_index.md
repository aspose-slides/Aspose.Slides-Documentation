---
title: Presentation Theme
type: docs
weight: 10
url: /java/presentation-theme/
keywords: "Theme, PowerPoint theme, PowerPoint presentation, Java, Aspose.Slides for Java"
description: "PowerPoint presentation theme in Java"
---

A presentation theme defines the properties of design elements. When you select a presentation theme, you are essentially choosing a specific set of visual elements and their properties.

In PowerPoint, a theme comprises colors, [fonts](/slides/java/powerpoint-fonts/), [background styles](/slides/java/presentation-background/), and effects.

![theme-constituents](theme-constituents.png)

## **Change Theme Color**

A PowerPoint theme uses a specific set of colors for different elements on a slide. If you don't like the colors, you change them colors by applying new colors for the theme. To allow you select a new theme color, Aspose.Slides provides values under the [SchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/SchemeColor) enumeration.

This Java code shows you how to change the accent color for a theme:

```java
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
} finally {
    if (pres != null) pres.dispose();
}
```

You can determine the resulting color's effective value this way:

```java
IFillFormatEffectiveData fillEffective = shape.getFillFormat().getEffective();

Color effectiveColor = fillEffective.getSolidFillColor();

System.out.println(String.format("Color [A=%d, R=%d, G=%d, B=%d]", 
        effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
```

To further demonstrate the color change operation, we create another element and assign the accent color (from the initial operation) to it. Then we change the color in the theme:

```java
IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.getFillFormat().setFillType(FillType.Solid);

otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
```

The new color is applied automatically on both elements.

### **Set Theme Color from Additional Palette - Luminance transformation**

Using colors from the additional palette, you can apply luminance transformations to the main color. This Java code demonstrates the operation: xxx

```java

```

## **Change Theme Font**

To allow you select fonts for themes and other purposes, Aspose.Slides uses these special identifiers (similar to those used in PowerPoint):

* **+mn-lt** - Body Font Latin (Minor Latin Font)
* **+mj-lt** -Heading Font Latin (Major Latin Font)
* **+mn-ea** - Body Font East Asian (Minor East Asian Font)
* **+mj-ea** - Body Font East Asian (Major East Asian Font)

This Java code shows you how to assign the Latin font to a theme element:

```java
IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Theme text format");

paragraph.getPortions().add(portion);

shape.getTextFrame().getParagraphs().add(paragraph);

portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));
```

This Java code shows you how to change the presentation theme font:

```java
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
```

The font in all text boxes will be updated.

{{% alert color="primary" title="TIP" %}} 

You may want to see [PowerPoint fonts](/slides/java/powerpoint-fonts/).

{{% /alert %}}

## **Change Theme Background Style**

By default, the PowerPoint app provides 12 predefined backgrounds but only 3 from those 12 backgrounds are saved in a typical presentation. 

![todo:image_alt_text](presentation-design_8.png)

For example, after you save a presentation in the PowerPoint app, you can run this Java code to find out the number of predefined backgrounds in the presentation:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    int numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();

    System.out.println("Number of background fill styles for theme is " + numberOfBackgroundFills);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 

Using the [BackgroundFillStyles](https://reference.aspose.com/slides/java/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) property from the [FormatScheme](https://reference.aspose.com/slides/java/com.aspose.slides/FormatScheme) class, you can add or access the background style in a PowerPoint theme. 

{{% /alert %}} 

This Java code shows you how to set the background for a presentation:

```java
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```

**Index guide**: 0 is used for no fill. The index starts from 1.

{{% alert color="primary" title="TIP" %}} 

You may want to see [PowerPoint Background](/slides/java/presentation-background/).

{{% /alert %}}

## **Change Theme Effect**

A PowerPoint theme usually contains 3 values for each style array. Those arrays are combined into these 3 effects: subtle, moderate, and intense. For example, this is the outcome when the effects are applied to a specific shape:

![todo:image_alt_text](presentation-design_10.png)



Using 3 properties ([FillStyles](https://reference.aspose.com/slides/java/com.aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/java/com.aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/java/com.aspose.slides/FormatScheme#getEffectStyles--)) from the  [FormatScheme](https://reference.aspose.com/slides/java/com.aspose.slides/FormatScheme) class you can change the elements in a theme (even more flexibly than the options in PowerPoint).

This Java code shows you how to change a theme effect by altering parts of elements:

```java
Presentation pres = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    pres.getMasterTheme().getFormatScheme().getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);

    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).setFillType(FillType.Solid);

    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).getSolidFillColor().setColor(Color.GREEN);

    pres.getMasterTheme().getFormatScheme().getEffectStyles().get_Item(2).getEffectFormat().getOuterShadowEffect().setDistance(10f);

    pres.save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

The resulting changes in fill color, fill type, shadow effect, etc:

![todo:image_alt_text](presentation-design_11.png)

