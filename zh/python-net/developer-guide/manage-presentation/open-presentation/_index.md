---
title: 在 Python 中打开演示文稿
linktitle: 打开演示文稿
type: docs
weight: 20
url: /zh/python-net/open-presentation/
keywords:
- 打开 PowerPoint
- 打开演示文稿
- 打开 PPTX
- 打开 PPT
- 打开 ODP
- 加载演示文稿
- 加载 PPTX
- 加载 PPT
- 加载 ODP
- 受保护的演示文稿
- 大型演示文稿
- 外部资源
- 二进制对象
- Python
- Aspose.Slides
description: "了解如何在 Python 中打开 PowerPoint 和 OpenDocument 演示文稿，提供打开密码，并使用 Aspose.Slides for Python via .NET 减少内存使用。"
---
## **简介**

[Aspose.Slides for Python via .NET](https://products.aspose.com/slides/zh/python-net/) 可从文件和流加载 PowerPoint 和 OpenDocument 演示文稿。加载演示文稿后，您可以检查其结构、编辑幻灯片、管理资源，并以原始格式或其他受支持的格式保存。

可以通过 [LoadOptions](https://reference.aspose.com/slides/zh/python-net/aspose.slides/loadoptions/) 类自定义加载行为。例如，您可以提供打开密码、将大型二进制对象保留在内存之外，或省略嵌入的二进制数据。

## **打开演示文稿**

要打开现有演示文稿，请将其文件路径传递给 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 构造函数。使用 `with` 语句可以及时释放文件句柄、临时数据和其他资源。

以下 Python 示例演示如何打开演示文稿并获取幻灯片计数：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

## **打开受密码保护的演示文稿**

打开密码会加密演示文稿内容。要加载完整的演示文稿，请将正确的密码分配给 [LoadOptions.password](https://reference.aspose.com/slides/zh/python-net/aspose.slides/loadoptions/password/) 并将该选项传递给 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 构造函数。如果密码缺失或不正确，加载将失败。

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-presentation.pptx", load_options) as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

有关密码检测、验证和加密工作流，请参阅 [Password-Protect Presentations](/slides/zh/python-net/password-protected-presentation/)。如果加密的演示文稿刻意以公共文档属性保存，则可以在不提供密码的情况下读取这些属性；请参阅 [Manage Presentation Properties](/slides/zh/python-net/presentation-properties/)。

## **打开大型演示文稿**

[LoadOptions.blob_management_options](https://reference.aspose.com/slides/zh/python-net/aspose.slides/loadoptions/blob_management_options/) 控制 Aspose.Slides 如何处理二进制大对象（如图像、音频和视频）。您可以保持源文件锁定、允许临时文件，并限制内存中保留的 BLOB 数据量。

以下 Python 代码演示如何加载大型演示文稿（例如 2 GB）：

```python
import aspose.slides as slides
file_path = "large-presentation.pptx"

load_options = slides.LoadOptions()
load_options.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
load_options.blob_management_options.is_temporary_files_allowed = True
load_options.blob_management_options.max_blobs_bytes_in_memory = 10 * 1024 * 1024

with slides.Presentation(file_path, load_options) as presentation:
    presentation.slides[0].name = "Large presentation"
    presentation.save("large-presentation-copy.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="info" title="注意" %}}
使用 `PresentationLockingBehavior.KEEP_LOCKED` 时，源文件会保持锁定状态，直至 `Presentation` 对象被释放。在该对象存活期间，请勿移动、覆盖或删除源文件。

Aspose.Slides 在加载时可能会复制输入流的内容。对于大型演示文稿，文件路径通常比流更高效。请参阅 [Manage BLOBs](/slides/zh/python-net/manage-blob/) 了解更多存储和内存管理选项。
{{% /alert %}}

## **加载不含嵌入二进制对象的演示文稿**

演示文稿可能包含应用程序不需要或不想保留的嵌入二进制数据。例如包括：

- VBA 项目，可通过 [Presentation.vba_project](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/vba_project/) 获取；
- 嵌入的 OLE 数据，可通过 [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/) 获取；
- ActiveX 控件数据，可通过 [Control.active_x_control_binary](https://reference.aspose.com/slides/zh/python-net/aspose.slides/control/active_x_control_binary/) 获取。

将 [LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/zh/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/) 设置为 `True`，即可在加载时删除这些二进制数据。保存加载后的演示文稿以保留已清理的结果。

此选项可降低不需要的嵌入负载的风险，但它并非完整的恶意软件检测或内容清理系统。

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("presentation-with-embedded-data.pptx", load_options) as presentation:
    presentation.save("presentation-without-embedded-data.pptx", slides.export.SaveFormat.PPTX)
```

## **常见问题**

**如何判断文件已损坏且无法打开？**

Aspose.Slides 在加载期间会抛出解析或格式异常。请将此类失败与密码错误的异常分开处理，以便应用程序能够准确报告原因。

**如果缺少必需的字体会怎样？**

演示文稿仍可加载，但在渲染和导出时可能会使用替代字体。您可以 [configure font substitution](/slides/zh/python-net/font-substitution/) 或 [provide custom fonts](/slides/zh/python-net/custom-font/) 来使输出更可预测。

**加载演示文稿是否也会加载其嵌入的媒体？**

嵌入的音频和视频可通过演示文稿对象模型访问。外部资源将按默认的资源加载行为解析，如果无法访问其位置，则可能不可用。