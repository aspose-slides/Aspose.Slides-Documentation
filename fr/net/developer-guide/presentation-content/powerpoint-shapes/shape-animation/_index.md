---
title: Appliquer des animations de forme dans les présentations en .NET
linktitle: Animation de forme
type: docs
weight: 60
url: /fr/net/shape-animation/
keywords:
- forme
- animation
- effet
- forme animée
- texte animé
- ajouter animation
- obtenir animation
- extraire animation
- ajouter effet
- obtenir effet
- extraire effet
- son d'effet
- appliquer animation
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Découvrez comment créer et personnaliser des animations de forme dans les présentations PowerPoint avec Aspose.Slides pour .NET. Démarquez-vous!"
---

Les animations sont des effets visuels qui peuvent être appliqués aux textes, images, formes ou aux [graphiques](/slides/fr/net/animated-charts/). Elles donnent vie aux présentations ou à leurs constituants. 

## **Pourquoi utiliser les animations dans les présentations ?**

Utiliser les animations, vous pouvez 

* contrôler le flux d’informations
* mettre en évidence les points importants
* accroître l’intérêt ou la participation de votre public
* rendre le contenu plus facile à lire, assimiler ou traiter
* attirer l’attention de vos lecteurs ou spectateurs sur les parties importantes d’une présentation

PowerPoint propose de nombreuses options et outils pour les animations et les effets d’animation dans les catégories **entrées**, **sorties**, **emphase** et **chemins de mouvement**. 

## **Animations dans Aspose.Slides**

* Aspose.Slides fournit les classes et types dont vous avez besoin pour travailler avec les animations dans l’espace de noms [Aspose.Slides.Animation](https://reference.aspose.com/slides/net/aspose.slides.animation/),
* Aspose.Slides fournit plus de **150 effets d'animation** dans l’énumération [EffectType](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttype). Ces effets sont essentiellement les mêmes (ou équivalents) que ceux utilisés dans PowerPoint.

## **Appliquer une animation à TextBox**

Aspose.Slides pour .NET vous permet d’appliquer une animation au texte d’une forme. 

1. Créez une instance de la classe [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/).
2. Obtenez une référence à une diapositive via son indice.
3. Ajoutez une [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) de type `rectangle`. 
4. Ajoutez du texte à [IAutoShape.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/properties/textframe).
5. Récupérez la séquence principale d’effets.
6. Ajoutez un effet d’animation à [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape).
7. Définissez la propriété [TextAnimation.BuildType](https://reference.aspose.com/slides/net/aspose.slides.animation/textanimation/properties/buildtype) sur la valeur de l’[énumération BuildType](https://reference.aspose.com/slides/net/aspose.slides.animation/buildtype).
8. Enregistrez la présentation sur le disque au format PPTX.

Ce code C# montre comment appliquer l’effet `Fade` à AutoShape et définir l’animation du texte sur la valeur *By 1st Level Paragraphs* :
```c#
// Instancie une classe de présentation qui représente un fichier de présentation.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    
    // Ajoute une nouvelle AutoShape avec du texte
    IAutoShape autoShape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "First paragraph \nSecond paragraph \n Third paragraph";

    // Obtient la séquence principale de la diapositive.
    ISequence sequence = sld.Timeline.MainSequence;

    // Ajoute l'effet d'animation Fade à la forme
    IEffect effect = sequence.AddEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Anime le texte de la forme par paragraphes de premier niveau
    effect.TextAnimation.BuildType = BuildType.ByLevelParagraphs1;

    // Enregistre le fichier PPTX sur le disque
    pres.Save(path + "AnimTextBox_out.pptx", SaveFormat.Pptx);
}
```


{{%  alert color="primary"  %}} 
En plus d’appliquer des animations au texte, vous pouvez également appliquer des animations à un seul [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph). Voir [**Texte animé**](/slides/fr/net/animated-text/).
{{% /alert %}} 

## **Appliquer une animation à PictureFrame**

1. Créez une instance de la classe [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/).
2. Obtenez une référence à une diapositive via son indice.
3. Ajoutez ou récupérez un [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe) sur la diapositive. 
5. Récupérez la séquence principale d’effets.
6. Ajoutez un effet d’animation à [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe).
8. Enregistrez la présentation sur le disque au format PPTX.

Ce code C# montre comment appliquer l’effet `Fly` à un cadre d’image :
```c#
// Instancie une classe de présentation qui représente un fichier de présentation.
using (Presentation pres = new Presentation())
{
    // Charge une image à ajouter dans la collection d'images de la présentation
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Ajoute un cadre d'image à la diapositive
    IPictureFrame picFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // Obtient la séquence principale de la diapositive.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Ajoute l'effet d'animation Fly depuis la gauche au cadre d'image
    IEffect effect = sequence.AddEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Enregistre le fichier PPTX sur le disque
    pres.Save("AnimImage_out.pptx", SaveFormat.Pptx);
}
```


## **Appliquer une animation à Shape**

1. Créez une instance de la classe [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/).
2. Obtenez une référence à une diapositive via son indice.
3. Ajoutez une [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) `rectangle`. 
4. Ajoutez un `Bevel` [IAutoShape] (lorsque cet objet est cliqué, l’animation est lancée).
5. Créez une séquence d’effets sur la forme Bevel.
6. Créez un `UserPath` personnalisé.
7. Ajoutez des commandes pour se déplacer vers le `UserPath`.
8. Enregistrez la présentation sur le disque au format PPTX.

Ce code C# montre comment appliquer l’effet `PathFootball` (chemin football) à une forme :
```c#
// Instancie une classe Presentation qui représente un fichier de présentation.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // Crée l'effet PathFootball pour la forme existante à partir de zéro.
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);

    ashp.AddTextFrame("Animated TextBox");

    // Ajoute l'effet d'animation PathFootball.
    pres.Slides[0].Timeline.MainSequence.AddEffect(ashp, EffectType.PathFootball,
                           EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Crée une sorte de "button".
    IShape shapeTrigger = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Crée une séquence d'effets pour le bouton.
    ISequence seqInter = pres.Slides[0].Timeline.InteractiveSequences.Add(shapeTrigger);

    // Crée un chemin utilisateur personnalisé. Notre objet ne sera déplacé qu'après le clic sur le bouton.
    IEffect fxUserPath = seqInter.AddEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

    // Ajoute des commandes de déplacement puisque le chemin créé est vide.
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.Behaviors[0]);

    PointF[] pts = new PointF[1];
    pts[0] = new PointF(0.076f, 0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new PointF(-0.076f, -0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.Path.Add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

    // Écrit le fichier PPTX sur le disque
    pres.Save("AnimExample_out.pptx", SaveFormat.Pptx);
}
```


## **Obtenir les effets d'animation appliqués à Shape**

Les exemples suivants montrent comment utiliser la méthode `GetEffectsByShape` de l’interface [ISequence](https://reference.aspose.com/slides/net/aspose.slides.animation/isequence/) pour récupérer tous les effets d’animation appliqués à une forme.

**Exemple 1 : Obtenir les effets d'animation appliqués à une forme sur une diapositive normale**

Dans la partie précédente, vous avez appris comment ajouter des effets d’animation aux formes dans les présentations PowerPoint. Le code d’exemple suivant montre comment obtenir les effets appliqués à la première forme sur la première diapositive normale du fichier `AnimExample_out.pptx`.
```c#
using (Presentation presentation = new Presentation("AnimExample_out.pptx"))
{
    ISlide firstSlide = presentation.Slides[0];

    // Obtient la séquence d'animation principale de la diapositive.
    ISequence sequence = firstSlide.Timeline.MainSequence;

    // Obtient la première forme de la première diapositive.
    IShape shape = firstSlide.Shapes[0];

    // Obtient les effets d'animation appliqués à la forme.
    IEffect[] shapeEffects = sequence.GetEffectsByShape(shape);

    if (shapeEffects.Length > 0)
        Console.WriteLine($"The shape {shape.Name} has {shapeEffects.Length} animation effects.");
}
```


**Exemple 2 : Obtenir tous les effets d'animation, y compris ceux hérités des espaces réservés**

Si une forme sur une diapositive normale possède des espaces réservés provenant de la diapositive de mise en page et/ou de la diapositive maître, et que des effets d’animation ont été ajoutés à ces espaces réservés, alors tous les effets de la forme seront lus pendant le diaporama, y compris ceux hérités.

Imaginons un fichier PowerPoint `sample.pptx` contenant une seule diapositive avec uniquement une forme de pied de page affichant le texte « Made with Aspose.Slides » et l’effet **Random Bars** appliqué à la forme.

![Effet d'animation de forme de diapositive](slide-shape-animation.png)

Supposons également que l’effet **Split** soit appliqué à l’espace réservé du pied de page sur la diapositive de **mise en page**.

![Effet d'animation de forme de mise en page](layout-shape-animation.png)

Et enfin, que l’effet **Fly In** soit appliqué à l’espace réservé du pied de page sur la diapositive **maître**.

![Effet d'animation de forme maîtresse](master-shape-animation.png)

Le code d’exemple suivant montre comment utiliser la méthode `GetBasePlaceholder` de l’interface [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) pour accéder aux espaces réservés de la forme et récupérer les effets d’animation appliqués à la forme de pied de page, y compris ceux hérités des espaces réservés situés sur les diapositives de mise en page et maîtres.
```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Obtient les effets d'animation de la forme sur la diapositive normale.
    IShape shape = slide.Shapes[0];
    IEffect[] shapeEffects = slide.Timeline.MainSequence.GetEffectsByShape(shape);

    // Obtient les effets d'animation du espace réservé sur la diapositive de mise en page.
    IShape layoutShape = shape.GetBasePlaceholder();
    IEffect[] layoutShapeEffects = slide.LayoutSlide.Timeline.MainSequence.GetEffectsByShape(layoutShape);

    // Obtient les effets d'animation du espace réservé sur la diapositive maître.
    IShape masterShape = layoutShape.GetBasePlaceholder();
    IEffect[] masterShapeEffects = slide.LayoutSlide.MasterSlide.Timeline.MainSequence.GetEffectsByShape(masterShape);

    Console.WriteLine("Main sequence of shape effects:");
    PrintEffects(masterShapeEffects);
    PrintEffects(layoutShapeEffects);
    PrintEffects(shapeEffects);
}
```

```cs
static void PrintEffects(IEnumerable<IEffect> effects)
{
    foreach (IEffect effect in effects)
    {
        Console.WriteLine($"{effect.Type} {effect.Subtype}");
    }
}
```


Output:
```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```


## **Modifier les propriétés de synchronisation des effets d'animation**

Aspose.Slides pour .NET vous permet de modifier les propriétés de synchronisation d’un effet d’animation.

Voici le volet de synchronisation des animations et le menu étendu dans Microsoft PowerPoint :

![example1_image](shape-animation.png)

Voici les correspondances entre le minutage PowerPoint et les propriétés [Effect.Timing](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/properties/timing) :

- La liste déroulante **Start** du minutage PowerPoint correspond à la propriété [Effect.Timing.TriggerType](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/properties/triggertype). 
- La valeur **Duration** du minutage PowerPoint correspond à la propriété [Effect.Timing.Duration](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/properties/duration). La durée d’une animation (en secondes) est le temps total nécessaire à l’animation pour effectuer un cycle. 
- La valeur **Delay** du minutage PowerPoint correspond à la propriété [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/properties/triggerdelaytime). 
- La liste déroulante **Repeat** du minutage PowerPoint correspond à ces propriétés :
  * la propriété [Effect.Timing.RepeatCount](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatcount) qui décrit le *nombre* de répétitions de l’effet ;
  * le drapeau [Effect.Timing.RepeatUntilEndSlide](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatuntilendslide) qui indique si l’effet se répète jusqu’à la fin de la diapositive ;
  * le drapeau [Effect.Timing.RepeatUntilNextClick](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatuntilnextclick) qui indique si l’effet se répète jusqu’au clic suivant.
- La case à cocher **Rewind when done playing** du minutage PowerPoint correspond à la propriété [Effect.Timing.Rewind](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/rewind/). 

Voici comment modifier les propriétés de synchronisation d’un effet :

1. [Appliquer](#apply-animation-to-shape) ou récupérer l’effet d’animation.
2. Définir de nouvelles valeurs pour les propriétés [Effect.Timing](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/properties/timing) dont vous avez besoin. 
3. Enregistrez le fichier PPTX modifié.

Ce code C# illustre l’opération :
```c#
// Instancie une classe de présentation qui représente un fichier de présentation.
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
    // Obtient la séquence principale de la diapositive.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Obtient le premier effet de la séquence principale.
    IEffect effect = sequence[0];

    // Modifie le TriggerType de l’effet pour démarrer au clic
    effect.Timing.TriggerType = EffectTriggerType.OnClick;

    // Modifie la durée de l’effet
    effect.Timing.Duration = 3f;

    // Modifie le TriggerDelayTime de l’effet
    effect.Timing.TriggerDelayTime = 0.5f;

    // Si la valeur Repeat de l’effet est "none"
    if (effect.Timing.RepeatCount == 1f)
    {
        // Modifie le Repeat de l’effet à "Jusqu’au prochain clic"
        effect.Timing.RepeatUntilNextClick = true;
    }
    else
    {
        // Modifie le Repeat de l’effet à "Jusqu’à la fin de la diapositive"
        effect.Timing.RepeatUntilEndSlide = true;
    }

    // Active le Rewind de l’effet
        effect.Timing.Rewind = true;
    
    // Enregistre le fichier PPTX sur le disque
    pres.Save("AnimExample_changed.pptx", SaveFormat.Pptx);
}
```


## **Son des effets d'animation**

Aspose.Slides propose ces propriétés pour travailler avec les sons des effets d’animation : 
- [IEffect.Sound](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/sound/) 
- [IEffect.StopPreviousSound](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/stopprevioussound/) 

### **Ajouter le son d'un effet d'animation**

Ce code C# montre comment ajouter un son à un effet d’animation et l’arrêter lorsque l’effet suivant démarre :
```c#
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
	// Ajoute audio à la collection audio de la présentation
	IAudio effectSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// Obtient la séquence principale de la diapositive.
	ISequence sequence = firstSlide.Timeline.MainSequence;

	// Obtient le premier effet de la séquence principale
	IEffect firstEffect = sequence[0];

	// Vérifie l'effet pour "No Sound"
	if (!firstEffect.StopPreviousSound && firstEffect.Sound == null)
	{
		// Ajoute le son pour le premier effet
		firstEffect.Sound = effectSound;
	}

	// Obtient la première séquence interactive de la diapositive.
	ISequence interactiveSequence = firstSlide.Timeline.InteractiveSequences[0];

	// Définit le drapeau "Stop previous sound" de l'effet
	interactiveSequence[0].StopPreviousSound = true;

	// Écrit le fichier PPTX sur le disque
	pres.Save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
}
```


### **Extraire le son d'un effet d'animation**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Obtenez une référence à une diapositive via son indice. 
3. Récupérez la séquence principale d’effets. 
4. Extrayez le [Sound](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/sound/) intégré à chaque effet d’animation. 

Ce code C# montre comment extraire le son intégré à un effet d’animation :
```c#
// Instancie une classe de présentation qui représente un fichier de présentation.
using (Presentation presentation = new Presentation("EffectSound.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Obtient la séquence principale de la diapositive.
    ISequence sequence = slide.Timeline.MainSequence;

    foreach (IEffect effect in sequence)
    {
        if (effect.Sound == null)
            continue;

        // Extrait le son de l'effet dans un tableau d'octets
        byte[] audio = effect.Sound.BinaryData;
    }
}
```


## **Après l'animation**

Aspose.Slides pour .NET vous permet de modifier la propriété « After animation » d’un effet d’animation.

Voici le volet de l’effet d’animation et le menu étendu dans Microsoft PowerPoint :

![example1_image](shape-after-animation.png)

La liste déroulante **After animation** du volet PowerPoint correspond à ces propriétés : 

- La propriété [IEffect.AfterAnimationType](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/afteranimationtype/) qui décrit le type d’animation après :
  * **More Colors** correspond au type [AfterAnimationType.Color](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/);
  * **Don't Dim** correspond au type [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/) (type par défaut) ;
  * **Hide After Animation** correspond au type [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/) ;
  * **Hide on Next Mouse Click** correspond au type [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/).
- La propriété [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/afteranimationcolor/) qui définit le format couleur après l’animation. Cette propriété fonctionne avec le type [AfterAnimationType.Color](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/). Si vous changez le type, la couleur après l’animation sera réinitialisée.

Ce code C# montre comment modifier un effet d’animation après :
```c#
// Instancie une classe de présentation qui représente un fichier de présentation
using (Presentation pres = new Presentation("AnimImage_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // Obtient le premier effet de la séquence principale
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // Modifie le type d'animation après en Couleur
    firstEffect.AfterAnimationType = AfterAnimationType.Color;

    // Définit la couleur d'atténuation après l'animation
    firstEffect.AfterAnimationColor.Color = Color.AliceBlue;

    // Enregistre le fichier PPTX sur le disque
    pres.Save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
}
```


## **Animer le texte**

Aspose.Slides propose ces propriétés pour travailler avec le bloc *Animate text* d’un effet d’animation :

- [IEffect.AnimateTextType](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/animatetexttype/) qui décrit le type d’animation du texte. Le texte de la forme peut être animé :
  - Tout d’un coup ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/net/aspose.slides.animation/animatetexttype/))
  - Par mot ([AnimateTextType.ByWord](https://reference.aspose.com/slides/net/aspose.slides.animation/animatetexttype/))
  - Par lettre ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/net/aspose.slides.animation/animatetexttype/))
- [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/delaybetweentextparts/) définit le délai entre les parties de texte animées (mots ou lettres). Une valeur positive indique le pourcentage de la durée de l’effet. Une valeur négative indique le délai en secondes.

Voici comment modifier les propriétés d’animation du texte :

1. [Appliquer](#apply-animation-to-shape) ou récupérer l’effet d’animation.
2. Définir la propriété [IEffect.TextAnimation.BuildType](https://reference.aspose.com/slides/net/aspose.slides.animation/itextanimation/buildtype/) sur la valeur [BuildType.AsOneObject](https://reference.aspose.com/slides/net/aspose.slides.animation/buildtype/) pour désactiver le mode d’animation *By Paragraphs*.
3. Définir de nouvelles valeurs pour les propriétés [IEffect.AnimateTextType](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/animatetexttype/) et [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/delaybetweentextparts/).
4. Enregistrez le fichier PPTX modifié.

Ce code C# illustre l’opération :
```c#
// Instancie une classe de présentation qui représente un fichier de présentation.
using (Presentation pres = new Presentation("AnimTextBox_out.pptx"))
{
	ISlide firstSlide = pres.Slides[0];

	// Obtient le premier effet de la séquence principale
	IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

	// Modifie le type d'animation du texte de l'effet à "As One Object"
	firstEffect.TextAnimation.BuildType = BuildType.AsOneObject;

	// Modifie le type d'animation du texte de l'effet à "By word"
	firstEffect.AnimateTextType = AnimateTextType.ByWord;

	// Définit le délai entre les mots à 20% de la durée de l'effet
	firstEffect.DelayBetweenTextParts = 20f;

	// Enregistre le fichier PPTX sur le disque
	pres.Save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Comment garantir que les animations sont conservées lors de la publication de la présentation sur le web ?**

[Export to HTML5](/slides/fr/net/export-to-html5/) et activez les [options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/) responsables des animations de [shape](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) et de [transition](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/). Le HTML brut ne lit pas les animations des diapositives, alors que le HTML5 le fait.

**Comment le changement de l'ordre Z (ordre des calques) des formes affecte-t-il l'animation ?**

L’ordre Z et l’ordre de dessin sont indépendants : un effet contrôle le moment et le type d’apparition/disparition, tandis que l’[z-order](https://reference.aspose.com/slides/net/aspose.slides/shape/zorderposition/) détermine ce qui recouvre quoi. Le résultat visible est défini par leur combinaison. (C’est le comportement général de PowerPoint ; le modèle d’effets et de formes d’Aspose.Slides suit la même logique.)

**Existe-t-il des limitations lors de la conversion des animations en vidéo pour certains effets ?**

En général, les [animations sont prises en charge](/slides/fr/net/convert-powerpoint-to-video/), mais des cas rares ou des effets spécifiques peuvent être rendus différemment. Il est recommandé de tester avec les effets que vous utilisez et avec la version de la bibliothèque.