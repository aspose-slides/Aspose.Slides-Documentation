---
title: Buat dan Terapkan Efek WordArt di PHP
linktitle: WordArt
type: docs
weight: 110
url: /id/php-java/wordart/
keywords:
- WordArt
- buat WordArt
- template WordArt
- efek WordArt
- efek bayangan
- efek pantulan
- efek cahaya
- transformasi WordArt
- efek 3D
- efek bayangan luar
- efek bayangan dalam
- PHP
- Aspose.Slides
description: "Buat dan sesuaikan efek WordArt di Aspose.Slides untuk PHP via Java. Panduan langkah demi langkah ini membantu pengembang meningkatkan presentasi dengan teks profesional dalam PHP."
---
## **Gambaran Umum**

Efek WordArt memungkinkan Anda memberi gaya pada teks dengan isian, garis tepi, bayangan, pantulan, cahaya, transformasi, dan pemformatan 3D. Artikel ini menjelaskan cara membuat dan menyesuaikan efek-efek tersebut dalam presentasi PowerPoint menggunakan Aspose.Slides for PHP via Java, tanpa Microsoft Office terpasang.

## **Membuat Template WordArt Sederhana dan Menerapkannya ke Teks**

Contoh berikut membangun gaya WordArt sederhana dengan mengatur teks, font, isian pola, dan garis tepi.

Setiap contoh membuat presentasi baru dan menambahkan persegi panjang ke slide pertama; tidak diperlukan file input. Contoh pertama mengatur teks menjadi "Aspose.Slides". Posisi dan dimensi shape diukur dalam point:

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);
    $textFrame = $autoShape->getTextFrame();

    $portion = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
} finally {
    $presentation->dispose();
}
```

Atur font menjadi Arial Black dengan ukuran 36 point agar pemformatan lebih terlihat:

```php
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);
} finally {
    $presentation->dispose();
}
```

Terapkan pola [SmallGrid](https://reference.aspose.com/slides/id/php-java/aspose.slides/patternstyle/#SmallGrid) dengan latar depan oranye tua dan latar belakang putih, lalu tambahkan garis tepi teks hitam dengan lebar 1 point:

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\PatternStyle;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);

    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Pattern);
    $darkOrange = new Java("java.awt.Color", 255, 140, 0);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor($darkOrange);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->WHITE);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::SmallGrid);

    $portion->getPortionFormat()->getLineFormat()->setWidth(1);
    $portion->getPortionFormat()->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
} finally {
    $presentation->dispose();
}
```

Teks hasilnya:

![Template WordArt sederhana](WordArt_template.png)

## **Menerapkan Efek WordArt Lainnya**

Contoh berikut menunjukkan cara menerapkan bayangan, pantulan, cahaya, transformasi, dan efek 3D ke teks.

### **Menerapkan Efek Bayangan Luar**

Bayangan luar menambah kedalaman dengan menempatkan bayangan di belakang teks. Anda dapat menyesuaikan warna, arah, jarak, radius blur, skala, dan skew.

Contoh ini memanggil [enableOuterShadowEffect](https://reference.aspose.com/slides/id/php-java/aspose.slides/effectformat/#enableOuterShadowEffect--) dan mengatur bayangan hitam dengan radius blur 4 point, arah 230 derajat, serta jarak 30 point. Nilai skala 100 mempertahankan ukuran bayangan, sedangkan skew horizontal memiringkannya 20 derajat. Transformasi alpha mengatur opasitas menjadi 32%:

```php
use aspose\slides\ColorTransformOperation;
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);

    $portion->getPortionFormat()->getEffectFormat()->enableOuterShadowEffect();
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setScaleHorizontal(100);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setScaleVertical(100);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setBlurRadius(4);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setDirection(230);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setDistance(30);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setSkewHorizontal(20);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setSkewVertical(0);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->getColorTransform()->add(ColorTransformOperation::SetAlpha, 0.32);
} finally {
    $presentation->dispose();
}
```

Teks hasilnya:

![Efek Bayangan Luar](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- Ketika bayangan luar dan bayangan prasetel digunakan bersama, hanya bayangan luar yang diterapkan.
- Jika bayangan luar dan dalam digunakan secara bersamaan, efek yang dihasilkan bergantung pada versi PowerPoint. Misalnya, di PowerPoint 2013 efeknya menjadi ganda, sedangkan di PowerPoint 2007 hanya bayangan luar yang diterapkan.
{{% /alert %}}

### **Menerapkan Efek Pantulan**

Pantulan membuat salinan teks yang terpantul secara cermin. Sesuaikan posisi, skala, blur, dan opasitas untuk mengontrol tampilannya.

Contoh ini memanggil [enableReflectionEffect](https://reference.aspose.com/slides/id/php-java/aspose.slides/effectformat/#enableReflectionEffect--) dan membalik pantulan secara vertikal dengan skala -100%. Ia menggunakan radius blur 0.5 point dan jarak 4.72 point. Opasitas menurun dari 60% menjadi 0.9% antara posisi 0% dan 60% sepanjang pantulan:

```php
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\RectangleAlignment;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);

    $portion->getPortionFormat()->getEffectFormat()->enableReflectionEffect();
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setBlurRadius(0.5);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setDistance(4.72);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setStartPosAlpha(0);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setEndPosAlpha(60);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setDirection(90);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setScaleHorizontal(100);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setScaleVertical(-100);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setStartReflectionOpacity(60);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setEndReflectionOpacity(0.9);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setRectangleAlign(RectangleAlignment::BottomLeft);
} finally {
    $presentation->dispose();
}
```

Teks hasilnya:

![Efek Pantulan](reflection_effect.png)

### **Menerapkan Efek Cahaya**

Cahaya menambahkan garis tepi berwarna lembut di sekitar teks. Sesuaikan warna, opasitas, dan radius untuk mengontrol efeknya.

Contoh ini memanggil [enableGlowEffect](https://reference.aspose.com/slides/id/php-java/aspose.slides/effectformat/#enableGlowEffect--) dan menerapkan cahaya merah dengan opasitas 54% serta radius 7 point:

```php
use aspose\slides\ColorTransformOperation;
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);

    $portion->getPortionFormat()->getEffectFormat()->enableGlowEffect();
    $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->setColor(java("java.awt.Color")->RED);
    $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->getColorTransform()->add(ColorTransformOperation::SetAlpha, 0.54);
    $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->setRadius(7);
} finally {
    $presentation->dispose();
}
```

Teks hasilnya:

![Efek Cahaya](glow_effect.png)

### **Menerapkan Transformasi WordArt**

Transformasi WordArt membengkokkan, meregangkan, atau melengkungkan blok teks.

Atur [setTransform](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframeformat/#setTransform-int-) ke [ArchUpPour](https://reference.aspose.com/slides/id/php-java/aspose.slides/textshapetype/#ArchUpPour) untuk melengkungkan seluruh frame teks ke atas:

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\TextShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->setText("Aspose.Slides");
    $textFrame->getTextFrameFormat()->setTransform(TextShapeType::ArchUpPour);
} finally {
    $presentation->dispose();
}
```

Teks hasilnya:

![Transformasi WordArt](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides for PHP via Java menyediakan serangkaian [tipe transformasi](https://reference.aspose.com/slides/id/php-java/aspose.slides/textshapetype/) yang telah didefinisikan.
{{% /alert %}}

### **Menerapkan Efek 3D pada Shape dan Teks**

Anda dapat menerapkan efek 3D pada shape atau pada teksnya. Bevel, ekstrusi, pencahayaan, dan pengaturan kamera mengontrol tampilan akhir.

Contoh berikut menggunakan [ThreeDFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/threedformat/) untuk menambahkan bevel melingkar, ekstrusi oranye, dan kontur merah gelap pada persegi panjang. Dimensi bevel, tinggi ekstrusi, lebar kontur, dan kedalaman diukur dalam point. Material plastik, pencahayaan seimbang berputar 40 derajat di sekitar sumbu Z, serta kamera perspektif menentukan penampilannya:

```php
use aspose\slides\BevelPresetType;
use aspose\slides\CameraPresetType;
use aspose\slides\LightRigPresetType;
use aspose\slides\LightingDirection;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);
    $autoShape->getTextFrame()->setText("Aspose.Slides");

    $autoShape->getThreeDFormat()->getBevelBottom()->setBevelType(BevelPresetType::Circle);
    $autoShape->getThreeDFormat()->getBevelBottom()->setHeight(10.5);
    $autoShape->getThreeDFormat()->getBevelBottom()->setWidth(10.5);

    $autoShape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $autoShape->getThreeDFormat()->getBevelTop()->setHeight(12.5);
    $autoShape->getThreeDFormat()->getBevelTop()->setWidth(11);

    $orange = new Java("java.awt.Color", 255, 165, 0);
    $autoShape->getThreeDFormat()->getExtrusionColor()->setColor($orange);
    $autoShape->getThreeDFormat()->setExtrusionHeight(6);

    $darkRed = new Java("java.awt.Color", 139, 0, 0);
    $autoShape->getThreeDFormat()->getContourColor()->setColor($darkRed);
    $autoShape->getThreeDFormat()->setContourWidth(1.5);

    $autoShape->getThreeDFormat()->setDepth(3);

    $autoShape->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);

    $autoShape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
    $autoShape->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);

    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);
} finally {
    $presentation->dispose();
}
```

Shape hasilnya:

![Efek 3D pada shape](shape_3D_effect.png)

Contoh ini menerapkan pemformatan 3D serupa pada teks melalui [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframeformat/#getThreeDFormat--). Bevel yang lebih kecil membentuk tepi huruf, sementara ekstrusi dan pencahayaan memberi kedalaman pada teks:

```php
use aspose\slides\BevelPresetType;
use aspose\slides\CameraPresetType;
use aspose\slides\LightRigPresetType;
use aspose\slides\LightingDirection;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);
    $textFrame = $autoShape->getTextFrame();
    $textFrame->setText("Aspose.Slides");

    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setBevelType(BevelPresetType::Circle);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setHeight(3.5);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setWidth(3.5);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setHeight(4);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setWidth(4);

    $orange = new Java("java.awt.Color", 255, 165, 0);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getExtrusionColor()->setColor($orange);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->setExtrusionHeight(6);

    $darkRed = new Java("java.awt.Color", 139, 0, 0);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getContourColor()->setColor($darkRed);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->setContourWidth(1.5);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->setDepth(3);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);
} finally {
    $presentation->dispose();
}
```

Teks hasilnya:

![Efek 3D pada teks](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
Penerapan efek 3D pada teks atau shape‑nya—serta interaksi di antara efek‑efek tersebut—diatur oleh aturan khusus. Pertimbangkan sebuah skenario yang melibatkan teks dan shape yang menampungnya. Efek 3D mencakup representasi 3D objek dan adegan tempat objek tersebut ditempatkan.

- Jika sebuah adegan ditetapkan untuk baik shape maupun teks, adegan shape memiliki prioritas dan adegan teks diabaikan.
- Jika shape tidak memiliki adegan sendiri tetapi memiliki representasi 3D, adegan teks yang digunakan.
- Jika shape tidak memiliki efek 3D sama sekali, shape diperlakukan datar, dan efek 3D hanya diterapkan pada teks.

Perilaku ini terkait dengan metode [ThreeDFormat::getLightRig](https://reference.aspose.com/slides/id/php-java/aspose.slides/threedformat/#getLightRig--) dan [ThreeDFormat::getCamera](https://reference.aspose.com/slides/id/php-java/aspose.slides/threedformat/#getCamera--).
{{% /alert %}}

Untuk contoh lebih lanjut tentang pemformatan 3D, lihat [Buat Efek 3D dalam Presentasi Menggunakan PHP](/slides/id/php-java/3d-presentation/).

## **FAQ**

**Apakah saya dapat menggunakan efek WordArt dengan font atau skrip yang berbeda (misalnya Arab, Cina)?**

Ya, Aspose.Slides for PHP via Java mendukung Unicode dan bekerja dengan semua font serta skrip utama. Efek WordArt seperti bayangan, isian, dan garis tepi dapat diterapkan tanpa memandang bahasa, meskipun ketersediaan font dan rendernya dapat bergantung pada font sistem.

**Apakah saya dapat menerapkan efek WordArt ke elemen master slide?**

Ya, Anda dapat menerapkan efek WordArt ke shape pada master slide, termasuk placeholder judul, footer, atau teks latar. Perubahan pada tata letak master akan tercermin di semua slide terkait.

**Apakah efek WordArt memengaruhi ukuran file presentasi?**

Sedikit. Efek WordArt seperti bayangan, cahaya, dan isian gradien dapat meningkatkan ukuran file sedikit karena penambahan metadata pemformatan, namun perbedaannya biasanya dapat diabaikan.

**Apakah saya dapat melihat pratinjau hasil efek WordArt tanpa menyimpan presentasi?**

Ya, Anda dapat merender slide yang berisi WordArt menjadi gambar (misalnya PNG, JPEG) menggunakan [Slide::getImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/slide/#getImage--), atau merender shape individu menggunakan [Shape::getImage](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/#getImage--). Ini memungkinkan Anda melihat pratinjau hasil di memori atau di layar sebelum menyimpan atau mengekspor presentasi secara keseluruhan.