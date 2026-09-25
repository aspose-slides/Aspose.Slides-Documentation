---
title: Crea e applica effetti WordArt in Python
linktitle: WordArt
type: docs
weight: 110
url: /it/python-net/wordart/
keywords:
- WordArt
- crea WordArt
- modello WordArt
- effetto WordArt
- effetto ombra
- effetto riflesso
- effetto bagliore
- trasformazione WordArt
- effetto 3D
- effetto ombra esterna
- effetto ombra interna
- Python
- Aspose.Slides
description: "Crea e personalizza gli effetti WordArt in Aspose.Slides per Python via .NET. Questa guida passo-passo aiuta gli sviluppatori a migliorare le presentazioni con testo professionale in Python."
---
## **Panoramica**

Gli effetti WordArt consentono di formattare il testo con riempimenti, contorni, ombre, riflessi, bagliore, trasformazioni e formattazione 3D. Questo articolo spiega come creare e personalizzare questi effetti nelle presentazioni PowerPoint utilizzando Aspose.Slides per Python via .NET, senza Microsoft Office installato.

## **Crea un modello WordArt semplice e applicalo al testo**

Gli esempi seguenti creano uno stile WordArt semplice impostando il testo, il carattere, il riempimento a motivo e il contorno.

Ogni esempio crea una nuova presentazione e aggiunge un rettangolo alla sua prima diapositiva; non è richiesto alcun file di input. Il primo esempio imposta il testo su "Aspose.Slides". La posizione e le dimensioni della forma sono misurate in punti:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)
    text_frame = auto_shape.text_frame

    portion = text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
```

Imposta il carattere su Arial Black a 36 punti per rendere la formattazione più evidente:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36
```

Applica un motivo [SMALL_GRID](https://reference.aspose.com/slides/it/python-net/aspose.slides/patternstyle/) con un primo piano arancione scuro e uno sfondo bianco, quindi aggiungi un contorno del testo nero con spessore di 1 punto:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36

    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = draw.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = draw.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.SMALL_GRID

    portion.portion_format.line_format.width = 1
    portion.portion_format.line_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.line_format.fill_format.solid_fill_color.color = draw.Color.black
```

Il testo risultante:

![Il modello WordArt semplice](WordArt_template.png)

## **Applica altri effetti WordArt**

Gli esempi seguenti dimostrano come applicare ombre, riflessi, bagliore, trasformazioni e effetti 3D al testo.

### **Applica effetti di Ombra Esterna**

Un'ombra esterna aggiunge profondità posizionando un'ombra dietro il testo. Puoi personalizzare il suo colore, direzione, distanza, raggio di sfocatura, scala e inclinazione.

La seguente chiamata [enable_outer_shadow_effect](https://reference.aspose.com/slides/it/python-net/aspose.slides/effectformat/enable_outer_shadow_effect/) imposta un'ombra nera con un raggio di sfocatura di 4 punti, una direzione di 230 gradi e una distanza di 30 punti. I valori di scala pari a 100 preservano le dimensioni dell'ombra, mentre l'inclinazione orizzontale la inclina di 20 gradi. La trasformazione alfa imposta la sua opacità al 32%:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36

    portion.portion_format.effect_format.enable_outer_shadow_effect()
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color = draw.Color.black
    portion.portion_format.effect_format.outer_shadow_effect.scale_horizontal = 100
    portion.portion_format.effect_format.outer_shadow_effect.scale_vertical = 100
    portion.portion_format.effect_format.outer_shadow_effect.blur_radius = 4
    portion.portion_format.effect_format.outer_shadow_effect.direction = 230
    portion.portion_format.effect_format.outer_shadow_effect.distance = 30
    portion.portion_format.effect_format.outer_shadow_effect.skew_horizontal = 20
    portion.portion_format.effect_format.outer_shadow_effect.skew_vertical = 0
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.32)
```

Il testo risultante:

![Effetto Ombra Esterna](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- Quando le ombre esterne e predefinite vengono usate insieme, viene applicata solo l'ombra esterna.
- Se ombre esterne e interne vengono usate simultaneamente, l'effetto risultante dipende dalla versione di PowerPoint. Per esempio, in PowerPoint 2013 l'effetto è raddoppiato, mentre in PowerPoint 2007 viene applicata solo l'ombra esterna.
{{% /alert %}}

### **Applica effetti di Riflesso**

Un riflesso crea una copia specchiata del testo. Regola la sua posizione, scala, sfocatura e opacità per controllare l'aspetto.

Questo esempio chiama [enable_reflection_effect](https://reference.aspose.com/slides/it/python-net/aspose.slides/effectformat/enable_reflection_effect/) e ribalta verticalmente il riflesso con una scala del -100%. Usa un raggio di sfocatura di 0.5 punti e una distanza di 4.72 punti. L'opacità diminuisce dal 60% allo 0.9% tra le posizioni 0% e 60% lungo il riflesso:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36

    portion.portion_format.effect_format.enable_reflection_effect()
    portion.portion_format.effect_format.reflection_effect.blur_radius = 0.5
    portion.portion_format.effect_format.reflection_effect.distance = 4.72
    portion.portion_format.effect_format.reflection_effect.start_pos_alpha = 0
    portion.portion_format.effect_format.reflection_effect.end_pos_alpha = 60
    portion.portion_format.effect_format.reflection_effect.direction = 90
    portion.portion_format.effect_format.reflection_effect.scale_horizontal = 100
    portion.portion_format.effect_format.reflection_effect.scale_vertical = -100
    portion.portion_format.effect_format.reflection_effect.start_reflection_opacity = 60
    portion.portion_format.effect_format.reflection_effect.end_reflection_opacity = 0.9
    portion.portion_format.effect_format.reflection_effect.rectangle_align = slides.RectangleAlignment.BOTTOM_LEFT
```

Il testo risultante:

![Effetto Riflesso](reflection_effect.png)

### **Applica effetti di Bagliore**

Un bagliore aggiunge un sottile contorno colorato attorno al testo. Regola il colore, l'opacità e il raggio per controllare l'effetto.

Questo esempio chiama [enable_glow_effect](https://reference.aspose.com/slides/it/python-net/aspose.slides/effectformat/enable_glow_effect/) e applica un bagliore rosso con opacità del 54% e raggio di 7 punti:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36

    portion.portion_format.effect_format.enable_glow_effect()
    portion.portion_format.effect_format.glow_effect.color.color = draw.Color.red
    portion.portion_format.effect_format.glow_effect.color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.54)
    portion.portion_format.effect_format.glow_effect.radius = 7
```

Il testo risultante:

![Effetto Bagliore](glow_effect.png)

### **Applica trasformazioni WordArt**

Le trasformazioni WordArt piegano, allungano o deformano un blocco di testo.

Imposta [transform](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframeformat/transform/) su [ARCH_UP_POUR](https://reference.aspose.com/slides/it/python-net/aspose.slides/textshapetype/) per curvare verso l'alto l'intero riquadro di testo:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    text_frame = auto_shape.text_frame
    text_frame.text = "Aspose.Slides"
    text_frame.text_frame_format.transform = slides.TextShapeType.ARCH_UP_POUR
```

Il testo risultante:

![Trasformazione WordArt](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides per Python via .NET offre un insieme di [tipi di trasformazione](https://reference.aspose.com/slides/it/python-net/aspose.slides/textshapetype/) predefiniti.
{{% /alert %}}

### **Applica effetti 3D a forme e testo**

Puoi applicare effetti 3D a una forma o al suo testo. Smussi, estrusione, illuminazione e impostazioni della fotocamera controllano l'aspetto risultante.

L'esempio seguente utilizza [ThreeDFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides/threedformat/) per aggiungere smussi circolari, estrusione arancione e un contorno rosso scuro al rettangolo. Le dimensioni dello smusso, l'altezza dell'estrusione, la larghezza del contorno e la profondità sono misurate in punti. Un materiale plastico, illuminazione bilanciata ruotata di 40 gradi attorno all'asse Z, e una fotocamera prospettica definiscono il suo aspetto:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)
    auto_shape.text_frame.text = "Aspose.Slides"

    auto_shape.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    auto_shape.three_d_format.bevel_bottom.height = 10.5
    auto_shape.three_d_format.bevel_bottom.width = 10.5

    auto_shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    auto_shape.three_d_format.bevel_top.height = 12.5
    auto_shape.three_d_format.bevel_top.width = 11

    auto_shape.three_d_format.extrusion_color.color = draw.Color.orange
    auto_shape.three_d_format.extrusion_height = 6

    auto_shape.three_d_format.contour_color.color = draw.Color.dark_red
    auto_shape.three_d_format.contour_width = 1.5

    auto_shape.three_d_format.depth = 3

    auto_shape.three_d_format.material = slides.MaterialPresetType.PLASTIC

    auto_shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    auto_shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    auto_shape.three_d_format.light_rig.set_rotation(0, 0, 40)

    auto_shape.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```

La forma risultante:

![Effetto 3D della forma](shape_3D_effect.png)

Questo esempio applica una formattazione 3D simile al testo tramite [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframeformat/three_d_format/). Smussi più piccoli modellano i bordi delle lettere, mentre l'estrusione e l'illuminazione conferiscono profondità al testo:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)
    text_frame = auto_shape.text_frame
    text_frame.text = "Aspose.Slides"

    text_frame.text_frame_format.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    text_frame.text_frame_format.three_d_format.bevel_bottom.height = 3.5
    text_frame.text_frame_format.three_d_format.bevel_bottom.width = 3.5

    text_frame.text_frame_format.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    text_frame.text_frame_format.three_d_format.bevel_top.height = 4
    text_frame.text_frame_format.three_d_format.bevel_top.width = 4

    text_frame.text_frame_format.three_d_format.extrusion_color.color = draw.Color.orange
    text_frame.text_frame_format.three_d_format.extrusion_height = 6

    text_frame.text_frame_format.three_d_format.contour_color.color = draw.Color.dark_red
    text_frame.text_frame_format.three_d_format.contour_width = 1.5

    text_frame.text_frame_format.three_d_format.depth = 3

    text_frame.text_frame_format.three_d_format.material = slides.MaterialPresetType.PLASTIC

    text_frame.text_frame_format.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    text_frame.text_frame_format.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    text_frame.text_frame_format.three_d_format.light_rig.set_rotation(0, 0, 40)

    text_frame.text_frame_format.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```

Il testo risultante:

![Effetto 3D del testo](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
L'applicazione di effetti 3D al testo o alle loro forme — e l'interazione tra questi effetti — è disciplinata da regole specifiche. Considera una scena che coinvolge sia il testo sia la forma che lo contiene. Un effetto 3D include la rappresentazione 3D dell'oggetto e la scena in cui è posizionato.

- Se una scena è impostata sia per la forma sia per il testo, la scena della forma ha la priorità e quella del testo viene ignorata.
- Se la forma non ha una sua scena ma possiede una rappresentazione 3D, viene usata la scena del testo.
- Se la forma non ha alcun effetto 3D, viene trattata come piatta e l'effetto 3D viene applicato solo al testo.

Questi comportamenti sono legati alle proprietà [ThreeDFormat.light_rig](https://reference.aspose.com/slides/it/python-net/aspose.slides/threedformat/light_rig/) e [ThreeDFormat.camera](https://reference.aspose.com/slides/it/python-net/aspose.slides/threedformat/camera/).
{{% /alert %}}

Per mantenere il testo piatto e leggibile conservando la formattazione 3D della forma, vedi [Mantieni testo piatto su una forma 3D](/slides/it/python-net/3d-presentation/) per un confronto di entrambe le impostazioni e un esempio Python completo.

## **Domande frequenti**

**Posso usare gli effetti WordArt con diversi caratteri o script (ad esempio arabo, cinese)?**

Sì, Aspose.Slides per Python via .NET supporta Unicode e funziona con tutti i principali caratteri e script. Gli effetti WordArt come ombra, riempimento e contorno possono essere applicati indipendentemente dalla lingua, sebbene la disponibilità dei caratteri e il rendering possano dipendere dai caratteri di sistema.

**Posso applicare gli effetti WordArt agli elementi del master delle diapositive?**

Sì, puoi applicare gli effetti WordArt alle forme nelle diapositive master, inclusi i segnaposto del titolo, i piè di pagina o il testo di sfondo. Le modifiche apportate al layout master verranno propagate a tutte le diapositive associate.

**Gli effetti WordArt influenzano la dimensione del file della presentazione?**

Leggermente. Gli effetti WordArt come ombre, bagliori e riempimenti a gradiente possono aumentare leggermente la dimensione del file a causa dei metadati di formattazione aggiunti, ma la differenza è di solito trascurabile.

**Posso visualizzare in anteprima il risultato degli effetti WordArt senza salvare la presentazione?**

Sì, puoi renderizzare le diapositive contenenti WordArt in immagini (ad esempio PNG, JPEG) utilizzando [Slide.get_image](https://reference.aspose.com/slides/it/python-net/aspose.slides/slide/get_image/), o renderizzare forme singole usando [Shape.get_image](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/get_image/). Questo ti consente di visualizzare l'anteprima del risultato in memoria o sullo schermo prima di salvare o esportare l'intera presentazione.