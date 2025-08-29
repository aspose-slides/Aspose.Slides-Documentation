---
title: Save Presentations in Python
linktitle: Save Presentation
type: docs
weight: 80
url: /python-net/save-presentation/
keywords:
- save PowerPoint
- save presentation
- save PPT
- save PPTX
- save ODP
- save presentation to file
- save presentation to stream
- view type
- strict Office Open XML format
- saving progress
- Python
- Aspose.Slides
description: "Discover how to save presentations in Python using Aspose.Slides—export to PowerPoint or OpenDocument while retaining layouts, fonts and effects."
---

## **Overview**

[Open a Presentation in Python](/slides/python-net/open-presentation/) described how to use the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class to open a presentation. This article explains how to create and save presentations. The [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class contains a presentation’s contents. Whether you’re creating a presentation from scratch or modifying an existing one, you’ll want to save it when you’re finished. With Aspose.Slides for Python, you can save to a **file** or **stream**. This article explains the different ways to save a presentation.

## **Save Presentations to Files**

Save a presentation to a file by calling the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class’s `save` method. Pass the file name and save format to the method. The following example show how to save a presentation with Aspose.Slides for Python.

```py
import aspose.slides as slides

# Instantiate the Presentation class that represents a PPT file.
with slides.Presentation() as presentation:
    
    # Do some work here...

    # Save the presentation to a file.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Save Presentations to Streams**

You can save a presentation to a stream by passing an output stream to the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class’s `save` method. A presentation can be written to many stream types. In the example below, we create a new presentation, add text to a shape, and save it to a stream.

```py
import aspose.slides as slides

# Instantiate the Presentation class that represents a PPT file.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 200)

    # Save the presentation to a stream.
    with open("output.pptx", "bw") as file_stream:
        presentation.save(file_stream, slides.export.SaveFormat.PPTX)
```

## **Save Presentations with a Predefined View Type**

Aspose.Slides for Python lets you set the initial view that PowerPoint uses when the generated presentation opens through the [ViewProperties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/) class. Set the `last_view` property to a value from the [ViewType](https://reference.aspose.com/slides/python-net/aspose.slides/viewtype/) enumeration.

```py
import aspose.slides as slides

# Instantiate the Presentation class that represents a PPT file.
with slides.Presentation() as presentation:
    
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW

    presentation.save("slide_master_view.pptx", slides.export.SaveFormat.PPTX)

```

## **Save Presentations in the Strict Office Open XML Format**

Aspose.Slides lets you save a presentation in the Strict Office Open XML format. Use the [PptxOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/) class and set its conformance property when saving. If you set `Conformance.ISO29500_2008_STRICT`, the output file is saved in the Strict Office Open XML format.

The example below creates a presentation and saves it in the Strict Office Open XML format.

```py
import aspose.slides as slides

# Instantiate the Presentation class that represents a presentation file.
with slides.Presentation() as presentation:
    # Get the first slide.
    slide = presentation.slides[0]

    # Add a line AutoShape.
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    options = slides.export.PptxOptions()
    options.conformance = slides.export.Conformance.ISO29500_2008_STRICT

    # Save the presentation in the Strict Office Open XML format.
    presentation.save("strict_office_open_xml.pptx", slides.export.SaveFormat.PPTX, options)
```

## **Save Presentations without Refreshing the Thumbnail**

The [PptxOptions.refresh_thumbnail](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/) property controls thumbnail generation when saving a presentation to PPTX:

- If set to `True`, the thumbnail is refreshed during save. This is the default.
- If set to `False`, the current thumbnail is preserved. If the presentation has no thumbnail, none is generated.

In the code below, the presentation is saved to PPTX without refreshing its thumbnail.

```py
with slides.Presentation("sample.pptx") as presentation:
    
    pptx_options = slides.export.PptxOptions()
    pptx_options.refresh_thumbnail = False
    
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="Info" color="info" %}}

This option helps reduce the time required to save a presentation in PPTX format.

{{% /alert %}}

{{% alert title="Info" color="info" %}}

Aspose has developed a [free PowerPoint Splitter app](https://products.aspose.app/slides/splitter) using its own API. The app lets you split a presentation into multiple files by saving selected slides as new PPTX or PPT files.

{{% /alert %}}
