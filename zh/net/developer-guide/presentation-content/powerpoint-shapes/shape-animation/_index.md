---
title: 在 .NET 中对演示文稿应用形状动画
linktitle: 形状动画
type: docs
weight: 60
url: /zh/net/shape-animation/
keywords:
- 形状
- 动画
- 效果
- 动画形状
- 动画文本
- 添加动画
- 获取动画
- 提取动画
- 添加效果
- 获取效果
- 提取效果
- 效果声音
- 应用动画
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 在 PowerPoint 演示文稿中创建和自定义形状动画。脱颖而出！"
---
## **介绍**

动画是可以应用于文本、图像、形状或[图表](/slides/zh/net/animated-charts/)的视觉效果。它们为演示文稿或其组成部分赋予活力。 

## **为什么在演示文稿中使用动画？**

使用动画，您可以 

* 控制信息流
* 强调重要点
* 提高观众的兴趣或参与度
* 使内容更易于阅读、吸收或处理
* 将读者或观众的注意力引导至演示文稿中的重要部分

PowerPoint 在 **进入**、**退出**、**强调** 和 **运动路径** 类别中提供了许多动画选项和工具。 

## **Aspose.Slides 中的动画**

* Aspose.Slides 在 [Aspose.Slides.Animation](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/) 命名空间下提供了进行动画操作所需的类和类型，  
* Aspose.Slides 在 [EffectType](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/effecttype) 枚举下提供了超过 **150** 个动画效果。这些效果本质上与 PowerPoint 使用的效果相同（或等价）。 

## **将动画应用于文本框**

Aspose.Slides for .NET 允许您对形状中的文本应用动画。 

1. 创建一个 [Presentation](http://www.aspose.com/api/net/slides/zh/aspose.slides/) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 添加一个 `rectangle` [IAutoShape](https://reference.aspose.com/slides/zh/net/aspose.slides/iautoshape)。  
4. 向 [IAutoShape.TextFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/iautoshape/properties/textframe) 添加文本。  
5. 获取主要的效果序列。  
6. 向 [IAutoShape](https://reference.aspose.com/slides/zh/net/aspose.slides/iautoshape) 添加动画效果。  
7. 将 [TextAnimation.BuildType](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/textanimation/properties/buildtype) 属性设置为来自 [BuildType Enumeration](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/buildtype) 的值。  
8. 将演示文稿写入磁盘，保存为 PPTX 文件。  

下面的 C# 代码演示了如何将 `Fade` 效果应用于 AutoShape 并将文本动画设置为 *By 1st Level Paragraphs* 值：

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// 实例化一个表示演示文稿文件的 Presentation 类。
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // 添加带文本的新 AutoShape
    IAutoShape autoShape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    // 添加三个段落，以便逐段构建有内容可遍历。
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "First paragraph";
    textFrame.Paragraphs.Add(new Paragraph { Text = "Second paragraph" });
    textFrame.Paragraphs.Add(new Paragraph { Text = "Third paragraph" });

    // 获取幻灯片的主序列。
    ISequence sequence = sld.Timeline.MainSequence;

    // 为形状添加 Fade 动画效果
    IEffect effect = sequence.AddEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // 按一级段落对形状文本进行动画
    effect.TextAnimation.BuildType = BuildType.ByLevelParagraphs1;

    // 将 PPTX 文件保存到磁盘
    pres.Save("AnimTextBox_out.pptx", SaveFormat.Pptx);
}
```

{{%  alert color="info"  %}} 

除了对文本应用动画之外，还可以对单个[段落](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraph)应用动画。请参阅[**动画文本**](/slides/zh/net/animated-text/)。

{{% /alert %}} 

## **将动画应用于图片框**

1. 创建 [Presentation](http://www.aspose.com/api/net/slides/zh/aspose.slides/) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 在幻灯片上添加或获取一个 [PictureFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/ipictureframe)。  
5. 获取主要的效果序列。  
6. 向 [PictureFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/ipictureframe) 添加动画效果。  
8. 将演示文稿写入磁盘，保存为 PPTX 文件。  

下面的 C# 代码演示了如何将 `Fly` 效果应用于图片框：

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// 实例化一个表示演示文稿文件的 Presentation 类。
using (Presentation pres = new Presentation())
{
    // 加载要添加到演示文稿图像集合中的图片
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // 向幻灯片添加图片框
    IPictureFrame picFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // 获取幻灯片的主序列。
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // 为图片框添加从左侧飞入的动画效果
    IEffect effect = sequence.AddEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // 将 PPTX 文件保存到磁盘
    pres.Save("AnimImage_out.pptx", SaveFormat.Pptx);
}
```

## **将动画应用于形状**

1. 创建 [Presentation](http://www.aspose.com/api/net/slides/zh/aspose.slides/) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 添加一个 `rectangle` [IAutoShape](https://reference.aspose.com/slides/zh/net/aspose.slides/iautoshape)。  
4. 添加一个 `Bevel` [IAutoShape](https://reference.aspose.com/slides/zh/net/aspose.slides/iautoshape)（当点击此对象时，动画将播放）。  
5. 在斜面形状上创建效果序列。  
6. 创建自定义 `UserPath`。  
7. 添加移动到 `UserPath` 的命令。  
8. 将演示文稿写入磁盘，保存为 PPTX 文件。  

下面的 C# 代码演示了如何将 `PathFootball`（path football）效果应用于形状：

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// 实例化一个表示演示文稿文件的 Presentation 类。
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // 为现有形状从头创建 PathFootball 效果。
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);

    ashp.AddTextFrame("Animated TextBox");

    // 添加 PathFootBall 动画效果。
    pres.Slides[0].Timeline.MainSequence.AddEffect(ashp, EffectType.PathFootball,
                           EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // 创建某种“按钮”。
    IShape shapeTrigger = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // 为按钮创建一系列效果。
    ISequence seqInter = pres.Slides[0].Timeline.InteractiveSequences.Add(shapeTrigger);

    // 创建自定义用户路径。我们的对象将在按钮点击后才会移动。
    IEffect fxUserPath = seqInter.AddEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

    // 添加移动命令，因为创建的路径为空。
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.Behaviors[0]);

    PointF[] pts = new PointF[1];
    pts[0] = new PointF(0.076f, 0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new PointF(-0.076f, -0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.Path.Add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

    // 将 PPTX 文件写入磁盘
    pres.Save("AnimExample_out.pptx", SaveFormat.Pptx);
}
```

## **获取应用于形状的动画效果**

以下示例演示了如何使用 [ISequence](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/isequence/) 接口中的 `GetEffectsByShape` 方法来获取应用于形状的所有动画效果。

**示例 1：获取普通幻灯片上形状的动画效果**

之前，您已经学习了如何在 PowerPoint 演示文稿中为形状添加动画效果。以下示例代码演示了如何获取演示文稿 `AnimExample_out.pptx` 中第一张普通幻灯片上第一个形状所应用的效果。

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation("AnimExample_out.pptx"))
{
    ISlide firstSlide = presentation.Slides[0];

    // 获取幻灯片的主动画序列。
    ISequence sequence = firstSlide.Timeline.MainSequence;

    // 获取第一张幻灯片上的第一个形状。
    IShape shape = firstSlide.Shapes[0];

    // 获取应用于该形状的动画效果。
    IEffect[] shapeEffects = sequence.GetEffectsByShape(shape);

    if (shapeEffects.Length > 0)
        Console.WriteLine($"The shape {shape.Name} has {shapeEffects.Length} animation effects.");
}
```

**示例 2：获取所有动画效果，包括从占位符继承的效果**

如果普通幻灯片上的形状具有位于版式幻灯片和/或母版幻灯片上的占位符，并且这些占位符已添加了动画效果，则在幻灯片放映期间，将播放该形状的所有效果，包括从占位符继承的效果。

假设我们有一个 PowerPoint 演示文稿文件 `sample.pptx`，其中仅有一张幻灯片，包含一个文本为 "Made with Aspose.Slides" 的页脚形状，并对该形状应用了 **Random Bars** 效果。

![幻灯片形状动画效果](slide-shape-animation.png)

再假设在 **layout** 幻灯片的页脚占位符上应用了 **Split** 效果。

![版式形状动画效果](layout-shape-animation.png)

最后，在 **master** 幻灯片的页脚占位符上应用了 **Fly In** 效果。

![母版形状动画效果](master-shape-animation.png)

以下示例代码演示了如何使用 [IShape](https://reference.aspose.com/slides/zh/net/aspose.slides/ishape/) 接口中的 `GetBasePlaceholder` 方法来访问形状占位符，并获取应用于页脚形状的动画效果，包括从版式和母版幻灯片上的占位符继承的效果。

```cs
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // 获取普通幻灯片上形状的动画效果。
    IShape shape = slide.Shapes[0];
    IEffect[] shapeEffects = slide.Timeline.MainSequence.GetEffectsByShape(shape);

    // 获取版式幻灯片上占位符的动画效果。
    IShape layoutShape = shape.GetBasePlaceholder();
    IEffect[] layoutShapeEffects = slide.LayoutSlide.Timeline.MainSequence.GetEffectsByShape(layoutShape);

    // 获取母版幻灯片上占位符的动画效果。
    IShape masterShape = layoutShape.GetBasePlaceholder();
    IEffect[] masterShapeEffects = slide.LayoutSlide.MasterSlide.Timeline.MainSequence.GetEffectsByShape(masterShape);

    Console.WriteLine("Main sequence of shape effects:");
    PrintEffects(masterShapeEffects);
    PrintEffects(layoutShapeEffects);
    PrintEffects(shapeEffects);
}

static void PrintEffects(IEnumerable<IEffect> effects)
{
    foreach (IEffect effect in effects)
    {
        Console.WriteLine($"{effect.Type} {effect.Subtype}");
    }
}
```
```cs
using Aspose.Slides.Animation;

static void PrintEffects(IEnumerable<IEffect> effects)
{
    foreach (IEffect effect in effects)
    {
        Console.WriteLine($"{effect.Type} {effect.Subtype}");
    }
}
```

Output:
```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```

## **更改动画效果时间属性**

Aspose.Slides for .NET 允许您更改动画效果的时间属性。

这是一张 Microsoft PowerPoint 中的动画时间窗格和扩展菜单：

![PowerPoint 中的动画时间窗格和扩展菜单](shape-animation.png)

以下是 PowerPoint 时间设置与 [Effect.Timing](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/effect/properties/timing) 属性之间的对应关系：

- PowerPoint 时间 **Start** 下拉列表对应 [Effect.Timing.TriggerType](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/itiming/properties/triggertype) 属性。  
- PowerPoint 时间 **Duration** 对应 [Effect.Timing.Duration](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/itiming/properties/duration) 属性。动画的持续时间（以秒为单位）是动画完成一次循环所需的总时间。  
- PowerPoint 时间 **Delay** 对应 [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/itiming/properties/triggerdelaytime) 属性。  
- PowerPoint 时间 **Repeat** 下拉列表对应以下属性：  
  * [Effect.Timing.RepeatCount](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/itiming/repeatcount) 属性，用于描述效果重复的*次数*；  
  * [Effect.Timing.RepeatUntilEndSlide](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/itiming/repeatuntilendslide) 标志，指定效果是否重复至幻灯片结束；  
  * [Effect.Timing.RepeatUntilNextClick](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/itiming/repeatuntilnextclick) 标志，指定效果是否重复至下一次点击。  
- PowerPoint 时间 **Rewind when done playing** 复选框对应 [Effect.Timing.Rewind](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/itiming/rewind/) 属性。  

以下是更改 Effect Timing 属性的方法：

1. [Apply](#apply-animation-to-shape) 或获取动画效果。  
2. 为所需的 [Effect.Timing](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/effect/properties/timing) 属性设置新值。  
3. 保存修改后的 PPTX 文件。  

下面的 C# 代码演示了该操作：

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// 实例化一个表示演示文稿文件的 Presentation 类。
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
    // 获取幻灯片的主序列。
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // 获取主序列的第一个效果。
    IEffect effect = sequence[0];

    // 将效果的 TriggerType 更改为点击开始
    effect.Timing.TriggerType = EffectTriggerType.OnClick;

    // 更改效果持续时间
    effect.Timing.Duration = 3f;

    // 更改效果的 TriggerDelayTime
    effect.Timing.TriggerDelayTime = 0.5f;

    // 如果效果的 Repeat 值为 “none”
    if (effect.Timing.RepeatCount == 1f)
    {
        // 将效果的 Repeat 更改为 “直到下一次点击”
        effect.Timing.RepeatUntilNextClick = true;
    }
    else
    {
        // 将效果的 Repeat 更改为 “直到幻灯片结束”
        effect.Timing.RepeatUntilEndSlide = true;
    }

    // 打开效果的 Rewind
        effect.Timing.Rewind = true;
    
    // 将 PPTX 文件保存到磁盘
    pres.Save("AnimExample_changed.pptx", SaveFormat.Pptx);
}
```

## **动画效果声音**

Aspose.Slides 提供以下属性，以便在动画效果中使用声音： 
- [IEffect.Sound](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/effect/sound/) 
- [IEffect.StopPreviousSound](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/effect/stopprevioussound/) 

### **添加动画效果声音**

下面的 C# 代码演示了如何添加动画效果声音并在下一个效果开始时停止它：

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
	// 向演示文稿的音频集合中添加音频
	IAudio effectSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// 获取幻灯片的主序列。
	ISequence sequence = firstSlide.Timeline.MainSequence;

	// 获取主序列的第一个效果
	IEffect firstEffect = sequence[0];

	// 检查效果是否没有声音
	if (!firstEffect.StopPreviousSound && firstEffect.Sound == null)
	{
		// 为第一个效果添加声音
		firstEffect.Sound = effectSound;
	}

	// 获取幻灯片的第一个交互序列。
		ISequence interactiveSequence = firstSlide.Timeline.InteractiveSequences[0];

	// 设置效果的“停止先前声音”标志
	interactiveSequence[0].StopPreviousSound = true;

	// 将 PPTX 文件写入磁盘
	pres.Save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
}
```

### **提取动画效果声音**

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/) 类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 获取主要的效果序列。  
4. 提取嵌入到每个动画效果中的 [Sound](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/effect/sound/) 。  

下面的 C# 代码演示了如何提取嵌入在动画效果中的声音：

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;

// 实例化一个表示演示文稿文件的 Presentation 类。
using (Presentation presentation = new Presentation("EffectSound.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // 获取幻灯片的主序列。
    ISequence sequence = slide.Timeline.MainSequence;

    foreach (IEffect effect in sequence)
    {
        if (effect.Sound == null)
            continue;

        // 提取效果声音为字节数组
        byte[] audio = effect.Sound.BinaryData;
    }
}
```

## **动画结束后**

Aspose.Slides for .NET 允许您更改动画效果的 After animation 属性。

![动画结束后窗格](shape-after-animation.png)

PowerPoint 效果 **After animation** 下拉列表对应以下属性：

- [IEffect.AfterAnimationType](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/ieffect/afteranimationtype/) 属性，用于描述 After animation 类型：  
  * PowerPoint **More Colors** 对应 [AfterAnimationType.Color](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/afteranimationtype/) 类型；  
  * PowerPoint **Don't Dim** 项对应 [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/afteranimationtype/) 类型（默认的 after animation 类型）；  
  * PowerPoint **Hide After Animation** 项对应 [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/afteranimationtype/) 类型；  
  * PowerPoint **Hide on Next Mouse Click** 项对应 [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/afteranimationtype/) 类型；  
- [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/ieffect/afteranimationcolor/) 属性，用于定义 after animation 的颜色格式。该属性与 [AfterAnimationType.Color](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/afteranimationtype/) 类型配合使用。如果将类型更改为其他类型，after animation 颜色将被清除。  

下面的 C# 代码演示了如何更改 after animation 效果：

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// 实例化一个表示演示文稿文件的 Presentation 类
using (Presentation pres = new Presentation("AnimImage_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // 获取主序列的第一个效果
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // 将 after animation 类型更改为颜色
    firstEffect.AfterAnimationType = AfterAnimationType.Color;

    // 设置 after animation 的暗淡颜色
    firstEffect.AfterAnimationColor.Color = Color.AliceBlue;

    // 将 PPTX 文件写入磁盘
    pres.Save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
}
```

## **动画文本**

Aspose.Slides 提供以下属性，以便使用动画效果的 *Animate text* 块：

- [IEffect.AnimateTextType](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/ieffect/animatetexttype/) 用于描述效果的 animate text 类型。形状文本可以如下方式动画化：  
  - 一次性全部 ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/animatetexttype/) 类型)  
  - 按词 ([AnimateTextType.ByWord](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/animatetexttype/) 类型)  
  - 按字母 ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/animatetexttype/) 类型)  
- [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/ieffect/delaybetweentextparts/) 设置动画文本部分（词或字母）之间的延迟。正值表示效果持续时间的百分比，负值表示秒数。  

以下是更改 Effect Animate text 属性的方法：

1. [Apply](#apply-animation-to-shape) 或获取动画效果。  
2. 将 [IEffect.TextAnimation.BuildType](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/itextanimation/buildtype/) 属性设置为 [BuildType.AsOneObject](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/buildtype/) 值，以关闭 *By Paragraphs* 动画模式。  
3. 为 [IEffect.AnimateTextType](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/ieffect/animatetexttype/) 和 [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/zh/net/aspose.slides.animation/ieffect/delaybetweentextparts/) 属性设置新值。  
4. 保存修改后的 PPTX 文件。  

下面的 C# 代码演示了该操作：

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// 实例化一个表示演示文稿文件的 Presentation 类。
using (Presentation pres = new Presentation("AnimTextBox_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // 获取主序列的第一个效果
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // 将效果的文本动画类型更改为 “As One Object”
    firstEffect.TextAnimation.BuildType = BuildType.AsOneObject;

    // 将效果的动画文本类型更改为 “By word”
    firstEffect.AnimateTextType = AnimateTextType.ByWord;

    // 将单词之间的延迟设置为效果持续时间的 20%
    firstEffect.DelayBetweenTextParts = 20f;

    // 将 PPTX 文件写入磁盘
    pres.Save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
}
```

## **常见问题**

### 如何确保在将演示文稿发布到网页时动画得以保留？

[Export to HTML5](/slides/zh/net/export-to-html5/) 并启用负责 [shape](https://reference.aspose.com/slides/zh/net/aspose.slides.export/html5options/animateshapes/) 和 [transition](https://reference.aspose.com/slides/zh/net/aspose.slides.export/html5options/animatetransitions/) 动画的 [options](https://reference.aspose.com/slides/zh/net/aspose.slides.export/html5options/) 。纯 HTML 不会播放幻灯片动画，而 HTML5 会。

### 更改形状的 Z 顺序（层次顺序）如何影响动画？

动画顺序和绘制顺序是独立的：效果控制出现/消失的时间和类型，而 [z-order](https://reference.aspose.com/slides/zh/net/aspose.slides/shape/zorderposition/) 决定覆盖关系。可见结果由两者的组合决定。（这是 PowerPoint 的通用行为，Aspose.Slides 的效果与形状模型遵循相同逻辑。）

### 将动画转换为视频时，某些效果是否存在限制？

通常情况下，[动画受支持](/slides/zh/net/convert-powerpoint-to-video/)，但在少数情况下或特定效果可能呈现不同。建议使用您所使用的效果以及相应的库版本进行测试。