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
- transisi morph
- tipe transisi
- efek transisi
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Terapkan transisi slide, konfigurasikan pergerakan slide otomatis, dan sesuaikan Morph serta efek transisi lainnya dengan Aspose.Slides untuk PHP via Java."
---
## **Gambaran Umum**

Transisi slide mengontrol cara slide muncul selama pertunjukan slide. Dengan Aspose.Slides untuk PHP via Java, Anda dapat memilih efek transisi untuk setiap slide, mengonfigurasi pergerakan lewat klik mouse atau timer, serta menyesuaikan opsi khusus untuk sebuah efek. Artikel ini menggunakan contoh PHP untuk menerapkan transisi, menetapkan durasi transisi yang tepat, mengelola waktu slide, dan membuat transisi Morph antara dua slide. Contoh-contoh tersebut juga menunjukkan cara menyimpan pengaturan ke file PPTX.

## **Menambahkan Transisi Slide**

Untuk menerapkan transisi, muat presentasi dengan kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) dan akses pengaturan transisi slide melalui [getSlideShowTransition](https://reference.aspose.com/slides/id/php-java/aspose.slides/baseslide/#getSlideShowTransition). Gunakan [setType](https://reference.aspose.com/slides/id/php-java/aspose.slides/slideshowtransition/#setType) dengan nilai dari enumerasi [TransitionType](https://reference.aspose.com/slides/id/php-java/aspose.slides/transitiontype/), lalu simpan presentasi.

Contoh berikut menerapkan transisi Circle pada slide pertama dan transisi Comb pada slide kedua. Gunakan file `input.pptx` yang memiliki setidaknya dua slide.

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

## **Menambahkan Transisi Slide Lanjutan**

Anda dapat mengonfigurasi berapa lama slide tetap di layar dan apakah klik mouse melanjutkan pertunjukan slide. Metode-metode berikut mengontrol perilaku tersebut:

- [setAdvanceOnClick](https://reference.aspose.com/slides/id/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) memungkinkan penonton melanjutkan dengan mengklik mouse.
- [setAdvanceAfter](https://reference.aspose.com/slides/id/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) mengaktifkan pergerakan otomatis.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/id/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) menentukan jeda sebelum pergerakan otomatis, dalam milidetik.

Aktifkan kedua pergerakan klik dan berbasis timer supaya penonton dapat melanjutkan dengan klik atau menunggu timer. Untuk menggunakan hanya timer, berikan `false` ke [setAdvanceOnClick](https://reference.aspose.com/slides/id/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). Jeda mengontrol kapan pertunjukan slide maju; ia tidak menentukan durasi efek transisi visual.

Contoh ini menetapkan efek yang berbeda untuk tiga slide pertama dan mengaktifkan pergerakan otomatis setelah 3, 5, dan 7 detik secara berurutan. Klik mouse juga dapat melanjutkan slide tersebut. Gunakan file `input.pptx` yang memiliki setidaknya tiga slide.

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

Untuk memeriksa apakah pergerakan berbasis timer diaktifkan, panggil [getAdvanceAfter](https://reference.aspose.com/slides/id/php-java/aspose.slides/slideshowtransition/#getAdvanceAfter). Jeda yang disimpan saja tidak menunjukkan bahwa timer sedang aktif.

Contoh berikut membuka file yang disimpan di atas, melaporkan setiap timer yang diaktifkan, dan menonaktifkan pergerakan otomatis untuk slide dengan jeda lebih dari dua detik. Ia mengaktifkan klik mouse untuk slide tersebut dan menyimpan pengaturan yang diperbarui.

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

## **Mengontrol Waktu Transisi Secara Tepat**

Gunakan [setDuration](https://reference.aspose.com/slides/id/php-java/aspose.slides/slideshowtransition/#setDuration) untuk menentukan panjang tepat efek transisi dalam milidetik. Metode [getSlideShowTransition](https://reference.aspose.com/slides/id/php-java/aspose.slides/baseslide/#getSlideShowTransition) pada slide mengungkapkan pengaturan ini melalui [SlideShowTransition](https://reference.aspose.com/slides/id/php-java/aspose.slides/slideshowtransition/):

| Metode | Tujuan |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/id/php-java/aspose.slides/slideshowtransition/#setDuration) | Menetapkan durasi efek transisi itu sendiri, dalam milidetik. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/id/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Menetapkan jeda sebelum slide maju otomatis, dalam milidetik. Berikan `true` ke [setAdvanceAfter](https://reference.aspose.com/slides/id/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) untuk mengaktifkan timer ini. |
| [setSpeed](https://reference.aspose.com/slides/id/php-java/aspose.slides/slideshowtransition/#setSpeed) | Memilih kategori kecepatan yang telah ditentukan dari [TransitionSpeed](https://reference.aspose.com/slides/id/php-java/aspose.slides/transitionspeed/): Slow, Medium, atau Fast. Digunakan bila durasi tepat tidak ditentukan. |

[setDuration](https://reference.aspose.com/slides/id/php-java/aspose.slides/slideshowtransition/#setDuration) mengontrol hanya efek transisi; ia tidak menentukan berapa lama slide tetap terlihat. Konfigurasikan jeda pergerakan otomatis secara terpisah. Ketika tidak ada durasi eksplisit yang ditetapkan, Aspose.Slides menentukan durasi efek dari tipe transisi dan nilai [getSpeed](https://reference.aspose.com/slides/id/php-java/aspose.slides/slideshowtransition/#getSpeed).

### **Menerapkan Durasi yang Sama pada Setiap Slide**

Untuk ritme yang konsisten, terapkan efek yang sama dan durasi tepat yang sama pada setiap slide. Contoh ini memuat `input.pptx`, memilih Fade dari [TransitionType](https://reference.aspose.com/slides/id/php-java/aspose.slides/transitiontype/), dan memberikan setiap transisi durasi 750 milidetik. Ia secara terpisah mengaktifkan pergerakan otomatis setelah 5.000 milidetik dan menonaktifkan pergerakan lewat klik mouse, kemudian menyimpan hasilnya sebagai PPTX.

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

        // Konfigurasikan pergerakan otomatis secara terpisah dari durasi efek.
        $transition->setAdvanceAfter(true);
        $transition->setAdvanceAfterTime(5000);
        $transition->setAdvanceOnClick(false);
    }

    $presentation->save("precise-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Menetapkan Durasi Berbeda untuk Slide Individu**

Slide yang berbeda dapat menggunakan durasi efek yang berbeda. Misalnya, gunakan transisi singkat untuk slide judul dan transisi lebih lama untuk pengenalan bagian. Contoh ini menetapkan 500 milidetik untuk slide pertama dan 1.200 milidetik untuk slide kedua. Gunakan file `input.pptx` yang memiliki setidaknya dua slide.

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

### **Mengkoordinasikan Transisi dengan Output Animasi**

Saat menyiapkan [animated GIF](/slides/id/php-java/convert-powerpoint-to-animated-gif/), [presentasi HTML5](/slides/id/php-java/export-to-html5/), atau [video](/slides/id/php-java/convert-powerpoint-to-video/), tetapkan durasi transisi yang tepat sebelum ekspor agar sesuai dengan ritme yang diinginkan. Misalnya, gunakan fade selama 600 milidetik antar adegan, dan sesuaikan jeda pergerakan setiap slide secara terpisah untuk memberi waktu pada narasi atau kontennya.

Untuk GIF dan video, sinkronkan frame rate output dengan durasi efek: 600 milidetik bersamaan dengan 18 frame pada 30 frame per detik. Pada HTML5, aktifkan transisi animasi dalam pengaturan ekspor. Periksa efek dan opsi waktu yang didukung oleh format ekspor yang dipilih, dan pratinjau output untuk memastikan sinkronisasi.

### **Membaca Durasi Transisi yang Ada**

Panggil [getDuration](https://reference.aspose.com/slides/id/php-java/aspose.slides/slideshowtransition/#getDuration) sebelum mengubah transisi untuk menentukan apakah nilai eksplisit disimpan. Nilai `-1` berarti tidak ada durasi eksplisit yang ditetapkan; nilai non-negatif menentukan durasi yang disimpan dalam milidetik. Nilai yang tidak disetel bukan durasi pemutaran yang dihitung: Aspose.Slides menggunakan tipe transisi dan nilai [getSpeed](https://reference.aspose.com/slides/id/php-java/aspose.slides/slideshowtransition/#getSpeed) untuk menentukan durasi tersebut. Menetapkan tipe transisi dapat menginisialisasi durasi, jadi periksa pengaturan asli terlebih dulu.

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

Transisi Morph menganimasikan perubahan antara objek pada slide berurutan. Untuk membuat efek Morph sederhana, klon slide, pindahkan atau ubah ukuran objek pada klon, dan terapkan transisi Morph pada slide kedua. Ini memberikan objek yang bersesuaian untuk dianimasikan antara keadaan asli dan yang dimodifikasi.

Contoh berikut membuat slide dengan sebuah persegi teks, mengkloning slide tersebut, dan mengubah posisi serta ukuran persegi pada klon. Kemudian ia memilih Morph dari enumerasi [TransitionType](https://reference.aspose.com/slides/id/php-java/aspose.slides/transitiontype/) untuk slide kedua. Buka file yang disimpan dalam penampil presentasi yang mendukung Morph untuk melihat efeknya selama pertunjukan slide.

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

Enumerasi [TransitionMorphType](https://reference.aspose.com/slides/id/php-java/aspose.slides/transitionmorphtype/) mengontrol cara Morph mencocokkan dan menganimasi konten:

- [ByObject](https://reference.aspose.com/slides/id/php-java/aspose.slides/transitionmorphtype/#ByObject) memperlakukan setiap bentuk sebagai satu objek keseluruhan.
- [ByWord](https://reference.aspose.com/slides/id/php-java/aspose.slides/transitionmorphtype/#ByWord) menganimasi teks dengan mencocokkan kata bila memungkinkan.
- [ByChar](https://reference.aspose.com/slides/id/php-java/aspose.slides/transitionmorphtype/#ByChar) menganimasi teks dengan mencocokkan karakter bila memungkinkan.

Gunakan [setType](https://reference.aspose.com/slides/id/php-java/aspose.slides/slideshowtransition/#setType) untuk memilih Morph sebelum mengakses [getValue](https://reference.aspose.com/slides/id/php-java/aspose.slides/slideshowtransition/#getValue). Nilai tersebut kemudian menyediakan objek [MorphTransition](https://reference.aspose.com/slides/id/php-java/aspose.slides/morphtransition/), yang metode [setMorphType](https://reference.aspose.com/slides/id/php-java/aspose.slides/morphtransition/#setMorphType)-nya memilih mode pencocokan.

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

## **Menetapkan Efek Transisi**

Beberapa transisi membuka opsi tambahan, seperti arah atau apakah efek dimulai dari layar hitam. Opsi yang tersedia tergantung pada transisi yang dipilih dengan [setType](https://reference.aspose.com/slides/id/php-java/aspose.slides/slideshowtransition/#setType). Tetapkan tipe terlebih dahulu, kemudian gunakan objek transisi yang tepat dari [getValue](https://reference.aspose.com/slides/id/php-java/aspose.slides/slideshowtransition/#getValue).

Contoh berikut menerapkan transisi Cut pada slide pertama `input.pptx`. Ia memanggil [setFromBlack](https://reference.aspose.com/slides/id/php-java/aspose.slides/optionalblacktransition/#setFromBlack) melalui [OptionalBlackTransition](https://reference.aspose.com/slides/id/php-java/aspose.slides/optionalblacktransition/) sehingga transisi dimulai dari layar hitam.

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

Ya. Gunakan [setDuration](https://reference.aspose.com/slides/id/php-java/aspose.slides/slideshowtransition/#setDuration) bila Anda memerlukan durasi efek yang tepat dalam milidetik. Gunakan [setSpeed](https://reference.aspose.com/slides/id/php-java/aspose.slides/slideshowtransition/#setSpeed) bila kategori [TransitionSpeed](https://reference.aspose.com/slides/id/php-java/aspose.slides/transitionspeed/) yang telah ditentukan—Slow, Medium, atau Fast—cukup dan tidak ada durasi eksplisit yang ditetapkan. Pengaturan ini mengontrol efek transisi secara independen dari jeda pergerakan otomatis.

**Apakah saya dapat menambahkan audio ke transisi dan membuatnya berulang?**

Ya. Tetapkan audio tersemat dengan [setSound](https://reference.aspose.com/slides/id/php-java/aspose.slides/slideshowtransition/#setSound), berikan StartSound dari enumerasi [TransitionSoundMode](https://reference.aspose.com/slides/id/php-java/aspose.slides/transitionsoundmode/) ke [setSoundMode](https://reference.aspose.com/slides/id/php-java/aspose.slides/slideshowtransition/#setSoundMode), dan aktifkan [setSoundLoop](https://reference.aspose.com/slides/id/php-java/aspose.slides/slideshowtransition/#setSoundLoop) dengan `true`. Audio akan berulang hingga terjadi peristiwa suara berikutnya dalam pertunjukan slide.

**Apa cara tercepat untuk menerapkan transisi yang sama pada setiap slide?**

Loop melalui koleksi [getSlides](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#getSlides) pada presentasi dan panggil [setType](https://reference.aspose.com/slides/id/php-java/aspose.slides/slideshowtransition/#setType) dengan nilai yang sama untuk transisi setiap slide. Tetapkan opsi waktu dan efek apa pun dalam loop yang sama untuk menjaga perilaku tetap konsisten di seluruh slide.

**Bagaimana saya dapat memeriksa transisi apa yang saat ini diterapkan pada sebuah slide?**

Panggil [getType](https://reference.aspose.com/slides/id/php-java/aspose.slides/slideshowtransition/#getType) pada hasil [getSlideShowTransition](https://reference.aspose.com/slides/id/php-java/aspose.slides/baseslide/#getSlideShowTransition) slide. Ia mengembalikan nilai dari enumerasi [TransitionType](https://reference.aspose.com/slides/id/php-java/aspose.slides/transitiontype/); None berarti tidak ada efek transisi yang diterapkan.