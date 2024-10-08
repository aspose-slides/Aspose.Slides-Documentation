---
title: Convertir PowerPoint en Vidéo
type: docs
weight: 130
url: /fr/net/convert-powerpoint-to-video/
keywords: "Convertir PowerPoint, PPT, PPTX, Présentation, Vidéo, MP4, PPT en vidéo, PPT en MP4, C#, Csharp, .NET, Aspose.Slides"
description: "Convertir PowerPoint en Vidéo en C# ou .NET "
---

En convertissant votre présentation PowerPoint en vidéo, vous obtenez 

* **Augmentation de l'accessibilité :** Tous les dispositifs (quelle que soit la plateforme) sont équipés par défaut de lecteurs vidéo par rapport aux applications d'ouverture de présentation, ce qui facilite l'ouverture ou la lecture des vidéos pour les utilisateurs.
* **Plus de portée :** Grâce aux vidéos, vous pouvez atteindre un large public et le cibler avec des informations qui pourraient autrement sembler ennuyeuses dans une présentation. La plupart des enquêtes et des statistiques suggèrent que les gens regardent et consomment des vidéos plus que d'autres formes de contenu, et ils préfèrent généralement ce type de contenu.

{{% alert color="primary" %}} 

Vous voudrez peut-être consulter notre [**Convertisseur PowerPoint en Vidéo en Ligne**](https://products.aspose.app/slides/conversion/ppt-to-word) car il s'agit d'une mise en œuvre en direct et efficace du processus décrit ici.

{{% /alert %}} 

## **Conversion de PowerPoint en Vidéo avec Aspose.Slides**

Dans [Aspose.Slides 22.11](https://docs.aspose.com/slides/net/aspose-slides-for-net-22-11-release-notes/), nous avons implémenté la prise en charge de la conversion de présentation en vidéo. 

* Utilisez Aspose.Slides pour générer un ensemble d'images (à partir des diapositives de présentation) correspondant à un certain FPS (images par seconde)
* Utilisez un utilitaire tiers comme FFMpegCore (ffmpeg) pour créer une vidéo basée sur les images. 

### **Convertir PowerPoint en Vidéo**

1. Utilisez la commande dotnet add package pour ajouter Aspose.Slides et la bibliothèque FFMpegCore à votre projet :
   * exécutez `dotnet add package Aspose.Slides.NET --version 22.11.0`
   * exécutez `dotnet add package FFMpegCore --version 4.8.0`
2. Téléchargez ffmpeg [ici](https://ffmpeg.org/download.html).
3. FFMpegCore nécessite que vous spécifiiez le chemin vers le ffmpeg téléchargé (par exemple, extrait dans "C:\tools\ffmpeg") :  `GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin",} );`
4. Exécutez le code de conversion PowerPoint en vidéo.

Ce code C# vous montre comment convertir une présentation (contenant une figure et deux effets d'animation) en vidéo :

```c#
using System.Collections.Generic;
using Aspose.Slides;
using FFMpegCore; // Utilisera les binaires FFmpeg que nous avons extraits dans "c:\tools\ffmpeg" auparavant
using Aspose.Slides.Animation;
using (Presentation presentation = new Presentation())

{
    // Ajoute une forme de sourire et l'anime
    IAutoShape smile = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);
    IEffect effectIn = presentation.Slides[0].Timeline.MainSequence.AddEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);
    IEffect effectOut = presentation.Slides[0].Timeline.MainSequence.AddEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);
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

    // Configure le dossier des binaires ffmpeg. Voir cette page : https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin", });
    // Convertit les images en vidéo webm
    FFMpeg.JoinImageSequence("smile.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());

}
```

## **Effets Vidéo**

Vous pouvez appliquer des animations aux objets sur les diapositives et utiliser des transitions entre les diapositives. 

{{% alert color="primary" %}} 

Vous pourriez vouloir voir ces articles : [Animation PowerPoint](https://docs.aspose.com/slides/net/powerpoint-animation/), [Animation de Forme](https://docs.aspose.com/slides/net/shape-animation/), et [Effet de Forme](https://docs.aspose.com/slides/net/shape-effect/).

{{% /alert %}} 

Les animations et transitions rendent les diaporamas plus engageants et intéressants — et ils font la même chose pour les vidéos. Ajoutons une autre diapositive et une transition au code de la présentation précédente :

```c#
// Ajoute une forme de sourire et l'anime

// ...

// Ajoute une nouvelle diapositive et une transition animée

ISlide newSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

newSlide.Background.Type = BackgroundType.OwnBackground;

newSlide.Background.FillFormat.FillType = FillType.Solid;

newSlide.Background.FillFormat.SolidFillColor.Color = Color.Indigo;

newSlide.SlideShowTransition.Type = TransitionType.Push;
```

Aspose.Slides prend également en charge l'animation des textes. Donc nous animons des paragraphes sur des objets, qui apparaîtront les uns après les autres (avec un délai fixé à une seconde) :

```c#
using System.Collections.Generic;
using Aspose.Slides.Export;
using Aspose.Slides;
using FFMpegCore;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    // Ajoute du texte et des animations
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 210, 120, 300, 300);
    Paragraph para1 = new Paragraph();
    para1.Portions.Add(new Portion("Aspose Slides for .NET"));
    Paragraph para2 = new Paragraph();
    para2.Portions.Add(new Portion("convertir la Présentation PowerPoint avec du texte en vidéo"));

    Paragraph para3 = new Paragraph();
    para3.Portions.Add(new Portion("paragraphe par paragraphe"));
    autoShape.TextFrame.Paragraphs.Add(para1);
    autoShape.TextFrame.Paragraphs.Add(para2);
    autoShape.TextFrame.Paragraphs.Add(para3);
    autoShape.TextFrame.Paragraphs.Add(new Paragraph());

    IEffect effect = presentation.Slides[0].Timeline.MainSequence.AddEffect(para1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect2 = presentation.Slides[0].Timeline.MainSequence.AddEffect(para2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect3 = presentation.Slides[0].Timeline.MainSequence.AddEffect(para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect4 = presentation.Slides[0].Timeline.MainSequence.AddEffect(para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    effect.Timing.TriggerDelayTime = 1f;
    effect2.Timing.TriggerDelayTime = 1f;
    effect3.Timing.TriggerDelayTime = 1f;
    effect4.Timing.TriggerDelayTime = 1f;

    // Convertit les images en vidéo
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
    // Configure le dossier des binaires ffmpeg. Voir cette page : https://github.com/rosenbjerg/FFMpegCore#installation

    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin", });
    // Convertit les images en vidéo webm
    FFMpeg.JoinImageSequence("text_animation.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());

}
```

## **Classes de Conversion Vidéo**

Pour vous permettre d'effectuer des tâches de conversion de PowerPoint en vidéo, Aspose.Slides fournit les classes [PresentationAnimationsGenerator](https://reference.aspose.com/slides/net/aspose.slides.export/presentationanimationsgenerator/) et [PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/).

PresentationAnimationsGenerator vous permet de définir la taille du cadre pour la vidéo (qui sera créée plus tard) via son constructeur. Si vous passez une instance de la présentation, `Presentation.SlideSize` sera utilisée et elle génère des animations que [PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/) utilise. 

Lorsque les animations sont générées, un événement `NewAnimation` est généré pour chaque animation suivante, qui a le paramètre [IPresentationAnimationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/). Ce dernier est une classe qui représente un lecteur pour une animation séparée.

Pour travailler avec [IPresentationAnimationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/), les propriétés [Duration](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/duration/) (la durée totale de l'animation) et la méthode [SetTimePosition](https://reference.aspose.com/slides/net/aspose.slides.export/ipresentationanimationplayer/settimeposition/) sont utilisées. Chaque position d'animation est définie dans la plage *0 à duration* et ensuite la méthode `GetFrame` retournera un Bitmap correspondant à l'état de l'animation à ce moment-là.

```c#
using (Presentation presentation = new Presentation())
{
    // Ajoute une forme de sourire et l'anime
    IAutoShape smile = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);
    IEffect effectIn = presentation.Slides[0].Timeline.MainSequence.AddEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);
    IEffect effectOut = presentation.Slides[0].Timeline.MainSequence.AddEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);
    effectIn.Timing.Duration = 2f;
    effectOut.PresetClassType = EffectPresetClassType.Exit;

    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    {
        animationsGenerator.NewAnimation += animationPlayer =>
        {
            Console.WriteLine($"Durée totale de l'animation : {animationPlayer.Duration}");
            
            animationPlayer.SetTimePosition(0); // état initial de l'animation
            Bitmap bitmap = animationPlayer.GetFrame(); // bitmap de l'état initial de l'animation

            animationPlayer.SetTimePosition(animationPlayer.Duration); // état final de l'animation
            Bitmap lastBitmap = animationPlayer.GetFrame(); // dernière image de l'animation
            lastBitmap.Save("last.png");
        };
    }
}
```

Pour faire jouer toutes les animations d'une présentation en même temps, la classe [PresentationPlayer](https://reference.aspose.com/slides/net/aspose.slides.export/presentationplayer/) est utilisée. Cette classe prend une instance de [PresentationAnimationsGenerator](https://reference.aspose.com/slides/net/aspose.slides.export/presentationanimationsgenerator/) et le FPS pour les effets dans son constructeur, puis appelle l'événement `FrameTick` pour toutes les animations afin de les jouer :

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

Puis les images générées peuvent être compilées pour produire une vidéo. Voir la section [Convertir PowerPoint en Vidéo](https://docs.aspose.com/slides/net/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Animations et Effets Supportés**


**Entrée**:

| Type d'Animation | Aspose.Slides | PowerPoint |
|---|---|---|
| **Apparaître** | ![non supporté](x.png) | ![supporté](v.png) |
| **Fondu** | ![supporté](v.png) | ![supporté](v.png) |
| **Entrée en Vol** | ![supporté](v.png) | ![supporté](v.png) |
| **Entrée Flottante** | ![supporté](v.png) | ![supporté](v.png) |
| **Division** | ![supporté](v.png) | ![supporté](v.png) |
| **Essuyer** | ![supporté](v.png) | ![supporté](v.png) |
| **Forme** | ![supporté](v.png) | ![supporté](v.png) |
| **Roue** | ![supporté](v.png) | ![supporté](v.png) |
| **Barres Aléatoires** | ![supporté](v.png) | ![supporté](v.png) |
| **Grandir et Tourner** | ![non supporté](x.png) | ![supporté](v.png) |
| **Zoom** | ![supporté](v.png) | ![supporté](v.png) |
| **Rotation** | ![supporté](v.png) | ![supporté](v.png) |
| **Rebond** | ![supporté](v.png) | ![supporté](v.png) |


**Accentuation**:

| Type d'Animation | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulsation** | ![non supporté](x.png) | ![supporté](v.png) |
| **Pulsation de Couleur** | ![non supporté](x.png) | ![supporté](v.png) |
| **Balancer** | ![supporté](v.png) | ![supporté](v.png) |
| **Rotation** | ![supporté](v.png) | ![supporté](v.png) |
| **Grandir/Rétrécir** | ![non supporté](x.png) | ![supporté](v.png) |
| **Désaturer** | ![non supporté](x.png) | ![supporté](v.png) |
| **Assombrir** | ![non supporté](x.png) | ![supporté](v.png) |
| **Éclaircir** | ![non supporté](x.png) | ![supporté](v.png) |
| **Transparence** | ![non supporté](x.png) | ![supporté](v.png) |
| **Couleur de l'Objet** | ![non supporté](x.png) | ![supporté](v.png) |
| **Couleur Complémentaire** | ![non supporté](x.png) | ![supporté](v.png) |
| **Couleur de Ligne** | ![non supporté](x.png) | ![supporté](v.png) |
| **Couleur de Remplissage** | ![non supporté](x.png) | ![supporté](v.png) |

**Sortie**:

| Type d'Animation | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disparaître** | ![non supporté](x.png) | ![supporté](v.png) |
| **Fondu** | ![supporté](v.png) | ![supporté](v.png) |
| **Sortie en Vol** | ![supporté](v.png) | ![supporté](v.png) |
| **Sortie Flottante** | ![supporté](v.png) | ![supporté](v.png) |
| **Division** | ![supporté](v.png) | ![supporté](v.png) |
| **Essuyer** | ![supporté](v.png) | ![supporté](v.png) |
| **Forme** | ![supporté](v.png) | ![supporté](v.png) |
| **Barres Aléatoires** | ![supporté](v.png) | ![supporté](v.png) |
| **Réduire et Tourner** | ![non supporté](x.png) | ![supporté](v.png) |
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

## **Effets de Transition de Diapositive Supportés**

**Subtils**:

| Type d'Animation | Aspose.Slides | PowerPoint |
|---|---|---|
| **Morphose** | ![non supporté](x.png) | ![supporté](v.png) |
| **Fondu** | ![supporté](v.png) | ![supporté](v.png) |
| **Pousser** | ![supporté](v.png) | ![supporté](v.png) |
| **Tirer** | ![supporté](v.png) | ![supporté](v.png) |
| **Essuyer** | ![supporté](v.png) | ![supporté](v.png) |
| **Division** | ![supporté](v.png) | ![supporté](v.png) |
| **Révéler** | ![non supporté](x.png) | ![supporté](v.png) |
| **Barres Aléatoires** | ![supporté](v.png) | ![supporté](v.png) |
| **Forme** | ![non supporté](x.png) | ![supporté](v.png) |
| **Dévoiler** | ![non supporté](x.png) | ![supporté](v.png) |
| **Couverture** | ![supporté](v.png) | ![supporté](v.png) |
| **Clignoter** | ![supporté](v.png) | ![supporté](v.png) |
| **Bandes** | ![supporté](v.png) | ![supporté](v.png) |

**Excitant**:

| Type d'Animation | Aspose.Slides | PowerPoint |
|---|---|---|
| **Tomber** | ![non supporté](x.png) | ![supporté](v.png) |
| **Draper** | ![non supporté](x.png) | ![supporté](v.png) |
| **Rideaux** | ![non supporté](x.png) | ![supporté](v.png) |
| **Vent** | ![non supporté](x.png) | ![supporté](v.png) |
| **Prestige** | ![non supporté](x.png) | ![supporté](v.png) |
| **Fracture** | ![non supporté](x.png) | ![supporté](v.png) |
| **Écraser** | ![non supporté](x.png) | ![supporté](v.png) |
| **Peler** | ![non supporté](x.png) | ![supporté](v.png) |
| **Pliage de Page** | ![non supporté](x.png) | ![supporté](v.png) |
| **Avion** | ![non supporté](x.png) | ![supporté](v.png) |
| **Origami** | ![non supporté](x.png) | ![supporté](v.png) |
| **Dissoudre** | ![supporté](v.png) | ![supporté](v.png) |
| **Damier** | ![non supporté](x.png) | ![supporté](v.png) |
| **Rideaux** | ![non supporté](x.png) | ![supporté](v.png) |
| **Horloge** | ![supporté](v.png) | ![supporté](v.png) |
| **Vague** | ![non supporté](x.png) | ![supporté](v.png) |
| **Rayon de miel** | ![non supporté](x.png) | ![supporté](v.png) |
| **Paillettes** | ![non supporté](x.png) | ![supporté](v.png) |
| **Vortex** | ![non supporté](x.png) | ![supporté](v.png) |
| **Déchirer** | ![non supporté](x.png) | ![supporté](v.png) |
| **Changer** | ![non supporté](x.png) | ![supporté](v.png) |
| **Retourner** | ![non supporté](x.png) | ![supporté](v.png) |
| **Galerie** | ![non supporté](x.png) | ![supporté](v.png) |
| **Cube** | ![non supporté](x.png) | ![supporté](v.png) |
| **Portes** | ![non supporté](x.png) | ![supporté](v.png) |
| **Boîte** | ![non supporté](x.png) | ![supporté](v.png) |
| **Peigne** | ![non supporté](x.png) | ![supporté](v.png) |
| **Zoom** | ![supporté](v.png) | ![supporté](v.png) |
| **Aléatoire** | ![non supporté](x.png) | ![supporté](v.png) |

**Contenu Dynamique**:

| Type d'Animation | Aspose.Slides | PowerPoint |
|---|---|---|
| **Panoramique** | ![non supporté](x.png) | ![supporté](v.png) |
| **Grande Roue** | ![supporté](v.png) | ![supporté](v.png) |
| **Convoyeur** | ![non supporté](x.png) | ![supporté](v.png) |
| **Rotation** | ![non supporté](x.png) | ![supporté](v.png) |
| **Orbite** | ![non supporté](x.png) | ![supporté](v.png) |
| **Volée à Travers** | ![supporté](v.png) | ![supporté](v.png) |