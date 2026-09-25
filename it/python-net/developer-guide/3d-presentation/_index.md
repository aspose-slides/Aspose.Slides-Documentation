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
- sfumatura 3D
- testo 3D
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Applica e renderizza effetti 3D per forme e testo PowerPoint in Python con Aspose.Slides. Configura telecamera, illuminazione, materiale, estrusione, riempimenti e testo 3D."
---
## **Panoramica**

Aspose.Slides per Python via .NET può creare, modificare, conservare e renderizzare la formattazione 3D in stile PowerPoint per forme e testo. Questo articolo copre effetti 3D come rotazione, estrusione, smussi, illuminazione, materiale, riempimenti sfumatura o immagine e testo 3D.

{{% alert color="info" title="Nota" %}}

Questo articolo tratta gli effetti di formattazione 3D su forme e testo di PowerPoint. Non riguarda l'inserimento o la modifica di file modello 3D autonomi. Quando esporti una diapositiva in un'immagine, PDF o HTML, Aspose.Slides renderizza quegli effetti 3D nell'output 2D esportato.

{{% /alert %}}

## **Concetti di Formattazione 3D**

Usa la proprietà [Shape.three_d_format](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/three_d_format/) per applicare la formattazione 3D a una forma. La proprietà espone [ThreeDFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides/threedformat/), che controlla la scena 3D per quella forma.

Per il testo, usa la proprietà [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframeformat/three_d_format/) . Questo applica la formattazione 3D al riquadro di testo anziché al corpo della forma.

Le proprietà più importanti sono:

| Proprietà | Cosa controlla | Quando usarla |
|---|---|---|
| [camera](https://reference.aspose.com/slides/it/python-net/aspose.slides/threedformat/camera/) | Punto di vista, tipo di telecamera predefinito, rotazione, zoom e prospettiva. | Ruotare l'oggetto nello spazio 3D o corrispondere a un preset di rotazione 3D di PowerPoint. |
| [light_rig](https://reference.aspose.com/slides/it/python-net/aspose.slides/threedformat/light_rig/) | Preset di luce, direzione e rotazione della luce. | Modificare come appaiono riflessi e ombre sulla superficie 3D. |
| [material](https://reference.aspose.com/slides/it/python-net/aspose.slides/threedformat/material/) | Materiale della superficie, ad esempio piatto, opaco, plastica o metallo. | Far apparire la stessa geometria più piatta, morbida, lucida o metallica. |
| [extrusion_height](https://reference.aspose.com/slides/it/python-net/aspose.slides/threedformat/extrusion_height/) | Quanto la forma si estende all'indietro dalla sua faccia frontale. | Trasformare una forma piatta in un oggetto 3D visibilmente spesso. |
| [extrusion_color](https://reference.aspose.com/slides/it/python-net/aspose.slides/threedformat/extrusion_color/) | Colore dei lati estrusi. | Rendere visibile la profondità o coordinare il colore laterale con il riempimento frontale. |
| [depth](https://reference.aspose.com/slides/it/python-net/aspose.slides/threedformat/depth/) | Profondità 3D aggiuntiva usata dalla formattazione 3D di PowerPoint. | Rifinire la profondità per forme o testo, soprattutto insieme a impostazioni di smusso e materiale. |
| [bevel_top](https://reference.aspose.com/slides/it/python-net/aspose.slides/threedformat/bevel_top/) e [bevel_bottom](https://reference.aspose.com/slides/it/python-net/aspose.slides/threedformat/bevel_bottom/) | Bordi rialzati o arrotondati sulle facce frontali e posteriori. | Aggiungere un bordo smussato o modellato anziché una faccia piatta e netta. |
| [contour_color](https://reference.aspose.com/slides/it/python-net/aspose.slides/threedformat/contour_color/) e [contour_width](https://reference.aspose.com/slides/it/python-net/aspose.slides/threedformat/contour_width/) | Contorno attorno all'oggetto 3D. | Evidenziare il confine dell'oggetto nel risultato renderizzato. |

## **Creare una Forma 3D**

Una forma solitamente richiede quattro tipi di impostazioni prima di apparire convincentemente 3D:

- Impostazioni della telecamera, perché la vista frontale predefinita può nascondere l'estrusione.
- Impostazioni di luce, perché l'illuminazione rende le facce e i lati leggibili.
- Impostazioni di materiale, perché la superficie influisce su come la luce viene renderizzata.
- Impostazioni di estrusione o profondità, perché una forma piatta necessita spessore.

L'esempio seguente crea un rettangolo, aggiunge testo alla sua faccia frontale e applica la formattazione 3D. I valori di rotazione della telecamera sono in gradi e l'altezza di estrusione è 100 punti. L'esempio renderizza la diapositiva in un'immagine PNG a doppia dimensione rispetto al valore predefinito e salva la presentazione come PPTX.

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

![Rettangolo 3D blu renderizzato con testo 3D bianco sulla faccia frontale](img_01_01.png)

## **Ruotare una Forma con la Telecamera**

In PowerPoint, la rotazione 3D è configurata dal riquadro Rotazione 3‑D. I valori di rotazione X, Y e Z corrispondono alla rotazione impostata tramite l'API della telecamera.

![Riquadro Rotazione 3‑D di PowerPoint con valori di rotazione X, Y e Z evidenziati](img_02_01.png)

In Aspose.Slides, accedi alla telecamera tramite [ThreeDFormat.camera](https://reference.aspose.com/slides/it/python-net/aspose.slides/threedformat/camera/). Questo esempio crea un rettangolo, seleziona una vista frontale ortografica e imposta le rotazioni X, Y e Z a 20, 30 e 40 gradi, rispettivamente. Configura la forma in memoria senza salvare un file:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
```

Usa la telecamera quando devi modificare il modo in cui lo spettatore vede l'oggetto. Non modifica la geometria 2D della forma nella diapositiva. Cambia il punto di vista 3D usato da PowerPoint e da Aspose.Slides durante il rendering.

## **Aggiungere Estrusione e Profondità**

L'estrusione rende una forma spessa estendendola dietro la faccia frontale. In PowerPoint, il controllo della profondità imposta questo spessore visibile e il controllo del colore imposta il colore delle facce laterali.

![Controlli di profondità di PowerPoint mappati al colore di estrusione e alle proprietà di altezza di estrusione](img_02_02.png)

Imposta [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/it/python-net/aspose.slides/threedformat/extrusion_height/) per lo spessore e [ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/it/python-net/aspose.slides/threedformat/extrusion_color/) per il colore laterale. Questo esempio assegna al rettangolo un'estrusione di 100 punti con lati viola e ruota la telecamera per mostrare lo spessore. Configura la forma in memoria senza salvare un file:

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

La proprietà [ThreeDFormat.depth](https://reference.aspose.com/slides/it/python-net/aspose.slides/threedformat/depth/) imposta la profondità di una forma 3D. La proprietà [extrusion_height](https://reference.aspose.com/slides/it/python-net/aspose.slides/threedformat/extrusion_height/) controlla l'altezza dell'effetto di estrusione, come mostrato in questo esempio.

## **Usare Riempimenti Sfumatura o Immagine con Effetti 3D**

La formattazione 3D è indipendente dal riempimento della forma. Puoi applicare un colore solido, una sfumatura, un motivo o un riempimento immagine alla faccia frontale e continuare a usare le stesse impostazioni di telecamera, luce, materiale ed estrusione.

Questo esempio applica una sfumatura dal blu all'arancione alla faccia frontale e un colore arancione scuro all'estrusione di 150 punti. Le fermate della sfumatura a 0 e 100 indicano l'inizio e la fine della sfumatura. I valori di rotazione della telecamera sono in gradi. La diapositiva è renderizzata in un'immagine PNG a doppia dimensione rispetto al valore predefinito:

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

L'output renderizzato mantiene la sfumatura sulla faccia frontale e renderizza separatamente l'estrusione:

![Rettangolo 3D renderizzato con riempimento sfumatura blu‑arancione e estrusione arancione](img_02_03.png)

Per usare un riempimento immagine, aggiungi l'immagine alla presentazione e assegnala al riempimento della forma. Questo esempio richiede un file esistente chiamato "image.jpg" nella directory di lavoro. Allunga l'immagine per riempire il rettangolo, applica un'estrusione di 150 punti e imposta la rotazione della telecamera in gradi. Configura la forma in memoria senza salvare o renderizzare un file:

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

L'immagine è renderizzata sulla faccia frontale, mentre l'estrusione è renderizzata come superficie laterale 3D:

![Rettangolo 3D renderizzato con riempimento foto sulla faccia frontale e estrusione arancione](img_02_04.png)

## **Applicare Formattazione 3D al Testo**

La formattazione 3D di una forma riguarda il corpo della forma. La formattazione 3D del testo riguarda il riquadro di testo. Questo è utile per effetti simili a WordArt dove le lettere stesse necessitano di estrusione, materiale, illuminazione e impostazioni della telecamera.

L'esempio seguente crea testo con un motivo griglia arancione‑bianco, applica un arco verso l'alto e configura le impostazioni 3D tramite [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframeformat/three_d_format/). L'altezza di estrusione e la profondità sono in punti, e la rotazione della luce è in gradi. Il riempimento e il contorno della forma sono nascosti così che solo il testo sia visibile. L'esempio renderizza un'immagine PNG a doppia dimensione rispetto alla diapositiva predefinita e salva la presentazione come PPTX:

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

![Testo 3D renderizzato con trasformazione arco WordArt, riempimento motivo arancione e estrusione scura](img_02_05.png)

## **Mantenere il Testo Piatti su una Forma 3D**

Per mantenere il testo leggibile preservando l'aspetto 3D della forma, imposta [TextFrameFormat.keep_text_flat](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframeformat/keep_text_flat/) tramite [TextFrame.text_frame_format](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/text_frame_format/). Quando il valore è `True`, il testo rimane fuori dalla scena 3D. Quando è `False`, il testo partecipa alla scena e segue la sua orientazione 3D.

Questa impostazione non rimuove la formattazione 3D della forma: la sua telecamera, illuminazione, materiale ed estrusione rimangono configurati tramite [Shape.three_d_format](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/three_d_format/). È anche diversa dalla rotazione tradizionale. [Shape.rotation](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/rotation/) ruota la forma nel piano della diapositiva, mentre [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframeformat/rotation_angle/) controlla la rotazione personalizzata del testo all'interno della sua area di delimitazione. Mantenere il testo fuori dalla scena 3D non reimposta nessuno di questi angoli.

L'esempio autonomo seguente crea un rettangolo blu con testo e lo clona accanto all'originale. Entrambe le forme hanno la stessa formattazione 3D; solo l'impostazione del testo differisce: `False` a sinistra e `True` a destra. Gli angoli della telecamera sono in gradi e l'altezza di estrusione è 40 punti. L'esempio salva la presentazione come PPTX e renderizza la diapositiva di confronto in PNG a doppia dimensione rispetto al valore predefinito.

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

A sinistra, il testo segue l'orientazione 3D. A destra, rimane piatto e più facile da leggere. Entrambi i rettangoli mantengono la stessa estrusione visibile e orientazione 3D.

![Rettangoli 3D affiancati: keep_text_flat è False a sinistra e True a destra](keep_text_flat.png)

## **Comportamento di Esportazione e Rendering**

Aspose.Slides conserva la formattazione 3D quando salva in formati PowerPoint come PPTX. Durante il rendering o l'esportazione in formati a layout fisso, la scena 3D è rasterizzata o disegnata nell'output come risultato 2D. Ciò vale quando renderizzi diapositive in [PNG](/slides/it/python-net/convert-powerpoint-to-png/), esporti in [PDF](/slides/it/python-net/convert-powerpoint-to-pdf/), esporti in [HTML](/slides/it/python-net/convert-powerpoint-to-html/), o generi fotogrammi per la [conversione video](/slides/it/python-net/convert-powerpoint-to-video/).

Tieni presenti questi punti:

- Le immagini ed i PDF esportati non sono interattivi. L'oggetto non può essere ruotato dallo spettatore dopo l'esportazione.
- L'aspetto finale dipende dalla combinazione di telecamera, rig di luci, materiale, estrusione, riempimento e scala della diapositiva.
- Se hai bisogno di ispezionare i valori di formattazione ereditati o basati su tema, leggi le [proprietà efficaci della forma](/slides/it/python-net/shape-effective-properties/).
- Alcuni formati di output non possono memorizzare la formattazione 3D editabile di PowerPoint. In tali formati, il risultato visivo è renderizzato anziché conservato come impostazioni 3D modificabili.

## **FAQ**

**Aspose.Slides può creare presentazioni 3D interattive?**

Aspose.Slides crea e renderizza gli effetti 3D di PowerPoint per forme e testo. Non rende le immagini, i PDF o le pagine HTML esportate in scene 3D interattive che lo spettatore può ruotare. In PPTX, la formattazione 3D rimane editabile in PowerPoint dove il formato lo supporta.

**Qual è la differenza tra un modello 3D e un effetto 3D?**

Un modello 3D è un oggetto 3D separato inserito nella presentazione. Un effetto 3D è una formattazione applicata a una forma o a un testo PowerPoint normale, come rotazione, estrusione, smusso, illuminazione e materiale. Questo articolo copre gli effetti 3D.

**Quali impostazioni sono necessarie per una forma 3D visibile?**

Al minimo, imposta una rotazione della telecamera e either estrusione o profondità. In pratica, imposta anche un rig di luci e un materiale affinché le facce renderizzate mostrino evidenti riflessi e ombre.

**Posso applicare effetti 3D sia a forme che a testo?**

Sì. Usa [Shape.three_d_format](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/three_d_format/) per il corpo della forma e [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframeformat/three_d_format/) per il testo.

**Gli effetti 3D appariranno quando esporti in immagini, PDF, HTML o fotogrammi video?**

Sì. Aspose.Slides renderizza gli effetti 3D durante la produzione di immagini delle diapositive, output PDF, output HTML e fotogrammi usati per la conversione video. L'output esportato contiene l'aspetto renderizzato, non un oggetto 3D editabile.

**Posso leggere i valori finali 3D dopo l'applicazione di ereditarietà e impostazioni di tema?**

Sì. Usa le API di formattazione efficace descritte nelle [Proprietà efficaci della forma](/slides/it/python-net/shape-effective-properties/) per leggere la telecamera finale, il rig di luci, lo smusso e i relativi valori 3D.