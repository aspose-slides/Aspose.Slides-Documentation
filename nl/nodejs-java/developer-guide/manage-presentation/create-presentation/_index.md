---
title: Presentaties maken in JavaScript
linktitle: Presentatie maken
type: docs
weight: 10
url: /nl/nodejs-java/create-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Maak presentaties met Aspose.Slides—maak PPT-, PPTX- en ODP-bestanden, profiteer van OpenDocument-ondersteuning, en sla ze programmatisch op voor betrouwbare resultaten."
---
## **Overzicht**

Dit artikel toont hoe u een presentatie maakt in Aspose.Slides, eenvoudige inhoud aan een dia toevoegt en het resultaat opslaat als een bestand.

## **PowerPoint‑presentatie maken**

Om een eenvoudige rechte lijn toe te voegen aan een geselecteerde dia van de presentatie, volgt u de onderstaande stappen:

1. Maak een instantie van de klasse Presentation.
1. Verkrijg de referentie van een dia via de index.
1. Voeg een AutoShape van het type Lijn toe met de addAutoShape‑methode van het Shapes‑object.
1. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

In het onderstaande voorbeeld hebben we een lijn toegevoegd aan de eerste dia van de presentatie.

```javascript
// Instantiseer een Presentation-object dat een presentatiebestand vertegenwoordigt
var pres = new aspose.slides.Presentation();
try {
    // Haal de eerste dia op
    var slide = pres.getSlides().get_Item(0);
    // Voeg een autoshape van type lijn toe
    slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    pres.save("NewPresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Veelgestelde vragen**

**In welke formaten kan ik een nieuwe presentatie opslaan?**

U kunt opslaan als [PPTX, PPT en ODP](/slides/nl/nodejs-java/save-presentation/), en exporteren naar [PDF](/slides/nl/nodejs-java/convert-powerpoint-to-pdf/), [XPS](/slides/nl/nodejs-java/convert-powerpoint-to-xps/), [HTML](/slides/nl/nodejs-java/convert-powerpoint-to-html/), [SVG](/slides/nl/nodejs-java/convert-powerpoint-to-png/), en [afbeeldingen](/slides/nl/nodejs-java/convert-powerpoint-to-png/), onder andere.

**Kan ik beginnen vanuit een sjabloon (POTX/POTM) en opslaan als een normale PPTX?**

Ja. Laad het sjabloon en sla op in het gewenste formaat; POTX/POTM/PPTM en soortgelijke formaten [worden ondersteund](/slides/nl/nodejs-java/supported-file-formats/).

**Hoe kan ik de dia‑grootte/beeldverhouding regelen bij het maken van een presentatie?**

Stel de [dia‑grootte](/slides/nl/nodejs-java/slide-size/) in (inclusief voorgedefinieerde maten zoals 4:3 en 16:9 of aangepaste afmetingen) en kies hoe de inhoud moet worden geschaald.

**In welke eenheden worden afmetingen en coördinaten gemeten?**

In punten: 1 inch is gelijk aan 72 eenheden.

**Hoe ga ik om met zeer grote presentaties (met veel mediabestanden) om het geheugenverbruik te verminderen?**

Gebruik [BLOB‑beheersstrategieën](/slides/nl/nodejs-java/manage-blob/), beperk het in‑memory geheugen door tijdelijke bestanden te gebruiken, en geef de voorkeur aan bestandsgebaseerde workflows boven uitsluitend in‑memory streams.

**Kan ik presentaties parallel maken/op slaan?**

U kunt niet dezelfde [Presentatie](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) instantie vanuit [meerdere threads](/slides/nl/nodejs-java/multithreading/) bewerken. Start aparte, geïsoleerde instanties per thread of proces.

**Hoe verwijder ik het proefversie‑watermerk en de beperkingen?**

[Pas een licentie toe](/slides/nl/nodejs-java/licensing/) één keer per proces. Het licentie‑XML‑bestand moet ongewijzigd blijven en de licentie‑configuratie moet gesynchroniseerd worden als er meerdere threads actief zijn.

**Kan ik de PPTX die ik maak digitaal ondertekenen?**

Ja. [Digitale handtekeningen](/slides/nl/nodejs-java/digital-signature-in-powerpoint/) (toevoegen en verifiëren) worden ondersteund voor presentaties.

**Worden macro’s (VBA) ondersteund in gemaakte presentaties?**

Ja. U kunt [VBA‑projecten maken/bewerken](/slides/nl/nodejs-java/presentation-via-vba/) en macro‑ingeschakelde bestanden opslaan, zoals PPTM/PPSM.