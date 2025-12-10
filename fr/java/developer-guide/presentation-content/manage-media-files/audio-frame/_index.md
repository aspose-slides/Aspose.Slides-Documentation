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
description: "Créer et contrôler les cadres audio dans Aspose.Slides for Java—exemples de code pour incorporer, rogner, mettre en boucle et configurer la lecture dans les présentations PPT, PPTX et ODP."
---

## **Créer des cadres audio**

Aspose.Slides for Java vous permet d'ajouter des fichiers audio aux diapositives. Les fichiers audio sont incorporés dans les diapositives sous forme de cadres audio. 

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Obtenez une référence à la diapositive via son index.
3. Chargez le flux du fichier audio que vous souhaitez incorporer dans la diapositive.
4. Ajoutez le cadre audio incorporé (contenant le fichier audio) à la diapositive.
5. Définissez [PlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/AudioPlayModePreset) et `Volume` exposés par l'objet [IAudioFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAudioFrame).
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

    // Enregistre le fichier PowerPoint sur le disque
    pres.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Modifier la miniature du cadre audio**

Lorsque vous ajoutez un fichier audio à une présentation, l'audio apparaît sous forme d'un cadre avec une image par défaut standard (voir l'image dans la section ci‑dessous). Vous pouvez modifier l'image d'aperçu du cadre audio (définir votre image préférée).

Ce code Java vous montre comment modifier la miniature ou l'image d'aperçu d'un cadre audio :
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

    // Définit l'image du cadre audio.
    audioFrame.getPictureFormat().getPicture().setImage(picture); // <-----

    //Enregistre la présentation modifiée sur le disque
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **Modifier les options de lecture audio**

Aspose.Slides for Java vous permet de modifier les options qui contrôlent la lecture ou les propriétés d'un audio. Par exemple, vous pouvez ajuster le volume d'un audio, définir la lecture en boucle, ou même masquer l'icône audio.

Le volet **Audio Options** dans Microsoft PowerPoint :
![example1_image](audio_frame_0.png)

Les **Audio Options** de PowerPoint qui correspondent aux propriétés [AudioFrame](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame) d’Aspose.Slides :
- **Start** (liste déroulante) correspond à la méthode [AudioFrame.setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setPlayMode-int-).
- **Volume** correspond à la méthode [AudioFrame.setVolume](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setVolume-int-).
- **Play Across Slides** correspond à la méthode [AudioFrame.setPlayAcrossSlides](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setPlayAcrossSlides-boolean-).
- **Loop until Stopped** correspond à la méthode [AudioFrame.setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setPlayLoopMode-boolean-).
- **Hide During Show** correspond à la méthode [AudioFrame.setHideAtShowing](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setHideAtShowing-boolean-).
- **Rewind after Playing** correspond à la méthode [AudioFrame.setRewindAudio](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setRewindAudio-boolean-).

Les options **Editing** de PowerPoint qui correspondent aux propriétés [AudioFrame](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame) d’Aspose.Slides :
- **Fade In** correspond à la méthode [AudioFrame.setFadeInDuration](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setFadeInDuration-float-).
- **Fade Out** correspond à la méthode [AudioFrame.setFadeOutDuration](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setFadeOutDuration-float-).
- **Trim Audio Start Time** correspond à la méthode [AudioFrame.setTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setTrimFromStart-float-).
- **Trim Audio End Time** correspond à la durée de l'audio moins la valeur de la méthode [AudioFrame.setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setTrimFromEnd-float-).

Le **Volume controll** de PowerPoint sur le panneau de contrôle audio correspond à la méthode [AudioFrame.setVolumeValue](https://reference.aspose.com/slides/java/com.aspose.slides/audioframe/#setVolumeValue-float-). Il vous permet de modifier le volume audio en pourcentage.

Voici comment modifier les options de lecture audio :
1. [Créer](#create-audio-frame) ou obtenir le cadre audio.
2. Définissez de nouvelles valeurs pour les propriétés du cadre audio que vous souhaitez ajuster.
3. Enregistrez le fichier PowerPoint modifié.

Ce code Java montre une opération dans laquelle les options d'un audio sont ajustées :
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


Cet exemple Java montre comment ajouter un nouveau cadre audio avec audio incorporé, le rogner et définir les durées de fondu :
```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    byte[] audioData = Files.readAllBytes(Paths.get("sampleaudio.mp3"));
    IAudio audio = pres.getAudios().addAudio(audioData);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Définit le décalage de début du rognage à 1.5 seconde
    audioFrame.setTrimFromStart(1500f);
    // Définit le décalage de fin du rognage à 2 secondes
    audioFrame.setTrimFromEnd(2000f);

    // Définit la durée du fondu entrant à 200 ms
    audioFrame.setFadeInDuration(200f);
    // Définit la durée du fondu sortant à 500 ms
    audioFrame.setFadeOutDuration(500f);

    pres.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


L'exemple de code suivant montre comment récupérer un cadre audio avec audio incorporé et définir son volume à 85 % :
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

Aspose.Slides for Java vous permet d'extraire le son utilisé dans les transitions de diaporama. Par exemple, vous pouvez extraire le son utilisé dans une diapositive spécifique.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) et chargez la présentation contenant l'audio.
2. Obtenez la référence de la diapositive concernée via son index.
3. Accédez aux [slideshow transitions](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getSlideShowTransition--) de la diapositive.
4. Extrayez le son sous forme de données binaires.

Ce code Java montre comment extraire l'audio utilisé dans une diapositive :
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

**Puis-je réutiliser le même fichier audio sur plusieurs diapositives sans augmenter la taille du fichier ?**

Oui. Ajoutez l’audio une fois à la [audio collection](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getAudios--) partagée de la présentation et créez des cadres audio supplémentaires qui font référence à cet même actif. Cela évite la duplication des données multimédia et maintient la taille de la présentation sous contrôle.

**Puis-je remplacer le son dans un cadre audio existant sans recréer la forme ?**

Oui. Pour un son lié, mettez à jour le [link path](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) afin qu’il pointe vers le nouveau fichier. Pour un son incorporé, remplacez l’objet [embedded audio](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-) par un autre provenant de la [audio collection](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getAudios--) de la présentation. Le format du cadre et la plupart des paramètres de lecture restent intacts.

**Le rognage modifie-t-il les données audio sous‑jacentes stockées dans la présentation ?**

Non. Le rognage n’ajuste que les limites de lecture. Les octets audio originaux restent intacts et accessibles via l’audio incorporé ou la collection audio de la présentation.