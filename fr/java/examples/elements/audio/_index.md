---
title: Audio
type: docs
weight: 70
url: /fr/java/examples/elements/audio/
keywords:
- exemple de code
- audio
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Découvrez les exemples audio d'Aspose.Slides for Java : insertion, lecture, découpage et extraction du son dans les présentations PPT, PPTX et ODP avec du code Java clair."
---
Cet article montre comment intégrer des trames audio et contrôler la lecture avec **Aspose.Slides for Java**. Les exemples suivants illustrent les opérations audio de base.

## **Ajouter une trame audio**

Insérez une trame audio vide qui pourra ensuite contenir des données sonores intégrées.

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

## **Accéder à une trame audio**

Ce code récupère la première trame audio d’une diapositive.

```java
static void accessAudio() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // Accéder à la première trame audio sur la diapositive.
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

## **Supprimer une trame audio**

Supprimez une trame audio ajoutée précédemment.

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

Configurez la trame audio pour qu’elle se lance automatiquement lorsque la diapositive apparaît.

```java
static void setAudioPlayback() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);
        
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(
                50, 50, 100, 100, new ByteArrayInputStream(new byte[0]));

        // Lire automatiquement lorsque la diapositive apparaît.
        audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    } finally {
        presentation.dispose();
    }
}
```