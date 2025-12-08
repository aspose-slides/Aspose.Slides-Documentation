---
title: Save Presentations in JavaScript
linktitle: Save Presentation
type: docs
weight: 80
url: /nodejs-java/save-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Discover how to save presentations using Aspose.Slides for Node.js via Java—export to PowerPoint or OpenDocument while retaining layouts, fonts and effects."
---

## **Overview**

[Open Presentations in JavaScript](/slides/nodejs-java/open-presentation/) described how to use the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) class to open a presentation. This article explains how to create and save presentations. The [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) class contains a presentation’s contents. Whether you’re creating a presentation from scratch or modifying an existing one, you’ll want to save it when you’re finished. With Aspose.Slides for Node.js, you can save to a **file** or **stream**. This article explains the different ways to save a presentation.

## **Save Presentations to Files**

Save a presentation to a file by calling the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) class’s `save` method. Pass the file name and save format to the method. The following example show how to save a presentation with Aspose.Slides.

```js
// Instantiate the Presentation class that represents a presentation file.
let presentation = new aspose.slides.Presentation();
try {
    // Do some work here...

    // Save the presentation to a file.
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Save Presentations to Streams**

You can save a presentation to a stream by passing an output stream to the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) class’s `save` method. A presentation can be written to many stream types. In the example below, we create a new presentation and save it to a file stream.

```js
// Instantiate the Presentation class that represents a presentation file.
let presentation = new aspose.slides.Presentation();
try {
    let fileStream = java.newInstanceSync("java.io.FileOutputStream", "Output.pptx");
    try {
        // Save the presentation to the stream.
        presentation.save(fileStream, aspose.slides.SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Save Presentations with a Predefined View Type**

Aspose.Slides lets you set the initial view that PowerPoint uses when the generated presentation opens through the [ViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/) class. Use the [setLastView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setLastView) method with a value from the [ViewType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewtype/) enumeration.

```js
let presentation = new aspose.slides.Presentation();
try {
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Save Presentations in the Strict Office Open XML Format**

Aspose.Slides lets you save a presentation in the Strict Office Open XML format. Use the [PptxOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pptxoptions/) class and set its conformance property when saving. If you set [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/nodejs-java/aspose.slides/conformance/#Iso29500_2008_Strict), the output file is saved in the Strict Office Open XML format.

The example below creates a presentation and saves it in the Strict Office Open XML format.

```js
let options = new aspose.slides.PptxOptions();
options.setConformance(aspose.slides.Conformance.Iso29500_2008_Strict);

// Instantiate the Presentation class that represents a presentation file.
let presentation = new aspose.slides.Presentation();
try {
    // Save the presentation in the Strict Office Open XML format.
    presentation.save("StrictOfficeOpenXml.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Save Presentations in Office Open XML Format in Zip64 Mode**

An Office Open XML file is a ZIP archive that imposes 4 GB (2^32 bytes) limits on the uncompressed size of any file, the compressed size of any file, and the total size of the archive, and it also limits the archive to 65,535 (2^16-1) files. ZIP64 format extensions raise these limits to 2^64.

The [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pptxoptions/#getZip64Mode) method lets you choose when to use ZIP64 format extensions when saving an Office Open XML file.

This method can be used with the following modes:

- [IfNecessary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zip64mode/#IfNecessary) uses ZIP64 format extensions only if the presentation exceeds the limitations above. This is the default mode.
- [Never](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zip64mode/#Never) never uses ZIP64 format extensions.
- [Always](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zip64mode/#Always) always uses ZIP64 format extensions.

The following code demonstrates how to save a presentation as PPTX with ZIP64 format extensions enabled:

```js
let pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setZip64Mode(aspose.slides.Zip64Mode.Always);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("OutputZip64.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}}

When you save with [Zip64Mode.Never](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zip64mode/#Never), a [PptxException](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pptxexception/) is thrown if the presentation cannot be saved in ZIP32 format.

{{% /alert %}}

## **Save Presentations without Refreshing the Thumbnail**

The [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail) method controls thumbnail generation when saving a presentation to PPTX:

- If set to `true`, the thumbnail is refreshed during save. This is the default.
- If set to `false`, the current thumbnail is preserved. If the presentation has no thumbnail, none is generated.

In the code below, the presentation is saved to PPTX without refreshing its thumbnail.

```js
let pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setRefreshThumbnail(false);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
}
finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}

This option helps reduce the time required to save a presentation in PPTX format.

{{% /alert %}}

## **Save Progress Updates in Percentage**

Save-progress reporting is configured via the [setProgressCallback](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setProgressCallback) method on [SaveOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/) and its subclasses. Provide a Java proxy that implements the [IProgressCallback](https://reference.aspose.com/slides/java/com.aspose.slides/iprogresscallback/) interface; during export, the callback receives periodic percentage updates.

The following code snippets show how to use `IProgressCallback`.

```javascript
const ExportProgressHandler = java.newProxy("com.aspose.slides.IProgressCallback", {
    reporting: function(progressValue) {
        // Use the progress percentage value here.
        const progress = Math.floor(progressValue);
        console.log(`${progress}% of the file has been converted.`);
    }
});

let saveOptions = new aspose.slides.PdfOptions();
saveOptions.setProgressCallback(ExportProgressHandler);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", aspose.slides.SaveFormat.Pdf, saveOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}

Aspose has developed a [free PowerPoint Splitter app](https://products.aspose.app/slides/splitter) using its own API. The app lets you split a presentation into multiple files by saving selected slides as new PPTX or PPT files.

{{% /alert %}}

## **FAQ**

**Is "fast save" (incremental save) supported so only changes are written?**

No. Saving creates the full target file each time; incremental "fast save" isn’t supported.

**Is it thread-safe to save the same Presentation instance from multiple threads?**

No. A [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) instance [isn’t thread-safe](/slides/nodejs-java/multithreading/); save it from a single thread.

**What happens to hyperlinks and externally linked files when saving?**

[Hyperlinks](/slides/nodejs-java/manage-hyperlinks/) are preserved. External linked files (e.g., videos via relative paths) aren’t copied automatically—ensure the referenced paths remain accessible.

**Can I set/save document metadata (Author, Title, Company, Date)?**

Yes. Standard [document properties](/slides/nodejs-java/presentation-properties/) are supported and will be written to the file on save.
