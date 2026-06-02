---
title: Export Presentations to HTML with Externally Linked Images
type: docs
weight: 100
url: /php-java/exporting-presentations-to-html-with-externally-linked-images/
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
- PHP
- Aspose.Slides
description: "Export PowerPoint and OpenDocument presentations to HTML in PHP via Java using Aspose.Slides with images and other resources saved as external linked files."
---

## **Overview**

By default, Aspose.Slides exports a presentation to a self-contained HTML file. Images and other resources are written directly into the HTML, usually as Base64 data. This is convenient when you need one portable file, but it is not always the best format for a website, a CMS, or a server-side conversion pipeline.

Use externally linked resources when you want to:

- reduce the size of the HTML document;
- cache images, fonts, audio, or video separately in a browser or CDN;
- inspect, replace, compress, or post-process generated resources after export;
- keep the output structure closer to what a web application expects.

For the general HTML conversion workflow, see [Convert PowerPoint Presentations to HTML](/slides/php-java/convert-powerpoint-to-html/). This article focuses on the resource-linking part of the export.

## **How Linked Resource Export Works**

[HtmlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/htmloptions/) can use a custom link/embed controller when Aspose.Slides exports a presentation to HTML. In PHP via Java, this scenario is usually implemented with a small Java helper class. Compile that helper, add it to the PHP Java Bridge classpath, and instantiate it from PHP with `new Java(...)`.

The helper class decides, resource by resource, whether the exporter embeds the data in the HTML or saves it externally and writes a link. It needs three callback methods:

- `ExternalResourceController.getObjectStoringLocation` decides whether a resource should be linked or embedded.
- `ExternalResourceController.getUrl` returns the URL that will be written to the generated HTML or to another linked resource.
- `ExternalResourceController.saveExternal` writes the linked resource data to disk or to another storage target.

The file system path and the browser URL are separate concerns. For example, the sample below writes resource files to `html-output/assets` on disk, while the HTML contains relative URLs such as `assets/resource-1.svg`. A browser resolves those URLs relative to the file that contains the link. Therefore, a link from `presentation.html` to an SVG file uses `assets/resource-1.svg`, while a link from that SVG file to an image saved in the same `assets` folder uses `resource-4.jpg`.

## **Create the Java Helper Class**

Create a Java class such as `com.example.slides.ExternalResourceController`, compile it with Aspose.Slides for Java on the classpath, and make the compiled class or JAR available to PHP Java Bridge.

The helper below links common image, font, audio, video, and CSS resources when Aspose.Slides provides or can infer a safe file extension. Resources that are not recognized remain embedded.

```java
package com.example.slides;

import com.aspose.slides.ILinkEmbedController;
import com.aspose.slides.LinkEmbedDecision;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.HashMap;
import java.util.Locale;
import java.util.Map;

public final class ExternalResourceController implements ILinkEmbedController {
    private static final Map<String, String> EXTENSIONS_BY_CONTENT_TYPE = createExtensionMap();

    private final Path assetDirectory;
    private final String assetUrlPrefix;
    private final Map<Integer, String> fileNamesByResourceId = new HashMap<>();

    public ExternalResourceController(String assetDirectory, String assetUrlPrefix) {
        if (assetDirectory == null || assetDirectory.trim().isEmpty()) {
            throw new IllegalArgumentException("The asset output directory must not be empty.");
        }

        this.assetDirectory = Paths.get(assetDirectory);
        this.assetUrlPrefix = normalizeUrlPrefix(assetUrlPrefix);
    }

    @Override
    public int getObjectStoringLocation(
            int resourceId,
            byte[] entityData,
            String semanticName,
            String contentType,
            String recommendedExtension) {
        String extension = resolveExtension(contentType, recommendedExtension);
        if (extension == null) {
            return LinkEmbedDecision.Embed;
        }

        fileNamesByResourceId.put(resourceId, "resource-" + resourceId + extension);
        return LinkEmbedDecision.Link;
    }

    @Override
    public String getUrl(int resourceId, int referrer) {
        String fileName = fileNamesByResourceId.get(resourceId);
        if (fileName == null) {
            return null;
        }

        if (fileNamesByResourceId.containsKey(referrer)) {
            return fileName;
        }

        return assetUrlPrefix + fileName;
    }

    @Override
    public void saveExternal(int resourceId, byte[] entityData) {
        String fileName = fileNamesByResourceId.get(resourceId);
        if (fileName == null) {
            throw new IllegalStateException(
                    "Resource " + resourceId + " was not registered for external storage.");
        }

        if (entityData == null || entityData.length == 0) {
            throw new IllegalStateException(
                    "Resource " + resourceId + " contains no data and cannot be saved.");
        }

        Path filePath = assetDirectory.resolve(fileName);
        try {
            Files.createDirectories(assetDirectory);
            Files.write(filePath, entityData);
        } catch (IOException exception) {
            throw new IllegalStateException(
                    "Could not save linked resource " + resourceId + " to " + filePath + ".",
                    exception);
        }
    }

    private static Map<String, String> createExtensionMap() {
        Map<String, String> extensions = new HashMap<>();
        extensions.put("image/jpeg", ".jpg");
        extensions.put("image/png", ".png");
        extensions.put("image/gif", ".gif");
        extensions.put("image/bmp", ".bmp");
        extensions.put("image/svg+xml", ".svg");
        extensions.put("image/tiff", ".tiff");
        extensions.put("image/x-emf", ".emf");
        extensions.put("image/x-wmf", ".wmf");
        extensions.put("font/woff", ".woff");
        extensions.put("font/woff2", ".woff2");
        extensions.put("font/ttf", ".ttf");
        extensions.put("application/font-woff", ".woff");
        extensions.put("application/vnd.ms-fontobject", ".eot");
        extensions.put("application/x-font-ttf", ".ttf");
        extensions.put("text/css", ".css");
        extensions.put("audio/mpeg", ".mp3");
        extensions.put("audio/mp4", ".m4a");
        extensions.put("audio/wav", ".wav");
        extensions.put("video/mp4", ".mp4");
        extensions.put("video/webm", ".webm");
        return extensions;
    }

    private static String resolveExtension(String contentType, String recommendedExtension) {
        if (contentType != null && !contentType.trim().isEmpty()) {
            String mappedExtension = EXTENSIONS_BY_CONTENT_TYPE.get(contentType);
            if (mappedExtension != null) {
                return mappedExtension;
            }
        }

        if (!isSupportedContentType(contentType)) {
            return null;
        }

        return normalizeExtension(recommendedExtension);
    }

    private static boolean isSupportedContentType(String contentType) {
        return contentType != null &&
                (contentType.regionMatches(true, 0, "image/", 0, 6) ||
                 contentType.regionMatches(true, 0, "font/", 0, 5) ||
                 contentType.regionMatches(true, 0, "audio/", 0, 6) ||
                 contentType.regionMatches(true, 0, "video/", 0, 6));
    }

    private static String normalizeExtension(String extension) {
        if (extension == null || extension.trim().isEmpty()) {
            return null;
        }

        String extensionCharacters = extension.trim();
        while (extensionCharacters.startsWith(".")) {
            extensionCharacters = extensionCharacters.substring(1);
        }

        for (int characterIndex = 0; characterIndex < extensionCharacters.length(); characterIndex++) {
            if (!Character.isLetterOrDigit(extensionCharacters.charAt(characterIndex))) {
                return null;
            }
        }

        return "." + extensionCharacters.toLowerCase(Locale.ROOT);
    }

    private static String normalizeUrlPrefix(String urlPrefix) {
        if (urlPrefix == null || urlPrefix.isEmpty()) {
            return "";
        }

        String normalizedUrlPrefix = urlPrefix.replace('\\', '/');
        return normalizedUrlPrefix.endsWith("/")
                ? normalizedUrlPrefix
                : normalizedUrlPrefix + "/";
    }
}
```

## **Export HTML with Linked Resources**

The following PHP code creates an output directory, saves the HTML file there, and stores linked resources in an `assets` subdirectory. It combines [HtmlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/htmloptions/), [SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/), [SlideImageFormat](https://reference.aspose.com/slides/php-java/aspose.slides/slideimageformat/), and [SaveFormat](https://reference.aspose.com/slides/php-java/aspose.slides/saveformat/) for the export.

```php
$inputFilePath = "presentation.pptx";
$outputDirectory = "html-output";
$assetDirectoryName = "assets";
$assetDirectory = $outputDirectory . DIRECTORY_SEPARATOR . $assetDirectoryName;

if (!is_dir($outputDirectory) && !mkdir($outputDirectory, 0777, true)) {
    throw new RuntimeException("Could not create the HTML output directory: " . $outputDirectory);
}

if (!is_dir($assetDirectory) && !mkdir($assetDirectory, 0777, true)) {
    throw new RuntimeException("Could not create the asset output directory: " . $assetDirectory);
}

$assetUrlPrefix = $assetDirectoryName . "/";
$controller = new Java("com.example.slides.ExternalResourceController", $assetDirectory, $assetUrlPrefix);
$svgOptions = new SVGOptions($controller);
$slideImageFormat = SlideImageFormat::svg($svgOptions);

$htmlOptions = new HtmlOptions($controller);
$htmlFormatter = java("com.aspose.slides.HtmlFormatter")->createDocumentFormatter("", false);
$htmlOptions->setHtmlFormatter($htmlFormatter);
$htmlOptions->setSlideImageFormat($slideImageFormat);

$presentation = new Presentation($inputFilePath);
try {
    $htmlFilePath = $outputDirectory . DIRECTORY_SEPARATOR . "presentation.html";
    $presentation->save($htmlFilePath, SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
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

When one linked resource refers to another linked resource, the sample uses the `referrer` parameter in `ExternalResourceController.getUrl` and returns only the file name. For example, if `resource-1.svg` and `resource-4.jpg` are both in the `assets` folder, the SVG file should refer to `resource-4.jpg`, not to `assets/resource-4.jpg`.

Use a different URL prefix when the files are deployed elsewhere:

- Use `assets/` when the asset directory is next to the HTML file.
- Use `../assets/` when the asset directory is one level above the HTML file.
- Use `https://cdn.example.com/presentations/job-123/assets/` when the files are uploaded to a CDN or static file server.

The URL returned by `ExternalResourceController.getUrl` must match the final deployed location of the file written by `ExternalResourceController.saveExternal`. In server applications, use a unique output directory or object-storage prefix for each conversion job to avoid overwriting files from another export.

## **When to Embed Instead**

Embedded Base64 HTML is still useful when the output must be a single file, such as an email attachment, an offline preview, or a document that will be moved without a supporting asset folder. Linked resources are a better fit when the HTML will be served by a web application, stored in a CMS, optimized by a build pipeline, or cached by browsers independently from the HTML.

## **FAQ**

**Can I externalize only images and keep other resources embedded?**

Yes. In `ExternalResourceController.getObjectStoringLocation`, return the `Link` value from [LinkEmbedDecision](https://reference.aspose.com/slides/php-java/aspose.slides/linkembeddecision/) only for the content types you want to save as separate files, and return the `Embed` value for everything else.

**Why does the exported image extension differ from the source presentation?**

Aspose.Slides may re-encode raster images during HTML export to improve size or browser compatibility. For example, an image from the source file may be written as JPEG or PNG depending on the rendered result.

**Do relative URLs work after I move the HTML file?**

Relative URLs work only when the same relative folder structure is preserved. If the HTML references `assets/resource-1.png`, the `assets` folder must stay next to the HTML file unless you generate a different URL prefix.

**Should server applications reuse the same output folder?**

No. Use a unique output directory or storage prefix for each conversion job. This avoids filename collisions and prevents one export from overwriting resources generated by another export.
