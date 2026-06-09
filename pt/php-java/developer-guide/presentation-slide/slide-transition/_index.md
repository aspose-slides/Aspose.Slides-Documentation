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
- transição de slide avançada
- transição morph
- tipo de transição
- efeito de transição
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Descubra como personalizar transições de slide no Aspose.Slides para PHP via Java, com orientação passo a passo para apresentações PowerPoint e OpenDocument."
---
## **Visão Geral**

Este artigo explica como gerenciar transições de slides em apresentações usando Aspose.Slides. Ele mostra como aplicar tipos de transição aos slides, configurar o comportamento da transição, como avançar ao clicar ou após um tempo especificado, verificar e desativar o avanço automático, usar a transição Morph e seus tipos, e definir opções de efeito de transição. Os exemplos demonstram como carregar ou criar uma apresentação, modificar as configurações de transição para slides selecionados e salvar o resultado como um arquivo PPTX. O artigo também responde a perguntas comuns sobre velocidade da transição, sons de transição, aplicação da mesma transição a vários slides e verificação da transição atualmente definida em um slide.

## **Adicionar Transição de Slide**
Para criar um efeito simples de transição de slide, siga os passos abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation).
2. Aplique um Tipo de Transição de Slide no slide a partir de um dos efeitos de transição oferecidos pela Aspose.Slides for PHP via Java através do enum TransitionType.
3. Grave o arquivo de apresentação modificado.

```php
  # Instanciar a classe Presentation para carregar o arquivo de apresentação fonte
  $presentation = new Presentation("AccessSlides.pptx");
  try {
    # Aplicar transição do tipo círculo no slide 1
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
    # Aplicar transição do tipo pente no slide 2
    $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);
    # Gravar a apresentação no disco
    $presentation->save("SampleTransition_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Adicionar Transição de Slide Avançada**
Na seção acima, aplicamos apenas um efeito de transição simples no slide. Agora, para tornar esse efeito simples ainda melhor e controlado, siga os passos abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation).
2. Aplique um Tipo de Transição de Slide no slide a partir de um dos efeitos de transição oferecidos pela Aspose.Slides for PHP via Java.
3. Você também pode definir a transição para Avançar ao Clicar, após um período de tempo específico ou ambos.
4. Se a transição do slide estiver habilitada para Avançar ao Clicar, a transição avançará somente quando alguém clicar o mouse. Além disso, se a propriedade Advance After Time estiver definida, a transição avançará automaticamente após o tempo especificado passar.
5. Grave a apresentação modificada como um arquivo de apresentação.

```php
  # Instanciar a classe Presentation que representa um arquivo de apresentação
  $pres = new Presentation("BetterSlideTransitions.pptx");
  try {
    # Aplicar transição do tipo círculo no slide 1
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
    # Definir o tempo de transição de 3 segundos
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setAdvanceAfterTime(3000);
    # Aplicar transição do tipo pente no slide 2
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);
    # Definir o tempo de transição de 5 segundos
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setAdvanceAfterTime(5000);
    # Aplicar transição do tipo zoom no slide 3
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setType(TransitionType::Zoom);
    # Definir o tempo de transição de 7 segundos
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setAdvanceAfterTime(7000);
    # Gravar a apresentação no disco
    $pres->save("SampleTransition_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Transição Morph**
{{% alert color="primary" %}} 
Aspose.Slides for PHP via Java agora suporta a [Morph Transition](https://reference.aspose.com/slides/pt/php-java/aspose.slides/morphtransition/). Elas representam a nova transição morph introduzida no PowerPoint 2019.
{{% /alert %}} 

A transição Morph permite animar um movimento suave de um slide para o próximo. Este artigo descreve o conceito e como usar a transição Morph. Para usar a transição Morph de forma eficaz, você precisará ter dois slides com ao menos um objeto em comum. A maneira mais fácil é duplicar o slide e então mover o objeto no segundo slide para um local diferente.

O trecho de código a seguir mostra como adicionar um clone do slide com algum texto à apresentação e definir uma transição do [morph type](https://reference.aspose.com/slides/pt/php-java/aspose.slides/TransitionType) para o segundo slide.

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

## **Tipos de Transição Morph**
Foi adicionado o novo enum [TransitionMorphType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/TransitionMorphType). Ele representa diferentes tipos de transição de slide Morph.

O enum TransitionMorphType tem três membros:

- ByObject: A transição Morph será executada considerando formas como objetos indivisíveis.
- ByWord: A transição Morph será executada transferindo o texto por palavras, quando possível.
- ByChar: A transição Morph será executada transferindo o texto por caracteres, quando possível.

O trecho de código a seguir mostra como definir a transição morph para o slide e alterar o tipo morph:

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

## **Definir Efeitos de Transição**
Aspose.Slides for PHP via Java suporta a definição de efeitos de transição, como de preto, da esquerda, da direita etc. Para definir o Efeito de Transição, siga os passos abaixo:

- Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation).
- Obtenha a referência do slide.
- Defina o efeito de transição.
- Grave a apresentação como um [PPTX](https://docs.fileformat.com/presentation/pptx/)arquivo.

No exemplo abaixo, definimos os efeitos de transição.

```php
  # Criar uma instância da classe Presentation
  $presentation = new Presentation("AccessSlides.pptx");
  try {
    # Definir efeito
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Cut);
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->getValue()->setFromBlack(true);
    # Gravar a apresentação no disco
    $presentation->save("SetTransitionEffects_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **FAQ**

**Posso controlar a velocidade de reprodução de uma transição de slide?**

Sim. Defina a [velocidade](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slideshowtransition/setspeed/) da transição usando a configuração [TransitionSpeed](https://reference.aspose.com/slides/pt/php-java/aspose.slides/transitionspeed/) (por exemplo, slow/medium/fast).

**Posso anexar áudio a uma transição e fazer loop?**

Sim. Você pode incorporar um som à transição e controlar o comportamento por meio de configurações como modo de som e repetição (por exemplo, [setSound](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slideshowtransition/setsound/), [setSoundMode](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slideshowtransition/setsoundmode/), [setSoundLoop](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slideshowtransition/setsoundloop/), além de metadados como [setSoundIsBuiltIn](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slideshowtransition/setsoundisbuiltin/) e [setSoundName](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slideshowtransition/setsoundname/)).

**Qual é a maneira mais rápida de aplicar a mesma transição a todos os slides?**

Configure o tipo de transição desejado nas configurações de transição de cada slide; as transições são armazenadas por slide, portanto aplicar o mesmo tipo a todos os slides produz um resultado consistente.

**Como posso verificar qual transição está atualmente definida em um slide?**

Verifique as [transition settings](https://reference.aspose.com/slides/pt/php-java/aspose.slides/baseslide/#getSlideShowTransition) do slide e leia o seu [transition type](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slideshowtransition/settype/); esse valor indica exatamente qual efeito está aplicado.