---
title: Cadre Audio
type: docs
weight: 10
url: /fr/java/audio-frame/
keywords: "Ajouter audio, Cadre audio, Propriétés audio, Extraire audio, Java, Aspose.Slides pour Java"
description: "Ajouter de l'audio à une présentation PowerPoint en Java"
---

## **Créer un Cadre Audio**
Aspose.Slides pour Java vous permet d'ajouter des fichiers audio à des diapositives. Les fichiers audio sont intégrés dans les diapositives sous forme de cadres audio.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Obtenez la référence d'une diapositive par son index.
3. Chargez le flux du fichier audio que vous souhaitez intégrer dans la diapositive.
4. Ajoutez le cadre audio intégré (contenant le fichier audio) à la diapositive.
5. Définissez [PlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/AudioPlayModePreset) et `Volume` exposés par l'objet [IAudioFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAudioFrame).
6. Enregistrez la présentation modifiée.

Ce code Java vous montre comment ajouter un cadre audio intégré à une diapositive :

```Java
// Instancie une classe Presentation qui représente un fichier de présentation
Presentation pres = new Presentation();
try {
    // Obtient la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);

    // Charge le fichier audio wav dans un flux
    FileInputStream fstr = new FileInputStream(new File("audio.wav"));

    // Ajoute le Cadre Audio
    IAudioFrame audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    
    // Définit le Mode de Lecture et le Volume de l'Audio
    audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    audioFrame.setVolume(AudioVolumeMode.Loud);

    // Écrit le fichier PowerPoint sur le disque
    pres.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Changer la Miniature du Cadre Audio**

Lorsque vous ajoutez un fichier audio à une présentation, l'audio apparaît comme un cadre avec une image par défaut standard (voir l'image dans la section ci-dessous). Vous changez l'image d'aperçu du cadre audio (définissez votre image préférée).

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

    // Définit l'image pour le cadre audio.
    audioFrame.getPictureFormat().getPicture().setImage(picture); // <-----

    // Enregistre la présentation modifiée sur le disque
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Changer les Options de Lecture Audio**

Aspose.Slides pour Java vous permet de changer les options qui contrôlent la lecture audio ou les propriétés. Par exemple, vous pouvez ajuster le volume d'un audio, définir l'audio pour qu'il soit lu en boucle, ou même cacher l'icône audio.

Le panneau **Options Audio** dans Microsoft PowerPoint :

![example1_image](audio_frame_0.png)

Les options audio de PowerPoint qui correspondent aux propriétés [AudioFrame](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame) de Aspose.Slides :
- La liste déroulante **Démarrer** des Options Audio correspond à la propriété [AudioFrame.PlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame#getPlayMode--) 
- Les **Volume** des Options Audio correspondent à la propriété [AudioFrame.Volume](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame#getVolume--)
- Les options **Jouer à travers les diapositives** correspondent à la propriété [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame#getPlayAcrossSlides--)
- Les options **Boucle jusqu'à arrêt** correspondent à la propriété [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame#getPlayLoopMode--)
- Les options **Masquer pendant la présentation** correspondent à la propriété [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame#getHideAtShowing--)
- Les options **Rembobiner après lecture** correspondent à la propriété [AudioFrame.RewindAudio](https://reference.aspose.com/slides/java/com.aspose.slides/AudioFrame#getRewindAudio--)

Voici comment vous changez les options de lecture audio :

1. [Créer](#create-audio-frame) ou obtenir le Cadre Audio.
2. Définissez de nouvelles valeurs pour les propriétés du Cadre Audio que vous souhaitez ajuster.
3. Enregistrez le fichier PowerPoint modifié.

Ce code Java démontre une opération dans laquelle les options audio sont ajustées :

```java 
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // Obtient la forme AudioFrame
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // Définit le mode de lecture pour jouer au clic
    audioFrame.setPlayMode(AudioPlayModePreset.OnClick);

    // Définit le volume sur Bas
    audioFrame.setVolume(AudioVolumeMode.Low);

    // Définit l'audio pour jouer à travers les diapositives
    audioFrame.setPlayAcrossSlides(true);

    // Désactive la boucle pour l'audio
    audioFrame.setPlayLoopMode(false);

    // Cache le Cadre Audio pendant la présentation
    audioFrame.setHideAtShowing(true);

    // Rembobine l'audio pour recommencer après lecture
    audioFrame.setRewindAudio(true);

    // Enregistre le fichier PowerPoint sur le disque
    pres.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Extraire l'Audio**

Aspose.Slides pour Java vous permet d'extraire le son utilisé dans les transitions de diapositive. Par exemple, vous pouvez extraire le son utilisé dans une diapositive spécifique.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) et chargez la présentation avec des transitions de diapositives.
2. Accédez à la diapositive souhaitée.
3. Accédez aux [transitions de diaporama](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getSlideShowTransition--) pour la diapositive.
4. Extrayez le son sous forme de données octets.

Ce code en Java vous montre comment extraire l'audio utilisé dans une diapositive :

```java
// Instancie une classe Presentation qui représente un fichier de présentation
Presentation pres = new Presentation("AudioSlide.pptx");
try {
    // Accède à la diapositive souhaitée
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Obtient les effets de transition de diaporama pour la diapositive
    ISlideShowTransition transition = slide.getSlideShowTransition();
    
    // Extrait le son sous forme de tableau d'octets
    byte[] audio = transition.getSound().getBinaryData();
    System.out.println("Longueur: " + audio.length);
} finally {
    if (pres != null) pres.dispose();
}
```