---
title: Applica effetti forma nelle presentazioni usando Python via Java
linktitle: Effetto forma
type: docs
weight: 30
url: /it/python-java/shape-effect/
keywords:
- effetto forma
- effetto ombra
- effetto riflessione
- effetto bagliore
- effetto bordi morbidi
- formato effetto
- PowerPoint
- presentazione
- Python
- Java
- Aspose.Slides
description: "Trasforma i tuoi file PPT e PPTX con effetti forma avanzati usando Aspose.Slides per Python via Java—crea diapositive sorprendenti e professionali in pochi secondi."
---
## **Introduzione**

Mentre gli effetti in PowerPoint possono essere usati per far risaltare una forma, differiscono da [riempimenti](/slides/it/python-java/shape-formatting/#gradient-fill) o contorni. Utilizzando gli effetti di PowerPoint, è possibile creare riflessioni convincenti su una forma, diffondere il bagliore di una forma, ecc.

![Effetto forma](shape-effect.png)

PowerPoint offre sei effetti che possono essere applicati alle forme. È possibile applicare uno o più effetti a una forma.

Alcune combinazioni di effetti risultano migliori di altre. Per questo motivo, PowerPoint fornisce opzioni sotto **Preset**. Le opzioni Preset sono combinazioni di due o più effetti noti per avere un aspetto gradevole. In questo modo, selezionando un preset, non dovrai perdere tempo a testare o combinare diversi effetti per trovare una buona combinazione.

Aspose.Slides fornisce proprietà e metodi nella classe [EffectFormat](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/) che consentono di applicare gli stessi effetti alle forme nelle presentazioni PowerPoint.

## **Applica un effetto ombra**

Aspose.Slides per Python via Java supporta ombre esterne e interne per le forme. È possibile personalizzare colore, direzione, distanza e raggio della sfocatura per adattarli al design della presentazione.

### **Applica un'ombra esterna**

Utilizza un'ombra esterna per far risaltare una scheda o un pannello rispetto allo sfondo della diapositiva. L'ombra si estende oltre i bordi della forma, creando l'impressione che la forma sia sollevata sopra la diapositiva. Regola colore, direzione, distanza e raggio della sfocatura per adattarli all'illuminazione e allo stile del tuo modello.

Questo codice Python mostra come applicare l'[effetto ombra esterna](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getOuterShadowEffect) a un rettangolo:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100)
    shape.getEffectFormat().enableOuterShadowEffect()
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color(169, 169, 169))
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10)
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45)

    presentation.save("shadow_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Effetto ombra](shadow_effect.png)

### **Applica un'ombra interna**

Quando si riproduce lo stile visivo di un modello, usa un'ombra interna per dare a una scheda o a un pannello un aspetto incassato. Un'ombra esterna si estende al di fuori della forma e la fa apparire sollevata, mentre un'ombra interna ombreggia l'interno dei suoi bordi.

Chiama [enableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enableInnerShadowEffect), quindi configura l'ombra restituita da [getInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getInnerShadowEffect). Valori più grandi del raggio della sfocatura producono bordi più morbidi.

Questo esempio Python crea una scheda azzurro chiaro con un'ombra interna grigio scuro e la salva come file PPTX. La direzione dell'ombra è di 225 gradi, la sua distanza è 7 punti e il raggio della sfocatura è 6 punti:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(173, 216, 230))
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    shape.getEffectFormat().enableInnerShadowEffect()
    shadow = shape.getEffectFormat().getInnerShadowEffect()
    shadow.getShadowColor().setColor(Color(105, 105, 105))
    shadow.setDirection(225)
    shadow.setDistance(7)
    shadow.setBlurRadius(6)

    presentation.save("inner_shadow_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Rettangolo azzurro chiaro con un'ombra interna](inner_shadow_effect.png)

Per rimuovere l'ombra interna, chiama [disableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableInnerShadowEffect) sul format dell'effetto della forma.

## **Applica un effetto di riflessione**

Per applicare un effetto di riflessione in Aspose.Slides per Python via Java, puoi aggiungere una riflessione simile a uno specchio alle forme, regolando parametri come distanza, trasparenza e dimensione. Questo effetto migliora l'estetica delle tue presentazioni conferendo alle forme un aspetto più curato e sofisticato. È facile da implementare con codice semplice, consentendo un'applicazione rapida su più elementi per un design coerente.

Questo codice Python mostra come applicare l'[effetto riflessione](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getReflectionEffect) a una forma:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RectangleAlignment, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100)
    shape.getEffectFormat().enableReflectionEffect()
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom)
    shape.getEffectFormat().getReflectionEffect().setDirection(90)
    shape.getEffectFormat().getReflectionEffect().setDistance(40)
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(2)

    presentation.save("reflection_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Effetto riflessione](reflection_effect.png)

## **Applica un effetto di bagliore**

Per applicare un effetto di bagliore a una forma in Aspose.Slides per Python via Java, è possibile aggiungere un'aura morbida e luminosa attorno alle forme, regolando proprietà come colore e dimensione. Questo effetto aiuta a far risaltare le forme e aggiunge un elemento visivo attraente e accattivante alla tua presentazione. È facile da implementare con poco codice, migliorando l'aspetto complessivo delle tue diapositive.

Questo codice Python mostra come applicare l'[effetto bagliore](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getGlowEffect) a una forma:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100)
    shape.getEffectFormat().enableGlowEffect()
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA)
    shape.getEffectFormat().getGlowEffect().setRadius(15)

    presentation.save("glow_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Effetto bagliore](glow_effect.png)

## **Applica un effetto bordi morbidi**

Per applicare un effetto bordi morbidi in Aspose.Slides per Python via Java, è possibile creare una transizione liscia e sfocata attorno ai bordi di una forma. Questo effetto aggiunge un aspetto più sottile e raffinato, perfetto per design che necessitano di un'apparenza delicata e più morbida. È possibile regolare facilmente parametri come il raggio per ottenere l'effetto desiderato su varie forme nella presentazione.

Questo codice Python mostra come applicare l'[effetto bordi morbidi](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getSoftEdgeEffect) a una forma:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150)
    shape.getEffectFormat().enableSoftEdgeEffect()
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(8)

    presentation.save("soft_edges_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Effetto bordi morbidi](soft_edges_effect.png)

## **Applica un effetto sfocatura**

Utilizza la sfocatura della forma per ammorbidire il riempimento e il contorno di una forma mantenendola modificabile. Chiama [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect) sul format dell'effetto della forma. Il raggio è misurato in punti (1/72 di pollice): usa un valore non negativo, con valori più grandi che producono una sfocatura più intensa. Un raggio pari a zero lascia inalterato l'aspetto.

L'impostazione [getGrow](https://reference.aspose.com/slides/python-java/aspose.slides/blur/#getGrow) controlla i limiti visibili dell'effetto. Con `False`, la sfocatura è ritagliata ai limiti dipinti originali, inclusi i contorni. Con `True`, la sfocatura può estendersi oltre tali limiti. Nessuna delle impostazioni modifica la posizione o le dimensioni della forma.

Il confronto qui sotto utilizza lo stesso riempimento, contorno e dimensioni della forma in tutti i casi. La riga superiore usa `grow = False`; la riga inferiore usa `grow = True`.

![Rettangolo originale confrontato con raggi di sfocatura di 5 e 15 punti, con grow disabilitato e abilitato](shape_blur_comparison.png)

Questo esempio Python crea un rettangolo arancione con un contorno blu scuro, applica una sfocatura di 5 punti e poi la aggiorna a 15 punti richiamando nuovamente [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect). Salva entrambi gli stati sfocati, quindi chiama [disableBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableBlurEffect) e salva la forma senza sfocatura.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 80, 160, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(255, 165, 0))
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color(0, 0, 139))
    shape.getLineFormat().setWidth(8)

    shape.getEffectFormat().setBlurEffect(5, False)
    presentation.save("shape_blur_5.pptx", SaveFormat.Pptx)

    shape.getEffectFormat().setBlurEffect(15, True)
    presentation.save("shape_blur_15.pptx", SaveFormat.Pptx)

    shape.getEffectFormat().disableBlurEffect()
    presentation.save("shape_blur_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La sfocatura della forma interessa sia il riempimento sia il contorno insieme. Un effetto bordi morbidi attenua i bordi della forma, mentre la sfocatura dell'ombra ammorbidisce solo l'ombra. Gli effetti di trasformazione dell'immagine operano sul contenuto dell'immagine; questo esempio applica la sfocatura direttamente al format dell'effetto della forma senza convertire la forma in un'immagine.

## **FAQ**

**Posso applicare più effetti alla stessa forma?**

Sì, è possibile combinare effetti diversi, come ombra, riflessione e bagliore, su una singola forma per creare un aspetto più dinamico.

**Su quali forme posso applicare gli effetti?**

È possibile applicare effetti a varie forme, incluse autoshape, grafici, tabelle, immagini, oggetti SmartArt, oggetti OLE e altro.

**Posso applicare effetti a forme raggruppate?**

Sì, è possibile applicare effetti a forme raggruppate. L'effetto verrà applicato all'intero gruppo.