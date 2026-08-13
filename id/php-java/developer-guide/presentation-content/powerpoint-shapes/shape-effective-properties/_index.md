---
title: Dapatkan Properti Efektif Shape dari Presentasi di PHP
linktitle: Properti Efektif
type: docs
weight: 50
url: /id/php-java/shape-effective-properties/
keywords:
- properti shape
- properti kamera
- rig cahaya
- bentuk bevel
- bingkai teks
- gaya teks
- tinggi font
- format isian
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Pelajari cara menggunakan Aspose.Slides untuk PHP via Java untuk membedakan pemformatan shape lokal, warisan, dan efektif dalam presentasi PowerPoint."
---
## **Pahami Properti Lokal, Warisan, dan Efektif**

Pemformatan PowerPoint dapat berasal dari beberapa tempat. Nilai yang disimpan langsung pada sebuah objek adalah **nilai lokal**. Jika nilai itu tidak ditetapkan, PowerPoint melihat sumber pemformatan induk, seperti default paragraf, gaya teks, tata letak atau slide master, tema, atau default tingkat presentasi. Nilai-nilai tersebut adalah **nilai yang diwariskan**. Nilai yang tersisa setelah seluruh hierarki diselesaikan adalah **nilai efektif**—nilai yang digunakan untuk merender objek.

Sebagai contoh, sebuah potongan teks mungkin tidak menentukan tinggi fontnya sendiri. Nilai lokal [getFontHeight](https://reference.aspose.com/slides/id/php-java/aspose.slides/baseportionformat/) maka menjadi `NAN`, yang berarti "tidak ditetapkan di sini." Potongan tersebut dapat mewarisi tinggi dari paragrafnya, gaya teks default presentasi, atau sumber lain yang berlaku. Memanggil [getEffective](https://reference.aspose.com/slides/id/php-java/aspose.slides/portionformat/geteffective/) pada format potongan mengembalikan tinggi yang telah diselesaikan secara akhir.

Gunakan dua jenis data pemformatan untuk tujuan yang berbeda:

- Baca atau ubah objek format lokal, seperti [PortionFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/portionformat/), ketika Anda perlu mengontrol di mana nilai didefinisikan.
- Baca objek data efektif, seperti [data yang dikembalikan oleh PortionFormat.getEffective](https://reference.aspose.com/slides/id/php-java/aspose.slides/portionformat/geteffective/), ketika Anda memerlukan hasil akhir yang dirender. Data efektif bersifat hanya baca.

Sebelum menjalankan contoh, [pasang Aspose.Slides untuk PHP via Java](/slides/id/php-java/installation/).

## **Bandingkan Nilai Lokal, Warisan, dan Efektif**

Contoh lengkap berikut membuat sebuah shape dan menerapkan tinggi font pada level presentasi, paragraf, dan potongan. Setiap langkah mencetak nilai yang didefinisikan pada level tersebut dan nilai efektif yang dihasilkan untuk potongan teks yang sama. Ini juga menunjukkan mengapa data efektif harus dibaca kembali setelah perubahan pemformatan.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

function formatLocalValue($value)
{
    return $value === null || is_nan($value) ? "<not set>" : (string)$value;
}

function printFontHeights($caption, $presentation, $paragraph, $portion)
{
    $presentationValue = java_values($presentation->getDefaultTextStyle()->getLevel(0)->getDefaultPortionFormat()->getFontHeight());
    $paragraphValue = java_values($paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFontHeight());
    $localValue = java_values($portion->getPortionFormat()->getFontHeight());

    // Baca data efektif setelah perubahan sebelumnya.
    $effectiveValue = java_values($portion->getPortionFormat()->getEffective()->getFontHeight());

    echo $caption . PHP_EOL;
    echo "  Presentation default: " . formatLocalValue($presentationValue) . PHP_EOL;
    echo "  Paragraph default:    " . formatLocalValue($paragraphValue) . PHP_EOL;
    echo "  Portion local:        " . formatLocalValue($localValue) . PHP_EOL;
    echo "  Portion effective:    " . $effectiveValue . PHP_EOL;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 500, 80, false);
    $textFrame = $shape->addTextFrame("Effective formatting");
    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $portion = $paragraph->getPortions()->get_Item(0);

    // Tentukan nilai yang diwariskan pada dua level berbeda.
    $presentation->getDefaultTextStyle()->getLevel(0)->getDefaultPortionFormat()->setFontHeight(20);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(28);

    printFontHeights("The portion inherits from the paragraph", $presentation, $paragraph, $portion);

    // Nilai lokal pada potongan menimpa kedua nilai yang diwariskan.
    $portion->getPortionFormat()->setFontHeight(36);
    printFontHeights("A local value overrides inherited values", $presentation, $paragraph, $portion);

    // Mengubah nilai yang diwariskan tidak menimpa nilai lokal yang sudah ada.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(30);
    printFontHeights("The local value still has priority", $presentation, $paragraph, $portion);

    // Bersihkan nilai lokal. Potongan kini mewarisi lagi dari paragraf.
    $portion->getPortionFormat()->setFontHeight(NAN);
    printFontHeights("The local value is cleared", $presentation, $paragraph, $portion);

    // Bersihkan nilai paragraf. Default presentasi kini menyediakan hasilnya.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(NAN);
    printFontHeights("The paragraph value is cleared", $presentation, $paragraph, $portion);

    $presentation->save("effective-properties.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Prioritas dalam contoh ini adalah pemformatan lokal potongan, kemudian pemformatan paragraf, kemudian default presentasi. Objek lain dapat memiliki rantai pewarisan yang berbeda, tetapi prinsipnya sama: nilai eksplisit yang lebih spesifik menang, dan [getEffective](https://reference.aspose.com/slides/id/php-java/aspose.slides/portionformat/geteffective/) mengembalikan hasil akhir.

## **Dapatkan Properti Teks Efektif**

Text formatting is split across several objects:

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframeformat/geteffective/) menyelesaikan properti bingkai teks seperti margin, penambatan, autofit, dan arah teks vertikal.
- [TextStyle.getEffective](https://reference.aspose.com/slides/id/php-java/aspose.slides/textstyle/geteffective/) menyelesaikan pemformatan paragraf untuk setiap tingkat gaya teks.
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraphformat/geteffective/) menyelesaikan properti paragraf seperti perataan, indentasi, dan bullet.
- [PortionFormat.getEffective](https://reference.aspose.com/slides/id/php-java/aspose.slides/portionformat/geteffective/) menyelesaikan properti karakter seperti tinggi font, jenis huruf, warna, tebal, dan miring.

Untuk contoh berikut, `text-formatting.pptx` harus berisi setidaknya satu slide dan satu [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/) dengan bingkai teks yang tidak kosong. AutoShape dapat muncul di posisi mana saja dalam koleksi shape; kode mencari objek yang cocok dan memvalidasinya sebelum digunakan.

```php
use aspose\slides\Presentation;

function formatEffectiveValue($javaValue)
{
    $value = java_values($javaValue);
    if ($value === null) {
        return "<not set>";
    }
    if (is_bool($value)) {
        return $value ? "true" : "false";
    }
    return (string)$value;
}

function hasNonEmptyText($shape)
{
    $textFrame = $shape->getTextFrame();
    if (java_is_null($textFrame)) {
        return false;
    }
    if (java_values($textFrame->getParagraphs()->getCount()) === 0) {
        return false;
    }
    return java_values($textFrame->getParagraphs()->get_Item(0)->getPortions()->getCount()) > 0;
}

function findAutoShapeWithText($slide)
{
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $candidate = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($candidate, $autoShapeClass) && hasNonEmptyText($candidate)) {
            return $candidate;
        }
    }
    return null;
}

$presentation = new Presentation("text-formatting.pptx");
try {
    if (java_values($presentation->getSlides()->size()) === 0) {
        throw new RuntimeException("The presentation contains no slides.");
    }

    $shape = findAutoShapeWithText($presentation->getSlides()->get_Item(0));
    if ($shape === null) {
        throw new RuntimeException("The first slide must contain an AutoShape with non-empty text.");
    }

    $textFrame = $shape->getTextFrame();
    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $portion = $paragraph->getPortions()->get_Item(0);

    $textFrameEffective = $textFrame->getTextFrameFormat()->getEffective();
    $paragraphEffective = $paragraph->getParagraphFormat()->getEffective();
    $portionEffective = $portion->getPortionFormat()->getEffective();

    echo "Text frame margins:" . PHP_EOL;
    echo "  Left: " . formatEffectiveValue($textFrameEffective->getMarginLeft()) . PHP_EOL;
    echo "  Top: " . formatEffectiveValue($textFrameEffective->getMarginTop()) . PHP_EOL;
    echo "  Right: " . formatEffectiveValue($textFrameEffective->getMarginRight()) . PHP_EOL;
    echo "  Bottom: " . formatEffectiveValue($textFrameEffective->getMarginBottom()) . PHP_EOL;
    echo "Paragraph alignment: " . formatEffectiveValue($paragraphEffective->getAlignment()) . PHP_EOL;
    echo "Font height: " . formatEffectiveValue($portionEffective->getFontHeight()) . PHP_EOL;
    echo "Bold: " . formatEffectiveValue($portionEffective->getFontBold()) . PHP_EOL;

    $effectiveTextStyle = $textFrame->getTextFrameFormat()->getTextStyle()->getEffective();
    for ($level = 0; $level < 9; $level++) {
        $levelEffective = $effectiveTextStyle->getLevel($level);
        echo "Level " . $level . " indent: " . formatEffectiveValue($levelEffective->getIndent()) . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Dapatkan Properti 3D Efektif**

[ThreeDFormat.getEffective](https://reference.aspose.com/slides/id/php-java/aspose.slides/threedformat/geteffective/) mengembalikan satu objek data efektif yang mengelompokkan semua pengaturan 3D yang telah diselesaikan. Metode [getCamera](https://reference.aspose.com/slides/id/php-java/aspose.slides/threedformat/geteffective/), [getLightRig](https://reference.aspose.com/slides/id/php-java/aspose.slides/threedformat/geteffective/), [getBevelTop](https://reference.aspose.com/slides/id/php-java/aspose.slides/threedformat/geteffective/), dan [getBevelBottom](https://reference.aspose.com/slides/id/php-java/aspose.slides/threedformat/geteffective/) menampilkan data efektif yang bersesuaian. Membaca pengaturan terkait ini secara bersamaan memudahkan memahami penampilan 3D akhir sebuah shape.

Untuk contoh ini, `shape-3d.pptx` harus berisi setidaknya satu shape pada slide pertama. Terapkan pengaturan kamera 3D, pencahayaan, atau bevel pada shape tersebut jika Anda menginginkan output berisi nilai selain default.

```php
use aspose\slides\Presentation;

function formatEffectiveValue($javaValue)
{
    $value = java_values($javaValue);
    return $value === null ? "<not set>" : (string)$value;
}

$presentation = new Presentation("shape-3d.pptx");
try {
    if (java_values($presentation->getSlides()->size()) === 0 || java_values($presentation->getSlides()->get_Item(0)->getShapes()->size()) === 0) {
        throw new RuntimeException("The first slide must contain a shape.");
    }

    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $threeDEffective = $shape->getThreeDFormat()->getEffective();

    echo "Camera:" . PHP_EOL;
    echo "  Type: " . formatEffectiveValue($threeDEffective->getCamera()->getCameraType()) . PHP_EOL;
    echo "  Field of view: " . formatEffectiveValue($threeDEffective->getCamera()->getFieldOfViewAngle()) . PHP_EOL;
    echo "  Zoom: " . formatEffectiveValue($threeDEffective->getCamera()->getZoom()) . PHP_EOL;

    echo "Light rig:" . PHP_EOL;
    echo "  Type: " . formatEffectiveValue($threeDEffective->getLightRig()->getLightType()) . PHP_EOL;
    echo "  Direction: " . formatEffectiveValue($threeDEffective->getLightRig()->getDirection()) . PHP_EOL;

    echo "Top bevel:" . PHP_EOL;
    echo "  Type: " . formatEffectiveValue($threeDEffective->getBevelTop()->getBevelType()) . PHP_EOL;
    echo "  Width: " . formatEffectiveValue($threeDEffective->getBevelTop()->getWidth()) . PHP_EOL;
    echo "  Height: " . formatEffectiveValue($threeDEffective->getBevelTop()->getHeight()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Dapatkan Pemformatan Tabel Efektif**

Pemformatan tabel dapat berasal dari gaya tabel dan dari format yang diterapkan pada seluruh tabel, kolom, baris, atau sel individu. Untuk konflik antar isian yang didefinisikan secara eksplisit, prioritasnya adalah sel, baris, kolom, dan kemudian seluruh tabel. Format efektif sebuah sel adalah format akhir yang digunakan untuk menggambar sel tersebut.

Untuk contoh ini, `table-formatting.pptx` harus berisi setidaknya satu tabel pada slide pertama. Tabel tersebut harus memiliki setidaknya satu baris dan satu kolom. Kode mencari sebuah [Table](https://reference.aspose.com/slides/id/php-java/aspose.slides/table/) alih-alih mengasumsikan bahwa `getShapes()->get_Item(0)` adalah sebuah tabel.

```php
use aspose\slides\Presentation;

function findTable($slide)
{
    $tableClass = new JavaClass("com.aspose.slides.Table");
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, $tableClass)) {
            return $shape;
        }
    }
    return null;
}

$presentation = new Presentation("table-formatting.pptx");
try {
    if (java_values($presentation->getSlides()->size()) === 0) {
        throw new RuntimeException("The presentation contains no slides.");
    }

    $table = findTable($presentation->getSlides()->get_Item(0));
    if ($table === null) {
        throw new RuntimeException("The first slide must contain a table.");
    }
    if (java_values($table->getRows()->size()) === 0 || java_values($table->getColumns()->size()) === 0) {
        throw new RuntimeException("The table must contain at least one cell.");
    }

    $tableEffective = $table->getTableFormat()->getEffective();
    $rowEffective = $table->getRows()->get_Item(0)->getRowFormat()->getEffective();
    $columnEffective = $table->getColumns()->get_Item(0)->getColumnFormat()->getEffective();
    $cellEffective = $table->get_Item(0, 0)->getCellFormat()->getEffective();

    echo "Table fill: " . java_values($tableEffective->getFillFormat()->getFillType()) . PHP_EOL;
    echo "Row fill: " . java_values($rowEffective->getFillFormat()->getFillType()) . PHP_EOL;
    echo "Column fill: " . java_values($columnEffective->getFillFormat()->getFillType()) . PHP_EOL;
    echo "Final cell fill: " . java_values($cellEffective->getFillFormat()->getFillType()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Jika Anda membutuhkan warna bukan hanya jenis isian, pertama periksa nilai efektif [getFillType](https://reference.aspose.com/slides/id/php-java/aspose.slides/fillformat/geteffective/), kemudian baca metode yang berlaku untuk tipe itu—misalnya, [getSolidFillColor](https://reference.aspose.com/slides/id/php-java/aspose.slides/fillformat/geteffective/) untuk isian padat.

## **Baca Ulang Data Efektif Setelah Perubahan**

Data efektif menggambarkan hierarki pemformatan pada saat diselesaikan. Panggil `getEffective` lagi setelah mengubah apa pun yang dapat berpartisipasi dalam hierarki tersebut, termasuk:

- pemformatan lokal objek;
- default paragraf atau bingkai teks;
- gaya tabel, tabel, kolom, baris, atau format sel;
- pemformatan tata letak atau slide master;
- data tema atau default tingkat presentasi;
- tata letak atau master yang ditetapkan pada slide.

Jangan menyimpan objek data efektif sebagai snapshot permanen. Aspose.Slides mungkin menyimpan beberapa data efektif secara internal, dan pemanggilan `getEffective` berikutnya dapat memperbarui data tersebut. Jika Anda perlu membandingkan nilai sebelum dan sesudah perubahan, salin nilai skalar yang diperlukan—seperti tinggi font, warna, perataan, atau lebar bevel—ke variabel Anda sendiri sebelum melakukan perubahan.

Untuk mengubah nilai, perbarui objek format lokal yang sesuai dan kemudian panggil `getEffective` untuk memverifikasi hasilnya. Objek data efektif bersifat hanya baca.

## **FAQ**

**Bagaimana saya dapat mengetahui level mana yang memberikan nilai efektif?**

Data efektif berisi nilai akhir, bukan sumbernya. Periksa objek lokal yang berlaku mulai dari level paling spesifik ke luar. Untuk teks, ini dapat mencakup potongan, paragraf, bingkai teks, tata letak, master, tema, dan default presentasi. Nilai yang tidak terdefinisi seperti `NAN` atau `null` menunjukkan bahwa pencarian berlanjut ke level lain.

**Apa yang terjadi bila tidak ada level yang mendefinisikan properti?**

Aspose.Slides menyelesaikan default PowerPoint atau perpustakaan yang sesuai. Nilai yang diselesaikan tersebut muncul dalam data efektif meskipun tidak ada objek lokal yang secara eksplisit mendefinisikannya.

**Mengapa nilai efektif kadang sama dengan nilai lokal?**

Nilai lokal memenangkan perhitungan pewarisan. Hal ini diharapkan ketika properti secara eksplisit diatur pada objek dan tidak ada aturan yang lebih spesifik yang menggantikannya.

**Kapan saya harus menggunakan data lokal alih-alih data efektif?**

Gunakan data lokal untuk memeriksa atau mengedit level pemformatan tertentu. Gunakan data efektif ketika Anda membutuhkan tampilan akhir setelah pewarisan, aturan tema, dan gaya yang berlaku diselesaikan. [contoh perbandingan lengkap](#compare-local-inherited-and-effective-values) menunjukkan keduanya dalam alur kerja yang sama.