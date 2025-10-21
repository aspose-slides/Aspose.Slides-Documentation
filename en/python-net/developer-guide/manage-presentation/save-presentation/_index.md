---
title: Save Presentations in Python
linktitle: Save Presentations
type: docs
weight: 80
url: /python-net/save-presentation/
keywords:
- save PowerPoint
- save OpenDocument
- save presentation
- save slide
- save PPT
- save PPTX
- save ODP
- presentation to file
- presentation to stream
- predefined view type
- Strict Office Open XML Format
- Zip64 mode
- refreshing thumbnail
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

# Instantiate the Presentation class that represents a presentation file.
with slides.Presentation() as presentation:
    
    # Do some work here...

    # Save the presentation to a file.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Save Presentations to Streams**

You can save a presentation to a stream by passing an output stream to the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class’s `save` method. A presentation can be written to many stream types. In the example below, we create a new presentation, add text to a shape, and save it to a stream.

```py
import aspose.slides as slides

# Instantiate the Presentation class that represents a presentation file.
with slides.Presentation() as presentation:
    with open("output.pptx", "bw") as file_stream:
        # Save the presentation to the stream.
        presentation.save(file_stream, slides.export.SaveFormat.PPTX)
```

## **Save Presentations with a Predefined View Type**

Aspose.Slides for Python lets you set the initial view that PowerPoint uses when the generated presentation opens through the [ViewProperties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/) class. Set the `last_view` property to a value from the [ViewType](https://reference.aspose.com/slides/python-net/aspose.slides/viewtype/) enumeration.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("slide_master_view.pptx", slides.export.SaveFormat.PPTX)
```

## **Save Presentations in the Strict Office Open XML Format**

Aspose.Slides lets you save a presentation in the Strict Office Open XML format. Use the [PptxOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/) class and set its conformance property when saving. If you set `Conformance.ISO_29500_2008_STRICT`, the output file is saved in the Strict Office Open XML format.

The example below creates a presentation and saves it in the Strict Office Open XML format.

```py
import aspose.slides as slides

options = slides.export.PptxOptions()
options.conformance = slides.export.Conformance.ISO_29500_2008_STRICT

# Instantiate the Presentation class that represents a presentation file.
with slides.Presentation() as presentation:
    # Save the presentation in the Strict Office Open XML format.
    presentation.save("strict_office_open_xml.pptx", slides.export.SaveFormat.PPTX, options)
```

## **Save Presentations in Office Open XML Format in Zip64 Mode**

An Office Open XML file is a ZIP archive that imposes 4 GB (2^32 bytes) limits on the uncompressed size of any file, the compressed size of any file, and the total size of the archive, and it also limits the archive to 65,535 (2^16-1) files. ZIP64 format extensions raise these limits to 2^64.

The [PptxOptions.zip_64_mode](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/zip_64_mode/) property lets you choose when to use ZIP64 format extensions when saving an Office Open XML file.

This property provides the following modes:

- `IF_NECESSARY` uses ZIP64 format extensions only if the presentation exceeds the limitations above. This is the default mode.
- `NEVER` never uses ZIP64 format extensions.
- `ALWAYS` always uses ZIP64 format extensions.

The following code demonstrates how to save a presentation as PPTX with ZIP64 format extensions enabled:

```py
pptx_options = slides.export.PptxOptions()
pptx_options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output_zip64.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="NOTE" color="warning" %}}

When you save with `Zip64Mode.NEVER`, a [PptxException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxexception/) is thrown if the presentation cannot be saved in ZIP32 format.

{{% /alert %}}

## **Save Presentations without Refreshing the Thumbnail**

The [PptxOptions.refresh_thumbnail](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/) property controls thumbnail generation when saving a presentation to PPTX:

- If set to `True`, the thumbnail is refreshed during save. This is the default.
- If set to `False`, the current thumbnail is preserved. If the presentation has no thumbnail, none is generated.

In the code below, the presentation is saved to PPTX without refreshing its thumbnail.

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.refresh_thumbnail = False

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="Info" color="info" %}}

This option helps reduce the time required to save a presentation in PPTX format.

{{% /alert %}}

{{% alert title="Info" color="info" %}}

Aspose has developed a [free PowerPoint Splitter app](https://products.aspose.app/slides/splitter) using its own API. The app lets you split a presentation into multiple files by saving selected slides as new PPTX or PPT files.

{{% /alert %}}

## **FAQ**

**Is "fast save" (incremental save) supported so only changes are written?**

No. Saving creates the full target file each time; incremental "fast save" isn’t supported.

**Is it thread-safe to save the same Presentation instance from multiple threads?**

No. A [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) instance [isn’t thread-safe](/slides/python-net/multithreading/); save it from a single thread.

**What happens to hyperlinks and externally linked files when saving?**

[Hyperlinks](/slides/python-net/manage-hyperlinks/) are preserved. External linked files (e.g., videos via relative paths) aren’t copied automatically—ensure the referenced paths remain accessible.

**Can I set/save document metadata (Author, Title, Company, Date)?**

Yes. Standard [document properties](/slides/python-net/presentation-properties/) are supported and will be written to the file on save.
