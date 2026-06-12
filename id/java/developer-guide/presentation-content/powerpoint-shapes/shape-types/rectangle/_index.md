---
title: Menambahkan Persegi Panjang ke Presentasi dalam Java
linktitle: Persegi Panjang
type: docs
weight: 80
url: /id/java/rectangle/
keywords:
- menambahkan persegi panjang
- membuat persegi panjang
- bentuk persegi panjang
- persegi panjang sederhana
- persegi panjang terformat
- PowerPoint
- presentasi
- Java
- Aspose.Slides
description: "Tingkatkan presentasi PowerPoint Anda dengan menambahkan persegi panjang menggunakan Aspose.Slides untuk Java—desain dan modifikasi bentuk secara programatis dengan mudah."
---
## **Ikhtisar**

Artikel ini menunjukkan cara menambahkan bentuk persegi panjang ke slide PowerPoint dengan menggunakan Aspose.Slides. Ini mencakup pembuatan persegi panjang sederhana, pembuatan persegi panjang yang diformat, dan menyimpan presentasi yang diperbarui sebagai file PPTX.

Anda juga akan melihat cara menerapkan pemformatan persegi panjang dasar, seperti warna isi padat, warna garis, dan lebar garis. Selain itu, bagian FAQ artikel mengarahkan ke tugas-tugas terkait persegi panjang, termasuk sudut melengkung, isi gambar, efek visual, hyperlink, penguncian bentuk, opsi ekspor, dan properti efektif.

## **Menambahkan Persegi Panjang ke Slide**
Untuk menambahkan persegi panjang sederhana ke slide yang dipilih dalam presentasi, ikuti langkah‑langkah berikut:

- Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation).
- Dapatkan referensi slide dengan menggunakan Index‑nya.
- Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/IAutoShape) tipe Rectangle menggunakan metode [addAutoShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) yang disediakan oleh objek [IShapeCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/IShapeCollection).
- Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

Pada contoh di bawah, kami menambahkan persegi panjang sederhana ke slide pertama presentasi.

```java
// Instansiasi kelas Presentation yang mewakili PPTX
Presentation pres = new Presentation();
try {
    // Dapatkan slide pertama
    ISlide sld = pres.getSlides().get_Item(0);

    // Tambahkan AutoShape tipe elips
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Tulis file PPTX ke disk
    pres.save("RecShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Menambahkan Persegi Panjang yang Diformat ke Slide**
Untuk menambahkan persegi panjang yang diformat ke slide, ikuti langkah‑langkah berikut:

- Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation).
- Dapatkan referensi slide dengan menggunakan Index‑nya.
- Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/IAutoShape) tipe Rectangle menggunakan metode [addAutoShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) yang disediakan oleh objek [IShapeCollection](https://reference.aspose.com/slides/id/java/com.aspose.slides/IShapeCollection).
- Atur [Fill Type](https://reference.aspose.com/slides/id/java/com.aspose.slides/FillType) Persegi Panjang menjadi Solid.
- Atur Warna Persegi Panjang menggunakan metode [SolidFillColor.setColor](https://reference.aspose.com/slides/id/java/com.aspose.slides/IColorFormat#setColor-java.awt.Color-) yang disediakan oleh objek [IFillFormat](https://reference.aspose.com/slides/id/java/com.aspose.slides/IFillFormat) yang terkait dengan objek [IShape](https://reference.aspose.com/slides/id/java/com.aspose.slides/IShape).
- Atur Warna garis Persegi Panjang.
- Atur Lebar garis Persegi Panjang.
- Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

Langkah‑langkah di atas diimplementasikan dalam contoh di bawah.

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

    // Tulis file PPTX ke disk
    pres.save("RecShp2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Bagaimana cara menambahkan persegi panjang dengan sudut melengkung?**

Gunakan [shape type](https://reference.aspose.com/slides/id/java/com.aspose.slides/shapetype/) dengan sudut melengkung dan sesuaikan radius sudut pada properti bentuk; pembulatan juga dapat diterapkan per sudut melalui penyesuaian geometri.

**Bagaimana cara mengisi persegi panjang dengan gambar (tekstur)?**

Pilih [fill type](https://reference.aspose.com/slides/id/java/com.aspose.slides/filltype/) gambar, berikan sumber gambar, dan konfigurasikan [mode stretching/tiling](https://reference.aspose.com/slides/id/java/com.aspose.slides/picturefillmode/).

**Apakah persegi panjang dapat memiliki bayangan dan cahaya glow?**

Ya. [Outer/inner shadow, glow, dan soft edges](/slides/id/java/shape-effect/) tersedia dengan parameter yang dapat disesuaikan.

**Bisakah saya mengubah persegi panjang menjadi tombol dengan hyperlink?**

Ya. [Assign a hyperlink](/slides/id/java/manage-hyperlinks/) ke klik bentuk (melompat ke slide, file, alamat web, atau email).

**Bagaimana cara melindungi persegi panjang dari pemindahan dan perubahan?**

[Use shape locks](/slides/id/java/applying-protection-to-presentation/): Anda dapat melarang pemindahan, pengubahan ukuran, pemilihan, atau pengeditan teks untuk mempertahankan tata letak.

**Bisakah saya mengonversi persegi panjang menjadi gambar raster atau SVG?**

Ya. Anda dapat [render the shape](https://reference.aspose.com/slides/id/java/com.aspose.slides/shape/#getImage-int-float-float-) ke gambar dengan ukuran/skalanya yang ditentukan atau [export it as SVG](https://reference.aspose.com/slides/id/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) untuk penggunaan vektor.

**Bagaimana cara cepat mendapatkan properti aktual (efektif) dari persegi panjang dengan mempertimbangkan tema dan pewarisan?**

[Use the shape’s effective properties](/slides/id/java/shape-effective-properties/): API mengembalikan nilai yang dihitung yang memperhitungkan gaya tema, tata letak, dan pengaturan lokal, sehingga mempermudah analisis pemformatan.