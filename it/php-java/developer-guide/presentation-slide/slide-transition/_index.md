---
title: Gestisci le transizioni delle diapositive nelle presentazioni usando PHP
linktitle: Transizione diapositiva
type: docs
weight: 80
url: /it/php-java/slide-transition/
keywords:
- transizione diapositiva
- aggiungere transizione diapositiva
- applicare transizione diapositiva
- transizione diapositiva avanzata
- transizione morph
- tipo di transizione
- effetto di transizione
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Applica le transizioni delle diapositive, configura l'avanzamento automatico delle diapositive e personalizza le transizioni Morph e altri effetti di transizione con Aspose.Slides per PHP tramite Java."
---
## **Panoramica**

Le transizioni delle diapositive controllano come le diapositive appaiono durante una presentazione. Con Aspose.Slides per PHP tramite Java, è possibile scegliere un effetto di transizione per ogni diapositiva, configurare l'avanzamento tramite clic del mouse o timer e regolare le opzioni specifiche di un effetto. Questo articolo utilizza esempi PHP per applicare le transizioni, impostare durate esatte delle transizioni, gestire il timing delle diapositive e creare una transizione Morph tra due diapositive. Gli esempi mostrano anche come salvare le impostazioni in un file PPTX.

## **Aggiungere transizione alla diapositiva**

Per applicare una transizione, carica una presentazione con la classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/) e accedi alle impostazioni di transizione della diapositiva tramite [getSlideShowTransition](https://reference.aspose.com/slides/it/php-java/aspose.slides/baseslide/#getSlideShowTransition). Usa [setType](https://reference.aspose.com/slides/it/php-java/aspose.slides/slideshowtransition/#setType) con un valore dell'enumerazione [TransitionType](https://reference.aspose.com/slides/it/php-java/aspose.slides/transitiontype/), quindi salva la presentazione.

L'esempio seguente applica una transizione Circle alla prima diapositiva e una transizione Comb alla seconda. Usa un file `input.pptx` con almeno due diapositive.

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

## **Aggiungere transizione avanzata alla diapositiva**

Puoi configurare per quanto tempo una diapositiva rimane sullo schermo e se un clic del mouse avanza la presentazione. I seguenti metodi controllano questo comportamento:

- [setAdvanceOnClick](https://reference.aspose.com/slides/it/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) consente allo spettatore di avanzare facendo clic con il mouse.
- [setAdvanceAfter](https://reference.aspose.com/slides/it/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) abilita l'avanzamento automatico.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/it/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) specifica il ritardo prima dell'avanzamento automatico, in millisecondi.

Abilita sia il clic che l'avanzamento temporizzato per consentire allo spettatore di procedere con un clic o di attendere il timer. Per usare solo il timer, passa `false` a [setAdvanceOnClick](https://reference.aspose.com/slides/it/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). Il ritardo controlla quando la presentazione avanza; non imposta la durata dell'effetto di transizione visiva.

Questo esempio assegna effetti diversi alle prime tre diapositive e abilita l'avanzamento automatico dopo 3, 5 e 7 secondi, rispettivamente. I clic del mouse possono anche avanzare queste diapositive. Usa un file `input.pptx` con almeno tre diapositive.

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

Per verificare se l'avanzamento temporizzato è abilitato, chiama [getAdvanceAfter](https://reference.aspose.com/slides/it/php-java/aspose.slides/slideshowtransition/#getAdvanceAfter). Un ritardo memorizzato da solo non indica che il timer sia attivo.

L'esempio successivo apre il file salvato sopra, riporta ogni timer abilitato e disabilita l'avanzamento automatico per le diapositive con un ritardo superiore a due secondi. Abilita i clic del mouse per quelle diapositive e salva le impostazioni aggiornate.

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

Usa [setDuration](https://reference.aspose.com/slides/it/php-java/aspose.slides/slideshowtransition/#setDuration) per specificare la lunghezza esatta di un effetto di transizione in millisecondi. Il metodo [getSlideShowTransition](https://reference.aspose.com/slides/it/php-java/aspose.slides/baseslide/#getSlideShowTransition) della diapositiva espone queste impostazioni tramite [SlideShowTransition](https://reference.aspose.com/slides/it/php-java/aspose.slides/slideshowtransition/):

| Metodo | Scopo |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/it/php-java/aspose.slides/slideshowtransition/#setDuration) | Imposta la durata dell'effetto di transizione in millisecondi. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/it/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Imposta il ritardo prima che la diapositiva avanzi automaticamente, in millisecondi. Passare `true` a [setAdvanceAfter](https://reference.aspose.com/slides/it/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) per attivare questo timer. |
| [setSpeed](https://reference.aspose.com/slides/it/php-java/aspose.slides/slideshowtransition/#setSpeed) | Seleziona una categoria di velocità predefinita dall'enumerazione [TransitionSpeed](https://reference.aspose.com/slides/it/php-java/aspose.slides/transitionspeed/): Lenta, Media o Veloce. Viene usata quando non è specificata una durata esatta. |

[setDuration] controlla solo l'effetto di transizione; non determina per quanto tempo la diapositiva rimane visibile. Configura separatamente il ritardo di avanzamento automatico. Quando non è impostata una durata esplicita, Aspose.Slides determina la durata dell'effetto dal tipo di transizione e dal valore di [getSpeed](https://reference.aspose.com/slides/it/php-java/aspose.slides/slideshowtransition/#getSpeed).

### **Applicare la stessa durata a tutte le diapositive**

Per mantenere un ritmo costante, applica lo stesso effetto e la stessa durata esatta a ogni diapositiva. Questo esempio carica `input.pptx`, seleziona Fade dall'enumerazione [TransitionType](https://reference.aspose.com/slides/it/php-java/aspose.slides/transitiontype/), e assegna a ogni transizione una durata di 750 millisecondi. Attiva separatamente l'avanzamento automatico dopo 5.000 millisecondi e disabilita l'avanzamento con clic del mouse, quindi salva il risultato come PPTX.

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

        // Configura l'avanzamento automatico indipendentemente dalla durata dell'effetto.
        $transition->setAdvanceAfter(true);
        $transition->setAdvanceAfterTime(5000);
        $transition->setAdvanceOnClick(false);
    }

    $presentation->save("precise-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Impostare durate diverse per diapositive individuali**

Diapositive diverse possono usare durate di effetto differenti. Ad esempio, usa una transizione rapida per una diapositiva titolo e una più lunga per l'introduzione di una sezione. Questo esempio imposta 500 millisecondi per la prima diapositiva e 1.200 millisecondi per la seconda. Usa un file `input.pptx` con almeno due diapositive.

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

### **Coordinare le transizioni con output animato**

Quando prepari un [animated GIF](/slides/it/php-java/convert-powerpoint-to-animated-gif/), una [presentazione HTML5](/slides/it/php-java/export-to-html5/) o un [video](/slides/it/php-java/convert-powerpoint-to-video/), imposta durate di transizione esatte prima dell'esportazione per corrispondere al ritmo desiderato. Ad esempio, usa una dissolvenza di 600 millisecondi tra le scene e regola separatamente il ritardo di avanzamento di ciascuna diapositiva per consentire il tempo necessario alla narrazione o al contenuto.

Per GIF e video, coordina la frequenza dei fotogrammi dell'output con la durata dell'effetto: 600 millisecondi corrispondono a 18 fotogrammi a 30 fps. In HTML5, abilita le transizioni animate nelle impostazioni di esportazione. Verifica gli effetti e le opzioni di timing supportati dal formato di esportazione scelto e visualizza un'anteprima per confermare la sincronizzazione.

### **Leggere la durata di una transizione esistente**

Chiama [getDuration](https://reference.aspose.com/slides/it/php-java/aspose.slides/slideshowtransition/#getDuration) prima di modificare la transizione per determinare se è memorizzato un valore esplicito. Un valore di `-1` indica che non è impostata alcuna durata esplicita; un valore non negativo specifica la durata memorizzata in millisecondi. Il valore non impostato non è la durata di riproduzione calcolata: Aspose.Slides utilizza il tipo di transizione e il valore di [getSpeed](https://reference.aspose.com/slides/it/php-java/aspose.slides/slideshowtransition/#getSpeed) per determinare quella durata. L'impostazione di un tipo di transizione può inizializzare una durata, quindi ispeziona prima le impostazioni originali.

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

La transizione Morph anima le modifiche tra oggetti su diapositive consecutive. Per creare un semplice effetto Morph, clona una diapositiva, sposta o ridimensiona un oggetto nel clone e applica la transizione Morph alla seconda diapositiva. Questo fornisce agli oggetti corrispondenti la possibilità di animarsi tra lo stato originale e quello modificato.

L'esempio seguente crea una diapositiva con un rettangolo di testo, clona la diapositiva e cambia la posizione e le dimensioni del rettangolo nel clone. Seleziona quindi Morph dall'enumerazione [TransitionType](https://reference.aspose.com/slides/it/php-java/aspose.slides/transitiontype/) per la seconda diapositiva. Apri il file salvato in un visualizzatore di presentazioni che supporta Morph per vedere l'effetto durante una presentazione.

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

L'enumerazione [TransitionMorphType](https://reference.aspose.com/slides/it/php-java/aspose.slides/transitionmorphtype/) controlla come Morph associa e anima il contenuto:

- [ByObject](https://reference.aspose.com/slides/it/php-java/aspose.slides/transitionmorphtype/#ByObject) tratta ogni forma come un oggetto intero.
- [ByWord](https://reference.aspose.com/slides/it/php-java/aspose.slides/transitionmorphtype/#ByWord) anima il testo facendo corrispondere le parole dove possibile.
- [ByChar](https://reference.aspose.com/slides/it/php-java/aspose.slides/transitionmorphtype/#ByChar) anima il testo facendo corrispondere i caratteri dove possibile.

Usa [setType](https://reference.aspose.com/slides/it/php-java/aspose.slides/slideshowtransition/#setType) per selezionare Morph prima di accedere a [getValue](https://reference.aspose.com/slides/it/php-java/aspose.slides/slideshowtransition/#getValue). Il valore fornisce quindi un oggetto [MorphTransition](https://reference.aspose.com/slides/it/php-java/aspose.slides/morphtransition/), il cui metodo [setMorphType](https://reference.aspose.com/slides/it/php-java/aspose.slides/morphtransition/#setMorphType) seleziona la modalità di corrispondenza.

Questo esempio apre la presentazione creata nella sezione precedente e configura la seconda diapositiva per utilizzare l'animazione Morph basata su parole.

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

Alcune transizioni espongono opzioni aggiuntive, come la direzione o se l'effetto inizia da una schermata nera. Le opzioni disponibili dipendono dalla transizione selezionata con [setType](https://reference.aspose.com/slides/it/php-java/aspose.slides/slideshowtransition/#setType). Imposta prima il tipo, poi usa l'oggetto di transizione appropriato ottenuto da [getValue](https://reference.aspose.com/slides/it/php-java/aspose.slides/slideshowtransition/#getValue).

L'esempio seguente applica una transizione Cut alla prima diapositiva di `input.pptx`. Chiama [setFromBlack](https://reference.aspose.com/slides/it/php-java/aspose.slides/optionalblacktransition/#setFromBlack) tramite [OptionalBlackTransition](https://reference.aspose.com/slides/it/php-java/aspose.slides/optionalblacktransition/) in modo che la transizione inizi da una schermata nera.

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

**Posso controllare la velocità di riproduzione di una transizione della diapositiva?**

Sì. Preferisci [setDuration](https://reference.aspose.com/slides/it/php-java/aspose.slides/slideshowtransition/#setDuration) quando hai bisogno di una durata esatta dell'effetto in millisecondi. Usa [setSpeed](https://reference.aspose.com/slides/it/php-java/aspose.slides/slideshowtransition/#setSpeed) quando è sufficiente una categoria predefinita di [TransitionSpeed](https://reference.aspose.com/slides/it/php-java/aspose.slides/transitionspeed/): Lenta, Media o Veloce, e non è impostata una durata esplicita. Queste impostazioni controllano l'effetto di transizione indipendentemente dal ritardo di avanzamento automatico.

**Posso allegare audio a una transizione e farlo ripetere in loop?**

Sì. Assegna audio incorporato con [setSound](https://reference.aspose.com/slides/it/php-java/aspose.slides/slideshowtransition/#setSound), passa StartSound dall'enumerazione [TransitionSoundMode](https://reference.aspose.com/slides/it/php-java/aspose.slides/transitionsoundmode/) a [setSoundMode](https://reference.aspose.com/slides/it/php-java/aspose.slides/slideshowtransition/#setSoundMode) e abilita [setSoundLoop](https://reference.aspose.com/slides/it/php-java/aspose.slides/slideshowtransition/#setSoundLoop) con `true`. L'audio si ripete in loop fino al prossimo evento sonoro nella presentazione.

**Qual è il modo più veloce per applicare la stessa transizione a ogni diapositiva?**

Scorri la collezione [getSlides](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#getSlides) della presentazione e chiama [setType](https://reference.aspose.com/slides/it/php-java/aspose.slides/slideshowtransition/#setType) con lo stesso valore per la transizione di ogni diapositiva. Imposta eventuali opzioni di timing ed effetti nello stesso ciclo per mantenere il comportamento coerente su tutte le diapositive.

**Come posso verificare quale transizione è attualmente impostata su una diapositiva?**

Chiama [getType](https://reference.aspose.com/slides/it/php-java/aspose.slides/slideshowtransition/#getType) sul risultato di [getSlideShowTransition](https://reference.aspose.com/slides/it/php-java/aspose.slides/baseslide/#getSlideShowTransition) della diapositiva. Restituisce un valore dell'enumerazione [TransitionType](https://reference.aspose.com/slides/it/php-java/aspose.slides/transitiontype/); None indica che nessun effetto di transizione è applicato.