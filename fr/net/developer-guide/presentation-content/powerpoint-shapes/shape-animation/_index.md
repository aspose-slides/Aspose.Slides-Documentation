---
title: "Animation de forme"
type: docs
weight: 60
url: /fr/net/shape-animation/
keywords:
- forme
- animation
- effet
- ajouter des effets
- obtenir des effets
- extraire des effets
- appliquer animation
- PowerPoint
- présentation
- C#
- Csharp
- Aspose.Slides pour .NET
description: "Appliquer une animation PowerPoint en C# ou .NET"
---

Les animations sont des effets visuels qui peuvent être appliqués aux textes, images, formes ou aux [charts](/slides/fr/net/animated-charts/). Elles donnent vie aux présentations ou à leurs composants. 

## **Pourquoi utiliser les animations dans les présentations ?**

En utilisant les animations, vous pouvez 

* contrôler le flux d'informations
* mettre en évidence les points importants
* augmenter l'intérêt ou la participation de votre audience
* rendre le contenu plus facile à lire, assimiler ou traiter
* attirer l'attention de vos lecteurs ou spectateurs sur les parties importantes d'une présentation

PowerPoint offre de nombreuses options et outils pour les animations et les effets d'animation dans les catégories **entrée**, **sortie**, **mise en évidence** et **chemins de mouvement**. 

## **Animations dans Aspose.Slides**

* Aspose.Slides fournit les classes et types dont vous avez besoin pour travailler avec les animations dans l'espace de noms [Aspose.Slides.Animation](https://reference.aspose.com/slides/net/aspose.slides.animation/) ,
* Aspose.Slides propose plus de **150 effets d'animation** dans l'énumération [EffectType](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttype). Ces effets sont essentiellement les mêmes (ou équivalents) que ceux utilisés dans PowerPoint.

## **Appliquer une animation à TextBox**

Aspose.Slides pour .NET vous permet d'appliquer une animation au texte d'une forme. 

1. Créez une instance de la classe [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) .
2. Obtenez une référence à une diapositive via son indice.
3. Ajoutez un `rectangle` [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape). 
4. Ajoutez du texte à [IAutoShape.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/properties/textframe).
5. Récupérez la séquence principale d'effets.
6. Ajoutez un effet d'animation à [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape).
7. Définissez la propriété [TextAnimation.BuildType](https://reference.aspose.com/slides/net/aspose.slides.animation/textanimation/properties/buildtype) sur la valeur de l'[BuildType Enumeration](https://reference.aspose.com/slides/net/aspose.slides.animation/buildtype).
8. Enregistrez la présentation sur le disque au format PPTX.

Ce code C# montre comment appliquer l'effet `Fade` à AutoShape et définir l'animation du texte sur la valeur *Par paragraphes du premier niveau* :
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

En plus d'appliquer des animations au texte, vous pouvez également appliquer des animations à un seul [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph). Voir [**Animated Text**](/slides/fr/net/animated-text/).

{{% /alert %}} 

## **Appliquer une animation à PictureFrame**

1. Créez une instance de la classe [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) .
2. Obtenez une référence à une diapositive via son indice.
3. Ajoutez ou récupérez un [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe) sur la diapositive. 
5. Récupérez la séquence principale d'effets.
6. Ajoutez un effet d'animation à [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe).
8. Enregistrez la présentation sur le disque au format PPTX.

Ce code C# montre comment appliquer l'effet `Fly` à un cadre d'image :
```c#
// Instancie une classe de présentation qui représente un fichier de présentation.
using (Presentation pres = new Presentation())
{
    // Charge l'image à ajouter à la collection d'images de la présentation
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

1. Créez une instance de la classe [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) .
2. Obtenez une référence à une diapositive via son indice.
3. Ajoutez un `rectangle` [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape). 
4. Ajoutez un `Bevel` [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) (lorsque cet objet est cliqué, l'animation se joue).
5. Créez une séquence d'effets sur la forme à biseau.
6. Créez un `UserPath` personnalisé.
7. Ajoutez des commandes pour se déplacer vers le `UserPath`.
8. Enregistrez la présentation sur le disque au format PPTX.

Ce code C# montre comment appliquer l'effet `PathFootball` (chemin football) à une forme :
```c#
// Instancie une classe Presentation qui représente un fichier de présentation.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // Crée l'effet PathFootball pour la forme existante à partir de zéro.
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);

    ashp.AddTextFrame("Animated TextBox");

    // Ajoute l'effet d'animation PathFootBall.
    pres.Slides[0].Timeline.MainSequence.AddEffect(ashp, EffectType.PathFootball,
                           EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Crée une sorte de "bouton".
    IShape shapeTrigger = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Crée une séquence d'effets pour le bouton.
    ISequence seqInter = pres.Slides[0].Timeline.InteractiveSequences.Add(shapeTrigger);

    // Crée un chemin utilisateur personnalisé. Notre objet ne sera déplacé qu'après le clic sur le bouton.
    IEffect fxUserPath = seqInter.AddEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

    // Ajoute des commandes de déplacement étant donné que le chemin créé est vide.
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


## **Obtenir les effets d'animation appliqués à une forme**

Les exemples suivants montrent comment utiliser la méthode `GetEffectsByShape` de l'interface [ISequence](https://reference.aspose.com/slides/net/aspose.slides.animation/isequence/) pour obtenir tous les effets d'animation appliqués à une forme.

**Exemple 1 : Obtenir les effets d'animation appliqués à une forme sur une diapositive normale**

Auparavant, vous avez appris comment ajouter des effets d'animation aux formes dans les présentations PowerPoint. Le code d'exemple suivant montre comment obtenir les effets appliqués à la première forme de la première diapositive normale de la présentation `AnimExample_out.pptx`.
```c#
using (Presentation presentation = new Presentation("AnimExample_out.pptx"))
{
    ISlide firstSlide = presentation.Slides[0];

    // Récupère la séquence principale d'animation de la diapositive.
    ISequence sequence = firstSlide.Timeline.MainSequence;

    // Récupère la première forme de la première diapositive.
    IShape shape = firstSlide.Shapes[0];

    // Récupère les effets d'animation appliqués à la forme.
    IEffect[] shapeEffects = sequence.GetEffectsByShape(shape);

    if (shapeEffects.Length > 0)
        Console.WriteLine($"The shape {shape.Name} has {shapeEffects.Length} animation effects.");
}
```


**Exemple 2 : Obtenir tous les effets d'animation, y compris ceux hérités des zones réservées**

Si une forme sur une diapositive normale possède des zones réservées qui se trouvent sur la diapositive de mise en page et/ou la diapositive maîtresse, et que des effets d'animation ont été ajoutés à ces zones réservées, alors tous les effets de la forme seront joués pendant le diaporama, y compris ceux hérités des zones réservées.

Supposons que nous ayons un fichier de présentation PowerPoint `sample.pptx` contenant une diapositive avec uniquement une forme de pied de page contenant le texte "Made with Aspose.Slides" et que l'effet **Random Bars** soit appliqué à la forme.

![Effet d'animation de forme de diapositive](slide-shape-animation.png)

Supposons également que l'effet **Split** soit appliqué à la zone réservée du pied de page sur la diapositive de **layout**.

![Effet d'animation de forme de disposition](layout-shape-animation.png)

Et enfin, que l'effet **Fly In** soit appliqué à la zone réservée du pied de page sur la diapositive **master**.

![Effet d'animation de forme maître](master-shape-animation.png)

Le code d'exemple suivant montre comment utiliser la méthode `GetBasePlaceholder` de l'interface [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) pour accéder aux zones réservées de la forme et obtenir les effets d'animation appliqués à la forme de pied de page, y compris ceux hérités des zones réservées situées sur les diapositives de mise en page et maîtresse.
```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Obtenir les effets d'animation de la forme sur la diapositive normale.
    IShape shape = slide.Shapes[0];
    IEffect[] shapeEffects = slide.Timeline.MainSequence.GetEffectsByShape(shape);

    // Obtenir les effets d'animation du placeholder sur la diapositive de mise en page.
    IShape layoutShape = shape.GetBasePlaceholder();
    IEffect[] layoutShapeEffects = slide.LayoutSlide.Timeline.MainSequence.GetEffectsByShape(layoutShape);

    // Obtenir les effets d'animation du placeholder sur la diapositive maître.
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


## **Modifier les propriétés de minutage des effets d'animation**

Aspose.Slides pour .NET vous permet de modifier les propriétés Timing d'un effet d'animation.

Voici le volet de minutage de l'animation et le menu étendu dans Microsoft PowerPoint :

![volet de minutage de l'animation](shape-animation.png)

Voici les correspondances entre le minutage PowerPoint et les propriétés [Effect.Timing](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/properties/timing) :

- La liste déroulante **Start** du minutage PowerPoint correspond à la propriété [Effect.Timing.TriggerType](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/properties/triggertype). 
- La liste déroulante **Duration** du minutage PowerPoint correspond à la propriété [Effect.Timing.Duration](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/properties/duration). La durée d'une animation (en secondes) est le temps total nécessaire à l'animation pour compléter un cycle. 
- La liste déroulante **Delay** du minutage PowerPoint correspond à la propriété [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/properties/triggerdelaytime). 
- La liste déroulante **Repeat** du minutage PowerPoint correspond à ces propriétés : 
  * la propriété [Effect.Timing.RepeatCount](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatcount) qui décrit le *nombre* de fois que l'effet est répété ;
  * le drapeau [Effect.Timing.RepeatUntilEndSlide](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatuntilendslide) qui indique si l'effet est répété jusqu'à la fin de la diapositive ;
  * le drapeau [Effect.Timing.RepeatUntilNextClick](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/repeatuntilnextclick) qui indique si l'effet est répété jusqu'au clic suivant.
- La case à cocher **Rewind when done playing** du minutage PowerPoint correspond à la propriété [Effect.Timing.Rewind](https://reference.aspose.com/slides/net/aspose.slides.animation/itiming/rewind/). 

Voici comment modifier les propriétés Timing de l'effet :

1. [Appliquer](#apply-animation-to-shape) ou obtenir l'effet d'animation.
2. Définissez de nouvelles valeurs pour les propriétés [Effect.Timing](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/properties/timing) dont vous avez besoin. 
3. Enregistrez le fichier PPTX modifié.

Ce code C# montre l'opération :
```c#
// Instancie une classe de présentation qui représente un fichier de présentation.
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
    // Obtient la séquence principale de la diapositive.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Obtient le premier effet de la séquence principale.
    IEffect effect = sequence[0];

    // Modifie le TriggerType de l'effet pour démarrer au clic
    effect.Timing.TriggerType = EffectTriggerType.OnClick;

    // Modifie la durée de l'effet
    effect.Timing.Duration = 3f;

    // Modifie le TriggerDelayTime de l'effet
    effect.Timing.TriggerDelayTime = 0.5f;

    // Si la valeur Repeat de l'effet est "none"
    if (effect.Timing.RepeatCount == 1f)
    {
        // Modifie le Repeat de l'effet à "Until Next Click"
        effect.Timing.RepeatUntilNextClick = true;
    }
    else
    {
        // Modifie le Repeat de l'effet à "Until End of Slide"
        effect.Timing.RepeatUntilEndSlide = true;
    }

    // Active le Rewind de l'effet
        effect.Timing.Rewind = true;
    
    // Enregistre le fichier PPTX sur le disque
    pres.Save("AnimExample_changed.pptx", SaveFormat.Pptx);
}
```


## **Son de l'effet d'animation**

Aspose.Slides fournit ces propriétés pour vous permettre de travailler avec les sons dans les effets d'animation : 
- [IEffect.Sound](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/sound/) 
- [IEffect.StopPreviousSound](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/stopprevioussound/) 

### **Ajouter un son d'effet d'animation**

Ce code C# montre comment ajouter un son d'effet d'animation et l'arrêter lorsque l'effet suivant commence :
```c#
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
	// Ajoute un audio à la collection audio de la présentation
	IAudio effectSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// Obtient la séquence principale de la diapositive.
	ISequence sequence = firstSlide.Timeline.MainSequence;

	// Obtient le premier effet de la séquence principale
	IEffect firstEffect = sequence[0];

	// Vérifie si l'effet n'a pas de son
	if (!firstEffect.StopPreviousSound && firstEffect.Sound == null)
	{
		// Ajoute un son pour le premier effet
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


### **Extraire le son d'effet d'animation**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. Obtenez une référence à une diapositive via son indice. 
3. Récupérez la séquence principale d'effets. 
4. Extrayez le [Sound](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/sound/) incorporé à chaque effet d'animation. 

Ce code C# montre comment extraire le son incorporé dans un effet d'animation :
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

        // Extrait le son de l'effet en tableau d'octets
        byte[] audio = effect.Sound.BinaryData;
    }
}
```


## **Après l'animation**

Aspose.Slides pour .NET vous permet de modifier la propriété After animation d'un effet d'animation.

Voici le volet de l'effet d'animation et le menu étendu dans Microsoft PowerPoint :

![volet d'effet après l'animation](shape-after-animation.png)

La liste déroulante **After animation** du PowerPoint correspond à ces propriétés : 

- La propriété [IEffect.AfterAnimationType](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/afteranimationtype/) qui décrit le type d'animation après :
  * **More Colors** du PowerPoint correspond au type [AfterAnimationType.Color](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/) ;
  * L'item **Don't Dim** du PowerPoint correspond au type [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/) (type d'animation après par défaut) ;
  * L'item **Hide After Animation** du PowerPoint correspond au type [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/) ;
  * L'item **Hide on Next Mouse Click** du PowerPoint correspond au type [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/) ;
- La propriété [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/afteranimationcolor/) qui définit un format de couleur après animation. Cette propriété fonctionne avec le type [AfterAnimationType.Color](https://reference.aspose.com/slides/net/aspose.slides.animation/afteranimationtype/). Si vous changez le type, la couleur après animation sera réinitialisée.

Ce code C# montre comment modifier un effet d'animation après :
```c#
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

Aspose.Slides fournit ces propriétés pour vous permettre de travailler avec le bloc *Animate text* d'un effet d'animation :

- [IEffect.AnimateTextType](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/animatetexttype/) qui décrit le type d'animation du texte de l'effet. Le texte de la forme peut être animé :
  - Tout en même temps ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/net/aspose.slides.animation/animatetexttype/) type)
  - Par mot ([AnimateTextType.ByWord](https://reference.aspose.com/slides/net/aspose.slides.animation/animatetexttype/) type)
  - Par lettre ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/net/aspose.slides.animation/animatetexttype/) type)
- [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/delaybetweentextparts/) définit un délai entre les parties du texte animé (mots ou lettres). Une valeur positive indique le pourcentage de la durée de l'effet. Une valeur négative indique le délai en secondes.

Voici comment modifier les propriétés Animate text de l'effet :

1. [Appliquer](#apply-animation-to-shape) ou obtenir l'effet d'animation.
2. Définissez la propriété [IEffect.TextAnimation.BuildType](https://reference.aspose.com/slides/net/aspose.slides.animation/itextanimation/buildtype/) sur la valeur [BuildType.AsOneObject](https://reference.aspose.com/slides/net/aspose.slides.animation/buildtype/) pour désactiver le mode d'animation *By Paragraphs*.
3. Définissez de nouvelles valeurs pour les propriétés [IEffect.AnimateTextType](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/animatetexttype/) et [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/net/aspose.slides.animation/ieffect/delaybetweentextparts/).
4. Enregistrez le fichier PPTX modifié.

Ce code C# montre l'opération :
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

**Comment garantir la conservation des animations lors de la publication de la présentation sur le web ?**

[Export to HTML5](/slides/fr/net/export-to-html5/) et activez les [options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/) responsables des animations de [shape](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) et de [transition](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/). Le HTML simple ne lit pas les animations de diapositive, alors que le HTML5 le fait.

**Comment le changement de l'ordre z (ordre des calques) des formes affecte-t-il l'animation ?**

L'ordre de mise en page et l'ordre z sont indépendants : un effet contrôle le moment et le type d'apparition/disparition, tandis que l'[z-order](https://reference.aspose.com/slides/net/aspose.slides/shape/zorderposition/) détermine ce qui couvre quoi. Le résultat visible est défini par leur combinaison. (C’est le comportement général de PowerPoint ; le modèle d’effets‑et‑formes d’Aspose.Slides suit la même logique.)

**Existe‑t‑il des limitations lors de la conversion des animations en vidéo pour certains effets ?**

En général, les [animations sont prises en charge](/slides/fr/net/convert-powerpoint-to-video/), mais des cas rares ou des effets spécifiques peuvent être rendus différemment. Il est recommandé de tester avec les effets que vous utilisez et avec la version de la bibliothèque.