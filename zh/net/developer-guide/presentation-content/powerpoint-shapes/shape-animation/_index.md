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
- 动画文字
- 添加动画
- 获取动画
- 提取动画
- 添加效果
- 获取效果
- 提取效果
- 效果音效
- 应用动画
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 在 PowerPoint 演示文稿中创建和自定义形状动画。脱颖而出！"
---

动画是可应用于文本、图像、形状或[图表](/slides/zh/net/animated-charts/)的视觉效果。它们为演示文稿或其组成部分注入活力。

## **为什么在演示文稿中使用动画？**

使用动画，您可以

* 控制信息流动
* 强调重要要点
* 增加受众的兴趣或参与度
* 使内容更易于阅读、理解或处理
* 吸引读者或观众注意演示文稿中的重要部分

PowerPoint 在 **进入**、**退出**、**强调** 和 **运动路径** 类别中提供了大量动画选项和工具。

## **Aspose.Slides 中的动画**

* Aspose.Slides 提供了位于 [Aspose.Slides.Animation](https://reference.aspose.com/slides/net/aspose.slides.animation/) 命名空间下的类和类型，以便处理动画，
* Aspose.Slides 在 [EffectType](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttype) 枚举中提供了超过 **150 种动画效果**。这些效果本质上与 PowerPoint 中使用的效果相同（或等效）。

## **将动画应用于文本框**

Aspose.Slides for .NET 允许您对形状中的文本应用动画。

1. 创建一个 [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 添加一个 `rectangle` [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape)。
4. 向 [IAutoShape.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/properties/textframe) 添加文本。
5. 获取主效果序列。
6. 为 [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) 添加动画效果。
7. 将 [TextAnimation.BuildType](https://reference.aspose.com/slides/net/aspose.slides.animation/textanimation/properties/buildtype) 属性设置为来自 [BuildType 枚举](https://reference.aspose.com/slides/net/aspose.slides.animation/buildtype) 的值。
8. 将演示文稿写入磁盘，保存为 PPTX 文件。

下面的 C# 代码演示了如何对 AutoShape 应用 `Fade` 效果并将文本动画设置为 *By 1st Level Paragraphs* 值：
```c#
// 实例化一个表示演示文稿文件的 Presentation 类。
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    
    // 添加带文本的新 AutoShape
    IAutoShape autoShape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "First paragraph \nSecond paragraph \n Third paragraph";

    // 获取幻灯片的主序列。
    ISequence sequence = sld.Timeline.MainSequence;

    // 为形状添加 Fade 动画效果
    IEffect effect = sequence.AddEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // 按第一级段落对形状文本进行动画
    effect.TextAnimation.BuildType = BuildType.ByLevelParagraphs1;

    // 将 PPTX 文件保存到磁盘
    pres.Save(path + "AnimTextBox_out.pptx", SaveFormat.Pptx);
}
```


{{%  alert color="primary"  %}} 

除了对文本应用动画外，您还可以对单个[Paragraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph)应用动画。请参阅[**动画文本**](/slides/zh/net/animated-text/)。

{{% /alert %}} 

## **将动画应用于图片框**

1. 创建一个 [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 在幻灯片上添加或获取一个 [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe)。
5. 获取主效果序列。
6. 为 [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe) 添加动画效果。
8. 将演示文稿写入磁盘，保存为 PPTX 文件。

下面的 C# 代码演示了如何对图片框应用 `Fly` 效果：
```c#
// 实例化一个表示演示文稿文件的 Presentation 类。
using (Presentation pres = new Presentation())
{
    // 加载要添加到演示文稿图像集合中的图像
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

1. 创建一个 [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 添加一个 `rectangle` [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape)。
4. 添加一个 `Bevel` [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape)（点击此对象时播放动画）。
5. 为该斜角形状创建效果序列。
6. 创建自定义 `UserPath`。
7. 为 `UserPath` 添加移动指令。
8. 将演示文稿写入磁盘，保存为 PPTX 文件。

下面的 C# 代码演示了如何对形状应用 `PathFootball`（路径足球）效果：
```c#
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

    // 创建某种 "按钮"。
    IShape shapeTrigger = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // 为按钮创建效果序列。
    ISequence seqInter = pres.Slides[0].Timeline.InteractiveSequences.Add(shapeTrigger);

    // 创建自定义用户路径。仅在按钮被点击后才移动对象。
    IEffect fxUserPath = seqInter.AddEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

    // 为移动添加命令，因为创建的路径为空。
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

以下示例展示了如何使用 [ISequence](https://reference.aspose.com/slides/net/aspose.slides.animation/isequence/) 接口的 `GetEffectsByShape` 方法获取所有应用于形状的动画效果。

**示例 1：获取普通幻灯片上形状的动画效果**

之前，您已经学习了如何在 PowerPoint 演示文稿中为形状添加动画效果。下面的示例代码展示了如何获取演示文稿 `AnimExample_out.pptx` 中第一张普通幻灯片上第一个形状的效果：
```c#
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


**示例 2：获取包括占位符继承的所有动画效果**

如果普通幻灯片上的形状拥有位于版式幻灯片和/或母版幻灯片上的占位符，并且这些占位符已添加动画效果，则在放映时该形状将播放所有效果，包括来自占位符的继承效果。

假设我们有一个 PowerPoint 演示文稿文件 `sample.pptx`，其中唯一一张幻灯片只包含一个页脚形状，文本为 “Made with Aspose.Slides”，并对该形状应用了 **Random Bars** 效果。

![Slide shape animation effect](slide-shape-animation.png)

再假设在 **版式** 幻灯片的页脚占位符上应用了 **Split** 效果。

![Layout shape animation effect](layout-shape-animation.png)

最后，在 **母版** 幻灯片的页脚占位符上应用了 **Fly In** 效果。

![Master shape animation effect](master-shape-animation.png)

下面的示例代码演示了如何使用 [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) 接口的 `GetBasePlaceholder` 方法访问形状占位符并获取页脚形状的动画效果，包括来自版式和母版占位符的继承效果：
```cs
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
```

```cs
static void PrintEffects(IEnumerable<IEffect> effects)
{
    foreach (IEffect effect in effects)
    {
        Console.WriteLine($"{effect.Type} {effect.Subtype}");
    }
}
```


输出：
```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```


## **更改动画效果的时间属性**

Aspose.Slides for .NET 允许您更改动画效果的时间属性。

以下是 Microsoft PowerPoint 中的动画时序窗格及其扩展菜单：

![example1_image](shape-animation.png)

这些对应关系映射了 PowerPoint 时序与 [Effect.Timing](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/properties/timing) 属性之间的关系：
- PowerPoint 时序 **Start** 下拉列表对应 [Effect.Timing.TriggerType](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/properties/triggertype) 属性。
- PowerPoint 时序 **Duration** 对应 [Effect.Timing.Duration](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/properties/duration) 属性。动画的持续时间（秒）指完成一次循环所需的总时间。
- PowerPoint 时序 **Delay** 对应 [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/properties/triggerdelaytime) 属性。
- PowerPoint 时序 **Repeat** 下拉列表对应以下属性：
  * [Effect.Timing.RepeatCount](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatcount) 属性，描述效果重复的*次数*；
  * [Effect.Timing.RepeatUntilEndSlide](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatuntilendslide) 标志，指定是否在幻灯片结束前一直重复；
  * [Effect.Timing.RepeatUntilNextClick](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatuntilnextclick) 标志，指定是否在下一次点击前一直重复。
- PowerPoint 时序 **Rewind when done playing** 复选框对应 [Effect.Timing.Rewind](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/rewind/) 属性。

更改 Effect Timing 属性的步骤：

1. [应用](#apply-animation-to-shape)或获取动画效果。
2. 为所需的 [Effect.Timing](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/properties/timing) 属性设置新值。
3. 保存修改后的 PPTX 文件。

下面的 C# 代码演示了此操作：
```c#
 // 实例化一个表示演示文稿文件的 Presentation 类。
 using (Presentation pres = new Presentation("AnimExample_out.pptx"))
 {
     // 获取幻灯片的主序列。
     ISequence sequence = pres.Slides[0].Timeline.MainSequence;

     // 获取主序列的第一个效果。
     IEffect effect = sequence[0];

     // 将效果的 TriggerType 更改为单击开始
     effect.Timing.TriggerType = EffectTriggerType.OnClick;

     // 更改效果的持续时间
     effect.Timing.Duration = 3f;

     // 更改效果的 TriggerDelayTime
     effect.Timing.TriggerDelayTime = 0.5f;

     // 如果效果的 Repeat 值为 "none"
     if (effect.Timing.RepeatCount == 1f)
     {
         // 将效果的 Repeat 更改为 “直到下次点击”
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


## **动画效果音效**

Aspose.Slides 提供以下属性，以便在动画效果中使用音频：
- [IEffect.Sound](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/sound/)
- [IEffect.StopPreviousSound](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/stopprevioussound/)

### **为动画效果添加音效**

下面的 C# 代码展示了如何为动画效果添加音效，并在下一个效果开始时停止它：
```c#
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
	// 将音频添加到演示文稿的音频集合
	IAudio effectSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// 获取幻灯片的主序列。
	ISequence sequence = firstSlide.Timeline.MainSequence;

	// 获取主序列的第一个效果
	IEffect firstEffect = sequence[0];

	// 检查该效果是否没有声音
	if (!firstEffect.StopPreviousSound && firstEffect.Sound == null)
	{
		// 为第一个效果添加声音
		firstEffect.Sound = effectSound;
	}

	// 获取幻灯片的第一个交互序列。
	ISequence interactiveSequence = firstSlide.Timeline.InteractiveSequences[0];

	// 设置效果的 “停止先前声音” 标志
	interactiveSequence[0].StopPreviousSound = true;

	// 将 PPTX 文件写入磁盘
	pres.Save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
}
```


### **提取动画效果音效**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 获取主效果序列。
4. 提取嵌入到每个动画效果中的 [Sound](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/sound/) 。

下面的 C# 代码演示了如何提取嵌入在动画效果中的音频：
```c#
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

        // 提取效果的音频为字节数组
        byte[] audio = effect.Sound.BinaryData;
    }
}
```


## **动画结束后**

Aspose.Slides for .NET 允许您更改动画效果的“After animation”属性。

以下是 Microsoft PowerPoint 中的动画效果窗格及其扩展菜单：

![example1_image](shape-after-animation.png)

PowerPoint “After animation” 下拉列表对应以下属性：

- [IEffect.AfterAnimationType](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/afteranimationtype/) 属性，用于描述动画结束后的类型：
  * PowerPoint **More Colors** 对应 [AfterAnimationType.Color](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/) 类型；
  * PowerPoint **Don't Dim** 项对应 [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/) 类型（默认）；
  * PowerPoint **Hide After Animation** 项对应 [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/) 类型；
  * PowerPoint **Hide on Next Mouse Click** 项对应 [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/) 类型；
- [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/afteranimationcolor/) 属性定义动画结束后的颜色格式。该属性与 [AfterAnimationType.Color](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/) 类型配合使用。如果将类型更改为其他值，动画结束颜色将被清除。

下面的 C# 代码演示了如何更改动画结束效果：
```c#
// 实例化一个表示演示文稿文件的 Presentation 类
using (Presentation pres = new Presentation("AnimImage_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // 获取主序列的第一个效果
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // 将后动画类型更改为 Color
    firstEffect.AfterAnimationType = AfterAnimationType.Color;

    // 设置后动画的暗淡颜色
    firstEffect.AfterAnimationColor.Color = Color.AliceBlue;

    // 将 PPTX 文件写入磁盘
    pres.Save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
}
```


## **文字动画**

Aspose.Slides 提供以下属性，以便操作动画效果的*Animate text* 块：

- [IEffect.AnimateTextType](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/animatetexttype/) 描述效果的文字动画类型。形状文字可以按以下方式动画：
  - 同时全部显示 ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/net/aspose.slides.animation/animatetexttype/) 类型)
  - 按单词 ([AnimateTextType.ByWord](https://reference.aspose.com/slides/net/aspose.slides.animation/animatetexttype/) 类型)
  - 按字母 ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/net/aspose.slides.animation/animatetexttype/) 类型)
- [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/delaybetweentextparts/) 设置动画文字部件（单词或字母）之间的延迟。正值表示效果持续时间的百分比，负值表示以秒为单位的延迟。

更改 Effect Animate text 属性的步骤：

1. [应用](#apply-animation-to-shape)或获取动画效果。
2. 将 [IEffect.TextAnimation.BuildType](https://reference.aspose.com/slides/net/aspose.slides.animation/itextanimation/buildtype/) 属性设置为 [BuildType.AsOneObject](https://reference.aspose.com/slides/net/aspose.slides.animation/buildtype/) 值，以关闭 *By Paragraphs* 动画模式。
3. 为 [IEffect.AnimateTextType](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/animatetexttype/) 和 [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/delaybetweentextparts/) 属性设置新值。
4. 保存修改后的 PPTX 文件。

下面的 C# 代码演示了此操作：
```c#
// 实例化一个表示演示文稿文件的 Presentation 类。
using (Presentation pres = new Presentation("AnimTextBox_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // 获取主序列的第一个效果
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // 将效果的文本动画类型更改为 “作为单个对象”
    firstEffect.TextAnimation.BuildType = BuildType.AsOneObject;

    // 将效果的动画文字类型更改为 “按词”
    firstEffect.AnimateTextType = AnimateTextType.ByWord;

    // 将词与词之间的延迟设置为效果持续时间的 20%
    firstEffect.DelayBetweenTextParts = 20f;

    // 将 PPTX 文件写入磁盘
    pres.Save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
}
```


## **常见问题**

**如何确保在将演示文稿发布到 Web 时保留动画？**

[导出为 HTML5](/slides/zh/net/export-to-html5/) 并启用负责[形状](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/)和[切换](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/)动画的[选项](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/)。普通 HTML 不会播放幻灯片动画，而 HTML5 可以。

**更改形状的 Z 顺序（图层顺序）会如何影响动画？**

动画顺序和绘制顺序是独立的：效果控制出现/消失的时间和类型，而 [z-order](https://reference.aspose.com/slides/net/aspose.slides/shape/zorderposition/) 决定哪个对象覆盖哪个。最终可见效果由两者共同决定。（这是 PowerPoint 的通用行为，Aspose.Slides 的效果与形状模型遵循相同逻辑。）

**在将某些动画转换为视频时是否存在限制？**

总体而言，[动画受支持](/slides/zh/net/convert-powerpoint-to-video/)，但在少数情况下或特定效果可能呈现不同。建议使用您实际使用的效果和库版本进行测试。