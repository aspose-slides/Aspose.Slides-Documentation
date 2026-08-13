---
title: Crea e Applica Effetti WordArt in Java
linktitle: WordArt
type: docs
weight: 110
url: /it/java/wordart/
keywords:
- WordArt
- crea WordArt
- modello WordArt
- effetto WordArt
- effetto ombra
- effetto display
- effetto bagliore
- trasformazione WordArt
- effetto 3D
- effetto ombra esterna
- effetto ombra interna
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Crea e personalizza gli effetti WordArt in Aspose.Slides per Java. Questa guida passo-passo aiuta gli sviluppatori a migliorare le presentazioni con testo professionale in Java."
---
## **Panoramica**

Gli effetti WordArt ti consentono di aggiungere testo stilizzato e visivamente accattivante alle tue presentazioni PowerPoint. Con Aspose.Slides, gli sviluppatori possono creare, personalizzare e gestire WordArt programmaticamente proprio come in Microsoft PowerPoint—senza dover installare Office. Questo articolo fornisce una panoramica su come lavorare con WordArt, includendo come applicare trasformazioni del testo, stili di riempimento, contorni, ombre e altre opzioni di formattazione per rendere il contenuto della presentazione più espressivo e coinvolgente. WordArt consente di trattare il testo come un oggetto grafico. È costituito da effetti o modifiche speciali applicate al testo per renderlo più attraente o evidente.

## **Creazione di un semplice modello WordArt e applicazione a un testo**

**Utilizzando Aspose.Slides** 

Innanzitutto, creiamo un semplice testo con questo codice Java: 

``` java
import com.aspose.slides.*;

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
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    FontData fontData = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(fontData);
    portion.getPortionFormat().setFontHeight(36);
} finally {
    if (pres != null) pres.dispose();
}
```

**Utilizzando Microsoft PowerPoint**

Vai al menu degli effetti WordArt in Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Dal pannello a destra, puoi scegliere un effetto WordArt predefinito. Dal pannello a sinistra, puoi specificare le impostazioni per un nuovo WordArt. 

Questi sono alcuni dei parametri o opzioni disponibili:

![todo:image_alt_text](image-20200930114015-3.png)

**Utilizzando Aspose.Slides**

Qui applichiamo il pattern di colore [SmallGrid](https://reference.aspose.com/slides/it/java/com.aspose.slides/PatternStyle#SmallGrid) al testo e aggiungiamo un contorno nero di larghezza 1 usando questo codice:

``` java 
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.ORANGE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

    portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
} finally {
    if (pres != null) pres.dispose();
}
```

Il testo risultante:

![todo:image_alt_text](image-20200930114108-4.png)

## **Applicazione di altri effetti WordArt**

**Utilizzando Microsoft PowerPoint**

Dall’interfaccia del programma, puoi applicare questi effetti a un testo, blocco di testo, forma o elemento simile:

![todo:image_alt_text](image-20200930114129-5.png)

Ad esempio, gli effetti Ombra, Riflessione e Bagliore possono essere applicati a un testo; gli effetti Formato 3D e Rotazione 3D possono essere applicati a un blocco di testo; la proprietà Bordi Morbidi può essere applicata a un oggetto Forma (ha comunque effetto quando non è impostata alcuna proprietà Formato 3D). 

### **Applicazione di effetti Ombra**

Qui intendiamo impostare le proprietà relative solo a un testo. Applichiamo l’effetto ombra a un testo usando questo codice Java:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

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
} finally {
    if (pres != null) pres.dispose();
}
```

L’API Aspose.Slides supporta tre tipi di ombre: OuterShadow, InnerShadow e PresetShadow. 

Con PresetShadow, puoi applicare un’ombra a un testo (usando valori predefiniti). 

**Utilizzando Microsoft PowerPoint**

In PowerPoint puoi usare un solo tipo di ombra. Ecco un esempio:

![todo:image_alt_text](image-20200930114225-6.png)

**Utilizzando Aspose.Slides**

Aspose.Slides consente effettivamente di applicare due tipi di ombra contemporaneamente: InnerShadow e PresetShadow.

**Note:**

- Quando OuterShadow e PresetShadow sono usati insieme, viene applicato solo l’effetto OuterShadow. 
- Se OuterShadow e InnerShadow vengono usati simultaneamente, l’effetto risultante o applicato dipende dalla versione di PowerPoint. Ad esempio, in PowerPoint 2013 l’effetto viene raddoppiato. Ma in PowerPoint 2007 viene applicato l’effetto OuterShadow. 

### **Applicazione di Display ai Testi**

Aggiungiamo il display al testo con questo esempio di codice Java:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

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
} finally {
    if (pres != null) pres.dispose();
}
```

### **Applicazione dell’effetto Bagliore ai Testi**

Applichiamo l’effetto bagliore al testo per farlo risplendere o distinguere usando questo codice:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    portion.getPortionFormat().getEffectFormat().enableGlowEffect();
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
} finally {
    if (pres != null) pres.dispose();
}
```

Il risultato dell’operazione:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="info" %}} 
Puoi modificare i parametri per ombra, display e bagliore. Le proprietà degli effetti vengono impostate separatamente per ogni porzione del testo. 
{{% /alert %}} 

### **Utilizzo delle Trasformazioni in WordArt**

Usiamo la proprietà Transform (interna all’intero blocco di testo) con questo codice:
``` java 
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

    textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
} finally {
    if (pres != null) pres.dispose();
}
```

Il risultato:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="info" %}} 
Sia Microsoft PowerPoint sia Aspose.Slides per Java forniscono un certo numero di tipi di trasformazione predefiniti. 
{{% /alert %}} 

**Utilizzando PowerPoint**

Per accedere ai tipi di trasformazione predefiniti, vai su: **Formato** → **EffettoTesto** → **Trasforma**

**Utilizzando Aspose.Slides**

Per selezionare un tipo di trasformazione, utilizza l’enum TextShapeType. 

### **Applicazione di effetti 3D a Testi e Forme**

Impostiamo un effetto 3D a una forma di testo con questo esempio di codice:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    autoShape.getTextFrame().setText("Aspose.Slides");

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
} finally {
    if (pres != null) pres.dispose();
}
```

Il testo e la sua forma risultanti:

![todo:image_alt_text](image-20200930114816-9.png)

Applichiamo un effetto 3D al testo con questo codice Java:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

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
} finally {
    if (pres != null) pres.dispose();
}
```

Il risultato dell’operazione:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="info" %}} 
L’applicazione di effetti 3D a testi o alle loro forme e le interazioni tra gli effetti sono basate su regole specifiche. 

Considera una scena per un testo e la forma che contiene quel testo. L’effetto 3D comprende la rappresentazione dell’oggetto 3D e la scena su cui l’oggetto è posizionato. 

- Quando la scena è impostata sia per la figura sia per il testo, la scena della figura ha priorità più alta—la scena del testo viene ignorata. 
- Quando la figura non ha una propria scena ma ha una rappresentazione 3D, viene usata la scena del testo. 
- Altrimenti—quando la forma originariamente non ha effetto 3D—la forma è piatta e l’effetto 3D viene applicato solo al testo. 

Queste descrizioni sono collegate ai metodi ThreeDFormat.getLightRig() e ThreeDFormat.getCamera(). 
{{% /alert %}} 

## **Applicare effetti Ombra Esterna ai Testi**
Aspose.Slides per Java fornisce le classi [**IOuterShadow**](https://reference.aspose.com/slides/it/java/com.aspose.slides/ioutershadow/) e [**IInnerShadow**](https://reference.aspose.com/slides/it/java/com.aspose.slides/iinnershadow/) che consentono di applicare effetti ombra a un testo contenuto in un [TextFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/textframe/). Segui questi passaggi:

1. Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation).  
2. Ottieni il riferimento di una diapositiva usando il suo indice.  
3. Aggiungi un AutoShape di tipo Rettangolo alla diapositiva.  
4. Accedi al TextFrame associato all’AutoShape.  
5. Imposta FillType dell’AutoShape su NoFill.  
6. Istanzia la classe OuterShadow.  
7. Imposta BlurRadius dell’ombra.  
8. Imposta Direction dell’ombra.  
9. Imposta Distance dell’ombra.  
10. Imposta RectanglelAlign su TopLeft.  
11. Imposta PresetColor dell’ombra su Black.  
12. Salva la presentazione come file [PPTX](https://docs.fileformat.com/presentation/pptx/).  

Questo esempio di codice Java—un’implementazione dei passaggi sopra—mostra come applicare l’effetto ombra esterna a un testo:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Ottieni il riferimento della diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Aggiungi un AutoShape di tipo Rettangolo
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Aggiungi TextFrame al rettangolo
    ashp.addTextFrame("Aspose TextBox");

    // Disattiva il riempimento della forma nel caso vogliamo l'ombra del testo
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Aggiungi ombra esterna e imposta tutti i parametri necessari
    ashp.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(PresetColor.Black);

    //Salva la presentazione su disco
    pres.save("pres_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Applicare l’effetto Ombra Interna a Forme**
Segui questi passaggi:

1. Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation).  
2. Ottieni il riferimento della diapositiva.  
3. Aggiungi un AutoShape di tipo Rettangolo.  
4. Abilita InnerShadowEffect.  
5. Imposta tutti i parametri necessari.  
6. Imposta ColorType su Scheme.  
7. Imposta Scheme Color.  
8. Salva la presentazione come file [PPTX](https://docs.fileformat.com/presentation/pptx/).  

Questo esempio di codice (basato sui passaggi sopra) mostra come applicare l’effetto ombra interna al testo in una forma in Java:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Ottieni il riferimento della diapositiva
    ISlide slide = pres.getSlides().get_Item(0);

    // Aggiungi un AutoShape di tipo Rettangolo
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

    // Imposta il colore dello schema
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(SchemeColor.Accent1);

    // Salva la presentazione
    pres.save("WordArt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### Posso utilizzare gli effetti WordArt con caratteri o script diversi (ad es. arabo, cinese)?

Sì, Aspose.Slides supporta Unicode e funziona con tutti i principali caratteri e script. Gli effetti WordArt come ombra, riempimento e contorno possono essere applicati indipendentemente dalla lingua, anche se la disponibilità dei caratteri e il rendering possono dipendere dai font di sistema.

### Posso applicare gli effetti WordArt agli elementi del layout master?

Sì, puoi applicare gli effetti WordArt alle forme nei master slide, inclusi segnaposto titolo, piè di pagina o testo di sfondo. Le modifiche al layout master verranno riflesse su tutte le diapositive associate.

### Gli effetti WordArt influiscono sulla dimensione del file della presentazione?

Lieve aumento. Effetti come ombre, bagliori e riempimenti sfumati possono aumentare marginalmente la dimensione del file a causa dei metadati di formattazione aggiunti, ma la differenza è generalmente trascurabile.

### Posso vedere in anteprima il risultato degli effetti WordArt senza salvare la presentazione?

Sì, è possibile renderizzare le diapositive contenenti WordArt in immagini (ad esempio PNG, JPEG) usando il metodo `getImage` delle interfacce [IShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/) o [ISlide](https://reference.aspose.com/slides/it/java/com.aspose.slides/islide/). Questo consente di visualizzare l’anteprima in memoria o a schermo prima di salvare o esportare l’intera presentazione.