---
title: Import prezentací z PDF nebo HTML v .NET
linktitle: Import prezentace
type: docs
weight: 60
url: /cs/net/import-presentation/
keywords:
- import prezentace
- import snímku
- import PDF
- import HTML
- PDF na prezentaci
- PDF na PPT
- PDF na PPTX
- PDF na ODP
- HTML na prezentaci
- HTML na PPT
- HTML na PPTX
- HTML na ODP
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Jednoduše importujte PDF a HTML dokumenty do prezentací PowerPoint a OpenDocument v .NET pomocí Aspose.Slides pro plynulé a vysoce výkonné zpracování snímků."
---
## **Úvod**

Pomocí Aspose.Slides můžete importovat prezentace ze souborů v jiných formátech. Aspose.Slides poskytuje třídu [SlideCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/slidecollection/), která umožňuje importovat prezentace z PDF a HTML dokumentů.

## **Import PowerPoint z PDF**

V tomto případě můžete převést PDF na prezentaci PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/). 
2. Zavolejte metodu [AddFromPdf](https://reference.aspose.com/slides/cs/net/aspose.slides.slidecollection/addfrompdf/methods/1) a předávejte soubor PDF. 
3. Použijte metodu [Save](https://reference.aspose.com/slides/cs/net/aspose.slides.presentation/save/methods/5) k uložení souboru ve formátu PowerPoint.

Tento C# kód demonstruje operaci převodu PDF na PowerPoint:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    pres.Slides.AddFromPdf("InputPDF.pdf");
    pres.Save("OutputPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert  title="TIP" color="info" %}} 

Chtěli byste vyzkoušet **Aspose free** [PDF na PowerPoint](https://products.aspose.app/slides/cs/import/pdf-to-powerpoint) webovou aplikaci, protože je to živá implementace procesu popsaného zde. 

{{% /alert %}} 

## **Import PowerPoint z HTML**

V tomto případě můžete převést HTML dokument na prezentaci PowerPoint.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/). 
2. Zavolejte metodu [AddFromHtml](https://reference.aspose.com/slides/cs/net/aspose.slides/slidecollection/addfromhtml/#addfromhtml) a předávejte soubor HTML. 
3. Použijte metodu [Save](https://apireference.aspose.com/slides/cs/net/aspose.slides.presentation/save/methods/5) k uložení souboru jako dokument PowerPoint.

Tento C# kód demonstruje operaci převodu HTML na PowerPoint: 

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

## **FAQ**

### Jsou tabulky zachovány při importu PDF a lze jejich detekci vylepšit?

Tabulky lze během importu detekovat; [PdfImportOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.import/pdfimportoptions/) obsahuje parametr [DetectTables](https://reference.aspose.com/slides/cs/net/aspose.slides.import/pdfimportoptions/detecttables/), který umožňuje rozpoznávání tabulek. Účinnost závisí na struktuře PDF.

{{% alert title="Note" color="warning" %}} 

Můžete také použít Aspose.Slides k převodu HTML do dalších populárních formátů souborů: 

* [HTML na obrázek](https://products.aspose.com/slides/cs/net/conversion/html-to-image/)
* [HTML na JPG](https://products.aspose.com/slides/cs/net/conversion/html-to-jpg/)
* [HTML na XML](https://products.aspose.com/slides/cs/net/conversion/html-to-xml/)
* [HTML na TIFF](https://products.aspose.com/slides/cs/net/conversion/html-to-tiff/)

{{% /alert %}}