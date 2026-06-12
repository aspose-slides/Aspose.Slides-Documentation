---
title: Kelola Latar Belakang Presentasi di PHP
linktitle: Latar Belakang Slide
type: docs
weight: 20
url: /id/php-java/presentation-background/
keywords:
- latar belakang presentasi
- latar belakang slide
- warna solid
- warna gradien
- latar belakang gambar
- transparansi latar belakang
- properti latar belakang
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Pelajari cara mengatur latar belakang dinamis dalam file PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk PHP via Java, dengan tips kode untuk meningkatkan presentasi Anda."
---
## **Pengantar**

Warna solid, gradien, dan gambar biasanya digunakan untuk latar belakang slide. Anda dapat mengatur latar belakang untuk **slide normal** (satu slide) atau **slide master** (berlaku untuk beberapa slide sekaligus).

![PowerPoint background](powerpoint-background.png)

## **Atur Latar Belakang Warna Solid untuk Slide Normal**

Aspose.Slides memungkinkan Anda mengatur warna solid sebagai latar belakang untuk slide tertentu dalam presentasi—bahkan jika presentasi menggunakan slide master. Perubahan ini hanya berlaku untuk slide yang dipilih.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/).
2. Set [BackgroundType](https://reference.aspose.com/slides/id/php-java/aspose.slides/backgroundtype/) slide menjadi `OwnBackground`.
3. Set [FillType](https://reference.aspose.com/slides/id/php-java/aspose.slides/filltype/) latar belakang slide menjadi `Solid`.
4. Gunakan metode [getSolidFillColor](https://reference.aspose.com/slides/id/php-java/aspose.slides/fillformat/#getSolidFillColor) pada [FillFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/fillformat/) untuk menentukan warna latar belakang solid.
5. Simpan presentasi yang telah dimodifikasi.

Contoh PHP berikut menunjukkan cara mengatur warna solid biru sebagai latar belakang untuk slide normal:

```php
// Buat instance kelas Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Atur warna latar belakang slide menjadi biru.
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    
    // Simpan presentasi ke disk.
    $presentation->save("SolidColorBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Atur Latar Belakang Warna Solid untuk Slide Master**

Aspose.Slides memungkinkan Anda mengatur warna solid sebagai latar belakang untuk slide master dalam sebuah presentasi. Slide master berfungsi sebagai templat yang mengontrol pemformatan untuk semua slide, sehingga ketika Anda memilih warna solid untuk latar belakang slide master, itu akan diterapkan pada setiap slide.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/).
2. Set [BackgroundType](https://reference.aspose.com/slides/id/php-java/aspose.slides/backgroundtype/) slide master (melalui `getMasters`) menjadi `OwnBackground`.
3. Set [FillType](https://reference.aspose.com/slides/id/php-java/aspose.slides/filltype/) latar belakang slide master menjadi `Solid`.
4. Gunakan metode [getSolidFillColor](https://reference.aspose.com/slides/id/php-java/aspose.slides/fillformat/#getSolidFillColor) untuk menentukan warna latar belakang solid.
5. Simpan presentasi yang telah dimodifikasi.

Contoh PHP berikut menunjukkan cara mengatur warna solid (hijau) sebagai latar belakang untuk slide master:

```php
// Buat instance dari kelas Presentation.
$presentation = new Presentation();
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);

    // Atur warna latar belakang slide Master menjadi Hijau Hutan.
    $masterSlide->getBackground()->setType(BackgroundType::OwnBackground);
    $masterSlide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $masterSlide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);

    // Simpan presentasi ke disk.
    $presentation->save("MasterSlideBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Atur Latar Belakang Gradien untuk Slide**

Gradien adalah efek grafis yang dibuat melalui perubahan warna secara bertahap. Ketika digunakan sebagai latar belakang slide, gradien dapat membuat presentasi terlihat lebih artistik dan profesional. Aspose.Slides memungkinkan Anda mengatur warna gradien sebagai latar belakang untuk slide.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/).
2. Set [BackgroundType](https://reference.aspose.com/slides/id/php-java/aspose.slides/backgroundtype/) slide menjadi `OwnBackground`.
3. Set [FillType](https://reference.aspose.com/slides/id/php-java/aspose.slides/filltype/) latar belakang slide menjadi `Gradient`.
4. Gunakan metode [getGradientFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/fillformat/#getGradientFormat) pada [FillFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/fillformat/) untuk mengonfigurasi pengaturan gradien yang Anda inginkan.
5. Simpan presentasi yang telah dimodifikasi.

Contoh PHP berikut menunjukkan cara mengatur warna gradien sebagai latar belakang untuk slide:

```php
// Buat instance dari kelas Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Terapkan efek gradien pada latar belakang.
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Gradient);
    $slide->getBackground()->getFillFormat()->getGradientFormat()->setTileFlip(TileFlip::FlipBoth);

    // Simpan presentasi ke disk.
    $presentation->save("GradientBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Atur Gambar sebagai Latar Belakang Slide**

Selain isi solid dan gradien, Aspose.Slides memungkinkan Anda menggunakan gambar sebagai latar belakang slide.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/).
2. Set [BackgroundType](https://reference.aspose.com/slides/id/php-java/aspose.slides/backgroundtype/) slide menjadi `OwnBackground`.
3. Set [FillType](https://reference.aspose.com/slides/id/php-java/aspose.slides/filltype/) latar belakang slide menjadi `Picture`.
4. Muat gambar yang ingin Anda gunakan sebagai latar belakang slide.
5. Tambahkan gambar ke koleksi gambar presentasi.
6. Gunakan metode [getPictureFillFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/fillformat/#getPictureFillFormat) pada [FillFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/fillformat/) untuk menetapkan gambar sebagai latar belakang.
7. Simpan presentasi yang telah dimodifikasi.

Contoh PHP berikut menunjukkan cara mengatur gambar sebagai latar belakang untuk slide:

```php
// Buat instance dari kelas Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Atur properti gambar latar belakang.
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Picture);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);

    // Muat gambar.
    $image = Images::fromFile("Tulips.jpg");
    // Tambahkan gambar ke koleksi gambar presentasi.
    $ppImage = $presentation->getImages()->addImage($image);
    $image->dispose();

    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($ppImage);

    // Simpan presentasi ke disk.
    $presentation->save("ImageAsBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Contoh kode berikut menunjukkan cara mengatur jenis isi latar belakang menjadi gambar berulang (tiled) dan memodifikasi properti pengulangan:

```php
$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);

    $background = $firstSlide->getBackground();

    $background->setType(BackgroundType::OwnBackground);
    $background->getFillFormat()->setFillType(FillType::Picture);

    $newImage = Images::fromFile("image.png");
    $ppImage = $presentation->getImages()->addImage($newImage);
    $newImage->dispose();

    // Atur gambar yang digunakan untuk isi latar belakang.
    $backPictureFillFormat = $background->getFillFormat()->getPictureFillFormat();
    $backPictureFillFormat->getPicture()->setImage($ppImage);

    // Atur mode isi gambar menjadi Tile dan sesuaikan properti ubin.
    $backPictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $backPictureFillFormat->setTileOffsetX(15);
    $backPictureFillFormat->setTileOffsetY(15);
    $backPictureFillFormat->setTileScaleX(46);
    $backPictureFillFormat->setTileScaleY(87);
    $backPictureFillFormat->setTileAlignment(RectangleAlignment::Center);
    $backPictureFillFormat->setTileFlip(TileFlip::FlipY);

    $presentation->save("TileBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert color="primary" %}}
Baca selengkapnya: [**Gambar Ulangan Sebagai Tekstur**](/slides/id/php-java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Ubah Transparansi Gambar Latar Belakang**

Anda mungkin ingin menyesuaikan transparansi gambar latar belakang slide agar isi slide lebih menonjol. Kode PHP berikut menunjukkan cara mengubah transparansi gambar latar belakang slide:

```php
$transparencyValue = 30; // Sebagai contoh.

// Dapatkan koleksi operasi transformasi gambar.
$imageTransform = $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->getImageTransform();

// Cari efek transparansi persentase tetap yang ada.
$transparencyOperation = null;
foreach($imageTransform as $operation) {
    if (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
        $transparencyOperation = $operation;
        break;
    }
}

// Atur nilai transparansi baru.
if (java_is_null($transparencyOperation)) {
    $imageTransform->addAlphaModulateFixedEffect(100 - $transparencyValue);
} else {
    $transparencyOperation->setAmount(100 - $transparencyValue);
}
```

## **Dapatkan Nilai Latar Belakang Slide**

Aspose.Slides menyediakan kelas `BackgroundEffectiveData` untuk mengambil nilai latar belakang efektif slide. Kelas ini mengungkapkan [FillFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/fillformat/) dan [EffectFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/effectformat/) yang efektif.

Dengan menggunakan metode `getBackground` pada kelas [BaseSlide](https://reference.aspose.com/slides/id/php-java/aspose.slides/baseslide/), Anda dapat memperoleh latar belakang efektif untuk sebuah slide.

Contoh PHP berikut menunjukkan cara mendapatkan nilai latar belakang efektif slide:

```php
// Buat instance dari kelas Presentation.
$presentation = new Presentation("Sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Ambil latar belakang efektif, memperhitungkan master, tata letak, dan tema.
    $effBackground = $slide->getBackground()->getEffective();

    if ($effBackground->getFillFormat()->getFillType() == FillType::Solid)
        echo "Fill color: " . $effBackground->getFillFormat()->getSolidFillColor() . "\n";
    else
        echo "Fill type: " . $effBackground->getFillFormat()->getFillType() . "\n";
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Apakah saya dapat mengatur ulang latar belakang kustom dan mengembalikan latar belakang tema/tata letak?**

Ya. Hapus isi kustom slide, dan latar belakang akan kembali diwarisi dari slide [tata letak](/slides/id/php-java/slide-layout/)/[master](/slides/id/php-java/slide-master/) yang bersesuaian (yaitu [latar belakang tema](/slides/id/php-java/presentation-theme/)).

**Apa yang terjadi pada latar belakang jika saya mengubah tema presentasi nanti?**

Jika sebuah slide memiliki isi sendiri, maka tidak akan berubah. Jika latar belakang diwarisi dari [tata letak](/slides/id/php-java/slide-layout/)/[master](/slides/id/php-java/slide-master/), maka akan diperbarui agar sesuai dengan [tema baru](/slides/id/php-java/presentation-theme/).