---
title: 使用 JavaScript 管理演示文稿中的幻灯片切换
linktitle: 幻灯片切换
type: docs
weight: 80
url: /zh/nodejs-java/slide-transition/
keywords:
  - 幻灯片切换
  - 添加幻灯片切换
  - 应用幻灯片切换
  - 高级幻灯片切换
  - Morph 切换
  - 切换类型
  - 切换效果
  - PowerPoint
  - OpenDocument
  - 演示文稿
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "使用 Aspose.Slides for Node.js via Java 应用幻灯片切换、配置自动幻灯片前进，并自定义 Morph 及其他切换效果。"
---
## **概述**

幻灯片切换控制幻灯片在放映期间的出现方式。使用 Aspose.Slides for Node.js via Java，您可以为每张幻灯片选择切换效果，配置通过鼠标单击或计时器进行的切换，并调整针对特定效果的选项。本文使用 JavaScript 示例来应用切换、设置精确的切换时长、管理幻灯片计时，并在两张幻灯片之间创建 Morph 切换。示例还展示了如何将设置保存为 PPTX 文件。

## **添加幻灯片切换**

要应用切换，使用 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 类加载演示文稿，并通过 [getSlideShowTransition](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) 访问幻灯片的切换设置。使用来自 [TransitionType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/transitiontype/) 枚举的值调用 [setType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slideshowtransition/#setType)，然后保存演示文稿。

下面的示例对第一张幻灯片应用 Circle 切换，对第二张幻灯片应用 Comb 切换。请使用至少包含两张幻灯片的 `input.pptx` 文件。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        presentation.getSlides().get_Item(0).getSlideShowTransition().setType(slides.TransitionType.Circle);
        presentation.getSlides().get_Item(1).getSlideShowTransition().setType(slides.TransitionType.Comb);

        presentation.save("slide-transitions.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **添加高级幻灯片切换**

您可以配置幻灯片在屏幕上的停留时长以及是否通过鼠标单击推进放映。以下方法控制此行为：

- [setAdvanceOnClick](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) 允许观众通过单击鼠标来推进。
- [setAdvanceAfter](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) 启用自动推进。
- [setAdvanceAfterTime](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) 指定自动推进前的延迟，以毫秒为单位。

同时启用点击和计时推进，使观众可以通过点击继续或等待计时器。若仅使用计时器，请向 [setAdvanceOnClick](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) 传递 `false`。延迟决定放映何时推进；它不设置视觉切换效果的时长。

此示例为前三张幻灯片分配不同的效果，并分别在 3、5、7 秒后启用自动推进。鼠标单击也可以推进这些幻灯片。请使用至少包含三张幻灯片的 `input.pptx` 文件。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 3) {
        const firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(slides.TransitionType.Circle);
        firstTransition.setAdvanceOnClick(true);
        firstTransition.setAdvanceAfter(true);
        firstTransition.setAdvanceAfterTime(3000);

        const secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(slides.TransitionType.Comb);
        secondTransition.setAdvanceOnClick(true);
        secondTransition.setAdvanceAfter(true);
        secondTransition.setAdvanceAfterTime(5000);

        const thirdTransition = presentation.getSlides().get_Item(2).getSlideShowTransition();
        thirdTransition.setType(slides.TransitionType.Zoom);
        thirdTransition.setAdvanceOnClick(true);
        thirdTransition.setAdvanceAfter(true);
        thirdTransition.setAdvanceAfterTime(7000);

        presentation.save("advanced-transitions.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The input presentation must contain at least three slides.");
    }
} finally {
    presentation.dispose();
}
```

要检查是否启用了计时推进，请调用 [getAdvanceAfter](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slideshowtransition/#getAdvanceAfter)。单独存储的延迟并不表示计时器已激活。

下面的示例打开上述保存的文件，报告每个已启用的计时器，并对延迟超过两秒的幻灯片禁用自动推进。为这些幻灯片启用鼠标单击并保存更新后的设置。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("advanced-transitions.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();

        if (transition.getAdvanceAfter()) {
            console.log("Slide " + slide.getSlideNumber() + ": advance after " + transition.getAdvanceAfterTime() + " ms.");

            if (transition.getAdvanceAfterTime() > 2000) {
                transition.setAdvanceAfter(false);
                transition.setAdvanceOnClick(true);
            }
        }
    }

    presentation.save("adjusted-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **精确控制切换时机**

使用 [setDuration](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slideshowtransition/#setDuration) 可以指定切换效果的精确时长（单位为毫秒）。幻灯片的 [getSlideShowTransition](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) 方法通过 [SlideShowTransition](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slideshowtransition/) 公开这些设置：

| 方法 | 目的 |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slideshowtransition/#setDuration) | 设置切换效果本身的时长，单位为毫秒。 |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | 设置幻灯片自动推进前的延迟，单位为毫秒。向 [setAdvanceAfter](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) 传递 `true` 以激活此计时器。 |
| [setSpeed](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) | 从 [TransitionSpeed](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/transitionspeed/) 中选择预定义的速度类别：Slow、Medium 或 Fast。当未指定精确时长时使用该设置。 |

[setDuration] 仅控制切换效果本身；它不决定幻灯片的可见时长。自动推进的延迟需单独配置。当未设置显式时长时，Aspose.Slides 会根据切换类型和 [getSpeed](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slideshowtransition/#getSpeed) 的值来确定效果时长。

### **为每张幻灯片应用相同的时长**

为保持一致的节奏，对每张幻灯片应用相同的效果和精确时长。此示例加载 `input.pptx`，从 [TransitionType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/transitiontype/) 中选择 Fade，并为每个切换设置 750 毫秒的时长。它分别在 5,000 毫秒后启用自动推进，并禁用鼠标单击推进，然后将结果保存为 PPTX。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();
        transition.setType(slides.TransitionType.Fade);
        transition.setDuration(750);

        // 配置自动推进，使其独立于效果时长。
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **为单个幻灯片设置不同的时长**

不同的幻灯片可以使用不同的效果时长。例如，对标题幻灯片使用较短的切换，对章节介绍使用较长的切换。此示例为第一张幻灯片设置 500 毫秒，为第二张幻灯片设置 1,200 毫秒。请使用至少包含两张幻灯片的 `input.pptx` 文件。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        const firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(slides.TransitionType.Fade);
        firstTransition.setDuration(500);

        const secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(slides.TransitionType.Push);
        secondTransition.setDuration(1200);

        presentation.save("individual-transition-durations.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

### **将切换与动画输出协调**

在准备 [animated GIF](/slides/zh/nodejs-java/convert-powerpoint-to-animated-gif/)、[HTML5 演示](/slides/zh/nodejs-java/export-to-html5/) 或 [视频](/slides/zh/nodejs-java/convert-powerpoint-to-video/) 时，导出前请设置精确的切换时长以匹配预期的节奏。例如，在场景之间使用 600 毫秒的淡入淡出，并分别调整每张幻灯片的推进延迟，以留出旁白或内容的时间。

对于 GIF 和视频，需要将输出帧率与效果时长相匹配：600 毫秒对应 30 帧每秒时的 18 帧。在 HTML5 中，在导出设置中启用动画切换。检查所选导出格式支持的效果和时机选项，并预览输出以确认同步。

### **读取已有的切换时长**

在修改切换前调用 [getDuration](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slideshowtransition/#getDuration) 以确定是否存有显式值。值为 `-1` 表示未设置显式时长；非负值表示以毫秒为单位的存储时长。未设置的值并非计算后的播放时长：Aspose.Slides 会根据切换类型和 [getSpeed](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slideshowtransition/#getSpeed) 的值来确定该时长。设置切换类型可能会初始化时长，因此请先检查原始设置。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();
        const duration = transition.getDuration();

        if (duration >= 0) {
            console.log("Slide " + slide.getSlideNumber() + ": stored transition duration is " + duration + " ms.");
        } else {
            console.log("Slide " + slide.getSlideNumber() + ": no explicit duration; timing depends on transition type " + transition.getType() + " and speed " + transition.getSpeed() + ".");
        }
    }
} finally {
    presentation.dispose();
}
```

## **Morph 切换**

Morph 切换在连续幻灯片的对象之间动画化变化。要创建简单的 Morph 效果，复制一张幻灯片，在副本上移动或调整对象大小，然后对第二张幻灯片应用 Morph。这样切换会为对应的对象在原始状态和修改后状态之间进行动画。

下面的示例创建包含文字矩形的幻灯片，克隆该幻灯片，并在克隆上更改矩形的位置和大小。随后为第二张幻灯片从 [TransitionType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/transitiontype/) 枚举中选择 Morph。使用支持 Morph 的演示文稿查看器打开保存的文件，即可在放映时看到效果。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const rectangle = firstSlide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 400, 100);
    rectangle.getTextFrame().setText("Morph transition");

    const secondSlide = presentation.getSlides().addClone(firstSlide);
    const movedRectangle = secondSlide.getShapes().get_Item(0);
    movedRectangle.setX(movedRectangle.getX() + 100);
    movedRectangle.setY(movedRectangle.getY() + 50);
    movedRectangle.setWidth(movedRectangle.getWidth() - 200);
    movedRectangle.setHeight(movedRectangle.getHeight() - 10);

    secondSlide.getSlideShowTransition().setType(slides.TransitionType.Morph);

    presentation.save("morph-transition.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Morph 切换类型**

[TransitionMorphType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/transitionmorphtype/) 枚举控制 Morph 如何匹配并动画化内容：

- [ByObject](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/transitionmorphtype/#ByObject) 将每个形状视为整体对象。
- [ByWord](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/transitionmorphtype/#ByWord) 在可能的情况下按单词匹配文本进行动画化。
- [ByChar](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/transitionmorphtype/#ByChar) 在可能的情况下按字符匹配文本进行动画化。

在访问 [getValue](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slideshowtransition/#getValue) 之前使用 [setType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slideshowtransition/#setType) 选择 Morph。该值随后提供一个 [MorphTransition](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/morphtransition/) 对象，其 [setMorphType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/morphtransition/#setMorphType) 方法用于选择匹配模式。

此示例打开前一节创建的演示文稿，并将第二张幻灯片配置为使用基于单词的 Morph 动画。

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("morph-transition.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        const transition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        transition.setType(slides.TransitionType.Morph);
        const transitionValue = transition.getValue();

        if (java.instanceOf(transitionValue, "com.aspose.slides.IMorphTransition")) {
            transitionValue.setMorphType(slides.TransitionMorphType.ByWord);
            presentation.save("morph-by-word.pptx", slides.SaveFormat.Pptx);
        } else {
            console.log("Morph transition options are unavailable.");
        }
    } else {
        console.log("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **设置切换效果**

某些切换提供额外选项，如方向或是否从黑屏开始。可用选项取决于使用 [setType] 选择的切换。首先设置类型，然后从 [getValue] 获取相应的切换对象。

下面的示例对 `input.pptx` 的第一张幻灯片应用 Cut 切换。它通过 [OptionalBlackTransition](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/optionalblacktransition/) 调用 [setFromBlack](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/optionalblacktransition/#setFromBlack)，使切换从黑屏开始。

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const transition = presentation.getSlides().get_Item(0).getSlideShowTransition();
    transition.setType(slides.TransitionType.Cut);
    const transitionValue = transition.getValue();

    if (java.instanceOf(transitionValue, "com.aspose.slides.IOptionalBlackTransition")) {
        transitionValue.setFromBlack(true);
        presentation.save("cut-from-black.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("Cut transition options are unavailable.");
    }
} finally {
    presentation.dispose();
}
```

## **常见问题**

**我可以控制幻灯片切换的播放速度吗？**

可以。当需要以毫秒为单位的精确效果时长时，推荐使用 [setDuration](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slideshowtransition/#setDuration)。如果预定义的 [TransitionSpeed](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/transitionspeed/)（Slow、Medium 或 Fast）类别已足够且未设置显式时长，则使用 [setSpeed](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slideshowtransition/#setSpeed)。这些设置独立于自动推进延迟，专门控制切换效果。

**我可以为切换附加音频并使其循环吗？**

可以。使用 [setSound](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slideshowtransition/#setSound) 分配嵌入的音频，将 [TransitionSoundMode](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/transitionsoundmode/) 枚举中的 StartSound 传递给 [setSoundMode](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slideshowtransition/#setSoundMode)，并将 [setSoundLoop](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slideshowtransition/#setSoundLoop) 设置为 `true`。音频将在幻灯片放映中循环播放，直至出现下一个声音事件。

**将相同的切换快速应用于每张幻灯片的最快方法是什么？**

遍历演示文稿的 [getSlides](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/#getSlides) 集合，对每张幻灯片的切换调用相同的 [setType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slideshowtransition/#setType) 值。将在同一循环中设置所有计时和效果选项，以保持跨幻灯片行为的一致性。

**我如何检查幻灯片当前设置的切换类型？**

对幻灯片的 [getSlideShowTransition](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) 结果调用 [getType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slideshowtransition/#getType)。它返回 [TransitionType](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/transitiontype/) 枚举中的值；None 表示未应用任何切换效果。