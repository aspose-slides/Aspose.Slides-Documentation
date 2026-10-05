---
title: Konversi PPT dan PPTX ke PDF dalam C++ [Fitur Lanjutan Disertakan]
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
- lampiran
- PDF/A1a
- PDF/A1b
- PDF/UA
- C++
- Aspose.Slides
description: "Konversi PowerPoint PPT/PPTX menjadi PDF berkualitas tinggi dan dapat dicari dalam C++ menggunakan Aspose.Slides, dengan contoh kode cepat dan opsi konversi lanjutan."
---
## **Gambaran Umum**

Mengonversi presentasi PowerPoint (PPT, PPTX, ODP, dll.) ke format PDF dalam C++ menawarkan beberapa keuntungan, termasuk kompatibilitas lintas perangkat dan menjaga tata letak serta pemformatan presentasi Anda. Panduan ini menunjukkan cara mengonversi presentasi ke dokumen PDF, menggunakan berbagai opsi untuk mengontrol kualitas gambar, menyertakan slide tersembunyi, melindungi file PDF dengan kata sandi, mendeteksi substitusi font, memilih slide tertentu untuk konversi, dan menerapkan standar kepatuhan pada dokumen output.

## **PowerPoint ke PDF**

Dengan Aspose.Slides, Anda dapat mengonversi presentasi dalam format berikut ke PDF:

* **PPT**
* **PPTX**
* **ODP**

Untuk mengonversi presentasi ke PDF, berikan nama file sebagai argumen ke kelas [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) dan kemudian simpan presentasi sebagai PDF menggunakan metode [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/). Kelas [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) menyediakan metode [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) yang biasanya digunakan untuk mengonversi presentasi ke PDF.

{{% alert color="info" title="Note" %}}

Aspose.Slides untuk C++ menyisipkan informasi API dan nomor versi ke dalam dokumen output. Misalnya, saat mengonversi presentasi ke PDF, Aspose.Slides mengisi bidang Application dengan "*Aspose.Slides*" dan bidang PDF Producer dengan nilai dalam bentuk "*Aspose.Slides v XX.XX*". **Note** bahwa Anda tidak dapat menginstruksikan Aspose.Slides untuk mengubah atau menghapus informasi ini dari dokumen output.

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

## **Konversi PowerPoint ke PDF**

Proses konversi PowerPoint ke PDF standar menggunakan opsi default. Dalam hal ini, Aspose.Slides mencoba mengonversi presentasi yang diberikan ke PDF dengan pengaturan optimal pada tingkat kualitas maksimum.

Contoh berikut memuat presentasi dan menyimpan semua slide yang terlihat ke PDF menggunakan pengaturan ekspor default.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}

Aspose menawarkan konverter online gratis **PowerPoint ke PDF** [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) yang memperlihatkan proses konversi presentasi ke PDF. Anda dapat menjalankan pengujian dengan konverter ini untuk implementasi langsung prosedur yang dijelaskan di sini.

{{% /alert %}}

## **Konversi PowerPoint ke PDF dengan Opsi**

Aspose.Slides menyediakan opsi khusus—properti di bawah kelas [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/)—yang memungkinkan Anda menyesuaikan PDF yang dihasilkan, mengunci PDF dengan kata sandi, atau menentukan bagaimana proses konversi harus dijalankan.

### **Konversi PowerPoint ke PDF dengan Opsi Kustom**

Dengan opsi konversi kustom, Anda dapat menentukan pengaturan kualitas yang diinginkan untuk gambar raster, menentukan cara penanganan metafile, mengatur tingkat kompresi untuk teks, mengonfigurasi DPI untuk gambar, dan lain-lain.

Contoh berikut mengekspor presentasi ke PDF 1.5 dengan kualitas JPEG 90, resolusi gambar 300 DPI, metafile disimpan sebagai PNG, dan kompresi teks Flate.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfCompliance.h>
#include <Export/PdfOptions.h>
#include <Export/PdfTextCompression.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_JpegQuality(90);
pdfOptions->set_SufficientResolution(300);
pdfOptions->set_SaveMetafilesAsPng(true);
pdfOptions->set_TextCompression(PdfTextCompression::Flate);
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **Mempertahankan File OLE Tersemat sebagai Lampiran PDF**

Jika sebuah presentasi berisi buku kerja Excel yang tersemat, Anda mungkin ingin penerima PDF dapat mengakses data buku kerja tersebut serta melihat slide. Panggil [PdfOptions::set_IncludeOleData](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_includeoledata/) dengan `true` untuk mempertahankan file OLE tersemat sebagai lampiran dalam PDF yang dihasilkan.

Nilai default adalah `false`: gambar pratinjau atau ikon objek OLE dirender pada halaman PDF, tetapi file tersemat tidak disertakan sebagai lampiran. Mengatur opsi ke `true` menambahkan data file. Pratinjau tetap sebagai representasi visual; lampiran memungkinkan penerima membuka atau menyimpan file tersemat secara terpisah. Objek OLE tidak menjadi lembar kerja Excel interaktif pada halaman PDF.

Contoh berikut memuat presentasi yang sudah berisi buku kerja Excel tersemat dan mengekspornya ke PDF dengan buku kerja terlampir.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_IncludeOleData(true);

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

Untuk memeriksa hasilnya:

1. Buka PDF yang diekspor di penampil yang mendukung lampiran file, seperti Adobe Acrobat Reader.
2. Buka panel **Attachments** penampil dan temukan buku kerja yang tersemat.
3. Simpan lampiran dan buka di Excel untuk memeriksa datanya, atau buka langsung jika penampil mengizinkannya. Pratinjau pada halaman PDF terpisah dari lampiran.

{{% alert color="info" title="Note" %}}

Standar PDF/A memberlakukan pembatasan pada lampiran: PDF/A-1 melarang file tersemat, PDF/A-2 memperbolehkan hanya lampiran PDF/A, dan PDF/A-3 memperbolehkan tipe file lain, termasuk buku kerja Excel. Ini adalah persyaratan standar, bukan pembatasan khusus Aspose.Slides. Contoh ini menggunakan pengaturan kepatuhan PDF default dan tidak memperlihatkan ekspor PDF/A.

{{% /alert %}}

### **Konversi PowerPoint ke PDF dengan Slide Tersembunyi**

Jika sebuah presentasi berisi slide tersembunyi, Anda dapat menggunakan metode [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) dari kelas [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) untuk menyertakan slide tersembunyi sebagai halaman dalam PDF yang dihasilkan.

Contoh berikut mengekspor presentasi ke PDF, termasuk semua slide tersembunyi.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_ShowHiddenSlides(true);

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **Konversi PowerPoint ke PDF yang Dilindungi Kata Sandi**

Contoh berikut mengekspor presentasi ke PDF yang memerlukan kata sandi `password` untuk dibuka. Izin akses mengizinkan pencetakan, termasuk pencetakan berkualitas tinggi.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfAccessPermissions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **Mendeteksi Substitusi Font**

Aspose.Slides menyediakan metode [set_WarningCallback](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_warningcallback/) di bawah kelas [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/), memungkinkan Anda mendeteksi substitusi font selama proses konversi presentasi ke PDF.

Contoh berikut mengekspor presentasi ke PDF dan mencetak peringatan substitusi font ke konsol. Peringatan dicetak hanya ketika font yang tidak tersedia diganti selama ekspor.

```cpp
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

class FontSubstitutionHandler : public IWarningCallback
{
public:
    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override
    {
        if (warning->get_WarningType() == WarningType::DataLoss && warning->get_Description().StartsWith(u"Font will be substituted"))
        {
            Console::WriteLine(u"Font substitution warning: {0}", warning->get_Description());
        }

        return ReturnAction::Continue;
    }
};

auto pdfOptions = MakeObject<PdfOptions>();
auto warningHandler = MakeObject<FontSubstitutionHandler>();
pdfOptions->set_WarningCallback(warningHandler);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}

Untuk informasi lebih lanjut tentang substitusi font, lihat artikel [Font Substitution](/slides/id/cpp/font-substitution/).

{{% /alert %}} 

## **Konversi Slide Terpilih dari PowerPoint ke PDF**

Contoh berikut mengekspor slide 1 dan 3 dari sebuah presentasi ke PDF. Nomor slide dalam array ini berbasis satu, dan presentasi input harus berisi setidaknya tiga slide.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
auto slides = MakeArray<int32_t>({ 1, 3 });
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);
presentation->Dispose();
```

## **Konversi PowerPoint ke PDF dengan Ukuran Slide Kustom**

Contoh berikut menyalin slide pertama dari sebuah presentasi ke presentasi baru dengan ukuran slide 612 × 792 poin (8,5 × 11 inci). Ia menskalakan konten slide agar sesuai dan mengekspor slide tunggal ke PDF.

```cpp
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

auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");
auto resizedPresentation = MakeObject<Presentation>();

resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// Remove the blank slide that the new presentation was created with.
resizedPresentation->get_Slides()->RemoveAt(1);

resizedPresentation->Save(u"PDF_with_custom_slide_size.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **Konversi PowerPoint ke PDF dalam Tampilan Slide Catatan**

Contoh berikut mengekspor presentasi ke PDF, menempatkan catatan pembicara setiap slide di bawah slide. Gunakan presentasi yang berisi catatan pembicara untuk melihat hasilnya.

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

auto presentation = MakeObject<Presentation>(u"NotesFile.pptx");
presentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

## **Aksesibilitas dan Standar Kepatuhan untuk PDF**

Aspose.Slides memungkinkan Anda menggunakan prosedur konversi yang mematuhi [Pedoman Aksesibilitas Konten Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Anda dapat mengekspor dokumen PowerPoint ke PDF menggunakan salah satu standar kepatuhan berikut: **PDF/A1a**, **PDF/A1b**, dan **PDF/UA**.

Kode C++ ini memperlihatkan proses konversi PowerPoint ke PDF yang menghasilkan beberapa PDF berdasarkan standar kepatuhan yang berbeda:

```cpp
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

{{% alert color="info" title="Note" %}}

Aspose.Slides mendukung operasi konversi PDF, memungkinkan Anda mengonversi file PDF ke format file populer. Anda dapat melakukan konversi [PDF ke HTML](https://products.aspose.com/slides/cpp/conversion/pdf-to-html/), [PDF ke gambar](https://products.aspose.com/slides/cpp/conversion/pdf-to-image/), [PDF ke JPG](https://products.aspose.com/slides/cpp/conversion/pdf-to-jpg/), dan [PDF ke PNG](https://products.aspose.com/slides/cpp/conversion/pdf-to-png/). Operasi konversi PDF ke format khusus lainnya—[PDF ke SVG](https://products.aspose.com/slides/cpp/conversion/pdf-to-svg/), [PDF ke TIFF](https://products.aspose.com/slides/cpp/conversion/pdf-to-tiff/), dan [PDF ke XML](https://products.aspose.com/slides/cpp/conversion/pdf-to-xml/)—juga didukung.

{{% /alert %}}

> **Note:** Saat mengekspor ke PDF/UA, Aspose.Slides memperlakukan grafik kompleks seperti SmartArt, diagram, dan rumus sebagai satu gambar. Elemen jalur individual tidak dipertahankan sebagai konten terpisah dan dapat ditandai sebagai artefak; teks alternatif disediakan hanya untuk seluruh gambar.

## **FAQ**

**Apakah saya dapat mengonversi banyak file PowerPoint ke PDF secara massal?**

Ya, Aspose.Slides mendukung konversi batch banyak file PPT atau PPTX ke PDF. Anda dapat mengiterasi file Anda dan menerapkan proses konversi secara programatik.

**Apakah mungkin melindungi PDF yang sudah dikonversi dengan kata sandi?**

Ya. Gunakan kelas [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) untuk mengatur kata sandi dan menentukan izin akses selama proses konversi.

**Bagaimana cara menyertakan slide tersembunyi dalam PDF?**

Gunakan metode [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) di kelas [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) untuk menyertakan slide tersembunyi dalam PDF yang dihasilkan.

**Apakah Aspose.Slides dapat mempertahankan kualitas gambar tinggi dalam PDF?**

Ya, Anda dapat mengontrol kualitas gambar dengan menggunakan metode seperti [set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_jpegquality/) dan [set_SufficientResolution](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_sufficientresolution/) di kelas [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) untuk memastikan gambar berkualitas tinggi dalam PDF Anda.

**Apakah Aspose.Slides mendukung standar kepatuhan PDF/A?**

Ya, Aspose.Slides memungkinkan Anda mengekspor PDF yang mematuhi berbagai standar, termasuk PDF/A1a, PDF/A1b, dan PDF/UA, memastikan dokumen Anda memenuhi persyaratan aksesibilitas dan arsip.

## **Sumber Daya Tambahan**

- [Aspose.Slides for C++ Documentation](/slides/id/cpp/)
- [Aspose.Slides for C++ API Reference](https://reference.aspose.com/slides/cpp/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)