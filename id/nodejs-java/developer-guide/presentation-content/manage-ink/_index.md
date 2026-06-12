---
title: Kelola Objek Tinta Presentasi dengan JavaScript
linktitle: Kelola Tinta
type: docs
weight: 95
url: /id/nodejs-java/manage-ink/
keywords:
- tinta
- objek tinta
- jejak tinta
- kelola tinta
- gambar tinta
- menggambar
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Kelola objek tinta PowerPoint—buat, edit & gaya tinta digital dengan Aspose.Slides untuk Node.js. Dapatkan contoh kode JavaScript untuk jejak, warna kuas & ukuran."
---
## **Pendahuluan**

PowerPoint menyediakan fungsi tinta untuk memungkinkan Anda menggambar gambar non-standar, yang dapat digunakan untuk menyoroti objek lain, menunjukkan koneksi dan proses, serta menarik perhatian ke item tertentu pada slide. 

Aspose.Slides menyediakan semua tipe Ink (misalnya kelas [Ink](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ink/)) yang Anda perlukan untuk membuat dan mengelola objek tinta.

## **Perbedaan antara Objek Biasa dan Objek Tinta**

Objek pada slide PowerPoint biasanya direpresentasikan oleh objek shape. Objek shape, dalam bentuk paling sederhana, adalah sebuah kontainer yang mendefinisikan area objek itu sendiri (bingkainya) beserta propertinya. Yang terakhir mencakup ukuran area kontainer, bentuk kontainer, latar belakang kontainer, dll. Untuk informasi, lihat [Shape Layout Format](https://docs.aspose.com/slides/id/nodejs-java/shape-manipulations/#access-layout-formats-for-shape).

Namun, ketika PowerPoint menangani objek tinta, ia mengabaikan semua properti dari bingkai objek (kontainer) kecuali ukurannya. Ukuran area kontainer ditentukan oleh nilai standar `width` dan `height`:

![ink_powerpoint1](ink_powerpoint1.png)

## **Jejak Inkshape**

Jejak adalah elemen dasar atau standar yang digunakan untuk merekam lintasan pena saat pengguna menulis tinta digital. Jejak adalah rekaman yang menggambarkan urutan titik-titik yang terhubung. 

Bentuk enkoding paling sederhana menentukan koordinat X dan Y setiap titik sampel. Ketika semua titik yang terhubung dirender, mereka menghasilkan gambar seperti ini:

![ink_powerpoint2](ink_powerpoint2.png)

## Properti Kuas untuk Menggambar 

Anda dapat menggunakan kuas untuk menggambar garis yang menghubungkan titik-titik elemen jejak. Kuas memiliki warna dan ukuran sendiri, yang sesuai dengan metode `Brush.setColor` dan `Brush.setSize`. 

### **Set Warna Kuas Tinta**

Kode JavaScript berikut menunjukkan cara mengatur warna untuk kuas:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var ink = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var traces = ink.getTraces();
    var brush = traces[0].getBrush();
    var brushColor = brush.getColor();
    brush.setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Set Ukuran Kuas Tinta** 

Kode JavaScript berikut menunjukkan cara mengatur ukuran untuk kuas:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var ink = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var traces = ink.getTraces();
    var brush = traces[0].getBrush();
    var brushSize = brush.getSize();
    brush.setSize(java.newInstanceSync("java.awt.Dimension", 5, 10));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Umumnya, lebar dan tinggi kuas tidak cocok, sehingga PowerPoint tidak menampilkan ukuran kuas (bagian data berwarna abu-abu). Namun ketika lebar dan tinggi kuas cocok, PowerPoint menampilkan ukurannya seperti ini:

![ink_powerpoint3](ink_powerpoint3.png)

Untuk kejelasan, mari tingkatkan tinggi objek tinta dan tinjau dimensi penting: 

![ink_powerpoint4](ink_powerpoint4.png)

Kontainer (bingkai) tidak mempertimbangkan ukuran kuas--ia selalu mengasumsikan ketebalan garis nol (lihat gambar terakhir). 

Oleh karena itu, untuk menentukan area yang terlihat dari seluruh objek tinta, kita harus mempertimbangkan ukuran kuas dari objek jejak. Di sini, objek target (objek jejak teks tulisan tangan) telah diskalakan ke ukuran kontainer (bingkai). Ketika ukuran kontainer (bingkai) berubah, ukuran kuas tetap konstan dan sebaliknya. 

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint menunjukkan perilaku yang sama ketika menangani teks:

![ink_powerpoint6](ink_powerpoint6.png)

**Bacaan lanjutan**

* Untuk membaca tentang shape secara umum, lihat bagian [PowerPoint Shapes](https://docs.aspose.com/slides/id/nodejs-java/powerpoint-shapes/).
* Untuk informasi lebih lanjut tentang nilai efektif, lihat [Shape Effective Properties](https://docs.aspose.com/slides/id/nodejs-java/shape-effective-properties/#getting-effective-font-height-value).