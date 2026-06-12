---
title: Kelola Baris dan Kolom dalam Tabel PowerPoint di Android
linktitle: Baris dan Kolom
type: docs
weight: 20
url: /id/androidjava/manage-rows-and-columns/
keywords:
- baris tabel
- kolom tabel
- baris pertama
- header tabel
- duplikat baris
- duplikat kolom
- salin baris
- salin kolom
- hapus baris
- hapus kolom
- pemformatan teks baris
- pemformatan teks kolom
- gaya tabel
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Kelola baris dan kolom tabel dalam PowerPoint dengan Aspose.Slides untuk Android melalui Java dan percepat penyuntingan presentasi serta pembaruan data."
---
## **Pendahuluan**

Untuk memungkinkan Anda mengelola baris dan kolom tabel dalam presentasi PowerPoint, Aspose.Slides menyediakan kelas [Table](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/table/), antarmuka [ITable](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ITable), dan banyak tipe lainnya.

## **Atur Baris Pertama sebagai Header**

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/) dan muat presentasi.  
2. Dapatkan referensi slide melalui indeksnya.  
3. Buat objek [ITable](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ITable) dan atur menjadi null.  
4. Iterasi semua objek [IShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/) untuk menemukan tabel yang relevan.  
5. Atur baris pertama tabel sebagai header.  

Kode Java ini menunjukkan cara mengatur baris pertama tabel sebagai header:

```java
// Menginstansiasi kelas Presentation
Presentation pres = new Presentation("table.pptx");
try {
    // Mengakses slide pertama
    ISlide sld = pres.getSlides().get_Item(0);

    // Menginisialisasi TableEx yang null
    ITable tbl = null;

    // Mengiterasi shape-shape dan menetapkan referensi ke tabel
    for (IShape shp : sld.getShapes())
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable)shp;
            
            //Setel baris pertama tabel sebagai headernya
            tbl.setFirstRow(true);
        }
    }
    
    // Menyimpan presentasi ke disk
    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Duplikasi Baris atau Kolom Tabel**

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/) dan muat presentasi,  
2. Dapatkan referensi slide melalui indeksnya.  
3. Definisikan array `columnWidth`.  
4. Definisikan array `rowHeight`.  
5. Tambahkan objek [ITable](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ITable) ke slide melalui metode [addTable](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---).  
6. Duplikat baris tabel.  
7. Duplikat kolom tabel.  
8. Simpan presentasi yang telah dimodifikasi.  

Kode Java ini menunjukkan cara menduplikasi baris atau kolom tabel PowerPoint:

```java
 // Menginstansiasi kelas Presentation
Presentation pres = new Presentation("Test.pptx");
try {
    // Mengakses slide pertama
    ISlide sld = pres.getSlides().get_Item(0);

    // Mendefinisikan kolom dengan lebar dan baris dengan tinggi
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Menambahkan bentuk tabel ke slide
    ITable table = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Menambahkan teks ke baris 1 sel 1
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");

    // Menambahkan teks ke baris 1 sel 2
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");

    // Menduplikasi Baris 1 di akhir tabel
    table.getRows().addClone(table.getRows().get_Item(0), false);

    // Menambahkan teks ke baris 2 sel 1
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");

    // Menambahkan teks ke baris 2 sel 2
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");

    // Menduplikasi Baris 2 sebagai baris ke-4 tabel
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    // Menduplikasi kolom pertama di akhir
    table.getColumns().addClone(table.getColumns().get_Item(0), false);

    // Menduplikasi kolom ke-2 pada indeks kolom ke-4
    table.getColumns().insertClone(3,table.getColumns().get_Item(1), false);
    
    // Menyimpan presentasi ke disk
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Hapus Baris atau Kolom dari Tabel**

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/) dan muat presentasi,  
2. Dapatkan referensi slide melalui indeksnya.  
3. Definisikan array `columnWidth`.  
4. Definisikan array `rowHeight`.  
5. Tambahkan objek [ITable](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ITable) ke slide melalui metode [addTable](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---).  
6. Hapus baris tabel.  
7. Hapus kolom tabel.  
8. Simpan presentasi yang telah dimodifikasi.  

Kode Java ini menunjukkan cara menghapus baris atau kolom dari tabel:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    double[] colWidth = { 100, 50, 30 };
    double[] rowHeight = { 30, 50, 30 };

    ITable table = slide.getShapes().addTable(100, 100, colWidth, rowHeight);
    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);
    
    pres.save("TestTable_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Atur Pemformatan Teks pada Tingkat Baris Tabel**

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/) dan muat presentasi,  
2. Dapatkan referensi slide melalui indeksnya.  
3. Akses objek [ITable](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ITable) yang relevan dari slide.  
4. Atur sel baris pertama dengan [setFontHeight(float value)](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-).  
5. Atur sel baris pertama dengan [setAlignment(int value)](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) dan [setMarginRight(float value)](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-).  
6. Atur sel baris kedua dengan [setTextVerticalType(byte value)](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).  
7. Simpan presentasi yang telah dimodifikasi.  

Kode Java ini mendemonstrasikan operasi tersebut.

```java
// Membuat instance dari kelas Presentation
Presentation pres = new Presentation();
try {
    // Misalkan shape pertama pada slide pertama adalah tabel
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0); 
    
    // Mengatur tinggi font sel baris pertama
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getRows().get_Item(0).setTextFormat(portionFormat);
    
    // Mengatur perataan teks dan margin kanan sel baris pertama
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getRows().get_Item(0).setTextFormat(paragraphFormat);
    
    // Mengatur tipe vertikal teks sel baris kedua
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getRows().get_Item(1).setTextFormat(textFrameFormat);

  // Menyimpan presentasi ke disk
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Atur Pemformatan Teks pada Tingkat Kolom Tabel**

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/) dan muat presentasi,  
2. Dapatkan referensi slide melalui indeksnya.  
3. Akses objek [ITable](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ITable) yang relevan dari slide.  
4. Atur sel kolom pertama dengan [setFontHeight(float value)](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-).  
5. Atur sel kolom pertama dengan [setAlignment(int value)](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) dan [setMarginRight(float value)](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-).  
6. Atur sel kolom kedua dengan [setTextVerticalType(byte value)](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).  
7. Simpan presentasi yang telah dimodifikasi.  

Kode Java ini mendemonstrasikan operasi tersebut:

```java
// Membuat instance dari kelas Presentation
Presentation pres = new Presentation();
try {
    // Misalkan shape pertama pada slide pertama adalah tabel
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0)];

    // Mengatur tinggi font sel kolom pertama
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getColumns().get_Item(0).setTextFormat(portionFormat);

    // Mengatur perataan teks dan margin kanan sel kolom pertama dalam satu panggilan
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
	
    someTable.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    // Mengatur tipe vertikal teks sel kolom kedua
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
	
    someTable.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Dapatkan Properti Gaya Tabel**

Aspose.Slides memungkinkan Anda mengambil properti gaya untuk sebuah tabel sehingga Anda dapat menggunakan detail tersebut pada tabel lain atau di tempat lain. Kode Java ini menunjukkan cara mendapatkan properti gaya dari gaya preset tabel:

```java
Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // ubah tema preset gaya default
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Apakah saya dapat menerapkan tema/gaya PowerPoint ke tabel yang sudah dibuat?**

Ya. Tabel mewarisi tema slide/layout/master, dan Anda tetap dapat menimpa isian, border, serta warna teks di atas tema tersebut.

**Apakah saya dapat mengurutkan baris tabel seperti di Excel?**

Tidak, tabel Aspose.Slides tidak memiliki penyortiran atau filter bawaan. Urutkan data di memori terlebih dahulu, lalu isi kembali baris tabel sesuai urutan tersebut.

**Apakah saya dapat memiliki kolom bergaris (striped) sambil mempertahankan warna khusus pada sel tertentu?**

Ya. Aktifkan kolom bergaris, lalu timpa sel tertentu dengan pemformatan lokal; pemformatan tingkat sel memiliki prioritas lebih tinggi daripada gaya tabel.