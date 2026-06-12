---
title: Automasi Lokalisasi Presentasi di .NET
linktitle: Lokalisasi Presentasi
type: docs
weight: 100
url: /id/net/presentation-localization/
keywords:
- ubah bahasa
- pemeriksaan ejaan
- id bahasa
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Automasi lokalisasi slide PowerPoint dan OpenDocument di .NET dengan Aspose.Slides, menggunakan contoh kode C# praktis dan tips untuk peluncuran global yang lebih cepat."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara mengatur `LanguageId` untuk teks dalam presentasi dengan menggunakan Aspose.Slides. Artikel ini menunjukkan cara membuka presentasi, menambahkan bentuk dengan teks, menetapkan pengidentifikasi bahasa ke bagian teks, dan menyimpan hasilnya sebagai file PPTX.

## **Ubah Bahasa untuk Presentasi dan Teks Bentuk**
- Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
- Dapatkan referensi slide dengan menggunakan Indeksnya.
- Tambahkan AutoShape tipe Persegi Panjang ke slide.
- Tambahkan beberapa teks ke TextFrame.
- Atur Language Id untuk teks.
- Simpan presentasi sebagai file PPTX.

Implementasi langkah-langkah di atas ditunjukkan di bawah ini dalam contoh.

```c#
using (Presentation pres = new Presentation("test0.pptx"))
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.AddTextFrame("Text to apply spellcheck language");
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LanguageId = "en-EN";

    pres.Save("test1.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **FAQ**

**Apakah Language ID memicu terjemahan teks otomatis?**

Tidak. [LanguageId](https://reference.aspose.com/slides/id/net/aspose.slides/baseportionformat/languageid/) di Aspose.Slides menyimpan bahasa untuk pemeriksaan ejaan dan pembuktian tata bahasa, tetapi tidak menerjemahkan atau mengubah konten teks. Itu adalah metadata yang dipahami PowerPoint untuk pembuktian.

**Apakah Language ID memengaruhi hyphenation dan pemecahan baris saat rendering?**

Di Aspose.Slides, [LanguageId](https://reference.aspose.com/slides/id/net/aspose.slides/baseportionformat/languageid/) digunakan untuk pembuktian. Kualitas hyphenation dan pembungkusan baris terutama bergantung pada ketersediaan [font yang tepat](/slides/id/net/powerpoint-fonts/) serta pengaturan tata letak/pemecahan baris untuk sistem penulisan. Untuk memastikan rendering yang benar, sediakan font yang diperlukan, konfigurasikan [aturan substitusi font](/slides/id/net/font-substitution/), dan/atau [sematkan font](/slides/id/net/embedded-font/) ke dalam presentasi.

**Apakah saya dapat mengatur bahasa yang berbeda dalam satu paragraf?**

Ya. [LanguageId](https://reference.aspose.com/slides/id/net/aspose.slides/baseportionformat/languageid/) diterapkan pada tingkat bagian teks, sehingga satu paragraf dapat mencampur beberapa bahasa dengan pengaturan pembuktian yang berbeda.