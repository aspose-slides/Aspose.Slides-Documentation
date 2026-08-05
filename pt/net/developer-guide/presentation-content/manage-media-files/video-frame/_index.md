---
title: Gerenciar Quadros de Vídeo em Apresentações no .NET
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
description: "Aprenda a adicionar e extrair programaticamente quadros de vídeo em slides PowerPoint e OpenDocument usando Aspose.Slides para .NET. Guia rápido de como-fazer."
---
## **Introdução**

Um vídeo bem colocado em uma apresentação pode tornar sua mensagem mais impactante e aumentar os níveis de engajamento com o seu público. 

O PowerPoint permite que você adicione vídeos a um slide em uma apresentação de duas maneiras:

* Adicionar ou incorporar um vídeo local (armazenado em sua máquina)
* Adicionar um vídeo online (de uma fonte web como o YouTube).

Para permitir que você adicione vídeos (objetos de vídeo) a uma apresentação, o Aspose.Slides fornece a interface [IVideo](https://reference.aspose.com/slides/pt/net/aspose.slides/ivideo/) , a interface [IVideoFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/ivideoframe/) e outros tipos relevantes. 

## **Criar um Quadro de Vídeo Incorporado**

Se o arquivo de vídeo que você deseja adicionar ao seu slide estiver armazenado localmente, você pode criar um quadro de vídeo para incorporar o vídeo em sua apresentação. 

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation).
1. Obtenha a referência de um slide através de seu índice. 
1. Adicione um objeto [IVideo](https://reference.aspose.com/slides/pt/net/aspose.slides/ivideo/) e passe o caminho do arquivo de vídeo para incorporar o vídeo à apresentação. 
1. Adicione um objeto [IVideoFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/ivideoframe/) para criar um quadro para o vídeo.  
1. Salve a apresentação modificada. 

Este código C# demonstra como adicionar um vídeo armazenado localmente a uma apresentação:

```c#
// Instancia a classe Presentation
using (Presentation pres = new Presentation("pres.pptx"))
{
    // Carrega o vídeo
    using (FileStream fileStream = new FileStream("Wildlife.mp4", FileMode.Open, FileAccess.Read))
    {
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        
        // Obtém o primeiro slide e adiciona um videoframe
        pres.Slides[0].Shapes.AddVideoFrame(10, 10, 150, 250, video);
        
        // Salva a apresentação no disco
        pres.Save("pres-with-video.pptx", SaveFormat.Pptx);
    }
}
```
Alternativamente, você pode adicionar um vídeo passando seu caminho de arquivo diretamente para o método [AddVideoFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/ishapecollection/addvideoframe/):

``` csharp
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    IVideoFrame vf = sld.Shapes.AddVideoFrame(50, 150, 300, 150, "video1.avi");
}
```


## **Criar um Quadro de Vídeo com Vídeo de uma Fonte Web**
Versões mais recentes do Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) suportam vídeos online em apresentações. Se o vídeo que você deseja usar estiver disponível online (por exemplo, no YouTube), você pode adicioná-lo à sua apresentação através do seu link web.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation).
1. Obtenha a referência de um slide através de seu índice. 
1. Adicione um objeto [IVideo](https://reference.aspose.com/slides/pt/net/aspose.slides/ivideo/) e passe o link para o vídeo.
1. Defina uma miniatura para o quadro de vídeo. 
1. Salve a apresentação. 

Este código C# demonstra como adicionar um vídeo da web a um slide em uma apresentação do PowerPoint:

```c#
public static void Run()
{
    // Instancia um objeto Presentation que representa um arquivo de apresentação 
    using (Presentation pres = new Presentation())
    {
        AddVideoFromYouTube(pres, "Tj75Arhq5ho");
        pres.Save("AddVideoFrameFromWebSource_out.pptx", SaveFormat.Pptx);
    }
}

private static void AddVideoFromYouTube(Presentation pres, string videoId)
{
    // Adiciona um VideoFrame
    IVideoFrame videoFrame = pres.Slides[0].Shapes.AddVideoFrame(10, 10, 427, 240, "https://www.youtube.com/embed/" + videoId);
    videoFrame.PlayMode = VideoPlayModePreset.Auto;

    // Carrega a miniatura
    using (WebClient client = new WebClient())
    {
        string thumbnailUri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
        videoFrame.PictureFormat.Picture.Image = pres.Images.AddImage(client.DownloadData(thumbnailUri));
    }
}
```

## **Cortar um Quadro de Vídeo**

O Aspose.Slides permite que você controle qual parte de um vídeo é reproduzida definindo os valores trim‑from‑start e trim‑from‑end através de [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/pt/net/aspose.slides/ivideoframe/trimfromstart/) e [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/pt/net/aspose.slides/ivideoframe/trimfromend/). Ambos os valores são especificados em milissegundos e definem quanto tempo é ignorado do início e do fim do vídeo, respectivamente. Essas configurações alteram as propriedades de reprodução do vídeo na apresentação; elas não cortam nem modificam os dados binários do vídeo incorporado.

**Definir Configurações de Corte**

Para criar um quadro de vídeo e definir suas configurações de corte:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/) .
1. Adicione um objeto [IVideo](https://reference.aspose.com/slides/pt/net/aspose.slides/ivideo/) à apresentação.
1. Adicione um objeto [IVideoFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/ivideoframe/) a um slide.
1. Defina os valores trim‑from‑start e trim‑from‑end através de [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/pt/net/aspose.slides/ivideoframe/trimfromstart/) e [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/pt/net/aspose.slides/ivideoframe/trimfromend/).
1. Salve a apresentação modificada.

O exemplo de código a seguir ignora os primeiros 2,5 segundos e o último segundo de um vídeo incorporado durante a reprodução:

```cs
using var presentation = new Presentation();

var videoData = File.ReadAllBytes("video.mp4");
var video = presentation.Videos.AddVideo(videoData);

var slide = presentation.Slides[0];
var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 640, 360, video);

videoFrame.TrimFromStart = 2500f;
videoFrame.TrimFromEnd = 1000f;

presentation.Save("video_with_trim.pptx", SaveFormat.Pptx);
```

**Ler Configurações de Corte**

Para inspecionar as configurações de corte existentes, carregue uma apresentação, encontre um objeto [IVideoFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/ivideoframe/) entre as formas do primeiro slide e leia os valores através de [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/pt/net/aspose.slides/ivideoframe/trimfromstart/) e [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/pt/net/aspose.slides/ivideoframe/trimfromend/).

O exemplo de código a seguir encontra o primeiro quadro de vídeo no primeiro slide e relata suas configurações de corte em milissegundos:

```cs
using var presentation = new Presentation("video_with_trim.pptx");

var slide = presentation.Slides[0];
foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        var trimFromStart = videoFrame.TrimFromStart;
        var trimFromEnd = videoFrame.TrimFromEnd;

        Console.WriteLine($"Trim from start: {trimFromStart} ms");
        Console.WriteLine($"Trim from end: {trimFromEnd} ms");

        break;
    }
}
```

## **Gerenciar Legendas de Vídeo**

O Aspose.Slides permite que você gerencie legendas fechadas para quadros de vídeo em apresentações PowerPoint. As legendas são armazenadas no formato WebVTT e são expostas através da propriedade [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/pt/net/aspose.slides/ivideoframe/captiontracks/).

**Adicionar Legendas a um Quadro de Vídeo**

Para adicionar legendas a um quadro de vídeo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/) .
1. Adicione um vídeo à apresentação.
1. Adicione um objeto [IVideoFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/ivideoframe/) a um slide.
1. Use a coleção [CaptionTracks](https://reference.aspose.com/slides/pt/net/aspose.slides/ivideoframe/captiontracks/) para adicionar uma faixa de legenda WebVTT.
1. Salve a apresentação modificada.

O código a seguir mostra como adicionar legendas a um quadro de vídeo:

```cs
using (Presentation presentation = new Presentation())
{
    byte[] videoData = File.ReadAllBytes("video.mp4");
    IVideo video = presentation.Videos.AddVideo(videoData);

    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(0, 0, 100, 100, video);

    // Adiciona uma nova faixa de legendas a partir de um arquivo WebVTT.
    videoFrame.CaptionTracks.Add("English", "track.vtt");

    presentation.Save("video_with_captions.pptx", SaveFormat.Pptx);
}
```

A interface [ICaptionsCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/icaptionscollection/) também fornece uma sobrecarga que permite adicionar legendas a partir de um stream.

**Extrair Legendas de um Quadro de Vídeo**

Para extrair legendas de um quadro de vídeo:

1. Carregue a apresentação que contém o vídeo.
1. Encontre o objeto [IVideoFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/ivideoframe/) alvo.
1. Percorra a coleção [CaptionTracks](https://reference.aspose.com/slides/pt/net/aspose.slides/ivideoframe/captiontracks/).
1. Salve cada faixa de legenda em um arquivo `.vtt`.

O código a seguir mostra como extrair legendas de um quadro de vídeo:

```cs
using (Presentation presentation = new Presentation("video_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IVideoFrame videoFrame)
        {
            foreach (ICaptions captionTrack in videoFrame.CaptionTracks)
            {
                // Salva a faixa de legendas em um arquivo WebVTT.
                string filePath = $"{captionTrack.CaptionId}.vtt";
                File.WriteAllBytes(filePath, captionTrack.BinaryData);
            }
        }
    }
}
```

Cada objeto [ICaptions](https://reference.aspose.com/slides/pt/net/aspose.slides/icaptions/) expõe o identificador da legenda, o rótulo, os dados binários e o texto da legenda como uma string UTF‑8.

**Remover Legendas de um Quadro de Vídeo**

Para remover legendas de um quadro de vídeo:

1. Carregue a apresentação que contém o vídeo.
1. Obtenha o objeto [IVideoFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/ivideoframe/) alvo.
1. Remova as faixas de legenda da coleção [CaptionTracks](https://reference.aspose.com/slides/pt/net/aspose.slides/ivideoframe/captiontracks/).
1. Salve a apresentação modificada.

O código a seguir mostra como remover todas as legendas de um quadro de vídeo:

```cs
using (Presentation presentation = new Presentation("video_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes[0] as IVideoFrame;

    // Remove todas as legendas do quadro de vídeo.
    videoFrame.CaptionTracks.Clear();

    presentation.Save("video_without_captions.pptx", SaveFormat.Pptx);
}
```

Se precisar remover apenas uma faixa de legenda, use os métodos [Remove](https://reference.aspose.com/slides/pt/net/aspose.slides/captionscollection/remove/) ou [RemoveAt](https://reference.aspose.com/slides/pt/net/aspose.slides/captionscollection/removeat/) em vez de [Clear](https://reference.aspose.com/slides/pt/net/aspose.slides/captionscollection/clear/).

## **Extrair Vídeo de um Slide**
Além de adicionar vídeos a slides, o Aspose.Slides permite extrair vídeos incorporados em apresentações.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation) para carregar a apresentação que contém o vídeo. 
2. Percorra todos os objetos [ISlide](https://reference.aspose.com/slides/pt/net/aspose.slides/islide).
3. Percorra todos os objetos [IShape](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape) para encontrar um [VideoFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/videoframe). 
4. Salve o vídeo no disco.

Este código C# demonstra como extrair o vídeo de um slide de apresentação:

```c#
// Instancia um objeto Presentation que representa um arquivo de apresentação 
Presentation presentation = new Presentation("Video.pptx");

// Itera pelos slides
foreach (ISlide slide in presentation.Slides)
{
    // Itera pelas formas
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Salva o vídeo no disco assim que um VideoFrame contendo o vídeo for encontrado
        if (shape is VideoFrame)
        {
            IVideoFrame vf = shape as IVideoFrame;
            String type = vf.EmbeddedVideo.ContentType;
            int ss = type.LastIndexOf('/');
            type = type.Remove(0, type.LastIndexOf('/') + 1);
            Byte[] buffer = vf.EmbeddedVideo.BinaryData;
            using (FileStream stream = new FileStream("NewVideo_out." + type, FileMode.Create, FileAccess.Write, FileShare.Read))
            {                                                     
                stream.Write(buffer, 0, buffer.Length);
            }
        }
    }
}
```

## **FAQ**

**Quais parâmetros de reprodução de vídeo podem ser alterados para um VideoFrame?**

Você pode controlar o [modo de reprodução](https://reference.aspose.com/slides/pt/net/aspose.slides/videoframe/playmode/) (automático ou ao clicar) e o [looping](https://reference.aspose.com/slides/pt/net/aspose.slides/videoframe/playloopmode/). Essas opções estão disponíveis através das propriedades do objeto [VideoFrame](https://reference.aspose.com/slides/pt/net/aspose.slides/videoframe/).

**Adicionar um vídeo afeta o tamanho do arquivo PPTX?**

Sim. Quando você incorpora um vídeo local, os dados binários são incluídos no documento, portanto o tamanho da apresentação aumenta proporcionalmente ao tamanho do arquivo. Quando você adiciona um vídeo online, um link e uma miniatura são incorporados, de modo que o aumento de tamanho é menor.

**Posso substituir o vídeo em um VideoFrame existente sem alterar sua posição e tamanho?**

Sim. Você pode trocar o [conteúdo do vídeo](https://reference.aspose.com/slides/pt/net/aspose.slides/videoframe/embeddedvideo/) dentro do quadro preservando a geometria da forma; esse é um cenário comum para atualizar mídia em um layout existente.

**É possível determinar o tipo de conteúdo (MIME) de um vídeo incorporado?**

Sim. Um vídeo incorporado possui um [tipo de conteúdo](https://reference.aspose.com/slides/pt/net/aspose.slides/video/contenttype/) que pode ser lido e usado, por exemplo, ao salvá‑lo no disco.