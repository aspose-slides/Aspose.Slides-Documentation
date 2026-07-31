---
title: Menambahkan Bentuk Garis ke Presentasi di Android
linktitle: Garis
type: docs
weight: 50
url: /id/androidjava/line/
keywords:
- garis
- membuat garis
- menambahkan garis
- garis polos
- mengonfigurasi garis
- menyesuaikan garis
- gaya dash
- kepala panah
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Pelajari cara memanipulasi format garis dalam presentasi PowerPoint dengan Aspose.Slides untuk Android. Temukan properti, metode, dan contoh Java."
---
## **Overview**

Aspose.Slides memungkinkan Anda menambahkan bentuk garis ke slide PowerPoint secara programatis. Artikel ini menunjukkan cara membuat garis sederhana dan cara menyesuaikan garis sehingga tampil seperti panah.

Anda akan mempelajari cara menambahkan bentuk garis ke slide, menyesuaikan tampilan visualnya, dan menyimpan presentasi yang telah diperbarui. Contoh‑contoh berfokus pada pengaturan format garis praktis seperti gaya, lebar, pola dash, opsi kepala panah, dan warna isi.

## **Create a Plain Line**

Untuk menambahkan garis biasa sederhana ke slide terpilih dalam presentasi, ikuti langkah‑langkah berikut:

- Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation).
- Dapatkan referensi slide dengan menggunakan Index‑nya.
- Tambahkan AutoShape tipe Line menggunakan metode [addAutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) yang tersedia pada objek [IShapeCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IShapeCollection).
- Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Pada contoh di bawah ini, kami telah menambahkan garis ke slide pertama presentasi.

```java
// Membuat instance kelas PresentationEx yang mewakili file PPTX
Presentation pres = new Presentation();
try {
    // Dapatkan slide pertama
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Tambahkan AutoShape tipe line
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // Simpan PPTX ke Disk
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Create an Arrow-Shaped Line**

Aspose.Slides untuk Android via Java juga memungkinkan pengembang mengonfigurasi beberapa properti garis supaya tampak lebih menarik. Mari kita coba mengonfigurasi beberapa properti agar garis terlihat seperti panah. Ikuti langkah‑langkah berikut:

- Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation).
- Dapatkan referensi slide dengan menggunakan Index‑nya.
- Tambahkan AutoShape tipe Line menggunakan metode [addAutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) yang tersedia pada objek [IShapeCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IShapeCollection).
- Atur [Line Style](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/LineStyle) ke salah satu gaya yang disediakan oleh Aspose.Slides untuk Android via Java.
- Atur Width garis.
- Atur [Dash Style](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/LineDashStyle) garis ke salah satu gaya yang disediakan oleh Aspose.Slides untuk Android via Java.
- Atur [Arrow Head Style](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/LineArrowheadStyle) dan [Length](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/LineArrowheadLength) pada titik awal garis.
- Atur [Arrow Head Style](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/LineArrowheadStyle) dan [Length](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/LineArrowheadLength) pada titik akhir garis.
- Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

```java
// Membuat instance kelas PresentationEx yang mewakili file PPTX
Presentation pres = new Presentation();
try {
    // Dapatkan slide pertama
    ISlide sld = pres.getSlides().get_Item(0);

    // Tambahkan AutoShape tipe line
    IAutoShape shp = sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Terapkan beberapa format pada garis
    shp.getLineFormat().setStyle(LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);

    shp.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    shp.getLineFormat().setBeginArrowheadLength(LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.Oval);

    shp.getLineFormat().setEndArrowheadLength(LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);

    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Maroon));

    // Simpan PPTX ke Disk
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Can I convert a regular line into a connector so it "snaps" to shapes?**

Tidak. Garis biasa (sebuah [AutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/autoshape/) berjenis [Line](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/shapetype/)) tidak otomatis menjadi konektor. Untuk membuatnya menempel pada bentuk, gunakan tipe [Connector](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/connector/) khusus dan [corresponding APIs](/slides/id/androidjava/connector/) untuk koneksi.

**What should I do if a line’s properties are inherited from the theme and it’s hard to determine the final values?**

[Baca properti efektif](/slides/id/androidjava/shape-effective-properties/) melalui antarmuka [ILineFormatEffectiveData](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ilinefillformateffectivedata/)—mereka sudah memperhitungkan pewarisan dan gaya tema.

**Can I lock a line against editing (moving, resizing)?**

Ya. Bentuk menyediakan [lock objects](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/autoshape/#getAutoShapeLock--) yang memungkinkan Anda melarang operasi pengeditan.