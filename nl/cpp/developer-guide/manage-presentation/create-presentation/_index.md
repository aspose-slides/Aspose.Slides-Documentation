---
title: Maak presentaties in C++
linktitle: Maak presentatie
type: docs
weight: 10
url: /nl/cpp/create-presentation/
keywords:
- maak presentatie
- nieuwe presentatie
- maak PPT
- nieuwe PPT
- maak PPTX
- nieuwe PPTX
- maak ODP
- nieuwe ODP
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Maak presentaties in C++ met Aspose.Slides—maak PPT, PPTX en ODP‑bestanden, profiteer van OpenDocument‑ondersteuning, en sla ze programmatisch op voor betrouwbare resultaten."
---
## **Overzicht**

Dit artikel laat zien hoe u een presentatie maakt in Aspose.Slides, een tekstvak toevoegt aan de eerste dia, en het resultaat opslaat als een bestand. Een korte FAQ aan het einde behandelt veelgestelde vragen over formaten, sjablonen, dia‑afmetingen, eenheden, geheugenverbruik, threading, licenties, digitale handtekeningen en VBA‑ondersteuning.

Voordat u begint, voegt u Aspose.Slides toe aan uw project: via NuGet in een Visual Studio‑project op Windows, of via het ZIP‑pakket met CMake op Linux. Zie [Installation](/slides/nl/cpp/installation/).

## **Een PowerPoint‑presentatie maken**

Om een presentatie te maken en een tekstvak op de eerste dia te plaatsen, volgt u deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑klasse. Een nieuwe presentatie bevat al één lege dia.
2. Haal die dia op met de [Presentation::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slide/)‑methode en zijn index, 0.
3. Voeg een rechthoek toe met de [IShapeCollection::AddAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addautoshape/)‑methode, en stel de tekst in met de [ITextFrame::set_Text](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/set_text/)‑methode.
4. Sla de presentatie op als een PPTX‑bestand met de [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/)‑methode.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

int main()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    shape->get_TextFrame()->set_Text(u"Hello, Aspose.Slides!");
    presentation->Save(u"hello.pptx", SaveFormat::Pptx);
    presentation->Dispose();
    return 0;
}
```

De linkerbovenhoek van de rechthoek bevindt zich 50 points van de linkerrand en 50 points van de bovenrand van de dia, en de rechthoek is 400 points breed en 100 points hoog. Het programma slaat *hello.pptx* op in de werkmap, met één dia die de rechthoek en de tekst bevat. Zonder licentie voegt Aspose.Slides ook een evaluatiewatermerk toe aan elke dia die het opslaat; zie [Licensing](/slides/nl/cpp/licensing/).

## **FAQ**

### In welke formaten kan ik een nieuwe presentatie opslaan?

U kunt opslaan naar [PPTX, PPT, and ODP](/slides/nl/cpp/save-presentation/), en exporteren naar [PDF](/slides/nl/cpp/convert-powerpoint-to-pdf/), [XPS](/slides/nl/cpp/convert-powerpoint-to-xps/), [HTML](/slides/nl/cpp/convert-powerpoint-to-html/), [SVG](/slides/nl/cpp/render-a-slide-as-an-svg-image/) en [images](/slides/nl/cpp/convert-powerpoint-to-png/), onder andere.

### Kan ik starten vanaf een sjabloon (POTX/POTM) en opslaan als een gewone PPTX?

Ja. Laad het sjabloon en sla op in het gewenste formaat; POTX/POTM/PPTM en soortgelijke formaten [are supported](/slides/nl/cpp/supported-file-formats/).

### Hoe kan ik de dia‑grootte / beeldverhouding regelen bij het maken van een presentatie?

Stel de [slide size](/slides/nl/cpp/slide-size/) in (inclusief presets zoals 4:3 en 16:9 of aangepaste afmetingen) en kies hoe de inhoud moet worden geschaald.

### In welke eenheden worden afmetingen en coördinaten gemeten?

In points: 1 inch is gelijk aan 72 eenheden.

### Hoe ga ik om met zeer grote presentaties (met veel mediabestanden) om het geheugenverbruik te verminderen?

Gebruik [BLOB management strategies](/slides/nl/cpp/manage-blob/), beperk de opslag in het geheugen door tijdelijke bestanden te benutten, en geef de voorkeur aan bestandsgebaseerde workflows boven uitsluitend in‑memory streams.

### Kan ik presentaties parallel maken/opslaan?

U kunt niet dezelfde [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑instantie gebruiken vanuit [multiple threads](/slides/nl/cpp/multithreading/). Gebruik aparte, geïsoleerde instanties per thread of proces.

### Hoe verwijder ik het proefwatermerk en de beperkingen?

[Apply a license](/slides/nl/cpp/licensing/) één keer per proces. Het XML‑licentiebestand moet onveranderd blijven, en de licentie‑configuratie moet gesynchroniseerd worden als er meerdere threads betrokken zijn.

### Kan ik de PPTX die ik maak digitaal ondertekenen?

Ja. [Digital signatures](/slides/nl/cpp/digital-signature-in-powerpoint/) (toevoegen en verifiëren) worden ondersteund voor presentaties.

### Worden macro's (VBA) ondersteund in aangemaakte presentaties?

Ja. U kunt [create/edit VBA projects](/slides/nl/cpp/presentation-via-vba/) en macro‑enabled bestanden opslaan zoals PPTM/PPSM.