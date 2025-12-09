---
title: Convertir des présentations PowerPoint en vidéo dans .NET
linktitle: PowerPoint en vidéo
type: docs
weight: 130
url: /fr/net/convert-powerpoint-to-video/
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
- .NET
- C#
- Aspose.Slides
description: "Apprenez comment convertir des présentations PowerPoint en vidéo dans .NET. Découvrez du code C# d'exemple et des techniques d'automatisation pour rationaliser votre flux de travail."
---

## **Aperçu**

En convertissant votre présentation PowerPoint ou OpenDocument en vidéo, vous obtenez :

**Accessibilité accrue :** Tous les appareils, quelle que soit la plateforme, sont équipés de lecteurs vidéo par défaut, ce qui facilite l’ouverture ou la lecture des vidéos comparé aux applications de présentation traditionnelles.

**Portée élargie :** Les vidéos vous permettent d’atteindre un public plus large et de présenter les informations sous un format plus engageant. Les enquêtes et les statistiques indiquent que les gens préfèrent regarder et consommer du contenu vidéo plutôt que d’autres formes, rendant votre message plus percutant.

{{% alert color="primary" %}} 

Découvrez notre [**Convertisseur en ligne PowerPoint vers Vidéo**](https://products.aspose.app/slides/video) car il propose une implémentation en direct et efficace du processus décrit ici.

{{% /alert %}} 

Dans Aspose.Slides for .NET, nous avons implémenté la prise en charge de la conversion des présentations en vidéo.

* Utilisez Aspose.Slides for .NET pour générer des images à partir des diapositives de la présentation à une fréquence d’images spécifiée (FPS).
* Puis, utilisez un utilitaire tiers comme ffmpeg pour assembler ces images en une vidéo.

## **Convertir une présentation PowerPoint en vidéo**

1. Utilisez la commande `dotnet add package` pour ajouter Aspose.Slides et la bibliothèque FFMpegCore à votre projet :
   * exécutez `dotnet add package Aspose.Slides.NET --version 22.11.0`
   * exécutez `dotnet add package FFMpegCore --version 4.8.0`
2. Téléchargez ffmpeg depuis [ici](https://ffmpeg.org/download.html).
3. FFMpegCore nécessite que vous spécifiiez le chemin vers le ffmpeg téléchargé (par ex., extrait dans "C:\tools\ffmpeg") :  
```cs
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });
```

4. Exécutez le code de conversion PowerPoint en vidéo.

Ce code C# montre comment convertir une présentation (containing a shape and two animation effects) en vidéo :
```c#
using System.Collections.Generic;
using Aspose.Slides;
using FFMpegCore; // utilisera les binaires FFmpeg que nous avons extraits vers C:\tools\ffmpeg plus tôt.
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Ajoutez une forme sourire puis animez‑la.
    IAutoShape smile = slide.Shapes.AddAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);

    IEffect effectIn = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);

    IEffect effectOut = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);

    effectIn.Timing.Duration = 2f;
    effectOut.PresetClassType = EffectPresetClassType.Exit;

    const int Fps = 33;
    List<string> frames = new List<string>();

    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    using (var player = new PresentationPlayer(animationsGenerator, Fps))
    {
        player.FrameTick += (sender, args) =>
        {
            string frame = $"frame_{(sender.FrameIndex):D4}.png";
            args.GetFrame().Save(frame);
            frames.Add(frame);
        };
        animationsGenerator.Run(presentation.Slides);
    }

    // Configurez le dossier des binaires ffmpeg. Voir cette page: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // Convertissez les images en vidéo webm.
    FFMpeg.JoinImageSequence("smile.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```


## **Effets vidéo**

Lors de la conversion d’une présentation PowerPoint en vidéo avec Aspose.Slides for .NET, vous pouvez appliquer divers effets vidéo pour améliorer la qualité visuelle du résultat. Ces effets vous permettent de contrôler l’apparence des diapositives dans la vidéo finale en ajoutant des transitions fluides, des animations et d’autres éléments visuels. Cette section explique les options d’effet vidéo disponibles et montre comment les appliquer.

{{% alert color="primary" %}} 

Voir :
- [Améliorer les présentations PowerPoint avec des animations en C#](https://docs.aspose.com/slides/net/powerpoint-animation/)
- [Animation de forme](https://docs.aspose.com/slides/net/shape-animation/)
- [Appliquer des effets de forme dans PowerPoint avec C#](https://docs.aspose.com/slides/net/shape-effect/)

{{% /alert %}} 

Les animations et les transitions rendent les diaporamas plus engageants et intéressants — et il en va de même pour les vidéos. Ajoutons une autre diapositive et une transition au code de la présentation précédente :
```c#
// Ajoutez une forme sourire et animez‑la.
// ...

// Ajoutez une nouvelle diapositive et une transition animée.
ISlide newSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
newSlide.Background.Type = BackgroundType.OwnBackground;
newSlide.Background.FillFormat.FillType = FillType.Solid;
newSlide.Background.FillFormat.SolidFillColor.Color = Color.Indigo;
newSlide.SlideShowTransition.Type = TransitionType.Push;
```


Aspose.Slides prend également en charge les animations de texte. Dans cet exemple, nous animons les paragraphes sur des objets afin qu’ils apparaissent les uns après les autres, avec un délai d’une seconde entre chaque :
```c#
using System.Collections.Generic;
using Aspose.Slides.Export;
using Aspose.Slides;
using FFMpegCore;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Ajouter du texte et des animations.
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 120, 300, 300);
    Paragraph para1 = new Paragraph();
    para1.Portions.Add(new Portion("Aspose Slides for .NET"));
    Paragraph para2 = new Paragraph();
    para2.Portions.Add(new Portion("Convert a PowerPoint presentation with text to video"));

    Paragraph para3 = new Paragraph();
    para3.Portions.Add(new Portion("paragraph by paragraph"));
    autoShape.TextFrame.Paragraphs.Add(para1);
    autoShape.TextFrame.Paragraphs.Add(para2);
    autoShape.TextFrame.Paragraphs.Add(para3);
    autoShape.TextFrame.Paragraphs.Add(new Paragraph());

    IEffect effect1 = slide.Timeline.MainSequence.AddEffect(
        para1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect2 = slide.Timeline.MainSequence.AddEffect(
        para2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect3 = slide.Timeline.MainSequence.AddEffect(
        para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect4 = slide.Timeline.MainSequence.AddEffect(
        para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    effect1.Timing.TriggerDelayTime = 1f;
    effect2.Timing.TriggerDelayTime = 1f;
    effect3.Timing.TriggerDelayTime = 1f;
    effect4.Timing.TriggerDelayTime = 1f;

    const int Fps = 33;
    List<string> frames = new List<string>();

    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    using (var player = new PresentationPlayer(animationsGenerator, Fps))
    {
        player.FrameTick += (sender, args) =>
        {
            string frame = $"frame_{(sender.FrameIndex):D4}.png";
            args.GetFrame().Save(frame);
            frames.Add(frame);
        };

        animationsGenerator.Run(presentation.Slides);
    }

    // Configurer le dossier des binaires ffmpeg. Voir cette page : https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // Convertir les images en vidéo webm.
    FFMpeg.JoinImageSequence("text_animation.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```


## **Classes de conversion vidéo**

Pour activer les tâches de conversion PowerPoint en vidéo, Aspose.Slides for .NET fournit les classes [PresentationAnimationsGenerator](https://reference.aspose.com/slides/net/aspose.slides.export/presentationanimationsgenerator/) et [PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/).

`PresentationAnimationsGenerator` vous permet de définir la taille du cadre pour la vidéo (qui sera créée ultérieurement) et la valeur FPS (images par seconde) via son constructeur. Si vous transmettez une instance d’une présentation, son `Presentation.SlideSize` sera utilisé et il génère des animations que [PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/) utilise.

Lorsque les animations sont générées, un événement `NewAnimation` est déclenché pour chaque animation suivante, incluant un paramètre [IPresentationAnimationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/). Cette classe représente un lecteur pour une animation individuelle.

Pour travailler avec [IPresentationAnimationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/), vous utilisez la propriété [Duration](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/duration/) (qui donne la durée totale de l’animation) et la méthode [SetTimePosition](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/settimeposition/). Chaque position d’animation est définie dans la plage *0 à duration*, et la méthode `GetFrame` renvoie alors un Bitmap représentant l’état de l’animation à ce moment‑là.
```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Ajoutez une forme sourire et animez‑la.
    IAutoShape smile = slide.Shapes.AddAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);

    IEffect effectIn = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);

    IEffect effectOut = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);

    effectIn.Timing.Duration = 2f;
    effectOut.PresetClassType = EffectPresetClassType.Exit;

    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    {
        animationsGenerator.NewAnimation += animationPlayer =>
        {
            Console.WriteLine($"Total animation duration: {animationPlayer.Duration}");

            animationPlayer.SetTimePosition(0);          // L'état initial de l'animation.
            Bitmap bitmap = animationPlayer.GetFrame();  // Le bitmap de l'état initial de l'animation.

            animationPlayer.SetTimePosition(animationPlayer.Duration);  // L'état final de l'animation.
            Bitmap lastBitmap = animationPlayer.GetFrame();             // La dernière image de l'animation.
            lastBitmap.Save("last.png");
        };
    }
}
```


Pour faire jouer toutes les animations d’une présentation simultanément, la classe [PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/) est utilisée. Cette classe prend une instance de [PresentationAnimationsGenerator](https://reference.aspose.com/slides/net/aspose.slides.export/presentationanimationsgenerator/) et une valeur FPS pour les effets dans son constructeur, puis appelle l’événement `FrameTick` pour toutes les animations afin de les lire :
```c#
using (Presentation presentation = new Presentation("animated.pptx"))
{
    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    using (var player = new PresentationPlayer(animationsGenerator, 33))
    {
        player.FrameTick += (sender, args) =>
        {
            args.GetFrame().Save($"frame_{sender.FrameIndex}.png");
        };
        animationsGenerator.Run(presentation.Slides);
    }
}
```


Ensuite, les images générées peuvent être assemblées pour produire une vidéo. Voir la section [Convertir une présentation PowerPoint en vidéo](/slides/fr/net/convert-powerpoint-to-video/#convert-a-powerpoint-presentation-to-video).

## **Animations et effets pris en charge**

Lors de la conversion d’une présentation PowerPoint en vidéo avec Aspose.Slides for .NET, il est important de connaître les animations et effets pris en charge dans le résultat. Aspose.Slides prend en charge un large éventail d’effets d’entrée, de sortie et d’accentuation courants tels que fondu, vol, zoom et rotation. Cependant, certaines animations avancées ou personnalisées peuvent ne pas être entièrement conservées ou apparaître différemment dans la vidéo finale. Cette section décrit les animations et effets pris en charge.

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

**Accentuation** :

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

## **Effets de transition de diapositive pris en charge**

Les effets de transition de diapositive jouent un rôle important dans la création de changements fluides et visuellement attrayants entre les diapositives d’une vidéo. Aspose.Slides for .NET prend en charge une variété d’effets de transition couramment utilisés afin de préserver le flux et le style de votre présentation d’origine. Cette section met en évidence les effets de transition pris en charge pendant le processus de conversion.

**Subtil** :

| Type d'animation | Aspose.Slides | PowerPoint |
|---|---|---|
| **Morph** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Fade** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Push** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Pull** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Wipe** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Split** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Reveal** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Random Bars** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Shape** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Uncover** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Cover** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Flash** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Strips** | ![pris en charge](v.png) | ![pris en charge](v.png) |

**Excitant** :

| Type d'animation | Aspose.Slides | PowerPoint |
|---|---|---|
| **Fall Over** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Drape** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Curtains** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Wind** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Prestige** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Fracture** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Crush** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Peel Off** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Page Curl** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Airplane** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Origami** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Dissolve** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Checkerboard** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Blinds** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Clock** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Ripple** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Honeycomb** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Glitter** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Vortex** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Shred** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Switch** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Flip** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Gallery** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Cube** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Doors** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Box** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Comb** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Zoom** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Random** | ![non pris en charge](x.png) | ![pris en charge](v.png) |

**Contenu dynamique** :

| Type d'animation | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pan** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Ferris Wheel** | ![pris en charge](v.png) | ![pris en charge](v.png) |
| **Conveyor** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Rotate** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Orbit** | ![non pris en charge](x.png) | ![pris en charge](v.png) |
| **Fly Through** | ![pris en charge](v.png) | ![pris en charge](v.png) |

## **FAQ**

**Est‑il possible de convertir des présentations protégées par mot de passe ?**

Oui, Aspose.Slides for .NET permet de travailler avec des présentations protégées par mot de passe. Lors du traitement de ces fichiers, vous devez fournir le mot de passe correct afin que la bibliothèque puisse accéder au contenu de la présentation.

**Aspose.Slides for .NET prend‑il en charge une utilisation dans les solutions cloud ?**

Oui, Aspose.Slides for .NET peut être intégré aux applications et services cloud. La bibliothèque est conçue pour fonctionner dans des environnements serveur, garantissant haute performance et évolutivité pour le traitement par lots de fichiers.

**Existe‑t‑il des limitations de taille pour les présentations lors de la conversion ?**

Aspose.Slides for .NET est capable de gérer des présentations de pratiquement n’importe quelle taille. Cependant, lors du traitement de fichiers très volumineux, des ressources système supplémentaires peuvent être nécessaires, et il est parfois recommandé d’optimiser la présentation afin d’améliorer les performances.