---
title: Diaformaat wijzigen in presentaties met Python
linktitle: Diaformaat
type: docs
weight: 70
url: /nl/python-net/slide-size/
keywords:
- diaformaat
- beeldverhouding
- standaard
- breedbeeld
- 4:3
- 16:9
- diaformaat instellen
- diaformaat wijzigen
- aangepast diaformaat
- speciaal diaformaat
- uniek diaformaat
- volledige dia
- schermtype
- niet schalen
- passen waarborgen
- maximaliseren
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Leer hoe u snel dia's kunt herschalen in PPT-, PPTX- en ODP-bestanden met Python en Aspose.Slides, en presentaties optimaliseert voor elk scherm zonder kwaliteitsverlies."
---
## **Introductie**

Aspose.Slides biedt uitgebreide hulpmiddelen om de dia‑grootte en beeldverhouding in PowerPoint‑presentaties aan te passen, wat essentieel is voor zowel afdrukken als weergave op scherm.

Populaire dia‑groottes en verhoudingen:

- **Standaard (4:3 beeldverhouding)**: Ideaal voor oudere schermen en apparaten.
- **Breedbeeld (16:9 beeldverhouding)**: Aanbevolen voor moderne projectoren en displays.

Zorg voor consistentie in de hele presentatie, want één dia‑grootte en beeldverhouding wordt op alle dia’s toegepast. Voor optimale resultaten stel je de dia‑afmetingen in aan het begin van het aanmaakproces van je presentatie om complicaties te voorkomen.

{{% alert color="primary" %}} 
Standaard gebruiken presentaties die met Aspose.Slides zijn gemaakt de 4:3‑beeldverhouding.
{{% /alert %}}

## **Diaformaat wijzigen in een presentatie**

Deze voorbeeldcode laat zien hoe je het diaformaat in een presentatie wijzigt in Python met Aspose.Slides:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(slides.SlideSizeType.ON_SCREEN16X9, slides.SlideSizeScaleType.DO_NOT_SCALE)
    pres.save("pres-4x3-aspect-ratio.pptx", slides.export.SaveFormat.PPTX)
```

## **Aangepaste dia‑groottes specificeren**

Als de gangbare dia‑groottes (4:3 en 16:9) niet geschikt zijn voor jouw werk, kun je kiezen voor een specifieke of unieke dia‑grootte. Bijvoorbeeld wanneer je volledige dia’s wilt afdrukken op een aangepast paginalay‑out of wanneer je de presentatie wilt tonen op bepaalde schermtypen, profiteer je van een aangepaste grootte‑instelling voor je presentatie.

Deze voorbeeldcode laat zien hoe je Aspose.Slides voor Python via .NET gebruikt om een aangepaste dia‑grootte voor een presentatie in Python te definiëren:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(780, 540, slides.SlideSizeScaleType.DO_NOT_SCALE) # A4 papierformaat
    pres.save("pres-a4-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

## **Dia‑inhoud afhandelen na het herschalen**

Nadat je het diaformaat van een presentatie hebt gewijzigd, kan de inhoud van de dia’s (bijvoorbeeld afbeeldingen of objecten) vervormd raken. Standaard worden de objecten automatisch aangepast aan de nieuwe dia‑grootte. Wanneer je echter de dia‑grootte van een presentatie wijzigt, kun je een instelling specificeren die bepaalt hoe Aspose.Slides met de inhoud op de dia’s omgaat.

Afhankelijk van wat je wilt bereiken, kun je een van de volgende instellingen gebruiken:

- `DO_NOT_SCALE`

  Als je **NIET** wilt dat de objecten op de dia’s worden geschaald, gebruik dan deze instelling.

- `ENSURE_FIT`

  Als je naar een kleinere dia‑grootte wilt schalen en je wilt dat Aspose.Slides de objecten verkleint zodat ze allemaal op de dia passen (zodat je geen inhoud verliest), gebruik dan deze instelling.

- `MAXIMIZE`

  Als je naar een grotere dia‑grootte wilt schalen en je wilt dat Aspose.Slides de objecten vergroot zodat ze evenredig blijven met de nieuwe dia‑grootte, gebruik dan deze instelling.

Deze voorbeeldcode laat zien hoe je de `MAXIMIZE`‑instelling gebruikt bij het wijzigen van de grootte van de dia’s van een presentatie:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
   pres.slide_size.set_size(slides.SlideSizeType.LEDGER, slides.SlideSizeScaleType.MAXIMIZE)
```

## **FAQ**

**Kan ik een aangepaste dia‑grootte instellen met andere eenheden dan inches (bijvoorbeeld punten of millimeters)?**

Ja. Aspose.Slides werkt intern met punten, waarbij 1 punt gelijk is aan 1/72 van een inch. Je kunt elke eenheid (zoals millimeters of centimeters) omrekenen naar punten en de omgezette waarden gebruiken om de dia‑breedte en -hoogte te definiëren.

**Zal een zeer grote aangepaste dia‑grootte de prestaties en het geheugenverbruik tijdens het renderen beïnvloeden?**

Ja. Grotere dia‑afmetingen (in punten) in combinatie met een hogere render‑schaal leiden tot meer geheugengebruik en langere verwerkingstijden. Streef naar een praktische dia‑grootte en pas de render‑schaal alleen aan wanneer dat nodig is om de gewenste uitvoerkwaliteit te behalen.

**Kan ik één niet‑standaard dia‑grootte definiëren en vervolgens dia’s uit presentaties met verschillende groottes samenvoegen?**

Je kunt geen presentaties [presentaties samenvoegen](/slides/nl/python-net/merge-presentation/) terwijl ze verschillende dia‑groottes hebben — pas eerst één presentatie aan zodat deze overeenkomt met de andere. Bij het wijzigen van de dia‑grootte kun je kiezen hoe bestaande inhoud wordt afgehandeld via de [SlideSizeScaleType](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidesizescaletype/)‑optie. Nadat de groottes zijn afgestemd, kun je dia’s samenvoegen terwijl de opmaak behouden blijft.

**Kan ik miniaturen genereren voor individuele vormen of specifieke regio’s van een dia, en respecteren deze de nieuwe dia‑grootte?**

Ja. Aspose.Slides kan miniaturen renderen voor [gehele dia’s](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slide/get_image/) evenals voor [geselecteerde vormen](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/get_image/). De resulterende afbeeldingen weerspiegelen de huidige dia‑grootte en beeldverhouding, zodat het kaderen en de geometrie consistent blijven.