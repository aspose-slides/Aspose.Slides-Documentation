---
title: Haal alinea‑grenzen op uit presentaties in C++
linktitle: Alinea‑grenzen
type: docs
weight: 43
url: /nl/cpp/paragraph-bounds/
keywords:
- alinea‑grenzen
- alinea‑coördinaat
- alinea‑grootte
- tekstkader
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Leer hoe u alinea‑grenzen kunt ophalen in Aspose.Slides voor C++ om de tekstplaatsing in PowerPoint‑presentaties te optimaliseren."
---
## **Overzicht**

Dit artikel legt uit hoe u de grenzen, grootte en coördinaten van alinea's in Aspose.Slides kunt verkrijgen. Het laat zien hoe u een alinea‑rechthoek kunt ophalen uit een [ITextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/) door [IParagraph::GetRect](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraph/getrect/) te gebruiken, hoe u alinea‑coördinaten binnen een tekstkader van een tabelcel kunt krijgen, en belicht belangrijke details zoals meeteenheden, het effect van tekstomloop op de grenzen, conversie naar pixels en effectieve alinea‑opmaakwaarden.

## **Rechthoekige coördinaten van een alinea ophalen**

Gebruik [IParagraph::GetRect](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraph/getrect/) om de begrenzende rechthoek van een alinea te krijgen.

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
auto rectangle = paragraph->GetRect();

presentation->Dispose();
```

## **De grootte van een alinea binnen een tekstkader van een tabelcel ophalen**

Om de grootte en coördinaten van een [IParagraph](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraph/) in een tekstkader van een tabelcel te verkrijgen, gebruikt u [IParagraph::GetRect](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraph/getrect/). De geretourneerde rechthoek is relatief ten opzichte van het tekstkader van de tabelcel, dus voeg de tabelpositie en celoffset toe wanneer u coördinaten op slide‑niveau nodig heeft.

Het volgende voorbeeld haalt de alinea‑grenzen binnen een tabelcel op en tekent rechthoeken op de slide om die grenzen te visualiseren:

```cpp
auto presentation = System::MakeObject<Presentation>(u"source.pptx");
auto slide = presentation->get_Slide(0);
auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));
auto cell = table->get_Row(1)->idx_get(1);

auto cellX = table->get_X() + cell->get_OffsetX();
auto cellY = table->get_Y() + cell->get_OffsetY();
auto paragraphs = cell->get_TextFrame()->get_Paragraphs();

for (const auto& paragraph : paragraphs)
{
    if (paragraph->get_Text().IsEmpty())
    {
        continue;
    }

    auto paragraphRectangle = paragraph->GetRect();
    auto paragraphRectangleX = paragraphRectangle.get_X() + cellX;
    auto paragraphRectangleY = paragraphRectangle.get_Y() + cellY;

    auto paragraphBoundsShape = slide->get_Shapes()->AddAutoShape(
        ShapeType::Rectangle,
        paragraphRectangleX,
        paragraphRectangleY,
        paragraphRectangle.get_Width(),
        paragraphRectangle.get_Height());

    paragraphBoundsShape->get_FillFormat()->set_FillType(FillType::NoFill);
    paragraphBoundsShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Yellow());
    paragraphBoundsShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**In welke eenheden worden alinea‑coördinaten gemeten?**

Ze worden gemeten in points, waarbij 1 inch gelijk is aan 72 points. Dit geldt voor alle coördinaten en afmetingen op de slide.

**Heeft woordomloop invloed op de grenzen van een alinea?**

Ja. Als [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframeformat/set_wraptext/) is ingeschakeld voor de [ITextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/), wordt de tekst afgebroken zodat deze past binnen de breedte van het gebied, waardoor de daadwerkelijke grenzen van de alinea veranderen.

**Kunnen alinea‑coördinaten betrouwbaar worden omgezet naar pixels in de geëxporteerde afbeelding?**

Ja. Converteer points naar pixels met de formule: pixels = points x (DPI / 72). Het resultaat hangt af van de DPI die gekozen is voor renderen of exporteren.

**Hoe krijg ik de “effectieve” alinea‑opmaakparameters, rekening houdend met erfelijkheid van stijlen?**

Gebruik de [effective paragraph formatting data structure](/slides/nl/cpp/shape-effective-properties/); deze geeft de uiteindelijke geconsolideerde waarden terug voor inspringingen, regelafstand, omloop, RTL en meer.