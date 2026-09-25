---
title: Crea e Applica Effetti WordArt in PHP
linktitle: WordArt
type: docs
weight: 110
url: /it/php-java/wordart/
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
- PHP
- Aspose.Slides
description: "Crea e personalizza gli effetti WordArt in Aspose.Slides per PHP via Java. Questa guida passo passo aiuta gli sviluppatori a migliorare le presentazioni con testo professionale in PHP."
---
## **Panoramica**

Le effetti WordArt ti consentono di formattare il testo con riempimenti, contorni, ombre, riflessi, bagliore, trasformazioni e formattazione 3D. Questo articolo spiega come creare e personalizzare questi effetti nelle presentazioni PowerPoint utilizzando Aspose.Slides per PHP via Java, senza l'installazione di Microsoft Office.

## **Crea un semplice modello WordArt e applicalo al testo**

Gli esempi seguenti creano uno stile WordArt semplice impostando il testo, il carattere, il riempimento a trama e il contorno.

Ogni esempio crea una nuova presentazione e aggiunge un rettangolo alla sua prima diapositiva; non è richiesto alcun file di input. Il primo esempio imposta il testo su "Aspose.Slides". La posizione e le dimensioni della forma sono misurate in punti:

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);
    $textFrame = $autoShape->getTextFrame();

    $portion = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
} finally {
    $presentation->dispose();
}
```

Imposta il carattere su Arial Black a 36 punti per rendere la formattazione più evidente:

```php
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);
} finally {
    $presentation->dispose();
}
```

Applica un modello [SmallGrid](https://reference.aspose.com/slides/it/php-java/aspose.slides/patternstyle/#SmallGrid) con un primo piano arancione scuro e uno sfondo bianco, poi aggiungi un contorno nero al testo con una larghezza di 1 punto:

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\PatternStyle;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);

    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Pattern);
    $darkOrange = new Java("java.awt.Color", 255, 140, 0);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor($darkOrange);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->WHITE);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::SmallGrid);

    $portion->getPortionFormat()->getLineFormat()->setWidth(1);
    $portion->getPortionFormat()->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
} finally {
    $presentation->dispose();
}
```

Il testo risultante:

![Il semplice modello WordArt](WordArt_template.png)

## **Applica altri effetti WordArt**

Gli esempi seguenti dimostrano come applicare ombre, riflessi, bagliore, trasformazioni e effetti 3D al testo.

### **Applica effetti di ombra esterna**

Un'ombra esterna aggiunge profondità posizionando un'ombra dietro il testo. Puoi personalizzare il suo colore, direzione, distanza, raggio di sfocatura, scala e inclinazione.

Questo esempio chiama [enableOuterShadowEffect](https://reference.aspose.com/slides/it/php-java/aspose.slides/effectformat/#enableOuterShadowEffect--) e imposta un'ombra nera con un raggio di sfocatura di 4 punti, una direzione di 230 gradi e una distanza di 30 punti. I valori di scala 100 mantengono le dimensioni dell'ombra, mentre l'inclinazione orizzontale la ruota di 20 gradi. La trasformazione alfa imposta l'opacità al 32%:

```php
use aspose\slides\ColorTransformOperation;
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);

    $portion->getPortionFormat()->getEffectFormat()->enableOuterShadowEffect();
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setScaleHorizontal(100);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setScaleVertical(100);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setBlurRadius(4);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setDirection(230);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setDistance(30);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setSkewHorizontal(20);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setSkewVertical(0);
    $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->getColorTransform()->add(ColorTransformOperation::SetAlpha, 0.32);
} finally {
    $presentation->dispose();
}
```

Il testo risultante:

![L'effetto Ombra Esterna](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- Quando vengono usate insieme ombre esterne e preset, viene applicata solo l'ombra esterna.
- Se ombre esterne e interne vengono utilizzate simultaneamente, l'effetto risultante dipende dalla versione di PowerPoint. Per esempio, in PowerPoint 2013 l'effetto è raddoppiato, mentre in PowerPoint 2007 viene applicata solo l'ombra esterna.
{{% /alert %}}

### **Applica effetti di riflessione**

Una riflessione crea una copia specchiata del testo. Regola la sua posizione, scala, sfocatura e opacità per controllarne l'aspetto.

Questo esempio chiama [enableReflectionEffect](https://reference.aspose.com/slides/it/php-java/aspose.slides/effectformat/#enableReflectionEffect--) e capovolge verticalmente la riflessione con una scala del -100%. Usa un raggio di sfocatura di 0,5 punti e una distanza di 4,72 punti. L'opacità diminuisce dal 60% allo 0,9% tra le posizioni 0% e 60% lungo la riflessione:

```php
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\RectangleAlignment;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);

    $portion->getPortionFormat()->getEffectFormat()->enableReflectionEffect();
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setBlurRadius(0.5);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setDistance(4.72);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setStartPosAlpha(0);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setEndPosAlpha(60);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setDirection(90);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setScaleHorizontal(100);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setScaleVertical(-100);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setStartReflectionOpacity(60);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setEndReflectionOpacity(0.9);
    $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setRectangleAlign(RectangleAlignment::BottomLeft);
} finally {
    $presentation->dispose();
}
```

Il testo risultante:

![L'effetto Riflesso](reflection_effect.png)

### **Applica effetti di bagliore**

Un bagliore aggiunge un delicato contorno colorato attorno al testo. Regola il suo colore, opacità e raggio per controllare l'effetto.

Questo esempio chiama [enableGlowEffect](https://reference.aspose.com/slides/it/php-java/aspose.slides/effectformat/#enableGlowEffect--) e applica un bagliore rosso con opacità del 54% e un raggio di 7 punti:

```php
use aspose\slides\ColorTransformOperation;
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $portion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
    $font = new FontData("Arial Black");
    $portion->getPortionFormat()->setLatinFont($font);
    $portion->getPortionFormat()->setFontHeight(36);

    $portion->getPortionFormat()->getEffectFormat()->enableGlowEffect();
    $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->setColor(java("java.awt.Color")->RED);
    $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->getColorTransform()->add(ColorTransformOperation::SetAlpha, 0.54);
    $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->setRadius(7);
} finally {
    $presentation->dispose();
}
```

Il testo risultante:

![L'effetto Bagliore](glow_effect.png)

### **Applica trasformazioni WordArt**

Le trasformazioni WordArt piegano, stirano o deformano un blocco di testo.

Imposta [setTransform](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframeformat/#setTransform-int-) su [ArchUpPour](https://reference.aspose.com/slides/it/php-java/aspose.slides/textshapetype/#ArchUpPour) per curvare il riquadro di testo verso l'alto:

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\TextShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->setText("Aspose.Slides");
    $textFrame->getTextFrameFormat()->setTransform(TextShapeType::ArchUpPour);
} finally {
    $presentation->dispose();
}
```

Il testo risultante:

![La trasformazione WordArt](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides for PHP via Java fornisce un insieme di [tipi di trasformazione](https://reference.aspose.com/slides/it/php-java/aspose.slides/textshapetype/) predefiniti.
{{% /alert %}}

### **Applica effetti 3D a forme e testo**

Puoi applicare effetti 3D a una forma o al suo testo. Smussature, estrusione, illuminazione e impostazioni della fotocamera controllano l'aspetto risultante.

L'esempio seguente utilizza [ThreeDFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/threedformat/) per aggiungere smussature circolari, estrusione arancione e un contorno rosso scuro al rettangolo. Le dimensioni della smussatura, l'altezza dell'estrusione, la larghezza del contorno e la profondità sono misurate in punti. Un materiale plastico, illuminazione bilanciata ruotata di 40 gradi attorno all'asse Z, e una fotocamera prospettica ne definiscono l'aspetto:

```php
use aspose\slides\BevelPresetType;
use aspose\slides\CameraPresetType;
use aspose\slides\LightRigPresetType;
use aspose\slides\LightingDirection;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);
    $autoShape->getTextFrame()->setText("Aspose.Slides");

    $autoShape->getThreeDFormat()->getBevelBottom()->setBevelType(BevelPresetType::Circle);
    $autoShape->getThreeDFormat()->getBevelBottom()->setHeight(10.5);
    $autoShape->getThreeDFormat()->getBevelBottom()->setWidth(10.5);

    $autoShape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $autoShape->getThreeDFormat()->getBevelTop()->setHeight(12.5);
    $autoShape->getThreeDFormat()->getBevelTop()->setWidth(11);

    $orange = new Java("java.awt.Color", 255, 165, 0);
    $autoShape->getThreeDFormat()->getExtrusionColor()->setColor($orange);
    $autoShape->getThreeDFormat()->setExtrusionHeight(6);

    $darkRed = new Java("java.awt.Color", 139, 0, 0);
    $autoShape->getThreeDFormat()->getContourColor()->setColor($darkRed);
    $autoShape->getThreeDFormat()->setContourWidth(1.5);

    $autoShape->getThreeDFormat()->setDepth(3);

    $autoShape->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);

    $autoShape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
    $autoShape->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);

    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);
} finally {
    $presentation->dispose();
}
```

La forma risultante:

![L'effetto 3D della forma](shape_3D_effect.png)

Questo esempio applica una formattazione 3D simile al testo tramite [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframeformat/#getThreeDFormat--). Smussature più piccole modellano i bordi delle lettere, mentre l'estrusione e l'illuminazione conferiscono profondità al testo:

```php
use aspose\slides\BevelPresetType;
use aspose\slides\CameraPresetType;
use aspose\slides\LightRigPresetType;
use aspose\slides\LightingDirection;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 200);
    $textFrame = $autoShape->getTextFrame();
    $textFrame->setText("Aspose.Slides");

    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setBevelType(BevelPresetType::Circle);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setHeight(3.5);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setWidth(3.5);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setHeight(4);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setWidth(4);

    $orange = new Java("java.awt.Color", 255, 165, 0);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getExtrusionColor()->setColor($orange);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->setExtrusionHeight(6);

    $darkRed = new Java("java.awt.Color", 139, 0, 0);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getContourColor()->setColor($darkRed);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->setContourWidth(1.5);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->setDepth(3);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
    $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);

    $textFrame->getTextFrameFormat()->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);
} finally {
    $presentation->dispose();
}
```

Il testo risultante:

![L'effetto 3D del testo](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
L'applicazione di effetti 3D al testo o alle loro forme — e l'interazione tra questi effetti — è regolata da regole specifiche. Considera una scena che coinvolge sia il testo sia la forma che lo contiene. Un effetto 3D include la rappresentazione 3D dell'oggetto e la scena in cui è collocato.

- Se una scena è impostata sia per la forma sia per il testo, la scena della forma ha la precedenza e quella del testo viene ignorata.
- Se la forma non ha una propria scena ma possiede una rappresentazione 3D, viene utilizzata la scena del testo.
- Se la forma non ha alcun effetto 3D, viene trattata come piatta e l'effetto 3D viene applicato solo al testo.

Questi comportamenti si riferiscono ai metodi [ThreeDFormat::getLightRig](https://reference.aspose.com/slides/it/php-java/aspose.slides/threedformat/#getLightRig--) e [ThreeDFormat::getCamera](https://reference.aspose.com/slides/it/php-java/aspose.slides/threedformat/#getCamera--).
{{% /alert %}}

Per ulteriori esempi di formattazione 3D, vedi [Crea effetti 3D nelle presentazioni usando PHP](/slides/it/php-java/3d-presentation/).

## **Domande frequenti**

**Posso utilizzare gli effetti WordArt con diversi caratteri o script (ad esempio, arabo, cinese)?**

Sì, Aspose.Slides per PHP via Java supporta Unicode e funziona con tutti i principali caratteri e script. Gli effetti WordArt come ombra, riempimento e contorno possono essere applicati indipendentemente dalla lingua, anche se la disponibilità dei caratteri e il rendering possono dipendere dai caratteri di sistema.

**Posso applicare gli effetti WordArt agli elementi del master della diapositiva?**

Sì, è possibile applicare gli effetti WordArt alle forme nelle diapositive master, inclusi segnaposti del titolo, piè di pagina o testo di sfondo. Le modifiche apportate al layout master verranno riflesse su tutte le diapositive associate.

**Gli effetti WordArt influiscono sulla dimensione del file della presentazione?**

Lieve. Gli effetti WordArt come ombre, bagliori e riempimenti sfumati possono aumentare leggermente la dimensione del file a causa dei metadati di formattazione aggiunti, ma la differenza è solitamente trascurabile.

**Posso visualizzare in anteprima il risultato degli effetti WordArt senza salvare la presentazione?**

Sì, puoi renderizzare le diapositive contenenti WordArt in immagini (ad esempio PNG, JPEG) usando [Slide::getImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/slide/#getImage--), oppure renderizzare singole forme usando [Shape::getImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/#getImage--). Questo ti consente di visualizzare in anteprima il risultato in memoria o sullo schermo prima di salvare o esportare l'intera presentazione.