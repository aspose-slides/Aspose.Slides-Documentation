---
title: Slide Layout
type: docs
weight: 60
url: /net/slide-layout/
keyword: "Set slide size, set slide options, specify slide size, Footer visibility, Child footer, Content scaling, page size, C#, Csharp, .NET, Aspose.Slides"
description: "Set PowerPoint slide size and options in C# or .NET"
---

A slide layout contains the placeholder boxes and formatting information for all the content that appears on a slide. The layout determines the available content placeholders and where they are placed. 

Slide layouts allow you to create and design presentations quickly (whether simple or complex). These are some of the most popular slide layouts used in PowerPoint presentations: 

* **Title Slide layout**. This layout consists of two text placeholders. One placeholder is for the title and the other is for the subtitle. 
* **Title and Content layout**. This layout contains a relatively small placeholder at the top for the title and a bigger placeholder for the core content (chart, paragraphs, bullet list, numbered list, images, etc).
* **Blank layout**. This layout lacks placeholders, so it allows you to create elements from scratch. 

Since a slide master is the top hierarchical slide that stores information about slide layouts, you can use the master slide to access slide layouts and make changes to them. A layout slide can be accessed by type or name. Similarly, every slide has a unique id, which can be used to access it. 

Alternatively, you can make changes directly to a specific slide layout in a presentation. 

* To allow you to work with slide layouts (including those in master slides), Aspose.Slides provides properties like [LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/presentation/layoutslides/) and [Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) under the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class. 
* To perform related tasks, Aspose.Slides provides [MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/masterslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/masterlayoutslidecollection/), [SlideSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/), [BaseSlideHeaderFooterManager](https://reference.aspose.com/slides/net/aspose.slides/baseslideheaderfootermanager/), and many other types. 

{{% alert title="Info" color="info" %}}

For more information on working with Master Slides in particular, see the [Slide Master](https://docs.aspose.com/slides/net/slide-master/) article.

{{% /alert %}}

## **Add Slide Layout to Presentation**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class.
1. Access the [MasterSlide collection](https://reference.aspose.com/slides/net/aspose.slides/imasterlayoutslidecollection/).
1. Go through the existing layout slides to confirm that the required layout slide already exists in the Layout Slide collection. Otherwise, add the Layout slide you want. 
1. Add an empty slide based on the new layout slide.
1. Save the presentation. 

This C# code shows you how to add a slide layout to a PowerPoint presentation:

```c#
// Instantiates a Presentation class that represents the presentation file
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    // Goes through layout slide types
    IMasterLayoutSlideCollection layoutSlides = presentation.Masters[0].LayoutSlides;
    ILayoutSlide layoutSlide = layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? layoutSlides.GetByType(SlideLayoutType.Title);

    if (layoutSlide == null)
    {
        // The situation where a presentation doesn't contain some layout types. 
        // presentation File only contains Blank and Custom layout types.
        // But layout slides with Custom types have different slide names,
        // like "Title", "Title and Content", etc. And it is possible to use these
        // names for layout slide selection.
        // You can also use a set of placeholder shape types. For example,
        // Title slide should have only Title pleceholder type, etc.
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

    // Adds empty slide with added layout slide 
    presentation.Slides.InsertEmptySlide(0, layoutSlide);

    // Saves the presentation to disk  
    presentation.Save("AddLayoutSlides_out.pptx", SaveFormat.Pptx);
}
```

## **Remove Unused Layout Slide**

Aspose.Slides provides the [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) method from the [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) class to allow you to delete unwanted and unused layout slides. This C# code shows you how to remove a layout slide from a PowerPoint presentation:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedLayoutSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


## **Set Size and Type for Slide Layout**

To allow you to set the size and type for a specific layout slide, Aspose.Slides provides the [Type](https://reference.aspose.com/slides/net/aspose.slides/slidesize/properties/type) and [Size](https://reference.aspose.com/slides/net/aspose.slides/slidesize/properties/size) properties (from the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class). This C# demonstrates the operation:

```c#
// Instantiates a Presentation object that represents a presentation file 
Presentation presentation = new Presentation("AccessSlides.pptx");
Presentation auxPresentation = new Presentation();

ISlide slide = presentation.Slides[0];

// Sets the slide size for the generated presentation to that of the source
auxPresentation.SlideSize.SetSize(presentation.SlideSize.Type,SlideSizeScaleType.EnsureFit);

auxPresentation.Slides.InsertClone(0, slide);
auxPresentation.Slides.RemoveAt(0);
// Saves the presentation to disk
auxPresentation.Save("Set_Size&Type_out.pptx", SaveFormat.Pptx);
```

## **Add Placeholder To Slide Layout**

Aspose.Slides provides the [ILayoutSlide.PlaceholderManager](https://reference.aspose.com/slides/net/aspose.slides/ilayoutslide/placeholdermanager/) property that allows you to add new placeholders to the layout slide.

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

This C# code demonstrates how to add the new placeholder shapes to the Blank layout slide:

```c#
using (var pres = new Presentation())
{
    // Getting the Blank layout slide
    ILayoutSlide layout = pres.LayoutSlides.GetByType(SlideLayoutType.Blank);

    // Getting the placeholder manager of the layout slide
    ILayoutPlaceholderManager placeholderManager = layout.PlaceholderManager;

    // Adding different placeholders to the Blank layout slide
    placeholderManager.AddContentPlaceholder(10, 10, 300, 200);
    placeholderManager.AddVerticalTextPlaceholder(350, 10, 200, 300);
    placeholderManager.AddChartPlaceholder(10, 350, 300, 300);
    placeholderManager.AddTablePlaceholder(350, 350, 300, 200);

    // Adding the new slide with Blank layout
    ISlide newSlide = pres.Slides.AddEmptySlide(layout);

    pres.Save("placeholders.pptx", SaveFormat.Pptx);
}
```

## **Set Footer Visibility Inside Slide**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
1. Get a slide's reference through its index.
1. Set the slide footer placeholder to visible. 
1. Set the date-time placeholder to visible. 
1. Save the presentation. 

This C# code shows you how to set the visibility for a slide footer (and perform related tasks):

```c#
using (Presentation presentation = new Presentation("presentation.ppt"))
{
    IBaseSlideHeaderFooterManager headerFooterManager = presentation.Slides[0].HeaderFooterManager;
    if (!headerFooterManager.IsFooterVisible) // Property IsFooterVisible is used to specify that a slide footer placeholder is missing
    {
        headerFooterManager.SetFooterVisibility(true); // Method SetFooterVisibility is used to set a slide footer placeholder to visible
    }
    if (!headerFooterManager.IsSlideNumberVisible) // Property IsSlideNumberVisible is used to specify that a slide page number placeholder is missing
    {
        headerFooterManager.SetSlideNumberVisibility(true); // Method SetSlideNumberVisibility is used to set a slide page number placeholder to visible
    }
    if (!headerFooterManager.IsDateTimeVisible) // Property IsDateTimeVisible is used to specify that a slide date-time placeholder is missing
    {
        headerFooterManager.SetDateTimeVisibility(true); // Method SetFooterVisibility is used to set a slide date-time placeholder to visible
    }
    headerFooterManager.SetFooterText("Footer text"); // Method SetFooterText is used to set a text for a slide footer placeholder
    headerFooterManager.SetDateTimeText("Date and time text"); // Method SetDateTimeText is used to set a text for a slide date-time placeholder.

	presentation.Save("Presentation.ppt",SaveFormat.ppt);
}
```

## **Set Child Footer Visibility Inside Slide**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
1. Get a reference for the master slide through its index. 
1. Set the master slide and all child footer placeholders to visible.
1. Set a text for the master slide and all child footer placeholders. 
1. Set a text for the master slide and all child date-time placeholders. 
1. Save the presentation. 

This C# code demonstrates the operation:

```c#
using (Presentation presentation = new Presentation("presentation.ppt"))
{
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.Masters[0].HeaderFooterManager;
    headerFooterManager.SetFooterAndChildFootersVisibility(true); // Method SetFooterAndChildFootersVisibility is used to set the master slide and all child footer placeholders to visible
    headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true); // Method SetSlideNumberAndChildSlideNumbersVisibility is used to set the master slide and all child page number placeholders to visible
    headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true); // Method SetDateTimeAndChildDateTimesVisibility is used to set a master slide and all child date-time placeholders to visible

    headerFooterManager.SetFooterAndChildFootersText("Footer text"); // Method SetFooterAndChildFootersText is used to set texts for the master slide and all child footer placeholders
    headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text"); // Method SetDateTimeAndChildDateTimesText is used to set text for the master slide and all child date-time placeholders
}
```

## **Set Slide Size with Respect to Content Scaling**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class and load the presentation containing the slide whose size you want to set. 
1. Create another instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class to generate a new presentation. 
1. Get the slide's reference (from the first presentation) through its index.
1. Set the slide footer placeholder to visible. 
1. Set the date-time placeholder to visible. 
1. Save the presentation. 

This C# demonstrates the operation: 

```c#
// Instantiates a Presentation object that represents a presentation file 
Presentation presentation = new Presentation("AccessSlides.pptx");
Presentation auxPresentation = new Presentation();

ISlide slide = presentation.Slides[0];

// Sets the slide size for the generated presentations to that of the source
presentation.SlideSize.SetSize(540, 720, SlideSizeScaleType.EnsureFit); // Method SetSize is used to set slide size with scale content to ensure fit
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.Maximize); // Method SetSize is used to set slide size with maximum size of content
           
// Saves the presentation to disk
auxPresentation.Save("Set_Size&Type_out.pptx", SaveFormat.Pptx);
```

## **Set Page Size when Generating PDF**

Certain presentations (like posters) are often converted to PDF docs. If you are looking to convert your PowerPoint to PDF to access the best printing and accessibility options, you want to set your slides to sizes that suit PDF documents (A4, for example).

Aspose.Slides provides the [SlideSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/) class to allow you to specify your preferred settings for slides. This C# code shows you how to use the [Type](https://reference.aspose.com/slides/net/aspose.slides/slidesize/type/) property (from the `SlideSize` class) to set a specific paper size for the slides in a presentation:

```c#
// Instantiates a Presentation object that represents a presentation file 
Presentation presentation = new Presentation();

// Sets the SlideSize.Type Property 
presentation.SlideSize.SetSize(SlideSizeType.A4Paper,SlideSizeScaleType.EnsureFit);

// Sets different properties for PDF Options
PdfOptions opts = new  PdfOptions();
opts.SufficientResolution = 600;

// Saves the presentation to disk
presentation.Save("SetPDFPageSize_out.pdf", SaveFormat.Pdf, opts);
```
