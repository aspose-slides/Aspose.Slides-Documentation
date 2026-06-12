---
title: Bentuk Grup Presentasi dalam JavaScript
linktitle: Grup Bentuk
type: docs
weight: 40
url: /id/nodejs-java/group/
keywords:
- bentuk grup
- grup bentuk
- tambahkan grup
- teks alternatif
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Pelajari cara mengelompokkan dan memisahkan bentuk dalam dek PowerPoint menggunakan Aspose.Slides untuk Node.js via Java — panduan cepat langkah demi langkah dengan kode JavaScript gratis."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan bentuk grup di Aspose.Slides. Artikel ini menunjukkan cara menambahkan bentuk grup ke slide, menempatkan bentuk di dalamnya, dan menyimpan presentasi yang diperbarui. Artikel ini juga mendemonstrasikan cara mengakses bentuk yang disimpan di dalam grup dan membaca nilai `AlternativeText` mereka. Selain itu, artikel ini secara singkat membahas kemampuan bentuk grup terkait seperti grup bertingkat, urutan‑z, dan opsi penguncian.

## **Menambahkan Bentuk Grup**
Aspose.Slides mendukung kerja dengan bentuk grup pada slide. Fitur ini membantu pengembang membuat presentasi yang lebih kaya. Aspose.Slides for Node.js via Java mendukung penambahan atau akses bentuk grup. Dimungkinkan untuk menambahkan bentuk ke dalam bentuk grup yang telah ditambahkan untuk mengisinya atau mengakses properti apa pun dari bentuk grup. Untuk menambahkan bentuk grup ke slide menggunakan Aspose.Slides for Node.js via Java:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation).
1. Dapatkan referensi slide dengan menggunakan Indeksnya.
1. Tambahkan bentuk grup ke slide.
1. Tambahkan bentuk ke dalam bentuk grup yang telah ditambahkan.
1. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Contoh di bawah ini menambahkan bentuk grup ke slide.

```javascript
// Instansiasi kelas Presentation
var pres = new aspose.slides.Presentation();
try {
    // Dapatkan slide pertama
    var sld = pres.getSlides().get_Item(0);
    // Mengakses koleksi bentuk pada slide
    var slideShapes = sld.getShapes();
    // Menambahkan bentuk grup ke slide
    var groupShape = slideShapes.addGroupShape();
    // Menambahkan bentuk di dalam bentuk grup yang ditambahkan
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 300, 100, 100);
    // Menambahkan bingkai bentuk grup
    groupShape.setFrame(new aspose.slides.ShapeFrame(100, 300, 500, 40, aspose.slides.NullableBool.False, aspose.slides.NullableBool.False, 0));
    // Menulis file PPTX ke disk
    pres.save("GroupShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Mengakses Properti AltText**
Topik ini menunjukkan langkah‑langkah sederhana, lengkap dengan contoh kode, untuk menambahkan bentuk grup dan mengakses properti AltText dari bentuk grup pada slide. Untuk mengakses AltText dari sebuah bentuk grup di slide menggunakan Aspose.Slides for Node.js via Java:

1. Instansiasi kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation) yang merepresentasikan file PPTX.
1. Dapatkan referensi slide dengan menggunakan Indeksnya.
1. Akses koleksi bentuk pada slide.
1. Akses bentuk grup.
1. Panggil properti [getAlternativeText](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Shape#getAlternativeText--).

Contoh di bawah ini mengakses teks alternatif dari bentuk grup.

```javascript
// Instansiasi kelas Presentation yang merepresentasikan file PPTX
var pres = new aspose.slides.Presentation("AltText.pptx");
try {
    // Dapatkan slide pertama
    var sld = pres.getSlides().get_Item(0);
    for (var i = 0; i < sld.getShapes().size(); i++) {
        // Mengakses koleksi bentuk pada slide
        var shape = sld.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.GroupShape")) {
            // Mengakses bentuk grup.
            var grphShape = shape;
            for (var j = 0; j < grphShape.getShapes().size(); j++) {
                var shape2 = grphShape.getShapes().get_Item(j);
                // Mengakses properti AltText
                console.log(shape2.getAlternativeText());
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Apakah pengelompokan berlapis (sebuah grup di dalam grup) didukung?**

Ya. [GroupShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/groupshape/) memiliki metode [getParentGroup](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/getparentgroup/), yang secara langsung menunjukkan dukungan hierarki (sebuah grup dapat menjadi anak dari grup lain).

**Bagaimana cara mengontrol urutan‑z grup relatif terhadap objek lain pada slide?**

Gunakan metode [getZOrderPosition](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/getzorderposition/) milik [GroupShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/groupshape/) untuk memeriksa posisinya dalam tumpukan tampilan.

**Apakah saya dapat mencegah pemindahan/pengeditan/pemecahan grup?**

Ya. Bagian kunci grup dapat diakses melalui [GroupShapeLock](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/groupshape/getgroupshapelock/), yang memungkinkan Anda membatasi operasi pada objek tersebut.