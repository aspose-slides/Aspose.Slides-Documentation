---
title: Převod prezentací PowerPoint do dokumentů Word v C++
linktitle: PowerPoint do Word
type: docs
weight: 110
url: /cs/cpp/convert-powerpoint-to-word/
keywords:
- převést PowerPoint
- převést prezentaci
- převést snímek
- převést PPT
- převést PPTX
- PowerPoint do Word
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
description: "Převod snímků PowerPoint PPT a PPTX do upravitelných dokumentů Word v C++ pomocí Aspose.Slides s přesným zachováním rozvržení, obrázků a formátování."
---
## **Úvod**

Pokud plánujete používat textový obsah nebo informace z prezentace (PPT nebo PPTX) novými způsoby, může vám prospěšné převést prezentaci do Wordu (DOC nebo DOCX). 

* Ve srovnání s Microsoft PowerPoint je aplikace Microsoft Word lépe vybavena nástroji či funkcemi pro práci s obsahem. 
* Kromě editačních funkcí ve Wordu můžete také těžit z vylepšených možností spolupráce, tisku a sdílení. 

{{% alert color="primary" %}} 

Možná budete chtít vyzkoušet náš [**Presentation to Word Online Converter**](https://products.aspose.app/slides/cs/conversion/ppt-to-word) a zjistit, jaké výhody vám přinese práce s textovým obsahem snímků. 

{{% /alert %}} 

## **Aspose.Slides a Aspose.Words**

Pro převod souboru PowerPoint (PPTX nebo PPT) do Wordu (DOC nebo DOCX) potřebujete jak [Aspose.Slides for C++](https://products.aspose.com/slides/cs/cpp/) tak [Aspose.Words for C++](https://products.aspose.com/words/cpp/).

Jako samostatné API poskytuje [Aspose.Slides](https://products.aspose.app/slides) pro C++ funkce, které vám umožní extrahovat texty z prezentací. 

[Aspose.Words](https://docs.aspose.com/words/cpp/) je pokročilé API pro zpracování dokumentů, které umožňuje aplikacím generovat, upravovat, převádět, vykreslovat, tisknout soubory a provádět další úkoly s dokumenty bez použití Microsoft Word.

## **Převod prezentace PowerPoint do dokumentu Word**

Použijte následující úryvek kódu k převodu PowerPointu do Wordu:

```cpp
auto presentation = MakeObject<Presentation>();
auto doc = MakeObject<Aspose::Words::Document>();
auto builder = MakeObject<Aspose::Words::DocumentBuilder>(doc);

for (const auto& slide : presentation->get_Slides())
{
    // generuje a vloží obrázek snímku
    auto image = slide->GetImage(1.0f, 1.0f);
    builder->InsertImage(image);

    // vkládá texty snímku
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
```

## **FAQ**

**Jaké komponenty je třeba nainstalovat pro převod prezentací PowerPoint a OpenDocument do dokumentů Word?**

Stačí do projektu přidat příslušné balíčky pro [Aspose.Slides for C++](https://releases.aspose.com/slides/cs/cpp/) a [Aspose.Words for C++](https://releases.aspose.com/words/cpp/). Obě knihovny fungují jako samostatná API a není nutné mít nainstalovaný Microsoft Office.

**Jsou podporovány všechny formáty prezentací PowerPoint a OpenDocument?**

Aspose.Slides [supports all presentation formats](/slides/cs/cpp/supported-file-formats/), včetně PPT, PPTX, ODP a dalších běžných typů souborů. To zajišťuje, že můžete pracovat s prezentacemi vytvořenými v různých verzích Microsoft PowerPoint.