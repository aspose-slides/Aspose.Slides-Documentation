---
title: Gérer les thèmes de présentation PowerPoint en Python
linktitle: Thème de présentation
type: docs
weight: 10
url: /fr/python-net/presentation-theme/
keywords:
- thème PowerPoint
- thème de présentation
- thème de diapositive
- définir le thème
- changer le thème
- gérer le thème
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
description: "Maîtrisez les thèmes de présentation dans Aspose.Slides pour Python via .NET pour créer, personnaliser et convertir des fichiers PowerPoint avec une identité visuelle cohérente."
---
## **Introduction**

Un thème de présentation définit un ensemble coordonné de couleurs, de polices, de styles d’arrière‑plan, de remplissages, de lignes et d’effets. Les objets sensibles au thème se réfèrent à ces définitions partagées au lieu de stocker chaque propriété visuelle comme une valeur fixe, de sorte qu’un changement de thème peut mettre à jour de nombreux objets en même temps.

Dans Aspose.Slides, le thème au niveau de la présentation est disponible via la propriété [Presentation.master_theme](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/master_theme/). Une présentation peut également contenir des substitutions de thème à des niveaux inférieurs. Un master peut substituer le thème de la présentation via [MasterThemeManager.override_theme](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/masterthememanager/override_theme/), une disposition peut substituer son thème hérité via [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/), et une diapositive individuelle peut faire de même. En pratique, le thème effectif d’une diapositive est résolu grâce à cette chaîne d’héritage : thème de présentation, substitution du master, substitution de la disposition et substitution de la diapositive.

![Composants du thème : couleurs, polices, styles d’arrière‑plan et effets](theme-constituents.png)

Les sections ci‑dessous montrent les flux de travail les plus courants : inspecter un thème, modifier les couleurs et les polices, copier ou appliquer un thème, mettre à jour les styles d’arrière‑plan et d’effets, et lire les valeurs effectives après résolution des héritages et des substitutions.

## **Inspecter un thème**

L’objet [MasterTheme](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/mastertheme/) expose les propriétés [color_scheme](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/mastertheme/color_scheme/), [font_scheme](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/mastertheme/font_scheme/) et [format_scheme](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/mastertheme/format_scheme/). Inspecter ces collections avant de les modifier est particulièrement utile lorsqu’une présentation provient d’une source externe, car le nombre et le contenu des entrées de style peuvent varier.

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

Si un fichier utilise plusieurs masters, ne supposez pas que chaque diapositive possède le même thème effectif. Inspectez le master associé à la diapositive, et utilisez le flux de travail du thème effectif présenté plus tard dans cet article lorsqu’une substitution de disposition ou de diapositive peut être présente.

## **Modifier les couleurs du thème**

Les remplissages, lignes et textes sensibles au thème peuvent se référer à une couleur logique de l’énumération [SchemeColor](https://reference.aspose.com/slides/fr/python-net/aspose.slides/schemecolor/). Lorsque vous modifiez l’entrée correspondante dans le [ColorScheme](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/colorscheme/) du thème, tous les objets qui référencent encore cette couleur de thème sont résolus avec la nouvelle valeur. Les objets qui utilisent une couleur RVB directe ne sont pas modifiés par la mise à jour d’une couleur de thème.

L’exemple de bout en bout suivant crée une forme qui utilise `ACCENT4`, change la couleur `accent4` du thème en rouge, enregistre la présentation, la rouvre et affiche la couleur de remplissage effective :

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

Comme le rectangle reste lié à `ACCENT4`, sa couleur visible devient rouge après la modification du thème. Si vous remplacez la couleur du schéma par une couleur directe sur la forme, les modifications ultérieures de `accent4` n’affecteront plus ce remplissage.

### **Utiliser les couleurs de la palette supplémentaire**

PowerPoint génère des variantes plus claires et plus sombres à partir d’une couleur de thème en appliquant des transformations de couleur. Aspose.Slides expose ces transformations via l’énumération [ColorTransformOperation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/colortransformoperation/).

![Couleurs principales du thème et couleurs plus claires et plus sombres générées à partir de la palette supplémentaire](additional-palette-colors.png)

**1** - Couleurs principales du thème.  

**2** - Variantes plus claires et plus sombres produites à partir des couleurs principales du thème.

L’exemple suivant crée six rectangles basés sur `ACCENT4`, applique des transformations de luminance à cinq d’entre eux et enregistre le résultat :

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

Ces variantes restent basées sur la couleur du thème. Si `accent4` change ultérieurement, les couleurs transformées sont recalculées à partir de la nouvelle valeur `accent4`.

### **Mapper les valeurs `SchemeColor` aux emplacements `ColorScheme`**

L’énumération [SchemeColor](https://reference.aspose.com/slides/fr/python-net/aspose.slides/schemecolor/) utilise `TEXT1`, `BACKGROUND1`, `TEXT2` et `BACKGROUND2`, tandis que [ColorScheme](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/colorscheme/) expose les mêmes emplacements de thème sous les noms `dark1`, `light1`, `dark2` et `light2`. Le mapping est fixe :

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

Ce ne sont que des noms alternatifs pour les mêmes emplacements de thème ; ils ne sont pas des valeurs converties dynamiquement d’une forme à l’autre.

## **Modifier les polices du thème**

Un schéma de polices de thème contient un jeu de polices principal pour les titres et un jeu secondaire pour le corps du texte. Les propriétés [FontScheme.major](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/fontscheme/major/) et [FontScheme.minor](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/fontscheme/minor/) exposent ces jeux.

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

Le titre suit la police majeure et le texte du corps suit la police mineure. Un texte qui possède un nom de police explicite au lieu d’un identifiant de thème ne changera pas automatiquement lorsque le schéma de polices du thème change.

Les collections majeures et mineures peuvent aussi contenir des correspondances de polices pour des systèmes d’écriture individuels, tels que le cyrillique, l’arabe, le japonais, le géorgien et le thaana. Pour inspecter, ajouter, remplacer ou supprimer ces correspondances, consultez [Script-Specific Theme Fonts](/slides/fr/python-net/script-specific-font-mappings/).

{{% alert color="info" title="Astuce" %}}
Pour plus d’informations sur les polices de présentation, consultez [Polices PowerPoint](/slides/fr/python-net/powerpoint-fonts/).
{{% /alert %}}

## **Copier ou appliquer un thème**

Il existe deux flux de travail courants, qui résolvent des problèmes différents.

### **Conserver le thème source lors du déplacement de diapositives**

Si vous souhaitez déplacer une diapositive vers une autre présentation tout en conservant son design d’origine, clonez le master source dans la présentation cible avec [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/fr/python-net/aspose.slides/masterslidecollection/add_clone/), puis clonez la diapositive avec [SlideCollection.add_clone](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slidecollection/add_clone/) et le master cloné. Cela transporte le master, ses dispositions et le thème associé.

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

C’est le flux de travail recommandé lorsque la diapositive source doit conserver exactement le même aspect dans la destination. Cloner simplement le contenu sur un master de destination non lié peut modifier les couleurs, polices, arrière‑plans et effets pilotés par le thème.

### **Appliquer les valeurs du thème à une diapositive existante**

Si la diapositive cible doit rester sur son master et sa disposition actuels, initialisez une substitution au niveau de la diapositive à partir du thème source. Les méthodes [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/), [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/), et [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) copient les trois principaux composants du thème dans la substitution.

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

Cela modifie le thème utilisé par cette diapositive sans changer le thème hérité par les autres diapositives. Pour supprimer la substitution locale et revenir aux valeurs héritées, appelez [OverrideTheme.clear](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/overridetheme/clear/).

### **Appliquer une substitution de thème à une disposition**

Une substitution au niveau de la disposition s’applique aux diapositives qui utilisent cette disposition, sauf si une diapositive particulière possède sa propre substitution. Les mêmes méthodes d’initialisation peuvent être utilisées via le [LayoutSlideThemeManager](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/layoutslidethememanager/) de la disposition :

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

Utilisez un thème au niveau du master ou de la présentation lorsque de nombreuses dispositions et diapositives doivent partager le même design de base, une substitution de disposition lorsqu’une famille de dispositions nécessite un style différent, et une substitution de diapositive uniquement pour de vérituelles exceptions. Un excès de substitutions au niveau des diapositives rend les changements globaux de thème ultérieurs plus difficiles à prévoir.

## **Mettre à jour les styles d’arrière‑plan du thème**

Les remplissages d’arrière‑plan du thème sont stockés dans [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/formatscheme/background_fill_styles/). PowerPoint peut présenter davantage d’options d’arrière‑plan dans son interface que le nombre de définitions de remplissage réellement stockées dans cette collection, car l’UI peut combiner les remplissages du thème avec les couleurs du thème et d’autres références de style.

![Galerie de styles d’arrière‑plan PowerPoint pour un thème de présentation](presentation-design_8.png)

Avant d’utiliser un style d’arrière‑plan, inspectez la collection stockée et l’attribut actuel [Background.style_index](https://reference.aspose.com/slides/fr/python-net/aspose.slides/background/style_index/). `style_index` utilise `0` pour aucun remplissage thématisé ; les valeurs positives sont des références de style d’arrière‑plan du thème. Ceci diffère de l’indexation d’une collection Python où `[0]` représente le premier élément stocké. Ne supposez pas que chaque présentation contienne le même nombre de styles de remplissage d’arrière‑plan.

L’exemple suivant indique le nombre de remplissages d’arrière‑plan disponibles, attribue une référence d’arrière‑plan thématisé au premier master et enregistre la présentation :

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

Le résultat visible dépend de l’entrée du thème référencée par le master et des éventuelles substitutions d’arrière‑plan au niveau de la disposition ou de la diapositive. Si une diapositive utilise son propre arrière‑plan, modifier uniquement l’arrière‑plan du master peut ne pas affecter cette diapositive. Utilisez [Background.get_effective](https://reference.aspose.com/slides/fr/python-net/aspose.slides/background/get_effective/) lorsque vous avez besoin de connaître l’arrière‑plan final après application de l’héritage.

{{% alert color="warning" title="Avertissement" %}}
Ne traitez pas `style_index` comme un indice de collection basé sur zéro. Évitez également de coder en dur un numéro de style d’un fichier et de supposer qu’il aura le même aspect dans un autre fichier ; les définitions de style du thème sont spécifiques à chaque présentation.
{{% /alert %}}

{{% alert color="info" title="Astuce" %}}
Pour le formatage d’arrière‑plan direct et l’héritage d’arrière‑plan, consultez [Arrière‑plan de la présentation](/slides/fr/python-net/presentation-background/).
{{% /alert %}}

## **Mettre à jour les effets du thème**

Un schéma de format de thème contient les collections séparées [FormatScheme.fill_styles](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/formatscheme/fill_styles/), [FormatScheme.line_styles](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/formatscheme/line_styles/) et [FormatScheme.effect_styles](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/formatscheme/effect_styles/). Les thèmes Office typiques contiennent souvent trois entrées principales correspondant visuellement à des formats subtils, modérés et intenses, mais le code doit inspecter chaque collection plutôt que de supposer un nombre fixe.

![Effets de thème subtils, modérés et intenses appliqués à la même forme](presentation-design_10.png)

Lorsque vous accédez à ces collections en Python, l’indice de collection commence à zéro : `[0]` est le premier style stocké et `[2]` le troisième. Les indices de référence de style d’une forme constituent un concept distinct, exposé via [IShapeStyle](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ishapestyle/). Modifier un style de thème affecte les formes qui le référencent ; les formes avec un formatage direct peuvent rester inchangées.

L’exemple suivant vérifie que les entrées de style requises existent, modifie le premier style de ligne, modifie le troisième style de remplissage, active une ombre extérieure dans le troisième style d’effet et enregistre le résultat :

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

Pour les formes qui référencent ces emplacements, le premier style de ligne du thème devient rouge, le troisième style de remplissage du thème devient vert forêt opaque, et le troisième style d’effet gagne une ombre extérieure avec une distance de 10 points. Le rendu visuel exact dépend toujours des emplacements de style référencés par chaque forme et d’éventuels formatages directs qui remplacent le thème.

![Styles d’effet du thème après modification des paramètres de ligne, de remplissage et d’ombre](presentation-design_11.png)

## **Lire les valeurs effectives du thème**

Les objets de thème bruts indiquent ce qui est défini à un niveau particulier. Les valeurs effectives indiquent ce qu’une diapositive ou une forme utilise réellement après résolution des héritages et des substitutions locales. Pour une diapositive, appelez [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/). Pour un arrière‑plan, utilisez [Background.get_effective](https://reference.aspose.com/slides/fr/python-net/aspose.slides/background/get_effective/), et pour un remplissage, utilisez [FillFormat.get_effective](https://reference.aspose.com/slides/fr/python-net/aspose.slides/fillformat/get_effective/).

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

Utilisez les données effectives pour le diagnostic de rendu, la validation et les comparaisons. Si vous inspectez uniquement [Presentation.master_theme](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/master_theme/), vous pouvez manquer une substitution au niveau du master, de la disposition, de la diapositive ou de la forme qui modifie l’apparence finale.

## **FAQ**

**Puis‑je appliquer un thème à une seule diapositive sans changer le master ?**

Oui. Utilisez le [SlideThemeManager](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/slidethememanager/) de la diapositive et initialisez sa substitution de thème. La modification reste locale à cette diapositive ; les autres diapositives continuent d’hériter de leurs thèmes existants.

**Quelle est la façon la plus sûre de transférer un thème d’une présentation à une autre ?**

Lors du déplacement d’une diapositive tout en conservant son apparence source, clonez le master source dans la destination et clonez la diapositive avec ce master en utilisant [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/fr/python-net/aspose.slides/masterslidecollection/add_clone/) et [SlideCollection.add_clone](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slidecollection/add_clone/). Cela conserve le master, les dispositions et le thème ensemble.

**Comment voir les valeurs effectives après héritage et substitutions ?**

Utilisez [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) pour un thème de diapositive ou de disposition et les méthodes de données effectives correspondantes pour les objets de format tels que [Background.get_effective](https://reference.aspose.com/slides/fr/python-net/aspose.slides/background/get_effective/) et [FillFormat.get_effective](https://reference.aspose.com/slides/fr/python-net/aspose.slides/fillformat/get_effective/). Ces API renvoient les valeurs résolues après application des héritages et des substitutions.