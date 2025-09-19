---
title: Apply or Change a Slide Layout on Android
linktitle: Slide Layout
type: docs
weight: 60
url: /androidjava/slide-layout/
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
- Android
- Java
- Aspose.Slides
description: "Learn how to manage and customize slide layouts in Aspose.Slides for Android. Explore layout types, placeholder control, footer visibility, and layout manipulation through code examples in Java."
---

## **Overview**

A slide layout defines the arrangement of placeholder boxes and formatting for the content on a slide. It controls which placeholders are available and where they appear. Slide layouts help you design presentations quickly and consistently—whether you're creating something simple or more complex. Some of the most common slide layouts in PowerPoint include:

**Title Slide layout** – Includes two text placeholders: one for the title and one for the subtitle.

**Title and Content layout** – Features a smaller title placeholder at the top and a larger one below for main content (such as text, bullet points, charts, images, and more).

**Blank layout** – Contains no placeholders, giving you full control to design the slide from scratch.

Slide layouts are part of a slide master, which is the top-level slide that defines layout styles for the presentation. You can access and modify layout slides through the slide master—either by their type, name, or unique ID. Alternatively, you can edit a specific layout slide directly within the presentation.

To work with slide layouts in Aspose.Slides for Android, you can use:

- Methods such as [getLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getLayoutSlides--) and [getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--) under the [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) class
- Types like [ILayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutplaceholdermanager/), and [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}

To learn more about working with master slides, check out the [Slide Master](/slides/androidjava/slide-master/) article.

{{% /alert %}}

## **Add Slide Layouts to Presentations**

To customize the appearance and structure of your slides, you may need to add new layout slides to a presentation. Aspose.Slides for Android allows you to check whether a specific layout already exists, add a new one if needed, and use it to insert slides based on that layout.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) class.
1. Access the [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterlayoutslidecollection/).
1. Check whether the desired layout slide already exists in the collection. If not, add the layout slide you need.
1. Add an empty slide based on the new layout slide.
1. Save the presentation.

The following Java code demonstrates how to add a slide layout to a PowerPoint presentation:

```java
// Instantiate the Presentation class that represents a PowerPoint file.
Presentation presentation = new Presentation("Sample.pptx");
try {
    // Go through the layout slide types to select a layout slide.
    IMasterLayoutSlideCollection layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide layoutSlide = null;
    if (layoutSlides.getByType(SlideLayoutType.TitleAndObject) != null)
        layoutSlide = layoutSlides.getByType(SlideLayoutType.TitleAndObject);
    else
        layoutSlide = layoutSlides.getByType(SlideLayoutType.Title);

    if (layoutSlide == null) {
        // A situation where the presentation doesn't contain all layout types.
        // The presentation file contains only Blank and Custom layout types.
        // However, layout slides with custom types may have recognizable names,
        // such as "Title", "Title and Content", etc., which can be used for layout slide selection.
        // You can also rely on a set of placeholder shape types.
        // For example, a Title slide should have only the Title placeholder type, and so on.
        for (ILayoutSlide titleAndObjectLayoutSlide : layoutSlides) {
            if (titleAndObjectLayoutSlide.getName().equals("Title and Object")) {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }

        if (layoutSlide == null) {
            for (ILayoutSlide titleLayoutSlide : layoutSlides) {
                if (titleLayoutSlide.getName().equals("Title")) {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }

            if (layoutSlide == null) {
                layoutSlide = layoutSlides.getByType(SlideLayoutType.Blank);
                if (layoutSlide == null) {
                    layoutSlide = layoutSlides.add(SlideLayoutType.TitleAndObject, "Title and Object");
                }
            }
        }
    }

    // Add an empty slide using the added layout slide.
    presentation.getSlides().insertEmptySlide(0, layoutSlide);

    // Save the presentation to disk.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Remove Unused Layout Slides**

Aspose.Slides provides the [removeUnusedLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) method from the [Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/) class to allow you to delete unwanted and unused layout slides.

The following Java code shows how to remove a layout slide from a PowerPoint presentation:

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Add Placeholders To Slide Layouts**

Aspose.Slides provides the [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) method, which allows you to add new placeholders to a layout slide.

This manager contains methods for the following placeholder types:

| PowerPoint Placeholder              | [ILayoutPlaceholderManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutplaceholdermanager/) Method |
| ----------------------------------- | ------------------------------------------------------------ |
| ![Content](content.png)             | addContentPlaceholder(float x, float y, float width, float height) |
| ![Content (Vertical)](contentV.png) | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Text](text.png)                   | addTextPlaceholder(float x, float y, float width, float height) |
| ![Text (Vertical)](textV.png)       | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Picture](picture.png)             | addPicturePlaceholder(float x, float y, float width, float height) |
| ![Chart](chart.png)                 | addChartPlaceholder(float x, float y, float width, float height) |
| ![Table](table.png)                 | addTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png)           | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Media](media.png)                 | addMediaPlaceholder(float x, float y, float width, float height) |
| ![Online Image](onlineimage.png)    | addOnlineImagePlaceholder(float x, float y, float width, float height) |

The following Java code demonstrates how to add new placeholder shapes to the Blank layout slide:

```java
Presentation presentation = new Presentation();
try {
    // Get the Blank layout slide.
    ILayoutSlide layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    // Get the placeholder manager of the layout slide.
    ILayoutPlaceholderManager placeholderManager = layout.getPlaceholderManager();

    // Add different placeholders to the Blank layout slide.
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    // Add a new slide with the Blank layout.
    ISlide newSlide = presentation.getSlides().addEmptySlide(layout);

    presentation.save("Placeholders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

The result:

![The placeholders on the layout slide](add_placeholders.png)

## **Set Footer Visibility for a Layout Slide**

In PowerPoint presentations, footer elements like date, slide number, and custom text can be shown or hidden depending on the slide layout. Aspose.Slides for Android allows you to control the visibility of these footer placeholders. This is useful when you want certain layouts to display footer information while others remain clean and minimal.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) class.
1. Get a layout slide reference by its index.
1. Set the slide footer placeholder to visible.
1. Set the slide number placeholder to visible.
1. Set the date-time placeholder to visible.
1. Save the presentation.

The following Java code shows how to set the visibility of a slide footer and perform related tasks:

```java
Presentation presentation = new Presentation("Presentation.ppt");
try {
    ILayoutSlideHeaderFooterManager headerFooterManager = presentation.getLayoutSlides().get_Item(0).getHeaderFooterManager();

    if (!headerFooterManager.isFooterVisible()) {
        headerFooterManager.setFooterVisibility(true);
    }

    if (!headerFooterManager.isSlideNumberVisible()) {
        headerFooterManager.setSlideNumberVisibility(true);
    }

    if (!headerFooterManager.isDateTimeVisible()) {
        headerFooterManager.setDateTimeVisibility(true);
    }

    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("Presentation.ppt", SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

## **Set Child Footer Visibility for a Slide**

​In PowerPoint presentations, footer elements such as date, slide number, and custom text can be controlled at the master slide level to ensure consistency across all layout slides. Aspose.Slides for Android enables you to set the visibility and content of these footer placeholders on the master slide and propagate these settings to all child layout slides. This approach ensures uniform footer information throughout your presentation.​

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) class.
1. Get a reference to the master slide by its index.
1. Set the master’s and all child footer placeholders to visible.
1. Set the master’s and all child slide number placeholders to visible.
1. Set the master’s and all child date-time placeholders to visible.
1. Save the presentation.

The following Java code demonstrates this operation:

```java
Presentation presentation = new Presentation("Presentation.ppt");
try {
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();

    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQs**

**What’s the difference between a master slide and a layout slide?**

A master slide defines the overall theme and default formatting, while layout slides define specific arrangements of placeholders for different types of content.

**Can I copy a layout slide from one presentation to another?**

Yes, you can clone a layout slide from one presentation’s layout slide collection, accessible via the [getLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getLayoutSlides--) method, and insert it into another presentation using the `addClone` method.

**What happens if I delete a layout slide that's still used by a slide?**

If you try to delete a layout slide that is still referenced by at least one slide in the presentation, Aspose.Slides will throw a [PptxEditException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxeditexception/). To avoid this, use [removeUnusedLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) which safely removes only the layout slides that are not in use.
