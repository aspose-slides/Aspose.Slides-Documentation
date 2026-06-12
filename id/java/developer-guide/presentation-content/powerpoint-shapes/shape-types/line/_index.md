---
title: Menambahkan Bentuk Garis ke Presentasi dalam Java
linktitle: Garis
type: docs
weight: 50
url: /id/java/Line/
keywords:
- garis
- buat garis
- tambahkan garis
- garis polos
- konfigurasi garis
- kustomisasi garis
- gaya putus-putus
- ujung panah
- PowerPoint
- presentasi
- Java
- Aspose.Slides
description: "Pelajari cara memanipulasi format garis dalam presentasi PowerPoint dengan Aspose.Slides for Java. Temukan properti, metode, dan contoh."
---
## **Ikhtisar**

Aspose.Slides memungkinkan Anda menambahkan bentuk garis ke slide PowerPoint secara programatik. Artikel ini menunjukkan cara membuat garis sederhana dan cara menyesuaikan garis sehingga muncul sebagai panah.

Anda akan belajar cara menambahkan bentuk garis ke slide, menyesuaikan penampilan visualnya, dan menyimpan presentasi yang telah diperbarui. Contoh-contoh berfokus pada pengaturan format garis praktis seperti gaya, lebar, pola putus‑putus, opsi ujung panah, dan warna isi.

## **Buat Garis Polos**

Untuk menambahkan sebuah garis polos sederhana ke slide yang dipilih dalam presentasi, ikuti langkah‑langkah di bawah ini:

- Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation).
- Dapatkan referensi slide dengan menggunakan Indeksnya.
- Tambahkan AutoShape tipe Line menggunakan metode [addAutoShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) yang disediakan oleh objek [IShapeCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/IShapeCollection).
- Tuliskan presentasi yang telah dimodifikasi sebagai file PPTX.

Dalam contoh di bawah ini, kami telah menambahkan sebuah garis ke slide pertama presentasi.

```java
// Buat instance kelas PresentationEx yang mewakili file PPTX
Presentation pres = new Presentation();
try {
    // Dapatkan slide pertama
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Tambahkan AutoShape tipe line
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // Tulis PPTX ke Disk
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Buat Garis Berbentuk Panah**

Aspose.Slides for Java juga memungkinkan pengembang mengonfigurasi beberapa properti garis agar terlihat lebih menarik. Mari coba mengonfigurasi beberapa properti garis agar tampak seperti panah. Ikuti langkah‑langkah di bawah ini:

- Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/Presentation).
- Dapatkan referensi slide dengan menggunakan Indeksnya.
- Tambahkan AutoShape tipe Line menggunakan metode [addAutoShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) yang disediakan oleh objek [IShapeCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/IShapeCollection).
- Setel [Line Style](https://reference.aspose.com/slides/id/java/com.aspose.slides/LineStyle) ke salah satu gaya yang disediakan oleh Aspose.Slides for Java.
- Setel Width garis.
- Setel [Dash Style](https://reference.aspose.com/slides/id/java/com.aspose.slides/LineDashStyle) garis ke salah satu gaya yang disediakan oleh Aspose.Slides for Java.
- Setel [Arrow Head Style](https://reference.aspose.com/slides/id/java/com.aspose.slides/LineArrowheadStyle) dan [Length](https://reference.aspose.com/slides/id/java/com.aspose.slides/LineArrowheadLength) titik awal garis.
- Setel [Arrow Head Style](https://reference.aspose.com/slides/id/java/com.aspose.slides/LineArrowheadStyle) dan [Length](https://reference.aspose.com/slides/id/java/com.aspose.slides/LineArrowheadLength) titik akhir garis.
- Tuliskan presentasi yang telah dimodifikasi sebagai file PPTX.

```java
// Buat instance kelas PresentationEx yang mewakili file PPTX
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

    // Tulis PPTX ke Disk
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Bisakah saya mengonversi garis biasa menjadi konektor sehingga ia “menempel” pada bentuk‑bentuk?**

Tidak. Garis biasa (sebuah [AutoShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/autoshape/) tipe [Line](https://reference.aspose.com/slides/id/java/com.aspose.slides/shapetype/)) tidak secara otomatis menjadi konektor. Untuk membuatnya menempel pada bentuk, gunakan tipe [Connector](https://reference.aspose.com/slides/id/java/com.aspose.slides/connector/) khusus dan [API yang sesuai](/slides/id/java/connector/) untuk koneksi.

**Apa yang harus saya lakukan jika properti sebuah garis diwarisi dari tema dan sulit menentukan nilai akhirnya?**

Baca [properti efektif](/slides/id/java/shape-effective-properties/) melalui antarmuka [ILineFormatEffectiveData](https://reference.aspose.com/slides/id/java/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/id/java/com.aspose.slides/ilinefillformateffectivedata/) — antarmuka ini sudah memperhitungkan pewarisan dan gaya tema.

**Bisakah saya mengunci sebuah garis agar tidak dapat diedit (dipindahkan, diubah ukurannya)?**

Ya. Bentuk menyediakan [lock objects](https://reference.aspose.com/slides/id/java/com.aspose.slides/autoshape/#getAutoShapeLock--) yang memungkinkan Anda [menolak operasi pengeditan](/slides/id/java/applying-protection-to-presentation/).