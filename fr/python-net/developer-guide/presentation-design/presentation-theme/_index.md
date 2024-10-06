---
title: Thème de Présentation
type: docs
weight: 10
url: /python-net/presentation-theme/
keywords: "Thème, thème PowerPoint, présentation PowerPoint, Python, Aspose.Slides pour Python via .NET"
description: "Thème de présentation PowerPoint en Python"
---

Un thème de présentation définit les propriétés des éléments de conception. Lorsque vous sélectionnez un thème de présentation, vous choisissez essentiellement un ensemble spécifique d'éléments visuels et leurs propriétés.

Dans PowerPoint, un thème comprend des couleurs, [polices](/slides/python-net/powerpoint-fonts/), [styles d'arrière-plan](/slides/python-net/presentation-background/), et effets.

![theme-constituents](theme-constituents.png)

## **Changer la Couleur du Thème**

Un thème PowerPoint utilise un ensemble spécifique de couleurs pour différents éléments sur une diapositive. Si vous n'aimez pas les couleurs, vous pouvez les changer en appliquant de nouvelles couleurs au thème. Pour vous permettre de choisir une nouvelle couleur de thème, Aspose.Slides fournit des valeurs sous l'énumération [SchemeColor](https://reference.aspose.com/slides/python-net/aspose.slides/schemecolor/).

Ce code Python vous montre comment changer la couleur d'accent pour un thème :

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
```

Vous pouvez déterminer la valeur effective de la couleur résultante de cette manière :

```python
fillEffective = shape.fill_format.get_effective()
print("{0} ({1})".format(fillEffective.solid_fill_color.name, fillEffective.solid_fill_color)) # ff8064a2 (Couleur [A=255, R=128, G=100, B=162])
```

Pour démontrer davantage l'opération de changement de couleur, nous créons un autre élément et lui attribuons la couleur d'accent (de l'opération initiale). Ensuite, nous changeons la couleur dans le thème :

```python
otherShape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 120, 100, 100)
otherShape.fill_format.fill_type = slides.FillType.SOLID
otherShape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

pres.master_theme.color_scheme.accent4.color = draw.Color.red
```

La nouvelle couleur est appliquée automatiquement aux deux éléments.

### **Définir la Couleur du Thème à Partir de la Palette Supplémentaire**

Lorsque vous appliquez des transformations de luminance à la couleur de thème principale(1), des couleurs de la palette supplémentaire(2) sont formées. Vous pouvez ensuite définir et obtenir ces couleurs de thème.

![additional-palette-colors](additional-palette-colors.png)

**1**- Couleurs principales du thème

**2** - Couleurs de la palette supplémentaire.

Ce code Python démontre une opération où les couleurs de la palette supplémentaire sont obtenues à partir de la couleur de thème principale, puis utilisées dans des formes :

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

    # Accent 4, plus foncé 25%
    shape5 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 250, 50, 50)

    shape5.fill_format.fill_type = slides.FillType.SOLID
    shape5.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape5.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.75)

    # Accent 4, plus foncé 50%
    shape6 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 50, 50)

    shape6.fill_format.fill_type = slides.FillType.SOLID
    shape6.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape6.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.5)

    presentation.save("example.pptx", slides.export.SaveFormat.PPTX)
```

## **Changer la Police du Thème**

Pour vous permettre de sélectionner des polices pour les thèmes et d'autres usages, Aspose.Slides utilise ces identifiants spéciaux (similaires à ceux utilisés dans PowerPoint) :

* **+mn-lt** - Police du Corps Latin (Police Latin Mineure)
* **+mj-lt** - Police de Titre Latin (Police Latin Majeure)
* **+mn-ea** - Police du Corps Est-asiatique (Police Est-asiatique Mineure)
* **+mj-ea** - Police de Titre Est-asiatique (Police Est-asiatique Majeure)

Ce code Python vous montre comment assigner la police latine à un élément de thème :

```python
shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)

paragraph = slides.Paragraph()
portion = slides.Portion("Format de texte de thème")
paragraph.portions.add(portion)
shape.text_frame.paragraphs.add(paragraph)
portion.portion_format.latin_font = slides.FontData("+mn-lt")
```

Ce code Python vous montre comment changer la police du thème de présentation :

```python
pres.master_theme.font_scheme.minor.latin_font = slides.FontData("Arial")
```

La police dans toutes les boîtes de texte sera mise à jour.

{{% alert color="primary" title="ASTUCE" %}} 

Vous souhaiterez peut-être consulter [les polices PowerPoint](/slides/python-net/powerpoint-fonts/).

{{% /alert %}}

## **Changer le Style d'Arrière-plan du Thème**

Par défaut, l'application PowerPoint fournit 12 arrière-plans prédéfinis mais seulement 3 de ces 12 arrière-plans sont enregistrés dans une présentation typique.

![todo:image_alt_text](presentation-design_8.png)

Par exemple, après avoir enregistré une présentation dans l'application PowerPoint, vous pouvez exécuter ce code Python pour savoir combien d'arrière-plans prédéfinis il y a dans la présentation :

```python
with slides.Presentation() as pres:
    numberOfBackgroundFills = len(pres.master_theme.format_scheme.background_fill_styles)
    print("Le nombre de styles de remplissage d'arrière-plan pour le thème est {0}".format(numberOfBackgroundFills))
```

{{% alert color="warning" %}} 

En utilisant la propriété `BackgroundFillStyles` de la classe [FormatScheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/), vous pouvez ajouter ou accéder au style d'arrière-plan dans un thème PowerPoint.

{{% /alert %}}

Ce code Python vous montre comment définir l'arrière-plan d'une présentation :

```python
pres.masters[0].background.style_index = 2
```

**Guide d'index** : 0 est utilisé pour aucun remplissage. L'index commence à 1.

{{% alert color="primary" title="ASTUCE" %}} 

Vous souhaiterez peut-être consulter [l'arrière-plan PowerPoint](/slides/python-net/presentation-background/).

{{% /alert %}}

## **Changer l'Effet du Thème**

Un thème PowerPoint contient généralement 3 valeurs pour chaque tableau de styles. Ces tableaux sont combinés en ces 3 effets : subtil, modéré et intense. Par exemple, voici le résultat lorsque les effets sont appliqués à une forme spécifique :

![todo:image_alt_text](presentation-design_10.png)

En utilisant 3 propriétés (`FillStyles`, `LineStyles`, `EffectStyles`) de la classe [FormatScheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/) vous pouvez changer les éléments d'un thème (de manière encore plus flexible que les options dans PowerPoint).

Ce code Python vous montre comment changer un effet de thème en modifiant des parties des éléments :

```python
with slides.Presentation("combined_with_master.pptx") as pres:
    pres.master_theme.format_scheme.line_styles[0].fill_format.solid_fill_color.color = draw.Color.red
    pres.master_theme.format_scheme.fill_styles[2].fill_type = slides.FillType.SOLID
    pres.master_theme.format_scheme.fill_styles[2].solid_fill_color.color = draw.Color.forest_green
    pres.master_theme.format_scheme.effect_styles[2].effect_format.outer_shadow_effect.distance = 10

    pres.save("Design_04_Subtle_Moderate_Intense-out.pptx", slides.export.SaveFormat.PPTX)
```

Les changements résultants dans la couleur de remplissage, le type de remplissage, l'effet d'ombre, etc :

![todo:image_alt_text](presentation-design_11.png)