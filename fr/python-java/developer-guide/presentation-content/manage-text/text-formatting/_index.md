---
title: Formatage du texte de présentation en Python via Java
linktitle: Mise en forme du texte
type: docs
weight: 50
url: /fr/python-java/text-formatting/
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
- ancre du cadre de texte
- tabulation du texte
- langue par défaut
- PowerPoint
- OpenDocument
- présentation
- Python
- Java
- Aspose.Slides
description: "Formatez et stylisez le texte dans les présentations PowerPoint et OpenDocument à l'aide d'Aspose.Slides pour Python via Java. Personnalisez les polices, les couleurs, l'alignement, et plus encore."
---
## **Vue d'ensemble**

Cet article montre comment formater le texte dans les présentations PowerPoint et OpenDocument à l'aide d'Aspose.Slides pour Python via Java. Il couvre les couleurs d'arrière-plan, la transparence, l'espacement des caractères, les propriétés de police, la rotation, l'espacement des paragraphes, le comportement d'ajustement automatique, l'ancrage du texte, les tabulations et les paramètres de langue.

Dans les exemples ci-dessous, nous utiliserons un fichier nommé « sample.pptx », qui contient une seule zone de texte sur la première diapositive avec le texte suivant :

![Texte d'exemple](sample_text.png)

Pour rechercher et mettre en surbrillance du texte littéral ou des correspondances d'expressions régulières, voir [Search and Replace Text](/slides/fr/python-java/search-and-replace-text/).

## **Définir la couleur d'arrière-plan du texte**

Utilisez [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) pour définir la couleur de surbrillance par défaut d'un paragraphe, ou utilisez [PortionFormat.getHighlightColor](https://reference.aspose.com/slides/fr/python-java/aspose.slides/portionformat/) pour des portions de texte individuelles.

L'exemple de code suivant montre comment définir la couleur d'arrière-plan pour le **paragraphe entier** :

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

    # Définir la couleur de surbrillance pour le paragraphe entier.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le résultat :

![Le paragraphe gris](gray_paragraph.png)

Exemple de code ci-dessous montre comment définir la couleur d'arrière-plan pour les **portions de texte avec une police en gras** :

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

Utilisez [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraphformat/#setAlignment) pour définir l'alignement du paragraphe dans un cadre de texte. La valeur peut être centrée, alignée à gauche, alignée à droite, justifiée, etc.

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

## **Définir la transparence du texte**

La transparence du texte est contrôlée par le composant alpha de la couleur assignée à [PortionFormat.getFillFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/portionformat/). Dans les exemples ci-dessous, `alpha = 50` est une valeur de canal alpha ARGB sur l'échelle 0‑255, et non un pourcentage de transparence.

L'exemple de code ci-dessous montre comment appliquer la transparence au **paragraphe entier** :

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

    # Définir la couleur de remplissage du texte à une couleur transparente.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le résultat :

![Le paragraphe transparent](transparent_paragraph.png)

L'exemple de code suivant montre comment appliquer la transparence aux **portions de texte avec une police en gras** :

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

Utilisez [PortionFormat.setSpacing](https://reference.aspose.com/slides/fr/python-java/aspose.slides/portionformat/) pour élargir ou condenser l'espacement entre les caractères dans une zone de texte.

Le code Python suivant montre comment élargir l'espacement des caractères dans le **paragraphe entier** :

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

    # Remarque: Utilisez des valeurs négatives pour compresser l'espacement des caractères.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3) # Elargir l'espacement des caractères.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le résultat :

![L'espacement des caractères dans le paragraphe](character_spacing_in_paragraph.png)

L'exemple de code ci-dessous montre comment élargir l'espacement des caractères dans les **portions de texte avec une police en gras** :

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

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # Remarque: Utilisez des valeurs négatives pour compresser l'espacement des caractères.
            portion.getPortionFormat().setSpacing(3) # Elargir l'espacement des caractères.

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le résultat :

![L'espacement des caractères dans les portions de texte](character_spacing_in_text_portions.png)

### **Désactiver le crénage pour des polices spécifiques**

Dans certains cas, le texte rendu par Aspose.Slides peut paraître légèrement plus serré que le même texte affiché dans PowerPoint. Cela peut se produire parce que PowerPoint peut ignorer les données de crénage pour certaines polices, même lorsque la police contient des informations de crénage valides et que le crénage est activé dans les paramètres de PowerPoint.

Pour que le rendu soit plus proche de PowerPoint dans ces cas, vous pouvez désactiver le crénage pour les portions de texte qui utilisent la police concernée. Définissez [PortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/fr/python-java/aspose.slides/portionformat/) à une valeur nettement supérieure à la taille réelle de la police :

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
            portion_format = portion.getPortionFormat()
            fonts = (portion_format.getLatinFont(), portion_format.getEastAsianFont(), portion_format.getComplexScriptFont())
            if any(font is not None and font.getFontName() == target_font for font in fonts):
                portion_format.setKerningMinimalSize(100)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ce paramètre empêche l'application du crénage aux portions de texte correspondantes et peut aider à aligner le rendu d'Aspose.Slides avec la sortie visuelle de PowerPoint pour les polices affectées par ce comportement spécifique à PowerPoint.

## **Gestion des propriétés de police du texte**

Les propriétés de police peuvent être définies au niveau du paragraphe via [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) ou sur des portions individuelles via [PortionFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/portionformat/).

Le code suivant définit la police et le style du texte pour le paragraphe entier : il applique la taille de police, le gras, l'italique, le soulignement pointillé, ainsi que la police Times New Roman à toutes les portions du paragraphe.

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

Exemple de code ci-dessous applique des propriétés similaires aux **portions de texte avec une police en gras** :

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

Utilisez [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframeformat/#setTextVerticalType) pour définir une orientation de texte prédéfinie à l'intérieur d'une forme.

L'exemple de code suivant définit l'orientation du texte dans la forme à `Vertical270`, ce qui fait pivoter le texte de **90 degrés dans le sens inverse des aiguilles d'une montre** :

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

Utilisez [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframeformat/#setRotationAngle) pour définir un angle de rotation personnalisé pour un [TextFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframe/).

L'exemple de code ci-dessous fait pivoter le cadre de texte de 3 degrés dans le sens des aiguilles d'une montre à l'intérieur de la forme :

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

![La rotation personnalisée du texte](custom_text_rotation.png)

## **Définir l'interligne des paragraphes**

Aspose.Slides fournit [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraphformat/#setSpaceBefore) et [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraphformat/#setSpaceWithin) pour contrôler l'espacement des paragraphes. Ces propriétés s'utilisent comme suit :

* Utilisez une valeur positive pour spécifier l'interligne en pourcentage de la hauteur de ligne.
* Utilisez une valeur négative pour spécifier l'interligne en points.

L'exemple de code suivant montre comment spécifier l'interligne à l'intérieur du paragraphe :

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

![L'interligne à l'intérieur du paragraphe](line_spacing.png)

## **Définir le type d'ajustement automatique pour les cadres de texte**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframeformat/#setAutofitType) détermine comment le texte se comporte lorsqu'il dépasse les limites de son conteneur. Utilisez-le pour contrôler si le texte se rétrécit, déborde ou redimensionne automatiquement la forme.

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

## **Définir l'ancre des cadres de texte**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframeformat/#setAnchoringType) définit comment le texte est positionné verticalement à l'intérieur d'une forme, par exemple en haut, au milieu ou en bas.

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

Utilisez [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraphformat/#setDefaultTabSize) et [ParagraphFormat.getTabs](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraphformat/#getTabs) pour configurer les tabulations dans un paragraphe.

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

Aspose.Slides propose [PortionFormat.setLanguageId](https://reference.aspose.com/slides/fr/python-java/aspose.slides/portionformat/), qui permet de définir la langue de vérification pour une portion de texte. La langue de vérification détermine la langue utilisée pour les vérifications orthographiques et grammaticales dans PowerPoint.

L'exemple de code suivant montre comment définir la langue de vérification pour une portion de texte :

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

## **Définir la langue par défaut**

Utilisez [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) pour définir la langue par défaut du texte créé lors du chargement ou de la création d'une présentation.

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

Pour appliquer un formatage de texte par défaut au niveau de la présentation, utilisez [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getDefaultTextStyle).

L'exemple de code suivant montre comment définir une police par défaut en gras avec une taille de 14 pt pour tout le texte sur toutes les diapositives d'une nouvelle présentation.

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

## **Extraire le texte avec l'effet tout en majuscules**

Dans PowerPoint, appliquer l'effet de police **All Caps** (tout en majuscules) fait apparaître le texte en majuscules sur la diapositive même s'il a été saisi initialement en minuscules. Lorsque vous récupérez une telle portion de texte avec Aspose.Slides, la bibliothèque renvoie le texte exactement tel qu'il a été saisi. Pour faire correspondre le texte affiché, vérifiez [TextCapType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textcaptype/) et convertissez la chaîne retournée en majuscules lorsque la valeur est `All`.

Supposons que nous ayons la zone de texte suivante sur la première diapositive du fichier sample2.pptx.

![L'effet tout en majuscules](all_caps_effect.png)

L'exemple de code ci-dessous montre comment extraire le texte avec l'effet **All Caps** appliqué :

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

Pour modifier le texte dans un tableau sur une diapositive, utilisez [Table](https://reference.aspose.com/slides/fr/python-java/aspose.slides/table/). Parcourez les cellules et mettez à jour chaque cellule via [Cell.getTextFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/cell/#getTextFrame) et le formatage des paragraphes via [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraph/#getParagraphFormat).

**Comment appliquer une couleur de dégradé au texte sur une diapositive PowerPoint ?**

Pour appliquer une couleur de dégradé au texte, utilisez [PortionFormat.getFillFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/portionformat/). Définissez [FillFormat.setFillType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fillformat/#setFillType) sur [FillType.Gradient](https://reference.aspose.com/slides/fr/python-java/aspose.slides/filltype/#Gradient) et configurez les arrêts du dégradé, la direction et la transparence.