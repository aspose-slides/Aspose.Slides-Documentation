---
title: Gestisci gli oggetti inchiostro di presentazione in Python tramite Java
linktitle: Gestisci Inchiostro
type: docs
weight: 95
url: /it/python-java/manage-ink/
keywords:
- inchiostro
- oggetto inchiostro
- traccia inchiostro
- gestire inchiostro
- disegnare inchiostro
- disegno
- esportazione inchiostro
- rendering inchiostro
- nascondere inchiostro
- InkOptions
- PowerPoint
- presentazione
- Python
- Java
- Aspose.Slides
description: "Gestisci gli oggetti inchiostro di PowerPoint, modifica le tracce e le proprietà del pennello, e controlla l'aspetto dell'inchiostro durante l'esportazione in PDF, HTML, SVG, TIFF e immagine con Aspose.Slides per Python tramite Java."
---
## **Introduzione**

PowerPoint offre una funzionalità di inchiostro che consente di disegnare tratti liberi. L'inchiostro può essere usato per evidenziare altri oggetti, mostrare connessioni e processi e attirare l'attenzione su elementi specifici di una diapositiva.

Aspose.Slides fornisce i tipi necessari per lavorare con gli oggetti inchiostro. Ad esempio, la classe [Ink](https://reference.aspose.com/slides/it/python-java/aspose.slides/ink/) rappresenta un oggetto inchiostro su una diapositiva.

## **Differenze tra oggetti normali e oggetti inchiostro**

Gli oggetti su una diapositiva PowerPoint sono tipicamente rappresentati da oggetti forma. Nella forma più semplice, una forma è un contenitore che definisce l'area dell'oggetto stesso (il suo riquadro) insieme a proprietà come la dimensione del contenitore, la forma e lo sfondo. Per ulteriori informazioni, vedere [Shape Layout Format](/slides/it/python-java/shape-manipulations/#access-layout-formats-for-shape).

Tuttavia, quando PowerPoint gestisce un oggetto inchiostro, ignora tutte le proprietà del riquadro dell'oggetto (contenitore) tranne la sua dimensione. La dimensione dell'area del contenitore è determinata dai metodi standard [Shape.getWidth](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#getWidth) e [Shape.getHeight](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#getHeight):

![ink_powerpoint1](ink_powerpoint1.png)

## **Tracce di inchiostro**

Una traccia di inchiostro è un elemento base usato per registrare la traiettoria di una penna mentre l'utente scrive inchiostro digitale. Una traccia memorizza una sequenza di punti connessi.

La forma più semplice di codifica specifica le coordinate X e Y di ogni punto campione. Quando tutti i punti connessi vengono visualizzati, producono un'immagine come questa:

![ink_powerpoint2](ink_powerpoint2.png)

## **Proprietà del pennello per il disegno**

Un pennello è usato per tracciare linee che collegano i punti di una traccia di inchiostro. Il pennello ha il proprio colore e dimensione, rappresentati dai metodi [InkBrush.getColor](https://reference.aspose.com/slides/it/python-java/aspose.slides/inkbrush/#getColor) e [InkBrush.getSize](https://reference.aspose.com/slides/it/python-java/aspose.slides/inkbrush/#getSize).

### **Impostare il colore del pennello inchiostro**

Questo codice Python mostra come impostare il colore di un pennello inchiostro:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Ink

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("pres.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ink = slide.getShapes().get_Item(0)
    if isinstance(ink, Ink):
        traces = ink.getTraces()
        if len(traces) > 0:
            brush = traces[0].getBrush()
            brush.setColor(Color.RED)
        else:
            print("The ink object has no traces.")
    else:
        print("The first shape is not an ink object.")
finally:
    presentation.dispose()
```

### **Impostare la dimensione del pennello inchiostro**

Questo codice Python mostra come impostare la dimensione di un pennello inchiostro:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Ink

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("pres.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ink = slide.getShapes().get_Item(0)
    if isinstance(ink, Ink):
        traces = ink.getTraces()
        if len(traces) > 0:
            brush = traces[0].getBrush()
            brush_size = Dimension(5, 10)
            brush.setSize(brush_size)
        else:
            print("The ink object has no traces.")
    else:
        print("The first shape is not an ink object.")
finally:
    presentation.dispose()
```

In generale, la larghezza e l'altezza di un pennello non corrispondono, quindi PowerPoint non visualizza la dimensione del pennello (la sezione dati corrispondente è grigia). Quando larghezza e altezza del pennello corrispondono, PowerPoint visualizza la sua dimensione in questo modo:

![ink_powerpoint3](ink_powerpoint3.png)

Per chiarezza, aumentiamo l'altezza dell'oggetto inchiostro e rivediamo le dimensioni importanti:

![ink_powerpoint4](ink_powerpoint4.png)

Il contenitore (riquadro) non tiene conto della dimensione dei pennelli—presume sempre che lo spessore della linea sia zero (vedi l'immagine precedente).

Pertanto, per determinare l'area visibile dell'intero oggetto inchiostro, è necessario considerare la dimensione del pennello delle sue tracce. Qui, l'oggetto di destinazione (la traccia di testo scritto a mano) è stato ridimensionato alla dimensione del contenitore (riquadro). Quando la dimensione del contenitore cambia, la dimensione del pennello rimane costante, e viceversa.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint utilizza un comportamento simile per gli oggetti testo:

![ink_powerpoint6](ink_powerpoint6.png)

## **Controllare l'aspetto dell'inchiostro durante l'esportazione e il rendering**

Aspose.Slides fornisce la classe [InkOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/inkoptions/) per controllare come gli oggetti inchiostro appaiono nell'output esportato o renderizzato. È possibile usare le sue proprietà per nascondere completamente l'inchiostro o modificare il modo in cui le operazioni di maschera del pennello inchiostro vengono interpretate.

Le opzioni inchiostro sono disponibili tramite le opzioni di esportazione o rendering per diversi tipi di output:

| Output | Proprietà delle opzioni Ink |
| --- | --- |
| PDF | [PdfOptions.getInkOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/pdfoptions/#getInkOptions) |
| HTML | [HtmlOptions.getInkOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/htmloptions/#getInkOptions) |
| SVG | [SVGOptions.getInkOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/svgoptions/#getInkOptions) |
| TIFF | [TiffOptions.getInkOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/tiffoptions/#getInkOptions) |
| Immagine diapositiva | [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/renderingoptions/#getInkOptions) |

I seguenti metodi di [InkOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/inkoptions/) espongono le stesse due impostazioni:

- [getHideInk](https://reference.aspose.com/slides/it/python-java/aspose.slides/inkoptions/#getHideInk) determina se gli oggetti inchiostro sono inclusi nell'output. Il valore predefinito è `False`.
- [getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/it/python-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) determina se un'operazione di maschera è interpretata come opacità durante il rendering di un pennello inchiostro. Il valore predefinito è `True`; chiamare [setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/it/python-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) con `False` per usare l'operazione ROP invece.

### **Nascondere gli oggetti inchiostro nell'output PDF**

Per impostazione predefinita, gli oggetti inchiostro rimangono visibili durante l'esportazione. Per creare un output pulito senza annotazioni scritte a mano o altri contenuti inchiostro, chiamare [InkOptions.setHideInk](https://reference.aspose.com/slides/it/python-java/aspose.slides/inkoptions/#setHideInk) con `True`.

Il seguente esempio Python esporta una presentazione in PDF nascondendo tutti gli oggetti inchiostro:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PdfOptions, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.getInkOptions().setHideInk(True)

    presentation.save("presentation_without_ink.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Nascondere gli oggetti inchiostro durante il rendering di una diapositiva come immagine**

Per nascondere gli oggetti inchiostro quando si renderizzano le diapositive come immagini bitmap, configurare [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/renderingoptions/#getInkOptions) e passare le opzioni di rendering a [Slide.getImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/slide/#getImage).

Il seguente esempio Python renderizza la prima diapositiva come immagine PNG senza oggetti inchiostro:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RenderingOptions, ImageFormat

presentation = Presentation("presentation.pptx")
try:
    rendering_options = RenderingOptions()
    rendering_options.getInkOptions().setHideInk(True)

    slide = presentation.getSlides().get_Item(0)
    image = slide.getImage(rendering_options)
    try:
        image.save("slide_without_ink.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

### **Controllare il rendering della maschera di inchiostro**

L'impostazione [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/it/python-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) controlla come le operazioni di maschera sono interpretate durante il rendering dei pennelli inchiostro. Il valore predefinito è `True`, che utilizza l'opacità. Per usare l'operazione ROP invece, chiamare [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/it/python-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) con `False`.

Il seguente esempio Python esporta una diapositiva in SVG e utilizza il rendering basato su ROP per le operazioni di maschera di inchiostro:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions

FileOutputStream = jpype.JClass("java.io.FileOutputStream")

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.getInkOptions().setInterpretMaskOpAsOpacity(False)

    stream = FileOutputStream("slide.svg")
    try:
        slide = presentation.getSlides().get_Item(0)
        slide.writeAsSvg(stream, svg_options)
    finally:
        stream.close()
finally:
    presentation.dispose()
```

La stessa impostazione può essere applicata tramite [TiffOptions.getInkOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/tiffoptions/#getInkOptions) durante l'esportazione di una presentazione o il rendering di una diapositiva in TIFF.

### **Scegliere se nascondere o preservare l'inchiostro**

Quando è necessaria una versione pulita di una presentazione annotata per la distribuzione senza segni di revisione, chiamare [InkOptions.setHideInk](https://reference.aspose.com/slides/it/python-java/aspose.slides/inkoptions/#setHideInk) con `True` durante l'esportazione.

Mantenere [InkOptions.getHideInk](https://reference.aspose.com/slides/it/python-java/aspose.slides/inkoptions/#getHideInk) al valore predefinito `False` quando le annotazioni inchiostro fanno parte del contenuto previsto, come commenti di revisione, note scritte a mano, evidenziazioni o disegni che devono rimanere visibili nel risultato esportato. Questo consente alle applicazioni di generare uscite di revisione e finali separate dalla stessa presentazione senza modificare gli oggetti inchiostro di origine.

## **FAQ**

**Posso cambiare il colore o la dimensione di una traccia di inchiostro esistente?**

Sì. Ottenere la traccia da [Ink.getTraces](https://reference.aspose.com/slides/it/python-java/aspose.slides/ink/#getTraces), quindi modificare il suo [InkTrace.getBrush](https://reference.aspose.com/slides/it/python-java/aspose.slides/inktrace/#getBrush). Chiamare [InkBrush.setColor](https://reference.aspose.com/slides/it/python-java/aspose.slides/inkbrush/#setColor) o [InkBrush.setSize](https://reference.aspose.com/slides/it/python-java/aspose.slides/inkbrush/#setSize) per cambiare il pennello.

**Nascondere l'inchiostro modifica la presentazione di origine?**

No. Chiamare [InkOptions.setHideInk](https://reference.aspose.com/slides/it/python-java/aspose.slides/inkoptions/#setHideInk) influisce solo sul risultato renderizzato o esportato; non rimuove né modifica gli oggetti inchiostro nella presentazione di origine.

**Quali formati di esportazione supportano le opzioni inchiostro?**

È possibile configurare le opzioni inchiostro per PDF, HTML, SVG, TIFF e immagini bitmap delle diapositive tramite le relative opzioni di esportazione o rendering mostrati sopra.

**Ulteriori letture**

* Per informazioni generali sulle forme, vedere la sezione [PowerPoint Shapes](/slides/it/python-java/powerpoint-shapes/).
* Per ulteriori dettagli sui valori effettivi, vedere [Shape Effective Properties](/slides/it/python-java/shape-effective-properties/#get-effective-font-height-value).
* Per dettagli sull'esportazione PDF, vedere [Convert PPT and PPTX to PDF](/slides/it/python-java/convert-powerpoint-to-pdf/).
* Per dettagli sull'esportazione HTML, vedere [Convert PowerPoint Presentations to HTML](/slides/it/python-java/convert-powerpoint-to-html/).
* Per dettagli sull'esportazione SVG, vedere [Render Presentation Slides as SVG Images](/slides/it/python-java/render-a-slide-as-an-svg-image/).
* Per dettagli sull'esportazione TIFF, vedere [Convert PowerPoint Presentations to TIFF](/slides/it/python-java/convert-powerpoint-to-tiff/).
* Per dettagli sul rendering diapositiva‑immagine, vedere [Convert Presentation Slides to Images](/slides/it/python-java/convert-slide/).