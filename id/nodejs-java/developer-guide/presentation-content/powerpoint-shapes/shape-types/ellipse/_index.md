---
title: Menambahkan Elips ke Presentasi dalam JavaScript
linktitle: Elips
type: docs
weight: 30
url: /id/nodejs-java/ellipse/
keywords:
- elips
- bentuk
- tambahkan elips
- buat elips
- gambar elips
- elips berformat
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Pelajari cara membuat, memformat, dan memanipulasi bentuk elips di Aspose.Slides untuk Node.js pada presentasi PPT dan PPTX—contoh kode JavaScript disertakan."
---
## **Gambaran Umum**

Artikel ini menunjukkan cara menambahkan bentuk elips ke slide PowerPoint dengan menggunakan Aspose.Slides. Artikel ini mencakup pembuatan elips sederhana, pembuatan elips berformat, dan menyimpan presentasi yang diperbarui sebagai file PPTX. Artikel ini juga membahas pertanyaan terkait seperti mengatur posisi dan ukuran elips, mengontrol urutan penumpukan, dan menerapkan efek animasi.

## **Buat Elips**
Untuk menambahkan elips sederhana ke slide yang dipilih dalam presentasi, ikuti langkah-langkah berikut:

- Buat sebuah instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation).
- Dapatkan referensi slide dengan menggunakan Index-nya.
- Tambahkan AutoShape tipe Ellipse menggunakan metode [addAutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) yang disediakan oleh objek [ShapeCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ShapeCollection).
- Tuliskan presentasi yang telah dimodifikasi sebagai file PPTX.

Pada contoh di bawah ini, kami telah menambahkan elips ke slide pertama

```javascript
// Membuat instance kelas Presentation yang mewakili PPTX
var pres = new aspose.slides.Presentation();
try {
    // Dapatkan slide pertama
    var sld = pres.getSlides().get_Item(0);
    // Tambahkan AutoShape tipe elips
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 150, 150, 50);
    // Tulis file PPTX ke disk
    pres.save("EllipseShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Buat Elips Berformat**
Untuk menambahkan elips berformat lebih baik ke slide, ikuti langkah-langkah di bawah ini:

- Buat sebuah instance kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation).
- Dapatkan referensi slide dengan menggunakan Index-nya.
- Tambahkan AutoShape tipe Ellipse menggunakan metode [addAutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) yang disediakan oleh objek [ShapeCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ShapeCollection).
- Setel Tipe Isi (Fill Type) Elips menjadi Solid.
- Setel Warna Elips menggunakan properti SolidFillColor.Color yang disediakan oleh objek [FillFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/FillFormat) yang terkait dengan objek [Shape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Shape).
- Setel Warna garis Elips.
- Setel Lebar garis Elips.
- Tuliskan presentasi yang telah dimodifikasi sebagai file PPTX.

Pada contoh di bawah ini, kami telah menambahkan elips berformat ke slide pertama presentasi.

```javascript
// Instansiasi kelas Presentation yang mewakili PPTX
var pres = new aspose.slides.Presentation();
try {
    // Dapatkan slide pertama
    var sld = pres.getSlides().get_Item(0);
    // Tambahkan AutoShape tipe elips
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 150, 150, 50);
    // Terapkan beberapa format pada bentuk elips
    shp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.Chocolate));
    // Terapkan beberapa format pada garis Elips
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shp.getLineFormat().setWidth(5);
    // Tulis file PPTX ke disk
    pres.save("EllipseShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
 
## **FAQ**

**Bagaimana cara saya mengatur posisi dan ukuran tepat elips relatif terhadap satuan slide?**

Koordinat dan ukuran biasanya ditentukan **dalam poin**. Untuk hasil yang dapat diprediksi, dasar perhitungan Anda pada ukuran slide dan konversikan milimeter atau inci yang diperlukan ke poin sebelum menetapkan nilai.

**Bagaimana saya dapat menempatkan elips di atas atau di bawah objek lain (mengontrol urutan penumpukan)?**

Sesuaikan urutan gambar objek dengan membawanya ke depan atau mengirimnya ke belakang. Hal ini memungkinkan elips menutupi objek lain atau memperlihatkan objek di bawahnya.

**Bagaimana cara saya memberi animasi pada tampilan atau penekanan elips?**

[Apply](/slides/id/nodejs-java/shape-animation/) efek masuk, penekanan, atau keluar pada bentuk, dan konfigurasikan pemicu serta timing untuk mengatur kapan dan bagaimana animasi dijalankan.