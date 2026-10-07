---
title: Kelola Sel Tabel dalam Presentasi Menggunakan PHP
linktitle: Kelola Sel
type: docs
weight: 30
url: /id/php-java/manage-cells/
keywords:
- sel tabel
- menggabungkan sel
- hapus batas
- pisah sel
- gambar dalam sel
- warna latar belakang
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Kelola sel tabel PowerPoint dalam PHP: mengidentifikasi sel yang digabungkan, menghapus batas, memisahkan sel, dan mengatur warna latar belakang serta gambar dengan Aspose.Slides untuk PHP melalui Java."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda mengakses dan memodifikasi sel tabel dalam presentasi PowerPoint. Artikel ini menjelaskan cara mengidentifikasi sel tabel yang digabungkan, menghapus batas sel, bekerja dengan penomoran sel setelah menggabungkan atau memisahkan sel, mengubah warna latar belakang sel, dan menambahkan gambar di dalam sel tabel. Contoh-contoh menunjukkan cara membuat atau membuka presentasi, mendapatkan tabel dari slide, memperbarui pemformatan sel melalui properti sel, dan menyimpan presentasi yang telah dimodifikasi sebagai file PPTX.

Aspose.Slides menggunakan indeks berbasis nol untuk mengakses sel tabel dengan urutan `(column, row)`.

## **Mengidentifikasi Sel Tabel yang Digabungkan**

Contoh ini membuka presentasi yang ada dan mengakses bentuk pertama pada slide pertama sebagai tabel. Ia mengasumsikan bahwa slide dan bentuk ada serta bentuk tersebut adalah tabel. Kemudian ia mengiterasi semua baris dan kolom serta menggunakan [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) untuk mengidentifikasi sel di wilayah yang digabungkan. Untuk setiap kecocokan, ia mencetak koordinat sel dalam urutan `row;column`, [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/), [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/), dan koordinat awal wilayah, [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) dan [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/).

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation_with_table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);

    $rowCount = java_values($table->getRows()->size());
    for ($rowIndex = 0; $rowIndex < $rowCount; $rowIndex++)
    {
        $columnCount = java_values($table->getColumns()->size());
        for ($columnIndex = 0; $columnIndex < $columnCount; $columnIndex++)
        {
            $cell = $table->get_Item($columnIndex, $rowIndex);
            if (java_values($cell->isMergedCell()))
            {
                printf("Cell %d;%d belongs to a merged region with RowSpan=%d and ColSpan=%d starting at %d;%d.\n", $rowIndex, $columnIndex, java_values($cell->getRowSpan()), java_values($cell->getColSpan()), java_values($cell->getFirstRowIndex()), java_values($cell->getFirstColumnIndex()));
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Menghapus Batas Sel Tabel**

Buat sebuah [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) dan tambahkan tabel ke slide pertamanya dengan [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/). Lebar kolom, tinggi baris, dan posisi tabel ditentukan dalam poin. Contoh ini mengatur semua empat batas sel ke [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/), membuatnya tidak terlihat.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 50, 50, 50, 50 ];
    $rowHeights = [ 50, 30, 30, 30, 30 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
        for ($columnIndex = 0; $columnIndex < java_values($table->getColumns()->size()); $columnIndex++) {
            $cell = $table->get_Item($columnIndex, $rowIndex);
            $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::NoFill);
            $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::NoFill);
            $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::NoFill);
            $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::NoFill);
        }
    }

    $presentation->save("table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Menggabungkan Sel Tabel**

Gunakan [mergeCells](https://reference.aspose.com/slides/php-java/aspose.slides/table/mergecells/) untuk menggabungkan rentang persegi panjang sel tabel menjadi satu sel. Tentukan sel di sudut kiri‑atas dan kanan‑bawah dari rentang. Argumen terakhir mengontrol apakah penggabungan dapat mencakup sel di luar rentang yang ditentukan; `false` menjaga penggabungan tetap dalam rentang tersebut.

Contoh ini membuat tabel 4‑by‑4 dengan kolom dan baris 70 poin, kemudian menggabungkan empat sel tengah dari `(1, 1)` hingga `(2, 2)`. Sel yang dihasilkan mencakup dua kolom dan dua baris, sementara grid tabel yang mendasarinya tetap memiliki empat kolom dan empat baris. Untuk mengakses konten atau pemformatan sel yang digabungkan, gunakan posisi kiri‑atasnya: `$table->get_Item(1, 1)` dalam contoh ini. Posisi lain dalam rentang yang digabungkan tetap menjadi bagian dari grid tabel, sehingga indeks sel di luar rentang tidak berubah.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 70, 70, 70, 70 ];
    $rowHeights = [ 70, 70, 70, 70 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->mergeCells($table->get_Item(1, 1), $table->get_Item(2, 2), false);

    $presentation->save("merged_cells.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Memisahkan Sel Tabel**

Menggabungkan sel pada contoh sebelumnya mempertahankan grid tabel. Memisahkan sel dapat memperkenalkan kolom grid baru dan mengubah indeks kolom sel di sebelah kanannya. Aspose.Slides mengikuti model grid tabel PowerPoint.

Contoh ini membuat tabel 4‑by‑4 dengan kolom dan baris 70 poin dan memanggil [splitByWidth](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbywidth/) pada sel `(1, 1)`. Setengah lebar 70 poin sel tersebut digunakan untuk membuat dua sel dengan lebar sama.

Setelah pemisahan ini, kedua bagian diakses sebagai `$table->get_Item(1, 1)` dan `$table->get_Item(2, 1)`. Grid tabel kini memiliki lima kolom: sel yang semula berada di kolom 2 dan 3 berpindah ke kolom 3 dan 4, masing‑masing. Indeks baris tetap tidak berubah. Gunakan indeks kolom yang diperbarui ini saat mengakses sel setelah pemisahan.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 70, 70, 70, 70 ];
    $rowHeights = [ 70, 70, 70, 70 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->get_Item(1, 1)->splitByWidth(java_values($table->get_Item(1, 1)->getWidth()) / 2);

    $presentation->save("split_cells.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Membagi Sel yang Digabungkan berdasarkan Baris atau Kolom**

Untuk menyiapkan sel templat yang digabungkan bagi pengisian data, gunakan [splitByRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyrowspan/) untuk memisahkan sepanjang batas baris yang ada, atau [splitByColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbycolspan/) untuk memisahkan sepanjang batas kolom.

`index` menghitung baris di bagian atas atau kolom di bagian kiri dari pemisahan; ia relatif terhadap wilayah yang digabungkan:
- Pemisahan baris: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/).
- Pemisahan kolom: `0 < index <` [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/).

Contoh ini mengasumsikan presentasi memiliki tabel sebagai bentuk pertama pada slide pertama, dengan `(1, 2)` dan `(1, 3)` digabungkan secara vertikal. Memulai dari posisi bawah, ia menggunakan [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) dan [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) untuk menemukan asal dan memeriksa kedua rentang. `splitByRowSpan(1)` kemudian memisahkan baris 2 dan 3 untuk nama produk. Untuk penggabungan dua kolom horizontal, gunakan `splitByColSpan(1)` sebagai gantinya.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("table_template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);

    $selectedCell = $table->get_Item(1, 3);
    $firstColumnIndex = java_values($selectedCell->getFirstColumnIndex());
    $firstRowIndex = java_values($selectedCell->getFirstRowIndex());
    $mergedCell = $table->get_Item($firstColumnIndex, $firstRowIndex);

    if (java_values($mergedCell->isMergedCell()) && java_values($mergedCell->getRowSpan()) == 2 && java_values($mergedCell->getColSpan()) == 1)
    {
        $mergedCell->splitByRowSpan(1);

        // Ambil sel yang dihasilkan dari tabel setelah pemisahan.
        $upperCell = $table->get_Item($firstColumnIndex, $firstRowIndex);
        $lowerCell = $table->get_Item($firstColumnIndex, $firstRowIndex + 1);
        echo "Upper cell merged: " . (java_values($upperCell->isMergedCell()) ? "true" : "false") . PHP_EOL;
        echo "Lower cell merged: " . (java_values($lowerCell->isMergedCell()) ? "true" : "false") . PHP_EOL;

        $upperCell->getTextFrame()->setText("Product A");
        $lowerCell->getTextFrame()->setText("Product B");

        $presentation->save("split_template.pptx", SaveFormat::Pptx);
    }
    else
    {
        echo "Select a merged region spanning exactly two rows and one column." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Grid tabel dan indeks sel di sekitarnya tetap tidak berubah. Ambil sel hasil dengan koordinatnya; di sini, keduanya memiliki rentang 1 dan [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) mencetak `false`. Wilayah yang lebih besar dapat tetap sebagian digabungkan setelah satu pemisahan.

Teks asli dan pemformatannya tetap berada di sel atas (atau kiri); sel baru kosong tetapi mewarisi pemformatan sel seperti isi, batas, dan margin. Isi sel setelah pemisahan dan atur pemformatan teks yang diperlukan secara eksplisit.

Presentasi yang disimpan berisi sel terpisah "Product A" dan "Product B" dengan pemformatan sel templat yang dipertahankan. Lihat [Cell API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) untuk detail.

## **Mengubah Warna Latar Belakang Sel Tabel**

Contoh ini membuat tabel dengan kolom 150 poin dan baris 50 poin. Ia menggunakan [setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) untuk memilih isian solid dan mengatur warna yang dikembalikan oleh [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/getsolidfillcolor/) menjadi merah untuk sel `(2, 3)`, di kolom ketiga dan baris keempat.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 150, 150, 150, 150 ];
    $rowHeights = [ 50, 50, 50, 50, 50 ];
    $table = $slide->getShapes()->addTable(50, 50, $columnWidths, $rowHeights);

    $cell = $table->get_Item(2, 3);
    $cell->getCellFormat()->getFillFormat()->setFillType(FillType::Solid);
    $cell->getCellFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $presentation->save("cell_background_color.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Menambahkan Gambar di Dalam Sel Tabel**

Letakkan gambar input di direktori kerja sebelum menjalankan contoh ini. Ia memuat gambar dengan [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile) dan menambahkannya ke koleksi gambar presentasi dengan [addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/addimage/). Kemudian ia menetapkan gambar sebagai isian gambar sel `(0, 0)`, sel pertama di tabel.

[PictureFillMode::Stretch](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) memperluas gambar untuk mengisi sel, yang mungkin mengubah rasio aspeknya. Lebar kolom dan tinggi baris dalam poin. Gambar yang dimuat dibuang dalam blok `finally` setelah ditambahkan ke presentasi.

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 150, 150, 150, 150 ];
    $rowHeights = [ 100, 100, 100, 100, 90 ];
    $table = $slide->getShapes()->addTable(50, 50, $columnWidths, $rowHeights);

    $image = Images::fromFile("aspose_logo.jpg");
    try {
        $ppImage = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $table->get_Item(0, 0)->getCellFormat()->getFillFormat()->setFillType(FillType::Picture);
    $table->get_Item(0, 0)->getCellFormat()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
    $table->get_Item(0, 0)->getCellFormat()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($ppImage);

    $presentation->save("table_cell_with_image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Apakah saya dapat mengatur ketebalan dan gaya garis yang berbeda untuk setiap sisi sel tunggal?**

Ya. Batas [top](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderright/) memiliki properti terpisah, sehingga ketebalan dan gaya setiap sisi dapat berbeda.

**Apa yang terjadi pada gambar jika saya mengubah ukuran kolom/baris setelah menetapkan gambar sebagai latar belakang sel?**

Perilaku tergantung pada [fill mode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/). Dengan stretch, gambar menyesuaikan diri dengan sel baru; dengan tile, ubin dihitung ulang.

**Apakah saya dapat menetapkan hyperlink ke seluruh konten sel?**

[Hyperlinks](/slides/id/php-java/manage-hyperlinks/) diatur pada tingkat teks (portion) di dalam frame teks sel atau pada tingkat seluruh tabel/bentuk. Pada praktiknya, Anda menetapkan tautan ke sebuah portion atau ke seluruh teks dalam sel.

**Apakah saya dapat mengatur font yang berbeda dalam satu sel?**

Ya. Frame teks sel mendukung [portions](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) (run) dengan pemformatan independen—famili font, gaya, ukuran, dan warna.