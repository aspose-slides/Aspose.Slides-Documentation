---
title: Presentaties maken in Python
linktitle: Presentatie maken
type: docs
weight: 10
url: /nl/python-net/create-presentation/
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
- Python
- Aspose.Slides
description: "Maak PowerPoint-presentaties in Python met Aspose.Slides—maak PPT-, PPTX- en ODP-bestanden, profiteer van OpenDocument-ondersteuning en sla ze programmeermatig op voor betrouwbare resultaten."
---
## **Overzicht**

Aspose.Slides for Python stelt u in staat om geheel in code een gloednieuwe presentatiedatei te maken. Dit artikel toont de basiswerkstroom — het aanmaken van een [Presentatie](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑object, het ophalen van de eerste dia, het invoegen van een eenvoudige vorm, en het opslaan van het resultaat — zodat u kunt zien hoe weinig configuratie nodig is om een presentatie te genereren zonder Microsoft Office. Omdat dezelfde API PPT-, PPTX- en ODP‑bestanden kan schrijven, kunt u zowel traditionele PowerPoint‑ als OpenDocument‑formaten targetten vanuit één code‑basis. Aspose.Slides is geschikt voor desktop‑, web‑ of serveromgevingen, waardoor uw Python‑applicatie een efficiënte basis krijgt voor het toevoegen van rijkere inhoud zoals tekst, afbeeldingen of grafieken zodra de eerste diareeks klaar is.

## **Een presentatie maken**

Een PowerPoint‑bestand vanaf nul maken in Aspose.Slides for Python is zo eenvoudig als een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse te creëren. De constructor levert automatisch een lege set met één dia, zodat u direct een canvas heeft voor vormen, tekst, grafieken of andere inhoud die uw applicatie nodig heeft. Zodra u die dia wijzigt — of nieuwe toevoegt — kunt u het resultaat opslaan als PPTX, legacy PPT of zelfs OpenDocument‑formaten. Het korte code‑voorbeeld hieronder illustreert deze werkstroom door een eenvoudige vorm op de eerste dia te plaatsen.

1. Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse.
1. Haal een referentie op naar de dia op basis van zijn index.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/)‑object van het type `CLOUD` toe met de `add_auto_shape`‑methode van de `shapes`‑collectie.
1. Voeg tekst toe aan de auto‑shape.
1. Sla de aangepaste presentatie op als een PPTX‑bestand.

In het onderstaande voorbeeld wordt een wolkvorm toegevoegd aan de eerste dia van de presentatie.

```py
import aspose.slides as slides

# Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
with slides.Presentation() as presentation:
    # Haal de eerste dia op.
    slide = presentation.slides[0]

    # Voeg een auto-shape van het type CLOUD toe.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # Sla de presentatie op als een PPTX-bestand.
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De nieuwe presentatie](new_presentation.png)

## **Veelgestelde vragen**

**In welke formaten kan ik een nieuwe presentatie opslaan?**

U kunt opslaan naar [PPTX, PPT en ODP](/slides/nl/python-net/save-presentation/), en exporteren naar [PDF](/slides/nl/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/nl/python-net/convert-powerpoint-to-xps/), [HTML](/slides/nl/python-net/convert-powerpoint-to-html/), [SVG](/slides/nl/python-net/convert-powerpoint-to-png/) en [afbeeldingen](/slides/nl/python-net/convert-powerpoint-to-png/), onder andere.

**Kan ik starten vanuit een sjabloon (POTX/POTM) en opslaan als een gewone PPTX?**

Ja. Laad het sjabloon en sla op in het gewenste formaat; POTX/POTM/PPTM en vergelijkbare formaten [worden ondersteund](/slides/nl/python-net/supported-file-formats/).

**Hoe beheer ik de dia‑grootte/beeldverhouding bij het maken van een presentatie?**

Stel de [dia‑grootte](/slides/nl/python-net/slide-size/) in (waaronder presets zoals 4:3 en 16:9 of aangepaste afmetingen) en kies hoe de inhoud moet schalen.

**In welke eenheden worden afmetingen en coördinaten gemeten?**

In punten: 1 inch is gelijk aan 72 eenheden.

**Hoe ga ik om met zeer grote presentaties (met veel mediabestanden) om het geheugengebruik te beperken?**

Gebruik [BLOB‑beheersstrategieën](/slides/nl/python-net/manage-blob/), beperk het in‑memory opslaan door tijdelijke bestanden te benutten, en geef de voorkeur aan werkstromen op basis van bestanden boven puur in‑memory streams.

**Kan ik presentaties parallel aanmaken/opslaan?**

U kunt niet tegelijk op dezelfde [Presentatie](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑instantie werken vanuit [meerdere threads](/slides/nl/python-net/multithreading/). Gebruik afzonderlijke, geïsoleerde instanties per thread of proces.

**Hoe verwijder ik de proefversie‑watermerk en beperkingen?**

[Pas een licentie toe](/slides/nl/python-net/licensing/) één keer per proces. Het licentie‑XML‑bestand moet ongewijzigd blijven, en de licentie‑initialisatie moet gesynchroniseerd worden als er meerdere threads actief zijn.

**Kan ik de gegenereerde PPTX digitaal ondertekenen?**

Ja. [Digitale handtekeningen](/slides/nl/python-net/digital-signature-in-powerpoint/) (toevoegen en verifiëren) worden ondersteund voor presentaties.

**Worden macro's (VBA) ondersteund in aangemaakte presentaties?**

Ja. U kunt [VBA‑projecten maken/bewerken](/slides/nl/python-net/presentation-via-vba/) en macro‑ingeschakelde bestanden opslaan, zoals PPTM/PPSM.