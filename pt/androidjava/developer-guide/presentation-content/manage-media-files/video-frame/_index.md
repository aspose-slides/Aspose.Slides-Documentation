---
title: Gerenciar Quadros de Vídeo em Apresentações no Android
linktitle: Quadro de Vídeo
type: docs
weight: 10
url: /pt/androidjava/video-frame/
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
- Android
- Java
- Aspose.Slides
description: "Aprenda a adicionar e extrair programaticamente quadros de vídeo em slides PowerPoint e OpenDocument usando Aspose.Slides para Android via Java. Guia rápido passo a passo."
---
## **Introdução**

Os vídeos podem ajudar a explicar ideias e envolver o público. Aspose.Slides for Android via Java permite adicionar quadros de vídeo aos slides, ajustar as configurações de reprodução, gerenciar legendas e extrair dados de vídeo incorporados.

O PowerPoint suporta vídeos locais e links para vídeos online, como vídeos do YouTube.

Para representar dados de vídeo e quadros de vídeo, o Aspose.Slides fornece a interface [IVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideo/) , a interface [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) e outros tipos relevantes.

## **Criar um Quadro de Vídeo Incorporado**

Se o arquivo de vídeo que você deseja adicionar ao seu slide estiver armazenado localmente, você pode criar um quadro de vídeo para incorporar o vídeo em sua apresentação.

Este exemplo incorpora um vídeo local no primeiro slide de uma apresentação existente e salva o resultado. As coordenadas e dimensões do quadro estão em pontos. O fluxo permanece aberto até que a gravação seja concluída porque [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadingstreambehavior/) o mantém bloqueado enquanto a apresentação o utiliza.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation("presentation.pptx");
try (FileInputStream videoStream = new FileInputStream("video.mp4")) {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideo video = presentation.getVideos().addVideo(videoStream, LoadingStreamBehavior.KeepLocked);
    slide.getShapes().addVideoFrame(10, 10, 150, 250, video);

    presentation.save("embedded_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Você também pode passar o caminho de um vídeo local diretamente para [addVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-java.lang.String-). Este exemplo incorpora o vídeo no primeiro slide de uma nova apresentação. O vídeo deve permanecer acessível até que a apresentação seja salva.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addVideoFrame(50, 150, 300, 150, "video.avi");

    presentation.save("video_from_path.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Criar um Quadro de Vídeo com Vídeo de uma Fonte Web**

O Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) suporta vídeos online em apresentações. Você pode criar um quadro de vídeo que aponta para um vídeo online, como um vídeo do YouTube.

Este exemplo adiciona um link de vídeo do YouTube e a miniatura ao primeiro slide. Substitua o identificador do vídeo para usar outro vídeo. O método [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setPlayMode-int-) solicita reprodução automática. Baixar a miniatura e reproduzir o vídeo requer acesso à internet. O visualizador de apresentação também deve suportar reprodução de vídeo online.

```java
import com.aspose.slides.*;
import java.io.InputStream;
import java.net.URL;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    String videoId = "aqz-KE-bpKQ";
    String videoUrl = "https://www.youtube.com/embed/" + videoId;
    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(10, 10, 427, 240, videoUrl);
    videoFrame.setPlayMode(VideoPlayModePreset.Auto);

    String thumbnailUrl = "https://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
    URL thumbnailLocation = new URL(thumbnailUrl);
    try (InputStream thumbnailStream = thumbnailLocation.openStream()) {
        IPPImage thumbnail = presentation.getImages().addImage(thumbnailStream);
        videoFrame.getPictureFormat().getPicture().setImage(thumbnail);
    }

    presentation.save("online_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Reproduzir um Vídeo em Modo de Tela Cheia**

Em uma apresentação de treinamento, você pode reproduzir uma demonstração de software em modo de tela cheia para que o público veja os detalhes. Chame [setFullScreenMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) com `true` para habilitar esse comportamento durante a reprodução.

Este exemplo abre uma apresentação, encontra o primeiro [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) no primeiro slide e habilita a reprodução em tela cheia. A apresentação de entrada deve conter ao menos um slide com um quadro de vídeo existente no primeiro slide.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("training.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            videoFrame.setFullScreenMode(true);
            break;
        }
    }

    presentation.save("full_screen_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A reprodução em tela cheia controla como o vídeo é exibido. Independentemente, [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) controla se ele inicia automaticamente ou por clique, e [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) controla se ele se repete. Para escolher o comportamento de início, configure o modo de reprodução para [VideoPlayModePreset.Auto ou VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoplaymodepreset/). O exemplo preserva as configurações existentes de início e repetição.

## **Rebobinar um Vídeo Após a Reprodução**

Em uma apresentação de treinamento, devolver um vídeo de demonstração ao início o deixa pronto para que o apresentador o reproduza novamente. Chame [setRewindVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setRewindVideo-boolean-) com `true` para retornar o vídeo ao início após a reprodução terminar.

Este exemplo abre uma apresentação, encontra o primeiro [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) no primeiro slide e habilita o rebobinamento. Ele desabilita a repetição para que a reprodução possa terminar e configura a reprodução para iniciar ao clique. A apresentação de entrada deve conter ao menos um slide com um quadro de vídeo existente no primeiro slide.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("training.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            videoFrame.setRewindVideo(true);
            videoFrame.setPlayLoopMode(false);
            videoFrame.setPlayMode(VideoPlayModePreset.OnClick);
            break;
        }
    }

    presentation.save("rewind_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O rebobinamento retorna o vídeo ao início sem iniciá‑lo novamente. Em contraste, chamar [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) com `true` repete a reprodução automaticamente. Mantenha a repetição desativada quando quiser que o vídeo termine e permaneça pronto para ser reproduzido novamente. [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) controla independentemente o início automático ou por clique; este exemplo usa [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoplaymodepreset/) para que o apresentador controle quando a reprodução começa. Defina o modo de reprodução após a configuração de repetição, conforme mostrado no exemplo. O rebobinamento funciona independentemente de [setFullScreenMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setFullScreenMode-boolean-).

## **Recortar um Quadro de Vídeo**

Use [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) e [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) para pular parte do início ou do fim de um vídeo durante a reprodução. Ambos os valores estão em milissegundos. O recorte altera as configurações de reprodução sem modificar os dados de vídeo incorporados.

**Definir Configurações de Recorte**

Este exemplo incorpora um vídeo local e pula os primeiros 2,5 segundos e o último segundo durante a reprodução. Use um vídeo com mais de 3,5 segundos para que reste um segmento reproduzível.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideo video;
    try (FileInputStream videoStream = new FileInputStream("video.mp4")) {
        video = presentation.getVideos().addVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
    }

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);
    videoFrame.setTrimFromStart(2500f);
    videoFrame.setTrimFromEnd(1000f);

    presentation.save("video_with_trim.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Ler Configurações de Recorte**

Este exemplo exibe os valores de recorte do primeiro quadro de vídeo no primeiro slide em milissegundos. A apresentação deve conter ao menos um slide. Se esse slide não possuir quadro de vídeo, nada será exibido. O exemplo anterior produz os valores 2500 e 1000.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("video_with_trim.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            System.out.println("Trim from start: " + videoFrame.getTrimFromStart() + " ms");
            System.out.println("Trim from end: " + videoFrame.getTrimFromEnd() + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **Gerenciar Legendas de Vídeo**

Aspose.Slides permite gerenciar legendas fechadas para quadros de vídeo em apresentações do PowerPoint. As legendas são armazenadas no formato WebVTT e são expostas através do método [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) .

### **Adicionar Legendas a um Quadro de Vídeo**

Este exemplo incorpora um vídeo local e adiciona uma faixa de legenda WebVTT rotulada como English. As marcações de tempo da legenda devem corresponder ao vídeo. A apresentação salva inclui tanto o vídeo quanto suas legendas.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideo video;
    try (FileInputStream videoStream = new FileInputStream("video.mp4")) {
        video = presentation.getVideos().addVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
    }

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A interface [ICaptionsCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/) também fornece uma sobrecarga que permite adicionar legendas a partir de um fluxo.

### **Extrair Legendas de um Quadro de Vídeo**

Este exemplo salva todas as faixas de legenda dos quadros de vídeo no primeiro slide como arquivos WebVTT separados. Números sequenciais mantêm os arquivos de saída distintos. O console relata o número de faixas extraídas. A apresentação deve conter ao menos um slide.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int trackCount = 0;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                trackCount++;
                try (FileOutputStream outputStream = new FileOutputStream("captions_" + trackCount + ".vtt")) {
                    outputStream.write(captionTrack.getBinaryData());
                }
            }
        }
    }

    System.out.println("Caption tracks extracted: " + trackCount);
} finally {
    presentation.dispose();
}
```

Cada objeto [ICaptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/) expõe o identificador da legenda, o rótulo, os dados binários e o texto da legenda como uma string UTF‑8.

### **Remover Legendas de um Quadro de Vídeo**

Este exemplo remove todas as legendas do quadro de vídeo na primeira posição da forma no primeiro slide e salva o resultado. Assume‑se que o slide e a forma existam e que a forma seja um quadro de vídeo.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideoFrame videoFrame = (IVideoFrame) slide.getShapes().get_Item(0);
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Se precisar remover apenas uma faixa de legenda, use os métodos [remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#remove-com.aspose.slides.ICaptions-) ou [removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#removeAt-int-) em vez de [clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#clear--).

### **Pesquisar Legendas de Vídeo**

[ICaptions.getDataAsString](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/#getDataAsString--) retorna a faixa WebVTT completa, incluindo seu cabeçalho, linhas de tempo e texto da legenda. Você pode pesquisar as cues na memória para encontrar uma frase falada e seu carimbo de tempo. Por exemplo, uma faixa em inglês no slide 2 pode conter o seguinte texto.

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

O exemplo abre `captioned_media.pptx` e usa [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) para ler as faixas de cada quadro de vídeo de nível superior em todas as slides. Em uma cue de texto simples, a linha de tempo contém `-->`, e uma linha vazia termina a cue. Quando a legenda contém “café” em qualquer capitalização, o exemplo exibe o número da slide, o rótulo da faixa, a linha de tempo original e a legenda completa.

```java
import com.aspose.slides.*;
import java.util.Locale;
import java.util.Scanner;

Presentation presentation = new Presentation("captioned_media.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (!(shape instanceof IVideoFrame)) {
                continue;
            }
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions track : videoFrame.getCaptionTracks()) {
                try (Scanner reader = new Scanner(track.getDataAsString())) {
                    while (reader.hasNextLine()) {
                        String timing = reader.nextLine();
                        if (!timing.contains("-->")) {
                            continue;
                        }
                        StringBuilder caption = new StringBuilder();
                        while (reader.hasNextLine()) {
                            String line = reader.nextLine();
                            if (line.isEmpty()) {
                                break;
                            }
                            if (caption.length() > 0) {
                                caption.append('\n');
                            }
                            caption.append(line);
                        }
                        if (caption.toString().toLowerCase(Locale.ROOT).contains("café")) {
                            System.out.printf("Slide %d | %s | %s%n", slide.getSlideNumber(), track.getLabel(), timing);
                            System.out.println(caption);
                        }
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Pesquisar por “café” produz uma correspondência para a faixa de exemplo. A pesquisa exclui o cabeçalho da faixa e preserva a configuração de tempo na saída.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Extrair Vídeo de um Slide**

Além de adicionar vídeos aos slides, o Aspose.Slides permite extrair vídeos incorporados em apresentações.

Este exemplo extrai vídeos incorporados de cada slide em arquivos binários separados e numerados. Vídeos vinculados são ignorados porque não possuem dados incorporados. O console exibe o tipo MIME de cada vídeo e o total de vídeos. A saída usa a extensão genérica `.bin`; altere-a para corresponder ao tipo de mídia relatado, se necessário.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("presentation_with_videos.pptx");
try {
    int videoCount = 0;
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IVideoFrame) {
                IVideoFrame videoFrame = (IVideoFrame) shape;
                IVideo video = videoFrame.getEmbeddedVideo();
                if (video == null) {
                    System.out.println("Skipped a linked video: no embedded data is available.");
                    continue;
                }

                videoCount++;
                try (FileOutputStream outputStream = new FileOutputStream("extracted_video_" + videoCount + ".bin")) {
                    outputStream.write(video.getBinaryData());
                }
                System.out.println("Video " + videoCount + ": " + video.getContentType());
            }
        }
    }

    System.out.println("Embedded videos extracted: " + videoCount);
} finally {
    presentation.dispose();
}
```

## **Perguntas Frequentes**

**Quais parâmetros de reprodução de vídeo podem ser alterados para um quadro de vídeo?**

Você pode controlar o [modo de reprodução](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) (auto ou ao clique) e a [repetição](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-). Essas opções estão disponíveis por meio dos métodos do objeto [VideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/).

**Adicionar um vídeo afeta o tamanho do arquivo PPTX?**

Sim. Quando você incorpora um vídeo local, os dados binários são incluídos no documento, portanto o tamanho da apresentação cresce proporcionalmente ao tamanho do arquivo. Quando você vincula a um vídeo online e adiciona uma miniatura, a apresentação armazena o link e a imagem de pré‑visualização em vez dos dados do vídeo, de modo que o aumento de tamanho costuma ser menor.

**Posso substituir o vídeo em um quadro de vídeo existente sem alterar sua posição e tamanho?**

Sim. Você pode trocar o [conteúdo do vídeo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) dentro do quadro preservando a geometria da forma; esse é um cenário comum para atualizar mídia em um layout existente.

**É possível determinar o tipo de conteúdo (MIME) de um vídeo incorporado?**

Sim. Um vídeo incorporado possui um [tipo de conteúdo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/video/#getContentType--) que pode ser lido e usado, por exemplo, ao salvá‑lo em disco.