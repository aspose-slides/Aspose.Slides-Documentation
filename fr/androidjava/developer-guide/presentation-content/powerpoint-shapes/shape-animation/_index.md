---
title: Appliquer des animations de formes dans les présentations sur Android
linktitle: Animation de forme
type: docs
weight: 60
url: /fr/androidjava/shape-animation/
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
- Android
- Java
- Aspose.Slides
description: "Découvrez comment créer et personnaliser des animations de formes dans les présentations PowerPoint avec Aspose.Slides pour Android via Java. Démarquez-vous!"
---


Les animations sont des effets visuels qui peuvent être appliqués aux textes, aux images, aux formes ou aux [graphes](https://docs.aspose.com/slides/androidjava/animated-charts/). Elles donnent vie aux présentations ou à leurs constituants.

## **Pourquoi utiliser les animations dans les présentations ?**

En utilisant les animations, vous pouvez  

* contrôler le flux d'information  
* mettre en évidence les points importants  
* augmenter l'intérêt ou la participation de votre audience  
* rendre le contenu plus facile à lire, assimiler ou traiter  
* attirer l'attention de vos lecteurs ou spectateurs sur les parties importantes d’une présentation  

PowerPoint propose de nombreuses options et outils pour les animations et les effets d'animation dans les catégories **entrée**, **sortie**, **mise en emphase** et **chemins de mouvement**.

## **Animations dans Aspose.Slides**

* Aspose.Slides fournit les classes et types dont vous avez besoin pour travailler avec les animations dans l’espace de noms `Aspose.Slides.Animation`,  
* Aspose.Slides propose plus de **150 effets d'animation** sous l'énumération [EffectType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effecttype). Ces effets sont essentiellement les mêmes (ou l'équivalent) que ceux utilisés dans PowerPoint.

## **Appliquer une animation à une zone de texte**

Aspose.Slides pour Android via Java vous permet d'appliquer une animation au texte d'une forme.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).  
2. Obtenez une référence de diapositive via son indice.  
3. Ajoutez une [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape) `rectangle`.  
4. Ajoutez du texte à [IAutoShape.TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-).  
5. Récupérez la séquence principale d'effets.  
6. Ajoutez un effet d'animation à [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape).  
7. Définissez la propriété `TextAnimation.BuildType` sur la valeur de l'énumération `BuildType`.  
8. Enregistrez la présentation sur le disque au format PPTX.  

Ce code Java montre comment appliquer l'effet `Fade` à AutoShape et définir l'animation du texte sur la valeur *By 1st Level Paragraphs* :  
```java
// Instancie une classe de présentation représentant un fichier de présentation.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Ajoute une nouvelle AutoShape avec du texte
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");

    // Récupère la séquence principale de la diapositive.
    ISequence sequence = sld.getTimeline().getMainSequence();

    // Ajoute un effet d'animation Fade à la forme
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Anime le texte de la forme par paragraphes de premier niveau
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // Enregistre le fichier PPTX sur le disque
    pres.save(path + "AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{%  alert color="primary"  %}} 

En plus d'appliquer des animations au texte, vous pouvez également appliquer des animations à un seul [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph). Voir [**Animated Text**](/slides/fr/androidjava/animated-text/).  
{{% /alert %}} 

## **Appliquer une animation à un PictureFrame**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).  
2. Obtenez une référence de diapositive via son indice.  
3. Ajoutez ou récupérez un [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe) sur la diapositive.  
4. Récupérez la séquence principale d'effets.  
5. Ajoutez un effet d'animation à [PictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pictureframe).  
6. Enregistrez la présentation sur le disque au format PPTX.  

Ce code Java montre comment appliquer l'effet `Fly` à un cadre d'image :  
```java
// Instancie une classe de présentation qui représente un fichier de présentation.
Presentation pres = new Presentation();
try {
    // Charge l'image à ajouter à la collection d'images de la présentation
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Ajoute un cadre d'image à la diapositive
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, picture);

    // Récupère la séquence principale de la diapositive.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Ajoute l'effet d'animation Fly depuis la gauche au cadre d'image
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Enregistre le fichier PPTX sur le disque
    pres.save(path + "AnimImage_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Appliquer une animation à une forme**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).  
2. Obtenez une référence de diapositive via son indice.  
3. Ajoutez une [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape) `rectangle`.  
4. Ajoutez une [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape) `Bevel` (lorsque cet objet est cliqué, l'animation se lance).  
5. Créez une séquence d'effets sur la forme Bevel.  
6. Créez un `UserPath` personnalisé.  
7. Ajoutez des commandes de déplacement vers le `UserPath`.  
8. Enregistrez la présentation sur le disque au format PPTX.  

Ce code Java montre comment appliquer l'effet `PathFootball` (football de chemin) à une forme :  
```java
// Instancie une classe Presentation qui représente un fichier PPTX.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Crée l'effet PathFootball pour la forme existante à partir de zéro.
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");

    // Ajoute l'effet d'animation PathFootBall
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Crée un type de « bouton ».
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Crée une séquence d'effets pour ce bouton.
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // Crée un chemin utilisateur personnalisé. Notre objet ne sera déplacé qu'après que le bouton soit cliqué.
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

     // Ajoute des commandes de déplacement puisque le chemin créé est vide.
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.getBehaviors().get_Item(0));

    Point2D.Float[] pts = new Point2D.Float[1];
    pts[0] = new Point2D.Float(0.076f, 0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new Point2D.Float(-0.076f, -0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.getPath().add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

     // Écrit le fichier PPTX sur le disque
    pres.save("AnimExample_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Obtenir les effets d'animation appliqués à une forme**

Les exemples suivants montrent comment utiliser la méthode `getEffectsByShape` de l'interface [ISequence](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isequence/) pour obtenir tous les effets d'animation appliqués à une forme.

**Exemple 1 : Obtenir les effets d'animation appliqués à une forme sur une diapositive normale**

Auparavant, vous avez appris comment ajouter des effets d'animation aux formes dans les présentations PowerPoint. Le code d'exemple suivant montre comment obtenir les effets appliqués à la première forme de la première diapositive normale de la présentation `AnimExample_out.pptx`.  
```java
Presentation presentation = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Récupère la séquence d'animation principale de la diapositive.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Récupère la première forme de la première diapositive.
    IShape shape = firstSlide.getShapes().get_Item(0);

    // Récupère les effets d'animation appliqués à la forme.
    IEffect[] shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0)
        System.out.println("The shape " + shape.getName() + " has " + shapeEffects.length + " animation effects.");
} finally {
    if (presentation != null) presentation.dispose();
}
```


**Exemple 2 : Obtenir tous les effets d'animation, y compris ceux hérités des espaces réservés**

Si une forme sur une diapositive normale possède des espaces réservés qui se trouvent sur la diapositive layout ou la diapositive master, et que des effets d'animation ont été ajoutés à ces espaces réservés, alors tous les effets de la forme seront joués pendant le diaporama, y compris ceux hérités des espaces réservés.

Supposons que nous ayons un fichier de présentation PowerPoint `sample.pptx` avec une diapositive contenant uniquement une forme de pied de page avec le texte "Made with Aspose.Slides" et que l'effet **Random Bars** soit appliqué à la forme.  

![Effet d'animation de forme de diapositive](slide-shape-animation.png)

Supposons également que l'effet **Split** soit appliqué à l'espace réservé du pied de page sur la diapositive **layout**.  

![Effet d'animation de forme de mise en page](layout-shape-animation.png)

Et enfin, l'effet **Fly In** est appliqué à l'espace réservé du pied de page sur la diapositive **master**.  

![Effet d'animation de forme de maître](master-shape-animation.png)

Le code d'exemple suivant montre comment utiliser la méthode `getBasePlaceholder` de l'interface [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) pour accéder aux espaces réservés de la forme et obtenir les effets d'animation appliqués à la forme de pied de page, y compris ceux hérités des espaces réservés situés sur les diapositives layout et master.  
```java
Presentation presentation = new Presentation("sample.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

// Get animation effects of the shape on the normal slide.
IShape shape = slide.getShapes().get_Item(0);
IEffect[] shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// Get animation effects of the placeholder on the layout slide.
IShape layoutShape = shape.getBasePlaceholder();
IEffect[] layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// Get animation effects of the placeholder on the master slide.
IShape masterShape = layoutShape.getBasePlaceholder();
IEffect[] masterShapeEffects = slide.getLayoutSlide().getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(masterShape);

System.out.println("Main sequence of shape effects:");
printEffects(masterShapeEffects);
printEffects(layoutShapeEffects);
printEffects(shapeEffects);

presentation.dispose();
```
  
```java
static void printEffects(IEffect[] effects)
{
    for (IEffect effect : effects)
    {
        String typeName = EffectType.getName(EffectType.class, effect.getType());
        String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());

        System.out.println(typeName + " " + subtypeName);
    }
}
```


```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```


## **Modifier les propriétés de synchronisation des effets d'animation**

Aspose.Slides pour Android via Java vous permet de modifier les propriétés de synchronisation d'un effet d'animation.

Voici le volet de synchronisation d'animation dans Microsoft PowerPoint :  
![exemple1_image](shape-animation.png)

Voici les correspondances entre la synchronisation PowerPoint et les propriétés [Effect.Timing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IEffect#getTiming--) :

- La liste déroulante **Start** de la synchronisation PowerPoint correspond à la propriété [Effect.Timing.TriggerType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiming#getTriggerType--).  
- La **Duration** de la synchronisation PowerPoint correspond à la propriété [Effect.Timing.Duration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiming#getDuration--). La durée d'une animation (en secondes) est le temps total que l'animation met pour compléter un cycle.  
- Le **Delay** de la synchronisation PowerPoint correspond à la propriété [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITiming#getTriggerDelayTime--).

Voici comment modifier les propriétés de synchronisation de l'effet :

1. [Apply](#apply-animation-to-shape) ou obtenez l'effet d'animation.  
2. Définissez de nouvelles valeurs pour les propriétés [Effect.Timing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IEffect#getTiming--) dont vous avez besoin.  
3. Enregistrez le fichier PPTX modifié.  

Ce code Java démontre l'opération :  
```java
// Instancie une classe de présentation qui représente un fichier de présentation.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Récupère la séquence principale de la diapositive.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Récupère le premier effet de la séquence principale.
    IEffect effect = sequence.get_Item(0);

    // Modifie le TriggerType de l'effet pour démarrer au clic
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick);

    // Modifie la durée de l'effet
    effect.getTiming().setDuration(3f);

    // Modifie le temps de délai de déclenchement de l'effet
    effect.getTiming().setTriggerDelayTime(0.5f);

    // Enregistre le fichier PPTX sur le disque
    pres.save("AnimExample_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Son d'effet d'animation**

Aspose.Slides fournit ces propriétés pour vous permettre de travailler avec les sons dans les effets d'animation :

- [setSound(IAudio value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)  
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effect/#setStopPreviousSound-boolean-)

### **Ajouter un son d'effet d'animation**

Ce code Java montre comment ajouter un son d'effet d'animation et l'arrêter lorsque l'effet suivant démarre :  
```java
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Ajoute l'audio à la collection audio de la présentation
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Récupère la séquence principale de la diapositive.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Récupère le premier effet de la séquence principale.
    IEffect firstEffect = sequence.get_Item(0);

    // Vérifie si l'effet n'a pas de son
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // Ajoute le son au premier effet
        firstEffect.setSound(effectSound);
    }

    // Récupère la première séquence interactive de la diapositive.
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // Définit le drapeau "Arrêter le son précédent" de l'effet
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // Enregistre le fichier PPTX sur le disque
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


### **Extraire un son d'effet d'animation**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/aspose.slides/presentation/).  
2. Obtenez une référence de diapositive via son indice.  
3. Récupérez la séquence principale d'effets.  
4. Extrayez le [setSound(IAudio value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) incorporé à chaque effet d'animation.  

Ce code Java montre comment extraire le son incorporé dans un effet d'animation :  
```java
// Instancie une classe de présentation qui représente un fichier de présentation.
Presentation presentation = new Presentation("EffectSound.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Récupère la séquence principale de la diapositive.
    ISequence sequence = slide.getTimeline().getMainSequence();

    for (IEffect effect : sequence)
    {
        if (effect.getSound() == null)
            continue;

        // Extrait le son de l'effet sous forme de tableau d'octets
        byte[] audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **Après l'animation**

Aspose.Slides pour Android via Java vous permet de modifier la propriété After animation d'un effet d'animation.

Voici le volet d'effet d'animation et le menu étendu dans Microsoft PowerPoint :  
![example1_image](shape-after-animation.png)

Le menu déroulant **After animation** de PowerPoint correspond aux propriétés suivantes :

- La propriété [setAfterAnimationType(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAfterAnimationType-int-) décrit le type After animation :
  * PowerPoint **More Colors** correspond au type [AfterAnimationType.Color](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#Color);
  * PowerPoint **Don't Dim** correspond à l'option [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#DoNotDim) (type d'animation après défaut);
  * PowerPoint **Hide After Animation** correspond au type [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#HideAfterAnimation);
  * PowerPoint **Hide on Next Mouse Click** correspond au type [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick);
- La propriété [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) définit un format de couleur After animation. Cette propriété fonctionne conjointement avec le type [AfterAnimationType.Color](https://reference.aspose.com/slides/androidjava/com.aspose.slides/afteranimationtype/#Color). Si vous changez le type, la couleur After animation sera réinitialisée.  

Ce code Java montre comment modifier un effet After animation :  
```java
// Instancie une classe de présentation qui représente un fichier de présentation
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Récupère le premier effet de la séquence principale
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Modifie le type d'animation après en Couleur
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // Définit la couleur d'assombrissement après l'animation
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // Enregistre le fichier PPTX sur le disque
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Animer le texte**

Aspose.Slides fournit ces propriétés pour vous permettre de travailler avec le bloc *Animate text* d'un effet d'animation :

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) décrit le type d'animation du texte de l'effet. Le texte de la forme peut être animé :
  * Tout en une fois ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/androidjava/com.aspose.slides/animatetexttype/#AllAtOnce) type)  
  * Par mot ([AnimateTextType.ByWord](https://reference.aspose.com/slides/androidjava/com.aspose.slides/animatetexttype/#ByWord) type)  
  * Par lettre ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/animatetexttype/#ByLetter) type)  
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) définit un délai entre les parties du texte animé (mots ou lettres). Une valeur positive indique le pourcentage de la durée de l'effet. Une valeur négative indique le délai en secondes.  

Voici comment vous pouvez modifier les propriétés Animate text de l'effet :

1. [Apply](#apply-animation-to-shape) ou obtenez l'effet d'animation.  
2. Définissez la propriété [setBuildType(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextanimation/#setBuildType-int-) sur la valeur [BuildType.AsOneObject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/buildtype/#AsOneObject) pour désactiver le mode d'animation *By Paragraphs*.  
3. Définissez de nouvelles valeurs pour les propriétés [setAnimateTextType(int value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) et [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-).  
4. Enregistrez le fichier PPTX modifié.  

Ce code Java démontre l'opération :  
```java
// Instancie une classe de présentation qui représente un fichier de présentation.
Presentation pres = new Presentation("AnimTextBox_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Récupère le premier effet de la séquence principale
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Modifie le type d'animation du texte de l'effet en "As One Object"
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // Modifie le type d'animation du texte de l'effet en "By word"
    firstEffect.setAnimateTextType(AnimateTextType.ByWord);

    // Définit le délai entre les mots à 20% de la durée de l'effet
    firstEffect.setDelayBetweenTextParts(20f);

    // Enregistre le fichier PPTX sur le disque
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Comment garantir que les animations sont conservées lors de la publication de la présentation sur le web ?**  

[Export to HTML5](/slides/fr/androidjava/export-to-html5/) et activez les [options](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/) responsables des animations de [shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) et de [transition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-). Le HTML simple ne joue pas les animations de diapositive, alors que le HTML5 le fait.  

**Comment la modification de l'ordre Z (ordre des calques) des formes affecte-t-elle l'animation ?**  

L'ordre d'animation et l'ordre de dessin sont indépendants : un effet contrôle le timing et le type d'apparition/disparition, tandis que l'[z-order](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getZOrderPosition--) détermine ce qui recouvre quoi. Le résultat visible est défini par leur combinaison. (Ceci est le comportement général de PowerPoint ; le modèle effets‑et‑formes d'Aspose.Slides suit la même logique.)  

**Existe-t-il des limitations lors de la conversion des animations en vidéo pour certains effets ?**  

En général, les [animations sont prises en charge](/slides/fr/androidjava/convert-powerpoint-to-video/), mais des cas rares ou des effets spécifiques peuvent être rendus différemment. Il est recommandé de tester avec les effets que vous utilisez et avec la version de la bibliothèque.