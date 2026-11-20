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
description: "Aprenda a adicionar e extrair quadros de vídeo programaticamente em slides PowerPoint e OpenDocument usando Aspose.Slides para PHP via Java. Guia rápido passo a passo."
---
## **Introdução**

Os vídeos podem ajudar a explicar ideias e envolver o público. Aspose.Slides for PHP via Java permite adicionar quadros de vídeo aos slides, ajustar as configurações de reprodução, gerenciar legendas e extrair dados de vídeo incorporados.

O PowerPoint suporta vídeos locais e links para vídeos online, como vídeos do YouTube.

Para representar dados de vídeo e quadros de vídeo, Aspose.Slides fornece a classe [Video](https://reference.aspose.com/slides/php-java/aspose.slides/video/) a classe [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) e outros tipos relevantes.

## **Criar um Quadro de Vídeo Incorporado**

Se o arquivo de vídeo que você deseja adicionar ao seu slide estiver armazenado localmente, você pode criar um quadro de vídeo para incorporar o vídeo em sua apresentação.

Este exemplo incorpora um vídeo local no primeiro slide de uma apresentação existente e salva o resultado. As coordenadas e dimensões do quadro estão em pontos. O fluxo permanece aberto até que a gravação termine porque [LoadingStreamBehavior::KeepLocked](https://reference.aspose.com/slides/php-java/aspose.slides/loadingstreambehavior/) o mantém bloqueado enquanto a apresentação o utiliza.

```php
use aspose\slides\LoadingStreamBehavior;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
$videoStream = null;
try {
    $videoStream = new Java("java.io.FileInputStream", "video.mp4");
    $slide = $presentation->getSlides()->get_Item(0);

    $video = $presentation->getVideos()->addVideo($videoStream, LoadingStreamBehavior::KeepLocked);
    $slide->getShapes()->addVideoFrame(10, 10, 150, 250, $video);

    $presentation->save("embedded_video.pptx", SaveFormat::Pptx);
} finally {
    if ($videoStream !== null) {
        $videoStream->close();
    }
    $presentation->dispose();
}
```

Você também pode passar um caminho de vídeo local diretamente para [addVideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addVideoFrame). Este exemplo incorpora o vídeo no primeiro slide de uma nova apresentação. O vídeo deve permanecer acessível até que a apresentação seja salva.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $slide->getShapes()->addVideoFrame(50, 150, 300, 150, "video.avi");

    $presentation->save("video_from_path.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Criar um Quadro de Vídeo com Vídeo de uma Fonte Web**

O Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) suporta vídeos online em apresentações. Você pode criar um quadro de vídeo que vincula a um vídeo online, como um vídeo do YouTube.

Este exemplo adiciona um link de vídeo do YouTube e uma miniatura ao primeiro slide. Substitua o identificador do vídeo para usar outro vídeo. O método [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) solicita reprodução automática. Baixar a miniatura e reproduzir o vídeo requer acesso à internet. O visualizador da apresentação também deve suportar a reprodução de vídeo online.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\VideoPlayModePreset;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoId = "aqz-KE-bpKQ";
    $videoUrl = "https://www.youtube.com/embed/" . $videoId;
    $videoFrame = $slide->getShapes()->addVideoFrame(10, 10, 427, 240, $videoUrl);
    $videoFrame->setPlayMode(VideoPlayModePreset::Auto);

    $thumbnailUrl = "https://img.youtube.com/vi/" . $videoId . "/hqdefault.jpg";
    $thumbnailLocation = new Java("java.net.URL", $thumbnailUrl);
    $thumbnailStream = $thumbnailLocation->openStream();
    try {
        $thumbnail = $presentation->getImages()->addImage($thumbnailStream);
        $videoFrame->getPictureFormat()->getPicture()->setImage($thumbnail);
    } finally {
        $thumbnailStream->close();
    }

    $presentation->save("online_video.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Reproduzir um Vídeo em Modo de Tela Cheia**

Em uma apresentação de treinamento, você pode reproduzir uma demonstração de software em modo de tela cheia para que o público veja os detalhes. Chame [setFullScreenMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setFullScreenMode) com `true` para habilitar esse comportamento durante a reprodução.

Este exemplo abre uma apresentação, encontra o primeiro [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) no primeiro slide e habilita a reprodução em tela cheia. A apresentação de entrada deve conter pelo menos um slide com um quadro de vídeo existente no primeiro slide.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("training.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $videoFrame->setFullScreenMode(true);
            break;
        }
    }

    $presentation->save("full_screen_video.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

A reprodução em tela cheia controla como o vídeo é exibido. Independentemente, [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) controla se ele começa automaticamente ou ao clique, e [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) controla se ele repete. Para escolher o comportamento de início, defina o modo de reprodução para [VideoPlayModePreset::Auto or VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/php-java/aspose.slides/videoplaymodepreset/). O exemplo preserva as configurações existentes de início e loop.

## **Retroceder um Vídeo Após a Reprodução**

Em uma apresentação de treinamento, retornar um vídeo de demonstração ao início o deixa pronto para que o apresentador o reproduza novamente. Chame [setRewindVideo](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setRewindVideo) com `true` para devolver o vídeo ao início após a reprodução terminar.

Este exemplo abre uma apresentação, encontra o primeiro [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) no primeiro slide e habilita o retrocesso. Ele desabilita o loop para que a reprodução possa terminar e define a reprodução para iniciar ao clique. A apresentação de entrada deve conter pelo menos um slide com um quadro de vídeo existente no primeiro slide.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\VideoPlayModePreset;

$presentation = new Presentation("training.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $videoFrame->setRewindVideo(true);
            $videoFrame->setPlayLoopMode(false);
            $videoFrame->setPlayMode(VideoPlayModePreset::OnClick);
            break;
        }
    }

    $presentation->save("rewind_video.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Retroceder devolve o vídeo ao início sem iniciá-lo novamente. Em contraste, chamar [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) com `true` repete a reprodução automaticamente. Mantenha o loop desativado quando quiser que o vídeo termine e permaneça pronto para ser reproduzido novamente. [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) controla independentemente o início automático ou ao clique; este exemplo usa [VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/php-java/aspose.slides/videoplaymodepreset/) para que o apresentador controle quando a reprodução inicia. Defina o modo de reprodução após a configuração de loop, como mostrado no exemplo. Retroceder funciona independentemente de [setFullScreenMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setFullScreenMode).

## **Cortar um Quadro de Vídeo**

Use [VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setTrimFromStart) e [VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setTrimFromEnd) para pular parte do início ou do final de um vídeo durante a reprodução. Ambos os valores estão em milissegundos. O corte altera as configurações de reprodução sem modificar os dados de vídeo incorporados.

**Definir Configurações de Corte**

Este exemplo incorpora um vídeo local e pula os primeiros 2,5 segundos e o último segundo durante a reprodução. Use um vídeo com mais de 3,5 segundos para que reste um segmento reproduzível.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoFile = new Java("java.io.File", "video.mp4");
    $videoPath = $videoFile->toPath();
    $videoData = java("java.nio.file.Files")->readAllBytes($videoPath);
    $video = $presentation->getVideos()->addVideo($videoData);

    $videoFrame = $slide->getShapes()->addVideoFrame(50, 50, 640, 360, $video);
    $videoFrame->setTrimFromStart(2500);
    $videoFrame->setTrimFromEnd(1000);

    $presentation->save("video_with_trim.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**Ler Configurações de Corte**

Este exemplo exibe os valores de corte do primeiro quadro de vídeo no primeiro slide em milissegundos. A apresentação deve conter pelo menos um slide. Se esse slide não possuir quadro de vídeo, nada será exibido. O exemplo anterior produz valores de 2500 e 1000.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("video_with_trim.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            echo "Trim from start: " . java_values($videoFrame->getTrimFromStart()) . " ms\n";
            echo "Trim from end: " . java_values($videoFrame->getTrimFromEnd()) . " ms\n";
            break;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Gerenciar Legendas de Vídeo**

Aspose.Slides permite gerenciar legendas fechadas para quadros de vídeo em apresentações PowerPoint. As legendas são armazenadas no formato WebVTT e são expostas através do método [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#getCaptionTracks).

### **Adicionar Legendas a um Quadro de Vídeo**

Este exemplo incorpora um vídeo local e adiciona uma faixa de legenda WebVTT rotulada como English. Os timestamps da legenda devem coincidir com o vídeo. A apresentação salva inclui tanto o vídeo quanto suas legendas.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoFile = new Java("java.io.File", "video.mp4");
    $videoPath = $videoFile->toPath();
    $videoData = java("java.nio.file.Files")->readAllBytes($videoPath);
    $video = $presentation->getVideos()->addVideo($videoData);

    $videoFrame = $slide->getShapes()->addVideoFrame(0, 0, 100, 100, $video);
    $videoFrame->getCaptionTracks()->add("English", "track.vtt");

    $presentation->save("video_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

A classe [CaptionsCollection](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/) também fornece uma sobrecarga que permite adicionar legendas a partir de um fluxo.

### **Extrair Legendas de um Quadro de Vídeo**

Este exemplo salva todas as faixas de legenda dos quadros de vídeo no primeiro slide como arquivos WebVTT separados. Números sequenciais mantêm os arquivos de saída distintos. O console relata o número de faixas extraídas. A apresentação deve conter pelo menos um slide.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $trackCount = 0;
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $captionCount = java_values($videoFrame->getCaptionTracks()->getCount());
            for ($trackIndex = 0; $trackIndex < $captionCount; $trackIndex++) {
                $captionTrack = $videoFrame->getCaptionTracks()->get_Item($trackIndex);
                $trackCount++;
                $outputStream = new Java("java.io.FileOutputStream", "captions_" . $trackCount . ".vtt");
                try {
                    $outputStream->write($captionTrack->getBinaryData());
                } finally {
                    $outputStream->close();
                }
            }
        }
    }

    echo "Caption tracks extracted: " . $trackCount . "\n";
} finally {
    $presentation->dispose();
}
```

Cada objeto [Captions](https://reference.aspose.com/slides/php-java/aspose.slides/captions/) expõe o identificador da legenda, o rótulo, os dados binários e o texto da legenda como uma string UTF-8.

### **Remover Legendas de um Quadro de Vídeo**

Este exemplo remove todas as legendas do quadro de vídeo na primeira posição de forma no primeiro slide e salva o resultado. Presume que o slide e a forma existam e que a forma seja um quadro de vídeo.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoFrame = $slide->getShapes()->get_Item(0);
    $videoFrame->getCaptionTracks()->clear();

    $presentation->save("video_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Se precisar remover apenas uma faixa de legenda, use os métodos [remove](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#remove) ou [removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#removeAt) em vez de [clear](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#clear).

### **Pesquisar Legendas de Vídeo**

[Captions::getDataAsString](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getDataAsString) retorna a faixa WebVTT completa, incluindo seu cabeçalho, linhas de cronometragem e texto da legenda. Você pode pesquisar as cues na memória para encontrar uma frase falada e seu timestamp. Por exemplo, uma faixa em inglês no slide 2 pode conter o seguinte texto.

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

O exemplo abre `captioned_media.pptx` e usa [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#getCaptionTracks) para ler as faixas de cada quadro de vídeo de nível superior em todos os slides. Em uma cue de texto simples, a linha de tempo contém `-->`, e uma linha em branco termina a cue. Quando a legenda contém “café” em qualquer capitalização, o exemplo exibe o número do slide, o rótulo da faixa, a linha de tempo original e a legenda completa.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("captioned_media.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
                continue;
            }
            $trackCount = java_values($shape->getCaptionTracks()->getCount());
            for ($index = 0; $index < $trackCount; $index++) {
                $track = $shape->getCaptionTracks()->get_Item($index);
                $lines = preg_split('/\r\n|\n|\r/', java_values($track->getDataAsString()));
                $lineCount = count($lines);
                for ($i = 0; $i < $lineCount; $i++) {
                    $timing = $lines[$i];
                    if (strpos($timing, "-->") === false) {
                        continue;
                    }
                    $captionLines = [];
                    while (++$i < $lineCount && $lines[$i] !== "") {
                        $captionLines[] = $lines[$i];
                    }
                    $caption = implode("\n", $captionLines);
                    if (preg_match('/café/iu', $caption)) {
                        printf("Slide %d | %s | %s\n", java_values($slide->getSlideNumber()), java_values($track->getLabel()), $timing);
                        echo $caption, "\n";
                    }
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Buscar por “café” produz uma correspondência para a faixa de exemplo. A busca exclui o cabeçalho da faixa e preserva a configuração de cronometragem na saída.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Extrair Vídeo de um Slide**

Além de adicionar vídeos aos slides, Aspose.Slides permite extrair vídeos incorporados em apresentações.

Este exemplo extrai vídeos incorporados de cada slide em arquivos binários separados e numerados. Vídeos vinculados são ignorados porque não possuem dados incorporados. O console imprime o tipo MIME de cada vídeo e a contagem total. A saída usa a extensão genérica `.bin`; altere-a para corresponder ao tipo de mídia relatado quando necessário.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation_with_videos.pptx");
try {
    $videoCount = 0;
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
                $videoFrame = $shape;
                $video = $videoFrame->getEmbeddedVideo();
                if (java_is_null($video)) {
                    echo "Skipped a linked video: no embedded data is available.\n";
                    continue;
                }

                $videoCount++;
                $outputStream = new Java("java.io.FileOutputStream", "extracted_video_" . $videoCount . ".bin");
                try {
                    $outputStream->write($video->getBinaryData());
                } finally {
                    $outputStream->close();
                }
                echo "Video " . $videoCount . ": " . java_values($video->getContentType()) . "\n";
            }
        }
    }

    echo "Embedded videos extracted: " . $videoCount . "\n";
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Quais parâmetros de reprodução de vídeo podem ser alterados para um quadro de vídeo?**

Você pode controlar o [playback mode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) (auto ou ao clique) e o [looping](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode). Estas opções estão disponíveis através dos métodos do objeto [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/).

**Adicionar um vídeo afeta o tamanho do arquivo PPTX?**

Sim. Quando você incorpora um vídeo local, os dados binários são incluídos no documento, portanto o tamanho da apresentação cresce proporcionalmente ao tamanho do arquivo. Quando você vincula a um vídeo online e adiciona uma miniatura, a apresentação armazena o link e a imagem de pré‑visualização em vez dos dados do vídeo, de modo que o aumento de tamanho costuma ser menor.

**Posso substituir o vídeo em um quadro de vídeo existente sem alterar sua posição e tamanho?**

Sim. Você pode trocar o [video content](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setEmbeddedVideo) dentro do quadro preservando a geometria da forma; isso é um cenário comum para atualizar mídia em um layout existente.

**É possível determinar o tipo de conteúdo (MIME) de um vídeo incorporado?**

Sim. Um vídeo incorporado possui um [content type](https://reference.aspose.com/slides/php-java/aspose.slides/video/#getContentType) que pode ser lido e usado, por exemplo ao salvá‑lo em disco.