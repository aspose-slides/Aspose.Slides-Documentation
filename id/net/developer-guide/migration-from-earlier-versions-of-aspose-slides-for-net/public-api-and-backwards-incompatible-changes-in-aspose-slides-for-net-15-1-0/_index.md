---
title: API Publik dan Perubahan Tidak Kompatibel ke Belakang di Aspose.Slides untuk .NET 15.1.0
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
description: "Tinjau pembaruan API publik dan perubahan yang memutuskan dalam Aspose.Slides untuk .NET untuk memigrasikan solusi presentasi PowerPoint PPT, PPTX, dan ODP Anda dengan mulus."
---
{{% alert color="info" %}} 

Halaman ini menampilkan semua [ditambahkan](/slides/id/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) atau [dihapus](/slides/id/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) kelas, metode, properti, dan sebagainya, serta perubahan lain yang diperkenalkan dengan API Aspose.Slides for .NET 15.1.0.

{{% /alert %}} 
## **Perubahan API Publik**
#### **Fungsionalitas Substitusi Font Telah Ditambahkan**
Kemampuan untuk mengganti font secara global di seluruh presentasi dan sementara untuk rendering telah ditambahkan.

Properti baru "FontsManager" pada kelas Presentation telah diperkenalkan. Kelas FontsManager memiliki anggota-anggota berikut:

**IFontSubstRuleCollection FontSubstRuleList** Properti

Koleksi ini berisi instance IFontSubstRule yang digunakan untuk mengganti font selama rendering. IFontSubstRule memiliki properti SourceFont dan DestFont yang mengimplementasikan interface IFontData serta properti ReplaceFontCondition yang memungkinkan memilih kondisi penggantian ("WhenInaccessible" atau "Always").

**IFontData[] GetFonts()** Metode

Digunakan untuk mengambil semua font yang digunakan dalam presentasi saat ini.

**ReplaceFont** Metode

Digunakan untuk mengganti font secara permanen dalam presentasi. 

Contoh berikut menunjukkan cara mengganti font dalam presentasi:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


             Presentation pres = new Presentation("PresContainsArialFont.pptx");

            IFontData sourceFont = new FontData("Arial");

            IFontData destFont = new FontData("Times New Roman");

            pres.FontsManager.ReplaceFont(sourceFont, destFont);

            pres.Save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);


``` 

Contoh lain menunjukkan substitusi font untuk rendering ketika tidak dapat diakses:

``` csharp
using Aspose.Slides;


             Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

            IFontData sourceFont = new FontData("SomeRareFont");

            IFontData destFont = new FontData("Arial");

            IFontSubstRule fontSubstRule = new FontSubstRule(

                sourceFont, destFont, FontSubstCondition.WhenInaccessible);

            IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

            fontSubstRuleCollection.Add(fontSubstRule);

            pres.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

            // Font Arial akan digunakan alih-alih SomeRareFont ketika tidak dapat diakses

            pres.Slides[0].GetImage();

```