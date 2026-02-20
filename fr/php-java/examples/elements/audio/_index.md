---
title: Audio
type: docs
weight: 70
url: /fr/php-java/examples/elements/audio/
keywords:
- audio
- cadre audio
- ajouter audio
- accéder à l'audio
- supprimer l'audio
- lecture audio
- exemples de code
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Travailler avec l'audio en PHP à l'aide d'Aspose.Slides: ajouter, remplacer, extraire et couper les sons, régler le volume et la lecture pour les diapositives et les formes dans PowerPoint et OpenDocument."
---
Illustration de la façon d'intégrer des cadres audio et de contrôler la lecture avec **Aspose.Slides for PHP via Java**. Les exemples suivants montrent les opérations audio de base.

## **Ajouter un cadre audio**

Insérer un cadre audio.

```php
function addAudio() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Créer un cadre audio.
        $audioStream = new Java("java.io.FileInputStream", new Java("java.io.File", "audio.wav"));
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audioStream);

        $presentation->save("audio.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Accéder à un cadre audio**

Ce code récupère le premier cadre audio d'une diapositive.

```php
function accessAudio() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Accéder au premier cadre audio de la diapositive.
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

## **Supprimer un cadre audio**

Supprimer un cadre audio précédemment ajouté.

```php
function removeAudio() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // En supposant que la première forme sur la diapositive est un cadre audio.
        $audioFrame = $slide->getShapes()->get_Item(0);

        // Supprimer le cadre audio.
        $slide->getShapes()->remove($audioFrame);

        $presentation->save("audio_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Définir la lecture audio**

Configurer le cadre audio pour qu'il se lise automatiquement lorsque la diapositive apparaît.

```php
function setAudioPlayback() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // En supposant que la première forme sur la diapositive est un cadre audio.
        $audioFrame = $slide->getShapes()->get_Item(0);

        // Lecture automatique lorsque la diapositive apparaît.
        $audioFrame->setPlayMode(AudioPlayModePreset::Auto);

        $presentation->save("audio_playback.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```