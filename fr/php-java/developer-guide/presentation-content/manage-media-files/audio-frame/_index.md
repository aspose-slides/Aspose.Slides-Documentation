---
title: Cadre Audio
type: docs
weight: 10
url: /fr/php-java/audio-frame/
keywords: "Ajouter de l'audio, Cadre audio, Propriétés audio, Extraire l'audio, Java, Aspose.Slides pour PHP via Java"
description: "Ajouter de l'audio à une présentation PowerPoint"
---

## **Créer un Cadre Audio**
Aspose.Slides pour PHP via Java vous permet d'ajouter des fichiers audio aux diapositives. Les fichiers audio sont intégrés dans les diapositives sous forme de cadres audio.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtenez une référence à la diapositive par son index.
3. Chargez le flux de fichier audio que vous souhaitez intégrer dans la diapositive.
4. Ajoutez le cadre audio intégré (contenant le fichier audio) à la diapositive.
5. Définissez [PlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/AudioPlayModePreset) et `Volume` exposés par l'objet [IAudioFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAudioFrame).
6. Enregistrez la présentation modifiée.

Ce code PHP vous montre comment ajouter un cadre audio intégré à une diapositive :

```php
// Instancie une classe Presentation représentant un fichier de présentation
  $pres = new Presentation();
  try {
    # Obtient la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Charge le fichier audio wav dans le flux
    $fstr = new Java("java.io.FileInputStream", new Java("java.io.File", "audio.wav"));
    # Ajoute le Cadre Audio
    $audioFrame = $sld->getShapes()->addAudioFrameEmbedded(50, 150, 100, 100, $fstr);
    $fstr->close();
    # Définit le Mode de Lecture et le Volume de l'Audio
    $audioFrame->setPlayMode(AudioPlayModePreset->Auto);
    $audioFrame->setVolume(AudioVolumeMode->Loud);
    # Écrit le fichier PowerPoint sur le disque
    $pres->save("AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
} catch(JavaException e) {
} finally {
    if (!java_is_null($pres)) $pres.dispose();
}
```

## **Changer la Miniature du Cadre Audio**

Lorsque vous ajoutez un fichier audio à une présentation, l'audio apparaît sous forme de cadre avec une image par défaut standard (voir l'image dans la section ci-dessous). Vous pouvez changer l'image de prévisualisation du cadre audio (définir votre image préférée).

Ce code PHP vous montre comment changer la miniature ou l'image de prévisualisation d'un cadre audio :

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # Ajoute un cadre audio à la diapositive avec une position et une taille spécifiées.
    $audioStream = new Java("java.io.FileInputStream", "sample2.mp3");
    $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(150, 100, 50, 50, $audioStream);
    $audioStream->close();
    # Ajoute une image aux ressources de la présentation.
    $picture;
    $image = Images->fromFile("eagle.jpeg");
    try {
      $picture = $presentation->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Définit l'image pour le cadre audio.
    $audioFrame->getPictureFormat()->getPicture()->setImage($picture);// <-----

    # Enregistre la présentation modifiée sur le disque
    $presentation->save("example_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Changer les Options de Lecture Audio**

Aspose.Slides pour PHP via Java vous permet de changer les options qui contrôlent la lecture ou les propriétés d'un audio. Par exemple, vous pouvez ajuster le volume d'un audio, définir l'audio pour jouer en boucle, ou même cacher l'icône de l'audio.

Le panneau **Options Audio** dans Microsoft PowerPoint :

![example1_image](audio_frame_0.png)

Les options audio de PowerPoint qui correspondent aux propriétés [AudioFrame](https://reference.aspose.com/slides/php-java/aspose.slides/AudioFrame) de Aspose.Slides :
- La liste déroulante **Démarrer** des Options Audio correspond à la propriété [AudioFrame.PlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/AudioFrame#getPlayMode--) 
- Les **Volume** des Options Audio correspondent à la propriété [AudioFrame.Volume](https://reference.aspose.com/slides/php-java/aspose.slides/AudioFrame#getVolume--) 
- Les **Jouer sur les Diapositives** des Options Audio correspondent à la propriété [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/php-java/aspose.slides/AudioFrame#getPlayAcrossSlides--) 
- Les **Boucle jusqu'à l'Arrêt** des Options Audio correspondent à la propriété [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/AudioFrame#getPlayLoopMode--) 
- Les **Cacher pendant le Spectacle** des Options Audio correspondent à la propriété [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/php-java/aspose.slides/AudioFrame#getHideAtShowing--) 
- Les **Rembobiner après Lecture** des Options Audio correspondent à la propriété [AudioFrame.RewindAudio](https://reference.aspose.com/slides/php-java/aspose.slides/AudioFrame#getRewindAudio--) 

Voici comment changer les options de lecture audio :

1. [Créer](#create-audio-frame) ou obtenir le Cadre Audio.
2. Définissez de nouvelles valeurs pour les propriétés du Cadre Audio que vous souhaitez ajuster.
3. Enregistrez le fichier PowerPoint modifié.

Ce code PHP démontre une opération dans laquelle les options d'un audio sont ajustées :

```php
  $pres = new Presentation("AudioFrameEmbed_out.pptx");
  try {
    # Obtient la forme AudioFrame
    $audioFrame = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Définit le mode de lecture pour jouer au clic
    $audioFrame->setPlayMode(AudioPlayModePreset->OnClick);
    # Définit le volume à Bas
    $audioFrame->setVolume(AudioVolumeMode->Low);
    # Définit l'audio pour jouer sur les diapositives
    $audioFrame->setPlayAcrossSlides(true);
    # Désactive la boucle pour l'audio
    $audioFrame->setPlayLoopMode(false);
    # Cache le Cadre Audio pendant le diaporama
    $audioFrame->setHideAtShowing(true);
    # Rembobine l'audio au début après la lecture
    $audioFrame->setRewindAudio(true);
    # Enregistre le fichier PowerPoint sur le disque
    $pres->save("AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Extraire l'Audio**

Aspose.Slides pour PHP via Java vous permet d'extraire le son utilisé dans les transitions de diaporama. Par exemple, vous pouvez extraire le son utilisé dans une diapositive spécifique.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) et chargez la présentation avec des transitions de diapositives.
2. Accédez à la diapositive souhaitée.
3. Accédez aux [transitions de diaporama](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide#getSlideShowTransition--) pour la diapositive.
4. Extraire le son en données octets.

Ce code vous montre comment extraire l'audio utilisé dans une diapositive :

```php
  # Instancie une classe Presentation représentant un fichier de présentation
  $pres = new Presentation("AudioSlide.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    # Accède à la diapositive souhaitée
    $slide = $pres->getSlides()->get_Item(0);
    # Obtient les effets de transition de diaporama pour la diapositive
    $transition = $slide->getSlideShowTransition();
    # Extrait le son dans un tableau d'octets
    $audio = $transition->getSound()->getBinaryData();
    echo("Longueur : " . $Array->getLength($audio));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```