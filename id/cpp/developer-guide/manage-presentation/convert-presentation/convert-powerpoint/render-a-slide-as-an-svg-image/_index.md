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
## **Gambaran Umum**

SVG adalah format gambar berbasis XML yang dapat diskalakan dan bekerja dengan baik untuk publikasi web, penampil slide, alur kerja aksesibilitas, dan pemrosesan pasca otomatis. Aspose.Slides untuk C++ mengekspor setiap slide ke file SVG terpisah dan memungkinkan Anda mengontrol cara teks, font, gambar, dan elemen SVG ditulis.

Gunakan [SVGOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/svgoptions/) ketika SVG yang diekspor harus kompak, dapat diprediksi di semua peramban, atau siap untuk penggunaan interaktif.

## **Ekspor Slide sebagai SVG**

Buat sebuah [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/), pilih sebuah slide, dan tulis ke stream. Contoh berikut mengekspor setiap slide dalam sebuah presentasi sebagai file SVG terpisah.

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

Nama file menggunakan [ISlide::get_SlideNumber](https://reference.aspose.com/slides/id/cpp/aspose.slides/islide/get_slidenumber/) bukan indeks perulangan. Anda juga dapat mengekspor sebuah bentuk individu dengan [IShape::WriteAsSvg](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/writeassvg/) ketika penampil slide atau halaman web hanya membutuhkan bentuk tersebut.

## **Konfigurasi Output SVG**

[SVGOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/svgoptions/) mengontrol rendering SVG. Untuk bingkai teks, [SVGOptions::set_UseFrameSize](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/svgoptions/set_useframesize/) menyertakan bingkai teks dalam area rendering, dan [SVGOptions::set_UseFrameRotation](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/svgoptions/set_useframerotation/) menentukan apakah rotasi bingkai diterapkan. Atur [SVGOptions::set_DisableFontLigatures](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/svgoptions/set_disablefontligatures/) ke `true` ketika teks harus dirender tanpa ligatur.

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

## **Kontrol Teks dan Font**

### **Vektorkan Semua Teks**

Atur [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) ke `true` untuk menulis semua teks slide sebagai grafik vektor. Ini menghilangkan ketergantungan pada font dan membuat hasil visual lebih konsisten di semua peramban, tetapi teks tidak lagi dapat dipilih atau dicari sebagai teks SVG.

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

### **Pilih Cara Penanganan Font Eksternal**

[SVGOptions::set_ExternalFontsHandling](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/svgoptions/set_externalfontshandling/) menggunakan nilai [SvgExternalFontsHandling](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/svgexternalfontshandling/) untuk font yang dimuat secara eksternal. Pilih `AddLinksToFontFiles` untuk merujuk file font terpisah, `Embed` untuk menyertakan data font dalam SVG, atau `Vectorize` untuk merender hanya teks yang menggunakan font eksternal sebagai grafik. Verifikasi lisensi font sebelum menyematkan font.

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

## **Kurangi Ukuran Gambar Tersemat**

Gunakan [SVGOptions::set_PicturesCompression](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/svgoptions/set_picturescompression/) untuk mengurangi resolusi gambar tersemat, [SVGOptions::set_DeletePicturesCroppedAreas](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/svgoptions/set_deletepicturescroppedareas/) untuk menghilangkan area sumber yang dipotong, dan [SVGOptions::set_JpegQuality](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/svgoptions/set_jpegquality/) untuk mengontrol kualitas enkoding JPEG. Pengaturan ini mengurangi ukuran berkas dengan mengorbankan kesetiaan gambar atau data gambar yang dipertahankan.

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

## **Tetapkan ID Stabil untuk Bentuk dan Teks**

Gunakan [ISvgShapeFormattingController](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/isvgshapeformattingcontroller/) untuk mengatur [ISvgShape::set_Id](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/isvgshape/set_id/) bagi setiap bentuk SVG. Untuk mengatur nilai [ISvgTSpan::set_Id](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/isvgtspan/set_id/) pada elemen `tspan` teks juga, implementasikan [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/isvgshapeandtextformattingcontroller/). Tetapkan salah satu controller dengan [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/).

Controller berikut menggunakan [IShape::get_OfficeInteropShapeId](https://reference.aspose.com/slides/id/cpp/aspose.slides/ishape/get_officeinteropshapeid/), yang stabil selama masa hidup bentuk, dan penghitung yang dapat diulang untuk span teksnya. Ini membuat ID yang dihasilkan cocok untuk pemrosesan lanjutan pada presentasi yang tidak berubah.

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

## **Tambahkan Penangan Peristiwa SVG**

Dalam sebuah [ISvgShapeFormattingController](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/isvgshapeformattingcontroller/), panggil [ISvgShape::SetEventHandler](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/isvgshape/seteventhandler/) dengan nilai [SvgEvent](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/svgevent/) untuk menambahkan penangan peristiwa JavaScript ke bentuk yang diekspor. Tetapkan controller dengan [SVGOptions::set_ShapeFormattingController](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/svgoptions/set_shapeformattingcontroller/) dan definisikan fungsi JavaScript di halaman atau dokumen SVG yang menampung hasilnya.

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

Halaman host dapat mendefinisikan fungsi JavaScript yang dirujuk oleh penangan. Penetapan ID dan penangan peristiwa memungkinkan penampil slide, peningkatan aksesibilitas, dan alur kerja SVG interaktif lainnya.

## **FAQ**

**Kapan saya harus menggunakan [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) alih-alih [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/svgexternalfontshandling/)?**

Gunakan [SVGOptions::set_VectorizeText](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/svgoptions/set_vectorizetext/) ketika semua teks harus independen dari font. Gunakan [SvgExternalFontsHandling::Vectorize](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/svgexternalfontshandling/) ketika hanya teks yang menggunakan font eksternal yang harus dikonversi menjadi grafik.

**Apa cara terbaik untuk membuat SVG lebih kecil?**

Mulailah dengan mengompresi gambar tersemat, menghapus area gambar yang dipotong, dan memilih file font yang ditautkan ketika lingkungan target dapat menyediakannya. Uji hasilnya karena resolusi gambar yang lebih rendah, kualitas JPEG yang lebih rendah, dan teks yang vektorisasi masing‑masing memiliki kompromi kualitas dan ukuran yang berbeda.

**Apakah saya dapat memodifikasi elemen SVG yang diekspor setelah ekspor?**

Ya. Tetapkan ID melalui controller pemformatan, kemudian pilih elemen SVG yang sesuai dalam alat pemrosesan lanjutan Anda atau skrip peramban.