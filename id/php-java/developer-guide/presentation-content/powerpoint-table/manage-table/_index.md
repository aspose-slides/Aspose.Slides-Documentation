---
title: Kelola Tabel Presentasi dalam PHP
linktitle: Kelola Tabel
type: docs
weight: 10
url: /id/php-java/manage-table/
keywords:
- menambah tabel
- buat tabel
- akses tabel
- rasio aspek
- ratakan teks
- pemformatan teks
- gaya tabel
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Buat & edit tabel di slide PowerPoint dengan Aspose.Slides untuk PHP via Java. Temukan contoh kode sederhana untuk menyederhanakan alur kerja tabel Anda."
---
## **Pendahuluan**

Tabel di PowerPoint mengatur informasi menjadi baris dan kolom, memudahkan pembacaan dan perbandingan nilai.

Aspose.Slides menyediakan kelas [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) kelas [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) dan tipe lainnya untuk memungkinkan Anda membuat, memperbarui, dan mengelola tabel dalam presentasi.

## **Buat Tabel dari Awal**

Buat tabel dengan menentukan posisinya, lebar kolom, dan tinggi baris. Setelah menambahkannya ke slide, Anda dapat memformat batas sel, menggabungkan sel, dan menyisipkan teks.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tentukan array lebar kolom dalam poin.
4. Tentukan array tinggi baris dalam poin.
5. Tambahkan objek [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) ke slide melalui metode [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/) .
6. Iterasikan setiap [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) untuk menerapkan pemformatan pada batas atas, bawah, kanan, dan kiri.
7. Gabungkan dua sel pertama pada baris pertama tabel.
8. Akses sel yang digabungkan melalui metode [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/cell/gettextframe/) .
9. Setel teks pada sel yang digabungkan.
10. Simpan presentasi yang telah dimodifikasi.

Contoh di bawah ini membuat tabel dengan tiga kolom dan lima baris pada koordinat (100, 50) poin. Ia menerapkan batas merah dengan lebar 5 poin, menggabungkan dua sel pertama pada baris pertama, dan menyimpan hasilnya sebagai `table.pptx`.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $red = java("java.awt.Color")->RED;
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 50, 50, 50 ];
    $rowHeights = [ 50, 30, 30, 30, 30 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
        $row = $table->getRows()->get_Item($rowIndex);
        for ($columnIndex = 0; $columnIndex < java_values($row->size()); $columnIndex++) {
            $cell = $row->get_Item($columnIndex);
            $cellFormat = $cell->getCellFormat();
            $cellFormat->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderTop()->setWidth(5);

            $cellFormat->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderBottom()->setWidth(5);

            $cellFormat->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderLeft()->setWidth(5);

            $cellFormat->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderRight()->setWidth(5);
        }
    }

    $table->mergeCells($table->get_Item(0, 0), $table->get_Item(1, 0), false);
    $table->get_Item(0, 0)->getTextFrame()->setText("Merged Cells");

    $presentation->save("table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Penomoran dalam Tabel Standar**

Dalam tabel standar, indeks sel berbasis nol dan menggunakan urutan (kolom, baris). Sel pertama diindeks sebagai (0, 0).

Sebagai contoh, sel‑sel dalam tabel dengan 4 kolom dan 4 baris diberi nomor seperti ini:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Contoh ini membuat tabel 4 × 4 yang diilustrasikan di atas, dengan lebar kolom dan tinggi baris masing‑masing 70 poin serta batas sel merah dengan lebar 5 poin. Koordinat menunjukkan indeks sel; contoh ini membiarkan sel kosong dan menyimpan tabel sebagai `StandardTables_out.pptx`.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $red = java("java.awt.Color")->RED;
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 70, 70, 70, 70 ];
    $rowHeights = [ 70, 70, 70, 70 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
        $row = $table->getRows()->get_Item($rowIndex);
        for ($columnIndex = 0; $columnIndex < java_values($row->size()); $columnIndex++) {
            $cell = $row->get_Item($columnIndex);
            $cellFormat = $cell->getCellFormat();
            $cellFormat->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderTop()->setWidth(5);

            $cellFormat->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderBottom()->setWidth(5);

            $cellFormat->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderLeft()->setWidth(5);

            $cellFormat->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderRight()->setWidth(5);
        }
    }

    $presentation->save("StandardTables_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Akses Tabel yang Ada**

Tabel disimpan dalam koleksi shape slide. Iterasikan shape‑shape untuk menemukan tabel, lalu gunakan kelas [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) untuk membaca atau memperbarui sel‑selnya.

1. Muat presentasi menggunakan kelas [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. Dapatkan referensi ke slide yang berisi tabel berdasarkan indeksnya.
3. Iterasikan objek [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) dan berhenti ketika menemukan tabel. Jika slide berisi beberapa tabel, gunakan [getAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getalternativetext/) untuk mengidentifikasi tabel yang Anda butuhkan.
4. Perbarui teks di sel target.
5. Simpan presentasi yang telah dimodifikasi.

Contoh di bawah ini membuka `UpdateExistingTable.pptx` dan menemukan tabel pertama pada slide pertama. Ia menetapkan sel pada kolom 0, baris 1 menjadi `New` dan menyimpan hasilnya sebagai `table1_out.pptx`. Input harus berisi setidaknya satu slide, dan tabel pertama pada slide tersebut harus memiliki setidaknya satu kolom dan dua baris.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("UpdateExistingTable.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = null;
    $tableClass = new JavaClass("com.aspose.slides.Table");

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, $tableClass)) {
            $table = $shape;
            break;
        }
    }

    if ($table !== null) {
        $table->get_Item(0, 1)->getTextFrame()->setText("New");
        $presentation->save("table1_out.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Untuk mengubah ukuran baris dalam tabel yang ada dan memahami mengapa tinggi sebenarnya dapat melebihi minimum yang diminta, lihat [Kontrol Tinggi Baris](/slides/id/php-java/manage-rows-and-columns/#control-row-height).

## **Temukan Sel yang Memiliki Text Frame**

Ketika kode pemrosesan teks umum menerima sebuah [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) dari tabel, gunakan metode [TextFrame::getParentCell](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentCell) untuk mengambil [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) pemiliknya. Untuk text frame sel tabel, [TextFrame::getParentCell](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentCell) mengembalikan pemilik dan [TextFrame::getParentShape](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentShape) mengembalikan `null`, meskipun tabel itu sendiri adalah sebuah shape.

Koordinat sel tersedia melalui metode read‑only [Cell::getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) dan [Cell::getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/). [TextFrame::getParentCell](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentCell) juga menyediakan navigasi read‑only: ia mengembalikan pemilik tetapi tidak mengubah kepemilikan. Selalu periksa sel yang dikembalikan dengan `java_is_null` sebelum menggunakannya.

Untuk contoh lengkap yang mengidentifikasi pemilik sel‑tabel dan shape, termasuk shape yang terkait dengan node SmartArt, lihat [Cari dan Ganti Teks](/slides/id/php-java/search-and-replace-text/).

## **Ratakan Teks dalam Tabel**

Anda dapat mengontrol penambatan vertikal dan arah teks dari sel tabel individu. Contoh pada bagian ini menengahkan teks dalam sel pertama dan memutar teks 270 derajat.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tambahkan objek [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) ke slide.
4. Akses objek [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) dari tabel.
5. Akses [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) pertama dan tetapkan teks serta warnanya.
6. Setel penambatan vertikal sel dan arah teks menggunakan [setTextAnchorType](https://reference.aspose.com/slides/php-java/aspose.slides/cell/settextanchortype/) dan [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/cell/settextverticaltype/) .
7. Simpan presentasi yang telah dimodifikasi.

Contoh ini membuat tabel 4 × 4 dengan lebar kolom 120 poin dan tinggi baris 100 poin. Ia memformat teks di sel (0, 0), menambahkan nilai ke sel‑sel yang tersisa di baris pertama, dan menyimpan hasilnya sebagai `Vertical_Align_Text_out.pptx`.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAnchorType;
use aspose\slides\TextVerticalType;

$presentation = new Presentation();
try {
    $black = java("java.awt.Color")->BLACK;
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 120, 120, 120, 120 ];
    $rowHeights = [ 100, 100, 100, 100 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->get_Item(1, 0)->getTextFrame()->setText("10");
    $table->get_Item(2, 0)->getTextFrame()->setText("20");
    $table->get_Item(3, 0)->getTextFrame()->setText("30");

    $textFrame = $table->get_Item(0, 0)->getTextFrame();
    $paragraph = $textFrame->getParagraphs()->get_Item(0);

    $portion = $paragraph->getPortions()->get_Item(0);
    $portion->setText("Text here");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($black);

    $cell = $table->get_Item(0, 0);
    $cell->setTextAnchorType(TextAnchorType::Center);
    $cell->setTextVerticalType(TextVerticalType::Vertical270);

    $presentation->save("Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Setel Pemformatan Teks pada Tingkat Tabel**

Gunakan [setTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/table/settextformat/) untuk menerapkan pemformatan teks ke semua sel dalam tabel. Overload‑nya menerima pemformatan bagian, paragraf, dan text frame, sehingga Anda dapat mengatur properti ini tanpa iterasi melalui setiap sel.

1. Muat presentasi menggunakan kelas [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Akses objek [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) dari slide.
4. Setel ukuran font menggunakan [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) untuk teks.
5. Setel perataan paragraf dan margin kanan menggunakan [setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) dan [setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/) .
6. Setel arah teks menggunakan [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/) .
7. Simpan presentasi yang telah dimodifikasi.

Contoh di bawah ini membuka `table.pptx`, yang harus berisi setidaknya satu slide dengan tabel sebagai shape pertama. Ia mengatur ukuran font menjadi 25 poin, meratakan paragraf ke kanan dengan margin kanan 20 poin, dan menjadikan teks vertikal. Presentasi yang diformat disimpan sebagai `result.pptx`.

```php
use aspose\slides\ParagraphFormat;
use aspose\slides\PortionFormat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAlignment;
use aspose\slides\TextFrameFormat;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);

    $portionFormat = new PortionFormat();
    $portionFormat->setFontHeight(25);
    $table->setTextFormat($portionFormat);

    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat->setAlignment(TextAlignment::Right);
    $paragraphFormat->setMarginRight(20);
    $table->setTextFormat($paragraphFormat);

    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat->setTextVerticalType(TextVerticalType::Vertical);
    $table->setTextFormat($textFrameFormat);

    $presentation->save("result.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Dapatkan Properti Gaya Tabel**

Gunakan [getStylePreset](https://reference.aspose.com/slides/php-java/aspose.slides/table/getstylepreset/) untuk membaca gaya preset tabel dan [setStylePreset](https://reference.aspose.com/slides/php-java/aspose.slides/table/setstylepreset/) untuk menetapkannya. Contoh ini menerapkan [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/php-java/aspose.slides/tablestylepreset/) ke satu tabel, mencetak nilai preset, dan menetapkan preset yang sama ke tabel kedua. Kedua tabel disimpan dalam `table-style.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TableStylePreset;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 100, 150 ];
    $rowHeights = [ 5, 5, 5 ];
    $table = $slide->getShapes()->addTable(10, 10, $columnWidths, $rowHeights);
    $table->setStylePreset(TableStylePreset::DarkStyle1);

    $stylePreset = java_values($table->getStylePreset());
    echo "Table style preset: " . $stylePreset . PHP_EOL;

    $anotherTable = $slide->getShapes()->addTable(10, 100, $columnWidths, $rowHeights);
    $anotherTable->setStylePreset($stylePreset);

    $presentation->save("table-style.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Kunci Rasio Aspek Tabel**

Rasio aspek tabel adalah perbandingan lebar dengan tingginya. Gunakan [setAspectRatioLocked](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/setaspectratiolocked/) untuk mengunci rasio ini pada tabel.

Contoh di bawah ini membuka `pres.pptx`, yang harus berisi setidaknya satu slide dengan tabel sebagai shape pertama. Ia mencetak status kunci saat ini, mengaktifkan kunci rasio aspek, mencetak status yang diperbarui (`true`), dan menyimpan hasilnya sebagai `pres-out.pptx`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    echo "Lock aspect ratio set: " . (java_values($table->getGraphicalObjectLock()->getAspectRatioLocked()) ? "true" : "false") . PHP_EOL;

    $table->getGraphicalObjectLock()->setAspectRatioLocked(true);
    echo "Lock aspect ratio set: " . (java_values($table->getGraphicalObjectLock()->getAspectRatioLocked()) ? "true" : "false") . PHP_EOL;

    $presentation->save("pres-out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Apakah saya dapat mengaktifkan arah baca kanan-ke-kiri (RTL) untuk seluruh tabel dan teks di sel‑selnya?**

Ya. Tabel menyediakan metode [setRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/table/setrighttoleft/) , dan paragraf memiliki [ParagraphFormat::setRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setrighttoleft/) . Menggunakan keduanya memastikan urutan RTL yang benar dan rendering di dalam sel.

**Bagaimana saya dapat mencegah pengguna memindahkan atau mengubah ukuran tabel dalam file akhir?**

Gunakan [shape locks](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) untuk menonaktifkan pemindahan, pengubahan ukuran, pemilihan, dll. Kunci ini juga berlaku pada tabel.

**Apakah menyisipkan gambar di dalam sel sebagai latar belakang didukung?**

Ya. Anda dapat menetapkan [picture fill](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) untuk sel; gambar akan menutupi area sel sesuai mode yang dipilih (stretch atau tile).