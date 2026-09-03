---
title: 在 Android 上管理演示文稿中的幻灯片切换
linktitle: 幻灯片切换
type: docs
weight: 80
url: /zh/androidjava/slide-transition/
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
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java，应用幻灯片切换，配置自动幻灯片推进，并自定义 Morph 及其他切换效果。"
---
## **概述**

幻灯片切换控制幻灯片放映期间幻灯片的出现方式。使用 Aspose.Slides for Android via Java，您可以为每张幻灯片选择切换效果，配置鼠标点击或计时器的推进方式，并调整特定于效果的选项。本文使用 Java 示例演示如何应用切换、设置精确的切换持续时间、管理幻灯片计时以及在两张幻灯片之间创建 Morph 切换。示例还展示了如何将设置保存为 PPTX 文件。

## **添加幻灯片切换**

要应用切换，使用 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/) 类加载演示文稿，并通过 [getSlideShowTransition](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) 访问幻灯片的切换设置。使用来自 [TransitionType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/transitiontype/) 枚举的值调用 [setType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/islideshowtransition/#setType-int-)，然后保存演示文稿。

下面的示例对第一张幻灯片应用 Circle 切换，对第二张幻灯片应用 Comb 切换。使用包含至少两张幻灯片的 `input.pptx` 文件。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);
        presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

        presentation.save("slide-transitions.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **添加高级幻灯片切换**

您可以配置幻灯片在屏幕上停留的时间以及是否通过鼠标点击推进放映。以下方法控制此行为：

- [setAdvanceOnClick](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) 允许观众通过单击鼠标推进。
- [setAdvanceAfter](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) 启用自动推进。
- [setAdvanceAfterTime](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) 指定自动推进前的延迟（毫秒）。

同时启用点击和计时推进，使观众可以点击继续或等待计时器。若仅使用计时器，向 [setAdvanceOnClick](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) 传入 `false`。延迟控制放映何时推进；它不设置视觉切换效果的持续时间。

此示例为前三张幻灯片分配不同效果，并分别在 3、5、7 秒后启用自动推进。鼠标单击同样可以推进这些幻灯片。使用包含至少三张幻灯片的 `input.pptx` 文件。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 3) {
        ISlideShowTransition firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(TransitionType.Circle);
        firstTransition.setAdvanceOnClick(true);
        firstTransition.setAdvanceAfter(true);
        firstTransition.setAdvanceAfterTime(3000);

        ISlideShowTransition secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(TransitionType.Comb);
        secondTransition.setAdvanceOnClick(true);
        secondTransition.setAdvanceAfter(true);
        secondTransition.setAdvanceAfterTime(5000);

        ISlideShowTransition thirdTransition = presentation.getSlides().get_Item(2).getSlideShowTransition();
        thirdTransition.setType(TransitionType.Zoom);
        thirdTransition.setAdvanceOnClick(true);
        thirdTransition.setAdvanceAfter(true);
        thirdTransition.setAdvanceAfterTime(7000);

        presentation.save("advanced-transitions.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The input presentation must contain at least three slides.");
    }
} finally {
    presentation.dispose();
}
```

要检查是否启用了计时推进，请调用 [getAdvanceAfter](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/islideshowtransition/#getAdvanceAfter--)。仅存储的延迟并不表示计时器已激活。

下面的示例打开上面保存的文件，报告每个已启用的计时器，并对延迟超过两秒的幻灯片禁用自动推进。为这些幻灯片启用鼠标点击，并保存更新后的设置。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("advanced-transitions.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();

        if (transition.getAdvanceAfter()) {
            System.out.println("Slide " + slide.getSlideNumber() + ": advance after " + transition.getAdvanceAfterTime() + " ms.");

            if (transition.getAdvanceAfterTime() > 2000) {
                transition.setAdvanceAfter(false);
                transition.setAdvanceOnClick(true);
            }
        }
    }

    presentation.save("adjusted-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **精确控制切换时间**

使用 [setDuration](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) 可以以毫秒为单位指定切换效果的确切长度。幻灯片的 [getSlideShowTransition](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) 方法通过 [ISlideShowTransition](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/islideshowtransition/) 暴露这些设置：

| 方法 | 目的 |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) | 设置切换效果本身的持续时间（毫秒）。 |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | 设置幻灯片自动推进前的延迟（毫秒）。要激活此计时器，请对 [setAdvanceAfter](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) 传入 `true`。 |
| [setSpeed](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-) | 从 [TransitionSpeed](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/transitionspeed/) 中选择预定义的速度类别：Slow、Medium 或 Fast。当未指定精确持续时间时使用此属性。 |

[setDuration](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) 仅控制切换效果本身；它不决定幻灯片保持可见的时长。自动推进延迟需单独配置。当未设置显式持续时间时，Aspose.Slides 会根据切换类型和 [getSpeed](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/islideshowtransition/#getSpeed--) 值推算效果时长。

### **为所有幻灯片应用相同的持续时间**

为实现一致的节奏，可对每张幻灯片使用相同的效果和精确持续时间。此示例加载 `input.pptx`，从 [TransitionType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/transitiontype/) 中选择 Fade，并为每个切换设置 750 毫秒的持续时间。它分别在 5,000 毫秒后启用自动推进，并禁用鼠标点击，然后将结果保存为 PPTX。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Fade);
        transition.setDuration(750);

        // 独立于效果持续时间配置自动推进。
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **为单个幻灯片设置不同的持续时间**

不同幻灯片可以使用不同的效果时长。例如，对标题页使用短切换，对章节介绍使用较长切换。此示例为第一张幻灯片设置 500 毫秒，为第二张幻灯片设置 1,200 毫秒。使用包含至少两张幻灯片的 `input.pptx` 文件。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        ISlideShowTransition firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(TransitionType.Fade);
        firstTransition.setDuration(500);

        ISlideShowTransition secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(TransitionType.Push);
        secondTransition.setDuration(1200);

        presentation.save("individual-transition-durations.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

### **与动画输出配合切换**

在准备 [animated GIF](/slides/zh/androidjava/convert-powerpoint-to-animated-gif/)、[HTML5 presentation](/slides/zh/androidjava/export-to-html5/) 或 [video](/slides/zh/androidjava/convert-powerpoint-to-video/) 时，请在导出前设置精确的切换持续时间，以匹配预期的节奏。例如，场景之间使用 600 毫秒的淡入淡出，并分别调整每张幻灯片的推进延迟，以便为其旁白或内容留出时间。

对于 GIF 和视频，需要将输出帧率与效果时长对应：600 毫秒相当于 30 帧每秒下的 18 帧。HTML5 中，可在导出设置中启用动画切换。请检查所选导出格式支持的效果和时间选项，并预览输出以确认同步。

### **读取已有的切换持续时间**

在修改切换之前，调用 [getDuration](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/islideshowtransition/#getDuration--) 以确定是否已存储显式值。`-1` 表示未设置显式持续时间；非负值表示以毫秒为单位的存储时长。未设置的值不是计算得到的播放时长：Aspose.Slides 使用切换类型和 [getSpeed](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/islideshowtransition/#getSpeed--) 值来确定该时长。设置切换类型可能会初始化持续时间，因此请先检查原始设置。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        int duration = transition.getDuration();

        if (duration >= 0) {
            System.out.println("Slide " + slide.getSlideNumber() + ": stored transition duration is " + duration + " ms.");
        } else {
            System.out.println("Slide " + slide.getSlideNumber() + ": no explicit duration; timing depends on transition type " + transition.getType() + " and speed " + transition.getSpeed() + ".");
        }
    }
} finally {
    presentation.dispose();
}
```

## **Morph 切换**

Morph 切换在连续幻灯片之间对对象的变化进行动画化。要创建简单的 Morph 效果，复制一张幻灯片，在复制版上移动或调整对象大小，然后对第二张幻灯片应用 Morph 切换。这样就会在原始状态和修改后状态之间为对应对象创建动画。

下面的示例创建一张包含文本矩形的幻灯片，克隆该幻灯片，并在克隆版上更改矩形的位置和大小。随后为第二张幻灯片从 [TransitionType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/transitiontype/) 枚举中选择 Morph。使用支持 Morph 的演示文稿查看器打开保存的文件，即可在放映时看到效果。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    IAutoShape rectangle = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    rectangle.getTextFrame().setText("Morph transition");

    ISlide secondSlide = presentation.getSlides().addClone(firstSlide);
    IShape movedRectangle = secondSlide.getShapes().get_Item(0);
    movedRectangle.setX(movedRectangle.getX() + 100);
    movedRectangle.setY(movedRectangle.getY() + 50);
    movedRectangle.setWidth(movedRectangle.getWidth() - 200);
    movedRectangle.setHeight(movedRectangle.getHeight() - 10);

    secondSlide.getSlideShowTransition().setType(TransitionType.Morph);

    presentation.save("morph-transition.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Morph 切换类型**

[TransitionMorphType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/transitionmorphtype/) 枚举控制 Morph 匹配和动画的方式：

- [ByObject](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/transitionmorphtype/#ByObject) 将每个形状视为整体对象。
- [ByWord](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/transitionmorphtype/#ByWord) 在可能的情况下按单词匹配并动画化文本。
- [ByChar](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/transitionmorphtype/#ByChar) 在可能的情况下按字符匹配并动画化文本。

使用 [setType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) 选择 Morph，然后访问 [getValue](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/islideshowtransition/#getValue--) 获得 [IMorphTransition](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imorphtransition/) 接口，其 [setMorphType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/imorphtransition/#setMorphType-int-) 方法用于选择匹配模式。

此示例打开前一节创建的演示文稿，并将第二张幻灯片配置为基于单词的 Morph 动画。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("morph-transition.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        ISlideShowTransition transition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        transition.setType(TransitionType.Morph);
        ITransitionValueBase transitionValue = transition.getValue();

        if (transitionValue instanceof IMorphTransition) {
            IMorphTransition morphTransition = (IMorphTransition) transitionValue;
            morphTransition.setMorphType(TransitionMorphType.ByWord);
            presentation.save("morph-by-word.pptx", SaveFormat.Pptx);
        } else {
            System.out.println("Morph transition options are unavailable.");
        }
    } else {
        System.out.println("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **设置切换效果**

某些切换暴露额外选项，例如方向或是否从黑屏开始。可用选项取决于使用 [setType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) 选中的切换。先设置类型，再通过 [getValue](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/islideshowtransition/#getValue--) 获取相应接口。

下面的示例对 `input.pptx` 的第一张幻灯片应用 Cut 切换。它通过 [IOptionalBlackTransition](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ioptionalblacktransition/) 调用 [setFromBlack](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-)，使切换从黑屏开始。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlideShowTransition transition = presentation.getSlides().get_Item(0).getSlideShowTransition();
    transition.setType(TransitionType.Cut);
    ITransitionValueBase transitionValue = transition.getValue();

    if (transitionValue instanceof IOptionalBlackTransition) {
        IOptionalBlackTransition cutTransition = (IOptionalBlackTransition) transitionValue;
        cutTransition.setFromBlack(true);
        presentation.save("cut-from-black.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("Cut transition options are unavailable.");
    }
} finally {
    presentation.dispose();
}
```

## **常见问题**

**我能控制幻灯片切换的播放速度吗？**

可以。当需要以毫秒为单位的精确效果时，请优先使用 [setDuration](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-)。如果使用预定义的 [TransitionSpeed](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/transitionspeed/)（Slow、Medium、Fast）即可且未设置显式持续时间，则使用 [setSpeed](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-)。这些设置独立于自动推进延迟，专门控制切换效果。

**我能将音频附加到切换并使其循环吗？**

可以。使用 [setSound](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-) 分配嵌入音频，向 [setSoundMode](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/islideshowtransition/#setSoundMode-int-) 传入来自 [TransitionSoundMode](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/transitionsoundmode/) 枚举的 StartSound，并通过 [setSoundLoop](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-) 将其设为 `true`。音频将循环播放，直至幻灯片放映中出现下一个声音事件。

**将相同切换快速应用于所有幻灯片的最佳方法是什么？**

遍历演示文稿的 [getSlides](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/#getSlides--) 集合，在循环中为每张幻灯片的切换调用 [setType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) 并传入相同的值。可以在同一循环中设置计时和效果选项，以保持所有幻灯片行为一致。

**如何检查幻灯片当前设置的切换类型？**

对幻灯片的 [getSlideShowTransition](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) 结果调用 [getType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/islideshowtransition/#getType--)。它返回 [TransitionType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/transitiontype/) 枚举中的一个值；None 表示未应用任何切换效果。