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
description: "Konversi presentasi PowerPoint menjadi gambar PNG berkualitas tinggi dengan cepat menggunakan Aspose.Slides untuk C++, memastikan hasil yang tepat dan otomatis."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara mengonversi slide presentasi menjadi gambar PNG menggunakan Aspose.Slides untuk C++. Anda dapat memuat presentasi dalam format seperti PPT, PPTX, dan ODP, merender tiap slide, dan menyimpannya sebagai gambar PNG terpisah.

Contoh di bawah menunjukkan cara merender dengan skala default, meningkatkan skala, menentukan dimensi output dalam piksel, dan memilih gaya render gradien.

## **Mengonversi PowerPoint ke PNG**

Muat presentasi dengan kelas [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) dan akses slidennya melalui accessor [Presentation::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slide/). Contoh ini merender setiap slide dengan [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) tanpa parameter untuk membuat thumbnail. Kemudian memanggil [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/) dengan [ImageFormat::Png](https://reference.aspose.com/slides/cpp/aspose.slides/imageformat/) untuk menyimpan tiap slide yang sudah dirender sebagai gambar PNG.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto slideCount = presentation->get_Slides()->get_Count();
for (auto index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage();
    image->Save(String::Format(u"slide_{0}.png", index), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Pemanggilan overload [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) tanpa parameter merender dengan skala 0,2. Misalnya, slide berukuran 720 × 540 poin menghasilkan thumbnail berukuran 144 × 108 piksel. Untuk mengontrol dimensi output, gunakan overload dengan faktor skala atau ukuran gambar eksplisit seperti yang ditunjukkan di bawah.
{{% /alert %}}

## **Mengonversi PowerPoint ke PNG dengan Dimensi Kustom**

Berikan faktor skala horizontal dan vertikal ke [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) untuk mengontrol dimensi hasil render. Pada contoh ini, kedua faktor adalah 2, sehingga slide berukuran 720 × 540 poin menghasilkan gambar 1440 × 1080 piksel. Faktor skala yang sama menjaga rasio aspek slide. Setiap gambar disimpan dalam format PNG dengan [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/).

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto scaleX = 2.f;
auto scaleY = scaleX;

auto slideCount = presentation->get_Slides()->get_Count();
for (auto index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage(scaleX, scaleY);
    image->Save(String::Format(u"slide_{0}.png", index), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

## **Mengonversi PowerPoint ke PNG dengan Ukuran Kustom**

Untuk menentukan dimensi output dalam piksel, berikan ukuran ke [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) alih-alih faktor skala. Contoh ini merender setiap slide pada 960 × 720 piksel dan menyimpan hasilnya dengan [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/). Pilih dimensi yang cocok dengan rasio aspek slide agar tidak terjadi pemanjangan gambar.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>
#include <drawing/size.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto imageSize = System::Drawing::Size(960, 720);

auto slideCount = presentation->get_Slides()->get_Count();
for (auto index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage(imageSize);
    image->Save(String::Format(u"slide_{0}.png", index), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

## **Pilih Gaya Rendering Gradien**

Misalkan sebuah slide berisi isian gradien, namun transisi pada PNG yang diekspor terlihat lebih terang atau berbeda dari yang Anda lihat di PowerPoint. Anda dapat menggunakan metode [SaveOptions::set_GradientStyle](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_gradientstyle/) dari [RenderingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/renderingoptions/) untuk memilih cara gradien dirender.

Unduh [gradient-styles.pptx](gradient-styles.pptx) dan letakkan di direktori kerja aplikasi. Slide pertamanya berisi dua gradien linear: cyan ke oranye di bagian atas dan biru ke kuning di bagian bawah. Setiap gradien memiliki dua stop, pada 0 % dan 100 %.

Contoh berikut memuat presentasi ini dan merender slide pertama yang sama dalam kedua mode dengan [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/).

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>
#include <DOM/GradientStyle.h>
#include <Export/RenderingOptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"gradient-styles.pptx");
auto slide = presentation->get_Slide(0);

auto gradientStyles = { GradientStyle::Default, GradientStyle::PowerPointUI };
for (auto style : gradientStyles)
{
    auto options = MakeObject<RenderingOptions>();
    options->set_GradientStyle(style);

    auto image = slide->GetImage(options, 1.f, 1.f);
    auto styleName = style == GradientStyle::Default ? u"Default" : u"PowerPointUI";
    image->Save(String::Format(u"gradient-{0}.png", styleName), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

Gambar di bawah menunjukkan hasil dari slide yang sama, dengan kedua gradien di tiap gambar:

| Default | PowerPointUI |
| --- | --- |
| ![Gradien cyan-ke-oranye dan biru-ke-kuning dirender dengan Default](gradient-Default.png) | ![Gradien yang sama dirender dengan PowerPointUI](gradient-PowerPointUI.png) |

Pada contoh ini, `Default` menghasilkan warna antara yang lebih terang, sementara `PowerPointUI` menghasilkan warna antara yang lebih gelap. Perbedaan tergantung pada warna dan stop dalam gradien.

Pilih `Default` ketika output standar Aspose.Slides sudah memenuhi kebutuhan Anda. Gunakan `PowerPointUI` bila prioritas Anda adalah mencocokkan tampilan di PowerPoint. Bandingkan kedua output dengan hasil yang Anda inginkan; tidak ada mode yang secara universal lebih baik.

## **Tanya Jawab**

**Bagaimana cara mengekspor bentuk tertentu, seperti diagram atau gambar, alih-alih seluruh slide?**

Aspose.Slides mendukung [generating thumbnails for individual shapes](/slides/id/cpp/shape-thumbnails/), memungkinkan Anda merender sebuah bentuk sebagai gambar PNG.

**Apakah konversi paralel didukung pada server?**

Ya. Gunakan instance presentasi terpisah untuk setiap thread atau proses; [do not share a single instance across threads](/slides/id/cpp/multithreading/).

**Apa batasan evaluasi saat mengekspor ke PNG?**

Mode evaluasi menambahkan watermark pada gambar output dan menerapkan [other restrictions](/slides/id/cpp/licensing/) hingga lisensi diterapkan.