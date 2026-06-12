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

Aspose.Slides per Python tramite .NET può creare, modificare, conservare e renderizzare la formattazione 3D in stile PowerPoint per forme e testo. Questo articolo tratta gli effetti 3D come rotazione, estrusione, smussi, illuminazione, materiale, riempimenti a gradiente o immagine, e testo 3D.

{{% alert color="primary" %}}
Questo articolo riguarda gli effetti di formattazione 3D su forme e testo di PowerPoint. Non tratta l'inserimento o la modifica di file modello 3D autonomi. Quando si esporta una diapositiva in un'immagine, PDF o HTML, Aspose.Slides renderizza quegli effetti 3D nell'output 2D esportato.
{{% /alert %}}

## **Concetti di Formattazione 3D**

Utilizza la proprietà [Shape.three_d_format](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/three_d_format/) per applicare la formattazione 3D a una forma. La proprietà espone [ThreeDFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides/threedformat/), che controlla la scena 3D per quella forma.

Per il testo, utilizza la proprietà [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframeformat/three_d_format/). Questo applica la formattazione 3D al riquadro di testo invece che al corpo della forma.

Le proprietà più importanti sono:

| Proprietà | Cosa controlla | Quando usarla |
|---|---|---|
| [camera](https://reference.aspose.com/slides/it/python-net/aspose.slides/threedformat/camera/) | Punto di vista, tipo di fotocamera predefinito, rotazione, zoom e prospettiva. | Ruotare l'oggetto nello spazio 3D o corrispondere a un preset di rotazione 3D di PowerPoint. |
| [light_rig](https://reference.aspose.com/slides/it/python-net/aspose.slides/threedformat/light_rig/) | Preset di luce, direzione e rotazione della luce. | Modificare l'aspetto di evidenziature e ombre sulla superficie 3D. |
| [material](https://reference.aspose.com/slides/it/python-net/aspose.slides/threedformat/material/) | Materiale della superficie, come piatto, opaco, plastica o metallo. | Far apparire la stessa geometria più piatta, più morbida, lucida o metallica. |
| [extrusion_height](https://reference.aspose.com/slides/it/python-net/aspose.slides/threedformat/extrusion_height/) | Quanto la forma si estende all'indietro dalla sua faccia anteriore. | Trasformare una forma piatta in un oggetto 3D visibilmente spesso. |
| [extrusion_color](https://reference.aspose.com/slides/it/python-net/aspose.slides/threedformat/extrusion_color/) | Colore dei lati estrusi. | Rendere visibile la profondità o coordinare il colore laterale con il riempimento anteriore. |
| [depth](https://reference.aspose.com/slides/it/python-net/aspose.slides/threedformat/depth/) | Profondità 3D aggiuntiva usata dalla formattazione 3D di PowerPoint. | Regolare finemente la profondità per forme o testo, soprattutto in combinazione con impostazioni di smusso e materiale. |
| [bevel_top](https://reference.aspose.com/slides/it/python-net/aspose.slides/threedformat/bevel_top/) and [bevel_bottom](https://reference.aspose.com/slides/it/python-net/aspose.slides/threedformat/bevel_bottom/) | Bordi rialzati o arrotondati sulle facce anteriore e posteriore. | Aggiungere un bordo smussato o modellato invece di una faccia piatta e netta. |
| [contour_color](https://reference.aspose.com/slides/it/python-net/aspose.slides/threedformat/contour_color/) and [contour_width](https://reference.aspose.com/slides/it/python-net/aspose.slides/threedformat/contour_width/) | Contorno intorno all'oggetto 3D. | Enfatizzare il confine dell'oggetto nell'output renderizzato. |

## **Crea una Forma 3D**

Una forma di solito richiede quattro tipi di impostazioni prima di apparire convincentemente 3D:

- Impostazioni della fotocamera, perché la vista frontale predefinita può nascondere l'estrusione.  
- Impostazioni della luce, perché l'illuminazione rende le facce e i lati leggibili.  
- Impostazioni del materiale, perché la superficie influisce sul modo in cui la luce viene renderizzata.  
- Impostazioni di estrusione o profondità, perché una forma piatta necessita di spessore.  

Il seguente esempio crea un rettangolo, aggiunge testo alla sua faccia anteriore, applica la formattazione 3D, salva la presentazione come PPTX e renderizza la diapositiva in un'immagine PNG.

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

L'immagine della diapositiva renderizzata mostra il rettangolo come un blocco 3D spesso:

![Rettangolo 3D blu renderizzato con testo 3D bianco sulla faccia anteriore](img_01_01.png)

## **Ruota una Forma con la Fotocamera**

In PowerPoint, la rotazione 3D è configurata dal pannello Rotazione 3-D. I valori di rotazione X, Y e Z corrispondono alla rotazione impostata tramite l'API della fotocamera.

![Pane Rotazione 3-D di PowerPoint con valori di rotazione X, Y e Z evidenziati](img_02_01.png)

In Aspose.Slides, imposta il tipo di fotocamera e la rotazione tramite [ThreeDFormat.camera](https://reference.aspose.com/slides/it/python-net/aspose.slides/threedformat/camera/):

```py
shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
shape.three_d_format.camera.set_rotation(20, 30, 40)
```

Utilizza la fotocamera quando è necessario modificare il modo in cui lo spettatore vede l'oggetto. Non modifica la geometria 2D della forma sulla diapositiva. Modifica il punto di vista 3D usato da PowerPoint e da Aspose.Slides durante il rendering.

## **Aggiungi Estrusione e Profondità**

L'estrusione rende una forma spessa estendendola dietro la faccia anteriore. In PowerPoint, il controllo della profondità imposta questo spessore visibile, e il controllo del colore imposta il colore delle facce laterali.

![Controlli di profondità di PowerPoint mappati alle proprietà colore dell'estrusione e altezza dell'estrusione](img_02_02.png)

Imposta [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/it/python-net/aspose.slides/threedformat/extrusion_height/) per lo spessore e [ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/it/python-net/aspose.slides/threedformat/extrusion_color/) per il colore laterale:

```py
shape.three_d_format.camera.set_rotation(20, 30, 40)
shape.three_d_format.extrusion_height = 100
shape.three_d_format.extrusion_color.color = drawing.Color.purple
```

Utilizza [ThreeDFormat.depth](https://reference.aspose.com/slides/it/python-net/aspose.slides/threedformat/depth/) quando è necessario lavorare direttamente con il valore di profondità di PowerPoint o combinare la profondità con smusso, materiale ed effetti di testo. In molti scenari di forma, [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/it/python-net/aspose.slides/threedformat/extrusion_height/) è l'impostazione più chiara perché esprime direttamente l'estrusione visibile.

## **Usa Riempimenti a Gradiente o Immagine con Effetti 3D**

La formattazione 3D è indipendente dal riempimento della forma. È possibile applicare un colore solido, un gradiente, un motivo o un riempimento immagine alla faccia anteriore e continuare a utilizzare le stesse impostazioni di fotocamera, luce, materiale ed estrusione.

Questo esempio applica un riempimento a gradiente alla forma e un colore di estrusione più scuro ai lati:

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

![Rettangolo 3D renderizzato con riempimento a gradiente dal blu all'arancione e estrusione arancione](img_02_03.png)

Per utilizzare invece un riempimento immagine, aggiungi l'immagine alla presentazione e assegnala al riempimento della forma:

```py
with open("image.jpg", "rb") as image_file:
    image_data = image_file.read()

image = presentation.images.add_image(image_data)

shape.fill_format.fill_type = slides.FillType.PICTURE
shape.fill_format.picture_fill_format.picture.image = image
shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

shape.three_d_format.camera.set_rotation(10, 20, 30)
shape.three_d_format.extrusion_height = 150
shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange
```

![Rettangolo 3D renderizzato con riempimento foto sulla faccia anteriore ed estrusione arancione](img_02_04.png)

## **Applica Formattazione 3D al Testo**

La formattazione 3D della forma influisce sul corpo della forma. La formattazione 3D del testo influisce sul riquadro di testo. Questo è utile per effetti simili a WordArt in cui le lettere stesse necessitano di estrusione, materiale, illuminazione e impostazioni della fotocamera.

Il seguente esempio crea testo con un riempimento a motivo, applica una trasformazione WordArt e configura le impostazioni 3D su [TextFrameFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframeformat/):

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

![Testo 3D renderizzato con trasformazione WordArt arcuata, riempimento a motivo arancione e estrusione scura](img_02_05.png)

## **Comportamento di Esportazione e Rendering**

Aspose.Slides conserva la formattazione 3D quando salva in formati PowerPoint come PPTX. Durante il rendering o l'esportazione in formati a layout fisso, la scena 3D è rasterizzata o disegnata nell'output come risultato 2D. Questo vale quando renderizzi le diapositive in [PNG](/slides/it/python-net/convert-powerpoint-to-png/), esporti in [PDF](/slides/it/python-net/convert-powerpoint-to-pdf/), esporti in [HTML](/slides/it/python-net/convert-powerpoint-to-html/), o generi frame per la [conversione video](/slides/it/python-net/convert-powerpoint-to-video/).

- Le immagini ed i PDF esportati non sono interattivi. L'oggetto non può essere ruotato dallo spettatore dopo l'esportazione.  
- L'aspetto finale dipende dalla combinazione di fotocamera, rig di luce, materiale, estrusione, riempimento e scala della diapositiva.  
- Se è necessario ispezionare i valori di formattazione ereditati o basati sul tema, leggi le [proprietà shape effective](/slides/it/python-net/shape-effective-properties/).  
- Alcuni formati di output non possono memorizzare la formattazione 3D modificabile di PowerPoint. In tali formati, il risultato visivo è renderizzato invece di essere conservato come impostazioni 3D modificabili.

## **FAQ**

**Aspose.Slides può creare presentazioni 3D interattive?**

Aspose.Slides crea e renderizza effetti 3D di PowerPoint per forme e testo. Non rende le immagini, i PDF o le pagine HTML esportate scene 3D interattive che un visualizzatore possa ruotare. Nei file PPTX, la formattazione 3D rimane modificabile in PowerPoint dove il formato la supporta.

**Qual è la differenza tra un modello 3D e un effetto 3D?**

Un modello 3D è un oggetto 3D separato inserito in una presentazione. Un effetto 3D è una formattazione applicata a una forma o a del testo PowerPoint regolare, come rotazione, estrusione, smusso, illuminazione e materiale. Questo articolo tratta gli effetti 3D.

**Quali impostazioni sono necessarie per una forma 3D visibile?**

Come minimo, imposta una rotazione della fotocamera e oppure l'estrusione o la profondità. In pratica, imposta anche un rig di luce e il materiale affinché le facce renderizzate abbiano evidenziazioni e ombre chiare.

**Posso applicare effetti 3D sia a forme che a testo?**

Sì. Usa [Shape.three_d_format](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/three_d_format/) per il corpo della forma e [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframeformat/three_d_format/) per il testo.

**Gli effetti 3D appariranno esportando in immagini, PDF, HTML o frame video?**

Sì. Aspose.Slides renderizza gli effetti 3D quando produce immagini delle diapositive, output PDF, output HTML e frame utilizzati per la conversione video. L'output esportato contiene l'aspetto renderizzato, non un oggetto 3D modificabile.

**Posso leggere i valori 3D finali dopo l'applicazione di ereditarietà e impostazioni tema?**

Sì. Usa le API di formattazione effective descritte nelle [proprietà shape effective](/slides/it/python-net/shape-effective-properties/) per leggere la fotocamera finale, il rig di luce, lo smusso e i valori 3D correlati.