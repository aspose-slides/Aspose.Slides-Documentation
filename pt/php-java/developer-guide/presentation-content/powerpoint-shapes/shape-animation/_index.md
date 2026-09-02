---
title: Aplicar animações de forma em apresentações usando PHP
linktitle: Animação de Forma
type: docs
weight: 60
url: /pt/php-java/shape-animation/
keywords:
- forma
- animação
- efeito
- forma animada
- texto animado
- adicionar animação
- obter animação
- extrair animação
- adicionar efeito
- obter efeito
- extrair efeito
- som do efeito
- aplicar animação
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Aprenda como adicionar, inspecionar e personalizar animações de forma, temporização, sons, comportamento pós‑animação e texto animado com Aspose.Slides para PHP via Java."
---
## **Visão geral**

Aspose.Slides para PHP via Java representa animações de slides como efeitos em uma linha do tempo de slide. Um efeito tem uma forma de destino, um tipo e subtipo de animação, um gatilho, configurações de temporização e propriedades opcionais como som ou comportamento pós‑animação.

A linha do tempo contém dois tipos de sequências:

- A **sequência principal** reproduz‑se conforme o slide avança.
- Uma **sequência interativa** inicia‑se quando sua forma de gatilho é clicada.

Como caixas de texto, imagens, gráficos, tabelas e outros objetos de slide são formas, você usa o mesmo [Sequence::addEffect](https://reference.aspose.com/slides/pt/php-java/aspose.slides/sequence/addeffect/) para a maioria do conteúdo do slide. Os efeitos disponíveis são listados na classe [EffectType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/effecttype/).

## **Adicionar animações a formas**

Para adicionar uma animação, obtenha a sequência principal do slide e chame [Sequence::addEffect](https://reference.aspose.com/slides/pt/php-java/aspose.slides/sequence/addeffect/) com a forma de destino, o tipo de efeito, o subtipo e o gatilho. Para um efeito que inicia quando outra forma é clicada, crie uma sequência interativa cujo gatilho seja essa outra forma.

O exemplo a seguir cria ambos os tipos de animação e salva o resultado em `shape-animations.pptx`.

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

O gatilho controla quando um efeito inicia:

- [EffectTriggerType::OnClick](https://reference.aspose.com/slides/pt/php-java/aspose.slides/effecttriggertype/) aguarda um clique na sequência principal, ou um clique na forma de gatilho em uma sequência interativa.
- [EffectTriggerType::WithPrevious](https://reference.aspose.com/slides/pt/php-java/aspose.slides/effecttriggertype/) inicia com o efeito anterior.
- [EffectTriggerType::AfterPrevious](https://reference.aspose.com/slides/pt/php-java/aspose.slides/effecttriggertype/) inicia quando o efeito anterior termina.

Para animar uma imagem, gráfico ou outro tipo de forma, passe esse objeto para [Sequence::addEffect](https://reference.aspose.com/slides/pt/php-java/aspose.slides/sequence/addeffect/) em vez de `$targetShape`. Para opções de agrupamento específicas de gráficos, consulte [Animated Charts](/slides/pt/php-java/animated-charts/).

## **Ler animações de formas**

Use [Sequence::getEffectsByShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/sequence/geteffectsbyshape/) quando souber a forma de destino. Para inspecionar cada efeito, enumere a sequência principal e todas as sequências interativas. A enumeração evita assumir que uma sequência contém um efeito no índice `0`.

O exemplo a seguir cria uma forma com efeitos de sequência principal e interativa, obtém os efeitos que têm a forma como alvo e, em seguida, enumera todas as sequências do slide.

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

Se precisar apenas dos efeitos para uma forma, primeiro identifique a forma por nome, tipo de espaço reservado ou outra propriedade estável; então chame [Sequence::getEffectsByShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/sequence/geteffectsbyshape/). Não presuma que [ShapeCollection::get_Item](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shapecollection/get_item/) no índice `0` seja sempre o objeto pretendido.

## **Trabalhar com efeitos de espaço reservado herdados**

Um espaço reservado em um slide normal pode herdar o comportamento de animação do espaço reservado correspondente no slide de layout e no slide mestre. [Shape::getBasePlaceholder](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/getbaseplaceholder/) devolve esse espaço reservado pai, ou `null` quando não existe pai.

Na apresentação de exemplo a seguir, o rodapé tem **Random Bars** no slide normal, **Split** no slide de layout e **Fly In** no slide mestre.

![Efeito de animação do rodapé no slide normal](slide-shape-animation.png)

![Efeito de animação do espaço reservado de rodapé no slide de layout](layout-shape-animation.png)

![Efeito de animação do espaço reservado de rodapé no slide mestre](master-shape-animation.png)

O próximo exemplo usa uma hierarquia de espaços reservados de uma nova apresentação. Ele adiciona efeitos a um espaço reservado mestre, a um espaço reservado de layout e ao espaço reservado correspondente em um slide normal. Cada chamada a [Shape::getBasePlaceholder](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/getbaseplaceholder/) é verificada antes de usar a forma retornada.

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

## **Alterar o tempo da animação**

A caixa de diálogo **Timing** do PowerPoint corresponde às propriedades de [Timing](https://reference.aspose.com/slides/pt/php-java/aspose.slides/timing/).

![Caixa de diálogo Timing do PowerPoint para um efeito de animação](shape-animation.png)

- **Start** corresponde a [Timing::getTriggerType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/timing/gettriggertype/).
- **Duration** corresponde a [Timing::getDuration](https://reference.aspose.com/slides/pt/php-java/aspose.slides/timing/getduration/), em segundos.
- **Delay** corresponde a [Timing::getTriggerDelayTime](https://reference.aspose.com/slides/pt/php-java/aspose.slides/timing/gettriggerdelaytime/), em segundos.
- **Repeat** corresponde a [Timing::getRepeatCount](https://reference.aspose.com/slides/pt/php-java/aspose.slides/timing/getrepeatcount/), [Timing::getRepeatUntilNextClick](https://reference.aspose.com/slides/pt/php-java/aspose.slides/timing/getrepeatuntilnextclick/) ou [Timing::getRepeatUntilEndSlide](https://reference.aspose.com/slides/pt/php-java/aspose.slides/timing/getrepeatuntilendslide/).
- **Rewind when done playing** corresponde a [Timing::getRewind](https://reference.aspose.com/slides/pt/php-java/aspose.slides/timing/getrewind/).

Este exemplo independente adiciona um efeito, altera seu tempo por meio do objeto devolvido por [Sequence::addEffect](https://reference.aspose.com/slides/pt/php-java/aspose.slides/sequence/addeffect/) e salva o resultado. Manter a referência ao [Effect](https://reference.aspose.com/slides/pt/php-java/aspose.slides/effect/) devolvido evita um índice de coleção desnecessário.

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

Use apenas um modo de repetição de forma intencional. Combinar um número de repetições com uma flag “until” pode produzir resultados confusos em diferentes visualizadores. Ao mudar os modos de repetição, chame [Timing::setRepeatUntilNextClick](https://reference.aspose.com/slides/pt/php-java/aspose.slides/timing/setrepeatuntilnextclick/) e [Timing::setRepeatUntilEndSlide](https://reference.aspose.com/slides/pt/php-java/aspose.slides/timing/setrepeatuntilendslide/) antes de [Timing::setRepeatCount](https://reference.aspose.com/slides/pt/php-java/aspose.slides/timing/setrepeatcount/), porque definir qualquer uma das flags também altera o modo de repetição ativo.

## **Adicionar e extrair sons de animação**

Um efeito de animação pode referenciar áudio incorporado através de [Effect::getSound](https://reference.aspose.com/slides/pt/php-java/aspose.slides/effect/getsound/). [Effect::setStopPreviousSound](https://reference.aspose.com/slides/pt/php-java/aspose.slides/effect/setstopprevioussound/) indica que um efeito deve parar o áudio iniciado por um efeito anterior.

### **Adicionar um som a um efeito**

O exemplo a seguir pressupõe um arquivo de áudio local chamado `animation-sound.wav`. Ele cria dois efeitos, incorpora esse arquivo como som do primeiro efeito e configura o segundo efeito para parar o som. Usa os objetos devolvidos por [Sequence::addEffect](https://reference.aspose.com/slides/pt/php-java/aspose.slides/sequence/addeffect/), portanto nenhum índice de sequência é necessário.

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

### **Extrair sons incorporados de efeitos**

O exemplo a seguir supõe uma apresentação local chamada `presentation-with-animation-sounds.pptx`. Ele analisa as sequências principal e interativa e grava cada som de efeito incorporado no diretório `extracted-animation-sounds`. A extensão é selecionada a partir do tipo MIME de áudio exposto por [Audio::getContentType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/audio/getcontenttype/).

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

Para objetos de áudio grandes, use [Audio::getStream](https://reference.aspose.com/slides/pt/php-java/aspose.slides/audio/getstream/) e copie o stream para um arquivo em vez de carregar todo o objeto em um array de bytes.

## **Definir comportamento pós‑animação**

A opção **After animation** controla o que acontece com uma forma depois que seu efeito termina.

![Caixa de diálogo de opções de efeito do PowerPoint mostrando as configurações de After animation](shape-after-animation.png)

A classe [AfterAnimationType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/afteranimationtype/) permite deixar a forma inalterada, mudar sua cor, ocultá‑la após a animação ou ocultá‑la no próximo clique. Quando o tipo é [AfterAnimationType::Color](https://reference.aspose.com/slides/pt/php-java/aspose.slides/afteranimationtype/), defina também [Effect::getAfterAnimationColor](https://reference.aspose.com/slides/pt/php-java/aspose.slides/effect/getafteranimationcolor/).

Este exemplo independente cria um efeito, define seu comportamento pós‑animação através do objeto de efeito retornado e salva o resultado.

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

Alterar o tipo para algo diferente de [AfterAnimationType::Color](https://reference.aspose.com/slides/pt/php-java/aspose.slides/afteranimationtype/) limpa a configuração de cor pós‑animação.

## **Animar texto**

A animação de texto tem dois controles relacionados:

- [TextAnimation::getBuildType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textanimation/getbuildtype/) controla se os parágrafos aparecem juntos ou nível por nível de parágrafo.
- [Effect::getAnimateTextType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/effect/getanimatetexttype/) controla se o texto aparece de uma vez, por palavra ou por letra. [Effect::getDelayBetweenTextParts](https://reference.aspose.com/slides/pt/php-java/aspose.slides/effect/getdelaybetweentextparts/) define o atraso entre palavras ou letras. Um valor positivo é uma porcentagem da duração do efeito; um valor negativo é um atraso em segundos.

O exemplo independente a seguir anima as palavras em uma caixa de texto. [BuildType::AsOneObject](https://reference.aspose.com/slides/pt/php-java/aspose.slides/buildtype/) desabilita a construção parágrafo a parágrafo para que a definição por palavra se aplique a todo o quadro de texto.

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

Para construir uma caixa de texto por parágrafo, defina [BuildType::ByLevelParagraphs1](https://reference.aspose.com/slides/pt/php-java/aspose.slides/buildtype/) (ou outro nível de parágrafo). Para direcionar um único parágrafo com seu próprio efeito, use a sobrecarga de [Sequence::addEffect](https://reference.aspose.com/slides/pt/php-java/aspose.slides/sequence/addeffect/) que aceita um [Paragraph](https://reference.aspose.com/slides/pt/php-java/aspose.slides/paragraph/). Consulte [Animated Text](/slides/pt/php-java/animated-text/) para exemplos ao nível de parágrafo.

## **Exportação e notas de compatibilidade**

- Salvar em PPT ou PPTX preserva o modelo de animação, mas a reprodução final é controlada pelo visualizador da apresentação.
- PDF e imagens estáticas não reproduzem animações. Use [exportação para HTML5](/slides/pt/php-java/export-to-html5/), GIF animado ou [conversão para vídeo](/slides/pt/php-java/convert-powerpoint-to-video/) quando a saída precisar mostrar movimento.
- Para HTML5, habilite [Html5Options::setAnimateShapes](https://reference.aspose.com/slides/pt/php-java/aspose.slides/html5options/setanimateshapes/) e, quando necessário, [Html5Options::setAnimateTransitions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/html5options/setanimatetransitions/).
- A renderização de vídeo suporta muitos efeitos comuns de entrada, ênfase, saída e caminho de movimento, mas nem todo efeito do PowerPoint é suportado. Verifique a lista atual de [animações e efeitos suportados](/slides/pt/php-java/convert-powerpoint-to-video/#supported-animations-and-effects) e teste apresentações críticas com a versão do Aspose.Slides que você utiliza.
- Efeitos personalizados avançados e efeitos importados de outros formatos de apresentação podem ser preservados no arquivo, porém renderizados de forma diferente no PowerPoint, HTML5 ou vídeo. Valide o resultado exportado em vez de confiar apenas no nome do efeito.

## **FAQ**

**Por que uma animação aparece no PowerPoint mas não em um PDF?**

PDF é um formato estático, portanto animações e transições de slide não são reproduzidas. Exporte para HTML5, GIF animado ou vídeo quando for necessário preservar o movimento.

**Por que um efeito é reproduzido de forma diferente em um vídeo?**

A exportação para vídeo renderiza animações em vez de armazenar o comportamento original do PowerPoint. Alguns efeitos avançados não são suportados ou são aproximados. Consulte a tabela de efeitos suportados e teste a apresentação real antes de usá‑la em produção.

**Mover uma forma para frente ou para trás altera a ordem da animação?**

Não. A ordem Z da forma controla a sobreposição, enquanto a ordem da sequência e os gatilhos controlam a reprodução da animação. Altere a linha do tempo se precisar de uma ordem de reprodução diferente.