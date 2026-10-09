---
title: Gérer les cadres vidéo dans les présentations sur Android
linktitle: Cadre vidéo
type: docs
weight: 10
url: /fr/androidjava/video-frame/
keywords:
- ajouter une vidéo
- créer une vidéo
- intégrer une vidéo
- extraire une vidéo
- récupérer une vidéo
- cadre vidéo
- source web
- PowerPoint
- OpenDocument
- présentation
- Android
- Java
- Aspose.Slides
description: "Apprenez à ajouter et extraire des cadres vidéo de manière programmatique dans les diapositives PowerPoint et OpenDocument à l’aide d’Aspose.Slides pour Android via Java. Guide pratique rapide."
---
## **Introduction**

Les vidéos peuvent aider à expliquer des idées et à capter l'attention du public. Aspose.Slides pour Android via Java vous permet d’ajouter des cadres vidéo aux diapositives, d’ajuster les paramètres de lecture, de gérer les sous‑titres et d’extraire les données vidéo intégrées.

PowerPoint prend en charge les vidéos locales et les liens vers des vidéos en ligne, comme les vidéos YouTube.

Pour représenter les données vidéo et les cadres vidéo, Aspose.Slides fournit l’interface [IVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideo/) , l’interface [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) , ainsi que d’autres types pertinents.

## **Créer un cadre vidéo intégré**

Si le fichier vidéo que vous souhaitez ajouter à votre diapositive est stocké localement, vous pouvez créer un cadre vidéo pour intégrer la vidéo dans votre présentation.

Cet exemple intègre une vidéo locale sur la première diapositive d’une présentation existante et enregistre le résultat. Les coordonnées et les dimensions du cadre sont exprimées en points. Le flux reste ouvert jusqu’à la fin de l’enregistrement car [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadingstreambehavior/) le verrouille pendant que la présentation l’utilise.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation("presentation.pptx");
try (FileInputStream videoStream = new FileInputStream("video.mp4")) {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideo video = presentation.getVideos().addVideo(videoStream, LoadingStreamBehavior.KeepLocked);
    slide.getShapes().addVideoFrame(10, 10, 150, 250, video);

    presentation.save("embedded_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Vous pouvez également transmettre directement le chemin d’une vidéo locale à [addVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-java.lang.String-). Cet exemple intègre la vidéo sur la première diapositive d’une nouvelle présentation. La vidéo doit rester accessible jusqu’à ce que la présentation soit enregistrée.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addVideoFrame(50, 150, 300, 150, "video.avi");

    presentation.save("video_from_path.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Créer un cadre vidéo avec une vidéo provenant d’une source Web**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) prend en charge les vidéos en ligne dans les présentations. Vous pouvez créer un cadre vidéo qui pointe vers une vidéo en ligne, comme une vidéo YouTube.

Cet exemple ajoute un lien vidéo YouTube et une vignette sur la première diapositive. Remplacez l’identifiant vidéo pour utiliser une autre vidéo. La méthode [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setPlayMode-int-) demande une lecture automatique. Le téléchargement de la vignette et la lecture de la vidéo nécessitent un accès Internet. Le visualiseur de présentation doit également prendre en charge la lecture de vidéos en ligne.

```java
import com.aspose.slides.*;
import java.io.InputStream;
import java.net.URL;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    String videoId = "aqz-KE-bpKQ";
    String videoUrl = "https://www.youtube.com/embed/" + videoId;
    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(10, 10, 427, 240, videoUrl);
    videoFrame.setPlayMode(VideoPlayModePreset.Auto);

    String thumbnailUrl = "https://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
    URL thumbnailLocation = new URL(thumbnailUrl);
    try (InputStream thumbnailStream = thumbnailLocation.openStream()) {
        IPPImage thumbnail = presentation.getImages().addImage(thumbnailStream);
        videoFrame.getPictureFormat().getPicture().setImage(thumbnail);
    }

    presentation.save("online_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Lire une vidéo en mode plein écran**

Dans une présentation de formation, vous pouvez lire une démonstration logicielle en mode plein écran afin que le public puisse voir les détails. Appelez [setFullScreenMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) avec `true` pour activer ce comportement pendant la lecture.

Cet exemple ouvre une présentation, trouve le premier [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) sur la première diapositive et active la lecture en plein écran. La présentation d’entrée doit contenir au moins une diapositive avec un cadre vidéo existant sur la première diapositive.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("training.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            videoFrame.setFullScreenMode(true);
            break;
        }
    }

    presentation.save("full_screen_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La lecture en plein écran détermine comment la vidéo est affichée. De manière indépendante, [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) contrôle si elle démarre automatiquement ou au clic, et [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) contrôle si elle se répète. Pour choisir le comportement de démarrage, définissez le mode de lecture sur [VideoPlayModePreset.Auto ou VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoplaymodepreset/). L’exemple préserve les paramètres de démarrage et de boucle existants.

## **Rembobiner une vidéo après la lecture**

Dans une présentation de formation, ramener une vidéo de démonstration au début la rend prête à être relancée par le présentateur. Appelez [setRewindVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setRewindVideo-boolean-) avec `true` pour ramener la vidéo au début après la fin de la lecture.

Cet exemple ouvre une présentation, trouve le premier [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) sur la première diapositive et active le rembobinage. Il désactive la boucle afin que la lecture puisse se terminer et définit le démarrage de la lecture au clic. La présentation d’entrée doit contenir au moins une diapositive avec un cadre vidéo existant sur la première diapositive.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("training.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            videoFrame.setRewindVideo(true);
            videoFrame.setPlayLoopMode(false);
            videoFrame.setPlayMode(VideoPlayModePreset.OnClick);
            break;
        }
    }

    presentation.save("rewind_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le rembobinage ramène la vidéo au début sans la redémarrer. En revanche, appeler [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) avec `true` répète la lecture automatiquement. Gardez la boucle désactivée lorsque vous voulez que la vidéo se termine et reste prête à être relancée. [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) contrôle indépendamment le démarrage automatique ou au clic ; cet exemple utilise [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoplaymodepreset/) afin que le présentateur contrôle le moment du démarrage de la lecture. Définissez le mode de lecture après le paramètre de boucle, comme le montre l’exemple. Le rembobinage fonctionne indépendamment de [setFullScreenMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setFullScreenMode-boolean-).

## **Rogner un cadre vidéo**

Utilisez [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) et [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) pour ignorer une partie du début ou de la fin d’une vidéo pendant la lecture. Les deux valeurs sont en millisecondes. Le rognage modifie les paramètres de lecture sans altérer les données vidéo intégrées.

**Définir les paramètres de rognage**

Cet exemple intègre une vidéo locale et ignore les 2,5 secondes initiales ainsi que la dernière seconde pendant la lecture. Utilisez une vidéo de plus de 3,5 secondes afin qu’il reste un segment lisible.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideo video;
    try (FileInputStream videoStream = new FileInputStream("video.mp4")) {
        video = presentation.getVideos().addVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
    }

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);
    videoFrame.setTrimFromStart(2500f);
    videoFrame.setTrimFromEnd(1000f);

    presentation.save("video_with_trim.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Lire les paramètres de rognage**

Cet exemple affiche les valeurs de rognage du premier cadre vidéo sur la première diapositive en millisecondes. La présentation doit contenir au moins une diapositive. Si cette diapositive ne possède pas de cadre vidéo, rien n’est affiché. L’exemple précédent produit les valeurs 2500 et 1000.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("video_with_trim.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            System.out.println("Trim from start: " + videoFrame.getTrimFromStart() + " ms");
            System.out.println("Trim from end: " + videoFrame.getTrimFromEnd() + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **Gérer les sous‑titres vidéo**

Aspose.Slides vous permet de gérer les sous‑titres fermés pour les cadres vidéo dans les présentations PowerPoint. Les sous‑titres sont stockés au format WebVTT et sont accessibles via la méthode [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--).

**Ajouter des sous‑titres à un cadre vidéo**

Cet exemple intègre une vidéo locale et ajoute une piste de sous‑titres WebVTT intitulée English. Les horodatages des sous‑titres doivent correspondre à la vidéo. La présentation enregistrée contient à la fois la vidéo et ses sous‑titres.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideo video;
    try (FileInputStream videoStream = new FileInputStream("video.mp4")) {
        video = presentation.getVideos().addVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
    }

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

L’interface [ICaptionsCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/) offre également une surcharge qui vous permet d’ajouter des sous‑titres à partir d’un flux.

**Extraire les sous‑titres d’un cadre vidéo**

Cet exemple enregistre toutes les pistes de sous‑titres des cadres vidéo sur la première diapositive en fichiers WebVTT séparés. Des numéros séquentiels permettent de différencier les fichiers de sortie. La console indique le nombre de pistes extraites. La présentation doit contenir au moins une diapositive.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int trackCount = 0;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                trackCount++;
                try (FileOutputStream outputStream = new FileOutputStream("captions_" + trackCount + ".vtt")) {
                    outputStream.write(captionTrack.getBinaryData());
                }
            }
        }
    }

    System.out.println("Caption tracks extracted: " + trackCount);
} finally {
    presentation.dispose();
}
```

Chaque objet [ICaptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/) expose l’identifiant du sous‑titre, le libellé, les données binaires et le texte du sous‑titre sous forme de chaîne UTF‑8.

**Supprimer les sous‑titres d’un cadre vidéo**

Cet exemple supprime tous les sous‑titres du cadre vidéo à la première position de forme sur la première diapositive et enregistre le résultat. Il part du principe que la diapositive et la forme existent et que la forme est un cadre vidéo.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideoFrame videoFrame = (IVideoFrame) slide.getShapes().get_Item(0);
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Si vous devez supprimer une seule piste de sous‑titre, utilisez les méthodes [remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#remove-com.aspose.slides.ICaptions-) ou [removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#removeAt-int-) au lieu de [clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#clear--).

## **Extraire la vidéo d’une diapositive**

En plus d’ajouter des vidéos aux diapositives, Aspose.Slides vous permet d’extraire les vidéos intégrées dans les présentations.

Cet exemple extrait les vidéos intégrées de chaque diapositive dans des fichiers binaires séparés et numérotés. Les vidéos liées sont ignorées car elles ne contiennent pas de données intégrées. La console affiche le type MIME de chaque vidéo ainsi que le nombre total. La sortie utilise l’extension générique `.bin` ; modifiez‑la pour correspondre au type de média indiqué si nécessaire.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("presentation_with_videos.pptx");
try {
    int videoCount = 0;
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IVideoFrame) {
                IVideoFrame videoFrame = (IVideoFrame) shape;
                IVideo video = videoFrame.getEmbeddedVideo();
                if (video == null) {
                    System.out.println("Skipped a linked video: no embedded data is available.");
                    continue;
                }

                videoCount++;
                try (FileOutputStream outputStream = new FileOutputStream("extracted_video_" + videoCount + ".bin")) {
                    outputStream.write(video.getBinaryData());
                }
                System.out.println("Video " + videoCount + ": " + video.getContentType());
            }
        }
    }

    System.out.println("Embedded videos extracted: " + videoCount);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Quels paramètres de lecture vidéo peuvent être modifiés pour un cadre vidéo ?**

Vous pouvez contrôler le [mode de lecture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) (automatique ou au clic) et la [boucle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-). Ces options sont disponibles via les méthodes de l’objet [VideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/).

**L’ajout d’une vidéo influence-t-il la taille du fichier PPTX ?**

Oui. Lorsque vous intégrez une vidéo locale, les données binaires sont incluses dans le document, ce qui augmente la taille de la présentation proportionnellement à la taille du fichier. Lorsque vous créez un lien vers une vidéo en ligne et ajoutez une vignette, la présentation ne stocke que le lien et l’image de prévisualisation au lieu des données vidéo, de sorte que l’augmentation de taille est généralement moindre.

**Puis‑je remplacer la vidéo d’un cadre vidéo existant sans modifier sa position et sa taille ?**

Oui. Vous pouvez remplacer le [contenu vidéo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) du cadre tout en conservant la géométrie de la forme ; c’est un scénario fréquent pour mettre à jour les médias dans une mise en page existante.

**Le type de contenu (MIME) d’une vidéo intégrée peut‑il être déterminé ?**

Oui. Une vidéo intégrée possède un [type de contenu](https://reference.aspose.com/slides/androidjava/com.aspose.slides/video/#getContentType--) que vous pouvez lire et utiliser, par exemple lors de son enregistrement sur disque.