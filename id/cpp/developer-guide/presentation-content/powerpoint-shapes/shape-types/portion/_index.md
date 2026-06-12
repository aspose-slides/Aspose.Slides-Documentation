---
title: Kelola Bagian Teks dalam Presentasi Menggunakan C++
linktitle: Bagian Teks
type: docs
weight: 70
url: /id/cpp/portion/
keywords:
- bagian teks
- potongan teks
- koordinat teks
- posisi teks
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Pelajari cara mengelola bagian teks dalam presentasi PowerPoint menggunakan Aspose.Slides untuk C++, meningkatkan kinerja dan kustomisasi."
---
## **Pendahuluan**

Bagian teks mewakili fragmen teks tertentu di dalam sebuah paragraf dan memungkinkan Anda bekerja dengan fragmen tersebut secara independen dari konten sekitarnya. Di Aspose.Slides, bagian dapat digunakan ketika Anda perlu mengambil posisi fragmen teks, menerapkan pemformatan hanya pada sebagian paragraf, atau mengendalikan perilaku teks pada tingkat yang lebih detail.

## **Dapatkan Koordinat Bagian Teks**
Metode **GetCoordinates()** telah ditambahkan ke antarmuka IPortion dan kelas Portion yang memungkinkan mengambil koordinat awal bagian:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto textFrame = shape->get_TextFrame();

for (const auto& paragraph : textFrame->get_Paragraphs())
{
    for (const auto& portion : paragraph->get_Portions())
    {
        PointF point = portion->GetCoordinates();
        Console::WriteLine(String(u"Coordinates X =") + point.get_X() + u" Coordinates Y =" + point.get_Y());
    }
}
```

## **FAQ**

**Apakah saya dapat menerapkan hyperlink hanya pada sebagian teks dalam satu paragraf?**

Ya, Anda dapat [menetapkan hyperlink](/slides/id/cpp/manage-hyperlinks/) ke bagian individu; hanya fragmen tersebut yang dapat diklik, bukan seluruh paragraf.

**Bagaimana cara kerja pewarisan gaya: apa yang ditimpa oleh Portion, dan apa yang diambil dari Paragraph/TextFrame?**

Properti pada level Portion memiliki prioritas tertinggi. Jika suatu properti tidak diatur pada [Portion](https://reference.aspose.com/slides/id/cpp/aspose.slides/portion/), mesin mengambilnya dari [Paragraph](https://reference.aspose.com/slides/id/cpp/aspose.slides/paragraph/); jika tidak diatur di sana juga, maka dari [TextFrame](https://reference.aspose.com/slides/id/cpp/aspose.slides/textframe/) atau gaya [theme](https://reference.aspose.com/slides/id/cpp/aspose.slides.theme/theme/).

**Apa yang terjadi jika font yang ditentukan untuk sebuah Portion tidak ada di mesin/server target?**

[Aturan substitusi font](/slides/id/cpp/font-selection-sequence/) berlaku. Teks mungkin akan mengalami reflow: metrik, hyphenasi, dan lebar dapat berubah, yang penting untuk penempatan yang tepat.

**Apakah saya dapat mengatur transparansi atau gradien isi teks khusus Portion secara terpisah dari sisa paragraf?**

Ya, warna teks, isi, dan transparansi pada level [Portion](https://reference.aspose.com/slides/id/cpp/aspose.slides/portion/) dapat berbeda dari fragmen tetangga.