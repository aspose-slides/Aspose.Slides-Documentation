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
- couleur du thème
- palette supplémentaire
- police du thème
- style du thème
- effet du thème
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Maîtrisez les thèmes de présentation dans Aspose.Slides pour Python via .NET afin de créer, personnaliser et convertir des fichiers PowerPoint avec une identité visuelle cohérente."
---

## **Aperçu**

Un thème de présentation définit les propriétés de ses éléments de conception. Lorsque vous sélectionnez un thème, vous choisissez un ensemble coordonné d'éléments visuels et leurs propriétés.

Dans PowerPoint, un thème comprend des couleurs, [polices](/slides/fr/python-net/powerpoint-fonts/), [styles d’arrière-plan](/slides/fr/python-net/presentation-background/), et des effets.

![theme-constituents](theme-constituents.png)

## **Modifier la couleur du thème**

Un thème PowerPoint utilise un ensemble spécifique de couleurs pour différents éléments d’une diapositive. Si vous n’aimez pas les valeurs par défaut, vous pouvez les modifier en appliquant de nouvelles couleurs de thème. Pour vous permettre de sélectionner une nouvelle couleur de thème, Aspose.Slides fournit les valeurs de l’énumération [SchemeColor](https://reference.aspose.com/slides/python-net/aspose.slides/schemecolor/).

Ce code Python montre comment modifier la couleur d’accent d’un thème :
```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
```


Vous pouvez déterminer la valeur effective de la couleur résultante comme suit :
```python
fill_effective = shape.fill_format.get_effective()
print("{0} ({1})".format(fill_effective.solid_fill_color.name, fill_effective.solid_fill_color))

# Exemple de sortie :
#
# ff8064a2 (Couleur [A=255, R=128, G=100, B=162])
```


Pour illustrer davantage le changement de couleur, nous créons un autre élément, lui assignons la couleur d’accent de l’étape initiale, puis mettons à jour la couleur du thème.
```python
other_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 120, 100, 100)
other_shape.fill_format.fill_type = slides.FillType.SOLID
other_shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

presentation.master_theme.color_scheme.accent4.color = draw.Color.red
```


La nouvelle couleur est appliquée automatiquement aux deux éléments.

### **Définir une couleur de thème à partir de la palette supplémentaire**

Lorsque vous appliquez des transformations de luminance à la couleur principale du thème (1), des couleurs de la palette supplémentaire (2) sont générées. Vous pouvez alors définir et récupérer ces couleurs de thème.

![additional-palette-colors](additional-palette-colors.png)

**1** — Couleurs principales du thème

**2** — Couleurs de la palette supplémentaire

Ce code Python montre comment les couleurs de la palette supplémentaire sont dérivées de la couleur principale du thème puis utilisées dans les formes :
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Accent 4
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 50, 50)

    shape1.fill_format.fill_type = slides.FillType.SOLID
    shape1.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

    # Accent 4, plus clair 80%
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 50, 50)

    shape2.fill_format.fill_type = slides.FillType.SOLID
    shape2.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.2)
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.8)

    # Accent 4, plus clair 60%
    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 50, 50)

    shape3.fill_format.fill_type = slides.FillType.SOLID
    shape3.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.4)
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.6)

    # Accent 4, plus clair 40%
    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 50, 50)

    shape4.fill_format.fill_type = slides.FillType.SOLID
    shape4.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.6)
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.4)

    # Accent 4, plus sombre 25%
    shape5 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 250, 50, 50)

    shape5.fill_format.fill_type = slides.FillType.SOLID
    shape5.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape5.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.75)

    # Accent 4, plus sombre 50%
    shape6 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 50, 50)

    shape6.fill_format.fill_type = slides.FillType.SOLID
    shape6.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape6.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.5)

    presentation.save("example.pptx", slides.export.SaveFormat.PPTX)
```


## **Modifier la police du thème**

Pour vous permettre de sélectionner des polices pour les thèmes et d’autres usages, Aspose.Slides utilise ces identifiants spéciaux (similaires à ceux de PowerPoint) :

- **+mn-lt** — Police du corps Latin (Police Latin mineure)
- **+mj-lt** — Police du titre Latin (Police Latin majeure)
- **+mn-ea** — Police du corps Asie de l’Est (Police Asie de l’Est mineure)
- **+mj-ea** — Police du titre Asie de l’Est (Police Asie de l’Est majeure)

Ce code Python montre comment assigner la police Latin à un élément du thème :
```python
portion = slides.Portion("Theme text format")
portion.portion_format.latin_font = slides.FontData("+mn-lt")

paragraph = slides.Paragraph()
paragraph.portions.add(portion)

shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
shape.text_frame.paragraphs.add(paragraph)
```


Cet exemple Python montre comment modifier la police du thème de la présentation :
```python
presentation.master_theme.font_scheme.minor.latin_font = slides.FontData("Arial")
```


Toutes les zones de texte seront mises à jour avec la nouvelle police.

{{% alert color="primary" title="TIP" %}}
Pour plus d’informations, voir [Polices maîtresses PowerPoint avec Python](/slides/fr/python-net/powerpoint-fonts/).
{{% /alert %}}

## **Modifier le style d’arrière-plan du thème**

Par défaut, PowerPoint propose 12 arrière-plans prédéfinis, mais une présentation typique n’enregistre que 3 d’entre eux.

![todo:image_alt_text](presentation-design_8.png)

Par exemple, après avoir enregistré une présentation dans PowerPoint, vous pouvez exécuter le code Python suivant pour déterminer combien d’arrière-plans prédéfinis elle contient :
```python
with slides.Presentation() as presentation:
    number_of_background_fills = len(presentation.master_theme.format_scheme.background_fill_styles)
    print(f"Number of theme background fill styles: {number_of_background_fills}")
```


{{% alert color="warning" %}}
En utilisant la propriété `background_fill_styles` de la classe [FormatScheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/) vous pouvez ajouter ou accéder aux styles d’arrière-plan dans un thème PowerPoint.
{{% /alert %}}

Cet exemple Python montre comment définir l’arrière-plan de la présentation :
```python
presentation.masters[0].background.style_index = 2  # 0 indique aucun remplissage ; l'indexation commence à 1.
```


{{% alert color="primary" title="TIP" %}}
Pour plus d’informations, voir [Gérer les arrière-plans de présentation en Python](/slides/fr/python-net/presentation-background/).
{{% /alert %}}

## **Modifier les effets du thème**

Un thème PowerPoint comprend généralement trois valeurs dans chaque tableau de style. Ces tableaux se combinent en trois niveaux d’effet : subtil, modéré et intense. Par exemple, voici le résultat lorsque ces effets sont appliqués à une forme spécifique :

![todo:image_alt_text](presentation-design_10.png)

En utilisant les trois propriétés —`FillStyles`, `LineStyles` et `EffectStyles`—de la classe [FormatScheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/) vous pouvez modifier les éléments du thème (de manière encore plus flexible que dans PowerPoint).

Ce code Python montre comment modifier un effet de thème en ajustant des parties de ces éléments :
```python
with slides.Presentation("sample.pptx") as presentation:
    presentation.master_theme.format_scheme.line_styles[0].fill_format.solid_fill_color.color = draw.Color.red
    presentation.master_theme.format_scheme.fill_styles[2].fill_type = slides.FillType.SOLID
    presentation.master_theme.format_scheme.fill_styles[2].solid_fill_color.color = draw.Color.forest_green
    presentation.master_theme.format_scheme.effect_styles[2].effect_format.outer_shadow_effect.distance = 10

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


Les changements résultants incluent des mises à jour de la couleur de remplissage, du type de remplissage, de l’effet d’ombre et d’autres propriétés :

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

**Puis-je appliquer un thème à une seule diapositive sans modifier le maître ?**

Oui. Aspose.Slides prend en charge les surcharges de thème au niveau de la diapositive, vous permettant d’appliquer un thème local uniquement à cette diapositive tout en conservant le thème maître intact (via le [SlideThemeManager](https://reference.aspose.com/slides/python-net/aspose.slides.theme/slidethememanager/)).

**Quelle est la façon la plus sûre de transférer un thème d’une présentation à une autre ?**

[Clone slides](/slides/fr/python-net/clone-slides/) avec leur maître dans la présentation cible. Cela préserve le maître original, les mises en page et le thème associé afin que l’apparence reste cohérente.

**Comment puis‑je voir les valeurs « effectives » après tous les héritages et surcharges ?**

Utilisez les vues « effective » de l’API [/slides/python-net/shape-effective-properties/] pour le thème/couleur/police/effet. Elles renvoient les propriétés résolues et finales après l’application du maître et des éventuelles surcharges locales.