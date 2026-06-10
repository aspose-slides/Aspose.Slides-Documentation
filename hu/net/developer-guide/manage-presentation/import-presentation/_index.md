---
title: "Prezentációk importálása PDF vagy HTML fájlokból .NET-ben"
linktitle: "Prezentáció importálása"
type: docs
weight: 60
url: /hu/net/import-presentation/
keywords:
- "prezentáció importálása"
- "dia importálása"
- "PDF importálása"
- "HTML importálása"
- "PDF prezentációvá alakítás"
- "PDF PPT-vé alakítás"
- "PDF PPTX-vé alakítás"
- "PDF ODP-vé alakítás"
- "HTML prezentációvá alakítás"
- "HTML PPT-vé alakítás"
- "HTML PPTX-vé alakítás"
- "HTML ODP-vé alakítás"
- "PowerPoint"
- "OpenDocument"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Könnyedén importálhat PDF és HTML dokumentumokat PowerPoint és OpenDocument prezentációkba .NET környezetben az Aspose.Slides segítségével, zökkenőmentes, nagy teljesítményű diafeldolgozást biztosítva."
---
## **Bevezetés**

Az Aspose.Slides segítségével importálhat prezentációkat más formátumú fájlokból. Az Aspose.Slides biztosítja a [SlideCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/slidecollection/) osztályt, amely lehetővé teszi a PDF és HTML dokumentumokból való importálást.

## **PowerPoint importálása PDF-ből**

Ebben az esetben egy PDF-fájlt PowerPoint‑prezentációvá konvertálhat.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból. 
2. Hívja meg a [AddFromPdf](https://reference.aspose.com/slides/hu/net/aspose.slides.slidecollection/addfrompdf/methods/1) metódust, és adja át a PDF-fájlt. 
3. Használja a [Save](https://reference.aspose.com/slides/hu/net/aspose.slides.presentation/save/methods/5) metódust a fájl PowerPoint formátumban történő mentéséhez.

Ez a C# kód bemutatja a PDF‑ról PowerPoint‑ra átalakítást:

```c#
using (Presentation pres = new Presentation())
{
    pres.Slides.AddFromPdf("InputPDF.pdf");
    pres.Save("OutputPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert  title="TIP" color="primary" %}} 
Érdemes megnézni az **Aspose ingyenes** [PDF to PowerPoint](https://products.aspose.app/slides/hu/import/pdf-to-powerpoint) webalkalmazást, mivel ez egy élő megvalósítása a leírt folyamatnak. 
{{% /alert %}} 

## **PowerPoint importálása HTML-ből**

Ebben az esetben egy HTML-dokumentumot PowerPoint‑prezentációvá konvertálhat.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból. 
2. Hívja meg a [AddFromHtml](https://reference.aspose.com/slides/hu/net/aspose.slides/slidecollection/addfromhtml/#addfromhtml) metódust, és adja át a HTML-fájlt. 
3. Használja a [Save](https://apireference.aspose.com/slides/hu/net/aspose.slides.presentation/save/methods/5) metódust a fájl PowerPoint dokumentumként való mentéséhez.

Ez a C# kód bemutatja a HTML‑ról PowerPoint‑ra átalakítást: 

```c#
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

**Megmaradnak a táblázatok PDF importálása során, és javítható a felismerésük?**

A táblázatok importálás közben felderíthetők; a [PdfImportOptions](https://reference.aspose.com/slides/hu/net/aspose.slides.import/pdfimportoptions/) tartalmaz egy [DetectTables](https://reference.aspose.com/slides/hu/net/aspose.slides.import/pdfimportoptions/detecttables/) paramétert, amely engedélyezi a táblázatok felismerését. A hatékonyság a PDF felépítésétől függ.

{{% alert title="Note" color="warning" %}} 
Az Aspose.Slides segítségével HTML-t is konvertálhat más népszerű fájlformátumokba: 

* [HTML képre](https://products.aspose.com/slides/hu/net/conversion/html-to-image/)
* [HTML JPG-re](https://products.aspose.com/slides/hu/net/conversion/html-to-jpg/)
* [HTML XML-re](https://products.aspose.com/slides/hu/net/conversion/html-to-xml/)
* [HTML TIFF-re](https://products.aspose.com/slides/hu/net/conversion/html-to-tiff/)

{{% /alert %}}