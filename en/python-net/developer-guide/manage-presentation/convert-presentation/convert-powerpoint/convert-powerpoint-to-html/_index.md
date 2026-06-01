---
title: Convert PowerPoint Presentations to HTML in Python
linktitle: PowerPoint to HTML
type: docs
weight: 30
url: /python-net/convert-powerpoint-to-html/
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
- Python
- Aspose.Slides
description: "Convert PowerPoint presentations to HTML in Python. Use Aspose.Slides to export PPT and PPTX files, selected slides, notes, fonts, images, SVG, and media."
---

## **Overview**

Aspose.Slides for Python via .NET can save PowerPoint presentations as HTML without Microsoft PowerPoint. The basic conversion is a single [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) load and a `save` call with [SaveFormat](https://reference.aspose.com/slides/python-net/aspose.slides.export/saveformat/). Use [HtmlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/) when you need to control the exported layout, fonts, images, notes, comments, SVG output, or linked resources.

This guide focuses on practical HTML export scenarios:

- Export a whole presentation or selected slides.
- Generate fixed-layout, responsive, or SVG-based HTML.
- Include speaker notes and comments.
- Control image quality and cropped image data.
- Embed fonts or save font files separately.
- Choose how external resources and media files are written and referenced.

By default, HTML export produces a self-contained HTML document where most resources are embedded. This is convenient for sharing one file, but it can increase output size. For web publishing, consider external resources, lower image DPI, and only embedding fonts that are not reliably available in the target environment.

## **Convert a Presentation to HTML**

To export a presentation to HTML, load it with [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) and save it with [SaveFormat](https://reference.aspose.com/slides/python-net/aspose.slides.export/saveformat/).

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.html", slides.export.SaveFormat.HTML)
```

This example writes one HTML file. The `with` statement disposes the presentation object and releases file handles and rendering resources after export.

## **Use HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/) is the main configuration class for HTML export. Common settings include:

- `slides_layout_options`: adds notes, comments, handouts, or other layout information.
- `html_formatter`: changes the HTML document structure or delegates formatting to a controller.
- `slide_image_format`: changes how slides are represented, for example as SVG.
- `pictures_compression`: controls image DPI and output size.
- `delete_pictures_cropped_areas`: keeps or removes cropped image data.
- `svg_responsive_layout`: makes exported SVG content adapt to its container.
- `show_hidden_slides`: includes hidden slides when required.

The following sections show the most common options separately so you can combine only the ones your workflow needs.

## **Convert Selected Slides to HTML**

The `save` overload that accepts slide numbers uses 1-based slide positions. The loop below saves every slide to a separate HTML file.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide_count = len(presentation.slides)

    for slide_index in range(slide_count):
        slide_number = slide_index + 1
        slide_numbers = [slide_number]
        html_file_name = "slide-{}.html".format(slide_number)

        presentation.save(html_file_name, slide_numbers, slides.export.SaveFormat.HTML)
```

Use this pattern when a website or application needs one HTML page per slide. If each slide should have the same layout, create one [HtmlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/) instance and pass it to each `save` call.

## **Create Responsive HTML**

[ResponsiveHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/responsivehtmlcontroller/) provides responsive HTML output through [HtmlFormatter](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmlformatter/). Use it when the exported page should adapt better to browser width.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    controller = slides.export.ResponsiveHtmlController()
    formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-responsive.html", slides.export.SaveFormat.HTML, html_options)
```

For SVG-based responsive layout, set `svg_responsive_layout` on [HtmlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/). This is useful when the slide content is exported as scalable SVG markup.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.svg_responsive_layout = True

    presentation.save("presentation-svg-responsive.html", slides.export.SaveFormat.HTML, html_options)
```

## **Include Speaker Notes and Comments**

Use [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/notescommentslayoutingoptions/) through `html_options.slides_layout_options` to include speaker notes or comments. Notes and comments are hidden by default unless you choose their positions.

Suppose the source presentation contains speaker notes:

![Slide with speaker notes in PowerPoint](slide_with_notes.png)

The following code exports the slide content with speaker notes below the slide.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    layout_options = slides.export.NotesCommentsLayoutingOptions()
    layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

    html_options = slides.export.HtmlOptions()
    html_options.slides_layout_options = layout_options

    presentation.save("presentation-with-notes.html", slides.export.SaveFormat.HTML, html_options)
```

The exported HTML includes the notes area:

![HTML output with the slide and speaker notes](HTML_with_notes.png)

To export comments, set `comments_position`, for example to `CommentsPositions.RIGHT` or `CommentsPositions.BOTTOM`. If you need only comments, omit `notes_position`. If you need both notes and comments, set both properties.

## **Control Image Quality and Cropped Areas**

HTML export can compress slide images to reduce output size. Set `pictures_compression` to a value from [PicturesCompression](https://reference.aspose.com/slides/python-net/aspose.slides.export/picturescompression/) when you need higher image quality.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.pictures_compression = slides.export.PicturesCompression.DPI150

    presentation.save("presentation-dpi-150.html", slides.export.SaveFormat.HTML, html_options)
```

By default, cropped areas of images may be removed from the exported output. Keep cropped data only when users must be able to recover or inspect those hidden image parts. Keeping it can increase the HTML size.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.delete_pictures_cropped_areas = False

    presentation.save("presentation-with-cropped-areas.html", slides.export.SaveFormat.HTML, html_options)
```

## **Add CSS**

For simple styling, pass a CSS string to [HtmlFormatter](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmlformatter/). This changes the surrounding HTML document while Aspose.Slides continues to render the slide content.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    css_rules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }"
    formatter = slides.export.HtmlFormatter.create_document_formatter(css_rules, True)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-styled.html", slides.export.SaveFormat.HTML, html_options)
```

For a custom document header, a linked CSS file, or custom markup around slides and shapes, use a custom formatting controller and pass it to [HtmlFormatter](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmlformatter/) with `create_custom_formatter`.

## **Embed Fonts**

If the target environment may not have the presentation fonts installed, embed fonts in the HTML with [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/). Embedding improves visual fidelity but increases output size.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    font_names_to_exclude = ["Arial"]
    font_controller = slides.export.EmbedAllFontsHtmlController(font_names_to_exclude)
    formatter = slides.export.HtmlFormatter.create_custom_formatter(font_controller)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-embedded-fonts.html", slides.export.SaveFormat.HTML, html_options)
```

Exclude a font only when you are confident that the target browsers or systems already provide it. For brand fonts or less common fonts, embedding is usually safer.

## **Link Font Files Instead of Embedding Them**

To reduce the HTML file size, you can write font data to separate WOFF files and add `@font-face` rules to the HTML. This requires a controller that customizes how font data is written during export. In Python via .NET, implement that controller in a small .NET helper assembly, load it in Python, and pass the helper object to [HtmlFormatter](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmlformatter/) with `create_custom_formatter`.

When you externalize fonts, choose two paths deliberately:

- The file system output directory where generated WOFF files will be written.
- The URL path that will appear in the HTML document and that the browser will use to load those font files.

Keep the HTML file and generated font files together until deployment paths are final. If the files are deployed to another location, make the URL prefix match the deployed URL path.

## **Save Resources Externally**

Self-contained HTML is easy to move around, but embedded Base64 resources can make the file large. If your application needs external image, font, audio, or video files, use a custom link/embed controller and pass it to the [HtmlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/) constructor.

When you externalize resources, choose two paths deliberately:

- The file system output path, where your application writes generated images, fonts, audio, or video.
- The URL path, which is what the browser uses from the HTML document to load those files.

For a full image-linking discussion, see [Export Presentations to HTML with Externally Linked Images](/slides/python-net/exporting-presentations-to-html-with-externally-linked-images/).

## **Export Media Files**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/videoplayerhtmlcontroller/) exports video and audio files and writes HTML that can play them in a browser. Its constructor takes:

- `path`: the directory where generated media files will be written.
- `file_name`: the HTML file name being generated.
- `base_uri`: the absolute URI prefix used in the HTML links to media files.

If the HTML file is `html-output/presentation.html` and media files are saved in `html-output/media`, `path` should point to the media directory on disk, while `base_uri` should point to the same directory from the browser's point of view. For local preview, you can build a `file:///` URI from the media directory. For a deployed application, use the absolute URL of the published media directory.

```python
import os
from pathlib import Path

import aspose.slides as slides

output_directory = os.path.join(os.getcwd(), "html-output")
media_directory = os.path.join(output_directory, "media")
os.makedirs(output_directory, exist_ok=True)
os.makedirs(media_directory, exist_ok=True)

html_file_name = "presentation.html"
media_base_uri = Path(media_directory).as_uri() + "/"

with slides.Presentation() as presentation:
    with open("intro.mp4", "rb") as video_stream:
        video = presentation.videos.add_video(
            video_stream,
            slides.LoadingStreamBehavior.READ_STREAM_AND_RELEASE)

    slide = presentation.slides[0]
    slide.shapes.add_video_frame(20, 20, 480, 270, video)

    controller = slides.export.VideoPlayerHtmlController(
        media_directory,
        html_file_name,
        media_base_uri)

    formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)
    svg_options = slides.export.SVGOptions(controller)
    slide_image_format = slides.export.SlideImageFormat.svg(svg_options)

    html_options = slides.export.HtmlOptions(controller)
    html_options.html_formatter = formatter
    html_options.slide_image_format = slide_image_format

    html_file_path = os.path.join(output_directory, html_file_name)
    presentation.save(html_file_path, slides.export.SaveFormat.HTML, html_options)
```

Use output directories that are unique per export job, especially in server applications. Shared output paths can cause files from different conversions to overwrite each other.

## **Performance and Resource Management**

HTML conversion is a rendering operation, so processing time and memory use depend on slide count, image resolution, fonts, effects, charts, and embedded media. Higher `pictures_compression` DPI values, embedded fonts, SVG output, and retained cropped image areas can improve fidelity but usually increase output size.

For batch conversion:

- Dispose every [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) instance promptly.
- Use separate output directories for separate jobs.
- Avoid embedding common fonts unless fidelity requires it.
- Lower image DPI when the HTML is for preview or thumbnails.
- Keep the source presentation, generated HTML, and external resources together until deployment paths are final.

## **FAQ**

**Are hyperlinks preserved in HTML output?**

Yes. Presentation hyperlinks are exported to HTML and remain clickable when the target URL is valid.

**Can I convert presentations to HTML in parallel?**

Yes, but do not share one [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) instance across threads. Process different files with separate presentation instances, separate streams, and separate output directories. See the [multithreading guidance](/slides/python-net/multithreading/) for details.

**Is a Presentation object thread-safe?**

No. A single [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) instance should be loaded, modified, saved, and disposed on one thread. For parallel work, create an independent instance per thread or process.

**Why is the generated HTML file large?**

The default export can embed resources directly in the HTML. Embedded fonts, high-DPI images, media, SVG content, and retained cropped image areas also increase size. Use external resources, exclude common fonts from embedding, and lower `pictures_compression` when smaller output is more important than maximum fidelity.

**How should I choose base_uri for media export?**

Choose `base_uri` from the browser's point of view and pass it as an absolute URI. For local preview, you can derive it from the output directory with `Path(media_directory).as_uri() + "/"`. For deployment, use the absolute URL of the published media directory. The file system `path` and browser `base_uri` do not have to be the same string, but they must describe the same resource location.

**Can I include hidden slides?**

Yes. Set `show_hidden_slides = True` on [HtmlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/) when hidden slides must be exported.
