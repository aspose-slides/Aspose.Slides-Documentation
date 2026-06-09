---
title: Gerenciar transições de slide em apresentações no .NET
linktitle: Transição de slide
type: docs
weight: 90
url: /pt/net/slide-transition/
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
- .NET
- C#
- Aspose.Slides
description: "Descubra como personalizar transições de slide no Aspose.Slides para .NET, com orientação passo a passo para apresentações PowerPoint e OpenDocument."
---
## **Visão geral**

Este artigo explica como gerenciar transições de slides em apresentações usando Aspose.Slides. Ele mostra como aplicar tipos de transição aos slides, configurar o comportamento da transição, como avançar ao clicar ou após um tempo especificado, verificar e desativar o avanço automático, usar a transição Morph e seus tipos e definir opções de efeito de transição. Os exemplos demonstram como carregar ou criar uma apresentação, modificar as configurações de transição para slides selecionados e salvar o resultado como um arquivo PPTX. O artigo também responde a perguntas comuns sobre velocidade da transição, sons de transição, aplicação da mesma transição a vários slides e verificação da transição atualmente definida em um slide.

## **Adicionar transição de slide**
Para facilitar a compreensão, demonstramos o uso do Aspose.Slides for .NET para gerenciar transições de slide simples. Os desenvolvedores podem não apenas aplicar diferentes efeitos de transição de slide nos slides, mas também personalizar o comportamento desses efeitos de transição. Para criar um efeito de transição de slide simples, siga os passos abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation).
1. Aplique um Tipo de Transição de Slide no slide a partir de um dos efeitos de transição oferecidos pelo Aspose.Slides for .NET por meio do enum TransitionType.
1. Grave o arquivo de apresentação modificado.

```c#
 // Instanciar a classe Presentation para carregar o arquivo de apresentação de origem
 using (Presentation presentation = new Presentation("AccessSlides.pptx"))
 {
     // Aplicar transição do tipo círculo no slide 1
     presentation.Slides[0].SlideShowTransition.Type = TransitionType.Circle;

     // Aplicar transição do tipo pente no slide 2
     presentation.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

     // Gravar a apresentação no disco
     presentation.Save("SampleTransition_out.pptx", SaveFormat.Pptx);
 }
```

## **Adicionar transição de slide avançada**
Na seção anterior, aplicamos apenas um efeito de transição simples no slide. Agora, para tornar esse efeito de transição simples ainda melhor e controlado, siga os passos abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation).
1. Aplique um Tipo de Transição de Slide no slide a partir de um dos efeitos de transição oferecidos pelo Aspose.Slides for .NET.
1. Você também pode definir a transição para Avançar ao Clicar, após um período de tempo específico ou ambos.
1. Se a transição de slide estiver habilitada para Avançar ao Clicar, a transição avançará somente quando alguém clicar com o mouse. Além disso, se a propriedade Advance After Time estiver definida, a transição avançará automaticamente após o tempo especificado.
1. Grave a apresentação modificada como um arquivo de apresentação.

```c#
// Instanciar a classe Presentation que representa um arquivo de apresentação
using (Presentation pres = new Presentation("BetterSlideTransitions.pptx"))
{

    // Aplicar transição do tipo círculo no slide 1
    pres.Slides[0].SlideShowTransition.Type = TransitionType.Circle;


    // Definir o tempo de transição de 3 segundos
    pres.Slides[0].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[0].SlideShowTransition.AdvanceAfterTime = 3000;

    // Aplicar transição do tipo pente no slide 2
    pres.Slides[1].SlideShowTransition.Type = TransitionType.Comb;


    // Definir o tempo de transição de 5 segundos
    pres.Slides[1].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[1].SlideShowTransition.AdvanceAfterTime = 5000;

    // Aplicar transição do tipo zoom no slide 3
    pres.Slides[2].SlideShowTransition.Type = TransitionType.Zoom;


    // Definir o tempo de transição de 7 segundos
    pres.Slides[2].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[2].SlideShowTransition.AdvanceAfterTime = 7000;

    // Gravar a apresentação no disco
    pres.Save("SampleTransition_out.pptx", SaveFormat.Pptx);
}
```

Além disso, usando a propriedade [AdvanceAfter](https://reference.aspose.com/slides/pt/net/aspose.slides/islideshowtransition/advanceafter/), você pode verificar se uma transição de slide foi configurada para avançar para o próximo slide ou desativar a configuração.

Este código C# demonstra a operação:

```c#
 // Instancia uma classe Presentation que representa um arquivo de apresentação
 using (Presentation pres = new Presentation("SampleTransition_out.pptx"))
 {
     foreach (ISlide slide in pres.Slides)
     {
         // Obtém a transição do slide
         ISlideShowTransition slideTransition = slide.SlideShowTransition;

         // Verifica se a configuração Avançar após o tempo está habilitada
         if (slideTransition.AdvanceAfter)
         {
             // Imprime o valor de Avançar após o tempo
             Console.WriteLine("The slide #" + slide.SlideNumber + " AdvancedAfterTime: " + slideTransition.AdvanceAfterTime);
         }

         // Desativa a transição após um tempo específico se o valor AdvancedAfterTime for maior que 2 segundos
         if (slideTransition.AdvanceAfterTime > 2000)
         {
             slideTransition.AdvanceAfter = false;
         }
     }
 }
```

## **Transição Morph**
Aspose.Slides for .NET agora oferece suporte à [Morph Transition](https://reference.aspose.com/slides/pt/net/aspose.slides.slideshow/imorphtransition). Elas representam uma nova transição morph introduzida no PowerPoint 2019. A transição Morph permite animar o movimento suave de um slide para o próximo. Este artigo descreve o conceito e como usar a transição Morph. Para usar a transição Morph de forma eficaz, você precisará de dois slides com pelo menos um objeto em comum. A maneira mais fácil é duplicar o slide e, em seguida, mover o objeto no segundo slide para outro local.

O trecho de código a seguir mostra como adicionar um clone do slide com algum texto à apresentação e definir uma transição de [tipo morph](https://reference.aspose.com/slides/pt/net/aspose.slides.slideshow/imorphtransition/properties/morphtype) para o segundo slide.

```c#
using (Presentation presentation = new Presentation())
{
    AutoShape autoshape = (AutoShape)presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.TextFrame.Text = "Morph Transition in PowerPoint Presentations";

    presentation.Slides.AddClone(presentation.Slides[0]);

    presentation.Slides[1].Shapes[0].X += 100;
    presentation.Slides[1].Shapes[0].Y += 50;
    presentation.Slides[1].Shapes[0].Width -= 200;
    presentation.Slides[1].Shapes[0].Height -= 10;

    presentation.Slides[1].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Morph;

    presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```

## **Tipos de transição Morph**
Foi adicionado o novo enum [Aspose.Slides.SlideShow.TransitionMorphType](https://reference.aspose.com/slides/pt/net/aspose.slides.slideshow/transitionmorphtype). Ele representa diferentes tipos de transição de slide Morph.

O enum TransitionMorphType possui três membros:

- ByObject: a transição Morph será realizada considerando as formas como objetos indivisíveis.
- ByWord: a transição Morph será realizada transferindo o texto por palavras, quando possível.
- ByChar: a transição Morph será realizada transferindo o texto por caracteres, quando possível.

O trecho de código a seguir mostra como definir a transição morph para um slide e alterar o tipo morph:

```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Morph;
    ((IMorphTransition)presentation.Slides[0].SlideShowTransition.Value).MorphType = TransitionMorphType.ByWord;
    presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```

## **Definir efeitos de transição**
Aspose.Slides for .NET oferece suporte à definição de efeitos de transição, como de preto, da esquerda, da direita etc. Para definir o Efeito de Transição, siga os passos abaixo:

- Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation).
- Obtenha a referência do slide.
- Defina o efeito de transição.
- Grave a apresentação como um arquivo [PPTX](https://docs.fileformat.com/presentation/pptx/).

No exemplo abaixo, definimos os efeitos de transição.

```c#
// Criar uma instância da classe Presentation
Presentation presentation = new Presentation("AccessSlides.pptx");

// Definir efeito
presentation.Slides[0].SlideShowTransition.Type = TransitionType.Cut;
((OptionalBlackTransition)presentation.Slides[0].SlideShowTransition.Value).FromBlack = true;

// Gravar a apresentação no disco
presentation.Save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
```

## **Perguntas frequentes**

**Posso controlar a velocidade de reprodução de uma transição de slide?**

Sim. Defina a [Speed](https://reference.aspose.com/slides/pt/net/aspose.slides.slideshow/slideshowtransition/speed/) da transição usando a configuração [TransitionSpeed](https://reference.aspose.com/slides/pt/net/aspose.slides.slideshow/transitionspeed/) (por exemplo, slow/medium/fast).

**Posso anexar áudio a uma transição e fazer loop?**

Sim. Você pode incorporar um som à transição e controlar o comportamento por meio de configurações como modo de som e repetição (por exemplo, [Sound](https://reference.aspose.com/slides/pt/net/aspose.slides.slideshow/slideshowtransition/sound/), [SoundMode](https://reference.aspose.com/slides/pt/net/aspose.slides.slideshow/slideshowtransition/soundmode/), [SoundLoop](https://reference.aspose.com/slides/pt/net/aspose.slides.slideshow/slideshowtransition/soundloop/), além de metadados como [SoundIsBuiltIn](https://reference.aspose.com/slides/pt/net/aspose.slides.slideshow/slideshowtransition/soundisbuiltin/) e [SoundName](https://reference.aspose.com/slides/pt/net/aspose.slides.slideshow/slideshowtransition/soundname/)).

**Qual a maneira mais rápida de aplicar a mesma transição a todos os slides?**

Configure o tipo de transição desejado nas configurações de transição de cada slide; as transições são armazenadas por slide, portanto aplicar o mesmo tipo a todos os slides produz um resultado consistente.

**Como posso verificar qual transição está atualmente definida em um slide?**

Inspecione as [configurações de transição](https://reference.aspose.com/slides/pt/net/aspose.slides/baseslide/slideshowtransition/) do slide e leia seu [tipo de transição](https://reference.aspose.com/slides/pt/net/aspose.slides.slideshow/slideshowtransition/type/); esse valor indica exatamente qual efeito está aplicado.