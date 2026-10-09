---
title: Gérer les cadres vidéo dans les présentations avec Node.js
linktitle: Cadre vidéo
type: docs
weight: 10
url: /fr/nodejs-java/video-frame/
keywords:
- ajouter vidéo
- créer vidéo
- intégrer vidéo
- extraire vidéo
- récupérer vidéo
- cadre vidéo
- source Web
- PowerPoint
- OpenDocument
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Apprenez à ajouter et extraire programmatiquement des cadres vidéo dans les diapositives PowerPoint et OpenDocument en utilisant Aspose.Slides pour Node.js via Java. Guide pratique rapide."
---
## **Introduction**

Les vidéos peuvent aider à expliquer des idées et à captiver un public. Aspose.Slides for Node.js via Java vous permet d’ajouter des cadres vidéo aux diapositives, de régler les paramètres de lecture, de gérer les sous-titres et d’extraire les données vidéo intégrées.

PowerPoint prend en charge les vidéos locales et les liens vers des vidéos en ligne, comme les vidéos YouTube.

Pour représenter les données vidéo et les cadres vidéo, Aspose.Slides fournit les classes [Video](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/) et [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/), ainsi que d’autres types pertinents.

## **Créer un cadre vidéo intégré**

Si le fichier vidéo que vous souhaitez ajouter à votre diapositive est stocké localement, vous pouvez créer un cadre vidéo pour intégrer la vidéo dans votre présentation.

Cet exemple intègre une vidéo locale sur la première diapositive d’une présentation existante et enregistre le résultat. Les coordonnées et les dimensions du cadre sont exprimées en points. Le flux reste ouvert jusqu’à la fin de l’enregistrement parce que [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadingstreambehavior/) le maintient verrouillé tant que la présentation l’utilise.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const videoStream = java.newInstanceSync("java.io.FileInputStream", "video.mp4");
    try {
        const slide = presentation.getSlides().get_Item(0);

        const video = presentation.getVideos().addVideo(videoStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        slide.getShapes().addVideoFrame(10, 10, 150, 250, video);

        presentation.save("embedded_video.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        videoStream.close();
    }
} finally {
    presentation.dispose();
}
```

Vous pouvez également fournir le chemin d’une vidéo locale directement à [addVideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addvideoframe/). Cet exemple intègre la vidéo sur la première diapositive d’une nouvelle présentation. La vidéo doit rester accessible jusqu’à ce que la présentation soit enregistrée.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addVideoFrame(50, 150, 300, 150, "video.avi");

    presentation.save("video_from_path.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Créer un cadre vidéo avec une vidéo provenant d’une source Web**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) prend en charge les vidéos en ligne dans les présentations. Vous pouvez créer un cadre vidéo qui pointe vers une vidéo en ligne, comme une vidéo YouTube.

Cet exemple ajoute un lien vidéo YouTube et une miniature à la première diapositive. Remplacez l’identifiant vidéo pour utiliser une autre vidéo. La méthode [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) demande une lecture automatique. Le téléchargement de la miniature et la lecture de la vidéo nécessitent un accès Internet. Le visualiseur de présentation doit également prendre en charge la lecture de vidéos en ligne.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoId = "aqz-KE-bpKQ";
    const videoUrl = "https://www.youtube.com/embed/" + videoId;
    const videoFrame = slide.getShapes().addVideoFrame(10, 10, 427, 240, videoUrl);
    videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.Auto);

    const thumbnailUrl = "https://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
    const thumbnailLocation = java.newInstanceSync("java.net.URL", thumbnailUrl);
    const thumbnailStream = thumbnailLocation.openStream();
    try {
        const thumbnail = presentation.getImages().addImage(thumbnailStream);
        videoFrame.getPictureFormat().getPicture().setImage(thumbnail);
    } finally {
        thumbnailStream.close();
    }

    presentation.save("online_video.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Lire une vidéo en mode plein écran**

Dans une présentation de formation, vous pouvez lire une démonstration logicielle en mode plein écran afin que le public puisse voir les détails. Appelez [setFullScreenMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setfullscreenmode/) avec `true` pour activer ce comportement pendant la lecture.

Cet exemple ouvre une présentation, trouve le premier [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) de la première diapositive et active la lecture en plein écran. La présentation d’entrée doit contenir au moins une diapositive avec un cadre vidéo existant sur la première diapositive.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("training.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            videoFrame.setFullScreenMode(true);
            break;
        }
    }

    presentation.save("full_screen_video.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La lecture en plein écran contrôle la façon dont la vidéo est affichée. De façon indépendante, [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) contrôle si elle démarre automatiquement ou au clic, et [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) contrôle si elle se répète. Pour choisir le comportement de démarrage, définissez le mode de lecture sur [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoplaymodepreset/). L’exemple conserve les paramètres de démarrage et de boucle existants.

## **Rembobiner une vidéo après la lecture**

Dans une présentation de formation, ramener une vidéo de démonstration au début la rend prête pour que le présentateur la relise. Appelez [setRewindVideo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setrewindvideo/) avec `true` pour ramener la vidéo au début après la fin de la lecture.

Cet exemple ouvre une présentation, trouve le premier [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) de la première diapositive et active le rembobinage. Il désactive la boucle afin que la lecture puisse se terminer et définit la lecture pour démarrer au clic. La présentation d’entrée doit contenir au moins une diapositive avec un cadre vidéo existant sur la première diapositive.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("training.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            videoFrame.setRewindVideo(true);
            videoFrame.setPlayLoopMode(false);
            videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.OnClick);
            break;
        }
    }

    presentation.save("rewind_video.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le rembobinage ramène la vidéo au début sans la relancer. En revanche, appeler [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) avec `true` répète la lecture automatiquement. Maintenez la boucle désactivée lorsque vous voulez que la vidéo se termine et reste prête à être relue. [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) contrôle indépendamment le démarrage automatique ou au clic ; cet exemple utilise [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoplaymodepreset/) afin que le présentateur contrôle le moment où la lecture commence. Définissez le mode de lecture après le réglage de la boucle, comme le montre l’exemple. Le rembobinage fonctionne indépendamment de [setFullScreenMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setfullscreenmode/).

## **Rogner un cadre vidéo**

Utilisez [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/settrimfromstart/) et [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/settrimfromend/) pour ignorer une partie du début ou de la fin d’une vidéo pendant la lecture. Les deux valeurs sont exprimées en millisecondes. Le rognage modifie les paramètres de lecture sans modifier les données vidéo intégrées.

**Définir les paramètres de rognage**

Cet exemple intègre une vidéo locale et ignore les 2,5 secondes initiales ainsi que la dernière seconde pendant la lecture. Utilisez une vidéo d’une durée supérieure à 3,5 secondes afin qu’un segment lisible reste.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoBuffer = fs.readFileSync("video.mp4");
    const videoData = java.newArray("byte", Array.from(videoBuffer));
    const video = presentation.getVideos().addVideo(videoData);

    const videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);
    videoFrame.setTrimFromStart(2500);
    videoFrame.setTrimFromEnd(1000);

    presentation.save("video_with_trim.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Lire les paramètres de rognage**

Cet exemple affiche les valeurs de rognage du premier cadre vidéo de la première diapositive en millisecondes. La présentation doit contenir au moins une diapositive. Si cette diapositive ne comporte aucun cadre vidéo, rien n’est affiché. L’exemple précédent produit les valeurs 2500 et 1000.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("video_with_trim.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            console.log("Trim from start: " + videoFrame.getTrimFromStart() + " ms");
            console.log("Trim from end: " + videoFrame.getTrimFromEnd() + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **Gérer les sous-titres vidéo**

Aspose.Slides vous permet de gérer les sous-titres fermés pour les cadres vidéo dans les présentations PowerPoint. Les sous-titres sont stockés au format WebVTT et sont accessibles via la méthode [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/#getCaptionTracks).

**Ajouter des sous-titres à un cadre vidéo**

Cet exemple intègre une vidéo locale et ajoute une piste de sous-titres WebVTT intitulée English. Les horodatages des sous-titres doivent correspondre à la vidéo. La présentation enregistrée inclut à la fois la vidéo et ses sous-titres.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoBuffer = fs.readFileSync("video.mp4");
    const videoData = java.newArray("byte", Array.from(videoBuffer));
    const video = presentation.getVideos().addVideo(videoData);

    const videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La classe [CaptionsCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/) fournit également la méthode [addFromStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#addFromStream) pour ajouter des sous-titres depuis un flux.

**Extraire les sous-titres d’un cadre vidéo**

Cet exemple enregistre toutes les pistes de sous-titres des cadres vidéo de la première diapositive en fichiers WebVTT distincts. Des numéros séquentiels permettent de distinguer les fichiers de sortie. La console indique le nombre de pistes extraites. La présentation doit contenir au moins une diapositive.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    let trackCount = 0;
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            for (let trackIndex = 0; trackIndex < videoFrame.getCaptionTracks().getCount(); trackIndex++) {
                const captionTrack = videoFrame.getCaptionTracks().get_Item(trackIndex);
                trackCount++;
                const outputPath = "captions_" + trackCount + ".vtt";
                const outputData = Buffer.from(captionTrack.getBinaryData());
                fs.writeFileSync(outputPath, outputData);
            }
        }
    }

    console.log("Caption tracks extracted: " + trackCount);
} finally {
    presentation.dispose();
}
```

Chaque objet [Captions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/) expose l’identifiant du sous-titre, le label, les données binaires et le texte du sous-titre sous forme de chaîne UTF-8.

**Supprimer les sous-titres d’un cadre vidéo**

Cet exemple supprime tous les sous-titres du cadre vidéo situé à la première position de forme sur la première diapositive et enregistre le résultat. Il suppose que la diapositive et la forme existent et que la forme est un cadre vidéo.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoFrame = slide.getShapes().get_Item(0);
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Si vous devez supprimer une seule piste de sous-titres, utilisez les méthodes [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#remove) ou [removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#removeAt) au lieu de [clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#clear).

## **Extraire la vidéo d’une diapositive**

En plus d’ajouter des vidéos aux diapositives, Aspose.Slides vous permet d’extraire les vidéos intégrées dans les présentations.

Cet exemple extrait les vidéos intégrées de chaque diapositive dans des fichiers binaires séparés et numérotés. Les vidéos liées sont ignorées car elles ne contiennent pas de données intégrées. La console affiche le type MIME de chaque vidéo ainsi que le nombre total. La sortie utilise l’extension générique `.bin` ; modifiez‑la pour correspondre au type de média signalé si besoin.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("presentation_with_videos.pptx");
try {
    let videoCount = 0;
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
                const videoFrame = shape;
                const video = videoFrame.getEmbeddedVideo();
                if (video == null) {
                    console.log("Skipped a linked video: no embedded data is available.");
                    continue;
                }

                videoCount++;
                const outputPath = "extracted_video_" + videoCount + ".bin";
                const outputData = Buffer.from(video.getBinaryData());
                fs.writeFileSync(outputPath, outputData);
                console.log("Video " + videoCount + ": " + video.getContentType());
            }
        }
    }

    console.log("Embedded videos extracted: " + videoCount);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Quels paramètres de lecture vidéo peuvent être modifiés pour un cadre vidéo ?**

Vous pouvez contrôler le [mode de lecture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) (automatique ou au clic) et le [bouclage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/). Ces options sont disponibles via les méthodes de l’objet [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/).

**L’ajout d’une vidéo affecte-t-il la taille du fichier PPTX ?**

Oui. Lorsque vous intégrez une vidéo locale, les données binaires sont incluses dans le document, ce qui fait croître la taille de la présentation proportionnellement à la taille du fichier. Lorsque vous créez un lien vers une vidéo en ligne et ajoutez une miniature, la présentation stocke le lien et l’image de prévisualisation plutôt que les données vidéo, ce qui entraîne généralement une augmentation de taille moindre.

**Puis‑je remplacer la vidéo d’un cadre vidéo existant sans modifier sa position et sa taille ?**

Oui. Vous pouvez échanger le [contenu vidéo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setembeddedvideo/) à l’intérieur du cadre tout en préservant la géométrie de la forme ; c’est un scénario courant pour mettre à jour les médias dans une mise en page existante.

**Peut‑on déterminer le type de contenu (MIME) d’une vidéo intégrée ?**

Oui. Une vidéo intégrée possède un [type de contenu](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/getcontenttype/) que vous pouvez lire et utiliser, par exemple lors de son enregistrement sur disque.