---
title: Tambahkan Bentuk Garis ke Presentasi di Android
linktitle: Garis
type: docs
weight: 50
url: /id/androidjava/Line/
keywords:
- garis
- buat garis
- tambahkan garis
- garis biasa
- konfigurasi garis
- sesuaikan garis
- gaya putus
- kepala panah
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Pelajari cara memanipulasi pemformatan garis dalam presentasi PowerPoint dengan Aspose.Slides untuk Android. Temukan properti, metode, dan contoh Java."
---
## **Ikhtisar**

Aspose.Slides memungkinkan Anda menambahkan bentuk garis ke slide PowerPoint secara programatis. Artikel ini menunjukkan cara membuat garis sederhana dan cara menyesuaikan garis sehingga muncul sebagai panah.

Anda akan belajar cara menambahkan bentuk garis ke slide, menyesuaikan tampilan visualnya, dan menyimpan presentasi yang diperbarui. Contoh-contoh berfokus pada pengaturan pemformatan garis praktis seperti gaya, lebar, pola putus, opsi kepala panah, dan warna isi.

## **Buat Garis Biasa**

Untuk menambahkan garis biasa sederhana ke slide yang dipilih dalam presentasi, ikuti langkah-langkah berikut:

- Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation) .
- Dapatkan referensi slide dengan menggunakan Indeksnya.
- Tambahkan AutoShape tipe Line menggunakan metode [addAutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) yang disediakan oleh objek [IShapeCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IShapeCollection) .
- Tuliskan presentasi yang telah dimodifikasi sebagai file PPTX.

Dalam contoh di bawah ini, kami telah menambahkan garis ke slide pertama presentasi.

```java
// Instansiasi kelas PresentationEx yang mewakili file PPTX
Presentation pres = new Presentation();
try {
    // Ambil slide pertama
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Tambahkan AutoShape tipe garis
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // Tuliskan PPTX ke Disk
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Buat Garis Berbentuk Panah**

Aspose.Slides for Android via Java juga memungkinkan pengembang mengonfigurasi beberapa properti garis agar tampak lebih menarik. Mari coba mengonfigurasi beberapa properti garis agar terlihat seperti panah. Ikuti langkah-langkah berikut untuk melakukannya:

- Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation) .
- Dapatkan referensi slide dengan menggunakan Indeksnya.
- Tambahkan AutoShape tipe Line menggunakan metode [addAutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) yang disediakan oleh objek [IShapeCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IShapeCollection) .
- Setel [Line Style](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/LineStyle) ke salah satu gaya yang disediakan oleh Aspose.Slides for Android via Java.
- Setel Lebar garis.
- Setel [Dash Style](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/LineDashStyle) garis ke salah satu gaya yang disediakan oleh Aspose.Slides for Android via Java.
- Setel [Arrow Head Style](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/LineArrowheadStyle) dan [Length](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/LineArrowheadLength) titik awal garis.
- Setel [Arrow Head Style](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/LineArrowheadStyle) dan [Length](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/LineArrowheadLength) titik akhir garis.
- Tuliskan presentasi yang telah dimodifikasi sebagai file PPTX.

```java
// Instansiasi kelas PresentationEx yang mewakili file PPTX
Presentation pres = new Presentation();
try {
    // Ambil slide pertama
    ISlide sld = pres.getSlides().get_Item(0);

    // Tambahkan AutoShape tipe garis
    IAutoShape shp = sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Terapkan beberapa pemformatan pada garis
    shp.getLineFormat().setStyle(LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);

    shp.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    shp.getLineFormat().setBeginArrowheadLength(LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.Oval);

    shp.getLineFormat().setEndArrowheadLength(LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);

    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Maroon));

    // Tuliskan PPTX ke Disk
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Apakah saya dapat mengonversi garis biasa menjadi konektor sehingga “menempel” pada bentuk?**

Tidak. Garis biasa (sebuah [AutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/autoshape/) dengan tipe [Line](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/shapetype/)) tidak secara otomatis menjadi konektor. Untuk membuatnya menempel pada bentuk, gunakan tipe [Connector](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/connector/) khusus dan [API yang bersangkutan](/slides/id/androidjava/connector/) untuk koneksi.

**Apa yang harus saya lakukan jika properti garis diwarisi dari tema dan sulit menentukan nilai akhir?**

[Baca properti efektif](/slides/id/androidjava/shape-effective-properties/) melalui antarmuka [ILineFormatEffectiveData](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ilinefillformateffectivedata/) — antarmuka ini sudah memperhitungkan pewarisan dan gaya tema.

**Apakah saya dapat mengunci garis agar tidak dapat diedit (dipindahkan, diubah ukurannya)?**

Ya. Bentuk menyediakan [objek kunci](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/autoshape/#getAutoShapeLock--) yang memungkinkan Anda melarang operasi pengeditan.