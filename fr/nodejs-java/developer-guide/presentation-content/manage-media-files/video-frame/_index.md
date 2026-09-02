---
title: Gérer les cadres vidéo dans les présentations avec JavaScript
linktitle: Cadre vidéo
type: docs
weight: 10
url: /fr/nodejs-java/video-frame/
keywords:
- ajouter une vidéo
- créer une vidéo
- intégrer une vidéo
- extraire une vidéo
- récupérer une vidéo
- cadre vidéo
- source Web
- PowerPoint
- OpenDocument
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Apprenez à ajouter et extraire programmatiquement des cadres vidéo dans les diapos PowerPoint et OpenDocument en utilisant Aspose.Slides pour Node.js via Java. Guide pratique rapide."
---
## **Introduction**

Une vidéo bien placée dans une présentation peut rendre votre message plus percutant et augmenter le niveau d'engagement de votre audience. 

PowerPoint vous permet d'ajouter des vidéos à une diapositive d'une présentation de deux manières :

* Ajouter ou intégrer une vidéo locale (stockée sur votre ordinateur)
* Ajouter une vidéo en ligne (provenant d'une source Web telle que YouTube).

Pour vous permettre d'ajouter des vidéos (objets vidéo) à une présentation, Aspose.Slides fournit la classe [Video](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/video/) , la classe [VideoFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/videoframe/) et d'autres types pertinents.

## **Créer un cadre vidéo intégré**

Si le fichier vidéo que vous souhaitez ajouter à votre diapositive est stocké localement, vous pouvez créer un cadre vidéo pour intégrer la vidéo dans votre présentation. 

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Presentation) .
1. Obtenez la référence d'une diapositive via son indice. 
1. Ajoutez un objet [Video](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/video/) et transmettez le chemin du fichier vidéo pour intégrer la vidéo à la présentation.
1. Ajoutez un objet [VideoFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/videoframe/) pour créer un cadre pour la vidéo.
1. Enregistrez la présentation modifiée. 

Ce code JavaScript vous montre comment ajouter une vidéo stockée localement à une présentation :

```javascript
// Instancie la classe Presentation
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // Charge la vidéo
    var fileStream = java.newInstanceSync("java.io.FileInputStream", "Wildlife.mp4");
    var video = pres.getVideos().addVideo(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
    // Obtient la première diapositive et ajoute un cadre vidéo
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);
    // Enregistre la présentation sur le disque
    pres.save("pres-with-video.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Vous pouvez également ajouter une vidéo en passant directement son chemin de fichier à la méthode [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shapecollection/#addVideoFrame-float-float-float-float-aspose.slides.IVideo-) :

```javascript
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    var vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Créer un cadre vidéo avec une vidéo provenant d'une source Web**

Microsoft [PowerPoint 2013 et versions ultérieures](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) prend en charge les vidéos YouTube dans les présentations. Si la vidéo que vous souhaitez utiliser est disponible en ligne (par ex. sur YouTube), vous pouvez l'ajouter à votre présentation via son lien Web. 

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Presentation) .
1. Obtenez la référence d'une diapositive via son indice. 
1. Ajoutez un objet [Video](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/video/) et transmettez le lien vers la vidéo.
1. Définissez une miniature pour le cadre vidéo. 
1. Enregistrez la présentation. 

Ce code JavaScript vous montre comment ajouter une vidéo depuis le Web à une diapositive d'une présentation PowerPoint :

```javascript
// Instancie un objet Presentation qui représente un fichier de présentation
var pres = new aspose.slides.Presentation();
try {
    addVideoFromYouTube(pres, "Tj75Arhq5ho");
    pres.save("out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

```javascript
async function addVideoFromYouTube(pres, videoID) {
    let slide = pres.getSlides().get_Item(0);
    let videoUrl = "https://www.youtube.com/embed/" + videoID;
    let videoFrame = slide.getShapes().addVideoFrame(10, 10, 427, 240, videoUrl);
    
    videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.Auto);

    let thumbnailUri = "http://img.youtube.com/vi/" + videoID + "/hqdefault.jpg";

    try {
        const imageStream = await getImageStream(thumbnailUri);
        let image = pres.getImages().addImage(imageStream);
        videoFrame.getPictureFormat().getPicture().setImage(image);
    } catch (error) {
        console.error("Error loading thumbnail:", error);
    }
}

async function getImageStream(url) {
    return new Promise((resolve, reject) => {
        http.get(url, (response) => {
            if (response.statusCode === 200) {
                resolve(response);
            } else {
                reject(new Error(`Failed to load image: ${response.statusCode}`));
            }
        }).on('error', (e) => {
            reject(e);
        });
    });
}
```

## **Rogner un cadre vidéo**

Aspose.Slides vous permet de contrôler quelle partie d'une vidéo est lue en définissant les valeurs trim‑from‑start et trim‑from‑end via [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/videoframe/settrimfromstart/) et [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/videoframe/settrimfromend/). Les deux valeurs sont exprimées en millisecondes et définissent la durée à ignorer respectivement au début et à la fin de la vidéo. Ces paramètres modifient les réglages de lecture de la vidéo dans la présentation ; ils ne coupent pas et ne modifient pas les données binaires de la vidéo intégrée.

**Définir les paramètres de découpe**

Pour créer un cadre vidéo et définir ses paramètres de découpe :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/) .
1. Ajoutez un objet [Video](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/video/) à la présentation.
1. Ajoutez un objet [VideoFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/videoframe/) à une diapositive.
1. Définissez les valeurs trim‑from‑start et trim‑from‑end via [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/videoframe/settrimfromstart/) et [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/videoframe/settrimfromend/) .
1. Enregistrez la présentation modifiée.

Le code suivant ignore les 2,5 secondes initiales et la dernière seconde d'une vidéo intégrée lors de la lecture :

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const videoStream = java.newInstanceSync("java.io.FileInputStream", "video.mp4");
    try {
        const video = presentation.getVideos().addVideo(
            videoStream, aspose.slides.LoadingStreamBehavior.ReadStreamAndRelease);
        const slide = presentation.getSlides().get_Item(0);
        const videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);

        videoFrame.setTrimFromStart(2500);
        videoFrame.setTrimFromEnd(1000);

        presentation.save("video_with_trim.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        videoStream.close();
    }
} finally {
    presentation.dispose();
}
```

**Lire les paramètres de découpe**

Pour examiner les paramètres de découpe existants, chargez une présentation, trouvez un objet [VideoFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/videoframe/) parmi les formes de la première diapositive, et lisez les valeurs via [VideoFrame.getTrimFromStart](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/videoframe/gettrimfromstart/) et [VideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/videoframe/gettrimfromend/) .

Le code suivant trouve le premier cadre vidéo de la première diapositive et indique ses paramètres de découpe en millisecondes :

```javascript
const presentation = new aspose.slides.Presentation("video_with_trim.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shapeCount = slide.getShapes().size();
    for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            const trimFromStart = videoFrame.getTrimFromStart();
            const trimFromEnd = videoFrame.getTrimFromEnd();

            console.log("Trim from start: " + trimFromStart + " ms");
            console.log("Trim from end: " + trimFromEnd + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **Gérer les légendes vidéo**

Aspose.Slides vous permet de gérer les sous‑titres pour les cadres vidéo dans les présentations PowerPoint. Les sous‑titres sont stockés au format WebVTT et sont accessibles via la méthode [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/videoframe/#getCaptionTracks) .

**Ajouter des sous‑titres à un cadre vidéo**

Pour ajouter des sous‑titres à un cadre vidéo :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/) .
1. Ajoutez une vidéo à la présentation.
1. Ajoutez un objet [VideoFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/videoframe/) à une diapositive.
1. Utilisez la collection [CaptionsCollection](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/captionscollection/) pour ajouter une piste de sous‑titres WebVTT.
1. Enregistrez la présentation modifiée.

Le code suivant montre comment ajouter des sous‑titres à un cadre vidéo :

```js
let presentation = new aspose.slides.Presentation();
try {
    let videoStream = java.newInstanceSync("java.io.FileInputStream", "video.mp4");
    let video = presentation.getVideos().addVideo(videoStream, aspose.slides.LoadingStreamBehavior.KeepLocked);

    let slide = presentation.getSlides().get_Item(0);
    let videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // Ajoute une nouvelle piste de sous-titres à partir d'un fichier WebVTT.
    presentation.save("video_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La classe [CaptionsCollection](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/captionscollection/) propose également la méthode [addFromStream](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/captionscollection/#addFromStream) qui vous permet d’ajouter des sous‑titres à partir d’un flux.

**Extraire les sous‑titres d’un cadre vidéo**

Pour extraire les sous‑titres d’un cadre vidéo :

1. Chargez la présentation contenant la vidéo.
1. Trouvez l’objet [VideoFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/videoframe/) cible.
1. Parcourez la collection [CaptionsCollection](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/captionscollection/) .
1. Enregistrez chaque piste de sous‑titres dans un fichier `.vtt` .

Le code suivant montre comment extraire les sous‑titres d’un cadre vidéo :

```js
let presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shapeCount = slide.getShapes().size();
    for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
        let shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            let videoFrame = shape;
            let trackCount = videoFrame.getCaptionTracks().getCount();
            for (let trackIndex = 0; trackIndex < trackCount; trackIndex++) {
                let captionTrack = videoFrame.getCaptionTracks().get_Item(trackIndex);
                // Enregistre la piste de sous-titres dans un fichier WebVTT.
                let filePath = captionTrack.getCaptionId() + ".vtt";
                let captionData = Buffer.from(captionTrack.getBinaryData());
                fs.writeFileSync(filePath, captionData);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Chaque objet [Captions](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/captions/) expose l’identifiant du sous‑titre, son libellé, les données binaires et le texte du sous‑titre sous forme de chaîne UTF‑8.

**Supprimer les sous‑titres d’un cadre vidéo**

Pour supprimer les sous‑titres d’un cadre vidéo :

1. Chargez la présentation contenant la vidéo.
1. Obtenez l’objet [VideoFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/videoframe/) cible.
1. Supprimez les pistes de sous‑titres de la collection [CaptionsCollection](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/captionscollection/) .
1. Enregistrez la présentation modifiée.

Le code suivant montre comment supprimer tous les sous‑titres d’un cadre vidéo :

```js
let presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let videoFrame = slide.getShapes().get_Item(0); // type: com.aspose.slides.VideoFrame

    // Supprime tous les sous‑titres du cadre vidéo.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Si vous devez supprimer uniquement une piste de sous‑titres, utilisez les méthodes [remove](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/captionscollection/#remove) ou [removeAt](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/captionscollection/#removeAt) au lieu de [clear](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/captionscollection/#clear) .

## **Extraire une vidéo d’une diapositive**

En plus d’ajouter des vidéos aux diapositives, Aspose.Slides vous permet d’extraire les vidéos intégrées dans les présentations.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Presentation) pour charger la présentation contenant la vidéo.
2. Parcourez tous les objets [Slide](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slide/) .
3. Parcourez tous les objets [Shape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shape/) pour trouver un [VideoFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/videoframe/) .
4. Enregistrez la vidéo sur le disque.

Ce code JavaScript vous montre comment extraire la vidéo d’une diapositive d’une présentation :

```javascript
// Instancie un objet Presentation qui représente un fichier de présentation
var pres = new aspose.slides.Presentation("VideoSample.pptx");
try {
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let slide = pres.getSlides().get_Item(i);
        for (let j = 0; j < slide.getShapes().size(); j++) {
            let shape = slide.getShapes().get_Item(j);
            if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
                var vf = shape;
                console.log(shape);
                var type = vf.getEmbeddedVideo().getContentType();
                var ss = type.lastIndexOf('-');
                const buffer = Buffer.from(vf.getEmbeddedVideo().getBinaryData());
                console.log(buffer);
                // Obtient l'extension du fichier
                var charIndex = type.indexOf("/");
                type = type.substring(charIndex + 1);
                fs.writeFileSync("testing2." + type, buffer);
            }
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Quels paramètres de lecture vidéo peuvent être modifiés pour un VideoFrame ?**

Vous pouvez contrôler le [mode de lecture](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/videoframe/setplaymode/) (auto ou au clic) et la [boucle](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/videoframe/setplayloopmode/). Ces options sont disponibles via les propriétés de l’objet [VideoFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/videoframe/) .

**L’ajout d’une vidéo affecte-t-il la taille du fichier PPTX ?**

Oui. Lorsque vous intégrez une vidéo locale, les données binaires sont incluses dans le document, ce qui augmente la taille de la présentation proportionnellement à celle du fichier. Lorsque vous ajoutez une vidéo en ligne, un lien et une miniature sont intégrés, de sorte que l’augmentation de taille est moindre.

**Puis-je remplacer la vidéo d’un VideoFrame existant sans changer sa position et sa taille ?**

Oui. Vous pouvez échanger le [contenu vidéo](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/videoframe/setembeddedvideo/) du cadre tout en conservant la géométrie de la forme ; c’est un scénario courant pour mettre à jour les médias dans une mise en page existante.

**Peut-on déterminer le type de contenu (MIME) d’une vidéo intégrée ?**

Oui. Une vidéo intégrée possède un [type de contenu](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/video/getcontenttype/) que vous pouvez lire et utiliser, par exemple lors de son enregistrement sur le disque.