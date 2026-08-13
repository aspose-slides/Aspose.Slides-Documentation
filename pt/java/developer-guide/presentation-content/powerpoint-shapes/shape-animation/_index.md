---
title: Aplicar Animações de Forma em Apresentações Usando Java
linktitle: Animação de Forma
type: docs
weight: 60
url: /pt/java/shape-animation/
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
- Java
- Aspose.Slides
description: "Descubra como criar e personalizar animações de forma em apresentações do PowerPoint com Aspose.Slides for Java. Destaque-se!"
---
## **Introdução**

Animações são efeitos visuais que podem ser aplicados a textos, imagens, formas ou [gráficos](https://docs.aspose.com/slides/pt/java/animated-charts/). Elas dão vida às apresentações ou aos seus componentes. 

## **Por que usar animações em apresentações?**

Usando animações, você pode 

* controlar o fluxo de informações
* enfatizar pontos importantes
* aumentar o interesse ou a participação do seu público
* tornar o conteúdo mais fácil de ler, assimilar ou processar
* chamar a atenção dos leitores ou espectadores para partes importantes em uma apresentação

O PowerPoint oferece muitas opções e ferramentas para animações e efeitos de animação nas categorias de **entrada**, **saída**, **ênfase** e **caminhos de movimento**. 

## **Animações no Aspose.Slides**

* Aspose.Slides fornece as classes e tipos que você precisa para trabalhar com animações no namespace `Aspose.Slides.Animation`,
* Aspose.Slides fornece mais de **150 efeitos de animação** sob a enumeração [EffectType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/effecttype). Esses efeitos são essencialmente os mesmos (ou equivalentes) usados no PowerPoint.

## **Aplicar animação a uma TextBox**

Aspose.Slides for Java permite aplicar animação ao texto em uma forma. 

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation).
2. Obtenha uma referência de slide por meio do seu índice.
3. Adicione um `rectangle` [IAutoShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iautoshape). 
4. Adicione texto ao [IAutoShape.TextFrame](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-).
5. Obtenha a sequência principal de efeitos.
6. Adicione um efeito de animação ao [IAutoShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iautoshape). 
7. Defina a propriedade `TextAnimation.BuildType` para o valor da enumeração `BuildType`.
8. Grave a apresentação no disco como um arquivo PPTX.

Este código Java mostra como aplicar o efeito `Fade` ao AutoShape e definir a animação de texto para o valor *By 1st Level Paragraphs*:

```java
import com.aspose.slides.*;

// Instancia uma classe de apresentação que representa um arquivo de apresentação.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Adiciona nova AutoShape com texto
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");

    // Obtém a sequência principal do slide.
    ISequence sequence = sld.getTimeline().getMainSequence();

    // Adiciona efeito de animação Fade à forma
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Anima o texto da forma por parágrafos de primeiro nível
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // Salva o arquivo PPTX no disco
    pres.save("AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert color="info"  %}} 

Além de aplicar animações ao texto, você também pode aplicar animações a um único [Paragraph](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iparagraph). Veja [**Texto Animado**](/slides/pt/java/animated-text/).

{{% /alert %}} 

## **Aplicar animação a um PictureFrame**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation).
2. Obtenha a referência de um slide por meio do seu índice.
3. Adicione ou obtenha um [PictureFrame](https://reference.aspose.com/slides/pt/java/com.aspose.slides/pictureframe) no slide. 
4. Obtenha a sequência principal de efeitos.
5. Adicione um efeito de animação ao [PictureFrame](https://reference.aspose.com/slides/pt/java/com.aspose.slides/pictureframe).
6. Grave a apresentação no disco como um arquivo PPTX.

Este código Java mostra como aplicar o efeito `Fly` a um quadro de imagem:

```java
import com.aspose.slides.*;

// Instancia uma classe de apresentação que representa um arquivo de apresentação.
Presentation pres = new Presentation();
try {
    // Carrega a imagem a ser adicionada na coleção de imagens da apresentação
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Adiciona quadro de imagem ao slide
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, picture);

    // Obtém a sequência principal do slide.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Adiciona efeito de animação Fly da esquerda ao quadro de imagem
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Salva o arquivo PPTX no disco
    pres.save("AnimImage_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Aplicar animação a uma Forma**

1. Crie uma instância da [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation) class.
2. Obtenha a referência de um slide por meio do seu índice.
3. Adicione um `rectangle` [IAutoShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iautoshape). 
4. Adicione um `Bevel` [IAutoShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iautoshape) (quando este objeto for clicado, a animação será reproduzida).
5. Crie uma sequência de efeitos na forma bevel.
6. Crie um `UserPath` personalizado.
7. Adicione comandos para mover ao `UserPath`.
8. Grave a apresentação no disco como um arquivo PPTX.

Este código Java mostra como aplicar o efeito `PathFootball` (caminho futebol) a uma forma:

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

// Instancia uma classe Presentation que representa um arquivo PPTX.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Cria o efeito PathFootball para a forma existente do zero.
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");

    // Adiciona o efeito de animação PathFootBall
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Cria algum tipo de "botão".
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Cria uma sequência de efeitos para este botão.
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // Cria um caminho de usuário personalizado. Nosso objeto será movido somente após o botão ser clicado.
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

     // Adiciona comandos de movimentação já que o caminho criado está vazio.
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.getBehaviors().get_Item(0));

    Point2D.Float[] pts = new Point2D.Float[1];
    pts[0] = new Point2D.Float(0.076f, 0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new Point2D.Float(-0.076f, -0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.getPath().add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

     // Grava o arquivo PPTX no disco
    pres.save("AnimExample_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Obter os efeitos de animação aplicados a uma forma**

Os exemplos a seguir mostram como usar o método `getEffectsByShape` da interface [ISequence](https://reference.aspose.com/slides/pt/java/com.aspose.slides/isequence/) para obter todos os efeitos de animação aplicados a uma forma.

**Exemplo 1: Obter efeitos de animação aplicados a uma forma em um slide normal**

Anteriormente, você aprendeu como adicionar efeitos de animação a formas em apresentações do PowerPoint. O código de exemplo a seguir mostra como obter os efeitos aplicados à primeira forma no primeiro slide normal da apresentação `AnimExample_out.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Obtém a sequência principal de animação do slide.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Obtém a primeira forma no primeiro slide.
    IShape shape = firstSlide.getShapes().get_Item(0);

    // Obtém os efeitos de animação aplicados à forma.
    IEffect[] shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0)
        System.out.println("The shape " + shape.getName() + " has " + shapeEffects.length + " animation effects.");
} finally {
    if (presentation != null) presentation.dispose();
}
```

**Exemplo 2: Obter todos os efeitos de animação, incluindo os herdados de placeholders**

Se uma forma em um slide normal possui placeholders que estão no slide de layout e/ou slide mestre, e efeitos de animação foram adicionados a esses placeholders, então todos os efeitos da forma serão reproduzidos durante a apresentação, incluindo os herdados dos placeholders.

Suponha que tenhamos um arquivo de apresentação PowerPoint `sample.pptx` com um slide contendo apenas uma forma de rodapé com o texto "Made with Aspose.Slides" e o efeito **Random Bars** aplicado à forma.

![Efeito de animação da forma do slide](slide-shape-animation.png)

Vamos também supor que o efeito **Split** seja aplicado ao placeholder de rodapé no slide de **layout**.

![Efeito de animação da forma de layout](layout-shape-animation.png)

E, finalmente, o efeito **Fly In** é aplicado ao placeholder de rodapé no slide **master**.

![Efeito de animação da forma mestre](master-shape-animation.png)

O código de exemplo a seguir mostra como usar o método `getBasePlaceholder` da interface [IShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ishape/) para acessar os placeholders da forma e obter os efeitos de animação aplicados à forma de rodapé, incluindo os herdados dos placeholders localizados nos slides de layout e mestre.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

// Get animation effects of the shape on the normal slide.
IShape shape = slide.getShapes().get_Item(0);
IEffect[] shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// Get animation effects of the placeholder on the layout slide.
IShape layoutShape = shape.getBasePlaceholder();
IEffect[] layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// Get animation effects of the placeholder on the master slide.
IShape masterShape = layoutShape.getBasePlaceholder();
IEffect[] masterShapeEffects = slide.getLayoutSlide().getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(masterShape);

System.out.println("Main sequence of shape effects:");
for (IEffect[] effects : new IEffect[][] { masterShapeEffects, layoutShapeEffects, shapeEffects }) {
    for (IEffect effect : effects) {
        String typeName = EffectType.getName(EffectType.class, effect.getType());
        String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());

        System.out.println(typeName + " " + subtypeName);
    }
}

presentation.dispose();
```
```java
import com.aspose.slides.*;

static void printEffects(IEffect[] effects)
{
    for (IEffect effect : effects)
    {
        String typeName = EffectType.getName(EffectType.class, effect.getType());
        String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());

        System.out.println(typeName + " " + subtypeName);
    }
}
```

Output:
```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```

## **Alterar propriedades de tempo do efeito de animação**

Aspose.Slides for Java permite alterar as propriedades de temporização de um efeito de animação.

Esta é a janela de temporização de animação no Microsoft PowerPoint:

![Painel de temporização de animação](shape-animation.png)

Estas são as correspondências entre a temporização do PowerPoint e as propriedades [Effect.Timing](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IEffect#getTiming--):

- A lista suspensa **Start** de temporização do PowerPoint corresponde à propriedade [Effect.Timing.TriggerType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ITiming#getTriggerType--). 
- **Duration** da temporização do PowerPoint corresponde à propriedade [Effect.Timing.Duration](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ITiming#getDuration--). A duração de uma animação (em segundos) é o tempo total que a animação leva para completar um ciclo. 
- **Delay** da temporização do PowerPoint corresponde à propriedade [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ITiming#getTriggerDelayTime--). 

É assim que você altera as propriedades de temporização do efeito:

1. [Apply](#apply-animation-to-shape) ou obtenha o efeito de animação.
2. Defina novos valores para as propriedades [Effect.Timing](https://reference.aspose.com/slides/pt/java/com.aspose.slides/IEffect#getTiming--) conforme necessário. 
3. Salve o arquivo PPTX modificado.

```java
import com.aspose.slides.*;

// Instancia uma classe de apresentação que representa um arquivo de apresentação.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Obtém a sequência principal do slide.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Obtém o primeiro efeito da sequência principal.
    IEffect effect = sequence.get_Item(0);

    // Altera o TriggerType do efeito para iniciar ao clique
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick);

    // Altera a Duração do efeito
    effect.getTiming().setDuration(3f);

    // Altera o TriggerDelayTime do efeito
    effect.getTiming().setTriggerDelayTime(0.5f);

    // Salva o arquivo PPTX no disco
    pres.save("AnimExample_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Som do efeito de animação**

Aspose.Slides fornece estas propriedades para permitir trabalhar com sons em efeitos de animação: 

- [setSound(IAudio value)](https://reference.aspose.com/slides/pt/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) 
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/pt/java/com.aspose.slides/effect/#setStopPreviousSound-boolean-) 

### **Adicionar som a um efeito de animação**

Este código Java mostra como adicionar um som a um efeito de animação e pará-lo quando o próximo efeito iniciar:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Adiciona áudio à coleção de áudio da apresentação
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Obtém a sequência principal do slide.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Obtém o primeiro efeito da sequência principal
    IEffect firstEffect = sequence.get_Item(0);

    // Verifica o efeito para "No Sound"
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // Adiciona som ao primeiro efeito
        firstEffect.setSound(effectSound);
    }

    // Obtém a primeira sequência interativa do slide.
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // Define a flag "Stop previous sound" do efeito
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // Grava o arquivo PPTX no disco
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Extrair som de um efeito de animação**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/) .
2. Obtenha a referência de um slide por meio do seu índice. 
3. Obtenha a sequência principal de efeitos. 
4. Extraia o [setSound(IAudio value)](https://reference.aspose.com/slides/pt/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) incorporado a cada efeito de animação. 

Este código Java mostra como extrair o som incorporado em um efeito de animação:

```java
import com.aspose.slides.*;

// Instancia uma classe de apresentação que representa um arquivo de apresentação.
Presentation presentation = new Presentation("EffectSound.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Obtém a sequência principal do slide.
    ISequence sequence = slide.getTimeline().getMainSequence();

    for (IEffect effect : sequence)
    {
        if (effect.getSound() == null)
            continue;

        // Extrai o som do efeito em um array de bytes
        byte[] audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Depois da animação**

Aspose.Slides for Java permite alterar a propriedade After animation de um efeito de animação.

Esta é a janela de efeito de animação e o menu estendido no Microsoft PowerPoint:

![Painel de efeito de animação](shape-after-animation.png)

A lista suspensa **After animation** do PowerPoint corresponde a estas propriedades: 

- A propriedade [setAfterAnimationType(int value)](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ieffect/#setAfterAnimationType-int-) que descreve o tipo After animation :
  * O **More Colors** do PowerPoint corresponde ao tipo [AfterAnimationType.Color](https://reference.aspose.com/slides/pt/java/com.aspose.slides/afteranimationtype/#Color);
  * O item **Don't Dim** do PowerPoint corresponde ao tipo [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/pt/java/com.aspose.slides/afteranimationtype/#DoNotDim) (tipo padrão de after animation);
  * O item **Hide After Animation** do PowerPoint corresponde ao tipo [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/afteranimationtype/#HideAfterAnimation);
  * O item **Hide on Next Mouse Click** do PowerPoint corresponde ao tipo [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/pt/java/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick);
- A propriedade [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) que define um formato de cor de after animation. Esta propriedade funciona em conjunto com o tipo [AfterAnimationType.Color](https://reference.aspose.com/slides/pt/java/com.aspose.slides/afteranimationtype/#Color). Se você mudar o tipo para outro, a cor after animation será limpa.

Este código Java mostra como alterar um efeito after animation:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instancia uma classe de apresentação que representa um arquivo de apresentação
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Obtém o primeiro efeito da sequência principal
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Altera o tipo de after animation para Color
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // Define a cor de after animation
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // Grava o arquivo PPTX no disco
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Animar texto**

Aspose.Slides fornece estas propriedades para permitir trabalhar com o bloco *Animate text* de um efeito de animação:

- [setAnimateTextType(int value)](...) que descreve o tipo de animação de texto do efeito. O texto da forma pode ser animado:
  - Tudo de uma vez ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/pt/java/com.aspose.slides/animatetexttype/#AllAtOnce) type)
  - Por palavra ([AnimateTextType.ByWord](https://reference.aspose.com/slides/pt/java/com.aspose.slides/animatetexttype/#ByWord) type)
  - Por letra ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/pt/java/com.aspose.slides/animatetexttype/#ByLetter) type)
- [setDelayBetweenTextParts(float value)](...) define um atraso entre as partes de texto animadas (palavras ou letras). Um valor positivo especifica a porcentagem da duração do efeito. Um valor negativo especifica o atraso em segundos.

Assim você pode alterar as propriedades Animate text do efeito:

1. [Apply](#apply-animation-to-shape) ou obtenha o efeito de animação.
2. Defina a propriedade [setBuildType(int value)](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itextanimation/#setBuildType-int-) para o valor [BuildType.AsOneObject](https://reference.aspose.com/slides/pt/java/com.aspose.slides/buildtype/#AsOneObject) para desativar o modo de animação *By Paragraphs*.
3. Defina novos valores para as propriedades [setAnimateTextType(int value)](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) e [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-).
4. Salve o arquivo PPTX modificado.

```java
import com.aspose.slides.*;

// Instancia uma classe de apresentação que representa um arquivo de apresentação.
Presentation pres = new Presentation("AnimText_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Obtém o primeiro efeito da sequência principal
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Altera o tipo de animação de texto do efeito para "As One Object"
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // Altera o tipo de animação de texto do efeito para "By word"
    firstEffect.setAnimateTextType(AnimateTextType.ByWord);

    // Define o atraso entre palavras para 20% da duração do efeito
    firstEffect.setDelayBetweenTextParts(20f);

    // Grava o arquivo PPTX no disco
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### Como posso garantir que as animações sejam preservadas ao publicar a apresentação na web?

Use [Export to HTML5](/slides/pt/java/export-to-html5/) e habilite as [options](https://reference.aspose.com/slides/pt/java/com.aspose.slides/html5options/) responsáveis por animações de [shape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) e [transition](https://reference.aspose.com/slides/pt/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-). HTML simples não reproduz animações de slide, enquanto HTML5 reproduz.

### Como a mudança da ordem Z (ordem de camadas) das formas afeta a animação?

A animação e a ordem de desenho são independentes: um efeito controla o tempo e o tipo de aparição/desaparecimento, enquanto [z-order](https://reference.aspose.com/slides/pt/java/com.aspose.slides/shape/#getZOrderPosition--) determina o que cobre o quê. O resultado visível é definido pela combinação de ambos. (Este é o comportamento geral do PowerPoint; o modelo de efeitos e formas do Aspose.Slides segue a mesma lógica.)

### Existem limitações ao converter animações em vídeo para certos efeitos?

Em geral, [as animações são suportadas](/slides/pt/java/convert-powerpoint-to-video/), mas casos raros ou efeitos específicos podem ser renderizados de forma diferente. Recomenda‑se testar com os efeitos que você usa e com a versão da biblioteca.