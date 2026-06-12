---
title: Kelola Baris dan Kolom dalam Tabel PowerPoint Menggunakan Java
linktitle: Baris dan Kolom
type: docs
weight: 20
url: /id/java/manage-rows-and-columns/
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
- Java
- Aspose.Slides
description: "Kelola baris dan kolom tabel di PowerPoint dengan Aspose.Slides untuk Java dan percepat pengeditan presentasi serta pembaruan data."
---
## **Pendahuluan**

Untuk memungkinkan Anda mengelola baris dan kolom tabel dalam presentasi PowerPoint, Aspose.Slides menyediakan kelas [Table](https://reference.aspose.com/slides/id/java/com.aspose.slides/table/) , antarmuka [ITable](https://reference.aspose.com/slides/id/java/com.aspose.slides/ITable) , dan banyak tipe lainnya. 

## **Set Baris Pertama sebagai Header**

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/) dan muat presentasi. 
2. Dapatkan referensi slide melalui indeksnya. 
3. Buat objek [ITable](https://reference.aspose.com/slides/id/java/com.aspose.slides/ITable) dan setel menjadi null. 
4. Iterasi semua objek [IShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishape/) untuk menemukan tabel yang relevan. 
5. Setel baris pertama tabel sebagai headernya. 

Kode Java ini menunjukkan cara mengatur baris pertama tabel sebagai header:

```java
// Membuat instance kelas Presentation
Presentation pres = new Presentation("table.pptx");
try {
    // Mengakses slide pertama
    ISlide sld = pres.getSlides().get_Item(0);

    // Menginisialisasi TableEx yang null
    ITable tbl = null;

    // Iterasi melalui shape dan menetapkan referensi ke tabel
    for (IShape shp : sld.getShapes())
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable)shp;
            
            //Mengatur baris pertama tabel sebagai headernya
        }
    }
    
    // Menyimpan presentasi ke disk
    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Duplikat Baris atau Kolom Tabel**

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/) dan muat presentasi, 
2. Dapatkan referensi slide melalui indeksnya. 
3. Definisikan array `columnWidth`. 
4. Definisikan array `rowHeight`. 
5. Tambahkan objek [ITable](https://reference.aspose.com/slides/id/java/com.aspose.slides/ITable) ke slide melalui metode [addTable](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---). 
6. Duplikat baris tabel. 
7. Duplikat kolom tabel. 
8. Simpan presentasi yang telah dimodifikasi. 

Kode Java ini menunjukkan cara menggandakan baris atau kolom tabel PowerPoint:

```java
 // Membuat instance kelas Presentation
Presentation pres = new Presentation("Test.pptx");
try {
    // Mengakses slide pertama
    ISlide sld = pres.getSlides().get_Item(0);

    // Mendefinisikan kolom dengan lebar dan baris dengan tinggi
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Menambahkan shape tabel ke slide
    ITable table = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Menambahkan teks ke sel baris 1 kolom 1
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");

    // Menambahkan teks ke sel baris 1 kolom 2
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");

    // Menggandakan Baris 1 di akhir tabel
    table.getRows().addClone(table.getRows().get_Item(0), false);

    // Menambahkan teks ke sel baris 2 kolom 1
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");

    // Menambahkan teks ke sel baris 2 kolom 2
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");

    // Menggandakan Baris 2 sebagai baris ke-4 tabel
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    // Menggandakan kolom pertama di akhir
    table.getColumns().addClone(table.getColumns().get_Item(0), false);

    // Menggandakan kolom ke-2 pada indeks kolom ke-4
    table.getColumns().insertClone(3,table.getColumns().get_Item(1), false);
    
    // Menyimpan presentasi ke disk
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Hapus Baris atau Kolom dari Tabel**

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/) dan muat presentasi, 
2. Dapatkan referensi slide melalui indeksnya. 
3. Definisikan array `columnWidth`. 
4. Definisikan array `rowHeight`. 
5. Tambahkan objek [ITable](https://reference.aspose.com/slides/id/java/com.aspose.slides/ITable) ke slide melalui metode [addTable](https://reference.aspose.com/slides/id/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---). 
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

## **Setel Pemformatan Teks pada Tingkat Baris Tabel**

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/) dan muat presentasi, 
2. Dapatkan referensi slide melalui indeksnya. 
3. Akses objek [ITable](https://reference.aspose.com/slides/id/java/com.aspose.slides/ITable) yang relevan dari slide. 
4. Setel [setFontHeight(float value)](https://reference.aspose.com/slides/id/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) pada sel baris pertama. 
5. Setel [setAlignment(int value)](https://reference.aspose.com/slides/id/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) dan [setMarginRight(float value)](https://reference.aspose.com/slides/id/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-) pada sel baris pertama. 
6. Setel [setTextVerticalType(byte value)](https://reference.aspose.com/slides/id/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) pada sel baris kedua. 
7. Simpan presentasi yang telah dimodifikasi. 

Kode Java ini memperlihatkan operasi tersebut.

```java
// Membuat instance kelas Presentation
Presentation pres = new Presentation();
try {
    // Misalkan bahwa shape pertama pada slide pertama adalah tabel
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

## **Setel Pemformatan Teks pada Tingkat Kolom Tabel**

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/) dan muat presentasi, 
2. Dapatkan referensi slide melalui indeksnya. 
3. Akses objek [ITable](https://reference.aspose.com/slides/id/java/com.aspose.slides/ITable) yang relevan dari slide. 
4. Setel [setFontHeight(float value)](https://reference.aspose.com/slides/id/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) pada sel kolom pertama. 
5. Setel [setAlignment(int value)](https://reference.aspose.com/slides/id/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) dan [setMarginRight(float value)](https://reference.aspose.com/slides/id/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-) pada sel kolom pertama. 
6. Setel [setTextVerticalType(byte value)](https://reference.aspose.com/slides/id/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) pada sel kolom kedua. 
7. Simpan presentasi yang telah dimodifikasi. 

Kode Java ini memperlihatkan operasi tersebut: 

```java
// Membuat instance kelas Presentation
Presentation pres = new Presentation();
try {
    // Misalkan bahwa shape pertama pada slide pertama adalah tabel
    ITable someTable = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0)];

    // Mengatur tinggi font sel kolom pertama
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
	
    someTable.getColumns().get_Item(0).setTextFormat(portionFormat);

    // Mengatur perataan teks dan margin kanan sel kolom pertama dalam satu pemanggilan
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

Ya. Tabel mewarisi tema slide/layout/master, dan Anda masih dapat menimpa isi, batas, dan warna teks di atas tema tersebut.

**Apakah saya dapat mengurutkan baris tabel seperti di Excel?**

Tidak, tabel Aspose.Slides tidak memiliki penyortiran atau filter bawaan. Urutkan data Anda di memori terlebih dahulu, lalu isi kembali baris tabel sesuai urutan tersebut.

**Apakah saya dapat memiliki kolom bergaris (striped) sambil mempertahankan warna khusus pada sel tertentu?**

Ya. Aktifkan kolom bergaris, lalu timpa sel tertentu dengan pemformatan lokal; pemformatan tingkat sel memiliki prioritas lebih tinggi daripada gaya tabel.