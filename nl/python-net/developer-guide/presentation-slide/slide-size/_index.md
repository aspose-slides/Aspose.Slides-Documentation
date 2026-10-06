---
title: Wijzig de dia-grootte in presentaties met Python
linktitle: Dia-grootte
type: docs
weight: 70
url: /nl/python-net/slide-size/
keywords:
- dia-grootte
- beeldverhouding
- standaard
- breedbeeld
- 4:3
- 16:9
- dia-grootte instellen
- dia-grootte wijzigen
- aangepaste dia-grootte
- speciale dia-grootte
- unieke dia-grootte
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
description: "Leer hoe u snel dia's kunt aanpassen in PPT-, PPTX- en ODP-bestanden met Python en Aspose.Slides, optimaliseer presentaties voor elk scherm zonder kwaliteitsverlies."
---
## **Introductie**

Aspose.Slides biedt uitgebreide hulpmiddelen om de dia‑grootte en beeldverhouding in PowerPoint‑presentaties aan te passen, wat essentieel is voor zowel afdrukken als weergave op een scherm.

Populaire dia‑groottes en verhoudingen:

- **Standaard (4:3 beeldverhouding)**: Ideaal voor oudere schermen en apparaten.  
- **Breedbeeld (16:9 beeldverhouding)**: Aanbevolen voor moderne projectoren en displays.

Zorg voor consistentie in uw hele presentatie, want één dia‑grootte en beeldverhouding gelden voor alle dia’s. Stel uw dia‑afmetingen bij het starten van het aanmaken van de presentatie in om complicaties te voorkomen.

{{% alert color="info" title="Let op" %}}
Standaard gebruiken presentaties die met Aspose.Slides worden gemaakt de 4:3‑beeldverhouding.
{{% /alert %}}

Notitie‑ en hand-outs‑pagina’s hebben andere afmetingen dan de gewone dia’s. Zie [Notitiepagina‑grootte](/slides/nl/python-net/notes-size/) om hun grootte en oriëntatie te wijzigen.

## **Dia‑grootte wijzigen in een presentatie**

Dit voorbeeld toont hoe u de dia‑grootte in een presentatie in Python wijzigt met Aspose.Slides:

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
    pres.slide_size.set_size(slides.SlideSizeType.ON_SCREEN_16X9, slides.SlideSizeScaleType.DO_NOT_SCALE)
    pres.save("pres-16x9-aspect-ratio.pptx", slides.export.SaveFormat.PPTX)
```

## **Aangepaste dia‑groottes opgeven**

Als de gangbare dia‑groottes (4:3 en 16:9) niet geschikt zijn voor uw werk, kunt u een specifieke of unieke dia‑grootte gebruiken. Bijvoorbeeld wanneer u volledige dia’s wilt afdrukken op een aangepaste paginalay‑out of wanneer u de presentatie op bepaalde schermtypen wilt weergeven; dan profiteert u van een aangepaste grootte‑instelling voor uw presentatie.

Dit voorbeeld toont hoe u Aspose.Slides voor Python via .NET gebruikt om een aangepaste dia‑grootte voor een presentatie in Python op te geven:

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
    pres.slide_size.set_size(780, 540, slides.SlideSizeScaleType.DO_NOT_SCALE) # A4-papierformaat
    pres.save("pres-a4-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

## **Dia‑inhoud verwerken na het aanpassen van de grootte**

Nadat u de dia‑grootte van een presentatie hebt gewijzigd, kan de inhoud van de dia’s (afbeeldingen of objecten, bijvoorbeeld) vervormd raken. Standaard worden de objecten automatisch aangepast aan de nieuwe dia‑grootte. Bij het wijzigen van de dia‑grootte kunt u echter een instelling opgeven die bepaalt hoe Aspose.Slides met de inhoud omgaat.

Afhankelijk van wat u wilt bereiken, kunt u een van deze instellingen gebruiken:

- `DO_NOT_SCALE`

  Gebruik deze instelling als u **NIET** wilt dat de objecten op de dia’s worden geschaald.

- `ENSURE_FIT`

  Gebruik deze instelling als u naar een kleinere dia‑grootte wilt schalen en Aspose.Slides de objecten moet verkleinen zodat alles op de dia past (zodat er geen inhoud verloren gaat).

- `MAXIMIZE`

  Gebruik deze instelling als u naar een grotere dia‑grootte wilt schalen en Aspose.Slides de objecten moet vergroten zodat ze evenredig blijven met de nieuwe dia‑grootte.

Dit voorbeeld toont hoe u de `MAXIMIZE`‑instelling gebruikt bij het wijzigen van de dia‑grootte van een presentatie:

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
   pres.slide_size.set_size(slides.SlideSizeType.LEDGER, slides.SlideSizeScaleType.MAXIMIZE)
```

## **Veelgestelde vragen**

**Kan ik een aangepaste dia‑grootte instellen met andere eenheden dan inches (bijvoorbeeld punten of millimeters)?**

Ja. Aspose.Slides werkt intern met punten, waarbij 1 punt gelijk is aan 1/72 van een inch. U kunt elke eenheid (zoals millimeters of centimeters) naar punten omrekenen en de omgezette waarden gebruiken om de dia‑breedte en -hoogte te definiëren.

**Zal een zeer grote aangepaste dia‑grootte de prestaties en het geheugenverbruik tijdens het renderen beïnvloeden?**

Ja. Grotere dia‑afmetingen (in punten) in combinatie met een hogere render‑schaal leiden tot hoger geheugenverbruik en langere verwerkingstijden. Streef naar een praktische dia‑grootte en pas de render‑schaal alleen aan wanneer dat nodig is om de gewenste uitvoerkwaliteit te bereiken.

**Kan ik één niet‑standaard dia‑grootte definiëren en vervolgens dia’s van presentaties met verschillende groottes samenvoegen?**

U kunt geen [presentaties samenvoegen](/slides/nl/python-net/merge-presentation/) zolang ze verschillende dia‑groottes hebben — pas eerst de grootte van één presentatie aan zodat ze overeenkomen. Bij het wijzigen van de dia‑grootte kunt u kiezen hoe bestaande inhoud wordt behandeld via de `SlideSizeScaleType`‑optie. Nadat de groottes zijn afgestemd, kunt u dia’s samenvoegen met behoud van de opmaak.

**Kan ik miniaturen genereren voor afzonderlijke vormen of specifieke gebieden van een dia, en respecteren deze de nieuwe dia‑grootte?**

Ja. Aspose.Slides kan miniaturen renderen voor [volledige dia’s](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slide/get_image/) én voor [geselecteerde vormen](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/get_image/). De gegenereerde afbeeldingen weerspiegelen de huidige dia‑grootte en beeldverhouding, waardoor de framing en geometrie consistent blijven.