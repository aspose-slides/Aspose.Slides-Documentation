---
title: Gerenciar quadros de áudio em apresentações no .NET
linktitle: Quadro de áudio
type: docs
weight: 10
url: /pt/net/audio-frame/
keywords:
- áudio
- quadro de áudio
- miniatura
- adicionar áudio
- propriedades de áudio
- opções de áudio
- extrair áudio
- .NET
- C#
- Aspose.Slides
description: "Incorpore áudio em slides, altere o ícone de áudio, configure a reprodução, gerencie legendas WebVTT e extraia sons de transição de slides com Aspose.Slides para .NET."
---
## **Visão geral**

Um quadro de áudio permite reproduzir um som em um slide. Com Aspose.Slides para .NET, você pode incorporar um clipe de áudio, escolher a imagem que o representa, ajustar a reprodução e anexar legendas. Você também pode recuperar um som atribuído a uma transição de slide.

## **Criar quadros de áudio**

Use [AddAudioFrameEmbedded](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addaudioframeembedded/) para incorporar um clipe de áudio local no primeiro slide. As duas primeiras coordenadas posicionam o quadro no slide, e os próximos dois valores definem sua largura e altura, todos em pontos. Este exemplo define [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) para iniciar o clipe automaticamente e [Volume](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volume/) para a predefinição alta.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, audioStream);
audioFrame.PlayMode = AudioPlayModePreset.Auto;
audioFrame.Volume = AudioVolumeMode.Loud;

presentation.Save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
```

## **Alterar a miniatura do quadro de áudio**

Por padrão, um quadro de áudio exibe um ícone de alto-falante. Para exibir uma miniatura personalizada, adicione uma imagem à apresentação com [AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/) e atribua‑a à propriedade [Picture.Image](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/image/) do quadro. O exemplo usa um JPEG como miniatura para um clipe de áudio incorporado.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var imageStream = File.OpenRead("eagle.jpeg");
var thumbnail = presentation.Images.AddImage(imageStream);

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
audioFrame.PictureFormat.Picture.Image = thumbnail;

presentation.Save("example_out.pptx", SaveFormat.Pptx);
```

## **Alterar opções de reprodução de áudio**

Os controles de **Opções de Áudio** do PowerPoint determinam quando um clipe começa, quão alto ele soa e como ele se comporta durante uma apresentação de slides.

![Controles de Opções de Áudio do PowerPoint para um quadro de áudio](audio_frame_0.png)

| Controle do PowerPoint | Propriedade Aspose.Slides |
| --- | --- |
| Início | [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) |
| Predefinição de volume | [Volume](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volume/) |
| Reproduzir em todos os slides | [PlayAcrossSlides](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playacrossslides/) |
| Repetir até parar | [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playloopmode/) |
| Ocultar durante a apresentação | [HideAtShowing](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/hideatshowing/) |
| Rebobinar após reproduzir | [RewindAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/rewindaudio/) |
| Aparecer gradualmente | [FadeInDuration](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/fadeinduration/) |
| Desaparecer gradualmente | [FadeOutDuration](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/fadeoutduration/) |
| Cortar tempo inicial do áudio | [TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromstart/) |
| Cortar tempo final do áudio | [TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) |
| Controle deslizante de volume | [VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volumevalue/) |

O exemplo encontra o primeiro quadro de áudio no primeiro slide, define [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) para iniciar a reprodução ao clicar e seleciona a predefinição de volume baixo. O clipe continua em vários slides com a repetição desativada. O ícone permanece oculto durante a apresentação, e o clipe rebobina após a reprodução.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("AudioFrameEmbed_out.pptx");
var slide = presentation.Slides[0];

var audioFrame = slide.Shapes.OfType<IAudioFrame>().FirstOrDefault();
if (audioFrame == null)
{
    Console.WriteLine("The first slide has no audio frame.");
    return;
}

audioFrame.PlayMode = AudioPlayModePreset.OnClick;
audioFrame.Volume = AudioVolumeMode.Low;
audioFrame.PlayAcrossSlides = true;
audioFrame.PlayLoopMode = false;
audioFrame.HideAtShowing = true;
audioFrame.RewindAudio = true;

presentation.Save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
```

Para um clipe com mais de 3,5 segundos, este exemplo pula os primeiros 1,5 segundos e os últimos 2 segundos. [TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) mede a duração a ser omitida do final do clipe. Para obter o tempo final exibido no PowerPoint, subtraia esse deslocamento da duração total do clipe. O clipe cortado aparece gradualmente em 200 milissegundos e desaparece gradualmente em 500 milissegundos. Todas as quatro propriedades aceitam valores em milissegundos.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audioStream);
audioFrame.TrimFromStart = 1500f;
audioFrame.TrimFromEnd = 2000f;
audioFrame.FadeInDuration = 200f;
audioFrame.FadeOutDuration = 500f;

presentation.Save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
```

Para definir o volume de reprodução para uma porcentagem específica, use [VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volumevalue/). Este exemplo define o primeiro quadro de áudio no primeiro slide para 85%.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("AudioFrameEmbed_out.pptx");
var slide = presentation.Slides[0];

var audioFrame = slide.Shapes.OfType<IAudioFrame>().FirstOrDefault();
if (audioFrame == null)
{
    Console.WriteLine("The first slide has no audio frame.");
    return;
}

audioFrame.VolumeValue = 85f;

presentation.Save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
```

## **Gerenciar legendas de áudio**

Cada quadro de áudio possui uma coleção [CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/captiontracks/). Use‑a para anexar legendas WebVTT ao clipe, exportar faixas existentes ou removê‑las.

### **Adicionar legendas de áudio**

O exemplo incorpora um clipe de áudio no primeiro slide e usa [ICaptionsCollection.Add](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/add/) para anexar uma faixa WebVTT local. O primeiro argumento fornece o rótulo da faixa, e o segundo identifica o arquivo contendo as legendas cronometradas.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(10, 10, 50, 50, audioStream);
audioFrame.CaptionTracks.Add("English", "track.vtt");

presentation.Save("audio_with_captions.pptx", SaveFormat.Pptx);
```

### **Extrair legendas de áudio**

Este exemplo exporta cada faixa de legenda anexada a um quadro de áudio no primeiro slide. Ele grava o [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/icaptions/binarydata/) da faixa em um arquivo WebVTT e usa seu [CaptionId](https://reference.aspose.com/slides/net/aspose.slides/icaptions/captionid/) como nome do arquivo, de modo que cada faixa tenha uma saída separada.

```csharp
using System.IO;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("audio_with_captions.pptx");
var slide = presentation.Slides[0];

foreach (var audioFrame in slide.Shapes.OfType<IAudioFrame>())
{
    foreach (var track in audioFrame.CaptionTracks)
    {
        File.WriteAllBytes($"{track.CaptionId}.vtt", track.BinaryData);
    }
}
```

### **Remover legendas de áudio**

Use [Remove](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/remove/) ou [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/removeat/) para excluir uma faixa individual. O exemplo usa [Clear](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/clear/) para remover todas as legendas do primeiro quadro de áudio no primeiro slide, preservando o clipe.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("audio_with_captions.pptx");
var slide = presentation.Slides[0];

var audioFrame = slide.Shapes.OfType<IAudioFrame>().FirstOrDefault();
if (audioFrame == null)
{
    Console.WriteLine("The first slide has no audio frame.");
    return;
}

audioFrame.CaptionTracks.Clear();

presentation.Save("audio_without_captions.pptx", SaveFormat.Pptx);
```

### **Encontrar uma linha nas legendas de áudio**

Para encontrar uma linha nas legendas de áudio no primeiro slide, leia o [DataAsString](https://reference.aspose.com/slides/net/aspose.slides/icaptions/dataasstring/) de cada faixa na memória. Em um cue WebVTT de texto simples, a linha de tempo contém `-->`, as linhas de legenda seguem‑na, e uma linha em branco termina o cue. Este exemplo imprime o rótulo da faixa e cada linha de legenda que contém “café”.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("audio_with_captions.pptx");
var slide = presentation.Slides[0];

foreach (var frame in slide.Shapes.OfType<IAudioFrame>())
{
    foreach (var track in frame.CaptionTracks)
    {
        using var reader = new StringReader(track.DataAsString);
        var inCue = false;
        while (reader.ReadLine() is string line)
        {
            if (line.Length == 0)
                inCue = false;
            else if (line.Contains("-->"))
                inCue = true;
            else if (inCue && line.Contains("café", StringComparison.OrdinalIgnoreCase))
                Console.WriteLine($"{track.Label}: {line}");
        }
    }
}
```

## **Extrair áudio**

Uma transição de slide pode ter seu próprio som. Para recuperá‑lo, leia a propriedade [Sound](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/sound/) da transição. O exemplo acessa o [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/iaudio/binarydata/) do som e imprime seu tamanho em bytes. Se o primeiro slide não possuir som de transição, ele imprime uma mensagem em vez disso.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("AudioSlide.pptx");
var slide = presentation.Slides[0];

var sound = slide.SlideShowTransition.Sound;
if (sound == null)
{
    Console.WriteLine("The first slide has no transition sound.");
    return;
}

var audioData = sound.BinaryData;
Console.WriteLine($"Transition sound: {audioData.Length} bytes.");
```

## **FAQ**

**Posso reutilizar o mesmo clipe de áudio em vários slides sem duplicá‑lo?**

Sim. Adicione o clipe uma vez à [coleção de áudio](https://reference.aspose.com/slides/net/aspose.slides/presentation/audios/) da apresentação e passe o mesmo objeto de áudio para [AddAudioFrameEmbedded](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addaudioframeembedded/) em cada slide.

**Posso substituir o som em um quadro de áudio existente?**

Sim. Para um som vinculado, atualize [LinkPathLong](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/linkpathlong/) para apontar para o arquivo de substituição. Para um som incorporado, atribua outro clipe da coleção de áudio da apresentação a [EmbeddedAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/embeddedaudio/). Ambas as abordagens preservam o quadro existente.

**O recorte altera os dados de áudio armazenados na apresentação?**

Não. [TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromstart/) e [TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) definem os limites de reprodução. Você ainda pode recuperar o clipe completo de [EmbeddedAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/embeddedaudio/).