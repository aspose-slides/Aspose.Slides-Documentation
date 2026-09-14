---
title: Diaformaat van de presentatie wijzigen in Python via Java
linktitle: Diaformaat
type: docs
weight: 70
url: /nl/python-java/slide-size/
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
- Java
- Aspose.Slides
description: "Leer hoe u snel dia's kunt herschalen in PPT-, PPTX- en ODP-bestanden met Python via Java en Aspose.Slides, en optimaliseer presentaties voor elk scherm zonder kwaliteitsverlies."
---
## **Inleiding**

Aspose.Slides biedt uitgebreide hulpmiddelen om de diaformaat en beeldverhouding in PowerPoint‑presentaties aan te passen, wat cruciaal is voor zowel afdrukken als weergave op scherm.

Populaire diaformaten en verhoudingen:

- **Standaard (4:3 beeldverhouding)**: Ideaal voor oudere schermen en apparaten.
- **Breedbeeld (16:9 beeldverhouding)**: Aanbevolen voor moderne projectoren en schermen.

Zorg voor consistentie door uw presentatie heen, aangezien één diaformaat en beeldverhouding op alle dia’s van toepassing is. Voor optimale resultaten stelt u de afmetingen van uw dia’s in aan het begin van het maakproces van de presentatie om complicaties te vermijden.

{{% alert color="info" title="Note" %}}
Standaard gebruiken presentaties die met Aspose.Slides zijn gemaakt de standaard 4:3 beeldverhouding.
{{% /alert %}}

## **Diaformaat wijzigen in presentaties**

Deze voorbeeldcode laat zien hoe u het diaformaat in een presentatie kunt wijzigen in Python via Java met Aspose.Slides:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType, SlideSizeType

presentation = Presentation("pres-4x3-aspect-ratio.pptx")
try:
    presentation.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale)
    presentation.save("pres-16x9-aspect-ratio.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Aangepaste diaformaten opgeven in presentaties**

Als u de gangbare diaformaten (4:3 en 16:9) niet geschikt vindt voor uw werk, kunt u besluiten een specifiek of uniek diaformaat te gebruiken. Bijvoorbeeld, als u van plan bent volledige dia’s uit uw presentatie af te drukken op een aangepaste paginalay-out of als u uw presentatie wilt weergeven op bepaalde schermtypen, kunt u profiteren van een aangepaste formaatinstelling voor uw presentatie.

Deze voorbeeldcode laat zien hoe u Aspose.Slides for Python via Java kunt gebruiken om een aangepast diaformaat voor een presentatie op te geven:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation("pres.pptx")
try:
    presentation.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale)
    presentation.save("pres-custom-slide-size.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Dia‑inhoud afhandelen na het wijzigen van het formaat**

Nadat u het diaformaat van een presentatie hebt gewijzigd, kan de inhoud van de dia’s (bijvoorbeeld afbeeldingen of objecten) vervormd raken. Standaard worden de objecten automatisch geschaald zodat ze passen bij het nieuwe diaformaat. Bij het wijzigen van het diaformaat kunt u echter een instelling specificeren die bepaalt hoe Aspose.Slides met de inhoud op de dia’s omgaat.

Afhankelijk van wat u wilt doen of bereiken, kunt u een van deze instellingen gebruiken:

- [DoNotScale](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidesizescaletype/#DoNotScale)
  
  Als u NIET wilt dat de objecten op de dia’s worden geschaald, gebruik dan deze instelling.

- [EnsureFit](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidesizescaletype/#EnsureFit)
  
  Als u wilt schalen naar een kleiner diaformaat en u wilt dat Aspose.Slides de objecten op de dia’s verkleint zodat ze allemaal op de dia passen (zodat u geen inhoud verliest), gebruik dan deze instelling.

- [Maximize](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidesizescaletype/#Maximize)
  
  Als u wilt schalen naar een groter diaformaat en u wilt dat Aspose.Slides de objecten op de dia’s vergroot zodat ze proportioneel zijn aan het nieuwe diaformaat, gebruik dan deze instelling.

Deze voorbeeldcode laat zien hoe u de [Maximize](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidesizescaletype/#Maximize) instelling kunt gebruiken bij het wijzigen van het formaat van een dia in een presentatie:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideSizeScaleType, SlideSizeType

presentation = Presentation("pres.pptx")
try:
    presentation.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize)
finally:
    presentation.dispose()
```

## **FAQ**

**Kan ik een aangepast diaformaat instellen met een andere eenheid dan inches (bijvoorbeeld punten of millimeters)?**

Ja. Aspose.Slides gebruikt intern punten, waarbij 1 punt gelijk is aan 1/72 van een inch. U kunt elke eenheid (zoals millimeters of centimeters) omrekenen naar punten en de omgezette waarden gebruiken om de breedte en hoogte van de dia te definiëren.

**Zal een zeer groot aangepast diaformaat de prestaties en het geheugenverbruik tijdens het renderen beïnvloeden?**

Ja. Grotere dia‑afmetingen (in punten) in combinatie met een hogere rendementschaal leiden tot meer geheugenverbruik en langere verwerkingstijden. Streef naar een praktisch diaformaat en pas de renderschaal alleen aan wanneer dat nodig is om de gewenste uitvoerkwaliteit te bereiken.

**Kan ik één niet‑standaard diaformaat definiëren en vervolgens dia’s uit presentaties met verschillende formaten samenvoegen?**

U kunt geen [presentaties samenvoegen](/slides/nl/python-java/merge-presentation/) terwijl ze verschillende diaformaten hebben — eerst moet u een presentatie schalen zodat het formaat overeenkomt met de andere. Bij het wijzigen van het diaformaat kunt u kiezen hoe bestaande inhoud wordt behandeld via de [SlideSizeScaleType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidesizescaletype/) optie. Nadat de formaten zijn afgestemd, kunt u dia’s samenvoegen met behoud van de opmaak.

**Kan ik thumbnails genereren voor individuele vormen of specifieke gebieden van een dia, en respecteren deze het nieuwe diaformaat?**

Ja. Aspose.Slides kan thumbnails renderen voor [volledige dia’s](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slide/#getImage) evenals voor [geselecteerde vormen](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getImage). De resulterende afbeeldingen weerspiegelen het huidige diaformaat en de beeldverhouding, waardoor een consistente kadering en geometrie gewaarborgd blijven.