---
title: Alinea-grenzen ophalen uit presentaties in C++
linktitle: Alinea
type: docs
weight: 60
url: /nl/cpp/paragraph/
keywords:
- alinea-grenzen
- tekstgedeelte-grenzen
- alinea-coördinaat
- gedeelte-coördinaat
- alinea-grootte
- tekstgedeelte-grootte
- tekstframe
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Leer hoe u alinea- en tekstgedeelte-grenzen kunt ophalen in Aspose.Slides voor C++ om de tekstpositionering in PowerPoint-presentaties te optimaliseren."
---
## **Overzicht**

Dit artikel legt uit hoe u de grenzen, grootte en coördinaten van alinea’s en tekstgedeelten in Aspose.Slides kunt verkrijgen. Het toont hoe u het rechthoekige gebied van een alinea in een `TextFrame` kunt ophalen met `GetRect()`, hoe u de coördinaten van alinea‑ en gedeelte‑elementen binnen een tabelcel‑tekstframe kunt krijgen, en belicht belangrijke details zoals meeteenheden, de invloed van tekstomslag op de grenzen, pixelconversie en effectieve alinea‑opmaakwaarden.

## **Coördinaten van alinea en gedeelte ophalen in een TextFrame**
Met Aspose.Slides for C++ kunnen ontwikkelaars nu de rechthoekige coördinaten van een alinea binnen de alinea‑collectie van een TextFrame verkrijgen. Het maakt ook mogelijk om de coördinaten van een gedeelte binnen de gedeelte‑collectie van een alinea op te halen. In dit onderwerp demonstreren we met een voorbeeld hoe u de rechthoekige coördinaten van een alinea samen met de positie van een gedeelte binnen die alinea kunt verkrijgen.

## **Rechthoekige coördinaten van een alinea ophalen**
De nieuwe methode **GetRect()** is toegevoegd. Hiermee kunt u het rechthoekige gebied van een alinea ophalen.

``` cpp
// Instantieer een Presentation-object dat een presentatie-bestand vertegenwoordigt
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto textFrame = shape->get_TextFrame();
auto rect = textFrame->get_Paragraphs()->idx_get(0)->GetRect();
```

## **De grootte van een alinea en gedeelte binnen een tabelcel‑TextFrame ophalen**

Om de grootte en coördinaten van een [Gedeelte](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.portion) of [Alinea](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.paragraph) in een tabelcel‑tekstframe te verkrijgen, kunt u de methoden [IPortion::GetRect](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_portion#a9e2fd8b58529d493b40835b8463838a9) en [IParagraph::GetRect](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.i_paragraph#a56f6e0026bbb81aa948bb0b000b8cf08t) gebruiken.

Deze voorbeeldcode demonstreert de beschreven bewerking:

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

**In welke eenheden worden de coördinaten voor een alinea en tekstgedeelten geretourneerd?**

In punten, waarbij 1 inch = 72 punten. Dit geldt voor alle coördinaten en afmetingen op de dia.

**Heeft woordomslag invloed op de grenzen van een alinea?**

Ja. Als [wrapping](https://reference.aspose.com/slides/nl/cpp/aspose.slides/textframeformat/set_wraptext/) is ingeschakeld in de [TextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/textframe/), breekt de tekst om binnen de breedte van het gebied, waardoor de werkelijke grenzen van de alinea veranderen.

**Kunnen alinea‑coördinaten betrouwbaar worden omgezet naar pixels in de geëxporteerde afbeelding?**

Ja. Converteer punten naar pixels met: pixels = punten × (DPI / 72). Het resultaat hangt af van de DPI‑waarde die voor het renderen/exporteren is gekozen.

**Hoe krijg ik de “effectieve” alinea‑opmaakparameters, rekening houdend met erfelijke stijlen?**

Gebruik de [effectieve alinea‑opmaak‑databasestructuur](/slides/nl/cpp/shape-effective-properties/); deze geeft de uiteindelijke geconsolideerde waarden voor inspringingen, spatiëring, omslag, RTL en meer.