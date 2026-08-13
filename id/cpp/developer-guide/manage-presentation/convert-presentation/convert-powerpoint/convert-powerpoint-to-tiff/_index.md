---
title: Konversi Presentasi PowerPoint ke TIFF dalam C++
titlelink: PowerPoint ke TIFF
type: docs
weight: 90
url: /id/cpp/convert-powerpoint-to-tiff/
keywords:
- konversi PowerPoint
- konversi OpenDocument
- konversi presentasi
- konversi slide
- konversi PPT
- konversi PPTX
- PowerPoint ke TIFF
- presentasi ke TIFF
- slide ke TIFF
- PPT ke TIFF
- PPTX ke TIFF
- simpan PPT sebagai TIFF
- simpan PPTX sebagai TIFF
- ekspor PPT ke TIFF
- ekspor PPTX ke TIFF
- C++
- Aspose.Slides
description: "Pelajari cara mudah mengonversi presentasi PowerPoint (PPT, PPTX) menjadi gambar TIFF berkualitas tinggi menggunakan Aspose.Slides untuk C++, dengan contoh kode."
---
## **Pendahuluan**

TIFF (**Tagged Image File Format**) adalah format gambar raster lossless yang banyak digunakan, dikenal karena kualitasnya yang luar biasa dan preservasi detail grafis. Desainer, fotografer, dan penerbit desktop sering memilih TIFF untuk mempertahankan lapisan, akurasi warna, dan pengaturan asli dalam gambar mereka.

Dengan Aspose.Slides, Anda dapat dengan mudah mengonversi slide PowerPoint (PPT, PPTX) dan slide OpenDocument (ODP) langsung menjadi gambar TIFF berkualitas tinggi, memastikan presentasi Anda mempertahankan fidelitas visual maksimum.

## **Mengonversi Presentasi ke TIFF**

Dengan menggunakan metode [Save](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/save/) yang disediakan oleh kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/), Anda dapat dengan cepat mengonversi seluruh presentasi PowerPoint ke TIFF. Gambar TIFF yang dihasilkan sesuai dengan ukuran slide default.

Kode C++ berikut menunjukkan cara mengonversi presentasi PowerPoint ke TIFF:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Buat instance kelas Presentation yang mewakili file presentasi (PPT, PPTX, ODP, dll).
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

// Simpan presentasi sebagai TIFF.
presentation->Save(u"Output.tiff", SaveFormat::Tiff);

presentation->Dispose();
```

## **Mengonversi Presentasi ke TIFF Hitam-Putih**

Metode [set_BwConversionMode](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) dalam kelas [TiffOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/tiffoptions/) memungkinkan Anda menentukan algoritma yang digunakan saat mengonversi slide atau gambar berwarna menjadi TIFF hitam-putih. Perhatikan bahwa pengaturan ini hanya berlaku ketika metode [set_CompressionType](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) disetel ke `CCITT4` atau `CCITT3`.

Misalkan kami memiliki file "sample.pptx" dengan slide berikut:

![Sebuah slide presentasi](slide_black_and_white.png)

Kode C++ berikut menunjukkan cara mengonversi slide berwarna menjadi TIFF hitam-putih:

```cpp
#include <DOM/Presentation.h>
#include <Export/BlackWhiteConversionMode.h>
#include <Export/SaveFormat.h>
#include <Export/TiffCompressionTypes.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_CompressionType(TiffCompressionTypes::CCITT4);
tiffOptions->set_BwConversionMode(BlackWhiteConversionMode::Dithering);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

Hasilnya:

![TIFF Hitam-Putih](TIFF_black_and_white.png)

## **Mengonversi Presentasi ke TIFF dengan Ukuran Kustom**

Jika Anda memerlukan gambar TIFF dengan dimensi tertentu, Anda dapat mengatur nilai yang diinginkan menggunakan metode yang tersedia di [TiffOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/tiffoptions/). Misalnya, metode [set_ImageSize](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/tiffoptions/set_imagesize/) memungkinkan Anda mendefinisikan ukuran gambar yang dihasilkan.

Kode C++ berikut menunjukkan cara mengonversi presentasi PowerPoint ke gambar TIFF dengan ukuran kustom:

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/SaveFormat.h>
#include <Export/TiffCompressionTypes.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Buat instance kelas Presentation yang mewakili file presentasi (PPT, PPTX, ODP, dll).
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

// Setel tipe kompresi.
tiffOptions->set_CompressionType(TiffCompressionTypes::Default);
/*
Compression types:
    Default - Menentukan skema kompresi default (LZW).
    None - Menentukan tidak ada kompresi.
    CCITT3
    CCITT4
    LZW
    RLE
*/

// Kedalaman tergantung pada tipe kompresi dan tidak dapat diatur secara manual.

// Setel DPI gambar.
tiffOptions->set_DpiX(200);
tiffOptions->set_DpiY(200);

// Setel ukuran gambar.
tiffOptions->set_ImageSize(System::Drawing::Size(1728, 1078));

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// Simpan presentasi sebagai TIFF dengan ukuran yang ditentukan.
presentation->Save(u"custom_size.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

## **Mengonversi Presentasi ke TIFF dengan Format Piksel Gambar Kustom**

Dengan menggunakan metode [set_PixelFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) dari kelas [TiffOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/tiffoptions/), Anda dapat menentukan format piksel yang Anda inginkan untuk gambar TIFF yang dihasilkan.

Kode C++ berikut menunjukkan cara mengonversi presentasi PowerPoint ke gambar TIFF dengan format piksel kustom:

```cpp
#include <DOM/Presentation.h>
#include <Export/ImagePixelFormat.h>
#include <Export/SaveFormat.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Buat instance kelas Presentation yang mewakili file presentasi (PPT, PPTX, ODP, dll).
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

tiffOptions->set_PixelFormat(ImagePixelFormat::Format8bppIndexed);
/*
ImagePixelFormat berisi nilai-nilai berikut (seperti yang tercantum dalam dokumentasi):
    Format1bppIndexed - 1 bit per piksel, diindeks.
    Format4bppIndexed - 4 bit per piksel, diindeks.
    Format8bppIndexed - 8 bit per piksel, diindeks.
    Format24bppRgb    - 24 bit per piksel, RGB.
    Format32bppArgb   - 32 bit per piksel, ARGB.
*/

// Simpan presentasi sebagai TIFF dengan ukuran gambar yang ditentukan.
presentation->Save(u"Custom_Image_Pixel_Format.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

{{% alert title="Tip" color="info" %}}
Lihat [konverter PowerPoint ke Poster GRATIS](https://products.aspose.app/slides/id/conversion/convert-ppt-to-poster-online) dari Aspose.
{{% /alert %}}

## **FAQ**

### Bisakah saya mengonversi slide individual alih-alih seluruh presentasi PowerPoint ke TIFF?

Ya. Aspose.Slides memungkinkan Anda mengonversi slide individual dari presentasi PowerPoint dan OpenDocument menjadi gambar TIFF secara terpisah.

### Apakah ada batasan jumlah slide saat mengonversi presentasi ke TIFF?

Tidak, Aspose.Slides tidak memberlakukan batasan apa pun pada jumlah slide. Anda dapat mengonversi presentasi berukuran apa saja ke format TIFF.

### Apakah animasi dan efek transisi PowerPoint dipertahankan saat mengonversi slide ke TIFF?

Tidak, TIFF adalah format gambar statis. Oleh karena itu, animasi dan efek transisi tidak dipertahankan; hanya snapshot statis slide yang diekspor.