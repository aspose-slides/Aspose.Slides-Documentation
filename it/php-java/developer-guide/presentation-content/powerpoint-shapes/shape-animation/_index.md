---
title: Applicare animazioni di forme nelle presentazioni usando PHP
linktitle: Animazione forma
type: docs
weight: 60
url: /it/php-java/shape-animation/
keywords:
- forma
- animazione
- effetto
- forma animata
- testo animato
- aggiungere animazione
- ottenere animazione
- estrarre animazione
- aggiungere effetto
- ottenere effetto
- estrarre effetto
- suono effetto
- applicare animazione
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Scopri come aggiungere, analizzare e personalizzare le animazioni di forme, la temporizzazione, i suoni, il comportamento dopo l'animazione e il testo animato con Aspose.Slides per PHP via Java."
---
## **Panoramica**

Aspose.Slides for PHP via Java rappresenta le animazioni delle diapositive come effetti in una timeline della diapositiva. Un effetto ha una forma di destinazione, un tipo e sottotipo di animazione, un trigger, impostazioni di temporizzazione e proprietà opzionali come suono o comportamento dopo l’animazione.

La timeline contiene due tipologie di sequenze:

- La **sequenza principale** viene riprodotta mentre la diapositiva avanza.  
- Una **sequenza interattiva** inizia quando la forma trigger viene cliccata.

Poiché caselle di testo, immagini, grafici, tabelle e altri oggetti della diapositiva sono forme, si utilizza lo stesso [Sequence::addEffect](https://reference.aspose.com/slides/it/php-java/aspose.slides/sequence/addeffect/) per la maggior parte del contenuto della diapositiva. Gli effetti disponibili sono elencati nella classe [EffectType](https://reference.aspose.com/slides/it/php-java/aspose.slides/effecttype/).

## **Aggiungere animazioni a forme**

Per aggiungere un’animazione, ottieni la sequenza principale della diapositiva e chiama [Sequence::addEffect](https://reference.aspose.com/slides/it/php-java/aspose.slides/sequence/addeffect/) con la forma di destinazione, il tipo di effetto, il sottotipo e il trigger. Per un effetto che inizia quando un’altra forma è cliccata, crea una sequenza interattiva il cui trigger è quell’altra forma.

L’esempio seguente crea entrambi i tipi di animazione e salva il risultato in `shape-animations.pptx`.

```php
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 120, 100, 320, 80);
    $targetShape->addTextFrame("Click to animate this shape");

    $mainSequence = $slide->getTimeline()->getMainSequence();
    $entranceEffect = $mainSequence->addEffect($targetShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $entranceEffect->getTiming()->setDuration(1.5);

    $triggerShape = $slide->getShapes()->addAutoShape(ShapeType::Bevel, 20, 20, 100, 40);
    $triggerShape->addTextFrame("Move");

    $interactiveSequence = $slide->getTimeline()->getInteractiveSequences()->add($triggerShape);
    $interactiveSequence->addEffect($targetShape, EffectType::PathFootball, EffectSubtype::None, EffectTriggerType::OnClick);

    $presentation->save("shape-animations.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il trigger controlla quando un effetto inizia:

- [EffectTriggerType::OnClick](https://reference.aspose.com/slides/it/php-java/aspose.slides/effecttriggertype/) attende un clic nella sequenza principale, o un clic sulla forma trigger in una sequenza interattiva.  
- [EffectTriggerType::WithPrevious](https://reference.aspose.com/slides/it/php-java/aspose.slides/effecttriggertype/) inizia con l’effetto precedente.  
- [EffectTriggerType::AfterPrevious](https://reference.aspose.com/slides/it/php-java/aspose.slides/effecttriggertype/) inizia quando l’effetto precedente termina.

Per animare un’immagine, un grafico o un altro tipo di forma, passa quell’oggetto a [Sequence::addEffect](https://reference.aspose.com/slides/it/php-java/aspose.slides/sequence/addeffect/) invece di `$targetShape`. Per le opzioni di raggruppamento specifiche dei grafici, vedi [Animated Charts](/slides/it/php-java/animated-charts/).

## **Leggere animazioni di forme**

Usa [Sequence::getEffectsByShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/sequence/geteffectsbyshape/) quando conosci la forma di destinazione. Per ispezionare ogni effetto, elenca la sequenza principale e ogni sequenza interattiva. L’enumerazione evita di presumere che una sequenza contenga un effetto all’indice `0`.

L’esempio seguente crea una forma con effetti nella sequenza principale e interattivi, ottiene gli effetti che hanno come destinazione la forma e poi elenca ogni sequenza sulla diapositiva.

```php
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

function printSequence($label, $sequence)
{
    $effectCount = java_values($sequence->getCount());

    echo "  " . $label . ": " . $effectCount . " effect(s)" . PHP_EOL;

    for ($effectIndex = 0; $effectIndex < $effectCount; $effectIndex++) {
        $effect = $sequence->get_Item($effectIndex);
        $targetShape = $effect->getTargetShape();
        $targetName = java_is_null($targetShape) ? "unknown" : java_values($targetShape->getName());
        $effectType = java_values($effect->getType());
        $effectSubtype = java_values($effect->getSubtype());
        $triggerType = java_values($effect->getTiming()->getTriggerType());
        echo "    type: " . $effectType . "; subtype: " . $effectSubtype . "; target: " . $targetName . "; trigger: " . $triggerType . PHP_EOL;
    }
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 120, 100, 320, 80);
    $targetShape->addTextFrame("Animated shape");

    $mainSequence = $slide->getTimeline()->getMainSequence();
    $mainSequence->addEffect($targetShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

    $triggerShape = $slide->getShapes()->addAutoShape(ShapeType::Bevel, 20, 20, 100, 40);
    $triggerShape->addTextFrame("Move");

    $interactiveSequence = $slide->getTimeline()->getInteractiveSequences()->add($triggerShape);
    $interactiveSequence->addEffect($targetShape, EffectType::PathFootball, EffectSubtype::None, EffectTriggerType::OnClick);

    $targetEffects = $mainSequence->getEffectsByShape($targetShape);
    $Array = new JavaClass("java.lang.reflect.Array");
    echo "The main sequence contains " . java_values($Array->getLength($targetEffects)) . " effect(s) for " . java_values($targetShape->getName()) . "." . PHP_EOL;

    printSequence("Main sequence", $mainSequence);

    $interactiveSequences = $slide->getTimeline()->getInteractiveSequences();
    $interactiveCount = java_values($interactiveSequences->getCount());
    for ($interactiveIndex = 0; $interactiveIndex < $interactiveCount; $interactiveIndex++) {
        $sequence = $interactiveSequences->get_Item($interactiveIndex);
        $sequenceTrigger = $sequence->getTriggerShape();
        $triggerName = java_is_null($sequenceTrigger) ? "unknown" : java_values($sequenceTrigger->getName());
        printSequence("Interactive sequence " . ($interactiveIndex + 1) . ", trigger: " . $triggerName, $sequence);
    }
} finally {
    $presentation->dispose();
}
```

Se ti servono solo gli effetti per una singola forma, identifica prima la forma per nome, tipo di segnaposto o altra proprietà stabile; poi chiama [Sequence::getEffectsByShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/sequence/geteffectsbyshape/). Non presumere che [ShapeCollection::get_Item](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapecollection/get_item/) all’indice `0` sia sempre l’oggetto desiderato.

## **Lavorare con gli effetti dei segnaposto ereditati**

Un segnaposto su una diapositiva normale può ereditare il comportamento di animazione dal corrispondente segnaposto nella diapositiva layout e nella diapositiva master. [Shape::getBasePlaceholder](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/getbaseplaceholder/) restituisce quel segnaposto genitore, o `null` quando non esiste un genitore.

Nella presentazione di esempio, il piè di pagina ha **Random Bars** sulla diapositiva normale, **Split** sulla diapositiva layout e **Fly In** sulla diapositiva master.

![Animazione del piè di pagina sulla diapositiva normale](slide-shape-animation.png)

![Animazione del segnaposto piè di pagina sulla diapositiva layout](layout-shape-animation.png)

![Animazione del segnaposto piè di pagina sulla diapositiva master](master-shape-animation.png)

L’esempio successivo utilizza una gerarchia di segnaposti da una nuova presentazione. Aggiunge effetti a un segnaposto master, a un segnaposto layout e al corrispondente segnaposto su una diapositiva normale. Ogni chiamata a [Shape::getBasePlaceholder](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/getbaseplaceholder/) viene verificata prima di utilizzare la forma restituita.

```php
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

function findLayoutPlaceholderWithBase($layoutSlide)
{
    $shapes = $layoutSlide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_is_null($shape->getBasePlaceholder())) {
            return $shape;
        }
    }

    return null;
}

function findSlidePlaceholderWithBase($slide, $expectedBase)
{
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $basePlaceholder = $shape->getBasePlaceholder();
        if (!java_is_null($basePlaceholder) && java_values($basePlaceholder->equals($expectedBase))) {
            return $shape;
        }
    }

    return null;
}

function printEffects($source, $effects)
{
    $Array = new JavaClass("java.lang.reflect.Array");
    echo $source . ": " . java_values($Array->getLength($effects)) . " effect(s)" . PHP_EOL;

    foreach ($effects as $effect) {
        echo "  type: " . java_values($effect->getType()) . "; subtype: " . java_values($effect->getSubtype()) . PHP_EOL;
    }
}

$presentation = new Presentation();
try {
    $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::TitleAndObject);
    $layoutPlaceholder = findLayoutPlaceholderWithBase($layoutSlide);

    if ($layoutPlaceholder === null) {
        throw new RuntimeException("The layout slide does not contain a placeholder linked to its master slide.");
    }

    $masterPlaceholder = $layoutPlaceholder->getBasePlaceholder();
    $layoutSlide->getMasterSlide()->getTimeline()->getMainSequence()->addEffect($masterPlaceholder, EffectType::Fly, EffectSubtype::Bottom, EffectTriggerType::OnClick);
    $layoutSlide->getTimeline()->getMainSequence()->addEffect($layoutPlaceholder, EffectType::Split, EffectSubtype::VerticalIn, EffectTriggerType::OnClick);

    $slide = $presentation->getSlides()->addEmptySlide($layoutSlide);
    $slidePlaceholder = findSlidePlaceholderWithBase($slide, $layoutPlaceholder);

    if ($slidePlaceholder === null) {
        throw new RuntimeException("The slide does not contain a placeholder linked to its layout slide.");
    }

    $slide->getTimeline()->getMainSequence()->addEffect($slidePlaceholder, EffectType::RandomBars, EffectSubtype::Horizontal, EffectTriggerType::OnClick);
    printEffects("Normal slide", $slide->getTimeline()->getMainSequence()->getEffectsByShape($slidePlaceholder));

    $baseLayoutPlaceholder = $slidePlaceholder->getBasePlaceholder();
    if (!java_is_null($baseLayoutPlaceholder)) {
        printEffects("Layout slide", $layoutSlide->getTimeline()->getMainSequence()->getEffectsByShape($baseLayoutPlaceholder));

        $baseMasterPlaceholder = $baseLayoutPlaceholder->getBasePlaceholder();
        if (!java_is_null($baseMasterPlaceholder)) {
            printEffects("Master slide", $layoutSlide->getMasterSlide()->getTimeline()->getMainSequence()->getEffectsByShape($baseMasterPlaceholder));
        }
    }

    $presentation->save("placeholder-animations.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Modificare la temporizzazione dell’animazione**

La finestra di dialogo **Timing** di PowerPoint corrisponde alle proprietà di [Timing](https://reference.aspose.com/slides/it/php-java/aspose.slides/timing/).

![Finestra di dialogo Timing di PowerPoint per un effetto di animazione](shape-animation.png)

- **Start** corrisponde a [Timing::getTriggerType](https://reference.aspose.com/slides/it/php-java/aspose.slides/timing/gettriggertype/).  
- **Duration** corrisponde a [Timing::getDuration](https://reference.aspose.com/slides/it/php-java/aspose.slides/timing/getduration/), in secondi.  
- **Delay** corrisponde a [Timing::getTriggerDelayTime](https://reference.aspose.com/slides/it/php-java/aspose.slides/timing/gettriggerdelaytime/), in secondi.  
- **Repeat** corrisponde a [Timing::getRepeatCount](https://reference.aspose.com/slides/it/php-java/aspose.slides/timing/getrepeatcount/), [Timing::getRepeatUntilNextClick](https://reference.aspose.com/slides/it/php-java/aspose.slides/timing/getrepeatuntilnextclick/) o [Timing::getRepeatUntilEndSlide](https://reference.aspose.com/slides/it/php-java/aspose.slides/timing/getrepeatuntilendslide/).  
- **Rewind when done playing** corrisponde a [Timing::getRewind](https://reference.aspose.com/slides/it/php-java/aspose.slides/timing/getrewind/).

Questo esempio indipendente aggiunge un effetto, ne modifica la temporizzazione attraverso l’oggetto restituito da [Sequence::addEffect](https://reference.aspose.com/slides/it/php-java/aspose.slides/sequence/addeffect/), e salva il risultato. Mantenere il riferimento all’[Effect](https://reference.aspose.com/slides/it/php-java/aspose.slides/effect/) restituito evita un indice di collezione non necessario.

```php
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 120, 100, 320, 80);
    $shape->addTextFrame("Timed animation");

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getTiming()->setTriggerType(EffectTriggerType::OnClick);
    $effect->getTiming()->setDuration(2.0);
    $effect->getTiming()->setTriggerDelayTime(0.5);
    $effect->getTiming()->setRepeatUntilNextClick(false);
    $effect->getTiming()->setRepeatUntilEndSlide(false);
    $effect->getTiming()->setRepeatCount(2.0);
    $effect->getTiming()->setRewind(true);

    $presentation->save("shape-animation-timing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Utilizza un solo modo di ripetizione intenzionalmente. Combinare un conteggio di ripetizioni con un flag “until” può produrre risultati confusi in visualizzatori diversi. Quando cambi i mode di ripetizione, imposta [Timing::setRepeatUntilNextClick](https://reference.aspose.com/slides/it/php-java/aspose.slides/timing/setrepeatuntilnextclick/) e [Timing::setRepeatUntilEndSlide](https://reference.aspose.com/slides/it/php-java/aspose.slides/timing/setrepeatuntilendslide/) prima di [Timing::setRepeatCount](https://reference.aspose.com/slides/it/php-java/aspose.slides/timing/setrepeatcount/), poiché impostare uno dei flag modifica anche la modalità di ripetizione attiva.

## **Aggiungere ed estrarre suoni di animazione**

Un effetto di animazione può fare riferimento a audio incorporato tramite [Effect::getSound](https://reference.aspose.com/slides/it/php-java/aspose.slides/effect/getsound/). [Effect::setStopPreviousSound](https://reference.aspose.com/slides/it/php-java/aspose.slides/effect/setstopprevioussound/) indica a un effetto di interrompere l’audio avviato da un effetto precedente.

### **Aggiungere un suono a un effetto**

L’esempio seguente prevede un file audio locale chiamato `animation-sound.wav`. Crea due effetti, incorpora quel file come suono per il primo effetto e configura il secondo effetto per fermare il suono. Usa gli oggetti restituiti da [Sequence::addEffect](https://reference.aspose.com/slides/it/php-java/aspose.slides/sequence/addeffect/), quindi non è necessario alcun indice di sequenza.

```php
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$Files = new JavaClass("java.nio.file.Files");

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $firstShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 100, 240, 80);
    $secondShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 400, 100, 240, 80);
    $firstShape->addTextFrame("Starts sound");
    $secondShape->addTextFrame("Stops sound");

    $sequence = $slide->getTimeline()->getMainSequence();
    $firstEffect = $sequence->addEffect($firstShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $secondEffect = $sequence->addEffect($secondShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

    $baseDirectory = getcwd();
    $audioPath = (new Java("java.io.File", $baseDirectory . DIRECTORY_SEPARATOR . "animation-sound.wav"))->toPath();
    $audioData = $Files->readAllBytes($audioPath);
    $effectSound = $presentation->getAudios()->addAudio($audioData);
    $firstEffect->setSound($effectSound);
    $secondEffect->setStopPreviousSound(true);

    $presentation->save($baseDirectory . DIRECTORY_SEPARATOR . "shape-animation-sound.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Estrarre suoni incorporati negli effetti**

L’esempio seguente prevede una presentazione locale chiamata `presentation-with-animation-sounds.pptx`. Analizza sia le sequenze principali che quelle interattive e scrive ogni suono incorporato nella cartella `extracted-animation-sounds`. L’estensione è selezionata dal tipo MIME audio esposto da [Audio::getContentType](https://reference.aspose.com/slides/it/php-java/aspose.slides/audio/getcontenttype/).

```php
use aspose\slides\Presentation;

function getAudioExtension($contentType)
{
    $normalizedType = strtolower($contentType === null ? "" : java_values($contentType));

    if ($normalizedType === "audio/mpeg") {
        return ".mp3";
    }

    if ($normalizedType === "audio/mp4") {
        return ".m4a";
    }

    if ($normalizedType === "audio/ogg") {
        return ".ogg";
    }

    if ($normalizedType === "audio/wav" || $normalizedType === "audio/x-wav") {
        return ".wav";
    }

    return ".bin";
}

function saveSounds($sequence, $outputDirectory, $soundIndex)
{
    $effectCount = java_values($sequence->getCount());
    for ($effectIndex = 0; $effectIndex < $effectCount; $effectIndex++) {
        $effect = $sequence->get_Item($effectIndex);
        $sound = $effect->getSound();
        if (java_is_null($sound)) {
            continue;
        }

        $extension = getAudioExtension($sound->getContentType());
        $outputPath = $outputDirectory->resolve("effect-sound-" . $soundIndex . $extension);
        $outputStream = new Java("java.io.FileOutputStream", $outputPath->toFile());
        try {
            $outputStream->write($sound->getBinaryData());
        } finally {
            $outputStream->close();
        }
        $soundIndex++;
    }

    return $soundIndex;
}

$baseDirectory = getcwd();
$inputPath = (new Java("java.io.File", $baseDirectory . DIRECTORY_SEPARATOR . "presentation-with-animation-sounds.pptx"))->toPath();
$outputDirectoryName = $baseDirectory . DIRECTORY_SEPARATOR . "extracted-animation-sounds";
if (!is_dir($outputDirectoryName)) {
    mkdir($outputDirectoryName, 0777, true);
}
$outputDirectory = (new Java("java.io.File", $outputDirectoryName))->toPath();

$presentation = new Presentation($inputPath->toString());
try {
    $soundIndex = 1;

    $slides = $presentation->getSlides();
    $slideCount = java_values($slides->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $slides->get_Item($slideIndex);
        $soundIndex = saveSounds($slide->getTimeline()->getMainSequence(), $outputDirectory, $soundIndex);

        $interactiveSequences = $slide->getTimeline()->getInteractiveSequences();
        $interactiveCount = java_values($interactiveSequences->getCount());
        for ($sequenceIndex = 0; $sequenceIndex < $interactiveCount; $sequenceIndex++) {
            $sequence = $interactiveSequences->get_Item($sequenceIndex);
            $soundIndex = saveSounds($sequence, $outputDirectory, $soundIndex);
        }
    }

    echo "Extracted " . ($soundIndex - 1) . " sound file(s) to " . java_values($outputDirectory->toAbsolutePath()->toString()) . "." . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Per oggetti audio di grandi dimensioni, usa [Audio::getStream](https://reference.aspose.com/slides/it/php-java/aspose.slides/audio/getstream/) e copia lo stream su un file invece di caricare l’intero oggetto in un array di byte.

## **Impostare il comportamento dopo l’animazione**

L’opzione **After animation** controlla cosa accade a una forma dopo che il suo effetto termina.

![Finestra di dialogo Opzioni effetto PowerPoint che mostra le impostazioni After animation](shape-after-animation.png)

La classe [AfterAnimationType](https://reference.aspose.com/slides/it/php-java/aspose.slides/afteranimationtype/) supporta il mantenimento della forma invariata, la modifica del suo colore, la sua scomparsa dopo l’animazione, o la sua scomparsa al prossimo clic. Quando il tipo è [AfterAnimationType::Color](https://reference.aspose.com/slides/it/php-java/aspose.slides/afteranimationtype/), impostare anche [Effect::getAfterAnimationColor](https://reference.aspose.com/slides/it/php-java/aspose.slides/effect/getafteranimationcolor/).

Questo esempio indipendente crea un effetto, ne imposta il comportamento after‑animation tramite l’oggetto effetto restituito, e salva il risultato.

```php
use aspose\slides\AfterAnimationType;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 120, 100, 320, 80);
    $shape->addTextFrame("Dim after animation");

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->setAfterAnimationType(AfterAnimationType::Color);
    $effect->getAfterAnimationColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);

    $presentation->save("shape-animation-after-effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Cambiare il tipo da [AfterAnimationType::Color](https://reference.aspose.com/slides/it/php-java/aspose.slides/afteranimationtype/) cancella l’impostazione del colore after‑animation.

## **Animare testo**

L’animazione del testo ha due controlli correlati:

- [TextAnimation::getBuildType](https://reference.aspose.com/slides/it/php-java/aspose.slides/textanimation/getbuildtype/) controlla se i paragrafi compaiono tutti insieme o a livello di paragrafo.  
- [Effect::getAnimateTextType](https://reference.aspose.com/slides/it/php-java/aspose.slides/effect/getanimatetexttype/) controlla se il testo appare tutto in una volta, parola per parola o lettera per lettera. [Effect::getDelayBetweenTextParts](https://reference.aspose.com/slides/it/php-java/aspose.slides/effect/getdelaybetweentextparts/) imposta il ritardo tra parole o lettere. Un valore positivo è una percentuale della durata dell’effetto; un valore negativo è un ritardo in secondi.

L’esempio indipendente seguente anima le parole in una casella di testo. [BuildType::AsOneObject](https://reference.aspose.com/slides/it/php-java/aspose.slides/buildtype/) disabilita la costruzione paragrafo per paragrafo così che l’impostazione per le parole si applichi all’intero riquadro di testo.

```php
use aspose\slides\AnimateTextType;
use aspose\slides\BuildType;
use aspose\slides\EffectSubtype;
use aspose\slides\EffectTriggerType;
use aspose\slides\EffectType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 560, 100);
    $textBox->addTextFrame("Aspose.Slides animates this sentence word by word.");

    $effect = $slide->getTimeline()->getMainSequence()->addEffect($textBox, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
    $effect->getTextAnimation()->setBuildType(BuildType::AsOneObject);
    $effect->setAnimateTextType(AnimateTextType::ByWord);
    $effect->setDelayBetweenTextParts(20.0);

    $presentation->save("animated-text.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Per costruire una casella di testo per paragrafo, imposta [BuildType::ByLevelParagraphs1](https://reference.aspose.com/slides/it/php-java/aspose.slides/buildtype/) (o un altro livello di paragrafo). Per targetizzare un singolo paragrafo con il proprio effetto, usa la sovraccarico di [Sequence::addEffect](https://reference.aspose.com/slides/it/php-java/aspose.slides/sequence/addeffect/) che accetta un [Paragraph](https://reference.aspose.com/slides/it/php-java/aspose.slides/paragraph/). Vedi [Animated Text](/slides/it/php-java/animated-text/) per esempi a livello di paragrafo.

## **Esportazione e note di compatibilità**

- Il salvataggio in PPT o PPTX preserva il modello di animazione, ma la riproduzione finale è controllata dal visualizzatore della presentazione.  
- PDF e immagini statiche non riproducono animazioni. Usa l’[esportazione HTML5](/slides/it/php-java/export-to-html5/), GIF animata o la [conversione in video](/slides/it/php-java/convert-powerpoint-to-video/) quando l’output deve mostrare movimento.  
- Per HTML5, abilita [Html5Options::setAnimateShapes](https://reference.aspose.com/slides/it/php-java/aspose.slides/html5options/setanimateshapes/) e, se necessario, [Html5Options::setAnimateTransitions](https://reference.aspose.com/slides/it/php-java/aspose.slides/html5options/setanimatetransitions/).  
- Il rendering video supporta molti effetti di ingresso, enfasi, uscita e percorso di movimento comuni, ma non tutti gli effetti di PowerPoint sono supportati. Controlla le [animazioni ed effetti supportati](/slides/it/php-java/convert-powerpoint-to-video/#supported-animations-and-effects) attuali e testa le presentazioni critiche con la versione di Aspose.Slides in uso.  
- Effetti personalizzati avanzati e effetti importati da altri formati di presentazione possono essere preservati nel file ma renderizzati diversamente in PowerPoint, HTML5 o video. Convalida il risultato esportato anziché basarti solo sul nome dell’effetto.

## **FAQ**

**Perché un’animazione appare in PowerPoint ma non in un PDF?**

Il PDF è un formato statico, quindi le animazioni e le transizioni delle diapositive non vengono riprodotte. Esporta in HTML5, GIF animata o video quando è necessario preservare il movimento.

**Perché un effetto viene riprodotto diversamente in un video?**

L’esportazione video rende le animazioni invece di memorizzare il comportamento originale di PowerPoint. Alcuni effetti avanzati non sono supportati o sono approssimati. Consulta la tabella degli effetti supportati e verifica la presentazione reale prima dell’uso in produzione.

**Spostare una forma in avanti o indietro cambia l’ordine di animazione?**

No. Lo z‑order della forma controlla la sovrapposizione, mentre l’ordine della sequenza e i trigger controllano la riproduzione dell’animazione. Modifica la timeline se necessiti di un ordine di riproduzione diverso.