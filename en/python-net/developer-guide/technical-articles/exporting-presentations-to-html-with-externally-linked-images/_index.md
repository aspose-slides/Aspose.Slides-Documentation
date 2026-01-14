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
- Python
- Aspose.Slides
description: "Learn how to export presentations to HTML with externally linked images in Aspose.Slides for Python via .NET, covering PowerPoint and OpenDocument formats."
---

{{% alert color="primary" %}} 

The presentation-to-HTML export process lets you specify:

1. which resources are embedded in the resulting HTML file, and
1. which resources are saved externally and referenced from the HTML file.

{{% /alert %}} 

## **Background**

By default, HTML export embeds all resources directly in the HTML using Base64 encoding. This produces a single, self-contained HTML file that’s convenient for viewing and distribution. However, this approach has drawbacks:

* The resulting file is significantly larger than the original resources because of Base64 overhead.
* Embedded images and other assets are difficult to update or replace.

## **Alternative Approach**

An alternative approach using [ILinkEmbedController](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/) avoids these limitations.

The `LinkController` class below implements [ILinkEmbedController](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/) and is passed to the [HtmlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/__init__/#ilinkembedcontroller) constructor. The class exposes three methods that control how resources are embedded or linked during HTML export:

[get_object_storing_location(id, entity_data, semantic_name, content_type, recommended_extension)](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/get_object_storing_location/#int-bytes-str-str-str): Called when the exporter encounters a resource and must decide where to store it. The most important parameters are `id` (the resource’s unique identifier for this export run) and `content_type` (the resource MIME type). Return [LinkEmbedDecision.LINK](https://reference.aspose.com/slides/python-net/aspose.slides.export/linkembeddecision/) to link the resource, or [LinkEmbedDecision.EMBED](https://reference.aspose.com/slides/python-net/aspose.slides.export/linkembeddecision/) to embed it.

[get_url(id, referrer)](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/get_url/#int-int): Returns the URL that will appear in the resulting HTML for the resource identified by `id` (optionally considering the referrer object).

[save_external(id, entity_data)](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/save_external/#int-bytes): Called when a resource selected for linking needs to be written externally. Because the identifier and contents are provided (as a byte array), you can persist the resource however you like.

The Python `LinkController` implementation of [ILinkEmbedController](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/) follows below.

```py
# [TODO[not_supported_yet]: python implementation of .NET interfaces]
```

After implementing the `LinkController` class, you can use it with the [HtmlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/htmloptions/) class to export the presentation to HTML with externally linked images, as shown below:

```py
# [TODO[not_supported_yet]: python implementation of .NET interfaces]
```

We assigned `SlideImageFormat.SVG` to the `slide_image_format` property so that the resulting HTML file will contain SVG data to render the presentation’s contents.

Content types: If the presentation contains raster bitmaps, then the class code must be prepared to process both `image/jpeg` and `image/png` content types. The content of the exported bitmap images may not match what was stored in the presentation. Aspose.Slides’ internal algorithms perform size optimization and use either the JPEG or PNG codec (depending on which produces a smaller file size). Images containing an alpha channel (transparency) are always encoded as PNG.
