---
title: Importera presentationer från PDF eller HTML i Python via Java
linktitle: Importera presentation
type: docs
weight: 60
url: /sv/python-java/import-presentation/
keywords:
- importera presentation
- importera bild
- importera PDF
- importera HTML
- PDF till presentation
- PDF till PPT
- PDF till PPTX
- PDF till ODP
- HTML till presentation
- HTML till PPT
- HTML till PPTX
- HTML till ODP
- PowerPoint
- OpenDocument
- Python
- Java
- Aspose.Slides
description: "Lär dig hur du importerar PDF- och HTML-innehåll till PowerPoint-presentationer i Python via Java med Aspose.Slides och sparar resultatet som PPTX-filer."
---
## **Introduktion**

Aspose.Slides for Python via Java kan konvertera PDF‑sidor eller HTML‑innehåll till PowerPoint‑bilder utan Microsoft PowerPoint. Klassen [SlideCollection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slidecollection/) tillhandahåller [addFromPdf](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slidecollection/#addFromPdf) och [addFromHtml](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slidecollection/#addFromHtml) för att lägga till importerat innehåll i en presentation.

För mer kontroll över HTML‑placering kan [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slidecollection/#insertFromHtml) infoga genererade bilder på ett samlingsindex eller börja fylla tillgängligt utrymme på en befintlig bild. Lång HTML pagineras automatiskt över ytterligare bilder, källan kan anges som en sträng eller ström, och externa resurser kan laddas via [ExternalResourceResolver](https://reference.aspose.com/slides/sv/python-java/aspose.slides/externalresourceresolver/) med en bas‑URI. Den returnerade [Slide](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slide/)‑arrayen identifierar de påverkade och nyss skapade bilderna.

## **Importera från PDF**

För att konvertera ett PDF‑dokument till en PowerPoint‑presentation, importera dess innehåll till bildsamlingen och spara resultatet som en PPTX‑fil.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. Skapa ett nytt [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/)‑objekt.
2. Anropa [addFromPdf](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slidecollection/#addFromPdf) med sökvägen till PDF‑filen.
3. Anropa [save](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#save) med [SaveFormat.Pptx](https://reference.aspose.com/slides/sv/python-java/aspose.slides/saveformat/#Pptx) för att skriva presentationen till en PPTX‑fil.

Följande Python‑exempel importerar ett PDF‑dokument och sparar de genererade bilderna som en PowerPoint‑presentation:

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

Den förvalda tomma bilden finns kvar i presentationen eftersom importen lägger till bilder. För att behålla endast importerade sidor, rensa bildsamlingen med [SlideCollection.clear](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slidecollection/#clear) innan import.

Metoden [addFromPdf](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slidecollection/#addFromPdf) returnerar de bilder den lägger till, vilket är användbart när du bara behöver bearbeta de importerade bilderna.

{{% alert title="Tip" color="success" %}}
Prova den kostnadsfria [PDF to PowerPoint](https://products.aspose.app/slides/sv/import/pdf-to-powerpoint)‑webbappen för att se detta konverteringsflöde i praktiken.
{{% /alert %}}

## **Importera från HTML**

Aspose.Slides kan också skapa bilder från ett HTML‑dokument. Källan kan anges som HTML‑text eller en ström. Följande steg använder en filström:

1. Skapa ett nytt [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/)‑objekt.
2. Öppna HTML‑filen för läsning och skicka strömmen till [addFromHtml](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slidecollection/#addFromHtml).
3. Anropa [save](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#save) med [SaveFormat.Pptx](https://reference.aspose.com/slides/sv/python-java/aspose.slides/saveformat/#Pptx) för att skriva resultatet till en PPTX‑fil.

Följande Python‑exempel importerar ett HTML‑dokument och sparar de genererade bilderna som en PowerPoint‑presentation:

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

## **Infoga HTML‑innehåll**

Använd [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slidecollection/#insertFromHtml) när HTML‑genererade bilder måste placeras på en specifik position istället för att läggas till. Indexet är nollbaserat och identifierar positionen där importen startar.

Argumentet `useSlideWithIndexAsStart` styr hur importören använder den positionen:

- När det är `False` skapar importören nya bilder på det angivna indexet och flyttar de bilder som följer efter dem.
- När det är `True` börjar importören placera innehåll i det lediga utrymmet på den befintliga bilden på det indexet. Om HTML‑innehållet inte får plats paginerar Aspose.Slides det automatiskt och infogar ytterligare bilder omedelbart efter startbilden.

[SlideCollection.insertFromHtml](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slidecollection/#insertFromHtml) returnerar en array av [Slide](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slide/)‑objekt. När infogning sker på nya bilder är varje returnerat objekt nyss skapat. När en befintlig bild används som start, innehåller arrayen den påverkade bilden följt av eventuella nya överskottsbilder. Du kan undersöka denna array i stället för att beräkna det påverkade intervallet från presentationens bildantal.

### **Infoga HTML som nya bilder**

Följande exempel anger HTML som en sträng och infogar de genererade bilderna på samlingsindexet `1`. Att skicka `False` lämnar de befintliga bilderna oförändrade förutom att de flyttas för att göra plats.

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

### **Starta på en befintlig bild**

Nästa exempel levererar HTML via en ström. Det behåller en rubrikform på den befintliga mallbilden, startar importen under det upptagna området och låter den långa kroppen fortsätta på nya bilder.

HTML‑innehållet innehåller också en relativ bild‑URL. En [ExternalResourceResolver](https://reference.aspose.com/slides/sv/python-java/aspose.slides/externalresourceresolver/) hämtar resursen, medan bas‑URI:n talar om för importören hur `images/logo.png` ska lösas. I detta exempel förväntas filen finnas på `html-assets/images/logo.png`.

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
En obegränsad extern resurshanterare kan läsa lokala eller nätverksresurser som refereras i HTML. För opålitlig input, validera och sanera resurs‑URL:er mot en vitlista av tillåtna scheman, kataloger och värdar innan HTML‑importen sker.
{{% /alert %}}

## **FAQ**

**Kan Aspose.Slides upptäcka tabeller när en PDF importeras?**

Ja. Skapa ett [PdfImportOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/pdfimportoptions/)‑objekt, anropa [setDetectTables](https://reference.aspose.com/slides/sv/python-java/aspose.slides/pdfimportoptions/#setDetectTables) med `True`, och skicka alternativet till [addFromPdf](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slidecollection/#addFromPdf). Kvaliteten på tabelligenkänning beror på strukturen och komplexiteten i käll‑PDF‑filen.

{{% alert title="Note" color="info" %}}
Efter att ha importerat HTML kan du även exportera bilderna till [images](/slides/sv/python-java/convert-powerpoint-to-png/), [TIFF](/slides/sv/python-java/convert-powerpoint-to-tiff/), eller [SVG](/slides/sv/python-java/render-slide-as-svg/).
{{% /alert %}}