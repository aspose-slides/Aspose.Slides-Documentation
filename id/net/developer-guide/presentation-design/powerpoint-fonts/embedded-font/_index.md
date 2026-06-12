---
title: Menyematkan Font dalam Presentasi di .NET
linktitle: Menyematkan Font
type: docs
weight: 40
url: /id/net/embedded-font/
keywords:
- tambah font
- menyematkan font
- penyematan font
- dapatkan font yang disematkan
- tambah font yang disematkan
- hapus font yang disematkan
- kompres font yang disematkan
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Menyematkan font TrueType dalam presentasi PowerPoint dan OpenDocument dengan Aspose.Slides untuk .NET, memastikan rendering yang akurat di semua platform."
---
## **Pengantar**

**Menyematkan font dalam PowerPoint** memastikan presentasi Anda mempertahankan tampilan yang dimaksud di berbagai sistem. Baik menggunakan font unik untuk kreativitas maupun yang standar, menyematkan font mencegah gangguan teks dan tata letak.

Jika Anda menggunakan font pihak ketiga atau non-standar karena berkreasi dengan pekerjaan Anda, maka Anda memiliki alasan lebih untuk menyematkan font tersebut. Sebaliknya (tanpa font yang disematkan), teks atau angka pada slide, tata letak, gaya, dll. dapat berubah atau menjadi kotak‑kotak yang membingungkan.

Manfaatkan kelas [FontsManager](https://reference.aspose.com/slides/id/net/aspose.slides/fontsmanager/), [FontData](https://reference.aspose.com/slides/id/net/aspose.slides/fontdata/), dan [Compress](https://reference.aspose.com/slides/id/net/aspose.slides.lowcode/compress/) untuk mengelola font yang disematkan.

## **Ambil dan Hapus Font yang Disematkan**

Dapatkan atau hapus font yang disematkan dari sebuah presentasi dengan mudah menggunakan metode [GetEmbeddedFonts](https://reference.aspose.com/slides/id/net/aspose.slides/fontsmanager/getembeddedfonts) dan [RemoveEmbeddedFont](https://reference.aspose.com/slides/id/net/aspose.slides/fontsmanager/removeembeddedfont).

Kode C# berikut menunjukkan cara mengambil dan menghapus font yang disematkan dari sebuah presentasi:

```c#
using (Presentation presentation = new Presentation("EmbeddedFonts.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Merender slide yang berisi bingkai teks yang menggunakan font "FunSized" yang disematkan
    using (IImage image = slide.GetImage(new Size(960, 720)))
    {
        image.Save("picture1_out.png", ImageFormat.Png);
    }

    IFontsManager fontsManager = presentation.FontsManager;

    IFontData[] embeddedFonts = fontsManager.GetEmbeddedFonts();

    // Menemukan font "Calibri"
    IFontData funSizedEmbeddedFont = Array.Find(embeddedFonts, delegate (IFontData data)
    {
        return data.FontName == "Calibri";
    });

    // Menghapus font "Calibri"
    fontsManager.RemoveEmbeddedFont(funSizedEmbeddedFont);

    // Merender presentasi; font "Calibri" digantikan dengan yang sudah ada
    using (IImage image = slide.GetImage(new Size(960, 720)))
    {
        image.Save("picture2_out.png", ImageFormat.Png);
    }

    // Menyimpan presentasi tanpa font "Calibri" yang disematkan ke disk
    presentation.Save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
}
```

## **Tambah Font yang Disematkan**

Dengan menggunakan enum [EmbedFontCharacters](https://reference.aspose.com/slides/id/net/aspose.slides.export/embedfontcharacters/) dan dua overload dari metode [AddEmbeddedFont](https://reference.aspose.com/slides/id/net/aspose.slides/fontsmanager/addembeddedfont/), Anda dapat memilih aturan (penyematan) yang diinginkan untuk menyematkan font dalam sebuah presentasi. Kode C# berikut menunjukkan cara menyematkan dan menambah font ke dalam presentasi:

```c#
// Memuat presentasi
Presentation presentation = new Presentation("Fonts.pptx");

IFontData[] allFonts = presentation.FontsManager.GetFonts();
IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();
foreach (IFontData font in allFonts)
{
    if (!embeddedFonts.Contains(font))
    {
        presentation.FontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);
    }
}

// Menyimpan presentasi ke disk
presentation.Save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
```

## **Kompres Font yang Disematkan**

Optimalkan ukuran file dengan mengompres font yang disematkan menggunakan [CompressEmbeddedFonts](https://reference.aspose.com/slides/id/net/aspose.slides.lowcode/compress/compressembeddedfonts/).

Contoh kode untuk kompresi:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.CompressEmbeddedFonts(pres);
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Bagaimana saya dapat mengetahui bahwa font tertentu dalam presentasi masih akan digantikan saat rendering meskipun sudah disematkan?**

Periksa [informasi substitusi](/slides/id/net/font-substitution/) di font manager dan [aturan fallback/substitusi](/slides/id/net/fallback-font/): jika font tidak tersedia atau dibatasi, fallback akan digunakan.

**Apakah layak menyematkan font "system" seperti Arial/Calibri?**

Biasanya tidak—font tersebut hampir selalu tersedia. Namun untuk portabilitas penuh dalam lingkungan "tipis" (Docker, server Linux tanpa font terpasang), menyematkan font sistem dapat menghilangkan risiko substitusi yang tidak terduga.