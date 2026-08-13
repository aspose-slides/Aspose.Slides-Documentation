---
title: Aplicar animações de formas em apresentações em .NET
linktitle: Animação de Forma
type: docs
weight: 60
url: /pt/net/shape-animation/
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
- .NET
- C#
- Aspose.Slides
description: "Descubra como criar e personalizar animações de forma em apresentações do PowerPoint com Aspose.Slides para .NET. Destaque-se!"
---
## **Introdução**

Animações são efeitos visuais que podem ser aplicados a textos, imagens, formas ou [charts](/slides/pt/net/animated-charts/). Elas dão vida a apresentações ou seus constituintes. 

## **Por que usar animações em apresentações?**

Usando animações, você pode 

* controlar o fluxo de informação
* enfatizar pontos importantes
* aumentar o interesse ou a participação do seu público
* tornar o conteúdo mais fácil de ler, assimilar ou processar
* chamar a atenção dos leitores ou espectadores para partes importantes em uma apresentação

PowerPoint oferece muitas opções e ferramentas para animações e efeitos de animação nas categorias **entrance**, **exit**, **emphasis** e **motion paths**. 

## **Animações no Aspose.Slides**

* Aspose.Slides fornece as classes e tipos que você precisa para trabalhar com animações no namespace [Aspose.Slides.Animation](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/),
* Aspose.Slides fornece mais de **150 efeitos de animação** no enumeração [EffectType](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/effecttype). Esses efeitos são essencialmente os mesmos (ou equivalentes) usados no PowerPoint.

## **Aplicar animação a um TextBox**

Aspose.Slides para .NET permite aplicar animação ao texto em uma forma. 

1. Crie uma instância da classe [Presentation](http://www.aspose.com/api/net/slides/pt/aspose.slides/).
2. Obtenha a referência de um slide através do seu índice.
3. Adicione um `rectangle` [IAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape). 
4. Adicione texto ao [IAutoShape.TextFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/properties/textframe).
5. Obtenha a sequência principal de efeitos.
6. Adicione um efeito de animação ao [IAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape).
7. Defina a propriedade [TextAnimation.BuildType](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/textanimation/properties/buildtype) para o valor da [BuildType Enumeration](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/buildtype).
8. Grave a apresentação no disco como um arquivo PPTX.

Este código C# mostra como aplicar o efeito `Fade` ao AutoShape e definir a animação de texto para o valor *By 1st Level Paragraphs*:

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Instancia uma classe de apresentação que representa um arquivo de apresentação.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // Adiciona um novo AutoShape com texto
    IAutoShape autoShape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    // Adiciona três parágrafos para que a construção por parágrafo tenha algo para percorrer.
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "First paragraph";
    textFrame.Paragraphs.Add(new Paragraph { Text = "Second paragraph" });
    textFrame.Paragraphs.Add(new Paragraph { Text = "Third paragraph" });

    // Obtém a sequência principal do slide.
    ISequence sequence = sld.Timeline.MainSequence;

    // Adiciona o efeito de animação Fade à forma
    IEffect effect = sequence.AddEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Anima o texto da forma por parágrafos de primeiro nível
    effect.TextAnimation.BuildType = BuildType.ByLevelParagraphs1;

    // Salva o arquivo PPTX no disco
    pres.Save("AnimTextBox_out.pptx", SaveFormat.Pptx);
}
```

{{%  alert color="info"  %}} 

Além de aplicar animações ao texto, você também pode aplicar animações a um único [Paragraph](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraph). Veja [**Animated Text**](/slides/pt/net/animated-text/).

{{% /alert %}} 

## **Aplicar animação a um PictureFrame**

1. Crie uma instância da classe [Presentation](http://www.aspose.com/api/net/slides/pt/aspose.slides/).
2. Obtenha a referência de um slide através do seu índice.
3. Adicione ou obtenha um [PictureFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/ipictureframe) no slide. 
5. Obtenha a sequência principal de efeitos.
6. Adicione um efeito de animação ao [PictureFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/ipictureframe).
8. Grave a apresentação no disco como um arquivo PPTX.

Este código C# mostra como aplicar o efeito `Fly` a um picture frame:

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Instancia uma classe de apresentação que representa um arquivo de apresentação.
using (Presentation pres = new Presentation())
{
    // Carrega a imagem a ser adicionada na coleção de imagens da apresentação
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Adiciona um quadro de imagem ao slide
    IPictureFrame picFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // Obtém a sequência principal do slide.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Adiciona o efeito de animação Fly da esquerda ao quadro de imagem
    IEffect effect = sequence.AddEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Salva o arquivo PPTX no disco
    pres.Save("AnimImage_out.pptx", SaveFormat.Pptx);
}
```

## **Aplicar animação a uma Shape**

1. Crie uma instância da classe [Presentation](http://www.aspose.com/api/net/slides/pt/aspose.slides/).
2. Obtenha a referência de um slide através do seu índice.
3. Adicione um `rectangle` [IAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape). 
4. Adicione um `Bevel` [IAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape) (quando este objeto for clicado, a animação será reproduzida).
5. Crie uma sequência de efeitos na forma bevel.
6. Crie um `UserPath` personalizado.
7. Adicione comandos para mover ao `UserPath`.
8. Grave a apresentação no disco como um arquivo PPTX.

Este código C# mostra como aplicar o efeito `PathFootball` (path football) a uma forma:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Instancia uma classe Presentation que representa um arquivo de apresentação.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // Cria o efeito PathFootball para a forma existente do zero.
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);

    ashp.AddTextFrame("Animated TextBox");

    // Adiciona o efeito de animação PathFootBall.
    pres.Slides[0].Timeline.MainSequence.AddEffect(ashp, EffectType.PathFootball,
                           EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Cria algum tipo de "botão".
    IShape shapeTrigger = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Cria uma sequência de efeitos para o botão.
    ISequence seqInter = pres.Slides[0].Timeline.InteractiveSequences.Add(shapeTrigger);

    // Cria um caminho de usuário personalizado. Nosso objeto será movido somente depois que o botão for clicado.
    IEffect fxUserPath = seqInter.AddEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

    // Adiciona comandos para mover, pois o caminho criado está vazio.
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.Behaviors[0]);

    PointF[] pts = new PointF[1];
    pts[0] = new PointF(0.076f, 0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new PointF(-0.076f, -0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.Path.Add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

    // Grava o arquivo PPTX no disco
    pres.Save("AnimExample_out.pptx", SaveFormat.Pptx);
}
```

## **Obter os efeitos de animação aplicados a uma forma**

A seguir, os exemplos mostram como usar o método `GetEffectsByShape` da interface [ISequence](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/isequence/) para obter todos os efeitos de animação aplicados a uma forma.

**Exemplo 1: Obter efeitos de animação aplicados a uma forma em um slide normal**

Anteriormente, você aprendeu como adicionar efeitos de animação a formas em apresentações do PowerPoint. O código de exemplo a seguir mostra como obter os efeitos aplicados à primeira forma no primeiro slide normal da apresentação `AnimExample_out.pptx`.

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation("AnimExample_out.pptx"))
{
    ISlide firstSlide = presentation.Slides[0];

    // Obtém a sequência principal de animação do slide.
    ISequence sequence = firstSlide.Timeline.MainSequence;

    // Obtém a primeira forma no primeiro slide.
    IShape shape = firstSlide.Shapes[0];

    // Obtém os efeitos de animação aplicados à forma.
    IEffect[] shapeEffects = sequence.GetEffectsByShape(shape);

    if (shapeEffects.Length > 0)
        Console.WriteLine($"The shape {shape.Name} has {shapeEffects.Length} animation effects.");
}
```

**Exemplo 2: Obter todos os efeitos de animação, incluindo os herdados de placeholders**

Se uma forma em um slide normal tem placeholders que estão no slide de layout e/ou slide mestre, e efeitos de animação foram adicionados a esses placeholders, então todos os efeitos da forma serão reproduzidos durante a apresentação, incluindo os herdados dos placeholders.

Suponha que tenhamos um arquivo de apresentação PowerPoint `sample.pptx` com um slide contendo apenas uma forma de rodapé com o texto "Made with Aspose.Slides" e o efeito **Random Bars** aplicado à forma.

![Slide shape animation effect](slide-shape-animation.png)

Assuma também que o efeito **Split** esteja aplicado ao placeholder de rodapé no slide de **layout**.

![Layout shape animation effect](layout-shape-animation.png)

E finalmente, o efeito **Fly In** esteja aplicado ao placeholder de rodapé no slide **master**.

![Master shape animation effect](master-shape-animation.png)

O código de exemplo a seguir mostra como usar o método `GetBasePlaceholder` da interface [IShape](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape/) para acessar os placeholders da forma e obter os efeitos de animação aplicados à forma de rodapé, incluindo os herdados dos placeholders localizados nos slides de layout e mestre.

```cs
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Obter efeitos de animação da forma no slide normal.
    IShape shape = slide.Shapes[0];
    IEffect[] shapeEffects = slide.Timeline.MainSequence.GetEffectsByShape(shape);

    // Obter efeitos de animação do placeholder no slide de layout.
    IShape layoutShape = shape.GetBasePlaceholder();
    IEffect[] layoutShapeEffects = slide.LayoutSlide.Timeline.MainSequence.GetEffectsByShape(layoutShape);

    // Obter efeitos de animação do placeholder no slide mestre.
    IShape masterShape = layoutShape.GetBasePlaceholder();
    IEffect[] masterShapeEffects = slide.LayoutSlide.MasterSlide.Timeline.MainSequence.GetEffectsByShape(masterShape);

    Console.WriteLine("Main sequence of shape effects:");
    PrintEffects(masterShapeEffects);
    PrintEffects(layoutShapeEffects);
    PrintEffects(shapeEffects);
}

static void PrintEffects(IEnumerable<IEffect> effects)
{
    foreach (IEffect effect in effects)
    {
        Console.WriteLine($"{effect.Type} {effect.Subtype}");
    }
}
```
```cs
using Aspose.Slides.Animation;

static void PrintEffects(IEnumerable<IEffect> effects)
{
    foreach (IEffect effect in effects)
    {
        Console.WriteLine($"{effect.Type} {effect.Subtype}");
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

Aspose.Slides para .NET permite alterar as propriedades de Tempo de um efeito de animação.

Esta é a janela de Timing de Animação e o menu estendido no Microsoft PowerPoint:

![example1_image](shape-animation.png)

Estas são as correspondências entre o Tempo do PowerPoint e as propriedades [Effect.Timing](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/effect/properties/timing):
- PowerPoint Timing **Start** drop-down list corresponds to the [Effect.Timing.TriggerType](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/itiming/properties/triggertype) property. 
- PowerPoint Timing **Duration** corresponds to the [Effect.Timing.Duration](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/itiming/properties/duration) property. A duração de uma animação (em segundos) é o tempo total que a animação leva para concluir um ciclo. 
- PowerPoint Timing **Delay** corresponds to the [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/itiming/properties/triggerdelaytime) property. 
- PowerPoint Timing **Repeat** drop-down list corresponds to these properties: 
  * [Effect.Timing.RepeatCount](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/itiming/repeatcount) property which describes the *number* of times the effect is repeated;
  * [Effect.Timing.RepeatUntilEndSlide](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/itiming/repeatuntilendslide) flag which specifies whether the effect is repeated until the end of the slide;
  * [Effect.Timing.RepeatUntilNextClick](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/itiming/repeatuntilnextclick) flag which specifies whether the effect is repeated until the next click.
- PowerPoint Timing **Rewind when done playing** checkbox matches the [Effect.Timing.Rewind](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/itiming/rewind/) property. 

Assim você altera as propriedades de Tempo do Effect:

1. [Apply](#apply-animation-to-shape) ou obtenha o efeito de animação.
2. Defina novos valores para as propriedades [Effect.Timing](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/effect/properties/timing) que precisar. 
3. Salve o arquivo PPTX modificado.

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Instancia uma classe de apresentação que representa um arquivo de apresentação.
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
    // Obtém a sequência principal do slide.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Obtém o primeiro efeito da sequência principal.
    IEffect effect = sequence[0];

    // Altera o TriggerType do efeito para iniciar ao clicar
    effect.Timing.TriggerType = EffectTriggerType.OnClick;

    // Altera a duração do efeito
    effect.Timing.Duration = 3f;

    // Altera o TriggerDelayTime do efeito
    effect.Timing.TriggerDelayTime = 0.5f;

    // Se o valor Repeat do efeito for "none"
    if (effect.Timing.RepeatCount == 1f)
    {
        // Altera o Repeat do efeito para "Until Next Click"
        effect.Timing.RepeatUntilNextClick = true;
    }
    else
    {
        // Altera o Repeat do efeito para "Until End of Slide"
        effect.Timing.RepeatUntilEndSlide = true;
    }

    // Ativa o Rewind do efeito
        effect.Timing.Rewind = true;
    
    // Salva o arquivo PPTX no disco
    pres.Save("AnimExample_changed.pptx", SaveFormat.Pptx);
}
```

## **Som do efeito de animação**

Aspose.Slides fornece estas propriedades para permitir trabalhar com sons em efeitos de animação: 
- [IEffect.Sound](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/effect/sound/) 
- [IEffect.StopPreviousSound](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/effect/stopprevioussound/) 

### **Adicionar som a um efeito de animação**

Este código C# mostra como adicionar um som a um efeito de animação e pará-lo quando o próximo efeito iniciar:

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
	// Adiciona áudio à coleção de áudio da apresentação
	IAudio effectSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// Obtém a sequência principal do slide.
	ISequence sequence = firstSlide.Timeline.MainSequence;

	// Obtém o primeiro efeito da sequência principal
	IEffect firstEffect = sequence[0];

	// Verifica se o efeito não tem som
	if (!firstEffect.StopPreviousSound && firstEffect.Sound == null)
	{
		// Adiciona som ao primeiro efeito
		firstEffect.Sound = effectSound;
	}

	// Obtém a primeira sequência interativa do slide.
	ISequence interactiveSequence = firstSlide.Timeline.InteractiveSequences[0];

	// Define a flag "Stop previous sound" do efeito
	interactiveSequence[0].StopPreviousSound = true;

	// Grava o arquivo PPTX no disco
	pres.Save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
}
```

### **Extrair som de um efeito de animação**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/).
2. Obtenha a referência de um slide através do seu índice. 
3. Obtenha a sequência principal de efeitos. 
4. Extraia o [Sound](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/effect/sound/) incorporado a cada efeito de animação. 

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;

// Instancia uma classe de apresentação que representa um arquivo de apresentação.
using (Presentation presentation = new Presentation("EffectSound.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Obtém a sequência principal do slide.
    ISequence sequence = slide.Timeline.MainSequence;

    foreach (IEffect effect in sequence)
    {
        if (effect.Sound == null)
            continue;

        // Extrai o som do efeito em array de bytes
        byte[] audio = effect.Sound.BinaryData;
    }
}
```

## **After Animation**

Aspose.Slides para .NET permite alterar a propriedade After animation de um efeito de animação.

Esta é a janela de After Animation do PowerPoint:

![example1_image](shape-after-animation.png)

A lista suspensa **After animation** do PowerPoint Effect corresponde a estas propriedades: 

- [IEffect.AfterAnimationType](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/ieffect/afteranimationtype/) property which describes the After animation type :
  * PowerPoint **More Colors** corresponds to the [AfterAnimationType.Color](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/afteranimationtype/) type;
  * PowerPoint **Don't Dim** corresponds to the [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/afteranimationtype/) type (default after animation type);
  * PowerPoint **Hide After Animation** corresponds to the [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/afteranimationtype/) type;
  * PowerPoint **Hide on Next Mouse Click** corresponds to the [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/afteranimationtype/) type;
- [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/ieffect/afteranimationcolor/) property which defines an after animation color format. This property works in conjunction with the [AfterAnimationType.Color](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/afteranimationtype/) type. If you change the type to another, the after animation color will be cleared.

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Instancia uma classe de apresentação que representa um arquivo de apresentação
using (Presentation pres = new Presentation("AnimImage_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // Obtém o primeiro efeito da sequência principal
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // Altera o tipo de animação posterior para Cor
    firstEffect.AfterAnimationType = AfterAnimationType.Color;

    // Define a cor de escurecimento da animação posterior
    firstEffect.AfterAnimationColor.Color = Color.AliceBlue;

    // Grava o arquivo PPTX no disco
    pres.Save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
}
```

## **Animar texto**

Aspose.Slides fornece estas propriedades para permitir trabalhar com o bloco *Animate text* de um efeito de animação:

- [IEffect.AnimateTextType](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/ieffect/animatetexttype/) which describes an animate text type of the effect. The shape text can be animated:
  - All at once ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/animatetexttype/) type)
  - By word ([AnimateTextType.ByWord](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/animatetexttype/) type)
  - By letter ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/animatetexttype/) type)
- [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/ieffect/delaybetweentextparts/) sets a delay between the animated text parts (words or letters). A positive value specifies the percentage of effect duration. A negative value specifies the delay in seconds.

Assim você pode alterar as propriedades Animate text do Effect:

1. [Apply](#apply-animation-to-shape) ou obtenha o efeito de animação.
2. Defina a propriedade [IEffect.TextAnimation.BuildType](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/itextanimation/buildtype/) para o valor [BuildType.AsOneObject](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/buildtype/) para desativar o modo de animação *By Paragraphs*.
3. Defina novos valores para as propriedades [IEffect.AnimateTextType](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/ieffect/animatetexttype/) e [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/ieffect/delaybetweentextparts/).
4. Salve o arquivo PPTX modificado.

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Instancia uma classe de apresentação que representa um arquivo de apresentação.
using (Presentation pres = new Presentation("AnimTextBox_out.pptx"))
{
	ISlide firstSlide = pres.Slides[0];

	// Obtém o primeiro efeito da sequência principal
	IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

	// Altera o tipo de animação de texto do efeito para "As One Object"
	firstEffect.TextAnimation.BuildType = BuildType.AsOneObject;

	// Altera o tipo de animação de texto do efeito para "By word"
	firstEffect.AnimateTextType = AnimateTextType.ByWord;

	// Define o atraso entre palavras como 20% da duração do efeito
	firstEffect.DelayBetweenTextParts = 20f;

	// Grava o arquivo PPTX no disco
	pres.Save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

### Como garantir que as animações sejam preservadas ao publicar a apresentação na web?

[Export to HTML5](/slides/pt/net/export-to-html5/) e habilite as [options](https://reference.aspose.com/slides/pt/net/aspose.slides.export/html5options/) responsáveis por animações de [shape](https://reference.aspose.com/slides/pt/net/aspose.slides.export/html5options/animateshapes/) e [transition](https://reference.aspose.com/slides/pt/net/aspose.slides.export/html5options/animatetransitions/). HTML puro não reproduz animações de slides, enquanto HTML5 reproduz.

### Como a mudança da ordem z (ordem de camada) das formas afeta a animação?

A ordem de animação e de desenho são independentes: um efeito controla o tempo e o tipo de aparição/desaparição, enquanto a [z-order](https://reference.aspose.com/slides/pt/net/aspose.slides/shape/zorderposition/) determina o que cobre o quê. O resultado visível é definido pela combinação de ambos. (Este é o comportamento geral do PowerPoint; o modelo de efeitos‑e‑formas do Aspose.Slides segue a mesma lógica.)

### Existem limitações ao converter animações para vídeo para certos efeitos?

Em geral, [as animações são suportadas](/slides/pt/net/convert-powerpoint-to-video/), mas casos raros ou efeitos específicos podem ser renderizados de forma diferente. Recomenda‑se testar com os efeitos que você usa e com a versão da biblioteca.