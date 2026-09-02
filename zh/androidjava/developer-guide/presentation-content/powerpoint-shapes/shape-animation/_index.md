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
- 动画文本
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
description: "了解如何使用 Aspose.Slides for Android via Java 添加、检查和自定义形状动画、计时、声音、动画结束后行为以及动画文本。"
---
## **概述**

Aspose.Slides for Android via Java 将幻灯片动画表示为幻灯片时间轴中的效果。每个效果具有目标形状、动画类型和子类型、触发器、计时设置以及诸如声音或动画结束后行为等可选属性。

时间轴包含两种序列：

- **主序列** 在幻灯片前进时播放。
- **交互式序列** 在其触发形状被点击时启动。

由于文本框、图片、图表、表格和其他幻灯片对象实现了[IShape](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishape/)，您可以对大多数幻灯片内容使用相同的[ISequence.addEffect](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) 方法。可用的效果列在[EffectType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/effecttype/) 类中。

## **添加形状动画**

要添加动画，获取幻灯片的主序列并调用[ISequence.addEffect](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) ，传入目标形状、效果类型、子类型和触发器。对于在另一个形状被点击时启动的效果，创建一个触发器为该形状的交互式序列。

下面的示例创建了两种类型的动画并将结果保存为 `shape-animations.pptx`。

```java
import com.aspose.slides.*;

public class AddShapeAnimations {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);

            IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 120, 100, 320, 80);
            targetShape.addTextFrame("Click to animate this shape");

            ISequence mainSequence = slide.getTimeline().getMainSequence();
            IEffect entranceEffect = mainSequence.addEffect(targetShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            entranceEffect.getTiming().setDuration(1.5f);

            IAutoShape triggerShape = slide.getShapes().addAutoShape(ShapeType.Bevel, 20, 20, 100, 40);
            triggerShape.addTextFrame("Move");

            ISequence interactiveSequence = slide.getTimeline().getInteractiveSequences().add(triggerShape);
            interactiveSequence.addEffect(targetShape, EffectType.PathFootball, EffectSubtype.None, EffectTriggerType.OnClick);

            presentation.save("shape-animations.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

触发器控制效果何时开始：

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/effecttriggertype/#OnClick) 在主序列中等待点击，或在交互式序列中等待触发形状的点击。
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/effecttriggertype/#WithPrevious) 与前一个效果同时开始。
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/effecttriggertype/#AfterPrevious) 在前一个效果完成后开始。

要为图片、图表或其他形状类型设置动画，请将该对象传递给[ISequence.addEffect](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-)，而不是 `targetShape`。有关图表特定的分组选项，请参阅[动画图表](/slides/zh/androidjava/animated-charts/)。

## **读取形状动画**

当您已知目标形状时，使用[ISequence.getEffectsByShape](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-)。若要检查每个效果，请枚举主序列和所有交互式序列。枚举能够避免假设序列在索引 `0` 处一定存在效果。

下面的示例创建了一个具有主序列和交互式效果的形状，获取针对该形状的效果，然后枚举幻灯片上的每个序列。

```java
import com.aspose.slides.*;

public class ReadShapeAnimations {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
            targetShape.addTextFrame("Animated shape");

            ISequence mainSequence = slide.getTimeline().getMainSequence();
            mainSequence.addEffect(targetShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

            IAutoShape triggerShape = slide.getShapes().addAutoShape(ShapeType.Bevel, 20, 20, 100, 40);
            triggerShape.addTextFrame("Move");

            ISequence interactiveSequence = slide.getTimeline().getInteractiveSequences().add(triggerShape);
            interactiveSequence.addEffect(targetShape, EffectType.PathFootball, EffectSubtype.None, EffectTriggerType.OnClick);

            IEffect[] targetEffects = mainSequence.getEffectsByShape(targetShape);
            System.out.println("The main sequence contains " + targetEffects.length + " effect(s) for " + targetShape.getName() + ".");

            printSequence("Main sequence", mainSequence);

            int interactiveIndex = 1;
            for (ISequence sequence : slide.getTimeline().getInteractiveSequences()) {
                String triggerName = sequence.getTriggerShape() == null ? "unknown" : sequence.getTriggerShape().getName();
                String sequenceLabel = "Interactive sequence " + interactiveIndex + ", trigger: " + triggerName;
                printSequence(sequenceLabel, sequence);
                interactiveIndex++;
            }
        } finally {
            presentation.dispose();
        }
    }

    private static void printSequence(String label, ISequence sequence) {
        System.out.println("  " + label + ": " + sequence.getCount() + " effect(s)");

        for (IEffect effect : sequence) {
            String targetName = effect.getTargetShape() == null ? "unknown" : effect.getTargetShape().getName();
            String typeName = EffectType.getName(EffectType.class, effect.getType());
            String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());
            String triggerName = EffectTriggerType.getName(EffectTriggerType.class, effect.getTiming().getTriggerType());
            String effectDescription = typeName + " " + subtypeName + "; target: " + targetName + "; trigger: " + triggerName;
            System.out.println("    " + effectDescription);
        }
    }
}
```

如果只需要单个形状的效果，首先通过名称、占位符类型或其他稳定属性识别该形状；然后调用[ISequence.getEffectsByShape](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-)。不要假设[IShapeCollection.get_Item](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishapecollection/#get_Item-int-) 在索引 `0` 处始终是目标对象。

## **使用继承的占位符效果**

普通幻灯片上的占位符可以继承其版式幻灯片和母版上对应占位符的动画行为。[IShape.getBasePlaceholder](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishape/#getBasePlaceholder--) 返回该父占位符，若不存在父占位符则返回 `null`。

在下面的示例演示文稿中，页脚在普通幻灯片上使用 **Random Bars**，在版式幻灯片上使用 **Split**，在母版上使用 **Fly In**。

![普通幻灯片上的页脚动画效果](slide-shape-animation.png)

![版式幻灯片上的页脚占位符动画效果](layout-shape-animation.png)

![母版幻灯片上的页脚占位符动画效果](master-shape-animation.png)

下面的示例使用新演示文稿中的占位符层次结构。它向母版占位符、版式占位符以及普通幻灯片上的对应占位符添加效果。在使用返回的形状之前，都会检查[IShape.getBasePlaceholder](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishape/#getBasePlaceholder--) 的返回值。

```java
import com.aspose.slides.*;

public class InheritedPlaceholderAnimations {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject);
            IShape layoutPlaceholder = findPlaceholderWithBase(layoutSlide);

            if (layoutPlaceholder == null) {
                throw new IllegalStateException("The layout slide does not contain a placeholder linked to its master slide.");
            }

            IShape masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
            layoutSlide.getMasterSlide().getTimeline().getMainSequence().addEffect(masterPlaceholder, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);
            layoutSlide.getTimeline().getMainSequence().addEffect(layoutPlaceholder, EffectType.Split, EffectSubtype.VerticalIn, EffectTriggerType.OnClick);

            ISlide slide = presentation.getSlides().addEmptySlide(layoutSlide);
            IShape slidePlaceholder = findPlaceholderWithBase(slide, layoutPlaceholder);

            if (slidePlaceholder == null) {
                throw new IllegalStateException("The slide does not contain a placeholder linked to its layout slide.");
            }

            slide.getTimeline().getMainSequence().addEffect(slidePlaceholder, EffectType.RandomBars, EffectSubtype.Horizontal, EffectTriggerType.OnClick);
            printEffects("Normal slide", slide.getTimeline().getMainSequence().getEffectsByShape(slidePlaceholder));

            IShape baseLayoutPlaceholder = slidePlaceholder.getBasePlaceholder();
            if (baseLayoutPlaceholder != null) {
                printEffects("Layout slide", layoutSlide.getTimeline().getMainSequence().getEffectsByShape(baseLayoutPlaceholder));

                IShape baseMasterPlaceholder = baseLayoutPlaceholder.getBasePlaceholder();
                if (baseMasterPlaceholder != null) {
                    printEffects("Master slide", layoutSlide.getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(baseMasterPlaceholder));
                }
            }

            presentation.save("placeholder-animations.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }

    private static IShape findPlaceholderWithBase(ILayoutSlide layoutSlide) {
        for (IShape shape : layoutSlide.getShapes()) {
            if (shape.getBasePlaceholder() != null) {
                return shape;
            }
        }

        return null;
    }

    private static IShape findPlaceholderWithBase(ISlide slide, IShape expectedBase) {
        for (IShape shape : slide.getShapes()) {
            if (shape.getBasePlaceholder() == expectedBase) {
                return shape;
            }
        }

        return null;
    }

    private static void printEffects(String source, IEffect[] effects) {
        System.out.println(source + ": " + effects.length + " effect(s)");

        for (IEffect effect : effects) {
            String typeName = EffectType.getName(EffectType.class, effect.getType());
            String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());
            System.out.println("  " + typeName + " " + subtypeName);
        }
    }
}
```

## **更改动画时间**

PowerPoint **计时** 对话框映射到[ITiming](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itiming/) 的属性。

![动画效果的 PowerPoint 计时对话框](shape-animation.png)

- **开始** 映射到[ITiming.getTriggerType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itiming/#getTriggerType--)。
- **持续时间** 映射到[ITiming.getDuration](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itiming/#getDuration--)，单位为秒。
- **延迟** 映射到[ITiming.getTriggerDelayTime](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itiming/#getTriggerDelayTime--)，单位为秒。
- **重复** 映射到[ITiming.getRepeatCount](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itiming/#getRepeatCount--)、[ITiming.getRepeatUntilNextClick](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itiming/#getRepeatUntilNextClick--)或[ITiming.getRepeatUntilEndSlide](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itiming/#getRepeatUntilEndSlide--)。
- **播放完成后倒带** 映射到[ITiming.getRewind](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itiming/#getRewind--)。

此独立示例添加一个效果，通过[ISequence.addEffect](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) 返回的对象更改其计时，并保存结果。保留返回的[IEffect](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ieffect/) 引用可避免不必要的集合索引。

```java
import com.aspose.slides.*;

public class ChangeAnimationTiming {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
            shape.addTextFrame("Timed animation");

            IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            effect.getTiming().setTriggerType(EffectTriggerType.OnClick);
            effect.getTiming().setDuration(2.0f);
            effect.getTiming().setTriggerDelayTime(0.5f);
            effect.getTiming().setRepeatUntilNextClick(false);
            effect.getTiming().setRepeatUntilEndSlide(false);
            effect.getTiming().setRepeatCount(2.0f);
            effect.getTiming().setRewind(true);

            presentation.save("shape-animation-timing.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

请有意使用一种重复模式。将重复计数与 “直到” 标志组合可能在不同的查看器中产生混乱的结果。更改重复模式时，请先调用[ITiming.setRepeatUntilNextClick](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itiming/#setRepeatUntilNextClick-boolean-) 和 [ITiming.setRepeatUntilEndSlide](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itiming/#setRepeatUntilEndSlide-boolean-)，再调用[ITiming.setRepeatCount](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itiming/#setRepeatCount-float-)，因为设置任一标志也会改变活动的重复模式。

## **添加和提取动画声音**

动画效果可以通过[IEffect.getSound](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ieffect/#getSound--) 引用嵌入的音频。[IEffect.setStopPreviousSound](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ieffect/#setStopPreviousSound-boolean-) 告诉效果停止先前效果启动的音频。

### **向效果添加声音**

下面的示例需要一个名为 `animation-sound.wav` 的本地音频文件。它创建两个效果，将该文件嵌入为第一个效果的声音，并配置第二个效果停止该声音。示例使用[ISequence.addEffect](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) 返回的对象，因此不需要序列索引。

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

public class AddAnimationSound {
    public static void main(String[] args) throws IOException {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape firstShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 100, 240, 80);
            IAutoShape secondShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 400, 100, 240, 80);
            firstShape.addTextFrame("Starts sound");
            secondShape.addTextFrame("Stops sound");

            ISequence sequence = slide.getTimeline().getMainSequence();
            IEffect firstEffect = sequence.addEffect(firstShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            IEffect secondEffect = sequence.addEffect(secondShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

            byte[] audioData = Files.readAllBytes(Paths.get("animation-sound.wav"));
            IAudio effectSound = presentation.getAudios().addAudio(audioData);
            firstEffect.setSound(effectSound);
            secondEffect.setStopPreviousSound(true);

            presentation.save("shape-animation-sound.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

### **提取嵌入的效果声音**

下面的示例需要一个名为 `presentation-with-animation-sounds.pptx` 的本地演示文稿。它扫描主序列和交互式序列，并将每个嵌入的效果声音写入 `extracted-animation-sounds` 目录。文件扩展名根据[IAudio.getContentType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iaudio/#getContentType--) 返回的音频 MIME 类型选择。

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Locale;

public class ExtractAnimationSounds {
    public static void main(String[] args) throws IOException {
        Path inputPath = Paths.get("presentation-with-animation-sounds.pptx");
        Path outputDirectory = Paths.get("extracted-animation-sounds");

        Files.createDirectories(outputDirectory);

        Presentation presentation = new Presentation(inputPath.toString());
        try {
            int soundIndex = 1;

            for (ISlide slide : presentation.getSlides()) {
                soundIndex = saveSounds(slide.getTimeline().getMainSequence(), outputDirectory, soundIndex);

                for (ISequence sequence : slide.getTimeline().getInteractiveSequences()) {
                    soundIndex = saveSounds(sequence, outputDirectory, soundIndex);
                }
            }

            System.out.println("Extracted " + (soundIndex - 1) + " sound file(s) to " + outputDirectory.toAbsolutePath() + ".");
        } finally {
            presentation.dispose();
        }
    }

    private static int saveSounds(ISequence sequence, Path outputDirectory, int soundIndex) throws IOException {
        for (IEffect effect : sequence) {
            if (effect.getSound() == null) {
                continue;
            }

            String extension = getAudioExtension(effect.getSound().getContentType());
            Path outputPath = outputDirectory.resolve("effect-sound-" + soundIndex + extension);
            Files.write(outputPath, effect.getSound().getBinaryData());
            soundIndex++;
        }

        return soundIndex;
    }

    private static String getAudioExtension(String contentType) {
        String normalizedType = contentType == null ? "" : contentType.toLowerCase(Locale.ROOT);

        if (normalizedType.equals("audio/mpeg")) {
            return ".mp3";
        }

        if (normalizedType.equals("audio/mp4")) {
            return ".m4a";
        }

        if (normalizedType.equals("audio/ogg")) {
            return ".ogg";
        }

        if (normalizedType.equals("audio/wav") || normalizedType.equals("audio/x-wav")) {
            return ".wav";
        }

        return ".bin";
    }
}
```

对于大型音频对象，请使用[IAudio.getStream](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iaudio/#getStream--) 并将流复制到文件，而不是将整个对象加载到字节数组中。

## **设置动画结束后的行为**

**After animation** 选项控制形状在其效果结束后会发生什么。

![显示 After animation 设置的 PowerPoint 效果选项对话框](shape-after-animation.png)

[AfterAnimationType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/afteranimationtype/) 类支持保持形状不变、改变颜色、在动画后隐藏或在下一次点击时隐藏。当类型为[AfterAnimationType.Color](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/afteranimationtype/#Color) 时，还需设置[IEffect.getAfterAnimationColor](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ieffect/#getAfterAnimationColor--)。

此独立示例创建一个效果，通过返回的效果对象设置其动画结束后行为，并保存结果。

```java
import com.aspose.slides.*;
import android.graphics.Color;

public class SetAfterAnimationBehavior {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
            shape.addTextFrame("Dim after animation");

            IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            effect.setAfterAnimationType(AfterAnimationType.Color);
            effect.getAfterAnimationColor().setColor(Color.LTGRAY);

            presentation.save("shape-animation-after-effect.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

将类型从[AfterAnimationType.Color](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/afteranimationtype/#Color) 更改为其他值会清除动画结束后的颜色设置。

## **动画文本**

文本动画有两个相关控制：

- [ITextAnimation.getBuildType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itextanimation/#getBuildType--) 控制段落是整体出现还是按段落级别出现。
- [IEffect.getAnimateTextType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ieffect/#getAnimateTextType--) 控制文本是一次性出现、按单词还是按字母出现。[IEffect.getDelayBetweenTextParts](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ieffect/#getDelayBetweenTextParts--) 设置单词或字母之间的延迟。正值为效果持续时间的百分比，负值为秒数延迟。

下面的独立示例对文本框中的单词进行动画。[BuildType.AsOneObject](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/buildtype/#AsOneObject) 禁用段落逐段构建，使单词设置适用于整个文本框。

```java
import com.aspose.slides.*;

public class AnimateTextByWord {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 560, 100);
            textBox.addTextFrame("Aspose.Slides animates this sentence word by word.");

            IEffect effect = slide.getTimeline().getMainSequence().addEffect(textBox, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            effect.getTextAnimation().setBuildType(BuildType.AsOneObject);
            effect.setAnimateTextType(AnimateTextType.ByWord);
            effect.setDelayBetweenTextParts(20.0f);

            presentation.save("animated-text.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

若要按段落构建文本框，请设置[BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/buildtype/#ByLevelParagraphs1)（或其他段落级别）。若要为单个段落单独设置效果，请使用接受[IParagraph](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iparagraph/) 参数的[ISequence.addEffect](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IParagraph-int-int-int-) 重载。有关段落级别示例，请参阅[动画文本](/slides/zh/androidjava/animated-text/)。

## **导出和兼容性说明**

- 保存为 PPT 或 PPTX 会保留动画模型，但最终播放由演示文稿查看器控制。
- PDF 和静态图像不播放动画。需要显示运动时，请使用[HTML5 导出](/slides/zh/androidjava/export-to-html5/)、动画 GIF 或[视频转换](/slides/zh/androidjava/convert-powerpoint-to-video/)。
- 对于 HTML5，启用[Html5Options.setAnimateShapes](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-)；如需动画切换，还需启用[Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-)。
- 视频渲染支持许多常见的进入、强调、退出和运动路径效果，但并非所有 PowerPoint 效果都受支持。请查看当前的[受支持动画和效果](/slides/zh/androidjava/convert-powerpoint-to-video/#supported-animations-and-effects) 并使用目标 Aspose.Slides 版本对关键演示文稿进行测试。
- 高级自定义效果以及从其他演示文稿格式导入的效果可能在文件中保留，但在 PowerPoint、HTML5 或视频中呈现方式不同。请验证导出结果，而不仅依赖于效果名称。

## **常见问题**

**为什么动画在 PowerPoint 中可以看到，但在 PDF 中没有？**

PDF 是静态格式，动画和幻灯片切换不会播放。需要保留运动时请导出为 HTML5、动画 GIF 或视频。

**为什么同一效果在视频中播放效果不同？**

视频导出会渲染动画，而不是存储原始 PowerPoint 行为。某些高级效果不受支持或被近似。请查阅受支持效果表并在生产使用前对实际演示文稿进行测试。

**移动形状的前置或后置会改变其动画顺序吗？**

不会。形状的 Z 顺序控制覆盖关系，序列顺序和触发器控制动画播放。若需更改播放顺序，请调整时间轴。