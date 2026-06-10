---
title: "PowerPoint prezentációk konvertálása Word dokumentumokká .NET-ben"
linktitle: "PowerPoint Word-re"
type: docs
weight: 110
url: /hu/net/convert-powerpoint-to-word/
keywords:
- "PowerPoint átalakítása"
- "prezentáció átalakítása"
- "dia átalakítása"
- "PPT átalakítása"
- "PPTX átalakítása"
- "PowerPoint Word-re"
- "prezentáció Word-re"
- "dia Word-re"
- "PPT Word-re"
- "PPTX Word-re"
- "PowerPoint DOCX-re"
- "prezentáció DOCX-re"
- "dia DOCX-re"
- "PPT DOCX-re"
- "PPTX DOCX-re"
- "PowerPoint DOC-ra"
- "prezentáció DOC-ra"
- "dia DOC-ra"
- "PPT DOC-ra"
- "PPTX DOC-ra"
- "PPT mentése DOCX-ként"
- "PPTX mentése DOCX-ként"
- "PPT exportálása DOCX-be"
- "PPTX exportálása DOCX-be"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "PowerPoint PPT és PPTX diák konvertálása szerkeszthető Word dokumentumokká C#-ban az Aspose.Slides for .NET használatával, megőrizve a pontos elrendezést, képeket és formázást."
---
## **Áttekintés**

Ez a cikk megoldást kínál a fejlesztők számára a PowerPoint és OpenDocument prezentációk Word dokumentummá konvertálásához az Aspose.Slides for .NET és az Aspose.Words for .NET használatával. A lépésről‑lépésre útmutató végigvezet a konverzió minden szakaszán.

## **Prezentáció konvertálása Word dokumentummá**

Az alábbi utasítások követésével konvertálhatja a PowerPoint vagy OpenDocument prezentációt Word dokumentummá:

1. Hozza létre a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályt, és töltse be a prezentáció fájlt.
2. Hozza létre a [Document](https://reference.aspose.com/words/net/aspose.words/document/) és a [DocumentBuilder](https://reference.aspose.com/words/net/aspose.words/documentbuilder/) osztályokat a Word dokumentum előállításához.
3. Állítsa be a Word dokumentum oldalméretét a prezentáció méretéhez igazítva a [DocumentBuilder.PageSetup](https://reference.aspose.com/words/net/aspose.words/documentbuilder/pagesetup/) tulajdonság segítségével.
4. Állítsa be a margókat a Word dokumentumban a [DocumentBuilder.PageSetup](https://reference.aspose.com/words/net/aspose.words/documentbuilder/pagesetup/) tulajdonság segítségével.
5. Iteráljon végig a prezentáció összes dián a [Presentation.Slides](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/slides/hu/) tulajdonság segítségével.
    - Generáljon egy diaképet a [ISlide](https://reference.aspose.com/slides/hu/net/aspose.slides/islide/) interfész `GetImage` metódusával, és mentse egy memóriaáramba.
    - Adja hozzá a diaképet a Word dokumentumhoz a [DocumentBuilder](https://reference.aspose.com/words/net/aspose.words/documentbuilder/) osztály `InsertImage` metódusával.
6. Mentse a Word dokumentumot egy fájlba.

Tegyük fel, hogy van egy "sample.pptx" prezentációnk, amely így néz ki:

![PowerPoint prezentáció](PowerPoint.png)

A következő C# kódrészlet bemutatja, hogyan konvertálhatja a PowerPoint prezentációt Word dokumentummá:

```cs
// Prezentációs fájl betöltése.
using var presentation = new Presentation("sample.pptx");

// Document és DocumentBuilder objektumok létrehozása.
var document = new Document();
var builder = new DocumentBuilder(document);

// Állítsa be az oldal méretét a Word dokumentumban.
var slideSize = presentation.SlideSize.Size;
builder.PageSetup.PageWidth = slideSize.Width;
builder.PageSetup.PageHeight = slideSize.Height;

// Állítsa be a margókat a Word dokumentumban.
builder.PageSetup.LeftMargin = 0;
builder.PageSetup.RightMargin = 0;
builder.PageSetup.TopMargin = 0;
builder.PageSetup.BottomMargin = 0;

const float scaleX = 2, scaleY = 2;

// Iteráljon végig a prezentáció összes diáján.
foreach (var slide in presentation.Slides)
{
    // Készítsen diaképet, és mentse memóriaáramba.
    using var image = slide.GetImage(scaleX, scaleY);
    using var imageStream = new MemoryStream();
    image.Save(imageStream, ImageFormat.Png);

    // Adja hozzá a diaképet a Word dokumentumhoz.
    imageStream.Seek(0, SeekOrigin.Begin);
    builder.InsertImage(imageStream.ToArray(), builder.PageSetup.PageWidth, builder.PageSetup.PageHeight);

    builder.InsertBreak(BreakType.PageBreak);
}

// Mentse a Word dokumentumot egy fájlba.
document.Save("output.docx");
```

Az eredmény:

![Word dokumentum](Word.png)

{{% alert color="primary" %}} 
Próbálja ki az [**Online PPT to Word Converter**](https://products.aspose.app/slides/hu/conversion/ppt-to-word) szolgáltatásunkat, hogy lássa, mit nyerhet a PowerPoint és OpenDocument prezentációk Word dokumentummá konvertálásával. 
{{% /alert %}}

## **GYIK**

**Milyen összetevőket kell telepíteni a PowerPoint és OpenDocument prezentációk Word dokumentummá konvertálásához?**

Csak fel kell vennie a megfelelő NuGet csomagokat a [Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET) és a [Aspose.Words for .NET](https://www.nuget.org/packages/Aspose.Words/) számára a C# projektjébe. Mindkét könyvtár önálló API-ként működik, és nincs szükség a Microsoft Office telepítésére.

**Támogatottak-e minden PowerPoint és OpenDocument prezentációs formátum?**

Az Aspose.Slides for .NET [támogatja az összes prezentációs formátumot](/slides/hu/net/supported-file-formats/), beleértve a PPT, PPTX, ODP és egyéb gyakori fájltípusokat. Ez biztosítja, hogy a Microsoft PowerPoint különböző verzióival készült prezentációkkal is dolgozhasson.