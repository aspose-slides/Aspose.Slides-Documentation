---
title: Import Prezentací z PDF nebo HTML v Pythonu přes Java
linktitle: Import Prezentace
type: docs
weight: 60
url: /cs/python-java/import-presentation/
keywords:
- import prezentace
- import snímku
- import PDF
- import HTML
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
description: "Zjistěte, jak importovat obsah PDF a HTML do PowerPoint prezentací v Pythonu přes Java pomocí Aspose.Slides a uložit výsledky jako soubory PPTX."
---
## **Úvod**

Aspose.Slides for Python via Java dokáže převést stránky PDF nebo obsah HTML na snímky PowerPointu bez Microsoft PowerPointu. Třída [SlideCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidecollection/) poskytuje [addFromPdf](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidecollection/#addFromPdf) a [addFromHtml](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidecollection/#addFromHtml) pro přidání importovaného obsahu do prezentace.

Pro větší kontrolu nad umístěním HTML může [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidecollection/#insertFromHtml) vložit vygenerované snímky na index kolekce nebo začít vyplňovat dostupný prostor na existujícím snímku. Dlouhé HTML je automaticky rozděleno na další snímky, zdroj může být předán jako řetězec nebo proud a externí prostředky lze načíst pomocí [ExternalResourceResolver](https://reference.aspose.com/slides/cs/python-java/aspose.slides/externalresourceresolver/) s base URI. Vrácené pole [Slide](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slide/) identifikuje ovlivněné a nově vytvořené snímky.

## **Import z PDF**

Pro převod PDF dokumentu do PowerPoint prezentace importujte jeho obsah do kolekce snímků a uložte výsledek jako soubor PPTX.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. Vytvořte nový objekt [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
2. Zavolejte [addFromPdf](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidecollection/#addFromPdf) s cestou k PDF souboru.
3. Zavolejte [save](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#save) s [SaveFormat.Pptx](https://reference.aspose.com/slides/cs/python-java/aspose.slides/saveformat/#Pptx) pro zapsání prezentace do souboru PPTX.

Následující příklad v Pythonu importuje PDF dokument a uloží vygenerované snímky jako PowerPoint prezentaci:

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

Výchozí prázdný snímek zůstává v prezentaci, protože import přidává snímky. Chcete-li zachovat pouze importované stránky, před importem vyprázdněte kolekci snímků pomocí [SlideCollection.clear](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidecollection/#clear).

Metoda [addFromPdf](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidecollection/#addFromPdf) vrací snímky, které přidá, což je užitečné, pokud potřebujete zpracovat jen importované snímky.

{{% alert title="Tip" color="success" %}}
Vyzkoušejte bezplatnou webovou aplikaci [PDF do PowerPointu](https://products.aspose.app/slides/cs/import/pdf-to-powerpoint) a uvidíte tento převodní postup v praxi.
{{% /alert %}}

## **Import z HTML**

Aspose.Slides může také vytvářet snímky z HTML dokumentu. Zdroj může být předán jako text HTML nebo proud. Následující kroky používají souborový proud:

1. Vytvořte nový objekt [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
2. Otevřete HTML soubor pro čtení a předejte proud metodě [addFromHtml](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidecollection/#addFromHtml).
3. Zavolejte [save](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#save) s [SaveFormat.Pptx](https://reference.aspose.com/slides/cs/python-java/aspose.slides/saveformat/#Pptx) pro zápis výsledku do souboru PPTX.

Následující příklad v Pythonu importuje HTML dokument a uloží vygenerované snímky jako PowerPoint prezentaci:

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

## **Vložit HTML obsah**

Použijte [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidecollection/#insertFromHtml), pokud je třeba umístit snímky generované z HTML na konkrétní pozici místo jejich připojení. Index je nulou založený a určuje místo, kde import začíná.

Argument `useSlideWithIndexAsStart` řídí, jak importér tuto pozici používá:

- Když je `False`, importér vytvoří nové snímky na určeném indexu a posune následující snímky.
- Když je `True`, importér začne umisťovat obsah do dostupného prostoru na existujícím snímku na tomto indexu. Pokud HTML nepasuje, Aspose.Slides jej automaticky rozčlení a vloží další snímky ihned za úvodní snímek.

[SlideCollection.insertFromHtml](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidecollection/#insertFromHtml) vrací pole objektů [Slide](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slide/). Když se vkládá na nové snímky, každý vrácený prvek je nově vytvořený. Když je jako výchozí použit existující snímek, pole zahrnuje tento ovlivněný snímek a následně všechny nové přetečící snímky. Místo výpočtu ovlivněného rozsahu z celkového počtu snímků můžete prozkoumat toto pole.

### **Vložit HTML jako nové snímky**

Následující příklad předává HTML jako řetězec a vkládá vygenerované snímky na index kolekce `1`. Předání `False` ponechává existující snímky beze změny, jen je posune, aby vytvořilo místo.

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

### **Začít na existujícím snímku**

Další příklad předává HTML pomocí proudu. Zachová tvar záhlaví na existujícím šablonovém snímku, začne import pod obsazenou oblastí a nechá dlouhé tělo pokračovat na nové snímky.

HTML také obsahuje relativní URL obrázku. [ExternalResourceResolver](https://reference.aspose.com/slides/cs/python-java/aspose.slides/externalresourceresolver/) získá prostředek, zatímco base URI řekne importérovi, jak vyřešit `images/logo.png`. V tomto příkladu se očekává, že soubor bude na `html-assets/images/logo.png`.

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
Neomezený externí resolver prostředků může číst místní nebo síťové zdroje odkazované v HTML. Pro nedůvěryhodný vstup ověřte a očistěte URL prostředků podle seznamu povolených schémat, adresářů a hostitelů před importem HTML.
{{% /alert %}}

## **Často kladené otázky**

**Dokáže Aspose.Slides při importu PDF detekovat tabulky?**

Ano. Vytvořte objekt [PdfImportOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pdfimportoptions/), zavolejte [setDetectTables](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pdfimportoptions/#setDetectTables) s hodnotou `True` a předávejte tyto možnosti metodě [addFromPdf](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidecollection/#addFromPdf). Kvalita rozpoznání tabulek závisí na struktuře a složitosti zdrojového PDF.

{{% alert title="Note" color="info" %}}
Po importu HTML můžete také exportovat snímky do [images](/slides/cs/python-java/convert-powerpoint-to-png/), [TIFF](/slides/cs/python-java/convert-powerpoint-to-tiff/) nebo [SVG](/slides/cs/python-java/render-a-slide-as-an-svg-image/).
{{% /alert %}}