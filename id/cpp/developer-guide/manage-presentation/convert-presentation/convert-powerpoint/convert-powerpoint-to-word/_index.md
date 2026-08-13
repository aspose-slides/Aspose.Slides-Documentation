---
title: Konversi Presentasi PowerPoint ke Dokumen Word dengan C++
linktitle: PowerPoint ke Word
type: docs
weight: 110
url: /id/cpp/convert-powerpoint-to-word/
keywords:
- konversi PowerPoint
- konversi presentasi
- konversi slide
- konversi PPT
- konversi PPTX
- PowerPoint ke Word
- presentasi ke Word
- slide ke Word
- PPT ke Word
- PPTX ke Word
- PowerPoint ke DOCX
- presentasi ke DOCX
- slide ke DOCX
- PPT ke DOCX
- PPTX ke DOCX
- PowerPoint ke DOC
- presentasi ke DOC
- slide ke DOC
- PPT ke DOC
- PPTX ke DOC
- simpan PPT sebagai DOCX
- simpan PPTX sebagai DOCX
- ekspor PPT ke DOCX
- ekspor PPTX ke DOCX
- C++
- Aspose.Slides
description: "Konversi slide PowerPoint PPT dan PPTX ke dokumen Word yang dapat disunting dalam C++ menggunakan Aspose.Slides dengan tata letak, gambar, dan format yang dipertahankan secara tepat."
---
## **Pendahuluan**

Jika Anda berencana menggunakan konten teks atau informasi dari sebuah presentasi (PPT atau PPTX) dengan cara baru, Anda mungkin akan mendapatkan manfaat dari mengonversi presentasi tersebut ke Word (DOC atau DOCX). 

* Dibandingkan dengan Microsoft PowerPoint, aplikasi Microsoft Word lebih dilengkapi dengan alat atau fungsionalitas untuk konten. 
* Selain fungsi penyuntingan di Word, Anda juga dapat memanfaatkan fitur kolaborasi, pencetakan, dan berbagi yang ditingkatkan. 

{{% alert color="info" %}} 

Anda mungkin ingin mencoba [**Presentation to Word Online Converter**](https://products.aspose.app/slides/id/conversion/ppt-to-word) kami untuk melihat apa yang dapat Anda peroleh dari bekerja dengan konten teks dari slide. 

{{% /alert %}} 

## **Aspose.Slides dan Aspose.Words**

Untuk mengonversi file PowerPoint (PPTX atau PPT) ke Word (DOCX atau DOC), Anda memerlukan both [Aspose.Slides for C++](https://products.aspose.com/slides/id/cpp/) dan [Aspose.Words for C++](https://products.aspose.com/words/cpp/).

Sebagai API mandiri, [Aspose.Slides](https://products.aspose.app/slides) for C++ menyediakan fungsi yang memungkinkan Anda mengekstrak teks dari presentasi. 

[Aspose.Words](https://docs.aspose.com/words/cpp/) adalah API pemrosesan dokumen tingkat lanjut yang memungkinkan aplikasi menghasilkan, memodifikasi, mengonversi, merender, mencetak file, dan melakukan tugas lainnya dengan dokumen tanpa memanfaatkan Microsoft Word.

## **Konversi Presentasi PowerPoint ke Dokumen Word**

Gunakan cuplikan kode ini untuk mengonversi PowerPoint ke Word:

```cpp
#include <Aspose.Words.Cpp/BreakType.h>
#include <Aspose.Words.Cpp/Document.h>
#include <Aspose.Words.Cpp/DocumentBuilder.h>
#include <DOM/AutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto doc = MakeObject<Aspose::Words::Document>();
auto builder = MakeObject<Aspose::Words::DocumentBuilder>(doc);

for (const auto& slide : presentation->get_Slides())
{
    // menghasilkan gambar slide sebagai aliran byte array
    auto image = slide->GetImage(1.0f, 1.0f);
    auto imageStream = MakeObject<System::IO::MemoryStream>();
    image->Save(imageStream, Aspose::Slides::ImageFormat::Png);
    image->Dispose();

    builder->InsertImage(imageStream->ToArray());

    // menyisipkan teks slide
    for (const auto& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<AutoShape>(shape))
        {
            auto autoShape = System::AsCast<AutoShape>(shape);
            builder->Writeln(autoShape->get_TextFrame()->get_Text());
        }
    }

    builder->InsertBreak(Aspose::Words::BreakType::PageBreak);
}

doc->Save(u"output.docx");
presentation->Dispose();
```

## **FAQ**

### Komponen apa yang perlu diinstal untuk mengonversi presentasi PowerPoint dan OpenDocument ke dokumen Word?

Anda hanya perlu menambahkan paket yang sesuai untuk [Aspose.Slides for C++](https://releases.aspose.com/slides/id/cpp/) dan [Aspose.Words for C++](https://releases.aspose.com/words/cpp/) ke proyek Anda. Kedua pustaka beroperasi sebagai API mandiri, dan tidak ada keharusan untuk menginstal Microsoft Office.

### Apakah semua format presentasi PowerPoint dan OpenDocument didukung?

Aspose.Slides [supports all presentation formats](/slides/id/cpp/supported-file-formats/), termasuk PPT, PPTX, ODP, dan tipe file umum lainnya. Ini memastikan Anda dapat bekerja dengan presentasi yang dibuat pada berbagai versi Microsoft PowerPoint.