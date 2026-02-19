---
title: Vidéo
type: docs
weight: 80
url: /fr/nodejs-java/examples/elements/video/
keywords:
- exemple de code
- vidéo
- PowerPoint
- OpenDocument
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Ajoutez et contrôlez les vidéos avec Aspose.Slides pour Node.js : insérez, lisez, coupez, définissez des images d'affiche, et exportez avec des exemples pour les présentations PPT, PPTX et ODP."
---
Cet article montre comment intégrer des cadres vidéo et définir les options de lecture en utilisant **Aspose.Slides for Node.js via Java**.

## **Ajouter un cadre vidéo**

Ajoutez un cadre vidéo à une diapositive.

```js
function addVideo() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Ajoutez une vidéo.
        let videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        presentation.save("video.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Accéder à un cadre vidéo**

Récupérez le premier cadre vidéo ajouté à une diapositive.

```js
function accessVideo() {
    let presentation = new aspose.slides.Presentation("video.pptx"); 
    try { 
        let slide = presentation.getSlides().get_Item(0);

        // Accédez au premier cadre vidéo sur la diapositive.
        let firstVideo = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IVideoFrame")) {
                firstVideo = shape;
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

```js
function removeVideo() {
    let presentation = new aspose.slides.Presentation("video.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Suppose que la première forme est le cadre vidéo.
        let videoFrame = slide.getShapes().get_Item(0);

        // Supprimez le cadre vidéo.
        slide.getShapes().remove(videoFrame);

        presentation.save("video_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Définir la lecture vidéo**

Configurez la vidéo pour qu'elle se lise automatiquement lorsque la diapositive est affichée.

```js
function setVideoPlayback() {
    let presentation = new aspose.slides.Presentation("video.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Supposons que la première forme est le cadre vidéo.
        let videoFrame = slide.getShapes().get_Item(0);

        // Configurez la vidéo pour qu'elle se lise automatiquement.
        videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.Auto);

        presentation.save("video_autoplay.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```