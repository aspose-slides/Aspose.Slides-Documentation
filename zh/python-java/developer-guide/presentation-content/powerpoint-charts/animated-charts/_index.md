---
title: 在 Python via Java 中为 PowerPoint 图表添加动画
linktitle: 动画图表
type: docs
weight: 80
url: /zh/python-java/animated-charts/
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
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python via Java 中创建惊艳的动画图表。通过 PPT 和 PPTX 文件中的动态图形提升演示文稿——立即开始。"
---
## **介绍**

Aspose.Slides for Python via Java 支持对图表元素进行动画。可以使用 [Sequence.addEffect](https://reference.aspose.com/slides/zh/python-java/aspose.slides/sequence/#addEffect) 方法以及两个枚举： [EffectChartMajorGroupingType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/effectchartmajorgroupingtype/) 和 [EffectChartMinorGroupingType](https://reference.aspose.com/slides/zh/python-java/aspose.slides/effectchartminorgroupingtype/) 对 **Series**、**Categories**、**Series Elements** 和 **Category Elements** 进行动画化。

## **图表系列动画**

如果要为图表系列添加动画，请按下面的步骤编写代码：

1. 加载演示文稿。
1. 获取对图表对象的引用。
1. 为系列添加动画。
1. 将演示文稿写入磁盘。

下面的示例为图表系列添加动画。示例文件中的图表包含三个系列，因此为索引 0 到 2 的每个系列都添加了一个效果。Aspose.Slides 不会检查索引是否对应图表数据，若为不存在的系列添加效果，该效果仍会写入文件但不会产生动画——请确保索引小于实际系列的数量。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMajorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# 加载演示文稿。
presentation = Presentation("ExistingChart.pptx")
try:
    # 获取对图表对象的引用。
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # 为图表元素添加动画。
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # 将修改后的演示文稿写入磁盘。
    presentation.save("AnimatingSeries_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **图表类别动画**

如果要为图表类别添加动画，请按下面的步骤编写代码：

1. 加载演示文稿。
1. 获取对图表对象的引用。
1. 为类别添加动画。
1. 将演示文稿写入磁盘。

下面的示例为图表类别添加动画。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMajorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# 加载演示文稿。
presentation = Presentation("ExistingChart.pptx")
try:
    # 获取对图表对象的引用。
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # 为图表元素添加动画。
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # 将修改后的演示文稿写入磁盘。
    presentation.save("Sample_Animation_C.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **系列元素动画**

如果要为系列元素添加动画，请按下面的步骤编写代码：

1. 加载演示文稿。
1. 获取对图表对象的引用。
1. 为系列元素添加动画。
1. 将演示文稿写入磁盘。

下面的示例为系列元素添加动画。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMinorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# 加载演示文稿。
presentation = Presentation("ExistingChart.pptx")
try:
    # 获取对图表对象的引用。
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # 为图表元素添加动画。
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # 将修改后的演示文稿写入磁盘。
    presentation.save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **类别元素动画**

如果要为类别元素添加动画，请按下面的步骤编写代码：

1. 加载演示文稿。
1. 获取对图表对象的引用。
1. 为类别元素添加动画。
1. 将演示文稿写入磁盘。

下面的示例为类别元素添加动画。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMinorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# 加载演示文稿。
presentation = Presentation("ExistingChart.pptx")
try:
    # 获取对图表对象的引用。
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # 为图表元素添加动画。
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # 将修改后的演示文稿写入磁盘。
    presentation.save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **常见问题**

**不同的效果类型（例如出现、强调、退出）是否像普通形状一样支持图表？**

是的。图表被视为形状，因而支持标准的动画效果类型，包括出现、强调和退出，并可通过幻灯片的时间轴和动画序列进行完整控制。

**可以将图表动画与幻灯片切换效果组合使用吗？**

可以。[Transitions](/slides/zh/python-java/slide-transition/) 作用于整个幻灯片，而动画效果作用于幻灯片上的对象。两者可以在同一演示文稿中同时使用，并可独立控制。

**将演示文稿保存为 PPTX 时，图表动画是否会被保留？**

会。使用[保存为 PPTX](/slides/zh/python-java/save-presentation/) 时，所有动画效果及其顺序都会被保留，因为它们是演示文稿本机动画模型的一部分。

**我能读取演示文稿中已有的图表动画并对其进行修改吗？**

可以。API 提供对幻灯片时间轴、序列和效果的访问，允许您检查现有的图表动画并在不重新创建的情况下进行调整。

**可以使用 Aspose.Slides 生成包含图表动画的视频吗？**

可以。您可以[将演示文稿导出为视频](/slides/zh/python-java/convert-powerpoint-to-video/)，在导出时保留动画，配置时间和其他导出设置，使生成的影片能够完整展示动画播放效果。