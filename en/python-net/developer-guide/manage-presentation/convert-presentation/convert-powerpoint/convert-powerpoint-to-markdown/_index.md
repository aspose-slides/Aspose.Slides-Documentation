---
title: Convert PowerPoint Presentations to Markdown in Python
linktitle: PowerPoint to Markdown
type: docs
weight: 140
url: /python-net/convert-powerpoint-to-markdown/
keywords:
- convert PowerPoint to Markdown
- convert OpenDocument to Markdown
- convert presentation to Markdown
- convert slide to Markdown
- convert PPT to Markdown
- convert PPTX to Markdown
- convert ODP to Markdown
- convert PowerPoint to MD
- convert OpenDocument to MD
- convert presentation to MD
- convert slide to MD
- convert PPT to MD
- convert PPTX to MD
- convert ODP to MD
- PowerPoint
- OpenDocument
- presentation
- Markdown
- Python
- Aspose.Slides
description: "Convert PowerPoint and OpenDocument slides—PPT, PPTX, ODP—to clean Markdown with Aspose.Slides for Python via .NET, automate documentation and keep formatting."
---

## **Convert Presentations to Markdown**

The example below shows the simplest way to convert a PowerPoint presentation to Markdown using Aspose.Slides for Python via .NET with default settings.

1. Instantiate a [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) to load the presentation.
1. Call `save` to export it as a Markdown file.

Use the Python snippet below to perform the conversion:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:  
    presentation.save("presentation.md", slides.export.SaveFormat.MD)
```

## **Convert Presentations to Markdown Flavor**

Aspose.Slides allows you to convert presentations to Markdown formats, including basic Markdown, CommonMark, GitHub-flavored Markdown, Trello, XWiki, GitLab, and 17 other Markdown flavors.

The following Python example shows how to convert a PowerPoint presentation to CommonMark:

```python
import aspose.slides as slides

save_options = slides.export.MarkdownSaveOptions()
save_options.flavor = slides.export.Flavor.COMMON_MARK

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD, save_options)
```

The 23 supported Markdown flavors are listed in the [Flavor](https://reference.aspose.com/slides/python-net/aspose.slides.dom.export.markdown.saveoptions/flavor/) enumeration of the [MarkdownSaveOptions](https://reference.aspose.com/slides/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) class.

## **Convert Presentations Containing Images to Markdown**

The [MarkdownSaveOptions](https://reference.aspose.com/slides/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) class provides properties and enumerations that let you configure the resulting Markdown file. For example, the [MarkdownExportType](https://reference.aspose.com/slides/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) enum controls how images are handled: `SEQUENTIAL`, `TEXT_ONLY`, or `VISUAL`.

### **Convert Images Sequentially**

If you want images to appear individually—one after another—in the generated Markdown, choose the `SEQUENTIAL` option. The Python example below shows how to convert a presentation with images to Markdown.

```python
import aspose.slides as slides

save_options = slides.export.MarkdownSaveOptions()
save_options.show_hidden_slides = True
save_options.show_slide_number = True
save_options.flavor = slides.export.Flavor.GITHUB
save_options.export_type = slides.export.MarkdownExportType.SEQUENTIAL
save_options.new_line_type = slides.export.NewLineType.WINDOWS

slide_indices = [1, 3, 5]

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slide_indices, slides.export.SaveFormat.MD, save_options)
```

### **Convert Images Visually**

If you want the images to appear together in the resulting Markdown, choose the `VISUAL` option. In this mode, images are saved to the application’s current directory (and the Markdown document uses relative paths), or you can specify a custom output path and folder name.

The Python example below demonstrates this operation:

```python
import os
import aspose.slides as slides

save_options = slides.export.MarkdownSaveOptions()
save_options.export_type = slides.export.MarkdownExportType.VISUAL
save_options.images_save_folder_name = "md-images"
save_options.base_path = "c:\\documents"

with slides.Presentation("presentation.pptx") as presentation:
    file_path = os.path.join(save_options.base_path, "presentation.md")
    presentation.save(file_path, slides.export.SaveFormat.MD, save_options)
```

## **FAQ**

**Do hyperlinks survive the export to Markdown?**

Yes. Text [hyperlinks](/slides/python-net/manage-hyperlinks/) are preserved as standard Markdown links. Slide [transitions](/slides/python-net/slide-transition/) and [animations](/slides/python-net/powerpoint-animation/) are not converted.

**Can I speed up conversion by running it in multiple threads?**

You can parallelize across files, but [don’t share](/slides/python-net/multithreading/) the same [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) instance across threads. Use separate instances/processes per file to avoid contention.

**What happens to images—where are they saved, and are the paths relative?**

[Images](/slides/python-net/image/) are exported to a dedicated folder, and the Markdown file references them with relative paths by default. You can configure the base output path and asset folder name to keep a predictable repository structure.
