---
title: Gérer les cadres vidéo dans les présentations avec PHP
linktitle: Cadre vidéo
type: docs
weight: 10
url: /fr/php-java/video-frame/
keywords:
- ajouter vidéo
- créer vidéo
- intégrer vidéo
- extraire vidéo
- récupérer vidéo
- cadre vidéo
- source Web
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Apprenez à ajouter et extraire programmatiquement des cadres vidéo dans les diapositives PowerPoint et OpenDocument en utilisant Aspose.Slides pour PHP via Java. Guide pratique rapide."
---
## **Introduction**

Les vidéos peuvent aider à expliquer des idées et à captiver un public. Aspose.Slides pour PHP via Java vous permet d'ajouter des cadres vidéo aux diapositives, d'ajuster les paramètres de lecture, de gérer les légendes et d'extraire les données vidéo intégrées.

PowerPoint prend en charge les vidéos locales et les liens vers des vidéos en ligne, telles que les vidéos YouTube.

Pour représenter les données vidéo et les cadres vidéo, Aspose.Slides fournit la classe [Video](https://reference.aspose.com/slides/php-java/aspose.slides/video/) , la classe [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) et d'autres types pertinents.

## **Créer un cadre vidéo intégré**

Si le fichier vidéo que vous souhaitez ajouter à votre diapositive est stocké localement, vous pouvez créer un cadre vidéo pour intégrer la vidéo dans votre présentation.

Cet exemple intègre une vidéo locale sur la première diapositive d'une présentation existante et enregistre le résultat. Les coordonnées et dimensions du cadre sont en points. Le flux reste ouvert jusqu'à la fin de l'enregistrement car [LoadingStreamBehavior::KeepLocked](https://reference.aspose.com/slides/php-java/aspose.slides/loadingstreambehavior/) le maintient verrouillé tant que la présentation l'utilise.

```php
use aspose\slides\LoadingStreamBehavior;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
$videoStream = null;
try {
    $videoStream = new Java("java.io.FileInputStream", "video.mp4");
    $slide = $presentation->getSlides()->get_Item(0);

    $video = $presentation->getVideos()->addVideo($videoStream, LoadingStreamBehavior::KeepLocked);
    $slide->getShapes()->addVideoFrame(10, 10, 150, 250, $video);

    $presentation->save("embedded_video.pptx", SaveFormat::Pptx);
} finally {
    if ($videoStream !== null) {
        $videoStream->close();
    }
    $presentation->dispose();
}
```

Vous pouvez également passer un chemin de vidéo locale directement à [addVideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addVideoFrame). Cet exemple intègre la vidéo sur la première diapositive d'une nouvelle présentation. La vidéo doit rester accessible jusqu'à ce que la présentation soit enregistrée.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $slide->getShapes()->addVideoFrame(50, 150, 300, 150, "video.avi");

    $presentation->save("video_from_path.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Créer un cadre vidéo avec une vidéo provenant d'une source Web**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) prend en charge les vidéos en ligne dans les présentations. Vous pouvez créer un cadre vidéo qui pointe vers une vidéo en ligne, comme une vidéo YouTube.

Cet exemple ajoute un lien vidéo YouTube et une miniature à la première diapositive. Remplacez l'identifiant vidéo pour utiliser une autre vidéo. La méthode [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) demande une lecture automatique. Le téléchargement de la miniature et la lecture de la vidéo nécessitent un accès à Internet. Le visualiseur de présentation doit également prendre en charge la lecture de vidéos en ligne.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\VideoPlayModePreset;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoId = "aqz-KE-bpKQ";
    $videoUrl = "https://www.youtube.com/embed/" . $videoId;
    $videoFrame = $slide->getShapes()->addVideoFrame(10, 10, 427, 240, $videoUrl);
    $videoFrame->setPlayMode(VideoPlayModePreset::Auto);

    $thumbnailUrl = "https://img.youtube.com/vi/" . $videoId . "/hqdefault.jpg";
    $thumbnailLocation = new Java("java.net.URL", $thumbnailUrl);
    $thumbnailStream = $thumbnailLocation->openStream();
    try {
        $thumbnail = $presentation->getImages()->addImage($thumbnailStream);
        $videoFrame->getPictureFormat()->getPicture()->setImage($thumbnail);
    } finally {
        $thumbnailStream->close();
    }

    $presentation->save("online_video.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Lire une vidéo en mode plein écran**

Dans une présentation de formation, vous pouvez lire une démonstration logicielle en mode plein écran afin que le public voie les détails. Appelez [setFullScreenMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setFullScreenMode) avec `true` pour activer ce comportement pendant la lecture.

Cet exemple ouvre une présentation, trouve le premier [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) sur la première diapositive et active la lecture en plein écran. La présentation d'entrée doit contenir au moins une diapositive avec un cadre vidéo existant sur la première diapositive.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("training.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $videoFrame->setFullScreenMode(true);
            break;
        }
    }

    $presentation->save("full_screen_video.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

La lecture en plein écran contrôle l'affichage de la vidéo. Indépendamment, [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) détermine si la lecture démarre automatiquement ou au clic, et [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) détermine si elle se répète. Pour choisir le comportement de démarrage, définissez le mode de lecture sur [VideoPlayModePreset::Auto ou VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/php-java/aspose.slides/videoplaymodepreset/). L'exemple conserve les paramètres de démarrage et de boucle existants.

## **Rembobiner une vidéo après la lecture**

Dans une présentation de formation, ramener une vidéo de démonstration au début la rend prête pour que le présentateur la relance. Appelez [setRewindVideo](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setRewindVideo) avec `true` pour ramener la vidéo au début après la fin de la lecture.

Cet exemple ouvre une présentation, trouve le premier [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) sur la première diapositive et active le rembobinage. Il désactive la boucle afin que la lecture puisse se terminer et configure la lecture pour démarrer au clic. La présentation d'entrée doit contenir au moins une diapositive avec un cadre vidéo existant sur la première diapositive.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\VideoPlayModePreset;

$presentation = new Presentation("training.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $videoFrame->setRewindVideo(true);
            $videoFrame->setPlayLoopMode(false);
            $videoFrame->setPlayMode(VideoPlayModePreset::OnClick);
            break;
        }
    }

    $presentation->save("rewind_video.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le rembobinage ramène la vidéo au début sans la relancer. En revanche, appeler [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) avec `true` répète la lecture automatiquement. Gardez la boucle désactivée lorsque vous souhaitez que la vidéo se termine et reste prête pour une nouvelle lecture. [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) contrôle indépendamment le démarrage automatique ou au clic ; cet exemple utilise [VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/php-java/aspose.slides/videoplaymodepreset/) afin que le présentateur contrôle le moment du démarrage. Définissez le mode de lecture après le paramètre de boucle, comme montré dans l'exemple. Le rembobinage fonctionne indépendamment de [setFullScreenMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setFullScreenMode).

## **Rogner un cadre vidéo**

Utilisez [VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setTrimFromStart) et [VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setTrimFromEnd) pour ignorer une partie du début ou de la fin d’une vidéo pendant la lecture. Les deux valeurs sont en millisecondes. Le rognage modifie les paramètres de lecture sans modifier les données vidéo intégrées.

**Définir les paramètres de rognage**

Cet exemple intègre une vidéo locale et saute les 2,5 premières secondes ainsi que la dernière seconde pendant la lecture. Utilisez une vidéo de plus de 3,5 secondes afin qu’un segment lisible reste.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoFile = new Java("java.io.File", "video.mp4");
    $videoPath = $videoFile->toPath();
    $videoData = java("java.nio.file.Files")->readAllBytes($videoPath);
    $video = $presentation->getVideos()->addVideo($videoData);

    $videoFrame = $slide->getShapes()->addVideoFrame(50, 50, 640, 360, $video);
    $videoFrame->setTrimFromStart(2500);
    $videoFrame->setTrimFromEnd(1000);

    $presentation->save("video_with_trim.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**Lire les paramètres de rognage**

Cet exemple affiche les valeurs de rognage du premier cadre vidéo sur la première diapositive en millisecondes. La présentation doit contenir au moins une diapositive. Si cette diapositive ne possède aucun cadre vidéo, rien n’est affiché. L’exemple précédent produit les valeurs 2500 et 1000.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("video_with_trim.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            echo "Trim from start: " . java_values($videoFrame->getTrimFromStart()) . " ms\n";
            echo "Trim from end: " . java_values($videoFrame->getTrimFromEnd()) . " ms\n";
            break;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Gérer les légendes vidéo**

Aspose.Slides vous permet de gérer les sous‑titres fermés pour les cadres vidéo dans les présentations PowerPoint. Les sous‑titres sont enregistrés au format WebVTT et sont accessibles via la méthode [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#getCaptionTracks).

**Ajouter des légendes à un cadre vidéo**

Cet exemple intègre une vidéo locale et ajoute une piste de légende WebVTT intitulée English. Les horodatages des légendes doivent correspondre à la vidéo. La présentation enregistrée inclut à la fois la vidéo et ses légendes.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoFile = new Java("java.io.File", "video.mp4");
    $videoPath = $videoFile->toPath();
    $videoData = java("java.nio.file.Files")->readAllBytes($videoPath);
    $video = $presentation->getVideos()->addVideo($videoData);

    $videoFrame = $slide->getShapes()->addVideoFrame(0, 0, 100, 100, $video);
    $videoFrame->getCaptionTracks()->add("English", "track.vtt");

    $presentation->save("video_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

La classe [CaptionsCollection](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/) fournit également une surcharge qui vous permet d’ajouter des légendes depuis un flux.

**Extraire les légendes d’un cadre vidéo**

Cet exemple enregistre toutes les pistes de légendes des cadres vidéo sur la première diapositive sous forme de fichiers WebVTT séparés. Des numéros séquentiels permettent de différencier les fichiers de sortie. La console indique le nombre de pistes extraites. La présentation doit contenir au moins une diapositive.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $trackCount = 0;
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $captionCount = java_values($videoFrame->getCaptionTracks()->getCount());
            for ($trackIndex = 0; $trackIndex < $captionCount; $trackIndex++) {
                $captionTrack = $videoFrame->getCaptionTracks()->get_Item($trackIndex);
                $trackCount++;
                $outputStream = new Java("java.io.FileOutputStream", "captions_" . $trackCount . ".vtt");
                try {
                    $outputStream->write($captionTrack->getBinaryData());
                } finally {
                    $outputStream->close();
                }
            }
        }
    }

    echo "Caption tracks extracted: " . $trackCount . "\n";
} finally {
    $presentation->dispose();
}
```

Chaque objet [Captions](https://reference.aspose.com/slides/php-java/aspose.slides/captions/) expose l’identifiant de la légende, le libellé, les données binaires et le texte de la légende en tant que chaîne UTF‑8.

**Supprimer les légendes d’un cadre vidéo**

Cet exemple supprime toutes les légendes du cadre vidéo à la première position de forme sur la première diapositive et enregistre le résultat. Il suppose que la diapositive et la forme existent et que la forme est un cadre vidéo.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoFrame = $slide->getShapes()->get_Item(0);
    $videoFrame->getCaptionTracks()->clear();

    $presentation->save("video_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Si vous devez supprimer uniquement une piste de légende, utilisez les méthodes [remove](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#remove) ou [removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#removeAt) au lieu de [clear](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#clear).

## **Extraire la vidéo d’une diapositive**

En plus d’ajouter des vidéos aux diapositives, Aspose.Slides vous permet d’extraire les vidéos intégrées dans les présentations.

Cet exemple extrait les vidéos intégrées de chaque diapositive dans des fichiers binaires séparés et numérotés. Les vidéos liées sont ignorées car elles ne contiennent pas de données intégrées. La console affiche le type MIME de chaque vidéo et le nombre total. La sortie utilise l’extension générique `.bin` ; modifiez‑la pour correspondre au type de média indiqué si nécessaire.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation_with_videos.pptx");
try {
    $videoCount = 0;
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
                $videoFrame = $shape;
                $video = $videoFrame->getEmbeddedVideo();
                if (java_is_null($video)) {
                    echo "Skipped a linked video: no embedded data is available.\n";
                    continue;
                }

                $videoCount++;
                $outputStream = new Java("java.io.FileOutputStream", "extracted_video_" . $videoCount . ".bin");
                try {
                    $outputStream->write($video->getBinaryData());
                } finally {
                    $outputStream->close();
                }
                echo "Video " . $videoCount . ": " . java_values($video->getContentType()) . "\n";
            }
        }
    }

    echo "Embedded videos extracted: " . $videoCount . "\n";
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Quels paramètres de lecture vidéo peuvent être modifiés pour un cadre vidéo ?**

Vous pouvez contrôler le [mode de lecture](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) (automatique ou au clic) et la [boucle](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode). Ces options sont disponibles via les méthodes de l’objet [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/).

**L’ajout d’une vidéo affecte-t-il la taille du fichier PPTX ?**

Oui. Lorsque vous intégrez une vidéo locale, les données binaires sont incluses dans le document, ce qui augmente la taille de la présentation proportionnellement à la taille du fichier. Lorsque vous créez un lien vers une vidéo en ligne et ajoutez une miniature, la présentation stocke le lien et l’image d’aperçu plutôt que les données vidéo, de sorte que l’augmentation de taille est généralement moindre.

**Puis‑je remplacer la vidéo dans un cadre vidéo existant sans modifier sa position et sa taille ?**

Oui. Vous pouvez permuter le [contenu vidéo](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setEmbeddedVideo) à l’intérieur du cadre tout en conservant la géométrie de la forme ; c’est un scénario courant pour mettre à jour les médias dans une mise en page existante.

**Le type de contenu (MIME) d’une vidéo intégrée peut‑il être déterminé ?**

Oui. Une vidéo intégrée possède un [type de contenu](https://reference.aspose.com/slides/php-java/aspose.slides/video/#getContentType) que vous pouvez lire et utiliser, par exemple lors de son enregistrement sur disque.