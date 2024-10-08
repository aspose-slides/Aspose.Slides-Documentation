---
title: 形状动画
type: docs
weight: 60
url: /androidjava/shape-animation/
keywords: "PowerPoint 动画, 动画效果, 应用动画, PowerPoint 演示文稿, Java, Aspose.Slides for Android via Java"
description: "在 Java 中应用 PowerPoint 动画"
---

动画是可以应用于文本、图像、形状或 [图表](https://docs.aspose.com/slides/androidjava/animated-charts/) 的视觉效果。它们为演示文稿或其组成部分注入了生命。

### **为什么在演示文稿中使用动画？**

使用动画，您可以

* 控制信息的流动
* 强调重要的要点
* 增强您观众的兴趣或参与度
* 使内容更易于阅读、理解或处理
* 吸引您的读者或观众关注演示中的重要部分

PowerPoint 提供了多个选项和工具，用于在 **进入**、**退出**、**强调** 和 **运动路径** 类别下使用动画及其效果。

### **Aspose.Slides 中的动画**

* Aspose.Slides 提供了您所需的类和类型，以便在 `Aspose.Slides.Animation` 命名空间下处理动画。
* Aspose.Slides 提供了超过 **150 种动画效果**，它们在 [EffectType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effecttype) 枚举中。 这些效果本质上与 PowerPoint 中使用的效果相同（或等效）。

## **将动画应用于文本框**

Aspose.Slides for Android via Java 允许您将动画应用于形状中的文本。

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
2. 根据其索引获取幻灯片的引用。
3. 添加一个 `rectangle` [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape)。
4. 向 [IAutoShape.TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-) 添加文本。
5. 获取效果的主序列。
6. 向 [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape) 添加动画效果。
7. 将 `TextAnimation.BuildType` 属性设置为 `BuildType` 枚举中的值。
8. 将演示文稿写入磁盘作为 PPTX 文件。

以下 Java 代码演示了如何将 `Fade` 效果应用于 AutoShape，并将文本动画设置为 *By 1st Level Paragraphs* 值：

```java
// Instantiates a presentation class that represents a presentation file.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Adds new AutoShape with text
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("第一段 \n第二段 \n第三段");

    // Gets the main sequence of the slide.
    ISequence sequence = sld.getTimeline().getMainSequence();

    // Adds Fade animation effect to shape
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Animates shape text by 1st level paragraphs
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // Save the PPTX file to disk
    pres.save(path + "AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert color="primary"  %}} 

除了将动画应用于文本，您还可以将动画应用于单个 [段落](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph)。 请参见 [**动画文本**](/slides/androidjava/animated-text/)。

{{% /alert %}} 

## **将动画应用于图片框**

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
2. 根据其索引获取幻灯片的引用。
3. 在幻灯片上添加或获取 [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe)。
4. 获取效果的主序列。
5. 向 [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe) 添加动画效果。
6. 将演示文稿写入磁盘作为 PPTX 文件。

以下 Java 代码演示了如何将 `Fly` 效果应用于图片框：

```java
// Instantiates a presentation class that represents a presentation file.
Presentation pres = new Presentation();
try {
    // Load Image to be added in presentaiton image collection
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Adds picture frame to slide
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, picture);

    // Gets the main sequence of the slide.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Adds Fly from Left animation effect to picture frame
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Save the PPTX file to disk
    pres.save(path + "AnimImage_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **将动画应用于形状**

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类的实例。
2. 根据其索引获取幻灯片的引用。
3. 添加一个 `rectangle` [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape)。
4. 添加一个 `Bevel` [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape)（当单击此对象时，动画会播放）。
5. 在 Bevel 形状上创建效果的序列。
6. 创建一个自定义 `UserPath`。
7. 为移动到 `UserPath` 添加命令。
8. 将演示文稿写入磁盘作为 PPTX 文件。

以下 Java 代码演示了如何将 `PathFootball`（路径足球）效果应用于形状：

```java
// Instantiate a Presentation class that represents a PPTX file.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Creates PathFootball effect for existing shape from scratch.
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("动画文本框");

    // Adds the PathFootBall animation effect
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Creates some kind of "button".
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Creates a sequence of effects for this button.
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // Creates a custom user path. Our object will be moved only after the button is clicked.
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

     // Adds commands for moving since created path is empty.
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.getBehaviors().get_Item(0));

    Point2D.Float[] pts = new Point2D.Float[1];
    pts[0] = new Point2D.Float(0.076f, 0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new Point2D.Float(-0.076f, -0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.getPath().add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

     // Writes the PPTX file to disk
    pres.save("AnimExample_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **获取应用于形状的动画效果**

您可能希望找出应用于单个形状的所有动画效果。

以下 Java 代码演示了如何获取应用于特定形状的所有效果：

```java
// Instantiates a presentation class that represents a presentation file.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Gets the main sequence of the slide.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Gets the first shape on slide.
    IShape shape = firstSlide.getShapes().get_Item(0);

    // Gets all animation effects applied to the shape.
    IEffect[] shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0)
        System.out.println("形状 " + shape.getName() + " 有 " + shapeEffects.length + " 个动画效果。");
} finally {
    if (pres != null) pres.dispose();
}
```

## **更改动画效果的时间属性**

Aspose.Slides for Android via Java 允许您更改动画效果的时间属性。

这是 Microsoft PowerPoint 中的动画定时窗格：

![example1_image](shape-animation.png)

下面是 PowerPoint 定时与 [Effect.Timing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IEffect#getTiming--) 属性之间的对应关系：

- PowerPoint 定时 **开始** 下拉列表匹配 [Effect.Timing.TriggerType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiming#getTriggerType--) 属性。
- PowerPoint 定时 **持续时间** 匹配 [Effect.Timing.Duration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiming#getDuration--) 属性。 动画的持续时间（以秒为单位）是完成一个周期所需的总时间。
- PowerPoint 定时 **延迟** 匹配 [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiming#getTriggerDelayTime--) 属性。

这就是更改效果定时属性的方法：

1. [应用](#apply-animation-to-shape) 或获取动画效果。
2. 设置所需的 [Effect.Timing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IEffect#getTiming--) 属性的新值。
3. 保存修改后的 PPTX 文件。

以下 Java 代码演示了此操作：

```java
// Instantiates a presentation class that represents a presentation file.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Gets the main sequence of the slide.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Gets the first effect of main sequence.
    IEffect effect = sequence.get_Item(0);

    // Changes effect TriggerType to start on click
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick);

    // Changes effect Duration
    effect.getTiming().setDuration(3f);

    // Changes effect TriggerDelayTime
    effect.getTiming().setTriggerDelayTime(0.5f);

    // Saves the PPTX file to disk
    pres.save("AnimExample_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **动画效果音效**

Aspose.Slides 提供了这些属性，允许您处理动画效果中的声音：

- [setSound(IAudio value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effect/#setStopPreviousSound-boolean-)

### **添加动画效果音效**

以下 Java 代码演示了如何添加动画效果声音并在下一个效果开始时停止它：

```java
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Adds audio to presentation audio collection
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Gets the main sequence of the slide.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Gets the first effect of the main sequence
    IEffect firstEffect = sequence.get_Item(0);

    // Сhecks the effect for "No Sound"
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // Adds sound for the first effect
        firstEffect.setSound(effectSound);
    }

    // Gets the first interactive sequence of the slide.
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // Sets the effect "Stop previous sound" flag
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // Writes the PPTX file to disk
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **提取动画效果音效**

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/aspose.slides/presentation/) 类的实例。
2. 根据其索引获取幻灯片的引用。
3. 获取效果的主序列。
4. 提取嵌入到每个动画效果的 [setSound(IAudio value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)。

以下 Java 代码演示了如何提取嵌入在动画效果中的声音：

```java
// Instantiates a presentation class that represents a presentation file.
Presentation presentation = new Presentation("EffectSound.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Gets the main sequence of the slide.
    ISequence sequence = slide.getTimeline().getMainSequence();

    for (IEffect effect : sequence)
    {
        if (effect.getSound() == null)
            continue;

        // Extracts the effect sound in byte array
        byte[] audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **动画后**

Aspose.Slides for Android via Java 允许您更改动画效果的“动画后”属性。

这是 Microsoft PowerPoint 中的动画效果窗格和扩展菜单：

![example1_image](shape-after-animation.png)

PowerPoint 效果 **动画后** 下拉列表与以下属性对应：

- [setAfterAnimationType(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAfterAnimationType-int-) 属性描述了动画后的类型：
  * PowerPoint **更多颜色** 匹配 [AfterAnimationType.Color](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#Color) 类型；
  * PowerPoint **不暗淡** 列表项匹配 [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#DoNotDim) 类型（默认动画后类型）；
  * PowerPoint **动画后隐藏** 项匹配 [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#HideAfterAnimation) 类型；
  * PowerPoint **在下次鼠标单击时隐藏** 项匹配 [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick) 类型；
- [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) 属性定义了动画后的颜色格式。 此属性与 [AfterAnimationType.Color](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#Color) 类型一起使用。 如果您将类型更改为其他类型，则动画后的颜色将被清除。

以下 Java 代码演示了如何更改动画后的效果：

```java
// Instantiates a presentation class that represents a presentation file
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Gets the first effect of the main sequence
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Changes the after animation type to Color
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // Sets the after animation dim color
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // Writes the PPTX file to disk
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **动画文本**

Aspose.Slides 提供了这些属性，使您能够处理动画效果的 *动画文本* 块：

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) 描述动画文本类型。 形状文本可以按以下方式动画：
  - 同时全部 ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/androidjava/com.aspose.slides/animatetexttype/#AllAtOnce) 类型)
  - 按词 ([AnimateTextType.ByWord](https://reference.aspose.com/slides/androidjava/com.aspose.slides/animatetexttype/#ByWord) 类型)
  - 按字母 ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/animatetexttype/#ByLetter) 类型)
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) 设置动画文本部分（单词或字母）之间的延迟。 正值指定效果持续时间的百分比。 负值指定以秒为单位的延迟。

这是如何更改效果动画文本属性的方法：

1. [应用](#apply-animation-to-shape) 或获取动画效果。
2. 将 [setBuildType(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextanimation/#setBuildType-int-) 属性设置为 [BuildType.AsOneObject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/buildtype/#AsOneObject) 值，以关闭 *按段落* 动画模式。
3. 为 [setAnimateTextType(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) 和 [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) 属性设置新值。
4. 保存修改后的 PPTX 文件。

以下 Java 代码演示了此操作：

```java
// Instantiates a presentation class that represents a presentation file.
Presentation pres = new Presentation("AnimTextBox_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Gets the first effect of the main sequence
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Changes the effect Text animation type to "As One Object"
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // Changes the effect Animate text type to "By word"
    firstEffect.setAnimateTextType(AnimateTextType.ByWord);

    // Sets the delay between words to 20% of effect duration
    firstEffect.setDelayBetweenTextParts(20f);

    // Writes the PPTX file to disk
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```