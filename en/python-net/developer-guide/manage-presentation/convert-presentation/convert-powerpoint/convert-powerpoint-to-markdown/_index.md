---
title: Convert PowerPoint Presentations to Markdown in Python
linktitle: PowerPoint to Markdown
type: docs
weight: 140
url: /python-net/convert-powerpoint-to-markdown/
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
- Python
- Python via .NET
- Aspose.Slides
description: "Convert PPT and PPTX presentations to Markdown in Python and control where exported images are saved and how the generated Markdown references them."
---

## **Overview**

Aspose.Slides for Python via .NET can convert PPT and PPTX presentations to Markdown for documentation, static-site, content-migration, and version-control workflows. You can choose a Markdown flavor, control how slide content is rendered, and decide where exported images are stored and how the generated Markdown references them.

By default, Markdown export uses text-only output. To export visual content, set the [MarkdownSaveOptions.export_type](https://reference.aspose.com/slides/python-net/aspose.slides.export/markdownsaveoptions/export_type/) property to the `SEQUENTIAL` or `VISUAL` value from the [MarkdownExportType](https://reference.aspose.com/slides/python-net/aspose.slides.export/markdownexporttype/) enumeration. `SEQUENTIAL` renders slide items separately and in order, whereas `VISUAL` keeps grouped items together to preserve their visual relationship. The `TEXT_ONLY` value does not emit image resources.

## **Convert a Presentation to Markdown**

Load the source file with the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class, and then call the [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/ipresentation/save/) method with the `MD` value from the [SaveFormat](https://reference.aspose.com/slides/python-net/aspose.slides.export/saveformat/) enumeration.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD)
```

## **Select a Markdown Flavor**

The [MarkdownSaveOptions.flavor](https://reference.aspose.com/slides/python-net/aspose.slides.export/markdownsaveoptions/flavor/) property controls the Markdown specification used for the output. The [Flavor](https://reference.aspose.com/slides/python-net/aspose.slides.export/flavor/) enumeration includes CommonMark, GitHub Flavored Markdown, and other supported variants.

The following example exports a presentation as CommonMark:

```python
import aspose.slides as slides

options = slides.export.MarkdownSaveOptions()
options.flavor = slides.export.Flavor.COMMON_MARK

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD, options)
```

## **Control Repeated Spaces**

When preparing slide text for documentation, text processing, or publication, use [MarkdownSaveOptions.handle_repeated_spaces](https://reference.aspose.com/slides/python-net/aspose.slides.export/markdownsaveoptions/handle_repeated_spaces/) to control consecutive regular spaces.

Single spaces remain regular spaces in all three modes. The following self-contained example creates text with one, two, and three consecutive spaces and exports the same slide using each mode.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 600, 100)
    shape.text_frame.text = "One space; two  spaces; three   spaces."

    modes = [
        slides.export.HandleRepeatedSpaces.NONE,
        slides.export.HandleRepeatedSpaces.ALTERNATE_SPACES_TO_NBSP,
        slides.export.HandleRepeatedSpaces.MULTIPLE_SPACES_TO_NBSP
    ]

    for mode in modes:
        options = slides.export.MarkdownSaveOptions()
        options.flavor = slides.export.Flavor.COMMON_MARK
        options.handle_repeated_spaces = mode

        presentation.save(f"spaces-{mode.name}.md", slides.export.SaveFormat.MD, options)
```

The exported text lines are shown below. These excerpts omit the slide separator and the two trailing spaces added by the exporter.

`NONE`:

```markdown
One space; two  spaces; three   spaces.
```

`ALTERNATE_SPACES_TO_NBSP`:

```markdown
One space; two &nbsp;spaces; three &nbsp; spaces.
```

`MULTIPLE_SPACES_TO_NBSP`:

```markdown
One space; two &nbsp;spaces; three &nbsp;&nbsp;spaces.
```

In a typical HTML-based Markdown viewer, consecutive regular spaces collapse visually even though they remain in the source. Both replacement modes preserve the visible spacing in this example; their source differs for the three-space sequence.

Choose `NONE` when downstream tools need ordinary space characters without HTML entities. Choose a replacement mode when visible spacing matters more. A text-processing pipeline consuming that output may need to decode `&nbsp;` and normalize the resulting nonbreaking spaces. Nonbreaking spaces also affect where a viewer can wrap text.

## **Remove Empty Lines**

The [MarkdownSaveOptions.remove_empty_lines](https://reference.aspose.com/slides/python-net/aspose.slides.export/markdownsaveoptions/remove_empty_lines/) property controls whether empty or whitespace-only lines are removed during export. Its default value is `False`. This controls vertical separation, independently of how repeated spaces within text are represented.

The following example creates two text paragraphs separated by an empty paragraph and a paragraph containing three regular spaces. It exports both settings. The `\r` characters create paragraph boundaries in the text frame; `HandleRepeatedSpaces.NONE` makes the treatment of ordinary spaces easier to inspect.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 600, 300)

    # Include an empty paragraph and a paragraph containing three regular spaces.
    shape.text_frame.text = "First paragraph.\r\r   \rSecond paragraph."

    options = slides.export.MarkdownSaveOptions()
    options.flavor = slides.export.Flavor.COMMON_MARK
    options.handle_repeated_spaces = slides.export.HandleRepeatedSpaces.NONE
    options.remove_empty_lines = False

    presentation.save("empty-lines-kept.md", slides.export.SaveFormat.MD, options)

    options.remove_empty_lines = True
    presentation.save("empty-lines-removed.md", slides.export.SaveFormat.MD, options)
```

With `False`, the generated Markdown is:

```markdown
---  

First paragraph.  

&nbsp;
  
     
Second paragraph.  
```

With `True`, it becomes:

```markdown
---  

First paragraph.  
Second paragraph.  
```

With `remove_empty_lines = False`, the exported Markdown preserves the empty and whitespace-only paragraphs. The `&nbsp;` line represents an empty paragraph.

With `remove_empty_lines = True`, these blank paragraphs are removed. The two text paragraphs become a single Markdown paragraph with a line break between them. This line break is preserved by two trailing spaces after `First paragraph.`—Markdown syntax for a hard line break.

The slide separator (`---`) remains in both outputs. Keep `remove_empty_lines = False` when you need to preserve paragraph separation. If your presentation contains lists or code blocks, check the exported result in your target Markdown viewer, since blank lines can affect how that content is interpreted.

## **Export Images Using the Default Local-Saving Behavior**

The [MarkdownSaveOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/markdownsaveoptions/) class provides two properties for locally saved images:

- [base_path](https://reference.aspose.com/slides/python-net/aspose.slides.export/markdownsaveoptions/base_path/) specifies the base directory for the Markdown document and its resources.
- [images_save_folder_name](https://reference.aspose.com/slides/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/) specifies the image subdirectory. Its default value is `Images`.

The following example renders visual content, writes images to `output/assets`, and creates relative image references in the Markdown document:

```python
import os
import aspose.slides as slides

output_directory = "output"
os.makedirs(output_directory, exist_ok=True)

options = slides.export.MarkdownSaveOptions()
options.export_type = slides.export.MarkdownExportType.VISUAL
options.base_path = output_directory
options.images_save_folder_name = "assets"

markdown_path = os.path.join(output_directory, "presentation.md")

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save(markdown_path, slides.export.SaveFormat.MD, options)
```

Aspose.Slides creates the image subdirectory when the export produces image resources, but the application must create `base_path` before saving the Markdown file.

## **Prepare Markdown and Images for Publication**

Aspose.Slides for Python via .NET does not expose the .NET image-saving callbacks for replacing each generated image link during export. Instead, export the Markdown document and its image folder to a publication directory, and then publish that directory without changing its relative structure.

The following example prepares `cdn-origin/presentations/quarterly-report` as a mounted or synchronized publication directory. The sample itself performs no network upload: the generated links become valid after the directory is published at the intended site or CDN location.

```python
import os
import aspose.slides as slides

publication_directory = os.path.join(
    "cdn-origin",
    "presentations",
    "quarterly-report")
os.makedirs(publication_directory, exist_ok=True)

options = slides.export.MarkdownSaveOptions()
options.export_type = slides.export.MarkdownExportType.VISUAL
options.base_path = publication_directory
options.images_save_folder_name = "assets"

markdown_path = os.path.join(publication_directory, "presentation.md")

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save(markdown_path, slides.export.SaveFormat.MD, options)
```

Publish `presentation.md` together with the `assets` directory. The Markdown document uses relative image references, so both items must keep the same relationship at the destination. If a publishing system requires absolute external URLs, rewrite the generated links as a separate post-processing step after all image files have been published.

## **FAQ**

**Can Python callbacks customize individual image files and links during Markdown export?**

No. Aspose.Slides for Python via .NET does not expose the .NET `ImageSaving` and `SvgImageSaving` callbacks. Configure the local output with [MarkdownSaveOptions.base_path](https://reference.aspose.com/slides/python-net/aspose.slides.export/markdownsaveoptions/base_path/) and [MarkdownSaveOptions.images_save_folder_name](https://reference.aspose.com/slides/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/), then publish or post-process the generated resources.

**Where are exported images saved?**

The image location is controlled by [MarkdownSaveOptions.base_path](https://reference.aspose.com/slides/python-net/aspose.slides.export/markdownsaveoptions/base_path/) and [MarkdownSaveOptions.images_save_folder_name](https://reference.aspose.com/slides/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/). The Markdown document references those images with relative paths.

**Which path separator should image links use?**

Use forward slashes in Markdown links and URLs. Use `os.path.join` only for file-system paths, and normalize any link created during post-processing separately.

**Are hyperlinks preserved during Markdown export?**

Yes. Text [hyperlinks](/slides/python-net/manage-hyperlinks/) are preserved as standard Markdown links. Slide [transitions](/slides/python-net/slide-transition/) and [animations](/slides/python-net/powerpoint-animation/) are not converted.

**Can presentations be converted to Markdown in parallel?**

You can process different presentation files in parallel, but do not share the same [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) instance between threads. Follow the [multithreading guidelines](/slides/python-net/multithreading/) and use a separate instance for each file.
