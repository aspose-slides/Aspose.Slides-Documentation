---
title: Aplicar animações de formas em apresentações no Android
linktitle: Animação de Forma
type: docs
weight: 60
url: /pt/androidjava/shape-animation/
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
- Android
- Java
- Aspose.Slides
description: "Descubra como criar e personalizar animações de formas em apresentações do PowerPoint com Aspose.Slides para Android via Java. Destaque-se!"
---
## **Introdução**

Animações são efeitos visuais que podem ser aplicados a textos, imagens, formas ou [gráficos](https://docs.aspose.com/slides/pt/androidjava/animated-charts/). Elas dão vida às apresentações ou aos seus componentes.

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
* Aspose.Slides oferece mais de **150 efeitos de animação** na enumeração [EffectType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/effecttype). Esses efeitos são essencialmente os mesmos (ou equivalentes) usados no PowerPoint.  

## **Aplicar animação a uma caixa de texto**

Aspose.Slides para Android via Java permite que você aplique animação ao texto em uma forma.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation).  
2. Obtenha uma referência de slide através do seu índice.  
3. Adicione um `rectangle` [IAutoShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iautoshape).  
4. Adicione texto ao [IAutoShape.TextFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-).  
5. Recupere a sequência principal de efeitos.  
6. Adicione um efeito de animação ao [IAutoShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iautoshape).  
7. Defina a propriedade `TextAnimation.BuildType` para o valor da enumeração `BuildType`.  
8. Grave a apresentação no disco como um arquivo PPTX.  

Este código Java mostra como aplicar o efeito `Fade` ao AutoShape e definir a animação de texto para o valor *By 1st Level Paragraphs*:

```java
// Instancia uma classe de apresentação que representa um arquivo de apresentação.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Adiciona um novo AutoShape com texto
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");

    // Obtém a sequência principal do slide.
    ISequence sequence = sld.getTimeline().getMainSequence();

    // Adiciona o efeito de animação Fade à forma
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Anima o texto da forma pelos parágrafos de primeiro nível
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // Salva o arquivo PPTX no disco
    pres.save(path + "AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert color="primary"  %}} 

Além de aplicar animações ao texto, você também pode aplicar animações a um único [Paragraph](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iparagraph). Veja [**Animated Text**](/slides/pt/androidjava/animated-text/).

{{% /alert %}} 

## **Aplicar animação a um PictureFrame**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation).  
2. Obtenha a referência de um slide através do seu índice.  
3. Adicione ou obtenha um [PictureFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/pictureframe) no slide.  
4. Recupere a sequência principal de efeitos.  
5. Adicione um efeito de animação ao [PictureFrame](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/pictureframe).  
6. Grave a apresentação no disco como um arquivo PPTX.  

Este código Java mostra como aplicar o efeito `Fly` a um picture frame:

```java
// Instancia uma classe de apresentação que representa um arquivo de apresentação.
Presentation pres = new Presentation();
try {
    // Carrega a imagem a ser adicionada à coleção de imagens da apresentação
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Adiciona um quadro de imagem ao slide
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, picture);

    // Obtém a sequência principal do slide.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Adiciona o efeito de animação Fly da esquerda ao quadro de imagem
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Salva o arquivo PPTX no disco
    pres.save(path + "AnimImage_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Aplicar animação a uma forma**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation).  
2. Obtenha a referência de um slide através do seu índice.  
3. Adicione um `rectangle` [IAutoShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iautoshape).  
4. Adicione um `Bevel` [IAutoShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iautoshape) (quando este objeto for clicado, a animação será reproduzida).  
5. Crie uma sequência de efeitos na forma bevel.  
6. Crie um `UserPath` personalizado.  
7. Adicione comandos para mover ao `UserPath`.  
8. Grave a apresentação no disco como um arquivo PPTX.  

Este código Java mostra como aplicar o efeito `PathFootball` (caminho de futebol) a uma forma:

```java
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

Os exemplos a seguir mostram como usar o método `getEffectsByShape` da interface [ISequence] para obter todos os efeitos de animação aplicados a uma forma.

**Exemplo 1: Obter efeitos de animação aplicados a uma forma em um slide normal**

Anteriormente, você aprendeu como adicionar efeitos de animação a formas em apresentações do PowerPoint. O código de exemplo a seguir mostra como obter os efeitos aplicados à primeira forma no primeiro slide normal da apresentação `AnimExample_out.pptx`.

```java
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

**Exemplo 2: Obter todos os efeitos de animação, incluindo os herdados de marcadores de posição**

Se uma forma em um slide normal possuir marcadores de posição que estão no slide de layout e/ou no slide mestre, e efeitos de animação foram adicionados a esses marcadores de posição, então todos os efeitos da forma serão reproduzidos durante a apresentação, incluindo os herdados dos marcadores de posição.

Suponha que temos um arquivo de apresentação PowerPoint `sample.pptx` com um slide contendo apenas uma forma de rodapé com o texto "Made with Aspose.Slides" e o efeito **Random Bars** está aplicado à forma.

![Slide shape animation effect](slide-shape-animation.png)

Suponha também que o efeito **Split** esteja aplicado ao marcador de posição de rodapé no slide de **layout**.

![Layout shape animation effect](layout-shape-animation.png)

E, finalmente, o efeito **Fly In** está aplicado ao marcador de posição de rodapé no slide **master**.

![Master shape animation effect](master-shape-animation.png)

O código de exemplo a seguir mostra como usar o método `getBasePlaceholder` da interface [IShape] para acessar os marcadores de posição da forma e obter os efeitos de animação aplicados à forma de rodapé, incluindo aqueles herdados de marcadores de posição localizados nos slides de layout e mestre.

```java
Presentation presentation = new Presentation("sample.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

// Obtém os efeitos de animação da forma no slide normal.
IShape shape = slide.getShapes().get_Item(0);
IEffect[] shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// Obtém os efeitos de animação do marcador de posição no slide de layout.
IShape layoutShape = shape.getBasePlaceholder();
IEffect[] layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// Obtém os efeitos de animação do marcador de posição no slide mestre.
IShape masterShape = layoutShape.getBasePlaceholder();
IEffect[] masterShapeEffects = slide.getLayoutSlide().getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(masterShape);

System.out.println("Main sequence of shape effects:");
printEffects(masterShapeEffects);
printEffects(layoutShapeEffects);
printEffects(shapeEffects);

presentation.dispose();
```
```java
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

Aspose.Slides para Android via Java permite que você altere as propriedades de temporização de um efeito de animação.

Esta é a janela Animation Timing no Microsoft PowerPoint:

![example1_image](shape-animation.png)

Estas são as correspondências entre PowerPoint Timing e as propriedades [Effect.Timing](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IEffect#getTiming--) :

- A lista suspensa **Start** do PowerPoint Timing corresponde à propriedade [Effect.Timing.TriggerType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ITiming#getTriggerType--).  
- A opção **Duration** do PowerPoint Timing corresponde à propriedade [Effect.Timing.Duration](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ITiming#getDuration--). A duração de uma animação (em segundos) é o tempo total que ela leva para completar um ciclo.  
- A opção **Delay** do PowerPoint Timing corresponde à propriedade [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ITiming#getTriggerDelayTime--).  

É assim que você altera as propriedades de temporização do efeito:

1. [Aplicar](#apply-animation-to-shape) ou obter o efeito de animação.  
2. Defina novos valores para as propriedades [Effect.Timing](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/IEffect#getTiming--) que você precisar.  
3. Salve o arquivo PPTX modificado.  

```java
// Instancia uma classe de apresentação que representa um arquivo de apresentação.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Obtém a sequência principal do slide.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Obtém o primeiro efeito da sequência principal.
    IEffect effect = sequence.get_Item(0);

    // Altera o TriggerType do efeito para iniciar ao clicar
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

Aspose.Slides fornece estas propriedades para permitir que você trabalhe com sons em efeitos de animação: 

- [setSound(IAudio value)](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)  
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/effect/#setStopPreviousSound-boolean-)  

### **Adicionar som a um efeito de animação**

Este código Java mostra como adicionar um som a um efeito de animação e interrompê‑lo quando o próximo efeito começar:

```java
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Adiciona áudio à coleção de áudio da apresentação
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Obtém a sequência principal do slide.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Obtém o primeiro efeito da sequência principal
    IEffect firstEffect = sequence.get_Item(0);

    // Verifica se o efeito está sem som
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

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/).  
2. Obtenha a referência de um slide através do seu índice.  
3. Recupere a sequência principal de efeitos.  
4. Extraia o [setSound(IAudio value)](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) incorporado a cada efeito de animação.  

Este código Java mostra como extrair o som incorporado a um efeito de animação:

```java
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

        // Extrai o som do efeito em array de bytes
        byte[] audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Após animação**

Aspose.Slides para Android via Java permite que você altere a propriedade After animation de um efeito de animação.

Esta é a janela Animation Effect e o menu estendido no Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

A lista suspensa **After animation** do PowerPoint Effect corresponde a estas propriedades: 

- A propriedade [setAfterAnimationType(int value)] que descreve o tipo de After animation :  
  * PowerPoint **More Colors** corresponde ao tipo [AfterAnimationType.Color](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/afteranimationtype/#Color);  
  * PowerPoint **Don't Dim** corresponde ao tipo [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/afteranimationtype/#DoNotDim) (tipo padrão de after animation);  
  * PowerPoint **Hide After Animation** corresponde ao tipo [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/afteranimationtype/#HideAfterAnimation);  
  * PowerPoint **Hide on Next Mouse Click** corresponde ao tipo [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick);  
- A propriedade [setAfterAnimationColor(IColorFormat value)] que define um formato de cor de after animation. Essa propriedade funciona em conjunto com o tipo [AfterAnimationType.Color](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/afteranimationtype/#Color). Se você mudar o tipo para outro, a cor de after animation será limpa.  

Este código Java mostra como alterar um efeito de after animation:

```java
// Instancia uma classe de apresentação que representa um arquivo de apresentação
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Obtém o primeiro efeito da sequência principal
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Altera o tipo de after animation para Color
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // Define a cor de escurecimento do after animation
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // Grava o arquivo PPTX no disco
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Animar texto**

Aspose.Slides fornece estas propriedades para permitir que você trabalhe com o bloco *Animate text* de um efeito de animação:

- [setAnimateTextType(int value)] que descreve um tipo de animação de texto do efeito. O texto da forma pode ser animado:  
  - Tudo de uma vez ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/animatetexttype/#AllAtOnce) tipo)  
  - Por palavra ([AnimateTextType.ByWord](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/animatetexttype/#ByWord) tipo)  
  - Por letra ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/animatetexttype/#ByLetter) tipo)  
- [setDelayBetweenTextParts(float value)] define um atraso entre as partes do texto animado (palavras ou letras). Um valor positivo especifica a porcentagem da duração do efeito. Um valor negativo especifica o atraso em segundos.  

É assim que você pode mudar as propriedades de Animate text do efeito:

1. [Aplicar](#apply-animation-to-shape) ou obter o efeito de animação.  
2. Defina a propriedade [setBuildType(int value)] para o valor [BuildType.AsOneObject](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/buildtype/#AsOneObject) para desativar o modo de animação *By Paragraphs*.  
3. Defina novos valores para as propriedades [setAnimateTextType(int value)] e [setDelayBetweenTextParts(float value)].  
4. Salve o arquivo PPTX modificado.  

```java
// Instancia uma classe de apresentação que representa um arquivo de apresentação.
Presentation pres = new Presentation("AnimTextBox_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Obtém o primeiro efeito da sequência principal
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Altera o tipo de animação de texto do efeito para "Como um único objeto"
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // Altera o tipo de Animar texto do efeito para "Por palavra"
    firstEffect.setAnimateTextType(AnimateTextType.ByWord);

    // Define o atraso entre palavras como 20% da duração do efeito
    firstEffect.setDelayBetweenTextParts(20f);

    // Grava o arquivo PPTX no disco
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Perguntas Frequentes**

**Como posso garantir que as animações sejam preservadas ao publicar a apresentação na Web?**

[Export to HTML5](/slides/pt/androidjava/export-to-html5/) e habilite as [opções](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/html5options/) responsáveis pelas animações de [shape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) e de [transition](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-). HTML simples não reproduz animações de slides, enquanto HTML5 reproduz.

**Como a mudança da ordem Z (ordem das camadas) das formas afeta a animação?**

A ordem de animação e a ordem de desenho são independentes: um efeito controla o tempo e o tipo de aparecimento/desaparecimento, enquanto o [z-order](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/shape/#getZOrderPosition--) determina o que cobre o quê. O resultado visível é definido pela combinação de ambos. (Este é o comportamento geral do PowerPoint; o modelo de efeitos e formas do Aspose.Slides segue a mesma lógica.)

**Existem limitações ao converter animações em vídeo para certos efeitos?**

Em geral, [as animações são suportadas](/slides/pt/androidjava/convert-powerpoint-to-video/), mas casos raros ou efeitos específicos podem ser renderizados de forma diferente. Recomenda‑se testar com os efeitos que você usa e com a versão da biblioteca.