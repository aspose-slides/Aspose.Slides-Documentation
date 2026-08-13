---
title: Konversi PPT dan PPTX ke PDF dalam C++ [Fitur Lanjutan Termasuk]
linktitle: PowerPoint ke PDF
type: docs
weight: 40
url: /id/cpp/convert-powerpoint-to-pdf/
keywords:
- konversi PowerPoint
- konversi presentasi
- PowerPoint ke PDF
- presentasi ke PDF
- PPT ke PDF
- konversi PPT ke PDF
- PPTX ke PDF
- konversi PPTX ke PDF
- simpan PowerPoint sebagai PDF
- simpan PPT sebagai PDF
- simpan PPTX sebagai PDF
- ekspor PPT ke PDF
- ekspor PPTX ke PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- C++
- Aspose.Slides
description: "Konversi PowerPoint PPT/PPTX ke PDF berkualitas tinggi dan dapat dicari dalam C++ menggunakan Aspose.Slides, dengan contoh kode cepat dan opsi konversi lanjutan."
---
## **Gambaran Umum**

Mengonversi presentasi PowerPoint (PPT, PPTX, ODP, dll.) ke format PDF dalam C++ menawarkan beberapa keuntungan, termasuk kompatibilitas lintas perangkat dan mempertahankan tata letak serta format presentasi Anda. Panduan ini menunjukkan cara mengonversi presentasi ke dokumen PDF, menggunakan berbagai opsi untuk mengontrol kualitas gambar, menyertakan slide tersembunyi, melindungi file PDF dengan kata sandi, mendeteksi substitusi font, memilih slide tertentu untuk konversi, dan menerapkan standar kepatuhan pada dokumen output.

## **Konversi PowerPoint ke PDF**

Dengan Aspose.Slides, Anda dapat mengonversi presentasi dalam format berikut ke PDF:

* **PPT**
* **PPTX**
* **ODP**

Untuk mengonversi presentasi ke PDF, berikan nama file sebagai argumen ke kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) dan kemudian simpan presentasi sebagai PDF menggunakan metode `Save`. Kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) menyediakan metode `Save` yang biasanya digunakan untuk mengonversi presentasi ke PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides untuk C++ memasukkan informasi API dan nomor versinya ke dalam dokumen output. Misalnya, saat mengonversi presentasi ke PDF, Aspose.Slides mengisi bidang Application dengan "*Aspose.Slides*" dan bidang PDF Producer dengan nilai dalam format "*Aspose.Slides v XX.XX*". **Catatan** bahwa Anda tidak dapat menginstruksikan Aspose.Slides untuk mengubah atau menghapus informasi ini dari dokumen output.

{{% /alert %}}

Aspose.Slides memungkinkan Anda mengonversi:

* Seluruh presentasi ke PDF
* Slide tertentu dari sebuah presentasi ke PDF

Aspose.Slides mengekspor presentasi ke PDF, memastikan PDF yang dihasilkan sangat mirip dengan presentasi aslinya. Elemen dan atribut dirender secara akurat dalam konversi, termasuk:

* Gambar
* Kotak teks dan bentuk
* Pemformatan teks
* Pemformatan paragraf
* Tautan hiperteks
* Header dan footer
* Bullet
* Tabel

## **Mengonversi PowerPoint ke PDF**

Proses konversi standar PowerPoint‑to‑PDF menggunakan opsi default. Dalam hal ini, Aspose.Slides berusaha mengonversi presentasi yang diberikan ke PDF dengan pengaturan optimal pada tingkat kualitas maksimum.

Kode C++ berikut menunjukkan cara mengonversi presentasi (PPT, PPTX, ODP, dll.) ke PDF:

```c++
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instantiate the Presentation class that represents a PowerPoint or OpenDocument file.
auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");

// Save the presentation as a PDF.
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);

presentation->Dispose();
```

{{%  alert  color="info"  %}} 

Aspose menyediakan konverter online gratis [**konverter PowerPoint ke PDF**](https://products.aspose.app/slides/id/conversion/ppt-to-pdf) yang memperagakan proses konversi presentasi ke PDF. Anda dapat menguji konverter ini untuk melihat implementasi langsung dari prosedur yang dijelaskan di sini.

{{% /alert %}}

## **Mengonversi PowerPoint ke PDF dengan Opsi**

Aspose.Slides menyediakan opsi kustom—properti di bawah kelas [PdfOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/pdfoptions/)—yang memungkinkan Anda menyesuaikan PDF yang dihasilkan, mengunci PDF dengan kata sandi, atau menentukan cara proses konversi berlangsung.

### **Mengonversi PowerPoint ke PDF dengan Opsi Kustom**

Dengan opsi konversi kustom, Anda dapat menentukan pengaturan kualitas gambar raster yang diinginkan, menentukan cara penanganan metafile, mengatur tingkat kompresi untuk teks, mengonfigurasi DPI untuk gambar, dan lainnya.

Contoh kode di bawah ini memperagakan cara mengonversi presentasi PowerPoint ke PDF dengan beberapa opsi kustom.

```c++
#include <DOM/Presentation.h>
#include <Export/PdfCompliance.h>
#include <Export/PdfOptions.h>
#include <Export/PdfTextCompression.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Membuat instance kelas PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// Atur kualitas untuk gambar JPG.
pdfOptions->set_JpegQuality(90);

// Atur DPI untuk gambar.
pdfOptions->set_SufficientResolution(300);

// Atur perilaku untuk metafile.
pdfOptions->set_SaveMetafilesAsPng(true);

// Atur tingkat kompresi teks untuk konten tekstual.
pdfOptions->set_TextCompression(PdfTextCompression::Flate);

// Tentukan mode kepatuhan PDF.
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

// Membuat instance kelas Presentation yang mewakili file PowerPoint atau OpenDocument file.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Simpan presentasi sebagai dokumen PDF.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Mengonversi PowerPoint ke PDF dengan Slide Tersembunyi**

Jika sebuah presentasi berisi slide tersembunyi, Anda dapat menggunakan metode [set_ShowHiddenSlides](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) dari kelas [PdfOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/pdfoptions/) untuk menyertakan slide tersembunyi sebagai halaman dalam PDF yang dihasilkan.

Kode C++ berikut menunjukkan cara mengonversi presentasi PowerPoint ke PDF dengan menyertakan slide tersembunyi:

```c++
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Buat instance kelas Presentation yang mewakili file PowerPoint atau OpenDocument file.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Buat instance kelas PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// Tambahkan slide tersembunyi.
pdfOptions->set_ShowHiddenSlides(true);

// Simpan presentasi sebagai PDF.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Mengonversi PowerPoint ke PDF yang Dilindungi Kata Sandi**

Kode C++ berikut memperagakan cara mengonversi presentasi PowerPoint menjadi PDF yang dilindungi kata sandi menggunakan parameter perlindungan dari kelas [PdfOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/pdfoptions/):

```c++
#include <DOM/Presentation.h>
#include <Export/PdfAccessPermissions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Buat instance kelas Presentation yang mewakili file PowerPoint atau OpenDocument file.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Buat instance kelas PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// Atur kata sandi PDF dan izin akses.
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

// Simpan presentasi sebagai PDF.
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Mendeteksi Substitusi Font**

Aspose.Slides menyediakan metode [set_WarningCallback](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/saveoptions/set_warningcallback/) di bawah kelas [PdfOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/pdfoptions/), memungkinkan Anda mendeteksi substitusi font selama proses konversi presentasi ke PDF.

Kode C++ berikut memperlihatkan cara mendeteksi substitusi font:

```c++
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <Warnings/IWarningCallback.h>
#include <Warnings/IWarningInfo.h>
#include <Warnings/ReturnAction.h>
#include <Warnings/WarningType.h>
#include <system/console.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Warnings;
using namespace System;

// Implementasi callback peringatan.
class FontSubstitutionHandler : public IWarningCallback
{
public:
    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override;
};

ReturnAction FontSubstitutionHandler::Warning(SharedPtr<IWarningInfo> warning)
{
    if (warning->get_WarningType() == WarningType::DataLoss &&
        warning->get_Description().StartsWith(u"Font will be substituted"))
    {
        Console::WriteLine(u"Font substitution warning: {0}", warning->get_Description());
    }

    return ReturnAction::Continue;
}

int main()
{
    // Buat instance kelas Presentation yang mewakili file PowerPoint atau OpenDocument file.
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // Atur callback peringatan pada opsi PDF.
    auto pdfOptions = MakeObject<PdfOptions>();
    pdfOptions->set_WarningCallback(MakeObject<FontSubstitutionHandler>());

    // Simpan presentasi sebagai PDF.
    presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);

    presentation->Dispose();

    return 0;
}
```

{{%  alert color="info"  %}} 

Untuk informasi lebih lanjut tentang menerima callback untuk substitusi font selama proses rendering, lihat [Mendapatkan Callback Peringatan untuk Substitusi Font](/slides/id/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Untuk informasi lebih lanjut tentang substitusi font, lihat artikel [Substitusi Font](/slides/id/cpp/font-substitution/).

{{% /alert %}} 

## **Mengonversi Slide Terpilih dari PowerPoint ke PDF**

Kode C++ berikut memperagakan cara mengonversi hanya slide tertentu dari sebuah presentasi PowerPoint ke PDF:

```C++
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Buat instance kelas Presentation yang mewakili file PowerPoint atau OpenDocument file.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Atur array nomor slide.
auto slides = MakeArray<int32_t>({ 1, 3 });

// Simpan presentasi sebagai PDF.
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);

presentation->Dispose();
```

## **Mengonversi PowerPoint ke PDF dengan Ukuran Slide Kustom**

Kode C++ berikut memperagakan cara mengonversi presentasi PowerPoint ke PDF dengan ukuran slide yang ditentukan:

```C++
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto slideWidth = 612;
auto slideHeight = 792;

// Buat instance kelas Presentation yang mewakili file PowerPoint atau OpenDocument file.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Buat presentasi baru dengan ukuran slide yang disesuaikan.
auto resizedPresentation = MakeObject<Presentation>();

// Atur ukuran slide khusus.
resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

// Kloning slide pertama dari presentasi asli.
auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// Simpan presentasi yang diubah ukurannya ke PDF dengan catatan.
resizedPresentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **Mengonversi PowerPoint ke PDF dalam Tampilan Slide Catatan**

Kode C++ berikut memperagakan cara mengonversi presentasi PowerPoint ke PDF yang menyertakan catatan:

```C++
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Buat instance kelas Presentation yang mewakili file PowerPoint atau OpenDocument.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Konfigurasikan opsi PDF dengan tata letak catatan.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Simpan presentasi ke PDF dengan catatan.
presentation->Save(u"PDF_with_notes.tiff", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

## **Aksesibilitas dan Standar Kepatuhan untuk PDF**

Aspose.Slides memungkinkan Anda menggunakan prosedur konversi yang mematuhi [Pedoman Aksesibilitas Konten Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Anda dapat mengekspor dokumen PowerPoint ke PDF menggunakan standar kepatuhan berikut: **PDF/A1a**, **PDF/A1b**, dan **PDF/UA**.

Kode C++ berikut memperagakan proses konversi PowerPoint‑to‑PDF yang menghasilkan beberapa PDF berdasarkan standar kepatuhan yang berbeda:

```C++
#include <DOM/Presentation.h>
#include <Export/PdfCompliance.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"pres.pptx");

auto pdfOptionsA1a = MakeObject<PdfOptions>();

pdfOptionsA1a->set_Compliance(PdfCompliance::PdfA1a);
presentation->Save(u"pres-a1a-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1a);

auto pdfOptionsA1b = MakeObject<PdfOptions>();
pdfOptionsA1b->set_Compliance(PdfCompliance::PdfA1b);
presentation->Save(u"pres-a1b-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1b);

auto pdfOptionsUa = MakeObject<PdfOptions>();
pdfOptionsUa->set_Compliance(PdfCompliance::PdfUa);

presentation->Save(u"pres-ua-compliance.pdf", SaveFormat::Pdf, pdfOptionsUa);

presentation->Dispose();
```

{{% alert title="Note" color="warning" %}} 

Aspose.Slides mendukung operasi konversi PDF, memungkinkan Anda mengonversi file PDF ke format file populer. Anda dapat melakukan konversi [PDF ke HTML](https://products.aspose.com/slides/id/cpp/conversion/pdf-to-html/), [PDF ke gambar](https://products.aspose.com/slides/id/cpp/conversion/pdf-to-image/), [PDF ke JPG](https://products.aspose.com/slides/id/cpp/conversion/pdf-to-jpg/), dan [PDF ke PNG](https://products.aspose.com/slides/id/cpp/conversion/pdf-to-png/). Operasi konversi PDF ke format khusus—[PDF ke SVG](https://products.aspose.com/slides/id/cpp/conversion/pdf-to-svg/), [PDF ke TIFF](https://products.aspose.com/slides/id/cpp/conversion/pdf-to-tiff/), dan [PDF ke XML](https://products.aspose.com/slides/id/cpp/conversion/pdf-to-xml/)—juga didukung.

{{% /alert %}}

> **Catatan:** Saat mengekspor ke PDF/UA, Aspose.Slides memperlakukan grafik kompleks seperti SmartArt, diagram, dan rumus sebagai satu gambar tunggal. Elemen jalur individu tidak dipertahankan sebagai konten terpisah dan mungkin ditandai sebagai artefak; teks alternatif hanya disediakan untuk keseluruhan gambar.

## **FAQ**

### Bisakah saya mengonversi beberapa file PowerPoint ke PDF secara massal?

Ya, Aspose.Slides mendukung konversi batch banyak file PPT atau PPTX ke PDF. Anda dapat mengiterasi file‑file Anda dan menerapkan proses konversi secara programatis.

### Apakah memungkinkan melindungi PDF yang telah dikonversi dengan kata sandi?

Tentu saja. Gunakan kelas [PdfOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/pdfoptions/) untuk menetapkan kata sandi dan menentukan izin akses selama proses konversi.

### Bagaimana cara menyertakan slide tersembunyi dalam PDF?

Gunakan metode `set_ShowHiddenSlides` pada kelas [PdfOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/pdfoptions/) untuk menyertakan slide tersembunyi dalam PDF yang dihasilkan.

### Apakah Aspose.Slides dapat mempertahankan kualitas gambar tinggi dalam PDF?

Ya, Anda dapat mengontrol kualitas gambar dengan menggunakan metode seperti `set_JpegQuality` dan `set_SufficientResolution` pada kelas [PdfOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/pdfoptions/) untuk memastikan gambar berkualitas tinggi dalam PDF Anda.

### Apakah Aspose.Slides mendukung standar kepatuhan PDF/A?

Ya, Aspose.Slides memungkinkan Anda mengekspor PDF yang mematuhi berbagai standar, termasuk PDF/A1a, PDF/A1b, dan PDF/UA, memastikan dokumen Anda memenuhi persyaratan aksesibilitas dan arsip.

## **Sumber Daya Tambahan**

- [Dokumentasi Aspose.Slides untuk C++](/slides/id/cpp/)
- [Referensi API Aspose.Slides untuk C++](https://reference.aspose.com/slides/id/cpp/)
- [Konverter Online Gratis Aspose](https://products.aspose.app/slides/id/conversion)