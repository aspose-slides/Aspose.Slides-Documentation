---
title: API Publik dan Perubahan Tidak Kompatibel Mundur di Aspose.Slides untuk Java 15.1.0
linktitle: Aspose.Slides for Java 15.1.0
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
description: "Tinjau pembaruan API publik dan perubahan yang memecah di Aspose.Slides untuk Java untuk memigrasikan solusi presentasi PowerPoint PPT, PPTX, dan ODP Anda dengan mulus."
---
{{% alert color="info" %}} 

Halaman ini mencantumkan semua kelas, metode, properti, dan sebagainya yang [ditambahkan](/slides/id/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) serta batasan baru dan [perubahan](/slides/id/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) yang diperkenalkan dengan API Aspose.Slides for Java 15.1.0.

{{% /alert %}} {{% alert color="info" %}} 

Ada masalah yang diketahui dengan beberapa bullet gambar dan objek WordArt yang akan diperbaiki di Aspose.Slides for Java 15.2.0.

{{% /alert %}} 
## **Perubahan API Publik**
### **Fungsionalitas substitusi font telah ditambahkan**
Kemampuan untuk mengganti font secara global di seluruh presentasi dan sementara untuk rendering telah ditambahkan.

Metode baru getFontsManager() pada kelas Presentation telah diperkenalkan. Kelas FontsManager memiliki anggota-anggota berikut:

**IFontSubstRuleCollection getFontSubstRuleList**() metode

Ini adalah koleksi instance IFontSubstRule yang digunakan untuk menggantikan font selama rendering. IFontSubstRule memiliki metode getSourceFont() dan getDestFont() yang mengimplementasikan antarmuka IFontData serta metode getReplaceFontCondition() yang memungkinkan memilih kondisi penggantian ("WhenInaccessible" atau "Always").

Metode **IFontData[] getFonts()** dapat digunakan untuk mengambil semua font yang digunakan dalam presentasi saat ini.

Metode **replaceFont(...)** dapat digunakan untuk menggantikan font secara permanen dalam sebuah presentasi.

Contoh berikut menunjukkan cara menggantikan font dalam sebuah presentasi:

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation("PresContainsArialFont.pptx");

IFontData sourceFont = new FontData("Arial");

IFontData destFont = new FontData("Times New Roman");

pres.getFontsManager().replaceFont(sourceFont, destFont);

pres.save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);

```

Contoh lain menunjukkan substitusi font untuk rendering ketika font tidak dapat diakses:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");
try {
    IFontData sourceFont = new FontData("SomeRareFont");
    IFontData destFont = new FontData("Arial");

    IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);

    IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);

    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);

    // Font Arial akan digunakan alih-alih SomeRareFont ketika tidak dapat diakses.
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    slideImage.dispose();
} finally {
    if (pres != null) pres.dispose();
}
```