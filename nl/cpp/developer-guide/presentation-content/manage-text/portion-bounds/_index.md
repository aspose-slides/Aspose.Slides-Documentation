---
title: Haal tekstgedeeltegrenzen op uit presentaties in C++
linktitle: Gedeeltegrenzen
type: docs
weight: 47
url: /nl/cpp/portion-bounds/
keywords:
- tekstgedeeltegrenzen
- tekstgedeelte
- tekstdeel
- tekstcoördinaten
- tekstpositie
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Leer hoe u tekstgedeeltegrenzen kunt ophalen in PowerPoint-presentaties met Aspose.Slides voor C++."
---
## **Overzicht**

Een tekstgedeelte vertegenwoordigt een specifiek fragment tekst binnen een alinea en stelt u in staat om met dat fragment onafhankelijk van de omringende inhoud te werken. In Aspose.Slides kunnen gedeelten worden gebruikt wanneer u de grenzen van een tekstfragment moet ophalen, opmaak alleen op een deel van een alinea wilt toepassen, of het tekstgedrag op een gedetailleerder niveau wilt beheersen.

Dit artikel toont hoe u de begrenzende rechthoek van een deel kunt verkrijgen met behulp van [IPortion::GetRect](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iportion/getrect/). Het laat ook zien hoe u de coördinaten van het begin van een deel kunt verkrijgen met behulp van [IPortion::GetCoordinates](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iportion/getcoordinates/). Bovendien belicht het veelvoorkomende scenario's met betrekking tot delen, zoals het toepassen van een hyperlink op een enkel tekstfragment, het begrijpen hoe opmaak wordt opgelost via het deel, de alinea, het tekstframe en de thema‑overerving, en het omgaan met gevallen waarin een opgegeven lettertype niet beschikbaar is.

## **Krijg de grenzen van een tekstgedeelte**

Gebruik [IPortion::GetRect](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iportion/getrect/) om de begrenzende rechthoek van een tekstgedeelte op te halen:

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraphs = shape->get_TextFrame()->get_Paragraphs();

for (const auto& paragraph : paragraphs)
{
    auto portions = paragraph->get_Portions();
    for (const auto& portion : portions)
    {
        auto rectangle = portion->GetRect();
        auto rectangleX = rectangle.get_X();
        auto rectangleY = rectangle.get_Y();
        auto rectangleWidth = rectangle.get_Width();
        auto rectangleHeight = rectangle.get_Height();

        Console::WriteLine(u"X = {0}; Y = {1}; Width = {2}; Height = {3}", rectangleX, rectangleY, rectangleWidth, rectangleHeight);
    }
}

presentation->Dispose();
```

## **Krijg de coördinaten van een tekstgedeelte**

Gebruik [IPortion::GetCoordinates](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iportion/getcoordinates/) om de coördinaten van het begin van een tekstgedeelte op te halen:

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraphs = shape->get_TextFrame()->get_Paragraphs();

for (const auto& paragraph : paragraphs)
{
    auto portions = paragraph->get_Portions();
    for (const auto& portion : portions)
    {
        auto point = portion->GetCoordinates();
        auto pointX = point.get_X();
        auto pointY = point.get_Y();

        Console::WriteLine(u"X = {0}; Y = {1}", pointX, pointY);
    }
}

presentation->Dispose();
```

## **Veelgestelde vragen**

**Kan ik een hyperlink toepassen op slechts een deel van de tekst binnen één alinea?**

Ja, u kunt een [hyperlink toewijzen](/slides/nl/cpp/manage-hyperlinks/) aan een individueel deel; alleen dat fragment is klikbaar, niet de hele alinea.

**Hoe werkt stijl‑overerving: wat overschrijft een deel, en wat wordt overgenomen van een alinea of tekstframe?**

Eigenschappen op het niveau van een deel hebben de hoogste prioriteit. Als een eigenschap niet is ingesteld op de [IPortion](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iportion/), neemt Aspose.Slides deze over van de [IParagraph](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraph/). Als deze daar ook niet is ingesteld, gebruikt Aspose.Slides de stijl van het [ITextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/) of van het [theme](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/theme/) .

**Wat gebeurt er als het opgegeven lettertype voor een deel ontbreekt op de doelmachine of server?**

[Lettertype‑vervangingsregels](/slides/nl/cpp/font-selection-sequence/) worden toegepast. De tekst kan opnieuw worden doorgeflowd: metriek, woordafbreking en breedte kunnen wijzigen, wat van belang is voor precieze positionering.

**Kan ik gedeelte‑specifieke tekstopvulling, transparantie of een gradient instellen onafhankelijk van de rest van de alinea?**

Ja, tekstkleur, opvulling en transparantie op het niveau van de [IPortion](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iportion/) kunnen verschillen van aangrenzende fragmenten.