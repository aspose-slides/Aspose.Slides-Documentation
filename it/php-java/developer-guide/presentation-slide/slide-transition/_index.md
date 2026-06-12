---
title: Gestire le transizioni delle diapositive nelle presentazioni usando PHP
linktitle: Transizione diapositiva
type: docs
weight: 80
url: /it/php-java/slide-transition/
keywords:
- transizione diapositiva
- aggiungi transizione diapositiva
- applica transizione diapositiva
- transizione diapositiva avanzata
- transizione Morph
- tipo di transizione
- effetto di transizione
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Scopri come personalizzare le transizioni delle diapositive in Aspose.Slides per PHP via Java, con guide passo passo per presentazioni PowerPoint e OpenDocument."
---
## **Panoramica**

Questo articolo spiega come gestire le transizioni delle diapositive nelle presentazioni usando Aspose.Slides. Mostra come applicare i tipi di transizione alle diapositive, configurare il comportamento della transizione come avanzare al clic o dopo un tempo specificato, verificare e disabilitare l’avanzamento automatico, utilizzare la transizione Morph e i suoi tipi, e impostare le opzioni degli effetti di transizione. Gli esempi dimostrano come caricare o creare una presentazione, modificare le impostazioni di transizione per le diapositive selezionate e salvare il risultato come file PPTX. L’articolo risponde anche a domande comuni sulla velocità della transizione, i suoni di transizione, l’applicazione della stessa transizione a più diapositive e il controllo della transizione attualmente impostata su una diapositiva.

## **Aggiungi transizione diapositiva**
Per creare un effetto di transizione diapositiva semplice, segui i passaggi seguenti:

1. Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation).
2. Applica un tipo di transizione diapositiva dalla diapositiva scegliendo uno degli effetti di transizione offerti da Aspose.Slides per PHP via Java tramite l’enumerazione TransitionType.
3. Scrivi il file della presentazione modificata.

```php
  # Istanzia la classe Presentation per caricare il file della presentazione sorgente
  $presentation = new Presentation("AccessSlides.pptx");
  try {
    # Applica la transizione di tipo cerchio alla diapositiva 1
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
    # Applica la transizione di tipo pettine alla diapositiva 2
    $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);
    # Scrivi la presentazione su disco
    $presentation->save("SampleTransition_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Aggiungi transizione diapositiva avanzata**
Nella sezione precedente abbiamo applicato un effetto di transizione semplice sulla diapositiva. Ora, per rendere quell’effetto semplice ancora migliore e controllato, segui i passaggi seguenti:

1. Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation).
2. Applica un tipo di transizione diapositiva dalla diapositiva scegliendo uno degli effetti di transizione offerti da Aspose.Slides per PHP via Java.
3. Puoi anche impostare la transizione per avanzare al clic, dopo un intervallo di tempo specifico o entrambi.
4. Se la transizione della diapositiva è abilitata per avanzare al clic, la transizione avanzerà solo quando qualcuno farà clic con il mouse. Inoltre, se la proprietà Advance After Time è impostata, la transizione avanzerà automaticamente dopo il tempo di avanzamento specificato.
5. Scrivi la presentazione modificata come file di presentazione.

```php
  # Istanzia la classe Presentation che rappresenta un file di presentazione
  $pres = new Presentation("BetterSlideTransitions.pptx");
  try {
    # Applica la transizione di tipo cerchio alla diapositiva 1
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
    # Imposta il tempo di transizione a 3 secondi
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setAdvanceAfterTime(3000);
    # Applica la transizione di tipo pettine alla diapositiva 2
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);
    # Imposta il tempo di transizione a 5 secondi
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setAdvanceAfterTime(5000);
    # Applica la transizione di tipo zoom alla diapositiva 3
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setType(TransitionType::Zoom);
    # Imposta il tempo di transizione a 7 secondi
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setAdvanceAfterTime(7000);
    # Scrivi la presentazione su disco
    $pres->save("SampleTransition_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Transizione Morph**
{{% alert color="primary" %}} 

Aspose.Slides per PHP via Java ora supporta la [Morph Transition](https://reference.aspose.com/slides/it/php-java/aspose.slides/morphtransition/). Rappresenta la nuova transizione morph introdotta in PowerPoint 2019.

{{% /alert %}} 

La transizione Morph ti consente di animare uno spostamento fluido da una diapositiva alla successiva. Questo articolo descrive il concetto e come utilizzare la transizione Morph. Per utilizzare efficacemente la transizione Morph, è necessario disporre di due diapositive con almeno un oggetto in comune. Il modo più semplice è duplicare la diapositiva e poi spostare l’oggetto nella seconda diapositiva in una posizione diversa.

Il frammento di codice seguente mostra come aggiungere una copia della diapositiva con del testo alla presentazione e impostare una transizione di [morph type](https://reference.aspose.com/slides/it/php-java/aspose.slides/TransitionType) sulla seconda diapositiva.

```php
  $presentation = new Presentation();
  try {
    $autoshape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 100);
    $autoshape->getTextFrame()->setText("Morph Transition in PowerPoint Presentations");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0));
    $shape = $presentation->getSlides()->get_Item(1)->getShapes()->get_Item(0);
    $shape->setX($shape->getX() + 100);
    $shape->setY($shape->getY() + 50);
    $shape->setWidth($shape->getWidth() - 200);
    $shape->setHeight($shape->getHeight() - 10);
    $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Morph);
    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Tipi di transizione Morph**
È stata aggiunta la nuova enumerazione [TransitionMorphType](https://reference.aspose.com/slides/it/php-java/aspose.slides/TransitionMorphType). Rappresenta diversi tipi di transizione diapositiva Morph.

L’enumerazione TransitionMorphType ha tre membri:

- ByObject: la transizione Morph verrà eseguita considerando le forme come oggetti indivisibili.
- ByWord: la transizione Morph verrà eseguita trasferendo il testo per parole, dove possibile.
- ByChar: la transizione Morph verrà eseguita trasferendo il testo per caratteri, dove possibile.

Il frammento di codice seguente mostra come impostare una transizione morph su una diapositiva e modificare il tipo morph:

```php
  $presentation = new Presentation("presentation.pptx");
  try {
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Morph);
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->getValue()->setMorphType(TransitionMorphType::ByWord);
    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Impostare effetti di transizione**
Aspose.Slides per PHP via Java supporta l’impostazione degli effetti di transizione, ad esempio da nero, da sinistra, da destra, ecc. Per impostare l’effetto di transizione, segui i passaggi seguenti:

- Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/Presentation).
- Ottieni il riferimento della diapositiva.
- Imposta l’effetto di transizione.
- Scrivi la presentazione come un file [PPTX](https://docs.fileformat.com/presentation/pptx/).

Nell’esempio mostrato di seguito, abbiamo impostato gli effetti di transizione.

```php
  # Crea un'istanza della classe Presentation
  $presentation = new Presentation("AccessSlides.pptx");
  try {
    # Imposta l'effetto
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Cut);
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->getValue()->setFromBlack(true);
    # Scrivi la presentazione su disco
    $presentation->save("SetTransitionEffects_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **FAQ**

**Posso controllare la velocità di riproduzione di una transizione diapositiva?**

Sì. Imposta la [speed](https://reference.aspose.com/slides/it/php-java/aspose.slides/slideshowtransition/setspeed/) della transizione usando l’impostazione [TransitionSpeed](https://reference.aspose.com/slides/it/php-java/aspose.slides/transitionspeed/) (ad esempio slow/medium/fast).

**Posso allegare audio a una transizione e farlo ripetere in loop?**

Sì. Puoi incorporare un suono per la transizione e controllarne il comportamento tramite impostazioni come modalità suono e looping (ad esempio [setSound](https://reference.aspose.com/slides/it/php-java/aspose.slides/slideshowtransition/setsound/), [setSoundMode](https://reference.aspose.com/slides/it/php-java/aspose.slides/slideshowtransition/setsoundmode/), [setSoundLoop](https://reference.aspose.com/slides/it/php-java/aspose.slides/slideshowtransition/setsoundloop/), più metadati come [setSoundIsBuiltIn](https://reference.aspose.com/slides/it/php-java/aspose.slides/slideshowtransition/setsoundisbuiltin/) e [setSoundName](https://reference.aspose.com/slides/it/php-java/aspose.slides/slideshowtransition/setsoundname/)).

**Qual è il modo più veloce per applicare la stessa transizione a tutte le diapositive?**

Configura il tipo di transizione desiderato nelle impostazioni di transizione di ciascuna diapositiva; le transizioni sono memorizzate per diapositiva, quindi applicare lo stesso tipo a tutte le diapositive produce un risultato coerente.

**Come posso verificare quale transizione è attualmente impostata su una diapositiva?**

Esamina le [transition settings](https://reference.aspose.com/slides/it/php-java/aspose.slides/baseslide/#getSlideShowTransition) della diapositiva e leggi il suo [transition type](https://reference.aspose.com/slides/it/php-java/aspose.slides/slideshowtransition/settype/); quel valore ti indica esattamente quale effetto è applicato.