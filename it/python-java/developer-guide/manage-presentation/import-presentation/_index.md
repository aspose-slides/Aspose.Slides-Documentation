---
title: Importazione di presentazioni da PDF o HTML in Python tramite Java
linktitle: Importa presentazione
type: docs
weight: 60
url: /it/python-java/import-presentation/
keywords:
- importazione presentazione
- importazione diapositiva
- importazione PDF
- importazione HTML
- PDF a presentazione
- PDF a PPT
- PDF a PPTX
- PDF a ODP
- HTML a presentazione
- HTML a PPT
- HTML a PPTX
- HTML a ODP
- PowerPoint
- OpenDocument
- Python
- Java
- Aspose.Slides
description: "Scopri come importare contenuti PDF e HTML in presentazioni PowerPoint in Python tramite Java con Aspose.Slides e salvare i risultati come file PPTX."
---
## **Introduzione**

Aspose.Slides per Python tramite Java può trasformare pagine PDF o contenuti HTML in diapositive PowerPoint senza Microsoft PowerPoint. La classe [SlideCollection](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidecollection/) fornisce [addFromPdf](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidecollection/#addFromPdf) e [addFromHtml](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidecollection/#addFromHtml) per aggiungere contenuti importati a una presentazione.

Per un controllo maggiore sul posizionamento dell'HTML, [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidecollection/#insertFromHtml) può inserire le diapositive generate in un indice della collezione o iniziare a riempire lo spazio disponibile su una diapositiva esistente. L'HTML lungo viene paginato automaticamente su diapositive aggiuntive, la sorgente può essere fornita come stringa o stream e le risorse esterne possono essere caricate tramite [ExternalResourceResolver](https://reference.aspose.com/slides/it/python-java/aspose.slides/externalresourceresolver/) con un URI di base. L'array di [Slide](https://reference.aspose.com/slides/it/python-java/aspose.slides/slide/) restituito identifica le diapositive interessate e quelle appena create.

## **Importazione da PDF**

Per convertire un documento PDF in una presentazione PowerPoint, importa il suo contenuto nella collezione di diapositive e salva il risultato come file PPTX.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. Crea un nuovo oggetto [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
2. Chiama [addFromPdf](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidecollection/#addFromPdf) con il percorso del file PDF.
3. Chiama [save](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#save) con [SaveFormat.Pptx](https://reference.aspose.com/slides/it/python-java/aspose.slides/saveformat/#Pptx) per scrivere la presentazione in un file PPTX.

Il seguente esempio Python importa un documento PDF e salva le diapositive generate come presentazione PowerPoint:

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

La diapositiva vuota predefinita rimane nella presentazione perché l'importazione aggiunge diapositive. Per conservare solo le pagine importate, svuota la collezione di diapositive con [SlideCollection.clear](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidecollection/#clear) prima di importare.

Il metodo [addFromPdf](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidecollection/#addFromPdf) restituisce le diapositive che aggiunge, utile quando è necessario elaborare solo le diapositive importate.

{{% alert title="Tip" color="success" %}}
Prova l'app web gratuita [PDF to PowerPoint](https://products.aspose.app/slides/it/import/pdf-to-powerpoint) per vedere questo flusso di conversione in azione.
{{% /alert %}}

## **Importazione da HTML**

Aspose.Slides può anche creare diapositive da un documento HTML. La sorgente può essere fornita come testo HTML o come stream. I passaggi seguenti usano uno stream di file:

1. Crea un nuovo oggetto [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
2. Apri il file HTML in lettura e passa lo stream a [addFromHtml](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidecollection/#addFromHtml).
3. Chiama [save](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#save) con [SaveFormat.Pptx](https://reference.aspose.com/slides/it/python-java/aspose.slides/saveformat/#Pptx) per scrivere il risultato in un file PPTX.

Il seguente esempio Python importa un documento HTML e salva le diapositive generate come presentazione PowerPoint:

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

## **Inserimento contenuto HTML**

Utilizza [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidecollection/#insertFromHtml) quando le diapositive generate da HTML devono essere posizionate in un punto specifico anziché aggiunte in coda. L'indice è basato su zero e identifica la posizione in cui inizia l'importazione.

L'argomento `useSlideWithIndexAsStart` controlla come l'importatore usa tale posizione:

- Quando è `False`, l'importatore crea nuove diapositive all'indice specificato e sposta quelle successive.
- Quando è `True`, l'importatore inizia a posizionare il contenuto nello spazio disponibile sulla diapositiva esistente in quel indice. Se l'HTML non entra, Aspose.Slides lo pagina automaticamente e inserisce diapositive aggiuntive subito dopo la diapositiva di partenza.

[SlideCollection.insertFromHtml](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidecollection/#insertFromHtml) restituisce un array di oggetti [Slide](https://reference.aspose.com/slides/it/python-java/aspose.slides/slide/). Quando l'inserimento inizia su nuove diapositive, ogni elemento restituito è appena creato. Quando una diapositiva esistente è usata come punto di partenza, l'array include quella diapositiva interessata seguita da eventuali nuove diapositive di overflow. Puoi esaminare questo array invece di calcolare l'intervallo interessato dal conteggio delle diapositive della presentazione.

### **Inserimento HTML come nuove diapositive**

Il seguente esempio fornisce l'HTML come stringa e inserisce le diapositive generate all'indice della collezione `1`. Passare `False` lascia inalterate le diapositive esistenti, tranne lo spostamento necessario per fare spazio.

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

### **Inizio su una diapositiva esistente**

Il prossimo esempio fornisce l'HTML tramite uno stream. Mantiene una forma di intestazione sulla diapositiva modello esistente, avvia l'importazione sotto l'area occupata e consente al corpo lungo di continuare su nuove diapositive.

L'HTML contiene anche un URL immagine relativo. Un [ExternalResourceResolver](https://reference.aspose.com/slides/it/python-java/aspose.slides/externalresourceresolver/) ottiene la risorsa, mentre l'URI di base indica all'importatore come risolvere `images/logo.png`. In questo esempio, il file è previsto in `html-assets/images/logo.png`.

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
Un resolver di risorse esterne non limitato può leggere risorse locali o di rete richieste dall'HTML. Per input non attendibile, valida e sanitizza gli URL delle risorse rispetto a una whitelist di schemi, directory e host consentiti prima di importare l'HTML.
{{% /alert %}}

## **FAQ**

**Aspose.Slides può rilevare le tabelle durante l'importazione di un PDF?**

Sì. Crea un oggetto [PdfImportOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/pdfimportoptions/), chiama [setDetectTables](https://reference.aspose.com/slides/it/python-java/aspose.slides/pdfimportoptions/#setDetectTables) con `True` e passa le opzioni a [addFromPdf](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidecollection/#addFromPdf). La qualità del riconoscimento delle tabelle dipende dalla struttura e dalla complessità del PDF sorgente.

{{% alert title="Note" color="info" %}}
Dopo aver importato HTML, puoi anche esportare le diapositive in [images](/slides/it/python-java/convert-powerpoint-to-png/), [TIFF](/slides/it/python-java/convert-powerpoint-to-tiff/) o [SVG](/slides/it/python-java/render-a-slide-as-an-svg-image/).
{{% /alert %}}