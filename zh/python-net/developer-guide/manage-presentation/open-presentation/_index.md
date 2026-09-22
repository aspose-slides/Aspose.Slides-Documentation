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

Aspose.Slides for Python via .NET 可以从文件和流加载 PowerPoint 和 OpenDocument 演示文稿。加载演示文稿后，您可以检查其结构、编辑幻灯片、管理资源，并以原始格式或其他受支持的格式保存。

可以通过 LoadOptions 类自定义加载行为。例如，您可以提供打开密码、将大型二进制对象保留在内存之外，或省略嵌入的二进制数据。

## **打开演示文稿**

加载文件或流后，您可以[确定其原始演示文稿格式](/slides/zh/python-net/detect-presentation-source-format/)以选择应用程序的处理方式。

要打开现有演示文稿，请将其文件路径传递给 Presentation 构造函数。使用 `with` 语句，以便及时释放文件句柄、临时数据和其他资源。

下面的 Python 示例演示如何打开演示文稿并获取幻灯片计数：

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

## **打开受密码保护的演示文稿**

打开密码会加密演示文稿内容。要加载完整的演示文稿，请将正确的密码分配给 LoadOptions.password，并将该选项传递给 Presentation 构造函数。当密码缺失或不正确时，加载将失败。

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-presentation.pptx", load_options) as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

有关密码检测、验证和加密工作流，请参阅[Password-Protect Presentations](/slides/zh/python-net/password-protected-presentation/)。如果加密的演示文稿有意以公开的文档属性保存，则这些属性可以在不提供密码的情况下读取；请参阅[Manage Presentation Properties](/slides/zh/python-net/presentation-properties/)。

## **打开大型演示文稿**

LoadOptions.blob_management_options 控制 Aspose.Slides 如何处理二进制大对象（如图像、音频和视频）。您可以保持源文件锁定、允许使用临时文件，并限制内存中保留的 BLOB 数据量。

下面的 Python 代码演示如何加载大型演示文稿（例如，2 GB）：

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

{{% alert color="info" title="Note" %}}
使用 `PresentationLockingBehavior.KEEP_LOCKED` 时，源文件会保持锁定状态，直至 `Presentation` 对象被释放。对象存活期间请勿移动、覆盖或删除源文件。

Aspose.Slides 可能在加载时复制输入流的内容。对于大型演示文稿，文件路径通常比流更高效。有关其他存储和内存管理选项，请参阅[Manage BLOBs](/slides/zh/python-net/manage-blob/)。

{{% /alert %}}

## **加载演示文稿时不包含嵌入的二进制对象**

演示文稿可能包含嵌入的二进制数据，而应用程序不需要或不希望保留这些数据。例如：

- VBA 项目，可通过 Presentation.vba_project 获取；
- 嵌入的 OLE 数据，可通过 OleEmbeddedDataInfo.embedded_file_data 获取；
- ActiveX 控件数据，可通过 Control.active_x_control_binary 获取。

将 LoadOptions.delete_embedded_binary_objects 设置为 `True`，即可在加载时删除这些二进制数据。保存加载后的演示文稿以保留已清理的结果。

此选项可降低不需要的嵌入负载的风险，但它并非完整的恶意软件检测或内容消毒系统。

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("presentation-with-embedded-data.pptx", load_options) as presentation:
    presentation.save("presentation-without-embedded-data.pptx", slides.export.SaveFormat.PPTX)
```

## **常见问题**

**如何判断文件已损坏且无法打开？**

Aspose.Slides 在加载期间会抛出解析或格式异常。请将此类失败与密码错误的错误分开处理，以便应用程序能够准确报告原因。

**如果缺少必需的字体会怎样？**

演示文稿仍然可以加载，但渲染和导出时可能会替换字体。您可以[配置字体替换](/slides/zh/python-net/font-substitution/)或[提供自定义字体](/slides/zh/python-net/custom-font/)以使输出更可预测。

**加载演示文稿是否也会加载其嵌入的媒体？**

嵌入的音频和视频可以通过演示文稿对象模型访问。外部资源根据默认的资源加载行为解析，如果无法访问其位置，则可能不可用。