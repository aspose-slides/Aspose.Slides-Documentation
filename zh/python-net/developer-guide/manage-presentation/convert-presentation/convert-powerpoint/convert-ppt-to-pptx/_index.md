---
title: 在 Python 中将 PPT 转换为 PPTX
linktitle: PPT 转 PPTX
type: docs
weight: 20
url: /zh/python-net/convert-ppt-to-pptx/
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
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python 中将传统 PPT 文件转换为 PPTX。包括单文件和批量转换示例、错误处理以及保真度说明。"
---
## **概述**

PPT 是传统的二进制 PowerPoint 格式，而 PPTX 是更新的 Open XML 格式。Aspose.Slides for Python via .NET 可以在无需 Microsoft PowerPoint 的情况下加载 PPT 文件并保存为 PPTX。本文展示如何转换单个文件或整个文件夹，并说明转换后需要检查的内容。

## **将 PPT 文件转换为 PPTX**

使用 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类加载源文件，然后调用 [Presentation.save](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/save/) 并传入 [SaveFormat.PPTX](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/saveformat/)。`with` 语句会在代码块结束时释放演示文稿并清理资源。

```python
import aspose.slides as slides

# 加载遗留的 PPT 演示文稿。
with slides.Presentation("presentation.ppt") as presentation:
    # 将演示文稿保存为 PPTX 格式。
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

文件扩展名本身并不会决定输出格式；是 [SaveFormat.PPTX](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/saveformat/) 参数起作用。如果需要保留原始 PPT 文件，请确保输入路径和输出路径不同。

## **批量转换 PPT 文件**

以下示例会转换指定目录下的每个 `.ppt` 文件。每个文件独立处理，单个转换失败不会影响其余文件。

```python
from pathlib import Path

import aspose.slides as slides

input_directory = Path("input")
output_directory = Path("output")
output_directory.mkdir(parents=True, exist_ok=True)

for input_path in input_directory.glob("*.ppt"):
    output_path = output_directory / f"{input_path.stem}.pptx"

    try:
        with slides.Presentation(str(input_path)) as presentation:
            presentation.save(str(output_path), slides.export.SaveFormat.PPTX)
        print(f"Converted: {input_path}")
    except Exception as exception:
        print(f"Failed: {input_path} ({exception})")
```

在生产环境中，记录完整的异常信息，决定是否可以覆盖已有的输出文件，并将失败的文件名写入重试或审核队列。损坏的文件、未提供正确密码的受保护文件、不可访问的路径以及不受支持的内容都可能导致转换失败。有关加载加密文件，请参阅 [Password-Protected Presentations](/slides/zh/python-net/password-protected-presentation/)。

## **保真度和遗留功能**

转换通常会保留幻灯片、母版、布局、文字、形状、图像、表格和图表。然而，PPT 与 PPTX 并未以完全相同的方式表示所有功能。没有 PPTX 对应项的遗留功能，或库不支持的功能，可能会被标准化、省略或以不同方式显示。

当转换后的文件包含动画、切换效果、嵌入或链接的 OLE 对象、ActiveX 控件、嵌入媒体、非主流字体或 VBA 宏时，请仔细检查。普通的 PPTX 文件并非宏启用格式，如需保留 VBA，请使用相应的宏启用工作流。同时确认所需字体和外部资源已在打开或渲染该演示文稿的环境中可用。

对于重要文档，建议以编程方式重新打开生成的 PPTX，检查关键幻灯片数量和内容，然后在目标查看器中比较其外观和放映行为。不要将一次成功的 [Presentation.save](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/save/) 调用视为所有遗留功能都有精确 PPTX 表示的证明。

## **何时使用 PPTX**

当演示文稿需在当前 PowerPoint 版本中编辑、与支持 Open XML 包的系统交换，或需要一种比传统二进制 PPT 更易检查和恢复的存储格式时，请使用 PPTX。保留原始 PPT 作为归档或回滚副本，直至转换后的演示文稿通过您的保真度检查。

如果您需要 PDF、HTML、图像、XPS 或其他输出类型，请参考 [Convert Presentations to Multiple Formats](/slides/zh/python-net/convert-presentation/) 中针对特定格式的指南，而不要假设所有目标格式都能保留可编辑的 PowerPoint 功能。

## **在线转换器**

对于偶尔的文件或快速对比，您可以使用 [online PPT to PPTX converter](https://products.aspose.app/slides/zh/conversion/ppt-to-pptx)。对于可重复的转换、批处理或应用级错误处理，请使用 Python API。

## **相关文章**

- [PPT vs PPTX](/slides/zh/python-net/ppt-vs-pptx/)
- [Save Presentations in Python](/slides/zh/python-net/save-presentation/)
- [Supported File Formats](/slides/zh/python-net/supported-file-formats/)
- [Open Presentations in Python](/slides/zh/python-net/open-presentation/)

## **常见问题**

**我可以在未安装 Microsoft PowerPoint 的情况下将 PPT 转换为 PPTX 吗？**

可以。Aspose.Slides for Python via .NET 能在不需要 Microsoft PowerPoint 的情况下加载和保存演示文稿文件。

**PPT 到 PPTX 的转换会完全保留所有内容吗？**

它会保留常见的演示文稿内容，但对每个遗留或不受支持的功能并不保证完全保真。当文件包含宏、OLE 或 ActiveX 对象、媒体、特殊动画或非主流字体时，请检查生成的文件。

**我可以转换受密码保护的 PPT 文件吗？**

可以，只要在加载文件时提供正确的密码。缺少或错误的密码会导致加载操作失败。

**转换后我应该删除 PPT 文件吗？**

请保留原始文件，直到您在相关查看器和工作流中验证了 PPTX 的效果。这可以在遗留功能转换出现差异时提供回滚副本。