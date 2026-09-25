---
title: Creare effetti 3D nelle presentazioni con Python
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
description: "Applica e renderizza effetti 3D per forme e testo PowerPoint in Python tramite Java con Aspose.Slides. Configura fotocamera, illuminazione, materiale, estrusione, riempimenti e testo 3D."
---
## **Panoramica**

Aspose.Slides per Python via Java può creare, modificare, conservare e renderizzare la formattazione 3D in stile PowerPoint per forme e testo. Questo articolo copre gli effetti 3D come rotazione, estrusione, smussature, illuminazione, materiale, riempimenti a gradiente o immagine e testo 3D.

{{% alert color="info" title="Nota" %}}
Questo articolo tratta gli effetti di formattazione 3D su forme e testo di PowerPoint. Non riguarda l'inserimento o la modifica di file modello 3D autonomi. Quando esporti una diapositiva in un'immagine, PDF o HTML, Aspose.Slides rende quegli effetti 3D nell'output 2D esportato.
{{% /alert %}}

## **Concetti di Formattazione 3D**

Usa il metodo [Shape.getThreeDFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#getThreeDFormat) per applicare la formattazione 3D a una forma. Il metodo restituisce [ThreeDFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/threedformat/), che controlla la scena 3D per quella forma.

Per il testo, usa il metodo [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframeformat/#getThreeDFormat). Questo applica la formattazione 3D al frame di testo invece che al corpo della forma.

I membri API più importanti sono:

| Membro API | Cosa controlla | Quando usarlo |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/it/python-java/aspose.slides/threedformat/#getCamera) | Punto di vista, tipo di fotocamera predefinito, rotazione, zoom e prospettiva. | Ruota l'oggetto nello spazio 3D o corrispondi a un preset di rotazione 3D di PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/it/python-java/aspose.slides/threedformat/#getLightRig) | Preset luce, direzione e rotazione della luce. | Modifica come appaiono le luci e le ombre sulla superficie 3D. |
| [getMaterial](https://reference.aspose.com/slides/it/python-java/aspose.slides/threedformat/#getMaterial) e [setMaterial](https://reference.aspose.com/slides/it/python-java/aspose.slides/threedformat/#setMaterial) | Materiale della superficie, ad esempio piatto, opaco, plastica o metallo. | Rende la stessa geometria più piatta, più morbida, lucida o metallica. |
| [getExtrusionHeight](https://reference.aspose.com/slides/it/python-java/aspose.slides/threedformat/#getExtrusionHeight) e [setExtrusionHeight](https://reference.aspose.com/slides/it/python-java/aspose.slides/threedformat/#setExtrusionHeight) | Quanto la forma si estende all'indietro dalla sua faccia anteriore. | Trasforma una forma piatta in un oggetto 3D visibilmente spesso. |
| [getExtrusionColor](https://reference.aspose.com/slides/it/python-java/aspose.slides/threedformat/#getExtrusionColor) | Colore dei lati estrusi. | Rende la profondità visibile o coordina il colore laterale con il riempimento anteriore. |
| [getDepth](https://reference.aspose.com/slides/it/python-java/aspose.slides/threedformat/#getDepth) e [setDepth](https://reference.aspose.com/slides/it/python-java/aspose.slides/threedformat/#setDepth) | Profondità 3D aggiuntiva usata dalla formattazione 3D di PowerPoint. | Regola finemente la profondità per forme o testo, specialmente insieme a impostazioni di smussatura e materiale. |
| [getBevelTop](https://reference.aspose.com/slides/it/python-java/aspose.slides/threedformat/#getBevelTop) e [getBevelBottom](https://reference.aspose.com/slides/it/python-java/aspose.slides/threedformat/#getBevelBottom) | Bordi rialzati o arrotondati sulle facce frontale e posteriore. | Aggiunge un bordo ammorbidito o modellato invece di una faccia piatta e netta. |
| [getContourColor](https://reference.aspose.com/slides/it/python-java/aspose.slides/threedformat/#getContourColor) e [getContourWidth](https://reference.aspose.com/slides/it/python-java/aspose.slides/threedformat/#getContourWidth) e [setContourWidth](https://reference.aspose.com/slides/it/python-java/aspose.slides/threedformat/#setContourWidth) | Contorno intorno all'oggetto 3D. | Evidenzia i bordi dell'oggetto nell'output renderizzato. |

## **Crea una Forma 3D**

Una forma di solito richiede quattro tipologie di impostazioni prima di apparire convincente in 3D:

- Impostazioni della fotocamera, perché la vista frontale predefinita può nascondere l'estrusione.
- Impostazioni di illuminazione, perché l'illuminazione rende le facce e i lati leggibili.
- Impostazioni del materiale, perché la superficie influisce su come la luce è renderizzata.
- Impostazioni di estrusione o profondità, perché una forma piatta necessita di spessore.

La seguente esempio crea un rettangolo, aggiunge testo alla sua faccia anteriore e applica la formattazione 3D. I valori di rotazione della fotocamera sono in gradi e l'altezza di estrusione è di 100 punti. L'esempio renderizza la diapositiva in un'immagine PNG il doppio delle dimensioni predefinite e salva la presentazione come PPTX.

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

## **Ruota una Forma con la Fotocamera**

In PowerPoint, la rotazione 3D è configurata dal pannello Rotazione 3-D. I valori di rotazione X, Y e Z corrispondono alla rotazione impostata tramite l'API della fotocamera.

![Pannello Rotazione 3-D di PowerPoint con i valori di rotazione X, Y e Z evidenziati](img_02_01.png)

In Aspose.Slides, accedi alla fotocamera tramite [ThreeDFormat.getCamera](https://reference.aspose.com/slides/it/python-java/aspose.slides/threedformat/#getCamera). Questo esempio crea un rettangolo, seleziona una vista frontale ortografica e imposta le rotazioni X, Y e Z a 20, 30 e 40 gradi, rispettivamente. Configura la forma in memoria senza salvare un file:

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

Usa la fotocamera quando hai bisogno di modificare il modo in cui lo spettatore vede l'oggetto. Non modifica la geometria 2D della forma sulla diapositiva. Cambia il punto di vista 3D usato da PowerPoint e da Aspose.Slides durante il rendering.

## **Aggiungi Estrusione e Profondità**

L'estrusione fa apparire una forma più spessa estendendola dietro la faccia anteriore. In PowerPoint, il controllo della profondità imposta questo spessore visibile, e il controllo del colore imposta il colore delle facce laterali.

![Controlli di profondità di PowerPoint mappati alle proprietà colore dell'estrusione e altezza dell'estrusione](img_02_02.png)

Usa [ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/it/python-java/aspose.slides/threedformat/#setExtrusionHeight) per impostare lo spessore e [ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/it/python-java/aspose.slides/threedformat/#getExtrusionColor) per accedere al colore laterale. Questo esempio assegna al rettangolo un'estrusione di 100 punti con lati viola e ruota la fotocamera per rivelare il suo spessore. Configura la forma in memoria senza salvare un file:

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

Il metodo [ThreeDFormat.setDepth](https://reference.aspose.com/slides/it/python-java/aspose.slides/threedformat/#setDepth) imposta la profondità di una forma 3D. Il metodo [setExtrusionHeight](https://reference.aspose.com/slides/it/python-java/aspose.slides/threedformat/#setExtrusionHeight) controlla l'altezza dell'effetto di estrusione, come mostrato in questo esempio.

## **Usa Riempimenti a Gradiente o Immagine con Effetti 3D**

La formattazione 3D è indipendente dal riempimento della forma. Puoi applicare un colore solido, un gradiente, un motivo o un riempimento immagine alla faccia anteriore e continuare a usare le stesse impostazioni di fotocamera, luce, materiale ed estrusione.

Questo esempio applica un gradiente dal blu all'arancione sulla faccia anteriore e un colore arancione scuro all'estrusione di 150 punti. Le fermate del gradiente a 0 e 100 indicano l'inizio e la fine del gradiente. I valori di rotazione della fotocamera sono in gradi. La diapositiva è renderizzata in un'immagine PNG il doppio delle dimensioni predefinite:

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

Rettangolo 3D renderizzato con riempimento a gradiente dal blu all'arancione ed estrusione arancione:

![Rettangolo 3D renderizzato con riempimento a gradiente dal blu all'arancione ed estrusione arancione](img_02_03.png)

Per usare invece un riempimento immagine, aggiungi l'immagine alla presentazione e assegnala al riempimento della forma. Questo esempio richiede un file esistente chiamato "image.jpg" nella directory di lavoro. Allunga l'immagine per riempire il rettangolo, applica un'estrusione di 150 punti e imposta la rotazione della fotocamera in gradi. Configura la forma in memoria senza salvare o renderizzare un file:

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

Rettangolo 3D renderizzato con riempimento foto sulla faccia anteriore ed estrusione arancione:

![Rettangolo 3D renderizzato con riempimento foto sulla faccia anteriore ed estrusione arancione](img_02_04.png)

## **Applica Formattazione 3D al Testo**

La formattazione 3D di una forma influisce sul corpo della forma. La formattazione 3D del testo influisce sul frame del testo. Questo è utile per effetti simili a WordArt dove le lettere stesse necessitano di estrusione, materiale, illuminazione e impostazioni di fotocamera.

L'esempio seguente crea testo con un motivo a griglia arancione e bianco, applica un arco verso l'alto e configura le impostazioni 3D tramite [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframeformat/#getThreeDFormat). L'altezza di estrusione e la profondità sono in punti, e la rotazione della luce è in gradi. Il riempimento e il contorno della forma sono nascosti così che sia visibile solo il testo. L'esempio renderizza un'immagine PNG il doppio delle dimensioni predefinite della diapositiva e salva la presentazione come PPTX:

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

Testo 3D renderizzato con trasformazione WordArt arcuata, riempimento a motivo arancione e estrusione scura:

![Testo 3D renderizzato con trasformazione WordArt arcuata, riempimento a motivo arancione e estrusione scura](img_02_05.png)

## **Mantieni il Testo Piatti su una Forma 3D**

Per mantenere il testo leggibile preservando l'aspetto 3D di una forma, chiama [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframeformat/#setKeepTextFlat) tramite [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframe/#getTextFrameFormat). Quando il valore è `True`, il testo rimane fuori dalla scena 3D. Quando è `False`, il testo partecipa alla scena e segue la sua orientazione 3D.

Questa impostazione non rimuove la formattazione 3D della forma: la sua fotocamera, illuminazione, materiale ed estrusione rimangono configurati tramite [Shape.getThreeDFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#getThreeDFormat). È anche diversa dalla rotazione ordinaria. [Shape.setRotation](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#setRotation) ruota la forma nel piano della diapositiva, mentre [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframeformat/#setRotationAngle) controlla la rotazione personalizzata del testo all'interno del suo riquadro. Mantenere il testo fuori dalla scena 3D non reimposta nessuno di questi angoli.

L'esempio autonomo seguente crea un rettangolo blu con testo e lo clona accanto all'originale. Entrambe le forme hanno la stessa formattazione 3D; solo l'impostazione del testo differisce: `False` a sinistra e `True` a destra. Gli angoli della fotocamera sono in gradi e l'altezza di estrusione è 40 punti. L'esempio salva la presentazione come PPTX e renderizza la diapositiva di confronto in PNG il doppio delle dimensioni predefinite.

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

A sinistra, il testo segue l'orientazione 3D. A destra, rimane piatto e più facile da leggere. Entrambi i rettangoli mantengono la stessa estrusione visibile e orientazione 3D.

![Rettangoli 3D affiancati: il testo segue l'orientazione 3D a sinistra e rimane piatto a destra](keep_text_flat.png)

## **Comportamento di Esportazione e Rendering**

Aspose.Slides conserva la formattazione 3D quando salva in formati PowerPoint come PPTX. Quando si esegue il rendering o l'esportazione in formati a layout fisso, la scena 3D viene rasterizzata o disegnata nell'output come risultato 2D. Questo vale quando renderizzi le diapositive in [PNG](/slides/it/python-java/convert-powerpoint-to-png/), esporti in [PDF](/slides/it/python-java/convert-powerpoint-to-pdf/), esporti in [HTML](/slides/it/python-java/convert-powerpoint-to-html/), o generi fotogrammi per [video conversion](/slides/it/python-java/convert-powerpoint-to-video/).

Tieni presenti questi punti:

- Le immagini e i PDF esportati non sono interattivi. L'oggetto non può essere ruotato dallo spettatore dopo l'esportazione.
- L'aspetto finale dipende dalla combinazione di fotocamera, illuminazione, materiale, estrusione, riempimento e scala della diapositiva.
- Se devi ispezionare i valori di formattazione ereditati o basati sul tema, leggi le [proprietà effective della forma](/slides/it/python-java/shape-effective-properties/).
- Alcuni formati di output non possono memorizzare la formattazione 3D editabile di PowerPoint. In questi formati, il risultato visivo è renderizzato piuttosto che conservato come impostazioni 3D editabili.

## **FAQ**

**Aspose.Slides può creare presentazioni 3D interattive?**

Aspose.Slides crea e renderizza gli effetti 3D di PowerPoint per forme e testo. Non rende le immagini, i PDF o le pagine HTML esportati scene 3D interattive che lo spettatore possa ruotare. In PPTX, la formattazione 3D rimane editabile in PowerPoint dove il formato lo supporta.

**Qual è la differenza tra un modello 3D e un effetto 3D?**

Un modello 3D è un oggetto 3D separato inserito in una presentazione. Un effetto 3D è una formattazione applicata a una forma o testo PowerPoint normale, come rotazione, estrusione, smussatura, illuminazione e materiale. Questo articolo tratta gli effetti 3D.

**Quali impostazioni sono necessarie per una forma 3D visibile?**

Come minimo, impostare una rotazione della fotocamera e oppure un'estrusione o profondità. In pratica, impostare anche un rig di luce e materiale affinché le facce renderizzate abbiano evidenziature e ombre chiare.

**Posso applicare effetti 3D sia a forme che a testo?**

Sì. Usa [Shape.getThreeDFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#getThreeDFormat) per il corpo della forma e [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframeformat/#getThreeDFormat) per il testo.

**Gli effetti 3D appariranno quando si esporta in immagini, PDF, HTML o fotogrammi video?**

Sì. Aspose.Slides renderizza gli effetti 3D durante la generazione di immagini diapositive, output PDF, output HTML e fotogrammi per la conversione video. L'output esportato contiene l'aspetto renderizzato, non un oggetto 3D editabile.

**Posso leggere i valori finali 3D dopo l'applicazione di ereditarietà e impostazioni del tema?**

Sì. Usa le API di formattazione effective descritte in [proprietà effective della forma](/slides/it/python-java/shape-effective-properties/) per leggere i valori finali di fotocamera, rig di luce, smussatura e relativi valori 3D.