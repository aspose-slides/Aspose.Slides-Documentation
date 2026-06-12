---
title: Hello World-toepassing met Aspose.Slides voor C++
type: docs
weight: 80
url: /nl/cpp/hello-world-application-using-aspose-slides/
keywords:
- hallo wereld
- toepassing
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Maak uw eerste C++-applicatie met Aspose.Slides, een eenvoudig Hello World-voorbeeld dat u klaarstoomt om PPT-, PPTX- en ODP-presentaties te automatiseren."
---
## **Overzicht**

Dit artikel laat zien hoe je een eenvoudige **Hello World** PowerPoint-presentatie maakt met Aspose.Slides. Het voorbeeld toont hoe je een nieuwe presentatie maakt, de eerste dia opent, een rechthoekige AutoShape op een opgegeven positie toevoegt, een tekstframe met de **Hello World**-tekst invoegt, en de vorm- en tekstopmaak aanpast.

Het legt ook uit hoe je de tekst zichtbaar maakt door de kleur naar zwart te wijzigen, de vormrand verbergt door de lijnkleur wit te maken, de vulling van de vorm verwijdert, en de presentatie opslaat als een PPTX-bestand.

## **Stappen om een Hello World-toepassing te maken**

Volg de onderstaande stappen om een **Hello World**-toepassing te maken met de Aspose.Slides voor C++ API:

- Maak een instantie van de Presentation-klasse
- Verkrijg de referentie van de eerste dia in de presentatie die wordt aangemaakt bij het instantieren van Presentation.
- Voeg een AutoShape met ShapeType Rectangle toe op een opgegeven positie van de dia.
- Voeg een TextFrame toe aan de AutoShape met Hello World als standaardtekst
- Verander de Text Color naar Black omdat deze standaard wit is en niet zichtbaar op een dia met een witte achtergrond
- Verander de Line Color van de vorm naar wit om de vormrand te verbergen
- Verwijder de standaard Fill Format van de vorm
- Schrijf tenslotte de presentatie naar het gewenste bestandsformaat met behulp van het Presentation-object

De implementatie van bovenstaande stappen wordt hieronder in een voorbeeld getoond.

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

    // haal de eerste dia op
    auto slide = pres->get_Slides()->idx_get(0);

    // voeg een AutoShape van het type Rechthoek toe
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

    // voeg TextFrame toe aan de rechthoek
    shape->AddTextFrame(u"Hello World");

    // verander de tekstkleur naar Zwart (standaard is deze Wit)
    auto portionFillFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_FillFormat();
    portionFillFormat->set_FillType(FillType::Solid);
    portionFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());

    // verander de lijnkleur van de rechthoek naar Wit
    shape->get_ShapeStyle()->get_LineColor()->set_Color(System::Drawing::Color::get_White());

    // verwijder eventuele opvulopmaak in de vorm
    shape->get_FillFormat()->set_FillType(FillType::NoFill);

    // sla de presentatie op op schijf
    pres->Save(u"output.pptx", SaveFormat::Pptx);

    return 0;
}
```