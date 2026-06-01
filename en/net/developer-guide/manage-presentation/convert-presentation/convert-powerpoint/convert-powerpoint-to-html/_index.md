---
title: Convert PowerPoint Presentations to HTML in .NET
linktitle: PowerPoint to HTML
type: docs
weight: 30
url: /net/convert-powerpoint-to-html/
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
- .NET
- C#
- Aspose.Slides
description: "Convert PowerPoint presentations to HTML in .NET. Use Aspose.Slides to export PPT and PPTX files, selected slides, notes, fonts, images, SVG, and media."
---

## **Overview**

Aspose.Slides for .NET can save PowerPoint presentations as HTML without Microsoft PowerPoint. The basic conversion is a single [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) load and a [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) call with [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/). Use [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions/) when you need to control the exported layout, fonts, images, notes, comments, SVG output, or linked resources.

This guide focuses on practical HTML export scenarios:

- Export a whole presentation or selected slides.
- Generate fixed-layout, responsive, or SVG-based HTML.
- Include speaker notes and comments.
- Control image quality and cropped image data.
- Embed fonts or save font files separately.
- Choose how external resources and media files are written and referenced.

By default, HTML export produces a self-contained HTML document where most resources are embedded. This is convenient for sharing one file, but it can increase output size. For web publishing, consider external resources, lower image DPI, and only embedding fonts that are not reliably available in the target environment.

## **Convert a Presentation to HTML**

To export a presentation to HTML, load it with [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) and save it with [SaveFormat.Html](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/).

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.Save("presentation.html", SaveFormat.Html);
```

This example writes one HTML file. The presentation object is disposed by the `using` declaration, which releases file handles and rendering resources after export.

## **Use HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions/) is the main configuration class for HTML export. Common settings include:

- `SlidesLayoutOptions`: adds notes, comments, handouts, or other layout information.
- `HtmlFormatter`: changes the HTML document structure or delegates formatting to a controller.
- `SlideImageFormat`: changes how slides are represented, for example as SVG.
- `PicturesCompression`: controls image DPI and output size.
- `DeletePicturesCroppedAreas`: keeps or removes cropped image data.
- `SvgResponsiveLayout`: makes exported SVG content adapt to its container.
- `ShowHiddenSlides`: includes hidden slides when required.

The following sections show the most common options separately so you can combine only the ones your workflow needs.

## **Convert Selected Slides to HTML**

The [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) overload that accepts slide numbers uses 1-based slide positions. The loop below saves every slide to a separate HTML file.

```csharp
using var presentation = new Presentation("presentation.pptx");

var slideCount = presentation.Slides.Count;

for (var slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    var slideNumber = slideIndex + 1;
    var slideNumbers = new[] { slideNumber };
    var htmlFileName = $"slide-{slideNumber}.html";

    presentation.Save(htmlFileName, slideNumbers, SaveFormat.Html);
}
```

Use this pattern when a website or application needs one HTML page per slide. If each slide should have the same layout, create one [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions/) instance and pass it to each `Save` call.

## **Create Responsive HTML**

[ResponsiveHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/responsivehtmlcontroller/) provides responsive HTML output through [HtmlFormatter](https://reference.aspose.com/slides/net/aspose.slides.export/htmlformatter/). Use it when the exported page should adapt better to browser width.

```csharp
using var presentation = new Presentation("presentation.pptx");

var controller = new ResponsiveHtmlController();
var formatter = HtmlFormatter.CreateCustomFormatter(controller);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

presentation.Save("presentation-responsive.html", SaveFormat.Html, htmlOptions);
```

For SVG-based responsive layout, set `SvgResponsiveLayout` on [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions/). This is useful when the slide content is exported as scalable SVG markup.

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    SvgResponsiveLayout = true
};

presentation.Save("presentation-svg-responsive.html", SaveFormat.Html, htmlOptions);
```

## **Include Speaker Notes and Comments**

Use [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/) through `HtmlOptions.SlidesLayoutOptions` to include speaker notes or comments. Notes and comments are hidden by default unless you choose their positions.

Suppose the source presentation contains speaker notes:

![Slide with speaker notes in PowerPoint](slide_with_notes.png)

The following code exports the slide content with speaker notes below the slide.

```csharp
using var presentation = new Presentation("presentation.pptx");

var layoutOptions = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomFull
};

var htmlOptions = new HtmlOptions
{
    SlidesLayoutOptions = layoutOptions
};

presentation.Save("presentation-with-notes.html", SaveFormat.Html, htmlOptions);
```

The exported HTML includes the notes area:

![HTML output with the slide and speaker notes](HTML_with_notes.png)

To export comments, set `CommentsPosition`, for example to `CommentsPositions.Right` or `CommentsPositions.Bottom`. If you need only comments, omit `NotesPosition`. If you need both notes and comments, set both properties.

## **Control Image Quality and Cropped Areas**

HTML export can compress slide images to reduce output size. Set `PicturesCompression` to a value from [PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/picturescompression/) when you need higher image quality.

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    PicturesCompression = PicturesCompression.Dpi150
};

presentation.Save("presentation-dpi-150.html", SaveFormat.Html, htmlOptions);
```

By default, cropped areas of images may be removed from the exported output. Keep cropped data only when users must be able to recover or inspect those hidden image parts. Keeping it can increase the HTML size.

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    DeletePicturesCroppedAreas = false
};

presentation.Save("presentation-with-cropped-areas.html", SaveFormat.Html, htmlOptions);
```

## **Add CSS**

For simple styling, pass a CSS string to [HtmlFormatter.CreateDocumentFormatter](https://reference.aspose.com/slides/net/aspose.slides.export/htmlformatter/createdocumentformatter/). This changes the surrounding HTML document while Aspose.Slides continues to render the slide content.

```csharp
using var presentation = new Presentation("presentation.pptx");

var cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
var formatter = HtmlFormatter.CreateDocumentFormatter(cssRules, true);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

presentation.Save("presentation-styled.html", SaveFormat.Html, htmlOptions);
```

For a custom document header, a linked CSS file, or custom markup around slides and shapes, implement [IHtmlFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/ihtmlformattingcontroller/) and pass it to [HtmlFormatter](https://reference.aspose.com/slides/net/aspose.slides.export/htmlformatter/) with `CreateCustomFormatter`.

## **Embed Fonts**

If the target environment may not have the presentation fonts installed, embed fonts in the HTML with [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller/). Embedding improves visual fidelity but increases output size.

```csharp
using var presentation = new Presentation("presentation.pptx");

string[] fontNamesToExclude = { "Arial", "Calibri" };
var fontController = new EmbedAllFontsHtmlController(fontNamesToExclude);
var formatter = HtmlFormatter.CreateCustomFormatter(fontController);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

presentation.Save("presentation-embedded-fonts.html", SaveFormat.Html, htmlOptions);
```

Exclude fonts only when you are confident that the target browsers or systems already provide them. For brand fonts or less common fonts, embedding is usually safer.

## **Link Font Files Instead of Embedding Them**

To reduce the HTML file size, you can write font data to separate WOFF files and add `@font-face` rules to the HTML. The helper below extends [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/embedallfontshtmlcontroller/) and overrides `WriteFont`.

```cs
using var presentation = new Presentation("presentation.pptx");

var outputDirectory = Path.Combine(Environment.CurrentDirectory, "html-output");
var fontsDirectory = Path.Combine(outputDirectory, "fonts");
Directory.CreateDirectory(outputDirectory);

var fontController = new LinkedFontsHtmlController(fontsDirectory, "fonts");
var formatter = HtmlFormatter.CreateCustomFormatter(fontController);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

var htmlFilePath = Path.Combine(outputDirectory, "presentation.html");
presentation.Save(htmlFilePath, SaveFormat.Html, htmlOptions);
```

```cs
public sealed class LinkedFontsHtmlController : EmbedAllFontsHtmlController
{
    private readonly string _fontOutputDirectory;
    private readonly string _fontUrlPrefix;

    public LinkedFontsHtmlController(
        string fontOutputDirectory,
        string fontUrlPrefix)
        : base(Array.Empty<string>())
    {
        _fontOutputDirectory = fontOutputDirectory;
        _fontUrlPrefix = fontUrlPrefix.TrimEnd('/') + "/";

        Directory.CreateDirectory(_fontOutputDirectory);
    }

    public override void WriteFont(
        IHtmlGenerator generator,
        IFontData originalFont,
        IFontData substitutedFont,
        string fontStyle,
        string fontWeight,
        byte[] fontData)
    {
        var font = substitutedFont ?? originalFont;
        var safeFontName = MakeSafeFileName(font.FontName);
        var safeFontStyle = string.IsNullOrWhiteSpace(fontStyle) ? "normal" : fontStyle;
        var safeFontWeight = string.IsNullOrWhiteSpace(fontWeight) ? "normal" : fontWeight;
        var fontFileName = $"{safeFontName}-{safeFontStyle}-{safeFontWeight}.woff";
        var fontFilePath = Path.Combine(_fontOutputDirectory, fontFileName);

        File.WriteAllBytes(fontFilePath, fontData);

        var fontUrl = _fontUrlPrefix + Uri.EscapeDataString(fontFileName);
        var fontFamily = font.FontName.Replace("\\", "\\\\").Replace("'", "\\'");

        generator.AddHtml("<style>");
        generator.AddHtml("@font-face {");
        generator.AddHtml($"font-family: '{fontFamily}';");
        generator.AddHtml($"font-style: {safeFontStyle};");
        generator.AddHtml($"font-weight: {safeFontWeight};");
        generator.AddHtml($"src: url('{fontUrl}') format('woff');");
        generator.AddHtml("}");
        generator.AddHtml("</style>");
    }

    private static string MakeSafeFileName(string fileName)
    {
        var invalidCharacters = Path.GetInvalidFileNameChars();
        var safeCharacters = fileName.ToCharArray();

        for (var characterIndex = 0; characterIndex < safeCharacters.Length; characterIndex++)
        {
            if (Array.IndexOf(invalidCharacters, safeCharacters[characterIndex]) >= 0)
            {
                safeCharacters[characterIndex] = '_';
            }
        }

        return new string(safeCharacters);
    }
}
```

In this example, font files are saved to `html-output/fonts`, and the HTML references them with URLs such as `fonts/BrandFont-normal-400.woff`. If the HTML file and fonts are deployed to another location, choose `fontUrlPrefix` so that it matches the deployed URL path.

## **Save Resources Externally**

Self-contained HTML is easy to move around, but embedded Base64 resources can make the file large. If your application needs external image files, implement [ILinkEmbedController](https://reference.aspose.com/slides/net/aspose.slides.export/ilinkembedcontroller/) and pass it to the [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions/htmloptions/) constructor.

When you externalize resources, choose two paths deliberately:

- The file system output path, where your application writes generated images, fonts, audio, or video.
- The URL path, which is what the browser uses from the HTML document to load those files.

For a full image-linking implementation, see [Export Presentations to HTML with Externally Linked Images](/slides/net/exporting-presentations-to-html-with-externally-linked-images/).

## **Export Media Files**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/net/aspose.slides.export/videoplayerhtmlcontroller/) exports video and audio files and writes HTML that can play them in a browser. Its constructor takes:

- `path`: the directory where generated media files will be written.
- `fileName`: the HTML file name being generated.
- `baseUri`: the absolute URI prefix used in the HTML links to media files.

If the HTML file is `html-output/presentation.html` and media files are saved in `html-output/media`, `path` should point to the media directory on disk, while `baseUri` should point to the same directory from the browser's point of view. For local preview, you can build a `file:///` URI from the media directory. For a deployed application, use the absolute URL of the published media directory.

```csharp
var outputDirectory = Path.Combine(Environment.CurrentDirectory, "html-output");
var mediaDirectory = Path.Combine(outputDirectory, "media");
Directory.CreateDirectory(outputDirectory);
Directory.CreateDirectory(mediaDirectory);

var htmlFileName = "presentation.html";
var mediaBaseUri = new Uri(mediaDirectory + Path.DirectorySeparatorChar).AbsoluteUri;

using var presentation = new Presentation();
using var videoStream = new FileStream("intro.mp4", FileMode.Open, FileAccess.Read);

var video = presentation.Videos.AddVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
var slide = presentation.Slides[0];
slide.Shapes.AddVideoFrame(20, 20, 480, 270, video);

var controller = new VideoPlayerHtmlController(mediaDirectory, htmlFileName, mediaBaseUri);
var formatter = HtmlFormatter.CreateCustomFormatter(controller);
var svgOptions = new SVGOptions(controller);
var slideImageFormat = SlideImageFormat.Svg(svgOptions);

var htmlOptions = new HtmlOptions(controller)
{
    HtmlFormatter = formatter,
    SlideImageFormat = slideImageFormat
};

var htmlFilePath = Path.Combine(outputDirectory, htmlFileName);
presentation.Save(htmlFilePath, SaveFormat.Html, htmlOptions);
```

Use output directories that are unique per export job, especially in server applications. Shared output paths can cause files from different conversions to overwrite each other.

## **Performance and Resource Management**

HTML conversion is a rendering operation, so processing time and memory use depend on slide count, image resolution, fonts, effects, charts, and embedded media. Higher `PicturesCompression` DPI values, embedded fonts, SVG output, and retained cropped image areas can improve fidelity but usually increase output size.

For batch conversion:

- Dispose every [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) instance promptly.
- Use separate output directories for separate jobs.
- Avoid embedding common fonts unless fidelity requires it.
- Lower image DPI when the HTML is for preview or thumbnails.
- Keep the source presentation, generated HTML, and external resources together until deployment paths are final.

## **FAQ**

**Are hyperlinks preserved in HTML output?**

Yes. Presentation hyperlinks are exported to HTML and remain clickable when the target URL is valid.

**Can I convert presentations to HTML in parallel?**

Yes, but do not share one [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) instance across threads. Process different files with separate presentation instances, separate streams, and separate output directories. See the [multithreading guidance](/slides/net/multithreading/) for details.

**Is a Presentation object thread-safe?**

No. A single [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) instance should be loaded, modified, saved, and disposed on one thread. For parallel work, create an independent instance per thread or process.

**Why is the generated HTML file large?**

The default export can embed resources directly in the HTML. Embedded fonts, high-DPI images, media, SVG content, and retained cropped image areas also increase size. Use external resources, exclude common fonts from embedding, and lower `PicturesCompression` when smaller output is more important than maximum fidelity.

**How should I choose baseUri for media export?**

Choose `baseUri` from the browser's point of view and pass it as an absolute URI. For local preview, you can derive it from the output directory with `new Uri(mediaDirectory + Path.DirectorySeparatorChar).AbsoluteUri`. For deployment, use the absolute URL of the published media directory. The file system `path` and browser `baseUri` do not have to be the same string, but they must describe the same resource location.

**Can I include hidden slides?**

Yes. Set `ShowHiddenSlides = true` on [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions/) when hidden slides must be exported.
