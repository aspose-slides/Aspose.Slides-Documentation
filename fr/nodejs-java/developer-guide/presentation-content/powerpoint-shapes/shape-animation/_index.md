---
title: Animation de forme
type: docs
weight: 60
url: /fr/nodejs-java/shape-animation/
keywords:
- forme
- animation
- effet
- ajouter des effets
- obtenir des effets
- extraire des effets
- appliquer une animation
- PowerPoint
- présentation
- Node.js
- Java
- Aspose.Slides for Node.js via Java
description: "Appliquer une animation PowerPoint en JavaScript"
---

Les animations sont des effets visuels qui peuvent être appliqués aux textes, images, formes ou [graphes](/slides/fr/nodejs-java/animated-charts/). Elles donnent vie aux présentations ou à leurs constituants.

## **Pourquoi utiliser les animations dans les présentations ?**

* contrôler le flux d'informations
* mettre en évidence les points importants
* augmenter l'intérêt ou la participation du public
* rendre le contenu plus facile à lire, assimiler ou traiter
* attirer l'attention des lecteurs ou spectateurs sur les parties importantes d'une présentation

PowerPoint propose de nombreuses options et outils pour les animations et les effets d'animation dans les catégories **entrée**, **sortie**, **mise en valeur** et **chemins de mouvement**.

## **Animations dans Aspose.Slides**

* Aspose.Slides fournit les classes et types dont vous avez besoin pour travailler avec les animations dans l’espace de noms `Aspose.Slides.Animation`,
* Aspose.Slides propose plus de **150 effets d'animation** dans l’énumération [EffectType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effecttype). Ces effets sont essentiellement les mêmes (ou équivalents) que ceux utilisés dans PowerPoint.

## **Appliquer une animation à une zone de texte**

Aspose.Slides for Node.js via Java vous permet d’appliquer une animation au texte d’une forme.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Obtenez une référence de diapositive via son index.
3. Ajoutez une [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape) de type `rectangle`.
4. Ajoutez du texte en utilisant [AutoShape.addTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-).
5. Récupérez la séquence principale d’effets.
6. Ajoutez un effet d’animation à la [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape).
7. Appelez la méthode `TextAnimation.setBuildType` avec la valeur de l’énumération `BuildType`.
8. Enregistrez la présentation sur le disque au format PPTX.

Ce code Javascript vous montre comment appliquer l’effet `Fade` à l’AutoShape et définir l’animation du texte sur la valeur *Par paragraphes de premier niveau* :
```javascript
// Instancie une classe de présentation qui représente un fichier de présentation.
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    // Ajoute une nouvelle AutoShape avec du texte
    var autoShape = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 100);
    var textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");
    // Obtient la séquence principale de la diapositive.
    var sequence = sld.getTimeline().getMainSequence();
    // Ajoute l'effet d'animation Fade à la forme
    var effect = sequence.addEffect(autoShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    // Anime le texte de la forme par paragraphes de premier niveau
    effect.getTextAnimation().setBuildType(aspose.slides.BuildType.ByLevelParagraphs1);
    // Enregistre le fichier PPTX sur le disque
    pres.save(path + "AnimText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{%  alert color="primary"  %}} 
En plus d’appliquer des animations au texte, vous pouvez également appliquer des animations à un seul [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph). Voir [**Texte animé**](/slides/fr/nodejs-java/animated-text/).
{{% /alert %}} 

## **Appliquer une animation à un PictureFrame**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Obtenez une référence de diapositive via son index.
3. Ajoutez ou récupérez un [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe) sur la diapositive.
4. Récupérez la séquence principale d’effets.
5. Ajoutez un effet d’animation au [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe).
6. Enregistrez la présentation sur le disque au format PPTX.

Ce code Javascript montre comment appliquer l’effet `Fly` à un cadre d’image :
```javascript
// Instancie une classe de présentation qui représente un fichier de présentation.
var pres = new aspose.slides.Presentation();
try {
    // Charge l'image à ajouter à la collection d'images de la présentation
    var picture;
    var image = aspose.slides.Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Ajoute un cadre d'image à la diapositive
    var picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 100, picture);
    // Obtient la séquence principale de la diapositive.
    var sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    // Ajoute l'effet d'animation Fly depuis la gauche au cadre d'image
    var effect = sequence.addEffect(picFrame, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.Left, aspose.slides.EffectTriggerType.OnClick);
    // Enregistre le fichier PPTX sur le disque
    pres.save(path + "AnimImage_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Appliquer une animation à une forme**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Obtenez une référence de diapositive via son index.
3. Ajoutez une [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape) de type `rectangle`.
4. Ajoutez une [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape) de type `Bevel` (lorsque cet objet est cliqué, l’animation est lue).
5. Créez une séquence d’effets sur la forme Bevel.
6. Créez un `UserPath` personnalisé.
7. Ajoutez des commandes pour se déplacer vers le `UserPath`.
8. Enregistrez la présentation sur le disque au format PPTX.

```javascript
// Instancie une classe Presentation qui représente un fichier PPTX.
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    // Crée l'effet PathFootball pour la forme existante à partir de zéro.
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");
    // Ajoute l'effet d'animation PathFootBall
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, aspose.slides.EffectType.PathFootball, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    // Crée une sorte de "bouton".
    var shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Bevel, 10, 10, 20, 20);
    // Crée une séquence d'effets pour ce bouton.
    var seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);
    // Crée un chemin utilisateur personnalisé. Notre objet ne sera déplacé qu'après le clic sur le bouton.
    var fxUserPath = seqInter.addEffect(ashp, aspose.slides.EffectType.PathUser, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    // Ajoute des commandes de déplacement car le chemin créé est vide.
    var motionBhv = fxUserPath.getBehaviors().get_Item(0);
    var pts = java.newArray("com.aspose.slides.Point2DFloat", [java.newInstanceSync("com.aspose.slides.Point2DFloat", 0.076, 0.59)]);
    motionBhv.getPath().add(aspose.slides.MotionCommandPathType.LineTo, pts, aspose.slides.MotionPathPointsType.Auto, true);
    pts[0] = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(-0.076), java.newFloat(-0.59));
    motionBhv.getPath().add(aspose.slides.MotionCommandPathType.LineTo, pts, aspose.slides.MotionPathPointsType.Auto, false);
    motionBhv.getPath().add(aspose.slides.MotionCommandPathType.End, null, aspose.slides.MotionPathPointsType.Auto, false);
    // Écrit le fichier PPTX sur le disque
    pres.save("AnimExample_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Obtenir les effets d'animation appliqués à une forme**

Les exemples suivants vous montrent comment utiliser la méthode `getEffectsByShape` de la classe [Sequence](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sequence/) pour obtenir tous les effets d’animation appliqués à une forme.

**Exemple 1 : Obtenir les effets d’animation appliqués à une forme sur une diapositive normale**

Auparavant, vous avez appris comment ajouter des effets d’animation aux formes dans les présentations PowerPoint. Le code d’exemple suivant vous montre comment récupérer les effets appliqués à la première forme de la première diapositive normale de la présentation `AnimExample_out.pptx`.
```javascript
var presentation = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    var firstSlide = presentation.getSlides().get_Item(0);

    // Obtient la séquence principale d'animation de la diapositive.
    var sequence = firstSlide.getTimeline().getMainSequence();

    // Obtient la première forme de la première diapositive.
    var shape = firstSlide.getShapes().get_Item(0);

    // Obtient les effets d'animation appliqués à la forme.
    var shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0) {
        console.log("The shape", shape.getName(), "has", shapeEffects.length, "animation effects.");
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


**Exemple 2 : Obtenir tous les effets d’animation, y compris ceux hérités des espaces réservés**

Si une forme sur une diapositive normale possède des espaces réservés qui se trouvent sur la diapositive de mise en page et/ou la diapositive maître, et que des effets d’animation ont été ajoutés à ces espaces réservés, alors tous les effets de la forme seront exécutés pendant le diaporama, y compris ceux hérités des espaces réservés.

Supposons que nous ayons un fichier de présentation PowerPoint `sample.pptx` contenant une seule diapositive avec uniquement une forme de pied de page portant le texte « Made with Aspose.Slides » et que l’effet **Random Bars** soit appliqué à la forme.

![Slide shape animation effect](slide-shape-animation.png)

Supposons également que l’effet **Split** soit appliqué à l’espace réservé du pied de page sur la diapositive **layout**.

![Layout shape animation effect](layout-shape-animation.png)

Et enfin, que l’effet **Fly In** soit appliqué à l’espace réservé du pied de page sur la diapositive **master**.

![Master shape animation effect](master-shape-animation.png)

Le code d’exemple suivant montre comment utiliser la méthode `getBasePlaceholder` de la classe [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) pour accéder aux espaces réservés de la forme et obtenir les effets d’animation appliqués à la forme du pied de page, y compris ceux hérités des espaces réservés situés sur les diapositives de mise en page et maîtres.
```js
var presentation = new aspose.slides.Presentation("sample.pptx");

var slide = presentation.getSlides().get_Item(0);

// Get animation effects of the shape on the normal slide.
var shape = slide.getShapes().get_Item(0);
var shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// Get animation effects of the placeholder on the layout slide.
var layoutShape = shape.getBasePlaceholder();
var layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// Get animation effects of the placeholder on the master slide.
var masterShape = layoutShape.getBasePlaceholder();
var masterShapeEffects = slide.getLayoutSlide().getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(masterShape);

console.log("Main sequence of shape effects:");
printEffects(masterShapeEffects);
printEffects(layoutShapeEffects);
printEffects(shapeEffects);

presentation.dispose();
```

```js
function printEffects(effects) {
    for (const effect of effects) {
        console.log("Type:", effect.getType() + ", subtype:", effect.getSubtype());
    }
}
```


Output:
```text
Main sequence of shape effects:
Type: 47, subtype: 2              // Vol, Bas
Type: 134, subtype: 45            // Division, VerticalEntrée
Type: 126, subtype: 22            // BarresAléatoires, Horizontale
```


## **Modifier les propriétés de chronométrage d’un effet d'animation**

Aspose.Slides for Node.js via Java vous permet de modifier les propriétés de chronométrage d’un effet d’animation.

Ceci est le volet Chronométrage d’animation dans Microsoft PowerPoint :

![example1_image](shape-animation.png)

Ces correspondances entre le chronométrage PowerPoint et les propriétés [Effect.Timing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Effect#getTiming--) :

- La liste déroulante **Start** du chronométrage PowerPoint correspond à la propriété [Effect.Timing.TriggerType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Timing#getTriggerType--).
- La zone **Duration** du chronométrage PowerPoint correspond à la propriété [Effect.Timing.Duration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Timing#getDuration--). La durée d’une animation (en secondes) est le temps total nécessaire pour qu’une animation termine un cycle.
- La zone **Delay** du chronométrage PowerPoint correspond à la propriété [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Timing#getTriggerDelayTime--).

Voici comment modifier les propriétés de chronométrage de l’effet :

1. [Appliquer](#apply-animation-to-shape) ou récupérer l’effet d’animation.
2. Définissez de nouvelles valeurs pour les propriétés [Effect.Timing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Effect#getTiming--) dont vous avez besoin.
3. Enregistrez le fichier PPTX modifié.

```javascript
// Instancie une classe de présentation qui représente un fichier de présentation.
var pres = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    // Obtient la séquence principale de la diapositive.
    var sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    // Obtient le premier effet de la séquence principale.
    var effect = sequence.get_Item(0);
    // Modifie le TriggerType de l'effet pour démarrer au clic
    effect.getTiming().setTriggerType(aspose.slides.EffectTriggerType.OnClick);
    // Modifie la durée de l'effet
    effect.getTiming().setDuration(3.0);
    // Modifie le TriggerDelayTime de l'effet
    effect.getTiming().setTriggerDelayTime(0.5);
    // Enregistre le fichier PPTX sur le disque
    pres.save("AnimExample_changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Son d’un effet d’animation**

Aspose.Slides fournit ces propriétés pour travailler avec les sons dans les effets d’animation :

- [setSound(IAudio value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effect/#setSound-aspose.slides.IAudio-)
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effect/#setStopPreviousSound-boolean-)

### **Ajouter un son à un effet d’animation**

Ce code Javascript montre comment ajouter un son à un effet d’animation et l’arrêter lorsque l’effet suivant démarre :
```javascript
var pres = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    // Ajoute un audio à la collection audio de la présentation
    var effectSound = pres.getAudios().addAudio(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "sampleaudio.wav")));
    var firstSlide = pres.getSlides().get_Item(0);
    // Obtient la séquence principale de la diapositive.
    var sequence = firstSlide.getTimeline().getMainSequence();
    // Obtient le premier effet de la séquence principale
    var firstEffect = sequence.get_Item(0);
    // Vérifie si l'effet n'a aucun son
    if ((!firstEffect.getStopPreviousSound()) && (firstEffect.getSound() == null)) {
        // Ajoute un son pour le premier effet
        firstEffect.setSound(effectSound);
    }
    // Obtient la première séquence interactive de la diapositive.
    var interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);
    // Définit le drapeau "Stop previous sound" de l'effet
    interactiveSequence.get_Item(0).setStopPreviousSound(true);
    // Écrit le fichier PPTX sur le disque
    pres.save("AnimExample_Sound_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **Extraire le son d’un effet d’animation**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Obtenez une référence de diapositive via son index.
3. Récupérez la séquence principale d’effets.
4. Extrayez le [setSound(IAudio value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effect/#setSound-aspose.slides.IAudio-) incorporé à chaque effet d’animation.

```javascript
// Instancie une classe de présentation qui représente un fichier de présentation.
var presentation = new aspose.slides.Presentation("EffectSound.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    // Obtient la séquence principale de la diapositive.
    var sequence = slide.getTimeline().getMainSequence();
    for (var i = 0; i < sequence.getCount(); i++) {
        var effect = sequence.get_Item(i);
        if (effect.getSound() == null) {
            continue;
        }
        // Extrait le son de l'effet sous forme de tableau d'octets
        var audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **Après l’animation**

Aspose.Slides for Node.js via Java vous permet de modifier la propriété Après animation d’un effet d’animation.

Ceci est le volet Effet d’animation et le menu étendu dans Microsoft PowerPoint :

![example1_image](shape-after-animation.png)

Le menu déroulant **After animation** de PowerPoint correspond à ces propriétés :

- [setAfterAnimationType(int value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effect/#setAfterAnimationType-int-) qui décrit le type d’après animation :
  * PowerPoint **More Colors** correspond au type [AfterAnimationType.Color](https://reference.aspose.com/slides/nodejs-java/aspose.slides/afteranimationtype/#Color) ;
  * PowerPoint **Don't Dim** correspond au type [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/nodejs-java/aspose.slides/afteranimationtype/#DoNotDim) (type d’après animation par défaut) ;
  * PowerPoint **Hide After Animation** correspond au type [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/afteranimationtype/#HideAfterAnimation) ;
  * PowerPoint **Hide on Next Mouse Click** correspond au type [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/afteranimationtype/#HideOnNextMouseClick) ;
- [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effect/#setAfterAnimationColor-aspose.slides.IColorFormat-) qui définit un format de couleur après animation. Cette méthode fonctionne conjointement avec le type [AfterAnimationType.Color](https://reference.aspose.com/slides/nodejs-java/aspose.slides/afteranimationtype/#Color). Si vous changez le type, la couleur après animation sera réinitialisée.

```javascript
// Instancie une classe de présentation qui représente un fichier de présentation
var pres = new aspose.slides.Presentation("AnimImage_out.pptx");
try {
    var firstSlide = pres.getSlides().get_Item(0);
    // Obtient le premier effet de la séquence principale
    var firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);
    // Modifie le type d'animation après en Couleur
    firstEffect.setAfterAnimationType(aspose.slides.AfterAnimationType.Color);
    // Définit la couleur d'atténuation après l'animation
    firstEffect.getAfterAnimationColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    // Enregistre le fichier PPTX sur le disque
    pres.save("AnimImage_AfterAnimation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Animer le texte**

Aspose.Slides fournit ces propriétés pour travailler avec le bloc *Animate text* d’un effet d’animation :

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effect/#setAnimateTextType-int-) qui décrit le type d’animation du texte de l’effet. Le texte de la forme peut être animé :
  - Tout d’un coup ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/nodejs-java/aspose.slides/animatetexttype/#AllAtOnce))
  - Par mot ([AnimateTextType.ByWord](https://reference.aspose.com/slides/nodejs-java/aspose.slides/animatetexttype/#ByWord))
  - Par lettre ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/animatetexttype/#ByLetter))
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effect/#setDelayBetweenTextParts-float-) définit un délai entre les parties de texte animées (mots ou lettres). Une valeur positive indique le pourcentage de la durée de l’effet. Une valeur négative indique le délai en secondes.

Voici comment modifier les propriétés d’animation du texte :

1. [Appliquer](#apply-animation-to-shape) ou récupérer l’effet d’animation.
2. Appelez la méthode [setBuildType(int value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textanimation/#setBuildType-int-) avec la valeur [BuildType.AsOneObject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/buildtype/#AsOneObject) pour désactiver le mode d’animation *Par paragraphes*.
3. Définissez de nouvelles valeurs pour les propriétés [setAnimateTextType(int value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effect/#setAnimateTextType-int-) et [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effect/#setDelayBetweenTextParts-float-).
4. Enregistrez le fichier PPTX modifié.

```javascript
// Instancie une classe de présentation qui représente un fichier de présentation.
var pres = new aspose.slides.Presentation("AnimTextBox_out.pptx");
try {
    var firstSlide = pres.getSlides().get_Item(0);
    // Obtient le premier effet de la séquence principale
    var firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);
    // Modifie le type d'animation du texte de l'effet à "As One Object"
    firstEffect.getTextAnimation().setBuildType(aspose.slides.BuildType.AsOneObject);
    // Modifie le type d'animation du texte de l'effet à "By word"
    firstEffect.setAnimateTextType(aspose.slides.AnimateTextType.ByWord);
    // Définit le délai entre les mots à 20% de la durée de l'effet
    firstEffect.setDelayBetweenTextParts(20.0);
    // Enregistre le fichier PPTX sur le disque
    pres.save("AnimTextBox_AnimateText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Comment garantir que les animations sont conservées lors de la publication de la présentation sur le web ?**

[Export to HTML5](/slides/fr/nodejs-java/export-to-html5/) et activez les [options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/) responsables des animations de [forme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/setanimateshapes/) et de [transition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/setanimatetransitions/). Le HTML simple ne lit pas les animations de diapositive, alors que le HTML5 le fait.

**Comment la modification de l’ordre Z (ordre des calques) des formes affecte-t-elle les animations ?**

L’ordre d’animation et l’ordre de dessin sont indépendants : un effet contrôle le chronométrage et le type d’apparition/disparition, tandis que le [z-order](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getzorderposition/) détermine ce qui recouvre quoi. Le résultat visuel est défini par leur combinaison. (C’est le comportement général de PowerPoint ; le modèle effets‑et‑formes d’Aspose.Slides suit la même logique.)

**Existe‑t‑il des limitations lors de la conversion des animations en vidéo pour certains effets ?**

En général, les [animations sont prises en charge](/slides/fr/nodejs-java/convert-powerpoint-to-video/), mais des cas rares ou des effets spécifiques peuvent être rendus différemment. Il est recommandé de tester avec les effets que vous utilisez et avec la version de la bibliothèque.