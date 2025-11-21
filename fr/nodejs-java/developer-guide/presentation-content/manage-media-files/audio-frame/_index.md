---
title: Gérer l'audio dans les présentations avec JavaScript
linktitle: Cadre audio
type: docs
weight: 10
url: /fr/nodejs-java/audio-frame/
keywords:
- audio
- cadre audio
- miniature
- ajouter de l'audio
- propriétés audio
- options audio
- extraire l'audio
- Node.js
- JavaScript
- Aspose.Slides
description: "Créer et contrôler les cadres audio dans Aspose.Slides pour Node.js — exemples JavaScript pour intégrer, rogner, boucler et configurer la lecture dans les présentations PPT, PPTX et ODP."
---

## **Créer des cadres audio**

Aspose.Slides for Node.js via Java vous permet d'ajouter des fichiers audio aux diapositives. Les fichiers audio sont intégrés dans les diapositives sous forme de cadres audio.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Obtenez la référence d'une diapositive via son index.
3. Chargez le flux du fichier audio que vous souhaitez intégrer dans la diapositive.
4. Ajoutez le cadre audio intégré (contenant le fichier audio) à la diapositive.
5. Définissez [PlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AudioPlayModePreset) et `Volume` exposés par l'objet [AudioFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AudioFrame).
6. Enregistrez la présentation modifiée.

Ce code JavaScript vous montre comment ajouter un cadre audio intégré à une diapositive:
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
    // Définit le mode de lecture et le volume de l'audio
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

Lorsque vous ajoutez un fichier audio à une présentation, l'audio apparaît sous forme de cadre avec une image standard par défaut (voir l'image dans la section ci-dessous). Vous pouvez modifier l'image d'aperçu du cadre audio (définir votre image préférée).

Ce code JavaScript vous montre comment modifier la miniature ou l'image d'aperçu d'un cadre audio :
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
    // Définit l'image pour le cadre audio.
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

Aspose.Slides for Node.js via Java vous permet de modifier les options qui contrôlent la lecture ou les propriétés d'un audio. Par exemple, vous pouvez ajuster le volume d'un audio, définir la lecture en boucle, ou même masquer l'icône audio.

Le volet **Options audio** dans Microsoft PowerPoint :

![example1_image](audio_frame_0.png)

Les **options audio** de PowerPoint qui correspondent aux propriétés Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/) :
- **Démarrer** la liste déroulante correspond à la méthode [AudioFrame.setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayMode)
- **Volume** correspond à la méthode [AudioFrame.setVolume](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolume)
- **Lire sur plusieurs diapositives** correspond à la méthode [AudioFrame.setPlayAcrossSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayAcrossSlides)
- **Boucler jusqu'à l'arrêt** correspond à la méthode [AudioFrame.setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayLoopMode)
- **Masquer pendant le diaporama** correspond à la méthode [AudioFrame.setHideAtShowing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setHideAtShowing)
- **Rembobiner après lecture** correspond à la méthode [AudioFrame.setRewindAudio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setRewindAudio)

Les options **édition** de PowerPoint qui correspondent aux propriétés Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/) :
- **Fondu d'entrée** correspond à la méthode [AudioFrame.setFadeInDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setFadeInDuration)
- **Fondu de sortie** correspond à la méthode [AudioFrame.setFadeOutDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setFadeOutDuration)
- **Rogner le temps de début de l'audio** correspond à la méthode [AudioFrame.setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromStart)
- **Rogner le temps de fin de l'audio** valeur égale à la durée de l'audio moins la valeur de la méthode [AudioFrame.setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd)

Le **contrôle du volume** de PowerPoint dans le panneau de contrôle audio correspond à la méthode [AudioFrame.setVolumeValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolumeValue). Il vous permet de modifier le volume audio en pourcentage.

Voici comment modifier les options de lecture audio :
1. [Créer](#create-audio-frame) ou obtenir le cadre audio.
2. Définissez de nouvelles valeurs pour les propriétés du cadre audio que vous souhaitez ajuster.
3. Enregistrez le fichier PowerPoint modifié.

Ce code JavaScript démontre une opération où les options d'un audio sont ajustées :
```javascript
const pres = new aspose.slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    // Récupère la forme AudioFrame
    const audioFrame = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // Définit le mode de lecture sur lecture au clic
    audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.OnClick);
    // Définit le volume à Bas
    audioFrame.setVolume(aspose.slides.AudioVolumeMode.Low);
    // Définit la lecture audio sur toutes les diapositives
    audioFrame.setPlayAcrossSlides(true);
    // Désactive la boucle pour l'audio
    audioFrame.setPlayLoopMode(false);
    // Masque le cadre audio pendant le diaporama
    audioFrame.setHideAtShowing(true);
    // Rembobine l'audio au début après la lecture
    audioFrame.setRewindAudio(true);
    // Enregistre le fichier PowerPoint sur le disque
    pres.save("AudioFrameEmbed_changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Cet exemple JavaScript montre comment ajouter un nouveau cadre audio avec audio intégré, le rogner, et définir les durées de fondu :
```js
const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);
    
    const audioData = java.newArray("byte", Array.from(fs.readFileSync("sampleaudio.mp3")));
    const audio = pres.getAudios().addAudio(audioData);
    const audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Définit le décalage de début du rognage à 1,5 seconde
    audioFrame.setTrimFromStart(1500);
    // Définit le décalage de fin du rognage à 2 secondes
    audioFrame.setTrimFromEnd(2000);

    // Définit la durée du fondu d'entrée à 200 ms
    audioFrame.setFadeInDuration(200);
    // Définit la durée du fondu de sortie à 500 ms
    audioFrame.setFadeOutDuration(500);

    pres.save("AudioFrameTrimFade_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


L'exemple de code suivant montre comment récupérer un cadre audio avec audio intégré et régler son volume à 85 % :
```js
const pres = new aspose.slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    const slide = pres.getSlides().get_Item(0);

    // Récupère une forme AudioFrame
    const audioFrame = slide.getShapes().get_Item(0);

    // Définit le volume de l'audio à 85%
    audioFrame.setVolumeValue(85.0);

    pres.save("AudioFrameValue_out.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```


## **Extraire l'audio**

Aspose.Slides for Node.js via Java vous permet d'extraire le son utilisé dans les transitions de diaporama. Par exemple, vous pouvez extraire le son utilisé dans une diapositive spécifique.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) et chargez la présentation contenant l'audio.
2. Obtenez la référence de la diapositive concernée via son index.
3. Accédez aux [transitions du diaporama](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getSlideShowTransition--) pour la diapositive.
4. Extrayez le son sous forme de données binaires.

Ce code JavaScript vous montre comment extraire l'audio utilisé dans une diapositive :
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

Oui. Ajoutez l'audio une fois à la collection d'**audio partagé** de la présentation [audio collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getaudios/) et créez des cadres audio supplémentaires qui font référence à cet actif existant. Cela évite la duplication des données multimédias et maintient la taille de la présentation sous contrôle.

**Puis-je remplacer le son d'un cadre audio existant sans recréer la forme ?**

Oui. Pour un son lié, mettez à jour le [link path](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/setlinkpathlong/) pour qu'il pointe vers le nouveau fichier. Pour un son intégré, remplacez l'objet [embedded audio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/setembeddedaudio/) par un autre provenant de la [audio collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getaudios/) de la présentation. La mise en forme du cadre et la plupart des paramètres de lecture restent intacts.

**Le rognage modifie-t-il les données audio sous‑jacentes stockées dans la présentation ?**

Non. Le rognage n’ajuste que les limites de lecture. Les octets audio originaux restent intacts et accessibles via l'audio intégré ou la collection d'audio de la présentation.