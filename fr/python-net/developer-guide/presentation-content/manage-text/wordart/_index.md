---
title: "Créer et appliquer des effets WordArt en Python"
linktitle: "WordArt"
type: docs
weight: 110
url: /fr/python-net/wordart/
keywords:
- "WordArt"
- "créer WordArt"
- "modèle WordArt"
- "effet WordArt"
- "effet d'ombre"
- "effet d'affichage"
- "effet de lueur"
- "transformation WordArt"
- "effet 3D"
- "effet d'ombre extérieure"
- "effet d'ombre intérieure"
- "Python"
- "Aspose.Slides"
description: "Apprenez à créer et personnaliser les effets WordArt dans Aspose.Slides for Python via .NET. Ce guide étape par étape aide les développeurs à enrichir les présentations avec du texte élégant et professionnel en Python."
---

## **À propos de WordArt ?**
WordArt ou Word Art est une fonctionnalité qui vous permet d’appliquer des effets aux textes afin de les faire ressortir. Avec WordArt, par exemple, vous pouvez tracer le contour d’un texte ou le remplir d’une couleur (ou d’un dégradé), ajouter des effets 3D, etc. Vous pouvez également incliner, plier et étirer la forme d’un texte. 

{{% alert color="primary" %}} 

WordArt vous permet de traiter un texte comme un objet graphique. WordArt consiste en des effets ou modifications spéciales appliqués aux textes pour les rendre plus attractifs ou visibles. 

{{% /alert %}} 

**WordArt dans Microsoft PowerPoint**

Pour utiliser WordArt dans Microsoft PowerPoint, vous devez sélectionner l’un des modèles WordArt prédéfinis. Un modèle WordArt est un ensemble d’effets appliqués à un texte ou à sa forme. 

**WordArt dans Aspose.Slides**

Dans Aspose.Slides for Python via .NET 20.10, nous avons ajouté la prise en charge de WordArt et amélioré la fonctionnalité dans les versions suivantes d’Aspose.Slides for Python via .NET. 

Avec Aspose.Slides for Python via .NET, vous pouvez facilement créer votre propre modèle WordArt (un effet ou une combinaison d’effets) en Python et l’appliquer aux textes. 

## Créer un modèle WordArt simple et l’appliquer à un texte

**En utilisant Aspose.Slides** 

Tout d’abord, nous créons un texte simple avec ce code Python : 

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

Ensuite, nous augmentons la hauteur de police du texte pour rendre l’effet plus visible avec ce code :

```py
    fontData = slides.FontData("Arial Black")
    portion.portion_format.latin_font = fontData
    portion.portion_format.font_height = 36
```

**En utilisant Microsoft PowerPoint**

Accédez au menu des effets WordArt dans Microsoft PowerPoint :

![todo:image_alt_text](image-20200930113926-1.png)

Dans le volet de droite, choisissez un effet WordArt prédéfini. Dans le volet de gauche, spécifiez les paramètres d’un nouveau WordArt. 

Voici quelques paramètres ou options disponibles :

![todo:image_alt_text](image-20200930114015-3.png)

**En utilisant Aspose.Slides**

Ici, nous appliquons la couleur de motif SmallGrid au texte et ajoutons une bordure noire de largeur 1 avec ce code :

```py
    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = draw.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = draw.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.SMALL_GRID
                
    portion.portion_format.line_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.line_format.fill_format.solid_fill_color.color = draw.Color.black
```

Le texte résultant :

![todo:image_alt_text](image-20200930114108-4.png)

## Appliquer d’autres effets WordArt

**En utilisant Microsoft PowerPoint**

Depuis l’interface du programme, vous pouvez appliquer ces effets à un texte, un bloc de texte, une forme ou un élément similaire :

![todo:image_alt_text](image-20200930114129-5.png)

Par exemple, les effets Ombre, Réflexion et Lueur peuvent être appliqués à un texte ; les effets Format 3D et Rotation 3D peuvent être appliqués à un bloc de texte ; la propriété Bords doux peut être appliquée à un objet Forme (cela a toujours un effet même lorsqu’aucune propriété Format 3D n’est définie). 

### Application des effets d’ombre

Ici, nous ne définissons les propriétés que pour le texte. Nous appliquons l’effet d’ombre à un texte avec ce code Python :

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

L’API Aspose.Slides prend en charge trois types d’ombres : OuterShadow, InnerShadow et PresetShadow. 

Avec PresetShadow, vous pouvez appliquer une ombre à un texte (en utilisant des valeurs prédéfinies). 

**En utilisant Microsoft PowerPoint**

Dans PowerPoint, vous ne pouvez utiliser qu’un type d’ombre. Exemple :

![todo:image_alt_text](image-20200930114225-6.png)

**En utilisant Aspose.Slides**

Aspose.Slides permet d’appliquer deux types d’ombres simultanément : InnerShadow et PresetShadow.

**Remarques :**

- Lorsque OuterShadow et PresetShadow sont combinés, seul l’effet OuterShadow est appliqué. 
- Si OuterShadow et InnerShadow sont utilisés en même temps, l’effet résultant dépend de la version de PowerPoint. Par exemple, sous PowerPoint 2013, l’effet est doublé. Sous PowerPoint 2007, l’effet OuterShadow est appliqué. 

### Application de l’effet d’affichage aux textes

Nous ajoutons l’effet d’affichage au texte avec cet extrait de code Python :

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

### Application de l’effet de lueur aux textes

Nous appliquons l’effet de lueur au texte pour le faire briller avec ce code :

```py
    portion.portion_format.effect_format.enable_glow_effect()
    portion.portion_format.effect_format.glow_effect.color.r = 255
    portion.portion_format.effect_format.glow_effect.color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.54)
    portion.portion_format.effect_format.glow_effect.radius = 7
```

Le résultat :

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

Vous pouvez modifier les paramètres d’ombre, d’affichage et de lueur. Les propriétés des effets sont définies séparément pour chaque portion du texte. 

{{% /alert %}} 

### Utilisation des transformations dans WordArt

Nous utilisons la propriété Transform (appliquée à tout le bloc de texte) avec ce code :

```py
textFrame.text_frame_format.transform = slides.TextShapeType.ARCH_UP_POUR
```

Le résultat :

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Microsoft PowerPoint et Aspose.Slides for Python via .NET proposent plusieurs types de transformations prédéfinies. 

{{% /alert %}} 

**En utilisant PowerPoint**

Accédez aux types de transformation prédéfinis via : **Format** → **Effet de texte** → **Transformer** 

**En utilisant Aspose.Slides**

Sélectionnez un type de transformation avec l’énumération TextShapeType. 

### Application d’effets 3D aux textes et aux formes

Nous appliquons un effet 3D à une forme texte avec cet exemple :

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

Le texte et sa forme résultants :

![todo:image_alt_text](image-20200930114816-9.png)

Nous appliquons un effet 3D au texte avec ce code Python :

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

Le résultat de l’opération :

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

L’application des effets 3D aux textes ou à leurs formes et les interactions entre effets suivent certaines règles. 

Considérez une scène pour le texte et la forme contenant ce texte. L’effet 3D comprend la représentation de l’objet 3D et la scène sur laquelle il est placé. 

- Si la scène est définie à la fois pour la forme et le texte, la scène de la forme a la priorité ; la scène du texte est ignorée. 
- Si la forme n’a pas de scène propre mais possède une représentation 3D, la scène du texte est utilisée. 
- Sinon—si la forme ne possède aucun effet 3D initial—la forme reste plate et l’effet 3D s’applique uniquement au texte. 

Les descriptions sont liées aux propriétés [ThreeDFormat.LightRig](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) et [ThreeDFormat.Camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/). 

{{% /alert %}} 

## **Appliquer des effets d’ombre extérieure aux textes**
Aspose.Slides for Python via .NET fournit les classes [**IOuterShadow**](https://reference.aspose.com/slides/python-net/aspose.slides.effects/ioutershadow/) et [**IInnerShadow**](https://reference.aspose.com/slides/python-net/aspose.slides.effects/iinnershadow/) qui permettent d’appliquer des effets d’ombre à un texte contenu dans un TextFrame. Suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).  
2. Obtenez la référence d’une diapositive en utilisant son indice.  
3. Ajoutez une AutoShape de type Rectangle à la diapositive.  
4. Accédez au TextFrame associé à l’AutoShape.  
5. Définissez le FillType de l’AutoShape sur NoFill.  
6. Instanciez la classe OuterShadow.  
7. Définissez le BlurRadius de l’ombre.  
8. Définissez la Direction de l’ombre.  
9. Définissez la Distance de l’ombre.  
10. Définissez le RectangleAlign sur TopLeft.  
11. Définissez le PresetColor de l’ombre sur Black.  
12. Enregistrez la présentation au format PPTX.  

Ce code Python — implémentation des étapes ci‑dessus — montre comment appliquer l’effet d’ombre extérieure à un texte :

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:

    # Obtenir la référence de la diapositive
    sld = pres.slides[0]

    # Ajouter une AutoShape de type Rectangle
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    # Ajouter un TextFrame au Rectangle
    ashp.add_text_frame("Aspose TextBox")

    # Désactiver le remplissage de la forme afin d’obtenir l’ombre du texte
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Ajouter l’ombre extérieure et définir tous les paramètres nécessaires
    ashp.effect_format.enable_outer_shadow_effect()
    shadow = ashp.effect_format.outer_shadow_effect
    shadow.blur_radius = 4.0
    shadow.direction = 45
    shadow.distance = 3
    shadow.rectangle_align = slides.RectangleAlignment.TOP_LEFT
    shadow.shadow_color.preset_color = slides.PresetColor.BLACK

    # Enregistrer la présentation sur le disque
    pres.save("pres_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Appliquer un effet d’ombre intérieure aux formes**
Suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).  
2. Obtenez la référence de la diapositive.  
3. Ajoutez une AutoShape de type Rectangle.  
4. Activez InnerShadowEffect.  
5. Définissez tous les paramètres nécessaires.  
6. Définissez le ColorType sur Scheme.  
7. Définissez la couleur Scheme.  
8. Enregistrez la présentation au format [PPTX](https://docs.fileformat.com/presentation/pptx/).  

Ce code Python (basé sur les étapes ci‑dessus) montre comment ajouter une ombre intérieure :

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    # Obtenir la référence d’une diapositive
    slide = presentation.slides[0]

    # Ajouter une AutoShape de type Rectangle
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

    # Définir la couleur Scheme
    ef.inner_shadow_effect.shadow_color.scheme_color = slides.SchemeColor.ACCENT1

    # Enregistrer la présentation
    presentation.save("WordArt_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Puis‑je utiliser les effets WordArt avec différentes polices ou systèmes d’écriture (par exemple, arabe, chinois )?**  
Oui, Aspose.Slides prend en charge Unicode et fonctionne avec toutes les principales polices et systèmes d’écriture. Les effets WordArt tels que l’ombre, le remplissage et le contour peuvent être appliqués quelle que soit la langue, bien que la disponibilité des polices et le rendu puissent dépendre des polices installées sur le système.

**Puis‑je appliquer les effets WordArt aux éléments du masque des diapositives ?**  
Oui, vous pouvez appliquer des effets WordArt aux formes des masques de diapositives, y compris les espaces réservés de titre, les pieds de page ou le texte d’arrière‑plan. Les modifications apportées au masque se répercutent sur toutes les diapositives qui en dépendent.

**Les effets WordArt influencent‑ils la taille du fichier de la présentation ?**  
Légèrement. Les effets WordArt comme les ombres, les lueurs et les remplissages en dégradé peuvent augmenter légèrement la taille du fichier en raison des métadonnées de formatage supplémentaires, mais la différence reste généralement négligeable.

**Puis‑je prévisualiser le résultat des effets WordArt sans enregistrer la présentation ?**  
Oui, vous pouvez rendre les diapositives contenant du WordArt en images (PNG, JPEG, etc.) à l’aide de la méthode `get_image` des classes [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) ou [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/). Cela vous permet de prévisualiser le résultat en mémoire ou à l’écran avant d’enregistrer ou d’exporter la présentation complète.