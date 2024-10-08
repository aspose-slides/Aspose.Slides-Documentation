---
title: 动画文本
type: docs
weight: 60
url: /python-net/animated-text/
keywords: "动画文本, 动画效果, PowerPoint 演示文稿, Python, Aspose.Slides for Python via .NET"
description: "在 Python 中向 PowerPoint 演示文稿添加动画文本和效果"
---

## 向段落添加动画效果

我们将 [**add_effect()**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/) 方法添加到 [**Sequence**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/) 和 [**ISequence**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/isequence/) 类中。此方法允许您向单个段落添加动画效果。以下示例代码向您展示如何向单个段落添加动画效果：

```py
import aspose.slides as slides

with slides.Presentation(path + "Presentation1.pptx") as presentation:
    # 选择要添加效果的段落
    autoShape = presentation.slides[0].shapes[0]
    paragraph = autoShape.text_frame.paragraphs[0]

    # 向选定段落添加飞入动画效果
    effect = presentation.slides[0].timeline.main_sequence.add_effect(paragraph, slides.animation.EffectType.FLY, slides.animation.EffectSubtype.LEFT, slides.animation.EffectTriggerType.ON_CLICK)
    presentation.save("AnimationEffectinParagraph.pptx", slides.export.SaveFormat.PPTX)
```



## 获取段落中的动画效果

您可能决定查找添加到段落中的动画效果—例如，在一种情况下，您想获取段落中的动画效果，因为您计划将这些效果应用于另一个段落或形状。

Aspose.Slides for Python via .NET 允许您获取应用于文本框（形状）中段落的所有动画效果。以下示例代码向您展示如何获取段落中的动画效果：

```py
import aspose.slides as slides

with slides.Presentation("AnimationEffectinParagraph.pptx") as pres:
    sequence = pres.slides[0].timeline.main_sequence
    autoShape = pres.slides[0].shapes[0]
    for paragraph in autoShape.text_frame.paragraphs:
        effects = sequence.get_effects_by_paragraph(paragraph)
        if len(effects) > 0:
            print("段落 \"" + paragraph.text + "\" 具有 " + str(effects[0].type) + " 效果。")
```