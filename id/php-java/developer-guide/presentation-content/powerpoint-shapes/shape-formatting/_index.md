---
title: Format Bentuk PowerPoint dalam PHP
linktitle: Pemformatan Bentuk
type: docs
weight: 20
url: /id/php-java/shape-formatting/
keywords:
- format bentuk
- format garis
- efek sketsa
- garis bentuk sketsa
- format gaya sambungan
- isian gradien
- isian pola
- isian gambar
- isian tekstur
- isian warna solid
- transparansi bentuk
- rendering bentuk hitam-putih
- rendering bentuk skala abu-abu
- putar bentuk
- efek bevel 3D
- efek rotasi 3D
- reset pemformatan
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Pelajari cara memformat bentuk PowerPoint dalam PHP menggunakan Aspose.Slides—atur isian, garis, dan gaya efek untuk file PPT dan PPTX dengan presisi dan kontrol penuh."
---
## **Pendahuluan**

Format bentuk di PowerPoint dengan menyesuaikan kontur, isian, dan efeknya. Aspose.Slides untuk PHP via Java memungkinkan Anda mengontrol pengaturan ini secara programatik, termasuk transparansi, rotasi, dan pemformatan 3D.

![Opsi pemformatan bentuk di PowerPoint](format-shape-powerpoint.png)

Aspose.Slides untuk PHP via Java menyediakan kelas dan metode yang memungkinkan Anda memformat bentuk menggunakan opsi yang sama tersedia di PowerPoint.

## **Format Garis**

Gunakan [Shape::getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getLineFormat) untuk mengontrol kontur suatu bentuk. Contoh ini membuat sebuah persegi panjang tanpa isian dengan kontur biru bergaris titik. [LineFormat::setStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setStyle) memilih garis gabungan tebal-tipis, sementara [LineFormat::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setWidth) mengatur lebarnya menjadi 7 poin dan [LineFormat::setDashStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setDashStyle) memilih pola garis.

```php
use aspose\slides\FillType;
use aspose\slides\LineDashStyle;
use aspose\slides\LineStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->setStyle(LineStyle::ThickThin);
    $shape->getLineFormat()->setWidth(7);
    $shape->getLineFormat()->setDashStyle(LineDashStyle::Dash);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    $presentation->save("formatted_lines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Hasil:

![Garis yang diformat dalam presentasi](formatted-lines.png)

### **Atur Pola Garis Kustom**

Gunakan [LineFormat::setCustomDashPattern](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setCustomDashPattern) ketika gaya garis yang sudah ditentukan tidak menyediakan panjang dash dan celah yang Anda butuhkan, misalnya untuk kontur bermerek atau diagram teknis. Menetapkan pola secara otomatis mengubah gaya dash garis menjadi [LineDashStyle::Custom](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/).

Entri array bergantian antara panjang dash dan celah, dimulai dengan dash. Setiap nilai merupakan kelipatan lebar garis: `[4, 2]` pada lebar 3 poin menghasilkan dash 12 poin diikuti celah 6 poin. Gunakan pasangan nilai terbatas dan tidak negatif untuk mendefinisikan segmen dash-dan-celah yang lengkap. Contoh ini menggunakan nilai positif agar setiap dash dan celah terlihat.

Contoh ini membuat lima garis biru dengan panjang yang sama dan cap datar. Tiga pertama membandingkan pola pada lebar 3 poin. Yang keempat mengulang pola pertama dengan lebar dua kali lipat, menggandakan panjang dash dan celah. Yang kelima beralih dari pola khusus ke garis solid.

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\LineCapStyle;
use aspose\slides\LineDashStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(600, 300, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $patterns = [
        [4, 2],
        [1, 2],
        [6, 2, 1, 2],
        [4, 2],
        [4, 2]
    ];
    $lineColor = new Java("java.awt.Color", 0, 0, 139);

    for ($i = 0; $i < count($patterns); $i++) {
        $line = $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 50 + $i * 50, 500, 0);
        $line->getLineFormat()->setWidth($i == 3 ? 6 : 3);
        $line->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
        $line->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
        $line->getLineFormat()->setCapStyle(LineCapStyle::Flat);
        $line->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle::None);
        $line->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::None);
        $line->getLineFormat()->setCustomDashPattern($patterns[$i]);
    }

    // Kembalikan garis terakhir ke gaya solid.
    $slide->getShapes()->get_Item(4)->getLineFormat()->setDashStyle(LineDashStyle::Solid);

    $presentation->save("custom_dash_patterns.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Untuk kembali ke gaya bergaris dash yang telah ditentukan, berikan [LineDashStyle::Dash](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/) ke [LineFormat::setDashStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setDashStyle). Gaya yang dipilih mengontrol tampilan garis.

Hasil di PowerPoint, dari atas ke bawah: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; dan **Solid, 3 pt**.

![Tiga pola dash kustom, garis lebih lebar menggunakan pola pertama, dan garis solid di PowerPoint](custom-dash-patterns.png)

### **Atur Cap Garis**

Gunakan [LineFormat::setCapStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setCapStyle) untuk mengatur ujung garis terbuka. Kelas [LineCapStyle](https://reference.aspose.com/slides/php-java/aspose.slides/linecapstyle/) menyediakan tiga gaya cap eksplisit:

- `Flat`: Garis berhenti pada titik akhir.
- `Round`: Cap setengah lingkaran melampaui titik akhir sebesar setengah lebar garis.
- `Square`: Cap persegi melampaui titik akhir sebesar setengah lebar garis.

Kelas ini juga mencakup `NotDefined`, yang berarti tidak ada gaya cap yang ditetapkan secara eksplisit.

Cap berbeda dari ujung panah, yang menambahkan simbol pada ujung garis, dan sambungan, yang mengontrol sudut antara segmen garis. Contoh ini menonaktifkan ujung panah melalui [LineFormat::setBeginArrowheadStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setBeginArrowheadStyle) dan [LineFormat::setEndArrowheadStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setEndArrowheadStyle) sehingga hanya bentuk cap yang dibandingkan.

Contoh berikut membuat tiga garis horizontal yang pada dasarnya identik, dengan lebar 20 poin. Dari atas ke bawah, mereka menggunakan cap flat, round, dan square. Titik akhir mereka memiliki koordinat horizontal yang sama; cap round dan square meluas 10 poin di luar setiap titik akhir.

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\LineCapStyle;
use aspose\slides\LineDashStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(500, 240, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $capStyles = [LineCapStyle::Flat, LineCapStyle::Round, LineCapStyle::Square];

    for ($i = 0; $i < count($capStyles); $i++) {
        $line = $slide->getShapes()->addAutoShape(ShapeType::Line, 100, 50 + $i * 70, 300, 0);
        $line->getLineFormat()->setWidth(20);
        $line->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
        $lineColor = new Java("java.awt.Color", 0, 0, 139);
        $line->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
        $line->getLineFormat()->setDashStyle(LineDashStyle::Solid);
        $line->getLineFormat()->setCapStyle($capStyles[$i]);
        $line->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle::None);
        $line->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::None);
    }

    $presentation->save("line_caps.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Hasil di PowerPoint, dari atas ke bawah: **Flat**, **Round**, dan **Square**.

![Cap flat, round, dan square pada garis tebal identik di PowerPoint](line-caps.png)

## **Terapkan Efek Sketsa pada Garis Bentuk**

Efek sketsa membuat garis bentuk terlihat seperti digambar tangan. Gunakan [Shape::getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getLineFormat) untuk mengakses pengaturan garis, [LineFormat::getSketchFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#getSketchFormat) untuk mengakses pengaturan sketsa, dan [SketchFormat::setSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/#setSketchType) untuk memilih nilai dari kelas [LineSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/).

Kode PHP berikut menunjukkan cara menerapkan efek [LineSketchType::Curved](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/) , membaca nilai yang ditetapkan secara eksplisit, dan menghapus efek dengan [LineSketchType::None](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/):

```php
use aspose\slides\LineSketchType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

    $sketchFormat = $shape->getLineFormat()->getSketchFormat();
    $sketchFormat->setSketchType(LineSketchType::Curved);
    $explicitSketchType = $sketchFormat->getSketchType();
    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;
    $sketchFormat->setSketchType(LineSketchType::None);
} finally {
    $presentation->dispose();
}
```

Nilai yang dikembalikan oleh [SketchFormat::getSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/#getSketchType) mewakili pengaturan yang ditetapkan langsung pada bentuk. Jika pemformatan garis dapat diwarisi dari tema, master slide, atau layout slide, gunakan [LineFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#getEffective), akses metode `getSketchFormat` dari objek yang dikembalikan, dan baca nilai `getSketchType`-nya. Nilai efektif mencerminkan pemformatan yang sebenarnya diterapkan setelah pewarisan diselesaikan. Contoh ini memerlukan presentasi yang sudah ada dengan setidaknya satu bentuk pada slide pertama dan mencetak kedua nilai:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $lineFormat = $shape->getLineFormat();
    $explicitSketchType = $lineFormat->getSketchFormat()->getSketchType();
    $effectiveLineFormat = $lineFormat->getEffective();
    $effectiveSketchType = $effectiveLineFormat->getSketchFormat()->getSketchType();

    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;
    echo "Effective sketch type: " . $effectiveSketchType . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Format Gaya Sambungan**

Berikut tiga opsi tipe sambungan:

* Round
* Miter
* Bevel

Gaya sambungan mengontrol bagaimana dua segmen kontur bertemu di suatu sudut. Gunakan **Round** untuk sudut melengkung, **Miter** untuk sudut tajam, atau **Bevel** untuk sudut rata.

![Gaya sambungan dalam presentasi](join-style-powerpoint.png)

Contoh ini membuat tiga persegi panjang hitam dengan kontur biru lebar 15 poin. Ia mengatur [LineFormat::setJoinStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setJoinStyle) ke nilai miter, bevel, dan round dari [LineJoinStyle](https://reference.aspose.com/slides/php-java/aspose.slides/linejoinstyle/), masing‑masing, untuk membandingkan cara sudut digambar.

```php
use aspose\slides\FillType;
use aspose\slides\LineJoinStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $miterShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
    $bevelShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
    $roundShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

    $miterShape->getFillFormat()->setFillType(FillType::Solid);
    $miterShape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $bevelShape->getFillFormat()->setFillType(FillType::Solid);
    $bevelShape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $roundShape->getFillFormat()->setFillType(FillType::Solid);
    $roundShape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

    $miterShape->getLineFormat()->setWidth(15);
    $bevelShape->getLineFormat()->setWidth(15);
    $roundShape->getLineFormat()->setWidth(15);

    $miterShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $miterShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $bevelShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $bevelShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $roundShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $roundShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    $miterShape->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
    $bevelShape->getLineFormat()->setJoinStyle(LineJoinStyle::Bevel);
    $roundShape->getLineFormat()->setJoinStyle(LineJoinStyle::Round);

    $miterShape->getTextFrame()->setText("Miter Join Style");
    $bevelShape->getTextFrame()->setText("Bevel Join Style");
    $roundShape->getTextFrame()->setText("Round Join Style");

    $presentation->save("join_styles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Batasi Sambungan Miter pada Sudut Tajam**

Gunakan [LineFormat::setMiterLimit](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setMiterLimit) bersama dengan [LineFormat::setJoinStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setJoinStyle) yang diatur ke [LineJoinStyle::Miter](https://reference.aspose.com/slides/php-java/aspose.slides/linejoinstyle/) untuk membatasi sejauh mana sudut tajam dapat meluas.

Limit tersebut adalah rasio antara jarak antara sudut dalam dan luar sambungan terhadap lebar garis. Misalnya, nilai `8` mengizinkan panjang miter hingga delapan kali lebar garis; bukan ukuran dalam poin. Jika sudut melebihi limit, PowerPoint menggunakan sambungan bevel pada sudut tersebut. Limit yang lebih besar memungkinkan poin yang lebih tajam. Pengaturan ini memengaruhi hanya sambungan miter, dan mengubahnya tidak menghasilkan efek visual bila sudut tetap berada dalam kedua limit.

Contoh ini membuat dua segitiga identik tanpa isian dengan kontur lebar 20 poin. Segitiga kiri menggunakan limit `2`, dan kanan menggunakan `8`. Setiap segitiga berukuran 80 poin lebar dan 160 poin tinggi, memberikan sudut atasnya rasio panjang miter terhadap lebar garis sekitar `4.12`. Akibatnya, PowerPoint menambah bevel pada puncak kiri dan mempertahankan puncak kanan.

```php
use aspose\slides\FillType;
use aspose\slides\LineJoinStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(500, 320, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $miterLimits = [2, 8];

    for ($i = 0; $i < count($miterLimits); $i++) {
        $triangle = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 90 + $i * 240, 110, 80, 160);
        $triangle->getFillFormat()->setFillType(FillType::NoFill);
        $triangle->getLineFormat()->setWidth(20);
        $triangle->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
        $lineColor = new Java("java.awt.Color", 0, 0, 139);
        $triangle->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
        $triangle->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
        $triangle->getLineFormat()->setMiterLimit($miterLimits[$i]);
    }

    $presentation->save("miter_limits.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Hasil di PowerPoint: **Miter limit 2** di kiri dan **miter limit 8** di kanan.

![Sisi berbevel dengan miter limit 2 dan sisi runcing dengan miter limit 8 di PowerPoint](miter-limits.png)

## **Isian Gradien**

Isian gradien menggabungkan warna di seluruh bentuk. Contoh ini mengisi sebuah elips dengan gradien linier pada sudut 45 derajat dari merah ke ungu menggunakan [FillFormat::getGradientFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getGradientFormat). Metode [GradientStopCollection::addPresetColor](https://reference.aspose.com/slides/php-java/aspose.slides/gradientstopcollection/#addPresetColor) menempatkan titik warna pada 0 dan 1, yaitu awal dan akhir gradien. Menghapus titik yang ada memastikan hanya dua warna ini yang digunakan.

```php
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\Presentation;
use aspose\slides\PresetColor;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape::Linear);
    $shape->getFillFormat()->getGradientFormat()->setLinearGradientAngle(45);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->clear();
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor::Purple);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0.0, PresetColor::Red);

    $presentation->save("gradient_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Hasil:

![Elips dengan isian gradien](gradient-fill.png)

Jika gradien terlihat berbeda dalam gambar yang diekspor dibandingkan di PowerPoint, lihat [Choose a Gradient Rendering Style](/slides/id/php-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Anda dapat memilih gaya rendering tanpa mengubah isian gradien yang disimpan dalam presentasi.

### **Atur Sudut Gradien Linear**

Gunakan [GradientFormat::setLinearGradientAngle](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setLinearGradientAngle) untuk mengontrol orientasi isian [GradientShape::Linear](https://reference.aspose.com/slides/php-java/aspose.slides/gradientshape/). Sudut diukur dalam derajat dan meningkat searah jarum jam: `0` dari kiri ke kanan, `90` dari atas ke bawah, `180` dari kanan ke kiri, dan `270` dari bawah ke atas. Sudut pecahan didukung. Sudut terbatas di luar `[0, 360)` dinormalisasi menjadi satu putaran; misalnya, `-45` menjadi `315` dan `360` menjadi `0`.

Contoh ini membuat enam persegi panjang dengan titik warna merah, hijau, dan biru yang identik pada posisi `0`, `0.5`, dan `1`. Skala dinonaktifkan sehingga sudut dapat dibandingkan secara independen dari proporsi persegi panjang. Sudut, dari kiri ke kanan, adalah `0`, `45`, dan `90` pada baris pertama, serta `135`, `180`, dan `270` pada baris kedua.

```php
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 400, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $angles = [0, 45, 90, 135, 180, 270];

    for ($i = 0; $i < count($angles); $i++) {
        $x = 30 + ($i % 3) * 230;
        $y = 30 + intdiv($i, 3) * 190;

        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 200, 150);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
        $shape->getFillFormat()->setFillType(FillType::Gradient);

        $gradient = $shape->getFillFormat()->getGradientFormat();
        $gradient->setGradientShape(GradientShape::Linear);
        $gradient->getGradientStops()->clear();
        $gradient->getGradientStops()->add(0, java("java.awt.Color")->RED);
        $gradient->getGradientStops()->add(0.5, java("java.awt.Color")->GREEN);
        $gradient->getGradientStops()->add(1, java("java.awt.Color")->BLUE);
        $gradient->setLinearGradientScaled(NullableBool::False);
        $gradient->setLinearGradientAngle($angles[$i]);
    }

    $presentation->save("linear_gradient_angles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Hasil di PowerPoint:

![Gradien linear pada 0, 45, dan 90 derajat pada baris atas, serta 135, 180, dan 270 derajat pada baris bawah](linear-gradient-angles.png)

### **Skalakan Gradien Linear dengan Bentuk**

[GradientFormat::setLinearGradientScaled](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setLinearGradientScaled) menerima nilai [NullableBool](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/). Atur secara eksplisit ke `False` untuk mempertahankan sudut gradien geometris saat proporsi bentuk berubah, atau ke `True` untuk menskalakan gradien dengan lebar dan tinggi bentuk. Dengan skala diaktifkan, sudut yang terlihat dapat berbeda dari sudut yang ditetapkan pada bentuk yang bukan persegi.

Contoh berikut menggunakan sudut `45` derajat dan titik warna yang sama seperti perbandingan sudut. Kolom kiri menggunakan `False`; kolom kanan menggunakan `True`. Setiap kolom berisi persegi panjang lebar di atas persegi panjang tinggi. Kedua kolom dimulai dengan dimensi lebar yang sama; mengubah lebar dan tinggi persegi panjang kedua menunjukkan bagaimana isian merespons perubahan ukuran tanpa mengubah pengaturan gradiennya.

```php
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 460, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $scalingOptions = [NullableBool::False, NullableBool::True];

    for ($column = 0; $column < count($scalingOptions); $column++) {
        for ($row = 0; $row < 2; $row++) {
            $x = 30 + $column * 360;
            $y = $row == 0 ? 30 : 150;

            $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 300, 90);
            $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
            $shape->getFillFormat()->setFillType(FillType::Gradient);

            $gradient = $shape->getFillFormat()->getGradientFormat();
            $gradient->setGradientShape(GradientShape::Linear);
            $gradient->getGradientStops()->clear();
            $gradient->getGradientStops()->add(0, java("java.awt.Color")->RED);
            $gradient->getGradientStops()->add(0.5, java("java.awt.Color")->GREEN);
            $gradient->getGradientStops()->add(1, java("java.awt.Color")->BLUE);
            $gradient->setLinearGradientAngle(45);
            $gradient->setLinearGradientScaled($scalingOptions[$column]);

            if ($row == 1) {
                $shape->setWidth(90);
                $shape->setHeight(280);
            }
        }
    }

    $presentation->save("linear_gradient_scaling.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Hasil di PowerPoint, dengan skala dinonaktifkan di kiri dan diaktifkan di kanan:

![Persegi panjang lebar dan tinggi dengan gradien 45 derajat, membandingkan LinearGradientScaled False di kiri dengan True di kanan](linear-gradient-scaling.png)

Dengan skala dinonaktifkan, pita warna diagonal menjaga orientasi yang sama di kedua persegi panjang. Dengan skala diaktifkan, pita-pita tersebut meregang sesuai proporsi bentuk. Ini membantu mereproduksi gradien templat saat menyesuaikan bentuk ke ukuran yang berbeda. Pada persegi, mengaktifkan skala tidak mengubah tampilan gradien `45` derajat ini.

Baik pengaturan sudut maupun skala berlaku untuk gradien linier. Mereka tidak mengontrol isian [GradientShape::Radial or GradientShape::Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/gradientshape/).

### **Gabungkan Sudut dengan Arah Gradien**

[GradientFormat::setGradientDirection](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setGradientDirection) memilih gaya gradien dari kelas [GradientDirection](https://reference.aspose.com/slides/php-java/aspose.slides/gradientdirection/). Ini bukan pengganti sudut numerik. Untuk gradien linier, gaya sudut dapat mengubah area distribusi warna tanpa mengubah sudut yang ditetapkan melalui [setLinearGradientAngle](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setLinearGradientAngle). Pertahankan arah tetap saat membandingkan sudut atau skala.

Contoh berikut menerapkan pengaturan yang sama dengan urutan yang berlawanan. Kedua persegi panjang memiliki tampilan yang sama: menetapkan arah sebelum atau sesudah sudut tidak mengubah hasil.

```php
use aspose\slides\FillType;
use aspose\slides\GradientDirection;
use aspose\slides\GradientShape;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    for ($i = 0; $i < 2; $i++) {
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30 + $i * 140, 320, 100);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
        $shape->getFillFormat()->setFillType(FillType::Gradient);

        $gradient = $shape->getFillFormat()->getGradientFormat();
        $gradient->setGradientShape(GradientShape::Linear);
        $gradient->getGradientStops()->clear();
        $gradient->getGradientStops()->add(0, java("java.awt.Color")->RED);
        $gradient->getGradientStops()->add(0.5, java("java.awt.Color")->GREEN);
        $gradient->getGradientStops()->add(1, java("java.awt.Color")->BLUE);
        $gradient->setLinearGradientScaled(NullableBool::True);

        if ($i == 0) {
            $gradient->setGradientDirection(GradientDirection::FromCorner1);
            $gradient->setLinearGradientAngle(30);
        } else {
            $gradient->setLinearGradientAngle(30);
            $gradient->setGradientDirection(GradientDirection::FromCorner1);
        }
    }

    $presentation->save("linear_gradient_direction.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Isian Pola**

Isian pola menerapkan desain dua warna, seperti titik, garis, atau kotak‑kotak. Contoh ini menggunakan [PatternFormat::setPatternStyle](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#setPatternStyle) untuk memilih pola trellis. [PatternFormat::getBackColor](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getBackColor) menyediakan latar belakang abu‑abu terang, dan [PatternFormat::getForeColor](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getForeColor) menyediakan warna pola kuning.

```php
use aspose\slides\FillType;
use aspose\slides\PatternStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::Pattern);
    $shape->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::Trellis);
    $shape->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shape->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);

    $presentation->save("pattern_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Hasil:

![Persegi panjang dengan isian pola](pattern-fill.png)

## **Isian Gambar**

Isian gambar menggunakan gambar di dalam bentuk. Contoh ini memerlukan gambar lokal dan menggunakan [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile) untuk memuatnya ke dalam koleksi gambar presentasi. Mengatur [PictureFillFormat::setPictureFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setPictureFillMode) ke mode ubin mengulang gambar di dalam persegi panjang. Gambar sumber yang digunakan ditampilkan di bawah:

![Gambar lotus](lotus.png)

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);
    $shape->getFillFormat()->setFillType(FillType::Picture);
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

    $image = Images::fromFile("lotus.png");
    try {
        $picture = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);

    $presentation->save("picture_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Hasil:

![Bentuk dengan isian gambar](picture-fill.png)

### **Ubin Gambar Sebagai Tekstur**

Jika Anda ingin mengatur gambar ubin sebagai tekstur dan menyesuaikan perilaku ubin, Anda dapat menggunakan metode berikut dari kelas [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setPictureFillMode): Menetapkan mode isian gambar—baik `Tile` atau `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileAlignment): Menentukan perataan ubin dalam bentuk.
- [setTileFlip](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileFlip): Mengontrol apakah ubin diputar secara horizontal, vertikal, atau keduanya.
- [setTileOffsetX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetX): Menetapkan offset horizontal ubin (dalam poin) dari asal bentuk.
- [setTileOffsetY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetY): Menetapkan offset vertikal ubin (dalam poin) dari asal bentuk.
- [setTileScaleX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleX): Mendefinisikan skala horizontal ubin sebagai persentase.
- [setTileScaleY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleY): Mendefinisikan skala vertikal ubin sebagai persentase.

Contoh ini memerlukan gambar lokal dan mengonfigurasi [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) untuk mengulangnya pada 50% ukuran aslinya. Offset −32 poin menggeser ubin secara horizontal dan vertikal; perataan kanan‑bawah dan pemutaran di kedua arah menentukan bagaimana tekstur berulang diatur.

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\RectangleAlignment;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TileFlip;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);

    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);
    $shape->getFillFormat()->setFillType(FillType::Picture);

    $sourceImage = Images::fromFile("lotus.png");
    try {
        $presentationImage = $presentation->getImages()->addImage($sourceImage);
    } finally {
        $sourceImage->dispose();
    }

    $pictureFillFormat = $shape->getFillFormat()->getPictureFillFormat();
    $pictureFillFormat->getPicture()->setImage($presentationImage);
    $pictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $pictureFillFormat->setTileOffsetX(-32);
    $pictureFillFormat->setTileOffsetY(-32);
    $pictureFillFormat->setTileScaleX(50);
    $pictureFillFormat->setTileScaleY(50);
    $pictureFillFormat->setTileAlignment(RectangleAlignment::BottomRight);
    $pictureFillFormat->setTileFlip(TileFlip::FlipBoth);

    $presentation->save("tile.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Hasil:

![Opsi ubin](tile-options.png)

## **Isian Warna Solid**

Isian solid memberikan bentuk satu warna seragam. Contoh ini mengatur [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType) ke mode isian solid dan menetapkan warna kuning melalui [FillFormat::getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor), kemudian menyimpan persegi panjang dalam sebuah presentasi.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

    $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Hasil:

![Bentuk dengan isian warna solid](solid-color-fill.png)

### **Salin Warna Sambil Mempertahankan Referensi Tema**

Gunakan [ColorFormat::copyFrom](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#copyFrom) untuk menyalin definisi warna, termasuk tipe warna, referensi tema, dan transformasi. Ini berguna saat memindahkan warna isian antar bentuk yang harus tetap mengikuti tema presentasi. Metode ini hanya menyalin warna: tidak menyalin tipe isian, kontur, atau pemformatan bentuk lainnya. Tetapkan tipe isian tujuan secara eksplisit dengan [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType).

Contoh ini membuat tiga persegi panjang, dari kiri ke kanan: sumber, salinan yang sadar tema, dan salinan RGB tetap. Sumber menggunakan [ColorFormat::setSchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#setSchemeColor) untuk merujuk pada warna aksen pertama dan menambahkan tint melalui [ColorOperationCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/coloroperationcollection/#add). Salinan RGB menggunakan warna isian efektif sumber sehingga ketiganya pada awalnya terlihat identik. Memanggil [ColorFormat::setColor](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#setColor) menetapkan nilai RGB tetap dan menghapus semua transformasi warna yang ada.

```php
use aspose\slides\ColorTransformOperation;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SchemeColor;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(660, 220, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $initialAccent = new Java("java.awt.Color", 65, 105, 225);
    $presentation->getMasterTheme()->getColorScheme()->getAccent1()->setColor($initialAccent);

    $source = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 40, 180, 140);
    $themeCopy = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 240, 40, 180, 140);
    $rgbCopy = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 450, 40, 180, 140);

    foreach ([$source, $themeCopy, $rgbCopy] as $shape) {
        $shape->getFillFormat()->setFillType(FillType::Solid);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    }

    $sourceColor = $source->getFillFormat()->getSolidFillColor();
    $sourceColor->setSchemeColor(SchemeColor::Accent1);
    $sourceColor->getColorTransform()->add(ColorTransformOperation::Tint, 0.75);

    $themeCopy->getFillFormat()->getSolidFillColor()->copyFrom($sourceColor);
    $rgbCopy->getFillFormat()->getSolidFillColor()->setColor($source->getFillFormat()->getEffective()->getSolidFillColor());

    $before = $slide->getImage(1.0, 1.0);
    try {
        $before->save("color-copy-before.png", ImageFormat::Png);
    } finally {
        $before->dispose();
    }

    // Referensi tema mengikuti warna aksen baru; nilai RGB tetap tidak berubah.
    $updatedAccent = new Java("java.awt.Color", 255, 69, 0);
    $presentation->getMasterTheme()->getColorScheme()->getAccent1()->setColor($updatedAccent);

    $after = $slide->getImage(1.0, 1.0);
    try {
        $after->save("color-copy-after.png", ImageFormat::Png);
    } finally {
        $after->dispose();
    }
    $presentation->save("copied_colors.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sebelum perubahan tema, ketiga isian cocok:

![Sumber, tujuan copyFrom, dan tujuan RGB tetap dengan isian biru identik](color-copy-before.png)

Setelah perubahan tema, sumber dan salinan yang sadar tema mengikuti warna aksen baru dan mempertahankan tint mereka. Salinan RGB tetap tetap biru:

![Sumber dan tujuan copyFrom dengan isian oranye, sementara tujuan RGB tetap tetap biru](color-copy-after.png)

Definisi yang disalin independen dari sumber. Mengubah referensi tema sumber, menetapkan warna lain, atau menambah atau menghapus transformasi mereka selanjutnya tidak mengubah tujuan. Perubahan tema tetap memengaruhi kedua bentuk karena masing‑masing merujuk secara independen ke warna tema yang sama.

Menyimpan dan membuka kembali file PPTX mempertahankan tipe warna yang disalin yang dikembalikan oleh [ColorFormat::getColorType](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#getColorType), referensi tema, dan koleksi transformasi yang dikembalikan oleh [ColorFormat::getColorTransform](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#getColorTransform); tidak mengubah definisi menjadi RGB.

Saat menyalin antar konteks tema yang berbeda, misalnya presentasi dengan palet aksen yang berbeda, referensi yang disalin diselesaikan terhadap tema tujuan. Referensi dan transformasi yang sama dapat menghasilkan warna tampak yang berbeda. Lihat [Presentation Theme](/slides/id/php-java/presentation-theme/) untuk informasi lebih lanjut tentang mengonfigurasi warna tema.

## **Gunakan Latar Belakang Slide sebagai Isian Bentuk**

Gunakan [AutoShape::setUseBackgroundFill](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#setUseBackgroundFill) ketika sebuah bentuk harus cocok dengan latar belakang slide, misalnya dalam templat presentasi. Tetapkan tipe isian dengan [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType) ke [FillType::NotDefined](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) terlebih dahulu untuk menghapus isian eksplisit apa pun. Dengan kombinasi ini, bentuk menggunakan latar belakang slide alih‑alih isian gaya‑nya. Mengaktifkan flag saja tidak menghapus isian eksplisit yang ada.

Ini berbeda dari [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/): isian latar belakang menutupi objek di belakang bentuk dengan area latar belakang slide yang bersesuaian, sementara tanpa isian membuat objek tersebut tetap terlihat. Gradien tetap selaras dengan slide bukan memulai kembali di dalam setiap bentuk.

Contoh berikut membuat latar belakang master yang diwarisi oleh slide dan menempatkan pita magenta di belakang tiga persegi panjang. Persegi panjang kiri menggunakan latar belakang, persegi panjang tengah tidak memiliki isian, dan persegi panjang kanan beralih dari isian latar belakang ke isian oranye eksplisit.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 400, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    // Warisi gradien dari master.
    $slide->getBackground()->setType(BackgroundType::NotDefined);
    $slide->getLayoutSlide()->getBackground()->setType(BackgroundType::NotDefined);
    $background = $slide->getLayoutSlide()->getMasterSlide()->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $background->getFillFormat()->setFillType(FillType::Gradient);
    $gradient = $background->getFillFormat()->getGradientFormat();
    $gradient->setGradientShape(GradientShape::Linear);
    $gradient->setLinearGradientAngle(0);
    $gradient->getGradientStops()->clear();
    $startColor = new Java("java.awt.Color", 0, 0, 139);
    $gradient->getGradientStops()->add(0, $startColor);
    $endColor = new Java("java.awt.Color", 135, 206, 250);
    $gradient->getGradientStops()->add(1, $endColor);

    // Tambahkan objek ini terlebih dahulu sehingga muncul di belakang persegi panjang.
    $band = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 25, 150, 670, 100);
    $band->getFillFormat()->setFillType(FillType::Solid);
    $band->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->MAGENTA);
    $band->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $backgroundShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 100, 160, 200);
    $backgroundShape->getFillFormat()->setFillType(FillType::NotDefined);
    $backgroundShape->setUseBackgroundFill(true);

    $noFillShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 280, 100, 160, 200);
    $noFillShape->getFillFormat()->setFillType(FillType::NoFill);

    $explicitShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 510, 100, 160, 200);
    $explicitShape->getFillFormat()->setFillType(FillType::NotDefined);
    $explicitShape->setUseBackgroundFill(true);

    // Nonaktifkan isian latar belakang sebelum menerapkan isian eksplisit.
    $explicitShape->setUseBackgroundFill(false);
    $explicitShape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 165, 0);
    $explicitShape->getFillFormat()->getSolidFillColor()->setColor($fillColor);

    $presentation->save("background_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Hasil, dari kiri ke kanan: **isian latar belakang**, **tanpa isian**, dan **isian eksplisit**. Pita magenta tersembunyi oleh persegi panjang kiri dan kanan tetapi tetap terlihat melalui persegi panjang tengah.

![Isian latar belakang, tanpa isian, dan isian oranye eksplisit di atas pita magenta](background-fill.png)

Perilaku yang sama berlaku pada latar belakang yang didefinisikan langsung pada slide atau diwarisi dari tata letak. Bentuk menggunakan latar belakang slide yang telah diselesaikan; contoh ini membiarkan latar belakang slide dan tata letak tidak ditentukan sehingga master menyediakannya.

## **Atur Transparansi**

Untuk isian solid, komponen alfa warna mengontrol opasitas: 0 sepenuhnya transparan dan 255 sepenuhnya tidak tembus. Contoh ini menggunakan nilai alfa 128 untuk persegi panjang kuning, menjadikannya kira‑kira 50% transparan sehingga persegi panjang di bawahnya tetap terlihat. Warna ditetapkan melalui [FillFormat::getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor).

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    $transparentShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
    $transparentShape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 255, 0, 128);
    $transparentShape->getFillFormat()->getSolidFillColor()->setColor($fillColor);

    $presentation->save("shape_transparency.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Hasil:

![Bentuk transparan](shape-transparency.png)

## **Putar Bentuk**

Gunakan [Shape::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) untuk memutar sebuah bentuk dalam bidang slide. Sudut diukur dalam derajat; contoh ini memutar persegi panjang 5 derajat searah jarum jam dan menyimpan presentasi.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 0? 5? 150, 75);
    $shape->setRotation(5);

    $presentation->save("shape_rotation.ppt5? 0? 1? 0? 0? 0…");
} finally {
    $presentation->dispose();
}
```

Hasil:

![Putaran bentuk](shape-rotation.png)

## **Tambahkan Efek Bevel 3D**

Gunakan [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat) untuk memberi bentuk kedalaman dan tepi bevel. Contoh ini membuat elips hijau dengan kontur oranye, mengatur [ThreeDFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setDepth) menjadi 4 poin, dan menerapkan bevel atas melingkar dengan lebar dan tinggi 6 poin melalui [ThreeDFormat::getBevelTop](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getBevelTop). Kamera ortografik menghadap depan dan pencahayaan tiga titik membuat bevel terlihat.

```php
use aspose\slides\BevelPresetType;
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\LightRigPresetType;
use aspose\slides\LightingDirection;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 0, 128, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $lineColor = new Java("java.awt.Color", 255, 165, 0);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
    $shape->getLineFormat()->setWidth(2.0);
    $shape->getThreeDFormat()->setDepth(4);
    $shape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $shape->getThreeDFormat()->getBevelTop()->setHeight(6);
    $shape->getThreeDFormat()->getBevelTop()->setWidth(6);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::ThreePt);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);

    $presentation->save("3D_bevel_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Hasil:

![Efek bevel 3D](3D-bevel-effect.png)

## **Tambahkan Efek Rotasi 3D**

Tampilan 3D sebuah bentuk dikontrol oleh pengaturan kameranya. Contoh ini menggunakan [Camera::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setRotation) dengan sudut lintang, bujur, dan revolusi masing‑masing 40, 35, dan 20 derajat. Ia memilih kamera isometrik melalui [Camera::setCameraType](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setCameraType) dan pencahayaan seimbang melalui [LightRig::setLightType](https://reference.aspose.com/slides/php-java/aspose.slides/lightrig/#setLightType), kemudian menyimpan persegi panjang yang diformat.

```php
use aspose\slides\CameraPresetType;
use aspose\slides\LightRigPresetType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $autoShape->getTextFrame()->setText("Hello, Aspose!");
    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::IsometricLeftUp);
    $autoShape->getThreeDFormat()->getCamera()->setRotation(40, 35, 20);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);

    $presentation->save("3D_rotation_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Hasil:

![Efek rotasi 3D](3D-rotation-effect.png)

## **Kontrol Rendering Hitam‑Putih untuk Bentuk**

Metode [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setBlackWhiteMode) menentukan bagaimana sebuah bentuk individual dirender ketika presentasi dilihat atau diproses dalam mode hitam‑putih. Metode ini tidak mengaktifkan tampilan hitam‑putih secara otomatis, dan tidak mengubah isian, garis, atau pemformatan lain bentuk dalam mode warna normal.

Gunakan nilai dari kelas [BlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/blackwhitemode/) untuk memilih perilaku yang diinginkan. Misalnya, `Automatic` membiarkan aplikasi rendering memilih konversi, `Gray` dan `LightGray` menggunakan pewarnaan abu‑abu, `BlackWhite` hanya menggunakan hitam dan putih, `Black` dan `White` memaksa satu warna, `Color` mempertahankan pewarnaan normal, dan `Hidden` menghilangkan bentuk dalam mode hitam‑putih. `NotDefined` berarti tidak ada mode tingkat‑bentuk yang ditetapkan.

Contoh ini membuat persegi panjang oranye dan mengatur [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setBlackWhiteMode) ke abu‑abu. Bentuk yang disimpan mempertahankan isian oranye untuk tampilan warna normal dan meminta pewarnaan abu‑abu dari aplikasi yang menghormati pengaturan tampilan hitam‑putih:

```php
use aspose\slides\BlackWhiteMode;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 165, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->setBlackWhiteMode(BlackWhiteMode::Gray);

    $presentation->save("shape_black_white_mode.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Dalam mode warna normal, persegi panjang mempertahankan isian oranye. Dalam alur kerja tampilan hitam‑putih, ia menggunakan pewarnaan abu‑abu karena mode‑nya diatur ke `Gray`. Ini memungkinkan Anda mempertahankan slide berwarna penuh sambil mendefinisikan tampilan berbeda untuk pencetakan, pratinjau, atau alur kerja lain yang menghormati pengaturan tampilan hitam‑putih presentasi.

## **Atur Ulang Pemformatan**

Gunakan [Slide::reset](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#reset) untuk mengembalikan posisi, ukuran, dan pemformatan placeholder slide dari placeholder tata letak yang bersesuaian. Contoh ini memerlukan presentasi yang sudah ada dengan placeholder yang terhubung ke tata letak dan mengatur ulang setiap slide sebelum menyimpan. Bentuk tanpa placeholder tata letak yang bersesuaian tidak direset.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        $slide->reset();
    }

    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Apakah pemformatan bentuk memengaruhi ukuran file akhir presentasi?**

Warna, gaya garis, dan pengaturan efek umumnya menambah sedikit data dibandingkan dengan gambar dan media yang disematkan. Isian gambar dapat meningkatkan ukuran file karena gambar mereka disimpan dalam presentasi.

**Bagaimana saya dapat mendeteksi bentuk pada slide yang memiliki pemformatan identik sehingga saya dapat mengelompokkannya?**

Bandingkan properti pemformatan kunci setiap bentuk—pengaturan isian, garis, dan efek. Jika semua nilai yang bersesuaian cocok, anggap gaya mereka identik dan kelompokkan bentuk‑bentuk tersebut secara logis, yang menyederhanakan pengelolaan gaya selanjutnya.

**Apakah saya dapat menyimpan sekumpulan gaya bentuk khusus ke file terpisah untuk digunakan kembali di presentasi lain?**

Ya. Simpan contoh bentuk dengan gaya yang diinginkan dalam dek slide templat atau file templat .POTX. Saat membuat presentasi baru, buka templat, kloning bentuk bergaya yang Anda perlukan, dan terapkan kembali pemformatannya di mana pun diperlukan.