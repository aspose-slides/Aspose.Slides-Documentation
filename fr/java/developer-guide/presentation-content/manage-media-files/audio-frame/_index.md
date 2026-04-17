---
title: "Gérer l'audio dans les présentations avec Java"
linktitle: "Cadre audio"
type: docs
weight: 10
url: /fr/java/audio-frame/
keywords:
- audio
- cadre audio
- vignette
- ajouter de l'audio
- propriétés audio
- options audio
- extraire l'audio
- Java
- Aspose.Slides
description: "Créer et contrôler les cadres audio dans Aspose.Slides for Java — exemples de code pour incorporer, couper, mettre en boucle et configurer la lecture dans les présentations PPT, PPTX et ODP."
---
## **Créer des cadres audio**

Aspose.Slides for Java vous permet d’ajouter des fichiers audio aux diapositives. Les fichiers audio sont incorporés dans les diapositives sous forme de cadres audio. 

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/Presentation).
2. Obtenez une référence à une diapositive via son indice.
3. Chargez le flux du fichier audio que vous souhaitez incorporer dans la diapositive.
4. Ajoutez le cadre audio incorporé (contenant le fichier audio) à la diapositive.
5. Définissez [PlayMode](https://reference.aspose.com/slides/fr/java/com.aspose.slides/AudioPlayModePreset) et `Volume` exposés par l’objet [IAudioFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IAudioFrame).
6. Enregistrez la présentation modifiée.

Ce code Java vous montre comment ajouter un cadre audio incorporé à une diapositive :

```java
// Instancie une classe Presentation qui représente un fichier de présentation
Presentation pres = new Presentation();
try {
    // Obtient la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);

    // Charge le fichier son wav dans un flux
    FileInputStream fstr = new FileInputStream(new File("audio.wav"));

    // Ajoute le cadre audio
    IAudioFrame audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    
    // Définit le mode de lecture et le volume de l'audio
    audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    audioFrame.setVolume(AudioVolumeMode.Loud);

    // Écrit le fichier PowerPoint sur le disque
    pres.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Modifier la vignette du cadre audio**

Lorsque vous ajoutez un fichier audio à une présentation, l’audio apparaît sous forme d’un cadre avec une image par défaut standard (voir l’image dans la section ci‑dessous). Vous pouvez modifier l’image d’aperçu du cadre audio (définir votre image préférée).

Ce code Java vous montre comment changer la vignette ou l’image d’aperçu d’un cadre audio :

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Ajoute un cadre audio à la diapositive avec une position et une taille spécifiées.
    FileInputStream audioStream = new FileInputStream("sample2.mp3");
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.close();

    // Ajoute une image aux ressources de la présentation.
    IPPImage picture;
    IImage image = Images.fromFile("eagle.jpeg");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Définit l'image pour le cadre audio.
    audioFrame.getPictureFormat().getPicture().setImage(picture); // <-----

    //Enregistre la présentation modifiée sur le disque
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Modifier les options de lecture audio**

Aspose.Slides for Java vous permet de modifier les options qui contrôlent la lecture ou les propriétés d’un audio. Par exemple, vous pouvez ajuster le volume d’un audio, définir que l’audio se lit en boucle, ou même masquer l’icône audio.

Le volet **Audio Options** dans Microsoft PowerPoint :

![example1_image](audio_frame_0.png)

Options **Audio** de PowerPoint qui correspondent aux propriétés Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/AudioFrame) :

- **Start** de la liste déroulante correspond à la méthode [AudioFrame.setPlayMode](https://reference.aspose.com/slides/fr/java/com.aspose.slides/audioframe/#setPlayMode-int-)
- **Volume** correspond à la méthode [AudioFrame.setVolume](https://reference.aspose.com/slides/fr/java/com.aspose.slides/audioframe/#setVolume-int-)
- **Play Across Slides** correspond à la méthode [AudioFrame.setPlayAcrossSlides](https://reference.aspose.com/slides/fr/java/com.aspose.slides/audioframe/#setPlayAcrossSlides-boolean-)
- **Loop until Stopped** correspond à la méthode [AudioFrame.setPlayLoopMode](https://reference.aspose.com/slides/fr/java/com.aspose.slides/audioframe/#setPlayLoopMode-boolean-)
- **Hide During Show** correspond à la méthode [AudioFrame.setHideAtShowing](https://reference.aspose.com/slides/fr/java/com.aspose.slides/audioframe/#setHideAtShowing-boolean-)
- **Rewind after Playing** correspond à la méthode [AudioFrame.setRewindAudio](https://reference.aspose.com/slides/fr/java/com.aspose.slides/audioframe/#setRewindAudio-boolean-)

Options **Édition** de PowerPoint qui correspondent aux propriétés Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/AudioFrame) :

- **Fade In** correspond à la méthode [AudioFrame.setFadeInDuration](https://reference.aspose.com/slides/fr/java/com.aspose.slides/audioframe/#setFadeInDuration-float-)
- **Fade Out** correspond à la méthode [AudioFrame.setFadeOutDuration](https://reference.aspose.com/slides/fr/java/com.aspose.slides/audioframe/#setFadeOutDuration-float-)
- **Trim Audio Start Time** correspond à la méthode [AudioFrame.setTrimFromStart](https://reference.aspose.com/slides/fr/java/com.aspose.slides/audioframe/#setTrimFromStart-float-)
- **Trim Audio End Time** valeur égale à la durée audio moins la valeur de la méthode [AudioFrame.setTrimFromEnd](https://reference.aspose.com/slides/fr/java/com.aspose.slides/audioframe/#setTrimFromEnd-float-)

Le **contrôle du volume** de PowerPoint sur le panneau de contrôle audio correspond à la méthode [AudioFrame.setVolumeValue](https://reference.aspose.com/slides/fr/java/com.aspose.slides/audioframe/#setVolumeValue-float-). Il vous permet de modifier le volume audio en pourcentage.

Voici comment modifier les options de lecture audio :

1. [Créer](#create-audio-frame) ou obtenir le cadre audio.
2. Définissez de nouvelles valeurs pour les propriétés du cadre audio que vous souhaitez ajuster.
3. Enregistrez le fichier PowerPoint modifié.

Ce code Java montre une opération où les options d’un audio sont ajustées :

```java
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // Obtient la forme AudioFrame
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // Définit le mode de lecture sur lecture au clic
    audioFrame.setPlayMode(AudioPlayModePreset.OnClick);

    // Définit le volume sur Bas
    audioFrame.setVolume(AudioVolumeMode.Low);

    // Définit l'audio pour jouer sur toutes les diapositives
    audioFrame.setPlayAcrossSlides(true);

    // Désactive la boucle pour l'audio
    audioFrame.setPlayLoopMode(false);

    // Masque le AudioFrame pendant le diaporama
    audioFrame.setHideAtShowing(true);

    // Rembobine l'audio au début après la lecture
    audioFrame.setRewindAudio(true);

    // Enregistre le fichier PowerPoint sur le disque
    pres.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Cet exemple Java montre comment ajouter un nouveau cadre audio avec audio incorporé, le couper, et définir les durées de fondu :

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    byte[] audioData = Files.readAllBytes(Paths.get("sampleaudio.mp3"));
    IAudio audio = pres.getAudios().addAudio(audioData);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Définit le décalage de début du rognage à 1,5 secondes
    audioFrame.setTrimFromStart(1500f);
    // Définit le décalage de fin du rognage à 2 secondes
    audioFrame.setTrimFromEnd(2000f);

    // Définit la durée du fondu d'entrée à 200 ms
    audioFrame.setFadeInDuration(200f);
    // Définit la durée du fondu de sortie à 500 ms
    audioFrame.setFadeOutDuration(500f);

    pres.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

L’exemple de code suivant montre comment récupérer un cadre audio avec audio incorporé et régler son volume à 85 % :

```java
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // Obtient une forme de cadre audio
    IAudioFrame audioFrame = (IAudioFrame)slide.getShapes().get_Item(0);

    // Définit le volume audio à 85%
    audioFrame.setVolumeValue(85f);

    pres.save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```

## **Gérer les sous‑titres audio**

Aspose.Slides vous permet d’ajouter des sous‑titres fermés à un cadre audio via la méthode [getCaptionTracks](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iaudioframe/#getCaptionTracks--) . Cette méthode renvoie une [ICaptionsCollection](https://reference.aspose.com/slides/fr/java/com.aspose.slides/icaptionscollection/), qui vous permet d’ajouter des pistes de sous‑titres WebVTT, de parcourir les pistes existantes et de les supprimer si nécessaire.

**Ajouter des sous‑titres audio**

Utilisez la méthode [getCaptionTracks](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iaudioframe/#getCaptionTracks--) pour attacher une ou plusieurs pistes de sous‑titres à un cadre audio. Dans l’exemple suivant, un fichier audio est ajouté à une diapositive, puis une nouvelle piste de sous‑titre est chargée depuis un fichier `.vtt`.

```java
Presentation presentation = new Presentation();
try {
    byte[] audioData = Files.readAllBytes(Paths.get("audio.mp3"));
    IAudio audio = presentation.getAudios().addAudio(audioData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio);

    // Ajouter une nouvelle piste de sous‑titres à partir d'un fichier WebVTT.
    audioFrame.getCaptionTracks().add("New track", "track.vtt");

    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Extraire les sous‑titres audio**

Vous pouvez parcourir les pistes de sous‑titres associées à un cadre audio et les enregistrer en fichiers `.vtt`. Chaque piste de sous‑titre expose ses données binaires et son identifiant unique, qui peuvent être utilisés lors de l’exportation des sous‑titres.

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame ) {
            IAudioFrame audioFrame = (IAudioFrame) shape;
            for (ICaptions captionTrack : audioFrame.getCaptionTracks()) {
                // Enregistre la piste de sous-titres en tant que fichier .vtt.
                Path filePath = Paths.get(captionTrack.getCaptionId() + ".vtt");
                Files.write(filePath, captionTrack.getBinaryData());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

**Supprimer les sous‑titres audio**

Pour supprimer les sous‑titres d’un cadre audio, utilisez les méthodes fournies par [ICaptionsCollection](https://reference.aspose.com/slides/fr/java/com.aspose.slides/icaptionscollection/), telles que [clear](https://reference.aspose.com/slides/fr/java/com.aspose.slides/icaptionscollection/#clear--), [remove](https://reference.aspose.com/slides/fr/java/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-), ou [removeAt](https://reference.aspose.com/slides/fr/java/com.aspose.slides/icaptionscollection/#removeAt-int-). L’exemple suivant supprime toutes les pistes de sous‑titres d’un cadre audio.

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = (IAudioFrame) slide.getShapes().get_Item(0);

    // Supprimer toutes les pistes de sous-titres du cadre audio.
    audioFrame.getCaptionTracks().clear();

    presentation.save("audio_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Extraire l’audio**

Aspose.Slides for Java vous permet d’extraire le son utilisé dans les transitions de diaporama. Par exemple, vous pouvez extraire le son utilisé dans une diapositive spécifique.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/Presentation) et chargez la présentation contenant l’audio.
2. Obtenez la référence de la diapositive concernée via son indice.
3. Accédez aux [slideshow transitions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IBaseSlide#getSlideShowTransition--) de la diapositive.
4. Extrayez le son sous forme de données binaires.

Ce code Java vous montre comment extraire l’audio utilisé dans une diapositive :

```java
// Instancie une classe Presentation qui représente un fichier de présentation
Presentation pres = new Presentation("AudioSlide.pptx");
try {
    // Accède à la diapositive souhaitée
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Obtient les effets de transition du diaporama pour la diapositive
    ISlideShowTransition transition = slide.getSlideShowTransition();
    
    //Extrait le son sous forme de tableau d'octets
    byte[] audio = transition.getSound().getBinaryData();
    System.out.println("Length: " + audio.length);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Puis-je réutiliser le même fichier audio sur plusieurs diapositives sans alourdir le fichier ?**

Oui. Ajoutez l’audio une fois à la [collection audio](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#getAudios--) partagée de la présentation et créez des cadres audio supplémentaires qui référencent cet élément existant. Cela évite de dupliquer les données multimédias et maintient la taille de la présentation sous contrôle.

**Puis-je remplacer le son d’un cadre audio existant sans recréer la forme ?**

Oui. Pour un son lié, mettez à jour le [link path](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) pour pointer vers le nouveau fichier. Pour un son incorporé, remplacez l’[embedded audio](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-) par un autre provenant de la [audio collection](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#getAudios--) de la présentation. Le formatage du cadre et la plupart des paramètres de lecture restent intacts.

**Le découpage modifie-t-il les données audio sous‑jacentes stockées dans la présentation ?**

Non. Le découpage ajuste uniquement les limites de lecture. Les octets audio originaux restent intacts et accessibles via l’audio incorporé ou la collection audio de la présentation.