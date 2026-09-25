---
title: Crea e Applica Effetti WordArt su Android
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
- effetto riflessione
- effetto bagliore
- trasformazione WordArt
- effetto 3D
- effetto ombra esterna
- effetto ombra interna
- Android
- Java
- Aspose.Slides
description: "Crea e personalizza gli effetti WordArt in Aspose.Slides per Android via Java. Questa guida passo passo aiuta gli sviluppatori a migliorare le presentazioni con testo professionale su Android."
---
## **Panoramica**

Gli effetti WordArt consentono di formattare il testo con riempimenti, contorni, ombre, riflessi, bagliore, trasformazioni e formattazione 3D. Questo articolo spiega come creare e personalizzare questi effetti nelle presentazioni PowerPoint utilizzando Aspose.Slides per Android via Java, senza installare Microsoft Office.

## **Crea un modello WordArt semplice e applicalo al testo**

Gli esempi seguenti creano uno stile WordArt semplice impostando il testo, il carattere, il riempimento a trama e il contorno.

Ogni esempio crea una nuova presentazione e aggiunge un rettangolo alla sua prima diapositiva; non è necessario alcun file di input. Il primo esempio imposta il testo su "Aspose.Slides". La posizione e le dimensioni della forma sono misurate in punti:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();

    IPortion portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    presentation.dispose();
}
```

Imposta il carattere su Arial Black a 36 punti per rendere la formattazione più evidente:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);
} finally {
    presentation.dispose();
}
```

Applica un modello [SmallGrid](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/patternstyle/#SmallGrid) con un primo piano arancione scuro e uno sfondo bianco, quindi aggiungi un contorno testuale nero con una larghezza di 1 punto:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
    int darkOrange = Color.rgb(255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(darkOrange);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

    portion.getPortionFormat().getLineFormat().setWidth(1);
    portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
} finally {
    presentation.dispose();
}
```

Il testo risultante:

![Il modello WordArt semplice](WordArt_template.png)

## **Applica altri effetti WordArt**

Gli esempi seguenti dimostrano come applicare ombre, riflessi, bagliori, trasformazioni e effetti 3D al testo.

### **Applica effetti di ombra esterna**

Un'ombra esterna aggiunge profondità posizionando un'ombra dietro il testo. È possibile personalizzare colore, direzione, distanza, raggio di sfocatura, scala e inclinazione.

Questo esempio chiama [enableOuterShadowEffect](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/effectformat/#enableOuterShadowEffect--) e imposta un'ombra nera con un raggio di sfocatura di 4 punti, una direzione di 230 gradi e una distanza di 30 punti. Valori di scala pari a 100 mantengono le dimensioni dell'ombra, mentre l'inclinazione orizzontale la ruota di 20 gradi. La trasformazione alfa imposta l'opacità al 32%:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.BLACK);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(30);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(20);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32f);
} finally {
    presentation.dispose();
}
```

Il testo risultante:

![L'effetto Ombra Esterna](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- Quando ombre esterne e preimpostate vengono usate insieme, viene applicata solo l'ombra esterna.
- Se ombre esterne e interne vengono usate simultaneamente, l'effetto risultante dipende dalla versione di PowerPoint. Ad esempio, in PowerPoint 2013 l'effetto è raddoppiato, mentre in PowerPoint 2007 viene applicata solo l'ombra esterna.
{{% /alert %}}

### **Applica effetti di riflessione**

Una riflessione crea una copia specchiata del testo. Regola posizione, scala, sfocatura e opacità per controllarne l'aspetto.

Questo esempio chiama [enableReflectionEffect](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/effectformat/#enableReflectionEffect--) e capovolge verticalmente la riflessione con una scala del -100%. Utilizza un raggio di sfocatura di 0,5 punti e una distanza di 4,72 punti. L'opacità diminuisce dal 60% allo 0,9% tra le posizioni 0% e 60% lungo la riflessione:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

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
    presentation.dispose();
}
```

Il testo risultante:

![L'effetto Riflesso](reflection_effect.png)

### **Applica effetti di bagliore**

Un bagliore aggiunge un contorno colorato soffice attorno al testo. Regola colore, opacità e raggio per controllarne l'effetto.

Questo esempio chiama [enableGlowEffect](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/effectformat/#enableGlowEffect--) e applica un bagliore rosso con opacità del 54% e raggio di 7 punti:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableGlowEffect();
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setColor(Color.RED);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
} finally {
    presentation.dispose();
}
```

Il testo risultante:

![L'effetto Bagliore](glow_effect.png)

### **Applica trasformazioni WordArt**

Le trasformazioni WordArt curvano, allungano o deformano un blocco di testo.

Imposta [setTransform](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/textframeformat/#setTransform-int-) su [ArchUpPour](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/textshapetype/#ArchUpPour) per curvare l'intero riquadro di testo verso l'alto:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");
    textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
} finally {
    presentation.dispose();
}
```

Il testo risultante:

![La trasformazione WordArt](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides per Android via Java fornisce un insieme di [tipi di trasformazione predefiniti](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/textshapetype/).
{{% /alert %}}

### **Applica effetti 3D a forme e testo**

È possibile applicare effetti 3D a una forma o al suo testo. Smussi, estrusione, illuminazione e impostazioni della telecamera controllano l'aspetto risultante.

L'esempio seguente utilizza [ThreeDFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/threedformat/) per aggiungere smussi circolari, estrusione arancione e un contorno rosso scuro al rettangolo. Dimensioni dello smusso, altezza di estrusione, larghezza del contorno e profondità sono misurate in punti. Un materiale plastico, illuminazione bilanciata ruotata di 40 gradi attorno all'asse Z e una telecamera prospettica ne definiscono l'aspetto:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    autoShape.getTextFrame().setText("Aspose.Slides");

    autoShape.getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
    autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);

    autoShape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
    autoShape.getThreeDFormat().getBevelTop().setWidth(11);

    int orange = Color.rgb(255, 165, 0);
    autoShape.getThreeDFormat().getExtrusionColor().setColor(orange);
    autoShape.getThreeDFormat().setExtrusionHeight(6);

    int darkRed = Color.rgb(139, 0, 0);
    autoShape.getThreeDFormat().getContourColor().setColor(darkRed);
    autoShape.getThreeDFormat().setContourWidth(1.5);

    autoShape.getThreeDFormat().setDepth(3);

    autoShape.getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

    autoShape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    presentation.dispose();
}
```

La forma risultante:

![La forma con effetto 3D](shape_3D_effect.png)

Questo esempio applica una formattazione 3D simile al testo tramite [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/textframeformat/#getThreeDFormat--). Smussi più piccoli modellano i bordi delle lettere, mentre estrusione e illuminazione conferiscono profondità al testo:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);

    int orange = Color.rgb(255, 165, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(orange);
    textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);

    int darkRed = Color.rgb(139, 0, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(darkRed);
    textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);

    textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);

    textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    presentation.dispose();
}
```

Il testo risultante:

![Il testo con effetto 3D](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
L'applicazione di effetti 3D al testo o alle loro forme—e l'interazione tra questi effetti—è governata da regole specifiche. Considera una scena che coinvolge sia il testo sia la forma che lo contiene. Un effetto 3D include la rappresentazione 3D dell'oggetto e la scena in cui è inserito.

- Se una scena è impostata sia per la forma sia per il testo, la scena della forma ha priorità e quella del testo viene ignorata.
- Se la forma non ha una propria scena ma possiede una rappresentazione 3D, viene utilizzata la scena del testo.
- Se la forma non ha alcun effetto 3D, viene trattata come piatta e l'effetto 3D viene applicato solo al testo.

Questi comportamenti riguardano i metodi [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/threedformat/#getLightRig--) e [ThreeDFormat.getCamera](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/threedformat/#getCamera--).
{{% /alert %}}

Per mantenere il testo piatto e leggibile pur conservando la formattazione 3D della forma, consulta [Keep Text Flat on a 3D Shape](/slides/it/androidjava/3d-presentation/) per un confronto tra le due impostazioni e un esempio Java completo.

## **FAQ**

**Posso usare gli effetti WordArt con font o script diversi (ad es. arabo, cinese)?**

Sì, Aspose.Slides per Android via Java supporta Unicode e funziona con tutti i principali font e script. Gli effetti WordArt come ombra, riempimento e contorno possono essere applicati indipendentemente dalla lingua, sebbene la disponibilità del font e il rendering possano dipendere dai font di sistema.

**Posso applicare gli effetti WordArt agli elementi del master della diapositiva?**

Sì, è possibile applicare gli effetti WordArt alle forme nei master slide, inclusi i segnaposto del titolo, i piè di pagina o il testo di sfondo. Le modifiche apportate al layout master verranno propagate a tutte le diapositive associate.

**Gli effetti WordArt influiscono sulla dimensione del file della presentazione?**

Leggermente. Effetti come ombre, bagliori e riempimenti sfumati possono aumentare marginalmente la dimensione del file a causa dei metadati di formattazione aggiunti, ma la differenza è di solito trascurabile.

**Posso visualizzare in anteprima il risultato degli effetti WordArt senza salvare la presentazione?**

Sì, è possibile renderizzare le diapositive contenenti WordArt in immagini (ad es. PNG, JPEG) usando [ISlide.getImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islide/#getImage--), oppure renderizzare forme individuali con [IShape.getImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishape/#getImage--). Questo consente di visualizzare l'anteprima in memoria o su schermo prima di salvare o esportare l'intera presentazione.