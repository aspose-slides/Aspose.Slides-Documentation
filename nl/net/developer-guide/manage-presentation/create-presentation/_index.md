---
title: Presentaties maken in .NET
linktitle: Presentatie maken
type: docs
weight: 10
url: /nl/net/create-presentation/
keywords:
- presentatie maken
- nieuwe presentatie
- PPT maken
- nieuwe PPT
- PPTX maken
- nieuwe PPTX
- ODP maken
- nieuwe ODP
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Maak presentaties in .NET met Aspose.Slides — genereer PPT-, PPTX- en ODP-bestanden, profiteer van OpenDocument-ondersteuning, en sla ze programmatisch op voor betrouwbare resultaten."
---
## **Overzicht**

Dit artikel laat zien hoe u een presentatie maakt in Aspose.Slides, een tekstvak toevoegt aan de eerste dia, en het resultaat opslaat als een bestand. Het laat ook zien hoe u een lege presentatie maakt en opslaat, en hoe u een bestaande presentatie in een ondersteund formaat opent en opslaat in een ander formaat. Een korte FAQ aan het eind behandelt veelgestelde vragen over formaten, sjablonen, dia‑afmetingen, eenheden, geheugengebruik, threading, licenties, digitale handtekeningen en VBA‑ondersteuning.

Voordat u begint, voegt u Aspose.Slides toe aan uw project via NuGet. Zie [Installation](/slides/nl/net/installation/) voor het pakket dat u kunt gebruiken op Windows, Linux en macOS.

## **Een PowerPoint‑presentatie maken**

Om een presentatie te maken en een tekstvak op de eerste dia te plaatsen, volgt u deze stappen:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/). Een nieuwe presentatie bevat reeds één lege dia.  
2. Haal die dia op uit de [Slides](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/slides/nl/) collectie via de index 0.  
3. Voeg een rechthoek toe met de methode [AddAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/ishapecollection/addautoshape/) en stel de [text](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/text/) in.  
4. Sla de presentatie op als een PPTX‑bestand met de [Save](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/save/) methode.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);
```

De linkerbovenhoek van de rechthoek bevindt zich 50 punten vanaf de linkerrand en 50 punten vanaf de bovenzijde van de dia, en de rechthoek is 400 punten breed en 100 punten hoog. Het opgeslagen bestand bevat één dia met die rechthoek en de tekst ervan. Zonder licentie voegt Aspose.Slides ook een evaluatiewatermerk toe aan elke dia die wordt opgeslagen; zie [Licensing](/slides/nl/net/licensing/).

## **Een presentatie maken en opslaan**

<a name="csharp-create-save-presentation"></a>

Om een lege presentatie te maken en op te slaan, maakt u een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) en slaat u deze op in een willekeurig formaat van de enumeratie [SaveFormat](https://reference.aspose.com/slides/nl/net/aspose.slides.export/saveformat/). Het resultaat is een presentatie met één lege dia.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.Save("OutputPresentation.pptx", SaveFormat.Pptx);
```

## **Een presentatie openen en opslaan**

<a name="csharp-open-save-presentation"></a>

Om een presentatie van het ene formaat naar het andere te converteren, opent u deze door het pad door te geven aan de constructor van [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/presentation/). Sla vervolgens op in het doelformaat. Aspose.Slides detecteert het invoerformaat, zoals PPT, PPTX of ODP, op basis van het bestand zelf.

Het onderstaande voorbeeld verwacht een OpenDocument‑presentatie met de naam *Sample.odp* in de werkmap en slaat deze op als PPTX.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.odp");
presentation.Save("OutputPresentation.pptx", SaveFormat.Pptx);
```

## **FAQ**

### In welke formaten kan ik een nieuwe presentatie opslaan?

U kunt opslaan naar [PPTX, PPT en ODP](/slides/nl/net/save-presentation/), en exporteren naar [PDF](/slides/nl/net/convert-powerpoint-to-pdf/), [XPS](/slides/nl/net/convert-powerpoint-to-xps/), [HTML](/slides/nl/net/convert-powerpoint-to-html/), [SVG](/slides/nl/net/render-a-slide-as-an-svg-image/) en [afbeeldingen](/slides/nl/net/convert-powerpoint-to-png/), onder andere.

### Kan ik starten vanaf een sjabloon (POTX/POTM) en opslaan als een gewone PPTX?

Ja. Laad het sjabloon en sla op in het gewenste formaat; POTX/POTM/PPTM en soortgelijke formaten [are supported](/slides/nl/net/supported-file-formats/).

### Hoe beheer ik de dia‑grootte / beeldverhouding bij het maken van een presentatie?

Stel de [slide size](/slides/nl/net/slide-size/) in (inclusief presets zoals 4:3 en 16:9 of aangepaste afmetingen) en bepaal hoe de inhoud moet worden geschaald.

### In welke eenheden worden afmetingen en coördinaten gemeten?

In punten: 1 inch is gelijk aan 72 eenheden.

### Hoe ga ik om met zeer grote presentaties (met veel mediabestanden) om het geheugengebruik te verminderen?

Gebruik [BLOB management strategies](/slides/nl/net/manage-blob/), beperk het in‑memory opslaggebruik door tijdelijke bestanden te benutten, en geef de voorkeur aan bestands‑gebaseerde workflows boven uitsluitend in‑memory streams.

### Kan ik presentaties parallel maken/opslaan?

U kunt niet dezelfde [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) instantie bedienen vanaf [multiple threads](/slides/nl/net/multithreading/). Gebruik afzonderlijke, geïsoleerde instanties per thread of proces.

### Hoe verwijder ik het proef‑watermerk en de beperkingen?

[Apply a license](/slides/nl/net/licensing/) eenmaal per proces. Het licentie‑XML‑bestand moet ongewijzigd blijven, en de licentie‑configuratie moet gesynchroniseerd worden als meerdere threads betrokken zijn.

### Kan ik de PPTX die ik maak digitaal ondertekenen?

Ja. [Digital signatures](/slides/nl/net/digital-signature-in-powerpoint/) (toevoegen en verifiëren) worden ondersteund voor presentaties.

### Worden macro’s (VBA) ondersteund in aangemaakte presentaties?

Ja. U kunt [create/edit VBA projects](/slides/nl/net/presentation-via-vba/) en macro‑enabled bestanden opslaan zoals PPTM/PPSM.