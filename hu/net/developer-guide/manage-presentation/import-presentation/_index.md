---
title: "PDF‑ből vagy HTML‑ből történő prezentációimportálás .NET‑ben"
linktitle: "Prezentáció importálása"
type: docs
weight: 60
url: /hu/net/import-presentation/
keywords:
- "prezentáció importálása"
- "dia importálása"
- "PDF importálása"
- "HTML importálása"
- "PDF prezentációvá"
- "PDF PPT‑vé"
- "PDF PPTX‑vé"
- "PDF ODP‑vé"
- "HTML prezentációvá"
- "HTML PPT‑vé"
- "HTML PPTX‑vé"
- "HTML ODP‑vé"
- "PowerPoint"
- "OpenDocument"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "PDF és HTML dokumentumok könnyed importálása PowerPoint és OpenDocument prezentációkba .NET‑en az Aspose.Slides segítségével a zökkenőmentes, nagy teljesítményű diakezelés érdekében."
---
## **Bevezetés**

Az Aspose.Slides használatával más formátumú fájlokból importálhat prezentációkat. Az Aspose.Slides a [SlideCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/slidecollection/) osztályt biztosítja, amely lehetővé teszi a prezentációk importálását PDF és HTML dokumentumokból.

## **PowerPoint importálása PDF‑ből**

Ebben az esetben egy PDF‑et konvertál PowerPoint‑prezentációvá.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból.  
2. Hívja meg a [AddFromPdf](https://reference.aspose.com/slides/hu/net/aspose.slides.slidecollection/addfrompdf/methods/1) metódust, és adja meg a PDF‑fájlt.  
3. Használja a [Save](https://reference.aspose.com/slides/hu/net/aspose.slides.presentation/save/methods/5) metódust a fájl PowerPoint formátumban való mentéséhez.

Ez a C# kód bemutatja a PDF‑ről PowerPoint‑ra konvertálást:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    pres.Slides.AddFromPdf("InputPDF.pdf");
    pres.Save("OutputPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert  title="TIPP" color="info" %}} 
Érdemes megnézni az **Aspose ingyenes** [PDF to PowerPoint](https://products.aspose.app/slides/hu/import/pdf-to-powerpoint) webalkalmazást, mivel ez egy élő megvalósítása a leírt folyamatnak. 
{{% /alert %}} 

## **PowerPoint importálása HTML‑ből**

Ebben az esetben egy HTML‑dokumentumot konvertál PowerPoint‑prezentációvá.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból.  
2. Hívja meg a [AddFromHtml](https://reference.aspose.com/slides/hu/net/aspose.slides/slidecollection/addfromhtml/#addfromhtml) metódust, és adja meg a HTML‑fájlt.  
3. Használja a [Save](https://apireference.aspose.com/slides/hu/net/aspose.slides.presentation/save/methods/5) metódust a fájl PowerPoint‑dokumentumként való mentéséhez.

Ez a C# kód bemutatja a HTML‑ről PowerPoint‑ra konvertálást: 

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation())
{
    using (var htmlStream = File.OpenRead("page.html"))
    {
        presentation.Slides.AddFromHtml(htmlStream);
    }

    presentation.Save("MyPresentation.pptx", SaveFormat.Pptx);
}
```

## **GYIK**

### A táblázatok megmaradnak a PDF importálásakor, és javítható a felismerésük?

Az importálás során felismerhetők a táblázatok; a [PdfImportOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.import/pdfimportoptions/) tartalmaz egy [DetectTables](https://reference.aspose.com/slides/hu/net/aspose.slides.import/pdfimportoptions/detecttables/) paramétert, amely engedélyezi a táblázatok felismerését. A hatékonyság a PDF felépítésétől függ.

{{% alert title="Megjegyzés" color="warning" %}} 
Az Aspose.Slides segítségével a HTML‑t más népszerű fájlformátumokra is konvertálhatja: 

* [HTML képpé](https://products.aspose.com/slides/hu/net/conversion/html-to-image/)
* [HTML JPG‑ként](https://products.aspose.com/slides/hu/net/conversion/html-to-jpg/)
* [HTML XML‑ként](https://products.aspose.com/slides/hu/net/conversion/html-to-xml/)
* [HTML TIFF‑ként](https://products.aspose.com/slides/hu/net/conversion/html-to-tiff/)

{{% /alert %}}