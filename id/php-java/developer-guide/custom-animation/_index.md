---
title: Buat dan Modifikasi Perilaku Animasi Khusus di PHP
linktitle: Animasi Khusus
type: docs
weight: 151
url: /id/php-java/custom-animation/
keywords:
- animasi khusus
- perilaku animasi
- jalur gerak
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Buat, periksa, dan modifikasi perilaku animasi khusus serta jalur gerak yang dapat diedit dalam presentasi PowerPoint dengan Aspose.Slides untuk PHP melalui Java."
---
## **Ringkasan**

Perilaku animasi khusus memungkinkan Anda mengontrol operasi individu dalam efek animasi, seperti mengubah warna, memutar bentuk, atau mengikuti jalur gerak yang dapat diedit. Panduan ini menunjukkan cara membuat dan menggabungkan perilaku, mengonfigurasi waktunya, memeriksa dan memodifikasi animasi yang ada, serta memverifikasi bahwa propertinya tetap ada setelah menyimpan dan membuka kembali presentasi.

Untuk efek yang sudah ditentukan dan pemicu klik, lihat [Animasi Bentuk](/slides/id/php-java/shape-animation/).

## **Pahami Model Animasi**

Animasi disusun sebagai **Timeline → Sequence → Effect → Behaviors**:

- Setiap slide memiliki timeline yang berisi urutan utama dan urutan interaktif.
- Sebuah [Sequence](https://reference.aspose.com/slides/id/php-java/aspose.slides/sequence/) berisi efek, yang mungkin menargetkan bentuk yang berbeda.
- Sebuah [Effect](https://reference.aspose.com/slides/id/php-java/aspose.slides/effect/) mengidentifikasi bentuk target, preset, subtype, dan waktu efek.
- Koleksi yang dikembalikan oleh [Effect::getBehaviors](https://reference.aspose.com/slides/id/php-java/aspose.slides/effect/getbehaviors/) berisi operasi yang mengimplementasikan efek: mengubah warna, memindahkan, memutar, menetapkan properti, dan sebagainya.

## **Buat Perilaku Individu**

Panggil [Sequence::addEffect](https://reference.aspose.com/slides/id/php-java/aspose.slides/sequence/addeffect/) untuk membuat efek dan mengakses koleksi [getBehaviors](https://reference.aspose.com/slides/id/php-java/aspose.slides/effect/getbehaviors/). Sebuah preset dapat mengisi koleksi ini secara otomatis. Pertahankan operasinya saat memperluas preset, atau gunakan [clear](https://reference.aspose.com/slides/id/php-java/aspose.slides/behaviorcollection/clear/) ketika memang ingin menggantinya.

[BehaviorFactory](https://reference.aspose.com/slides/id/php-java/aspose.slides/behaviorfactory/) membuat delapan tipe perilaku yang diilustrasikan di bawah. Gerakan dibahas di [Bangun Jalur Gerak](#build-a-motion-path). Setiap contoh menyertakan impor dan mengasumsikan PHP/Java Bridge serta perpustakaan Aspose.Slides PHP telah dimuat. Contoh pengeditan selanjutnya menyebutkan file output yang digunakannya.

### **Rotasi**

Gunakan [createRotationEffect](https://reference.aspose.com/slides/id/php-java/aspose.slides/behaviorfactory/createrotationeffect/) untuk membuat rotasi. [getBy](https://reference.aspose.com/slides/id/php-java/aspose.slides/rotationeffect/getby/) menentukan sudut relatif dalam derajat; [getFrom](https://reference.aspose.com/slides/id/php-java/aspose.slides/rotationeffect/getfrom/) dan [getTo](https://reference.aspose.com/slides/id/php-java/aspose.slides/rotationeffect/getto/) menentukan titik akhir.

Contoh dimulai dengan efek Spin, mengganti operasi presetnya dengan satu perilaku rotasi, dan memberi operasi tersebut durasi dua detik. Sudut relatif 90 derajat menyatakan seperempat putaran dari orientasi awal bentuk, sehingga tidak diperlukan sudut awal yang eksplisit.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Spin, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $rotation = $factory->createRotationEffect();
    $rotation->setBy(90);
    $rotation->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($rotation);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`rotation.pptx` berisi satu bentuk dan satu perilaku rotasi. Koleksi, waktu, dan contoh penyuntingan rotasi di bawah menggunakan file ini.

### **Skala**

Gunakan [createScaleEffect](https://reference.aspose.com/slides/id/php-java/aspose.slides/behaviorfactory/createscaleeffect/) dengan persentase X/Y: [getFrom](https://reference.aspose.com/slides/id/php-java/aspose.slides/scaleeffect/getfrom/) dan [getTo](https://reference.aspose.com/slides/id/php-java/aspose.slides/scaleeffect/getto/) menjelaskan ukuran awal dan akhir, sementara [getBy](https://reference.aspose.com/slides/id/php-java/aspose.slides/scaleeffect/getby/) menjelaskan perubahan relatif. Di sini, 100 berarti ukuran asli.

Contoh memperbesar kedua dimensi dari 100 % menjadi 125 % selama dua detik. Menggunakan persentase horizontal dan vertikal yang sama menjaga proporsi bentuk; persentase yang berbeda akan meregangkan satu dimensi lebih dari yang lain.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::GrowShrink, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $scale = $factory->createScaleEffect();
    $initialSize = new Point2DFloat(100, 100);
    $scale->setFrom($initialSize);
    $targetSize = new Point2DFloat(125, 125);
    $scale->setTo($targetSize);
    $scale->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($scale);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "scale.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Warna**

Gunakan [createColorEffect](https://reference.aspose.com/slides/id/php-java/aspose.slides/behaviorfactory/createcoloreffect/) untuk mengubah isian dari biru ke oranye. [getFrom](https://reference.aspose.com/slides/id/php-java/aspose.slides/coloreffect/getfrom/) dan [getTo](https://reference.aspose.com/slides/id/php-java/aspose.slides/coloreffect/getto/) adalah warna; [getBy](https://reference.aspose.com/slides/id/php-java/aspose.slides/coloreffect/getby/) adalah offset warna. [BehaviorPropertyCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/behaviorpropertycollection/) pada perilaku mengidentifikasi atribut yang dianimasikan.

Isian padat bentuk diinisialisasi menjadi biru, cocok dengan warna awal animasi. Memilih atribut isian-warna memberi tahu perilaku bagian mana dari bentuk yang akan diubah; hanya warna akhir tidak mengidentifikasi atribut tersebut. Efek yang disimpan menggambarkan transisi dua detik ke oranye.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\BehaviorProperty;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$blue = new Java("java.awt.Color", 0, 0, 255);

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor($blue);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::ChangeFillColor, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $color = $factory->createColorEffect();
    $color->getProperties()->add(BehaviorProperty::getFillColor()->getValue());
    $color->getFrom()->setColor($blue);
    $orange = new Java("java.awt.Color", 255, 165, 0);
    $color->getTo()->setColor($orange);
    $color->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($color);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "color.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Filter**

Gunakan [createFilterEffect](https://reference.aspose.com/slides/id/php-java/aspose.slides/behaviorfactory/createfiltereffect/) untuk memilih wipe. [getType](https://reference.aspose.com/slides/id/php-java/aspose.slides/filtereffect/gettype/), [getSubtype](https://reference.aspose.com/slides/id/php-java/aspose.slides/filtereffect/getsubtype/), dan [getReveal](https://reference.aspose.com/slides/id/php-java/aspose.slides/filtereffect/getreveal/) menentukan filter, arah, dan apakah akan menampilkan atau menyembunyikan bentuk.

Contoh ini mengonfigurasi wipe dua detik yang menampilkan bentuk menggunakan subtype arah kanan. Pengaturan filter merupakan bagian dari perilaku di dalam efek, sehingga dikonfigurasi setelah operasi asli preset dihapus.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\FilterEffectRevealType;
use aspose\slides\FilterEffectSubtype;
use aspose\slides\FilterEffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Wipe, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $filter = $factory->createFilterEffect();
    $filter->setType(FilterEffectType::Wipe);
    $filter->setSubtype(FilterEffectSubtype::Right);
    $filter->setReveal(FilterEffectRevealType::In);
    $filter->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($filter);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "filter.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Properti**

Gunakan [createPropertyEffect](https://reference.aspose.com/slides/id/php-java/aspose.slides/behaviorfactory/createpropertyeffect/) untuk menganimasikan opasitas. [getFrom](https://reference.aspose.com/slides/id/php-java/aspose.slides/propertyeffect/getfrom/), [getTo](https://reference.aspose.com/slides/id/php-java/aspose.slides/propertyeffect/getto/), dan [getBy](https://reference.aspose.com/slides/id/php-java/aspose.slides/propertyeffect/getby/) adalah string yang diinterpretasikan menggunakan [getValueType](https://reference.aspose.com/slides/id/php-java/aspose.slides/propertyeffect/getvaluetype/) dan [getCalcMode](https://reference.aspose.com/slides/id/php-java/aspose.slides/propertyeffect/getcalcmode/). Pilih nilai akhir atau offset relatif alih-alih mengatur ketiganya sekaligus.

Di sini, atribut yang dipilih adalah opasitas, dan string numerik mewakili perubahan dari 25 % opasitas ke opasitas penuh. Interpolasi linier menggambarkan perubahan bertahap antara nilai tersebut. Saat menyesuaikan contoh ini ke atribut lain, pilih tipe nilai dan nilai akhir yang sesuai dengan atribut tersebut.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\BehaviorProperty;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\PropertyCalcModeType;
use aspose\slides\PropertyValueType;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $property = $factory->createPropertyEffect();
    $property->getProperties()->add(BehaviorProperty::getStyleOpacity()->getValue());
    $property->setValueType(PropertyValueType::Number);
    $property->setCalcMode(PropertyCalcModeType::Linear);
    $property->setFrom("0.25");
    $property->setTo("1");
    $property->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($property);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "property.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Set**

Gunakan [createSetEffect](https://reference.aspose.com/slides/id/php-java/aspose.slides/behaviorfactory/createseteffect/) untuk menetapkan visibilitas melalui [getTo](https://reference.aspose.com/slides/id/php-java/aspose.slides/seteffect/getto/). Perilaku set tidak melakukan interpolasi antara titik akhir.

Contoh memilih atribut visibilitas dan menetapkan string `visible` ketika perilaku dijalankan. Persegi panjang sudah terlihat dalam presentasi minimal ini, sehingga penetapan mungkin tidak menghasilkan perubahan visual yang jelas. Operasi semacam ini berguna sebagai bagian dari efek yang lebih besar yang juga mengontrol kapan bentuk menjadi tersembunyi atau terlihat.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\BehaviorProperty;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Appear, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $set = $factory->createSetEffect();
    $set->getProperties()->add(BehaviorProperty::getStyleVisibility()->getValue());
    $set->setTo("visible");

    $effect->getBehaviors()->add($set);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "set.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Perintah**

Gunakan [createCommandEffect](https://reference.aspose.com/slides/id/php-java/aspose.slides/behaviorfactory/createcommandeffect/) dan konfigurasikan [getType](https://reference.aspose.com/slides/id/php-java/aspose.slides/commandeffect/gettype/), [getCommandString](https://reference.aspose.com/slides/id/php-java/aspose.slides/commandeffect/getcommandstring/), dan [getShapeTarget](https://reference.aspose.com/slides/id/php-java/aspose.slides/commandeffect/getshapetarget/). Letakkan rekaman WAV bernama `sample.wav` di direktori kerja. Contoh ini menyisipkannya dengan [addAudioFrameEmbedded](https://reference.aspose.com/slides/id/php-java/aspose.slides/shapecollection/addaudioframeembedded/) dan menambahkan perintah play ke audio frame.

Audio frame adalah target efek sekaligus target perintah. Ini menghubungkan permintaan play ke rekaman tersemat; string perintah sendiri tidak mengidentifikasi objek media mana yang dikendalikan. Efek dikonfigurasi untuk dimulai pada klik selama slideshow.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\CommandEffectType;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioPath = $baseDirectory . DIRECTORY_SEPARATOR . "sample.wav";
    $audioStream = new Java("java.io.FileInputStream", $audioPath);
    try {
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(100, 100, 40, 40, $audioStream);

        $effect = $slide->getTimeline()->getMainSequence()->addEffect($audioFrame, EffectType::MediaPlay, EffectSubtype::None, EffectTriggerType::OnClick);
        $effect->getBehaviors()->clear();

        $factory = new BehaviorFactory();
        $command = $factory->createCommandEffect();
        $command->setType(CommandEffectType::Call);
        $command->setCommandString("play");
        $command->setShapeTarget($audioFrame);

        $effect->getBehaviors()->add($command);

        $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "command.pptx", SaveFormat::Pptx);
    } finally {
        $audioStream->close();
    }
} finally {
    $presentation->dispose();
}
```

Menyimpan menyimpan perintah dalam `command.pptx`; tidak memutar rekaman. Pemutaran memerlukan pemutar slideshow yang mendukung perintah dan target media tersebut.

## **Kelola Koleksi Perilaku**

[BehaviorCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/behaviorcollection/) mendukung [add](https://reference.aspose.com/slides/id/php-java/aspose.slides/behaviorcollection/add/), [insert](https://reference.aspose.com/slides/id/php-java/aspose.slides/behaviorcollection/insert/), [remove](https://reference.aspose.com/slides/id/php-java/aspose.slides/behaviorcollection/remove/), dan [removeAt](https://reference.aspose.com/slides/id/php-java/aspose.slides/behaviorcollection/removeat/). Contoh ini membuka `rotation.pptx`, menambahkan skala, memindahkannya sebelum rotasi, dan menghapus rotasi. Menghapus dan menyisipkan kembali objek yang sama mengubah posisi tersimpan tanpa membuat salinan.

Urutan edit mengubah koleksi dari rotasi–skala menjadi skala–rotasi, kemudian menjadi hanya skala. Indeks mengacu pada koleksi saat ini, sehingga penghapusan menggunakan indeks baru rotasi setelah penataan ulang. Enumerasi akhir mengonfirmasi perilaku mana yang akan disimpan.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "rotation.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);
    $behaviors = $effect->getBehaviors();

    $factory = new BehaviorFactory();
    $scale = $factory->createScaleEffect();
    $targetSize = new Point2DFloat(125, 125);
    $scale->setTo($targetSize);
    $scale->getTiming()->setDuration(2);

    $behaviors->add($scale);

    $behaviors->remove($scale);
    $behaviors->insert(0, $scale);
    $behaviors->removeAt(1);

    $behaviorCount = java_values($behaviors->getCount());
    for ($i = 0; $i < $behaviorCount; $i++) {
        $behavior = $behaviors->get_Item($i);
        echo java_values($behavior->getClass()->getSimpleName()) . PHP_EOL;
    }

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "collection-edited.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Outputnya `ScaleEffect`: hanya skala yang tersisa. Urutan koleksi tidak secara otomatis menjadwalkan perilaku satu demi satu. Bersihkan koleksi hanya ketika mengganti semua operasinya.

## **Konfigurasikan Waktu Perilaku**

Sebuah perilaku memiliki [Timing](https://reference.aspose.com/slides/id/php-java/aspose.slides/timing/) sendiri, terpisah dari waktu yang dikembalikan oleh [Effect::getTiming](https://reference.aspose.com/slides/id/php-java/aspose.slides/effect/gettiming/). Waktu efek menjadwalkan efek yang membungkus; waktu perilaku menggambarkan operasi di dalamnya.

### **Atur Durasi, Penundaan, Pengulangan, dan Akselerasi**

Buka `rotation.pptx` dan atur durasi ([getDuration](https://reference.aspose.com/slides/id/php-java/aspose.slides/timing/getduration/)) serta penundaan pemicu ([getTriggerDelayTime](https://reference.aspose.com/slides/id/php-java/aspose.slides/timing/gettriggerdelaytime/)) dalam detik, lalu konfigurasikan jumlah pengulangan melalui [setRepeatCount](https://reference.aspose.com/slides/id/php-java/aspose.slides/timing/setrepeatcount/). [getAccelerate](https://reference.aspose.com/slides/id/php-java/aspose.slides/timing/getaccelerate/) dan [getDecelerate](https://reference.aspose.com/slides/id/php-java/aspose.slides/timing/getdecelerate/) adalah pecahan dari durasi; pertahankan jumlahnya tidak lebih dari 1.

File input adalah file yang dibuat pada contoh rotasi, di mana perilaku pertama diketahui merupakan rotasi. Contoh ini hanya mengubah waktu perilaku tersebut; sudut 90 derajat tetap tidak berubah. Memisahkan sudut dan waktu memudahkan penyesuaian kecepatan tanpa membangun ulang animasi.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "rotation.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);

    $rotation = $effect->getBehaviors()->get_Item(0);
    $rotation->getTiming()->setDuration(2);
    $rotation->getTiming()->setTriggerDelayTime(0.5);
    $rotation->getTiming()->setRepeatCount(3);
    $rotation->getTiming()->setAccelerate(0.2);
    $rotation->getTiming()->setDecelerate(0.2);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "timing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Perilaku menggunakan durasi dua detik, penundaan setengah detik, dan jumlah pengulangan 3. 20 % pertama dan terakhir durasinya digunakan untuk akselerasi dan deselerasi.

Kebijakan pengulangan lain termasuk [getRepeatDuration](https://reference.aspose.com/slides/id/php-java/aspose.slides/timing/getrepeatduration/), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/id/php-java/aspose.slides/timing/getrepeatuntilendslide/), dan [getRepeatUntilNextClick](https://reference.aspose.com/slides/id/php-java/aspose.slides/timing/getrepeatuntilnextclick/); pilih satu kebijakan alih-alih mengaktifkan semuanya sekaligus. [getAutoReverse](https://reference.aspose.com/slides/id/php-java/aspose.slides/timing/getautoreverse/) memutar animasi mundur setelah putaran maju. Akselerasi dan deselerasi berlaku untuk perubahan kontinu, bukan penetapan diskrit atau perintah.

## **Bangun Jalur Gerak**

Gunakan [createMotionEffect](https://reference.aspose.com/slides/id/php-java/aspose.slides/behaviorfactory/createmotioneffect/) untuk membuat gerak. [getFrom](https://reference.aspose.com/slides/id/php-java/aspose.slides/motioneffect/getfrom/), [getTo](https://reference.aspose.com/slides/id/php-java/aspose.slides/motioneffect/getto/), dan [getBy](https://reference.aspose.com/slides/id/php-java/aspose.slides/motioneffect/getby/) menjelaskan koordinat atau offset berbasis persentase. Untuk rute yang dapat diedit, buat [MotionPath](https://reference.aspose.com/slides/id/php-java/aspose.slides/motionpath/) dan tetapkan dengan [MotionEffect::setPath](https://reference.aspose.com/slides/id/php-java/aspose.slides/motioneffect/setpath/). [MotionPath](https://reference.aspose.com/slides/id/php-java/aspose.slides/motionpath/) menyimpan perintah jalur.

[MotionCommandPathType](https://reference.aspose.com/slides/id/php-java/aspose.slides/motioncommandpathtype/) memilih operasi:

| Command | Points | Meaning |
| --- | --- | --- |
| MoveTo | One | Menetapkan posisi awal. |
| LineTo | One | Bergerak lurus ke titik akhir segmen. |
| CurveTo | Three | Mengikuti kurva kubik yang didefinisikan oleh dua titik kontrol dan satu titik akhir. |
| CloseLoop | None | Kembali ke posisi awal. |
| End | None | Mengakhiri jalur. |

[MotionPathPointsType](https://reference.aspose.com/slides/id/php-java/aspose.slides/motionpathpointstype/) menggambarkan karakteristik penyuntingan titik, seperti titik sudut atau halus. Ini tidak menggantikan tipe perintah. Gunakan tipe titik kurva untuk contoh kurva di bawah, dan tipe titik sudut untuk segmen lurus.

Koordinat jalur dinormalkan terhadap dimensi slide: perpindahan X 0.25 mewakili seperempat lebar slide, bukan 0.25 poin. Y positif mengarah ke bawah. Perintah absolut menentukan posisi dalam sistem koordinat jalur; perintah relatif menentukan offset dari posisi saat ini. Ini terpisah dari [getOrigin](https://reference.aspose.com/slides/id/php-java/aspose.slides/motioneffect/getorigin/), yang memilih kerangka referensi jalur, dan [getPathEditMode](https://reference.aspose.com/slides/id/php-java/aspose.slides/motioneffect/getpatheditmode/), yang mengontrol bagaimana jalur bergerak ketika bentuk dipindahkan.

### **Buat Jalur Lurus**

Buat perilaku gerak dengan titik awal, satu segmen lurus, dan perintah akhir. [MotionPath::add](https://reference.aspose.com/slides/id/php-java/aspose.slides/motionpath/add/) menerima tipe perintah, titik‑titiknya, tipe titik, dan flag koordinat relatif.

Perintah awal menetapkan (0, 0), dan garis berakhir di (0.25, 0), memberi rute perpindahan horizontal seperempat lebar slide. Perintah akhir tidak memiliki titik koordinat. Setelah jalur ditetapkan, menambahkan perilaku gerak ke efek menghubungkan rute tersebut ke persegi panjang.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\MotionCommandPathType;
use aspose\slides\MotionOriginType;
use aspose\slides\MotionPath;
use aspose\slides\MotionPathPointsType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::PathRight, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory;
    $motion = $factory->createMotionEffect();
    $motion->setOrigin(MotionOriginType::Layout);
    $motion->getTiming()->setDuration(2);

    $path = new MotionPath();
    $startPoints = [new Point2DFloat(0, 0)];
    $path->add(MotionCommandPathType::MoveTo, $startPoints, MotionPathPointsType::Auto, false);
    $endPoints = [new Point2DFloat(0.25, 0)];
    $path->add(MotionCommandPathType::LineTo, $endPoints, MotionPathPointsType::Corner, false);
    $path->add(MotionCommandPathType::End, [], MotionPathPointsType::None, false);

    $motion->setPath($path);
    $effect->getBehaviors()->add($motion);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`motion.pptx` berisi satu perilaku gerak dengan tiga perintah jalur. Contoh penyuntingan file berikut menggunakan struktur yang diketahui ini.

### **Bandingkan Koordinat Absolut dan Relatif**

Kedua objek jalur ini menggambarkan rute yang sama. Perintah absolut berakhir di (0.3, 0.1); perintah relatif menambah (0.1, 0.1) ke posisi saat ini, menjadi (0.2, 0).

Kedua jalur mulai pada posisi yang sama. Untuk garis relatif, tambahkan offset X dan Y ke posisi saat ini untuk memperoleh titik akhir; untuk garis absolut, baca titik akhir secara langsung. Mengubah flag tanpa mengonversi koordinat akan menghasilkan rute yang berbeda.

```php
use aspose\slides\MotionCommandPathType;
use aspose\slides\MotionPath;
use aspose\slides\MotionPathPointsType;
use aspose\slides\Point2DFloat;

$absolutePath = new MotionPath();
$absoluteStart = [new Point2DFloat(0.2, 0)];
$absolutePath->add(MotionCommandPathType::MoveTo, $absoluteStart, MotionPathPointsType::Auto, false);
$absoluteEnd = [new Point2DFloat(0.3, 0.1)];
$absolutePath->add(MotionCommandPathType::LineTo, $absoluteEnd, MotionPathPointsType::Corner, false);

$relativePath = new MotionPath();
$relativeStart = [new Point2DFloat(0.2, 0)];
$relativePath->add(MotionCommandPathType::MoveTo, $relativeStart, MotionPathPointsType::Auto, false);
$relativeOffset = [new Point2DFloat(0.1, 0.1)];
$relativePath->add(MotionCommandPathType::LineTo, $relativeOffset, MotionPathPointsType::Corner, true);
```

Terapkan salah satu jalur ke perilaku gerak untuk menggunakannya dalam presentasi. Argumen Boolean terakhir memilih koordinat relatif untuk perintah tersebut.

### **Ganti Garis dengan Kurva**

Buka `motion.pptx` dan ganti perintah garisnya dengan kurva kubik. Sertakan dua titik kontrol terlebih dahulu, diikuti oleh titik akhir.

Posisi awal disediakan oleh perintah sebelumnya. Dua titik pertama membentuk kurva, sementara titik ketiga adalah tujuan; mereka bukan tiga tujuan berurutan. Memperbarui tipe perintah, tipe penyuntingan titik, dan larik titik secara bersamaan menjaga segmen tetap konsisten dengan geometri barunya.

```php
use aspose\slides\MotionCommandPathType;
use aspose\slides\MotionPathPointsType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);
    $motion = $effect->getBehaviors()->get_Item(0);

    $path = $motion->getPath();
    $path->get_Item(1)->setCommandType(MotionCommandPathType::CurveTo);
    $path->get_Item(1)->setPointsType(MotionPathPointsType::CurveSmooth);
    $curvePoints = [new Point2DFloat(0.1, 0), new Point2DFloat(0.2, 0.1), new Point2DFloat(0.3, 0.1)];
    $path->get_Item(1)->setPoints($curvePoints);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "curve.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Jalur dalam `curve.pptx` masih memiliki tiga perintah; perintah tengahnya kini mendefinisikan kurva.

## **Periksa dan Sunting Jalur yang Disimpan**

Setiap [MotionCmdPath](https://reference.aspose.com/slides/id/php-java/aspose.slides/motioncmdpath/) menampilkan [getPoints](https://reference.aspose.com/slides/id/php-java/aspose.slides/motioncmdpath/getpoints/), [getCommandType](https://reference.aspose.com/slides/id/php-java/aspose.slides/motioncmdpath/getcommandtype/), [getPointsType](https://reference.aspose.com/slides/id/php-java/aspose.slides/motioncmdpath/getpointstype/), dan [isRelative](https://reference.aspose.com/slides/id/php-java/aspose.slides/motioncmdpath/isrelative/). Contoh berikut menggunakan jalur tiga‑perintah yang diketahui dalam `motion.pptx`. Untuk input sembarang, temukan efek yang dimaksud dan periksa tipe perintah serta jumlah titik sebelum menyunting berdasarkan indeks.

### **Baca Perintah dan Koordinat**

Baca jalur tanpa mengubahnya. Perintah end dan close‑loop tidak memerlukan titik, jadi izinkan larik titik bernilai null.

Output memasangkan setiap tipe perintah numerik dengan flag koordinat relatifnya sebelum mencantumkan titik‑titiknya. Ini memungkinkan Anda membedakan titik akhir dari offset sebelum memodifikasi jalur. Kurva akan mencantumkan tiga titik, sedangkan garis lurus dalam file ini hanya mencantumkan satu.

```php
use aspose\slides\Presentation;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);
    $motion = $effect->getBehaviors()->get_Item(0);

    $path = $motion->getPath();
    $commandCount = java_values($path->getCount());
    for ($i = 0; $i < $commandCount; $i++) {
        $segment = $path->get_Item($i);
        $commandType = java_values($segment->getCommandType());
        $relative = java_values($segment->isRelative()) ? "true" : "false";
        echo $commandType . ", relative: " . $relative . PHP_EOL;
        $points = $segment->getPoints();
        if (!java_is_null($points)) {
            foreach ($points as $point) {
                echo "X=" . java_values($point->getX()) . ", Y=" . java_values($point->getY()) . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Daftar berisi titik awal, garis absolut yang berakhir di (0.25, 0), dan perintah end.

### **Ubah Titik Akhir**

Buka `motion.pptx` dan ganti larik titik garis untuk memindahkan titik akhirnya.

Dalam file input, indeks 0 adalah perintah awal dan indeks 1 adalah garis. Mengganti satu titik garis mengubah tujuan tanpa mengubah tipe perintah, waktu, atau posisi dalam koleksi. Karena perintah menggunakan koordinat absolut, pasangan baru menentukan posisi, bukan offset tambahan.

```php
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);

    $motion = $effect->getBehaviors()->get_Item(0);
    $endPoints = [new Point2DFloat(0.4, 0.1)];
    $motion->getPath()->get_Item(1)->setPoints($endPoints);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "motion-endpoint.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Garis dalam `motion-endpoint.pptx` berakhir di (0.4, 0.1); file asli tidak berubah.

### **Ganti Segmen**

Gunakan [insert](https://reference.aspose.com/slides/id/php-java/aspose.slides/motionpath/insert/) dan [removeAt](https://reference.aspose.com/slides/id/php-java/aspose.slides/motionpath/removeat/) untuk mengganti garis dalam `motion.pptx`. Penyisipan menggeser garis lama ke indeks 2.

Ini mendemonstrasikan penggantian objek perintah alih-alih menyunting koordinat yang sudah ada. Setelah penyisipan, koleksi sementara berisi perintah awal, garis baru, garis lama, dan perintah end. Menghapus indeks 2 menghapus garis lama dan meninggalkan rute baru di tempat.

```php
use aspose\slides\MotionCommandPathType;
use aspose\slides\MotionPathPointsType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);
    $motion = $effect->getBehaviors()->get_Item(0);

    $path = $motion->getPath();
    $replacementPoints = [new Point2DFloat(0.2, 0.1)];
    $path->insert(1, MotionCommandPathType::LineTo, $replacementPoints, MotionPathPointsType::Corner, false);
    $path->removeAt(2);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "motion-edited.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Jalur yang disimpan masih memiliki tiga perintah, dengan garis baru berakhir di (0.2, 0.1) dan perintah end terakhir.

## **Ubah dan Verifikasi Perilaku yang Ada**

Ketika indeks perilaku tidak diketahui, pilih berdasarkan tipe. Contoh ini membuka `rotation.pptx`, menemukan [RotationEffect](https://reference.aspose.com/slides/id/php-java/aspose.slides/rotationeffect/), mengubah sudutnya, dan memeriksa nilai yang disimpan setelah membuka kembali.

Pemeriksaan tipe memungkinkan loop melewati perilaku yang bukan rotasi. Pembacaan kedua memuat file yang disimpan ke objek presentasi terpisah, sehingga perbandingan memeriksa data yang dipertahankan, bukan nilai yang masih berada di memori. Contoh ini tetap mengasumsikan efek yang dikenal berada pertama dalam urutan utama; memilih perilaku berdasarkan tipe tidak selalu menemukan efek yang tepat dalam presentasi sembarang.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$rotationClass = new JavaClass("com.aspose.slides.IRotationEffect");

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "rotation.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);

    $behaviors = $effect->getBehaviors();
    $behaviorCount = java_values($behaviors->getCount());
    for ($i = 0; $i < $behaviorCount; $i++) {
        $behavior = $behaviors->get_Item($i);
        if (java_instanceof($behavior, $rotationClass)) {
            $rotation = $behavior;
            $rotation->setBy(180);
        }
    }

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "rotation-edited.pptx", SaveFormat::Pptx);

    $reopened = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "rotation-edited.pptx");
    try {
        $savedEffect = $reopened->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);

        $savedBehaviors = $savedEffect->getBehaviors();
        $savedBehaviorCount = java_values($savedBehaviors->getCount());
        for ($i = 0; $i < $savedBehaviorCount; $i++) {
            $behavior = $savedBehaviors->get_Item($i);
            if (java_instanceof($behavior, $rotationClass)) {
                $rotation = $behavior;
                $preserved = abs(java_values($rotation->getBy()) - 180) < 0.001;
                echo "Rotation preserved: " . ($preserved ? "true" : "false") . PHP_EOL;
            }
        }
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Outputnya `Rotation preserved: true`. Terapkan pola pemeriksaan tipe yang sama pada perilaku lain. Untuk pemeriksaan kepresisian lengkap, bandingkan bentuk target, efek, tipe dan urutan perilaku, waktu, serta perintah jalur. Gunakan toleransi numerik untuk nilai floating‑point. Untuk presentasi dengan tata letak animasi yang tidak diketahui, lihat [Baca Animasi Bentuk](/slides/id/php-java/shape-animation/#read-shape-animations) untuk penelusuran urutan utama dan interaktif.

## **Urutan Perilaku, Preset, dan Pemutaran**

Urutan dalam [BehaviorCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/behaviorcollection/) adalah urutan yang disimpan dari operasi efek. Itu bukan playlist di mana setiap perilaku otomatis menunggu yang sebelumnya. Waktu dan efek yang membungkus menentukan penjadwalan. Perilaku dapat tumpang tindih, dan operasi pada properti yang sama dapat berinteraksi melalui pengaturan [additive](https://reference.aspose.com/slides/id/php-java/aspose.slides/behavioradditivetype/) dan [accumulation](https://reference.aspose.com/slides/id/php-java/aspose.slides/behavioraccumulatetype/). Jangan gunakan penataan ulang koleksi saja untuk menjadwalkan “pindah, lalu putar”; gunakan waktu eksplisit atau efek terpisah seperti dijelaskan di [Animasi Bentuk](/slides/id/php-java/shape-animation/).

[getType](https://reference.aspose.com/slides/id/php-java/aspose.slides/effect/gettype/) dan [getSubtype](https://reference.aspose.com/slides/id/php-java/aspose.slides/effect/getsubtype/) pada efek mendeskripsikan presetnya. Itu bukan deskripsi lengkap dari pohon perilaku yang disunting. Pilih preset dan subtype sebelum menyesuaikan perilaku: mengubah preset dapat membangun ulang koleksi dan membuang operasi khusus Anda. Misalnya, mengubah efek Spin yang disesuaikan menjadi Fade dapat mengganti perilaku rotasi dengan perilaku set dan filter. Periksa kembali koleksi setelah mengubah preset atau subtype. Menghapus perilaku preset juga dapat menghilangkan operasi visibilitas atau inisialisasi yang dibutuhkan preset. Contoh sengaja menggunakan bentuk yang terlihat dan mengganti perilaku; mereka tidak membangun ulang setiap implementasi preset.

## **Kompatibilitas Format**

Pohon perilaku yang dipertahankan tidak menjamin pemutaran identik di setiap penampil atau renderer ekspor. Periksa data yang disimpan dan output yang dirender secara terpisah.

| Format atau output | Hal yang harus diverifikasi |
| --- | --- |
| PPTX | Gunakan sebagai format utama untuk contoh ini. Buka kembali untuk memverifikasi pohon perilaku yang dapat disunting, lalu periksa pemutaran di versi PowerPoint yang dituju. |
| PPT | Representasi biner warisan dapat berbeda dari PPTX. Lakukan siklus simpan‑buka‑ulang terpisah dan uji pemutaran; jangan menyimpulkan dukungan untuk tiap kombinasi khusus hanya dari output PPTX yang berhasil. |
| PDF, PNG, JPEG, dan gambar slide statis lainnya | Mengandung representasi slide statis, bukan timeline perilaku yang dapat diputar atau frame animasi final yang dijamin. |
| [HTML5](/slides/id/php-java/export-to-html5/) | Dapat memutar animasi yang didukung ketika animasi bentuk diaktifkan dalam opsi ekspor. Uji kombinasi khusus di peramban. |
| [Animated GIF](/slides/id/php-java/convert-powerpoint-to-animated-gif/) | Menyimpan frame yang dirender, bukan perilaku yang dapat disunting atau interaksi klik. Periksa gerakan yang sebenarnya dirender. |
| [Video](/slides/id/php-java/convert-powerpoint-to-video/) | Merender frame animasi dan mengkodekannya sebagai video. Dukungan terbatas pada [animasi dan efek yang didukung](/slides/id/php-java/convert-powerpoint-to-video/#supported-animations-and-effects) oleh renderer; perintah dan acara interaktif tidak menjadi timeline yang dapat disunting. |

## **FAQ**

**Mengapa efek saya berisi perilaku sebelum saya menambahkan apa pun?**

Membuat efek yang telah ditentukan dapat membuat operasi dasarnya. Periksa mereka sebelum memutuskan memperluas preset atau mengganti perilakunya.

**Apakah memindahkan perilaku ke awal membuatnya diputar pertama?**

Tidak selalu. Urutan koleksi bukan pengganti waktu. Periksa penundaan, durasi, dan interaksi antara operasi pada properti yang sama.

**Mengapa perintah end tidak memiliki titik?**

Perintah tersebut menandai akhir jalur dan tidak memerlukan koordinat. Periksa larik titik null saat memeriksa jalur yang dibaca dari file.

**Apakah perjalanan pulang‑pergi yang berhasil cukup untuk mengonfirmasi pemutaran?**

Tidak. Membuka kembali mengonfirmasi kepresisian properti yang Anda periksa. Uji pemutar slideshow atau ekspor animasi secara terpisah untuk memastikan perilaku visualnya.