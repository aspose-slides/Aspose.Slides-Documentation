---
title: Import prezentací z PDF nebo HTML v Pythonu pomocí Java
linktitle: Import prezentace
type: docs
weight: 60
url: /cs/python-java/import-presentation/
keywords:
- importovat prezentaci
- importovat snímek
- importovat PDF
- importovat HTML
- PDF na prezentaci
- PDF na PPT
- PDF na PPTX
- PDF na ODP
- HTML na prezentaci
- HTML na PPT
- HTML na PPTX
- HTML na ODP
- PowerPoint
- OpenDocument
- Python
- Java
- Aspose.Slides
description: "Zjistěte, jak importovat obsah PDF a HTML do prezentací PowerPoint v Pythonu prostřednictvím Java pomocí Aspose.Slides a uložit výsledky jako soubory PPTX."
---
## **Úvod**

Aspose.Slides pro Python prostřednictvím Java může převést stránky PDF nebo obsah HTML na snímky PowerPointu bez Microsoft PowerPoint. Třída [SlideCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidecollection/) poskytuje [addFromPdf](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidecollection/#addFromPdf) a [addFromHtml](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidecollection/#addFromHtml) pro přidání importovaného obsahu do prezentace.

Pro větší kontrolu nad umístěním HTML může [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidecollection/#insertFromHtml) vložit vygenerované snímky na index kolekce nebo začít zaplňovat dostupný prostor na existujícím snímku. Dlouhé HTML je automaticky rozděleno na další snímky, zdroj lze poskytnout jako řetězec nebo stream a externí zdroje lze načíst pomocí [ExternalResourceResolver](https://reference.aspose.com/slides/cs/python-java/aspose.slides/externalresourceresolver/) s základní URI. Vrácené pole [Slide](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slide/) identifikuje dotčené a nově vytvořené snímky.

## **Import z PDF**

Pro převod dokumentu PDF na prezentaci PowerPoint importujte jeho obsah do kolekce snímků a uložte výsledek jako soubor PPTX.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. Vytvořte nový objekt [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
2. Zavolejte [addFromPdf](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidecollection/#addFromPdf) s cestou k souboru PDF.
3. Zavolejte [save](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#save) s [SaveFormat.Pptx](https://reference.aspose.com/slides/cs/python-java/aspose.slides/saveformat/#Pptx) pro zápis prezentace do souboru PPTX.

Následující příklad v Pythonu importuje dokument PDF a uloží vygenerované snímky jako prezentaci PowerPoint:

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

Výchozí prázdný snímek zůstane v prezentaci, protože import přidává snímky. Pro zachování pouze importovaných stránek vymažte kolekci snímků metodou [SlideCollection.clear](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidecollection/#clear) před importem.

Metoda [addFromPdf](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidecollection/#addFromPdf) vrací snímky, které přidá, což je užitečné, pokud potřebujete zpracovat jen importované snímky.

{{% alert title="Tip" color="success" %}}
Vyzkoušejte bezplatnou webovou aplikaci PDF do PowerPoint, abyste viděli tento konverzní pracovní postup v akci.
{{% /alert %}}

## **Import z HTML**

Aspose.Slides může také vytvořit snímky z dokumentu HTML. Zdroj lze poskytnout jako text HTML nebo stream. Následující kroky používají souborový stream:

1. Vytvořte nový objekt [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
2. Otevřete soubor HTML pro čtení a předejte stream metodě [addFromHtml](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidecollection/#addFromHtml).
3. Zavolejte [save](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#save) s [SaveFormat.Pptx](https://reference.aspose.com/slides/cs/python-java/aspose.slides/saveformat/#Pptx) pro zápis výsledku do souboru PPTX.

Následující příklad v Pythonu importuje dokument HTML a uloží vygenerované snímky jako prezentaci PowerPoint:

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

## **Vložení HTML obsahu**

Použijte [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidecollection/#insertFromHtml), když je potřeba umístit snímky generované HTML na konkrétní pozici místo jejich připojení. Index je nulový a určuje pozici, kde import začne.

Argument `useSlideWithIndexAsStart` řídí, jak importér tuto pozici používá:

- Když je `False`, importér vytváří nové snímky na zadaném indexu a posouvá následující snímky.
- Když je `True`, importér začne umisťovat obsah do dostupného prostoru na existujícím snímku na tomto indexu. Pokud HTML nepadne, Aspose.Slides jej automaticky rozčlení a vloží další snímky ihned za úvodní snímek.

[SlideCollection.insertFromHtml](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidecollection/#insertFromHtml) vrací pole objektů [Slide](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slide/). Když vkládání začíná na nových snímcích, každý vrácený prvek je nově vytvořený. Když je jako výchozí použit existující snímek, pole obsahuje tento dotčený snímek následovaný všemi novými přetékajícími snímky. Místo výpočtu dotčeného rozsahu z počtu snímků prezentace můžete toto pole prozkoumat.

### **Vložení HTML jako nové snímky**

Následující příklad předává HTML jako řetězec a vkládá vygenerované snímky na index kolekce `1`. Předání `False` ponechá existující snímky nezměněné, pouze je posune, aby vzniklo místo.

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

### **Začátek na existujícím snímku**

Další příklad předává HTML prostřednictvím streamu. Zachovává tvar nadpisu na existujícím šablonovém snímku, začíná import pod obsazenou oblastí a umožňuje dlouhému tělu pokračovat na nové snímky.

HTML také obsahuje relativní URL obrázku. [ExternalResourceResolver](https://reference.aspose.com/slides/cs/python-java/aspose.slides/externalresourceresolver/) získá prostředek, zatímco základní URI říká importérovi, jak rozpoznat `images/logo.png`. V tomto příkladu se očekává, že soubor bude umístěn v `html-assets/images/logo.png`.

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
Neomezený externí resolver zdrojů může číst místní nebo síťové zdroje odkazované v HTML. Pro nedůvěryhodný vstup validujte a sanitizujte URL zdrojů proti seznamu povolených schémat, adresářů a hostitelů před importem HTML.
{{% /alert %}}

## **Často kladené otázky**

**Dokáže Aspose.Slides detekovat tabulky při importu PDF?**

Ano. Vytvořte objekt [PdfImportOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pdfimportoptions/), zavolejte [setDetectTables](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pdfimportoptions/#setDetectTables) s `True` a předáte možnosti metodě [addFromPdf](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidecollection/#addFromPdf). Kvalita rozpoznávání tabulek závisí na struktuře a složitosti původního PDF.

{{% alert title="Note" color="info" %}}
Po importu HTML můžete také exportovat snímky do [images](/slides/cs/python-java/convert-powerpoint-to-png/), [TIFF](/slides/cs/python-java/convert-powerpoint-to-tiff/) nebo [SVG](/slides/cs/python-java/render-slide-as-svg/).
{{% /alert %}}