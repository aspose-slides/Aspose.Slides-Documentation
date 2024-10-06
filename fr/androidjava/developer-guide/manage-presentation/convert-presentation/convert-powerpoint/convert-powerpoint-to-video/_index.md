---
title: Convertir PowerPoint en Vidéo
type: docs
weight: 130
url: /androidjava/convert-powerpoint-to-video/
keywords: "Convertir PowerPoint, PPT, PPTX, Présentation, Vidéo, MP4, PPT en vidéo, PPT en MP4, Java, Aspose.Slides"
description: "Convertir PowerPoint en Vidéo en Java"
---

En convertissant votre présentation PowerPoint en vidéo, vous obtenez

* **Augmentation de l'accessibilité :** Tous les appareils (indépendamment de la plateforme) sont équipés par défaut de lecteurs vidéo comparés aux applications d'ouverture de présentation, donc les utilisateurs trouvent plus facile d'ouvrir ou de lire des vidéos.
* **Plus de portée :** Grâce aux vidéos, vous pouvez atteindre un large public et leur fournir des informations qui pourraient autrement sembler fastidieuses dans une présentation. La plupart des enquêtes et des statistiques suggèrent que les gens regardent et consomment des vidéos plus que d'autres formes de contenu, et ils préfèrent généralement ce type de contenu.

{{% alert color="primary" %}}

Vous voudrez peut-être vérifier notre [**Convertisseur en Ligne PowerPoint en Vidéo**](https://products.aspose.app/slides/conversion/ppt-to-word) car c'est une mise en œuvre en direct et efficace du processus décrit ici.

{{% /alert %}}

## **Conversion de PowerPoint en Vidéo dans Aspose.Slides**

Dans [Aspose.Slides 22.11](https://docs.aspose.com/slides/androidjava/aspose-slides-for-java-22-11-release-notes/), nous avons implémenté le support de la conversion de présentation en vidéo.

* Utilisez **Aspose.Slides** pour générer un ensemble de frames (à partir des diapositives de la présentation) correspondant à un certain FPS (frames par seconde)
* Utilisez un utilitaire tiers comme **ffmpeg** ([pour java](https://github.com/bramp/ffmpeg-cli-wrapper)) pour créer une vidéo à partir des frames.

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

4. Exécutez le code Java pour convertir PowerPoint en vidéo.

Ce code Java vous montre comment convertir une présentation (contenant une figure et deux effets d'animation) en vidéo :

```java
Presentation presentation = new Presentation();
try {
    // Ajoute une forme de sourire et l'anime
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

    // Configurez le dossier des binaires ffmpeg. Voir cette page : https://github.com/rosenbjerg/FFMpegCore#installation
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

Vous pouvez appliquer des animations aux objets sur les diapositives et utiliser des transitions entre les diapositives.

{{% alert color="primary" %}}

Vous voudrez peut-être consulter ces articles : [Animation PowerPoint](https://docs.aspose.com/slides/androidjava/powerpoint-animation/), [Animation de Forme](https://docs.aspose.com/slides/androidjava/shape-animation/), et [Effet de Forme](https://docs.aspose.com/slides/androidjava/shape-effect/).

{{% /alert %}}

Les animations et transitions rendent les diaporamas plus engageants et intéressants—et font de même pour les vidéos. Ajoutons une autre diapositive et une transition au code pour la présentation précédente :

```java
// Ajoute une forme de sourire et l'anime

// ...

// Ajoute une nouvelle diapositive et une transition animée

ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

newSlide.getBackground().setType(BackgroundType.OwnBackground);

newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

newSlide.getSlideShowTransition().setType(TransitionType.Push);
```

Aspose.Slides prend également en charge l'animation des textes. Nous animons donc des paragraphes sur des objets, qui apparaîtront un après l'autre (avec un délai fixé à une seconde) :

```java
Presentation presentation = new Presentation();
try {
    // Ajoute du texte et des animations
    IAutoShape autoShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 210, 120, 300, 300);
    Paragraph para1 = new Paragraph();
    para1.getPortions().add(new Portion("Aspose Slides pour Java"));
    Paragraph para2 = new Paragraph();
    para2.getPortions().add(new Portion("convertir la présentation PowerPoint avec du texte en vidéo"));

    Paragraph para3 = new Paragraph();
    para3.getPortions().add(new Portion("paragraphe par paragraphe"));
    IParagraphCollection paragraphCollection = autoShape.getTextFrame().getParagraphs();
    paragraphCollection.add(para1);
    paragraphCollection.add(para2);
    paragraphCollection.add(para3);
    paragraphCollection.add(new Paragraph());

    ISequence mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    IEffect effect1 = mainSequence.addEffect(para1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect2 = mainSequence.addEffect(para2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect3 = mainSequence.addEffect(para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect4 = mainSequence.addEffect(para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    effect1.getTiming().setTriggerDelayTime(1f);
    effect2.getTiming().setTriggerDelayTime(1f);
    effect3.getTiming().setTriggerDelayTime(1f);
    effect4.getTiming().setTriggerDelayTime(1f);

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

    // Configurez le dossier des binaires ffmpeg. Voir cette page : https://github.com/rosenbjerg/FFMpegCore#installation
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

Pour vous permettre d'effectuer des tâches de conversion PowerPoint en vidéo, Aspose.Slides fournit les classes [PresentationAnimationsGenerator](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationanimationsgenerator/) et [PresentationPlayer](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationplayer/).

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationanimationsgenerator/) vous permet de définir la taille de frame pour la vidéo (qui sera créée plus tard) à travers son constructeur. Si vous passez une instance de la présentation, `Presentation.SlideSize` sera utilisé et il génère des animations que [PresentationPlayer](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationplayer/) utilise.

Lorsque les animations sont générées, un événement `NewAnimation` est généré pour chaque animation subséquente, qui a le paramètre [IPresentationAnimationPlayer](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationanimationplayer/). Ce dernier est une classe qui représente un lecteur pour une animation séparée.

Pour travailler avec [IPresentationAnimationPlayer](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationanimationplayer/), les propriétés [Duration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationanimationplayer/#getDuration--) (la durée totale de l'animation) et la méthode [SetTimePosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-) sont utilisées. Chaque position d'animation est définie dans la plage *0 à durée*, et ensuite la méthode `GetFrame` retournera un BufferedImage qui correspond à l'état de l'animation à ce moment :

```java
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
            System.out.println(String.format("Durée totale de l'animation : %f", animationPlayer.getDuration()));
            animationPlayer.setTimePosition(0); // état initial de l'animation
            try {
                // bitmap d'état initial de l'animation
                animationPlayer.getFrame().save("firstFrame.png", ImageFormat.Png);
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
            animationPlayer.setTimePosition(animationPlayer.getDuration()); // état final de l'animation
            try {
                // dernière frame de l'animation
                animationPlayer.getFrame().save("lastFrame.png", ImageFormat.Png);
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
        });
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

Pour faire jouer toutes les animations d'une présentation en même temps, la classe [PresentationPlayer](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationplayer/) est utilisée. Cette classe prend une instance de [PresentationAnimationsGenerator](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentationanimationsgenerator/) et un FPS pour les effets dans son constructeur, et appelle ensuite l'événement `FrameTick` pour toutes les animations afin de les faire jouer :

```java
Presentation presentation = new Presentation("animated.pptx");
try {
    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, 33);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                try {
                    arguments.getFrame().save("frame_" + sender.getFrameIndex() + ".png", ImageFormat.Png);
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
} finally {
    if (presentation != null) presentation.dispose();
}
```

Ensuite, les frames générées peuvent être compilées pour produire une vidéo. Voir la section [Convertir PowerPoint en Vidéo](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Animations et Effets Supportés**

**Entrée** :

| Type d'Animation | Aspose.Slides | PowerPoint |
|---|---|---|
| **Apparaître** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Fondu** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Entrée en Vol** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Entrée Flottante** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Scinder** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Essuyer** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Forme** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Roue** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Barres Aléatoires** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Croître & Tourner** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Zoomer** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Rotation** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Rebondir** | ![pris en charge](v.png) | ![pris en charge](v.png) |

**Accentuation** :

| Type d'Animation | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Pulse de Couleur** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Balancement** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Rotation** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Croître/Réduire** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Désaturer** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Assombrir** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Éclaircir** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Transparence** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Couleur d'Objet** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Couleur Complémentaire** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Couleur de Ligne** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Couleur de Remplissage** | ![non pris en charge](x.png) | ![pris en charge](v.png) |

**Sortie** :

| Type d'Animation | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disparaître** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Fondu** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Sortie en Vol** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Sortie Flottante** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Scinder** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Essuyer** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Forme** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Barres Aléatoires** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Réduire & Tourner** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Zoomer** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Rotation** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Rebondir** | ![pris en charge](v.png) | ![pris en charge](v.png) |

**Chemins de Mouvement :**

| Type d'Animation | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lignes** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Arcs** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Virages** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Formes** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Boucles** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Chemin Personnalisé** | ![pris en charge](v.png) | ![pris en charge](v.png) |