---
title: Convert PowerPoint Presentations to HTML in Node.js
linktitle: PowerPoint to HTML
type: docs
weight: 30
url: /nodejs-java/convert-powerpoint-to-html/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Convert PowerPoint presentations to HTML in Node.js. Use Aspose.Slides for Node.js via Java to export PPT and PPTX files, selected slides, notes, fonts, images, SVG, and media."
---

## **Overview**

Aspose.Slides for Node.js via Java can save PowerPoint presentations as HTML without Microsoft PowerPoint. The basic conversion is a single [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) load and a `save` call with [SaveFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveformat/). Use [HtmlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/htmloptions/) when you need to control the exported layout, fonts, images, notes, comments, SVG output, or linked resources.

This guide focuses on practical HTML export scenarios:

- Export a whole presentation or selected slides.
- Generate fixed-layout, responsive, or SVG-based HTML.
- Include speaker notes and comments.
- Control image quality and cropped image data.
- Embed fonts or save font files separately.
- Choose how external resources and media files are written and referenced.

By default, HTML export produces a self-contained HTML document where most resources are embedded. This is convenient for sharing one file, but it can increase output size. For web publishing, consider external resources, lower image DPI, and only embedding fonts that are not reliably available in the target environment.

## **Convert a Presentation to HTML**

To export a presentation to HTML, load it with [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) and save it with [SaveFormat.Html](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveformat/).

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.html", aspose.slides.SaveFormat.Html);
} finally {
    presentation.dispose();
}
```

This example writes one HTML file. The presentation object is disposed in the `finally` block, which releases file handles and rendering resources after export.

## **Use HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/htmloptions/) is the main configuration class for HTML export. Common settings include:

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

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideCount = presentation.getSlides().size();

    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        let slideNumber = slideIndex + 1;
        let slideNumbers = java.newArray("int", [slideNumber]);
        let htmlFileName = "slide-" + slideNumber + ".html";

        presentation.save(htmlFileName, slideNumbers, aspose.slides.SaveFormat.Html);
    }
} finally {
    presentation.dispose();
}
```

Use this pattern when a website or application needs one HTML page per slide. If each slide should have the same layout, create one [HtmlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/htmloptions/) instance and pass it to each `save` call.

## **Create Responsive HTML**

[ResponsiveHtmlController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/responsivehtmlcontroller/) provides responsive HTML output through [HtmlFormatter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/htmlformatter/). Use it when the exported page should adapt better to browser width.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let controller = new aspose.slides.ResponsiveHtmlController();
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(controller);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-responsive.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

For SVG-based responsive layout, set `SvgResponsiveLayout` on [HtmlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/htmloptions/). This is useful when the slide content is exported as scalable SVG markup.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setSvgResponsiveLayout(true);

    presentation.save("presentation-svg-responsive.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **Include Speaker Notes and Comments**

Use [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notescommentslayoutingoptions/) through `HtmlOptions.setSlidesLayoutOptions` to include speaker notes or comments. Notes and comments are hidden by default unless you choose their positions.

Suppose the source presentation contains speaker notes:

![Slide with speaker notes in PowerPoint](slide_with_notes.png)

The following code exports the slide content with speaker notes below the slide.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let layoutOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    layoutOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setSlidesLayoutOptions(layoutOptions);

    presentation.save("presentation-with-notes.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

The exported HTML includes the notes area:

![HTML output with the slide and speaker notes](HTML_with_notes.png)

To export comments, set `CommentsPosition`, for example to `CommentsPositions.Right` or `CommentsPositions.Bottom`. If you need only comments, omit `NotesPosition`. If you need both notes and comments, set both properties.

## **Control Image Quality and Cropped Areas**

HTML export can compress slide images to reduce output size. Set `PicturesCompression` to a value from [PicturesCompression](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturescompression/) when you need higher image quality.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setPicturesCompression(aspose.slides.PicturesCompression.Dpi150);

    presentation.save("presentation-dpi-150.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

By default, cropped areas of images may be removed from the exported output. Keep cropped data only when users must be able to recover or inspect those hidden image parts. Keeping it can increase the HTML size.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setDeletePicturesCroppedAreas(false);

    presentation.save("presentation-with-cropped-areas.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

## **Add CSS**

For simple styling, pass a CSS string to `HtmlFormatter.createDocumentFormatter`. This changes the surrounding HTML document while Aspose.Slides continues to render the slide content.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
    let formatter = aspose.slides.HtmlFormatter.createDocumentFormatter(cssRules, true);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-styled.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

For a custom document header, a linked CSS file, or custom markup around slides and shapes, use [HtmlFormatter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/htmlformatter/) with a formatting controller.

## **Embed Fonts**

If the target environment may not have the presentation fonts installed, embed fonts in the HTML with [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/embedallfontshtmlcontroller/). Embedding improves visual fidelity but increases output size.

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let fontNamesToExclude = java.newArray("java.lang.String", ["Arial"]);
    let fontController = new aspose.slides.EmbedAllFontsHtmlController(fontNamesToExclude);
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(fontController);

    let htmlOptions = new aspose.slides.HtmlOptions();
    htmlOptions.setHtmlFormatter(formatter);

    presentation.save("presentation-embedded-fonts.html", aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Exclude fonts only when you are confident that the target browsers or systems already provide them. For brand fonts or less common fonts, embedding is usually safer.

## **Link Font Files Instead of Embedding Them**

To reduce the HTML file size, you can write font data to separate WOFF files and add `@font-face` rules to the HTML. In Node.js via Java, this scenario is usually implemented with a small Java helper class that extends [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/embedallfontshtmlcontroller/), writes font bytes to an output directory, and injects `@font-face` rules into the generated HTML. Compile that helper, add it to the Node.js module classpath, and then instantiate it from JavaScript with `java.newInstanceSync`.

When you build such a helper, choose two paths deliberately:

- The file system output path, where generated font files are written.
- The URL path, which is what the browser uses from the HTML document to load those font files.

## **Save Resources Externally**

Self-contained HTML is easy to move around, but embedded Base64 resources can make the file large. If your application needs external image, font, audio, or video files, use an export controller that writes resources to a chosen directory and emits browser-visible URLs. Keep the file system path and URL path aligned with your deployment layout.

## **Export Media Files**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoplayerhtmlcontroller/) exports video and audio files and writes HTML that can play them in a browser. Its constructor takes:

- `path`: the directory where generated media files will be written.
- `fileName`: the HTML file name being generated.
- `baseUri`: the absolute URI prefix used in the HTML links to media files.

If the HTML file is `html-output/presentation.html` and media files are saved in `html-output/media`, `path` should point to the media directory on disk, while `baseUri` should point to the same directory from the browser's point of view. For local preview, you can build a `file:///` URI from the media directory. For a deployed application, use the absolute URL of the published media directory.

```javascript
let fs = require("fs");
let path = require("path");

let outputDirectory = path.join(process.cwd(), "html-output");
let mediaDirectory = path.join(outputDirectory, "media");
fs.mkdirSync(mediaDirectory, { recursive: true });

let htmlFileName = "presentation.html";
let mediaBaseUri = "file:///" + mediaDirectory.replace(/\\/g, "/") + "/";

let presentation = new aspose.slides.Presentation();
try {
    let videoFilePath = path.join(process.cwd(), "intro.mp4");
    let videoBytes = Array.from(fs.readFileSync(videoFilePath));
    let videoData = java.newArray("byte", videoBytes);

    let video = presentation.getVideos().addVideo(videoData);
    let slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addVideoFrame(20, 20, 480, 270, video);

    let controller = new aspose.slides.VideoPlayerHtmlController(mediaDirectory, htmlFileName, mediaBaseUri);
    let formatter = aspose.slides.HtmlFormatter.createCustomFormatter(controller);
    let svgOptions = new aspose.slides.SVGOptions(controller);
    let slideImageFormat = aspose.slides.SlideImageFormat.svg(svgOptions);

    let htmlOptions = new aspose.slides.HtmlOptions(controller);
    htmlOptions.setHtmlFormatter(formatter);
    htmlOptions.setSlideImageFormat(slideImageFormat);

    let htmlFilePath = path.join(outputDirectory, htmlFileName);
    presentation.save(htmlFilePath, aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    presentation.dispose();
}
```

Use output directories that are unique per export job, especially in server applications. Shared output paths can cause files from different conversions to overwrite each other.

## **Performance and Resource Management**

HTML conversion is a rendering operation, so processing time and memory use depend on slide count, image resolution, fonts, effects, charts, and embedded media. Higher `PicturesCompression` DPI values, embedded fonts, SVG output, and retained cropped image areas can improve fidelity but usually increase output size.

For batch conversion:

- Dispose every [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) instance promptly.
- Use separate output directories for separate jobs.
- Avoid embedding common fonts unless fidelity requires it.
- Lower image DPI when the HTML is for preview or thumbnails.
- Keep the source presentation, generated HTML, and external resources together until deployment paths are final.

## **FAQ**

**Are hyperlinks preserved in HTML output?**

Yes. Presentation hyperlinks are exported to HTML and remain clickable when the target URL is valid.

**Can I convert presentations to HTML in parallel?**

Yes, but do not share one [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) instance across workers. Process different files with separate presentation instances, separate streams, and separate output directories. See the [multithreading guidance](/slides/nodejs-java/multithreading/) for details.

**Is a Presentation object thread-safe?**

No. A single [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) instance should be loaded, modified, saved, and disposed in one worker. For parallel work, create an independent instance per worker or process.

**Why is the generated HTML file large?**

The default export can embed resources directly in the HTML. Embedded fonts, high-DPI images, media, SVG content, and retained cropped image areas also increase size. Use external resources, exclude common fonts from embedding, and lower `PicturesCompression` when smaller output is more important than maximum fidelity.

**Why does a PowerPoint font size such as 24 pt appear as 17.999819 pt in HTML?**

This can happen because PowerPoint and HTML use different DPI models. PowerPoint stores text sizes in typographic points based on 72 DPI, while HTML layout is based on CSS pixels in a 96 DPI model. When Aspose.Slides exports a presentation to HTML, the font size is translated between these systems, and the conversion may introduce small rounding differences.

These values do not indicate a real visual font-size change. They are only a mathematical side effect of converting text metrics between PowerPoint and HTML.

**How should I choose baseUri for media export?**

Choose `baseUri` from the browser's point of view and pass it as an absolute URI. For local preview, you can derive it from the output directory with a `file:///` URI. For deployment, use the absolute URL of the published media directory. The file system `path` and browser `baseUri` do not have to be the same string, but they must describe the same resource location.

**Can I include hidden slides?**

Yes. Set `ShowHiddenSlides` to `true` on [HtmlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/htmloptions/) when hidden slides must be exported.
