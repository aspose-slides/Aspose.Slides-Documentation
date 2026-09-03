---
title: Gestion des transitions de diapositives dans les présentations en .NET
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
description: "Appliquez des transitions de diapositives, configurez l’avancement automatique des diapositives et personnalisez les transitions Morph et autres effets de transition avec Aspose.Slides pour .NET."
---
## **Vue d'ensemble**

Les transitions de diapositives contrôlent la manière dont les diapositives apparaissent pendant un diaporama. Avec Aspose.Slides for .NET, vous pouvez choisir un effet de transition pour chaque diapositive, configurer le passage par clic de souris ou par minuteur, et ajuster les options spécifiques à un effet. Cet article utilise des exemples C# pour appliquer des transitions, définir des durées de transition précises, gérer le minutage des diapositives et créer une transition Morph entre deux diapositives. Les exemples montrent également comment enregistrer les paramètres dans un fichier PPTX.

## **Ajouter une transition de diapositive**

Pour appliquer une transition, chargez une présentation avec la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/) et accédez à la propriété [SlideShowTransition](https://reference.aspose.com/slides/fr/net/aspose.slides/ibaseslide/slideshowtransition/) de la diapositive. Définissez son [Type](https://reference.aspose.com/slides/fr/net/aspose.slides/islideshowtransition/type/) sur une valeur de l’énumération [TransitionType](https://reference.aspose.com/slides/fr/net/aspose.slides.slideshow/transitiontype/), puis enregistrez la présentation.

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

## **Ajouter une transition de diapositive avancée**

Vous pouvez configurer la durée pendant laquelle une diapositive reste à l’écran et si un clic de souris fait avancer le diaporama. Les propriétés suivantes contrôlent ce comportement :

- [AdvanceOnClick](https://reference.aspose.com/slides/fr/net/aspose.slides/islideshowtransition/advanceonclick/) permet au spectateur de faire avancer la présentation en cliquant.
- [AdvanceAfter](https://reference.aspose.com/slides/fr/net/aspose.slides/islideshowtransition/advanceafter/) active l’avancement automatique.
- [AdvanceAfterTime](https://reference.aspose.com/slides/fr/net/aspose.slides/islideshowtransition/advanceaftertime/) indique le délai avant l’avancement automatique, en millisecondes.

Activez à la fois l’avancement par clic et le minutage pour permettre au spectateur de passer à la diapositive suivante soit en cliquant, soit en attendant le minuteur. Pour n’utiliser que le minuteur, définissez [AdvanceOnClick](https://reference.aspose.com/slides/fr/net/aspose.slides/islideshowtransition/advanceonclick/) sur `false`. Le délai contrôle le moment où le diaporama avance ; il ne fixe pas la durée de l’effet visuel de transition.

Cet exemple attribue différents effets aux trois premières diapositives et active l’avancement automatique après 3, 5 et 7 secondes, respectivement. Les clics de souris peuvent également faire avancer ces diapositives. Utilisez un fichier `input.pptx` contenant au moins trois diapositives.

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

Pour vérifier si l’avancement chronométré est activé, lisez [AdvanceAfter](https://reference.aspose.com/slides/fr/net/aspose.slides/islideshowtransition/advanceafter/). Un délai stocké seul n’indique pas que le minuteur est actif.

L’exemple suivant ouvre le fichier enregistré ci‑dessus, signale chaque minuteur activé et désactive l’avancement automatique pour les diapositives dont le délai dépasse deux secondes. Il active les clics de souris pour ces diapositives et enregistre les paramètres mis à jour.

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

## **Contrôler précisément le minutage des transitions**

Utilisez [Duration](https://reference.aspose.com/slides/fr/net/aspose.slides.slideshow/slideshowtransition/duration/) pour spécifier la longueur exacte d’un effet de transition en millisecondes. La propriété [SlideShowTransition](https://reference.aspose.com/slides/fr/net/aspose.slides/ibaseslide/slideshowtransition/) de la diapositive expose ces paramètres via [ISlideShowTransition](https://reference.aspose.com/slides/fr/net/aspose.slides/islideshowtransition/) :

| Propriété | Objectif |
| --- | --- |
| [Duration](https://reference.aspose.com/slides/fr/net/aspose.slides.slideshow/slideshowtransition/duration/) | Définit la durée de l’effet de transition lui‑même, en millisecondes. |
| [AdvanceAfterTime](https://reference.aspose.com/slides/fr/net/aspose.slides.slideshow/slideshowtransition/advanceaftertime/) | Définit le délai avant que la diapositive avance automatiquement, en millisecondes. Activez [AdvanceAfter](https://reference.aspose.com/slides/fr/net/aspose.slides/islideshowtransition/advanceafter/) pour activer ce minuteur. |
| [Speed](https://reference.aspose.com/slides/fr/net/aspose.slides.slideshow/slideshowtransition/speed/) | Sélectionne une catégorie de vitesse prédéfinie dans [TransitionSpeed](https://reference.aspose.com/slides/fr/net/aspose.slides.slideshow/transitionspeed/) : Slow, Medium ou Fast. Elle est utilisée lorsqu’une durée exacte n’est pas spécifiée. |

[Duration](https://reference.aspose.com/slides/fr/net/aspose.slides.slideshow/slideshowtransition/duration/) ne contrôle que l’effet de transition ; il ne détermine pas la durée pendant laquelle la diapositive reste visible. Configurez séparément le délai d’avancement automatique. Lorsqu’aucune durée explicite n’est définie, Aspose.Slides détermine la durée de l’effet à partir du type de transition et de la valeur [Speed](https://reference.aspose.com/slides/fr/net/aspose.slides.slideshow/slideshowtransition/speed/).

### **Appliquer la même durée à chaque diapositive**

Pour un rythme cohérent, appliquez le même effet et la même durée exacte à chaque diapositive. Cet exemple charge `input.pptx`, sélectionne Fade dans [TransitionType](https://reference.aspose.com/slides/fr/net/aspose.slides.slideshow/transitiontype/), et attribue à chaque transition une durée de 750 millisecondes. Il active séparément l’avancement automatique après 5 000 millisecondes et désactive l’avancement par clic de souris, puis enregistre le résultat au format PPTX.

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

    // Configurez l'avancement automatique independamment de la duree de l'effet.
    transition.AdvanceAfter = true;
    transition.AdvanceAfterTime = 5000;
    transition.AdvanceOnClick = false;
}

presentation.Save("precise-transitions.pptx", SaveFormat.Pptx);
```

### **Définir des durées différentes pour des diapositives individuelles**

Des diapositives différentes peuvent utiliser des durées d’effet différentes. Par exemple, utilisez une transition brève pour une diapositive titre et une transition plus longue pour une introduction de section. Cet exemple fixe 500 millisecondes pour la première diapositive et 1 200 millisecondes pour la deuxième. Utilisez un fichier `input.pptx` contenant au moins deux diapositives.

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

Lors de la préparation d’un [GIF animé](/slides/fr/net/convert-powerpoint-to-animated-gif/), d’une [présentation HTML5](/slides/fr/net/export-to-html5/) ou d’une [vidéo](/slides/fr/net/convert-powerpoint-to-video/), définissez des durées de transition exactes avant l’exportation afin d’adapter le rythme souhaité. Par exemple, utilisez un fondu de 600 millisecondes entre les scènes et ajustez séparément le délai d’avancement de chaque diapositive pour laisser le temps à la narration ou au contenu.

Pour les GIF et les vidéos, coordonnez le taux d’images de sortie avec la durée de l’effet : 600 millisecondes correspondent à 18 images à 30 images par seconde. En HTML5, activez les transitions animées dans les paramètres d’exportation. Vérifiez les effets et options de minutage pris en charge par le format d’exportation choisi, et prévisualisez la sortie pour confirmer la synchronisation.

### **Lire la durée d’une transition existante**

Lisez [Duration](https://reference.aspose.com/slides/fr/net/aspose.slides.slideshow/slideshowtransition/duration/) avant de modifier la transition afin de déterminer si une valeur explicite est stockée. Une valeur de `-1` signifie qu’aucune durée explicite n’est définie ; une valeur non négative indique la durée stockée en millisecondes. Cette valeur non définie n’est pas la durée de lecture calculée : Aspose.Slides utilise le type de transition et [Speed](https://reference.aspose.com/slides/fr/net/aspose.slides.slideshow/slideshowtransition/speed/) pour déterminer cette durée. La définition d’un type de transition peut initialiser une durée, il faut donc d’abord inspecter les paramètres d’origine.

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

La transition Morph anime les changements entre les objets sur des diapositives consécutives. Pour créer un effet Morph simple, clonez une diapositive, déplacez ou redimensionnez un objet sur le clone, puis appliquez la transition Morph à la deuxième diapositive. Cela fournit à la transition les objets correspondants à animer entre leurs états d’origine et modifiés.

L’exemple suivant crée une diapositive contenant un rectangle de texte, clone la diapositive et modifie la position et la taille du rectangle sur le clone. Il sélectionne ensuite Morph dans l’énumération [TransitionType](https://reference.aspose.com/slides/fr/net/aspose.slides.slideshow/transitiontype/) pour la deuxième diapositive. Ouvrez le fichier enregistré dans un visualiseur de présentations prenant en charge Morph pour voir l’effet pendant le diaporama.

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

L’énumération [TransitionMorphType](https://reference.aspose.com/slides/fr/net/aspose.slides.slideshow/transitionmorphtype/) contrôle la façon dont Morph associe et anime le contenu :

- [ByObject](https://reference.aspose.com/slides/fr/net/aspose.slides.slideshow/transitionmorphtype/) traite chaque forme comme un objet complet.
- [ByWord](https://reference.aspose.com/slides/fr/net/aspose.slides.slideshow/transitionmorphtype/) anime le texte en associant les mots lorsque cela est possible.
- [ByChar](https://reference.aspose.com/slides/fr/net/aspose.slides.slideshow/transitionmorphtype/) anime le texte en associant les caractères lorsque cela est possible.

Définissez le [Type](https://reference.aspose.com/slides/fr/net/aspose.slides/islideshowtransition/type/) de la transition sur Morph avant d’accéder à sa [Value](https://reference.aspose.com/slides/fr/net/aspose.slides/islideshowtransition/value/). La valeur fournit alors l’interface [IMorphTransition](https://reference.aspose.com/slides/fr/net/aspose.slides.slideshow/imorphtransition/), dont la propriété [MorphType](https://reference.aspose.com/slides/fr/net/aspose.slides.slideshow/imorphtransition/morphtype/) sélectionne le mode d’association.

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

## **Définir les effets de transition**

Certaines transitions exposent des options supplémentaires, comme la direction ou si l’effet démarre depuis un écran noir. Les options disponibles dépendent du [Type](https://reference.aspose.com/slides/fr/net/aspose.slides/islideshowtransition/type/) de transition sélectionné. Définissez d’abord le type, puis utilisez l’interface appropriée depuis sa [Value](https://reference.aspose.com/slides/fr/net/aspose.slides/islideshowtransition/value/).

L’exemple suivant applique une transition Cut à la première diapositive de `input.pptx`. Il définit [FromBlack](https://reference.aspose.com/slides/fr/net/aspose.slides.slideshow/ioptionalblacktransition/fromblack/) via [IOptionalBlackTransition](https://reference.aspose.com/slides/fr/net/aspose.slides.slideshow/ioptionalblacktransition/) afin que la transition commence depuis un écran noir.

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

Oui. Privilégiez [Duration](https://reference.aspose.com/slides/fr/net/aspose.slides.slideshow/slideshowtransition/duration/) lorsque vous avez besoin d’une durée d’effet exacte en millisecondes. Utilisez [Speed](https://reference.aspose.com/slides/fr/net/aspose.slides.slideshow/slideshowtransition/speed/) lorsqu’une catégorie prédéfinie de [TransitionSpeed](https://reference.aspose.com/slides/fr/net/aspose.slides.slideshow/transitionspeed/) – Slow, Medium ou Fast – suffit et qu’aucune durée explicite n’est définie. Ces paramètres contrôlent l’effet de transition indépendamment du délai d’avancement automatique.

**Puis‑je attacher un son à une transition et le faire boucler ?**

Oui. Assignez le son intégré à [Sound](https://reference.aspose.com/slides/fr/net/aspose.slides/islideshowtransition/sound/), définissez [SoundMode](https://reference.aspose.com/slides/fr/net/aspose.slides/islideshowtransition/soundmode/) sur StartSound provenant de l’énumération [TransitionSoundMode](https://reference.aspose.com/slides/fr/net/aspose.slides.slideshow/transitionsoundmode/), et activez [SoundLoop](https://reference.aspose.com/slides/fr/net/aspose.slides/islideshowtransition/soundloop/). Le son se répète jusqu’au prochain événement sonore du diaporama.

**Quel est le moyen le plus rapide d’appliquer la même transition à toutes les diapositives ?**

Parcourez la collection [Slides](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/slides/fr/) de la présentation et définissez pour chaque diapositive le [Type](https://reference.aspose.com/slides/fr/net/aspose.slides/islideshowtransition/type/) de transition sur la même valeur. Définissez les options de minutage et d’effet dans la même boucle afin de maintenir un comportement cohérent sur l’ensemble des diapositives.

**Comment vérifier quelle transition est actuellement définie sur une diapositive ?**

Lisez la propriété [Type](https://reference.aspose.com/slides/fr/net/aspose.slides/islideshowtransition/type/) de la [SlideShowTransition](https://reference.aspose.com/slides/fr/net/aspose.slides/ibaseslide/slideshowtransition/) de la diapositive. Elle renvoie une valeur de l’énumération [TransitionType](https://reference.aspose.com/slides/fr/net/aspose.slides.slideshow/transitiontype/) ; None signifie qu’aucun effet de transition n’est appliqué.