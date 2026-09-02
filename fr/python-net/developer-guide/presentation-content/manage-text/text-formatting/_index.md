---
title: Formater le texte d'une présentation en Python
linktitle: Mise en forme du texte
type: docs
weight: 50
url: /fr/python-net/text-formatting/
keywords:
- aligner le paragraphe
- style du texte
- arrière-plan du texte
- transparence du texte
- espacement des caractères
- propriétés de police
- famille de police
- rotation du texte
- angle de rotation
- cadre de texte
- interligne
- propriété d'ajustement automatique
- ancrage du cadre de texte
- tabulation du texte
- langue par défaut
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Formatez et stylisez le texte dans les présentations PowerPoint et OpenDocument à l'aide d'Aspose.Slides pour Python via .NET. Personnalisez les polices, les couleurs, l'alignement, etc."
---
## **Vue d'ensemble**

Cet article montre comment formater du texte dans les présentations PowerPoint et OpenDocument à l'aide d'Aspose.Slides pour Python via .NET. Il couvre les couleurs d'arrière-plan, la transparence, l'espacement des caractères, les propriétés de police, la rotation, l'espacement des paragraphes, le comportement d'ajustement automatique, l'ancrage du texte, les tabulations et les paramètres de langue.

Dans les exemples ci‑dessous, nous utiliserons un fichier nommé "sample.pptx", qui contient une seule zone de texte sur la première diapositive avec le texte suivant :

![Texte d'exemple](sample_text.png)

Pour trouver et mettre en surbrillance du texte littéral ou des correspondances d'expressions régulières, voir [Rechercher et remplacer du texte](/slides/fr/python-net/search-and-replace-text/).

## **Définir la couleur d'arrière-plan du texte**

Utilisez [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraphformat/default_portion_format/) pour définir la couleur de surbrillance par défaut d'un paragraphe, ou utilisez [PortionFormat.highlight_color](https://reference.aspose.com/slides/fr/python-net/aspose.slides/portionformat/highlight_color/) pour des portions de texte individuelles.

L'exemple de code suivant montre comment définir la couleur d'arrière-plan pour le **paragraphe entier** :

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Définir la couleur de surbrillance pour le paragraphe entier.
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![Le paragraphe gris](gray_paragraph.png)

L'exemple de code ci‑dessous montre comment définir la couleur d'arrière-plan pour les **portions de texte en gras** :

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Définir la couleur de surbrillance pour la portion de texte.
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![Les portions de texte gris](gray_text_portions.png)

## **Aligner les paragraphes de texte**

Utilisez [ParagraphFormat.alignment](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraphformat/alignment/) pour définir l'alignement du paragraphe à l'intérieur d'un cadre de texte. La valeur peut être centrée, alignée à gauche, alignée à droite, justifiée, etc.

L'exemple de code suivant montre comment aligner le paragraphe au **centre** :

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Définir l'alignement du paragraphe au centre.
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![Le paragraphe aligné](aligned_paragraph.png)

## **Définir la transparence du texte**

La transparence du texte est contrôlée via le composant alpha de la couleur assignée à [PortionFormat.fill_format](https://reference.aspose.com/slides/fr/python-net/aspose.slides/portionformat/fill_format/). Dans les exemples ci‑dessous, `alpha = 50` est une valeur de canal alpha ARGB sur l'échelle 0‑255, et non un pourcentage de transparence.

L'exemple de code ci‑dessous montre comment appliquer la transparence au **paragraphe entier** :

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Définir la couleur de remplissage du texte en couleur transparente.
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![Le paragraphe transparent](transparent_paragraph.png)

L'exemple de code suivant montre comment appliquer la transparence aux **portions de texte en gras** :

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Définir la transparence de la portion de texte.
            portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
            portion.portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![Les portions de texte transparentes](transparent_text_portions.png)

## **Définir l'espacement des caractères du texte**

Utilisez [BasePortionFormat.spacing](https://reference.aspose.com/slides/fr/python-net/aspose.slides/baseportionformat/spacing/) pour élargir ou condenser l'espacement entre les caractères dans une zone de texte.

Le code Python suivant montre comment augmenter l'espacement des caractères dans le **paragraphe entier** :

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Remarque : utilisez des valeurs négatives pour compresser l'espacement des caractères.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # Étendre l'espacement des caractères.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![L'espacement des caractères dans le paragraphe](character_spacing_in_paragraph.png)

L'exemple de code ci‑dessous montre comment augmenter l'espacement des caractères dans les **portions de texte en gras** :

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Remarque : Utilisez des valeurs négatives pour compresser l'espacement des caractères.
            portion.portion_format.spacing = 3  # Étendre l'espacement des caractères.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![L'espacement des caractères dans les portions de texte](character_spacing_in_text_portions.png)

### **Désactiver le crénage pour des polices spécifiques**

Dans certains cas, le texte rendu par Aspose.Slides peut sembler légèrement plus serré que le même texte affiché dans PowerPoint. Cela peut se produire parce que PowerPoint peut ignorer les données de crénage pour certaines polices, même lorsque la police contient des informations de crénage valides et que le crénage est activé dans les paramètres de PowerPoint.

Pour que le rendu se rapproche davantage de PowerPoint dans ces cas, vous pouvez désactiver le crénage pour les portions de texte qui utilisent la police concernée. Définissez [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/fr/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) à une valeur nettement supérieure à la taille réelle de la police :

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    target_font = "Roboto"

    for paragraph in auto_shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            latin_font = portion.portion_format.latin_font
            east_asian_font = portion.portion_format.east_asian_font
            complex_script_font = portion.portion_format.complex_script_font

            if ((latin_font is not None and latin_font.font_name == target_font) or
                    (east_asian_font is not None and east_asian_font.font_name == target_font) or
                    (complex_script_font is not None and complex_script_font.font_name == target_font)):
                portion.portion_format.kerning_minimal_size = 100

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Ce paramètre empêche l'application du crénage aux portions de texte correspondantes et peut aider à aligner le rendu d'Aspose.Slides avec la sortie visuelle de PowerPoint pour les polices affectées par ce comportement spécifique à PowerPoint.

## **Gérer les propriétés de police du texte**

Les propriétés de police peuvent être définies au niveau du paragraphe via [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraphformat/default_portion_format/) ou sur des portions individuelles via [PortionFormat](https://reference.aspose.com/slides/fr/python-net/aspose.slides/portionformat/).

Le code suivant définit la police et le style du texte pour le paragraphe entier : il applique la taille de police, le gras, l'italique, le soulignement pointillé et la police Times New Roman à toutes les portions du paragraphe.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Définir les propriétés de police du paragraphe.
    paragraph.paragraph_format.default_portion_format.font_height = 12
    paragraph.paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE
    paragraph.paragraph_format.default_portion_format.font_italic = slides.NullableBool.TRUE
    paragraph.paragraph_format.default_portion_format.font_underline = slides.TextUnderlineType.DOTTED
    paragraph.paragraph_format.default_portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![Les propriétés de police du paragraphe](font_properties_for_paragraph.png)

L'exemple de code ci‑dessous applique des propriétés similaires aux **portions de texte en gras** :

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Définir les propriétés de police pour la portion de texte.
            portion.portion_format.font_height = 13
            portion.portion_format.font_italic = slides.NullableBool.TRUE
            portion.portion_format.font_underline = slides.TextUnderlineType.DOTTED
            portion.portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![Les propriétés de police des portions de texte](font_properties_for_text_portions.png)

## **Définir la rotation du texte**

Utilisez [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframeformat/text_vertical_type/) pour définir une orientation de texte prédéfinie à l'intérieur d'une forme.

L'exemple de code suivant définit l'orientation du texte dans la forme à `VERTICAL270`, ce qui fait pivoter le texte de **90 degrés dans le sens inverse des aiguilles d'une montre** :

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

![La rotation du texte](text_rotation.png)

## **Définir une rotation personnalisée pour les cadres de texte**

Utilisez [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframeformat/rotation_angle/) pour définir un angle de rotation personnalisé pour un [TextFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframe/).

L'exemple de code ci‑dessous fait pivoter le cadre de texte de 3 degrés dans le sens des aiguilles d'une montre à l'intérieur de la forme :

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

![La rotation personnalisée du texte](custom_text_rotation.png)

## **Définir l'espacement des lignes des paragraphes**

Aspose.Slides propose [ParagraphFormat.space_after](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraphformat/space_before/), et [ParagraphFormat.space_within](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraphformat/space_within/) pour contrôler l'espacement des paragraphes. Ces propriétés sont utilisées comme suit :

* Utilisez une valeur positive pour spécifier l'espacement des lignes en pourcentage de la hauteur de ligne.
* Utilisez une valeur négative pour spécifier l'espacement des lignes en points.

L'exemple de code suivant montre comment spécifier l'espacement des lignes au sein du paragraphe :

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.space_within = 200

    presentation.save("line_spacing.pptx", slides.export.SaveFormat.PPTX)
```

![L'espacement des lignes dans le paragraphe](line_spacing.png)

## **Définir le type d'ajustement automatique pour les cadres de texte**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframeformat/autofit_type/) détermine le comportement du texte lorsqu'il dépasse les limites de son conteneur. Utilisez-le pour contrôler si le texte rétrécit, déborde ou redimensionne automatiquement la forme.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir l'ancrage des cadres de texte**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textframeformat/anchoring_type/) définit la façon dont le texte est positionné verticalement à l'intérieur d'une forme, par exemple en haut, au milieu ou en bas.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir la tabulation du texte**

Utilisez [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraphformat/default_tab_size/) et [ParagraphFormat.tabs](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraphformat/tabs/) pour configurer les tabulations dans un paragraphe.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.default_tab_size = 100
    paragraph.paragraph_format.tabs.add(30, slides.TabAlignment.LEFT)

    presentation.save("paragraph_tabs.pptx", slides.export.SaveFormat.PPTX)
```

![Les tabulations du paragraphe](paragraph_tabs.png)

## **Définir la langue de vérification**

Aspose.Slides fournit [PortionFormat.language_id](https://reference.aspose.com/slides/fr/python-net/aspose.slides/portionformat/language_id/), qui vous permet de définir la langue de vérification pour une portion de texte. La langue de vérification détermine la langue utilisée pour les vérifications d'orthographe et de grammaire dans PowerPoint.

L'exemple de code suivant montre comment définir la langue de vérification pour une portion de texte :

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    font = slides.FontData("SimSun")

    text_portion = slides.Portion()
    text_portion.portion_format.complex_script_font = font
    text_portion.portion_format.east_asian_font = font
    text_portion.portion_format.latin_font = font

    # Définir l'Id d'une langue de vérification.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir la langue par défaut**

Utilisez [LoadOptions.default_text_language](https://reference.aspose.com/slides/fr/python-net/aspose.slides/loadoptions/default_text_language/) pour définir la langue par défaut du texte créé lors du chargement ou de la création d'une présentation.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # Ajouter une nouvelle forme rectangulaire avec du texte.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # Vérifier la langue de la première portion.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **Définir le style de texte par défaut**

Pour appliquer un formatage de texte par défaut au niveau de la présentation, utilisez [Presentation.default_text_style](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/default_text_style/).

L'exemple de code suivant montre comment définir une police par défaut en gras avec une taille de 14 pt pour tout le texte sur toutes les diapositives d'une nouvelle présentation.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Obtenir le format du paragraphe de niveau supérieur.
    paragraph_format = presentation.default_text_style.get_level(0)

    if paragraph_format is not None:
        paragraph_format.default_portion_format.font_height = 14
        paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("default_text_style.pptx", slides.export.SaveFormat.PPTX)
```

## **Extraire le texte avec l'effet Tout en majuscules**

Dans PowerPoint, appliquer l'effet de police **All Caps** (tout en majuscules) rend le texte affiché en majuscules sur la diapositive même s'il a été saisi initialement en minuscules. Lorsque vous récupérez une telle portion de texte avec Aspose.Slides, la bibliothèque renvoie le texte exactement tel qu'il a été saisi. Pour faire correspondre le texte affiché, vérifiez [TextCapType](https://reference.aspose.com/slides/fr/python-net/aspose.slides/textcaptype/) et convertissez la chaîne renvoyée en majuscules lorsque la valeur est `ALL`.

Supposons que nous ayons la zone de texte suivante sur la première diapositive du fichier sample2.pptx.

![L'effet Tout en majuscules](all_caps_effect.png)

L'exemple de code ci‑dess dessous montre comment extraire le texte avec l'effet **All Caps** appliqué :

```python
import aspose.slides as slides

with slides.Presentation("sample2.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    text_portion = auto_shape.text_frame.paragraphs[0].portions[0]

    print("Original text:", text_portion.text)

    text_format = text_portion.portion_format.get_effective()
    if text_format.text_cap_type == slides.TextCapType.ALL:
        text = text_portion.text.upper()
        print("All-Caps effect:", text)
```

Sortie :

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Comment modifier le texte dans un tableau sur une diapositive ?**

Pour modifier le texte dans un tableau sur une diapositive, utilisez [Table](https://reference.aspose.com/slides/fr/python-net/aspose.slides/table/). Parcourez les cellules et mettez à jour chaque cellule via [Cell.text_frame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/cell/text_frame/) et le formatage du paragraphe via [Paragraph.paragraph_format](https://reference.aspose.com/slides/fr/python-net/aspose.slides/paragraph/paragraph_format/).

**Comment appliquer un dégradé de couleur au texte dans une diapositive PowerPoint ?**

Pour appliquer un dégradé de couleur au texte, utilisez [PortionFormat.fill_format](https://reference.aspose.com/slides/fr/python-net/aspose.slides/portionformat/fill_format/). Définissez [FillFormat.fill_type](https://reference.aspose.com/slides/fr/python-net/aspose.slides/fillformat/fill_type/) sur [FillType.GRADIENT](https://reference.aspose.com/slides/fr/python-net/aspose.slides/filltype/) et configurez les arrêts du dégradé, la direction et la transparence.