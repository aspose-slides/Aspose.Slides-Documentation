---
title: Convertir des présentations PowerPoint en vidéo sur Android
linktitle: PowerPoint en vidéo
type: docs
weight: 130
url: /fr/androidjava/convert-powerpoint-to-video/
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
- sauvegarder PPT en MP4
- sauvegarder PPTX en MP4
- exporter PPT en MP4
- exporter PPTX en MP4
- conversion vidéo
- PowerPoint
- Android
- Java
- Aspose.Slides
description: "Apprenez comment convertir des présentations PowerPoint en vidéo en Java. Découvrez des exemples de code et des techniques d'automatisation pour optimiser votre flux de travail."
---
## **Introduction**

En convertissant votre présentation PowerPoint en vidéo, vous obtenez 

* **Augmentation de l'accessibilité :** Tous les appareils (indépendamment de la plateforme) sont équipés de lecteurs vidéo par défaut, contrairement aux applications d'ouverture de présentations, ce qui facilite l'ouverture ou la lecture des vidéos pour les utilisateurs.
* **Plus grande portée :** Grâce aux vidéos, vous pouvez atteindre un large public et leur proposer des informations qui pourraient autrement sembler fastidieuses dans une présentation. La plupart des enquêtes et statistiques indiquent que les gens regardent et consomment davantage les vidéos que les autres formes de contenu, et ils préfèrent généralement ce type de contenu.

## **Conversion de PowerPoint en vidéo avec Aspose.Slides**

Aspose.Slides prend en charge la conversion de présentations en vidéo.

* Utilisez **Aspose.Slides** pour générer un ensemble d'images (à partir des diapositives de la présentation) qui correspondent à un certain nombre d'IPS (images par seconde)
* Utilisez un utilitaire tiers comme **ffmpeg** ([pour java](https://github.com/bramp/ffmpeg-cli-wrapper)) pour créer une vidéo à partir des images. 

### **Convertir PowerPoint en vidéo**

1. Ajoutez ceci à votre fichier POM :
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```

2. Téléchargez ffmpeg [ici](https://ffmpeg.org/download.html).

3. Exécutez le code Java de conversion PowerPoint en vidéo.

Ce code Java vous montre comment convertir une présentation (contenant une figure et deux effets d'animation) en vidéo :
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

    // Configure le dossier des binaires ffmpeg. Voir cette page : https://github.com/bramp/ffmpeg-cli-wrapper
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

## **Effets vidéo**

Vous pouvez appliquer des animations aux objets des diapositives et utiliser des transitions entre les diapositives. 

{{% alert color="info" %}} 

Vous souhaiterez peut‑être consulter ces articles : [Animation PowerPoint](https://docs.aspose.com/slides/fr/androidjava/powerpoint-animation/), [Animation de forme](https://docs.aspose.com/slides/fr/androidjava/shape-animation/), et [Effet de forme](https://docs.aspose.com/slides/fr/androidjava/shape-effect/).

{{% /alert %}} 

Les animations et les transitions rendent les diaporamas plus attrayants et intéressants — et elles ont le même effet sur les vidéos. Ajoutons une autre diapositive et une transition au code de la présentation précédente :
```java
import com.aspose.slides.*;
import java.awt.Color;

// La présentation avec la forme de sourire animée créée ci-dessus.
Presentation presentation = new Presentation();
try {
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

Aspose.Slides prend également en charge l'animation du texte. Nous animons donc les paragraphes sur les objets, qui apparaîtront les uns après les autres (avec un délai d'une seconde) :
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

    // Configure le dossier des binaires ffmpeg. Voir cette page : https://github.com/bramp/ffmpeg-cli-wrapper
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

## **Classes de conversion vidéo**

Pour vous permettre d'effectuer des tâches de conversion de PowerPoint en vidéo, Aspose.Slides fournit les classes [PresentationAnimationsGenerator](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentationanimationsgenerator/) et [PresentationPlayer](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentationplayer/).

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentationanimationsgenerator/) vous permet de définir la taille du cadre pour la vidéo (qui sera créée ultérieurement) via son constructeur. Si vous transmettez une instance de la présentation, `Presentation.SlideSize` sera utilisée et il génère des animations que [PresentationPlayer](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentationplayer/) utilise.

Lorsque les animations sont générées, un événement `NewAnimation` est créé pour chaque animation successive, qui possède le paramètre [IPresentationAnimationPlayer](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipresentationanimationplayer/). Ce dernier est une classe qui représente un lecteur pour une animation distincte.

Pour travailler avec [IPresentationAnimationPlayer](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipresentationanimationplayer/), les propriétés [Duration](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipresentationanimationplayer/#getDuration--) (la durée totale de l'animation) et la méthode [SetTimePosition](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-) sont utilisées. Chaque position d'animation est définie dans l'intervalle *0 à durée*, puis la méthode `getFrame` renverra un [IImage](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iimage/) correspondant à l'état de l'animation à ce moment :
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
            // dernière image de l'animation
            animationPlayer.getFrame().save("lastFrame.png", ImageFormat.Png);
        });

        // Génère les animations. Le rappel ci‑dessus s'exécute pour chacune d'elles.
        animationsGenerator.run(presentation.getSlides());
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

Pour faire jouer toutes les animations d'une présentation simultanément, la classe [PresentationPlayer](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentationplayer/) est utilisée. Cette classe prend une instance de [PresentationAnimationsGenerator](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentationanimationsgenerator/) et le nombre d'IPS pour les effets dans son constructeur, puis déclenche l'événement `FrameTick` pour toutes les animations afin de les lire :
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

Ensuite, les images générées peuvent être assemblées pour produire une vidéo. Voir la section [Convert PowerPoint to Video](https://docs.aspose.com/slides/fr/androidjava/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Animations et effets pris en charge**

**Entrée** :

| Type d'animation | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Fade** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Fly In** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Float In** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Split** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Wipe** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Shape** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Wheel** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Random Bars** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Grow & Turn** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Zoom** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Swivel** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Bounce** | ![pris en charge](v.png) | ![pris en charge](v.png) |

**Mise en évidence** :

| Type d'animation | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Color Pulse** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Teeter** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Spin** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Grow/Shrink** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Desaturate** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Darken** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Lighten** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Transparency** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Object Color** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Complementary Color** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Line Color** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Fill Color** | ![non pris en charge](x.png) | ![pris en charge](v.png) |

**Sortie** :

| Type d'animation | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Fade** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Fly Out** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Float Out** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Split** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Wipe** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Shape** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Random Bars** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Shrink & Turn** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Zoom** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Swivel** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Bounce** | ![pris en charge](v.png) | ![pris en charge](v.png) |

**Chemins de mouvement** :

| Type d'animation | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Arcs** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Turns** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Shapes** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Loops** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Custom Path** | ![pris en charge](v.png) | ![pris en charge](v.png) |

## **FAQ**

### Est‑il possible de convertir des présentations protégées par mot de passe ?

Oui, Aspose.Slides permet de travailler avec des [présentations protégées par mot de passe](/slides/fr/androidjava/password-protected-presentation/). Lors du traitement de tels fichiers, vous devez fournir le mot de passe correct afin que la bibliothèque puisse accéder au contenu de la présentation.

### Aspose.Slides prend‑il en charge une utilisation dans les solutions cloud ?

Oui, Aspose.Slides peut être intégré aux applications et services cloud. La bibliothèque est conçue pour fonctionner dans des environnements serveur, garantissant haute performance et évolutivité pour le traitement par lots des fichiers.

### Existe‑t‑il des limitations de taille pour les présentations lors de la conversion ?

Aspose.Slides est capable de gérer des présentations de pratiquement n'importe quelle taille. Cependant, lors du traitement de fichiers très volumineux, des ressources système supplémentaires peuvent être nécessaires, et il est parfois recommandé d'optimiser la présentation pour améliorer les performances.