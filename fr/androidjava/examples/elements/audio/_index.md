---
title: Audio
type: docs
weight: 70
url: /fr/androidjava/examples/elements/audio/
keywords:
- exemple de code
- audio
- PowerPoint
- OpenDocument
- présentation
- Android
- Java
- Aspose.Slides
description: "Découvrez les exemples audio d’Aspose.Slides pour Android : insertion, lecture, découpage et extraction du son dans les présentations PPT, PPTX et ODP avec du code Java clair."
---
Cet article montre comment intégrer des trames audio et contrôler la lecture avec **Aspose.Slides for Android via Java**. Les exemples suivants illustrent les opérations audio de base.

## **Ajouter un cadre audio**

Insérez un cadre audio vide qui pourra ensuite contenir des données sonores intégrées.

```java
static void addAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Créer une trame audio vide (le son sera intégré plus tard).
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));
    } finally {
        presentation.dispose();
    }
}
```

## **Accéder à un cadre audio**

Ce code récupère le premier cadre audio d’une diapositive.

```java
static void accessAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // Accéder à la première trame audio de la diapositive.
        IAudioFrame firstAudio = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAudioFrame) {
                firstAudio = (IAudioFrame) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Supprimer un cadre audio**

Supprimez un cadre audio ajouté précédemment.

```java
static void removeAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // Supprimer la trame audio.
        slide.getShapes().remove(audioFrame);
    } finally {
        presentation.dispose();
    }
}
```

## **Définir la lecture audio**

Configurez le cadre audio pour qu’il se lise automatiquement lorsque la diapositive apparaît.

```java
static void setAudioPlayback() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);
        
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // Lecture automatique lorsque la diapositive apparaît.
        audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    } finally {
        presentation.dispose();
    }
}
```