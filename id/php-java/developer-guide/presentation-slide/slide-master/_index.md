---
title: Kelola Slide Master Presentasi di PHP
linktitle: Master Slide
type: docs
weight: 70
url: /id/php-java/slide-master/
keywords:
- slide master
- slide master
- slide master PPT
- beberapa slide master
- bandingkan slide master
- latar belakang
- placeholder
- klon slide master
- salin slide master
- duplikat slide master
- slide master yang tidak terpakai
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Kelola slide master di Aspose.Slides untuk PHP via Java: mengakses, mengedit, mengklon, membandingkan, dan menghapus slide master dalam presentasi PowerPoint dan OpenDocument."
---
## **Ringkasan**

**Slide master** menentukan pengaturan desain bersama untuk sekumpulan slide. Ini dapat berisi bentuk umum, logo, latar belakang, gaya teks, pengaturan tema, dan pengaturan footer. Di PowerPoint, mengedit slide master adalah cara biasa untuk menjaga konsistensi presentasi tanpa mengulangi format yang sama pada setiap slide.

Aspose.Slides untuk PHP via Java mendukung model yang sama. Sebuah presentasi dapat berisi satu atau lebih slide master, dan setiap slide master dapat berisi beberapa slide tata letak. Slide biasa biasanya tidak merujuk langsung ke slide master. Sebaliknya, slide biasa menggunakan slide tata letak, dan slide tata letak tersebut merupakan milik slide master.

Hierarki tersebut adalah:

1. **Slide master** - menentukan desain dan tema bersama.  
1. **Slide tata letak** - menentukan susunan khusus placeholder dan format tingkat tata letak.  
1. **Slide biasa** - berisi konten presentasi aktual dan menggunakan satu slide tata letak.

![Hierarki slide master, slide tata letak, dan slide biasa](slide-master_2.jpg)

Di Aspose.Slides, slide master direpresentasikan oleh kelas [MasterSlide](https://reference.aspose.com/slides/id/php-java/aspose.slides/masterslide/). Semua slide master dalam sebuah presentasi dapat diakses melalui metode [Presentation.getMasters](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#getMasters), yang mengembalikan objek [MasterSlideCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/masterslidecollection/).

{{% alert color="info" title="Inheritance" %}}

Ketika properti yang sama didefinisikan pada lebih dari satu tingkat, tingkat yang lebih spesifik yang menang. Misalnya, jika slide master dan slide tata letak keduanya mendefinisikan latar belakang, slide yang berbasis tata letak tersebut menggunakan latar belakang tata letak. Untuk informasi lebih lanjut tentang slide tata letak, lihat [Terapkan atau Ubah Tata Letak Slide](/slides/id/php-java/slide-layout/).

{{% /alert %}}

## **Akses Slide Master**

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

Anda juga dapat mendapatkan slide master yang digunakan oleh slide biasa melalui tata letaknya:

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

Slide master adalah objek yang mirip slide. Ia memperluas [BaseSlide](https://reference.aspose.com/slides/id/php-java/aspose.slides/baseslide/), sehingga mengekspos banyak properti slide yang sama yang digunakan oleh slide biasa dan slide tata letak. Anggota khusus master tercantum pada halaman API [MasterSlide](https://reference.aspose.com/slides/id/php-java/aspose.slides/masterslide/).

Anggota master slide yang sering digunakan meliputi:

| Anggota | Tujuan |
| --- | --- |
| `getBackground` | Mengatur latar belakang slide tingkat master. |
| `getShapes` | Menyimpan bentuk yang ditempatkan pada master, seperti logo, bingkai gambar, dan teks bersama. |
| `getLayoutSlides` | Menyimpan slide tata letak yang menjadi milik master. |
| `getThemeManager` | Memberikan akses ke API tema master. |
| `getHeaderFooterManager` | Mengontrol header, footer, tanggal, dan nomor slide untuk master dan tata letak turunannya. |
| `getDependingSlides` | Mengembalikan slide biasa yang bergantung pada master melalui tata letaknya. |

## **Menambahkan Gambar ke Slide Master**

Saat Anda menambahkan gambar ke slide master, gambar tersebut muncul pada slide yang menggunakan tata letak dari master itu. Ini berguna untuk logo, watermark, pita dekoratif, dan elemen visual berulang lainnya.

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

Untuk informasi lebih lanjut tentang bingkai gambar, lihat [Bingkai Gambar](/slides/id/php-java/picture-frame/).

## **Bekerja dengan Placeholder**

Placeholder biasanya didefinisikan pada slide tata letak. Slide master menyediakan gaya dan tema bersama yang diwarisi oleh tata letak tersebut, sementara setiap tata letak memutuskan placeholder mana yang tersedia dan di mana mereka ditempatkan.

Di PowerPoint, perintah placeholder tersedia di tampilan Slide Master.

![Perintah Insert Placeholder pada tampilan Slide Master di PowerPoint](slide-master_5.png)

Untuk menambahkan placeholder baru dengan Aspose.Slides, kerja dengan slide tata letak yang milik master:

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

![Placeholder judul yang diformat diwarisi oleh slide biasa](slide-master_8.png)

Untuk opsi pemformatan placeholder dan teks lebih lanjut, lihat [Atur Teks Prompt dalam Placeholder](/slides/id/php-java/manage-placeholder/) dan [Pemformatan Teks](/slides/id/php-java/text-formatting/).

## **Mengubah Latar Belakang Slide Master**

Latar belakang master diwarisi oleh tata letak dan slide yang tidak menimpanya. Contoh berikut mengatur warna latar belakang solid untuk slide master pertama:

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

Untuk topik terkait, lihat [Latar Belakang Presentasi](/slides/id/php-java/presentation-background/) dan [Tema Presentasi](/slides/id/php-java/presentation-theme/).

## **Mengkloning Slide Master ke Presentasi Lain**

Gunakan `addClone` dari [MasterSlideCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/masterslidecollection/) untuk menyalin slide master ke presentasi lain. Master yang disalin kemudian dapat digunakan oleh tata letak dan slide di presentasi tujuan.

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

Jika Anda perlu mengkloning slide biasa bersama masternya, lihat [Klon Slide](/slides/id/php-java/clone-slides/).

## **Menambahkan Beberapa Slide Master**

Sebuah presentasi dapat berisi beberapa slide master. Ini berguna ketika bagian yang berbeda memerlukan branding, struktur halaman, atau pengaturan tema yang berbeda.

![Perintah PowerPoint untuk menyisipkan dan mengelola slide master](slide-master_9.jpg)

Contoh berikut mengkloning master default, memberi klon latar belakang berbeda, membuat tata letak di bawah master yang diklon, dan menambahkan slide baru berdasarkan tata letak tersebut:

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

Slide master dapat dibandingkan dengan metode `equals` yang diwarisi dari [BaseSlide](https://reference.aspose.com/slides/id/php-java/aspose.slides/baseslide/). Perbandingan memeriksa struktur dan konten statis, seperti bentuk, teks, pemformatan, animasi, dan pengaturan slide lainnya. Ia tidak membandingkan pengenal unik, seperti ID slide, atau nilai placeholder dinamis, seperti tanggal saat ini.

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

Untuk informasi lebih lanjut, lihat [Bandingkan Slide Presentasi](/slides/id/php-java/compare-slides/).

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

Untuk pengaturan tampilan lebih lanjut, lihat [Simpan Presentasi](/slides/id/php-java/save-presentation/).

## **Menghapus Slide Master yang Tidak Digunakan**

Presentasi kadang‑kadang berisi slide master yang tidak lagi digunakan oleh slide biasa mana pun. Menghapus master yang tidak digunakan dapat mengurangi ukuran file dan mempermudah pemeliharaan templat.

Gunakan `removeUnused` dari [MasterSlideCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/masterslidecollection/) untuk menghapus master yang tidak digunakan dari koleksi `getMasters`:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getMasters()->removeUnused(true);
    $presentation->save("presentation-clean.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Anda juga dapat menggunakan metode low‑code `removeUnusedMasterSlides` dari kelas [Compress](https://reference.aspose.com/slides/id/php-java/aspose.slides/compress/):

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

**Apa perbedaan antara slide master dan slide tata letak?**

Slide master mendefinisikan pengaturan desain bersama seperti tema, latar belakang, bentuk umum, dan gaya teks. Slide tata letak merupakan bagian dari slide master dan mendefinisikan susunan khusus placeholder. Slide biasa menggunakan slide tata letak, sehingga ia mewarisi dari tata letak dan master.

**Apakah satu presentasi dapat berisi beberapa slide master?**

Ya. Sebuah presentasi dapat berisi beberapa slide master. Gunakan banyak master ketika bagian yang berbeda memerlukan sistem visual atau branding yang berbeda.

**Haruskah saya menambahkan placeholder ke slide master atau slide tata letak?**

Dalam kebanyakan kasus, tambahkan placeholder ke slide tata letak. Letakkan elemen visual bersama dan pemformatan bersama pada slide master, kemudian letakkan placeholder konten pada tata letak yang akan digunakan oleh slide biasa.

**Bisakah saya menghapus slide master yang masih digunakan?**

Tidak. Slide master yang memiliki slide tergantung tidak dapat dihapus secara langsung dengan aman. Pindahkan slide tersebut ke tata letak di bawah master lain terlebih dahulu, atau gunakan metode pembersihan master yang tidak digunakan yang hanya menghapus master yang tidak dipakai.