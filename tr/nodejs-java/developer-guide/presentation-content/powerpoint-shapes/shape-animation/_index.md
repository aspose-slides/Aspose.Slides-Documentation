---
title: JavaScript Kullanarak Sunumlarda Şekil Animasyonlarını Uygulama
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
- animasyon çıkart
- efekt ekle
- efekt al
- efekt çıkart
- efekt sesi
- animasyon uygula
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java ile şekil animasyonlarını, zamanlamayı, sesleri, animasyon sonrası davranışı ve animasyonlu metni nasıl ekleyeceğinizi, inceleyeceğinizi ve özelleştireceğinizi öğrenin."
---
## **Genel Bakış**

Bir efekt içindeki bireysel davranışlarla çalışmak veya hareket yolu bölümlerini düzenlemek için [Özel Animasyon](/slides/tr/nodejs-java/custom-animation/) sayfasına bakın.

Aspose.Slides for Node.js via Java, slayt animasyonlarını bir slayt zaman çizelgesindeki efektler olarak temsil eder. Bir efektin hedef şekli, animasyon türü ve alt türü, tetikleyicisi, zamanlama ayarları ve ses ya da animasyon sonrası davranış gibi isteğe bağlı özellikleri vardır.

Zaman çizelgesi iki tür dizi içerir:

- **Ana dizi**, slayt ilerledikçe oynatılır.
- **Etkileşimli dizi**, tetikleyici şekli tıklandığında başlar.

Metin kutuları, resimler, grafikler, tablolar ve diğer slayt nesneleri [Shape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/) nesneleri olduğundan, çoğu slayt içeriği için aynı [Sequence.addEffect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sequence/#addEffect) metodunu kullanırsınız. Kullanılabilir efektler [EffectType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/effecttype/) enumunda listelenmiştir.

## **Şekil Animasyonları Ekleme**

Bir animasyon eklemek için slaytın ana dizisini alın ve hedef şekil, efekt türü, alt tür ve tetikleyici ile [Sequence.addEffect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sequence/#addEffect) metodunu çağırın. Başka bir şekil tıklandığında başlayan bir efekt için, tetikleyicisi o diğer şekil olan bir etkileşimli dizi oluşturun.

Aşağıdaki örnek her iki animasyon türünü oluşturur ve sonucu `shape-animations.pptx` dosyasına kaydeder.

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

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/effecttriggertype/#OnClick) ana dizide bir tıklama ya da etkileşimli dizide tetikleyici şekle bir tıklama bekler.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/effecttriggertype/#WithPrevious) önceki efektle birlikte başlar.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/effecttriggertype/#AfterPrevious) önceki efekt bittiğinde başlar.

Bir resim, grafik veya başka bir şekil türünü animasyonlamak için, `targetShape` yerine o nesneyi [Sequence.addEffect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sequence/#addEffect) metoduna gönderin. Grafiklere özgü grup seçenekleri için [Animasyonlu Grafikler](/slides/tr/nodejs-java/animated-charts/) sayfasına bakın.

## **Şekil Animasyonlarını Okuma**

Hedef şekli bildiğinizde [Sequence.getEffectsByShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sequence/#getEffectsByShape) metodunu kullanın. Tüm efektleri incelemek için ana diziyi ve her etkileşimli diziyi döngüyle gezinin. Dizi içinde indeks `0`‑da bir efekt olduğu varsayımından kaçının.

Aşağıdaki örnek bir şekle ana‑dizi ve etkileşimli efektler ekler, şekle yönelik efektleri alır ve ardından slayttaki tüm dizileri döngüyle listeler.

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

Sadece tek bir şeklin efektlerine ihtiyacınız varsa, önce şekli ad, yer tutucu türü ya da başka bir sabit özellik ile bulun; ardından [Sequence.getEffectsByShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sequence/#getEffectsByShape) metodunu çağırın. [ShapeCollection.get_Item](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shapecollection/#get_Item) indeks `0`‑da her zaman istenen nesnenin olduğunu varsaymayın.

## **Kalıtılan Yer Tutucu Efektleriyle Çalışma**

Normal bir slayttaki bir yer tutucu, düzen slaytı ve ana slayt üzerindeki karşılık gelen yer tutucudan animasyon davranışı miras alabilir. [Shape.getBasePlaceholder](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/#getBasePlaceholder) bu üst yer tutucuyu döndürür; üst yoksa `null` döner.

Aşağıdaki örnek sunumda, alt bilgi normal slaytta **Random Bars**, düzen slaytta **Split** ve ana slaytta **Fly In** efektlerine sahiptir.

![Normal slayttaki alt bilgi animasyon efekti](slide-shape-animation.png)

![Düzen slayttaki alt bilgi yer tutucu animasyon efekti](layout-shape-animation.png)

![Ana slayttaki alt bilgi yer tutucu animasyon efekti](master-shape-animation.png)

Bir sonraki örnek yeni bir sunumdaki yer tutucu hiyerarşisini kullanır. Bir ana yer tutucu, bir düzen yer tutucu ve normal slayttaki karşılık gelen yer tutucuya efekt ekler. Her [Shape.getBasePlaceholder](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/#getBasePlaceholder) çağrısı, döndürülen şekil kullanılmadan önce kontrol edilir.

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

PowerPoint **Timing** iletişim kutusu, [Timing](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/timing/) özelliklerine eşlenir.

![Bir animasyon efekti için PowerPoint Timing iletişim kutusu](shape-animation.png)

- **Start** [Timing.getTriggerType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/timing/#getTriggerType) ile eşlenir.
- **Duration** [Timing.getDuration](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/timing/#getDuration) ile saniye cinsinden eşlenir.
- **Delay** [Timing.getTriggerDelayTime](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/timing/#getTriggerDelayTime) ile saniye cinsinden eşlenir.
- **Repeat** [Timing.getRepeatCount](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/timing/#getRepeatCount), [Timing.getRepeatUntilNextClick](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/timing/#getRepeatUntilNextClick) ya da [Timing.getRepeatUntilEndSlide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/timing/#getRepeatUntilEndSlide) ile eşlenir.
- **Rewind when done playing** [Timing.getRewind](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/timing/#getRewind) ile eşlenir.

Bu bağımsız örnek bir efekt ekler, zamanlamasını [Sequence.addEffect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sequence/#addEffect) tarafından döndürülen nesne aracılığıyla değiştirir ve sonucu kaydeder. Döndürülen [Effect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/effect/) referansının tutulması, gereksiz bir koleksiyon indeksinden kaçınır.

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

Tek bir yineleme modunu kasıtlı olarak kullanın. Bir yineleme sayısını bir “kadar” bayrağı ile birleştirmek farklı izleyicilerde karışık sonuçlar doğurabilir. Tekrar modlarını değiştirirken, önce [Timing.setRepeatUntilNextClick](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/timing/#setRepeatUntilNextClick) ve [Timing.setRepeatUntilEndSlide](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/timing/#setRepeatUntilEndSlide) ayarlayın, ardından [Timing.setRepeatCount](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/timing/#setRepeatCount) metodunu çağırın; çünkü bayraklardan birini ayarlamak aktif tekrar modunu da değiştirir.

## **Animasyon Seslerini Ekleme ve Çıkarma**

Bir animasyon efekti, gömülü ses dosyasına [Effect.getSound](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/effect/#getSound) aracılığıyla başvurabilir. [Effect.setStopPreviousSound](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/effect/#setStopPreviousSound), bir efektin daha önceki bir efekt tarafından başlatılan sesi durdurmasını sağlar.

### **Bir Efekte Ses Ekleme**

Aşağıdaki örnek, `animation-sound.wav` adlı yerel bir ses dosyası olduğunu varsayar. İki efekt oluşturur, bu dosyayı ilk efektin sesi olarak gömer ve ikinci efekti sesi durduracak şekilde yapılandırır. [Sequence.addEffect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sequence/#addEffect) tarafından döndürülen nesneler kullanıldığından dizi indeksi gerekmez.

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

Aşağıdaki örnek, `presentation-with-animation-sounds.pptx` adlı yerel bir sunum olduğunu varsayar. Hem ana hem de etkileşimli dizileri tarar ve her gömülü efekt sesini `extracted-animation-sounds` klasörüne yazar. Uzantı, [Audio.getContentType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/audio/#getContentType) tarafından bildirilen ses MIME tipinden seçilir.

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

Büyük ses nesneleri için, nesneyi bir bayt dizisine yüklemek yerine [Audio.getStream](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/audio/#getStream) kullanıp akışı bir dosyaya kopyalayın.

## **Animasyon Sonrası Davranışı Ayarlama**

**After animation** seçeneği, bir şeklin efekti tamamlandıktan sonra ne olacağını kontrol eder.

![PowerPoint Efekt Seçenekleri iletişim kutusunda After animation ayarları gösteriliyor](shape-after-animation.png)

[AfterAnimationType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/afteranimationtype/) enumı, şekli değiştirmeden bırakma, rengini değiştirme, animasyondan sonra gizleme veya bir sonraki tıklamada gizleme seçeneklerini destekler. Tür [AfterAnimationType.Color](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/afteranimationtype/#Color) olduğunda, ayrıca [Effect.getAfterAnimationColor](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/effect/#getAfterAnimationColor) ayarlanmalıdır.

Bu bağımsız örnek bir efekt oluşturur, after‑animation davranışını döndürülen efekt nesnesi üzerinden ayarlar ve sonucu kaydeder.

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

[AfterAnimationType.Color](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/afteranimationtype/#Color) dışına bir tür seçildiğinde, after‑animation renk ayarı temizlenir.

## **Metni Animasyonlu Hale Getirme**

Metin animasyonunda iki ilgili kontrol bulunur:

- [TextAnimation.getBuildType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/textanimation/#getBuildType), paragrafların birlikte mi yoksa paragraf seviyesinde mi görüneceğini belirler.
- [Effect.getAnimateTextType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/effect/#getAnimateTextType), metnin bir kerede, kelime bazında ya da harf bazında görünmesini kontrol eder. [Effect.getDelayBetweenTextParts](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/effect/#getDelayBetweenTextParts) kelime ya da harfler arasındaki gecikmeyi ayarlar. Pozitif değer, efekt süresinin yüzde olarak; negatif değer ise saniye cinsinden gecikmedir.

Aşağıdaki bağımsız örnek bir metin kutusundaki kelimeleri animasyonlar. [BuildType.AsOneObject](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/buildtype/#AsOneObject), kelime ayarının tüm metin çerçevesine uygulanması için paragraf‑paragraf oluşturmayı devre dışı bırakır.

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

Bir metin kutusunu paragraf bazında oluşturmak için [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/buildtype/#ByLevelParagraphs1) (veya başka bir paragraf seviyesi) ayarlayın. Tek bir paragrafı kendi etkisiyle hedeflemek için [Sequence.addEffect](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sequence/#addEffect) metodunun [Paragraph](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/paragraph/) parametresi alan aşırı yüklemesini kullanın. Paragraf‑seviyesi örnekleri için [Animasyonlu Metin](/slides/tr/nodejs-java/animated-text/) sayfasına bakın.

## **Dışa Aktarma ve Uyumluluk Notları**

- PPT veya PPTX olarak kaydetmek animasyon modelini korur, ancak nihai oynatma sunum görüntüleyicisi tarafından kontrol edilir.
- PDF ve sabit görseller animasyonları oynatmaz. Çıktının hareket göstermesi gerektiğinde [HTML5 dışa aktarımı](/slides/tr/nodejs-java/export-to-html5/), animasyonlu GIF veya [video dönüşümü](/slides/tr/nodejs-java/convert-powerpoint-to-video/) kullanın.
- HTML5 için, [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/html5options/#setAnimateShapes) etkinleştirin ve gerektiğinde [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/html5options/#setAnimateTransitions) ayarını yapın.
- Video işleme, birçok yaygın giriş, vurgu, çıkış ve hareket‑yolu efektini destekler, ancak her PowerPoint efekti desteklenmez. Mevcut [desteklenen animasyonlar ve efektler](/slides/tr/nodejs-java/convert-powerpoint-to-video/#supported-animations-and-effects) sayfasını kontrol edin ve kritik sunumları hedef Aspose.Slides sürümünüzle test edin.
- Özel gelişmiş efektler ve diğer sunum formatlarından içe aktarılmış efektler dosyada korunabilir ancak PowerPoint, HTML5 veya video ortamlarında farklı şekilde işlenebilir. Yalnızca efekt adına güvenmek yerine dışa aktarılan sonucu doğrulayın.

## **SSS**

**Bir animasyon PowerPoint’te görünüyor ama PDF’de neden görünmüyor?**

PDF statik bir formattır; bu nedenle animasyonlar ve slayt geçişleri oynatılmaz. Hareketin korunması gerektiğinde HTML5, animasyonlu GIF veya video olarak dışa aktarın.

**Bir efekt video içinde farklı neden oynatılıyor?**

Video dışa aktarımı animasyonları işler, orijinal PowerPoint davranışını saklamaz. Bazı gelişmiş efektler desteklenmez ya da yaklaşık olarak oluşturulur. Desteklenen‑efektler tablosunu inceleyin ve üretim öncesinde gerçek sunumu test edin.

**Bir şekli ileri ya da geri taşımak animasyon sırasını değiştirir mi?**

Hayır. Şekil z‑order’ı üst üste binmeyi kontrol eder, dizi sırası ve tetikleyiciler animasyon oynatımını belirler. Farklı bir oynatma sırası gerekiyorsa zaman çizelgesini değiştirin.