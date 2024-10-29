---
title: Cadre Audio
type: docs
weight: 10
url: /fr/androidjava/audio-frame/
keywords: "Ajouter de l'audio, Cadre audio, Propriétés audio, Extraire l'audio, Java, Aspose.Slides pour Android via Java"
description: "Ajouter de l'audio à une présentation PowerPoint en Java"
---

## **Créer un Cadre Audio**
Aspose.Slides pour Android via Java vous permet d'ajouter des fichiers audio aux diapositives. Les fichiers audio sont intégrés dans les diapositives sous forme de cadres audio.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Obtenez la référence d'une diapositive via son index.
3. Chargez le flux du fichier audio que vous souhaitez intégrer dans la diapositive.
4. Ajoutez le cadre audio intégré (contenant le fichier audio) à la diapositive.
5. Définissez [PlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioPlayModePreset) et `Volume` exposés par l'objet [IAudioFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAudioFrame).
6. Enregistrez la présentation modifiée.

Ce code Java vous montre comment ajouter un cadre audio intégré à une diapositive :

```Java
// Instancie une classe Presentation qui représente un fichier de présentation
Presentation pres = new Presentation();
try {
    // Obtient la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);

    // Charge le fichier audio wav dans le flux
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

## **Changer la Miniature du Cadre Audio**

Lorsque vous ajoutez un fichier audio à une présentation, l'audio apparaît comme un cadre avec une image par défaut standard (voir l'image dans la section ci-dessous). Vous pouvez changer l'image de prévisualisation du cadre audio (définissez votre image préférée).

Ce code Java vous montre comment changer la miniature ou l'image de prévisualisation d'un cadre audio :

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

Aspose.Slides pour Android via Java vous permet de modifier les options qui contrôlent la lecture d'un audio ou ses propriétés. Par exemple, vous pouvez ajuster le volume d'un audio, définir l'audio pour qu'il soit lu en boucle, ou même cacher l'icône audio.

Le panneau **Options Audio** dans Microsoft PowerPoint :

![example1_image](audio_frame_0.png)

Options audio de PowerPoint qui correspondent aux propriétés [AudioFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame) d'Aspose.Slides :
- La liste déroulante Options Audio **Démarrer** correspond à la propriété [AudioFrame.PlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getPlayMode--) 
- Les Options Audio **Volume** correspondent à la propriété [AudioFrame.Volume](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getVolume--)
- Les Options Audio **Jouer à Travers les Diapositives** correspondent à la propriété [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getPlayAcrossSlides--)
- Les Options Audio **Boucle jusqu'à Arrêt** correspondent à la propriété [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getPlayLoopMode--)
- Les Options Audio **Cacher Pendant la Présentation** correspondent à la propriété [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getHideAtShowing--)
- Les Options Audio **Rewind After Playing** correspondent à la propriété [AudioFrame.RewindAudio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AudioFrame#getRewindAudio--)

Voici comment changer les options de lecture audio :

1. [Créer](#create-audio-frame) ou obtenir le Cadre Audio.
2. Définissez de nouvelles valeurs pour les propriétés du Cadre Audio que vous souhaitez ajuster.
3. Enregistrez le fichier PowerPoint modifié.

Ce code Java démontre une opération dans laquelle les options d'un audio sont ajustées :

```java 
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // Obtient la forme AudioFrame
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // Définit le mode de lecture sur lecture au clic
    audioFrame.setPlayMode(AudioPlayModePreset.OnClick);

    // Définit le volume sur Bas
    audioFrame.setVolume(AudioVolumeMode.Low);

    // Définit l'audio pour jouer à travers les diapositives
    audioFrame.setPlayAcrossSlides(true);

    // Désactive la boucle pour l'audio
    audioFrame.setPlayLoopMode(false);

    // Cache le cadre audio pendant la présentation
    audioFrame.setHideAtShowing(true);

    // Rembobine l'audio pour recommencer après la lecture
    audioFrame.setRewindAudio(true);

    // Enregistre le fichier PowerPoint sur le disque
    pres.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Extraire l'Audio**

Aspose.Slides pour Android via Java vous permet d'extraire le son utilisé dans les transitions de diaporama. Par exemple, vous pouvez extraire le son utilisé dans une diapositive spécifique.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) et chargez la présentation avec des transitions de diapositive.
2. Accédez à la diapositive souhaitée.
3. Accédez aux [transitions de diaporama](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#getSlideShowTransition--) pour la diapositive.
4. Extrayez le son dans des données binaires.

Ce code en Java vous montre comment extraire l'audio utilisé dans une diapositive :

```java
// Instancie une classe Presentation qui représente un fichier de présentation
Presentation pres = new Presentation("AudioSlide.pptx");
try {
    // Accède à la diapositive souhaitée
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Obtient les effets de transition de diaporama pour la diapositive
    ISlideShowTransition transition = slide.getSlideShowTransition();
    
    // Extrait le son dans un tableau de bytes
    byte[] audio = transition.getSound().getBinaryData();
    System.out.println("Longueur : " + audio.length);
} finally {
    if (pres != null) pres.dispose();
}
```