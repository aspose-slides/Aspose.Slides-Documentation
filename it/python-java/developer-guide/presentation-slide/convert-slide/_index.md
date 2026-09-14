---
title: Converti diapositive della presentazione in immagini in Python
linktitle: Diapositiva in immagine
type: docs
weight: 35
url: /it/python-java/convert-slide/
keywords: 
- converti diapositiva
- esporta diapositiva
- diapositiva in immagine
- salva diapositiva come immagine
- diapositiva in EMF
- diapositiva in PNG
- diapositiva in JPEG
- diapositiva in bitmap
- diapositiva in TIFF
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Converti diapositive da presentazioni PPT, PPTX e ODP in PNG, JPEG, GIF, TIFF, EMF e altri formati immagine in Python con Aspose.Slides."
---
## **Introduzione**

Aspose.Slides per Python via Java può rendere singole diapositive da presentazioni PowerPoint e OpenDocument come PNG, JPEG, GIF, TIFF e altri formati immagine.

Per convertire una diapositiva in un'immagine, segui questi passaggi:

1. Carica la presentazione con la classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
2. Seleziona la diapositiva che desideri rendere.
3. Se necessario, configura il rendering con la classe [RenderingOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/renderingoptions/) o [TiffOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/tiffoptions/).
4. Chiama il metodo [Slide.getImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/slide/#getImage). Restituisce un oggetto immagine.
5. Salva l'immagine e specifica il formato di output con un valore [ImageFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/imageformat/).

## **Convertire una diapositiva in un'immagine PNG**

La conversione più semplice utilizza le impostazioni predefinite di rendering. L'oggetto immagine risultante può essere elaborato in memoria o salvato su file.

Il seguente esempio Python rende la prima diapositiva e la salva come immagine PNG:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("Presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage()
    try:
        image.save("Slide_0.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **Convertire diapositive in immagini con dimensioni personalizzate**

Usa la versione sovraccaricata di [Slide.getImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/slide/#getImage) che accetta un valore [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) per rendere una diapositiva con dimensioni pixel esatte.

Il seguente esempio crea un'immagine JPEG 1820 × 1040:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

image_size = Dimension(1820, 1040)

presentation = Presentation("Presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage(image_size)
    try:
        image.save("Slide_0.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **Convertire diapositive con note e commenti in immagini**

Per impostazione predefinita, le immagini delle diapositive non includono note o commenti. Passa un oggetto [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/notescommentslayoutingoptions/) al metodo [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) per controllare dove appaiono note e commenti.

Il seguente esempio posiziona note troncate sotto la diapositiva e commenti a destra della stessa:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, Presentation, RenderingOptions
from java.awt import Color

scale_x = 2.0
scale_y = scale_x

comments_area_color = Color(250, 235, 215)

layout_options = NotesCommentsLayoutingOptions()
layout_options.setNotesPosition(NotesPositions.BottomTruncated)
layout_options.setCommentsPosition(CommentsPositions.Right)
layout_options.setCommentsAreaWidth(500)
layout_options.setCommentsAreaColor(comments_area_color)

rendering_options = RenderingOptions()
rendering_options.setSlidesLayoutOptions(layout_options)

presentation = Presentation("Presentation_with_notes_and_comments.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage(rendering_options, scale_x, scale_y)
    try:
        image.save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

{{% alert title="Warning" color="warning" %}}
Per la conversione da diapositiva a immagine, non passare [BottomFull](https://reference.aspose.com/slides/it/python-java/aspose.slides/notespositions/#BottomFull) al metodo [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/it/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). Le note possono contenere più testo di quanto la dimensione fissa dell'immagine possa contenere. Usa invece [BottomTruncated](https://reference.aspose.com/slides/it/python-java/aspose.slides/notespositions/#BottomTruncated).
{{% /alert %}}

## **Convertire diapositive in immagini usando le opzioni TIFF**

La classe [TiffOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/tiffoptions/) consente di controllare le dimensioni, la risoluzione e altre proprietà dell'immagine TIFF renderizzata.

Il seguente esempio rende la prima diapositiva come immagine TIFF 2160 × 2880 a 300 DPI:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, TiffOptions
from java.awt import Dimension

image_size = Dimension(2160, 2880)

tiff_options = TiffOptions()
tiff_options.setImageSize(image_size)
tiff_options.setDpiX(300)
tiff_options.setDpiY(300)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    image = slide.getImage(tiff_options)
    try:
        image.save("output.tiff", ImageFormat.Tiff)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

{{% alert title="Warning" color="warning" %}}
Il supporto TIFF non è garantito nelle versioni Java precedenti a JDK 9.
{{% /alert %}}

## **Convertire tutte le diapositive in immagini**

Itera attraverso la collezione di diapositive per convertire l'intera presentazione in una serie di immagini. Le diapositive nascoste sono incluse a meno che non le salti esplicitamente.

Il seguente esempio rende ogni diapositiva come immagine JPEG con fattori di scala orizzontale e verticale pari a 2:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

scale_x = 2.0
scale_y = scale_x

presentation = Presentation("Presentation.pptx")
try:
    slide_count = presentation.getSlides().size()
    for index in range(slide_count):
        slide = presentation.getSlides().get_Item(index)
        image = slide.getImage(scale_x, scale_y)
        try:
            image.save(f"Slide_{index}.jpg", ImageFormat.Jpeg)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

## **Creare output Enhanced Metafile**

Enhanced Metafile (EMF) è utile quando è necessario scambiare grafiche vettoriali con Microsoft Office o altre applicazioni Windows che supportano i metafile Windows. A differenza di un'immagine basata su pixel, un EMF può conservare le operazioni di disegno vettoriale che si scalano senza la stessa perdita di nitidezza. Tuttavia, EMF è principalmente un formato di compatibilità per applicazioni con supporto ai metafile Windows, non un formato di interscambio universale. Inoltre, contenuti complessi delle diapositive, come immagini bitmap e alcuni effetti, possono essere memorizzati come elementi rasterizzati all'interno del contenitore vettoriale del metafile.

### **Esportare una diapositiva in EMF**

Il metodo [Slide.writeAsEmf](https://reference.aspose.com/slides/it/python-java/aspose.slides/slide/) scrive una [Slide](https://reference.aspose.com/slides/it/python-java/aspose.slides/slide/) in un flusso di destinazione in formato EMF. Il seguente esempio carica una presentazione, seleziona la prima diapositiva e la scrive in un flusso di file EMF:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.io import FileOutputStream

presentation = Presentation("Presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    emf_stream = FileOutputStream("Slide_0.emf")
    try:
        slide.writeAsEmf(emf_stream)
    finally:
        emf_stream.close()
finally:
    presentation.dispose()
```

Chi chiama possiede il flusso passato a [Slide.writeAsEmf](https://reference.aspose.com/slides/it/python-java/aspose.slides/slide/) ed è responsabile della sua chiusura, come mostrato sopra.

### **Convertire un'immagine SVG in EMF e aggiungerla a una presentazione**

Usa [SvgImage.writeAsEmf](https://reference.aspose.com/slides/it/python-java/aspose.slides/svgimage/) per convertire il contenuto SVG in EMF. I byte risultanti possono essere aggiunti alla presentazione tramite [ImageCollection.addImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/imagecollection/#addImage) e posizionati su una diapositiva con [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapecollection/#addPictureFrame).

Il seguente esempio crea un [SvgImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/svgimage/) dal markup SVG, lo converte in un EMF in memoria, inserisce il metafile nella prima diapositiva e salva la presentazione:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType, SvgImage
from java.io import ByteArrayOutputStream

svg_content = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>"
svg_image = SvgImage(svg_content)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    emf_stream = ByteArrayOutputStream()
    try:
        svg_image.writeAsEmf(emf_stream)

        emf_data = emf_stream.toByteArray()
        image = presentation.getImages().addImage(emf_data)
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 100, image)
    finally:
        emf_stream.close()

    presentation.save("Presentation_with_emf.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[SvgImage.writeAsEmf](https://reference.aspose.com/slides/it/python-java/aspose.slides/svgimage/) non assume la proprietà del flusso di destinazione. Un [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) memorizza tutti i dati generati in memoria, quindi non è necessario resettare la posizione prima di chiamare [ByteArrayOutputStream.toByteArray](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html#toByteArray--). L'array di byte restituito rimane valido dopo la chiusura del flusso.

La generazione di EMF è disponibile sui sistemi operativi supportati dalla versione di Aspose.Slides per Python via Java e dalla configurazione JDK selezionata, ma il rendering può differire tra piattaforme quando i font o le dipendenze grafiche non sono disponibili. Installa i font utilizzati dal contenuto di origine o configura sostituzioni adeguate, segui i [requisiti di piattaforma](/slides/it/python-java/system-requirements/) per Aspose.Slides per Python via Java e verifica il risultato nell'applicazione di destinazione che consuma EMF. Le applicazioni Linux e macOS spesso hanno un supporto limitato o incoerente per la visualizzazione e la modifica dei metafile Windows.

## **Rendering di Emoji a colori**

{{% alert title="Note" color="info" %}}
Per rendere correttamente le emoji a colori durante la conversione delle diapositive di una presentazione in immagini, i font delle emoji utilizzati nella presentazione devono essere installati e disponibili sul sistema che esegue la conversione. Ad esempio, se la presentazione utilizza **Segoe UI Emoji** e questo font è assente, le emoji potrebbero comparire in bianco e nero nelle immagini di output.
{{% /alert %}}

## **FAQ**

**Aspose.Slides supporta il rendering di diapositive con animazioni?**

No. Il metodo [Slide.getImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/slide/#getImage) genera un'immagine statica della diapositiva e non esporta le animazioni.

**Le diapositive nascoste possono essere esportate come immagini?**

Sì. Le diapositive nascoste possono essere renderizzate come diapositive normali. Includile nel ciclo di elaborazione, come mostrato nell'esempio precedente.

**Ombre e altri effetti sono preservati nelle immagini delle diapositive?**

Sì. Aspose.Slides renderizza ombre, trasparenza e altri effetti grafici supportati nelle immagini delle diapositive.