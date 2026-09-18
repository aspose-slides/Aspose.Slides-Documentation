---
title: Criar e Modificar Comportamentos de Animação Personalizados em PHP
linktitle: Animação Personalizada
type: docs
weight: 151
url: /pt/php-java/custom-animation/
keywords:
- animação personalizada
- comportamento de animação
- caminho de movimento
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Criar, inspecionar e modificar comportamentos de animação personalizados e caminhos de movimento editáveis em apresentações PowerPoint com Aspose.Slides para PHP via Java."
---
## **Visão geral**

Comportamentos de animação personalizados permitem que você controle operações individuais dentro de um efeito de animação, como mudar uma cor, girar uma forma ou seguir um caminho de movimento editável. Este guia mostra como criar e combinar comportamentos, configurar seu tempo, inspecionar e modificar animações existentes e verificar se suas propriedades sobrevivem ao salvar e reabrir uma apresentação.

Para efeitos predefinidos e gatilhos de clique, veja [Animação de Forma](/slides/pt/php-java/shape-animation/).

## **Entenda o Modelo de Animação**

Uma animação é organizada como **Timeline → Sequence → Effect → Behaviors**:

- Cada slide tem uma linha do tempo contendo sua sequência principal e sequências interativas.
- Uma [Sequence](https://reference.aspose.com/slides/pt/php-java/aspose.slides/sequence/) contém efeitos, potencialmente direcionados a diferentes formas.
- Um [Effect](https://reference.aspose.com/slides/pt/php-java/aspose.slides/effect/) identifica uma forma alvo, preset, subtipo e o tempo do efeito.
- A coleção retornada por [Effect::getBehaviors](https://reference.aspose.com/slides/pt/php-java/aspose.slides/effect/getbehaviors/) contém as operações que implementam o efeito: mudar a cor, mover, girar, definir uma propriedade, etc.

## **Crie Comportamentos Individuais**

Chame [Sequence::addEffect](https://reference.aspose.com/slides/pt/php-java/aspose.slides/sequence/addeffect/) para criar um efeito e acessar a coleção [getBehaviors](https://reference.aspose.com/slides/pt/php-java/aspose.slides/effect/getbehaviors/). Um preset pode preencher essa coleção automaticamente. Mantenha suas operações ao estender o preset, ou use [clear](https://reference.aspose.com/slides/pt/php-java/aspose.slides/behaviorcollection/clear/) ao substituí‑las deliberadamente.

[BehaviorFactory](https://reference.aspose.com/slides/pt/php-java/aspose.slides/behaviorfactory/) cria os oito tipos de comportamento ilustrados abaixo. Movimento é abordado em [Construir um Caminho de Movimento](#build-a-motion-path). Cada trecho inclui suas importações e supõe que o PHP/Java Bridge e a biblioteca Aspose.Slides PHP foram carregados. Exemplos de edição posteriores indicam qual arquivo de saída eles utilizam.

### **Rotação**

Use [createRotationEffect](https://reference.aspose.com/slides/pt/php-java/aspose.slides/behaviorfactory/createrotationeffect/) para criar uma rotação. [getBy](https://reference.aspose.com/slides/pt/php-java/aspose.slides/rotationeffect/getby/) especifica um ângulo relativo em graus; [getFrom](https://reference.aspose.com/slides/pt/php-java/aspose.slides/rotationeffect/getfrom/) e [getTo](https://reference.aspose.com/slides/pt/php-java/aspose.slides/rotationeffect/getto/) especificam os pontos finais.

O exemplo começa com um efeito Spin, substitui suas operações de preset por um comportamento de rotação e atribui a essa operação uma duração de dois segundos. Um ângulo relativo de 90 graus representa um quarto de volta a partir da orientação inicial da forma, então não é necessário um ângulo inicial explícito.

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

`rotation.pptx` contém uma forma e um comportamento de rotação. A coleção, o tempo e os exemplos de edição de rotação abaixo usam este arquivo.

### **Escala**

Use [createScaleEffect](https://reference.aspose.com/slides/pt/php-java/aspose.slides/behaviorfactory/createscaleeffect/) com porcentagens X/Y: [getFrom](https://reference.aspose.com/slides/pt/php-java/aspose.slides/scaleeffect/getfrom/) e [getTo](https://reference.aspose.com/slides/pt/php-java/aspose.slides/scaleeffect/getto/) descrevem o tamanho inicial e final, enquanto [getBy](https://reference.aspose.com/slides/pt/php-java/aspose.slides/scaleeffect/getby/) descreve uma alteração relativa. Aqui, 100 significa o tamanho original.

O exemplo aumenta ambas as dimensões de 100% para 125% em dois segundos. Usar percentuais horizontais e verticais iguais mantém as proporções da forma; percentuais diferentes esticariam uma dimensão mais que a outra.

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

### **Cor**

Use [createColorEffect](https://reference.aspose.com/slides/pt/php-java/aspose.slides/behaviorfactory/createcoloreffect/) para mudar o preenchimento de azul para laranja. [getFrom](https://reference.aspose.com/slides/pt/php-java/aspose.slides/coloreffect/getfrom/) e [getTo](https://reference.aspose.com/slides/pt/php-java/aspose.slides/coloreffect/getto/) são cores; [getBy](https://reference.aspose.com/slides/pt/php-java/aspose.slides/coloreffect/getby/) é um deslocamento de cor. A [BehaviorPropertyCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/behaviorpropertycollection/) do comportamento identifica o atributo que está sendo animado.

O preenchimento sólido da forma é inicializado como azul, correspondendo à cor inicial da animação. Selecionar o atributo de cor de preenchimento indica ao comportamento qual parte da forma mudar; os pontos finais de cor por si só não identificam esse atributo. O efeito salvo descreve uma transição de dois segundos para laranja.

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

Use [createFilterEffect](https://reference.aspose.com/slides/pt/php-java/aspose.slides/behaviorfactory/createfiltereffect/) para selecionar um efeito de varredura. [getType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/filtereffect/gettype/), [getSubtype](https://reference.aspose.com/slides/pt/php-java/aspose.slides/filtereffect/getsubtype/), e [getReveal](https://reference.aspose.com/slides/pt/php-java/aspose.slides/filtereffect/getreveal/) especificam o filtro, a direção e se revelar ou ocultar a forma.

Este exemplo configura uma varredura de dois segundos que revela a forma usando o subtipo de direção direita. As configurações de filtro pertencem ao comportamento dentro do efeito, portanto são configuradas após as operações originais do preset serem removidas.

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

### **Propriedade**

Use [createPropertyEffect](https://reference.aspose.com/slides/pt/php-java/aspose.slides/behaviorfactory/createpropertyeffect/) para animar a opacidade. [getFrom](https://reference.aspose.com/slides/pt/php-java/aspose.slides/propertyeffect/getfrom/), [getTo](https://reference.aspose.com/slides/pt/php-java/aspose.slides/propertyeffect/getto/), e [getBy](https://reference.aspose.com/slides/pt/php-java/aspose.slides/propertyeffect/getby/) são strings interpretadas usando [getValueType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/propertyeffect/getvaluetype/) e [getCalcMode](https://reference.aspose.com/slides/pt/php-java/aspose.slides/propertyeffect/getcalcmode/). Escolha pontos finais ou um deslocamento relativo em vez de definir todos os três indiscriminadamente.

Aqui, o atributo selecionado é opacidade, e as strings numéricas representam uma mudança de 25% de opacidade para opacidade total. A interpolação linear descreve uma mudança gradual entre esses valores. Ao adaptar este exemplo para outro atributo, escolha um tipo de valor e valores de ponto final adequados a esse atributo.

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

### **Definir**

Use [createSetEffect](https://reference.aspose.com/slides/pt/php-java/aspose.slides/behaviorfactory/createseteffect/) para atribuir visibilidade através de [getTo](https://reference.aspose.com/slides/pt/php-java/aspose.slides/seteffect/getto/). Um comportamento de definição não interpola entre os pontos finais.

O exemplo seleciona o atributo de visibilidade e atribui a string `visible` quando o comportamento é executado. O retângulo já está visível nesta apresentação mínima, portanto a atribuição pode não produzir uma mudança visual óbvia por si só. Essa operação é útil como parte de um efeito maior que também controla quando a forma se torna oculta ou visível.

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

Use [createCommandEffect](https://reference.aspose.com/slides/pt/php-java/aspose.slides/behaviorfactory/createcommandeffect/) e configure [getType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/commandeffect/gettype/), [getCommandString](https://reference.aspose.com/slides/pt/php-java/aspose.slides/commandeffect/getcommandstring/), e [getShapeTarget](https://reference.aspose.com/slides/pt/php-java/aspose.slides/commandeffect/getshapetarget/). Coloque uma gravação WAV nomeada `sample.wav` no diretório de trabalho. Este exemplo a incorpora com [addAudioFrameEmbedded](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shapecollection/addaudioframeembedded/) e anexa um comando de reprodução ao quadro de áudio.

O quadro de áudio é tanto o alvo do efeito quanto o alvo do comando. Isso conecta a solicitação de reprodução à gravação incorporada; uma string de comando por si só não identifica qual objeto de mídia controlar. O efeito está configurado para iniciar ao clicar durante a apresentação.

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

Salvar armazena o comando em `command.pptx`; ele não reproduz a gravação. A reprodução requer um player de apresentação que suporte o comando e seu alvo de mídia.

## **Gerencie a Coleção de Comportamentos**

[BehaviorCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/behaviorcollection/) suporta [add](https://reference.aspose.com/slides/pt/php-java/aspose.slides/behaviorcollection/add/), [insert](https://reference.aspose.com/slides/pt/php-java/aspose.slides/behaviorcollection/insert/), [remove](https://reference.aspose.com/slides/pt/php-java/aspose.slides/behaviorcollection/remove/), e [removeAt](https://reference.aspose.com/slides/pt/php-java/aspose.slides/behaviorcollection/removeat/). Este exemplo abre `rotation.pptx`, adiciona escalonamento, move‑o antes da rotação e remove a rotação. Remover e reinserir o mesmo objeto altera sua posição armazenada sem fazer cópia.

A sequência de edições altera a coleção de rotação‑escala para escala‑rotação e depois apenas para escala. Índices referem‑se à coleção atual, portanto a remoção usa o novo índice da rotação após a reorganização. A enumeração final confirma qual comportamento será salvo.

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

O resultado é `ScaleEffect`: resta apenas o escalonamento. A ordem da coleção não agenda, por si só, comportamentos um após o outro. Limpe a coleção somente ao substituir todas as suas operações.

## **Configure o Tempo do Comportamento**

Um comportamento tem seu próprio [Timing](https://reference.aspose.com/slides/pt/php-java/aspose.slides/timing/), independente do tempo retornado por [Effect::getTiming](https://reference.aspose.com/slides/pt/php-java/aspose.slides/effect/gettiming/). O tempo do efeito agenda o efeito envolvente; o tempo do comportamento descreve uma operação dentro dele.

### **Definir Duração, Atraso, Repetição e Aceleração**

Abra `rotation.pptx` e defina a duração ([getDuration](https://reference.aspose.com/slides/pt/php-java/aspose.slides/timing/getduration/)) e o atraso de gatilho ([getTriggerDelayTime](https://reference.aspose.com/slides/pt/php-java/aspose.slides/timing/gettriggerdelaytime/)) em segundos, depois configure a contagem de repetições através de [setRepeatCount](https://reference.aspose.com/slides/pt/php-java/aspose.slides/timing/setrepeatcount/). [getAccelerate](https://reference.aspose.com/slides/pt/php-java/aspose.slides/timing/getaccelerate/) e [getDecelerate](https://reference.aspose.com/slides/pt/php-java/aspose.slides/timing/getdecelerate/) são frações da duração; mantenha sua soma no máximo 1.

O arquivo de entrada é o criado no exemplo de rotação, onde se sabe que o primeiro comportamento é uma rotação. Este exemplo altera apenas o tempo desse comportamento; seu ângulo de 90 graus permanece intacto. Manter o ângulo e o tempo separados facilita ajustar o ritmo sem reconstruir a animação.

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

O comportamento usa duração de dois segundos, atraso de meio segundo e contagem de repetições 3. Os primeiros e últimos 20% de sua duração são usados para aceleração e desaceleração.

Outras políticas de repetição incluem [getRepeatDuration](https://reference.aspose.com/slides/pt/php-java/aspose.slides/timing/getrepeatduration/), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/pt/php-java/aspose.slides/timing/getrepeatuntilendslide/), e [getRepeatUntilNextClick](https://reference.aspose.com/slides/pt/php-java/aspose.slides/timing/getrepeatuntilnextclick/); escolha uma política em vez de habilitá‑las todas ao mesmo tempo. [getAutoReverse](https://reference.aspose.com/slides/pt/php-java/aspose.slides/timing/getautoreverse/) reproduz a animação ao contrário após a passagem direta. A aceleração e desaceleração aplicam‑se a mudanças contínuas, não a atribuições discretas ou comandos.

## **Construa um Caminho de Movimento**

Use [createMotionEffect](https://reference.aspose.com/slides/pt/php-java/aspose.slides/behaviorfactory/createmotioneffect/) para criar movimento. Seu [getFrom](https://reference.aspose.com/slides/pt/php-java/aspose.slides/motioneffect/getfrom/), [getTo](https://reference.aspose.com/slides/pt/php-java/aspose.slides/motioneffect/getto/), e [getBy](https://reference.aspose.com/slides/pt/php-java/aspose.slides/motioneffect/getby/) descrevem coordenadas ou deslocamentos baseados em porcentagem. Para uma rota editável, crie um [MotionPath](https://reference.aspose.com/slides/pt/php-java/aspose.slides/motionpath/) e atribua‑o com [MotionEffect::setPath](https://reference.aspose.com/slides/pt/php-java/aspose.slides/motioneffect/setpath/). [MotionPath](https://reference.aspose.com/slides/pt/php-java/aspose.slides/motionpath/) armazena os comandos de caminho.

| Comando | Pontos | Significado |
| --- | --- | --- |
| MoveTo | Um | Define a posição inicial. |
| LineTo | Um | Move ao longo de um segmento reto até seu ponto final. |
| CurveTo | Três | Segue uma curva cúbica definida por dois pontos de controle e um ponto final. |
| CloseLoop | Nenhum | Retorna à posição inicial. |
| End | Nenhum | Finaliza o caminho. |

[MotionPathPointsType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/motionpathpointstype/) descreve características de edição de pontos, como cantos ou pontos suaves. Não substitui o tipo de comando. Use um tipo de ponto de curva para o exemplo de curva abaixo e um tipo de ponto de canto para os segmentos retos.

As coordenadas do caminho são normalizadas às dimensões do slide: um deslocamento X de 0,25 representa um quarto da largura do slide, não 0,25 pontos. Y positivo segue para baixo. Comandos absolutos especificam posições no sistema de coordenadas do caminho; comandos relativos especificam deslocamentos a partir da posição atual. Isso é separado de [getOrigin](https://reference.aspose.com/slides/pt/php-java/aspose.slides/motioneffect/getorigin/), que seleciona a estrutura de referência do caminho, e [getPathEditMode](https://reference.aspose.com/slides/pt/php-java/aspose.slides/motioneffect/getpatheditmode/), que controla como o caminho se move quando a forma é movida.

### **Crie um Caminho Reto**

Crie um comportamento de movimento com um ponto inicial, um segmento reto e um comando de final. [MotionPath::add](https://reference.aspose.com/slides/pt/php-java/aspose.slides/motionpath/add/) recebe o tipo de comando, seus pontos, o tipo de ponto e um sinalizador de coordenada relativa.

O comando inicial estabelece (0, 0), e a linha termina em (0.25, 0), dando ao trajeto um deslocamento horizontal de um quarto da largura do slide. O comando final não tem pontos de coordenada. Quando o caminho é atribuído, adicionar o comportamento de movimento ao efeito conecta esse trajeto ao retângulo.

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

`motion.pptx` contém um comportamento de movimento com três comandos de caminho. Os exemplos de edição de arquivo a seguir usam esta estrutura conhecida.

### **Compare Coordenadas Absolutas e Relativas**

Esses dois objetos de caminho descrevem a mesma rota. O comando absoluto termina em (0.3, 0.1); o comando relativo adiciona (0.1, 0.1) à posição atual, (0.2, 0).

Ambos os caminhos começam na mesma posição. Para a linha relativa, some seus deslocamentos X e Y à posição atual para obter o ponto final; para a linha absoluta, leia o ponto final diretamente. Alterar o sinalizador sem converter as coordenadas descreveria uma rota diferente.

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

Atribua qualquer um dos caminhos a um comportamento de movimento para usá‑lo em uma apresentação. O argumento booleano final seleciona coordenadas relativas para esse comando.

### **Substitua uma Linha por uma Curva**

Abra `motion.pptx` e substitua seu comando de linha por uma curva cúbica. Forneça primeiro os dois pontos de controle, seguidos pelo ponto final.

A posição inicial é fornecida pelo comando anterior. Os dois primeiros pontos moldam a curva, enquanto o terceiro é seu destino; eles não são três destinos sucessivos. Atualizar simultaneamente o tipo de comando, o tipo de edição de ponto e a matriz de pontos mantém o segmento consistente com sua nova geometria.

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

O caminho em `curve.pptx` ainda tem três comandos; seu comando do meio agora define uma curva.

## **Inspecione e Edite um Caminho Salvo**

Cada [MotionCmdPath](https://reference.aspose.com/slides/pt/php-java/aspose.slides/motioncmdpath/) expõe [getPoints](https://reference.aspose.com/slides/pt/php-java/aspose.slides/motioncmdpath/getpoints/), [getCommandType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/motioncmdpath/getcommandtype/), [getPointsType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/motioncmdpath/getpointstype/), e [isRelative](https://reference.aspose.com/slides/pt/php-java/aspose.slides/motioncmdpath/isrelative/). Os exemplos a seguir usam o caminho de três comandos conhecido em `motion.pptx`. Para entrada arbitrária, localize o efeito pretendido e verifique os tipos de comando e a contagem de pontos antes de editar por índice.

### **Leia Comandos e Coordenadas**

Leia o caminho sem alterá‑lo. Comandos de fim e fechar‑loop não precisam de pontos, portanto permita uma matriz de pontos nula.

A saída associa cada tipo de comando numérico ao seu sinalizador de coordenada relativa antes de listar seus pontos. Isso permite distinguir um ponto final de um deslocamento antes de modificar o caminho. Uma curva listaria três pontos, enquanto a linha reta neste arquivo lista apenas um.

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

A lista contém um ponto inicial, uma linha absoluta terminando em (0.25, 0) e um comando de fim.

### **Altere um Ponto Final**

Abra `motion.pptx` e substitua a matriz de pontos da linha para mover seu ponto final.

No arquivo de entrada, o índice 0 é o comando inicial e o índice 1 é a linha. Substituir o único ponto da linha altera seu destino sem mudar o tipo de comando, o tempo ou a posição na coleção. Como o comando usa coordenadas absolutas, o novo par especifica uma posição em vez de um deslocamento adicionado.

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

A linha em `motion-endpoint.pptx` termina em (0.4, 0.1); o arquivo original permanece inalterado.

### **Substitua um Segmento**

Use [insert](https://reference.aspose.com/slides/pt/php-java/aspose.slides/motionpath/insert/) e [removeAt](https://reference.aspose.com/slides/pt/php-java/aspose.slides/motionpath/removeat/) para substituir a linha em `motion.pptx`. Inserir desloca a linha antiga para o índice 2.

Isso demonstra a substituição de um objeto de comando em vez de editar suas coordenadas existentes. Após a inserção, a coleção contém temporariamente o comando inicial, a nova linha, a linha antiga e o comando de fim. Remover o índice 2 descarta a linha antiga e deixa a nova rota no lugar.

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

O caminho salvo ainda tem três comandos, com a nova linha terminando em (0.2, 0.1) e o comando de fim em último.

## **Modifique e Verifique um Comportamento Existente**

Quando o índice do comportamento é desconhecido, selecione‑o por tipo. Este exemplo abre `rotation.pptx`, encontra seu [RotationEffect](https://reference.aspose.com/slides/pt/php-java/aspose.slides/rotationeffect/), altera o ângulo e verifica o valor salvo após reabrir.

A verificação de tipo permite que o loop ignore comportamentos que não são rotações. A segunda carga lê o arquivo salvo em um objeto de apresentação separado, de modo que a comparação verifica os dados persistidos ao invés do valor ainda mantido na memória. Este exemplo ainda assume que o efeito conhecido é o primeiro na sequência principal; selecionar um comportamento por tipo não localiza o efeito correto em uma apresentação arbitrária.

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

O resultado é `Rotation preserved: true`. Aplique o mesmo padrão de verificação de tipo a outros comportamentos. Para uma verificação completa de preservação, compare a forma alvo, o efeito, os tipos e ordem dos comportamentos, o tempo e os comandos de caminho. Use uma tolerância numérica para valores de ponto flutuante. Para uma apresentação com layout de animação desconhecido, veja [Ler Animações de Forma](/slides/pt/php-java/shape-animation/#read-shape-animations) para percorrer as sequências principais e interativas.

## **Ordem dos Comportamentos, Presets e Reprodução**

A ordem em [BehaviorCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/behaviorcollection/) é a ordem armazenada das operações de um efeito. Não é uma lista de reprodução em que cada comportamento espera automaticamente o anterior. O tempo e o efeito envolvente determinam o agendamento. Os comportamentos podem se sobrepor, e operações na mesma propriedade podem interagir através das configurações de [additive](https://reference.aspose.com/slides/pt/php-java/aspose.slides/behavioradditivetype/) e [accumulation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/behavioraccumulatetype/). Não use apenas a reordenação da coleção para agendar “mover, então girar”; use tempo explícito ou efeitos separados como descrito em [Animação de Forma](/slides/pt/php-java/shape-animation/).

O [getType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/effect/gettype/) e o [getSubtype](https://reference.aspose.com/slides/pt/php-java/aspose.slides/effect/getsubtype/) do efeito descrevem seu preset. Eles não são uma descrição completa de uma árvore de comportamentos editada. Escolha o preset e subtipo antes de personalizar comportamentos: mudar o preset pode reconstruir a coleção e descartar suas operações personalizadas. Por exemplo, mudar um efeito Spin customizado para Fade pode substituir seu comportamento de rotação por comportamentos de set e filter. Inspecione a coleção novamente após mudar um preset ou subtipo. Limpar os comportamentos do preset também pode remover operações de visibilidade ou inicialização que o preset necessita. Os exemplos usam deliberadamente formas visíveis e substituem os comportamentos; eles não recriam a implementação de cada preset.

## **Compatibilidade de Formato**

Uma árvore de comportamentos preservada não garante reprodução idêntica em todos os visualizadores ou renderizadores de exportação. Verifique os dados salvos e a saída renderizada separadamente.

| Formato ou saída | O que verificar |
| --- | --- |
| PPTX | Use como o formato principal para estes exemplos. Reabra‑o para verificar a árvore de comportamentos editável, depois teste a reprodução na versão do PowerPoint desejada. |
| PPT | A representação binária legada pode diferir do PPTX. Teste um ciclo separado de salvar‑e‑reabrir e a reprodução; não deduza suporte para cada combinação personalizada a partir de um sucesso no PPTX. |
| PDF, PNG, JPEG e outras imagens estáticas de slides | Contêm uma representação estática do slide, não uma linha do tempo reproduzível ou um quadro final de animação garantido. |
| [HTML5](/slides/pt/php-java/export-to-html5/) | Pode reproduzir animações suportadas quando a animação de forma está habilitada nas opções de exportação. Teste combinações personalizadas no navegador. |
| [Animated GIF](/slides/pt/php-java/convert-powerpoint-to-animated-gif/) | Armazena quadros renderizados, não comportamentos editáveis ou interações acionadas por clique. Verifique o movimento realmente renderizado. |
| [Video](/slides/pt/php-java/convert-powerpoint-to-video/) | Renderiza quadros de animação e os codifica como vídeo. O suporte é limitado às [animações e efeitos suportados](/slides/pt/php-java/convert-powerpoint-to-video/#supported-animations-and-effects) do renderizador; comandos e eventos interativos não se tornam uma linha do tempo editável. |

## **FAQ**

**Por que meu efeito contém comportamentos antes de eu adicionar algum?**

Criar um efeito predefinido pode criar suas operações subjacentes. Inspecione‑as antes de decidir se estende o preset ou substitui seus comportamentos.

**Mover um comportamento para o início faz com que ele seja reproduzido primeiro?**

Não necessariamente. A ordem da coleção não substitui o tempo. Verifique atrasos, durações e interações entre operações na mesma propriedade.

**Por que um comando de fim não tem pontos?**

Ele marca o fim do caminho e não precisa de coordenadas. Verifique uma matriz de pontos nula ao inspecionar um caminho lido de um arquivo.

**Um ciclo bem‑sucedido de salvar e abrir é suficiente para confirmar a reprodução?**

Não. Reabrir confirma a preservação das propriedades que você verificou. Teste o player da apresentação ou a exportação animada separadamente para confirmar seu comportamento visual.