---
title: Crea e applica effetti WordArt in Python via Java
linktitle: WordArt
type: docs
weight: 110
url: /it/python-java/wordart/
keywords:
- WordArt
- creare WordArt
- modello WordArt
- effetto WordArt
- effetto ombra
- effetto riflessione
- effetto bagliore
- trasformazione WordArt
- effetto 3D
- effetto ombra esterna
- effetto ombra interna
- PowerPoint
- presentazione
- Python
- Java
- Aspose.Slides
description: "Crea e personalizza gli effetti WordArt in Aspose.Slides per Python via Java. Questa guida passo passo aiuta gli sviluppatori a migliorare le presentazioni con testo professionale in Python via Java."
---
## **Panoramica**

Le effetti WordArt consentono di aggiungere testo stilizzato e visivamente attraente alle presentazioni PowerPoint. Con Aspose.Slides, gli sviluppatori possono creare, personalizzare e gestire programmaticamente WordArt proprio come in Microsoft PowerPoint, senza la necessità di avere Office installato. Questo articolo fornisce una panoramica sull'utilizzo di WordArt, includendo come applicare trasformazioni di testo, stili di riempimento, contorni, ombre e altre opzioni di formattazione per rendere il contenuto della presentazione più espressivo e coinvolgente. WordArt consente di trattare il testo come un oggetto grafico. È costituito da effetti o modifiche speciali applicate al testo per renderlo più attraente o evidente.

## **Crea un modello WordArt semplice e applicalo al testo**

**Utilizzando Aspose.Slides**

Per prima cosa, creiamo del testo semplice usando questo codice Python:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()

    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
finally:
    presentation.dispose()
```
Successivamente, aumentiamo la dimensione del carattere per rendere l'effetto più evidente:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    font_data = FontData("Arial Black")
    portion_format = portion.getPortionFormat()
    portion_format.setLatinFont(font_data)
    portion_format.setFontHeight(36)
finally:
    presentation.dispose()
```

**Utilizzando Microsoft PowerPoint**

Vai al menu degli effetti WordArt in Microsoft PowerPoint:

![WordArt effects menu in PowerPoint](image-20200930113926-1.png)

Dalla barra laterale destra, è possibile scegliere un effetto WordArt predefinito. Dalla barra laterale sinistra, è possibile specificare le impostazioni per un nuovo WordArt.

Ecco alcuni dei parametri o opzioni disponibili:

![WordArt formatting options](image-20200930114015-3.png)

**Utilizzando Aspose.Slides**

Qui applichiamo il riempimento a pattern [PatternStyle.SmallGrid](https://reference.aspose.com/slides/it/python-java/aspose.slides/patternstyle/#SmallGrid) al testo e aggiungiamo un bordo testuale nero usando questo codice:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PatternStyle, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getFillFormat().setFillType(FillType.Pattern)
    pattern_format = portion_format.getFillFormat().getPatternFormat()
    pattern_format.getForeColor().setColor(Color.ORANGE)
    pattern_format.getBackColor().setColor(Color.WHITE)
    pattern_format.setPatternStyle(PatternStyle.SmallGrid)

    line_format = portion_format.getLineFormat()
    line_format.getFillFormat().setFillType(FillType.Solid)
    line_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)
finally:
    presentation.dispose()
```

Il testo risultante:

![Text with a pattern fill and black outline](image-20200930114108-4.png)

## **Applicare altri effetti WordArt**

**Utilizzando Microsoft PowerPoint**

Dall'interfaccia del programma, è possibile applicare questi effetti a testo, blocco di testo, forma o un elemento simile:

![Text and shape effects in PowerPoint](image-20200930114129-5.png)

Ad esempio, gli effetti Ombra, Riflesso e Bagliore possono essere applicati al testo; gli effetti Formato 3D e Rotazione 3D possono essere applicati a un blocco di testo; l'effetto Bordi morbidi può essere applicato a una forma (ha comunque effetto quando non è impostato alcun effetto Formato 3D).

### **Applicare effetti Ombra**

Il seguente codice Python applica un effetto ombra solo al testo:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getEffectFormat().enableOuterShadowEffect()
    outer_shadow = portion_format.getEffectFormat().getOuterShadowEffect()
    outer_shadow.getShadowColor().setColor(Color.BLACK)
    outer_shadow.setScaleHorizontal(100)
    outer_shadow.setScaleVertical(65)
    outer_shadow.setBlurRadius(4.73)
    outer_shadow.setDirection(230)
    outer_shadow.setDistance(2)
    outer_shadow.setSkewHorizontal(30)
    outer_shadow.setSkewVertical(0)
    outer_shadow.getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32)
finally:
    presentation.dispose()
```

L'API Aspose.Slides supporta tre tipi di ombre: [OuterShadow](https://reference.aspose.com/slides/it/python-java/aspose.slides/outershadow/), [InnerShadow](https://reference.aspose.com/slides/it/python-java/aspose.slides/innershadow/), e [PresetShadow](https://reference.aspose.com/slides/it/python-java/aspose.slides/presetshadow/).

Con [PresetShadow](https://reference.aspose.com/slides/it/python-java/aspose.slides/presetshadow/), è possibile applicare un'ombra al testo utilizzando valori predefiniti.

**Utilizzando Microsoft PowerPoint**

In PowerPoint, è possibile utilizzare un solo tipo di ombra. Ecco un esempio:

![Shadow settings in PowerPoint](image-20200930114225-6.png)

**Utilizzando Aspose.Slides**

Aspose.Slides consente effettivamente di applicare due tipi di ombre contemporaneamente: [InnerShadow](https://reference.aspose.com/slides/it/python-java/aspose.slides/innershadow/) e [PresetShadow](https://reference.aspose.com/slides/it/python-java/aspose.slides/presetshadow/).

**Note:**

- Quando [OuterShadow](https://reference.aspose.com/slides/it/python-java/aspose.slides/outershadow/) e [PresetShadow](https://reference.aspose.com/slides/it/python-java/aspose.slides/presetshadow/) sono utilizzati insieme, viene applicato solo l'effetto [OuterShadow](https://reference.aspose.com/slides/it/python-java/aspose.slides/outershadow/).
- Se [OuterShadow](https://reference.aspose.com/slides/it/python-java/aspose.slides/outershadow/) e [InnerShadow](https://reference.aspose.com/slides/it/python-java/aspose.slides/innershadow/) sono usati simultaneamente, l'effetto risultante o applicato dipende dalla versione di PowerPoint. Ad esempio, in PowerPoint 2013, l'effetto è duplicato. Invece, in PowerPoint 2007, viene applicato l'effetto [OuterShadow](https://reference.aspose.com/slides/it/python-java/aspose.slides/outershadow/).

### **Applicare riflessione al testo**

Aggiungiamo una riflessione al testo tramite questo esempio di codice in Python via Java:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RectangleAlignment, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getEffectFormat().enableReflectionEffect()
    reflection = portion_format.getEffectFormat().getReflectionEffect()
    reflection.setBlurRadius(0.5)
    reflection.setDistance(4.72)
    reflection.setStartPosAlpha(0)
    reflection.setEndPosAlpha(60)
    reflection.setDirection(90)
    reflection.setScaleHorizontal(100)
    reflection.setScaleVertical(-100)
    reflection.setStartReflectionOpacity(60)
    reflection.setEndReflectionOpacity(0.9)
    reflection.setRectangleAlign(RectangleAlignment.BottomLeft)
finally:
    presentation.dispose()
```

### **Applicare un effetto Bagliore al testo**

Applichiamo l'effetto bagliore al testo per farlo brillare o risaltare usando questo codice:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")

    portion_format = portion.getPortionFormat()
    portion_format.getEffectFormat().enableGlowEffect()
    glow = portion_format.getEffectFormat().getGlowEffect()
    glow.getColor().setR(jpype.JByte(-1))
    glow.getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54)
    glow.setRadius(7)
finally:
    presentation.dispose()
```

Il risultato dell'operazione:

![Text with a glow effect](image-20200930114621-7.png)

{{% alert color="info" title="Note" %}}
Puoi modificare i parametri per ombra, riflessione e bagliore. Le proprietà degli effetti vengono impostate separatamente per ciascuna parte del testo.
{{% /alert %}}

### **Utilizzare le trasformazioni in WordArt**

Utilizza [TextFrameFormat.setTransform](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframeformat/#setTransform) per trasformare l'intero blocco di testo:

```python
import jpime
import asposeslides

if not jpime.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import Presentation, ShapeType, TextShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    text_frame.setText("Aspose.Slides")

    text_frame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour)
finally:
    presentation.dispose()
```

Il risultato:

![Text with an arch transformation](image-20200930114712-8.png)

{{% alert color="info" title="Note" %}}
sia Microsoft PowerPoint sia Aspose.Slides per Python via Java offrono un certo numero di tipi di trasformazione predefiniti.
{{% /alert %}}

**Utilizzando PowerPoint**

Per accedere ai tipi di trasformazione predefiniti, vai su: **Formato** -> **EffettoTesto** -> **Trasforma**

**Utilizzando Aspose.Slides**

Per selezionare un tipo di trasformazione, utilizza l'enumerazione [TextShapeType](https://reference.aspose.com/slides/it/python-java/aspose.slides/textshapetype/).

### **Applicare effetti 3D a testo e forme**

Applichiamo un effetto 3D a una forma di testo usando questo esempio di codice:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    auto_shape.getTextFrame().setText("Aspose.Slides")

    three_d_format = auto_shape.getThreeDFormat()
    three_d_format.getBevelBottom().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelBottom().setHeight(10.5)
    three_d_format.getBevelBottom().setWidth(10.5)

    three_d_format.getBevelTop().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelTop().setHeight(12.5)
    three_d_format.getBevelTop().setWidth(11)

    three_d_format.getExtrusionColor().setColor(Color.ORANGE)
    three_d_format.setExtrusionHeight(6)

    three_d_format.getContourColor().setColor(Color.RED)
    three_d_format.setContourWidth(1.5)

    three_d_format.setDepth(3)

    three_d_format.setMaterial(MaterialPresetType.Plastic)

    three_d_format.getLightRig().setDirection(LightingDirection.Top)
    three_d_format.getLightRig().setLightType(LightRigPresetType.Balanced)
    three_d_format.getLightRig().setRotation(0, 0, 40)

    three_d_format.getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)
finally:
    presentation.dispose()
```

Il testo risultante e la sua forma:

![Text shape with 3D effects](image-20200930114816-9.png)

Applichiamo un effetto 3D al testo con questo codice Python:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = auto_shape.getTextFrame()
    text_frame.setText("Aspose.Slides")

    three_d_format = text_frame.getTextFrameFormat().getThreeDFormat()
    three_d_format.getBevelBottom().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelBottom().setHeight(3.5)
    three_d_format.getBevelBottom().setWidth(3.5)

    three_d_format.getBevelTop().setBevelType(BevelPresetType.Circle)
    three_d_format.getBevelTop().setHeight(4)
    three_d_format.getBevelTop().setWidth(4)

    three_d_format.getExtrusionColor().setColor(Color.ORANGE)
    three_d_format.setExtrusionHeight(6)

    three_d_format.getContourColor().setColor(Color.RED)
    three_d_format.setContourWidth(1.5)

    three_d_format.setDepth(3)

    three_d_format.setMaterial(MaterialPresetType.Plastic)

    three_d_format.getLightRig().setDirection(LightingDirection.Top)
    three_d_format.getLightRig().setLightType(LightRigPresetType.Balanced)
    three_d_format.getLightRig().setRotation(0, 0, 40)

    three_d_format.getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)
finally:
    presentation.dispose()
```

Il risultato dell'operazione:

![Text with 3D effects](image-20200930114905-10.png)

{{% alert color="info" title="Note" %}}
Applicare effetti 3D al testo o alle sue forme e le interazioni tra gli effetti sono basati su determinate regole.

Considera una scena per il testo e la forma contenente quel testo. L'effetto 3D comprende una rappresentazione dell'oggetto 3D e la scena in cui l'oggetto è posizionato.

- Quando la scena è impostata sia per la forma sia per il testo, la scena della forma ha la priorità: la scena del testo viene ignorata.
- Quando la forma non ha una sua scena ma ha una rappresentazione 3D, viene utilizzata la scena del testo.
- Altrimenti — quando la forma originariamente non ha alcun effetto 3D — la forma è piatta e l'effetto 3D viene applicato solo al testo.

Queste regole si riferiscono ai metodi [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/it/python-java/aspose.slides/threedformat/#getLightRig) e [ThreeDFormat.getCamera](https://reference.aspose.com/slides/it/python-java/aspose.slides/threedformat/#getCamera).
{{% /alert %}}

## **Applicare effetti Ombra esterna al testo**

Aspose.Slides per Python via Java fornisce le classi [OuterShadow](https://reference.aspose.com/slides/it/python-java/aspose.slides/outershadow/) e [InnerShadow](https://reference.aspose.com/slides/it/python-java/aspose.slides/innershadow/) che consentono di applicare effetti di ombra al testo in un [TextFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframe/). Segui questi passaggi:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) .
2. Ottieni il riferimento a una diapositiva usando il suo indice.
3. Aggiungi una forma rettangolare alla diapositiva.
4. Accedi al frame di testo associato alla forma.
5. Disattiva il riempimento della forma.
6. Abilita l'effetto ombra esterna.
7. Imposta il raggio di sfocatura dell'ombra.
8. Imposta la direzione dell'ombra.
9. Imposta la distanza dell'ombra.
10. Allinea l'ombra in alto a sinistra.
11. Imposta il colore dell'ombra su nero.
12. Salva la presentazione come file [PPTX](https://docs.fileformat.com/presentation/pptx/) .

Questo codice di esempio in Python via Java — un'implementazione dei passaggi sopra — mostra come applicare l'effetto ombra esterna al testo:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, PresetColor, RectangleAlignment, SaveFormat, ShapeType

presentation = Presentation()
try:
    # Ottieni il riferimento della diapositiva
    slide = presentation.getSlides().get_Item(0)

    # Aggiungi un AutoShape di tipo Rettangolo
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50)

    # Aggiungi TextFrame al Rettangolo
    auto_shape.addTextFrame("Aspose TextBox")

    # Disattiva il riempimento della forma nel caso volessimo ottenere l'ombra del testo
    auto_shape.getFillFormat().setFillType(FillType.NoFill)

    # Aggiungi ombra esterna e imposta tutti i parametri necessari
    auto_shape.getEffectFormat().enableOuterShadowEffect()
    shadow = auto_shape.getEffectFormat().getOuterShadowEffect()
    shadow.setBlurRadius(4.0)
    shadow.setDirection(45)
    shadow.setDistance(3)
    shadow.setRectangleAlign(RectangleAlignment.TopLeft)
    shadow.getShadowColor().setPresetColor(PresetColor.Black)

    # Scrivi la presentazione su disco
    presentation.save("pres_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Applicare effetto Ombra interna alle forme**

Segui questi passaggi:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) .
2. Ottieni un riferimento alla diapositiva.
3. Aggiungi una forma rettangolare.
4. Abilita l'effetto ombra interna.
5. Imposta tutti i parametri necessari.
6. Imposta il tipo di colore dell'ombra per utilizzare un colore del tema.
7. Imposta il colore del tema.
8. Salva la presentazione come file [PPTX](https://docs.fileformat.com/presentation/pptx/) .

Questo codice di esempio (basato sui passaggi sopra) mostra come applicare l'effetto ombra interna al testo in una forma in Python via Java:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorType, FillType, Presentation, SaveFormat, SchemeColor, ShapeType

presentation = Presentation()
try:
    # Ottieni il riferimento della diapositiva
    slide = presentation.getSlides().get_Item(0)

    # Aggiungi un AutoShape di tipo Rectangle
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300)
    auto_shape.getFillFormat().setFillType(FillType.NoFill)

    # Aggiungi TextFrame al Rectangle
    auto_shape.addTextFrame("Aspose TextBox")
    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion_format = portion.getPortionFormat()
    portion_format.setFontHeight(50)

    # Abilita InnerShadowEffect
    effect_format = portion_format.getEffectFormat()
    effect_format.enableInnerShadowEffect()

    # Imposta tutti i parametri necessari
    inner_shadow = effect_format.getInnerShadowEffect()
    inner_shadow.setBlurRadius(8.0)
    inner_shadow.setDirection(90.0)
    inner_shadow.setDistance(6.0)
    inner_shadow.getShadowColor().setB(jpype.JByte(-67))

    # Imposta ColorType come Scheme
    inner_shadow.getShadowColor().setColorType(ColorType.Scheme)

    # Imposta Scheme Color
    inner_shadow.getShadowColor().setSchemeColor(SchemeColor.Accent1)

    # Salva la presentazione
    presentation.save("WordArt_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Posso utilizzare gli effetti WordArt con diversi caratteri o script (ad esempio, arabo, cinese)?**

Sì, Aspose.Slides supporta Unicode e funziona con tutti i principali caratteri e script. Gli effetti WordArt come ombra, riempimento e contorno possono essere applicati indipendentemente dalla lingua, sebbene la disponibilità dei caratteri e il rendering possano dipendere dai caratteri di sistema.

**Posso applicare gli effetti WordArt agli elementi del master della diapositiva?**

Sì, è possibile applicare gli effetti WordArt alle forme nei master delle diapositive, inclusi i segnaposto del titolo, i piè di pagina o il testo di sfondo. Le modifiche apportate al layout master verranno riflesse in tutte le diapositive associate.

**Gli effetti WordArt influiscono sulla dimensione del file della presentazione?**

Leggermente. Gli effetti WordArt come ombre, bagliori e riempimenti a gradiente possono aumentare leggermente la dimensione del file a causa dei metadati di formattazione aggiunti, ma la differenza è generalmente trascurabile.

**Posso visualizzare in anteprima il risultato degli effetti WordArt senza salvare la presentazione?**

Sì, è possibile renderizzare le diapositive contenenti WordArt in immagini (ad esempio PNG, JPEG) utilizzando [Shape.getImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#getImage) o [Slide.getImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/slide/#getImage). Questo consente di visualizzare in anteprima il risultato in memoria o sullo schermo prima di salvare o esportare l'intera presentazione.