---
title: Formater le texte d'une présentation en Python via Java
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
- espacement des lignes
- propriété d'ajustement automatique
- ancrage du cadre de texte
- tabulation du texte
- langue par défaut
- PowerPoint
- OpenDocument
- présentation
- Python
- Java
- Aspose.Slides
description: "Formate et stylise le texte dans les présentations PowerPoint et OpenDocument en utilisant Aspose.Slides pour Python via Java. Personnalisez les polices, les couleurs, l'alignement et plus encore."
---
## **Vue d'ensemble**

Cet article montre comment formater du texte dans des présentations PowerPoint et OpenDocument en utilisant Aspose.Slides pour Python via Java. Il couvre les couleurs d'arrière-plan, la transparence, l'espacement des caractères, les propriétés de police, la rotation, l'espacement des paragraphes, le comportement d'ajustement automatique, l'ancrage du texte, les tabulations et les paramètres de langue.

À moins d'indication contraire, les exemples utilisent [sample.pptx](sample.pptx). La première forme de la première diapositive est une zone de texte, et son premier paragraphe contient le texte affiché ci‑dessous. Les indices des diapositives et des formes sont basés sur zéro. Les exemples qui sélectionnent des portions en gras utilisent le formatage effectif, y compris le formatage gras hérité :

![Texte d'exemple](sample_text.png)

Pour trouver et mettre en surbrillance du texte littéral ou des correspondances d'expression régulière, voir [Rechercher et remplacer du texte](/slides/fr/python-java/search-and-replace-text/).

## **Définir la couleur d'arrière-plan du texte**

Utilisez [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) pour définir la couleur de surlignage par défaut d'un paragraphe, ou utilisez [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getHighlightColor) pour des portions de texte individuelles.

L'exemple suivant définit un surlignage gris clair comme valeur par défaut pour le premier paragraphe. Les couleurs de surlignage explicites sur des portions individuelles prennent le pas sur cette valeur par défaut :

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

    # Définit la couleur de surbrillance pour l'ensemble du paragraphe.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le résultat :

![Le paragraphe gris](gray_paragraph.png)

L'exemple de code ci‑dessous montre comment définir la couleur d'arrière-plan pour **les portions de texte avec une police en gras** :

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
            # Définit la couleur de surbrillance pour la portion de texte.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le résultat :

![Les portions de texte gris](gray_text_portions.png)

## **Aligner les paragraphes de texte**

Utilisez [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) pour définir l'alignement des paragraphes dans un cadre de texte. La valeur peut être centrée, alignée à gauche, alignée à droite, justifiée, etc.

L'exemple de code suivant montre comment aligner le paragraphe au **centre** :

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

## **Aligner les polices au sein d'une ligne**

Utilisez [ParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setFontAlignment) pour aligner verticalement les portions de texte de tailles de police différentes au sein d'une ligne. Ce paramètre s'applique à l'ensemble du paragraphe et contrôle l'alignement dans chacune de ses lignes.

L'exemple autonome suivant crée quatre zones de texte étiquetées sur une même diapositive. Chaque paragraphe contient le même texte en tailles 18, 36 et 54 points, avec un alignement de police différent. Il utilise Arial, désactive l'ajustement automatique et le retour à la ligne, et maintient les cadres de texte suffisamment grands pour une seule ligne.

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

![Comparaison des alignements de police Baseline, Top, Center et Bottom avec des tailles de police mixtes](font_alignment.png)

L'alignement des polices utilise les métriques typographiques, de sorte que les bords visibles des caractères individuels ne s'alignent pas nécessairement exactement. L'exemple comprend à la fois une lettre majuscule et une descendeuse pour illustrer la différence entre l'alignement sur la ligne de base et le bas. La disponibilité et le remplacement des polices, les caractères utilisés et la différence de tailles de police influencent le résultat. Les dimensions du cadre, les marges, l'espacement des lignes, le retour à la ligne et l'ajustement automatique affectent également la mise en page ; utilisez les mêmes polices et paramètres de mise en page lors de la comparaison des modes.

Ce paramètre diffère de [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment), qui contrôle l'alignement horizontal du paragraphe, et de [TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAnchoringType), qui positionne le bloc de texte verticalement dans sa forme. La mise en forme en exposant et indice via [BasePortionFormat.setEscapement](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setEscapement) décale les portions individuelles par rapport à la ligne de base plutôt que de définir l'alignement de police pour les lignes du paragraphe.

## **Définir la transparence du texte**

La transparence du texte est contrôlée via le composant alpha de la couleur attribuée à [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFillFormat). Dans les exemples ci‑dessous, `alpha = 50` est une valeur du canal alpha ARGB sur l'échelle 0–255, et non un pourcentage de transparence.

L'exemple de code ci‑dessous montre comment appliquer la transparence à **l'ensemble du paragraphe** :

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

    # Définir la couleur de remplissage du texte en couleur transparente.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le résultat :

![Le paragraphe transparent](transparent_paragraph.png)

L'exemple de code suivant montre comment appliquer la transparence à **les portions de texte avec une police en gras** :

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

## **Définir l'espacement des caractères pour le texte**

Utilisez [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setSpacing) pour augmenter ou réduire l'espacement entre les caractères dans une zone de texte. Les exemples ajoutent 3 points d'espacement ; les valeurs négatives condensent le texte.

Le code Python suivant montre comment étendre l'espacement des caractères dans **l'ensemble du paragraphe** :

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

    # Note: Utilisez des valeurs négatives pour compresser l'espacement des caractères.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3) # Étendre l'espacement des caractères.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le résultat :

![L'espacement des caractères dans le paragraphe](character_spacing_in_paragraph.png)

L'exemple de code ci‑dessous montre comment étendre l'espacement des caractères dans **les portions de texte avec une police en gras** :

```python
import jpime
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # Remarque : Utilisez des valeurs négatives pour compresser l'espacement des caractères.
            portion.getPortionFormat().setSpacing(3) # Étendre l'espacement des caractères.

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le résultat :

![L'espacement des caractères dans les portions de texte](character_spacing_in_text_portions.png)

### **Désactiver le crénage pour des polices spécifiques**

Dans certains cas, le texte rendu par Aspose.Slides peut sembler légèrement plus serré que le même texte affiché dans PowerPoint. Cela peut se produire parce que PowerPoint peut ignorer les données de crénage pour certaines polices, même si la police contient des informations de crénage valides et que le crénage est activé dans les paramètres de PowerPoint.

Pour rendre la sortie rendue plus proche de PowerPoint dans ces cas, vous pouvez désactiver le crénage pour les portions de texte utilisant la police concernée. Définissez [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setKerningMinimalSize) à une valeur supérieure à la taille réelle de la police. Cet exemple nécessite « presentation.pptx » avec une zone de texte comme première forme de la première diapositive. Il vérifie les noms de police effectifs, y compris les polices héritées, et définit un seuil de 100 points pour les portions utilisant Roboto. Cela désactive le crénage pour les portions correspondantes dont la taille de police est inférieure à 100 points :

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

Pour le texte correspondant en dessous du seuil, ce paramètre empêche le crénage et peut aider à aligner le rendu d'Aspose.Slides avec la sortie visuelle de PowerPoint pour les polices affectées par ce comportement spécifique à PowerPoint.

## **Gérer les propriétés de police du texte**

Les propriétés de police peuvent être définies au niveau du paragraphe via [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) ou sur des portions individuelles via [PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/).

L'exemple suivant définit la police par défaut du premier paragraphe à Times New Roman 12 points avec un format gras, italique et souligné pointillé. Le formatage explicite sur les portions individuelles prime sur ces valeurs par défaut.

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

    # Définir les propriétés de police pour le paragraphe.
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

L'exemple suivant applique Times New Roman 13 points, du format italique et un soulignement pointillé aux portions dont le formatage effectif est en gras :

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

## **Définir la rotation du texte**

Utilisez [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType) pour définir une orientation de texte prédéfinie à l'intérieur d'une forme.

L'exemple de code suivant définit l'orientation du texte dans la forme à [TextVerticalType.Vertical270](https://reference.aspose.com/slides/python-java/aspose.slides/textverticaltype/), qui fait pivoter le texte de **90 degrés dans le sens inverse des aiguilles d'une montre** :

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

L'exemple de code ci‑dessous fait pivoter le cadre de texte de 3 degrés dans le sens horaire à l'intérieur de la forme :

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

## **Définir l'espacement des lignes des paragraphes**

Aspose.Slides fournit [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceBefore) et [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceWithin) pour contrôler l'espacement des paragraphes. Ces propriétés sont utilisées comme suit :

* Utilisez une valeur positive pour spécifier l'espacement des lignes en pourcentage de la hauteur de ligne.
* Utilisez une valeur négative pour spécifier l'espacement des lignes en points.

L'exemple suivant définit l'espacement à l'intérieur du premier paragraphe à 200 % de la hauteur de ligne (double interligne) :

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

![L'espacement des lignes à l'intérieur du paragraphe](line_spacing.png)

## **Contrôler le retour à la ligne**

Les règles de retour à la ligne des paragraphes sont utiles dans des blocs de texte étroits et des présentations mêlant du texte latin et asiatique de l'Est. Les méthodes suivantes appartiennent à [ParagraphFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/), elles s'appliquent donc à l'ensemble du paragraphe :

- [setLatinLineBreak](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setLatinLineBreak) contrôle les règles de retour à la ligne du texte latin. Dans un texte mixte, le modifier peut également changer l’endroit où le texte et la ponctuation asiatiques de l’Est adjacents se replient.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) contrôle les règles de retour à la ligne du texte asiatique de l’Est, y compris les restrictions sur les caractères en début et fin de ligne.

Ces règles ne remplacent pas [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setWrapText), qui active le retour à la ligne automatique dans un cadre de texte. Elles influencent la mise en page lorsque le retour à la ligne se produit ; elles n'insèrent pas de caractères de saut de ligne. Un saut de ligne explicite force une nouvelle ligne dans le paragraphe indépendamment de la largeur disponible.

L'exemple autonome suivant crée un bloc de texte étroit contenant du texte chinois et latin. Il définit explicitement les deux options de retour à la ligne et enregistre « line_breaking.pptx ». Pour expérimenter chaque règle, modifiez la valeur correspondante tout en maintenant les autres paramètres fixes. L'exemple utilise Arial 24 points et SimSun avec une largeur de cadre de 160 points et des marges horizontales du cadre de texte à zéro. [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) est appelé avec [TextAutofitType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/textautofittype/) afin que la taille du texte et les dimensions du cadre restent fixes.

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

## **Contrôler la ponctuation en suspension**

[ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setHangingPunctuation) permet à la ponctuation admissible de dépasser le bord droit de la ligne de texte au lieu d'occuper la ligne suivante. Elle s'applique à l'ensemble du paragraphe et diffère d'un retrait suspendu.

L'exemple autonome suivant active la ponctuation en suspension dans un cadre de texte de 100 points de large et enregistre « hanging_punctuation.pptx ». Avec Arial 24 points et des marges horizontales du cadre de texte à zéro, le point final reste après « sentence » et dépasse le bord droit du texte. Réglez la propriété sur [NullableBool.False_](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/) pour comparer : avec ces paramètres, le point occupe une ligne séparée. Le retour à la ligne est activé et l'ajustement automatique désactivé pour garder la largeur disponible fixe.

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

Toute ponctuation ne peut pas être suspendue. Les [conditions de police et de mise en page décrites ci‑dessus](#control-line-breaking) s'appliquent également à cette comparaison : modifier la police, la largeur disponible, les marges ou les paramètres d'ajustement automatique peut supprimer la différence visible.

## **Définir le type d'ajustement automatique pour les cadres de texte**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) détermine le comportement du texte lorsqu'il dépasse les limites de son conteneur. Utilisez-le pour contrôler si le texte se rétrécit, dépasse ou redimensionne automatiquement la forme. L'exemple suivant configure la forme pour redimensionner afin d'ajuster son texte et enregistre le résultat dans « autofit_type.pptx ».

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

Pour compter les lignes après le retour à la ligne automatique et voir comment la largeur du texte ou de la forme modifie le résultat, consultez [Count Rendered Lines](/slides/fr/python-java/manage-paragraph/). Le nombre de lignes seul n'indique pas si le texte dépasse son conteneur.

## **Définir l'ancrage des cadres de texte**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAnchoringType) définit la façon dont le texte est positionné verticalement à l'intérieur d'une forme, par exemple en haut, au milieu ou en bas. L'exemple suivant ancre le texte au bas de la première forme et enregistre le résultat dans « text_anchor.pptx ».

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

Utilisez [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDefaultTabSize) et [ParagraphFormat.getTabs](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getTabs) pour configurer les taquets de tabulation dans un paragraphe. L'exemple suivant définit l'intervalle de tabulation par défaut à 100 points et ajoute un taquet de tabulation aligné à gauche à 30 points. Ces paramètres affectent le texte contenant des caractères de tabulation.

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

Aspose.Slides propose [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setLanguageId), qui permet de définir la langue de vérification pour une portion de texte. La langue de vérification détermine la langue utilisée pour les vérifications d'orthographe et de grammaire dans PowerPoint.

L'exemple suivant nécessite « presentation.pptx » avec une zone de texte comme première forme de la première diapositive et au moins un paragraphe. Il remplace le contenu du premier paragraphe par "1。", définit SimSun comme police et attribue la langue de vérification chinois simplifié (`zh-CN`). Il enregistre le résultat dans « proofing_language.pptx » :

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

    # Définir l'ID d'une langue de vérification.
    text_portion.getPortionFormat().setLanguageId("zh-CN")

    text_portion.setText("1。")
    paragraph.getPortions().add(text_portion)

    presentation.save("proofing_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Définir la langue par défaut**

Utilisez [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) pour définir la langue par défaut du texte créé lors du chargement ou de la création d'une présentation. L'exemple suivant crée une présentation avec l'anglais américain comme langue de texte par défaut, ajoute une zone de texte et affiche `en-US` pour sa première portion de texte.

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

    # Ajouter une forme rectangulaire avec du texte.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50)
    shape.getTextFrame().setText("Sample text")

    # Vérifier la langue de la première portion.
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    print(portion.getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **Définir le style de texte par défaut**

Pour appliquer le formatage de texte par défaut au niveau de la présentation, utilisez [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDefaultTextStyle).

L'exemple suivant définit une police en gras de 14 points comme valeur par défaut pour les paragraphes de niveau supérieur dans une nouvelle présentation et l'enregistre dans « default_text_style.pptx ». Le texte peut hériter de ces valeurs par défaut sauf si un formatage plus spécifique les surcharge.

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

## **Extraire le texte avec l'effet Tout en majuscules**

Dans PowerPoint, appliquer l’effet de police **All Caps** fait apparaître le texte en majuscules sur la diapositive même s'il a été saisi en minuscules. Lorsque vous récupérez une telle portion de texte avec Aspose.Slides, la bibliothèque renvoie le texte exactement tel qu'il a été entré. Pour faire correspondre le texte affiché, vérifiez [TextCapType](https://reference.aspose.com/slides/python-java/aspose.slides/textcaptype/) et convertissez la chaîne renvoyée en majuscules lorsque la valeur est `All`.

Cet exemple nécessite « sample2.pptx » avec une zone de texte comme première forme de la première diapositive. La première portion du premier paragraphe contient "Hello, Aspose!" avec l’effet Tout en majuscules appliqué, comme illustré ci‑dessous.

![L'effet Tout en majuscules](all_caps_effect.png)

L'exemple de code ci‑dessous montre comment extraire le texte avec l’effet **All Caps** appliqué :

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

Pour modifier le texte dans un tableau sur une diapositive, utilisez [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/). Parcourez les cellules et mettez à jour chaque cellule via [Cell.getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame) et le formatage des paragraphes via [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getParagraphFormat).

**Comment appliquer une couleur dégradée au texte d'une diapositive PowerPoint ?**

Pour appliquer une couleur dégradée au texte, utilisez [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFillFormat). Définissez [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) à [FillType.Gradient](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) et configurez les arrêts du dégradé, la direction et la transparence.