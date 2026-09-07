---
title: Convert PowerPoint Presentations to Markdown in Python via Java
linktitle: PowerPoint to Markdown
type: docs
weight: 140
url: /python-java/convert-powerpoint-to-markdown/
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
- Java
- Aspose.Slides
description: "Convert PPT and PPTX presentations to Markdown in Python via Java and control where exported bitmap, metafile, and SVG images are saved and referenced."
---

## **Overview**

Aspose.Slides for Python via Java can convert PPT and PPTX presentations to Markdown for documentation, static-site, content-migration, and version-control workflows. You can choose a Markdown flavor, control how slide content is rendered, and decide where exported images are stored and how the generated Markdown references them.

By default, Markdown export uses text-only output. To export visual content, set the export type with the [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/python-java/aspose.slides/markdownsaveoptions/#setExportType) method to the `Sequential` or `Visual` value from the [MarkdownExportType](https://reference.aspose.com/slides/python-java/aspose.slides/markdownexporttype/) enumeration. `Sequential` renders slide items separately and in order, whereas `Visual` keeps grouped items together to preserve their visual relationship. The `TextOnly` value does not emit image resources, so the image-saving callbacks are not invoked in that mode.

## **Convert a Presentation to Markdown**

Load the source file with the [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) class, and then call the [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) method with the `Md` value from the [SaveFormat](https://reference.aspose.com/slides/python-java/aspose.slides/saveformat/) enumeration.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.md", SaveFormat.Md)
finally:
    presentation.dispose()
```

Each example reads `presentation.pptx` from the current working directory. Install Aspose.Slides for Python via Java and a compatible Java runtime before running the examples. Start the JVM once per Python process.

## **Select a Markdown Flavor**

The [MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/python-java/aspose.slides/markdownsaveoptions/#setFlavor) method controls the Markdown specification used for the output. The [Flavor](https://reference.aspose.com/slides/python-java/aspose.slides/flavor/) enumeration includes CommonMark, GitHub Flavored Markdown, and other supported variants.

The following example exports a presentation as CommonMark:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Flavor, MarkdownSaveOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setFlavor(Flavor.CommonMark)

    presentation.save("presentation.md", SaveFormat.Md, options)
finally:
    presentation.dispose()
```

## **Export Images Using the Default Local-Saving Behavior**

The [MarkdownSaveOptions](https://reference.aspose.com/slides/python-java/aspose.slides/markdownsaveoptions/) class provides two methods for configuring locally saved images:

- [setBasePath](https://reference.aspose.com/slides/python-java/aspose.slides/markdownsaveoptions/#setBasePath) specifies the base directory for the Markdown document and its resources.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName) specifies the image subdirectory. Its default value is `Images`.

The following example renders visual content, writes images to `output/assets`, and creates relative image references in the Markdown document:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import MarkdownExportType, MarkdownSaveOptions, Presentation, SaveFormat

output_directory = Path("output")
output_directory.mkdir(parents=True, exist_ok=True)

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setExportType(MarkdownExportType.Visual)
    options.setBasePath(str(output_directory))
    options.setImagesSaveFolderName("assets")

    markdown_path = output_directory / "presentation.md"
    presentation.save(str(markdown_path), SaveFormat.Md, options)
finally:
    presentation.dispose()
```

This behavior also serves as the fallback when a custom image-saving handler returns `False`.

## **Customize Image Saving and Markdown Links**

Use the [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/python-java/aspose.slides/markdownsaveoptions/) method to register a callback for non-SVG bitmap and metafile resources emitted during Markdown export. Its `MarkdownImageSavingHandler` callback receives the image object, its [ImageFormat](https://reference.aspose.com/slides/python-java/aspose.slides/imageformat/) value, and the generated Markdown link as a one-element `String[]` parameter. Save or upload the image with the supplied format, and replace `link[0]` with the reference that must appear in the Markdown output.

Resources emitted in SVG format are handled separately. Register a callback with the [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/python-java/aspose.slides/markdownsaveoptions/) method. Its `MarkdownSvgImageSavingHandler` callback receives an [SvgImage](https://reference.aspose.com/slides/python-java/aspose.slides/svgimage/) object and the one-element `String[] link` parameter. An SVG has no `ImageFormat` argument; write or upload its XML data from the [SvgImage.getSvgData](https://reference.aspose.com/slides/python-java/aspose.slides/svgimage/#getSvgData) method instead. Depending on the export mode and visual grouping, an SVG in the source presentation can be rasterized or combined with other content; the resulting non-SVG resource is then passed to the image-saving callback. Register both callbacks when every exported visual resource requires custom processing.

The handler return value determines who processes the image:

- Return `True` after the handler has saved, uploaded, transformed, or otherwise processed the image and assigned a valid value to `link[0]`. Aspose.Slides writes that value to the Markdown document and does not perform its default local save.
- Return `False` to let Aspose.Slides save the image locally and generate its link according to the values set by [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/python-java/aspose.slides/markdownsaveoptions/#setBasePath) and [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName).

{{% alert color="danger" title="Important" %}}

A handler that returns `True` takes responsibility for the image. If it returns `True` without assigning a valid, nonempty link, the export fails with an `InvalidOperationException`.

{{% /alert %}}

In Python, register these callbacks with `jpype.JProxy`, implementing the Java callback interface through its `invoke` method. The `link` argument is a mutable Java string array: convert `link[0]` to a Python string before processing it, then assign the replacement URL back to `link[0]`.

### **Save Images to a CDN Origin Directory and Use External URLs**

The following example treats `cdn-origin/presentations/quarterly-report` as a mounted or synchronized CDN origin directory. Each handler extracts the generated file name, saves the image to that custom directory, and replaces the generated local reference with a public CDN URL. The sample itself performs no network upload: the URL becomes valid only after the directory is mounted as the CDN origin or its files are published to the CDN. For object storage, replace the file-system write with the storage SDK's upload operation and assign `link[0]` only after the upload succeeds.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from urllib.parse import quote
from asposeslides.api import MarkdownExportType, MarkdownSaveOptions, Presentation, SaveFormat

output_directory = Path("output")
public_base_url = "https://cdn.example.com/presentations/quarterly-report"
storage_directory = Path("cdn-origin", "presentations", "quarterly-report")
output_directory.mkdir(parents=True, exist_ok=True)
storage_directory.mkdir(parents=True, exist_ok=True)

def get_file_name(generated_link):
    normalized_link = str(generated_link).replace("\\", "/")
    return normalized_link.rsplit("/", 1)[-1]

def save_image(image, image_format, link):
    if image.getWidth() < 128 or image.getHeight() < 128:
        return False

    file_name = get_file_name(link[0])
    storage_path = storage_directory / file_name
    image.save(str(storage_path), image_format)
    encoded_file_name = quote(file_name, safe="")
    link[0] = public_base_url + "/" + encoded_file_name
    return True

def save_svg(svg_image, link):
    file_name = get_file_name(link[0])
    storage_path = storage_directory / file_name
    svg_data = svg_image.getSvgData()
    try:
        storage_path.write_bytes(bytes(svg_data))
    except OSError as error:
        print(f"Could not save the SVG image: {error}")
        return False

    encoded_file_name = quote(file_name, safe="")
    link[0] = public_base_url + "/" + encoded_file_name
    return True

image_handler = jpype.JProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownImageSavingHandler", dict(invoke=save_image))
svg_handler = jpype.JProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownSvgImageSavingHandler", dict(invoke=save_svg))

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setExportType(MarkdownExportType.Visual)
    options.setBasePath(str(output_directory))
    options.setImagesSaveFolderName("fallback-images")
    options.setImageSaving(image_handler)
    options.setSvgImageSaving(svg_handler)

    markdown_path = output_directory / "presentation.md"
    presentation.save(str(markdown_path), SaveFormat.Md, options)
finally:
    presentation.dispose()
```

The bitmap handler deliberately returns `False` for images smaller than 128 × 128 pixels, so Aspose.Slides saves those images to `output/fallback-images` using the default behavior. Larger bitmap and metafile resources, as well as SVG resources, are handled by the custom code. For example, a generated local reference such as `fallback-images/image1.png` becomes `https://cdn.example.com/presentations/quarterly-report/image1.png`. The handlers use operating-system paths only when writing files; links written to Markdown use forward slashes and URL-escaped file names. Apply the same rule when building relative links: use `/`, not the platform-specific directory separator.

## **FAQ**

**Can one handler process both raster images and SVG images?**

No. Use [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/python-java/aspose.slides/markdownsaveoptions/) for emitted bitmap and metafile resources and [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/python-java/aspose.slides/markdownsaveoptions/) for resources emitted as SVG. The former provides an image object and an [ImageFormat](https://reference.aspose.com/slides/python-java/aspose.slides/imageformat/) value; the latter provides an [SvgImage](https://reference.aspose.com/slides/python-java/aspose.slides/svgimage/) object whose SVG data can be read with [SvgImage.getSvgData](https://reference.aspose.com/slides/python-java/aspose.slides/svgimage/#getSvgData). A source SVG that is rasterized during export is processed by the image-saving callback instead.

**What happens when an image-saving handler returns `False`?**

Aspose.Slides uses its default local-saving behavior. The image location and generated reference are controlled by the values set with [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/python-java/aspose.slides/markdownsaveoptions/#setBasePath) and [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName).

**Can a handler provide a URL without saving the image locally?**

Yes. The handler can upload the image to object storage or pass it to another service, assign the resulting URL to `link[0]`, and return `True`. The handler must complete the processing itself; returning `True` prevents the default local save.

**Why does Markdown export throw an `InvalidOperationException` from a handler?**

This exception occurs when the handler returns `True` but does not provide a valid link. Assign the relative path or external URL that should be written to Markdown before returning `True`.

**Which path separator should image links use?**

Use forward slashes in Markdown links and URLs. Use `pathlib.Path` only for file-system paths, then construct or normalize the Markdown reference separately.

**Are hyperlinks preserved during Markdown export?**

Yes. Text [hyperlinks](/slides/python-java/manage-hyperlinks/) are preserved as standard Markdown links. Slide [transitions](/slides/python-java/slide-transition/) and [animations](/slides/python-java/powerpoint-animation/) are not converted.

**Can presentations be converted to Markdown in parallel?**

You can process different presentation files in parallel, but do not share the same [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) instance between threads. Follow the [multithreading guidelines](/slides/python-java/multithreading/) and use a separate instance for each file.
