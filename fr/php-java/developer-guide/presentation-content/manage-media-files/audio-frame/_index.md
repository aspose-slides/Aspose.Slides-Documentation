---
title: Gérer les cadres audio dans les présentations avec PHP
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
description: "Incorporez de l’audio dans les diapositives, modifiez l'icône audio, configurez la lecture, gérez les légendes WebVTT et extrayez les sons de transition de diapositives avec Aspose.Slides for PHP via Java."
---
## **Vue d'ensemble**

Un cadre audio vous permet de lire un son sur une diapositive. Avec Aspose.Slides for PHP via Java, vous pouvez incorporer un clip audio, choisir l’image qui le représente, ajuster la lecture et ajouter des sous‑titres. Vous pouvez également récupérer un son attribué à une transition de diapositive.

## **Créer des cadres audio**

Utilisez [addAudioFrameEmbedded](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addaudioframeembedded/) pour incorporer un clip audio local sur la première diapositive. Les deux premières coordonnées positionnent le cadre sur la diapositive, et les deux valeurs suivantes définissent sa largeur et sa hauteur, le tout en points. Cet exemple appelle [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplaymode/) pour démarrer le clip automatiquement et appelle [setVolume](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setvolume/) pour sélectionner le préréglage fort.

```php
use aspose\slides\AudioPlayModePreset;
use aspose\slides\AudioVolumeMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioStream = new Java("java.io.FileInputStream", "audio.wav");
    try {
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 150, 100, 100, $audioStream);
    } finally {
        $audioStream->close();
    }
    $audioFrame->setPlayMode(AudioPlayModePreset::Auto);
    $audioFrame->setVolume(AudioVolumeMode::Loud);

    $presentation->save("AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Modifier la vignette du cadre audio**

Par défaut, un cadre audio affiche une icône de haut‑parleur. Pour afficher une vignette personnalisée, ajoutez une image à la présentation avec [addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/addimage/) et affectez‑la à l’image du cadre avec [setImage](https://reference.aspose.com/slides/php-java/aspose.slides/picture/setimage/). L’exemple utilise un JPEG comme vignette pour un clip audio incorporé.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioStream = new Java("java.io.FileInputStream", "audio.wav");
    try {
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(150, 100, 50, 50, $audioStream);
    } finally {
        $audioStream->close();
    }

    $imageStream = new Java("java.io.FileInputStream", "eagle.jpeg");
    try {
        $thumbnail = $presentation->getImages()->addImage($imageStream);
    } finally {
        $imageStream->close();
    }
    $audioFrame->getPictureFormat()->getPicture()->setImage($thumbnail);

    $presentation->save("example_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Modifier les options de lecture audio**

Les contrôles **Audio Options** de PowerPoint déterminent quand un clip démarre, à quel volume il joue et comment il se comporte pendant le diaporama.

![Contrôles des options audio de PowerPoint pour un cadre audio](audio_frame_0.png)

| Contrôle PowerPoint | Méthode Aspose.Slides for PHP via Java |
| --- | --- |
| Start | [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplaymode/) |
| Volume preset | [setVolume](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setvolume/) |
| Play Across Slides | [setPlayAcrossSlides](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplayacrossslides/) |
| Loop until Stopped | [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplayloopmode/) |
| Hide During Show | [setHideAtShowing](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/sethideatshowing/) |
| Rewind after Playing | [setRewindAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setrewindaudio/) |
| Fade In | [setFadeInDuration](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setFadeInDuration) |
| Fade Out | [setFadeOutDuration](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setFadeOutDuration) |
| Trim Audio start time | [setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromStart) |
| Trim Audio end time | [setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd) |
| Volume slider | [setVolumeValue](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setVolumeValue) |

L’exemple trouve le premier cadre audio sur la première diapositive, appelle [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplaymode/) pour démarrer la lecture au clic, et sélectionne le préréglage de faible volume. Le clip se poursuit d’une diapositive à l’autre avec la boucle désactivée. L’icône reste masquée pendant le diaporama, et le clip est rembobiné après la lecture.

```php
use aspose\slides\AudioPlayModePreset;
use aspose\slides\AudioVolumeMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("AudioFrameEmbed_out.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioFrameType = new JavaClass("com.aspose.slides.AudioFrame");
    $audioFrame = null;
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($i = 0; $i < $shapeCount; $i++) {
        $shape = $shapes->get_Item($i);
        if (java_instanceof($shape, $audioFrameType)) {
            $audioFrame = $shape;
            break;
        }
    }

    if ($audioFrame !== null) {
        $audioFrame->setPlayAcrossSlides(true);
        $audioFrame->setPlayLoopMode(false);
        $audioFrame->setPlayMode(AudioPlayModePreset::OnClick);
        $audioFrame->setVolume(AudioVolumeMode::Low);
        $audioFrame->setHideAtShowing(true);
        $audioFrame->setRewindAudio(true);

        $presentation->save("AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
    } else {
        echo "The first slide has no audio frame.\n";
    }
} finally {
    $presentation->dispose();
}
```

Pour un clip de plus de 3,5 secondes, cet exemple saute les 1,5 premières secondes et les 2 dernières secondes. [setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd) indique la durée à omettre à la fin du clip. Pour obtenir le temps de fin affiché dans PowerPoint, soustrayez ce décalage de la durée totale du clip. Le clip découpé fait un fondu d’entrée de 200 ms et un fondu de sortie de 500 ms. Les quatre méthodes acceptent des valeurs en millisecondes.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioStream = new Java("java.io.FileInputStream", "audio.wav");
    try {
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audioStream);
    } finally {
        $audioStream->close();
    }
    $audioFrame->setTrimFromStart(1500);
    $audioFrame->setTrimFromEnd(2000);
    $audioFrame->setFadeInDuration(200);
    $audioFrame->setFadeOutDuration(500);

    $presentation->save("AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Pour définir le volume de lecture à un pourcentage précis, utilisez [setVolumeValue](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setVolumeValue). Cet exemple fixe le volume du premier cadre audio sur la première diapositive à 85 %.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("AudioFrameEmbed_out.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioFrameType = new JavaClass("com.aspose.slides.AudioFrame");
    $audioFrame = null;
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($i = 0; $i < $shapeCount; $i++) {
        $shape = $shapes->get_Item($i);
        if (java_instanceof($shape, $audioFrameType)) {
            $audioFrame = $shape;
            break;
        }
    }

    if ($audioFrame !== null) {
        $audioFrame->setVolumeValue(85);
        $presentation->save("AudioFrameValue_out.pptx", SaveFormat::Pptx);
    } else {
        echo "The first slide has no audio frame.\n";
    }
} finally {
    $presentation->dispose();
}
```

## **Gérer les légendes audio**

Chaque cadre audio donne accès à ses pistes de légendes via [getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#getCaptionTracks). Utilisez la collection pour ajouter des légendes WebVTT au clip, exporter les pistes existantes ou les supprimer.

### **Ajouter des légendes audio**

L’exemple incorpore un clip audio sur la première diapositive et utilise [add](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#add) pour attacher une piste WebVTT locale. Le premier argument fournit l’étiquette de la piste, et le second identifie le fichier contenant les légendes synchronisées.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioStream = new Java("java.io.FileInputStream", "audio.wav");
    try {
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(10, 10, 50, 50, $audioStream);
    } finally {
        $audioStream->close();
    }
    $audioFrame->getCaptionTracks()->add("English", "track.vtt");

    $presentation->save("audio_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Extraire les légendes audio**

Cet exemple exporte chaque piste de légende attachée à un cadre audio sur la première diapositive. Il écrit les octets renvoyés par [getBinaryData](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getBinaryData) dans un fichier WebVTT et utilise l’identifiant renvoyé par [getCaptionId](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getCaptionId) comme nom de fichier afin que chaque piste dispose d’une sortie séparée.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioFrameType = new JavaClass("com.aspose.slides.AudioFrame");
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($i = 0; $i < $shapeCount; $i++) {
        $shape = $shapes->get_Item($i);
        if (!java_instanceof($shape, $audioFrameType)) {
            continue;
        }
        $tracks = $shape->getCaptionTracks();
        $trackCount = java_values($tracks->getCount());
        for ($j = 0; $j < $trackCount; $j++) {
            $track = $tracks->get_Item($j);
            $fileName = $track->getCaptionId() . ".vtt";
            $audioCaptions = $track->getBinaryData();
            $output = new Java("java.io.FileOutputStream", $fileName);
            try {
                $output->write($audioCaptions);
            } finally {
                $output->close();
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

### **Supprimer les légendes audio**

Utilisez [remove](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#remove) ou [removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#removeAt) pour supprimer une piste individuelle. L’exemple utilise [clear](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#clear) pour enlever toutes les légendes du premier cadre audio sur la première diapositive tout en conservant le clip.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioFrameType = new JavaClass("com.aspose.slides.AudioFrame");
    $audioFrame = null;
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($i = 0; $i < $shapeCount; $i++) {
        $shape = $shapes->get_Item($i);
        if (java_instanceof($shape, $audioFrameType)) {
            $audioFrame = $shape;
            break;
        }
    }

    if ($audioFrame !== null) {
        $audioFrame->getCaptionTracks()->clear();
        $presentation->save("audio_without_captions.pptx", SaveFormat::Pptx);
    } else {
        echo "The first slide has no audio frame.\n";
    }
} finally {
    $presentation->dispose();
}
```

### **Trouver une ligne dans les légendes audio**

Pour trouver une ligne dans les légendes audio de la première diapositive, recherchez le texte renvoyé par [getDataAsString](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getDataAsString) en mémoire. Dans une indication WebVTT en texte brut, la ligne de synchronisation contient `-->`, les lignes de légende la suivent, et une ligne vide termine l’indication. Cet exemple affiche l’étiquette de la piste et chaque ligne de légende contenant « café ».

```php
use aspose\slides\Presentation;

$presentation = new Presentation("audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioFrameType = new JavaClass("com.aspose.slides.AudioFrame");
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($i = 0; $i < $shapeCount; $i++) {
        $shape = $shapes->get_Item($i);
        if (!java_instanceof($shape, $audioFrameType)) {
            continue;
        }
        $tracks = $shape->getCaptionTracks();
        $trackCount = java_values($tracks->getCount());
        for ($j = 0; $j < $trackCount; $j++) {
            $track = $tracks->get_Item($j);
            $inCue = false;
            $captions = (string) $track->getDataAsString();
            foreach (preg_split('/\R/u', $captions) as $line) {
                if ($line === "") {
                    $inCue = false;
                } elseif (strpos($line, "-->") !== false) {
                    $inCue = true;
                } elseif ($inCue && preg_match('/café/iu', $line)) {
                    echo $track->getLabel() . ": " . $line . "\n";
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Extraire l'audio**

Une transition de diapositive peut avoir son propre son. Pour le récupérer, appelez [getSound](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/getsound/) sur la transition de diapositive. L’exemple accède aux octets renvoyés par [getBinaryData](https://reference.aspose.com/slides/php-java/aspose.slides/audio/getbinarydata/) et affiche le nombre d’octets. Si la première diapositive n’a pas de son de transition, il affiche un message à la place.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("AudioSlide.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $sound = $slide->getSlideShowTransition()->getSound();
    if (java_is_null($sound)) {
        echo "The first slide has no transition sound.\n";
    } else {
        $audioData = $sound->getBinaryData();
        $array = new JavaClass("java.lang.reflect.Array");
        echo "Transition sound: " . $array->getLength($audioData) . " bytes.\n";
    }
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Puis-je réutiliser le même clip audio sur plusieurs diapositives sans le dupliquer ?**

Oui. Ajoutez le clip une fois à la **collection audio** de la présentation ([audio collection](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getaudios/)) et transmettez le même objet audio à [addAudioFrameEmbedded](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addaudioframeembedded/) pour chaque diapositive.

**Puis-je remplacer le son d’un cadre audio existant ?**

Oui. Pour un son lié, utilisez [setLinkPathLong](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setlinkpathlong/) pour pointer vers le fichier de remplacement. Pour un son incorporé, choisissez un autre clip dans la **collection audio** de la présentation avec [setEmbeddedAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setembeddedaudio/). Les deux approches conservent le cadre existant.

**Le rognage modifie-t-il les données audio stockées dans la présentation ?**

Non. [setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromStart) et [setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd) définissent les limites de lecture. Vous pouvez toujours récupérer le clip complet avec [getEmbeddedAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/getembeddedaudio/).