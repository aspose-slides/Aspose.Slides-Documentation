---
title: Vídeo
type: docs
weight: 80
url: /pt/php-java/examples/elements/video/
keywords:
- vídeo
- quadro de vídeo
- adicionar vídeo
- acessar vídeo
- remover vídeo
- reprodução de vídeo
- exemplos de código
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Trabalhe com vídeo em PHP usando Aspose.Slides: insira, substitua, corte, defina quadros de pôster e opções de reprodução, e exporte apresentações para PPT, PPTX e ODP."
---
Mostra como incorporar quadros de vídeo e definir opções de reprodução usando **Aspose.Slides for PHP via Java**.

## **Adicionar um Quadro de Vídeo**

Insira um quadro de vídeo em um slide.

```php
function addVideo() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Adicionar um quadro de vídeo.
        $videoFrame = $slide->getShapes()->addVideoFrame(50, 50, 320, 240, "video.mp4");

        $presentation->save("video.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Acessar um Quadro de Vídeo**

Recupere o primeiro quadro de vídeo adicionado a um slide.

```php
function accessVideo() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Acessar o primeiro quadro de vídeo no slide.
        $firstVideoFrame = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
                $firstVideoFrame = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Remover um Quadro de Vídeo**

Exclua um quadro de vídeo do slide.

```php
function removeVideo() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Assumindo que a primeira forma no slide é o quadro de vídeo.
        $videoFrame = $slide->getShapes()->get_Item(0);

        // Remover o quadro de vídeo.
        $slide->getShapes()->remove($videoFrame);

        $presentation->save("video_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Definir Reprodução de Vídeo**

Configure o vídeo para reproduzir automaticamente quando o slide for exibido.

```php
function setVideoPlayback() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Assumindo que a primeira forma no slide é o quadro de vídeo.
        $videoFrame = $slide->getShapes()->get_Item(0);

        // Configurar o vídeo para reproduzir automaticamente.
        $videoFrame->setPlayMode(VideoPlayModePreset::Auto);

        $presentation->save("video_playback.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```