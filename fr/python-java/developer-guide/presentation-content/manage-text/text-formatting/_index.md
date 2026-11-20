---
title: Formater le texte de la présentation en Python via Java
linktitle: Mise en forme du texte
type: docs
weight: 50
url: /fr/python-java/text-formatting/
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
- interligne
- propriété autofit
- ancrage du cadre de texte
- tabulation du texte
- langue par défaut
- PowerPoint
- OpenDocument
- présentation
- Python
- Java
- Aspose.Slides
description: "Formatez et stylisez le texte dans les présentations PowerPoint et OpenDocument à l’aide d’Aspose.Slides pour Python via Java. Personnalisez les polices, les couleurs, l’alignement et plus encore."
---
## **Vue d'ensemble**

Cet article montre comment mettre en forme du texte dans les présentations PowerPoint et OpenDocument à l’aide d’Aspose.Slides for Python via Java. Il couvre les couleurs d’arrière‑plan, la transparence, l’espacement des caractères, les propriétés de police, la rotation, l’interligne des paragraphes, le comportement autofit, l’ancrage du texte, les taquets de tabulation et les paramètres de langue.

Sauf indication contraire, les exemples utilisent [sample.pptx](sample.pptx). La première forme de la première diapositive est une zone de texte, et son premier paragraphe contient le texte présenté ci‑dessous. Les indices de diapositive et de forme sont à base zéro. Les exemples qui sélectionnent des portions en gras utilisent le format effectif, y compris le format gras hérité :

![Texte d’exemple](sample_text.png)

Pour rechercher et mettre en évidence du texte littéral ou des correspondances d’expression régulière, voir [Search and Replace Text](/slides/fr/python-java/search-and-replace-text/).

## **Définir la couleur d’arrière‑plan du texte**

Utilisez [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) pour définir la couleur de surbrillance par défaut d’un paragraphe, ou utilisez [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getHighlightColor) pour des portions de texte individuelles.

L’exemple suivant définit une surbrillance gris clair comme valeur par défaut du premier paragraphe. Les couleurs de surbrillance explicites sur les portions individuelles ont la priorité sur cette valeur par défaut :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Définir la couleur de surbrillance pour tout le paragraphe.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le résultat :

![Le paragraphe gris](gray_paragraph.png)

L’exemple de code ci‑dessous montre comment définir la couleur d’arrière‑plan pour **les portions de texte avec une police en gras** :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # Définir la couleur de surbrillance pour la portion de texte.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le résultat :

![Les portions de texte grises](gray_text_portions.png)

## **Aligner les paragraphes de texte**

Utilisez [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) pour définir l’alignement du paragraphe dans un cadre de texte. La valeur peut être centrée, alignée à gauche, à droite, justifiée, etc.

L’exemple suivant montre comment aligner le paragraphe au **centre** :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAlignment

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Définir l'alignement du paragraphe au centre.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center)

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le résultat :

![Le paragraphe aligné](aligned_paragraph.png)

## **Aligner les polices au sein d’une ligne**

Utilisez [ParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setFontAlignment) pour aligner verticalement les portions de texte de tailles de police différentes au sein d’une ligne. Ce paramètre s’applique à tout le paragraphe et contrôle l’alignement dans chacune de ses lignes.

L’exemple autonome suivant crée quatre zones de texte étiquetées sur une diapositive. Chaque paragraphe contient le même texte en 18, 36 et 54 points, avec un alignement de police différent. Il utilise Arial, désactive l’autofit et le retour à la ligne, et maintient les cadres de texte suffisamment larges pour une seule ligne.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontAlignment, FontData, NullableBool, Paragraph, Portion, Presentation, SaveFormat, ShapeType, TextAlignment, TextAnchorType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    alignments = [FontAlignment.Baseline, FontAlignment.Top, FontAlignment.Center, FontAlignment.Bottom]
    alignment_names = ["Baseline", "Top", "Center", "Bottom"]
    font_sizes = [18.0, 36.0, 54.0]
    font = FontData("Arial")

    for i, alignment in enumerate(alignments):
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 20 + i * 130, 660, 120)
        shape.getFillFormat().setFillType(FillType.NoFill)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

        text_frame = shape.getTextFrame()
        text_frame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top)
        text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
        text_frame.getTextFrameFormat().setWrapText(NullableBool.False_)

        label = text_frame.getParagraphs().get_Item(0)
        label.setText(alignment_names[i])
        label.getParagraphFormat().setAlignment(TextAlignment.Left)
        label.getParagraphFormat().getDefaultPortionFormat().setFontHeight(14)
        label.getParagraphFormat().getDefaultPortionFormat().setLatinFont(font)
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)

        paragraph = Paragraph()
        paragraph.getParagraphFormat().setFontAlignment(alignment)
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left)
        paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(font)
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        for font_size in font_sizes:
            portion = Portion("Ag ")
            portion.getPortionFormat().setFontHeight(font_size)
            paragraph.getPortions().add(portion)

        text_frame.getParagraphs().add(paragraph)

    presentation.save("font_alignment.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le résultat :

![Comparaison des alignements Baseline, Top, Center et Bottom avec des tailles de police mixtes](font_alignment.png)

L’alignement de police utilise les métriques de la police ; les bords visibles des lettres individuelles ne sont donc pas forcément parfaitement alignés. L’exemple inclut une lettre majuscule et un descendant pour illustrer la différence entre l’alignement sur la ligne de base et le bas. La disponibilité des polices, la substitution, les caractères utilisés et la différence de tailles de police influent sur le résultat. Les dimensions du cadre, les marges, l’interligne, le retour à la ligne et l’autofit affectent également la mise en page ; utilisez les mêmes polices et paramètres de mise en page lors de la comparaison des modes.

Ce paramètre diffère de [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment), qui contrôle l’alignement horizontal du paragraphe, et de [TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAnchoringType), qui positionne verticalement le bloc de texte dans sa forme. La mise en forme exposant et indice via [BasePortionFormat.setEscapement](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setEscapement) décale les portions individuelles par rapport à la ligne de base au lieu de définir l’alignement de police pour les lignes du paragraphe.

## **Définir la transparence du texte**

La transparence du texte est contrôlée via le composant alpha de la couleur attribuée à [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFillFormat). Dans les exemples ci‑dessous, `alpha = 50` est une valeur alpha ARGB sur l’échelle 0‑255, et non un pourcentage de transparence.

L’exemple de code suivant montre comment appliquer la transparence à **l’ensemble du paragraphe** :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

alpha = 50
text_color = Color(0, 0, 0, alpha)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Définir la couleur de remplissage du texte sur une couleur transparente.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le résultat :

![Le paragraphe transparent](transparent_paragraph.png)

L’exemple suivant montre comment appliquer la transparence à **les portions de texte avec une police en gras** :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

alpha = 50
text_color = Color(0, 0, 0, alpha)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # Définir la transparence de la portion de texte.
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le résultat :

![Les portions de texte transparentes](transparent_text_portions.png)

## **Définir l’espacement des caractères du texte**

Utilisez [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setSpacing) pour augmenter ou réduire l’espacement entre les caractères dans une zone de texte. Les exemples ajoutent 3 points d’espacement ; des valeurs négatives condensent le texte.

Le code Python suivant montre comment augmenter l’espacement des caractères dans **l’ensemble du paragraphe** :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Remarque: utilisez des valeurs négatives pour compresser l'espacement des caractères.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3) # Augmenter l'espacement des caractères.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le résultat :

![L’espacement des caractères dans le paragraphe](character_spacing_in_paragraph.png)

L’exemple de code ci‑dessous montre comment augmenter l’espacement des caractères dans **les portions de texte avec une police en gras** :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpile.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # Remarque: utilisez des valeurs négatives pour compresser l'espacement des caractères.
            portion.getPortionFormat().setSpacing(3) # Augmenter l'espacement des caractères.

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le résultat :

![L’espacement des caractères dans les portions de texte](character_spacing_in_text_portions.png)

### **Désactiver le crénage pour des polices spécifiques**

Dans certains cas, le texte rendu par Aspose.Slides peut paraître légèrement plus serré que le même texte affiché dans PowerPoint. Cela peut se produire parce que PowerPoint ignore les données de crénage pour certaines polices, même si la police contient des informations de crénage valides et que le crénage est activé dans les paramètres de PowerPoint.

Pour rapprocher le rendu de celui de PowerPoint, vous pouvez désactiver le crénage pour les portions de texte qui utilisent la police concernée. Définissez [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setKerningMinimalSize) sur une valeur supérieure à la taille réelle de la police. Cet exemple nécessite « presentation.pptx » contenant une zone de texte comme première forme de la première diapositive. Il vérifie les noms de police effectifs, y compris les polices héritées, et fixe un seuil de 100 points pour les portions utilisant Roboto. Cela désactive le crénage pour les portions correspondantes dont la taille de police est inférieure à 100 points :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    target_font = "Roboto"

    for paragraph in auto_shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            portion_format = portion.getPortionFormat().getEffective()
            fonts = (portion_format.getLatinFont(), portion_format.getEastAsianFont(), portion_format.getComplexScriptFont())
            if any(font is not None and font.getFontName() == target_font for font in fonts):
                portion.getPortionFormat().setKerningMinimalSize(100)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Pour le texte correspondant situé en dessous du seuil, ce paramètre empêche le crénage et peut aider à aligner le rendu d’Aspose.Slides avec la sortie visuelle de PowerPoint pour les polices concernées par ce comportement propre à PowerPoint.

## **Gérer les propriétés de police du texte**

Les propriétés de police peuvent être définies au niveau du paragraphe via [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) ou sur des portions individuelles via [PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/).

L’exemple suivant définit la police par défaut du premier paragraphe à Times New Roman 12 pt avec gras, italique et soulignement pointillé. Le formatage explicite sur les portions individuelles prend le pas sur ces valeurs par défaut.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, NullableBool, Presentation, SaveFormat, TextUnderlineType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Définir les propriétés de police du paragraphe.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(12)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontBold(NullableBool.True_)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontItalic(NullableBool.True_)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontUnderline(TextUnderlineType.Dotted)
    font = FontData("Times New Roman")
    paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(font)

    presentation.save("font_properties_for_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le résultat :

![Les propriétés de police du paragraphe](font_properties_for_paragraph.png)

L’exemple suivant applique Times New Roman 13 pt, un formatage italique et un soulignement pointillé aux portions dont le format effectif est gras :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, NullableBool, Presentation, SaveFormat, TextUnderlineType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # Définir les propriétés de police pour la portion de texte.
            portion.getPortionFormat().setFontHeight(13)
            portion.getPortionFormat().setFontItalic(NullableBool.True_)
            portion.getPortionFormat().setFontUnderline(TextUnderlineType.Dotted)
            font = FontData("Times New Roman")
            portion.getPortionFormat().setLatinFont(font)

    presentation.save("font_properties_for_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le résultat :

![Les propriétés de police des portions de texte](font_properties_for_text_portions.png)

## **Contrôler la normalisation de la hauteur du texte**

Utilisez [BasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setNormaliseHeight) lorsqu’on reproduit la typographie d’un modèle ou qu’on examine des différences de hauteur de caractère. Dans PowerPoint, activer la normalisation étire ou comprime verticalement les caractères individuels afin de leur donner une hauteur visible uniforme au sein de la portion de texte. Cela ne garantit pas des hauteurs de texte égales entre différentes polices.

Définissez la propriété sur [NullableBool.True_ ou False_](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/) pour activer ou désactiver explicitement la normalisation. `NullableBool.NotDefined` laisse le paramètre local non défini afin que la portion hérite de la valeur du paragraphe via [getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat). Ce n’est pas équivalent à `False`. Utilisez [PortionFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective) et lisez `getNormaliseHeight` sur le formatage effectif retourné pour obtenir la valeur booléenne résolue.

L’exemple autonome suivant nécessite **Arial** installé. Il crée deux blocs de texte contenant les mêmes lettres majuscules, minuscules, descendantes et caractères accentués à 54 pt. Les deux paragraphes activent la normalisation par défaut. La portion supérieure la désactive explicitement ; la portion inférieure l’hérite. Les dimensions des cadres, les marges et l’interligne sont identiques, le retour à la ligne et l’autofit étant désactivés pour garder la comparaison cohérente. L’exemple affiche `False: False` et `NotDefined: True`, puis enregistre « text_height_normalization.pptx ».

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextAlignment, TextAnchorType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    settings = [NullableBool.False_, NullableBool.NotDefined]
    setting_names = ["False", "NotDefined"]

    for i, setting in enumerate(settings):
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 60 + i * 200, 660, 150)
        shape.getFillFormat().setFillType(FillType.NoFill)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

        text_frame = shape.getTextFrame()
        text_frame.setText("Hxgjpq ÅÉ 0123")
        text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
        text_frame.getTextFrameFormat().setWrapText(NullableBool.False_)
        text_frame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top)
        text_frame.getTextFrameFormat().setMarginTop(0)
        text_frame.getTextFrameFormat().setMarginLeft(0)

        paragraph = text_frame.getParagraphs().get_Item(0)
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left)
        paragraph.getParagraphFormat().setSpaceBefore(0)
        paragraph.getParagraphFormat().setSpaceAfter(0)
        paragraph.getParagraphFormat().setSpaceWithin(100)
        paragraph.getParagraphFormat().getDefaultPortionFormat().setNormaliseHeight(NullableBool.True_)

        portion = paragraph.getPortions().get_Item(0)
        font = FontData("Arial")
        portion.getPortionFormat().setLatinFont(font)
        portion.getPortionFormat().setFontHeight(54)
        portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
        portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
        portion.getPortionFormat().setNormaliseHeight(setting)

        print(f"{setting_names[i]}: {bool(portion.getPortionFormat().getEffective().getNormaliseHeight())}")

    presentation.save("text_height_normalization.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La comparaison ci‑dessous a été exportée depuis la présentation enregistrée. La rangée supérieure a la normalisation désactivée (`False`) ; la rangée inférieure l’hérite (`NotDefined` → `True`). Conservez Arial installé pour reproduire cet aspect.

![Texte Arial 54 pt avec normalisation désactivée en haut et normalisation héritée activée en bas](text_height_normalization.png)

La normalisation modifie la hauteur des caractères sans changer la valeur assignée à [getFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFontHeight), qui indique la taille de la police en points. [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceWithin) contrôle l’interligne, tandis que [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) contrôle la façon dont le texte ou son conteneur s’ajuste. Ces paramètres servent à des fins différentes et peuvent influencer la disposition globale indépendamment. Pour plus d’informations sur le formatage des paragraphes et l’héritage, voir [Manage Paragraph](/slides/fr/python-java/manage-paragraph/).

## **Appliquer et supprimer le barré**

Utilisez [BasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setStrikethroughType) sur une portion de texte pour indiquer des corrections, des termes annulés ou des prix antérieurs sans supprimer le texte original. Définissez‑le sur [TextStrikethroughType.Single ou Double](https://reference.aspose.com/slides/python-java/aspose.slides/textstrikethroughtype/) pour une ou deux lignes traversant le texte.

Pour supprimer le barré, passez [TextStrikethroughType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/textstrikethroughtype/#None). Cela désactive explicitement l’effet, même si le formatage parent spécifie un barré. En revanche, [TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/python-java/aspose.slides/textstrikethroughtype/#NotDefined) laisse le paramètre local non défini, permettant à la portion d’hériter du formatage, par exemple du paragraphe. Cela ne garantit pas la suppression du barré. Utilisez [PortionFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective) pour lire le formatage résultant, y compris les valeurs héritées.

L’exemple autonome suivant crée trois comparaisons de prix. Chaque paragraphe comporte des portions séparées pour l’étiquette, le prix précédent et le prix actuel, de sorte que seul le prix précédent est affecté. La première rangée applique puis supprime le barré ; les autres rangées conservent respectivement le barré simple et le double. Modifier ce paramètre préserve le texte et son autre formatage, y compris le prix précédent en gras.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Paragraph, Portion, Presentation, SaveFormat, ShapeType, TextAlignment, TextStrikethroughType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 620, 220)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    shape.getTextFrame().getParagraphs().clear()

    labels = ["None: ", "Single: ", "Double: "]

    for label in labels:
        paragraph = Paragraph()
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left)
        paragraph.getParagraphFormat().setSpaceAfter(20)

        portion_format = paragraph.getParagraphFormat().getDefaultPortionFormat()
        portion_format.setFontHeight(28)
        font = FontData("Arial")
        portion_format.setLatinFont(font)
        portion_format.getFillFormat().setFillType(FillType.Solid)
        portion_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        label_portion = Portion(label)
        paragraph.getPortions().add(label_portion)

        previous_price = Portion("$100")
        previous_price.getPortionFormat().setFontBold(NullableBool.True_)
        paragraph.getPortions().add(previous_price)
        current_price = Portion(" → $80")
        paragraph.getPortions().add(current_price)

        shape.getTextFrame().getParagraphs().add(paragraph)

    paragraphs = shape.getTextFrame().getParagraphs()

    # Appliquer le barré, puis le supprimer explicitement du premier prix précédent.
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single)
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.None_)

    paragraphs.get_Item(1).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single)
    paragraphs.get_Item(2).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Double)

    presentation.save("strikethrough.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le résultat, de haut en bas : aucun barré, barré simple, barré double.

![Prix précédents sans barré, avec barré simple et avec barré double](strikethrough.png)

## **Définir la rotation du texte**

Utilisez [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType) pour définir une orientation de texte prédéfinie dans une forme.

L’exemple suivant définit l’orientation du texte dans la forme sur [TextVerticalType.Vertical270](https://reference.aspose.com/slides/python-java/aspose.slides/textverticaltype/), ce qui fait pivoter le texte de **90 degrés dans le sens inverse des aiguilles d’une montre** :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextVerticalType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270)

    presentation.save("text_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le résultat :

![La rotation du texte](text_rotation.png)

## **Définir une rotation personnalisée pour les cadres de texte**

Utilisez [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setRotationAngle) pour définir un angle de rotation personnalisé pour un [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/).

L’exemple de code ci‑dessous fait pivoter le cadre de texte de 3 degrés dans le sens des aiguilles d’une montre à l’intérieur de la forme :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setRotationAngle(3)

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le résultat :

![La rotation de texte personnalisée](custom_text_rotation.png)

## **Définir l’interligne des paragraphes**

Aspose.Slides fournit [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceBefore) et [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceWithin) pour contrôler l’interligne des paragraphes. Ces propriétés sont utilisées comme suit :

* Utilisez une valeur positive pour spécifier l’interligne en pourcentage de la hauteur de ligne.
* Utilisez une valeur négative pour spécifier l’interligne en points.

L’exemple suivant définit l’interligne au sein du premier paragraphe à 200 % de la hauteur de ligne (double interligne) :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().setSpaceWithin(200)

    presentation.save("line_spacing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le résultat :

![L’interligne au sein du paragraphe](line_spacing.png)

## **Contrôler le retour à la ligne**

Les règles de retour à la ligne des paragraphes sont utiles dans des blocs de texte étroits et des présentations qui mêlent texte latin et asiatique oriental. Les méthodes suivantes appartiennent à [ParagraphFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/), elles s’appliquent donc à un paragraphe entier :

- [setLatinLineBreak](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setLatinLineBreak) contrôle les règles de retour à la ligne latin. Dans du texte mixte, la modifier peut également changer l’endroit où le texte asiatique oriental adjacent et la ponctuation se replient.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) contrôle les règles de retour à la ligne asiatique orientale, y compris les restrictions sur les caractères en début ou fin de ligne.

Ces règles ne remplacent pas [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setWrapText), qui active le retour à la ligne automatique dans un cadre de texte. Elles influencent la disposition lorsque le retour à la ligne se produit ; elles n’insèrent pas de caractères de saut de ligne. Un saut de ligne explicite force une nouvelle ligne dans le paragraphe indépendamment de la largeur disponible.

L’exemple autonome suivant crée un bloc de texte étroit contenant du chinois et du latin. Il définit les deux options de retour à la ligne explicitement et enregistre « line_breaking.pptx ». Pour expérimenter avec l’une ou l’autre règle, modifiez la valeur correspondante tout en conservant l’autre paramètre fixe. L’exemple utilise Arial 24 pt et SimSun avec une largeur de cadre de 160 pt et des marges horizontales du cadre de texte nulles. [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) est appelé avec [TextAutofitType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/textautofittype/) afin que la taille du texte et les dimensions du cadre restent fixes.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextAlignment, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 160, 300)
    shape.getFillFormat().setFillType(FillType.NoFill)

    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setWrapText(NullableBool.True_)
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
    text_frame.getTextFrameFormat().setMarginLeft(0)
    text_frame.getTextFrameFormat().setMarginRight(0)

    paragraph = text_frame.getParagraphs().get_Item(0)
    paragraph.setText("中文排版测试，PowerPoint 中文演示。")

    paragraph_format = paragraph.getParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Left)
    paragraph_format.getDefaultPortionFormat().setFontHeight(24)
    latin_font = FontData("Arial")
    paragraph_format.getDefaultPortionFormat().setLatinFont(latin_font)
    east_asian_font = FontData("SimSun")
    paragraph_format.getDefaultPortionFormat().setEastAsianFont(east_asian_font)
    paragraph_format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph_format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph_format.setLatinLineBreak(NullableBool.False_)
    paragraph_format.setEastAsianLineBreak(NullableBool.True_)

    presentation.save("line_breaking.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Contrôler la ponctuation suspendue**

[ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setHangingPunctuation) autorise les ponctuations admissibles à dépasser le bord droit de la ligne de texte au lieu d’occuper la ligne suivante. Elle s’applique à tout le paragraphe et diffère d’un retrait suspendu.

L’exemple autonome suivant active la ponctuation suspendue dans un cadre de texte de 100 pt de large et enregistre « hanging_punctuation.pptx ». Avec Arial 24 pt et des marges horizontales nulles, le point final reste après le mot « sentence » et dépasse le bord droit du texte. Définissez la propriété sur [NullableBool.False_](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/) pour comparer : avec ces réglages, le point occupe une ligne séparée. Le retour à la ligne est activé et l’autofit désactivé afin de garder la largeur disponible fixe.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextAlignment, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 200)
    shape.getFillFormat().setFillType(FillType.NoFill)

    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setWrapText(NullableBool.True_)
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
    text_frame.getTextFrameFormat().setMarginLeft(0)
    text_frame.getTextFrameFormat().setMarginRight(0)

    paragraph = text_frame.getParagraphs().get_Item(0)
    paragraph.setText("Simple text, next sentence.")

    paragraph_format = paragraph.getParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Left)
    paragraph_format.getDefaultPortionFormat().setFontHeight(24)
    latin_font = FontData("Arial")
    paragraph_format.getDefaultPortionFormat().setLatinFont(latin_font)
    paragraph_format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph_format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph_format.setHangingPunctuation(NullableBool.True_)

    presentation.save("hanging_punctuation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Toutes les marques de ponctuation ne peuvent pas être suspendues. Les [conditions de police et de mise en page décrites ci‑dessus](#control-line-breaking) s’appliquent également à cette comparaison : changer la police, la largeur disponible, les marges ou les paramètres d’autofit peut supprimer la différence visible.

## **Définir le type d’autofit pour les cadres de texte**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) détermine le comportement du texte lorsqu’il dépasse les limites de son conteneur. Utilisez‑le pour contrôler si le texte se réduit, déborde ou redimensionne automatiquement la forme. L’exemple suivant configure la forme pour qu’elle redimensionne afin d’accueillir le texte et enregistre le résultat sous « autofit_type.pptx ».

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAutofitType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape)

    presentation.save("autofit_type.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Pour compter les lignes après le retour à la ligne automatique et voir comment la largeur du texte ou de la forme modifie le résultat, consultez [Count Rendered Lines](/slides/fr/python-java/manage-paragraph/). Le nombre de lignes seul n’indique pas si le texte déborde de son conteneur.

## **Définir l’ancrage des cadres de texte**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAnchoringType) définit la position verticale du texte à l’intérieur d’une forme, par exemple en haut, au centre ou en bas. L’exemple suivant ancre le texte au bas de la première forme et enregistre le résultat sous « text_anchor.pptx ».

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAnchorType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom)

    presentation.save("text_anchor.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Définir la tabulation du texte**

Utilisez [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDefaultTabSize) et [ParagraphFormat.getTabs](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getTabs) pour configurer les taquets de tabulation dans un paragraphe. L’exemple suivant fixe l’intervalle de tabulation par défaut à 100 points et ajoute un taquet de tabulation aligné à gauche à 30 points. Ces réglages affectent le texte contenant des caractères de tabulation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TabAlignment

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().setDefaultTabSize(100)
    paragraph.getParagraphFormat().getTabs().add(30, TabAlignment.Left)

    presentation.save("paragraph_tabs.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le résultat :

![Les tabulations du paragraphe](paragraph_tabs.png)

## **Définir la langue de vérification**

Aspose.Slides fournit [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setLanguageId), qui permet de régler la langue de vérification orthographique pour une portion de texte. La langue de vérification détermine la langue utilisée pour les contrôles d’orthographe et de grammaire dans PowerPoint.

L’exemple suivant nécessite « presentation.pptx » avec une zone de texte comme première forme de la première diapositive et au moins un paragraphe. Il remplace le contenu du premier paragraphe par « 1。 », définit SimSun comme police et attribue la langue de vérification simplifiée chinoise (`zh-CN`). Il enregistre le résultat sous « proofing_language.pptx »:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Portion, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    font = FontData("SimSun")

    text_portion = Portion()
    text_portion.getPortionFormat().setComplexScriptFont(font)
    text_portion.getPortionFormat().setEastAsianFont(font)
    text_portion.getPortionFormat().setLatinFont(font)

    # Définir l'Id d'une langue de vérification.
    text_portion.getPortionFormat().setLanguageId("zh-CN")

    text_portion.setText("1。")
    paragraph.getPortions().add(text_portion)

    presentation.save("proofing_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Copier les métadonnées de langue**

Lors de la copie de texte multilingue depuis un modèle, conservez à la fois [BasePortionFormat.getLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getLanguageId) et [BasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getAlternativeLanguageId). L’exemple autonome suivant crée une portion source avec l’anglais américain comme langue et le français comme langue alternative, puis copie le texte et les identifiants dans une portion d’une nouvelle présentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Portion, Presentation, SaveFormat, ShapeType

source = Portion("Hello! Bonjour!")
source.getPortionFormat().setLanguageId("en-US")
source.getPortionFormat().setAlternativeLanguageId("fr-FR")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 80)
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    destination = Portion()
    destination.setText(source.getText())
    destination.getPortionFormat().setLanguageId(source.getPortionFormat().getLanguageId())
    # Si la source n'a pas de langue alternative, None efface la valeur de destination.
    destination.getPortionFormat().setAlternativeLanguageId(source.getPortionFormat().getAlternativeLanguageId())
    paragraph.getPortions().add(destination)

    presentation.save("copied_language_metadata.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Pour essayer une source sans langue alternative, omettez l’affectation de `"fr-FR"`. L’identifiant alternatif sera alors `None`, et la même instruction de copie préserve son absence sans introduire de valeur par défaut, même si la destination possédait auparavant une langue alternative assignée.

Ces identifiants sont stockés comme métadonnées de langue. Les conserver ne définit pas le dictionnaire que PowerPoint utilisera pour l’orthographe ou la grammaire.

## **Définir la langue par défaut**

Utilisez [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) pour définir la langue par défaut du texte créé lors du chargement ou de la création d’une présentation. L’exemple suivant crée une présentation avec l’anglais américain comme langue de texte par défaut, ajoute une zone de texte et affiche `en-US` pour sa première portion de texte.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("en-US")

presentation = Presentation(load_options)
try:
    slide = presentation.getSlides().get_Item(0)

    # Ajouter une forme rectangle avec du texte.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50)
    shape.getTextFrame().setText("Sample text")

    # Vérifier la langue de la première portion.
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    print(portion.getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **Définir le style de texte par défaut**

Pour appliquer un formatage de texte par défaut au niveau de la présentation, utilisez [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDefaultTextStyle).

L’exemple suivant définit une police en gras de 14 pt comme valeur par défaut pour les paragraphes de niveau supérieur dans une nouvelle présentation et l’enregistre sous « default_text_style.pptx ». Le texte peut hériter de ces valeurs par défaut sauf si un formatage plus spécifique les surcharge.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat

presentation = Presentation()
try:
    # Obtenir le format de paragraphe de niveau supérieur.
    paragraph_format = presentation.getDefaultTextStyle().getLevel(0)

    if paragraph_format is not None:
        paragraph_format.getDefaultPortionFormat().setFontHeight(14)
        paragraph_format.getDefaultPortionFormat().setFontBold(NullableBool.True_)

    presentation.save("default_text_style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Extraire le texte avec l’effet tout en majuscules**

Dans PowerPoint, appliquer l’effet de police **All Caps** fait apparaître le texte en majuscules sur la diapositive même s’il a été saisi en minuscules. Lorsque vous récupérez une telle portion de texte avec Aspose.Slides, la bibliothèque renvoie le texte exactement tel qu’il a été entré. Pour obtenir le texte affiché, vérifiez [TextCapType](https://reference.aspose.com/slides/python-java/aspose.slides/textcaptype/) et convertissez la chaîne renvoyée en majuscules lorsque la valeur est `All`.

Cet exemple nécessite « sample2.pptx » avec une zone de texte comme première forme de la première diapositive. La première portion du premier paragraphe contient « Hello, Aspose! » avec l’effet All Caps appliqué, comme le montre l’image ci‑dessous.

![L’effet tout en majuscules](all_caps_effect.png)

Le code ci‑dessus montre comment extraire le texte avec l’effet **All Caps** appliqué :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TextCapType

presentation = Presentation("sample2.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    
    auto_shape = slide.getShapes().get_Item(0)
    text_portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)

    print("Original text: " + str(text_portion.getText()))

    text_format = text_portion.getPortionFormat().getEffective()
    if text_format.getTextCapType() == TextCapType.All:
        text = str(text_portion.getText()).upper()
        print("All-Caps effect: " + text)
finally:
    presentation.dispose()
```

Sortie :

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Comment modifier le texte dans un tableau sur une diapositive ?**

Pour modifier le texte d’un tableau sur une diapositive, utilisez [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/). Parcourez les cellules et mettez à jour chaque cellule via [Cell.getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame) et le formatage des paragraphes via [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getParagraphFormat).

**Comment appliquer une couleur dégradée au texte d’une diapositive PowerPoint ?**

Pour appliquer une couleur dégradée au texte, utilisez [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFillFormat). Définissez [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) sur [FillType.Gradient](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) et configurez les arrêts du dégradé, la direction et la transparence.