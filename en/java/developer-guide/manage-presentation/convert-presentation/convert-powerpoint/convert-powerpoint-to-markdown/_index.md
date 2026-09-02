---
title: Convert PowerPoint Presentations to Markdown in Java
linktitle: PowerPoint to Markdown
type: docs
weight: 140
url: /java/convert-powerpoint-to-markdown/
keywords:
- convert PowerPoint
- convert presentation
- convert slide
- convert PPT
- convert PPTX
- PowerPoint to MD
- presentation to MD
- slide to MD
- PPT to MD
- PPTX to MD
- save PowerPoint as Markdown
- save presentation as Markdown
- save slide as Markdown
- save PPT as MD
- save PPTX as MD
- export PPT to MD
- export PPTX to MD
- Markdown image export
- CDN image links
- PowerPoint
- presentation
- Markdown
- Java
- Aspose.Slides
description: "Convert PPT and PPTX presentations to Markdown in Java and control where exported bitmap, metafile, and SVG images are saved and referenced."
---

## **Overview**

Aspose.Slides for Java can convert PPT and PPTX presentations to Markdown for documentation, static-site, content-migration, and version-control workflows. You can choose a Markdown flavor, control how slide content is rendered, and decide where exported images are stored and how the generated Markdown references them.

By default, Markdown export uses text-only output. To export visual content, set the export type with the [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/java/com.aspose.slides/markdownsaveoptions/) method to the `Sequential` or `Visual` value from the [MarkdownExportType](https://reference.aspose.com/slides/java/com.aspose.slides/markdownexporttype/) enumeration. `Sequential` renders slide items separately and in order, whereas `Visual` keeps grouped items together to preserve their visual relationship. The `TextOnly` value does not emit image resources, so the image-saving callbacks are not invoked in that mode.

## **Convert a Presentation to Markdown**

Load the source file with the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) class, and then call the [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) method with the `Md` value from the [SaveFormat](https://reference.aspose.com/slides/java/com.aspose.slides/saveformat/) enumeration.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.md", SaveFormat.Md);
} finally {
    presentation.dispose();
}
```

## **Select a Markdown Flavor**

The [MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/java/com.aspose.slides/markdownsaveoptions/) method controls the Markdown specification used for the output. The [Flavor](https://reference.aspose.com/slides/java/com.aspose.slides/flavor/) enumeration includes CommonMark, GitHub Flavored Markdown, and other supported variants.

The following example exports a presentation as CommonMark:

```java
import com.aspose.slides.Flavor;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setFlavor(Flavor.CommonMark);

    presentation.save("presentation.md", SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

## **Export Images Using the Default Local-Saving Behavior**

The [MarkdownSaveOptions](https://reference.aspose.com/slides/java/com.aspose.slides/markdownsaveoptions/) class provides two methods for configuring locally saved images:

- [setBasePath](https://reference.aspose.com/slides/java/com.aspose.slides/markdownsaveoptions/) specifies the base directory for the Markdown document and its resources.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/java/com.aspose.slides/markdownsaveoptions/) specifies the image subdirectory. Its default value is `Images`.

The following example renders visual content, writes images to `output/assets`, and creates relative image references in the Markdown document:

```java
import com.aspose.slides.MarkdownExportType;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Path outputDirectory = Paths.get("output");
Files.createDirectories(outputDirectory);

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setExportType(MarkdownExportType.Visual);
    options.setBasePath(outputDirectory.toString());
    options.setImagesSaveFolderName("assets");

    Path markdownPath = outputDirectory.resolve("presentation.md");
    presentation.save(markdownPath.toString(), SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

This behavior also serves as the fallback when a custom image-saving handler returns `false`.

## **Customize Image Saving and Markdown Links**

Use the [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/java/com.aspose.slides/markdownsaveoptions/) method to register a callback for non-SVG bitmap and metafile resources emitted during Markdown export. Its `MarkdownImageSavingHandler` callback receives the [IImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/) object, its [ImageFormat](https://reference.aspose.com/slides/java/com.aspose.slides/imageformat/) value, and the generated Markdown link as a one-element `String[]` parameter. Save or upload the image with the supplied format, and replace `link[0]` with the reference that must appear in the Markdown output.

Resources emitted in SVG format are handled separately. Register a callback with the [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/java/com.aspose.slides/markdownsaveoptions/) method. Its `MarkdownSvgImageSavingHandler` callback receives an [ISvgImage](https://reference.aspose.com/slides/java/com.aspose.slides/isvgimage/) object and the one-element `String[] link` parameter. An SVG has no `ImageFormat` argument; write or upload its XML data from the [ISvgImage.getSvgData](https://reference.aspose.com/slides/java/com.aspose.slides/isvgimage/) method instead. Depending on the export mode and visual grouping, an SVG in the source presentation can be rasterized or combined with other content; the resulting non-SVG resource is then passed to the image-saving callback. Register both callbacks when every exported visual resource requires custom processing.

The handler return value determines who processes the image:

- Return `true` after the handler has saved, uploaded, transformed, or otherwise processed the image and assigned a valid value to `link[0]`. Aspose.Slides writes that value to the Markdown document and does not perform its default local save.
- Return `false` to let Aspose.Slides save the image locally and generate its link according to the values set by [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/java/com.aspose.slides/markdownsaveoptions/) and [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/java/com.aspose.slides/markdownsaveoptions/).

{{% alert color="warning" title="Important" %}}

A handler that returns `true` takes responsibility for the image. If it returns `true` without assigning a valid, nonempty link, the export fails with an `InvalidOperationException`.

{{% /alert %}}

### **Save Images to a CDN Origin Directory and Use External URLs**

The following example treats `cdn-origin/presentations/quarterly-report` as a mounted or synchronized CDN origin directory. Each handler extracts the generated file name, saves the image to that custom directory, and replaces the generated local reference with a public CDN URL. The sample itself performs no network upload: the URL becomes valid only after the directory is mounted as the CDN origin or its files are published to the CDN. For object storage, replace the file-system write with the storage SDK's upload operation and assign `link[0]` only after the upload succeeds.

```java
import com.aspose.slides.MarkdownExportType;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.IOException;
import java.io.UnsupportedEncodingException;
import java.net.URLEncoder;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.function.Function;

Path outputDirectory = Paths.get("output");
String publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
Path storageDirectory = Paths.get("cdn-origin", "presentations", "quarterly-report");
Files.createDirectories(outputDirectory);
Files.createDirectories(storageDirectory);

Function<String, String> getFileNameFromLink = generatedLink -> {
    String urlCompatibleLink = generatedLink.replace('\\', '/');
    return urlCompatibleLink.substring(urlCompatibleLink.lastIndexOf('/') + 1);
};
Function<String, String> buildPublicUrl = fileName -> {
    try {
        String encodedFileName = URLEncoder.encode(fileName, "UTF-8").replace("+", "%20");
        return publicBaseUrl + "/" + encodedFileName;
    } catch (UnsupportedEncodingException exception) {
        System.err.println("Could not encode the image file name: " + exception.getMessage());
        return null;
    }
};

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setExportType(MarkdownExportType.Visual);
    options.setBasePath(outputDirectory.toString());
    options.setImagesSaveFolderName("fallback-images");

    options.setImageSaving((image, format, link) -> {
        if (image.getWidth() < 128 || image.getHeight() < 128) {
            return false;
        }

        String fileName = getFileNameFromLink.apply(link[0]);
        String publicUrl = buildPublicUrl.apply(fileName);
        if (publicUrl == null) {
            return false;
        }
        Path storagePath = storageDirectory.resolve(fileName);
        image.save(storagePath.toString(), format);
        link[0] = publicUrl;
        return true;
    });

    options.setSvgImageSaving((svgImage, link) -> {
        String fileName = getFileNameFromLink.apply(link[0]);
        String publicUrl = buildPublicUrl.apply(fileName);
        if (publicUrl == null) {
            return false;
        }
        Path storagePath = storageDirectory.resolve(fileName);
        try {
            Files.write(storagePath, svgImage.getSvgData());
        } catch (IOException exception) {
            System.err.println("Could not save the SVG image: " + exception.getMessage());
            return false;
        }
        link[0] = publicUrl;
        return true;
    });

    Path markdownPath = outputDirectory.resolve("presentation.md");
    presentation.save(markdownPath.toString(), SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

The bitmap handler deliberately returns `false` for images smaller than 128 × 128 pixels, so Aspose.Slides saves those images to `output/fallback-images` using the default behavior. Larger bitmap and metafile resources, as well as SVG resources, are handled by the custom code. For example, a generated local reference such as `fallback-images/image1.png` becomes `https://cdn.example.com/presentations/quarterly-report/image1.png`. The handlers use operating-system paths only when writing files; links written to Markdown use forward slashes and URL-escaped file names. Apply the same rule when building relative links: use `/`, not the platform-specific directory separator.

## **FAQ**

**Can one handler process both raster images and SVG images?**

No. Use [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/java/com.aspose.slides/markdownsaveoptions/) for emitted bitmap and metafile resources and [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/java/com.aspose.slides/markdownsaveoptions/) for resources emitted as SVG. The former provides an [IImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/) object and an [ImageFormat](https://reference.aspose.com/slides/java/com.aspose.slides/imageformat/) value; the latter provides an [ISvgImage](https://reference.aspose.com/slides/java/com.aspose.slides/isvgimage/) object whose SVG data can be read with [ISvgImage.getSvgData](https://reference.aspose.com/slides/java/com.aspose.slides/isvgimage/). A source SVG that is rasterized during export is processed by the image-saving callback instead.

**What happens when an image-saving handler returns `false`?**

Aspose.Slides uses its default local-saving behavior. The image location and generated reference are controlled by the values set with [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/java/com.aspose.slides/markdownsaveoptions/) and [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/java/com.aspose.slides/markdownsaveoptions/).

**Can a handler provide a URL without saving the image locally?**

Yes. The handler can upload the image to object storage or pass it to another service, assign the resulting URL to `link[0]`, and return `true`. The handler must complete the processing itself; returning `true` prevents the default local save.

**Why does Markdown export throw an `InvalidOperationException` from a handler?**

This exception occurs when the handler returns `true` but does not provide a valid link. Assign the relative path or external URL that should be written to Markdown before returning `true`.

**Which path separator should image links use?**

Use forward slashes in Markdown links and URLs. Use `Path.resolve` only for file-system paths, then construct or normalize the Markdown reference separately.

**Are hyperlinks preserved during Markdown export?**

Yes. Text [hyperlinks](/slides/java/manage-hyperlinks/) are preserved as standard Markdown links. Slide [transitions](/slides/java/slide-transition/) and [animations](/slides/java/powerpoint-animation/) are not converted.

**Can presentations be converted to Markdown in parallel?**

You can process different presentation files in parallel, but do not share the same [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) instance between threads. Follow the [multithreading guidelines](/slides/java/multithreading/) and use a separate instance for each file.
