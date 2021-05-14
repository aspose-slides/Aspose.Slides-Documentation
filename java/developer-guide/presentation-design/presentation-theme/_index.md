---
title: Presentation Theme
type: docs
weight: 10
url: /java/presentation-theme/
keywords: "PowerPoint PPT presentation design"
description: "Create PowerPoint design, PPT presentation design with Aspose.Slides API."
---

## **About Presentation Design**

In the **presentation design**, there are two types of elements:

- Data elements. Used to add an informational content into the presentation: text, titles, lists, charts, tables, videos, etc.
- Design elements. Used to create a visual appearance of all presentation elements - the presentation design.

**Design elements** are the following:

- Data elements layout. It depends on the type of the element. Elements of non-placeholder type have a fixed position. While elements of placeholder type (or a combination of elements with placeholder type, like: header and body) have a flexible position, which can be changed. They can be placed on different Slide Layouts, Slide Masters, that are applied to a slide.
- Template elements. Which are only dedicated to quickly create the style of presentation. 
- Colors. Used to paint elements and their parts. Usually, elements are designed with many colors, having one fill color and border color, etc.
- Fonts. Used for the data elements, containing text.
- Effects. Which are applied to various elements: shadow, glow, reflection, 3D-effects, ect.
- Background. Fills the background of the slide or presentation, and can be used on Slide Master, Slide Layout or a certain slide. The background can be: solid, gradient, texture, etc.

All the design elements of presentation create the **presentation design**. The major properties of design elements are defined by the **presentation theme**. When you choose a certain presentation theme, you actually choose a set of visual elements and their properties, to build the presentation design.


In PowerPoint it is possible to change the whole presentation theme in one click:

![todo:image_alt_text](presentation-design_1.png)



It is also available to change a certain part of the presentation theme (colors, fonts, effects, background styles):

![todo:image_alt_text](presentation-design_2.png)

Through "*Design - ->View"* menu user can change a set of stylistic properties of visual elements. Apart from that, it's possible to add new elements into the presentation (e.g. into Slide Master), based on a certain template. However, newly added elements will be removed in case the presentation theme will be changed.

For example, if you choose "Organic" template in PowerPoint, the following shape will be added into Slide Master:

![todo:image_alt_text](presentation-design_3.png)

After changing the presentation theme on "*Ion*", the abovementioned element will be removed. While that, a new element of "*Ion*" presentation theme will be added on the slide (see on the image). As you can see, this element is binded to a placeholder, which will show the slide number (in case, its switched on in "*Insert --> Header & Footer --> Slide Number"*):

![todo:image_alt_text](presentation-design_4.png)

However, if you will change the presentation theme on "*Office Theme*", the placeholder will be removed from the slide. This happens because presentation theme actually includes a **presentation template** as well. So, while we change the presentation theme, this action may also cause presentation template to be changed (e.g. add elements to Slide Master, change placeholders positions).


## **Change Theme Colors**
When a certain theme is chosen for presentation, the colors to apply on presentation are calculated based on the presentation theme. Each presentation theme has an ordered set of colors, where every color is destinated to different elements or parts of the slide. The actual value of the color is not used in theme color set. Instead, the color order number and color name are used. Colors for presentation elements are calculated based on default theme settings or chosen according to the pointer referring to a color from the theme colors set.

In PowerPoint theme colors set looks this way on a color picker:


![todo:image_alt_text](presentation-design_5.png)


It is a set of theme colors, containing 10 main colors of the theme. A popup window shows the name of one color from this theme. 

Here is the same theme color set, with all its color names, available in "*Design -> Variants -> Customize Colors -> “Theme Colors”* PowerPoint menu:

![todo:image_alt_text](presentation-design_6.png)

Here is possible to add new colors not defined in presentation theme, or change existing ones. For example, "Hyperlink” and ”Followed Hyperlink” colors were added manually. 
## **Change Theme Colors with Aspose.Slides**
In [**Aspose.Slides**](https://products.aspose.com/slides/java) to choose the appropriate color from the theme color set and set it to the element, use [**IFillFormat.getSolidFillColor.getSchemeColor**](https://apireference.aspose.com/slides/java/com.aspose.slides/IColorFormat#getSchemeColor--) method:

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

In the example above, we have set a reference on *Accent4* color, taken from the **scheme color** (theme colors). If we want to know the real value of this color, it is necessary to calculate its effective value - the value of the element color, which user sees after all the styles applied to this element:

```java
IFillFormatEffectiveData fillEffective = shape.getFillFormat().getEffective();

Color effectiveColor = fillEffective.getSolidFillColor();

System.out.println(String.format("Color [A=%d, R=%d, G=%d, B=%d]", 
        effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
``` 

We can check that color matches the one defined as *Accent4* for the presentation theme:

```java
Color themeAccent4 = pres.getMasterTheme().getColorScheme().getAccent4().getColor();

System.out.println(String.format("Color [A=%d, R=%d, G=%d, B=%d] - from theme",
        themeAccent4.getAlpha(), themeAccent4.getRed(), themeAccent4.getGreen(), themeAccent4.getBlue()));
``` 

Lets us create one more element and assign it the same *Accent4* color from the scheme. Then we will change this color in the scheme:

```java
IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.getFillFormat().setFillType(FillType.Solid);

otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
``` 

The color will change on both elements after we have changed it in the color theme. 

## **Change Theme Fonts**
The presentation theme defines two main fonts, which will be used for presentation Heading and Body. It is possible to set Latin, Asian or Complex option for each presentation theme font. In PowerPoint it's done the following way:

![todo:image_alt_text](presentation-design_7.png)


## **Change Theme Fonts with Aspose.Slides**
In [**Aspose.Slides**](https://products.aspose.com/slides/java) (the same as in PowerPoint) to choose the font from the **font scheme**, the special identifier is used:

- "**+mn-lt**": Body Font Latin (Minor Latin Font)
- "**+mj-lt**": Heading Font Latin (Major Latin Font)
- "**+mn-ea**": Body Font East Asian (Minor East Asian Font)
- "**+mj-ea**": Body Font East Asian (Minor East Asian Font)

Let us create an element with the text, and assign the Latin font from the font scheme to it: 

```java
IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Theme text format");

paragraph.getPortions().add(portion);

shape.getTextFrame().getParagraphs().add(paragraph);

portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));
``` 

Now lets check that the same font is set for Body Latin:

```java
System.out.println("Portion Body Latin font is: " + portion.getPortionFormat().getEffective().getLatinFont().getFontName());

System.out.println("Theme Body Latin font is: " + pres.getMasterTheme().getFontScheme().getMinor().getLatinFont());
``` 

It is possible to change the presentation theme font, which will be updated for all presentation text accordingly:

```java
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
``` 

{{% alert color="primary" title="See also" %}} 
- [Working with Presentation Fonts](/slides/java/powerpoint-fonts/)
{{% /alert %}}

## **Change Theme Background Style**
Presentation theme may also contain a set of background styles, which can be changed via "*Design -> Variants -> Background Styles*" menu:

![todo:image_alt_text](presentation-design_8.png)

## **Change Theme Background Style with Aspose.Slides**
In [**Aspose.Slides**](https://products.aspose.com/slides/java) its possible to access Background Style with [**IPresentation.getMasterTheme.getFormatScheme.getBackgroundFillStyles**](https://apireference.aspose.com/slides/java/com.aspose.slides/IFormatScheme#getBackgroundFillStyles--) method. There is a difference in the way Background Style is represented in presentation with Aspose.Slides comparing to PowerPoint. The logic difference affects the slide effects too. We will consider the Background Style logic difference below.

On the images above you can see, that to design the Background Style in PowerPoint, there are 12 predefined backgrounds available. However, if we upload the presentation, saved in PowerPoint through Aspose.Slides, then execute the following code - we will see only 3 predefined backgrounds in the resulting presentation:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    int numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();

    System.out.println("Number of background fill styles for theme is " + numberOfBackgroundFills);
} finally {
    if (pres != null) pres.dispose();
}
``` 

The reason is that,12 predefined backgrounds are used to design Background Style only, but they are not actually saved into the resulting presentation. However, its possible to add additional backgrounds to [IPresentation.getMasterTheme.getFormatScheme.getBackgroundFillStyles](https://apireference.aspose.com/slides/java/com.aspose.slides/IFormatScheme#getBackgroundFillStyles--) method.

To define which background should be used for presentation, set the needed presentation index (**Note**: the index starts from 1, not from 0. 0 is used to define "*no fill*" value):

```java
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
``` 

{{% alert color="primary" title="See also" %}} 
- [Working with Presentation Background](/slides/java/presentation-background/)
{{% /alert %}}

## **Change Theme Effects with Aspose.Slides**

An important difference in [**Aspose.Slides**](https://products.aspose.com/slides/java) to PowerPoint is in grouping theme properties into a [**FormatScheme**](https://apireference.aspose.com/slides/java/com.aspose.slides/FormatScheme) type. In PowerPoint, *Theme Effect* and *Backgrounds* are represented as two separate lists in "*Design --> Variant"* menu. In Aspose.Slides they are both encapsulated into [FormatScheme](https://apireference.aspose.com/slides/java/com.aspose.slides/FormatScheme) type. [FormatScheme](https://apireference.aspose.com/slides/java/com.aspose.slides/FormatScheme) type is the core type to define the presentation theme properties, it is a "style matrix" containing style arrays of types:

- fill styles
- line styles
- effect styles
- background fill styles

PowerPoint theme usually contains 3 values for each style array, which are combined into "*Subtle*", "*Moderate*" and "*Intense*” effects. Let's demonstrate it on the example of formatting shapes. The themes of individual shapes can be edited with "*PowerPoint's Format -> Shape Styles*" menu:

![todo:image_alt_text](presentation-design_9.png)

For example, 3 shapes will look this way after we apply 3 different effects on them:

![todo:image_alt_text](presentation-design_10.png)

In [**Aspose.Slides**](https://products.aspose.com/slides/java) there are no "*Subtle*", "*Moderate*" and "*Intense*” effects. Instead, you can operate the [FormatScheme](https://apireference.aspose.com/slides/java/com.aspose.slides/FormatScheme) style matrix, having 3 elements in each array (FillStyles, LineStyles, EffectStyles) to change the outlook of presentation elements. There is also the [IPresentation.getMasterTheme.getFormatScheme.getBackgroundFillStyles](https://apireference.aspose.com/slides/java/com.aspose.slides/IFormatScheme#getBackgroundFillStyles--) method available, but it can only change the background fill style.

So, the effects you can use in PowerPoint are strictly limited. While, in Aspose.Slides it is possible to change them in a flexible way by changing their composite parts. In the following example, we will change the outlook of the abovementioned elements with Aspose.Slides:

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

As you can see, we have changed the fill color, the fill type, shadow effect, etc of the elements:

![todo:image_alt_text](presentation-design_11.png)
