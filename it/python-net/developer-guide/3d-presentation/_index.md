---
title: Crea effetti 3D nelle presentazioni usando Python
linktitle: Presentazione 3D
type: docs
weight: 232
url: /it/python-net/3d-presentation/
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
- Aspose.Slides
description: "Applica e renderizza effetti 3D per forme e testo PowerPoint in Python con Aspose.Slides. Configura fotocamera, illuminazione, materiale, estrusione, riempimenti e testo 3D."
---
## **Panoramica**

Aspose.Slides per Python tramite .NET può creare, modificare, conservare e renderizzare la formattazione 3D in stile PowerPoint per forme e testo. Questo articolo tratta effetti 3D come rotazione, estrusione, smussi, illuminazione, materiale, riempimenti a gradiente o immagine e testo 3D.

{{% alert color="info" title="Nota" %}}

Questo articolo tratta gli effetti di formattazione 3D su forme e testo di PowerPoint. Non riguarda l'inserimento o la modifica di file modello 3D autonomi. Quando esporti una diapositiva in immagine, PDF o HTML, Aspose.Slides rende quegli effetti 3D nell'output 2D esportato.

{{% /alert %}}

## **Concetti di formattazione 3D**

Usa la proprietà [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) per applicare la formattazione 3D a una forma. La proprietà espone [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/), che controlla la scena 3D per quella forma.

Per il testo, usa la proprietà [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/three_d_format/). Questo applica la formattazione 3D al riquadro di testo anziché al corpo della forma.

Le proprietà più importanti sono:

| Proprietà | Cosa controlla | Quando utilizzarlo |
|---|---|---|
| [camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/camera/) | Punto di vista, tipo di fotocamera predefinita, rotazione, zoom e prospettiva. | Ruotare l'oggetto nello spazio 3D o corrispondere a un preset di rotazione 3D di PowerPoint. |
| [light_rig](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/light_rig/) | Preset di luce, direzione e rotazione della luce. | Modificare il modo in cui appaiono luci e ombre sulla superficie 3D. |
| [material](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/material/) | Materiale della superficie, ad esempio piatto, opaco, plastica o metallo. | Far apparire la stessa geometria più piatta, più morbida, lucida o metallica. |
| [extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/) | Quanto la forma si estende all'indietro dalla sua faccia anteriore. | Trasformare una forma piatta in un oggetto 3D visibilmente spesso. |
| [extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_color/) | Colore dei lati estrusi. | Rendere visibile la profondità o coordinare il colore laterale con il riempimento frontale. |
| [depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/) | Profondità 3D aggiuntiva usata dalla formattazione 3D di PowerPoint. | Regolare finemente la profondità per forme o testo, specialmente insieme a impostazioni di smusso e materiale. |
| [bevel_top](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_top/) e [bevel_bottom](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_bottom/) | Bordi rialzati o arrotondati sulle facce anteriore e posteriore. | Aggiungere un bordo smussato o modellato invece di una faccia piatta e netta. |
| [contour_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/contour_color/) e [contour_width](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/contour_width/) | Contorno attorno all'oggetto 3D. | Evidenziare il bordo dell'oggetto nell'output renderizzato. |

## **Creare una forma 3D**

Una forma di solito necessita di quattro tipi di impostazioni prima di apparire convincentemente 3D:

- Impostazioni della fotocamera, perché la vista frontale predefinita può nascondere l'estrusione.
- Impostazioni della luce, perché l'illuminazione rende le facce e i lati leggibili.
- Impostazioni del materiale, perché la superficie influisce su come la luce viene renderizzata.
- Impostazioni di estrusione o profondità, perché una forma piatta ha bisogno di spessore.

L'esempio seguente crea un rettangolo, aggiunge testo alla sua faccia frontale e applica la formattazione 3D. I valori di rotazione della fotocamera sono in gradi, e l'altezza di estrusione è 100 punti. L'esempio renderizza la diapositiva in un'immagine PNG a dimensioni doppie rispetto a quelle predefinite e salva la presentazione come PPTX.

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.text_frame.text = "3D"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 64

    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = drawing.Color.cornflower_blue

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 100
    shape.three_d_format.extrusion_color.color = drawing.Color.blue

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("shape_3d.png")

    presentation.save("shape_3d.pptx", slides.export.SaveFormat.PPTX)
```

L'immagine renderizzata della diapositiva mostra il rettangolo come un blocco 3D spesso:

![Rettangolo 3D blu renderizzato con testo 3D bianco sulla faccia anteriore](img_01_01.png)

## **Ruotare una forma con la fotocamera**

In PowerPoint, la rotazione 3D è configurata dal pannello Rotazione 3-D. I valori di rotazione X, Y e Z corrispondono alla rotazione impostata tramite l'API della fotocamera.

![Pannello Rotazione 3-D di PowerPoint con i valori di rotazione X, Y e Z evidenziati](img_02_01.png)

In Aspose.Slides, accedi alla fotocamera tramite [ThreeDFormat.camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/camera/). Questo esempio crea un rettangolo, seleziona una vista frontale ortografica e imposta le rotazioni X, Y e Z a 20, 30 e 40 gradi rispettivamente. Configura la forma in memoria senza salvare un file:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
```

Usa la fotocamera quando devi cambiare il modo in cui lo spettatore vede l'oggetto. Non modifica la geometria 2D della forma sulla diapositiva. Cambia il punto di vista 3D usato da PowerPoint e da Aspose.Slides durante il rendering.

### **Copiare l'orientamento della fotocamera da una forma modello**

Per corrispondere all'orientamento di una forma modello, copia il preset [camera_type](https://reference.aspose.com/slides/python-net/aspose.slides/camera/camera_type/) e leggi la sua rotazione con [get_rotation](https://reference.aspose.com/slides/python-net/aspose.slides/camera/get_rotation/). L'esempio apre `template.pptx` e copia l'orientamento della fotocamera dalla prima forma della prima diapositiva alla seconda forma. Entrambe le forme hanno già l'illuminazione 3D, e la seconda forma non ha una rotazione della fotocamera esplicita.

Gli angoli sono in gradi. Gli indici `0`, `1` e `2` contengono latitudine, longitudine e rivoluzione rispettivamente. Passali a [set_rotation](https://reference.aspose.com/slides/python-net/aspose.slides/camera/set_rotation/) in quest'ordine. Se la sorgente non ha una rotazione esplicita, `get_rotation` restituisce `None`, quindi lascia gli angoli di destinazione non impostati. Se la sorgente imposta esplicitamente tutti e tre gli angoli a zero, copia quegli zero.

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    shapes = presentation.slides[0].shapes
    
    source_camera = shapes[0].three_d_format.camera
    destination_camera = shapes[1].three_d_format.camera

    destination_camera.camera_type = source_camera.camera_type
    angles = source_camera.get_rotation()
    if angles is not None:
        destination_camera.set_rotation(angles[0], angles[1], angles[2])

    presentation.save("camera-copy.pptx", slides.export.SaveFormat.PPTX)
```

Quando riapri `camera-copy.pptx` in PowerPoint, entrambe le forme hanno lo stesso preset e la stessa rotazione della fotocamera. La freccia a destra utilizza l'orientamento copiato dal rettangolo a sinistra. Entrambe le forme usano la stessa illuminazione e profondità di estrusione.

![Un rettangolo 3D blu e una freccia destra con orientamento della fotocamera corrispondente, viste dall'alto e a destra](camera-orientation.png)

## **Aggiungere estrusione e profondità**

L'estrusione rende una forma spessa estendendola dietro la faccia anteriore. In PowerPoint, il controllo della profondità imposta questo spessore visibile, e il controllo del colore imposta il colore delle facce laterali.

![Controlli di profondità di PowerPoint mappati alle proprietà extrusion_color e extrusion_height](img_02_02.png)

Imposta [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/) per lo spessore e [ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_color/) per il colore laterale. Questo esempio assegna a un rettangolo un'estrusione di 100 punti con lati viola e ruota la fotocamera per mostrare lo spessore. Configura la forma in memoria senza salvare un file:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 100
    shape.three_d_format.extrusion_color.color = drawing.Color.purple
```

La proprietà [ThreeDFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/) imposta la profondità di una forma 3D. La proprietà [extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/) controlla l'altezza dell'effetto di estrusione, come mostrato in questo esempio.

## **Usare riempimenti a gradiente o immagine con effetti 3D**

La formattazione 3D è indipendente dal riempimento della forma. Puoi applicare un colore solido, un gradiente, un motivo o un riempimento immagine alla faccia anteriore e continuare a usare la stessa fotocamera, luce, materiale ed impostazioni di estrusione.

Questo esempio applica un gradiente dal blu all'arancione alla faccia anteriore e un colore arancione scuro all'estrusione di 150 punti. Le fermate del gradiente a 0 e 100 indicano l'inizio e la fine del gradiente. I valori di rotazione della fotocamera sono in gradi. La diapositiva è renderizzata in un'immagine PNG a dimensioni doppie rispetto a quelle predefinite:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)

    shape.text_frame.text = "3D Gradient"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 64

    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_stops.add(0, drawing.Color.blue)
    shape.fill_format.gradient_format.gradient_stops.add(100, drawing.Color.orange)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(10, 20, 30)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 150
    shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("gradient_3d.png")
```

L'output renderizzato mantiene il gradiente sulla faccia anteriore e renderizza l'estrusione separatamente:

![Rettangolo 3D renderizzato con riempimento gradiente blu‑arancione e estrusione arancione](img_02_03.png)

Per utilizzare un riempimento immagine, aggiungi l'immagine alla presentazione e assegnala al riempimento della forma. Questo esempio richiede un file esistente chiamato "image.jpg" nella directory di lavoro. Estende l'immagine per riempire il rettangolo, applica un'estrusione di 150 punti e imposta la rotazione della fotocamera in gradi. Configura la forma in memoria senza salvare o renderizzare un file:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with open("image.jpg", "rb") as image_file:
    image_data = image_file.read()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)

    image = presentation.images.add_image(image_data)

    shape.fill_format.fill_type = slides.FillType.PICTURE
    shape.fill_format.picture_fill_format.picture.image = image
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(10, 20, 30)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 150
    shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange
```

L'immagine è renderizzata sulla faccia anteriore, mentre l'estrusione è renderizzata come superficie laterale 3D:

![Rettangolo 3D renderizzato con riempimento foto sulla faccia anteriore e estrusione arancione](img_02_04.png)

## **Applicare la formattazione 3D al testo**

La formattazione 3D della forma influisce sul corpo della forma. La formattazione 3D del testo influisce sul riquadro di testo. Questo è utile per effetti simili a WordArt dove le lettere hanno bisogno di estrusione, materiale, illuminazione e impostazioni della fotocamera.

L'esempio seguente crea del testo con un motivo griglia arancione‑bianco, applica un arco verso l'alto e configura le impostazioni 3D tramite [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/three_d_format/). L'altezza di estrusione e la profondità sono in punti, e la rotazione della luce è in gradi. Il riempimento e il contorno della forma sono nascosti in modo che sia visibile solo il testo. L'esempio renderizza un'immagine PNG a dimensioni doppie rispetto a quelle predefinite della diapositiva e salva la presentazione come PPTX:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)
    
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.text = "3D Text"

    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = drawing.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = drawing.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.LARGE_GRID

    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 128

    text_frame_format = shape.text_frame.text_frame_format
    text_frame_format.transform = slides.TextShapeType.ARCH_UP
    text_frame_format.three_d_format.extrusion_height = 3.5
    text_frame_format.three_d_format.depth = 3
    text_frame_format.three_d_format.material = slides.MaterialPresetType.PLASTIC
    text_frame_format.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    text_frame_format.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    text_frame_format.three_d_format.light_rig.set_rotation(0, 0, 40)
    text_frame_format.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("text_3d.png")

    presentation.save("text_3d.pptx", slides.export.SaveFormat.PPTX)
```

Il testo è renderizzato come lettere 3D curve, estruse:

![Testo 3D renderizzato con trasformazione WordArt ad arco, riempimento motivo arancione e estrusione scura](img_02_05.png)

## **Mantenere il testo piatto su una forma 3D**

Per mantenere il testo leggibile preservando l'aspetto 3D della forma, imposta [TextFrameFormat.keep_text_flat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/keep_text_flat/) tramite [TextFrame.text_frame_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/text_frame_format/). Quando il valore è `True`, il testo rimane fuori dalla scena 3D. Quando è `False`, il testo partecipa alla scena e segue la sua orientazione 3D.

Questa impostazione non rimuove la formattazione 3D della forma: la sua fotocamera, illuminazione, materiale ed estrusione rimangono configurati tramite [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/). È anche diversa dalla rotazione ordinaria. [Shape.rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) ruota la forma nel piano della diapositiva, mentre [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) controlla la rotazione personalizzata del testo all'interno della sua area di contenimento. Mantenere il testo fuori dalla scena 3D non reimposta nessuno di questi angoli.

L'esempio autonomo seguente crea un rettangolo blu con testo e lo clona accanto all'originale. Entrambe le forme hanno la stessa formattazione 3D; solo l'impostazione del testo differisce: `False` a sinistra e `True` a destra. Gli angoli della fotocamera sono in gradi e l'altezza di estrusione è 40 punti. L'esempio salva la presentazione come PPTX e renderizza la diapositiva di confronto in PNG a dimensioni doppie rispetto al default.

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 70, 160, 240, 140)

    shape.text_frame.text = "Readable text"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 28
    shape.text_frame.paragraphs[0].paragraph_format.alignment = slides.TextAlignment.CENTER
    shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.CENTER
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = drawing.Color.cornflower_blue

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(30, 30, 0)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 40
    shape.three_d_format.extrusion_color.color = drawing.Color.royal_blue
    shape.text_frame.text_frame_format.keep_text_flat = False

    flat_text_shape = slide.shapes.add_clone(shape, 400, 160)
    flat_text_shape.text_frame.text_frame_format.keep_text_flat = True

    presentation.save("keep_text_flat.pptx", slides.export.SaveFormat.PPTX)
    with slide.get_image(2, 2) as image:
        image.save("keep_text_flat.png")
```

A sinistra, il testo segue l'orientamento 3D. A destra, rimane piatto e più facile da leggere. Entrambi i rettangoli mantengono la stessa estrusione visibile e l'orientamento 3D.

![Rettangoli 3D affiancati: keep_text_flat è False a sinistra e True a destra](keep_text_flat.png)

## **Comportamento di esportazione e rendering**

Aspose.Slides conserva la formattazione 3D quando salva in formati PowerPoint come PPTX. Quando si renderizza o si esporta in formati a layout fisso, la scena 3D viene rasterizzata o disegnata nell'output come risultato 2D. Ciò avviene quando renderizzi le diapositive in [PNG](/slides/it/python-net/convert-powerpoint-to-png/), esporti in [PDF](/slides/it/python-net/convert-powerpoint-to-pdf/), esporti in [HTML](/slides/it/python-net/convert-powerpoint-to-html/), o generi frame per [conversione video](/slides/it/python-net/convert-powerpoint-to-video/).

Tieni presenti questi punti:

- Le immagini e i PDF esportati non sono interattivi. L'oggetto non può essere ruotato dallo spettatore dopo l'esportazione.
- L'aspetto finale dipende dalla combinazione di fotocamera, rig di luce, materiale, estrusione, riempimento e scalatura della diapositiva.
- Se devi ispezionare i valori di formattazione ereditati o basati sui temi, leggi le [proprietà effettive della forma](/slides/it/python-net/shape-effective-properties/).
- Alcuni formati di output non possono memorizzare la formattazione 3D modificabile di PowerPoint. In quei formati, il risultato visivo è renderizzato anziché conservato come impostazioni 3D modificabili.

## **FAQ**

**Aspose.Slides può creare presentazioni 3D interattive?**

Aspose.Slides crea e renderizza effetti 3D di PowerPoint per forme e testo. Non rende le immagini, i PDF o le pagine HTML esportate scene 3D interattive che lo spettatore può ruotare. In PPTX, la formattazione 3D rimane modificabile in PowerPoint dove il formato lo supporta.

**Qual è la differenza tra un modello 3D e un effetto 3D?**

Un modello 3D è un oggetto 3D separato inserito nella presentazione. Un effetto 3D è una formattazione applicata a una forma o a un testo PowerPoint normale, come rotazione, estrusione, smusso, illuminazione e materiale. Questo articolo tratta gli effetti 3D.

**Quali impostazioni sono necessarie per una forma 3D visibile?**

Al minimo, imposta una rotazione della fotocamera e un'estrusione o profondità. In pratica, imposta anche un rig di luce e un materiale affinché le facce renderizzate abbiano evidenziature e ombre chiare.

**Posso applicare effetti 3D sia a forme che a testo?**

Sì. Usa [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) per il corpo della forma e [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/three_d_format/) per il testo.

**Gli effetti 3D appariranno quando esporti in immagini, PDF, HTML o frame video?**

Sì. Aspose.Slides renderizza gli effetti 3D quando produce immagini delle diapositive, output PDF, output HTML e frame usati per la conversione video. L'output esportato contiene l'aspetto renderizzato, non un oggetto 3D modificabile.

**Posso leggere i valori finali 3D dopo l'applicazione di ereditarietà e impostazioni del tema?**

Sì. Usa le API di formattazione effettiva descritte in [Proprietà effettive della forma](/slides/it/python-net/shape-effective-properties/) per leggere la fotocamera finale, il rig di luce, lo smusso e i valori 3D correlati.