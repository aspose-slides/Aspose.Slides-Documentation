---
title: Vidéo
type: docs
weight: 80
url: /fr/java/examples/elements/video/
keywords:
- exemple de code
- vidéo
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Ajoutez et contrôlez des vidéos avec Aspose.Slides for Java : insérez, lisez, coupez, définissez des images d’affiche, et exportez avec des exemples Java pour les présentations PPT, PPTX et ODP."
---
Cet article montre comment incorporer des cadres vidéo et définir les options de lecture en utilisant **Aspose.Slides for Java**.

## **Add a Video Frame**
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

## **Access a Video Frame**
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

## **Remove a Video Frame**
Supprimez un cadre vidéo de la diapositive.

```java
static void removeVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // Supprime le cadre vidéo.
        slide.getShapes().remove(videoFrame);
    } finally {
        presentation.dispose();
    }
}
```

## **Set Video Playback**
Configurez la vidéo pour qu’elle se lise automatiquement lorsque la diapositive est affichée.

```java
static void setVideoPlayback() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // Configure la vidéo pour qu'elle se lise automatiquement.
        videoFrame.setPlayMode(VideoPlayModePreset.Auto);
    } finally {
        presentation.dispose();
    }
}
```