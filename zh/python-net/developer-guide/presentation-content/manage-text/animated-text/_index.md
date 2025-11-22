---
title: 在 Python 中为 PowerPoint 文本添加动画
linktitle: 动画文本
type: docs
weight: 60
url: /zh/python-net/animated-text/
keywords:
- 动画文本
- 文本动画
- 动画段落
- 段落动画
- 动画效果
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python 通过 .NET 在 PowerPoint 和 OpenDocument 演示文稿中创建动态动画文本，提供易于遵循的优化代码示例。"
---

## **概述**

本文展示了如何使用 Aspose.Slides for Python 在 PowerPoint 演示文稿中为文本添加动画。您将学习为单个段落添加效果、调整触发器以及读取现有的动画序列。完成后，您将能够创建可复用的文本动画工作流，导出为标准 PPTX 并在 PowerPoint 中正确播放。

## **为段落添加动画效果**

[Sequence](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/)类的[add_effect](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/add_effect/)方法允许您对单个段落应用动画效果。下面的示例代码演示了如何实现：
```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    # 选择要添加效果的段落。
    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # 为所选段落添加飞入动画效果。
    effect = slide.timeline.main_sequence.add_effect(paragraph,
                                                     slides.animation.EffectType.FLY,
                                                     slides.animation.EffectSubtype.LEFT,
                                                     slides.animation.EffectTriggerType.ON_CLICK)
    presentation.save("ParagraphAnimationEffect.pptx", slides.export.SaveFormat.PPTX)
```


## **获取段落动画效果**

您可能想确定段落上应用了哪些动画效果，例如，计划将这些效果复制到另一个段落或形状。

Aspose.Slides for Python 允许您检索文本框（形状）中段落所应用的所有动画效果。下面的示例代码展示了如何获取段落的动画效果：
```py
import aspose.slides as slides

with slides.Presentation("ParagraphAnimationEffect.pptx") as presentation:
    slide = presentation.slides[0]
    sequence = slide.timeline.main_sequence
    auto_shape = slide.shapes[0]

    for paragraph in auto_shape.text_frame.paragraphs:
        effects = sequence.get_effects_by_paragraph(paragraph)
        if len(effects) > 0:
            print(f"Paragraph \"{paragraph.text}\" has the first animation effect of type {str(effects[0].type)}.")
```


## **常见问题**

**文本动画与幻灯片切换有何不同，能否同时使用？**

文本动画控制对象在幻灯片上的随时间变化，而[transitions](/slides/zh/python-net/slide-transition/)控制幻灯片之间的切换方式。它们相互独立，可以一起使用；播放顺序由动画时间轴和切换设置决定。

**导出为 PDF 或图像时文本动画会保留吗？**

不会。PDF 和光栅图像是静态的，您只能看到幻灯片的单一状态而没有动画。若需保留动画，请使用[video](/slides/zh/python-net/convert-powerpoint-to-video/)或[HTML](/slides/zh/python-net/export-to-html5/)导出。

**文本动画在布局和母版中有效吗？**

应用于布局/母版对象的效果会被幻灯片继承，但其时序和与幻灯片级动画的交互取决于幻灯片上的最终序列。