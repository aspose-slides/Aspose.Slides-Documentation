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
- ajouter animation
- récupérer animation
- extraire animation
- ajouter effet
- récupérer effet
- extraire effet
- son d’effet
- appliquer animation
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Découvrez comment créer et personnaliser des animations de forme dans les présentations PowerPoint et OpenDocument avec Aspose.Slides pour Python via .NET. Démarquez‑vous !"
---

Les animations sont des effets visuels qui peuvent être appliqués aux textes, images, formes ou [charts](/slides/fr/python-net/animated-charts/). Elles donnent vie aux présentations ou à leurs éléments.

## **Pourquoi utiliser des animations dans les présentations ?**

En utilisant les animations, vous pouvez

* contrôler le flux d’information
* mettre en avant les points importants
* augmenter l’intérêt ou la participation de votre auditoire
* rendre le contenu plus facile à lire, assimiler ou traiter
* attirer l’attention de vos lecteurs ou spectateurs sur les parties importantes d’une présentation

PowerPoint fournit de nombreuses options et outils pour les animations et les effets d’animation dans les catégories **entrée**, **sortie**, **mise en valeur** et **chemins de mouvement**.

## **Animations dans Aspose.Slides**

* Aspose.Slides fournit les classes et types nécessaires pour travailler avec les animations dans l’espace de noms [Aspose.Slides.Animation](https://reference.aspose.com/slides/python-net/aspose.slides.animation/),
* Aspose.Slides propose plus de **150 effets d’animation** dans l’énumération [EffectType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttype/). Ces effets sont essentiellement les mêmes (ou équivalents) que ceux utilisés dans PowerPoint.

## **Appliquer une animation à une TextBox**

Aspose.Slides for Python via .NET vous permet d’appliquer une animation au texte d’une forme.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenez une référence à une diapositive via son index.
3. Ajoutez un `rectangle` [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/).
4. Ajoutez du texte à `IAutoShape.TextFrame`.
5. Récupérez la séquence principale d’effets.
6. Ajoutez un effet d’animation à [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/).
7. Définissez la propriété `TextAnimation.BuildType` sur la valeur de l’énumération `BuildType`.
8. Enregistrez la présentation sur le disque au format PPTX.

Ce code Python montre comment appliquer l’effet `Fade` à une AutoShape et définir l’animation du texte sur la valeur *By 1st Level Paragraphs* :

```python
import aspose.slides as slides

# Instantiates a presentation class that represents a presentation file.
with slides.Presentation() as pres:
    sld = pres.slides[0]
    
    # Adds new AutoShape with text
    autoShape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 100)

    textFrame = autoShape.text_frame
    textFrame.text = "First paragraph \nSecond paragraph \n Third paragraph"

    # Gets the main sequence of the slide.
    sequence = sld.timeline.main_sequence

    # Adds Fade animation effect to shape
    effect = sequence.add_effect(autoShape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    # Animates shape text by 1st level paragraphs
    effect.text_animation.build_type = slides.animation.BuildType.BY_LEVEL_PARAGRAPHS1

    # Save the PPTX file to disk
    pres.save("AnimText_out.pptx", slides.export.SaveFormat.PPTX)
```

{{%  alert color="primary"  %}} 

En plus d’appliquer des animations au texte, vous pouvez également appliquer des animations à un [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraph/). Voir [**Texte animé**](/slides/fr/python-net/animated-text/).

{{% /alert %}} 

## **Appliquer une animation à un PictureFrame**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenez une référence à une diapositive via son index.
3. Ajoutez ou récupérez un [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) sur la diapositive.
4. Récupérez la séquence principale d’effets.
5. Ajoutez un effet d’animation à [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/).
6. Enregistrez la présentation sur le disque au format PPTX.

Ce code Python montre comment appliquer l’effet `Fly` à un cadre d’image :

```python
import aspose.slides as slides
import aspose.pydrawing as draw


# Instantiates a presentation class that represents a presentation file.
with slides.Presentation() as pres:
    # Load Image to be added in presentaiton image collection
    img = draw.Bitmap("aspose-logo.jpg")
    image = pres.images.add_image(img)

    # Adds picture frame to slide
    picFrame = pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

    # Gets the main sequence of the slide.
    sequence = pres.slides[0].timeline.main_sequence

    # Adds Fly from Left animation effect to picture frame
    effect = sequence.add_effect(picFrame, slides.animation.EffectType.FLY,  
        slides.animation.EffectSubtype.LEFT, 
        slides.animation.EffectTriggerType.ON_CLICK)

    # Save the PPTX file to disk
    pres.save("AnimImage_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Appliquer une animation à une Shape**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenez une référence à une diapositive via son index.
3. Ajoutez un `rectangle` [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/).
4. Ajoutez un `Bevel` [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) (lorsque cet objet est cliqué, l’animation se lance).
5. Créez une séquence d’effets sur la forme en biseau.
6. Créez un `UserPath` personnalisé.
7. Ajoutez des commandes pour le déplacement dans le `UserPath`.
8. Enregistrez la présentation sur le disque au format PPTX.

Ce code Python montre comment appliquer l’effet `PathFootball` (chemin football) à une forme :

```python
import aspose.slides.animation as anim
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiates a Prseetation class that represents a PPTX file
with slides.Presentation() as pres:
    sld = pres.slides[0]

    # Creates PathFootball effect for existing shape from scratch.
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 250, 25)

    ashp.add_text_frame("Animated TextBox")

    # Adds the PathFootBall animation effect.
    pres.slides[0].timeline.main_sequence.add_effect(ashp, 
        anim.EffectType.PATH_FOOTBALL,
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    # Creates some kind of "button".
    shapeTrigger = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.BEVEL, 10, 10, 20, 20)

    # Creates a sequence of effects for the button.
    seqInter = pres.slides[0].timeline.interactive_sequences.add(shapeTrigger)

    # Creates a custom user path. Our object will be moved only after the button is clicked.
    fxUserPath = seqInter.add_effect(ashp, 
        anim.EffectType.PATH_USER, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.ON_CLICK)

    # Adds commands for moving since created path is empty.
    motionBhv = fxUserPath.behaviors[0]

    pts = [draw.PointF(0.076, 0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, True)
    pts = [draw.PointF(-0.076, -0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, False)
    motionBhv.path.add(anim.MotionCommandPathType.END, None, anim.MotionPathPointsType.AUTO, False)

    # Writes the PPTX file to disk
    pres.save("AnimExample_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Obtenir les effets d’animation appliqués à une Shape**

Les exemples suivants montrent comment utiliser la méthode `get_effects_by_shape` de la classe [Sequence](https://reference.aspose.com/slides/python-net/aspose.slides.animation/sequence/) pour récupérer tous les effets d’animation appliqués à une forme.

**Exemple 1 : Récupérer les effets d’animation appliqués à une forme sur une diapositive normale**

Dans la partie précédente, vous avez appris à ajouter des effets d’animation aux formes dans les présentations PowerPoint. Le code suivant montre comment obtenir les effets appliqués à la première forme de la première diapositive normale du fichier `AnimExample_out.pptx`.

```python
import aspose.slides as slides

with slides.Presentation("AnimExample_out.pptx") as presentation:
    first_slide = presentation.slides[0]

    # Gets the main animation sequence of the slide.
    sequence = first_slide.timeline.main_sequence

    # Gets the first shape on the first slide.
    shape = first_slide.shapes[0]

    # Gets animation effects applied to the shape.
    shape_effects = sequence.get_effects_by_shape(shape)

    if len(shape_effects) > 0:
        print("The shape", shape.name, "has", len(shape_effects), "animation effects.")
```

**Exemple 2 : Récupérer tous les effets d’animation, y compris ceux hérités des espaces réservés**

Si une forme sur une diapositive normale possède des espaces réservés provenant de la diapositive de mise en page et/ou du masque, et que des effets d’animation ont été ajoutés à ces espaces réservés, alors tous les effets de la forme seront joués lors du diaporama, y compris ceux hérités.

Supposons que nous ayons un fichier de présentation PowerPoint `sample.pptx` contenant une seule diapositive avec uniquement une forme de pied de page affichant le texte « Made with Aspose.Slides » et que l’effet **Random Bars** soit appliqué à la forme.

![Effet d’animation de forme de diapositive](slide-shape-animation.png)

Supposons également que l’effet **Split** soit appliqué à l’espace réservé du pied de page sur la diapositive de **mise en page**.

![Effet d’animation de forme de mise en page](layout-shape-animation.png)

Enfin, l’effet **Fly In** est appliqué à l’espace réservé du pied de page sur la diapositive de **masque**.

![Effet d’animation de forme de masque](master-shape-animation.png)

Le code suivant montre comment utiliser la méthode `get_base_placeholder` de la classe [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) pour accéder aux espaces réservés et obtenir les effets d’animation appliqués à la forme du pied de page, y compris ceux hérités des espaces réservés des diapositives de mise en page et de masque.

```py
import aspose.slides as slides

def print_effects(effects):
    for effect in effects:
        print(effect.type.name, effect.subtype.name)
```
```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Get animation effects of the shape on the normal slide.
    shape = slide.shapes[0]
    shape_effects = slide.timeline.main_sequence.get_effects_by_shape(shape)

    # Get animation effects of the placeholder on the layout slide.
    layout_shape = shape.get_base_placeholder()
    layout_shape_effects = slide.layout_slide.timeline.main_sequence.get_effects_by_shape(layout_shape)

    # Get animation effects of the placeholder on the master slide.
    master_shape = layout_shape.get_base_placeholder()
    master_shape_effects = slide.layout_slide.master_slide.timeline.main_sequence.get_effects_by_shape(master_shape)

    print("Main sequence of shape effects:")
    print_effects(master_shape_effects)
    print_effects(layout_shape_effects)
    print_effects(shape_effects)
```

Sortie :
```text
Main sequence of shape effects:
FLY BOTTOM
SPLIT VERTICAL_IN
RANDOM_BARS HORIZONTAL
```

## **Modifier les propriétés de synchronisation d’un effet d’animation**

Aspose.Slides for Python via .NET vous permet de modifier les propriétés de synchronisation d’un effet d’animation.

Voici le volet *Animation Timing* dans Microsoft PowerPoint :

![example1_image](shape-animation.png)

Correspondances entre le timing PowerPoint et les propriétés `Effect.Timing` :

- La liste déroulante **Start** du timing PowerPoint correspond à la propriété [Effect.Timing.TriggerType](https://reference.aspose.com/slides/python-net/aspose.slides.animation/effecttriggertype/).
- La zone **Duration** correspond à la propriété `Effect.Timing.Duration`. La durée (en secondes) représente le temps total nécessaire à l’effet pour exécuter un cycle complet.
- La zone **Delay** correspond à la propriété `Effect.Timing.TriggerDelayTime`.

Voici comment modifier les propriétés de synchronisation d’un effet :

1. [Appliquer](#apply-animation-to-shape) ou obtenir l’effet d’animation.
2. Définir les nouvelles valeurs des propriétés `Effect.Timing` souhaitées.
3. Enregistrer le fichier PPTX modifié.

Exemple de code Python :

```python
import aspose.slides as slides

# Instantiates a presentation class that represents a presentation file.
with slides.Presentation("AnimExample_out.pptx") as pres:
    # Gets the main sequence of the slide.
    sequence = pres.slides[0].timeline.main_sequence

    # Gets the first effect of main sequence.
    effect = sequence[0]

    # Changes effect TriggerType to start on click
    effect.t timing.trigger_type = slides.animation.EffectTriggerType.ON_CLICK

    # Changes effect Duration
    effect.timing.duration = 3

    # Changes effect TriggerDelayTime
    effect.timing.trigger_delay_time = 0.5

    # Saves the PPTX file to disk
    pres.save("AnimExample_changed.pptx", slides.export.SaveFormat.PPTX)
```

## **Son d’un effet d’animation**

Aspose.Slides expose les propriétés suivantes pour travailler avec le son des effets d’animation :

- `sound`
- `stop_previous_sound`

### **Ajouter un son à un effet d’animation**

Ce code Python montre comment ajouter un son à un effet d’animation et l’arrêter lorsque l’effet suivant démarre :

```python
import aspose.slides as slides

with Presentation("AnimExample_out.pptx") as pres:
    # Adds audio to presentation audio collection
    effect_sound = pres.audios.add_audio(open("sampleaudio.wav", "rb").read())

    first_slide = pres.slides[0]

    # Gets the main sequence of the slide.
    sequence = first_slide.timeline.main_sequence

    # Gets the first effect of the main sequence
    first_effect = sequence[0]

    # Сhecks the effect for "No Sound"
    if not first_effect.stop_previous_sound and first_effect.sound is None:
        # Adds sound for the first effect
        first_effect.sound = effect_sound

    # Gets the first interactive sequence of the slide.
    interactive_sequence = first_slide.timeline.interactive_sequences[0]

    # Sets the effect "Stop previous sound" flag
    interactive_sequence[0].stop_previous_sound = True

    # Writes the PPTX file to disk
    pres.save("AnimExample_Sound_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Extraire le son d’un effet d’animation**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenez une référence à une diapositive via son index.
3. Récupérez la séquence principale d’effets.
4. Extraire le `sound` intégré à chaque effet d’animation.

Ce code Python montre comment extraire le son incrusté dans un effet d’animation :

```python
import aspose.slides as slides

# Instantiates a presentation class that represents a presentation file.
with slides.Presentation("EffectSound.pptx") as presentation:
    slide = presentation.slides[0]

    # Gets the main sequence of the slide.
    sequence = slide.timeline.main_sequence

    for effect in sequence:
        if effect.sound is None:
            continue

        # Extracts the effect sound in byte array
        audio = effect.sound.binary_data
```

## **Après l’animation**

Aspose.Slides for .NET vous permet de modifier la propriété *After animation* d’un effet d’animation.

Voici le volet *Animation Effect* et le menu étendu dans Microsoft PowerPoint :

![example1_image](shape-after-animation.png)

La liste déroulante **After animation** du volet PowerPoint correspond aux propriétés :

- propriété `after_animation_type` qui décrit le type d’après‑animation :
  * **More Colors** correspond au type [COLOR](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/);
  * **Don't Dim** correspond au type [DO_NOT_DIM](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) (type par défaut) ;
  * **Hide After Animation** correspond au type [HIDE_AFTER_ANIMATION](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) ;
  * **Hide on Next Mouse Click** correspond au type [HIDE_ON_NEXT_MOUSE_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/) ;
- propriété `after_animation_color` qui définit le format de couleur après l’animation. Cette propriété fonctionne conjointement avec le type [COLOR](https://reference.aspose.com/slides/python-net/aspose.slides.animation/afteranimationtype/). Si vous changez le type, la couleur après animation sera réinitialisée.

Ce code Python montre comment modifier un effet d’après‑animation :

```python
import aspose.slides as slides

# Instantiates a presentation class that represents a presentation file
with slides.Presentation("AnimImage_out.pptx") as pres:
    first_slide = pres.slides[0]

    # Gets the first effect of the main sequence
    first_effect = first_slide.timeline.main_sequence[0]

    # Changes the after animation type to Color
    first_effect.after_animation_type = AfterAnimationType.COLOR

    # Sets the after animation dim color
    first_effect.after_animation_color.color = Color.alice_blue

    # Writes the PPTX file to disk
    pres.save("AnimImage_AfterAnimation.pptx", slides.export.SaveFormat.PPTX)
```

## **Animer le texte**

Aspose.Slides expose les propriétés suivantes pour travailler avec le bloc *Animate text* d’un effet d’animation :

- `animate_text_type` qui décrit le type d’animation du texte de l’effet. Le texte d’une forme peut être animé :
  - Tout d’un coup ([ALL_AT_ONCE](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/)) ;
  - Par mot ([BY_WORD](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/)) ;
  - Par lettre ([BY_LETTER](https://reference.aspose.com/slides/python-net/aspose.slides.animation/animatetexttype/)) ;
- `delay_between_text_parts` définit un délai entre les parties du texte animé (mots ou lettres). Une valeur positive indique le pourcentage de la durée de l’effet ; une valeur négative indique le délai en secondes.

Voici comment modifier les propriétés *Animate text* d’un effet :

1. [Appliquer](#apply-animation-to-shape) ou récupérer l’effet d’animation.
2. Définir la propriété `build_type` sur la valeur [AS_ONE_OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides.animation/buildtype/) pour désactiver le mode *By Paragraphs*.
3. Définir de nouvelles valeurs pour les propriétés `animate_text_type` et `delay_between_text_parts`.
4. Enregistrer le fichier PPTX modifié.

Exemple de code Python :

```python
import aspose.slides as slides

with slides.Presentation("AnimTextBox_out.pptx") as pres:
    first_slide = pres.slides[0]

    # Gets the first effect of the main sequence
    first_effect = first_slide.timeline.main_sequence[0]

    # Changes the effect Text animation type to "As One Object"
    first_effect.text_animation.build_type = slides.animation.BuildType.AS_ONE_OBJECT

    # Changes the effect Animate text type to "By word"
    first_effect.animate_text_type = slides.animation.AnimateTextType.BY_WORD

    # Sets the delay between words to 20% of effect duration
    first_effect.delay_between_text_parts = 20

    # Writes the PPTX file to disk
    pres.save("AnimTextBox_AnimateText.pptx", slides.export.SaveFormat.PPTX)

```

## **FAQ**

**Comment garantir que les animations sont conservées lors de la publication de la présentation sur le web ?**

[Exportez vers HTML5](/slides/fr/python-net/export-to-html5/) et activez les [options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/) responsables des animations de [formes](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) et de [transition](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/). Le HTML simple ne lit pas les animations de diapositive, alors que le HTML5 le fait.

**Comment le changement d’ordre Z (ordre des calques) des formes affecte‑t‑il les animations ?**

L’ordre d’animation et l’ordre de dessin sont indépendants : un effet contrôle le moment et le type d’apparition/disparition, tandis que l’[ordre Z](https://reference.aspose.com/slides/python-net/aspose.slides/shape/z_order_position/) détermine ce qui recouvre quoi. Le résultat visible est défini par leur combinaison. (C’est le comportement général de PowerPoint ; le modèle Aspose.Slides effets‑et‑formes suit la même logique.)

**Existe‑t‑il des limitations lors de la conversion des animations en vidéo pour certains effets ?**

En général, les [animations sont prises en charge](/slides/fr/python-net/convert-powerpoint-to-video/), mais des cas rares ou des effets spécifiques peuvent être rendus différemment. Il est recommandé de tester les effets que vous utilisez avec la version de la bibliothèque.