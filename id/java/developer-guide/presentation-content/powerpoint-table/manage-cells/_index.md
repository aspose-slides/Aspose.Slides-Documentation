---
title: Kelola Sel Tabel dalam Presentasi Menggunakan Java
linktitle: Kelola Sel
type: docs
weight: 30
url: /id/java/manage-cells/
keywords:
- sel tabel
- menggabungkan sel
- menghapus batas
- memisahkan sel
- gambar dalam sel
- warna latar belakang
- PowerPoint
- presentasi
- Java
- Aspose.Slides
description: "Kelola sel tabel di PowerPoint dengan mudah menggunakan Aspose.Slides untuk Java. Kuasai cara mengakses, memodifikasi, dan menata sel dengan cepat untuk otomatisasi slide yang mulus."
---
## **Ikhtisar**

Aspose.Slides memungkinkan Anda mengakses dan memodifikasi sel tabel dalam presentasi PowerPoint. Artikel ini menjelaskan cara mengidentifikasi sel tabel yang digabung, menghapus batas sel, bekerja dengan penomoran sel setelah menggabungkan atau memisahkan sel, mengubah warna latar belakang sel, dan menambahkan gambar di dalam sel tabel. Contoh-contohnya menunjukkan cara membuat atau membuka sebuah presentasi, mengambil tabel dari slide, memperbarui format sel melalui properti sel, dan menyimpan presentasi yang telah dimodifikasi sebagai file PPTX.

## **Mengidentifikasi Sel Tabel yang Digabung**
1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation).
2. Dapatkan tabel dari slide pertama.
3. Iterasi melalui baris dan kolom tabel untuk menemukan sel yang digabung.
4. Cetak pesan saat sel yang digabung ditemukan.

Kode Java ini menunjukkan cara mengidentifikasi sel tabel yang digabung dalam sebuah presentasi:

```java
Presentation pres = new Presentation("SomePresentationWithTable.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0); // dengan asumsi bahwa Slide#0.Shape#0 adalah tabel
    for (int i = 0; i < table.getRows().size(); i++)
    {
        for (int j = 0; j < table.getColumns().size(); j++)
        {
            ICell currentCell = table.getRows().get_Item(i).get_Item(j);
            if (currentCell.isMergedCell())
            {
                System.out.println(String.format("Cell %d;%d is a part of merged cell with RowSpan=%d and ColSpan=%d starting from Cell %d;%d.",
                        i, j, currentCell.getRowSpan(), currentCell.getColSpan(), currentCell.getFirstRowIndex(), currentCell.getFirstColumnIndex()));
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Menghapus Batas Sel Tabel**
1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation).
2. Dapatkan referensi slide melalui indeksnya.
3. Definisikan array kolom dengan lebar.
4. Definisikan array baris dengan tinggi.
5. Tambahkan tabel ke slide melalui metode [addTable](https://reference.aspose.com/slides/id/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-).
6. Iterasi melalui setiap sel untuk menghapus batas atas, bawah, kanan, dan kiri.
7. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode Java ini menunjukkan cara menghapus batas dari sel tabel:

```java
// Membuat instance kelas Presentation yang mewakili file PPTX
Presentation pres = new Presentation();
try {
    // Mengakses slide pertama
    Slide sld = (Slide)pres.getSlides().get_Item(0);

    // Mendefinisikan kolom dengan lebar dan baris dengan tinggi
    double[] dblCols = { 50, 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Menambahkan bentuk tabel ke slide
    ITable tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);

    // Mengatur format batas untuk setiap sel
    for (IRow row : tbl.getRows())
    {
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill);
        }
    }

    // Menulis PPTX ke disk
    pres.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Penomoran dalam Sel yang Digabung**
Jika kita menggabungkan 2 pasang sel (1, 1) x (2, 1) dan (1, 2) x (2, 2), tabel yang dihasilkan akan bernomor. Kode Java ini mendemonstrasikan prosesnya:

```java
// Membuat instance kelas Presentation yang mewakili file PPTX
Presentation pres = new Presentation();
try {
    // Mengakses slide pertama
    ISlide sld = pres.getSlides().get_Item(0);

    // Mendefinisikan kolom dengan lebar dan baris dengan tinggi
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Menambahkan bentuk tabel ke slide
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

    // Menggabungkan sel (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // Menggabungkan sel (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Kemudian kita menggabungkan sel lebih lanjut dengan menggabungkan (1, 1) dan (1, 2). Hasilnya adalah tabel yang berisi sel besar yang digabung di tengahnya:

```java
// Membuat instance kelas Presentation yang mewakili file PPTX
Presentation pres = new Presentation();
try {
    // Mengakses slide pertama
    ISlide sld = pres.getSlides().get_Item(0);

    // Mendefinisikan kolom dengan lebar dan baris dengan tinggi
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Menambahkan bentuk tabel ke slide
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

    // Menggabungkan sel (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // Menggabungkan sel (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    // Menggabungkan sel (1, 1) x (1, 2)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(1, 2), true);
	
	//Menulis file PPTX ke disk
    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Penomoran dalam Sel yang Dipisah**
Pada contoh sebelumnya, ketika sel tabel digabung, sistem penomoran atau nomor di sel lain tidak berubah.

Kali ini, kami mengambil tabel biasa (tabel tanpa sel yang digabung) dan kemudian mencoba memisahkan sel (1,1) untuk mendapatkan tabel khusus. Anda mungkin ingin memperhatikan penomoran tabel ini, yang mungkin terlihat aneh. Namun, itulah cara Microsoft PowerPoint menomori sel tabel dan Aspose.Slides melakukan hal yang sama.

Kode Java ini mendemonstrasikan proses yang kami jelaskan:

```java
// Membuat instance kelas Presentation yang mewakili file PPTX
Presentation pres = new Presentation();
try {
    // Mengakses slide pertama
    ISlide sld = pres.getSlides().get_Item(0);

    // Mendefinisikan kolom dengan lebar dan baris dengan tinggi
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Menambahkan bentuk tabel ke slide
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

    // Menggabungkan sel (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);

    // Menggabungkan sel (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);

    // Membagi sel (1, 1)
    tbl.get_Item(1, 1).splitByWidth(tbl.get_Item(2, 1).getWidth() / 2);

    // Menulis file PPTX ke disk
    pres.save("SplitCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Mengubah Warna Latar Belakang Sel Tabel**

Kode Java ini menunjukkan cara mengubah warna latar belakang sel tabel:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 50, 50, 50, 50, 50 };

    // buat tabel baru
    ITable table = slide.getShapes().addTable(50, 50, dblCols, dblRows);

    // atur warna latar belakang untuk sebuah sel
    ICell cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid);
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Menambahkan Gambar di Dalam Sel Tabel**

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation).
2. Dapatkan referensi slide melalui indeksnya.
3. Definisikan array kolom dengan lebar.
4. Definisikan array baris dengan tinggi.
5. Tambahkan tabel ke slide melalui metode [AddTable](https://reference.aspose.com/slides/id/java/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-).
6. Buat objek `Images` untuk menyimpan file gambar.
7. Tambahkan gambar `IImage` ke objek `IPPImage`.
8. Atur `FillFormat` untuk Sel Tabel menjadi `Picture`.
9. Tambahkan gambar ke sel pertama tabel.
10. Simpan presentasi yang telah dimodifikasi sebagai file PPTX

Kode Java ini menunjukkan cara menempatkan gambar di dalam sel tabel saat membuat tabel:

```java
// Membuat instance kelas Presentation yang mewakili file PPTX
Presentation pres = new Presentation();
try {
    // Mengakses slide pertama
    ISlide islide = pres.getSlides().get_Item(0);

    // Mendefinisikan kolom dengan lebar dan baris dengan tinggi
    double[] dblCols = {150, 150, 150, 150};
    double[] dblRows = {100, 100, 100, 100, 90};

    // Menambahkan bentuk tabel ke slide
    ITable tbl = islide.getShapes().addTable(50, 50, dblCols, dblRows);

    // Membuat objek IPPImage menggunakan file gambar
    IPPImage picture;
    IImage image = Images.fromFile("image.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Menambahkan gambar ke sel tabel pertama
    ICellFormat cellFormat = tbl.get_Item(0, 0).getCellFormat();
    cellFormat.getFillFormat().setFillType(FillType.Picture);
    cellFormat.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    cellFormat.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Menyimpan file PPTX ke disk
    pres.save("Image_In_TableCell_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Apakah saya dapat mengatur ketebalan dan gaya garis yang berbeda untuk sisi yang berbeda dari satu sel?**

Ya. Batas [top](https://reference.aspose.com/slides/id/java/com.aspose.slides/cellformat/#getBorderTop--)/[bottom](https://reference.aspose.com/slides/id/java/com.aspose.slides/cellformat/#getBorderBottom--)/[left](https://reference.aspose.com/slides/id/java/com.aspose.slides/cellformat/#getBorderLeft--)/[right](https://reference.aspose.com/slides/id/java/com.aspose.slides/cellformat/#getBorderRight--) memiliki properti terpisah, sehingga ketebalan dan gaya tiap sisi dapat berbeda. Hal ini secara logis mengikuti kontrol batas per sisi untuk sebuah sel yang ditunjukkan dalam artikel.

**Apa yang terjadi pada gambar jika saya mengubah ukuran kolom/baris setelah menetapkan gambar sebagai latar belakang sel?**

Perilaku tergantung pada [fill mode](https://reference.aspose.com/slides/id/java/com.aspose.slides/picturefillmode/) (stretch/tile). Dengan stretching, gambar menyesuaikan dengan sel yang baru; dengan tiling, ubin dihitung ulang. Artikel tersebut menyebutkan mode tampilan gambar dalam sel.

**Apakah saya dapat menetapkan hyperlink ke seluruh konten sel?**

[Hyperlinks](/slides/id/java/manage-hyperlinks/) diatur pada tingkat teks (bagian) di dalam bingkai teks sel atau pada tingkat seluruh tabel/bentuk. Pada praktiknya, Anda menetapkan tautan ke bagian atau ke seluruh teks dalam sel.

**Apakah saya dapat mengatur font yang berbeda dalam satu sel?**

Ya. Bingkai teks sel mendukung [portions](https://reference.aspose.com/slides/id/java/com.aspose.slides/portion/) (run) dengan format independen—jenis font, gaya, ukuran, dan warna.