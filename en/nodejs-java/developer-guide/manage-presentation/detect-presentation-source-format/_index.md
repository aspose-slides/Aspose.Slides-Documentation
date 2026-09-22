---
title: Determine the Original Presentation Format in Node.js
linktitle: Source Format
type: docs
weight: 35
url: /nodejs-java/detect-presentation-source-format/
keywords:
- source format
- detect presentation format
- PowerPoint
- OpenDocument
- presentation
- PPT
- PPTX
- Node.js
- JavaScript
- Aspose.Slides
description: "Read the original format of a loaded presentation in Node.js with Aspose.Slides for Node.js via Java, compare detection APIs, and handle files, streams, and legacy formats."
---

## **Overview**

After loading a presentation, call the [Presentation.getSourceFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSourceFormat) method to determine its original format. Use it when subsequent processing depends on the format from which the current instance was loaded.

The source format is distinct from the [SaveFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveformat/) selected for an output file. Saving to another format does not change the source format of the existing instance.

## **Read the Source Format of a File**

This example requires an existing `sample.pptx` file. It loads the file and selects an application processing policy using [Presentation.getSourceFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSourceFormat), rather than the filename. Change the input path to try other formats. The example prints the selected policy; replace the messages with your application logic.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    switch (presentation.getSourceFormat()) {
        case aspose.SourceFormat.Ppt:
        case aspose.SourceFormat.Pps:
        case aspose.SourceFormat.Pot:
            console.log("Use the legacy PowerPoint processing policy.");
            break;
        case aspose.SourceFormat.Pptx:
            console.log("Use the standard PPTX processing policy.");
            break;
        default:
            console.log("Use the general policy for source format " + presentation.getSourceFormat() + ".");
            break;
    }
} finally {
    presentation.dispose();
}
```

## **Recognize the Supported Values**

The [SourceFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sourceformat/) class defines integer constants that distinguish the following presentation formats. The extensions below are conventional extensions, not a reconstruction of the original filename.

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

This example requires an existing `sample.pps` file. Reading its bytes into a memory stream models input received without a filename, such as a database value or an uploaded byte array. The [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) constructor receives only the stream.

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const buffer = fs.readFileSync("sample.pps");
const bytes = java.newArray("byte", Array.from(buffer));
const stream = java.newInstanceSync("java.io.ByteArrayInputStream", bytes);
try {
    const presentation = new aspose.Presentation(stream);
    try {
        console.log("Source format: " + presentation.getSourceFormat());
    } finally {
        presentation.dispose();
    }
} finally {
    stream.close();
}
```

PPT, PPS, and POT use the same underlying binary format. When loading by file path, the extension can help distinguish a slide show or template. Without a filename, legacy PPS and POT content may be reported as `SourceFormat.Ppt`; the PPS example above prints the integer value of `SourceFormat.Ppt`.

If your application must preserve the distinction, keep the original filename or subtype metadata separately. An extension is a useful hint for these legacy subtypes, but should not be the only basis for identifying arbitrary presentation content.

## **Compare Detection Before and After Loading**

Use [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) and [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationinfo/#getLoadFormat) when you need to inspect a file before loading its complete presentation object model. Use [Presentation.getSourceFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSourceFormat) when the instance already exists.

This example requires `sample.pptx` and prints the integer values of `LoadFormat.Pptx` and `SourceFormat.Pptx`, respectively. In production, choose the API appropriate to your processing stage; an already loaded presentation does not need a second inspection solely to obtain its source format.

```javascript
const aspose = require("aspose.slides.via.java");

const path = "sample.pptx";
const information = aspose.PresentationFactory.getInstance().getPresentationInfo(path);
console.log("Before loading: " + information.getLoadFormat());

const presentation = new aspose.Presentation(path);
try {
    console.log("After loading: " + presentation.getSourceFormat());
} finally {
    presentation.dispose();
}
```

The results use constants from different classes: [LoadFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadformat/) and [SourceFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sourceformat/). Do not compare their numeric values or assume that every format has identical detection results. PowerPoint XML can be reported as `LoadFormat.Unknown` before loading and `SourceFormat.Xml` after loading.

## **Keep Source and Output Formats Separate**

This example requires `sample.pptx` and writes `converted.odp`. It prints the integer value of `SourceFormat.Pptx` both before and after saving the original instance. Only the new instance loaded from the ODP output reports `Odp`.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    console.log("Before saving: " + presentation.getSourceFormat());

    presentation.save("converted.odp", aspose.SaveFormat.Odp);
    console.log("After saving: " + presentation.getSourceFormat());

    const reopened = new aspose.Presentation("converted.odp");
    try {
        console.log("Reopened output: " + reopened.getSourceFormat());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

A presentation created from scratch with `new Presentation()` reports `SourceFormat.Pptx`. It has no input file: this is the default value for a newly created instance, not evidence that a PPTX file was loaded. Track whether your application created or loaded the instance separately if that distinction matters.

## **Map a Source Format to an Extension**

The following example requires `sample.pptx`. It maps every currently supported [SourceFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sourceformat/) value to a conventional extension, without parsing the input filename. The fallback avoids silently assigning an extension to an unrecognized value.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    let extension;
    switch (presentation.getSourceFormat()) {
        case aspose.SourceFormat.Ppt:
            extension = ".ppt";
            break;
        case aspose.SourceFormat.Pptx:
            extension = ".pptx";
            break;
        case aspose.SourceFormat.Pptm:
            extension = ".pptm";
            break;
        case aspose.SourceFormat.Pps:
            extension = ".pps";
            break;
        case aspose.SourceFormat.Ppsx:
            extension = ".ppsx";
            break;
        case aspose.SourceFormat.Ppsm:
            extension = ".ppsm";
            break;
        case aspose.SourceFormat.Pot:
            extension = ".pot";
            break;
        case aspose.SourceFormat.Potx:
            extension = ".potx";
            break;
        case aspose.SourceFormat.Potm:
            extension = ".potm";
            break;
        case aspose.SourceFormat.Odp:
            extension = ".odp";
            break;
        case aspose.SourceFormat.Otp:
            extension = ".otp";
            break;
        case aspose.SourceFormat.Fodp:
            extension = ".fodp";
            break;
        case aspose.SourceFormat.Xml:
            extension = ".xml";
            break;
        default:
            extension = null;
            break;
    }

    console.log(extension != null ? extension : "No extension mapping is available.");
} finally {
    presentation.dispose();
}
```

This mapping does not convert a file or recover a legacy PPS/POT subtype lost during stream loading. For actual saving, select a [SaveFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveformat/) explicitly, or use the conversion shown in [Save Presentations in Their Original Format](/slides/nodejs-java/save-presentation/#save-presentations-in-their-original-format).

## **Verify Formats by Saving and Reopening**

This self-contained example creates a presentation and writes three files in the working directory, overwriting files with the same names. It reopens each output both by path and through a memory stream. For PPTX and ODP, both routes report the saved format. For PPS, loading by path reports `Pps`, while loading the same bytes without a filename reports `Ppt`.

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const presentation = new aspose.Presentation();
try {
    const formats = [aspose.SaveFormat.Pptx, aspose.SaveFormat.Odp, aspose.SaveFormat.Pps];
    const extensions = ["pptx", "odp", "pps"];

    for (let i = 0; i < formats.length; i++) {
        const path = "roundtrip." + extensions[i];
        presentation.save(path, formats[i]);

        const fromFile = new aspose.Presentation(path);
        try {
            const buffer = fs.readFileSync(path);
            const bytes = java.newArray("byte", Array.from(buffer));
            const stream = java.newInstanceSync("java.io.ByteArrayInputStream", bytes);
            try {
                const fromStream = new aspose.Presentation(stream);
                try {
                    console.log(extensions[i] + ": file=" + fromFile.getSourceFormat() + ", stream=" + fromStream.getSourceFormat());
                } finally {
                    fromStream.dispose();
                }
            } finally {
                stream.close();
            }
        } finally {
            fromFile.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

The following table summarizes source-format identification for presentations with matching extensions. Names denote constants; the JavaScript examples print their integer values:

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

Read [Presentation.getSourceFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSourceFormat). Use [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) for inspection before loading.
