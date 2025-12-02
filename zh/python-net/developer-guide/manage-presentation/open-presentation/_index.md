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
description: "使用 Aspose.Slides for Python via .NET，轻松打开 PowerPoint（.pptx、.ppt）和 OpenDocument（.odp）演示文稿——快速、可靠、功能齐全。"
---

## **概述**

除了从头创建 PowerPoint 演示文稿外，Aspose.Slides 还可以打开现有的演示文稿。加载演示文稿后，您可以检索其信息，编辑幻灯片内容，添加新幻灯片，删除已有幻灯片，等等。

## **打开演示文稿**

要打开现有演示文稿，请实例化 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类并将文件路径传递给其构造函数。

下面的 Python 示例展示了如何打开演示文稿并获取其幻灯片数量：
```python
import aspose.slides as slides

# 实例化 Presentation 类并将文件路径传递给其构造函数。
with slides.Presentation("sample.pptx") as presentation:
    # 打印演示文稿中的幻灯片总数。
    print(presentation.slides.length)
```


## **打开受密码保护的演示文稿**

当需要打开受密码保护的演示文稿时，请通过 [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) 类的 [password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/) 属性传入密码，以解密并加载演示文稿。下面的 Python 代码演示了此操作：
```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("sample.pptx", load_options) as presentation:
    # 对已解密的演示文稿执行操作。
```


## **打开大型演示文稿**

Aspose.Slides 提供选项——尤其是 [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) 类中的 [blob_management_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/blob_management_options/) 属性，帮助您加载大型演示文稿。

下面的 Python 代码演示了加载大型演示文稿（例如 2 GB）：
```python
import aspose.slides as slides
import os

file_path = "LargePresentation.pptx"

load_options = slides.LoadOptions()
# Choose the KeepLocked behavior—the presentation file will remain locked for the lifetime of 
# the Presentation instance, but it does not need to be loaded into memory or copied to a temporary file.
load_options.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
load_options.blob_management_options.is_temporary_files_allowed = True
load_options.blob_management_options.max_blobs_bytes_in_memory = 10 * 1024 * 1024  # 10 MB

with slides.Presentation(file_path, load_options) as presentation:
    # 已加载大型演示文稿，可直接使用，且内存消耗保持低。

    # 对演示文稿进行修改。
    presentation.slides[0].name = "Large presentation"

    # 将演示文稿保存到另一个文件。此操作期间内存消耗保持低。
    presentation.save("LargePresentation-copy.pptx", slides.export.SaveFormat.PPTX)

    # 不要这样做！会抛出 I/O 异常，因为文件在演示稿对象被释放前会保持锁定。
    os.remove(file_path)

# 此处可以这样做。源文件已不再被演示文稿对象锁定。
os.remove(file_path)
```


{{% alert color="info" title="信息" %}}
为了解决使用流时的某些限制，Aspose.Slides 可能会复制流的内容。从流加载大型演示文稿会导致演示文稿被复制，从而减慢加载速度。因此，在需要加载大型演示文稿时，我们强烈建议使用演示文稿文件路径而不是流。

在创建包含大型对象（视频、音频、高分辨率图像等）的演示文稿时，您可以使用 [BLOB 管理](/slides/zh/python-net/manage-blob/) 来降低内存消耗。
{{%/alert %}}

## **控制外部资源**

Aspose.Slides 提供 [IResourceLoadingCallback](https://reference.aspose.com/slides/python-net/aspose.slides/iresourceloadingcallback/) 接口，允许您管理外部资源。下面的 Python 代码展示了如何使用 `IResourceLoadingCallback` 接口：
```python
# [TODO[not_supported_yet]: python 对 .NET 接口的实现]
```


## **加载不包含嵌入式二进制对象的演示文稿**

PowerPoint 演示文稿可能包含以下类型的嵌入式二进制对象：

- VBA 项目（可通过 [Presentation.vba_project](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/vba_project/) 访问）；
- OLE 对象嵌入数据（可通过 [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/) 访问）；
- ActiveX 控件二进制数据（可通过 [Control.active_x_control_binary](https://reference.aspose.com/slides/python-net/aspose.slides/control/active_x_control_binary/) 访问）。

使用 [LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/) 属性，您可以在不加载任何嵌入式二进制对象的情况下打开演示文稿。

此属性对于删除可能存在的恶意二进制内容非常有用。下面的 Python 代码演示了如何在不加载任何嵌入式二进制内容的情况下打开演示文稿：
```py
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("malware.ppt", load_options) as presentation:
    # 对演示文稿执行操作。
```


## **常见问题**

**如何判断文件已损坏且无法打开？**

加载期间会出现解析/格式验证异常。这类错误通常会提及无效的 ZIP 结构或损坏的 PowerPoint 记录。

**打开时缺少必需的字体会怎样？**

文件仍会打开，但后续的 [渲染/导出](/slides/zh/python-net/convert-presentation/) 可能会使用替代字体。请在运行时环境中 [配置字体替代](/slides/zh/python-net/font-substitution/) 或 [添加所需字体](/slides/zh/python-net/custom-font/)。

**打开时嵌入的媒体（视频/音频）会怎样处理？**

它们会作为演示文稿资源可用。如果媒体通过外部路径引用，请确保这些路径在您的环境中可访问；否则 [渲染/导出](/slides/zh/python-net/convert-presentation/) 可能会省略这些媒体。