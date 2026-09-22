---
title: Determine the Original Presentation Format in Java
linktitle: Source Format
type: docs
weight: 35
url: /java/detect-presentation-source-format/
keywords:
- source format
- detect presentation format
- PowerPoint
- OpenDocument
- presentation
- PPT
- PPTX
- Java
- Aspose.Slides
description: "Read the original format of a loaded presentation in Java with Aspose.Slides for Java, compare detection APIs, and handle files, streams, and legacy formats."
---

## **Overview**

After loading a presentation, call the [Presentation.getSourceFormat](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSourceFormat--) method to determine its original format. The method is also available through [IPresentation.getSourceFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getSourceFormat--). Use it when subsequent processing depends on the format from which the current instance was loaded.

The source format is distinct from the [SaveFormat](https://reference.aspose.com/slides/java/com.aspose.slides/saveformat/) selected for an output file. Saving to another format does not change the source format of the existing instance.

## **Read the Source Format of a File**

This example requires an existing `sample.pptx` file. It loads the file and selects an application processing policy using [Presentation.getSourceFormat](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSourceFormat--), rather than the filename. Change the input path to try other formats. The example prints the selected policy; replace the messages with your application logic.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SourceFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    switch (presentation.getSourceFormat()) {
        case SourceFormat.Ppt:
        case SourceFormat.Pps:
        case SourceFormat.Pot:
            System.out.println("Use the legacy PowerPoint processing policy.");
            break;
        case SourceFormat.Pptx:
            System.out.println("Use the standard PPTX processing policy.");
            break;
        default:
            System.out.println("Use the general policy for source format " + presentation.getSourceFormat() + ".");
            break;
    }
} finally {
    presentation.dispose();
}
```

## **Recognize the Supported Values**

The [SourceFormat](https://reference.aspose.com/slides/java/com.aspose.slides/sourceformat/) class defines integer constants that distinguish the following presentation formats. The extensions below are conventional extensions, not a reconstruction of the original filename.

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

This example requires an existing `sample.pps` file. Reading its bytes into a memory stream models input received without a filename, such as a database value or an uploaded byte array. The [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) constructor receives only the stream.

```java
import com.aspose.slides.Presentation;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

try {
    byte[] bytes = Files.readAllBytes(Paths.get("sample.pps"));
    try (ByteArrayInputStream stream = new ByteArrayInputStream(bytes)) {
        Presentation presentation = new Presentation(stream);
        try {
            System.out.println("Source format: " + presentation.getSourceFormat());
        } finally {
            presentation.dispose();
        }
    }
} catch (IOException exception) {
    System.err.println("Cannot read the presentation: " + exception.getMessage());
}
```

PPT, PPS, and POT use the same underlying binary format. When loading by file path, the extension can help distinguish a slide show or template. Without a filename, legacy PPS and POT content may be reported as `SourceFormat.Ppt`; the PPS example above prints the integer value of `SourceFormat.Ppt`.

If your application must preserve the distinction, keep the original filename or subtype metadata separately. An extension is a useful hint for these legacy subtypes, but should not be the only basis for identifying arbitrary presentation content.

## **Compare Detection Before and After Loading**

Use [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) and [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationinfo/#getLoadFormat--) when you need to inspect a file before loading its complete presentation object model. Use [Presentation.getSourceFormat](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSourceFormat--) when the instance already exists.

This example requires `sample.pptx` and prints the integer values of `LoadFormat.Pptx` and `SourceFormat.Pptx`, respectively. In production, choose the API appropriate to your processing stage; an already loaded presentation does not need a second inspection solely to obtain its source format.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.PresentationFactory;

String path = "sample.pptx";
IPresentationInfo information = PresentationFactory.getInstance().getPresentationInfo(path);
System.out.println("Before loading: " + information.getLoadFormat());

Presentation presentation = new Presentation(path);
try {
    System.out.println("After loading: " + presentation.getSourceFormat());
} finally {
    presentation.dispose();
}
```

The results use constants from different classes: [LoadFormat](https://reference.aspose.com/slides/java/com.aspose.slides/loadformat/) and [SourceFormat](https://reference.aspose.com/slides/java/com.aspose.slides/sourceformat/). Do not compare their numeric values or assume that every format has identical detection results. PowerPoint XML can be reported as `LoadFormat.Unknown` before loading and `SourceFormat.Xml` after loading.

## **Keep Source and Output Formats Separate**

This example requires `sample.pptx` and writes `converted.odp`. It prints the integer value of `SourceFormat.Pptx` both before and after saving the original instance. Only the new instance loaded from the ODP output reports `Odp`.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    System.out.println("Before saving: " + presentation.getSourceFormat());

    presentation.save("converted.odp", SaveFormat.Odp);
    System.out.println("After saving: " + presentation.getSourceFormat());

    Presentation reopened = new Presentation("converted.odp");
    try {
        System.out.println("Reopened output: " + reopened.getSourceFormat());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

A presentation created from scratch with `new Presentation()` reports `SourceFormat.Pptx`. It has no input file: this is the default value for a newly created instance, not evidence that a PPTX file was loaded. Track whether your application created or loaded the instance separately if that distinction matters.

## **Map a Source Format to an Extension**

The following example requires `sample.pptx`. It maps every currently supported [SourceFormat](https://reference.aspose.com/slides/java/com.aspose.slides/sourceformat/) value to a conventional extension, without parsing the input filename. The fallback avoids silently assigning an extension to an unrecognized value.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SourceFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    String extension;
    switch (presentation.getSourceFormat()) {
        case SourceFormat.Ppt:
            extension = ".ppt";
            break;
        case SourceFormat.Pptx:
            extension = ".pptx";
            break;
        case SourceFormat.Pptm:
            extension = ".pptm";
            break;
        case SourceFormat.Pps:
            extension = ".pps";
            break;
        case SourceFormat.Ppsx:
            extension = ".ppsx";
            break;
        case SourceFormat.Ppsm:
            extension = ".ppsm";
            break;
        case SourceFormat.Pot:
            extension = ".pot";
            break;
        case SourceFormat.Potx:
            extension = ".potx";
            break;
        case SourceFormat.Potm:
            extension = ".potm";
            break;
        case SourceFormat.Odp:
            extension = ".odp";
            break;
        case SourceFormat.Otp:
            extension = ".otp";
            break;
        case SourceFormat.Fodp:
            extension = ".fodp";
            break;
        case SourceFormat.Xml:
            extension = ".xml";
            break;
        default:
            extension = null;
            break;
    }

    System.out.println(extension != null ? extension : "No extension mapping is available.");
} finally {
    presentation.dispose();
}
```

This mapping does not convert a file or recover a legacy PPS/POT subtype lost during stream loading. For actual saving, select a [SaveFormat](https://reference.aspose.com/slides/java/com.aspose.slides/saveformat/) explicitly, or use the conversion shown in [Save Presentations in Their Original Format](/slides/java/save-presentation/#save-presentations-in-their-original-format).

## **Verify Formats by Saving and Reopening**

This self-contained example creates a presentation and writes three files in the working directory, overwriting files with the same names. It reopens each output both by path and through a memory stream. For PPTX and ODP, both routes report the saved format. For PPS, loading by path reports `Pps`, while loading the same bytes without a filename reports `Ppt`.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    int[] formats = { SaveFormat.Pptx, SaveFormat.Odp, SaveFormat.Pps };
    String[] extensions = { "pptx", "odp", "pps" };

    for (int i = 0; i < formats.length; i++) {
        String path = "roundtrip." + extensions[i];
        presentation.save(path, formats[i]);

        Presentation fromFile = new Presentation(path);
        try {
            byte[] bytes = Files.readAllBytes(Paths.get(path));
            try (ByteArrayInputStream stream = new ByteArrayInputStream(bytes)) {
                Presentation fromStream = new Presentation(stream);
                try {
                    System.out.println(extensions[i] + ": file=" + fromFile.getSourceFormat() + ", stream=" + fromStream.getSourceFormat());
                } finally {
                    fromStream.dispose();
                }
            }
        } finally {
            fromFile.dispose();
        }
    }
} catch (IOException exception) {
    System.err.println("Cannot read a saved presentation: " + exception.getMessage());
} finally {
    presentation.dispose();
}
```

The following table summarizes source-format identification for presentations with matching extensions. Names denote constants; the Java examples print their integer values:

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

Read [Presentation.getSourceFormat](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSourceFormat--). Use [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) for inspection before loading.
