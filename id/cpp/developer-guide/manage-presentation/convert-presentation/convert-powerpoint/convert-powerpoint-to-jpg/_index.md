---
title: Mengonversi PPT dan PPTX ke JPG dalam C++
linktitle: PowerPoint ke JPG
type: docs
weight: 60
url: /id/cpp/convert-powerpoint-to-jpg/
keywords:
- konversi PowerPoint
- mengonversi presentasi
- mengonversi slide
- mengonversi PPT
- mengonversi PPTX
- PowerPoint ke JPG
- presentasi ke JPG
- slide ke JPG
- PPT ke JPG
- PPTX ke JPG
- menyimpan PowerPoint sebagai JPG
- menyimpan presentasi sebagai JPG
- menyimpan slide sebagai JPG
- menyimpan PPT sebagai JPG
- menyimpan PPTX sebagai JPG
- mengekspor PPT ke JPG
- mengekspor PPTX ke JPG
- C++
- Aspose.Slides
description: "Mengonversi slide PowerPoint (PPT, PPTX) menjadi gambar JPG berkualitas tinggi dalam C++ dengan Aspose.Slides menggunakan contoh kode yang cepat dan andal."
---
## **Pendahuluan**

Mengonversi presentasi PowerPoint dan OpenDocument menjadi gambar JPG membantu dalam berbagi slide, mengoptimalkan kinerja, dan menyematkan konten ke situs web atau aplikasi. Aspose.Slides for C++ memungkinkan Anda mengubah file PPTX, PPT, dan ODP menjadi gambar JPEG berkualitas tinggi. Panduan ini menjelaskan berbagai metode konversi.

Dengan fitur-fitur ini, mudah untuk mengimplementasikan penampil presentasi Anda sendiri dan membuat thumbnail untuk setiap slide. Ini dapat berguna jika Anda ingin melindungi slide presentasi dari penyalinan atau memperlihatkan presentasi dalam mode hanya-baca. Aspose.Slides memungkinkan Anda mengonversi seluruh presentasi atau slide tertentu ke format gambar.

## **Mengonversi Slide Presentasi ke Gambar JPG**

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/).
2. Dapatkan objek slide dengan tipe [ISlide](https://reference.aspose.com/slides/id/cpp/aspose.slides/islide/) dari koleksi slide presentasi.
3. Buat gambar slide menggunakan metode [ISlide.GetImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/islide/getimage/).
4. Panggil metode [IImage.Save](https://reference.aspose.com/slides/id/cpp/aspose.slides/iimage/save/) pada objek gambar. Berikan nama file output dan format gambar sebagai argumen.

{{% alert color="info" %}} 
**Catatan:** Konversi PPT, PPTX, atau ODP ke JPG berbeda dari konversi ke format lain dalam API Aspose.Slides for C++. Untuk format lain, biasanya Anda menggunakan metode [IPresentation.Save](https://reference.aspose.com/slides/id/cpp/aspose.slides/ipresentation/save/). Namun, untuk konversi JPG, Anda perlu menggunakan metode [IImage.Save](https://reference.aspose.com/slides/id/cpp/aspose.slides/iimage/save/).
{{% /alert %}} 

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/enumerator_adapter.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

float scaleX = 1.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.ppt");

for (auto&& slide : presentation->get_Slides())
{
    // Buat gambar slide dengan skala yang ditentukan.
    auto image = slide->GetImage(scaleX, scaleY);

    // Simpan gambar ke disk dalam format JPEG.
    auto fileName = String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **Mengonversi Slide ke JPG dengan Dimensi yang Disesuaikan**

Untuk mengubah dimensi gambar JPG yang dihasilkan, Anda dapat mengatur ukuran gambar dengan memasukkannya ke dalam metode [ISlide.GetImage(Size)](https://reference.aspose.com/slides/id/cpp/aspose.slides/islide/getimage/#islidegetimagesystemdrawingsize-method). Hal ini memungkinkan Anda menghasilkan gambar dengan lebar dan tinggi tertentu, memastikan output memenuhi kebutuhan resolusi dan rasio aspek Anda. Fleksibilitas ini sangat berguna saat menghasilkan gambar untuk aplikasi web, laporan, atau dokumentasi, di mana dimensi gambar yang tepat diperlukan.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

System::Drawing::Size imageSize(1200, 800);

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // Buat gambar slide dengan ukuran yang ditentukan.
    auto image = slide->GetImage(imageSize);

    // Simpan gambar ke disk dalam format JPEG.
    auto fileName = System::String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **Render Komentar Saat Menyimpan Slide sebagai Gambar**

Aspose.Slides for C++ menyediakan fitur yang memungkinkan Anda merender komentar pada slide presentasi saat mengonversinya menjadi gambar JPG. Fungsionalitas ini sangat berguna untuk mempertahankan anotasi, umpan balik, atau diskusi yang ditambahkan oleh kolaborator dalam presentasi PowerPoint. Dengan mengaktifkan opsi ini, Anda memastikan komentar terlihat pada gambar yang dihasilkan, memudahkan peninjauan dan berbagi umpan balik tanpa perlu membuka file presentasi asli.

Misalkan kita memiliki file presentasi, "sample.pptx," dengan slide yang berisi komentar:

![Slide dengan komentar](slide_with_comments.png)

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/CommentsPositions.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/RenderingOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

float scaleX = 2.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
{
    auto commentOptions = MakeObject<NotesCommentsLayoutingOptions>();
    commentOptions->set_CommentsPosition(CommentsPositions::Right);
    commentOptions->set_CommentsAreaWidth(200);
    commentOptions->set_CommentsAreaColor(Color::get_DarkOrange());

    // Atur opsi untuk komentar slide.
    auto options = MakeObject<RenderingOptions>();
    options->set_SlidesLayoutOptions(commentOptions);

    // Konversi slide pertama menjadi gambar.
    auto image = presentation->get_Slide(0)->GetImage(options, scaleX, scaleY);

    image->Save(u"Slide_1.jpg", ImageFormat::Jpeg);
    image->Dispose();
}

presentation->Dispose();
```

Hasilnya:

![Gambar JPG dengan komentar](image_with_comments.png)

## **Lihat Juga**

- [Mengonversi PowerPoint ke GIF](/slides/id/cpp/convert-powerpoint-to-animated-gif/)
- [Mengonversi PowerPoint ke PNG](/slides/id/cpp/convert-powerpoint-to-png/)
- [Mengonversi PowerPoint ke TIFF](/slides/id/cpp/convert-powerpoint-to-tiff/)
- [Mengonversi PowerPoint ke SVG](/slides/id/cpp/render-a-slide-as-an-svg-image/)

{{% alert color="info" %}} 
Untuk melihat bagaimana Aspose.Slides mengonversi PowerPoint ke gambar JPG, coba konverter online gratis berikut: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/id/conversion/pptx-to-jpg) dan [PPT to JPG](https://products.aspose.app/slides/id/conversion/ppt-to-jpg). 
{{% /alert %}}

![Konverter PPTX ke JPG Online Gratis](ppt-to-jpg.png)

{{% alert title="Tip" color="info" %}}

Aspose menyediakan [aplikasi web Collage GRATIS](https://products.aspose.app/slides/id/collage). Dengan layanan online ini, Anda dapat menggabungkan gambar [JPG ke JPG](https://products.aspose.app/slides/id/collage/jpg) atau PNG ke PNG, membuat [grid foto](https://products.aspose.app/slides/id/collage/photo-grid), dan sebagainya. 

Dengan prinsip yang sama seperti dijelaskan dalam artikel ini, Anda dapat mengonversi gambar dari satu format ke format lain. Untuk informasi lebih lanjut, lihat halaman berikut: konversi [image to JPG](https://products.aspose.com/slides/id/cpp/conversion/image-to-jpg/); konversi [JPG to image](https://products.aspose.com/slides/id/cpp/conversion/jpg-to-image/); konversi [JPG to PNG](https://products.aspose.com/slides/id/cpp/conversion/jpg-to-png/), konversi [PNG to JPG](https://products.aspose.com/slides/id/cpp/conversion/png-to-jpg/); konversi [PNG to SVG](https://products.aspose.com/slides/id/cpp/conversion/png-to-svg/), konversi [SVG to PNG](https://products.aspose.com/slides/id/cpp/conversion/svg-to-png/).
{{% /alert %}}

## **FAQ**

### Apakah metode ini mendukung konversi batch?

Ya, Aspose.Slides memungkinkan konversi batch banyak slide ke JPG dalam satu operasi.

### Apakah konversi mendukung SmartArt, diagram, dan objek kompleks lainnya?

Ya, Aspose.Slides merender semua konten, termasuk SmartArt, diagram, tabel, bentuk, dan lainnya. Namun, akurasi rendering mungkin sedikit berbeda dibandingkan PowerPoint, terutama ketika menggunakan font khusus atau yang tidak ada.

### Apakah ada batasan jumlah slide yang dapat diproses?

Aspose.Slides sendiri tidak memberlakukan batasan ketat pada jumlah slide yang dapat Anda proses. Namun, Anda mungkin mengalami error kehabisan memori saat bekerja dengan presentasi besar atau gambar beresolusi tinggi.