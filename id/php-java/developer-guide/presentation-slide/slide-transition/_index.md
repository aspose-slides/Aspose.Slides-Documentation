---
title: Kelola Transisi Slide dalam Presentasi Menggunakan PHP
linktitle: Transisi Slide
type: docs
weight: 80
url: /id/php-java/slide-transition/
keywords:
- transisi slide
- tambahkan transisi slide
- terapkan transisi slide
- transisi slide lanjutan
- transisi Morph
- tipe transisi
- efek transisi
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Terapkan transisi slide, konfigurasikan kemajuan slide otomatis, dan sesuaikan Morph serta efek transisi lainnya dengan Aspose.Slides untuk PHP via Java."
---
## **Ikhtisar**

Transisi slide mengontrol cara slide muncul selama pertunjukan slide. Dengan Aspose.Slides untuk PHP via Java, Anda dapat memilih efek transisi untuk setiap slide, mengonfigurasi kemajuan dengan klik mouse atau timer, serta menyesuaikan opsi khusus untuk suatu efek. Artikel ini menggunakan contoh PHP untuk menerapkan transisi, menetapkan durasi transisi yang tepat, mengelola waktu slide, dan membuat transisi Morph antara dua slide. Contoh-contoh juga menunjukkan cara menyimpan pengaturan ke file PPTX.

## **Tambahkan Transisi Slide**

Untuk menerapkan transisi, muat presentasi dengan kelas [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) dan akses pengaturan transisi slide melalui [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition). Gunakan [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) dengan nilai dari enumerasi [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/), lalu simpan presentasi.

Contoh berikut menerapkan transisi Circle pada slide pertama dan transisi Comb pada slide kedua. Gunakan file `input.pptx` dengan setidaknya dua slide.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 2) {
        $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
        $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);

        $presentation->save("slide-transitions.pptx", SaveFormat::Pptx);
    } else {
        echo "The input presentation must contain at least two slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Transisi Wheel**

Metode [setSpokes](https://reference.aspose.com/slides/php-java/aspose.slides/wheeltransition/#setSpokes) mengontrol berapa banyak sektor radial yang mengungkap slide tujuan. Gunakan [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) untuk memilih Wheel dari [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/), lalu panggil [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue) untuk mengakses pengaturan [WheelTransition](https://reference.aspose.com/slides/php-java/aspose.slides/wheeltransition/).

Contoh membuat dua pasang slide yang identik. Setiap pasang dimulai dengan slide hitam dan diakhiri dengan slide yang ditutupi persegi panjang emas. Slide 2 menggunakan satu spoke dan slide 4 menggunakan delapan. Kedua transisi menggunakan kecepatan lambat yang sama, ditetapkan dengan [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed), dan durasi eksplisit 8.000 milidetik, ditetapkan dengan [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration).

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TransitionSpeed;
use aspose\slides\TransitionType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $slides = $presentation->getSlides();
    $width = java_values($presentation->getSlideSize()->getSize()->getWidth());
    $height = java_values($presentation->getSlideSize()->getSize()->getHeight());

    $blackSlide = $slides->get_Item(0);
    $blackSlide->getShapes()->clear();
    $background = $blackSlide->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $background->getFillFormat()->setFillType(FillType::Solid);
    $black = new Color(0, 0, 0);
    $background->getFillFormat()->getSolidFillColor()->setColor($black);

    $destinationSlide = $slides->addClone($blackSlide);
    $rectangle = $destinationSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 0, 0, $width, $height);
    $rectangle->getFillFormat()->setFillType(FillType::Solid);
    $gold = new Color(255, 215, 0);
    $rectangle->getFillFormat()->getSolidFillColor()->setColor($gold);
    $rectangle->getTextFrame()->setText("Wheel transition");

    $slides->addClone($blackSlide);
    $slides->addClone($destinationSlide);

    foreach ([1 => 1, 3 => 8] as $slideIndex => $spokes) {
        $transition = $slides->get_Item($slideIndex)->getSlideShowTransition();
        $transition->setType(TransitionType::Wheel);
        $transition->getValue()->setSpokes($spokes);
        $transition->setSpeed(TransitionSpeed::Slow);
        $transition->setDuration(8000);
    }

    $presentation->save("wheel-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Buka presentasi yang disimpan di PowerPoint dan mulai pertunjukan slide. Lanjutkan dari slide 1 ke slide 2 untuk melihat satu sapuan searah jarum jam. Kemudian lanjutkan dari slide 3 ke slide 4 untuk melihat delapan sektor radial mengungkap persegi panjang yang sama secara bersamaan.

## **Fade Through Black dengan Transisi Reveal**

Atur tipe transisi slide tujuan menjadi Reveal, lalu panggil [setThroughBlack](https://reference.aspose.com/slides/php-java/aspose.slides/revealtransition/#setThroughBlack) pada pengaturan [RevealTransition](https://reference.aspose.com/slides/php-java/aspose.slides/revealtransition/). Contoh membuat slide sumber berwarna teal dan slide tujuan berwarna coral, lalu menggandakannya. Setiap pasang menggunakan transisi Reveal dua detik yang sama. Hanya pasang kedua yang melakukan fade melalui hitam.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TransitionLeftRightDirectionType;
use aspose\slides\TransitionSpeed;
use aspose\slides\TransitionType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $source = $presentation->getSlides()->get_Item(0);
    $destination = $presentation->getSlides()->addClone($source);

    foreach ([
        [$source, new Color(0, 128, 128), "Source"],
        [$destination, new Color(255, 127, 80), "Destination"],
    ] as [$slide, $color, $label]) {
        $slide->getBackground()->setType(BackgroundType::OwnBackground);
        $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
        $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);

        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 160, 180, 400, 130);
        $shape->getTextFrame()->setText($label);
        $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setFontHeight(44);
    }

    $presentation->getSlides()->addClone($source);
    $clonedDestination = $presentation->getSlides()->addClone($destination);
    foreach ([[$destination, false], [$clonedDestination, true]] as [$slide, $throughBlack]) {
        $slide->getSlideShowTransition()->setType(TransitionType::Reveal);
        $slide->getSlideShowTransition()->setSpeed(TransitionSpeed::Slow);
        $slide->getSlideShowTransition()->setDuration(2000);
        $slide->getSlideShowTransition()->getValue()->setDirection(TransitionLeftRightDirectionType::Left);
        $slide->getSlideShowTransition()->getValue()->setThroughBlack($throughBlack);
    }

    $presentation->save("reveal-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Buka presentasi yang disimpan di PowerPoint dan mulai pertunjukan slide. Lanjutkan dari slide 1 ke slide 2 untuk melihat teal memudar langsung ke coral. Kemudian lanjutkan dari slide 3 ke slide 4. Layar sesaat menjadi hampir hitam sebelum slide coral muncul. Kedua slide tetap mempertahankan warna latar belakang aslinya.

Baris di bawah menampilkan frame PowerPoint pada interval setengah detik. Bandingkan frame tengah pada setiap baris untuk melihat efeknya.

![PowerPoint playback with fade through black disabled (top) and enabled (bottom). Only the bottom row passes through near black.](reveal-through-black.png)

## **Tambahkan Transisi Slide Lanjutan**

Anda dapat mengonfigurasi berapa lama slide tetap di layar dan apakah klik mouse melanjutkan pertunjukan slide. Metode berikut mengontrol perilaku ini:

- [setAdvanceOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) memungkinkan penonton melanjutkan dengan mengklik mouse.
- [setAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) mengaktifkan kemajuan otomatis.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) menentukan penundaan sebelum kemajuan otomatis, dalam milidetik.

Aktifkan kedua kemajuan klik dan berwaktu agar penonton dapat melanjutkan dengan klik atau menunggu timer. Untuk hanya menggunakan timer, berikan `false` ke [setAdvanceOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). Penundaan mengontrol kapan pertunjukan slide maju; itu tidak mengatur durasi efek transisi visual.

Contoh ini menetapkan efek berbeda pada tiga slide pertama dan mengaktifkan kemajuan otomatis setelah 3, 5, dan 7 detik masing-masing. Klik mouse juga dapat melanjutkan slide tersebut. Gunakan file `input.pptx` dengan setidaknya tiga slide.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 3) {
        $firstTransition = $presentation->getSlides()->get_Item(0)->getSlideShowTransition();
        $firstTransition->setType(TransitionType::Circle);
        $firstTransition->setAdvanceOnClick(true);
        $firstTransition->setAdvanceAfter(true);
        $firstTransition->setAdvanceAfterTime(3000);

        $secondTransition = $presentation->getSlides()->get_Item(1)->getSlideShowTransition();
        $secondTransition->setType(TransitionType::Comb);
        $secondTransition->setAdvanceOnClick(true);
        $secondTransition->setAdvanceAfter(true);
        $secondTransition->setAdvanceAfterTime(5000);

        $thirdTransition = $presentation->getSlides()->get_Item(2)->getSlideShowTransition();
        $thirdTransition->setType(TransitionType::Zoom);
        $thirdTransition->setAdvanceOnClick(true);
        $thirdTransition->setAdvanceAfter(true);
        $thirdTransition->setAdvanceAfterTime(7000);

        $presentation->save("advanced-transitions.pptx", SaveFormat::Pptx);
    } else {
        echo "The input presentation must contain at least three slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Untuk memeriksa apakah kemajuan berwaktu diaktifkan, panggil [getAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getAdvanceAfter). Penundaan yang tersimpan saja tidak menunjukkan bahwa timer aktif.

Contoh berikut membuka file yang disimpan di atas, melaporkan setiap timer yang diaktifkan, dan menonaktifkan kemajuan otomatis untuk slide dengan penundaan lebih dari dua detik. Itu mengaktifkan klik mouse untuk slide tersebut dan menyimpan pengaturan yang diperbarui.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("advanced-transitions.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $transition = $slide->getSlideShowTransition();

        if (java_values($transition->getAdvanceAfter())) {
            echo "Slide " . java_values($slide->getSlideNumber()) . ": advance after " . java_values($transition->getAdvanceAfterTime()) . " ms." . PHP_EOL;

            if (java_values($transition->getAdvanceAfterTime()) > 2000) {
                $transition->setAdvanceAfter(false);
                $transition->setAdvanceOnClick(true);
            }
        }
    }

    $presentation->save("adjusted-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Kontrol Waktu Transisi dengan Tepat**

Gunakan [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) untuk menentukan panjang tepat efek transisi dalam milidetik. Metode [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) slide mengungkapkan pengaturan ini melalui [SlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/):

| Metode | Tujuan |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) | Menetapkan durasi efek transisi itu sendiri, dalam milidetik. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Menetapkan penundaan sebelum slide maju secara otomatis, dalam milidetik. Berikan `true` ke [setAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) untuk mengaktifkan timer ini. |
| [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) | Memilih kategori kecepatan bawaan dari [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/): Slow, Medium, atau Fast. Digunakan ketika durasi tepat tidak ditentukan. |

[setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) hanya mengontrol efek transisi; ia tidak menentukan berapa lama slide tetap terlihat. Konfigurasikan penundaan kemajuan otomatis secara terpisah. Ketika tidak ada durasi eksplisit yang ditetapkan, Aspose.Slides menentukan durasi efek berdasarkan tipe transisi dan nilai [getSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getSpeed).

<!-- visual-explanation:slide-transition:start -->
[![Separate bars identify the 750-ms transition duration and 5,000-ms automatic advancement setting.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Contoh bersama memberikan setiap slide transisi Fade 750 ms dan secara terpisah mengaktifkan kemajuan otomatis pada 5.000 ms. Durasi transisi mengontrol efek; kemajuan mengontrol kapan meninggalkan slide. Bar ini merupakan skema pengaturan, bukan timeline gabungan yang diukur.*
<!-- visual-explanation:slide-transition:end -->

### **Terapkan Durasi yang Sama untuk Semua Slide**

Untuk konsistensi kecepatan, terapkan efek dan durasi tepat yang sama pada setiap slide. Contoh ini memuat `input.pptx`, memilih Fade dari [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/), dan memberikan setiap transisi durasi 750 milidetik. Ia secara terpisah mengaktifkan kemajuan otomatis setelah 5.000 milidetik dan menonaktifkan kemajuan dengan klik mouse, lalu menyimpan hasilnya sebagai PPTX.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $transition = $slide->getSlideShowTransition();
        $transition->setType(TransitionType::Fade);
        $transition->setDuration(750);

        // Konfigurasikan kemajuan otomatis secara terpisah dari durasi efek.
        $transition->setAdvanceAfter(true);
        $transition->setAdvanceAfterTime(5000);
        $transition->setAdvanceOnClick(false);
    }

    $presentation->save("precise-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Tetapkan Durasi Berbeda untuk Slide Individual**

Slide yang berbeda dapat menggunakan durasi efek yang berbeda. Misalnya, gunakan transisi singkat untuk slide judul dan transisi lebih lama untuk pengantar bagian. Contoh ini menetapkan 500 milidetik untuk slide pertama dan 1.200 milidetik untuk slide kedua. Gunakan file `input.pptx` dengan setidaknya dua slide.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 2) {
        $firstTransition = $presentation->getSlides()->get_Item(0)->getSlideShowTransition();
        $firstTransition->setType(TransitionType::Fade);
        $firstTransition->setDuration(500);

        $secondTransition = $presentation->getSlides()->get_Item(1)->getSlideShowTransition();
        $secondTransition->setType(TransitionType::Push);
        $secondTransition->setDuration(1200);

        $presentation->save("individual-transition-durations.pptx", SaveFormat::Pptx);
    } else {
        echo "The input presentation must contain at least two slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **Koordinasikan Transisi dengan Output Animasi**

Saat menyiapkan [animated GIF](/slides/id/php-java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/id/php-java/export-to-html5/), atau [video](/slides/id/php-java/convert-powerpoint-to-video/), tetapkan durasi transisi yang tepat sebelum mengekspor untuk mencocokkan kecepatan yang diinginkan. Misalnya, gunakan fade 600 milidetik antara adegan, dan sesuaikan penundaan kemajuan masing‑masing slide secara terpisah untuk memberi waktu pada narasi atau kontennya.

Untuk GIF dan video, koordinasikan frame rate output dengan durasi efek: 600 milidetik bersamaan dengan 18 frame pada 30 frame per detik. Pada HTML5, aktifkan transisi animasi di pengaturan ekspor. Periksa efek dan opsi waktu yang didukung oleh format ekspor yang dipilih, dan pratinjau output untuk memastikan sinkronisasi.

### **Baca Durasi Transisi yang Ada**

Panggil [getDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getDuration) sebelum memodifikasi transisi untuk menentukan apakah nilai eksplisit disimpan. Nilai `-1` berarti tidak ada durasi eksplisit yang ditetapkan; nilai non‑negatif menentukan durasi yang disimpan dalam milidetik. Nilai yang tidak disetel bukan durasi pemutaran yang dihitung: Aspose.Slides menggunakan tipe transisi dan nilai [getSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getSpeed) untuk menentukan durasi tersebut. Menetapkan tipe transisi dapat menginisialisasi durasi, jadi periksa pengaturan asli terlebih dahulu.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $transition = $slide->getSlideShowTransition();
        $duration = java_values($transition->getDuration());

        if ($duration >= 0) {
            echo "Slide " . java_values($slide->getSlideNumber()) . ": stored transition duration is " . $duration . " ms." . PHP_EOL;
        } else {
            echo "Slide " . java_values($slide->getSlideNumber()) . ": no explicit duration; timing depends on transition type " . java_values($transition->getType()) . " and speed " . java_values($transition->getSpeed()) . "." . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Transisi Morph**

Transisi Morph menganimasikan perubahan antara objek pada slide berurutan. Untuk membuat efek Morph sederhana, gandakan slide, pindahkan atau ubah ukuran objek pada duplikat, dan terapkan transisi Morph pada slide kedua. Ini memberi transisi objek yang bersesuaian untuk beranimasi antara keadaan asli dan yang dimodifikasi.

Contoh berikut membuat slide dengan persegi panjang teks, menggandakan slide, dan mengubah posisi serta ukuran persegi panjang pada duplikat. Kemudian ia memilih Morph dari enumerasi [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) untuk slide kedua. Buka file yang disimpan di penampil presentasi yang mendukung Morph untuk melihat efeknya selama pertunjukan slide.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TransitionType;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $rectangle = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 100);
    $rectangle->getTextFrame()->setText("Morph transition");

    $secondSlide = $presentation->getSlides()->addClone($firstSlide);
    $movedRectangle = $secondSlide->getShapes()->get_Item(0);
    $movedRectangle->setX(java_values($movedRectangle->getX()) + 100);
    $movedRectangle->setY(java_values($movedRectangle->getY()) + 50);
    $movedRectangle->setWidth(java_values($movedRectangle->getWidth()) - 200);
    $movedRectangle->setHeight(java_values($movedRectangle->getHeight()) - 10);

    $secondSlide->getSlideShowTransition()->setType(TransitionType::Morph);

    $presentation->save("morph-transition.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Jenis Transisi Morph**

Enumerasi [TransitionMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/) mengontrol cara Morph mencocokkan dan menganimasikan konten:

- [ByObject](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByObject) memperlakukan setiap bentuk sebagai satu objek keseluruhan.
- [ByWord](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByWord) menganimasikan teks dengan mencocokkan kata bila memungkinkan.
- [ByChar](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByChar) menganimasikan teks dengan mencocokkan karakter bila memungkinkan.

Gunakan [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) untuk memilih Morph sebelum mengakses [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue). Nilai tersebut kemudian memberikan objek [MorphTransition](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/), yang metode [setMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/#setMorphType)‑nya memilih mode pencocokan.

Contoh ini membuka presentasi yang dibuat pada bagian sebelumnya dan mengonfigurasi slide kedua untuk menggunakan animasi Morph berbasis kata.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionMorphType;
use aspose\slides\TransitionType;

$presentation = new Presentation("morph-transition.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 2) {
        $transition = $presentation->getSlides()->get_Item(1)->getSlideShowTransition();
        $transition->setType(TransitionType::Morph);
        $morphTransition = $transition->getValue();

        if (!java_is_null($morphTransition)) {
            $morphTransition->setMorphType(TransitionMorphType::ByWord);
            $presentation->save("morph-by-word.pptx", SaveFormat::Pptx);
        } else {
            echo "Morph transition options are unavailable." . PHP_EOL;
        }
    } else {
        echo "The input presentation must contain at least two slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Tetapkan Efek Transisi**

Beberapa transisi mengungkapkan opsi tambahan, seperti arah atau apakah efek dimulai dari layar hitam. Opsi yang tersedia bergantung pada transisi yang dipilih dengan [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType). Tetapkan tipe terlebih dahulu, lalu gunakan objek transisi yang sesuai dari [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue).

Contoh berikut menerapkan transisi Cut pada slide pertama `input.pptx`. Ia memanggil [setFromBlack](https://reference.aspose.com/slides/php-java/aspose.slides/optionalblacktransition/#setFromBlack) melalui [OptionalBlackTransition](https://reference.aspose.com/slides/php-java/aspose.slides/optionalblacktransition/) sehingga transisi dimulai dari layar hitam.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    $transition = $presentation->getSlides()->get_Item(0)->getSlideShowTransition();
    $transition->setType(TransitionType::Cut);
    $cutTransition = $transition->getValue();

    if (!java_is_null($cutTransition)) {
        $cutTransition->setFromBlack(true);
        $presentation->save("cut-from-black.pptx", SaveFormat::Pptx);
    } else {
        echo "Cut transition options are unavailable." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Apakah saya dapat mengontrol kecepatan pemutaran transisi slide?**

Ya. Pilih [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) ketika Anda membutuhkan durasi efek yang tepat dalam milidetik. Gunakan [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) ketika kategori [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/) yang sudah ditentukan—Slow, Medium, atau Fast—cukup dan tidak ada durasi eksplisit yang ditetapkan. Pengaturan ini mengendalikan efek transisi secara independen dari penundaan kemajuan otomatis.

**Apakah saya dapat melampirkan audio ke transisi dan membuatnya berulang?**

Ya. Tetapkan audio tertanam dengan [setSound](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSound), berikan nilai StartSound dari enumerasi [TransitionSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/transitionsoundmode/) ke [setSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSoundMode), dan aktifkan [setSoundLoop](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSoundLoop) dengan `true`. Audio akan berulang hingga ada peristiwa suara berikutnya dalam pertunjukan slide.

**Apa cara tercepat untuk menerapkan transisi yang sama pada setiap slide?**

Iterasi koleksi [getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides) presentasi dan panggil [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) dengan nilai yang sama untuk transisi tiap slide. Tetapkan semua opsi waktu dan efek dalam loop yang sama untuk menjaga konsistensi perilaku di seluruh slide.

**Bagaimana cara memeriksa transisi apa yang saat ini diterapkan pada sebuah slide?**

Panggil [getType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getType) pada hasil [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) slide. Ini mengembalikan nilai dari enumerasi [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/); None berarti tidak ada efek transisi yang diterapkan.