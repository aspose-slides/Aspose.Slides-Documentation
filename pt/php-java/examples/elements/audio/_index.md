---
title: Áudio
type: docs
weight: 70
url: /pt/php-java/examples/elements/audio/
keywords:
- áudio
- quadro de áudio
- adicionar áudio
- acessar áudio
- remover áudio
- reprodução de áudio
- exemplos de código
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Trabalhe com áudio em PHP usando Aspose.Slides: adicione, substitua, extraia e corte sons, defina volume e reprodução para slides e formas no PowerPoint e OpenDocument."
---
Ilustra como incorporar quadros de áudio e controlar a reprodução com **Aspose.Slides for PHP via Java**. Os exemplos a seguir mostram operações básicas de áudio.

## **Adicionar um Quadro de Áudio**

Inserir um quadro de áudio.

```php
function addAudio() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Criar um quadro de áudio.
        $audioStream = new Java("java.io.FileInputStream", new Java("java.io.File", "audio.wav"));
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audioStream);

        $presentation->save("audio.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Acessar um Quadro de Áudio**

Este código recupera o primeiro quadro de áudio em um slide.

```php
function accessAudio() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Acessar o primeiro quadro de áudio no slide.
        $firstAudioFrame = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AudioFrame"))) {
                $firstAudioFrame = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Remover um Quadro de Áudio**

Excluir um quadro de áudio previamente adicionado.

```php
function removeAudio() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Assumindo que a primeira forma no slide é um quadro de áudio.
        $audioFrame = $slide->getShapes()->get_Item(0);

        // Remover o quadro de áudio.
        $slide->getShapes()->remove($audioFrame);

        $presentation->save("audio_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Definir Reprodução de Áudio**

Configure o quadro de áudio para reproduzir automaticamente quando o slide aparecer.

```php
function setAudioPlayback() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Assumindo que a primeira forma no slide é um quadro de áudio.
        $audioFrame = $slide->getShapes()->get_Item(0);

        // Reproduzir automaticamente quando o slide aparecer.
        $audioFrame->setPlayMode(AudioPlayModePreset::Auto);

        $presentation->save("audio_playback.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```