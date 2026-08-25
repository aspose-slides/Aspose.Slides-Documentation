---
title: Manage Presentation Themes in JavaScript
linktitle: Presentation Theme
type: docs
weight: 10
url: /nodejs-java/presentation-theme/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Master presentation themes in JavaScript with Aspose.Slides for Node.js to create, customize and convert PowerPoint files with consistent branding."
---

## **Introduction**

A presentation theme defines a coordinated set of colors, fonts, background styles, fills, lines, and effects. Theme-aware objects refer to these shared definitions instead of storing every visual property as a fixed value, so a theme change can update many objects at once.

In Aspose.Slides, the presentation-level theme is available through [Presentation.getMasterTheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getmastertheme/). A presentation can also contain theme overrides at lower levels. A master can override the presentation theme through [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterthememanager/), while a layout or an individual slide can override its inherited theme through [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseoverridethememanager/). In practice, the effective theme for a slide is resolved through this inheritance chain: presentation theme, master override, layout override, and slide override.

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

The sections below show the most common theme workflows: inspect a theme, change colors and fonts, copy or apply a theme, update background and effect styles, and read effective values after inheritance and overrides have been resolved.

## **Inspect a Theme**

The [MasterTheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mastertheme/) object exposes the theme's color scheme, font scheme, and format scheme through [MasterTheme.getColorScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mastertheme/), and [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mastertheme/). Inspecting these collections before changing them is especially useful when a presentation comes from an external source because the number and content of style entries can vary.

The following example reads the main theme properties and reports how many background, fill, line, and effect styles are stored in the theme:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const theme = presentation.getMasterTheme();
    console.log("Theme name: " + theme.getName());
    console.log("Accent 1: " + theme.getColorScheme().getAccent1().getColor());
    console.log("Major Latin font: " + theme.getFontScheme().getMajor().getLatinFont().getFontName());
    console.log("Minor Latin font: " + theme.getFontScheme().getMinor().getLatinFont().getFontName());
    console.log("Background fill styles: " + theme.getFormatScheme().getBackgroundFillStyles().size());
    console.log("Fill styles: " + theme.getFormatScheme().getFillStyles().size());
    console.log("Line styles: " + theme.getFormatScheme().getLineStyles().size());
    console.log("Effect styles: " + theme.getFormatScheme().getEffectStyles().size());
} finally {
    presentation.dispose();
}
```

If a file uses multiple masters, do not assume that every slide has the same effective theme. Inspect the master associated with the slide, and use the effective-theme workflow shown later in this article when layout or slide overrides may be present.

## **Change Theme Colors**

Theme-aware fills, lines, and text can refer to a logical color from the [SchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/schemecolor/) enumeration. When you change the corresponding entry in the [ColorScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorscheme/), all objects that still reference that theme color are resolved against the new value. Objects that use a direct RGB color are not changed by a theme-color update.

The following end-to-end example creates a shape that uses `Accent4`, changes the theme's `Accent4` color to red, saves the presentation, reopens it, and prints the effective fill color:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    presentation.getMasterTheme().getColorScheme().getAccent4().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    presentation.save("theme-color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const savedPresentation = new aspose.slides.Presentation("theme-color.pptx");
try {
    const savedSlide = savedPresentation.getSlides().get_Item(0);
    const savedShape = savedSlide.getShapes().get_Item(0);
    const effectiveFill = savedShape.getFillFormat().getEffective();
    console.log("Effective fill color: " + effectiveFill.getSolidFillColor());
} finally {
    savedPresentation.dispose();
}
```

Because the rectangle remains linked to `Accent4`, its visible color becomes red after the theme is changed. If you replace the scheme color with a direct color on the shape, later changes to `Accent4` will no longer affect that fill.

### **Use Colors from the Additional Palette**

PowerPoint derives lighter and darker variants from a theme color by applying color transformations. Aspose.Slides exposes these transformations through the [ColorTransformOperation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colortransformoperation/) enumeration.

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - Main theme colors.

**2** - Lighter and darker variants produced from the main theme colors.

The following example creates six rectangles based on `Accent4`, applies luminance transformations to five of them, and saves the result:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);

    const shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.2));
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.8));

    const shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.4));
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.6));

    const shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.6));
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.AddLuminance, java.newFloat(0.4));

    const shape5 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.75));

    const shape6 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(aspose.slides.SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(aspose.slides.ColorTransformOperation.MultiplyLuminance, java.newFloat(0.5));

    presentation.save("theme-color-palette.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

These variants remain based on the theme color. If `Accent4` changes later, the transformed colors are recalculated from the new `Accent4` value.

### **Map `SchemeColor` Values to `ColorScheme` Slots**

The [SchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/schemecolor/) enumeration uses `Text1`, `Background1`, `Text2`, and `Background2`, while the [ColorScheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorscheme/) exposes the same theme slots as `Dark1`, `Light1`, `Dark2`, and `Light2`. The mapping is fixed:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

These are alternate names for the same theme slots; they are not values that are dynamically converted from one form to another.

## **Change Theme Fonts**

A theme font scheme contains a major font set for headings and a minor font set for body text. The [FontScheme.getMajor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontscheme/) and [FontScheme.getMinor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontscheme/) methods expose those sets.

PowerPoint-compatible theme font identifiers can be used in text formatting:

* `+mn-lt` - Body Font Latin (Minor Latin Font)
* `+mj-lt` - Heading Font Latin (Major Latin Font)
* `+mn-ea` - Body Font East Asian (Minor East Asian Font)
* `+mj-ea` - Heading Font East Asian (Major East Asian Font)

The following example creates one heading that uses the major Latin theme font and one body line that uses the minor Latin theme font. It then changes the theme fonts and saves the result:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const heading = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 500, 60);
    heading.getTextFrame().setText("Theme heading");
    heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new aspose.slides.FontData("+mj-lt"));

    const body = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 120, 500, 60);
    body.getTextFrame().setText("Theme body text");
    body.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new aspose.slides.FontData("+mn-lt"));

    presentation.getMasterTheme().getFontScheme().getMajor().setLatinFont(new aspose.slides.FontData("Aptos Display"));
    presentation.getMasterTheme().getFontScheme().getMinor().setLatinFont(new aspose.slides.FontData("Arial"));
    presentation.save("theme-fonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

The heading follows the major font and the body text follows the minor font. Text that has an explicit font name instead of a theme identifier will not automatically switch when the theme font scheme changes.

The major and minor font collections can also contain font mappings for individual writing systems, such as Cyrillic, Arabic, Japanese, Georgian, and Thaana. To inspect, add, replace, or remove these mappings, see [Script-Specific Theme Fonts](/slides/nodejs-java/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}

For more information about presentation fonts, see [PowerPoint Fonts](/slides/nodejs-java/powerpoint-fonts/).

{{% /alert %}}

## **Copy or Apply a Theme**

There are two common workflows, and they solve different problems.

### **Preserve a Source Theme When Moving Slides**

If you want to move a slide to another presentation and preserve its original design, clone the source master into the target presentation with [MasterSlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/), then clone the slide with [SlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/) and the cloned master. This carries the master, its layouts, and the associated theme together.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceSlide = source.getSlides().get_Item(0);
        const clonedMaster = target.getMasters().addClone(sourceSlide.getLayoutSlide().getMasterSlide());
        target.getSlides().addClone(sourceSlide, clonedMaster, true);
        target.save("theme-preserved.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

This is the preferred workflow when the source slide must look the same in the destination. Simply cloning content onto an unrelated destination master can change theme-driven colors, fonts, backgrounds, and effects.

### **Apply Theme Values to an Existing Slide**

If the target slide must stay on its current master and layout, initialize a slide-level override from the source theme. The [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/overridetheme/), and [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/overridetheme/) methods copy the three main theme components into the override.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceTheme = source.getMasterTheme();
        const targetSlide = target.getSlides().get_Item(0);
        const overrideTheme = targetSlide.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(sourceTheme.getColorScheme());
        overrideTheme.initFontSchemeFrom(sourceTheme.getFontScheme());
        overrideTheme.initFormatSchemeFrom(sourceTheme.getFormatScheme());
        target.save("theme-applied-to-slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

This changes the theme used by that slide without changing the theme inherited by other slides. To remove the local override and return to inherited values, call [OverrideTheme.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/overridetheme/).

### **Apply a Theme Override to a Layout**

A layout-level override applies to slides that use that layout, unless a particular slide has its own override. The same initialization methods can be used through the [LayoutSlideThemeManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslidethememanager/):

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const source = new aspose.slides.Presentation("source-theme.pptx");
try {
    const target = new aspose.slides.Presentation("target.pptx");
    try {
        const sourceTheme = source.getMasterTheme();
        const targetSlide = target.getSlides().get_Item(0);
        const overrideTheme = targetSlide.getLayoutSlide().getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(sourceTheme.getColorScheme());
        overrideTheme.initFontSchemeFrom(sourceTheme.getFontScheme());
        overrideTheme.initFormatSchemeFrom(sourceTheme.getFormatScheme());
        target.save("theme-applied-to-layout.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

Use a master or presentation-level theme when many layouts and slides should share the same base design, a layout override when one layout family needs different styling, and a slide override only for true exceptions. Excessive slide-level overrides make later global theme changes harder to predict.

## **Update Theme Background Styles**

The theme's background fills are stored in [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/formatscheme/). PowerPoint can present more background choices in its UI than the number of fill definitions physically stored in this collection because the UI can combine theme fills with theme colors and other style references.

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

Before using a background style, inspect the stored collection and the current [Background.getStyleIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/background/). A style index of `0` means no themed fill; positive values are theme background-style references. This is different from indexing the JavaScript collection directly, where index `0` means the first stored item. Do not assume that every presentation contains the same number of background fill styles.

The following example reports the available background fill count, assigns a themed background reference to the first master, and saves the presentation:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const backgroundStyles = presentation.getMasterTheme().getFormatScheme().getBackgroundFillStyles();
    console.log("Background fill styles: " + backgroundStyles.size());
    if (backgroundStyles.size() === 0) {
        throw new Error("The presentation theme does not contain background fill styles.");
    }

    const masterSlide = presentation.getMasters().get_Item(0);
    masterSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.Themed));
    masterSlide.getBackground().setStyleIndex(1);
    presentation.save("theme-background.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

The visible result depends on the theme entry referenced by the master and on any background overrides at the layout or slide level. If a slide uses its own background, changing only the master background may not change that slide. Use [Background.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/background/) when you need to know the final background after inheritance has been applied.

{{% alert color="warning" title="Warning" %}}

Do not treat the style index as a zero-based collection index. Also avoid hard-coding a style number from one file and assuming it has the same appearance in another file; theme style definitions are presentation-specific.

{{% /alert %}}

{{% alert color="info" title="Tip" %}}

For direct background formatting and background inheritance, see [Presentation Background](/slides/nodejs-java/presentation-background/).

{{% /alert %}}

## **Update Theme Effects**

A theme format scheme contains separate fill, line, and effect style collections exposed through [FormatScheme.getFillStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/formatscheme/), and [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/formatscheme/). Typical Office themes often contain three principal style entries that correspond visually to subtle, moderate, and intense formatting, but code should inspect each collection instead of assuming a fixed count.

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

When you access these collections in JavaScript, the collection index is zero-based: index `0` is the first stored style and index `2` is the third. A shape's style-reference indexes are a separate concept, exposed through [ShapeStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapestyle/). Modifying a theme style affects shapes that reference that theme style; shapes with direct formatting may remain unchanged.

The following example checks that the required style entries exist, changes the first line style, changes the third fill style, enables an outer shadow in the third effect style, and saves the result:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("Subtle_Moderate_Intense.pptx");
try {
    const formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new Error("The theme does not contain the style entries required by this example.");
    }

    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    formatScheme.getFillStyles().get_Item(2).setFillType(java.newByte(aspose.slides.FillType.Solid));
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 34, 139, 34));
    const effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10);
    presentation.save("theme-effects.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

For shapes that reference these slots, the first theme line style becomes red, the third theme fill style becomes solid forest green, and the third effect style gains an outer shadow with a distance of 10 points. The exact visual result still depends on which style slots each shape references and whether direct formatting overrides the theme.

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **Read Effective Theme Values**

Raw theme objects tell you what is defined at a particular level. Effective values tell you what a slide or shape actually uses after inheritance and local overrides are resolved. For a slide, call [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseoverridethememanager/). For a background, use [Background.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/background/), and for a fill, use [FillFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/).

The following example reads the effective theme, background, and first shape fill from a slide:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const effectiveTheme = slide.getThemeManager().createThemeEffective();
    const effectiveBackground = slide.getBackground().getEffective();
    console.log("Effective major Latin font: " + effectiveTheme.getFontScheme().getMajor().getLatinFont().getFontName());
    console.log("Effective minor Latin font: " + effectiveTheme.getFontScheme().getMinor().getLatinFont().getFontName());
    console.log("Effective background fill type: " + effectiveBackground.getFillFormat().getFillType());
    if (slide.getShapes().size() > 0) {
        const effectiveFill = slide.getShapes().get_Item(0).getFillFormat().getEffective();
        console.log("First shape effective fill type: " + effectiveFill.getFillType());
        if (effectiveFill.getFillType() === aspose.slides.FillType.Solid) {
            console.log("First shape effective fill color: " + effectiveFill.getSolidFillColor());
        }
    }
} finally {
    presentation.dispose();
}
```

Use effective data for rendering diagnostics, validation, and comparisons. If you inspect only [Presentation.getMasterTheme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getmastertheme/), you can miss a master, layout, slide, or shape override that changes the final appearance.

## **FAQ**

**Can I apply a theme to a single slide without changing the master?**

Yes. Use the slide's [SlideThemeManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidethememanager/) and initialize its override theme. The change remains local to that slide; other slides continue to inherit their existing themes.

**What is the safest way to carry a theme from one presentation to another?**

When moving a slide and preserving its source appearance, clone the source master into the destination and clone the slide with that master using [MasterSlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/) and [SlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/). This keeps the master, layouts, and theme together.

**How can I see the effective values after inheritance and overrides?**

Use [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseoverridethememanager/) for a slide or layout theme and the corresponding effective-data methods for format objects such as [Background.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/background/) and [FillFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/). These APIs return the resolved values after inheritance and overrides are applied.
