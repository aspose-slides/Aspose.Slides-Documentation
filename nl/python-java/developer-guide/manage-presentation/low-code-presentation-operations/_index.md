---
title: Low-Code presentatiewerkzaamheden in Python via Java
linktitle: Low-Code API
type: docs
weight: 50
url: /nl/python-java/low-code-presentation-operations/
keywords:
- low-code presentatie-API
- presentatie converteren
- presentaties samenvoegen
- dia's itereren
- vormen itereren
- tekst itereren
- vormen verzamelen
- presentatie comprimeren
- ongebruikte masterdia's verwijderen
- ongebruikte layoutdia's verwijderen
- ingesloten lettertypen comprimeren
- PowerPoint
- OpenDocument
- presentatie
- Python
- Java
- Aspose.Slides
description: "Gebruik de Aspose.Slides low-code API in Python via Java om presentaties te converteren en samen te voegen, door inhoud te itereren, vormen te verzamelen en de presentatiegrootte te verkleinen."
---
## **Overzicht**

De [Aspose.Slides for Python via Java](https://reference.aspose.com/slides/nl/python-java/aspose.slides/) API biedt statische hulpprogramma‑klassen voor algemene presentatie‑bewerkingen. Deze helpers verpakken veelgebruikte object‑modelwerkstromen in gerichte methoden, zodat u bestanden kunt converteren of samenvoegen, presentatie‑elementen kunt verwerken, vormen kunt verzamelen en ongebruikte inhoud kunt verwijderen met minder code.

Low‑code helpers zijn het meest bruikbaar wanneer de bewerking van toepassing is op een heel bestand of een hele presentatie en de standaard workflow aan uw eisen voldoet. Gebruik het volledige [Aspose.Slides object model](https://reference.aspose.com/slides/nl/python-java/aspose.slides/) wanneer u fijnmazige controle nodig heeft over individuele dia’s, masters, lay‑outs, vormen, exportinstellingen of relaties tussen presentatiedelen.

De volgende tabel geeft een overzicht van de beschikbare helpers:

| Helper | Gebruik hiervoor |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/nl/python-java/aspose.slides/convert/) | Een presentatie converteren naar een ander formaat met een directe bestand‑naar‑bestand aanroep. |
| [Merger](https://reference.aspose.com/slides/nl/python-java/aspose.slides/merger/) | Volledige presentatiebestanden van hetzelfde formaat combineren. |
| [ForEach](https://reference.aspose.com/slides/nl/python-java/aspose.slides/foreach/) | Een handeling uitvoeren voor elke dia, vorm, alinea of tekstgedeelte. |
| [Collect](https://reference.aspose.com/slides/nl/python-java/aspose.slides/collect/) | Vormen ophalen uit de volledige presentatie voor herhaaldelijke verwerking of analyse. |
| [Compress](https://reference.aspose.com/slides/nl/python-java/aspose.slides/compress/) | Ongebruikte masters en lay‑outs verwijderen en ingesloten lettertypegegevens reduceren. |

## **Een presentatie converteren**

Gebruik [Convert.autoByExtension](https://reference.aspose.com/slides/nl/python-java/aspose.slides/convert/#autoByExtension) wanneer de extensie van het uitvoerbestand voldoende is om het exportformaat te bepalen. De methode opent de bronpresentatie, bepaalt het vereiste formaat vanuit het uitvoerpad en schrijft het resultaat.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Convert

Convert.autoByExtension("input.pptx", "output.pdf")
```

De [Convert](https://reference.aspose.com/slides/nl/python-java/aspose.slides/convert/)‑klasse biedt ook speciale methoden voor PDF, SVG, JPEG, PNG en TIFF uitvoer. Gebruik het volledige objectmodel wanneer u de presentatie moet inspecteren of wijzigen vóór export of een exportoptie moet configureren die niet door de gekozen helper wordt blootgesteld. Zie [Convert Presentation](/slides/nl/python-java/convert-presentation/) voor formaat‑specifieke werkstromen en opties.

## **Presentaties samenvoegen**

Gebruik [Merger.process](https://reference.aspose.com/slides/nl/python-java/aspose.slides/merger/#process) om volledige presentatiebestanden met één aanroep te combineren. De invoerpresentaties moeten hetzelfde bestandsformaat hebben.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Merger

input_files = jpype.JArray(jpype.JString)(["part-1.pptx", "part-2.pptx"])
Merger.process(input_files, "merged.pptx")
```

De helper is geschikt wanneer alle dia’s moeten worden toegevoegd aan één resultaat zonder ze individueel te selecteren of opnieuw toe te wijzen. Gebruik het volledige objectmodel wanneer u geselecteerde dia’s moet samenvoegen, een doel‑master of -lay‑out wilt toepassen, secties expliciet wilt behouden, of verschillende dia‑groottes moet harmoniseren. Zie [Merge Presentations](/slides/nl/python-java/merge-presentation/) voor die scenario’s.

## **Itereren door presentatie‑elementen**

De [ForEach](https://reference.aspose.com/slides/nl/python-java/aspose.slides/foreach/)‑klasse roept een callback aan voor elk gevraagde type presentatie‑element. Het voorkomt geneste verzamellussen en is handig voor inspectie of opmaakwijzigingen over de hele presentatie.

Het volgende voorbeeld gebruikt [ForEach.slide](https://reference.aspose.com/slides/nl/python-java/aspose.slides/foreach/#slide), [ForEach.shape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/nl/python-java/aspose.slides/foreach/#paragraph) en [ForEach.portion](https://reference.aspose.com/slides/nl/python-java/aspose.slides/foreach/#portion) om de overeenkomstige elementen te inspecteren:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ForEach, Presentation

def print_slide(slide, index):
    print(f"Slide {index}: {slide.getShapes().size()} shapes")

def print_shape(shape, slide, index):
    print(f"Shape {index} on {slide.getClass().getSimpleName()}: {shape.getName()}")

def print_paragraph(paragraph, slide, index):
    print(f"Paragraph {index} on {slide.getClass().getSimpleName()}: {paragraph.getText()}")

def print_portion(portion, paragraph, slide, index):
    print(f"Portion {index} on {slide.getClass().getSimpleName()}: {portion.getText()}")

presentation = Presentation("input.pptx")
try:
    ForEach.slide(presentation, print_slide)
    ForEach.shape(presentation, print_shape)
    ForEach.paragraph(presentation, print_paragraph)
    ForEach.portion(presentation, print_portion)
finally:
    presentation.dispose()
```

Standaard omvat traversatie van vormen en tekst over de hele presentatie normale, master‑ en lay‑outdia’s. Overloads met een `includeNotes`‑parameter kunnen ook notitiedia’s verwerken. Gebruik directe verzamellussen wanneer de volgorde van traversatie, vroegtijdig stoppen, filteren vóór de callback‑aanroep of gedetailleerde ouder‑kind‑controle belangrijk is.

## **Vormen verzamelen**

Gebruik [Collect.shapes](https://reference.aspose.com/slides/nl/python-java/aspose.slides/collect/#shapes) wanneer u een verzameling van alle vormen in een presentatie nodig heeft in plaats van een callback voor elke vorm. Dit is nuttig wanneer dezelfde set meerdere malen gefilterd, geteld of verwerkt moet worden.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Collect, Presentation

presentation = Presentation("input.pptx")
try:
    shapes = Collect.shapes(presentation)

    for shape in shapes:
        print(f"{shape.getName()}: {shape.getClass().getSimpleName()}")
finally:
    presentation.dispose()
```

Gebruik [ForEach.shape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/foreach/#shape) in plaats daarvan wanneer elke vorm meteen kan worden afgehandeld en u het verzamelde resultaat niet hoeft te behouden.

## **Presentatie‑inhoud comprimeren**

De [Compress](https://reference.aspose.com/slides/nl/python-java/aspose.slides/compress/)‑klasse kan ongebruikte structurele elementen verwijderen en ingesloten lettertypegegevens reduceren:

- [removeUnusedLayoutSlides](https://reference.aspose.com/slides/nl/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) verwijdert lay‑outdia’s die door geen normale dia worden gerefereerd.  
- [removeUnusedMasterSlides](https://reference.aspose.com/slides/nl/python-java/aspose.slides/compress/#removeUnusedMasterSlides) verwijdert masterdia’s die niet langer worden gebruikt.  
- [compressEmbeddedFonts](https://reference.aspose.com/slides/nl/python-java/aspose.slides/compress/#compressEmbeddedFonts) verwijdert ongebruikte tekens uit ingesloten lettertypen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    Compress.removeUnusedLayoutSlides(presentation)
    Compress.removeUnusedMasterSlides(presentation)
    Compress.compressEmbeddedFonts(presentation)

    presentation.save("compressed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Verwijder ongebruikte lay‑outs vóór ongebruikte masters, zodat een master die na het opruimen van lay‑outs geen referentie meer heeft, ook kan worden verwijderd. Sla de geoptimaliseerde presentatie op in een nieuw bestand als u later de oorspronkelijke masters, lay‑outs of volledige ingesloten lettertypegegevens nodig heeft. Voor meer details, zie [Slide Master](/slides/nl/python-java/slide-master/) en [Embedded Font](/slides/nl/python-java/embedded-font/).

## **FAQ**

**Wanneer moet ik de low‑code‑API gebruiken in plaats van het volledige objectmodel?**

Gebruik low‑code helpers wanneer een standaardbewerking van toepassing is op een compleet bestand of een volledige presentatie en geen gedetailleerde controle over individuele elementen vereist. Gebruik het volledige objectmodel wanneer u specifieke dia’s moet selecteren, master‑ en lay‑outrelaties moet beheren, de tussenliggende staat moet inspecteren, of gedrag moet configureren dat de helper niet blootstelt.

**Kan Merger presentaties combineren in verschillende bestandsformaten?**

Nee. [Merger.process](https://reference.aspose.com/slides/nl/python-java/aspose.slides/merger/#process) vereist dat de invoerpresentaties hetzelfde formaat hebben. Converteer de invoerbestanden eerst naar een gemeenschappelijk formaat, bijvoorbeeld met [Convert.autoByExtension](https://reference.aspose.com/slides/nl/python-java/aspose.slides/convert/#autoByExtension), en voeg daarna de geconverteerde bestanden samen.

**Verwerkt ForEach master‑, lay‑out‑ en notities‑dia’s?**

[ForEach.slide](https://reference.aspose.com/slides/nl/python-java/aspose.slides/foreach/#slide) iterert door normale presentatiedia’s. Presentatie‑brede [ForEach.shape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/nl/python-java/aspose.slides/foreach/#paragraph) en [ForEach.portion](https://reference.aspose.com/slides/nl/python-java/aspose.slides/foreach/#portion)‑operaties omvatten standaard normale, master‑ en lay‑outdia’s. Gebruik hun overloads met `includeNotes` ingesteld op `True` om notitiedia’s mee te nemen.

**Wat is het verschil tussen ForEach.shape en Collect.shapes?**

Gebruik [ForEach.shape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/foreach/#shape) om elke vorm onmiddellijk via een callback te verwerken. Gebruik [Collect.shapes](https://reference.aspose.com/slides/nl/python-java/aspose.slides/collect/#shapes) wanneer u een iterabel resultaat nodig heeft dat kan worden bewaard, gefilterd, geteld of meerdere keren kan worden doorlopen.

**Maakt Compress altijd het presentatiebestand kleiner?**

Niet per se. Het resultaat hangt af van of de presentatie ongebruikte lay‑outs, ongebruikte masters of ingesloten lettertypen met ongebruikte tekens bevat. Als geen van deze elementen aanwezig zijn, kunnen de desbetreffende [Compress](https://reference.aspose.com/slides/nl/python-java/aspose.slides/compress/)‑operaties de bestandsgrootte mogelijk niet verkleinen.

**Worden wijzigingen gemaakt door ForEach of Compress automatisch opgeslagen?**

Nee. Deze helpers werken op het geladen [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑object in het geheugen. Nadat u elementen hebt gewijzigd in een [ForEach](https://reference.aspose.com/slides/nl/python-java/aspose.slides/foreach/)‑callback of [Compress](https://reference.aspose.com/slides/nl/python-java/aspose.slides/compress/) hebt uitgevoerd, dient u [Presentation.save](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#save) aan te roepen om het resultaat op te slaan.

## **Gerelateerde artikelen**

- [Presentatie converteren](/slides/nl/python-java/convert-presentation/)
- [Presentaties samenvoegen](/slides/nl/python-java/merge-presentation/)
- [Dia‑master](/slides/nl/python-java/slide-master/)
- [Tekstvak beheren](/slides/nl/python-java/manage-textbox/)
- [Ingesloten lettertype](/slides/nl/python-java/embedded-font/)