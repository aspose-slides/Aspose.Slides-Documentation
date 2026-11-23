---
title: Gestire le transizioni delle diapositive nelle presentazioni usando PHP
linktitle: Transizione diapositiva
type: docs
weight: 80
url: /it/php-java/slide-transition/
keywords:
- transizione diapositiva
- aggiungere transizione diapositiva
- applicare transizione diapositiva
- transizione diapositiva avanzata
- transizione Morph
- tipo di transizione
- effetto di transizione
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Applica transizioni alle diapositive, configura l'avanzamento automatico delle diapositive e personalizza Morph e altri effetti di transizione con Aspose.Slides per PHP via Java."
---
## **Panoramica**

Le transizioni delle diapositive controllano come le diapositive appaiono durante una presentazione. Con Aspose.Slides per PHP via Java, è possibile scegliere un effetto di transizione per ogni diapositiva, configurare l’avanzamento tramite clic del mouse o timer e regolare le opzioni specifiche di un effetto. Questo articolo utilizza esempi PHP per applicare transizioni, impostare durate esatte delle transizioni, gestire il tempo delle diapositive e creare una transizione Morph tra due diapositive. Gli esempi mostrano anche come salvare le impostazioni in un file PPTX.

## **Aggiungere una transizione alla diapositiva**

Per applicare una transizione, carica una presentazione con la classe [Presentazione](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) e accedi alle impostazioni di transizione della diapositiva tramite [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition). Usa [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) con un valore dell’enumerazione [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/), quindi salva la presentazione.

L’esempio seguente applica una transizione Circle alla prima diapositiva e una transizione Comb alla seconda. Usa un file `input.pptx` con almeno due diapositive.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 2) {
        $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
        $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);

        $presentation->save("slide-transitions.pptx", SaveFormat::Pptx);
    } else {
        echo "The input presentation must contain at least two slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Transizione Ruota**

Il metodo [setSpokes](https://reference.aspose.com/slides/php-java/aspose.slides/wheeltransition/#setSpokes) controlla quanti settori radiali rivelano la diapositiva di destinazione. Usa [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) per selezionare Wheel da [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/), quindi chiama [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue) per accedere alle impostazioni di [WheelTransition](https://reference.aspose.com/slides/php-java/aspose.slides/wheeltransition/).

L’esempio crea due coppie identiche di diapositive. Ogni coppia inizia con una diapositiva nera e termina con una diapositiva coperta da un rettangolo dorato. La diapositiva 2 utilizza una riga e la diapositiva 4 utilizza otto righe. Entrambe le transizioni usano la stessa velocità lenta, impostata con [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed), e una durata esplicita di 8 000 millisecondi, impostata con [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration).

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TransitionSpeed;
use aspose\slides\TransitionType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $slides = $presentation->getSlides();
    $width = java_values($presentation->getSlideSize()->getSize()->getWidth());
    $height = java_values($presentation->getSlideSize()->getSize()->getHeight());

    $blackSlide = $slides->get_Item(0);
    $blackSlide->getShapes()->clear();
    $background = $blackSlide->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $background->getFillFormat()->setFillType(FillType::Solid);
    $black = new Color(0, 0, 0);
    $background->getFillFormat()->getSolidFillColor()->setColor($black);

    $destinationSlide = $slides->addClone($blackSlide);
    $rectangle = $destinationSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 0, 0, $width, $height);
    $rectangle->getFillFormat()->setFillType(FillType::Solid);
    $gold = new Color(255, 215, 0);
    $rectangle->getFillFormat()->getSolidFillColor()->setColor($gold);
    $rectangle->getTextFrame()->setText("Wheel transition");

    $slides->addClone($blackSlide);
    $slides->addClone($destinationSlide);

    foreach ([1 => 1, 3 => 8] as $slideIndex => $spokes) {
        $transition = $slides->get_Item($slideIndex)->getSlideShowTransition();
        $transition->setType(TransitionType::Wheel);
        $transition->getValue()->setSpokes($spokes);
        $transition->setSpeed(TransitionSpeed::Slow);
        $transition->setDuration(8000);
    }

    $presentation->save("wheel-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Apri la presentazione salvata in PowerPoint e avvia la presentazione. Avanza dalla diapositiva 1 alla diapositiva 2 per vedere una singola rotazione in senso orario. Poi avanza dalla diapositiva 3 alla diapositiva 4 per vedere otto settori radiali rivelare simultaneamente lo stesso rettangolo.

## **Dissolvenza attraverso il nero con la transizione Reveal**

Imposta il tipo di transizione della diapositiva di destinazione su Reveal, quindi chiama [setThroughBlack](https://reference.aspose.com/slides/php-java/aspose.slides/revealtransition/#setThroughBlack) sulle impostazioni di [RevealTransition](https://reference.aspose.com/slides/php-java/aspose.slides/revealtransition/). L’esempio crea una diapositiva sorgente color turchese e una diapositiva di destinazione color corallo, quindi clona entrambe. Ogni coppia usa la stessa transizione Reveal di due secondi. Solo la seconda coppia sfuma attraverso il nero.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TransitionLeftRightDirectionType;
use aspose\slides\TransitionSpeed;
use aspose\slides\TransitionType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $source = $presentation->getSlides()->get_Item(0);
    $destination = $presentation->getSlides()->addClone($source);

    foreach ([
        [$source, new Color(0, 128, 128), "Source"],
        [$destination, new Color(255, 127, 80), "Destination"],
    ] as [$slide, $color, $label]) {
        $slide->getBackground()->setType(BackgroundType::OwnBackground);
        $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
        $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);

        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 160, 180, 400, 130);
        $shape->getTextFrame()->setText($label);
        $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setFontHeight(44);
    }

    $presentation->getSlides()->addClone($source);
    $clonedDestination = $presentation->getSlides()->addClone($destination);
    foreach ([[$destination, false], [$clonedDestination, true]] as [$slide, $throughBlack]) {
        $slide->getSlideShowTransition()->setType(TransitionType::Reveal);
        $slide->getSlideShowTransition()->setSpeed(TransitionSpeed::Slow);
        $slide->getSlideShowTransition()->setDuration(2000);
        $slide->getSlideShowTransition()->getValue()->setDirection(TransitionLeftRightDirectionType::Left);
        $slide->getSlideShowTransition()->getValue()->setThroughBlack($throughBlack);
    }

    $presentation->save("reveal-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Apri la presentazione salvata in PowerPoint e avvia la presentazione. Avanza dalla diapositiva 1 alla diapositiva 2 per vedere il turchese sfumare direttamente nel corallo. Poi avanza dalla diapositiva 3 alla diapositiva 4. Lo schermo si scurisce brevemente quasi al nero prima che la diapositiva corallo compaia. Entrambe le diapositive mantengono i loro colori di sfondo originali.

Le righe sottostanti mostrano fotogrammi di PowerPoint a intervalli di mezzo secondo. Confronta il fotogramma centrale in ogni riga per vedere l’effetto.

![Riproduzione PowerPoint con dissolvenza attraverso il nero disabilitata (in alto) e abilitata (in basso). Solo la riga inferiore passa attraverso quasi il nero.](reveal-through-black.png)

## **Aggiungere transizione avanzata alla diapositiva**

È possibile configurare per quanto tempo una diapositiva rimane sullo schermo e se un clic del mouse avanza la presentazione. I metodi seguenti controllano questo comportamento:

- [setAdvanceOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) consente allo spettatore di avanzare facendo clic con il mouse.
- [setAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) abilita l’avanzamento automatico.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) specifica il ritardo prima dell’avanzamento automatico, in millisecondi.

Abilita sia l’avanzamento con clic che quello temporizzato per permettere allo spettatore di procedere con un clic o attendere il timer. Per usare solo il timer, passa `false` a [setAdvanceOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). Il ritardo controlla quando la presentazione avanza; non imposta la durata dell’effetto visivo della transizione.

Questo esempio assegna effetti diversi alle prime tre diapositive e abilita l’avanzamento automatico dopo 3, 5 e 7 secondi, rispettivamente. I clic del mouse possono anche avanzare queste diapositive. Usa un file `input.pptx` con almeno tre diapositive.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 3) {
        $firstTransition = $presentation->getSlides()->get_Item(0)->getSlideShowTransition();
        $firstTransition->setType(TransitionType::Circle);
        $firstTransition->setAdvanceOnClick(true);
        $firstTransition->setAdvanceAfter(true);
        $firstTransition->setAdvanceAfterTime(3000);

        $secondTransition = $presentation->getSlides()->get_Item(1)->getSlideShowTransition();
        $secondTransition->setType(TransitionType::Comb);
        $secondTransition->setAdvanceOnClick(true);
        $secondTransition->setAdvanceAfter(true);
        $secondTransition->setAdvanceAfterTime(5000);

        $thirdTransition = $presentation->getSlides()->get_Item(2)->getSlideShowTransition();
        $thirdTransition->setType(TransitionType::Zoom);
        $thirdTransition->setAdvanceOnClick(true);
        $thirdTransition->setAdvanceAfter(true);
        $thirdTransition->setAdvanceAfterTime(7000);

        $presentation->save("advanced-transitions.pptx", SaveFormat::Pptx);
    } else {
        echo "The input presentation must contain at least three slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Per verificare se l’avanzamento temporizzato è abilitato, chiama [getAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getAdvanceAfter). Un ritardo memorizzato da solo non indica che il timer sia attivo.

L’esempio successivo apre il file salvato sopra, riporta ogni timer abilitato e disabilita l’avanzamento automatico per le diapositive con un ritardo superiore a due secondi. Abilita i clic del mouse per quelle diapositive e salva le impostazioni aggiornate.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("advanced-transitions.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $transition = $slide->getSlideShowTransition();

        if (java_values($transition->getAdvanceAfter())) {
            echo "Slide " . java_values($slide->getSlideNumber()) . ": advance after " . java_values($transition->getAdvanceAfterTime()) . " ms." . PHP_EOL;

            if (java_values($transition->getAdvanceAfterTime()) > 2000) {
                $transition->setAdvanceAfter(false);
                $transition->setAdvanceOnClick(true);
            }
        }
    }

    $presentation->save("adjusted-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Controllare con precisione il tempo della transizione**

Usa [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) per specificare la lunghezza esatta di un effetto di transizione in millisecondi. Il metodo [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) della diapositiva espone queste impostazioni tramite [SlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/):

| Metodo | Scopo |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) | Imposta la durata dell’effetto di transizione stesso, in millisecondi. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Imposta il ritardo prima che la diapositiva avanzi automaticamente, in millisecondi. Passa `true` a [setAdvanceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) per attivare questo timer. |
| [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) | Seleziona una categoria di velocità predefinita da [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/): Slow, Medium o Fast. Viene utilizzata quando non è specificata una durata esplicita. |

[setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) controlla solo l’effetto di transizione; non determina per quanto tempo la diapositiva rimane visibile. Configura separatamente il ritardo di avanzamento automatico. Quando non è impostata una durata esplicita, Aspose.Slides determina la durata dell’effetto dal tipo di transizione e dal valore di [getSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getSpeed).

<!-- visual-explanation:slide-transition:start -->
[![Barre separate identificano la durata della transizione di 750 ms e l’impostazione di avanzamento automatico di 5 000 ms.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*L’esempio condiviso assegna a ciascuna diapositiva una transizione Fade di 750 ms e abilita separatamente l’avanzamento automatico a 5 000 ms. La durata della transizione controlla l’effetto; l’avanzamento controlla quando lasciare la diapositiva. Queste barre sono impostazioni schematiche, non una timeline combinata misurata.* 
<!-- visual-explanation:slide-transition:end -->

### **Applicare la stessa durata a tutte le diapositive**

Per mantenere un ritmo costante, applica lo stesso effetto e la stessa durata esatta a tutte le diapositive. Questo esempio carica `input.pptx`, seleziona Fade da [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/), e assegna a ciascuna transizione una durata di 750 millisecondi. Abilita separatamente l’avanzamento automatico dopo 5 000 millisecondi e disabilita l’avanzamento tramite clic del mouse, quindi salva il risultato come PPTX.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $transition = $slide->getSlideShowTransition();
        $transition->setType(TransitionType::Fade);
        $transition->setDuration(750);

        // Configura l'avanzamento automatico in modo indipendente dalla durata dell'effetto.
        $transition->setAdvanceAfter(true);
        $transition->setAdvanceAfterTime(5000);
        $transition->setAdvanceOnClick(false);
    }

    $presentation->save("precise-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Impostare durate diverse per slide individuali**

Diapositive diverse possono utilizzare durate di effetto differenti. Ad esempio, usa una transizione breve per una diapositiva titolo e una più lunga per l’introduzione di una sezione. Questo esempio imposta 500 ms per la prima diapositiva e 1 200 ms per la seconda. Usa un file `input.pptx` con almeno due diapositive.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 2) {
        $firstTransition = $presentation->getSlides()->get_Item(0)->getSlideShowTransition();
        $firstTransition->setType(TransitionType::Fade);
        $firstTransition->setDuration(500);

        $secondTransition = $presentation->getSlides()->get_Item(1)->getSlideShowTransition();
        $secondTransition->setType(TransitionType::Push);
        $secondTransition->setDuration(1200);

        $presentation->save("individual-transition-durations.pptx", SaveFormat::Pptx);
    } else {
        echo "The input presentation must contain at least two slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **Coordinare le transizioni con l’output animato**

Quando si prepara un [GIF animato](/slides/it/php-java/convert-powerpoint-to-animated-gif/), una [presentazione HTML5](/slides/it/php-java/export-to-html5/) o un [video](/slides/it/php-java/convert-powerpoint-to-video/), imposta durate di transizione esatte prima dell’esportazione per corrispondere al ritmo desiderato. Ad esempio, usa una dissolvenza di 600 ms tra le scene e regola separatamente il ritardo di avanzamento di ciascuna diapositiva per consentire il tempo necessario alla narrazione o al contenuto.

Per GIF e video, coordina la frequenza dei fotogrammi di output con la durata dell’effetto: 600 ms corrispondono a 18 fotogrammi a 30 fps. In HTML5, abilita le transizioni animate nelle impostazioni di esportazione. Controlla gli effetti e le opzioni di temporizzazione supportati dal formato di esportazione scelto e visualizza in anteprima l’output per confermare la sincronizzazione.

### **Leggere la durata di una transizione esistente**

Chiama [getDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getDuration) prima di modificare la transizione per determinare se è memorizzato un valore esplicito. Un valore di `-1` indica che non è impostata alcuna durata esplicita; un valore non negativo specifica la durata memorizzata in millisecondi. Il valore non impostato non è la durata di riproduzione calcolata: Aspose.Slides usa il tipo di transizione e il valore di [getSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getSpeed) per determinarla. L’impostazione di un tipo di transizione può inizializzare una durata, quindi ispeziona prima le impostazioni originali.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $transition = $slide->getSlideShowTransition();
        $duration = java_values($transition->getDuration());

        if ($duration >= 0) {
            echo "Slide " . java_values($slide->getSlideNumber()) . ": stored transition duration is " . $duration . " ms." . PHP_EOL;
        } else {
            echo "Slide " . java_values($slide->getSlideNumber()) . ": no explicit duration; timing depends on transition type " . java_values($transition->getType()) . " and speed " . java_values($transition->getSpeed()) . "." . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Transizione Morph**

La transizione Morph anima le modifiche tra oggetti su diapositive consecutive. Per creare un semplice effetto Morph, clona una diapositiva, sposta o ridimensiona un oggetto nel clone e applica la transizione Morph alla seconda diapositiva. Questo fornisce agli oggetti corrispondenti una animazione tra lo stato originale e quello modificato.

L’esempio seguente crea una diapositiva con un rettangolo di testo, clona la diapositiva e cambia la posizione e la dimensione del rettangolo nel clone. Quindi seleziona Morph dall’enumerazione [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/) per la seconda diapositiva. Apri il file salvato in un visualizzatore di presentazioni che supporta Morph per vedere l’effetto durante la presentazione.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TransitionType;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $rectangle = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 100);
    $rectangle->getTextFrame()->setText("Morph transition");

    $secondSlide = $presentation->getSlides()->addClone($firstSlide);
    $movedRectangle = $secondSlide->getShapes()->get_Item(0);
    $movedRectangle->setX(java_values($movedRectangle->getX()) + 100);
    $movedRectangle->setY(java_values($movedRectangle->getY()) + 50);
    $movedRectangle->setWidth(java_values($movedRectangle->getWidth()) - 200);
    $movedRectangle->setHeight(java_values($movedRectangle->getHeight()) - 10);

    $secondSlide->getSlideShowTransition()->setType(TransitionType::Morph);

    $presentation->save("morph-transition.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Tipi di transizione Morph**

L’enumerazione [TransitionMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/) controlla come Morph corrisponde e anima il contenuto:

- [ByObject](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByObject) tratta ogni forma come un intero oggetto.
- [ByWord](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByWord) anima il testo abbinando le parole dove possibile.
- [ByChar](https://reference.aspose.com/slides/php-java/aspose.slides/transitionmorphtype/#ByChar) anima il testo abbinando i caratteri dove possibile.

Usa [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) per selezionare Morph prima di accedere a [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue). Il valore fornisce quindi un oggetto [MorphTransition](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/), il cui metodo [setMorphType](https://reference.aspose.com/slides/php-java/aspose.slides/morphtransition/#setMorphType) seleziona la modalità di corrispondenza.

Questo esempio apre la presentazione creata nella sezione precedente e configura la seconda diapositiva per usare l’animazione Morph basata su parole.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionMorphType;
use aspose\slides\TransitionType;

$presentation = new Presentation("morph-transition.pptx");
try {
    if (java_values($presentation->getSlides()->size()) >= 2) {
        $transition = $presentation->getSlides()->get_Item(1)->getSlideShowTransition();
        $transition->setType(TransitionType::Morph);
        $morphTransition = $transition->getValue();

        if (!java_is_null($morphTransition)) {
            $morphTransition->setMorphType(TransitionMorphType::ByWord);
            $presentation->save("morph-by-word.pptx", SaveFormat::Pptx);
        } else {
            echo "Morph transition options are unavailable." . PHP_EOL;
        }
    } else {
        echo "The input presentation must contain at least two slides." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Impostare gli effetti di transizione**

Alcune transizioni espongono opzioni aggiuntive, come la direzione o se l’effetto inizia da uno schermo nero. Le opzioni disponibili dipendono dalla transizione selezionata con [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType). Imposta prima il tipo, poi utilizza l’oggetto di transizione appropriato restituito da [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getValue).

L’esempio seguente applica una transizione Cut alla prima diapositiva di `input.pptx`. Chiama [setFromBlack](https://reference.aspose.com/slides/php-java/aspose.slides/optionalblacktransition/#setFromBlack) tramite [OptionalBlackTransition](https://reference.aspose.com/slides/php-java/aspose.slides/optionalblacktransition/) affinché la transizione inizi da uno schermo nero.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TransitionType;

$presentation = new Presentation("input.pptx");
try {
    $transition = $presentation->getSlides()->get_Item(0)->getSlideShowTransition();
    $transition->setType(TransitionType::Cut);
    $cutTransition = $transition->getValue();

    if (!java_is_null($cutTransition)) {
        $cutTransition->setFromBlack(true);
        $presentation->save("cut-from-black.pptx", SaveFormat::Pptx);
    } else {
        echo "Cut transition options are unavailable." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Posso controllare la velocità di riproduzione di una transizione diapositive?**

Sì. Preferisci [setDuration](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setDuration) quando ti serve una durata esatta dell’effetto in millisecondi. Usa [setSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSpeed) quando è sufficiente una categoria predefinita di [TransitionSpeed](https://reference.aspose.com/slides/php-java/aspose.slides/transitionspeed/): Slow, Medium o Fast, e non è impostata una durata esplicita. Queste impostazioni controllano l’effetto di transizione indipendentemente dal ritardo di avanzamento automatico.

**Posso allegare audio a una transizione e farlo ripetere in loop?**

Sì. Assegna audio incorporato con [setSound](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSound), passa StartSound dall’enumerazione [TransitionSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/transitionsoundmode/) a [setSoundMode](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSoundMode), e abilita [setSoundLoop](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setSoundLoop) con `true`. L’audio si ripete fino al prossimo evento sonoro nella presentazione.

**Qual è il modo più rapido per applicare la stessa transizione a tutte le diapositive?**

Scorri la collezione [getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides) della presentazione e chiama [setType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#setType) con lo stesso valore per la transizione di ogni diapositiva. Imposta eventuali opzioni di temporizzazione e di effetto nello stesso ciclo per mantenere il comportamento coerente tra le diapositive.

**Come posso verificare quale transizione è attualmente impostata su una diapositiva?**

Chiama [getType](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/#getType) sul risultato di [getSlideShowTransition](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) della diapositiva. Restituisce un valore dell’enumerazione [TransitionType](https://reference.aspose.com/slides/php-java/aspose.slides/transitiontype/); None indica che non è stato applicato alcun effetto di transizione.