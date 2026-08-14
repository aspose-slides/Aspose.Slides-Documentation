---
title: Sunumlarda Java Kullanarak Şekil Animasyonları Uygulama
linktitle: Şekil Animasyonu
type: docs
weight: 60
url: /tr/java/shape-animation/
keywords:
- şekil
- animasyon
- efekt
- canlandırılmış şekil
- canlandırılmış metin
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
description: "Aspose.Slides for Java ile şekil animasyonlarını ekleme, inceleme ve özelleştirme, zamanlama, sesler, animasyon sonrası davranış ve canlandırılmış metin konularını öğrenin."
---
## **Genel Bakış**

Aspose.Slides for Java, slayt animasyonlarını bir slayt zaman çizelgesindeki efektler olarak temsil eder. Bir efektin hedef şekli, bir animasyon türü ve alt türü, bir tetikleyici, zamanlama ayarları ve ses ya da animasyon sonrası davranış gibi isteğe bağlı özellikleri vardır.

Zaman çizelgesi iki tür dizi içerir:

- **Ana dizi**, slayt ilerledikçe oynatılır.
- **Etkileşimli dizi**, tetikleyici şekli tıklandığında başlar.

Metin kutuları, resimler, grafikler, tablolar ve diğer slayt nesneleri [IShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/) uygular, bu nedenle çoğu slayt içeriği için aynı [ISequence.addEffect](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) yöntemini kullanırsınız. Mevcut efektler [EffectType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/effecttype/) sınıfında listelenir.

## **Şekil Animasyonları Ekleme**

Bir animasyon eklemek için slaytın ana dizisini alın ve hedef şekil, efekt türü, alt tür ve tetikleyici ile [ISequence.addEffect](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) yöntemini çağırın. Başka bir şekil tıklandığında başlayan bir efekt için, tetikleyicisi o diğer şekil olan bir etkileşimli dizi oluşturun.

Aşağıdaki örnek hem ana hem de etkileşimli animasyon tiplerini oluşturur ve sonucu `shape-animations.pptx` dosyasına kaydeder.

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

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/tr/java/com.aspose.slides/effecttriggertype/#OnClick) ana dizide bir tıklamayı veya etkileşimli dizide tetikleyici şeklin tıklanmasını bekler.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/tr/java/com.aspose.slides/effecttriggertype/#WithPrevious) önceki efektle birlikte başlar.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/tr/java/com.aspose.slides/effecttriggertype/#AfterPrevious) önceki efekt bittiğinde başlar.

Bir resmi, grafiği veya başka bir şekil türünü canlandırmak için, `targetShape` yerine o nesneyi [ISequence.addEffect](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) yöntemine geçirin. Grafiklere özgü grup seçenekleri için [Animated Charts](/slides/tr/java/animated-charts/) bölümüne bakın.

## **Şekil Animasyonlarını Okuma**

Hedef şekli bildiğinizde [ISequence.getEffectsByShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-) yöntemini kullanın. Her bir efekti incelemek için ana diziyi ve tüm etkileşimli dizileri dolaşın. Dizi içindeki bir efektin `0` indeksinde bulunduğunu varsaymaktan kaçının.

Aşağıdaki örnek bir şekle ana‑dizi ve etkileşimli efektler ekler, şekli hedefleyen efektleri alır ve ardından slayttaki her diziyi dolaşır.

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

Yalnızca tek bir şekil için efektlere ihtiyacınız varsa, önce şekli adı, yer tutucu türü veya başka bir sabit özelliğiyle belirleyin; ardından [ISequence.getEffectsByShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-) yöntemini çağırın. [IShapeCollection.get_Item](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishapecollection/#get_Item-int-) öğesinin `0` indeksindeki öğenin her zaman istenen nesne olduğunu varsaymayın.

## **Miras Alınan Yer Tutucu Efektleriyle Çalışma**

Normal bir slayttaki bir yer tutucu, düzen slaytındaki ve ana slayttaki karşılık gelen yer tutucudan animasyon davranışı miras alabilir. [IShape.getBasePlaceholder](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/#getBasePlaceholder--) bu üst yer tutucuyu döndürür; üst yoksa `null` verir.

Aşağıdaki örnek sunumda, normal slaytta altbilgi **Random Bars**, düzen slaytta **Split**, ana slaytta ise **Fly In** efektine sahiptir.

![Normal slayttaki altbilgi animasyon efekti](slide-shape-animation.png)

![Düzen slayttaki altbilgi yer tutucu animasyon efekti](layout-shape-animation.png)

![Ana slayttaki altbilgi yer tutucu animasyon efekti](master-shape-animation.png)

Sonraki örnek, yeni bir sunumdan bir yer tutucu hiyerarşisi kullanır. Bir ana yer tutucuya, bir düzen yer tutucuya ve normal slayttaki karşılık gelen yer tutucuya efekt ekler. Her [IShape.getBasePlaceholder](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/#getBasePlaceholder--) çağrısı, döndürülen şekil kullanılmadan önce kontrol edilir.

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

## **Animasyon Zamanlamasını Değiştirme**

PowerPoint **Timing** iletişim kutusu, [ITiming](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itiming/) özelliklerine karşılık gelir.

![Bir animasyon efekti için PowerPoint Zamanlama iletişim kutusu](shape-animation.png)

- **Start** [ITiming.getTriggerType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itiming/#getTriggerType--) ile eşleşir.
- **Duration** [ITiming.getDuration](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itiming/#getDuration--) ile eşleşir, saniye cinsindendir.
- **Delay** [ITiming.getTriggerDelayTime](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itiming/#getTriggerDelayTime--) ile eşleşir, saniye cinsindendir.
- **Repeat** [ITiming.getRepeatCount](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itiming/#getRepeatCount--) , [ITiming.getRepeatUntilNextClick](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itiming/#getRepeatUntilNextClick--) veya [ITiming.getRepeatUntilEndSlide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itiming/#getRepeatUntilEndSlide--) ile eşleşir.
- **Rewind when done playing** [ITiming.getRewind](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itiming/#getRewind--) ile eşleşir.

Bu bağımsız örnek bir efekt ekler, zamanlamasını [ISequence.addEffect](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) tarafından döndürülen nesne üzerinden değiştirir ve sonucu kaydeder. Döndürülen [IEffect](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ieffect/) referansını saklamak, gereksiz bir dizi indeksinden kaçınmayı sağlar.

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

Tek bir tekrar modunu kasıtlı olarak kullanın. Tekrar sayısını bir “until” bayrağıyla birleştirmek, farklı görüntüleyicilerde karışık sonuçlar doğurabilir. Tekrar modlarını değiştirirken, önce [ITiming.setRepeatUntilNextClick](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itiming/#setRepeatUntilNextClick-boolean-) ve [ITiming.setRepeatUntilEndSlide](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itiming/#setRepeatUntilEndSlide-boolean-) ayarlayın, ardından [ITiming.setRepeatCount](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itiming/#setRepeatCount-float-) metodunu çağırın; çünkü bu bayraklardan biri ayarlandığında etkin tekrar modu da değişir.

## **Animasyon Seslerini Ekleme ve Çıkarma**

Bir animasyon efekti, gömülü ses dosyasına [IEffect.getSound](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ieffect/#getSound--) aracılığıyla başvurabilir. [IEffect.setStopPreviousSound](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ieffect/#setStopPreviousSound-boolean-) bir efektin önceki efekt tarafından başlatılan sesleri durdurmasını sağlar.

### **Bir Efekte Ses Ekleme**

Aşağıdaki örnek, `animation-sound.wav` adlı yerel bir ses dosyası olduğunu varsayar. İki efekt oluşturur, bu dosyayı ilk efektin sesi olarak gömer ve ikinci efekti sesi durduracak şekilde yapılandırır. [ISequence.addEffect](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) tarafından döndürülen nesneler kullanıldığı için dizi indeksi gerekmez.

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

### **Gömülü Efekt Seslerini Çıkarma**

Aşağıdaki örnek, `presentation-with-animation-sounds.pptx` adlı yerel bir sunum olduğunu varsayar. Hem ana hem de etkileşimli dizileri tarar ve her gömülü efekt sesini `extracted-animation-sounds` klasörüne yazar. Uzantı, [IAudio.getContentType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iaudio/#getContentType--) tarafından sağlanan ses MIME türünden seçilir.

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

Büyük ses nesneleri için, tüm nesneyi bayt dizisine yüklemek yerine [IAudio.getStream](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iaudio/#getStream--) kullanıp akışı bir dosyaya kopyayın.

## **Animasyon Sonrası Davranışı Ayarlama**

**After animation** seçeneği, bir şeklin etkisi bittiğinde ne olacağını belirler.

![PowerPoint Etki Seçenekleri iletişim kutusunda After animation ayarları gösteriliyor](shape-after-animation.png)

[AfterAnimationType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/afteranimationtype/) sınıfı, şeklin değişmeden kalması, renginin değiştirilmesi, animasyondan sonra gizlenmesi veya bir sonraki tıklamada gizlenmesi gibi seçenekleri destekler. Tür [AfterAnimationType.Color](https://reference.aspose.com/slides/tr/java/com.aspose.slides/afteranimationtype/#Color) olduğunda, ayrıca [IEffect.getAfterAnimationColor](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ieffect/#getAfterAnimationColor--) ayarlanmalıdır.

Bu bağımsız örnek bir efekt oluşturur, after‑animation davranışını döndürülen efekt nesnesi üzerinden ayarlar ve sonucu kaydeder.

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

[AfterAnimationType.Color](https://reference.aspose.com/slides/tr/java/com.aspose.slides/afteranimationtype/#Color) dışındaki bir türe geçmek, after‑animation renk ayarını temizler.

## **Metni Canlandırma**

Metin animasyonu iki ilgili denetimi içerir:

- [ITextAnimation.getBuildType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itextanimation/#getBuildType--), paragrafların birlikte mi yoksa paragraf seviyesinde mi görüneceğini kontrol eder.
- [IEffect.getAnimateTextType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ieffect/#getAnimateTextType--) , metnin tüm olarak, kelime bazında veya harf bazında görünüp görünmeyeceğini kontrol eder. [IEffect.getDelayBetweenTextParts](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ieffect/#getDelayBetweenTextParts--) kelime ya da harfler arasındaki gecikmeyi ayarlar. Pozitif bir değer, efekt süresinin yüzdesi; negatif bir değer ise saniye cinsinden gecikmedir.

Aşağıdaki bağımsız örnek bir metin kutusundaki kelimeleri canlandırır. [BuildType.AsOneObject](https://reference.aspose.com/slides/tr/java/com.aspose.slides/buildtype/#AsOneObject) paragraf‑paragraf oluşturmayı devre dışı bırakır, böylece kelime ayarı tüm metin çerçevesine uygulanır.

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

Paragraflar halinde bir metin kutusu oluşturmak için [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/tr/java/com.aspose.slides/buildtype/#ByLevelParagraphs1) (veya başka bir paragraf seviyesi) ayarlayın. Tek bir paragrafı kendi etkisiyle hedeflemek için, [ISequence.addEffect](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IParagraph-int-int-int-) aşırı yüklemesini kullanın ve bir [IParagraph](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iparagraph/) geçirin. Paragraf‑seviyesi örnekleri için [Animated Text](/slides/tr/java/animated-text/) bölümüne bakın.

## **Dışa Aktarma ve Uyumluluk Notları**

- PPT veya PPTX olarak kaydetmek animasyon modelini korur, ancak nihai oynatma sunum görüntüleyicisi tarafından kontrol edilir.
- PDF ve statik görüntüler animasyonları oynatmaz. Çıktının hareket göstermesi gerekiyorsa [HTML5 export](/slides/tr/java/export-to-html5/), animasyonlu GIF veya [video conversion](/slides/tr/java/convert-powerpoint-to-video/) kullanın.
- HTML5 için, gerekli olduğunda [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/tr/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) ve [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) özelliklerini etkinleştirin.
- Video oluşturma, pek çok yaygın giriş, vurgu, çıkış ve hareket‑yolu efektini destekler, ancak her PowerPoint efekti desteklenmez. Mevcut [supported animations and effects](/slides/tr/java/convert-powerpoint-to-video/#supported-animations-and-effects) tablosunu kontrol edin ve kritik sunumları hedef Aspose.Slides sürümünüzle test edin.
- Gelişmiş özel efektler ve diğer sunum formatlarından içe aktarılan efektler dosyada korunabilir ancak PowerPoint, HTML5 veya video ortamlarında farklı şekilde işlenebilir. Yalnızca efekt adını temel alarak değil, dışa aktarılan sonucu doğrulayın.

## **SSS**

**Bir animasyon PowerPoint’te görünüyor ancak PDF’de neden görünmüyor?**

PDF sabit bir format olduğundan animasyonlar ve slayt geçişleri oynatılamaz. Hareketin korunması gerektiğinde HTML5, animasyonlu GIF veya video olarak dışa aktarın.

**Bir efekt video dosyasında farklı neden oynatılıyor?**

Video dışa aktarımı, animasyonları orijinal PowerPoint davranışı yerine render eder. Bazı gelişmiş efektler desteklenmez veya yaklaşık olarak uygulanır. Desteklenen efektler tablosunu inceleyin ve üretim öncesinde gerçek sunumu test edin.

**Bir şekli öne ya da arkaya taşıma, animasyon sırasını değiştirir mi?**

Hayır. Şeklin z‑order’ı üst üste binmeyi kontrol eder, dizi sırası ve tetikleyiciler animasyon oynatımını belirler. Farklı bir oynatma sırası ihtiyacınız varsa zaman çizelgesini değiştirin.