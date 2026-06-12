---
title: Applica effetti forma nelle presentazioni con Python
linktitle: Effetto forma
type: docs
weight: 30
url: /it/python-net/shape-effect
keywords:
- effetto forma
- effetto ombra
- effetto riflessione
- effetto bagliore
- effetto bordi morbidi
- formato effetto
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Trasforma i tuoi file PPT, PPTX e ODP con effetti forma avanzati usando Aspose.Slides per Python—crea diapositive sorprendenti e professionali in pochi secondi."
---
## **Introduzione**

Mentre gli effetti in PowerPoint possono essere usati per far risaltare una forma, differiscono da [riempimenti](/slides/it/python-net/shape-formatting/#gradient-fill) o contorni. Usando gli effetti di PowerPoint, è possibile creare riflessioni convincenti su una forma, diffondere il bagliore di una forma, ecc.

<img src="shape-effect.png" alt="effetto-forma" style="zoom:50%;" />

* PowerPoint offre sei effetti che possono essere applicati alle forme. È possibile applicare uno o più effetti a una forma. 

* Alcune combinazioni di effetti sono più gradevoli di altre. Per questo motivo, le opzioni di PowerPoint si trovano sotto **Preset**. Le opzioni Preset sono essenzialmente una combinazione già nota ed esteticamente gradevole di due o più effetti. In questo modo, scegliendo un preset, non dovrai perdere tempo a testare o combinare diversi effetti per trovare una buona combinazione.

Aspose.Slides fornisce proprietà e metodi nella classe [EffectFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides/effectformat/) che consentono di applicare gli stessi effetti alle forme nelle presentazioni PowerPoint.

## **Applicare l'effetto ombra**

Questo codice Python mostra come applicare l'effetto ombra esterna (`outer_shadow_effect`) a un rettangolo:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_outer_shadow_effect()
    shape.effect_format.outer_shadow_effect.shadow_color.color = draw.Color.dark_gray
    shape.effect_format.outer_shadow_effect.distance = 10
    shape.effect_format.outer_shadow_effect.direction = 45

    pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Applicare l'effetto riflessione**

Questo codice Python mostra come applicare l'effetto di riflessione a una forma:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_reflection_effect()
    shape.effect_format.reflection_effect.rectangle_align = slides.RectangleAlignment.BOTTOM
    shape.effect_format.reflection_effect.direction = 90
    shape.effect_format.reflection_effect.distance = 55
    shape.effect_format.reflection_effect.blur_radius = 4

    pres.save("reflection.pptx", slides.export.SaveFormat.PPTX)
```

## **Applicare l'effetto bagliore**

Questo codice Python mostra come applicare l'effetto bagliore a una forma:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_glow_effect()
    shape.effect_format.glow_effect.color.color = draw.Color.magenta
    shape.effect_format.glow_effect.radius = 15

    pres.save("glow.pptx", slides.export.SaveFormat.PPTX)
```

## **Applicare l'effetto bordi soffici**

Questo codice Python mostra come applicare i bordi soffici a una forma:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)

    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 15

    pres.save("softEdges.pptx", slides.export.SaveFormat.PPTX)
```

## **Domande frequenti**

**Posso applicare più effetti alla stessa forma?**

Sì, è possibile combinare diversi effetti, come ombra, riflessione e bagliore, su una singola forma per ottenere un aspetto più dinamico.

**Su quali forme posso applicare effetti?**

È possibile applicare effetti a varie forme, inclusi autoshapes, grafici, tabelle, immagini, oggetti SmartArt, oggetti OLE e altro.

**Posso applicare effetti a forme raggruppate?**

Sì, è possibile applicare effetti a forme raggruppate. L'effetto verrà applicato all'intero gruppo.