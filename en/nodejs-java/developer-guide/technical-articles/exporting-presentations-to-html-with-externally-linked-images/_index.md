---
title: Export Presentations to HTML with Externally Linked Images
type: docs
weight: 100
url: /nodejs-java/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- export PowerPoint
- export OpenDocument
- export presentation
- export slide
- export PPT
- export PPTX
- export ODP
- PowerPoint to HTML
- OpenDocument to HTML
- presentation to HTML
- slide to HTML
- PPT to HTML
- PPTX to HTML
- ODP to HTML
- linked image
- externally linked image
- linked resource
- external resource
- JavaScript
- Node.js
- Aspose.Slides
description: "Export PowerPoint and OpenDocument presentations to HTML in JavaScript using Aspose.Slides for Node.js via Java with images and other resources saved as external linked files."
---

## **Overview**

By default, Aspose.Slides exports a presentation to a self-contained HTML file. Images and other resources are written directly into the HTML, usually as Base64 data. This is convenient when you need one portable file, but it is not always the best format for a website, a CMS, or a server-side conversion pipeline.

Use externally linked resources when you want to:

- reduce the size of the HTML document;
- cache images, fonts, audio, or video separately in a browser or CDN;
- inspect, replace, compress, or post-process generated resources after export;
- keep the output structure closer to what a web application expects.

For the general HTML conversion workflow, see [Convert PowerPoint Presentations to HTML](/slides/nodejs-java/convert-powerpoint-to-html/). This article focuses on the resource-linking part of the export.

## **How Linked Resource Export Works**

A Java proxy for [ILinkEmbedController](https://reference.aspose.com/slides/java/com.aspose.slides/ilinkembedcontroller/) lets your application decide, resource by resource, whether the exporter embeds the data in the HTML or saves it externally and writes a link.

The controller has three methods:

- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/java/com.aspose.slides/ilinkembedcontroller/) decides whether a resource should be linked or embedded.
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/java/com.aspose.slides/ilinkembedcontroller/) returns the URL that will be written to the generated HTML or to another linked resource.
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/java/com.aspose.slides/ilinkembedcontroller/) writes the linked resource data to disk or to another storage target.

The file system path and the browser URL are separate concerns. For example, the sample below writes resource files to `html-output/assets` on disk, while the HTML contains relative URLs such as `assets/resource-1.svg`. A browser resolves those URLs relative to the file that contains the link. Therefore, a link from `presentation.html` to an SVG file uses `assets/resource-1.svg`, while a link from that SVG file to an image saved in the same `assets` folder uses `resource-4.jpg`.

## **Export HTML with Linked Resources**

The following JavaScript example creates an output directory, saves the HTML file there, and stores linked resources in an `assets` subdirectory. The controller links common image, font, audio, video, and CSS resources when Aspose.Slides provides or can infer a safe file extension. Resources that are not recognized remain embedded.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");
const path = require("path");

class ExternalResourceController {
    constructor(assetDirectory, assetUrlPrefix) {
        if (assetDirectory == null || assetDirectory.trim().length === 0) {
            throw new Error("The asset output directory must not be empty.");
        }

        this.assetDirectory = assetDirectory;
        this.assetUrlPrefix = normalizeUrlPrefix(assetUrlPrefix);
        this.fileNamesByResourceId = new Map();
    }

    createProxy() {
        const linkEmbedControllerInterfaceName = "com.aspose.slides.ILinkEmbedController";
        let controller = this;
        return java.newProxy(linkEmbedControllerInterfaceName, {
            getObjectStoringLocation: function(resourceId, entityData, semanticName, contentType, recommendedExtension) {
                return controller.getObjectStoringLocation(
                    resourceId,
                    entityData,
                    semanticName,
                    contentType,
                    recommendedExtension);
            },
            getUrl: function(resourceId, referrer) {
                return controller.getUrl(resourceId, referrer);
            },
            saveExternal: function(resourceId, entityData) {
                controller.saveExternal(resourceId, entityData);
            }
        });
    }

    getObjectStoringLocation(resourceId, entityData, semanticName, contentType, recommendedExtension) {
        let extension = resolveExtension(contentType, recommendedExtension);
        if (extension == null) {
            return aspose.slides.LinkEmbedDecision.Embed;
        }

        this.fileNamesByResourceId.set(resourceId, "resource-" + resourceId + extension);
        return aspose.slides.LinkEmbedDecision.Link;
    }

    getUrl(resourceId, referrer) {
        let fileName = this.fileNamesByResourceId.get(resourceId);
        if (fileName == null) {
            return null;
        }

        if (this.fileNamesByResourceId.has(referrer)) {
            return fileName;
        }

        return this.assetUrlPrefix + fileName;
    }

    saveExternal(resourceId, entityData) {
        let fileName = this.fileNamesByResourceId.get(resourceId);
        if (fileName == null) {
            throw new Error("Resource " + resourceId + " was not registered for external storage.");
        }

        if (entityData == null || entityData.length === 0) {
            throw new Error("Resource " + resourceId + " contains no data and cannot be saved.");
        }

        fs.mkdirSync(this.assetDirectory, { recursive: true });

        let filePath = path.join(this.assetDirectory, fileName);
        let fileData = Buffer.from(entityData);
        fs.writeFileSync(filePath, fileData);
    }
}

function createExtensionsByContentType() {
    let extensionsByContentType = new Map();
    extensionsByContentType.set("image/jpeg", ".jpg");
    extensionsByContentType.set("image/png", ".png");
    extensionsByContentType.set("image/gif", ".gif");
    extensionsByContentType.set("image/bmp", ".bmp");
    extensionsByContentType.set("image/svg+xml", ".svg");
    extensionsByContentType.set("image/tiff", ".tiff");
    extensionsByContentType.set("image/x-emf", ".emf");
    extensionsByContentType.set("image/x-wmf", ".wmf");
    extensionsByContentType.set("font/woff", ".woff");
    extensionsByContentType.set("font/woff2", ".woff2");
    extensionsByContentType.set("font/ttf", ".ttf");
    extensionsByContentType.set("application/font-woff", ".woff");
    extensionsByContentType.set("application/vnd.ms-fontobject", ".eot");
    extensionsByContentType.set("application/x-font-ttf", ".ttf");
    extensionsByContentType.set("text/css", ".css");
    extensionsByContentType.set("audio/mpeg", ".mp3");
    extensionsByContentType.set("audio/mp4", ".m4a");
    extensionsByContentType.set("audio/wav", ".wav");
    extensionsByContentType.set("video/mp4", ".mp4");
    extensionsByContentType.set("video/webm", ".webm");
    return extensionsByContentType;
}

let extensionsByContentType = createExtensionsByContentType();

function resolveExtension(contentType, recommendedExtension) {
    if (contentType != null && contentType.trim().length > 0) {
        let mappedExtension = extensionsByContentType.get(contentType);
        if (mappedExtension != null) {
            return mappedExtension;
        }
    }

    if (!isSupportedContentType(contentType)) {
        return null;
    }

    return normalizeExtension(recommendedExtension);
}

function isSupportedContentType(contentType) {
    if (contentType == null) {
        return false;
    }

    let normalizedContentType = contentType.toLowerCase();
    return normalizedContentType.startsWith("image/") ||
        normalizedContentType.startsWith("font/") ||
        normalizedContentType.startsWith("audio/") ||
        normalizedContentType.startsWith("video/");
}

function normalizeExtension(extension) {
    if (extension == null || extension.trim().length === 0) {
        return null;
    }

    let extensionCharacters = extension.trim();
    while (extensionCharacters.startsWith(".")) {
        extensionCharacters = extensionCharacters.substring(1);
    }

    if (extensionCharacters.length === 0) {
        return null;
    }

    for (let index = 0; index < extensionCharacters.length; index++) {
        let character = extensionCharacters[index];
        if (!/[A-Za-z0-9]/.test(character)) {
            return null;
        }
    }

    return "." + extensionCharacters.toLowerCase();
}

function normalizeUrlPrefix(urlPrefix) {
    if (urlPrefix == null || urlPrefix.length === 0) {
        return "";
    }

    let normalizedUrlPrefix = urlPrefix.replace(/\\/g, "/");
    return normalizedUrlPrefix.endsWith("/")
        ? normalizedUrlPrefix
        : normalizedUrlPrefix + "/";
}

let inputFilePath = "presentation.pptx";
let outputDirectory = "html-output";
let assetDirectoryName = "assets";
let assetDirectory = path.join(outputDirectory, assetDirectoryName);

fs.mkdirSync(outputDirectory, { recursive: true });
fs.mkdirSync(assetDirectory, { recursive: true });

let assetUrlPrefix = assetDirectoryName + "/";
let controllerWrapper = new ExternalResourceController(assetDirectory, assetUrlPrefix);
let controller = controllerWrapper.createProxy();
let svgOptions = new aspose.slides.SVGOptions(controller);
let slideImageFormat = aspose.slides.SlideImageFormat.svg(svgOptions);

let htmlOptions = new aspose.slides.HtmlOptions(controller);
htmlOptions.setHtmlFormatter(aspose.slides.HtmlFormatter.createDocumentFormatter("", false));
htmlOptions.setSlideImageFormat(slideImageFormat);

let presentation = new aspose.slides.Presentation(inputFilePath);
try {
    let htmlFilePath = path.join(outputDirectory, "presentation.html");
    presentation.save(htmlFilePath, aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

After the export, the output folder has this structure:

```text
html-output/
  presentation.html
  assets/
    resource-1.svg
    resource-2.svg
    resource-3.svg
    resource-4.jpg
    resource-5.png
```

The exact files depend on the presentation content and export options. For example, raster images are commonly exported as JPEG or PNG. Aspose.Slides may choose a different image codec than the one used in the source presentation when that produces a smaller or more suitable file. Images with transparency are exported as PNG.

## **Choosing URLs for Deployment**

The sample uses a relative URL prefix: `assets/`. If `presentation.html` is opened from `html-output/presentation.html`, the browser loads `html-output/assets/resource-1.svg`.

When one linked resource refers to another linked resource, the sample uses the `referrer` parameter in [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/java/com.aspose.slides/ilinkembedcontroller/) and returns only the file name. For example, if `resource-1.svg` and `resource-4.jpg` are both in the `assets` folder, the SVG file should refer to `resource-4.jpg`, not to `assets/resource-4.jpg`.

Use a different URL prefix when the files are deployed elsewhere:

- Use `assets/` when the asset directory is next to the HTML file.
- Use `../assets/` when the asset directory is one level above the HTML file.
- Use `https://cdn.example.com/presentations/job-123/assets/` when the files are uploaded to a CDN or static file server.

The URL returned by [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/java/com.aspose.slides/ilinkembedcontroller/) must match the final deployed location of the file written by [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/java/com.aspose.slides/ilinkembedcontroller/). In server applications, use a unique output directory or object-storage prefix for each conversion job to avoid overwriting files from another export.

## **When to Embed Instead**

Embedded Base64 HTML is still useful when the output must be a single file, such as an email attachment, an offline preview, or a document that will be moved without a supporting asset folder. Linked resources are a better fit when the HTML will be served by a web application, stored in a CMS, optimized by a build pipeline, or cached by browsers independently from the HTML.

## **FAQ**

**Can I externalize only images and keep other resources embedded?**

Yes. In [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/java/com.aspose.slides/ilinkembedcontroller/), return `LinkEmbedDecision.Link` only for the content types you want to save as separate files, and return `LinkEmbedDecision.Embed` for everything else.

**Why does the exported image extension differ from the source presentation?**

Aspose.Slides may re-encode raster images during HTML export to improve size or browser compatibility. For example, an image from the source file may be written as JPEG or PNG depending on the rendered result.

**Do relative URLs work after I move the HTML file?**

Relative URLs work only when the same relative folder structure is preserved. If the HTML references `assets/resource-1.png`, the `assets` folder must stay next to the HTML file unless you generate a different URL prefix.

**Should server applications reuse the same output folder?**

No. Use a unique output directory or storage prefix for each conversion job. This avoids filename collisions and prevents one export from overwriting resources generated by another export.
