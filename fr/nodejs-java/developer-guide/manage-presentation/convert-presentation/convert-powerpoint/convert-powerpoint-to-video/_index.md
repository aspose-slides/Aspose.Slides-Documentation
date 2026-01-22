---
title: Convertir les présentations PowerPoint en vidéo avec JavaScript
linktitle: PowerPoint en vidéo
type: docs
weight: 130
url: /fr/nodejs-java/convert-powerpoint-to-video/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Apprenez comment convertir des présentations PowerPoint en vidéo avec JavaScript. Découvrez du code d'exemple et des techniques d'automatisation pour optimiser votre flux de travail."
---

En convertissant votre présentation PowerPoint en vidéo, vous obtenez 

* **Augmentation de l'accessibilité :** Tous les appareils (indépendamment de la plateforme) sont équipés par défaut de lecteurs vidéo, contrairement aux applications d'ouverture de présentations, ce qui permet aux utilisateurs d'ouvrir ou de lire plus facilement les vidéos.
* **Portée accrue :** Grâce aux vidéos, vous pouvez atteindre un large public et le cibler avec des informations qui pourraient autrement sembler fastidieuses dans une présentation. La plupart des enquêtes et des statistiques suggèrent que les gens regardent et consomment davantage les vidéos que les autres formes de contenu, et ils préfèrent généralement ce type de contenu.

{{% alert color="primary" %}} 
Vous voudrez peut‑être consulter notre [**Convertisseur en ligne PowerPoint en vidéo**](https://products.aspose.app/slides/conversion/ppt-to-word) car il s’agit d’une implémentation en direct et efficace du processus décrit ici.
{{% /alert %}} 

## **Conversion de PowerPoint en vidéo avec Aspose.Slides**

Aspose.Slides prend en charge la conversion de présentations en vidéo.

* Utilisez **Aspose.Slides** pour générer un ensemble d’images (à partir des diapositives de la présentation) qui correspondent à un certain nombre de FPS (images par seconde)
* Utilisez un utilitaire tiers comme **ffmpeg** ([for java](https://github.com/bramp/ffmpeg-cli-wrapper)) pour créer une vidéo à partir des images. 

### **Convertir PowerPoint en vidéo**

1. Téléchargez ffmpeg [ici](https://ffmpeg.org/download.html).
2. Exécutez le code JavaScript de conversion PowerPoint en vidéo.

Ce code JavaScript vous montre comment convertir une présentation (contenant une figure et deux effets d’animation) en vidéo :
```javascript
var presentation = new aspose.slides.Presentation();
try {
    // Ajoute une forme sourire puis l'anime
    var smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.SmileyFace, 110, 20, 500, 500);
    var mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    var effectIn = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.TopLeft, aspose.slides.EffectTriggerType.AfterPrevious);
    var effectOut = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.BottomRight, aspose.slides.EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2.0);
    effectOut.setPresetClassType(aspose.slides.EffectPresetClassType.Exit);
    final var fps = 33;
    var frames = java.newInstanceSync("java.util.ArrayList");
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        var player = new aspose.slides.PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) -> {
                try {
                    var frame = java.callStaticMethodSync("java.lang.String", "format", "frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, aspose.slides.ImageFormat.Png);
                    frames.add(frame);
                } catch (e) {console.log(e);
                    throw java.newInstanceSync("java.lang.RuntimeException", e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) {
                player.dispose();
            }
        }
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
    // Configure le dossier des exécutables ffmpeg. Voir cette page: https://github.com/rosenbjerg/FFMpegCore#installation
    var ffmpeg = java.newInstanceSync("FFmpeg", "path/to/ffmpeg");
    var ffprobe = java.newInstanceSync("FFprobe", "path/to/ffprobe");
    var builder = java.newInstanceSync("FFmpegBuilder").addExtraArgs("-start_number", "1").setInput("frame_%04d.png").addOutput("output.avi").setVideoFrameRate(java.getStaticFieldValue("FFmpeg", "FPS_24")).setFormat("avi").done();
    var executor = java.newInstanceSync("FFmpegExecutor", ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (e) {console.log(e);
    console.log(e);
}
```


## **Effets vidéo**

Vous pouvez appliquer des animations aux objets sur les diapositives et utiliser des transitions entre les diapositives. 

{{% alert color="primary" %}} 
Vous voudrez peut‑être consulter ces articles : [Animation PowerPoint](https://docs.aspose.com/slides/nodejs-java/powerpoint-animation/), [Animation de forme](https://docs.aspose.com/slides/nodejs-java/shape-animation/), et [Effet de forme](https://docs.aspose.com/slides/nodejs-java/shape-effect/).
{{% /alert %}} 

Les animations et les transitions rendent les diaporamas plus attrayants et intéressants — et elles font la même chose pour les vidéos. Ajoutons une autre diapositive et une transition au code de la présentation précédente :
```javascript
// Ajoute une forme sourire et l'anime
// ...
// Ajoute une nouvelle diapositive et une transition animée
var newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());
newSlide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
newSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
newSlide.getSlideShowTransition().setType(aspose.slides.TransitionType.Push);
```


Aspose.Slides prend également en charge l’animation du texte. Nous animons donc les paragraphes sur les objets, qui apparaîtront les uns après les autres (avec le délai réglé à une seconde) :
```javascript
var presentation = new aspose.slides.Presentation();
try {
    // Ajoute du texte et des animations
    var autoShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 120, 300, 300);
    var para1 = new aspose.slides.Paragraph();
    para1.getPortions().add(new aspose.slides.Portion("Aspose Slides for Node.js via Java"));
    var para2 = new aspose.slides.Paragraph();
    para2.getPortions().add(new aspose.slides.Portion("convert PowerPoint Presentation with text to video"));
    var para3 = new aspose.slides.Paragraph();
    para3.getPortions().add(new aspose.slides.Portion("paragraph by paragraph"));
    var paragraphCollection = autoShape.getTextFrame().getParagraphs();
    paragraphCollection.add(para1);
    paragraphCollection.add(para2);
    paragraphCollection.add(para3);
    paragraphCollection.add(new aspose.slides.Paragraph());
    var mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    var effect1 = mainSequence.addEffect(para1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    var effect2 = mainSequence.addEffect(para2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    var effect3 = mainSequence.addEffect(para3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    var effect4 = mainSequence.addEffect(para3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    effect1.getTiming().setTriggerDelayTime(1.0);
    effect2.getTiming().setTriggerDelayTime(1.0);
    effect3.getTiming().setTriggerDelayTime(1.0);
    effect4.getTiming().setTriggerDelayTime(1.0);
    final var fps = 33;
    var frames = java.newInstanceSync("java.util.ArrayList");
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        var player = new aspose.slides.PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) -> {
                try {
                    var frame = java.callStaticMethodSync("java.lang.String", "format", "frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, aspose.slides.ImageFormat.Png);
                    frames.add(frame);
                } catch (e) {console.log(e);
                    throw java.newInstanceSync("java.lang.RuntimeException", e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) {
                player.dispose();
            }
        }
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
    // Configure le dossier des exécutables ffmpeg. Voir cette page: https://github.com/rosenbjerg/FFMpegCore#installation
    var ffmpeg = java.newInstanceSync("FFmpeg", "path/to/ffmpeg");
    var ffprobe = java.newInstanceSync("FFprobe", "path/to/ffprobe");
    var builder = java.newInstanceSync("FFmpegBuilder").addExtraArgs("-start_number", "1").setInput("frame_%04d.png").addOutput("output.avi").setVideoFrameRate(java.getStaticFieldValue("FFmpeg", "FPS_24")).setFormat("avi").done();
    var executor = java.newInstanceSync("FFmpegExecutor", ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (e) {console.log(e);
    console.log(e);
}
```


## **Classes de conversion vidéo**

Pour vous permettre d’effectuer des tâches de conversion PowerPoint en vidéo, Aspose.Slides fournit les classes [PresentationAnimationsGenerator](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationanimationsgenerator/) et [PresentationPlayer](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationplayer/).

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationanimationsgenerator/) vous permet de définir la taille du cadre pour la vidéo (qui sera créée plus tard) via son constructeur. Si vous transmettez une instance de la présentation, `Presentation.getSlideSize` sera utilisé et il génère des animations que [PresentationPlayer](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationplayer/) utilise.

Lorsque les animations sont générées, un événement `NewAnimation` est créé pour chaque animation suivante, contenant le paramètre du lecteur d’animation de la présentation. Ce dernier est une classe qui représente un lecteur pour une animation distincte.

Pour travailler avec le lecteur d’animation de la présentation, les méthodes `getDuration` (la durée totale de l’animation) et `setTimePosition` sont utilisées. Chaque position d’animation est définie dans la plage *0 à durée*, puis la méthode `getFrame` renvoie un `BufferedImage` correspondant à l’état de l’animation à ce moment‑là :
```javascript
var presentation = new aspose.slides.Presentation();
try {
    // Ajoute une forme sourire et l'anime
    var smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.SmileyFace, 110, 20, 500, 500);
    var mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    var effectIn = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.TopLeft, aspose.slides.EffectTriggerType.AfterPrevious);
    var effectOut = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.BottomRight, aspose.slides.EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2.0);
    effectOut.setPresetClassType(aspose.slides.EffectPresetClassType.Exit);
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        animationsGenerator.setNewAnimation(animationPlayer -> {
            console.log(java.callStaticMethodSync("java.lang.String", "format", "Animation total duration: %f", animationPlayer.getDuration()));
            animationPlayer.setTimePosition(0);// état initial de l'animation
            try {
                // bitmap de l'état initial de l'animation
                animationPlayer.getFrame().save("firstFrame.png", aspose.slides.ImageFormat.Png);
            } catch (e) {console.log(e);
                throw java.newInstanceSync("java.lang.RuntimeException", e);
            }
            animationPlayer.setTimePosition(animationPlayer.getDuration());// état final de l'animation
            try {
                // dernière image de l'animation
                animationPlayer.getFrame().save("lastFrame.png", aspose.slides.ImageFormat.Png);
            } catch (e) {console.log(e);
                throw java.newInstanceSync("java.lang.RuntimeException", e);
            }
        });
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


Pour faire jouer toutes les animations d’une présentation en même temps, on utilise la classe [PresentationPlayer](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationplayer/). Cette classe prend une instance de [PresentationAnimationsGenerator](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentationanimationsgenerator/) et le FPS des effets dans son constructeur, puis déclenche l’événement `FrameTick` pour toutes les animations afin de les faire lire :
```javascript
var presentation = new aspose.slides.Presentation("animated.pptx");
try {
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        var player = new aspose.slides.PresentationPlayer(animationsGenerator, 33);
        try {
            player.setFrameTick((sender, arguments) -> {
                try {
                    arguments.getFrame().save(("frame_" + sender.getFrameIndex()) + ".png", aspose.slides.ImageFormat.Png);
                } catch (e) {console.log(e);
                    throw java.newInstanceSync("java.lang.RuntimeException", e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) {
                player.dispose();
            }
        }
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


Ensuite, les cadres générés peuvent être compilés pour produire une vidéo. Voir la section [Convertir PowerPoint en vidéo](https://docs.aspose.com/slides/nodejs-java/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Animations et effets pris en charge**

**Entrée** :

| Type d'animation | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly In** | ![supported](v.png) | ![supported](v.png) |
| **Float In** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Grow & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |

**Mise en évidence** :

| Type d'animation | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Color Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Teeter** | ![supported](v.png) | ![supported](v.png) |
| **Spin** | ![supported](v.png) | ![supported](v.png) |
| **Grow/Shrink** | ![not supported](x.png) | ![supported](v.png) |
| **Desaturate** | ![not supported](x.png) | ![supported](v.png) |
| **Darken** | ![not supported](x.png) | ![supported](v.png) |
| **Lighten** | ![not supported](x.png) | ![supported](v.png) |
| **Transparency** | ![not supported](x.png) | ![supported](v.png) |
| **Object Color** | ![not supported](x.png) | ![supported](v.png) |
| **Complementary Color** | ![not supported](x.png) | ![supported](v.png) |
| **Line Color** | ![not supported](x.png) | ![supported](v.png) |
| **Fill Color** | ![not supported](x.png) | ![supported](v.png) |

**Sortie** :

| Type d'animation | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly Out** | ![supported](v.png) | ![supported](v.png) |
| **Float Out** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Shrink & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |

**Chemins de mouvement** :

| Type d'animation | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **FAQ**

**Est‑il possible de convertir des présentations protégées par mot de passe ?**

Oui, Aspose.Slides permet de travailler avec des présentations protégées par mot de passe. Lors du traitement de ces fichiers, vous devez fournir le mot de passe correct afin que la bibliothèque puisse accéder au contenu de la présentation.

**Aspose.Slides prend‑il en charge une utilisation dans des solutions cloud ?**

Oui, Aspose.Slides peut être intégré aux applications et services cloud. La bibliothèque est conçue pour fonctionner dans des environnements serveur, assurant haute performance et évolutivité pour le traitement par lots de fichiers.

**Existe‑t‑il des limitations de taille pour les présentations lors de la conversion ?**

Aspose.Slides est capable de gérer des présentations de taille pratiquement illimitée. Cependant, pour des fichiers très volumineux, des ressources système supplémentaires peuvent être requises, et il est parfois recommandé d’optimiser la présentation afin d’améliorer les performances.