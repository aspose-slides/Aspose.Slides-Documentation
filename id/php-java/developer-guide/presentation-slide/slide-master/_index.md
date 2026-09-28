---
title: Kelola Slide Master Presentasi di PHP
linktitle: Master Slide
type: docs
weight: 70
url: /id/php-java/slide-master/
keywords:
- master slide
- slide master
- slide master PPT
- banyak slide master
- bandingkan slide master
- latar belakang
- placeholder
- kloning slide master
- salin slide master
- duplikat slide master
- slide master tidak terpakai
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Kelola slide master di Aspose.Slides untuk PHP via Java: akses, edit, kloning, bandingkan, dan hapus slide master dalam presentasi PowerPoint dan OpenDocument."
---
## **Gambaran Umum**

Sebuah **slide master** mendefinisikan pengaturan desain bersama untuk sekelompok slide. Itu dapat berisi bentuk umum, logo, latar belakang, gaya teks, pengaturan tema, dan pengaturan footer. Di PowerPoint, mengedit slide master adalah cara biasa untuk menjaga konsistensi presentasi tanpa mengulangi format yang sama pada setiap slide.

Aspose.Slides for PHP via Java mendukung model yang sama. Sebuah presentasi dapat berisi satu atau lebih slide master, dan setiap slide master dapat berisi beberapa layout slide. Slide normal biasanya tidak merujuk langsung ke slide master. Sebaliknya, slide normal menggunakan layout slide, dan layout slide tersebut berada di bawah slide master.

Hierarki nya adalah:

1. **Slide master** – mendefinisikan desain dan tema bersama.
1. **Layout slide** – mendefinisikan susunan placeholder dan pemformatan tingkat layout tertentu.
1. **Normal slide** – berisi konten presentasi aktual dan menggunakan satu layout slide.

![Hierarki slide master, layout slide, dan normal slide](slide-master_2.jpg)

Di Aspose.Slides, slide master direpresentasikan oleh kelas [MasterSlide](https://reference.aspose.com/slides/id/php-java/aspose.slides/masterslide/). Semua slide master dalam sebuah presentasi dapat diakses melalui metode [Presentation.getMasters](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#getMasters), yang mengembalikan objek [MasterSlideCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/masterslidecollection/).

{{% alert color="info" title="Warisan" %}}

Ketika properti yang sama didefinisikan pada lebih dari satu tingkat, tingkat yang lebih spesifik yang akan dipakai. Misalnya, jika slide master dan layout slide keduanya mendefinisikan latar belakang, slide yang berbasis pada layout tersebut akan menggunakan latar belakang layout. Untuk informasi lebih lanjut tentang layout slide, lihat [Apply or Change Slide Layouts](/slides/id/php-java/slide-layout/).

{{% /alert %}}

## **Mengakses Slide Master**

Di PowerPoint, Anda dapat membuka tampilan Slide Master melalui **View** > **Slide Master**.

![Perintah Slide Master pada tab View di PowerPoint](slide-master_3.jpg)

Di Aspose.Slides, gunakan metode `getMasters` untuk mengakses slide master:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $firstMasterSlide = $presentation->getMasters()->get_Item(0);
    $masterSlideCount = $presentation->getMasters()->size();
    $firstMasterLayoutSlideCount = $firstMasterSlide->getLayoutSlides()->size();

    echo "Master slides: " . $masterSlideCount . PHP_EOL;
    echo "Layouts in the first master: " . $firstMasterLayoutSlideCount . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Anda juga dapat mendapatkan slide master yang digunakan oleh slide normal melalui layout-nya:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $slide->getLayoutSlide();
    $masterSlide = $layoutSlide->getMasterSlide();
    $masterSlideName = $masterSlide->getName();

    echo $masterSlideName . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Apa yang Dimiliki Slide Master**

Slide master adalah objek yang mirip slide. Ia memperluas [BaseSlide](https://reference.aspose.com/slides/id/php-java/aspose.slides/baseslide/), sehingga menampilkan banyak properti slide yang sama yang digunakan oleh slide normal dan layout. Anggota khusus master tercantum pada halaman API [MasterSlide](https://reference.aspose.com/slides/id/php-java/aspose.slides/masterslide/).

Anggota master slide yang umum digunakan meliputi:

| Anggota | Tujuan |
| --- | --- |
| `getBackground` | Mengatur latar belakang slide tingkat master. |
| `getShapes` | Menyimpan bentuk yang ditempatkan pada master, seperti logo, bingkai gambar, dan teks bersama. |
| `getLayoutSlides` | Menyimpan layout slide yang menjadi bagian dari master. |
| `getThemeManager` | Menyediakan akses ke API tema master. |
| `getHeaderFooterManager` | Mengontrol header, footer, tanggal, dan nomor slide untuk master dan layout turunannya. |
| `getDependingSlides` | Mengembalikan slide normal yang bergantung pada master melalui layout mereka. |

## **Menambahkan Gambar ke Slide Master**

Saat Anda menambahkan gambar ke slide master, gambar tersebut muncul pada slide yang menggunakan layout dari master tersebut. Ini berguna untuk logo, watermark, pita dekoratif, dan elemen visual berulang lainnya.

Contoh berikut menambahkan logo ke slide master pertama:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $logoImage = Images::fromFile("logo.png");
    try {
        $presentationImage = $presentation->getImages()->addImage($logoImage);
    } finally {
        $logoImage->dispose();
    }

    $masterSlide->getShapes()->addPictureFrame(
        ShapeType::Rectangle,
        20,
        20,
        80,
        80,
        $presentationImage
    );

    $presentation->save("presentation-with-logo.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Untuk informasi lebih lanjut tentang bingkai gambar, lihat [Picture Frame](/slides/id/php-java/picture-frame/).

## **Mengontrol Visibilitas Grafik Master**

Gunakan [BaseSlide::setShowMasterShapes](https://reference.aspose.com/slides/id/php-java/aspose.slides/baseslide/#setShowMasterShapes) untuk menyembunyikan grafik master yang diwariskan, seperti logo atau bentuk dekoratif, tanpa menghapusnya dari master. Kirim `false` ke [Slide::setShowMasterShapes](https://reference.aspose.com/slides/id/php-java/aspose.slides/slide/#setShowMasterShapes) pada slide yang harus mengabaikan grafik tersebut dan biarkan tetap `true` pada slide yang harus menampilkannya.

Contoh mandiri berikut membuat pita dekoratif biru pada master dan dua slide yang menggunakan layout kosong yang sama. Pita tersebut terlihat pada slide pertama dan disembunyikan pada slide kedua. Tidak diperlukan presentasi atau gambar masukan.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation();
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $layoutSlide = $masterSlide->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $layoutSlide->setShowMasterShapes(true);

    $slideHeight = java_values($presentation->getSlideSize()->getSize()->getHeight());
    $band = $masterSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 0, 0, 60, $slideHeight);
    $bandColor = new Java("java.awt.Color", 70, 130, 180);
    $band->getFillFormat()->setFillType(FillType::Solid);
    $band->getFillFormat()->getSolidFillColor()->setColor($bandColor);
    $band->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $visibleSlide = $presentation->getSlides()->get_Item(0);
    $visibleSlide->setLayoutSlide($layoutSlide);
    $visibleSlide->getShapes()->clear();

    $hiddenSlide = $presentation->getSlides()->addEmptySlide($layoutSlide);

    $visibleSlide->setShowMasterShapes(true);
    $hiddenSlide->setShowMasterShapes(false);

    $presentation->save("master-graphics.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Contoh menggunakan layout **Blank** yang disediakan dengan presentasi baru dan menghapus placeholder slide awal.

### **Pilih Lingkup Pengaturan**

Slide normal menggunakan master-nya melalui [Slide::getLayoutSlide](https://reference.aspose.com/slides/id/php-java/aspose.slides/slide/#getLayoutSlide) dan [LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/id/php-java/aspose.slides/layoutslide/#getMasterSlide). Menetapkan properti pada slide individu hanya memengaruhi slide tersebut. Mengirim `false` ke [LayoutSlide::setShowMasterShapes](https://reference.aspose.com/slides/id/php-java/aspose.slides/layoutslide/#setShowMasterShapes) menyembunyikan grafik master untuk semua slide yang menggunakan layout bersama itu, meskipun pengaturan mereka sendiri `true`. Untuk menyembunyikan grafik hanya pada satu slide, ubah properti slide dan biarkan layout bersama tidak berubah.

Pengaturan ini tidak didukung sebagai kontrol visibilitas pada slide master itu sendiri. Pada master, [getShowMasterShapes](https://reference.aspose.com/slides/id/php-java/aspose.slides/masterslide/#getShowMasterShapes) selalu mengembalikan `false`, dan mengirim `true` ke [setShowMasterShapes](https://reference.aspose.com/slides/id/php-java/aspose.slides/masterslide/#setShowMasterShapes) akan menghasilkan pengecualian. Terapkan pada slide normal atau layout saja.

### **Bedakan Grafik dari Latar Belakang**

| Operasi | Efek |
| --- | --- |
| Sembunyikan grafik master | Mengontrol visibilitas bentuk master yang diwariskan tanpa menghapusnya atau mengubah bentuk slide sendiri. |
| Ubah isian latar belakang slide | Mengubah warna, gradien, atau gambar latar belakang. Grafik master adalah bentuk terpisah dan dapat tetap terlihat di atas latar belakang tersebut. Lihat [Presentation Background](/slides/id/php-java/presentation-background/). |
| Hapus bentuk dari master | Menghapus bentuk sumber bersama, sehingga tidak lagi tersedia bagi slide mana pun yang menggunakan master tersebut. |

## **Bekerja dengan Placeholder**

Placeholder biasanya didefinisikan pada layout slide. Slide master menyediakan gaya dan tema bersama yang diwarisi oleh layout tersebut, sementara setiap layout memutuskan placeholder mana yang tersedia dan di mana penempatannya.

Di PowerPoint, perintah placeholder tersedia di tampilan Slide Master.

![Perintah Insert Placeholder di tampilan Slide Master PowerPoint](slide-master_5.png)

Untuk menambahkan placeholder baru dengan Aspose.Slides, kerjakan layout slide yang menjadi bagian dari master:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $blankLayoutSlideName = "Custom Blank";
    $blankLayoutSlide = $masterSlide->getLayoutSlides()->add(
        SlideLayoutType::Blank,
        $blankLayoutSlideName
    );

    $blankLayoutSlide->getPlaceholderManager()->addTextPlaceholder(
        60,
        120,
        600,
        80
    );

    $presentation->getSlides()->addEmptySlide($blankLayoutSlide);
    $presentation->save("presentation-with-placeholder.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Anda juga dapat memformat bentuk placeholder yang sudah ada pada slide master. Contoh berikut menemukan placeholder judul dan menerapkan isian gradien linear:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $titlePlaceholder = findPlaceholder($masterSlide, PlaceholderType::Title);

    if (!java_is_null($titlePlaceholder)) {
        $redGradientColor = java("java.awt.Color")->RED;
        $purpleGradientColor = new Java("java.awt.Color", 128, 0, 128);

        $fillFormat = $titlePlaceholder->getFillFormat();
        $fillFormat->setFillType(FillType::Gradient);
        $gradientFormat = $fillFormat->getGradientFormat();
        $gradientFormat->setGradientShape(GradientShape::Linear);
        $gradientStops = $gradientFormat->getGradientStops();
        $gradientStops->add(0, $redGradientColor);
        $gradientStops->add(255, $purpleGradientColor);
    }

    $presentation->save("presentation-title-style.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

function findPlaceholder($masterSlide, $placeholderType)
{
    $shapesCount = java_values($masterSlide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapesCount; $shapeIndex++) {
        $shape = $masterSlide->getShapes()->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();

        if (!java_is_null($placeholder) && java_values($placeholder->getType()) == $placeholderType) {
            return $shape;
        }
    }

    return null;
}
```

![Placeholder judul yang diformat dan diwariskan oleh slide normal](slide-master_8.png)

Untuk opsi placeholder dan pemformatan teks lebih lanjut, lihat [Set Prompt Text in Placeholder](/slides/id/php-java/manage-placeholder/) dan [Text Formatting](/slides/id/php-java/text-formatting/).

## **Mengubah Latar Belakang Slide Master**

Latar belakang master diwariskan oleh layout dan slide yang tidak menimpanya. Contoh berikut mengatur warna latar belakang padat untuk slide master pertama:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $forestGreenColor = new Java("java.awt.Color", 34, 139, 34);

    $background = $masterSlide->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $fillFormat = $background->getFillFormat();
    $fillFormat->setFillType(FillType::Solid);
    $fillFormat->getSolidFillColor()->setColor($forestGreenColor);

    $presentation->save("presentation-master-background.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Untuk topik terkait, lihat [Presentation Background](/slides/id/php-java/presentation-background/) dan [Presentation Theme](/slides/id/php-java/presentation-theme/).

## **Menggandakan Slide Master ke Presentasi Lain**

Gunakan `addClone` dari [MasterSlideCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/masterslidecollection/) untuk menyalin slide master ke presentasi lain. Master yang disalin kemudian dapat dipakai oleh layout dan slide di presentasi tujuan.

```php
$sourcePresentation = new Presentation("source.pptx");
$destinationPresentation = new Presentation("destination.pptx");
try {
    $sourceMasterSlide = $sourcePresentation->getMasters()->get_Item(0);
    $clonedMasterSlide = $destinationPresentation->getMasters()->addClone($sourceMasterSlide);

    $destinationPresentation->save("destination-with-master.pptx", SaveFormat::Pptx);
} finally {
    $destinationPresentation->dispose();
    $sourcePresentation->dispose();
}
```

Jika Anda perlu menggandakan slide normal bersama master-nya, lihat [Clone Slides](/slides/id/php-java/clone-slides/).

## **Menambahkan Beberapa Slide Master**

Sebuah presentasi dapat berisi banyak slide master. Ini berguna ketika bagian berbeda memerlukan branding, struktur halaman, atau pengaturan tema yang berbeda.

![Perintah PowerPoint untuk menyisipkan dan mengelola slide master](slide-master_9.jpg)

Contoh berikut menggandakan master default, memberikan latar belakang yang berbeda pada klon, membuat layout di bawah master yang digandakan, dan menambahkan slide baru berdasarkan layout tersebut:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $defaultMasterSlide = $presentation->getMasters()->get_Item(0);
    $sectionMasterSlide = $presentation->getMasters()->addClone($defaultMasterSlide);
    $lightSteelBlueColor = new Java("java.awt.Color", 176, 196, 222);

    $background = $sectionMasterSlide->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $fillFormat = $background->getFillFormat();
    $fillFormat->setFillType(FillType::Solid);
    $fillFormat->getSolidFillColor()->setColor($lightSteelBlueColor);

    $sourceBlankLayout = $defaultMasterSlide->getLayoutSlides()->get_Item(0);
    $sectionBlankLayout = $sectionMasterSlide->getLayoutSlides()->addClone($sourceBlankLayout);

    $presentation->getSlides()->addEmptySlide($sectionBlankLayout);
    $presentation->save("presentation-with-multiple-masters.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Membandingkan Slide Master**

Slide master dapat dibandingkan dengan metode `equals` yang diwarisi dari [BaseSlide](https://reference.aspose.com/slides/id/php-java/aspose.slides/baseslide/). Perbandingan memeriksa struktur dan konten statis, seperti bentuk, teks, pemformatan, animasi, dan pengaturan slide lainnya. Tidak membandingkan pengenal unik, seperti ID slide, atau nilai placeholder dinamis, seperti tanggal saat ini.

```php
$firstPresentation = new Presentation("first.pptx");
$secondPresentation = new Presentation("second.pptx");
try {
    $firstPresentationMasterCount = java_values($firstPresentation->getMasters()->size());
    $secondPresentationMasterCount = java_values($secondPresentation->getMasters()->size());

    for ($firstMasterIndex = 0; $firstMasterIndex < $firstPresentationMasterCount; $firstMasterIndex++) {
        for ($secondMasterIndex = 0; $secondMasterIndex < $secondPresentationMasterCount; $secondMasterIndex++) {
            $firstMasterSlide = $firstPresentation->getMasters()->get_Item($firstMasterIndex);
            $secondMasterSlide = $secondPresentation->getMasters()->get_Item($secondMasterIndex);
            $areMasterSlidesEqual = $firstMasterSlide->equals($secondMasterSlide);

            if ($areMasterSlidesEqual) {
                echo "first.pptx master #" . $firstMasterIndex .
                    " equals second.pptx master #" . $secondMasterIndex . PHP_EOL;
            }
        }
    }
} finally {
    $secondPresentation->dispose();
    $firstPresentation->dispose();
}
```

Untuk informasi lebih lanjut, lihat [Compare Presentation Slides](/slides/id/php-java/compare-slides/).

## **Menetapkan Tampilan Slide Master sebagai Tampilan Default**

Gunakan metode `setLastView` pada [ViewProperties](https://reference.aspose.com/slides/id/php-java/aspose.slides/viewproperties/) untuk mengontrol tampilan yang dibuka pertama kali oleh PowerPoint. Contoh berikut membuka presentasi dalam tampilan Slide Master:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("presentation-master-view.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Untuk pengaturan tampilan lainnya, lihat [Save Presentation](/slides/id/php-java/save-presentation/).

## **Menghapus Slide Master yang Tidak Digunakan**

Presentasi kadang berisi slide master yang tidak lagi dipakai oleh slide normal mana pun. Menghapus master yang tidak digunakan dapat mengurangi ukuran file dan menyederhanakan pemeliharaan templat.

Gunakan `removeUnused` dari [MasterSlideCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/masterslidecollection/) untuk menghapus master yang tidak terpakai dari koleksi `getMasters`:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getMasters()->removeUnused(true);
    $presentation->save("presentation-clean.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Anda juga dapat menggunakan metode low-code `removeUnusedMasterSlides` dari kelas [Compress](https://reference.aspose.com/slides/id/php-java/aspose.slides/compress/):

```php
$presentation = new Presentation("presentation.pptx");
try {
    Compress::removeUnusedMasterSlides($presentation);
    $presentation->save("presentation-clean.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Apa perbedaan antara slide master dan layout slide?**

Slide master mendefinisikan pengaturan desain bersama seperti tema, latar belakang, bentuk umum, dan gaya teks. Layout slide merupakan bagian dari slide master dan mendefinisikan susunan placeholder tertentu. Slide normal menggunakan layout slide, sehingga mewarisi dari layout serta master.

**Apakah satu presentasi dapat berisi beberapa slide master?**

Ya. Sebuah presentasi dapat berisi beberapa slide master. Gunakan banyak master ketika bagian berbeda memerlukan sistem visual atau branding yang berbeda.

**Haruskah saya menambahkan placeholder ke slide master atau layout slide?**

Dalam kebanyakan kasus, tambahkan placeholder ke layout slide. Letakkan elemen visual bersama dan pemformatan bersama pada slide master, lalu letakkan placeholder konten pada layout yang akan dipakai slide normal.

**Dapatkah saya menghapus slide master yang masih digunakan?**

Tidak. Slide master yang memiliki slide tergantung tidak dapat dihapus secara langsung dengan aman. Pindahkan terlebih dahulu slide tersebut ke layout di bawah master lain, atau gunakan metode pembersihan master yang tidak terpakai yang hanya menghapus master yang tidak digunakan.