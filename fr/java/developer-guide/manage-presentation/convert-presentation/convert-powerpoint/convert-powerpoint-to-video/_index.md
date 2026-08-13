---
title: Convertir des présentations PowerPoint en vidéo en Java
linktitle: PowerPoint en vidéo
type: docs
weight: 130
url: /fr/java/convert-powerpoint-to-video/
keywords:
- convertir PowerPoint
- convertir présentation
- convertir PPT
- convertir PPTX
- PowerPoint en vidéo
- présentation en vidéo
- PPT en vidéo
- PPTX en vidéo
- PowerPoint en MP4
- présentation en MP4
- PPT en MP4
- PPTX en MP4
- enregistrer PPT en MP4
- enregistrer PPTX en MP4
- exporter PPT en MP4
- exporter PPTX en MP4
- conversion vidéo
- PowerPoint
- Java
- Aspose.Slides
description: "Apprenez comment convertir des présentations PowerPoint en vidéo avec Java. Découvrez des exemples de code et des techniques d'automatisation pour rationaliser votre flux de travail."
---
## **Introduction**

En convertissant votre présentation PowerPoint ou OpenDocument en vidéo, vous obtenez :

**Accessibilité accrue :** Tous les appareils, quel que soit le système, disposent par défaut de lecteurs vidéo, ce qui facilite l’ouverture ou la lecture de vidéos comparé aux applications de présentation traditionnelles.

**Portée élargie :** Les vidéos vous permettent d’atteindre un public plus large et de présenter l’information de façon plus attrayante. Les enquêtes et les statistiques montrent que les gens préfèrent regarder et consommer du contenu vidéo plutôt que d’autres formats, rendant votre message plus percutant.

{{% alert color="info" %}} 
Vous voudrez peut‑être consulter notre [**Convertisseur en ligne PowerPoint vers Vidéo**](https://products.aspose.app/slides/fr/video) car il s’agit d’une implémentation en direct et efficace du processus décrit ici.
{{% /alert %}} 

## **Conversion PowerPoint vers Vidéo avec Aspose.Slides**

Dans [Aspose.Slides 22.11](https://docs.aspose.com/slides/fr/java/aspose-slides-for-java-22-11-release-notes/), nous avons ajouté la prise en charge de la conversion de présentations en vidéo. 

* Utilisez **Aspose.Slides** pour générer un ensemble de cadres (à partir des diapositives) correspondant à un certain FPS (images par seconde)
* Utilisez un utilitaire tiers comme **ffmpeg** ([pour java](https://github.com/bramp/ffmpeg-cli-wrapper)) pour créer une vidéo à partir des cadres. 

### **Convertir PowerPoint en Vidéo**

1. Ajoutez ceci à votre fichier POM :
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```

2. Téléchargez ffmpeg [ici](https://ffmpeg.org/download.html).

4. Exécutez le code Java de conversion PowerPoint vers vidéo.

Ce code Java vous montre comment convertir une présentation (contient une figure et deux effets d’animation) en vidéo :

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.util.ArrayList;

Presentation presentation = new Presentation();
try {
    // Ajoute une forme de sourire puis l'anime
    IAutoShape smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);
    ISequence mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    IEffect effectIn = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);
    IEffect effectOut = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2f);
    effectOut.setPresetClassType(EffectPresetClassType.Exit);

    final int fps = 33;
    ArrayList<String> frames = new ArrayList<String>();

    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try
    {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                try {
                    String frame = String.format("frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, ImageFormat.Png);
                    frames.add(frame);
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) player.dispose();
        }
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }

    // Configure le dossier des binaires ffmpeg. Voir cette page: https://github.com/rosenbjerg/FFMpegCore#installation
    FFmpeg ffmpeg = new FFmpeg("path/to/ffmpeg");
    FFprobe ffprobe = new FFprobe("path/to/ffprobe");

    FFmpegBuilder builder = new FFmpegBuilder()
            .addExtraArgs("-start_number", "1")
            .setInput("frame_%04d.png")
            .addOutput("output.avi")
            .setVideoFrameRate(FFmpeg.FPS_24)
            .setFormat("avi")
            .done();

    FFmpegExecutor executor = new FFmpegExecutor(ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (IOException e) {
    e.printStackTrace();
}
```

## **Effets Vidéo**

Vous pouvez appliquer des animations aux objets des diapositives et utiliser des transitions entre les diapositives. 

{{% alert color="info" %}} 
Vous pourriez consulter ces articles : [Animation PowerPoint](https://docs.aspose.com/slides/fr/java/powerpoint-animation/), [Animation de forme](https://docs.aspose.com/slides/fr/java/shape-animation/), et [Effet de forme](https://docs.aspose.com/slides/fr/java/shape-effect/).
{{% /alert %}} 

Les animations et les transitions rendent les diaporamas plus engageants et intéressants — et il en va de même pour les vidéos. Ajoutons une autre diapositive et une transition au code de la présentation précédente :

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    // Ajoute une forme de sourire et l'anime

    // ...

    // Ajoute une nouvelle diapositive et une transition animée

    ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

    newSlide.getBackground().setType(BackgroundType.OwnBackground);

    newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

    newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

    newSlide.getSlideShowTransition().setType(TransitionType.Push);
} finally {
    if (presentation != null) presentation.dispose();
}
```

Aspose.Slides prend également en charge l’animation du texte. Ainsi, nous animons les paragraphes sur les objets, qui apparaîtront les uns après les autres (avec un délai d’une seconde) :

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.util.ArrayList;

Presentation presentation = new Presentation();
try {
    // Ajoute du texte et des animations
    IAutoShape autoShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 210, 120, 300, 300);
    Paragraph para1 = new Paragraph();
    para1.getPortions().add(new Portion("Aspose Slides for Java"));
    Paragraph para2 = new Paragraph();
    para2.getPortions().add(new Portion("convert PowerPoint Presentation with text to video"));

    Paragraph para3 = new Paragraph();
    para3.getPortions().add(new Portion("paragraph by paragraph"));
    IParagraphCollection paragraphCollection = autoShape.getTextFrame().getParagraphs();
    paragraphCollection.add(para1);
    paragraphCollection.add(para2);
    paragraphCollection.add(para3);
    paragraphCollection.add(new Paragraph());

    ISequence mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    IEffect effect1 = mainSequence.addEffect(para1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect2 = mainSequence.addEffect(para2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect3 = mainSequence.addEffect(para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    effect1.getTiming().setTriggerDelayTime(1f);
    effect2.getTiming().setTriggerDelayTime(1f);
    effect3.getTiming().setTriggerDelayTime(1f);

    final int fps = 33;
    ArrayList<String> frames = new ArrayList<String>();

    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try
    {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                try {
                    String frame = String.format("frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, ImageFormat.Png);
                    frames.add(frame);
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) player.dispose();
        }
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }

    // Configure le dossier des binaires ffmpeg. Voir cette page : https://github.com/rosenbjerg/FFMpegCore#installation
    FFmpeg ffmpeg = new FFmpeg("path/to/ffmpeg");
    FFprobe ffprobe = new FFprobe("path/to/ffprobe");

    FFmpegBuilder builder = new FFmpegBuilder()
            .addExtraArgs("-start_number", "1")
            .setInput("frame_%04d.png")
            .addOutput("output.avi")
            .setVideoFrameRate(FFmpeg.FPS_24)
            .setFormat("avi")
            .done();

    FFmpegExecutor executor = new FFmpegExecutor(ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (IOException e) {
    e.printStackTrace();
}
```

## **Classes de Conversion Vidéo**

Pour vous permettre d’effectuer des tâches de conversion PowerPoint vers vidéo, Aspose.Slides fournit les classes [PresentationAnimationsGenerator](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentationanimationsgenerator/) et [PresentationPlayer](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentationplayer/).

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentationanimationsgenerator/) vous permet de définir la taille du cadre vidéo (qui sera créé ultérieurement) via son constructeur. Si vous transmettez une instance de la présentation, `Presentation.SlideSize` sera utilisée et il génère les animations que [PresentationPlayer](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentationplayer/) exploite. 

Lorsque les animations sont générées, un événement `NewAnimation` est déclenché pour chaque animation successive, contenant le paramètre [IPresentationAnimationPlayer](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipresentationanimationplayer/). Cette classe représente un lecteur pour une animation distincte.

Pour travailler avec [IPresentationAnimationPlayer](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipresentationanimationplayer/), on utilise la propriété [Duration](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipresentationanimationplayer/#getDuration--) (durée totale de l’animation) et la méthode [SetTimePosition](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-). Chaque position d’animation est définie dans la plage *0 à durée*, puis la méthode `getFrame` renvoie un [IImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iimage/) correspondant à l’état de l’animation à ce moment‑là :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Ajoute une forme de sourire et l'anime
    IAutoShape smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);
    ISequence mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    IEffect effectIn = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);
    IEffect effectOut = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2f);
    effectOut.setPresetClassType(EffectPresetClassType.Exit);

    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try {
        animationsGenerator.setNewAnimation(animationPlayer ->
        {
            System.out.println(String.format("Animation total duration: %f", animationPlayer.getDuration()));

            animationPlayer.setTimePosition(0); // état initial de l'animation
            // bitmap de l'état initial de l'animation
            animationPlayer.getFrame().save("firstFrame.png", ImageFormat.Png);

            animationPlayer.setTimePosition(animationPlayer.getDuration()); // état final de l'animation
            // dernier cadre de l'animation
            animationPlayer.getFrame().save("lastFrame.png", ImageFormat.Png);
        });

        // génère les animations - c'est ce qui déclenche les événements gérés ci-dessous
        animationsGenerator.run(presentation.getSlides());
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

Pour faire jouer toutes les animations d’une présentation simultanément, on utilise la classe [PresentationPlayer](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentationplayer/). Cette classe reçoit une instance de [PresentationAnimationsGenerator](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentationanimationsgenerator/) et le FPS des effets dans son constructeur, puis déclenche l’événement `FrameTick` pour toutes les animations afin de les faire jouer :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("animated.pptx");
try {
    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, 33);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                arguments.getFrame().save("frame_" + sender.getFrameIndex() + ".png", ImageFormat.Png);
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) player.dispose();
        }
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

Ensuite, les cadres générés peuvent être assemblés pour produire une vidéo. Voir la section [Convertir PowerPoint en Vidéo](https://docs.aspose.com/slides/fr/java/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Animations et Effets Pris en Charge**

**Entrée** :

| Type d'animation | Aspose.Slides | PowerPoint |
|---|---|---|
| **Apparition** | ![not supported](x.png) | ![supported](v.png) |
| **Fondu** | ![supported](v.png) | ![supported](v.png) |
| **Entrée en vol** | ![supported](v.png) | ![supported](v.png) |
| **Flottement** | ![supported](v.png) | ![supported](v.png) |
| **Division** | ![supported](v.png) | ![supported](v.png) |
| **Balayage** | ![supported](v.png) | ![supported](v.png) |
| **Forme** | ![supported](v.png) | ![supported](v.png) |
| **Roue** | ![supported](v.png) | ![supported](v.png) |
| **Barres aléatoires** | ![supported](v.png) | ![supported](v.png) |
| **Croissance & rotation** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Pivot** | ![supported](v.png) | ![supported](v.png) |
| **Rebond** | ![supported](v.png) | ![supported](v.png) |

**Mise en évidence** :

| Type d'animation | Aspose.Slides | PowerPoint |
|---|---|---|
| **Impulsion** | ![not supported](x.png) | ![supported](v.png) |
| **Impulsion de couleur** | ![not supported](x.png) | ![supported](v.png) |
| **Balancement** | ![supported](v.png) | ![supported](v.png) |
| **Rotation** | ![supported](v.png) | ![supported](v.png) |
| **Grossissement/Rétrécissement** | ![not supported](x.png) | ![supported](v.png) |
| **Désaturation** | ![not supported](x.png) | ![supported](v.png) |
| **Assombrissement** | ![not supported](x.png) | ![supported](v.png) |
| **Éclaircissement** | ![not supported](x.png) | ![supported](v.png) |
| **Transparence** | ![not supported](x.png) | ![supported](v.png) |
| **Couleur de l'objet** | ![not supported](x.png) | ![supported](v.png) |
| **Couleur complémentaire** | ![not supported](x.png) | ![supported](v.png) |
| **Couleur de ligne** | ![not supported](x.png) | ![supported](v.png) |
| **Couleur de remplissage** | ![not supported](x.png) | ![supported](v.png) |

**Sortie** :

| Type d'animation | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disparition** | ![not supported](x.png) | ![supported](v.png) |
| **Fondu** | ![supported](v.png) | ![supported](v.png) |
| **Sortie en vol** | ![supported](v.png) | ![supported](v.png) |
| **Flottement sortant** | ![supported](v.png) | ![supported](v.png) |
| **Division** | ![supported](v.png) | ![supported](v.png) |
| **Balayage** | ![supported](v.png) | ![supported](v.png) |
| **Forme** | ![supported](v.png) | ![supported](v.png) |
| **Barres aléatoires** | ![supported](v.png) | ![supported](v.png) |
| **Réduction & rotation** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Pivot** | ![supported](v.png) | ![supported](v.png) |
| **Rebond** | ![supported](v.png) | ![supported](v.png) |

**Chemins de déplacement** :

| Type d'animation | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lignes** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Virages** | ![supported](v.png) | ![supported](v.png) |
| **Formes** | ![supported](v.png) | ![supported](v.png) |
| **Boucles** | ![supported](v.png) | ![supported](v.png) |
| **Chemin personnalisé** | ![supported](v.png) | ![supported](v.png) |

## **FAQ**

### Est‑il possible de convertir des présentations protégées par mot de passe ?

Oui, Aspose.Slides permet de travailler avec des [présentations protégées par mot de passe](/slides/fr/java/password-protected-presentation/). Lors du traitement de ces fichiers, vous devez fournir le mot de passe correct afin que la bibliothèque puisse accéder au contenu de la présentation.

### Aspose.Slides prend‑il en charge une utilisation dans des solutions cloud ?

Oui, Aspose.Slides peut être intégré aux applications et services cloud. La bibliothèque est conçue pour fonctionner dans des environnements serveur, garantissant haute performance et évolutivité pour le traitement par lot de fichiers.

### Existe‑t‑il des limitations de taille pour les présentations lors de la conversion ?

Aspose.Slides peut gérer des présentations de pratiquement n’importe quelle taille. Cependant, avec des fichiers très volumineux, des ressources système supplémentaires peuvent être nécessaires, et il est parfois recommandé d’optimiser la présentation afin d’améliorer les performances.