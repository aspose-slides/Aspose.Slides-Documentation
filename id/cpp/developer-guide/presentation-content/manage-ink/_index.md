---
title: Kelola Objek Tinta Presentasi di C++
linktitle: Kelola Tinta
type: docs
weight: 95
url: /id/cpp/manage-ink/
keywords:
- tinta
- objek tinta
- jejak tinta
- kelola tinta
- gambar tinta
- menggambar
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Kelola objek tinta PowerPoint—buat, edit, dan atur gaya tinta digital dengan Aspose.Slides untuk C++. Dapatkan contoh kode untuk jejak, warna kuas, dan ukuran."
---
## **Pendahuluan**

PowerPoint menyediakan fungsi tinta yang memungkinkan Anda menggambar bentuk tidak standar, yang dapat digunakan untuk menyorot objek lain, menunjukkan sambungan dan proses, serta menarik perhatian pada item tertentu dalam sebuah slide.

Aspose.Slides menyediakan antarmuka [Aspose.Slides.Ink](https://reference.aspose.com/slides/id/cpp/aspose.slides.ink/) yang berisi tipe‑tipe yang Anda perlukan untuk membuat dan mengelola objek tinta.

## **Perbedaan antara Objek Biasa dan Objek Tinta**

Objek pada slide PowerPoint biasanya direpresentasikan oleh objek shape. Sebuah object shape, dalam bentuk paling sederhana, adalah wadah yang mendefinisikan area objek itu sendiri (bingkainya) beserta propertinya. Properti tersebut mencakup ukuran area wadah, bentuk wadah, latar belakang wadah, dll. Untuk informasi lebih lanjut, lihat [Shape Layout Format](https://docs.aspose.com/slides/id/cpp/shape-manipulations/#access-layout-formats-for-shape).

Namun, ketika PowerPoint menangani objek tinta, ia mengabaikan semua properti bingkai objek (wadah) kecuali ukurannya. Ukuran area wadah ditentukan oleh nilai standar `width` dan `height`:

![ink_powerpoint1](ink_powerpoint1.png)

## **Jejak Inkshape**

Jejak adalah elemen dasar atau standar yang digunakan untuk merekam lintasan pena saat pengguna menulis tinta digital. Jejak adalah rekaman yang menggambarkan urutan titik‑titik yang terhubung.

Bentuk enkoding paling sederhana menentukan koordinat X dan Y setiap titik sampel. Ketika semua titik yang terhubung dirender, mereka menghasilkan gambar seperti ini:

![ink_powerpoint2](ink_powerpoint2.png)

## **Properti Kuas untuk Menggambar**

Anda dapat menggunakan kuas untuk menggambar garis yang menghubungkan titik‑titik elemen jejak. Kuas memiliki warna dan ukuran masing‑masing, yang sesuai dengan properti `Brush.Color` dan `Brush.Size`.

### **Atur Warna Kuas Tinta**

Kode C++ berikut menunjukkan cara mengatur warna untuk sebuah kuas:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<IInk> ink = System::ExplicitCast<IInk>(pres->get_Slide(0)->get_Shape(0));
System::ArrayPtr<System::SharedPtr<IInkTrace>> traces = ink->get_Traces();
System::SharedPtr<IInkBrush> brush = traces[0]->get_Brush();
System::Drawing::Color brushColor = brush->get_Color();
brush->set_Color(System::Drawing::Color::get_Red());
```

### **Atur Ukuran Kuas Tinta**

Kode C++ berikut menunjukkan cara mengatur ukuran untuk sebuah kuas:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<IInk> ink = System::ExplicitCast<IInk>(pres->get_Slide(0)->get_Shape(0));
System::ArrayPtr<System::SharedPtr<IInkTrace>> traces = ink->get_Traces();
System::SharedPtr<IInkBrush> brush = traces[0]->get_Brush();
System::Drawing::SizeF brushSize = brush->get_Size();
brush->set_Size(System::Drawing::SizeF(5.0f, 10.0f));
```

Umumnya, lebar dan tinggi kuas tidak sama, sehingga PowerPoint tidak menampilkan ukuran kuas (bagian data berwarna abu‑abu). Namun ketika lebar dan tinggi kuas sama, PowerPoint menampilkan ukurannya seperti ini:

![ink_powerpoint3](ink_powerpoint3.png)

Untuk memperjelas, mari tingkatkan tinggi objek tinta dan tinjau dimensi penting:

![ink_powerpoint4](ink_powerpoint4.png)

Wadah (bingkai) tidak memperhitungkan ukuran kuas—ia selalu mengasumsikan ketebalan garis nol (lihat gambar terakhir).

Oleh karena itu, untuk menentukan area yang terlihat dari seluruh objek tinta, kita harus mempertimbangkan ukuran kuas pada objek jejak. Di sini, objek target (objek jejak teks tulisan tangan) telah diskalakan ke ukuran wadah (bingkai). Ketika ukuran wadah (bingkai) berubah, ukuran kuas tetap konstan, dan sebaliknya.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint menunjukkan perilaku yang sama saat menangani teks:

![ink_powerpoint6](ink_powerpoint6.png)

**Bacaan Lebih Lanjut**

* Untuk mempelajari tentang bentuk secara umum, lihat bagian [PowerPoint Shapes](https://docs.aspose.com/slides/id/cpp/powerpoint-shapes/).
* Untuk informasi lebih lanjut tentang nilai efektif, lihat [Shape Effective Properties](https://docs.aspose.com/slides/id/cpp/shape-effective-properties/#get-effective-font-height-value).