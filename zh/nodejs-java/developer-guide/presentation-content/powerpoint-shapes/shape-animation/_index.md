---
title: 形状动画
type: docs
weight: 60
url: /zh/nodejs-java/shape-animation/
keywords:
- 形状
- 动画
- 效果
- 添加效果
- 获取效果
- 提取效果
- 应用动画
- PowerPoint
- 演示文稿
- Node.js
- Java
- Aspose.Slides for Node.js via Java
description: "在 JavaScript 中应用 PowerPoint 动画"
---

动画是可以应用于文本、图像、形状或[图表](/slides/zh/nodejs-java/animated-charts/)的视觉效果。它们为演示文稿或其组成部分赋予活力。

## **为什么在演示文稿中使用动画？**

使用动画，您可以

* 控制信息流
* 强调重要要点
* 提高观众的兴趣或参与度
* 使内容更易阅读、吸收或处理
* 吸引读者或观众注意演示文稿中的重要部分

PowerPoint 在 **入口**、**退出**、**强调** 和 **运动路径** 四类中提供了众多动画选项和工具。

## **Aspose.Slides 中的动画**

* Aspose.Slides 在 `Aspose.Slides.Animation` 命名空间下提供了处理动画所需的类和类型，
* Aspose.Slides 在 [EffectType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effecttype) 枚举中提供了超过 **150 种动画效果**。这些效果本质上与 PowerPoint 中使用的效果相同（或等效）。

## **为 TextBox 应用动画**

Aspose.Slides for Node.js via Java 允许您对形状中的文本应用动画。

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片引用。
3. 添加一个 `rectangle` [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape)。
4. 使用 [AutoShape.addTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-) 添加文本。
5. 获取主效果序列。
6. 向 [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape) 添加动画效果。
7. 调用 `TextAnimation.setBuildType` 方法，并使用 `BuildType` 枚举中的值。
8. 将演示文稿写入磁盘为 PPTX 文件。

下面的 Javascript 代码演示如何将 `Fade` 效果应用于 AutoShape 并将文本动画设置为 *By 1st Level Paragraphs* 值：
```javascript
// 实例化一个表示演示文稿文件的 Presentation 类。
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    // 添加带文本的新 AutoShape
    var autoShape = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 100);
    var textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");
    // 获取幻灯片的主序列。
    var sequence = sld.getTimeline().getMainSequence();
    // 为形状添加 Fade 动画效果
    var effect = sequence.addEffect(autoShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    // 按一级段落对形状文本进行动画
    effect.getTextAnimation().setBuildType(aspose.slides.BuildType.ByLevelParagraphs1);
    // 将 PPTX 文件保存到磁盘
    pres.save(path + "AnimText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{%  alert color="primary"  %}} 

除了对文本应用动画外，您还可以对单个[段落](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph)应用动画。参见[**动画文本**](/slides/zh/nodejs-java/animated-text/)。

{{% /alert %}} 

## **为 PictureFrame 应用动画**

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片引用。
3. 在幻灯片上添加或获取一个 [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe)。
4. 获取主效果序列。
5. 向 [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe) 添加动画效果。
6. 将演示文稿写入磁盘为 PPTX 文件。

下面的 Javascript 代码演示如何将 `Fly` 效果应用于图片框：
```javascript
// 实例化一个表示演示文稿文件的 Presentation 类。
var pres = new aspose.slides.Presentation();
try {
    // 加载要添加到演示文稿图像集合的图片
    var picture;
    var image = aspose.slides.Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // 向幻灯片添加图片框
    var picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 100, picture);
    // 获取幻灯片的主序列。
    var sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    // 向图片框添加从左侧飞入动画效果
    var effect = sequence.addEffect(picFrame, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.Left, aspose.slides.EffectTriggerType.OnClick);
    // 将 PPTX 文件保存到磁盘
    pres.save(path + "AnimImage_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **为 Shape 应用动画**

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片引用。
3. 添加一个 `rectangle` [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape)。
4. 添加一个 `Bevel` [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape)（单击此对象时播放动画）。
5. 在斜面形状上创建效果序列。
6. 创建自定义 `UserPath`。
7. 添加移动到 `UserPath` 的命令。
8. 将演示文稿写入磁盘为 PPTX 文件。

下面的 Javascript 代码演示如何将 `PathFootball`（路径足球）效果应用于形状：
```javascript
// 实例化一个表示 PPTX 文件的 Presentation 类。
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    // 为现有形状从头创建 PathFootball 效果。
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");
    // 添加 PathFootBall 动画效果
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, aspose.slides.EffectType.PathFootball, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    // 创建某种“按钮”。
    var shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Bevel, 10, 10, 20, 20);
    // 为此按钮创建一系列效果。
    var seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);
    // 创建自定义用户路径。我们的对象仅在按钮被点击后才会移动。
    var fxUserPath = seqInter.addEffect(ashp, aspose.slides.EffectType.PathUser, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    // 添加移动命令，因为创建的路径为空。
    var motionBhv = fxUserPath.getBehaviors().get_Item(0);
    var pts = java.newArray("com.aspose.slides.Point2DFloat", [java.newInstanceSync("com.aspose.slides.Point2DFloat", 0.076, 0.59)]);
    motionBhv.getPath().add(aspose.slides.MotionCommandPathType.LineTo, pts, aspose.slides.MotionPathPointsType.Auto, true);
    pts[0] = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(-0.076), java.newFloat(-0.59));
    motionBhv.getPath().add(aspose.slides.MotionCommandPathType.LineTo, pts, aspose.slides.MotionPathPointsType.Auto, false);
    motionBhv.getPath().add(aspose.slides.MotionCommandPathType.End, null, aspose.slides.MotionPathPointsType.Auto, false);
    // 将 PPTX 文件写入磁盘
    pres.save("AnimExample_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **获取应用于 Shape 的动画效果**

以下示例演示如何使用 [Sequence](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sequence/) 类的 `getEffectsByShape` 方法获取应用于形状的所有动画效果。

**示例 1：获取普通幻灯片上形状的动画效果**

之前，您已经学习了如何向 PowerPoint 演示文稿中的形状添加动画效果。以下示例代码演示如何获取演示文稿 `AnimExample_out.pptx` 中第一张普通幻灯片上第一个形状所应用的效果。
```javascript
var presentation = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    var firstSlide = presentation.getSlides().get_Item(0);

    // 获取幻灯片的主动画序列。
    var sequence = firstSlide.getTimeline().getMainSequence();

    // 获取第一张幻灯片上的第一个形状。
    var shape = firstSlide.getShapes().get_Item(0);

    // 获取应用于该形状的动画效果。
    var shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0) {
        console.log("The shape", shape.getName(), "has", shapeEffects.length, "animation effects.");
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


**示例 2：获取所有动画效果，包括从占位符继承的效果**

如果普通幻灯片上的形状具有位于布局幻灯片和/或母版幻灯片的占位符，并且这些占位符已添加动画效果，则在幻灯片放映期间，该形状将播放所有效果，包括来自占位符的继承效果。

假设我们有一个 PowerPoint 演示文稿文件 `sample.pptx`，其中只有一张幻灯片，仅包含一个文本为 “Made with Aspose.Slides” 的页脚形状，并对该形状应用了 **Random Bars** 效果。

![Slide shape animation effect](slide-shape-animation.png)

再假设在 **布局** 幻灯片的页脚占位符上应用了 **Split** 效果。

![Layout shape animation effect](layout-shape-animation.png)

最后，在 **母版** 幻灯片的页脚占位符上应用了 **Fly In** 效果。

![Master shape animation effect](master-shape-animation.png)

以下示例代码演示如何使用 [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) 类的 `getBasePlaceholder` 方法访问形状占位符，并获取应用于页脚形状的动画效果，包括来自布局和母版幻灯片上占位符的继承效果。
```js
var presentation = new aspose.slides.Presentation("sample.pptx");

var slide = presentation.getSlides().get_Item(0);

// 获取普通幻灯片上形状的动画效果。
var shape = slide.getShapes().get_Item(0);
var shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// 获取布局幻灯片上占位符的动画效果。
var layoutShape = shape.getBasePlaceholder();
var layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// 获取母版幻灯片上占位符的动画效果。
var masterShape = layoutShape.getBasePlaceholder();
var masterShapeEffects = slide.getLayoutSlide().getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(masterShape);

console.log("Main sequence of shape effects:");
printEffects(masterShapeEffects);
printEffects(layoutShapeEffects);
printEffects(shapeEffects);

presentation.dispose();
```

```js
function printEffects(effects) {
    for (const effect of effects) {
        console.log("Type:", effect.getType() + ", subtype:", effect.getSubtype());
    }
}
```


Output:
```text
Main sequence of shape effects:
Type: 47, subtype: 2              // 飞入, 底部
Type: 134, subtype: 45            // 拆分, 垂直进入
Type: 126, subtype: 22            // 随机条形, 水平
```


## **更改动画效果的时间属性**

Aspose.Slides for Node.js via Java 允许您更改动画效果的 Timing（时间）属性。

这是一张 Microsoft PowerPoint 中的动画时间窗格：

![example1_image](shape-animation.png)

以下是 PowerPoint 时间与 [Effect.Timing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Effect#getTiming--) 属性之间的对应关系：

- PowerPoint 时间 **Start** 下拉列表对应 [Effect.Timing.TriggerType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Timing#getTriggerType--) 属性。
- PowerPoint 时间 **Duration** 对应 [Effect.Timing.Duration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Timing#getDuration--) 属性。动画的持续时间（以秒为单位）是动画完成一个循环所需的总时间。
- PowerPoint 时间 **Delay** 对应 [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Timing#getTriggerDelayTime--) 属性。

以下是更改 Effect Timing（效果时间）属性的方法：

1. [Apply](#apply-animation-to-shape) 或获取动画效果。
2. 为所需的 [Effect.Timing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Effect#getTiming--) 属性设置新值。
3. 保存修改后的 PPTX 文件。

下面的 Javascript 代码演示此操作：
```javascript
// 实例化一个表示演示文稿文件的 Presentation 类。
var pres = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    // 获取幻灯片的主序列。
    var sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    // 获取主序列的第一个效果。
    var effect = sequence.get_Item(0);
    // 将效果的 TriggerType 更改为单击开始
    effect.getTiming().setTriggerType(aspose.slides.EffectTriggerType.OnClick);
    // 更改效果的持续时间
    effect.getTiming().setDuration(3.0);
    // 更改效果的触发延迟时间
    effect.getTiming().setTriggerDelayTime(0.5);
    // 将 PPTX 文件保存到磁盘
    pres.save("AnimExample_changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **动画效果声音**

Aspose.Slides 提供以下属性，以便在动画效果中使用声音：

- [setSound(IAudio value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effect/#setSound-aspose.slides.IAudio-)
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effect/#setStopPreviousSound-boolean-)

### **添加动画效果声音**

下面的 Javascript 代码演示如何为动画效果添加声音，并在下一个效果开始时停止它：
```javascript
var pres = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    // 将音频添加到演示文稿的音频集合
    var effectSound = pres.getAudios().addAudio(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "sampleaudio.wav")));
    var firstSlide = pres.getSlides().get_Item(0);
    // 获取幻灯片的主序列。
    var sequence = firstSlide.getTimeline().getMainSequence();
    // 获取主序列的第一个效果
    var firstEffect = sequence.get_Item(0);
    // 检查效果是否为“无声音”
    if ((!firstEffect.getStopPreviousSound()) && (firstEffect.getSound() == null)) {
        // 为第一个效果添加声音
        firstEffect.setSound(effectSound);
    }
    // 获取幻灯片的第一个交互序列。
    var interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);
    // 设置效果的“停止先前声音”标志
    interactiveSequence.get_Item(0).setStopPreviousSound(true);
    // 将 PPTX 文件写入磁盘
    pres.save("AnimExample_Sound_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **提取动画效果声音**

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 类的实例。
2. 通过索引获取幻灯片引用。
3. 获取主效果序列。
4. 提取嵌入到每个动画效果中的 [setSound(IAudio value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effect/#setSound-aspose.slides.IAudio-) 声音。

下面的 Javascript 代码演示如何提取嵌入到动画效果中的声音：
```javascript
// 实例化一个表示演示文稿文件的 Presentation 类。
var presentation = new aspose.slides.Presentation("EffectSound.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    // 获取幻灯片的主序列。
    var sequence = slide.getTimeline().getMainSequence();
    for (var i = 0; i < sequence.getCount(); i++) {
        var effect = sequence.get_Item(i);
        if (effect.getSound() == null) {
            continue;
        }
        // 提取效果声音的字节数组
        var audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **动画结束后**

Aspose.Slides for Node.js via Java 允许您更改动画效果的 After animation（动画结束后）属性。

这是 Microsoft PowerPoint 中的 Animation Effect（动画效果）窗格及其扩展菜单：

![example1_image](shape-after-animation.png)

PowerPoint Effect **After animation** 下拉列表对应以下属性：

- [setAfterAnimationType(int value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effect/#setAfterAnimationType-int-) 方法用于描述动画结束后的类型；
  * PowerPoint **More Colors** 对应 [AfterAnimationType.Color](https://reference.aspose.com/slides/nodejs-java/aspose.slides/afteranimationtype/#Color) 类型；
  * PowerPoint **Don't Dim** 列表项对应 [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/nodejs-java/aspose.slides/afteranimationtype/#DoNotDim) 类型（默认的动画结束后类型）；
  * PowerPoint **Hide After Animation** 项对应 [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/afteranimationtype/#HideAfterAnimation) 类型；
  * PowerPoint **Hide on Next Mouse Click** 项对应 [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/afteranimationtype/#HideOnNextMouseClick) 类型；
- [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effect/#setAfterAnimationColor-aspose.slides.IColorFormat-) 方法用于定义动画结束后的颜色格式。此方法需与 [AfterAnimationType.Color](https://reference.aspose.com/slides/nodejs-java/aspose.slides/afteranimationtype/#Color) 类型配合使用。如果将类型更改为其他类型，动画结束后的颜色将被清除。

下面的 Javascript 代码演示如何更改动画结束后的效果：
```javascript
// 实例化一个表示演示文稿文件的 Presentation 类
var pres = new aspose.slides.Presentation("AnimImage_out.pptx");
try {
    var firstSlide = pres.getSlides().get_Item(0);
    // 获取主序列的第一个效果
    var firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);
    // 将 after animation 类型更改为 Color
    firstEffect.setAfterAnimationType(aspose.slides.AfterAnimationType.Color);
    // 设置 after animation 的暗淡颜色
    firstEffect.getAfterAnimationColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    // 将 PPTX 文件写入磁盘
    pres.save("AnimImage_AfterAnimation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **动画文本**

Aspose.Slides 提供以下属性，以便在动画效果的 *Animate text*（动画文本）块中使用：

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effect/#setAnimateTextType-int-) 方法用于描述效果的 Animate text（动画文本）类型。形状文本可以按以下方式进行动画：
  - 一次性全部显示（[AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/nodejs-java/aspose.slides/animatetexttype/#AllAtOnce)）
  - 按字词显示（[AnimateTextType.ByWord](https://reference.aspose.com/slides/nodejs-java/aspose.slides/animatetexttype/#ByWord)）
  - 按字母显示（[AnimateTextType.ByLetter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/animatetexttype/#ByLetter)）
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effect/#setDelayBetweenTextParts-float-) 方法设置动画文本部分（字词或字母）之间的延迟。正值表示效果持续时间的百分比，负值表示以秒为单位的延迟。

以下是更改 Effect Animate text（效果动画文本）属性的方法：

1. [Apply](#apply-animation-to-shape) 或获取动画效果。
2. 将 `setBuildType(int value)` 方法设置为 `BuildType.AsOneObject` 值，以关闭 *By Paragraphs* 动画模式。
3. 为 `setAnimateTextType(int value)` 和 `setDelayBetweenTextParts(float value)` 属性设置新值。
4. 保存修改后的 PPTX 文件。

下面的 Javascript 代码演示此操作：
```javascript
// 实例化一个表示演示文稿文件的 Presentation 类。
var pres = new aspose.slides.Presentation("AnimTextBox_out.pptx");
try {
    var firstSlide = pres.getSlides().get_Item(0);
    // 获取主序列的第一个效果
    var firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);
    // 将效果的文本动画类型更改为 “As One Object”
    firstEffect.getTextAnimation().setBuildType(aspose.slides.BuildType.AsOneObject);
    // 将效果的动画文本类型更改为 “By word”
    firstEffect.setAnimateTextType(aspose.slides.AnimateTextType.ByWord);
    // 将单词之间的延迟设置为效果持续时间的 20%
    firstEffect.setDelayBetweenTextParts(20.0);
    // 将 PPTX 文件写入磁盘
    pres.save("AnimTextBox_AnimateText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **常见问题**

**如何确保在将演示文稿发布到网页时保留动画？**

[Export to HTML5](/slides/zh/nodejs-java/export-to-html5/) 并启用负责 [shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/setanimateshapes/) 和 [transition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/setanimatetransitions/) 动画的 [options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/)。普通的 HTML 无法播放幻灯片动画，而 HTML5 可以。

**更改形状的 Z 顺序（图层顺序）如何影响动画？**

动画顺序和绘制顺序是独立的：效果控制出现/消失的时间和类型，而 [z-order](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getzorderposition/) 决定哪个在上层。可见的结果由二者的组合决定。（这是 PowerPoint 的通用行为，Aspose.Slides 的效果与形状模型遵循相同的逻辑。）

**将动画转换为视频时对某些效果是否有限制？**

一般情况下，[动画受支持](/slides/zh/nodejs-java/convert-powerpoint-to-video/)，但在少数情况或特定效果下可能呈现不同。建议使用您所用的效果以及相应的库版本进行测试。