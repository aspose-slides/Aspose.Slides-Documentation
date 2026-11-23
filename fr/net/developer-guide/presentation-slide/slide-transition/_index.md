---
title: Gérer les transitions de diapositive dans les présentations en .NET
linktitle: Transition de diapositive
type: docs
weight: 90
url: /fr/net/slide-transition/
keywords:
- transition de diapositive
- ajouter une transition de diapositive
- appliquer une transition de diapositive
- transition de diapositive avancée
- transition morph
- type de transition
- effet de transition
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Appliquer des transitions de diapositive, configurer l’avancement automatique des diapositives et personnaliser les effets de transition Morph et autres avec Aspose.Slides for .NET."
---
## **Aperçu**

Les transitions de diapositive contrôlent la façon dont les diapositives apparaissent pendant un diaporama. Avec Aspose.Slides for .NET, vous pouvez choisir un effet de transition pour chaque diapositive, configurer le passage par clic de souris ou par minuteur, et ajuster les options spécifiques à un effet. Cet article utilise des exemples C# pour appliquer des transitions, définir des durées de transition précises, gérer le minutage des diapositives et créer une transition Morph entre deux diapositives. Les exemples montrent également comment enregistrer les paramètres dans un fichier PPTX.

## **Ajouter une transition de diapositive**

Pour appliquer une transition, chargez une présentation avec la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) et accédez à la propriété [SlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideshowtransition/) de la diapositive. Définissez son [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) sur une valeur de l’énumération [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/), puis enregistrez la présentation.

L’exemple suivant applique une transition Circle à la première diapositive et une transition Comb à la deuxième. Utilisez un fichier `input.pptx` contenant au moins deux diapositives.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

if (presentation.Slides.Count >= 2)
{
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Circle;
    presentation.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    presentation.Save("slide-transitions.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The input presentation must contain at least two slides.");
}
```

## **Transition Wheel**

La propriété [Spokes](https://reference.aspose.com/slides/net/aspose.slides.slideshow/iwheeltransition/spokes/) de [IWheelTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/iwheeltransition/) contrôle le nombre de secteurs radiaux qui révèlent la diapositive cible. Définissez le [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) de la transition de la diapositive sur Wheel depuis [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) avant d’accéder à [Value](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/value/) via [IWheelTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/iwheeltransition/).

Cet exemple crée deux paires identiques de diapositives : une diapositive noire suivie d’une diapositive avec un rectangle doré. Les diapositives cibles utilisent respectivement des nombres de rayons de 1 et 8, avec la même [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) et une [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) explicite de 8 000 ms pour faciliter l’observation de la différence.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation();
var slideWidth = presentation.SlideSize.Size.Width;
var slideHeight = presentation.SlideSize.Size.Height;

var blackSlide = presentation.Slides[0];
blackSlide.Shapes.Clear();
blackSlide.Background.Type = BackgroundType.OwnBackground;
blackSlide.Background.FillFormat.FillType = FillType.Solid;
blackSlide.Background.FillFormat.SolidFillColor.Color = Color.Black;

var destinationSlide = presentation.Slides.AddClone(blackSlide);
var rectangle = destinationSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, slideWidth, slideHeight);
rectangle.FillFormat.FillType = FillType.Solid;
rectangle.FillFormat.SolidFillColor.Color = Color.Gold;
rectangle.TextFrame.Text = "Wheel transition";

presentation.Slides.AddClone(blackSlide);
presentation.Slides.AddClone(destinationSlide);

var spokeCounts = new uint[] { 1, 8 };
for (var i = 0; i < spokeCounts.Length; i++)
{
    var transition = presentation.Slides[i * 2 + 1].SlideShowTransition;
    transition.Type = TransitionType.Wheel;
    var wheelTransition = (IWheelTransition)transition.Value;
    wheelTransition.Spokes = spokeCounts[i];
    transition.Speed = TransitionSpeed.Slow;
    transition.Duration = 8000;
}

presentation.Save("wheel-transitions.pptx", SaveFormat.Pptx);
```

Ouvrez la présentation résultante dans PowerPoint et lancez le diaporama. Passez de la diapositive 1 à la diapositive 2, puis de la diapositive 3 à la diapositive 4. En lecture PowerPoint, le nombre de rayons vérifié de 1 révèle la diapositive avec un balayage horloger unique ; le nombre de 8 la révèle à travers huit secteurs radiaux simultanément. Le contenu cible et le minutage de la transition sont identiques, la différence réside donc dans le nombre de secteurs de révélation.

## **Fondu vers le noir avec la transition Reveal**

Définissez le type de transition de la diapositive cible sur Reveal, puis utilisez [IRevealTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/irevealtransition/) pour définir [ThroughBlack](https://reference.aspose.com/slides/net/aspose.slides.slideshow/irevealtransition/throughblack/). L’exemple crée une diapositive source teal et une diapositive cible coral, puis les clone afin que vous puissiez comparer la même transition de deux secondes avec le fondu désactivé et activé.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation();

var source = presentation.Slides[0];
var destination = presentation.Slides.AddClone(source);
StyleSlide(source, Color.Teal, "Source");
StyleSlide(destination, Color.Coral, "Destination");
presentation.Slides.AddClone(source);
presentation.Slides.AddClone(destination);

foreach (var index in new[] { 1, 3 })
{
    var transition = presentation.Slides[index].SlideShowTransition;
    transition.Type = TransitionType.Reveal;
    transition.Speed = TransitionSpeed.Slow;
    transition.Duration = 2000;

    var reveal = (IRevealTransition)transition.Value;
    reveal.Direction = TransitionLeftRightDirectionType.Left;
    reveal.ThroughBlack = index == 3;
}

presentation.Save("reveal-transitions.pptx", SaveFormat.Pptx);

void StyleSlide(ISlide slide, Color background, string label)
{
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = background;

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 160, 180, 400, 130);
    shape.TextFrame.Text = label;
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 44;
}
```

Dans un diaporama PowerPoint, passez de la diapositive 1 à la diapositive 2. Le teal fondu directement en coral. Puis passez de la diapositive 3 à la diapositive 4. L’écran s’assombrit brièvement presque jusqu’au noir avant que la diapositive coral apparaisse. Les deux diapositives conservent leurs couleurs d’arrière‑plan d’origine.

Les lignes ci‑dessous montrent des images de PowerPoint à intervalles de demi‑seconde. Comparez le cadre du milieu de chaque ligne pour voir l’effet du paramètre.

![PowerPoint playback with ThroughBlack disabled (top) and enabled (bottom). Only the bottom row passes through near black.](reveal-through-black.png)

## **Ajouter une transition de diapositive avancée**

Vous pouvez configurer la durée pendant laquelle une diapositive reste à l’écran et si un clic de souris avance le diaporama. Les propriétés suivantes contrôlent ce comportement :

- [AdvanceOnClick](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceonclick/) permet au spectateur d’avancer en cliquant.
- [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/) active l’avancement automatique.
- [AdvanceAfterTime](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceaftertime/) spécifie le délai avant l’avancement automatique, en millisecondes.

Activez à la fois l’avancement par clic et par minuteur pour permettre au spectateur de passer à la diapositive suivant soit par clic, soit en attendant le minuteur. Pour n’utiliser que le minuteur, définissez [AdvanceOnClick](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceonclick/) sur `false`. Le délai contrôle le moment où le diaporama avance ; il ne définit pas la durée de l’effet visuel de transition.

Cet exemple affecte des effets différents aux trois premières diapositives et active l’avancement automatique après 3, 5 et 7 secondes, respectivement. Les clics de souris peuvent également faire avancer ces diapositives. Utilisez un fichier `input.pptx` contenant au moins trois diapositives.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

if (presentation.Slides.Count >= 3)
{
    var firstTransition = presentation.Slides[0].SlideShowTransition;
    firstTransition.Type = TransitionType.Circle;
    firstTransition.AdvanceOnClick = true;
    firstTransition.AdvanceAfter = true;
    firstTransition.AdvanceAfterTime = 3000;

    var secondTransition = presentation.Slides[1].SlideShowTransition;
    secondTransition.Type = TransitionType.Comb;
    secondTransition.AdvanceOnClick = true;
    secondTransition.AdvanceAfter = true;
    secondTransition.AdvanceAfterTime = 5000;

    var thirdTransition = presentation.Slides[2].SlideShowTransition;
    thirdTransition.Type = TransitionType.Zoom;
    thirdTransition.AdvanceOnClick = true;
    thirdTransition.AdvanceAfter = true;
    thirdTransition.AdvanceAfterTime = 7000;

    presentation.Save("advanced-transitions.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The input presentation must contain at least three slides.");
}
```

Pour vérifier si l’avancement chronométré est activé, lisez [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/). Un simple délai stocké ne signifie pas que le minuteur est actif.

L’exemple suivant ouvre le fichier enregistré ci‑dessus, indique chaque minuteur activé, puis désactive l’avancement automatique pour les diapositives dont le délai dépasse deux secondes. Il active les clics de souris pour ces diapositives et enregistre les paramètres mis à jour.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("advanced-transitions.pptx");

foreach (var slide in presentation.Slides)
{
    var transition = slide.SlideShowTransition;

    if (transition.AdvanceAfter)
    {
        Console.WriteLine($"Slide {slide.SlideNumber}: advance after {transition.AdvanceAfterTime} ms.");

        if (transition.AdvanceAfterTime > 2000)
        {
            transition.AdvanceAfter = false;
            transition.AdvanceOnClick = true;
        }
    }
}

presentation.Save("adjusted-transitions.pptx", SaveFormat.Pptx);
```

## **Contrôler le minutage de la transition avec précision**

Utilisez [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) pour spécifier la longueur exacte d’un effet de transition en millisecondes. La propriété [SlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideshowtransition/) de la diapositive expose ces réglages via [ISlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/):

| Property | Purpose |
| --- | --- |
| [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) | Sets the duration of the transition effect itself, in milliseconds. |
| [AdvanceAfterTime](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/advanceaftertime/) | Sets the delay before the slide advances automatically, in milliseconds. Enable [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/) to activate this timer. |
| [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) | Selects a predefined speed category from [TransitionSpeed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionspeed/): Slow, Medium, or Fast. It is used when an exact duration is not specified. |

[Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) ne contrôle que l’effet de transition ; il ne détermine pas la durée pendant laquelle la diapositive reste visible. Configurez le délai d’avancement automatique séparément. Lorsqu’aucune durée explicite n’est définie, Aspose.Slides détermine la durée de l’effet à partir du type de transition et de la valeur [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/).

### **Appliquer la même durée à chaque diapositive**

Pour une cadence cohérente, appliquez le même effet et la même durée exacte à chaque diapositive. Cet exemple charge `input.pptx`, sélectionne Fade depuis [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/), et attribue à chaque transition une durée de 750 ms. Il active séparément l’avancement automatique après 5 000 ms et désactive l’avancement par clic de souris, puis enregistre le résultat au format PPTX.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

foreach (var slide in presentation.Slides)
{
    var transition = slide.SlideShowTransition;
    transition.Type = TransitionType.Fade;
    transition.Duration = 750;

    // Configurer l'avancement automatique indépendamment de la durée de l'effet.
    transition.AdvanceAfter = true;
    transition.AdvanceAfterTime = 5000;
    transition.AdvanceOnClick = false;
}

presentation.Save("precise-transitions.pptx", SaveFormat.Pptx);
```

### **Définir des durées différentes pour des diapositives individuelles**

Des diapositives différentes peuvent utiliser des durées d’effet différentes. Par exemple, utilisez une transition courte pour une diapositive de titre et une transition plus longue pour une introduction de section. Cet exemple affecte 500 ms à la première diapositive et 1 200 ms à la deuxième. Utilisez un fichier `input.pptx` contenant au moins deux diapositives.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

if (presentation.Slides.Count >= 2)
{
    var firstTransition = presentation.Slides[0].SlideShowTransition;
    firstTransition.Type = TransitionType.Fade;
    firstTransition.Duration = 500;

    var secondTransition = presentation.Slides[1].SlideShowTransition;
    secondTransition.Type = TransitionType.Push;
    secondTransition.Duration = 1200;

    presentation.Save("individual-transition-durations.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The input presentation must contain at least two slides.");
}
```

### **Coordonner les transitions avec une sortie animée**

Lors de la préparation d’un [animated GIF](/slides/fr/net/convert-powerpoint-to-animated-gif/), d’une [HTML5 presentation](/slides/fr/net/export-to-html5/) ou d’une [video](/slides/fr/net/convert-powerpoint-to-video/), définissez les durées exactes des transitions avant l’exportation afin d’ajuster le rythme prévu. Par exemple, utilisez un fondu de 600 ms entre les scènes, et ajustez séparément le délai d’avancement de chaque diapositive pour laisser le temps à la narration ou au contenu.

Pour les GIF et les vidéos, synchronisez le taux d’images de sortie avec la durée de l’effet : 600 ms correspondent à 18 images à 30 images par seconde. En HTML5, activez les transitions animées dans les paramètres d’exportation. Vérifiez les effets et options de minutage pris en charge par le format d’export choisi, et prévisualisez la sortie pour confirmer la synchronisation.

### **Lire une durée de transition existante**

Lisez [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) avant de modifier la transition afin de déterminer si une valeur explicite est stockée. Une valeur de `-1` signifie qu’aucune durée explicite n’est définie ; une valeur non négative indique la durée stockée en millisecondes. La valeur non définie n’est pas la durée de lecture calculée : Aspose.Slides utilise le type de transition et [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) pour déterminer cette durée. La définition d’un type de transition peut initialiser une durée, il convient donc d’inspecter les paramètres d’origine d’abord.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");

foreach (var slide in presentation.Slides)
{
    var transition = slide.SlideShowTransition;
    var duration = transition.Duration;

    if (duration >= 0)
    {
        Console.WriteLine($"Slide {slide.SlideNumber}: stored transition duration is {duration} ms.");
    }
    else
    {
        Console.WriteLine($"Slide {slide.SlideNumber}: no explicit duration; timing depends on {transition.Type} and {transition.Speed}.");
    }
}
```

## **Transition Morph**

La transition Morph anime les changements entre les objets sur des diapositives consécutives. Pour créer un effet Morph simple, clonez une diapositive, déplacez ou redimensionnez un objet sur le clone, et appliquez la transition Morph à la deuxième diapositive. Cela donne aux objets correspondants la possibilité d’être animés entre leurs états d’origine et modifié.

L’exemple suivant crée une diapositive contenant un rectangle de texte, clone la diapositive, puis modifie la position et la taille du rectangle sur le clone. Il sélectionne ensuite Morph depuis l’énumération [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) pour la deuxième diapositive. Ouvrez le fichier enregistré dans un visualiseur de présentations qui prend en charge Morph pour voir l’effet pendant un diaporama.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation();

var firstSlide = presentation.Slides[0];
var rectangle = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
rectangle.TextFrame.Text = "Morph transition";

var secondSlide = presentation.Slides.AddClone(firstSlide);
var movedRectangle = secondSlide.Shapes[0];
movedRectangle.X += 100;
movedRectangle.Y += 50;
movedRectangle.Width -= 200;
movedRectangle.Height -= 10;

secondSlide.SlideShowTransition.Type = TransitionType.Morph;

presentation.Save("morph-transition.pptx", SaveFormat.Pptx);
```

## **Types de transition Morph**

L’énumération [TransitionMorphType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) contrôle la façon dont Morph associe et anime le contenu :

- [ByObject](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) traite chaque forme comme un objet complet.
- [ByWord](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) anime le texte en associant les mots lorsque c’est possible.
- [ByChar](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) anime le texte en associant les caractères lorsque c’est possible.

Définissez le [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) de la transition sur Morph avant d’accéder à son [Value](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/value/). La valeur fournit alors l’interface [IMorphTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition/), dont la propriété [MorphType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition/morphtype/) sélectionne le mode d’association.

Cet exemple ouvre la présentation créée dans la section précédente et configure la deuxième diapositive pour utiliser l’animation Morph basée sur les mots.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("morph-transition.pptx");

if (presentation.Slides.Count >= 2)
{
    var transition = presentation.Slides[1].SlideShowTransition;
    transition.Type = TransitionType.Morph;

    if (transition.Value is IMorphTransition morphTransition)
    {
        morphTransition.MorphType = TransitionMorphType.ByWord;
        presentation.Save("morph-by-word.pptx", SaveFormat.Pptx);
    }
    else
    {
        Console.WriteLine("Morph transition options are unavailable.");
    }
}
else
{
    Console.WriteLine("The input presentation must contain at least two slides.");
}
```


<!-- visual-explanation:slide-transition:start -->
[![Morph matching units shown as a whole shape, individual words, and individual characters.](visual-slide-transition-76bdbee41cb7.svg)](visual-slide-transition-76bdbee41cb7.svg)

*Morph can match whole shapes, words or characters where possible. These boxes identify matching units rather than observed motion. The example selects ByWord on the second slide.*
<!-- visual-explanation:slide-transition:end -->

## **Définir les effets de transition**

Certaines transitions exposent des options supplémentaires, telles que la direction ou le fait que l’effet démarre depuis un écran noir. Les options disponibles dépendent du [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) de transition sélectionné. Définissez d’abord le type, puis utilisez l’interface appropriée via son [Value](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/value/).

L’exemple suivant applique une transition Cut à la première diapositive de `input.pptx`. Il définit [FromBlack](https://reference.aspose.com/slides/net/aspose.slides.slideshow/ioptionalblacktransition/fromblack/) via [IOptionalBlackTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/ioptionalblacktransition/) afin que la transition démarre depuis un écran noir.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");
var transition = presentation.Slides[0].SlideShowTransition;
transition.Type = TransitionType.Cut;

if (transition.Value is IOptionalBlackTransition cutTransition)
{
    cutTransition.FromBlack = true;
    presentation.Save("cut-from-black.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("Cut transition options are unavailable.");
}
```

## **FAQ**

**Puis‑je contrôler la vitesse de lecture d’une transition de diapositive ?**

Oui. Privilégiez [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) lorsque vous avez besoin d’une durée d’effet exacte en millisecondes. Utilisez [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) lorsque la catégorie prédéfinie [TransitionSpeed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionspeed/) — Slow, Medium ou Fast — est suffisante et qu’aucune durée explicite n’est définie. Ces réglages contrôlent l’effet de transition indépendamment du délai d’avancement automatique.

**Puis‑je attacher un son à une transition et le faire boucler ?**

Oui. Assignez un son intégré à [Sound](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/sound/), définissez [SoundMode](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/soundmode/) sur StartSound depuis l’énumération [TransitionSoundMode](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionsoundmode/), et activez [SoundLoop](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/soundloop/). Le son boucle jusqu’au prochain événement sonore du diaporama.

**Quelle est la manière la plus rapide d’appliquer la même transition à chaque diapositive ?**

Parcourez la collection [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) de la présentation et définissez le [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) de chaque diapositive sur la même valeur. Appliquez les options de minutage et d’effet dans la même boucle afin de conserver un comportement cohérent sur toutes les diapositives.

**Comment vérifier quelle transition est actuellement définie sur une diapositive ?**

Lisez la propriété [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) de la [SlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideshowtransition/) de la diapositive. Elle renvoie une valeur de l’énumération [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) ; None signifie qu’aucun effet de transition n’est appliqué.