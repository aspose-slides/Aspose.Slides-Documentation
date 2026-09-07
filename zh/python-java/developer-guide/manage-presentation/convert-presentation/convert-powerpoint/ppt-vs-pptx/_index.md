---
title: "了解差异：PPT 与 PPTX"
linktitle: PPT 与 PPTX
type: docs
weight: 10
url: /zh/python-java/ppt-vs-pptx/
keywords:
- PPT 与 PPTX
- PPT 或 PPTX
- 传统格式
- 现代格式
- 二进制格式
- Office Open XML
- PowerPoint
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "比较 PPT 与 PPTX 格式、兼容性以及使用 Aspose.Slides for Python via Java 的转换选项，包含 Python 代码示例。"
---
## **概述**

PPT 和 PPTX 是 PowerPoint 演示文稿格式，内部结构和功能支持不同。 PPT 是 PowerPoint 97–2003 使用的传统二进制格式。 PPTX 是随 PowerPoint 2007 引入的 Office Open XML 格式。本文比较这两种格式，并展示如何使用 Aspose.Slides for Python via Java 将 PPT 文件转换为 PPTX。

## **什么是 PPT？**

[PPT](https://docs.fileformat.com/presentation/ppt/) 将演示文稿数据存储在二进制结构中。读取或修改其内容需要能够理解该结构的软件。当与旧版 PowerPoint 交换文件时 PPT 很有用，但它对较新演示功能的表示能力有限。

## **什么是 PPTX？**

[PPTX](https://docs.fileformat.com/presentation/pptx/) 基于 Office Open XML。PPTX 文件是一个包含 XML 部分、媒体以及这些部分之间关系的 ZIP 包。相比二进制 PPT，这种结构更易于检查和扩展。自 PowerPoint 2007 起，PowerPoint 将 PPTX 作为其默认演示文稿格式。

## **PPT 与 PPTX 对比**

| 方面 | PPT | PPTX |
| --- | --- | --- |
| 内部结构 | 二进制记录 | 包含 XML 和媒体的 ZIP 包 |
| 典型兼容性要求 | PowerPoint 97–2003 工作流 | PowerPoint 2007 及以后工作流 |
| 更新的演示功能 | 支持有限；某些内容可能被简化 | 更广泛地支持新对象和效果 |
| 推荐使用 | 与需要 PPT 的系统交换 | 新建演示文稿及持续编辑 |

在两种格式之间转换不仅仅是更改文件扩展名。有些 PPTX 功能在 PPT 中没有直接对应的等价物。PowerPoint 可以在特殊的 PPT 记录（例如 MetroBlob 数据）中存储额外信息，以保留新内容以备后用。旧版 PowerPoint 无法显示所有这些内容，因此即使存储，也不能保证在所有查看器中演示文稿的外观或行为保持一致。

Aspose.Slides for Python via Java 提供了一个通用 API，用于加载和保存这两种格式。它支持双向转换，但格式差异和不受支持的功能可能影响结果。尽可能使用 PPTX，并在目标查看器中检查转换为 PPT 的演示文稿。

{{% alert color="info" title="Note" %}}
尝试使用 [Aspose.Slides Conversion app](https://products.aspose.app/slides/zh/conversion/) 在线比较 PPT 到 PPTX 和 PPTX 到 PPT 的转换结果。
{{% /alert %}}

## **在 Python 中将 PPT 转换为 PPTX**

使用 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类加载 PPT 文件，然后使用 [Presentation.save](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#save) 并传入 [SaveFormat.Pptx](https://reference.aspose.com/slides/zh/python-java/aspose.slides/saveformat/#Pptx) 进行保存。无需 Microsoft PowerPoint。

示例在需要时启动 Java 虚拟机，并在 `finally` 块中释放演示文稿资源。请将输入和输出路径替换为您自己的文件名。

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

更多示例请参阅 [Convert PPT to PPTX in Python](/slides/zh/python-java/convert-ppt-to-pptx/)。关于相反方向的转换及其兼容性考虑，请参阅 [Convert PPTX to PPT in Python](/slides/zh/python-java/convert-pptx-to-ppt/).

## **常见问题**

**如果旧的 PPT 演示文稿可以正常打开，仍然保留它们有意义吗？**

当现有工作流需要 PPT 时，可继续保留 PPT。若进行持续编辑并使用新功能，建议 [转换为 PPTX](/slides/zh/python-java/convert-ppt-to-pptx/)。在检查转换后的演示文稿之前，请保留原始文件。

**我应该先将哪些演示文稿转换为 PPTX？**

优先处理那些经常编辑或共享的文件，包含复杂的 [charts](/slides/zh/python-java/create-chart/) 或 [shapes](/slides/zh/python-java/shape-manipulations/)，或在 [打开](/slides/zh/python-java/open-presentation/) 时触发兼容性警告的文件。转换后检查它们的外观和幻灯片放映行为。

**在 PPT 与 PPTX 之间转换时，密码保护会被保留吗？**

不要假设输出的保护会自动与源文件相同。加载加密文件时提供必要的密码，显式配置输出保护，并验证保存的文件。参见 [Password-Protected Presentations](/slides/zh/python-java/password-protected-presentation/).

**为什么在将 PPTX 转换为 PPT 时，一些效果会消失或变得更简单？**

PPT 无法表示所有新对象、属性或效果。某些信息可能会被保留以供稍后恢复，但旧版查看器无法显示全部内容。若需保留新功能，请保留原始 PPTX。