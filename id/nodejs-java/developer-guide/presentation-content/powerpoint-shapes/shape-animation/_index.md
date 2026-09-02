---
title: Terapkan Animasi Bentuk pada Presentasi Menggunakan JavaScript
linktitle: Animasi Bentuk
type: docs
weight: 60
url: /id/nodejs-java/shape-animation/
keywords:
- bentuk
- animasi
- efek
- bentuk animasi
- teks animasi
- tambahkan animasi
- dapatkan animasi
- ekstrak animasi
- tambahkan efek
- dapatkan efek
- ekstrak efek
- suara efek
- terapkan animasi
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Pelajari cara menambahkan, memeriksa, dan menyesuaikan animasi bentuk, pengaturan waktu, suara, perilaku setelah animasi, serta teks animasi dengan Aspose.Slides untuk Node.js via Java."
---
## **Gambaran Umum**

Aspose.Slides for Node.js via Java merepresentasikan animasi slide sebagai efek dalam timeline slide. Sebuah efek memiliki shape target, tipe animasi dan subtipe, pemicu, pengaturan waktu, serta properti opsional seperti suara atau perilaku setelah animasi.

Timeline berisi dua jenis urutan:

- **urutan utama** dimainkan saat slide maju.
- **urutan interaktif** dimulai ketika shape pemicunya diklik.

Karena kotak teks, gambar, diagram, tabel, dan objek slide lainnya adalah objek [Shape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/) , Anda menggunakan metode yang sama [Sequence.addEffect](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sequence/#addEffect) untuk kebanyakan konten slide. Efek yang tersedia tercantum dalam enumerasi [EffectType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/effecttype/) .

## **Menambahkan Animasi Shape**

Untuk menambahkan animasi, dapatkan urutan utama slide dan panggil [Sequence.addEffect](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sequence/#addEffect) dengan shape target, tipe efek, subtipe, dan pemicu. Untuk efek yang dimulai ketika shape lain diklik, buat urutan interaktif yang pemicunya adalah shape tersebut.

Contoh berikut membuat kedua jenis animasi dan menyimpan hasilnya ke `shape-animations.pptx`.

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

Pemicu mengontrol kapan efek dimulai:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/effecttriggertype/#OnClick) menunggu klik di urutan utama, atau klik pada shape pemicu di urutan interaktif.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/effecttriggertype/#WithPrevious) dimulai bersamaan dengan efek sebelumnya.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/effecttriggertype/#AfterPrevious) dimulai ketika efek sebelumnya selesai.

Untuk menganimasikan gambar, diagram, atau tipe shape lain, berikan objek tersebut ke [Sequence.addEffect](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sequence/#addEffect) alih-alih `targetShape`. Untuk opsi pengelompokan khusus diagram, lihat [Animated Charts](/slides/id/nodejs-java/animated-charts/) .

## **Membaca Animasi Shape**

Gunakan [Sequence.getEffectsByShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sequence/#getEffectsByShape) ketika Anda mengetahui shape target. Untuk memeriksa setiap efek, enumerasikan urutan utama dan setiap urutan interaktif. Enumerasi menghindari asumsi bahwa urutan berisi efek pada indeks `0`.

Contoh berikut membuat sebuah shape dengan efek urutan utama dan interaktif, mendapatkan efek yang menargetkan shape tersebut, lalu mengenumerasikan setiap urutan pada slide.

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

Jika Anda hanya memerlukan efek untuk satu shape, pertama identifikasi shape tersebut berdasarkan nama, tipe placeholder, atau properti stabil lainnya; lalu panggil [Sequence.getEffectsByShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sequence/#getEffectsByShape). Jangan mengasumsikan bahwa [ShapeCollection.get_Item](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shapecollection/#get_Item) pada indeks `0` selalu merupakan objek yang dimaksud.

## **Bekerja dengan Efek Placeholder yang Diwarisi**

Sebuah placeholder pada slide normal dapat mewarisi perilaku animasi dari placeholder yang bersesuaian pada slide tata letak dan master. [Shape.getBasePlaceholder](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/#getBasePlaceholder) mengembalikan placeholder induk tersebut, atau `null` bila tidak ada induk.

Pada presentasi contoh berikut, footer memiliki **Random Bars** pada slide normal, **Split** pada slide tata letak, dan **Fly In** pada slide master.

![Efek animasi footer pada slide normal](slide-shape-animation.png)

![Efek animasi placeholder footer pada slide tata letak](layout-shape-animation.png)

![Efek animasi placeholder footer pada slide master](master-shape-animation.png)

Contoh berikutnya menggunakan hierarki placeholder dari presentasi baru. Ia menambahkan efek ke placeholder master, placeholder tata letak, dan placeholder yang bersesuaian pada slide normal. Setiap pemanggilan [Shape.getBasePlaceholder](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/#getBasePlaceholder) diperiksa sebelum shape yang dikembalikan digunakan.

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

## **Mengubah Pengaturan Waktu Animasi**

Dialog **Timing** di PowerPoint dipetakan ke properti [Timing](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/timing/) .

![Dialog Timing PowerPoint untuk sebuah efek animasi](shape-animation.png)

- **Start** dipetakan ke [Timing.getTriggerType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/timing/#getTriggerType) .
- **Duration** dipetakan ke [Timing.getDuration](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/timing/#getDuration) , dalam detik.
- **Delay** dipetakan ke [Timing.getTriggerDelayTime](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/timing/#getTriggerDelayTime) , dalam detik.
- **Repeat** dipetakan ke [Timing.getRepeatCount](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/timing/#getRepeatCount) , [Timing.getRepeatUntilNextClick](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/timing/#getRepeatUntilNextClick) , atau [Timing.getRepeatUntilEndSlide](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/timing/#getRepeatUntilEndSlide) .
- **Rewind when done playing** dipetakan ke [Timing.getRewind](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/timing/#getRewind) .

Contoh independen ini menambahkan sebuah efek, mengubah pengaturannya melalui objek yang dikembalikan oleh [Sequence.addEffect](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sequence/#addEffect) , dan menyimpan hasilnya. Menyimpan referensi [Effect](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/effect/) yang dikembalikan menghindari kebutuhan indeks koleksi yang tidak perlu.

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

Gunakan satu mode pengulangan secara sengaja. Menggabungkan hitungan pengulangan dengan flag “until” dapat menghasilkan hasil yang membingungkan pada penampil yang berbeda. Saat mengubah mode pengulangan, setel [Timing.setRepeatUntilNextClick](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/timing/#setRepeatUntilNextClick) dan [Timing.setRepeatUntilEndSlide](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/timing/#setRepeatUntilEndSlide) **sebelum** [Timing.setRepeatCount](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/timing/#setRepeatCount) , karena menyetel salah satu flag juga mengubah mode pengulangan yang aktif.

## **Menambahkan dan Mengekstrak Suara Animasi**

Sebuah efek animasi dapat merujuk ke audio tersemat melalui [Effect.getSound](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/effect/#getSound) . [Effect.setStopPreviousSound](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/effect/#setStopPreviousSound) memberi tahu efek untuk menghentikan audio yang dimulai oleh efek sebelumnya.

### **Menambahkan Suara ke Efek**

Contoh berikut mengharapkan file audio lokal bernama `animation-sound.wav`. Ia membuat dua efek, menanamkan file tersebut sebagai suara untuk efek pertama, dan mengonfigurasi efek kedua untuk menghentikan suara. Ia menggunakan objek yang dikembalikan oleh [Sequence.addEffect](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sequence/#addEffect) , sehingga tidak diperlukan indeks urutan.

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

### **Mengekstrak Suara Efek yang Tersemat**

Contoh berikut mengharapkan sebuah presentasi lokal bernama `presentation-with-animation-sounds.pptx`. Ia memindai urutan utama dan interaktif serta menulis setiap suara efek yang tersemat ke direktori `extracted-animation-sounds`. Ekstensi dipilih berdasarkan tipe MIME audio yang diberikan oleh [Audio.getContentType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/audio/#getContentType) .

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

Untuk objek audio berukuran besar, gunakan [Audio.getStream](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/audio/#getStream) dan salin stream ke file alih-alih memuat seluruh objek ke dalam array byte.

## **Menetapkan Perilaku Setelah Animasi**

Opsi **After animation** mengontrol apa yang terjadi pada shape setelah efeknya selesai.

![Dialog Opsi Efek PowerPoint menampilkan pengaturan After animation](shape-after-animation.png)

Enumerasi [AfterAnimationType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/afteranimationtype/) mendukung meninggalkan shape tidak berubah, mengubah warnanya, menyembunyikannya setelah animasi, atau menyembunyikannya pada klik berikutnya. Ketika tipe adalah [AfterAnimationType.Color](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/afteranimationtype/#Color) , setel juga [Effect.getAfterAnimationColor](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/effect/#getAfterAnimationColor) .

Contoh independen ini membuat sebuah efek, menetapkan perilaku setelah animasi melalui objek efek yang dikembalikan, dan menyimpan hasilnya.

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

Mengubah tipe dari [AfterAnimationType.Color](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/afteranimationtype/#Color) menghapus pengaturan warna after‑animation.

## **Menganimasikan Teks**

Animasi teks memiliki dua kontrol terkait:

- [TextAnimation.getBuildType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textanimation/#getBuildType) mengontrol apakah paragraf muncul secara bersamaan atau per tingkat paragraf.
- [Effect.getAnimateTextType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/effect/#getAnimateTextType) mengontrol apakah teks muncul sekaligus, per kata, atau per huruf. [Effect.getDelayBetweenTextParts](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/effect/#getDelayBetweenTextParts) menetapkan jeda antar kata atau huruf. Nilai positif adalah persentase dari durasi efek; nilai negatif adalah jeda dalam detik.

Contoh independen berikut menganimasikan kata‑kata dalam sebuah kotak teks. [BuildType.AsOneObject](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/buildtype/#AsOneObject) menonaktifkan pembangunan paragraf‑per‑paragraf sehingga pengaturan kata berlaku untuk seluruh bingkai teks.

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

Untuk membangun kotak teks per paragraf, setel [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/buildtype/#ByLevelParagraphs1) (atau tingkat paragraf lain). Untuk menargetkan satu paragraf dengan efeknya sendiri, gunakan overload [Sequence.addEffect](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sequence/#addEffect) yang menerima sebuah [Paragraph](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraph/) . Lihat [Animated Text](/slides/id/nodejs-java/animated-text/) untuk contoh tingkat paragraf.

## **Ekspor dan Catatan Kompatibilitas**

- Menyimpan ke PPT atau PPTX mempertahankan model animasi, tetapi pemutaran akhir dikendalikan oleh penampil presentasi.
- PDF dan gambar statis tidak memutar animasi. Gunakan [HTML5 export](/slides/id/nodejs-java/export-to-html5/) , GIF animasi, atau [konversi video](/slides/id/nodejs-java/convert-powerpoint-to-video/) ketika output harus menampilkan gerakan.
- Untuk HTML5, aktifkan [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/html5options/#setAnimateShapes) dan, bila diperlukan, [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/html5options/#setAnimateTransitions) .
- Rendering video mendukung banyak efek masuk, penekanan, keluar, dan jalur‑gerak umum, tetapi tidak semua efek PowerPoint didukung. Periksa halaman [supported animations and effects](/slides/id/nodejs-java/convert-powerpoint-to-video/#supported-animations-and-effects) yang terbaru dan uji presentasi kritis dengan versi Aspose.Slides Anda.
- Efek khusus lanjutan dan efek yang diimpor dari format presentasi lain mungkin dipertahankan dalam berkas tetapi dirender secara berbeda di PowerPoint, HTML5, atau video. Validasi hasil ekspor daripada hanya mengandalkan nama efek.

## **FAQ**

**Mengapa animasi muncul di PowerPoint tetapi tidak di PDF?**

PDF adalah format statis, sehingga animasi dan transisi slide tidak diputar. Ekspor ke HTML5, GIF animasi, atau video bila gerakan harus dipertahankan.

**Mengapa sebuah efek diputar berbeda pada video?**

Ekspor video merender animasi alih‑alih menyimpan perilaku PowerPoint asli. Beberapa efek lanjutan tidak didukung atau hanya diperkirakan. Tinjau tabel efek yang didukung dan uji presentasi aktual sebelum penggunaan produksi.

**Apakah memindahkan shape maju atau mundur mengubah urutan animasinya?**

Tidak. Z‑order shape mengontrol tumpang tindih, sedangkan urutan urutan dan pemicu mengontrol pemutaran animasi. Ubah timeline bila Anda memerlukan urutan pemutaran yang berbeda.