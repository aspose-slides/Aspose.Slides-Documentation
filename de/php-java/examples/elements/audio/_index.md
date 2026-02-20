---
title: Audio
type: docs
weight: 70
url: /de/php-java/examples/elements/audio/
keywords:
- Audio
- Audio-Frame
- Audio hinzufügen
- Audio abrufen
- Audio entfernen
- Audio-Wiedergabe
- Code-Beispiele
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Arbeiten Sie mit Audio in PHP unter Verwendung von Aspose.Slides: Hinzufügen, Ersetzen, Extrahieren und Kürzen von Sounds, Lautstärke und Wiedergabe für Folien und Formen in PowerPoint und OpenDocument festlegen."
---
Veranschaulicht, wie Audio-Frames eingebettet und die Wiedergabe mit **Aspose.Slides for PHP via Java** gesteuert werden können. Die folgenden Beispiele zeigen grundlegende Audio-Operationen.

## **Audio-Frame hinzufügen**

Fügen Sie einen Audio-Frame ein.

```php
function addAudio() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Erstelle einen Audio-Frame.
        $audioStream = new Java("java.io.FileInputStream", new Java("java.io.File", "audio.wav"));
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audioStream);

        $presentation->save("audio.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Zugriff auf einen Audio-Frame**

Dieser Code ruft den ersten Audio-Frame einer Folie ab.

```php
function accessAudio() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Zugriff auf den ersten Audio-Frame auf der Folie.
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

## **Audio-Frame entfernen**

Löschen Sie einen zuvor hinzugefügten Audio-Frame.

```php
function removeAudio() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Angenommen, die erste Form auf der Folie ist ein Audio-Frame.
        $audioFrame = $slide->getShapes()->get_Item(0);

        // Entferne den Audio-Frame.
        $slide->getShapes()->remove($audioFrame);

        $presentation->save("audio_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Audio-Wiedergabe festlegen**

Konfigurieren Sie den Audio-Frame so, dass er automatisch abgespielt wird, wenn die Folie angezeigt wird.

```php
function setAudioPlayback() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Angenommen, die erste Form auf der Folie ist ein Audio-Frame.
        $audioFrame = $slide->getShapes()->get_Item(0);

        // Automatisch abspielen, wenn die Folie erscheint.
        $audioFrame->setPlayMode(AudioPlayModePreset::Auto);

        $presentation->save("audio_playback.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```