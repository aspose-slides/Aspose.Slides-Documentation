---
title: 在 Android 上管理演示文稿的幻灯片切换
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
description: "使用 Aspose.Slides for Android via Java 应用幻灯片切换、配置自动幻灯片前进，并自定义 Morph 及其他切换效果。"
---
## **概述**

幻灯片切换控制幻灯片在放映过程中的出现方式。使用 Aspose.Slides for Android via Java，您可以为每张幻灯片选择切换效果，配置鼠标点击或计时器的前进方式，并调整特定于某种效果的选项。本文使用 Java 示例演示如何应用切换、设置精确的切换持续时间、管理幻灯片计时以及在两张幻灯片之间创建 Morph 切换。示例还展示了如何将设置保存为 PPTX 文件。

## **添加幻灯片切换**

要应用切换，请使用[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)类加载演示文稿，并通过[getSlideShowTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--)访问幻灯片的切换设置。使用[setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-)并从[TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/)枚举中选择一个值，然后保存演示文稿。

下面的示例对第一张幻灯片应用 Circle 切换，对第二张幻灯片应用 Comb 切换。请使用至少包含两张幻灯片的 `input.pptx` 文件。

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

## **轮盘切换**

[IWheelTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iwheeltransition/) 的[setSpokes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iwheeltransition/#setSpokes-long-)方法控制显示目标幻灯片的径向扇区数量。在访问[IWheelTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iwheeltransition/)之前，先使用[TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/)中的[setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-)将幻灯片的切换类型设置为 Wheel，然后通过[getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getValue--)获取该接口。

本示例创建两对相同的幻灯片：一张黑色幻灯片后跟一张带有金色矩形的幻灯片。目标幻灯片的扇区计数分别为 1 和 8，速度通过[setSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-)统一设置，并通过[setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-)显式设为 8000 毫秒，以便轻松观察差异。

```java
import android.graphics.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    float slideWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float slideHeight = (float) presentation.getSlideSize().getSize().getHeight();

    ISlide blackSlide = presentation.getSlides().get_Item(0);
    blackSlide.getShapes().clear();
    blackSlide.getBackground().setType(BackgroundType.OwnBackground);
    blackSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    blackSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    ISlide destinationSlide = presentation.getSlides().addClone(blackSlide);
    IAutoShape rectangle = destinationSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, slideWidth, slideHeight);
    rectangle.getFillFormat().setFillType(FillType.Solid);
    int gold = Color.rgb(255, 215, 0);
    rectangle.getFillFormat().getSolidFillColor().setColor(gold);
    rectangle.getTextFrame().setText("Wheel transition");

    presentation.getSlides().addClone(blackSlide);
    presentation.getSlides().addClone(destinationSlide);

    long[] spokeCounts = { 1, 8 };
    for (int i = 0; i < spokeCounts.length; i++) {
        ISlideShowTransition transition = presentation.getSlides().get_Item(i * 2 + 1).getSlideShowTransition();
        transition.setType(TransitionType.Wheel);
        IWheelTransition wheelTransition = (IWheelTransition) transition.getValue();
        wheelTransition.setSpokes(spokeCounts[i]);
        transition.setSpeed(TransitionSpeed.Slow);
        transition.setDuration(8000);
    }

    presentation.save("wheel-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

在 PowerPoint 中打开输出演示文稿并运行放映。从第 1 张幻灯片前进到第 2 张，再从第 3 张前进到第 4 张。在 PowerPoint 播放时，扇区计数为 1 的切换以一次顺时针扫过的方式显示幻灯片；计数为 8 的切换则同时通过八个径向扇区显示。目标内容和切换时间相同，唯一的差别在于显示扇区的数量。

## **使用 Reveal 切换实现淡入黑色**

将目标幻灯片的切换类型设为 Reveal，然后在其[IRevealTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irevealtransition/)设置上调用[setThroughBlack](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irevealtransition/#setThroughBlack-boolean-)。示例创建一张青色源幻灯片和一张珊瑚色目标幻灯片，并对两者进行克隆。每对子使用相同的两秒 Reveal 切换，只有第二对子在切换时淡入黑色。

```java
import android.graphics.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide source = presentation.getSlides().get_Item(0);
    ISlide destination = presentation.getSlides().addClone(source);
    ISlide[] slides = { source, destination };
    int[] backgrounds = { Color.rgb(0, 128, 128), Color.rgb(255, 127, 80) };
    String[] labels = { "Source", "Destination" };

    for (int i = 0; i < slides.length; i++) {
        ISlide slide = slides[i];
        slide.getBackground().setType(BackgroundType.OwnBackground);
        slide.getBackground().getFillFormat().setFillType(FillType.Solid);
        slide.getBackground().getFillFormat().getSolidFillColor().setColor(backgrounds[i]);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 160, 180, 400, 130);
        shape.getTextFrame().setText(labels[i]);
        shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setFontHeight(44);
    }

    presentation.getSlides().addClone(source);
    ISlide clonedDestination = presentation.getSlides().addClone(destination);
    for (ISlide slide : new ISlide[] { destination, clonedDestination }) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Reveal);
        transition.setSpeed(TransitionSpeed.Slow);
        transition.setDuration(2000);

        IRevealTransition reveal = (IRevealTransition) transition.getValue();
        reveal.setDirection(TransitionLeftRightDirectionType.Left);
        reveal.setThroughBlack(slide == clonedDestination);
    }

    presentation.save("reveal-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

在 PowerPoint 中打开保存的演示文稿并开始放映。从第 1 张幻灯片前进到第 2 张，您会看到青色直接淡入珊瑚色。然后从第 3 张前进到第 4 张，屏幕会短暂暗到接近黑色后再出现珊瑚色幻灯片。两张幻灯片保持原始背景颜色。

下表展示了 PowerPoint 每半秒截取的帧。比较每行的中间帧即可看到效果。

![PowerPoint 播放时禁用淡入黑色（上）和启用淡入黑色（下）。仅底部行通过接近黑色。](reveal-through-black.png)

## **添加高级幻灯片切换**

您可以配置幻灯片在屏幕上停留的时间以及是否通过鼠标点击前进。以下方法用于控制此行为：

- [setAdvanceOnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) 允许观看者通过点击鼠标前进。
- [setAdvanceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) 启用自动前进。
- [setAdvanceAfterTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) 指定自动前进前的延迟（毫秒）。

可同时启用点击和计时前进，使观看者可以点击继续或等待计时器。若只使用计时器，请将[setAdvanceOnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-)设为 `false`。延迟控制放映何时前进；它并不设定视觉切换效果的持续时间。

本示例为前三张幻灯片分配不同的切换效果，并分别在 3、5、7 秒后自动前进。鼠标点击同样可以前进这些幻灯片。请使用至少包含三张幻灯片的 `input.pptx` 文件。

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

要检查是否启用了计时前进，请调用[getAdvanceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getAdvanceAfter--)。仅存储的延迟并不表示计时器已激活。

下面的示例打开上述保存的文件，报告每个已启用的计时器，并对延迟大于两秒的幻灯片禁用自动前进。随后为这些幻灯片启用鼠标点击并保存更新后的设置。

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

使用[setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-)可指定切换效果的精确时长（毫秒）。幻灯片的[getSlideShowTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--)方法通过[ISlideShowTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/)公开这些设置：

| 方法 | 用途 |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) | 设置切换效果本身的持续时间（毫秒）。 |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | 设置幻灯片自动前进前的延迟（毫秒）。将 `true` 传递给[setAdvanceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-)以激活此计时器。 |
| [setSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-) | 从[TransitionSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionspeed/)枚举中选择预定义的速度类别：Slow、Medium 或 Fast。当未指定精确时长时使用该类别。 |

[setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-)仅控制切换效果本身；它不决定幻灯片的可见时长。请单独配置自动前进的延迟。当未设置显式时长时，Aspose.Slides 会根据切换类型和[getSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getSpeed--)值计算效果时长。

<!-- visual-explanation:slide-transition:start -->
[![Separate bars identify the 750-ms transition duration and 5,000-ms automatic advancement setting.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*共享示例为每张幻灯片分配 750 ms 的淡入切换，并分别在 5 000 ms 后启用自动前进。切换时长控制效果，前进时长控制何时离开幻灯片。这些条形图是示意设置，而非实际测量的合并时间线。*
<!-- visual-explanation:slide-transition:end -->

### **将相同的时长应用于每张幻灯片**

为获得一致的节奏，可将相同的效果和精确时长应用于每张幻灯片。此示例加载 `input.pptx`，从[TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/)中选择 Fade，并为每个切换设置 750 毫秒的时长。随后分别在 5 000 毫秒后启用自动前进，并禁用鼠标点击前进，最后将结果保存为 PPTX。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Fade);
        transition.setDuration(750);

        // 配置自动前进，独立于效果持续时间。
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **为单独幻灯片设置不同的时长**

不同幻灯片可以使用不同的效果时长。例如，对标题幻灯片使用短暂的切换，对章节介绍使用较长的切换。此示例为第一张幻灯片设置 500 毫秒，为第二张幻灯片设置 1 200 毫秒。请使用至少包含两张幻灯片的 `input.pptx` 文件。

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

### **与动画输出协同切换**

在准备[animated GIF](/slides/zh/androidjava/convert-powerpoint-to-animated-gif/)、[HTML5 演示](/slides/zh/androidjava/export-to-html5/)或[视频](/slides/zh/androidjava/convert-powerpoint-to-video/)时，请在导出前设置精确的切换时长以匹配预期节奏。例如，在场景之间使用 600 毫秒的淡入，并为每张幻灯片单独设置前进延迟，以便留出旁白或内容的时间。

对于 GIF 和视频，请将输出帧率与效果时长对应：600 毫秒在 30 fps 下对应 18 帧。对于 HTML5，在导出设置中启用动画切换。检查所选导出格式支持的效果和计时选项，并预览输出以确认同步。

### **读取已有的切换时长**

在修改切换之前调用[getDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getDuration--)以确定是否存储了显式值。`-1` 表示未设置显式时长；非负值表示以毫秒为单位的存储时长。未设置的值并非计算出的播放时长：Aspose.Slides 使用切换类型和[getSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getSpeed--)值来确定该时长。设置切换类型可能会初始化时长，因此请先检查原始设置。

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

Morph 切换在连续幻灯片之间动画化对象的变化。要创建简单的 Morph 效果，可克隆幻灯片，在克隆上移动或缩放对象，然后对第二张幻灯片应用 Morph 切换。这样会在原始状态和修改后状态之间为对应对象生成动画。

下面的示例创建一张包含文本矩形的幻灯片，克隆该幻灯片，并在克隆上更改矩形的位置和大小。随后为第二张幻灯片从[TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/)枚举中选择 Morph。将保存的文件在支持 Morph 的演示查看器中打开，即可在放映时看到效果。

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

[TransitionMorphType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionmorphtype/) 枚举决定 Morph 如何匹配并动画化内容：

- [ByObject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionmorphtype/#ByObject) 将每个形状视为整体对象。
- [ByWord](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionmorphtype/#ByWord) 在可能的情况下按单词匹配文本并动画化。
- [ByChar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionmorphtype/#ByChar) 在可能的情况下按字符匹配文本并动画化。

使用[setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-)选择 Morph，然后访问[getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getValue--)获取[IMorphTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imorphtransition/)接口，随后调用其[setMorphType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imorphtransition/#setMorphType-int-)方法选择匹配模式。

本示例打开前一节创建的演示文稿，并将第二张幻灯片配置为基于单词的 Morph 动画。

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

某些切换会暴露额外选项，例如方向或是否从黑屏开始。可用选项取决于使用[setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-)选择的切换类型。先设置类型，然后通过[getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getValue--)获取相应接口。

以下示例对 `input.pptx` 的第一张幻灯片应用 Cut 切换，并通过[IOptionalBlackTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioptionalblacktransition/)调用[setFromBlack](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-)，使切换从黑屏开始。

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

## **常见问题解答**

**我可以控制幻灯片切换的播放速度吗？**

可以。当需要以毫秒为单位的精确效果时长时，请优先使用[setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-)。当预定义的[TransitionSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionspeed/)（Slow、Medium 或 Fast）足以满足需求且未设定显式时长时，请使用[setSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-)。这些设置独立于自动前进延迟，专门控制切换效果。

**我可以为切换附加音频并设置循环吗？**

可以。使用[setSound](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-)分配嵌入音频，将[TransitionSoundMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionsoundmode/) 枚举中的 StartSound 传递给[setSoundMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSoundMode-int-)，并通过[setSoundLoop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-)将其设为 `true`。音频将在幻灯片放映中循环，直至出现下一个音频事件。

**将相同的切换应用于所有幻灯片的最快方法是什么？**

遍历演示文稿的[getSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--)集合，对每张幻灯片的切换调用[setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-)并传入相同的值。可在同一循环中设置计时和效果选项，以保持所有幻灯片行为一致。

**如何检查幻灯片当前设置了哪种切换？**

对幻灯片的[getSlideShowTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--)结果调用[getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getType--)。它返回[TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/) 枚举中的一个值；None 表示未应用任何切换效果。