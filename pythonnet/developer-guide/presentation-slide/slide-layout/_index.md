---
title: Slide Layout
type: docs
weight: 60
url: /pythonnet/slide-layout/
keyword: "Set slide size, set slide options, specify slide size, Footer visibility, Child footer, Content scaling, page size, Python, Aspose.Slides"
description: "Set PowerPoint slide size and options in Python"
---


## **Add Slide Layout to Presentation**
Aspose.Slides also offer to add Layout slides in presentation. There are cases when there is missing Layout slide in presentation and once can now add the Layout Slides in presentation. Each slide has unique Id and Layout slides are maintained inside presentation Masters. One can access the Layout slide either by Type or by Name. Aspose.Slides for Python via .NET allows developers to add new Layout slides in presentation. To add a Layout Slide, please follow the steps below:

1. Create an instance of Presentation class.
1. Access the Master Slide collection.
1. Try to find existing Layout slides to see if the required one is already available in Layout Slide collection or not.
1. Add a new Layout slide if the desired layout is unavailable.
1. Add an empty slide with a newly added Layout slide.
1. Finally, write the presentation file using the Presentation object.

In the example given below, we have added Layout Slides to Presentation.

```py
// Instantiate Presentation class that represents the presentation file
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    // Try to search by layout slide type
    IMasterLayoutSlideCollection layoutSlides = presentation.Masters[0].LayoutSlides;
    ILayoutSlide layoutSlide = layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? layoutSlides.GetByType(SlideLayoutType.Title);

    if (layoutSlide == null)
    {
        // The situation when a presentation doesn't contain some type of layouts.
        // presentation File only contains Blank and Custom layout types.
        // But layout slides with Custom types has different slide names,
        // like "Title", "Title and Content", etc. And it is possible to use these
        // names for layout slide selection.
        // Also it is possible to use the set of placeholder shape types. For example,
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

    // Adding empty slide with added layout slide 
    presentation.Slides.InsertEmptySlide(0, layoutSlide);

    // Save presentation    
    presentation.Save("AddLayoutSlides_out.pptx", SaveFormat.Pptx);
}
```




## **Set Size and Type of Slide**
[SlideSize.Type](https://apireference.aspose.com/slides/pythonnet/aspose.slides/slidesize/properties/type) and [SlideSize.Size](https://apireference.aspose.com/slides/pythonnet/aspose.slides/slidesize/properties/size) are the properties of presentation class which could be set or get as shown below in the example.

```py
// Instantiate a Presentation object that represents a presentation file 
Presentation presentation = new Presentation("AccessSlides.pptx");
Presentation auxPresentation = new Presentation();

ISlide slide = presentation.Slides[0];

// Set the slide size of generated presentations to that of source
auxPresentation.SlideSize.SetSize(presentation.SlideSize.Type,SlideSizeScaleType.EnsureFit);

auxPresentation.Slides.InsertClone(0, slide);
auxPresentation.Slides.RemoveAt(0);
// Save Presentation to disk
auxPresentation.Save("Set_Size&Type_out.pptx", SaveFormat.Pptx);
```


## **Set Footer Visibility Inside Slide**
To set footer in a slide using its index position in the slides collection of the presentation, please follow the steps below:

1. Create an instance of [Presentation](https://apireference.aspose.com/slides/pythonnet/aspose.slides/presentation) class.
1. Obtain a slide by its reference index.
1. Set Footer visible by making slide footer placeholder visible.
1. Set date-time placeholder visible by using the SetDateTime method.
1. Write the modified presentation file.

```py
using (Presentation presentation = new Presentation("presentation.ppt"))
{
    IBaseSlideHeaderFooterManager headerFooterManager = presentation.Slides[0].HeaderFooterManager;
    if (!headerFooterManager.IsFooterVisible) // Property IsFooterVisible is used for indicating that a slide footer placeholder is not present.
    {
        headerFooterManager.SetFooterVisibility(true); // Method SetFooterVisibility is used for making a slide footer placeholder visible.
    }
    if (!headerFooterManager.IsSlideNumberVisible) // Property IsSlideNumberVisible is used for indicating that a slide page number placeholder is not present.
    {
        headerFooterManager.SetSlideNumberVisibility(true); // Method SetSlideNumberVisibility is used for making a slide page number placeholder visible.
    }
    if (!headerFooterManager.IsDateTimeVisible) // Property IsDateTimeVisible is used for indicating that a slide date-time placeholder is not present.
    {
        headerFooterManager.SetDateTimeVisibility(true); // Method SetFooterVisibility is used for making a slide date-time placeholder visible.
    }
    headerFooterManager.SetFooterText("Footer text"); // Method SetFooterText is used for setting text to slide footer placeholder.
    headerFooterManager.SetDateTimeText("Date and time text"); // Method SetDateTimeText is used for setting text to slide date-time placeholder.

	presentation.Save("Presentation.ppt",SaveFormat.ppt);
}
```



## **Set Child Footer Visibility Inside Slide**
To set footer and child footer a slide using its index position in the slides collection of the presentation, please follow the steps below:

1. Create an instance of [Presentation](https://apireference.aspose.com/slides/pythonnet/aspose.slides/presentation) class.
1. Obtain the master slide by using its index.
1. Set Footer and child footer visibility by making a master slide and all child footer placeholder visible.
1. Set text to master slide and all child footer placeholder by using [SetFooterAndChildFootersText ](https://apireference.aspose.com/slides/pythonnet/aspose.slides/imasterslideheaderfootermanager/methods/setfooterandchildfootersvisibility)method.
1. Set text to master slide and all child date-time placeholder by using SetDateTimeAndChildDateTimesText method.
1. Write the modified presentation file.

```py
using (Presentation presentation = new Presentation("presentation.ppt"))
{
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.Masters[0].HeaderFooterManager;
    headerFooterManager.SetFooterAndChildFootersVisibility(true); // Method SetFooterAndChildFootersVisibility is used for making a master slide and all child footer placeholders visible.
    headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true); // Method SetSlideNumberAndChildSlideNumbersVisibility is used for making a master slide and all child page number placeholders visible.
    headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true); // Method SetDateTimeAndChildDateTimesVisibility is used for making a master slide and all child date-time placeholders visible.

    headerFooterManager.SetFooterAndChildFootersText("Footer text"); // Method SetFooterAndChildFootersText is used for setting text to master slide and all child footer placeholders.
    headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text"); // Method SetDateTimeAndChildDateTimesText is used for setting text to master slide and all child date-time placeholders.
}

```



## **Set Slide Size with Respect to Content Scaling**
You can also set the slide size by using it with different ways of content scaling.[SlideSize.Type](https://apireference.aspose.com/slides/pythonnet/aspose.slides/slidesize/properties/type) and [SlideSize.Size](https://apireference.aspose.com/slides/pythonnet/aspose.slides/slidesize/properties/size) are the properties of presentation class which could be set or get as shown below in the example.

```py
// Instantiate a Presentation object that represents a presentation file 
Presentation presentation = new Presentation("AccessSlides.pptx");
Presentation auxPresentation = new Presentation();

ISlide slide = presentation.Slides[0];

// Set the slide size of generated presentations to that of source
presentation.SlideSize.SetSize(540, 720, SlideSizeScaleType.EnsureFit); // Method SetSize is used for set slide size with scale content to ensure fit
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.Maximize); // Method SetSize is used for set slide size with maximize size of content
           
// Save Presentation to disk
auxPresentation.Save("Set_Size&Type_out.pptx", SaveFormat.Pptx);
```



## **Set Page Size when Generating PDF**
Slides in presentation could be set as different paper sizes. The [SlideSize.Type](https://apireference.aspose.com/slides/pythonnet/aspose.slides/slidesize/properties/type) property can be used to set the slide size. Developers can set the size of a slide as shown below in the example.

```py
// Instantiate a Presentation object that represents a presentation file 
Presentation presentation = new Presentation();

// Set SlideSize.Type Property 
presentation.SlideSize.SetSize(SlideSizeType.A4Paper,SlideSizeScaleType.EnsureFit);

// Set different properties of PDF Options
PdfOptions opts = new  PdfOptions();
opts.SufficientResolution = 600;

// Save presentation to disk
presentation.Save("SetPDFPageSize_out.pdf", SaveFormat.Pdf, opts);
```

