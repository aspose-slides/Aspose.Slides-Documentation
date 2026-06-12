---
title: Crea e applica effetti WordArt in JavaScript
linktitle: WordArt
type: docs
weight: 110
url: /it/nodejs-java/wordart/
keywords:
- WordArt
- crea WordArt
- modello WordArt
- effetto WordArt
- effetto ombra
- effetto visualizzazione
- effetto bagliore
- trasformazione WordArt
- effetto 3D
- effetto ombra esterna
- effetto ombra interna
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Crea e personalizza gli effetti WordArt in Aspose.Slides per Node.js. Questa guida passo passo aiuta gli sviluppatori a migliorare le presentazioni con testo professionale."
---
## **Panoramica**

Le effetti di WordArt ti consentono di aggiungere testo visivamente attraente e stilizzato alle tue presentazioni PowerPoint. Con Aspose.Slides, gli sviluppatori possono creare, personalizzare e gestire WordArt in modo programmato proprio come in Microsoft PowerPoint, senza la necessità di avere Office installato. Questo articolo fornisce una panoramica sul lavoro con WordArt, inclusa l’applicazione di trasformazioni del testo, stili di riempimento, contorni, ombre e altre opzioni di formattazione per rendere il contenuto della presentazione più espressivo e coinvolgente. WordArt ti permette di trattare il testo come un oggetto grafico. È costituito da effetti o modifiche speciali applicate al testo per renderlo più attraente o evidente.

## **Creazione di un modello WordArt semplice e sua applicazione a un testo**

**Utilizzo di Aspose.Slides** 

Prima, creiamo un testo semplice utilizzando questo codice JavaScript:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    var textFrame = autoShape.getTextFrame();
    var portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
Ora, impostiamo l’altezza del carattere del testo a un valore più grande per rendere l’effetto più evidente tramite questo codice:

```javascript
var fontData = new aspose.slides.FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```

**Utilizzo di Microsoft PowerPoint**

Vai al menu degli effetti WordArt in Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Dal menu a destra, puoi scegliere un effetto WordArt predefinito. Dal menu a sinistra, puoi specificare le impostazioni per un nuovo WordArt. 

Questi sono alcuni dei parametri o opzioni disponibili:

![todo:image_alt_text](image-20200930114015-3.png)

**Utilizzo di Aspose.Slides**

Qui, applichiamo il colore del pattern [SmallGrid](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/PatternStyle#SmallGrid) al testo e aggiungiamo un contorno di testo nero di larghezza 1 usando questo codice:

```javascript
portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.SmallGrid));
portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
```

Il testo risultante:

![todo:image_alt_text](image-20200930114108-4.png)

## **Applicazione di altri effetti WordArt**

**Utilizzo di Microsoft PowerPoint**

Dal gruppo del programma, puoi applicare questi effetti a un testo, blocco di testo, forma o elemento simile:

![todo:image_alt_text](image-20200930114129-5.png)

Ad esempio, gli effetti Ombra, Riflesso e Bagliore possono essere applicati a un testo; gli effetti Formato 3D e Rotazione 3D possono essere applicati a un blocco di testo; la proprietà Bordi morbidi può essere applicata a un oggetto Forma (ha comunque un effetto quando non è impostata alcuna proprietà Formato 3D). 

### **Applicazione degli effetti Ombra**

Qui, intendiamo impostare le proprietà relative solo a un testo. Applichiamo l’effetto ombra a un testo usando questo codice in JavaScript:

```javascript
portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(65);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4.73);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(2);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(30);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, 0.32);
```

L’API Aspose.Slides supporta tre tipi di ombre: OuterShadow, InnerShadow e PresetShadow. 

Con PresetShadow, puoi applicare un’ombra a un testo (usando valori predefiniti). 

**Utilizzo di Microsoft PowerPoint**

In PowerPoint, puoi usare un solo tipo di ombra. Ecco un esempio:

![todo:image_alt_text](image-20200930114225-6.png)

**Utilizzo di Aspose.Slides**

Aspose.Slides consente effettivamente di applicare due tipi di ombre contemporaneamente: InnerShadow e PresetShadow.

Note:
- Quando OuterShadow e PresetShadow vengono usati insieme, viene applicato solo l’effetto OuterShadow. 
- Se OuterShadow e InnerShadow vengono usati simultaneamente, l’effetto risultante o applicato dipende dalla versione di PowerPoint. Ad esempio, in PowerPoint 2013, l’effetto viene raddoppiato. Ma in PowerPoint 2007, viene applicato l’effetto OuterShadow. 

### **Applicazione della visualizzazione ai testi**

Aggiungiamo la visualizzazione al testo tramite questo esempio di codice in JavaScript:

```javascript
portion.getPortionFormat().getEffectFormat().enableReflectionEffect();
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(0.0);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(60.0);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(60.0);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(0.9);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(aspose.slides.RectangleAlignment.BottomLeft);
```

### **Applicazione dell’effetto Bagliore ai testi**

Applichiamo l’effetto Bagliore al testo per farlo risplendere o risaltare usando questo codice:

```javascript
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR(255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, 0.54);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```

Il risultato dell’operazione:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

Puoi modificare i parametri per ombra, visualizzazione e bagliore. Le proprietà degli effetti vengono impostate separatamente per ogni porzione del testo. 

{{% /alert %}} 

### **Utilizzo delle trasformazioni in WordArt**

Utilizziamo la proprietà Transform (presente nell’intero blocco di testo) tramite questo codice:
```javascript
textFrame.getTextFrameFormat().setTransform(java.newByte(aspose.slides.TextShapeType.ArchUpPour));
```

Il risultato:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Sia Microsoft PowerPoint sia Aspose.Slides per Node.js via Java forniscono un certo numero di tipi di trasformazione predefiniti.

{{% /alert %}} 

**Utilizzo di PowerPoint**

Per accedere ai tipi di trasformazione predefiniti, vai su: **Formato** -> **EffettoTesto** -> **Trasforma**

**Utilizzo di Aspose.Slides**

Per selezionare un tipo di trasformazione, utilizza l’enum TextShapeType. 

### **Applicazione di effetti 3D a testi e forme**

Impostiamo un effetto 3D su una forma di testo usando questo codice di esempio:

```javascript
autoShape.getThreeDFormat().getBevelBottom().setBevelType(aspose.slides.BevelPresetType.Circle);
autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);
autoShape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
autoShape.getThreeDFormat().getBevelTop().setWidth(11);
autoShape.getThreeDFormat().getExtrusionColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
autoShape.getThreeDFormat().setExtrusionHeight(6);
autoShape.getThreeDFormat().getContourColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
autoShape.getThreeDFormat().setContourWidth(1.5);
autoShape.getThreeDFormat().setDepth(3);
autoShape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);
autoShape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);
autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
```

Il testo risultante e la sua forma:

![todo:image_alt_text](image-20200930114816-9.png)

Applichiamo un effetto 3D al testo con questo codice JavaScript:

```javascript
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(aspose.slides.BevelPresetType.Circle);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);
textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);
textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);
textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);
textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);
textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
```

Il risultato dell’operazione:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

L’applicazione di effetti 3D a testi o alle loro forme e le interazioni tra gli effetti si basano su alcune regole.

Considera una scena per un testo e la forma che contiene quel testo. L’effetto 3D contiene la rappresentazione dell’oggetto 3D e la scena su cui l’oggetto è stato posizionato.

- Quando la scena è impostata sia per la figura sia per il testo, la scena della figura ha priorità più alta—la scena del testo viene ignorata.
- Quando la figura non ha una propria scena ma ha una rappresentazione 3D, viene usata la scena del testo.
- Altrimenti—quando la forma originariamente non ha effetto 3D—la forma è piatta e l’effetto 3D viene applicato solo al testo.

Queste descrizioni sono collegate ai metodi ThreeDFormat.getLightRig() e ThreeDFormat.getCamera(). 

{{% /alert %}} 

## **Applicazione di effetti OuterShadow ai testi**

Aspose.Slides per Node.js via Java fornisce le classi [**OuterShadow**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/outershadow/) e [**InnerShadow**](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/innershadow/) che consentono di applicare effetti di ombra a un testo contenuto in [TextFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/textframe/). Segui questi passaggi:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation) .
2. Ottieni il riferimento di una diapositiva usando il suo indice.
3. Aggiungi un AutoShape di tipo Rettangolo alla diapositiva.
4. Accedi al TextFrame associato all'AutoShape.
5. Imposta il FillType dell'AutoShape su NoFill.
6. Istanzia la classe OuterShadow.
7. Imposta il BlurRadius dell'ombra.
8. Imposta la Direction dell'ombra.
9. Imposta la Distance dell'ombra.
10. Imposta il RectanglelAlign su TopLeft.
11. Imposta il PresetColor dell'ombra su Black.
12. Scrivi la presentazione in un file [PPTX](https://docs.fileformat.com/presentation/pptx/) .

Questo codice di esempio in Java—un'implementazione dei passaggi sopra—mostra come applicare l’effetto OuterShadow a un testo:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Ottieni il riferimento della diapositiva
    var sld = pres.getSlides().get_Item(0);
    // Aggiungi un AutoShape di tipo Rettangolo
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 150, 50);
    // Aggiungi TextFrame al Rettangolo
    ashp.addTextFrame("Aspose TextBox");
    // Disabilita il riempimento della forma nel caso si voglia ottenere l'ombra del testo
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Aggiungi ombra esterna e imposta tutti i parametri necessari
    ashp.getEffectFormat().enableOuterShadowEffect();
    var shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(aspose.slides.RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(aspose.slides.PresetColor.Black);
    // Scrivi la presentazione su disco
    pres.save("pres_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Applicazione dell’effetto Inner Shadow alle forme**

Segui questi passaggi:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation) .
2. Ottieni un riferimento della diapositiva.
3. Aggiungi un AutoShape di tipo Rettangolo.
4. Abilita InnerShadowEffect.
5. Imposta tutti i parametri necessari.
6. Imposta il ColorType come Scheme.
7. Imposta il colore Scheme.
8. Scrivi la presentazione in un file [PPTX](https://docs.fileformat.com/presentation/pptx/) file.

Questo codice di esempio (basato sui passaggi sopra) mostra come aggiungere un connettore tra due forme in JavaScript:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Ottieni il riferimento della diapositiva
    var slide = pres.getSlides().get_Item(0);
    // Aggiungi un AutoShape di tipo Rettangolo
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Aggiungi TextFrame al Rettangolo
    ashp.addTextFrame("Aspose TextBox");
    var port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    var pf = port.getPortionFormat();
    pf.setFontHeight(50);
    // Abilita InnerShadowEffect
    var ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();
    // Imposta tutti i parametri necessari
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB(189);
    // Imposta ColorType come Scheme
    ef.getInnerShadowEffect().getShadowColor().setColorType(aspose.slides.ColorType.Scheme);
    // Imposta colore Scheme
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(aspose.slides.SchemeColor.Accent1);
    // Salva la presentazione
    pres.save("WordArt_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Posso usare gli effetti WordArt con diversi caratteri o scritture (es. arabo, cinese)?**

Sì, Aspose.Slides supporta Unicode e funziona con tutti i principali caratteri e scritture. Gli effetti WordArt come ombra, riempimento e contorno possono essere applicati indipendentemente dalla lingua, sebbene la disponibilità dei caratteri e il rendering possano dipendere dai caratteri di sistema.

**Posso applicare gli effetti WordArt agli elementi del master della diapositiva?**

Sì, puoi applicare gli effetti WordArt alle forme nei master delle diapositive, inclusi i segnaposto del titolo, i piè di pagina o il testo di sfondo. Le modifiche apportate al layout master verranno riflesse su tutte le diapositive associate.

**Gli effetti WordArt influenzano la dimensione del file della presentazione?**

Leggermente. Gli effetti WordArt come ombre, bagliori e riempimenti a gradiente possono aumentare leggermente la dimensione del file a causa dei metadati di formattazione aggiunti, ma la differenza è generalmente trascurabile.

**Posso visualizzare in anteprima il risultato degli effetti WordArt senza salvare la presentazione?**

Sì, puoi renderizzare le diapositive contenenti WordArt in immagini (ad es. PNG, JPEG) usando il metodo `getImage` delle classi [Shape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/) o [Slide](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slide/). Questo ti consente di visualizzare in anteprima il risultato in memoria o sullo schermo prima di salvare o esportare l’intera presentazione.