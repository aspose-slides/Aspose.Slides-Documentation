---
title: Crea e applica effetti WordArt in PHP
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
- effetto visualizzazione
- effetto bagliore
- trasformazione WordArt
- effetto 3D
- effetto ombra esterna
- effetto ombra interna
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Crea e personalizza gli effetti WordArt in Aspose.Slides per PHP tramite Java. Questa guida passo passo aiuta gli sviluppatori a migliorare le presentazioni con testo professionale."
---
## **Panoramica**

Gli effetti WordArt consentono di aggiungere testo stilizzato e visivamente attraente alle presentazioni PowerPoint. Con Aspose.Slides, gli sviluppatori possono creare, personalizzare e gestire programmaticamente WordArt proprio come in Microsoft PowerPoint, senza necessità di installare Office. Questo articolo fornisce una panoramica sul lavoro con WordArt, includendo come applicare trasformazioni del testo, stili di riempimento, contorni, ombre e altre opzioni di formattazione per rendere il contenuto della presentazione più espressivo e coinvolgente. WordArt permette di trattare il testo come un oggetto grafico. Consiste in effetti o modifiche speciali applicate al testo per renderlo più attraente o evidente.

## **Crea un modello WordArt semplice e applicalo al testo**

**Utilizzando Aspose.Slides** 

Prima, creiamo un testo semplice usando questo codice PHP:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $autoShape->getTextFrame();
    $portion = $textFrame->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->setText("Aspose.Slides");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
Ora, impostiamo l’altezza del carattere del testo a un valore più grande per rendere l’effetto più evidente tramite questo codice:

```php
  $fontData = new FontData("Arial Black");
  $portion->getPortionFormat()->setLatinFont($fontData);
  $portion->getPortionFormat()->setFontHeight(36);

```

**Utilizzando Microsoft PowerPoint**

Vai al menu degli effetti WordArt in Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Dal menu a destra, è possibile scegliere un effetto WordArt predefinito. Dal menu a sinistra, è possibile specificare le impostazioni per un nuovo WordArt. 

Questi sono alcuni dei parametri o opzioni disponibili:

![todo:image_alt_text](image-20200930114015-3.png)

**Utilizzando Aspose.Slides**

Qui, applichiamo il colore di pattern [SmallGrid](https://reference.aspose.com/slides/it/php-java/aspose.slides/patternstyle/#SmallGrid) al testo e aggiungiamo un bordo nero di larghezza 1 al testo usando questo codice:

```php
  $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Pattern);
  $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->ORANGE);
  $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->WHITE);
  $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle->SmallGrid);
  $portion->getPortionFormat()->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $portion->getPortionFormat()->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
```

Il testo risultante:

![todo:image_alt_text](image-20200930114108-4.png)

## **Applica altri effetti WordArt**

**Utilizzando Microsoft PowerPoint**

Dall’interfaccia del programma, è possibile applicare questi effetti a un testo, blocco di testo, forma o elemento simile:

![todo:image_alt_text](image-20200930114129-5.png)

Ad esempio, gli effetti Ombra, Riflesso e Bagliore possono essere applicati a un testo; gli effetti Formato 3D e Rotazione 3D possono essere applicati a un blocco di testo; la proprietà Bordi morbidi può essere applicata a un oggetto Forma (ha ancora effetto quando non è impostata la proprietà Formato 3D). 

### **Applica effetti Ombra**

Qui, intendiamo impostare le proprietà relative solo a un testo. Applichiamo l’effetto ombra a un testo usando questo codice :

```php
  $portion->getPortionFormat()->getEffectFormat()->enableOuterShadowEffect();
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->setColor(java("java.awt.Color")->BLACK);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setScaleHorizontal(100);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setScaleVertical(65);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setBlurRadius(4.73);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setDirection(230);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setDistance(2);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setSkewHorizontal(30);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->setSkewVertical(0);
  $portion->getPortionFormat()->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->getColorTransform()->add(ColorTransformOperation->SetAlpha, 0.32);
```

L’API Aspose.Slides supporta tre tipi di ombre: OuterShadow, InnerShadow e PresetShadow. 

Con PresetShadow, è possibile applicare un’ombra a un testo (usando valori predefiniti). 

**Utilizzando Microsoft PowerPoint**

In PowerPoint, è possibile utilizzare un solo tipo di ombra. Ecco un esempio:

![todo:image_alt_text](image-20200930114225-6.png)

**Utilizzando Aspose.Slides**

Aspose.Slides consente effettivamente di applicare due tipi di ombre contemporaneamente: InnerShadow e PresetShadow.

**Note:**

- Quando OuterShadow e PresetShadow vengono usati insieme, viene applicato solo l’effetto OuterShadow. 
- Se OuterShadow e InnerShadow vengono usati simultaneamente, l’effetto risultante o applicato dipende dalla versione di PowerPoint. Ad esempio, in PowerPoint 2013, l’effetto viene raddoppiato. Ma in PowerPoint 2007, viene applicato l’effetto OuterShadow. 

### **Applica effetti Riflesso al testo**

Aggiungiamo il riflesso al testo con questo esempio di codice :

```php
  $portion->getPortionFormat()->getEffectFormat()->enableReflectionEffect();
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setBlurRadius(0.5);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setDistance(4.72);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setStartPosAlpha(0.0);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setEndPosAlpha(60.0);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setDirection(90);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setScaleHorizontal(100);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setScaleVertical(-100);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setStartReflectionOpacity(60.0);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setEndReflectionOpacity(0.9);
  $portion->getPortionFormat()->getEffectFormat()->getReflectionEffect()->setRectangleAlign(RectangleAlignment->BottomLeft);
```

### **Applica effetti Bagliore al testo**

Applichiamo l’effetto bagliore al testo per farlo brillare o risaltare usando questo codice:

```php
  $portion->getPortionFormat()->getEffectFormat()->enableGlowEffect();
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->setR(255);
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->getColor()->getColorTransform()->add(ColorTransformOperation->SetAlpha, 0.54);
  $portion->getPortionFormat()->getEffectFormat()->getGlowEffect()->setRadius(7);
```

Il risultato dell'operazione:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

È possibile modificare i parametri per ombra, riflesso e bagliore. Le proprietà degli effetti vengono impostate separatamente per ogni porzione del testo. 

{{% /alert %}} 

### **Usa trasformazioni in WordArt**

Utilizziamo la proprietà Transform (presente nell’intero blocco di testo) con questo codice:
```php
  $textFrame->getTextFrameFormat()->setTransform(TextShapeType::ArchUpPour);

```

Il risultato:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Sia Microsoft PowerPoint sia Aspose.Slides per PHP via Java offrono un certo numero di tipi di trasformazione predefiniti.

{{% /alert %}} 

**Utilizzando PowerPoint**

Per accedere ai tipi di trasformazione predefiniti, vai su: **Formato** -> **Effetto testo** -> **Trasforma**

**Utilizzando Aspose.Slides**

Per selezionare un tipo di trasformazione, usa l’enumerazione TextShapeType. 

### **Applica effetti 3D a testo e forme**

Impostiamo un effetto 3D a una forma di testo usando questo codice di esempio:

```php
  $autoShape->getThreeDFormat()->getBevelBottom()->setBevelType(BevelPresetType::Circle);
  $autoShape->getThreeDFormat()->getBevelBottom()->setHeight(10.5);
  $autoShape->getThreeDFormat()->getBevelBottom()->setWidth(10.5);
  $autoShape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
  $autoShape->getThreeDFormat()->getBevelTop()->setHeight(12.5);
  $autoShape->getThreeDFormat()->getBevelTop()->setWidth(11);
  $autoShape->getThreeDFormat()->getExtrusionColor()->setColor(java("java.awt.Color")->ORANGE);
  $autoShape->getThreeDFormat()->setExtrusionHeight(6);
  $autoShape->getThreeDFormat()->getContourColor()->setColor(java("java.awt.Color")->RED);
  $autoShape->getThreeDFormat()->setContourWidth(1.5);
  $autoShape->getThreeDFormat()->setDepth(3);
  $autoShape->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);
  $autoShape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
  $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
  $autoShape->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);
  $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```

Il testo risultante e la sua forma:

![todo:image_alt_text](image-20200930114816-9.png)

Applichiamo un effetto 3D al testo con questo codice PHP:

```php
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setBevelType(BevelPresetType::Circle);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setHeight(3.5);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelBottom()->setWidth(3.5);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setHeight(4);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getBevelTop()->setWidth(4);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getExtrusionColor()->setColor(java("java.awt.Color")->ORANGE);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setExtrusionHeight(6);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getContourColor()->setColor(java("java.awt.Color")->RED);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setContourWidth(1.5);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setDepth(3);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);
  $textFrame->getTextFrameFormat()->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```

Il risultato dell'operazione:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

L’applicazione di effetti 3D a testi o alle loro forme e le interazioni tra gli effetti si basano su alcune regole. 

Considera una scena per un testo e la forma che contiene quel testo. L’effetto 3D contiene la rappresentazione dell’oggetto 3D e la scena su cui l’oggetto è stato posizionato. 

- Quando la scena è impostata sia per la figura che per il testo, la scena della figura ha priorità più alta—la scena del testo viene ignorata. 
- Quando la figura non ha una propria scena ma ha rappresentazione 3D, viene usata la scena del testo. 
- Altrimenti—quando la forma originariamente non ha effetto 3D—la forma è piatta e l’effetto 3D viene applicato solo al testo. 

Queste descrizioni sono collegate ai metodi ThreeDFormat.getLightRig() e ThreeDFormat.getCamera(). 

{{% /alert %}} 

## **Applica effetti Ombra Esterna al testo**
Aspose.Slides per PHP via Java fornisce le classi [OuterShadow](https://reference.aspose.com/slides/it/php-java/aspose.slides/outershadow/) e [InnerShadow](https://reference.aspose.com/slides/it/php-java/aspose.slides/innershadow/) che consentono di applicare effetti ombra a un testo contenuto in [TextFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/). Segui questi passaggi:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/).
2. Ottieni il riferimento di una diapositiva usando il suo indice.
3. Aggiungi un AutoShape di tipo Rettangolo alla diapositiva.
4. Accedi al TextFrame associato all'AutoShape.
5. Imposta il FillType dell'AutoShape su NoFill.
6. Istanzia la classe OuterShadow
7. Imposta il BlurRadius dell’ombra.
8. Imposta la Direction dell’ombra
9. Imposta la Distance dell’ombra.
10. Imposta il RectanglelAlign su TopLeft.
11. Imposta il PresetColor dell’ombra su Black.
12. Salva la presentazione come file [PPTX](https://docs.fileformat.com/presentation/pptx/) .

Questo codice di esempio —un'implementazione dei passaggi sopra—mostra come applicare l’effetto ombra esterna a un testo:

```php
  $pres = new Presentation();
  try {
    # Ottieni il riferimento della diapositiva
    $sld = $pres->getSlides()->get_Item(0);
    # Aggiungi un AutoShape di tipo Rettangolo
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);
    # Aggiungi TextFrame al Rettangolo
    $ashp->addTextFrame("Aspose TextBox");
    # Disabilita il riempimento della forma nel caso volessi ottenere l'ombra del testo
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Aggiungi ombra esterna e imposta tutti i parametri necessari
    $ashp->getEffectFormat()->enableOuterShadowEffect();
    $shadow = $ashp->getEffectFormat()->getOuterShadowEffect();
    $shadow->setBlurRadius(4.0);
    $shadow->setDirection(45);
    $shadow->setDistance(3);
    $shadow->setRectangleAlign(RectangleAlignment->TopLeft);
    $shadow->getShadowColor()->setPresetColor(PresetColor->Black);
    # Scrivi la presentazione su disco
    $pres->save("pres_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Applica effetti Ombra Interna alle forme**
Segui questi passaggi:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/).
2. Ottieni un riferimento della diapositiva.
3. Aggiungi un AutoShape di tipo Rettangolo.
4. Abilita InnerShadowEffect.
5. Imposta tutti i parametri necessari.
6. Imposta il ColorType su Scheme.
7. Imposta il colore Scheme.
8. Salva la presentazione come file [PPTX](https://docs.fileformat.com/presentation/pptx/) .

Questo codice di esempio (basato sui passaggi sopra) mostra come aggiungere un connettore tra due forme :

```php
  $pres = new Presentation();
  try {
    # Ottieni il riferimento della diapositiva
    $slide = $pres->getSlides()->get_Item(0);
    # Aggiungi un AutoShape di tipo Rettangolo
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 75, 400, 300);
    $ashp->getFillFormat()->setFillType(FillType::NoFill);
    # Aggiungi TextFrame al Rettangolo
    $ashp->addTextFrame("Aspose TextBox");
    $port = $ashp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $pf = $port->getPortionFormat();
    $pf->setFontHeight(50);
    # Abilita InnerShadowEffect
    $ef = $pf->getEffectFormat();
    $ef->enableInnerShadowEffect();
    # Imposta tutti i parametri necessari
    $ef->getInnerShadowEffect()->setBlurRadius(8.0);
    $ef->getInnerShadowEffect()->setDirection(90.0);
    $ef->getInnerShadowEffect()->setDistance(6.0);
    $ef->getInnerShadowEffect()->getShadowColor()->setB(189);
    # Imposta ColorType come Scheme
    $ef->getInnerShadowEffect()->getShadowColor()->setColorType(ColorType::Scheme);
    # Imposta il colore Scheme
    $ef->getInnerShadowEffect()->getShadowColor()->setSchemeColor(SchemeColor->Accent1);
    # Salva la presentazione
    $pres->save("WordArt_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Posso utilizzare gli effetti WordArt con caratteri o script diversi (es. arabo, cinese)?**

Sì, Aspose.Slides supporta Unicode e funziona con tutti i principali caratteri e script. Gli effetti WordArt come ombra, riempimento e contorno possono essere applicati indipendentemente dalla lingua, sebbene la disponibilità dei caratteri e il rendering possano dipendere dai caratteri di sistema.

**Posso applicare gli effetti WordArt agli elementi del master delle diapositive?**

Sì, è possibile applicare gli effetti WordArt alle forme nei master delle diapositive, inclusi i segnaposto del titolo, i piè di pagina o il testo di sfondo. Le modifiche apportate al layout master verranno riflesse su tutte le diapositive associate.

**Gli effetti WordArt influiscono sulla dimensione del file della presentazione?**

Un po'. Gli effetti WordArt come ombre, bagliori e riempimenti sfumati possono aumentare leggermente la dimensione del file a causa dei metadati di formattazione aggiunti, ma la differenza è di solito trascurabile.

**Posso visualizzare in anteprima il risultato degli effetti WordArt senza salvare la presentazione?**

Sì, è possibile renderizzare le diapositive contenenti WordArt in immagini (es. PNG, JPEG) usando il metodo `getImage` delle classi [Shape](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/) o [Slide](https://reference.aspose.com/slides/it/php-java/aspose.slides/slide/). Questo consente di visualizzare l’anteprima del risultato in memoria o sullo schermo prima di salvare o esportare l’intera presentazione.