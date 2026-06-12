---
title: Kelola Tabel Presentasi pada Android
linktitle: Kelola Tabel
type: docs
weight: 10
url: /id/androidjava/manage-table/
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
- Android
- Java
- Aspose.Slides
description: "Buat & edit tabel dalam slide PowerPoint dengan Aspose.Slides untuk Android. Temukan contoh kode Java sederhana untuk mempermudah alur kerja tabel Anda."
---
## **Pendahuluan**

Tabel di PowerPoint adalah cara yang efisien untuk menampilkan dan menggambarkan informasi. Informasi dalam kisi sel (disusun dalam baris dan kolom) bersifat langsung dan mudah dipahami.

Aspose.Slides menyediakan kelas [Table](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Table), antarmuka [ITable](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ITable), kelas [Cell](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/cell/), antarmuka [ICell](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/icell/), dan tipe lainnya untuk memungkinkan Anda membuat, memperbarui, dan mengelola tabel dalam semua jenis presentasi.

## **Buat Tabel dari Awal**

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation).
2. Dapatkan referensi slide melalui indeksnya. 
3. Definisikan array `columnWidth`.
4. Definisikan array `rowHeight`.
5. Tambahkan objek [ITable](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ITable) ke slide melalui metode [addTable](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-).
6. Iterasi setiap [ICell](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/icell/) untuk menerapkan pemformatan pada batas atas, bawah, kanan, dan kiri.
7. Gabungkan dua sel pertama pada baris pertama tabel. 
8. Akses [TextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/textframe/) dari sebuah [ICell](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/icell/).
9. Tambahkan teks ke [TextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/textframe/).
10. Simpan presentasi yang telah dimodifikasi.

Kode Java berikut menunjukkan cara membuat tabel dalam sebuah presentasi:

```java
// Membuat instance kelas Presentation yang mewakili file PPTX
Presentation pres = new Presentation();
try {
    // Mengakses slide pertama
    ISlide sld = pres.getSlides().get_Item(0);

    // Mendefinisikan kolom dengan lebar dan baris dengan tinggi
    double[] dblCols = {50, 50, 50};
    double[] dblRows = {50, 30, 30, 30, 30};

    // Menambahkan shape tabel ke slide
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Mengatur format batas untuk setiap sel
    for (int row = 0; row < tbl.getRows().size(); row++)
    {
        for (int cell = 0; cell < tbl.getRows().get_Item(row).size(); cell++)
        {
            ICellFormat cellFormat = tbl.getRows().get_Item(row).get_Item(cell).getCellFormat();
            
            cellFormat.getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderRight().setWidth(5);
        }
    }
    // Menggabungkan sel 1 & 2 pada baris 1
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(1).get_Item(1), false);

    // Menambahkan teks ke sel yang digabung
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");

    // Menyimpan presentasi ke Disk
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Penomoran dalam Tabel Standar**

Dalam tabel standar, penomoran sel bersifat langsung dan berbasis nol. Sel pertama dalam tabel diindeks sebagai 0,0 (kolom 0, baris 0). 

Misalnya, sel dalam tabel dengan 4 kolom dan 4 baris diberi nomor seperti ini:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Kode Java berikut menunjukkan cara menentukan penomoran untuk sel dalam tabel:

```java
// Membuat instance kelas Presentation yang mewakili file PPTX
Presentation pres = new Presentation();
try {
    // Mengakses slide pertama
    ISlide sld = pres.getSlides().get_Item(0);

    // Mendefinisikan kolom dengan lebar dan baris dengan tinggi
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Menambahkan shape tabel ke slide
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Mengatur format batas untuk setiap sel
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderTop().setWidth(5);

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderBottom().setWidth(5);

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderLeft().setWidth(5);

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }

    // Menyimpan presentasi ke disk
    pres.save("StandardTables_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Akses Tabel yang Ada**

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation).
2. Dapatkan referensi ke slide yang berisi tabel melalui indeksnya. 
3. Buat objek [ITable](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ITable) dan setel ke null.
4. Iterasi semua objek [IShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/) hingga tabel ditemukan.

   Jika Anda menduga slide yang sedang Anda tangani berisi satu tabel, Anda dapat cukup memeriksa semua shape yang ada di dalamnya. Saat sebuah shape teridentifikasi sebagai tabel, Anda dapat melakukan typecast menjadi objek [Table](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Table). Namun jika slide yang Anda tangani berisi beberapa tabel, maka lebih baik mencari tabel yang Anda perlukan melalui [setAlternativeText(String value)](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/#setAlternativeText-java.lang.String-).

5. Gunakan objek [ITable](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ITable) untuk bekerja dengan tabel. Pada contoh di bawah, kami menambahkan baris baru ke tabel.
6. Simpan presentasi yang telah dimodifikasi.

Kode Java berikut menunjukkan cara mengakses dan bekerja dengan tabel yang ada:

```java
// Membuat instance kelas Presentation yang mewakili file PPTX
Presentation pres = new Presentation("UpdateExistingTable.pptx");
try {

    // Mengakses slide pertama
    ISlide sld = pres.getSlides().get_Item(0);

    // Menginisialisasi TableEx null
    ITable tbl = null;

    // Mengiterasi shape dan menetapkan referensi ke tabel yang ditemukan
    for (IShape shp : sld.getShapes()) 
    {
        if (shp instanceof ITable) 
        {
            tbl = (ITable) shp;
            // Menetapkan teks untuk kolom pertama pada baris kedua
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    
    // Menyimpan presentasi yang dimodifikasi ke disk
    pres.save("table1_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ratakan Teks dalam Tabel**

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation).
2. Dapatkan referensi slide melalui indeksnya. 
3. Tambahkan objek [ITable](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ITable) ke slide.
4. Akses objek [ITextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/) dari tabel.
5. Akses [IParagraph](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraph/) dari [ITextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/).
6. Ratakan teks secara vertikal.
7. Simpan presentasi yang telah dimodifikasi.

Kode Java berikut menunjukkan cara meratakan teks dalam tabel:

```java
// Membuat instance kelas Presentation
Presentation pres = new Presentation();
try {
    // Mendapatkan slide pertama 
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Mendefinisikan kolom dengan lebar dan baris dengan tinggi
    double[] dblCols = { 120, 120, 120, 120 };
    double[] dblRows = { 100, 100, 100, 100 };
    
    // Menambahkan shape tabel ke slide
    ITable tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    
    // Mengakses text frame
    ITextFrame txtFrame = tbl.get_Item(0, 0).getTextFrame();
    
    // Membuat objek Paragraph untuk text frame
    IParagraph paragraph = txtFrame.getParagraphs().get_Item(0);
    
    // Membuat objek Portion untuk paragraf
    IPortion portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // Meratakan teks secara vertikal
    ICell cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(TextAnchorType.Center);
    cell.setTextVerticalType(TextVerticalType.Vertical270);
    
    // Menyimpan presentasi ke disk
    pres.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Atur Pemformatan Teks pada Tingkat Tabel**

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation).
2. Dapatkan referensi slide melalui indeksnya. 
3. Akses objek [ITable](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ITable) dari Slide.
4. Setel [setFontHeight(float value)](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) untuk teks.
5. Setel [setAlignment(int value)](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) dan [setMarginRight(float value)](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-).
6. Setel [setTextVerticalType(byte value)](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Simpan presentasi yang telah dimodifikasi. 

Kode Java berikut menunjukkan cara menerapkan opsi pemformatan pilihan Anda pada teks dalam tabel:

```java
// Membuat instance kelas Presentation
Presentation pres = new Presentation("simpletable.pptx");
try {
    // Asumsikan bahwa shape pertama pada slide pertama adalah tabel
    ITable someTable = (ITable) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    // Mengatur tinggi font sel tabel
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    
    // Mengatur perataan teks sel tabel dan margin kanan dalam satu panggilan
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    
    // Mengatur tipe vertikal teks sel tabel
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    someTable.setTextFormat(textFrameFormat);
    
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Dapatkan Properti Gaya Tabel**

Aspose.Slides memungkinkan Anda mengambil properti gaya untuk sebuah tabel sehingga Anda dapat menggunakan detail tersebut pada tabel lain atau di tempat lain. Kode Java berikut menunjukkan cara mendapatkan properti gaya dari preset style tabel:

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

## **Kunci Rasio Aspek Tabel**

Rasio aspek suatu bentuk geometris adalah perbandingan ukuran‑ukuran dalam dimensi yang berbeda. Aspose.Slides menyediakan properti [**setAspectRatioLocked**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) untuk memungkinkan Anda mengunci pengaturan rasio aspek pada tabel dan shape lainnya.

Kode Java berikut menunjukkan cara mengunci rasio aspek untuk sebuah tabel:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked()); // balikkan

    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Apakah saya dapat mengaktifkan arah baca kanan-ke-kiri (RTL) untuk seluruh tabel dan teks di selnya?**

Ya. Tabel menyediakan metode [setRightToLeft](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/table/#setRightToLeft-boolean-), dan paragraf memiliki [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/paragraphformat/#setRightToLeft-byte-). Menggunakan keduanya memastikan urutan RTL yang benar dan rendering di dalam sel.

**Bagaimana saya dapat mencegah pengguna memindahkan atau mengubah ukuran tabel dalam file akhir?**

Gunakan kunci shape untuk menonaktifkan pemindahan, perubahan ukuran, pemilihan, dll. Kunci ini juga berlaku untuk tabel.

**Apakah menyisipkan gambar di dalam sel sebagai latar belakang didukung?**

Ya. Anda dapat mengatur [picture fill](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/picturefillformat/) untuk sebuah sel; gambar akan menutupi area sel sesuai mode yang dipilih (stretch atau tile).