---
title: Import prezentací z PDF nebo HTML v C++
linktitle: Import prezentace
type: docs
weight: 60
url: /cs/cpp/import-presentation/
keywords:
- importovat prezentaci
- importovat snímek
- importovat PDF
- importovat HTML
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
- C++
- Aspose.Slides
description: "Jednoduše importujte PDF a HTML dokumenty do prezentací PowerPoint a OpenDocument v C++ pomocí Aspose.Slides pro plynulé, vysoce výkonné zpracování snímků."
---
## **Úvod**

Pomocí [**Aspose.Slides for C++**](https://products.aspose.com/slides/cs/cpp/) můžete importovat prezentace ze souborů v jiných formátech. Aspose.Slides poskytuje třídu [SlideCollection](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.slide_collection), která vám umožní importovat prezentace z PDF, HTML dokumentů atd.

## **Import PowerPointu z PDF**

V tomto případě můžete převést PDF na prezentaci PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Vytvořte instanci třídy Presentation.  
2. Zavolejte metodu [AddFromPdf()](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.slide_collection#a966c00d26b741a6c56e424d2f0d689a5) a předáte PDF soubor.  
3. Použijte metodu [Save()](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) k uložení souboru ve formátu PowerPoint.

Tento C++ kód demonstruje operaci převodu PDF na PowerPoint:

```cpp
auto pres = System::MakeObject<Presentation>();
    
pres->get_Slides()->AddFromPdf(u"InputPDF.pdf");
pres->Save(u"OutputPresentation.pptx", SaveFormat::Pptx);
```

{{% alert title="Tip" color="primary" %}} 
Možná budete chtít vyzkoušet bezplatnou webovou aplikaci Aspose PDF do PowerPoint, protože se jedná o živou implementaci zde popsaného postupu. 
{{% /alert %}} 

## **Import PowerPointu z HTML**

V tomto případě můžete převést HTML dokument na prezentaci PowerPoint.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation/).  
2. Zavolejte metodu [AddFromHtml()](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.slide_collection#ad4337f6be235c230d5d422a6799ef965) a předáte HTML soubor.  
3. Použijte metodu [Save()](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) k uložení souboru ve formátu PowerPoint.

Tento C++ kód demonstruje operaci převodu HTML na PowerPoint:

```c++
auto presentation = System::MakeObject<Presentation>();

{
    auto htmlStream = System::IO::File::OpenRead(u"page.html");
    presentation->get_Slides()->AddFromHtml(htmlStream);
}

presentation->Save(u"MyPresentation.pptx", SaveFormat::Pptx);
```

{{% alert title="Poznámka" color="warning" %}} 
Můžete také použít Aspose.Slides k převodu HTML do dalších populárních formátů souborů: 

* [HTML to image](https://products.aspose.com/slides/cs/cpp/conversion/html-to-image/)
* [HTML to JPG](https://products.aspose.com/slides/cs/cpp/conversion/html-to-jpg/)
* [HTML to XML](https://products.aspose.com/slides/cs/cpp/conversion/html-to-xml/)
* [HTML to TIFF](https://products.aspose.com/slides/cs/cpp/conversion/html-to-tiff/)

{{% /alert %}}

## **Často kladené otázky**

**Jsou tabulky zachovány při importu PDF a lze jejich rozpoznávání zlepšit?**

Tabulky lze během importu detekovat; [PdfImportOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.import/pdfimportoptions/) obsahuje metodu [set_DetectTables](https://reference.aspose.com/slides/cs/cpp/aspose.slides.import/pdfimportoptions/set_detecttables/), která umožňuje rozpoznávání tabulek. Úspěšnost závisí na struktuře PDF.