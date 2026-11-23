---
title: Formater le texte des présentations en Python
linktitle: Mise en forme du texte
type: docs
weight: 50
url: /fr/python-net/text-formatting/
keywords:
- aligner le paragraphe
- style de texte
- arrière-plan du texte
- transparence du texte
- espacement des caractères
- propriétés de police
- famille de police
- rotation du texte
- angle de rotation
- cadre de texte
- espacement des lignes
- propriété d'ajustement automatique
- ancre du cadre de texte
- tabulation du texte
- langue par défaut
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Formatez et stylisez le texte dans les présentations PowerPoint et OpenDocument à l’aide d’Aspose.Slides pour Python via .NET. Personnalisez les polices, les couleurs, l’alignement et plus encore."
---
## **Vue d'ensemble**

Cet article montre comment formater du texte dans des présentations PowerPoint et OpenDocument à l’aide d’Aspose.Slides pour Python via .NET. Il traite des couleurs d’arrière‑plan, de la transparence, de l’espacement des caractères, des propriétés de police, de la rotation, de l’espacement des paragraphes, du comportement d’ajustement automatique, de l’ancrage du texte, des tabulations et des paramètres de langue.

Sauf indication contraire, les exemples utilisent [sample.pptx](sample.pptx). La première forme de la première diapositive est une zone de texte, et son premier paragraphe contient le texte affiché ci‑dessous. Les indices de diapositive et de forme sont basés à zéro. Les exemples qui sélectionnent des parties en gras utilisent le formatage effectif, y compris le formatage gras hérité :

![Texte d’exemple](sample_text.png)

Pour rechercher et mettre en surbrillance du texte littéral ou des correspondances d’expressions régulières, voir [Rechercher et remplacer du texte](/slides/fr/python-net/search-and-replace-text/).

## **Définir la couleur d’arrière‑plan du texte**

Utilisez [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) pour définir la couleur de surbrillance par défaut d’un paragraphe, ou utilisez [BasePortionFormat.highlight_color](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/highlight_color/) pour des portions de texte individuelles.

L’exemple suivant définit une surbrillance gris clair comme valeur par défaut du premier paragraphe. Les couleurs de surbrillance explicites sur des portions individuelles ont la priorité sur cette valeur par défaut :

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Définir la couleur de surbrillance pour l'ensemble du paragraphe.
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![Le paragraphe gris](gray_paragraph.png)

L’exemple de code ci‑dessous montre comment définir la couleur d’arrière‑plan pour **les portions de texte avec une police en gras** :

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
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

Utilisez [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) pour définir l’alignement du paragraphe dans un cadre de texte. La valeur peut être centrée, alignée à gauche, à droite, justifiée, etc.

L’exemple de code suivant montre comment aligner le paragraphe au **centre** :

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Définir l'alignement du paragraphe au centre.
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![Le paragraphe aligné](aligned_paragraph.png)

## **Aligner les polices au sein d’une ligne**

Utilisez [ParagraphFormat.font_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/font_alignment/) pour aligner verticalement les portions de texte de tailles de police différentes au sein d’une même ligne. Ce paramètre s’applique à l’ensemble du paragraphe et contrôle l’alignement au sein de chacune de ses lignes.

L’exemple autonome suivant crée quatre zones de texte intitulées sur une même diapositive. Chaque paragraphe contient le même texte en 18, 36 et 54 points, avec un alignement de police différent. Il utilise Arial, désactive l’ajustement automatique et le renvoi à la ligne, et garde les cadres de texte suffisamment grands pour une seule ligne.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    alignments = [slides.FontAlignment.BASELINE, slides.FontAlignment.TOP, slides.FontAlignment.CENTER, slides.FontAlignment.BOTTOM]
    font_sizes = [18, 36, 54]

    for i, alignment in enumerate(alignments):
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 20 + i * 130, 660, 120)
        shape.fill_format.fill_type = slides.FillType.NO_FILL
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

        text_frame = shape.text_frame
        text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.TOP
        text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
        text_frame.text_frame_format.wrap_text = slides.NullableBool.FALSE

        label = text_frame.paragraphs[0]
        label.text = alignment.name.title()
        label.paragraph_format.alignment = slides.TextAlignment.LEFT
        label.paragraph_format.default_portion_format.font_height = 14
        label.paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
        label.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        label.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.gray

        paragraph = slides.Paragraph()
        paragraph.paragraph_format.font_alignment = alignment
        paragraph.paragraph_format.alignment = slides.TextAlignment.LEFT
        paragraph.paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
        paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black

        for font_size in font_sizes:
            portion = slides.Portion("Ag ")
            portion.portion_format.font_height = font_size
            paragraph.portions.add(portion)

        text_frame.paragraphs.add(paragraph)

    presentation.save("font_alignment.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![Comparaison des alignements Baseline, Top, Center et Bottom avec des tailles de police mixtes](font_alignment.png)

L’alignement de police utilise les métriques de la police, de sorte que les bords visibles de chaque lettre ne sont pas forcément parfaitement alignés. L’exemple comprend à la fois une majuscule et un caractère descendant afin d’illustrer la différence entre l’alignement de base et l’alignement inférieur. La disponibilité et le remplacement de la police, les caractères utilisés et la différence de tailles de police influencent le résultat. Les dimensions du cadre, les marges, l’espacement des lignes, le renvoi à la ligne et l’ajustement automatique affectent également la mise en page ; utilisez les mêmes polices et paramètres de mise en page lors de la comparaison des modes.

Ce paramètre diffère de [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/), qui contrôle l’alignement horizontal du paragraphe, et de [TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/), qui positionne le bloc de texte verticalement dans sa forme. Le formatage en exposant et indice via [BasePortionFormat.escapement](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/escapement/) décale les portions individuelles par rapport à la ligne de base au lieu de définir l’alignement de police pour les lignes du paragraphe.

## **Définir la transparence du texte**

La transparence du texte est contrôlée par le composant alpha de la couleur attribuée à [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/). Dans les exemples ci‑dessous, `alpha = 50` est une valeur de canal alpha ARGB sur l’échelle 0‑255, et non un pourcentage de transparence.

L’exemple de code suivant montre comment appliquer la transparence à **l’ensemble du paragraphe** :

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Définir un remplissage noir semi-transparent pour le texte.
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![Le paragraphe transparent](transparent_paragraph.png)

L’exemple de code suivant montre comment appliquer la transparence à **des portions de texte avec une police en gras** :

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
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

## **Définir l’espacement des caractères du texte**

Utilisez [BasePortionFormat.spacing](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/spacing/) pour élargir ou condenser l’espacement entre les caractères d’une zone de texte. Les exemples ajoutent 3 points d’espacement ; les valeurs négatives condensent le texte.

Le code Python suivant montre comment élargir l’espacement des caractères dans **l’ensemble du paragraphe** :

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Remarque: utilisez des valeurs négatives pour comprimer l'espacement des caractères.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # Étendre l'espacement des caractères.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![L’espacement des caractères dans le paragraphe](character_spacing_in_paragraph.png)

L’exemple de code ci‑dessous montre comment élargir l’espacement des caractères dans **des portions de texte avec une police en gras** :

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Remarque: utilisez des valeurs négatives pour comprimer l'espacement des caractères.
            portion.portion_format.spacing = 3  # Étendre l'espacement des caractères.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![L’espacement des caractères dans les portions de texte](character_spacing_in_text_portions.png)

### **Désactiver le crénage pour des polices spécifiques**

Dans certains cas, le texte rendu par Aspose.Slides peut paraître légèrement plus serré que le même texte affiché dans PowerPoint. Cela peut se produire parce que PowerPoint ignore les données de crénage pour certaines polices, même lorsque la police contient des informations de crénage valides et que le crénage est activé dans les paramètres de PowerPoint.

Pour rapprocher le rendu de celui de PowerPoint dans ces cas, vous pouvez désactiver le crénage pour les portions de texte qui utilisent la police concernée. Définissez [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) sur une valeur supérieure à la taille réelle de la police. Cet exemple nécessite « presentation.pptx » avec une zone de texte en première forme de la première diapositive. Il vérifie les noms de police effectifs, y compris les polices héritées, et fixe un seuil de 100 points pour les portions qui utilisent Roboto. Cela désactive le crénage pour les portions correspondantes dont la taille de police est inférieure à 100 points :

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    target_font = "Roboto"

    for paragraph in auto_shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            text_format = portion.portion_format.get_effective()
            fonts = (text_format.latin_font, text_format.east_asian_font, text_format.complex_script_font)
            uses_target_font = any(font is not None and font.font_name == target_font for font in fonts)

            if uses_target_font:
                portion.portion_format.kerning_minimal_size = 100

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Pour le texte correspondant en dessous du seuil, ce paramètre empêche le crénage et peut aider à aligner le rendu d’Aspose.Slides sur la sortie visuelle de PowerPoint pour les polices affectées par ce comportement spécifique à PowerPoint.

## **Gérer les propriétés de police du texte**

Les propriétés de police peuvent être définies au niveau du paragraphe via [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) ou sur des portions individuelles via [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/).

L’exemple suivant définit la police par défaut du premier paragraphe à Times New Roman 12 pt avec gras, italique et soulignement pointillé. Le formatage explicite sur les portions individuelles a la priorité sur ces valeurs par défaut.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Définir les propriétés de police du paragraphe.
    portion_format = paragraph.paragraph_format.default_portion_format
    portion_format.font_height = 12
    portion_format.font_bold = slides.NullableBool.TRUE
    portion_format.font_italic = slides.NullableBool.TRUE
    portion_format.font_underline = slides.TextUnderlineType.DOTTED
    portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![Les propriétés de police du paragraphe](font_properties_for_paragraph.png)

L’exemple suivant applique Times New Roman 13 pt, un formatage italique et un soulignement pointillé aux portions dont le formatage effectif est gras :

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
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

## **Contrôler la normalisation de la hauteur du texte**

Utilisez [BasePortionFormat.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/normalise_height/) lors de la reproduction de la typographie d’un modèle ou pour enquêter sur les différences de hauteur des caractères. Dans PowerPoint, l’activation de la normalisation étire ou compresse verticalement les caractères individuels afin de leur donner une hauteur visible uniforme au sein de la portion de texte. Cela ne garantit pas des hauteurs de texte égales entre différentes polices.

Définissez la propriété sur [NullableBool.TRUE ou FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) pour activer ou désactiver explicitement la normalisation. `NullableBool.NOT_DEFINED` laisse le réglage local non défini afin que la portion hérite de la valeur, par exemple, du [default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) du paragraphe. Cela ne signifie pas `False`. Utilisez [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/) et lisez [IBasePortionFormatEffectiveData.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseportionformateffectivedata/normalise_height/) pour obtenir la valeur booléenne résolue.

L’exemple autonome suivant nécessite **Arial** installé. Il crée deux blocs de texte contenant les mêmes lettres majuscules, minuscules, descendantes et caractères accentués en 54 pt. Les deux paragraphes activent la normalisation par défaut. La portion supérieure la désactive explicitement ; la portion inférieure l’hérite. Les tailles de cadre, les marges et l’espacement des paragraphes sont identiques, le renvoi à la ligne et l’ajustement automatique étant désactivés pour garder la comparaison cohérente. L’exemple affiche `FALSE: False` et `NOT_DEFINED: True`, puis enregistre « text_height_normalization.pptx ».

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    settings = [slides.NullableBool.FALSE, slides.NullableBool.NOT_DEFINED]

    for i, setting in enumerate(settings):
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 60 + i * 200, 660, 150)
        shape.fill_format.fill_type = slides.FillType.NO_FILL
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

        text_frame = shape.text_frame
        text_frame.text = "Hxgjpq ÅÉ 0123"
        text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
        text_frame.text_frame_format.wrap_text = slides.NullableBool.FALSE
        text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.TOP
        text_frame.text_frame_format.margin_top = 0
        text_frame.text_frame_format.margin_left = 0

        paragraph = text_frame.paragraphs[0]
        paragraph.paragraph_format.alignment = slides.TextAlignment.LEFT
        paragraph.paragraph_format.space_before = 0
        paragraph.paragraph_format.space_after = 0
        paragraph.paragraph_format.space_within = 100
        paragraph.paragraph_format.default_portion_format.normalise_height = slides.NullableBool.TRUE

        portion = paragraph.portions[0]
        portion.portion_format.latin_font = slides.FontData("Arial")
        portion.portion_format.font_height = 54
        portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
        portion.portion_format.fill_format.solid_fill_color.color = "black"
        portion.portion_format.normalise_height = setting

        print(f"{setting.name}: {portion.portion_format.get_effective().normalise_height}")

    presentation.save("text_height_normalization.pptx", slides.export.SaveFormat.PPTX)
```

La comparaison ci‑dessous a été exportée depuis la présentation enregistrée. La rangée supérieure a la normalisation désactivée (`FALSE`) ; la rangée inférieure hérite du réglage activé (`NOT_DEFINED` → `True`). Gardez Arial installé pour reproduire cet aspect.

![Texte Arial 54 pt avec normalisation désactivée en haut et normalisation héritée activée en bas](text_height_normalization.png)

La normalisation modifie la hauteur des caractères sans modifier la valeur [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) assignée, qui spécifie la taille de police en points. L’espacement de paragraphes [space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) contrôle l’espacement des lignes, tandis que [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) du cadre de texte contrôle la façon dont le texte ou son conteneur s’ajuste. Ces paramètres ont des objectifs différents et peuvent influencer la mise en page globale de manière indépendante. Pour plus d’informations sur le formatage des paragraphes et l’héritage, voir [Gérer les paragraphes](/slides/fr/python-net/manage-paragraph/).

## **Appliquer et supprimer le texte barré**

Utilisez [BasePortionFormat.strikethrough_type](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/strikethrough_type/) sur une portion de texte pour afficher des corrections, des termes annulés ou des prix précédents sans supprimer le texte original. Réglez-le sur [TextStrikethroughType.SINGLE ou DOUBLE](https://reference.aspose.com/slides/python-net/aspose.slides/textstrikethroughtype/) pour une ou deux lignes traversant le texte.

Pour supprimer le texte barré, attribuez `TextStrikethroughType.NONE`. Cela désactive explicitement l’effet, même si le formatage environnant spécifie un texte barré. En revanche, `TextStrikethroughType.NOT_DEFINED` laisse le réglage local non défini, permettant à la portion d’hériter du formatage, par exemple du paragraphe. Cela ne garantit pas que le texte barré soit supprimé. Utilisez [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/) pour lire le formatage résultant, y compris les valeurs héritées.

L’exemple autonome suivant crée trois comparaisons de prix. Chaque paragraphe possède des portions distinctes pour le libellé, le prix précédent et le prix actuel, de sorte que seul le prix précédent est affecté. La première rangée applique puis supprime le texte barré ; les autres rangées conservent le texte barré simple et double. Modifier cette propriété conserve le texte et son autre formatage, y compris le prix précédent en gras.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 620, 220)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.paragraphs.clear()

    labels = ["None: ", "Single: ", "Double: "]

    for label in labels:
        paragraph = slides.Paragraph()
        paragraph.paragraph_format.alignment = slides.TextAlignment.LEFT
        paragraph.paragraph_format.space_after = 20

        portion_format = paragraph.paragraph_format.default_portion_format
        portion_format.font_height = 28
        portion_format.latin_font = slides.FontData("Arial")
        portion_format.fill_format.fill_type = slides.FillType.SOLID
        portion_format.fill_format.solid_fill_color.color = draw.Color.black

        paragraph.portions.add(slides.Portion(label))

        previous_price = slides.Portion("$100")
        previous_price.portion_format.font_bold = slides.NullableBool.TRUE
        paragraph.portions.add(previous_price)
        paragraph.portions.add(slides.Portion(" → $80"))

        shape.text_frame.paragraphs.add(paragraph)

    paragraphs = shape.text_frame.paragraphs

    # Appliquer le texte barré, puis le supprimer explicitement du premier prix précédent.
    paragraphs[0].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.SINGLE
    paragraphs[0].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.NONE

    paragraphs[1].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.SINGLE
    paragraphs[2].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.DOUBLE

    presentation.save("strikethrough.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat, de haut en bas : aucun texte barré, texte barré simple, texte barré double.

![Prix précédents sans texte barré, avec texte barré simple et avec texte barré double](strikethrough.png)

## **Définir la rotation du texte**

Utilisez [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) pour définir une orientation de texte prédéfinie au sein d’une forme.

L’exemple de code suivant définit l’orientation du texte dans la forme sur [TextVerticalType.VERTICAL270](https://reference.aspose.com/slides/python-net/aspose.slides/textverticaltype/), qui fait pivoter le texte de **90 degrés dans le sens inverse des aiguilles d’une montre** :

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![La rotation du texte](text_rotation.png)

## **Afficher les chiffres côte à côte dans du texte vertical**

Pour conserver un nombre à deux chiffres ensemble dans une étiquette japonaise verticale, placez les deux chiffres dans une même portion de texte et définissez [BasePortionFormat.kumimoji](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/kumimoji/) sur cette portion. L’exemple crée deux étiquettes dans une nouvelle présentation en utilisant [TextVerticalType.EAST_ASIAN_VERTICAL](https://reference.aspose.com/slides/python-net/aspose.slides/textverticaltype/) et MS Gothic 40 pt. Seule la valeur [NullableBool](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) attribuée à la portion numérique diffère.

```python
import aspose.slides as slides


def add_label(slide, x, kumimoji):
    label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, 48, 120, 420)
    label.fill_format.fill_type = slides.FillType.NO_FILL
    label.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    frame = label.add_text_frame("")
    frame.text_frame_format.text_vertical_type = slides.TextVerticalType.EAST_ASIAN_VERTICAL

    paragraph = frame.paragraphs[0]
    portion_format = paragraph.paragraph_format.default_portion_format
    font = slides.FontData("MS Gothic")
    portion_format.latin_font = font
    portion_format.east_asian_font = font
    portion_format.font_height = 40
    portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion_format.fill_format.solid_fill_color.color = "black"

    digits = slides.Portion("12")
    digits.portion_format.kumimoji = kumimoji

    paragraph.portions.clear()
    paragraph.portions.add(slides.Portion("令和"))
    paragraph.portions.add(digits)
    paragraph.portions.add(slides.Portion("年"))


with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    add_label(slide, 120, slides.NullableBool.TRUE)
    add_label(slide, 360, slides.NullableBool.FALSE)
    
    presentation.save("vertical_date.pptx", slides.export.SaveFormat.PPTX)
```

Dans PowerPoint, l’étiquette de gauche (`TRUE`) montre les chiffres droits et côte à côte entre 和 et 年. Dans l’étiquette de droite (`FALSE`), la paire est tournée de 90 degrés dans le sens des aiguilles d’une montre. Les caractères japonais environnants restent droits dans les deux étiquettes.

![Comparaison PowerPoint des étiquettes de date verticales avec chiffres droits à gauche et chiffres tournés à droite.](vertical_date.png)

## **Définir une rotation personnalisée pour les cadres de texte**

Utilisez [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) pour définir un angle de rotation personnalisé pour un [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).

L’exemple de code ci‑dessus fait pivoter le cadre de texte de 3 degrés dans le sens des aiguilles d’une montre au sein de la forme :

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![La rotation personnalisée du texte](custom_text_rotation.png)

## **Définir l’espacement des lignes des paragraphes**

Aspose.Slides propose [ParagraphFormat.space_after](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_before/) et [ParagraphFormat.space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) pour contrôler l’espacement des paragraphes. Ces propriétés sont utilisées comme suit :

* Utilisez une valeur positive pour spécifier l’interligne en pourcentage de la hauteur de ligne.
* Utilisez une valeur négative pour spécifier l’interligne en points.

L’exemple suivant définit l’espacement à l’intérieur du premier paragraphe à 200 % de la hauteur de ligne (interligne double) :

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.space_within = 200

    presentation.save("line_spacing.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![L’interligne au sein du paragraphe](line_spacing.png)

## **Contrôler le retour à la ligne**

Les règles de retour à la ligne des paragraphes sont utiles dans les blocs de texte étroits et les présentations qui mêlent texte latin et texte d’Asie de l’Est. Les propriétés suivantes appartiennent à [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/), de sorte qu’elles s’appliquent à l’ensemble d’un paragraphe :

- [latin_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/latin_line_break/) contrôle les règles de retour à la ligne latines. Dans un texte mixte, le modifier peut aussi changer l’endroit où le texte asiatique adjacent et la ponctuation se replient.
- [east_asian_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/east_asian_line_break/) contrôle les règles de retour à la ligne d’Asie de l’Est, y compris les restrictions sur les caractères en début et fin de ligne.

Ces règles ne remplacent pas [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/), qui active le renvoi à la ligne automatique dans un cadre de texte. Elles influencent la mise en page lorsque le renvoi à la ligne se produit ; elles n’insèrent pas de caractères de saut de ligne. Un saut de ligne explicite force une nouvelle ligne dans le paragraphe indépendamment de la largeur disponible.

L’exemple autonome suivant crée un bloc de texte étroit contenant du chinois et du latin. Il définit explicitement les deux propriétés de retour à la ligne et enregistre « line_breaking.pptx ». Pour expérimenter avec l’une ou l’autre règle, changez la valeur de la propriété correspondante tout en maintenant les autres réglages fixes. L’exemple utilise Arial 24 pt et SimSun avec une largeur de cadre de 160 pt et des marges horizontales du cadre de texte à zéro. [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) est réglé sur [TextAutofitType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/textautofittype/) afin que la taille du texte et les dimensions du cadre restent fixes.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 160, 300)
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
    text_frame.text_frame_format.margin_left = 0
    text_frame.text_frame_format.margin_right = 0

    paragraph = text_frame.paragraphs[0]
    paragraph.text = "中文排版测试，PowerPoint 中文演示。"

    paragraph_format = paragraph.paragraph_format
    paragraph_format.alignment = slides.TextAlignment.LEFT
    paragraph_format.default_portion_format.font_height = 24
    paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
    paragraph_format.default_portion_format.east_asian_font = slides.FontData("SimSun")
    paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph_format.latin_line_break = slides.NullableBool.FALSE
    paragraph_format.east_asian_line_break = slides.NullableBool.TRUE

    presentation.save("line_breaking.pptx", slides.export.SaveFormat.PPTX)
```

## **Contrôler la ponctuation suspendue**

[ParagraphFormat.hanging_punctuation](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/hanging_punctuation/) permet à la ponctuation admissible de dépasser le bord droit de la ligne de texte au lieu d’occuper la ligne suivante. Elle s’applique à l’ensemble du paragraphe et diffère d’un retrait suspendu.

L’exemple autonome suivant active la ponctuation suspendue dans un cadre de texte de 100 pt de large et enregistre « hanging_punctuation.pptx ». Avec Arial 24 pt et des marges horizontales du cadre de texte à zéro, le point final reste après « sentence » et dépasse le bord droit du texte. Réglez la propriété sur [NullableBool.FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) pour comparer : avec ces réglages, le point occupe une ligne distincte. Le renvoi à la ligne est activé et l’ajustement automatique désactivé afin de maintenir la largeur disponible fixe.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 100, 200)
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
    text_frame.text_frame_format.margin_left = 0
    text_frame.text_frame_format.margin_right = 0

    paragraph = text_frame.paragraphs[0]
    paragraph.text = "Simple text, next sentence."

    paragraph_format = paragraph.paragraph_format
    paragraph_format.alignment = slides.TextAlignment.LEFT
    paragraph_format.default_portion_format.font_height = 24
    paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
    paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph_format.hanging_punctuation = slides.NullableBool.TRUE

    presentation.save("hanging_punctuation.pptx", slides.export.SaveFormat.PPTX)
```

Toutes les marques de ponctuation ne peuvent pas être suspendues. Le résultat visible dépend des [conditions de police et de mise en page](#control-line-breaking) : changer la police, la largeur disponible, les marges ou les réglages d’ajustement automatique peut supprimer la différence visible.

## **Définir le type d’ajustement automatique pour les cadres de texte**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) détermine comment le texte se comporte lorsqu’il dépasse les limites de son conteneur. Utilisez‑le pour contrôler si le texte se rétrécit, déborde ou redimensionne automatiquement la forme. L’exemple suivant configure la forme pour qu’elle redimensionne afin d’ajuster son texte et enregistre le résultat sous « autofit_type.pptx ».

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

Pour compter les lignes après un renvoi à la ligne automatique et voir comment la largeur du texte ou de la forme modifie le résultat, consultez [Count Rendered Lines](/slides/fr/python-net/manage-paragraph/). Le nombre de lignes seul ne indique pas si le texte dépasse son conteneur.

## **Définir l’ancre des cadres de texte**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/) définit comment le texte est positionné verticalement à l’intérieur d’une forme, par exemple en haut, au milieu ou en bas. L’exemple suivant ancre le texte en bas de la première forme et enregistre le résultat sous « text_anchor.pptx ».

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir la tabulation du texte**

Utilisez [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_tab_size/) et [ParagraphFormat.tabs](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/tabs/) pour configurer les tabulations dans un paragraphe. L’exemple suivant fixe l’intervalle de tabulation par défaut à 100 points et ajoute une tabulation alignée à gauche à 30 points. Ces réglages affectent le texte contenant des caractères de tabulation.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.default_tab_size = 100
    paragraph.paragraph_format.tabs.add(30, slides.TabAlignment.LEFT)

    presentation.save("paragraph_tabs.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![Les tabulations du paragraphe](paragraph_tabs.png)

## **Définir la langue de vérification**

Aspose.Slides fournit [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/), qui permet de définir la langue de vérification pour une portion de texte. La langue de vérification détermine la langue utilisée pour les contrôles orthographiques et grammaticaux dans PowerPoint.

L’exemple suivant nécessite « presentation.pptx » avec une zone de texte en première forme de la première diapositive et au moins un paragraphe. Il remplace le contenu du premier paragraphe par « 1。 », définit SimSun comme police et attribue la langue de vérification chinois simplifié (`zh-CN`). Il enregistre le résultat sous « proofing_language.pptx » :

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    font = slides.FontData("SimSun")

    text_portion = slides.Portion()
    text_portion.portion_format.complex_script_font = font
    text_portion.portion_format.east_asian_font = font
    text_portion.portion_format.latin_font = font

    # Définir la langue de vérification sur le chinois simplifié.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

### **Copier les métadonnées de langue**

Lors de la copie de texte multilingue depuis un modèle, conservez à la fois [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/) et [BasePortionFormat.alternative_language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/alternative_language_id/). L’exemple autonome suivant crée une portion source avec l’anglais américain comme langue et le français comme langue alternative, puis copie le texte et les identifiants dans une portion d’une nouvelle présentation.

```python
import aspose.slides as slides

source = slides.Portion("Hello! Bonjour!")
source.portion_format.language_id = "en-US"
source.portion_format.alternative_language_id = "fr-FR"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 80)
    paragraph = shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    destination = slides.Portion()
    destination.text = source.text
    destination.portion_format.language_id = source.portion_format.language_id
    # Si la source n'a pas de langue alternative, None efface la valeur de destination.
    destination.portion_format.alternative_language_id = source.portion_format.alternative_language_id
    paragraph.portions.add(destination)

    presentation.save("copied_language_metadata.pptx", slides.export.SaveFormat.PPTX)
```

Pour tester une source sans langue alternative, omettez l’attribution de `"fr-FR"`. L’identifiant alternatif sera alors `None`, et la même instruction de copie préserve son absence sans introduire de valeur par défaut, même si la destination possédait auparavant une langue alternative assignée.

Ces identifiants sont stockés comme métadonnées de langue. Les conserver n’influe pas sur le dictionnaire que PowerPoint sélectionnera pour l’orthographe ou la grammaire.

## **Définir la langue par défaut**

Utilisez [LoadOptions.default_text_language](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/default_text_language/) pour définir la langue par défaut du texte créé lors du chargement ou de la création d’une présentation. L’exemple suivant crée une présentation avec l’anglais américain comme langue de texte par défaut, ajoute une zone de texte et affiche `en-US` pour sa première portion de texte.

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

Pour appliquer un formatage de texte par défaut au niveau de la présentation, utilisez [Presentation.default_text_style](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/default_text_style/).

L’exemple suivant définit une police en gras de 14 pt comme style par défaut pour les paragraphes de niveau supérieur d’une nouvelle présentation et l’enregistre sous « default_text_style.pptx ». Le texte peut hériter de ces valeurs par défaut sauf si un formatage plus spécifique les surcharge.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Obtenir le format de paragraphe de niveau supérieur.
    paragraph_format = presentation.default_text_style.get_level(0)

    if paragraph_format is not None:
        paragraph_format.default_portion_format.font_height = 14
        paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("default_text_style.pptx", slides.export.SaveFormat.PPTX)
```

## **Extraire le texte avec l’effet Tout en majuscules**

Dans PowerPoint, appliquer l’effet de police **Tout en majuscules** rend le texte affiché en majuscules sur la diapositive même s’il a été tapé en minuscules. Lorsque vous récupérez une telle portion de texte avec Aspose.Slides, la bibliothèque renvoie le texte exactement tel qu’il a été saisi. Pour correspondre au texte affiché, vérifiez [TextCapType](https://reference.aspose.com/slides/python-net/aspose.slides/textcaptype/) et convertissez la chaîne renvoyée en majuscules lorsque la valeur est `ALL`.

Cet exemple nécessite « sample2.pptx » avec une zone de texte en première forme de la première diapositive. Sa première portion du premier paragraphe contient « Hello, Aspose! » avec l’effet Tout en majuscules appliqué, comme illustré ci‑dessous.

![L’effet Tout en majuscules](all_caps_effect.png)

L’exemple de code ci‑dessous montre comment extraire le texte avec l’effet **Tout en majuscules** appliqué :

```python
import aspose.slides as slides

with slides.Presentation("sample2.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
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

**Comment modifier le texte d’un tableau sur une diapositive ?**

Pour modifier le texte d’un tableau sur une diapositive, utilisez [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/). Parcourez les cellules et mettez à jour chaque cellule via [Cell.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/) et le formatage des paragraphes via [Paragraph.paragraph_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/paragraph_format/).

**Comment appliquer une couleur de dégradé au texte d’une diapositive PowerPoint ?**

Pour appliquer une couleur de dégradé au texte, utilisez [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/). Réglez [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) sur [FillType.GRADIENT](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) et configurez les arrêts de dégradé, la direction et la transparence.

Fonctionnalité connexe : [Formater le texte dans les diapositives](/slides/fr/features/text-formatting/).