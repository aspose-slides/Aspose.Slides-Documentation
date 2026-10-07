---
title: Kelola Sel Tabel dalam Presentasi di Android
linktitle: Kelola Sel
type: docs
weight: 30
url: /id/androidjava/manage-cells/
keywords:
- sel tabel
- menggabungkan sel
- hapus batas
- pisahkan sel
- gambar dalam sel
- warna latar belakang
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Kelola sel tabel PowerPoint di Android: identifikasi sel yang digabung, hapus batas, pisahkan sel, serta atur warna latar belakang dan gambar dengan Aspose.Slides untuk Android melalui Java."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda mengakses dan memodifikasi sel tabel dalam presentasi PowerPoint. Artikel ini menjelaskan cara mengidentifikasi sel tabel yang digabung, menghapus batas sel, bekerja dengan penomoran sel setelah menggabungkan atau memisahkan sel, mengubah warna latar belakang sel, dan menambahkan gambar di dalam sel tabel. Contoh-contoh menunjukkan cara membuat atau membuka presentasi, mendapatkan tabel dari sebuah slide, memperbarui format sel melalui properti sel, dan menyimpan presentasi yang dimodifikasi sebagai file PPTX.

Aspose.Slides menggunakan indeks berbasis nol untuk mengakses sel tabel dalam urutan `(column, row)`.

## **Mengidentifikasi Sel Tabel yang Digabung**

Contoh membuka presentasi yang ada dan mengakses bentuk pertama pada slide pertama sebagai tabel. Diasumsikan bahwa slide dan bentuk ada dan bentuk tersebut adalah tabel. Kemudian iterasi melalui semua baris dan kolom dan menggunakan [isMergedCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#isMergedCell--) untuk mengidentifikasi sel dalam wilayah yang digabung. Untuk setiap kecocokan, ia mencetak koordinat sel dalam urutan `row;column`, [getRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getRowSpan--), [getColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getColSpan--), dan koordinat awal wilayah, [getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) dan [getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation_with_table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    int rowCount = table.getRows().size();
    for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
    {
        int columnCount = table.getColumns().size();
        for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
        {
            ICell cell = table.get_Item(columnIndex, rowIndex);
            if (cell.isMergedCell())
            {
                System.out.printf("Cell %d;%d belongs to a merged region with RowSpan=%d and ColSpan=%d starting at %d;%d.%n", rowIndex, columnIndex, cell.getRowSpan(), cell.getColSpan(), cell.getFirstRowIndex(), cell.getFirstColumnIndex());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Menghapus Garis Batas Sel Tabel**

Buat sebuah [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) dan tambahkan tabel ke slide pertamanya dengan [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---). Lebar kolom, tinggi baris, dan posisi tabel ditentukan dalam poin. Contoh mengatur keempat batas sel menjadi [FillType.NoFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/), sehingga tidak terlihat.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 50, 50, 50, 50 };
    double[] rowHeights = { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill);
        }

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Menggabungkan Sel Tabel**

Gunakan [mergeCells](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#mergeCells-com.aspose.slides.ICell-com.aspose.slides.ICell-boolean-) untuk menggabungkan rentang persegi panjang sel tabel menjadi satu sel. Tentukan sel pada pojok kiri‑atas dan kanan‑bawah dari rentang. Argumen terakhir mengontrol apakah penggabungan dapat mencakup sel di luar rentang yang ditentukan; `false` menjaga penggabungan tetap dalam rentang tersebut.

Contoh membuat tabel 4×4 dengan kolom dan baris 70 poin, kemudian menggabungkan empat sel tengah dari `(1, 1)` sampai `(2, 2)`. Sel yang dihasilkan mencakup dua kolom dan dua baris, sementara grid tabel yang mendasarinya tetap memiliki empat kolom dan empat baris. Untuk mengakses konten atau format sel yang digabung, gunakan posisi kiri‑atasnya: `table.get_Item(1, 1)` dalam contoh ini. Posisi lain dalam rentang yang digabung tetap menjadi bagian dari grid tabel, sehingga indeks sel di luar rentang tidak berubah.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 2), false);

    presentation.save("merged_cells.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Memisahkan Sel Tabel**

Menggabungkan sel pada contoh sebelumnya mempertahankan grid tabel. Memisahkan sel dapat menambah kolom grid baru dan mengubah indeks kolom sel di sebelah kanannya. Aspose.Slides mengikuti model grid tabel PowerPoint.

Contoh ini membuat tabel 4×4 dengan kolom dan baris 70 poin dan memanggil [splitByWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByWidth-double-) pada sel `(1, 1)`. Setengah lebar sel 70 poin diberikan untuk membuat dua sel dengan lebar sama.

Setelah pemisahan ini, dua bagian diakses sebagai `table.get_Item(1, 1)` dan `table.get_Item(2, 1)`. Grid tabel kini memiliki lima kolom: sel yang semula berada di kolom 2 dan 3 berpindah ke kolom 3 dan 4 masing‑masing. Indeks baris tetap tidak berubah. Gunakan indeks kolom yang diperbarui saat mengakses sel setelah pemisahan.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 1).splitByWidth(table.get_Item(1, 1).getWidth() / 2);

    presentation.save("split_cells.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Memisahkan Sel yang Digabung Berdasarkan Baris atau Kolom**

Untuk menyiapkan sel templat yang digabung agar dapat diisi data, gunakan [splitByRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByRowSpan-int-) untuk memisahkan sepanjang batas baris yang ada, atau [splitByColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByColSpan-int-) untuk memisahkan sepanjang batas kolom.

Argumen `index` menghitung baris di bagian atas atau kolom di bagian kiri dari pemisahan; nilainya relatif terhadap wilayah yang digabung:

- Row split: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getRowSpan--).
- Column split: `0 < index <` [getColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getColSpan--).

Contoh mengasumsikan presentasi memiliki tabel sebagai bentuk pertama pada slide pertama, dengan sel `(1, 2)` dan `(1, 3)` digabung secara vertikal. Dimulai dari posisi bawah, contoh menggunakan [getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) dan [getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) untuk menemukan asal dan memeriksa kedua rentang. `splitByRowSpan(1)` kemudian memisahkan baris 2 dan 3 untuk nama produk. Untuk penggabungan horizontal dua kolom, gunakan `splitByColSpan(1)` sebagai gantinya.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table_template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    ICell selectedCell = table.get_Item(1, 3);
    int firstColumnIndex = selectedCell.getFirstColumnIndex();
    int firstRowIndex = selectedCell.getFirstRowIndex();
    ICell mergedCell = table.get_Item(firstColumnIndex, firstRowIndex);

    if (mergedCell.isMergedCell() && mergedCell.getRowSpan() == 2 && mergedCell.getColSpan() == 1)
    {
        mergedCell.splitByRowSpan(1);

        // Ambil sel hasil dari tabel setelah pemisahan.
        ICell upperCell = table.get_Item(firstColumnIndex, firstRowIndex);
        ICell lowerCell = table.get_Item(firstColumnIndex, firstRowIndex + 1);
        System.out.println("Upper cell merged: " + upperCell.isMergedCell());
        System.out.println("Lower cell merged: " + lowerCell.isMergedCell());

        upperCell.getTextFrame().setText("Product A");
        lowerCell.getTextFrame().setText("Product B");

        presentation.save("split_template.pptx", SaveFormat.Pptx);
    }
    else
    {
        System.out.println("Select a merged region spanning exactly two rows and one column.");
    }
} finally {
    presentation.dispose();
}
```

Grid tabel dan indeks sel di sekitarnya tetap tidak berubah. Ambil sel hasil dengan koordinatnya; di sini, keduanya memiliki rentang 1 dan [isMergedCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#isMergedCell--) menghasilkan `false`. Wilayah yang lebih besar dapat tetap sebagian digabung setelah satu pemisahan.

Teks asli dan formatnya tetap berada di sel atas (atau kiri); sel baru kosong tetapi mewarisi format sel seperti isi, batas, dan margin. Isi sel setelah pemisahan dan tetapkan format teks yang diperlukan secara eksplisit.

Presentasi yang disimpan berisi sel “Product A” dan “Product B” terpisah dengan format sel templat yang dipertahankan. Lihat [Referensi API Sel](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cell/) untuk detail.

## **Mengubah Warna Latar Belakang Sel Tabel**

Contoh ini membuat tabel dengan kolom 150 poin dan baris 50 poin. Ia menggunakan [setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) untuk memilih isi solid dan mengatur warna yang dikembalikan oleh [getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--) menjadi merah untuk sel `(2, 3)`, yaitu kolom ketiga dan baris keempat.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 150, 150, 150, 150 };
    double[] rowHeights = { 50, 50, 50, 50, 50 };
    ITable table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    ICell cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid);
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Menambahkan Gambar Di Dalam Sel Tabel**

Letakkan gambar input dalam direktori kerja sebelum menjalankan contoh ini. Gambar dimuat dengan [Images.fromFile](https://reference.aspose.com/slides/androidjava/com.aspose.slides/images/#fromFile-java.lang.String-) dan ditambahkan ke koleksi gambar presentasi dengan [addImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagecollection/#addImage-com.aspose.slides.IImage-). Selanjutnya gambar ditetapkan ke isian gambar sel `(0, 0)`, sel pertama dalam tabel.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/) memperpanjang gambar agar mengisi sel, yang dapat mengubah rasio aspeknya. Lebar kolom dan tinggi baris dalam poin. Gambar yang dimuat dibuang dalam blok `finally` setelah ditambahkan ke presentasi.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 150, 150, 150, 150 };
    double[] rowHeights = { 100, 100, 100, 100, 90 };
    ITable table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    IPPImage ppImage;
    IImage image = Images.fromFile("aspose_logo.jpg");
    try {
        ppImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    table.get_Item(0, 0).getCellFormat().getFillFormat().setFillType(FillType.Picture);
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);

    presentation.save("table_cell_with_image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Apakah saya dapat mengatur ketebalan garis dan gaya yang berbeda untuk sisi yang berbeda dari satu sel?**

Ya. Batas [top](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderTop--)/[bottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderBottom--)/[left](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderLeft--)/[right](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderRight--) memiliki properti terpisah, sehingga ketebalan dan gaya setiap sisi dapat berbeda.

**Apa yang terjadi pada gambar jika saya mengubah ukuran kolom/baris setelah menetapkan gambar sebagai latar belakang sel?**

Perilaku tergantung pada [mode isi](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/) (stretch/tile). Dengan stretch, gambar menyesuaikan diri dengan sel yang baru; dengan tile, ubin dihitung ulang.

**Apakah saya dapat menetapkan hyperlink ke seluruh konten sel?**

[Hyperlink](/slides/id/androidjava/manage-hyperlinks/) diatur pada tingkat teks (bagian) di dalam bingkai teks sel atau pada tingkat seluruh tabel/bentuk. Pada praktiknya, Anda menetapkan tautan ke bagian atau ke seluruh teks dalam sel.

**Apakah saya dapat mengatur font yang berbeda dalam satu sel?**

Ya. Bingkai teks sel mendukung [portions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/) (run) dengan format independen—famili font, gaya, ukuran, dan warna.