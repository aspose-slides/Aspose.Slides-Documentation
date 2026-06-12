---
title: Kelola Bagian Teks dalam Presentasi di .NET
linktitle: Bagian Teks
type: docs
weight: 70
url: /id/net/portion/
keywords:
- bagian teks
- segmen teks
- koordinat teks
- posisi teks
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Pelajari cara mengelola bagian teks dalam presentasi PowerPoint menggunakan Aspose.Slides untuk .NET, meningkatkan kinerja dan kustomisasi."
---
## **Gambaran Umum**

Bagian teks mewakili fragmen spesifik dari teks di dalam sebuah paragraf dan memungkinkan Anda bekerja dengan fragmen tersebut secara independen dari konten sekitarnya. Di Aspose.Slides, bagian dapat digunakan ketika Anda perlu mengambil posisi fragmen teks, menerapkan pemformatan hanya pada sebagian paragraf, atau mengendalikan perilaku teks pada tingkat yang lebih detail.

Artikel ini menunjukkan cara mendapatkan koordinat awal sebuah bagian dengan menggunakan metode `GetCoordinates()`. Artikel ini juga menyoroti skenario umum terkait bagian, seperti menerapkan hyperlink pada satu fragmen teks, memahami cara pemformatan diselesaikan melalui pewarisan bagian, paragraf, bingkai teks, dan tema, serta menangani kasus di mana font yang ditentukan tidak tersedia. Selain itu, disebutkan bahwa isian teks, warna, dan transparansi dapat diatur secara berbeda untuk masing-masing bagian dalam paragraf yang sama.

## **Dapatkan Koordinat Bagian Teks**
Metode **GetCoordinates()** telah ditambahkan ke kelas IPortion dan Portion yang memungkinkan pengambilan koordinat awal bagian:

```c#
using (Presentation presentation = new Presentation("Shapes.pptx"))
{
    IAutoShape shape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var textFrame = (ITextFrame)shape.TextFrame;

    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (Portion portion in paragraph.Portions)
        {
            PointF point = portion.GetCoordinates();
            Console.Write(Environment.NewLine + "Corrdinates X =" + point.X + " Corrdinates Y =" + point.Y);
        }
    }
}
```

## **FAQ**

**Apakah saya dapat menerapkan hyperlink hanya pada bagian teks dalam satu paragraf?**

Ya, Anda dapat [menetapkan hyperlink](/slides/id/net/manage-hyperlinks/) pada bagian individu; hanya fragmen itu yang dapat diklik, bukan seluruh paragraf.

**Bagaimana pewarisan gaya bekerja: apa yang ditimpa oleh Portion, dan apa yang diambil dari Paragraph/TextFrame?**

Properti pada tingkat Portion memiliki prioritas tertinggi. Jika properti tidak ditetapkan pada [Portion](https://reference.aspose.com/slides/id/net/aspose.slides/portion/), mesin mengambilnya dari [Paragraph](https://reference.aspose.com/slides/id/net/aspose.slides/paragraph/); jika tidak ditetapkan di sana juga, dari [TextFrame](https://reference.aspose.com/slides/id/net/aspose.slides/textframe/) atau gaya [tema](https://reference.aspose.com/slides/id/net/aspose.slides.theme/theme/).

**Apa yang terjadi jika font yang ditentukan untuk sebuah Portion tidak ada di mesin/server target?**

[Aturan substitusi font](/slides/id/net/font-selection-sequence/) diterapkan. Teks dapat berubah alirannya: metrik, hyphenasi, dan lebar dapat berubah, yang berpengaruh pada penempatan yang tepat.

**Apakah saya dapat mengatur transparansi atau gradien isian teks khusus Portion secara terpisah dari sisanya paragraf?**

Ya, warna teks, isian, dan transparansi pada tingkat [Portion](https://reference.aspose.com/slides/id/net/aspose.slides/portion/) dapat berbeda dari fragmen tetangga.