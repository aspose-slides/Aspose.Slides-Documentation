---
title: Importovat prezentace z PDF nebo HTML v .NET
linktitle: Importovat prezentaci
type: docs
weight: 60
url: /cs/net/import-presentation/
keywords:
- import prezentace
- import snímku
- import PDF
- import HTML
- PDF do prezentace
- PDF do PPT
- PDF do PPTX
- PDF do ODP
- HTML do prezentace
- HTML do PPT
- HTML do PPTX
- HTML do ODP
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Jednoduše importujte PDF a HTML dokumenty do prezentací PowerPoint a OpenDocument v .NET pomocí Aspose.Slides pro plynulé a výkonné zpracování snímků."
---
## **Úvod**

Pomocí Aspose.Slides můžete importovat prezentace ze souborů v jiných formátech. Aspose.Slides poskytuje třídu [SlideCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/slidecollection/), která umožňuje importovat prezentace z PDF a HTML dokumentů.

## **Importovat PowerPoint z PDF**

V tomto případě můžete převést PDF na prezentaci PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/). 
2. Zavolejte metodu [AddFromPdf](https://reference.aspose.com/slides/cs/net/aspose.slides.slidecollection/addfrompdf/methods/1) a předávejte PDF soubor. 
3. Použijte metodu [Save](https://reference.aspose.com/slides/cs/net/aspose.slides.presentation/save/methods/5) k uložení souboru ve formátu PowerPoint.

Tento C# kód demonstruje operaci převodu PDF na PowerPoint:

```c#
using (Presentation pres = new Presentation())
{
    pres.Slides.AddFromPdf("InputPDF.pdf");
    pres.Save("OutputPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert  title="TIP" color="primary" %}} 
Můžete si vyzkoušet **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/cs/import/pdf-to-powerpoint) webovou aplikaci, protože se jedná o živou implementaci procesu popsaného zde. 
{{% /alert %}} 

## **Importovat PowerPoint z HTML**

V tomto případě můžete převést HTML dokument na prezentaci PowerPoint.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/). 
2. Zavolejte metodu [AddFromHtml](https://reference.aspose.com/slides/cs/net/aspose.slides/slidecollection/addfromhtml/#addfromhtml) a předávejte HTML soubor. 
3. Použijte metodu [Save](https://apireference.aspose.com/slides/cs/net/aspose.slides.presentation/save/methods/5) k uložení souboru jako dokument PowerPoint.

Tento C# kód demonstruje operaci převodu HTML na PowerPoint: 

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

## **Často kladené otázky**

**Zůstávají tabulky zachovány při importu PDF a lze zlepšit jejich detekci?**

Tabulky lze během importu detekovat; [PdfImportOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.import/pdfimportoptions/) zahrnuje parametr [DetectTables](https://reference.aspose.com/slides/cs/net/aspose.slides.import/pdfimportoptions/detecttables/), který umožňuje rozpoznávání tabulek. Účinnost závisí na struktuře PDF.

{{% alert title="Note" color="warning" %}} 
Můžete také použít Aspose.Slides k převodu HTML do dalších populárních formátů souborů: 

* [HTML to image](https://products.aspose.com/slides/cs/net/conversion/html-to-image/)
* [HTML to JPG](https://products.aspose.com/slides/cs/net/conversion/html-to-jpg/)
* [HTML to XML](https://products.aspose.com/slides/cs/net/conversion/html-to-xml/)
* [HTML to TIFF](https://products.aspose.com/slides/cs/net/conversion/html-to-tiff/)
{{% /alert %}}