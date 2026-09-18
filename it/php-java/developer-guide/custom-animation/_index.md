---
title: Creare e modificare comportamenti di animazione personalizzati in PHP
linktitle: Animazione personalizzata
type: docs
weight: 151
url: /it/php-java/custom-animation/
keywords:
- animazione personalizzata
- comportamento di animazione
- percorso di movimento
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Creare, ispezionare e modificare comportamenti di animazione personalizzati e percorsi di movimento modificabili nelle presentazioni PowerPoint con Aspose.Slides per PHP via Java."
---
## **Panoramica**

I comportamenti di animazione personalizzati ti consentono di controllare operazioni individuali all'interno di un effetto di animazione, come la modifica di un colore, la rotazione di una forma o il seguito di un percorso di movimento modificabile. Questa guida mostra come creare e combinare i comportamenti, configurare il loro timing, ispezionare e modificare animazioni esistenti e verificare che le loro proprietà sopravvivano al salvataggio e alla riapertura di una presentazione.

Per effetti predefiniti e trigger di clic, vedi [Animazione delle forme](/slides/it/php-java/shape-animation/).

## **Comprendere il modello di animazione**

Un'animazione è organizzata come **Timeline → Sequence → Effect → Behaviors**:

- Ogni diapositiva ha una timeline che contiene la sua sequenza principale e le sequenze interattive.
- Una [Sequence](https://reference.aspose.com/slides/it/php-java/aspose.slides/sequence/) contiene effetti, potenzialmente rivolti a forme diverse.
- Un [Effect](https://reference.aspose.com/slides/it/php-java/aspose.slides/effect/) identifica una forma di destinazione, un preset, un subtipo e il timing dell'effetto.
- La collezione restituita da [Effect::getBehaviors](https://reference.aspose.com/slides/it/php-java/aspose.slides/effect/getbehaviors/) contiene le operazioni che implementano l'effetto: modifica del colore, spostamento, rotazione, impostazione di una proprietà, ecc.

## **Creare comportamenti individuali**

Chiama [Sequence::addEffect](https://reference.aspose.com/slides/it/php-java/aspose.slides/sequence/addeffect/) per creare un effetto e accedere alla collezione [getBehaviors](https://reference.aspose.com/slides/it/php-java/aspose.slides/effect/getbehaviors/). Un preset può popolare automaticamente questa collezione. Mantieni le sue operazioni quando estendi il preset, o usa [clear](https://reference.aspose.com/slides/it/php-java/aspose.slides/behaviorcollection/clear/) quando le sostituisci deliberatamente.

BehaviorFactory crea gli otto tipi di comportamento illustrati di seguito. Il movimento è trattato in Build a Motion Path. Ogni frammento include le sue importazioni e assume che il PHP/Java Bridge e la libreria Aspose.Slides PHP siano stati caricati. Gli esempi di modifica successivi indicano quale file di output utilizzano.

### **Rotazione**

Usa [createRotationEffect](https://reference.aspose.com/slides/it/php-java/aspose.slides/behaviorfactory/createrotationeffect/) per creare una rotazione. [getBy](https://reference.aspose.com/slides/it/php-java/aspose.slides/rotationeffect/getby/) specifica un angolo relativo in gradi; [getFrom](https://reference.aspose.com/slides/it/php-java/aspose.slides/rotationeffect/getfrom/) e [getTo](https://reference.aspose.com/slides/it/php-java/aspose.slides/rotationeffect/getto/) specificano i punti finali.

L'esempio parte da un effetto Spin, sostituisce le sue operazioni preset con un comportamento di rotazione, e assegna a tale operazione una durata di due secondi. Un angolo relativo di 90 gradi esprime un quarto di giro rispetto all'orientamento iniziale della forma, quindi non è necessario specificare un angolo di partenza.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Spin, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $rotation = $factory->createRotationEffect();
    $rotation->setBy(90);
    $rotation->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($rotation);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`rotation.pptx` contiene una forma e un comportamento di rotazione. La collezione, il timing e gli esempi di modifica della rotazione di seguito utilizzano questo file.

### **Scala**

Usa [createScaleEffect](https://reference.aspose.com/slides/it/php-java/aspose.slides/behaviorfactory/createscaleeffect/) con percentuali X/Y: [getFrom](https://reference.aspose.com/slides/it/php-java/aspose.slides/scaleeffect/getfrom/) e [getTo](https://reference.aspose.com/slides/it/php-java/aspose.slides/scaleeffect/getto/) descrivono la dimensione iniziale e finale, mentre [getBy](https://reference.aspose.com/slides/it/php-java/aspose.slides/scaleeffect/getby/) descrive una variazione relativa. Qui, 100 indica la dimensione originale.

L'esempio aumenta entrambe le dimensioni dal 100% al 125% in due secondi. L'uso di percentuali orizzontali e verticali uguali mantiene le proporzioni della forma; percentuali diverse allungherebbero una dimensione più dell'altra.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::GrowShrink, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $scale = $factory->createScaleEffect();
    $initialSize = new Point2DFloat(100, 100);
    $scale->setFrom($initialSize);
    $targetSize = new Point2DFloat(125, 125);
    $scale->setTo($targetSize);
    $scale->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($scale);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "scale.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Colore**

Usa [createColorEffect](https://reference.aspose.com/slides/it/php-java/aspose.slides/behaviorfactory/createcoloreffect/) per cambiare il riempimento da blu a arancione. [getFrom](https://reference.aspose.com/slides/it/php-java/aspose.slides/coloreffect/getfrom/) e [getTo](https://reference.aspose.com/slides/it/php-java/aspose.slides/coloreffect/getto/) sono colori; [getBy](https://reference.aspose.com/slides/it/php-java/aspose.slides/coloreffect/getby/) è un offset di colore. La [BehaviorPropertyCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/behaviorpropertycollection/) del comportamento identifica l'attributo animato.

Il riempimento solido della forma è inizializzato a blu, corrispondente al colore iniziale dell'animazione. Selezionare l'attributo fill-color indica al comportamento quale parte della forma modificare; i punti finali del colore da soli non identificano quell'attributo. L'effetto salvato descrive una transizione di due secondi verso l'arancione.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\BehaviorProperty;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$blue = new Java("java.awt.Color", 0, 0, 255);

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor($blue);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::ChangeFillColor, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $color = $factory->createColorEffect();
    $color->getProperties()->add(BehaviorProperty::getFillColor()->getValue());
    $color->getFrom()->setColor($blue);
    $orange = new Java("java.awt.Color", 255, 165, 0);
    $color->getTo()->setColor($orange);
    $color->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($color);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "color.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Filtro**

Usa [createFilterEffect](https://reference.aspose.com/slides/it/php-java/aspose.slides/behaviorfactory/createfiltereffect/) per selezionare una cancellazione. [getType](https://reference.aspose.com/slides/it/php-java/aspose.slides/filtereffect/gettype/), [getSubtype](https://reference.aspose.com/slides/it/php-java/aspose.slides/filtereffect/getsubtype/), e [getReveal](https://reference.aspose.com/slides/it/php-java/aspose.slides/filtereffect/getreveal/) specificano il filtro, la direzione e se rivelare o nascondere la forma.

Questo esempio configura una cancellazione di due secondi che rivela la forma usando il subtipo di direzione destra. Le impostazioni del filtro appartengono al comportamento all'interno dell'effetto, quindi vengono configurate dopo la rimozione delle operazioni originali del preset.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\FilterEffectRevealType;
use aspose\slides\FilterEffectSubtype;
use aspose\slides\FilterEffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Wipe, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $filter = $factory->createFilterEffect();
    $filter->setType(FilterEffectType::Wipe);
    $filter->setSubtype(FilterEffectSubtype::Right);
    $filter->setReveal(FilterEffectRevealType::In);
    $filter->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($filter);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "filter.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Proprietà**

Usa [createPropertyEffect](https://reference.aspose.com/slides/it/php-java/aspose.slides/behaviorfactory/createpropertyeffect/) per animare l'opacità. [getFrom](https://reference.aspose.com/slides/it/php-java/aspose.slides/propertyeffect/getfrom/), [getTo](https://reference.aspose.com/slides/it/php-java/aspose.slides/propertyeffect/getto/), e [getBy](https://reference.aspose.com/slides/it/php-java/aspose.slides/propertyeffect/getby/) sono stringhe interpretate usando [getValueType](https://reference.aspose.com/slides/it/php-java/aspose.slides/propertyeffect/getvaluetype/) e [getCalcMode](https://reference.aspose.com/slides/it/php-java/aspose.slides/propertyeffect/getcalcmode/). Scegli punti finali o un offset relativo invece di impostare tutti e tre indiscriminatamente.

Qui, l'attributo selezionato è l'opacità, e le stringhe numeriche rappresentano una variazione dal 25% di opacità all'opacità completa. L'interpolazione lineare descrive una variazione graduale tra tali valori. Quando si adatta questo esempio a un altro attributo, scegliere un tipo di valore e valori di fine appropriati a quell'attributo.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\BehaviorProperty;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\PropertyCalcModeType;
use aspose\slides\PropertyValueType;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $property = $factory->createPropertyEffect();
    $property->getProperties()->add(BehaviorProperty::getStyleOpacity()->getValue());
    $property->setValueType(PropertyValueType::Number);
    $property->setCalcMode(PropertyCalcModeType::Linear);
    $property->setFrom("0.25");
    $property->setTo("1");
    $property->getTiming()->setDuration(2);

    $effect->getBehaviors()->add($property);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "property.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Imposta**

Usa [createSetEffect](https://reference.aspose.com/slides/it/php-java/aspose.slides/behaviorfactory/createseteffect/) per assegnare la visibilità tramite [getTo](https://reference.aspose.com/slides/it/php-java/aspose.slides/seteffect/getto/). Un comportamento di set non interpola tra i punti finali.

L'esempio seleziona l'attributo visibility e assegna la stringa `visible` quando il comportamento viene eseguito. Il rettangolo è già visibile in questa presentazione minimale, quindi l'assegnazione potrebbe non produrre un cambiamento visivo evidente da sola. Un'operazione di questo tipo è utile come parte di un effetto più ampio che controlla anche quando la forma diventa nascosta o visibile.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\BehaviorProperty;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Appear, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $set = $factory->createSetEffect();
    $set->getProperties()->add(BehaviorProperty::getStyleVisibility()->getValue());
    $set->setTo("visible");

    $effect->getBehaviors()->add($set);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "set.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Comando**

Usa [createCommandEffect](https://reference.aspose.com/slides/it/php-java/aspose.slides/behaviorfactory/createcommandeffect/) e configura [getType](https://reference.aspose.com/slides/it/php-java/aspose.slides/commandeffect/gettype/), [getCommandString](https://reference.aspose.com/slides/it/php-java/aspose.slides/commandeffect/getcommandstring/), e [getShapeTarget](https://reference.aspose.com/slides/it/php-java/aspose.slides/commandeffect/getshapetarget/). Posiziona una registrazione WAV denominata `sample.wav` nella directory di lavoro. Questo esempio la incorpora con [addAudioFrameEmbedded](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapecollection/addaudioframeembedded/) e assegna un comando di riproduzione al frame audio.

Il frame audio è sia il target dell'effetto sia il target del comando. Questo collega la richiesta di riproduzione alla registrazione incorporata; una stringa di comando da sola non identifica quale oggetto multimediale controllare. L'effetto è configurato per avviarsi con un clic durante la presentazione.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\CommandEffectType;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioPath = $baseDirectory . DIRECTORY_SEPARATOR . "sample.wav";
    $audioStream = new Java("java.io.FileInputStream", $audioPath);
    try {
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(100, 100, 40, 40, $audioStream);

        $effect = $slide->getTimeline()->getMainSequence()->addEffect($audioFrame, EffectType::MediaPlay, EffectSubtype::None, EffectTriggerType::OnClick);
        $effect->getBehaviors()->clear();

        $factory = new BehaviorFactory();
        $command = $factory->createCommandEffect();
        $command->setType(CommandEffectType::Call);
        $command->setCommandString("play");
        $command->setShapeTarget($audioFrame);

        $effect->getBehaviors()->add($command);

        $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "command.pptx", SaveFormat::Pptx);
    } finally {
        $audioStream->close();
    }
} finally {
    $presentation->dispose();
}
```

Il salvataggio memorizza il comando in `command.pptx`; non riproduce la registrazione. La riproduzione richiede un lettore di presentazioni che supporti il comando e il suo target multimediale.

## **Gestire la collezione di comportamenti**

[BehaviorCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/behaviorcollection/) supporta [add](https://reference.aspose.com/slides/it/php-java/aspose.slides/behaviorcollection/add/), [insert](https://reference.aspose.com/slides/it/php-java/aspose.slides/behaviorcollection/insert/), [remove](https://reference.aspose.com/slides/it/php-java/aspose.slides/behaviorcollection/remove/), e [removeAt](https://reference.aspose.com/slides/it/php-java/aspose.slides/behaviorcollection/removeat/). Questo esempio apre `rotation.pptx`, aggiunge una scala, la sposta prima della rotazione e rimuove la rotazione. Rimuovere e reinserire lo stesso oggetto cambia la sua posizione memorizzata senza crearne una copia.

La sequenza di modifiche cambia la collezione da rotazione–scala a scala–rotazione, poi a sola scala. Gli indici si riferiscono alla collezione corrente, quindi la rimozione utilizza il nuovo indice della rotazione dopo il riordino. L'enumerazione finale conferma quale comportamento verrà salvato.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "rotation.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);
    $behaviors = $effect->getBehaviors();

    $factory = new BehaviorFactory();
    $scale = $factory->createScaleEffect();
    $targetSize = new Point2DFloat(125, 125);
    $scale->setTo($targetSize);
    $scale->getTiming()->setDuration(2);

    $behaviors->add($scale);

    $behaviors->remove($scale);
    $behaviors->insert(0, $scale);
    $behaviors->removeAt(1);

    $behaviorCount = java_values($behaviors->getCount());
    for ($i = 0; $i < $behaviorCount; $i++) {
        $behavior = $behaviors->get_Item($i);
        echo java_values($behavior->getClass()->getSimpleName()) . PHP_EOL;
    }

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "collection-edited.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

L'output è `ScaleEffect`: rimane solo la scala. L'ordine della collezione non programma, di per sé, i comportamenti uno dopo l'altro. Cancella la collezione solo quando sostituisci tutte le sue operazioni.

## **Configurare il timing del comportamento**

Un comportamento ha il proprio [Timing](https://reference.aspose.com/slides/it/php-java/aspose.slides/timing/), indipendente dal timing restituito da [Effect::getTiming](https://reference.aspose.com/slides/it/php-java/aspose.slides/effect/gettiming/). Il timing dell'effetto programma l'effetto contenitore; il timing del comportamento descrive un'operazione al suo interno.

### **Impostare Durata, Ritardo, Ripetizione e Accelerazione**

Apri `rotation.pptx` e imposta la durata ([getDuration](https://reference.aspose.com/slides/it/php-java/aspose.slides/timing/getduration/)) e il ritardo di trigger ([getTriggerDelayTime](https://reference.aspose.com/slides/it/php-java/aspose.slides/timing/gettriggerdelaytime/)) in secondi, poi configura il conteggio di ripetizione tramite [setRepeatCount](https://reference.aspose.com/slides/it/php-java/aspose.slides/timing/setrepeatcount/). [getAccelerate](https://reference.aspose.com/slides/it/php-java/aspose.slides/timing/getaccelerate/) e [getDecelerate](https://reference.aspose.com/slides/it/php-java/aspose.slides/timing/getdecelerate/) sono frazioni della durata; mantieni la loro somma al massimo 1.

Il file di input è quello creato nell'esempio di rotazione, dove si sa che il primo comportamento è una rotazione. Questo esempio modifica solo il timing di quel comportamento; il suo angolo di 90 gradi resta intatto. Tenere separati angolo e timing rende più semplice regolare il ritmo senza ricostruire l'animazione.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "rotation.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);

    $rotation = $effect->getBehaviors()->get_Item(0);
    $rotation->getTiming()->setDuration(2);
    $rotation->getTiming()->setTriggerDelayTime(0.5);
    $rotation->getTiming()->setRepeatCount(3);
    $rotation->getTiming()->setAccelerate(0.2);
    $rotation->getTiming()->setDecelerate(0.2);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "timing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il comportamento utilizza una durata di due secondi, un ritardo di mezzo secondo e un conteggio di ripetizione di 3. Il primo e l'ultimo 20% della sua durata sono usati per accelerazione e decelerazione.

Altre politiche di ripetizione includono [getRepeatDuration](https://reference.aspose.com/slides/it/php-java/aspose.slides/timing/getrepeatduration/), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/it/php-java/aspose.slides/timing/getrepeatuntilendslide/), e [getRepeatUntilNextClick](https://reference.aspose.com/slides/it/php-java/aspose.slides/timing/getrepeatuntilnextclick/); scegli una politica invece di abilitarle tutte insieme. [getAutoReverse](https://reference.aspose.com/slides/it/php-java/aspose.slides/timing/getautoreverse/) riproduce l'animazione al contrario dopo il passaggio in avanti. Accelerazione e decelerazione si applicano a cambiamenti continui, non a assegnazioni discrete o comandi.

## **Costruire un percorso di movimento**

Usa [createMotionEffect](https://reference.aspose.com/slides/it/php-java/aspose.slides/behaviorfactory/createmotioneffect/) per creare un movimento. I suoi [getFrom](https://reference.aspose.com/slides/it/php-java/aspose.slides/motioneffect/getfrom/), [getTo](https://reference.aspose.com/slides/it/php-java/aspose.slides/motioneffect/getto/), e [getBy](https://reference.aspose.com/slides/it/php-java/aspose.slides/motioneffect/getby/) descrivono coordinate o offset basati su percentuali. Per un percorso modificabile, crea un [MotionPath](https://reference.aspose.com/slides/it/php-java/aspose.slides/motionpath/) e assegnalo con [MotionEffect::setPath](https://reference.aspose.com/slides/it/php-java/aspose.slides/motioneffect/setpath/). [MotionPath](https://reference.aspose.com/slides/it/php-java/aspose.slides/motionpath/) memorizza i comandi del percorso.

| Comando | Punti | Significato |
| --- | --- | --- |
| MoveTo | Uno | Imposta la posizione di partenza. |
| LineTo | Uno | Muovi lungo un segmento rettilineo fino al suo punto finale. |
| CurveTo | Tre | Segui una curva cubica definita da due punti di controllo e un punto finale. |
| CloseLoop | Nessuno | Ritorna alla posizione di partenza. |
| End | Nessuno | Termina il percorso. |

[MotionPathPointsType](https://reference.aspose.com/slides/it/php-java/aspose.slides/motionpathpointstype/) descrive le caratteristiche di modifica dei punti, come punti d'angolo o lisci. Non sostituisce il tipo di comando. Usa un tipo di punto curva per l'esempio di curva sotto, e un tipo di punto d'angolo per i segmenti rettilinei.

Le coordinate del percorso sono normalizzate alle dimensioni della diapositiva: uno spostamento X di 0.25 rappresenta un quarto della larghezza della diapositiva, non 0.25 punti. Y positivo scorre verso il basso. I comandi assoluti specificano le posizioni nel sistema di coordinate del percorso; i comandi relativi specificano offset dalla posizione corrente. Questo è separato da [getOrigin](https://reference.aspose.com/slides/it/php-java/aspose.slides/motioneffect/getorigin/), che seleziona il frame di riferimento del percorso, e da [getPathEditMode](https://reference.aspose.com/slides/it/php-java/aspose.slides/motioneffect/getpatheditmode/), che controlla come il percorso si muove quando la forma viene spostata.

### **Creare un percorso rettilineo**

Crea un comportamento di movimento con un punto di partenza, un segmento rettilineo e un comando di fine. [MotionPath::add](https://reference.aspose.com/slides/it/php-java/aspose.slides/motionpath/add/) accetta il tipo di comando, i suoi punti, il tipo di punto e un flag di coordinate relative.

Il comando di partenza stabilisce (0, 0), e la linea termina a (0.25, 0), dando al percorso uno spostamento orizzontale di un quarto della larghezza della diapositiva. Il comando di fine non ha punti di coordinate. Una volta assegnato il percorso, aggiungere il comportamento di movimento all'effetto collega quel percorso al rettangolo.

```php
use aspose\slides\BehaviorFactory;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\MotionCommandPathType;
use aspose\slides\MotionOriginType;
use aspose\slides\MotionPath;
use aspose\slides\MotionPathPointsType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$baseDirectory = getcwd();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::PathRight, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getBehaviors()->clear();

    $factory = new BehaviorFactory();
    $motion = $factory->createMotionEffect();
    $motion->setOrigin(MotionOriginType::Layout);
    $motion->getTiming()->setDuration(2);

    $path = new MotionPath();
    $startPoints = [new Point2DFloat(0, 0)];
    $path->add(MotionCommandPathType::MoveTo, $startPoints, MotionPathPointsType::Auto, false);
    $endPoints = [new Point2DFloat(0.25, 0)];
    $path->add(MotionCommandPathType::LineTo, $endPoints, MotionPathPointsType::Corner, false);
    $path->add(MotionCommandPathType::End, [], MotionPathPointsType::None, false);

    $motion->setPath($path);
    $effect->getBehaviors()->add($motion);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`motion.pptx` contiene un comportamento di movimento con tre comandi di percorso. I seguenti esempi di modifica del file usano questa struttura nota.

### **Confrontare coordinate assolute e relative**

Questi due oggetti percorso descrivono lo stesso percorso. Il comando assoluto termina a (0.3, 0.1); il comando relativo aggiunge (0.1, 0.1) alla posizione corrente, (0.2, 0).

Entrambi i percorsi iniziano alla stessa posizione. Per la linea relativa, aggiungi i suoi offset X e Y alla posizione corrente per ottenere il punto finale; per la linea assoluta, leggi direttamente il punto finale. Cambiare il flag senza convertire le coordinate descriverebbe un percorso diverso.

```php
use aspose\slides\MotionCommandPathType;
use aspose\slides\MotionPath;
use aspose\slides\MotionPathPointsType;
use aspose\slides\Point2DFloat;

$absolutePath = new MotionPath();
$absoluteStart = [new Point2DFloat(0.2, 0)];
$absolutePath->add(MotionCommandPathType::MoveTo, $absoluteStart, MotionPathPointsType::Auto, false);
$absoluteEnd = [new Point2DFloat(0.3, 0.1)];
$absolutePath->add(MotionCommandPathType::LineTo, $absoluteEnd, MotionPathPointsType::Corner, false);

$relativePath = new MotionPath();
$relativeStart = [new Point2DFloat(0.2, 0)];
$relativePath->add(MotionCommandPathType::MoveTo, $relativeStart, MotionPathPointsType::Auto, false);
$relativeOffset = [new Point2DFloat(0.1, 0.1)];
$relativePath->add(MotionCommandPathType::LineTo, $relativeOffset, MotionPathPointsType::Corner, true);
```

Assegna uno dei due percorsi a un comportamento di movimento per usarlo in una presentazione. L'argomento booleano finale seleziona coordinate relative per quel comando.

### **Sostituire una linea con una curva**

Apri `motion.pptx` e sostituisci il suo comando di linea con una curva cubica. Fornisci prima i due punti di controllo, seguiti dal punto finale.

La posizione di partenza è fornita dal comando precedente. I primi due punti definiscono la curva, mentre il terzo è la sua destinazione; non sono tre destinazioni successive. Aggiornare contemporaneamente il tipo di comando, il tipo di modifica dei punti e l'array di punti mantiene il segmento coerente con la nuova geometria.

```php
use aspose\slides\MotionCommandPathType;
use aspose\slides\MotionPathPointsType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);
    $motion = $effect->getBehaviors()->get_Item(0);

    $path = $motion->getPath();
    $path->get_Item(1)->setCommandType(MotionCommandPathType::CurveTo);
    $path->get_Item(1)->setPointsType(MotionPathPointsType::CurveSmooth);
    $curvePoints = [new Point2DFloat(0.1, 0), new Point2DFloat(0.2, 0.1), new Point2DFloat(0.3, 0.1)];
    $path->get_Item(1)->setPoints($curvePoints);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "curve.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il percorso in `curve.pptx` ha ancora tre comandi; il comando intermedio ora definisce una curva.

## **Ispezionare e modificare un percorso salvato**

Ogni [MotionCmdPath](https://reference.aspose.com/slides/it/php-java/aspose.slides/motioncmdpath/) espone [getPoints](https://reference.aspose.com/slides/it/php-java/aspose.slides/motioncmdpath/getpoints/), [getCommandType](https://reference.aspose.com/slides/it/php-java/aspose.slides/motioncmdpath/getcommandtype/), [getPointsType](https://reference.aspose.com/slides/it/php-java/aspose.slides/motioncmdpath/getpointstype/), e [isRelative](https://reference.aspose.com/slides/it/php-java/aspose.slides/motioncmdpath/isrelative/). I seguenti esempi usano il percorso a tre comandi noto in `motion.pptx`. Per input arbitrari, individua l'effetto desiderato e verifica i tipi di comando e il conteggio dei punti prima di modificare per indice.

### **Leggere comandi e coordinate**

Leggi il percorso senza modificarlo. I comandi End e CloseLoop non necessitano di punti, quindi prevedi un array di punti nullo.

L'output associa ogni tipo di comando numerico al suo flag di coordinate relative prima di elencare i suoi punti. Questo ti permette di distinguere un punto finale da un offset prima di modificare il percorso. Una curva elencherebbe tre punti, mentre la linea rettilinea in questo file ne elenca solo uno.

```php
use aspose\slides\Presentation;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);
    $motion = $effect->getBehaviors()->get_Item(0);

    $path = $motion->getPath();
    $commandCount = java_values($path->getCount());
    for ($i = 0; $i < $commandCount; $i++) {
        $segment = $path->get_Item($i);
        $commandType = java_values($segment->getCommandType());
        $relative = java_values($segment->isRelative()) ? "true" : "false";
        echo $commandType . ", relative: " . $relative . PHP_EOL;
        $points = $segment->getPoints();
        if (!java_is_null($points)) {
            foreach ($points as $point) {
                echo "X=" . java_values($point->getX()) . ", Y=" . java_values($point->getY()) . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

L'elenco contiene un punto di partenza, una linea assoluta che termina a (0.25, 0), e un comando End.

### **Modificare un punto finale**

Apri `motion.pptx` e sostituisci l'array di punti della linea per spostare il suo punto finale.

Nel file di input, l'indice 0 è il comando di partenza e l'indice 1 è la linea. Sostituire il singolo punto della linea ne cambia la destinazione senza modificare il tipo di comando, il timing o la posizione nella collezione. Poiché il comando usa coordinate assolute, la nuova coppia specifica una posizione anziché un offset aggiunto.

```php
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);

    $motion = $effect->getBehaviors()->get_Item(0);
    $endPoints = [new Point2DFloat(0.4, 0.1)];
    $motion->getPath()->get_Item(1)->setPoints($endPoints);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "motion-endpoint.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

La linea in `motion-endpoint.pptx` termina a (0.4, 0.1); il file originale rimane invariato.

### **Sostituire un segmento**

Usa [insert](https://reference.aspose.com/slides/it/php-java/aspose.slides/motionpath/insert/) e [removeAt](https://reference.aspose.com/slides/it/php-java/aspose.slides/motionpath/removeat/) per sostituire la linea in `motion.pptx`. L'inserimento sposta la vecchia linea all'indice 2.

Questo dimostra la sostituzione di un oggetto comando piuttosto che modificare le coordinate esistenti. Dopo l'inserimento, la collezione contiene temporaneamente il comando di partenza, la nuova linea, la vecchia linea e il comando End. Rimuovendo l'indice 2 si elimina la vecchia linea e si mantiene il nuovo percorso.

```php
use aspose\slides\MotionCommandPathType;
use aspose\slides\MotionPathPointsType;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "motion.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);
    $motion = $effect->getBehaviors()->get_Item(0);

    $path = $motion->getPath();
    $replacementPoints = [new Point2DFloat(0.2, 0.1)];
    $path->insert(1, MotionCommandPathType::LineTo, $replacementPoints, MotionPathPointsType::Corner, false);
    $path->removeAt(2);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "motion-edited.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il percorso salvato ha ancora tre comandi, con la nuova linea che termina a (0.2, 0.1) e il comando End alla fine.

## **Modificare e verificare un comportamento esistente**

Quando l'indice del comportamento è sconosciuto, selezionalo per tipo. Questo esempio apre `rotation.pptx`, trova il suo [RotationEffect](https://reference.aspose.com/slides/it/php-java/aspose.slides/rotationeffect/), modifica l'angolo e verifica il valore salvato dopo aver riaperto.

Il controllo del tipo consente al ciclo di saltare i comportamenti che non sono rotazioni. Il secondo caricamento legge il file salvato in un oggetto presentazione separato, così il confronto verifica i dati persistenti anziché il valore ancora in memoria. Questo esempio assume ancora che l'effetto noto sia il primo nella sequenza principale; selezionare un comportamento per tipo non individua l'effetto corretto in una presentazione arbitraria.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$baseDirectory = getcwd();

$rotationClass = new JavaClass("com.aspose.slides.IRotationEffect");

$presentation = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "rotation.pptx");
try {
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);

    $behaviors = $effect->getBehaviors();
    $behaviorCount = java_values($behaviors->getCount());
    for ($i = 0; $i < $behaviorCount; $i++) {
        $behavior = $behaviors->get_Item($i);
        if (java_instanceof($behavior, $rotationClass)) {
            $rotation = $behavior;
            $rotation->setBy(180);
        }
    }

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "rotation-edited.pptx", SaveFormat::Pptx);

    $reopened = new Presentation($baseDirectory . DIRECTORY_SEPARATOR . "rotation-edited.pptx");
    try {
        $savedEffect = $reopened->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->get_Item(0);

        $savedBehaviors = $savedEffect->getBehaviors();
        $savedBehaviorCount = java_values($savedBehaviors->getCount());
        for ($i = 0; $i < $savedBehaviorCount; $i++) {
            $behavior = $savedBehaviors->get_Item($i);
            if (java_instanceof($behavior, $rotationClass)) {
                $rotation = $behavior;
                $preserved = abs(java_values($rotation->getBy()) - 180) < 0.001;
                echo "Rotation preserved: " . ($preserved ? "true" : "false") . PHP_EOL;
            }
        }
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

L'output è `Rotation preserved: true`. Applica lo stesso schema di verifica del tipo ad altri comportamenti. Per una verifica completa della conservazione, confronta la forma di destinazione, l'effetto, i tipi e l'ordine dei comportamenti, il timing e i comandi del percorso. Usa una tolleranza numerica per i valori floating-point. Per una presentazione con un layout di animazione sconosciuto, vedi [Read Shape Animations](/slides/it/php-java/shape-animation/#read-shape-animations) per l'attraversamento delle sequenze principali e interattive.

## **Ordine dei comportamenti, preset e riproduzione**

L'ordine in [BehaviorCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/behaviorcollection/) è l'ordine memorizzato delle operazioni di un effetto. Non è una playlist in cui ogni comportamento attende automaticamente quello precedente. Il timing e l'effetto contenitore determinano la programmazione. I comportamenti possono sovrapporsi, e le operazioni sulla stessa proprietà possono interagire tramite impostazioni additive e di accumulazione. Non usare solo il riordino della collezione per programmare “muovi, poi ruota”; usa timing esplicito o effetti separati come descritto in [Shape Animation](/slides/it/php-java/shape-animation/).

Il [getType](https://reference.aspose.com/slides/it/php-java/aspose.slides/effect/gettype/) e il [getSubtype](https://reference.aspose.com/slides/it/php-java/aspose.slides/effect/getsubtype/) dell'effetto descrivono il suo preset. Non sono una descrizione completa di un albero di comportamenti modificato. Scegli il preset e il subtipo prima di personalizzare i comportamenti: cambiare il preset può ricostruire la collezione e scartare le tue operazioni personalizzate. Per esempio, cambiare un effetto Spin personalizzato in Fade può sostituire il suo comportamento di rotazione con comportamenti set e filter. Ispeziona di nuovo la collezione dopo aver cambiato un preset o subtipo. Cancellare i comportamenti del preset può anche rimuovere operazioni di visibilità o di inizializzazione di cui il preset ha bisogno. Gli esempi usano deliberatamente forme visibili e sostituiscono i comportamenti; non ricostruiscono l'implementazione di ogni preset.

## **Compatibilità dei formati**

Un albero di comportamenti preservato non garantisce una riproduzione identica in ogni visualizzatore o motore di esportazione. Controlla separatamente i dati salvati e l'output renderizzato.

| Formato o output | Cosa verificare |
| --- | --- |
| PPTX | Usalo come formato principale per questi esempi. Riaprilo per verificare l'albero di comportamenti modificabile, poi controlla la riproduzione nella versione di PowerPoint desiderata. |
| PPT | La rappresentazione binaria legacy può differire da PPTX. Testa un ciclo di salvataggio e riapertura separato e la riproduzione; non inferire il supporto per ogni combinazione personalizzata dal risultato PPTX riuscito. |
| PDF, PNG, JPEG e altre immagini statiche delle diapositive | Contengono una rappresentazione statica della diapositiva, non una timeline di comportamenti riproducibile né un frame finale di animazione garantito. |
| [HTML5](/slides/it/php-java/export-to-html5/) | Può riprodurre le animazioni supportate quando l'animazione delle forme è abilitata nelle opzioni di esportazione. Testa combinazioni personalizzate nel browser. |
| [Animated GIF](/slides/it/php-java/convert-powerpoint-to-animated-gif/) | Memorizza i fotogrammi renderizzati, non i comportamenti modificabili o l'interazione attivata da click. Controlla il movimento effettivamente renderizzato. |
| [Video](/slides/it/php-java/convert-powerpoint-to-video/) | Renderizza i fotogrammi di animazione e li codifica come video. Il supporto è limitato alle [animazioni ed effetti supportati](/slides/it/php-java/convert-powerpoint-to-video/#supported-animations-and-effects) del renderer; i comandi e gli eventi interattivi non diventano una timeline modificabile. |

## **FAQ**

**Perché il mio effetto contiene comportamenti prima che ne aggiunga?**

La creazione di un effetto predefinito può generare le operazioni sottostanti. Ispezionalle prima di decidere se estendere il preset o sostituire i suoi comportamenti.

**Spostare un comportamento all'inizio lo fa riprodurre per primo?**

Non necessariamente. L'ordine della collezione non sostituisce il timing. Controlla ritardi, durate e interazioni tra operazioni sulla stessa proprietà.

**Perché un comando End non ha punti?**

Segna la fine del percorso e non ha bisogno di coordinate. Verifica un array di punti nullo quando ispezioni un percorso letto da un file.

**Un round trip riuscito è sufficiente a confermare la riproduzione?**

No. Riaprire conferma la conservazione delle proprietà verificate. Testa separatamente il lettore di presentazioni o l'esportazione animata per confermare il comportamento visivo.