---
title: Kelola Tabel Presentasi dengan JavaScript
linktitle: Kelola Tabel
type: docs
weight: 10
url: /id/nodejs-java/manage-table/
keywords:
- menambah tabel
- membuat tabel
- mengakses tabel
- rasio aspek
- meratakan teks
- format teks
- gaya tabel
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Buat & edit tabel dalam slide PowerPoint dengan JavaScript dan Aspose.Slides untuk Node.js. Temukan contoh kode sederhana untuk menyederhanakan alur kerja tabel Anda."
---
## **Pendahuluan**

Tabel di PowerPoint adalah cara yang efisien untuk menampilkan dan menggambarkan informasi. Informasi dalam kisi sel (diatur dalam baris dan kolom) sederhana dan mudah dipahami.

Aspose.Slides menyediakan kelas [Table](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Table) , kelas [Cell](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/cell/) , dan tipe lainnya untuk memungkinkan Anda membuat, memperbarui, dan mengelola tabel dalam semua jenis presentasi.

## **Buat Tabel dari Awal**

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
2. Dapatkan referensi slide melalui indeksnya. 
3. Tentukan array `columnWidth`.
4. Tentukan array `rowHeight`.
5. Tambahkan objek [Table](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Table) ke slide melalui metode [addTable](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-).
6. Iterasi setiap [Cell](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/cell/) untuk menerapkan format pada batas atas, bawah, kanan, dan kiri.
7. Gabungkan empat sel di sudut kiri atas tabel (dua kolom pertama dari dua baris pertama) menjadi satu sel. 
8. Akses [TextFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/) dari sebuah [Cell](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/cell/).
9. Tambahkan beberapa teks ke [TextFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/).
10. Simpan presentasi yang telah dimodifikasi.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Membuat instance kelas Presentation yang mewakili file PPTX
var pres = new aspose.slides.Presentation();
try {
    // Mengakses slide pertama
    var sld = pres.getSlides().get_Item(0);
    // Mendefinisikan kolom dengan lebar dan baris dengan tinggi
    var dblCols = java.newArray("double", [50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // Menambahkan shape tabel ke slide
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Mengatur format border untuk setiap sel
    for (var row = 0; row < tbl.getRows().size(); row++) {
        for (var cell = 0; cell < tbl.getRows().get_Item(row).size(); cell++) {
            var cellFormat = tbl.getRows().get_Item(row).get_Item(cell).getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderTop().setWidth(5);
            cellFormat.getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderBottom().setWidth(5);
            cellFormat.getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderLeft().setWidth(5);
            cellFormat.getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderRight().setWidth(5);
        }
    }
    // Menggabungkan blok sel 2x2 di kiri atas menjadi satu sel
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(1).get_Item(1), false);
    // Menambahkan beberapa teks ke sel yang digabungkan
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");
    // Menyimpan presentasi ke Disk
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Penomoran dalam Tabel Standar**

Pada tabel standar, penomoran sel sederhana dan berbasis nol. Sel pertama dalam tabel diindeks sebagai 0,0 (kolom 0, baris 0). 

Sebagai contoh, sel-sel dalam tabel dengan 4 kolom dan 4 baris diberi nomor seperti ini:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Kode JavaScript ini menunjukkan cara menentukan penomoran untuk sel dalam tabel:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Membuat instance kelas Presentation yang mewakili file PPTX
var pres = new aspose.slides.Presentation();
try {
    // Mengakses slide pertama
    var sld = pres.getSlides().get_Item(0);
    // Mendefinisikan kolom dengan lebar dan baris dengan tinggi
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // Menambahkan shape tabel ke slide
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Mengatur format border untuk setiap sel
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
    // Menyimpan presentasi ke disk
    pres.save("StandardTables_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Akses Tabel yang Ada**

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
2. Dapatkan referensi ke slide yang berisi tabel melalui indeksnya. 
3. Buat objek [Table](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Table) dan set ke null.
4. Iterasi semua objek [Shape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/) hingga tabel ditemukan.

   Jika Anda menduga slide yang Anda tangani berisi satu tabel, Anda dapat memeriksa semua shape yang ada. Ketika sebuah shape diidentifikasi sebagai tabel, Anda dapat melakukan typecast menjadi objek [Table](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Table). Namun jika slide yang Anda tangani berisi beberapa tabel, lebih baik mencari tabel yang Anda perlukan melalui [setAlternativeText(String value)](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/#setAlternativeText-java.lang.String-).

5. Gunakan objek [Table](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Table) untuk bekerja dengan tabel. Pada contoh di bawah, kami menetapkan teks pada sebuah sel dalam tabel.
6. Simpan presentasi yang telah dimodifikasi.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Membuat instance kelas Presentation yang mewakili file PPTX
var pres = new aspose.slides.Presentation("UpdateExistingTable.pptx");
try {
    // Mengakses slide pertama
    var sld = pres.getSlides().get_Item(0);
    // Menginisialisasi TableEx null
    var tbl = null;
    // Mengiterasi shape dan menetapkan referensi ke tabel yang ditemukan
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (java.instanceOf(shp, "com.aspose.slides.ITable")) {
            tbl = shp;
            // Mengatur teks untuk kolom pertama baris kedua
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    // Menyimpan presentasi yang telah dimodifikasi ke disk
    pres.save("table1_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Temukan Sel yang Memiliki Text Frame**

Ketika kode pemrosesan teks umum menerima [TextFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/) dari sebuah tabel, gunakan metode [TextFrame.getParentCell](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/#getParentCell--) untuk mendapatkan [Cell](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/cell/) pemilik. Untuk text frame sel tabel, [TextFrame.getParentCell](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/#getParentCell--) mengembalikan pemilik dan [TextFrame.getParentShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/#getParentShape--) mengembalikan `null`, meskipun tabel itu sendiri merupakan shape.

Koordinat sel tersedia melalui metode read-only [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/cell/#getFirstColumnIndex--) dan [Cell.getFirstRowIndex](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/cell/#getFirstRowIndex--). [TextFrame.getParentCell](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/#getParentCell--) juga menyediakan navigasi read-only: ia mengembalikan pemilik tetapi tidak mengubah kepemilikan. Selalu periksa apakah sel yang dikembalikan `null` sebelum menggunakannya.

Untuk contoh lengkap yang mengidentifikasi pemilik sel-tabel dan shape, termasuk shape yang terkait dengan node SmartArt, lihat [Search and Replace Text](/slides/id/nodejs-java/search-and-replace-text/).

## **Ratakan Teks dalam Tabel**

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
2. Dapatkan referensi slide melalui indeksnya. 
3. Tambahkan objek [Table](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Table) ke slide.
4. Akses objek [TextFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/) dari tabel.
5. Akses [Paragraph](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraph/) dari [TextFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/).
6. Ratakan teks secara vertikal.
7. Simpan presentasi yang telah dimodifikasi.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Membuat instance kelas Presentation
var pres = new aspose.slides.Presentation();
try {
    // Mendapatkan slide pertama
    var slide = pres.getSlides().get_Item(0);
    // Mendefinisikan kolom dengan lebar dan baris dengan tinggi
    var dblCols = java.newArray("double", [120, 120, 120, 120]);
    var dblRows = java.newArray("double", [100, 100, 100, 100]);
    // Menambahkan shape tabel ke slide
    var tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    // Mengakses text frame
    var txtFrame = tbl.get_Item(0, 0).getTextFrame();
    // Membuat objek Paragraph untuk text frame
    var paragraph = txtFrame.getParagraphs().get_Item(0);
    // Membuat objek Portion untuk paragraf
    var portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Meratakan teks secara vertikal
    var cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(java.newByte(aspose.slides.TextAnchorType.Center));
    cell.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));
    // Menyimpan presentasi ke disk
    pres.save("Vertical_Align_Text_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Set Format Teks pada Tingkat Tabel**

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
2. Dapatkan referensi slide melalui indeksnya. 
3. Akses objek [Table](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Table) dari Slide.
4. Setel [setFontHeight(float value)](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) untuk teks.
5. Setel [setAlignment(int value)](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) dan [setMarginRight(float value)](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-).
6. Setel [setTextVerticalType(byte value)](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Simpan presentasi yang telah dimodifikasi. 

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Membuat instance kelas Presentation
var pres = new aspose.slides.Presentation("simpletable.pptx");
try {
    // Misalkan shape pertama pada slide pertama adalah tabel
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Mengatur tinggi font sel tabel
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    // Mengatur perataan teks sel tabel dan margin kanan sekaligus
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    // Mengatur tipe vertikal teks sel tabel
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical));
    someTable.setTextFormat(textFrameFormat);
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Set Preset Gaya Tabel**

Aspose.Slides menyediakan gaya tabel PowerPoint bawaan sebagai enumerasi [TableStylePreset](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/tablestylepreset/), sehingga Anda dapat menerapkan tampilan yang sama ke tabel mana pun. Kode JavaScript ini menunjukkan cara mengganti gaya default tabel dengan gaya preset:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var pres = new aspose.slides.Presentation();
try {
    var table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, java.newArray("double", [100, 150]), java.newArray("double", [5, 5, 5]));
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);// ubah tema preset gaya default
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Kunci Rasio Aspek Tabel**

Rasio aspek sebuah bentuk geometris adalah perbandingan ukurannya dalam dimensi yang berbeda. Aspose.Slides menyediakan properti [**setAspectRatioLocked**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) untuk memungkinkan Anda mengunci pengaturan rasio aspek untuk tabel dan bentuk lainnya.

Kode JavaScript ini menunjukkan cara mengunci rasio aspek untuk sebuah tabel:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var table = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());
    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked());// balikkan
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Apakah saya dapat mengaktifkan arah baca kanan-ke-kiri (RTL) untuk seluruh tabel dan teks di selnya?**

Ya. Tabel menyediakan metode [setRightToLeft](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/table/setrighttoleft/), dan paragraf memiliki [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraphformat/setrighttoleft/). Menggunakan keduanya memastikan urutan RTL yang tepat dan render yang benar di dalam sel.

**Bagaimana saya dapat mencegah pengguna memindahkan atau mengubah ukuran tabel dalam file akhir?**

Gunakan kunci shape untuk menonaktifkan pemindahan, pengubahan ukuran, pemilihan, dll. Kunci ini juga berlaku untuk tabel.

**Apakah memasukkan gambar di dalam sel sebagai latar belakang didukung?**

Ya. Anda dapat mengatur [picture fill](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/picturefillformat/) untuk sebuah sel; gambar akan menutupi area sel sesuai mode yang dipilih (stretch atau tile).