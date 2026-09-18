---
title: Menerapkan Animasi Bentuk dalam Presentasi Menggunakan PHP
linktitle: Animasi Bentuk
type: docs
weight: 60
url: /id/php-java/shape-animation/
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
- PHP
- Aspose.Slides
description: "Pelajari cara menambahkan, memeriksa, dan menyesuaikan animasi bentuk, timing, suara, perilaku setelah animasi, serta teks animasi dengan Aspose.Slides untuk PHP melalui Java."
---
## **Gambaran Umum**

Untuk bekerja dengan perilaku individu di dalam sebuah efek atau mengedit segmen jalur‑gerak, lihat [Animasi Kustom](/slides/id/php-java/custom-animation/).

Aspose.Slides untuk PHP melalui Java merepresentasikan animasi slide sebagai efek dalam garis waktu slide. Sebuah efek memiliki shape target, tipe dan subtipe animasi, pemicu, pengaturan timing, serta properti opsional seperti suara atau perilaku setelah animasi.

Garis waktu berisi dua jenis urutan:

- The **urutan utama** diputar saat slide maju.
- **Urutan interaktif** dimulai ketika shape pemicunya diklik.

Karena kotak teks, gambar, bagan, tabel, dan objek slide lainnya adalah shape, Anda menggunakan metode [Sequence::addEffect](https://reference.aspose.com/slides/id/php-java/aspose.slides/sequence/addeffect/) yang sama untuk kebanyakan konten slide. Efek yang tersedia terdaftar di kelas [EffectType](https://reference.aspose.com/slides/id/php-java/aspose.slides/effecttype/).

## **Menambahkan Animasi Bentuk**

Untuk menambahkan animasi, dapatkan urutan utama slide dan panggil [Sequence::addEffect](https://reference.aspose.com/slides/id/php-java/aspose.slides/sequence/addeffect/) dengan shape target, tipe efek, subtipe, dan pemicu. Untuk efek yang dimulai ketika shape lain diklik, buat urutan interaktif yang pemicunya adalah shape lain tersebut.

Contoh berikut membuat kedua tipe animasi dan menyimpan hasilnya ke `shape-animations.pptx`.

```php
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 120, 100, 320, 80);
    $targetShape->addTextFrame("Click to animate this shape");

    $mainSequence = $slide->getTimeline()->getMainSequence();
    $entranceEffect = $mainSequence->addEffect($targetShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $entranceEffect->getTiming()->setDuration(1.5);

    $triggerShape = $slide->getShapes()->addAutoShape(ShapeType::Bevel, 20, 20, 100, 40);
    $triggerShape->addTextFrame("Move");

    $interactiveSequence = $slide->getTimeline()->getInteractiveSequences()->add($triggerShape);
    $interactiveSequence->addEffect($targetShape, EffectType::PathFootball, EffectSubtype::None, EffectTriggerType::OnClick);

    $presentation->save("shape-animations.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Pemicu mengontrol kapan sebuah efek dimulai:

- [EffectTriggerType::OnClick] menunggu klik dalam urutan utama, atau klik pada shape pemicu dalam urutan interaktif.
- [EffectTriggerType::WithPrevious] dimulai bersama efek sebelumnya.
- [EffectTriggerType::AfterPrevious] dimulai ketika efek sebelumnya selesai.

Untuk menganimasikan gambar, bagan, atau tipe shape lainnya, berikan objek tersebut ke [Sequence::addEffect](https://reference.aspose.com/slides/id/php-java/aspose.slides/sequence/addeffect/) alih‑alih `$targetShape`. Untuk opsi pengelompokan khusus bagan, lihat [Diagram Animasi](/slides/id/php-java/animated-charts/).

## **Membaca Animasi Bentuk**

Gunakan [Sequence::getEffectsByShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/sequence/geteffectsbyshape/) ketika Anda mengetahui shape target. Untuk memeriksa setiap efek, enumerasikan urutan utama dan setiap urutan interaktif. Enumerasi menghindari asumsi bahwa sebuah urutan berisi efek pada indeks `0`.

Contoh berikut membuat sebuah shape dengan efek urutan utama dan interaktif, mengambil efek yang menargetkan shape tersebut, lalu menelusuri setiap urutan pada slide.

```php
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

function printSequence($label, $sequence)
{
    $effectCount = java_values($sequence->getCount());

    echo "  " . $label . ": " . $effectCount . " effect(s)" . PHP_EOL;

    for ($effectIndex = 0; $effectIndex < $effectCount; $effectIndex++) {
        $effect = $sequence->get_Item($effectIndex);
        $targetShape = $effect->getTargetShape();
        $targetName = java_is_null($targetShape) ? "unknown" : java_values($targetShape->getName());
        $effectType = java_values($effect->getType());
        $effectSubtype = java_values($effect->getSubtype());
        $triggerType = java_values($effect->getTiming()->getTriggerType());
        echo "    type: " . $effectType . "; subtype: " . $effectSubtype . "; target: " . $targetName . "; trigger: " . $triggerType . PHP_EOL;
    }
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 120, 100, 320, 80);
    $targetShape->addTextFrame("Animated shape");

    $mainSequence = $slide->getTimeline()->getMainSequence();
    $mainSequence->addEffect($targetShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

    $triggerShape = $slide->getShapes()->addAutoShape(ShapeType::Bevel, 20, 20, 100, 40);
    $triggerShape->addTextFrame("Move");

    $interactiveSequence = $slide->getTimeline()->getInteractiveSequences()->add($triggerShape);
    $interactiveSequence->addEffect($targetShape, EffectType::PathFootball, EffectSubtype::None, EffectTriggerType::OnClick);

    $targetEffects = $mainSequence->getEffectsByShape($targetShape);
    $Array = new JavaClass("java.lang.reflect.Array");
    echo "The main sequence contains " . java_values($Array->getLength($targetEffects)) . " effect(s) for " . java_values($targetShape->getName()) . "." . PHP_EOL;

    printSequence("Main sequence", $mainSequence);

    $interactiveSequences = $slide->getTimeline()->getInteractiveSequences();
    $interactiveCount = java_values($interactiveSequences->getCount());
    for ($interactiveIndex = 0; $interactiveIndex < $interactiveCount; $interactiveIndex++) {
        $sequence = $interactiveSequences->get_Item($interactiveIndex);
        $sequenceTrigger = $sequence->getTriggerShape();
        $triggerName = java_is_null($sequenceTrigger) ? "unknown" : java_values($sequenceTrigger->getName());
        printSequence("Interactive sequence " . ($interactiveIndex + 1) . ", trigger: " . $triggerName, $sequence);
    }
} finally {
    $presentation->dispose();
}
```

Jika Anda hanya membutuhkan efek untuk satu shape, pertama identifikasi shape dengan nama, tipe placeholder, atau properti stabil lainnya; kemudian panggil [Sequence::getEffectsByShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/sequence/geteffectsbyshape/). Jangan mengasumsikan bahwa [ShapeCollection::get_Item](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapecollection/get_item/) pada indeks `0` selalu merupakan objek yang dimaksud.

## **Bekerja dengan Efek Placeholder yang Dwariskan**

Placeholder pada slide normal dapat mewarisi perilaku animasi dari placeholder yang bersesuaian pada slide tata letak dan slide master. [Shape::getBasePlaceholder](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/getbaseplaceholder/) mengembalikan placeholder induk tersebut, atau `null` bila tidak ada induk.

Pada presentasi contoh berikut, footer memiliki **Random Bars** pada slide normal, **Split** pada slide tata letak, dan **Fly In** pada slide master.

![Efek animasi footer pada slide normal](slide-shape-animation.png)

![Efek animasi placeholder footer pada slide tata letak](layout-shape-animation.png)

![Efek animasi placeholder footer pada slide master](master-shape-animation.png)

Contoh berikutnya menggunakan hierarki placeholder dari presentasi baru. Ia menambahkan efek ke placeholder master, placeholder tata letak, dan placeholder yang bersesuaian pada slide normal. Setiap panggilan ke [Shape::getBasePlaceholder](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/getbaseplaceholder/) diperiksa sebelum shape yang dikembalikan digunakan.

```php
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

function findLayoutPlaceholderWithBase($layoutSlide)
{
    $shapes = $layoutSlide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_is_null($shape->getBasePlaceholder())) {
            return $shape;
        }
    }

    return null;
}

function findSlidePlaceholderWithBase($slide, $expectedBase)
{
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $basePlaceholder = $shape->getBasePlaceholder();
        if (!java_is_null($basePlaceholder) && java_values($basePlaceholder->equals($expectedBase))) {
            return $shape;
        }
    }

    return null;
}

function printEffects($source, $effects)
{
    $Array = new JavaClass("java.lang.reflect.Array");
    echo $source . ": " . java_values($Array->getLength($effects)) . " effect(s)" . PHP_EOL;

    foreach ($effects as $effect) {
        echo "  type: " . java_values($effect->getType()) . "; subtype: " . java_values($effect->getSubtype()) . PHP_EOL;
    }
}

$presentation = new Presentation();
try {
    $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::TitleAndObject);
    $layoutPlaceholder = findLayoutPlaceholderWithBase($layoutSlide);

    if ($layoutPlaceholder === null) {
        throw new RuntimeException("The layout slide does not contain a placeholder linked to its master slide.");
    }

    $masterPlaceholder = $layoutPlaceholder->getBasePlaceholder();
    $layoutSlide->getMasterSlide()->getTimeline()->getMainSequence()->addEffect($masterPlaceholder, EffectType::Fly, EffectSubtype::Bottom, EffectTriggerType::OnClick);
    $layoutSlide->getTimeline()->getMainSequence()->addEffect($layoutPlaceholder, EffectType::Split, EffectSubtype::VerticalIn, EffectTriggerType::OnClick);

    $slide = $presentation->getSlides()->addEmptySlide($layoutSlide);
    $slidePlaceholder = findSlidePlaceholderWithBase($slide, $layoutPlaceholder);

    if ($slidePlaceholder === null) {
        throw new RuntimeException("The slide does not contain a placeholder linked to its layout slide.");
    }

    $slide->getTimeline()->getMainSequence()->addEffect($slidePlaceholder, EffectType::RandomBars, EffectSubtype::Horizontal, EffectTriggerType::OnClick);
    printEffects("Normal slide", $slide->getTimeline()->getMainSequence()->getEffectsByShape($slidePlaceholder));

    $baseLayoutPlaceholder = $slidePlaceholder->getBasePlaceholder();
    if (!java_is_null($baseLayoutPlaceholder)) {
        printEffects("Layout slide", $layoutSlide->getTimeline()->getMainSequence()->getEffectsByShape($baseLayoutPlaceholder));

        $baseMasterPlaceholder = $baseLayoutPlaceholder->getBasePlaceholder();
        if (!java_is_null($baseMasterPlaceholder)) {
            printEffects("Master slide", $layoutSlide->getMasterSlide()->getTimeline()->getMainSequence()->getEffectsByShape($baseMasterPlaceholder));
        }
    }

    $presentation->save("placeholder-animations.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Mengubah Timing Animasi**

Dialog **Timing** PowerPoint memetakan ke properti [Timing](https://reference.aspose.com/slides/id/php-java/aspose.slides/timing/).

![Dialog Timing PowerPoint untuk efek animasi](shape-animation.png)

- **Mulai** memetakan ke [Timing::getTriggerType](https://reference.aspose.com/slides/id/php-java/aspose.slides/timing/gettriggertype/).
- **Durasi** memetakan ke [Timing::getDuration](https://reference.aspose.com/slides/id/php-java/aspose.slides/timing/getduration/), dalam detik.
- **Delay** memetakan ke [Timing::getTriggerDelayTime](https://reference.aspose.com/slides/id/php-java/aspose.slides/timing/gettriggerdelaytime/), dalam detik.
- **Ulang** memetakan ke [Timing::getRepeatCount](https://reference.aspose.com/slides/id/php-java/aspose.slides/timing/getrepeatcount/), [Timing::getRepeatUntilNextClick](https://reference.aspose.com/slides/id/php-java/aspose.slides/timing/getrepeatuntilnextclick/), atau [Timing::getRepeatUntilEndSlide](https://reference.aspose.com/slides/id/php-java/aspose.slides/timing/getrepeatuntilendslide/).
- **Putar ulang setelah selesai** memetakan ke [Timing::getRewind](https://reference.aspose.com/slides/id/php-java/aspose.slides/timing/getrewind/).

Contoh independen ini menambahkan sebuah efek, mengubah timing‑nya melalui objek yang dikembalikan oleh [Sequence::addEffect](https://reference.aspose.com/slides/id/php-java/aspose.slides/sequence/addeffect/), dan menyimpan hasilnya. Menjaga referensi [Effect](https://reference.aspose.com/slides/id/php-java/aspose.slides/effect/) yang dikembalikan menghindari indeks koleksi yang tidak perlu.

```php
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 120, 100, 320, 80);
    $shape->addTextFrame("Timed animation");

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getTiming()->setTriggerType(EffectTriggerType::OnClick);
    $effect->getTiming()->setDuration(2.0);
    $effect->getTiming()->setTriggerDelayTime(0.5);
    $effect->getTiming()->setRepeatUntilNextClick(false);
    $effect->getTiming()->setRepeatUntilEndSlide(false);
    $effect->getTiming()->setRepeatCount(2.0);
    $effect->getTiming()->setRewind(true);

    $presentation->save("shape-animation-timing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Gunakan satu mode pengulangan secara sengaja. Menggabungkan jumlah pengulangan dengan flag “until” dapat menghasilkan hasil yang membingungkan pada penampil yang berbeda. Saat mengubah mode pengulangan, atur [Timing::setRepeatUntilNextClick](https://reference.aspose.com/slides/id/php-java/aspose.slides/timing/setrepeatuntilnextclick/) dan [Timing::setRepeatUntilEndSlide](https://reference.aspose.com/slides/id/php-java/aspose.slides/timing/setrepeatuntilendslide/) sebelum [Timing::setRepeatCount](https://reference.aspose.com/slides/id/php-java/aspose.slides/timing/setrepeatcount/), karena mengatur salah satu flag juga mengubah mode pengulangan aktif.

## **Menambahkan dan Mengekstrak Suara Animasi**

Sebuah efek animasi dapat merujuk pada audio tersemat melalui [Effect::getSound](https://reference.aspose.com/slides/id/php-java/aspose.slides/effect/getsound/). [Effect::setStopPreviousSound](https://reference.aspose.com/slides/id/php-java/aspose.slides/effect/setstopprevioussound/) memberi tahu sebuah efek untuk menghentikan audio yang dimulai oleh efek sebelumnya.

### **Menambahkan Suara ke Efek**

Contoh berikut mengharapkan file audio lokal bernama `animation-sound.wav`. Ia membuat dua efek, menyematkan file tersebut sebagai suara untuk efek pertama, dan mengonfigurasi efek kedua untuk menghentikan suara. Ia menggunakan objek yang dikembalikan oleh [Sequence::addEffect](https://reference.aspose.com/slides/id/php-java/aspose.slides/sequence/addeffect/), sehingga tidak diperlukan indeks urutan.

```php
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$Files = new JavaClass("java.nio.file.Files");

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $firstShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 100, 240, 80);
    $secondShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 400, 100, 240, 80);
    $firstShape->addTextFrame("Starts sound");
    $secondShape->addTextFrame("Stops sound");

    $sequence = $slide->getTimeline()->getMainSequence();
    $firstEffect = $sequence->addEffect($firstShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $secondEffect = $sequence->addEffect($secondShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

    $baseDirectory = getcwd();
    $audioPath = (new Java("java.io.File", $baseDirectory . DIRECTORY_SEPARATOR . "animation-sound.wav"))->toPath();
    $audioData = $Files->readAllBytes($audioPath);
    $effectSound = $presentation->getAudios()->addAudio($audioData);
    $firstEffect->setSound($effectSound);
    $secondEffect->setStopPreviousSound(true);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "shape-animation-sound.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Mengekstrak Suara Efek Tersemat**

Contoh berikut mengharapkan presentasi lokal bernama `presentation-with-animation-sounds.pptx`. Ia memindai urutan utama dan interaktif serta menulis setiap suara efek tersemat ke direktori `extracted-animation-sounds`. Ekstensi dipilih dari tipe MIME audio yang diberikan oleh [Audio::getContentType](https://reference.aspose.com/slides/id/php-java/aspose.slides/audio/getcontenttype/).

```php
use aspose\slides\Presentation;

function getAudioExtension($contentType)
{
    $normalizedType = strtolower($contentType === null ? "" : java_values($contentType));

    if ($normalizedType === "audio/mpeg") {
        return ".mp3";
    }

    if ($normalizedType === "audio/mp4") {
        return ".m4a";
    }

    if ($normalizedType === "audio/ogg") {
        return ".ogg";
    }

    if ($normalizedType === "audio/wav" || $normalizedType === "audio/x-wav") {
        return ".wav";
    }

    return ".bin";
}

function saveSounds($sequence, $outputDirectory, $soundIndex)
{
    $effectCount = java_values($sequence->getCount());
    for ($effectIndex = 0; $effectIndex < $effectCount; $effectIndex++) {
        $effect = $sequence->get_Item($effectIndex);
        $sound = $effect->getSound();
        if (java_is_null($sound)) {
            continue;
        }

        $extension = getAudioExtension($sound->getContentType());
        $outputPath = $outputDirectory->resolve("effect-sound-" . $soundIndex . $extension);
        $outputStream = new Java("java.io.FileOutputStream", $outputPath->toFile());
        try {
            $outputStream->write($sound->getBinaryData());
        } finally {
            $outputStream->close();
        }
        $soundIndex++;
    }

    return $soundIndex;
}

$baseDirectory = getcwd();
$inputPath = (new Java("java.io.File", $baseDirectory . DIRECTORY_SEPARATOR . "presentation-with-animation-sounds.pptx"))->toPath();
$outputDirectoryName = $baseDirectory . DIRECTORY_SEPARATOR . "extracted-animation-sounds";
if (!is_dir($outputDirectoryName)) {
    mkdir($outputDirectoryName, 0777, true);
}
$outputDirectory = (new Java("java.io.File", $outputDirectoryName))->toPath();

$presentation = new Presentation($inputPath->toString());
try {
    $soundIndex = 1;

    $slides = $presentation->getSlides();
    $slideCount = java_values($slides->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $slides->get_Item($slideIndex);
        $soundIndex = saveSounds($slide->getTimeline()->getMainSequence(), $outputDirectory, $soundIndex);

        $interactiveSequences = $slide->getTimeline()->getInteractiveSequences();
        $interactiveCount = java_values($interactiveSequences->getCount());
        for ($sequenceIndex = 0; $sequenceIndex < $interactiveCount; $sequenceIndex++) {
            $sequence = $interactiveSequences->get_Item($sequenceIndex);
            $soundIndex = saveSounds($sequence, $outputDirectory, $soundIndex);
        }
    }

    echo "Extracted " . ($soundIndex - 1) . " sound file(s) to " . java_values($outputDirectory->toAbsolutePath()->toString()) . "." . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Untuk objek audio berukuran besar, gunakan [Audio::getStream](https://reference.aspose.com/slides/id/php-java/aspose.slides/audio/getstream/) dan salin stream ke file alih‑alih memuat seluruh objek ke dalam array byte.

## **Mengatur Perilaku Setelah Animasi**

Opsi **After animation** mengontrol apa yang terjadi pada sebuah shape setelah efeknya selesai.

![Dialog Opsi Efek PowerPoint menampilkan pengaturan After animation](shape-after-animation.png)

Kelas [AfterAnimationType](https://reference.aspose.com/slides/id/php-java/aspose.slides/afteranimationtype/) mendukung membiarkan shape tidak berubah, mengubah warnanya, menyembunyikannya setelah animasi, atau menyembunyikannya pada klik berikutnya. Ketika tipe adalah [AfterAnimationType::Color](https://reference.aspose.com/slides/id/php-java/aspose.slides/afteranimationtype/), atur juga [Effect::getAfterAnimationColor](https://reference.aspose.com/slides/id/php-java/aspose.slides/effect/getafteranimationcolor/).

Contoh independen ini membuat sebuah efek, mengatur perilaku after‑animation melalui objek efek yang dikembalikan, dan menyimpan hasilnya.

```php
use aspose\slides\AfterAnimationType;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 120, 100, 320, 80);
    $shape->addTextFrame("Dim after animation");

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->setAfterAnimationType(AfterAnimationType::Color);
    $effect->getAfterAnimationColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);

    $presentation->save("shape-animation-after-effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Mengubah tipe dari [AfterAnimationType::Color](https://reference.aspose.com/slides/id/php-java/aspose.slides/afteranimationtype/) menghapus pengaturan warna after‑animation.

## **Menganimasikan Teks**

Animasi teks memiliki dua kontrol terkait:

- [TextAnimation::getBuildType](https://reference.aspose.com/slides/id/php-java/aspose.slides/textanimation/getbuildtype/) mengontrol apakah paragraf muncul bersamaan atau per tingkat paragraf.
- [Effect::getAnimateTextType](https://reference.aspose.com/slides/id/php-java/aspose.slides/effect/getanimatetexttype/) mengontrol apakah teks muncul sekaligus, per kata, atau per huruf. [Effect::getDelayBetweenTextParts](https://reference.aspose.com/slides/id/php-java/aspose.slides/effect/getdelaybetweentextparts/) mengatur jeda antara kata atau huruf. Nilai positif adalah persentase durasi efek; nilai negatif adalah jeda dalam detik.

Contoh independen berikut menganimasi kata‑kata dalam sebuah kotak teks. [BuildType::AsOneObject](https://reference.aspose.com/slides/id/php-java/aspose.slides/buildtype/) menonaktifkan pembangunan paragraf‑per‑paragraf sehingga pengaturan kata berlaku pada seluruh bingkai teks.

```php
use aspose\slides\AnimateTextType;
use aspose\slides\BuildType;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 560, 100);
    $textBox->addTextFrame("Aspose.Slides animates this sentence word by word.");

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($textBox, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getTextAnimation()->setBuildType(BuildType::AsOneObject);
    $effect->setAnimateTextType(AnimateTextType::ByWord);
    $effect->setDelayBetweenTextParts(20.0);

    $presentation->save("animated-text.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Untuk membangun kotak teks per paragraf, atur [BuildType::ByLevelParagraphs1](https://reference.aspose.com/slides/id/php-java/aspose.slides/buildtype/) (atau tingkat paragraf lain). Untuk menargetkan satu paragraf dengan efeknya sendiri, gunakan overload [Sequence::addEffect](https://reference.aspose.com/slides/id/php-java/aspose.slides/sequence/addeffect/) yang menerima sebuah [Paragraph](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraph/). Lihat [Teks Animasi](/slides/id/php-java/animated-text/) untuk contoh level paragraf.

## **Catatan Ekspor dan Kompatibilitas**

- Menyimpan ke PPT atau PPTX mempertahankan model animasi, tetapi pemutaran akhir dikendalikan oleh penampil presentasi.
- PDF dan gambar statis tidak memutar animasi. Gunakan [Ekspor HTML5](/slides/id/php-java/export-to-html5/), GIF animasi, atau [konversi video](/slides/id/php-java/convert-powerpoint-to-video/) ketika output harus menampilkan gerakan.
- Untuk HTML5, aktifkan [Html5Options::setAnimateShapes] dan, bila diperlukan, [Html5Options::setAnimateTransitions].
- Rendering video mendukung banyak efek masuk, penekanan, keluar, dan jalur‑gerak umum, tetapi tidak semua efek PowerPoint didukung. Periksa [animasi dan efek yang didukung](/slides/id/php-java/convert-powerpoint-to-video/#supported-animations-and-effects) saat ini dan uji presentasi kritis dengan versi Aspose.Slides target Anda.
- Efek kustom lanjutan dan efek yang diimpor dari format presentasi lain mungkin dipertahankan dalam file tetapi dirender berbeda di PowerPoint, HTML5, atau video. Validasi hasil ekspor daripada hanya mengandalkan nama efek.

## **Tanya Jawab**

**Mengapa animasi muncul di PowerPoint tetapi tidak di PDF?**

PDF adalah format statis, sehingga animasi dan transisi slide tidak diputar. Ekspor ke HTML5, GIF animasi, atau video ketika gerakan harus dipertahankan.

**Mengapa sebuah efek diputar berbeda dalam video?**

Ekspor video merender animasi alih‑alih menyimpan perilaku PowerPoint asli. Beberapa efek lanjutan tidak didukung atau hanya diperkirakan. Tinjau tabel efek yang didukung dan uji presentasi sebenarnya sebelum penggunaan produksi.

**Apakah memindahkan shape ke depan atau ke belakang mengubah urutan animasinya?**

Tidak. Z‑order shape mengontrol tumpang tindih, sedangkan urutan urutan dan pemicu mengontrol pemutaran animasi. Ubah garis waktu bila Anda memerlukan urutan pemutaran yang berbeda.