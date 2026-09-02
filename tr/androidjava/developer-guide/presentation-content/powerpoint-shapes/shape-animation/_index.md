---
title: Android'de Sunumlarda Şekil Animasyonlarını Uygulama
linktitle: Şekil Animasyonu
type: docs
weight: 60
url: /tr/androidjava/shape-animation/
keywords:
- şekil
- animasyon
- efekt
- animasyonlu şekil
- animasyonlu metin
- animasyon ekle
- animasyon al
- animasyonu çıkar
- efekt ekle
- efekti al
- efekti çıkar
- efekt sesi
- animasyonu uygula
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java ile şekil animasyonları, zamanlama, sesler, animasyon sonrası davranış ve animasyonlu metin ekleme, inceleme ve özelleştirme konularını öğrenin."
---
## **Genel Bakış**

Aspose.Slides for Android via Java, slayt animasyonlarını bir slayt zaman çizelgesindeki efektler olarak temsil eder. Bir efektin hedef şekli, animasyon türü ve alt türü, tetikleyicisi, zamanlama ayarları ve ses ya da animasyon sonrası davranış gibi isteğe bağlı özellikleri vardır.

Zaman çizelgesi iki tür dizi içerir:

- **Ana dizi** slayt ilerledikçe oynatılır.
- **Etkileşimli dizi** tetikleyici şekli tıklandığında başlar.

Metin kutuları, resimler, grafikler, tablolar ve diğer slayt nesneleri [IShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/) uyguladığından, çoğu slayt içeriği için aynı [ISequence.addEffect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) yöntemini kullanırsınız. Mevcut efektler [EffectType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/effecttype/) sınıfında listelenmiştir.

## **Şekil Animasyonları Ekle**

Bir animasyon eklemek için slaydın ana dizisini alın ve hedef şekil, efekt türü, alt tür ve tetikleyici ile [ISequence.addEffect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) yöntemini çağırın. Başka bir şekil tıklandığında başlayan bir efekt için, tetikleyicisi o diğer şekil olan bir etkileşimli dizi oluşturun.

Aşağıdaki örnek her iki tip animasyonu oluşturur ve sonucu `shape-animations.pptx` dosyasına kaydeder.

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

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/effecttriggertype/#OnClick) ana dizide bir tıklama ya da etkileşimli dizide tetikleyici şekle tıklanmasını bekler.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/effecttriggertype/#WithPrevious) önceki efektle birlikte başlar.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/effecttriggertype/#AfterPrevious) önceki efekt bitince başlar.

Bir resmi, grafiği veya başka bir şekil türünü canlandırmak için, `targetShape` yerine o nesneyi [ISequence.addEffect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) yöntemine geçirin. Grafik‑özel grup seçenekleri için [Animated Charts](/slides/tr/androidjava/animated-charts/) bölümüne bakın.

## **Şekil Animasyonlarını Oku**

Hedef şekli bildiğinizde [ISequence.getEffectsByShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-) yöntemini kullanın. Tüm efektleri incelemek için ana diziyi ve her etkileşimli diziyi dolaşın. Dizi taraması, bir dizinin `0` indeksinde bir efekt olduğu varsayımını ortadan kaldırır.

Aşağıdaki örnek bir şekil oluşturur, ana‑dizi ve etkileşimli efektler ekler, şekle hedeflenen efektleri alır ve ardından slayttaki tüm dizileri dolaşır.

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

Yalnızca tek bir şekil için efektlere ihtiyacınız varsa, şekli önce adı, yer tutucu tipi veya başka bir sabit özelliğiyle tanımlayın; ardından [ISequence.getEffectsByShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-) metodunu çağırın. `[IShapeCollection.get_Item](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishapecollection/#get_Item-int-)` metodunun `0` indeksindeki öğesinin her zaman istenen nesne olduğunu varsamamalısınız.

## **Kalıtılmış Yer Tutucu Efektleriyle Çalışma**

Normal bir slayttaki bir yer tutucu, düzen slaytı ve ana slayttaki karşılık gelen yer tutucudan animasyon davranışı miras alabilir. [IShape.getBasePlaceholder](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/#getBasePlaceholder--) yöntemi bu üst yer tutucuyu döndürür; üst yoksa `null` döner.

Aşağıdaki örnek sunumda, alt bilgi normal slaytta **Random Bars**, düzen slaytında **Split** ve ana slaytta **Fly In** efekti alır.

![Normal slaytta altbilgi animasyon efekti](slide-shape-animation.png)

![Düzen slaytındaki altbilgi yer tutucu animasyon efekti](layout-shape-animation.png)

![Ana slayttaki altbilgi yer tutucu animasyon efekti](master-shape-animation.png)

Sonraki örnek yeni bir sunumdan bir yer tutucu hiyerarşisi kullanır. Bir ana yer tutucuya, bir düzen yer tutucuya ve normal slayttaki karşılık gelen yer tutucuya efekt ekler. [IShape.getBasePlaceholder](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/#getBasePlaceholder--) çağrısı, döndürülen şekil kullanılmadan önce kontrol edilir.

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

PowerPoint **Timing** (Zamanlama) iletişim kutusu, [ITiming](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itiming/) özelliklerine karşılık gelir.

![Bir animasyon efekti için PowerPoint Zamanlama iletişim kutusu](shape-animation.png)

- **Başlat** [ITiming.getTriggerType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itiming/#getTriggerType--) ile eşleştirilir.
- **Süre** [ITiming.getDuration](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itiming/#getDuration--) ile eşleştirilir, saniye cinsinden.
- **Gecikme** [ITiming.getTriggerDelayTime](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itiming/#getTriggerDelayTime--) ile eşleştirilir, saniye cinsinden.
- **Tekrar** [ITiming.getRepeatCount](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itiming/#getRepeatCount--), [ITiming.getRepeatUntilNextClick](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itiming/#getRepeatUntilNextClick--), veya [ITiming.getRepeatUntilEndSlide](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itiming/#getRepeatUntilEndSlide--) ile eşleştirilir.
- **Oynatma tamamlandığında geri sar** [ITiming.getRewind](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itiming/#getRewind--) ile eşleştirilir.

Bu bağımsız örnek bir efekt ekler, zamanlamasını [ISequence.addEffect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) tarafından döndürülen nesne aracılığıyla değiştirir ve sonucu kaydeder. Döndürülen [IEffect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ieffect/) referansının tutulması gereksiz bir koleksiyon indeksinden kaçınır.

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

Tek bir tekrar modunu kasıtlı olarak kullanın. Tekrar sayısını bir “until” bayrağıyla birleştirmek, farklı görüntüleyicilerde kafa karıştırıcı sonuçlar doğurabilir. Tekrar modlarını değiştirirken, önce [ITiming.setRepeatUntilNextClick](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itiming/#setRepeatUntilNextClick-boolean-) ve [ITiming.setRepeatUntilEndSlide](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itiming/#setRepeatUntilEndSlide-boolean-) ayarlarını, ardından [ITiming.setRepeatCount](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itiming/#setRepeatCount-float-) yöntemini çağırın; çünkü bu bayraklardan birini ayarlamak aktif tekrar modunu da değiştirir.

## **Animasyon Seslerini Ekle ve Çıkar**

Bir animasyon efekti, gömülü sesi [IEffect.getSound](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ieffect/#getSound--) aracılığıyla referans gösterebilir. [IEffect.setStopPreviousSound](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ieffect/#setStopPreviousSound-boolean-) bir efektin önceki bir efekt tarafından başlatılan sesi durdurmasını sağlar.

### **Bir Efekte Ses Ekle**

Aşağıdaki örnek, `animation-sound.wav` adlı yerel bir ses dosyası bekler. İki efekt oluşturur, bu dosyayı ilk efektin sesi olarak gömer ve ikinci efekti sesi durduracak şekilde yapılandırır. [ISequence.addEffect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) tarafından döndürülen nesneler kullanıldığından dizi indeksine ihtiyaç yoktur.

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

Aşağıdaki örnek, `presentation-with-animation-sounds.pptx` adlı yerel bir sunum bekler. Hem ana hem de etkileşimli dizileri tarar ve gömülü her efekti `extracted-animation-sounds` dizinine yazar. Uzantı, [IAudio.getContentType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iaudio/#getContentType--) tarafından sağlanan ses MIME tipinden seçilir.

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

Büyük ses nesneleri için, tüm nesneyi bayt dizisine yüklemek yerine [IAudio.getStream](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iaudio/#getStream--) ile akışı alın ve bir dosyaya kopyalayın.

## **Animasyon Sonrası Davranışı Ayarla**

**After animation** (Animasyon Sonrası) seçeneği, bir şeklin efekt bitiminde ne olacağını denetler.

![PowerPoint Efekt Seçenekleri iletişim kutusunda After animation ayarlarını gösteriyor](shape-after-animation.png)

[AfterAnimationType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/afteranimationtype/) sınıfı, şekli değişmeden bırakma, rengini değiştirme, animasyondan sonra gizleme veya bir sonraki tıklamada gizleme seçeneklerini destekler. Tür [AfterAnimationType.Color](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/afteranimationtype/#Color) ise, ayrıca [IEffect.getAfterAnimationColor](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ieffect/#getAfterAnimationColor--) ayarlanmalıdır.

Bu bağımsız örnek bir efekt oluşturur, döndürülen efekt nesnesi aracılığıyla animasyon sonrası davranışını ayarlar ve sonucu kaydeder.

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

[AfterAnimationType.Color](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/afteranimationtype/#Color) dışına bir tür değiştirildiğinde, animasyon sonrası renk ayarı temizlenir.

## **Metni Canlandır**

Metin animasyonu iki ilgili kontrol içerir:

- [ITextAnimation.getBuildType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextanimation/#getBuildType--) paragrafın topluca mı yoksa paragraf seviyesinde mi görüneceğini denetler.
- [IEffect.getAnimateTextType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ieffect/#getAnimateTextType--) metnin bir seferde, kelime bazında veya harf bazında görüneceğini denetler. [IEffect.getDelayBetweenTextParts](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ieffect/#getDelayBetweenTextParts--) kelime ya da harfler arasındaki gecikmeyi ayarlar. Pozitif değer, efekt süresinin yüzdesi; negatif değer ise saniye cinsinden gecikmedir.

Aşağıdaki bağımsız örnek bir metin kutusundaki kelimeleri canlandırır. [BuildType.AsOneObject](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/buildtype/#AsOneObject) paragraf‑paragraf oluşturmayı devre dışı bırakır, böylece kelime ayarı tüm metin çerçevesine uygulanır.

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

Paragraf bazında bir metin kutusu oluşturmak için [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/buildtype/#ByLevelParagraphs1) (veya başka bir paragraf seviyesi) ayarlayın. Tek bir paragrafı kendi efektine hedeflemek için, bir [IParagraph](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iparagraph/) kabul eden [ISequence.addEffect](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IParagraph-int-int-int-) aşırı yüklemesini kullanın. Paragraf‑seviyesindeki örnekler için [Animated Text](/slides/tr/androidjava/animated-text/) bölümüne bakın.

## **Dışa Aktarma ve Uyumluluk Notları**

- PPT veya PPTX olarak kaydetmek animasyon modelini korur, ancak nihai oynatma sunum görüntüleyicisi tarafından kontrol edilir.
- PDF ve statik görüntüler animasyonları oynatmaz. Çıktının hareket göstermesi gerektiğinde [HTML5 export](/slides/tr/androidjava/export-to-html5/), animasyonlu GIF veya [video conversion](/slides/tr/androidjava/convert-powerpoint-to-video/) kullanın.
- HTML5 için, gerektiğinde [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) ve [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) özelliklerini etkinleştirin.
- Video renderlama, birçok yaygın giriş, vurgu, çıkış ve hareket‑yolu efektini destekler, ancak tüm PowerPoint efektleri desteklenmez. Güncel [supported animations and effects](/slides/tr/androidjava/convert-powerpoint-to-video/#supported-animations-and-effects) sayfasını kontrol edin ve kritik sunumları hedef Aspose.Slides sürümünüzle test edin.
- Gelişmiş özel efektler ve diğer sunum formatlarından içe aktarılan efektler dosyada korunabilir ancak PowerPoint, HTML5 veya videoda farklı renderlenebilir. Efekt adına yalnızca güvenmek yerine dışa aktarılan sonucu doğrulayın.

## **SSS**

**Bir animasyon PowerPoint’te görünürken PDF’de neden görünmüyor?**  
PDF statik bir format olduğundan animasyonlar ve slayt geçişleri oynatılmaz. Hareketin korunması gerektiğinde HTML5, animasyonlu GIF veya video olarak dışa aktarın.

**Bir efekt video içinde farklı şekilde neden oynatılıyor?**  
Video dışa aktarımı, animasyonları renderlar ve orijinal PowerPoint davranışını depolamaz. Bazı gelişmiş efektler desteklenmez veya yaklaşık olarak uygulanır. Desteklenen‑efektler tablosunu inceleyin ve üretime geçmeden önce gerçek sunumu test edin.

**Bir şekli öne ya da arkaya taşımak animasyon sırasını değiştirir mi?**  
Hayır. Şekil z‑order’ı örtüşmeyi kontrol eder, dizi sırası ve tetikleyiciler animasyon oynatımını belirler. Farklı bir oynatma sırası gerekiyorsa zaman çizelgesini değiştirin.