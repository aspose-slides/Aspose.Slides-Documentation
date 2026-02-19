---
title: Vidéo
type: docs
weight: 80
url: /fr/androidjava/examples/elements/video/
keywords:
- exemple de code
- vidéo
- PowerPoint
- OpenDocument
- présentation
- Android
- Java
- Aspose.Slides
description: "Ajoutez et contrôlez des vidéos avec Aspose.Slides pour Android: insérez, lisez, coupez, définissez les images d'affiche, et exportez avec des exemples Java pour les présentations PPT, PPTX et ODP."
---
Cet article montre comment intégrer des cadres vidéo et définir les options de lecture en utilisant **Aspose.Slides for Android via Java**.

## **Ajouter un cadre vidéo**

Insérez un cadre vidéo vide sur une diapositive.

```java
static void addVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Ajoutez une vidéo.
        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");
    } finally {
        presentation.dispose();
    }
}
```

## **Accéder à un cadre vidéo**

Récupérez le premier cadre vidéo ajouté à une diapositive.

```java
static void accessVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // Accédez au premier cadre vidéo sur la diapositive.
        IVideoFrame firstVideo = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IVideoFrame) {
                firstVideo = (IVideoFrame) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Supprimer un cadre vidéo**

Supprimez un cadre vidéo de la diapositive.

```java
static void removeVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // Supprimez le cadre vidéo.
        slide.getShapes().remove(videoFrame);
    } finally {
        presentation.dispose();
    }
}
```

## **Définir la lecture vidéo**

Configurez la vidéo pour qu'elle se lise automatiquement lorsque la diapositive est affichée.

```java
static void setVideoPlayback() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // Configurez la vidéo pour qu'elle se lise automatiquement.
        videoFrame.setPlayMode(VideoPlayModePreset.Auto);
    } finally {
        presentation.dispose();
    }
}
```