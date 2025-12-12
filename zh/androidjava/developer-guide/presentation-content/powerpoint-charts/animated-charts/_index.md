---
title: 在 Android 上为 PowerPoint 图表添加动画
linktitle: 动态图表
type: docs
weight: 80
url: /zh/androidjava/animated-charts/
keywords:
- 图表
- 动态图表
- 图表动画
- 图表序列
- 图表类别
- 序列元素
- 类别元素
- 添加效果
- 效果类型
- PowerPoint
- 演示文稿
- Android
- Java
- Aspose.Slides
description: 使用 Aspose.Slides for Android 在 Java 中创建惊艳的动态图表。通过 PPT 和 PPTX 文件中的动态视觉效果提升演示文稿——立即开始。
---

{{% alert color="primary" %}} 

Aspose.Slides for Android via Java 支持为图表元素添加动画。**Series**、**Categories**、**Series Elements**、**Categories Elements** 可以通过 [**ISequence**.**addEffect**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISequence#addEffect-com.aspose.slides.IChart-int-int-int-int-int-) 方法以及两个枚举 [**EffectChartMajorGroupingType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EffectChartMajorGroupingType) 和 [**EffectChartMinorGroupingType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EffectChartMinorGroupingType) 进行动画化。

{{% /alert %}} 

## **图表序列动画**
如果您想为图表序列添加动画，请按照以下步骤编写代码：

1. 加载演示文稿。
1. 获取图表对象的引用。
1. 为序列添加动画。
1. 将演示文稿文件写入磁盘。

下面的示例演示了图表序列的动画。
```java
// 实例化表示演示文稿文件的 Presentation 类
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // 获取图表对象的引用
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // 为序列添加动画
    slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None,
            EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.BySeries, 0,
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.BySeries, 1,
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.BySeries, 2,
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.BySeries, 3,
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // 将修改后的演示文稿写入磁盘
    pres.save("AnimatingSeries_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **图表类别动画**
如果您想为图表类别添加动画，请按照以下步骤编写代码：

1. 加载演示文稿。
1. 获取图表对象的引用。
1. 为类别添加动画。
1. 将演示文稿文件写入磁盘。

下面的示例演示了图表类别的动画。
```java
// 实例化表示演示文稿文件的 Presentation 类
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None,
            EffectTriggerType.AfterPrevious);

    ((Sequence) slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.ByCategory, 0, 
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    
    ((Sequence) slide.getTimeline().getMainSequence()).addEffect(chart, 
            EffectChartMajorGroupingType.ByCategory, 1, 
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    
    ((Sequence) slide.getTimeline().getMainSequence()).addEffect(chart, 
            EffectChartMajorGroupingType.ByCategory, 2, 
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    
    ((Sequence) slide.getTimeline().getMainSequence()).addEffect(chart, 
            EffectChartMajorGroupingType.ByCategory, 3, 
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    pres.save("Sample_Animation_C.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **序列元素动画**
如果您想为序列元素添加动画，请按照以下步骤编写代码：

1. 加载演示文稿。
1. 获取图表对象的引用。
1. 为序列元素添加动画。
1. 将演示文稿文件写入磁盘。

下面的示例演示了序列元素的动画。
```java
// 实例化表示演示文稿文件的 Presentation 类
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // 获取图表对象的引用
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // 为序列元素添加动画
    slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // 将演示文稿文件写入磁盘
    pres.save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **类别元素动画**
如果您想为类别元素添加动画，请按照以下步骤编写代码：

1. 加载演示文稿。
1. 获取图表对象的引用。
1. 为类别元素添加动画。
1. 将演示文稿文件写入磁盘。

下面的示例演示了类别元素的动画。
```java
// 实例化表示演示文稿文件的 Presentation 类
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // 获取图表对象的引用
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // 为类别元素添加动画
    slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // 将演示文稿文件写入磁盘
    pres.save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **常见问题**

**图表是否支持不同的效果类型（例如进入、强调、退出），类似于常规形状？**

是的。图表被视为形状，因此它支持标准的动画效果类型，包括进入、强调和退出，并且可以通过幻灯片的时间轴和动画序列进行完整控制。

**我可以将图表动画与幻灯片切换效果结合使用吗？**

是的。[Transitions](/slides/zh/androidjava/slide-transition/) 适用于幻灯片，而动画效果适用于幻灯片上的对象。您可以在同一个演示文稿中同时使用两者，并独立控制它们。

**将演示文稿保存为 PPTX 时，图表动画会被保留吗？**

是的。当您[save to PPTX](/slides/zh/androidjava/save-presentation/) 时，所有动画效果及其顺序都会被保留，因为它们是演示文稿原生动画模型的一部分。

**我可以从演示文稿中读取现有的图表动画并进行修改吗？**

是的。API 提供对幻灯片时间轴、序列和效果的访问，允许您检查现有的图表动画并在不重新创建全部内容的情况下进行调整。

**我可以使用 Aspose.Slides 生成包含图表动画的视频吗？**

是的。您可以[export a presentation to video](/slides/zh/androidjava/convert-powerpoint-to-video/) 时保留动画，配置时间和其他导出设置，使生成的 clip 反映动画播放效果。