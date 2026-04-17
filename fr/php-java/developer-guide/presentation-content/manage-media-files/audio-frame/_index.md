---
title: Gérer l'audio dans les présentations avec PHP
linktitle: Cadre audio
type: docs
weight: 10
url: /fr/php-java/audio-frame/
keywords:
- audio
- cadre audio
- vignette
- ajouter audio
- propriétés audio
- options audio
- extraire l'audio
- PHP
- Aspose.Slides
description: "Créer et contrôler des cadres audio dans Aspose.Slides pour PHP — exemples de code pour intégrer, couper, mettre en boucle et configurer la lecture dans les présentations PPT, PPTX et ODP."
---
## **Créer des frames audio**

Aspose.Slides for PHP via Java vous permet d’ajouter des fichiers audio aux diapositives. Les fichiers audio sont intégrés aux diapositives sous forme de frames audio.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/Presentation).
2. Obtenez la référence d’une diapositive via son index.
3. Chargez le flux du fichier audio que vous souhaitez incorporer dans la diapositive.
4. Ajoutez le frame audio intégré (contenant le fichier audio) à la diapositive.
5. Définissez le [PlayMode](https://reference.aspose.com/slides/fr/php-java/aspose.slides/AudioPlayModePreset) et la `Volume` exposés par l’objet [AudioFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/audioframe/).
6. Enregistrez la présentation modifiée.

Ce code PHP vous montre comment ajouter un frame audio intégré à une diapositive :

```php
// Instancie une classe Presentation qui représente un fichier de présentation
$pres = new Presentation();
try {
    # Récupère la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Charge le fichier audio wav en flux
    $fstr = new Java("java.io.FileInputStream", new Java("java.io.File", "audio.wav"));
    # Ajoute le cadre audio
    $audioFrame = $sld->getShapes()->addAudioFrameEmbedded(50, 150, 100, 100, $fstr);
    $fstr->close();
    # Définit le mode de lecture et le volume de l'audio
    $audioFrame->setPlayMode(AudioPlayModePreset->Auto);
    $audioFrame->setVolume(AudioVolumeMode->Loud);
    # Écrit le fichier PowerPoint sur le disque
    $pres->save("AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
} catch(JavaException e) {
} finally {
    if (!java_is_null($pres)) $pres.dispose();
}
```

## **Modifier la vignette du frame audio**

Lorsque vous ajoutez un fichier audio à une présentation, l’audio apparaît sous forme de frame avec une image par défaut standard (voir l’image dans la section ci‑dessous). Vous pouvez modifier l’image d’aperçu du frame audio (définir votre image préférée).

Ce code PHP vous montre comment modifier la vignette ou l’image d’aperçu d’un frame audio :

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

## **Modifier les options de lecture audio**

Aspose.Slides for PHP via Java vous permet de modifier les options qui contrôlent la lecture ou les propriétés d’un audio. Par exemple, vous pouvez ajuster le volume, définir la lecture en boucle ou même masquer l’icône audio.

Le volet **Audio Options** dans Microsoft PowerPoint :

![example1_image](audio_frame_0.png)

Les **Audio Options** de PowerPoint correspondant aux propriétés Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/audioframe/) :

- **Start** correspond à la méthode [AudioFrame::setPlayMode](https://reference.aspose.com/slides/fr/php-java/aspose.slides/audioframe/#setPlayMode)
- **Volume** correspond à la méthode [AudioFrame::setVolume](https://reference.aspose.com/slides/fr/php-java/aspose.slides/audioframe/#setVolume)
- **Play Across Slides** correspond à la méthode [AudioFrame::setPlayAcrossSlides](https://reference.aspose.com/slides/fr/php-java/aspose.slides/audioframe/#setPlayAcrossSlides)
- **Loop until Stopped** correspond à la méthode [AudioFrame::setPlayLoopMode](https://reference.aspose.com/slides/fr/php-java/aspose.slides/audioframe/#setPlayLoopMode)
- **Hide During Show** correspond à la méthode [AudioFrame::setHideAtShowing](https://reference.aspose.com/slides/fr/php-java/aspose.slides/audioframe/#setHideAtShowing)
- **Rewind after Playing** correspond à la méthode [AudioFrame::setRewindAudio](https://reference.aspose.com/slides/fr/php-java/aspose.slides/audioframe/#setRewindAudio)

Les options **Editing** de PowerPoint correspondant aux propriétés Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/audioframe/) :

- **Fade In** correspond à la méthode [AudioFrame::setFadeInDuration](https://reference.aspose.com/slides/fr/php-java/aspose.slides/audioframe/#setFadeInDuration)
- **Fade Out** correspond à la méthode [AudioFrame::setFadeOutDuration](https://reference.aspose.com/slides/fr/php-java/aspose.slides/audioframe/#setFadeOutDuration)
- **Trim Audio Start Time** correspond à la méthode [AudioFrame::setTrimFromStart](https://reference.aspose.com/slides/fr/php-java/aspose.slides/audioframe/#setTrimFromStart)
- **Trim Audio End Time** correspond à la durée audio moins la valeur de la méthode [AudioFrame::setTrimFromEnd](https://reference.aspose.com/slides/fr/php-java/aspose.slides/audioframe/#setTrimFromEnd)

Le **contrôle du volume** de PowerPoint sur le panneau de commande audio correspond à la méthode [AudioFrame::setVolumeValue](https://reference.aspose.com/slides/fr/php-java/aspose.slides/audioframe/#setVolumeValue). Il vous permet de modifier le volume audio en pourcentage.

Voici comment modifier les options de lecture audio :

1. [Сreate](#create-audio-frame) ou récupérez le frame audio.
2. Définissez de nouvelles valeurs pour les propriétés du frame audio que vous souhaitez ajuster.
3. Enregistrez le fichier PowerPoint modifié.

Ce code PHP montre une opération où les options d’un audio sont ajustées :

```php
$pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    # Obtient la forme AudioFrame
    $audioFrame = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Définit le mode de lecture sur lecture au clic
    $audioFrame->setPlayMode(AudioPlayModePreset->OnClick);
    # Définit le volume sur Bas
    $audioFrame->setVolume(AudioVolumeMode->Low);
    # Définit l'audio pour lire sur toutes les diapositives
    $audioFrame->setPlayAcrossSlides(true);
    # Désactive la lecture en boucle pour l'audio
    $audioFrame->setPlayLoopMode(false);
    # Masque le cadre audio pendant le diaporama
    $audioFrame->setHideAtShowing(true);
    # Rembobine l'audio au départ après la lecture
    $audioFrame->setRewindAudio(true);
    # Enregistre le fichier PowerPoint sur le disque
    $pres->save("AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
} finally {
	if (!java_is_null($pres)) {
		$pres->dispose();
	}
}
```

Cet exemple PHP montre comment ajouter un nouveau frame audio avec audio intégré, le couper et définir les durées de fondu :

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $audioData = file_get_contents("sampleaudio.mp3");
    $audio = $pres->getAudios()->addAudio($audioData);
    $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audio);

    // Définit le décalage de début du découpage à 1,5 seconde
    $audioFrame->setTrimFromStart(1500);
    // Définit le décalage de fin du découpage à 2 secondes
    $audioFrame->setTrimFromEnd(2000);

    // Définit la durée du fondu d'entrée à 200 ms
    $audioFrame->setFadeInDuration(200);
    // Définit la durée du fondu de sortie à 500 ms
    $audioFrame->setFadeOutDuration(500);

    $pres->save("AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
} finally {
    $pres->dispose();
}
```

L’extrait de code suivant montre comment récupérer un frame audio intégré et régler son volume à 85 % :

```php
$pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    $slide = $pres->getSlides()->get_Item(0);

    // Obtient la forme du cadre audio
    $audioFrame = $slide->getShapes()->get_Item(0);

    // Définit le volume audio à 85%
    $audioFrame->setVolumeValue(85);

    $pres->save("AudioFrameValue_out.pptx", SaveFormat::Pptx);
}
finally {
    $pres->dispose();
}
```

## **Gérer les sous‑titres audio**

Aspose.Slides vous permet d’ajouter des sous‑titres fermés à un frame audio via la méthode [getCaptionTracks](https://reference.aspose.com/slides/fr/php-java/aspose.slides/audioframe/#getCaptionTracks). Cette méthode renvoie une [CaptionsCollection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/captionscollection/), qui vous permet d’ajouter des pistes de sous‑titres WebVTT, de parcourir les pistes existantes et de les supprimer si nécessaire.

**Ajouter des sous‑titres audio**

Utilisez la méthode [getCaptionTracks](https://reference.aspose.com/slides/fr/php-java/aspose.slides/audioframe/#getCaptionTracks) pour attacher une ou plusieurs pistes de sous‑titres à un frame audio. Dans l’exemple suivant, un fichier audio est ajouté à une diapositive, puis une nouvelle piste de sous‑titres est chargée à partir d’un fichier `.vtt`.

```php
$presentation = new Presentation();
try {
    $audioData = file_get_contents("audio.mp3");
    $audio = $presentation->getAudios()->addAudio($audioData);

    $slide = $presentation->getSlides()->get_Item(0);
    $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(10, 10, 50, 50, $audio);

    // Ajouter une nouvelle piste de sous‑titres à partir d'un fichier WebVTT.
    $audioFrame->getCaptionTracks()->add("New track", "track.vtt");

    $presentation->save("audio_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**Extraire les sous‑titres audio**

Vous pouvez parcourir les pistes de sous‑titres associées à un frame audio et les enregistrer en fichiers `.vtt`. Chaque piste de sous‑titres expose ses données binaires et son identifiant unique, utilisables lors de l’exportation des sous‑titres.

```php
$presentation = new Presentation("audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AudioFrame"))) {
            $audioFrame = $shape;
            $trackCount = java_values($audioFrame->getCaptionTracks()->getCount());
            for ($trackIndex = 0; $trackIndex < $trackCount; $trackIndex++) {
                $captionTrack = $audioFrame->getCaptionTracks()->get_Item($trackIndex);
                // Enregistrer chaque piste de sous‑titres en tant que fichier .vtt.
                $filePath = $captionTrack->getCaptionId() . ".vtt";
                file_put_contents($filePath, $captionTrack->getBinaryData());
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

**Supprimer les sous‑titres audio**

Pour supprimer les sous‑titres d’un frame audio, utilisez les méthodes fournies par [CaptionsCollection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/captionscollection/), telles que [clear](https://reference.aspose.com/slides/fr/php-java/aspose.slides/captionscollection/#clear), [remove](https://reference.aspose.com/slides/fr/php-java/aspose.slides/captionscollection/#remove) ou [removeAt](https://reference.aspose.com/slides/fr/php-java/aspose.slides/captionscollection/#removeAt). L’exemple suivant supprime toutes les pistes de sous‑titres d’un frame audio.

```php
$presentation = new Presentation($folderPath . "audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $audioFrame = $slide->getShapes()->get_Item(0); // type : AudioFrame

    // Supprime toutes les pistes de sous‑titres du cadre audio.
    $audioFrame->getCaptionTracks()->clear();

    $presentation->save($folderPath . "audio_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Extraire l’audio**

Aspose.Slides for PHP via Java vous permet d’extraire le son utilisé dans les transitions du diaporama. Par exemple, vous pouvez extraire le son d’une diapositive spécifique.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/Presentation) et chargez la présentation contenant l’audio.
2. Obtenez la référence de la diapositive concernée via son index.
3. Accédez aux [transitions du diaporama](https://reference.aspose.com/slides/fr/php-java/aspose.slides/baseslide/#getSlideShowTransition) de la diapositive.
4. Extrayez le son sous forme de données octetées.

Ce code montre comment extraire l’audio utilisé dans une diapositive :

```php
# Instancie une classe Presentation qui représente un fichier de présentation
$pres = new Presentation("AudioSlide.pptx");
$Array = new java_class("java.lang.reflect.Array");
try {
	# Accède à la diapositive souhaitée
	$slide = $pres->getSlides()->get_Item(0);
	# Obtient les effets de transition du diaporama pour la diapositive
	$transition = $slide->getSlideShowTransition();
	# Extrait le son sous forme de tableau d'octets
	$audio = $transition->getSound()->getBinaryData();
	echo("Length: " . $Array->getLength($audio));
} finally {
	if (!java_is_null($pres)) {
		$pres->dispose();
	}
}
```

## **FAQ**

**Puis‑je réutiliser le même fichier audio sur plusieurs diapositives sans augmenter la taille du fichier ?**

Oui. Ajoutez l’audio une fois à la [collection audio partagée](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/getaudios/) de la présentation et créez des frames audio supplémentaires qui référencent cet actif existant. Cela évite la duplication des données multimédia et maintient la taille de la présentation sous contrôle.

**Puis‑je remplacer le son d’un frame audio existant sans recréer la forme ?**

Oui. Pour un son lié, mettez à jour le [link path](https://reference.aspose.com/slides/fr/php-java/aspose.slides/audioframe/setlinkpathlong/) pour qu’il pointe vers le nouveau fichier. Pour un son intégré, remplacez l’objet [embedded audio](https://reference.aspose.com/slides/fr/php-java/aspose.slides/audioframe/setembeddedaudio/) par un autre provenant de la [collection audio](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/getaudios/) de la présentation. Le format du frame et la plupart des paramètres de lecture restent inchangés.

**Le découpage modifie‑t‑il les données audio sous‑jacentes stockées dans la présentation ?**

Non. Le découpage ne fait qu’ajuster les limites de lecture. Les octets audio originaux restent intacts et accessibles via l’audio intégré ou la collection audio de la présentation.