---
title: Aplicar animações de formas em apresentações usando JavaScript
linktitle: Animação de Forma
type: docs
weight: 60
url: /pt/nodejs-java/shape-animation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Descubra como criar e personalizar animações de formas em apresentações PowerPoint com JavaScript e Aspose.Slides para Node.js via Java. Destaque-se!"
---
## **Introdução**

Animações são efeitos visuais que podem ser aplicados a textos, imagens, formas ou [gráficos](/slides/pt/nodejs-java/animated-charts/). Elas dão vida a apresentações ou seus componentes.

## **Por que usar animações em apresentações?**

* controlar o fluxo de informações
* enfatizar pontos importantes
* aumentar o interesse ou a participação do seu público
* tornar o conteúdo mais fácil de ler, assimilar ou processar
* chamar a atenção de seus leitores ou espectadores para partes importantes em uma apresentação

O PowerPoint oferece muitas opções e ferramentas para animações e efeitos de animação nas categorias de **entrada**, **saída**, **ênfase** e **caminhos de movimento**. 

## **Animações no Aspose.Slides**

* Aspose.Slides fornece as classes e tipos que você precisa para trabalhar com animações no namespace `Aspose.Slides.Animation`,
* Aspose.Slides oferece mais de **150 efeitos de animação** na enumeração [EffectType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/effecttype). Esses efeitos são essencialmente os mesmos (ou equivalentes) usados no PowerPoint.

## **Aplicar animação a TextBox**

Aspose.Slides para Node.js via Java permite que você aplique animação ao texto em uma forma.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
2. Obtenha uma referência ao slide através de seu índice.
3. Adicione um `rectangle` [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape).
4. Adicione texto usando [AutoShape.addTextFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-).
5. Obtenha a sequência principal de efeitos.
6. Adicione um efeito de animação ao [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape).
7. Chame o método `TextAnimation.setBuildType` com o valor da enumeração `BuildType`.
8. Grave a apresentação no disco como um arquivo PPTX.

Este código Javascript mostra como aplicar o efeito `Fade` ao AutoShape e definir a animação de texto para o valor *By 1st Level Paragraphs*:

```javascript
// Instancia uma classe de apresentação que representa um arquivo de apresentação.
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    // Adiciona um novo AutoShape com texto
    var autoShape = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 100);
    var textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");
    // Obtém a sequência principal do slide.
    var sequence = sld.getTimeline().getMainSequence();
    // Adiciona o efeito de animação Fade à forma
    var effect = sequence.addEffect(autoShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    // Anima o texto da forma por parágrafos de primeiro nível
    effect.getTextAnimation().setBuildType(aspose.slides.BuildType.ByLevelParagraphs1);
    // Salva o arquivo PPTX no disco
    pres.save(path + "AnimText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{%  alert color="primary"  %}} 

Além de aplicar animações ao texto, você também pode aplicar animações a um único [Paragraph](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraph). Consulte [**Animated Text**](/slides/pt/nodejs-java/animated-text/).

{{% /alert %}} 

## **Aplicar animação a PictureFrame**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
2. Obtenha a referência de um slide através de seu índice.
3. Adicione ou obtenha um [PictureFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/pictureframe) no slide.
4. Obtenha a sequência principal de efeitos.
5. Adicione um efeito de animação ao [PictureFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/pictureframe).
6. Grave a apresentação no disco como um arquivo PPTX.

Este código Javascript mostra como aplicar o efeito `Fly` a um quadro de imagem:

```javascript
// Instancia uma classe de apresentação que representa um arquivo de apresentação.
var pres = new aspose.slides.Presentation();
try {
    // Carrega a imagem a ser adicionada à coleção de imagens da apresentação
    var picture;
    var image = aspose.slides.Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Adiciona um quadro de imagem ao slide
    var picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 100, picture);
    // Obtém a sequência principal do slide.
    var sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    // Adiciona o efeito de animação Fly de esquerda para o quadro de imagem
    var effect = sequence.addEffect(picFrame, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.Left, aspose.slides.EffectTriggerType.OnClick);
    // Salva o arquivo PPTX no disco
    pres.save(path + "AnimImage_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Aplicar animação a Shape**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
2. Obtenha a referência de um slide através de seu índice.
3. Adicione um `rectangle` [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape).
4. Adicione um `Bevel` [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape) (quando este objeto for clicado, a animação será reproduzida).
5. Crie uma sequência de efeitos na forma bevel.
6. Crie um `UserPath` personalizado.
7. Adicione comandos para mover ao `UserPath`.
8. Grave a apresentação no disco como um arquivo PPTX.

Este código Javascript mostra como aplicar o efeito `PathFootball` (caminho futebol) a uma forma:

```javascript
// Instancia uma classe Presentation que representa um arquivo PPTX.
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    // Cria o efeito PathFootball para a forma existente do zero.
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");
    // Adiciona o efeito de animação PathFootBall
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, aspose.slides.EffectType.PathFootball, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    // Cria uma espécie de "botão".
    var shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Bevel, 10, 10, 20, 20);
    // Cria uma sequência de efeitos para este botão.
    var seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);
    // Cria um caminho de usuário personalizado. Nosso objeto será movido somente após o botão ser clicado.
    var fxUserPath = seqInter.addEffect(ashp, aspose.slides.EffectType.PathUser, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    // Adiciona comandos de movimentação já que o caminho criado está vazio.
    var motionBhv = fxUserPath.getBehaviors().get_Item(0);
    var pts = java.newArray("com.aspose.slides.Point2DFloat", [java.newInstanceSync("com.aspose.slides.Point2DFloat", 0.076, 0.59)]);
    motionBhv.getPath().add(aspose.slides.MotionCommandPathType.LineTo, pts, aspose.slides.MotionPathPointsType.Auto, true);
    pts[0] = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(-0.076), java.newFloat(-0.59));
    motionBhv.getPath().add(aspose.slides.MotionCommandPathType.LineTo, pts, aspose.slides.MotionPathPointsType.Auto, false);
    motionBhv.getPath().add(aspose.slides.MotionCommandPathType.End, null, aspose.slides.MotionPathPointsType.Auto, false);
    // Grava o arquivo PPTX no disco
    pres.save("AnimExample_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Obter os efeitos de animação aplicados à Shape**

Os exemplos a seguir mostram como usar o método `getEffectsByShape` da classe [Sequence](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/sequence/) para obter todos os efeitos de animação aplicados a uma forma.

**Exemplo 1: Obter efeitos de animação aplicados a uma forma em um slide normal**

Anteriormente, você aprendeu como adicionar efeitos de animação a formas em apresentações do PowerPoint. O código de exemplo a seguir mostra como obter os efeitos aplicados à primeira forma no primeiro slide normal da apresentação `AnimExample_out.pptx`.

```javascript
var presentation = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    var firstSlide = presentation.getSlides().get_Item(0);

    // Obtém a sequência principal de animação do slide.
    var sequence = firstSlide.getTimeline().getMainSequence();

    // Obtém a primeira forma no primeiro slide.
    var shape = firstSlide.getShapes().get_Item(0);

    // Obtém os efeitos de animação aplicados à forma.
    var shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0) {
        console.log("The shape", shape.getName(), "has", shapeEffects.length, "animation effects.");
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

**Exemplo 2: Obter todos os efeitos de animação, incluindo os herdados de placeholders**

Se uma forma em um slide normal contém espaços reservados que estão no slide de layout e/ou no slide mestre, e efeitos de animação foram adicionados a esses espaços reservados, então todos os efeitos da forma serão reproduzidos durante a apresentação, incluindo os herdados dos espaços reservados.

Suponha que temos um arquivo de apresentação PowerPoint `sample.pptx` com um slide contendo apenas uma forma de rodapé com o texto "Made with Aspose.Slides" e o efeito **Random Bars** está aplicado à forma.

![Slide shape animation effect](slide-shape-animation.png)

Vamos também supor que o efeito **Split** está aplicado ao espaço reservado de rodapé no slide de **layout**.

![Layout shape animation effect](layout-shape-animation.png)

E, finalmente, o efeito **Fly In** está aplicado ao espaço reservado de rodapé no slide **master**.

![Master shape animation effect](master-shape-animation.png)

O código de exemplo a seguir mostra como usar o método `getBasePlaceholder` da classe [Shape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/) para acessar os espaços reservados de forma e obter os efeitos de animação aplicados à forma de rodapé, incluindo os herdados dos espaços reservados localizados nos slides de layout e mestre.

```js
var presentation = new aspose.slides.Presentation("sample.pptx");

var slide = presentation.getSlides().get_Item(0);

// Obtém os efeitos de animação da forma no slide normal.
var shape = slide.getShapes().get_Item(0);
var shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// Obtém os efeitos de animação do placeholder no slide de layout.
var layoutShape = shape.getBasePlaceholder();
var layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// Obtém os efeitos de animação do placeholder no slide mestre.
var masterShape = layoutShape.getBasePlaceholder();
var masterShapeEffects = slide.getLayoutSlide().getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(masterShape);

console.log("Main sequence of shape effects:");
printEffects(masterShapeEffects);
printEffects(layoutShapeEffects);
printEffects(shapeEffects);

presentation.dispose();
```
```js
function printEffects(effects) {
    for (const effect of effects) {
        console.log("Type:", effect.getType() + ", subtype:", effect.getSubtype());
    }
}
```

```text
Main sequence of shape effects:
Type: 47, subtype: 2              // Voo, Inferior
Type: 134, subtype: 45            // Dividir, VerticalIn
Type: 126, subtype: 22            // Barras aleatórias, Horizontal
```

## **Alterar propriedades de temporização do efeito de animação**

Aspose.Slides para Node.js via Java permite que você altere as propriedades de temporização de um efeito de animação.

Este é o painel de temporização de animação no Microsoft PowerPoint:

![example1_image](shape-animation.png)

Estas são as correspondências entre a temporização do PowerPoint e as propriedades [Effect.Timing](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Effect#getTiming--):

- O menu suspenso **Start** da temporização do PowerPoint corresponde à propriedade [Effect.Timing.TriggerType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Timing#getTriggerType--).
- O **Duration** da temporização do PowerPoint corresponde à propriedade [Effect.Timing.Duration](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Timing#getDuration--). A duração de uma animação (em segundos) é o tempo total que leva para a animação concluir um ciclo.
- O **Delay** da temporização do PowerPoint corresponde à propriedade [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Timing#getTriggerDelayTime--).

É assim que você altera as propriedades de temporização do Effect:

1. [Aplicar](#apply-animation-to-shape) ou obter o efeito de animação.
2. Defina novos valores para as propriedades [Effect.Timing](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Effect#getTiming--) necessárias.
3. Salve o arquivo PPTX modificado.

Este código Javascript demonstra a operação:

```javascript
// Instancia uma classe de apresentação que representa um arquivo de apresentação.
var pres = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    // Obtém a sequência principal do slide.
    var sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    // Obtém o primeiro efeito da sequência principal.
    var effect = sequence.get_Item(0);
    // Altera o TriggerType do efeito para iniciar ao clicar
    effect.getTiming().setTriggerType(aspose.slides.EffectTriggerType.OnClick);
    // Altera a Duração do efeito
    effect.getTiming().setDuration(3.0);
    // Altera o TriggerDelayTime do efeito
    effect.getTiming().setTriggerDelayTime(0.5);
    // Salva o arquivo PPTX no disco
    pres.save("AnimExample_changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Som do efeito de animação**

Aspose.Slides fornece estas propriedades para permitir trabalhar com sons em efeitos de animação: 

- [setSound(IAudio value)](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/effect/#setSound-aspose.slides.IAudio-)
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/effect/#setStopPreviousSound-boolean-)

### **Adicionar som ao efeito de animação**

Este código Javascript mostra como adicionar um som ao efeito de animação e pará-lo quando o próximo efeito começar:

```javascript
var pres = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    // Adiciona áudio à coleção de áudio da apresentação
    var effectSound = pres.getAudios().addAudio(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "sampleaudio.wav")));
    var firstSlide = pres.getSlides().get_Item(0);
    // Obtém a sequência principal do slide.
    var sequence = firstSlide.getTimeline().getMainSequence();
    // Obtém o primeiro efeito da sequência principal
    var firstEffect = sequence.get_Item(0);
    // Verifica se o efeito está sem som
    if ((!firstEffect.getStopPreviousSound()) && (firstEffect.getSound() == null)) {
        // Adiciona som ao primeiro efeito
        firstEffect.setSound(effectSound);
    }
    // Obtém a primeira sequência interativa do slide.
    var interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);
    // Define a flag "Stop previous sound" do efeito
    interactiveSequence.get_Item(0).setStopPreviousSound(true);
    // Grava o arquivo PPTX no disco
    pres.save("AnimExample_Sound_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Extrair som do efeito de animação**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/).
2. Obtenha a referência de um slide através de seu índice. 
3. Obtenha a sequência principal de efeitos. 
4. Extraia o [setSound(IAudio value)](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/effect/#setSound-aspose.slides.IAudio-) incorporado a cada efeito de animação.

Este código Javascript mostra como extrair o som incorporado em um efeito de animação:

```javascript
// Instancia uma classe de apresentação que representa um arquivo de apresentação.
var presentation = new aspose.slides.Presentation("EffectSound.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    // Obtém a sequência principal do slide.
    var sequence = slide.getTimeline().getMainSequence();
    for (var i = 0; i < sequence.getCount(); i++) {
        var effect = sequence.get_Item(i);
        if (effect.getSound() == null) {
            continue;
        }
        // Extrai o som do efeito em um array de bytes
        var audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Após a animação**

Aspose.Slides para Node.js via Java permite que você altere a propriedade After animation de um efeito de animação.

Este é o painel de Efeito de Animação e o menu estendido no Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

A lista suspensa **After animation** do efeito PowerPoint corresponde a estas propriedades:

- O método [setAfterAnimationType(int value)](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/effect/#setAfterAnimationType-int-) que descreve o tipo After animation;
  * O **More Colors** do PowerPoint corresponde ao tipo [AfterAnimationType.Color](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/afteranimationtype/#Color);
  * O item **Don't Dim** do PowerPoint corresponde ao tipo [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/afteranimationtype/#DoNotDim) (tipo padrão de After animation);
  * O item **Hide After Animation** do PowerPoint corresponde ao tipo [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/afteranimationtype/#HideAfterAnimation);
  * O item **Hide on Next Mouse Click** do PowerPoint corresponde ao tipo [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/afteranimationtype/#HideOnNextMouseClick);
- O método [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/effect/#setAfterAnimationColor-aspose.slides.IColorFormat-) que define um formato de cor de after animation. Este método funciona em conjunto com o tipo [AfterAnimationType.Color](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/afteranimationtype/#Color). Se você mudar o tipo para outro, a cor after animation será limpa.

Este código Javascript mostra como alterar um efeito de after animation:

```javascript
// Instancia uma classe de apresentação que representa um arquivo de apresentação
var pres = new aspose.slides.Presentation("AnimImage_out.pptx");
try {
    var firstSlide = pres.getSlides().get_Item(0);
    // Obtém o primeiro efeito da sequência principal
    var firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);
    // Altera o tipo de after animation para Cor
    firstEffect.setAfterAnimationType(aspose.slides.AfterAnimationType.Color);
    // Define a cor de after animation
    firstEffect.getAfterAnimationColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    // Grava o arquivo PPTX no disco
    pres.save("AnimImage_AfterAnimation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Animar texto**

Aspose.Slides fornece estas propriedades para permitir trabalhar com o bloco *Animate text* de um efeito de animação:

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/effect/#setAnimateTextType-int-) que descreve o tipo de animação de texto do efeito. O texto da forma pode ser animado:
  * Tudo de uma vez ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/animatetexttype/#AllAtOnce) tipo)
  * Por palavra ([AnimateTextType.ByWord](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/animatetexttype/#ByWord) tipo)
  * Por letra ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/animatetexttype/#ByLetter) tipo)
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/effect/#setDelayBetweenTextParts-float-) define um atraso entre as partes de texto animadas (palavras ou letras). Um valor positivo especifica a porcentagem da duração do efeito. Um valor negativo especifica o atraso em segundos.

É assim que você pode alterar as propriedades Animate text do Effect:

1. [Aplicar](#apply-animation-to-shape) ou obter o efeito de animação.
2. Defina o método [setBuildType(int value)](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textanimation/#setBuildType-int-) para o valor [BuildType.AsOneObject](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/buildtype/#AsOneObject) para desativar o modo de animação *By Paragraphs*.
3. Defina novos valores para as propriedades [setAnimateTextType(int value)](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/effect/#setAnimateTextType-int-) e [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/effect/#setDelayBetweenTextParts-float-).
4. Salve o arquivo PPTX modificado.

Este código Javascript demonstra a operação:

```javascript
// Instancia uma classe de apresentação que representa um arquivo de apresentação.
var pres = new aspose.slides.Presentation("AnimTextBox_out.pptx");
try {
    var firstSlide = pres.getSlides().get_Item(0);
    // Obtém o primeiro efeito da sequência principal
    var firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);
    // Altera o tipo de animação de texto do efeito para "Como um objeto único"
    firstEffect.getTextAnimation().setBuildType(aspose.slides.BuildType.AsOneObject);
    // Altera o tipo de animação de texto do efeito para "Por palavra"
    firstEffect.setAnimateTextType(aspose.slides.AnimateTextType.ByWord);
    // Define o atraso entre palavras para 20% da duração do efeito
    firstEffect.setDelayBetweenTextParts(20.0);
    // Grava o arquivo PPTX no disco
    pres.save("AnimTextBox_AnimateText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Como posso garantir que as animações sejam preservadas ao publicar a apresentação na web?**

[Export to HTML5](/slides/pt/nodejs-java/export-to-html5/) e habilite as [options](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/html5options/) responsáveis por animações de [shape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/html5options/setanimateshapes/) e de [transition](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/html5options/setanimatetransitions/). HTML simples não reproduz animações de slides, enquanto HTML5 reproduz.

**Como a alteração da ordem Z (ordem das camadas) das formas afeta a animação?**

A ordem de animação e a ordem de desenho são independentes: um efeito controla o tempo e o tipo de aparição/desaparecimento, enquanto a [z-order](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/getzorderposition/) determina o que cobre o quê. O resultado visível é definido pela combinação das duas. (Esse é o comportamento geral do PowerPoint; o modelo de efeitos e formas do Aspose.Slides segue a mesma lógica.)

**Existem limitações ao converter animações para vídeo para certos efeitos?**

Em geral, [as animações são suportadas](/slides/pt/nodejs-java/convert-powerpoint-to-video/), mas casos raros ou efeitos específicos podem ser renderizados de forma diferente. Recomenda‑se testar com os efeitos que você usa e com a versão da biblioteca.