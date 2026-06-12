---
title: "Konversi PPT dan PPTX ke PDF dalam C++ [Fitur Lanjutan Termasuk]"
linktitle: "PowerPoint ke PDF"
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
## **Ringkasan**

Mengonversi presentasi PowerPoint (PPT, PPTX, ODP, dll.) ke format PDF dalam C++ menawarkan beberapa keuntungan, termasuk kompatibilitas lintas perangkat dan menjaga tata letak serta pemformatan presentasi Anda. Panduan ini menunjukkan cara mengonversi presentasi menjadi dokumen PDF, menggunakan berbagai opsi untuk mengontrol kualitas gambar, menyertakan slide tersembunyi, melindungi file PDF dengan kata sandi, mendeteksi substitusi font, memilih slide tertentu untuk konversi, dan menerapkan standar kepatuhan pada dokumen output.

## **Konversi PowerPoint ke PDF**

Dengan Aspose.Slides, Anda dapat mengonversi presentasi dalam format berikut ke PDF:

* **PPT**
* **PPTX**
* **ODP**

Untuk mengonversi presentasi ke PDF, berikan nama file sebagai argumen ke kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) kemudian simpan presentasi sebagai PDF menggunakan metode `Save`. Kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) menyediakan metode `Save` yang biasanya digunakan untuk mengonversi presentasi ke PDF.

{{%  alert title="NOTE"  color="warning"   %}} 
Aspose.Slides untuk C++ menyisipkan informasi API dan nomor versinya ke dalam dokumen output. Misalnya, saat mengonversi presentasi ke PDF, Aspose.Slides mengisi field Application dengan "*Aspose.Slides*" dan field PDF Producer dengan nilai dalam format "*Aspose.Slides v XX.XX*". **Catatan** bahwa Anda tidak dapat menginstruksikan Aspose.Slides untuk mengubah atau menghapus informasi ini dari dokumen output.
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

Proses konversi standar dari PowerPoint ke PDF menggunakan opsi default. Dalam hal ini, Aspose.Slides mencoba mengonversi presentasi yang diberikan ke PDF dengan pengaturan optimal pada tingkat kualitas maksimum.

Kode C++ berikut menunjukkan cara mengonversi sebuah presentasi (PPT, PPTX, ODP, dll.) ke PDF:

```c++
// Membuat instance kelas Presentation yang mewakili file PowerPoint atau OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");

// Simpan presentasi sebagai PDF.
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);

presentation->Dispose();
```

{{%  alert  color="primary"  %}} 
Aspose menyediakan [**konverter PowerPoint ke PDF**](https://products.aspose.app/slides/id/conversion/ppt-to-pdf) gratis secara online yang memperlihatkan proses konversi presentasi ke PDF. Anda dapat melakukan tes dengan konverter ini untuk implementasi langsung prosedur yang dijelaskan di sini.
{{% /alert %}}

## **Konversi PowerPoint ke PDF dengan Opsi**

Aspose.Slides menyediakan opsi khusus—properti pada kelas [PdfOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/pdfoptions/)—yang memungkinkan Anda menyesuaikan PDF yang dihasilkan, mengunci PDF dengan kata sandi, atau menentukan bagaimana proses konversi harus dijalankan.

### **Konversi PowerPoint ke PDF dengan Opsi Khusus**

Dengan menggunakan opsi konversi khusus, Anda dapat menentukan pengaturan kualitas yang Anda inginkan untuk gambar raster, menentukan bagaimana metafile harus diproses, mengatur tingkat kompresi untuk teks, mengkonfigurasi DPI untuk gambar, dan lain-lain.

Contoh kode di bawah ini menunjukkan cara mengonversi presentasi PowerPoint ke PDF dengan beberapa opsi khusus.

```c++
// Membuat instance kelas PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// Atur kualitas untuk gambar JPG.
pdfOptions->set_JpegQuality(90);

// Atur DPI untuk gambar.
pdfOptions->set_SufficientResolution(300);

// Atur perilaku untuk metafile.
pdfOptions->set_SaveMetafilesAsPng(true);

// Atur tingkat kompresi teks untuk konten teks.
pdfOptions->set_TextCompression(PdfTextCompression::Flate);

// Definisikan mode kepatuhan PDF.
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

// Membuat instance kelas Presentation yang mewakili file PowerPoint atau OpenDocument file.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Simpan presentasi sebagai dokumen PDF.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Konversi PowerPoint ke PDF dengan Slide Tersembunyi**

Jika sebuah presentasi berisi slide tersembunyi, Anda dapat menggunakan metode [set_ShowHiddenSlides](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) dari kelas [PdfOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/pdfoptions/) untuk menyertakan slide tersembunyi sebagai halaman dalam PDF yang dihasilkan.

Kode C++ berikut menunjukkan cara mengonversi presentasi PowerPoint ke PDF dengan menyertakan slide tersembunyi:

```c++
// Membuat instance kelas Presentation yang mewakili file PowerPoint atau OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Membuat instance kelas PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// Tambahkan slide tersembunyi.
pdfOptions->set_ShowHiddenSlides(true);

// Simpan presentasi sebagai PDF.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Konversi PowerPoint ke PDF dengan Perlindungan Kata Sandi**

Kode C++ berikut mendemonstrasikan cara mengonversi presentasi PowerPoint menjadi PDF yang dilindungi kata sandi menggunakan parameter perlindungan dari kelas [PdfOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/pdfoptions/):

```c++
// Membuat instance kelas Presentation yang mewakili file PowerPoint atau OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Membuat instance kelas PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// Atur kata sandi PDF dan izin akses.
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

// Simpan presentasi sebagai PDF.
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Deteksi Substitusi Font**

Aspose.Slides menyediakan metode [set_WarningCallback](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/saveoptions/set_warningcallback/) pada kelas [PdfOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/pdfoptions/) yang memungkinkan Anda mendeteksi substitusi font selama proses konversi presentasi ke PDF.

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
    // Membuat instance kelas Presentation yang mewakili file PowerPoint atau OpenDocument file.
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

Kode C++ berikut mendemonstrasikan cara mengonversi hanya slide tertentu dari sebuah presentasi PowerPoint ke PDF:

```C++
// Membuat instance kelas Presentation yang mewakili file PowerPoint atau OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Setel array nomor slide.
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

## **Konversi PowerPoint ke PDF dalam Tampilan Catatan Slide**

Kode C++ berikut mendemonstrasikan cara mengonversi presentasi PowerPoint ke PDF yang menyertakan catatan:

```C++
// Membuat instance kelas Presentation yang mewakili file PowerPoint atau OpenDocument file.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Konfigurasikan opsi PDF dengan tata letak Catatan.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Simpan presentasi ke PDF dengan catatan.
presentation->Save(u"PDF_with_notes.tiff", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

## **Standar Aksesibilitas dan Kepatuhan untuk PDF**

Aspose.Slides memungkinkan Anda menggunakan prosedur konversi yang mematuhi [Pedoman Aksesibilitas Konten Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Anda dapat mengekspor dokumen PowerPoint ke PDF menggunakan salah satu standar kepatuhan berikut: **PDF/A1a**, **PDF/A1b**, dan **PDF/UA**.

Kode C++ berikut mendemonstrasikan proses konversi PowerPoint ke PDF yang menghasilkan beberapa PDF berdasarkan standar kepatuhan yang berbeda:

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
Aspose.Slides mendukung operasi konversi PDF, memungkinkan Anda mengonversi file PDF ke format file populer. Anda dapat melakukan konversi [PDF ke HTML](https://products.aspose.com/slides/id/cpp/conversion/pdf-to-html/), [PDF ke gambar](https://products.aspose.com/slides/id/cpp/conversion/pdf-to-image/), [PDF ke JPG](https://products.aspose.com/slides/id/cpp/conversion/pdf-to-jpg/), dan [PDF ke PNG](https://products.aspose.com/slides/id/cpp/conversion/pdf-to-png/). Operasi konversi PDF ke format khusus lainnya—[PDF ke SVG](https://products.aspose.com/slides/id/cpp/conversion/pdf-to-svg/), [PDF ke TIFF](https://products.aspose.com/slides/id/cpp/conversion/pdf-to-tiff/), dan [PDF ke XML](https://products.aspose.com/slides/id/cpp/conversion/pdf-to-xml/)—juga didukung.
{{% /alert %}}

> **Catatan:** Saat mengekspor ke PDF/UA, Aspose.Slides memperlakukan grafik kompleks seperti SmartArt, diagram, dan formula sebagai satu gambar. Elemen jalur individual tidak dipertahankan sebagai konten terpisah dan dapat ditandai sebagai artefak; teks alternatif hanya disediakan untuk keseluruhan gambar.

## **FAQ**

**Apakah saya dapat mengonversi banyak file PowerPoint ke PDF sekaligus?**  
Ya, Aspose.Slides mendukung konversi batch beberapa file PPT atau PPTX ke PDF. Anda dapat mengiterasi file Anda dan menerapkan proses konversi secara programatis.

**Apakah memungkinkan untuk melindungi PDF yang dikonversi dengan kata sandi?**  
Tentu saja. Gunakan kelas [PdfOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/pdfoptions/) untuk menetapkan kata sandi dan mendefinisikan izin akses selama proses konversi.

**Bagaimana cara menyertakan slide tersembunyi dalam PDF?**  
Gunakan metode `set_ShowHiddenSlides` pada kelas [PdfOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/pdfoptions/) untuk menyertakan slide tersembunyi dalam PDF yang dihasilkan.

**Apakah Aspose.Slides dapat mempertahankan kualitas gambar tinggi dalam PDF?**  
Ya, Anda dapat mengontrol kualitas gambar dengan menggunakan metode seperti `set_JpegQuality` dan `set_SufficientResolution` pada kelas [PdfOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/pdfoptions/) untuk memastikan gambar berkualitas tinggi dalam PDF Anda.

**Apakah Aspose.Slides mendukung standar kepatuhan PDF/A?**  
Ya, Aspose.Slides memungkinkan Anda mengekspor PDF yang mematuhi berbagai standar, termasuk PDF/A1a, PDF/A1b, dan PDF/UA, sehingga dokumen Anda memenuhi persyaratan aksesibilitas dan arsip.

## **Sumber Daya Tambahan**

- [Aspose.Slides for C++ Documentation](/slides/id/cpp/)
- [Aspose.Slides for C++ API Reference](https://reference.aspose.com/slides/id/cpp/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/id/conversion)