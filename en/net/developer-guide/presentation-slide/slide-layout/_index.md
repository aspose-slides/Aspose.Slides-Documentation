---
title: Apply or Change a Slide Layout in C#
linktitle: Slide Layout
type: docs
weight: 60
url: /net/slide-layout/
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
- C#
- Csharp
- .NET
- Aspose.Slides
description: "Learn how to manage and customize slide layouts in Aspose.Slides for .NET. Explore layout types, placeholder control, footer visibility, and layout manipulation through code examples in C#."
---

## **Overview**

A slide layout defines the arrangement of placeholder boxes and formatting for the content on a slide. It controls which placeholders are available and where they appear. Slide layouts help you design presentations quickly and consistently—whether you're creating something simple or more complex. Some of the most common slide layouts in PowerPoint include:

**Title Slide layout** – Includes two text placeholders: one for the title and one for the subtitle.

**Title and Content layout** – Features a smaller title placeholder at the top and a larger one below for main content (such as text, bullet points, charts, images, and more).

**Blank layout** – Contains no placeholders, giving you full control to design the slide from scratch.

Slide layouts are part of a slide master, which is the top-level slide that defines layout styles for the presentation. You can access and modify layout slides through the slide master—either by their type, name, or unique ID. Alternatively, you can edit a specific layout slide directly within the presentation.

To work with slide layouts in Aspose.Slides for .NET, use properties such as:

- [LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/presentation/layoutslides/) and [Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) under the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class
- Types like [ILayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/net/aspose.slides/ilayoutplaceholdermanager/), and [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/net/aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}

To learn more about working with master slides, check out the [Slide Master](/slides/net/slide-master/) article.

{{% /alert %}}

## **Add a Slide Layout to a Presentation**

To customize the appearance and structure of your slides, you may need to add new layout slides to a presentation. Aspose.Slides for .NET allows you to check whether a specific layout already exists, add a new one if needed, and use it to insert slides based on that layout.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class.
1. Access the [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterlayoutslidecollection/).
1. Check whether the desired layout slide already exists in the collection. If not, add the layout slide you need.
1. Add an empty slide based on the new layout slide.
1. Save the presentation.

The following C# code demonstrates how to add a slide layout to a PowerPoint presentation:

```cs
// Instantiate the Presentation class that represents a PowerPoint file.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    // Go through the layout slide types to select a layout slide.
    IMasterLayoutSlideCollection layoutSlides = presentation.Masters[0].LayoutSlides;
    ILayoutSlide layoutSlide = layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? layoutSlides.GetByType(SlideLayoutType.Title);

    if (layoutSlide == null)
    {
        // A situation where the presentation doesn't contain all layout types.
        // The presentation file contains only Blank and Custom layout types.
        // However, layout slides with custom types may have recognizable names,
        // such as "Title", "Title and Content", etc., which can be used for layout slide selection.
        // You can also rely on a set of placeholder shape types.
        // For example, a Title slide should have only the Title placeholder type, and so on.
        foreach (ILayoutSlide titleAndObjectLayoutSlide in layoutSlides)
        {
            if (titleAndObjectLayoutSlide.Name == "Title and Object")
            {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }

        if (layoutSlide == null)
        {
            foreach (ILayoutSlide titleLayoutSlide in layoutSlides)
            {
                if (titleLayoutSlide.Name == "Title")
                {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }

            if (layoutSlide == null)
            {
                layoutSlide = layoutSlides.GetByType(SlideLayoutType.Blank);
                if (layoutSlide == null)
                {
                    layoutSlide = layoutSlides.Add(SlideLayoutType.TitleAndObject, "Title and Object");
                }
            }
        }
    }

    // Add an empty slide using the added layout slide.
    presentation.Slides.InsertEmptySlide(0, layoutSlide);

    // Save the presentation to disk.  
    presentation.Save("AddLayoutSlides.pptx", SaveFormat.Pptx);
}
```

## **Remove Unused Layout Slides**

Aspose.Slides provides the [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) method from the [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) class to allow you to delete unwanted and unused layout slides.

The following C# code shows how to remove a layout slide from a PowerPoint presentation:

```cs
using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedLayoutSlides(presentation);
    
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **Add a Placeholder To a Slide Layout**

Aspose.Slides provides the [ILayoutSlide.PlaceholderManager](https://reference.aspose.com/slides/net/aspose.slides/ilayoutslide/placeholdermanager/) property, which allows you to add new placeholders to a layout slide.

This manager contains methods for the following placeholder types:

| PowerPoint Placeholder              | [ILayoutPlaceholderManager](https://reference.aspose.com/slides/net/aspose.slides/ilayoutplaceholdermanager/) Method |
| ----------------------------------- | ------------------------------------------------------------ |
| ![Content](content.png)             | AddContentPlaceholder(float x, float y, float width, float height); |
| ![Content (Vertical)](contentV.png) | AddVerticalContentPlaceholder(float x, float y, float width, float height); |
| ![Text](text.png)                   | AddTextPlaceholder(float x, float y, float width, float height); |
| ![Text (Vertical)](textV.png)       | AddVerticalTextPlaceholder(float x, float y, float width, float height); |
| ![Picture](picture.png)             | AddPicturePlaceholder(float x, float y, float width, float height); |
| ![Chart](chart.png)                 | AddChartPlaceholder(float x, float y, float width, float height); |
| ![Table](table.png)                 | AddTablePlaceholder(float x, float y, float width, float height); |
| ![SmartArt](smartart.png)           | AddSmartArtPlaceholder(float x, float y, float width, float height); |
| ![Media](media.png)                 | AddMediaPlaceholder(float x, float y, float width, float height); |
| ![Online Image](onlineimage.png)    | AddOnlineImagePlaceholder(float x, float y, float width, float height); |

This C# code demonstrates how to add new placeholder shapes to the Blank layout slide:

```cs
using (var presentation = new Presentation())
{
    // Get the Blank layout slide.
    ILayoutSlide layout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

    // Get the placeholder manager of the layout slide.
    ILayoutPlaceholderManager placeholderManager = layout.PlaceholderManager;

    // Add different placeholders to the Blank layout slide.
    placeholderManager.AddContentPlaceholder(20, 20, 310, 270);
    placeholderManager.AddVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.AddChartPlaceholder(20, 310, 310, 180);
    placeholderManager.AddTablePlaceholder(350, 310, 350, 180);

    // Add a new slide with the Blank layout.
    ISlide newSlide = presentation.Slides.AddEmptySlide(layout);

    presentation.Save("Placeholders.pptx", SaveFormat.Pptx);
}
```

The result:

![The placeholders on the layout slide](add_placeholders.png)

## **Set Footer Visibility Inside a Layout Slide**

In PowerPoint presentations, footer elements like date, slide number, and custom text can be shown or hidden depending on the slide layout. Aspose.Slides for .NET allows you to control the visibility of these footer placeholders. This is useful when you want certain layouts to display footer information while others remain clean and minimal.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class.
1. Get a layout slide reference by its index.
1. Set the slide footer placeholder to visible.
1. Set the slide number placeholder to visible.
1. Set the date-time placeholder to visible.
1. Save the presentation.

The following C# code shows how to set the visibility of a slide footer and perform related tasks:

```cs
using (Presentation presentation = new Presentation("Presentation.ppt"))
{
    ILayoutSlideHeaderFooterManager headerFooterManager = presentation.LayoutSlides[0].HeaderFooterManager;

    if (!headerFooterManager.IsFooterVisible)
    {
        headerFooterManager.SetFooterVisibility(true);
    }

    if (!headerFooterManager.IsSlideNumberVisible)
    {
        headerFooterManager.SetSlideNumberVisibility(true);
    }

    if (!headerFooterManager.IsDateTimeVisible)
    {
        headerFooterManager.SetDateTimeVisibility(true);
    }

    headerFooterManager.SetFooterText("Footer text");
    headerFooterManager.SetDateTimeText("Date and time text");

    presentation.Save("Presentation.ppt", SaveFormat.Ppt);
}
```

## **Set Child Footer Visibility Inside a Slide**

​In PowerPoint presentations, footer elements such as date, slide number, and custom text can be controlled at the master slide level to ensure consistency across all layout slides. Aspose.Slides for .NET enables you to set the visibility and content of these footer placeholders on the master slide and propagate these settings to all child layout slides. This approach ensures uniform footer information throughout your presentation.​

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class.
1. Get a reference to the master slide by its index.
1. Set the master’s and all child footer placeholders to visible.
1. Set the master’s and all child slide number placeholders to visible.
1. Set the master’s and all child date-time placeholders to visible.
1. Save the presentation.

The following C# code demonstrates this operation:

```cs
using (Presentation presentation = new Presentation("Presentation.ppt"))
{
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.Masters[0].HeaderFooterManager;

    headerFooterManager.SetFooterAndChildFootersVisibility(true);
    headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.SetFooterAndChildFootersText("Footer text");
    headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");

    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **FAQs**

**What’s the difference between a master slide and a layout slide?**

A master slide defines the overall theme and default formatting, while layout slides define specific arrangements of placeholders for different types of content.

**Can I copy a layout slide from one presentation to another?**

Yes, you can clone a layout slide from one presentation’s [LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/presentation/layoutslides/) collection and insert it into another using the `LayoutSlides.AddClone` method.

**What happens if I delete a layout slide that's still used by a slide?**

If you try to delete a layout slide that is still referenced by at least one slide in the presentation, Aspose.Slides will throw a [PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception/). To avoid this, use [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) which safely removes only the layout slides that are not in use.
