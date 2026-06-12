---
title: Kelola Sel Tabel dalam Presentasi Menggunakan JavaScript
linktitle: Kelola Sel
type: docs
weight: 30
url: /id/nodejs-java/manage-cells/
keywords:
- sel tabel
- menggabungkan sel
- menghapus batas
- memisahkan sel
- gambar dalam sel
- warna latar belakang
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Kelola sel tabel di PowerPoint dengan Aspose.Slides untuk Node.js. Kuasai cara mengakses, memodifikasi, dan menata sel dengan cepat untuk otomatisasi slide yang mulus."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda mengakses dan memodifikasi sel tabel dalam presentasi PowerPoint. Artikel ini menjelaskan cara mengidentifikasi sel tabel yang digabungkan, menghapus batas sel, bekerja dengan penomoran sel setelah menggabungkan atau memisahkan sel, mengubah warna latar belakang sel, dan menambahkan gambar di dalam sel tabel. Contoh-contohnya menunjukkan cara membuat atau membuka presentasi, mendapatkan tabel dari slide, memperbarui format sel melalui properti sel, dan menyimpan presentasi yang dimodifikasi sebagai file PPTX.

## **Mengidentifikasi Sel Tabel yang Digabungkan**
1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
2. Dapatkan tabel dari slide pertama.
3. Iterasi melalui baris dan kolom tabel untuk menemukan sel yang digabungkan.
4. Cetak pesan ketika sel yang digabungkan ditemukan.

Kode JavaScript ini menunjukkan cara mengidentifikasi sel tabel yang digabungkan dalam sebuah presentasi:

```javascript
var pres = new aspose.slides.Presentation("SomePresentationWithTable.pptx");
try {
    var table = pres.getSlides().get_Item(0).getShapes().get_Item(0);// mengasumsikan bahwa Slide#0.Shape#0 adalah tabel
    for (var i = 0; i < table.getRows().size(); i++) {
        for (var j = 0; j < table.getColumns().size(); j++) {
            var currentCell = table.getRows().get_Item(i).get_Item(j);
            if (currentCell.isMergedCell()) {
                console.log(java.callStaticMethodSync("java.lang.String", "format", "Cell %d;%d is a part of merged cell with RowSpan=%d and ColSpan=%d starting from Cell %d;%d.", i, j, currentCell.getRowSpan(), currentCell.getColSpan(), currentCell.getFirstRowIndex(), currentCell.getFirstColumnIndex()));
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Menghapus Batas Sel Tabel**
1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
2. Dapatkan referensi slide melalui indeksnya.
3. Definisikan array kolom dengan lebar.
4. Definisikan array baris dengan tinggi.
5. Tambahkan tabel ke slide melalui metode [addTable](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-).
6. Iterasi melalui setiap sel untuk menghapus batas atas, bawah, kanan, dan kiri.
7. Simpan presentasi yang dimodifikasi sebagai file PPTX.

Kode JavaScript ini menunjukkan cara menghapus batas dari sel tabel:

```javascript
// Membuat instance kelas Presentation yang mewakili file PPTX
var pres = new aspose.slides.Presentation();
try {
    // Mengakses slide pertama
    var sld = pres.getSlides().get_Item(0);
    // Mendefinisikan kolom dengan lebar dan baris dengan tinggi
    var dblCols = java.newArray("double", [50, 50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // Menambahkan bentuk tabel ke slide
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Mengatur format batas untuk setiap sel
    for (let i = 0; i < tbl.getRows().size(); i++) {
        const row = tbl.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        }
    }
    // Menulis PPTX ke disk
    pres.save("table_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Penomoran dalam Sel yang Digabungkan**

Jika kita menggabungkan 2 pasangan sel (1, 1) x (2, 1) dan (1, 2) x (2, 2), tabel yang dihasilkan akan bernomor. Kode JavaScript ini menunjukkan prosesnya:

```javascript
// Membuat instance kelas Presentation yang mewakili file PPTX
var pres = new aspose.slides.Presentation();
try {
    // Mengakses slide pertama
    var sld = pres.getSlides().get_Item(0);
    // Mendefinisikan kolom dengan lebar dan baris dengan tinggi
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // Menambahkan bentuk tabel ke slide
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Mengatur format batas untuk setiap sel
    for (let i = 0; i < tbl.getRows().size(); i++) {
        const row = tbl.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderTop().setWidth(5);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderBottom().setWidth(5);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderLeft().setWidth(5);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }
    // Menggabungkan sel (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);
    // Menggabungkan sel (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);
    pres.save("MergeCells_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Kemudian kami menggabungkan sel lebih lanjut dengan menggabungkan (1, 1) dan (1, 2). Hasilnya adalah tabel yang berisi sel besar yang digabungkan di tengahnya:

```javascript
// Membuat instance kelas Presentation yang mewakili file PPTX
var pres = new aspose.slides.Presentation();
try {
    // Mengakses slide pertama
    var sld = pres.getSlides().get_Item(0);
    // Mendefinisikan kolom dengan lebar dan baris dengan tinggi
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // Menambahkan bentuk tabel ke slide
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Mengatur format batas untuk setiap sel
    for (let i = 0; i < tbl.getRows().size(); i++) {
        const row = tbl.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderTop().setWidth(5);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderBottom().setWidth(5);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderLeft().setWidth(5);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }
    // Menggabungkan sel (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);
    // Menggabungkan sel (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);
    // Menggabungkan sel (1, 1) x (1, 2)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(1, 2), true);
    // Menulis file PPTX ke disk
    pres.save("MergeCells_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Penomoran dalam Sel yang Dipisah**

Pada contoh sebelumnya, ketika sel tabel digabungkan, sistem penomoran pada sel lain tidak berubah.

Kali ini, kami mengambil tabel biasa (tabel tanpa sel yang digabungkan) dan kemudian mencoba memisahkan sel (1,1) untuk mendapatkan tabel khusus. Anda mungkin ingin memperhatikan penomoran tabel ini, yang mungkin terasa aneh. Namun, itulah cara Microsoft PowerPoint menomori sel tabel dan Aspose.Slides melakukan hal yang sama.

Kode JavaScript ini menunjukkan proses yang kami jelaskan:

```javascript
// Membuat instance kelas Presentation yang mewakili file PPTX
var pres = new aspose.slides.Presentation();
try {
    // Mengakses slide pertama
    var sld = pres.getSlides().get_Item(0);
    // Mendefinisikan kolom dengan lebar dan baris dengan tinggi
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // Menambahkan bentuk tabel ke slide
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Mengatur format batas untuk setiap sel
    for (let i = 0; i < tbl.getRows().size(); i++) {
        const row = tbl.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderTop().setWidth(5);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderBottom().setWidth(5);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderLeft().setWidth(5);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }
    // Menggabungkan sel (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);
    // Menggabungkan sel (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);
    // Memisahkan sel (1, 1)
    tbl.get_Item(1, 1).splitByWidth(tbl.get_Item(2, 1).getWidth() / 2);
    // Menulis file PPTX ke disk
    pres.save("SplitCells_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Mengubah Warna Latar Belakang Sel Tabel**

Kode JavaScript ini menunjukkan cara mengubah warna latar belakang sel tabel:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    var dblCols = java.newArray("double", [150, 150, 150, 150]);
    var dblRows = java.newArray("double", [50, 50, 50, 50, 50]);
    // buat tabel baru
    var table = slide.getShapes().addTable(50, 50, dblCols, dblRows);
    // atur warna latar belakang untuk sel
    var cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    presentation.save("cell_background_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Menambahkan Gambar di Dalam Sel Tabel**
1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
2. Dapatkan referensi slide melalui indeksnya.
3. Definisikan array kolom dengan lebar.
4. Definisikan array baris dengan tinggi.
5. Tambahkan tabel ke slide melalui metode [addTable](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-).
6. Buat objek `Images` untuk menampung file gambar.
7. Tambahkan gambar `IImage` ke objek `PPImage`.
8. Setel `FillFormat` untuk Sel Tabel ke `Picture`.
9. Tambahkan gambar ke sel pertama tabel.
10. Simpan presentasi yang dimodifikasi sebagai file PPTX

Kode JavaScript ini menunjukkan cara menempatkan gambar di dalam sel tabel saat membuat tabel:

```javascript
// Membuat instance kelas Presentation yang mewakili file PPTX
var pres = new aspose.slides.Presentation();
try {
    // Mengakses slide pertama
    var islide = pres.getSlides().get_Item(0);
    // Mendefinisikan kolom dengan lebar dan baris dengan tinggi
    var dblCols = java.newArray("double", [150, 150, 150, 150]);
    var dblRows = java.newArray("double", [100, 100, 100, 100, 90]);
    // Menambahkan bentuk tabel ke slide
    var tbl = islide.getShapes().addTable(50, 50, dblCols, dblRows);
    // Membuat objek PPImage menggunakan file gambar
    var picture;
    var image = aspose.slides.Images.fromFile("image.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Menambahkan gambar ke sel tabel pertama
    var cellFormat = tbl.get_Item(0, 0).getCellFormat();
    cellFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    cellFormat.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    cellFormat.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);
    // Menyimpan file PPTX ke disk
    pres.save("Image_In_TableCell_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Bisakah saya mengatur ketebalan garis dan gaya yang berbeda untuk setiap sisi sel tunggal?**

Ya. Batas [top](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/cellformat/getborderright/) memiliki properti terpisah, sehingga ketebalan dan gaya setiap sisi dapat berbeda. Hal ini logis mengikuti kontrol batas per sisi untuk sel yang ditunjukkan dalam artikel.

**Apa yang terjadi pada gambar jika saya mengubah ukuran kolom/baris setelah menetapkan gambar sebagai latar belakang sel?**

Perilakunya tergantung pada [fill mode](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/picturefillmode/) (stretch/tile). Dengan stretch, gambar menyesuaikan diri dengan sel yang baru; dengan tile, ubin dihitung ulang. Artikel ini menyebutkan mode tampilan gambar di dalam sel.

**Bisakah saya menetapkan hyperlink ke seluruh konten sel?**

[Hyperlinks](/slides/id/nodejs-java/manage-hyperlinks/) diatur pada tingkat teks (portion) di dalam bingkai teks sel atau pada tingkat seluruh tabel/bentuk. Pada praktiknya, Anda menetapkan tautan ke bagian teks atau ke seluruh teks dalam sel.

**Bisakah saya mengatur font yang berbeda dalam satu sel?**

Ya. Bingkai teks sel mendukung [portions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/portion/) (run) dengan pemformatan independen—jenis font, gaya, ukuran, dan warna.