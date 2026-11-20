---
title: Gérer les cadres audio dans les présentations avec Java
linktitle: Cadre audio
type: docs
weight: 10
url: /fr/java/audio-frame/
keywords:
- audio
- cadre audio
- miniature
- ajouter audio
- propriétés audio
- options audio
- extraire l'audio
- Java
- Aspose.Slides
description: "Intégrez de l'audio dans les diapositives, changez l'icône audio, configurez la lecture, gérez les sous-titres WebVTT et extrayez les sons de transition des diapositives avec Aspose.Slides for Java."
---
## **Aperçu**

Un cadre audio vous permet de lire un son sur une diapositive. Avec Aspose.Slides for Java, vous pouvez intégrer un clip audio, choisir l’image qui le représente, ajuster la lecture et ajouter des sous‑titres. Vous pouvez également récupérer un son attribué à une transition de diapositive.

## **Créer des cadres audio**

Utilisez [addAudioFrameEmbedded](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-java.io.InputStream-) pour intégrer un clip audio local sur la première diapositive. Les deux premières coordonnées positionnent le cadre sur la diapositive, et les deux suivantes définissent sa largeur et sa hauteur, toutes exprimées en points. Cet exemple appelle [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setPlayMode-int-) pour démarrer le clip automatiquement et appelle [setVolume](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setVolume-int-) pour sélectionner le préréglage de volume élevé.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

try (FileInputStream audioStream = new FileInputStream("audio.wav")) {
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, audioStream);
    audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    audioFrame.setVolume(AudioVolumeMode.Loud);

    presentation.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Modifier la miniature du cadre audio**

Par défaut, un cadre audio affiche une icône de haut‑parleur. Pour afficher une miniature personnalisée, ajoutez une image à la présentation avec [addImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimagecollection/#addImage-java.io.InputStream-) et affectez‑la à la picture du cadre avec [setImage](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/#setImage-com.aspose.slides.IPPImage-). L’exemple utilise un JPEG comme miniature pour un clip audio intégré.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

try (FileInputStream audioStream = new FileInputStream("audio.wav");
     FileInputStream imageStream = new FileInputStream("eagle.jpeg")) {
    IPPImage thumbnail = presentation.getImages().addImage(imageStream);

    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioFrame.getPictureFormat().getPicture().setImage(thumbnail);

    presentation.save("example_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Modifier les options de lecture audio**

Les contrôles **Options audio** de PowerPoint déterminent quand un clip démarre, quel volume il a et comment il se comporte pendant le diaporama.

![Contrôles des options audio de PowerPoint pour un cadre audio](audio_frame_0.png)

| Contrôle PowerPoint | Méthode Aspose.Slides for Java |
| --- | --- |
| Démarrer | [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setPlayMode-int-) |
| Préréglage de volume | [setVolume](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setVolume-int-) |
| Lire sur plusieurs diapositives | [setPlayAcrossSlides](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setPlayAcrossSlides-boolean-) |
| Boucle jusqu’à l’arrêt | [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setPlayLoopMode-boolean-) |
| Masquer pendant le diaporama | [setHideAtShowing](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setHideAtShowing-boolean-) |
| Rembobiner après lecture | [setRewindAudio](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setRewindAudio-boolean-) |
| Fondu d’entrée | [setFadeInDuration](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setFadeInDuration-float-) |
| Fondu de sortie | [setFadeOutDuration](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setFadeOutDuration-float-) |
| Découper le début de l’audio | [setTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setTrimFromStart-float-) |
| Découper la fin de l’audio | [setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) |
| Curseur de volume | [setVolumeValue](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setVolumeValue-float-) |

L’exemple trouve le premier cadre audio sur la première diapositive, appelle [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setPlayMode-int-) pour démarrer la lecture au clic, et sélectionne le préréglage de volume faible. Le clip se poursuit sur les diapositives avec la boucle désactivée. L’icône reste masquée pendant le diaporama, et le clip est rembobiné après la lecture.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAudioFrame audioFrame = null;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame) {
            audioFrame = (IAudioFrame) shape;
            break;
        }
    }

    if (audioFrame != null) {
        audioFrame.setPlayMode(AudioPlayModePreset.OnClick);
        audioFrame.setVolume(AudioVolumeMode.Low);
        audioFrame.setPlayAcrossSlides(true);
        audioFrame.setPlayLoopMode(false);
        audioFrame.setHideAtShowing(true);
        audioFrame.setRewindAudio(true);
        presentation.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

Pour un clip de plus de 3,5 secondes, cet exemple ignore les 1,5 secondes initiales et les 2 secondes finales. [setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) indique la durée à omettre à la fin du clip. Pour obtenir l’heure de fin affichée dans PowerPoint, soustrayez ce décalage de la durée totale du clip. Le clip découpé apparaît progressivement pendant 200 millisecondes et disparaît sur 500 millisecondes. Les quatre méthodes prennent des valeurs en millisecondes.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

try (FileInputStream audioStream = new FileInputStream("audio.wav")) {
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audioStream);
    audioFrame.setTrimFromStart(1500f);
    audioFrame.setTrimFromEnd(2000f);
    audioFrame.setFadeInDuration(200f);
    audioFrame.setFadeOutDuration(500f);

    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pour définir le volume de lecture à un pourcentage spécifique, utilisez [setVolumeValue](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setVolumeValue-float-). Cet exemple règle le premier cadre audio sur la première diapositive à 85 %.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAudioFrame audioFrame = null;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame) {
            audioFrame = (IAudioFrame) shape;
            break;
        }
    }

    if (audioFrame != null) {
        audioFrame.setVolumeValue(85f);
        presentation.save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

## **Gérer les sous‑titres audio**

Chaque cadre audio donne accès à ses pistes de sous‑titres via [getCaptionTracks](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#getCaptionTracks--). Utilisez la collection pour attacher des sous‑titres WebVTT au clip, exporter les pistes existantes ou les supprimer.

### **Ajouter des sous‑titres audio**

L’exemple intègre un clip audio sur la première diapositive et utilise [add](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/#add-java.lang.String-java.lang.String-) pour attacher une piste WebVTT locale. Le premier argument fournit le libellé de la piste, et le second identifie le fichier contenant les sous‑titres synchronisés.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

try (FileInputStream audioStream = new FileInputStream("audio.wav")) {
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audioStream);
    audioFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Extraire les sous‑titres audio**

Cet exemple exporte chaque piste de sous‑titres attachée à un cadre audio sur la première diapositive. Il écrit les octets renvoyés par [getBinaryData](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/#getBinaryData--) dans un fichier WebVTT et utilise l’identifiant renvoyé par [getCaptionId](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/#getCaptionId--) comme nom de fichier afin que chaque piste possède une sortie distincte.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IAudioFrame)) {
            continue;
        }
        IAudioFrame audioFrame = (IAudioFrame) shape;
        for (ICaptions track : audioFrame.getCaptionTracks()) {
            Path output = Paths.get(track.getCaptionId() + ".vtt");
            Files.write(output, track.getBinaryData());
        }
    }
} finally {
    presentation.dispose();
}
```

### **Supprimer les sous‑titres audio**

Utilisez [remove](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) ou [removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/#removeAt-int-) pour supprimer une piste individuelle. L’exemple utilise [clear](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/#clear--) pour enlever tous les sous‑titres du premier cadre audio sur la première diapositive tout en conservant le clip.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAudioFrame audioFrame = null;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame) {
            audioFrame = (IAudioFrame) shape;
            break;
        }
    }

    if (audioFrame != null) {
        audioFrame.getCaptionTracks().clear();
        presentation.save("audio_without_captions.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

### **Trouver une ligne dans les sous‑titres audio**

Pour trouver une ligne dans les sous‑titres audio de la première diapositive, recherchez le texte renvoyé par [getDataAsString](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/#getDataAsString--) en mémoire. Dans une zone de texte WebVTT simple, la ligne de synchronisation contient `-->`, les lignes de sous‑titres la suivent, et une ligne vide termine la zone. Cet exemple affiche le libellé de la piste et chaque ligne de sous‑titre contenant «café».

```java
import com.aspose.slides.*;
import java.util.Locale;

Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IAudioFrame)) {
            continue;
        }
        IAudioFrame audioFrame = (IAudioFrame) shape;
        for (ICaptions track : audioFrame.getCaptionTracks()) {
            boolean inCue = false;
            String captions = track.getDataAsString();
            for (String line : captions.split("\\R")) {
                if (line.isEmpty()) {
                    inCue = false;
                } else if (line.contains("-->")) {
                    inCue = true;
                } else if (inCue && line.toLowerCase(Locale.ROOT).contains("café")) {
                    System.out.println(track.getLabel() + ": " + line);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Extraire l’audio**

Une transition de diapositive peut avoir son propre son. Pour le récupérer, appelez [getSound](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getSound--) sur la transition de la diapositive. L’exemple accède aux octets renvoyés par [getBinaryData](https://reference.aspose.com/slides/java/com.aspose.slides/iaudio/#getBinaryData--) et affiche le nombre d’octets. Si la première diapositive n’a aucun son de transition, il affiche un message à la place.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("AudioSlide.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAudio sound = slide.getSlideShowTransition().getSound();
    if (sound != null) {
        byte[] audioData = sound.getBinaryData();
        System.out.println("Transition sound: " + audioData.length + " bytes.");
    } else {
        System.out.println("The first slide has no transition sound.");
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Puis‑je réutiliser le même clip audio sur plusieurs diapositives sans le dupliquer ?**

Oui. Ajoutez le clip une fois à la [audio collection](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getAudios--) de la présentation et transmettez le même objet audio à [addAudioFrameEmbedded](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-com.aspose.slides.IAudio-) pour chaque diapositive.

**Puis‑je remplacer le son d’un cadre audio existant ?**

Oui. Pour un son lié, utilisez [setLinkPathLong](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) pour pointer vers le fichier de remplacement. Pour un son intégré, sélectionnez un autre clip dans la collection audio de la présentation avec [setEmbeddedAudio](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-). Les deux approches conservent le cadre existant.

**Le découpage modifie‑t‑il les données audio stockées dans la présentation ?**

Non. [setTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setTrimFromStart-float-) et [setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) définissent les limites de lecture. Vous pouvez toujours récupérer le clip complet avec [getEmbeddedAudio](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#getEmbeddedAudio--).