---
title: Mengonversi Presentasi PowerPoint ke Dokumen Word dalam C++
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
description: "Mengonversi slide PowerPoint PPT dan PPTX menjadi dokumen Word yang dapat diedit dalam C++ menggunakan Aspose.Slides dengan tata letak, gambar, dan pemformatan yang presisi terjaga."
---
## **Pendahuluan**

Jika Anda berencana untuk menggunakan konten teks atau informasi dari presentasi (PPT atau PPTX) dengan cara baru, Anda mungkin akan memperoleh manfaat dengan mengonversi presentasi tersebut ke Word (DOC atau DOCX).

* Dibandingkan dengan Microsoft PowerPoint, aplikasi Microsoft Word dilengkapi dengan lebih banyak alat atau fungsionalitas untuk konten.
* Selain fungsi penyuntingan di Word, Anda juga dapat memperoleh manfaat dari fitur kolaborasi, pencetakan, dan berbagi yang ditingkatkan.

{{% alert color="primary" %}} 
Anda mungkin ingin mencoba [**Presentation to Word Online Converter**](https://products.aspose.app/slides/id/conversion/ppt-to-word) kami untuk melihat apa yang dapat Anda peroleh dengan bekerja dengan konten teks dari slide. 
{{% /alert %}} 

## **Aspose.Slides dan Aspose.Words**

Untuk mengonversi file PowerPoint (PPTX atau PPT) ke Word (DOCX atau DOCX), Anda memerlukan kedua [Aspose.Slides for C++](https://products.aspose.com/slides/id/cpp/) dan [Aspose.Words for C++](https://products.aspose.com/words/cpp/).

Sebagai API mandiri, [Aspose.Slides](https://products.aspose.app/slides) untuk C++ menyediakan fungsi yang memungkinkan Anda mengekstrak teks dari presentasi.

[Aspose.Words](https://docs.aspose.com/words/cpp/) adalah API pemrosesan dokumen lanjutan yang memungkinkan aplikasi untuk membuat, memodifikasi, mengonversi, merender, mencetak file, dan melakukan tugas lainnya dengan dokumen tanpa menggunakan Microsoft Word.

## **Konversi Presentasi PowerPoint ke Dokumen Word**

Gunakan potongan kode ini untuk mengonversi PowerPoint ke Word:

```cpp
auto presentation = MakeObject<Presentation>();
auto doc = MakeObject<Aspose::Words::Document>();
auto builder = MakeObject<Aspose::Words::DocumentBuilder>(doc);

for (const auto& slide : presentation->get_Slides())
{
    // menghasilkan dan menyisipkan gambar slide
    auto image = slide->GetImage(1.0f, 1.0f);
    builder->InsertImage(image);

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
```

## **FAQ**

**Komponen apa yang perlu diinstal untuk mengonversi presentasi PowerPoint dan OpenDocument ke dokumen Word?**

Anda hanya perlu menambahkan paket masing-masing untuk [Aspose.Slides for C++](https://releases.aspose.com/slides/id/cpp/) dan [Aspose.Words for C++](https://releases.aspose.com/words/cpp/) ke proyek Anda. Kedua pustaka beroperasi sebagai API mandiri, dan tidak ada keharusan untuk menginstal Microsoft Office.

**Apakah semua format presentasi PowerPoint dan OpenDocument didukung?**

Aspose.Slides [mendukung semua format presentasi](/slides/id/cpp/supported-file-formats/), termasuk PPT, PPTX, ODP, dan jenis file umum lainnya. Hal ini memastikan Anda dapat bekerja dengan presentasi yang dibuat dalam berbagai versi Microsoft PowerPoint.