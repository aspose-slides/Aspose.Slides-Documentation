---
title: Converter apresentações PowerPoint em vídeo no .NET
linktitle: PowerPoint para vídeo
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
description: "Aprenda como converter apresentações PowerPoint em vídeo no .NET. Descubra exemplos de código C# e técnicas de automação para otimizar seu fluxo de trabalho."
---
## **Introdução**

Ao converter sua apresentação PowerPoint ou OpenDocument em vídeo, você obtém:

**Aumento da acessibilidade:** Todos os dispositivos, independentemente da plataforma, vêm com reprodutores de vídeo por padrão, facilitando a abertura ou reprodução de vídeos em comparação com aplicativos de apresentação tradicionais.

**Alcance mais amplo:** Os vídeos permitem alcançar um público maior e apresentar informações de forma mais envolvente. Pesquisas e estatísticas indicam que as pessoas preferem assistir e consumir conteúdo em vídeo em vez de outras formas, tornando sua mensagem mais impactante.

{{% alert color="primary" %}} 

Confira nosso [**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/pt/video) porque ele oferece uma implementação ao vivo e eficaz do processo descrito aqui.

{{% /alert %}} 

No Aspose.Slides for .NET, implementamos suporte para converter apresentações em vídeo.

* Use Aspose.Slides for .NET para gerar quadros a partir dos slides da apresentação em uma taxa de quadros especificada (FPS).
* Em seguida, use uma ferramenta de terceiros como ffmpeg para compilar esses quadros em um vídeo.

## **Converter uma Apresentação PowerPoint em Vídeo**

1. Use o comando `dotnet add package` para adicionar Aspose.Slides e a biblioteca FFMpegCore ao seu projeto:
   * execute `dotnet add package Aspose.Slides.NET --version 22.11.0`
   * execute `dotnet add package FFMpegCore --version 4.8.0`
2. Baixe ffmpeg de [here](https://ffmpeg.org/download.html).
3. O FFMpegCore requer que você especifique o caminho para o ffmpeg baixado (por exemplo, extraído para "C:\tools\ffmpeg"):  
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

    // Adicione uma forma de sorriso e depois anime-a.
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

Ao converter uma apresentação PowerPoint em vídeo usando Aspose.Slides for .NET, você pode aplicar vários efeitos de vídeo para melhorar a qualidade visual do resultado. Esses efeitos permitem controlar a aparência dos slides no vídeo final, adicionando transições suaves, animações e outros elementos visuais. Esta seção explica as opções de efeito de vídeo disponíveis e mostra como aplicá‑las.

{{% alert color="primary" %}} 

Veja:
- [Aprimorando Apresentações PowerPoint com Animações em C#](https://docs.aspose.com/slides/pt/net/powerpoint-animation/)
- [Animação de Forma](https://docs.aspose.com/slides/pt/net/shape-animation/)
- [Aplicar Efeitos de Forma no PowerPoint Usando C#](https://docs.aspose.com/slides/pt/net/shape-effect/)

{{% /alert %}} 

Animações e transições tornam apresentações de slides mais envolventes e interessantes — e o mesmo vale para vídeos. Vamos adicionar outro slide e transição ao código da apresentação anterior:

```c#
 // Adicione uma forma de sorriso e anime-a.
 // ...

 // Adicione um novo slide e uma transição animada.
 ISlide newSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
 newSlide.Background.Type = BackgroundType.OwnBackground;
 newSlide.Background.FillFormat.FillType = FillType.Solid;
 newSlide.Background.FillFormat.SolidFillColor.Color = Color.Indigo;
 newSlide.SlideShowTransition.Type = TransitionType.Push;
```

O Aspose.Slides também oferece suporte a animações de texto. Neste exemplo, animamos parágrafos em objetos para que eles apareçam um após o outro, com um atraso de um segundo entre eles:

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

Para habilitar tarefas de conversão de PowerPoint para vídeo, o Aspose.Slides for .NET fornece as classes [PresentationAnimationsGenerator](https://reference.aspose.com/slides/pt/net/aspose.slides.export/presentationanimationsgenerator/) e [PresentationPlayer](https://reference.aspose.com/slides/pt/net/aspose.slides.export/presentationplayer/).

`PresentationAnimationsGenerator` permite definir o tamanho do quadro para o vídeo (que será criado posteriormente) e o valor FPS (quadros por segundo) através do seu construtor. Se você passar uma instância de apresentação, seu `Presentation.SlideSize` será usado e ele gera animações que o [PresentationPlayer](https://reference.aspose.com/slides/pt/net/aspose.slides.export/presentationplayer/) utiliza.

Quando as animações são geradas, um evento `NewAnimation` é disparado para cada animação subsequente, incluindo um parâmetro [IPresentationAnimationPlayer](https://reference.aspose.com/slides/pt/net/aspose.slides.export/ipresentationanimationplayer/). Essa classe representa um player para uma animação individual.

Para trabalhar com [IPresentationAnimationPlayer](https://reference.aspose.com/slides/pt/net/aspose.slides.export/ipresentationanimationplayer/), você usa a propriedade [Duration](https://reference.aspose.com/slides/pt/net/aspose.slides.export/ipresentationanimationplayer/duration/) (que fornece a duração total da animação) e o método [SetTimePosition](https://reference.aspose.com/slides/pt/net/aspose.slides.export/ipresentationanimationplayer/settimeposition/). Cada posição de animação é definida dentro do intervalo *0 a duration*, e o método `GetFrame` então retorna um Bitmap que representa o estado da animação naquele instante.

```c#
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

            animationPlayer.SetTimePosition(0);          // O estado inicial da animação.
            Bitmap bitmap = animationPlayer.GetFrame();  // O bitmap do estado inicial da animação.

            animationPlayer.SetTimePosition(animationPlayer.Duration);  // O estado final da animação.
            Bitmap lastBitmap = animationPlayer.GetFrame();             // O último quadro da animação.
            lastBitmap.Save("last.png");
        };
    }
}
```

Para fazer com que todas as animações de uma apresentação sejam reproduzidas simultaneamente, utiliza‑se a classe [PresentationPlayer](https://reference.aspose.com/slides/pt/net/aspose.slides.export/presentationplayer/). Essa classe recebe uma instância de [PresentationAnimationsGenerator](https://reference.aspose.com/slides/pt/net/aspose.slides.export/presentationanimationsgenerator/) e um valor FPS para os efeitos em seu construtor, e então chama o evento `FrameTick` para todas as animações reproduzi‑las:

```c#
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

Em seguida, os quadros gerados podem ser compilados para produzir um vídeo. Veja a seção [Convert a PowerPoint Presentation to Video](/slides/pt/net/convert-powerpoint-to-video/#convert-a-powerpoint-presentation-to-video).

## **Animações e Efeitos Suportados**

Ao converter uma apresentação PowerPoint em vídeo usando Aspose.Slides for .NET, é importante entender quais animações e efeitos são preservados no resultado. O Aspose.Slides oferece suporte a uma ampla gama de efeitos de entrada, saída e ênfase comuns, como fade, fly in, zoom e spin. Entretanto, algumas animações avançadas ou personalizadas podem não ser totalmente preservadas ou podem aparecer de forma diferente no vídeo final. Esta seção descreve as animações e efeitos suportados.

**Entrada**:

| Tipo de Animação | Aspose.Slides | PowerPoint |
|---|---|---|
| **Aparecer** | ![não suportado](x.png) | ![suportado](v.png) |
| **Desvanecer** | ![suportado](v.png) | ![suportado](v.png) |
| **Voo para dentro** | ![suportado](v.png) | ![suportado](v.png) |
| **Flutuar para dentro** | ![suportado](v.png) | ![suportado](v.png) |
| **Dividir** | ![suportado](v.png) | ![suportado](v.png) |
| **Limpar** | ![suportado](v.png) | ![suportado](v.png) |
| **Forma** | ![suportado](v.png) | ![suportado](v.png) |
| **Roda** | ![suportado](v.png) | ![suportado](v.png) |
| **Barras aleatórias** | ![suportado](v.png) | ![suportado](v.png) |
| **Crescer e girar** | ![não suportado](x.png) | ![suportado](v.png) |
| **Zoom** | ![suportado](v.png) | ![suportado](v.png) |
| **Giratório** | ![suportado](v.png) | ![suportado](v.png) |
| **Quicar** | ![suportado](v.png) | ![suportado](v.png) |

**Ênfase**:

| Tipo de Animação | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulso** | ![não suportado](x.png) | ![suportado](v.png) |
| **Pulso de cor** | ![não suportado](x.png) | ![suportado](v.png) |
| **Oscilar** | ![suportado](v.png) | ![suportado](v.png) |
| **Girar** | ![suportado](v.png) | ![suportado](v.png) |
| **Crescer/Encolher** | ![não suportado](x.png) | ![suportado](v.png) |
| **Dessaturar** | ![não suportado](x.png) | ![suportado](v.png) |
| **Escurecer** | ![não suportado](x.png) | ![suportado](v.png) |
| **Clarear** | ![não suportado](x.png) | ![suportado](v.png) |
| **Transparência** | ![não suportado](x.png) | ![suportado](v.png) |
| **Cor do objeto** | ![não suportado](x.png) | ![suportado](v.png) |
| **Cor complementar** | ![não suportado](x.png) | ![suportado](v.png) |
| **Cor da linha** | ![não suportado](x.png) | ![suportado](v.png) |
| **Cor de preenchimento** | ![não suportado](x.png) | ![suportado](v.png) |

**Saída**:

| Tipo de Animação | Aspose.Slides | PowerPoint |
|---|---|---|
| **Desaparecer** | ![não suportado](x.png) | ![suportado](v.png) |
| **Desvanecer** | ![suportado](v.png) | ![suportado](v.png) |
| **Voo para fora** | ![suportado](v.png) | ![suportado](v.png) |
| **Flutuar para fora** | ![suportado](v.png) | ![suportado](v.png) |
| **Dividir** | ![suportado](v.png) | ![suportado](v.png) |
| **Limpar** | ![suportado](v.png) | ![suportado](v.png) |
| **Forma** | ![suportado](v.png) | ![suportado](v.png) |
| **Barras aleatórias** | ![suportado](v.png) | ![suportado](v.png) |
| **Encolher e girar** | ![não suportado](x.png) | ![suportado](v.png) |
| **Zoom** | ![suportado](v.png) | ![suportado](v.png) |
| **Giratório** | ![suportado](v.png) | ![suportado](v.png) |
| **Quicar** | ![suportado](v.png) | ![suportado](v.png) |

**Caminhos de Movimento**:

| Tipo de Animação | Aspose.Slides | PowerPoint |
|---|---|---|
| **Linhas** | ![suportado](v.png) | ![suportado](v.png) |
| **Arcos** | ![suportado](v.png) | ![suportado](v.png) |
| **Curvas** | ![suportado](v.png) | ![suportado](v.png) |
| **Formas** | ![suportado](v.png) | ![suportado](v.png) |
| **Loops** | ![suportado](v.png) | ![suportado](v.png) |
| **Caminho personalizado** | ![suportado](v.png) | ![suportado](v.png) |

## **Efeitos de Transição de Slides Suportados**

Os efeitos de transição de slides desempenham um papel importante na criação de mudanças suaves e visualmente atraentes entre slides em um vídeo. O Aspose.Slides for .NET oferece suporte a uma variedade de transições comumente usadas para ajudar a preservar o fluxo e o estilo da sua apresentação original. Esta seção destaca quais transições são suportadas durante o processo de conversão.

**Sutil**:

| Tipo de Animação | Aspose.Slides | PowerPoint |
|---|---|---|
| **Morfose** | ![não suportado](x.png) | ![suportado](v.png) |
| **Desvanecer** | ![suportado](v.png) | ![suportado](v.png) |
| **Empurrar** | ![suportado](v.png) | ![suportado](v.png) |
| **Puxar** | ![suportado](v.png) | ![suportado](v.png) |
| **Limpar** | ![suportado](v.png) | ![suportado](v.png) |
| **Dividir** | ![suportado](v.png) | ![suportado](v.png) |
| **Revelar** | ![não suportado](x.png) | ![suportado](v.png) |
| **Barras aleatórias** | ![suportado](v.png) | ![suportado](v.png) |
| **Forma** | ![não suportado](x.png) | ![suportado](v.png) |
| **Descobrir** | ![não suportado](x.png) | ![suportado](v.png) |
| **Cobrir** | ![suportado](v.png) | ![suportado](v.png) |
| **Flash** | ![suportado](v.png) | ![suportado](v.png) |
| **Tiras** | ![suportado](v.png) | ![suportado](v.png) |

**Empolgante**:

| Tipo de Animação | Aspose.Slides | PowerPoint |
|---|---|---|
| **Cair** | ![não suportado](x.png) | ![suportado](v.png) |
| **Cortina** | ![não suportado](x.png) | ![suportado](v.png) |
| **Cortinas** | ![não suportado](x.png) | ![suportado](v.png) |
| **Vento** | ![não suportado](x.png) | ![suportado](v.png) |
| **Prestígio** | ![não suportado](x.png) | ![suportado](v.png) |
| **Fratura** | ![não suportado](x.png) | ![suportado](v.png) |
| **Esmagar** | ![não suportado](x.png) | ![suportado](v.png) |
| **Descolar** | ![não suportado](x.png) | ![suportado](v.png) |
| **Curvatura de página** | ![não suportado](x.png) | ![suportado](v.png) |
| **Avião** | ![não suportado](x.png) | ![suportado](v.png) |
| **Origami** | ![não suportado](x.png) | ![suportado](v.png) |
| **Dissolver** | ![suportado](v.png) | ![suportado](v.png) |
| **Tabuleiro** | ![não suportado](x.png) | ![suportado](v.png) |
| **Cortinas** | ![não suportado](x.png) | ![suportado](v.png) |
| **Relógio** | ![suportado](v.png) | ![suportado](v.png) |
| **Ondulação** | ![não suportado](x.png) | ![suportado](v.png) |
| **Favo** | ![não suportado](x.png) | ![suportado](v.png) |
| **Brilho** | ![não suportado](x.png) | ![suportado](v.png) |
| **Vórtice** | ![não suportado](x.png) | ![suportado](v.png) |
| **Desfiar** | ![não suportado](x.png) | ![suportado](v.png) |
| **Alternar** | ![não suportado](x.png) | ![suportado](v.png) |
| **Virar** | ![não suportado](x.png) | ![suportado](v.png) |
| **Galeria** | ![não suportado](x.png) | ![suportado](v.png) |
| **Cubo** | ![não suportado](x.png) | ![suportado](v.png) |
| **Portas** | ![não suportado](x.png) | ![suportado](v.png) |
| **Caixa** | ![não suportado](x.png) | ![suportado](v.png) |
| **Pente** | ![não suportado](x.png) | ![suportado](v.png) |
| **Zoom** | ![suportado](v.png) | ![suportado](v.png) |
| **Aleatório** | ![não suportado](x.png) | ![suportado](v.png) |

**Conteúdo Dinâmico**:

| Tipo de Animação | Aspose.Slides | PowerPoint |
|---|---|---|
| **Panorâmica** | ![não suportado](x.png) | ![suportado](v.png) |
| **Roda‑gigante** | ![suportado](v.png) | ![suportado](v.png) |
| **Esteira** | ![não suportado](x.png) | ![suportado](v.png) |
| **Rotacionar** | ![não suportado](x.png) | ![suportado](v.png) |
| **Órbita** | ![não suportado](x.png) | ![suportado](v.png) |
| **Voo através** | ![suportado](v.png) | ![suportado](v.png) |

## **FAQ**

**É possível converter apresentações protegidas por senha?**

Sim, o Aspose.Slides for .NET permite trabalhar com apresentações protegidas por senha. Ao processar esses arquivos, você precisa fornecer a senha correta para que a biblioteca possa acessar o conteúdo da apresentação.

**O Aspose.Slides para .NET oferece suporte ao uso em soluções de nuvem?**

Sim, o Aspose.Slides for .NET pode ser integrado em aplicações e serviços baseados em nuvem. A biblioteca foi projetada para funcionar em ambientes de servidor, garantindo alto desempenho e escalabilidade para o processamento em lote de arquivos.

**Existem limitações de tamanho para apresentações durante a conversão?**

O Aspose.Slides for .NET é capaz de lidar com apresentações de praticamente qualquer tamanho. Contudo, ao trabalhar com arquivos muito grandes, podem ser necessários recursos adicionais do sistema, e às vezes recomenda‑se otimizar a apresentação para melhorar o desempenho.