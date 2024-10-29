---
title: 幻灯片过渡
type: docs
weight: 90
url: /zh/net/slide-transition/
keywords: "添加幻灯片过渡，PowerPoint 幻灯片过渡，形态过渡，高级幻灯片过渡，过渡效果，C#，Csharp，.NET，Aspose.Slides"
description: "在 C# 或 .NET 中添加 PowerPoint 幻灯片过渡和过渡效果"
---

## **添加幻灯片过渡**
为便于理解，我们演示了使用 Aspose.Slides for .NET 管理简单幻灯片过渡。开发人员不仅可以在幻灯片上应用不同的幻灯片过渡效果，还可以自定义这些过渡效果的行为。要创建简单的幻灯片过渡效果，请遵循以下步骤：

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 使用 TransitionType 枚举从 Aspose.Slides for .NET 提供的过渡效果中应用一种幻灯片过渡类型。
1. 编写修改后的演示文稿文件。

```c#
// 实例化 Presentation 类以加载源演示文稿文件
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    // 在幻灯片 1 上应用圆形类型过渡
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Circle;

    // 在幻灯片 2 上应用组合类型过渡
    presentation.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    // 将演示文稿写入磁盘
    presentation.Save("SampleTransition_out.pptx", SaveFormat.Pptx);
}
```


## **添加高级幻灯片过渡**
在上面的部分中，我们仅在幻灯片上应用了简单的过渡效果。现在，为了使这个简单的过渡效果更好并可控，请遵循以下步骤：

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
1. 使用 Aspose.Slides for .NET 提供的过渡效果中的一种应用幻灯片过渡类型。
1. 您还可以将过渡设置为“单击后高级”、“经过特定时间”或“二者兼具”。
1. 如果幻灯片过渡启用为单击后高级，则过渡仅在有人单击鼠标时才会继续。此外，如果设置了“经过时间后高级”属性，则在指定的高级时间经过后，过渡将自动继续。
1. 将修改后的演示文稿作为演示文稿文件编写。

```c#
// 实例化表示演示文稿文件的 Presentation 类
using (Presentation pres = new Presentation("BetterSlideTransitions.pptx"))
{

    // 在幻灯片 1 上应用圆形类型过渡
    pres.Slides[0].SlideShowTransition.Type = TransitionType.Circle;


    // 设置3秒的过渡时间
    pres.Slides[0].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[0].SlideShowTransition.AdvanceAfterTime = 3000;

    // 在幻灯片 2 上应用组合类型过渡
    pres.Slides[1].SlideShowTransition.Type = TransitionType.Comb;


    // 设置5秒的过渡时间
    pres.Slides[1].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[1].SlideShowTransition.AdvanceAfterTime = 5000;

    // 在幻灯片 3 上应用缩放类型过渡
    pres.Slides[2].SlideShowTransition.Type = TransitionType.Zoom;


    // 设置7秒的过渡时间
    pres.Slides[2].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[2].SlideShowTransition.AdvanceAfterTime = 7000;

    // 将演示文稿写入磁盘
    pres.Save("SampleTransition_out.pptx", SaveFormat.Pptx);
}
```

此外，通过使用 [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/) 属性，您可以检查幻灯片过渡是否已配置为移动到下一张幻灯片或禁用该设置。

以下 C# 代码演示了操作：

```c#
// 实例化表示演示文稿文件的 Presentation 类
using (Presentation pres = new Presentation("SampleTransition_out.pptx"))
{
    foreach (ISlide slide in pres.Slides)
    {
        // 获取幻灯片过渡
        ISlideShowTransition slideTransition = slide.SlideShowTransition;

        // 检查“经过时间后高级”设置是否启用
        if (slideTransition.AdvanceAfter)
        {
            // 打印经过时间后的值
            Console.WriteLine("幻灯片 #" + slide.SlideNumber + " AdvancedAfterTime: " + slideTransition.AdvanceAfterTime);
        }

        // 如果经过时间后值大于 2 秒，则在特定时间后禁用过渡
        if (slideTransition.AdvanceAfterTime > 2000)
        {
            slideTransition.AdvanceAfter = false;
        }
    }
}
``` 

## **形态过渡**
Aspose.Slides for .NET 现在支持 [Morph Transition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition)。它们代表在 PowerPoint 2019 中引入的新形态过渡。形态过渡允许您在幻灯片之间动画平滑移动。本文描述了这一概念以及如何使用形态过渡。要有效使用形态过渡，您需要有两个幻灯片，至少有一个共同的对象。最简单的方法是复制幻灯片，然后将第二张幻灯片上的对象移动到不同的位置。

以下代码片段向您展示了如何将带有一些文本的幻灯片克隆添加到演示文稿并将过渡设置为 [morph type](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition/properties/morphtype) 到第二张幻灯片。

```c#
using (Presentation presentation = new Presentation())
{
    AutoShape autoshape = (AutoShape)presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.TextFrame.Text = "PowerPoint 演示文稿中的形态过渡";

    presentation.Slides.AddClone(presentation.Slides[0]);

    presentation.Slides[1].Shapes[0].X += 100;
    presentation.Slides[1].Shapes[0].Y += 50;
    presentation.Slides[1].Shapes[0].Width -= 200;
    presentation.Slides[1].Shapes[0].Height -= 10;

    presentation.Slides[1].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Morph;

    presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```

## **形态过渡类型**
新添加了 [Aspose.Slides.SlideShow.TransitionMorphType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype) 枚举。它表示不同类型的形态幻灯片过渡。

TransitionMorphType 枚举有三个成员：

- ByObject: 形态过渡将考虑形状作为不可分割的对象。
- ByWord: 形态过渡将尽可能按单词转移文本。
- ByChar: 形态过渡将尽可能按字符转移文本。

以下代码片段向您展示了如何设置形态过渡到幻灯片并更改形态类型：

```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Morph;
    ((IMorphTransition)presentation.Slides[0].SlideShowTransition.Value).MorphType = TransitionMorphType.ByWord;
    presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```

## **设置过渡效果**
Aspose.Slides for .NET 支持设置过渡效果，例如，从黑色、从左边、从右边等。为了设置过渡效果。请遵循以下步骤：

- 创建 [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)类的实例。
- 获取幻灯片的引用。
- 设置过渡效果。
- 将演示文稿写入 [PPTX ](https://docs.fileformat.com/presentation/pptx/)文件。

在下面给出的示例中，我们设置了过渡效果。

```c#
// 创建 Presentation 类的实例
Presentation presentation = new Presentation("AccessSlides.pptx");

// 设置效果
presentation.Slides[0].SlideShowTransition.Type = TransitionType.Cut;
((OptionalBlackTransition)presentation.Slides[0].SlideShowTransition.Value).FromBlack = true;

// 将演示文稿写入磁盘
presentation.Save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
```