---
title: Kelola Sel Tabel dalam Presentasi Menggunakan JavaScript
linktitle: Kelola Sel
type: docs
weight: 30
url: /id/nodejs-java/manage-cells/
keywords:
- sel tabel
- gabungkan sel
- hapus batas
- pisah sel
- gambar dalam sel
- warna latar belakang
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Kelola sel tabel PowerPoint dalam JavaScript: identifikasi sel yang digabung, hapus batas, pisah sel, dan atur warna latar belakang serta gambar dengan Aspose.Slides untuk Node.js via Java."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda mengakses dan memodifikasi sel tabel dalam presentasi PowerPoint. Artikel ini menjelaskan cara mengidentifikasi sel tabel yang digabung, menghapus batas sel, bekerja dengan penomoran sel setelah menggabungkan atau memisahkan sel, mengubah warna latar belakang sel, dan menambahkan gambar di dalam sel tabel. Contoh‑contoh menunjukkan cara membuat atau membuka presentasi, mendapatkan tabel dari slide, memperbarui format sel melalui properti sel, dan menyimpan presentasi yang telah dimodifikasi sebagai file PPTX.

Aspose.Slides menggunakan indeks berbasis nol untuk mengakses sel tabel dalam urutan `(kolom, baris)`.

## **Identifikasi Sel Tabel yang Digabung**

Contoh ini membuka presentasi yang ada dan mengakses bentuk pertama pada slide pertama sebagai tabel. Diasumsikan bahwa slide dan bentuk tersebut ada serta bentuknya adalah tabel. Kemudian contoh ini mengiterasi semua baris dan kolom dan menggunakan [isMergedCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/ismergedcell/) untuk mengidentifikasi sel dalam wilayah yang digabung. Untuk setiap kecocokan, contoh mencetak koordinat sel dalam urutan `baris;kolom`, [getRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getrowspan/), [getColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getcolspan/), serta koordinat mulai wilayah, [getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstrowindex/) dan [getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstcolumnindex/).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation_with_table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);

    const rowCount = table.getRows().size();
    for (let rowIndex = 0; rowIndex < rowCount; rowIndex++) {
        const columnCount = table.getColumns().size();
        for (let columnIndex = 0; columnIndex < columnCount; columnIndex++) {
            const cell = table.get_Item(columnIndex, rowIndex);
            if (cell.isMergedCell()) {
                console.log("Cell %d;%d belongs to a merged region with RowSpan=%d and ColSpan=%d starting at %d;%d.", rowIndex, columnIndex, cell.getRowSpan(), cell.getColSpan(), cell.getFirstRowIndex(), cell.getFirstColumnIndex());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Hapus Garis Batas Sel Tabel**

Buat sebuah [Presentasi](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) dan tambahkan tabel ke slide pertama dengan [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addtable/). Lebar kolom, tinggi baris, dan posisi tabel ditentukan dalam poin. Contoh ini menetapkan semua empat batas sel ke [FillType.NoFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/), sehingga menjadi tidak terlihat.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [50, 50, 50, 50]);
    const rowHeights = java.newArray("double", [50, 30, 30, 30, 30]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (let rowIndex = 0; rowIndex < table.getRows().size(); rowIndex++) {
        const row = table.getRows().get_Item(rowIndex);
        for (let columnIndex = 0; columnIndex < row.size(); columnIndex++) {
            const cell = row.get_Item(columnIndex);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        }
    }

    presentation.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Gabungkan Sel Tabel**

Gunakan [mergeCells](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/mergecells/) untuk menggabungkan rentang persegi panjang sel tabel menjadi satu sel. Tentukan sel pada sudut kiri‑atas dan kanan‑bawah rentang. Argumen terakhir mengontrol apakah penggabungan dapat mencakup sel di luar rentang yang ditentukan; `false` menjaga penggabungan tetap dalam rentang tersebut.

Contoh ini membuat tabel 4×4 dengan kolom dan baris 70 poin, kemudian menggabungkan empat sel tengah dari `(1, 1)` hingga `(2, 2)`. Sel yang dihasilkan mencakup dua kolom dan dua baris, sementara grid tabel tetap memiliki empat kolom dan empat baris. Untuk mengakses konten atau format sel yang digabung, gunakan posisi kiri‑atasnya: `table.get_Item(1, 1)` dalam contoh ini. Posisi lain dalam rentang yang digabung tetap menjadi bagian dari grid tabel, sehingga indeks sel di luar rentang tidak berubah.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [70, 70, 70, 70]);
    const rowHeights = java.newArray("double", [70, 70, 70, 70]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 2), false);

    presentation.save("merged_cells.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Pisahkan Sel Tabel**

Menggabungkan sel pada contoh sebelumnya mempertahankan grid tabel. Memisahkan sel dapat menambahkan kolom grid baru dan mengubah indeks kolom sel di sebelah kanannya. Aspose.Slides mengikuti model grid tabel PowerPoint.

Contoh ini membuat tabel 4×4 dengan kolom dan baris 70 poin dan memanggil [splitByWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbywidth/) pada sel `(1, 1)`. Setengah lebar 70 poin sel tersebut diberikan untuk membuat dua sel dengan lebar yang sama.

Setelah pemisahan ini, kedua bagian diakses sebagai `table.get_Item(1, 1)` dan `table.get_Item(2, 1)`. Grid tabel kini memiliki lima kolom: sel yang semula berada di kolom 2 dan 3 berpindah ke kolom 3 dan 4 masing‑masing. Indeks baris tetap tidak berubah. Gunakan indeks kolom yang telah diperbarui ini saat mengakses sel setelah pemisahan.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [70, 70, 70, 70]);
    const rowHeights = java.newArray("double", [70, 70, 70, 70]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 1).splitByWidth(table.get_Item(1, 1).getWidth() / 2);

    presentation.save("split_cells.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Pisahkan Sel yang Digabung berdasarkan Rentang Baris atau Kolom**

Untuk menyiapkan sel template yang digabung agar dapat diisi data, gunakan [splitByRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbyrowspan/) untuk memisahkan sepanjang batas baris yang ada, atau [splitByColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbycolspan/) untuk memisahkan sepanjang batas kolom.

Argumen `index` menghitung baris di bagian atas atau kolom di bagian kiri pemisahan; nilainya relatif terhadap wilayah yang digabung:

- Pemisahan baris: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getrowspan/).
- Pemisahan kolom: `0 < index <` [getColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getcolspan/).

Contoh ini mengasumsikan sebuah presentasi memiliki tabel sebagai bentuk pertama pada slide pertama, dengan sel `(1, 2)` dan `(1, 3)` digabung secara vertikal. Memulai dari posisi bawah, contoh ini menggunakan [getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstcolumnindex/) dan [getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstrowindex/) untuk menemukan asal dan memeriksa kedua rentang. `splitByRowSpan(1)` kemudian memisahkan baris 2 dan 3 untuk nama produk. Untuk penggabungan dua kolom secara horizontal, gunakan `splitByColSpan(1)` sebagai gantinya.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("table_template.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);

    const selectedCell = table.get_Item(1, 3);
    const firstColumnIndex = selectedCell.getFirstColumnIndex();
    const firstRowIndex = selectedCell.getFirstRowIndex();
    const mergedCell = table.get_Item(firstColumnIndex, firstRowIndex);

    if (mergedCell.isMergedCell() && mergedCell.getRowSpan() == 2 && mergedCell.getColSpan() == 1) {
        mergedCell.splitByRowSpan(1);

        // Ambil sel hasil dari tabel setelah pemisahan.
        const upperCell = table.get_Item(firstColumnIndex, firstRowIndex);
        const lowerCell = table.get_Item(firstColumnIndex, firstRowIndex + 1);
        console.log("Upper cell merged: " + upperCell.isMergedCell());
        console.log("Lower cell merged: " + lowerCell.isMergedCell());

        upperCell.getTextFrame().setText("Product A");
        lowerCell.getTextFrame().setText("Product B");

        presentation.save("split_template.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("Select a merged region spanning exactly two rows and one column.");
    }
} finally {
    presentation.dispose();
}
```

Grid tabel dan indeks sel di sekitarnya tetap tidak berubah. Ambil sel‑sel yang dihasilkan dengan koordinatnya; di sini, keduanya memiliki rentang 1 dan [isMergedCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/ismergedcell/) mencetak `false`. Wilayah yang lebih besar dapat tetap sebagian digabung setelah satu pemisahan.

Teks asli dan formatnya tetap berada di sel atas (atau kiri); sel baru kosong tetapi mewarisi format sel seperti isian, batas, dan margin. Isi sel setelah pemisahan dan tetapkan format teks yang diperlukan secara eksplisit.

Presentasi yang disimpan berisi sel “Product A” dan “Product B” terpisah dengan format sel template tetap dipertahankan. Lihat [Cell API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) untuk detail lebih lanjut.

## **Ubah Warna Latar Belakang Sel Tabel**

Contoh ini membuat tabel dengan kolom 150 poin dan baris 50 poin. Ia menggunakan [setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/) untuk memilih isian padat dan menetapkan warna yang dikembalikan oleh [getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/getsolidfillcolor/) menjadi merah untuk sel `(2, 3)`, pada kolom ketiga dan baris keempat.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [150, 150, 150, 150]);
    const rowHeights = java.newArray("double", [50, 50, 50, 50, 50]);
    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    const cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));

    presentation.save("cell_background_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tambahkan Gambar di dalam Sel Tabel**

Letakkan gambar input di direktori kerja sebelum menjalankan contoh ini. Gambar dimuat dengan [Images.fromFile](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Images#fromFile) dan ditambahkan ke koleksi gambar presentasi dengan [addImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/addimage/). Kemudian gambar tersebut ditetapkan ke isian gambar sel `(0, 0)`, sel pertama dalam tabel.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/) memperluas gambar untuk mengisi sel, yang dapat mengubah rasio aspeknya. Lebar kolom dan tinggi baris dinyatakan dalam poin. Gambar yang dimuat dibuang dalam blok `finally` setelah ditambahkan ke presentasi.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [150, 150, 150, 150]);
    const rowHeights = java.newArray("double", [100, 100, 100, 100, 90]);
    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    let ppImage;
    const image = aspose.slides.Images.fromFile("aspose_logo.jpg");
    try {
        ppImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    table.get_Item(0, 0).getCellFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);

    presentation.save("table_cell_with_image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tanya Jawab**

**Apakah saya dapat mengatur ketebalan dan gaya garis yang berbeda untuk sisi yang berbeda dari satu sel?**

Ya. Batas [top](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderright/) memiliki properti terpisah, sehingga ketebalan dan gaya masing‑masing sisi dapat berbeda.

**Apa yang terjadi pada gambar jika saya mengubah ukuran kolom/baris setelah menetapkan gambar sebagai latar belakang sel?**

Perilaku tergantung pada [fill mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/) (stretch/tile). Dengan stretch, gambar menyesuaikan dengan sel baru; dengan tile, ubin‑ubin dihitung ulang.

**Apakah saya dapat menambahkan hyperlink ke seluruh konten sel?**

[Hyperlinks](/slides/id/nodejs-java/manage-hyperlinks/) diatur pada tingkat teks (bagian) di dalam bingkai teks sel atau pada tingkat seluruh tabel/bentuk. Pada praktiknya, Anda menambahkan tautan ke bagian atau ke seluruh teks dalam sel.

**Apakah saya dapat mengatur font yang berbeda dalam satu sel?**

Ya. Bingkai teks sel mendukung [portions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) (run) dengan format independen—jenis font, gaya, ukuran, dan warna.