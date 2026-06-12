---
title: Tambahkan Persegi Panjang ke Presentasi di Android
linktitle: Persegi Panjang
type: docs
weight: 80
url: /id/androidjava/rectangle/
keywords:
- tambahkan persegi panjang
- buat persegi panjang
- bentuk persegi panjang
- persegi panjang sederhana
- persegi panjang berformat
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Tingkatkan presentasi PowerPoint Anda dengan menambahkan persegi panjang menggunakan Aspose.Slides untuk Android via Java—desain dan modifikasi bentuk secara programatis dengan mudah."
---
## **Ringkasan**

Artikel ini menunjukkan cara menambahkan bentuk persegi panjang ke slide PowerPoint dengan menggunakan Aspose.Slides. Artikel ini mencakup pembuatan persegi panjang sederhana, pembuatan persegi panjang berformat, dan menyimpan presentasi yang diperbarui sebagai file PPTX.

Anda juga akan melihat cara menerapkan pemformatan persegi panjang dasar, seperti warna isian padat, warna garis, dan lebar garis. Selain itu, bagian FAQ artikel ini mengarahkan ke tugas-tugas terkait persegi panjang, termasuk sudut melengkung, isian gambar, efek visual, hyperlink, penguncian bentuk, opsi ekspor, dan properti efektif.

## **Tambahkan Persegi Panjang ke Slide**
- Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation).
- Dapatkan referensi slide dengan menggunakan Index-nya.
- Tambahkan [IAutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IAutoShape) tipe Rectangle menggunakan metode [addAutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) yang disediakan oleh objek [IShapeCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IShapeCollection).
- Tuliskan presentasi yang dimodifikasi sebagai file PPTX.

Pada contoh di bawah ini, kami telah menambahkan persegi panjang sederhana ke slide pertama presentasi.

```java
// Instansiasi kelas Presentation yang mewakili PPTX
Presentation pres = new Presentation();
try {
    // Dapatkan slide pertama
    ISlide sld = pres.getSlides().get_Item(0);

    // Tambahkan AutoShape tipe elips
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Tuliskan file PPTX ke disk
    pres.save("RecShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Tambahkan Persegi Panjang Berformat ke Slide**
- Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation).
- Dapatkan referensi slide dengan menggunakan Index-nya.
- Tambahkan [IAutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IAutoShape) tipe Rectangle menggunakan metode [addAutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) yang disediakan oleh objek [IShapeCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IShapeCollection).
- Setel [Fill Type](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/FillType) Persegi Panjang ke Solid.
- Setel Warna Persegi Panjang menggunakan metode [SolidFillColor.setColor](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IColorFormat#setColor-java.awt.Color-) yang disediakan oleh objek [IFillFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IFillFormat) yang terkait dengan objek [IShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IShape).
- Setel Warna garis Persegi Panjang.
- Setel Lebar garis Persegi Panjang.
- Tuliskan presentasi yang dimodifikasi sebagai file PPTX.

Langkah-langkah di atas diimplementasikan dalam contoh di bawah ini.

```java
// Instansiasi kelas Presentation yang mewakili PPTX
Presentation pres = new Presentation();
try {
    // Dapatkan slide pertama
    ISlide sld = pres.getSlides().get_Item(0);

    // Tambahkan AutoShape tipe elips
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Terapkan beberapa format pada bentuk elips
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    // Terapkan beberapa format pada garis elips
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // Tuliskan file PPTX ke disk
    pres.save("RecShp2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Bagaimana cara menambahkan persegi panjang dengan sudut melengkung?**

Gunakan [shape type](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/shapetype/) sudut melengkung dan sesuaikan radius sudut pada properti bentuk; pembulatan juga dapat diterapkan per sudut melalui penyesuaian geometri.

**Bagaimana cara mengisi persegi panjang dengan gambar (tekstur)?**

Pilih [fill type](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/filltype/) gambar, berikan sumber gambar, dan konfigurasikan [mode stretch/tiling](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/picturefillmode/).

**Apakah persegi panjang dapat memiliki bayangan dan cahaya?**

Ya. [Outer/inner shadow, glow, and soft edges](/slides/id/androidjava/shape-effect/) tersedia dengan parameter yang dapat disesuaikan.

**Bisakah saya mengubah persegi panjang menjadi tombol dengan hyperlink?**

Ya. [Assign a hyperlink](/slides/id/androidjava/manage-hyperlinks/) pada klik bentuk (lompat ke slide, file, alamat web, atau email).

**Bagaimana saya dapat melindungi persegi panjang dari pergerakan dan perubahan?**

Gunakan penguncian bentuk: Anda dapat melarang pergerakan, pengubahan ukuran, pemilihan, atau penyuntingan teks untuk menjaga tata letak.

**Bisakah saya mengonversi persegi panjang menjadi gambar raster atau SVG?**

Ya. Anda dapat [render the shape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) ke gambar dengan ukuran/skalanya tertentu atau [export it as SVG](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) untuk penggunaan vektor.

**Bagaimana cara cepat mendapatkan properti aktual (efektif) dari persegi panjang dengan mempertimbangkan tema dan warisan?**

[Use the shape’s effective properties](/slides/id/androidjava/shape-effective-properties/): API mengembalikan nilai yang dihitung yang mempertimbangkan gaya tema, tata letak, dan pengaturan lokal, menyederhanakan analisis pemformatan.