---
title: Kelola Tabel Presentasi di Android
linktitle: Kelola Tabel
type: docs
weight: 10
url: /id/androidjava/manage-table/
keywords:
- menambahkan tabel
- membuat tabel
- mengakses tabel
- rasio aspek
- menyelaraskan teks
- pemformatan teks
- gaya tabel
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Buat & edit tabel dalam slide PowerPoint dengan Aspose.Slides untuk Android. Temukan contoh kode Java sederhana untuk menyederhanakan alur kerja tabel Anda."
---
## **Pendahuluan**

Tabel di PowerPoint adalah cara yang efisien untuk menampilkan dan menggambarkan informasi. Informasi dalam kisi sel (diatur dalam baris dan kolom) bersifat langsung dan mudah dipahami.

Aspose.Slides menyediakan kelas [Table](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Table), antarmuka [ITable](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ITable), kelas [Cell](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/cell/), antarmuka [ICell](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/icell/), dan tipe lainnya untuk memungkinkan Anda membuat, memperbarui, dan mengelola tabel dalam semua jenis presentasi.

## **Membuat Tabel dari Awal**

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation).
2. Dapatkan referensi slide melalui indeksnya. 
3. Tentukan array `columnWidth`.
4. Tentukan array `rowHeight`.
5. Tambahkan objek [ITable](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ITable) ke slide melalui metode [addTable](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-).
6. Iterasi melalui setiap [ICell](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/icell/) untuk menerapkan pemformatan pada batas atas, bawah, kanan, dan kiri.
7. Gabungkan dua sel pertama pada baris pertama tabel. 
8. Akses [TextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/textframe/) milik sebuah [ICell](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/icell/).
9. Tambahkan teks ke [TextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/textframe/).
10. Simpan presentasi yang telah dimodifikasi.

Kode Java ini menunjukkan cara membuat tabel dalam sebuah presentasi:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

    // Menetapkan format border untuk setiap sel
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
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(0).get_Item(1), false);

    // Menambahkan teks ke sel yang digabungkan
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");

    // Menyimpan presentasi ke Disk
    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Penomoran dalam Tabel Standar**

Dalam tabel standar, penomoran sel bersifat langsung dan berbasis nol. Sel pertama dalam tabel diindeks sebagai 0,0 (kolom 0, baris 0). 

Sebagai contoh, sel dalam tabel dengan 4 kolom dan 4 baris dinomori sebagai berikut:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Kode Java ini menunjukkan cara menentukan penomoran untuk sel dalam sebuah tabel:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

    // Menetapkan format border untuk setiap sel
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

## **Mengakses Tabel yang Ada**

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation).
2. Dapatkan referensi ke slide yang berisi tabel melalui indeksnya. 
3. Buat objek [ITable](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ITable) dan setel menjadi null.
4. Iterasi melalui semua objek [IShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/) hingga tabel ditemukan.

   Jika Anda menduga slide yang Anda tangani hanya berisi satu tabel, Anda dapat memeriksa semua shape yang ada. Ketika sebuah shape diidentifikasi sebagai tabel, Anda dapat melakukan typecast menjadi objek [Table](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Table). Namun jika slide tersebut berisi beberapa tabel, lebih baik mencari tabel yang Anda butuhkan melalui [setAlternativeText(String value)](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/#setAlternativeText-java.lang.String-).

5. Gunakan objek [ITable](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ITable) untuk bekerja dengan tabel. Pada contoh di bawah, kami mengatur teks sebuah sel dalam tabel.
6. Simpan presentasi yang telah dimodifikasi.

Kode Java ini menunjukkan cara mengakses dan bekerja dengan tabel yang ada:

```java
import com.aspose.slides.*;

// Membuat instance kelas Presentation yang mewakili file PPTX
Presentation pres = new Presentation("UpdateExistingTable.pptx");
try {

    // Mengakses slide pertama
    ISlide sld = pres.getSlides().get_Item(0);

    // Menginisialisasi TableEx menjadi null
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

## **Temukan Sel yang Memiliki Text Frame**

Ketika kode pemrosesan teks umum menerima sebuah [ITextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/) dari sebuah tabel, gunakan metode [ITextFrame.getParentCell](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/#getParentCell--) untuk mendapatkan [ICell](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/icell/) pemiliknya. Untuk text frame sel tabel, [ITextFrame.getParentCell](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/#getParentCell--) mengembalikan pemilik dan [ITextFrame.getParentShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/#getParentShape--) mengembalikan `null`, meskipun tabel itu sendiri adalah sebuah shape.

Koordinat sel tersedia melalui metode baca-saja [ICell.getFirstColumnIndex](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) dan [ICell.getFirstRowIndex](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/icell/#getFirstRowIndex--). [ITextFrame.getParentCell](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/#getParentCell--) juga menyediakan navigasi baca-saja: ia mengembalikan pemilik tetapi tidak mengubah kepemilikan. Selalu periksa apakah sel yang dikembalikan `null` sebelum menggunakannya.

Untuk contoh lengkap yang mengidentifikasi pemilik sel tabel dan shape, termasuk shape yang terkait dengan node SmartArt, lihat [Search and Replace Text](/slides/id/androidjava/search-and-replace-text/).

## **Menyelaraskan Teks dalam Tabel**

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation).
2. Dapatkan referensi slide melalui indeksnya. 
3. Tambahkan objek [ITable](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ITable) ke slide.
4. Akses objek [ITextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/) dari tabel.
5. Akses [IParagraph](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraph/) dari [ITextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/).
6. Luruskan teks secara vertikal.
7. Simpan presentasi yang telah dimodifikasi.

Kode Java ini menunjukkan cara menyelaraskan teks dalam tabel:

```java
import com.aspose.slides.*;
import java.awt.Color;

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
    
    // Membuat objek Portion untuk paragraph
    IPortion portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    
    // Menyelaraskan teks secara vertikal
    ICell cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(TextAnchorType.Center);
    cell.setTextVerticalType(TextVerticalType.Vertical270);
    
    // Menyimpan presentasi ke disk
    pres.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Setel Pemformatan Teks pada Tingkat Tabel**

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation).
2. Dapatkan referensi slide melalui indeksnya. 
3. Akses objek [ITable](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ITable) dari Slide.
4. Setel [setFontHeight(float value)](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) untuk teks.
5. Setel [setAlignment(int value)](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) dan [setMarginRight(float value)](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-).
6. Setel [setTextVerticalType(byte value)](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Simpan presentasi yang telah dimodifikasi. 

Kode Java ini menunjukkan cara menerapkan opsi pemformatan yang Anda pilih pada teks dalam tabel:

```java
import com.aspose.slides.*;

// Membuat instance kelas Presentation
Presentation pres = new Presentation("simpletable.pptx");
try {
    // Misalkan shape pertama pada slide pertama adalah sebuah tabel
    ITable someTable = (ITable) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    // Menetapkan tinggi font sel tabel
    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    
    // Menetapkan perataan teks sel tabel dan margin kanan dalam satu panggilan
    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    
    // Menetapkan tipe vertikal teks sel tabel
    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    someTable.setTextFormat(textFrameFormat);
    
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Dapatkan Properti Gaya Tabel**

Aspose.Slides memungkinkan Anda mengambil properti gaya untuk sebuah tabel sehingga Anda dapat menggunakan detail tersebut pada tabel lain atau di tempat lain. Kode Java ini menunjukkan cara mendapatkan properti gaya dari style preset tabel:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ITable table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.setStylePreset(TableStylePreset.DarkStyle1); // ubah tema preset gaya default 

    // Dapatkan preset gaya tabel
    int stylePreset = table.getStylePreset();
    System.out.println("Table style preset: " + stylePreset);

    // Terapkan preset gaya yang diambil ke tabel lain
    ITable anotherTable = pres.getSlides().get_Item(0).getShapes().addTable(10, 100, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    anotherTable.setStylePreset(stylePreset);

    pres.save("table.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Kunci Rasio Aspek Tabel**

Rasio aspek sebuah shape geometris adalah perbandingan ukuran pada dimensi yang berbeda. Aspose.Slides menyediakan properti [**setAspectRatioLocked**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) untuk memungkinkan Anda mengunci pengaturan rasio aspek pada tabel dan shape lainnya.

Kode Java ini menunjukkan cara mengunci rasio aspek untuk sebuah tabel:

```java
import com.aspose.slides.*;

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

**Apakah saya dapat mengaktifkan arah baca kanan-ke-kiri (RTL) untuk seluruh tabel dan teks di dalam selnya?**

Ya. Tabel menyediakan metode [setRightToLeft](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/table/#setRightToLeft-boolean-), dan paragraf memiliki [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/paragraphformat/#setRightToLeft-byte-). Menggunakan keduanya memastikan urutan RTL yang tepat dan rendering di dalam sel.

**Bagaimana saya dapat mencegah pengguna memindahkan atau mengubah ukuran tabel dalam file akhir?**

Gunakan kunci shape untuk menonaktifkan pemindahan, perubahan ukuran, pemilihan, dll. Kunci ini juga berlaku untuk tabel.

**Apakah menyisipkan gambar di dalam sel sebagai latar belakang didukung?**

Ya. Anda dapat mengatur [picture fill](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/picturefillformat/) untuk sebuah sel; gambar akan menutupi area sel sesuai mode yang dipilih (stretch atau tile).