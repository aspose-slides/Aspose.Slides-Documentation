---
title: Kelola Objek Tinta Presentasi di Android
linktitle: Kelola Tinta
type: docs
weight: 95
url: /id/androidjava/manage-ink/
keywords:
- tinta
- objek tinta
- jejak tinta
- kelola tinta
- gambar tinta
- menggambar
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Kelola objek tinta PowerPoint—buat, edit, & atur gaya tinta digital dengan Aspose.Slides untuk Android. Dapatkan contoh kode Java untuk jejak, warna kuas, dan ukuran."
---
## **Pendahuluan**

PowerPoint menyediakan fungsi tinta untuk memungkinkan Anda menggambar gambar non-standar, yang dapat digunakan untuk menyoroti objek lain, menunjukkan koneksi dan proses, serta menarik perhatian pada item tertentu dalam slide. 

Aspose.Slides menyediakan semua tipe Ink (misalnya kelas [Ink](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ink/)) yang Anda perlukan untuk membuat dan mengelola objek tinta.

## **Perbedaan antara Objek Reguler dan Objek Tinta**

Objek pada slide PowerPoint biasanya direpresentasikan oleh objek shape. Sebuah objek shape, dalam bentuk paling sederhana, adalah sebuah kontainer yang menentukan area objek itu sendiri (bingkainya) beserta properti-propertinya. Yang terakhir mencakup ukuran area kontainer, bentuk kontainer, latar belakang kontainer, dll. Untuk informasi lebih lanjut, lihat [Shape Layout Format](https://docs.aspose.com/slides/id/androidjava/shape-manipulations/#access-layout-formats-for-shape).

Namun, ketika PowerPoint menangani objek tinta, ia mengabaikan semua properti bingkai objek (kontainer) kecuali ukurannya. Ukuran area kontainer ditentukan oleh nilai standar `width` dan `height`:

![ink_powerpoint1](ink_powerpoint1.png)

## **Jejak Inkshape**

Jejak adalah elemen dasar atau standar yang digunakan untuk merekam lintasan pena ketika pengguna menulis tinta digital. Jejak merupakan rekaman yang menggambarkan urutan titik-titik yang terhubung. 

Bentuk enkoding paling sederhana menentukan koordinat X dan Y setiap titik sampel. Ketika semua titik yang terhubung dirender, mereka menghasilkan gambar seperti ini:

![ink_powerpoint2](ink_powerpoint2.png)

## **Properti Kuas untuk Menggambar**

Anda dapat menggunakan kuas untuk menggambar garis yang menghubungkan titik-titik elemen jejak. Kuas memiliki warna dan ukuran sendiri, yang sesuai dengan properti `Brush.Color` dan `Brush.Size`. 

### **Atur Warna Kuas Tinta**

This Java code shows you how to set the color for a brush:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    IInk ink = (IInk)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IInkTrace[] traces = ink.getTraces();
    IInkBrush brush = traces[0].getBrush();
    Color brushColor = brush.getColor();
    brush.setColor(Color.RED);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Atur Ukuran Kuas Tinta** 

This Java code shows you how to set the size for a brush:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    IInk ink = (IInk)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IInkTrace[] traces = ink.getTraces();
    IInkBrush brush = traces[0].getBrush();
    Dimension2D brushSize = brush.getSize();
    brush.setSize(new Dimension(5, 10));
} finally {
    if (pres != null) pres.dispose();
}
```

Secara umum, lebar dan tinggi kuas tidak cocok, sehingga PowerPoint tidak menampilkan ukuran kuas (bagian data berwarna abu-abu). Namun ketika lebar dan tinggi kuas cocok, PowerPoint menampilkan ukurannya seperti ini:

![ink_powerpoint3](ink_powerpoint3.png)

Untuk kejelasan, mari tingkatkan tinggi objek tinta dan tinjau dimensi penting: 

![ink_powerpoint4](ink_powerpoint4.png)

Kontainer (bingkai) tidak memperhitungkan ukuran kuas--ia selalu mengasumsikan ketebalan garis menjadi nol (lihat gambar terakhir). 

Oleh karena itu, untuk menentukan area tampak dari seluruh objek tinta, kita harus mempertimbangkan ukuran kuas pada objek jejak. Di sini, objek target (objek jejak teks tulisan tangan) telah diskalakan ke ukuran kontainer (bingkai). Ketika ukuran kontainer (bingkai) berubah, ukuran kuas tetap konstan dan sebaliknya. 

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint memperlihatkan perilaku yang sama ketika menangani teks:

![ink_powerpoint6](ink_powerpoint6.png)

**Bacaan Lebih Lanjut**

* Untuk mempelajari tentang shape secara umum, lihat bagian [PowerPoint Shapes](https://docs.aspose.com/slides/id/androidjava/powerpoint-shapes/).
* Untuk informasi lebih lanjut tentang nilai efektif, lihat [Shape Effective Properties](https://docs.aspose.com/slides/id/androidjava/shape-effective-properties/#getting-effective-font-height-value).