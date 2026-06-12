---
title: Gestisci i temi di presentazione in PHP
linktitle: Tema di presentazione
type: docs
weight: 10
url: /it/php-java/presentation-theme/
keywords:
- tema PowerPoint
- tema della presentazione
- tema diapositiva
- imposta tema
- cambia tema
- gestisci tema
- colore tema
- tavolozza aggiuntiva
- carattere tema
- stile tema
- effetto tema
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Gestisci i temi principali delle presentazioni in Aspose.Slides per PHP via Java per creare, personalizzare e convertire file PowerPoint con un'identità di marca coerente."
---
## **Introduzione**

Un tema di presentazione definisce le proprietà degli elementi di design. Quando si seleziona un tema di presentazione, si sta essenzialmente scegliendo un insieme specifico di elementi visivi e le loro proprietà.

In PowerPoint, un tema comprende colori, [font](/slides/it/php-java/powerpoint-fonts/), [stili di sfondo](/slides/it/php-java/presentation-background/) ed effetti.

![theme-constituents](theme-constituents.png)

## **Modifica colore del tema**

Un tema di PowerPoint utilizza un insieme specifico di colori per diversi elementi di una diapositiva. Se i colori non ti piacciono, li cambi applicando nuovi colori al tema. Per consentirti di selezionare un nuovo colore del tema, Aspose.Slides fornisce valori nella enumerazione [SchemeColor](https://reference.aspose.com/slides/it/php-java/aspose.slides/SchemeColor).

Questo codice PHP mostra come modificare il colore di accento per un tema:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Puoi determinare il valore effettivo del colore risultante in questo modo:

```php
  $fillEffective = $shape->getFillFormat()->getEffective();
  $effectiveColor = $fillEffective->getSolidFillColor();
  echo(sprintf("Color [A=%d, R=%d, G=%d, B=%d]", $effectiveColor->getAlpha(), $effectiveColor->getRed(), $effectiveColor->getGreen(), $effectiveColor->getBlue()));

```

Per dimostrare ulteriormente l'operazione di cambio colore, creiamo un altro elemento e gli assegniamo il colore di accento (dall'operazione iniziale). Quindi cambiamo il colore nel tema:

```php
  $otherShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 120, 100, 100);
  $otherShape->getFillFormat()->setFillType(FillType::Solid);
  $otherShape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
  $pres->getMasterTheme()->getColorScheme()->getAccent4()->setColor(java("java.awt.Color")->RED);
```

Il nuovo colore viene applicato automaticamente a entrambi gli elementi.

### **Imposta colore del tema da una tavolozza aggiuntiva**

Quando applichi trasformazioni di luminanza al colore principale del tema(1), si formano i colori dalla tavolozza aggiuntiva(2). È quindi possibile impostare e recuperare quei colori del tema.

![additional-palette-colors](additional-palette-colors.png)

**1** - Colori principali del tema

**2** - Colori dalla tavolozza aggiuntiva.

Questo codice PHP dimostra un'operazione in cui i colori della tavolozza aggiuntiva vengono ottenuti dal colore principale del tema e poi usati nelle forme:

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # Accent 4
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 50, 50);
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    # Accent 4, più chiaro 80%
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 70, 50, 50);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.2);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.8);
    # Accent 4, più chiaro 60%
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 130, 50, 50);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.6);
    # Accent 4, più chiaro 40%
    $shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 190, 50, 50);
    $shape4->getFillFormat()->setFillType(FillType::Solid);
    $shape4->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.6);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.4);
    # Accent 4, più scuro 25%
    $shape5 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 250, 50, 50);
    $shape5->getFillFormat()->setFillType(FillType::Solid);
    $shape5->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape5->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.75);
    # Accent 4, più scuro 50%
    $shape6 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 50, 50);
    $shape6->getFillFormat()->setFillType(FillType::Solid);
    $shape6->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape6->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.5);
    $presentation->save($path . "example_accent4.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

### **Mappa `SchemeColor` a colori `ColorScheme`**

Quando lavori con [SchemeColor](https://reference.aspose.com/slides/it/php-java/aspose.slides/schemecolor/), potresti notare che contiene i seguenti valori di colore del tema:

`Background1`, `Background2`, `Text1` e `Text2`.

Tuttavia, `Presentation::getMasterTheme()::getColorScheme()` restituisce [ColorScheme](https://reference.aspose.com/slides/it/php-java/aspose.slides/colorscheme/), che espone i colori corrispondenti come:

`Dark1`, `Dark2`, `Light1` e `Light2`.

Questa differenza riguarda solo la denominazione. Questi valori si riferiscono agli stessi slot di colore del tema e la mappatura è fissa:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Non esiste una conversione dinamica tra `Text`/`Background` e `Dark`/`Light`. Sono semplicemente nomi alternativi per gli stessi colori del tema.

Questa differenza di denominazione proviene dalla terminologia di Microsoft Office. Le versioni più vecchie di Office utilizzavano `Dark 1`, `Light 1`, `Dark 2` e `Light 2`, mentre le versioni UI più recenti mostrano gli stessi slot come `Text 1`, `Background 1`, `Text 2` e `Background 2`.

## **Modifica carattere del tema**

Per consentirti di selezionare i caratteri per i temi e altri scopi, Aspose.Slides utilizza questi identificatori speciali (simili a quelli usati in PowerPoint):

* **+mn-lt** - Carattere corpo Latin (Minor Latin Font)
* **+mj-lt** - Carattere intestazione Latin (Major Latin Font)
* **+mn-ea** - Carattere corpo East Asian (Minor East Asian Font)
* **+mj-ea** - Carattere intestazione East Asian (Major East Asian Font)

Questo codice PHP mostra come assegnare il carattere Latin a un elemento del tema:

```php
  $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
  $paragraph = new Paragraph();
  $portion = new Portion("Theme text format");
  $paragraph->getPortions()->add($portion);
  $shape->getTextFrame()->getParagraphs()->add($paragraph);
  $portion->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));
```

Questo codice PHP mostra come modificare il carattere del tema della presentazione:

```php
  $pres->getMasterTheme()->getFontScheme()->getMinor()->setLatinFont(new FontData("Arial"));

```

Il carattere in tutte le caselle di testo sarà aggiornato.

{{% alert color="primary" title="TIP" %}} 

Potresti voler vedere i [font di PowerPoint](/slides/it/php-java/powerpoint-fonts/).

{{% /alert %}}

## **Modifica stile di sfondo del tema**

Per impostazione predefinita, l'app PowerPoint fornisce 12 sfondi predefiniti ma solo 3 di questi 12 sfondi vengono salvati in una presentazione tipica.

![todo:image_alt_text](presentation-design_8.png)

Ad esempio, dopo aver salvato una presentazione nell'app PowerPoint, puoi eseguire questo codice PHP per scoprire il numero di sfondi predefiniti nella presentazione:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $numberOfBackgroundFills = $pres->getMasterTheme()->getFormatScheme()->getBackgroundFillStyles()->size();
    echo("Number of background fill styles for theme is " . $numberOfBackgroundFills);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" %}} 

Utilizzando la proprietà [BackgroundFillStyles](https://reference.aspose.com/slides/it/php-java/aspose.slides/FormatScheme#getBackgroundFillStyles--) della classe [FormatScheme](https://reference.aspose.com/slides/it/php-java/aspose.slides/FormatScheme), è possibile aggiungere o accedere allo stile di sfondo in un tema PowerPoint.

{{% /alert %}} 

Questo codice PHP mostra come impostare lo sfondo per una presentazione:

```php
  $pres->getMasters()->get_Item(0)->getBackground()->setStyleIndex(2);
```

**Guida agli indici**: 0 è usato per nessun riempimento. L'indice parte da 1.

{{% alert color="primary" title="TIP" %}} 

Potresti voler vedere lo [sfondo di PowerPoint](/slides/it/php-java/presentation-background/).

{{% /alert %}}

## **Modifica effetto del tema**

Un tema di PowerPoint contiene di solito 3 valori per ogni array di stile. Quegli array sono combinati in questi 3 effetti: sottile, moderato e intenso. Ad esempio, questo è il risultato quando gli effetti vengono applicati a una forma specifica:

![todo:image_alt_text](presentation-design_10.png)

Utilizzando 3 proprietà ([FillStyles](https://reference.aspose.com/slides/it/php-java/aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/it/php-java/aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/it/php-java/aspose.slides/FormatScheme#getEffectStyles--)) della classe [FormatScheme](https://reference.aspose.com/slides/it/php-java/aspose.slides/FormatScheme) è possibile modificare gli elementi in un tema (in modo ancora più flessibile rispetto alle opzioni di PowerPoint).

Questo codice PHP mostra come modificare un effetto del tema alterando parti degli elementi:

```php
  $pres = new Presentation("Subtle_Moderate_Intense.pptx");
  try {
    $pres->getMasterTheme()->getFormatScheme()->getLineStyles()->get_Item(0)->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $pres->getMasterTheme()->getFormatScheme()->getFillStyles()->get_Item(2)->setFillType(FillType::Solid);
    $pres->getMasterTheme()->getFormatScheme()->getFillStyles()->get_Item(2)->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $pres->getMasterTheme()->getFormatScheme()->getEffectStyles()->get_Item(2)->getEffectFormat()->getOuterShadowEffect()->setDistance(10.0);
    $pres->save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Le modifiche risultanti in colore di riempimento, tipo di riempimento, effetto ombra, ecc.:

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

**Posso applicare un tema a una singola diapositiva senza modificare il master?**

Sì. Aspose.Slides supporta sovrascritture del tema a livello di diapositiva, quindi puoi applicare un tema locale solo a quella diapositiva mantenendo intatto il tema master (tramite lo [SlideThemeManager](https://reference.aspose.com/slides/it/php-java/aspose.slides/slidethememanager/)).

**Qual è il modo più sicuro per portare un tema da una presentazione all'altra?**

[Clona le diapositive](/slides/it/php-java/clone-slides/) insieme al loro master nella presentazione di destinazione. Questo preserva il master originale, i layout e il tema associato così l'aspetto rimane coerente.

**Come posso vedere i valori "effettivi" dopo tutta l'ereditarietà e le sovrascritture?**

Usa le visualizzazioni ["effettive"](/slides/it/php-java/shape-effective-properties/) dell'API per tema/colore/carattere/effetto. Queste restituiscono le proprietà risolte, finali, dopo l'applicazione del master più eventuali sovrascritture locali.