---
title: Buat Efek 3D dalam Presentasi Menggunakan PHP
linktitle: Presentasi 3D
type: docs
weight: 232
url: /id/php-java/3d-presentation/
keywords:
- PowerPoint 3D
- presentasi 3D
- rotasi 3D
- kedalaman 3D
- ekstrusi 3D
- gradien 3D
- teks 3D
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Terapkan dan render efek 3D untuk bentuk dan teks PowerPoint dalam PHP dengan Aspose.Slides. Konfigurasikan kamera, pencahayaan, material, ekstrusi, isian, dan teks 3D."
---
## **Ikhtisar**

Aspose.Slides for PHP via Java dapat membuat, mengedit, mempertahankan, dan merender format 3D bergaya PowerPoint untuk bentuk dan teks. Artikel ini mencakup efek 3D seperti rotasi, ekstrusi, bevel, pencahayaan, material, isian gradien atau gambar, dan teks 3D.

{{% alert color="info" title="Note" %}}
Artikel ini membahas efek format 3D pada bentuk dan teks PowerPoint. Ini bukan tentang menyisipkan atau mengedit file model 3D terpisah. Ketika Anda mengekspor slide ke gambar, PDF, atau HTML, Aspose.Slides merender efek 3D tersebut ke output 2D yang diekspor.
{{% /alert %}}

## **Konsep Pemformatan 3D**

Gunakan metode [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat) untuk menerapkan pemformatan 3D pada sebuah bentuk. Metode ini mengembalikan [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/), yang mengendalikan adegan 3D untuk bentuk tersebut.

Untuk teks, gunakan metode [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#getThreeDFormat). Ini menerapkan pemformatan 3D ke bingkai teks alih-alih badan bentuk.

Anggota API yang paling penting adalah:

| Anggota API | Apa yang dikontrol | Kapan menggunakannya |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getCamera) | Titik pandang, tipe kamera preset, rotasi, zoom, dan perspektif. | Putar objek dalam ruang 3D atau cocokkan dengan preset rotasi 3D PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getLightRig) | Preset cahaya, arah, dan rotasi cahaya. | Ubah cara sorotan dan bayangan muncul pada permukaan 3D. |
| [getMaterial](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getMaterial) dan [setMaterial](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setMaterial) | Material permukaan, seperti rata, matte, plastik, atau logam. | Membuat geometri yang sama terlihat lebih rata, lebih lembut, mengkilap, atau bersifat logam. |
| [getExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getExtrusionHeight) dan [setExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setExtrusionHeight) | Seberapa jauh bentuk memperluas ke belakang dari sisi depannya. | Mengubah bentuk datar menjadi objek 3D tebal yang terlihat. |
| [getExtrusionColor](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getExtrusionColor) | Warna sisi yang diekstrusi. | Membuat kedalaman terlihat atau menyelaraskan warna sisi dengan isian depan. |
| [getDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getDepth) dan [setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setDepth) | Kedalaman 3D tambahan yang digunakan oleh pemformatan 3D PowerPoint. | Sesuaikan kedalaman untuk bentuk atau teks, terutama bersama dengan pengaturan bevel dan material. |
| [getBevelTop](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getBevelTop) dan [getBevelBottom](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getBevelBottom) | Tepi yang terangkat atau melengkung pada sisi depan dan belakang. | Tambahkan tepi yang lebih lembut atau dibentuk alih-alih permukaan datar yang tajam. |
| [getContourColor](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getContourColor) dan [getContourWidth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getContourWidth) dan [setContourWidth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setContourWidth) | Garis luar di sekitar objek 3D. | Tekankan batas objek dalam output yang dirender. |

## **Buat Bentuk 3D**

Sebuah bentuk biasanya membutuhkan empat jenis pengaturan sebelum tampak meyakinkan sebagai 3D:

- Pengaturan kamera, karena tampilan depan default dapat menyembunyikan ekstrusi.
- Pengaturan cahaya, karena pencahayaan membuat wajah dan sisi dapat dibaca.
- Pengaturan material, karena permukaan memengaruhi cara cahaya dirender.
- Pengaturan ekstrusi atau kedalaman, karena bentuk datar membutuhkan ketebalan.

Contoh berikut membuat sebuah persegi panjang, menambahkan teks ke sisi depannya, dan menerapkan pemformatan 3D. Nilai rotasi kamera dalam derajat, dan tinggi ekstrusi adalah 100 poin. Contoh ini merender slide ke gambar PNG dengan dimensi dua kali ukuran default dan menyimpan presentasi sebagai PPTX.

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);

    $shape->getTextFrame()->setText("3D");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 100, 149, 237));

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(100);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor(java("java.awt.Color")->BLUE);

    $thumbnail = $slide->getImage($imageScale, $imageScale);
    try {
        $thumbnail->save("shape_3d.png", ImageFormat::Png);
    } finally {
        $thumbnail->dispose();
    }

    $presentation->save("shape_3d.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Gambar slide yang dirender menampilkan persegi panjang sebagai blok 3D tebal:

![Persegi panjang 3D biru yang dirender dengan teks 3D putih pada sisi depan](img_01_01.png)

## **Putar Bentuk dengan Kamera**

Di PowerPoint, rotasi 3D dikonfigurasi dari panel Rotasi 3-D. Nilai rotasi X, Y, dan Z sesuai dengan rotasi yang Anda atur melalui API kamera.

![Panel Rotasi 3-D PowerPoint dengan nilai rotasi X, Y, dan Z disorot](img_02_01.png)

Dalam Aspose.Slides, akses kamera melalui [ThreeDFormat::getCamera](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getCamera). Contoh ini membuat sebuah persegi panjang, memilih tampilan depan ortografik, dan mengatur rotasi X, Y, dan Z-nya masing-masing menjadi 20, 30, dan 40 derajat. Ia mengkonfigurasi bentuk di memori tanpa menyimpan file:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
} finally {
    $presentation->dispose();
}
```

Gunakan kamera ketika Anda perlu mengubah cara penonton melihat objek. Ini tidak mengubah geometri bentuk 2D pada slide. Ini mengubah sudut pandang 3D yang digunakan oleh PowerPoint dan Aspose.Slides saat merender.

### **Salin Orientasi Kamera dari Bentuk Template**

Untuk mencocokkan orientasi bentuk templat, bacalah preset kameranya dengan [Camera::getCameraType](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#getCameraType) dan sudut rotasinya dengan [Camera::getRotation](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#getRotation). Contoh ini membuka `template.pptx` dan menyalin orientasi kamera dari bentuk pertama pada slide pertama ke bentuk kedua. Kedua bentuk sudah memiliki pencahayaan 3D, dan bentuk kedua tidak memiliki rotasi kamera yang eksplisit.

Sudutnya dalam derajat. Indeks `0` adalah lintang, indeks `1` adalah bujur, dan indeks `2` adalah revolusi. Kirimkan ke [Camera::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setRotation) dalam urutan itu. Jika sumber mengembalikan `null`, berarti tidak ada rotasi eksplisit, jadi biarkan sudut bentuk kedua tidak disetel. Rotasi eksplisit `(0, 0, 0)` mengembalikan tiga nol dan harus disalin.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();
    
    $sourceCamera = $shapes->get_Item(0)->getThreeDFormat()->getCamera();
    $destinationCamera = $shapes->get_Item(1)->getThreeDFormat()->getCamera();

    $destinationCamera->setCameraType($sourceCamera->getCameraType());
    $angles = java_values($sourceCamera->getRotation());
    if ($angles !== null) {
        $destinationCamera->setRotation($angles[0], $angles[1], $angles[2]);
    }

    $presentation->save("camera-copy.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Saat Anda membuka kembali `camera-copy.pptx` di PowerPoint, panah di kanan memiliki preset kamera dan rotasi yang sama dengan persegi panjang di kiri. Kedua bentuk menggunakan pencahayaan dan kedalaman ekstrusi yang sama.

![Sebuah persegi panjang 3D biru dan panah kanan dengan orientasi kamera yang cocok, dilihat dari atas dan kanan](camera-orientation.png)

## **Tambahkan Ekstrusi dan Kedalaman**

Ekstrusi membuat bentuk tampak tebal dengan memperpanjangnya di belakang sisi depan. Di PowerPoint, kontrol kedalaman menentukan ketebalan yang terlihat ini, dan kontrol warna menentukan warna sisi.

![Kontrol kedalaman PowerPoint yang dipetakan ke properti warna ekstrusi dan tinggi ekstrusi](img_02_02.png)

Gunakan [ThreeDFormat::setExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setExtrusionHeight) untuk mengatur ketebalan dan [ThreeDFormat::getExtrusionColor](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getExtrusionColor) untuk mengakses warna sisi. Contoh ini memberikan persegi panjang ekstrusi 100 poin dengan sisi ungu dan memutar kamera untuk memperlihatkan ketebalannya. Ia mengkonfigurasi bentuk di memori tanpa menyimpan file:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);

    $extrusionColor = new Java("java.awt.Color", 128, 0, 128);

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(100);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor($extrusionColor);
} finally {
    $presentation->dispose();
}
```

Metode [ThreeDFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setDepth) mengatur kedalaman suatu bentuk 3D. Metode [setExtrusionHeight](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setExtrusionHeight) mengontrol tinggi efek ekstrusi, seperti yang ditunjukkan dalam contoh ini.

## **Gunakan Isian Gradien atau Gambar dengan Efek 3D**

Pemformatan 3D bersifat independen dari isian bentuk. Anda dapat menerapkan warna solid, gradien, pola, atau isian gambar ke sisi depan dan tetap menggunakan pengaturan kamera, cahaya, material, dan ekstrusi yang sama.

Contoh ini menerapkan gradien biru-ke-oren pada sisi depan dan warna oranye gelap pada ekstrusi 150 poin. Hentian gradien pada 0 dan 100 menandai awal dan akhir gradien. Nilai rotasi kamera dalam derajat. Slide dirender ke gambar PNG dengan dimensi dua kali ukuran default:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);

    $shape->getTextFrame()->setText("3D Gradient");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(0, java("java.awt.Color")->BLUE);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(100, new Java("java.awt.Color", 255, 165, 0));

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $extrusionColor = new Java("java.awt.Color", 255, 140, 0);
    $shape->getThreeDFormat()->setExtrusionHeight(150);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor($extrusionColor);

    $thumbnail = $slide->getImage($imageScale, $imageScale);
    try {
        $thumbnail->save("gradient_3d.png", ImageFormat::Png);
    } finally {
        $thumbnail->dispose();
    }
} finally {
    $presentation->dispose();
}
```

![Persegi panjang 3D yang dirender dengan isian gradien biru-ke-oren dan ekstrusi oranye](img_02_03.png)

Untuk menggunakan isian gambar sebagai gantinya, tambahkan gambar ke presentasi dan tetapkan ke isian bentuk. Contoh ini memerlukan file yang ada bernama "image.jpg" di direktori kerja. Ia memperluas gambar untuk mengisi persegi panjang, menerapkan ekstrusi 150 poin, dan mengatur rotasi kamera dalam derajat. Ia mengkonfigurasi bentuk di memori tanpa menyimpan atau merender file:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);

    $sourceImage = Images::fromFile("image.jpg");

    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        $sourceImage->dispose();
    }

    $shape->getFillFormat()->setFillType(FillType::Picture);
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($image);
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);

    $extrusionColor = new Java("java.awt.Color", 255, 140, 0);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(150);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor($extrusionColor);
} finally {
    $presentation->dispose();
}
```

![Persegi panjang 3D yang dirender dengan isian foto pada sisi depan dan ekstrusi oranye](img_02_04.png)

## **Terapkan Pemformatan 3D pada Teks**

Pemformatan 3D pada bentuk memengaruhi badan bentuk. Pemformatan 3D pada teks memengaruhi bingkai teks. Ini berguna untuk efek mirip WordArt di mana hurufnya sendiri memerlukan ekstrusi, material, pencahayaan, dan pengaturan kamera.

Contoh berikut membuat teks dengan pola kisi oranye-dan-putih, menerapkan lengkungan ke atas, dan mengkonfigurasi pengaturan 3D melalui [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#getThreeDFormat). Tinggi ekstrusi dan kedalaman dalam poin, dan rotasi cahaya dalam derajat. Isian bentuk dan garis luar disembunyikan sehingga hanya teks yang terlihat. Contoh ini merender gambar PNG dengan dimensi slide dua kali ukuran default dan menyimpan presentasi sebagai PPTX:

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\PatternStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextShapeType;

$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);

    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getTextFrame()->setText("3D Text");

    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Pattern);
    $patternColor = new Java("java.awt.Color", 255, 140, 0);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor($patternColor);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->WHITE);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::LargeGrid);

    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(128);

    $textFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat->setTransform(TextShapeType::ArchUp);
    $textFrameFormat->getThreeDFormat()->setExtrusionHeight(3.5);
    $textFrameFormat->getThreeDFormat()->setDepth(3);
    $textFrameFormat->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);
    $textFrameFormat->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $textFrameFormat->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
    $textFrameFormat->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);
    $textFrameFormat->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);

    $thumbnail = $slide->getImage($imageScale, $imageScale);
    try {
        $thumbnail->save("text_3d.png", ImageFormat::Png);
    } finally {
        $thumbnail->dispose();
    }

    $presentation->save("text_3d.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Teks 3D yang dirender dengan transformasi WordArt melengkung, isian pola oranye, dan ekstrusi gelap](img_02_05.png)

## **Jaga Teks Tetap Datar pada Bentuk 3D**

Untuk menjaga teks tetap dapat dibaca sambil mempertahankan tampilan 3D bentuk, panggil [TextFrameFormat::setKeepTextFlat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setKeepTextFlat) melalui [TextFrame::getTextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getTextFrameFormat). Ketika nilai `true`, teks tetap di luar adegan 3D. Ketika `false`, teks berpartisipasi dalam adegan dan mengikuti orientasi 3D-nya.

Pengaturan ini tidak menghapus pemformatan 3D bentuk: kamera, pencahayaan, material, dan ekstrusinya tetap dikonfigurasi melalui [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat). Ini juga berbeda dari rotasi biasa. [Shape::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) memutar bentuk di bidang slide, sementara [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setRotationAngle) mengontrol rotasi khusus teks dalam kotak pembatasnya. Menjaga teks di luar adegan 3D tidak mereset kedua sudut tersebut.

Contoh mandiri berikut membuat persegi panjang biru dengan teks dan menggandakannya di sebelah asli. Kedua bentuk memiliki pemformatan 3D yang sama; hanya pengaturan teks yang berbeda: `false` di kiri dan `true` di kanan. Sudut kamera dalam derajat, dan tinggi ekstrusi 40 poin. Contoh ini menyimpan presentasi sebagai PPTX dan merender slide perbandingan ke PNG dengan dimensi dua kali ukuran default.

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAnchorType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 70, 160, 240, 140);

    $shape->getTextFrame()->setText("Readable text");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(28);
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->setAlignment(TextAlignment::Center);
    $shape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Center);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 100, 149, 237));

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(30, 30, 0);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(40);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 65, 105, 225));
    $shape->getTextFrame()->getTextFrameFormat()->setKeepTextFlat(false);

    $flatTextShape = $slide->getShapes()->addClone($shape, 400, 160);
    $flatTextShape->getTextFrame()->getTextFrameFormat()->setKeepTextFlat(true);

    $presentation->save("keep_text_flat.pptx", SaveFormat::Pptx);
    $image = $slide->getImage(2, 2);
    try {
        $image->save("keep_text_flat.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Di kiri, teks mengikuti orientasi 3D. Di kanan, teks tetap datar dan lebih mudah dibaca. Kedua persegi panjang mempertahankan ekstrusi dan orientasi 3D yang terlihat sama.

![Persegi panjang 3D berdampingan: teks mengikuti orientasi 3D di kiri dan tetap datar di kanan](keep_text_flat.png)

## **Perilaku Ekspor dan Rendering**

Aspose.Slides mempertahankan pemformatan 3D saat menyimpan ke format PowerPoint seperti PPTX. Saat merender atau mengekspor ke format tata letak tetap, adegan 3D dirasterisasi atau digambar ke output sebagai hasil 2D. Ini berlaku ketika Anda merender slide ke [PNG](/slides/id/php-java/convert-powerpoint-to-png/), mengekspor ke [PDF](/slides/id/php-java/convert-powerpoint-to-pdf/), mengekspor ke [HTML](/slides/id/php-java/convert-powerpoint-to-html/), atau menghasilkan frame untuk [konversi video](/slides/id/php-java/convert-powerpoint-to-video/).

- Gambar dan PDF yang diekspor tidak interaktif. Objek tidak dapat diputar oleh penonton setelah diekspor.
- Penampilan akhir tergantung pada kombinasi kamera, rig cahaya, material, ekstrusi, isian, dan skala slide.
- Jika Anda perlu memeriksa nilai pemformatan yang diwariskan atau berbasis tema, bacalah [properti bentuk yang efektif](/slides/id/php-java/shape-effective-properties/).
- Beberapa format output tidak dapat menyimpan pemformatan 3D PowerPoint yang dapat diedit. Pada format tersebut, hasil visual dirender alih-alih dipertahankan sebagai pengaturan 3D yang dapat diedit.

## **FAQ**

**Apakah Aspose.Slides dapat membuat presentasi 3D interaktif?**

Aspose.Slides membuat dan merender efek 3D PowerPoint untuk bentuk dan teks. Ia tidak menjadikan gambar, PDF, atau halaman HTML yang diekspor menjadi adegan 3D interaktif yang dapat diputar oleh penonton. Pada PPTX, pemformatan 3D tetap dapat diedit di PowerPoint bila format tersebut mendukungnya.

**Apa perbedaan antara model 3D dan efek 3D?**

Model 3D adalah objek 3D terpisah yang disisipkan ke dalam presentasi. Efek 3D adalah pemformatan yang diterapkan pada bentuk atau teks PowerPoint biasa, seperti rotasi, ekstrusi, bevel, pencahayaan, dan material. Artikel ini membahas efek 3D.

**Pengaturan apa yang diperlukan untuk bentuk 3D yang terlihat?**

Setidaknya, atur rotasi kamera dan ekstrusi atau kedalaman. Praktiknya, juga atur rig cahaya dan material agar permukaan yang dirender memiliki sorotan dan bayangan yang jelas.

**Apakah saya dapat menerapkan efek 3D pada bentuk dan teks?**

Ya. Gunakan [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat) untuk badan bentuk dan [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#getThreeDFormat) untuk teks.

**Apakah efek 3D akan muncul saat mengekspor ke gambar, PDF, HTML, atau frame video?**

Ya. Aspose.Slides merender efek 3D saat menghasilkan gambar slide, output PDF, output HTML, dan frame yang digunakan untuk konversi video. Output yang diekspor berisi tampilan yang dirender, bukan objek 3D yang dapat diedit.

**Apakah saya dapat membaca nilai 3D akhir setelah pewarisan dan pengaturan tema diterapkan?**

Ya. Gunakan API pemformatan efektif yang dijelaskan dalam [Properti Bentuk Efektif](/slides/id/php-java/shape-effective-properties/) untuk membaca nilai kamera, rig cahaya, bevel, dan nilai 3D terkait lainnya.