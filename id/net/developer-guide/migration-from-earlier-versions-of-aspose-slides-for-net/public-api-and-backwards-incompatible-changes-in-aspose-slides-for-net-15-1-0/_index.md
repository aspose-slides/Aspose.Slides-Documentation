---
title: API Publik dan Perubahan Tidak Kompatibel Mundur di Aspose.Slides untuk .NET 15.1.0
linktitle: Aspose.Slides untuk .NET 15.1.0
type: docs
weight: 130
url: /id/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/
keywords:
- migrasi
- kode warisan
- kode modern
- pendekatan warisan
- pendekatan modern
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Tinjau pembaruan API publik dan perubahan yang merusak di Aspose.Slides untuk .NET untuk memigrasikan solusi presentasi PowerPoint PPT, PPTX, dan ODP Anda dengan lancar."
---
{{% alert color="primary" %}} 

Halaman ini menampilkan semua [added](/slides/id/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) atau [removed](/slides/id/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) kelas, metode, properti, dan lain-lain, serta perubahan lainnya yang diperkenalkan dengan API Aspose.Slides untuk .NET 15.1.0.

{{% /alert %}} 
## **Public API Chages**
#### **Fonts Substitutions Functinality Has Been Added**
Kemampuan untuk mengganti font secara global di seluruh presentasi serta sementara untuk proses rendering telah ditambahkan.

Properti baru "FontsManager" pada kelas Presentation telah diperkenalkan. Kelas FontsManager memiliki anggota-anggota berikut:

**IFontSubstRuleCollection FontSubstRuleList** Property

Koleksi ini berisi instance IFontSubstRule yang digunakan untuk mengganti font selama rendering. IFontSubstRule memiliki properti SourceFont dan DestFont yang mengimplementasikan antarmuka IFontData serta properti ReplaceFontCondition yang memungkinkan memilih kondisi penggantian ("WhenInaccessible" atau "Always").

**IFontData[] GetFonts()** Method

Digunakan untuk mengambil semua font yang digunakan dalam presentasi saat ini.

**ReplaceFont** Methods

Digunakan untuk mengganti font secara permanen dalam presentasi. 

Contoh berikut menunjukkan cara mengganti font dalam presentasi:

``` csharp

             Presentation pres = new Presentation("PresContainsArialFont.pptx");

            IFontData sourceFont = new FontData("Arial");

            IFontData destFont = new FontData("Times New Roman");

            pres.FontsManager.ReplaceFont(sourceFont, destFont);

            pres.Save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);


``` 

Contoh lain menunjukkan substitusi font untuk rendering ketika tidak dapat diakses:

``` csharp

             Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

            IFontData sourceFont = new FontData("SomeRareFont");

            IFontData destFont = new FontData("Arial");

            IFontSubstRule fontSubstRule = new FontSubstRule(

                sourceFont, destFont, FontSubstCondition.WhenInaccessible);

            IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

            fontSubstRuleCollection.Add(fontSubstRule);

            pres.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

            // Font Arial akan digunakan alih-alih SomeRareFont ketika tidak dapat diakses

            pres.Slides[0].GetThumbnail();

```