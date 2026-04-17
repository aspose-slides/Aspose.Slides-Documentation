---
title: Gérer l’audio dans les présentations avec JavaScript
linktitle: Cadre audio
type: docs
weight: 10
url: /fr/nodejs-java/audio-frame/
keywords:
- audio
- cadre audio
- miniature
- ajouter de l’audio
- propriétés audio
- options audio
- extraire l’audio
- Node.js
- JavaScript
- Aspose.Slides
description: "Créer et contrôler des cadres audio dans Aspose.Slides pour Node.js — exemples pour intégrer, découper, boucler et configurer la lecture dans les présentations PPT, PPTX et ODP."
---
## **Créer des cadres audio**

Aspose.Slides for Node.js via Java vous permet d’ajouter des fichiers audio aux diapositives. Les fichiers audio sont intégrés aux diapositives sous forme de cadres audio.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Presentation).
2. Obtenez la référence d’une diapositive via son indice.
3. Chargez le flux du fichier audio que vous souhaitez intégrer dans la diapositive.
4. Ajoutez le cadre audio intégré (contenant le fichier audio) à la diapositive.
5. Définissez [PlayMode](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/AudioPlayModePreset) et `Volume` exposés par l’objet [AudioFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/AudioFrame).
6. Enregistrez la présentation modifiée.

Ce code JavaScript vous montre comment ajouter un cadre audio intégré à une diapositive :

```javascript
// Instancie une classe Presentation qui représente un fichier de présentation
const pres = new aspose.slides.Presentation();
try {
    // Obtient la première diapositive
    const sld = pres.getSlides().get_Item(0);
    // Charge le fichier son wav dans un flux
    const fstr = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "audio.wav"));
    // Ajoute le cadre audio
    const audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    // Définit le mode de lecture et le volume de l’audio
    audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.Auto);
    audioFrame.setVolume(aspose.slides.AudioVolumeMode.Loud);
    // Écrit le fichier PowerPoint sur le disque
    pres.save("AudioFrameEmbed_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Modifier la miniature du cadre audio**

Lorsque vous ajoutez un fichier audio à une présentation, l’audio apparaît sous la forme d’un cadre avec une image par défaut standard (voir l’image dans la section ci‑dessous). Vous pouvez changer l’image d’aperçu du cadre audio (définir votre image préférée).

Ce code JavaScript vous montre comment modifier la miniature ou l’image d’aperçu d’un cadre audio :

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    // Ajoute un cadre audio à la diapositive avec une position et une taille spécifiées.
    const audioStream = java.newInstanceSync("java.io.FileInputStream", "sample2.mp3");
    const audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.close();
    // Ajoute une image aux ressources de la présentation.
    let picture;
    const image = aspose.slides.Images.fromFile("eagle.jpeg");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Définit l’image pour le cadre audio.
    audioFrame.getPictureFormat().getPicture().setImage(picture);// <-----
    // Enregistre la présentation modifiée sur le disque
    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Modifier les options de lecture audio**

Aspose.Slides for Node.js via Java vous permet de modifier les options qui contrôlent la lecture ou les propriétés d’un audio. Par exemple, vous pouvez ajuster le volume, définir la lecture en boucle ou même masquer l’icône audio.

Le panneau **Options audio** dans Microsoft PowerPoint :

![example1_image](audio_frame_0.png)

Options audio de PowerPoint qui correspondent aux propriétés Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/audioframe/) :

- **Démarrage** la liste déroulante correspond à la méthode [AudioFrame.setPlayMode](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/audioframe/#setPlayMode)
- **Volume** correspond à la méthode [AudioFrame.setVolume](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/audioframe/#setVolume)
- **Lecture sur plusieurs diapositives** correspond à la méthode [AudioFrame.setPlayAcrossSlides](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/audioframe/#setPlayAcrossSlides)
- **Boucle jusqu’à l’arrêt** correspond à la méthode [AudioFrame.setPlayLoopMode](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/audioframe/#setPlayLoopMode)
- **Masquer pendant le diaporama** correspond à la méthode [AudioFrame.setHideAtShowing](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/audioframe/#setHideAtShowing)
- **Rembobiner après la lecture** correspond à la méthode [AudioFrame.setRewindAudio](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/audioframe/#setRewindAudio)

Options d’**édition** de PowerPoint qui correspondent aux propriétés Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/audioframe/) :

- **Fondu d’entrée** correspond à la méthode [AudioFrame.setFadeInDuration](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/audioframe/#setFadeInDuration) 
- **Fondu de sortie** correspond à la méthode [AudioFrame.setFadeOutDuration](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/audioframe/#setFadeOutDuration) 
- **Trim du temps de démarrage audio** correspond à la méthode [AudioFrame.setTrimFromStart](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/audioframe/#setTrimFromStart) 
- **Trim du temps de fin audio** équivaut à la durée de l’audio moins la valeur de la méthode [AudioFrame.setTrimFromEnd](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd)

Le **contrôle du volume** de PowerPoint sur le panneau de contrôle audio correspond à la méthode [AudioFrame.setVolumeValue](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/audioframe/#setVolumeValue). Il vous permet de modifier le volume audio en pourcentage.

Voici comment modifier les options de lecture audio :

1. [Créer](#create-audio-frame) ou obtenez le cadre audio.
2. Définissez de nouvelles valeurs pour les propriétés du cadre audio que vous souhaitez ajuster.
3. Enregistrez le fichier PowerPoint modifié.

Ce code JavaScript montre une opération dans laquelle les options d’un audio sont ajustées :

```javascript
const pres = new aspose.slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    // Obtient la forme AudioFrame
    const audioFrame = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Définit le mode de lecture sur lecture au clic
    audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.OnClick);
    // Définit le volume à Bas
    audioFrame.setVolume(aspose.slides.AudioVolumeMode.Low);
    // Définit l’audio pour lire sur plusieurs diapositives
    audioFrame.setPlayAcrossSlides(true);
    // Désactive la boucle pour l’audio
    audioFrame.setPlayLoopMode(false);
    // Masque le cadre audio pendant le diaporama
    audioFrame.setHideAtShowing(true);
    // Rembobine l’audio au début après la lecture
    audioFrame.setRewindAudio(true);
    // Enregistre le fichier PowerPoint sur le disque
    pres.save("AudioFrameEmbed_changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Cet exemple JavaScript montre comment ajouter un nouveau cadre audio avec audio intégré, le découper et définir les durées de fondu :

```js
const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);
    
    const audioData = java.newArray("byte", Array.from(fs.readFileSync("sampleaudio.mp3")));
    const audio = pres.getAudios().addAudio(audioData);
    const audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Définit le décalage de début du découpage à 1,5 seconde
    // Définit le décalage de fin du découpage à 2 secondes

    // Définit la durée du fondu d’entrée à 200 ms
    // Définit la durée du fondu de sortie à 500 ms

    pres.save("AudioFrameTrimFade_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

L’exemple de code suivant montre comment récupérer un cadre audio avec audio intégré et définir son volume à 85 % :

```js
const pres = new aspose.slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    const slide = pres.getSlides().get_Item(0);

    // Obtient une forme de cadre audio
    const audioFrame = slide.getShapes().get_Item(0);

    // Définit le volume audio à 85%
    audioFrame.setVolumeValue(85.0);

    pres.save("AudioFrameValue_out.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```

## **Gérer les légendes audio**

Aspose.Slides vous permet d’ajouter des sous‑titres fermés à un cadre audio via la méthode [getCaptionTracks](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/audioframe/#getCaptionTracks). Cette méthode renvoie une [CaptionsCollection](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/captionscollection/), qui vous permet d’ajouter des pistes de sous‑titres WebVTT, d’itérer les pistes existantes et de les supprimer si nécessaire.

**Ajouter des légendes audio**

Utilisez la méthode [getCaptionTracks](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/audioframe/#getCaptionTracks) pour attacher une ou plusieurs pistes de sous‑titres à un cadre audio. Dans l’exemple suivant, un fichier audio est ajouté à une diapositive, puis une nouvelle piste de sous‑titres est chargée depuis un fichier `.vtt`.

```js
let presentation = new aspose.slides.Presentation();
try {
    let audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.mp3");
    let audio = presentation.getAudios().addAudio(audioStream);
    audioStream.close();

    let slide = presentation.getSlides().get_Item(0);
    let audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio);

    // Ajouter une nouvelle piste de sous-titres à partir d'un fichier WebVTT.
    audioFrame.getCaptionTracks().add("New track", "track.vtt");

    presentation.save("audio_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Extraire les légendes audio**

Vous pouvez itérer les pistes de sous‑titres associées à un cadre audio et les enregistrer en fichiers `.vtt`. Chaque piste expose ses données binaires et son identifiant unique, utilisables lors de l’exportation des sous‑titres.

```js
let presentation = new aspose.slides.Presentation("audio_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shapeCount = slide.getShapes().size();
    for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
        let shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            let audioFrame = shape;
            let trackCount = audioFrame.getCaptionTracks().getCount();
            for (let trackIndex = 0; trackIndex < trackCount; trackIndex++) {
                let captionTrack = audioFrame.getCaptionTracks().get_Item(trackIndex);
                // Enregistrer la piste de sous‑titres sous forme de fichier .vtt.
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

**Supprimer les légendes audio**

Pour supprimer des sous‑titres d’un cadre audio, utilisez les méthodes proposées par [CaptionsCollection](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/captionscollection/), telles que [clear](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/captionscollection/#clear), [remove](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/captionscollection/#remove) ou [removeAt](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/captionscollection/#removeAt). L’exemple suivant supprime toutes les pistes de sous‑titres d’un cadre audio.

```js
let presentation = new aspose.slides.Presentation("audio_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let audioFrame = slide.getShapes().get_Item(0); // type : aspose.slides.AudioFrame

    // Supprimer toutes les pistes de sous‑titres du cadre audio.
    audioFrame.getCaptionTracks().clear();

    presentation.save("audio_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Extraire l’audio**

Aspose.Slides for Node.js via Java vous permet d’extraire le son utilisé dans les transitions de diaporama. Par exemple, vous pouvez extraire le son utilisé dans une diapositive spécifique.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Presentation) et chargez la présentation contenant l’audio.
2. Obtenez la référence de la diapositive concernée via son indice.
3. Accédez aux [transitions du diaporama](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/BaseSlide#getSlideShowTransition--) de la diapositive.
4. Extrayez le son sous forme de données octetées.

Ce code en JavaScript vous montre comment extraire l’audio utilisé dans une diapositive :

```javascript
// Instancie une classe Presentation qui représente un fichier de présentation
const pres = new aspose.slides.Presentation("AudioSlide.pptx");
try {
    // Accède à la diapositive souhaitée
    const slide = pres.getSlides().get_Item(0);
    // Obtient les effets de transition du diaporama pour la diapositive
    const transition = slide.getSlideShowTransition();
    // Extrait le son sous forme de tableau d'octets
    const audio = transition.getSound().getBinaryData();
    console.log("Length: " + audio.length);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Puis-je réutiliser le même fichier audio sur plusieurs diapositives sans augmenter la taille du fichier ?**

Oui. Ajoutez l’audio une fois à la [collection audio partagée](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/getaudios/) de la présentation et créez des cadres audio supplémentaires qui font référence à cet actif existant. Cela évite la duplication des données multimédia et maintient la taille de la présentation sous contrôle.

**Puis-je remplacer le son d’un cadre audio existant sans recréer la forme ?**

Oui. Pour un son lié, mettez à jour le [chemin du lien](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/audioframe/setlinkpathlong/) pour qu’il pointe vers le nouveau fichier. Pour un son intégré, échangez l’objet [embedded audio](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/audioframe/setembeddedaudio/) avec un autre provenant de la [collection audio](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/getaudios/) de la présentation. Le format du cadre et la plupart des paramètres de lecture restent intacts.

**Le découpage modifie-t-il les données audio sous-jacentes stockées dans la présentation ?**

Non. Le découpage ajuste uniquement les limites de lecture. Les octets audio originaux demeurent inchangés et accessibles via l’audio intégré ou la collection audio de la présentation.