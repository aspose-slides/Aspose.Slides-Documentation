---
title: Aplicar animações de formas em apresentações no .NET
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
description: "Descubra como criar e personalizar animações de formas em apresentações do PowerPoint com Aspose.Slides para .NET. Destaque-se!"
---
## **Introdução**

Animações são efeitos visuais que podem ser aplicados a textos, imagens, formas ou [gráficos](/slides/pt/net/animated-charts/). Elas dão vida às apresentações ou seus componentes. 

## **Por que usar animações em apresentações?**

Usando animações, você pode 

* controlar o fluxo de informações
* enfatizar pontos importantes
* aumentar o interesse ou a participação do seu público
* tornar o conteúdo mais fácil de ler, assimilar ou processar
* chamar a atenção de seus leitores ou espectadores para partes importantes de uma apresentação

PowerPoint fornece muitas opções e ferramentas para animações e efeitos de animação nas categorias **entrada**, **saída**, **ênfase** e **caminhos de movimento**. 

## **Animações no Aspose.Slides**

* Aspose.Slides fornece as classes e tipos que você precisa para trabalhar com animações no namespace [Aspose.Slides.Animation](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/),
* Aspose.Slides oferece mais de **150 efeitos de animação** na enumeração [EffectType](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/effecttype). Esses efeitos são essencialmente os mesmos (ou equivalentes) usados no PowerPoint.

## **Aplicar animação a uma caixa de texto**

Aspose.Slides para .NET permite aplicar animação ao texto em uma forma. 

1. Crie uma instância da classe [Presentation](http://www.aspose.com/api/net/slides/pt/aspose.slides/).
2. Obtenha uma referência ao slide através de seu índice.
3. Adicione um `rectangle` [IAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape). 
4. Adicione texto ao [IAutoShape.TextFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape/properties/textframe).
5. Obtenha uma sequência principal de efeitos.
6. Adicione um efeito de animação ao [IAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape).
7. Defina a propriedade [TextAnimation.BuildType](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/textanimation/properties/buildtype) para o valor da [enumeração BuildType](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/buildtype).
8. Grave a apresentação no disco como um arquivo PPTX.

```c#
// Instancia uma classe Presentation que representa um arquivo de apresentação.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    
    // Adiciona um novo AutoShape com texto
    IAutoShape autoShape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "First paragraph \nSecond paragraph \n Third paragraph";

    // Obtém a sequência principal do slide.
    ISequence sequence = sld.Timeline.MainSequence;

    // Adiciona efeito de animação Fade à forma
    IEffect effect = sequence.AddEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Anima o texto da forma por parágrafos de 1º nível
    effect.TextAnimation.BuildType = BuildType.ByLevelParagraphs1;

    // Salva o arquivo PPTX no disco
    pres.Save(path + "AnimTextBox_out.pptx", SaveFormat.Pptx);
}
```

{{%  alert color="primary"  %}} 

Além de aplicar animações ao texto, você também pode aplicar animações a um único [Parágrafo](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraph). Veja [**Texto Animado**](/slides/pt/net/animated-text/).

{{% /alert %}} 

## **Aplicar animação a um PictureFrame**

1. Crie uma instância da classe [Presentation](http://www.aspose.com/api/net/slides/pt/aspose.slides/).
2. Obtenha uma referência ao slide através de seu índice.
3. Adicione ou obtenha um [PictureFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/ipictureframe) no slide. 
5. Obtenha a sequência principal de efeitos.
6. Adicione um efeito de animação ao [PictureFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/ipictureframe).
8. Grave a apresentação no disco como um arquivo PPTX.

```c#
 // Instancia uma classe de apresentação que representa um arquivo de apresentação.
 using (Presentation pres = new Presentation())
 {
     // Carrega a imagem a ser adicionada na coleção de imagens da apresentação
     IImage image = Images.FromFile("aspose-logo.jpg");
     IPPImage ppImage = pres.Images.AddImage(image);
     image.Dispose();

     // Adiciona quadro de imagem ao slide
     IPictureFrame picFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

     // Obtém a sequência principal do slide.
     ISequence sequence = pres.Slides[0].Timeline.MainSequence;

     // Adiciona efeito de animação Fly da esquerda ao quadro de imagem
     IEffect effect = sequence.AddEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

     // Salva o arquivo PPTX no disco
     pres.Save("AnimImage_out.pptx", SaveFormat.Pptx);
 }
```

## **Aplicar animação a uma forma**

1. Crie uma instância da classe [Presentation](http://www.aspose.com/api/net/slides/pt/aspose.slides/).
2. Obtenha uma referência ao slide através de seu índice.
3. Adicione um `rectangle` [IAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape). 
4. Adicione um `Bevel` [IAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/iautoshape) (quando este objeto for clicado, a animação será reproduzida).
5. Crie uma sequência de efeitos na forma bevel.
6. Crie um `UserPath` personalizado.
7. Adicione comandos para mover ao `UserPath`.
8. Grave a apresentação no disco como um arquivo PPTX.

```c#
 // Instancia uma classe Presentation que representa um arquivo de apresentação.
 using (Presentation pres = new Presentation())
 {
     ISlide sld = pres.Slides[0];

     // Cria o efeito PathFootball para a forma existente do zero.
     IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);

     ashp.AddTextFrame("Animated TextBox");

     // Adiciona o efeito de animação PathFootball.
     pres.Slides[0].Timeline.MainSequence.AddEffect(ashp, EffectType.PathFootball,
                            EffectSubtype.None, EffectTriggerType.AfterPrevious);

     // Cria uma espécie de "botão".
     IShape shapeTrigger = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

     // Cria uma sequência de efeitos para o botão.
     ISequence seqInter = pres.Slides[0].Timeline.InteractiveSequences.Add(shapeTrigger);

     // Cria um caminho de usuário personalizado. Nosso objeto será movido somente após o botão ser clicado.
     IEffect fxUserPath = seqInter.AddEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

     // Adiciona comandos de movimentação já que o caminho criado está vazio.
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

Os exemplos a seguir mostram como usar o método `GetEffectsByShape` da interface [ISequence](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/isequence/) para obter todos os efeitos de animação aplicados a uma forma.

**Exemplo 1: Obter efeitos de animação aplicados a uma forma em um slide normal**

Anteriormente, você aprendeu como adicionar efeitos de animação a formas em apresentações do PowerPoint. O código de exemplo a seguir mostra como obter os efeitos aplicados à primeira forma no primeiro slide normal da apresentação `AnimExample_out.pptx`.

```c#
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

**Exemplo 2: Obter todos os efeitos de animação, incluindo os herdados de marcadores de posição**

Se uma forma em um slide normal possui marcadores de posição que estão no slide de layout e/ou no slide mestre, e efeitos de animação foram adicionados a esses marcadores, então todos os efeitos da forma serão reproduzidos durante a apresentação, incluindo os herdados dos marcadores.

Vamos supor que temos um arquivo de apresentação PowerPoint `sample.pptx` com um slide contendo apenas uma forma de rodapé com o texto "Made with Aspose.Slides" e o efeito **Random Bars** aplicado à forma.

![Efeito de animação da forma do slide](slide-shape-animation.png)

Vamos também supor que o efeito **Split** está aplicado ao marcador de posição do rodapé no slide de **layout**.

![Efeito de animação da forma de layout](layout-shape-animation.png)

E, por fim, o efeito **Fly In** está aplicado ao marcador de posição do rodapé no slide **mestre**.

![Efeito de animação da forma mestre](master-shape-animation.png)

O código de exemplo a seguir mostra como usar o método `GetBasePlaceholder` da interface [IShape](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape/) para acessar os marcadores de posição da forma e obter os efeitos de animação aplicados à forma de rodapé, incluindo os herdados dos marcadores localizados nos slides de layout e mestre.

```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Obtém os efeitos de animação da forma no slide normal.
    IShape shape = slide.Shapes[0];
    IEffect[] shapeEffects = slide.Timeline.MainSequence.GetEffectsByShape(shape);

    // Obtém os efeitos de animação do marcador de posição no slide de layout.
    IShape layoutShape = shape.GetBasePlaceholder();
    IEffect[] layoutShapeEffects = slide.LayoutSlide.Timeline.MainSequence.GetEffectsByShape(layoutShape);

    // Obtém os efeitos de animação do marcador de posição no slide mestre.
    IShape masterShape = layoutShape.GetBasePlaceholder();
    IEffect[] masterShapeEffects = slide.LayoutSlide.MasterSlide.Timeline.MainSequence.GetEffectsByShape(masterShape);

    Console.WriteLine("Main sequence of shape effects:");
    PrintEffects(masterShapeEffects);
    PrintEffects(layoutShapeEffects);
    PrintEffects(shapeEffects);
}
```
```cs
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

Aspose.Slides para .NET permite alterar as propriedades de Timing (tempo) de um efeito de animação.

Este é o painel de Timing de Animação e o menu estendido no Microsoft PowerPoint:

![example1_image](shape-animation.png)

Estas são as correspondências entre o Timing do PowerPoint e as propriedades [Effect.Timing](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/effect/properties/timing):

- O menu suspenso **Start** do Timing do PowerPoint corresponde à propriedade [Effect.Timing.TriggerType](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/itiming/properties/triggertype). 
- O **Duration** do Timing do PowerPoint corresponde à propriedade [Effect.Timing.Duration](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/itiming/properties/duration). A duração de uma animação (em segundos) é o tempo total que a animação leva para completar um ciclo. 
- O **Delay** do Timing do PowerPoint corresponde à propriedade [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/itiming/properties/triggerdelaytime). 
- O menu suspenso **Repeat** do Timing do PowerPoint corresponde a estas propriedades: 
  * a propriedade [Effect.Timing.RepeatCount](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/itiming/repeatcount) que descreve o *número* de vezes que o efeito é repetido;
  * a flag [Effect.Timing.RepeatUntilEndSlide](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/itiming/repeatuntilendslide) que especifica se o efeito é repetido até o final do slide;
  * a flag [Effect.Timing.RepeatUntilNextClick](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/itiming/repeatuntilnextclick) que especifica se o efeito é repetido até o próximo clique.
- A caixa de seleção **Rewind when done playing** do Timing do PowerPoint corresponde à propriedade [Effect.Timing.Rewind](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/itiming/rewind/). 

É assim que você altera as propriedades de Timing do Effect:

1. [Aplicar](#apply-animation-to-shape) ou obter o efeito de animação.
2. Defina novos valores para as propriedades [Effect.Timing](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/effect/properties/timing) que você precisar. 
3. Salve o arquivo PPTX modificado.

```c#
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

    // Se o valor de Repeat do efeito for "none"
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

```c#
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
	// Adiciona áudio à coleção de áudio da apresentação
	IAudio effectSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// Obtém a sequência principal do slide.
	ISequence sequence = firstSlide.Timeline.MainSequence;

	// Obtém o primeiro efeito da sequência principal
	IEffect firstEffect = sequence[0];

	// Verifica se o efeito está sem som
	if (!firstEffect.StopPreviousSound && firstEffect.Sound == null)
	{
		// Adiciona som ao primeiro efeito
		firstEffect.Sound = effectSound;
	}

	// Obtém a primeira sequência interativa do slide.
	ISequence interactiveSequence = firstSlide.Timeline.InteractiveSequences[0];

	// Define a flag de "Stop previous sound" do efeito
	interactiveSequence[0].StopPreviousSound = true;

	// Grava o arquivo PPTX no disco
	pres.Save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
}
```

### **Extrair som de um efeito de animação**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/).
2. Obtenha uma referência ao slide através de seu índice. 
3. Obtenha a sequência principal de efeitos. 
4. Extraia o [Sound](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/effect/sound/) incorporado a cada efeito de animação. 

```c#
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

## **Depois da animação**

Aspose.Slides para .NET permite alterar a propriedade After Animation (Depois da animação) de um efeito de animação.

Este é o painel de After Animation e o menu estendido no Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

A lista suspensa **After animation** do PowerPoint corresponde a estas propriedades: 

- A propriedade [IEffect.AfterAnimationType](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/ieffect/afteranimationtype/) que descreve o tipo de After animation :
  * O **More Colors** do PowerPoint corresponde ao tipo [AfterAnimationType.Color](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/afteranimationtype/).
  * O item **Don't Dim** do PowerPoint corresponde ao tipo [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/afteranimationtype/) (tipo padrão).
  * O item **Hide After Animation** do PowerPoint corresponde ao tipo [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/afteranimationtype/).
  * O item **Hide on Next Mouse Click** do PowerPoint corresponde ao tipo [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/afteranimationtype/).
- A propriedade [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/ieffect/afteranimationcolor/) que define o formato de cor After Animation. Esta propriedade funciona em conjunto com o tipo [AfterAnimationType.Color](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/afteranimationtype/). Se você mudar o tipo para outro, a cor After Animation será limpa.

```c#
// Instancia uma classe Presentation que representa um arquivo de apresentação
using (Presentation pres = new Presentation("AnimImage_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // Obtém o primeiro efeito da sequência principal
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // Altera o tipo de after animation para Cor
    firstEffect.AfterAnimationType = AfterAnimationType.Color;

    // Define a cor de escurecimento after animation
    firstEffect.AfterAnimationColor.Color = Color.AliceBlue;

    // Grava o arquivo PPTX no disco
    pres.Save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
}
```

## **Animar texto**

Aspose.Slides fornece estas propriedades para permitir trabalhar com o bloco *Animate text* (Animar texto) de um efeito de animação:

- [IEffect.AnimateTextType](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/ieffect/animatetexttype/) que descreve o tipo de animação de texto do efeito. O texto da forma pode ser animado:
  - Tudo de uma vez ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/animatetexttype/) tipo)
  - Por palavra ([AnimateTextType.ByWord](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/animatetexttype/) tipo)
  - Por letra ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/animatetexttype/) tipo)
- [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/ieffect/delaybetweentextparts/) define um atraso entre as partes de texto animadas (palavras ou letras). Um valor positivo especifica a porcentagem da duração do efeito. Um valor negativo especifica o atraso em segundos.

É assim que você pode alterar as propriedades de Animate Text do Effect:

1. [Aplicar](#apply-animation-to-shape) ou obter o efeito de animação.
2. Defina a propriedade [IEffect.TextAnimation.BuildType](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/itextanimation/buildtype/) para o valor [BuildType.AsOneObject](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/buildtype/) para desativar o modo de animação *By Paragraphs*.
3. Defina novos valores para as propriedades [IEffect.AnimateTextType](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/ieffect/animatetexttype/) e [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/ieffect/delaybetweentextparts/).
4. Salve o arquivo PPTX modificado.

```c#
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

    // Define o atraso entre palavras para 20% da duração do efeito
    firstEffect.DelayBetweenTextParts = 20f;

    // Grava o arquivo PPTX no disco
    pres.Save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
}
```

## **Perguntas frequentes**

**Como posso garantir que as animações sejam preservadas ao publicar a apresentação na web?**

[Export to HTML5](/slides/pt/net/export-to-html5/) e habilite as [opções](https://reference.aspose.com/slides/pt/net/aspose.slides.export/html5options/) responsáveis pelas animações de [shape](https://reference.aspose.com/slides/pt/net/aspose.slides.export/html5options/animateshapes/) e [transition](https://reference.aspose.com/slides/pt/net/aspose.slides.export/html5options/animatetransitions/). HTML simples não reproduz animações de slides, enquanto HTML5 reproduz.

**Como a mudança da ordem z (ordem de camadas) das formas afeta a animação?**

Animação e ordem de desenho são independentes: um efeito controla o tempo e o tipo de aparecimento/desaparecimento, enquanto o [z-order](https://reference.aspose.com/slides/pt/net/aspose.slides/shape/zorderposition/) determina o que cobre o quê. O resultado visível é definido pela combinação de ambos. (Este é o comportamento geral do PowerPoint; o modelo de efeitos e formas do Aspose.Slides segue a mesma lógica.)

**Existem limitações ao converter animações para vídeo para certos efeitos?**

Em geral, [as animações são suportadas](/slides/pt/net/convert-powerpoint-to-video/), mas casos raros ou efeitos específicos podem ser renderizados de forma diferente. Recomenda‑se testar com os efeitos que você usa e com a versão da biblioteca.