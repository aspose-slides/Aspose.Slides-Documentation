---
title: 使用 Python（通过 Java）为 PowerPoint 文本添加动画
linktitle: 动画文本
type: docs
weight: 60
url: /zh/python-java/animated-text/
keywords:
- 动画文本
- 文本动画
- 动画段落
- 段落动画
- 动画效果
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 在 PowerPoint 和 OpenDocument 演示文稿中创建动态动画文本，提供易于理解且经过优化的 Python 代码示例。"
---
## **概述**

本文介绍如何在 Aspose.Slides 中通过对单个段落应用动画效果以及检索已分配给文本框中段落的动画效果来处理动画文本。重点说明用于向段落级别添加动画和检查演示文稿中已有段落动画效果的 API 方法。

## **向段落添加动画效果**

[addEffect](https://reference.aspose.com/slides/zh/python-java/aspose.slides/sequence/#addEffect) 方法属于 [Sequence](https://reference.aspose.com/slides/zh/python-java/aspose.slides/sequence/) 类，可用于向单个段落添加动画效果。以下示例代码演示如何向单个段落添加动画效果：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

presentation = Presentation("Presentation.pptx")
try:
    # 选择要添加效果的段落。
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # 为选定的段落添加飞入动画效果。
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick)

    presentation.save("AnimationEffectinParagraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **获取段落的动画效果**

您可能需要检索已应用于段落的动画效果，例如将这些效果应用到另一个段落或形状。

Aspose.Slides for Python via Java 允许您获取文本框（形状）中段落所应用的所有动画效果。以下示例代码演示如何获取已应用于段落的动画效果：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Presentation.pptx")
try:
    sequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence()
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    for paragraph in auto_shape.getTextFrame().getParagraphs():
        effects = sequence.getEffectsByParagraph(paragraph)

        if len(effects) > 0:
            print(f'Paragraph "{paragraph.getText()}" has {effects[0].getType()} effect.')
finally:
    presentation.dispose()
```

## **常见问题**

**文本动画与幻灯片切换有何不同，是否可以组合使用？**

文本动画控制对象在幻灯片上的时间行为，而 [transitions](/slides/zh/python-java/slide-transition/) 控制幻灯片之间的切换方式。它们相互独立，可一起使用；播放顺序由动画时间轴和切换设置共同决定。

**导出为 PDF 或图像时，文本动画会被保留吗？**

不会。PDF 和光栅图像是静态的，只会显示幻灯片的单一状态而没有动画。如需保留动画，请使用 [video](/slides/zh/python-java/convert-powerpoint-to-video/) 或 [HTML](/slides/zh/python-java/export-to-html5/) 导出。

**文本动画在布局和母版中是否有效？**

应用于布局/母版对象的效果会被幻灯片继承，但其时间安排和与幻灯片级别动画的交互取决于幻灯片上的最终序列。