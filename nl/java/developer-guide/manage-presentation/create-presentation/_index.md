---
title: Presentaties maken in Java
linktitle: Presentatie maken
type: docs
weight: 10
url: /nl/java/create-presentation/
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
- Java
- Aspose.Slides
description: "Maak presentaties in Java met Aspose.Slides—maak PPT-, PPTX- en ODP-bestanden, profiteer van OpenDocument-ondersteuning en sla ze programmatisch op voor betrouwbare resultaten."
---
## **Overzicht**

Dit artikel toont hoe u een presentatie maakt in Aspose.Slides, eenvoudige inhoud aan een dia toevoegt en het resultaat als bestand opslaat. Het laat ook zien hoe u een nieuwe presentatie maakt en opslaat, een bestaande presentatie opent in een ondersteund formaat, en deze naar een ander formaat opslaat. Daarnaast bevat het artikel een korte FAQ met veelgestelde vragen over formaten, sjablonen, dia‑grootte, eenheden, geheugengebruik, threading, licenties, digitale handtekeningen en VBA‑ondersteuning.

## **Een presentatie maken**

Een PowerPoint‑bestand vanaf nul maken in Aspose.Slides voor Java is net zo eenvoudig als een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) klasse aanmaken. De constructor levert automatisch een lege presentatie met één dia, waardoor u meteen een canvas heeft voor vormen, tekst, grafieken of andere inhoud die uw applicatie nodig heeft. Zodra u die dia aanpast - of nieuwe dia's toevoegt - kunt u het resultaat opslaan als PPTX, legacy PPT of zelfs OpenDocument‑formaten. Het korte code‑voorbeeld hieronder illustreert deze workflow door een eenvoudige vorm toe te voegen aan de eerste dia.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) klasse.
1. Verkrijg een referentie naar de dia op basis van de index.
1. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape/) object van het type `Cloud` toe met behulp van de `addAutoShape`‑methode van de `Shapes`‑collectie.
1. Voeg tekst toe aan de auto‑shape.
1. Sla de aangepaste presentatie op als een PPTX‑bestand.

In het onderstaande voorbeeld wordt een wolkvorm toegevoegd aan de eerste dia van de presentatie.

```java
// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
Presentation presentation = new Presentation();
try {
    // Haal de eerste dia op.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Voeg een auto-shape van het type Cloud toe.
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    // Sla de presentatie op als een PPTX-bestand.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De nieuwe presentatie](new_presentation.png)

## **FAQ**

**In welke formaten kan ik een nieuwe presentatie opslaan?**

U kunt opslaan naar [PPTX, PPT en ODP](/slides/nl/java/save-presentation/), en exporteren naar [PDF](/slides/nl/java/convert-powerpoint-to-pdf/), [XPS](/slides/nl/java/convert-powerpoint-to-xps/), [HTML](/slides/nl/java/convert-powerpoint-to-html/), [SVG](/slides/nl/java/convert-powerpoint-to-png/), en [afbeeldingen](/slides/nl/java/convert-powerpoint-to-png/), onder andere.

**Kan ik beginnen met een sjabloon (POTX/POTM) en opslaan als een gewone PPTX?**

Ja. Laad het sjabloon en sla op in het gewenste formaat; POTX/POTM/PPTM en soortgelijke formaten [worden ondersteund](/slides/nl/java/supported-file-formats/).

**Hoe kan ik de dia‑grootte/beeldverhouding regelen bij het maken van een presentatie?**

Stel de [dia‑grootte](/slides/nl/java/slide-size/) in (inclusief voorgedefinieerde verhoudingen zoals 4:3 en 16:9 of aangepaste afmetingen) en kies hoe de inhoud moet schalen.

**In welke eenheden worden afmetingen en coördinaten gemeten?**

In punten: 1 inch is gelijk aan 72 eenheden.

**Hoe ga ik om met zeer grote presentaties (met veel mediabestanden) om het geheugengebruik te verminderen?**

Gebruik [BLOB‑beheersstrategieën](/slides/nl/java/manage-blob/), beperk in‑memory opslag door tijdelijke bestanden te gebruiken, en geef de voorkeur aan bestands‑gebaseerde workflows boven volledig in‑memory streams.

**Kan ik presentaties gelijktijdig maken/opslaan?**

U kunt niet hetzelfde [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) object gebruiken vanuit [meerdere threads](/slides/nl/java/multithreading/). Gebruik afzonderlijke, geïsoleerde instanties per thread of proces.

**Hoe verwijder ik het proef‑watermerk en de beperkingen?**

[Pas een licentie toe](/slides/nl/java/licensing/) één keer per proces. Het licentie‑XML‑bestand moet ongewijzigd blijven, en de licentie‑configuratie moet gesynchroniseerd worden als er meerdere threads actief zijn.

**Kan ik de PPTX die ik maak digitaal ondertekenen?**

Ja. [Digitale handtekeningen](/slides/nl/java/digital-signature-in-powerpoint/) (toevoegen en verifiëren) worden ondersteund voor presentaties.

**Worden macro's (VBA) ondersteund in gemaakte presentaties?**

Ja. U kunt [VBA‑projecten maken/bewerken](/slides/nl/java/presentation-via-vba/) en macro‑ingeschakelde bestanden opslaan, zoals PPTM/PPSM.