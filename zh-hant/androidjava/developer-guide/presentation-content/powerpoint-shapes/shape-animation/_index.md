---
title: 在 Android 上的簡報中套用形狀動畫
linktitle: 形狀動畫
type: docs
weight: 60
url: /zh-hant/androidjava/shape-animation/
keywords:
- 形狀
- 動畫
- 效果
- 動畫形狀
- 動畫文字
- 新增動畫
- 取得動畫
- 擷取動畫
- 新增效果
- 取得效果
- 擷取效果
- 效果音效
- 套用動畫
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Android via Java 新增、檢查與自訂形狀動畫、時間設定、音效、動畫後行為，以及動畫文字。"
---
## **概觀**

若要處理效果內的個別行為或編輯移動路徑段，請參閱[Custom Animation for Java](/slides/zh-hant/java/custom-animation/)。

Aspose.Slides for Android via Java 將投影片動畫表示為投影片時間軸中的效果。一個效果具有目標形狀、動畫類型與子類型、觸發器、時間設定，以及聲音或動畫後行為等可選屬性。

時間軸包含兩種序列：

- **主序列** 會在投影片前進時播放。
- **互動序列** 會在其觸發形狀被點擊時開始。

因為文字方塊、圖片、圖表、表格以及其他投影片物件皆實作[IShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishape/)，您可以對大多數投影片內容使用相同的[ISequence.addEffect](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-)方法。可用的效果列於[EffectType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/effecttype/)類別中。

## **新增形狀動畫**

若要新增動畫，取得投影片的主序列，並以目標形狀、效果類型、子類型與觸發器呼叫[ISequence.addEffect](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-)。若效果在點擊其他形狀時開始，請建立其觸發形狀為該其他形狀的互動序列。

下列範例建立兩種動畫，並將結果儲存為`shape-animations.pptx`。

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

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/effecttriggertype/#OnClick) 等待主序列中的點擊，或在互動序列中等待觸發形狀的點擊。
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/effecttriggertype/#WithPrevious) 與前一個效果同時開始。
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/effecttriggertype/#AfterPrevious) 在前一個效果結束時開始。

若要讓圖片、圖表或其他形狀類型產生動畫，請將該物件傳遞給[ISequence.addEffect](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-)而非`targetShape`。關於圖表專屬的分組選項，請參閱[Animated Charts](/slides/zh-hant/androidjava/animated-charts/)。

## **讀取形狀動畫**

當您已知目標形狀時，使用[ISequence.getEffectsByShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-)。若要檢查每個效果，請列舉主序列與所有互動序列。列舉可避免假設序列在索引`0`處一定有效果。

下列範例建立一個同時具有主序列與互動效果的形狀，取得目標該形狀的效果，然後列舉投影片上的每個序列。

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

如果只需要單一形狀的效果，請先依名稱、佔位類型或其他穩定屬性識別該形狀；接著呼叫[ISequence.getEffectsByShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-)。不要假設在索引`0`的[IShapeCollection.get_Item](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishapecollection/#get_Item-int-)必定是目標物件。

## **使用繼承的佔位符效果**

一般投影片上的佔位符可以繼承其版面投影片與母版投影片上相對應佔位符的動畫行為。[IShape.getBasePlaceholder](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishape/#getBasePlaceholder--)會傳回該父佔位符，若不存在則傳回`null`。

在下列範例簡報中，頁腳在一般投影片上使用**Random Bars**，在版面投影片上使用**Split**，在母版投影片上使用**Fly In**。

![一般投影片上的頁腳動畫效果](slide-shape-animation.png)

![版面投影片上的頁腳佔位符動畫效果](layout-shape-animation.png)

![母版投影片上的頁腳佔位符動畫效果](master-shape-animation.png)

下一個範例使用新簡報中的佔位符階層。它會對母版佔位符、版面佔位符以及一般投影片上對應的佔位符加入效果。每次呼叫[IShape.getBasePlaceholder](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishape/#getBasePlaceholder--)前，都會檢查返回的形狀是否為null。

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

PowerPoint 的**Timing**對話方塊對應到[ITiming](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itiming/)的屬性。

![PowerPoint 動畫效果的 Timing 對話方塊](shape-animation.png)

- **Start** 對應到[ITiming.getTriggerType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itiming/#getTriggerType--)。
- **Duration** 對應到[ITiming.getDuration](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itiming/#getDuration--)，以秒為單位。
- **Delay** 對應到[ITiming.getTriggerDelayTime](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itiming/#getTriggerDelayTime--)，以秒為單位。
- **Repeat** 對應到[ITiming.getRepeatCount](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itiming/#getRepeatCount--)、[ITiming.getRepeatUntilNextClick](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itiming/#getRepeatUntilNextClick--)或[ITiming.getRepeatUntilEndSlide](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itiming/#getRepeatUntilEndSlide--)。
- **Rewind when done playing** 對應到[ITiming.getRewind](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itiming/#getRewind--)。

此獨立範例加入一個效果，透過由[ISequence.addEffect](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-)回傳的物件變更其時間設定，並儲存結果。保留返回的[IEffect](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ieffect/)參考，可避免不必要的集合索引。

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

請有意只使用一種重複模式。將重複次數與「until」旗標同時使用，可能在不同的檢視器中產生混淆的結果。變更重複模式時，請先設定[ITiming.setRepeatUntilNextClick](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itiming/#setRepeatUntilNextClick-boolean-)與[ITiming.setRepeatUntilEndSlide](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itiming/#setRepeatUntilEndSlide-boolean-)，再設定[ITiming.setRepeatCount](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itiming/#setRepeatCount-float-)，因為設定任一旗標都會更改目前的重複模式。

## **新增與擷取動畫聲音**

動畫效果可以透過[IEffect.getSound](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ieffect/#getSound--)參照嵌入的音訊。[IEffect.setStopPreviousSound](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ieffect/#setStopPreviousSound-boolean-) 可指示效果停止先前效果啟動的音訊。

### **將聲音加入效果**

下列範例需要一個名為`animation-sound.wav`的本機音訊檔。它會建立兩個效果，將該檔案嵌入為第一個效果的聲音，並設定第二個效果停止該聲音。它使用由[ISequence.addEffect](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-)回傳的物件，無需提供序列索引。

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

下列範例需要一個名為`presentation-with-animation-sounds.pptx`的本機簡報。它會掃描主序列與互動序列，將所有嵌入的效果聲音寫入`extracted-animation-sounds`目錄。副檔名依據[IAudio.getContentType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iaudio/#getContentType--)所回傳的音訊MIME類型選擇。

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

對於大型音訊物件，請使用[IAudio.getStream](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iaudio/#getStream--)，將串流複製到檔案，而不是將整個物件載入為位元組陣列。

## **設定動畫後行為**

**After animation**選項控制形狀在效果結束後的處理方式。

![PowerPoint 效果選項對話方塊顯示 After animation 設定](shape-after-animation.png)

[AfterAnimationType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/afteranimationtype/)類別支援保持形狀不變、更改其顏色、動畫結束後隱藏，或在下一次點擊時隱藏。當類型為[AfterAnimationType.Color](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/afteranimationtype/#Color)時，亦需設定[IEffect.getAfterAnimationColor](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ieffect/#getAfterAnimationColor--)。

此獨立範例建立一個效果，透過返回的效果物件設定其動畫後行為，並儲存結果。

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

將類型改為非[AfterAnimationType.Color](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/afteranimationtype/#Color)會清除動畫後的顏色設定。

## **動畫文字**

文字動畫有兩個相關控制項：

- [ITextAnimation.getBuildType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itextanimation/#getBuildType--) 控制段落是一次顯示還是依段落層級顯示。
- [IEffect.getAnimateTextType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ieffect/#getAnimateTextType--) 控制文字是一次全部顯示、逐字或逐字母顯示。[IEffect.getDelayBetweenTextParts](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ieffect/#getDelayBetweenTextParts--) 設定字詞或字母之間的延遲。正值表示效果持續時間的百分比；負值則為秒數延遲。

下列獨立範例為文字方塊中的字詞加入動畫。[BuildType.AsOneObject](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/buildtype/#AsOneObject) 會停用逐段落建構，使字詞設定套用於整個文字框。

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

若要逐段落建構文字方塊，請設定[BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/buildtype/#ByLevelParagraphs1)（或其他段落層級）。若要對單一段落套用獨立效果，請使用接受[IParagraph](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iparagraph/)的[ISequence.addEffect](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IParagraph-int-int-int-)重載。參閱[Animated Text](/slides/zh-hant/androidjava/animated-text/)取得段落層級的範例。

## **匯出與相容性說明**

- 儲存為 PPT 或 PPTX 可保留動畫模型，但最終播放由簡報檢視程式控制。
- PDF 與靜態圖像不會播放動畫。若輸出必須呈現動態，請使用[HTML5 export](/slides/zh-hant/androidjava/export-to-html5/)、動畫 GIF，或[video conversion](/slides/zh-hant/androidjava/convert-powerpoint-to-video/)。
- 若輸出為 HTML5，請啟用[Html5Options.setAnimateShapes](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-)，必要時亦啟用[Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-)。
- 影片轉換支援許多常見的進場、強調、退出與移動路徑效果，但並非所有 PowerPoint 效果皆受支援。請檢查目前的[supported animations and effects](/slides/zh-hant/androidjava/convert-powerpoint-to-video/#supported-animations-and-effects)，並以目標 Aspose.Slides 版本測試關鍵簡報。
- 進階自訂效果與從其他簡報格式匯入的效果可能會保留在檔案中，但在 PowerPoint、HTML5 或影片中呈現方式可能不同。請驗證匯出結果，而非僅依賴效果名稱。

## **常見問題**

**為何動畫在 PowerPoint 中會顯示，但在 PDF 中不顯示？**

PDF 為靜態格式，故不會播放動畫與投影片過場。若必須保留動態，請匯出為 HTML5、動畫 GIF 或影片。

**為何效果在影片中播放不同？**

影片匯出會渲染動畫，而非儲存原始 PowerPoint 行為。某些進階效果未受支援或會被近似呈現。請查閱支援的效果表，並在正式使用前測試實際簡報。

**將形狀前移或後移會改變其動畫順序嗎？**

不會。形狀的 Z 軸順序僅影響重疊，而序列順序與觸發器決定動畫播放。若需要不同的播放順序，請調整時間軸。