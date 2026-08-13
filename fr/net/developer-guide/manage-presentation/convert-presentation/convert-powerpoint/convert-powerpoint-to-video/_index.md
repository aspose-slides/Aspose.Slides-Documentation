---
title: Convertir des présentations PowerPoint en vidéo avec .NET
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
description: "Apprenez comment convertir des présentations PowerPoint en vidéo avec .NET. Découvrez du code C# d'exemple et des techniques d'automatisation pour optimiser votre flux de travail."
---
## **Introduction**

En convertissant votre présentation PowerPoint ou OpenDocument en vidéo, vous obtenez :

**Accessibilité accrue :** Tous les appareils, quel que soit le système, sont équipés de lecteurs vidéo par défaut, ce qui facilite l’ouverture ou la lecture des vidéos comparé aux applications de présentation traditionnelles.

**Portée élargie :** Les vidéos vous permettent d’atteindre un public plus large et de présenter l’information sous un format plus engageant. Les enquêtes et les statistiques indiquent que les gens préfèrent regarder et consommer du contenu vidéo plutôt que d’autres formes, rendant votre message plus percutant.

{{% alert color="info" %}} 

Découvrez notre [**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/fr/video) car il propose une implémentation en direct et efficace du processus décrit ici.

{{% /alert %}} 

Dans Aspose.Slides for .NET, nous avons implémenté la prise en charge de la conversion des présentations en vidéo.

* Utilisez Aspose.Slides for .NET pour générer des images à partir des diapositives de la présentation à un débit d’images spécifié (FPS).
* Puis, utilisez un utilitaire tiers comme ffmpeg pour assembler ces images en une vidéo.

## **Convertir une présentation PowerPoint en vidéo**

1. Utilisez la commande `dotnet add package` pour ajouter Aspose.Slides et la bibliothèque FFMpegCore à votre projet :
   * exécutez `dotnet add package Aspose.Slides.NET --version 22.11.0`
   * exécutez `dotnet add package FFMpegCore --version 4.8.0`
2. Téléchargez ffmpeg depuis [here](https://ffmpeg.org/download.html).
3. FFMpegCore vous oblige à préciser le chemin du ffmpeg téléchargé (par ex. extrait dans "C:\tools\ffmpeg") :  
```cs
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });
```
4. Exécutez le code de conversion PowerPoint‑vers‑vidéo.

Ce code C# montre comment convertir une présentation (contenant une forme et deux effets d’animation) en vidéo :

```c#
using System.Collections.Generic;
using Aspose.Slides;
using FFMpegCore; // utilisera les binaires FFmpeg que nous avons extraits vers C:\tools\ffmpeg précédemment.
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Ajouter une forme smiley puis l'animer.
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

    // Configurer le dossier des binaires ffmpeg. Voir cette page : https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // Convertir les images en vidéo webm.
    FFMpeg.JoinImageSequence("smile.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```

## **Effets vidéo**

Lors de la conversion d’une présentation PowerPoint en vidéo avec Aspose.Slides for .NET, vous pouvez appliquer divers effets vidéo pour améliorer la qualité visuelle du résultat. Ces effets vous permettent de contrôler l’apparence des diapositives dans la vidéo finale en ajoutant des transitions fluides, des animations et d’autres éléments visuels. Cette section décrit les options d’effets vidéo disponibles et montre comment les appliquer.

{{% alert color="info" %}} 

Voir :
- [Enhancing PowerPoint Presentations with Animations in C#](https://docs.aspose.com/slides/fr/net/powerpoint-animation/)
- [Shape Animation](https://docs.aspose.com/slides/fr/net/shape-animation/)
- [Apply Shape Effects in PowerPoint Using C#](https://docs.aspose.com/slides/fr/net/shape-effect/)

{{% /alert %}} 

Les animations et les transitions rendent les diaporamas plus dynamiques et intéressants — et il en va de même pour les vidéos. Ajoutons une diapositive supplémentaire et une transition au code de la présentation précédente :

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.SlideShow;

using (Presentation presentation = new Presentation())
{
    // Ajouter une forme sourire et l'animer (voir le code ci-dessus).

    // Ajouter une nouvelle diapositive et une transition animée.
    ISlide newSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
    newSlide.Background.Type = BackgroundType.OwnBackground;
    newSlide.Background.FillFormat.FillType = FillType.Solid;
    newSlide.Background.FillFormat.SolidFillColor.Color = Color.Indigo;
    newSlide.SlideShowTransition.Type = TransitionType.Push;
}
```

Aspose.Slides prend également en charge les animations de texte. Dans cet exemple, nous animons les paragraphes d’objets afin qu’ils apparaissent l’un après l’autre, avec un délai d’une seconde entre chacun :

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

Pour faciliter les tâches de conversion PowerPoint → vidéo, Aspose.Slides for .NET fournit les classes [PresentationAnimationsGenerator](https://reference.aspose.com/slides/fr/net/aspose.slides.export/presentationanimationsgenerator/) et [PresentationPlayer](https://reference.aspose.com/slides/fr/net/aspose.slides.export/presentationplayer/).

`PresentationAnimationsGenerator` vous permet de définir la taille du cadre vidéo (qui sera créée ultérieurement) ainsi que la valeur FPS (images par seconde) via son constructeur. Si vous transmettez une instance de présentation, son `Presentation.SlideSize` sera utilisé et il génère les animations que [PresentationPlayer](https://reference.aspose.com/slides/fr/net/aspose.slides.export/presentationplayer/) utilise.

Lorsque les animations sont générées, un événement `NewAnimation` est déclenché pour chaque animation successive, incluant un paramètre [IPresentationAnimationPlayer](https://reference.aspose.com/slides/fr/net/aspose.slides.export/ipresentationanimationplayer/). Cette classe représente un lecteur pour une animation individuelle.

Pour travailler avec [IPresentationAnimationPlayer](https://reference.aspose.com/slides/fr/net/aspose.slides.export/ipresentationanimationplayer/), vous utilisez la propriété [Duration](https://reference.aspose.com/slides/fr/net/aspose.slides.export/ipresentationanimationplayer/duration/) (qui indique la durée totale de l’animation) et la méthode [SetTimePosition](https://reference.aspose.com/slides/fr/net/aspose.slides.export/ipresentationanimationplayer/settimeposition/). Chaque position d’animation est définie dans l’intervalle *0 à durée*, et la méthode `GetFrame` renvoie alors un Bitmap représentant l’état de l’animation à ce moment‑là.

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Ajouter une forme sourire et l'animer.
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

            animationPlayer.SetTimePosition(0);        // L'état initial de l'animation.
            IImage image = animationPlayer.GetFrame(); // L'image de l'état initial de l'animation.

            animationPlayer.SetTimePosition(animationPlayer.Duration); // L'état final de l'animation.
            IImage lastImage = animationPlayer.GetFrame();             // Le dernier cadre de l'animation.
            lastImage.Save("last.png");
        };
    }
}
```

Pour lire toutes les animations d’une présentation simultanément, on utilise la classe [PresentationPlayer](https://reference.aspose.com/slides/fr/net/aspose.slides.export/presentationplayer/). Cette classe reçoit une instance de [PresentationAnimationsGenerator](https://reference.aspose.com/slides/fr/net/aspose.slides.export/presentationanimationsgenerator/) et une valeur FPS pour les effets dans son constructeur, puis invoque l’événement `FrameTick` pour toutes les animations afin de les lire :

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

Lors de la conversion d’une présentation PowerPoint en vidéo avec Aspose.Slides for .NET, il est important de connaître les animations et effets qui seront conservés dans le résultat. Aspose.Slides supporte une large gamme d’effets d’entrée, de sortie et d’accentuation courants tels que le fondu, le glissement, le zoom et la rotation. Cependant, certaines animations avancées ou personnalisées peuvent ne pas être entièrement préservées ou apparaître différemment dans la vidéo finale. Cette section récapitule les animations et effets pris en charge.

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

Les effets de transition de diapositive jouent un rôle important pour créer des changements fluides et visuellement attrayants entre les diapositives d’une vidéo. Aspose.Slides for .NET supporte une variété d’effets de transition couramment utilisés afin de préserver le flux et le style de votre présentation originale. Cette section met en évidence les effets de transition pris en charge lors du processus de conversion.

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
| **Shred** | ![not supported](x.png) | ![supported](v.png) |
| **Switch** | ![not supported](x.png) | ![supported](v.png) |
| **Flip** | ![not supported](x/png) | ![supported](v.png) |
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

### Est‑il possible de convertir des présentations protégées par mot de passe ?

Oui, Aspose.Slides for .NET permet de travailler avec des présentations protégées par mot de passe. Lors du traitement de ces fichiers, vous devez fournir le mot de passe correct afin que la bibliothèque puisse accéder au contenu de la présentation.

### Aspose.Slides for .NET prend‑il en charge une utilisation dans des solutions cloud ?

Oui, Aspose.Slides for .NET peut être intégré aux applications et services cloud. La bibliothèque est conçue pour fonctionner dans des environnements serveur, garantissant des performances élevées et une grande évolutivité pour le traitement par lots de fichiers.

### Existe‑t‑il des limitations de taille pour les présentations lors de la conversion ?

Aspose.Slides for .NET est capable de gérer des présentations de taille quasi illimitée. Cependant, lors du traitement de fichiers très volumineux, des ressources système supplémentaires peuvent être nécessaires, et il est parfois recommandé d’optimiser la présentation afin d’améliorer les performances.