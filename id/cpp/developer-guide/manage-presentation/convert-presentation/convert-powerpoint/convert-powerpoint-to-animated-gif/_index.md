---
title: Mengonversi Presentasi PowerPoint ke GIF Animasi dalam C++
linktitle: PowerPoint ke GIF
type: docs
weight: 65
url: /id/cpp/convert-powerpoint-to-animated-gif/
keywords:
- GIF animasi
- mengonversi PowerPoint
- mengonversi presentasi
- mengonversi slide
- mengonversi PPT
- mengonversi PPTX
- PowerPoint ke GIF
- presentasi ke GIF
- slide ke GIF
- PPT ke GIF
- PPTX ke GIF
- menyimpan PPT sebagai GIF
- menyimpan PPTX sebagai GIF
- mengekspor PPT sebagai GIF
- mengekspor PPTX sebagai GIF
- pengaturan default
- pengaturan kustom
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Dengan mudah mengonversi presentasi PowerPoint (PPT, PPTX) ke GIF animasi menggunakan Aspose.Slides untuk C++. Hasil cepat dan berkualitas tinggi."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda mengonversi presentasi PowerPoint ke file GIF animasi dengan hanya beberapa baris kode. Ini berguna ketika Anda perlu berbagi konten slide dalam format animasi ringan, didukung secara luas, yang dapat disematkan di halaman web, messenger, atau dokumentasi. Artikel ini menjelaskan cara mengekspor presentasi ke GIF menggunakan pengaturan default dan cara menyesuaikan output dengan mengonfigurasi opsi seperti ukuran bingkai, jeda slide, dan kecepatan bingkai transisi melalui [GifOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/gifoptions/).

## **Mengonversi Presentasi ke GIF Animasi dengan Pengaturan Default**

Contoh kode berikut dalam C++ menunjukkan cara mengonversi presentasi ke GIF animasi menggunakan pengaturan standar:

``` cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif);
```

GIF animasi akan dibuat dengan parameter default. 

{{%  alert  title="TIP"  color="info"  %}} 

Jika Anda ingin menyesuaikan parameter untuk GIF, Anda dapat menggunakan kelas [GifOptions](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.export.gif_options). Lihat contoh kode di bawah ini. 

{{% /alert %}} 

## **Mengonversi Presentasi ke GIF Animasi dengan Pengaturan Kustom**

Contoh kode berikut menunjukkan cara mengonversi presentasi ke GIF animasi menggunakan pengaturan kustom dalam C++:

``` cpp
#include <DOM/Presentation.h>
#include <Export/GifOptions.h>
#include <Export/SaveFormat.h>
#include <drawing/size.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto gifOptions = System::MakeObject<GifOptions>();
// ukuran GIF yang dihasilkan
gifOptions->set_FrameSize(System::Drawing::Size(960, 720));
// berapa lama setiap slide akan ditampilkan sampai diganti dengan slide berikutnya
gifOptions->set_DefaultDelay(2000);
// tingkatkan FPS untuk kualitas animasi transisi yang lebih baik
gifOptions->set_TransitionFps(35);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif, gifOptions);
```

{{% alert title="Info" color="info" %}}

Anda mungkin ingin mencoba konverter GRATIS [Text to GIF](https://products.aspose.app/slides/id/text-to-gif) yang dikembangkan oleh Aspose. 

{{% /alert %}}

## **FAQ**

### Bagaimana jika font yang digunakan dalam presentasi tidak terpasang di sistem?

Instal font yang hilang atau [konfigurasikan fallback fonts](/slides/id/cpp/powerpoint-fonts/). Aspose.Slides akan melakukan substitusi, namun tampilannya mungkin berbeda. Untuk keperluan branding, pastikan semua tipe huruf yang diperlukan tersedia secara eksplisit.

### Bisakah saya menambahkan watermark pada bingkai GIF?

Ya. [Tambahkan objek/logo semi-transparan](/slides/id/cpp/watermark/) ke master slide atau ke slide individu sebelum ekspor — watermark akan muncul pada setiap bingkai.