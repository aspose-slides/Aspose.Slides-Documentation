---
title: Aggiungi filigrane alle presentazioni in Python
linktitle: Filigrana
type: docs
weight: 40
url: /it/python-java/watermark/
keywords:
- filigrana
- filigrana di testo
- filigrana immagine
- aggiungi filigrana
- modifica filigrana
- rimuovi filigrana
- elimina filigrana
- aggiungi filigrana a PPT
- aggiungi filigrana a PPTX
- aggiungi filigrana a ODP
- rimuovi filigrana da PPT
- rimuovi filigrana da PPTX
- rimuovi filigrana da ODP
- elimina filigrana da PPT
- elimina filigrana da PPTX
- elimina filigrana da ODP
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Gestisci filigrane di testo e immagine in presentazioni PowerPoint e OpenDocument in Python per indicare una bozza, informazioni riservate, diritto d'autore e altro."
---
## **Introduzione**

**Un watermark** in una presentazione è un timbro di testo o immagine utilizzato su una diapositiva o su tutte le diapositive della presentazione. Di solito, un watermark è usato per indicare che la presentazione è una bozza (ad esempio, un watermark "Bozza"), che contiene informazioni riservate (ad esempio, un watermark "Confidenziale"), per specificare a quale azienda appartiene (ad esempio, un watermark "Nome Azienda"), per identificare l'autore della presentazione, ecc. Un watermark aiuta a prevenire violazioni del copyright indicando che la presentazione non deve essere copiata. I watermark sono usati sia nei formati di presentazione PowerPoint che OpenOffice. In Aspose.Slides, è possibile aggiungere un watermark ai formati di file PowerPoint PPT, PPTX e OpenOffice ODP.

In [**Aspose.Slides**](https://products.aspose.com/slides/it/python-java/), esistono vari modi per creare watermark in documenti PowerPoint o OpenOffice e modificare il loro design e comportamento. L'aspetto comune è che per aggiungere watermark di testo, si dovrebbe utilizzare la classe [TextFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframe/), e per aggiungere watermark di immagine, utilizzare la classe [PictureFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/pictureframe/) o riempire una forma di watermark con un'immagine. [PictureFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/pictureframe/) eredita dalla classe [Shape](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/), consentendo di utilizzare tutte le impostazioni flessibili dell'oggetto forma. Poiché [TextFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframe/) non è una forma e le sue impostazioni sono limitate, viene avvolto in un oggetto [Shape](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/).

Ci sono due modalità per applicare un watermark: a una singola diapositiva o a tutte le diapositive della presentazione. Lo Slide Master è usato per applicare un watermark a tutte le diapositive della presentazione — il watermark viene aggiunto allo Slide Master, completamente progettato lì, e applicato a tutte le diapositive senza influire sul permesso di modificare il watermark su singole diapositive.

Di solito un watermark è considerato non modificabile da altri utenti. Per impedire che il watermark (o piuttosto la forma genitore del watermark) venga modificato, Aspose.Slides fornisce la funzionalità di blocco delle forme. Una specifica forma può essere bloccata su una diapositiva normale o su uno Slide Master. Quando la forma del watermark è bloccata sullo Slide Master, verrà bloccata su tutte le diapositive della presentazione.

È possibile impostare un nome per il watermark in modo che in futuro, se si desidera eliminarlo, sia possibile trovarlo tra le forme della diapositiva per nome.

È possibile progettare il watermark in qualsiasi modo; tuttavia, di solito i watermark presentano caratteristiche comuni, come l'allineamento al centro, la rotazione, la posizione in primo piano, ecc. Vedremo come utilizzare queste caratteristiche negli esempi seguenti.

## **Watermark di Testo**

### **Aggiungere un Watermark di Testo a una Diapositiva**

Per aggiungere un watermark di testo in PPT, PPTX o ODP, è possibile prima aggiungere una forma alla diapositiva, quindi aggiungere un riquadro di testo a questa forma. Il riquadro di testo è rappresentato dalla classe [TextFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframe/). Questo tipo non eredita da [Shape](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/), che offre un ampio insieme di proprietà per posizionare il watermark in modo flessibile. Pertanto, l'oggetto [TextFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframe/) è avvolto in un oggetto [AutoShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/autoshape/). Per aggiungere il testo del watermark alla forma, utilizzare il metodo [addTextFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/autoshape/#addTextFrame) come mostrato di seguito.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

watermark_text = "CONFIDENTIAL"
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame(watermark_text)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Nota" %}} 
- [Come utilizzare la classe TextFrame](/slides/it/python-java/text-formatting/)
{{% /alert %}}

### **Aggiungere un Watermark di Testo a una Presentazione**

Se si desidera aggiungere un watermark di testo all'intera presentazione (cioè a tutte le diapositive contemporaneamente), aggiungerlo al [MasterSlide](https://reference.aspose.com/slides/it/python-java/aspose.slides/masterslide/). Il resto della logica è lo stesso di quando si aggiunge un watermark a una singola diapositiva — creare un oggetto [AutoShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/autoshape/) e poi aggiungere il watermark usando il metodo [addTextFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/autoshape/#addTextFrame).

```python
import jpime
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

watermark_text = "CONFIDENTIAL"
presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    watermark_shape = master_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame(watermark_text)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Nota" %}} 
- [Come utilizzare lo Slide Master](/slides/it/python-java/slide-master/)
{{% /alert %}}

### **Impostare la Trasparenza della Forma del Watermark**

Per impostazione predefinita, la forma rettangolare è stilizzata con colori di riempimento e linea. Le seguenti righe di codice rendono la forma trasparente.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_shape.getFillFormat().setFillType(FillType.NoFill)
    watermark_shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
finally:
    presentation.dispose()
```

### **Impostare il Font per un Watermark di Testo**

È possibile modificare il font del watermark di testo come mostrato di seguito.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FontData

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame("CONFIDENTIAL")
    text_format = watermark_frame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat()
    font = FontData("Arial")
    text_format.setLatinFont(font)
    text_format.setFontHeight(50)
finally:
    presentation.dispose()
```

### **Impostare il Colore del Testo del Watermark**

Per impostare il colore del testo del watermark, utilizzare questo codice:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame("CONFIDENTIAL")
    alpha, red, green, blue = 150, 200, 200, 200
    fill_format = watermark_frame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat()
    fill_format.setFillType(FillType.Solid)
    color = Color(red, green, blue, alpha)
    fill_format.getSolidFillColor().setColor(color)
finally:
    presentation.dispose()
```

### **Centrare un Watermark di Testo**

È possibile centrare il watermark su una diapositiva e, per farlo, è possibile eseguire quanto segue:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

watermark_text = "CONFIDENTIAL"
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide_size = presentation.getSlideSize().getSize()
    watermark_width = 400
    watermark_height = 40
    watermark_x = (slide_size.getWidth() - watermark_width) / 2
    watermark_y = (slide_size.getHeight() - watermark_height) / 2
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, watermark_x, watermark_y, watermark_width, watermark_height)
    watermark_frame = watermark_shape.addTextFrame(watermark_text)
finally:
    presentation.dispose()
```

![Il watermark di testo](text_watermark.png)

## **Watermark Immagine**

### **Aggiungere un Watermark Immagine a una Presentazione**

Per aggiungere un watermark immagine a una diapositiva della presentazione, è possibile fare quanto segue:

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType, PictureFillMode

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    image_data = Path("watermark.png").read_bytes()
    image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(image_data))
    watermark_shape.getFillFormat().setFillType(FillType.Picture)
    watermark_shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image)
    watermark_shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
finally:
    presentation.dispose()
```

### **Bloccare un Watermark dalla Modifica**

Se è necessario impedire la modifica di un watermark, utilizzare il metodo [AutoShape.getAutoShapeLock](https://reference.aspose.com/slides/it/python-java/aspose.slides/autoshape/#getAutoShapeLock) sulla forma. Con questa proprietà è possibile proteggere la forma dall'essere selezionata, ridimensionata, riposizionata, raggruppata con altri elementi, bloccare il suo testo dalla modifica e molto altro:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    # Blocca la forma del watermark contro le modifiche.
    watermark_shape.getAutoShapeLock().setSelectLocked(True)
    watermark_shape.getAutoShapeLock().setSizeLocked(True)
    watermark_shape.getAutoShapeLock().setTextLocked(True)
    watermark_shape.getAutoShapeLock().setPositionLocked(True)
    watermark_shape.getAutoShapeLock().setGroupingLocked(True)
finally:
    presentation.dispose()
```

### **Portare un Watermark in Primo Piano**

In Aspose.Slides, l'ordine Z delle forme può essere impostato tramite il metodo [ShapeCollection.reorder](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapecollection/#reorder). Per farlo, è necessario chiamare questo metodo dalla collezione di forme della diapositiva e passare il riferimento della forma e il suo numero di ordine al metodo. In questo modo è possibile portare una forma in primo piano o inviarla sullo sfondo della diapositiva. Questa funzionalità è particolarmente utile se è necessario posizionare un watermark davanti alla presentazione:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    shape_count = slide.getShapes().size()
    slide.getShapes().reorder(shape_count - 1, watermark_shape)
finally:
    presentation.dispose()
```

### **Impostare la Rotazione del Watermark**

Ecco un esempio di codice su come regolare la rotazione del watermark in modo che sia posizionato diagonalmente sulla diapositiva:

```python
import jpype
import asposeslides
import math

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    slide_size = presentation.getSlideSize().getSize()
    diagonal_angle = math.atan((slide_size.getHeight() / slide_size.getWidth())) * 180 / math.pi
    watermark_shape.setRotation(diagonal_angle)
finally:
    presentation.dispose()
```

### **Impostare un Nome per un Watermark**

Aspose.Slides consente di impostare il nome di una forma. Utilizzando il nome della forma, è possibile accedervi in futuro per modificarla o eliminarla. Per impostare il nome della forma del watermark, passarlo al metodo [Shape.setName](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#setName):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_shape.setName("watermark")
finally:
    presentation.dispose()
```

### **Rimuovere un Watermark**

Per rimuovere la forma del watermark, utilizzare il metodo [Shape.getName](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#getName) per trovarla tra le forme della diapositiva. Quindi, passare la forma del watermark al metodo [ShapeCollection.remove](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapecollection/#remove):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    slide_shapes = slide.getShapes().toArray()
    for shape in slide_shapes:
        if shape.getName() == "watermark":
            slide.getShapes().remove(shape)
finally:
    presentation.dispose()
```

## **Domande Frequenti**

**Che cos'è un watermark e perché dovrei usarlo?**

Un watermark è una sovrapposizione di testo o immagine applicata alle diapositive che aiuta a proteggere la proprietà intellettuale, migliorare il riconoscimento del marchio o impedire l'uso non autorizzato delle presentazioni.

**Posso aggiungere un watermark a tutte le diapositive di una presentazione?**

Sì, Aspose.Slides consente di aggiungere programmaticamente un watermark a ogni diapositiva di una presentazione. È possibile scorrere tutte le diapositive e applicare le impostazioni del watermark singolarmente.

**Come posso regolare la trasparenza del watermark?**

È possibile regolare la trasparenza del watermark modificando le impostazioni di riempimento ([getFillFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#getFillFormat)) della forma. Ciò garantisce che il watermark sia discreto e non distolga l'attenzione dal contenuto della diapositiva.

**Quali formati immagine sono supportati per i watermark?**

Aspose.Slides supporta vari formati immagine come PNG, JPEG, GIF, BMP, SVG e altri.

**Posso personalizzare il font e lo stile di un watermark di testo?**

Sì, è possibile scegliere qualsiasi font, dimensione e stile per abbinare il design della presentazione e mantenere la coerenza del marchio.

**Come modifico la posizione o l'orientamento di un watermark?**

È possibile regolare la posizione e l'orientamento del watermark programmaticamente modificando le coordinate, le dimensioni e le proprietà di rotazione della forma.