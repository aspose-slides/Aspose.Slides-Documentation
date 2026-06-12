---
title: Konversi Slide PowerPoint ke PNG dalam C++
linktitle: PowerPoint ke PNG
type: docs
weight: 30
url: /id/cpp/convert-powerpoint-to-png/
keywords:
- konversi PowerPoint
- konversi presentasi
- konversi slide
- konversi PPT
- konversi PPTX
- PowerPoint ke PNG
- presentasi ke PNG
- slide ke PNG
- PPT ke PNG
- PPTX ke PNG
- simpan PPT sebagai PNG
- simpan PPTX sebagai PNG
- ekspor PPT ke PNG
- ekspor PPTX ke PNG
- C++
- Aspose.Slides
description: "Konversi presentasi PowerPoint ke gambar PNG berkualitas tinggi dengan cepat menggunakan Aspose.Slides untuk C++, memastikan hasil yang tepat dan otomatis."
---
## **Ikhtisar**

Artikel ini menjelaskan cara mengonversi presentasi PowerPoint ke gambar PNG menggunakan Aspose.Slides. Artikel ini menunjukkan cara memuat file presentasi dalam format seperti PPT, PPTX, dan ODP, merender slide sebagai gambar, dan menyimpan hasilnya dalam format PNG.

Artikel ini juga memperlihatkan cara menyesuaikan gambar PNG yang dihasilkan dengan mengatur nilai skala atau menentukan lebar dan tinggi yang diinginkan.

## **Konversi PowerPoint ke PNG**

Ikuti langkah-langkah berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation).
2. Dapatkan objek slide dari koleksi [Presentation::get_Slides()](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c) di bawah antarmuka [ISlide](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_slide).
3. Gunakan metode [ISlide::GetImage()](https://reference.aspose.com/slides/id/cpp/aspose.slides/islide/getimage) untuk mendapatkan thumbnail setiap slide.
4. Gunakan metode [IImage::Save(String, ImageFormatPtr](https://reference.aspose.com/slides/id/cpp/aspose.slides/iimage/save/#iimagesavesystemstring-imageformat-method) untuk menyimpan thumbnail slide ke format PNG.

Kode C++ berikut menunjukkan cara mengonversi presentasi PowerPoint ke PNG:

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
    
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage()->Save(fileName, ImageFormat::Png);
}
```

## **Konversi PowerPoint ke PNG dengan Dimensi Kustom**

Jika Anda ingin memperoleh file PNG dengan skala tertentu, Anda dapat mengatur nilai `desiredX` dan `desiredY`, yang menentukan dimensi thumbnail yang dihasilkan.

Kode C++ di bawah ini mendemonstrasikan operasi tersebut:

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

float scaleX = 2.f;
float scaleY = 2.f;
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage(scaleX, scaleY)->Save(fileName, ImageFormat::Png);
}
```

## **Konversi PowerPoint ke PNG dengan Ukuran Kustom**

Jika Anda ingin memperoleh file PNG dengan ukuran tertentu, Anda dapat memberi argumen `width` dan `height` yang diinginkan untuk `ImageSize`.

Kode berikut menunjukkan cara mengonversi PowerPoint ke PNG sambil menentukan ukuran gambar:

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
    
Size size(960, 720);
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage(size)->Save(fileName, ImageFormat::Png);
}
```

## **FAQ**

**Bagaimana cara mengekspor hanya bentuk tertentu (misalnya diagram atau gambar) bukan seluruh slide?**

Aspose.Slides mendukung [generating thumbnails for individual shapes](/slides/id/cpp/create-shape-thumbnails/); Anda dapat merender sebuah bentuk ke gambar PNG.

**Apakah konversi paralel didukung pada server?**

Ya, tetapi [don’t share](/slides/id/cpp/multithreading/) satu instance presentasi di antara thread. Gunakan instance terpisah per thread atau proses.

**Apa saja batasan versi percobaan saat mengekspor ke PNG?**

Mode evaluasi menambahkan watermark pada gambar output dan memberlakukan [other restrictions](/slides/id/cpp/licensing/) sampai lisensi diterapkan.