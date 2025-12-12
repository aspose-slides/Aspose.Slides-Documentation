---
title: "Gérer l'audio dans les présentations sur Android"
linktitle: "Cadre audio"
type: docs
weight: 10
url: /fr/androidjava/audio-frame/
keywords:
- "audio"
- "cadre audio"
- "miniature"
- "ajouter de l'audio"
- "propriétés audio"
- "options audio"
- "extraire l'audio"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Créer et contrôler des cadres audio dans Aspose.Slides pour Android—exemples Java pour incorporer, couper, boucler et configurer la lecture dans les présentations PPT, PPTX et ODP."
---

## **Créer des cadres audio**
Aspose.Slides for Android via Java vous permettre d'ajouter des fichiers audio aux diapositives. Les fichiers audio sont incorporés dans les diapositives sous forme de cadres audio.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Obtenez la référence d'une diapositive via son indice.
3. Chargez le flux du fichier audio que vous souhaitez incorporer dans la diapositive.
4. Ajoutez le cadre audio incorporé (contenant le fichier audio) à la diapositive.
5. Définissez le [PlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioPlayModePreset) et `Volume` exposés par l'objet [IAudioFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAudioFrame).
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


## **Modifier la miniature du cadre audio**
Lorsque vous ajoutez un fichier audio à une présentation, l'audio apparaît sous forme d'un cadre avec une image par défaut standard (voir l'image dans la section ci-dessous). Vous pouvez modifier l'image d'aperçu du cadre audio (définissez votre image préférée).

Ce code Java vous montre comment changer la miniature ou l'image d'aperçu d'un cadre audio :
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
Aspose.Slides for Android via Java vous permettre de modifier les options qui contrôlent la lecture ou les propriétés d'un audio. Par exemple, vous pouvez ajuster le volume d'un audio, définir la lecture en boucle, ou même masquer l'icône audio.

Le volet **Options audio** dans Microsoft PowerPoint :
![example1_image](audio_frame_0.png)

Les **Options audio** de PowerPoint qui correspondent aux propriétés d'[AudioFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame) d'Aspose.Slides :
- **Start** la liste déroulante correspond à la propriété [AudioFrame.PlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getPlayMode--) .
- **Volume** correspond à la propriété [AudioFrame.Volume](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getVolume--) .
- **Play Across Slides** correspond à la propriété [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getPlayAcrossSlides--) .
- **Loop until Stopped** correspond à la propriété [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getPlayLoopMode--) .
- **Hide During Show** correspond à la propriété [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getHideAtShowing--) .
- **Rewind after Playing** correspond à la propriété [AudioFrame.RewindAudio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getRewindAudio--) .

Les options **Édition** de PowerPoint qui correspondent aux propriétés d'[AudioFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/audioframe/) d'Aspose.Slides :
- **Fade In** correspond à la propriété [AudioFrame.FadeInDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/audioframe/#getFadeInDuration--) .
- **Fade Out** correspond à la propriété [AudioFrame.FadeOutDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/audioframe/#getFadeOutDuration--) .
- **Trim Audio Start Time** correspond à la propriété [AudioFrame.TrimFromStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/audioframe/#getTrimFromStart--) .
- **Trim Audio End Time** la valeur est égale à la durée de l'audio moins la valeur de la propriété [AudioFrame.TrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/audioframe/#getTrimFromEnd--) .

Le **contrôle du volume** de PowerPoint sur le panneau de contrôle audio correspond à la propriété [AudioFrame.VolumeValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/audioframe/#getVolumeValue--) . Il vous permettre de modifier le volume audio en pourcentage.

Voici comment modifier les options de lecture audio :
1. [Créer](#create-audio-frame) ou obtenir le cadre audio.
2. Définissez de nouvelles valeurs pour les propriétés du cadre audio que vous souhaitez ajuster.
3. Enregistrez le fichier PowerPoint modifié.

Ce code Java démontre une opération dans laquelle les options d'un audio sont ajustées :
```java 
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // Récupère la forme AudioFrame
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // Définit le mode de lecture sur lecture au clic
    audioFrame.setPlayMode(AudioPlayModePreset.OnClick);

    // Définit le volume sur Bas
    audioFrame.setVolume(AudioVolumeMode.Low);

    // Définit la lecture audio sur toutes les diapositives
    audioFrame.setPlayAcrossSlides(true);

    // Désactive la boucle pour l'audio
    audioFrame.setPlayLoopMode(false);

    // Masque le AudioFrame pendant le diaporama
    audioFrame.setHideAtShowing(true);

    // Rembobine l'audio au début après lecture
    audioFrame.setRewindAudio(true);

    // Enregistre le fichier PowerPoint sur le disque
    pres.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


Cet exemple Java montre comment ajouter un nouveau cadre audio avec audio incorporé, le couper, et définir les durées d'estompage :
```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    FileInputStream audioData = new FileInputStream("sampleaudio.mp3");
    IAudio audio = pres.getAudios().addAudio(audioData, LoadingStreamBehavior.KeepLocked);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Définit le décalage de début du découpage à 1,5 seconde
    // Définit le décalage de fin du découpage à 2 secondes
    // Définit la durée de fondu entrant à 200 ms
    // Définit la durée de fondu sortant à 500 ms

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


## **Extraire l'audio**
Aspose.Slides for Android via Java vous permettre d'extraire le son utilisé dans les transitions de diaporama. Par exemple, vous pouvez extraire le son utilisé dans une diapositive spécifique.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) et chargez la présentation contenant l'audio.
2. Obtenez la référence de la diapositive concernée via son indice.
3. Accédez aux [transitions du diaporama](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#getSlideShowTransition--) de la diapositive.
4. Extrayez le son sous forme de données octet.

Ce code Java vous montre comment extraire l'audio utilisé dans une diapositive :
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

Oui. Ajoutez l'audio une seule fois à la [collection audio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getAudios--) partagée de la présentation et créez des cadres audio supplémentaires qui font référence à cet actif existant. Cela évite de dupliquer les données multimédia et maintient la taille de la présentation sous contrôle.

**Puis-je remplacer le son d'un cadre audio existant sans recréer la forme ?**

Oui. Pour un son lié, mettez à jour le [chemin du lien](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) pour pointer vers le nouveau fichier. Pour un son incorporé, remplacez l'objet [audio incorporé](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-) par un autre provenant de la [collection audio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getAudios--) de la présentation. Le format du cadre et la plupart des paramètres de lecture restent intacts.

**Le découpage modifie-t-il les données audio sous‑jacent stockées dans la présentation ?**

Non. Le découpage n'ajuste que les limites de lecture. Les octets audio originaux restent intacts et accessibles via l'audio incorporé ou la collection audio de la présentation.