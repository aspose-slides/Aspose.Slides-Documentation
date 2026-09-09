---
title: 使用 Java 通过 Python 打开演示文稿
linktitle: 打开演示文稿
type: docs
weight: 20
url: /zh/python-java/open-presentation/
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
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via Java 在 Python 中通过 Java 打开 PowerPoint 和 OpenDocument 演示文稿，提供打开密码，控制资源加载，并减少内存使用。"
---
## **简介**

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/zh/python-java/) 可以从文件和流加载 PowerPoint 和 OpenDocument 演示文稿。加载演示文稿后，您可以检查其结构、编辑幻灯片、管理资源，并以原始或其他受支持的格式保存。

可以通过 [LoadOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/loadoptions/) 类自定义加载行为。例如，您可以提供打开密码、将大型二进制对象保留在 Java 堆内存之外、控制外部资源，或省略嵌入的二进制数据。

## **打开演示文稿**

要打开现有演示文稿，请将其文件路径传递给 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 构造函数。使用后请释放演示文稿，以便及时释放文件句柄、临时数据和其他资源。

以下 Python 示例展示了如何打开演示文稿并获取其幻灯片计数：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("sample.pptx")
try:
    print("Slide count:", presentation.getSlides().size())
finally:
    presentation.dispose()
```

## **打开受密码保护的演示文稿**

打开密码会加密演示文稿内容。要加载完整的演示文稿，请将正确的密码传递给 [LoadOptions.setPassword](https://reference.aspose.com/slides/zh/python-java/aspose.slides/loadoptions/#setPassword) 并将选项提供给 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 构造函数。如果缺少密码或密码不正确，加载将失败。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-presentation.pptx", load_options)
try:
    print("Slide count:", presentation.getSlides().size())
finally:
    presentation.dispose()
```

有关密码检测、验证和加密工作流，请参阅 [Password-Protect Presentations](/slides/zh/python-java/password-protected-presentation/)。如果已加密的演示文稿被有意保存了公共文档属性，则可以在不提供密码的情况下读取这些属性；请参阅 [Manage Presentation Properties](/slides/zh/python-java/presentation-properties/)。

## **打开大型演示文稿**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/loadoptions/#getBlobManagementOptions) 返回控制 Aspose.Slides 如何处理图像、音频和视频等二进制大对象的选项。您可以保持源文件锁定、允许临时文件，并限制保存在内存中的 BLOB 数据量。

以下 Python 代码演示了加载大型演示文稿（例如 2 GB）：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior, SaveFormat

file_path = "large-presentation.pptx"

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)
load_options.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024)

presentation = Presentation(file_path, load_options)
try:
    presentation.getSlides().get_Item(0).setName("Large presentation")
    presentation.save("large-presentation-copy.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
使用 [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentationlockingbehavior/#KeepLocked) 时，源文件将保持锁定状态，直到释放演示文稿实例。在该实例存活期间，请勿移动、覆盖或删除源文件。

Aspose.Slides 在加载时可能会复制输入流的内容。对于大型演示文稿，文件路径通常比流更高效。请参阅 [Manage BLOBs](/slides/zh/python-java/manage-blob/) 了解更多存储和内存管理选项。
{{% /alert %}}

## **控制外部资源**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/zh/python-java/aspose.slides/loadoptions/#setResourceLoadingCallback) 接受实现 Java 资源加载回调接口的 JPype 代理。回调可以提供替换数据、重定向资源、使用默认加载器或跳过资源。当演示文稿包含需根据应用特定安全或存储规则解析的外部图像时，此功能非常有用。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import LoadOptions, Presentation, ResourceLoadingAction

class ImageLoadingHandler:
    def resourceLoading(self, resource_loading_arguments):
        is_jpeg = str(resource_loading_arguments.getOriginalUri()).lower().endswith(".jpg")
        approved_image_path = Path("approved-image.jpg")
        if not is_jpeg or not approved_image_path.exists():
            return ResourceLoadingAction.Skip

        try:
            image_data = approved_image_path.read_bytes()
            java_image_data = jpype.JArray(jpype.JByte)(image_data)
            resource_loading_arguments.setData(java_image_data)
            return ResourceLoadingAction.UserProvided
        except OSError:
            print("The approved replacement image could not be read.")
            return ResourceLoadingAction.Skip

load_options = LoadOptions()
image_loading_handler = ImageLoadingHandler()
callback = jpype.JProxy("com.aspose.slides.IResourceLoadingCallback", inst=image_loading_handler)
load_options.setResourceLoadingCallback(callback)

presentation = Presentation("presentation-with-external-images.pptx", load_options)
try:
    print("Slide count:", presentation.getSlides().size())
finally:
    presentation.dispose()
```

## **加载不含嵌入二进制对象的演示文稿**

演示文稿可能包含应用程序不需要或不想保留的嵌入二进制数据。例如包括：

- VBA 项目，可通过 [Presentation.getVbaProject](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getVbaProject) 获取；
- 嵌入的 OLE 数据，可通过 [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/zh/python-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData) 获取；
- ActiveX 控件数据，可通过 [Control.getActiveXControlBinary](https://reference.aspose.com/slides/zh/python-java/aspose.slides/control/#getActiveXControlBinary) 获取。

将 [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/zh/python-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) 设置为 `True` 可在加载时删除这些二进制数据。保存加载后的演示文稿以保留已清理的结果。

此选项可降低不需要的嵌入负载的风险，但它并非完整的恶意软件检测或内容清理系统。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SaveFormat

load_options = LoadOptions()
load_options.setDeleteEmbeddedBinaryObjects(True)

presentation = Presentation("presentation-with-embedded-data.pptx", load_options)
try:
    presentation.save("presentation-without-embedded-data.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **常见问题**

**如何判断文件已损坏且无法打开？**

Aspose.Slides 在加载时会抛出解析或格式异常。请将此类失败单独处理，以区别于密码错误错误，从而使应用程序能够准确报告原因。

**如果缺少必需的字体会怎样？**

演示文稿仍然可以加载，但渲染和导出可能会进行字体替换。您可以 [配置字体替换](/slides/zh/python-java/font-substitution/) 或 [提供自定义字体](/slides/zh/python-java/custom-font/) 以使输出更可预测。

**加载演示文稿时是否也会加载其嵌入的媒体？**

嵌入的音频和视频可通过演示文稿对象模型访问。外部资源将根据配置的资源加载行为进行解析，如果无法访问其位置，则可能不可用。