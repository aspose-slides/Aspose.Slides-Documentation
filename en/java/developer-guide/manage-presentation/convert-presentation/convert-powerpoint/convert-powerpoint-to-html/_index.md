---
title: Convert PowerPoint Presentations to HTML in Java
linktitle: PowerPoint to HTML
type: docs
weight: 30
url: /java/convert-powerpoint-to-html/
keywords:
- convert PowerPoint
- convert presentation
- convert slide
- convert PPT
- convert PPTX
- PowerPoint to HTML
- presentation to HTML
- slide to HTML
- PPT to HTML
- PPTX to HTML
- save PowerPoint as HTML
- save presentation as HTML
- save slide as HTML
- save PPT as HTML
- save PPTX as HTML
- export PPT to HTML
- export PPTX to HTML
- Java
- Aspose.Slides
description: "Convert PowerPoint presentations to HTML in Java. Use Aspose.Slides to export PPT and PPTX files, selected slides, notes, fonts, images, SVG, and media."
---

## **Overview**

Aspose.Slides for Java can save PowerPoint presentations as HTML without Microsoft PowerPoint. The basic conversion is a single [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) load and a `save` call with [SaveFormat](https://reference.aspose.com/slides/java/com.aspose.slides/saveformat/). Use [HtmlOptions](https://reference.aspose.com/slides/java/com.aspose.slides/htmloptions/) when you need to control the exported layout, fonts, images, notes, comments, SVG output, or linked resources.

This guide focuses on practical HTML export scenarios:

- Export a whole presentation or selected slides.
- Generate fixed-layout, responsive, or SVG-based HTML.
- Include speaker notes and comments.
- Control image quality and cropped image data.
- Embed fonts or save font files separately.
- Choose how external resources and media files are written and referenced.

By default, HTML export produces a self-contained HTML document where most resources are embedded. This is convenient for sharing one file, but it can increase output size. For web publishing, consider external resources, lower image DPI, and only embedding fonts that are not reliably available in the target environment.

## **Convert a Presentation to HTML**

To export a presentation to HTML, load it with [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) and save it with [SaveFormat.Html](https://reference.aspose.com/slides/java/com.aspose.slides/saveformat/).

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.html", SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

This example writes one HTML file. The presentation object is disposed in the `finally` block, which releases file handles and rendering resources after export.

## **Use HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/java/com.aspose.slides/htmloptions/) is the main configuration class for HTML export. Common settings include:

- `SlidesLayoutOptions`: adds notes, comments, handouts, or other layout information.
- `HtmlFormatter`: changes the HTML document structure or delegates formatting to a controller.
- `SlideImageFormat`: changes how slides are represented, for example as SVG.
- `PicturesCompression`: controls image DPI and output size.
- `DeletePicturesCroppedAreas`: keeps or removes cropped image data.
- `SvgResponsiveLayout`: makes exported SVG content adapt to its container.
- `ShowHiddenSlides`: includes hidden slides when required.

The following sections show the most common options separately so you can combine only the ones your workflow needs.

## **Convert Selected Slides to HTML**

The `Presentation.save` overload that accepts slide numbers uses 1-based slide positions. The loop below saves every slide to a separate HTML file.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    int slideCount = presentation.getSlides().size();

    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        int slideNumber = slideIndex + 1;
        int[] slideNumbers = { slideNumber };
        String htmlFileName = "slide-" + slideNumber + ".html";

        presentation.save(htmlFileName, slideNumbers, SaveFormat.Html);
    }
} finally {
    presentation.dispose();
}
```

Use this pattern when a website or application needs one HTML page per slide. If each slide should have the same layout, create one [HtmlOptions](https://reference.aspose.com/slides/java/com.aspose.slides/htmloptions/) instance and pass it to each `save` call.

## **Create Responsive HTML**

[ResponsiveHtmlController](https://reference.aspose.com/slides/java/com.aspose.slides/responsivehtmlcontroller/) provides responsive HTML output through [HtmlFormatter](https://reference.aspose.com/slides/java/com.aspose.slides/htmlformatter/). Use it when the exported page should adapt better to browser width.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    ResponsiveHtmlController controller = new ResponsiveHtmlController();
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(controller);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-responsive.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

For SVG-based responsive layout, set `SvgResponsiveLayout` on [HtmlOptions](https://reference.aspose.com/slides/java/com.aspose.slides/htmloptions/). This is useful when the slide content is exported as scalable SVG markup.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setSvgResponsiveLayout(true);

    presentation.save("presentation-svg-responsive.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **Include Speaker Notes and Comments**

Use [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/notescommentslayoutingoptions/) through `HtmlOptions.setSlidesLayoutOptions` to include speaker notes or comments. Notes and comments are hidden by default unless you choose their positions.

Suppose the source presentation contains speaker notes:

![Slide with speaker notes in PowerPoint](slide_with_notes.png)

The following code exports the slide content with speaker notes below the slide.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    NotesCommentsLayoutingOptions layoutOptions = new NotesCommentsLayoutingOptions();
    layoutOptions.setNotesPosition(NotesPositions.BottomFull);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setSlidesLayoutOptions(layoutOptions);

    presentation.save("presentation-with-notes.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

The exported HTML includes the notes area:

![HTML output with the slide and speaker notes](HTML_with_notes.png)

To export comments, set `CommentsPosition`, for example to `CommentsPositions.Right` or `CommentsPositions.Bottom`. If you need only comments, omit `NotesPosition`. If you need both notes and comments, set both properties.

## **Control Image Quality and Cropped Areas**

HTML export can compress slide images to reduce output size. Set `PicturesCompression` to a value from [PicturesCompression](https://reference.aspose.com/slides/java/com.aspose.slides/picturescompression/) when you need higher image quality.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setPicturesCompression(PicturesCompression.Dpi150);

    presentation.save("presentation-dpi-150.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

By default, cropped areas of images may be removed from the exported output. Keep cropped data only when users must be able to recover or inspect those hidden image parts. Keeping it can increase the HTML size.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setDeletePicturesCroppedAreas(false);

    presentation.save("presentation-with-cropped-areas.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **Add CSS**

For simple styling, pass a CSS string to `HtmlFormatter.createDocumentFormatter`. This changes the surrounding HTML document while Aspose.Slides continues to render the slide content.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    String cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
    HtmlFormatter formatter = HtmlFormatter.createDocumentFormatter(cssRules, true);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-styled.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

For a custom document header, a linked CSS file, or custom markup around slides and shapes, implement [IHtmlFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/ihtmlformattingcontroller/) and pass it to [HtmlFormatter](https://reference.aspose.com/slides/java/com.aspose.slides/htmlformatter/) with `createCustomFormatter`.

## **Embed Fonts**

If the target environment may not have the presentation fonts installed, embed fonts in the HTML with [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/java/com.aspose.slides/embedallfontshtmlcontroller/). Embedding improves visual fidelity but increases output size.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    String[] fontNamesToExclude = { "Arial" };
    EmbedAllFontsHtmlController fontController = new EmbedAllFontsHtmlController(fontNamesToExclude);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-embedded-fonts.html", SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Exclude fonts only when you are confident that the target browsers or systems already provide them. For brand fonts or less common fonts, embedding is usually safer.

## **Link Font Files Instead of Embedding Them**

To reduce the HTML file size, you can write font data to separate WOFF files and add `@font-face` rules to the HTML. The helper below extends [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/java/com.aspose.slides/embedallfontshtmlcontroller/) and overrides `writeFont`.

```java
class LinkedFontsHtmlController extends EmbedAllFontsHtmlController {
    private final java.nio.file.Path fontOutputDirectory;
    private final String fontUrlPrefix;

    LinkedFontsHtmlController(
            java.nio.file.Path fontOutputDirectory,
            String fontUrlPrefix) throws java.io.IOException {
        super(new String[0]);
        this.fontOutputDirectory = fontOutputDirectory;
        this.fontUrlPrefix = fontUrlPrefix.endsWith("/") ? fontUrlPrefix : fontUrlPrefix + "/";

        java.nio.file.Files.createDirectories(fontOutputDirectory);
    }

    @Override
    public void writeFont(
            IHtmlGenerator generator,
            IFontData originalFont,
            IFontData substitutedFont,
            String fontStyle,
            String fontWeight,
            byte[] fontData) {
        try {
            IFontData font = substitutedFont == null ? originalFont : substitutedFont;
            String safeFontName = makeSafeFileName(font.getFontName());
            String safeFontStyle = fontStyle == null || fontStyle.trim().isEmpty() ? "normal" : fontStyle;
            String safeFontWeight = fontWeight == null || fontWeight.trim().isEmpty() ? "normal" : fontWeight;
            String fontFileName = safeFontName + "-" + safeFontStyle + "-" + safeFontWeight + ".woff";
            java.nio.file.Path fontFilePath = fontOutputDirectory.resolve(fontFileName);

            java.nio.file.Files.write(fontFilePath, fontData);

            String encodedFontFileName = java.net.URLEncoder.encode(fontFileName, "UTF-8");
            String fontUrl = fontUrlPrefix + encodedFontFileName.replace("+", "%20");
            String escapedBackslashes = font.getFontName().replace("\\", "\\\\");
            String fontFamily = escapedBackslashes.replace("'", "\\'");

            generator.addHtml("<style>");
            generator.addHtml("@font-face {");
            generator.addHtml("font-family: '" + fontFamily + "';");
            generator.addHtml("font-style: " + safeFontStyle + ";");
            generator.addHtml("font-weight: " + safeFontWeight + ";");
            generator.addHtml("src: url('" + fontUrl + "') format('woff');");
            generator.addHtml("}");
            generator.addHtml("</style>");
        } catch (java.io.IOException exception) {
            throw new RuntimeException("Unable to write an exported font.", exception);
        }
    }

    private String makeSafeFileName(String fileName) {
        String invalidCharacters = "\\/:*?\"<>|";
        char[] safeCharacters = fileName.toCharArray();

        for (int characterIndex = 0; characterIndex < safeCharacters.length; characterIndex++) {
            if (invalidCharacters.indexOf(safeCharacters[characterIndex]) >= 0) {
                safeCharacters[characterIndex] = '_';
            }
        }

        return new String(safeCharacters);
    }
}

java.nio.file.Path outputDirectory = java.nio.file.Paths.get(System.getProperty("user.dir"), "html-output");
java.nio.file.Path fontsDirectory = outputDirectory.resolve("fonts");
java.nio.file.Files.createDirectories(outputDirectory);

Presentation presentation = new Presentation("presentation.pptx");
try {
    LinkedFontsHtmlController fontController = new LinkedFontsHtmlController(fontsDirectory, "fonts");
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(fontController);

    HtmlOptions htmlOptions = new HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    java.nio.file.Path htmlFilePath = outputDirectory.resolve("presentation.html");
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

In this example, font files are saved to `html-output/fonts`, and the HTML references them with URLs such as `fonts/BrandFont-normal-400.woff`. If the HTML file and fonts are deployed to another location, choose `fontUrlPrefix` so that it matches the deployed URL path.

## **Save Resources Externally**

Self-contained HTML is easy to move around, but embedded Base64 resources can make the file large. If your application needs external image files, implement [ILinkEmbedController](https://reference.aspose.com/slides/java/com.aspose.slides/ilinkembedcontroller/) and pass it to the [HtmlOptions](https://reference.aspose.com/slides/java/com.aspose.slides/htmloptions/) constructor.

When you externalize resources, choose two paths deliberately:

- The file system output path, where your application writes generated images, fonts, audio, or video.
- The URL path, which is what the browser uses from the HTML document to load those files.

## **Export Media Files**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/java/com.aspose.slides/videoplayerhtmlcontroller/) exports video and audio files and writes HTML that can play them in a browser. Its constructor takes:

- `path`: the directory where generated media files will be written.
- `fileName`: the HTML file name being generated.
- `baseUri`: the absolute URI prefix used in the HTML links to media files.

If the HTML file is `html-output/presentation.html` and media files are saved in `html-output/media`, `path` should point to the media directory on disk, while `baseUri` should point to the same directory from the browser's point of view. For local preview, you can build a `file:///` URI from the media directory. For a deployed application, use the absolute URL of the published media directory.

```java
java.nio.file.Path outputDirectory = java.nio.file.Paths.get(System.getProperty("user.dir"), "html-output");
java.nio.file.Path mediaDirectory = outputDirectory.resolve("media");
java.nio.file.Files.createDirectories(outputDirectory);
java.nio.file.Files.createDirectories(mediaDirectory);

String htmlFileName = "presentation.html";
String mediaBaseUri = mediaDirectory.toUri().toString();

Presentation presentation = new Presentation();
try {
    java.nio.file.Path videoFilePath = java.nio.file.Paths.get("intro.mp4");
    byte[] videoData = java.nio.file.Files.readAllBytes(videoFilePath);

    IVideo video = presentation.getVideos().addVideo(videoData);
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addVideoFrame(20, 20, 480, 270, video);

    String mediaDirectoryPath = mediaDirectory.toString();
    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(mediaDirectoryPath, htmlFileName, mediaBaseUri);
    HtmlFormatter formatter = HtmlFormatter.createCustomFormatter(controller);
    SVGOptions svgOptions = new SVGOptions(controller);
    SlideImageFormat slideImageFormat = SlideImageFormat.svg(svgOptions);

    HtmlOptions htmlOptions = new HtmlOptions(controller);
    htmlOptions.setHtmlFormatter(formatter);
    htmlOptions.setSlideImageFormat(slideImageFormat);

    java.nio.file.Path htmlFilePath = outputDirectory.resolve(htmlFileName);
    presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Use output directories that are unique per export job, especially in server applications. Shared output paths can cause files from different conversions to overwrite each other.

## **Performance and Resource Management**

HTML conversion is a rendering operation, so processing time and memory use depend on slide count, image resolution, fonts, effects, charts, and embedded media. Higher `PicturesCompression` DPI values, embedded fonts, SVG output, and retained cropped image areas can improve fidelity but usually increase output size.

For batch conversion:

- Dispose every [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) instance promptly.
- Use separate output directories for separate jobs.
- Avoid embedding common fonts unless fidelity requires it.
- Lower image DPI when the HTML is for preview or thumbnails.
- Keep the source presentation, generated HTML, and external resources together until deployment paths are final.

## **FAQ**

**Are hyperlinks preserved in HTML output?**

Yes. Presentation hyperlinks are exported to HTML and remain clickable when the target URL is valid.

**Can I convert presentations to HTML in parallel?**

Yes, but do not share one [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) instance across threads. Process different files with separate presentation instances, separate streams, and separate output directories. See the [multithreading guidance](/slides/java/multithreading/) for details.

**Is a Presentation object thread-safe?**

No. A single [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) instance should be loaded, modified, saved, and disposed on one thread. For parallel work, create an independent instance per thread or process.

**Why is the generated HTML file large?**

The default export can embed resources directly in the HTML. Embedded fonts, high-DPI images, media, SVG content, and retained cropped image areas also increase size. Use external resources, exclude common fonts from embedding, and lower `PicturesCompression` when smaller output is more important than maximum fidelity.

**How should I choose baseUri for media export?**

Choose `baseUri` from the browser's point of view and pass it as an absolute URI. For local preview, you can derive it from the output directory with `mediaDirectory.toUri().toString()`. For deployment, use the absolute URL of the published media directory. The file system `path` and browser `baseUri` do not have to be the same string, but they must describe the same resource location.

**Can I include hidden slides?**

Yes. Set `ShowHiddenSlides` to `true` on [HtmlOptions](https://reference.aspose.com/slides/java/com.aspose.slides/htmloptions/) when hidden slides must be exported.
