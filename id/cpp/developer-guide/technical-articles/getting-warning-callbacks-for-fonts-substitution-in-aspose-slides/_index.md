---
title: Dapatkan Panggilan Balik Peringatan untuk Substitusi Font
type: docs
weight: 70
url: /id/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- panggilan balik peringatan
- substitusi font
- proses rendering
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Pelajari cara mendapatkan panggilan balik peringatan untuk substitusi font di Aspose.Slides untuk C++ dan menampilkan presentasi PowerPoint serta OpenDocument secara akurat."
---
## **Pendahuluan**

Aspose.Slides for C++ memungkinkan Anda menerima panggilan balik peringatan untuk substitusi font ketika font yang diperlukan tidak tersedia di mesin saat proses rendering. Panggilan balik ini membantu mendiagnosis masalah dengan font yang hilang atau tidak dapat diakses.

## **Mengaktifkan Panggilan Balik Peringatan**

Aspose.Slides for C++ menyediakan API yang sederhana untuk menerima panggilan balik peringatan saat merender slide presentasi. Ikuti langkah-langkah berikut untuk mengonfigurasi panggilan balik peringatan:

1. Buat kelas panggilan balik khusus yang mengimplementasikan antarmuka [IWarningCallback](https://reference.aspose.com/slides/id/cpp/aspose.slides.warnings/iwarningcallback/) untuk menangani peringatan.
1. Atur panggilan balik peringatan menggunakan kelas opsi seperti [RenderingOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/renderingoptions/), [PdfOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/htmloptions/), dan lainnya.
1. Muat presentasi yang menggunakan font yang tidak tersedia di mesin target.
1. Hasilkan thumbnail slide atau ekspor presentasi untuk mengamati efeknya.

**Kelas Panggilan Balik Peringatan Kustom:**

```cpp
#include <Warnings/IWarningCallback.h>

class FontWarningHandler : public IWarningCallback
{
public:
    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override;
};

ReturnAction FontWarningHandler::Warning(SharedPtr<IWarningInfo> warning)
{
    if (warning->get_WarningType() == WarningType::DataLoss)
    {
        Console::WriteLine(warning->get_Description());
    }

    return ReturnAction::Continue;
}

// Contoh output:
//
// Font akan digantikan dari XYZ ke {Calibri,Cambria Math,MS Gothic,Gulim,Arial Unicode,SimSun,Segoe UI Symbol}}
```

**Hasilkan Thumbnail Slide:**

```cpp
// Siapkan panggilan balik peringatan untuk menangani peringatan terkait font selama rendering slide.
auto options = MakeObject<RenderingOptions>();
options->set_WarningCallback(MakeObject<FontWarningHandler>());

// Muat presentasi dari jalur file yang ditentukan.
auto presentation = MakeObject<Presentation>(u"sample.pptx");
    
// Hasilkan gambar thumbnail untuk setiap slide dalam presentasi.
for(auto&& slide : presentation->get_Slides())
{
    // Dapatkan gambar thumbnail slide menggunakan opsi rendering yang ditentukan.
    auto image = slide->GetImage(options);
    // ...

    image->Dispose();
}

presentation->Dispose();
```

**Ekspor ke Format PDF:**

```cpp
// Siapkan panggilan balik peringatan untuk menangani peringatan terkait font selama ekspor PDF.
auto options = MakeObject<PdfOptions>();
options->set_WarningCallback(MakeObject<FontWarningHandler>());

// Muat presentasi dari jalur file yang ditentukan.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Ekspor presentasi sebagai PDF.
auto stream = MakeObject<MemoryStream>();
presentation->Save(stream, SaveFormat::Pdf, options);
// ...

stream->Dispose();
presentation->Dispose();
```

**Ekspor ke Format HTML:**

```cpp
// Siapkan panggilan balik peringatan untuk menangani peringatan terkait font selama ekspor HTML.
auto options = MakeObject<HtmlOptions>();
options->set_WarningCallback(MakeObject<FontWarningHandler>());

// Muat presentasi dari jalur file yang ditentukan.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Ekspor presentasi dalam format HTML.
auto stream = MakeObject<MemoryStream>();
presentation->Save(stream, SaveFormat::Html, options);
// ...

stream->Dispose();
presentation->Dispose();
```