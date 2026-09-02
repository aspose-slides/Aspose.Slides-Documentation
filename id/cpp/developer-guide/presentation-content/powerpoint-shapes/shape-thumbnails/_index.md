---
title: "Buat Thumbnail Bentuk Presentasi dalam C++"
linktitle: "Thumbnail Bentuk"
type: docs
weight: 70
url: /id/cpp/shape-thumbnails/
keywords:
- "thumbnail bentuk"
- "gambar bentuk"
- "render bentuk"
- "rendering bentuk"
- "batas visual"
- "batas bentuk"
- "PowerPoint"
- "presentasi"
- "C++"
- "Aspose.Slides"
description: "Buat thumbnail bentuk berkualitas tinggi dari slide PowerPoint dengan Aspose.Slides untuk C++ – dengan mudah membuat dan mengekspor thumbnail presentasi."
---
## **Pendahuluan**

Aspose.Slides digunakan untuk membuat file presentasi di mana setiap halaman adalah slide. Slide tersebut dapat dilihat dengan membuka file presentasi menggunakan Microsoft PowerPoint. Namun terkadang, pengembang perlu melihat gambar bentuk secara terpisah di penampil gambar. Dalam situasi tersebut, Aspose.Slides membantu Anda menghasilkan gambar thumbnail bentuk slide. Cara menggunakan fitur ini dijelaskan dalam artikel ini.  
Artikel ini menjelaskan cara menghasilkan thumbnail slide dengan berbagai cara:

- Menghasilkan thumbnail bentuk di dalam slide.  
- Menghasilkan thumbnail bentuk untuk bentuk slide dengan dimensi yang ditentukan pengguna.  
- Menghasilkan thumbnail bentuk dalam batas penampilan bentuk.

## **Menghasilkan Thumbnail Bentuk dari Slide**
Untuk menghasilkan thumbnail bentuk dari slide apa pun menggunakan Aspose.Slides for C++:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) .
2. Dapatkan referensi slide apa pun menggunakan ID atau indeksnya.  
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
Untuk menghasilkan thumbnail bentuk dari bentuk slide apa pun menggunakan Aspose.Slides for C++:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) .
2. Dapatkan referensi slide apa pun menggunakan ID atau indeksnya.  
3. Dapatkan gambar thumbnail dari slide yang direferensikan dengan batas bentuk.  
4. Simpan gambar thumbnail ke format gambar yang diinginkan.  

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

## **Membuat Thumbnail Penampilan Bentuk Berbasis Batas**
Metode ini untuk membuat thumbnail bentuk memungkinkan pengembang menghasilkan thumbnail dalam batas penampilan bentuk. Metode ini memperhitungkan semua efek bentuk. Thumbnail bentuk yang dihasilkan dibatasi oleh batas slide. Untuk menghasilkan thumbnail dari bentuk slide apa pun dalam batas penampilannya, gunakan contoh kode berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) .
2. Dapatkan referensi slide apa pun menggunakan ID atau indeksnya.  
3. Dapatkan gambar thumbnail dari slide yang direferensikan dengan batas bentuk sebagai penampilan.  
4. Simpan gambar thumbnail ke format gambar yang diinginkan.  

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

## **Dapatkan Batas Visual Aktual dari Bentuk**

Properti bingkai dari [IShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/)—`IShape::get_X()`, `IShape::get_Y()`, `IShape::get_Width()`, dan `IShape::get_Height()`—menjelaskan persegi panjang yang disimpan dalam model presentasi. Konten yang sebenarnya dirender dapat melampaui bingkai tersebut atau menempati persegi panjang yang berorientasi sumbu berbeda. Rotasi, outline, kepala panah, tata letak teks dan overflow, geometri SmartArt yang dihasilkan, dan efek rendering lainnya dapat mengubah area yang ditempati.

Gunakan [Shape::GetVisualBounds](https://reference.aspose.com/slides/id/cpp/aspose.slides/shape/getvisualbounds/) untuk menghitung area yang ditempati tanpa membuat gambar. Metode ini mengembalikan sebuah [RectangleF](https://reference.aspose.com/slides/id/cpp/system.drawing/rectanglef/) dalam koordinat slide. Persegi panjang yang dikembalikan tidak dipotong ke slide, sehingga koordinatnya dapat bernilai negatif ketika konten melampaui asal slide.

[Shape::GetVisualBounds](https://reference.aspose.com/slides/id/cpp/aspose.slides/shape/getvisualbounds/) saat ini belum dideklarasikan oleh antarmuka [IShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/). Oleh karena itu, simpan bentuk yang diambil dari koleksi bentuk slide sebagai nilai antarmuka dan lakukan casting hanya saat memanggil metode tersebut.

Contoh berikut mengambil dan membandingkan bingkai dengan batas visual:

```cpp
auto presentation = MakeObject<Presentation>(u"example.pptx");

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

auto visualBounds = System::AsCast<Shape>(shape)->GetVisualBounds();

System::Drawing::RectangleF frameBounds(
    shape->get_X(), shape->get_Y(), shape->get_Width(), shape->get_Height());

Console::WriteLine(u"Frame bounds: {0}", frameBounds);
Console::WriteLine(u"Visual bounds: {0}", visualBounds);

presentation->Dispose();
```

[RectangleF](https://reference.aspose.com/slides/id/cpp/system.drawing/rectanglef/) yang sama dapat digunakan untuk menyelaraskan bentuk‑bentuk di sekitarnya ke tepi `RectangleF::get_Left()`, `RectangleF::get_Right()`, `RectangleF::get_Top()`, atau `RectangleF::get_Bottom()`‑nya; menyediakan ruang yang cukup dalam tata letak yang dihasilkan; atau mendeteksi konten di luar wilayah yang diizinkan. Batas visual sangat berguna untuk SmartArt, kotak teks, panah, gambar, bentuk berrotasi, dan grup bentuk, di mana bingkai yang disimpan mungkin tidak mewakili hasil rendering penuh.

Gunakan [Shape::GetVisualBounds](https://reference.aspose.com/slides/id/cpp/aspose.slides/shape/getvisualbounds/) ketika Anda memerlukan koordinat untuk tata letak atau validasi dan tidak memerlukan bitmap. Gunakan [IShape::GetImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/getimage/) ketika Anda perlu merender bentuk. Dengan [ShapeThumbnailBounds](https://reference.aspose.com/slides/id/cpp/aspose.slides/shapethumbnailbounds/), `ShapeThumbnailBounds::Shape` menentukan ukuran gambar dari batas bentuk, termasuk pengaturan outline, sementara `ShapeThumbnailBounds::Appearance` menentukan ukuran dari penampilan bentuk dan membatasi hasil ke batas slide. Sebaliknya, [Shape::GetVisualBounds](https://reference.aspose.com/slides/id/cpp/aspose.slides/shape/getvisualbounds/) hanya mengembalikan persegi panjang yang dihitung dan tidak memotongnya ke slide.

## **FAQ**

**Format gambar apa yang dapat digunakan saat menyimpan thumbnail bentuk?**  
[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/id/cpp/aspose.slides/imageformat/), dan lainnya. Bentuk juga dapat [diekspor sebagai SVG vektor](https://reference.aspose.com/slides/id/cpp/aspose.slides/shape/writeassvg/) dengan menyimpan konten bentuk sebagai SVG.

**Apa perbedaan antara batas Shape dan Appearance saat merender thumbnail?**  
`Shape` menggunakan geometri bentuk; `Appearance` mempertimbangkan [efek visual](/slides/id/cpp/shape-effect/) (bayangan, cahaya, dll).

**Apa yang terjadi jika sebuah bentuk ditandai sebagai tersembunyi? Apakah tetap dapat dirender sebagai thumbnail?**  
Bentuk tersembunyi tetap menjadi bagian dari model dan dapat dirender; flag tersembunyi memengaruhi tampilan slide show tetapi tidak mencegah pembuatan gambar bentuk.

**Apakah grup bentuk, diagram, SmartArt, dan objek kompleks lainnya didukung?**  
Ya. Objek apa pun yang direpresentasikan sebagai [Shape](https://reference.aspose.com/slides/id/cpp/aspose.slides/shape/) (termasuk [GroupShape](https://reference.aspose.com/slides/id/cpp/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/id/cpp/aspose.slides.charts/chart/), dan [SmartArt](https://reference.aspose.com/slides/id/cpp/aspose.slides.smartart/smartart/)) dapat disimpan sebagai thumbnail atau sebagai SVG.

**Apakah font yang dipasang pada sistem memengaruhi kualitas thumbnail untuk bentuk teks?**  
Ya. Anda harus [menyediakan font yang diperlukan](/slides/id/cpp/custom-font/) (atau [mengonfigurasi substitusi font](/slides/id/cpp/font-substitution/)) untuk menghindari fallback yang tidak diinginkan dan pergeseran teks.