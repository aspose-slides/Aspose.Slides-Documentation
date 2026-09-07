---
title: 在 Python 中将 PPTX 转换为 PPT
linktitle: PPTX 转 PPT
type: docs
weight: 21
url: /zh/python-java/convert-pptx-to-ppt/
keywords:
- 转换 PowerPoint
- 转换 演示文稿
- 转换 幻灯片
- 转换 PPTX
- PPTX 转 PPT
- 将 PPTX 保存为 PPT
- 导出 PPTX 为 PPT
- PowerPoint
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 在 Python 中将 PPTX 转换为传统 PPT 格式。包括代码示例以及有关兼容性和受保护文件的说明。"
---
## **概述**

Aspose.Slides for Python via Java 允许您在未安装 Microsoft PowerPoint 的情况下，将 PPTX 演示文稿转换为 PowerPoint 97–2003 使用的旧版 PPT 格式。加载 PPTX 文件并使用 PPT 输出格式保存，如下所示。

## **将 PPTX 转换为 PPT**

使用 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类加载源文件，然后使用输出路径和 [SaveFormat.Ppt](https://reference.aspose.com/slides/zh/python-java/aspose.slides/saveformat/#Ppt) 调用 [Presentation.save](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#save)。

以下示例在需要时启动 Java 虚拟机，并使用默认选项将 `template.pptx` 转换为 `output.ppt`。将路径替换为您自己的文件名。即使保存失败，`finally` 块也会释放演示文稿资源。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# 加载 PPTX 演示文稿。
presentation = Presentation("template.pptx")
try:
    # 将演示文稿保存为 PPT 格式。
    presentation.save("output.ppt", SaveFormat.Ppt)
finally:
    presentation.dispose()
```

[SaveFormat.Ppt](https://reference.aspose.com/slides/zh/python-java/aspose.slides/saveformat/#Ppt) 参数用于选择输出格式，仅更改文件扩展名并不能转换演示文稿。保留原始 PPTX 文件，以便在新功能在 PPT 中没有等价时能够返回。

## **将 PPTX 转换为其他格式**

Aspose.Slides 还支持其他输出格式。请参阅相应文章以了解特定格式的选项和示例：

- [在 Python 中将 PowerPoint 转换为 PDF](/slides/zh/python-java/convert-powerpoint-to-pdf/)
- [在 Python 中将 PowerPoint 转换为 XPS](/slides/zh/python-java/convert-powerpoint-to-xps/)
- [在 Python 中将 PowerPoint 转换为 HTML](/slides/zh/python-java/convert-powerpoint-to-html/)
- [在 Python 中将演示文稿保存为 ODP](/slides/zh/python-java/save-presentation/)
- [在 Python 中将 PowerPoint 转换为 PNG](/slides/zh/python-java/convert-powerpoint-to-png/)

## **常见问题**

**所有 PPTX 效果和功能在转换为 PPT 时都能保留吗？**

并非总是如此。旧版 PPT 格式并不支持 PPTX 中的所有功能。某些效果、对象或行为可能会被简化或以不同方式显示。请在目标查看器中检查转换后的演示文稿，特别是当其中包含较新的 PowerPoint 功能时。

**我可以只将选定的幻灯片转换为 PPT 吗？**

保存为 PPT 时会写入整个演示文稿。若要仅转换选定的幻灯片，需要创建一个新演示文稿，删除其初始的空白幻灯片，将所需幻灯片克隆进去，然后保存为 PPT。请参阅 [在 Python 中克隆幻灯片](/slides/zh/python-java/clone-slides/)。

**我可以转换受密码保护的 PPTX 文件吗？**

可以，只要在加载源演示文稿时提供正确的密码。您还可以为输出文件配置保护。请参阅 [受密码保护的演示文稿](/slides/zh/python-java/password-protected-presentation/)。