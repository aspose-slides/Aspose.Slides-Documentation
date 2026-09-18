---
title: 在 Java 中於簡報套用圖形動畫
linktitle: 圖形動畫
type: docs
weight: 60
url: /zh-hant/java/shape-animation/
keywords:
- 圖形
- 動畫
- 效果
- 已動畫圖形
- 已動畫文字
- 新增動畫
- 取得動畫
- 擷取動畫
- 新增效果
- 取得效果
- 擷取效果
- 效果聲音
- 套用動畫
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Java 新增、檢查和自訂圖形動畫、時間設定、聲音、動畫後行為，以及動畫文字。"
---
## **概觀**

若要在效果內處理各個行為或編輯移動路徑段，請參閱 [自訂動畫](/slides/zh-hant/java/custom-animation/)。

Aspose.Slides for Java 將投影片動畫表示為投影片時間軸上的效果。每個效果具有目標圖形、動畫類型與子類型、觸發器、計時設定，以及聲音或動畫後行為等可選屬性。

時間軸包含兩種類型的序列：

- **主要序列** 在投影片前進時播放。
- **互動序列** 於其觸發圖形被點擊時開始。

因為文字方塊、圖片、圖表、表格以及其他投影片物件皆實作 [IShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/)，您可對大多數投影片內容使用相同的 [ISequence.addEffect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) 方法。可用的效果列於 [EffectType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/effecttype/) 類別中。

## **新增圖形動畫**

若要新增動畫，取得投影片的主要序列，並以目標圖形、效果類型、子類型與觸發器呼叫 [ISequence.addEffect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-)。若要在點擊另一個圖形時開始效果，請建立以該圖形為觸發器的互動序列。

下列範例建立兩種動畫，並將結果儲存為 `shape-animations.pptx`。

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

觸發器控制效果何時開始：

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/effecttriggertype/#OnClick) 於主要序列等待點擊，或於互動序列等待對觸發圖形的點擊。
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/effecttriggertype/#WithPrevious) 在前一個效果同時開始。
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/effecttriggertype/#AfterPrevious) 在前一個效果完成後開始。

若要為圖片、圖表或其他圖形類型設定動畫，請將該物件傳遞給 [ISequence.addEffect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-)，而非 `targetShape`。欲了解圖表特定的分組選項，請參閱 [Animated Charts](/slides/zh-hant/java/animated-charts/)。

## **讀取圖形動畫**

當您知道目標圖形時，請使用 [ISequence.getEffectsByShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-)。若要檢查每個效果，請列舉主要序列與所有互動序列。使用列舉可避免假設序列在索引 `0` 處一定有效果。

下列範例建立具有主要序列與互動效果的圖形，取得針對該圖形的效果，然後列舉投影片上的每個序列。

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

如果只需要單一圖形的效果，請先依名稱、佔位符類型或其他穩定屬性辨識該圖形；然後呼叫 [ISequence.getEffectsByShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-)。切勿假設在索引 `0` 的 [IShapeCollection.get_Item](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishapecollection/#get_Item-int-) 一定是目標物件。

## **使用繼承的佔位符效果**

一般投影片上的佔位符可以繼承其版面投影片與母版投影片上相對應佔位符的動畫行為。[IShape.getBasePlaceholder](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/#getBasePlaceholder--) 會回傳該父佔位符，若不存在則回傳 `null`。

在下列示例簡報中，頁腳在一般投影片上使用 **Random Bars**，在版面投影片上使用 **Split**，在母版投影片上使用 **Fly In**。

![一般投影片上的頁腳動畫效果](slide-shape-animation.png)

![版面投影片上頁腳佔位符動畫效果](layout-shape-animation.png)

![母版投影片上頁腳佔位符動畫效果](master-shape-animation.png)

下一個範例使用新簡報中的佔位符階層。它對母版佔位符、版面佔位符以及一般投影片上的對應佔位符加入效果。對每一次呼叫 [IShape.getBasePlaceholder](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ishape/#getBasePlaceholder--) 都會先檢查返回的圖形再使用。

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

## **變更動畫時間設定**

PowerPoint **Timing** 對話方塊對應至 [ITiming](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itiming/) 的屬性。

![PowerPoint 動畫效果的 Timing 對話方塊](shape-animation.png)

- **開始** 對應至 [ITiming.getTriggerType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itiming/#getTriggerType--)。
- **持續時間** 對應至 [ITiming.getDuration](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itiming/#getDuration--)（單位：秒）。
- **延遲** 對應至 [ITiming.getTriggerDelayTime](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itiming/#getTriggerDelayTime--)（單位：秒）。
- **重複** 對應至 [ITiming.getRepeatCount](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itiming/#getRepeatCount--)、[ITiming.getRepeatUntilNextClick](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itiming/#getRepeatUntilNextClick--) 或 [ITiming.getRepeatUntilEndSlide](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itiming/#getRepeatUntilEndSlide--)。
- **播放完畢時倒轉** 對應至 [ITiming.getRewind](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itiming/#getRewind--)。

此獨立範例加入一個效果，透過 [ISequence.addEffect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) 回傳的物件變更其時間設定，並儲存結果。保留回傳的 [IEffect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ieffect/) 參考可避免不必要的集合索引。

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

請有意使用單一的重複模式。將重複計數與「直到」旗標結合可能在不同的檢視器中產生混淆的結果。變更重複模式時，請先設定 [ITiming.setRepeatUntilNextClick](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itiming/#setRepeatUntilNextClick-boolean-) 與 [ITiming.setRepeatUntilEndSlide](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itiming/#setRepeatUntilEndSlide-boolean-)，再呼叫 [ITiming.setRepeatCount](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itiming/#setRepeatCount-float-)，因為設定任一旗標也會改變目前的重複模式。

## **新增與擷取動畫聲音**

動畫效果可以透過 [IEffect.getSound](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ieffect/#getSound--) 參考嵌入的音訊。[IEffect.setStopPreviousSound](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ieffect/#setStopPreviousSound-boolean-) 可指示效果停止先前效果所啟動的音訊。

### **為效果新增聲音**

下列範例預期有名為 `animation-sound.wav` 的本機音訊檔案。它建立兩個效果，將該檔案嵌入為第一個效果的聲音，並設定第二個效果停止聲音。它使用由 [ISequence.addEffect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) 回傳的物件，因而不需要序列索引。

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

### **擷取嵌入的效果聲音**

下列範例預期有名為 `presentation-with-animation-sounds.pptx` 的本機簡報。它掃描主要與互動序列，將每個嵌入的效果聲音寫入 `extracted-animation-sounds` 目錄。副檔名根據 [IAudio.getContentType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iaudio/#getContentType--) 所提供的音訊 MIME 類型選取。

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

對於大型音訊物件，請使用 [IAudio.getStream](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iaudio/#getStream--)，並將串流複製至檔案，而非將整個物件載入至位元組陣列。

## **設定動畫後行為**

**After animation** 選項控制效果完成後圖形的處理方式。

![PowerPoint 效果選項對話方塊顯示「After animation」設定](shape-after-animation.png)

[AfterAnimationType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/afteranimationtype/) 類別支援保持圖形不變、更改其顏色、在動畫後隱藏圖形，或在下一次點擊時隱藏圖形。當類型為 [AfterAnimationType.Color](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/afteranimationtype/#Color) 時，亦需設定 [IEffect.getAfterAnimationColor](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ieffect/#getAfterAnimationColor--)。

此獨立範例建立一個效果，透過回傳的效果物件設定其動畫後行為，並儲存結果。

```java
import com.aspose.slides.*;
import java.awt.Color;

public class SetAfterAnimationBehavior {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
            shape.addTextFrame("Dim after animation");

            IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            effect.setAfterAnimationType(AfterAnimationType.Color);
            effect.getAfterAnimationColor().setColor(Color.LIGHT_GRAY);

            presentation.save("shape-animation-after-effect.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

將類型從 [AfterAnimationType.Color](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/afteranimationtype/#Color) 改為其他會清除動畫後的顏色設定。

## **動畫文字**

文字動畫有兩個相關控制項：

- [ITextAnimation.getBuildType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextanimation/#getBuildType--) 控制段落是一次顯示還是逐段顯示。
- [IEffect.getAnimateTextType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ieffect/#getAnimateTextType--) 控制文字是一次全部顯示、逐字或逐字元顯示。[IEffect.getDelayBetweenTextParts](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ieffect/#getDelayBetweenTextParts--) 設定字或字元之間的延遲。正值為效果持續時間的百分比，負值為以秒為單位的延遲。

下列獨立範例為文字方塊中的單字加入動畫。[BuildType.AsOneObject](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/buildtype/#AsOneObject) 會停用逐段構建，使字詞設定套用於整個文字框。

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

若要逐段建立文字方塊，請設定 [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/buildtype/#ByLevelParagraphs1)（或其他段落層級）。若要對單一段落套用其專屬效果，請使用接受 [IParagraph](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/iparagraph/) 的 [ISequence.addEffect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IParagraph-int-int-int-) 重載。請參閱 [Animated Text](/slides/zh-hant/java/animated-text/) 取得段落層級的範例。

## **匯出與相容性說明**

- 將檔案儲存為 PPT 或 PPTX 會保留動畫模型，但最終播放由簡報檢視器控制。
- PDF 與靜態影像不會播放動畫。當輸出必須顯示動作時，請使用 [HTML5 export](/slides/zh-hant/java/export-to-html5/)、動畫 GIF，或 [video conversion](/slides/zh-hant/java/convert-powerpoint-to-video/)。
- 對於 HTML5，請啟用 [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-)，必要時亦啟用 [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-)。
- 影片渲染支援許多常見的進入、強調、退出與移動路徑效果，但並非所有 PowerPoint 效果皆受支援。請查看目前的 [supported animations and effects](/slides/zh-hant/java/convert-powerpoint-to-video/#supported-animations-and-effects) 並使用目標的 Aspose.Slides 版本測試關鍵簡報。
- 進階自訂效果以及從其他簡報格式匯入的效果可能在檔案中被保留，但在 PowerPoint、HTML5 或影片中呈現方式可能不同。請驗證匯出結果，而非僅僅依賴效果名稱。

## **常見問題**

**為什麼動畫在 PowerPoint 中出現，但在 PDF 中沒有？**

PDF 為靜態格式，故不會播放動畫與投影片轉場。當必須保留動作時，請匯出為 HTML5、動畫 GIF，或影片。

**為什麼效果在影片中播放不同？**

影片匯出會渲染動畫，而非儲存原始 PowerPoint 行為。一些進階效果不受支援或僅為近似。請檢閱支援效果表，並在正式使用前測試實際簡報。

**將圖形向前或向後移動會改變其動畫順序嗎？**

不會。圖形的 Z 軸順序僅控制重疊，而序列順序與觸發器控制動畫播放。若需不同的播放順序，請調整時間軸。