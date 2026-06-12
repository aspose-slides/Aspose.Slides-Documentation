---
title: Dapatkan Properti Efektif Bentuk dari Presentasi di PHP
linktitle: Properti Efektif
type: docs
weight: 50
url: /id/php-java/shape-effective-properties/
keywords:
- properti bentuk
- properti kamera
- rig cahaya
- bentuk bevel
- bingkai teks
- gaya teks
- tinggi font
- format isi
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Temukan bagaimana Aspose.Slides untuk PHP melalui Java menghitung dan menerapkan properti bentuk efektif untuk rendering PowerPoint yang tepat."
---
## **Gambaran Umum**

Topik ini menjelaskan perbedaan antara **local** dan **effective** properties. Nilai local adalah nilai yang ditetapkan secara langsung pada level format tertentu, seperti:

1. Properti bagian pada slide.  
1. Gaya teks bentuk prototipe pada layout atau master slide, ketika bentuk bingkai teks bagian memiliki satu.  
1. Pengaturan teks global dalam sebuah presentasi.

Nilai local dapat didefinisikan atau dihilangkan pada level manapun. Ketika Aspose.Slides memerlukan format akhir "as rendered", ia menyelesaikan rantai pewarisan dan mengembalikan nilai **effective**. Anda dapat memperolehnya dengan memanggil metode `getEffective` pada objek format local.

Contoh berikut menunjukkan cara mendapatkan nilai effective. Diasumsikan bahwa bentuk pertama pada slide pertama adalah sebuah [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/) dengan bingkai teks dan setidaknya satu bagian.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $localTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $effectiveTextFrameFormat = $localTextFrameFormat->getEffective();

    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $portion = $paragraph->getPortions()->get_Item(0);

    $localPortionFormat = $portion->getPortionFormat();
    $effectivePortionFormat = $localPortionFormat->getEffective();
} finally {
    $presentation->dispose();
}
```

{{% alert color="primary" %}}
Data format effective mewakili format yang dihitung saat ini setelah pewarisan diterapkan. Pada implementasi saat ini, beberapa objek data effective yang dikembalikan oleh metode seperti [PortionFormat.getEffective](https://reference.aspose.com/slides/id/php-java/aspose.slides/portionformat/geteffective/) dapat disimpan dalam cache secara internal. Memanggil `getEffective` lagi setelah mengubah format induk atau yang diwarisi dapat menyegarkan data yang di‑cache, dan objek yang sebelumnya diperoleh mungkin tidak lagi mewakili keadaan sebelumnya. Jika Anda perlu menyimpan nilai effective untuk penggunaan kembali nanti, salin properti yang diperlukan, seperti tinggi font, warna isi, gaya font, atau perataan, ke dalam objek data Anda sendiri.
{{% /alert %}}

## **Mendapatkan Properti Effective Kamera**

Aspose.Slides memungkinkan Anda mendapatkan properti effective dari kamera. Data effective yang dikembalikan oleh [ThreeDFormat.getEffective](https://reference.aspose.com/slides/id/php-java/aspose.slides/threedformat/geteffective/) berisi properti kamera akhir untuk sebuah [ThreeDFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/threedformat/).

Contoh kode berikut menunjukkan cara mendapatkan properti effective untuk kamera. Diasumsikan bahwa bentuk pertama pada slide pertama memiliki format 3D.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $threeDEffectiveData = $shape->getThreeDFormat()->getEffective();
    $camera = $threeDEffectiveData->getCamera();
    $cameraType = $camera->getCameraType();
    $fieldOfViewAngle = $camera->getFieldOfViewAngle();
    $zoom = $camera->getZoom();

    echo "= Effective camera properties =" . PHP_EOL;
    echo "Type: " . $cameraType . PHP_EOL;
    echo "Field of view: " . $fieldOfViewAngle . PHP_EOL;
    echo "Zoom: " . $zoom . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Mendapatkan Properti Effective Rig Cahaya**

Aspose.Slides memungkinkan Anda mendapatkan properti effective dari rig cahaya. Data effective yang dikembalikan oleh [ThreeDFormat.getEffective](https://reference.aspose.com/slides/id/php-java/aspose.slides/threedformat/geteffective/) berisi properti rig cahaya akhir untuk sebuah [ThreeDFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/threedformat/).

Contoh kode berikut menunjukkan cara mendapatkan properti effective untuk rig cahaya. Diasumsikan bahwa bentuk pertama pada slide pertama memiliki format 3D.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $threeDEffectiveData = $shape->getThreeDFormat()->getEffective();
    $lightRig = $threeDEffectiveData->getLightRig();
    $lightType = $lightRig->getLightType();
    $direction = $lightRig->getDirection();

    echo "= Effective light rig properties =" . PHP_EOL;
    echo "Type: " . $lightType . PHP_EOL;
    echo "Direction: " . $direction . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Mendapatkan Properti Effective Bentuk Bevel**

Aspose.Slides memungkinkan Anda mendapatkan properti effective dari bevel bentuk. Data effective yang dikembalikan oleh [ThreeDFormat.getEffective](https://reference.aspose.com/slides/id/php-java/aspose.slides/threedformat/geteffective/) berisi properti relief muka akhir untuk sebuah [ThreeDFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/threedformat/).

Contoh kode berikut menunjukkan cara mendapatkan properti effective untuk bevel atas sebuah bentuk. Diasumsikan bahwa bentuk pertama pada slide pertama memiliki format 3D.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $threeDEffectiveData = $shape->getThreeDFormat()->getEffective();
    $bevelTop = $threeDEffectiveData->getBevelTop();
    $bevelType = $bevelTop->getBevelType();
    $bevelWidth = $bevelTop->getWidth();
    $bevelHeight = $bevelTop->getHeight();

    echo "= Effective shape's top face relief properties =" . PHP_EOL;
    echo "Type: " . $bevelType . PHP_EOL;
    echo "Width: " . $bevelWidth . PHP_EOL;
    echo "Height: " . $bevelHeight . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Mendapatkan Properti Effective Bingkai Teks**

Dengan Aspose.Slides, Anda dapat mendapatkan properti effective dari sebuah bingkai teks. Data effective yang dikembalikan oleh [TextFrameFormat.getEffective](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframeformat/geteffective/) berisi properti format bingkai teks.

Contoh kode berikut menunjukkan cara mendapatkan properti format bingkai teks effective. Diasumsikan bahwa bentuk pertama pada slide pertama adalah sebuah [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/) dengan bingkai teks.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $effectiveTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat()->getEffective();
    $anchoringType = $effectiveTextFrameFormat->getAnchoringType();
    $autofitType = $effectiveTextFrameFormat->getAutofitType();
    $textVerticalType = $effectiveTextFrameFormat->getTextVerticalType();
    $marginLeft = $effectiveTextFrameFormat->getMarginLeft();
    $marginTop = $effectiveTextFrameFormat->getMarginTop();
    $marginRight = $effectiveTextFrameFormat->getMarginRight();
    $marginBottom = $effectiveTextFrameFormat->getMarginBottom();

    echo "Anchoring type: " . $anchoringType . PHP_EOL;
    echo "Autofit type: " . $autofitType . PHP_EOL;
    echo "Text vertical type: " . $textVerticalType . PHP_EOL;
    echo "Margins" . PHP_EOL;
    echo "   Left: " . $marginLeft . PHP_EOL;
    echo "   Top: " . $marginTop . PHP_EOL;
    echo "   Right: " . $marginRight . PHP_EOL;
    echo "   Bottom: " . $marginBottom . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Mendapatkan Properti Effective Gaya Teks**

Dengan Aspose.Slides, Anda dapat mendapatkan properti effective dari gaya teks. Data effective yang dikembalikan oleh [TextStyle.getEffective](https://reference.aspose.com/slides/id/php-java/aspose.slides/textstyle/geteffective/) berisi properti gaya teks.

Contoh kode berikut menunjukkan cara mendapatkan properti gaya teks effective. Diasumsikan bahwa bentuk pertama pada slide pertama adalah sebuah [AutoShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/autoshape/) dengan bingkai teks.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $textFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $textStyle = $textFrameFormat->getTextStyle();
    $effectiveTextStyle = $textStyle->getEffective();
    $levelCount = 9;

    for ($levelIndex = 0; $levelIndex < $levelCount; $levelIndex++) {
        $effectiveStyleLevel = $effectiveTextStyle->getLevel($levelIndex);
        $depth = $effectiveStyleLevel->getDepth();
        $indent = $effectiveStyleLevel->getIndent();
        $alignment = $effectiveStyleLevel->getAlignment();
        $fontAlignment = $effectiveStyleLevel->getFontAlignment();

        echo "= Effective paragraph formatting for style level #" . $levelIndex . " =" . PHP_EOL;

        echo "Depth: " . $depth . PHP_EOL;
        echo "Indent: " . $indent . PHP_EOL;
        echo "Alignment: " . $alignment . PHP_EOL;
        echo "Font alignment: " . $fontAlignment . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Mendapatkan Nilai Tinggi Font Effective**

Dengan Aspose.Slides, Anda dapat mendapatkan tinggi font effective. Contoh berikut menunjukkan bagaimana tinggi font effective sebuah bagian berubah setelah nilai tinggi font lokal diatur pada level struktur presentasi yang berbeda.

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 75, false);
    $autoShape->addTextFrame("");

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $firstPortion = new Portion("Sample text with first portion");
    $secondPortion = new Portion(" and second portion.");

    $paragraph->getPortions()->add($firstPortion);
    $paragraph->getPortions()->add($secondPortion);

    $firstEffectivePortionFormat = $firstPortion->getPortionFormat()->getEffective();
    $secondEffectivePortionFormat = $secondPortion->getPortionFormat()->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height just after creation:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $defaultStyleLevel = $presentation->getDefaultTextStyle()->getLevel(0);
    $defaultPortionFormat = $defaultStyleLevel->getDefaultPortionFormat();
    $defaultPortionFormat->setFontHeight(24);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting the presentation default font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $paragraphDefaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
    $paragraphDefaultPortionFormat->setFontHeight(40);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting paragraph default font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $firstPortionFormat->setFontHeight(55);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting portion #0 font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $secondPortionFormat->setFontHeight(18);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting portion #1 font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $presentation->save("SetLocalFontHeightValues.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Mendapatkan Format Isi Effective untuk Tabel**

Dengan Aspose.Slides, Anda dapat mendapatkan format isi effective untuk berbagai bagian tabel. Data effective yang dikembalikan oleh objek format berisi properti [FillFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/fillformat/). Format sel memiliki prioritas lebih tinggi daripada format baris, format baris memiliki prioritas lebih tinggi daripada format kolom, dan format kolom memiliki prioritas lebih tinggi daripada format seluruh tabel.

Sebagai hasilnya, properti [CellFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/cellformat/) effective digunakan untuk menggambar sel tabel. Contoh kode berikut menunjukkan cara mendapatkan format isi effective untuk berbagai bagian tabel. Diasumsikan bahwa bentuk pertama pada slide pertama adalah sebuah [Table](https://reference.aspose.com/slides/id/php-java/aspose.slides/table/).

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    $tableFormatEffective = $table->getTableFormat()->getEffective();

    $row = $table->getRows()->get_Item(0);
    $rowFormatEffective = $row->getRowFormat()->getEffective();

    $column = $table->getColumns()->get_Item(0);
    $columnFormatEffective = $column->getColumnFormat()->getEffective();

    $cell = $table->get_Item(0, 0);
    $cellFormatEffective = $cell->getCellFormat()->getEffective();

    $tableFillFormatEffective = $tableFormatEffective->getFillFormat();
    $rowFillFormatEffective = $rowFormatEffective->getFillFormat();
    $columnFillFormatEffective = $columnFormatEffective->getFillFormat();
    $cellFillFormatEffective = $cellFormatEffective->getFillFormat();
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Apakah `getEffective` mengembalikan snapshot?**

Tidak selalu. Data effective mewakili format yang dihitung setelah pewarisan diterapkan, tetapi beberapa objek data effective dapat disimpan dalam cache secara internal. Pemanggilan `getEffective` berikutnya mungkin menghitung ulang format dan menyegarkan data yang di‑cache, sehingga objek yang sebelumnya diperoleh tidak boleh dianggap sebagai snapshot yang tahan lama.

**Kapan saya harus membaca properti effective lagi?**

Panggil `getEffective` lagi setelah mengubah format lokal, gaya induk, format layout, format master, atau nilai default pada tingkat presentasi. Panggilan selanjutnya akan mengevaluasi ulang hierarki format dan mengembalikan hasil effective saat ini.

**Apakah mengubah atau menghapus slide layout/master mempengaruhi properti effective yang sudah diambil?**

Ya, tetapi perubahan tersebut akan terlihat pada pemanggilan `getEffective` berikutnya. Jika sumber format induk diubah atau dihapus, data effective yang sebelumnya diperoleh mungkin sudah usang. Setelah `getEffective` dipanggil lagi, Aspose.Slides akan mengevaluasi ulang pohon format dan font, warna, ukuran, atau nilai lainnya dapat berubah.

**Apakah saya dapat memodifikasi nilai melalui objek data effective?**

Tidak. Objek data effective hanya mengekspose nilai yang telah dihitung. Lakukan perubahan pada objek format lokal, kemudian peroleh kembali nilai effective.

**Apa yang terjadi jika properti tidak diatur pada level bentuk, maupun di layout/master, maupun di pengaturan global?**

Nilai effective ditentukan oleh mekanisme default, yang mencakup nilai default PowerPoint dan Aspose.Slides. Nilai yang terpecahkan tersebut menjadi bagian dari data effective saat ini.

**Dari nilai font effective, dapatkah saya mengetahui level mana yang menyediakan ukuran atau tipe huruf?**

Tidak secara langsung. Data effective hanya mengembalikan nilai akhir. Untuk menemukan sumbernya, periksa nilai lokal pada bagian, paragraf, bingkai teks, serta gaya teks pada layout, master, dan tingkat presentasi untuk melihat di mana definisi eksplisit pertama muncul.

**Mengapa nilai effective kadang terlihat identik dengan nilai lokal?**

Karena nilai lokal berakhir menjadi nilai akhir (tidak ada pewarisan dari level yang lebih tinggi yang diperlukan). Dalam kasus tersebut, nilai effective sama dengan nilai lokal.

**Kapan saya harus menggunakan properti effective, dan kapan saya hanya bekerja dengan nilai lokal?**

Gunakan data effective ketika Anda memerlukan hasil "as rendered" setelah semua pewarisan diterapkan, misalnya untuk menyelaraskan warna, indentasi, atau ukuran. Jika Anda perlu mempertahankan nilai tersebut terlepas dari perubahan format selanjutnya, salin properti yang diperlukan ke dalam objek Anda sendiri. Jika Anda perlu mengubah format pada level tertentu, modifikasi properti lokal dan kemudian, jika diperlukan, baca kembali data effective untuk memverifikasi hasilnya.