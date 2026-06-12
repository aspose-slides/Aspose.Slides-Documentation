---
title: Presentaties maken op Android
linktitle: Presentatie maken
type: docs
weight: 10
url: /nl/androidjava/create-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Maak presentaties in Java met Aspose.Slides voor Android—produceer PPT-, PPTX- en ODP-bestanden, profiteer van OpenDocument-ondersteuning en sla ze programmatisch op voor betrouwbare resultaten."
---
## **Overzicht**

Dit artikel laat zien hoe je een presentatie maakt met Aspose.Slides, eenvoudige inhoud aan een dia toevoegt en het resultaat opslaat als bestand. Het toont ook hoe je een nieuwe presentatie maakt en opslaat, een bestaande presentatie opent in een ondersteund formaat, en deze naar een ander formaat opslaat.

## **Maak een PowerPoint‑presentatie**
Om een eenvoudige rechte lijn aan een geselecteerde dia van de presentatie toe te voegen, volg je de onderstaande stappen:

1. Maak een instantie van de `Presentation`‑klasse.
1. Haal de referentie van een dia op door zijn index te gebruiken.
1. Voeg een AutoShape van het type Lijn toe met de `addAutoShape`‑methode van het `Shapes`‑object.
1. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

In het onderstaande voorbeeld hebben we een lijn toegevoegd aan de eerste dia van de presentatie.

```java
// Instantieer een Presentation-object dat een presentatiebestand vertegenwoordigt
Presentation pres = new Presentation();
try {
    // Haal de eerste dia op
    ISlide slide = pres.getSlides().get_Item(0);

    // Voeg een autoshape van het type lijn toe
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    pres.save("NewPresentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Welke formaten kan ik gebruiken om een nieuwe presentatie op te slaan?**

Je kunt opslaan als [PPTX, PPT en ODP](/slides/nl/androidjava/save-presentation/), en exporteren naar [PDF](/slides/nl/androidjava/convert-powerpoint-to-pdf/), [XPS](/slides/nl/androidjava/convert-powerpoint-to-xps/), [HTML](/slides/nl/androidjava/convert-powerpoint-to-html/), [SVG](/slides/nl/androidjava/convert-powerpoint-to-png/) en [afbeeldingen](/slides/nl/androidjava/convert-powerpoint-to-png/), onder andere.

**Kan ik starten vanaf een sjabloon (POTX/POTM) en opslaan als een gewone PPTX?**

Ja. Laad het sjabloon en sla op in het gewenste formaat; POTX/POTM/PPTM en soortgelijke formaten [worden ondersteund](/slides/nl/androidjava/supported-file-formats/).

**Hoe beheer ik de dia‑grootte/beeldverhouding bij het maken van een presentatie?**

Stel de [dia‑grootte](/slides/nl/androidjava/slide-size/) in (inclusief presets zoals 4:3 en 16:9 of aangepaste afmetingen) en kies hoe de inhoud moet schalen.

**In welke eenheden worden afmetingen en coördinaten gemeten?**

In punten: 1 inch equals 72 eenheden.

**Hoe ga ik om met zeer grote presentaties (met veel mediabestanden) om het geheugenverbruik te verminderen?**

Gebruik [BLOB‑beheersstrategieën](/slides/nl/androidjava/manage-blob/), beperk opslag in het geheugen door tijdelijke bestanden te gebruiken, en geef de voorkeur aan bestandsgebaseerde workflows boven zuiver in‑memory streams.

**Kan ik presentaties parallel maken/opslaan?**

Je kunt niet dezelfde [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑instantie vanuit [meerdere threads](/slides/nl/androidjava/multithreading/) bedienen. Start afzonderlijke, geïsoleerde instanties per thread of proces.

**Hoe verwijder ik het trial‑watermerk en de beperkingen?**

[Pas een licentie toe](/slides/nl/androidjava/licensing/) één keer per proces. Het licentie‑XML‑bestand moet ongewijzigd blijven, en de licentie‑initialisatie moet gesynchroniseerd worden als er meerdere threads betrokken zijn.

**Kan ik de PPTX die ik maak digitaal ondertekenen?**

Ja. [Digitale handtekeningen](/slides/nl/androidjava/digital-signature-in-powerpoint/) (toevoegen en verifiëren) worden ondersteund voor presentaties.

**Worden macro’s (VBA) ondersteund in gemaakte presentaties?**

Ja. Je kunt [VBA‑projecten maken/bewerken](/slides/nl/androidjava/presentation-via-vba/) en macro‑ingeschakelde bestanden opslaan, zoals PPTM/PPSM.