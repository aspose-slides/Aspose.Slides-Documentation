---
title: Gérer les cadres audio dans les présentations avec JavaScript
linktitle: Cadre audio
type: docs
weight: 10
url: /fr/nodejs-java/audio-frame/
keywords:
- audio
- cadre audio
- miniature
- ajouter audio
- propriétés audio
- options audio
- extraire audio
- Node.js
- JavaScript
- Aspose.Slides
description: "Intégrez de l'audio dans les diapositives, modifiez l'icône audio, configurez la lecture, gérez les sous-titres WebVTT et extrayez les sons de transition des diapositives avec Aspose.Slides pour Node.js via Java."
---
## **Vue d'ensemble**

Un cadre audio vous permet de lire un son sur une diapositive. Avec Aspose.Slides for Node.js via Java, vous pouvez intégrer un clip audio, choisir l'image qui le représente, ajuster la lecture et ajouter des sous‑titres. Vous pouvez également récupérer un son attribué à une transition de diapositive.

## **Créer des cadres audio**

Utilisez [addAudioFrameEmbedded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) pour intégrer un clip audio local sur la première diapositive. Les deux premières coordonnées positionnent le cadre sur la diapositive, et les deux suivantes définissent sa largeur et sa hauteur, toutes en points. Cet exemple appelle [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayMode) pour démarrer le clip automatiquement et appelle [setVolume](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolume) pour sélectionner le préréglage fort.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.wav");
    try {
        const audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, audioStream);
        audioFrame.setPlayMode(slides.AudioPlayModePreset.Auto);
        audioFrame.setVolume(slides.AudioVolumeMode.Loud);
    } finally {
        audioStream.close();
    }
    presentation.save("AudioFrameEmbed_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Modifier la miniature du cadre audio**

Par défaut, un cadre audio affiche une icône de haut‑parleur. Pour afficher une miniature personnalisée, ajoutez une image à la présentation avec [addImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/#addImage) et définissez‑la sur l'image du cadre avec [setImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/#setImage). L'exemple utilise `eagle.jpeg` comme miniature pour un clip audio intégré.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.wav");
    try {
        const audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
        const imageStream = java.newInstanceSync("java.io.FileInputStream", "eagle.jpeg");
        try {
            const thumbnail = presentation.getImages().addImage(imageStream);
            audioFrame.getPictureFormat().getPicture().setImage(thumbnail);
        } finally {
            imageStream.close();
        }
    } finally {
        audioStream.close();
    }
    presentation.save("example_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Modifier les options de lecture audio**

Les contrôles **Options audio** de PowerPoint déterminent quand un clip commence, son volume et son comportement pendant le diaporama.

![Contrôles des Options audio de PowerPoint pour un cadre audio](audio_frame_0.png)

| Contrôle PowerPoint | Méthode Aspose.Slides for Node.js via Java |
| --- | --- |
| Démarrer | [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayMode) |
| Préréglage du volume | [setVolume](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolume) |
| Lecture sur plusieurs diapositives | [setPlayAcrossSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayAcrossSlides) |
| Boucler jusqu'à l'arrêt | [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayLoopMode) |
| Masquer pendant le diaporama | [setHideAtShowing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setHideAtShowing) |
| Rembobiner après lecture | [setRewindAudio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setRewindAudio) |
| Fondu entrant | [setFadeInDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setFadeInDuration) |
| Fondu sortant | [setFadeOutDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setFadeOutDuration) |
| Couper le temps de début audio | [setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromStart) |
| Couper le temps de fin audio | [setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd) |
| Curseur de volume | [setVolumeValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolumeValue) |

L'exemple trouve le premier cadre audio sur la première diapositive, appelle [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayMode) pour démarrer la lecture au clic, et sélectionne le préréglage de volume bas. Le clip continue sur plusieurs diapositives avec la boucle désactivée. L'icône reste masquée pendant le diaporama, et le clip est rembobiné après la lecture.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapes = slide.getShapes();
    let audioFrame = null;
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            audioFrame = shape;
            break;
        }
    }

    if (audioFrame) {
        audioFrame.setPlayMode(slides.AudioPlayModePreset.OnClick);
        audioFrame.setVolume(slides.AudioVolumeMode.Low);
        audioFrame.setPlayAcrossSlides(true);
        audioFrame.setPlayLoopMode(false);
        audioFrame.setHideAtShowing(true);
        audioFrame.setRewindAudio(true);
        presentation.save("AudioFrameEmbed_changed.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

Pour un clip de plus de 3,5 secondes, cet exemple saute les 1,5 premières secondes et les 2 dernières secondes. [setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd) prend la durée à omettre à la fin du clip. Pour obtenir l'heure de fin affichée dans PowerPoint, soustrayez ce décalage de la durée totale du clip. Le clip tronqué effectue un fondu entrant sur 200 millisecondes et un fondu sortant sur 500 millisecondes. Les quatre méthodes acceptent des valeurs en millisecondes.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.wav");
    try {
        const audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audioStream);
        audioFrame.setTrimFromStart(1500);
        audioFrame.setTrimFromEnd(2000);
        audioFrame.setFadeInDuration(200);
        audioFrame.setFadeOutDuration(500);
    } finally {
        audioStream.close();
    }
    presentation.save("AudioFrameTrimFade_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pour définir le volume de lecture à un pourcentage spécifique, utilisez [setVolumeValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolumeValue). Cet exemple fixe le volume du premier cadre audio sur la première diapositive à 85 %.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapes = slide.getShapes();
    let audioFrame = null;
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            audioFrame = shape;
            break;
        }
    }

    if (audioFrame) {
        audioFrame.setVolumeValue(85);
        presentation.save("AudioFrameValue_out.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

## **Gérer les sous‑titres audio**

Chaque cadre audio donne accès à ses pistes de sous‑titres via [getCaptionTracks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#getCaptionTracks). Utilisez la collection pour attacher des sous‑titres WebVTT au clip, exporter les pistes existantes ou les supprimer.

### **Ajouter des sous‑titres audio**

L'exemple intègre un clip audio sur la première diapositive et utilise [add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#add) pour attacher une piste WebVTT locale. Le premier argument fournit le libellé de la piste, et le second identifie le fichier contenant les sous‑titres synchronisés.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.wav");
    try {
        const audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audioStream);
        audioFrame.getCaptionTracks().add("English", "track.vtt");
    } finally {
        audioStream.close();
    }
    presentation.save("audio_with_captions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Extraire les sous‑titres audio**

Cet exemple exporte chaque piste de sous‑titre attachée à un cadre audio sur la première diapositive. Il écrit les octets renvoyés par [getBinaryData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/#getBinaryData) dans un fichier WebVTT et utilise l'identifiant renvoyé par [getCaptionId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/#getCaptionId) comme nom de fichier afin que chaque piste possède une sortie distincte.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("node:fs");

const presentation = new slides.Presentation("audio_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapes = slide.getShapes();
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            continue;
        }
        const tracks = shape.getCaptionTracks();
        for (let k = 0; k < tracks.getCount(); k++) {
            const track = tracks.get_Item(k);
            const fileName = track.getCaptionId() + ".vtt";
            const bytes = track.getBinaryData();
            const data = Buffer.from(bytes);
            fs.writeFileSync(fileName, data);
        }
    }
} finally {
    presentation.dispose();
}
```

### **Supprimer les sous‑titres audio**

Utilisez [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#remove) ou [removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#removeAt) pour supprimer une piste individuelle. L'exemple utilise [clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#clear) pour enlever tous les sous‑titres du premier cadre audio sur la première diapositive tout en conservant le clip.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("audio_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapes = slide.getShapes();
    let audioFrame = null;
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            audioFrame = shape;
            break;
        }
    }

    if (audioFrame) {
        audioFrame.getCaptionTracks().clear();
        presentation.save("audio_without_captions.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

### **Trouver une ligne dans les sous‑titres audio**

Pour trouver une ligne dans les sous‑titres audio de la première diapositive, recherchez le texte renvoyé par [getDataAsString](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/#getDataAsString) en mémoire. Dans un cue WebVTT en texte brut, la ligne de synchronisation contient `-->`, les lignes de sous‑titre la suivent, et une ligne vide termine le cue. Cet exemple affiche le libellé de la piste et chaque ligne de sous‑titre contenant « café ».

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("audio_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapes = slide.getShapes();
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            continue;
        }
        const tracks = shape.getCaptionTracks();
        for (let k = 0; k < tracks.getCount(); k++) {
            const track = tracks.get_Item(k);
            let inCue = false;
            const captions = track.getDataAsString();
            for (const line of captions.split(/\r\n|\n|\r/)) {
                if (line === "") {
                    inCue = false;
                } else if (line.includes("-->")) {
                    inCue = true;
                } else if (inCue && line.toLowerCase().includes("café")) {
                    console.log(track.getLabel() + ": " + line);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Extraire l'audio**

Une transition de diapositive peut avoir son propre son. Pour le récupérer, appelez [getSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getSound) sur la transition de diapositive. L'exemple accède aux octets renvoyés par [getBinaryData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audio/#getBinaryData) et affiche le nombre d'octets. Si la première diapositive n'a pas de son de transition, il affiche un message à la place.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("AudioSlide.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    
    const sound = slide.getSlideShowTransition().getSound();
    if (sound) {
        const audioData = sound.getBinaryData();
        console.log("Transition sound: " + audioData.length + " bytes.");
    } else {
        console.log("The first slide has no transition sound.");
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Puis‑je réutiliser le même clip audio sur plusieurs diapositives sans le dupliquer ?**

Oui. Ajoutez le clip une fois à la [collection audio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getAudios) de la présentation et passez le même objet audio à [addAudioFrameEmbedded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) pour chaque diapositive.

**Puis‑je remplacer le son d'un cadre audio existant ?**

Oui. Pour un son lié, utilisez [setLinkPathLong](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setLinkPathLong) pour pointer vers le fichier de remplacement. Pour un son intégré, sélectionnez un autre clip dans la [collection audio] de la présentation avec [setEmbeddedAudio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setEmbeddedAudio). Les deux approches conservent le cadre existant.

**Le rognage modifie-t-il les données audio stockées dans la présentation ?**

Non. [setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromStart) et [setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd) définissent les limites de lecture. Vous pouvez toujours récupérer le clip complet avec [getEmbeddedAudio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#getEmbeddedAudio).