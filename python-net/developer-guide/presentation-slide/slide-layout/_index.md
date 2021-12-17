---
title: Slide Layout
type: docs
weight: 60
url: /python-net/slide-layout/
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
import aspose.pydrawing as draw
import aspose.slides as slides

# Instantiate Presentation class that represents the presentation file
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Try to search by layout slide type
    layoutSlides = presentation.masters[0].layout_slides
    layoutSlide = layoutSlides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)  
    if layoutSlide is None:
         layoutSlide = layoutSlides.get_by_type(slides.SlideLayoutType.TITLE)

    if layoutSlide is None:
        # The situation when a presentation doesn't contain some type of layouts.
        # presentation File only contains Blank and Custom layout types.
        # But layout slides with Custom types has different slide names,
        # like "Title", "Title and Content", etc. And it is possible to use these
        # names for layout slide selection.
        # Also it is possible to use the set of placeholder shape types. For example,
        # Title slide should have only Title pleceholder type, etc.
        for titleAndObjectLayoutSlide in layoutSlides:
            if titleAndObjectLayoutSlide.name == "Title and Object":
                layoutSlide = titleAndObjectLayoutSlide
                break

        if layoutSlide is None:
            for titleLayoutSlide in layoutSlides:
                if titleLayoutSlide.name == "Title":
                    layoutSlide = titleLayoutSlide
                    break

            if layoutSlide is None:
                layoutSlide = layoutSlides.get_by_type(slides.SlideLayoutType.BLANK)
                if layoutSlide is None:
                    layoutSlide = layoutSlides.Add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Title and Object")

    # Adding empty slide with added layout slide 
    presentation.slides.insert_empty_slide(0, layoutSlide)

    # save presentation    
    presentation.save("AddLayoutSlides_out.pptx", slides.export.SaveFormat.PPTX)
```




## **Set Size and Type of Slide**
[SlideSize.type](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/slidesize/) and [SlideSize.size](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/slidesize/) are the properties of presentation class which could be set or get as shown below in the example.

```py
import aspose.slides as slides

// Instantiate a Presentation object that represents a presentation file 
# Instantiate a Presentation object that represents a presentation file 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    with slides.Presentation() as auxPresentation:
        slide = presentation.slides[0]

        # Set the slide size of generated presentations to that of source
        auxPresentation.slide_size.set_size(presentation.slide_size.type, slides.SlideSizeScaleType.ENSURE_FIT)

        auxPresentation.slides.insert_clone(0, slide)
        auxPresentation.slides.remove_at(0)
        # save Presentation to disk
        auxPresentation.save("Set_Size&Type_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Set Footer Visibility Inside Slide**
To set footer in a slide using its index position in the slides collection of the presentation, please follow the steps below:

1. Create an instance of [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) class.
1. Obtain a slide by its reference index.
1. Set Footer visible by making slide footer placeholder visible.
1. Set date-time placeholder visible by using the SetDateTime method.
1. Write the modified presentation file.

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    headerFooterManager = presentation.slides[0].header_footer_manager
    # Property is_footer_visible is used for indicating that a slide footer placeholder is not present.
    if not headerFooterManager.is_footer_visible: 
        # Method set_footer_visibility is used for making a slide footer placeholder visible.
        headerFooterManager.set_footer_visibility(True) 
        # Property is_slide_number_visible is used for indicating that a slide page number placeholder is not present.
    if not headerFooterManager.is_slide_number_visible:  
        # Method set_slide_number_visibility is used for making a slide page number placeholder visible.
        headerFooterManager.set_slide_number_visibility(True) 
        # Property is_date_time_visible is used for indicating that a slide date-time placeholder is not present.
    if not headerFooterManager.is_date_time_visible: 
        # Method set_footer_visibility is used for making a slide date-time placeholder visible. 
        headerFooterManager.set_date_time_visibility(True)

    # Method set_footer_text is used for setting text to slide footer placeholder. 
    headerFooterManager.set_footer_text("Footer text") 
    # Method set_date_time_text is used for setting text to slide date-time placeholder.
    headerFooterManager.set_date_time_text("Date and time text") 

    presentation.save("Presentation.ppt", slides.export.SaveFormat.PPT)
```



## **Set Child Footer Visibility Inside Slide**
To set footer and child footer a slide using its index position in the slides collection of the presentation, please follow the steps below:

1. Create an instance of [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) class.
1. Obtain the master slide by using its index.
1. Set Footer and child footer visibility by making a master slide and all child footer placeholder visible.
1. Set text to master slide and all child footer placeholder by using [set_footer_and_child_footers_visibility ](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/imasterslideheaderfootermanager/)method.
1. Set text to master slide and all child date-time placeholder by using SetDateTimeAndChildDateTimesText method.
1. Write the modified presentation file.

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    manager = presentation.masters[0].header_footer_manager
    manager.set_footer_and_child_footers_visibility(True) # Method set_footer_and_child_footers_visibility is used for making a master slide and all child footer placeholders visible.
    manager.set_slide_number_and_child_slide_numbers_visibility(True) # Method set_slide_number_and_child_slide_numbers_visibility is used for making a master slide and all child page number placeholders visible.
    manager.set_date_time_and_child_date_times_visibility(True) # Method set_date_time_and_child_date_times_visibility is used for making a master slide and all child date-time placeholders visible.

    manager.set_footer_and_child_footers_text("Footer text") # Method set_footer_and_child_footers_text is used for setting text to master slide and all child footer placeholders.
    manager.set_date_time_and_child_date_times_text("Date and time text") # Method set_date_time_and_child_date_times_text is used for setting text to master slide and all child date-time placeholders.


```



## **Set Slide Size with Respect to Content Scaling**
You can also set the slide size by using it with different ways of content scaling.[SlideSize.Type](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/slidesize/) and [SlideSize.Size](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/slidesize/) are the properties of presentation class which could be set or get as shown below in the example.

```py
import aspose.slides as slides

# Instantiate a Presentation object that represents a presentation file 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    with slides.Presentation() as auxPresentation:
        slide = presentation.slides[0]

        # Set the slide size of generated presentations to that of source
        presentation.slide_size.set_size(540, 720, slides.SlideSizeScaleType.ENSURE_FIT) # Method set_size is used for set slide size with scale content to ensure fit
        presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.MAXIMIZE) # Method set_size is used for set slide size with maximize size of content
                
        # save Presentation to disk
        auxPresentation.save("Set_Size&Type_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Set Page Size when Generating PDF**
Slides in presentation could be set as different paper sizes. The [SlideSize.Type](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/slidesize/) property can be used to set the slide size. Developers can set the size of a slide as shown below in the example.

```py
import aspose.slides as slides

# Instantiate a Presentation object that represents a presentation file 
with slides.Presentation() as presentation:
    # Set slide_size.Type Property 
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.ENSURE_FIT)

    # Set different properties of PDF Options
    opts = slides.export.PdfOptions()
    opts.sufficient_resolution = 600

    # save presentation to disk
    presentation.save("SetPDFPageSize_out.pdf", slides.export.SaveFormat.PDF, opts)
```

