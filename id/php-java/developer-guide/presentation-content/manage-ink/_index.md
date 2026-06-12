---
title: Kelola Objek Tinta Presentasi dalam PHP
linktitle: Kelola Tinta
type: docs
weight: 95
url: /id/php-java/manage-ink/
keywords:
- tinta
- objek tinta
- jejak tinta
- kelola tinta
- gambar tinta
- menggambar
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Kelola objek tinta PowerPoint — buat, edit, & atur gaya tinta digital dengan Aspose.Slides untuk PHP via Java. Dapatkan contoh kode untuk jejak, warna kuas & ukuran."
---
## **Pendahuluan**

PowerPoint menyediakan fungsi tinta untuk memungkinkan Anda menggambar bentuk yang tidak standar, yang dapat digunakan untuk menyoroti objek lain, menunjukkan hubungan dan proses, serta menarik perhatian pada item tertentu di slide. 

Aspose.Slides menyediakan semua tipe Ink (mis. [Ink](https://reference.aspose.com/slides/id/php-java/aspose.slides/ink/) class) yang Anda perlukan untuk membuat dan mengelola objek tinta.

## **Perbedaan antara Objek Reguler dan Objek Tinta**

Objek pada slide PowerPoint biasanya direpresentasikan oleh objek shape. Sebuah shape, dalam bentuk paling sederhana, adalah kontainer yang mendefinisikan area objek itu sendiri (bingkainya) beserta propertinya. Properti tersebut mencakup ukuran area kontainer, bentuk kontainer, latar belakang kontainer, dll. Untuk informasi lebih lanjut, lihat [Shape Layout Format](https://docs.aspose.com/slides/id/php-java/shape-manipulations/#access-layout-formats-for-shape).

Namun, ketika PowerPoint menangani objek tinta, ia mengabaikan semua properti bingkai objek (kontainer) kecuali ukurannya. Ukuran area kontainer ditentukan oleh nilai standar `width` dan `height`:

![ink_powerpoint1](ink_powerpoint1.png)

## **Jejak Inkshape**

Jejak adalah elemen dasar atau standar yang digunakan untuk merekam lintasan pena saat pengguna menulis tinta digital. Jejak adalah rekaman yang menggambarkan urutan titik‑titik yang terhubung. 

Bentuk enkoding paling sederhana menentukan koordinat X dan Y setiap titik sampel. Ketika semua titik terhubung dirender, mereka menghasilkan gambar seperti ini:

![ink_powerpoint2](ink_powerpoint2.png)

## **Properti Brush untuk Menggambar**

Anda dapat menggunakan brush untuk menggambar garis yang menghubungkan titik‑titik elemen jejak. Brush memiliki warna dan ukuran sendiri, yang sesuai dengan properti `Brush.Color` dan `Brush.Size`. 

### **Mengatur Warna Brush Tinta**

Kode PHP berikut menunjukkan cara mengatur warna untuk brush:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $ink = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $traces = $ink->getTraces();
    $brush = $traces[0]->getBrush();
    $brushColor = $brush->getColor();
    $brush->setColor(java("java.awt.Color")->RED);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Mengatur Ukuran Brush Tinta** 

Kode PHP berikut menunjukkan cara mengatur ukuran untuk brush:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $ink = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $traces = $ink->getTraces();
    $brush = $traces[0]->getBrush();
    $brushSize = $brush->getSize();
    $brush->setSize(new Java("java.awt.Dimension", 5, 10));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Secara umum, lebar dan tinggi brush tidak sama, sehingga PowerPoint tidak menampilkan ukuran brush (bagian data berwarna abu‑abu). Namun ketika lebar dan tinggi brush cocok, PowerPoint menampilkan ukurannya seperti ini:

![ink_powerpoint3](ink_powerpoint3.png)

Untuk kejelasan, mari tingkatkan tinggi objek tinta dan tinjau dimensi penting:

![ink_powerpoint4](ink_powerpoint4.png)

Kontainer (bingkai) tidak memperhitungkan ukuran brush—ia selalu mengasumsikan bahwa ketebalan garis adalah nol (lihat gambar terakhir). 

Oleh karena itu, untuk menentukan area yang terlihat dari seluruh objek tinta, kita harus mempertimbangkan ukuran brush pada objek jejak. Di sini, objek target (objek jejak teks tulisan tangan) telah diskalakan ke ukuran kontainer (bingkai). Ketika ukuran kontainer (bingkai) berubah, ukuran brush tetap konstan dan sebaliknya.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint menunjukkan perilaku yang sama ketika menangani teks:

![ink_powerpoint6](ink_powerpoint6.png)

**Bacaan lanjutan**

* Untuk mempelajari tentang shape secara umum, lihat bagian [PowerPoint Shapes](https://docs.aspose.com/slides/id/php-java/powerpoint-shapes/).
* Untuk informasi lebih lanjut tentang nilai efektif, lihat [Shape Effective Properties](https://docs.aspose.com/slides/id/php-java/shape-effective-properties/#getting-effective-font-height-value).