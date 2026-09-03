---
title: Gerenciar Transições de Slides em Apresentações em .NET
linktitle: Transição de Slide
type: docs
weight: 90
url: /pt/net/slide-transition/
keywords:
- transição de slide
- adicionar transição de slide
- aplicar transição de slide
- transição avançada de slide
- transição morph
- tipo de transição
- efeito de transição
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Aplicar transições de slide, configurar o avanço automático de slides e personalizar Morph e outros efeitos de transição com Aspose.Slides para .NET."
---
## **Visão geral**

As transições de slides controlam como os slides aparecem durante uma apresentação. Com Aspose.Slides para .NET, você pode escolher um efeito de transição para cada slide, configurar o avanço por clique do mouse ou timer, e ajustar opções específicas de um efeito. Este artigo usa exemplos em C# para aplicar transições, definir durações exatas de transição, gerenciar o tempo dos slides e criar uma transição Morph entre dois slides. Os exemplos também mostram como salvar as configurações em um arquivo PPTX.

## **Adicionar transição de slide**

Para aplicar uma transição, carregue uma apresentação com a classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/) e acesse a propriedade [SlideShowTransition](https://reference.aspose.com/slides/pt/net/aspose.slides/ibaseslide/slideshowtransition/) do slide. Defina seu [Type](https://reference.aspose.com/slides/pt/net/aspose.slides/islideshowtransition/type/) para um valor da enumeração [TransitionType](https://reference.aspose.com/slides/pt/net/aspose.slides.slideshow/transitiontype/), então salve a apresentação.

O exemplo a seguir aplica uma transição Circle ao primeiro slide e uma transição Comb ao segundo. Use um arquivo `input.pptx` com pelo menos dois slides.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

if (presentation.Slides.Count >= 2)
{
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Circle;
    presentation.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    presentation.Save("slide-transitions.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The input presentation must contain at least two slides.");
}
```

## **Adicionar transição avançada de slide**

Você pode configurar por quanto tempo um slide permanece na tela e se um clique do mouse avança a apresentação. As propriedades a seguir controlam esse comportamento:

- [AdvanceOnClick](https://reference.aspose.com/slides/pt/net/aspose.slides/islideshowtransition/advanceonclick/) permite que o visualizador avance clicando o mouse.
- [AdvanceAfter](https://reference.aspose.com/slides/pt/net/aspose.slides/islideshowtransition/advanceafter/) habilita o avanço automático.
- [AdvanceAfterTime](https://reference.aspose.com/slides/pt/net/aspose.slides/islideshowtransition/advanceaftertime/) especifica o atraso antes do avanço automático, em milissegundos.

Habilite tanto o avanço por clique quanto o avançado por tempo para permitir que o visualizador avance com um clique ou espere o temporizador. Para usar apenas o temporizador, defina [AdvanceOnClick](https://reference.aspose.com/slides/pt/net/aspose.slides/islideshowtransition/advanceonclick/) como `false`. O atraso controla quando a apresentação avança; ele não define a duração do efeito visual de transição.

Este exemplo atribui efeitos diferentes aos três primeiros slides e habilita o avanço automático após 3, 5 e 7 segundos, respectivamente. Cliques do mouse também podem avançar esses slides. Use um arquivo `input.pptx` com pelo menos três slides.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

if (presentation.Slides.Count >= 3)
{
    var firstTransition = presentation.Slides[0].SlideShowTransition;
    firstTransition.Type = TransitionType.Circle;
    firstTransition.AdvanceOnClick = true;
    firstTransition.AdvanceAfter = true;
    firstTransition.AdvanceAfterTime = 3000;

    var secondTransition = presentation.Slides[1].SlideShowTransition;
    secondTransition.Type = TransitionType.Comb;
    secondTransition.AdvanceOnClick = true;
    secondTransition.AdvanceAfter = true;
    secondTransition.AdvanceAfterTime = 5000;

    var thirdTransition = presentation.Slides[2].SlideShowTransition;
    thirdTransition.Type = TransitionType.Zoom;
    thirdTransition.AdvanceOnClick = true;
    thirdTransition.AdvanceAfter = true;
    thirdTransition.AdvanceAfterTime = 7000;

    presentation.Save("advanced-transitions.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The input presentation must contain at least three slides.");
}
```

Para verificar se o avanço cronometrado está habilitado, leia [AdvanceAfter](https://reference.aspose.com/slides/pt/net/aspose.slides/islideshowtransition/advanceafter/). Um atraso armazenado sozinho não indica que o temporizador está ativo.

O exemplo a seguir abre o arquivo salvo acima, relata cada temporizador habilitado e desabilita o avanço automático para slides com atraso superior a dois segundos. Ele habilita cliques do mouse para esses slides e salva as configurações atualizadas.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("advanced-transitions.pptx");

foreach (var slide in presentation.Slides)
{
    var transition = slide.SlideShowTransition;

    if (transition.AdvanceAfter)
    {
        Console.WriteLine($"Slide {slide.SlideNumber}: advance after {transition.AdvanceAfterTime} ms.");

        if (transition.AdvanceAfterTime > 2000)
        {
            transition.AdvanceAfter = false;
            transition.AdvanceOnClick = true;
        }
    }
}

presentation.Save("adjusted-transitions.pptx", SaveFormat.Pptx);
```

## **Controlar o tempo da transição com precisão**

Use [Duration](https://reference.aspose.com/slides/pt/net/aspose.slides.slideshow/slideshowtransition/duration/) para especificar o comprimento exato de um efeito de transição em milissegundos. A propriedade [SlideShowTransition](https://reference.aspose.com/slides/pt/net/aspose.slides/ibaseslide/slideshowtransition/) do slide expõe essas configurações por meio de [ISlideShowTransition](https://reference.aspose.com/slides/pt/net/aspose.slides/islideshowtransition/):

| Propriedade | Objetivo |
| --- | --- |
| [Duration](https://reference.aspose.com/slides/pt/net/aspose.slides.slideshow/slideshowtransition/duration/) | Define a duração do próprio efeito de transição, em milissegundos. |
| [AdvanceAfterTime](https://reference.aspose.com/slides/pt/net/aspose.slides.slideshow/slideshowtransition/advanceaftertime/) | Define o atraso antes que o slide avance automaticamente, em milissegundos. Habilite [AdvanceAfter](https://reference.aspose.com/slides/pt/net/aspose.slides/islideshowtransition/advanceafter/) para ativar esse temporizador. |
| [Speed](https://reference.aspose.com/slides/pt/net/aspose.slides.slideshow/slideshowtransition/speed/) | Seleciona uma categoria de velocidade predefinida da [TransitionSpeed](https://reference.aspose.com/slides/pt/net/aspose.slides.slideshow/transitionspeed/): Slow, Medium ou Fast. É usado quando uma duração exata não é especificada. |

[Duration](https://reference.aspose.com/slides/pt/net/aspose.slides.slideshow/slideshowtransition/duration/) controla apenas o efeito de transição; ele não determina por quanto tempo o slide permanece visível. Configure o atraso de avanço automático separadamente. Quando nenhuma duração explícita é definida, Aspose.Slides determina a duração do efeito a partir do tipo de transição e do valor de [Speed](https://reference.aspose.com/slides/pt/net/aspose.slides.slideshow/slideshowtransition/speed/).

### **Aplicar a mesma duração a todos os slides**

Para um ritmo consistente, aplique o mesmo efeito e a mesma duração exata a todos os slides. Este exemplo carrega `input.pptx`, seleciona Fade da [TransitionType](https://reference.aspose.com/slides/pt/net/aspose.slides.slideshow/transitiontype/) e atribui a cada transição uma duração de 750 milissegundos. Ele habilita separadamente o avanço automático após 5 000 milissegundos e desabilita o avanço por clique do mouse, então salva o resultado como PPTX.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

foreach (var slide in presentation.Slides)
{
    var transition = slide.SlideShowTransition;
    transition.Type = TransitionType.Fade;
    transition.Duration = 750;

    // Configurar avanço automático independentemente da duração do efeito.
    transition.AdvanceAfter = true;
    transition.AdvanceAfterTime = 5000;
    transition.AdvanceOnClick = false;
}

presentation.Save("precise-transitions.pptx", SaveFormat.Pptx);
```

### **Definir durações diferentes para slides individuais**

Slides diferentes podem usar durações de efeito diferentes. Por exemplo, use uma transição breve para um slide de título e uma transição mais longa para a introdução de uma seção. Este exemplo define 500 milissegundos para o primeiro slide e 1 200 milissegundos para o segundo. Use um arquivo `input.pptx` com pelo menos dois slides.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

if (presentation.Slides.Count >= 2)
{
    var firstTransition = presentation.Slides[0].SlideShowTransition;
    firstTransition.Type = TransitionType.Fade;
    firstTransition.Duration = 500;

    var secondTransition = presentation.Slides[1].SlideShowTransition;
    secondTransition.Type = TransitionType.Push;
    secondTransition.Duration = 1200;

    presentation.Save("individual-transition-durations.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The input presentation must contain at least two slides.");
}
```

### **Coordenar transições com saída animada**

Ao preparar um [animated GIF](/slides/pt/net/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/pt/net/export-to-html5/) ou [video](/slides/pt/net/convert-powerpoint-to-video/), defina durações exatas de transição antes da exportação para corresponder ao ritmo desejado. Por exemplo, use um fade de 600 milissegundos entre cenas e ajuste separadamente o atraso de avanço de cada slide para permitir tempo para narração ou conteúdo.

Para GIF e vídeo, coordenar a taxa de quadros da saída com a duração do efeito: 600 milissegundos correspondem a 18 quadros a 30 quadros por segundo. No HTML5, habilite transições animadas nas configurações de exportação. Verifique os efeitos e opções de tempo suportados pelo formato de exportação escolhido e visualize a saída para confirmar a sincronização.

### **Ler a duração de transição existente**

Leia [Duration](https://reference.aspose.com/slides/pt/net/aspose.slides.slideshow/slideshowtransition/duration/) antes de modificar a transição para determinar se um valor explícito está armazenado. Um valor de `-1` indica que nenhuma duração explícita foi definida; um valor não negativo especifica a duração armazenada em milissegundos. O valor não definido não é a duração de reprodução calculada: Aspose.Slides usa o tipo de transição e [Speed](https://reference.aspose.com/slides/pt/net/aspose.slides.slideshow/slideshowtransition/speed/) para determinar essa duração. Definir um tipo de transição pode inicializar uma duração, portanto examine as configurações originais primeiro.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");

foreach (var slide in presentation.Slides)
{
    var transition = slide.SlideShowTransition;
    var duration = transition.Duration;

    if (duration >= 0)
    {
        Console.WriteLine($"Slide {slide.SlideNumber}: stored transition duration is {duration} ms.");
    }
    else
    {
        Console.WriteLine($"Slide {slide.SlideNumber}: no explicit duration; timing depends on {transition.Type} and {transition.Speed}.");
    }
}
```

## **Transição Morph**

A transição Morph anima mudanças entre objetos em slides consecutivos. Para criar um efeito Morph simples, clone um slide, mova ou redimensione um objeto no clone e aplique a transição Morph ao segundo slide. Isso fornece aos objetos correspondentes a animação entre seus estados original e modificado.

O exemplo a seguir cria um slide com um retângulo de texto, clona o slide e altera a posição e o tamanho do retângulo no clone. Em seguida, seleciona Morph da enumeração [TransitionType](https://reference.aspose.com/slides/pt/net/aspose.slides.slideshow/transitiontype/) para o segundo slide. Abra o arquivo salvo em um visualizador de apresentações que suporte Morph para ver o efeito durante a apresentação.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation();

var firstSlide = presentation.Slides[0];
var rectangle = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
rectangle.TextFrame.Text = "Morph transition";

var secondSlide = presentation.Slides.AddClone(firstSlide);
var movedRectangle = secondSlide.Shapes[0];
movedRectangle.X += 100;
movedRectangle.Y += 50;
movedRectangle.Width -= 200;
movedRectangle.Height -= 10;

secondSlide.SlideShowTransition.Type = TransitionType.Morph;

presentation.Save("morph-transition.pptx", SaveFormat.Pptx);
```

## **Tipos de transição Morph**

A enumeração [TransitionMorphType](https://reference.aspose.com/slides/pt/net/aspose.slides.slideshow/transitionmorphtype/) controla como o Morph corresponde e anima o conteúdo:

- [ByObject](https://reference.aspose.com/slides/pt/net/aspose.slides.slideshow/transitionmorphtype/) trata cada forma como um objeto inteiro.
- [ByWord](https://reference.aspose.com/slides/pt/net/aspose.slides.slideshow/transitionmorphtype/) anima o texto correspondendo palavras quando possível.
- [ByChar](https://reference.aspose.com/slides/pt/net/aspose.slides.slideshow/transitionmorphtype/) anima o texto correspondendo caracteres quando possível.

Defina a transição [Type](https://reference.aspose.com/slides/pt/net/aspose.slides/islideshowtransition/type/) como Morph antes de acessar seu [Value](https://reference.aspose.com/slides/pt/net/aspose.slides/islideshowtransition/value/). O valor então fornece a interface [IMorphTransition](https://reference.aspose.com/slides/pt/net/aspose.slides.slideshow/imorphtransition/), cuja propriedade [MorphType](https://reference.aspose.com/slides/pt/net/aspose.slides.slideshow/imorphtransition/morphtype/) seleciona o modo de correspondência.

Este exemplo abre a apresentação criada na seção anterior e configura o segundo slide para usar animação Morph baseada em palavras.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("morph-transition.pptx");

if (presentation.Slides.Count >= 2)
{
    var transition = presentation.Slides[1].SlideShowTransition;
    transition.Type = TransitionType.Morph;

    if (transition.Value is IMorphTransition morphTransition)
    {
        morphTransition.MorphType = TransitionMorphType.ByWord;
        presentation.Save("morph-by-word.pptx", SaveFormat.Pptx);
    }
    else
    {
        Console.WriteLine("Morph transition options are unavailable.");
    }
}
else
{
    Console.WriteLine("The input presentation must contain at least two slides.");
}
```

## **Definir efeitos de transição**

Algumas transições expõem opções adicionais, como direção ou se o efeito começa a partir de uma tela preta. As opções disponíveis dependem do [Type](https://reference.aspose.com/slides/pt/net/aspose.slides/islideshowtransition/type/) de transição selecionado. Defina o tipo primeiro, depois use a interface apropriada obtida via seu [Value](https://reference.aspose.com/slides/pt/net/aspose.slides/islideshowtransition/value/).

O exemplo a seguir aplica uma transição Cut ao primeiro slide de `input.pptx`. Ele define [FromBlack](https://reference.aspose.com/slides/pt/net/aspose.slides.slideshow/ioptionalblacktransition/fromblack/) através de [IOptionalBlackTransition](https://reference.aspose.com/slides/pt/net/aspose.slides.slideshow/ioptionalblacktransition/) para que a transição comece a partir de uma tela preta.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");
var transition = presentation.Slides[0].SlideShowTransition;
transition.Type = TransitionType.Cut;

if (transition.Value is IOptionalBlackTransition cutTransition)
{
    cutTransition.FromBlack = true;
    presentation.Save("cut-from-black.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("Cut transition options are unavailable.");
}
```

## **FAQ**

**Posso controlar a velocidade de reprodução de uma transição de slide?**

Sim. Prefira [Duration](https://reference.aspose.com/slides/pt/net/aspose.slides.slideshow/slideshowtransition/duration/) quando precisar de uma duração exata do efeito em milissegundos. Use [Speed](https://reference.aspose.com/slides/pt/net/aspose.slides.slideshow/slideshowtransition/speed/) quando uma categoria predefinida de [TransitionSpeed](https://reference.aspose.com/slides/pt/net/aspose.slides.slideshow/transitionspeed/) — Slow, Medium ou Fast — for suficiente e nenhuma duração explícita for definida. Essas configurações controlam o efeito de transição independentemente do atraso de avanço automático.

**Posso anexar áudio a uma transição e fazê-lo em loop?**

Sim. Atribua áudio incorporado a [Sound](https://reference.aspose.com/slides/pt/net/aspose.slides/islideshowtransition/sound/), defina [SoundMode](https://reference.aspose.com/slides/pt/net/aspose.slides/islideshowtransition/soundmode/) como StartSound a partir da enumeração [TransitionSoundMode](https://reference.aspose.com/slides/pt/net/aspose.slides.slideshow/transitionsoundmode/), e habilite [SoundLoop](https://reference.aspose.com/slides/pt/net/aspose.slides/islideshowtransition/soundloop/). O áudio entra em loop até o próximo evento sonoro na apresentação.

**Qual a maneira mais rápida de aplicar a mesma transição a todos os slides?**

Percorra a coleção [Slides](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/slides/pt/) da apresentação e defina o [Type](https://reference.aspose.com/slides/pt/net/aspose.slides/islideshowtransition/type/) de transição de cada slide para o mesmo valor. Defina quaisquer opções de tempo e efeito dentro do mesmo loop para manter o comportamento consistente entre os slides.

**Como posso verificar qual transição está definida atualmente em um slide?**

Leia a propriedade [Type](https://reference.aspose.com/slides/pt/net/aspose.slides/islideshowtransition/type/) do [SlideShowTransition](https://reference.aspose.com/slides/pt/net/aspose.slides/ibaseslide/slideshowtransition/) do slide. Ela devolve um valor da enumeração [TransitionType](https://reference.aspose.com/slides/pt/net/aspose.slides.slideshow/transitiontype/); None indica que nenhum efeito de transição foi aplicado.