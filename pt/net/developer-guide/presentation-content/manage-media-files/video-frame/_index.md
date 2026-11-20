---
title: Gerenciar Quadros de Vídeo em Apresentações em .NET
linktitle: Quadro de Vídeo
type: docs
weight: 10
url: /pt/net/video-frame/
keywords:
- adicionar vídeo
- criar vídeo
- incorporar vídeo
- extrair vídeo
- recuperar vídeo
- quadro de vídeo
- fonte web
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Aprenda a adicionar e extrair programaticamente quadros de vídeo em slides PowerPoint e OpenDocument usando Aspose.Slides para .NET. Guia rápido de como‑fazer."
---
## **Introdução**

Os vídeos podem ajudar a explicar ideias e envolver o público. Aspose.Slides for .NET permite adicionar quadros de vídeo aos slides, ajustar as configurações de reprodução, gerenciar legendas e extrair dados de vídeo incorporados.

O PowerPoint suporta vídeos locais e links para vídeos online, como vídeos do YouTube.

Para representar dados de vídeo e quadros de vídeo, Aspose.Slides fornece a interface [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) e a interface [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/), além de outros tipos relevantes.

## **Criar um Quadro de Vídeo Incorporado**

Se o arquivo de vídeo que você deseja adicionar ao slide está armazenado localmente, pode criar um quadro de vídeo para incorporar o vídeo na apresentação.

Este exemplo incorpora um vídeo local no primeiro slide de uma apresentação existente e salva o resultado. As coordenadas e dimensões do quadro estão em pontos. O stream permanece aberto até que a gravação termine porque [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/net/aspose.slides/loadingstreambehavior/) o mantém bloqueado enquanto a apresentação o usa.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

using var videoStream = File.OpenRead("video.mp4");
var video = presentation.Videos.AddVideo(videoStream, LoadingStreamBehavior.KeepLocked);
slide.Shapes.AddVideoFrame(10, 10, 150, 250, video);

presentation.Save("embedded_video.pptx", SaveFormat.Pptx);
```

Você também pode passar o caminho de um vídeo local diretamente para [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/). Este exemplo incorpora o vídeo no primeiro slide de uma nova apresentação. O vídeo deve permanecer acessível até que a apresentação seja salva.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddVideoFrame(50, 150, 300, 150, "video.avi");

presentation.Save("video_from_path.pptx", SaveFormat.Pptx);
```

## **Definir o Volume do Vídeo Precisamente**

No Aspose.Slides for .NET 26.11 ou posterior, [IVideoFrame.VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/volumevalue/) define um percentual de ponto flutuante de 0 a 100. Use-o quando as predefinições de [Volume](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/volume/) forem muito grosseiras. Por exemplo, `75.5f` solicita 75,5 % de volume.

Este exemplo requer [Aspose.Slides for .NET](/slides/pt/net/installation/) 26.11 ou posterior e um `video.mp4` local. Ele incorpora o vídeo, inicializa explicitamente a reprodução, salva a apresentação e lê o percentual armazenado.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

var volume = 75.5f;
if (float.IsNaN(volume) || float.IsInfinity(volume) || volume < 0 || volume > 100)
{
    Console.WriteLine("Use a finite volume from 0 to 100.");
    return;
}

using (var presentation = new Presentation())
{
    var videoBytes = File.ReadAllBytes("video.mp4");
    var video = presentation.Videos.AddVideo(videoBytes);
    var frame = presentation.Slides[0].Shapes.AddVideoFrame(50, 50, 320, 180, video);
    frame.PlayMode = VideoPlayModePreset.Auto;
    frame.VolumeValue = volume;
    presentation.Save("video-volume.pptx", SaveFormat.Pptx);
}

using var saved = new Presentation("video-volume.pptx");
var savedFrame = saved.Slides[0].Shapes.OfType<IVideoFrame>().First();
Console.WriteLine(savedFrame.VolumeValue);
```

Valide a entrada você mesmo; não dependa do setter para rejeitar valores fora do intervalo documentado. As predefinições Low, Medium e Loud correspondem a 20, 50 e 80 na versão 26.11. Definir uma predefinição pode substituir um percentual anterior, portanto atribua o percentual por último quando precisar de um valor exato. Use [AudioVolumeMode.Mute](https://reference.aspose.com/slides/net/aspose.slides/audiovolumemode/) para a configuração explícita de mudo; zero numérico e a enumeração de predefinição não são estados intercambiáveis.

Defina explicitamente [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) ao configurar um vídeo vinculado também, e mantenha seu arquivo de mídia disponível ao visualizador. Salvar e reabrir verifica a configuração armazenada; a reprodução real e a intensidade dependem do reprodutor da apresentação e de suas configurações de áudio.

## **Criar um Quadro de Vídeo com Vídeo de uma Fonte Web**

A Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) oferece suporte a vídeos online em apresentações. Você pode criar um quadro de vídeo que vincula a um vídeo online, como um vídeo do YouTube.

Este exemplo adiciona um link de vídeo do YouTube e sua miniatura ao primeiro slide. Substitua o identificador do vídeo para usar outro vídeo. A configuração [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) solicita reprodução automática. Baixar a miniatura e reproduzir o vídeo requer acesso à internet. O visualizador da apresentação também deve suportar reprodução de vídeo online.

```csharp
using System.Net.Http;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var httpClient = new HttpClient();

var videoId = "aqz-KE-bpKQ";
var videoUrl = $"https://www.youtube.com/embed/{videoId}";
var videoFrame = slide.Shapes.AddVideoFrame(10, 10, 427, 240, videoUrl);
videoFrame.PlayMode = VideoPlayModePreset.Auto;

var thumbnailUrl = $"https://img.youtube.com/vi/{videoId}/hqdefault.jpg";
var thumbnailData = httpClient.GetByteArrayAsync(thumbnailUrl).GetAwaiter().GetResult();
var thumbnail = presentation.Images.AddImage(thumbnailData);
videoFrame.PictureFormat.Picture.Image = thumbnail;

presentation.Save("online_video.pptx", SaveFormat.Pptx);
```

## **Reproduzir um Vídeo em Modo Tela Cheia**

Em uma apresentação de treinamento, você pode reproduzir uma demonstração de software em modo tela cheia para que o público veja os detalhes. Defina [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/) como `true` para habilitar esse comportamento durante a reprodução.

Este exemplo abre uma apresentação, encontra o primeiro [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) no primeiro slide e habilita a reprodução em tela cheia. A apresentação de origem deve conter ao menos um slide com um quadro de vídeo existente no primeiro slide.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("training.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        videoFrame.FullScreenMode = true;
        break;
    }
}

presentation.Save("full_screen_video.pptx", SaveFormat.Pptx);
```

A reprodução em tela cheia controla como o vídeo é exibido. De forma independente, [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) controla se ele inicia automaticamente ou ao clicar, e [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) controla se ele se repete. Para escolher o comportamento de início, defina o modo de reprodução para [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/). O exemplo preserva as configurações de início e loop existentes.

## **Retroceder um Vídeo Após a Reprodução**

Em uma apresentação de treinamento, retornar um vídeo de demonstração ao início o deixa pronto para o apresentador reproduzi‑lo novamente. Defina [RewindVideo](https://reference.aspose.com/slides/net/aspose.slides/videoframe/rewindvideo/) como `true` para retornar o vídeo ao início após a conclusão da reprodução.

Este exemplo abre uma apresentação, localiza o primeiro [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) no primeiro slide e habilita o retrocesso. Ele desabilita o looping para que a reprodução possa terminar e define a reprodução para iniciar ao clicar. A apresentação de origem deve conter ao menos um slide com um quadro de vídeo existente no primeiro slide.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("training.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        videoFrame.RewindVideo = true;
        videoFrame.PlayLoopMode = false;
        videoFrame.PlayMode = VideoPlayModePreset.OnClick;
        break;
    }
}

presentation.Save("rewind_video.pptx", SaveFormat.Pptx);
```

O retrocesso devolve o vídeo ao início sem iniciá‑lo novamente. Em contraste, habilitar [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) faz a reprodução repetir automaticamente. Mantenha o looping desativado quando desejar que o vídeo termine e permaneça pronto para ser reproduzido novamente. [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) controla independentemente o início automático ou ao clicar; este exemplo usa [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/) para que o apresentador controle quando a reprodução começa. Defina o modo de reprodução após a configuração de loop, como mostrado no exemplo. O retrocesso funciona independentemente de [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/).

## **Cortar um Quadro de Vídeo**

Use [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromstart/) e [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromend/) para ignorar parte do início ou do fim de um vídeo durante a reprodução. Ambos os valores estão em milissegundos. O corte altera as configurações de reprodução sem modificar os dados de vídeo incorporados.

**Definir Configurações de Corte**

Este exemplo incorpora um vídeo local e pula os primeiros 2,5 s e o último segundo durante a reprodução. Use um vídeo com mais de 3,5 s para que reste um segmento reproduzível.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var videoData = File.ReadAllBytes("video.mp4");
var video = presentation.Videos.AddVideo(videoData);

var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 640, 360, video);
videoFrame.TrimFromStart = 2500f;
videoFrame.TrimFromEnd = 1000f;

presentation.Save("video_with_trim.pptx", SaveFormat.Pptx);
```

**Ler Configurações de Corte**

Este exemplo exibe os valores de corte do primeiro quadro de vídeo no primeiro slide em milissegundos. A apresentação deve conter ao menos um slide. Se esse slide não possuir quadro de vídeo, nada será impresso. O exemplo anterior gera os valores 2500 e 1000.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("video_with_trim.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        Console.WriteLine($"Trim from start: {videoFrame.TrimFromStart} ms");
        Console.WriteLine($"Trim from end: {videoFrame.TrimFromEnd} ms");
        break;
    }
}
```

## **Gerenciar Legendas de Vídeo**

Aspose.Slides permite gerenciar legendas ocultas para quadros de vídeo em apresentações PowerPoint. As legendas são armazenadas no formato WebVTT e são expostas através da propriedade [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/).

### **Adicionar Legendas a um Quadro de Vídeo**

Este exemplo incorpora um vídeo local e adiciona uma faixa de legenda WebVTT rotulada como English. Os timestamps das legendas devem corresponder ao vídeo. A apresentação salva inclui tanto o vídeo quanto suas legendas.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var videoData = File.ReadAllBytes("video.mp4");
var video = presentation.Videos.AddVideo(videoData);

var videoFrame = slide.Shapes.AddVideoFrame(0, 0, 100, 100, video);
videoFrame.CaptionTracks.Add("English", "track.vtt");

presentation.Save("video_with_captions.pptx", SaveFormat.Pptx);
```

A interface [ICaptionsCollection](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/) também oferece uma sobrecarga que permite adicionar legendas a partir de um stream.

### **Extrair Legendas de um Quadro de Vídeo**

Este exemplo salva todas as faixas de legendas dos quadros de vídeo no primeiro slide como arquivos WebVTT separados. Números sequenciais mantêm os arquivos de saída distintos. O console relata o número de faixas extraídas. A apresentação deve conter ao menos um slide.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("video_with_captions.pptx");
var slide = presentation.Slides[0];

var trackCount = 0;
foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        foreach (var captionTrack in videoFrame.CaptionTracks)
        {
            trackCount++;
            var outputPath = $"captions_{trackCount}.vtt";
            File.WriteAllBytes(outputPath, captionTrack.BinaryData);
        }
    }
}

Console.WriteLine($"Caption tracks extracted: {trackCount}");
```

Cada objeto [ICaptions](https://reference.aspose.com/slides/net/aspose.slides/icaptions/) expõe o identificador da legenda, o rótulo, os dados binários e o texto da legenda como uma string UTF‑8.

### **Remover Legendas de um Quadro de Vídeo**

Este exemplo remove todas as legendas do quadro de vídeo na primeira posição de forma no primeiro slide e salva o resultado. Ele presume que o slide e a forma existem e que a forma é um quadro de vídeo.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("video_with_captions.pptx");
var slide = presentation.Slides[0];

var videoFrame = (IVideoFrame) slide.Shapes[0];
videoFrame.CaptionTracks.Clear();

presentation.Save("video_without_captions.pptx", SaveFormat.Pptx);
```

Se precisar remover apenas uma faixa de legenda, use os métodos [Remove](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/remove/) ou [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/removeat/) em vez de [Clear](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/clear/).

### **Pesquisar Legendas de Vídeo**

[ICaptions.DataAsString](https://reference.aspose.com/slides/net/aspose.slides/icaptions/dataasstring/) devolve a faixa completa de WebVTT, incluindo seu cabeçalho, linhas de temporização e texto da legenda. Para encontrar uma frase falada e seu timestamp, leia as cues em memória. Por exemplo, uma faixa English no slide 2 pode conter o texto a seguir:

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

O exemplo percorre cada slide e lê as faixas dos seus quadros de vídeo de nível superior através de [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/). Em uma cue de texto simples, a linha de temporização contém `-->` e uma linha vazia finaliza a cue. Quando o texto da legenda contém “café”, o exemplo imprime o número do slide, o rótulo da faixa, a linha de temporização original e a legenda completa.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("captioned_media.pptx");
foreach (var slide in presentation.Slides)
{
    var tracks = slide.Shapes.OfType<IVideoFrame>().SelectMany(frame => frame.CaptionTracks);
    foreach (var track in tracks)
    {
        using var reader = new StringReader(track.DataAsString);
        while (reader.ReadLine() is string timing)
        {
            if (!timing.Contains("-->")) continue;

            var lines = new List<string>();
            while (reader.ReadLine() is string line && line.Length > 0)
                lines.Add(line);

            var caption = string.Join(Environment.NewLine, lines);
            if (caption.Contains("café", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Slide {slide.SlideNumber} | {track.Label} | {timing}");
                Console.WriteLine(caption);
            }
        }
    }
}
```

A pesquisa por “café” produz uma correspondência para a faixa de amostra. O cabeçalho e a configuração de temporização ficam fora do texto da cue.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Extrair Vídeo de um Slide**

Além de adicionar vídeos a slides, Aspose.Slides permite extrair vídeos incorporados em apresentações.

Este exemplo extrai vídeos incorporados de cada slide em arquivos binários numerados separados. Vídeos vinculados são ignorados porque não possuem dados incorporados. O console imprime o tipo MIME de cada vídeo e a contagem total. A saída usa a extensão genérica `.bin`; altere‑a para corresponder ao tipo de mídia relatado quando necessário.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("presentation_with_videos.pptx");

var videoCount = 0;
foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IVideoFrame videoFrame)
        {
            var video = videoFrame.EmbeddedVideo;
            if (video == null)
            {
                Console.WriteLine("Skipped a linked video: no embedded data is available.");
                continue;
            }

            videoCount++;
            var outputPath = $"extracted_video_{videoCount}.bin";
            File.WriteAllBytes(outputPath, video.BinaryData);
            Console.WriteLine($"Video {videoCount}: {video.ContentType}");
        }
    }
}

Console.WriteLine($"Embedded videos extracted: {videoCount}");
```

## **Perguntas Frequentes**

**Quais parâmetros de reprodução de vídeo podem ser alterados para um quadro de vídeo?**

É possível controlar o [modo de reprodução](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) (automático ou ao clicar) e o [looping](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/). Essas opções estão disponíveis nas propriedades do objeto [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/).

**Adicionar um vídeo afeta o tamanho do arquivo PPTX?**

Sim. Quando você incorpora um vídeo local, os dados binários são incluídos no documento, portanto o tamanho da apresentação cresce proporcionalmente ao tamanho do arquivo. Quando você vincula a um vídeo online e adiciona uma miniatura, a apresentação armazena apenas o link e a imagem de pré‑visualização, o que geralmente resulta em um aumento menor.

**Posso substituir o vídeo em um quadro de vídeo existente sem mudar sua posição e tamanho?**

Sim. É possível trocar o [conteúdo do vídeo](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/) dentro do quadro mantendo a geometria da forma; esse é um cenário comum para atualizar a mídia em um layout já existente.

**É possível determinar o tipo de conteúdo (MIME) de um vídeo incorporado?**

Sim. Um vídeo incorporado possui um [tipo de conteúdo](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/) que pode ser lido e usado, por exemplo, ao salvá‑lo em disco.