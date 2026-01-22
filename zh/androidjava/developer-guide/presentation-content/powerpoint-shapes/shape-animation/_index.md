---
title: 在 Android 上的演示文稿中应用形状动画
linktitle: 形状动画
type: docs
weight: 60
url: /zh/androidjava/shape-animation/
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
- 效果声音
- 应用动画
- PowerPoint
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Android via Java 在 PowerPoint 演示文稿中创建和自定义形状动画。脱颖而出！"
---

动画是可以应用于文本、图像、形状或[图表](https://docs.aspose.com/slides/androidjava/animated-charts/)的视觉效果。它们为演示文稿及其组成部分赋予活力。

## **为什么在演示文稿中使用动画？**

* 控制信息流
* 强调重要要点
* 提升观众的兴趣或参与度
* 使内容更易于阅读、理解或处理
* 吸引读者或观众注意演示文稿中的重要部分

PowerPoint 在 **进入**、**退出**、**强调** 和 **运动路径** 类别中提供了许多动画选项和工具。

## **Aspose.Slides 中的动画**

* Aspose.Slides 在 `Aspose.Slides.Animation` 命名空间下提供了处理动画所需的类和类型，
* Aspose.Slides 在 [EffectType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effecttype) 枚举中提供了超过 **150 种动画效果**。这些效果本质上与 PowerPoint 中使用的效果相同（或等效）。

## **将动画应用于文本框**

Aspose.Slides for Android via Java 允许您对形状中的文本应用动画。

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片引用。
3. 添加一个 `rectangle` [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape)。
4. 向 [IAutoShape.TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-) 添加文本。
5. 获取主效果序列。
6. 向 [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape) 添加动画效果。
7. 将 `TextAnimation.BuildType` 属性设置为 `BuildType` 枚举中的值。
8. 将演示文稿写入磁盘为 PPTX 文件。

下面的 Java 代码演示了如何对 AutoShape 应用 `Fade` 效果并将文本动画设置为 *By 1st Level Paragraphs* 值：
```java
// 实例化一个表示演示文稿文件的 Presentation 类。
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // 添加带文本的新 AutoShape
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");

    // 获取幻灯片的主序列。
    ISequence sequence = sld.getTimeline().getMainSequence();

    // 为形状添加淡入淡出动画效果
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // 按第一级段落进行形状文本动画
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // 将 PPTX 文件保存到磁盘
    pres.save(path + "AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{%  alert color="primary"  %}} 
除了对文本应用动画外，您还可以对单个 [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph) 应用动画。请参阅[**Animated Text**](/slides/zh/androidjava/animated-text/)。
{{% /alert %}} 

## **将动画应用于 PictureFrame**

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片引用。
3. 在幻灯片上添加或获取一个 [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe)。
4. 获取主效果序列。
5. 向 [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe) 添加动画效果。
6. 将演示文稿写入磁盘为 PPTX 文件。

下面的 Java 代码演示了如何对图片框应用 `Fly` 效果：
```java
// 实例化一个表示演示文稿文件的 Presentation 类。
Presentation pres = new Presentation();
try {
    // 加载要添加到演示文稿图像集合中的图像
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // 向幻灯片添加图片框
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, picture);

    // 获取幻灯片的主序列。
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // 为图片框添加从左侧飞入的动画效果
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // 将 PPTX 文件保存到磁盘
    pres.save(path + "AnimImage_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **将动画应用于形状**

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片引用。
3. 添加一个 `rectangle` [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape)。
4. 添加一个 `Bevel` [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape)（单击此对象时播放动画）。
5. 在 bevel 形状上创建效果序列。
6. 创建自定义 `UserPath`。
7. 添加移动到 `UserPath` 的命令。
8. 将演示文稿写入磁盘为 PPTX 文件。

下面的 Java 代码演示了如何对形状应用 `PathFootball`（路径足球）效果：
```java
// 实例化一个表示 PPTX 文件的 Presentation 类。
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // 为已有形状从头创建 PathFootball 效果。
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");

    // 添加 PathFootBall 动画效果
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // 创建某种 "button"。
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // 为此按钮创建效果序列。
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // 创建自定义用户路径。我们的对象仅在按钮被点击后移动。
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

     // 添加移动命令，因为创建的路径为空。
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.getBehaviors().get_Item(0));

    Point2D.Float[] pts = new Point2D.Float[1];
    pts[0] = new Point2D.Float(0.076f, 0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new Point2D.Float(-0.076f, -0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.getPath().add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

     // 将 PPTX 文件写入磁盘
    pres.save("AnimExample_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **获取应用于形状的动画效果**

以下示例演示如何使用 [ISequence](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isequence/) 接口中的 `getEffectsByShape` 方法获取应用于形状的所有动画效果。

**示例 1：获取普通幻灯片上形状的动画效果**

之前，您已经学习了如何向 PowerPoint 演示文稿中的形状添加动画效果。下面的示例代码展示了如何获取演示文稿 `AnimExample_out.pptx` 中第一张普通幻灯片上第一个形状所应用的效果。
```java
Presentation presentation = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // 获取幻灯片的主动画序列。
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // 获取第一张幻灯片上的第一个形状。
    IShape shape = firstSlide.getShapes().get_Item(0);

    // 获取应用于该形状的动画效果。
    IEffect[] shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0)
        System.out.println("The shape " + shape.getName() + " has " + shapeEffects.length + " animation effects.");
} finally {
    if (presentation != null) presentation.dispose();
}
```


**示例 2：获取所有动画效果，包括从占位符继承的效果**

如果普通幻灯片上的形状具有位于布局幻灯片和/或母版幻灯片上的占位符，并且这些占位符已添加动画效果，则在放映期间该形状的所有效果都会播放，包括从占位符继承的效果。

假设我们有一个 PowerPoint 演示文稿文件 `sample.pptx`，其中只有一张幻灯片，仅包含一个脚注形状，文本为 “Made with Aspose.Slides”，并对该形状应用了 **Random Bars** 效果。

![幻灯片形状动画效果](slide-shape-animation.png)

再假设在 **布局** 幻灯片的页脚占位符上应用了 **Split** 效果。

![布局形状动画效果](layout-shape-animation.png)

最后，在 **母版** 幻灯片的页脚占位符上应用了 **Fly In** 效果。

![母版形状动画效果](master-shape-animation.png)

下面的示例代码演示了如何使用 [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) 接口中的 `getBasePlaceholder` 方法访问形状占位符，并获取应用于页脚形状的动画效果，包括从布局和母版幻灯片上的占位符继承的效果。
```java
Presentation presentation = new Presentation("sample.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

// Get animation effects of the shape on the normal slide.
IShape shape = slide.getShapes().get_Item(0);
IEffect[] shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// Get animation effects of the placeholder on the layout slide.
IShape layoutShape = shape.getBasePlaceholder();
IEffect[] layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// Get animation effects of the placeholder on the master slide.
IShape masterShape = layoutShape.getBasePlaceholder();
IEffect[] masterShapeEffects = slide.getLayoutSlide().getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(masterShape);

System.out.println("Main sequence of shape effects:");
printEffects(masterShapeEffects);
printEffects(layoutShapeEffects);
printEffects(shapeEffects);

presentation.dispose();
```

```java
static void printEffects(IEffect[] effects)
{
    for (IEffect effect : effects)
    {
        String typeName = EffectType.getName(EffectType.class, effect.getType());
        String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());

        System.out.println(typeName + " " + subtypeName);
    }
}
```


```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```


## **更改动画效果的时间属性**

Aspose.Slides for Android via Java 允许您更改动画效果的时间属性。

这是 Microsoft PowerPoint 中的动画计时窗格：

![示例1 图像](shape-animation.png)

以下是 PowerPoint 计时与 [Effect.Timing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IEffect#getTiming--) 属性之间的对应关系：

- PowerPoint 计时 **Start** 下拉列表对应 [Effect.Timing.TriggerType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiming#getTriggerType--) 属性。
- PowerPoint 计时 **Duration** 对应 [Effect.Timing.Duration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiming#getDuration--) 属性。动画的持续时间（以秒为单位）是动画完成一个循环所需的总时间。
- PowerPoint 计时 **Delay** 对应 [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiming#getTriggerDelayTime--) 属性。

以下是更改 Effect Timing 属性的方法：

1. [Apply](#apply-animation-to-shape) 或获取动画效果。
2. 为所需的 [Effect.Timing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IEffect#getTiming--) 属性设置新值。
3. 保存修改后的 PPTX 文件。

下面的 Java 代码演示了此操作：
```java
// 实例化表示演示文稿文件的 Presentation 类。
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // 获取幻灯片的主序列。
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // 获取主序列的第一个效果。
    IEffect effect = sequence.get_Item(0);

    // 将效果的 TriggerType 更改为点击启动
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick);

    // 更改效果持续时间
    effect.getTiming().setDuration(3f);

    // 更改效果的 TriggerDelayTime
    effect.getTiming().setTriggerDelayTime(0.5f);

    // 将 PPTX 文件保存到磁盘
    pres.save("AnimExample_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **动画效果声音**

Aspose.Slides 提供以下属性，以便在动画效果中使用声音：

- [setSound(IAudio value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effect/#setStopPreviousSound-boolean-)

### **添加动画效果声音**

下面的 Java 代码演示了如何添加动画效果声音并在下一个效果开始时停止它：
```java
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // 向演示文稿音频集合中添加音频
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // 获取幻灯片的主序列。
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // 获取主序列的第一个效果
    IEffect firstEffect = sequence.get_Item(0);

    // 检查效果是否为 "No Sound"
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // 为第一个效果添加声音
        firstEffect.setSound(effectSound);
    }

    // 获取幻灯片的第一个交互序列。
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // 设置效果的 "Stop previous sound" 标志
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // 将 PPTX 文件写入磁盘
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **提取动画效果声音**

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 类的实例。
2. 通过索引获取幻灯片引用。 
3. 获取主效果序列。 
4. 提取嵌入到每个动画效果中的 [setSound(IAudio value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)。

下面的 Java 代码演示了如何提取动画效果中嵌入的声音：
```java
// 实例化一个表示演示文稿文件的 Presentation 类。
Presentation presentation = new Presentation("EffectSound.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 获取幻灯片的主序列。
    ISequence sequence = slide.getTimeline().getMainSequence();

    for (IEffect effect : sequence)
    {
        if (effect.getSound() == null)
            continue;

        // 提取效果声音为字节数组
        byte[] audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **动画结束后**

Aspose.Slides for Android via Java 允许您更改动画效果的 After animation 属性。

这是 Microsoft PowerPoint 中的动画效果窗格和扩展菜单：

![示例1 图像](shape-after-animation.png)

PowerPoint 效果 **After animation** 下拉列表对应以下属性：

- [setAfterAnimationType(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAfterAnimationType-int-) 属性描述 After animation 类型：
  * PowerPoint **More Colors** 对应 [AfterAnimationType.Color](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#Color) 类型；
  * PowerPoint **Don't Dim** 项对应 [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#DoNotDim) 类型（默认的 After animation 类型）；
  * PowerPoint **Hide After Animation** 项对应 [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#HideAfterAnimation) 类型；
  * PowerPoint **Hide on Next Mouse Click** 项对应 [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick) 类型；
- [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) 属性定义 After animation 的颜色格式。此属性与 [AfterAnimationType.Color](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#Color) 类型一起使用。如果将类型更改为其他类型，则 After animation 颜色将被清除。

下面的 Java 代码演示了如何更改 After animation 效果：
```java
// 实例化一个表示演示文稿文件的 Presentation 类
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // 获取主序列的第一个效果
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // 将后动画类型更改为颜色
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // 设置后动画的暗淡颜色
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // 将 PPTX 文件写入磁盘
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **动画文字**

Aspose.Slides 提供以下属性，以便使用动画效果的 *Animate text* 块：

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) 描述效果的动画文本类型。形状文本可以被动画化：
  * 一次性全部（[AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/androidjava/com.aspose.slides/animatetexttype/#AllAtOnce) 类型）
  * 按词（[AnimateTextType.ByWord](https://reference.aspose.com/slides/androidjava/com.aspose.slides/animatetexttype/#ByWord) 类型）
  * 按字母（[AnimateTextType.ByLetter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/animatetexttype/#ByLetter) 类型）
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) 设置动画文本部分（词或字母）之间的延迟。正值表示效果持续时间的百分比，负值表示以秒为单位的延迟。

以下是更改 Effect Animate text 属性的方法：

1. [Apply](#apply-animation-to-shape) 或获取动画效果。
2. 将 [setBuildType(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextanimation/#setBuildType-int-) 属性设置为 [BuildType.AsOneObject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/buildtype/#AsOneObject) 值，以关闭 *By Paragraphs* 动画模式。
3. 为 [setAnimateTextType(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) 和 [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) 属性设置新值。
4. 保存修改后的 PPTX 文件。

下面的 Java 代码演示了此操作：
```java
// 实例化一个表示演示文稿文件的 Presentation 类。
Presentation pres = new Presentation("AnimTextBox_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // 获取主序列的第一个效果
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // 将效果的文本动画类型更改为 "As One Object"
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // 将效果的动画文本类型更改为 "By word"
    firstEffect.setAnimateTextType(AnimateTextType.ByWord);

    // 设置单词之间的延迟为效果持续时间的 20%
    firstEffect.setDelayBetweenTextParts(20f);

    // 将 PPTX 文件写入磁盘
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **常见问题**

**如何确保在将演示文稿发布到网页时动画得以保留？**

[Export to HTML5](/slides/zh/androidjava/export-to-html5/) 并启用负责 [shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) 和 [transition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) 动画的 [options](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/)。纯 HTML 不播放幻灯片动画，而 HTML5 可以。

**更改形状的 z 顺序（层次顺序）会如何影响动画？**

动画顺序和绘制顺序是独立的：效果控制出现/消失的时机和类型，而 [z-order](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getZOrderPosition--) 决定哪一个覆盖哪一个。可见结果由两者的组合决定。（这是 PowerPoint 的一般行为；Aspose.Slides 的效果与形状模型遵循相同的逻辑。）

**将动画转换为视频时对某些效果是否有限制？**

一般来说，[动画受支持](/slides/zh/androidjava/convert-powerpoint-to-video/)，但在罕见情况下或特定效果可能会有不同的渲染。建议使用您所用的效果和相应的库版本进行测试。