---
title: Gestisci lo Zoom della presentazione in Python via Java
linktitle: Gestisci Zoom
type: docs
weight: 60
url: /it/python-java/manage-zoom/
keywords:
- zoom
- frame zoom
- zoom diapositiva
- zoom sezione
- zoom riepilogo
- aggiungi zoom
- PowerPoint
- presentazione
- Python
- Java
- Aspose.Slides
description: "Crea e personalizza lo Zoom con Aspose.Slides per Python via Java — passa tra le sezioni, aggiungi miniature e transizioni in presentazioni PPT, PPTX e ODP."
---
## **Introduzione**

Gli Zoom in PowerPoint consentono di passare da e verso diapositive, sezioni e parti specifiche di una presentazione. Quando presenti, questa capacità di navigare rapidamente tra i contenuti può rivelarsi molto utile.

![overview_image](overview.png)

* Per riepilogare un'intera presentazione in un'unica diapositiva, usa uno [Zoom di riepilogo](#summary-zoom).
* Per mostrare solo le diapositive selezionate, usa uno [Zoom diapositiva](#slide-zoom).
* Per mostrare una singola sezione, usa uno [Zoom sezione](#section-zoom).

## **Zoom diapositiva**
Uno zoom diapositiva può rendere la tua presentazione più dinamica, consentendo di navigare liberamente tra le diapositive in qualsiasi ordine tu scelga senza interrompere il flusso della presentazione. Gli zoom diapositiva sono ottimi per presentazioni brevi senza molte sezioni, ma è possibile usarli comunque in diversi scenari di presentazione.

Gli zoom diapositiva ti aiutano a approfondire più informazioni mantenendo l'impressione di essere su un'unica tela.

![overview_image](slidezoomsel.png)

Per gli oggetti zoom diapositiva, Aspose.Slides fornisce l'enumerazione ZoomImageType, la classe ZoomFrame e alcuni metodi nella classe ShapeCollection.

### **Crea frame zoom**

Puoi aggiungere un frame zoom su una diapositiva in questo modo:

1. Crea un'istanza della classe Presentation.
2. Crea nuove diapositive a cui intendi collegare i frame zoom.
3. Aggiungi testo identificativo e sfondo alle diapositive create.
4. Aggiungi i frame zoom (contenenti i riferimenti alle diapositive create) alla prima diapositiva.
5. Salva la presentazione modificata come file PPTX.

Questo codice Python mostra come creare un frame zoom su una diapositiva:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # Aggiunge nuove diapositive alla presentazione
    second_slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    third_slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())

    #  Crea uno sfondo per la seconda diapositiva
    second_slide.getBackground().setType(BackgroundType.OwnBackground)
    second_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    second_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)

    #  Crea una casella di testo per la seconda diapositiva
    auto_shape = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Second Slide")

    #  Crea uno sfondo per la terza diapositiva
    third_slide.getBackground().setType(BackgroundType.OwnBackground)
    third_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    third_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray)

    #  Crea una casella di testo per la terza diapositiva
    auto_shape = third_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Third Slide")

    # Aggiunge oggetti ZoomFrame
    presentation.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, second_slide)
    presentation.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, third_slide)

    #  Salva la presentazione
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **Crea frame zoom con immagini personalizzate**
Con Aspose.Slides per Python via Java, puoi creare un frame zoom con un'immagine di anteprima della diapositiva diversa in questo modo:
1. Crea un'istanza della classe Presentation.
2. Crea una nuova diapositiva a cui intendi collegare il frame zoom.
3. Aggiungi testo identificativo e sfondo alla diapositiva.
4. Crea un oggetto PPImage aggiungendo un'immagine alla collezione immagini associata all'oggetto Presentation che verrà usata per riempire il frame.
5. Aggiungi i frame zoom (contenenti il riferimento alla diapositiva creata) alla prima diapositiva.
6. Salva la presentazione modificata come file PPTX.

Questo codice Python mostra come creare un frame zoom con un'immagine diversa:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # Aggiunge una nuova diapositiva alla presentazione
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())

    #  Crea uno sfondo per la seconda diapositiva
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)

    #  Crea una casella di testo per la seconda diapositiva
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Second Slide")

    #  Crea una nuova immagine per l'oggetto zoom
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    # Aggiunge l'oggetto ZoomFrame
    presentation.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture)

    #  Salva la presentazione
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **Formatta frame zoom**
Nelle sezioni precedenti, ti abbiamo mostrato come creare semplici frame zoom. Per creare frame zoom più complessi, è necessario modificare la formattazione di un frame semplice. Sono disponibili diverse opzioni di formattazione che puoi applicare a un frame zoom.

Puoi controllare la formattazione di un frame zoom su una diapositiva in questo modo:

1. Crea un'istanza della classe Presentation.
2. Crea nuove diapositive a cui intendi collegare i frame zoom.
3. Aggiungi testo identificativo e sfondo alle diapositive create.
4. Aggiungi i frame zoom (contenenti i riferimenti alle diapositive create) alla prima diapositiva.
5. Crea un oggetto PPImage aggiungendo un'immagine alla collezione immagini associata all'oggetto Presentation che verrà usata per riempire il frame.
6. Imposta un'immagine personalizzata per il primo oggetto frame zoom.
7. Modifica la formattazione della linea per il secondo oggetto frame zoom.
8. Rimuovi lo sfondo dall'immagine del secondo oggetto frame zoom.
9. Salva la presentazione modificata come file PPTX.

Questo codice Python mostra come modificare la formattazione di un frame zoom su una diapositiva:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # Aggiunge nuove diapositive alla presentazione
    second_slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    third_slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())

    #  Crea uno sfondo per la seconda diapositiva
    second_slide.getBackground().setType(BackgroundType.OwnBackground)
    second_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    second_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)

    #  Crea una casella di testo per la seconda diapositiva
    auto_shape = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Second Slide")

    #  Crea uno sfondo per la terza diapositiva
    third_slide.getBackground().setType(BackgroundType.OwnBackground)
    third_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    third_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray)

    #  Crea una casella di testo per la terza diapositiva
    auto_shape = third_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Third Slide")

    # Aggiunge oggetti ZoomFrame
    first_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, second_slide)
    second_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, third_slide)

    #  Crea una nuova immagine per l'oggetto zoom
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    #  Imposta immagine personalizzata per l'oggetto first_zoom_frame
    first_zoom_frame.setZoomImage(picture)

    #  Imposta un formato di zoom frame per l'oggetto second_zoom_frame
    second_zoom_frame.getLineFormat().setWidth(5)
    second_zoom_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    second_zoom_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.pink)
    second_zoom_frame.getLineFormat().setDashStyle(LineDashStyle.DashDot)

    #  Impostazione per non mostrare lo sfondo per l'oggetto second_zoom_frame
    second_zoom_frame.setShowBackground(False)

    #  Salva la presentazione
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zoom sezione**

Uno zoom sezione è un collegamento a una sezione della tua presentazione. Puoi usare gli zoom sezione per tornare a sezioni che desideri enfatizzare. Oppure puoi usarli per evidenziare come certe parti della presentazione si collegano tra loro.

![overview_image](seczoomsel.png)

Per gli oggetti zoom sezione, Aspose.Slides fornisce la classe SectionZoomFrame e alcuni metodi nella classe ShapeCollection.

### **Crea frame zoom sezione**

Puoi aggiungere un frame zoom sezione a una diapositiva in questo modo:

1. Crea un'istanza della classe Presentation.
2. Crea una nuova diapositiva.
3. Aggiungi uno sfondo distintivo alla diapositiva creata.
4. Crea una nuova sezione a cui intendi collegare il frame zoom.
5. Aggiungi un frame zoom sezione (contenente riferimenti alla sezione creata) alla prima diapositiva.
6. Salva la presentazione modificata come file PPTX.

Questo codice Python mostra come creare un frame zoom su una diapositiva:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Aggiunge una nuova diapositiva alla presentazione
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Aggiunge una nuova Sezione alla presentazione
    presentation.getSections().addSection("Section 1", slide)

    #  Aggiunge un oggetto SectionZoomFrame
    section_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, presentation.getSections().get_Item(1))

    #  Salva la presentazione
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **Crea frame zoom sezione con immagini personalizzate**

Utilizzando Aspose.Slides per Python via Java, puoi creare un frame zoom sezione con un'immagine di anteprima della diapositiva diversa in questo modo:

1. Crea un'istanza della classe Presentation.
2. Crea una nuova diapositiva.
3. Aggiungi uno sfondo distintivo alla diapositiva creata.
4. Crea una nuova sezione a cui intendi collegare il frame zoom.
5. Crea un oggetto PPImage aggiungendo un'immagine alla collezione immagini associata all'oggetto Presentation che verrà usata per riempire il frame.
6. Aggiungi un frame zoom sezione (contenente un riferimento alla sezione creata) alla prima diapositiva.
7. Salva la presentazione modificata come file PPTX.

Questo codice Python mostra come creare un frame zoom con un'immagine diversa:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Aggiunge una nuova diapositiva alla presentazione
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Aggiunge una nuova Sezione alla presentazione
    presentation.getSections().addSection("Section 1", slide)

    #  Crea una nuova immagine per l'oggetto zoom
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    #  Aggiunge l'oggetto SectionZoomFrame
    section_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, presentation.getSections().get_Item(1), picture)

    #  Salva la presentazione
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **Formatta frame zoom sezione**

Per creare frame zoom sezione più complessi, devi modificare la formattazione di un frame semplice. Sono disponibili diverse opzioni di formattazione che puoi applicare a un frame zoom sezione.

Puoi controllare la formattazione di un frame zoom sezione su una diapositiva in questo modo:

1. Crea un'istanza della classe Presentation.
2. Crea una nuova diapositiva.
3. Aggiungi uno sfondo distintivo alla diapositiva creata.
4. Crea una nuova sezione a cui intendi collegare il frame zoom.
5. Aggiungi un frame zoom sezione (contenente riferimenti alla sezione creata) alla prima diapositiva.
6. Modifica le dimensioni e la posizione dell'oggetto zoom sezione creato.
7. Crea un oggetto PPImage aggiungendo un'immagine alla collezione immagini associata all'oggetto Presentation che verrà usata per riempire il frame.
8. Imposta un'immagine personalizzata per l'oggetto frame zoom sezione creato.
9. Imposta la funzionalità *ritorno alla diapositiva originale dalla sezione collegata*.
10. Rimuovi lo sfondo dall'immagine dell'oggetto frame zoom sezione.
11. Modifica la formattazione della linea per l'oggetto frame zoom sezione.
12. Modifica la durata della transizione.
13. Salva la presentazione modificata come file PPTX.

Questo codice Python mostra come modificare la formattazione di un frame zoom sezione:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Aggiunge una nuova diapositiva alla presentazione
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Aggiunge una nuova Sezione alla presentazione
    presentation.getSections().addSection("Section 1", slide)

    #  Aggiunge l'oggetto SectionZoomFrame
    section_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, presentation.getSections().get_Item(1))

    #  Formattazione per SectionZoomFrame
    section_zoom_frame.setX(100)
    section_zoom_frame.setY(300)
    section_zoom_frame.setWidth(100)
    section_zoom_frame.setHeight(75)

    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    section_zoom_frame.setZoomImage(picture)

    section_zoom_frame.setReturnToParent(True)
    section_zoom_frame.setShowBackground(False)

    section_zoom_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    section_zoom_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.gray)
    section_zoom_frame.getLineFormat().setDashStyle(LineDashStyle.DashDot)
    section_zoom_frame.getLineFormat().setWidth(2.5)

    section_zoom_frame.setTransitionDuration(1.5)

    #  Salva la presentazione
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zoom riepilogo**

Uno zoom di riepilogo è come una pagina di atterraggio in cui tutti gli elementi della presentazione sono visualizzati contemporaneamente. Quando presenti, puoi usare lo zoom per spostarti da una parte della presentazione a un'altra in qualsiasi ordine desideri. Puoi essere creativo, saltare avanti o rivisitare parti della presentazione senza interrompere il flusso.

![overview_image](sumzoomsel.png)

Per gli oggetti zoom riepilogo, Aspose.Slides fornisce le classi SummaryZoomFrame, SummaryZoomSection e SummaryZoomSectionCollection e alcuni metodi nella classe ShapeCollection.

### **Crea uno zoom di riepilogo**

Puoi aggiungere un frame zoom di riepilogo a una diapositiva in questo modo:

1. Crea un'istanza della classe Presentation.
2. Crea nuove diapositive con uno sfondo distintivo e nuove sezioni per le diapositive create.
3. Aggiungi il frame zoom di riepilogo alla prima diapositiva.
4. Salva la presentazione modificata come file PPTX.

Questo codice Python mostra come creare un frame zoom di riepilogo su una diapositiva:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Aggiunge una nuova diapositiva alla presentazione
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Aggiunge una nuova sezione alla presentazione
    presentation.getSections().addSection("Section 1", slide)

    # Aggiunge una nuova diapositiva alla presentazione
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Aggiunge una nuova sezione alla presentazione
    presentation.getSections().addSection("Section 2", slide)

    # Aggiunge una nuova diapositiva alla presentazione
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Aggiunge una nuova sezione alla presentazione
    presentation.getSections().addSection("Section 3", slide)

    # Aggiunge una nuova diapositiva alla presentazione
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.green)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Aggiunge una nuova sezione alla presentazione
    presentation.getSections().addSection("Section 4", slide)

    #  Aggiunge un oggetto SummaryZoomFrame
    summary_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    #  Salva la presentazione
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Aggiungi e rimuovi una sezione zoom di riepilogo**

Tutte le sezioni in un frame zoom di riepilogo sono rappresentate da oggetti SummaryZoomSection, che sono memorizzati nell'oggetto SummaryZoomSectionCollection. Puoi aggiungere o rimuovere un oggetto sezione zoom di riepilogo tramite la classe SummaryZoomSectionCollection in questo modo:

1. Crea un'istanza della classe Presentation.
2. Crea nuove diapositive con uno sfondo distintivo e nuove sezioni per le diapositive create.
3. Aggiungi un frame zoom di riepilogo nella prima diapositiva.
4. Aggiungi una nuova diapositiva e sezione alla presentazione.
5. Aggiungi la sezione creata al frame zoom di riepilogo.
6. Rimuovi la prima sezione dal frame zoom di riepilogo.
7. Salva la presentazione modificata come file PPTX.

Questo codice Python mostra come aggiungere e rimuovere sezioni in un frame zoom di riepilogo:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Aggiunge una nuova diapositiva alla presentazione
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Aggiunge una nuova sezione alla presentazione
    presentation.getSections().addSection("Section 1", slide)

    # Aggiunge una nuova diapositiva alla presentazione
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Aggiunge una nuova sezione alla presentazione
    presentation.getSections().addSection("Section 2", slide)

    #  Aggiunge un oggetto SummaryZoomFrame
    summary_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    # Aggiunge una nuova diapositiva alla presentazione
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Aggiunge una nuova sezione alla presentazione
    third_section = presentation.getSections().addSection("Section 3", slide)

    #  Aggiunge una sezione allo Summary Zoom
    summary_zoom_frame.getSummaryZoomCollection().addSummaryZoomSection(third_section)

    #  Rimuove la sezione dallo Summary Zoom
    summary_zoom_frame.getSummaryZoomCollection().removeSummaryZoomSection(presentation.getSections().get_Item(1))

    #  Salva la presentazione
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Formatta sezioni zoom di riepilogo**

Per creare oggetti sezione zoom di riepilogo più complessi, devi modificare la formattazione di un frame semplice. Sono disponibili diverse opzioni di formattazione che puoi applicare a un oggetto sezione zoom di riepilogo.

Puoi controllare la formattazione di un oggetto sezione zoom di riepilogo in un frame zoom di riepilogo in questo modo:

1. Crea un'istanza della classe Presentation.
2. Crea nuove diapositive con uno sfondo distintivo e nuove sezioni per le diapositive create.
3. Aggiungi un frame zoom di riepilogo alla prima diapositiva.
4. Ottieni il primo oggetto sezione zoom di riepilogo dalla SummaryZoomSectionCollection.
5. Crea un oggetto PPImage aggiungendo un'immagine alla collezione immagini associata all'oggetto Presentation che verrà usata per riempire il frame.
6. Imposta un'immagine personalizzata per l'oggetto sezione zoom di riepilogo.
7. Imposta la funzionalità *ritorno alla diapositiva originale dalla sezione collegata*.
8. Modifica la formattazione della linea per l'oggetto sezione zoom di riepilogo.
9. Modifica la durata della transizione.
10. Salva la presentazione modificata come file PPTX.

Questo codice Python mostra come modificare la formattazione di un oggetto sezione zoom di riepilogo:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Aggiunge una nuova diapositiva alla presentazione
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Aggiunge una nuova sezione alla presentazione
    presentation.getSections().addSection("Section 1", slide)

    # Aggiunge una nuova diapositiva alla presentazione
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Aggiunge una nuova sezione alla presentazione
    presentation.getSections().addSection("Section 2", slide)

    #  Aggiunge un oggetto SummaryZoomFrame
    summary_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    #  Ottiene il primo oggetto SummaryZoomSection
    summary_section = summary_zoom_frame.getSummaryZoomCollection().get_Item(0)

    #  Formattazione per l'oggetto SummaryZoomSection
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    summary_section.setZoomImage(picture)

    summary_section.setReturnToParent(False)

    summary_section.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    summary_section.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.black)
    summary_section.getLineFormat().setDashStyle(LineDashStyle.DashDot)
    summary_section.getLineFormat().setWidth(1.5)

    summary_section.setTransitionDuration(1.5)

    #  Salva la presentazione
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Posso controllare il ritorno alla diapositiva 'genitore' dopo aver mostrato il target?**

Sì. Lo ZoomFrame o lo SectionZoomFrame supportano il ritorno alla diapositiva di origine tramite setReturnToParent, che riporta gli spettatori indietro dopo aver visitato il contenuto di destinazione quando è abilitato.

**Posso regolare la 'velocità' o la durata della transizione Zoom?**

Sì. Lo Zoom consente di impostare una durata di transizione con setTransitionDuration, così puoi controllare quanto tempo dura l'animazione del salto.

**Ci sono limiti al numero di oggetti Zoom che una presentazione può contenere?**

Non esiste un limite rigido documentato dall'API. I limiti pratici dipendono dalla complessità complessiva della presentazione e dalle prestazioni del visualizzatore. È possibile aggiungere molti frame Zoom, ma è opportuno considerare la dimensione del file e i tempi di rendering.