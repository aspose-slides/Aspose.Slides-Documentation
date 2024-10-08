---
title: 形状动画
type: docs
weight: 60
url: /java/shape-animation/
keywords: "PowerPoint 动画, 动画效果, 应用动画, PowerPoint 演示文稿, Java, Aspose.Slides for Java"
description: "在 Java 中应用 PowerPoint 动画"
---

动画是可以应用于文本、图像、形状或 [图表](https://docs.aspose.com/slides/java/animated-charts/) 的视觉效果。它们为演示文稿或其组成部分赋予生命。

### **为什么在演示文稿中使用动画？**

使用动画，你可以

* 控制信息的流动
* 强调重要点
* 增加观众的兴趣或参与度
* 使内容更易于阅读、吸收或处理
* 吸引读者或观众关注演示文稿中的重要部分

PowerPoint 在 **进入**、**退出**、**强调** 和 **运动路径** 类别中提供了许多动画和动画效果的选项和工具。

### **Aspose.Slides 中的动画**

* Aspose.Slides 提供了在 `Aspose.Slides.Animation` 命名空间下处理动画所需的类和类型。
* Aspose.Slides 在 [EffectType](https://reference.aspose.com/slides/java/com.aspose.slides/effecttype) 枚举下提供超过 **150 种动画效果**。这些效果基本上与 PowerPoint 中使用的效果相同（或等效）。

## **应用动画到文本框**

Aspose.Slides for Java 允许你对形状中的文本应用动画。

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 添加一个 `rectangle` [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape)。
4. 将文本添加到 [IAutoShape.TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-)。
5. 获取主效果序列。
6. 将动画效果添加到 [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape)。
7. 将 `TextAnimation.BuildType` 属性设置为来自 `BuildType` 枚举的值。
8. 将演示文稿作为 PPTX 文件写入磁盘。

这段 Java 代码展示了如何将 `Fade` 效果应用到 AutoShape 并将文本动画设置为 *按第一层级段落* 值：

```java
// 实例化一个表示演示文稿文件的演示文稿类。
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // 添加带文本的新 AutoShape
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("第一段 \n第二段 \n 第三段");

    // 获取幻灯片的主序列。
    ISequence sequence = sld.getTimeline().getMainSequence();

    // 为形状添加 Fade 动画效果
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // 以第一级段落的方式动画形状文本
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // 将 PPTX 文件保存到磁盘
    pres.save(path + "AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert color="primary"  %}} 

除了对文本应用动画外，你还可以对单个 [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph) 应用动画。请参见 [**动画文本**](/slides/java/animated-text/)。

{{% /alert %}} 

## **应用动画到图片框**

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 在幻灯片上添加或获取 [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe)。
4. 获取主效果序列。
5. 将动画效果添加到 [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe)。
6. 将演示文稿作为 PPTX 文件写入磁盘。

这段 Java 代码展示了如何将 `Fly` 效果应用到图片框：

```java
// 实例化一个表示演示文稿文件的演示文稿类。
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

    // 将图片框添加到幻灯片
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, picture);

    // 获取幻灯片的主序列。
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // 将从左侧飞入的动画效果添加到图片框
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // 将 PPTX 文件保存到磁盘
    pres.save(path + "AnimImage_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **应用动画到形状**

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 添加一个 `rectangle` [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape)。
4. 添加一个 `Bevel` [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape)（当单击该对象时，动画将播放）。
5. 为斜面形状创建效果序列。
6. 创建一个自定义 `UserPath`。
7. 为移动到 `UserPath` 添加命令。
8. 将演示文稿作为 PPTX 文件写入磁盘。

这段 Java 代码展示了如何将 `PathFootball` 效果应用于形状：

```java
// 实例化一个表示 PPTX 文件的演示文稿类。
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // 从头创建现有形状的 PathFootball 效果。
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("动画文本框");

    // 添加 PathFootBall 动画效果
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // 创建某种“按钮”。
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // 为此按钮创建效果序列。
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // 创建一个自定义用户路径。我们的对象仅在单击按钮后移动。
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

     // 添加移动命令，因为创建的路径是空的。
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

你可以决定找出应用于单个形状的所有动画效果。

这段 Java 代码展示了如何获取应用于特定形状的所有效果：

```java
// 实例化一个表示演示文稿文件的演示文稿类。
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // 获取幻灯片的主序列。
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // 获取幻灯片上的第一个形状。
    IShape shape = firstSlide.getShapes().get_Item(0);

    // 获取应用于形状的所有动画效果。
    IEffect[] shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0)
        System.out.println("该形状 " + shape.getName() + " 有 " + shapeEffects.length + " 个动画效果。");
} finally {
    if (pres != null) pres.dispose();
}
```

## **更改动画效果的计时属性**

Aspose.Slides for Java 允许你更改动画效果的计时属性。

这是 Microsoft PowerPoint 中的动画计时窗格：

![example1_image](shape-animation.png)

这些是 PowerPoint 计时与 [Effect.Timing](https://reference.aspose.com/slides/java/com.aspose.slides/IEffect#getTiming--) 属性之间的对应关系：

- PowerPoint 计时 **开始** 下拉列表与 [Effect.Timing.TriggerType](https://reference.aspose.com/slides/java/com.aspose.slides/ITiming#getTriggerType--) 属性相匹配。
- PowerPoint 计时 **持续时间** 与 [Effect.Timing.Duration](https://reference.aspose.com/slides/java/com.aspose.slides/ITiming#getDuration--) 属性相匹配。动画的持续时间（以秒为单位）是动画完成一个周期所需的总时间。
- PowerPoint 计时 **延迟** 与 [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/java/com.aspose.slides/ITiming#getTriggerDelayTime--) 属性相匹配。

这就是如何更改效果计时属性：

1. [应用](#apply-animation-to-shape) 或获取动画效果。
2. 为所需的 [Effect.Timing](https://reference.aspose.com/slides/java/com.aspose.slides/IEffect#getTiming--) 属性设置新值。
3. 保存修改后的 PPTX 文件。

这段 Java 代码演示了该操作：

```java
// 实例化一个表示演示文稿文件的演示文稿类。
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // 获取幻灯片的主序列。
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // 获取主序列的第一个效果。
    IEffect effect = sequence.get_Item(0);

    // 更改效果 TriggerType 以在单击时启动
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick);

    // 更改效果持续时间
    effect.getTiming().setDuration(3f);

    // 更改效果 TriggerDelayTime
    effect.getTiming().setTriggerDelayTime(0.5f);

    // 将 PPTX 文件保存到磁盘
    pres.save("AnimExample_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **动画效果声音**

Aspose.Slides 提供这些属性以允许你处理动画效果中的声音：

- [setSound(IAudio value)](https://reference.aspose.com/slides/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) 
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/java/com.aspose.slides/effect/#setStopPreviousSound-boolean-) 

### **添加动画效果声音**

这段 Java 代码展示了如何添加动画效果声音，并在下一个效果开始时停止它：

```java
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // 将音频添加到演示文稿音频集合
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // 获取幻灯片的主序列。
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // 获取主序列的第一个效果
    IEffect firstEffect = sequence.get_Item(0);

    // 检查效果是否为“无声音”
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // 为第一个效果添加声音
        firstEffect.setSound(effectSound);
    }

    // 获取幻灯片的第一个交互序列。
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // 设置效果“停止之前声音”标志
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // 将 PPTX 文件写入磁盘
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **提取动画效果声音**

1. 创建 [Presentation](https://reference.aspose.com/slides/java/aspose.slides/presentation/) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 获取效.sequence的主序列。
4. 提取嵌入到每个动画效果中的 [setSound(IAudio value)](https://reference.aspose.com/slides/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)。

这段 Java 代码展示了如何提取嵌入在动画效果中的声音：

```java
// 实例化一个表示演示文稿文件的演示文稿类。
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

## **动画之后**

Aspose.Slides for Java 允许你更改动画效果的“动画之后”属性。

这是 Microsoft PowerPoint 中的动画效果窗格和扩展菜单：

![example1_image](shape-after-animation.png)

PowerPoint 效果 **动画之后** 下拉列表与以下属性相匹配：

- [setAfterAnimationType(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setAfterAnimationType-int-) 属性描述动画之后类型：
  * PowerPoint **更多颜色** 与 [AfterAnimationType.Color](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#Color) 类型相匹配；
  * PowerPoint **不变暗** 列表项与 [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#DoNotDim) 类型相匹配（默认的动画之后类型）；
  * PowerPoint **动画后隐藏** 项与 [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#HideAfterAnimation) 类型相匹配；
  * PowerPoint **在下一个鼠标单击时隐藏** 项与 [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick) 类型相匹配；
- [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) 属性定义动画之后的颜色格式。该属性与 [AfterAnimationType.Color](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#Color) 类型结合使用。如果你将类型更改为其他类型，则动画之后的颜色将被清除。

这段 Java 代码展示了如何更改动画之后的效果：

```java
// 实例化一个表示演示文稿文件的演示文稿类
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // 获取主序列的第一个效果
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // 将动画之后效果类型更改为颜色
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // 设置动画之后效果的淡化颜色
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // 将 PPTX 文件写入磁盘
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **动画文本**

Aspose.Slides 提供这些属性以允许你处理动画效果的 *动画文本* 块：

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) 描述效果的动画文本类型。形状文本可以按以下方式动画化：
  - 一次性（[AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/java/com.aspose.slides/animatetexttype/#AllAtOnce) 类型）
  - 按单词（[AnimateTextType.ByWord](https://reference.aspose.com/slides/java/com.aspose.slides/animatetexttype/#ByWord) 类型）
  - 按字母（[AnimateTextType.ByLetter](https://reference.aspose.com/slides/java/com.aspose.slides/animatetexttype/#ByLetter) 类型）
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) 设置动画文本部分（单词或字母）之间的延迟。正值指定效果持续时间的百分比。负值指定以秒为单位的延迟。

这就是如何更改效果动画文本属性：

1. [应用](#apply-animation-to-shape) 或获取动画效果。
2. 将 [setBuildType(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/itextanimation/#setBuildType-int-) 属性设置为 [BuildType.AsOneObject](https://reference.aspose.com/slides/java/com.aspose.slides/buildtype/#AsOneObject) 值以关闭 *按段落* 动画模式。
3. 为 [setAnimateTextType(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) 和 [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) 属性设置新值。
4. 保存修改后的 PPTX 文件。

这段 Java 代码演示了该操作：

```java
// 实例化一个表示演示文稿文件的演示文稿类。
Presentation pres = new Presentation("AnimTextBox_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // 获取主序列的第一个效果
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // 将效果文本动画类型更改为“作为一个对象”
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // 将效果动画文本类型更改为“按单词”
    firstEffect.setAnimateTextType(AnimateTextType.ByWord);

    // 将单词之间的延迟设置为效果持续时间的 20%
    firstEffect.setDelayBetweenTextParts(20f);

    // 将 PPTX 文件写入磁盘
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```