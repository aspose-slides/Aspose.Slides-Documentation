---
title: Kelola Sel Tabel dalam Presentasi Menggunakan PHP
linktitle: Kelola Sel
type: docs
weight: 30
url: /id/php-java/manage-cells/
keywords:
- sel tabel
- gabungkan sel
- hapus batas
- pisah sel
- gambar dalam sel
- warna latar belakang
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Kelola sel tabel PowerPoint di PHP: identifikasi sel yang digabungkan, hapus batas, pisah sel, dan atur warna latar belakang serta gambar dengan Aspose.Slides untuk PHP via Java."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda mengakses dan memodifikasi sel tabel dalam presentasi PowerPoint. Artikel ini menjelaskan cara mengidentifikasi sel tabel yang digabungkan, menghapus batas sel, bekerja dengan penomoran sel setelah menggabungkan atau memisahkan sel, mengubah warna latar belakang sel, dan menambahkan gambar di dalam sel tabel. Contoh-contoh menunjukkan cara membuat atau membuka presentasi, mengambil tabel dari slide, memperbarui pemformatan sel melalui properti sel, dan menyimpan presentasi yang dimodifikasi sebagai file PPTX.

Aspose.Slides menggunakan indeks berbasis nol untuk mengakses sel tabel dalam urutan `(column, row)`.

## **Identifikasi Sel Tabel yang Digabungkan**

Contoh membuka presentasi yang sudah ada dan mengakses shape pertama pada slide pertama sebagai tabel. Asumsinya slide dan shape ada serta shape tersebut merupakan tabel. Kemudian contoh mengiterasi semua baris dan kolom serta menggunakan [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) untuk mengidentifikasi sel dalam wilayah yang digabungkan. Untuk setiap kecocokan, contoh mencetak koordinat sel dalam urutan `row;column`, [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/), [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/), dan koordinat awal wilayah, [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) serta [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/).

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

## **Hapus Garis Sel Tabel**

Buat sebuah [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) dan tambahkan tabel ke slide pertamanya dengan [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/). Lebar kolom, tinggi baris, dan posisi tabel ditentukan dalam poin. Contoh mengatur keempat garis sel menjadi [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/), sehingga tidak terlihat.

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

## **Tambahkan Garis Diagonal Sel**

Gunakan [getBorderDiagonalDown](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderdiagonaldown/) untuk menggambar garis dari sudut kiri‑atas ke sudut kanan‑bawah, dan [getBorderDiagonalUp](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderdiagonalup/) untuk menggambar garis dari sudut kiri‑bawah ke sudut kanan‑atas. Sebuah diagonal dapat menandai header sudut; kedua diagonal dapat membentuk X untuk menandai sel tidak berlaku.

Setiap diagonal memiliki [LineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/)‑nya masing‑masing. Pada [getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/getfillformat/), gunakan [setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) untuk memilih [FillType::Solid](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) dan pilih warna melalui [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/getsolidfillcolor/). Atur lebar garis dalam poin dengan [setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/setwidth/).

Contoh membuat tiga sel dalam satu baris: diagonal ke bawah merah, diagonal ke atas biru, dan kedua diagonal. Garis sel atas, bawah, kiri, dan kanan dibiarkan tidak berubah.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 210, 210, 210 ];
    $rowHeights = [ 160 ];
    $table = $slide->getShapes()->addTable(45, 130, $columnWidths, $rowHeights);

    $downwardBorder = $table->get_Item(0, 0)->getCellFormat()->getBorderDiagonalDown();
    $downwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $downwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $downwardBorder->setWidth(3);

    $upwardBorder = $table->get_Item(1, 0)->getCellFormat()->getBorderDiagonalUp();
    $upwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $upwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $upwardBorder->setWidth(5);

    $crossDownwardBorder = $table->get_Item(2, 0)->getCellFormat()->getBorderDiagonalDown();
    $crossDownwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $crossDownwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $crossDownwardBorder->setWidth(3);

    $crossUpwardBorder = $table->get_Item(2, 0)->getCellFormat()->getBorderDiagonalUp();
    $crossUpwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $crossUpwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $crossUpwardBorder->setWidth(5);

    $presentation->save("diagonal_cell_borders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sebuah diagonal hanya mengubah pemformatan sel. Setiap sel tetap memiliki satu text frame, yang dapat diakses melalui [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/cell/gettextframe/). Wilayah di masing‑masing sisi diagonal tidak dapat diedit secara independen.

Tabel yang disimpan, ditampilkan di Microsoft PowerPoint:

![Tiga sel tabel yang menunjukkan diagonal merah dari kiri atas ke kanan bawah, diagonal biru dari kiri bawah ke kanan atas, dan kedua diagonal membentuk X.](diagonal-cell-borders.png)

*Kiri ke kanan: diagonal ke bawah (merah, 3 pt), diagonal ke atas (biru, 5 pt), dan kedua diagonal.*

## **Gabungkan Sel Tabel**

Gunakan [mergeCells](https://reference.aspose.com/slides/php-java/aspose.slides/table/mergecells/) untuk menggabungkan rentang sel tabel berbentuk persegi panjang menjadi satu sel. Tentukan sel di sudut kiri‑atas dan kanan‑bawah rentang. Argumen terakhir mengontrol apakah penggabungan dapat mencakup sel di luar rentang yang ditentukan; `false` menjaga penggabungan tetap dalam rentang tersebut.

Contoh membuat tabel 4‑by‑4 dengan kolom dan baris 70 poin, lalu menggabungkan empat sel tengah dari `(1, 1)` hingga `(2, 2)`. Sel yang dihasilkan membentang dua kolom dan dua baris, sementara grid tabel yang mendasarinya tetap memiliki empat kolom dan empat baris. Untuk mengakses konten atau pemformatan sel yang digabungkan, gunakan posisi kiri‑atasnya: `$table->get_Item(1, 1)` dalam contoh ini. Posisi lainnya dalam rentang yang digabungkan tetap menjadi bagian dari grid tabel, sehingga indeks sel di luar rentang tidak berubah.

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

## **Pisah Sel Tabel**

Penggabungan sel pada contoh sebelumnya mempertahankan grid tabel. Memisahkan sebuah sel dapat menambahkan kolom grid baru dan mengubah indeks kolom sel di sebelah kanannya. Aspose.Slides mengikuti model grid tabel PowerPoint.

Contoh ini membuat tabel 4‑by‑4 dengan kolom dan baris 70 poin dan memanggil [splitByWidth](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbywidth/) pada sel `(1, 1)`. Setengah dari lebar 70 poin sel tersebut diberikan untuk membuat dua sel dengan lebar sama.

Setelah pemisahan ini, dua bagian dapat diakses sebagai `$table->get_Item(1, 1)` dan `$table->get_Item(2, 1)`. Grid tabel kini memiliki lima kolom: sel yang semula berada di kolom 2 dan 3 berpindah ke kolom 3 dan 4 masing‑masing. Indeks baris tetap tidak berubah. Gunakan indeks kolom yang diperbarui ini ketika mengakses sel setelah pemisahan.

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

<!-- visual-explanation:manage-cells:start -->
[![Sel 70-point yang tidak digabungkan terbagi menjadi dua sel 35-point, menambahkan kolom grid kelima dan menggeser indeks di sebelah kanannya.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*Pemecahan lebar memengaruhi sel (1, 1), menggunakan indeks berbasis nol (kolom, baris). Baris lain mempertahankan sel yang membentang kedua posisi kolom baru.*
<!-- visual-explanation:manage-cells:end -->

### **Pisah Sel yang Digabungkan berdasarkan Baris atau Kolom**

Untuk menyiapkan sel templat yang digabungkan agar dapat diisi data, gunakan [splitByRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyrowspan/) untuk memisahkan mengikuti batas baris yang ada, atau [splitByColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbycolspan/) untuk memisahkan mengikuti batas kolom.

Argumen `index` menghitung baris pada bagian atas atau kolom pada bagian kiri pemisahan; nilainya relatif terhadap wilayah yang digabungkan:

- Pemecahan baris: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/).
- Pemecahan kolom: `0 < index <` [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/).

Contoh mengasumsikan presentasi memiliki tabel sebagai shape pertama pada slide pertama, dengan `(1, 2)` dan `(1, 3)` digabung secara vertikal. Mulai dari posisi bawah, contoh menggunakan [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) dan [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) untuk menemukan asal dan memeriksa kedua rentang. `splitByRowSpan(1)` kemudian memisahkan baris 2 dan 3 untuk nama produk. Untuk gabungan dua kolom secara horizontal, gunakan `splitByColSpan(1)` sebagai gantinya.

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

Grid tabel dan indeks sel di sekitarnya tetap tidak berubah. Dapatkan sel‑sel yang dihasilkan berdasarkan koordinatnya; di sini, keduanya memiliki rentang 1 dan [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) mencetak `false`. Wilayah yang lebih besar dapat tetap sebagian digabung setelah satu pemisahan.

Teks asli dan pemformatannya tetap berada di sel atas (atau kiri); sel baru kosong tetapi mewarisi pemformatan sel seperti isi, batas, dan margin. Isi sel‑sel setelah pemisahan dan atur pemformatan teks yang diperlukan secara eksplisit.

Presentasi yang disimpan berisi sel “Product A” dan “Product B” terpisah dengan pemformatan sel templat yang dipertahankan. Lihat [Cell API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) untuk detail.

### **Pisah Sel pada Tinggi Tertentu**

[splitByHeight](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyheight/) menerima tinggi bagian atas dalam poin. [splitByRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyrowspan/) menerima jumlah baris grid yang ada pada bagian atas. Untuk memusatkan sel 40 poin di kolom kanan, kurangi 40 dari tinggi aktual sel dan bagi sisa ruang secara merata di atas dan di bawahnya.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 160, 160 ];
    $rowHeights = [ 140 ];
    
    $table = $slide->getShapes()->addTable(50, 50, $columnWidths, $rowHeights);
    $table->get_Item(0, 0)->getTextFrame()->setText("Left");

    $rightCell = $table->get_Item(1, 0);
    $height = java_values($rightCell->getHeight());
    $margin = ($height - 40) / 2;

    $rightCell->splitByHeight($margin);
    $table->get_Item(1, 1)->splitByHeight(40);
    $table->get_Item(1, 1)->getTextFrame()->setText("Middle");

    $presentation->save("split_by_height.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Pemecahan pertama menambahkan satu baris grid dan meninggalkan 90 poin di bagian bawah sel `(1, 1)`. Pemecahan kedua membagi sel tersebut menjadi sel tengah 40 poin dan sel bawah 50 poin. Kolom kanan kini memiliki tiga sel dengan tinggi 50, 40, dan 50 poin dari atas ke bawah. Sel kiri membentang ketiga baris tersebut dan mempertahankan tinggi aslinya 140 poin.

![Sel kiri membentang seluruh tinggi tabel di samping tiga sel dengan Tengah di tengah.](split-by-height.png)

## **Ubah Warna Latar Belakang Sel Tabel**

Contoh ini membuat tabel dengan kolom 150 poin dan baris 50 poin. Ia menggunakan [setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) untuk memilih isi padat dan mengatur warna yang dikembalikan oleh [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/getsolidfillcolor/) menjadi merah untuk sel `(2, 3)`, yaitu kolom ketiga dan baris keempat.

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

## **Tambahkan Gambar di Dalam Sel Tabel**

Letakkan gambar masukan di direktori kerja sebelum menjalankan contoh ini. Gambar dimuat dengan [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile) dan ditambahkan ke koleksi gambar presentasi dengan [addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/addimage/). Kemudian gambar ditetapkan sebagai picture fill sel `(0, 0)`, sel pertama dalam tabel.

[PictureFillMode::Stretch](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) meregangkan gambar agar mengisi sel, yang dapat mengubah rasio aspeknya. Lebar kolom dan tinggi baris dalam poin. Gambar yang dimuat dibuang dalam blok `finally` setelah ditambahkan ke presentasi.

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

**Apakah saya dapat mengatur ketebalan dan gaya garis yang berbeda untuk sisi yang berbeda dari satu sel?**

Ya. Garis [top](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderright/) memiliki properti terpisah, sehingga ketebalan dan gaya masing‑masing sisi dapat berbeda.

**Apa yang terjadi pada gambar jika saya mengubah ukuran kolom/baris setelah menetapkan gambar sebagai latar belakang sel?**

Perilaku tergantung pada [fill mode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) (stretch/tile). Dengan stretch, gambar menyesuaikan dengan sel baru; dengan tile, ubin‑ubin dihitung ulang.

**Apakah saya dapat menambahkan hyperlink ke seluruh konten sel?**

[Hyperlinks](/slides/id/php-java/manage-hyperlinks/) diatur pada tingkat teks (portion) di dalam text frame sel atau pada tingkat seluruh tabel/shape. Pada praktiknya, Anda menambahkan tautan ke bagian teks atau ke seluruh teks dalam sel.

**Apakah saya dapat mengatur font yang berbeda dalam satu sel?**

Ya. Text frame sel mendukung [portions](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) (run) dengan pemformatan independen—jenis font, gaya, ukuran, dan warna.