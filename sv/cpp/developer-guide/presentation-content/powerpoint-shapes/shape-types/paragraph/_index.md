---
title: Hämta styckegränser från presentationer i C++
linktitle: Stycke
type: docs
weight: 60
url: /sv/cpp/paragraph/
keywords:
- styckegränser
- textdelgränser
- styckekoordinat
- delkoordinat
- styckestorlek
- textdelstorlek
- textram
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Lär dig hur du hämtar stycke- och textdelgränser i Aspose.Slides för C++ för att optimera textplacering i PowerPoint-presentationer."
---
## **Översikt**

Denna artikel förklarar hur man hämtar gränser, storlek och koordinater för stycken och textdelar i Aspose.Slides. Den visar hur man med `GetRect()` får ett styckes rektangel i ett `TextFrame`, hur man får stycke- och portionskoordinater i en textram i en tabellcell, samt framhäver viktiga detaljer såsom mätenheter, hur radbrytning påverkar gränser, pixelförvandling och effektiva formatvärden för stycken.

## **Hämta stycke- och portionskoordinater i en TextFrame**

Med Aspose.Slides för C++ kan utvecklare nu hämta de rektangulära koordinaterna för ett stycke i styckeskollektionen i ett TextFrame. Det möjliggör också att få koordinaterna för en portion i portionskollektionen för ett stycke. I detta avsnitt demonstrerar vi med ett exempel hur man får de rektangulära koordinaterna för ett stycke samt positionen för en portion i ett stycke.

## **Hämta de rektangulära koordinaterna för ett stycke**

Den nya metoden **GetRect()** har lagts till. Den möjliggör att hämta styckets avgränsningsrektangel.

``` cpp
// Instansiera ett Presentation-objekt som representerar en presentationsfil
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto textFrame = shape->get_TextFrame();
auto rect = textFrame->get_Paragraphs()->idx_get(0)->GetRect();
```

## **Hämta storleken på ett stycke och en portion i en tabellcells TextFrame**

För att hämta storleken och koordinaterna för en [Portion](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.portion) eller ett [Paragraph](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.paragraph) i en tabellcells textram kan du använda metoderna [IPortion::GetRect](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_portion#a9e2fd8b58529d493b40835b8463838a9) och [IParagraph::GetRect](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.i_paragraph#a56f6e0026bbb81aa948bb0b000b8cf08t).

Denna exempelkod demonstrerar den beskrivna operationen:

``` cpp
auto pres = System::MakeObject<Presentation>(u"source.pptx");
auto tbl = System::AsCast<Table>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

auto cell = tbl->get_Rows()->idx_get(1)->idx_get(1);

double x = tbl->get_X() + tbl->get_Rows()->idx_get(1)->idx_get(1)->get_OffsetX();
double y = tbl->get_Y() + tbl->get_Rows()->idx_get(1)->idx_get(1)->get_OffsetY();

for (const auto& para : cell->get_TextFrame()->get_Paragraphs())
{
    if (para->get_Text() == u"")
    {
        continue;
    }

    auto rect = para->GetRect();
    auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, rect.get_X() + x, rect.get_Y() + y, rect.get_Width(), rect.get_Height());

    shape->get_FillFormat()->set_FillType(FillType::NoFill);
    shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);

    for (const auto& portion : para->get_Portions())
    {
        if (portion->get_Text().Contains(u"0"))
        {
            rect = portion->GetRect();
            shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, rect.get_X() + x, rect.get_Y() + y, rect.get_Width(), rect.get_Height());

            shape->get_FillFormat()->set_FillType(FillType::NoFill);
        }
    }
}
```

## **FAQ**

**I vilka enheter returneras koordinaterna för ett stycke och textdelar?**

I punkter, där 1 tum = 72 punkter. Detta gäller för alla koordinater och dimensioner på bilden.

**Påverkar radbrytning ett styckes avgränsningar?**

Ja. Om [wrapping](https://reference.aspose.com/slides/sv/cpp/aspose.slides/textframeformat/set_wraptext/) är aktiverad i [TextFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/textframe/), bryts texten för att passa områdets bredd, vilket ändrar styckets faktiska avgränsningar.

**Kan styckekoordinater tillförlitligt omvandlas till pixlar i den exporterade bilden?**

Ja. Konvertera punkter till pixlar med: pixels = points × (DPI / 72). Resultatet beror på den DPI som valts för rendering/export.

**Hur hämtar jag de "effektiva" styckeformateringsparametrarna med hänsyn till ärvda stilar?**

Använd [effective paragraph formatting data structure](/slides/sv/cpp/shape-effective-properties/); den returnerar de slutgiltiga konsoliderade värdena för indrag, avstånd, radbrytning, RTL och mer.