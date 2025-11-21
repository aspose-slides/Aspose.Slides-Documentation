---
title: Créer et appliquer des effets WordArt en Python
linktitle: WordArt
type: docs
weight: 110
url: /fr/python-net/wordart/
keywords:
- WordArt
- créer WordArt
- modèle WordArt
- effet WordArt
- effet d'ombre
- effet d'affichage
- effet de lueur
- transformation WordArt
- effet 3D
- effet d'ombre externe
- effet d'ombre interne
- Python
- Aspose.Slides
description: "Apprenez à créer et personnaliser des effets WordArt dans Aspose.Slides pour Python via .NET. Ce guide étape par étape aide les développeurs à améliorer les présentations avec du texte élégant et professionnel en Python."
---

## **À propos de WordArt ?**
WordArt ou Word Art est une fonctionnalité qui vous permet d’appliquer des effets au texte pour le faire ressortir. Avec WordArt, par exemple, vous pouvez tracer le contour d’un texte ou le remplir d’une couleur (ou d’un dégradé), ajouter des effets 3D, etc. Vous pouvez également incliner, plier et étirer la forme d’un texte. 

{{% alert color="primary" %}} 

WordArt vous permet de traiter un texte comme un objet graphique. WordArt se compose d’effets ou de modifications spéciales appliquées aux textes pour les rendre plus attrayants ou remarquables. 

{{% /alert %}} 

**WordArt dans Microsoft PowerPoint**

Pour utiliser WordArt dans Microsoft PowerPoint, vous devez sélectionner l’un des modèles WordArt prédéfinis. Un modèle WordArt est un ensemble d’effets appliqués à un texte ou à sa forme. 

**WordArt dans Aspose.Slides**

Dans Aspose.Slides for Python via .NET 20.10, nous avons implémenté la prise en charge de WordArt et apporté des améliorations à la fonctionnalité dans les versions ultérieures d’Aspose.Slides for Python via .NET. 

Avec Aspose.Slides for Python via .NET, vous pouvez facilement créer votre propre modèle WordArt (un effet ou une combinaison d’effets) en Python et l’appliquer aux textes. 

## Créer un modèle WordArt simple et l’appliquer à un texte

**Utilisation d’Aspose.Slides** 

Tout d’abord, nous créons un texte simple à l’aide de ce code Python :
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

Ensuite, nous définissons la hauteur de la police du texte à une valeur plus grande pour rendre l’effet plus visible grâce à ce code :
```py 
    fontData = slides.FontData("Arial Black")
    portion.portion_format.latin_font = fontData
    portion.portion_format.font_height = 36
```


**Utilisation de Microsoft PowerPoint**

Accédez au menu des effets WordArt dans Microsoft PowerPoint :

![todo:image_alt_text](image-20200930113926-1.png)

Dans le menu à droite, vous pouvez choisir un effet WordArt prédéfini. Dans le menu à gauche, vous pouvez spécifier les paramètres d’un nouveau WordArt. 

Voici quelques‑uns des paramètres ou options disponibles :

![todo:image_alt_text](image-20200930114015-3.png)

**Utilisation d’Aspose.Slides**

Ici, nous appliquons la couleur de motif SmallGrid au texte et ajoutons une bordure de texte noire de largeur 1 à l’aide de ce code :
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

## Appliquer d’autres effets WordArt

**Utilisation de Microsoft PowerPoint**

Depuis l’interface du programme, vous pouvez appliquer ces effets à un texte, un bloc de texte, une forme ou un élément similaire :

![todo:image_alt_text](image-20200930114129-5.png)

Par exemple, les effets Ombre, Réflexion et Lueur peuvent être appliqués à un texte ; les effets Format 3D et Rotation 3D peuvent être appliqués à un bloc de texte ; la propriété Bords arrondis peut être appliquée à un objet Forme (elle a toujours un effet lorsqu’aucune propriété Format 3D n’est définie). 

### Appliquer des effets d’ombre

Ici, nous avons l’intention de définir les propriétés liées uniquement à un texte. Nous appliquons l’effet d’ombre à un texte à l’aide de ce code en Python :
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


L’API Aspose.Slides prend en charge trois types d’ombres : OuterShadow, InnerShadow et PresetShadow. 

Avec PresetShadow, vous pouvez appliquer une ombre à un texte (en utilisant des valeurs prédéfinies). 

**Utilisation de Microsoft PowerPoint**

Dans PowerPoint, vous pouvez utiliser un type d’ombre. Voici un exemple :

![todo:image_alt_text](image-20200930114225-6.png)

**Utilisation d’Aspose.Slides**

Aspose.Slides permet en réalité d’appliquer deux types d’ombres simultanément : InnerShadow et PresetShadow.

- Lorsqu’OuterShadow et PresetShadow sont utilisés ensemble, seul l’effet OuterShadow est appliqué. 
- Si OuterShadow et InnerShadow sont utilisés simultanément, l’effet résultant dépend de la version de PowerPoint. Par exemple, dans PowerPoint 2013, l’effet est doublé. Mais dans PowerPoint 2007, l’effet OuterShadow est appliqué. 

### Appliquer l’affichage aux textes

Nous ajoutons un affichage au texte via cet exemple de code en Python :
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


### Appliquer l’effet de lueur aux textes

Nous appliquons l’effet de lueur au texte pour le faire briller ou le faire ressortir à l’aide de ce code :
```py 
    portion.portion_format.effect_format.enable_glow_effect()
    portion.portion_format.effect_format.glow_effect.color.r = 255
    portion.portion_format.effect_format.glow_effect.color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.54)
    portion.portion_format.effect_format.glow_effect.radius = 7
```


Le résultat de l’opération :

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

Vous pouvez modifier les paramètres d’ombre, d’affichage et de lueur. Les propriétés des effets sont définies séparément pour chaque portion du texte. 

{{% /alert %}} 

### Utiliser les transformations dans WordArt

Nous utilisons la propriété Transform (inhérente à l’ensemble du bloc de texte) via ce code :
```py 
textFrame.text_frame_format.transform = slides.TextShapeType.ARCH_UP_POUR
```


Le résultat :

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Microsoft PowerPoint et Aspose.Slides for Python via .NET offrent un certain nombre de types de transformation prédéfinis. 

{{% /alert %}} 

**Utilisation de PowerPoint**

Pour accéder aux types de transformation prédéfinis, suivez : **Format** -> **TextEffect** -> **Transform**

**Utilisation d’Aspose.Slides**

Pour sélectionner un type de transformation, utilisez l’énumération TextShapeType. 

### Appliquer des effets 3D aux textes et aux formes

Nous appliquons un effet 3D à une forme de texte à l’aide de cet exemple de code :
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


Le résultat de l’opération :

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

L’application d’effets 3D aux textes ou à leurs formes ainsi que les interactions entre les effets sont basées sur certaines règles. 

Considérez une scène pour un texte et la forme contenant ce texte. L’effet 3D comprend la représentation d’un objet 3D et la scène sur laquelle l’objet est placé. 

- Lorsque la scène est définie à la fois pour la forme et pour le texte, la scène de la forme a la priorité supérieure — la scène du texte est ignorée. 
- Si la forme ne possède pas de scène propre mais possède une représentation 3D, la scène du texte est utilisée. 
- Sinon—si la forme n’a initialement aucun effet 3D—la forme est plane et l’effet 3D n’est appliqué qu’au texte. 

Les descriptions sont liées aux propriétés [ThreeDFormat.LightRig](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) et [ThreeDFormat.Camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/). 

{{% /alert %}} 

## **Appliquer des effets d’ombre externe aux textes**
Aspose.Slides for Python via .NET fournit les classes [**IOuterShadow**](https://reference.aspose.com/slides/python-net/aspose.slides.effects/ioutershadow/) et [**IInnerShadow**](https://reference.aspose.com/slides/python-net/aspose.slides.effects/iinnershadow/) qui permettent d’appliquer des effets d’ombre à un texte contenu dans TextFrame. Suivez les étapes suivantes :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).  
2. Obtenir la référence d’une diapositive en utilisant son indice.  
3. Ajouter une AutoShape de type Rectangle à la diapositive.  
4. Accéder au TextFrame associé à l’AutoShape.  
5. Définir la propriété FillType de l’AutoShape sur NoFill.  
6. Instancier la classe OuterShadow  
7. Définir la propriété BlurRadius de l’ombre.  
8. Définir la Direction de l’ombre  
9. Définir la Distance de l’ombre.  
10. Définir la propriété RectanglelAlign sur TopLeft.  
11. Définir la couleur prédéfinie (PresetColor) de l’ombre sur Black.  
12. Enregistrer la présentation sous forme de fichier PPTX.  

Ce code d’exemple en Python—une implémentation des étapes ci‑above—vous montre comment appliquer l’effet d’ombre externe à un texte :
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:

    # Obtenir la référence de la diapositive
    sld = pres.slides[0]

    # Ajouter un AutoShape de type Rectangle
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    # Ajouter un TextFrame au Rectangle
    ashp.add_text_frame("Aspose TextBox")

    # Désactiver le remplissage de la forme au cas où nous voulons obtenir l'ombre du texte
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Ajouter une ombre externe et définir tous les paramètres nécessaires
    ashp.effect_format.enable_outer_shadow_effect()
    shadow = ashp.effect_format.outer_shadow_effect
    shadow.blur_radius = 4.0
    shadow.direction = 45
    shadow.distance = 3
    shadow.rectangle_align = slides.RectangleAlignment.TOP_LEFT
    shadow.shadow_color.preset_color = slides.PresetColor.BLACK

    #Enregistrer la présentation sur le disque
    pres.save("pres_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Appliquer l’effet d’ombre interne aux formes**
Suivez ces étapes :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).  
2. Obtenir une référence de la diapositive.  
3. Ajouter une AutoShape du type Rectangle.  
4. Activer InnerShadowEffect.  
5. Définir tous les paramètres nécessaires.  
6. Définir la propriété ColorType sur Scheme.  
7. Définir la couleur du schéma.  
8. Enregistrer la présentation sous forme de fichier [PPTX](https://docs.fileformat.com/presentation/pptx/).  

Ce code d’exemple (basé sur les étapes ci‑above) vous montre comment ajouter un connecteur entre deux formes en Python :
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    # Obtenir la référence d'une diapositive
    slide = presentation.slides[0]

    # Ajouter un AutoShape de type Rectangle
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 400, 300)
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Ajouter un TextFrame au Rectangle
    ashp.add_text_frame("Aspose TextBox")
    port = ashp.text_frame.paragraphs[0].portions[0]
    pf = port.portion_format
    pf.font_height = 50

    # Activer inner_shadow_effect
    ef = pf.effect_format
    ef.enable_inner_shadow_effect()

    # Définir tous les paramètres nécessaires
    ef.inner_shadow_effect.blur_radius = 8.0
    ef.inner_shadow_effect.direction = 90.0
    ef.inner_shadow_effect.distance = 6.0
    ef.inner_shadow_effect.shadow_color.b = 189

    # Définir ColorType sur Scheme
    ef.inner_shadow_effect.shadow_color.color_type = slides.ColorType.SCHEME

    # Définir la couleur du schéma
    ef.inner_shadow_effect.shadow_color.scheme_color = slides.SchemeColor.ACCENT1

    # Enregistrer la présentation
    presentation.save("WordArt_out.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Puis‑je utiliser les effets WordArt avec différentes polices ou scripts (par ex., Arabe, Chinois) ?**

Oui, Aspose.Slides prend en charge Unicode et fonctionne avec toutes les principales polices et scripts. Les effets WordArt tels que l’ombre, le remplissage et le contour peuvent être appliqués quel que soit la langue, bien que la disponibilité des polices et le rendu puissent dépendre des polices du système.

**Puis‑je appliquer les effets WordArt aux éléments du masque des diapositives ?**

Oui, vous pouvez appliquer les effets WordArt aux formes sur les masques des diapositives, y compris les espaces réservés de titre, les pieds de page ou le texte d’arrière‑plan. Les modifications apportées à la disposition du masque seront reflétées sur toutes les diapositives associées.

**Les effets WordArt affectent‑ils la taille du fichier de la présentation ?**

Légèrement. Les effets WordArt comme les ombres, les lueurs et les remplissages en dégradé peuvent augmenter légèrement la taille du fichier en raison des métadonnées de formatage ajoutées, mais la différence est généralement négligeable.

**Puis‑je prévisualiser le résultat des effets WordArt sans enregistrer la présentation ?**

Oui, vous pouvez rendre les diapositives contenant du WordArt en images (par ex., PNG, JPEG) à l’aide de la méthode `get_image` de la classe [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) ou [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/). Cela vous permet de prévisualiser le résultat en mémoire ou à l’écran avant d’enregistrer ou d’exporter la présentation complète.