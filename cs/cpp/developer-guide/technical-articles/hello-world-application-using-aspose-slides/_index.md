---
title: Aplikace Hello World používající Aspose.Slides pro C++
type: docs
weight: 80
url: /cs/cpp/hello-world-application-using-aspose-slides/
keywords:
- ahoj svět
- aplikace
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Vytvořte svou první C++ aplikaci s Aspose.Slides, jednoduchý příklad Hello World, který vás připraví na automatizaci prezentací PPT, PPTX a ODP."
---
## **Přehled**

Tento článek ukazuje, jak vytvořit jednoduchou prezentaci PowerPoint **Hello World** pomocí Aspose.Slides. Příklad demonstruje, jak vytvořit novou prezentaci, získat první snímek, přidat obdélníkový AutoShape na určenou pozici, vložit textový rámec obsahující text **Hello World** a upravit formátování tvaru a textu.

Také vysvětluje, jak učinit text viditelným změnou jeho barvy na černou, skrýt okraj tvaru nastavením barvy čáry na bílou, odstranit výplň tvaru a uložit prezentaci jako soubor PPTX.

## **Kroky pro vytvoření aplikace Hello World**

Postupujte podle níže uvedených kroků pro vytvoření aplikace **Hello World** pomocí API Aspose.Slides pro C++:

- Vytvořte instanci třídy Presentation
- Získejte odkaz na první snímek v prezentaci, která je vytvořena při instanciaci třídy Presentation.
- Přidejte AutoShape typu Rectangle na určenou pozici snímku.
- Přidejte TextFrame do AutoShape, který obsahuje Hello World jako výchozí text.
- Změňte barvu textu na černou, protože je ve výchozím nastavení bílá a na snímku s bílým pozadím není viditelná.
- Změňte barvu čáry tvaru na bílou, aby byl okraj tvaru skryt.
- Odstraňte výchozí formát výplně tvaru.
- Nakonec uložte prezentaci do požadovaného formátu souboru pomocí objektu Presentation

Implementace výše uvedených kroků je ukázána níže v příkladu.

``` cpp
#include <DOM/Presentation.h>
#include <DOM/SlideCollection.h>
#include <DOM/Slide.h>
#include <DOM/ShapeCollection.h>
#include <DOM/AutoShape.h>
#include <DOM/Paragraph.h>
#include <DOM/ParagraphCollection.h>
#include <DOM/TextFrame.h>
#include <DOM/PortionCollection.h>
#include <DOM/Portion.h>
#include <DOM/PortionFormat.h>
#include <DOM/ColorFormat.h>
#include <DOM/FillFormat.h>
#include <DOM/ShapeStyle.h>
#include <DOM/ShapeType.h>
#include <DOM/FillType.h>

#include <Export/SaveFormat.h>

#include <drawing/color.h>

using namespace Aspose;
using namespace Slides;
using namespace Export;

using namespace System;

int main(int argc, const char argv[])
{
    auto pres = System::MakeObject<Presentation>();

    // získat první snímek
    auto slide = pres->get_Slides()->idx_get(0);

    // přidat AutoShape typu Obdélník
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

    // přidat TextFrame do obdélníku
    shape->AddTextFrame(u"Hello World");

    // změnit barvu textu na černou (což je ve výchozím nastavení bílá)
    auto portionFillFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_FillFormat();
    portionFillFormat->set_FillType(FillType::Solid);
    portionFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());

    // změnit barvu čáry obdélníku na bílou
    shape->get_ShapeStyle()->get_LineColor()->set_Color(System::Drawing::Color::get_White());

    // odstranit veškeré formátování výplně ve tvaru
    shape->get_FillFormat()->set_FillType(FillType::NoFill);

    // uložit prezentaci na disk
    pres->Save(u"output.pptx", SaveFormat::Pptx);

    return 0;
}
```