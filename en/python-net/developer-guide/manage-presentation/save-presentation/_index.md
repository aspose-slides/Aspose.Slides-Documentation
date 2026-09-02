---
title: Save Presentations in Python
linktitle: Save Presentation
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
description: "Save PowerPoint and OpenDocument presentations to files or streams in Python with Aspose.Slides, and configure PPTX output options."
---

## **Overview**

After you create a presentation or [open an existing one](/slides/python-net/open-presentation/), use the [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/ipresentation/save/) method to write the result. Aspose.Slides for Python via .NET can save a presentation to a file or stream in PowerPoint, OpenDocument, PDF, and other formats. The following sections cover the standard save operations and the options available for PPTX output.

## **Save Presentations to Files**

To save a presentation to a file, pass the output path and a [SaveFormat](https://reference.aspose.com/slides/python-net/aspose.slides.export/saveformat/) value to the [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/ipresentation/save/) method. The format value determines the type of file that Aspose.Slides creates.

The following example creates a presentation and saves it as a PPTX file:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Add or modify presentation content here.

    presentation.save("Output.pptx", slides.export.SaveFormat.PPTX)
```

## **Save Presentations in Their Original Format**

In a batch-processing application, the input format may not be known in advance. After loading a file, read its original format from the [Presentation.source_format](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/source_format/) property. Pass the resulting [SourceFormat](https://reference.aspose.com/slides/python-net/aspose.slides/sourceformat/) value to [SlideUtil.to_save_format](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/to_save_format/) to obtain the corresponding [SaveFormat](https://reference.aspose.com/slides/python-net/aspose.slides.export/saveformat/) value, and then use [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/ipresentation/save/) to write the modified presentation.

The following complete example processes every file in an input directory, updates its title, and saves it to an output directory in the format from which it was loaded:

```py
from pathlib import Path

import aspose.slides as slides
from aspose.slides.util import SlideUtil

input_directory = Path("Input")
output_directory = Path("Output")

output_directory.mkdir(exist_ok=True)

for input_path in input_directory.iterdir():
    if not input_path.is_file():
        continue

    try:
        with slides.Presentation(str(input_path)) as presentation:
            source_format = presentation.source_format
            save_format = SlideUtil.to_save_format(source_format)

            presentation.document_properties.title = "Processed by the batch application"

            output_path = output_directory / input_path.name
            presentation.save(str(output_path), save_format)
    except Exception as exception:
        print(f"Cannot process '{input_path}': {exception}")
```

[SlideUtil.to_save_format](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/to_save_format/) maps PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP, and PowerPoint XML to their corresponding presentation save formats. It maps presentation source formats only; it is not intended to select export formats such as PDF, HTML, TIFF, or images. Passing an unsupported or invalid [SourceFormat](https://reference.aspose.com/slides/python-net/aspose.slides/sourceformat/) value raises an exception.

Legacy PPT, PPS, and POT files use the same binary container. When such a presentation is loaded from a stream without a file extension, a PPS or POT file may therefore be identified as PPT. If preserving these legacy subtypes is required, retain the original filename or format metadata separately and use it when choosing the output filename and format.

## **Save Presentations to Streams**

To write a presentation without relying on a final file path, pass a writable [BinaryIO](https://docs.python.org/3/library/typing.html#typing.BinaryIO) stream and a [SaveFormat](https://reference.aspose.com/slides/python-net/aspose.slides.export/saveformat/) value to the [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/ipresentation/save/) method. This approach is useful when the output must be returned from a web service, stored in a database, or processed in memory.

The following example saves a new presentation to a file stream:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("Output.pptx", "wb") as output_stream:
        presentation.save(output_stream, slides.export.SaveFormat.PPTX)
```

## **Save Presentations with a Predefined View Type**

You can specify the view in which PowerPoint initially opens a saved presentation. Set the [ViewProperties.last_view](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/last_view/) property to a [ViewType](https://reference.aspose.com/slides/python-net/aspose.slides/viewtype/) value before saving.

The following example configures Slide Master view as the initial view:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("SlideMasterView.pptx", slides.export.SaveFormat.PPTX)
```

## **Save Presentations in the Strict Office Open XML Format**

To create a PPTX file that conforms to the Strict profile of Office Open XML, create a [PptxOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/) instance and set its [conformance](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/conformance/) property to `Conformance.ISO_29500_2008_STRICT`. Then pass the options to the [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/ipresentation/save/) method.

```py
import aspose.slides as slides

options = slides.export.PptxOptions()
options.conformance = slides.export.Conformance.ISO_29500_2008_STRICT

with slides.Presentation() as presentation:
    presentation.save("StrictOfficeOpenXml.pptx", slides.export.SaveFormat.PPTX, options)
```

## **Save Presentations in Office Open XML Format in Zip64 Mode**

A standard ZIP archive limits the compressed and uncompressed size of each entry, the total archive size, and the number of entries. Because a PPTX file is a ZIP archive, a very large presentation can exceed those limits. ZIP64 extensions raise the applicable size and entry-count limits.

Use the [PptxOptions.zip_64_mode](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/zip_64_mode/) property to control whether Aspose.Slides writes ZIP64 extensions:

- `IF_NECESSARY` uses ZIP64 only when the presentation exceeds standard ZIP limits. This is the default mode.
- `NEVER` disables ZIP64 extensions.
- `ALWAYS` always writes ZIP64 extensions.

The following example always enables ZIP64 extensions for the output presentation:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

    presentation.save("OutputZip64.pptx", slides.export.SaveFormat.PPTX, options)
```

{{% alert color="warning" title="Warning" %}}

If `Zip64Mode.NEVER` is used and the presentation cannot fit within standard ZIP limits, the save operation raises a [PptxException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxexception/).

{{% /alert %}}

## **Save Presentations in Office Open XML Format with Compression Levels**

For PPTX output, you can balance saving speed against file size by setting the [PptxOptions.compression_level](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/compression_level/) property. The [CompressionLevel](https://reference.aspose.com/slides/python-net/aspose.slides.export/compressionlevel/) enumeration provides these values:

- `NONE` stores data without compression.
- `LEVEL1` provides the fastest compression and the largest compressed output.
- `LEVEL2` through `LEVEL5` progressively favor smaller output over saving speed.
- `LEVEL6` balances saving speed and file size. This is the default level.
- `LEVEL7` and `LEVEL8` further favor smaller output over saving speed.
- `LEVEL9` provides the strongest compression and requires the most processing time.

The following example saves a presentation without compression:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.compression_level = slides.export.CompressionLevel.NONE

    presentation.save("OutputNoCompression.pptx", slides.export.SaveFormat.PPTX, options)
```

The following example uses the maximum compression level:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.compression_level = slides.export.CompressionLevel.LEVEL9

    presentation.save("OutputMaximumCompression.pptx", slides.export.SaveFormat.PPTX, options)
```

## **Save Presentations without Refreshing the Thumbnail**

When a presentation is saved as PPTX, the [PptxOptions.refresh_thumbnail](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/) property controls its document thumbnail:

- `True` regenerates the thumbnail during the save operation. This is the default value.
- `False` preserves the existing thumbnail. If the presentation has no thumbnail, Aspose.Slides does not generate one.

The following example saves a presentation without refreshing its thumbnail:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.refresh_thumbnail = False

    presentation.save("Output.pptx", slides.export.SaveFormat.PPTX, options)
```

{{% alert color="info" title="Note" %}}

Disabling thumbnail refresh can reduce the time required to save a PPTX file.

{{% /alert %}}

{{% alert color="info" title="Note" %}}

Aspose provides a free [PowerPoint Splitter](https://products.aspose.app/slides/splitter) built with the Aspose.Slides API. It saves selected slides from a presentation as separate PPT or PPTX files.

{{% /alert %}}

## **FAQ**

**Does Aspose.Slides support incremental or “fast save”?**

No. Each save operation writes a complete output file rather than updating only the changed parts.

**Can multiple threads save the same Presentation instance?**

No. A [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) instance [is not thread-safe](/slides/python-net/multithreading/). Access and save each instance from only one thread at a time.

**What happens to hyperlinks and externally linked files when I save a presentation?**

[Hyperlinks](/slides/python-net/manage-hyperlinks/) remain in the presentation. Aspose.Slides does not copy externally linked files, so the saved presentation must still be able to access their locations.

**Can I save document metadata such as the author, title, company, and creation date?**

Yes. Set the appropriate [document properties](/slides/python-net/presentation-properties/) before saving, and Aspose.Slides writes them to the output file.
