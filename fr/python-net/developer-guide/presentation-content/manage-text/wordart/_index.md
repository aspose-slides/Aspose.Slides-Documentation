---
title: WordArt
type: docs
weight: 110
url: /python-net/wordart/
keywords: "WordArt, Art de texte, Créer WordArt, Modèle WordArt, Effets WordArt, Effets d'ombre, Effets d'affichage, Effets de lueur, Transformations WordArt, Effets 3D, Effets d'ombre extérieure, Effets d'ombre intérieure, Python, Aspose.Slides pour Python via .NET"
description: "Ajouter, manipuler et gérer WordArt et effets dans des présentations PowerPoint en Python ou Aspose.Slides pour Python via .NET"
---

## **À propos de WordArt ?**
WordArt ou Art de texte est une fonctionnalité qui vous permet d'appliquer des effets aux textes pour les faire ressortir. Avec WordArt, par exemple, vous pouvez contourner un texte ou le remplir d'une couleur (ou d'un dégradé), lui ajouter des effets 3D, etc. Vous pouvez également déformer, plier et étirer la forme d'un texte.

{{% alert color="primary" %}} 

WordArt vous permet de traiter un texte comme vous le feriez avec un objet graphique. WordArt se compose d'effets ou de modifications spéciales apportées aux textes pour les rendre plus attrayants ou remarquables. 

{{% /alert %}} 

**WordArt dans Microsoft PowerPoint**

Pour utiliser WordArt dans Microsoft PowerPoint, vous devez sélectionner l'un des modèles WordArt prédéfinis. Un modèle WordArt est un ensemble d'effets qui sont appliqués à un texte ou à sa forme.

**WordArt dans Aspose.Slides**

Dans Aspose.Slides pour Python via .NET 20.10, nous avons mis en œuvre le support de WordArt et apporté des améliorations à cette fonctionnalité dans les versions successives d'Aspose.Slides pour Python via .NET.

Avec Aspose.Slides pour Python via .NET, vous pouvez facilement créer votre propre modèle WordArt (un effet ou une combinaison d'effets) en Python et l'appliquer aux textes.

## Création d'un modèle WordArt simple et application à un texte

**En utilisant Aspose.Slides** 

Tout d'abord, nous créons un texte simple en utilisant ce code Python : 

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    textFrame = autoShape.text_frame

    portion = textFrame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"

    pres.save("wordart-1.pptx", slides.export.SaveFormat.PPTX)
```
Maintenant, nous réglons la hauteur de la police du texte sur une valeur plus élevée pour rendre l'effet plus visible à travers ce code :

```py 
    fontData = slides.FontData("Arial Black")
    portion.portion_format.latin_font = fontData
    portion.portion_format.font_height = 36
```

**En utilisant Microsoft PowerPoint**

Allez dans le menu des effets WordArt dans Microsoft PowerPoint :

![todo:image_alt_text](image-20200930113926-1.png)

À partir du menu à droite, vous pouvez choisir un effet WordArt prédéfini. À partir du menu à gauche, vous pouvez spécifier les paramètres pour un nouveau WordArt. 

Voici quelques-uns des paramètres ou options disponibles :

![todo:image_alt_text](image-20200930114015-3.png)

**En utilisant Aspose.Slides**

Ici, nous appliquons la couleur du motif SmallGrid au texte et ajoutons une bordure de texte noire de 1 de largeur en utilisant ce code :

```py 
    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = draw.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = draw.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.SMALL_GRID
                
    portion.portion_format.line_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.line_format.fill_format.solid_fill_color.color = draw.Color.black
```

Le texte résultant :

![todo:image_alt_text](image-20200930114108-4.png)

## Application d'autres effets WordArt

**En utilisant Microsoft PowerPoint**

À partir de l'interface du programme, vous pouvez appliquer ces effets à un texte, un bloc de texte, une forme ou un élément similaire :

![todo:image_alt_text](image-20200930114129-5.png)

Par exemple, les effets d'ombre, de réflexion et de lueur peuvent être appliqués à un texte ; les effets de format 3D et de rotation 3D peuvent être appliqués à un bloc de texte ; la propriété Edges doux peut être appliquée à un objet Shape (cela a toujours un effet lorsqu'aucune propriété de format 3D n'est définie).

### Application des effets d'ombre

Ici, nous avons l'intention de définir les propriétés relatives uniquement à un texte. Nous appliquons l'effet d'ombre à un texte en utilisant ce code en Python :

```py 
    portion.portion_format.effect_format.enable_outer_shadow_effect()
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color = draw.Color.black
    portion.portion_format.effect_format.outer_shadow_effect.scale_horizontal = 100
    portion.portion_format.effect_format.outer_shadow_effect.scale_vertical = 65
    portion.portion_format.effect_format.outer_shadow_effect.blur_radius = 4.73
    portion.portion_format.effect_format.outer_shadow_effect.direction = 230
    portion.portion_format.effect_format.outer_shadow_effect.distance = 2
    portion.portion_format.effect_format.outer_shadow_effect.skew_horizontal = 30
    portion.portion_format.effect_format.outer_shadow_effect.skew_vertical = 0
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.32)
```

L'API Aspose.Slides prend en charge trois types d'ombre : OuterShadow, InnerShadow et PresetShadow.

Avec PresetShadow, vous pouvez appliquer une ombre à un texte (en utilisant des valeurs prédéfinies).

**En utilisant Microsoft PowerPoint**

Dans PowerPoint, vous pouvez utiliser un type d'ombre. Voici un exemple :

![todo:image_alt_text](image-20200930114225-6.png)

**En utilisant Aspose.Slides**

Aspose.Slides permet effectivement d'appliquer deux types d'ombres à la fois : InnerShadow et PresetShadow.

**Remarques :**

- Lorsque OuterShadow et PresetShadow sont utilisés ensemble, seul l'effet OuterShadow est appliqué. 
- Si OuterShadow et InnerShadow sont utilisés simultanément, l'effet résultant ou appliqué dépend de la version de PowerPoint. Par exemple, dans PowerPoint 2013, l'effet est doublé. Mais dans PowerPoint 2007, l'effet OuterShadow est appliqué.

### Application d'effets d'affichage aux textes

Nous ajoutons un affichage au texte à l'aide de cet exemple de code en Python :

```py 
    portion.portion_format.effect_format.enable_reflection_effect()
    portion.portion_format.effect_format.reflection_effect.blur_radius = 0.5 
    portion.portion_format.effect_format.reflection_effect.distance = 4.72 
    portion.portion_format.effect_format.reflection_effect.start_pos_alpha = 0 
    portion.portion_format.effect_format.reflection_effect.end_pos_alpha = 60
    portion.portion_format.effect_format.reflection_effect.direction = 90 
    portion.portion_format.effect_format.reflection_effect.scale_horizontal = 100 
    portion.portion_format.effect_format.reflection_effect.scale_vertical = -100
    portion.portion_format.effect_format.reflection_effect.start_reflection_opacity = 60
    portion.portion_format.effect_format.reflection_effect.end_reflection_opacity = 0.9
    portion.portion_format.effect_format.reflection_effect.rectangle_align = slides.RectangleAlignment.BOTTOM_LEFT  
```

### Application de l'effet de lueur aux textes

Nous appliquons l'effet de lueur au texte pour le faire briller ou ressortir en utilisant ce code :

```py 
    portion.portion_format.effect_format.enable_glow_effect()
    portion.portion_format.effect_format.glow_effect.color.r = 255
    portion.portion_format.effect_format.glow_effect.color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.54)
    portion.portion_format.effect_format.glow_effect.radius = 7
```

Le résultat de l'opération :

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

Vous pouvez modifier les paramètres pour l'ombre, l'affichage et la lueur. Les propriétés des effets sont définies sur chaque portion du texte séparément. 

{{% /alert %}} 

### Utilisation des transformations dans WordArt

Nous utilisons la propriété Transform (inhérente à l'ensemble du bloc de texte) via ce code :
```py 
textFrame.text_frame_format.transform = slides.TextShapeType.ARCH_UP_POUR
```

Le résultat :

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Microsoft PowerPoint et Aspose.Slides pour Python via .NET offrent un certain nombre de types de transformation prédéfinis. 

{{% /alert %}} 

**En utilisant PowerPoint**

Pour accéder aux types de transformation prédéfinis, allez dans : **Format** -> **Effet de texte** -> **Transformer**

**En utilisant Aspose.Slides**

Pour sélectionner un type de transformation, utilisez l'énumération TextShapeType.

### Application d'effets 3D aux textes et formes

Nous appliquons un effet 3D à une forme de texte en utilisant cet exemple de code :

```py 
    autoShape.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    autoShape.three_d_format.bevel_bottom.height = 10.5
    autoShape.three_d_format.bevel_bottom.width = 10.5

    autoShape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    autoShape.three_d_format.bevel_top.height = 12.5
    autoShape.three_d_format.bevel_top.width = 11

    autoShape.three_d_format.extrusion_color.color = draw.Color.orange
    autoShape.three_d_format.extrusion_height = 6

    autoShape.three_d_format.contour_color.color = draw.Color.dark_red
    autoShape.three_d_format.contour_width = 1.5

    autoShape.three_d_format.depth = 3

    autoShape.three_d_format.material = slides.MaterialPresetType.PLASTIC

    autoShape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    autoShape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    autoShape.three_d_format.light_rig.set_rotation(0, 0, 40)

    autoShape.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```

Le texte résultant et sa forme :

![todo:image_alt_text](image-20200930114816-9.png)

Nous appliquons un effet 3D au texte avec ce code Python :

```py 
    textFrame.text_frame_format.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    textFrame.text_frame_format.three_d_format.bevel_bottom.height = 3.5
    textFrame.text_frame_format.three_d_format.bevel_bottom.width = 3.5

    textFrame.text_frame_format.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    textFrame.text_frame_format.three_d_format.bevel_top.height = 4
    textFrame.text_frame_format.three_d_format.bevel_top.width = 4

    textFrame.text_frame_format.three_d_format.extrusion_color.color = draw.Color.orange
    textFrame.text_frame_format.three_d_format.extrusion_height= 6

    textFrame.text_frame_format.three_d_format.contour_color.color = draw.Color.dark_red
    textFrame.text_frame_format.three_d_format.contour_width = 1.5

    textFrame.text_frame_format.three_d_format.depth= 3

    textFrame.text_frame_format.three_d_format.material = slides.MaterialPresetType.PLASTIC

    textFrame.text_frame_format.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    textFrame.text_frame_format.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    textFrame.text_frame_format.three_d_format.light_rig.set_rotation(0, 0, 40)

    textFrame.text_frame_format.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```

Le résultat de l'opération :

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

L'application d'effets 3D aux textes ou à leurs formes et les interactions entre les effets sont basées sur certaines règles. 

Considérez une scène pour un texte et la forme contenant ce texte. L'effet 3D contient la représentation de l'objet 3D et la scène sur laquelle l'objet a été placé. 

- Lorsque la scène est définie à la fois pour la figure et le texte, la scène de la figure a une priorité plus élevée—la scène du texte est ignorée. 
- Lorsque la figure n'a pas sa propre scène mais a une représentation 3D, la scène du texte est utilisée. 
- Sinon—lorsque la forme n'a initialement aucun effet 3D—la forme est plate et l'effet 3D n'est appliqué qu'au texte. 

Les descriptions sont liées aux propriétés [ThreeDFormat.LightRig](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) et [ThreeDFormat.Camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/).

{{% /alert %}} 

## **Appliquer des effets d'ombre extérieure aux textes**
Aspose.Slides pour Python via .NET fournit les classes [**IOuterShadow**](https://reference.aspose.com/slides/python-net/aspose.slides.effects/ioutershadow/) et [**IInnerShadow**](https://reference.aspose.com/slides/python-net/aspose.slides.effects/iinnershadow/) qui vous permettent d'appliquer des effets d'ombre à un texte contenu dans TextFrame. Suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenez la référence d'une diapositive en utilisant son index.
3. Ajoutez une AutoShape de type Rectangle à la diapositive.
4. Accédez à la TextFrame associée à l'AutoShape.
5. Définissez le FillType de l'AutoShape sur NoFill.
6. Instanciez la classe OuterShadow.
7. Définissez le BlurRadius de l'ombre.
8. Définissez la Direction de l'ombre.
9. Définissez la Distance de l'ombre.
10. Définissez l'Alignement du rectangle sur TopLeft.
11. Définissez la couleur prédéfinie de l'ombre sur Noir.
12. Écrivez la présentation sous forme de fichier PPTX.

Cet exemple de code en Python—une implémentation des étapes ci-dessus—vous montre comment appliquer l'effet d'ombre extérieure à un texte :

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:

    # Obtenez la référence de la diapositive
    sld = pres.slides[0]

    # Ajoutez une AutoShape de type Rectangle
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    # Ajoutez une TextFrame au Rectangle
    ashp.add_text_frame("Aspose TextBox")

    # Désactivez le remplissage de la forme au cas où nous voudrions obtenir l'ombre du texte
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Ajoutez une ombre extérieure et définissez tous les paramètres nécessaires
    ashp.effect_format.enable_outer_shadow_effect()
    shadow = ashp.effect_format.outer_shadow_effect
    shadow.blur_radius = 4.0
    shadow.direction = 45
    shadow.distance = 3
    shadow.rectangle_align = slides.RectangleAlignment.TOP_LEFT
    shadow.shadow_color.preset_color = slides.PresetColor.BLACK

    # Écrivez la présentation sur le disque
    pres.save("pres_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Appliquer un effet d'ombre intérieure aux formes**
Suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenez une référence de la diapositive.
3. Ajoutez une AutoShape de type Rectangle.
4. Activez l'effet InnerShadowEffect.
5. Définissez tous les paramètres nécessaires.
6. Définissez le ColorType sur Scheme.
7. Définissez la couleur du schéma.
8. Écrivez la présentation sous forme de fichier [PPTX](https://docs.fileformat.com/presentation/pptx/) .

Cet exemple de code (basé sur les étapes ci-dessus) vous montre comment ajouter un connecteur entre deux formes en Python :

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    # Obtenez la référence d'une diapositive
    slide = presentation.slides[0]

    # Ajoutez une AutoShape de type Rectangle
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 400, 300)
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Ajoutez une TextFrame au Rectangle
    ashp.add_text_frame("Aspose TextBox")
    port = ashp.text_frame.paragraphs[0].portions[0]
    pf = port.portion_format
    pf.font_height = 50

    # Activez l'effet inner_shadow_effect    
    ef = pf.effect_format
    ef.enable_inner_shadow_effect()

    # Définissez tous les paramètres nécessaires
    ef.inner_shadow_effect.blur_radius = 8.0
    ef.inner_shadow_effect.direction = 90.0
    ef.inner_shadow_effect.distance = 6.0
    ef.inner_shadow_effect.shadow_color.b = 189

    # Définissez ColorType sur Scheme
    ef.inner_shadow_effect.shadow_color.color_type = slides.ColorType.SCHEME

    # Définissez la couleur du schéma
    ef.inner_shadow_effect.shadow_color.scheme_color = slides.SchemeColor.ACCENT1

    # Enregistrez la présentation
    presentation.save("WordArt_out.pptx", slides.export.SaveFormat.PPTX)
```