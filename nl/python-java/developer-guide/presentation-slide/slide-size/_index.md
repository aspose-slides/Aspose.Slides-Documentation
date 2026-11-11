---
title: Verander de dia-grootte van de presentatie in Python via Java
linktitle: Dia-grootte
type: docs
weight: 70
url: /nl/python-java/slide-size/
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
- Java
- Aspose.Slides
description: "Leer hoe u snel dia's kunt verkleinen in PPT-, PPTX- en ODP-bestanden met Python via Java en Aspose.Slides, en optimaliseer presentaties voor elk scherm zonder kwaliteitsverlies."
---
## **Inleiding**

Aspose.Slides biedt uitgebreide hulpmiddelen om de dia‑grootte en beeldverhouding in PowerPoint‑presentaties aan te passen, wat cruciaal is voor zowel afdrukken als weergave op scherm.

Populaire dia‑groottes en verhoudingen:

- **Standaard (4:3 beeldverhouding)**: Ideaal voor oudere schermen en apparaten.
- **Breedbeeld (16:9 beeldverhouding)**: Aanbevolen voor moderne projectoren en displays.

Zorg voor consistentie gedurende uw presentatie omdat één dia‑grootte en beeldverhouding van toepassing is op alle dia’s. Voor optimale resultaten stelt u de afmetingen van uw dia’s in aan het begin van het aanmaken van de presentatie om complicaties te vermijden.

{{% alert color="info" title="Opmerking" %}}
Standaard gebruiken presentaties die met Aspose.Slides worden gemaakt de 4:3‑beeldverhouding.
{{% /alert %}}

Notitie‑ en hand‑out‑pagina’s hebben andere afmetingen dan gewone dia’s. Zie [Notes Page Size](/slides/nl/python-java/notes-size/) om hun grootte en oriëntatie aan te passen.

## **Dia‑grootte wijzigen in presentaties**

Deze voorbeeldcode laat zien hoe u de dia‑grootte in een presentatie wijzigt in Python via Java met Aspose.Slides:

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

## **Aangepaste dia‑groottes specificeren in presentaties**

Als de gangbare dia‑groottes (4:3 en 16:9) niet geschikt zijn voor uw werk, kunt u besluiten een specifieke of unieke dia‑grootte te gebruiken. Bijvoorbeeld wanneer u volledige dia’s wilt afdrukken op een aangepast paginaplan of wanneer u de presentatie wilt weergeven op bepaalde types schermen, draait het wellicht om een aangepaste grootte‑instelling voor uw presentatie.

Deze voorbeeldcode laat zien hoe u met Aspose.Slides voor Python via Java een aangepaste dia‑grootte voor een presentatie specificeert:

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

## **Dia‑inhoud behandelen na het wijzigen van de grootte**

Nadat u de dia‑grootte van een presentatie hebt gewijzigd, kan de inhoud van de dia’s (bijvoorbeeld afbeeldingen of objecten) vervormd raken. Standaard worden de objecten automatisch aangepast aan de nieuwe dia‑grootte. Bij het wijzigen van de dia‑grootte kunt u echter een instelling opgeven die bepaalt hoe Aspose.Slides omgaat met de inhoud op de dia’s.

Afhankelijk van wat u wilt bereiken, kunt u een van deze instellingen gebruiken:

- [DoNotScale](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidesizescaletype/#DoNotScale)

  Als u NIET wilt dat de objecten op de dia’s worden geschaald, gebruikt u deze instelling.

- [EnsureFit](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidesizescaletype/#EnsureFit)

  Als u naar een kleinere dia‑grootte wilt schalen en Aspose.Slides de objecten wilt laten verkleinen zodat ze allemaal op de dia passen (zodat u geen inhoud verliest), gebruikt u deze instelling.

- [Maximize](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidesizescaletype/#Maximize)

  Als u naar een grotere dia‑grootte wilt schalen en Aspose.Slides de objecten wilt laten vergroten zodat ze proportioneel zijn aan de nieuwe dia‑grootte, gebruikt u deze instelling.

Deze voorbeeldcode laat zien hoe u de [Maximize](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidesizescaletype/#Maximize) instelling gebruikt bij het wijzigen van de grootte van de dia’s van een presentatie:

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

**Kan ik een aangepaste dia‑grootte instellen met andere eenheden dan inches (bijvoorbeeld punten of millimeters)?**

Ja. Aspose.Slides werkt intern met punten, waarbij 1 punt gelijk is aan 1/72 van een inch. U kunt elke eenheid (zoals millimeters of centimeters) omrekenen naar punten en de geconverteerde waarden gebruiken om de breedte en hoogte van de dia te definiëren.

**Zal een zeer grote aangepaste dia‑grootte de prestaties en het geheugenverbruik tijdens het renderen beïnvloeden?**

Ja. Grotere dia‑afmetingen (in punten) in combinatie met een hogere render‑schaal leiden tot meer geheugengebruik en langere verwerkingstijden. Streef naar een praktische dia‑grootte en pas de render‑schaal alleen aan wanneer dat nodig is om de gewenste uitvoerkwaliteit te bereiken.

**Kan ik één niet‑standaard dia‑grootte definiëren en vervolgens dia’s uit presentaties met verschillende groottes samenvoegen?**

U kunt geen [presentaties samenvoegen](/slides/nl/python-java/merge-presentation/) uitvoeren terwijl ze verschillende dia‑groottes hebben — vergroot eerst de ene presentatie zodat deze overeenkomt met de andere. Bij het wijzigen van de dia‑grootte kunt u kiezen hoe bestaande inhoud wordt behandeld via de [SlideSizeScaleType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidesizescaletype/) optie. Na het uitlijnen van de groottes kunt u de dia’s samenvoegen en de opmaak behouden.

**Kan ik thumbnails genereren voor individuele vormen of specifieke regio’s van een dia, en houden deze rekening met de nieuwe dia‑grootte?**

Ja. Aspose.Slides kan thumbnails renderen voor [hele dia's](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slide/#getImage) evenals voor [geselecteerde vormen](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getImage). De resulterende afbeeldingen weerspiegelen de huidige dia‑grootte en beeldverhouding, waardoor consistente compositie en geometrie worden gewaarborgd.