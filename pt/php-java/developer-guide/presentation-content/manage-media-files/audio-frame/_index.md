---
title: Gerenciar quadros de áudio em apresentações usando PHP
linktitle: Quadro de Áudio
type: docs
weight: 10
url: /pt/php-java/audio-frame/
keywords:
- áudio
- quadro de áudio
- miniatura
- adicionar áudio
- propriedades de áudio
- opções de áudio
- extrair áudio
- PHP
- Aspose.Slides
description: "Incorpore áudio em slides, altere o ícone de áudio, configure a reprodução, gerencie legendas WebVTT e extraia sons de transição de slides com Aspose.Slides for PHP via Java."
---
## **Visão geral**

Um quadro de áudio permite reproduzir um som em um slide. Com Aspose.Slides for PHP via Java, você pode incorporar um clipe de áudio, escolher a imagem que o representa, ajustar a reprodução e anexar legendas. Também é possível recuperar um som atribuído a uma transição de slide.

## **Criar quadros de áudio**

Use [addAudioFrameEmbedded](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addaudioframeembedded/) para incorporar um clipe de áudio local no primeiro slide. As duas primeiras coordenadas posicionam o quadro no slide, e os dois valores seguintes definem sua largura e altura, todos em pontos. Este exemplo chama [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplaymode/) para iniciar o clipe automaticamente e chama [setVolume](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setvolume/) para selecionar a predefinição alta.

```php
use aspose\slides\AudioPlayModePreset;
use aspose\slides\AudioVolumeMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioStream = new Java("java.io.FileInputStream", "audio.wav");
    try {
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 150, 100, 100, $audioStream);
    } finally {
        $audioStream->close();
    }
    $audioFrame->setPlayMode(AudioPlayModePreset::Auto);
    $audioFrame->setVolume(AudioVolumeMode::Loud);

    $presentation->save("AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Alterar a miniatura do quadro de áudio**

Por padrão, um quadro de áudio exibe um ícone de alto-falante. Para exibir uma miniatura personalizada, adicione uma imagem à apresentação com [addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/addimage/) e defina-a na imagem do quadro com [setImage](https://reference.aspose.com/slides/php-java/aspose.slides/picture/setimage/). O exemplo usa um JPEG como miniatura para um clipe de áudio incorporado.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioStream = new Java("java.io.FileInputStream", "audio.wav");
    try {
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(150, 100, 50, 50, $audioStream);
    } finally {
        $audioStream->close();
    }

    $imageStream = new Java("java.io.FileInputStream", "eagle.jpeg");
    try {
        $thumbnail = $presentation->getImages()->addImage($imageStream);
    } finally {
        $imageStream->close();
    }
    $audioFrame->getPictureFormat()->getPicture()->setImage($thumbnail);

    $presentation->save("example_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Alterar opções de reprodução de áudio**

Os controles **Opções de Áudio** do PowerPoint determinam quando um clipe inicia, quão alto ele soa e como ele se comporta durante a apresentação de slides.

![Controles de Opções de Áudio do PowerPoint para um quadro de áudio](audio_frame_0.png)

| Controle do PowerPoint | Método Aspose.Slides for PHP via Java |
| --- | --- |
| Iniciar | [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplaymode/) |
| Predefinição de volume | [setVolume](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setvolume/) |
| Reproduzir em todos os slides | [setPlayAcrossSlides](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplayacrossslides/) |
| Loop até parar | [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplayloopmode/) |
| Ocultar durante a apresentação | [setHideAtShowing](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/sethideatshowing/) |
| Retroceder após reproduzir | [setRewindAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setrewindaudio/) |
| Fade In | [setFadeInDuration](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setFadeInDuration) |
| Fade Out | [setFadeOutDuration](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setFadeOutDuration) |
| Cortar tempo de início do áudio | [setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromStart) |
| Cortar tempo de fim do áudio | [setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd) |
| Controle deslizante de volume | [setVolumeValue](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setVolumeValue) |

O exemplo encontra o primeiro quadro de áudio no primeiro slide, chama [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplaymode/) para iniciar a reprodução ao clicar e seleciona a predefinição de volume baixo. O clipe continua em todos os slides com o loop desativado. O ícone permanece oculto durante a apresentação, e o clipe retrocede após a reprodução.

```php
use aspose\slides\AudioPlayModePreset;
use aspose\slides\AudioVolumeMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("AudioFrameEmbed_out.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioFrameType = new JavaClass("com.aspose.slides.AudioFrame");
    $audioFrame = null;
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($i = 0; $i < $shapeCount; $i++) {
        $shape = $shapes->get_Item($i);
        if (java_instanceof($shape, $audioFrameType)) {
            $audioFrame = $shape;
            break;
        }
    }

    if ($audioFrame !== null) {
        $audioFrame->setPlayAcrossSlides(true);
        $audioFrame->setPlayLoopMode(false);
        $audioFrame->setPlayMode(AudioPlayModePreset::OnClick);
        $audioFrame->setVolume(AudioVolumeMode::Low);
        $audioFrame->setHideAtShowing(true);
        $audioFrame->setRewindAudio(true);

        $presentation->save("AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
    } else {
        echo "The first slide has no audio frame.\n";
    }
} finally {
    $presentation->dispose();
}
```

Para um clipe com mais de 3,5 segundos, este exemplo ignora os primeiros 1,5 segundos e os últimos 2 segundos. [setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd) recebe a duração a ser omitida do final do clipe. Para obter o tempo final exibido no PowerPoint, subtraia esse deslocamento da duração total do clipe. O clipe ajustado fade in em 200 milissegundos e fade out em 500 milissegundos. Todos os quatro métodos aceitam valores em milissegundos.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioStream = new Java("java.io.FileInputStream", "audio.wav");
    try {
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audioStream);
    } finally {
        $audioStream->close();
    }
    $audioFrame->setTrimFromStart(1500);
    $audioFrame->setTrimFromEnd(2000);
    $audioFrame->setFadeInDuration(200);
    $audioFrame->setFadeOutDuration(500);

    $presentation->save("AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Para definir o volume de reprodução em uma porcentagem específica, use [setVolumeValue](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setVolumeValue). Este exemplo define o primeiro quadro de áudio no primeiro slide para 85%.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("AudioFrameEmbed_out.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioFrameType = new JavaClass("com.aspose.slides.AudioFrame");
    $audioFrame = null;
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($i = 0; $i < $shapeCount; $i++) {
        $shape = $shapes->get_Item($i);
        if (java_instanceof($shape, $audioFrameType)) {
            $audioFrame = $shape;
            break;
        }
    }

    if ($audioFrame !== null) {
        $audioFrame->setVolumeValue(85);
        $presentation->save("AudioFrameValue_out.pptx", SaveFormat::Pptx);
    } else {
        echo "The first slide has no audio frame.\n";
    }
} finally {
    $presentation->dispose();
}
```

## **Gerenciar legendas de áudio**

Cada quadro de áudio fornece acesso às suas faixas de legenda através de [getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#getCaptionTracks). Use a coleção para anexar legendas WebVTT ao clipe, exportar faixas existentes ou removê‑las.

### **Adicionar legendas de áudio**

O exemplo incorpora um clipe de áudio no primeiro slide e usa [add](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#add) para anexar uma faixa WebVTT local. O primeiro argumento fornece o rótulo da faixa, e o segundo identifica o arquivo contendo as legendas cronometradas.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioStream = new Java("java.io.FileInputStream", "audio.wav");
    try {
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(10, 10, 50, 50, $audioStream);
    } finally {
        $audioStream->close();
    }
    $audioFrame->getCaptionTracks()->add("English", "track.vtt");

    $presentation->save("audio_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Extrair legendas de áudio**

Este exemplo exporta cada faixa de legenda anexada a um quadro de áudio no primeiro slide. Ele grava os bytes retornados por [getBinaryData](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getBinaryData) em um arquivo WebVTT e usa o identificador retornado por [getCaptionId](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getCaptionId) como nome do arquivo, de forma que cada faixa tenha uma saída separada.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioFrameType = new JavaClass("com.aspose.slides.AudioFrame");
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($i = 0; $i < $shapeCount; $i++) {
        $shape = $shapes->get_Item($i);
        if (!java_instanceof($shape, $audioFrameType)) {
            continue;
        }
        $tracks = $shape->getCaptionTracks();
        $trackCount = java_values($tracks->getCount());
        for ($j = 0; $j < $trackCount; $j++) {
            $track = $tracks->get_Item($j);
            $fileName = $track->getCaptionId() . ".vtt";
            $audioCaptions = $track->getBinaryData();
            $output = new Java("java.io.FileOutputStream", $fileName);
            try {
                $output->write($audioCaptions);
            } finally {
                $output->close();
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

### **Remover legendas de áudio**

Use [remove](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#remove) ou [removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#removeAt) para excluir uma faixa individual. O exemplo usa [clear](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#clear) para remover todas as legendas do primeiro quadro de áudio no primeiro slide, preservando o clipe.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioFrameType = new JavaClass("com.aspose.slides.AudioFrame");
    $audioFrame = null;
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($i = 0; $i < $shapeCount; $i++) {
        $shape = $shapes->get_Item($i);
        if (java_instanceof($shape, $audioFrameType)) {
            $audioFrame = $shape;
            break;
        }
    }

    if ($audioFrame !== null) {
        $audioFrame->getCaptionTracks()->clear();
        $presentation->save("audio_without_captions.pptx", SaveFormat::Pptx);
    } else {
        echo "The first slide has no audio frame.\n";
    }
} finally {
    $presentation->dispose();
}
```

### **Encontrar uma linha nas legendas de áudio**

Para encontrar uma linha nas legendas de áudio do primeiro slide, procure o texto retornado por [getDataAsString](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getDataAsString) na memória. Em um cue WebVTT em texto simples, a linha de tempo contém `-->`, as linhas de legenda seguem‑a, e uma linha em branco finaliza o cue. Este exemplo imprime o rótulo da faixa e cada linha de legenda que contém “café”.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioFrameType = new JavaClass("com.aspose.slides.AudioFrame");
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($i = 0; $i < $shapeCount; $i++) {
        $shape = $shapes->get_Item($i);
        if (!java_instanceof($shape, $audioFrameType)) {
            continue;
        }
        $tracks = $shape->getCaptionTracks();
        $trackCount = java_values($tracks->getCount());
        for ($j = 0; $j < $trackCount; $j++) {
            $track = $tracks->get_Item($j);
            $inCue = false;
            $captions = (string) $track->getDataAsString();
            foreach (preg_split('/\R/u', $captions) as $line) {
                if ($line === "") {
                    $inCue = false;
                } elseif (strpos($line, "-->") !== false) {
                    $inCue = true;
                } elseif ($inCue && preg_match('/café/iu', $line)) {
                    echo $track->getLabel() . ": " . $line . "\n";
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Extrair áudio**

Uma transição de slide pode ter seu próprio som. Para recuperá‑lo, chame [getSound](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/getsound/) na transição de slide. O exemplo acessa os bytes retornados por [getBinaryData](https://reference.aspose.com/slides/php-java/aspose.slides/audio/getbinarydata/) e imprime o número de bytes. Se o primeiro slide não possui som de transição, ele imprime uma mensagem.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("AudioSlide.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $sound = $slide->getSlideShowTransition()->getSound();
    if (java_is_null($sound)) {
        echo "The first slide has no transition sound.\n";
    } else {
        $audioData = $sound->getBinaryData();
        $array = new JavaClass("java.lang.reflect.Array");
        echo "Transition sound: " . $array->getLength($audioData) . " bytes.\n";
    }
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Posso reutilizar o mesmo clipe de áudio em vários slides sem duplicá‑lo?**

Sim. Adicione o clipe uma vez à [coleção de áudio](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getaudios/) da apresentação e passe o mesmo objeto de áudio para [addAudioFrameEmbedded](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addaudioframeembedded/) em cada slide.

**Posso substituir o som em um quadro de áudio existente?**

Sim. Para um som vinculado, use [setLinkPathLong](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setlinkpathlong/) para apontar ao arquivo de substituição. Para um som incorporado, selecione outro clipe da coleção de áudio da apresentação com [setEmbeddedAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setembeddedaudio/). Ambas as abordagens preservam o quadro existente.

**A edição (trim) altera os dados de áudio armazenados na apresentação?**

Não. [setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromStart) e [setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd) definem os limites de reprodução. Você ainda pode recuperar o clipe completo de [getEmbeddedAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/getembeddedaudio/).