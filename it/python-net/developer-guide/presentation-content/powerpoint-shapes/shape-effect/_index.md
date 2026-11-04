---
title: Applicare effetti forma nelle presentazioni con Python
linktitle: Effetto Forma
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

Mentre gli effetti in PowerPoint possono essere usati per far risaltare una forma, differiscono da [riempimenti](/slides/it/python-net/shape-formatting/#gradient-fill) o contorni. Utilizzando gli effetti di PowerPoint, è possibile creare riflessi convincenti su una forma, diffondere il bagliore di una forma, ecc.

![Effetto forma](shape-effect.png)

PowerPoint offre sei effetti che possono essere applicati alle forme. È possibile applicare uno o più effetti a una forma.

Alcune combinazioni di effetti risultano migliori di altre. Per questo motivo, PowerPoint dispone di opzioni nella sezione **Preset**. Le opzioni Preset sono essenzialmente una combinazione nota e gradevole di due o più effetti. In questo modo, selezionando un preset, non dovrai perdere tempo a testare o combinare diversi effetti per trovare una buona combinazione.

Aspose.Slides fornisce proprietà e metodi nella classe [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) che consentono di applicare gli stessi effetti alle forme nelle presentazioni PowerPoint.

## **Applicare un effetto ombra**

Aspose.Slides per Python tramite .NET supporta ombre esterne e interne per le forme. È possibile personalizzare colore, direzione, distanza e raggio di sfocatura per adeguarli al design della presentazione.

### **Applicare un'ombra esterna**

Usa un'ombra esterna per far risaltare una scheda o un pannello rispetto allo sfondo della diapositiva. L'ombra si estende oltre i bordi della forma, creando l'impressione che la forma sia sollevata sopra la diapositiva. Regola colore, direzione, distanza e raggio di sfocatura per adeguarli all'illuminazione e allo stile del tuo modello.

Questo codice Python mostra come applicare l'[effetto ombra esterna](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/outer_shadow_effect/) a un rettangolo:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_outer_shadow_effect()
    shape.effect_format.outer_shadow_effect.shadow_color.color = slides.Color.dark_gray
    shape.effect_format.outer_shadow_effect.distance = 10
    shape.effect_format.outer_shadow_effect.direction = 45

    presentation.save("shadow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Effetto ombra](shadow_effect.png)

### **Applicare un'ombra interna**

Quando si replica lo stile visivo di un modello, usa un'ombra interna per dare a una scheda o a un pannello un aspetto incassato. Un'ombra esterna si estende al di fuori della forma e la fa apparire sollevata, mentre un'ombra interna ombreggia l'interno dei suoi bordi.

Chiama [enable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/enable_inner_shadow_effect/), quindi configura [inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/inner_shadow_effect/). Valori più grandi del raggio di sfocatura producono bordi più morbidi.

Questo esempio Python crea una scheda azzurra chiara con un'ombra interna grigio scuro e lo salva come file PPTX:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = slides.Color.light_blue
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    shape.effect_format.enable_inner_shadow_effect()
    shadow = shape.effect_format.inner_shadow_effect
    shadow.shadow_color.color = slides.Color.dim_gray
    shadow.direction = 225
    shadow.distance = 7
    shadow.blur_radius = 6

    presentation.save("inner_shadow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Rettangolo azzurro chiaro con un'ombra interna](inner_shadow_effect.png)

Per rimuovere l'ombra interna, chiama [disable_inner_shadow_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_inner_shadow_effect/) sul formato effetto della forma.

## **Applicare un effetto riflessione**

Per applicare un effetto riflessione in Aspose.Slides per Python tramite .NET, è possibile aggiungere una riflessione simile a uno specchio alle forme, regolando parametri come distanza, trasparenza e dimensione. Questo effetto migliora l'estetica delle tue presentazioni conferendo alle forme un aspetto più rifinito e sofisticato. È facile da implementare con codice semplice, consentendo un'applicazione rapida su più elementi per un design coerente.

Questo codice Python mostra come applicare l'[effetto riflessione](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/reflection_effect/) a una forma:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_reflection_effect()
    shape.effect_format.reflection_effect.rectangle_align = slides.RectangleAlignment.BOTTOM
    shape.effect_format.reflection_effect.direction = 90
    shape.effect_format.reflection_effect.distance = 40
    shape.effect_format.reflection_effect.blur_radius = 2

    presentation.save("reflection_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Effetto riflessione](reflection_effect.png)

## **Applicare un effetto bagliore**

Per applicare un effetto bagliore a una forma in Aspose.Slides per Python tramite .NET, è possibile aggiungere un'aura luminosa soffusa intorno alle forme, regolando proprietà come colore e dimensione. Questo effetto aiuta a far risaltare le forme e aggiunge un elemento visivo attraente e accattivante alla presentazione. È facile da implementare con poco codice, migliorando l'aspetto complessivo delle diapositive.

Questo codice Python mostra come applicare l'[effetto bagliore](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/glow_effect/) a una forma:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 100)
    shape.effect_format.enable_glow_effect()
    shape.effect_format.glow_effect.color.color = slides.Color.magenta
    shape.effect_format.glow_effect.radius = 15

    presentation.save("glow_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Effetto bagliore](glow_effect.png)

## **Applicare un effetto bordi morbidi**

Per applicare un effetto bordi morbidi in Aspose.Slides per Python tramite .NET, è possibile creare una transizione liscia e sfocata attorno ai bordi di una forma. Questo effetto aggiunge un aspetto più delicato e raffinato, perfetto per design che richiedono un'apparenza più morbida. È possibile regolare facilmente parametri come il raggio per ottenere l'effetto desiderato su varie forme nella presentazione.

Questo codice Python mostra come applicare i [bordi morbidi](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/soft_edge_effect/) a una forma:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 20, 20, 200, 150)
    shape.effect_format.enable_soft_edge_effect()
    shape.effect_format.soft_edge_effect.radius = 8

    presentation.save("soft_edges_effect.pptx", slides.export.SaveFormat.PPTX)
```

![Effetto bordi morbidi](soft_edges_effect.png)

## **Applicare un effetto sfocatura**

Usa la sfocatura della forma per ammorbidire il riempimento e il contorno della forma mantenendola modificabile. Chiama [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/) sul formato effetto della forma. Il raggio è misurato in punti (1/72 di pollice): usa un valore non negativo, con valori più grandi che producono una sfocatura più forte. Un raggio di zero lascia l'aspetto invariato.

L'impostazione [grow](https://reference.aspose.com/slides/python-net/aspose.slides.effects/blur/grow/) controlla i limiti visibili dell'effetto. Con `False`, la sfocatura è ritagliata ai limiti originali dipinti, includendo il contorno. Con `True`, la sfocatura può estendersi oltre quei limiti. Nessuna delle due impostazioni modifica la posizione o le dimensioni della forma.

Il confronto sotto utilizza lo stesso riempimento, contorno e dimensioni della forma in tutto. La riga superiore usa `grow = False`; la riga inferiore usa `grow = True`.

![Rettangolo originale confrontato con raggi di sfocatura di 5 e 15 punti, con grow disabilitato e abilitato](shape_blur_comparison.png)

Questo esempio Python crea un rettangolo arancione con un contorno blu scuro, applica una sfocatura di 5 punti e poi la aggiorna a 15 punti chiamando nuovamente [set_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/set_blur_effect/). Salva entrambi gli stati sfocati, quindi chiama [disable_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/disable_blur_effect/) e salva la forma senza sfocatura.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 80, 160, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = slides.Color.orange
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = slides.Color.dark_blue
    shape.line_format.width = 8

    shape.effect_format.set_blur_effect(5, False)
    presentation.save("shape_blur_5.pptx", slides.export.SaveFormat.PPTX)

    shape.effect_format.set_blur_effect(15, True)
    presentation.save("shape_blur_15.pptx", slides.export.SaveFormat.PPTX)

    shape.effect_format.disable_blur_effect()
    presentation.save("shape_blur_removed.pptx", slides.export.SaveFormat.PPTX)
```

La sfocatura della forma influisce sia sul riempimento sia sul contorno. Un effetto bordi morbidi attenua i bordi della forma, mentre la sfocatura dell'ombra ammorbidisce solo l'ombra. Gli effetti di trasformazione delle immagini operano sul contenuto dell'immagine; questo esempio applica la sfocatura direttamente al formato effetto della forma senza convertire la forma in un'immagine.

## **FAQ**

**Posso applicare più effetti alla stessa forma?**

Sì, è possibile combinare diversi effetti, come ombra, riflessione e bagliore, su una singola forma per creare un aspetto più dinamico.

**Su quali forme posso applicare gli effetti?**

È possibile applicare effetti a varie forme, inclusi autoshape, grafici, tabelle, immagini, oggetti SmartArt, oggetti OLE e altro.

**Posso applicare effetti a forme raggruppate?**

Sì, è possibile applicare effetti a forme raggruppate. L'effetto verrà applicato all'intero gruppo.