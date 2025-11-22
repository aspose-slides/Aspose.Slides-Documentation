---
title: Convertir les présentations PowerPoint en vidéo en C#
linktitle: PowerPoint en vidéo
type: docs
weight: 130
url: /fr/net/convert-powerpoint-to-video/
keywords:
- PowerPoint en vidéo
- convertir PowerPoint en vidéo
- présentation en vidéo
- convertir présentation en vidéo
- PPT en vidéo
- convertir PPT en vidéo
- PPTX en vidéo
- convertir PPTX en vidéo
- ODP en vidéo
- convertir ODP en vidéo
- PowerPoint en MP4
- convertir PowerPoint en MP4
- présentation en MP4
- convertir présentation en MP4
- PPT en MP4
- convertir PPT en MP4
- PPTX en MP4
- convertir PPTX en MP4
- conversion PowerPoint en vidéo
- conversion présentation en vidéo
- conversion PPT en vidéo
- conversion PPTX en vidéo
- conversion ODP en vidéo
- conversion vidéo C#
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: "Apprenez à convertir les présentations PowerPoint et OpenDocument en vidéo en utilisant C#. Découvrez des exemples de code et des techniques d'automatisation pour rationaliser votre flux de travail."
---

## **Aperçu**

En convertissant votre présentation PowerPoint ou OpenDocument en vidéo, vous obtenez :

**Accessibilité accrue :** Tous les appareils, quelle que soit la plateforme, sont équipés de lecteurs vidéo par défaut, ce qui facilite l'ouverture ou la lecture des vidéos par rapport aux applications de présentation traditionnelles.

**Portée plus large :** Les vidéos vous permettent d'atteindre un public plus vaste et de présenter l'information sous un format plus attrayant. Les sondages et les statistiques indiquent que les gens préfèrent regarder et consommer du contenu vidéo plutôt que d'autres formes, rendant votre message plus percutant.

{{% alert color="primary" %}} 
Découvrez notre [**Convertisseur en ligne PowerPoint en Vidéo**](https://products.aspose.app/slides/video) car il offre une implémentation en direct et efficace du processus décrit ici.
{{% /alert %}} 

Dans Aspose.Slides for .NET, nous avons implémenté la prise en charge de la conversion des présentations en vidéo.

* Utilisez Aspose.Slides for .NET pour générer des images à partir des diapositives de la présentation à une fréquence d'images spécifiée (FPS).
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

4. Exécutez le code de conversion PowerPoint‑en‑vidéo.

Ce code C# montre comment convertir une présentation (contenant une forme et deux effets d’animation) en vidéo :
```c#
using System.Collections.Generic;
using Aspose.Slides;
using FFMpegCore; // utilisera les binaires FFmpeg que nous avons extraits vers C:\tools\ffmpeg auparavant.
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Ajoutez une forme de sourire puis animez‑la.
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

    // Configurez le dossier des binaires ffmpeg. Voir cette page : https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // Convertissez les images en vidéo webm.
    FFMpeg.JoinImageSequence("smile.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```


## **Effets vidéo**

Lors de la conversion d’une présentation PowerPoint en vidéo avec Aspose.Slides for .NET, vous pouvez appliquer divers effets vidéo pour améliorer la qualité visuelle du résultat. Ces effets vous permettent de contrôler l’apparence des diapositives dans la vidéo finale en ajoutant des transitions fluides, des animations et d’autres éléments visuels. Cette section explique les options d’effets vidéo disponibles et montre comment les appliquer.

{{% alert color="primary" %}} 
Voir :
- [Améliorer les présentations PowerPoint avec des animations en C#](https://docs.aspose.com/slides/net/powerpoint-animation/)
- [Animation de forme](https://docs.aspose.com/slides/net/shape-animation/)
- [Appliquer des effets de forme dans PowerPoint avec C#](https://docs.aspose.com/slides/net/shape-effect/)
{{% /alert %}} 

Les animations et les transitions rendent les diaporamas plus attrayants et intéressants — et il en va de même pour les vidéos. Ajoutons une autre diapositive et une transition au code de la présentation précédente :
```c#
// Ajouter une forme de sourire et l'animer.
// ...

// Ajouter une nouvelle diapositive et une transition animée.
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

Pour activer les tâches de conversion PowerPoint → vidéo, Aspose.Slides for .NET fournit les classes [PresentationAnimationsGenerator](https://reference.aspose.com/slides/net/aspose.slides.export/presentationanimationsgenerator/) et [PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/).

`PresentationAnimationsGenerator` vous permet de définir la taille du cadre pour la vidéo (qui sera créée ultérieurement) et la valeur FPS (images par seconde) via son constructeur. Si vous transmettez une instance d’une présentation, son `Presentation.SlideSize` sera utilisé et il génère les animations que `PresentationPlayer` utilise.

Lorsque les animations sont générées, un événement `NewAnimation` est déclenché pour chaque animation successive, incluant un paramètre [IPresentationAnimationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/). Cette classe représente un lecteur pour une animation individuelle.

Pour travailler avec [IPresentationAnimationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/), vous utilisez la propriété [Duration](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/duration/) (qui donne la durée totale de l’animation) et la méthode [SetTimePosition](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/settimeposition/). Chaque position d’animation est définie dans l’intervalle *0 à duration*, et la méthode `GetFrame` renvoie alors un Bitmap représentant l’état de l’animation à ce moment précis.
```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Ajouter une forme de sourire et l'animer.
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


Pour faire jouer toutes les animations d’une présentation simultanément, on utilise la classe [PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/). Cette classe accepte une instance de [PresentationAnimationsGenerator](https://reference.aspose.com/slides/net/aspose.slides.export/presentationanimationsgenerator/) et une valeur FPS pour les effets dans son constructeur, puis déclenche l’événement `FrameTick` pour toutes les animations afin de les jouer :
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

Lors de la conversion d’une présentation PowerPoint en vidéo avec Aspose.Slides for .NET, il est important de connaître les animations et effets pris en charge dans le résultat. Aspose.Slides prend en charge un large éventail d’effets d’entrée, de sortie et d’accentuation courants tels que fondu, glissement, zoom et rotation. Cependant, certaines animations avancées ou personnalisées peuvent ne pas être entièrement préservées ou apparaître différemment dans la vidéo finale. Cette section répertorie les animations et effets pris en charge.

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

**Accentuation** :

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

## **Effets de transition de diapositive pris en charge**

Les effets de transition de diapositive jouent un rôle important pour créer des changements fluides et visuellement attrayants entre les diapositives d’une vidéo. Aspose.Slides for .NET prend en charge une variété d’effets de transition couramment utilisés afin de préserver le flux et le style de votre présentation d’origine. Cette section souligne les effets de transition pris en charge lors du processus de conversion.

**Subtil** :

| Type d'animation | Aspose.Slides | PowerPoint |
|---|---|---|
| **Morph** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Push** | ![supported](v.png) | ![supported](v.png) |
| **Pull** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Reveal** | ![not supported](x.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![not supported](x.png) | ![supported](v.png) |
| **Uncover** | ![not supported](x.png) | ![supported](v.png) |
| **Cover** | ![supported](v.png) | ![supported](v.png) |
| **Flash** | ![supported](v.png) | ![supported](v.png) |
| **Strips** | ![supported](v.png) | ![supported](v.png) |

**Excitant** :

| Type d'animation | Aspose.Slides | PowerPoint |
|---|---|---|
| **Fall Over** | ![not supported](x.png) | ![supported](v.png) |
| **Drape** | ![not supported](x.png) | ![supported](v.png) |
| **Curtains** | ![not supported](x.png) | ![supported](v.png) |
| **Wind** | ![not supported](x.png) | ![supported](v.png) |
| **Prestige** | ![not supported](x.png) | ![supported](v.png) |
| **Fracture** | ![not supported](x.png) | ![supported](v.png) |
| **Crush** | ![not supported](x.png) | ![supported](v.png) |
| **Peel Off** | ![not supported](x.png) | ![supported](v.png) |
| **Page Curl** | ![not supported](x.png) | ![supported](v.png) |
| **Airplane** | ![not supported](x.png) | ![supported](v.png) |
| **Origami** | ![not supported](x.png) | ![supported](v.png) |
| **Dissolve** | ![supported](v.png) | ![supported](v.png) |
| **Checkerboard** | ![not supported](x.png) | ![supported](v.png) |
| **Blinds** | ![not supported](x.png) | ![supported](v.png) |
| **Clock** | ![supported](v.png) | ![supported](v.png) |
| **Ripple** | ![not supported](x.png) | ![supported](v.png) |
| **Honeycomb** | ![not supported](x.png) | ![supported](v.png) |
| **Glitter** | ![not supported](x.png) | ![supported](v.png) |
| **Vortex** | ![not supported](x.png) | ![supported](v.png) |
| **Shred** | ![not supported](x/png) | ![supported](v.png) |
| **Switch** | ![not supported](x.png) | ![supported](v.png) |
| **Flip** | ![not supported](x.png) | ![supported](v.png) |
| **Gallery** | ![not supported](x.png) | ![supported](v.png) |
| **Cube** | ![not supported](x.png) | ![supported](v.png) |
| **Doors** | ![not supported](x.png) | ![supported](v.png) |
| **Box** | ![not supported](x.png) | ![supported](v.png) |
| **Comb** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Random** | ![not supported](x.png) | ![supported](v.png) |

**Contenu dynamique** :

| Type d'animation | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pan** | ![not supported](x.png) | ![supported](v.png) |
| **Ferris Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Conveyor** | ![not supported](x.png) | ![supported](v.png) |
| **Rotate** | ![not supported](x.png) | ![supported](v.png) |
| **Orbit** | ![not supported](x.png) | ![supported](v.png) |
| **Fly Through** | ![supported](v.png) | ![supported](v.png) |

## **FAQ**

**Est‑il possible de convertir des présentations protégées par mot de passe ?**

Oui, Aspose.Slides for .NET permet de travailler avec des présentations protégées par mot de passe. Lors du traitement de ces fichiers, vous devez fournir le mot de passe correct afin que la bibliothèque puisse accéder au contenu de la présentation.

**Aspose.Slides for .NET prend‑il en charge une utilisation dans des solutions cloud ?**

Oui, Aspose.Slides for .NET peut être intégré aux applications et services cloud. La bibliothèque est conçue pour fonctionner dans des environnements serveur, garantissant des performances élevées et une évolutivité pour le traitement par lots de fichiers.

**Existe‑t‑il des limitations de taille pour les présentations lors de la conversion ?**

Aspose.Slides for .NET est capable de gérer des présentations de taille pratiquement illimitée. Cependant, avec des fichiers très volumineux, des ressources système supplémentaires peuvent être nécessaires, et il est parfois recommandé d’optimiser la présentation pour améliorer les performances.