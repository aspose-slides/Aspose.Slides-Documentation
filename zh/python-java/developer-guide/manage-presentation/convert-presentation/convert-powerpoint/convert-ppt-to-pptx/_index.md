---
title: 在 Python 中将 PPT 转换为 PPTX
linktitle: PPT 转 PPTX
type: docs
weight: 20
url: /zh/python-java/convert-ppt-to-pptx/
keywords:
- 转换 PowerPoint
- 转换演示文稿
- 转换幻灯片
- 转换 PPT
- PPT 转 PPTX
- 将 PPT 保存为 PPTX
- 导出 PPT 为 PPTX
- PowerPoint
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python 中将传统 PPT 文件转换为 PPTX。包括单文件和批量转换的 Python 示例、错误处理以及保真度说明。"
---
## **概述**

PPT 是传统的二进制 PowerPoint 格式，而 PPTX 是较新的 Open XML 格式。Aspose.Slides for Python via Java 可以在不依赖 Microsoft PowerPoint 的情况下加载 PPT 文件并将其保存为 PPTX。本文展示了如何转换单个文件或整个文件夹的文件，并说明转换后需要验证的事项。

每个示例在需要时启动 Java 虚拟机，并在使用后释放演示文稿。请将示例路径替换为您自己的文件或目录路径。

## **将 PPT 文件转换为 PPTX**

使用 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类加载源文件，然后调用 [Presentation.save](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#save) 并使用 [SaveFormat.Pptx](https://reference.aspose.com/slides/zh/python-java/aspose.slides/saveformat/#Pptx)。`finally` 块会释放演示文稿并释放其资源。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# 加载传统 PPT 演示文稿。
presentation = Presentation("presentation.ppt")
try:
    # 将演示文稿保存为 PPTX 格式。
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

文件扩展名本身不会选择输出格式；必须使用 [SaveFormat.Pptx](https://reference.aspose.com/slides/zh/python-java/aspose.slides/saveformat/#Pptx) 参数。若需保留原始 PPT 文件，请确保输入路径和输出路径不同。

## **批量转换 PPT 文件**

以下示例会转换指定目录中的每个 `.ppt` 文件。每个文件独立处理，因此单个转换失败不会影响其余批次。

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

input_directory = Path("input")
output_directory = Path("output")

try:
    output_directory.mkdir(parents=True, exist_ok=True)
    input_files = list(input_directory.iterdir())
except OSError as error:
    print(f"Cannot prepare the conversion directories: {error}")
else:
    for input_file in input_files:
        if not input_file.is_file() or input_file.suffix.lower() != ".ppt":
            continue

        output_file = output_directory / (input_file.stem + ".pptx")
        input_path = str(input_file)
        output_path = str(output_file)
        presentation = None

        try:
            presentation = Presentation(input_path)
            presentation.save(output_path, SaveFormat.Pptx)
            print(f"Converted: {input_path}")
        except Exception as error:
            print(f"Failed: {input_path} ({error})")
        finally:
            if presentation is not None:
                presentation.dispose()
```

在生产环境中，记录完整的异常信息，决定是否允许覆盖已存在的输出文件，并将失败的文件名写入重试或审查队列。损坏的文件、未提供所需密码而打开的受密码保护的文件、不可访问的路径以及不受支持的内容都可能导致转换失败。有关加载加密文件，请参阅 [Password-Protected Presentations](/slides/zh/python-java/password-protected-presentation/)。

## **保真度和传统功能**

转换通常会保留幻灯片、母版、布局、文本、形状、图像、表格和图表。然而，PPT 与 PPTX 并未以完全相同的方式呈现所有功能。对于没有 PPTX 等价项的传统功能，或库不支持的功能，可能会被标准化、省略或以不同方式显示。

当转换的文件包含动画、切换效果、嵌入或链接的 OLE 对象、ActiveX 控件、嵌入媒体、罕见字体或 VBA 宏时，请检查转换后的文件。普通 PPTX 文件不是支持宏的格式，因此在必须保留 VBA 时请使用相应的宏启用工作流。同时，确保在打开或渲染转换后演示文稿的环境中存在所需的字体和外部资源。

对于重要文档，建议以编程方式重新打开生成的 PPTX 并检查关键的幻灯片数量和内容，然后在目标查看器中比较其外观和幻灯片放映行为。不应将成功的 [Presentation.save](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#save) 调用视为每个传统功能都有精确 PPTX 表现的证明。

## **何时使用 PPTX**

当演示文稿将在当前版本的 PowerPoint 中进行编辑、需要与使用 Open XML 包的系统交换，或需要以更易检查和恢复的格式存储时，请使用 PPTX。保留原始 PPT 作为归档或回滚副本，直至转换后的演示文稿通过您的保真度检查。

如果需要 PDF、HTML、图像、XPS 或其他输出类型，请参考 [Convert Presentations to Multiple Formats](/slides/zh/python-java/convert-presentation/) 中的特定格式指南，而不要假设所有目标都能保留可编辑的 PowerPoint 功能。

## **在线转换器**

对于偶尔的文件或快速比较，您可以使用 [online PPT to PPTX converter](https://products.aspose.app/slides/zh/conversion/ppt-to-pptx)。对于可重复的转换、批量处理或应用级错误处理，请使用 Python via Java API。

## **相关文章**

- [PPT 与 PPTX 对比](/slides/zh/python-java/ppt-vs-pptx/)
- [在 Python 中保存演示文稿](/slides/zh/python-java/save-presentation/)
- [受支持的文件格式](/slides/zh/python-java/supported-file-formats/)
- [在 Python 中打开演示文稿](/slides/zh/python-java/open-presentation/)

## **常见问题**

**是否可以在未安装 Microsoft PowerPoint 的情况下将 PPT 转换为 PPTX？**

是的。Aspose.Slides for Python via Java 可以在不需要 Microsoft PowerPoint 的情况下加载和保存演示文稿文件。

**PPT 转 PPTX 的转换会完全保留所有内容吗？**

它会保留常见的演示文稿内容，但对于每个传统或不受支持的功能，无法保证完全的保真度。当文件包含宏、OLE 或 ActiveX 对象、媒体、特殊动画或罕见字体时，请检查生成的文件。

**是否可以转换受密码保护的 PPT 文件？**

可以，只需在加载文件时提供正确的密码。缺少或错误的密码会导致加载操作失败。

**转换后是否应删除 PPT 文件？**

在您验证了在相关查看器和工作流中的 PPTX 之前，请保留原始文件。如果某些传统功能转换后与预期不同，这也提供了回滚副本。