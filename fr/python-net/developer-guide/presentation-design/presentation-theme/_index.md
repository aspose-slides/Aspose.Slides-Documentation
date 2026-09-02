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

Un thème de présentation définit un ensemble coordonné de couleurs, de polices, de styles d’arrière‑plan, de remplissages, de lignes et d’effets. Les objets sensibles au thème font référence à ces définitions partagées plutôt que d’enregistrer chaque propriété visuelle comme une valeur fixe, de sorte qu’un changement de thème peut mettre à jour de nombreux objets à la fois.

Dans Aspose.Slides, le thème au niveau de la présentation est disponible via la propriété [Presentation.master_theme](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/master_theme/). Une présentation peut également contenir des surcharges de thème à des niveaux inférieurs. Un master peut surcharger le thème de la présentation via [MasterThemeManager.override_theme](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/masterthememanager/override_theme/), une diapositive‑maître peut surcharger son thème hérité via [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/), et une diapositive individuelle peut faire de même. En pratique, le thème effectif d’une diapositive est résolu grâce à cette chaîne d’héritage : thème de la présentation, surcharge du master, surcharge de la mise en page, et surcharge de la diapositive.

![Composants du thème : couleurs, polices, styles d’arrière‑plan et effets](theme-constituents.png)

Les sections ci‑dessous présentent les flux de travail les plus courants liés aux thèmes : inspecter un thème, modifier les couleurs et les polices, copier ou appliquer un thème, mettre à jour les styles d’arrière‑plan et d’effets, et lire les valeurs effectives après résolution des héritages et des surcharges.

## **Inspecter un thème**

L’objet [MasterTheme](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/mastertheme/) expose les propriétés [color_scheme](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/mastertheme/color_scheme/), [font_scheme](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/mastertheme/font_scheme/) et [format_scheme](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/mastertheme/format_scheme/). Inspecter ces collections avant de les modifier est particulièrement utile lorsqu’une présentation provient d’une source externe, car le nombre et le contenu des entrées de style peuvent varier.

L’exemple suivant lit les principales propriétés du thème et indique combien de styles d’arrière‑plan, de remplissage, de ligne et d’effet sont stockés dans le thème :

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

Si un fichier utilise plusieurs maîtres, ne supposez pas que chaque diapositive possède le même thème effectif. Inspectez le master associé à la diapositive, et utilisez le flux de travail du thème effectif présenté plus loin dans cet article lorsque des surcharges de mise en page ou de diapositive peuvent être présentes.

## **Modifier les couleurs du thème**

Les remplissages, lignes et textes sensibles au thème peuvent référencer une couleur logique provenant de l’énumération [SchemeColor](https://reference.aspose.com/slides/fr/python-net/aspose.slides/schemecolor/). Lorsque vous modifiez l’entrée correspondante dans le [ColorScheme](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/colorscheme/) du thème, tous les objets qui font encore référence à cette couleur de thème sont résolus avec la nouvelle valeur. Les objets qui utilisent une couleur RVB directe ne sont pas modifiés par une mise à jour de couleur de thème.

L’exemple complet suivant crée une forme qui utilise `ACCENT4`, change la couleur `accent4` du thème en rouge, enregistre la présentation, la rouvre, puis affiche la couleur de remplissage effective :

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

Comme le rectangle reste lié à `ACCENT4`, sa couleur visible devient rouge après le changement de thème. Si vous remplacez la couleur du schéma par une couleur directe sur la forme, les modifications ultérieures de `accent4` n’affecteront plus ce remplissage.

### **Utiliser les couleurs de la palette supplémentaire**

PowerPoint dérive des variantes plus claires et plus sombres d’une couleur de thème en appliquant des transformations de couleur. Aspose.Slides expose ces transformations via l’énumération [ColorTransformOperation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/colortransformoperation/).

![Couleurs principales du thème et couleurs plus claires et plus sombres générées à partir de la palette supplémentaire](additional-palette-colors.png)

**1** – Couleurs principales du thème.  
**2** – Variantes plus claires et plus sombres produites à partir des couleurs principales du thème.

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

Ces variantes restent basées sur la couleur du thème. Si `accent4` change plus tard, les couleurs transformées sont recalculées à partir de la nouvelle valeur de `accent4`.

### **Faire correspondre les valeurs `SchemeColor` aux emplacements `ColorScheme`**

L’énumération [SchemeColor](https://reference.aspose.com/slides/fr/python-net/aspose.slides/schemecolor/) utilise `TEXT1`, `BACKGROUND1`, `TEXT2` et `BACKGROUND2`, tandis que [ColorScheme](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/colorscheme/) expose les mêmes emplacements de thème sous les noms `dark1`, `light1`, `dark2` et `light2`. Le mapping est fixe :

* `TEXT1` = `dark1`  
* `BACKGROUND1` = `light1`  
* `TEXT2` = `dark2`  
* `BACKGROUND2` = `light2`

Il s’agit simplement de noms alternatifs pour les mêmes emplacements de thème ; il ne s’agit pas de valeurs converties dynamiquement d’une forme à l’autre.

## **Modifier les polices du thème**

Un schéma de polices de thème contient un jeu de polices majeur pour les titres et un jeu de polices mineur pour le corps du texte. Les propriétés [FontScheme.major](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/fontscheme/major/) et [FontScheme.minor](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/fontscheme/minor/) exposent ces jeux.

Les identifiants de police de thème compatibles PowerPoint peuvent être utilisés dans le formatage du texte :

* `+mn-lt` – Police du corps Latin (Minor Latin Font)  
* `+mj-lt` – Police du titre Latin (Major Latin Font)  
* `+mn-ea` – Police du corps Asie de l’Est (Minor East Asian Font)  
* `+mj-ea` – Police du titre Asie de l’Est (Major East Asian Font)

L’exemple suivant crée un titre qui utilise la police Latin majeure du thème et une ligne de corps qui utilise la police Latin mineure du thème. Il modifie ensuite les polices du thème et enregistre le résultat :

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

Le titre suit la police majeure et le texte du corps suit la police mineure. Un texte qui possède un nom de police explicite au lieu d’un identifiant de thème ne changera pas automatiquement lorsque le schéma de polices du thème est modifié.

Les collections majeures et mineures peuvent aussi contenir des mappages de polices pour des systèmes d’écriture individuels, comme le cyrillique, l’arabe, le japonais, le géorgien et le thaana. Pour inspecter, ajouter, remplacer ou supprimer ces mappages, consultez [Script‑Specific Theme Fonts](/slides/fr/python-net/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Pour plus d’informations sur les polices de présentation, voir [PowerPoint Fonts](/slides/fr/python-net/powerpoint-fonts/).
{{% /alert %}}

## **Copier ou appliquer un thème**

Les flux de travail ci‑dessous résolvent différents problèmes liés aux thèmes.

### **Appliquer un thème externe aux diapositives dépendantes d’un master**

Utilisez [IMasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/fr/python-net/aspose.slides/imasterslide/apply_external_theme_to_depending_slides/) lorsque vous disposez d’un fichier de thème PowerPoint (`.thmx`) et que vous souhaitez re‑styler chaque diapositive dépendant d’un master particulier. Sélectionnez le master dans la collection [Presentation.masters](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/masters/), qui implémente [MasterSlideCollection](https://reference.aspose.com/slides/fr/python-net/aspose.slides/masterslidecollection/), puis transmettez le chemin du fichier thème à la méthode.

La méthode exécute les opérations suivantes :

1. Crée une nouvelle diapositive‑master basée sur le master sélectionné.  
1. Applique le thème externe au nouveau master.  
1. Assigne le nouveau master à toutes les diapositives qui dépendaient auparavant du master sélectionné.  
1. Retourne le nouvel [IMasterSlide](https://reference.aspose.com/slides/fr/python-net/aspose.slides/imasterslide/) créé.

L’exemple suivant applique un thème externe aux diapositives dépendant du premier master et enregistre la présentation :

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    selected_master = presentation.masters[0]
    themed_master = selected_master.apply_external_theme_to_depending_slides("corporate-theme.thmx")

    print(f"Created master: {themed_master.name}")
    presentation.save("presentation-with-external-theme.pptx", slides.export.SaveFormat.PPTX)
```

Un thème invalide, corrompu ou non pris en charge peut provoquer une [PptxException](https://reference.aspose.com/slides/fr/python-net/aspose.slides/pptxexception/) ou l’une de ses sous‑classes liées au format. Validez les chemins fournis par les utilisateurs, gérez les échecs d’accès au système de fichiers, et n’enregistrez la présentation qu’après l’application réussie du thème.

Seules les diapositives dépendant du master sélectionné sont réaffectées. Les diapositives associées à d’autres masters conservent leurs masters et thèmes existants. Les couleurs, polices, remplissages, lignes, arrière‑plans et effets sensibles au thème sont résolus par rapport au thème externe. Les couleurs, polices, remplissages et autres formatages attribués directement peuvent rester inchangés. Les surcharges au niveau de la mise en page et de la diapositive peuvent également prévaloir sur les valeurs héritées du nouveau master.

Le thème peut référencer des polices qui ne sont pas disponibles dans l’environnement d’exécution. Pour un rendu et une exportation cohérents, installez les polices requises, fournissez‑les via [custom font sources](/slides/fr/python-net/custom-font/), ou configurez la [font substitution](/slides/fr/python-net/font-substitution/).

Il s’agit d’un flux de travail direct au niveau du master : la méthode accepte un chemin de fichier `.thmx` et ne nécessite pas de créer manuellement des surcharges de thème au niveau de la diapositive ou de la mise en page.

### **Appliquer différents thèmes externes dans une présentation multi‑master**

Lorsque le master pertinent n’est pas connu à l’avance, obtenez‑le à partir d’une diapositive représentative via [Slide.layout_slide](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slide/layout_slide/) et [LayoutSlide.master_slide](https://reference.aspose.com/slides/fr/python-net/aspose.slides/layoutslide/master_slide/). Conservez les références des masters originaux avant d’appliquer des thèmes, car chaque appel crée un autre master dans la présentation.

L’exemple suivant utilise des diapositives de deux sections pour localiser leurs masters et applique un thème externe différent à chaque groupe :

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

Le premier appel affecte uniquement les diapositives dépendant de `first_group_master`, et le second appel affecte uniquement les diapositives dépendant de `second_group_master`. Les diapositives appartenant à tout autre master ne sont pas re‑stylées.

### **Conserver un thème source lors du déplacement de diapositives**

Si vous devez déplacer une diapositive vers une autre présentation tout en conservant son design original, clonez le master source dans la présentation cible avec [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/fr/python-net/aspose.slides/masterslidecollection/add_clone/), puis clonez la diapositive avec [SlideCollection.add_clone](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slidecollection/add_clone/) et le master cloné. Cela transfère le master, ses mises en page et le thème associé en une seule opération.

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

C’est le flux de travail recommandé lorsque la diapositive source doit rester identique dans la destination. Cloner simplement le contenu sur un master de destination non lié peut modifier les couleurs, polices, arrière‑plans et effets contrôlés par le thème.

### **Appliquer les valeurs du thème à une diapositive existante**

Si la diapositive cible doit rester sur son master et sa mise en page actuels, créez une surcharge au niveau de la diapositive à partir du thème source. Les méthodes [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/), [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/) et [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) copient les trois principaux composants du thème dans la surcharge.

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

Cela modifie le thème utilisé par cette diapositive sans toucher au thème hérité par les autres diapositives. Pour supprimer la surcharge locale et revenir aux valeurs héritées, appelez [OverrideTheme.clear](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/overridetheme/clear/).

### **Appliquer une surcharge de thème à une mise en page**

Une surcharge au niveau de la mise en page s’applique aux diapositives qui utilisent cette mise en page, sauf si une diapositive particulière possède sa propre surcharge. Les mêmes méthodes d’initialisation peuvent être utilisées via le [LayoutSlideThemeManager](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/layoutslidethememanager/) de la mise en page :

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

Utilisez un thème au niveau du master ou de la présentation lorsque de nombreuses mises en page et diapositives doivent partager le même design de base, une surcharge de mise en page lorsque une famille de mises en page requiert un style différent, et une surcharge de diapositive uniquement pour de vérituelles exceptions. Un excès de surcharges au niveau des diapositives rend les modifications globales du thème plus difficiles à prédire.

## **Mettre à jour les styles d’arrière‑plan du thème**

Les remplissages d’arrière‑plan du thème sont stockés dans [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/formatscheme/background_fill_styles/). PowerPoint peut présenter davantage d’options d’arrière‑plan dans son interface que le nombre d‑définitions de remplissage réellement stockées dans cette collection, car l’interface peut combiner les remplissages du thème avec les couleurs du thème et d’autres références de style.

![Galerie de styles d’arrière‑plan PowerPoint pour un thème de présentation](presentation-design_8.png)

Avant d’utiliser un style d’arrière‑plan, inspectez la collection stockée et la propriété actuelle [Background.style_index](https://reference.aspose.com/slides/fr/python-net/aspose.slides/background/style_index/). `style_index` utilise `0` pour indiquer aucun remplissage thématisé ; les valeurs positives sont des références de style d’arrière‑plan du thème. Cela diffère de l’indexation d’une collection Python où `[0]` désigne le premier élément stocké. Ne supposez pas que chaque présentation contient le même nombre de styles de remplissage d’arrière‑plan.

L’exemple suivant indique le nombre de remplissages d’arrière‑plan disponibles, assigne une référence d’arrière‑plan thématisé au premier master, puis enregistre la présentation :

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

Le résultat visible dépend de l’entrée de thème référencée par le master et de toute surcharge d’arrière‑plan au niveau de la mise en page ou de la diapositive. Si une diapositive utilise son propre arrière‑plan, modifier uniquement l’arrière‑plan du master peut ne pas affecter cette diapositive. Utilisez [Background.get_effective](https://reference.aspose.com/slides/fr/python-net/aspose.slides/background/get_effective/) lorsque vous devez connaître l’arrière‑plan final après application de l’héritage.

{{% alert color="warning" title="Warning" %}}
Ne traitez pas `style_index` comme un indice de collection basé sur zéro. Évitez également de coder en dur un numéro de style provenant d’un fichier et de supposer qu’il aura le même aspect dans un autre fichier ; les définitions de style de thème sont propres à chaque présentation.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Pour le formatage direct de l’arrière‑plan et l’héritage d’arrière‑plan, consultez [Presentation Background](/slides/fr/python-net/presentation-background/).
{{% /alert %}}

## **Mettre à jour les effets du thème**

Un schéma de format du thème contient des collections séparées [FormatScheme.fill_styles](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/formatscheme/fill_styles/), [FormatScheme.line_styles](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/formatscheme/line_styles/) et [FormatScheme.effect_styles](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/formatscheme/effect_styles/). Les thèmes Office typiques contiennent souvent trois entrées de style principales qui correspondent visuellement à des formats subtil, modéré et intense, mais le code doit inspecter chaque collection au lieu de supposer un nombre fixe.

![Effets de thème subtils, modérés et intenses appliqués à la même forme](presentation-design_10.png)

Lorsque vous accédez à ces collections en Python, l’indice de la collection est basé sur zéro : `[0]` est le premier style stocké et `[2]` le troisième. Les indices de référence de style d’une forme constituent un concept distinct, exposé via [IShapeStyle](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ishapestyle/). Modifier un style de thème affecte les formes qui référencent ce style ; les formes avec un formatage direct peuvent rester inchangées.

L’exemple suivant vérifie que les entrées de style requises existent, modifie le premier style de ligne, modifie le troisième style de remplissage, active une ombre externe dans le troisième style d’effet, puis enregistre le résultat :

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

Pour les formes qui référencent ces emplacements, le premier style de ligne du thème devient rouge, le troisième style de remplissage du thème devient vert forêt plein, et le troisième style d’effet gagne une ombre externe avec une distance de 10 points. Le rendu visuel exact dépend toujours des emplacements de style référencés par chaque forme et du fait qu’un formatage direct puisse écraser le thème.

![Styles d’effet du thème après modification des paramètres de ligne, de remplissage et d’ombre](presentation-design_11.png)

## **Lire les valeurs effectives du thème**

Les objets de thème bruts indiquent ce qui est défini à un niveau particulier. Les valeurs effectives indiquent ce qu’une diapositive ou une forme utilise réellement après résolution des héritages et des surcharges locales. Pour une diapositive, appelez [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/). Pour un arrière‑plan, utilisez [Background.get_effective](https://reference.aspose.com/slides/fr/python-net/aspose.slides/background/get_effective/), et pour un remplissage, utilisez [FillFormat.get_effective](https://reference.aspose.com/slides/fr/python-net/aspose.slides/fillformat/get_effective/).

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

Utilisez les données effectives pour les diagnostics de rendu, la validation et les comparaisons. Si vous inspectez uniquement [Presentation.master_theme](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/master_theme/), vous risquez de manquer une surcharge de master, de mise en page, de diapositive ou de forme qui modifie l’apparence finale.

## **FAQ**

**L’application d’un thème externe affecte‑t‑elle chaque diapositive de la présentation ?**

Non. [IMasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/fr/python-net/aspose.slides/imasterslide/apply_external_theme_to_depending_slides/) ne réaffecte que les diapositives dépendant du master sélectionné. Les diapositives utilisant d’autres masters conservent leurs thèmes existants.

**Puis‑je appliquer un thème à une seule diapositive sans changer le master ?**

Oui. Utilisez le [SlideThemeManager](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/slidethememanager/) de la diapositive et initialisez sa surcharge de thème. La modification reste locale à cette diapositive ; les autres diapositives continuent d’hériter de leurs thèmes existants.

**Quelle est la méthode la plus sûre pour transférer un thème d’une présentation à une autre ?**

Lors du déplacement d’une diapositive tout en préservant son apparence source, clonez le master source dans la destination puis clonez la diapositive avec ce master en utilisant [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/fr/python-net/aspose.slides/masterslidecollection/add_clone/) et [SlideCollection.add_clone](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slidecollection/add_clone/). Cela maintient le master, les mises en page et le thème ensemble.

**Comment puis‑je voir les valeurs effectives après héritage et surcharges ?**

Utilisez [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/fr/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) pour un thème de diapositive ou de mise en page et les méthodes de données effectives correspondantes pour les objets de format tels que [Background.get_effective](https://reference.aspose.com/slides/fr/python-net/aspose.slides/background/get_effective/) et [FillFormat.get_effective](https://reference.aspose.com/slides/fr/python-net/aspose.slides/fillformat/get_effective/). Ces API renvoient les valeurs résolues après application des héritages et des surcharges.