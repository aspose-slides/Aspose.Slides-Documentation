---
title: Transition de diapositive
type: docs
weight: 90
url: /fr/net/slide-transition/
keywords: "Ajouter une transition de diapositive, transition de diapositive PowerPoint, transition morph, transition de diapositive avancée, effets de transition, C#, Csharp, .NET, Aspose.Slides"
description: "Ajouter une transition de diapositive PowerPoint et des effets de transition en C# ou .NET"
---

## **Ajouter une transition de diapositive**
Pour faciliter la compréhension, nous avons démontré l’utilisation d’Aspose.Slides for .NET pour gérer des transitions de diapositive simples. Les développeurs peuvent non seulement appliquer différents effets de transition de diapositive aux diapositives, mais aussi personnaliser le comportement de ces effets de transition. Pour créer un effet de transition de diapositive simple, suivez les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Appliquez un type de transition de diapositive sur la diapositive à partir de l’un des effets de transition proposés par Aspose.Slides for .NET via l’énumération TransitionType.
3. Enregistrez le fichier de présentation modifié.
```c#
// Instancier la classe Presentation pour charger le fichier de présentation source
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    // Appliquer une transition de type cercle sur la diapositive 1
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Circle;

    // Appliquer une transition de type peigne sur la diapositive 2
    presentation.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    // Enregistrer la présentation sur le disque
    presentation.Save("SampleTransition_out.pptx", SaveFormat.Pptx);
}
```


## **Ajouter une transition de diapositive avancée**
Dans la section précédente, nous avons simplement appliqué un effet de transition simple sur la diapositive. Maintenant, pour rendre cet effet de transition simple encore meilleur et contrôlé, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Appliquez un type de transition de diapositive sur la diapositive à partir de l’un des effets de transition proposés par Aspose.Slides for .NET.
3. Vous pouvez également définir la transition sur Avance au clic, après une période de temps spécifique ou les deux.
4. Si la transition de diapositive est configurée sur Avance au clic, la transition ne s’avancera que lorsqu’on cliquera avec la souris. De plus, si la propriété Advance After Time est définie, la transition avancera automatiquement après le délai spécifié.
5. Enregistrez la présentation modifiée sous forme de fichier de présentation.
```c#
 // Instancier la classe Presentation qui représente un fichier de présentation
 using (Presentation pres = new Presentation("BetterSlideTransitions.pptx"))
 {
 
     // Appliquer une transition de type cercle sur la diapositive 1
     pres.Slides[0].SlideShowTransition.Type = TransitionType.Circle;
 
 
     // Définir le temps de transition à 3 secondes
     pres.Slides[0].SlideShowTransition.AdvanceOnClick = true;
     pres.Slides[0].SlideShowTransition.AdvanceAfterTime = 3000;
 
     // Appliquer une transition de type peigne sur la diapositive 2
     pres.Slides[1].SlideShowTransition.Type = TransitionType.Comb;
 
 
     // Définir le temps de transition à 5 secondes
     pres.Slides[1].SlideShowTransition.AdvanceOnClick = true;
     pres.Slides[1].SlideShowTransition.AdvanceAfterTime = 5000;
 
     // Appliquer une transition de type zoom sur la diapositive 3
     pres.Slides[2].SlideShowTransition.Type = TransitionType.Zoom;
 
 
     // Définir le temps de transition à 7 secondes
     pres.Slides[2].SlideShowTransition.AdvanceOnClick = true;
     pres.Slides[2].SlideShowTransition.AdvanceAfterTime = 7000;
 
     // Enregistrer la présentation sur le disque
     pres.Save("SampleTransition_out.pptx", SaveFormat.Pptx);
 }
```


De plus, en utilisant la propriété [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/), vous pouvez vérifier si une transition de diapositive a été configurée pour passer à la diapositive suivante ou désactiver le paramètre.

Ce code C# illustre le fonctionnement :
```c#
 // Instancie une classe Presentation qui représente un fichier de présentation
using (Presentation pres = new Presentation("SampleTransition_out.pptx"))
{
    foreach (ISlide slide in pres.Slides)
    {
        // Obtient la transition de la diapositive
        ISlideShowTransition slideTransition = slide.SlideShowTransition;

        // Vérifie si le paramètre AdvanceAfter est activé
        if (slideTransition.AdvanceAfter)
        {
            // Affiche la valeur du paramètre AdvanceAfterTime
            Console.WriteLine("The slide #" + slide.SlideNumber + " AdvancedAfterTime: " + slideTransition.AdvanceAfterTime);
        }

        // Désactive la transition après un temps spécifique si la valeur AdvanceAfterTime est supérieure à 2 secondes
        if (slideTransition.AdvanceAfterTime > 2000)
        {
            slideTransition.AdvanceAfter = false;
        }
    }
}
```


## **Transition Morph**
Aspose.Slides for .NET prend désormais en charge la [Morph Transition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition). Il s’agit d’une nouvelle transition morph introduite dans PowerPoint 2019. La transition Morph vous permet d’animer un déplacement fluide d’une diapositive à la suivante. Cet article décrit le concept et la façon d’utiliser la transition Morph. Pour utiliser efficacement la transition Morph, vous devez disposer de deux diapositives partageant au moins un objet commun. La manière la plus simple consiste à dupliquer la diapositive puis à déplacer l’objet sur la deuxième diapositive à un autre emplacement.

L’extrait de code suivant montre comment ajouter un clone de la diapositive contenant du texte à la présentation et définir une transition de [morph type](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition/properties/morphtype) sur la deuxième diapositive.
```c#
using (Presentation presentation = new Presentation())
{
    AutoShape autoshape = (AutoShape)presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.TextFrame.Text = "Morph Transition in PowerPoint Presentations";

    presentation.Slides.AddClone(presentation.Slides[0]);

    presentation.Slides[1].Shapes[0].X += 100;
    presentation.Slides[1].Shapes[0].Y += 50;
    presentation.Slides[1].Shapes[0].Width -= 200;
    presentation.Slides[1].Shapes[0].Height -= 10;

    presentation.Slides[1].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Morph;

    presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```


## **Types de transition Morph**
Le nouvel énumérateur [Aspose.Slides.SlideShow.TransitionMorphType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype) a été ajouté. Il représente différents types de transition de diapositive Morph.

L’énumération TransitionMorphType comporte trois membres :

- ByObject : la transition Morph sera effectuée en considérant les formes comme des objets indivisibles.
- ByWord : la transition Morph sera effectuée en transférant le texte mot par mot lorsque cela est possible.
- ByChar : la transition Morph sera effectuée en transférant le texte caractère par caractère lorsque cela est possible.

L’extrait de code suivant montre comment définir une transition morph sur une diapositive et changer le type de morph :
```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Morph;
    ((IMorphTransition)presentation.Slides[0].SlideShowTransition.Value).MorphType = TransitionMorphType.ByWord;
    presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```


## **Définir les effets de transition**
Aspose.Slides for .NET prend en charge la configuration des effets de transition tels que, depuis le noir, depuis la gauche, depuis la droite, etc. Pour définir l’effet de transition, veuillez suivre les étapes ci-dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Obtenez la référence de la diapositive.
- Définissez l’effet de transition.
- Enregistrez la présentation sous forme de fichier [PPTX](https://docs.fileformat.com/presentation/pptx/).

Dans l’exemple ci dessous, nous avons défini les effets de transition.
```c#
// Créez une instance de la classe Presentation
Presentation presentation = new Presentation("AccessSlides.pptx");

// Définir l'effet
presentation.Slides[0].SlideShowTransition.Type = TransitionType.Cut;
((OptionalBlackTransition)presentation.Slides[0].SlideShowTransition.Value).FromBlack = true;

// Enregistrez la présentation sur le disque
presentation.Save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
```


## **FAQ**

**Puis‑je contrôler la vitesse de lecture d’une transition de diapositive ?**  
Oui. Définissez la [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) de la transition à l’aide du paramètre [TransitionSpeed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionspeed/) (par ex. lent/moyen/rapide).

**Puis‑je attacher un audio à une transition et le faire boucler ?**  
Oui. Vous pouvez intégrer un son pour la transition et contrôler le comportement via des paramètres tels que le mode son et la boucle (par ex. [Sound](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/sound/), [SoundMode](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/soundmode/), [SoundLoop](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/soundloop/), ainsi que les métadonnées telles que [SoundIsBuiltIn](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/soundisbuiltin/) et [SoundName](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/soundname/)).

**Quelle est la façon la plus rapide d’appliquer la même transition à chaque diapositive ?**  
Configurez le type de transition souhaité dans les paramètres de transition de chaque diapositive ; les transitions sont stockées par diapositive, donc appliquer le même type à toutes les diapositives donne un résultat cohérent.

**Comment puis‑je vérifier quelle transition est actuellement définie sur une diapositive ?**  
Inspectez les [paramètres de transition](https://reference.aspose.com/slides/net/aspose.slides/baseslide/slideshowtransition/) de la diapositive et lisez son [type de transition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/type/) ; cette valeur indique exactement quel effet est appliqué.