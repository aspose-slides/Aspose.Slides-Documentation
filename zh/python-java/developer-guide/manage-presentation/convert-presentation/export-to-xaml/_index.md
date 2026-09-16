---
title: 在 Python via Java 中将演示文稿导出为 XAML
linktitle: 演示文稿到 XAML
type: docs
weight: 30
url: /zh/python-java/export-to-xaml/
keywords:
- 导出 PowerPoint
- 导出 OpenDocument
- 导出演示文稿
- 转换 PowerPoint
- 转换 OpenDocument
- 转换演示文稿
- PowerPoint 转 XAML
- OpenDocument 转 XAML
- 演示文稿转 XAML
- PPT 转 XAML
- PPTX 转 XAML
- ODP 转 XAML
- 将 PPT 保存为 XAML
- 将 PPTX 保存为 XAML
- 将 ODP 保存为 XAML
- 导出 PPT 为 XAML
- 导出 PPTX 为 XAML
- 导出 ODP 为 XAML
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 将 PowerPoint 和 OpenDocument 演示文稿导出为 XAML。可使用默认选项或包含隐藏幻灯片。"
---
## **概述**

本文说明如何使用 Aspose.Slides for Python via Java 将 PowerPoint 演示文稿导出为 XAML。它包括对 XAML 的简要介绍，展示如何使用默认设置将演示文稿保存为 XAML，并演示如何通过 [XamlOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/xamloptions/) 自定义导出，包括导出隐藏幻灯片。文章还回答了一些常见问题，涉及回退字体、XAML 堆栈兼容性以及隐藏幻灯片的导出行为。

示例需要 Aspose.Slides for Python via Java 以及兼容的 Java 运行时。请将 `pres.pptx` 放在当前工作目录中。每个示例只有在 JVM 未运行时才会启动它。

## **关于 XAML**

XAML 是一种基于 XML 的标记语言，用于在 WPF（Windows Presentation Foundation）、UWP（Universal Windows Platform）和 Xamarin.Forms 等框架中描述用户界面。

您可以在可视化设计器中使用 XAML 文件，也可以直接编写和编辑标记。

## **使用默认选项导出演示文稿为 XAML**

以下 Python 示例展示了如何使用默认设置将演示文稿导出为 XAML：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

默认情况下，导出的幻灯片会保存在进程当前工作目录的 `pres` 子文件夹中。该文件夹会自动创建，所需的图像也会保存在其中。

输出文件夹名称取自源文件名（不含扩展名）。对于 `pres.pptx`，输出文件命名为 `pres/Slide_1.xaml`、`pres/Slide_2.xaml` 等。即使提供了输入演示文稿的绝对路径，输出文件夹也会相对于当前工作目录创建，而不是与输入文件并列。

## **使用自定义选项导出演示文稿为 XAML**

使用 [XamlOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/xamloptions/) 类来控制 Aspose.Slides 将演示文稿导出为 XAML 的方式。

若要将输出保存到自定义位置，请实现 `IXamlOutputSaver` 并将您的实现实例传递给 [XamlOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/xamloptions/) 的 [setOutputSaver](https://reference.aspose.com/slides/zh/python-java/aspose.slides/xamloptions/#setOutputSaver) 方法。

若要在 XAML 输出中包含隐藏幻灯片，请使用 `True` 调用 [setExportHiddenSlides](https://reference.aspose.com/slides/zh/python-java/aspose.slides/xamloptions/#setExportHiddenSlides)，如下 Python 示例所示：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    xaml_options.setExportHiddenSlides(True)
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

## **捕获所有生成的 XAML 工件**

一次 XAML 导出可以为每张导出的幻灯片生成一个 XAML 文档，并产生单独的图像和支持资源。将自定义 `IXamlOutputSaver` 分配给 [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/zh/python-java/aspose.slides/xamloptions/#setOutputSaver) 以接收这些工件，而不是使用默认的文件系统保存器。使用接受 XAML 选项的特定于 XAML 的 [Presentation.save](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#save) 重载启动导出。

在 Python 中，使用 `jpype.JProxy` 实现 Java `IXamlOutputSaver` 接口。将回调路径转换为 `str`，并在返回前将 Java 字节数组复制为 Python `bytes`，如下示例所示。

### **了解回调生命周期**

导出器会针对每个生成的工件单独调用 `IXamlOutputSaver.save`：

- `path` 用于标识工件，可能包含相对目录。请保留此信息，因为 XAML 可能使用相对路径引用资源。
- `data` 包含工件的字节。图像和其他二进制资源不能被解码为文本。
- 保存器负责在返回之前保留或持久化这些数据。示例中将每个字节数组复制到应用程序拥有的内存中。
- 仅当演示文稿保存操作返回且每个回调都成功完成时才视导出为成功。不要吞噬存储错误或启动未观察的后台写入。如果持久化在之后发生，仅在该步骤成功后才报告整体成功。

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/zh/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) 同样适用于自定义保存器。默认设置为 `False`，会排除隐藏幻灯片的 XAML 文档。传入 `True` 则会包含它们以及导出所需的任何资源。资源数量取决于演示文稿；不要假设每张幻灯片对应一个回调或回调顺序固定。

### **导出到内存并检查工件**

此完整示例加载 `pres.pptx`，将每个工件收集到一个 Python 字典中（键为名称，值为不可变的 `bytes`），并打印其名称、类型和字节计数。它会完整保留提供的名称。如果出现重复名称，则标记集合为无效，而不是悄悄覆盖工件。示例在使用结果前会进行此检查。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

class MemoryXamlSaver:
    def __init__(self):
        self.artifacts = {}
        self.valid = True

    def save(self, path, data):
        name = str(path)
        if name in self.artifacts:
            self.valid = False
            print(f"Export rejected: duplicate artifact name: {name}")
            return
        self.artifacts[name] = bytes(data)

def main():

    saver = MemoryXamlSaver()
    output_saver = jpype.JProxy("com.aspose.slides.IXamlOutputSaver", inst=saver)
    presentation = Presentation("pres.pptx")
    try:
        options = XamlOptions()
        options.setOutputSaver(output_saver)
        options.setExportHiddenSlides(True)
        presentation.save(options)
    finally:
        presentation.dispose()

    if not saver.valid:
        print("Export rejected: the artifact collection is invalid.")
        return

    inspect_xaml_text = False
    image_extensions = (".png", ".jpg", ".jpeg", ".gif", ".bmp", ".tif", ".tiff", ".svg")
    for name, data in saver.artifacts.items():
        lower_name = name.lower()
        is_xaml = lower_name.endswith(".xaml")
        is_image = lower_name.endswith(image_extensions)
        kind = "slide XAML" if is_xaml else "image" if is_image else "supporting resource"
        print(f"{name}: {len(data)} bytes ({kind})")

        # 仅在需要文本检查时解码 XAML。
        if is_xaml and inspect_xaml_text:
            markup = data.decode("utf-8")
            print(markup)


main()
```

扩展名检查对于检查非常有用；保留所有工件，包括不熟悉的资源类型。存储或传输时保持字节不变。仅在需要对 XAML 进行文本处理时才使用 UTF-8 的 `bytes.decode`。

### **将收集的工件打包为 ZIP 存档**

此独立示例收集导出内容，验证其名称，并将原始字节写入 ZIP 存档。唯一的存档名称用于区分并发的导出任务。ZIP 条目使用正斜杠并保留相对目录。若名称不安全或经规范化后冲突，则在写入之前拒绝整个包。

```python
from uuid import uuid4
from zipfile import ZipFile

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

class MemoryXamlSaver:
    def __init__(self):
        self.artifacts = {}
        self.valid = True

    def save(self, path, data):
        name = str(path)
        if name in self.artifacts:
            self.valid = False
            print(f"Export rejected: duplicate artifact name: {name}")
            return
        self.artifacts[name] = bytes(data)

def main():

    saver = MemoryXamlSaver()
    output_saver = jpype.JProxy("com.aspose.slides.IXamlOutputSaver", inst=saver)
    presentation = Presentation("pres.pptx")
    try:
        options = XamlOptions()
        options.setOutputSaver(output_saver)
        options.setExportHiddenSlides(False)
        presentation.save(options)
    finally:
        presentation.dispose()

    if not saver.valid:
        print("Export rejected: the artifact collection is invalid.")
        return

    entries = {}
    entry_names = set()
    for name, data in saver.artifacts.items():
        entry_name = name.replace("\\", "/")
        segments = entry_name.split("/")
        unsafe_name = entry_name.startswith("/") or ":" in entry_name or "\x00" in entry_name
        unsafe_name |= any(not segment.strip() or segment in (".", "..") for segment in segments)
        normalized_name = entry_name.casefold()
        if unsafe_name or normalized_name in entry_names:
            print(f"Export rejected: unsafe or duplicate artifact name: {name}")
            return
        entry_names.add(normalized_name)
        entries[entry_name] = data

    job_id = uuid4()
    archive_path = f"xaml-{job_id}.zip"
    try:
        with ZipFile(archive_path, mode="x") as archive:
            for name, data in entries.items():
                archive.writestr(name, data)

        # 关闭操作在报告成功之前完成 ZIP 目录的写入。
        print(f"Saved {len(entries)} artifacts to {archive_path}")
    except OSError as exception:
        print(f"Archive persistence failed: {exception}")


main()
```

示例使用 Python 的 `zipfile.ZipFile` 写入本地存档；导出器本身不会写入散列的 XAML 或图像文件。对于远程存储，可将写入存档的阶段替换为上传收集的字节数组。使用导出作业标识符加完整相对工件名称作为 blob 键，或在数据库行中存储作业标识符、相对名称和二进制数据。仅在所有上传完成或数据库事务提交后才发布作业。若持久化失败，请清理部分输出。

对于大型演示文稿，自定义保存器可以将每个工件直接持久化到应用程序存储，以避免在应用程序内存中保留整个导出的额外副本。确保每个回调对导出器而言是同步的：仅在目标接受字节后才返回，并让错误传递给调用方。

### **保留资源名称并验证引用**

- 当目标需要时规范化路径分隔符，但保留相对目录。除非已知每个生成的名称唯一且资源引用保持有效，否则不要仅使用 `pathlib.Path.name`。
- 实施针对目标的名称验证。写入松散文件时，拒绝根路径和遍历段，使用 `pathlib.Path.resolve` 解析目标，并验证其仍位于预期的导出目录下，包括在包含检查中使用目录分隔符。使用由应用程序控制且没有符号链接的目录，以防写入被重定向。
- 为每个导出作业使用独立的保存器和存储命名空间。根据分隔符规范化后以及目标的大小写敏感规则检测冲突。
- 在发布之前，将每个 XAML 文档作为 XML 进行解析，并检查其基于文件的资源引用，例如图像的 `Source` 或 `ImageSource` 属性。将每个相对 URI 相对于包含该 XAML 工件的目录进行解析，规范化得到的存储名称，并确认相应的映射键、ZIP 条目或存储对象是否存在。将外部 URI 和 XAML 标记表达式与相对文件名分开处理。

例如，如果 `pres/Slide_1.xaml` 引用了 `images/image1.png`，则存储的资源必须以 `pres/images/image1.png` 的形式存在。仅保留 `image1.png` 会破坏该关系。对于对象存储，请在作业前缀下保留相同的布局，并使这些资源 URL 可供 XAML 使用方访问。重新打开完成的 ZIP，验证条目名称和资源字节，并在目标 XAML 环境中加载代表性幻灯片，以确认图像能够正确解析。

## **常见问题**

**如果机器上没有原始字体，如何确保字体可预测？**

在 [XamlOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/xamloptions/) 中调用 [setDefaultRegularFont](https://reference.aspose.com/slides/zh/python-java/aspose.slides/saveoptions/#setDefaultRegularFont) —— 当原始字体缺失时，它会在导出期间用作回退字体。这并不保证生成的 XAML 会引用回退字体，或该字体在目标机器上可用。请确保 XAML 所引用的字体在显示环境中可用。

**导出的 XAML 仅用于 WPF，还是可以在其他 XAML 堆栈中使用？**

Aspose.Slides 通过其公共 API 导出 WPF XAML。与其他 XAML 堆栈（如 UWP 和 Xamarin.Forms）的兼容性不作保证。请在目标环境中测试生成的标记。

**是否支持隐藏幻灯片，如何防止默认导出它们？**

默认情况下，不会包含隐藏幻灯片。您可以通过 [XamlOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/xamloptions/) 中的 [setExportHiddenSlides](https://reference.aspose.com/slides/zh/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) 来控制此行为——如果不需要导出隐藏幻灯片，请保持其禁用。