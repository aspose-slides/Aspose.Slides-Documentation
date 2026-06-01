---
title: Export Presentations to HTML with Externally Linked Images in Python
linktitle: Export Presentations to HTML with Externally Linked Images
type: docs
weight: 100
url: /python-net/exporting-presentations-to-html-with-externally-linked-images/
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
- Python
- Aspose.Slides
description: "Export PowerPoint and OpenDocument presentations to HTML in Python using Aspose.Slides with images saved as external linked files."
---

## **Overview**

By default, Aspose.Slides exports a presentation to a self-contained HTML file. Images and other resources are written directly into the HTML, usually as Base64 data. This is convenient when you need one portable file, but it is not always the best format for a website, a CMS, or a server-side conversion pipeline.

Use externally linked images when you want to:

- reduce the size of the HTML document;
- cache images separately in a browser or CDN;
- inspect, replace, compress, or post-process generated images after export;
- keep the output structure closer to what a web application expects.

For the general HTML conversion workflow, see [Convert PowerPoint Presentations to HTML](/slides/python-net/convert-powerpoint-to-html/). This article focuses on the image-linking part of the export.

## **How Linked Image Export Works**

In .NET and Java, [ILinkEmbedController](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/) represents the callback interface used by the exporter to decide whether a resource should be embedded or linked. In Python via .NET, Python classes cannot currently implement this .NET callback interface directly, so the practical workflow is:

1. Export the presentation to HTML with [HtmlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/).
1. Use [SlideImageFormat](https://reference.aspose.com/slides/python-net/aspose.slides.export/slideimageformat/) with [SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) so the slides are represented as SVG in the HTML.
1. Move Base64 image data from HTML `data:` URLs into separate files.
1. Replace the original `data:` URLs with relative links such as `assets/resource-1.jpg`.

The file system path and the browser URL are separate concerns. For example, the sample below writes image files to `html-output/assets` on disk, while the HTML contains relative URLs such as `assets/resource-1.jpg`. A browser resolves those URLs relative to the HTML file that contains the link.

## **Export HTML with Linked Images**

The following Python example creates an output directory, saves the HTML file there, stores extracted images in an `assets` subdirectory, and rewrites Base64 image URLs to relative links. The example extracts common Base64 image formats when Aspose.Slides provides a safe file extension. Data URLs that are not recognized remain embedded.

```python
import base64
import os
import re

import aspose.slides as slides
import aspose.slides.export as slides_export


EXTENSIONS_BY_CONTENT_TYPE = {
    "image/jpeg": ".jpg",
    "image/png": ".png",
    "image/gif": ".gif",
    "image/bmp": ".bmp",
    "image/svg+xml": ".svg",
    "image/tiff": ".tiff",
    "image/x-emf": ".emf",
    "image/x-wmf": ".wmf",
}

DATA_URI_PATTERN = re.compile(
    r"data:(?P<content_type>[-\w.+]+/[-\w.+]+);base64,(?P<data>[A-Za-z0-9+/=\r\n]+)"
)


def export_presentation_to_html_with_linked_images(
    input_file_path,
    output_directory,
    asset_directory_name="assets",
):
    asset_directory = os.path.join(output_directory, asset_directory_name)

    os.makedirs(output_directory, exist_ok=True)
    os.makedirs(asset_directory, exist_ok=True)

    html_options = slides_export.HtmlOptions()
    html_options.html_formatter = slides_export.HtmlFormatter.create_document_formatter("", False)
    html_options.slide_image_format = slides_export.SlideImageFormat.svg(
        slides_export.SVGOptions()
    )

    html_file_path = os.path.join(output_directory, "presentation.html")

    with slides.Presentation(input_file_path) as presentation:
        presentation.save(html_file_path, slides_export.SaveFormat.HTML, html_options)

    externalize_base64_images(html_file_path, asset_directory, asset_directory_name)


def externalize_base64_images(html_file_path, asset_directory, asset_directory_name):
    with open(html_file_path, "r", encoding="utf-8-sig") as html_file:
        html_content = html_file.read()

    saved_resource_names = {}
    resource_index = 1

    def replace_data_uri(match):
        nonlocal resource_index

        data_uri = match.group(0)
        if data_uri in saved_resource_names:
            return saved_resource_names[data_uri]

        content_type = match.group("content_type").lower()
        extension = EXTENSIONS_BY_CONTENT_TYPE.get(content_type)
        if extension is None:
            return data_uri

        encoded_data = match.group("data")
        image_data = base64.b64decode(encoded_data)
        if len(image_data) == 0:
            return data_uri

        file_name = f"resource-{resource_index}{extension}"
        resource_index += 1

        file_path = os.path.join(asset_directory, file_name)
        with open(file_path, "wb") as image_file:
            image_file.write(image_data)

        linked_url = f"{asset_directory_name}/{file_name}"
        saved_resource_names[data_uri] = linked_url
        return linked_url

    updated_html_content = DATA_URI_PATTERN.sub(replace_data_uri, html_content)

    with open(html_file_path, "w", encoding="utf-8", newline="\n") as html_file:
        html_file.write(updated_html_content)


input_file_path = "presentation.pptx"
output_directory = "html-output"

export_presentation_to_html_with_linked_images(input_file_path, output_directory)
```

After the export, the output folder may have this structure:

```text
html-output/
  presentation.html
  assets/
    resource-1.jpg
    resource-2.png
```

The exact files depend on the presentation content and export options. For example, raster images are commonly exported as JPEG or PNG. Aspose.Slides may choose a different image codec than the one used in the source presentation when that produces a smaller or more suitable file. Images with transparency are exported as PNG.

## **Choosing URLs for Deployment**

The sample uses a relative URL prefix: `assets/`. If `presentation.html` is opened from `html-output/presentation.html`, the browser loads `html-output/assets/resource-1.jpg`.

Use a different asset directory name or rewrite the generated links when the files are deployed elsewhere:

- Use `assets/` when the asset directory is next to the HTML file.
- Use `../assets/` when the asset directory is one level above the HTML file.
- Use `https://cdn.example.com/presentations/job-123/assets/` when the files are uploaded to a CDN or static file server.

In server applications, use a unique output directory or object-storage prefix for each conversion job to avoid overwriting files from another export.

## **When to Embed Instead**

Embedded Base64 HTML is still useful when the output must be a single file, such as an email attachment, an offline preview, or a document that will be moved without a supporting asset folder. Linked images are a better fit when the HTML will be served by a web application, stored in a CMS, optimized by a build pipeline, or cached by browsers independently from the HTML.

## **FAQ**

**Can I externalize only images and keep other resources embedded?**

Yes. The sample extracts only `image/*` Base64 data URLs whose content types are listed in `EXTENSIONS_BY_CONTENT_TYPE`. Other data URLs remain embedded.

**Why does the exported image extension differ from the source presentation?**

Aspose.Slides may re-encode raster images during HTML export to improve size or browser compatibility. For example, an image from the source file may be written as JPEG or PNG depending on the rendered result.

**Do relative URLs work after I move the HTML file?**

Relative URLs work only when the same relative folder structure is preserved. If the HTML references `assets/resource-1.png`, the `assets` folder must stay next to the HTML file unless you generate a different URL prefix.

**Should server applications reuse the same output folder?**

No. Use a unique output directory or storage prefix for each conversion job. This avoids filename collisions and prevents one export from overwriting resources generated by another export.
