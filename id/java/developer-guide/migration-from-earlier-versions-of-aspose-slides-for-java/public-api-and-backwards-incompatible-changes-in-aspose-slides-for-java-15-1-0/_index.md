---
title: API Publik dan Perubahan Tidak Kompatibel ke Belakang di Aspose.Slides untuk Java 15.1.0
linktitle: Aspose.Slides untuk Java 15.1.0
type: docs
weight: 100
url: /id/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/
keywords:
- migrasi
- kode warisan
- kode modern
- pendekatan warisan
- pendekatan modern
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Tinjau pembaruan API publik dan perubahan yang merusak di Aspose.Slides untuk Java untuk memigrasikan solusi presentasi PowerPoint PPT, PPTX, dan ODP Anda dengan mulus."
---
{{% alert color="primary" %}} 

Halaman ini mencantumkan semua kelas, metode, properti, dan sebagainya yang [ditambahkan](/slides/id/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) serta pembatasan baru dan [perubahan](/slides/id/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) yang diperkenalkan dengan API Aspose.Slides for Java 15.1.0.

{{% /alert %}} {{% alert color="primary" %}} 

Ada masalah yang diketahui dengan beberapa bullet gambar dan objek WordArt yang akan diperbaiki di Aspose.Slides for Java 15.2.0.

{{% /alert %}} 
## **Public API Changes**
### **Fonts substitutions functinality has been added**
Kemungkinan untuk mengganti font secara global di seluruh presentasi dan sementara untuk rendering telah ditambahkan.

Metode baru getFontsManager() pada kelas Presentation telah diperkenalkan. Kelas FontsManager memiliki anggota-anggota berikut:

**IFontSubstRuleCollection getFontSubstRuleList**() method

Ini adalah koleksi instance IFontSubstRule yang digunakan untuk mengganti font selama rendering. IFontSubstRule memiliki metode getSourceFont() dan getDestFont() yang mengimplementasikan antarmuka IFontData serta metode getReplaceFontCondition() yang memungkinkan pemilihan kondisi penggantian ("WhenInaccessible" atau "Always").

**IFontData[] getFonts()** method dapat digunakan untuk mengambil semua font yang digunakan dalam presentasi saat ini.

**replaceFont(...)** methods dapat digunakan untuk mengganti font secara permanen dalam sebuah presentasi. 

Contoh berikut menunjukkan cara mengganti font dalam sebuah presentasi:

``` java

 Presentation pres = new Presentation("PresContainsArialFont.pptx");

IFontData sourceFont = new FontData("Arial");

IFontData destFont = new FontData("Times New Roman");

pres.getFontsManager().replaceFont(sourceFont, destFont);

pres.save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);

```

Contoh lain menunjukkan penggantian font untuk rendering ketika tidak dapat diakses:

``` java



Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

IFontData sourceFont = new FontData("SomeRareFont");

IFontData destFont = new FontData("Arial");

IFontSubstRule fontSubstRule = new FontSubstRule(

sourceFont, destFont, FontSubstCondition.WhenInaccessible);

IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

fontSubstRuleCollection.add(fontSubstRule);

pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);

// Font Arial akan digunakan alih-alih SomeRareFont ketika tidak dapat diakses

pres.getSlides().get_Item(0).getThumbnail(1, 1);

```