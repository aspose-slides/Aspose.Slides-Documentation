---
title: Animation de forme
type: docs
weight: 60
url: /androidjava/shape-animation/
keywords: "animation PowerPoint, effet d'animation, appliquer une animation, présentation PowerPoint, Java, Aspose.Slides pour Android via Java"
description: "Appliquer une animation PowerPoint en Java"
---

Les animations sont des effets visuels qui peuvent être appliqués à des textes, des images, des formes ou des [graphes](https://docs.aspose.com/slides/androidjava/animated-charts/). Elles donnent vie aux présentations ou à ses éléments.

### **Pourquoi utiliser des animations dans les présentations ?**

En utilisant des animations, vous pouvez 

* contrôler le flux d'information
* souligner des points importants
* augmenter l'intérêt ou la participation de votre public
* rendre le contenu plus facile à lire, assimiler ou traiter
* attirer l'attention de vos lecteurs ou spectateurs sur des parties importantes d'une présentation

PowerPoint propose de nombreuses options et outils pour les animations et les effets d'animation dans les catégories **entrée**, **sortie**, **emphase** et **chemins de mouvement**. 

### **Animations dans Aspose.Slides**

* Aspose.Slides fournit les classes et les types dont vous avez besoin pour travailler avec des animations sous l'espace de noms `Aspose.Slides.Animation`,
* Aspose.Slides propose plus de **150 effets d'animation** sous l'énumération [EffectType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effecttype). Ces effets sont essentiellement les mêmes (ou équivalents) que ceux utilisés dans PowerPoint.

## **Appliquer une animation à TextBox**

Aspose.Slides pour Android via Java vous permet d'appliquer une animation au texte dans une forme.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Obtenez une référence de diapositive via son index.
3. Ajoutez un [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape) `rectangle`.
4. Ajoutez du texte à [IAutoShape.TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-).
5. Obtenez une séquence principale d'effets.
6. Ajoutez un effet d'animation à [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape).
7. Définissez la propriété `TextAnimation.BuildType` sur la valeur de l'énumération `BuildType`.
8. Enregistrez la présentation sur le disque en tant que fichier PPTX.

Ce code Java vous montre comment appliquer l'effet `Fade` à AutoShape et définir l'animation de texte à *Par niveaux de paragraphes* :

```java
// Instancie une classe de présentation qui représente un fichier de présentation.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Ajoute une nouvelle AutoShape avec du texte
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Premier paragraphe \nDeuxième paragraphe \n Troisième paragraphe");

    // Obtient la séquence principale de la diapositive.
    ISequence sequence = sld.getTimeline().getMainSequence();

    // Ajoute un effet d'animation Fade à la forme
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Anime le texte de la forme par niveaux de paragraphes
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // Sauvegarde le fichier PPTX sur disque
    pres.save(path + "AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert color="primary"  %}} 

En plus d'appliquer des animations au texte, vous pouvez également appliquer des animations à un seul [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph). Voir [**Texte Animé**](/slides/androidjava/animated-text/).

{{% /alert %}} 

## **Appliquer une animation à PictureFrame**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Obtenez une référence de diapositive via son index.
3. Ajoutez ou obtenez un [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe) sur la diapositive.
4. Obtenez la séquence principale d'effets.
5. Ajoutez un effet d'animation à [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe).
6. Enregistrez la présentation sur le disque en tant que fichier PPTX.

Ce code Java vous montre comment appliquer l'effet `Fly` à un cadre d'image :

```java
// Instancie une classe de présentation qui représente un fichier de présentation.
Presentation pres = new Presentation();
try {
    // Charge l'image à ajouter dans la collection d'images de la présentation
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Ajoute un cadre d'image à la diapositive
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, picture);

    // Obtient la séquence principale de la diapositive.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Ajoute un effet d'animation Fly from Left au cadre d'image
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Sauvegarde le fichier PPTX sur disque
    pres.save(path + "AnimImage_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Appliquer une animation à Shape**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. Obtenez une référence de diapositive via son index.
3. Ajoutez un [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape) `rectangle`.
4. Ajoutez un [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape) `Bevel` (lorsque cet objet est cliqué, l'animation est jouée).
5. Créez une séquence d'effets sur la forme biseautée.
6. Créez un `UserPath` personnalisé.
7. Ajoutez des commandes pour se déplacer vers le `UserPath`.
8. Enregistrez la présentation sur le disque en tant que fichier PPTX.

Ce code Java vous montre comment appliquer l'effet `PathFootball` (effet football) à une forme :

```java
// Instancie une classe de présentation qui représente un fichier PPTX.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Crée l'effet PathFootball pour une forme existante de zéro.
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Boîte de texte animée");

    // Ajoute l'effet d'animation PathFootBall
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Crée une sorte de "bouton".
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Crée une séquence d'effets pour ce bouton.
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // Crée un chemin utilisateur personnalisé. Notre objet ne sera déplacé qu'après que le bouton est cliqué.
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

     // Ajoute des commandes pour se déplacer puisque le chemin créé est vide.
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.getBehaviors().get_Item(0));

    Point2D.Float[] pts = new Point2D.Float[1];
    pts[0] = new Point2D.Float(0.076f, 0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new Point2D.Float(-0.076f, -0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.getPath().add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

     // Écrit le fichier PPTX sur disque
    pres.save("AnimExample_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Obtenir les effets d'animation appliqués à la forme**

Vous pouvez décider de découvrir tous les effets d'animation appliqués à une seule forme. 

Ce code Java vous montre comment obtenir tous les effets appliqués à une forme spécifique :

```java
// Instancie une classe de présentation qui représente un fichier de présentation.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Obtient la séquence principale de la diapositive.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Obtient la première forme sur la diapositive.
    IShape shape = firstSlide.getShapes().get_Item(0);

    // Obtient tous les effets d'animation appliqués à la forme.
    IEffect[] shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0)
        System.out.println("La forme " + shape.getName() + " a " + shapeEffects.length + " effets d'animation.");
} finally {
    if (pres != null) pres.dispose();
}
```

## **Modifier les propriétés de timing des effets d'animation**

Aspose.Slides pour Android via Java vous permet de modifier les propriétés de Timing d'un effet d'animation.

Voici le panneau de timing d'animation dans Microsoft PowerPoint :

![example1_image](shape-animation.png)

Voici les correspondances entre le timing PowerPoint et les propriétés [Effect.Timing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IEffect#getTiming--) :

- La liste déroulante **Démarrer** du timing PowerPoint correspond à la propriété [Effect.Timing.TriggerType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiming#getTriggerType--) .
- La **Durée** du timing PowerPoint correspond à la propriété [Effect.Timing.Duration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiming#getDuration--). La durée d'une animation (en secondes) est le temps total qu'il faut à l'animation pour compléter un cycle.
- Le **Délai** du timing PowerPoint correspond à la propriété [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiming#getTriggerDelayTime--).

Voici comment vous modifiez les propriétés de timing de l'effet :

1. [Appliquer](#apply-animation-to-shape) ou obtenir l'effet d'animation.
2. Définissez de nouvelles valeurs pour les propriétés [Effect.Timing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IEffect#getTiming--) dont vous avez besoin.
3. Enregistrez le fichier PPTX modifié.

Ce code Java démontre l'opération :

```java
// Instancie une classe de présentation qui représente un fichier de présentation.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Obtient la séquence principale de la diapositive.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Obtient le premier effet de la séquence principale.
    IEffect effect = sequence.get_Item(0);

    // Modifie le TriggerType de l'effet pour démarrer sur clic
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick);

    // Modifie la durée de l'effet
    effect.getTiming().setDuration(3f);

    // Modifie le TriggerDelayTime de l'effet
    effect.getTiming().setTriggerDelayTime(0.5f);

    // Sauvegarde le fichier PPTX sur disque
    pres.save("AnimExample_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Son d'effet d'animation**

Aspose.Slides fournit ces propriétés pour vous permettre de travailler avec des sons dans les effets d'animation :

- [setSound(IAudio value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effect/#setStopPreviousSound-boolean-)

### **Ajouter un son d'effet d'animation**

Ce code Java montre comment ajouter un son d'effet d'animation et l'arrêter lorsque le prochain effet commence :

```java
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Ajoute de l'audio à la collection d'audio de la présentation
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Obtient la séquence principale de la diapositive.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Obtient le premier effet de la séquence principale
    IEffect firstEffect = sequence.get_Item(0);

    // Vérifie l'effet pour "Pas de son"
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // Ajoute du son pour le premier effet
        firstEffect.setSound(effectSound);
    }

    // Obtient la première séquence interactive de la diapositive.
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // Définit le drapeau "Arrêter le son précédent" de l'effet
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // Écrit le fichier PPTX sur disque
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Extraire le son d'effet d'animation**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/aspose.slides/presentation/) .
2. Obtenez une référence de diapositive via son index. 
3. Obtenez la séquence principale d'effets. 
4. Extrayez le [setSound(IAudio value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) intégré à chaque effet d'animation.

Ce code Java montre comment extraire le son intégré dans un effet d'animation :

```java
// Instancie une classe de présentation qui représente un fichier de présentation.
Presentation presentation = new Presentation("EffectSound.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Obtient la séquence principale de la diapositive.
    ISequence sequence = slide.getTimeline().getMainSequence();

    for (IEffect effect : sequence)
    {
        if (effect.getSound() == null)
            continue;

        // Extrait le son de l'effet dans un tableau d'octets
        byte[] audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Après l'animation**

Aspose.Slides pour Android via Java vous permet de modifier la propriété Après l'animation d'un effet d'animation.

Voici le panneau d'effet d'animation et le menu étendu dans Microsoft PowerPoint :

![example1_image](shape-after-animation.png)

La liste déroulante **Après l'animation** de l'effet PowerPoint correspond à ces propriétés :

- [setAfterAnimationType(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAfterAnimationType-int-) qui décrit le type d'animation après :
  * Les **Plus de couleurs** de PowerPoint correspondent au type [AfterAnimationType.Color](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#Color) ;
  * Le **Ne pas atténuer** de la liste correspond au type [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#DoNotDim) (type par défaut après animation) ;
  * L'élément **Masquer après animation** correspond au type [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#HideAfterAnimation) ;
  * L'élément **Masquer au prochain clic de souris** correspond au type [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick) ;
- [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) qui définit un format de couleur après animation. Cette propriété fonctionne en conjonction avec le type [AfterAnimationType.Color](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#Color). Si vous changez le type en un autre, la couleur après animation sera effacée.

Ce code Java vous montre comment changer un effet d'animation après :

```java
// Instancie une classe de présentation qui représente un fichier de présentation
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Obtient le premier effet de la séquence principale
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Modifie le type d'animation après en couleur
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // Définit la couleur d'atténuation après l'animation
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // Écrit le fichier PPTX sur disque
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Animer le texte**

Aspose.Slides fournit ces propriétés pour vous permettre de travailler avec le bloc *Animer le texte* d'un effet d'animation :

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) qui décrit un type d'animation de texte de l'effet. Le texte de la forme peut être animé :
  - En une seule fois ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/androidjava/com.aspose.slides/animatetexttype/#AllAtOnce) type)
  - Par mot ([AnimateTextType.ByWord](https://reference.aspose.com/slides/androidjava/com.aspose.slides/animatetexttype/#ByWord) type)
  - Par lettre ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/animatetexttype/#ByLetter) type)
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) définit un délai entre les parties de texte animées (mots ou lettres). Une valeur positive précise le pourcentage de la durée de l'effet. Une valeur négative précise le délai en secondes.

Voici comment vous pouvez modifier les propriétés d'effet Animer le texte :

1. [Appliquer](#apply-animation-to-shape) ou obtenir l'effet d'animation.
2. Définissez la propriété [setBuildType(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextanimation/#setBuildType-int-) à la valeur [BuildType.AsOneObject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/buildtype/#AsOneObject) pour désactiver le mode d'animation *Par paragraphes*.
3. Définissez de nouvelles valeurs pour les propriétés [setAnimateTextType(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) et [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) .
4. Enregistrez le fichier PPTX modifié.

Ce code Java démontre l'opération :

```java
// Instancie une classe de présentation qui représente un fichier de présentation.
Presentation pres = new Presentation("AnimTextBox_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Obtient le premier effet de la séquence principale
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Modifie le type d'animation de texte de l'effet à "Comme un seul objet"
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // Modifie le type d'animation de texte de l'effet à "Par mot"
    firstEffect.setAnimateTextType(AnimateTextType.ByWord);

    // Définit le délai entre les mots à 20% de la durée de l'effet
    firstEffect.setDelayBetweenTextParts(20f);

    // Écrit le fichier PPTX sur disque
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```