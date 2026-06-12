---
title: Crea e Applica Effetti WordArt in Java
linktitle: WordArt
type: docs
weight: 110
url: /it/java/wordart/
keywords:
- WordArt
- Crea WordArt
- Modello WordArt
- Effetto WordArt
- Effetto ombra
- Effetto display
- Effetto bagliore
- Trasformazione WordArt
- Effetto 3D
- Effetto ombra esterna
- Effetto ombra interna
- PowerPoint
- Presentazione
- Java
- Aspose.Slides
description: "Crea e personalizza gli effetti WordArt in Aspose.Slides per Java. Questa guida passo passo aiuta gli sviluppatori a migliorare le presentazioni con testo professionale in Java."
---
## **Panoramica**

Gli effetti WordArt consentono di aggiungere testo stilizzato e visivamente accattivante alle presentazioni PowerPoint. Con Aspose.Slides, gli sviluppatori possono creare, personalizzare e gestire programmaticamente WordArt proprio come in Microsoft PowerPoint—senza la necessità di avere Office installato. Questo articolo fornisce una panoramica sul lavoro con WordArt, inclusa l'applicazione di trasformazioni del testo, stili di riempimento, contorni, ombre e altre opzioni di formattazione per rendere il contenuto della presentazione più espressivo e coinvolgente. WordArt consente di trattare il testo come un oggetto grafico. È costituito da effetti o modifiche speciali applicate al testo per renderlo più attraente o evidente.

## **Creare un modello WordArt semplice e applicarlo a un testo**

**Using Aspose.Slides** 

Per prima cosa, creiamo un testo semplice usando questo codice Java: 

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
Ora impostiamo l’altezza del carattere del testo a un valore maggiore per rendere l’effetto più evidente con questo codice:

``` java 
FontData fontData = new FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```

**Utilizzare Microsoft PowerPoint**

Accedi al menu effetti WordArt in Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Dal menu a destra, puoi scegliere un effetto WordArt predefinito. Dal menu a sinistra, puoi specificare le impostazioni per un nuovo WordArt. 

Questi sono alcuni dei parametri o opzioni disponibili:

![todo:image_alt_text](image-20200930114015-3.png)

**Utilizzare Aspose.Slides**

Qui, applichiamo il colore di pattern [SmallGrid](https://reference.aspose.com/slides/it/java/com.aspose.slides/PatternStyle#SmallGrid) al testo e aggiungiamo un contorno di testo nero di larghezza 1 usando questo codice:

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

**Utilizzare Microsoft PowerPoint**

Dall’interfaccia del programma, è possibile applicare questi effetti a un testo, blocco di testo, forma o elemento simile:

![todo:image_alt_text](image-20200930114129-5.png)

Ad esempio, gli effetti Ombra, Riflesso e Bagliore possono essere applicati a un testo; gli effetti Formato 3D e Rotazione 3D possono essere applicati a un blocco di testo; la proprietà Bordi morbidi può essere applicata a un oggetto Forma (ha comunque effetto quando non è impostata alcuna proprietà Formato 3D). 

### **Applicare effetti Ombra**

Qui, intendiamo impostare le proprietà relative solo a un testo. Applichiamo l’effetto ombra a un testo usando questo codice Java:

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

Con PresetShadow, puoi applicare un’ombra a un testo (usando valori predefiniti). 

**Utilizzare Microsoft PowerPoint**

In PowerPoint, è possibile utilizzare un solo tipo di ombra. Ecco un esempio:

![todo:image_alt_text](image-20200930114225-6.png)

**Utilizzare Aspose.Slides**

Aspose.Slides consente effettivamente di applicare due tipi di ombre contemporaneamente: InnerShadow e PresetShadow.

**Note:**

- Quando OuterShadow e PresetShadow vengono usati insieme, viene applicato solo l’effetto OuterShadow. 
- Se OuterShadow e InnerShadow vengono usati simultaneamente, l’effetto risultante o applicato dipende dalla versione di PowerPoint. Per esempio, in PowerPoint 2013, l’effetto viene raddoppiato. In PowerPoint 2007, viene applicato l’effetto OuterShadow. 

### **Applicare Display ai Testi**

Aggiungiamo il display al testo con questo esempio di codice Java:

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

### **Applicare l’effetto Bagliore ai Testi**

Applichiamo l’effetto bagliore al testo per farlo brillare o risaltare usando questo codice:

``` java
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```

Il risultato dell’operazione:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

Puoi modificare i parametri per ombra, display e bagliore. Le proprietà degli effetti vengono impostate separatamente per ogni porzione del testo. 

{{% /alert %}} 

### **Utilizzare le trasformazioni in WordArt**

Usiamo la proprietà Transform (intrinseca a tutto il blocco di testo) con questo codice:
``` java 
textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
```

Il risultato:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Sia Microsoft PowerPoint che Aspose.Slides per Java offrono un certo numero di tipi di trasformazione predefiniti. 

{{% /alert %}} 

**Utilizzare PowerPoint**

Per accedere ai tipi di trasformazione predefiniti, vai su: **Formato** -> **Effetto testuale** -> **Trasforma**

**Utilizzare Aspose.Slides**

Per selezionare un tipo di trasformazione, usa l’enum TextShapeType. 

### **Applicare effetti 3D a Testi e Forme**

Impostiamo un effetto 3D su una forma di testo usando questo esempio di codice:

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

Il testo risultato e la sua forma:

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

L’applicazione di effetti 3D a testi o alle loro forme e le interazioni tra effetti si basano su regole specifiche.

Considera una scena per un testo e la forma che contiene quel testo. L’effetto 3D comprende la rappresentazione dell’oggetto 3D e la scena su cui l’oggetto è stato posizionato.

- Quando la scena è impostata sia per la figura sia per il testo, la scena della figura ha priorità più alta—la scena del testo è ignorata. 
- Quando la figura non ha una sua scena ma ha una rappresentazione 3D, viene usata la scena del testo. 
- Altrimenti—quando la forma originariamente non ha effetto 3D—la forma è piatta e l’effetto 3D viene applicato solo al testo. 

Queste descrizioni sono collegate ai metodi ThreeDFormat.getLightRig() e ThreeDFormat.getCamera(). 

{{% /alert %}} 

## **Applicare effetti Ombra Esterna ai Testi**
Aspose.Slides per Java fornisce le classi [**IOuterShadow**](https://reference.aspose.com/slides/it/java/com.aspose.slides/ioutershadow/) e [**IInnerShadow**](https://reference.aspose.com/slides/it/java/com.aspose.slides/iinnershadow/) che consentono di applicare effetti ombra a un testo contenuto in un [TextFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/textframe/). Segui questi passaggi:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation).  
2. Ottieni il riferimento di una diapositiva utilizzando il suo indice.  
3. Aggiungi un AutoShape di tipo Rettangolo alla diapositiva.  
4. Accedi al TextFrame associato all'AutoShape.  
5. Imposta il FillType dell'AutoShape a NoFill.  
6. Istanzia la classe OuterShadow  
7. Imposta il BlurRadius dell'ombra.  
8. Imposta la Direction dell'ombra  
9. Imposta il Distance dell'ombra.  
10. Imposta il RectanglelAlign a TopLeft.  
11. Imposta il PresetColor dell'ombra a Black.  
12. Scrivi la presentazione in un file [PPTX](https://docs.fileformat.com/presentation/pptx/) .  

Questo esempio di codice in Java — un'implementazione dei passaggi sopra — mostra come applicare l’effetto ombra esterna a un testo:

```java
Presentation pres = new Presentation();
try {
    // Ottieni il riferimento della diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Aggiungi un AutoShape di tipo Rettangolo
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Aggiungi TextFrame al Rettangolo
    ashp.addTextFrame("Aspose TextBox");

    // Disabilita il riempimento della forma nel caso volessimo ottenere l'ombra del testo
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Aggiungi l'ombra esterna e imposta tutti i parametri necessari
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

## **Applicare effetto Ombra Interna alle Forme**
Segui questi passaggi:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation).  
2. Ottieni un riferimento della diapositiva.  
3. Aggiungi un AutoShape di tipo Rettangolo.  
4. Abilita InnerShadowEffect.  
5. Imposta tutti i parametri necessari.  
6. Imposta il ColorType a Scheme.  
7. Imposta il colore Scheme.  
8. Scrivi la presentazione in un file [PPTX](https://docs.fileformat.com/presentation/pptx/) .  

Questo esempio di codice (basato sui passaggi sopra) mostra come aggiungere un connettore tra due forme in Java:

```java
Presentation pres = new Presentation();
try {
    // Ottieni il riferimento della diapositiva
    ISlide slide = pres.getSlides().get_Item(0);

    // Aggiungi un AutoShape di tipo Rettangolo
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Aggiungi TextFrame al Rettangolo
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

    // Imposta il colore Scheme
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(SchemeColor.Accent1);

    // Salva la presentazione
    pres.save("WordArt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Posso usare gli effetti WordArt con diversi caratteri o script (ad es. arabo, cinese)?**

Sì, Aspose.Slides supporta Unicode e funziona con tutti i principali caratteri e script. Gli effetti WordArt come ombra, riempimento e contorno possono essere applicati indipendentemente dalla lingua, sebbene la disponibilità dei font e il rendering possano dipendere dai font di sistema.

**Posso applicare gli effetti WordArt agli elementi del master delle diapositive?**

Sì, è possibile applicare gli effetti WordArt a forme nei master delle diapositive, inclusi segnaposto titolo, piè di pagina o testo di sfondo. Le modifiche apportate al layout master verranno riflesse in tutte le diapositive associate.

**Gli effetti WordArt influenzano le dimensioni del file della presentazione?**

Leggermente. Effetti come ombre, bagliori e riempimenti a gradiente possono aumentare marginalmente le dimensioni del file a causa dei metadati di formattazione aggiunti, ma la differenza è solitamente trascurabile.

**Posso visualizzare l’anteprima del risultato degli effetti WordArt senza salvare la presentazione?**

Sì, è possibile renderizzare le diapositive contenenti WordArt in immagini (ad esempio PNG, JPEG) usando il metodo `getImage` dalle interfacce [IShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/) o [ISlide](https://reference.aspose.com/slides/it/java/com.aspose.slides/islide/). Questo permette di vedere l’anteprima in memoria o a schermo prima di salvare o esportare l’intera presentazione.