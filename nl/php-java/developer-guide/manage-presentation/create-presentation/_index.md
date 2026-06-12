---
title: Presentaties maken in PHP
linktitle: Presentatie maken
type: docs
weight: 10
url: /nl/php-java/create-presentation/
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
- PHP
- Aspose.Slides
description: "Maak presentaties met Aspose.Slides voor PHP via Java — produceer PPT-, PPTX- en ODP-bestanden en sla ze programmatisch op voor betrouwbare resultaten."
---
## **Overzicht**

Dit artikel laat zien hoe u een presentatie maakt in Aspose.Slides, eenvoudige inhoud aan een dia toevoegt en het resultaat opslaat als een bestand. Het laat ook zien hoe u een nieuwe presentatie maakt en opslaat, een bestaande presentatie in een ondersteund formaat opent en deze naar een ander formaat opslaat. Daarnaast bevat het artikel een korte FAQ met veelgestelde vragen over formaten, sjablonen, dia‑grootte, eenheden, geheugengebruik, meerthreading, licenties, digitale handtekeningen en VBA‑ondersteuning.

## **Presentatie maken**

Om een eenvoudige rechte lijn toe te voegen aan een geselecteerde dia van de presentatie, volgt u de onderstaande stappen:

1. Maak een instantie van de klasse Presentation.
2. Haal de referentie van een dia op met behulp van de Index.
3. Voeg een AutoShape van het type Lijn toe met de addAutoShape‑methode die door het Shapes‑object wordt aangeboden.
4. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

In het onderstaande voorbeeld hebben we een lijn toegevoegd aan de eerste dia van de presentatie.

```php
  # Instantieer een Presentation-object dat een presentatiebestand vertegenwoordigt
  $pres = new Presentation();
  try {
    # Krijg de eerste dia
    $slide = $pres->getSlides()->get_Item(0);
    # Voeg een autoshape van het type lijn toe
    $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    $pres->save("NewPresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**In welke formaten kan ik een nieuwe presentatie opslaan?**

U kunt opslaan als [PPTX, PPT en ODP](/slides/nl/php-java/save-presentation/), en exporteren naar [PDF](/slides/nl/php-java/convert-powerpoint-to-pdf/), [XPS](/slides/nl/php-java/convert-powerpoint-to-xps/), [HTML](/slides/nl/php-java/convert-powerpoint-to-html/), [SVG](/slides/nl/php-java/convert-powerpoint-to-png/), en [afbeeldingen](/slides/nl/php-java/convert-powerpoint-to-png/), onder andere.

**Kan ik starten vanuit een sjabloon (POTX/POTM) en opslaan als een gewone PPTX?**

Ja. Laad het sjabloon en sla op in het gewenste formaat; POTX/POTM/PPTM en vergelijkbare formaten [worden ondersteund](/slides/nl/php-java/supported-file-formats/).

**Hoe stel ik de dia‑grootte/het beeldverhouding in bij het maken van een presentatie?**

Stel de [dia‑grootte](/slides/nl/php-java/slide-size/) in (inclusief voorinstellingen zoals 4:3 en 16:9 of aangepaste afmetingen) en kies hoe de inhoud moet schalen.

**In welke eenheden worden afmetingen en coördinaten gemeten?**

In punten: 1 inch is gelijk aan 72 eenheden.

**Hoe ga ik om met zeer grote presentaties (met veel mediabestanden) om het geheugengebruik te verminderen?**

Gebruik [BLOB‑beheersstrategieën](/slides/nl/php-java/manage-blob/), beperk het gebruik van het geheugen door tijdelijke bestanden te benutten, en geef de voorkeur aan bestandsgebaseerde workflows boven uitsluitend in‑geheugen‑streams.

**Kan ik presentaties parallel maken/opslaan?**

U kunt niet op dezelfde [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑instantie werken vanuit [meerdere threads](/slides/nl/php-java/multithreading/). Gebruik afzonderlijke, geïsoleerde instanties per thread of proces.

**Hoe verwijder ik de proef‑watermerk en beperkingen?**

[Pas een licentie toe](/slides/nl/php-java/licensing/) één keer per proces. Het licentie‑XML‑bestand moet ongewijzigd blijven en de licentie‑configuratie moet worden gesynchroniseerd als er meerdere threads betrokken zijn.

**Kan ik de PPTX die ik maak digitaal ondertekenen?**

Ja. [Digitale handtekeningen](/slides/nl/php-java/digital-signature-in-powerpoint/) (toevoegen en verifiëren) worden ondersteund voor presentaties.

**Worden macro’s (VBA) ondersteund in gemaakte presentaties?**

Ja. U kunt [VBA‑projecten maken/bewerken](/slides/nl/php-java/presentation-via-vba/) en macro‑ingeschakelde bestanden opslaan, zoals PPTM/PPSM.