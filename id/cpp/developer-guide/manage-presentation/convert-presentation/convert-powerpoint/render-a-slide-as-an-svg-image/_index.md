---
title: Render Slide Presentasi sebagai Gambar SVG di C++
linktitle: Slide ke SVG
type: docs
weight: 50
url: /id/cpp/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint ke SVG
- presentasi ke SVG
- slide ke SVG
- PPT ke SVG
- PPTX ke SVG
- opsi ekspor SVG
- SVG interaktif
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Ekspor slide PowerPoint sebagai gambar SVG di C++ dan kontrol font, teks, gambar, ID, serta peristiwa dengan Aspose.Slides."
---
## **Ikhtisar**

SVG adalah format gambar berbasis XML yang dapat diskalakan dan bekerja baik untuk publikasi web, penampil slide, alur kerja aksesibilitas, serta pemrosesan pasca otomatis. Aspose.Slides for C++ mengekspor setiap slide ke file SVG terpisah dan memungkinkan Anda mengontrol bagaimana teks, font, gambar, dan elemen SVG ditulis.

Gunakan [SVGOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/) ketika SVG yang diekspor harus kompak, dapat diprediksi di berbagai peramban, atau siap untuk penggunaan interaktif.

## **Mengekspor Slide sebagai SVG**

Buat [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/), pilih slide, dan tulis ke aliran. Contoh berikut mengekspor setiap slide dalam presentasi sebagai file SVG terpisah.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto slideCount = presentation->get_Slides()->get_Count();

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);
    auto svgFileName = String::Format(u"slide-{0}.svg", slide->get_SlideNumber());
    auto svgStream = File::Create(svgFileName);

    slide->WriteAsSvg(svgStream);
    svgStream->Dispose();
}

presentation->Dispose();
```

Nama file menggunakan [ISlide::get_SlideNumber](https://reference.aspose.com/slides/cpp/aspose.slides/islide/get_slidenumber/) alih‑alih indeks perulangan. Anda juga dapat mengekspor bentuk individual dengan [IShape::WriteAsSvg](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/writeassvg/) bila penampil slide atau halaman web hanya membutuhkan bentuk tersebut.

## **Mengonfigurasi Output SVG**

[SVGOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/) mengontrol rendering SVG. Untuk bingkai teks, [SVGOptions::set_UseFrameSize](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_useframesize/) menyertakan bingkai teks dalam area rendering, dan [SVGOptions::set_UseFrameRotation](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_useframerotation/) menentukan apakah rotasi bingkai diterapkan. Atur [SVGOptions::set_DisableFontLigatures](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_disablefontligatures/) ke `true` ketika teks harus dirender tanpa ligatur.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_DisableFontLigatures(true);
svgOptions->set_UseFrameSize(true);
svgOptions->set_UseFrameRotation(false);

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"slide-with-custom-options.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

## **Mengontrol Teks dan Font**

Saat mengekspor slide ke SVG, Anda dapat mengontrol apakah teks tetap sebagai teks atau diubah menjadi grafis vektor, serta bagaimana font eksternal disertakan atau dirujuk. Opsi‑opsi berikut membantu menyeimbangkan konsistensi visual, kemampuan pemilihan teks, dan ketergantungan font dalam SVG yang diekspor.

### **Vektorisasi Semua Teks**

Atur [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) ke `true` untuk menulis semua teks slide sebagai grafis vektor. Ini menghilangkan ketergantungan font dan membuat hasil visual lebih konsisten di berbagai peramban, tetapi teks tidak lagi dapat dipilih atau dicari sebagai teks SVG.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_VectorizeText(true);

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"slide-with-vectorized-text.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

### **Pilih Cara Menangani Font Eksternal**

[SVGOptions::set_ExternalFontsHandling](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_externalfontshandling/) menggunakan nilai [SvgExternalFontsHandling](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgexternalfontshandling/) untuk font yang dimuat secara eksternal. Pilih `AddLinksToFontFiles` untuk merujuk berkas font terpisah, `Embed` untuk menyertakan data font dalam SVG, atau `Vectorize` untuk merender hanya teks yang menggunakan font eksternal sebagai grafis. Verifikasi lisensi font sebelum menyematkan font.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SVGOptions.h>
#include <Export/SvgExternalFontsHandling.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto slide = presentation->get_Slide(0);

auto linkedFontsOptions = MakeObject<SVGOptions>();
linkedFontsOptions->set_ExternalFontsHandling(SvgExternalFontsHandling::AddLinksToFontFiles);
auto linkedFontsStream = File::Create(u"slide-with-font-links.svg");
slide->WriteAsSvg(linkedFontsStream, linkedFontsOptions);
linkedFontsStream->Dispose();

auto embeddedFontsOptions = MakeObject<SVGOptions>();
embeddedFontsOptions->set_ExternalFontsHandling(SvgExternalFontsHandling::Embed);
auto embeddedFontsStream = File::Create(u"slide-with-embedded-fonts.svg");
slide->WriteAsSvg(embeddedFontsStream, embeddedFontsOptions);
embeddedFontsStream->Dispose();

auto vectorizedExternalFontsOptions = MakeObject<SVGOptions>();
vectorizedExternalFontsOptions->set_ExternalFontsHandling(SvgExternalFontsHandling::Vectorize);
auto vectorizedExternalFontsStream = File::Create(u"slide-with-vectorized-external-fonts.svg");
slide->WriteAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
vectorizedExternalFontsStream->Dispose();

presentation->Dispose();
```

## **Mengurangi Ukuran Gambar Tertanam**

Gunakan [SVGOptions::set_PicturesCompression](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_picturescompression/) untuk mengurangi resolusi gambar yang tertanam, [SVGOptions::set_DeletePicturesCroppedAreas](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_deletepicturescroppedareas/) untuk menghilangkan area gambar yang dipotong, dan [SVGOptions::set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_jpegquality/) untuk mengontrol kualitas enkoding JPEG. Pengaturan ini mengurangi ukuran berkas dengan mengorbankan kesetiaan gambar atau data gambar yang dipertahankan.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/PicturesCompression.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_PicturesCompression(PicturesCompression::Dpi150);
svgOptions->set_DeletePicturesCroppedAreas(true);
svgOptions->set_JpegQuality(80);

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"compressed-slide.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

## **Mengontrol Resolusi Rasterisasi Metafile**

[SVGOptions::set_MetafileRasterizationDpi](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_metafilerasterizationdpi/) menetapkan batas resolusi terendah untuk merasterisasi metafile selama ekspor SVG. Gunakan untuk menyeimbangkan detail dan ukuran berkas ketika gambar EMF atau WMF dirasterisasi. Ini tidak mendefinisikan DPI global untuk SVG atau memaksa setiap objek pada slide menjadi gambar raster.

Unduh [metafile-rasterization.pptx](metafile-rasterization.pptx), yang berisi gambar EMF dengan garis diagonal berjarak rapat. Contoh berikut mengekspor slide pertama dengan tiga resolusi rasterisasi melalui [ISlide::WriteAsSvg](https://reference.aspose.com/slides/cpp/aspose.slides/islide/writeassvg/). Semua pengaturan ekspor lainnya tetap identik sehingga hasil dapat dibandingkan.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/PicturesCompression.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"metafile-rasterization.pptx");
auto slide = presentation->get_Slide(0);
const int resolutions[] = { 72, 150, 300 };

for (auto dpi : resolutions)
{
    auto svgOptions = MakeObject<SVGOptions>();
    svgOptions->set_MetafileRasterizationDpi(dpi);
    svgOptions->set_PicturesCompression(PicturesCompression::Dpi330);
    svgOptions->set_JpegQuality(90);

    auto svgFileName = String::Format(u"slide-{0}.svg", dpi);
    auto svgStream = File::Create(svgFileName);
    slide->WriteAsSvg(svgStream, svgOptions);
    svgStream->Dispose();
}

presentation->Dispose();
```

Dalam output, EMF menjadi satu PNG tersemat di setiap SVG. Pengukuran berikut untuk presentasi yang disediakan; bukan formula umum untuk mengubah DPI menjadi dimensi piksel.

| DPI rasterisasi Metafile | Dimensi PNG Tersemat | Ukuran file SVG (byte) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Perbandingan di bawah menunjukkan area raster tersemat yang sama pada ukuran tampilan yang diperbesar. Garis diagonal menunjukkan pikselasi yang terlihat pada 72 DPI dan tepi yang lebih halus pada resolusi lebih tinggi, sementara ukuran file SVG bertambah. Meningkatkan nilai tidak selalu memperbaiki setiap detail atau mengubah setiap gambar yang diekspor.

![Enlarged diagonal-line detail at 72, 150, and 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions::set_PicturesCompression](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_picturescompression/) mengontrol pengurangan resolusi gambar dan dapat menyamarkan efek perubahan resolusi rasterisasi metafile. [SVGOptions::set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_jpegquality/) mengontrol kualitas enkoding JPEG, bukan resolusi rasterisasi metafile.

## **Menetapkan ID Stabil untuk Bentuk dan Teks**

Gunakan [ISvgShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshapeformattingcontroller/) untuk menetapkan [ISvgShape::set_Id](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshape/set_id/) bagi setiap bentuk SVG. Untuk menetapkan nilai [ISvgTSpan::set_Id](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgtspan/set_id/) pada elemen `tspan` teks, implementasikan [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshapeandtextformattingcontroller/). Tetapkan salah satu controller dengan [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/).

Controller berikut menggunakan [IShape::get_OfficeInteropShapeId](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_officeinteropshapeid/), yang stabil selama masa hidup bentuk, serta penghitung berulang untuk span teksnya. Ini membuat ID yang dihasilkan cocok untuk pemrosesan lanjutan pada presentasi yang tidak berubah.

```cpp
#include <DOM/IPortion.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/ISvgShape.h>
#include <Export/ISvgShapeAndTextFormattingController.h>
#include <Export/ISvgTSpan.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

class StableSvgIdController : public ISvgShapeAndTextFormattingController
{
private:
    String m_currentShapeId;
    int m_textSpanIndex = 0;

public:
    void FormatShape(SharedPtr<ISvgShape> svgShape, SharedPtr<IShape> shape) override
    {
        m_currentShapeId = String::Format(u"shape-{0}", shape->get_OfficeInteropShapeId());
        m_textSpanIndex = 0;
        svgShape->set_Id(m_currentShapeId);
    }

    void FormatText(SharedPtr<ISvgTSpan> svgTSpan, SharedPtr<IPortion> portion,
                    SharedPtr<ITextFrame> textFrame) override
    {
        auto currentTextSpanIndex = m_textSpanIndex;
        m_textSpanIndex++;
        svgTSpan->set_Id(String::Format(u"{0}-text-{1}", m_currentShapeId, currentTextSpanIndex));
    }
};

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_ShapeFormattingController(MakeObject<StableSvgIdController>());

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"slide-with-stable-ids.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

## **Menambahkan Penangan Peristiwa SVG**

Dalam [ISvgShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshapeformattingcontroller/), panggil [ISvgShape::SetEventHandler](https://reference.aspose.com/slides/cpp/aspose.slides.export/isvgshape/seteventhandler/) dengan nilai [SvgEvent](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgevent/) untuk menambahkan penangan peristiwa JavaScript ke bentuk yang diekspor. Tetapkan controller dengan [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/) dan definisikan fungsi JavaScript di halaman atau dokumen SVG yang menampung hasilnya.

```cpp
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/ISvgShape.h>
#include <Export/ISvgShapeFormattingController.h>
#include <Export/SVGOptions.h>
#include <Export/SvgEvent.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

class SvgEventController : public ISvgShapeFormattingController
{
public:
    void FormatShape(SharedPtr<ISvgShape> svgShape, SharedPtr<IShape> shape) override
    {
        if (shape->get_Name() == u"ActionButton")
        {
            svgShape->set_Id(u"action-button");
            svgShape->SetEventHandler(SvgEvent::OnClick, u"handleShapeClick(event)");
        }
    }
};

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_ShapeFormattingController(MakeObject<SvgEventController>());

auto slide = presentation->get_Slide(0);
auto svgStream = File::Create(u"interactive-slide.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```

Halaman host dapat mendefinisikan fungsi JavaScript yang dirujuk oleh penangan. Menetapkan ID dan penangan peristiwa memungkinkan penampil slide, peningkatan aksesibilitas, dan alur kerja SVG interaktif lainnya.

## **FAQ**

**Kapan saya harus menggunakan [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) alih‑alih [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgexternalfontshandling/)?**

Gunakan [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) ketika semua teks harus independen dari font. Gunakan [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/cpp/aspose.slides.export/svgexternalfontshandling/) ketika hanya teks yang menggunakan font eksternal yang harus diubah menjadi grafis.

**Apa cara terbaik untuk membuat SVG lebih kecil?**

Mulailah dengan mengompresi gambar yang tertanam, menghapus area gambar yang dipotong, dan memilih file font yang ditautkan ketika lingkungan target dapat menyediakannya. Uji hasilnya karena resolusi gambar yang lebih rendah, kualitas JPEG yang lebih rendah, dan teks yang tervektorisasi masing‑masing memiliki kompromi kualitas dan ukuran yang berbeda.

**Bisakah saya memodifikasi elemen SVG yang diekspor setelah ekspor?**

Ya. Tetapkan ID melalui controller pemformatan, lalu pilih elemen SVG yang cocok dalam alat pemrosesan lanjutan atau skrip peramban Anda.