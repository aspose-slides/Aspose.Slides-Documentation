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

Aspose.Slides for PHP via Java dapat membuat, mengedit, mempertahankan, dan merender format 3D bergaya PowerPoint untuk bentuk dan teks. Artikel ini mencakup efek 3D seperti rotasi, ekstrusi, bevel, pencahayaan, material, isian gradasi atau gambar, dan teks 3D.

{{% alert color="primary" %}}
Artikel ini membahas efek format 3D pada bentuk dan teks PowerPoint. Tidak membahas penyisipan atau penyuntingan file model 3D terpisah. Saat Anda mengekspor slide ke gambar, PDF, atau HTML, Aspose.Slides merender efek 3D tersebut ke dalam output 2D yang diekspor.
{{% /alert %}}

## **Konsep Format 3D**

Gunakan kelas [Shape](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/) dan metode [Shape::getThreeDFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/#getThreeDFormat--) untuk menerapkan format 3D pada sebuah bentuk. Metode ini mengembalikan [ThreeDFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/threedformat/), yang mengendalikan adegan 3D untuk bentuk tersebut.

Untuk teks, gunakan kelas [TextFrameFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframeformat/) dan metode [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframeformat/#getThreeDFormat--). Ini menerapkan format 3D pada bingkai teks, bukan pada tubuh bentuk.

Pengaturan terpenting adalah:

| Metode atau pengaturan | Apa yang dikendalikan | Kapan digunakan |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/id/php-java/aspose.slides/threedformat/#getCamera--) | Titik pandang, tipe kamera preset, rotasi, zoom, dan perspektif. | Putar objek dalam ruang 3D atau cocokkan dengan preset rotasi 3D PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/id/php-java/aspose.slides/threedformat/#getLightRig--) | Preset cahaya, arah, dan rotasi cahaya. | Ubah cara sorotan dan bayangan muncul pada permukaan 3D. |
| [setMaterial](https://reference.aspose.com/slides/id/php-java/aspose.slides/threedformat/#setMaterial-byte-) | Material permukaan, seperti datar, matte, plastik, atau logam. | Membuat geometri yang sama tampak lebih datar, lebih lembut, mengkilap, atau metalik. |
| [setExtrusionHeight](https://reference.aspose.com/slides/id/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) | Seberapa jauh bentuk menjorok ke belakang dari permukaan depannya. | Mengubah bentuk datar menjadi objek 3D yang terlihat tebal. |
| [getExtrusionColor](https://reference.aspose.com/slides/id/php-java/aspose.slides/threedformat/#getExtrusionColor--) | Warna sisi yang diekstrusi. | Membuat kedalaman terlihat atau menyelaraskan warna sisi dengan isian depan. |
| [setDepth](https://reference.aspose.com/slides/id/php-java/aspose.slides/threedformat/#setDepth-double-) | Kedalaman 3D tambahan yang digunakan oleh format 3D PowerPoint. | Sesuaikan kedalaman untuk bentuk atau teks, terutama bersama pengaturan bevel dan material. |
| [getBevelTop](https://reference.aspose.com/slides/id/php-java/aspose.slides/threedformat/#getBevelTop--) dan [getBevelBottom](https://reference.aspose.com/slides/id/php-java/aspose.slides/threedformat/#getBevelBottom--) | Tepi yang terangkat atau melengkung pada permukaan depan dan belakang. | Menambahkan tepi yang lembut atau dibentuk alih-alih permukaan datar yang tajam. |
| [getContourColor](https://reference.aspose.com/slides/id/php-java/aspose.slides/threedformat/#getContourColor--) dan [setContourWidth](https://reference.aspose.com/slides/id/php-java/aspose.slides/threedformat/#setContourWidth-double-) | Garis tepi di sekitar objek 3D. | Menekankan batas objek dalam hasil render. |

## **Buat Bentuk 3D**

Sebuah bentuk biasanya memerlukan empat jenis pengaturan sebelum tampak meyakinkan sebagai 3D:

- Pengaturan kamera, karena tampilan depan default dapat menyembunyikan ekstrusi.
- Pengaturan cahaya, karena pencahayaan membuat wajah dan sisi dapat terlihat.
- Pengaturan material, karena permukaan memengaruhi cara cahaya dirender.
- Pengaturan ekstrusi atau kedalaman, karena bentuk datar memerlukan ketebalan.

Contoh berikut membuat sebuah persegi panjang, menambahkan teks ke wajah depannya, menerapkan format 3D, menyimpan presentasi sebagai PPTX, dan merender slide menjadi gambar PNG.

```php
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

Gambar slide yang dirender menunjukkan persegi panjang sebagai blok 3D tebal:

![Persegi panjang 3D biru yang dirender dengan teks 3D putih pada wajah depan](img_01_01.png)

## **Putar Bentuk dengan Kamera**

Di PowerPoint, rotasi 3D dikonfigurasi dari panel 3-D Rotation. Nilai rotasi X, Y, dan Z sesuai dengan rotasi yang Anda atur melalui API kamera.

![Panel 3-D Rotation PowerPoint dengan nilai rotasi X, Y, dan Z disorot](img_02_01.png)

Di Aspose.Slides, atur tipe kamera dan rotasi melalui [ThreeDFormat::getCamera](https://reference.aspose.com/slides/id/php-java/aspose.slides/threedformat/#getCamera--):

```php
$shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
$shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
```

Gunakan kamera ketika Anda perlu mengubah cara penonton melihat objek. Ini tidak mengubah geometri bentuk 2D pada slide. Ini mengubah sudut pandang 3D yang digunakan oleh PowerPoint dan Aspose.Slides saat merender.

## **Tambahkan Ekstrusi dan Kedalaman**

Ekstrusi membuat bentuk tampak tebal dengan memperpanjangnya di belakang wajah depan. Di PowerPoint, kontrol kedalaman mengatur ketebalan yang terlihat, dan kontrol warna mengatur warna sisi.

![Kontrol kedalaman PowerPoint dipetakan ke properti warna ekstrusi dan tinggi ekstrusi](img_02_02.png)

Atur [ThreeDFormat::setExtrusionHeight](https://reference.aspose.com/slides/id/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) untuk ketebalan dan [ThreeDFormat::getExtrusionColor](https://reference.aspose.com/slides/id/php-java/aspose.slides/threedformat/#getExtrusionColor--) untuk warna sisi:

```php
$shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
$shape->getThreeDFormat()->setExtrusionHeight(100);
$shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 128, 0, 128));
```

Gunakan [ThreeDFormat::setDepth](https://reference.aspose.com/slides/id/php-java/aspose.slides/threedformat/#setDepth-double-) ketika Anda perlu bekerja langsung dengan nilai kedalaman PowerPoint atau menggabungkan kedalaman dengan bevel, material, dan efek teks. Dalam banyak skenario bentuk, `setExtrusionHeight` adalah pengaturan yang lebih jelas karena secara langsung menggambarkan ekstrusi yang terlihat.

## **Gunakan Isian Gradien atau Gambar dengan Efek 3D**

Format 3D independen dari isian bentuk. Anda dapat menerapkan warna solid, gradien, pola, atau isian gambar pada wajah depan dan tetap menggunakan pengaturan kamera, cahaya, material, dan ekstrusi yang sama.

Contoh ini menerapkan isian gradien pada bentuk dan warna ekstrusi yang lebih gelap pada sisi:

```php
$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);
    $shape->getTextFrame()->setText("3D Gradient");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(0, java("java.awt.Color")->BLUE);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(100, java("java.awt.Color")->ORANGE);

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(150);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 255, 140, 0));

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

Untuk menggunakan isian gambar, tambahkan gambar ke presentasi dan tetapkan ke isian bentuk:

```php
$image = Images::fromFile("image.jpg");
try {
    $picture = $presentation->getImages()->addImage($image);
} finally {
    $image->dispose();
}

$shape->getFillFormat()->setFillType(FillType::Picture);
$shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
$shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);

$shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
$shape->getThreeDFormat()->setExtrusionHeight(150);
$shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 255, 140, 0));
```

![Persegi panjang 3D yang dirender dengan isian foto pada wajah depan dan ekstrusi oranye](img_02_04.png)

## **Terapkan Format 3D pada Teks**

Format 3D pada bentuk memengaruhi tubuh bentuk. Format 3D pada teks memengaruhi bingkai teks. Ini berguna untuk efek mirip WordArt di mana huruf-huruf itu sendiri memerlukan ekstrusi, material, pencahayaan, dan pengaturan kamera.

Contoh berikut membuat teks dengan isian pola, menerapkan transformasi WordArt, dan mengonfigurasi pengaturan 3D pada [TextFrameFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframeformat/):

```php
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
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor(new Java("java.awt.Color", 255, 140, 0));
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

## **Perilaku Ekspor dan Rendering**

Aspose.Slides mempertahankan format 3D saat menyimpan ke format PowerPoint seperti PPTX. Saat merender atau mengekspor ke format tata letak tetap, adegan 3D diubah menjadi raster atau digambar ke output sebagai hasil 2D. Ini berlaku ketika Anda merender slide ke [PNG](/slides/id/php-java/convert-powerpoint-to-png/), mengekspor ke [PDF](/slides/id/php-java/convert-powerpoint-to-pdf/), mengekspor ke [HTML](/slides/id/php-java/convert-powerpoint-to-html/), atau menghasilkan frame untuk [video conversion](/slides/id/php-java/convert-powerpoint-to-video/).

- Gambar dan PDF yang diekspor tidak interaktif. Objek tidak dapat diputar oleh penonton setelah diekspor.
- Penampilan akhir tergantung pada kombinasi kamera, rig cahaya, material, ekstrusi, isian, dan skala slide.
- Jika Anda perlu memeriksa nilai format yang diwariskan atau berbasis tema, bacalah [effective shape properties](/slides/id/php-java/shape-effective-properties/).
- Beberapa format output tidak dapat menyimpan format 3D PowerPoint yang dapat disunting. Pada format tersebut, hasil visual dirender bukan disimpan sebagai pengaturan 3D yang dapat disunting.

## **FAQ**

**Apakah Aspose.Slides dapat membuat presentasi 3D interaktif?**

Aspose.Slides membuat dan merender efek 3D PowerPoint untuk bentuk dan teks. Itu tidak menjadikan gambar, PDF, atau halaman HTML yang diekspor menjadi adegan 3D interaktif yang dapat diputar oleh penonton. Pada PPTX, format 3D tetap dapat disunting di PowerPoint bila formatnya mendukung.

**Apa perbedaan antara model 3D dan efek 3D?**

Model 3D adalah objek 3D terpisah yang disisipkan ke dalam presentasi. Efek 3D adalah format yang diterapkan pada bentuk atau teks PowerPoint biasa, seperti rotasi, ekstrusi, bevel, pencahayaan, dan material. Artikel ini membahas efek 3D.

**Pengaturan apa yang diperlukan agar bentuk 3D terlihat?**

Setidaknya, atur rotasi kamera dan ekstrusi atau kedalaman. Pada praktiknya, juga atur rig cahaya dan material agar sisi yang dirender memiliki sorotan dan bayangan yang jelas.

**Apakah saya dapat menerapkan efek 3D pada bentuk dan teks?**

Ya. Gunakan [Shape::getThreeDFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/#getThreeDFormat--) untuk tubuh bentuk dan [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframeformat/#getThreeDFormat--) untuk teks.

**Apakah efek 3D akan muncul saat mengekspor ke gambar, PDF, HTML, atau frame video?**

Ya. Aspose.Slides merender efek 3D saat menghasilkan gambar slide, output PDF, output HTML, dan frame yang digunakan untuk konversi video. Output yang diekspor berisi tampilan yang dirender, bukan objek 3D yang dapat disunting.

**Apakah saya dapat membaca nilai 3D akhir setelah pewarisan dan pengaturan tema diterapkan?**

Ya. Gunakan API format efektif yang dijelaskan dalam [Shape Effective Properties](/slides/id/php-java/shape-effective-properties/) untuk membaca nilai kamera, rig cahaya, bevel, dan nilai 3D terkait akhir.