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
- PDF/A1a
- PDF/A1b
- PDF/UA
- C++
- Aspose.Slides
description: "Konversi PowerPoint PPT/PPTX ke PDF berkualitas tinggi dan dapat dicari dalam C++ menggunakan Aspose.Slides, dengan contoh kode cepat dan opsi konversi lanjutan."
---
## **Ikhtisar**

Mengonversi presentasi PowerPoint (PPT, PPTX, ODP, dll.) ke format PDF dalam C++ menawarkan beberapa keuntungan, termasuk kompatibilitas di berbagai perangkat dan mempertahankan tata letak serta format presentasi Anda. Panduan ini menunjukkan cara mengonversi presentasi ke dokumen PDF, menggunakan berbagai opsi untuk mengontrol kualitas gambar, menyertakan slide tersembunyi, melindungi file PDF dengan kata sandi, mendeteksi substitusi font, memilih slide tertentu untuk konversi, dan menerapkan standar kepatuhan pada dokumen keluaran.

## **Konversi PowerPoint ke PDF**

Menggunakan Aspose.Slides, Anda dapat mengonversi presentasi dalam format berikut ke PDF:

* **PPT**
* **PPTX**
* **ODP**

Untuk mengonversi presentasi ke PDF, berikan nama file sebagai argumen ke kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) dan kemudian simpan presentasi sebagai PDF menggunakan metode `Save`. Kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) menyediakan metode `Save` yang biasanya digunakan untuk mengonversi presentasi ke PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides untuk C++ menyisipkan informasi API dan nomor versi ke dalam dokumen keluaran. Misalnya, saat mengonversi presentasi ke PDF, Aspose.Slides mengisi bidang Application dengan "*Aspose.Slides*" dan bidang PDF Producer dengan nilai dalam format "*Aspose.Slides v XX.XX*". **Catatan** bahwa Anda tidak dapat menginstruksikan Aspose.Slides untuk mengubah atau menghapus informasi ini dari dokumen keluaran.

{{% /alert %}}

Aspose.Slides memungkinkan Anda untuk mengonversi:

* Seluruh presentasi ke PDF
* Slide tertentu dari sebuah presentasi ke PDF

Aspose.Slides mengekspor presentasi ke PDF, memastikan PDF yang dihasilkan sangat mirip dengan presentasi asli. Elemen dan atribut dirender secara akurat dalam konversi, termasuk:

* Gambar
* Kotak teks dan bentuk
* Pemformatan teks
* Pemformatan paragraf
* Tautan hiperteks
* Header dan footer
* Bullet
* Tabel

## **Konversi PowerPoint ke PDF**

Proses konversi standar PowerPoint-ke-PDF menggunakan opsi default. Dalam hal ini, Aspose.Slides berusaha mengonversi presentasi yang diberikan ke PDF dengan pengaturan optimal pada tingkat kualitas maksimum.

Kode C++ berikut menunjukkan cara mengonversi sebuah presentasi (PPT, PPTX, ODP, dll.) ke PDF:

```c++
// Instansiasi kelas Presentation yang mewakili file PowerPoint atau OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");

// Simpan presentasi sebagai PDF.
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);

presentation->Dispose();
```

{{%  alert  color="primary"  %}} 

Aspose menyediakan [**konverter PowerPoint ke PDF**](https://products.aspose.app/slides/id/conversion/ppt-to-pdf) online gratis yang mendemonstrasikan proses konversi presentasi ke PDF. Anda dapat menjalankan tes dengan konverter ini untuk implementasi langsung dari prosedur yang dijelaskan di sini.

{{% /alert %}}

## **Konversi PowerPoint ke PDF dengan Opsi**

Aspose.Slides menyediakan opsi khusus—properti di bawah kelas [PdfOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/pdfoptions/)—yang memungkinkan Anda menyesuaikan PDF yang dihasilkan, mengunci PDF dengan kata sandi, atau menentukan cara proses konversi berjalan.

### **Konversi PowerPoint ke PDF dengan Opsi Kustom**

Dengan menggunakan opsi konversi kustom, Anda dapat menentukan pengaturan kualitas yang diinginkan untuk gambar raster, menentukan cara penanganan metafile, menetapkan tingkat kompresi untuk teks, mengonfigurasi DPI untuk gambar, dan lain-lain.

Contoh kode di bawah ini menunjukkan cara mengonversi presentasi PowerPoint ke PDF dengan beberapa opsi kustom.

```c++
// Instansiasi kelas PdfOptions.
// Atur kualitas gambar JPG.
// Atur DPI untuk gambar.
// Atur perilaku untuk metafile.
// Atur level kompresi teks untuk konten teks.
// Tentukan mode kepatuhan PDF.
// Instansiasi kelas Presentation yang mewakili file PowerPoint atau OpenDocument.
auto pdfOptions = MakeObject<PdfOptions>();

pdfOptions->set_JpegQuality(90);

// Set DPI for images.
pdfOptions->set_SufficientResolution(300);

// Set the behavior for metafiles.
pdfOptions->set_SaveMetafilesAsPng(true);

// Set the text compression level for textual content.
pdfOptions->set_TextCompression(PdfTextCompression::Flate);

// Define the PDF compliance mode.
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

// Instantiate the Presentation class that represents a PowerPoint or OpenDocument file.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Save the presentation as a PDF document.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Konversi PowerPoint ke PDF dengan Slide Tersembunyi**

Jika sebuah presentasi berisi slide tersembunyi, Anda dapat menggunakan metode [set_ShowHiddenSlides](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) dari kelas [PdfOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/pdfoptions/) untuk menyertakan slide tersembunyi sebagai halaman dalam PDF yang dihasilkan.

Kode C++ berikut menunjukkan cara mengonversi presentasi PowerPoint ke PDF dengan menyertakan slide tersembunyi:

```c++
// Instansiasi kelas Presentation yang mewakili file PowerPoint atau OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Instansiasi kelas PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// Tambahkan slide tersembunyi.
pdfOptions->set_ShowHiddenSlides(true);

// Simpan presentasi sebagai PDF.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Konversi PowerPoint ke PDF yang Dilindungi Kata Sandi**

Kode C++ berikut mendemonstrasikan cara mengonversi presentasi PowerPoint menjadi PDF yang dilindungi kata sandi menggunakan parameter perlindungan dari kelas [PdfOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/pdfoptions/):

```c++
// Instansiasi kelas Presentation yang mewakili file PowerPoint atau OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Instansiasi kelas PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// Atur kata sandi PDF dan izin akses.
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

// Simpan presentasi sebagai PDF.
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Deteksi Substitusi Font**

Aspose.Slides menyediakan metode [set_WarningCallback](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/saveoptions/set_warningcallback/) pada kelas [PdfOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/pdfoptions/), memungkinkan Anda mendeteksi substitusi font selama proses konversi presentasi ke PDF.

Kode C++ berikut menunjukkan cara mendeteksi substitusi font:

```c++
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
    // Instansiasi kelas Presentation yang mewakili file PowerPoint atau OpenDocument.
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

{{%  alert color="primary"  %}} 

Untuk informasi lebih lanjut tentang menerima callback untuk substitusi font selama proses rendering, lihat [Mendapatkan Callback Peringatan untuk Substitusi Font](/slides/id/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Untuk informasi lebih lanjut tentang substitusi font, lihat artikel [Substitusi Font](/slides/id/cpp/font-substitution/).

{{% /alert %}} 

## **Konversi Slide Terpilih dari PowerPoint ke PDF**

Kode C++ berikut mendemonstrasikan cara mengonversi hanya slide tertentu dari presentasi PowerPoint ke PDF:

```C++
// Instansiasi kelas Presentation yang mewakili file PowerPoint atau OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Atur array nomor slide.
auto slides = MakeArray<int32_t>({ 1, 3 });

// Simpan presentasi sebagai PDF.
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);

presentation->Dispose();
```

## **Konversi PowerPoint ke PDF dengan Ukuran Slide Kustom**

Kode C++ berikut mendemonstrasikan cara mengonversi presentasi PowerPoint ke PDF dengan ukuran slide yang ditentukan:

```C++
auto slideWidth = 612;
auto slideHeight = 792;

// Instantiate the Presentation class that represents a PowerPoint or OpenDocument file.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Create a new presentation with an adjusted slide size.
auto resizedPresentation = MakeObject<Presentation>();

// Set the custom slide size.
resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

// Clone the first slide from the original presentation.
auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// Save the resized presentation to a PDF with notes.
resizedPresentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **Konversi PowerPoint ke PDF dalam Tampilan Slide Catatan**

Kode C++ berikut mendemonstrasikan cara mengonversi presentasi PowerPoint ke PDF yang menyertakan catatan:

```C++
// Instansiasi kelas Presentation yang mewakili file PowerPoint atau OpenDocument.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Konfigurasikan opsi PDF dengan Tata Letak Catatan.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Simpan presentasi ke PDF dengan catatan.
presentation->Save(u"PDF_with_notes.tiff", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

## **Aksesibilitas dan Standar Kepatuhan untuk PDF**

Aspose.Slides memungkinkan Anda menggunakan prosedur konversi yang mematuhi [Pedoman Aksesibilitas Konten Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Anda dapat mengekspor dokumen PowerPoint ke PDF menggunakan salah satu standar kepatuhan berikut: **PDF/A1a**, **PDF/A1b**, dan **PDF/UA**.

Kode C++ berikut mendemonstrasikan proses konversi PowerPoint-ke-PDF yang menghasilkan beberapa PDF berdasarkan standar kepatuhan yang berbeda:

```C++
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

Aspose.Slides mendukung operasi konversi PDF, memungkinkan Anda mengonversi file PDF ke format file populer. Anda dapat melakukan konversi [PDF ke HTML](https://products.aspose.com/slides/id/cpp/conversion/pdf-to-html/), [PDF ke gambar](https://products.aspose.com/slides/id/cpp/conversion/pdf-to-image/), [PDF ke JPG](https://products.aspose.com/slides/id/cpp/conversion/pdf-to-jpg/), dan [PDF ke PNG](https://products.aspose.com/slides/id/cpp/conversion/pdf-to-png/). Operasi konversi PDF lainnya ke format khusus—[PDF ke SVG](https://products.aspose.com/slides/id/cpp/conversion/pdf-to-svg/), [PDF ke TIFF](https://products.aspose.com/slides/id/cpp/conversion/pdf-to-tiff/), dan [PDF ke XML](https://products.aspose.com/slides/id/cpp/conversion/pdf-to-xml/)—juga didukung.

{{% /alert %}}

> **Catatan:** Saat mengekspor ke PDF/UA, Aspose.Slides memperlakukan grafik kompleks seperti SmartArt, diagram, dan rumus sebagai satu gambar tunggal. Elemen jalur individual tidak dipertahankan sebagai konten terpisah dan mungkin ditandai sebagai artefak; teks alternatif hanya disediakan untuk seluruh gambar.

## **FAQ**

**Apakah saya dapat mengonversi banyak file PowerPoint ke PDF secara massal?**

Ya, Aspose.Slides mendukung konversi batch banyak file PPT atau PPTX ke PDF. Anda dapat mengulang file Anda dan menerapkan proses konversi secara programatis.

**Apakah memungkinkan untuk melindungi PDF yang dikonversi dengan kata sandi?**

Tentu saja. Gunakan kelas [PdfOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/pdfoptions/) untuk mengatur kata sandi dan menentukan izin akses selama proses konversi.

**Bagaimana cara menyertakan slide tersembunyi dalam PDF?**

Gunakan metode `set_ShowHiddenSlides` pada kelas [PdfOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/pdfoptions/) untuk menyertakan slide tersembunyi dalam PDF yang dihasilkan.

**Apakah Aspose.Slides dapat mempertahankan kualitas gambar tinggi dalam PDF?**

Ya, Anda dapat mengontrol kualitas gambar dengan menggunakan metode seperti `set_JpegQuality` dan `set_SufficientResolution` pada kelas [PdfOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/pdfoptions/) untuk memastikan gambar berkualitas tinggi dalam PDF Anda.

**Apakah Aspose.Slides mendukung standar kepatuhan PDF/A?**

Ya, Aspose.Slides memungkinkan Anda mengekspor PDF yang mematuhi berbagai standar, termasuk PDF/A1a, PDF/A1b, dan PDF/UA, memastikan dokumen Anda memenuhi persyaratan aksesibilitas dan pengarsipan.

## **Sumber Daya Tambahan**

- [Dokumentasi Aspose.Slides untuk C++](/slides/id/cpp/)
- [Referensi API Aspose.Slides untuk C++](https://reference.aspose.com/slides/id/cpp/)
- [Konverter Online Gratis Aspose](https://products.aspose.app/slides/id/conversion)