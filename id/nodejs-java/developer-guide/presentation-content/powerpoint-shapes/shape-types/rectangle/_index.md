---
title: Menambahkan Persegi Panjang ke Presentasi dengan JavaScript
linktitle: Persegi Panjang
type: docs
weight: 80
url: /id/nodejs-java/rectangle/
keywords:
- menambahkan persegi panjang
- membuat persegi panjang
- bentuk persegi panjang
- persegi panjang sederhana
- persegi panjang yang diformat
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Tingkatkan presentasi PowerPoint Anda dengan menambahkan persegi panjang menggunakan JavaScript dan Aspose.Slides untuk Node.js—dengan mudah merancang dan memodifikasi bentuk secara programatis."
---
## **Ikhtisar**

Artikel ini menunjukkan cara menambahkan bentuk persegi panjang ke slide PowerPoint dengan menggunakan Aspose.Slides. Artikel ini mencakup pembuatan persegi panjang sederhana, pembuatan persegi panjang yang diformat, dan menyimpan presentasi yang diperbarui sebagai file PPTX. Anda juga akan melihat cara menerapkan pemformatan dasar persegi panjang, seperti warna isi padat, warna garis, dan lebar garis. Selain itu, bagian Tanya Jawab artikel mengarahkan ke tugas terkait persegi panjang, termasuk sudut membulat, isi gambar, efek visual, hyperlink, penguncian bentuk, opsi ekspor, dan properti efektif.

## **Menambahkan Persegi Panjang ke Slide**

Seperti topik sebelumnya, topik ini juga tentang menambahkan bentuk dan kali ini bentuk yang akan kita bahas adalah Rectangle. Dalam topik ini, kami menjelaskan bagaimana pengembang dapat menambahkan persegi panjang sederhana atau yang diformat ke slide mereka menggunakan Aspose.Slides.

Untuk menambahkan persegi panjang sederhana ke slide yang dipilih dalam presentasi, ikuti langkah-langkah berikut:

- Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation).
- Dapatkan referensi slide dengan menggunakan Index-nya.
- Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/AutoShape) tipe Rectangle menggunakan metode [addAutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) yang disediakan oleh objek [ShapeCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ShapeCollection).
- Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

Pada contoh di bawah ini, kami telah menambahkan persegi panjang sederhana ke slide pertama presentasi.

```javascript
// Instansiasi kelas Prseetation yang mewakili PPTX
var pres = new aspose.slides.Presentation();
try {
    // Dapatkan slide pertama
    var sld = pres.getSlides().get_Item(0);
    // Tambahkan AutoShape tipe elips
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 50);
    // Tuliskan file PPTX ke disk
    pres.save("RecShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Menambahkan Persegi Panjang yang Diformat ke Slide**

Untuk menambahkan persegi panjang yang diformat ke slide, ikuti langkah-langkah berikut:

- Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation).
- Dapatkan referensi slide dengan menggunakan Index-nya.
- Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/AutoShape) tipe Rectangle menggunakan metode [addAutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) yang disediakan oleh objek [ShapeCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ShapeCollection).
- Set [Fill Type](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/FillType) Persegi Panjang menjadi Solid.
- Set Warna Persegi Panjang menggunakan metode [SolidFillColor.setColor](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ColorFormat#setColor-java.awt.Color-) yang disediakan oleh objek [FillFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/FillFormat) yang terkait dengan objek [Shape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Shape).
- Set Warna garis Persegi Panjang.
- Set Lebar garis Persegi Panjang.
- Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

Langkah-langkah di atas diimplementasikan dalam contoh di bawah ini.

```javascript
// Instansiasi kelas Prseetation yang mewakili PPTX
var pres = new aspose.slides.Presentation();
try {
    // Dapatkan slide pertama
    var sld = pres.getSlides().get_Item(0);
    // Tambahkan AutoShape tipe elips
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 50);
    // Terapkan beberapa pemformatan pada bentuk elips
    shp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    // Terapkan beberapa pemformatan pada garis elips
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shp.getLineFormat().setWidth(5);
    // Tuliskan file PPTX ke disk
    pres.save("RecShp2.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Tanya Jawab**

**Bagaimana cara menambahkan persegi panjang dengan sudut membulat?**

Gunakan [tipe bentuk](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shapetype/) dengan sudut membulat dan sesuaikan radius sudut pada properti shape; pembulatan juga dapat diterapkan per sudut melalui penyesuaian geometri.

**Bagaimana cara mengisi persegi panjang dengan gambar (tekstur)?**

Pilih [tipe isi gambar](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/filltype/), sediakan sumber gambar, dan konfigurasikan [mode peregangan/pengulangan](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/picturefillmode/).

**Apakah persegi panjang dapat memiliki bayangan dan cahaya bersinar?**

Ya. [Bayangan luar/dalam, cahaya bersinar, dan tepi lembut](/slides/id/nodejs-java/shape-effect/) tersedia dengan parameter yang dapat disesuaikan.

**Bisakah saya mengubah persegi panjang menjadi tombol dengan hyperlink?**

Ya. [Tetapkan hyperlink](/slides/id/nodejs-java/manage-hyperlinks/) pada klik shape (melompat ke slide, file, alamat web, atau email).

**Bagaimana saya dapat melindungi persegi panjang dari pergerakan dan perubahan?**

Gunakan kunci shape: Anda dapat melarang pemindahan, pengubahan ukuran, pemilihan, atau pengeditan teks untuk mempertahankan tata letak.

**Apakah saya dapat mengonversi persegi panjang menjadi gambar raster atau SVG?**

Ya. Anda dapat [render shape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/#getImage) ke gambar dengan ukuran/skala tertentu atau [ekspor sebagai SVG](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/writeassvg/) untuk penggunaan vektor.

**Bagaimana cara cepat mendapatkan properti aktual (efektif) dari persegi panjang yang mempertimbangkan tema dan pewarisan?**

[Gunakan properti efektif shape](/slides/id/nodejs-java/shape-effective-properties/): API mengembalikan nilai yang dihitung yang mempertimbangkan gaya tema, tata letak, dan pengaturan lokal, menyederhanakan analisis pemformatan.