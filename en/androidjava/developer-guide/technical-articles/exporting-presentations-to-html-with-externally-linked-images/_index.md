---
title: Export Presentations to HTML with Externally Linked Images
type: docs
weight: 100
url: /androidjava/exporting-presentations-to-html-with-externally-linked-images/
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
- Android
- Java
- Aspose.Slides
description: "Export PowerPoint and OpenDocument presentations to HTML in Android via Java using Aspose.Slides with images and other resources saved as external linked files."
---

## **Overview**

By default, Aspose.Slides exports a presentation to a self-contained HTML file. Images and other resources are written directly into the HTML, usually as Base64 data. This is convenient when you need one portable file, but it is not always the best format for a web view, a CMS, or a server-side conversion pipeline that later publishes the output.

Use externally linked resources when you want to:

- reduce the size of the HTML document;
- cache images, fonts, audio, or video separately in a browser or CDN;
- inspect, replace, compress, or post-process generated resources after export;
- keep the output structure closer to what a web application expects.

For the general HTML conversion workflow, see [Convert PowerPoint Presentations to HTML](/slides/androidjava/convert-powerpoint-to-html/). This article focuses on the resource-linking part of the export.

## **How Linked Resource Export Works**

[ILinkEmbedController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilinkembedcontroller/) lets your application decide, resource by resource, whether the exporter embeds the data in the HTML or saves it externally and writes a link.

The interface has three methods:

- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilinkembedcontroller/) decides whether a resource should be linked or embedded.
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilinkembedcontroller/) returns the URL that will be written to the generated HTML or to another linked resource.
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilinkembedcontroller/) writes the linked resource data to disk or to another storage target.

The file system path and the browser URL are separate concerns. For example, the sample below writes resource files to `html-output/assets` in the application's file storage, while the HTML contains relative URLs such as `assets/resource-1.svg`. A browser resolves those URLs relative to the file that contains the link. Therefore, a link from `presentation.html` to an SVG file uses `assets/resource-1.svg`, while a link from that SVG file to an image saved in the same `assets` folder uses `resource-4.jpg`.

## **Export HTML with Linked Resources**

The following Android Java example creates an output directory, saves the HTML file there, and stores linked resources in an `assets` subdirectory. Pass an app-owned directory such as `context.getFilesDir()` as `applicationFilesDirectory`. The code avoids `java.nio.file` APIs, so it remains compatible with Android `minSdk` 19.

The controller links common image, font, audio, video, and CSS resources when Aspose.Slides provides or can infer a safe file extension. Resources that are not recognized remain embedded.

```java
import com.aspose.slides.HtmlFormatter;
import com.aspose.slides.HtmlOptions;
import com.aspose.slides.ILinkEmbedController;
import com.aspose.slides.LinkEmbedDecision;
import com.aspose.slides.Presentation;
import com.aspose.slides.SVGOptions;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.SlideImageFormat;

import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.util.HashMap;
import java.util.Locale;
import java.util.Map;

public class ExportToHtmlWithLinkedResources {
    public static void exportPresentation(File applicationFilesDirectory) {
        if (applicationFilesDirectory == null) {
            throw new IllegalArgumentException("The application files directory must not be null.");
        }

        File inputFile = new File(applicationFilesDirectory, "presentation.pptx");
        File outputDirectory = new File(applicationFilesDirectory, "html-output");
        String assetDirectoryName = "assets";
        File assetDirectory = new File(outputDirectory, assetDirectoryName);

        createDirectory(outputDirectory, "HTML output");
        createDirectory(assetDirectory, "asset output");

        String assetUrlPrefix = assetDirectoryName + "/";
        ExternalResourceController controller = new ExternalResourceController(assetDirectory, assetUrlPrefix);
        SVGOptions svgOptions = new SVGOptions(controller);
        SlideImageFormat slideImageFormat = SlideImageFormat.svg(svgOptions);

        HtmlOptions htmlOptions = new HtmlOptions(controller);
        htmlOptions.setHtmlFormatter(HtmlFormatter.createDocumentFormatter("", false));
        htmlOptions.setSlideImageFormat(slideImageFormat);

        Presentation presentation = new Presentation(inputFile.getAbsolutePath());
        try {
            File htmlFile = new File(outputDirectory, "presentation.html");
            presentation.save(htmlFile.getAbsolutePath(), SaveFormat.Html, htmlOptions);
        } finally {
            presentation.dispose();
        }
    }

    private static final class ExternalResourceController implements ILinkEmbedController {
        private static final Map<String, String> EXTENSIONS_BY_CONTENT_TYPE = createExtensionsByContentType();

        private final File assetDirectory;
        private final String assetUrlPrefix;
        private final Map<Integer, String> fileNamesByResourceId = new HashMap<Integer, String>();

        private ExternalResourceController(File assetDirectory, String assetUrlPrefix) {
            if (assetDirectory == null) {
                throw new IllegalArgumentException("The asset output directory must not be null.");
            }

            this.assetDirectory = assetDirectory;
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

            createDirectory(assetDirectory, "asset output");

            File outputFile = new File(assetDirectory, fileName);
            FileOutputStream outputStream = null;
            try {
                outputStream = new FileOutputStream(outputFile);
                outputStream.write(entityData);
            } catch (IOException exception) {
                throw new IllegalStateException(
                        "Failed to save external resource " + resourceId +
                                " to " + outputFile.getAbsolutePath() + ".",
                        exception);
            } finally {
                closeOutputStream(outputStream, outputFile);
            }
        }

        private static Map<String, String> createExtensionsByContentType() {
            Map<String, String> extensionsByContentType = new HashMap<String, String>();
            extensionsByContentType.put("image/jpeg", ".jpg");
            extensionsByContentType.put("image/png", ".png");
            extensionsByContentType.put("image/gif", ".gif");
            extensionsByContentType.put("image/bmp", ".bmp");
            extensionsByContentType.put("image/svg+xml", ".svg");
            extensionsByContentType.put("image/tiff", ".tiff");
            extensionsByContentType.put("image/x-emf", ".emf");
            extensionsByContentType.put("image/x-wmf", ".wmf");
            extensionsByContentType.put("font/woff", ".woff");
            extensionsByContentType.put("font/woff2", ".woff2");
            extensionsByContentType.put("font/ttf", ".ttf");
            extensionsByContentType.put("application/font-woff", ".woff");
            extensionsByContentType.put("application/vnd.ms-fontobject", ".eot");
            extensionsByContentType.put("application/x-font-ttf", ".ttf");
            extensionsByContentType.put("text/css", ".css");
            extensionsByContentType.put("audio/mpeg", ".mp3");
            extensionsByContentType.put("audio/mp4", ".m4a");
            extensionsByContentType.put("audio/wav", ".wav");
            extensionsByContentType.put("video/mp4", ".mp4");
            extensionsByContentType.put("video/webm", ".webm");
            return extensionsByContentType;
        }

        private static String resolveExtension(String contentType, String recommendedExtension) {
            if (contentType != null && !contentType.trim().equals("")) {
                String normalizedContentType = contentType.toLowerCase(Locale.US);
                String mappedExtension = EXTENSIONS_BY_CONTENT_TYPE.get(normalizedContentType);
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
                    (contentType.regionMatches(true, 0, "image/", 0, "image/".length()) ||
                     contentType.regionMatches(true, 0, "font/", 0, "font/".length()) ||
                     contentType.regionMatches(true, 0, "audio/", 0, "audio/".length()) ||
                     contentType.regionMatches(true, 0, "video/", 0, "video/".length()));
        }

        private static String normalizeExtension(String extension) {
            if (extension == null || extension.trim().equals("")) {
                return null;
            }

            String extensionCharacters = extension.trim();
            while (extensionCharacters.startsWith(".")) {
                extensionCharacters = extensionCharacters.substring(1);
            }

            if (extensionCharacters.equals("")) {
                return null;
            }

            int characterCount = extensionCharacters.length();
            for (int index = 0; index < characterCount; index++) {
                char character = extensionCharacters.charAt(index);
                if (!Character.isLetterOrDigit(character)) {
                    return null;
                }
            }

            return "." + extensionCharacters.toLowerCase(Locale.US);
        }

        private static String normalizeUrlPrefix(String urlPrefix) {
            if (urlPrefix == null || urlPrefix.equals("")) {
                return "";
            }

            String normalizedUrlPrefix = urlPrefix.replace('\\', '/');
            return normalizedUrlPrefix.endsWith("/")
                    ? normalizedUrlPrefix
                    : normalizedUrlPrefix + "/";
        }
    }

    private static void createDirectory(File directory, String description) {
        if (directory.exists()) {
            if (!directory.isDirectory()) {
                throw new IllegalStateException(
                        "The " + description + " path exists but is not a directory: " +
                                directory.getAbsolutePath());
            }

            return;
        }

        if (!directory.mkdirs()) {
            throw new IllegalStateException(
                    "Failed to create the " + description + " directory: " +
                            directory.getAbsolutePath());
        }
    }

    private static void closeOutputStream(FileOutputStream outputStream, File outputFile) {
        if (outputStream == null) {
            return;
        }

        try {
            outputStream.close();
        } catch (IOException exception) {
            throw new IllegalStateException(
                    "Failed to close the external resource file: " +
                            outputFile.getAbsolutePath(),
                    exception);
        }
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

When one linked resource refers to another linked resource, the sample uses the `referrer` parameter in [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilinkembedcontroller/) and returns only the file name. For example, if `resource-1.svg` and `resource-4.jpg` are both in the `assets` folder, the SVG file should refer to `resource-4.jpg`, not to `assets/resource-4.jpg`.

Use a different URL prefix when the files are deployed elsewhere:

- Use `assets/` when the asset directory is next to the HTML file.
- Use `../assets/` when the asset directory is one level above the HTML file.
- Use `https://cdn.example.com/presentations/job-123/assets/` when the files are uploaded to a CDN or static file server.

The URL returned by [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilinkembedcontroller/) must match the final deployed location of the file written by [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilinkembedcontroller/). In Android applications, use app-specific storage, a cache directory, or a directory obtained through the Storage Access Framework according to your publishing workflow. In server applications, use a unique output directory or object-storage prefix for each conversion job to avoid overwriting files from another export.

## **When to Embed Instead**

Embedded Base64 HTML is still useful when the output must be a single file, such as an email attachment, an offline preview, or a document that will be moved without a supporting asset folder. Linked resources are a better fit when the HTML will be served by a web application, stored in a CMS, optimized by a build pipeline, or cached by browsers independently from the HTML.

## **FAQ**

**Can I externalize only images and keep other resources embedded?**

Yes. In [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilinkembedcontroller/), return `Link` from [LinkEmbedDecision](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linkembeddecision/) only for the content types you want to save as separate files, and return `Embed` for everything else.

**Why does the exported image extension differ from the source presentation?**

Aspose.Slides may re-encode raster images during HTML export to improve size or browser compatibility. For example, an image from the source file may be written as JPEG or PNG depending on the rendered result.

**Do relative URLs work after I move the HTML file?**

Relative URLs work only when the same relative folder structure is preserved. If the HTML references `assets/resource-1.png`, the `assets` folder must stay next to the HTML file unless you generate a different URL prefix.

**Can I write resources to public external storage on Android?**

Yes, if your application has a valid destination and permission model for the target Android version. For generated HTML that is used only by your app, app-specific files or cache directories are usually simpler. For user-visible output, use a user-selected location or another storage approach that fits your app.

**Should server applications reuse the same output folder?**

No. Use a unique output directory or storage prefix for each conversion job. This avoids filename collisions and prevents one export from overwriting resources generated by another export.
