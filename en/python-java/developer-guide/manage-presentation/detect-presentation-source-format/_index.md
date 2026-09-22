---
title: Determine the Original Presentation Format in Python via Java
linktitle: Source Format
type: docs
weight: 35
url: /python-java/detect-presentation-source-format/
keywords:
- source format
- detect presentation format
- PowerPoint
- OpenDocument
- presentation
- PPT
- PPTX
- Python
- Java
- Aspose.Slides
description: "Read the original format of a loaded presentation in Python via Java with Aspose.Slides for Python via Java, compare detection APIs, and handle files, streams, and legacy formats."
---

## **Overview**

After loading a presentation, call the [Presentation.getSourceFormat](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSourceFormat) method to determine its original format. Use it when subsequent processing depends on the format from which the current instance was loaded.

The source format is distinct from the [SaveFormat](https://reference.aspose.com/slides/python-java/aspose.slides/saveformat/) selected for an output file. Saving to another format does not change the source format of the existing instance.

The examples require Aspose.Slides for Python via Java and a compatible Java runtime. Each example starts the JVM if it is not already running.

## **Read the Source Format of a File**

This example requires an existing `sample.pptx` file. It loads the file and selects an application processing policy using [Presentation.getSourceFormat](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSourceFormat), rather than the filename. Change the input path to try other formats. The example prints the selected policy; replace the messages with your application logic.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SourceFormat

presentation = Presentation("sample.pptx")
try:
    source_format = presentation.getSourceFormat()
    if source_format in (SourceFormat.Ppt, SourceFormat.Pps, SourceFormat.Pot):
        print("Use the legacy PowerPoint processing policy.")
    elif source_format == SourceFormat.Pptx:
        print("Use the standard PPTX processing policy.")
    else:
        print(f"Use the general policy for source format {source_format}.")
finally:
    presentation.dispose()
```

## **Recognize the Supported Values**

The [SourceFormat](https://reference.aspose.com/slides/python-java/aspose.slides/sourceformat/) class defines integer constants that distinguish the following presentation formats. The extensions below are conventional extensions, not a reconstruction of the original filename.

| SourceFormat value | Extension | Format |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint 97–2003 presentation |
| `Pptx` | `.pptx` | Office Open XML presentation |
| `Pptm` | `.pptm` | Macro-enabled Office Open XML presentation |
| `Pps` | `.pps` | PowerPoint 97–2003 slide show |
| `Ppsx` | `.ppsx` | Office Open XML slide show |
| `Ppsm` | `.ppsm` | Macro-enabled Office Open XML slide show |
| `Pot` | `.pot` | PowerPoint 97–2003 template |
| `Potx` | `.potx` | Office Open XML template |
| `Potm` | `.potm` | Macro-enabled Office Open XML template |
| `Odp` | `.odp` | OpenDocument presentation |
| `Otp` | `.otp` | OpenDocument presentation template |
| `Fodp` | `.fodp` | Flat XML ODF presentation |
| `Xml` | `.xml` | PowerPoint XML presentation |

## **Read the Source Format of a Stream**

This example requires an existing `sample.pps` file. Reading its bytes into a memory stream models input received without a filename, such as a database value or an uploaded byte array. The [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) constructor receives only the stream. Python reads the file bytes, and JPype converts them to a Java byte array for the Java memory stream.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation

try:
    data = Path("sample.pps").read_bytes()
    java_bytes = jpype.JArray(jpype.JByte)(data)
    stream = jpype.JClass("java.io.ByteArrayInputStream")(java_bytes)
    try:
        presentation = Presentation(stream)
        try:
            print(f"Source format: {presentation.getSourceFormat()}")
        finally:
            presentation.dispose()
    finally:
        stream.close()
except OSError as exception:
    print(f"Cannot read the presentation: {exception}")
```

PPT, PPS, and POT use the same underlying binary format. When loading by file path, the extension can help distinguish a slide show or template. Without a filename, legacy PPS and POT content may be reported as `SourceFormat.Ppt`; the PPS example above prints the integer value of `SourceFormat.Ppt`.

If your application must preserve the distinction, keep the original filename or subtype metadata separately. An extension is a useful hint for these legacy subtypes, but should not be the only basis for identifying arbitrary presentation content.

## **Compare Detection Before and After Loading**

Use [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/python-java/aspose.slides/presentationfactory/#getPresentationInfo) and [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#getLoadFormat) when you need to inspect a file before loading its complete presentation object model. Use [Presentation.getSourceFormat](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSourceFormat) when the instance already exists.

This example requires `sample.pptx` and prints the integer values of `LoadFormat.Pptx` and `SourceFormat.Pptx`, respectively. In production, choose the API appropriate to your processing stage; an already loaded presentation does not need a second inspection solely to obtain its source format.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PresentationFactory

path = "sample.pptx"
information = PresentationFactory.getInstance().getPresentationInfo(path)
print(f"Before loading: {information.getLoadFormat()}")

presentation = Presentation(path)
try:
    print(f"After loading: {presentation.getSourceFormat()}")
finally:
    presentation.dispose()
```

The results use constants from different classes: [LoadFormat](https://reference.aspose.com/slides/python-java/aspose.slides/loadformat/) and [SourceFormat](https://reference.aspose.com/slides/python-java/aspose.slides/sourceformat/). Do not compare their numeric values or assume that every format has identical detection results. PowerPoint XML can be reported as `LoadFormat.Unknown` before loading and `SourceFormat.Xml` after loading.

## **Keep Source and Output Formats Separate**

This example requires `sample.pptx` and writes `converted.odp`. It prints the integer value of `SourceFormat.Pptx` both before and after saving the original instance. Only the new instance loaded from the ODP output reports `Odp`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    print(f"Before saving: {presentation.getSourceFormat()}")

    presentation.save("converted.odp", SaveFormat.Odp)
    print(f"After saving: {presentation.getSourceFormat()}")

    reopened = Presentation("converted.odp")
    try:
        print(f"Reopened output: {reopened.getSourceFormat()}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

A presentation created from scratch with `Presentation()` reports `SourceFormat.Pptx`. It has no input file: this is the default value for a newly created instance, not evidence that a PPTX file was loaded. Track whether your application created or loaded the instance separately if that distinction matters.

## **Map a Source Format to an Extension**

The following example requires `sample.pptx`. It maps every currently supported [SourceFormat](https://reference.aspose.com/slides/python-java/aspose.slides/sourceformat/) value to a conventional extension, without parsing the input filename. The fallback avoids silently assigning an extension to an unrecognized value.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SourceFormat

extensions = {
    SourceFormat.Ppt: ".ppt",
    SourceFormat.Pptx: ".pptx",
    SourceFormat.Pptm: ".pptm",
    SourceFormat.Pps: ".pps",
    SourceFormat.Ppsx: ".ppsx",
    SourceFormat.Ppsm: ".ppsm",
    SourceFormat.Pot: ".pot",
    SourceFormat.Potx: ".potx",
    SourceFormat.Potm: ".potm",
    SourceFormat.Odp: ".odp",
    SourceFormat.Otp: ".otp",
    SourceFormat.Fodp: ".fodp",
    SourceFormat.Xml: ".xml",
}

presentation = Presentation("sample.pptx")
try:
    extension = extensions.get(presentation.getSourceFormat())
    print(extension if extension is not None else "No extension mapping is available.")
finally:
    presentation.dispose()
```

This mapping does not convert a file or recover a legacy PPS/POT subtype lost during stream loading. For actual saving, select a [SaveFormat](https://reference.aspose.com/slides/python-java/aspose.slides/saveformat/) explicitly, or use the conversion shown in [Save Presentations in Their Original Format](/slides/python-java/save-presentation/#save-presentations-in-their-original-format).

## **Verify Formats by Saving and Reopening**

This self-contained example creates a presentation and writes three files in the working directory, overwriting files with the same names. It reopens each output both by path and through a memory stream. For PPTX and ODP, both routes report the saved format. For PPS, loading by path reports `Pps`, while loading the same bytes without a filename reports `Ppt`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    formats = [
        (SaveFormat.Pptx, "pptx"),
        (SaveFormat.Odp, "odp"),
        (SaveFormat.Pps, "pps"),
    ]

    for save_format, extension in formats:
        path = f"roundtrip.{extension}"
        presentation.save(path, save_format)

        from_file = Presentation(path)
        try:
            data = Path(path).read_bytes()
            java_bytes = jpype.JArray(jpype.JByte)(data)
            stream = jpype.JClass("java.io.ByteArrayInputStream")(java_bytes)
            try:
                from_stream = Presentation(stream)
                try:
                    print(f"{extension}: file={from_file.getSourceFormat()}, stream={from_stream.getSourceFormat()}")
                finally:
                    from_stream.dispose()
            finally:
                stream.close()
        finally:
            from_file.dispose()
except OSError as exception:
    print(f"Cannot read a saved presentation: {exception}")
finally:
    presentation.dispose()
```

The following table summarizes source-format identification for presentations with matching extensions. Names denote constants; the Python examples print their integer values:

| Saved format | SourceFormat from a file path | SourceFormat from a nameless stream |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` respectively | Same as file path |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` respectively | Same as file path |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` respectively | Same as file path |
| ODP, OTP | `Odp`, `Otp` respectively | Same as file path |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

PPS/POT content is identified as `Ppt` for nameless streams. The table describes format identification, not preservation of every presentation feature during conversion.

## **FAQ**

**Does saving to ODP change the source format of a presentation loaded from PPTX?**

No. The existing instance still reports `Pptx`. An instance loaded from the saved ODP file reports `Odp`.

**Can a stream always distinguish a legacy presentation, slide show, and template?**

No. PPT, PPS, and POT share the binary format. Keep filename or subtype metadata separately when that distinction is required.

**Which API should I use if the presentation is already loaded?**

Read [Presentation.getSourceFormat](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSourceFormat). Use [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/python-java/aspose.slides/presentationfactory/#getPresentationInfo) for inspection before loading.
