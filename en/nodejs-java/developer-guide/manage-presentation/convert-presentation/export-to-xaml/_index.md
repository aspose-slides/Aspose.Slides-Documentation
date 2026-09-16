---
title: Export Presentations to XAML in JavaScript
linktitle: Presentation to XAML
type: docs
weight: 30
url: /nodejs-java/export-to-xaml/
keywords:
- export PowerPoint
- export OpenDocument
- export presentation
- convert PowerPoint
- convert OpenDocument
- convert presentation
- PowerPoint to XAML
- OpenDocument to XAML
- presentation to XAML
- PPT to XAML
- PPTX to XAML
- ODP to XAML
- save PPT as XAML
- save PPTX as XAML
- save ODP as XAML
- export PPT to XAML
- export PPTX to XAML
- export ODP to XAML
- Node.js
- JavaScript
- Aspose.Slides
description: "Convert PowerPoint and OpenDocument slides to XAML in JavaScript using Aspose.Slides—quick, Office-free solution that keeps your layout intact."
---

## **Overview**

This article explains how to export PowerPoint presentations to XAML using Aspose.Slides. It includes a brief introduction to XAML, shows how to save a presentation to XAML with default settings, and demonstrates how to customize the export through [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/), including exporting hidden slides. The article also answers a few common questions related to fallback fonts, XAML stack compatibility, and hidden slide export behavior.

## **About XAML**

XAML is an XML-based markup language used to describe user interfaces in frameworks such as WPF (Windows Presentation Foundation), UWP (Universal Windows Platform), and Xamarin.Forms.

You can work with XAML files in a visual designer or write and edit the markup directly.

## **Export Presentations to XAML With Default Options**

The following JavaScript example shows how to export a presentation to XAML with default settings:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const xamlOptions = new aspose.slides.XamlOptions();
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

By default, the exported slides are saved in an `input` subfolder of the process's current working directory. The folder is created automatically, and any required images are saved there as well.

The output folder name is taken from the source file name without its extension. In Aspose.Slides for Node.js via Java 26.8, exporting `input.pptx` produces a nested path such as `input/input/Slide_1.xaml`. Preserve the complete generated paths when handling the output. The default output is relative to the current working directory, rather than necessarily alongside the input file.

## **Export Presentations to XAML With Custom Options**

Use the [IXamlOptions](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloptions/) interface to control how Aspose.Slides exports a presentation to XAML.

To save the output to a custom location, implement [IXamlOutputSaver](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloutputsaver/) and pass an instance of your implementation to the [setOutputSaver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) method of [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/).

To include hidden slides in the XAML output, call [setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) with `true`, as shown in the following JavaScript example:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const xamlOptions = new aspose.slides.XamlOptions();
    xamlOptions.setExportHiddenSlides(true);
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

## **Capture All Generated XAML Artifacts**

A XAML export can produce a XAML document for each exported slide plus separate images and supporting resources. Assign a custom [IXamlOutputSaver](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloutputsaver/) to [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) to receive these artifacts instead of using the default file-system saver. Start the export with the XAML-specific [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save) overload that accepts XAML options.

In Node.js, implement the Java interface with `java.newProxy` from the `java` package used by Aspose.Slides. Keep the proxy reachable until export completes.

### **Understand the Callback Lifecycle**

The exporter calls [IXamlOutputSaver.save](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) separately for each generated artifact:

- `path` identifies the artifact and may include relative directories. Retain this information because XAML may reference resources using relative paths.
- `data` contains the artifact's bytes. Images and other binary resources must not be decoded as text.
- The saver is responsible for retaining or persisting the data before returning. The examples copy each Java byte array into an application-owned Node.js buffer.
- Treat export as successful only when the presentation save operation returns and every callback has completed successfully. Do not swallow storage errors or start unobserved background writes. If persistence happens afterward, report overall success only after that step also succeeds.

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) also applies to a custom saver. The default setting, `false`, excludes hidden-slide XAML documents. Passing `true` includes them and any resources required for their export. Resource counts depend on the presentation; do not assume one callback per slide or a fixed callback order.

### **Export to Memory and Inspect the Artifacts**

This complete example loads `input.pptx`, collects every artifact in a JavaScript map of names to buffers, and prints its name, type, and byte count. It preserves the supplied names exactly. Duplicate names mark the collection as invalid instead of silently overwriting an artifact. The example checks this before using the results.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const artifacts = new Map();
let valid = true;
const saver = java.newProxy("com.aspose.slides.IXamlOutputSaver", {
    save: function(path, data) {
        const name = String(path);
        if (artifacts.has(name)) {
            valid = false;
            console.error("Export rejected: duplicate artifact name: " + name);
            return;
        }
        const retainedData = Buffer.from(data);
        artifacts.set(name, retainedData);
    }
});

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(true);
    presentation.save(options);
} finally {
    presentation.dispose();
}

if (!valid) {
    console.error("Export rejected: the artifact collection is invalid.");
} else {
    const inspectXamlText = false;
    for (const [name, data] of artifacts) {
        const isXaml = /\.xaml$/i.test(name);
        const isImage = /\.(png|jpg|jpeg|gif|bmp|tif|tiff|svg)$/i.test(name);
        const kind = isXaml ? "slide XAML" : isImage ? "image" : "supporting resource";
        console.log(name + ": " + data.length + " bytes (" + kind + ")");

        // Decode only XAML, and only when textual inspection is needed.
        if (isXaml && inspectXamlText) {
            console.log(data.toString("utf8"));
        }
    }
}
```

Extension checks are useful for inspection; retain all artifacts, including unfamiliar resource types. Leave the bytes unchanged when storing or transmitting them. Use UTF-8 decoding only for XAML that needs textual processing.

### **Package Collected Artifacts in a ZIP Archive**

This independent example collects the export, validates its names, and writes the original bytes into a ZIP archive using the Java bridge. The ZIP is assembled in memory before being saved to disk. A unique archive name separates concurrent export jobs. ZIP entries use forward slashes and retain relative directories. Unsafe names or names that collide after normalization reject the entire package before it is written.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const artifacts = new Map();
let valid = true;
const saver = java.newProxy("com.aspose.slides.IXamlOutputSaver", {
    save: function(path, data) {
        const name = String(path);
        if (artifacts.has(name)) {
            valid = false;
            console.error("Export rejected: duplicate artifact name: " + name);
            return;
        }
        const retainedData = Buffer.from(data);
        artifacts.set(name, retainedData);
    }
});

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(false);
    presentation.save(options);
} finally {
    presentation.dispose();
}

const entries = new Map();
const entryNames = new Set();
for (const [name, data] of artifacts) {
    const entryName = name.replace(/\\/g, "/");
    const segments = entryName.split("/");
    const unsafeName = entryName.startsWith("/") || entryName.includes(":") || segments.some(segment => segment.trim() === "" || segment === "." || segment === "..");
    const comparisonName = entryName.toLowerCase();
    if (unsafeName || entryNames.has(comparisonName)) {
        valid = false;
        console.error("Export rejected: unsafe or duplicate artifact name: " + name);
        break;
    }
    entryNames.add(comparisonName);
    entries.set(entryName, data);
}

if (!valid) {
    console.error("Export rejected: the artifact collection is invalid.");
} else {
    const fs = require("node:fs");
    const crypto = require("node:crypto");
    const archivePath = "xaml-" + crypto.randomUUID() + ".zip";
    const output = java.newInstanceSync("java.io.ByteArrayOutputStream");
    const archive = java.newInstanceSync("java.util.zip.ZipOutputStream", output);
    try {
        for (const [name, data] of entries) {
            const entry = java.newInstanceSync("java.util.zip.ZipEntry", name);
            archive.putNextEntry(entry);
            const signedBytes = Array.from(data, value => value > 127 ? value - 256 : value);
            const bytes = java.newArray("byte", signedBytes);
            archive.write(bytes);
            archive.closeEntry();
        }
    } finally {
        archive.close();
    }

    // Closing finalizes the ZIP directory before the archive is persisted.
    const archiveData = Buffer.from(output.toByteArray());
    try {
        fs.writeFileSync(archivePath, archiveData, { flag: "wx" });
        console.log("Saved " + entries.size + " artifacts to " + archivePath);
    } catch (error) {
        console.error("Archive persistence failed: " + error.message);
    }
}
```

The example uses [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) to write one local archive; the exporter itself does not write loose XAML or image files. For remote storage, replace the archive-writing stage with uploads of the collected byte arrays. Use an export-job identifier plus the full relative artifact name as a blob key, or store the job identifier, relative name, and binary data in a database row. Publish the job only after all uploads complete or the database transaction commits. Clean up partial output if persistence fails.

For large presentations, a custom saver can persist each artifact directly to application storage to avoid keeping an additional copy of the entire export in application memory. Keep each callback synchronous from the exporter's perspective: return only after the destination has accepted the bytes, and allow failures to reach the caller.

### **Preserve Resource Names and Verify References**

- Normalize path separators when the destination requires it, but preserve relative directories. Do not use only the basename unless every generated name is known to be unique and resource references remain valid.
- Apply destination-specific name validation. When writing loose files, reject rooted paths and traversal segments, resolve the destination to an absolute path, and verify it stays beneath the intended export directory, including the directory separator in the containment check. Use an application-controlled directory without symbolic links that could redirect writes.
- Use a separate saver and storage namespace for each export job. Detect collisions after separator normalization and according to the destination's case-sensitivity rules.
- Before publishing, parse each XAML document as XML and inspect its file-based resource references, such as image `Source` or `ImageSource` attributes. Resolve each relative URI against the containing XAML artifact's directory, normalize the resulting storage name, and confirm that the corresponding map key, ZIP entry, or stored object exists. Treat external URIs and XAML markup expressions separately from relative file names.

For example, if `input/Slide_1.xaml` references `images/image1.png`, the stored resource must be available as `input/images/image1.png`. Keeping just `image1.png` would break that relationship. For object storage, preserve the same layout beneath the job prefix and make those resource URLs accessible to the XAML consumer. Reopen the completed ZIP to verify entry names and resource bytes, and load representative slides in the target XAML environment to confirm that images resolve correctly.

## **FAQ**

**How can I ensure predictable fonts if the original font is not available on the machine?**

Call [setDefaultRegularFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) in [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) — it is used as a fallback font during export when the original is missing. This does not guarantee that the generated XAML references the fallback font or that the font is available on the target machine. Ensure that the fonts referenced by the XAML are available in the environment where it is displayed.

**Is the exported XAML intended only for WPF, or can it be used in other XAML stacks as well?**

Aspose.Slides exports WPF XAML through its public API. Compatibility with other XAML stacks, such as UWP and Xamarin.Forms, is not guaranteed. Test the generated markup in your target environment.

**Are hidden slides supported, and how can I prevent them from being exported by default?**

By default, hidden slides are not included. You can control this behavior via [setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) in [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) — keep it disabled if you do not need to export them.
