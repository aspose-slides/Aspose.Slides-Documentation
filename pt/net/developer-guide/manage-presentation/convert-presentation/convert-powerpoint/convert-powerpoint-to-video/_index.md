---
title: Converter apresentações PowerPoint em vídeo no .NET
linktitle: PowerPoint para Vídeo
type: docs
weight: 130
url: /pt/net/convert-powerpoint-to-video/
keywords:
- converter PowerPoint
- converter apresentação
- converter PPT
- converter PPTX
- PowerPoint para vídeo
- apresentação para vídeo
- PPT para vídeo
- PPTX para vídeo
- PowerPoint para MP4
- apresentação para MP4
- PPT para MP4
- PPTX para MP4
- salvar PPT como MP4
- salvar PPTX como MP4
- exportar PPT para MP4
- exportar PPTX para MP4
- conversão de vídeo
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: "Aprenda como converter apresentações PowerPoint em vídeo no .NET. Descubra código de exemplo em C# e técnicas de automação para otimizar seu fluxo de trabalho."
---
## **Introdução**

Ao converter sua apresentação PowerPoint ou OpenDocument em vídeo, você obtém:

**Acessibilidade aumentada:** Todos os dispositivos, independentemente da plataforma, vêm equipados com reprodutores de vídeo por padrão, facilitando a abertura ou reprodução de vídeos em comparação com aplicativos de apresentação tradicionais.

**Alcance ampliado:** Os vídeos permitem alcançar um público maior e apresentar informações de forma mais envolvente. Pesquisas e estatísticas indicam que as pessoas preferem assistir e consumir conteúdo em vídeo em vez de outros formatos, tornando sua mensagem mais impactante.

{{% alert color="info" %}} 

Confira nosso [**Conversor Online de PowerPoint para Vídeo**](https://products.aspose.app/slides/pt/video) porque ele oferece uma implementação ao vivo e eficaz do processo descrito aqui.

{{% /alert %}} 

No Aspose.Slides para .NET, implementamos suporte para converter apresentações em vídeo.

* Use Aspose.Slides for .NET para gerar quadros a partir dos slides da apresentação em uma taxa de quadros (FPS) especificada.
* Em seguida, use um utilitário de terceiros como ffmpeg para compilar esses quadros em um vídeo.

## **Converter uma Apresentação PowerPoint em Vídeo**

1. Use o comando `dotnet add package` para adicionar o Aspose.Slides e a biblioteca FFMpegCore ao seu projeto:
   * execute `dotnet add package Aspose.Slides.NET --version 22.11.0`
   * execute `dotnet add package FFMpegCore --version 4.8.0`
2. Faça o download do ffmpeg de [aqui](https://ffmpeg.org/download.html).
3. FFMpegCore requer que você especifique o caminho para o ffmpeg baixado (por exemplo, extraído para "C:\tools\ffmpeg"):  
```cs
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });
```
4. Execute o código de conversão de PowerPoint para vídeo.

Este código C# demonstra como converter uma apresentação (contendo uma forma e dois efeitos de animação) em um vídeo:

```c#
using System.Collections.Generic;
using Aspose.Slides;
using FFMpegCore; // usará os binários FFmpeg que extraímos para C:\tools\ffmpeg anteriormente.
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Adicione uma forma de sorriso e então anime-a.
    IAutoShape smile = slide.Shapes.AddAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);

    IEffect effectIn = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);

    IEffect effectOut = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);

    effectIn.Timing.Duration = 2f;
    effectOut.PresetClassType = EffectPresetClassType.Exit;

    const int Fps = 33;
    List<string> frames = new List<string>();

    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    using (var player = new PresentationPlayer(animationsGenerator, Fps))
    {
        player.FrameTick += (sender, args) =>
        {
            string frame = $"frame_{(sender.FrameIndex):D4}.png";
            args.GetFrame().Save(frame);
            frames.Add(frame);
        };
        animationsGenerator.Run(presentation.Slides);
    }

    // Configure a pasta dos binários ffmpeg. Veja esta página: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // Converta os quadros em um vídeo webm.
    FFMpeg.JoinImageSequence("smile.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```

## **Efeitos de Vídeo**

Ao converter uma apresentação PowerPoint em vídeo usando Aspose.Slides para .NET, você pode aplicar vários efeitos de vídeo para melhorar a qualidade visual da saída. Esses efeitos permitem controlar a aparência dos slides no vídeo final, adicionando transições suaves, animações e outros elementos visuais. Esta seção explica as opções de efeitos de vídeo disponíveis e mostra como aplicá-las.

{{% alert color="info" %}} 

Veja:
- [Aprimorando Apresentações PowerPoint com Animações em C#](https://docs.aspose.com/slides/pt/net/powerpoint-animation/)
- [Animação de Forma](https://docs.aspose.com/slides/pt/net/shape-animation/)
- [Aplicar Efeitos de Forma no PowerPoint Usando C#](https://docs.aspose.com/slides/pt/net/shape-effect/)

{{% /alert %}} 

Animações e transições tornam as apresentações de slides mais envolventes e interessantes — e fazem o mesmo para vídeos. Vamos adicionar outro slide e transição ao código da apresentação anterior:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.SlideShow;

using (Presentation presentation = new Presentation())
{
    // Adicione uma forma de sorriso e anime-a (veja o código acima).

    // Adicione um novo slide e uma transição animada.
    ISlide newSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
    newSlide.Background.Type = BackgroundType.OwnBackground;
    newSlide.Background.FillFormat.FillType = FillType.Solid;
    newSlide.Background.FillFormat.SolidFillColor.Color = Color.Indigo;
    newSlide.SlideShowTransition.Type = TransitionType.Push;
}
```

O Aspose.Slides também oferece suporte a animações de texto. Neste exemplo, animamos parágrafos em objetos para que apareçam um após o outro, com um atraso de um segundo entre eles:

```c#
using System.Collections.Generic;
using Aspose.Slides.Export;
using Aspose.Slides;
using FFMpegCore;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Adicione texto e animações.
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 120, 300, 300);
    Paragraph para1 = new Paragraph();
    para1.Portions.Add(new Portion("Aspose Slides for .NET"));
    Paragraph para2 = new Paragraph();
    para2.Portions.Add(new Portion("Convert a PowerPoint presentation with text to video"));

    Paragraph para3 = new Paragraph();
    para3.Portions.Add(new Portion("paragraph by paragraph"));
    autoShape.TextFrame.Paragraphs.Add(para1);
    autoShape.TextFrame.Paragraphs.Add(para2);
    autoShape.TextFrame.Paragraphs.Add(para3);
    autoShape.TextFrame.Paragraphs.Add(new Paragraph());

    IEffect effect1 = slide.Timeline.MainSequence.AddEffect(
        para1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect2 = slide.Timeline.MainSequence.AddEffect(
        para2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect3 = slide.Timeline.MainSequence.AddEffect(
        para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect4 = slide.Timeline.MainSequence.AddEffect(
        para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    effect1.Timing.TriggerDelayTime = 1f;
    effect2.Timing.TriggerDelayTime = 1f;
    effect3.Timing.TriggerDelayTime = 1f;
    effect4.Timing.TriggerDelayTime = 1f;

    const int Fps = 33;
    List<string> frames = new List<string>();

    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    using (var player = new PresentationPlayer(animationsGenerator, Fps))
    {
        player.FrameTick += (sender, args) =>
        {
            string frame = $"frame_{(sender.FrameIndex):D4}.png";
            args.GetFrame().Save(frame);
            frames.Add(frame);
        };

        animationsGenerator.Run(presentation.Slides);
    }

    // Configure a pasta dos binários ffmpeg. Veja esta página: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // Converta os quadros em um vídeo webm.
    FFMpeg.JoinImageSequence("text_animation.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```

## **Classes de Conversão de Vídeo**

Para habilitar tarefas de conversão de PowerPoint para vídeo, o Aspose.Slides para .NET fornece as classes [PresentationAnimationsGenerator](https://reference.aspose.com/slides/pt/net/aspose.slides.export/presentationanimationsgenerator/) e [PresentationPlayer](https://reference.aspose.com/slides/pt/net/aspose.slides.export/presentationplayer/).

`PresentationAnimationsGenerator` permite definir o tamanho do quadro para o vídeo (que será criado posteriormente) e o valor FPS (quadros por segundo) por meio de seu construtor. Se você passar uma instância de uma apresentação, seu `Presentation.SlideSize` será usado e ele gera animações que [PresentationPlayer](https://reference.aspose.com/slides/pt/net/aspose.slides.export/presentationplayer/) utiliza.

Quando as animações são geradas, um evento `NewAnimation` é disparado para cada animação subsequente, que inclui um parâmetro [IPresentationAnimationPlayer](https://reference.aspose.com/slides/pt/net/aspose.slides.export/ipresentationanimationplayer/). Esta classe representa um reprodutor para uma animação individual.

Para trabalhar com [IPresentationAnimationPlayer](https://reference.aspose.com/slides/pt/net/aspose.slides.export/ipresentationanimationplayer/), use a propriedade [Duration](https://reference.aspose.com/slides/pt/net/aspose.slides.export/ipresentationanimationplayer/duration/) (que fornece a duração total da animação) e o método [SetTimePosition](https://reference.aspose.com/slides/pt/net/aspose.slides.export/ipresentationanimationplayer/settimeposition/). Cada posição de animação é definida dentro do intervalo *0 a duration*, e o método `GetFrame` devolve um Bitmap que representa o estado da animação naquele ponto no tempo.

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Adicione uma forma de sorriso e anime-a.
    IAutoShape smile = slide.Shapes.AddAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);

    IEffect effectIn = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);

    IEffect effectOut = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);

    effectIn.Timing.Duration = 2f;
    effectOut.PresetClassType = EffectPresetClassType.Exit;

    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    {
        animationsGenerator.NewAnimation += animationPlayer =>
        {
            Console.WriteLine($"Total animation duration: {animationPlayer.Duration}");

            animationPlayer.SetTimePosition(0);        // O estado inicial da animação.
            IImage image = animationPlayer.GetFrame(); // A imagem do estado inicial da animação.

            animationPlayer.SetTimePosition(animationPlayer.Duration); // O estado final da animação.
            IImage lastImage = animationPlayer.GetFrame();             // O último quadro da animação.
            lastImage.Save("last.png");
        };
    }
}
```

Para fazer com que todas as animações de uma apresentação sejam reproduzidas simultaneamente, utiliza‑se a classe [PresentationPlayer](https://reference.aspose.com/slides/pt/net/aspose.slides.export/presentationplayer/). Esta classe recebe uma instância de [PresentationAnimationsGenerator](https://reference.aspose.com/slides/pt/net/aspose.slides.export/presentationanimationsgenerator/) e um valor FPS para os efeitos em seu construtor, e então chama o evento `FrameTick` para todas as animações reproduzi‑las:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("animated.pptx"))
{
    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    using (var player = new PresentationPlayer(animationsGenerator, 33))
    {
        player.FrameTick += (sender, args) =>
        {
            args.GetFrame().Save($"frame_{sender.FrameIndex}.png");
        };
        animationsGenerator.Run(presentation.Slides);
    }
}
```

Em seguida, os quadros gerados podem ser compilados para produzir um vídeo. Consulte a seção [Converter uma Apresentação PowerPoint em Vídeo](/slides/pt/net/convert-powerpoint-to-video/#convert-a-powerpoint-presentation-to-video).

## **Animações e Efeitos Suportados**

Ao converter uma apresentação PowerPoint em vídeo usando Aspose.Slides para .NET, é importante entender quais animações e efeitos são suportados na saída. O Aspose.Slides oferece uma ampla gama de efeitos comuns de entrada, saída e ênfase, como fade, fly in, zoom e spin. No entanto, algumas animações avançadas ou personalizadas podem não ser totalmente preservadas ou podem aparecer de forma diferente no vídeo final. Esta seção descreve as animações e efeitos suportados.

**Entrada**:

| Tipo de Animação | Aspose.Slides | PowerPoint |
|---|---|---|
| **Aparecer** | ![not supported](x.png) | ![supported](v.png) |
| **Desvanecer** | ![supported](v.png) | ![supported](v.png) |
| **Voar para Dentro** | ![supported](v.png) | ![supported](v.png) |
| **Flutuar para Dentro** | ![supported](v.png) | ![supported](v.png) |
| **Dividir** | ![supported](v.png) | ![supported](v.png) |
| **Varredura** | ![supported](v.png) | ![supported](v.png) |
| **Forma** | ![supported](v.png) | ![supported](v.png) |
| **Roda** | ![supported](v.png) | ![supported](v.png) |
| **Barras Aleatórias** | ![supported](v.png) | ![supported](v.png) |
| **Crescer e Girar** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Girar** | ![supported](v.png) | ![supported](v.png) |
| **Saltar** | ![supported](v.png) | ![supported](v.png) |

**Ênfase**:

| Tipo de Animação | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulsar** | ![not supported](x.png) | ![supported](v.png) |
| **Pulsação de Cor** | ![not supported](x.png) | ![supported](v.png) |
| **Oscilar** | ![supported](v.png) | ![supported](v.png) |
| **Girar** | ![supported](v.png) | ![supported](v.png) |
| **Crescer/Encolher** | ![not supported](x.png) | ![supported](v.png) |
| **Dessaturar** | ![not supported](x.png) | ![supported](v.png) |
| **Escurecer** | ![not supported](x.png) | ![supported](v.png) |
| **Clarear** | ![not supported](x.png) | ![supported](v.png) |
| **Transparência** | ![not supported](x.png) | ![supported](v.png) |
| **Cor do Objeto** | ![not supported](x.png) | ![supported](v.png) |
| **Cor Complementar** | ![not supported](x.png) | ![supported](v.png) |
| **Cor da Linha** | ![not supported](x.png) | ![supported](v.png) |
| **Cor de Preenchimento** | ![not supported](x.png) | ![supported](v.png) |

**Saída**:

| Tipo de Animação | Aspose.Slides | PowerPoint |
|---|---|---|
| **Desaparecer** | ![not supported](x.png) | ![supported](v.png) |
| **Desvanecer** | ![supported](v.png) | ![supported](v.png) |
| **Voar para Fora** | ![supported](v.png) | ![supported](v.png) |
| **Flutuar para Fora** | ![supported](v.png) | ![supported](v.png) |
| **Dividir** | ![supported](v.png) | ![supported](v.png) |
| **Varredura** | ![supported](v.png) | ![supported](v.png) |
| **Forma** | ![supported](v.png) | ![supported](v.png) |
| **Barras Aleatórias** | ![supported](v.png) | ![supported](v.png) |
| **Encolher e Girar** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Girar** | ![supported](v.png) | ![supported](v.png) |
| **Saltar** | ![supported](v.png) | ![supported](v.png) |

**Caminhos de Movimento**:

| Tipo de Animação | Aspose.Slides | PowerPoint |
|---|---|---|
| **Linhas** | ![supported](v.png) | ![supported](v.png) |
| **Arcos** | ![supported](v.png) | ![supported](v.png) |
| **Curvas** | ![supported](v.png) | ![supported](v.png) |
| **Formas** | ![supported](v.png) | ![supported](v.png) |
| **Laços** | ![supported](v.png) | ![supported](v.png) |
| **Caminho Personalizado** | ![supported](v.png) | ![supported](v.png) |

## **Efeitos de Transição de Slide Suportados**

Os efeitos de transição de slide desempenham um papel importante na criação de mudanças suaves e visualmente atraentes entre slides em um vídeo. O Aspose.Slides para .NET oferece uma variedade de efeitos de transição comumente usados para ajudar a preservar o fluxo e o estilo da sua apresentação original. Esta seção destaca quais efeitos de transição são suportados durante o processo de conversão.

**Sutil**:

| Tipo de Animação | Aspose.Slides | PowerPoint |
|---|---|---|
| **Transformar** | ![not supported](x.png) | ![supported](v.png) |
| **Desvanecer** | ![supported](v.png) | ![supported](v.png) |
| **Empurrar** | ![supported](v.png) | ![supported](v.png) |
| **Puxar** | ![supported](v.png) | ![supported](v.png) |
| **Varredura** | ![supported](v.png) | ![supported](v.png) |
| **Dividir** | ![supported](v.png) | ![supported](v.png) |
| **Revelar** | ![not supported](x.png) | ![supported](v.png) |
| **Barras Aleatórias** | ![supported](v.png) | ![supported](v.png) |
| **Forma** | ![not supported](x.png) | ![supported](v.png) |
| **Descobrir** | ![not supported](x.png) | ![supported](v.png) |
| **Cobrir** | ![supported](v.png) | ![supported](v.png) |
| **Flash** | ![supported](v.png) | ![supported](v.png) |
| **Faixas** | ![supported](v.png) | ![supported](v.png) |

**Empolgante**:

| Tipo de Animação | Aspose.Slides | PowerPoint |
|---|---|---|
| **Cair** | ![not supported](x.png) | ![supported](v.png) |
| **Cortina** | ![not supported](x.png) | ![supported](v.png) |
| **Cortinas** | ![not supported](x.png) | ![supported](v.png) |
| **Vento** | ![not supported](x.png) | ![supported](v.png) |
| **Prestígio** | ![not supported](x.png) | ![supported](v.png) |
| **Fratura** | ![not supported](x.png) | ![supported](v.png) |
| **Esmagar** | ![not supported](x.png) | ![supported](v.png) |
| **Descascar** | ![not supported](x.png) | ![supported](v.png) |
| **Curvatura de Página** | ![not supported](x.png) | ![supported](v.png) |
| **Avião** | ![not supported](x.png) | ![supported](v.png) |
| **Origami** | ![not supported](x.png) | ![supported](v.png) |
| **Dissolver** | ![supported](v.png) | ![supported](v.png) |
| **Tabuleiro** | ![not supported](x.png) | ![supported](v.png) |
| **Persianas** | ![not supported](x.png) | ![supported](v.png) |
| **Relógio** | ![supported](v.png) | ![supported](v.png) |
| **Ondulação** | ![not supported](x.png) | ![supported](v.png) |
| **Favo** | ![not supported](x.png) | ![supported](v.png) |
| **Cintilação** | ![not supported](x.png) | ![supported](v.png) |
| **Vórtice** | ![not supported](x.png) | ![supported](v.png) |
| **Fragmentar** | ![not supported](x.png) | ![supported](v.png) |
| **Alternar** | ![not supported](x.png) | ![supported](v.png) |
| **Virar** | ![not supported](x.png) | ![supported](v.png) |
| **Galeria** | ![not supported](x.png) | ![supported](v.png) |
| **Cubo** | ![not supported](x.png) | ![supported](v.png) |
| **Portas** | ![not supported](x.png) | ![supported](v.png) |
| **Caixa** | ![not supported](x.png) | ![supported](v.png) |
| **Pente** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Aleatório** | ![not supported](x.png) | ![supported](v.png) |

**Conteúdo Dinâmico**:

| Tipo de Animação | Aspose.Slides | PowerPoint |
|---|---|---|
| **Panorâmica** | ![not supported](x.png) | ![supported](v.png) |
| **Roda‑Gigante** | ![supported](v.png) | ![supported](v.png) |
| **Esteira** | ![not supported](x.png) | ![supported](v.png) |
| **Rotacionar** | ![not supported](x.png) | ![supported](v.png) |
| **Órbita** | ![not supported](x.png) | ![supported](v.png) |
| **Voar Através** | ![supported](v.png) | ![supported](v.png) |

## **FAQ**

### É possível converter apresentações protegidas por senha?

Sim, o Aspose.Slides para .NET permite trabalhar com apresentações protegidas por senha. Ao processar esses arquivos, você precisa fornecer a senha correta para que a biblioteca possa acessar o conteúdo da apresentação.

### O Aspose.Slides para .NET oferece suporte ao uso em soluções de nuvem?

Sim, o Aspose.Slides para .NET pode ser integrado a aplicativos e serviços em nuvem. A biblioteca foi projetada para funcionar em ambientes de servidor, garantindo alto desempenho e escalabilidade para o processamento em lote de arquivos.

### Existem limitações de tamanho para apresentações durante a conversão?

O Aspose.Slides para .NET é capaz de lidar com apresentações de tamanho praticamente ilimitado. Contudo, ao trabalhar com arquivos muito grandes, recursos adicionais do sistema podem ser necessários, e costuma‑se recomendar otimizar a apresentação para melhorar o desempenho.