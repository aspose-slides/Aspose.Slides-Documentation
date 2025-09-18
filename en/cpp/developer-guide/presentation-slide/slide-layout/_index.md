---
title: Apply or Change a Slide Layout in C++
linktitle: Slide Layout
type: docs
weight: 60
url: /cpp/slide-layout/
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
- C++
- Aspose.Slides
description: "Learn how to manage and customize slide layouts in Aspose.Slides for C++. Explore layout types, placeholder control, footer visibility, and layout manipulation through code examples in C++."
---

## **Overview**

A slide layout defines the arrangement of placeholder boxes and formatting for the content on a slide. It controls which placeholders are available and where they appear. Slide layouts help you design presentations quickly and consistently—whether you're creating something simple or more complex. Some of the most common slide layouts in PowerPoint include:

**Title Slide layout** – Includes two text placeholders: one for the title and one for the subtitle.

**Title and Content layout** – Features a smaller title placeholder at the top and a larger one below for main content (such as text, bullet points, charts, images, and more).

**Blank layout** – Contains no placeholders, giving you full control to design the slide from scratch.

Slide layouts are part of a slide master, which is the top-level slide that defines layout styles for the presentation. You can access and modify layout slides through the slide master—either by their type, name, or unique ID. Alternatively, you can edit a specific layout slide directly within the presentation.

To work with slide layouts in Aspose.Slides for Android, you can use:

- Methods such as [get_LayoutSlides](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_layoutslides/) and [get_Masters](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/) under the [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class
- Types like [ILayoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/cpp/aspose.slides/ilayoutplaceholdermanager/), and [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/cpp/aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}

To learn more about working with master slides, check out the [Slide Master](/slides/cpp/slide-master/) article.

{{% /alert %}}

## **Add a Slide Layout to a Presentation**

To customize the appearance and structure of your slides, you may need to add new layout slides to a presentation. Aspose.Slides for Android allows you to check whether a specific layout already exists, add a new one if needed, and use it to insert slides based on that layout.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class.
1. Access the [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/imasterlayoutslidecollection/).
1. Check whether the desired layout slide already exists in the collection. If not, add the layout slide you need.
1. Add an empty slide based on the new layout slide.
1. Save the presentation.

The following C++ code demonstrates how to add a slide layout to a PowerPoint presentation:

```cpp
// Instantiate the Presentation class that represents a PowerPoint file.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// Go through the layout slide types to select a layout slide.
auto layoutSlides = presentation->get_Master(0)->get_LayoutSlides();
SharedPtr<ILayoutSlide> layoutSlide;
if (layoutSlides->GetByType(SlideLayoutType::TitleAndObject) != NULL)
{
    layoutSlide = layoutSlides->GetByType(SlideLayoutType::TitleAndObject);
}
else if (layoutSlides->GetByType(SlideLayoutType::Title) != NULL)
{
    layoutSlide = layoutSlides->GetByType(SlideLayoutType::Title);
}

if (layoutSlide == NULL)
{
    // A situation where the presentation doesn't contain all layout types.
    // The presentation file contains only Blank and Custom layout types.
    // However, layout slides with custom types may have recognizable names,
    // such as "Title", "Title and Content", etc., which can be used for layout slide selection.
    // You can also rely on a set of placeholder shape types.
    // For example, a Title slide should have only the Title placeholder type, and so on.
    for (int i = 0; i < layoutSlides->get_Count(); i++)
    {
        auto titleAndObjectLayoutSlide = layoutSlides->idx_get(i);

        if (titleAndObjectLayoutSlide->get_Name().Equals(u"Title and Object"))
        {
            layoutSlide = titleAndObjectLayoutSlide;
            break;
        }
    }

    if (layoutSlide == NULL)
    {
        for (int i = 0; i < layoutSlides->get_Count(); i++)
        {
            auto titleLayoutSlide = layoutSlides->idx_get(i);

            if (titleLayoutSlide->get_Name().Equals(u"Title"))
            {
                layoutSlide = titleLayoutSlide;
                break;
            }
        }

        if (layoutSlide == NULL)
        {
            layoutSlide = layoutSlides->GetByType(SlideLayoutType::Blank);
            if (layoutSlide == NULL)
            {
                layoutSlide = layoutSlides->Add(SlideLayoutType::TitleAndObject, u"Title and Object");
            }
        }
    }
}

// Add an empty slide using the added layout slide.
presentation->get_Slides()->InsertEmptySlide(0, layoutSlide);

// Save the presentation to disk.
presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Remove Unused Layout Slides**

Aspose.Slides provides the [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) method from the [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/) class to allow you to delete unwanted and unused layout slides.

The following C++ code shows how to remove a layout slide from a PowerPoint presentation:

```cpp
auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Add a Placeholder To a Slide Layout**

Aspose.Slides provides the [ILayoutSlide.get_PlaceholderManager](https://reference.aspose.com/slides/cpp/aspose.slides/ilayoutslide/get_placeholdermanager/) method, which allows you to add new placeholders to a layout slide.

This manager contains methods for the following placeholder types:

| PowerPoint Placeholder              | [ILayoutPlaceholderManager](https://reference.aspose.com/slides/cpp/aspose.slides/ilayoutplaceholdermanager/) Method |
| ----------------------------------- | ------------------------------------------------------------ |
| ![Content](content.png)             | AddContentPlaceholder(float x, float y, float width, float height) |
| ![Content (Vertical)](contentV.png) | AddVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Text](text.png)                   | AddTextPlaceholder(float x, float y, float width, float height) |
| ![Text (Vertical)](textV.png)       | AddVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Picture](picture.png)             | AddPicturePlaceholder(float x, float y, float width, float height) |
| ![Chart](chart.png)                 | AddChartPlaceholder(float x, float y, float width, float height) |
| ![Table](table.png)                 | AddTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png)           | AddSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Media](media.png)                 | AddMediaPlaceholder(float x, float y, float width, float height) |
| ![Online Image](onlineimage.png)    | AddOnlineImagePlaceholder(float x, float y, float width, float height) |

The following C++ code demonstrates how to add new placeholder shapes to the Blank layout slide:

```cpp
auto presentation = MakeObject<Presentation>();

// Get the Blank layout slide.
auto layout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

// Get the placeholder manager of the layout slide.
auto placeholderManager = layout->get_PlaceholderManager();

// Add different placeholders to the Blank layout slide.
placeholderManager->AddContentPlaceholder(20, 20, 310, 270);
placeholderManager->AddVerticalTextPlaceholder(350, 20, 350, 270);
placeholderManager->AddChartPlaceholder(20, 310, 310, 180);
placeholderManager->AddTablePlaceholder(350, 310, 350, 180);

// Add a new slide with the Blank layout.
auto newSlide = presentation->get_Slides()->AddEmptySlide(layout);

presentation->Save(u"Placeholders.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

The result:

![The placeholders on the layout slide](add_placeholders.png)

## **Set Footer Visibility for a Layout Slide**

In PowerPoint presentations, footer elements like date, slide number, and custom text can be shown or hidden depending on the slide layout. Aspose.Slides for Android allows you to control the visibility of these footer placeholders. This is useful when you want certain layouts to display footer information while others remain clean and minimal.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class.
1. Get a layout slide reference by its index.
1. Set the slide footer placeholder to visible.
1. Set the slide number placeholder to visible.
1. Set the date-time placeholder to visible.
1. Save the presentation.

The following C++ code shows how to set the visibility of a slide footer and perform related tasks:

```cpp
auto presentation = MakeObject<Presentation>(u"Presentation.ppt");
auto headerFooterManager = presentation->get_LayoutSlides()->idx_get(0)->get_HeaderFooterManager();

if (!headerFooterManager->get_IsFooterVisible())
{
    headerFooterManager->SetFooterVisibility(true);
}

if (!headerFooterManager->get_IsSlideNumberVisible())
{
    headerFooterManager->SetSlideNumberVisibility(true);
}

if (!headerFooterManager->get_IsDateTimeVisible())
{
    headerFooterManager->SetDateTimeVisibility(true);
}

headerFooterManager->SetFooterText(u"Footer text");
headerFooterManager->SetDateTimeText(u"Date and time text");

presentation->Save(u"Presentation.ppt", SaveFormat::Pptx);
presentation->Dispose();
```

## **Set Child Footer Visibility for a Slide**

​In PowerPoint presentations, footer elements such as date, slide number, and custom text can be controlled at the master slide level to ensure consistency across all layout slides. Aspose.Slides for Android enables you to set the visibility and content of these footer placeholders on the master slide and propagate these settings to all child layout slides. This approach ensures uniform footer information throughout your presentation.​

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class.
1. Get a reference to the master slide by its index.
1. Set the master’s and all child footer placeholders to visible.
1. Set the master’s and all child slide number placeholders to visible.
1. Set the master’s and all child date-time placeholders to visible.
1. Save the presentation.

The following C++ code demonstrates this operation:

```cpp
auto presentation = MakeObject<Presentation>();

auto headerFooterManager = presentation->get_Master(0)->get_HeaderFooterManager();

headerFooterManager->SetFooterAndChildFootersVisibility(true);
headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQs**

**What’s the difference between a master slide and a layout slide?**

A master slide defines the overall theme and default formatting, while layout slides define specific arrangements of placeholders for different types of content.

**Can I copy a layout slide from one presentation to another?**

Yes, you can clone a layout slide from one presentation’s layout slide collection, accessible via the [get_LayoutSlides](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_layoutslides/) method, and insert it into another presentation using the `AddClone` method.

**What happens if I delete a layout slide that's still used by a slide?**

If you try to delete a layout slide that is still referenced by at least one slide in the presentation, Aspose.Slides will throw a [PptxEditException](https://reference.aspose.com/slides/cpp/aspose.slides/pptxeditexception/). To avoid this, use [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) which safely removes only the layout slides that are not in use.
