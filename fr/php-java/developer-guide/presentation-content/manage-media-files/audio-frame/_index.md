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
description: "Créer et contrôler les cadres audio dans Aspose.Slides pour PHP — exemples de code pour incorporer, rogner, boucler et configurer la lecture dans les présentations PPT, PPTX et ODP."
---

## **Créer des cadres audio**

Aspose.Slides for PHP via Java vous permet d’ajouter des fichiers audio aux diapositives. Les fichiers audio sont intégrés aux diapositives sous forme de cadres audio.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtenez la référence d’une diapositive via son indice.
3. Chargez le flux du fichier audio que vous souhaitez intégrer dans la diapositive.
4. Ajoutez le cadre audio intégré (contenant le fichier audio) à la diapositive.
5. Définissez [PlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/AudioPlayModePreset) et `Volume` exposés par l’objet [IAudioFrame](https://reference.aspose.com/slides/php-java/aspose.slides/IAudioFrame).
6. Enregistrez la présentation modifiée.

Ce code PHP vous montre comment ajouter un cadre audio intégré à une diapositive :
```php
// Instancie une classe Presentation qui représente un fichier de présentation
$pres = new Presentation();
try {
    # Obtient la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Charge le fichier son wav en flux
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

Lorsque vous ajoutez un fichier audio à une présentation, l’audio apparaît sous forme de cadre avec une image par défaut standard (voir l’image dans la section ci‑dessous). Vous pouvez modifier l’image d’aperçu du cadre audio (définir votre image préférée).

Ce code PHP vous montre comment modifier la vignette ou l’image d’aperçu d’un cadre audio :
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

The **Audio Options** pane in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** that correspond to Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/) properties:

- La liste déroulante **Start** correspond à la méthode [AudioFrame.setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setPlayMode).
- **Volume** correspond à la méthode [AudioFrame.setVolume](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setVolume).
- **Play Across Slides** correspond à la méthode [AudioFrame.setPlayAcrossSlides](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setPlayAcrossSlides).
- **Loop until Stopped** correspond à la méthode [AudioFrame.setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setPlayLoopMode).
- **Hide During Show** correspond à la méthode [AudioFrame.setHideAtShowing](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setHideAtShowing).
- **Rewind after Playing** correspond à la méthode [AudioFrame.setRewindAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setRewindAudio).

PowerPoint **Editing** options that correspond to Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/) properties:

- **Fade In** correspond à la méthode [AudioFrame.setFadeInDuration](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setFadeInDuration).
- **Fade Out** correspond à la méthode [AudioFrame.setFadeOutDuration](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setFadeOutDuration).
- **Trim Audio Start Time** correspond à la méthode [AudioFrame.setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromStart).
- La valeur **Trim Audio End Time** équivaut à la durée de l’audio moins la valeur de la méthode [AudioFrame.setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd).

Le **contrôle du volume** de PowerPoint sur le panneau de contrôle audio correspond à la méthode [AudioFrame.setVolumeValue](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setVolumeValue). Il vous permet de modifier le volume audio en pourcentage.

Voici comment modifier les options de lecture audio :

1. [Créer](#create-audio-frame) ou obtenez le cadre audio.
2. Définissez de nouvelles valeurs pour les propriétés du cadre audio que vous souhaitez ajuster.
3. Enregistrez le fichier PowerPoint modifié.

Ce code PHP montre une opération dans laquelle les options d’un audio sont ajustées :
```php
$pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    # Obtient la forme AudioFrame
    $audioFrame = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # Définit le mode de lecture sur lecture au clic
    $audioFrame->setPlayMode(AudioPlayModePreset->OnClick);
    # Définit le volume à faible
    $audioFrame->setVolume(AudioVolumeMode->Low);
    # Définit l'audio pour qu'il se lise sur plusieurs diapositives
    $audioFrame->setPlayAcrossSlides(true);
    # Désactive la boucle pour l'audio
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


Cet exemple PHP montre comment ajouter un nouveau cadre audio avec audio intégré, le rogner et définir les durées de fondu :
```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $audioData = file_get_contents("sampleaudio.mp3");
    $audio = $pres->getAudios()->addAudio($audioData);
    $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audio);

    // Définit le décalage de début du rognage à 1,5 seconde
    $audioFrame->setTrimFromStart(1500);
    // Définit le décalage de fin du rognage à 2 secondes
    $audioFrame->setTrimFromEnd(2000);

    // Définit la durée du fondu en entrée à 200 ms
    $audioFrame->setFadeInDuration(200);
    // Définit la durée du fondu en sortie à 500 ms
    $audioFrame->setFadeOutDuration(500);

    $pres->save("AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
} finally {
    $pres->dispose();
}
```


L’échantillon de code suivant montre comment récupérer un cadre audio avec audio intégré et régler son volume à 85 % :
```php
$pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    $slide = $pres->getSlides()->get_Item(0);

    // Récupère une forme de cadre audio
    $audioFrame = $slide->getShapes()->get_Item(0);

    // Définit le volume audio à 85%
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
2. Obtenez la référence de la diapositive concernée via son indice.
3. Accédez aux [slideshow transitions](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide#getSlideShowTransition--) de la diapositive.
4. Extrayez le son sous forme de données binaires.

Ce code vous montre comment extraire l’audio utilisé dans une diapositive :
```php
# Instancie une classe Presentation qui représente un fichier de présentation
$pres = new Presentation("AudioSlide.pptx");
$Array = new java_class("java.lang.reflect.Array");
try {
	# Accède à la diapositive souhaitée
	$slide = $pres->getSlides()->get_Item(0);
	# Récupère les effets de transition du diaporama pour la diapositive
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

Oui. Ajoutez l’audio une seule fois à la [audio collection](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getaudios/) partagée de la présentation et créez d’autres cadres audio qui font référence à cet actif existant. Cela évite la duplication des données multimédia et maintient la taille de la présentation sous contrôle.

**Puis-je remplacer le son d’un cadre audio existant sans recréer la forme ?**

Oui. Pour un son lié, mettez à jour le [link path](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setlinkpathlong/) pour qu’il pointe vers le nouveau fichier. Pour un son intégré, remplacez l’objet [embedded audio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setembeddedaudio/) par un autre provenant de la [audio collection](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getaudios/) de la présentation. Le format du cadre et la plupart des paramètres de lecture restent inchangés.

**Le découpage modifie-t-il les données audio sous‑jacentes stockées dans la présentation ?**

Non. Le découpage ne modifie que les limites de lecture. Les octets audio d’origine restent intacts et accessibles via l’audio intégré ou la collection audio de la présentation.