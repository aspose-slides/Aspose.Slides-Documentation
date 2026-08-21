---
title: Low-Code presentatieoperaties in Python
linktitle: Low-Code API
type: docs
weight: 50
url: /nl/python-net/low-code-presentation-operations/
keywords:
- low-code presentatietoepassing API
- presentatie converteren
- presentaties samenvoegen
- vormen verzamelen
- presentatie comprimeren
- ongebruikte masterdia's verwijderen
- ongebruikte layoutdia's verwijderen
- ingesloten lettertypen comprimeren
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Gebruik de Aspose.Slides low-code API in Python om presentaties te converteren en samen te voegen, vormen te verzamelen en de grootte van de presentatie te verkleinen."
---
## **Overzicht**

De [aspose.slides.lowcode](https://reference.aspose.com/slides/nl/python-net/aspose.slides.lowcode/)‑module biedt hulpprogrammaklassen voor veelvoorkomende presentatietaken. Deze helpers verpakken vaak gebruikte object‑model‑workflows in gerichte methoden, zodat u bestanden kunt converteren of samenvoegen, vormen kunt verzamelen en ongebruikte inhoud kunt verwijderen met minder code.

Low‑code helpers zijn het meest nuttig wanneer de bewerking van toepassing is op een compleet bestand of presentatie en de standaardworkflow aan uw eisen voldoet. Gebruik het volledige [Aspose.Slides object model](https://reference.aspose.com/slides/nl/python-net/aspose.slides/) wanneer u fijnmazige controle nodig heeft over afzonderlijke dia's, masters, layouts, vormen, exportinstellingen of relaties tussen presentatie‑elementen.

De onderstaande tabel geeft een overzicht van de beschikbare helpers:

| Helper | Waarvoor te gebruiken |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/nl/python-net/aspose.slides.lowcode/convert/) | Een presentatie converteren naar een ander formaat met een directe bestand‑naar‑bestand‑aanroep. |
| [Merger](https://reference.aspose.com/slides/nl/python-net/aspose.slides.lowcode/merger/) | Volledige presentatiebestanden van hetzelfde formaat combineren. |
| [Collect](https://reference.aspose.com/slides/nl/python-net/aspose.slides.lowcode/collect/) | Vormen uit de volledige presentatie ophalen voor herhaalde verwerking of analyse. |
| [Compress](https://reference.aspose.com/slides/nl/python-net/aspose.slides.lowcode/compress/) | Niet‑gebruikte masters en layouts verwijderen en ingesloten lettertype‑gegevens verkleinen. |

## **Een presentatie converteren**

Gebruik [Convert.auto_by_extension](https://reference.aspose.com/slides/nl/python-net/aspose.slides.lowcode/convert/auto_by_extension/) wanneer de extensie van het uitvoerbestand voldoende is om het exportformaat te bepalen. De methode opent de bronpresentatie, bepaalt het vereiste formaat op basis van het doelpad en schrijft het resultaat.

```python
import aspose.slides as slides

slides.lowcode.Convert.auto_by_extension("input.pptx", "output.pdf")
```

De [Convert](https://reference.aspose.com/slides/nl/python-net/aspose.slides.lowcode/convert/)‑klasse biedt ook speciale methoden voor PDF, SVG, JPEG, PNG en TIFF uitvoer. Gebruik het volledige objectmodel wanneer u de presentatie moet inspecteren of wijzigen vóór export of wanneer u een exportoptie moet configureren die door de gekozen helper niet wordt blootgesteld. Zie [Convert Presentation](/python-net/convert-presentation/) voor formaat‑specifieke workflows en opties.

## **Presentaties samenvoegen**

Gebruik [Merger.process](https://reference.aspose.com/slides/nl/python-net/aspose.slides.lowcode/merger/process/) om volledige presentatiebestanden met één oproep te combineren. De invoerpresentaties moeten hetzelfde bestandsformaat hebben.

```python
import aspose.slides as slides

input_files = ["part-1.pptx", "part-2.pptx"]
slides.lowcode.Merger.process(input_files, "merged.pptx")
```

De helper is geschikt wanneer alle dia's aan één resultaat moeten worden toegevoegd zonder ze individueel te selecteren of te hermappen. Gebruik het volledige objectmodel wanneer u geselecteerde dia's wilt samenvoegen, een bestemmings‑master of layout wilt toepassen, secties expliciet wilt behouden of verschillende dia‑groottes wilt harmoniseren. Zie [Merge Presentations](/python-net/merge-presentation/) voor die scenario’s.

## **Vormen verzamelen**

Gebruik [Collect.shapes](https://reference.aspose.com/slides/nl/python-net/aspose.slides.lowcode/collect/shapes/) wanneer u een collectie van alle vormen in een presentatie nodig heeft. Dit is handig wanneer dezelfde set later gefilterd, geteld of meerdere keren verwerkt wordt.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    shapes = slides.lowcode.Collect.shapes(presentation)

    for shape in shapes:
        print(f"{shape.name}: {type(shape).__name__}")
```

Gebruik directe verzamel‑lussen wanneer de traversie‑volgorde, vroegtijdige onderbreking, filteren vóór verwerking of gedetailleerde ouder‑kind‑controle belangrijk zijn.

## **Presentatie‑inhoud comprimeren**

De [Compress](https://reference.aspose.com/slides/nl/python-net/aspose.slides.lowcode/compress/)‑klasse kan ongebruikte structurele elementen verwijderen en ingesloten lettertype‑gegevens verkleinen:

- [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/nl/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) verwijdert layout‑dia's die door geen enkele normale dia worden gerefereerd.
- [Compress.remove_unused_master_slides](https://reference.aspose.com/slides/nl/python-net/aspose.slides.lowcode/compress/remove_unused_master_slides/) verwijdert master‑dia's die niet meer in gebruik zijn.
- [Compress.compress_embedded_fonts](https://reference.aspose.com/slides/nl/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) verwijdert ongebruikte tekens uit ingesloten lettertypen.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    slides.lowcode.Compress.compress_embedded_fonts(presentation)

    presentation.save("compressed.pptx", slides.export.SaveFormat.PPTX)
```

Verwijder ongebruikte layouts vóór ongebruikte masters, zodat een master die na het opruimen van layouts niet meer wordt gerefereerd ook verwijderd kan worden. Sla de geoptimaliseerde presentatie op in een nieuw bestand als u later de oorspronkelijke masters, layouts of volledige ingesloten lettertype‑gegevens nodig heeft. Voor meer details, zie [Slide Master](/python-net/slide-master/) en [Embedded Font](/python-net/embedded-font/).

## **Veelgestelde vragen**

**Wanneer moet ik de low‑code‑API gebruiken in plaats van het volledige objectmodel?**

Gebruik low‑code helpers wanneer een standaardbewerking van toepassing is op een compleet bestand of presentatie en geen gedetailleerde controle over afzonderlijke elementen vereist. Gebruik het volledige objectmodel wanneer u specifieke dia's moet selecteren, master‑ en layout‑relaties moet beheersen, een tussentijdse status wilt inspecteren of gedrag wilt configureren dat de helper niet blootstelt.

**Kan Merger presentaties combineren in verschillende bestandsformaten?**

Nee. [Merger.process](https://reference.aspose.com/slides/nl/python-net/aspose.slides.lowcode/merger/process/) vereist invoerpresentaties in hetzelfde formaat. Converteer de invoerbestanden eerst naar een gemeenschappelijk formaat, bijvoorbeeld met [Convert.auto_by_extension](https://reference.aspose.com/slides/nl/python-net/aspose.slides.lowcode/convert/auto_by_extension/), en merge vervolgens de geconverteerde bestanden.

**Wat omvat Collect.shapes?**

[Collect.shapes](https://reference.aspose.com/slides/nl/python-net/aspose.slides.lowcode/collect/shapes/) haalt vormen uit de presentatie zodat ze behouden, gefilterd, geteld of meerdere keren doorlopen kunnen worden. Gebruik directe verzamel‑lussen wanneer u precieze controle nodig heeft over welke dia‑typen of geneste objecten bezocht worden.

**Vermindert Compress altijd de bestandsgrootte van de presentatie?**

Niet per se. Het resultaat hangt af van of de presentatie ongebruikte layouts, ongebruikte masters of ingesloten lettertypen met ongebruikte tekens bevat. Als geen van deze aanwezig is, kunnen de bijbehorende [Compress](https://reference.aspose.com/slides/nl/python-net/aspose.slides.lowcode/compress/)‑bewerkingen de bestandsgrootte mogelijk niet verkleinen.

**Worden wijzigingen aangebracht door Compress automatisch opgeslagen?**

Nee. Deze helpers werken op het geladen [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑object in het geheugen. Na het uitvoeren van [Compress](https://reference.aspose.com/slides/nl/python-net/aspose.slides.lowcode/compress/), roep [Presentation.save](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/save/) aan om het resultaat weg te schrijven.

## **Gerelateerde artikelen**

- [Presentatie converteren](/python-net/convert-presentation/)
- [Presentaties samenvoegen](/python-net/merge-presentation/)
- [Slide Master](/python-net/slide-master/)
- [Manage Text Box](/python-net/manage-textbox/)
- [Embedded Font](/python-net/embedded-font/)