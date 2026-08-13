---
title: Import prezentací z PDF nebo HTML v C++
linktitle: Import prezentace
type: docs
weight: 60
url: /cs/cpp/import-presentation/
keywords:
- import prezentace
- import snímek
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
- C++
- Aspose.Slides
description: "Jednoduše importujte PDF a HTML dokumenty do prezentací PowerPoint a OpenDocument v C++ pomocí Aspose.Slides pro plynulé, vysoce výkonné zpracování snímků."
---
## **Úvod**

Pomocí [**Aspose.Slides for C++**](https://products.aspose.com/slides/cs/cpp/), můžete importovat prezentace ze souborů v jiných formátech. Aspose.Slides poskytuje třídu [SlideCollection](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.slide_collection), která umožňuje importovat prezentace z PDF, HTML dokumentů atd.

## **Import PowerPointu z PDF**

V tomto případě můžete převést PDF do prezentace PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Vytvořte instanci třídy Presentation.  
2. Zavolejte metodu [AddFromPdf()](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.slide_collection#a966c00d26b741a6c56e424d2f0d689a5) a předávejte PDF soubor.  
3. Použijte metodu [Save()](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) pro uložení souboru ve formátu PowerPoint.

Tento C++ kód demonstruje operaci převodu PDF do PowerPointu:

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
    
pres->get_Slides()->AddFromPdf(u"InputPDF.pdf");
pres->Save(u"OutputPresentation.pptx", SaveFormat::Pptx);
```

{{% alert  title="Tip" color="info" %}} 
Možná budete chtít vyzkoušet **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/cs/import/pdf-to-powerpoint) webovou aplikaci, protože se jedná o živou implementaci zde popsaného postupu. 
{{% /alert %}} 

## **Import PowerPointu z HTML**

V tomto případě můžete převést HTML dokument do prezentace PowerPoint.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation/).  
2. Zavolejte metodu [AddFromHtml()](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.slide_collection#ad4337f6be235c230d5d422a6799ef965) a předávejte HTML soubor.  
3. Použijte metodu [Save()](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) pro uložení souboru ve formátu PowerPoint.

Tento C++ kód demonstruje operaci převodu HTML do PowerPointu:

```c++
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = System::MakeObject<Presentation>();

{
    auto htmlStream = System::IO::File::OpenRead(u"page.html");
    presentation->get_Slides()->AddFromHtml(htmlStream);
}

presentation->Save(u"MyPresentation.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 
Můžete také použít Aspose.Slides k převodu HTML do dalších oblíbených formátů souborů: 

* [HTML to image](https://products.aspose.com/slides/cs/cpp/conversion/html-to-image/)
* [HTML to JPG](https://products.aspose.com/slides/cs/cpp/conversion/html-to-jpg/)
* [HTML to XML](https://products.aspose.com/slides/cs/cpp/conversion/html-to-xml/)
* [HTML to TIFF](https://products.aspose.com/slides/cs/cpp/conversion/html-to-tiff/)

{{% /alert %}}

## **FAQ**

### Jsou tabulky zachovány při importu PDF a lze zlepšit jejich detekci?

Tabulky mohou být během importu detekovány; [PdfImportOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.import/pdfimportoptions/) obsahuje metodu [set_DetectTables](https://reference.aspose.com/slides/cs/cpp/aspose.slides.import/pdfimportoptions/set_detecttables/) umožňující rozpoznání tabulek. Účinnost závisí na struktuře PDF.