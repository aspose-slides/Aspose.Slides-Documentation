---
title: 在Python中打开演示文稿
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
description: "通过 Aspose.Slides for Python via .NET，轻松打开 PowerPoint（.pptx、.ppt）和 OpenDocument（.odp）演示文稿——快速、可靠、功能齐全。"
---

## **概述**

除了从头创建 PowerPoint 演示文稿之外，Aspose.Slides 还允许您打开现有的演示文稿。加载演示文稿后，您可以检索其信息、编辑幻灯片内容、添加新幻灯片、删除已有幻灯片等。

## **打开演示文稿**

要打开现有的演示文稿，请实例化 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类并将文件路径作为构造函数参数传入。

以下 Python 示例展示了如何打开演示文稿并获取幻灯片数量：
```python
import aspose.slides as slides

# 实例化 Presentation 类并将文件路径传递给其构造函数。
with slides.Presentation("sample.pptx") as presentation:
    # 打印演示文稿中的幻灯片总数。
    print(presentation.slides.length)
```


## **打开受密码保护的演示文稿**

当需要打开受密码保护的演示文稿时，请通过 [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) 类的 [password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/) 属性传入密码以解密并加载。以下 Python 代码演示了此操作：
```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("sample.pptx", load_options) as presentation:
    # 对解密后的演示文稿执行操作。
```


## **打开大型演示文稿**

Aspose.Slides 提供了选项——尤其是 [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) 类中的 [blob_management_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/blob_management_options/) 属性——帮助您加载大型演示文稿。

以下 Python 代码演示了加载大型演示文稿（例如 2 GB）：
```python
import aspose.slides as slides
import os

file_path = "LargePresentation.pptx"

load_options = slides.LoadOptions()
# 选择 KeepLocked 行为——演示文稿文件将在整个生命周期内保持锁定 
# 演示文稿实例，但它无需加载到内存或复制到临时文件。
load_options.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
load_options.blob_management_options.is_temporary_files_allowed = True
load_options.blob_management_options.max_blobs_bytes_in_memory = 10 * 1024 * 1024  # 10 MB

with slides.Presentation(file_path, load_options) as presentation:
    # 大型演示文稿已加载并可使用，且内存消耗保持低水平。

    # 对演示文稿进行修改。
    presentation.slides[0].name = "Large presentation"

    # 将演示文稿保存到另一个文件。此操作期间内存消耗保持低水平。
    presentation.save("LargePresentation-copy.pptx", slides.export.SaveFormat.PPTX)

    # 不要这样做！由于文件在演示文稿对象释放前被锁定，会抛出 I/O 异常。
    os.remove(file_path)

# 此处执行没有问题。源文件已不再被演示文稿对象锁定。
os.remove(file_path)
```


{{% alert color="info" title="Info" %}}
为了解决在使用流时的某些限制，Aspose.Slides 可能会复制流的内容。从流加载大型演示文稿会导致演示文稿被复制，从而减慢加载速度。因此，当您需要加载大型演示文稿时，强烈建议使用演示文稿文件路径而不是流。

在创建包含大型对象（视频、音频、高分辨率图像等）的演示文稿时，您可以使用 [BLOB management](/slides/zh/python-net/manage-blob/) 来降低内存消耗。
{{%/alert %}}

## **控制外部资源**

Aspose.Slides 提供了 [IResourceLoadingCallback](https://reference.aspose.com/slides/python-net/aspose.slides/iresourceloadingcallback/) 接口，让您管理外部资源。以下 Python 代码展示了如何使用 `IResourceLoadingCallback` 接口：
```python
# [TODO[not_supported_yet]: Python 实现 .NET 接口]
```


## **加载不含嵌入二进制对象的演示文稿**

PowerPoint 演示文稿可能包含以下类型的嵌入二进制对象：

- VBA 项目（可通过 [Presentation.vba_project](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/vba_project/) 访问）；
- OLE 对象嵌入数据（可通过 [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/) 访问）；
- ActiveX 控件二进制数据（可通过 [Control.active_x_control_binary](https://reference.aspose.com/slides/python-net/aspose.slides/control/active_x_control_binary/) 访问）。

使用 [LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/) 属性，您可以在不加载任何嵌入二进制对象的情况下打开演示文稿。

此属性对于移除潜在的恶意二进制内容非常有用。以下 Python 代码演示了如何在不加载任何嵌入二进制内容的情况下加载演示文稿：
```py
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("malware.ppt", load_options) as presentation:
    # 对演示文稿执行操作。
```


## **常见问题**

**如何判断文件已损坏且无法打开？**

加载时会抛出解析/格式验证异常。此类错误通常提及 ZIP 结构无效或 PowerPoint 记录损坏。

**打开时如果缺少必需的字体会怎样？**

文件仍会打开，但随后在[rendering/export](/slides/zh/python-net/convert-presentation/)时可能会替换字体。请在运行时环境中[Configure font substitutions](/slides/zh/python-net/font-substitution/)或[add the required fonts](/slides/zh/python-net/custom-font/)。

**打开时嵌入的媒体（视频/音频）怎么办？**

它们会作为演示文稿资源可用。如果媒体通过外部路径引用，请确保这些路径在您的环境中可访问；否则在[rendering/export](/slides/zh/python-net/convert-presentation/)时可能会省略这些媒体。