---
title: Menambahkan Bentuk Garis ke Presentasi dengan JavaScript
linktitle: Garis
type: docs
weight: 50
url: /id/nodejs-java/line/
keywords:
- garis
- membuat garis
- menambahkan garis
- garis polos
- mengkonfigurasi garis
- menyesuaikan garis
- gaya garis putus
- kepala panah
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Pelajari cara memanipulasi format garis dalam presentasi PowerPoint dengan JavaScript dan Aspose.Slides untuk Node.js. Temukan properti, metode, dan contoh."
---
## **Ikhtisar**

Aspose.Slides memungkinkan Anda menambahkan bentuk garis ke slide PowerPoint secara programatis. Artikel ini menunjukkan cara membuat garis sederhana dan cara menyesuaikan garis sehingga tampil sebagai panah.

Anda akan mempelajari cara menambahkan bentuk garis ke slide, menyesuaikan tampilannya, dan menyimpan presentasi yang diperbarui. Contoh-contoh berfokus pada pengaturan format garis praktis seperti gaya, lebar, pola garis putus, opsi kepala panah, dan warna isi.

## **Buat Garis Polos**

Untuk menambahkan garis polos sederhana ke slide yang dipilih dalam presentasi, silakan ikuti langkah-langkah berikut:

- Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
- Dapatkan referensi slide dengan menggunakan Index-nya.
- Buat AutoShape tipe Line menggunakan metode [addAutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) yang disediakan oleh objek [ShapeCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ShapeCollection).
- Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

Pada contoh di bawah ini, kami telah menambahkan garis ke slide pertama presentasi.

```javascript
// Instansiasi kelas PresentationEx yang merepresentasikan file PPTX
var pres = new aspose.slides.Presentation();
try {
    // Ambil slide pertama
    var sld = pres.getSlides().get_Item(0);
    // Tambahkan AutoShape bertipe line
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    // Tulis PPTX ke Disk
    pres.save("LineShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Buat Garis Berbentuk Panah**

Aspose.Slides for Node.js via Java juga memungkinkan pengembang mengkonfigurasi beberapa properti garis agar tampak lebih menarik. Mari coba mengkonfigurasi beberapa properti garis agar tampil seperti panah. Silakan ikuti langkah-langkah berikut:

- Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
- Dapatkan referensi slide dengan menggunakan Index-nya.
- Buat AutoShape tipe Line menggunakan metode [addAutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) yang disediakan oleh objek [ShapeCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ShapeCollection).
- Atur [Line Style](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/LineStyle) ke salah satu gaya yang disediakan oleh Aspose.Slides for Node.js via Java.
- Atur Width garis.
- Atur [Dash Style](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/LineDashStyle) garis ke salah satu gaya yang ditawarkan oleh Aspose.Slides for Node.js via Java.
- Atur [Arrow Head Style](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/LineArrowheadStyle) dan [Length](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/LineArrowheadLength) pada titik awal garis.
- Atur [Arrow Head Style](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/LineArrowheadStyle) dan [Length](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/LineArrowheadLength) pada titik akhir garis.
- Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

```javascript
// Instansiasi kelas PresentationEx yang merepresentasikan file PPTX
var pres = new aspose.slides.Presentation();
try {
    // Ambil slide pertama
    var sld = pres.getSlides().get_Item(0);
    // Tambahkan AutoShape bertipe line
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    // Terapkan beberapa format pada garis
    shp.getLineFormat().setStyle(aspose.slides.LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);
    shp.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    shp.getLineFormat().setBeginArrowheadLength(aspose.slides.LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(aspose.slides.LineArrowheadStyle.Oval);
    shp.getLineFormat().setEndArrowheadLength(aspose.slides.LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.Maroon));
    // Tulis PPTX ke Disk
    pres.save("LineShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Apakah saya dapat mengubah garis biasa menjadi connector sehingga ia "menempel" pada bentuk?**

Tidak. Garis biasa (sebuah [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/) bertipe [Line](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shapetype/)) tidak secara otomatis menjadi connector. Untuk membuatnya menempel pada bentuk, gunakan tipe [Connector](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/connector/) khusus dan [API yang sesuai](/slides/id/nodejs-java/connector/) untuk koneksi.

**Apa yang harus saya lakukan jika properti garis diwarisi dari tema dan sulit menentukan nilai akhirnya?**

[Baca properti yang efektif](/slides/id/nodejs-java/shape-effective-properties/) melalui kelas `ILineFormatEffectiveData`/`ILineFillFormatEffectiveData`—kelas ini sudah memperhitungkan warisan dan gaya tema.

**Apakah saya dapat mengunci garis agar tidak dapat diedit (dipindahkan, diubah ukuran)?**

Ya. Bentuk menyediakan [lock objects](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/getautoshapelock/) yang memungkinkan Anda melarang operasi pengeditan.