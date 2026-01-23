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
- extraire audio
- PHP
- Aspose.Slides
description: "Créer et contrôler des cadres audio dans Aspose.Slides pour PHP - exemples de code pour intégrer, découper, boucler et configurer la lecture dans les présentations PPT, PPTX et ODP."
---

## **Créer des cadres audio**

Aspose.Slides for PHP via Java vous permet d’ajouter des fichiers audio aux diapositives. Les fichiers audio sont intégrés aux diapositives sous forme de cadres audio.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtenez la référence d’une diapositive via son index.
3. Chargez le flux du fichier audio que vous souhaitez intégrer dans la diapositive.
4. Ajoutez le cadre audio intégré (contenant le fichier audio) à la diapositive.
5. Définissez le [PlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/AudioPlayModePreset) et `Volume` exposés par l’objet [AudioFrame](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/).
6. Enregistrez la présentation modifiée.

Ce code PHP vous montre comment ajouter un cadre audio intégré à une diapositive:
```php
// Instancie une classe Presentation qui représente un fichier de présentation
$pres = new Presentation();
try {
    # Obtient la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Charge le fichier wav en flux
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


## **Modifier la vignette du cadre audio**

Lorsque vous ajoutez un fichier audio à une présentation, l’audio apparaît sous forme d’un cadre avec une image standard par défaut (voir l’image dans la section ci‑dessous). Vous pouvez changer l’image d’aperçu du cadre audio (définissez l’image de votre choix).

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

Aspose.Slides for PHP via Java vous permet de modifier les options qui contrôlent la lecture ou les propriétés d’un audio. Par exemple, vous pouvez ajuster le volume d’un audio, définir la lecture en boucle, ou même masquer l’icône audio.

Le volet **Audio Options** dans Microsoft PowerPoint:
![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** qui correspondent aux propriétés d’[AudioFrame](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/) d’Aspose.Slides:

- **Start** liste déroulante correspond à la méthode [AudioFrame::setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setPlayMode)
- **Volume** correspond à la méthode [AudioFrame::setVolume](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setVolume)
- **Play Across Slides** correspond à la méthode [AudioFrame::setPlayAcrossSlides](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setPlayAcrossSlides)
- **Loop until Stopped** correspond à la méthode [AudioFrame::setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setPlayLoopMode)
- **Hide During Show** correspond à la méthode [AudioFrame::setHideAtShowing](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setHideAtShowing)
- **Rewind after Playing** correspond à la méthode [AudioFrame::setRewindAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setRewindAudio)

Les options **Édition** de PowerPoint qui correspondent aux propriétés d’[AudioFrame](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/) d’Aspose.Slides:

- **Fade In** correspond à la méthode [AudioFrame::setFadeInDuration](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setFadeInDuration)
- **Fade Out** correspond à la méthode [AudioFrame::setFadeOutDuration](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setFadeOutDuration)
- **Trim Audio Start Time** correspond à la méthode [AudioFrame::setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromStart)
- **Trim Audio End Time** la valeur correspond à la durée de l’audio moins la valeur de la méthode [AudioFrame::setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd)

Le **contrôle du volume** de PowerPoint dans le panneau de contrôle audio correspond à la méthode [AudioFrame::setVolumeValue](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setVolumeValue). Il vous permet de modifier le volume audio en pourcentage.

Voici comment modifier les options de lecture audio:

1. [Créer](#create-audio-frame) ou obtenez le cadre audio.
2. Définissez de nouvelles valeurs pour les propriétés du cadre audio que vous souhaitez ajuster.
3. Enregistrez le fichier PowerPoint modifié.

Ce code PHP montre une opération où les options d’un audio sont ajustées:
```php
$pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    # Récupère la forme AudioFrame
    $audioFrame = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Définit le mode de lecture sur lecture au clic
    $audioFrame->setPlayMode(AudioPlayModePreset->OnClick);
    # Définit le volume sur Faible
    $audioFrame->setVolume(AudioVolumeMode->Low);
    # Définit la lecture de l'audio sur toutes les diapositives
    $audioFrame->setPlayAcrossSlides(true);
    # Désactive la lecture en boucle pour l'audio
    $audioFrame->setPlayLoopMode(false);
    # Masque le AudioFrame pendant le diaporama
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


Cet exemple PHP montre comment ajouter un nouveau cadre audio avec audio intégré, le découper et définir les durées de fondu:
```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $audioData = file_get_contents("sampleaudio.mp3");
    $audio = $pres->getAudios()->addAudio($audioData);
    $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audio);

    // Définit le point de début du rognage à 1,5 seconde
    // Définit le point de fin du rognage à 2 secondes
    // Définit la durée du fondu entrant à 200 ms
    // Définit la durée du fondu sortant à 500 ms

    $pres->save("AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
} finally {
    $pres->dispose();
}
```


L’exemple de code suivant montre comment récupérer un cadre audio avec audio intégré et définir son volume à 85 %:
```php
$pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    $slide = $pres->getSlides()->get_Item(0);

    // Récupère la forme AudioFrame
    $audioFrame = $slide->getShapes()->get_Item(0);

    // Définit le volume de l'audio à 85%
    $audioFrame->setVolumeValue(85);

    $pres->save("AudioFrameValue_out.pptx", SaveFormat::Pptx);
}
finally {
    $pres->dispose();
}
```


## **Extraire l’audio**

Aspose.Slides for PHP via Java vous permet d’extraire le son utilisé dans les transitions de diaporama. Par exemple, vous pouvez extraire le son utilisé dans une diapositive spécifique.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) et chargez la présentation contenant l’audio.
2. Obtenez la référence de la diapositive concernée via son index.
3. Accédez aux [slideshow transitions](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getSlideShowTransition) de la diapositive.
4. Extrayez le son sous forme de données binaires.

Ce code vous montre comment extraire l’audio utilisé dans une diapositive:
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

**Puis-je réutiliser le même fichier audio sur plusieurs diapositives sans augmenter la taille du fichier ?**

Oui. Ajoutez l’audio une fois à la [collection audio](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getaudios/) partagée de la présentation et créez des cadres audio supplémentaires qui font référence à cet actif existant. Cela évite la duplication des données multimédias et maintient la taille de la présentation sous contrôle.

**Puis-je remplacer le son d’un cadre audio existant sans recréer la forme ?**

Oui. Pour un son lié, mettez à jour le [link path](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setlinkpathlong/) pour pointer vers le nouveau fichier. Pour un son intégré, remplacez l’objet [embedded audio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setembeddedaudio/) par un autre provenant de la [collection audio](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getaudios/) de la présentation. Le format du cadre et la plupart des réglages de lecture restent intacts.

**Le découpage modifie-t-il les données audio sous‑jacentes stockées dans la présentation ?**

Non. Le découpage ne modifie que les limites de lecture. Les octets audio originaux restent intacts et accessibles via l’audio intégré ou la collection audio de la présentation.