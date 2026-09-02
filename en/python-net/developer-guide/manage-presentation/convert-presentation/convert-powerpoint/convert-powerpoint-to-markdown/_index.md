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
