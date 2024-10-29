---
title: Animation de Forme
type: docs
weight: 60
url: /fr/python-net/shape-animation/
keywords: "animation PowerPoint, présentation PowerPoint, Python, Aspose.Slides pour Python via .NET"
description: "Créer une animation PowerPoint en Python"
---

Les animations sont des effets visuels qui peuvent être appliqués aux textes, images, formes ou [graphiques](/slides/fr/python-net/animated-charts/). Elles donnent vie aux présentations ou à leurs éléments.

### **Pourquoi utiliser des animations dans les présentations ?**

En utilisant des animations, vous pouvez 

* contrôler le flux d'information
* souligner des points importants
* augmenter l'intérêt ou la participation de votre audience
* rendre le contenu plus facile à lire, assimiler ou traiter
* attirer l'attention de vos lecteurs ou spectateurs sur des parties importantes d'une présentation

PowerPoint offre de nombreuses options et outils pour les animations et les effets d'animation dans les catégories **entrée**, **sortie**, **accentuation** et **chemins de mouvement**.

### **Animations dans Aspose.Slides**

* Aspose.Slides fournit les classes et types nécessaires pour travailler avec des animations sous le namespace [Aspose.Slides.Animation](https://reference.aspose.com/slides/python-net/aspose.slides.animation/),
* Aspose.Slides propose plus de **150 effets d'animation** sous l'énumération [EffectType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttype/). Ces effets sont essentiellement les mêmes (ou équivalents) que ceux utilisés dans PowerPoint.

## **Appliquer une animation à un TextBox**

Aspose.Slides pour Python via .NET permet d'appliquer une animation au texte dans une forme. 

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenez la référence d'une diapositive via son index.
3. Ajoutez une `rectangle` [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/). 
4. Ajoutez du texte à `IAutoShape.TextFrame`.
5. Obtenez une séquence principale d'effets.
6. Ajoutez un effet d'animation à [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/). 
7. Définissez la propriété `TextAnimation.BuildType` sur la valeur de l'énumération `BuildType`.
8. Écrivez la présentation sur le disque en tant que fichier PPTX.

Ce code Python montre comment appliquer l'effet `Fade` à AutoShape et définir l'animation du texte sur la valeur *Par 1er Niveau de Paragraphes* :

```python
import aspose.slides as slides

# Instancie une classe de présentation qui représente un fichier de présentation.
with slides.Presentation() as pres:
    sld = pres.slides[0]
    
    # Ajoute une nouvelle AutoShape avec du texte
    autoShape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 100)

    textFrame = autoShape.text_frame
    textFrame.text = "Premier paragraphe \nDeuxième paragraphe \n Troisième paragraphe"

    # Obtient la séquence principale de la diapositive.
    sequence = sld.timeline.main_sequence

    # Ajoute un effet d'animation Fade à la forme
    effect = sequence.add_effect(autoShape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    # Anime le texte de la forme par les 1ers niveaux de paragraphes
    effect.text_animation.build_type = slides.animation.BuildType.BY_LEVEL_PARAGRAPHS1

    # Sauvegarde le fichier PPTX sur le disque
    pres.save("AnimText_out.pptx", slides.export.SaveFormat.PPTX)
```

{{%  alert color="primary"  %}} 

En plus d'appliquer des animations au texte, vous pouvez également appliquer des animations à un seul [Paragraphe](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraph/). Voir [**Texte Animé**](/slides/fr/python-net/animated-text/).

{{% /alert %}} 

## **Appliquer une animation à PictureFrame**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenez la référence d'une diapositive via son index.
3. Ajoutez ou obtenez un [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) sur la diapositive. 
4. Obtenez la séquence principale d'effets.
5. Ajoutez un effet d'animation à [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/).
6. Écrivez la présentation sur le disque en tant que fichier PPTX.

Ce code Python montre comment appliquer l'effet `Fly` à un cadre d'image :

```python
import aspose.slides as slides
import aspose.pydrawing as draw


# Instancie une classe de présentation qui représente un fichier de présentation.
with slides.Presentation() as pres:
    # Charge l'image à ajouter dans la collection d'images de la présentation
    img = draw.Bitmap("aspose-logo.jpg")
    image = pres.images.add_image(img)

    # Ajoute un cadre d'image à la diapositive
    picFrame = pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

    # Obtient la séquence principale de la diapositive.
    sequence = pres.slides[0].timeline.main_sequence

    # Ajoute un effet d'animation Fly from Left au cadre d'image
    effect = sequence.add_effect(picFrame, slides.animation.EffectType.FLY,  
        slides.animation.EffectSubtype.LEFT, 
        slides.animation.EffectTriggerType.ON_CLICK)

    # Sauvegarde le fichier PPTX sur le disque
    pres.save("AnimImage_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Appliquer une animation à une forme**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenez la référence d'une diapositive via son index.
3. Ajoutez une `rectangle` [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/). 
4. Ajoutez une `Bevel` [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) (quand cet objet est cliqué, l'animation est jouée).
5. Créez une séquence d'effets sur la forme bevel.
6. Créez un `UserPath` personnalisé.
7. Ajoutez des commandes pour se déplacer vers le `UserPath`.
8. Écrivez la présentation sur le disque en tant que fichier PPTX.

Ce code Python montre comment appliquer l'effet `PathFootball` à une forme :

```python
import aspose.slides.animation as anim
import aspose.slides as slides
import aspose.pydrawing as draw

# Instancie une classe de présentation qui représente un fichier PPTX
with slides.Presentation() as pres:
    sld = pres.slides[0]

    # Crée l'effet PathFootball pour la forme existante à partir de zéro.
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 250, 25)

    ashp.add_text_frame("Texte É animé")

    # Ajoute l'effet d'animation PathFootBall.
    pres.slides[0].timeline.main_sequence.add_effect(ashp, 
        anim.EffectType.PATH_FOOTBALL,
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    # Crée une sorte de "bouton".
    shapeTrigger = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.BEVEL, 10, 10, 20, 20)

    # Crée une séquence d'effets pour le bouton.
    seqInter = pres.slides[0].timeline.interactive_sequences.add(shapeTrigger)

    # Crée un chemin utilisateur personnalisé. Notre objet ne sera déplacé qu'après que le bouton ait été cliqué.
    fxUserPath = seqInter.add_effect(ashp, 
        anim.EffectType.PATH_USER, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.ON_CLICK)

    # Ajoute des commandes pour se déplacer puisque le chemin créé est vide.
    motionBhv = fxUserPath.behaviors[0]

    pts = [draw.PointF(0.076, 0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, True)
    pts = [draw.PointF(-0.076, -0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, False)
    motionBhv.path.add(anim.MotionCommandPathType.END, None, anim.MotionPathPointsType.AUTO, False)

    # Écrit le fichier PPTX sur le disque
    pres.save("AnimExample_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Obtenir les effets d'animation appliqués à une forme**

Vous pouvez décider de découvrir tous les effets d'animation appliqués à une seule forme. 

Ce code Python montre comment obtenir tous les effets appliqués à une forme spécifique :

```python
import aspose.slides as slides

# Instancie une classe de présentation qui représente un fichier de présentation.
with slides.Presentation("AnimExample_out.pptx") as pres:
    firstSlide = pres.slides[0]

    # Obtient la séquence principale de la diapositive.
    sequence = firstSlide.timeline.main_sequence

    # Obtient la première forme sur la diapositive.
    shape = firstSlide.shapes[0]

    # Obtient tous les effets d’animation appliqués à la forme.
    shapeEffects = sequence.get_effects_by_shape(shape)

    if len(shapeEffects) > 0:
        print("La forme " + shape.name + " a " + str(len(shapeEffects)) + " effets d'animation.")
```

## **Modifier les propriétés de timing de l'effet d'animation**

Aspose.Slides pour Python via .NET vous permet de modifier les propriétés de Timing d'un effet d'animation.

Voici le panneau de Timing d'animation dans Microsoft PowerPoint :

![example1_image](shape-animation.png)

Voici les correspondances entre le Timing PowerPoint et les propriétés `Effect.Timing` :

- La liste déroulante de démarrage **Timing** de PowerPoint correspond à la propriété [Effect.Timing.TriggerType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttriggertype/). 
- La **Durée** de Timing de PowerPoint correspond à la propriété `Effect.Timing.Duration`. La durée d'une animation (en secondes) est le temps total nécessaire pour que l'animation complète un cycle. 
- Le **Délai** de Timing de PowerPoint correspond à la propriété `Effect.Timing.TriggerDelayTime`. 

Voici comment modifier les propriétés de Timing d'effet :

1. [Appliquez](#appliquer-une-animation-à-une-forme) ou obtenez l'effet d'animation.
2. Définissez de nouvelles valeurs pour les propriétés `Effect.Timing` dont vous avez besoin. 
3. Sauvegardez le fichier PPTX modifié.

Ce code Python illustre l'opération :

```python
import aspose.slides as slides

# Instancie une classe de présentation qui représente un fichier de présentation.
with slides.Presentation("AnimExample_out.pptx") as pres:
    # Obtient la séquence principale de la diapositive.
    sequence = pres.slides[0].timeline.main_sequence

    # Obtient le premier effet de la séquence principale.
    effect = sequence[0]

    # Change le trigger d'effet pour qu'il commence au clic
    effect.timing.trigger_type = slides.animation.EffectTriggerType.ON_CLICK

    # Change la durée de l'effet
    effect.timing.duration = 3

    # Change le TriggerDelayTime de l'effet
    effect.timing.trigger_delay_time = 0.5

    # Sauvegarde le fichier PPTX sur le disque
    pres.save("AnimExample_changed.pptx", slides.export.SaveFormat.PPTX)
```

## **Son de l'effet d'animation**

Aspose.Slides fournit ces propriétés pour vous permettre de travailler avec des sons dans les effets d'animation : 

- `sound`
- `stop_previous_sound`

### **Ajouter un son à l'effet d'animation**

Ce code Python montre comment ajouter un son à un effet d'animation et l'arrêter lorsque l'effet suivant commence :

```python
import aspose.slides as slides

with Presentation("AnimExample_out.pptx") as pres:
    # Ajoute un audio à la collection audio de la présentation
    effect_sound = pres.audios.add_audio(open("sampleaudio.wav", "rb").read())

    first_slide = pres.slides[0]

    # Obtient la séquence principale de la diapositive.
    sequence = first_slide.timeline.main_sequence

    # Obtient le premier effet de la séquence principale
    first_effect = sequence[0]

    # Vérifie l'effet pour "Pas de Son"
    if not first_effect.stop_previous_sound and first_effect.sound is None:
        # Ajoute un son pour le premier effet
        first_effect.sound = effect_sound

    # Obtient la première séquence interactive de la diapositive.
    interactive_sequence = first_slide.timeline.interactive_sequences[0]

    # Définit le flag "Arrêter le son précédent" de l'effet
    interactive_sequence[0].stop_previous_sound = True

    # Écrit le fichier PPTX sur le disque
    pres.save("AnimExample_Sound_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Extraire le son de l'effet d'animation**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenez la référence d'une diapositive via son index. 
3. Obtenez la séquence principale d'effets. 
4. Extrayez le `son` intégré à chaque effet d'animation. 

Ce code Python montre comment extraire le son intégré dans un effet d'animation :

```python
import aspose.slides as slides

# Instancie une classe de présentation qui représente un fichier de présentation.
with slides.Presentation("EffectSound.pptx") as presentation:
    slide = presentation.slides[0]

    # Obtient la séquence principale de la diapositive.
    sequence = slide.timeline.main_sequence

    for effect in sequence:
        if effect.sound is None:
            continue

        # Extrait le son d'effet en tableau d'octets
        audio = effect.sound.binary_data
```

## **Après l'animation**

Aspose.Slides pour .NET vous permet de modifier la propriété Après l'animation d'un effet d'animation.

Voici le panneau Effet d'animation et le menu étendu dans Microsoft PowerPoint :

![example1_image](shape-after-animation.png)

La liste déroulante **Après l'animation** de PowerPoint correspond à ces propriétés : 

- la propriété `after_animation_type` qui décrit le type d'après-animation :
  * Les **Plus de couleurs** de PowerPoint correspondent au type [COLOR](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) ;
  * L'élément de liste **Ne pas atténuer** de PowerPoint correspond au type [DO_NOT_DIM](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) (type d'après-animation par défaut) ;
  * L'élément **Cacher après animation** de PowerPoint correspond au type [HIDE_AFTER_ANIMATION](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) ;
  * L'élément **Cacher au prochain clic de souris** de PowerPoint correspond au type [HIDE_ON_NEXT_MOUSE_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) ;
- La propriété `after_animation_color` qui définit un format de couleur après animation. Cette propriété fonctionne en conjonction avec le type  [COLOR](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/). Si vous changez le type en un autre, la couleur après animation sera effacée.

Ce code Python montre comment modifier un effet d'après animation :

```python
import aspose.slides as slides

# Instancie une classe de présentation qui représente un fichier de présentation
with slides.Presentation("AnimImage_out.pptx") as pres:
    first_slide = pres.slides[0]

    # Obtient le premier effet de la séquence principale
    first_effect = first_slide.timeline.main_sequence[0]

    # Change le type d'après animation en Couleur
    first_effect.after_animation_type = AfterAnimationType.COLOR

    # Définit la couleur d'atténuation après animation
    first_effect.after_animation_color.color = Color.alice_blue

    # Écrit le fichier PPTX sur le disque
    pres.save("AnimImage_AfterAnimation.pptx", slides.export.SaveFormat.PPTX)
```

## **Animer le texte**

Aspose.Slides fournit ces propriétés pour vous permettre de travailler avec le bloc *Animer le texte* d'un effet d'animation :

- `animate_text_type` qui décrit un type d'animation de texte de l'effet. Le texte de la forme peut être animé :
  - Tout d'un coup ([ALL_AT_ONCE](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/) type)
  - Par mot ([BY_WORD](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/) type)
  - Par lettre ([BY_LETTER](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/) type)
- `delay_between_text_parts` définit un délai entre les parties de texte animées (mots ou lettres). Une valeur positive spécifie le pourcentage de durée de l'effet. Une valeur négative spécifie le délai en secondes.

Voici comment vous pouvez modifier les propriétés d'animation d'effet :

1. [Appliquez](#appliquer-une-animation-à-une-forme) ou obtenez l'effet d'animation.
2. Définissez la propriété `build_type` sur la valeur [AS_ONE_OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides.animation/buildtype/) pour désactiver le mode d'animation *Par Paragraphes*.
3. Définissez de nouvelles valeurs pour les propriétés `animate_text_type` et `delay_between_text_parts`.
4. Sauvegardez le fichier PPTX modifié.

Ce code Python démontre l'opération :

```python
import aspose.slides as slides

with slides.Presentation("AnimTextBox_out.pptx") as pres:
    first_slide = pres.slides[0]

    # Obtient le premier effet de la séquence principale
    first_effect = first_slide.timeline.main_sequence[0]

    # Change le type d'animation d'effet de texte à "En tant qu'un objet"
    first_effect.text_animation.build_type = slides.animation.BuildType.AS_ONE_OBJECT

    # Change le type d'animation d'effet de texte à "Par mot"
    first_effect.animate_text_type = slides.animation.AnimateTextType.BY_WORD

    # Définit le délai entre les mots à 20% de la durée de l'effet
    first_effect.delay_between_text_parts = 20

    # Écrit le fichier PPTX sur le disque
    pres.save("AnimTextBox_AnimateText.pptx", slides.export.SaveFormat.PPTX)

```