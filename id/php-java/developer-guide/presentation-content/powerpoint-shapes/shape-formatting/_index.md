---
title: Format Bentuk PowerPoint dalam PHP
linktitle: Pemformatan Bentuk
type: docs
weight: 20
url: /id/php-java/shape-formatting/
keywords:
- format bentuk
- format garis
- format gaya sambungan
- isian gradien
- isian pola
- isian gambar
- isian tekstur
- isian warna solid
- transparansi bentuk
- putar bentuk
- efek bevel 3D
- efek rotasi 3D
- reset pemformatan
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Pelajari cara memformat bentuk PowerPoint dalam PHP menggunakan Aspose.Slides—atur gaya isian, garis, dan efek untuk file PPT, PPTX, dan ODP dengan presisi dan kontrol penuh."
---
## **Pengantar**

Di PowerPoint, Anda dapat menambahkan bentuk ke slide. Karena bentuk terdiri dari garis, Anda dapat memformatnya dengan memodifikasi atau menerapkan efek pada kontur mereka. Selain itu, Anda dapat memformat bentuk dengan menentukan pengaturan yang mengontrol bagaimana bagian dalamnya diisi.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides untuk PHP via Java menyediakan kelas dan metode yang memungkinkan Anda memformat bentuk menggunakan opsi yang sama dengan yang tersedia di PowerPoint.

## **Format Garis**

Dengan Aspose.Slides, Anda dapat menentukan gaya garis khusus untuk sebuah bentuk. Langkah‑langkah berikut menjelaskan prosedurnya:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/).
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/) ke slide.
1. Atur [line style](https://reference.aspose.com/slides/id/php-java/aspose.slides/linestyle/) bentuk.
1. Atur lebar garis.
1. Atur [dash style](https://reference.aspose.com/slides/id/php-java/aspose.slides/linedashstyle/) garis.
1. Atur warna garis untuk bentuk.
1. Simpan presentasi yang sudah dimodifikasi sebagai file PPTX.

Kode PHP berikut menunjukkan cara memformat sebuah `AutoShape` berbentuk persegi panjang:

```php
// Instansiasi kelas Presentation yang mewakili file presentasi.
$presentation = new Presentation();
try {
    // Dapatkan slide pertama.
    $slide = $presentation->getSlides()->get_Item(0);

    // Tambahkan auto shape tipe Persegi Panjang.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

    // Atur warna isian untuk shape persegi panjang.
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    // Terapkan pemformatan pada garis persegi panjang.
    $shape->getLineFormat()->setStyle(LineStyle::ThickThin);
    $shape->getLineFormat()->setWidth(7);
    $shape->getLineFormat()->setDashStyle(LineDashStyle::Dash);

    // Atur warna untuk garis persegi panjang.
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // Simpan file PPTX ke disk.
    $presentation->save("formatted_lines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Hasilnya:

![Garis yang diformat dalam presentasi](formatted-lines.png)

## **Format Gaya Sambungan**

Berikut tiga opsi tipe sambungan:

* Bundar
* Miter
* Bevel

Secara default, ketika PowerPoint menyambungkan dua garis pada sudut (misalnya pada sudut bentuk), ia menggunakan pengaturan **Bundar**. Namun, jika Anda menggambar bentuk dengan sudut tajam, Anda mungkin lebih menyukai opsi **Miter**.

![Gaya sambungan dalam presentasi](join-style-powerpoint.png)

Kode PHP berikut menunjukkan bagaimana tiga persegi panjang (seperti pada gambar di atas) dibuat menggunakan pengaturan tipe sambungan Miter, Bevel, dan Bundar:

```php
// Instansiasi kelas Presentation yang mewakili file presentasi.
$presentation = new Presentation();
try {
    // Dapatkan slide pertama.
    $slide = $presentation->getSlides()->get_Item(0);

    // Tambahkan tiga auto shape tipe Persegi Panjang.
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

    // Atur warna isi untuk setiap shape persegi panjang.
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

    // Atur lebar garis.
    $shape1->getLineFormat()->setWidth(15);
    $shape2->getLineFormat()->setWidth(15);
    $shape3->getLineFormat()->setWidth(15);

    // Atur warna untuk garis tiap persegi panjang.
    $shape1->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape3->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // Atur gaya sambungan.
    $shape1->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
    $shape2->getLineFormat()->setJoinStyle(LineJoinStyle::Bevel);
    $shape3->getLineFormat()->setJoinStyle(LineJoinStyle::Round);

    // Tambahkan teks ke setiap persegi panjang.
    $shape1->getTextFrame()->setText("Miter Join Style");
    $shape2->getTextFrame()->setText("Bevel Join Style");
    $shape3->getTextFrame()->setText("Round Join Style");

    // Simpan file PPTX ke disk.
    $presentation->save("join_styles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Isian Gradien**

Di PowerPoint, Isian Gradien merupakan opsi pemformatan yang memungkinkan Anda menerapkan perpaduan warna secara kontinu pada sebuah bentuk. Misalnya, Anda dapat menerapkan dua atau lebih warna sehingga satu secara perlahan memudar menjadi warna lainnya.

Berikut cara menerapkan isian gradien pada bentuk menggunakan Aspose.Slides:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/).
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/) ke slide.
1. Atur [FillType](https://reference.aspose.com/slides/id/php-java/aspose.slides/filltype/) bentuk menjadi `Gradient`.
1. Tambahkan dua warna pilihan Anda dengan posisi yang ditentukan menggunakan metode `add` pada koleksi gradient stop yang disediakan oleh kelas [GradientFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/gradientformat/).
1. Simpan presentasi yang sudah dimodifikasi sebagai file PPTX.

Kode PHP berikut menunjukkan cara menerapkan efek isian gradien pada sebuah elips:

```php
// Instansiasi kelas Presentation yang mewakili file presentasi.
$presentation = new Presentation();
try {
    // Dapatkan slide pertama.
    $slide = $presentation->getSlides()->get_Item(0);

    // Tambahkan auto shape tipe Ellipse.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

    // Terapkan pemformatan gradien pada elips.
    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape::Linear);

    // Atur arah gradien.
    $shape->getFillFormat()->getGradientFormat()->setGradientDirection(GradientDirection::FromCorner2);

    // Tambahkan dua stop gradien.
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor::Purple);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0, PresetColor::Red);

    // Simpan file PPTX ke disk.
    $presentation->save("gradient_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Hasilnya:

![Elips dengan isian gradien](gradient-fill.png)

## **Isian Pola**

Di PowerPoint, Isian Pola merupakan opsi pemformatan yang memungkinkan Anda menerapkan desain dua warna—seperti titik, garis, pola silang, atau kotak—to bentuk. Anda dapat memilih warna khusus untuk latar depan dan latar belakang pola.

Aspose.Slides menyediakan lebih dari 45 gaya pola yang sudah didefinisikan yang dapat Anda terapkan pada bentuk untuk meningkatkan daya tarik visual presentasi Anda. Bahkan setelah memilih pola yang sudah didefinisikan, Anda masih dapat menentukan warna tepat yang akan digunakan.

Berikut cara menerapkan isian pola pada bentuk menggunakan Aspose.Slides:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/).
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/) ke slide.
1. Atur [FillType](https://reference.aspose.com/slides/id/php-java/aspose.slides/filltype/) bentuk menjadi `Pattern`.
1. Pilih gaya pola dari opsi yang sudah didefinisikan.
1. Atur [Background Color](https://reference.aspose.com/slides/id/php-java/aspose.slides/patternformat/#getBackColor) pola.
1. Atur [Foreground Color](https://reference.aspose.com/slides/id/php-java/aspose.slides/patternformat/#getForeColor) pola.
1. Simpan presentasi yang sudah dimodifikasi sebagai file PPTX.

Kode PHP berikut menunjukkan cara menerapkan isian pola pada sebuah persegi panjang:

```php
// Instansiasi kelas Presentation yang mewakili file presentasi.
$presentation = new Presentation();
try {
    // Dapatkan slide pertama.
    $slide = $presentation->getSlides()->get_Item(0);

    // Tambahkan auto shape tipe Persegi Panjang.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Atur tipe isian menjadi Pattern.
    $shape->getFillFormat()->setFillType(FillType::Pattern);

    // Atur gaya pola.
    $shape->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::Trellis);

    // Atur warna latar belakang dan latar depan pola.
    $shape->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shape->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);

    // Simpan file PPTX ke disk.
    $presentation->save("pattern_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Hasilnya:

![Persegi panjang dengan isian pola](pattern-fill.png)

## **Isian Gambar**

Di PowerPoint, Isian Gambar merupakan opsi pemformatan yang memungkinkan Anda menyisipkan gambar di dalam sebuah bentuk—secara efektif menggunakan gambar tersebut sebagai latar belakang bentuk.

Berikut cara menggunakan Aspose.Slides untuk menerapkan isian gambar pada bentuk:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/).
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/) ke slide.
1. Atur [FillType](https://reference.aspose.com/slides/id/php-java/aspose.slides/filltype/) bentuk menjadi `Picture`.
1. Atur mode isian gambar menjadi `Tile` (atau mode lain yang diinginkan).
1. Buat sebuah objek [PPImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/ppimage/) dari gambar yang ingin Anda gunakan.
1. Berikan gambar tersebut ke metode `SlidesPicture.setImage`.
1. Simpan presentasi yang sudah dimodifikasi sebagai file PPTX.

Misalkan kita memiliki file "lotus.png" dengan gambar berikut:

![Gambar lotus](lotus.png)

Kode PHP berikut menunjukkan cara mengisi bentuk dengan gambar:

```php
// Instansiasi kelas Presentation yang mewakili file presentasi.
$presentation = new Presentation();
try {
    // Dapatkan slide pertama.
    $slide = $presentation->getSlides()->get_Item(0);

    // Tambahkan auto shape tipe Persegi Panjang.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

    // Atur tipe isian menjadi Picture.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // Atur mode isian gambar.
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

    // Muat gambar dan tambahkan ke sumber daya presentasi.
    $image = Images::fromFile("lotus.png");
    $picture = $presentation->getImages()->addImage($image);
    $image->dispose();

    // Atur gambar.
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);

    // Simpan file PPTX ke disk.
    $presentation->save("picture_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Hasilnya:

![Bentuk dengan isian gambar](picture-fill.png)

### **Ubah Gambar Tile Menjadi Tekstur**

Jika Anda ingin mengatur gambar berulang (tiled) sebagai tekstur dan menyesuaikan perilaku pengulangan, Anda dapat menggunakan metode berikut dari kelas [PictureFillFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/id/php-java/aspose.slides/picturefillformat/#setPictureFillMode): Menetapkan mode isian gambar—baik `Tile` atau `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/id/php-java/aspose.slides/picturefillformat/#setTileAlignment): Menentukan perataan ubin di dalam bentuk.
- [setTileFlip](https://reference.aspose.com/slides/id/php-java/aspose.slides/picturefillformat/#setTileFlip): Mengontrol apakah ubin dibalik secara horizontal, vertikal, atau keduanya.
- [setTileOffsetX](https://reference.aspose.com/slides/id/php-java/aspose.slides/picturefillformat/#setTileOffsetX): Menetapkan offset horizontal ubin (dalam poin) dari asal bentuk.
- [setTileOffsetY](https://reference.aspose.com/slides/id/php-java/aspose.slides/picturefillformat/#setTileOffsetY): Menetapkan offset vertikal ubin (dalam poin) dari asal bentuk.
- [setTileScaleX](https://reference.aspose.com/slides/id/php-java/aspose.slides/picturefillformat/#setTileScaleX): Mendefinisikan skala horizontal ubin sebagai persentase.
- [setTileScaleY](https://reference.aspose.com/slides/id/php-java/aspose.slides/picturefillformat/#setTileScaleY): Mendefinisikan skala vertikal ubin sebagai persentase.

Contoh kode berikut menunjukkan cara menambahkan bentuk persegi panjang dengan isian gambar berulang dan mengonfigurasi opsi ubin:

```php
// Instansiasi kelas Presentation yang mewakili file presentasi.
$presentation = new Presentation();
try {
    // Dapatkan slide pertama.
    $firstSlide = $presentation->getSlides()->get_Item(0);

    // Tambahkan auto shape persegi panjang.
    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

    // Atur tipe isian shape menjadi Picture.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // Muat gambar dan tambahkan ke sumber daya presentasi.
    $sourceImage = Images::fromFile("lotus.png");
    $presentationImage = $presentation->getImages()->addImage($sourceImage);
    $sourceImage->dispose();

    // Tetapkan gambar ke shape.
    $pictureFillFormat = $shape->getFillFormat()->getPictureFillFormat();
    $pictureFillFormat->getPicture()->setImage($presentationImage);

    // Konfigurasikan mode isian gambar dan properti pengulangan.
    $pictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $pictureFillFormat->setTileOffsetX(-32);
    $pictureFillFormat->setTileOffsetY(-32);
    $pictureFillFormat->setTileScaleX(50);
    $pictureFillFormat->setTileScaleY(50);
    $pictureFillFormat->setTileAlignment(RectangleAlignment::BottomRight);
    $pictureFillFormat->setTileFlip(TileFlip::FlipBoth);

    // Simpan file PPTX ke disk.
    $presentation->save("tile.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Hasilnya:

![Opsi ubin](tile-options.png)

## **Isian Warna Solid**

Di PowerPoint, Isian Warna Solid merupakan opsi pemformatan yang mengisi bentuk dengan satu warna seragam. Latar belakang berwarna polos ini diterapkan tanpa gradien, tekstur, atau pola apa pun.

Untuk menerapkan isian warna solid pada bentuk menggunakan Aspose.Slides, ikuti langkah‑langkah berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/).
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/) ke slide.
1. Atur [FillType](https://reference.aspose.com/slides/id/php-java/aspose.slides/filltype/) bentuk menjadi `Solid`.
1. Tetapkan warna isian pilihan Anda ke bentuk.
1. Simpan presentasi yang sudah dimodifikasi sebagai file PPTX.

Kode PHP berikut menunjukkan cara menerapkan isian warna solid pada sebuah persegi panjang di slide PowerPoint:

```php
// Instansiasi kelas Presentation yang mewakili file presentasi.
$presentation = new Presentation();
try {
    // Dapatkan slide pertama.
    $slide = $presentation->getSlides()->get_Item(0);

    // Tambahkan auto shape tipe Persegi Panjang.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Atur tipe isian menjadi Solid.
    $shape->getFillFormat()->setFillType(FillType::Solid);

    // Atur warna isian.
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

    // Simpan file PPTX ke disk.
    $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Hasilnya:

![Bentuk dengan isian warna solid](solid-color-fill.png)

## **Atur Transparansi**

Di PowerPoint, ketika Anda menerapkan isian warna solid, gradien, gambar, atau tekstur pada bentuk, Anda juga dapat mengatur tingkat transparansi untuk mengontrol opasitas isian. Nilai transparansi yang lebih tinggi membuat bentuk menjadi lebih tembus pandang, memungkinkan latar belakang atau objek di bawahnya terlihat sebagian.

Aspose.Slides memungkinkan Anda mengatur tingkat transparansi dengan menyesuaikan nilai alfa pada warna yang digunakan untuk isian. Berikut caranya:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/).
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/) ke slide.
1. Atur [FillType](https://reference.aspose.com/slides/id/php-java/aspose.slides/filltype/) menjadi `Solid`.
1. Gunakan `Color` untuk mendefinisikan warna dengan transparansi (komponen `alpha` mengontrol transparansi).
1. Simpan presentasi.

Kode PHP berikut menunjukkan cara menerapkan warna isian transparan pada sebuah persegi panjang:

```php
// Instansiasi kelas Presentation yang mewakili file presentasi.
$presentation = new Presentation();
try {
    // Dapatkan slide pertama.
    $slide = $presentation->getSlides()->get_Item(0);

    // Tambahkan auto shape persegi panjang solid.
    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Tambahkan auto shape persegi panjang transparan di atas shape solid.
    $transparentShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
    $transparentShape->getFillFormat()->setFillType(FillType::Solid);
    $transparentShape->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", 255, 255, 0, 204));

    // Simpan file PPTX ke disk.
    $presentation->save("shape_transparency.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Hasilnya:

![Bentuk transparan](shape-transparency.png)

## **Putar Bentuk**

Aspose.Slides memungkinkan Anda memutar bentuk dalam presentasi PowerPoint. Hal ini dapat berguna saat menempatkan elemen visual dengan kebutuhan penyelarasan atau desain tertentu.

Untuk memutar sebuah bentuk pada slide, ikuti langkah‑langkah berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/).
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/) ke slide.
1. Atur properti rotasi bentuk ke sudut yang diinginkan.
1. Simpan presentasi.

Kode PHP berikut menunjukkan cara memutar bentuk sebesar 5 derajat:

```php
// Instansiasi kelas Presentation yang mewakili file presentasi.
$presentation = new Presentation();
try {
    // Dapatkan slide pertama.
    $slide = $presentation->getSlides()->get_Item(0);

    // Tambahkan auto shape tipe Persegi Panjang.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Putar shape sebesar 5 derajat.
    $shape->setRotation(5);

    // Simpan file PPTX ke disk.
    $presentation->save("shape_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Hasilnya:

![Rotasi bentuk](shape-rotation.png)

## **Tambahkan Efek Bevel 3D**

Aspose.Slides memungkinkan Anda menerapkan efek bevel 3D pada bentuk dengan mengonfigurasi properti [ThreeDFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/threedformat/) mereka.

Untuk menambahkan efek bevel 3D pada bentuk, ikuti langkah‑langkah berikut:

1. Instansiasi kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/).
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/) ke slide.
1. Konfigurasikan [ThreeDFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/threedformat/) bentuk untuk mendefinisikan pengaturan bevel.
1. Simpan presentasi.

Kode PHP berikut menunjukkan cara menerapkan efek bevel 3D pada sebuah bentuk:

```php
// Buat instance dari kelas Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Tambahkan shape ke slide.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $shape->getLineFormat()->setWidth(2.0);

    // Atur properti ThreeDFormat shape.
    $shape->getThreeDFormat()->setDepth(4);
    $shape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $shape->getThreeDFormat()->getBevelTop()->setHeight(6);
    $shape->getThreeDFormat()->getBevelTop()->setWidth(6);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::ThreePt);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);

    // Simpan presentasi sebagai file PPTX.
    $presentation->save("3D_bevel_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Hasilnya:

![Efek bevel 3D](3D-bevel-effect.png)

## **Tambahkan Efek Rotasi 3D**

Aspose.Slides memungkinkan Anda menerapkan efek rotasi 3D pada bentuk dengan mengonfigurasi properti [ThreeDFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/threedformat/) mereka.

Untuk menerapkan rotasi 3D pada sebuah bentuk:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/).
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/) ke slide.
1. Gunakan [setCameraType](https://reference.aspose.com/slides/id/php-java/aspose.slides/camera/#setCameraType) dan [setLightType](https://reference.aspose.com/slides/id/php-java/aspose.slides/lightrig/#setLightType) untuk mendefinisikan rotasi 3D.
1. Simpan presentasi.

Kode PHP berikut menunjukkan cara menerapkan efek rotasi 3D pada sebuah bentuk:

```php
// Buat instance dari kelas Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $autoShape->getTextFrame()->setText("Hello, Aspose!");

    $autoShape->getThreeDFormat()->setDepth(6);
    $autoShape->getThreeDFormat()->getCamera()->setRotation(40, 35, 20);
    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::IsometricLeftUp);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);

    // Simpan presentasi sebagai file PPTX.
    $presentation->save("3D_rotation_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Hasilnya:

![Efek rotasi 3D](3D-rotation-effect.png)

## **Setel Ulang Pemformatan**

Kode Java berikut menunjukkan cara menyetel ulang pemformatan slide dan mengembalikan posisi, ukuran, serta pemformatan semua bentuk dengan placeholder pada [LayoutSlide](https://reference.aspose.com/slides/id/php-java/aspose.slides/layoutslide/) ke pengaturan default mereka:

```php
$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        // Setel ulang setiap shape pada slide yang memiliki placeholder pada layout.
        $slide->reset();
    }
    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Apakah pemformatan bentuk memengaruhi ukuran file presentasi akhir?**

Hanya sangat sedikit. Gambar dan media yang disematkan mengambil sebagian besar ruang file, sementara parameter bentuk seperti warna, efek, dan gradien disimpan sebagai metadata dan hampir tidak menambah ukuran.

**Bagaimana saya dapat mendeteksi bentuk pada slide yang memiliki pemformatan identik sehingga dapat saya grupkan?**

Bandingkan masing‑masing properti pemformatan utama bentuk—pengaturan isian, garis, dan efek. Jika semua nilai yang bersesuaian cocok, perlakukan gaya mereka sebagai identik dan grupkan bentuk‑bentuk tersebut secara logis, yang memudahkan manajemen gaya selanjutnya.

**Apakah saya dapat menyimpan sekumpulan gaya bentuk khusus ke file terpisah untuk digunakan kembali di presentasi lain?**

Ya. Simpan contoh bentuk dengan gaya yang diinginkan dalam slide templat atau file templat .POTX. Saat membuat presentasi baru, buka templat tersebut, kloning bentuk bergaya yang diperlukan, dan terapkan kembali pemformatannya di mana diperlukan.