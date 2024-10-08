---
title: 形状动画
type: docs
weight: 60
url: /net/shape-animation/
keywords: 
- PowerPoint 动画
- 动画效果
- 应用动画
- PowerPoint 演示文稿
- C#
- Csharp
- Aspose.Slides for .NET
description: "在 C# 或 .NET 中应用 PowerPoint 动画"
---

动画是可以应用于文本、图像、形状或 [图表](/slides/net/animated-charts/) 的视觉效果。它们为演示文稿或其组成部分赋予生命。

### **为什么在演示文稿中使用动画？**

使用动画，您可以 

* 控制信息的流动
* 强调重要点
* 提高观众的兴趣或参与度
* 使内容更易于阅读、理解或处理
* 吸引读者或观众的注意力关注演示文稿中的重要部分

PowerPoint 提供了许多动画和动画效果的选项和工具，包括 **出现**、**消失**、**强调** 和 **运动路径** 类别。

### **Aspose.Slides 中的动画**

* Aspose.Slides 提供了您需要在 [Aspose.Slides.Animation](https://reference.aspose.com/slides/net/aspose.slides.animation/) 命名空间下处理动画的类和类型，
* Aspose.Slides 提供了 **150 多种动画效果**，这些效果在 [EffectType](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttype) 枚举下。这些效果在功能上与 PowerPoint 中使用的效果基本相同（或等效）。

## **将动画应用于文本框**

Aspose.Slides for .NET 允许您将动画应用于形状中的文本。 

1. 创建 [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 添加一个 `rectangle` [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape)。 
4. 向 [IAutoShape.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/properties/textframe) 添加文本。
5. 获取主要的效果序列。
6. 将动画效果添加到 [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape)。
7. 将 [TextAnimation.BuildType](https://reference.aspose.com/slides/net/aspose.slides.animation/textanimation/properties/buildtype) 属性设置为 [BuildType 枚举](https://reference.aspose.com/slides/net/aspose.slides.animation/buildtype) 中的值。
8. 将演示文稿写入磁盘作为 PPTX 文件。

以下 C# 代码显示了如何将 `Fade` 效果应用于 AutoShape，并将文本动画设置为 *按第一层段落* 值：

```c#
// 实例化表示演示文稿文件的演示类。
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    
    // 添加带文本的新 AutoShape
    IAutoShape autoShape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "第一段 \n第二段 \n第三段";

    // 获取幻灯片的主要序列。
    ISequence sequence = sld.Timeline.MainSequence;

    // 将 Fade 动画效果添加到形状
    IEffect effect = sequence.AddEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // 以 1 级段落动画形状文本
    effect.TextAnimation.BuildType = BuildType.ByLevelParagraphs1;

    // 将 PPTX 文件保存到磁盘
    pres.Save(path + "AnimTextBox_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}} 

除了将动画应用于文本，您还可以将动画应用于单个 [段落](https://reference.aspose.com/slides/net/aspose.slides/iparagraph)。请参见 [**动画文本**](/slides/net/animated-text/)。

{{% /alert %}} 

## **将动画应用于图片框**

1. 创建 [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 在幻灯片上添加或获取 [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe)。 
5. 获取主要效果序列。
6. 将动画效果添加到 [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe)。
8. 将演示文稿写入磁盘作为 PPTX 文件。

以下 C# 代码显示了如何将 `Fly` 效果应用于图片框：

```c#
// 实例化表示演示文稿文件的演示类。
using (Presentation pres = new Presentation())
{
    // 加载要添加到演示文稿图像集合的图像
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // 向幻灯片添加图片框
    IPictureFrame picFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // 获取幻灯片的主要序列。
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // 向图片框添加从左侧飞入的动画效果
    IEffect effect = sequence.AddEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // 将 PPTX 文件保存到磁盘
    pres.Save("AnimImage_out.pptx", SaveFormat.Pptx);
}
```

## **将动画应用于形状**

1. 创建 [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 添加一个 `rectangle` [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape)。 
4. 添加一个 `Bevel` [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape)（当单击该对象时，动画将播放）。
5. 在斜角形状上创建效果序列。
6. 创建一个自定义 `UserPath`。
7. 添加移动到 `UserPath` 的命令。
8. 将演示文稿写入磁盘作为 PPTX 文件。

以下 C# 代码显示了如何将 `PathFootball`（路径足球）效果应用于形状：

```c#
// 实例化表示演示文稿文件的演示类。
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // 从头开始为现有形状创建 PathFootball 效果。
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);

    ashp.AddTextFrame("动画文本框");

    // 添加 PathFootBall 动画效果。
    pres.Slides[0].Timeline.MainSequence.AddEffect(ashp, EffectType.PathFootball,
                           EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // 为按钮创建效果序列。
    IShape shapeTrigger = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // 为按钮创建效果序列。
    ISequence seqInter = pres.Slides[0].Timeline.InteractiveSequences.Add(shapeTrigger);

    // 创建自定义用户路径。我们的对象将仅在单击按钮后移动。
    IEffect fxUserPath = seqInter.AddEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

    // 添加移动的命令，因为创建的路径为空。
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.Behaviors[0]);

    PointF[] pts = new PointF[1];
    pts[0] = new PointF(0.076f, 0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new PointF(-0.076f, -0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.Path.Add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

    // 将 PPTX 文件保存到磁盘
    pres.Save("AnimExample_out.pptx", SaveFormat.Pptx);
}
```

## **获取应用于形状的动画效果**

您可能决定找出应用于单个形状的所有动画效果。 

以下 C# 代码显示了如何获取应用于特定形状的所有效果：

```c#
// 实例化表示演示文稿文件的演示类。
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // 获取幻灯片的主要序列。
    ISequence sequence = firstSlide.Timeline.MainSequence;

    // 获取幻灯片上的第一个形状。
    IShape shape = firstSlide.Shapes[0];

    // 获取应用于该形状的所有动画效果。
    IEffect[] shapeEffects = sequence.GetEffectsByShape(shape);

    if (shapeEffects.Length > 0)
        Console.WriteLine("形状 " + shape.Name + " 有 " + shapeEffects.Length + " 个动画效果。");
}
```

## **更改动画效果时序属性**

Aspose.Slides for .NET 允许您更改动画效果的时序属性。

这是 Microsoft PowerPoint 中的动画时序窗格和扩展菜单：

![example1_image](shape-animation.png)

这些是 PowerPoint 时序与 [Effect.Timing](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/properties/timing) 属性之间的对应关系：
- PowerPoint 时序 **开始** 下拉列表与 [Effect.Timing.TriggerType](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/properties/triggertype) 属性匹配。 
- PowerPoint 时序 **持续时间** 与 [Effect.Timing.Duration](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/properties/duration) 属性匹配。动画的持续时间（以秒为单位）是动画完成一个周期所需的总时间。 
- PowerPoint 时序 **延迟** 与 [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/properties/triggerdelaytime) 属性匹配。 
- PowerPoint 时序 **重复** 下拉列表与以下属性匹配： 
  * [Effect.Timing.RepeatCount](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatcount) 属性描述效果重复的 *次数*；
  * [Effect.Timing.RepeatUntilEndSlide](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatuntilendslide) 标志指定效果是否重复直到幻灯片结束；
  * [Effect.Timing.RepeatUntilNextClick](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatuntilnextclick) 标志指定效果是否重复直到下次单击。
- PowerPoint 时序 **播放完成后回放** 复选框与 [Effect.Timing.Rewind](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/rewind/) 属性匹配。

这是更改效果时序属性的方法：

1. [应用](#apply-animation-to-shape)或获取动画效果。
2. 为所需的 [Effect.Timing](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/properties/timing) 属性设置新值。 
3. 保存修改后的 PPTX 文件。

以下 C# 代码演示了操作：

```c#
// 实例化表示演示文稿文件的演示类。
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
    // 获取幻灯片的主要序列。
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // 获取主要序列的第一个效果。
    IEffect effect = sequence[0];

    // 将效果的 TriggerType 更改为单击时启动
    effect.Timing.TriggerType = EffectTriggerType.OnClick;

    // 更改效果持续时间
    effect.Timing.Duration = 3f;

    // 更改效果 TriggerDelayTime
    effect.Timing.TriggerDelayTime = 0.5f;

    // 如果效果重复值为 "无"
    if (effect.Timing.RepeatCount == 1f)
    {
        // 将效果重复更改为 "直到下次单击"
        effect.Timing.RepeatUntilNextClick = true;
    }
    else
    {
        // 将效果重复更改为 "直到幻灯片结束"
        effect.Timing.RepeatUntilEndSlide = true;
    }

    // 启用效果的回放
    effect.Timing.Rewind = true;
    
    // 将 PPTX 文件保存到磁盘
    pres.Save("AnimExample_changed.pptx", SaveFormat.Pptx);
}
```

## **动画效果声音**

Aspose.Slides 提供了这些属性，以便您可以处理动画效果中的声音： 
- [IEffect.Sound](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/sound/) 
- [IEffect.StopPreviousSound](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/stopprevioussound/) 

### **添加动画效果声音**

以下 C# 代码显示了如何添加动画效果声音，并在下一个效果开始时停止它：

```c#
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
	// 将音频添加到演示文稿音频集合
	IAudio effectSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// 获取幻灯片的主要序列。
	ISequence sequence = firstSlide.Timeline.MainSequence;

	// 获取主要序列的第一个效果
	IEffect firstEffect = sequence[0];

	// 检查效果是否为 "无声"
	if (!firstEffect.StopPreviousSound && firstEffect.Sound == null)
	{
		// 为第一个效果添加声音
		firstEffect.Sound = effectSound;
	}

	// 获取幻灯片的第一个交互序列。
	ISequence interactiveSequence = firstSlide.Timeline.InteractiveSequences[0];

	// 设置效果 "停止之前的声音" 标志
	interactiveSequence[0].StopPreviousSound = true;

	// 将 PPTX 文件保存到磁盘
	pres.Save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
}
```

### **提取动画效果声音**

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类的实例。
2. 通过索引获取幻灯片的引用。 
3. 获取效果的主要序列。 
4. 提取嵌入到每个动画效果中的 [Sound](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/sound/) 。

以下 C# 代码显示了如何提取嵌入在动画效果中的声音：

```c#
// 实例化表示演示文稿文件的演示类。
using (Presentation presentation = new Presentation("EffectSound.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // 获取幻灯片的主要序列。
    ISequence sequence = slide.Timeline.MainSequence;

    foreach (IEffect effect in sequence)
    {
        if (effect.Sound == null)
            continue;

        // 将效果声音提取为字节数组
        byte[] audio = effect.Sound.BinaryData;
    }
}
```

## **动画之后**

Aspose.Slides for .NET 允许您更改动画效果的动画之后属性。

这是 Microsoft PowerPoint 中的动画效果窗格和扩展菜单：

![example1_image](shape-after-animation.png)

PowerPoint 效果 **动画之后** 下拉列表与以下属性匹配：

- [IEffect.AfterAnimationType](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/afteranimationtype/) 属性描述动画之后的类型：
  * PowerPoint **更多颜色** 与 [AfterAnimationType.Color](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/) 类型匹配；
  * PowerPoint **不变暗** 列表项与 [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/) 类型匹配（默认动画之后类型）；
  * PowerPoint **动画后隐藏** 项与 [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/) 类型匹配；
  * PowerPoint **在下次鼠标单击时隐藏** 项与 [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/) 类型匹配；
- [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/afteranimationcolor/) 属性定义动画之后的颜色格式。该属性与 [AfterAnimationType.Color](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/) 类型一起工作。如果您更改类型为其他类型，则将清除动画之后的颜色。

以下 C# 代码显示了如何更改动画之后效果：

```c#
// 实例化表示演示文稿文件的演示类
using (Presentation pres = new Presentation("AnimImage_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // 获取主要序列的第一个效果
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // 将动画之后类型更改为颜色
    firstEffect.AfterAnimationType = AfterAnimationType.Color;

    // 设置动画之后的变暗颜色
    firstEffect.AfterAnimationColor.Color = Color.AliceBlue;

    // 将 PPTX 文件保存到磁盘
    pres.Save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
}
```

## **动画文本**

Aspose.Slides 提供了这些属性，以便您可以处理动画效果的 *动画文本* 块：

- [IEffect.AnimateTextType](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/animatetexttype/) 描述动画文本类型。形状文本可以被动画化：
  - 一次性全部（[AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/net/aspose.slides.animation/animatetexttype/) 类型）
  - 按字（[AnimateTextType.ByWord](https://reference.aspose.com/slides/net/aspose.slides.animation/animatetexttype/) 类型）
  - 按字母（[AnimateTextType.ByLetter](https://reference.aspose.com/slides/net/aspose.slides.animation/animatetexttype/) 类型）
- [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/delaybetweentextparts/) 设置动画文本部分（单词或字母）之间的延迟。正值指定效果持续时间的百分比。负值指定以秒为单位的延迟。

这是更改效果动画文本属性的方法：

1. [应用](#apply-animation-to-shape)或获取动画效果。
2. 将 [IEffect.TextAnimation.BuildType](https://reference.aspose.com/slides/net/aspose.slides.animation/itextanimation/buildtype/) 属性设置为 [BuildType.AsOneObject](https://reference.aspose.com/slides/net/aspose.slides.animation/buildtype/) 值以关闭 *按段落* 动画模式。
3. 为 [IEffect.AnimateTextType](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/animatetexttype/) 和 [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/delaybetweentextparts/) 属性设置新值。
4. 保存修改后的 PPTX 文件。

以下 C# 代码演示了操作：

```c#
// 实例化表示演示文稿文件的演示类。
using (Presentation pres = new Presentation("AnimTextBox_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // 获取主要序列的第一个效果
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // 将效果文本动画类型更改为 "作为一个对象"
    firstEffect.TextAnimation.BuildType = BuildType.AsOneObject;

    // 将效果动画文本类型更改为 "按字"
    firstEffect.AnimateTextType = AnimateTextType.ByWord;

    // 将单词之间的延迟设置为效果持续时间的 20%
    firstEffect.DelayBetweenTextParts = 20f;

    // 将 PPTX 文件保存到磁盘
    pres.Save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
}
```