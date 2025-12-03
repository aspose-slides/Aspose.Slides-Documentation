---
title: Gérer l'audio dans les présentations avec Java
linktitle: Cadre audio
type: docs
weight: 10
url: /fr/java/audio-frame/
keywords:
- audio
- cadre audio
- vignette
- ajouter audio
- propriétés audio
- options audio
- extraire audio
- Java
- Aspose.Slides
description: "Créer et contrôler les cadres audio dans Aspose.Slides pour Java — exemples de code pour incorporer, rogner, boucler et configurer la lecture dans les présentations PPT, PPTX et ODP."
---

## **Créer des cadres audio**

Aspose.Slides for Java vous permet d’ajouter des fichiers audio aux diapositives. Les fichiers audio sont incorporés dans les diapositives sous forme de cadres audio. 

1. Créez une instance de la classe [Présentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Obtenez la référence d’une diapositive via son index.
3. Chargez le flux du fichier audio que vous souhaitez incorporer dans la diapositive.
4. Ajoutez le cadre audio incorporé (contenant le fichier audio) à la diapositive.
5. Définissez le [PlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/AudioPlayModePreset) et `Volume` exposés par l’objet [IAudioFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAudioFrame).
6. Enregistrez la présentation modifiée.

```java
// Crée une instance de la classe Presentation qui représente un fichier de présentation
Presentation pres = new Presentation();
try {
    // Récupère la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);

    // Charge le fichier son wav dans un flux
    FileInputStream fstr = new FileInputStream(new File("audio.wav"));

    // Ajoute le cadre audio
    IAudioFrame audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    
    // Définit le mode de lecture et le volume de l'audio
    audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    audioFrame.setVolume(AudioVolumeMode.Loud);

    // Enregistre le fichier PowerPoint sur le disque
    pres.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Modifier la vignette du cadre audio**

Lorsque vous ajoutez un fichier audio à une présentation, l’audio apparaît sous forme de cadre avec une image par défaut standard (voir l’image dans la section ci‑dessous). Vous pouvez modifier l’image de prévisualisation du cadre audio (définir votre image préférée).

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

Aspose.Slides for Java vous permet de modifier les options qui contrôlent la lecture ou les propriétés d’un audio. Par exemple, vous pouvez régler le volume d’un audio, définir la lecture en boucle, ou même masquer l’icône audio.

Le volet **Options audio** dans Microsoft PowerPoint :

![example1_image](audio_frame_0.png)

Les **Options audio** de PowerPoint qui correspondent aux propriétés [AudioFrame](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame) d’Aspose.Slides :

- **Démarrer** la liste déroulante correspond à la méthode [AudioFrame.setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setPlayMode-int-)
- **Volume** correspond à la méthode [AudioFrame.setVolume](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setVolume-int-)
- **Lecture sur toutes les diapositives** correspond à la méthode [AudioFrame.setPlayAcrossSlides](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setPlayAcrossSlides-boolean-)
- **Boucler jusqu’à l’arrêt** correspond à la méthode [AudioFrame.setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setPlayLoopMode-boolean-)
- **Masquer pendant le diaporama** correspond à la méthode [AudioFrame.setHideAtShowing](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setHideAtShowing-boolean-)
- **Rembobiner après la lecture** correspond à la méthode [AudioFrame.setRewindAudio](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setRewindAudio-boolean-)

Les options **Édition** de PowerPoint qui correspondent aux propriétés [AudioFrame](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame) d’Aspose.Slides :

- **Fondu d’entrée** correspond à la méthode [AudioFrame.setFadeInDuration](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setFadeInDuration-float-)
- **Fondu de sortie** correspond à la méthode [AudioFrame.setFadeOutDuration](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setFadeOutDuration-float-)
- **Rogner le début de l’audio** correspond à la méthode [AudioFrame.setTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setTrimFromStart-float-)
- **Rogner la fin de l’audio** : la valeur correspond à la durée de l’audio moins la valeur de la méthode [AudioFrame.setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setTrimFromEnd-float-)

Le **contrôle du volume** de PowerPoint dans le panneau de contrôle audio correspond à la méthode [AudioFrame.setVolumeValue](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setVolumeValue-float-). Il vous permet de modifier le volume audio en pourcentage.

Voici comment modifier les options de lecture audio :

1. [Créer](#create-audio-frame) ou obtenir le cadre audio.
2. Définissez de nouvelles valeurs pour les propriétés du cadre audio que vous souhaitez ajuster.
3. Enregistrez le fichier PowerPoint modifié.

```java 
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // Obtient la forme AudioFrame
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // Définit le mode de lecture sur lecture au clic
    audioFrame.setPlayMode(AudioPlayModePreset.OnClick);

    // Définit le volume sur Bas
    audioFrame.setVolume(AudioVolumeMode.Low);

    // Définit la lecture de l'audio sur toutes les diapositives
    audioFrame.setPlayAcrossSlides(true);

    // Désactive la boucle pour l'audio
    audioFrame.setPlayLoopMode(false);

    // Masque l'AudioFrame pendant le diaporama
    audioFrame.setHideAtShowing(true);

    // Rembobine l'audio au début après la lecture
    audioFrame.setRewindAudio(true);

    // Enregistre le fichier PowerPoint sur le disque
    pres.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    byte[] audioData = Files.readAllBytes(Paths.get("sampleaudio.mp3"));
    IAudio audio = pres.getAudios().addAudio(audioData);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Définit le décalage de début du rognage à 1,5 seconde
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


## **Extraire l’audio**

Aspose.Slides for Java vous permet d’extraire le son utilisé dans les transitions du diaporama. Par exemple, vous pouvez extraire le son utilisé dans une diapositive spécifique.

1. Créez une instance de la classe [Présentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) et chargez la présentation contenant l’audio.
2. Obtenez la référence de la diapositive concernée via son index.
3. Accédez aux [transitions du diaporama](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getSlideShowTransition--) pour la diapositive.
4. Extrayez le son sous forme de données octetées.

```java
// Instancie une classe Presentation qui représente un fichier de présentation
Presentation pres = new Presentation("AudioSlide.pptx");
try {
    // Accède à la diapositive souhaitée
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Obtient les effets de transition du diaporama pour la diapositive
    ISlideShowTransition transition = slide.getSlideShowTransition();
    
    //Extrait le son dans un tableau d'octets
    byte[] audio = transition.getSound().getBinaryData();
    System.out.println("Length: " + audio.length);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Puis-je réutiliser le même fichier audio sur plusieurs diapositives sans gonfler la taille du fichier ?**

Oui. Ajoutez l’audio une fois à la [collection audio](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getAudios--) partagée de la présentation et créez des cadres audio supplémentaires qui font référence à cet asset existant. Cela évite la duplication des données multimédia et maintient la taille de la présentation sous contrôle.

**Puis-je remplacer le son d’un cadre audio existant sans recréer la forme ?**

Oui. Pour un son lié, mettez à jour le [chemin du lien](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) pour qu’il pointe vers le nouveau fichier. Pour un son incorporé, remplacez l’objet [audio incorporé](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-) par un autre provenant de la [collection audio](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getAudios--) de la présentation. Le format du cadre et la plupart des paramètres de lecture restent intacts.

**Le rognage modifie-t-il les données audio sous‑jacent stockées dans la présentation ?**

Non. Le rognage n’ajuste que les limites de lecture. Les octets audio originaux restent intacts et accessibles via l’audio incorporé ou la collection audio de la présentation.