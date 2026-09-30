---
title: Kelola Tabel Presentasi di Android
linktitle: Kelola Tabel
type: docs
weight: 10
url: /id/androidjava/manage-table/
keywords:
- menambah tabel
- buat tabel
- akses tabel
- rasio aspek
- rata teks
- pemformatan teks
- gaya tabel
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Buat & edit tabel dalam slide PowerPoint dengan Aspose.Slides untuk Android. Temukan contoh kode Java sederhana untuk mempermudah alur kerja tabel Anda."
---
## **Pengantar**

Tabel di PowerPoint mengatur informasi ke dalam baris dan kolom, memudahkan membaca dan membandingkan nilai.

Aspose.Slides menyediakan kelas [Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/) , antarmuka [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) , kelas [Cell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cell/) , antarmuka [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/) , dan tipe lainnya untuk memungkinkan Anda membuat, memperbarui, dan mengelola tabel dalam presentasi.

## **Buat Tabel dari Awal**

Buat tabel dengan menentukan posisinya, lebar kolom, dan tinggi baris. Setelah menambahkannya ke slide, Anda dapat memformat border sel, menggabungkan sel, dan menyisipkan teks.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tentukan array lebar kolom dalam poin.
4. Tentukan array tinggi baris dalam poin.
5. Tambahkan objek [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) ke slide melalui metode [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---).
6. Iterasi setiap [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/) untuk menerapkan pemformatan pada border atas, bawah, kanan, dan kiri.
7. Gabungkan dua sel pertama pada baris pertama tabel.
8. Akses sel yang digabungkan melalui metode [getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getTextFrame--) .
9. Atur teks dalam sel yang digabungkan.
10. Simpan presentasi yang dimodifikasi.

Contoh di bawah ini membuat tabel dengan tiga kolom dan lima baris pada posisi (100, 50) poin. Ia menerapkan border merah dengan lebar 5 poin, menggabungkan dua sel pertama pada baris pertama, dan menyimpan hasilnya sebagai `table.pptx`.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 50, 50, 50 };
    double[] rowHeights = { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
    {
        for (ICell cell : row)
        {
            ICellFormat cellFormat = cell.getCellFormat();
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

    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 0), false);
    table.get_Item(0, 0).getTextFrame().setText("Merged Cells");

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Penomoran dalam Tabel Standar**

Dalam tabel standar, indeks sel berbasis nol dan menggunakan urutan (kolom, baris). Sel pertama diindeks sebagai (0, 0).

Sebagai contoh, sel‑sel dalam tabel dengan 4 kolom dan 4 baris diberi nomor sebagai berikut:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Contoh ini membuat tabel 4 × 4 yang diilustrasikan di atas, dengan lebar kolom dan tinggi baris masing‑masing 70 poin serta border sel merah berukuran 5 poin. Koordinat tersebut menunjukkan indeks sel; contoh ini membiarkan sel kosong dan menyimpan tabel sebagai `StandardTables_out.pptx`.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
    {
        for (ICell cell : row)
        {
            ICellFormat cellFormat = cell.getCellFormat();
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

    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Akses Tabel yang Ada**

Tabel disimpan dalam koleksi shape slide. Iterasi shape untuk menemukan tabel, lalu gunakan antarmuka [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) untuk membaca atau memperbarui sel‑nya.

1. Muat presentasi menggunakan kelas [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
2. Dapatkan referensi ke slide yang berisi tabel berdasarkan indeksnya.
3. Iterasi objek [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) dan berhenti ketika tabel ditemukan. Jika slide berisi beberapa tabel, gunakan [getAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getAlternativeText--) untuk mengidentifikasi yang Anda butuhkan.
4. Perbarui teks dalam sel target.
5. Simpan presentasi yang dimodifikasi.

Contoh di bawah ini membuka `UpdateExistingTable.pptx` dan menemukan tabel pertama pada slide pertama. Ia mengatur sel pada kolom 0, baris 1 menjadi `New` dan menyimpan hasilnya sebagai `table1_out.pptx`. Input harus berisi setidaknya satu slide, dan tabel pertama pada slide tersebut harus memiliki setidaknya satu kolom dan dua baris.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("UpdateExistingTable.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof ITable) {
            table = (ITable) shape;
            break;
        }
    }

    if (table != null) {
        table.get_Item(0, 1).getTextFrame().setText("New");
        presentation.save("table1_out.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Untuk mengubah ukuran baris dalam tabel yang ada dan memahami mengapa tinggi sebenarnya dapat melebihi minimum yang diminta, lihat [Mengontrol Tinggi Baris](/slides/id/androidjava/manage-rows-and-columns/#control-row-height).

## **Temukan Sel yang Memiliki Text Frame**

Ketika kode pemrosesan teks umum menerima sebuah [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) dari tabel, gunakan metode [ITextFrame.getParentCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentCell--) untuk mengambil [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/) pemiliknya. Untuk text frame sel‑tabel, [ITextFrame.getParentCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentCell--) mengembalikan pemilik dan [ITextFrame.getParentShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentShape--) mengembalikan `null`, meskipun tabel itu sendiri adalah sebuah shape.

Koordinat sel tersedia melalui metode read‑only [ICell.getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) dan [ICell.getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) . [ITextFrame.getParentCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentCell--) juga menyediakan navigasi read‑only: ia mengembalikan pemilik tetapi tidak mengubah kepemilikan. Selalu periksa apakah sel yang dikembalikan `null` sebelum menggunakannya.

Untuk contoh lengkap yang mengidentifikasi pemilik sel‑tabel dan shape, termasuk shape yang terkait dengan node SmartArt, lihat [Cari dan Ganti Teks](/slides/id/androidjava/search-and-replace-text/).

## **Ratakan Teks dalam Tabel**

Anda dapat mengontrol anchoring vertikal dan arah teks sel‑tabel secara individu. Contoh dalam seksi ini memusatkan teks dalam sel pertama dan memutarnya sebesar 270 derajat.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tambahkan objek [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) ke slide.
4. Akses objek [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) dari tabel.
5. Akses [IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/) pertama dan atur teks serta warnanya.
6. Atur anchoring vertikal sel dan arah teks menggunakan [setTextAnchorType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setTextAnchorType-byte-) dan [setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setTextVerticalType-byte-) .
7. Simpan presentasi yang dimodifikasi.

Contoh ini membuat tabel 4 × 4 dengan lebar kolom 120 poin dan tinggi baris 100 poin. Ia memformat teks di sel (0, 0), menambahkan nilai ke sel‑sel lain di baris pertama, dan menyimpan hasilnya sebagai `Vertical_Align_Text_out.pptx`.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 120, 120, 120, 120 };
    double[] rowHeights = { 100, 100, 100, 100 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 0).getTextFrame().setText("10");
    table.get_Item(2, 0).getTextFrame().setText("20");
    table.get_Item(3, 0).getTextFrame().setText("30");

    ITextFrame textFrame = table.get_Item(0, 0).getTextFrame();
    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);

    IPortion portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    ICell cell = table.get_Item(0, 0);
    cell.setTextAnchorType(TextAnchorType.Center);
    cell.setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Atur Pemformatan Teks pada Tingkat Tabel**

Gunakan [setTextFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulktextformattable/#setTextFormat-com.aspose.slides.IPortionFormat-) untuk menerapkan pemformatan teks ke semua sel dalam tabel. Overload‑nya menerima pemformatan portion, paragraph, dan text frame, sehingga Anda dapat mengatur properti‑nya tanpa iterasi sel‑per‑sel.

1. Muat presentasi menggunakan kelas [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Akses objek [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) dari slide.
4. Atur ukuran font menggunakan [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) untuk teks.
5. Atur perataan paragraf dan margin kanan menggunakan [setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) dan [setMarginRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) .
6. Atur arah teks menggunakan [setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) .
7. Simpan presentasi yang dimodifikasi.

Contoh di bawah ini membuka `table.pptx`, yang harus berisi setidaknya satu slide dengan tabel sebagai shape pertama. Ia mengatur ukuran font menjadi 25 poin, meratakan paragraf ke kanan dengan margin kanan 20 poin, dan menjadikan teks vertikal. Presentasi yang telah diformat disimpan sebagai `result.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.setTextFormat(textFrameFormat);

    presentation.save("result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Dapatkan Properti Gaya Tabel**

Gunakan [getStylePreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#getStylePreset--) untuk membaca gaya preset tabel dan [setStylePreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#setStylePreset-int-) untuk menetapkannya. Contoh ini menerapkan [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tablestylepreset/) pada satu tabel, mencetak nilai preset, dan menetapkan preset yang sama pada tabel kedua. Kedua tabel disimpan dalam `table-style.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 100, 150 };
    double[] rowHeights = { 5, 5, 5 };
    ITable table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(TableStylePreset.DarkStyle1);

    int stylePreset = table.getStylePreset();
    System.out.println("Table style preset: " + stylePreset);

    ITable anotherTable = slide.getShapes().addTable(10, 100, columnWidths, rowHeights);
    anotherTable.setStylePreset(stylePreset);

    presentation.save("table-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kunci Rasio Aspek Tabel**

Rasio aspek tabel adalah perbandingan antara lebar dan tingginya. Gunakan [setAspectRatioLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/#setAspectRatioLocked-boolean-) untuk mengunci rasio ini pada tabel.

Contoh di bawah ini membuka `pres.pptx`, yang harus berisi setidaknya satu slide dengan tabel sebagai shape pertama. Ia mencetak status kunci saat ini, mengaktifkan kunci rasio aspek, mencetak status yang diperbarui (`true`), dan menyimpan hasilnya sebagai `pres-out.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable) slide.getShapes().get_Item(0);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(true);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    presentation.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Apakah saya dapat mengaktifkan arah baca kanan‑ke‑kiri (RTL) untuk seluruh tabel dan teks di sel‑nya?**

Ya. Tabel menyediakan metode [setRightToLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/#setRightToLeft-boolean-) , dan paragraf memiliki [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphformat/#setRightToLeft-byte-) . Menggunakan keduanya memastikan urutan RTL yang benar dan rendering di dalam sel.

**Bagaimana cara mencegah pengguna memindahkan atau mengubah ukuran tabel dalam file akhir?**

Gunakan [shape locks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/) untuk menonaktifkan pemindahan, perubahan ukuran, pemilihan, dll. Kunci ini juga berlaku untuk tabel.

**Apakah menyisipkan gambar di dalam sel sebagai latar belakang didukung?**

Ya. Anda dapat mengatur [picture fill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillformat/) untuk sel; gambar akan menutupi area sel sesuai mode yang dipilih (stretch atau tile).