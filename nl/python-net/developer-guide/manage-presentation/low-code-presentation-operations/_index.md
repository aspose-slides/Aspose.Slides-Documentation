---
title: Low-Code presentatietaken in Python
linktitle: Low-Code API
type: docs
weight: 50
url: /nl/python-net/low-code-presentation-operations/
keywords:
- low-code presentaties API
- presentatie converteren
- presentaties samenvoegen
- vormen verzamelen
- presentatie comprimeren
- ongebruikte master-dia's verwijderen
- ongebruikte layout-dia's verwijderen
- ingesloten lettertypen comprimeren
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Gebruik de Aspose.Slides low-code API in Python om presentaties te converteren en samen te voegen, vormen te verzamelen en de grootte van de presentatie te verkleinen."
---
## **Overzicht**

De [aspose.slides.lowcode](https://reference.aspose.com/slides/nl/python-net/aspose.slides.lowcode/)‑module biedt hulpmiddelklassen voor veelvoorkomende presentatietaken. Deze helpers wikkelen vaak gebruikte object‑modelwerkstromen in gerichte methoden, zodat je bestanden kunt converteren of samenvoegen, vormen kunt verzamelen en ongebruikte inhoud kunt verwijderen met minder code.

Low‑code‑helpers zijn het meest nuttig wanneer de bewerking van toepassing is op een volledig bestand of presentatie en de standaard workflow aan je eisen voldoet. Gebruik het volledige [Aspose.Slides‑objectmodel](https://reference.aspose.com/slides/nl/python-net/aspose.slides/) wanneer je fijnmazige controle nodig hebt over afzonderlijke dia’s, masters, lay‑outs, vormen, exportinstellingen of relaties tussen presentatie‑elementen.

De onderstaande tabel geeft een overzicht van de beschikbare helpers:

| Helper | Waarvoor gebruiken |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/nl/python-net/aspose.slides.lowcode/convert/) | Een presentatie converteren naar een ander formaat met een directe bestands‑naar‑bestand‑aanroep. |
| [Merger](https://reference.aspose.com/slides/nl/python-net/aspose.slides.lowcode/merger/) | Complete presentatiebestanden van hetzelfde formaat combineren. |
| [Collect](https://reference.aspose.com/slides/nl/python-net/aspose.slides.lowcode/collect/) | Vormen uit de gehele presentatie ophalen voor herhaalde verwerking of analyse. |
| [Compress](https://reference.aspose.com/slides/nl/python-net/aspose.slides.lowcode/compress/) | Ongebruikte masters en lay‑outs verwijderen en ingesloten lettertype‑data verkleinen. |

## **Een presentatie converteren**

Gebruik [Convert.auto_by_extension](https://reference.aspose.com/slides/nl/python-net/aspose.slides.lowcode/convert/auto_by_extension/) wanneer de bestandsextensie van de uitvoer voldoende is om het exportformaat te bepalen. De methode opent de bronpresentatie, bepaalt het vereiste formaat op basis van het uitvoerpad en schrijft het resultaat.

```python
import aspose.slides as slides

slides.lowcode.Convert.auto_by_extension("input.pptx", "output.pdf")
```

De [Convert](https://reference.aspose.com/slides/nl/python-net/aspose.slides.lowcode/convert/)‑klasse biedt ook speciale methoden voor PDF, SVG, JPEG, PNG en TIFF uitvoer. Gebruik het volledige objectmodel wanneer je de presentatie wilt inspecteren of wijzigen vóór export, of wanneer je een exportoptie moet configureren die niet wordt blootgesteld door de geselecteerde helper. Zie [Convert Presentation](/slides/nl/python-net/convert-presentation/) voor formaat‑specifieke werkstromen en opties.

## **Presentaties samenvoegen**

Gebruik [Merger.process](https://reference.aspose.com/slides/nl/python-net/aspose.slides.lowcode/merger/process/) om complete presentatiebestanden met één aanroep te combineren. De invoer‑presentaties moeten hetzelfde bestandsformaat hebben.

```python
import aspose.slides as slides

input_files = ["part-1.pptx", "part-2.pptx"]
slides.lowcode.Merger.process(input_files, "merged.pptx")
```

De helper is geschikt wanneer alle dia’s moeten worden toegevoegd aan één resultaat zonder ze individueel te selecteren of opnieuw toe te wijzen. Gebruik het volledige objectmodel wanneer je geselecteerde dia’s wilt samenvoegen, een bestemmings‑master of -lay‑out wilt toepassen, secties expliciet wilt behouden, of verschillende dia‑groottes moet harmoniseren. Zie [Merge Presentations](/slides/nl/python-net/merge-presentation/) voor die scenario’s.

## **Vormen verzamelen**

Gebruik [Collect.shapes](https://reference.aspose.com/slides/nl/python-net/aspose.slides.lowcode/collect/shapes/) wanneer je een verzameling van alle vormen in een presentatie nodig hebt. Dit is nuttig wanneer dezelfde set later gefilterd, geteld of meerdere keren verwerkt moet worden.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    shapes = slides.lowcode.Collect.shapes(presentation)

    for shape in shapes:
        print(f"{shape.name}: {type(shape).__name__}")
```

Gebruik directe verzamelings‑lussen wanneer de doorloopvolgorde, vroegtijdig afbreken, filteren vóór verwerking of gedetailleerde ouder‑kind‑controle belangrijk zijn.

## **Presentatie‑inhoud comprimeren**

De [Compress](https://reference.aspose.com/slides/nl/python-net/aspose.slides.lowcode/compress/)‑klasse kan ongebruikte structurele elementen verwijderen en ingesloten lettertype‑data verkleinen:

- [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/nl/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) verwijdert lay‑outdia’s die door geen enkele normale dia worden gerefereerd.
- [Compress.remove_unused_master_slides](https://reference.aspose.com/slides/nl/python-net/aspose.slides.lowcode/compress/remove_unused_master_slides/) verwijdert master‑dia’s die niet meer worden gebruikt.
- [Compress.compress_embedded_fonts](https://reference.aspose.com/slides/nl/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) verwijdert ongebruikte tekens uit ingesloten lettertypen.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    slides.lowcode.Compress.compress_embedded_fonts(presentation)

    presentation.save("compressed.pptx", slides.export.SaveFormat.PPTX)
```

Verwijder eerst ongebruikte lay‑outs voordat je ongebruikte masters verwijdert, zodat een master die na het opruimen van lay‑outs niet meer wordt gerefereerd ook kan worden verwijderd. Sla de geoptimaliseerde presentatie op in een nieuw bestand als je later de originele masters, lay‑outs of volledige ingesloten lettertype‑data mogelijk nodig hebt. Voor meer details, zie [Slide Master](/slides/nl/python-net/slide-master/) en [Embedded Font](/slides/nl/python-net/embedded-font/).

## **FAQ**

**Wanneer moet ik de low-code‑API gebruiken in plaats van het volledige objectmodel?**

Gebruik low‑code‑helpers wanneer een standaardbewerking van toepassing is op een volledig bestand of presentatie en geen gedetailleerde controle over individuele elementen vereist. Gebruik het volledige objectmodel wanneer je specifieke dia’s wilt selecteren, relaties tussen master en lay‑out wilt beheersen, de tussenliggende status wilt inspecteren, of gedrag wilt configureren dat de helper niet blootstelt.

**Kan Merger presentaties combineren in verschillende bestandsformaten?**

Nee. [Merger.process](https://reference.aspose.com/slides/nl/python-net/aspose.slides.lowcode/merger/process/) vereist invoer‑presentaties in hetzelfde formaat. Converteer de invoerbestanden eerst naar een gemeenschappelijk formaat, bijvoorbeeld met [Convert.auto_by_extension](https://reference.aspose.com/slides/nl/python-net/aspose.slides.lowcode/convert/auto_by_extension/), en voeg vervolgens de geconverteerde bestanden samen.

**Wat omvat Collect.shapes?**

[Collect.shapes](https://reference.aspose.com/slides/nl/python-net/aspose.slides.lowcode/collect/shapes/) haalt vormen op uit de presentatie zodat ze bewaard, gefilterd, geteld of meerdere keren doorlopen kunnen worden. Gebruik directe verzamelings‑lussen wanneer je nauwkeurige controle nodig hebt over welk type dia’s of geneste objecten worden bezocht.

**Maakt Compress altijd de presentatiedata kleiner?**

Niet per se. Het resultaat hangt af van of de presentatie ongebruikte lay‑outs, ongebruikte masters of ingesloten lettertypen met ongebruikte tekens bevat. Als geen van deze aanwezig is, zullen de corresponderende [Compress](https://reference.aspose.com/slides/nl/python-net/aspose.slides.lowcode/compress/)‑bewerkingen het bestandsgrootte niet verkleinen.

**Worden wijzigingen door Compress automatisch opgeslagen?**

Nee. Deze helpers opereren op het geladen [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑object in het geheugen. Nadat je [Compress](https://reference.aspose.com/slides/nl/python-net/aspose.slides.lowcode/compress/) hebt uitgevoerd, roep je [Presentation.save](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/save/) aan om het resultaat weg te schrijven.

## **Gerelateerde artikelen**

- [Convert Presentation](/slides/nl/python-net/convert-presentation/)
- [Merge Presentations](/slides/nl/python-net/merge-presentation/)
- [Slide Master](/slides/nl/python-net/slide-master/)
- [Manage Text Box](/slides/nl/python-net/manage-textbox/)
- [Embedded Font](/slides/nl/python-net/embedded-font/)