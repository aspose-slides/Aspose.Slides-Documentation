---
title: Gérer les thèmes de présentation PowerPoint en Python
linktitle: Thème de présentation
type: docs
weight: 10
url: /fr/python-net/presentation-theme/
keywords:
- Thème PowerPoint
- thème de présentation
- thème de diapositive
- définir le thème
- modifier le thème
- gérer le thème
- thème externe
- THMX
- couleur du thème
- palette supplémentaire
- police du thème
- style du thème
- effet du thème
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Maîtrisez les thèmes de présentation dans Aspose.Slides pour Python via .NET afin de créer, personnaliser et convertir des fichiers PowerPoint avec une identité visuelle cohérente."
---
## **Introduction**

Un thème de présentation définit un ensemble coordonné de couleurs, de polices, de styles d’arrière‑plan, de remplissages, de lignes et d’effets. Les objets sensibles au thème font référence à ces définitions partagées au lieu de stocker chaque propriété visuelle comme une valeur fixe, de sorte qu’un changement de thème peut mettre à jour de nombreux objets à la fois.

Dans Aspose.Slides, le thème au niveau de la présentation est disponible via la propriété [Presentation.master_theme](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/master_theme/). Une présentation peut également contenir des surcharges de thème à des niveaux inférieurs. Un master peut surcharger le thème de la présentation via [MasterThemeManager.override_theme](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/masterthememanager/override_theme/), une disposition peut surcharger son thème hérité via [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/), et une diapositive individuelle peut faire de même. En pratique, le thème effectif d’une diapositive est résolu grâce à cette chaîne d’héritage : thème de la présentation, surcharge du master, surcharge de la disposition et surcharge de la diapositive.

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

Les sections ci‑dessous montrent les flux de travail de thème les plus courants : inspecter un thème, modifier les couleurs et les polices, copier ou appliquer un thème, mettre à jour les styles d’arrière‑plan et d’effets, et lire les valeurs effectives après résolution de l’héritage et des surcharges.

## **Inspect a Theme**

L’objet [MasterTheme](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/mastertheme/) expose les propriétés du thème : [color_scheme](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/mastertheme/color_scheme/), [font_scheme](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/mastertheme/font_scheme/) et [format_scheme](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/mastertheme/format_scheme/). Inspecter ces collections avant de les modifier est particulièrement utile lorsqu’une présentation provient d’une source externe, car le nombre et le contenu des entrées de style peuvent varier.

L’exemple suivant lit les propriétés principales du thème et indique combien de styles d’arrière‑plan, de remplissage, de ligne et d’effet sont stockés dans le thème :

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    theme = presentation.master_theme
    print(f"Theme name: {theme.name}")
    print(f"Accent 1: {theme.color_scheme.accent1.color}")
    print(f"Major Latin font: {theme.font_scheme.major.latin_font.font_name}")
    print(f"Minor Latin font: {theme.font_scheme.minor.latin_font.font_name}")
    print(f"Background fill styles: {len(theme.format_scheme.background_fill_styles)}")
    print(f"Fill styles: {len(theme.format_scheme.fill_styles)}")
    print(f"Line styles: {len(theme.format_scheme.line_styles)}")
    print(f"Effect styles: {len(theme.format_scheme.effect_styles)}")
```

Si un fichier utilise plusieurs masters, ne supposez pas que chaque diapositive possède le même thème effectif. Inspectez le master associé à la diapositive et utilisez le flux de travail thème‑effectif présenté plus loin dans cet article lorsque des surcharges de disposition ou de diapositive peuvent être présentes.

## **Change Theme Colors**

Les remplissages, lignes et textes sensibles au thème peuvent faire référence à une couleur logique provenant de l’énumération [SchemeColor](https://reference.aspose.com/slides/fr/python-net/aspose.slides/schemecolor/). Lorsque vous modifiez l’entrée correspondante dans le [ColorScheme](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/colorscheme/) du thème, tous les objets qui référencent encore cette couleur de thème sont résolus avec la nouvelle valeur. Les objets qui utilisent une couleur RVB directe ne sont pas modifiés par une mise à jour de couleur de thème.

L’exemple de bout en bout suivant crée une forme qui utilise `ACCENT4`, modifie la couleur `accent4` du thème en rouge, enregistre la présentation, la rouvre et affiche la couleur de remplissage effective :

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    presentation.master_theme.color_scheme.accent4.color = draw.Color.red
    presentation.save("theme-color.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("theme-color.pptx") as saved_presentation:
    saved_slide = saved_presentation.slides[0]
    saved_shape = saved_slide.shapes[0]
    effective_fill = saved_shape.fill_format.get_effective()
    print(f"Effective fill color: {effective_fill.solid_fill_color}")
```

Comme le rectangle reste lié à `ACCENT4`, sa couleur visible devient rouge après le changement de thème. Si vous remplacez la couleur de palette par une couleur directe sur la forme, les modifications ultérieures de `accent4` n’affecteront plus ce remplissage.

### **Use Colors from the Additional Palette**

PowerPoint génère des variantes plus claires et plus foncées à partir d’une couleur de thème en appliquant des transformations de couleur. Aspose.Slides expose ces transformations via l’énumération [ColorTransformOperation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/colortransformoperation/).

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - Couleurs principales du thème.

**2** - Variantes plus claires et plus foncées produites à partir des couleurs principales du thème.

L’exemple suivant crée six rectangles basés sur `ACCENT4`, applique des transformations de luminance à cinq d’entre eux, puis enregistre le résultat :

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 50, 50)
    shape1.fill_format.fill_type = slides.FillType.SOLID
    shape1.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 50, 50)
    shape2.fill_format.fill_type = slides.FillType.SOLID
    shape2.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.2)
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.8)
    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 50, 50)
    shape3.fill_format.fill_type = slides.FillType.SOLID
    shape3.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.4)
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.6)
    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 50, 50)
    shape4.fill_format.fill_type = slides.FillType.SOLID
    shape4.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.6)
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.4)
    shape5 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 250, 50, 50)
    shape5.fill_format.fill_type = slides.FillType.SOLID
    shape5.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape5.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.75)
    shape6 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 50, 50)
    shape6.fill_format.fill_type = slides.FillType.SOLID
    shape6.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape6.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.5)
    presentation.save("theme-color-palette.pptx", slides.export.SaveFormat.PPTX)
```

Ces variantes restent basées sur la couleur de thème. Si `accent4` change ultérieurement, les couleurs transformées sont recalculées à partir de la nouvelle valeur `accent4`.

### **Map `SchemeColor` Values to `ColorScheme` Slots**

L’énumération [SchemeColor](https://reference.aspose.com/slides/fr/python-net/aspose.slides/schemecolor/) utilise `TEXT1`, `BACKGROUND1`, `TEXT2` et `BACKGROUND2`, tandis que [ColorScheme](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/colorscheme/) expose les mêmes emplacements du thème sous les noms `dark1`, `light1`, `dark2` et `light2`. Le mappage est fixe :

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

Ce sont des noms alternatifs pour les mêmes emplacements du thème ; ils ne sont pas des valeurs converties dynamiquement d’une forme à l’autre.

## **Change Theme Fonts**

Un jeu de polices de thème comprend un jeu de polices principal pour les titres et un jeu de polices secondaire pour le texte du corps. Les propriétés [FontScheme.major](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/fontscheme/major/) et [FontScheme.minor](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/fontscheme/minor/) exposent ces ensembles.

Les identifiants de police de thème compatibles PowerPoint peuvent être utilisés dans le formatage du texte :

* `+mn-lt` - Police du corps Latin (Minor Latin Font)
* `+mj-lt` - Police du titre Latin (Major Latin Font)
* `+mn-ea` - Police du corps Asie de l’Est (Minor East Asian Font)
* `+mj-ea` - Police du titre Asie de l’Est (Major East Asian Font)

L’exemple suivant crée un titre qui utilise la police majeure Latin du thème et une ligne de corps qui utilise la police mineure Latin du thème. Il modifie ensuite les polices du thème et enregistre le résultat :

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    heading = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 500, 60)
    heading.text_frame.text = "Theme heading"
    heading.text_frame.paragraphs[0].portions[0].portion_format.latin_font = slides.FontData("+mj-lt")
    body = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 120, 500, 60)
    body.text_frame.text = "Theme body text"
    body.text_frame.paragraphs[0].portions[0].portion_format.latin_font = slides.FontData("+mn-lt")
    presentation.master_theme.font_scheme.major.latin_font = slides.FontData("Aptos Display")
    presentation.master_theme.font_scheme.minor.latin_font = slides.FontData("Arial")
    presentation.save("theme-fonts.pptx", slides.export.SaveFormat.PPTX)
```

Le titre suit la police majeure et le texte du corps suit la police mineure. Le texte qui possède un nom de police explicite au lieu d’un identifiant de thème ne changera pas automatiquement lorsque le jeu de polices du thème évolue.

Les collections majeures et mineures peuvent également contenir des mappages de police pour des systèmes d’écriture individuels, tels que le cyrillique, l’arabe, le japonais, le géorgien et le thaana. Pour inspecter, ajouter, remplacer ou supprimer ces mappages, consultez [Script‑Specific Theme Fonts](/slides/fr/python-net/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Pour plus d’informations sur les polices de présentation, voir [PowerPoint Fonts](/slides/fr/python-net/powerpoint-fonts/).
{{% /alert %}}

## **Copy or Apply a Theme**

Les flux de travail ci‑dessous résolvent différents problèmes liés aux thèmes.

### **Apply an External Theme to a Master's Dependent Slides**

Utilisez [IMasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/fr/python-net/aspose.slides/imasterslide/apply_external_theme_to_depending_slides/) lorsque vous disposez d’un fichier de thème PowerPoint (`.thmx`) et que vous souhaitez re‑styler chaque diapositive qui dépend d’un master particulier. Sélectionnez le master dans la collection [Presentation.masters](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/masters/), qui implémente [MasterSlideCollection](https://reference.aspose.com/slides/fr/python-net/aspose.slides/masterslidecollection/), et transmettez le chemin du fichier de thème à la méthode.

La méthode effectue les opérations suivantes :

1. Crée un nouveau master slide basé sur le master sélectionné.
1. Applique le thème externe au nouveau master.
1. Assigne le nouveau master à toutes les diapositives qui dépendaient auparavant du master sélectionné.
1. Retourne le nouvel [IMasterSlide](https://reference.aspose.com/slides/fr/python-net/aspose.slides/imasterslide/).

L’exemple suivant applique un thème externe aux diapositives qui dépendent du premier master et enregistre la présentation :

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    selected_master = presentation.masters[0]
    themed_master = selected_master.apply_external_theme_to_depending_slides("corporate-theme.thmx")

    print(f"Created master: {themed_master.name}")
    presentation.save("presentation-with-external-theme.pptx", slides.export.SaveFormat.PPTX)
```

Un thème invalide, corrompu ou non pris en charge peut déclencher une [PptxException](https://reference.aspose.com/slides/fr/python-net/aspose.slides/pptxexception/) ou l’une de ses sous‑classes liées au format. Validez les chemins fournis par les utilisateurs, gérez les échecs d’accès au système de fichiers et n’enregistrez la présentation qu’après l’application réussie du thème.

Seules les diapositives qui dépendaient du master sélectionné sont réassignées. Les diapositives associées à d’autres masters conservent leurs masters et leurs thèmes existants. Les couleurs, polices, remplissages, lignes, arrière‑plans et effets sensibles au thème sont résolus par rapport au thème externe. Les couleurs, polices, remplissages et autres formats attribués directement peuvent rester inchangés. Les surcharges au niveau de la disposition ou de la diapositive peuvent également prévaloir sur les valeurs héritées du nouveau master.

Le thème peut référencer des polices non disponibles dans l’environnement d’exécution. Pour un rendu et une exportation cohérents, installez les polices requises, fournissez‑les via [custom font sources](/slides/fr/python-net/custom-font/), ou configurez la [font substitution](/slides/fr/python-net/font-substitution/).

Il s’agit d’un flux de travail direct au niveau du master : la méthode accepte un chemin de fichier `.thmx` et ne nécessite pas de créer manuellement des surcharges de thème au niveau de la disposition ou de la diapositive.

### **Apply Different External Themes in a Multi-Master Presentation**

Lorsque le master concerné n’est pas connu à l’avance, récupérez‑le à partir d’une diapositive représentative via [Slide.layout_slide](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slide/layout_slide/) et [LayoutSlide.master_slide](https://reference.aspose.com/slides/fr/python-net/aspose.slides/layoutslide/master_slide/). Conservez les références des masters d’origine avant d’appliquer des thèmes, car chaque appel crée un nouveau master dans la présentation.

L’exemple suivant utilise des diapositives provenant de deux sections pour localiser leurs masters et applique un thème externe différent à chaque groupe :

```python
import aspose.slides as slides

with slides.Presentation("multi-master-presentation.pptx") as presentation:
    if len(presentation.slides) < 5:
        print("The presentation does not contain the expected representative slides.")
    else:
        first_group_master = presentation.slides[0].layout_slide.master_slide
        second_group_master = presentation.slides[4].layout_slide.master_slide

        if first_group_master.slide_id == second_group_master.slide_id:
            print("The representative slides use the same master.")
        else:
            first_themed_master = first_group_master.apply_external_theme_to_depending_slides("blue-theme.thmx")
            second_themed_master = second_group_master.apply_external_theme_to_depending_slides("green-theme.thmx")

            print(f"First themed master: {first_themed_master.name}")
            print(f"Second themed master: {second_themed_master.name}")
            presentation.save("multi-master-with-external-themes.pptx", slides.export.SaveFormat.PPTX)
```

Le premier appel ne concerne que les diapositives qui dépendaient de `first_group_master`, et le second appel ne concerne que celles qui dépendaient de `second_group_master`. Les diapositives appartenant à un autre master ne sont pas re‑stylées.

### **Preserve a Source Theme When Moving Slides**

Si vous devez déplacer une diapositive vers une autre présentation tout en conservant son design d’origine, clonez le master source dans la présentation cible avec [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/fr/python-net/aspose.slides/masterslidecollection/add_clone/), puis clonez la diapositive avec [SlideCollection.add_clone](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slidecollection/add_clone/) et le master cloné. Cela transporte le master, ses dispositions et le thème associé ensemble.

```python
import aspose.slides as slides

with slides.Presentation("source-theme.pptx") as source:
    with slides.Presentation("target.pptx") as target:
        source_slide = source.slides[0]
        source_master = source_slide.layout_slide.master_slide
        cloned_master = target.masters.add_clone(source_master)
        target.slides.add_clone(source_slide, cloned_master, True)
        target.save("theme-preserved.pptx", slides.export.SaveFormat.PPTX)
```

C’est le flux de travail recommandé lorsque la diapositive source doit apparaître identiquement dans la destination. Le simple clonage du contenu sur un master de destination non lié peut modifier les couleurs, polices, arrière‑plans et effets pilotés par le thème.

### **Apply Theme Values to an Existing Slide**

Si la diapositive cible doit rester sur son master et sa disposition actuels, initialisez une surcharge au niveau de la diapositive à partir du thème source. Les méthodes [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/), [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/) et [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) copient les trois principaux composants du thème dans la surcharge.

```python
import aspose.slides as slides

with slides.Presentation("source-theme.pptx") as source:
    with slides.Presentation("target.pptx") as target:
        target_slide = target.slides[0]
        override_theme = target_slide.theme_manager.override_theme
        override_theme.init_color_scheme_from(source.master_theme.color_scheme)
        override_theme.init_font_scheme_from(source.master_theme.font_scheme)
        override_theme.init_format_scheme_from(source.master_theme.format_scheme)
        target.save("theme-applied-to-slide.pptx", slides.export.SaveFormat.PPTX)
```

Cela modifie le thème utilisé par cette diapositive sans changer le thème hérité par les autres diapositives. Pour supprimer la surcharge locale et revenir aux valeurs héritées, appelez [OverrideTheme.clear](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/overridetheme/clear/).

### **Apply a Theme Override to a Layout**

Une surcharge au niveau de la disposition s’applique aux diapositives qui utilisent cette disposition, sauf si une diapositive possède sa propre surcharge. Les mêmes méthodes d’initialisation peuvent être utilisées via le [LayoutSlideThemeManager](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/layoutslidethememanager/) de la disposition :

```python
import aspose.slides as slides

with slides.Presentation("source-theme.pptx") as source:
    with slides.Presentation("target.pptx") as target:
        target_slide = target.slides[0]
        override_theme = target_slide.layout_slide.theme_manager.override_theme
        override_theme.init_color_scheme_from(source.master_theme.color_scheme)
        override_theme.init_font_scheme_from(source.master_theme.font_scheme)
        override_theme.init_format_scheme_from(source.master_theme.format_scheme)
        target.save("theme-applied-to-layout.pptx", slides.export.SaveFormat.PPTX)
```

Utilisez un thème au niveau du master ou de la présentation lorsque de nombreuses dispositions et diapositives doivent partager le même design de base, une surcharge de disposition lorsqu’une famille de dispositions nécessite un style différent, et une surcharge de diapositive uniquement pour les exceptions réelles. Un excès de surcharges au niveau de la diapositive rend les modifications globales du thème plus difficiles à prévoir.

## **Update Theme Background Styles**

Les remplissages d’arrière‑plan du thème sont stockés dans [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/formatscheme/background_fill_styles/). PowerPoint peut présenter davantage d’options d’arrière‑plan dans son interface que le nombre de définitions de remplissage réellement stockées dans cette collection, car l’interface peut combiner les remplissages de thème avec les couleurs de thème et d’autres références de style.

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

Avant d’utiliser un style d’arrière‑plan, inspectez la collection stockée et la propriété actuelle [Background.style_index](https://reference.aspose.com/slides/fr/python-net/aspose.slides/background/style_index/). `style_index` utilise `0` pour aucun remplissage thématisé ; les valeurs positives sont des références de style d’arrière‑plan du thème. Cela diffère de l’indexation directe d’une collection Python, où `[0]` désigne le premier élément stocké. Ne supposez pas que chaque présentation contient le même nombre de styles de remplissage d’arrière‑plan.

L’exemple suivant indique le nombre de remplissages d’arrière‑plan disponibles, associe une référence d’arrière‑plan thématisé au premier master et enregistre la présentation :

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    background_styles = presentation.master_theme.format_scheme.background_fill_styles
    print(f"Background fill styles: {len(background_styles)}")
    if len(background_styles) == 0:
        raise RuntimeError("The presentation theme does not contain background fill styles.")
    master_slide = presentation.masters[0]
    master_slide.background.type = slides.BackgroundType.THEMED
    master_slide.background.style_index = 1
    presentation.save("theme-background.pptx", slides.export.SaveFormat.PPTX)
```

Le rendu visible dépend de l’entrée de thème référencée par le master et de toute surcharge d’arrière‑plan au niveau de la disposition ou de la diapositive. Si une diapositive utilise son propre arrière‑plan, modifier uniquement l’arrière‑plan du master peut ne pas affecter cette diapositive. Utilisez [Background.get_effective](https://reference.aspose.com/slides/fr/python-net/aspose.slides/background/get_effective/) lorsque vous devez connaître l’arrière‑plan final après application de l’héritage.

{{% alert color="warning" title="Warning" %}}
Ne traitez pas `style_index` comme un indice de collection zéro‑based. Évitez également de coder en dur un numéro de style provenant d’un fichier et de supposer qu’il aura le même aspect dans un autre fichier ; les définitions de style du thème sont propres à chaque présentation.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Pour le formatage direct de l’arrière‑plan et l’héritage de l’arrière‑plan, consultez [Presentation Background](/slides/fr/python-net/presentation-background/).
{{% /alert %}}

## **Update Theme Effects**

Un schéma de format de thème contient des collections séparées : [FormatScheme.fill_styles](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/formatscheme/fill_styles/), [FormatScheme.line_styles](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/formatscheme/line_styles/) et [FormatScheme.effect_styles](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/formatscheme/effect_styles/). Les thèmes Office typiques contiennent souvent trois entrées de style principales qui correspondent visuellement à des formats subtils, modérés et intenses, mais le code doit inspecter chaque collection plutôt que de supposer un nombre fixe.

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

Lorsque vous accédez à ces collections en Python, l’indice de collection est zéro‑based : `[0]` désigne le premier style stocké et `[2]` le troisième. Les indices de référence de style d’une forme constituent un concept distinct, exposé via [IShapeStyle](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ishapestyle/). Modifier un style de thème affecte les formes qui le référencent ; les formes avec un formatage direct peuvent rester inchangées.

L’exemple suivant vérifie que les entrées de style requises existent, modifie le premier style de ligne, modifie le troisième style de remplissage, active une ombre extérieure dans le troisième style d’effet, puis enregistre le résultat :

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("Subtle_Moderate_Intense.pptx") as presentation:
    format_scheme = presentation.master_theme.format_scheme
    if len(format_scheme.line_styles) < 1 or len(format_scheme.fill_styles) < 3 or len(format_scheme.effect_styles) < 3:
        raise RuntimeError("The theme does not contain the style entries required by this example.")
    format_scheme.line_styles[0].fill_format.fill_type = slides.FillType.SOLID
    format_scheme.line_styles[0].fill_format.solid_fill_color.color = draw.Color.red
    format_scheme.fill_styles[2].fill_type = slides.FillType.SOLID
    format_scheme.fill_styles[2].solid_fill_color.color = draw.Color.forest_green
    format_scheme.effect_styles[2].effect_format.enable_outer_shadow_effect()
    format_scheme.effect_styles[2].effect_format.outer_shadow_effect.distance = 10
    presentation.save("theme-effects.pptx", slides.export.SaveFormat.PPTX)
```

Pour les formes qui référencent ces emplacements, le premier style de ligne du thème devient rouge, le troisième style de remplissage du thème devient vert forêt plein, et le troisième style d’effet gagne une ombre extérieure avec une distance de 10 points. Le rendu exact dépend toujours des emplacements de style référencés par chaque forme et d’éventuels formats directs qui prévalent sur le thème.

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **Determine Whether an Effective Solid Fill Uses a Theme Color**

Un remplissage peut être stocké directement sur un objet ou hérité d’un paragraphe, d’une disposition, d’un master, d’un style de thème ou d’un autre niveau de formatage. Appelez [FillFormat.get_effective](https://reference.aspose.com/slides/fr/python-net/aspose.slides/fillformat/get_effective/) pour résoudre cette hiérarchie en un objet immuable [IFillFormatEffectiveData](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ifillformateffectivedata/). Commencez par vérifier [IFillFormatEffectiveData.fill_type](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ifillformateffectivedata/fill_type/). Ce n’est que lorsqu’il est `FillType.SOLID` que vous devez lire les propriétés du remplissage plein.

Pour un remplissage plein, [IFillFormatEffectiveData.solid_fill_color](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ifillformateffectivedata/solid_fill_color/) renvoie la valeur RVB finale rendue après application de l’héritage, de la recherche dans le thème et des transformations de couleur. [IFillFormatEffectiveData.solid_fill_scheme_color](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ifillformateffectivedata/solid_fill_scheme_color/) renvoie l’emplacement logique [SchemeColor](https://reference.aspose.com/slides/fr/python-net/aspose.slides/schemecolor/) correspondant, tel que `TEXT1` ou `ACCENT6`. Une valeur `SchemeColor.NOT_DEFINED` signifie que le remplissage plein effectif n’est pas basé sur une couleur de palette. Dans un flux de travail où les remplissages sont soit des couleurs de thème, soit des couleurs RVB directes, cette valeur identifie un remplissage RVB direct.

N’utilisez pas uniquement la valeur locale [IColorFormat.scheme_color](https://reference.aspose.com/slides/fr/python-net/aspose.slides/icolorformat/scheme_color/) pour classer un remplissage. Par exemple, une portion de texte peut ne pas avoir de couleur de palette définie localement, son valeur locale est donc `NOT_DEFINED`, tandis que son remplissage effectif hérite d’une couleur de thème et se résout en `TEXT1` ou `ACCENT6`. Inversement, `solid_fill_scheme_color` indique quel emplacement logique du thème a produit la couleur effective, mais ne précise pas si cet emplacement provient de l’objet, du paragraphe, de la disposition, du master ou d’un autre niveau de la hiérarchie de formatage.

L’exemple suivant charge une présentation, audite les remplissages des formes et des portions de texte, affiche chaque valeur RVB finale et la couleur de palette associée, et signale les remplissages pleins qui ne suivront pas les changements de couleur du thème :

```python
import aspose.slides as slides


def audit_fill(object_name, local_fill):
    effective_fill = local_fill.get_effective()

    if effective_fill.fill_type != slides.FillType.SOLID:
        print(f"{object_name}: fill type = {effective_fill.fill_type}; not a solid fill.")
        return

    rgb = effective_fill.solid_fill_color
    effective_scheme_color = effective_fill.solid_fill_scheme_color
    local_scheme_color = local_fill.solid_fill_color.scheme_color

    print(f"{object_name}: RGB = #{rgb.r:02X}{rgb.g:02X}{rgb.b:02X}")
    print(f"{object_name}: local scheme = {local_scheme_color}, effective scheme = {effective_scheme_color}")

    if effective_scheme_color == slides.SchemeColor.NOT_DEFINED:
        print(f"{object_name}: direct RGB or another non-scheme fill; audit as theme-independent.")
    else:
        print(f"{object_name}: theme-dependent through {effective_scheme_color}.")


with slides.Presentation("input.pptx") as presentation:
    for slide_index, slide in enumerate(presentation.slides):
        for shape_index, shape in enumerate(slide.shapes):
            shape_name = f"Slide {slide_index + 1}, shape {shape_index + 1}"
            audit_fill(shape_name, shape.fill_format)

            if isinstance(shape, slides.AutoShape):
                for paragraph_index, paragraph in enumerate(shape.text_frame.paragraphs):
                    for portion_index, portion in enumerate(paragraph.portions):
                        portion_name = f"{shape_name}, paragraph {paragraph_index + 1}, portion {portion_index + 1}"
                        audit_fill(portion_name, portion.portion_format.fill_format)
```

La branche `NOT_DEFINED` fournit une liste d’audit des remplissages pleins qui ne réagiront pas aux modifications des emplacements de couleur du thème. Examinez ces objets lorsqu’une présentation doit suivre une nouvelle palette de marque. La valeur RVB signalée montre toujours l’apparence actuelle, tandis que la valeur de palette explique si cette apparence est liée au thème.

Les objets de format effectif sont des instantanés. Après avoir modifié le thème de la présentation, une surcharge de thème ou tout formatage hérité, appelez à nouveau `get_effective` et lisez un nouvel objet `IFillFormatEffectiveData` avant de comparer ou de rapporter les couleurs.

## **Read Effective Theme Values**

Les objets de thème bruts indiquent ce qui est défini à un niveau particulier. Les valeurs effectives indiquent ce qu’une diapositive ou une forme utilise réellement après résolution de l’héritage et des surcharges locales. Pour une diapositive, appelez [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/). Pour un arrière‑plan, utilisez [Background.get_effective](https://reference.aspose.com/slides/fr/python-net/aspose.slides/background/get_effective/), et pour un remplissage, utilisez [FillFormat.get_effective](https://reference.aspose.com/slides/fr/python-net/aspose.slides/fillformat/get_effective/).

L’exemple suivant lit le thème effectif, l’arrière‑plan et le premier remplissage de forme d’une diapositive :

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]
    effective_theme = slide.theme_manager.create_theme_effective()
    effective_background = slide.background.get_effective()
    print(f"Effective major Latin font: {effective_theme.font_scheme.major.latin_font.font_name}")
    print(f"Effective minor Latin font: {effective_theme.font_scheme.minor.latin_font.font_name}")
    print(f"Effective background fill type: {effective_background.fill_format.fill_type}")
    if len(slide.shapes) > 0:
        effective_fill = slide.shapes[0].fill_format.get_effective()
        print(f"First shape effective fill type: {effective_fill.fill_type}")
        if effective_fill.fill_type == slides.FillType.SOLID:
            print(f"First shape effective fill color: {effective_fill.solid_fill_color}")
```

Utilisez les données effectives pour le diagnostic de rendu, la validation et les comparaisons. Si vous inspectez uniquement [Presentation.master_theme](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/master_theme/), vous risquez de manquer une surcharge de master, de disposition, de diapositive ou de forme qui modifie l’apparence finale.

## **FAQ**

**Does applying an external theme affect every slide in the presentation?**

Non. [IMasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/fr/python-net/aspose.slides/imasterslide/apply_external_theme_to_depending_slides/) ne réaffecte que les diapositives qui dépendent du master sélectionné. Les diapositives utilisant d’autres masters conservent leurs thèmes existants.

**Can I apply a theme to a single slide without changing the master?**

Oui. Utilisez le [SlideThemeManager](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/slidethememanager/) de la diapositive et initialisez sa surcharge de thème. Le changement reste local à cette diapositive ; les autres diapositives continuent d’hériter de leurs thèmes existants.

**What is the safest way to carry a theme from one presentation to another?**

Lors du déplacement d’une diapositive tout en préservant son apparence source, clonez le master source dans la destination et clonez la diapositive avec ce master à l’aide de [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/fr/python-net/aspose.slides/masterslidecollection/add_clone/) et [SlideCollection.add_clone](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slidecollection/add_clone/). Cela conserve le master, les dispositions et le thème ensemble.

**How can I see the effective values after inheritance and overrides?**

Utilisez [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) pour un thème de diapositive ou de disposition et les méthodes de données effectives correspondantes pour les objets de format tels que [Background.get_effective](https://reference.aspose.com/slides/fr/python-net/aspose.slides/background/get_effective/) et [FillFormat.get_effective](https://reference.aspose.com/slides/fr/python-net/aspose.slides/fillformat/get_effective/). Ces API renvoient les valeurs résolues après application de l’héritage et des surcharges.