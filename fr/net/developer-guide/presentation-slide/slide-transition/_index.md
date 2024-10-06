---
title: Transition de diapositive
type: docs
weight: 90
url: /net/slide-transition/
keywords: "Ajouter une transition de diapositive, transition de diapositive PowerPoint, transition morphing, transition de diapositive avancée, effets de transition, C#, Csharp, .NET, Aspose.Slides"
description: "Ajouter une transition de diapositive PowerPoint et des effets de transition en C# ou .NET"
---

## **Ajouter une transition de diapositive**
Pour faciliter la compréhension, nous avons démontré l'utilisation d'Aspose.Slides pour .NET pour gérer les transitions de diapositive simples. Les développeurs peuvent non seulement appliquer différents effets de transition de diapositive, mais aussi personnaliser le comportement de ces effets de transition. Pour créer un effet de transition de diapositive simple, suivez les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Appliquez un type de transition de diapositive sur la diapositive à partir de l'un des effets de transition offerts par Aspose.Slides pour .NET via l'énumération TransitionType.
1. Écrivez le fichier de présentation modifié.

```c#
// Instancier la classe Presentation pour charger le fichier de présentation source
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    // Appliquer une transition de type cercle sur la diapositive 1
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Circle;

    // Appliquer une transition de type peigne sur la diapositive 2
    presentation.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    // Écrire la présentation sur le disque
    presentation.Save("SampleTransition_out.pptx", SaveFormat.Pptx);
}
```

## **Ajouter une transition de diapositive avancée**
Dans la section ci-dessus, nous avons simplement appliqué un effet de transition simple sur la diapositive. Maintenant, pour améliorer et contrôler cet effet de transition simple, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Appliquez un type de transition de diapositive sur la diapositive à partir de l'un des effets de transition offerts par Aspose.Slides pour .NET.
1. Vous pouvez également définir la transition pour avancer au clic, après une période de temps spécifique ou les deux.
1. Si la transition de diapositive est activée pour avancer au clic, la transition n'avancera que lorsque quelqu'un cliquera avec la souris. De plus, si la propriété Avancer après le temps est définie, la transition avancera automatiquement après que le temps d'avance spécifié sera écoulé.
1. Écrivez la présentation modifiée en tant que fichier de présentation.

```c#
// Instancier la classe Presentation qui représente un fichier de présentation
using (Presentation pres = new Presentation("BetterSlideTransitions.pptx"))
{

    // Appliquer une transition de type cercle sur la diapositive 1
    pres.Slides[0].SlideShowTransition.Type = TransitionType.Circle;

    // Définir le temps de transition de 3 secondes
    pres.Slides[0].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[0].SlideShowTransition.AdvanceAfterTime = 3000;

    // Appliquer une transition de type peigne sur la diapositive 2
    pres.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    // Définir le temps de transition de 5 secondes
    pres.Slides[1].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[1].SlideShowTransition.AdvanceAfterTime = 5000;

    // Appliquer une transition de type zoom sur la diapositive 3
    pres.Slides[2].SlideShowTransition.Type = TransitionType.Zoom;

    // Définir le temps de transition de 7 secondes
    pres.Slides[2].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[2].SlideShowTransition.AdvanceAfterTime = 7000;

    // Écrire la présentation sur le disque
    pres.Save("SampleTransition_out.pptx", SaveFormat.Pptx);
}
```

De plus, en utilisant la propriété [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/), vous pouvez vérifier si une transition de diapositive a été configurée pour passer à la diapositive suivante ou désactiver le paramètre.

Ce code C# démontre l'opération :

```c#
// Instancie une classe Presentation qui représente un fichier de présentation
using (Presentation pres = new Presentation("SampleTransition_out.pptx"))
{
    foreach (ISlide slide in pres.Slides)
    {
        // Obtient la transition de la diapositive
        ISlideShowTransition slideTransition = slide.SlideShowTransition;

        // Vérifie si le paramètre Avancer après le temps est activé
        if (slideTransition.AdvanceAfter)
        {
            // Affiche la valeur du temps d'avance après
            Console.WriteLine("La diapositive #" + slide.SlideNumber + " AdvancedAfterTime: " + slideTransition.AdvanceAfterTime);
        }

        // Désactive la transition après un temps spécifique si la valeur AdvancedAfterTime est supérieure à 2 secondes
        if (slideTransition.AdvanceAfterTime > 2000)
        {
            slideTransition.AdvanceAfter = false;
        }
    }
}
```

## **Transition Morph**
Aspose.Slides pour .NET prend désormais en charge la [Transition Morph](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition). Elle représente une nouvelle transition morphing introduite dans PowerPoint 2019. La transition Morph vous permet d'animer un mouvement fluide d'une diapositive à l'autre. Cet article décrit le concept et comment utiliser la transition Morph. Pour utiliser efficacement la transition Morph, vous aurez besoin de deux diapositives contenant au moins un objet en commun. La manière la plus simple est de dupliquer la diapositive, puis de déplacer l'objet sur la seconde diapositive à un endroit différent.

Le code suivant montre comment ajouter un clone de la diapositive avec un texte à la présentation et définir une transition de type [morph](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition/properties/morphtype) sur la seconde diapositive.

```c#
using (Presentation presentation = new Presentation())
{
    AutoShape autoshape = (AutoShape)presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.TextFrame.Text = "Transition Morph dans les présentations PowerPoint";

    presentation.Slides.AddClone(presentation.Slides[0]);

    presentation.Slides[1].Shapes[0].X += 100;
    presentation.Slides[1].Shapes[0].Y += 50;
    presentation.Slides[1].Shapes[0].Width -= 200;
    presentation.Slides[1].Shapes[0].Height -= 10;

    presentation.Slides[1].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Morph;

    presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```

## **Types de transition morph**
Une nouvelle énumération [Aspose.Slides.SlideShow.TransitionMorphType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype) a été ajoutée. Elle représente différents types de transitions morphing de diapositive.

L'énumération TransitionMorphType a trois membres :

- ParObjet : La transition morphing sera effectuée en considérant les formes comme des objets indivisibles.
- ParMot : La transition morphing sera effectuée en transférant le texte par mots lorsque cela est possible.
- ParCaractère : La transition morphing sera effectuée en transférant le texte par caractères lorsque cela est possible.

Le code suivant montre comment définir la transition morph sur la diapositive et changer le type morph :

```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Morph;
    ((IMorphTransition)presentation.Slides[0].SlideShowTransition.Value).MorphType = TransitionMorphType.ByWord;
    presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```

## **Définir les effets de transition**
Aspose.Slides pour .NET prend en charge la définition des effets de transition tels que, depuis le noir, depuis la gauche, depuis la droite, etc. Afin de définir l'effet de transition. Veuillez suivre les étapes ci-dessous :

- Créez une instance de la classe [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Obtenez la référence de la diapositive.
- Définir l'effet de transition.
- Écrivez la présentation en tant que fichier [PPTX ](https://docs.fileformat.com/presentation/pptx/).

Dans l'exemple ci-dessous, nous avons défini les effets de transition.

```c#
// Créer une instance de la classe Presentation
Presentation presentation = new Presentation("AccessSlides.pptx");

// Définir l'effet
presentation.Slides[0].SlideShowTransition.Type = TransitionType.Cut;
((OptionalBlackTransition)presentation.Slides[0].SlideShowTransition.Value).FromBlack = true;

// Écrire la présentation sur le disque
presentation.Save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
```