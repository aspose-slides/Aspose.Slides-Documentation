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
description: "使用 Aspose.Slides for Node.js via Java 应用幻灯片切换、配置自动幻灯片推进，并自定义 Morph 等切换效果。"
---
## **概述**

幻灯片切换用于控制幻灯片在放映过程中的出现方式。使用 Aspose.Slides for Node.js via Java，您可以为每张幻灯片选择切换效果、配置鼠标点击或计时器推进方式，并调整特定于某种效果的选项。本文通过 JavaScript 示例演示如何应用切换、设置精确的切换时长、管理幻灯片计时以及在两张幻灯片之间创建 Morph 切换。示例还展示了如何将设置保存为 PPTX 文件。

## **添加幻灯片切换**

要应用切换，请使用 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 类加载演示文稿，并通过 [getSlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) 访问幻灯片的切换设置。使用 [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) 并从 [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) 枚举中选择值，然后保存演示文稿。

以下示例对第一张幻灯片应用 Circle 切换，对第二张幻灯片应用 Comb 切换。请使用至少包含两张幻灯片的 `input.pptx` 文件。

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

## **轮转切换**

[WheelTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/wheeltransition/) 的 [setSpokes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/wheeltransition/#setSpokes) 方法用于控制显示目标幻灯片的径向扇区数。先使用 [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) 将幻灯片的切换类型设置为 Wheel（来自 [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/)），然后通过 [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getValue) 获取为 [WheelTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/wheeltransition/)。

此示例创建两对相同的幻灯片：一张黑色幻灯片后跟一张带有金色矩形的幻灯片。目标幻灯片的扇区计数分别为 1 和 8，速度通过 [setSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) 设置相同，且通过 [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) 明确设为 8000 毫秒，以便轻松观察差异。

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slideWidth = presentation.getSlideSize().getSize().getWidth();
    const slideHeight = presentation.getSlideSize().getSize().getHeight();

    const blackSlide = presentation.getSlides().get_Item(0);
    blackSlide.getShapes().clear();
    blackSlide.getBackground().setType(java.newByte(slides.BackgroundType.OwnBackground));
    blackSlide.getBackground().getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
    const black = java.newInstanceSync("java.awt.Color", 0, 0, 0);
    blackSlide.getBackground().getFillFormat().getSolidFillColor().setColor(black);

    const destinationSlide = presentation.getSlides().addClone(blackSlide);
    const rectangle = destinationSlide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 0, 0, slideWidth, slideHeight);
    rectangle.getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
    const gold = java.newInstanceSync("java.awt.Color", 255, 215, 0);
    rectangle.getFillFormat().getSolidFillColor().setColor(gold);
    rectangle.getTextFrame().setText("Wheel transition");

    presentation.getSlides().addClone(blackSlide);
    presentation.getSlides().addClone(destinationSlide);

    const spokeCounts = [1, 8];
    for (let i = 0; i < spokeCounts.length; i++) {
        const transition = presentation.getSlides().get_Item(i * 2 + 1).getSlideShowTransition();
        transition.setType(slides.TransitionType.Wheel);
        const wheelTransition = transition.getValue();
        wheelTransition.setSpokes(java.newLong(spokeCounts[i]));
        transition.setSpeed(slides.TransitionSpeed.Slow);
        transition.setDuration(8000);
    }

    presentation.save("wheel-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

在 PowerPoint 中打开输出演示文稿并运行放映。从幻灯片 1 前进到幻灯片 2，然后从幻灯片 3 前进到幻灯片 4。在 PowerPoint 播放中，扇区计数为 1 时会以一次顺时针扫过的方式显示幻灯片；计数为 8 时则会同时通过八个径向扇区显示。目标内容和切换时长相同，唯一的区别在于显示扇区的数量。

## **使用 Reveal 切换实现淡入黑色**

将目标幻灯片的切换类型设置为 Reveal，然后在其 [RevealTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/revealtransition/) 设置上调用 [setThroughBlack](https://reference.aspose.com/slides/nodejs-java/aspose.slides/revealtransition/#setThroughBlack)。本例创建一张青绿色源幻灯片和一张珊瑚色目标幻灯片，并对两者进行克隆。每对幻灯片均使用相同的两秒 Reveal 切换，仅第二对在切换时淡入黑色。

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const source = presentation.getSlides().get_Item(0);
    const destination = presentation.getSlides().addClone(source);
    const teal = java.newInstanceSync("java.awt.Color", 0, 128, 128);
    const coral = java.newInstanceSync("java.awt.Color", 255, 127, 80);

    for (const [slide, color, label] of [[source, teal, "Source"], [destination, coral, "Destination"]]) {
        slide.getBackground().setType(java.newByte(slides.BackgroundType.OwnBackground));
        const fill = slide.getBackground().getFillFormat();
        fill.setFillType(java.newByte(slides.FillType.Solid));
        fill.getSolidFillColor().setColor(color);

        const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 160, 180, 400, 130);
        const textFrame = shape.getTextFrame();
        textFrame.setText(label);
        textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setFontHeight(44);
    }

    presentation.getSlides().addClone(source);
    const clonedDestination = presentation.getSlides().addClone(destination);
    for (const slide of [destination, clonedDestination]) {
        const transition = slide.getSlideShowTransition();
        transition.setType(slides.TransitionType.Reveal);
        transition.setSpeed(slides.TransitionSpeed.Slow);
        transition.setDuration(2000);

        const reveal = transition.getValue();
        reveal.setDirection(slides.TransitionLeftRightDirectionType.Left);
        reveal.setThroughBlack(slide === clonedDestination);
    }

    presentation.save("reveal-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

在 PowerPoint 中打开保存的演示文稿并启动放映。从幻灯片 1 前进到幻灯片 2，可看到青绿色直接淡入珊瑚色。然后从幻灯片 3 前进到幻灯片 4，屏幕会短暂变暗至接近黑色后再显示珊瑚色幻灯片。两对幻灯片的原始背景颜色保持不变。

下表展示了 PowerPoint 每隔半秒截取的一帧画面。比较每行的中间帧即可看到效果差异。

![PowerPoint 播放时禁用淡入黑色（上）和启用淡入黑色（下）的对比。仅下行通过接近黑色。](reveal-through-black.png)

## **添加高级幻灯片切换**

您可以配置幻灯片在屏幕上停留的时长以及是否通过鼠标点击推进放映。以下方法控制此行为：

- [setAdvanceOnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) 允许观看者通过点击鼠标推进。
- [setAdvanceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) 启用自动推进。
- [setAdvanceAfterTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) 指定自动推进前的延迟，单位为毫秒。

可同时启用点击和计时推进，使观看者可以点击前进或等待计时器。若仅使用计时器，请向 [setAdvanceOnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) 传入 `false`。延迟决定何时自动推进，而不是视觉切换效果的时长。

本示例为前三张幻灯片分别分配不同的切换效果，并在 3、5、7 秒后自动推进。鼠标点击同样可以推进这些幻灯片。请使用至少包含三张幻灯片的 `input.pptx` 文件。

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

要检查是否启用了计时推进，请调用 [getAdvanceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getAdvanceAfter)。仅存储的延迟并不表示计时器已激活。

下面的示例打开上面保存的文件，报告每个已启用的计时器，并对延迟超过两秒的幻灯片禁用自动推进。随后为这些幻灯片重新启用鼠标点击并保存更新后的设置。

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

## **精确控制切换时长**

使用 [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) 可在毫秒级别指定切换效果的精确长度。幻灯片的 [getSlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) 方法通过 [SlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/) 暴露这些设置：

| 方法 | 用途 |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) | 设置切换效果本身的时长，单位为毫秒。 |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | 设置幻灯片自动推进前的延迟，单位为毫秒。需将 `true` 传给 [setAdvanceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) 才会激活计时器。 |
| [setSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) | 从 [TransitionSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionspeed/) 枚举中选择预定义的速度类别：Slow、Medium 或 Fast。未指定精确时长时使用该设置。 |

[setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) 仅控制切换效果本身；它不决定幻灯片在屏幕上停留的时长。请单独配置自动推进的延迟。当未设置显式时长时，Aspose.Slides 会根据切换类型和 [getSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getSpeed) 的值推算效果时长。

<!-- visual-explanation:slide-transition:start -->
[![单独的条形标识 750 ms 的切换时长和 5,000 ms 的自动推进设置。](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*共享示例为每张幻灯片设置 750 ms 的淡入切换，并单独在 5,000 ms 后启用自动推进。切换时长控制视觉效果，自动推进控制离开幻灯片的时机。这些条形是示意设置，而非实际测量的合并时间轴。*
<!-- visual-explanation:slide-transition:end -->

### **为每张幻灯片应用相同的时长**

为了保持节奏一致，可为每张幻灯片使用相同的效果和精确时长。此示例加载 `input.pptx`，从 [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) 中选择 Fade，并为每个切换设置 750 毫秒的时长。随后单独在 5,000 毫秒后启用自动推进，并禁用鼠标点击推进，最后保存为 PPTX。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();
        transition.setType(slides.TransitionType.Fade);
        transition.setDuration(750);

        // 配置自动推进，独立于效果时长。
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

不同的幻灯片可以使用不同的效果时长。例如，可为标题幻灯片使用较短的切换，为章节导入幻灯片使用稍长的切换。此示例为第一张幻灯片设为 500 毫秒，为第二张设为 1,200 毫秒。请使用至少包含两张幻灯片的 `input.pptx` 文件。

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

### **与动画输出协同切换**

在准备 [animated GIF](/slides/zh/nodejs-java/convert-powerpoint-to-animated-gif/)、[HTML5 演示](/slides/zh/nodejs-java/export-to-html5/) 或 [视频](/slides/zh/nodejs-java/convert-powerpoint-to-video/) 时，请在导出前设置精确的切换时长，以匹配预期的节奏。例如，可在场景之间使用 600 毫秒的淡入，并为每张幻灯片分别设置推进延迟，以留出旁白或内容的播放时间。

对于 GIF 与视频，需要将输出帧率与效果时长对应：600 毫秒相当于 30 fps 下的 18 帧。对于 HTML5，请在导出设置中启用动画切换。请检查所选导出格式支持的效果和计时选项，并预览输出以确认同步情况。

### **读取已存在的切换时长**

在修改切换之前调用 [getDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getDuration) 可以判断是否存有显式值。返回 `-1` 表示未设置显式时长；非负值表示已存储的时长（毫秒）。未设置的值并非计算得到的播放时长：Aspose.Slides 会根据切换类型和 [getSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getSpeed) 计算时长。设置切换类型可能会初始化时长，因此请先检查原始设置。

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

Morph 切换在连续幻灯片之间对对象的变化进行动画化。要创建简单的 Morph 效果，先克隆幻灯片，在克隆上移动或调整对象大小，然后对第二张幻灯片应用 Morph 切换。这样对应的对象将在原始状态与修改后状态之间进行动画。

下面的示例创建一张包含文本矩形的幻灯片，克隆该幻灯片并在克隆上更改矩形的位置和大小。随后为第二张幻灯片从 [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) 枚举中选择 Morph。请在支持 Morph 的演示查看器中打开保存的文件，以在放映时查看效果。

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

[TransitionMorphType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/) 枚举控制 Morph 匹配和动画内容的方式：

- [ByObject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/#ByObject) 将每个形状视为整体对象。
- [ByWord](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/#ByWord) 在可能的情况下按单词匹配文本并进行动画。
- [ByChar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/#ByChar) 在可能的情况下按字符匹配文本并进行动画。

使用 [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) 选取 Morph，然后再访问 [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getValue)。随后得到的 [MorphTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/morphtransition/) 对象可通过其 [setMorphType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/morphtransition/#setMorphType) 方法选择匹配模式。

本示例打开前一节创建的演示文稿，并将第二张幻灯片配置为基于单词的 Morph 动画。

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

某些切换会公开额外选项，例如方向或是否从黑屏开始。可用选项取决于使用 [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) 选定的切换类型。请先设置类型，然后通过 [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getValue) 获取相应的切换对象并使用。

下面的示例对 `input.pptx` 的第一张幻灯片应用 Cut 切换。它通过 [OptionalBlackTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/optionalblacktransition/) 的 [setFromBlack](https://reference.aspose.com/slides/nodejs-java/aspose.slides/optionalblacktransition/#setFromBlack) 方法，使切换从黑屏开始。

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

**我能控制幻灯片切换的播放速度吗？**

可以。当需要毫秒级的精确时长时，请优先使用 [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration)。如果预定义的 [TransitionSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionspeed/)（Slow、Medium、Fast）已经足够且未设置显式时长，则使用 [setSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSpeed)。

**我可以为切换附加音频并使其循环吗？**

可以。使用 [setSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSound) 赋予嵌入音频，向 [setSoundMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSoundMode) 传入来自 [TransitionSoundMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionsoundmode/) 枚举的 StartSound，并通过将 [setSoundLoop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSoundLoop) 设为 `true` 启用循环。音频将在下一次声音事件出现前一直循环。

**将相同切换应用于每张幻灯片的最快方式是什么？**

遍历演示文稿的 [getSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlides) 集合，在循环中对每张幻灯片的切换调用 [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) 并传入相同的值。可在同一循环中设置计时和效果选项，以确保所有幻灯片行为一致。

**我如何检查幻灯片当前设置了哪种切换？**

对幻灯片的 [getSlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) 结果调用 [getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getType)。它返回 [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) 枚举中的一个值；若为 None，则表示未应用任何切换效果。