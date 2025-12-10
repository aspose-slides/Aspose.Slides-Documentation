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
description: "Découvrez comment créer et personnaliser des animations de forme dans les présentations PowerPoint avec Aspose.Slides pour .NET. Demarquez-vous !"
---

Les animations sont des effets visuels qui peuvent être appliqués aux textes, images, formes ou [graphes](/slides/fr/net/animated-charts/). Elles donnent vie aux présentations ou à leurs constituants. 

## **Pourquoi utiliser les animations dans les présentations ?**

En utilisant des animations, vous pouvez 

* contrôler le flux d’informations
* mettre en évidence les points importants
* stimuler l’intérêt ou la participation de votre audience
* rendre le contenu plus facile à lire, assimiler ou traiter
* attirer l’attention de vos lecteurs ou spectateurs sur les parties importantes d’une présentation

PowerPoint propose de nombreuses options et outils pour les animations et les effets d’animation dans les catégories **entré​e**, **sortie**, **mise en valeur** et **chemins de mouvement**. 

## **Animations dans Aspose.Slides**

* Aspose.Slides fournit les classes et types nécessaires pour travailler avec les animations sous l’espace de noms [Aspose.Slides.Animation](https://reference.aspose.com/slides/net/aspose.slides.animation/) ,
* Aspose.Slides propose plus de **150 effets d’animation** sous l’énumération [EffectType](https://reference.aspose.com/slides/net/aspose.slides.animation/effecttype). Ces effets sont essentiellement les mêmes (ou équivalents) que ceux utilisés dans PowerPoint.

## **Appliquer une animation à une zone de texte**

Aspose.Slides pour .NET vous permet d’appliquer une animation au texte d’une forme. 

1. Créez une instance de la classe [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) .
2. Obtenez la référence d’une diapositive via son index.
3. Ajoutez une forme `rectangle` [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) . 
4. Ajoutez du texte à [IAutoShape.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/properties/textframe) .
5. Récupérez la séquence principale d’effets.
6. Ajoutez un effet d’animation à [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) .
7. Définissez la propriété [TextAnimation.BuildType](https://reference.aspose.com/slides/net/aspose.slides.animation/textanimation/properties/buildtype) à la valeur de l’[enumeration BuildType](https://reference.aspose.com/slides/net/aspose.slides.animation/buildtype) .
8. Enregistrez la présentation sur le disque au format PPTX.

Ce code C# montre comment appliquer l’effet `Fade` à AutoShape et définir l’animation du texte sur la valeur *Par paragraphes du premier niveau* :
```c#
// Instancie une classe de présentation qui représente un fichier de présentation.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    
    // Ajoute une nouvelle AutoShape avec du texte
    IAutoShape autoShape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "First paragraph \nSecond paragraph \n Third paragraph";

    // Récupère la séquence principale de la diapositive.
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

## **Appliquer une animation à un PictureFrame**

1. Créez une instance de la classe [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) .
2. Obtenez la référence d’une diapositive via son index.
3. Ajoutez ou récupérez un [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe) sur la diapositive. 
5. Récupérez la séquence principale d’effets.
6. Ajoutez un effet d’animation à [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe) .
8. Enregistrez la présentation sur le disque au format PPTX.

Ce code C# montre comment appliquer l’effet `Fly` à un cadre image :
```c#
// Instancie une classe de présentation qui représente un fichier de présentation.
using (Presentation pres = new Presentation())
{
    // Charge l'image à ajouter dans la collection d'images de la présentation
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Ajoute un cadre image à la diapositive
    IPictureFrame picFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // Récupère la séquence principale de la diapositive.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Ajoute l'effet d'animation Fly depuis la gauche au cadre image
    IEffect effect = sequence.AddEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Enregistre le fichier PPTX sur le disque
    pres.Save("AnimImage_out.pptx", SaveFormat.Pptx);
}
```


## **Appliquer une animation à une forme**

1. Créez une instance de la classe [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) .
2. Obtenez la référence d’une diapositive via son index.
3. Ajoutez une forme `rectangle` [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) . 
4. Ajoutez un `Bevel` [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape) (lorsque cet objet est cliqué, l’animation se déclenche).
5. Créez une séquence d’effets sur la forme bevel.
6. Créez un `UserPath` personnalisé.
7. Ajoutez des commandes pour déplacer vers le `UserPath`.
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

    // Ajoute l'effet d'animation PathFootBall.
    pres.Slides[0].Timeline.MainSequence.AddEffect(ashp, EffectType.PathFootball,
                           EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Crée une sorte de « bouton ».
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


## **Obtenir les effets d’animation appliqués à une forme**

Les exemples suivants montrent comment utiliser la méthode `GetEffectsByShape` de l’interface [ISequence](https://reference.aspose.com/slides/net/aspose.slides.animation/isequence/) pour obtenir tous les effets d’animation appliqués à une forme.

**Exemple 1 : Obtenir les effets d’animation appliqués à une forme sur une diapositive normale**

Auparavant, vous avez appris comment ajouter des effets d’animation aux formes dans les présentations PowerPoint. Le code d’exemple suivant montre comment récupérer les effets appliqués à la première forme de la première diapositive normale de la présentation `AnimExample_out.pptx`.
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


**Exemple 2 : Obtenir tous les effets d’animation, y compris ceux hérités des espaces réservés**

Si une forme sur une diapositive normale possède des espaces réservés qui se trouvent sur la diapositive de mise en page et/ou la diapositive maître, et que des effets d’animation ont été ajoutés à ces espaces réservés, alors tous les effets de la forme seront lus pendant le diaporama, y compris ceux hérités des espaces réservés.

Supposons que nous ayons un fichier de présentation PowerPoint `sample.pptx` contenant une seule diapositive avec uniquement une forme de pied de page affichant le texte « Made with Aspose.Slides » et que l’effet **Random Bars** soit appliqué à la forme.

![Effet d'animation de forme de diapositive](slide-shape-animation.png)

Supposons également que l’effet **Split** soit appliqué à l’espace réservé du pied de page sur la diapositive de **mise en page**.

![Effet d'animation de forme de mise en page](layout-shape-animation.png)

Enfin, l’effet **Fly In** est appliqué à l’espace réservé du pied de page sur la diapositive **maître**.

![Effet d'animation de forme maître](master-shape-animation.png)

Le code d’exemple suivant montre comment utiliser la méthode `GetBasePlaceholder` de l’interface [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) pour accéder aux espaces réservés de la forme et obtenir les effets d’animation appliqués à la forme du pied de page, y compris ceux hérités des espaces réservés situés sur les diapositives de mise en page et maître.
```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Récupère les effets d'animation de la forme sur la diapositive normale.
    IShape shape = slide.Shapes[0];
    IEffect[] shapeEffects = slide.Timeline.MainSequence.GetEffectsByShape(shape);

    // Récupère les effets d'animation du espace réservé sur la diapositive de mise en page.
    IShape layoutShape = shape.GetBasePlaceholder();
    IEffect[] layoutShapeEffects = slide.LayoutSlide.Timeline.MainSequence.GetEffectsByShape(layoutShape);

    // Récupère les effets d'animation du espace réservé sur la diapositive maître.
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


Sortie :
```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```


## **Modifier les propriétés de synchronisation d’un effet d’animation**

Aspose.Slides pour .NET vous permet de modifier les propriétés de synchronisation d’un effet d’animation.

Voici le volet Synchronisation d’animation et le menu étendu dans Microsoft PowerPoint :

![example1_image](shape-animation.png)

Voici les correspondances entre la synchronisation PowerPoint et les propriétés [Effect.Timing](https://reference.aspose.com/slides/net/aspose.slides.animation/effect/properties/timing) :

- La liste déroulante **Start** du minutage PowerPoint correspond à la propriété [Effect.Timing.TriggerType] .
- La liste déroulante **Duration** du minutage PowerPoint correspond à la propriété [Effect.Timing.Duration] . La durée d’une animation (en secondes) est le temps total nécessaire pour qu’une animation complète un cycle.
- La liste déroulante **Delay** du minutage PowerPoint correspond à la propriété [Effect.Timing.TriggerDelayTime] .
- La liste déroulante **Repeat** du minutage PowerPoint correspond aux propriétés suivantes :
  * La propriété [Effect.Timing.RepeatCount] qui décrit le *nombre* de répétitions de l’effet ;
  * Le drapeau [Effect.Timing.RepeatUntilEndSlide] qui indique si l’effet se répète jusqu’à la fin de la diapositive ;
  * Le drapeau [Effect.Timing.RepeatUntilNextClick] qui indique si l’effet se répète jusqu’au prochain clic.
- La case à cocher **Rewind when done playing** du minutage PowerPoint correspond à la propriété [Effect.Timing.Rewind] .

Voici comment modifier les propriétés de synchronisation d’un effet :

1. [Appliquer](#apply-animation-to-shape) ou récupérer l’effet d’animation.
2. Définissez de nouvelles valeurs pour les propriétés [Effect.Timing] dont vous avez besoin. 
3. Enregistrez le fichier PPTX modifié.

Ce code C# montre l’opération :
```c#
// Instancie une classe Presentation qui représente un fichier de présentation.
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
    // Récupère la séquence principale de la diapositive.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Récupère le premier effet de la séquence principale.
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
        // Modifie le Repeat de l'effet en "Until Next Click"
        effect.Timing.RepeatUntilNextClick = true;
    }
    else
    {
        // Modifie le Repeat de l'effet en "Until End of Slide"
        effect.Timing.RepeatUntilEndSlide = true;
    }

    // Active le Rewind de l'effet
        effect.Timing.Rewind = true;
    
    // Enregistre le fichier PPTX sur le disque
    pres.Save("AnimExample_changed.pptx", SaveFormat.Pptx);
}
```


## **Son d’un effet d’animation**

Aspose.Slides fournit ces propriétés pour travailler avec les sons dans les effets d’animation : 
- [IEffect.Sound] 
- [IEffect.StopPreviousSound] 

### **Ajouter un son à un effet d’animation**

Ce code C# montre comment ajouter un son à un effet d’animation et l’arrêter lorsque l’effet suivant démarre :
```c#
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
	// Ajoute un audio à la collection audio de la présentation
	IAudio effectSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// Récupère la séquence principale de la diapositive.
	ISequence sequence = firstSlide.Timeline.MainSequence;

	// Récupère le premier effet de la séquence principale
	IEffect firstEffect = sequence[0];

	// Vérifie si l'effet n'a pas de son
	if (!firstEffect.StopPreviousSound && firstEffect.Sound == null)
	{
		// Ajoute un son au premier effet
		firstEffect.Sound = effectSound;
	}

	// Récupère la première séquence interactive de la diapositive.
	ISequence interactiveSequence = firstSlide.Timeline.InteractiveSequences[0];

	// Définit le drapeau StopPreviousSound de l'effet
	interactiveSequence[0].StopPreviousSound = true;

	// Enregistre le fichier PPTX sur le disque
	pres.Save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
}
```


### **Extraire le son d’un effet d’animation**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. Obtenez la référence d’une diapositive via son index. 
3. Récupérez la séquence principale d’effets. 
4. Extrayez le [Sound] intégré à chaque effet d’animation. 

Ce code C# montre comment extraire le son intégré dans un effet d’animation :
```c#
// Instancie une classe de présentation qui représente un fichier de présentation.
using (Presentation presentation = new Presentation("EffectSound.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Récupère la séquence principale de la diapositive.
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


## **Après l’animation**

Aspose.Slides pour .NET vous permet de modifier la propriété After animation d’un effet d’animation.

Voici le volet Effet d’animation et le menu étendu dans Microsoft PowerPoint :

![example1_image](shape-after-animation.png)

La liste déroulante **After animation** du volet Effet PowerPoint correspond aux propriétés suivantes :

- La propriété [IEffect.AfterAnimationType] qui décrit le type d’animation après :
  * **More Colors** de PowerPoint correspond au type [AfterAnimationType.Color] ;
  * **Don't Dim** de PowerPoint correspond au type [AfterAnimationType.DoNotDim] (type d’animation après par défaut) ;
  * **Hide After Animation** de PowerPoint correspond au type [AfterAnimationType.HideAfterAnimation] ;
  * **Hide on Next Mouse Click** de PowerPoint correspond au type [AfterAnimationType.HideOnNextMouseClick] ;
- La propriété [IEffect.AfterAnimationColor] qui définit un format de couleur après l’animation. Cette propriété fonctionne en conjonction avec le type [AfterAnimationType.Color]. Si vous changez le type, la couleur après l’animation sera effacée.

Ce code C# montre comment modifier un effet après l’animation :
```c#
// Instancie une classe de présentation qui représente un fichier de présentation
using (Presentation pres = new Presentation("AnimImage_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // Récupère le premier effet de la séquence principale
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

Aspose.Slides fournit ces propriétés pour travailler avec le bloc *Animate text* d’un effet d’animation :

- [IEffect.AnimateTextType] qui décrit le type d’animation du texte de l’effet. Le texte de la forme peut être animé :
  - Tout d’un seul coup ([AnimateTextType.AllAtOnce] )
  - Par mot ([AnimateTextType.ByWord] )
  - Par lettre ([AnimateTextType.ByLetter] )
- [IEffect.DelayBetweenTextParts] définit un délai entre les parties de texte animées (mots ou lettres). Une valeur positive indique le pourcentage de la durée de l’effet. Une valeur négative indique le délai en secondes.

Voici comment modifier les propriétés *Animate text* de l’effet :

1. [Appliquer](#apply-animation-to-shape) ou récupérer l’effet d’animation.
2. Définissez la propriété [IEffect.TextAnimation.BuildType] sur la valeur [BuildType.AsOneObject] pour désactiver le mode d’animation *Par paragraphes*.
3. Définissez de nouvelles valeurs pour les propriétés [IEffect.AnimateTextType] et [IEffect.DelayBetweenTextParts] .
4. Enregistrez le fichier PPTX modifié.

Ce code C# montre l’opération :
```c#
// Instancie une classe de présentation qui représente un fichier de présentation.
using (Presentation pres = new Presentation("AnimTextBox_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // Récupère le premier effet de la séquence principale
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // Modifie le type d'animation du texte de l'effet en "As One Object"
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

**Comment garantir que les animations sont conservées lors de la publication de la présentation sur le web ?**

[Export to HTML5](/slides/fr/net/export-to-html5/) et activez les [options]https://reference.aspose.com/slides/net/aspose.slides.export/html5options/ responsables des animations de [shape]https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/ et de [transition]https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/. Le HTML simple ne lit pas les animations de diapositive, alors que le HTML5 le fait.

**Comment la modification de l’ordre z (ordre des calques) des formes affecte‑t‑elle les animations ?**

Les animations et l’ordre de dessin sont indépendants : un effet contrôle le minutage et le type d’apparition/disparition, tandis que le [z-order]https://reference.aspose.com/slides/net/aspose.slides/shape/zorderposition/ détermine ce qui recouvre quoi. Le résultat visible est défini par leur combinaison. (C’est le comportement général de PowerPoint ; le modèle effets‑et‑formes d’Aspose.Slides suit la même logique.)

**Existe‑t‑il des limitations lors de la conversion des animations en vidéo pour certains effets ?**

En général, les [animations are supported](/slides/fr/net/convert-powerpoint-to-video/), mais des cas rares ou des effets spécifiques peuvent être rendus différemment. Il est recommandé de tester avec les effets que vous utilisez et avec la version de la bibliothèque.