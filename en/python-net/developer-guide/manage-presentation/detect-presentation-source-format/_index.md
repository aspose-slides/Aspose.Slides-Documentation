---
title: Determine the Original Presentation Format in Python
linktitle: Source Format
type: docs
weight: 35
url: /python-net/detect-presentation-source-format/
keywords:
- source format
- detect presentation format
- PowerPoint
- OpenDocument
- presentation
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Read the original format of a loaded presentation in Python with Aspose.Slides for Python via .NET, compare detection APIs, and handle files, streams, and legacy formats."
---

## **Overview**

After loading a presentation, read the read-only [Presentation.source_format](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/source_format/) property to determine its original format. Use it when subsequent processing depends on the format from which the current instance was loaded.

The source format is distinct from the [SaveFormat](https://reference.aspose.com/slides/python-net/aspose.slides.export/saveformat/) selected for an output file. Saving to another format does not change the source format of the existing instance.

## **Read the Source Format of a File**

This example requires an existing `sample.pptx` file. It loads the file and selects an application processing policy using [Presentation.source_format](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/source_format/), rather than the filename. Change the input path to try other formats. The example prints the selected policy; replace the messages with your application logic.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    source_format = presentation.source_format
    if source_format in (slides.SourceFormat.PPT, slides.SourceFormat.PPS, slides.SourceFormat.POT):
        print("Use the legacy PowerPoint processing policy.")
    elif source_format == slides.SourceFormat.PPTX:
        print("Use the standard PPTX processing policy.")
    else:
        print(f"Use the general policy for {source_format.name}.")
```

## **Recognize the Supported Values**

The [SourceFormat](https://reference.aspose.com/slides/python-net/aspose.slides/sourceformat/) enumeration distinguishes the following presentation formats. The extensions below are conventional extensions, not a reconstruction of the original filename.

| SourceFormat value | Extension | Format |
| --- | --- | --- |
| `PPT` | `.ppt` | PowerPoint 97–2003 presentation |
| `PPTX` | `.pptx` | Office Open XML presentation |
| `PPTM` | `.pptm` | Macro-enabled Office Open XML presentation |
| `PPS` | `.pps` | PowerPoint 97–2003 slide show |
| `PPSX` | `.ppsx` | Office Open XML slide show |
| `PPSM` | `.ppsm` | Macro-enabled Office Open XML slide show |
| `POT` | `.pot` | PowerPoint 97–2003 template |
| `POTX` | `.potx` | Office Open XML template |
| `POTM` | `.potm` | Macro-enabled Office Open XML template |
| `ODP` | `.odp` | OpenDocument presentation |
| `OTP` | `.otp` | OpenDocument presentation template |
| `FODP` | `.fodp` | Flat XML ODF presentation |
| `XML` | `.xml` | PowerPoint XML presentation |

## **Read the Source Format of a Stream**

This example requires an existing `sample.pps` file. Reading its bytes into a memory stream models input received without a filename, such as a database value or an uploaded byte array. The [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) constructor receives only the stream.

```python
import io
import aspose.slides as slides

with open("sample.pps", "rb") as input_file:
    data = input_file.read()

with io.BytesIO(data) as stream:
    with slides.Presentation(stream) as presentation:
        print(f"Source format: {presentation.source_format.name}")
```

PPT, PPS, and POT use the same underlying binary format. When loading by file path, the extension can help distinguish a slide show or template. Without a filename, legacy PPS and POT content may be reported as `SourceFormat.PPT`; the PPS example above reports `PPT`.

If your application must preserve the distinction, keep the original filename or subtype metadata separately. An extension is a useful hint for these legacy subtypes, but should not be the only basis for identifying arbitrary presentation content.

## **Compare Detection Before and After Loading**

Use [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/get_presentation_info/) and [PresentationInfo.load_format](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/load_format/) when you need to inspect a file before loading its complete presentation object model. Use [Presentation.source_format](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/source_format/) when the instance already exists.

This example requires `sample.pptx` and prints `PPTX` for both checks. In production, choose the API appropriate to your processing stage; an already loaded presentation does not need a second inspection solely to obtain its source format.

```python
import aspose.slides as slides

path = "sample.pptx"
information = slides.PresentationFactory.instance.get_presentation_info(path)
print(f"Before loading: {information.load_format.name}")

with slides.Presentation(path) as presentation:
    print(f"After loading: {presentation.source_format.name}")
```

The results have different enumeration types: [LoadFormat](https://reference.aspose.com/slides/python-net/aspose.slides/loadformat/) and [SourceFormat](https://reference.aspose.com/slides/python-net/aspose.slides/sourceformat/). Do not compare them by casting their numeric values or assume that every format has identical detection results. In the save-and-reopen check described below, PowerPoint XML was reported as `LoadFormat.UNKNOWN` before loading and `SourceFormat.XML` after loading.

## **Keep Source and Output Formats Separate**

This example requires `sample.pptx` and writes `converted.odp`. It prints `PPTX` both before and after saving the original instance. Only the new instance loaded from the ODP output reports `ODP`.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    print(f"Before saving: {presentation.source_format.name}")

    presentation.save("converted.odp", slides.export.SaveFormat.ODP)
    print(f"After saving: {presentation.source_format.name}")

with slides.Presentation("converted.odp") as reopened:
    print(f"Reopened output: {reopened.source_format.name}")
```

A presentation created from scratch with `slides.Presentation()` reports `SourceFormat.PPTX`. It has no input file: this is the default value for a newly created instance, not evidence that a PPTX file was loaded. Track whether your application created or loaded the instance separately if that distinction matters.

## **Map a Source Format to an Extension**

The following example requires `sample.pptx`. It maps every currently supported [SourceFormat](https://reference.aspose.com/slides/python-net/aspose.slides/sourceformat/) value to a conventional extension, without parsing the input filename. The fallback avoids silently assigning an extension to an unrecognized value.

```python
import aspose.slides as slides

extensions = {
    slides.SourceFormat.PPT: ".ppt",
    slides.SourceFormat.PPTX: ".pptx",
    slides.SourceFormat.PPTM: ".pptm",
    slides.SourceFormat.PPS: ".pps",
    slides.SourceFormat.PPSX: ".ppsx",
    slides.SourceFormat.PPSM: ".ppsm",
    slides.SourceFormat.POT: ".pot",
    slides.SourceFormat.POTX: ".potx",
    slides.SourceFormat.POTM: ".potm",
    slides.SourceFormat.ODP: ".odp",
    slides.SourceFormat.OTP: ".otp",
    slides.SourceFormat.FODP: ".fodp",
    slides.SourceFormat.XML: ".xml",
}

with slides.Presentation("sample.pptx") as presentation:
    extension = extensions.get(presentation.source_format)
    print(extension if extension is not None else "No extension mapping is available.")
```

This mapping does not convert a file or recover a legacy PPS/POT subtype lost during stream loading. For actual saving, select a [SaveFormat](https://reference.aspose.com/slides/python-net/aspose.slides.export/saveformat/) explicitly, or use the conversion shown in [Save Presentations in Their Original Format](/slides/python-net/save-presentation/#save-presentations-in-their-original-format).

## **Verify Formats by Saving and Reopening**

This self-contained example creates a presentation and writes three files in the working directory, overwriting files with the same names. It reopens each output both by path and through a memory stream. For PPTX and ODP, both routes report the saved format. For PPS, loading by path reports `PPS`, while loading the same bytes without a filename reports `PPT`.

```python
import io
import aspose.slides as slides

formats = [slides.export.SaveFormat.PPTX, slides.export.SaveFormat.ODP, slides.export.SaveFormat.PPS]

with slides.Presentation() as presentation:
    for output_format in formats:
        path = f"roundtrip.{output_format.name.lower()}"
        presentation.save(path, output_format)

        with open(path, "rb") as input_file:
            data = input_file.read()

        with slides.Presentation(path) as from_file:
            with io.BytesIO(data) as stream:
                with slides.Presentation(stream) as from_stream:
                    print(f"{output_format.name}: file={from_file.source_format.name}, stream={from_stream.source_format.name}")
```

The same check with all the formats listed above produced these results for generated presentations with matching extensions:

| Saved format | SourceFormat from a file path | SourceFormat from a nameless stream |
| --- | --- | --- |
| PPT | `PPT` | `PPT` |
| PPTX, PPTM | `PPTX`, `PPTM` respectively | Same as file path |
| PPS | `PPS` | `PPT` |
| PPSX, PPSM | `PPSX`, `PPSM` respectively | Same as file path |
| POT | `POT` | `PPT` |
| POTX, POTM | `POTX`, `POTM` respectively | Same as file path |
| ODP, OTP | `ODP`, `OTP` respectively | Same as file path |
| FODP | `FODP` | `FODP` |
| PowerPoint XML | `XML` | `XML` |

In these checks, the only source-format normalization was PPS/POT to `PPT` for nameless streams. The table describes format identification, not preservation of every presentation feature during conversion.

## **FAQ**

**Does saving to ODP change the source format of a presentation loaded from PPTX?**

No. The existing instance still reports `PPTX`. An instance loaded from the saved ODP file reports `ODP`.

**Can a stream always distinguish a legacy presentation, slide show, and template?**

No. PPT, PPS, and POT share the binary format. Keep filename or subtype metadata separately when that distinction is required.

**Which API should I use if the presentation is already loaded?**

Read [Presentation.source_format](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/source_format/). Use [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/get_presentation_info/) for inspection before loading.
