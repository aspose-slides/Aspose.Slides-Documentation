---
title: 动画图表
type: docs
weight: 80
url: /zh/net/animated-charts/
keywords: "图表, 图表系列, 动画 PowerPoint 演示文稿, PPTX, PPT, C#, Csharp, Aspose.Slides for .NET"
description: "PowerPoint 图表系列和动画，使用 C# 或 .NET"
---

Aspose.Slides for .NET 支持对图表元素进行动画。 **Series**、**Categories**、**Series Elements**、**Categories Elements** 可以使用[**ISequence**.**AddEffect** ](https://reference.aspose.com/slides/net/aspose.slides.animation/isequence/methods/addeffect)方法以及两个枚举[**EffectChartMajorGroupingType** ](https://reference.aspose.com/slides/net/aspose.slides.animation/effectchartmajorgroupingtype)和[**EffectChartMinorGroupingType**](https://reference.aspose.com/slides/net/aspose.slides.animation/effectchartminorgroupingtype)进行动画设置。

## **图表系列动画**
如果您想为图表系列添加动画，请按照下面列出的步骤编写代码：

1. 加载演示文稿。  
1. 获取图表对象的引用。  
1. 为系列添加动画。  
1. 将演示文稿写入磁盘。

在下面的示例中，我们为图表系列添加了动画。  
```c#
 // 实例化表示演示文稿文件的 Presentation 类 
 using (Presentation presentation = new Presentation("ExistingChart.pptx"))
 {
     // 获取图表对象的引用
     var slide = presentation.Slides[0] as Slide;
     var shapes = slide.Shapes as ShapeCollection;
     var chart = shapes[0] as IChart;

     // 为系列添加动画
     slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None,
     EffectTriggerType.AfterPrevious);

     ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
     EffectChartMajorGroupingType.BySeries, 0,
     EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

     ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
     EffectChartMajorGroupingType.BySeries, 1,
     EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

     ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
     EffectChartMajorGroupingType.BySeries, 2,
     EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

     ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
     EffectChartMajorGroupingType.BySeries, 3,
     EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

     // 将修改后的演示文稿写入磁盘 
     presentation.Save("AnimatingSeries_out.pptx", SaveFormat.Pptx);
 }
```


## **图表类别动画**
如果您想为图表类别添加动画，请按照下面列出的步骤编写代码：

1. 加载演示文稿。  
1. 获取图表对象的引用。  
1. 为类别添加动画。  
1. 将演示文稿写入磁盘。

在下面的示例中，我们为图表类别添加了动画。  
```c#
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // 获取图表对象的引用
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // 为类别元素添加动画
    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // 将演示文稿文件写入磁盘
    presentation.Save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
}
```


## **系列元素动画**
如果您想为系列元素添加动画，请按照下面列出的步骤编写代码：

1. 加载演示文稿。  
1. 获取图表对象的引用。  
1. 为系列元素添加动画。  
1. 将演示文稿写入磁盘。

在下面的示例中，我们已经为系列元素添加了动画。  
```c#
// 加载演示文稿
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // 获取图表对象的引用
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // 为系列元素添加动画
    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // 将演示文稿文件写入磁盘 
    presentation.Save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx);
}
```


## **类别元素动画**
如果您想为类别元素添加动画，请按照下面列出的步骤编写代码：

1. 加载演示文稿。  
1. 获取图表对象的引用。  
1. 为类别元素添加动画。  
1. 将演示文稿写入磁盘。

在下面的示例中，我们已经为类别元素添加了动画。  
```c#
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // 获取图表对象的引用
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // 为类别元素添加动画
    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // 将演示文稿文件写入磁盘
    presentation.Save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**是否支持与普通形状相同的不同效果类型（例如进入、强调、退出）用于图表？**

是的。图表被视为形状，因此支持标准的动画效果类型，包括进入、强调和退出，并可通过幻灯片时间线和动画序列进行完整控制。

**我可以将图表动画与幻灯片切换效果结合使用吗？**

是的。[Transitions](/slides/zh/net/slide-transition/) 作用于幻灯片本身，而动画效果作用于幻灯片上的对象。您可以在同一演示文稿中同时使用两者，并独立控制它们。

**将演示文稿保存为 PPTX 时，图表动画会被保留吗？**

是的。当您[save to PPTX](/slides/zh/net/save-presentation/) 时，所有动画效果及其顺序都会被保留，因为它们是演示文稿原生动画模型的一部分。

**我可以读取演示文稿中已有的图表动画并进行修改吗？**

是的。该[API](https://reference.aspose.com/slides/net/aspose.slides.animation/) 提供对幻灯片时间线、序列和效果的访问，您可以检查现有的图表动画并在不重新创建的情况下对其进行调整。

**我能使用 Aspose.Slides 生成包含图表动画的视频吗？**

是的。您可以[export a presentation to video](/slides/zh/net/convert-powerpoint-to-video/) 并保留动画，配置时间和其他导出设置，使生成的影片能够完整呈现动画播放效果。