---
title: 在 Python 中使用外部链接图像将演示文稿导出为 HTML
linktitle: 使用外部链接图像将演示文稿导出为 HTML
type: docs
weight: 100
url: /zh/python-net/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- 导出 PowerPoint
- 导出 OpenDocument
- 导出演示文稿
- 导出幻灯片
- 导出 PPT
- 导出 PPTX
- 导出 ODP
- PowerPoint 转 HTML
- OpenDocument 转 HTML
- 演示文稿转 HTML
- 幻灯片转 HTML
- PPT 转 HTML
- PPTX 转 HTML
- ODP 转 HTML
- 链接图像
- 外部链接图像
- 链接资源
- 外部资源
- Python
- Aspose.Slides
description: 在 Python 中使用 Aspose.Slides 将 PowerPoint 和 OpenDocument 演示文稿导出为 HTML，图像保存为外部链接文件。
---
## **概述**

默认情况下，Aspose.Slides 会将演示文稿导出为一个自包含的 HTML 文件。图像和其他资源直接写入 HTML，通常以 Base64 数据的形式。这在需要单个可移植文件时很方便，但并不总是网站、CMS 或服务器端转换流水线的最佳格式。

当您希望实现以下目标时，请使用外部链接的图像：
- 减小 HTML 文档的大小；
- 在浏览器或 CDN 中单独缓存图像；
- 在导出后检查、替换、压缩或后处理生成的图像；
- 使输出结构更符合 Web 应用程序的预期。

关于一般的 HTML 转换工作流，请参见[将 PowerPoint 演示文稿转换为 HTML](/slides/zh/python-net/convert-powerpoint-to-html/)。本文重点介绍导出过程中的图像链接部分。

## **链接图像导出工作原理**

在 .NET 和 Java 中，[ILinkEmbedController](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/ilinkembedcontroller/) 表示导出器用来决定资源是嵌入还是链接的回调接口。在通过 .NET 使用 Python 时，Python 类目前无法直接实现此 .NET 回调接口，因此实际工作流如下：

1. 使用 [HtmlOptions](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/htmloptions/) 将演示文稿导出为 HTML。
2. 使用 [SlideImageFormat](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/slideimageformat/) 与 [SVGOptions](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/svgoptions/) 使幻灯片在 HTML 中以 SVG 形式呈现。
3. 将 HTML 中的 `data:` URL 所包含的 Base64 图像数据移动到独立的文件中。
4. 将原始的 `data:` URL 替换为相对链接，例如 `assets/resource-1.jpg`。

文件系统路径和浏览器 URL 是相互独立的概念。例如，下面的示例将图像文件写入磁盘上的 `html-output/assets`，而 HTML 中包含的相对 URL 如 `assets/resource-1.jpg`。浏览器会根据包含链接的 HTML 文件相对解析这些 URL。

## **导出带链接图像的 HTML**

下面的 Python 示例会创建输出目录，将 HTML 文件保存到该目录，将提取的图像存放在 `assets` 子目录中，并将 Base64 图像 URL 重写为相对链接。当 Aspose.Slides 提供安全的文件扩展名时，示例会提取常见的 Base64 图像格式。未识别的 Data URL 将保持嵌入。

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

导出后，输出文件夹可能具有以下结构：

```text
html-output/
  presentation.html
  assets/
    resource-1.jpg
    resource-2.png
```

具体文件取决于演示文稿的内容和导出选项。例如，光栅图像通常导出为 JPEG 或 PNG。当使用不同的图像编解码器可以生成更小或更合适的文件时，Aspose.Slides 可能会选择与源演示文稿不同的编解码器。具有透明度的图像会导出为 PNG。

## **部署时选择 URL**

示例使用相对 URL 前缀：`assets/`。如果从 `html-output/presentation.html` 打开 `presentation.html`，浏览器会加载 `html-output/assets/resource-1.jpg`。

当文件部署到其他位置时，请使用不同的资源目录名称或重写生成的链接：
- 当资源目录与 HTML 文件位于同一目录时使用 `assets/`。
- 当资源目录位于 HTML 文件的上一级目录时使用 `../assets/`。
- 当文件上传到 CDN 或静态文件服务器时使用 `https://cdn.example.com/presentations/job-123/assets/`。

在服务器应用程序中，为每个转换任务使用唯一的输出目录或对象存储前缀，以避免覆盖其他导出的文件。

## **何时使用嵌入而非链接**

当输出必须是单个文件时（例如电子邮件附件、离线预览或在没有配套资源文件夹的情况下移动的文档），嵌入的 Base64 HTML 仍然有用。若 HTML 将由 Web 应用程序提供、存放在 CMS 中、通过构建流水线进行优化，或由浏览器独立于 HTML 缓存，则使用链接图像更为合适。

## **常见问题**

**我可以仅外部化图像而保持其他资源嵌入吗？**

可以。示例仅提取在 `EXTENSIONS_BY_CONTENT_TYPE` 列表中的 `image/*` Base64 数据 URL。其他数据 URL 将保持嵌入。

**导出图像的扩展名为何与源演示文稿不同？**

Aspose.Slides 可能在 HTML 导出时重新编码光栅图像，以优化大小或兼容浏览器。例如，源文件中的图像可能根据渲染结果被写为 JPEG 或 PNG。

**移动 HTML 文件后相对 URL 还能工作吗？**

只有在保持相同的相对文件夹结构时，相对 URL 才能工作。如果 HTML 引用了 `assets/resource-1.png`，则 `assets` 文件夹必须与 HTML 文件位于同一目录，除非您生成了不同的 URL 前缀。

**服务器应用程序是否应重复使用相同的输出文件夹？**

不应。为每个转换任务使用唯一的输出目录或存储前缀。这可避免文件名冲突，并防止一次导出覆盖另一导出的资源。