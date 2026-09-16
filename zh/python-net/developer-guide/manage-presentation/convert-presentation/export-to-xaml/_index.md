---
title: 使用 Python 将演示文稿导出为 XAML
linktitle: 演示文稿转 XAML
type: docs
weight: 30
url: /zh/python-net/export-to-xaml/
keywords:
- 导出 PowerPoint
- 导出 OpenDocument
- 导出演示文稿
- 转换 PowerPoint
- 转换 OpenDocument
- 转换演示文稿
- PowerPoint 转 XAML
- OpenDocument 转 XAML
- 演示文稿 转 XAML
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
- Aspose.Slides
description: "使用 Aspose.Slides 将 PowerPoint 和 OpenDocument 幻灯片转换为 XAML，使用 Python——快速、无需 Office 的解决方案，保持布局完整。"
---
## **概述**

本文介绍如何使用 Aspose.Slides 将 PowerPoint 演示文稿导出为 XAML。它包括对 XAML 的简要介绍，展示了如何使用默认设置将演示文稿保存为 XAML，并演示如何通过 [XamlOptions](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export.xaml/xamloptions/) 自定义导出，包括导出隐藏幻灯片。本文还回答了一些常见问题，涉及回退字体、XAML 堆栈兼容性以及隐藏幻灯片导出行为。

## **关于 XAML**

XAML 是一种基于 XML 的标记语言，用于在 WPF（Windows Presentation Foundation）、UWP（Universal Windows Platform）和 Xamarin.Forms 等框架中描述用户界面。您可以在可视化设计器中使用 XAML 文件，亦可直接编写和编辑标记。

## **使用默认选项将演示文稿导出为 XAML**

以下 Python 示例展示了如何使用默认设置将演示文稿导出为 XAML：

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    xaml_options = slides.export.xaml.XamlOptions()
    presentation.save(xaml_options)
```

默认情况下，导出的幻灯片会保存在进程当前工作目录的 `pres` 子文件夹中，路径由 [os.getcwd](https://docs.python.org/3/library/os.html#os.getcwd) 返回。该文件夹会自动创建，所需的图像也会保存到其中。

输出文件夹的名称取自源文件名（不含扩展名）。对于 `pres.pptx`，输出文件命名为 `pres/Slide_1.xaml`、`pres/Slide_2.xaml` 等。即使为输入演示文稿提供绝对路径，输出文件夹仍相对于当前工作目录创建，而不是与输入文件同级。

## **使用自定义选项将演示文稿导出为 XAML**

使用 [XamlOptions](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export.xaml/xamloptions/) 类来控制 Aspose.Slides 将演示文稿导出为 XAML 的方式。

要在 XAML 输出中包含隐藏幻灯片，请将 [export_hidden_slides](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) 属性设为 `True`，如下 Python 示例所示：

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    xaml_options = slides.export.xaml.XamlOptions()
    xaml_options.export_hidden_slides = True
    presentation.save(xaml_options)
```

## **捕获所有生成的 XAML 产物**

XAML 导出可以为每个导出的幻灯片生成一个 XAML 文档，并附带单独的图像和支持资源。在存储或传输导出内容时请保留所有这些文件。

以下示例使用默认的文件系统保存器在临时目录中进行保存，然后收集生成的文件。

### **了解导出生命周期**

- 使用接受 XAML 选项的特定于 XAML 的 [Presentation.save](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/save/) 重载启动导出。仅在其成功返回后读取生成的文件。
- 保留每个产物的相对路径，因为 XAML 可能使用相对路径引用资源。
- 以字节形式读取产物。图像和其他二进制资源不得解码为文本。
- 仅在收集完成且后续任何存储操作完成后报告整体成功。将存储错误传递给调用者，并在持久化失败时清理部分输出。

[XamlOptions.export_hidden_slides](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) 默认值为 `False`，会排除隐藏幻灯片的 XAML 文档。将其设为 `True` 会包含隐藏幻灯片及其导出所需的所有资源。资源数量取决于演示文稿，不能假设每张幻灯片对应一个文件。

{{% alert color="warning" title="Warning" %}}
这些示例会临时更改进程的当前工作目录，进而影响所有线程。请在专用的工作进程中运行每次导出，或确保在导出期间进程中的其他工作不依赖于当前目录。仅使用唯一的临时目录并不能保证同一进程中并发导出的安全性。
{{% /alert %}}

### **导出到内存并检查产物**

此完整示例加载 `pres.pptx`，将其导出到临时目录，收集每个产物到一个相对名称和字节的字典中，并打印其名称、类型和字节数。它保留生成的目录结构，并在收集后删除临时文件。输入路径在更改工作目录之前已解析。

```python
import os
from pathlib import Path
from tempfile import TemporaryDirectory

import aspose.slides as slides


def collect_xaml_artifacts(source_path, export_hidden_slides):
    source_path = Path(source_path).resolve()
    original_directory = Path.cwd()
    artifacts = {}

    with TemporaryDirectory(prefix="xaml-") as temporary_directory:
        try:
            os.chdir(temporary_directory)
            with slides.Presentation(str(source_path)) as presentation:
                options = slides.export.xaml.XamlOptions()
                options.export_hidden_slides = export_hidden_slides
                presentation.save(options)

            for artifact_path in Path(temporary_directory).rglob("*"):
                if artifact_path.is_file():
                    relative_path = artifact_path.relative_to(temporary_directory)
                    artifacts[relative_path.as_posix()] = artifact_path.read_bytes()
        finally:
            os.chdir(original_directory)

    return artifacts


artifacts = collect_xaml_artifacts("pres.pptx", True)
inspect_xaml_text = False
image_extensions = {".png", ".jpg", ".jpeg", ".gif", ".bmp", ".tif", ".tiff", ".svg"}
for name, data in artifacts.items():
    extension = Path(name).suffix.lower()
    if extension == ".xaml":
        kind = "slide XAML"
    elif extension in image_extensions:
        kind = "image"
    else:
        kind = "supporting resource"
    print(f"{name}: {len(data)} bytes ({kind})")

    # 仅在需要文本检查时解码 XAML。
    if extension == ".xaml" and inspect_xaml_text:
        print(data.decode("utf-8"))
```

扩展名检查有助于检查；保留所有产物，包括不熟悉的资源类型。存储或传输时保持字节不变。仅对需要文本处理的 XAML 进行解码。此方法同时使用临时磁盘空间和内存来保存收集的导出。

### **将收集的产物打包为 ZIP 存档**

此独立示例收集导出内容，验证其名称，并将原始字节写入 ZIP 存档。唯一的存档名称用于区分导出作业。ZIP 条目使用正斜杠并保留相对目录。出现不安全的名称或规范化后冲突的名称会在写入前拒绝整个包。

```python
from uuid import uuid4
from zipfile import ZIP_DEFLATED, ZipFile
import os
from pathlib import Path
from tempfile import TemporaryDirectory

import aspose.slides as slides


def collect_xaml_artifacts(source_path, export_hidden_slides):
    source_path = Path(source_path).resolve()
    original_directory = Path.cwd()
    artifacts = {}

    with TemporaryDirectory(prefix="xaml-") as temporary_directory:
        try:
            os.chdir(temporary_directory)
            with slides.Presentation(str(source_path)) as presentation:
                options = slides.export.xaml.XamlOptions()
                options.export_hidden_slides = export_hidden_slides
                presentation.save(options)

            for artifact_path in Path(temporary_directory).rglob("*"):
                if artifact_path.is_file():
                    relative_path = artifact_path.relative_to(temporary_directory)
                    artifacts[relative_path.as_posix()] = artifact_path.read_bytes()
        finally:
            os.chdir(original_directory)

    return artifacts


def package_xaml():
    artifacts = collect_xaml_artifacts("pres.pptx", False)
    entries = {}
    normalized_names = set()
    for name, data in artifacts.items():
        entry_name = name.replace("\\", "/")
        segments = entry_name.split("/")
        unsafe_name = entry_name.startswith("/") or ":" in entry_name
        unsafe_name = unsafe_name or any(not segment.strip() or segment in {".", ".."} for segment in segments)
        normalized_name = entry_name.casefold()
        if unsafe_name or normalized_name in normalized_names:
            print(f"Export rejected: unsafe or duplicate artifact name: {name}")
            return
        normalized_names.add(normalized_name)
        entries[entry_name] = data

    archive_path = Path(f"xaml-{uuid4().hex}.zip")
    with ZipFile(archive_path, "x", compression=ZIP_DEFLATED) as archive:
        for name, data in entries.items():
            archive.writestr(name, data)

    # ZIP 目录已在报告成功之前完成。
    print(f"Saved {len(entries)} artifacts to {archive_path}")


package_xaml()
```

示例使用 [ZipFile](https://docs.python.org/3/library/zipfile.html#zipfile.ZipFile) 在收集完临时导出后写入本地存档。对于远程存储，可将写入存档的阶段替换为对收集字节的上传。使用导出作业标识符加完整相对产物名称作为对象键，或在数据库行中存储作业标识符、相对名称和二进制数据。仅在所有上传完成或数据库事务提交后发布作业。持久化失败时清理部分输出。

对于大型演示文稿，导出后一次处理一个临时文件，而不是将所有字节收集到字典中。这可以避免对整个导出进行额外的内存复制，但并不能消除导出器自身的内存需求。

### **保留资源名称并验证引用**

- 当目标需要时归一化路径分隔符，但保留相对目录。除非确认每个生成的名称都是唯一且资源引用仍然有效，否则不要只保留最终文件名。
- 应用目标特定的名称验证。写入松散文件时，拒绝绝对路径和遍历段，解析目标并确保其位于预期的导出目录下。使用受应用程序控制且不含符号链接的目录，以防写入被重定向。
- 为每个导出作业使用单独的存储命名空间。根据分隔符归一化后以及目标的大小写敏感规则检测冲突。
- 在发布之前，将每个 XAML 文档作为 XML 解析并检查其基于文件的资源引用，例如图像的 `Source` 或 `ImageSource` 属性。将每个相对 URI 解析相对于包含该 XAML 产物的目录，归一化得到的存储名称，并确认相应的字典键、ZIP 条目或存储对象存在。将外部 URI 与 XAML 标记表达式与相对文件名分开处理。

例如，如果 `pres/Slide_1.xaml` 引用 `images/image1.png`，则存储的资源必须以 `pres/images/image1.png` 形式可用。仅保留 `image1.png` 会破坏此关系。对于对象存储，在作业前缀下保持相同的布局，并使这些资源 URL 对 XAML 使用者可访问。重新打开已完成的 ZIP 以验证条目名称和资源字节，并在目标 XAML 环境中加载代表性幻灯片，确认图像能够正确解析。

## **常见问题**

**如果原始字体在机器上不可用，如何确保字体可预测？**  
在 [XamlOptions](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export.xaml/xamloptions/) 中设置 [default_regular_font](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export.xaml/xamloptions/default_regular_font/)，当原始字体缺失时导出会使用该回退字体。此设置并不保证生成的 XAML 实际引用回退字体，也不保证目标机器上已安装该字体。请确保 XAML 所引用的字体在显示环境中可用。

**导出的 XAML 仅针对 WPF，还是也可用于其他 XAML 堆栈？**  
Aspose.Slides 通过其公开 API 导出 WPF XAML。对其他 XAML 堆栈（如 UWP 和 Xamarin.Forms）的兼容性没有保证。请在目标环境中测试生成的标记。

**是否支持隐藏幻灯片，如何阻止默认导出它们？**  
默认情况下不会包含隐藏幻灯片。您可以通过在 [XamlOptions](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export.xaml/xamloptions/) 中的 [export_hidden_slides](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) 属性进行控制——如果不需要导出隐藏幻灯片，请保持该属性为禁用状态。