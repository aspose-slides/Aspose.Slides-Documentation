---
title: Convertir PowerPoint en Vidéo
type: docs
weight: 130
url: /java/convert-powerpoint-to-video/
keywords: "Convertir PowerPoint, PPT, PPTX, Présentation, Vidéo, MP4, PPT en vidéo, PPT en MP4, Java, Aspose.Slides"
description: "Convertir PowerPoint en Vidéo en Java"
---

En convertissant votre présentation PowerPoint en vidéo, vous obtenez 

* **Augmentation de l'accessibilité :** Tous les appareils (quel que soit la plateforme) sont par défaut équipés de lecteurs vidéo comparé aux applications d'ouverture de présentation, donc les utilisateurs trouvent plus facile d'ouvrir ou de lire des vidéos.
* **Plus de portée :** Grâce aux vidéos, vous pouvez atteindre un large public et le cibler avec des informations qui pourraient autrement sembler ennuyeuses dans une présentation. La plupart des enquêtes et statistiques suggèrent que les gens regardent et consomment des vidéos plus que d'autres formes de contenu, et ils préfèrent généralement ce type de contenu.

{{% alert color="primary" %}} 

Vous souhaitez peut-être consulter notre [**Convertisseur PowerPoint en Vidéo en Ligne**](https://products.aspose.app/slides/conversion/ppt-to-word) car c'est une implementation en direct et efficace du processus décrit ici.

{{% /alert %}} 

## **Conversion PowerPoint en Vidéo dans Aspose.Slides**

Dans [Aspose.Slides 22.11](https://docs.aspose.com/slides/java/aspose-slides-for-java-22-11-release-notes/), nous avons implémenté le support de la conversion de présentation en vidéo. 

* Utilisez **Aspose.Slides** pour générer un ensemble d'images (à partir des diapositives de présentation) qui correspondent à une certaine FPS (images par seconde)
* Utilisez un utilitaire tiers comme **ffmpeg** ([pour java](https://github.com/bramp/ffmpeg-cli-wrapper)) pour créer une vidéo basée sur les images. 

### **Convertir PowerPoint en Vidéo**

1. Ajoutez cela à votre fichier POM :
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
    // Ajoute une forme sourire et l'anime
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

Vous souhaitez peut-être voir ces articles : [Animation PowerPoint](https://docs.aspose.com/slides/java/powerpoint-animation/), [Animation de forme](https://docs.aspose.com/slides/java/shape-animation/), et [Effet de forme](https://docs.aspose.com/slides/java/shape-effect/).

{{% /alert %}} 

Les animations et transitions rendent les diaporamas plus engageants et intéressants — et ils font la même chose pour les vidéos. Ajoutons une autre diapositive et une transition au code pour la présentation précédente :

```java
// Ajoute une forme sourire et l'anime

// ...

// Ajoute une nouvelle diapositive et une transition animée

ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

newSlide.getBackground().setType(BackgroundType.OwnBackground);

newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

newSlide.getSlideShowTransition().setType(TransitionType.Push);
```

Aspose.Slides prend également en charge l'animation des textes. Ainsi, nous animons les paragraphes sur des objets, qui apparaîtront les uns après les autres (avec le délai réglé à une seconde) :

```java
Presentation presentation = new Presentation();
try {
    // Ajoute du texte et des animations
    IAutoShape autoShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 210, 120, 300, 300);
    Paragraph para1 = new Paragraph();
    para1.getPortions().add(new Portion("Aspose Slides pour Java"));
    Paragraph para2 = new Paragraph();
    para2.getPortions().add(new Portion("convertir la présentation PowerPoint avec texte en vidéo"));

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

Pour vous permettre d'effectuer des tâches de conversion PowerPoint en vidéo, Aspose.Slides fournit les classes [PresentationAnimationsGenerator](https://reference.aspose.com/slides/java/com.aspose.slides/presentationanimationsgenerator/) et [PresentationPlayer](https://reference.aspose.com/slides/java/com.aspose.slides/presentationplayer/).

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/java/com.aspose.slides/presentationanimationsgenerator/) vous permet de définir la taille de l'image pour la vidéo (qui sera créée plus tard) via son constructeur. Si vous passez une instance de la présentation, `Presentation.SlideSize` sera utilisé et il génère des animations que [PresentationPlayer](https://reference.aspose.com/slides/java/com.aspose.slides/presentationplayer/) utilise. 

Lorsque les animations sont générées, un événement `NewAnimation` est généré pour chaque animation suivante, qui a le paramètre [IPresentationAnimationPlayer](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationanimationplayer/). Ce dernier est une classe qui représente un lecteur pour une animation distincte.

Pour travailler avec [IPresentationAnimationPlayer](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationanimationplayer/), la propriété [Duration](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationanimationplayer/#getDuration--) (la durée totale de l'animation) et la méthode [SetTimePosition](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-) sont utilisées. Chaque position d'animation est définie dans l'intervalle *0 à durée*, et ensuite la méthode `GetFrame` renverra un BufferedImage qui correspond à l'état de l'animation à ce moment :

```java
Presentation presentation = new Presentation();
try {
    // Ajoute une forme sourire et l'anime
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
                // bitmap de l'état initial de l'animation
                animationPlayer.getFrame().save("firstFrame.png", ImageFormat.Png);
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
            animationPlayer.setTimePosition(animationPlayer.getDuration()); // état final de l'animation
            try {
                // dernière image de l'animation
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

Pour que toutes les animations dans une présentation se jouent en même temps, la classe [PresentationPlayer](https://reference.aspose.com/slides/java/com.aspose.slides/presentationplayer/) est utilisée. Cette classe prend une instance de [PresentationAnimationsGenerator](https://reference.aspose.com/slides/java/com.aspose.slides/presentationanimationsgenerator/) et FPS pour les effets dans son constructeur et appelle ensuite l'événement `FrameTick` pour toutes les animations afin de les jouer :

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

Ensuite, les images générées peuvent être compilées pour produire une vidéo. Voir la section [Convertir PowerPoint en Vidéo](https://docs.aspose.com/slides/java/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Animations et Effets Supportés**

**Entrée** :

| Type d'Animation | Aspose.Slides | PowerPoint |
|---|---|---|
| **Apparaître** | ![non supporté](x.png) | ![supporté](v.png) |
| **Fondu** | ![supporté](v.png) | ![supporté](v.png) |
| **Entrée en Vol** | ![supporté](v.png) | ![supporté](v.png) |
| **Entrée Flottante** | ![supporté](v.png) | ![supporté](v.png) |
| **Division** | ![supporté](v.png) | ![supporté](v.png) |
| **Essuyage** | ![supporté](v.png) | ![supporté](v.png) |
| **Forme** | ![supporté](v.png) | ![supporté](v.png) |
| **Roue** | ![supporté](v.png) | ![supporté](v.png) |
| **Barres Aléatoires** | ![supporté](v.png) | ![supporté](v.png) |
| **Grandir & Tourner** | ![non supporté](x.png) | ![supporté](v.png) |
| **Zoom** | ![supporté](v.png) | ![supporté](v.png) |
| **Rotation** | ![supporté](v.png) | ![supporté](v.png) |
| **Rebond** | ![supporté](v.png) | ![supporté](v.png) |

**Accentuation** :

| Type d'Animation | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pouls** | ![non supporté](x.png) | ![supporté](v.png) |
| **Pouls de Couleur** | ![non supporté](x.png) | ![supporté](v.png) |
| **Balancement** | ![supporté](v.png) | ![supporté](v.png) |
| **Rotation** | ![supporté](v.png) | ![supporté](v.png) |
| **Grandir/Réduire** | ![non supporté](x.png) | ![supporté](v.png) |
| **Désaturer** | ![non supporté](x.png) | ![supporté](v.png) |
| **Assombrir** | ![non supporté](x.png) | ![supporté](v.png) |
| **Éclaircir** | ![non supporté](x.png) | ![supporté](v.png) |
| **Transparence** | ![non supporté](x.png) | ![supporté](v.png) |
| **Couleur d'Objet** | ![non supporté](x.png) | ![supporté](v.png) |
| **Couleur Complémentaire** | ![non supporté](x.png) | ![supporté](v.png) |
| **Couleur de Ligne** | ![non supporté](x.png) | ![supporté](v.png) |
| **Couleur de Remplissage** | ![non supporté](x.png) | ![supporté](v.png) |

**Sortie** :

| Type d'Animation | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disparaître** | ![non supporté](x.png) | ![supporté](v.png) |
| **Fondu** | ![supporté](v.png) | ![supporté](v.png) |
| **Sortie en Vol** | ![supporté](v.png) | ![supporté](v.png) |
| **Sortie Flottante** | ![supporté](v.png) | ![supporté](v.png) |
| **Division** | ![supporté](v.png) | ![supporté](v.png) |
| **Essuyage** | ![supporté](v.png) | ![supporté](v.png) |
| **Forme** | ![supporté](v.png) | ![supporté](v.png) |
| **Barres Aléatoires** | ![supporté](v.png) | ![supporté](v.png) |
| **Réduire & Tourner** | ![non supporté](x.png) | ![supporté](v.png) |
| **Zoom** | ![supporté](v.png) | ![supporté](v.png) |
| **Rotation** | ![supporté](v.png) | ![supporté](v.png) |
| **Rebond** | ![supporté](v.png) | ![supporté](v.png) |

**Chemins de Mouvement :**

| Type d'Animation | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lignes** | ![supporté](v.png) | ![supporté](v.png) |
| **Arcs** | ![supporté](v.png) | ![supporté](v.png) |
| **Virages** | ![supporté](v.png) | ![supporté](v.png) |
| **Formes** | ![supporté](v.png) | ![supporté](v.png) |
| **Boucles** | ![supporté](v.png) | ![supporté](v.png) |
| **Chemin Personnalisé** | ![supporté](v.png) | ![supporté](v.png) |