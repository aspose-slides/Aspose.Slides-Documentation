---
title: Gerenciar Transições de Slides em Apresentações Usando PHP
linktitle: Transição de Slide
type: docs
weight: 80
url: /pt/php-java/slide-transition/
keywords:
- transição de slide
- adicionar transição de slide
- aplicar transição de slide
- transição avançada de slide
- transição Morph
- tipo de transição
- efeito de transição
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Aplique transições de slides, configure o avanço automático dos slides e personalize a transição Morph e outros efeitos de transição com Aspose.Slides para PHP via Java."
---
## **Visão geral**

As transições de slides controlam como os slides aparecem durante uma apresentação. Com Aspose.Slides para PHP via Java, você pode escolher um efeito de transição para cada slide, configurar o avanço por clique do mouse ou temporizador e ajustar opções específicas de um efeito. Este artigo usa exemplos em PHP para aplicar transições, definir durações exatas de transição, gerenciar o tempo dos slides e criar uma transição Morph entre dois slides. Os exemplos também mostram como salvar as configurações em um arquivo PPTX.

## **Adicionar Transição de Slide**

Para aplicar uma transição, carregue uma apresentação com a classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/) e acesse as configurações de transição do slide através de [getSlideShowTransition](https://reference.aspose.com/slides/pt/php-java/aspose.slides/baseslide/#getSlideShowTransition). Use [setType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slideshowtransition/#setType) com um valor da enumeração [TransitionType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/transitiontype/), em seguida salve a apresentação.

O exemplo a seguir aplica uma transição Circle ao primeiro slide e uma transição Comb ao segundo. Use um arquivo `input.pptx` com pelo menos dois slides.

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

## **Adicionar Transição de Slide Avançada**

Você pode configurar por quanto tempo um slide permanece na tela e se um clique do mouse avança a apresentação. Os métodos a seguir controlam esse comportamento:

- [setAdvanceOnClick](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) permite que o espectador avance clicando o mouse.
- [setAdvanceAfter](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) habilita o avanço automático.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) especifica o atraso antes do avanço automático, em milissegundos.

Habilite tanto o avanço por clique quanto o cronometrado para que o espectador possa avançar com um clique ou aguardar o temporizador. Para usar apenas o temporizador, passe `false` para [setAdvanceOnClick](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). O atraso controla quando a apresentação avança; ele não define a duração do efeito visual da transição.

Este exemplo atribui efeitos diferentes aos três primeiros slides e habilita o avanço automático após 3, 5 e 7 segundos, respectivamente. Cliques do mouse também podem avançar esses slides. Use um arquivo `input.pptx` com pelo menos três slides.

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

Para verificar se o avanço cronometrado está habilitado, chame [getAdvanceAfter](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slideshowtransition/#getAdvanceAfter). Um atraso armazenado sozinho não indica que o temporizador está ativo.

O próximo exemplo abre o arquivo salvo acima, relata cada temporizador habilitado e desabilita o avanço automático para slides com atraso maior que dois segundos. Ele habilita cliques do mouse para esses slides e salva as configurações atualizadas.

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

## **Controlar a Temporização da Transição com Precisão**

Use [setDuration](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slideshowtransition/#setDuration) para especificar o comprimento exato de um efeito de transição em milissegundos. O método [getSlideShowTransition](https://reference.aspose.com/slides/pt/php-java/aspose.slides/baseslide/#getSlideShowTransition) do slide expõe essas configurações através de [SlideShowTransition](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slideshowtransition/):

| Método | Objetivo |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slideshowtransition/#setDuration) | Define a duração do próprio efeito de transição, em milissegundos. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Define o atraso antes que o slide avance automaticamente, em milissegundos. Passe `true` para [setAdvanceAfter](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slideshowtransition/#setAdvanceAfter) para ativar esse temporizador. |
| [setSpeed](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slideshowtransition/#setSpeed) | Seleciona uma categoria de velocidade predefinida da enumeração [TransitionSpeed](https://reference.aspose.com/slides/pt/php-java/aspose.slides/transitionspeed/): Slow, Medium ou Fast. É usada quando uma duração exata não é especificada. |

[setDuration] controla apenas o efeito de transição; não determina quanto tempo o slide permanece visível. Configure o atraso de avanço automático separadamente. Quando nenhuma duração explícita é definida, Aspose.Slides determina a duração do efeito a partir do tipo de transição e do valor de [getSpeed].

### **Aplicar a Mesma Duração a Cada Slide**

Para um ritmo consistente, aplique o mesmo efeito e a mesma duração exata a cada slide. Este exemplo carrega `input.pptx`, seleciona Fade da enumeração [TransitionType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/transitiontype/), e atribui a cada transição uma duração de 750 milissegundos. Ele habilita separadamente o avanço automático após 5 000 milissegundos e desabilita o avanço por clique do mouse, então salva o resultado como PPTX.

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

        // Configure o avanço automático independentemente da duração do efeito.
        $transition->setAdvanceAfter(true);
        $transition->setAdvanceAfterTime(5000);
        $transition->setAdvanceOnClick(false);
    }

    $presentation->save("precise-transitions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Definir Durações Diferentes para Slides Individuais**

Slides diferentes podem usar durações de efeito distintas. Por exemplo, use uma transição curta para um slide de título e uma transição mais longa para a introdução de uma seção. Este exemplo define 500 milissegundos para o primeiro slide e 1 200 milissegundos para o segundo. Use um arquivo `input.pptx` com pelo menos dois slides.

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

### **Coordenar Transições com Saída Animada**

Ao preparar um [animated GIF](/slides/pt/php-java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/pt/php-java/export-to-html5/) ou [video](/slides/pt/php-java/convert-powerpoint-to-video/), defina durações exatas de transição antes da exportação para combinar com o ritmo desejado. Por exemplo, use um fade de 600 milissegundos entre cenas e ajuste separadamente o atraso de avanço de cada slide para permitir tempo para sua narração ou conteúdo.

Para GIF e vídeo, coordene a taxa de quadros de saída com a duração do efeito: 600 milissegundos correspondem a 18 quadros a 30 quadros por segundo. No HTML5, habilite transições animadas nas configurações de exportação. Verifique os efeitos e opções de temporização suportados pelo formato de exportação escolhido e visualize a saída para confirmar a sincronização.

### **Ler a Duração de uma Transição Existente**

Chame [getDuration](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slideshowtransition/#getDuration) antes de modificar a transição para determinar se um valor explícito está armazenado. Um valor de `-1` significa que nenhuma duração explícita está definida; um valor não negativo especifica a duração armazenada em milissegundos. O valor não definido não é a duração calculada de reprodução: Aspose.Slides usa o tipo de transição e o valor de [getSpeed] para determinar essa duração. Definir um tipo de transição pode inicializar uma duração, portanto inspecione as configurações originais primeiro.

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

## **Transição Morph**

A transição Morph anima alterações entre objetos em slides consecutivos. Para criar um efeito Morph simples, clone um slide, mova ou redimensione um objeto no clone e aplique a transição Morph ao segundo slide. Isso fornece aos objetos correspondentes da transição a animação entre seus estados original e modificado.

O exemplo a seguir cria um slide com um retângulo de texto, clona o slide e altera a posição e o tamanho do retângulo no clone. Em seguida, seleciona Morph da enumeração [TransitionType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/transitiontype/) para o segundo slide. Abra o arquivo salvo em um visualizador de apresentações que suporte Morph para ver o efeito durante a apresentação.

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

## **Tipos de Transição Morph**

A enumeração [TransitionMorphType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/transitionmorphtype/) controla como o Morph corresponde e anima o conteúdo:

- [ByObject](https://reference.aspose.com/slides/pt/php-java/aspose.slides/transitionmorphtype/#ByObject) trata cada forma como um objeto completo.
- [ByWord](https://reference.aspose.com/slides/pt/php-java/aspose.slides/transitionmorphtype/#ByWord) anima o texto correspondendo palavras quando possível.
- [ByChar](https://reference.aspose.com/slides/pt/php-java/aspose.slides/transitionmorphtype/#ByChar) anima o texto correspondendo caracteres quando possível.

Use [setType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slideshowtransition/#setType) para selecionar Morph antes de acessar [getValue](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slideshowtransition/#getValue). O valor então fornece um objeto [MorphTransition](https://reference.aspose.com/slides/pt/php-java/aspose.slides/morphtransition/), cujo método [setMorphType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/morphtransition/#setMorphType) seleciona o modo de correspondência.

Este exemplo abre a apresentação criada na seção anterior e configura o segundo slide para usar animação Morph baseada em palavras.

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

## **Definir Efeitos de Transição**

Algumas transições expõem opções adicionais, como direção ou se o efeito começa a partir de uma tela preta. As opções disponíveis dependem da transição selecionada com [setType]. Defina o tipo primeiro, depois use o objeto de transição apropriado de [getValue].

O exemplo a seguir aplica uma transição Cut ao primeiro slide de `input.pptx`. Ele chama [setFromBlack](https://reference.aspose.com/slides/pt/php-java/aspose.slides/optionalblacktransition/#setFromBlack) por meio de [OptionalBlackTransition](https://reference.aspose.com/slides/pt/php-java/aspose.slides/optionalblacktransition/) para que a transição comece a partir de uma tela preta.

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

## **Perguntas frequentes**

**Posso controlar a velocidade de reprodução de uma transição de slide?**

Sim. Prefira [setDuration] quando precisar de uma duração exata do efeito em milissegundos. Use [setSpeed] quando uma categoria predefinida de [TransitionSpeed]—Slow, Medium ou Fast— for suficiente e não houver duração explícita definida. Essas configurações controlam o efeito da transição independentemente do atraso de avanço automático.

**Posso anexar áudio a uma transição e fazê-lo em loop?**

Sim. Atribua áudio incorporado com [setSound], passe StartSound da enumeração [TransitionSoundMode] para [setSoundMode] e habilite [setSoundLoop] com `true`. O áudio fica em loop até o próximo evento sonoro na apresentação.

**Qual é a maneira mais rápida de aplicar a mesma transição a todos os slides?**

Percorra a coleção [getSlides] da apresentação e chame [setType] com o mesmo valor para a transição de cada slide. Defina quaisquer opções de temporização e efeito no mesmo loop para manter o comportamento consistente em todos os slides.

**Como posso verificar qual transição está atualmente definida em um slide?**

Chame [getType] no resultado de [getSlideShowTransition] do slide. Ele retorna um valor da enumeração [TransitionType]; None indica que nenhum efeito de transição está aplicado.