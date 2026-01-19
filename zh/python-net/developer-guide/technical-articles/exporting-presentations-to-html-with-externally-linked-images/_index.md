---
title: 在 Python 中使用外部链接图像将演示文稿导出为 HTML
linktitle: 导出演示文稿为带外部链接图像的 HTML
type: docs
weight: 100
url: /zh/python-net/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- 导出 PowerPoint
- 导出 OpenDocument
- 导出 演示文稿
- 导出 幻灯片
- 导出 PPT
- 导出 PPTX
- 导出 ODP
- PowerPoint 转 HTML
- OpenDocument 转 HTML
- 演示文稿 转 HTML
- 幻灯片 转 HTML
- PPT 转 HTML
- PPTX 转 HTML
- ODP 转 HTML
- 链接的图像
- 外部链接的图像
- Python
- Aspose.Slides
description: 了解如何使用 Aspose.Slides for Python via .NET 将演示文稿导出为带外部链接图像的 HTML，涵盖 PowerPoint 和 OpenDocument 格式。
---

{{% alert color="primary" %}} 

演示文稿到HTML的导出过程允许您指定：

1. 哪些资源被嵌入到生成的HTML文件中，
1. 哪些资源被外部保存并从HTML文件中引用。

{{% /alert %}} 

## **背景**

默认情况下，HTML 导出会使用 Base64 编码将所有资源直接嵌入到 HTML 中。这会生成一个单一的、独立的 HTML 文件，便于查看和分发。然而，这种方式有以下缺点：

* 由于 Base64 编码的开销，生成的文件比原始资源大得多。
* 嵌入的图像和其他资产难以更新或替换。

## **替代方法**

使用 [ILinkEmbedController](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/) 的替代方法可避免这些限制。

`LinkController` 类如下实现了 [ILinkEmbedController](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/)，并作为参数传递给 [HtmlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/__init__/#ilinkembedcontroller) 构造函数。该类公开了三个方法，用于控制在 HTML 导出期间资源是嵌入还是链接：

[get_object_storing_location(id, entity_data, semantic_name, content_type, recommended_extension)](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/get_object_storing_location/#int-bytes-str-str-str): 在导出程序遇到资源并必须决定存储位置时调用。最重要的参数是 `id`（此导出运行中资源的唯一标识）和 `content_type`（资源的 MIME 类型）。返回 [LinkEmbedDecision.LINK](https://reference.aspose.com/slides/python-net/aspose.slides.export/linkembeddecision/) 以链接资源，或返回 [LinkEmbedDecision.EMBED](https://reference.aspose.com/slides/python-net/aspose.slides.export/linkembeddecision/) 以嵌入资源。

[get_url(id, referrer)](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/get_url/#int-int): 返回将在生成的HTML中显示的、由 `id` 标识的资源的URL（可选地考虑引用对象）。

[save_external(id, entity_data)](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/save_external/#int-bytes): 当选中链接的资源需要外部写入时调用。由于标识符和内容已提供（作为字节数组），您可以以任何方式持久化该资源。

下面是 Python `LinkController` 对 [ILinkEmbedController](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/) 的实现。
```py
# [TODO[not_supported_yet]: python 实现 .NET 接口]
```


实现 `LinkController` 类后，您可以将其与 [HtmlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/) 类一起使用，以将演示文稿导出为带有外部链接图像的HTML，如下所示：
```py
# [TODO[not_supported_yet]: python 实现 .NET 接口]
```


我们将 `SlideImageFormat.SVG` 赋给 `slide_image_format` 属性，以便生成的 HTML 文件包含用于渲染演示文稿内容的 SVG 数据。

内容类型：如果演示文稿包含光栅位图，则类代码必须能够处理 `image/jpeg` 和 `image/png` 两种内容类型。导出的位图图像的内容可能与演示文稿中存储的内容不一致。Aspose.Slides 的内部算法会进行大小优化，并使用 JPEG 或 PNG 编解码器（取决于哪种能产生更小的文件尺寸）。包含 alpha 通道（透明度）的图像始终编码为 PNG。