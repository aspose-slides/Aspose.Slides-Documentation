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
description: "Descubra como criar e personalizar animações de forma em apresentações do PowerPoint com Aspose.Slides para PHP via Java. Destaque-se!"
---
## **Introdução**

Animações são efeitos visuais que podem ser aplicados a textos, imagens, formas ou [gráficos](https://docs.aspose.com/slides/pt/php-java/animated-charts/). Elas dão vida às apresentações ou aos seus componentes.

## **Por que usar animações em apresentações?**

Usando animações, você pode 

* controlar o fluxo de informações
* enfatizar pontos importantes
* aumentar o interesse ou a participação do seu público
* tornar o conteúdo mais fácil de ler, assimilar ou processar
* chamar a atenção dos leitores ou espectadores para partes importantes em uma apresentação

O PowerPoint fornece muitas opções e ferramentas para animações e efeitos de animação nas categorias **entrada**, **saída**, **ênfase** e **caminhos de movimento**. 

## **Animações no Aspose.Slides**

* O Aspose.Slides fornece as classes e tipos necessários para trabalhar com animações no namespace `Aspose.Slides.Animation`,
* O Aspose.Slides oferece mais de **150 efeitos de animação** sob a enumeração [EffectType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/effecttype). Esses efeitos são essencialmente os mesmos (ou equivalentes) usados no PowerPoint.

## **Aplicar animação a uma caixa de texto**

O Aspose.Slides para PHP via Java permite aplicar animação ao texto em uma forma.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation).
2. Obtenha uma referência ao slide por meio de seu índice.
3. Adicione um retângulo [AutoShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/).
4. Adicione texto ao [TextFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/#getTextFrame) do `AutoShape`.
5. Recupere a sequência principal de efeitos.
6. Adicione um efeito de animação ao [AutoShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/).
7. Use o método `TextAnimation.setBuildType` e o valor da enumeração `BuildType`.
8. Grave a apresentação no disco como um arquivo PPTX.

Este código PHP mostra como aplicar o efeito `Fade` ao AutoShape e definir a animação de texto para o valor *Por parágrafos de 1º nível*:

```php
  # Instancia uma classe de apresentação que representa um arquivo de apresentação.
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    # Adiciona um novo AutoShape com texto
    $autoShape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 100);
    $textFrame = $autoShape->getTextFrame();
    $textFrame->setText("First paragraph \nSecond paragraph \n Third paragraph");
    # Obtém a sequência principal do slide.
    $sequence = $sld->getTimeline()->getMainSequence();
    # Adiciona o efeito de animação Fade à forma
    $effect = $sequence->addEffect($autoShape, EffectType::Fade, EffectSubType::None, EffectTriggerType::OnClick);
    # Anima o texto da forma por parágrafos de nível 1
    $effect->getTextAnimation()->setBuildType(BuildType::ByLevelParagraphs1);
    # Salva o arquivo PPTX no disco
    $pres->save($path . "AnimText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{%  alert color="primary"  %}} 

Além de aplicar animações ao texto, você também pode aplicar animações a um único [Paragraph](https://reference.aspose.com/slides/pt/php-java/aspose.slides/paragraph/). Veja [**Texto Animado**](/slides/pt/php-java/animated-text/).

{{% /alert %}} 

## **Aplicar animação a um PictureFrame**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation).
2. Obtenha a referência de um slide pelo seu índice.
3. Adicione ou obtenha um [PictureFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/pictureframe) no slide.
4. Recupere a sequência principal de efeitos.
5. Adicione um efeito de animação ao [PictureFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/pictureframe).
6. Grave a apresentação no disco como um arquivo PPTX.

Este código PHP mostra como aplicar o efeito `Fly` a um quadro de imagem:

```php
  # Instancia uma classe de apresentação que representa um arquivo de apresentação.
  $pres = new Presentation();
  try {
    # Carrega a imagem a ser adicionada à coleção de imagens da apresentação.
    $picture;
    $image = Images->fromFile("aspose-logo.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Adiciona um quadro de imagem ao slide
    $picFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, $picture);
    # Obtém a sequência principal do slide.
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    # Adiciona o efeito de animação Fly da esquerda ao quadro de imagem
    $effect = $sequence->addEffect($picFrame, EffectType::Fly, EffectSubType::Left, EffectTriggerType::OnClick);
    # Salva o arquivo PPTX no disco
    $pres->save($path . "AnimImage_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Aplicar animação a uma forma**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation).
2. Obtenha a referência de um slide pelo seu índice.
3. Adicione um retângulo [AutoShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/).
4. Adicione uma [AutoShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/) chanfrada (quando este objeto for clicado, a animação será reproduzida).
5. Crie uma sequência de efeitos na forma chanfrada.
6. Crie um `UserPath` personalizado.
7. Adicione comandos para mover para o `UserPath`.
8. Grave a apresentação no disco como um arquivo PPTX.

Este código PHP mostra como aplicar o efeito `PathFootball` (caminho football) a uma forma:

```php
  # Instancia uma classe Presentation que representa um arquivo PPTX.
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    # Cria o efeito PathFootball para a forma existente do zero.
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);
    $ashp->addTextFrame("Animated TextBox");
    # Adiciona o efeito de animação PathFootball
    $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($ashp, EffectType::PathFootball, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # Cria uma espécie de "botão".
    $shapeTrigger = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Bevel, 10, 10, 20, 20);
    # Cria uma sequência de efeitos para este botão.
    $seqInter = $pres->getSlides()->get_Item(0)->getTimeline()->getInteractiveSequences()->add($shapeTrigger);
    # Cria um caminho de usuário personalizado. Nosso objeto será movido somente após o botão ser clicado.
    $fxUserPath = $seqInter->addEffect($ashp, EffectType::PathUser, EffectSubType::None, EffectTriggerType::OnClick);
    # Adiciona comandos de movimento, já que o caminho criado está vazio.
    $motionBhv = $fxUserPath->getBehaviors()->get_Item(0);
    $pts = new Point2DFloat[1];
    $pts[0] = new Point2DFloat(0.076, 0.59);
    $motionBhv->getPath()->add(MotionCommandPathType::LineTo, $pts, MotionPathPointsType::Auto, true);
    $pts[0] = new Point2DFloat(-0.076, -0.59);
    $motionBhv->getPath()->add(MotionCommandPathType::LineTo, $pts, MotionPathPointsType::Auto, false);
    $motionBhv->getPath()->add(MotionCommandPathType::End, null, MotionPathPointsType::Auto, false);
    # Grava o arquivo PPTX no disco
    $pres->save("AnimExample_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Obter os efeitos de animação aplicados a uma forma**

Os exemplos a seguir mostram como usar o método `getEffectsByShape` da classe [Sequence](https://reference.aspose.com/slides/pt/php-java/aspose.slides/sequence/) para obter todos os efeitos de animação aplicados a uma forma.

**Exemplo 1: Obter efeitos de animação aplicados a uma forma em um slide normal**

Anteriormente, você aprendeu como adicionar efeitos de animação a formas em apresentações do PowerPoint. O código de exemplo a seguir mostra como obter os efeitos aplicados à primeira forma no primeiro slide normal da apresentação `AnimExample_out.pptx`.

```php
  $Array = new java_class("java.lang.reflect.Array");
  $presentation = new Presentation("AnimExample_out.pptx");

  try {
    $firstSlide = $presentation->getSlides()->get_Item(0);

    # Obtém a sequência principal de animação do slide.
    $sequence = $firstSlide->getTimeline()->getMainSequence();

    # Obtém a primeira forma no primeiro slide.
    $shape = $firstSlide->getShapes()->get_Item(0);

    # Obtém os efeitos de animação aplicados à forma.
    $shapeEffects = $sequence->getEffectsByShape($shape);

    if (java_values($Array->getLength($shapeEffects)) > 0) {
      echo("The shape " . $shape->getName() . " has " . $Array->getLength($shapeEffects) . " animation effects.");
    }
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

**Exemplo 2: Obter todos os efeitos de animação, incluindo os herdados de placeholders**

Se uma forma em um slide normal possui placeholders que estão no slide de layout e/ou no slide mestre, e efeitos de animação foram adicionados a esses placeholders, então todos os efeitos da forma serão reproduzidos durante a apresentação, incluindo os herdados dos placeholders.

Suponha que temos um arquivo de apresentação PowerPoint `sample.pptx` com um slide contendo apenas uma forma de rodapé com o texto "Made with Aspose.Slides" e o efeito **Random Bars** aplicado à forma.

![Slide shape animation effect](slide-shape-animation.png)

Vamos também supor que o efeito **Split** esteja aplicado ao placeholder de rodapé no slide **layout**.

![Layout shape animation effect](layout-shape-animation.png)

E, finalmente, o efeito **Fly In** esteja aplicado ao placeholder de rodapé no slide **master**.

![Master shape animation effect](master-shape-animation.png)

O código de exemplo a seguir mostra como usar o método `getBasePlaceholder` da classe [Shape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/) para acessar os placeholders de forma e obter os efeitos de animação aplicados à forma de rodapé, incluindo os herdados dos placeholders localizados nos slides de layout e mestre.

```php
$presentation = new Presentation("sample.pptx");

$slide = $presentation->getSlides()->get_Item(0);

// Obtenha os efeitos de animação da forma no slide normal.
$shape = $slide->getShapes()->get_Item(0);
$shapeEffects = $slide->getTimeline()->getMainSequence()->getEffectsByShape($shape);

// Obtenha os efeitos de animação do placeholder no slide de layout.
$layoutShape = $shape->getBasePlaceholder();
$layoutShapeEffects = $slide->getLayoutSlide()->getTimeline()->getMainSequence()->getEffectsByShape($layoutShape);

// Obtenha os efeitos de animação do placeholder no slide mestre.
$masterShape = $layoutShape->getBasePlaceholder();
$masterShapeEffects = $slide->getLayoutSlide()->getMasterSlide()->getTimeline()->getMainSequence()->getEffectsByShape($masterShape);

echo "Main sequence of shape effects:" . PHP_EOL;
printEffects($masterShapeEffects);
printEffects($layoutShapeEffects);
printEffects($shapeEffects);

$presentation->dispose();
```
```php
function printEffects($effects) {
    foreach ($effects as $effect) {
        echo "Type: " . $effect->getType() . ", subtype: " . $effect->getSubtype() . PHP_EOL;
    }
}
```

Saída:
```text
Main sequence of shape effects:
Type: 47, subtype: 2              // Fly, Inferior
Type: 134, subtype: 45            // Split, VerticalIn
Type: 126, subtype: 22            // RandomBars, Horizontal
```

## **Alterar métodos de temporização do efeito de animação**

O Aspose.Slides para PHP via Java permite alterar as propriedades de Timing de um efeito de animação.

Esta é a guia de Temporização de Animação no Microsoft PowerPoint:

![example1_image](shape-animation.png)

Estas são as correspondências entre o Timing do PowerPoint e as propriedades de [Effect Timing](https://reference.aspose.com/slides/pt/php-java/aspose.slides/effect/#getTiming):

- A lista suspensa **Start** do Timing do PowerPoint corresponde ao método [Timing::getTriggerType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/timing/#getTriggerType).
- O **Duration** do Timing do PowerPoint corresponde ao método [Timing::getDuration](https://reference.aspose.com/slides/pt/php-java/aspose.slides/timing/#getDuration). A duração de uma animação (em segundos) é o tempo total que a animação leva para concluir um ciclo.
- O **Delay** do Timing do PowerPoint corresponde ao método [Timing::getTriggerDelayTime](https://reference.aspose.com/slides/pt/php-java/aspose.slides/timing/#getTriggerDelayTime).

É assim que você altera as propriedades de Temporização do Efeito:

1. [Apply](#apply-animation-to-shape) ou obtenha o efeito de animação.
2. Defina novos valores necessários usando o método [Effect::getTiming](https://reference.aspose.com/slides/pt/php-java/aspose.slides/effect/#getTiming).
3. Salve o arquivo PPTX modificado.

Este código PHP demonstra a operação:

```php
  # Instancia uma classe de apresentação que representa um arquivo de apresentação.
  $pres = new Presentation("AnimExample_out.pptx");
  try {
    # Obtém a sequência principal do slide.
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    # Obtém o primeiro efeito da sequência principal.
    $effect = $sequence->get_Item(0);
    # Altera o TriggerType do efeito para iniciar ao clicar
    $effect->getTiming()->setTriggerType(EffectTriggerType::OnClick);
    # Altera a Duração do efeito
    $effect->getTiming()->setDuration(3.0);
    # Altera o TriggerDelayTime do efeito
    $effect->getTiming()->setTriggerDelayTime(0.5);
    # Salva o arquivo PPTX no disco
    $pres->save("AnimExample_changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Som do efeito de animação**

Aspose.Slides fornece estes métodos para permitir que você trabalhe com sons em efeitos de animação: 

- [setSound(IAudio value)](https://reference.aspose.com/slides/pt/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/pt/php-java/aspose.slides/effect/#setStopPreviousSound-boolean-)

### **Adicionar som a um efeito de animação**

Este código PHP mostra como adicionar um som ao efeito de animação e pará‑lo quando o próximo efeito iniciar:

```php
  $pres = new Presentation("AnimExample_out.pptx");
  try {
    # Adiciona áudio à coleção de áudio da apresentação
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "sampleaudio.wav"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $effectSound = $pres->getAudios()->addAudio($bytes);

    $firstSlide = $pres->getSlides()->get_Item(0);
    # Obtém a sequência principal do slide.
    $sequence = $firstSlide->getTimeline()->getMainSequence();
    # Obtém o primeiro efeito da sequência principal
    $firstEffect = $sequence->get_Item(0);
    # Verifica se o efeito tem "No Sound"
    if (java_is_null(!$firstEffect->getStopPreviousSound() && $firstEffect->getSound())) {
      # Adiciona som ao primeiro efeito
      $firstEffect->setSound($effectSound);
    }
    # Obtém a primeira sequência interativa do slide.
    $interactiveSequence = $firstSlide->getTimeline()->getInteractiveSequences()->get_Item(0);
    # Define a flag "Stop previous sound" do efeito
    $interactiveSequence->get_Item(0)->setStopPreviousSound(true);
    # Grava o arquivo PPTX no disco
    $pres->save("AnimExample_Sound_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Extrair som de um efeito de animação**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/).
2. Obtenha a referência de um slide pelo seu índice. 
3. Recupere a sequência principal de efeitos. 
4. Extraia o [setSound(IAudio value)](https://reference.aspose.com/slides/pt/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) incorporado a cada efeito de animação.

Este código PHP mostra como extrair o som incorporado em um efeito de animação:

```php
  # Instancia uma classe de apresentação que representa um arquivo de apresentação.
  $presentation = new Presentation("EffectSound.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # Obtém a sequência principal do slide.
    $sequence = $slide->getTimeline()->getMainSequence();
    foreach($sequence as $effect) {
      if (java_is_null($effect->getSound())) {
        continue;
      }
      # Extrai o som do efeito em array de bytes
      $audio = $effect->getSound()->getBinaryData();
    }
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Após a animação**

O Aspose.Slides para PHP via Java permite mudar a propriedade After animation de um efeito de animação.

Esta é a guia de Efeito de Animação e menu expandido no Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

A lista suspensa **After animation** do PowerPoint corresponde a esses métodos: 

- O método [setAfterAnimationType(int value)](https://reference.aspose.com/slides/pt/php-java/aspose.slides/effect/#setAfterAnimationType) que descreve o tipo de After animation:
  * PowerPoint **More Colors** corresponde ao tipo [AfterAnimationType::Color](https://reference.aspose.com/slides/pt/php-java/aspose.slides/afteranimationtype/#Color);
  * O item **Don't Dim** do PowerPoint corresponde ao tipo [AfterAnimationType::DoNotDim](https://reference.aspose.com/slides/pt/php-java/aspose.slides/afteranimationtype/#DoNotDim) (tipo padrão de after animation);
  * O item **Hide After Animation** do PowerPoint corresponde ao tipo [AfterAnimationType::HideAfterAnimation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/afteranimationtype/#HideAfterAnimation);
  * O item **Hide on Next Mouse Click** do PowerPoint corresponde ao tipo [AfterAnimationType::HideOnNextMouseClick](https://reference.aspose.com/slides/pt/php-java/aspose.slides/afteranimationtype/#HideOnNextMouseClick);
- O método [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/pt/php-java/aspose.slides/effect/#setAfterAnimationColor) que define um formato de cor after animation. Este método funciona em conjunto com o tipo [AfterAnimationType::Color](https://reference.aspose.com/slides/pt/php-java/aspose.slides/afteranimationtype/#Color). Se você mudar o tipo para outro, a cor after animation será limpa.

Este código PHP mostra como mudar um efeito de after animation:

```php
  # Instancia uma classe de apresentação que representa um arquivo de apresentação
  $pres = new Presentation("AnimImage_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # Obtém o primeiro efeito da sequência principal
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # Altera o tipo de after animation para Cor
    $firstEffect->setAfterAnimationType(AfterAnimationType::Color);
    # Define a cor de escurecimento da animação posterior
    $firstEffect->getAfterAnimationColor()->setColor(java("java.awt.Color")->BLUE);
    # Grava o arquivo PPTX no disco
    $pres->save("AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Animar texto**

Aspose.Slides fornece estes métodos para permitir que você trabalhe com o bloco *Animate text* de um efeito de animação:

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/pt/php-java/aspose.slides/effect/#setAnimateTextType) que descreve o tipo de animação de texto do efeito. O texto da forma pode ser animado:
  - Tudo de uma vez ([AnimateTextType::AllAtOnce](https://reference.aspose.com/slides/pt/php-java/aspose.slides/animatetexttype/#AllAtOnce) tipo)
  - Por palavra ([AnimateTextType::ByWord](https://reference.aspose.com/slides/pt/php-java/aspose.slides/animatetexttype/#ByWord) tipo)
  - Por letra ([AnimateTextType::ByLetter](https://reference.aspose.com/slides/pt/php-java/aspose.slides/animatetexttype/#ByLetter) tipo)
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/pt/php-java/aspose.slides/effect/#setDelayBetweenTextParts) define um atraso entre as partes de texto animadas (palavras ou letras). Um valor positivo especifica a porcentagem da duração do efeito. Um valor negativo especifica o atraso em segundos.

É assim que você pode mudar as propriedades *Animate text* do Efeito:

1. [Apply](#apply-animation-to-shape) ou obtenha o efeito de animação.
2. Use o método [setBuildType(int value)](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textanimation/#setBuildType) e o valor [BuildType::AsOneObject](https://reference.aspose.com/slides/pt/php-java/aspose.slides/buildtype/#AsOneObject) para desativar o modo de animação *By Paragraphs*.
3. Defina novos valores usando os métodos [setAnimateTextType(int value)](https://reference.aspose.com/slides/pt/php-java/aspose.slides/effect/#setAnimateTextType) e [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/pt/php-java/aspose.slides/effect/#setDelayBetweenTextParts).
4. Salve o arquivo PPTX modificado.

Este código PHP demonstra a operação:

```php
  # Instancia uma classe de apresentação que representa um arquivo de apresentação.
  $pres = new Presentation("AnimTextBox_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # Obtém o primeiro efeito da sequência principal
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # Altera o tipo de animação de texto do efeito para "As One Object"
    $firstEffect->getTextAnimation()->setBuildType(BuildType::AsOneObject);
    # Altera o tipo de animação de texto do efeito para "By word"
    $firstEffect->setAnimateTextType(AnimateTextType::ByWord);
    # Define o atraso entre palavras para 20% da duração do efeito
    $firstEffect->setDelayBetweenTextParts(20.0);
    # Grava o arquivo PPTX no disco
    $pres->save("AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Perguntas frequentes**

**Como posso garantir que as animações sejam preservadas ao publicar a apresentação na web?**

[Export to HTML5](/slides/pt/php-java/export-to-html5/) e habilite as [opções](https://reference.aspose.com/slides/pt/php-java/aspose.slides/html5options/) responsáveis por animações de [shape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/html5options/setanimateshapes/) e de [transition](https://reference.aspose.com/slides/pt/php-java/aspose.slides/html5options/setanimatetransitions/). HTML simples não reproduz animações de slides, enquanto HTML5 reproduz.

**Como a alteração da ordem Z (ordem de camada) das formas afeta a animação?**

A ordem de animação e a ordem de desenho são independentes: um efeito controla o tempo e o tipo de aparição/desaparecimento, enquanto a [z-order](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/getzorderposition/) determina o que cobre o quê. O resultado visível é definido pela combinação de ambos. (Este é o comportamento geral do PowerPoint; o modelo de efeitos‑e‑formas do Aspose.Slides segue a mesma lógica.)

**Existem limitações ao converter animações em vídeo para certos efeitos?**

Em geral, [as animações são suportadas](/slides/pt/php-java/convert-powerpoint-to-video/), mas casos raros ou efeitos específicos podem ser renderizados de forma diferente. Recomenda‑se testar com os efeitos que você usa e com a versão da biblioteca.