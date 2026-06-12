---
title: Crea e applica effetti WordArt su Android
linktitle: WordArt
type: docs
weight: 110
url: /it/androidjava/wordart/
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
- Android
- Java
- Aspose.Slides
description: "Crea e personalizza gli effetti WordArt in Aspose.Slides per Android. Questa guida passo passo aiuta gli sviluppatori a migliorare le presentazioni con testo professionale in Java."
---
## **Panoramica**

Gli effetti WordArt consentono di aggiungere testo stilizzato e visivamente accattivante alle presentazioni PowerPoint. Con Aspose.Slides, gli sviluppatori possono creare, personalizzare e gestire WordArt in modo programmatico proprio come in Microsoft PowerPoint, senza bisogno di installare Office. Questo articolo fornisce una panoramica su come lavorare con WordArt, includendo come applicare trasformazioni di testo, stili di riempimento, contorni, ombre e altre opzioni di formattazione per rendere il contenuto della presentazione più espressivo e coinvolgente. WordArt permette di trattare il testo come un oggetto grafico. Consiste in effetti o modifiche speciali applicate al testo per renderlo più attraente o evidente.

## **Creare un modello WordArt semplice e applicarlo al testo**

**Utilizzando Aspose.Slides** 

Per prima cosa, creiamo un semplice testo con questo codice Java: 

``` java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();

    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    if (pres != null) pres.dispose();
}
```
Ora impostiamo l’altezza del carattere del testo a un valore più grande per rendere l’effetto più evidente con questo codice:

``` java 
FontData fontData = new FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```

**Utilizzando Microsoft PowerPoint**

Vai al menu degli effetti WordArt in Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Dal menu a destra è possibile scegliere un effetto WordArt predefinito. Dal menu a sinistra è possibile specificare le impostazioni per un nuovo WordArt. 

Questi sono alcuni dei parametri o opzioni disponibili:

![todo:image_alt_text](image-20200930114015-3.png)

**Utilizzando Aspose.Slides**

Qui applichiamo il colore pattern [SmallGrid](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/PatternStyle#SmallGrid) al testo e aggiungiamo un contorno nero di larghezza 1 usando questo codice:

``` java 
portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.ORANGE);
portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
```

Il testo risultante:

![todo:image_alt_text](image-20200930114108-4.png)

## **Applicare altri effetti WordArt**

**Utilizzando Microsoft PowerPoint**

Dall’interfaccia del programma è possibile applicare questi effetti a un testo, a un blocco di testo, a una forma o a un elemento simile:

![todo:image_alt_text](image-20200930114129-5.png)

Ad esempio, gli effetti Ombra, Riflesso e Bagliore possono essere applicati a un testo; gli effetti Formato 3D e Rotazione 3D possono essere applicati a un blocco di testo; la proprietà Bordi morbidi può essere applicata a un oggetto Forma (ha comunque effetto anche senza impostare la proprietà Formato 3D). 

### **Applicare effetti Ombra**

Qui impostiamo le proprietà relative solo a un testo. Applichiamo l’effetto ombra al testo con questo codice Java:

``` java
portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.BLACK);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(65);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4.73);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(2);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(30);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32f);
```

L’API Aspose.Slides supporta tre tipi di ombre: OuterShadow, InnerShadow e PresetShadow. 

Con PresetShadow è possibile applicare un’ombra a un testo (usando valori predefiniti). 

**Utilizzando Microsoft PowerPoint**

In PowerPoint è possibile utilizzare un solo tipo di ombra. Ecco un esempio:

![todo:image_alt_text](image-20200930114225-6.png)

**Utilizzando Aspose.Slides**

Aspose.Slides consente invece di applicare due tipi di ombra contemporaneamente: InnerShadow e PresetShadow.

**Note:**

- Quando OuterShadow e PresetShadow vengono usati insieme, viene applicato solo l’effetto OuterShadow. 
- Se OuterShadow e InnerShadow vengono usati simultaneamente, l’effetto risultante dipende dalla versione di PowerPoint. Ad esempio, in PowerPoint 2013 l’effetto viene raddoppiato, mentre in PowerPoint 2007 l’effetto OuterShadow viene applicato. 

### **Applicare effetti Riflesso al testo**

Aggiungiamo il riflesso al testo con questo esempio di codice Java:

``` java
portion.getPortionFormat().getEffectFormat().enableReflectionEffect();
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(0f);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(60f);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(60f);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(0.9f);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.BottomLeft);   
```

### **Applicare effetti Bagliore al testo**

Applichiamo l’effetto bagliore al testo per farlo risaltare con questo codice:

``` java
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```

Il risultato dell’operazione:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 
È possibile modificare i parametri per ombra, riflesso e bagliore. Le proprietà degli effetti vengono impostate separatamente per ciascuna porzione di testo. 
{{% /alert %}} 

### **Utilizzare le Trasformazioni in WordArt**

Usiamo la proprietà Transform (che agisce sull’intero blocco di testo) con questo codice:
``` java 
textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
```

Il risultato:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 
Sia Microsoft PowerPoint sia Aspose.Slides per Android tramite Java offrono un certo numero di tipi di trasformazione predefiniti. 
{{% /alert %}} 

**Utilizzando PowerPoint**

Per accedere ai tipi di trasformazione predefiniti, vai su: **Formato** -> **EffettoTesto** -> **Trasforma**

**Utilizzando Aspose.Slides**

Per selezionare un tipo di trasformazione, utilizza l’enumerazione TextShapeType. 

### **Applicare effetti 3D al testo e alle forme**

Impostiamo un effetto 3D su una forma di testo con questo esempio di codice:

``` java
autoShape.getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);

autoShape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
autoShape.getThreeDFormat().getBevelTop().setWidth(11);

autoShape.getThreeDFormat().getExtrusionColor().setColor(Color.ORANGE);
autoShape.getThreeDFormat().setExtrusionHeight(6);

autoShape.getThreeDFormat().getContourColor().setColor(Color.RED);
autoShape.getThreeDFormat().setContourWidth(1.5);

autoShape.getThreeDFormat().setDepth(3);

autoShape.getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

autoShape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);

autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
```

Il testo e la sua forma risultanti:

![todo:image_alt_text](image-20200930114816-9.png)

Applichiamo un effetto 3D al testo con questo codice Java:

``` java
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);

textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);

textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(Color.ORANGE);
textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);

textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(Color.RED);
textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);

textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);

textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);

textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
```

Il risultato dell’operazione:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 
L’applicazione di effetti 3D a testi o alle loro forme e le interazioni tra gli effetti si basano su regole specifiche. 

Considera una scena per il testo e la forma che contiene quel testo. L’effetto 3D comprende la rappresentazione dell’oggetto 3D e la scena su cui l’oggetto è posizionato. 

- Quando la scena è impostata sia per la figura sia per il testo, la scena della figura ha priorità più alta e quella del testo viene ignorata. 
- Quando la figura non ha una propria scena ma ha una rappresentazione 3D, viene usata la scena del testo. 
- Altrimenti, se la forma originariamente non ha alcun effetto 3D, la forma rimane piatta e l’effetto 3D viene applicato solo al testo. 

Queste descrizioni sono collegate ai metodi ThreeDFormat.getLightRig() e ThreeDFormat.getCamera(). 
{{% /alert %}} 

## **Applicare effetti Ombra Esterna al testo**
Aspose.Slides per Android tramite Java fornisce le classi [**IOuterShadow**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ioutershadow/) e [**IInnerShadow**](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iinnershadow/) che consentono di applicare effetti ombra a un testo contenuto in un [TextFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/textframe/). Segui questi passaggi:

1. Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation). 
2. Ottieni il riferimento di una diapositiva usando il suo indice. 
3. Aggiungi un’AutoShape di tipo Rettangolo alla diapositiva. 
4. Accedi al TextFrame associato all’AutoShape. 
5. Imposta FillType dell’AutoShape su NoFill. 
6. Istanzia la classe OuterShadow. 
7. Imposta BlurRadius dell’ombra. 
8. Imposta Direction dell’ombra. 
9. Imposta Distance dell’ombra. 
10. Imposta RectanglelAlign su TopLeft. 
11. Imposta PresetColor dell’ombra su Black. 
12. Salva la presentazione come file [PPTX](https://docs.fileformat.com/presentation/pptx/). 

Questo codice di esempio in Java—un’implementazione dei passaggi sopra—mostra come applicare l’effetto ombra esterna a un testo:

```java
Presentation pres = new Presentation();
try {
    // Ottieni il riferimento della diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Aggiungi un'AutoShape di tipo Rettangolo
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Aggiungi TextFrame al rettangolo
    ashp.addTextFrame("Aspose TextBox");

    // Disabilita il riempimento della forma nel caso vogliamo ottenere l'ombra del testo
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Aggiungi ombra esterna e imposta tutti i parametri necessari
    ashp.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(PresetColor.Black);

    //Scrivi la presentazione su disco
    pres.save("pres_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Applicare effetti Ombra Interna alle forme**
Segui questi passaggi:

1. Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation). 
2. Ottieni il riferimento della diapositiva. 
3. Aggiungi un’AutoShape di tipo Rettangolo. 
4. Abilita InnerShadowEffect. 
5. Imposta tutti i parametri necessari. 
6. Imposta ColorType su Scheme. 
7. Imposta lo Scheme Color. 
8. Salva la presentazione come file [PPTX](https://docs.fileformat.com/presentation/pptx/). 

Questo codice di esempio (basato sui passaggi sopra) mostra come aggiungere un connettore tra due forme in Java:

```java
Presentation pres = new Presentation();
try {
    // Ottieni il riferimento della diapositiva
    ISlide slide = pres.getSlides().get_Item(0);

    // Aggiungi un'AutoShape di tipo Rettangolo
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Aggiungi TextFrame al rettangolo
    ashp.addTextFrame("Aspose TextBox");
    IPortion port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormat pf = port.getPortionFormat();
    pf.setFontHeight(50);

    // Abilita InnerShadowEffect
    IEffectFormat ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();

    // Imposta tutti i parametri necessari
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0F);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB((byte)189);

    // Imposta ColorType come Scheme
    ef.getInnerShadowEffect().getShadowColor().setColorType(ColorType.Scheme);

    // Imposta Scheme Color
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(SchemeColor.Accent1);

    // Salva la presentazione
    pres.save("WordArt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Posso usare gli effetti WordArt con font o script diversi (ad esempio arabo, cinese)?**

Sì, Aspose.Slides supporta Unicode e funziona con tutti i principali font e script. Gli effetti WordArt come ombra, riempimento e contorno possono essere applicati indipendentemente dalla lingua, sebbene la disponibilità dei font e il rendering dipendano dai font di sistema.

**Posso applicare gli effetti WordArt agli elementi del master della diapositiva?**

Sì, è possibile applicare gli effetti WordArt alle forme nei master slide, inclusi i segnaposti del titolo, i piè di pagina o il testo di sfondo. Le modifiche apportate al layout master verranno propagate a tutte le diapositive associate.

**Gli effetti WordArt influiscono sulla dimensione del file della presentazione?**

L’effetto è minimo. Gli effetti WordArt come ombre, bagliori e riempimenti a gradiente possono aumentare leggermente la dimensione del file a causa dei metadati di formattazione aggiunti, ma la differenza è generalmente trascurabile.

**Posso visualizzare in anteprima il risultato degli effetti WordArt senza salvare la presentazione?**

Sì, è possibile renderizzare le diapositive contenenti WordArt in immagini (ad esempio PNG, JPEG) utilizzando il metodo `getImage` delle interfacce [IShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishape/) o [ISlide](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islide/). Questo consente di vedere l’anteprima in memoria o sullo schermo prima di salvare o esportare l’intera presentazione.