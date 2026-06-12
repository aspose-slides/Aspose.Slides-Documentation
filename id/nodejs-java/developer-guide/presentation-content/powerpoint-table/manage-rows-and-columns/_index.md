---
title: Kelola Baris dan Kolom dalam Tabel PowerPoint menggunakan JavaScript
linktitle: Baris dan Kolom
type: docs
weight: 20
url: /id/nodejs-java/manage-rows-and-columns/
keywords:
- baris tabel
- kolom tabel
- baris pertama
- header tabel
- gandakan baris
- gandakan kolom
- salin baris
- salin kolom
- hapus baris
- hapus kolom
- pemformatan teks baris
- pemformatan teks kolom
- gaya tabel
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Kelola baris dan kolom tabel dalam PowerPoint dengan JavaScript dan Aspose.Slides untuk Node.js melalui Java serta percepat penyuntingan presentasi dan pembaruan data."
---
## **Pendahuluan**

Untuk memungkinkan Anda mengelola baris dan kolom tabel dalam presentasi PowerPoint, Aspose.Slides menyediakan kelas [Table](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/table/) dan tipe lainnya.

## **Atur Baris Pertama sebagai Header**

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) dan muat presentasi.  
2. Dapatkan referensi slide melalui indeksnya.  
3. Buat objek [Table](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Table) dan setel ke null.  
4. Iterasi melalui semua objek [Shape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/) untuk menemukan tabel yang relevan.  
5. Atur baris pertama tabel sebagai header‑nya.  

Kode JavaScript berikut menunjukkan cara mengatur baris pertama tabel sebagai header:

```javascript
// Membuat instance kelas Presentation
var pres = new aspose.slides.Presentation("table.pptx");
try {
    // Mengakses slide pertama
    var sld = pres.getSlides().get_Item(0);
    // Menginisialisasi TableEx null
    var tbl = null;
    // Mengiterasi shape dan menetapkan referensi ke tabel
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (java.instanceOf(shp, "com.aspose.slides.ITable")) {
            tbl = shp;
            // Menetapkan baris pertama tabel sebagai headernya
            tbl.setFirstRow(true);
        }
    }
    // Menyimpan presentasi ke disk
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Gandakan Baris atau Kolom Tabel**

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) dan muat presentasi,  
2. Dapatkan referensi slide melalui indeksnya.  
3. Tentukan array `columnWidth`.  
4. Tentukan array `rowHeight`.  
5. Tambahkan objek [Table](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Table) ke slide melalui metode [addTable](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---).  
6. Gandakan baris tabel.  
7. Gandakan kolom tabel.  
8. Simpan presentasi yang dimodifikasi.  

Kode JavaScript berikut menunjukkan cara menggandakan baris atau kolom tabel PowerPoint:

```javascript
// Membuat instance kelas Presentation
var pres = new aspose.slides.Presentation("Test.pptx");
try {
    // Mengakses slide pertama
    var sld = pres.getSlides().get_Item(0);
    // Mendefinisikan kolom dengan lebar dan baris dengan tinggi
    var dblCols = java.newArray("double", [50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // Menambahkan shape tabel ke slide
    var table = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Menambahkan teks ke baris 1 sel 1
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");
    // Menambahkan teks ke baris 1 sel 2
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");
    // Menggandakan Baris 1 ke akhir tabel
    table.getRows().addClone(table.getRows().get_Item(0), false);
    // Menambahkan teks ke baris 2 sel 1
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");
    // Menambahkan teks ke baris 2 sel 2
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");
    // Menggandakan Baris 2 sebagai baris ke-4 tabel
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);
    // Menggandakan kolom pertama di akhir
    table.getColumns().addClone(table.getColumns().get_Item(0), false);
    // Menggandakan kolom ke-2 di indeks kolom ke-4
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);
    // Menyimpan presentasi ke disk
    pres.save("table_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Hapus Baris atau Kolom dari Tabel**

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) dan muat presentasi,  
2. Dapatkan referensi slide melalui indeksnya.  
3. Tentukan array `columnWidth`.  
4. Tentukan array `rowHeight`.  
5. Tambahkan objek [Table](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Table) ke slide melalui metode [addTable](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---).  
6. Hapus baris tabel.  
7. Hapus kolom tabel.  
8. Simpan presentasi yang dimodifikasi.  

Kode JavaScript berikut menunjukkan cara menghapus baris atau kolom dari tabel:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var colWidth = java.newArray("double", [100, 50, 30]);
    var rowHeight = java.newArray("double", [30, 50, 30]);
    var table = slide.getShapes().addTable(100, 100, colWidth, rowHeight);
    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);
    pres.save("TestTable_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Atur Pemformatan Teks pada Tingkat Baris Tabel**

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) dan muat presentasi,  
2. Dapatkan referensi slide melalui indeksnya.  
3. Akses objek [Table](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Table) yang relevan dari slide.  
4. Setel [setFontHeight(float value)](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) pada sel baris pertama.  
5. Setel [setAlignment(int value)](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) dan [setMarginRight(float value)](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) pada sel baris pertama.  
6. Setel [setTextVerticalType(byte value)](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) pada sel baris kedua.  
7. Simpan presentasi yang dimodifikasi.  

Kode JavaScript ini mendemonstrasikan operasi tersebut.

```javascript
// Membuat instance kelas Presentation
var pres = new aspose.slides.Presentation();
try {
    // Asumsikan bahwa shape pertama pada slide pertama adalah tabel
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Mengatur tinggi font sel baris pertama
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.getRows().get_Item(0).setTextFormat(portionFormat);
    // Mengatur perataan teks sel baris pertama dan margin kanan
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.getRows().get_Item(0).setTextFormat(paragraphFormat);
    // Mengatur tipe vertikal teks sel baris kedua
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(aspose.slides.TextVerticalType.Vertical);
    someTable.getRows().get_Item(1).setTextFormat(textFrameFormat);
    // Menyimpan presentasi ke disk
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Atur Pemformatan Teks pada Tingkat Kolom Tabel**

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) dan muat presentasi,  
2. Dapatkan referensi slide melalui indeksnya.  
3. Akses objek [Table](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Table) yang relevan dari slide.  
4. Setel [setFontHeight(float value)](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) pada sel kolom pertama.  
5. Setel [setAlignment(int value)](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) dan [setMarginRight(float value)](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) pada sel kolom pertama.  
6. Setel [setTextVerticalType(byte value)](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) pada sel kolom kedua.  
7. Simpan presentasi yang dimodifikasi.  

Kode JavaScript ini mendemonstrasikan operasi:

```javascript
// Membuat instance kelas Presentation
var pres = new aspose.slides.Presentation();
try {
    // Asumsikan bahwa shape pertama pada slide pertama adalah tabel
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Mengatur tinggi font sel kolom pertama
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.getColumns().get_Item(0).setTextFormat(portionFormat);
    // Mengatur perataan teks dan margin kanan sel kolom pertama dalam satu panggilan
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.getColumns().get_Item(0).setTextFormat(paragraphFormat);
    // Mengatur tipe vertikal teks sel kolom kedua
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(aspose.slides.TextVerticalType.Vertical);
    someTable.getColumns().get_Item(1).setTextFormat(textFrameFormat);
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Dapatkan Properti Gaya Tabel**

Aspose.Slides memungkinkan Anda mengambil properti gaya untuk sebuah tabel sehingga Anda dapat menggunakan detail tersebut untuk tabel lain atau di tempat lain. Kode JavaScript berikut menunjukkan cara mendapatkan properti gaya dari gaya preset tabel:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, java.newArray("double", [100, 150]), java.newArray("double", [5, 5, 5]));
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);// ganti tema preset gaya default
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Apakah saya dapat menerapkan tema/gaya PowerPoint ke tabel yang sudah dibuat?**

Ya. Tabel mewarisi tema slide/layout/master, dan Anda masih dapat menimpa isian, batas, dan warna teks di atas tema tersebut.

**Apakah saya dapat mengurutkan baris tabel seperti di Excel?**

Tidak, tabel Aspose.Slides tidak memiliki fitur penyortiran atau filter bawaan. Urutkan data Anda di memori terlebih dahulu, lalu isi kembali baris tabel dalam urutan tersebut.

**Apakah saya dapat memiliki kolom berstrip (bergaris) sambil mempertahankan warna khusus pada sel tertentu?**

Ya. Aktifkan kolom bergaris, lalu timpa sel tertentu dengan pemformatan lokal; pemformatan pada tingkat sel memiliki prioritas lebih tinggi dibandingkan gaya tabel.