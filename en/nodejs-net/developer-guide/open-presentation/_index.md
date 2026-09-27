---
title: Open Presentations in Node.js via .NET
linktitle: Open Presentation
type: docs
weight: 20
url: /nodejs-net/open-presentation/
keywords:
- open presentation
- open PowerPoint
- open PPTX
- open PPT
- open ODP
- load presentation
- presentation from buffer
- slide count
- convert presentation
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Open PPTX, PPT, and ODP presentations in JavaScript with Aspose.Slides for Node.js via .NET: load from a file path or a Buffer, read the slide count, and save in another format."
---

## **Overview**

Aspose.Slides for Node.js via .NET opens PowerPoint and OpenDocument presentations, such as PPTX, PPT, and ODP files, from a file path or from a Node.js `Buffer`. This article shows both ways, reads the number of slides, and saves an opened presentation in another format.

The examples expect a presentation named `sample.pptx` in the project folder that you set up in [Installation](/slides/nodejs-net/installation/). Any PowerPoint presentation will do. Save each example as a `.js` file in the project folder and run it from that folder with `node`.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET has no API reference of its own. It mirrors the Aspose.Slides for .NET API with camelCase names, so the API links in this article lead to the matching classes and members in the [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/net/).
{{% /alert %}}

## **Open a Presentation from a File**

To open a presentation, pass its path to the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) constructor. Aspose.Slides detects the format from the file content rather than from the extension, so the same code opens PPTX, PPT, and ODP files. A relative path is resolved against the current working directory, which is the project folder when you run the script from there.

```javascript
const { Presentation } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    console.log("Slide count: " + presentation.slides.count);
} finally {
    presentation.dispose();
}
```

The script prints the number of slides in `sample.pptx`, for example `Slide count: 9`. The `count` property of the [slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) collection includes hidden slides. Call `dispose` in a `finally` block, as shown, so that the .NET resources behind the presentation are released even if your code fails.

## **Open a Presentation from a Buffer**

When a presentation comes from a database, an HTTP upload, or another source that gives you bytes rather than a file path, pass a Node.js `Buffer` as the second constructor argument and `null` as the first. The following example reads `sample.pptx` into a buffer to stand in for such a source:

```javascript
const fs = require("fs");
const { Presentation } = require("aspose.slides.via.net");

const presentationData = fs.readFileSync("sample.pptx");

const presentation = new Presentation(null, presentationData);
try {
    console.log("Slide count: " + presentation.slides.count);
} finally {
    presentation.dispose();
}
```

The script prints the same slide count as the previous example. The second argument must be a `Buffer`. For any other type, such as a `Uint8Array`, the constructor does not report an error; it creates a new presentation with one empty slide instead. Convert other binary types with `Buffer.from` first.

## **Save a Presentation in Another Format**

To convert a presentation to another presentation format, open it and save it with a different [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/) value. The following example prints the format that Aspose.Slides detected, which the [sourceFormat](https://reference.aspose.com/slides/net/aspose.slides/presentation/sourceformat/) property returns, and saves the presentation as an OpenDocument presentation:

```javascript
const { Presentation, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    console.log("Source format: " + presentation.sourceFormat);
    presentation.save("sample.odp", SaveFormat.Odp);
} finally {
    presentation.dispose();
}
```

The script prints `Source format: Pptx` and writes `sample.odp`, which contains the same slides. `sourceFormat` returns `Ppt`, `Pptx`, or `Odp`. To save as PDF or as images instead, see [Convert PowerPoint to PDF](/slides/nodejs-net/convert-powerpoint-to-pdf/) and [Convert Slides to Images](/slides/nodejs-net/convert-slide/).

## **FAQ**

**How do I open a password-protected presentation?**

Create a [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) object, set its [password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/) property, and pass the object as the third constructor argument: `new Presentation("protected.pptx", null, loadOptions)`. Without the correct password, the constructor throws an error.

**Why does the constructor throw an `Error` with an empty message?**

When the `Presentation` constructor fails in .NET, for example because the file is missing, is not a presentation, or needs a different password, JavaScript receives an `Error` whose message is empty. Before you open a file, check that it exists relative to the working directory, for example with `fs.existsSync`.

**Which formats can I open?**

PowerPoint and OpenDocument presentation formats, including PPT, PPTX, PPS, POT, POTX, PPTM, ODP, OTP, and FODP.
