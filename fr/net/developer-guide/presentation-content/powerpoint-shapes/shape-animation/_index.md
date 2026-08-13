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
- ajouter une animation
- obtenir une animation
- extraire une animation
- ajouter un effet
- obtenir un effet
- extraire un effet
- son d'effet
- appliquer une animation
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Découvrez comment créer et personnaliser des animations de forme dans les présentations PowerPoint avec Aspose.Slides pour .NET. Démarquez-vous !"
---
## **Introduction**

Les animations sont des effets visuels qui peuvent être appliqués aux textes, images, formes ou aux [graphes](/slides/fr/net/animated-charts/). Elles donnent vie aux présentations ou à leurs constituants. 

## **Pourquoi utiliser des animations dans les présentations ?**

En utilisant les animations, vous pouvez 

* contrôler le flux d'informations
* mettre en évidence les points importants
* susciter plus d'intérêt ou de participation chez votre public
* rendre le contenu plus facile à lire, assimiler ou traiter
* attirer l'attention de vos lecteurs ou spectateurs sur les parties importantes d'une présentation

PowerPoint propose de nombreuses options et outils pour les animations et les effets d'animation dans les catégories **entrée**, **sortie**, **mise en emphase** et **chemins de mouvement**. 

## **Animations dans Aspose.Slides**

* Aspose.Slides fournit les classes et types dont vous avez besoin pour travailler avec les animations dans l'espace de noms [Aspose.Slides.Animation](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/).
* Aspose.Slides propose plus de **150 effets d'animation** dans l'énumération [EffectType](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/effecttype). Ces effets sont essentiellement les mêmes (ou équivalents) que ceux utilisés dans PowerPoint.

## **Appliquer une animation à une zone de texte**

Aspose.Slides pour .NET vous permet d'appliquer une animation au texte d'une forme. 

1. Créer une instance de la classe [Presentation](http://www.aspose.com/api/net/slides/fr/aspose.slides/).
2. Obtenir la référence d'une diapositive via son index.
3. Ajouter un `rectangle` [IAutoShape](https://reference.aspose.com/slides/fr/net/aspose.slides/iautoshape). 
4. Ajouter du texte à [IAutoShape.TextFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/iautoshape/properties/textframe).
5. Obtenir la séquence principale d'effets.
6. Ajouter un effet d'animation à [IAutoShape](https://reference.aspose.com/slides/fr/net/aspose.slides/iautoshape).
7. Définir la propriété [TextAnimation.BuildType](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/textanimation/properties/buildtype) sur la valeur provenant de l'[énumération BuildType](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/buildtype).
8. Enregistrer la présentation sur le disque au format PPTX.

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Instancie une classe de présentation représentant un fichier de présentation.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // Ajoute une nouvelle AutoShape avec du texte
    IAutoShape autoShape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    // Ajoute trois paragraphes afin que la construction par paragraphe ait quelque chose à parcourir.
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "First paragraph";
    textFrame.Paragraphs.Add(new Paragraph { Text = "Second paragraph" });
    textFrame.Paragraphs.Add(new Paragraph { Text = "Third paragraph" });

    // Obtient la séquence principale de la diapositive.
    ISequence sequence = sld.Timeline.MainSequence;

    // Ajoute l'effet d'animation Fade à la forme
    IEffect effect = sequence.AddEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Anime le texte de la forme par paragraphes de premier niveau
    effect.TextAnimation.BuildType = BuildType.ByLevelParagraphs1;

    // Enregistre le fichier PPTX sur le disque
    pres.Save("AnimTextBox_out.pptx", SaveFormat.Pptx);
}
```

{{%  alert color="info"  %}} 

En plus d'appliquer des animations au texte, vous pouvez aussi appliquer des animations à un seul [Paragraph](https://reference.aspose.com/slides/fr/net/aspose.slides/iparagraph). Voir [**Texte animé**](/slides/fr/net/animated-text/).

{{% /alert %}} 

## **Appliquer une animation à un PictureFrame**

1. Créer une instance de la classe [Presentation](http://www.aspose.com/api/net/slides/fr/aspose.slides/).
2. Obtenir la référence d'une diapositive via son index.
3. Ajouter ou obtenir un [PictureFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/ipictureframe) sur la diapositive. 
5. Obtenir la séquence principale d'effets.
6. Ajouter un effet d'animation à [PictureFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/ipictureframe).
8. Enregistrer la présentation sur le disque au format PPTX.

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Instancie une classe de présentation qui représente un fichier de présentation.
using (Presentation pres = new Presentation())
{
    // Charge l'image à ajouter dans la collection d'images de la présentation
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

## **Appliquer une animation à une forme**

1. Créer une instance de la classe [Presentation](http://www.aspose.com/api/net/slides/fr/aspose.slides/).
2. Obtenir la référence d'une diapositive via son index.
3. Ajouter un `rectangle` [IAutoShape](https://reference.aspose.com/slides/fr/net/aspose.slides/iautoshape). 
4. Ajouter un `Bevel` [IAutoShape](https://reference.aspose.com/slides/fr/net/aspose.slides/iautoshape) (lorsque cet objet est cliqué, l'animation se lance).
5. Créer une séquence d'effets sur la forme en biseau.
6. Créer un `UserPath` personnalisé.
7. Ajouter des commandes pour se déplacer vers le `UserPath`.
8. Enregistrer la présentation sur le disque au format PPTX.

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Instancie une classe Presentation qui représente un fichier de présentation.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // Crée l'effet PathFootball pour une forme existante à partir de zéro.
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);

    ashp.AddTextFrame("Animated TextBox");

    // Ajoute l'effet d'animation PathFootBall.
    pres.Slides[0].Timeline.MainSequence.AddEffect(ashp, EffectType.PathFootball,
                           EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Crée une sorte de "bouton".
    IShape shapeTrigger = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Crée une séquence d'effets pour le bouton.
    ISequence seqInter = pres.Slides[0].Timeline.InteractiveSequences.Add(shapeTrigger);

    // Crée un chemin utilisateur personnalisé. Notre objet ne sera déplacé qu'après que le bouton soit cliqué.
    IEffect fxUserPath = seqInter.AddEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

    // Ajoute des commandes de déplacement puisque le chemin créé est vide.
    IMotionEffect motionBvh = ((IMotionEffect)fxUserPath.Behaviors[0]);

    PointF[] pts = new PointF[1];
    pts[0] = new PointF(0.076f, 0.59f);
    motionBvh.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new PointF(-0.076f, -0.59f);
    motionBvh.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBvh.Path.Add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

    // Écrit le fichier PPTX sur le disque
    pres.Save("AnimExample_out.pptx", SaveFormat.Pptx);
}
```

## **Obtenir les effets d'animation appliqués à une forme**

Les exemples suivants montrent comment utiliser la méthode `GetEffectsByShape` de l'interface [ISequence](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/isequence/) pour obtenir tous les effets d'animation appliqués à une forme.

**Exemple 1 : Obtenir les effets d'animation appliqués à une forme sur une diapositive normale**

Auparavant, vous avez appris comment ajouter des effets d'animation aux formes dans les présentations PowerPoint. Le code d'exemple suivant montre comment obtenir les effets appliqués à la première forme de la première diapositive normale de la présentation `AnimExample_out.pptx`.

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation("AnimExample_out.pptx"))
{
    ISlide firstSlide = presentation.Slides[0];

    // Obtient la séquence principale d'animation de la diapositive.
    ISequence sequence = firstSlide.Timeline.MainSequence;

    // Obtient la première forme sur la première diapositive.
    IShape shape = firstSlide.Shapes[0];

    // Obtient les effets d'animation appliqués à la forme.
    IEffect[] shapeEffects = sequence.GetEffectsByShape(shape);

    if (shapeEffects.Length > 0)
        Console.WriteLine($"The shape {shape.Name} has {shapeEffects.Length} animation effects.");
}
```

**Exemple 2 : Obtenir tous les effets d'animation, y compris ceux hérités des espaces réservés**

Si une forme sur une diapositive normale possède des espaces réservés qui se trouvent sur la diapositive de disposition et/ou la diapositive maîtresse, et que des effets d'animation ont été ajoutés à ces espaces réservés, alors tous les effets de la forme seront joués pendant le diaporama, y compris ceux hérités des espaces réservés.

Supposons que nous ayons un fichier de présentation PowerPoint `sample.pptx` avec une diapositive contenant uniquement une forme de pied de page avec le texte "Made with Aspose.Slides" et que l'effet **Random Bars** soit appliqué à la forme.

![Effet d'animation de forme de diapositive](slide-shape-animation.png)

Supposons également que l'effet **Split** soit appliqué à l'espace réservé du pied de page sur la diapositive **layout**.

![Effet d'animation de forme du layout](layout-shape-animation.png)

Enfin, l'effet **Fly In** est appliqué à l'espace réservé du pied de page sur la diapositive **master**.

![Effet d'animation de forme du master](master-shape-animation.png)

```cs
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Obtenir les effets d'animation de la forme sur la diapositive normale.
    IShape shape = slide.Shapes[0];
    IEffect[] shapeEffects = slide.Timeline.MainSequence.GetEffectsByShape(shape);

    // Obtenir les effets d'animation de l'espace réservé sur la diapositive de mise en page.
    IShape layoutShape = shape.GetBasePlaceholder();
    IEffect[] layoutShapeEffects = slide.LayoutSlide.Timeline.MainSequence.GetEffectsByShape(layoutShape);

    // Obtenir les effets d'animation de l'espace réservé sur la diapositive maître.
    IShape masterShape = layoutShape.GetBasePlaceholder();
    IEffect[] masterShapeEffects = slide.LayoutSlide.MasterSlide.Timeline.MainSequence.GetEffectsByShape(masterShape);

    Console.WriteLine("Main sequence of shape effects:");
    PrintEffects(masterShapeEffects);
    PrintEffects(layoutShapeEffects);
    PrintEffects(shapeEffects);
}

static void PrintEffects(IEnumerable<IEffect> effects)
{
    foreach (IEffect effect in effects)
    {
        Console.WriteLine($"{effect.Type} {effect.Subtype}");
    }
}
```
```cs
using Aspose.Slides.Animation;

static void PrintEffects(IEnumerable<IEffect> effects)
{
    foreach (IEffect effect in effects)
    {
        Console.WriteLine($"{effect.Type} {effect.Subtype}");
    }
}
```

```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```

## **Modifier les propriétés de temporisation d'un effet d'animation**

Aspose.Slides pour .NET vous permet de modifier les propriétés de temporisation d'un effet d'animation.

![example1_image](shape-animation.png)

Les correspondances entre le temporisateur PowerPoint et les propriétés [Effect.Timing](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/effect/properties/timing) sont :

- La liste déroulante **Start** du temporisateur PowerPoint correspond à la propriété [Effect.Timing.TriggerType](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/itiming/properties/triggertype). 
- Le **Duration** du temporisateur PowerPoint correspond à la propriété [Effect.Timing.Duration](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/itiming/properties/duration). La durée d'une animation (en secondes) est le temps total nécessaire pour qu'une animation complète un cycle. 
- Le **Delay** du temporisateur PowerPoint correspond à la propriété [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/itiming/properties/triggerdelaytime). 
- La liste déroulante **Repeat** du temporisateur PowerPoint correspond à ces propriétés : 
  * la propriété [Effect.Timing.RepeatCount](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/itiming/repeatcount) qui décrit le *nombre* de fois que l'effet est répété ;
  * le drapeau [Effect.Timing.RepeatUntilEndSlide](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/itiming/repeatuntilendslide) qui indique si l'effet est répété jusqu'à la fin de la diapositive ;
  * le drapeau [Effect.Timing.RepeatUntilNextClick](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/itiming/repeatuntilnextclick) qui indique si l'effet est répété jusqu'au prochain clic.
- La case à cocher **Rewind when done playing** du temporisateur PowerPoint correspond à la propriété [Effect.Timing.Rewind](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/itiming/rewind/). 

Voici comment modifier les propriétés de temporisation d'un effet :

1. [Appliquer](#apply-animation-to-shape) ou obtenir l'effet d'animation.
2. Définir de nouvelles valeurs pour les propriétés [Effect.Timing](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/effect/properties/timing) dont vous avez besoin. 
3. Enregistrer le fichier PPTX modifié.

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Instancie une classe de présentation qui représente un fichier de présentation.
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
    // Obtient la séquence principale de la diapositive.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Obtient le premier effet de la séquence principale.
    IEffect effect = sequence[0];

    // Change le TriggerType de l'effet pour démarrer au clic
    effect.Timing.TriggerType = EffectTriggerType.OnClick;

    // Change la durée de l'effet
    effect.Timing.Duration = 3f;

    // Change le TriggerDelayTime de l'effet
    effect.Timing.TriggerDelayTime = 0.5f;

    // Si la valeur Repeat de l'effet est "none"
    if (effect.Timing.RepeatCount == 1f)
    {
        // Change le Repeat de l'effet à "Until Next Click"
        effect.Timing.RepeatUntilNextClick = true;
    }
    else
    {
        // Change le Repeat de l'effet à "Until End of Slide"
        effect.Timing.RepeatUntilEndSlide = true;
    }

    // Active le Rewind de l'effet
        effect.Timing.Rewind = true;
    
    // Enregistre le fichier PPTX sur le disque
    pres.Save("AnimExample_changed.pptx", SaveFormat.Pptx);
}
```

## **Son d'un effet d'animation**

Aspose.Slides fournit ces propriétés pour travailler avec les sons dans les effets d'animation : 
- [IEffect.Sound](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/effect/sound/) 
- [IEffect.StopPreviousSound](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/effect/stopprevioussound/) 

### **Ajouter un son à un effet d'animation**

Ce code C# montre comment ajouter un son à un effet d'animation et l'arrêter lorsque l'effet suivant démarre :

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
	// Ajoute l'audio à la collection audio de la présentation
	IAudio effectSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// Obtient la séquence principale de la diapositive.
	ISequence sequence = firstSlide.Timeline.MainSequence;

	// Obtient le premier effet de la séquence principale
	IEffect firstEffect = sequence[0];

	// Vérifie l'effet pour "No Sound"
	if (!firstEffect.StopPreviousSound && firstEffect.Sound == null)
	{
		// Ajoute le son au premier effet
		firstEffect.Sound = effectSound;
	}

	// Obtient la première séquence interactive de la diapositive.
	ISequence interactiveSequence = firstSlide.Timeline.InteractiveSequences[0];

	// Définit le drapeau "Stop previous sound" de l'effet
	interactiveSequence[0].StopPreviousSound = true;

	// Enregistre le fichier PPTX sur le disque
	pres.Save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
}
```

### **Extraire le son d'un effet d'animation**

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/).
2. Obtenir la référence d’une diapositive via son index. 
3. Obtenir la séquence principale d'effets. 
4. Extraire le [Sound](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/effect/sound/) intégré à chaque effet d'animation. 

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;

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

        // Extrait le son de l'effet sous forme de tableau d'octets
        byte[] audio = effect.Sound.BinaryData;
    }
}
```

## **Après l'animation**

Aspose.Slides pour .NET vous permet de modifier la propriété After animation d'un effet d'animation.

![example1_image](shape-after-animation.png)

La liste déroulante **After animation** de PowerPoint correspond à ces propriétés :

- la propriété [IEffect.AfterAnimationType](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/ieffect/afteranimationtype/) qui décrit le type d'After animation :
  * PowerPoint **More Colors** correspond au type [AfterAnimationType.Color](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/afteranimationtype/);
  * PowerPoint **Don't Dim** correspond à l'item [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/afteranimationtype/) (type d'animation par défaut);
  * PowerPoint **Hide After Animation** correspond au type [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/afteranimationtype/);
  * PowerPoint **Hide on Next Mouse Click** correspond au type [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/afteranimationtype/);
- la propriété [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/ieffect/afteranimationcolor/) qui définit un format de couleur après l'animation. Cette propriété fonctionne en conjonction avec le type [AfterAnimationType.Color](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/afteranimationtype/). Si vous changez le type, la couleur après l'animation sera réinitialisée.

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Instancie une classe de présentation qui représente un fichier de présentation
using (Presentation pres = new Presentation("AnimImage_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // Obtient le premier effet de la séquence principale
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // Modifie le type d'animation après en Couleur
    firstEffect.AfterAnimationType = AfterAnimationType.Color;

    // Définit la couleur d'assombrissement après l'animation
    firstEffect.AfterAnimationColor.Color = Color.AliceBlue;

    // Enregistre le fichier PPTX sur le disque
    pres.Save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
}
```

## **Animer le texte**

Aspose.Slides fournit ces propriétés pour travailler avec le bloc *Animate text* d'un effet d'animation :

- la propriété [IEffect.AnimateTextType](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/ieffect/animatetexttype/) qui décrit le type d'animation du texte de l'effet. Le texte de la forme peut être animé :
  * Tout d'un coup ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/animatetexttype/) type)
  * Par mot ([AnimateTextType.ByWord](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/animatetexttype/) type)
  * Par lettre ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/animatetexttype/) type)
- la propriété [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/ieffect/delaybetweentextparts/) définit un délai entre les parties du texte animé (mots ou lettres). Une valeur positive indique le pourcentage de la durée de l'effet. Une valeur négative indique le délai en secondes.

1. [Appliquer](#apply-animation-to-shape) ou obtenir l'effet d'animation.
2. Définir la propriété [IEffect.TextAnimation.BuildType](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/itextanimation/buildtype/) sur la valeur [BuildType.AsOneObject](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/buildtype/) pour désactiver le mode d'animation *By Paragraphs*.
3. Définir de nouvelles valeurs pour les propriétés [IEffect.AnimateTextType](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/ieffect/animatetexttype/) et [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/fr/net/aspose.slides.animation/ieffect/delaybetweentextparts/).
4. Enregistrer le fichier PPTX modifié.

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Instancie une classe de présentation qui représente un fichier de présentation.
using (Presentation pres = new Presentation("AnimTextBox_out.pptx"))
{
	ISlide firstSlide = pres.Slides[0];

	// Obtient le premier effet de la séquence principale
	IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

	// Modifie le type d'animation de texte de l'effet en "As One Object"
	firstEffect.TextAnimation.BuildType = BuildType.AsOneObject;

	// Modifie le type d'animation du texte de l'effet en "By word"
	firstEffect.AnimateTextType = AnimateTextType.ByWord;

	// Définit le délai entre les mots à 20% de la durée de l'effet
	firstEffect.DelayBetweenTextParts = 20f;

	// Enregistre le fichier PPTX sur le disque
	pres.Save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

### Comment garantir que les animations sont conservées lors de la publication de la présentation sur le Web ?

Utilisez [Export to HTML5](/slides/fr/net/export-to-html5/) et activez les [options](https://reference.aspose.com/slides/fr/net/aspose.slides.export/html5options/) responsables des animations de [shape](https://reference.aspose.com/slides/fr/net/aspose.slides.export/html5options/animateshapes/) et de [transition](https://reference.aspose.com/slides/fr/net/aspose.slides.export/html5options/animatetransitions/). Le HTML simple ne lit pas les animations de diapositive, alors que le HTML5 le fait.

### Comment le changement de l'ordre Z (ordre des calques) des formes affecte-t-il l'animation ?

Les ordres d'animation et de dessin sont indépendants : un effet contrôle la temporisation et le type d'apparition/disparition, tandis que le [z-order](https://reference.aspose.com/slides/fr/net/aspose.slides/shape/zorderposition/) détermine ce qui recouvre quoi. Le résultat visible est défini par leur combinaison. (C’est le comportement général de PowerPoint ; le modèle effets‑et‑formes d’Aspose.Slides suit la même logique.)

### Existe-t-il des limitations lors de la conversion des animations en vidéo pour certains effets ?

En général, les [animations sont prises en charge](/slides/fr/net/convert-powerpoint-to-video/), mais des cas rares ou des effets spécifiques peuvent être rendus différemment. Il est recommandé de tester avec les effets que vous utilisez et avec la version de la bibliothèque.