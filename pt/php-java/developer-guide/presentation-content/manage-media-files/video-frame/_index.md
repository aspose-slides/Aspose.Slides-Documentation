---
title: Gerenciar Quadros de Vídeo em Apresentações Usando PHP
linktitle: Quadro de Vídeo
type: docs
weight: 10
url: /pt/php-java/video-frame/
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
- PHP
- Aspose.Slides
description: "Aprenda a adicionar e extrair programaticamente quadros de vídeo em slides PowerPoint e OpenDocument usando Aspose.Slides para PHP via Java. Guia rápido passo a passo."
---
## **Introdução**

Um vídeo bem colocado em uma apresentação pode tornar sua mensagem mais envolvente e aumentar o nível de engajamento com o público. 

PowerPoint permite que você adicione vídeos a um slide em uma apresentação de duas maneiras:

* Adicionar ou incorporar um vídeo local (armazenado na sua máquina)
* Adicionar um vídeo online (de uma fonte web como o YouTube).

Para permitir que você adicione vídeos (objetos de vídeo) a uma apresentação, Aspose.Slides fornece a classe [Video](https://reference.aspose.com/slides/pt/php-java/aspose.slides/video/), a classe [VideoFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/videoframe/) e outros tipos relevantes.

## **Criar Quadros de Vídeo Incorporados**

Se o arquivo de vídeo que você deseja adicionar ao seu slide estiver armazenado localmente, você pode criar um quadro de vídeo para incorporar o vídeo na sua apresentação. 

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/).
1. Obtenha a referência de um slide por meio do seu índice. 
1. Adicione um objeto [Video](https://reference.aspose.com/slides/pt/php-java/aspose.slides/video/) e passe o caminho do arquivo de vídeo para incorporar o vídeo à apresentação.
1. Adicione um objeto [VideoFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/videoframe/) para criar um quadro para o vídeo.
1. Salve a apresentação modificada. 

Este código PHP mostra como adicionar um vídeo armazenado localmente a uma apresentação:

```php
  # Instancia a classe Presentation
  $pres = new Presentation("pres.pptx");
  try {
    # Carrega o vídeo
    $fileStream = new Java("java.io.FileInputStream", "Wildlife.mp4");
    $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
    # Obtém o primeiro slide e adiciona um quadro de vídeo
    $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(10, 10, 150, 250, $video);
    # Salva a apresentação no disco
    $pres->save("pres-with-video.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Como alternativa, você pode adicionar um vídeo passando diretamente o caminho do arquivo ao método [addVideoFrame(float x, float y, float width, float height, Video video)](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shapecollection/addvideoframe/):

```php
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    $vf = $sld->getShapes()->addVideoFrame(50, 150, 300, 150, "video1.avi");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Criar Quadros de Vídeo com Vídeo de Fontes Web**

O Microsoft [PowerPoint 2013 e posterior](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) oferece suporte a vídeos do YouTube em apresentações. Se o vídeo que você deseja usar estiver disponível online (por exemplo, no YouTube), você pode adicioná‑lo à sua apresentação através do seu link web. 

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/).
1. Obtenha a referência de um slide por meio do seu índice. 
1. Adicione um objeto [Video](https://reference.aspose.com/slides/pt/php-java/aspose.slides/video/) e passe o link para o vídeo.
1. Defina uma miniatura para o quadro de vídeo. 
1. Salve a apresentação. 

Este código PHP mostra como adicionar um vídeo da web a um slide em uma apresentação PowerPoint:

```php
  # Instancia um objeto Presentation que representa um arquivo de apresentação
  $pres = new Presentation();
  try {
    addVideoFromYouTube($pres, "Tj75Arhq5ho");
    $pres->save("out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

```php

```

## **Cortar um Quadro de Vídeo**

Aspose.Slides permite que você controle qual parte de um vídeo é reproduzida definindo os valores trim‑from‑start e trim‑from‑end através de [VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/pt/php-java/aspose.slides/videoframe/#setTrimFromStart) e [VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/pt/php-java/aspose.slides/videoframe/#setTrimFromEnd). Ambos os valores são especificados em milissegundos e definem quanto tempo é pulado do início e do final do vídeo, respectivamente. Essas configurações alteram as opções de reprodução do vídeo na apresentação; elas não cortam nem modificam os dados binários do vídeo incorporado.

**Definir Configurações de Corte**

Para criar um quadro de vídeo e definir suas configurações de corte:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/).
1. Adicione um objeto [Video](https://reference.aspose.com/slides/pt/php-java/aspose.slides/video/) à apresentação.
1. Adicione um objeto [VideoFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/videoframe/) a um slide.
1. Defina os valores trim‑from‑start e trim‑from‑end através de [VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/pt/php-java/aspose.slides/videoframe/#setTrimFromStart) e [VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/pt/php-java/aspose.slides/videoframe/#setTrimFromEnd).
1. Salve a apresentação modificada.

O exemplo de código a seguir ignora os primeiros 2,5 s e o último segundo de um vídeo incorporado durante a reprodução:

```php
$presentation = new Presentation();
$videoStream = null;
try {
    $videoStream = new Java("java.io.FileInputStream", "video.mp4");
    $video = $presentation->getVideos()->addVideo(
        $videoStream, LoadingStreamBehavior::ReadStreamAndRelease);
    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->addVideoFrame(50, 50, 640, 360, $video);

    $videoFrame->setTrimFromStart(2500);
    $videoFrame->setTrimFromEnd(1000);

    $presentation->save("video_with_trim.pptx", SaveFormat::Pptx);
} finally {
    if ($videoStream !== null) {
        $videoStream->close();
    }
    $presentation->dispose();
}
```

**Ler Configurações de Corte**

Para inspecionar as configurações de corte existentes, carregue uma apresentação, encontre um objeto [VideoFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/videoframe/) entre as formas do primeiro slide e leia os valores através de [VideoFrame::getTrimFromStart](https://reference.aspose.com/slides/pt/php-java/aspose.slides/videoframe/#getTrimFromStart) e [VideoFrame::getTrimFromEnd](https://reference.aspose.com/slides/pt/php-java/aspose.slides/videoframe/#getTrimFromEnd).

O exemplo de código a seguir localiza o primeiro quadro de vídeo no primeiro slide e relata suas configurações de corte em milissegundos:

```php
$presentation = new Presentation("video_with_trim.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $trimFromStart = java_values($videoFrame->getTrimFromStart());
            $trimFromEnd = java_values($videoFrame->getTrimFromEnd());

            echo "Trim from start: " . $trimFromStart . " ms\n";
            echo "Trim from end: " . $trimFromEnd . " ms\n";
            break;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Gerenciar Legendas de Vídeo**

Aspose.Slides permite que você gerencie legendas fechadas para quadros de vídeo em apresentações PowerPoint. As legendas são armazenadas no formato WebVTT e são expostas através do método [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/pt/php-java/aspose.slides/videoframe/#getCaptionTracks).

**Adicionar Legendas a um Quadro de Vídeo**

Para adicionar legendas a um quadro de vídeo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/).
1. Adicione um vídeo à apresentação.
1. Adicione um objeto [VideoFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/videoframe/) a um slide.
1. Use a coleção [CaptionsCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/captionscollection/) retornada por [getCaptionTracks](https://reference.aspose.com/slides/pt/php-java/aspose.slides/videoframe/#getCaptionTracks) para adicionar uma faixa de legenda WebVTT.
1. Salve a apresentação modificada.

O código a seguir mostra como adicionar legendas a um quadro de vídeo:

```php
$presentation = new Presentation();
try {
    $videoData = file_get_contents("video.mp4");
    $video = $presentation->getVideos()->addVideo($videoData);

    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->addVideoFrame(0, 0, 100, 100, $video);

    // Adiciona uma nova faixa de legendas a partir de um arquivo WebVTT.
    $videoFrame->getCaptionTracks()->add("English", "track.vtt");

    $presentation->save("video_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

A classe [CaptionsCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/captionscollection/) também oferece uma sobrecarga que permite adicionar legendas a partir de um fluxo.

**Extrair Legendas de um Quadro de Vídeo**

Para extrair legendas de um quadro de vídeo:

1. Carregue a apresentação que contém o vídeo.
1. Encontre o objeto [VideoFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/videoframe/) alvo.
1. Percorra a coleção retornada por [getCaptionTracks](https://reference.aspose.com/slides/pt/php-java/aspose.slides/videoframe/#getCaptionTracks).
1. Salve cada faixa de legenda em um arquivo `.vtt`.

O código a seguir mostra como extrair legendas de um quadro de vídeo:

```php
$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $trackCount = java_values($videoFrame->getCaptionTracks()->getCount());
            for ($trackIndex = 0; $trackIndex < $trackCount; $trackIndex++) {
                $captionTrack = $videoFrame->getCaptionTracks()->get_Item($trackIndex);
                // Salva a faixa de legendas em um arquivo WebVTT.
                $filePath = $captionTrack->getCaptionId() . ".vtt";
                file_put_contents($filePath, $captionTrack->getBinaryData());
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Cada objeto [Captions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/captions/) expõe o identificador da legenda, o rótulo, os dados binários e o texto da legenda como uma string UTF‑8.

**Remover Legendas de um Quadro de Vídeo**

Para remover legendas de um quadro de vídeo:

1. Carregue a apresentação que contém o vídeo.
1. Obtenha o objeto [VideoFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/videoframe/) alvo.
1. Remova as faixas de legenda da coleção retornada por [getCaptionTracks](https://reference.aspose.com/slides/pt/php-java/aspose.slides/videoframe/#getCaptionTracks).
1. Salve a apresentação modificada.

O código a seguir mostra como remover todas as legendas de um quadro de vídeo:

```php
$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->get_Item(0); // tipo: VideoFrame

    // Remove todas as legendas do quadro de vídeo.
    $videoFrame->getCaptionTracks()->clear();

    $presentation->save("video_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Se precisar remover apenas uma faixa de legenda, use os métodos [remove](https://reference.aspose.com/slides/pt/php-java/aspose.slides/captionscollection/#remove) ou [removeAt](https://reference.aspose.com/slides/pt/php-java/aspose.slides/captionscollection/#removeAt) em vez de [clear](https://reference.aspose.com/slides/pt/php-java/aspose.slides/captionscollection/#clear).

## **Extrair Vídeo de Slides**

Além de adicionar vídeos a slides, Aspose.Slides permite extrair vídeos incorporados em apresentações.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/) para carregar a apresentação que contém o vídeo.
2. Percorra todos os objetos [Slide](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slide/).
3. Percorra todos os objetos [Shape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/) para encontrar um [VideoFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/videoframe/).
4. Salve o vídeo no disco.

Este código PHP mostra como extrair o vídeo de um slide de apresentação:

```php
  # Instancia um objeto Presentation que representa um arquivo de apresentação
  $pres = new Presentation("VideoSample.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
          $vf = $shape;
          $type = $vf->getEmbeddedVideo()->getContentType();
          $ss = $type->lastIndexOf('-');
          $buffer = $vf->getEmbeddedVideo()->getBinaryData();
          # Obtém a extensão do arquivo
          $charIndex = $type->indexOf("/");
          $type = $type->substring($charIndex + 1);
          $fop = new Java("java.io.FileOutputStream", "testing2." . $type);
          $fop->write($buffer);
          $fop->flush();
          $fop->close();
        }
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Quais parâmetros de reprodução de vídeo podem ser alterados para um VideoFrame?**

Você pode controlar o [modo de reprodução](https://reference.aspose.com/slides/pt/php-java/aspose.slides/videoframe/setplaymode/) (automático ou ao clicar) e o [looping](https://reference.aspose.com/slides/pt/php-java/aspose.slides/videoframe/setplayloopmode/). Essas opções estão disponíveis nas propriedades do objeto [VideoFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/videoframe/).

**Adicionar um vídeo afeta o tamanho do arquivo PPTX?**

Sim. Quando você incorpora um vídeo local, os dados binários são incluídos no documento, portanto o tamanho da apresentação cresce proporcionalmente ao tamanho do arquivo. Quando você adiciona um vídeo online, um link e uma miniatura são incorporados, de modo que o aumento de tamanho é menor.

**Posso substituir o vídeo em um VideoFrame existente sem alterar sua posição e tamanho?**

Sim. Você pode trocar o [conteúdo do vídeo](https://reference.aspose.com/slides/pt/php-java/aspose.slides/videoframe/setembeddedvideo/) dentro do quadro mantendo a geometria da forma; esse é um cenário comum para atualizar mídia em um layout existente.

**É possível determinar o tipo de conteúdo (MIME) de um vídeo incorporado?**

Sim. Um vídeo incorporado possui um [tipo de conteúdo](https://reference.aspose.com/slides/pt/php-java/aspose.slides/video/getcontenttype/) que você pode ler e usar, por exemplo, ao salvá‑lo no disco.