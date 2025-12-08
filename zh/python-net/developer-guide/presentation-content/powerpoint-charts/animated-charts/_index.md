---
title: 在 Python 中为 PowerPoint 图表添加动画
linktitle: 动画图表
type: docs
weight: 80
url: /zh/python-net/animated-charts/
keywords:
- 图表
- 动画图表
- 图表动画
- 图表系列
- 图表类别
- 系列元素
- 类别元素
- 添加效果
- 效果类型
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python 中创建惊艳的动态图表。通过 PPT、PPTX 和 ODP 文件中的动态视觉效果提升演示文稿——立即开始。"
---

Aspose.Slides for Python via .NET 支持对图表元素进行动画。**Series**、**Categories**、**Series Elements**、**Categories Elements** 可使用 [**ISequence**.**AddEffect**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/isequence/) 方法以及两个枚举 [**EffectChartMajorGroupingType**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effectchartmajorgroupingtype/) 和 [**EffectChartMinorGroupingType**](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effectchartminorgroupingtype/) 进行动画。

## **图表系列动画**
如果您想对图表系列进行动画，请按照以下步骤编写代码：

1. 加载演示文稿。
1. 获取图表对象的引用。
1. 对系列进行动画处理。
1. 将演示文稿文件写入磁盘。

在下面的示例中，我们对图表系列进行了动画处理。
```py
import aspose.slides.animation as anim;
import aspose.slides as slides

# 实例化表示演示文稿文件的 Presentation 类
with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    # 获取图表对象的引用
    slide = presentation.slides[0]
    shapes = slide.shapes
    chart = shapes[0]

    # 为系列添加动画
    slide.timeline.main_sequence.add_effect(chart, 
        anim.EffectType.FADE, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, 
        anim.EffectChartMajorGroupingType.BY_SERIES, 0, 
        anim.EffectType.APPEAR, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart,
        anim.EffectChartMajorGroupingType.BY_SERIES, 1,
        anim.EffectType.APPEAR, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart,
        anim.EffectChartMajorGroupingType.BY_SERIES, 2,
        anim.EffectType.APPEAR, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart,
        anim.EffectChartMajorGroupingType.BY_SERIES, 3,
        anim.EffectType.APPEAR, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    # 将修改后的演示文稿写入磁盘 
    presentation.save("AnimatingSeries_out.pptx", slides.export.SaveFormat.PPTX)
```


## **图表类别动画**
如果您想对图表类别进行动画，请按照以下步骤编写代码：

1. 加载演示文稿。
1. 获取图表对象的引用。
1. 对类别进行动画处理。
1. 将演示文稿文件写入磁盘。

在下面的示例中，我们对图表类别进行了动画处理。
```py
import aspose.slides.animation as anim;
import aspose.slides as slides

with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    # 获取图表对象的引用
    slide = presentation.slides[0]
    shapes = slide.shapes
    chart = shapes[0]

    # 为类别元素添加动画
    slide.timeline.main_sequence.add_effect(chart, anim.EffectType.FADE, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    # 将演示文稿文件写入磁盘
    presentation.save("AnimatingCategoriesElements_out.pptx", slides.export.SaveFormat.PPTX)
```


## **系列元素的动画**
如果您想对系列元素进行动画，请按照以下步骤编写代码：

1. 加载演示文稿。
1. 获取图表对象的引用。
1. 对系列元素进行动画处理。
1. 将演示文稿文件写入磁盘。

在下面的示例中，我们对系列的元素进行了动画处理。
```py
import aspose.slides.animation as anim;
import aspose.slides as slides

# 加载演示文稿
with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    # 获取图表对象的引用
    slide = presentation.slides[0]
    shapes = slide.shapes
    chart = shapes[0]

    # 为系列元素添加动画
    slide.timeline.main_sequence.add_effect(chart, anim.EffectType.FADE, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 0, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 0, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 0, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 0, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 1, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 1, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 1, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 1, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 2, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 2, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 2, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_SERIES, 2, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    # 将演示文稿文件写入磁盘 
    presentation.save("AnimatingSeriesElements_out.pptx", slides.export.SaveFormat.PPTX)
```


## **类别元素的动画**
如果您想对类别元素进行动画，请按照以下步骤编写代码：

1. 加载演示文稿。
1. 获取图表对象的引用。
1. 对类别元素进行动画处理。
1. 将演示文稿文件写入磁盘。

在下面的示例中，我们对类别元素进行了动画处理。
```py
import aspose.slides.animation as anim;
import aspose.slides as slides

with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    # 获取图表对象的引用
    slide = presentation.slides[0]
    shapes = slide.shapes
    chart = shapes[0]

    # 为类别元素添加动画
    slide.timeline.main_sequence.add_effect(chart, anim.EffectType.FADE, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 0, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 1, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 0, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 1, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 2, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)
    slide.timeline.main_sequence.add_effect(chart, anim.EffectChartMinorGroupingType.BY_ELEMENT_IN_CATEGORY, 2, 3, anim.EffectType.APPEAR, anim.EffectSubtype.NONE, anim.EffectTriggerType.AFTER_PREVIOUS)

    # 将演示文稿文件写入磁盘
    presentation.save("AnimatingCategoriesElements_out.pptx", slides.export.SaveFormat.PPTX)
```


## **常见问题**

**图表是否支持不同的效果类型（例如进入、强调、退出），如同普通形状一样？**

是的。图表被视为形状，因此支持标准的动画效果类型，包括进入、强调和退出，并且可以通过幻灯片的时间轴和动画序列进行完整控制。

**我可以将图表动画与幻灯片切换结合使用吗？**

是的。[切换](/slides/zh/python-net/slide-transition/) 适用于幻灯片，而动画效果适用于幻灯片上的对象。您可以在同一演示文稿中同时使用二者，并独立控制它们。

**保存为 PPTX 时，图表动画会被保留吗？**

是的。当您[保存为 PPTX](/slides/zh/python-net/save-presentation/)时，所有动画效果及其顺序都会被保留，因为它们是演示文稿原生动画模型的一部分。

**我可以读取演示文稿中已有的图表动画并进行修改吗？**

是的。该[API](https://reference.aspose.com/slides/python-net/aspose.slides.animation/)提供对幻灯片时间轴、序列和效果的访问，允许您检查现有的图表动画并在不重新创建的情况下进行调整。

**我可以使用 Aspose.Slides for Python via .NET 生成包含图表动画的视频吗？**

是的。您可以[导出演示文稿为视频](/slides/zh/python-net/convert-powerpoint-to-video/)并保留动画，配置时间和其他导出设置，以便生成的片段体现动画播放效果。