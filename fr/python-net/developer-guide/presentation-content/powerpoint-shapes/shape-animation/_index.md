---
title: Appliquer des animations de forme dans les présentations avec Python
linktitle: Animation de forme
type: docs
weight: 60
url: /fr/python-net/shape-animation/
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
- Python
- Aspose.Slides
description: "Découvrez comment créer et personnaliser des animations de forme dans les présentations PowerPoint et OpenDocument avec Aspose.Slides for Python via .NET. Démarquez-vous!"
---

Les animations sont des effets visuels qui peuvent être appliqués aux textes, aux images, aux formes ou aux [graphes](/slides/fr/python-net/animated-charts/). Elles donnent vie aux présentations ou à leurs constituants. 

## **Pourquoi utiliser les animations dans les présentations ?**

En utilisant les animations, vous pouvez 

* contrôler le flux d’informations
* mettre en avant les points importants
* augmenter l’intérêt ou la participation de votre public
* rendre le contenu plus facile à lire, assimiler ou traiter
* attirer l’attention de vos lecteurs ou spectateurs sur les parties importantes d’une présentation

PowerPoint propose de nombreuses options et outils pour les animations et les effets d’animation dans les catégories **entrée**, **sortie**, **mise en valeur** et **chemins de mouvement**. 

## **Animations dans Aspose.Slides**

* Aspose.Slides fournit les classes et les types nécessaires pour travailler avec les animations sous l’espace de noms [Aspose.Slides.Animation](https://reference.aspose.com/slides/python-net/aspose.slides.animation/) ,
* Aspose.Slides propose plus de **150 effets d’animation** sous l’énumération [EffectType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttype/). Ces effets sont essentiellement les mêmes (ou équivalents) que ceux utilisés dans PowerPoint.

## **Appliquer une animation à une zone de texte**

Aspose.Slides for Python via .NET vous permet d’appliquer une animation au texte d’une forme. 

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).  
2. Obtenez la référence d’une diapositive grâce à son indice.  
3. Ajoutez un `rectangle` [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/).  
4. Ajoutez du texte à `IAutoShape.TextFrame`.  
5. Récupérez la séquence principale d’effets.  
6. Ajoutez un effet d’animation à [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/).  
7. Définissez la propriété `TextAnimation.BuildType` sur la valeur issue de l’énumération `BuildType`.  
8. Enregistrez la présentation sur le disque au format PPTX.  

Ce code Python montre comment appliquer l’effet `Fade` à une AutoShape et définir l’animation du texte sur la valeur *Par paragraphes du premier niveau* :
```python
import aspose.slides as slides

# Crée une instance de la classe Presentation qui représente un fichier de présentation.
with slides.Presentation() as pres:
    sld = pres.slides[0]
    
    # Ajoute une nouvelle AutoShape avec du texte
    autoShape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 100)

    textFrame = autoShape.text_frame
    textFrame.text = "First paragraph \nSecond paragraph \n Third paragraph"

    # Obtient la séquence principale de la diapositive.
    sequence = sld.timeline.main_sequence

    # Ajoute l'effet d'animation Fade à la forme
    effect = sequence.add_effect(autoShape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    # Anime le texte de la forme par paragraphes de premier niveau
    effect.text_animation.build_type = slides.animation.BuildType.BY_LEVEL_PARAGRAPHS1

    # Enregistre le fichier PPTX sur le disque
    pres.save("AnimText_out.pptx", slides.export.SaveFormat.PPTX)
```


{{%  alert color="primary"  %}} 

En plus d’appliquer des animations au texte, vous pouvez également les appliquer à un seul [Paragraphe](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraph/). Consultez [**Texte animé**](/slides/fr/python-net/animated-text/).  

{{% /alert %}} 

## **Appliquer une animation à un PictureFrame**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).  
2. Obtenez la référence d’une diapositive grâce à son indice.  
3. Ajoutez ou récupérez un [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) sur la diapositive.  
4. Récupérez la séquence principale d’effets.  
5. Ajoutez un effet d’animation à [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/).  
6. Enregistrez la présentation sur le disque au format PPTX.  

Ce code Python montre comment appliquer l’effet `Fly` à un cadre image :
```python
import aspose.slides as slides
import aspose.pydrawing as draw


# Instancie une classe de présentation qui représente un fichier de présentation.
with slides.Presentation() as pres:
    # Charge l'image à ajouter à la collection d'images de la présentation
    img = draw.Bitmap("aspose-logo.jpg")
    image = pres.images.add_image(img)

    # Ajoute un cadre image à la diapositive
    picFrame = pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

    # Obtient la séquence principale de la diapositive.
    sequence = pres.slides[0].timeline.main_sequence

    # Ajoute l'effet d'animation Voler depuis la gauche au cadre image
    effect = sequence.add_effect(picFrame, slides.animation.EffectType.FLY,  
        slides.animation.EffectSubtype.LEFT, 
        slides.animation.EffectTriggerType.ON_CLICK)

    # Enregistre le fichier PPTX sur le disque
    pres.save("AnimImage_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Appliquer une animation à une forme**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).  
2. Obtenez la référence d’une diapositive grâce à son indice.  
3. Ajoutez un `rectangle` [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/).  
4. Ajoutez un `Bevel` [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) (lorsque cet objet est cliqué, l’animation se déclenche).  
5. Créez une séquence d’effets sur la forme en biseau.  
6. Créez un `UserPath` personnalisé.  
7. Ajoutez des commandes pour le déplacement vers le `UserPath`.  
8. Enregistrez la présentation sur le disque au format PPTX.  

Ce code Python montre comment appliquer l’effet `PathFootball` (chemin football) à une forme :
```python
import aspose.slides.animation as anim
import aspose.slides as slides
import aspose.pydrawing as draw

# Instancie une classe Presentation qui représente un fichier PPTX.
with slides.Presentation() as pres:
    sld = pres.slides[0]

    # Crée l'effet PathFootball pour la forme existante à partir de zéro.
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 250, 25)

    ashp.add_text_frame("Animated TextBox")

    # Ajoute l'effet d'animation PathFootBall.
    pres.slides[0].timeline.main_sequence.add_effect(ashp, 
        anim.EffectType.PATH_FOOTBALL,
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    # Crée une sorte de "button".
    shapeTrigger = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.BEVEL, 10, 10, 20, 20)

    # Crée une séquence d'effets pour le bouton.
    seqInter = pres.slides[0].timeline.interactive_sequences.add(shapeTrigger)

    # Crée un chemin utilisateur personnalisé. Notre objet ne sera déplacé qu'après le clic sur le bouton.
    fxUserPath = seqInter.add_effect(ashp, 
        anim.EffectType.PATH_USER, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.ON_CLICK)

    # Ajoute des commandes de déplacement puisque le chemin créé est vide.
    motionBhv = fxUserPath.behaviors[0]

    pts = [draw.PointF(0.076, 0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, True)
    pts = [draw.PointF(-0.076, -0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, False)
    motionBhv.path.add(anim.MotionCommandPathType.END, None, anim.MotionPathPointsType.AUTO, False)

    # Enregistre le fichier PPTX sur le disque
    pres.save("AnimExample_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Obtenir les effets d’animation appliqués à une forme**

Les exemples suivants montrent comment utiliser la méthode `get_effects_by_shape` de la classe [Sequence](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/) pour récupérer tous les effets d’animation appliqués à une forme.

**Exemple 1 : Obtenir les effets d’animation appliqués à une forme sur une diapositive normale**

Auparavant, vous avez appris comment ajouter des effets d’animation aux formes dans les présentations PowerPoint. Le code suivant montre comment obtenir les effets appliqués à la première forme de la première diapositive normale du fichier `AnimExample_out.pptx`.
```python
import aspose.slides as slides

with slides.Presentation("AnimExample_out.pptx") as presentation:
    first_slide = presentation.slides[0]

    # Obtient la séquence principale d'animation de la diapositive.
    sequence = first_slide.timeline.main_sequence

    # Obtient la première forme de la première diapositive.
    shape = first_slide.shapes[0]

    # Obtient les effets d'animation appliqués à la forme.
    shape_effects = sequence.get_effects_by_shape(shape)

    if len(shape_effects) > 0:
        print("The shape", shape.name, "has", len(shape_effects), "animation effects.")
```


**Exemple 2 : Obtenir tous les effets d’animation, y compris ceux hérités des espaces réservés**

Si une forme sur une diapositive normale possède des espaces réservés provenant de la diapositive de mise en page et/ou de la diapositive maître, et que des effets d’animation ont été ajoutés à ces espaces réservés, alors tous les effets de la forme seront joués pendant le diaporama, y compris ceux hérités.

Imaginons un fichier PowerPoint `sample.pptx` contenant une diapositive avec uniquement une forme de pied de page contenant le texte « Made with Aspose.Slides » et l’effet **Random Bars** appliqué à la forme.

![Effet d’animation de forme de diapositive](slide-shape-animation.png)

Supposons également que l’effet **Split** soit appliqué à l’espace réservé du pied de page sur la diapositive **mise en page**.

![Effet d’animation de forme de mise en page](layout-shape-animation.png)

Enfin, l’effet **Fly In** est appliqué à l’espace réservé du pied de page sur la diapositive **maître**.

![Effet d’animation de forme maître](master-shape-animation.png)

Le code suivant montre comment utiliser la méthode `get_base_placeholder` de la classe [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) pour accéder aux espaces réservés de la forme et obtenir les effets d’animation appliqués à la forme de pied de page, y compris ceux hérités des espaces réservés situés sur les diapositives de mise en page et maître.
```py
import aspose.slides as slides

def print_effects(effects):
    for effect in effects:
        print(effect.type.name, effect.subtype.name)
```

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Récupère les effets d'animation de la forme sur la diapositive normale.
    shape = slide.shapes[0]
    shape_effects = slide.timeline.main_sequence.get_effects_by_shape(shape)

    # Récupère les effets d'animation du placeholder sur la diapositive de mise en page.
    layout_shape = shape.get_base_placeholder()
    layout_shape_effects = slide.layout_slide.timeline.main_sequence.get_effects_by_shape(layout_shape)

    # Récupère les effets d'animation du placeholder sur la diapositive maître.
    master_shape = layout_shape.get_base_placeholder()
    master_shape_effects = slide.layout_slide.master_slide.timeline.main_sequence.get_effects_by_shape(master_shape)

    print("Main sequence of shape effects:")
    print_effects(master_shape_effects)
    print_effects(layout_shape_effects)
    print_effects(shape_effects)
```


Sortie :
```text
Main sequence of shape effects:
FLY BOTTOM
SPLIT VERTICAL_IN
RANDOM_BARS HORIZONTAL
```


## **Modifier les propriétés de synchronisation d’un effet d’animation**

Aspose.Slides for Python via .NET vous permet de modifier les propriétés de synchronisation d’un effet d’animation.

Voici le panneau Synchronisation de l’animation dans Microsoft PowerPoint :

![example1_image](shape-animation.png)

Correspondances entre la synchronisation de PowerPoint et les propriétés `Effect.Timing` :

- La liste déroulante **Start** de PowerPoint correspond à la propriété [Effect.Timing.TriggerType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttriggertype/).  
- La valeur **Duration** de PowerPoint correspond à la propriété `Effect.Timing.Duration`. La durée d’une animation (en secondes) correspond au temps total nécessaire à l’animation pour accomplir un cycle.  
- La valeur **Delay** de PowerPoint correspond à la propriété `Effect.Timing.TriggerDelayTime`.  

Voici comment modifier les propriétés de synchronisation de l’effet :

1. [Appliquer](#apply-animation-to-shape) ou récupérer l’effet d’animation.  
2. Définir de nouvelles valeurs pour les propriétés `Effect.Timing` souhaitées.  
3. Enregistrer le fichier PPTX modifié.  

Ce code Python illustre l’opération :
```python
import aspose.slides as slides

# Instancie une classe de présentation qui représente un fichier de présentation.
with slides.Presentation("AnimExample_out.pptx") as pres:
    # Obtient la séquence principale de la diapositive.
    sequence = pres.slides[0].timeline.main_sequence

    # Obtient le premier effet de la séquence principale.
    effect = sequence[0]

    # Modifie le TriggerType de l'effet pour démarrer au clic
    effect.timing.trigger_type = slides.animation.EffectTriggerType.ON_CLICK

    # Modifie la durée de l'effet
    effect.timing.duration = 3

    # Modifie le TriggerDelayTime de l'effet
    effect.timing.trigger_delay_time = 0.5

    # Enregistre le fichier PPTX sur le disque
    pres.save("AnimExample_changed.pptx", slides.export.SaveFormat.PPTX)
```


## **Son d’un effet d’animation**

Aspose.Slides propose les propriétés suivantes pour travailler avec les sons dans les effets d’animation : 

- `sound`
- `stop_previous_sound`

### **Ajouter un son à un effet d’animation**

Ce code Python montre comment ajouter un son à un effet d’animation et l’arrêter lorsque l’effet suivant démarre :
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

    # Vérifie si l'effet n'a pas de son
    if not first_effect.stop_previous_sound and first_effect.sound is None:
        # Ajoute un son au premier effet
        first_effect.sound = effect_sound

    # Obtient la première séquence interactive de la diapositive.
    interactive_sequence = first_slide.timeline.interactive_sequences[0]

    # Définit le drapeau «Stop previous sound» de l'effet
    interactive_sequence[0].stop_previous_sound = True

    # Enregistre le fichier PPTX sur le disque
    pres.save("AnimExample_Sound_out.pptx", slides.export.SaveFormat.PPTX)
```


### **Extraire le son d’un effet d’animation**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).  
2. Obtenez la référence d’une diapositive grâce à son indice.  
3. Récupérez la séquence principale d’effets.  
4. Extrayez le `sound` intégré à chaque effet d’animation.  

Ce code Python montre comment extraire le son intégré à un effet d’animation :
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

        # Extrait le son de l'effet sous forme de tableau d'octets
        audio = effect.sound.binary_data
```


## **Après l’animation**

Aspose.Slides for .NET vous permet de modifier la propriété Après animation d’un effet d’animation.

Voici le panneau Effet d’animation et le menu étendu dans Microsoft PowerPoint :

![example1_image](shape-after-animation.png)

La liste déroulante **After animation** de PowerPoint correspond aux propriétés suivantes : 

- propriété `after_animation_type` qui décrit le type d’après‑animation :
  * **More Colors** de PowerPoint correspond au type [COLOR](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/);
  * **Don’t Dim** de PowerPoint correspond au type [DO_NOT_DIM](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) (type d’après‑animation par défaut);
  * **Hide After Animation** de PowerPoint correspond au type [HIDE_AFTER_ANIMATION](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/);
  * **Hide on Next Mouse Click** de PowerPoint correspond au type [HIDE_ON_NEXT_MOUSE_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/);
- propriété `after_animation_color` qui définit le format de couleur après l’animation. Cette propriété fonctionne en conjonction avec le type [COLOR](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/). Si vous changez le type, la couleur après animation sera réinitialisée.

Ce code Python montre comment modifier un effet après animation :
```python
import aspose.slides as slides

# Instancie une classe de présentation qui représente un fichier de présentation
with slides.Presentation("AnimImage_out.pptx") as pres:
    first_slide = pres.slides[0]

    # Obtient le premier effet de la séquence principale
    first_effect = first_slide.timeline.main_sequence[0]

    # Modifie le type d'animation après en Couleur
    first_effect.after_animation_type = AfterAnimationType.COLOR

    # Définit la couleur d'atténuation après animation
    first_effect.after_animation_color.color = Color.alice_blue

    # Enregistre le fichier PPTX sur le disque
    pres.save("AnimImage_AfterAnimation.pptx", slides.export.SaveFormat.PPTX)
```


## **Animer le texte**

Aspose.Slides propose les propriétés suivantes pour travailler avec le bloc *Animate text* d’un effet d’animation : 

- `animate_text_type` qui décrit le type d’animation du texte de l’effet. Le texte de la forme peut être animé :
  - Tout d’un coup ([ALL_AT_ONCE](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/) )
  - Par mot ([BY_WORD](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/) )
  - Par lettre ([BY_LETTER](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/) )
- `delay_between_text_parts` définit le délai entre les parties du texte animé (mots ou lettres). Une valeur positive indique le pourcentage de la durée de l’effet. Une valeur négative indique le délai en secondes.

Voici comment modifier les propriétés d’animation du texte :

1. [Appliquer](#apply-animation-to-shape) ou récupérer l’effet d’animation.  
2. Définir la propriété `build_type` sur la valeur [AS_ONE_OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides.animation/buildtype/) pour désactiver le mode d’animation *Par paragraphes*.  
3. Définir de nouvelles valeurs pour les propriétés `animate_text_type` et `delay_between_text_parts`.  
4. Enregistrer le fichier PPTX modifié.  

Ce code Python montre l’opération :
```python
import aspose.slides as slides

with slides.Presentation("AnimTextBox_out.pptx") as pres:
    first_slide = pres.slides[0]

    # Obtient le premier effet de la séquence principale
    first_effect = first_slide.timeline.main_sequence[0]

    # Modifie le type d'animation du texte de l'effet en "As One Object"
    first_effect.text_animation.build_type = slides.animation.BuildType.AS_ONE_OBJECT

    # Modifie le type d'animation du texte de l'effet en "By word"
    first_effect.animate_text_type = slides.animation.AnimateTextType.BY_WORD

    # Définit le délai entre les mots à 20% de la durée de l'effet
    first_effect.delay_between_text_parts = 20

    # Enregistre le fichier PPTX sur le disque
    pres.save("AnimTextBox_AnimateText.pptx", slides.export.SaveFormat.PPTX)

```


## **FAQ**

**Comment garantir que les animations sont conservées lors de la publication de la présentation sur le Web ?**

[Export to HTML5](/slides/fr/python-net/export-to-html5/) et activez les [options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/) responsables des animations des [formes](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) et des [transitions](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/). Le HTML simple ne lit pas les animations de diapositive, tandis que le HTML5 le fait.

**Comment le changement de l’ordre Z (ordre des calques) des formes affecte‑t‑il les animations ?**

L’ordre d’animation et l’ordre de dessin sont indépendants : un effet contrôle le moment et le type d’apparition/disparition, tandis que le [z-order](https://reference.aspose.com/slides/python-net/aspose.slides/shape/z_order_position/) détermine ce qui couvre quoi. Le résultat visible est défini par leur combinaison. (C’est le comportement général de PowerPoint ; le modèle effets‑et‑formes d’Aspose.Slides suit la même logique.)

**Existe‑t‑il des limitations lors de la conversion des animations en vidéo pour certains effets ?**

En général, les [animations sont prises en charge](/slides/fr/python-net/convert-powerpoint-to-video/), mais des cas rares ou des effets spécifiques peuvent être rendus différemment. Il est recommandé de tester avec les effets que vous utilisez et avec la version de la bibliothèque.