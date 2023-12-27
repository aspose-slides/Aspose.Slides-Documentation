---
title: Slide Layout
type: docs
weight: 60
url: /python-net/slide-layout/
keyword: "Set slide size, set slide options, specify slide size, Footer visibility, Child footer, Content scaling, page size, Python, Aspose.Slides"
description: "Set PowerPoint slide size and options in Python"
---

A slide layout contains the placeholder boxes and formatting information for all the content that appears on a slide. The layout determines the available content placeholders and where they are placed. 

Slide layouts allow you to create and design presentations quickly (whether simple or complex). These are some of the most popular slide layouts used in PowerPoint presentations: 

* **Title Slide layout**. This layout consists of two text placeholders. One placeholder is for the title and the other is for the subtitle. 
* **Title and Content layout**. This layout contains a relatively small placeholder at the top for the title and a bigger placeholder for the core content (chart, paragraphs, bullet list, numbered list, images, etc).
* **Blank layout**. This layout lacks placeholders, so it allows you to create elements from scratch. 

Since a slide master is the top hierarchical slide that stores information about slide layouts, you can use the master slide to access slide layouts and make changes to them. A layout slide can be accessed by type or name. Similarly, every slide has a unique id, which can be used to access it. 

Alternatively, you can make changes directly to a specific slide layout in a presentation. 

* To allow you to work with slide layouts (including those in master slides), Aspose.Slides provides properties like `layout_slides` and `masters` under the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class. 
* To perform related tasks, Aspose.Slides provides [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterlayoutslidecollection/), [SlideSize](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/), [BaseSlideHeaderFooterManager](https://reference.aspose.com/slides/python-net/aspose.slides/baseslideheaderfootermanager/), and many other types. 

{{% alert title="Info" color="info" %}}

For more information on working with Master Slides in particular, see the [Slide Master](https://docs.aspose.com/slides/python-net/slide-master/) article.

{{% /alert %}}

## **Add Slide Layout to Presentation**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Access the [MasterSlide collection](https://reference.aspose.com/slides/python-net/aspose.slides/imasterlayoutslidecollection/).
1. Go through the existing layout slides to confirm that the required layout slide already exists in the Layout Slide collection. Otherwise, add the Layout slide you want. 
1. Add an empty slide based on the new layout slide.
1. Save the presentation. 

This Python code shows you how to add a slide layout to a PowerPoint presentation:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instantiates a Presentation class that represents the presentation file
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Goes through layout slide types
    layoutSlides = presentation.masters[0].layout_slides
    layoutSlide = layoutSlides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)  
    if layoutSlide is None:
         layoutSlide = layoutSlides.get_by_type(slides.SlideLayoutType.TITLE)

    if layoutSlide is None:
        # The situation where a presentation doesn't contain some layout types.
        # presentation File only contains Blank and Custom layout types.
        # But layout slides with Custom types have different slide names,
        # like "Title", "Title and Content", etc. And it is possible to use these
        # names for layout slide selection.
        # You can also use a set of placeholder shape types. For example,
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

    # Adds empty slide with added layout slide 
    presentation.slides.insert_empty_slide(0, layoutSlide)

    # Saves the presentation to disk
    presentation.save("AddLayoutSlides_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Remove Unused Layout Slide**

Aspose.Slides provides the `remove_unused_layout_slides` method from the [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/) class to allow you to delete unwanted and unused layout slides. This Python code shows you how to remove a layout slide from a PowerPoint presentation:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slides.lowcode.Compress.remove_unused_layout_slides(pres)
    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```


## **Set Size and Type for Slide Layout**

To allow you to set the size and type for a specific layout slide, Aspose.Slides provides the `type` and `size` properties (from the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class). This Python demonstrates the operation:

```python
import aspose.slides as slides

// Instantiate a Presentation object that represents a presentation file 
# Instantiates a Presentation object that represents a presentation file 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    with slides.Presentation() as auxPresentation:
        slide = presentation.slides[0]

        # Sets the slide size for the generated presentation to that of the source
        auxPresentation.slide_size.set_size(presentation.slide_size.type, slides.SlideSizeScaleType.ENSURE_FIT)

        auxPresentation.slides.insert_clone(0, slide)
        auxPresentation.slides.remove_at(0)
        # Saves the presentation to disk
        auxPresentation.save("Set_Size&Type_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Set Footer Visibility Inside Slide**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Get a slide's reference through its index.
1. Set the slide footer placeholder to visible. 
1. Set the date-time placeholder to visible. 
1. Save the presentation. 

This Python code shows you how to set the visibility for a slide footer (and perform related tasks):

```python
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    headerFooterManager = presentation.slides[0].header_footer_manager
    # Property is_footer_visible is used to specify that a slide footer placeholder is missing
    if not headerFooterManager.is_footer_visible: 
        # Method set_footer_visibility is used to set a slide footer placeholder to visible
        headerFooterManager.set_footer_visibility(True) 
        # Property is_slide_number_visible is used to specify that a slide page number placeholder is missing
    if not headerFooterManager.is_slide_number_visible:  
        # Method set_slide_number_visibility is used to set a slide page number placeholder to visible
        headerFooterManager.set_slide_number_visibility(True) 
        # Property is_date_time_visible is used to specify that a slide date-time placeholder is missing
    if not headerFooterManager.is_date_time_visible: 
        # Method set_date_time_visibility is used to set a slide date-time placeholder to visible 
        headerFooterManager.set_date_time_visibility(True)

    # Method set_footer_text is used to set a text for a slide footer placeholder 
    headerFooterManager.set_footer_text("Footer text") 
    # Method set_date_time_text is used to set a text for a slide date-time placeholder.
    headerFooterManager.set_date_time_text("Date and time text") 

    # Saves the presentation to disk
    presentation.save("Presentation.ppt", slides.export.SaveFormat.PPT)
```

## **Set Child Footer Visibility Inside Slide**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Get a reference for the master slide through its index. 
1. Set the master slide and all child footer placeholders to visible.
1. Set a text for the master slide and all child footer placeholders. 
1. Set a text for the master slide and all child date-time placeholders. 
1. Save the presentation. 

This Python code demonstrates the operation:

```python
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    manager = presentation.masters[0].header_footer_manager
    manager.set_footer_and_child_footers_visibility(True) # Method set_footer_and_child_footers_visibility is used to set the master slide and all child footer placeholders to visible
    manager.set_slide_number_and_child_slide_numbers_visibility(True) # Method set_slide_number_and_child_slide_numbers_visibility is used to set the master slide and all child page number placeholders to visible
    manager.set_date_time_and_child_date_times_visibility(True) # Method set_date_time_and_child_date_times_visibility is used to set a master slide and all child date-time placeholders to visible

    manager.set_footer_and_child_footers_text("Footer text") # Method set_footer_and_child_footers_text is used to set texts for the master slide and all child footer placeholders
    manager.set_date_time_and_child_date_times_text("Date and time text") # Method set_date_time_and_child_date_times_text is used to set text for the master slide and all child date-time placeholders


```

## **Set Slide Size with Respect to Content Scaling**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class and load the presentation containing the slide whose size you want to set. 
1. Create another instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class to generate a new presentation. 
1. Get the slide's reference (from the first presentation) through its index.
1. Set the slide footer placeholder to visible. 
1. Set the date-time placeholder to visible. 
1. Save the presentation. 

This Python demonstrates the operation: 

```python
import aspose.slides as slides

# Instantiates a Presentation object that represents a presentation file 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    with slides.Presentation() as auxPresentation:
        slide = presentation.slides[0]

        # Sets the slide size for the generated presentations to that of the source
        presentation.slide_size.set_size(540, 720, slides.SlideSizeScaleType.ENSURE_FIT) # Method set_size is used to set slide size with scale content to ensure fit
        presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.MAXIMIZE) # Method set_size is used to set slide size with maximum size of content
                
        # Saves the presentation to disk
        auxPresentation.save("Set_Size&Type_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Set Page Size when Generating PDF**

Certain presentations (like posters) are often converted to PDF docs. If you are looking to convert your PowerPoint to PDF to access the best printing and accessibility options, you want to set your slides to sizes that suit PDF documents (A4, for example).

Aspose.Slides provides the [SlideSize](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/) class to allow you to specify your preferred settings for slides. This Python code shows you how to use the `type` property (from the `SlideSize` class) to set a specific paper size for the slides in a presentation:

```python
import aspose.slides as slides

# Instantiates a Presentation object that represents a presentation file  
with slides.Presentation() as presentation:
    # Sets the SlideSize.Type Property 
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.ENSURE_FIT)

    # Sets different properties for PDF Options
    opts = slides.export.PdfOptions()
    opts.sufficient_resolution = 600

    # Saves the presentation to disk
    presentation.save("SetPDFPageSize_out.pdf", slides.export.SaveFormat.PDF, opts)
```

