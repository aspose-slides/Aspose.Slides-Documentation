---
title: JavaScript Kullanarak Sunumlarda Şekil Animasyonları Uygulama
linktitle: Şekil Animasyonu
type: docs
weight: 60
url: /tr/nodejs-java/shape-animation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java ile şekil animasyonlarını, zamanlamayı, sesleri, animasyon sonrası davranışı ve animasyonlu metni eklemeyi, incelemeyi ve özelleştirmeyi öğrenin."
---
## **Genel Bakış**

Aspose.Slides for Node.js via Java, slayt animasyonlarını bir slayt zaman çizelgesindeki efektler olarak temsil eder. Bir efekt, hedef şekil, bir animasyon tipi ve alt tipi, bir tetikleyici, zamanlama ayarları ve ses veya animasyon sonrası davranış gibi isteğe bağlı özelliklere sahiptir.

Zaman çizelgesi iki tür sekans içerir:

- **ana sekans** slayt ilerledikçe oynatılır.
- **etkileşimli sekans** tetikleyici şekline tıklandığında başlar.

Metin kutuları, resimler, grafikler, tablolar ve diğer slayt nesneleri birer [Şekil](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/) olduğundan, çoğu slayt içeriği için aynı [Sequence.addEffect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sequence/#addEffect) yöntemini kullanırsınız. Kullanılabilir efektler [EffectType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/effecttype/) sayımında listelenir.

## **Şekil Animasyonları Ekle**

Bir animasyon eklemek için slaytın ana sekansını alın ve hedef şekil, efekt tipi, alt tip ve tetikleyiciyle [Sequence.addEffect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sequence/#addEffect) metodunu çağırın. Başka bir şekle tıklandığında başlayan bir efekt için, tetikleyicisi o diğer şekil olan bir etkileşimli sekans oluşturun.

Aşağıdaki örnek her iki tip animasyonu oluşturur ve sonucu `shape-animations.pptx` dosyasına kaydeder.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 120, 100, 320, 80);
    targetShape.addTextFrame("Click to animate this shape");

    const mainSequence = slide.getTimeline().getMainSequence();
    const entranceEffect = mainSequence.addEffect(targetShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    entranceEffect.getTiming().setDuration(java.newFloat(1.5));

    const triggerShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Bevel, 20, 20, 100, 40);
    triggerShape.addTextFrame("Move");

    const interactiveSequence = slide.getTimeline().getInteractiveSequences().add(triggerShape);
    interactiveSequence.addEffect(targetShape, aspose.slides.EffectType.PathFootball, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);

    presentation.save("shape-animations.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Tetikleyici, bir efektin ne zaman başlayacağını kontrol eder:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/effecttriggertype/#OnClick) ana sekans içinde bir tıklamayı veya etkileşimli sekans içinde tetikleyici şekle bir tıklamayı bekler.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/effecttriggertype/#WithPrevious) önceki efektle birlikte başlar.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/effecttriggertype/#AfterPrevious) önceki efekt tamamlandığında başlar.

Bir resim, grafik veya başka bir şekil türünü animasyonlamak için, `targetShape` yerine o nesneyi [Sequence.addEffect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sequence/#addEffect) metoduna geçirin. Grafik‑özel grup seçenekleri için [Animasyonlu Grafikler](/slides/tr/nodejs-java/animated-charts/) bölümüne bakın.

## **Şekil Animasyonlarını Okuma**

Hedef şekli bildiğinizde [Sequence.getEffectsByShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sequence/#getEffectsByShape) yöntemini kullanın. Tüm efektleri incelemek için ana sekansı ve her etkileşimli sekansı dolaşın. Dolaşma, bir sekansın `0` dizininde bir efekt içerdiği varsayımını ortadan kaldırır.

Aşağıdaki örnek bir şekil oluşturur, ana‑sekans ve etkileşimli efektler ekler, şekli hedefleyen efektleri alır ve ardından slayttaki tüm sekansları dolaşır.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

function getEnumName(enumType, value) {
    for (const [name, enumValue] of Object.entries(enumType)) {
        if (enumValue === value) {
            return name;
        }
    }

    return String(value);
}

function printSequence(label, sequence) {
    console.log(`  ${label}: ${sequence.getCount()} effect(s)`);

    for (let i = 0; i < sequence.getCount(); i++) {
        const effect = sequence.get_Item(i);
        const targetName = effect.getTargetShape() == null ? "unknown" : effect.getTargetShape().getName();
        const typeName = getEnumName(aspose.slides.EffectType, effect.getType());
        const subtypeName = getEnumName(aspose.slides.EffectSubtype, effect.getSubtype());
        const triggerName = getEnumName(aspose.slides.EffectTriggerType, effect.getTiming().getTriggerType());
        console.log(`    ${typeName} ${subtypeName}; target: ${targetName}; trigger: ${triggerName}`);
    }
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 120, 100, 320, 80);
    targetShape.addTextFrame("Animated shape");

    const mainSequence = slide.getTimeline().getMainSequence();
    mainSequence.addEffect(targetShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);

    const triggerShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Bevel, 20, 20, 100, 40);
    triggerShape.addTextFrame("Move");

    const interactiveSequence = slide.getTimeline().getInteractiveSequences().add(triggerShape);
    interactiveSequence.addEffect(targetShape, aspose.slides.EffectType.PathFootball, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);

    const targetEffects = mainSequence.getEffectsByShape(targetShape);
    console.log(`The main sequence contains ${targetEffects.length} effect(s) for ${targetShape.getName()}.`);

    printSequence("Main sequence", mainSequence);

    const interactiveSequences = slide.getTimeline().getInteractiveSequences();
    for (let i = 0; i < interactiveSequences.getCount(); i++) {
        const sequence = interactiveSequences.get_Item(i);
        const triggerName = sequence.getTriggerShape() == null ? "unknown" : sequence.getTriggerShape().getName();
        printSequence(`Interactive sequence ${i + 1}, trigger: ${triggerName}`, sequence);
    }
} finally {
    presentation.dispose();
}
```

Eğer sadece tek bir şekil için efektlere ihtiyacınız varsa, önce şekli ad, yer tutucu tipi veya başka bir sabit özellik ile tanımlayın; ardından [Sequence.getEffectsByShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sequence/#getEffectsByShape) metodunu çağırın. [ShapeCollection.get_Item](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shapecollection/#get_Item) dizin `0`'da her zaman istenen nesne olduğu varsayımında bulunmayın.

## **Türetilmiş Yer Tutucu Efektleri ile Çalışma**

Normal bir slayttaki bir yer tutucu, düzen slaytı ve ana slayttaki karşılık gelen yer tutucudan animasyon davranışını devralabilir. [Shape.getBasePlaceholder](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/#getBasePlaceholder) bu üst yer tutucuyu döndürür; üst yer tutucu yoksa `null` döner.

Aşağıdaki örnek sunumda altbilgi, normal slaytta **Random Bars**, düzen slaytta **Split**, ana slaytta ise **Fly In** animasyonuna sahiptir.

![Normal slayttaki altbilgi animasyon etkisi](slide-shape-animation.png)

![Düzen slayttaki altbilgi yer tutucu animasyon etkisi](layout-shape-animation.png)

![Ana slayttaki altbilgi yer tutucu animasyon etkisi](master-shape-animation.png)

Sonraki örnek yeni bir sunumda yer tutucu hiyerarşisini kullanır. Bir ana yer tutucuya, bir düzen yer tutucuya ve normal bir slayttaki karşılık gelen yer tutucuya efekt ekler. Her [Shape.getBasePlaceholder](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/#getBasePlaceholder) çağrısı, döndürülen şekil kullanılmadan önce kontrol edilir.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function findPlaceholderWithBase(baseSlide, expectedBase) {
    const shapes = baseSlide.getShapes();

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const basePlaceholder = shape.getBasePlaceholder();

        if (basePlaceholder == null) {
            continue;
        }

        if (expectedBase == null || basePlaceholder.getPlaceholder().getType() === expectedBase.getPlaceholder().getType()) {
            return shape;
        }
    }

    return null;
}

function getEnumName(enumType, value) {
    for (const [name, enumValue] of Object.entries(enumType)) {
        if (enumValue === value) {
            return name;
        }
    }

    return String(value);
}

function printEffects(source, effects) {
    console.log(`${source}: ${effects.length} effect(s)`);

    for (const effect of effects) {
        const typeName = getEnumName(aspose.slides.EffectType, effect.getType());
        const subtypeName = getEnumName(aspose.slides.EffectSubtype, effect.getSubtype());
        console.log(`  ${typeName} ${subtypeName}`);
    }
}

const presentation = new aspose.slides.Presentation();
try {
    const layoutSlide = presentation.getLayoutSlides().getByType(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject));
    const layoutPlaceholder = findPlaceholderWithBase(layoutSlide, null);

    if (layoutPlaceholder == null) {
        throw new Error("The layout slide does not contain a placeholder linked to its master slide.");
    }

    const masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
    layoutSlide.getMasterSlide().getTimeline().getMainSequence().addEffect(masterPlaceholder, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.Bottom, aspose.slides.EffectTriggerType.OnClick);
    layoutSlide.getTimeline().getMainSequence().addEffect(layoutPlaceholder, aspose.slides.EffectType.Split, aspose.slides.EffectSubtype.VerticalIn, aspose.slides.EffectTriggerType.OnClick);

    const slide = presentation.getSlides().addEmptySlide(layoutSlide);
    const slidePlaceholder = findPlaceholderWithBase(slide, layoutPlaceholder);

    if (slidePlaceholder == null) {
        throw new Error("The slide does not contain a placeholder linked to its layout slide.");
    }

    slide.getTimeline().getMainSequence().addEffect(slidePlaceholder, aspose.slides.EffectType.RandomBars, aspose.slides.EffectSubtype.Horizontal, aspose.slides.EffectTriggerType.OnClick);
    printEffects("Normal slide", slide.getTimeline().getMainSequence().getEffectsByShape(slidePlaceholder));

    const baseLayoutPlaceholder = slidePlaceholder.getBasePlaceholder();
    if (baseLayoutPlaceholder != null) {
        printEffects("Layout slide", layoutSlide.getTimeline().getMainSequence().getEffectsByShape(baseLayoutPlaceholder));

        const baseMasterPlaceholder = baseLayoutPlaceholder.getBasePlaceholder();
        if (baseMasterPlaceholder != null) {
            printEffects("Master slide", layoutSlide.getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(baseMasterPlaceholder));
        }
    }

    presentation.save("placeholder-animations.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Animasyon Zamanlamasını Değiştirme**

PowerPoint **Timing** iletişim kutusu, [Timing](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/timing/) özelliklerine karşılık gelir.

![Bir animasyon efekti için PowerPoint Timing iletişim kutusu](shape-animation.png)

- **Start** [Timing.getTriggerType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/timing/#getTriggerType) ile eşlenir.
- **Duration** [Timing.getDuration](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/timing/#getDuration) ile eşlenir; saniye cinsindendir.
- **Delay** [Timing.getTriggerDelayTime](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/timing/#getTriggerDelayTime) ile eşlenir; saniye cinsindendir.
- **Repeat** [Timing.getRepeatCount](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/timing/#getRepeatCount), [Timing.getRepeatUntilNextClick](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/timing/#getRepeatUntilNextClick) veya [Timing.getRepeatUntilEndSlide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/timing/#getRepeatUntilEndSlide) ile eşlenir.
- **Rewind when done playing** [Timing.getRewind](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/timing/#getRewind) ile eşlenir.

Bu bağımsız örnek bir efekt ekler, zamanlamasını [Sequence.addEffect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sequence/#addEffect) tarafından döndürülen nesne üzerinden değiştirir ve sonucu kaydeder. Döndürülen [Effect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/effect/) referansını tutmak, gereksiz bir sekans indeksinden kaçınmayı sağlar.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 120, 100, 320, 80);
    shape.addTextFrame("Timed animation");

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getTiming().setTriggerType(aspose.slides.EffectTriggerType.OnClick);
    effect.getTiming().setDuration(java.newFloat(2.0));
    effect.getTiming().setTriggerDelayTime(java.newFloat(0.5));
    effect.getTiming().setRepeatUntilNextClick(false);
    effect.getTiming().setRepeatUntilEndSlide(false);
    effect.getTiming().setRepeatCount(java.newFloat(2.0));
    effect.getTiming().setRewind(true);

    presentation.save("shape-animation-timing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Tek bir tekrar modunu bilinçli olarak kullanın. Tekrar sayısı ile bir “until” bayrağını birleştirmek, farklı izleyicilerde kafa karıştırıcı sonuçlar verebilir. Tekrar modlarını değiştirirken, [Timing.setRepeatUntilNextClick](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/timing/#setRepeatUntilNextClick) ve [Timing.setRepeatUntilEndSlide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/timing/#setRepeatUntilEndSlide) metodlarını, [Timing.setRepeatCount](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/timing/#setRepeatCount) çağırmadan önce ayarlayın; çünkü bu bayrakların herhangi birini ayarlamak aktif tekrar modunu da değiştirir.

## **Animasyon Seslerini Ekle ve Çıkar**

Bir animasyon efekti, gömülü ses dosyasına [Effect.getSound](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/effect/#getSound) üzerinden referans verebilir. [Effect.setStopPreviousSound](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/effect/#setStopPreviousSound) bir efekti, önceki bir efekt tarafından başlatılan sesi durdurması için talimat verir.

### **Bir Efekte Ses Ekleme**

Aşağıdaki örnek, `animation-sound.wav` adlı yerel bir ses dosyası bekler. İki efekt oluşturur, bu dosyayı ilk efektin sesi olarak gömer ve ikinci efekti sesi durduracak şekilde ayarlar. [Sequence.addEffect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sequence/#addEffect) tarafından döndürülen nesneler kullanıldığı için sekans indeksi gerekmez.

```javascript
const fs = require("fs");
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const firstShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 100, 240, 80);
    const secondShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 400, 100, 240, 80);
    firstShape.addTextFrame("Starts sound");
    secondShape.addTextFrame("Stops sound");

    const sequence = slide.getTimeline().getMainSequence();
    const firstEffect = sequence.addEffect(firstShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    const secondEffect = sequence.addEffect(secondShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);

    const audioData = java.newArray("byte", Array.from(fs.readFileSync("animation-sound.wav")));
    const effectSound = presentation.getAudios().addAudio(audioData);
    firstEffect.setSound(effectSound);
    secondEffect.setStopPreviousSound(true);

    presentation.save("shape-animation-sound.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Gömülü Efekt Seslerini Çıkarma**

Aşağıdaki örnek, `presentation-with-animation-sounds.pptx` adlı yerel bir sunum bekler. Hem ana hem de etkileşimli sekansları tarar ve her gömülü efekt sesini `extracted-animation-sounds` dizinine yazar. Uzantı, [Audio.getContentType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/audio/#getContentType) tarafından sağlanan ses MIME tipinden seçilir.

```javascript
const fs = require("fs");
const path = require("path");
const aspose = { slides: require("aspose.slides.via.java") };

function getAudioExtension(contentType) {
    const normalizedType = contentType == null ? "" : contentType.toLowerCase();

    if (normalizedType === "audio/mpeg") {
        return ".mp3";
    }

    if (normalizedType === "audio/mp4") {
        return ".m4a";
    }

    if (normalizedType === "audio/ogg") {
        return ".ogg";
    }

    if (normalizedType === "audio/wav" || normalizedType === "audio/x-wav") {
        return ".wav";
    }

    return ".bin";
}

function saveSounds(sequence, outputDirectory, soundIndex) {
    for (let i = 0; i < sequence.getCount(); i++) {
        const effect = sequence.get_Item(i);

        if (effect.getSound() == null) {
            continue;
        }

        const extension = getAudioExtension(effect.getSound().getContentType());
        const outputPath = path.join(outputDirectory, `effect-sound-${soundIndex}${extension}`);
        fs.writeFileSync(outputPath, Buffer.from(effect.getSound().getBinaryData()));
        soundIndex++;
    }

    return soundIndex;
}

const outputDirectory = "extracted-animation-sounds";
fs.mkdirSync(outputDirectory, { recursive: true });

const presentation = new aspose.slides.Presentation("presentation-with-animation-sounds.pptx");
try {
    let soundIndex = 1;

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        soundIndex = saveSounds(slide.getTimeline().getMainSequence(), outputDirectory, soundIndex);

        const interactiveSequences = slide.getTimeline().getInteractiveSequences();
        for (let sequenceIndex = 0; sequenceIndex < interactiveSequences.getCount(); sequenceIndex++) {
            soundIndex = saveSounds(interactiveSequences.get_Item(sequenceIndex), outputDirectory, soundIndex);
        }
    }

    console.log(`Extracted ${soundIndex - 1} sound file(s) to ${path.resolve(outputDirectory)}.`);
} finally {
    presentation.dispose();
}
```

Büyük ses nesneleri için, nesneyi bir bayt dizisine yüklemek yerine [Audio.getStream](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/audio/#getStream) kullanın ve akışı bir dosyaya kopyalayın.

## **Animasyon Sonrası Davranışı Ayarla**

**After animation** seçeneği, bir şeklin efekti bittikten sonra ne olacağını kontrol eder.

![PowerPoint Effect Options iletişim kutusunda After animation ayarları gösteriliyor](shape-after-animation.png)

[AfterAnimationType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/afteranimationtype/) sayımı, şekli değişmeden bırakma, rengini değiştirme, animasyondan sonra gizleme veya bir sonraki tıklamada gizleme gibi seçenekler sunar. Tipi [AfterAnimationType.Color](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/afteranimationtype/#Color) olarak ayarladığınızda, ayrıca [Effect.getAfterAnimationColor](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/effect/#getAfterAnimationColor) ayarlanmalıdır.

Bu bağımsız örnek bir efekt oluşturur, döndürülen efekt nesnesi üzerinden animasyon sonrası davranışı ayarlar ve sonucu kaydeder.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 120, 100, 320, 80);
    shape.addTextFrame("Dim after animation");

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.setAfterAnimationType(aspose.slides.AfterAnimationType.Color);
    effect.getAfterAnimationColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    presentation.save("shape-animation-after-effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[AfterAnimationType.Color](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/afteranimationtype/#Color) dışına bir tip seçmek, animasyon sonrası renk ayarını temizler.

## **Metni Animasyonla**

Metin animasyonunda iki ilgili kontrol bulunur:

- [TextAnimation.getBuildType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textanimation/#getBuildType), paragrafların birlikte mi yoksa paragraf düzeyinde mi görüneceğini belirler.
- [Effect.getAnimateTextType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/effect/#getAnimateTextType), metnin tamamen mi, kelime kelime mi yoksa harf harf mi görüneceğini belirler. [Effect.getDelayBetweenTextParts](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/effect/#getDelayBetweenTextParts), kelimeler veya harfler arasındaki gecikmeyi ayarlar. Pozitif bir değer, efekt süresinin yüzde değeri; negatif bir değer ise saniye cinsinden gecikmedir.

Aşağıdaki bağımsız örnek bir metin kutusundaki kelimeleri animasyonlaştırır. [BuildType.AsOneObject](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/buildtype/#AsOneObject), paragraf‑paragraf oluşturmayı devre dışı bırakır; böylece kelime ayarı tüm metin çerçevesine uygulanır.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 80, 560, 100);
    textBox.addTextFrame("Aspose.Slides animates this sentence word by word.");

    const effect = slide.getTimeline().getMainSequence().addEffect(textBox, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getTextAnimation().setBuildType(aspose.slides.BuildType.AsOneObject);
    effect.setAnimateTextType(aspose.slides.AnimateTextType.ByWord);
    effect.setDelayBetweenTextParts(java.newFloat(20.0));

    presentation.save("animated-text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Metin kutusunu paragraf bazında oluşturmak için [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/buildtype/#ByLevelParagraphs1) (veya başka bir paragraf seviyesi) ayarlayın. Tek bir paragrafı kendi efektiyle hedeflemek için, bir [Paragraph](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraph/) kabul eden [Sequence.addEffect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sequence/#addEffect) aşırı yüklemesini kullanın. Paragraf‑seviyesi örnekleri için [Animasyonlu Metin](/slides/tr/nodejs-java/animated-text/) bölümüne bakın.

## **Dışa Aktarma ve Uyumluluk Notları**

- PPT veya PPTX olarak kaydetmek animasyon modelini korur, ancak nihai oynatma sunum görüntüleyicisi tarafından kontrol edilir.
- PDF ve statik görüntüler animasyonları oynatmaz. Çıktının hareket göstermesi gerektiğinde [HTML5 dışa aktarımı](/slides/tr/nodejs-java/export-to-html5/), animasyonlu GIF veya [video dönüştürme](/slides/tr/nodejs-java/convert-powerpoint-to-video/) kullanın.
- HTML5 için, gerektiğinde [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/html5options/#setAnimateShapes) ve [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/html5options/#setAnimateTransitions) etkinleştirin.
- Video işleme, birçok yaygın giriş, vurgu, çıkış ve hareket‑yolu efektini destekler, ancak her PowerPoint efekti desteklenmez. Güncel [desteklenen animasyonlar ve efektler](/slides/tr/nodejs-java/convert-powerpoint-to-video/#supported-animations-and-effects) sayfasını kontrol edin ve kritik sunumları hedef Aspose.Slides sürümünüzle test edin.
- Gelişmiş özel efektler ve diğer sunum formatlarından içe aktarılan efektler dosyada korunabilir, ancak PowerPoint, HTML5 veya video ortamlarında farklı şekilde işlenebilir. Etki adını yalnızca temel almayın; dışa aktarılan sonucu doğrulayın.

## **SSS**

**Bir animasyon PowerPoint’te görünürken PDF’de neden görünmüyor?**

PDF statik bir formattır; animasyonlar ve slayt geçişleri oynatılmaz. Hareketin korunması gerektiğinde HTML5, animasyonlu GIF veya video olarak dışa aktarın.

**Bir efekt video içinde farklı şekilde oynatılıyor neden?**

Video dışa aktarımı, animasyonları render eder; orijinal PowerPoint davranışını saklamaz. Bazı gelişmiş efektler desteklenmez veya yaklaşık olarak işlenir. Desteklenen‑efektler tablosunu inceleyin ve gerçek sunumu üretim öncesi test edin.

**Bir şekli öne ya da arkaya taşımak animasyon sırasını değiştirir mi?**

Hayır. Şekil z‑sırası örtüşmeyi kontrol eder, sekans sırası ve tetikleyiciler animasyon oynatımını belirler. Farklı bir oynatma sırası gerekiyorsa zaman çizelgesini değiştirin.