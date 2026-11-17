---
title: "Kelola Sel Tabel dalam Presentasi Menggunakan Java"
linktitle: "Kelola Sel"
type: docs
weight: 30
url: /id/java/manage-cells/
keywords:
- "sel tabel"
- "gabungkan sel"
- "hapus batas"
- "pisah sel"
- "gambar dalam sel"
- "warna latar belakang"
- "PowerPoint"
- "presentasi"
- "Java"
- "Aspose.Slides"
description: "Kelola sel tabel PowerPoint di Java: identifikasi sel yang digabungkan, hapus batas, pisah sel, dan atur warna latar belakang serta gambar dengan Aspose.Slides untuk Java."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda mengakses dan memodifikasi sel tabel dalam presentasi PowerPoint. Artikel ini menjelaskan cara mengidentifikasi sel tabel yang digabungkan, menghapus batas sel, bekerja dengan penomoran sel setelah menggabungkan atau memisahkan sel, mengubah warna latar belakang sel, dan menambahkan gambar di dalam sel tabel. Contoh-contoh menunjukkan cara membuat atau membuka presentasi, mengambil tabel dari slide, memperbarui format sel melalui properti sel, dan menyimpan presentasi yang telah dimodifikasi sebagai file PPTX.

Aspose.Slides menggunakan indeks berbasis nol untuk mengakses sel tabel dengan urutan `(column, row)`.

## **Mengidentifikasi Sel Tabel yang Digabungkan**

Contoh membuka presentasi yang ada dan mengakses bentuk pertama pada slide pertama sebagai tabel. Itu mengasumsikan bahwa slide dan bentuk ada serta bentuk tersebut adalah tabel. Selanjutnya, iterasi melalui semua baris dan kolom dan menggunakan [isMergedCell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#isMergedCell--) untuk mengidentifikasi sel dalam wilayah yang digabungkan. Untuk setiap kecocokan, program mencetak koordinat sel dalam urutan `row;column`, [getRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getRowSpan--), [getColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getColSpan--), dan koordinat awal wilayah, [getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--) serta [getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--).

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

## **Menghapus Batas Sel Tabel**

Buah [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) dan tambahkan tabel ke slide pertamanya dengan [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---). Lebar kolom, tinggi baris, dan posisi tabel ditentukan dalam poin. Contoh menetapkan semua empat batas sel menjadi [FillType.NoFill](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/), sehingga tidak terlihat.

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

## **Menambahkan Batas Sel Diagonal**

Gunakan [getBorderDiagonalDown](https://reference.aspose.com/slides/java/com.aspose.slides/icellformat/#getBorderDiagonalDown--) untuk menggambar garis dari sudut kiri atas ke kanan bawah, dan [getBorderDiagonalUp](https://reference.aspose.com/slides/java/com.aspose.slides/icellformat/#getBorderDiagonalUp--) untuk menggambar garis dari sudut kiri bawah ke kanan atas. Garis diagonal dapat menandai header sudut; kedua diagonal dapat membentuk X untuk menandai sel yang tidak berlaku.

Setiap diagonal adalah [ILineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/). Di dalam [getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getFillFormat--), gunakan [setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) untuk memilih [FillType.Solid](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) dan memilih warna melalui [getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--). Atur lebar garis dalam poin dengan [setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setWidth-double-).

Contoh membuat tiga sel dalam satu baris: diagonal menurun berwarna merah, diagonal naik berwarna biru, dan kedua diagonal. Batas sel atas, bawah, kiri, dan kanan tetap tidak berubah.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 210, 210, 210 };
    double[] rowHeights = { 160 };
    ITable table = slide.getShapes().addTable(45, 130, columnWidths, rowHeights);

    ILineFormat downwardBorder = table.get_Item(0, 0).getCellFormat().getBorderDiagonalDown();
    downwardBorder.getFillFormat().setFillType(FillType.Solid);
    downwardBorder.getFillFormat().getSolidFillColor().setColor(Color.RED);
    downwardBorder.setWidth(3);

    ILineFormat upwardBorder = table.get_Item(1, 0).getCellFormat().getBorderDiagonalUp();
    upwardBorder.getFillFormat().setFillType(FillType.Solid);
    upwardBorder.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    upwardBorder.setWidth(5);

    ILineFormat crossDownwardBorder = table.get_Item(2, 0).getCellFormat().getBorderDiagonalDown();
    crossDownwardBorder.getFillFormat().setFillType(FillType.Solid);
    crossDownwardBorder.getFillFormat().getSolidFillColor().setColor(Color.RED);
    crossDownwardBorder.setWidth(3);

    ILineFormat crossUpwardBorder = table.get_Item(2, 0).getCellFormat().getBorderDiagonalUp();
    crossUpwardBorder.getFillFormat().setFillType(FillType.Solid);
    crossUpwardBorder.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    crossUpwardBorder.setWidth(5);

    presentation.save("diagonal_cell_borders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Diagonal adalah properti pemformatan, bukan pemisahan sel. Setiap sel mempertahankan satu bingkai teks, diakses melalui [getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getTextFrame--); wilayah di kedua sisi diagonal tidak dapat diedit secara terpisah.

Tabel yang disimpan, dirender di Microsoft PowerPoint:

![Tiga sel tabel yang menunjukkan diagonal merah dari kiri atas ke kanan bawah, diagonal biru dari kiri bawah ke kanan atas, dan kedua diagonal membentuk X.](diagonal-cell-borders.png)

*Dari kiri ke kanan: diagonal menurun (merah, 3 pt), diagonal naik (biru, 5 pt), dan kedua diagonal.*

## **Menggabungkan Sel Tabel**

Gunakan [mergeCells](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#mergeCells-com.aspose.slides.ICell-com.aspose.slides.ICell-boolean-) untuk menggabungkan rentang persegi panjang sel tabel menjadi satu sel. Tentukan sel di sudut kiri atas dan kanan bawah rentang. Argumen terakhir mengontrol apakah penggabungan dapat mencakup sel di luar rentang yang ditentukan; `false` menjaga penggabungan tetap dalam rentang tersebut.

Contoh membuat tabel 4x4 dengan kolom dan baris 70 poin, kemudian menggabungkan empat sel tengah dari `(1, 1)` hingga `(2, 2)`. Sel hasil menggabungkan mencakup dua kolom dan dua baris, sementara grid tabel yang mendasari tetap memiliki empat kolom dan empat baris. Untuk mengakses konten atau pemformatan sel yang digabungkan, gunakan posisi kiri atasnya: `table.get_Item(1, 1)` dalam contoh ini. Posisi lain dalam rentang yang digabungkan tetap menjadi bagian dari grid tabel, sehingga indeks sel di luar rentang tidak berubah.

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

Menggabungkan sel pada contoh sebelumnya mempertahankan grid tabel. Memisahkan sel dapat menambahkan kolom grid baru dan mengubah indeks kolom sel di sebelah kanannya. Aspose.Slides mengikuti model grid tabel PowerPoint.

Contoh ini membuat tabel 4x4 dengan kolom dan baris 70 poin dan memanggil [splitByWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByWidth-double-) pada sel `(1, 1)`. Setengah dari lebar 70 poin sel tersebut diberikan untuk membuat dua sel dengan lebar sama.

Setelah pemisahan ini, dua bagian diakses sebagai `table.get_Item(1, 1)` dan `table.get_Item(2, 1)`. Grid tabel kini memiliki lima kolom: sel yang semula berada di kolom 2 dan 3 berpindah ke kolom 3 dan 4, masing-masing. Indeks baris tetap tidak berubah. Gunakan indeks kolom yang diperbarui ini saat mengakses sel setelah pemisahan.

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

<!-- visual-explanation:manage-cells:start -->
[![Sel 70 poin yang tidak digabung menjadi dua sel 35 poin, menambahkan kolom grid kelima dan menggeser indeks di sebelah kanannya.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*Pemecahan lebar memengaruhi sel (1, 1), menggunakan indeks berbasis nol (kolom, baris). Baris lain tetap memiliki sel yang mencakup kedua posisi kolom baru.*
<!-- visual-explanation:manage-cells:end -->

### **Memisahkan Sel yang Digabungkan berdasarkan Rentang Baris atau Kolom**

Untuk menyiapkan sel templat yang digabungkan bagi pengisian data, gunakan [splitByRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByRowSpan-int-) untuk memisahkan sepanjang batas baris yang ada, atau [splitByColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByColSpan-int-) untuk memisahkan sepanjang batas kolom.

Argumen `index` menghitung baris pada bagian atas atau kolom pada bagian kiri dari pemisahan; nilainya relatif terhadap wilayah yang digabungkan:

- Pemisahan baris: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getRowSpan--).
- Pemisahan kolom: `0 < index <` [getColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getColSpan--).

Contoh mengharapkan presentasi memiliki tabel sebagai bentuk pertama pada slide pertama, dengan `(1, 2)` dan `(1, 3)` digabung secara vertikal. Dimulai dari posisi bawah, contoh menggunakan [getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--) dan [getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--) untuk menemukan asal dan memeriksa kedua rentang. `splitByRowSpan(1)` kemudian memisahkan baris 2 dan 3 untuk nama produk. Untuk penggabungan dua kolom horizontal, gunakan `splitByColSpan(1)`.

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

        // Dapatkan sel yang dihasilkan dari tabel setelah pemisahan.
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

Grid tabel dan indeks sel di sekitarnya tetap tidak berubah. Dapatkan sel yang dihasilkan dengan koordinatnya; di sini, keduanya memiliki rentang 1 dan [isMergedCell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#isMergedCell--) mencetak `false`. Wilayah yang lebih besar dapat tetap sebagian digabung setelah satu pemisahan.

Teks asli dan pemformatannya tetap berada di sel atas (atau kiri); sel baru kosong tetapi mewarisi pemformatan sel seperti isi, batas, dan margin. Isi sel setelah pemisahan dan atur pemformatan teks yang diperlukan secara eksplisit.

Presentasi yang disimpan berisi sel terpisah "Product A" dan "Product B" dengan pemformatan sel template yang dipertahankan. Lihat [Cell API Reference](https://reference.aspose.com/slides/java/com.aspose.slides/cell/) untuk detail.

### **Memisahkan Sel pada Tinggi Tertentu**

[splitByHeight](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByHeight-double-) mengambil tinggi bagian atas dalam poin. [splitByRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByRowSpan-int-) mengambil jumlah baris grid yang ada pada bagian atas. Untuk menempatkan sel 40 poin di tengah kolom kanan, kurangi 40 dari tinggi aktual sel dan bagi sisa ruang secara merata di atas dan di bawahnya.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 160, 160 };
    double[] rowHeights = { 140 };
    
    ITable table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);
    table.get_Item(0, 0).getTextFrame().setText("Left");

    double height = table.get_Item(1, 0).getHeight();
    double margin = (height - 40) / 2;

    table.get_Item(1, 0).splitByHeight(margin);
    table.get_Item(1, 1).splitByHeight(40);
    table.get_Item(1, 1).getTextFrame().setText("Middle");

    presentation.save("split_by_height.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pemecahan pertama menambahkan baris grid dan menyisakan 90 poin di bagian bawah sel `(1, 1)`. Pemecahan kedua membagi sel tersebut menjadi sel tengah 40 poin dan sel bawah 50 poin. Kolom kanan kini memiliki tiga sel dengan tinggi 50, 40, dan 50 poin dari atas ke bawah. Sel kiri mencakup ketiga baris dan mempertahankan tinggi aslinya 140 poin.

![Sel kiri mencakup seluruh tinggi tabel di samping tiga sel dengan Tengah di tengah.](split-by-height.png)

## **Mengubah Warna Latar Belakang Sel Tabel**

Contoh ini membuat tabel dengan kolom 150 poin dan baris 50 poin. Ini menggunakan [setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) untuk memilih isi padat dan mengatur warna yang dikembalikan oleh [getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--) menjadi merah untuk sel `(2, 3)`, di kolom ketiga dan baris keempat.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

## **Menambahkan Gambar di Dalam Sel Tabel**

Letakkan gambar input di direktori kerja sebelum menjalankan contoh ini. Itu memuat gambar dengan [Images.fromFile](https://reference.aspose.com/slides/java/com.aspose.slides/images/#fromFile-java.lang.String-) dan menambahkannya ke koleksi gambar presentasi dengan [addImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimagecollection/#addImage-com.aspose.slides.IImage-). Kemudian gambar tersebut diberikan ke isian gambar sel `(0, 0)`, sel pertama dalam tabel.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillmode/) memperluas gambar untuk mengisi sel, yang dapat mengubah rasio aspeknya. Lebar kolom dan tinggi baris dalam poin. Gambar yang dimuat dibuang dalam blok `finally` setelah ditambahkan ke presentasi.

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

Ya. Batas [top](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderTop--)/[bottom](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderBottom--)/[left](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderLeft--)/[right](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderRight--) memiliki properti terpisah, sehingga ketebalan dan gaya setiap sisi dapat berbeda.

**Apa yang terjadi pada gambar jika saya mengubah ukuran kolom/bari setelah menetapkan gambar sebagai latar belakang sel?**

Perilakunya tergantung pada [fill mode](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillmode/). Dengan stretching, gambar menyesuaikan diri dengan sel baru; dengan tiling, ubin dihitung ulang.

**Apakah saya dapat menetapkan hyperlink ke seluruh konten sel?**

[Hyperlinks](/slides/id/java/manage-hyperlinks/) ditetapkan pada tingkat teks (bagian) di dalam bingkai teks sel atau pada tingkat seluruh tabel/bentuk. Pada praktiknya, Anda menetapkan tautan ke bagian atau ke seluruh teks dalam sel.

**Apakah saya dapat mengatur font yang berbeda dalam satu sel?**

Ya. Bingkai teks sel mendukung [portions](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) (run) dengan pemformatan independen—jenis font, gaya, ukuran, dan warna.