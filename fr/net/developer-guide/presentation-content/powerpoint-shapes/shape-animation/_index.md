---
title: Animation de forme
type: docs
weight: 60
url: /net/shape-animation/
keywords: 
- animation PowerPoint
- effet d'animation
- appliquer l'animation
- présentation PowerPoint
- C#
- Csharp
- Aspose.Slides pour .NET
description: "Appliquer l'animation PowerPoint en C# ou .NET"
---

Les animations sont des effets visuels qui peuvent être appliqués à des textes, images, formes ou [graphique](/slides/net/animated-charts/). Elles donnent vie aux présentations ou à ses éléments.

### **Pourquoi utiliser des animations dans les présentations ?**

En utilisant des animations, vous pouvez 

* contrôler le flux d'information
* mettre en valeur des points importants
* augmenter l'intérêt ou la participation de votre audience
* rendre le contenu plus facile à lire, assimiler ou traiter
* attirer l'attention de vos lecteurs ou spectateurs vers des parties importantes d'une présentation

PowerPoint propose de nombreuses options et outils pour les animations et effets d'animation dans les catégories **entrée**, **sortie**, **emphase** et **chemins de mouvement**.

### **Animations dans Aspose.Slides**

* Aspose.Slides fournit les classes et types nécessaires pour travailler avec les animations sous l'espace de noms [Aspose.Slides.Animation](https://reference.aspose.com/slides/net/aspose.slides.animation/),
* Aspose.Slides propose plus de **150 effets d'animation** sous l'énumération [EffectType](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttype). Ces effets sont essentiellement les mêmes (ou équivalents) que ceux utilisés dans PowerPoint.

## **Appliquer une animation à TextBox**

Aspose.Slides pour .NET vous permet d'appliquer une animation au texte d'une forme. 

1. Créez une instance de la classe [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/).
2. Obtenez la référence d'un diapositive via son index.
3. Ajoutez un `rectangle` [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape). 
4. Ajoutez du texte à [IAutoShape.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/properties/textframe).
5. Obtenez une séquence principale d'effets.
6. Ajoutez un effet d'animation à [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape).
7. Définissez la propriété [TextAnimation.BuildType](https://reference.aspose.com/slides/net/aspose.slides.animation/textanimation/properties/buildtype) avec la valeur de l'[énumération BuildType](https://reference.aspose.com/slides/net/aspose.slides.animation/buildtype).
8. Écrivez la présentation sur le disque en tant que fichier PPTX.

Ce code C# montre comment appliquer l'effet `Fade` à AutoShape et définir l'animation du texte sur la valeur *Par 1er niveaux de paragraphes* :

```c#
// Instantiates a presentation class that represents a presentation file.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    
    // Adds new AutoShape with text
    IAutoShape autoShape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "Premier paragraphe \nDeuxième paragraphe \n Troisième paragraphe";

    // Gets the main sequence of the slide.
    ISequence sequence = sld.Timeline.MainSequence;

    // Adds Fade animation effect to shape
    IEffect effect = sequence.AddEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Animates shape text by 1st level paragraphs
    effect.TextAnimation.BuildType = BuildType.ByLevelParagraphs1;

    // Save the PPTX file to disk
    pres.Save(path + "AnimTextBox_out.pptx", SaveFormat.Pptx);
}
```

{{%  alert color="primary"  %}} 

En plus d'appliquer des animations au texte, vous pouvez également appliquer des animations à un seul [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph). Voir [**Texte animé**](/slides/net/animated-text/).

{{% /alert %}} 

## **Appliquer une animation à PictureFrame**

1. Créez une instance de la classe [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/).
2. Obtenez la référence d'un diapositive via son index.
3. Ajoutez ou obtenez un [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe) sur le diapositive. 
5. Obtenez la séquence principale d'effets.
6. Ajoutez un effet d'animation à [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe).
8. Écrivez la présentation sur le disque en tant que fichier PPTX.

Ce code C# montre comment appliquer l'effet `Fly` à un cadre d'image :

```c#
// Instantiates a presentation class that represents a presentation file.
using (Presentation pres = new Presentation())
{
    // Load Image to be added in presentaiton image collection
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Adds picture frame to slide
    IPictureFrame picFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // Gets the main sequence of the slide.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Adds Fly from Left animation effect to picture frame
    IEffect effect = sequence.AddEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Save the PPTX file to disk
    pres.Save("AnimImage_out.pptx", SaveFormat.Pptx);
}
```

## **Appliquer une animation à Shape**

1. Créez une instance de la classe [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/).
2. Obtenez la référence d'un diapositive via son index.
3. Ajoutez un `rectangle` [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape). 
4. Ajoutez un `Bevel` [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) (lorsque cet objet est cliqué, l'animation se joue).
5. Créez une séquence d'effets sur la forme biseautée.
6. Créez un `UserPath` personnalisé.
7. Ajoutez des commandes pour se déplacer vers le `UserPath`.
8. Écrivez la présentation sur le disque en tant que fichier PPTX.

Ce code C# montre comment appliquer l'effet `PathFootball` (chemin football) à une forme :

```c#
// Instantiates a Presentation class that represents a presentation file.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // Creates PathFootball effect for existing shape from scratch.
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);

    ashp.AddTextFrame("Texte animé");

    // Adds the PathFootBall animation effect.
    pres.Slides[0].Timeline.MainSequence.AddEffect(ashp, EffectType.PathFootball,
                           EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Creates some kind of "button".
    IShape shapeTrigger = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Creates a sequence of effects for the button.
    ISequence seqInter = pres.Slides[0].Timeline.InteractiveSequences.Add(shapeTrigger);

    // Creates a custom user path. Our object will be moved only after the button is clicked.
    IEffect fxUserPath = seqInter.AddEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

    // Adds commands for moving since created path is empty.
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.Behaviors[0]);

    PointF[] pts = new PointF[1];
    pts[0] = new PointF(0.076f, 0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new PointF(-0.076f, -0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.Path.Add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

    // Writes the PPTX file to disk
    pres.Save("AnimExample_out.pptx", SaveFormat.Pptx);
}
```

## **Obtenir les effets d'animation appliqués à une forme**

Vous pouvez décider de découvrir tous les effets d'animation appliqués à une seule forme. 

Ce code C# montre comment obtenir tous les effets appliqués à une forme spécifique :

```c#
// Instantiates a presentation class that represents a presentation file.
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // Gets the main sequence of the slide.
    ISequence sequence = firstSlide.Timeline.MainSequence;

    // Gets the first shape on slide.
    IShape shape = firstSlide.Shapes[0];

    // Gets all animation effects applied to the shape.
    IEffect[] shapeEffects = sequence.GetEffectsByShape(shape);

    if (shapeEffects.Length > 0)
        Console.WriteLine("La forme " + shape.Name + " a " + shapeEffects.Length + " effets d'animation.");
}
```

## **Changer les propriétés de timing des effets d'animation**

Aspose.Slides pour .NET vous permet de changer les propriétés de timing d'un effet d'animation.

Voici le panneau de Timing de l'animation et le menu étendu dans Microsoft PowerPoint :

![example1_image](shape-animation.png)

Voici les correspondances entre les Timing de PowerPoint et les propriétés [Effect.Timing](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/properties/timing) :
- La liste déroulante PowerPoint Timing **Début** correspond à la propriété [Effect.Timing.TriggerType](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/properties/triggertype). 
- La durée de Timing **Durée** correspond à la propriété [Effect.Timing.Duration](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/properties/duration). La durée d'une animation (en secondes) est le temps total nécessaire pour que l'animation complète un cycle. 
- La durée de Timing **Délai** correspond à la propriété [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/properties/triggerdelaytime). 
- La liste déroulante Timing **Répéter** correspond à ces propriétés : 
  * La propriété [Effect.Timing.RepeatCount](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatcount) qui décrit le *nombre* de fois que l'effet est répété ;
  * Le drapeau [Effect.Timing.RepeatUntilEndSlide](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatuntilendslide) qui spécifie si l'effet est répété jusqu'à la fin de la diapositive ;
  * Le drapeau [Effect.Timing.RepeatUntilNextClick](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatuntilnextclick) qui spécifie si l'effet est répété jusqu'au prochain clic.
- La case à cocher Timing **Rewind when done playing** correspond à la propriété [Effect.Timing.Rewind](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/rewind/). 

Voici comment vous changez les propriétés de Timing des effets :

1. [Appliquez](#apply-animation-to-shape) ou obtenez l'effet d'animation.
2. Définissez de nouvelles valeurs pour les propriétés [Effect.Timing](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/properties/timing) dont vous avez besoin. 
3. Enregistrez le fichier PPTX modifié.

Ce code C# illustre l'opération :

```c#
// Instantiates a presentation class that represents a presentation file.
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
    // Gets the main sequence of the slide.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Gets the first effect of main sequence.
    IEffect effect = sequence[0];

    // Changes effect TriggerType to start on click
    effect.Timing.TriggerType = EffectTriggerType.OnClick;

    // Changes effect Duration
    effect.Timing.Duration = 3f;

    // Changes effect TriggerDelayTime
    effect.Timing.TriggerDelayTime = 0.5f;

    // If the effect Repeat value is "none"
    if (effect.Timing.RepeatCount == 1f)
    {
        // Changes effect Repeat to "Until Next Click"
        effect.Timing.RepeatUntilNextClick = true;
    }
    else
    {
        // Changes effect Repeat to "Until End of Slide"
        effect.Timing.RepeatUntilEndSlide = true;
    }

    // Turns the effect Rewind on
        effect.Timing.Rewind = true;
    
    // Saves the PPTX file to disk
    pres.Save("AnimExample_changed.pptx", SaveFormat.Pptx);
}
```

## **Son des effets d'animation**

Aspose.Slides fournit ces propriétés pour vous permettre de travailler avec des sons dans les effets d'animation : 
- [IEffect.Sound](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/sound/) 
- [IEffect.StopPreviousSound](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/stopprevioussound/) 

### **Ajouter un son d'effet d'animation**

Ce code C# montre comment ajouter un son d'effet d'animation et l'arrêter lorsque l'effet suivant commence :

```c#
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
	// Adds audio to presentation audio collection
	IAudio effectSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// Gets the main sequence of the slide.
	ISequence sequence = firstSlide.Timeline.MainSequence;

	// Gets the first effect of the main sequence
	IEffect firstEffect = sequence[0];

	// Сhecks the effect for "No Sound"
	if (!firstEffect.StopPreviousSound && firstEffect.Sound == null)
	{
		// Adds sound for the first effect
		firstEffect.Sound = effectSound;
	}

	// Gets the first interactive sequence of the slide.
	ISequence interactiveSequence = firstSlide.Timeline.InteractiveSequences[0];

	// Sets the effect "Stop previous sound" flag
	interactiveSequence[0].StopPreviousSound = true;

	// Writes the PPTX file to disk
	pres.Save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
}
```

### **Extraire le son des effets d'animation**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Obtenez la référence d'un diapositive via son index. 
3. Obtenez la séquence principale d'effets. 
4. Extraire le [Son](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/sound/) intégré à chaque effet d'animation. 

Ce code C# montre comment extraire le son embarqué dans un effet d'animation :

```c#
// Instantiates a presentation class that represents a presentation file.
using (Presentation presentation = new Presentation("EffectSound.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Gets the main sequence of the slide.
    ISequence sequence = slide.Timeline.MainSequence;

    foreach (IEffect effect in sequence)
    {
        if (effect.Sound == null)
            continue;

        // Extracts the effect sound in byte array
        byte[] audio = effect.Sound.BinaryData;
    }
}
```

## **Après l'animation**

Aspose.Slides pour .NET vous permet de changer la propriété Après animation d'un effet d'animation.

Voici le panneau et le menu étendu des effets d'animation dans Microsoft PowerPoint :

![example1_image](shape-after-animation.png)

La liste déroulante **Après animation** de PowerPoint correspond à ces propriétés : 

- La propriété [IEffect.AfterAnimationType](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/afteranimationtype/) qui décrit le type d'animation après :
  * **Plus de couleurs** de PowerPoint correspond au type [AfterAnimationType.Color](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/) ;
  * L'élément de liste **Ne pas atténuer** correspond au type [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/) (type par défaut après animation) ;
  * L'élément **Masquer après l'animation** correspond au type [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/) ;
  * L'élément **Masquer au prochain clic de souris** correspond au type [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/) ;
- La propriété [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/afteranimationcolor/) qui définit un format de couleur après l'animation. Cette propriété fonctionne en conjonction avec le type [AfterAnimationType.Color](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/). Si vous changez le type en un autre, la couleur après l'animation sera effacée.

Ce code C# montre comment changer un effet après l'animation :

```c#
// Instantiates a presentation class that represents a presentation file
using (Presentation pres = new Presentation("AnimImage_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // Gets the first effect of the main sequence
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // Changes the after animation type to Color
    firstEffect.AfterAnimationType = AfterAnimationType.Color;

    // Sets the after animation dim color
    firstEffect.AfterAnimationColor.Color = Color.AliceBlue;

    // Writes the PPTX file to disk
    pres.Save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
}
```

## **Animer le texte**

Aspose.Slides fournit ces propriétés pour vous permettre de travailler avec le bloc *Animer le texte* d'un effet d'animation :

- [IEffect.AnimateTextType](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/animatetexttype/) qui décrit un type d'animation de texte de l'effet. Le texte de la forme peut être animé :
  - Tout à la fois ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/net/aspose.slides.animation/animatetexttype/) type)
  - Par mot ([AnimateTextType.ByWord](https://reference.aspose.com/slides/net/aspose.slides.animation/animatetexttype/) type)
  - Par lettre ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/net/aspose.slides.animation/animatetexttype/) type)
- [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/delaybetweentextparts/) définit un délai entre les parties de texte animées (mots ou lettres). Une valeur positive spécifie le pourcentage de la durée de l'effet. Une valeur négative spécifie le délai en secondes.

Voici comment vous pouvez changer les propriétés de l'effet Animer le texte :

1. [Appliquez](#apply-animation-to-shape) ou obtenez l'effet d'animation.
2. Définissez la propriété [IEffect.TextAnimation.BuildType](https://reference.aspose.com/slides/net/aspose.slides.animation/itextanimation/buildtype/) sur la valeur [BuildType.AsOneObject](https://reference.aspose.com/slides/net/aspose.slides.animation/buildtype/) pour désactiver le mode d'animation *Par paragraphes*.
3. Définissez de nouvelles valeurs pour les propriétés [IEffect.AnimateTextType](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/animatetexttype/) et [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/delaybetweentextparts/).
4. Enregistrez le fichier PPTX modifié.

Ce code C# illustre l'opération :

```c#
// Instantiates a presentation class that represents a presentation file.
using (Presentation pres = new Presentation("AnimTextBox_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // Gets the first effect of the main sequence
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // Changes the effect Text animation type to "As One Object"
    firstEffect.TextAnimation.BuildType = BuildType.AsOneObject;

    // Changes the effect Animate text type to "By word"
    firstEffect.AnimateTextType = AnimateTextType.ByWord;

    // Sets the delay between words to 20% of effect duration
    firstEffect.DelayBetweenTextParts = 20f;

    // Writes the PPTX file to disk
    pres.Save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
}
```