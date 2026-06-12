---
title: Kelola Superskrip dan Subskrip dalam Presentasi di .NET
linktitle: Superskrip dan Subskrip
type: docs
weight: 80
url: /id/net/superscript-and-subscript/
keywords:
- superskrip
- subskrip
- tambahkan superskrip
- tambahkan subskrip
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Kuasai superskrip dan subskrip dalam Aspose.Slides untuk .NET dan tingkatkan presentasi Anda dengan pemformatan teks profesional untuk dampak maksimal."
---
## **Gambaran Umum**

Aspose.Slides for .NET menyediakan fitur untuk mengintegrasikan teks superskrip dan subskrip ke dalam presentasi PowerPoint (PPT, PPTX) dan OpenDocument (ODP) Anda. Baik Anda perlu menyoroti rumus kimia, persamaan matematika, atau memberi anotasi pada konten dengan catatan kaki, opsi pemformatan khusus ini membantu menjaga kejelasan dan ketepatan. Pada artikel ini, Anda akan mempelajari cara menerapkan gaya superskrip dan subskrip secara mulus serta memastikan hasil profesional di setiap slide.

## **Menambahkan Teks Superskrip dan Subskrip**

Anda dapat menambahkan teks superskrip dan subskrip di dalam paragraf apa pun dalam sebuah presentasi. Untuk melakukannya dengan Aspose.Slides, Anda harus menggunakan properti `Escapement` dari kelas [PortionFormat](https://reference.aspose.com/slides/id/net/aspose.slides/portionformat/).

Properti ini memungkinkan Anda mengatur teks superskrip atau subskrip, dengan nilai berkisar antara -100% (subskrip) hingga 100% (superskrip).

Langkah-langkah implementasi:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/).
2. Dapatkan referensi ke slide menggunakan indeksnya.
3. Tambahkan sebuah [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/) berjenis `Rectangle` ke slide.
4. Akses [ITextFrame](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/) yang terkait dengan [IAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/iautoshape/).
5. Bersihkan paragraf yang ada.
6. Buat sebuah [Paragraph](https://reference.aspose.com/slides/id/net/aspose.slides/paragraph/) baru untuk teks superskrip dan tambahkan ke koleksi paragraf pada [ITextFrame](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/).
7. Buat sebuah objek bagian teks baru.
8. Setel properti `Escapement` untuk bagian teks antara 0 hingga 100 untuk menerapkan superskrip (0 berarti tidak ada superskrip).
9. Setel beberapa teks untuk [Portion](https://reference.aspose.com/slides/id/net/aspose.slides/portion/) dan tambahkan ke koleksi bagian pada paragraf.
10. Buat sebuah [Paragraph](https://reference.aspose.com/slides/id/net/aspose.slides/paragraph/) lain untuk teks subskrip dan tambahkan ke koleksi paragraf.
11. Buat sebuah objek bagian teks baru.
12. Setel properti `Escapement` untuk bagian teks antara 0 hingga -100 untuk menerapkan subskrip (0 berarti tidak ada subskrip).
13. Setel beberapa teks untuk [Portion](https://reference.aspose.com/slides/id/net/aspose.slides/portion/) dan tambahkan ke koleksi bagian pada paragraf.
14. Simpan presentasi sebagai file PPTX.

Kode C# berikut mengimplementasikan langkah-langkah ini:

```c#
using (Presentation presentation = new Presentation())
{
    // Dapatkan slide pertama.
    ISlide slide = presentation.Slides[0];

    // Buat kotak teks.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.TextFrame;

    textFrame.Paragraphs.Clear();

    // Buat paragraf untuk teks superskrip.
    IParagraph superPar = new Paragraph();

    // Buat bagian teks dengan teks biasa.
    IPortion portion1 = new Portion();
    portion1.Text = "MyProduct";
    superPar.Portions.Add(portion1);

    // Buat bagian teks dengan teks superskrip.
    IPortion superPortion = new Portion();
    superPortion.PortionFormat.Escapement = 30;
    superPortion.Text = "TM";
    superPar.Portions.Add(superPortion);

    // Buat paragraf untuk teks subskrip.
    IParagraph paragraph2 = new Paragraph();

    // Buat bagian teks dengan teks biasa.
    IPortion portion2 = new Portion();
    portion2.Text = "a";
    paragraph2.Portions.Add(portion2);

    // Buat bagian teks dengan teks subskrip.
    IPortion subPortion = new Portion();
    subPortion.PortionFormat.Escapement = -25;
    subPortion.Text = "i";
    paragraph2.Portions.Add(subPortion);

    // Tambahkan paragraf ke kotak teks.
    textFrame.Paragraphs.Add(superPar);
    textFrame.Paragraphs.Add(paragraph2);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

Hasil:

![Superscript and Subscript](superscript_and_subscript.png)

## **FAQ**

**Apakah superskrip dan subskrip akan dipertahankan saat mengekspor ke PDF atau format lain?**

Ya, Aspose.Slides for .NET dengan tepat mempertahankan pemformatan superskrip dan subskrip saat mengekspor presentasi ke PDF, PPT/PPTX, gambar, dan format lain yang didukung. Pemformatan khusus tetap utuh di semua file keluaran.

**Apakah superskrip dan subskrip dapat digabungkan dengan gaya pemformatan lain seperti tebal atau miring?**

Ya, Aspose.Slides memungkinkan Anda mencampur berbagai gaya teks dalam satu bagian teks. Anda dapat mengaktifkan tebal, miring, garis bawah, dan secara bersamaan menerapkan superskrip atau subskrip dengan mengonfigurasi properti yang sesuai di [PortionFormat](https://reference.aspose.com/slides/id/net/aspose.slides/portionformat/).

**Apakah pemformatan superskrip dan subskrip bekerja untuk teks di dalam tabel, diagram, atau SmartArt?**

Ya, Aspose.Slides for .NET mendukung pemformatan di dalam sebagian besar objek, termasuk tabel dan elemen diagram. Saat bekerja dengan SmartArt, Anda harus mengakses elemen yang sesuai (seperti [SmartArtNode](https://reference.aspose.com/slides/id/net/aspose.slides.smartart/smartartnode/)) dan kontainer teksnya, lalu mengonfigurasi properti [PortionFormat](https://reference.aspose.com/slides/id/net/aspose.slides/portionformat/) dengan cara yang serupa.