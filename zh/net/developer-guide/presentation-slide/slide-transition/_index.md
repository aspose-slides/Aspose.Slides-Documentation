---
title: 幻灯片切换
type: docs
weight: 90
url: /zh/net/slide-transition/
keywords: "添加幻灯片切换, PowerPoint 幻灯片切换, 形变切换, 高级幻灯片切换, 切换效果, C#, Csharp, .NET, Aspose.Slides"
description: "在 C# 或 .NET 中添加 PowerPoint 幻灯片切换和切换效果"
---

## **添加幻灯片切换**
为了更容易理解，我们演示了使用 Aspose.Slides for .NET 管理简单幻灯片切换的用法。开发人员不仅可以在幻灯片上应用不同的切换效果，还可以自定义这些切换效果的行为。要创建一个简单的幻灯片切换效果，请按照以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
2. 通过 TransitionType 枚举，从 Aspose.Slides for .NET 提供的过渡效果中为幻灯片应用 Slide Transition Type。
3. 将修改后的演示文稿写入文件。
```c#
// 实例化 Presentation 类以加载源演示文稿文件
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    // 在第 1 张幻灯片上应用圆形过渡效果
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Circle;

    // 在第 2 张幻灯片上应用梳形过渡效果
    presentation.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    // 将演示文稿写入磁盘
    presentation.Save("SampleTransition_out.pptx", SaveFormat.Pptx);
}
```


## **添加高级幻灯片切换**
在上述章节中，我们仅在幻灯片上应用了简单的切换效果。现在，为了让该简单切换效果更好且可控，请按照以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
2. 从 Aspose.Slides for .NET 提供的过渡效果中为幻灯片应用 Slide Transition Type。
3. 您还可以将切换设置为单击后前进、在特定时间段后前进，或同时设置两者。
4. 如果幻灯片切换启用了“单击后前进”，则仅在有人点击鼠标时才会前进。此外，如果设置了“Advance After Time”属性，切换将在指定的时间过去后自动前进。
5. 将修改后的演示文稿写入为演示文稿文件。
```c#
// 实例化表示演示文稿文件的 Presentation 类
using (Presentation pres = new Presentation("BetterSlideTransitions.pptx"))
{

    // 在第 1 张幻灯片上应用圆形过渡效果
    pres.Slides[0].SlideShowTransition.Type = TransitionType.Circle;


    // 设置 3 秒的切换时间
    pres.Slides[0].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[0].SlideShowTransition.AdvanceAfterTime = 3000;

    // 在第 2 张幻灯片上应用梳形过渡效果
    pres.Slides[1].SlideShowTransition.Type = TransitionType.Comb;


    // 设置 5 秒的切换时间
    pres.Slides[1].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[1].SlideShowTransition.AdvanceAfterTime = 5000;

    // 在第 3 张幻灯片上应用缩放过渡效果
    pres.Slides[2].SlideShowTransition.Type = TransitionType.Zoom;


    // 设置 7 秒的切换时间
    pres.Slides[2].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[2].SlideShowTransition.AdvanceAfterTime = 7000;

    // 将演示文稿写入磁盘
    pres.Save("SampleTransition_out.pptx", SaveFormat.Pptx);
}
```


此外，使用 [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/) 属性，您可以检查幻灯片切换是否已配置为移动到下一张幻灯片或已禁用该设置。

This C# code demonstrates the operation:
```c#
// 实例化表示演示文稿文件的 Presentation 类
using (Presentation pres = new Presentation("SampleTransition_out.pptx"))
{
    foreach (ISlide slide in pres.Slides)
    {
        // 获取幻灯片的过渡
        ISlideShowTransition slideTransition = slide.SlideShowTransition;

        // 检查是否启用了 Advance After Time 设置
        if (slideTransition.AdvanceAfter)
        {
            // 打印 Advance After Time 值
            Console.WriteLine("The slide #" + slide.SlideNumber + " AdvancedAfterTime: " + slideTransition.AdvanceAfterTime);
        }

        // 如果 AdvancedAfterTime 值大于 2 秒，则在特定时间后禁用过渡
        if (slideTransition.AdvanceAfterTime > 2000)
        {
            slideTransition.AdvanceAfter = false;
        }
    }
}
```


## **Morph 切换**
Aspose.Slides for .NET 现在支持 [Morph Transition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition)。它们是 PowerPoint 2019 引入的新 Morph 切换。Morph 切换允许您对从一张幻灯片到下一张幻灯片的平滑移动进行动画处理。本文描述了该概念及其使用方法。要有效使用 Morph 切换，您需要有两张至少包含一个相同对象的幻灯片。最简单的方法是复制幻灯片，然后将第二张幻灯片上的对象移动到其他位置。

以下代码片段展示了如何向演示文稿中添加带有文本的幻灯片克隆，并将 [morph type](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition/properties/morphtype) 设置为第二张幻灯片的切换。
```c#
using (Presentation presentation = new Presentation())
{
    AutoShape autoshape = (AutoShape)presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.TextFrame.Text = "Morph Transition in PowerPoint Presentations";

    presentation.Slides.AddClone(presentation.Slides[0]);

    presentation.Slides[1].Shapes[0].X += 100;
    presentation.Slides[1].Shapes[0].Y += 50;
    presentation.Slides[1].Shapes[0].Width -= 200;
    presentation.Slides[1].Shapes[0].Height -= 10;

    presentation.Slides[1].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Morph;

    presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```


## **Morph 切换类型**
新增了 [Aspose.Slides.SlideShow.TransitionMorphType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype) 枚举。它表示不同类型的 Morph 幻灯片切换。

TransitionMorphType 枚举有三个成员：

- ByObject：Morph 切换将在形状视为不可分割对象的前提下执行。
- ByWord：Morph 切换将在可能的情况下按单词转移动文本。
- ByChar：Morph 切换将在可能的情况下按字符转移动文本。

以下代码片段展示了如何为幻灯片设置 Morph 切换并更改 Morph 类型：
```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Morph;
    ((IMorphTransition)presentation.Slides[0].SlideShowTransition.Value).MorphType = TransitionMorphType.ByWord;
    presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```


## **设置切换效果**
Aspose.Slides for .NET 支持设置切换效果，例如从黑色、从左侧、从右侧等。要设置切换效果，请按照以下步骤操作：

- 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例。
- 获取幻灯片的引用。
- 设置切换效果。
- 将演示文稿写入为 [PPTX](https://docs.fileformat.com/presentation/pptx/) 文件。

在下面给出的示例中，我们已设置了切换效果。
```c#
// 创建 Presentation 类的实例
Presentation presentation = new Presentation("AccessSlides.pptx");

// 设置效果
presentation.Slides[0].SlideShowTransition.Type = TransitionType.Cut;
((OptionalBlackTransition)presentation.Slides[0].SlideShowTransition.Value).FromBlack = true;

// 将演示文稿写入磁盘
presentation.Save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
```


## **FAQ**

**我可以控制幻灯片切换的播放速度吗？**

是的。使用 [TransitionSpeed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionspeed/) 设置来设置切换的 [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/)，例如慢/中/快。

**我可以为切换附加音频并使其循环吗？**

是的。您可以为切换嵌入声音，并通过诸如声音模式和循环等设置来控制行为（例如 [Sound](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/sound/)、[SoundMode](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/soundmode/)、[SoundLoop](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/soundloop/)，以及诸如 [SoundIsBuiltIn](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/soundisbuiltin/) 和 [SoundName](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/soundname/) 之类的元数据）。

**将相同切换应用于每张幻灯片的最快方法是什么？**

在每张幻灯片的切换设置中配置所需的切换类型；切换是按幻灯片存储的，因此在所有幻灯片上应用相同的类型即可获得一致的效果。

**如何检查幻灯片上当前设置的切换类型？**

检查幻灯片的 [transition settings](https://reference.aspose.com/slides/net/aspose.slides/baseslide/slideshowtransition/) 并读取其 [transition type](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/type/)，该值会精确告诉您应用了哪种效果。