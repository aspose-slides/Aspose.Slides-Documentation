---
title: Presentaties importeren vanuit PDF of HTML in Python via Java
linktitle: Importeer presentatie
type: docs
weight: 60
url: /nl/python-java/import-presentation/
keywords:
- import presentatie
- import dia
- import PDF
- import HTML
- PDF naar presentatie
- PDF naar PPT
- PDF naar PPTX
- PDF naar ODP
- HTML naar presentatie
- HTML naar PPT
- HTML naar PPTX
- HTML naar ODP
- PowerPoint
- OpenDocument
- Python
- Java
- Aspose.Slides
description: "Leer hoe u PDF- en HTML-inhoud kunt importeren in PowerPoint-presentaties in Python via Java met Aspose.Slides en sla de resultaten op als PPTX-bestanden."
---
## **Introductie**

Aspose.Slides voor Python via Java kan PDF-pagina's of HTML-inhoud omzetten naar PowerPoint-dia's zonder Microsoft PowerPoint. De [SlideCollection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidecollection/) klasse biedt [addFromPdf](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidecollection/#addFromPdf) en [addFromHtml](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidecollection/#addFromHtml) om geïmporteerde inhoud aan een presentatie toe te voegen.

Voor meer controle over de plaatsing van HTML kan [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidecollection/#insertFromHtml) gegenereerde dia's invoegen op een verzamelingsindex of beginnen met het vullen van beschikbare ruimte op een bestaande dia. Lange HTML wordt automatisch over meerdere dia's gepagineerd, de bron kan als tekenreeks of stream worden aangeleverd, en externe middelen kunnen worden geladen via [ExternalResourceResolver](https://reference.aspose.com/slides/nl/python-java/aspose.slides/externalresourceresolver/) met een basis-URI. De geretourneerde [Slide](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slide/) array identificeert de getroffen en nieuw aangemaakte dia's.

## **Importeren vanuit PDF**

Om een PDF-document om te zetten naar een PowerPoint-presentatie, importeer je de inhoud in de dia‑collectie en sla je het resultaat op als een PPTX‑bestand.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. Maak een nieuw [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) object aan.
2. Roep [addFromPdf](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidecollection/#addFromPdf) aan met het pad naar het PDF‑bestand.
3. Roep [save](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#save) aan met [SaveFormat.Pptx](https://reference.aspose.com/slides/nl/python-java/aspose.slides/saveformat/#Pptx) om de presentatie naar een PPTX‑bestand te schrijven.

Het volgende Python‑voorbeeld importeert een PDF‑document en slaat de gegenereerde dia's op als een PowerPoint‑presentatie:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlides().addFromPdf("document.pdf")
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

De standaard lege dia blijft in de presentatie omdat de import dia's toevoegt. Om alleen de geïmporteerde pagina's te behouden, maak je de dia‑collectie leeg met [SlideCollection.clear](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidecollection/#clear) vóór het importeren.

De [addFromPdf](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidecollection/#addFromPdf) methode retourneert de dia's die hij toevoegt, wat handig is wanneer je alleen de geïmporteerde dia's moet verwerken.

{{% alert title="Tip" color="success" %}}
Probeer de gratis [PDF to PowerPoint](https://products.aspose.app/slides/nl/import/pdf-to-powerpoint) web‑app om deze conversiewerkstroom in actie te zien.
{{% /alert %}}

## **Importeren vanuit HTML**

Aspose.Slides kan ook dia's maken vanuit een HTML‑document. De bron kan worden aangeleverd als HTML‑tekst of een stream. De volgende stappen gebruiken een bestands‑stream:

1. Maak een nieuw [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) object aan.
2. Open het HTML‑bestand voor lezen en geef de stream door aan [addFromHtml](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidecollection/#addFromHtml).
3. Roep [save](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#save) aan met [SaveFormat.Pptx](https://reference.aspose.com/slides/nl/python-java/aspose.slides/saveformat/#Pptx) om het resultaat naar een PPTX‑bestand te schrijven.

Het volgende Python‑voorbeeld importeert een HTML‑document en slaat de gegenereerde dia's op als een PowerPoint‑presentatie:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.io import FileInputStream

presentation = Presentation()
try:
    html_stream = FileInputStream("page.html")
    try:
        presentation.getSlides().addFromHtml(html_stream)
    finally:
        html_stream.close()
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **HTML‑inhoud invoegen**

Gebruik [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidecollection/#insertFromHtml) wanneer HTML‑gegenereerde dia's op een specifieke positie moeten worden geplaatst in plaats van toegevoegd. De index is nul‑gebaseerd en geeft de positie aan waarop de import begint.

Het argument `useSlideWithIndexAsStart` bepaalt hoe de importeur die positie gebruikt:

- Wanneer het `False` is, maakt de importeur nieuwe dia's op de opgegeven index en verschuift de daarop volgende dia's.
- Wanneer het `True` is, begint de importeur de inhoud te plaatsen in de beschikbare ruimte op de bestaande dia op die index. Als de HTML niet past, pagina't Aspose.Slides het automatisch en voegt extra dia's direct na de startdia in.

[SlideCollection.insertFromHtml](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidecollection/#insertFromHtml) retourneert een array van [Slide](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slide/) objecten. Wanneer de invoeging start op nieuwe dia's, is elk geretourneerd item nieuw aangemaakt. Wanneer een bestaande dia wordt gebruikt als start, bevat de array die getroffen dia gevolgd door eventuele nieuwe overlappende dia's. Je kunt deze array inspecteren in plaats van het berekenen van het getroffen bereik op basis van het aantal dia's in de presentatie.

### **HTML invoegen als nieuwe dia's**

Het volgende voorbeeld levert HTML als een tekenreeks en voegt de gegenereerde dia's in op verzamelings‑index `1`. Het doorgeven van `False` laat de bestaande dia's ongewijzigd, behalve dat ze worden verschoven om ruimte te maken.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)

    insert_index = 1
    html = "<html><body><h1>Quarterly update</h1><p>This content is inserted before the slide that was at index 1.</p></body></html>"
    inserted_slides = presentation.getSlides().insertFromHtml(insert_index, html, False)

    for slide in inserted_slides:
        print("Inserted slide index:", presentation.getSlides().indexOf(slide))

    presentation.save("presentation-with-inserted-html.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Beginnen op een bestaande dia**

Het volgende voorbeeld levert de HTML via een stream. Het behoudt een koptekst‑vorm op de bestaande sjabloondia, begint met importeren onder het bezette gebied, en laat de lange body doorgaan op nieuwe dia's.

De HTML bevat ook een relatieve afbeelding‑URL. Een [ExternalResourceResolver](https://reference.aspose.com/slides/nl/python-java/aspose.slides/externalresourceresolver/) haalt de bron op, terwijl de basis‑URI de importeur vertelt hoe `images/logo.png` moet worden opgelost. In dit voorbeeld wordt verwacht dat dat bestand zich bevindt op `html-assets/images/logo.png`.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExternalResourceResolver, Presentation, SaveFormat, ShapeType
from java.io import ByteArrayInputStream

presentation = Presentation()
try:
    template_slide = presentation.getSlides().get_Item(0)
    header = template_slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 680, 60)
    header.getTextFrame().setText("Product roadmap")

    html_parts = ["<html><body><img src='images/logo.png' width='120' height='60'><h2>Roadmap details</h2>"]
    for item_index in range(1, 61):
        html_parts.append(f"<p style='font-size:24pt'>Roadmap item {item_index}: detailed implementation notes.</p>")
    html_parts.append("</body></html>")

    html = "".join(html_parts)
    html_data = html.encode("utf-8")
    resolver = ExternalResourceResolver()
    base_directory = Path("html-assets").resolve()
    base_uri = base_directory.as_uri() + "/"

    html_stream = ByteArrayInputStream(html_data)
    try:
        affected_slides = presentation.getSlides().insertFromHtml(0, html_stream, resolver, base_uri, True)
        for slide in affected_slides:
            print("Affected slide index:", presentation.getSlides().indexOf(slide))
    finally:
        html_stream.close()

    presentation.save("presentation-with-html-overflow.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Warning" color="warning" %}}
Een onbeperkte externe resource‑resolver kan lokale of netwerkbronnen lezen die door de HTML worden gerefereerd. Voor niet‑vertrouwde invoer moet je resource‑URL's valideren en sanitizen tegen een whitelist van toegestane schema's, mappen en hosts voordat je de HTML importeert.
{{% /alert %}}

## **FAQ**

**Kan Aspose.Slides tabellen detecteren bij het importeren van een PDF?**

Ja. Maak een [PdfImportOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/pdfimportoptions/) object aan, roep [setDetectTables](https://reference.aspose.com/slides/nl/python-java/aspose.slides/pdfimportoptions/#setDetectTables) aan met `True`, en geef de opties door aan [addFromPdf](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slidecollection/#addFromPdf). De kwaliteit van tabelherkenning hangt af van de structuur en complexiteit van de bron‑PDF.

{{% alert title="Note" color="info" %}}
Na het importeren van HTML kun je de dia's ook exporteren naar [images](/slides/nl/python-java/convert-powerpoint-to-png/), [TIFF](/slides/nl/python-java/convert-powerpoint-to-tiff/), of [SVG](/slides/nl/python-java/render-slide-as-svg/).
{{% /alert %}}