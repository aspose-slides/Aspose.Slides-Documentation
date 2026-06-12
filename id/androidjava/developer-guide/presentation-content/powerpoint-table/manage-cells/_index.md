---
title: Kelola Sel Tabel dalam Presentasi di Android
linktitle: Kelola Sel
type: docs
weight: 30
url: /id/androidjava/manage-cells/
keywords:
- sel tabel
- menggabungkan sel
- menghapus batas
- memisah sel
- gambar dalam sel
- warna latar belakang
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Kelola sel tabel di PowerPoint dengan Aspose.Slides untuk Android melalui Java dengan mudah. Kuasai cara mengakses, memodifikasi, dan menata sel dengan cepat untuk otomasi slide yang mulus."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda mengakses dan memodifikasi sel tabel dalam presentasi PowerPoint. Artikel ini menjelaskan cara mengidentifikasi sel tabel yang digabung, menghapus batas sel, bekerja dengan penomoran sel setelah penggabungan atau pemisahan sel, mengubah warna latar belakang sel, dan menambahkan gambar di dalam sel tabel. Contoh-contohnya menunjukkan cara membuat atau membuka presentasi, mendapatkan tabel dari slide, memperbarui format sel melalui properti sel, dan menyimpan presentasi yang telah dimodifikasi sebagai file PPTX.

## **Identifikasi Sel Tabel yang Digabung**
1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation).
2. Dapatkan tabel dari slide pertama. 
3. Iterasi baris dan kolom tabel untuk menemukan sel yang digabung.
4. Tampilkan pesan ketika sel yang digabung ditemukan.

Kode Java ini menunjukkan cara mengidentifikasi sel tabel yang digabung dalam sebuah presentasi:

```java
Presentation pres = new Presentation("SomePresentationWithTable.pptx");
try {
    ITable table = (ITable)pres.getSlides().get_Item(0).getShapes().get_Item(0); // dengan asumsi bahwa Slide#0.Shape#0 adalah sebuah tabel
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

## **Hapus Batas Sel Tabel**
1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation).
2. Dapatkan referensi slide melalui indeksnya. 
3. Definisikan array kolom dengan lebar.
4. Definisikan array baris dengan tinggi.
5. Tambahkan tabel ke slide melalui metode [addTable](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-).
6. Iterasi setiap sel untuk menghapus batas atas, bawah, kanan, dan kiri.
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

## **Penomoran pada Sel yang Digabung**
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

Selanjutnya kita menggabungkan sel lebih lanjut dengan menggabungkan (1, 1) dan (1, 2). Hasilnya adalah tabel yang berisi sel besar yang digabung di tengahnya:

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
	
	// Menulis file PPTX ke disk
    pres.save("MergeCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Penomoran pada Sel yang Dipisah**
Pada contoh sebelumnya, ketika sel tabel digabung, sistem penomoran pada sel lain tidak berubah.

Kali ini, kita mengambil tabel biasa (tabel tanpa sel yang digabung) dan kemudian memisah sel (1,1) untuk mendapatkan tabel khusus. Perhatikan penomoran tabel ini, yang mungkin tampak aneh. Namun, itulah cara Microsoft PowerPoint menomori sel tabel dan Aspose.Slides melakukan hal yang sama.

Kode Java ini mendemonstrasikan proses yang dijelaskan:

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

    // Memisahkan sel (1, 1)
    tbl.get_Item(1, 1).splitByWidth(tbl.get_Item(2, 1).getWidth() / 2);

    // Menulis file PPTX ke disk
    pres.save("SplitCells_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ubah Warna Latar Sel Tabel**

Kode Java ini menunjukkan cara mengubah warna latar belakang sel tabel:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] dblCols = { 150, 150, 150, 150 };
    double[] dblRows = { 50, 50, 50, 50, 50 };

    // buat tabel baru
    ITable table = slide.getShapes().addTable(50, 50, dblCols, dblRows);

    // set warna latar belakang untuk sebuah sel 
    ICell cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid);
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Tambahkan Gambar di Dalam Sel Tabel**

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation).
2. Dapatkan referensi slide melalui indeksnya.
3. Definisikan array kolom dengan lebar.
4. Definisikan array baris dengan tinggi.
5. Tambahkan tabel ke slide melalui metode [AddTable](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IShapeCollection#addTable-float-float-double:A-double:A-).
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

**Apakah saya dapat mengatur ketebalan dan gaya garis yang berbeda untuk setiap sisi sebuah sel?**

Ya. Batas [top](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/cellformat/#getBorderTop--)/[bottom](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/cellformat/#getBorderBottom--)/[left](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/cellformat/#getBorderLeft--)/[right](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/cellformat/#getBorderRight--) memiliki properti terpisah, sehingga ketebalan dan gaya masing‑masing sisi dapat berbeda. Ini secara logis mengikuti kontrol batas per sisi untuk sebuah sel yang ditunjukkan dalam artikel.

**Apa yang terjadi pada gambar jika saya mengubah ukuran kolom/baris setelah menetapkan gambar sebagai latar belakang sel?**

Perilaku bergantung pada [fill mode](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/picturefillmode/) (stretch/tile). Dengan stretch, gambar menyesuaikan dengan sel baru; dengan tile, ubin‑ubin dihitung ulang. Artikel menyebutkan mode tampilan gambar dalam sel.

**Bisakah saya menambahkan hyperlink ke seluruh konten sebuah sel?**

[Hyperlinks](/slides/id/androidjava/manage-hyperlinks/) diatur pada tingkat teks (portion) di dalam frame teks sel atau pada tingkat seluruh tabel/bentuk. Pada praktiknya, Anda menambahkan tautan ke bagian teks atau ke seluruh teks dalam sel.

**Bisakah saya mengatur font yang berbeda di dalam satu sel?**

Ya. Frame teks sebuah sel mendukung [portions](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/portion/) (run) dengan format independen—jenis font, gaya, ukuran, dan warna.