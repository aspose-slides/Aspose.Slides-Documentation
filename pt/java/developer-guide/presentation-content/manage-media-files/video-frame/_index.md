---
title: Gerenciar Quadros de Vídeo em Apresentações Usando Java
linktitle: Quadro de Vídeo
type: docs
weight: 10
url: /pt/java/video-frame/
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
- Java
- Aspose.Slides
description: "Aprenda a adicionar e extrair programaticamente quadros de vídeo em slides PowerPoint e OpenDocument usando Aspose.Slides para Java. Guia rápido passo a passo."
---
## **Introdução**

Um vídeo bem posicionado em uma apresentação pode tornar sua mensagem mais persuasiva e aumentar os níveis de engajamento com o público. 

O PowerPoint permite adicionar vídeos a um slide em uma apresentação de duas maneiras:

* Adicionar ou incorporar um vídeo local (armazenado em seu computador)
* Adicionar um vídeo online (de uma fonte web como o YouTube).

Para permitir que você adicione vídeos (objetos de vídeo) a uma apresentação, o Aspose.Slides fornece as interfaces [IVideo](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ivideo/) e [IVideoFrame](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ivideoframe/), além de outros tipos relevantes. 

## **Criar Quadros de Vídeo Incorporados**

Se o arquivo de vídeo que você deseja adicionar ao seu slide estiver armazenado localmente, você pode criar um quadro de vídeo para incorporar o vídeo em sua apresentação. 

1. Crie uma instância da classe [Presentation ](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation)class.
1. Obtenha a referência de um slide por meio de seu índice. 
1. Adicione um objeto [IVideo](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ivideo/) e passe o caminho do arquivo de vídeo para incorporá-lo à apresentação. 
1. Adicione um objeto [IVideoFrame](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ivideoframe/) para criar um quadro para o vídeo.  
1. Salve a apresentação modificada. 

Este código Java mostra como adicionar um vídeo armazenado localmente a uma apresentação:

```java
// Instancia a classe Presentation
Presentation pres = new Presentation("pres.pptx");
try {
    // Carrega o vídeo
    FileInputStream fileStream = new FileInputStream("Wildlife.mp4");
    
    IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);

    // Obtém o primeiro slide e adiciona um quadro de vídeo
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);

    // Salva a apresentação no disco
    pres.save("pres-with-video.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

Alternativamente, você pode adicionar um vídeo passando seu caminho de arquivo diretamente para o método [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) :

``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```


## **Criar Quadros de Vídeo com Vídeo de Fontes Web**

O Microsoft [PowerPoint 2013 e posterior](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) oferece suporte a vídeos do YouTube em apresentações. Se o vídeo que você deseja usar estiver disponível online (por exemplo, no YouTube), você pode adicioná-lo à sua apresentação por meio de seu link web. 

1. Crie uma instância da classe [Presentation ](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation)class
1. Obtenha a referência de um slide por meio de seu índice. 
1. Adicione um objeto [IVideo](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ivideo/) e passe o link para o vídeo.
1. Defina uma miniatura para o quadro de vídeo. 
1. Salve a apresentação. 

Este código Java mostra como adicionar um vídeo da web a um slide em uma apresentação do PowerPoint:

```java
// Instancia um objeto Presentation que representa um arquivo de apresentação 
Presentation pres = new Presentation();
try {
    addVideoFromYouTube(pres, "Tj75Arhq5ho");
    pres.save("out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

```java
private static void addVideoFromYouTube(Presentation pres, String videoID)
{
    // Adiciona um VideoFrame
    IVideoFrame videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(
            10, 10, 427, 240, "https://www.youtube.com/embed/" + videoID);
    videoFrame.setPlayMode(VideoPlayModePreset.Auto);

    // Carrega a miniatura
    String thumbnailUri = "http://img.youtube.com/vi/" + videoID + "/hqdefault.jpg";
    URL url;

    try {
        url = new URL(thumbnailUri);
        videoFrame.getPictureFormat().getPicture().setImage(pres.getImages().addImage(url.openStream()));
    } catch (MalformedURLException e) {
        e.printStackTrace();
    } catch (IOException e) {
        e.printStackTrace();
    }
}
```

## **Gerenciar Legendas de Vídeo**

O Aspose.Slides permite gerenciar legendas fechadas para quadros de vídeo em apresentações do PowerPoint. As legendas são armazenadas no formato WebVTT e são expostas através do método [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) .

**Adicionar Legendas a um Quadro de Vídeo**

Para adicionar legendas a um quadro de vídeo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/) .
1. Adicione um vídeo à apresentação.
1. Adicione um objeto [IVideoFrame](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ivideoframe/) a um slide.
1. Use a [ICaptionsCollection](https://reference.aspose.com/slides/pt/java/com.aspose.slides/icaptionscollection/) retornada por [getCaptionTracks](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) para adicionar uma faixa de legenda WebVTT.
1. Salve a apresentação modificada.

O código a seguir mostra como adicionar legendas a um quadro de vídeo:

```java
Presentation presentation = new Presentation();
try {
    byte[] videoData = Files.readAllBytes(Paths.get("video.mp4"));
    IVideo video = presentation.getVideos().addVideo(videoData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // Adiciona uma nova trilha de legendas a partir de um arquivo WebVTT.
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A interface [ICaptionsCollection](https://reference.aspose.com/slides/pt/java/com.aspose.slides/icaptionscollection/) também fornece uma sobrecarga que permite adicionar legendas a partir de um fluxo.

**Extrair Legendas de um Quadro de Vídeo**

Para extrair legendas de um quadro de vídeo:

1. Carregue a apresentação que contém o vídeo.
1. Encontre o objeto [IVideoFrame](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ivideoframe/) alvo.
1. Percorra as faixas de legenda na [ICaptionsCollection](https://reference.aspose.com/slides/pt/java/com.aspose.slides/icaptionscollection/).
1. Salve cada faixa de legenda em um arquivo `.vtt`.

O código a seguir mostra como extrair legendas de um quadro de vídeo:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame)shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                // Salva a faixa de legendas em um arquivo WebVTT.
                String filePath = captionTrack.getCaptionId().toString() + ".vtt";
                Files.write(Paths.get(filePath), captionTrack.getBinaryData());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Cada objeto [ICaptions](https://reference.aspose.com/slides/pt/java/com.aspose.slides/icaptions/) expõe o identificador da legenda, rótulo, dados binários e o texto da legenda como uma string UTF-8.

**Remover Legendas de um Quadro de Vídeo**

Para remover legendas de um quadro de vídeo:

1. Carregue a apresentação que contém o vídeo.
1. Obtenha o objeto [IVideoFrame](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ivideoframe/) alvo.
1. Remova as faixas de legenda da [ICaptionsCollection](https://reference.aspose.com/slides/pt/java/com.aspose.slides/icaptionscollection/).
1. Salve a apresentação modificada.

O código a seguir mostra como remover todas as legendas de um quadro de vídeo:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = (IVideoFrame)slide.getShapes().get_Item(0);

    // Remove todas as legendas do quadro de vídeo.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Se precisar remover apenas uma faixa de legenda, use os métodos [remove](https://reference.aspose.com/slides/pt/java/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) ou [removeAt](https://reference.aspose.com/slides/pt/java/com.aspose.slides/icaptionscollection/#removeAt-int-) em vez de [clear](https://reference.aspose.com/slides/pt/java/com.aspose.slides/icaptionscollection/#clear--) .

## **Extrair Vídeo de Slides**

Além de adicionar vídeos aos slides, o Aspose.Slides permite extrair vídeos incorporados nas apresentações.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation) para carregar a apresentação que contém o vídeo. 
2. Percorra todos os objetos [ISlide](https://reference.aspose.com/slides/pt/java/com.aspose.slides/islide/) .
3. Percorra todos os objetos [IShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ishape/) para encontrar um [VideoFrame](https://reference.aspose.com/slides/pt/java/com.aspose.slides/videoframe/) . 
4. Salve o vídeo no disco.

Este código Java mostra como extrair o vídeo de um slide de apresentação:

```java
// Instancia um objeto Presentation que representa um arquivo de apresentação 
Presentation pres = new Presentation("VideoSample.pptx");
try {
    for (ISlide slide : pres.getSlides()) 
    {
        for (IShape shape : slide.getShapes()) 
        {
            if (shape instanceof VideoFrame) 
            {
                IVideoFrame vf = (IVideoFrame) shape;
                String type = vf.getEmbeddedVideo().getContentType();
                int ss = type.lastIndexOf('-');
                byte[] buffer = vf.getEmbeddedVideo().getBinaryData();

                //Obtém a extensão do arquivo
                int charIndex = type.indexOf("/");
                type = type.substring(charIndex + 1);

                FileOutputStream fop = new FileOutputStream("testing2." + type);
                fop.write(buffer);
                fop.flush();
                fop.close();
            }
        }
    }
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Quais parâmetros de reprodução de vídeo podem ser alterados para um VideoFrame?**

Você pode controlar o [modo de reprodução](https://reference.aspose.com/slides/pt/java/com.aspose.slides/videoframe/#setPlayMode-int-) (auto ou ao clicar) e o [looping](https://reference.aspose.com/slides/pt/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-). Essas opções estão disponíveis nas propriedades do objeto [VideoFrame](https://reference.aspose.com/slides/pt/java/com.aspose.slides/videoframe/) .

**Adicionar um vídeo afeta o tamanho do arquivo PPTX?**

Sim. Quando você incorpora um vídeo local, os dados binários são incluídos no documento, portanto o tamanho da apresentação cresce proporcionalmente ao tamanho do arquivo. Quando você adiciona um vídeo online, um link e uma miniatura são incorporados, de modo que o aumento de tamanho é menor.

**Posso substituir o vídeo em um VideoFrame existente sem alterar sua posição e tamanho?**

Sim. Você pode trocar o [conteúdo do vídeo](https://reference.aspose.com/slides/pt/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) dentro do quadro mantendo a geometria da forma; este é um cenário comum para atualizar mídia em um layout existente.

**É possível determinar o tipo de conteúdo (MIME) de um vídeo incorporado?**

Sim. Um vídeo incorporado possui um [tipo de conteúdo](https://reference.aspose.com/slides/pt/java/com.aspose.slides/video/#getContentType--) que pode ser lido e usado, por exemplo ao salvá‑lo no disco.