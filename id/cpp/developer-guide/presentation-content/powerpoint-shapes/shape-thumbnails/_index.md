---
title: Buat Thumbnail Bentuk Presentasi dalam C++
linktitle: Thumbnail Bentuk
type: docs
weight: 70
url: /id/cpp/shape-thumbnails/
keywords:
- thumbnail bentuk
- gambar bentuk
- render bentuk
- rendering bentuk
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Hasilkan thumbnail bentuk berkualitas tinggi dari slide PowerPoint dengan Aspose.Slides untuk C++ – dengan mudah membuat dan mengekspor thumbnail presentasi."
---
## **Pendahuluan**

Aspose.Slides digunakan untuk membuat file presentasi dimana setiap halaman adalah slide. Slide ini dapat dilihat dengan membuka file presentasi menggunakan Microsoft PowerPoint. Namun terkadang, pengembang mungkin perlu melihat gambar bentuk secara terpisah di penampil gambar. Dalam kasus seperti itu, Aspose.Slides membantu Anda menghasilkan gambar mini (thumbnail) dari bentuk slide. Cara menggunakan fitur ini dijelaskan dalam artikel ini.
Artikel ini menjelaskan cara menghasilkan thumbnail slide dengan berbagai cara:

- Menghasilkan thumbnail bentuk di dalam slide.
- Menghasilkan thumbnail bentuk untuk bentuk slide dengan dimensi yang ditentukan pengguna.
- Menghasilkan thumbnail bentuk dalam batas tampilan bentuk.

## **Menghasilkan Thumbnail Bentuk dari Slide**
Untuk menghasilkan thumbnail bentuk dari slide apa pun menggunakan Aspose.Slides untuk C++:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
2. Dapatkan referensi dari slide apa pun menggunakan ID atau indeksnya.
3. Dapatkan gambar thumbnail bentuk dari slide yang direferensikan dengan skala default.
4. Simpan gambar thumbnail ke format gambar yang diinginkan.

Contoh di bawah menghasilkan thumbnail bentuk.

```cpp
auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage();
image->Save(u"Shape_thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Menghasilkan Thumbnail dengan Faktor Skala yang Ditentukan Pengguna**
Untuk menghasilkan thumbnail bentuk dari bentuk slide apa pun menggunakan Aspose.Slides untuk C++:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
2. Dapatkan referensi dari slide apa pun menggunakan ID atau indeksnya.
3. Dapatkan gambar thumbnail dari slide yang direferensikan dengan batas bentuk.
4. Simpan gambar thumbnail dalam format gambar yang diinginkan.

Contoh di bawah menghasilkan thumbnail dengan faktor skala yang ditentukan pengguna.

```cpp
auto bounds = ShapeThumbnailBounds::Shape;
auto scale = 1; // Skala pada sumbu X dan Y.

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Scaling Factor Thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Membuat Thumbnail Tampilan Bentuk Berdasarkan Batas**
Metode ini untuk membuat thumbnail bentuk memungkinkan pengembang menghasilkan thumbnail dalam batas tampilan bentuk. Metode ini mempertimbangkan semua efek bentuk. Thumbnail bentuk yang dihasilkan dibatasi oleh batas slide. Untuk menghasilkan thumbnail dari bentuk slide apa pun dalam batas tampilannya, gunakan kode contoh berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
2. Dapatkan referensi dari slide apa pun menggunakan ID atau indeksnya.
3. Dapatkan gambar thumbnail dari slide yang direferensikan dengan batas bentuk sebagai tampilan.
4. Simpan gambar thumbnail dalam format gambar yang diinginkan.

Contoh di bawah membuat thumbnail dengan menghasilkan thumbnail dengan faktor skala yang ditentukan pengguna.

```cpp
auto bounds = ShapeThumbnailBounds::Appearance;
auto scale = 1; // Skala pada sumbu X dan Y.

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Shape_thumbnail_Bound_Shape_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **FAQ**

**Format gambar apa yang dapat digunakan saat menyimpan thumbnail bentuk?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/id/cpp/aspose.slides/imageformat/), dan lainnya. Bentuk juga dapat [dieksport sebagai SVG vektor](https://reference.aspose.com/slides/id/cpp/aspose.slides/shape/writeassvg/) dengan menyimpan konten bentuk sebagai SVG.

**Apa perbedaan antara batas Shape dan Appearance saat merender thumbnail?**

`Shape` menggunakan geometrik bentuk; `Appearance` memperhitungkan [efek visual](/slides/id/cpp/shape-effect/) (bayangan, cahaya, dll).

**Apa yang terjadi jika sebuah bentuk ditandai sebagai tersembunyi? Apakah masih akan dirender sebagai thumbnail?**

Bentuk tersembunyi tetap menjadi bagian dari model dan dapat dirender; flag tersembunyi memengaruhi tampilan slideshow tetapi tidak mencegah pembuatan gambar bentuk.

**Apakah bentuk grup, grafik, SmartArt, dan objek kompleks lainnya didukung?**

Ya. Objek apa pun yang direpresentasikan sebagai [Shape](https://reference.aspose.com/slides/id/cpp/aspose.slides/shape/) (termasuk [GroupShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/chart/), dan [SmartArt](https://reference.aspose.com/slides/id/cpp/aspose.slides.smartart/smartart/)) dapat disimpan sebagai thumbnail atau sebagai SVG.

**Apakah font yang diinstal pada sistem memengaruhi kualitas thumbnail untuk bentuk teks?**

Ya. Anda harus [menyediakan font yang diperlukan](/slides/id/cpp/custom-font/) (atau [mengonfigurasi substitusi font](/slides/id/cpp/font-substitution/)) untuk menghindari fallback yang tidak diinginkan dan aliran ulang teks.