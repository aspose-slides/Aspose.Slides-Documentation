---
title: Gérer les images vidéo dans les présentations à l'aide de Node.js
linktitle: Image vidéo
type: docs
weight: 10
url: /fr/nodejs-java/video-frame/
keywords:
- ajouter vidéo
- créer vidéo
- intégrer vidéo
- extraire vidéo
- récupérer vidéo
- image vidéo
- source web
- PowerPoint
- OpenDocument
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Apprenez à ajouter et extraire programmatiquement des images vidéo dans les diapositives PowerPoint et OpenDocument en utilisant Aspose.Slides pour Node.js via Java. Guide pratique rapide."
---
## **Introduction**

Les vidéos peuvent aider à expliquer des idées et à captiver un public. Aspose.Slides for Node.js via Java vous permet d'ajouter des images video aux diapositives, d'ajuster les paramètres de lecture, de gérer les sous-titres et d'extraire les données video intégrées.

PowerPoint prend en charge les vidéos locales et les liens vers des vidéos en ligne, telles que les vidéos YouTube.

Pour représenter les données vidéo et les images vidéo, Aspose.Slides fournit la classe [Video](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/) la classe [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) et d'autres types pertinents.

## **Créer une image vidéo intégrée**

Si le fichier vidéo que vous souhaitez ajouter à votre diapositive est stocké localement, vous pouvez créer une image vidéo pour intégrer la vidéo dans votre présentation.

Cet exemple intègre une vidéo locale sur la première diapositive d'une présentation existante et enregistre le résultat. Les coordonnées et dimensions de l'image sont exprimées en points. Le flux reste ouvert jusqu'à la fin de l'enregistrement car [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadingstreambehavior/) le maintient verrouillé pendant que la présentation l'utilise.

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

Vous pouvez également fournir un chemin de vidéo locale directement à [addVideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addvideoframe/). Cet exemple intègre la vidéo sur la première diapositive d'une nouvelle présentation. La vidéo doit rester accessible jusqu'à ce que la présentation soit enregistrée.

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

## **Créer une image vidéo avec une vidéo provenant d'une source Web**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) prend en charge les vidéos en ligne dans les présentations. Vous pouvez créer une image vidéo qui lie à une vidéo en ligne, comme une vidéo YouTube.

Cet exemple ajoute un lien vidéo YouTube et une miniature à la première diapositive. Remplacez l'identifiant de la vidéo pour en utiliser une autre. La méthode [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) demande une lecture automatique. Le téléchargement de la miniature et la lecture de la vidéo nécessitent un accès internet. Le visualiseur de présentation doit également prendre en charge la lecture de vidéos en ligne.

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

Cet exemple ouvre une présentation, trouve la première [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) sur la première diapositive et active la lecture en plein écran. La présentation d'entrée doit contenir au moins une diapositive avec une image vidéo existante sur la première diapositive.

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

La lecture en plein écran contrôle la façon dont la vidéo est affichée. De façon indépendante, [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) contrôle si elle démarre automatiquement ou au clic, et [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) contrôle si elle se répète. Pour choisir le comportement de démarrage, définissez le mode de lecture sur [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoplaymodepreset/). L'exemple préserve les paramètres de démarrage et de boucle existants.

## **Rembobiner une vidéo après la lecture**

Dans une présentation de formation, ramener une vidéo de démonstration au début la rend prête pour que le présentateur la relise. Appelez [setRewindVideo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setrewindvideo/) avec `true` pour ramener la vidéo au début après la fin de la lecture.

Cet exemple ouvre une présentation, trouve la première [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) sur la première diapositive et active le rembobinage. Il désactive la boucle afin que la lecture puisse se terminer et configure la lecture pour démarrer au clic. La présentation d'entrée doit contenir au moins une diapositive avec une image vidéo existante sur la première diapositive.

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

Le rembobinage ramène la vidéo au début sans la relancer. En revanche, appeler [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) avec `true` répète la lecture automatiquement. Gardez la boucle désactivée lorsque vous voulez que la vidéo se termine et reste prête à être rejouée. [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) contrôle indépendamment le démarrage automatique ou au clic ; cet exemple utilise [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoplaymodepreset/) afin que le présentateur contrôle le moment où la lecture démarre. Définissez le mode de lecture après le paramètre de boucle, comme indiqué dans l'exemple. Le rembobinage fonctionne indépendamment de [setFullScreenMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setfullscreenmode/).

## **Rogner une image vidéo**

Utilisez [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/settrimfromstart/) et [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/settrimfromend/) pour ignorer une partie du début ou de la fin d'une vidéo pendant la lecture. Les deux valeurs sont exprimées en millisecondes. Le rognage modifie les paramètres de lecture sans modifier les données video intégrées.

**Définir les paramètres de rognage**

Cet exemple intègre une vidéo locale et saute les 2,5 premières secondes ainsi que la dernière seconde pendant la lecture. Utilisez une vidéo de plus de 3,5 secondes afin qu'un segment lisible reste.

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

Cet exemple affiche les valeurs de rognage de la première image vidéo sur la première diapositive en millisecondes. La présentation doit contenir au moins une diapositive. Si cette diapositive n'a pas d'image vidéo, rien n'est affiché. L'exemple précédent produit les valeurs 2500 et 1000.

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

Aspose.Slides vous permet de gérer les sous-titres fermés pour les images vidéo dans les présentations PowerPoint. Les sous-titres sont stockés au format WebVTT et sont accessibles via la méthode [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/#getCaptionTracks).

### **Ajouter des sous-titres à une image vidéo**

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

### **Extraire les sous-titres d'une image vidéo**

Cet exemple enregistre toutes les pistes de sous-titres des images vidéo sur la première diapositive en fichiers WebVTT distincts. Des numéros séquentiels permettent de différencier les fichiers de sortie. La console indique le nombre de pistes extraites. La présentation doit contenir au moins une diapositive.

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

Chaque objet [Captions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/) expose l'identifiant du sous-titre, le libellé, les données binaires et le texte du sous-titre sous forme de chaîne UTF-8.

### **Supprimer les sous-titres d'une image vidéo**

Cet exemple supprime tous les sous-titres de l'image vidéo à la première position de forme sur la première diapositive et enregistre le résultat. Il suppose que la diapositive et la forme existent et que la forme est une image vidéo.

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

Si vous devez supprimer uniquement une piste de sous-titres, utilisez les méthodes [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#remove) ou [removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#removeAt) au lieu de [clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#clear).

### **Rechercher des sous-titres vidéo**

La méthode [Captions.getDataAsString](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/#getDataAsString) renvoie l'intégralité de la piste WebVTT, y compris l'en-tête, les lignes de timing et le texte du sous-titre. Vous pouvez rechercher le texte du sous-titre en mémoire pour trouver une phrase et son horodatage. Par exemple, une piste English sur la diapositive 2 peut contenir ce cue :

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

Cet exemple ouvre `captioned_media.pptx` et utilise [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/#getCaptionTracks) pour lire les pistes de chaque image vidéo de niveau supérieur sur chaque diapositive. Dans un cue en texte brut, la ligne de timing contient `-->`, et une ligne vide termine le cue. Pour chaque sous-titre contenant « café » quelle que soit la casse, l'exemple affiche le numéro de diapositive, le libellé de la piste, la ligne de timing originale et le sous-titre complet.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("captioned_media.pptx");
try {
    const slides = presentation.getSlides();
    for (let slideIndex = 0; slideIndex < slides.size(); slideIndex++) {
        const slide = slides.get_Item(slideIndex);
        const shapes = slide.getShapes();
        for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
            const shape = shapes.get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
                continue;
            }

            const tracks = shape.getCaptionTracks();
            for (let trackIndex = 0; trackIndex < tracks.getCount(); trackIndex++) {
                const track = tracks.get_Item(trackIndex);
                const lines = track.getDataAsString().split(/\r\n|\n|\r/);
                for (let i = 0; i < lines.length; i++) {
                    const timing = lines[i];
                    if (!timing.includes("-->")) {
                        continue;
                    }
                    const start = i + 1;
                    i = start;
                    while (i < lines.length && lines[i] !== "") {
                        i++;
                    }
                    const caption = lines.slice(start, i).join("\n");
                    if (caption.toLowerCase().includes("café")) {
                        console.log(`Slide ${slide.getSlideNumber()} | ${track.getLabel()} | ${timing}`);
                        console.log(caption);
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

La recherche de « café » trouve une correspondance dans la piste d'exemple. La recherche ignore l'en-tête de la piste et préserve le paramètre de timing ainsi que les sauts de ligne dans la sortie.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Extraire la vidéo d'une diapositive**

Outre l'ajout de vidéos aux diapositives, Aspose.Slides vous permet d'extraire les vidéos intégrées dans les présentations.

Cet exemple extrait les vidéos intégrées de chaque diapositive dans des fichiers binaires séparés et numérotés. Les vidéos liées sont ignorées car elles ne contiennent pas de données intégrées. La console affiche le type MIME de chaque vidéo et le nombre total. La sortie utilise l'extension générique `.bin` ; modifiez-la pour correspondre au type de média signalé si nécessaire.

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

**Quels paramètres de lecture vidéo peuvent être modifiés pour une image vidéo ?**

Vous pouvez contrôler le [mode de lecture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) (auto ou au clic) et la [boucle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/). Ces options sont disponibles via les méthodes de l'objet [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/).

**L'ajout d'une vidéo affecte-t-il la taille du fichier PPTX ?**

Oui. Lorsque vous intégrez une vidéo locale, les données binaires sont incluses dans le document, ainsi la taille de la présentation augmente proportionnellement à la taille du fichier. Lorsque vous liez à une vidéo en ligne et ajoutez une miniature, la présentation enregistre le lien et l'image d'aperçu plutôt que les données vidéo, de sorte que l'augmentation de taille est généralement moindre.

**Puis-je remplacer la vidéo dans une image vidéo existante sans changer sa position et sa taille ?**

Oui. Vous pouvez échanger le [contenu vidéo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setembeddedvideo/) à l'intérieur de l'image tout en conservant la géométrie de la forme ; c'est un scénario courant pour mettre à jour les médias dans une mise en page existante.

**Peut-on déterminer le type de contenu (MIME) d'une vidéo intégrée ?**

Oui. Une vidéo intégrée possède un [type de contenu](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/getcontenttype/) que vous pouvez lire et utiliser, par exemple lors de son enregistrement sur le disque.