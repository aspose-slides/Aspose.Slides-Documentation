---
title: Java Kullanarak Sunumlarda Şekil Animasyonlarını Uygulama
linktitle: Şekil Animasyonu
type: docs
weight: 60
url: /tr/java/shape-animation/
keywords:
- şekil
- animasyon
- efekt
- animasyonlu şekil
- animasyonlu metin
- animasyon ekle
- animasyon al
- animasyon çıkar
- efekt ekle
- efekt al
- efekt çıkar
- efekt sesi
- animasyon uygula
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile şekil animasyonlarını, zamanlamayı, sesleri, animasyon sonrası davranışı ve animasyonlu metni eklemeyi, incelemeyi ve özelleştirmeyi öğrenin."
---
## **Genel Bakış**

Bir etki içindeki bireysel davranışlarla çalışmak veya hareket yolu bölümlerini düzenlemek için, bkz. [Custom Animation](/slides/tr/java/custom-animation/).

Aspose.Slides for Java, slayt animasyonlarını bir slayt zaman çizelgesindeki efektler olarak temsil eder. Bir efektin hedef şekli, bir animasyon türü ve alt türü, bir tetikleyicisi, zamanlama ayarları ve ses ya da animasyon sonrası davranış gibi isteğe bağlı özellikleri vardır.

Zaman çizelgesi iki tür sıralama içerir:

- **ana sıra** slayt ilerledikçe oynatılır.
- **etkileşimli sıralama**, tetikleyici şekli tıklandığında başlar.

Metin kutuları, resimler, grafikler, tablolar ve diğer slayt nesneleri [IShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/)​'i uyguladıkları için, çoğu slayt içeriği için aynı [ISequence.addEffect](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-)​ metodunu kullanırsınız. Kullanılabilir efektler [EffectType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/effecttype/)​ sınıfında listelenmiştir.

## **Şekil Animasyonları Ekle**

Bir animasyon eklemek için slaytın ana sıralamasını alın ve hedef şekil, efekt türü, alt tür ve tetikleyici ile [ISequence.addEffect](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-)​ metodunu çağırın. Başka bir şekil tıklandığında başlayan bir efekt için, tetikleyicisi o diğer şekil olan bir etkileşimli sıralama oluşturun.

Aşağıdaki örnek her iki tür animasyonu oluşturur ve sonucu `shape-animations.pptx` dosyasına kaydeder.

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

Tetikleyici, bir efektin ne zaman başlayacağını kontrol eder:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/tr/java/com.aspose.slides/effecttriggertype/#OnClick)​ ana sırada bir tıklama ya da etkileşimli sırada tetikleyici şekle tıklama bekler.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/tr/java/com.aspose.slides/effecttriggertype/#WithPrevious)​ önceki efektle birlikte başlar.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/tr/java/com.aspose.slides/effecttriggertype/#AfterPrevious)​ önceki efekt bittiğinde başlar.

Bir resmi, grafiği veya başka bir şekil türünü canlandırmak için, `targetShape` yerine o nesneyi [ISequence.addEffect](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-)​ metoduna geçirin. Grafiklere özgü gruplama seçenekleri için bkz. [Animated Charts](/slides/tr/java/animated-charts/).

## **Şekil Animasyonlarını Oku**

Hedef şekli bildiğinizde [ISequence.getEffectsByShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-)​ metodunu kullanın. Her efekti incelemek için ana sırayı ve tüm etkileşimli sıralamaları döngüye alın. Döngü, bir sıralamanın `0` indeksinde bir efekt içerdiği varsayımını önler.

Aşağıdaki örnek bir şekil oluşturur, ana‑sıra ve etkileşimli efektler ekler, şekli hedefleyen efektleri alır ve ardından slayttaki tüm sıralamaları döngüye alır.

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

Yalnızca bir şeklin efektlerine ihtiyacınız varsa, önce şekli ad, yer tutucu tipi veya başka bir sabit özellik ile tanımlayın; ardından [ISequence.getEffectsByShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-)​ metodunu çağırın. [IShapeCollection.get_Item](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishapecollection/#get_Item-int-)​ indeks `0`'ın her zaman istenen nesne olduğunu varsamaktan kaçının.

## **Miras Alınan Yer Tutucu Efektleri ile Çalışma**

Normal bir slayttaki bir yer tutucu, düzen slaytı ve ana slayttaki ilgili yer tutucudan animasyon davranışını miras alabilir. [IShape.getBasePlaceholder](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/#getBasePlaceholder--)​ bu üst yer tutucuyu döndürür; üst yoksa `null` döner.

Aşağıdaki örnek sunumda altbilgi normal slaytta **Random Bars**, düzen slaytta **Split** ve ana slaytta **Fly In** efektlerine sahiptir.

![Normal slaytta altbilgi animasyon efekti](slide-shape-animation.png)

![Düzen slaytında altbilgi yer tutucu animasyon efekti](layout-shape-animation.png)

![Ana slaytta altbilgi yer tutucu animasyon efekti](master-shape-animation.png)

Sonraki örnek yeni bir sunumdan bir yer tutucu hiyerarşisi kullanır. Bir ana yer tutucuya, bir düzen yer tutucuya ve normal slayttaki karşılık gelen yer tutucuya efektler ekler. [IShape.getBasePlaceholder](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/#getBasePlaceholder--)​ metodunun her çağrısı, döndürülen şekil kullanılmadan önce kontrol edilir.

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

## **Animasyon Zamanlamasını Değiştir**

PowerPoint **Timing**​ iletişim kutusu, [ITiming](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itiming/)​ özellikleriyle eşleşir.

![Bir animasyon efekti için PowerPoint Zamanlama iletişim kutusu](shape-animation.png)

- **Start**​ [ITiming.getTriggerType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itiming/#getTriggerType--)​ metoduna karşılık gelir.
- **Duration**​ [ITiming.getDuration](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itiming/#getDuration--)​ metoduna karşılık gelir; saniye cinsindendir.
- **Delay**​ [ITiming.getTriggerDelayTime](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itiming/#getTriggerDelayTime--)​ metoduna karşılık gelir; saniye cinsindendir.
- **Repeat**​ [ITiming.getRepeatCount](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itiming/#getRepeatCount--)​, [ITiming.getRepeatUntilNextClick](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itiming/#getRepeatUntilNextClick--)​ veya [ITiming.getRepeatUntilEndSlide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itiming/#getRepeatUntilEndSlide--)​ metodlarından birine karşılık gelir.
- **Rewind when done playing**​ [ITiming.getRewind](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itiming/#getRewind--)​ metoduna karşılık gelir.

Bu bağımsız örnek bir efekt ekler, zamanlamasını [ISequence.addEffect](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-)​ metodundan dönen nesne üzerinden değiştirir ve sonucu kaydeder. Döndürülen [IEffect](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ieffect/)​ referansını tutmak gereksiz bir koleksiyon indeksinden kaçınır.

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

Tek bir tekrarlama modunu bilinçli olarak kullanın. Tekrar sayısını bir “until” bayrağıyla birleştirmek farklı izleyicilerde kafa karıştırıcı sonuçlar doğurabilir. Tekrar modlarını değiştirirken, [ITiming.setRepeatUntilNextClick](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itiming/#setRepeatUntilNextClick-boolean-)​ ve [ITiming.setRepeatUntilEndSlide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itiming/#setRepeatUntilEndSlide-boolean-)​ metodlarını [ITiming.setRepeatCount](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itiming/#setRepeatCount-float-)​ metodundan önce ayarlayın; çünkü bu bayraklardan birini ayarlamak aktif tekrar modunu da değiştirir.

## **Animasyon Sesleri Ekle ve Çıkar**

Bir animasyon efekti, [IEffect.getSound](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ieffect/#getSound--)​ aracılığıyla gömülü ses referans gösterebilir. [IEffect.setStopPreviousSound](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ieffect/#setStopPreviousSound-boolean-)​ bir efektin, önceki bir efekt tarafından başlatılan sesi durdurmasını sağlar.

### **Bir Efekte Ses Ekle**

Aşağıdaki örnek, `animation-sound.wav` adlı yerel bir ses dosyası bekler. İki efekt oluşturur, bu dosyayı ilk efektin sesi olarak gömer ve ikinci efekti sesi durduracak şekilde yapılandırır. [ISequence.addEffect](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-)​ metodundan dönen nesneleri kullandığından bir sıralama indeksi gerektirmez.

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

### **Gömülü Efekt Seslerini Çıkar**

Aşağıdaki örnek, `presentation-with-animation-sounds.pptx` adlı yerel bir sunum bekler. Hem ana hem de etkileşimli sıralamaları tarar ve her gömülü efekt sesini `extracted-animation-sounds` dizinine yazar. Uzantı, [IAudio.getContentType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iaudio/#getContentType--)​ tarafından sunulan ses MIME tipinden seçilir.

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

Büyük ses nesneleri için, nesneyi bir bayt dizisine yüklemek yerine akışı bir dosyaya kopyalamak amacıyla [IAudio.getStream](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iaudio/#getStream--)​ metodunu kullanın.

## **Animasyon Sonrası Davranışı Ayarla**

**After animation**​ seçeneği, bir şeklin efekti tamamlandıktan sonra ne olacağını belirler.

![PowerPoint Efekt Seçenekleri iletişim kutusunda After animation ayarlarını gösterir](shape-after-animation.png)

[AfterAnimationType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/afteranimationtype/)​ sınıfı, şekli değiştirmeden bırakma, rengini değiştirme, animasyondan sonra gizleme veya bir sonraki tıklamada gizleme seçeneklerini destekler. Tip [AfterAnimationType.Color](https://reference.aspose.com/slides/tr/java/com.aspose.slides/afteranimationtype/#Color)​ olduğunda, ayrıca [IEffect.getAfterAnimationColor](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ieffect/#getAfterAnimationColor--)​ de ayarlanmalıdır.

Bu bağımsız örnek bir efekt oluşturur, dönen efekt nesnesi üzerinden animasyon sonrası davranışı ayarlar ve sonucu kaydeder.

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

[AfterAnimationType.Color](https://reference.aspose.com/slides/tr/java/com.aspose.slides/afteranimationtype/#Color)​ tipini başka bir tipe değiştirirseniz, animasyon sonrası renk ayarı temizlenir.

## **Metni Canlandır**

Metin animasyonunun iki ilgili kontrolü vardır:

- [ITextAnimation.getBuildType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextanimation/#getBuildType--)​ paragrafın birlikte mi yoksa paragraf seviyesinde mi görüneceğini kontrol eder.
- [IEffect.getAnimateTextType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ieffect/#getAnimateTextType--)​ metnin bir kerede, kelime bazında ya da harf bazında görünüp görünmeyeceğini kontrol eder. [IEffect.getDelayBetweenTextParts](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ieffect/#getDelayBetweenTextParts--)​ kelimeler ya da harfler arasındaki gecikmeyi ayarlar. Pozitif bir değer, efekt süresinin yüzdesi; negatif bir değer ise saniye cinsinden gecikmedir.

Aşağıdaki bağımsız örnek bir metin kutusundaki kelimeleri canlandırır. [BuildType.AsOneObject](https://reference.aspose.com/slides/tr/java/com.aspose.slides/buildtype/#AsOneObject)​ paragraf‑paragraf inşa etmeyi devre dışı bırakır, böylece kelime ayarı tüm metin çerçevesine uygulanır.

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

Paragraf bazında bir metin kutusu oluşturmak için [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/tr/java/com.aspose.slides/buildtype/#ByLevelParagraphs1)​ (veya başka bir paragraf seviyesi) ayarlayın. Kendi efektine sahip tek bir paragrafı hedeflemek için, bir [IParagraph](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iparagraph/)​ kabul eden [ISequence.addEffect](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IParagraph-int-int-int-)​ aşırı yüklemesini kullanın. Paragraf‑seviyesi örnekleri için bkz. [Animated Text](/slides/tr/java/animated-text/).

## **Dışa Aktarım ve Uyumluluk Notları**

- PPT veya PPTX olarak kaydetmek animasyon modelini korur, ancak nihai oynatma sunum görüntüleyicisi tarafından kontrol edilir.
- PDF ve statik görseller animasyonları oynatmaz. Çıktının hareket göstermesi gerektiğinde [HTML5 export](/slides/tr/java/export-to-html5/), animasyonlu GIF veya [video conversion](/slides/tr/java/convert-powerpoint-to-video/) kullanın.
- HTML5 için, [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/tr/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-)​ özelliğini ve gerektiğinde [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-)​ özelliğini etkinleştirin.
- Video renderı, birçok yaygın giriş, vurgu, çıkış ve hareket yolu efektini destekler, ancak her PowerPoint efekti desteklenmez. Mevcut [supported animations and effects](/slides/tr/java/convert-powerpoint-to-video/#supported-animations-and-effects)​ sayfasını kontrol edin ve kritik sunumları hedef Aspose.Slides sürümünüzle test edin.
- Gelişmiş özel efektler ve diğer sunum formatlarından içe aktarılan efektler dosyada korunabilir ancak PowerPoint, HTML5 veya videoda farklı görüntülenebilir. Sonucu yalnızca efekt adına dayanarak değil, dışa aktarılan sonucu doğrulayarak değerlendirin.

## **SSS**

**Neden bir animasyon PowerPoint'te görünüyor ama PDF'de görünmüyor?**

PDF statik bir format olduğundan animasyonlar ve slayt geçişleri oynatılmaz. Hareketin korunması gerektiğinde HTML5, animasyonlu GIF veya video olarak dışa aktarın.

**Neden bir efekt video içinde farklı oynatılıyor?**

Video dışa aktarımı animasyonları renderlar, orijinal PowerPoint davranışını depolamaz. Bazı gelişmiş efektler desteklenmez veya yaklaşık olarak işlenir. Desteklenen efektler tablosunu inceleyin ve üretim öncesinde gerçek sunumu test edin.

**Bir şekli öne ya da geriye taşıma animasyon sırasını değiştirir mi?**

Hayır. Şeklin z‑order'ı üst üste binmeyi kontrol eder, sıralama order'ı ve tetikleyiciler animasyon oynatımını kontrol eder. Farklı bir oynatma sırası gerekiyorsa zaman çizelgesini değiştirin.