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
- menggambar tinta
- menggambar
- ekspor tinta
- rendering tinta
- sembunyikan tinta
- IInkOptions
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Kelola objek tinta PowerPoint, edit jejak dan properti kuas, serta kontrol penampilan tinta selama ekspor PDF, HTML, SVG, TIFF, dan gambar dengan Aspose.Slides untuk C++."
---
## **Pendahuluan**

PowerPoint menyediakan fitur tinta yang memungkinkan Anda menggambar goresan bebas. Tinta dapat digunakan untuk menyorot objek lain, menunjukkan hubungan dan proses, serta menarik perhatian ke item tertentu pada slide.

Namespace [Aspose.Slides.Ink](https://reference.aspose.com/slides/id/cpp/aspose.slides.ink/) berisi kelas dan antarmuka yang diperlukan untuk bekerja dengan objek tinta. Misalnya, antarmuka [IInk](https://reference.aspose.com/slides/id/cpp/aspose.slides.ink/iink/) mewakili objek tinta pada slide.

## **Perbedaan antara Objek Biasa dan Objek Tinta**

Objek pada slide PowerPoint biasanya direpresentasikan sebagai objek bentuk. Dalam bentuk paling sederhana, sebuah bentuk adalah wadah yang menentukan area objek itu sendiri (kerangkanya) bersama properti seperti ukuran wadah, bentuk, dan latar belakang. Untuk informasi lebih lanjut, lihat [Shape Layout Format](https://docs.aspose.com/slides/id/cpp/shape-manipulations/#access-layout-formats-for-shape).

Namun, ketika PowerPoint menangani objek tinta, ia mengabaikan semua properti kerangka objek (wadah) kecuali ukurannya. Ukuran area wadah ditentukan oleh metode standar [IShape::get_Width](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/get_width/) dan [IShape::get_Height](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/get_height/):

![ink_powerpoint1](ink_powerpoint1.png)

## **Jejak Tinta**

Jejak tinta adalah elemen dasar yang digunakan untuk merekam lintasan pena saat pengguna menulis tinta digital. Sebuah jejak menyimpan urutan titik yang terhubung.

Bentuk enkoding paling sederhana menyebutkan koordinat X dan Y dari setiap titik sampel. Ketika semua titik terhubung dirender, mereka menghasilkan gambar seperti ini:

![ink_powerpoint2](ink_powerpoint2.png)

## **Properti Kuas untuk Menggambar**

Kuas digunakan untuk menggambar garis yang menghubungkan titik-titik jejak tinta. Kuas memiliki warna dan ukuran masing-masing, yang direpresentasikan oleh metode [IInkBrush::get_Color](https://reference.aspose.com/slides/id/cpp/aspose.slides.ink/iinkbrush/get_color/) dan [IInkBrush::get_Size](https://reference.aspose.com/slides/id/cpp/aspose.slides.ink/iinkbrush/get_size/).

### **Mengatur Warna Kuas Tinta**

Kode C++ ini menunjukkan cara mengatur warna kuas tinta:

```cpp
#include <DOM/Ink/IInk.h>
#include <DOM/Ink/IInkBrush.h>
#include <DOM/Ink/IInkTrace.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Ink::IInk;
using Aspose::Slides::Presentation;
using System::ExplicitCast;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"pres.pptx");
auto ink = ExplicitCast<IInk>(presentation->get_Slide(0)->get_Shape(0));
auto inkTrace = ink->get_Traces()[0];
auto brush = inkTrace->get_Brush();
brush->set_Color(System::Drawing::Color::get_Red());

presentation->Dispose();
```

### **Mengatur Ukuran Kuas Tinta**

Kode C++ ini menunjukkan cara mengatur ukuran kuas tinta:

```cpp
#include <DOM/Ink/IInk.h>
#include <DOM/Ink/IInkBrush.h>
#include <DOM/Ink/IInkTrace.h>
#include <DOM/Presentation.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Ink::IInk;
using Aspose::Slides::Presentation;
using System::ExplicitCast;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"pres.pptx");
auto ink = ExplicitCast<IInk>(presentation->get_Slide(0)->get_Shape(0));
auto inkTrace = ink->get_Traces()[0];
auto brush = inkTrace->get_Brush();
brush->set_Size(System::Drawing::SizeF(5.0f, 10.0f));

presentation->Dispose();
```

Secara umum, lebar dan tinggi kuas tidak cocok, sehingga PowerPoint tidak menampilkan ukuran kuas (bagian data yang bersangkutan berwarna abu‑abu). Ketika lebar dan tinggi kuas cocok, PowerPoint menampilkan ukurannya seperti ini:

![ink_powerpoint3](ink_powerpoint3.png)

Untuk kejelasan, mari tingkatkan tinggi objek tinta dan tinjau dimensi penting:

![ink_powerpoint4](ink_powerpoint4.png)

Wadah (kerangka) tidak memperhitungkan ukuran kuas—ia selalu mengasumsikan ketebalan garis nol (lihat gambar sebelumnya).

Oleh karena itu, untuk menentukan area yang terlihat dari seluruh objek tinta, ukuran kuas pada jejaknya harus dipertimbangkan. Di sini, objek target (jejak teks tulisan tangan) telah diskalakan ke ukuran wadah (kerangka). Ketika ukuran wadah berubah, ukuran kuas tetap konstan, dan sebaliknya.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint menggunakan perilaku serupa untuk objek teks:

![ink_powerpoint6](ink_powerpoint6.png)

## **Mengontrol Penampilan Tinta saat Ekspor dan Rendering**

Aspose.Slides menyediakan antarmuka [IInkOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/iinkoptions/) untuk mengontrol bagaimana objek tinta muncul dalam output yang diekspor atau dirender. Anda dapat menggunakan metodenya untuk menyembunyikan tinta sepenuhnya atau mengubah cara operasi mask kuas tinta diinterpretasikan.

Opsi tinta tersedia melalui opsi ekspor atau rendering untuk beberapa jenis output:

| Output | Metode opsi tinta |
| --- | --- |
| PDF | [PdfOptions::get_InkOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/pdfoptions/get_inkoptions/) |
| HTML | [HtmlOptions::get_InkOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/htmloptions/get_inkoptions/) |
| SVG | [SVGOptions::get_InkOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/svgoptions/get_inkoptions/) |
| TIFF | [TiffOptions::get_InkOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/tiffoptions/get_inkoptions/) |
| Gambar slide | [RenderingOptions::get_InkOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/renderingoptions/get_inkoptions/) |

Dua pengaturan yang sama tersedia melalui metode tersebut:

- [IInkOptions::set_HideInk](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/iinkoptions/set_hideink/) menentukan apakah objek tinta termasuk dalam output. Nilai defaultnya adalah `false`.
- [IInkOptions::set_InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/iinkoptions/set_interpretmaskopasopacity/) menentukan apakah operasi mask diinterpretasikan sebagai opasitas saat merender kuas tinta. Nilai defaultnya adalah `true`; ubah menjadi `false` untuk menggunakan operasi ROP sebagai gantinya.

### **Menyembunyikan Objek Tinta pada Output PDF**

Secara default, objek tinta tetap terlihat saat ekspor. Panggil [IInkOptions::set_HideInk](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/iinkoptions/set_hideink/) dengan `true` ketika Anda memerlukan output bersih tanpa anotasi tulisan tangan atau konten tinta lainnya.

Contoh C++ berikut mengekspor presentasi ke PDF sambil menyembunyikan semua objek tinta:

```cpp
#include <DOM/Presentation.h>
#include <Export/IInkOptions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::PdfOptions;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->get_InkOptions()->set_HideInk(true);

presentation->Save(u"presentation_without_ink.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **Menyembunyikan Objek Tinta saat Rendering Slide menjadi Gambar**

Untuk menyembunyikan objek tinta saat merender slide menjadi gambar bitmap, konfigurasikan [RenderingOptions::get_InkOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/renderingoptions/get_inkoptions/) dan lewati opsi rendering ke metode [ISlide::GetImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/islide/getimage/).

Contoh C++ berikut merender slide pertama sebagai gambar PNG tanpa objek tinta:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/IInkOptions.h>
#include <Export/RenderingOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::ImageFormat;
using Aspose::Slides::Presentation;
using Aspose::Slides::Export::RenderingOptions;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->get_InkOptions()->set_HideInk(true);

auto image = presentation->get_Slide(0)->GetImage(renderingOptions);
image->Save(u"slide_without_ink.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

### **Mengontrol Rendering Mask Tinta**

Metode [IInkOptions::set_InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/iinkoptions/set_interpretmaskopasopacity/) mengontrol bagaimana operasi mask diinterpretasikan saat merender kuas tinta. Nilai defaultnya adalah `true`, yang menggunakan opasitas. Panggil metode dengan `false` untuk menggunakan operasi ROP sebagai gantinya.

Contoh C++ berikut mengekspor slide ke SVG dan menggunakan rendering berbasis ROP untuk operasi mask tinta:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/IInkOptions.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::SVGOptions;
using System::MakeObject;
using System::IO::File;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->get_InkOptions()->set_InterpretMaskOpAsOpacity(false);

auto stream = File::Create(u"slide.svg");
presentation->get_Slide(0)->WriteAsSvg(stream, svgOptions);

stream->Dispose();
presentation->Dispose();
```

Pengaturan yang sama dapat diterapkan melalui [TiffOptions::get_InkOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/tiffoptions/get_inkoptions/) saat mengekspor presentasi atau merender slide ke TIFF.

### **Memilih untuk Menyembunyikan atau Mempertahankan Tinta**

Gunakan [IInkOptions::set_HideInk](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/iinkoptions/set_hideink/) dengan `true` ketika file yang diekspor harus menjadi versi bersih dari presentasi yang dianotasi, misalnya salinan akhir yang akan didistribusikan tanpa tanda tinjauan.

Biarkan tinta terlihat (pengaturan default `false`) ketika anotasi tinta merupakan bagian dari konten yang diinginkan, seperti komentar tinjauan, catatan tulisan tangan, sorotan, atau gambar yang harus tetap terlihat dalam hasil ekspor. Ini memungkinkan aplikasi menghasilkan output tinjauan dan akhir terpisah dari presentasi yang sama tanpa mengubah objek tinta sumber.

## **FAQ**

**Apakah saya dapat mengubah warna atau ukuran goresan tinta yang sudah ada?**

Ya. Dapatkan jejak dari [IInk::get_Traces](https://reference.aspose.com/slides/id/cpp/aspose.slides.ink/iink/get_traces/), lalu ubah [IInkTrace::get_Brush](https://reference.aspose.com/slides/id/cpp/aspose.slides.ink/iinktrace/get_brush/). Anda dapat memanggil [IInkBrush::set_Color](https://reference.aspose.com/slides/id/cpp/aspose.slides.ink/iinkbrush/set_color/) dan [IInkBrush::set_Size](https://reference.aspose.com/slides/id/cpp/aspose.slides.ink/iinkbrush/set_size/) pada kuas.

**Apakah menyembunyikan tinta mengubah presentasi sumber?**

Tidak. [IInkOptions::set_HideInk](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/iinkoptions/set_hideink/) hanya memengaruhi hasil yang dirender atau diekspor; ia tidak menghapus atau memodifikasi objek tinta dalam presentasi sumber.

**Format ekspor apa yang mendukung opsi tinta?**

Anda dapat mengonfigurasi opsi tinta untuk PDF, HTML, SVG, TIFF, dan gambar slide bitmap melalui opsi ekspor atau rendering yang ditunjukkan di atas.

**Bacaan lanjutan**

* Untuk mempelajari tentang bentuk secara umum, lihat bagian [PowerPoint Shapes](https://docs.aspose.com/slides/id/cpp/powerpoint-shapes/).
* Untuk informasi lebih lanjut tentang nilai efektif, lihat [Shape Effective Properties](https://docs.aspose.com/slides/id/cpp/shape-effective-properties/#get-effective-font-height-value).
* Untuk detail tentang ekspor PDF, lihat [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/id/cpp/convert-powerpoint-to-pdf/).
* Untuk detail tentang ekspor HTML, lihat [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/id/cpp/convert-powerpoint-to-html/).
* Untuk detail tentang ekspor SVG, lihat [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/id/cpp/render-a-slide-as-an-svg-image/).
* Untuk detail tentang ekspor TIFF, lihat [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/id/cpp/convert-powerpoint-to-tiff/).
* Untuk detail tentang rendering slide menjadi gambar, lihat [Convert Presentation Slides to Images](https://docs.aspose.com/slides/id/cpp/convert-slide/).