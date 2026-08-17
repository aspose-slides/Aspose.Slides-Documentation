---
title: Apply or Change Slide Layouts in Java
linktitle: Slide Layout
type: docs
weight: 60
url: /java/slide-layout/
keywords:
- slide layout
- content layout
- placeholder
- presentation design
- slide design
- unused layout
- footer visibility
- title slide
- title and content
- section header
- two content
- comparison
- title only
- blank layout
- content with caption
- picture with caption
- title and vertical text
- vertical title and text
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Apply, create, and modify slide layouts in Aspose.Slides for Java, add placeholders, remove unused layouts, and control footer visibility."
---

## **Overview**

A slide layout defines the positions and formatting of placeholders such as titles, text, pictures, charts, and tables. Applying a layout gives slides a consistent structure while allowing each slide to contain its own content.

The most common layouts include:

- **Title Slide**: Contains title and subtitle placeholders.
- **Title and Content**: Contains a title placeholder and a general-purpose content placeholder.
- **Blank**: Contains no content placeholders and is useful when every shape will be positioned manually.

## **Understand Layout Inheritance**

A presentation has three related levels:

1. A [master slide](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/) defines the theme, shared formatting, backgrounds, and common objects.
1. A [layout slide](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutslide/) belongs to a master and defines a particular arrangement of placeholders.
1. A [normal slide](https://reference.aspose.com/slides/java/com.aspose.slides/islide/) uses one layout and stores the content entered for that slide.

A normal slide inherits theme and formatting from its layout, and the layout inherits from its master. A value set directly on a normal slide overrides the inherited value at that level. When a normal slide is created, its placeholder shapes are generated from the selected layout, while the content entered into those placeholders belongs to the normal slide.

Add required placeholders to a layout before creating slides from it. Adding another placeholder to a layout later does not automatically add a corresponding placeholder shape to existing normal slides.

This relationship has two important consequences:

- Changing inherited formatting or existing placeholder geometry on a layout can update every slide that depends on it. Before editing a layout that is already in use, inspect its dependent slides and review the resulting presentation.
- A layout that is still used by a slide cannot be removed. Reassign its dependent slides to another layout first, or remove only unused layouts.

For more information about the top level of this hierarchy, see [Slide Master](/slides/java/slide-master/).

## **Select and Apply a Slide Layout**

Use a layout type when the presentation follows standard PowerPoint layout definitions. Layout names are user-editable and can be localized, so name-based selection is less reliable unless you control the source template.

The following example looks for **Title and Content** on the first master. If that layout is unavailable, it deliberately falls back to **Blank**. The second null check is necessary because a presentation can contain only custom layouts. The selected layout is then applied to the first normal slide through the [ISlide.setLayoutSlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#setLayoutSlide-com.aspose.slides.ILayoutSlide-) method.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterLayoutSlideCollection layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide targetLayout = layoutSlides.getByType(SlideLayoutType.TitleAndObject);

    if (targetLayout == null) {
        targetLayout = layoutSlides.getByType(SlideLayoutType.Blank);
    }

    if (targetLayout == null) {
        throw new IllegalStateException("The first master does not contain a suitable layout slide.");
    }

    presentation.getSlides().get_Item(0).setLayoutSlide(targetLayout);
    presentation.save("output-with-new-layout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Changing a slide's layout does not remove ordinary shapes added directly to the slide. However, placeholder positions, inherited formatting, and the correspondence between existing placeholders and the new layout can change, so inspect the output when switching between substantially different layouts.

## **Add a Layout Slide**

Selection and creation are separate operations. The previous example selects an existing layout; it does not create one. To create a layout, call the [IMasterLayoutSlideCollection.add](https://reference.aspose.com/slides/java/com.aspose.slides/imasterlayoutslidecollection/#add-byte-java.lang.String-) method on the target master's layout collection.

The following example always adds a new **Title and Content** layout named `Report Title and Content`, then adds a normal slide based on it. Layout names must be unique within the collection.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide reportLayout = masterSlide.getLayoutSlides().add(SlideLayoutType.TitleAndObject, "Report Title and Content");
    presentation.getSlides().addEmptySlide(reportLayout);

    presentation.save("output-with-report-layout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Add a layout only when the template genuinely needs another reusable structure. If a suitable layout already exists, select and reuse it instead of creating a duplicate.

## **Add Placeholders to a Layout Slide**

The [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) method provides an [ILayoutPlaceholderManager](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutplaceholdermanager/) for adding placeholder shapes to a layout.

| PowerPoint Placeholder              | `ILayoutPlaceholderManager` Method |
| ----------------------------------- | ---------------------------------- |
| ![Content](content.png)             | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutplaceholdermanager/#addContentPlaceholder-float-float-float-float-) |
| ![Content (Vertical)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalContentPlaceholder-float-float-float-float-) |
| ![Text](text.png)                   | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutplaceholdermanager/#addTextPlaceholder-float-float-float-float-) |
| ![Text (Vertical)](textV.png)       | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalTextPlaceholder-float-float-float-float-) |
| ![Picture](picture.png)             | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutplaceholdermanager/#addPicturePlaceholder-float-float-float-float-) |
| ![Chart](chart.png)                 | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutplaceholdermanager/#addChartPlaceholder-float-float-float-float-) |
| ![Table](table.png)                 | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutplaceholdermanager/#addTablePlaceholder-float-float-float-float-) |
| ![SmartArt](smartart.png)           | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutplaceholdermanager/#addSmartArtPlaceholder-float-float-float-float-) |
| ![Media](media.png)                 | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutplaceholdermanager/#addMediaPlaceholder-float-float-float-float-) |
| ![Online Image](onlineImage.png)    | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutplaceholdermanager/#addOnlineImagePlaceholder-float-float-float-float-) |

The following example verifies that the **Blank** layout exists, adds four placeholders to it, and then creates a normal slide that uses the modified layout. The order is intentional: the placeholders are added before the normal slide is created, so Aspose.Slides can generate the corresponding placeholder shapes on that slide.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    if (blankLayout == null) {
        throw new IllegalStateException("The presentation does not contain a Blank layout slide.");
    }

    ILayoutPlaceholderManager placeholderManager = blankLayout.getPlaceholderManager();
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    presentation.getSlides().addEmptySlide(blankLayout);
    presentation.save("output-with-placeholders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

The result:

![The placeholders on the layout slide](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}

Changing inherited formatting or the geometry of existing layout placeholders can affect dependent slides. A newly added layout placeholder is not backfilled into existing normal slides. Test layout changes on a copy of the presentation and inspect every dependent slide.

{{% /alert %}}

## **Remove Unused Layout Slides**

Use the [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) method to remove layouts that no normal slide references. The method leaves layouts that are still in use intact.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("output-without-unused-layouts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

To remove one specific layout, first use its [hasDependingSlides](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutslide/#hasDependingSlides--) or [getDependingSlides](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutslide/#getDependingSlides--) method. Reassign any dependent slides before calling [ILayoutSlide.remove](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutslide/#remove--). Attempting to remove a used layout raises a [PptxEditException](https://reference.aspose.com/slides/java/com.aspose.slides/pptxeditexception/).

## **Control Footer Visibility on a Layout Slide**

A layout has its own footer, slide-number, and date-time placeholders. Use the [ILayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutslide/#getHeaderFooterManager--) method to control those placeholders for one layout. This is useful when, for example, content layouts should show footers but title layouts should not.

The following example selects a layout safely and makes its footer elements visible:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject);

    if (layoutSlide == null) {
        layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    }

    if (layoutSlide == null) {
        throw new IllegalStateException("The presentation does not contain a suitable layout slide.");
    }

    ILayoutSlideHeaderFooterManager headerFooterManager = layoutSlide.getHeaderFooterManager();
    headerFooterManager.setFooterVisibility(true);
    headerFooterManager.setSlideNumberVisibility(true);
    headerFooterManager.setDateTimeVisibility(true);
    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("output-with-layout-footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Control Footer Visibility on a Master and Its Child Layouts**

To apply consistent footer settings across a master hierarchy, use the [IMasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/#getHeaderFooterManager--) method. The propagation methods of [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslideheaderfootermanager/) operate on the master and its dependent layout slides and normal slides; they do not target just one normal slide.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();
    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);
    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("output-with-master-footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**What Is the Difference Between a Master Slide and a Layout Slide?**

A master slide defines the presentation's theme and shared formatting. A layout slide belongs to a master and defines one reusable arrangement of placeholders. Normal slides use those layouts and store slide-specific content.

**Can I Copy a Layout Slide from One Presentation to Another?**

Yes. Add a copy to the destination collection with the [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/igloballayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) method. When copying between presentations, also verify fonts, themes, images, and other resources used by the source layout.

**What Happens When I Modify a Layout That Is Already in Use?**

Dependent slides inherit the layout changes unless they override the affected formatting or objects locally. Placeholder geometry and inherited styling can therefore change on many slides at once. Use [getDependingSlides](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutslide/#getDependingSlides--) to identify the affected slides before editing the layout.

**What Happens If I Remove a Layout That Is Still in Use?**

Aspose.Slides throws a [PptxEditException](https://reference.aspose.com/slides/java/com.aspose.slides/pptxeditexception/). Reassign the dependent slides first, or use [removeUnusedLayoutSlides](https://reference.aspose.com/slides/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) to remove only unreferenced layouts.
