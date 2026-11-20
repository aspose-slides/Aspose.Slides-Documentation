---
title: Gérer les cadres vidéo dans les présentations avec Java
linktitle: Cadre vidéo
type: docs
weight: 10
url: /fr/java/video-frame/
keywords:
- ajouter vidéo
- créer vidéo
- intégrer vidéo
- extraire vidéo
- récupérer vidéo
- cadre vidéo
- source web
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Apprenez à ajouter et extraire programmatiquement des cadres vidéo dans les diapositives PowerPoint et OpenDocument en utilisant Aspose.Slides pour Java. Guide pratique rapide."
---
## **Introduction**

Les vidéos peuvent aider à expliquer des idées et a captiver le public. Aspose.Slides for Java vous permet d'ajouter des cadres video aux diapositives, d'ajuster les parametres de lecture, de gerer les sous-titres et d'extraire les donnees video integrees.

PowerPoint prend en charge les videos locales et les liens vers des videos en ligne, telles que les videos YouTube.

Pour representer les donnees video et les cadres video, Aspose.Slides fournit les interfaces [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/) , [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) , et d'autres types pertinents.

## **Creer un cadre video integre**

Si le fichier video que vous souhaitez ajouter a votre diapositive est stocke localement, vous pouvez creer un cadre video pour integrer la video dans votre presentation.

Cet exemple integre une video locale sur la premiere diapositive d'une presentation existante et enregistre le resultat. Les coordonnees et les dimensions du cadre sont exprimees en points. Le flux reste ouvert jusqu'a la fin de l'enregistrement parce que [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/java/com.aspose.slides/loadingstreambehavior/) le maintient verrouille pendant que la presentation l'utilise.

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

Vous pouvez egalement transmettre le chemin d'une video locale directement a [addVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-java.lang.String-). Cet exemple integre la video sur la premiere diapositive d'une nouvelle presentation. La video doit rester accessible jusqu'a ce que la presentation soit enregistree.

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

## **Creer un cadre video avec une video provenant d'une source Web**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) prend en charge les videos en ligne dans les presentations. Vous pouvez creer un cadre video qui pointe vers une video en ligne, telle qu'une video YouTube.

Cet exemple ajoute un lien video YouTube et une vignette a la premiere diapositive. Remplacez l'identifiant video pour utiliser une autre video. La methode [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setPlayMode-int-) demande la lecture automatique. Le telechargement de la vignette et la lecture de la video necessitent un acces Internet. Le visualiseur de presentations doit egalement prendre en charge la lecture de videos en ligne.

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

## **Lire une video en mode plein ecran**

Dans une presentation de formation, vous pouvez lire une demonstration logicielle en mode plein ecran afin que le public puisse voir les details. Appelez [setFullScreenMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) avec `true` pour activer ce comportement pendant la lecture.

Cet exemple ouvre une presentation, trouve le premier [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) sur la premiere diapositive, et active la lecture en plein ecran. La presentation d'entree doit contenir au moins une diapositive avec un cadre video existant sur la premiere diapositive.

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

La lecture en plein ecran controle la facon dont la video est affichee. De maniere independente, [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) controle si elle demarre automatiquement ou sur clic, et [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) controle si elle se repete. Pour choisir le comportement de demarrage, définissez le mode de lecture sur [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/java/com.aspose.slides/videoplaymodepreset/). L'exemple conserve les parametres de demarrage et de boucle existants.

## **Rembobiner une video après la lecture**

Dans une presentation de formation, ramener une video de demonstration a son debut la rend prête pour que le presentateur la relise. Appelez [setRewindVideo](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setRewindVideo-boolean-) avec `true` pour ramener la video au debut apres la fin de la lecture.

Cet exemple ouvre une presentation, trouve le premier [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) sur la premiere diapositive, et active le rembobinage. Il desactive la boucle afin que la lecture puisse se terminer et definit la lecture pour demarrer sur clic. La presentation d'entree doit contenir au moins une diapositive avec un cadre video existant sur la premiere diapositive.

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

Le rembobinage ramene la video a son debut sans la relancer. En revanche, appeler [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) avec `true` repete la lecture automatiquement. Gardez la boucle desactivee lorsque vous voulez que la video se termine et reste prête a etre relue. [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) controle independamment le demarrage automatique ou sur clic ; cet exemple utilise [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/java/com.aspose.slides/videoplaymodepreset/) afin que le presentateur decide quand la lecture demarre. Definissez le mode de lecture apres le parametre de boucle, comme le montre l'exemple. Le rembobinage fonctionne independamment de [setFullScreenMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setFullScreenMode-boolean-).

## **Rogner un cadre video**

Utilisez [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) et [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) pour ignorer une partie du debut ou de la fin d'une video pendant la lecture. Les deux valeurs sont exprimees en millisecondes. Le rognage modifie les parametres de lecture sans modifier les donnees video integrees.

**Definir les parametres de rognage**

Cet exemple integre une video locale et saute les 2,5 premieres secondes ainsi que la derniere seconde pendant la lecture. Utilisez une video de plus de 3,5 secondes afin qu'un segment lisible reste.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    Path videoPath = Paths.get("video.mp4");
    byte[] videoData = Files.readAllBytes(videoPath);
    IVideo video = presentation.getVideos().addVideo(videoData);

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);
    videoFrame.setTrimFromStart(2500f);
    videoFrame.setTrimFromEnd(1000f);

    presentation.save("video_with_trim.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Lire les parametres de rognage**

Cet exemple affiche les valeurs de rognage du premier cadre video sur la premiere diapositive en millisecondes. La presentation doit contenir au moins une diapositive. Si cette diapositive ne possède aucun cadre video, rien n'est affiche. L'exemple precedent produit les valeurs 2500 et 1000.

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

## **Gerer les sous-titres video**

Aspose.Slides vous permet de gerer les sous-titres fermes pour les cadres video dans les presentations PowerPoint. Les sous-titres sont stockes au format WebVTT et sont accessibles via la methode [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#getCaptionTracks--).

### **Ajouter des sous-titres a un cadre video**

Cet exemple integre une video locale et ajoute une piste de sous-titres WebVTT intitule English. Les horodatages des sous-titres doivent correspondre a la video. La presentation enregistree inclut a la fois la video et ses sous-titres.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    Path videoPath = Paths.get("video.mp4");
    byte[] videoData = Files.readAllBytes(videoPath);
    IVideo video = presentation.getVideos().addVideo(videoData);

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

L'interface [ICaptionsCollection](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/) propose egalement une surcharge qui vous permet d'ajouter des sous-titres depuis un flux.

### **Extraire les sous-titres d'un cadre video**

Cet exemple enregistre toutes les pistes de sous-titres des cadres video de la premiere diapositive sous forme de fichiers WebVTT separes. Des numeraux sequenciels permettent de differencier les fichiers de sortie. La console indique le nombre de pistes extraites. La presentation doit contenir au moins une diapositive.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int trackCount = 0;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                trackCount++;
                Path outputPath = Paths.get("captions_" + trackCount + ".vtt");
                Files.write(outputPath, captionTrack.getBinaryData());
            }
        }
    }

    System.out.println("Caption tracks extracted: " + trackCount);
} finally {
    presentation.dispose();
}
```

Chaque objet [ICaptions](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/) expose l'identifiant du sous-titre, le libelle, les donnees binaires et le texte du sous-titre sous forme de chaine UTF-8.

### **Supprimer les sous-titres d'un cadre video**

Cet exemple supprime tous les sous-titres du cadre video a la première position de forme sur la première diapositive et enregistre le resultat. Il suppose que la diapositive et la forme existent et que la forme est un cadre video.

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

Si vous devez supprimer uniquement une piste de sous-titre, utilisez les methodes [remove](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#remove-com.aspose.slides.ICaptions-) ou [removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#removeAt-int-) au lieu de [clear](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#clear--).

### **Rechercher des sous-titres video**

[ICaptions.getDataAsString](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/#getDataAsString--) renvoie la piste WebVTT complete, incluant son en-tete, ses lignes de timing et le texte du sous-titre. Vous pouvez rechercher les repères en memoire afin de trouver une phrase prononcee et son horodatage. Par exemple, une piste English sur la diapositive 2 pourrait contenir le texte suivant.

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

L'exemple ouvre `captioned_media.pptx` et utilise [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) pour lire les pistes de chaque cadre video de niveau superieur sur chaque diapositive. Dans un repere en texte brut, la ligne de timing contient `-->`, et une ligne vide termine le repere. Lorsque le sous-titre contient "café" quelle que soit la casse, l'exemple affiche le numero de diapositive, le libelle de la piste, la ligne de timing originale et le sous-titre complet.

```java
import com.aspose.slides.*;
import java.util.Locale;
import java.util.Scanner;
import java.util.StringJoiner;

Presentation presentation = new Presentation("captioned_media.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (!(shape instanceof IVideoFrame)) {
                continue;
            }
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions track : videoFrame.getCaptionTracks()) {
                try (Scanner reader = new Scanner(track.getDataAsString())) {
                    while (reader.hasNextLine()) {
                        String timing = reader.nextLine();
                        if (!timing.contains("-->")) {
                            continue;
                        }
                        StringJoiner caption = new StringJoiner(System.lineSeparator());
                        while (reader.hasNextLine()) {
                            String line = reader.nextLine();
                            if (line.isEmpty()) {
                                break;
                            }
                            caption.add(line);
                        }
                        if (caption.toString().toLowerCase(Locale.ROOT).contains("café")) {
                            System.out.printf("Slide %d | %s | %s%n", slide.getSlideNumber(), track.getLabel(), timing);
                            System.out.println(caption);
                        }
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

La recherche de "café" produit une correspondance pour la piste d'exemple. La recherche exclut l'en-tete de la piste et conserve le reglage de timing dans la sortie.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Extraire la video d'une diapositive**

Outre l'ajout de videos aux diapositives, Aspose.Slides vous permet d'extraire les videos integrees aux presentations.

Cet exemple extrait les videos integrees de chaque diapositive dans des fichiers binaires separes et numerotes. Les videos liees sont ignorees car elles ne possedent aucune donnee integree. La console affiche le type MIME de chaque video ainsi que le nombre total. La sortie utilise l'extension generique `.bin`; modifiez-la pour correspondre au type media rapporte si necessaire.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

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
                Path outputPath = Paths.get("extracted_video_" + videoCount + ".bin");
                Files.write(outputPath, video.getBinaryData());
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

**Quels parametres de lecture video peuvent etre modifies pour un cadre video ?**

Vous pouvez contrôler le [mode de lecture](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) (automatique ou sur clic) et la [boucle](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-). Ces options sont disponibles via les methodes de l'objet [VideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/).

**L'ajout d'une video affecte-t-il la taille du fichier PPTX ?**

Oui. Lorsque vous integrez une video locale, les donnees binaires sont incluses dans le document, ce qui fait augmenter la taille de la presentation proportionnellement à la taille du fichier. Lorsque vous creez un lien vers une video en ligne et ajoutez une vignette, la presentation enregistre le lien et l'image d'aperçu plutôt que les donnees video, ce qui entraine généralement une augmentation de taille moindre.

**Puis-je remplacer la video d'un cadre video existant sans modifier sa position et sa taille ?**

Oui. Vous pouvez remplacer le [contenu video](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) a l'interieur du cadre tout en conservant la geometrie de la forme ; c'est un scenario frequent pour mettre a jour les medias dans une mise en page existante.

**Peut-on determiner le type de contenu (MIME) d'une video integree ?**

Oui. Une video integree possède un [type de contenu](https://reference.aspose.com/slides/java/com.aspose.slides/video/#getContentType--) que vous pouvez lire et utiliser, par exemple lors de son enregistrement sur disque.