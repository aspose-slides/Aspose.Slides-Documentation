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
- passend maken
- maximaliseren
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
descriptions: "Leer hoe u snel dia's kunt aanpassen in PPT-, PPTX- en ODP-bestanden met Python en Aspose.Slides, en presentaties optimaliseert voor elk scherm zonder kwaliteitsverlies."
---
## **Inleiding**

Aspose.Slides biedt uitgebreide hulpmiddelen om de dia‑grootte en beeldverhouding in PowerPoint‑presentaties aan te passen, wat cruciaal is zowel voor afdrukken als weergave op het scherm. 

Populaire dia‑groottes en verhoudingen:

- **Standaard (4:3‑beeldverhouding)**: Ideaal voor oudere schermen en apparaten.
- **Breedbeeld (16:9‑beeldverhouding)**: Aanbevolen voor moderne projectoren en displays.

Zorg voor consistentie in uw presentatie, want één dia‑grootte en beeldverhouding geldt voor alle dia's. Voor optimale resultaten stelt u de afmetingen van de dia's in aan het begin van het maakproces van uw presentatie om complicaties te voorkomen.

{{% alert color="primary" %}} 
Standaard gebruiken presentaties die met Aspose.Slides zijn gemaakt de standaard 4:3‑beeldverhouding.
{{% /alert %}}

## **Dia‑grootte wijzigen in een presentatie**

Deze voorbeeldcode laat zien hoe u de dia‑grootte in een presentatie wijzigt met Python en Aspose.Slides:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(slides.SlideSizeType.ON_SCREEN16X9, slides.SlideSizeScaleType.DO_NOT_SCALE)
    pres.save("pres-4x3-aspect-ratio.pptx", slides.export.SaveFormat.PPTX)
```

## **Aangepaste dia‑groottes specificeren**

Als de gebruikelijke dia‑groottes (4:3 en 16:9) niet geschikt zijn voor uw werk, kunt u ervoor kiezen een specifieke of unieke dia‑grootte te gebruiken. Bijvoorbeeld, wanneer u van plan bent volledige dia's af te drukken op een aangepaste paginalay-out of uw presentatie wilt weergeven op bepaalde schermtypes, heeft u waarschijnlijk baat bij het gebruiken van een aangepaste groottinstelling voor uw presentatie. 

Deze voorbeeldcode laat zien hoe u Aspose.Slides voor Python via .NET gebruikt om een aangepaste dia‑grootte voor een presentatie in Python op te geven:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(780, 540, slides.SlideSizeScaleType.DO_NOT_SCALE) # A4 papierformaat
    pres.save("pres-a4-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

## **Dia‑inhoud behandelen na het wijzigen van de grootte**

Nadat u de dia‑grootte van een presentatie hebt gewijzigd, kan de inhoud van de dia's (bijvoorbeeld afbeeldingen of objecten) vervormd raken. Standaard worden objecten automatisch aangepast zodat ze passen bij de nieuwe dia‑grootte. Bij het wijzigen van de dia‑grootte kunt u echter een instelling opgeven die bepaalt hoe Aspose.Slides met de inhoud van de dia's omgaat.

Afhankelijk van wat u wilt bereiken, kunt u een van deze instellingen gebruiken:

- `DO_NOT_SCALE`

  Als u de objecten op de dia's NIET wilt laten schalen, gebruikt u deze instelling.

- `ENSURE_FIT`

  Als u wilt schalen naar een kleinere dia‑grootte en u wilt dat Aspose.Slides de objecten verkleint zodat ze allemaal op de dia passen (zodat u geen inhoud verliest), gebruikt u deze instelling.

- `MAXIMIZE`

  Als u wilt schalen naar een grotere dia‑grootte en u wilt dat Aspose.Slides de objecten vergroot zodat ze proportioneel zijn aan de nieuwe dia‑grootte, gebruikt u deze instelling.

Deze voorbeeldcode toont hoe u de instelling `MAXIMIZE` gebruikt bij het wijzigen van de grootte van een dia in een presentatie:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
   pres.slide_size.set_size(slides.SlideSizeType.LEDGER, slides.SlideSizeScaleType.MAXIMIZE)
```

## **FAQ**

**Kan ik een aangepaste dia‑grootte instellen met een andere eenheid dan inches (bijvoorbeeld punten of millimeters)?**

Ja. Aspose.Slides gebruikt intern punten, waarbij 1 punt gelijk is aan 1/72 inch. U kunt elke eenheid (zoals millimeters of centimeters) omrekenen naar punten en de omgezette waarden gebruiken om de breedte en hoogte van de dia te definiëren.

**Zal een zeer grote aangepaste dia‑grootte de prestaties en het geheugenverbruik tijdens het renderen beïnvloeden?**

Ja. Grotere dia‑afmetingen (in punten) gecombineerd met een hogere renderingschaal zorgen voor een hoger geheugenverbruik en langere verwerkingstijden. Streef naar een praktische dia‑grootte en pas de renderingschaal alleen aan wanneer dat nodig is om de gewenste uitvoerkwaliteit te bereiken.

**Kan ik één niet‑standaard dia‑grootte definiëren en vervolgens dia's van presentaties met verschillende groottes samenvoegen?**

U kunt geen [presentaties samenvoegen](/slides/nl/python-net/merge-presentation/) wanneer ze verschillende dia‑groottes hebben — eerst past u één presentatie aan zodat deze overeenkomt met de andere. Bij het wijzigen van de dia‑grootte kunt u kiezen hoe bestaande inhoud wordt behandeld via de optie [SlideSizeScaleType](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidesizescaletype/). Nadat de groottes zijn afgestemd, kunt u dia's samenvoegen met behoud van de opmaak.

**Kan ik miniaturen genereren voor individuele vormen of specifieke gebieden van een dia, en houden deze rekening met de nieuwe dia‑grootte?**

Ja. Aspose.Slides kan miniaturen renderen voor [complete dia's](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slide/get_image/) evenals voor [geselecteerde vormen](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/get_image/). De resulterende afbeeldingen weerspiegelen de huidige dia‑grootte en beeldverhouding, waardoor een consistente compositie en geometrie wordt gegarandeerd.