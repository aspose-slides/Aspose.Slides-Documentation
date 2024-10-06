---
title: Animation de Formes
type: docs
weight: 60
url: /java/shape-animation/
keywords: "animation PowerPoint, effet d'animation, appliquer une animation, présentation PowerPoint, Java, Aspose.Slides pour Java"
description: "Appliquer une animation PowerPoint en Java"
---

Les animations sont des effets visuels qui peuvent être appliqués aux textes, images, formes ou [graphiques](https://docs.aspose.com/slides/java/animated-charts/). Elles donnent vie aux présentations ou à leurs composants.

### **Pourquoi utiliser des animations dans les présentations ?**

En utilisant des animations, vous pouvez

* contrôler le flux d'informations
* souligner des points importants
* augmenter l'intérêt ou la participation de votre audience
* rendre le contenu plus facile à lire, assimiler ou traiter
* attirer l'attention de vos lecteurs ou spectateurs sur des parties importantes d'une présentation

PowerPoint propose de nombreuses options et outils pour les animations et effets d'animation dans les catégories **entrée**, **sortie**, **emphase** et **chemins de mouvement**.

### **Animations dans Aspose.Slides**

* Aspose.Slides fournit les classes et types dont vous avez besoin pour travailler avec des animations sous l'espace de noms `Aspose.Slides.Animation`,
* Aspose.Slides propose plus de **150 effets d'animation** sous l'énumération [EffectType](https://reference.aspose.com/slides/java/com.aspose.slides/effecttype). Ces effets sont essentiellement les mêmes (ou équivalents) que ceux utilisés dans PowerPoint.

## **Appliquer une animation à TextBox**

Aspose.Slides pour Java vous permet d'appliquer une animation au texte d'une forme.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Obtenez une référence de diapositive par son index.
3. Ajoutez une forme de type `rectangle` [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape).
4. Ajoutez du texte à [IAutoShape.TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-).
5. Obtenez une séquence principale d'effets.
6. Ajoutez un effet d'animation à [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape).
7. Définissez la propriété `TextAnimation.BuildType` sur la valeur de l'énumération `BuildType`.
8. Enregistrez la présentation sur le disque sous forme de fichier PPTX.

Ce code Java vous montre comment appliquer l'effet `Fade` à un AutoShape et définir l'animation du texte sur la valeur *By 1st Level Paragraphs* :

```java
// Instantiates a presentation class that represents a presentation file.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Adds new AutoShape with text
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Premier paragraphe \nDeuxième paragraphe \nTroisième paragraphe");

    // Gets the main sequence of the slide.
    ISequence sequence = sld.getTimeline().getMainSequence();

    // Adds Fade animation effect to shape
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Animates shape text by 1st level paragraphs
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // Save the PPTX file to disk
    pres.save(path + "AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert color="primary"  %}} 

En plus d'appliquer des animations au texte, vous pouvez également appliquer des animations à un seul [Paragraphe](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph). Voir [**Texte Animé**](/slides/java/animated-text/).

{{% /alert %}} 

## **Appliquer une animation à PictureFrame**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Obtenez une référence de diapositive par son index.
3. Ajoutez ou obtenez un [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe) sur la diapositive.
4. Obtenez la séquence principale d'effets.
5. Ajoutez un effet d'animation à [PictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/pictureframe).
6. Enregistrez la présentation sur le disque sous forme de fichier PPTX.

Ce code Java vous montre comment appliquer l'effet `Fly` à un cadre d'image :

```java
// Instantiates a presentation class that represents a presentation file.
Presentation pres = new Presentation();
try {
    // Load Image to be added in presentaiton image collection
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Adds picture frame to slide
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, picture);

    // Gets the main sequence of the slide.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Adds Fly from Left animation effect to picture frame
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Save the PPTX file to disk
    pres.save(path + "AnimImage_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Appliquer une animation à Shape**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Obtenez une référence de diapositive par son index.
3. Ajoutez une forme de type `rectangle` [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape).
4. Ajoutez un [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape) de type `Bevel` (lorsque cet objet est cliqué, l'animation est lancée).
5. Créez une séquence d'effets sur la forme bevel.
6. Créez un `UserPath` personnalisé.
7. Ajoutez des commandes pour le déplacement vers le `UserPath`.
8. Enregistrez la présentation sur le disque sous forme de fichier PPTX.

Ce code Java vous montre comment appliquer l'effet `PathFootball` (chemin football) à une forme :

```java
// Instantiate a Presentation class that represents a PPTX file.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Creates PathFootball effect for existing shape from scratch.
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Texte Animé");

    // Adds the PathFootBall animation effect
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Creates some kind of "button".
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Creates a sequence of effects for this button.
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // Creates a custom user path. Our object will be moved only after the button is clicked.
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

     // Adds commands for moving since created path is empty.
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.getBehaviors().get_Item(0));

    Point2D.Float[] pts = new Point2D.Float[1];
    pts[0] = new Point2D.Float(0.076f, 0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new Point2D.Float(-0.076f, -0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.getPath().add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

     // Writes the PPTX file to disk
    pres.save("AnimExample_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Obtenir les effets d'animation appliqués à une forme**

Vous pouvez décider de découvrir tous les effets d'animation appliqués à une seule forme.

Ce code Java vous montre comment obtenir tous les effets appliqués à une forme spécifique :

```java
// Instantiates a presentation class that represents a presentation file.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Gets the main sequence of the slide.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Gets the first shape on slide.
    IShape shape = firstSlide.getShapes().get_Item(0);

    // Gets all animation effects applied to the shape.
    IEffect[] shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0)
        System.out.println("La forme " + shape.getName() + " a " + shapeEffects.length + " effets d'animation.");
} finally {
    if (pres != null) pres.dispose();
}
```

## **Modifier les propriétés de timing des effets d'animation**

Aspose.Slides pour Java vous permet de modifier les propriétés de timing d'un effet d'animation.

Voici le panneau de Timing d'Animation dans Microsoft PowerPoint :

![example1_image](shape-animation.png)

Voici les correspondances entre le Timing de PowerPoint et les propriétés [Effect.Timing](https://reference.aspose.com/slides/java/com.aspose.slides/IEffect#getTiming--) :

- La liste déroulante Timing **Début** de PowerPoint correspond à la propriété [Effect.Timing.TriggerType](https://reference.aspose.com/slides/java/com.aspose.slides/ITiming#getTriggerType--) .
- La **Durée** de Timing de PowerPoint correspond à la propriété [Effect.Timing.Duration](https://reference.aspose.com/slides/java/com.aspose.slides/ITiming#getDuration--) . La durée d'une animation (en secondes) est le temps total nécessaire pour que l'animation complète un cycle.
- Le **Délai** de Timing correspond à la propriété [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/java/com.aspose.slides/ITiming#getTriggerDelayTime--) .

Voici comment vous modifiez les propriétés de Timing de l'effet :

1. [Appliquez](#apply-animation-to-shape) ou obtenez l'effet d'animation.
2. Définissez de nouvelles valeurs pour les propriétés [Effect.Timing](https://reference.aspose.com/slides/java/com.aspose.slides/IEffect#getTiming--) dont vous avez besoin.
3. Enregistrez le fichier PPTX modifié.

Ce code Java démontre l'opération :

```java
// Instantiates a presentation class that represents a presentation file.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Gets the main sequence of the slide.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Gets the first effect of main sequence.
    IEffect effect = sequence.get_Item(0);

    // Changes effect TriggerType to start on click
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick);

    // Changes effect Duration
    effect.getTiming().setDuration(3f);

    // Changes effect TriggerDelayTime
    effect.getTiming().setTriggerDelayTime(0.5f);

    // Saves the PPTX file to disk
    pres.save("AnimExample_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Son de l'effet d'animation**

Aspose.Slides fournit ces propriétés pour vous permettre de travailler avec des sons dans les effets d'animation : 

- [setSound(IAudio value)](https://reference.aspose.com/slides/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) 
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/java/com.aspose.slides/effect/#setStopPreviousSound-boolean-) 

### **Ajouter le son d'effet d'animation**

Ce code Java vous montre comment ajouter un son d'effet d'animation et l'arrêter lorsque l'effet suivant commence :

```java
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Adds audio to presentation audio collection
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Gets the main sequence of the slide.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Gets the first effect of the main sequence
    IEffect firstEffect = sequence.get_Item(0);

    // Checks the effect for "No Sound"
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // Adds sound for the first effect
        firstEffect.setSound(effectSound);
    }

    // Gets the first interactive sequence of the slide.
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // Sets the effect "Stop previous sound" flag
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // Writes the PPTX file to disk
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Extraire le son de l'effet d'animation**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/aspose.slides/presentation/) .
2. Obtenez une référence de diapositive par son index.
3. Obtenez la séquence principale d'effets.
4. Extraire le son [setSound(IAudio value)](https://reference.aspose.com/slides/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) intégré à chaque effet d'animation.

Ce code Java vous montre comment extraire le son intégré dans un effet d'animation :

```java
// Instantiates a presentation class that represents a presentation file.
Presentation presentation = new Presentation("EffectSound.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Gets the main sequence of the slide.
    ISequence sequence = slide.getTimeline().getMainSequence();

    for (IEffect effect : sequence)
    {
        if (effect.getSound() == null)
            continue;

        // Extracts the effect sound in byte array
        byte[] audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Après animation**

Aspose.Slides pour Java vous permet de modifier la propriété After animation d'un effet d'animation.

Voici le panneau d'Effet d'Animation et le menu étendu dans Microsoft PowerPoint :

![example1_image](shape-after-animation.png)

La liste déroulante **Après animation** de l'effet PowerPoint correspond à ces propriétés :

- [setAfterAnimationType(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setAfterAnimationType-int-) qui décrit le type d'animation après :
  * Les **Plus de couleurs** de PowerPoint correspondent au type [AfterAnimationType.Color](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#Color) ;
  * La liste des éléments **Ne pas atténuer** de PowerPoint correspond au type [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#DoNotDim) (type par défaut après animation) ;
  * L'élément **Masquer après animation** de PowerPoint correspond au type [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#HideAfterAnimation) ;
  * L'élément **Masquer au prochain clic de souris** correspond au type [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick) ;
- [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) qui définit un format de couleur après animation. Cette propriété fonctionne en conjonction avec le type [AfterAnimationType.Color](https://reference.aspose.com/slides/java/com.aspose.slides/afteranimationtype/#Color) . Si vous changez le type en un autre, la couleur après animation sera effacée.

Ce code Java vous montre comment modifier un effet d'animation après :

```java
// Instantiates a presentation class that represents a presentation file
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Gets the first effect of the main sequence
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Changes the after animation type to Color
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // Sets the after animation dim color
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // Writes the PPTX file to disk
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Animer le texte**

Aspose.Slides fournit ces propriétés pour vous permettre de travailler avec le bloc d'effet *Animer le texte* :

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) qui décrit un type d'animation de texte de l'effet. Le texte de la forme peut être animé :
  - Tout à la fois ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/java/com.aspose.slides/animatetexttype/#AllAtOnce) type)
  - Par mot ([AnimateTextType.ByWord](https://reference.aspose.com/slides/java/com.aspose.slides/animatetexttype/#ByWord) type)
  - Par lettre ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/java/com.aspose.slides/animatetexttype/#ByLetter) type)
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) définit un délai entre les parties de texte animées (mots ou lettres). Une valeur positive spécifie le pourcentage de la durée de l'effet. Une valeur négative spécifie le délai en secondes.

Voici comment vous pouvez modifier les propriétés d'animation de l'effet de texte :

1. [Appliquez](#apply-animation-to-shape) ou obtenez l'effet d'animation.
2. Définissez la propriété [setBuildType(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/itextanimation/#setBuildType-int-) sur la valeur [BuildType.AsOneObject](https://reference.aspose.com/slides/java/com.aspose.slides/buildtype/#AsOneObject) pour désactiver le mode *Par paragraphes* d'animation.
3. Définissez de nouvelles valeurs pour les propriétés [setAnimateTextType(int value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) et [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) .
4. Enregistrez le fichier PPTX modifié.

Ce code Java démontre l'opération :

```java
// Instantiates a presentation class that represents a presentation file.
Presentation pres = new Presentation("AnimTextBox_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Gets the first effect of the main sequence
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Changes the effect Text animation type to "As One Object"
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // Changes the effect Animate text type to "By word"
    firstEffect.setAnimateTextType(AnimateTextType.ByWord);

    // Sets the delay between words to 20% of effect duration
    firstEffect.setDelayBetweenTextParts(20f);

    // Writes the PPTX file to disk
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```