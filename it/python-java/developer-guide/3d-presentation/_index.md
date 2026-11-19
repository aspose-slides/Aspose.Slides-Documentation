---
title: Crea effetti 3D nelle presentazioni usando Python
linktitle: Presentazione 3D
type: docs
weight: 232
url: /it/python-java/3d-presentation/
keywords:
- PowerPoint 3D
- presentazione 3D
- rotazione 3D
- profondità 3D
- estrusione 3D
- gradiente 3D
- testo 3D
- PowerPoint
- presentazione
- Python
- Java
- Aspose.Slides
description: "Applica e renderizza effetti 3D per forme e testo PowerPoint in Python tramite Java con Aspose.Slides. Configura telecamera, illuminazione, materiale, estrusione, riempimenti e testo 3D."
---
## **Panoramica**

Aspose.Slides per Python via Java può creare, modificare, conservare e renderizzare formattazione 3D in stile PowerPoint per forme e testo. Questo articolo tratta gli effetti 3D come rotazione, estrusione, smussature, illuminazione, materiale, riempimenti a gradiente o immagine e testo 3D.

{{% alert color="info" title="Note" %}}
Questo articolo tratta gli effetti di formattazione 3D su forme e testo di PowerPoint. Non riguarda l'inserimento o la modifica di file modello 3D autonomi. Quando esporti una diapositiva in un'immagine, PDF o HTML, Aspose.Slides rende quegli effetti 3D nell'output 2D esportato.
{{% /alert %}}

## **Concetti di Formattazione 3D**

Usa il metodo [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat) per applicare la formattazione 3D a una forma. Il metodo restituisce [ThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/), che controlla la scena 3D per quella forma.

Per il testo, usa il metodo [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getThreeDFormat). Questo applica la formattazione 3D al riquadro di testo invece che al corpo della forma.

I membri API più importanti sono:

| Membro API | Cosa controlla | Quando usarlo |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getCamera) | Punto di vista, tipo di telecamera predefinito, rotazione, zoom e prospettiva. | Ruota l'oggetto nello spazio 3D o corrispondi a un preset di rotazione 3D di PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getLightRig) | Preset luce, direzione e rotazione della luce. | Modifica come appaiono le luci e le ombre sulla superficie 3D. |
| [getMaterial](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getMaterial) e [setMaterial](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setMaterial) | Materiale della superficie, ad esempio piatto, opaco, plastica o metallo. | Rendi la stessa geometria più piatta, più morbida, lucida o metallica. |
| [getExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getExtrusionHeight) e [setExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setExtrusionHeight) | Quanto la forma si estende all'indietro dalla sua faccia anteriore. | Trasforma una forma piatta in un oggetto 3D visibilmente spesso. |
| [getExtrusionColor](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getExtrusionColor) | Colore dei lati estrusi. | Rendi la profondità visibile o coordina il colore laterale con il riempimento frontale. |
| [getDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getDepth) e [setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setDepth) | Profondità 3D aggiuntiva usata dalla formattazione 3D di PowerPoint. | Regola finemente la profondità per forme o testo, soprattutto insieme a impostazioni di smussatura e materiale. |
| [getBevelTop](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getBevelTop) e [getBevelBottom](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getBevelBottom) | Bordi rialzati o arrotondati su facce frontali e posteriori. | Aggiungi un bordo smussato o modellato invece di una superficie piatta e nitida. |
| [getContourColor](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getContourColor) e [getContourWidth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getContourWidth) e [setContourWidth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setContourWidth) | Contorno attorno all'oggetto 3D. | Evidenzia il bordo dell'oggetto nell'output renderizzato. |

## **Crea una Forma 3D**

Una forma di solito necessita di quattro tipi di impostazioni prima di apparire convincentemente 3D:

- Impostazioni della telecamera, perché la vista frontale predefinita può nascondere l'estrusione.
- Impostazioni della luce, perché l'illuminazione rende visibili le facce e i lati.
- Impostazioni del materiale, perché la superficie influisce su come la luce viene renderizzata.
- Impostazioni di estrusione o profondità, perché una forma piatta ha bisogno di spessore.

L'esempio seguente crea un rettangolo, aggiunge testo alla sua faccia anteriore e applica la formattazione 3D. I valori di rotazione della telecamera sono in gradi, e l'altezza di estrusione è 100 punti. L'esempio renderizza la diapositiva in un'immagine PNG a dimensioni doppie rispetto al valore predefinito e salva la presentazione come PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, SaveFormat, ShapeType
from java.awt import Color

image_scale = 2.0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)
    shape.getTextFrame().setText("3D")
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64)

    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(100, 149, 237))

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(100)
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.BLUE)

    thumbnail = slide.getImage(image_scale, image_scale)
    try:
        thumbnail.save("shape_3d.png", ImageFormat.Png)
    finally:
        thumbnail.dispose()

    presentation.save("shape_3d.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

L'immagine della diapositiva renderizzata mostra il rettangolo come un blocco 3D spesso:

![Rettangolo 3D blu renderizzato con testo 3D bianco sulla faccia anteriore](img_01_01.png)

## **Ruota una Forma con la Telecamera**

In PowerPoint, la rotazione 3D è configurata dal pannello Rotazione 3‑D. I valori di rotazione X, Y e Z corrispondono alla rotazione impostata tramite l'API della telecamera.

![PowerPoint 3‑D Rotation pane with X, Y, and Z rotation values highlighted](img_02_01.png)

In Aspose.Slides, accedi alla telecamera tramite [ThreeDFormat.getCamera](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getCamera). Questo esempio crea un rettangolo, seleziona una vista frontale ortografica e imposta le rotazioni X, Y e Z a 20, 30 e 40 gradi, rispettivamente. Configura la forma in memoria senza salvare un file:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
finally:
    presentation.dispose()
```

Usa la telecamera quando devi modificare il modo in cui lo spettatore vede l'oggetto. Non modifica la geometria 2D della forma sulla diapositiva. Cambia il punto di vista 3D usato da PowerPoint e da Aspose.Slides durante il rendering.

### **Copia l'Orientamento della Telecamera da una Forma Modello**

Per corrispondere all'orientamento di una forma modello, leggi il suo preset di telecamera con [Camera.getCameraType](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#getCameraType) e i suoi angoli di rotazione con [Camera.getRotation](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#getRotation). L'esempio apre `template.pptx` e copia l'orientamento della telecamera dalla prima forma della prima diapositiva alla seconda forma. Entrambe le forme hanno già illuminazione 3D, e la seconda forma non ha rotazione della telecamera esplicita.

Gli angoli sono in gradi. L'indice `0` è latitudine, l'indice `1` è longitudine e l'indice `2` è rivoluzione. Passali a [Camera.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setRotation) in quest'ordine. Se la fonte restituisce `None`, non ha una rotazione esplicita, quindi lascia gli angoli della seconda forma non impostati. Una rotazione esplicita di `(0, 0, 0)` restituisce tre zero e deve essere copiata.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("template.pptx")
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()
    
    source_camera = shapes.get_Item(0).getThreeDFormat().getCamera()
    destination_camera = shapes.get_Item(1).getThreeDFormat().getCamera()

    destination_camera.setCameraType(source_camera.getCameraType())
    angles = source_camera.getRotation()
    if angles is not None:
        destination_camera.setRotation(angles[0], angles[1], angles[2])

    presentation.save("camera-copy.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Quando riapri `camera-copy.pptx` in PowerPoint, la freccia a destra ha lo stesso preset di telecamera e la stessa rotazione del rettangolo a sinistra. Entrambe le forme usano la stessa illuminazione e la stessa profondità di estrusione.

![Un rettangolo 3D blu e una freccia destra con orientamento della telecamera corrispondente, vista dall’alto e da destra](camera-orientation.png)

## **Aggiungi Estrusione e Profondità**

L'estrusione rende una forma più spessa estendendola dietro la faccia anteriore. In PowerPoint, il controllo della profondità imposta questo spessore visibile, e il controllo del colore imposta il colore delle facce laterali.

![PowerPoint depth controls mapped to extrusion color and extrusion height properties](img_02_02.png)

Usa [ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setExtrusionHeight) per impostare lo spessore e [ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getExtrusionColor) per accedere al colore laterale. Questo esempio assegna al rettangolo un'estrusione di 100 punti con lati viola e ruota la telecamera per mostrare lo spessore. Configura la forma in memoria senza salvare un file:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)

    extrusion_color = Color(128, 0, 128)

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(100)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

Il metodo [ThreeDFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setDepth) imposta la profondità di una forma 3D. Il metodo [setExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setExtrusionHeight) controlla l'altezza dell'effetto di estrusione, come mostrato in questo esempio.

## **Usa Riempimenti a Gradiente o Immagine con Effetti 3D**

La formattazione 3D è indipendente dal riempimento della forma. Puoi applicare un colore solido, un gradiente, un motivo o un riempimento immagine alla faccia anteriore e continuare a usare la stessa telecamera, luce, materiale ed impostazioni di estrusione.

Questo esempio applica un gradiente dal blu all’arancione alla faccia anteriore e un colore arancione scuro all'estrusione di 150 punti. Le fermate del gradiente a 0 e 100 indicano l'inizio e la fine del gradiente. I valori di rotazione della telecamera sono in gradi. La diapositiva è renderizzata in un’immagine PNG a dimensioni doppie rispetto al valore predefinito:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

image_scale = 2.0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)
    shape.getTextFrame().setText("3D Gradient")
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64)

    shape.getFillFormat().setFillType(FillType.Gradient)
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, Color.BLUE)
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color(255, 165, 0))

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    extrusion_color = Color(255, 140, 0)
    shape.getThreeDFormat().setExtrusionHeight(150)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)

    thumbnail = slide.getImage(image_scale, image_scale)
    try:
        thumbnail.save("gradient_3d.png", ImageFormat.Png)
    finally:
        thumbnail.dispose()
finally:
    presentation.dispose()
```

![Rettangolo 3D renderizzato con riempimento a gradiente dal blu all’arancione e estrusione arancione](img_02_03.png)

Per usare invece un riempimento immagine, aggiungi l’immagine alla presentazione e assegnala al riempimento della forma. Questo esempio richiede un file esistente chiamato "image.jpg" nella directory di lavoro. Allunga l’immagine per riempire il rettangolo, applica un'estrusione di 150 punti e imposta la rotazione della telecamera in gradi. Configura la forma in memoria senza salvare o renderizzare un file:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, LightRigPresetType, LightingDirection, MaterialPresetType, PictureFillMode, Presentation, ShapeType
from java.awt import Color
from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)

    image_data = Path("image.jpg").read_bytes()
    java_image_data = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(java_image_data)

    shape.getFillFormat().setFillType(FillType.Picture)
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image)
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)

    extrusion_color = Color(255, 140, 0)
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(150)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

![Rettangolo 3D renderizzato con riempimento fotografico sulla faccia anteriore e estrusione arancione](img_02_04.png)

## **Applica Formattazione 3D al Testo**

La formattazione 3D della forma influisce sul corpo della forma. La formattazione 3D del testo influisce sul riquadro di testo. È utile per effetti simili a WordArt dove le lettere stesse richiedono estrusione, materiale, illuminazione e impostazioni della telecamera.

L'esempio seguente crea testo con un motivo a griglia arancione‑bianco, applica un arco verso l'alto e configura le impostazioni 3D tramite [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getThreeDFormat). L'altezza e la profondità dell'estrusione sono in punti, e la rotazione della luce è in gradi. Il riempimento e il contorno della forma sono nascosti affinché sia visibile solo il testo. L'esempio renderizza un'immagine PNG a dimensioni doppie rispetto a quelle predefinite della diapositiva e salva la presentazione come PPTX:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, PatternStyle, Presentation, SaveFormat, ShapeType, TextShapeType
from java.awt import Color

image_scale = 2.0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    shape.getTextFrame().setText("3D Text")

    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern)
    pattern_color = Color(255, 140, 0)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(pattern_color)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE)
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid)

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128)

    text_frame_format = shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setTransform(TextShapeType.ArchUp)
    text_frame_format.getThreeDFormat().setExtrusionHeight(3.5)
    text_frame_format.getThreeDFormat().setDepth(3)
    text_frame_format.getThreeDFormat().setMaterial(MaterialPresetType.Plastic)
    text_frame_format.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    text_frame_format.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)
    text_frame_format.getThreeDFormat().getLightRig().setRotation(0, 0, 40)
    text_frame_format.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)

    thumbnail = slide.getImage(image_scale, image_scale)
    try:
        thumbnail.save("text_3d.png", ImageFormat.Png)
    finally:
        thumbnail.dispose()

    presentation.save("text_3d.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Testo 3D renderizzato con trasformazione WordArt ad arco, riempimento a motivo arancione e estrusione scura](img_02_05.png)

## **Mantieni il Testo Piatti su una Forma 3D**

Per mantenere il testo leggibile preservando l'aspetto 3D della forma, chiama [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setKeepTextFlat) tramite [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getTextFrameFormat). Quando il valore è `True`, il testo resta fuori dalla scena 3D. Quando è `False`, il testo partecipa alla scena e segue la sua orientazione 3D.

Questa impostazione non rimuove la formattazione 3D della forma: la telecamera, l'illuminazione, il materiale e l'estrusione rimangono configurati tramite [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat). È anche diversa dalla rotazione ordinaria. [Shape.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation) ruota la forma nel piano della diapositiva, mentre [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setRotationAngle) controlla la rotazione personalizzata del testo all'interno della sua area. Tenere il testo fuori dalla scena 3D non reimposta nessuno di questi angoli.

L'esempio autonomo seguente crea un rettangolo blu con testo e lo clona accanto all'originale. Entrambe le forme hanno la stessa formattazione 3D; solo l'impostazione del testo differisce: `False` a sinistra e `True` a destra. Gli angoli della telecamera sono in gradi, e l'altezza di estrusione è 40 punti. L'esempio salva la presentazione come PPTX e renderizza la diapositiva di confronto in PNG a dimensioni doppie rispetto al valore predefinito.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, SaveFormat, ShapeType, TextAlignment, TextAnchorType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 70, 160, 240, 140)

    shape.getTextFrame().setText("Readable text")
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28)
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(TextAlignment.Center)
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Center)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(100, 149, 237))

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(40)
    shape.getThreeDFormat().getExtrusionColor().setColor(Color(65, 105, 225))
    shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(False)

    flat_text_shape = slide.getShapes().addClone(shape, 400, 160)
    flat_text_shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(True)

    presentation.save("keep_text_flat.pptx", SaveFormat.Pptx)
    image = slide.getImage(2, 2)
    try:
        image.save("keep_text_flat.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

A sinistra, il testo segue l'orientamento 3D. A destra, rimane piatto e più leggibile. Entrambi i rettangoli mantengono la stessa estrusione visibile e la stessa orientazione 3D.

![Rettangoli 3D affiancati: testo segue l'orientamento 3D a sinistra e rimane piatto a destra](keep_text_flat.png)

## **Comportamento di Esportazione e Rendering**

Aspose.Slides conserva la formattazione 3D quando salva nei formati PowerPoint come PPTX. Quando si renderizza o si esporta in formati a layout fisso, la scena 3D è rasterizzata o disegnata nell'output come risultato 2D. Ciò vale quando renderizzi le diapositive in [PNG](/slides/it/python-java/convert-powerpoint-to-png/), esporti in [PDF](/slides/it/python-java/convert-powerpoint-to-pdf/), esporti in [HTML](/slides/it/python-java/convert-powerpoint-to-html/), o generi fotogrammi per la [conversione video](/slides/it/python-java/convert-powerpoint-to-video/).

Tieni presenti i seguenti punti:

- Le immagini e i PDF esportati non sono interattivi. L'oggetto non può essere ruotato dallo spettatore dopo l'esportazione.
- L'aspetto finale dipende dalla combinazione di telecamera, impianto luce, materiale, estrusione, riempimento e scala della diapositiva.
- Se hai bisogno di ispezionare i valori di formattazione ereditati o basati sul tema, leggi le [proprietà effettive della forma](/slides/it/python-java/shape-effective-properties/).
- Alcuni formati di output non possono memorizzare la formattazione 3D modificabile di PowerPoint. In quei formati, il risultato visivo è renderizzato anziché conservato come impostazioni 3D modificabili.

## **FAQ**

**Aspose.Slides può creare presentazioni 3D interattive?**

Aspose.Slides crea e renderizza effetti 3D di PowerPoint per forme e testo. Non rende le immagini, i PDF o le pagine HTML esportate in scene 3D interattive che lo spettatore possa ruotare. In PPTX, la formattazione 3D rimane modificabile in PowerPoint dove il formato lo supporta.

**Qual è la differenza tra un modello 3D e un effetto 3D?**

Un modello 3D è un oggetto 3D separato inserito in una presentazione. Un effetto 3D è una formattazione applicata a una forma o a un testo PowerPoint regolare, come rotazione, estrusione, smussatura, illuminazione e materiale. Questo articolo tratta gli effetti 3D.

**Quali impostazioni sono necessarie per una forma 3D visibile?**

Al minimo, imposta una rotazione della telecamera e una estrusione o profondità. In pratica, imposta anche un impianto luce e un materiale affinché le facce renderizzate mostrino chiaramente luci e ombre.

**Posso applicare effetti 3D sia a forme che a testo?**

Sì. Usa [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat) per il corpo della forma e [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getThreeDFormat) per il testo.

**Gli effetti 3D appariranno quando si esporta in immagini, PDF, HTML o fotogrammi video?**

Sì. Aspose.Slides renderizza gli effetti 3D quando produce immagini della diapositiva, output PDF, output HTML e fotogrammi usati per la conversione video. L'output esportato contiene l'aspetto renderizzato, non un oggetto 3D modificabile.

**Posso leggere i valori 3D finali dopo l'applicazione di ereditarietà e impostazioni del tema?**

Sì. Usa le API di formattazione effettiva descritte nelle [proprietà effettive della forma](/slides/it/python-java/shape-effective-properties/) per leggere la telecamera finale, l'impianto luce, la smussatura e i relativi valori 3D.