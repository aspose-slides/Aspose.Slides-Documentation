---
title: Převod prezentací PowerPoint do dokumentů Word v C++
linktitle: PowerPoint do Wordu
type: docs
weight: 110
url: /cs/cpp/convert-powerpoint-to-word/
keywords:
- převést PowerPoint
- převést prezentaci
- převést snímek
- převést PPT
- převést PPTX
- PowerPoint do Wordu
- prezentace do Wordu
- snímek do Wordu
- PPT do Wordu
- PPTX do Wordu
- PowerPoint do DOCX
- prezentace do DOCX
- snímek do DOCX
- PPT do DOCX
- PPTX do DOCX
- PowerPoint do DOC
- prezentace do DOC
- snímek do DOC
- PPT do DOC
- PPTX do DOC
- uložit PPT jako DOCX
- uložit PPTX jako DOCX
- exportovat PPT do DOCX
- exportovat PPTX do DOCX
- C++
- Aspose.Slides
description: "Převod snímků PowerPoint PPT a PPTX do editovatelných dokumentů Word v C++ pomocí Aspose.Slides se zachováním přesného rozvržení, obrázků a formátování."
---
## **Úvod**

Pokud plánujete využít textový obsah nebo informace z prezentace (PPT nebo PPTX) novými způsoby, může vám pomoci převod prezentace do Wordu (DOC nebo DOCX).

* Ve srovnání s Microsoft PowerPoint má aplikace Microsoft Word více vybavených nástrojů nebo funkcí pro práci s obsahem. 
* Kromě editačních funkcí ve Wordu můžete také využít rozšířené funkce spolupráce, tisku a sdílení. 

{{% alert color="info" %}} 

Možná budete chtít vyzkoušet náš [**Online převodník Prezentace do Wordu**](https://products.aspose.app/slides/cs/conversion/ppt-to-word), abyste zjistili, jaké výhody vám může přinést práce s textovým obsahem snímků. 

{{% /alert %}} 

## **Aspose.Slides a Aspose.Words**

Pro převod souboru PowerPoint (PPTX nebo PPT) do Wordu (DOCX nebo DOCX) potřebujete jak [Aspose.Slides for C++](https://products.aspose.com/slides/cs/cpp/), tak i [Aspose.Words for C++](https://products.aspose.com/words/cpp/).

Jako samostatné API poskytuje [Aspose.Slides](https://products.aspose.app/slides) pro C++ funkce, které vám umožní extrahovat texty z prezentací. 

[Aspose.Words](https://docs.aspose.com/words/cpp/) je pokročilé API pro zpracování dokumentů, které umožňuje aplikacím generovat, upravovat, převádět, vykreslovat, tisknout soubory a provádět další úkoly s dokumenty bez využití Microsoft Word.

## **Převod prezentace PowerPoint do dokumentu Word**

Použijte tento úryvek kódu k převodu PowerPointu do Wordu:

```cpp
#include <Aspose.Words.Cpp/BreakType.h>
#include <Aspose.Words.Cpp/Document.h>
#include <Aspose.Words.Cpp/DocumentBuilder.h>
#include <DOM/AutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto doc = MakeObject<Aspose::Words::Document>();
auto builder = MakeObject<Aspose::Words::DocumentBuilder>(doc);

for (const auto& slide : presentation->get_Slides())
{
    // generuje obrázek snímku jako proud bajtů
    auto image = slide->GetImage(1.0f, 1.0f);
    auto imageStream = MakeObject<System::IO::MemoryStream>();
    image->Save(imageStream, Aspose::Slides::ImageFormat::Png);
    image->Dispose();

    builder->InsertImage(imageStream->ToArray());

    // vloží texty snímku
    for (const auto& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<AutoShape>(shape))
        {
            auto autoShape = System::AsCast<AutoShape>(shape);
            builder->Writeln(autoShape->get_TextFrame()->get_Text());
        }
    }

    builder->InsertBreak(Aspose::Words::BreakType::PageBreak);
}

doc->Save(u"output.docx");
presentation->Dispose();
```

## **Často kladené otázky**

### Jaké komponenty je potřeba nainstalovat pro převod prezentací PowerPoint a OpenDocument do dokumentů Word?

Stačí do svého projektu přidat příslušné balíčky pro [Aspose.Slides for C++](https://releases.aspose.com/slides/cs/cpp/) a [Aspose.Words for C++](https://releases.aspose.com/words/cpp/). Obě knihovny fungují jako samostatná API a není nutné mít nainstalovaný Microsoft Office.

### Jsou podporovány všechny formáty prezentací PowerPoint a OpenDocument?

Aspose.Slides [podporuje všechny formáty prezentací](/slides/cs/cpp/supported-file-formats/), včetně PPT, PPTX, ODP a dalších běžných typů souborů. To zajišťuje, že můžete pracovat s prezentacemi vytvořenými v různých verzích Microsoft PowerPoint.