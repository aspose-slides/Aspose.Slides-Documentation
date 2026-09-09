---
title: Gérer les paragraphes de texte PowerPoint en Python via Java
linktitle: Gérer le paragraphe
type: docs
weight: 40
url: /fr/python-java/manage-paragraph/
aliases:
  - /python-java/paragraph/
  - /python-java/portion/
keywords:
- ajouter du texte
- ajouter un paragraphe
- gérer le texte
- gérer le paragraphe
- gérer les puces
- retrait de paragraphe
- retrait suspendu
- puce de paragraphe
- liste numérotée
- liste à puces
- propriétés du paragraphe
- importer HTML
- texte en HTML
- paragraphe en HTML
- paragraphe en image
- texte en image
- exporter le paragraphe
- PowerPoint
- présentation
- Python
- Java
- Aspose.Slides
description: "Apprenez à créer et formater des paragraphes, portions, puces, listes numérotées, retraits, contenu HTML et images de paragraphes avec Aspose.Slides pour Python via Java."
---
## **Vue d'ensemble**

Aspose.Slides for Python via Java représente le texte comme une hiérarchie de cadres de texte, de paragraphes et de portions :

* [TextFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframe/) représente le conteneur de texte dans une forme et fournit l’accès à sa collection de paragraphes.
* [Paragraph](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraph/) représente un paragraphe dans un cadre de texte et fournit l’accès à ses portions ainsi qu’au formatage au niveau du paragraphe.
* [Portion](https://reference.aspose.com/slides/fr/python-java/aspose.slides/portion/) représente un fragment de texte au sein d’un paragraphe. Chaque portion peut avoir son propre texte et un formatage au niveau des caractères.

Un paragraphe peut donc contenir du texte avec différentes polices, couleurs, tailles et autres formatages en utilisant plusieurs portions.

## **Créer et formater des paragraphes**

### **Créer des paragraphes avec plusieurs portions**

Les étapes suivantes créent un cadre de texte avec trois paragraphes, chacun contenant trois portions :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
2. Accéder à la diapositive concernée via son indice.
3. Ajouter une forme [AutoShape] rectangulaire à la diapositive.
4. Accéder au [TextFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframe/) de la forme.
5. Utiliser le paragraphe par défaut et ajouter deux autres objets [Paragraph] au cadre de texte.
6. Ajouter suffisamment d’objets [Portion] pour que chaque paragraphe contienne trois portions. Le paragraphe par défaut contient déjà une portion vide.
7. Définir le texte de chaque portion.
8. Appliquer le formatage au niveau des caractères via [Portion.getPortionFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/portion/#getPortionFormat).
9. Enregistrer la présentation modifiée.

Cet exemple Python implémente les étapes :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, NullableBool, Paragraph, Portion, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150)
    text_frame = shape.getTextFrame()
    first_paragraph = text_frame.getParagraphs().get_Item(0)
    first_paragraph.getPortions().add(Portion())
    first_paragraph.getPortions().add(Portion())
    second_paragraph = Paragraph()
    second_paragraph.getPortions().add(Portion())
    second_paragraph.getPortions().add(Portion())
    second_paragraph.getPortions().add(Portion())
    text_frame.getParagraphs().add(second_paragraph)
    third_paragraph = Paragraph()
    third_paragraph.getPortions().add(Portion())
    third_paragraph.getPortions().add(Portion())
    third_paragraph.getPortions().add(Portion())
    text_frame.getParagraphs().add(third_paragraph)
    paragraph_count = text_frame.getParagraphs().getCount()
    for paragraph_index in range(paragraph_count):
        paragraph = text_frame.getParagraphs().get_Item(paragraph_index)
        portion_count = paragraph.getPortions().getCount()
        for portion_index in range(portion_count):
            portion = paragraph.getPortions().get_Item(portion_index)
            portion.setText(f"Portion {paragraph_index + 1}.{portion_index + 1}")
            if portion_index == 0:
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)
                portion.getPortionFormat().setFontBold(NullableBool.True_)
                portion.getPortionFormat().setFontHeight(15)
            elif portion_index == 1:
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
                portion.getPortionFormat().setFontItalic(NullableBool.True_)
                portion.getPortionFormat().setFontHeight(18)
    presentation.save("paragraphs_with_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Créer des listes à puces et numérotées**

### **Créer une liste à puces ou numérotée**

Les puces et la numérotation facilitent la lecture d’éléments liés. Dans Aspose.Slides, les paramètres de liste sont définis via [BulletFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/bulletformat/).

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
2. Accéder à la diapositive concernée via son indice.
3. Ajouter une [AutoShape] à la diapositive sélectionnée.
4. Accéder au [TextFrame] de la forme.
5. Supprimer le paragraphe par défaut du cadre de texte.
6. Créer un [Paragraph] pour une puce symbole.
7. Définir [BulletFormat.setType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/bulletformat/#setType) sur [BulletType.Symbol](https://reference.aspose.com/slides/fr/python-java/aspose.slides/bullettype/#Symbol) et spécifier le caractère de la puce.
8. Définir le texte du paragraphe, le retrait, la couleur de la puce et la hauteur de la puce.
9. Ajouter le paragraphe au cadre de texte.
10. Créer un second paragraphe et définir [BulletFormat.setType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/bulletformat/#setType) sur [BulletType.Numbered](https://reference.aspose.com/slides/fr/python-java/aspose.slides/bullettype/#Numbered).
11. Configurer le style de puce numérotée et ajouter le paragraphe au cadre de texte.
12. Enregistrer la présentation.

Cet exemple Python crée une puce symbole et une puce numérotée :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, ColorType, NullableBool, NumberedBulletStyle, Paragraph, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    symbol_paragraph = Paragraph()
    symbol_paragraph.setText("Welcome to Aspose.Slides")
    symbol_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    symbol_paragraph.getParagraphFormat().getBullet().setChar("•")
    symbol_paragraph.getParagraphFormat().setIndent(25)
    symbol_paragraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB)
    symbol_paragraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK)
    symbol_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    symbol_paragraph.getParagraphFormat().getBullet().setHeight(100)
    text_frame.getParagraphs().add(symbol_paragraph)
    numbered_paragraph = Paragraph()
    numbered_paragraph.setText("This is a numbered item")
    numbered_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    numbered_paragraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain)
    numbered_paragraph.getParagraphFormat().setIndent(25)
    numbered_paragraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB)
    numbered_paragraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK)
    numbered_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    numbered_paragraph.getParagraphFormat().getBullet().setHeight(100)
    text_frame.getParagraphs().add(numbered_paragraph)
    presentation.save("bulleted_and_numbered_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Utiliser des puces image**

Les puces image permettent d’utiliser une image personnalisée à la place d’un symbole ou d’un numéro.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
2. Accéder à la diapositive concernée via son indice.
3. Ajouter une [AutoShape] et accéder à son [TextFrame].
4. Supprimer le paragraphe par défaut du cadre de texte.
5. Charger l’image de la puce et l’ajouter à la collection d’images de la présentation sous forme de [PPImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/ppimage/).
6. Créer un [Paragraph] et définir son texte.
7. Définir [BulletFormat.setType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/bulletformat/#setType) sur [BulletType.Picture](https://reference.aspose.com/slides/fr/python-java/aspose.slides/bullettype/#Picture).
8. Assigner l’image via [BulletFormat.getPicture](https://reference.aspose.com/slides/fr/python-java/aspose.slides/bulletformat/#getPicture) et définir la hauteur de la puce.
9. Ajouter le paragraphe au cadre de texte.
10. Enregistrer la présentation modifiée.

Cet exemple Python crée une puce image :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Images, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    bullet_image = Images.fromFile("bullets.png")
    try:
        presentation_image = presentation.getImages().addImage(bullet_image)
    finally:
        bullet_image.dispose()
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    paragraph = Paragraph()
    paragraph.setText("Welcome to Aspose.Slides")
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture)
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(presentation_image)
    paragraph.getParagraphFormat().getBullet().setHeight(100)
    text_frame.getParagraphs().add(paragraph)
    presentation.save("picture_bullet.pptx", SaveFormat.Pptx)
    presentation.save("picture_bullet.ppt", SaveFormat.Ppt)
finally:
    presentation.dispose()
```

### **Créer une liste à plusieurs niveaux**

Définir [ParagraphFormat.setDepth](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraphformat/#setDepth) pour placer les paragraphes à différents niveaux d’une liste. Le niveau supérieur a une profondeur de `0`.

1. Créer une [Presentation] et accéder à une diapositive.
2. Ajouter une [AutoShape] et nettoyer le paragraphe par défaut de son cadre de texte.
3. Créer quatre paragraphes et configurer leurs symboles de puce.
4. Définir leurs valeurs [ParagraphFormat.setDepth](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraphformat/#setDepth) à `0`, `1`, `2` et `3`.
5. Ajouter les paragraphes au cadre de texte et enregistrer la présentation.

Cet exemple Python crée une liste à puces à quatre niveaux :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, FillType, Paragraph, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_paragraph.setText("Content")
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    first_paragraph.getParagraphFormat().getBullet().setChar("•")
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    first_paragraph.getParagraphFormat().setDepth(0)
    second_paragraph = Paragraph()
    second_paragraph.setText("Second level")
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    second_paragraph.getParagraphFormat().getBullet().setChar('-')
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    second_paragraph.getParagraphFormat().setDepth(1)
    third_paragraph = Paragraph()
    third_paragraph.setText("Third level")
    third_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    third_paragraph.getParagraphFormat().getBullet().setChar("•")
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    third_paragraph.getParagraphFormat().setDepth(2)
    fourth_paragraph = Paragraph()
    fourth_paragraph.setText("Fourth level")
    fourth_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    fourth_paragraph.getParagraphFormat().getBullet().setChar('-')
    fourth_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    fourth_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    fourth_paragraph.getParagraphFormat().setDepth(3)
    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)
    text_frame.getParagraphs().add(third_paragraph)
    text_frame.getParagraphs().add(fourth_paragraph)
    presentation.save("multilevel_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Commencer les puces numérotées à des valeurs personnalisées**

Utiliser [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/fr/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) pour définir le numéro initial affiché pour un paragraphe numéroté.

1. Créer une [Presentation] et ajouter une [AutoShape] à une diapositive.
2. Nettoyer le paragraphe par défaut du cadre de texte de la forme.
3. Créer trois paragraphes numérotés.
4. Définir [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/fr/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) à `2`, `3` et `7` pour les paragraphes respectifs.
5. Ajouter les paragraphes au cadre de texte et enregistrer la présentation.

Cet exemple Python attribue un numéro de départ personnalisé à chaque paragraphe :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_paragraph.setText("Start at 2")
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    first_paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(2)
    text_frame.getParagraphs().add(first_paragraph)
    second_paragraph = Paragraph()
    second_paragraph.setText("Start at 3")
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    second_paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(3)
    text_frame.getParagraphs().add(second_paragraph)
    third_paragraph = Paragraph()
    third_paragraph.setText("Start at 7")
    third_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    third_paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(7)
    text_frame.getParagraphs().add(third_paragraph)
    presentation.save("custom_numbered_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Contrôler la mise en page du paragraphe et les propriétés de fin**

### **Définir un retrait de première ligne**

Utiliser [ParagraphFormat.setIndent](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraphformat/#setIndent) pour contrôler le retrait de la première ligne d’un paragraphe. Cette méthode ne déplace que la première ligne par rapport à la marge gauche du paragraphe. Une valeur positive décale la première ligne vers la droite, tandis que les lignes restantes restent alignées sur le corps du paragraphe.

Utilisez [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraphformat/#setMarginLeft) lorsque vous devez déplacer le paragraphe entier. Utilisez [ParagraphFormat.setIndent](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraphformat/#setIndent) lorsque vous devez ne déplacer que la première ligne.

L’exemple ci‑dessous crée plusieurs paragraphes et applique différentes valeurs [ParagraphFormat.setIndent] pour montrer comment le retrait de première ligne affecte la mise en page du paragraphe.

1. Créer une instance de la classe [Presentation].
2. Accéder à la diapositive cible.
3. Ajouter une forme [AutoShape] rectangulaire à la diapositive.
4. Accéder au [TextFrame] de la forme et supprimer le paragraphe par défaut.
5. Créer plusieurs paragraphes et définir différentes valeurs [ParagraphFormat.setIndent] pour chacun.
6. Ajouter les paragraphes au cadre de texte.
7. Enregistrer la présentation modifiée.

Ce code montre comment définir un retrait de paragraphe :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Presentation, SaveFormat, ShapeType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape)
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_paragraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.")
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    first_paragraph.getParagraphFormat().setMarginLeft(20.0)
    first_paragraph.getParagraphFormat().setIndent(0.0)
    second_paragraph = Paragraph()
    second_paragraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.")
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    second_paragraph.getParagraphFormat().setMarginLeft(20.0)
    second_paragraph.getParagraphFormat().setIndent(20.0)
    third_paragraph = Paragraph()
    third_paragraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.")
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    third_paragraph.getParagraphFormat().setMarginLeft(20.0)
    third_paragraph.getParagraphFormat().setIndent(40.0)
    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)
    text_frame.getParagraphs().add(third_paragraph)
    presentation.save("paragraph_indent.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le résultat :

![Le retrait de première ligne des paragraphes](first_line_indent.png)

### **Définir un retrait suspendu**

Un retrait suspendu est une mise en page où la première ligne commence à gauche des lignes suivantes. Dans Aspose.Slides, vous créez cet effet avec [ParagraphFormat.setIndent]. Passez une valeur négative pour déplacer la première ligne vers la gauche par rapport au corps du paragraphe.

En pratique, [ParagraphFormat.setMarginLeft] définit la position gauche du corps du paragraphe, et [ParagraphFormat.setIndent] définit la position de la première ligne par rapport à cette marge. Pour créer un retrait suspendu, passez une valeur positive à [ParagraphFormat.setMarginLeft] et une valeur négative à [ParagraphFormat.setIndent].

Ce formatage est utile pour les bibliographies, références, entrées de glossaire et autres paragraphes où les lignes enroulées doivent s’aligner sous le corps du paragraphe plutôt que sous le premier caractère de la première ligne.

1. Créer une instance de la classe [Presentation].
2. Accéder à la diapositive cible.
3. Ajouter une forme [AutoShape] rectangulaire à la diapositive.
4. Accéder au [TextFrame] de la forme et supprimer le paragraphe par défaut.
5. Créer des paragraphes et passer une valeur positive à [ParagraphFormat.setMarginLeft] pour chaque paragraphe.
6. Passer une valeur négative à [ParagraphFormat.setIndent] pour créer l’effet de retrait suspendu.
7. Ajouter les paragraphes au cadre de texte.
8. Enregistrer la présentation modifiée.

Ce code montre comment définir un retrait suspendu pour un paragraphe :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Presentation, SaveFormat, ShapeType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape)
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_paragraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.")
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    first_paragraph.getParagraphFormat().setMarginLeft(40.0)
    first_paragraph.getParagraphFormat().setIndent(-20.0)
    second_paragraph = Paragraph()
    second_paragraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.")
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    second_paragraph.getParagraphFormat().setMarginLeft(60.0)
    second_paragraph.getParagraphFormat().setIndent(-30.0)
    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)
    presentation.save("hanging_indent.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le résultat :

![Le retrait suspendu des paragraphes](hanging_indent.png)

### **Définir les propriétés de fin de paragraphe**

[Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) contrôle le formatage du marqueur de fin de paragraphe. L’exemple suivant assigne une taille de police et une police latine au marqueur de fin du second paragraphe :

1. Charger une [Presentation] et accéder à une diapositive.
2. Ajouter une [AutoShape] et nettoyer son paragraphe par défaut.
3. Créer deux paragraphes et leur ajouter des portions de texte.
4. Créer un [PortionFormat] pour le marqueur de fin du second paragraphe.
5. Définir [BasePortionFormat.setFontHeight] et [BasePortionFormat.setLatinFont].
6. Assigner le format avec [Paragraph.setEndParagraphPortionFormat] et enregistrer la présentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Paragraph, Portion, PortionFormat, Presentation, SaveFormat, ShapeType

presentation = Presentation("Test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_portion = Portion("Sample text")
    first_paragraph.getPortions().add(first_portion)
    second_paragraph = Paragraph()
    second_portion = Portion("Sample text 2")
    second_paragraph.getPortions().add(second_portion)
    end_paragraph_format = PortionFormat()
    end_paragraph_format.setFontHeight(48)
    latin_font = FontData("Times New Roman")
    end_paragraph_format.setLatinFont(latin_font)
    second_paragraph.setEndParagraphPortionFormat(end_paragraph_format)
    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)
    presentation.save("end_paragraph_format.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Importer et exporter le contenu des paragraphes**

### **Importer du texte HTML dans des paragraphes**

Utiliser [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraphcollection/#addFromHtml) pour convertir le balisage HTML en paragraphes et portions dans un cadre de texte.

1. Créer une instance de la classe [Presentation].
2. Accéder à une diapositive et ajouter une [AutoShape].
3. Accéder au [TextFrame] de la forme et nettoyer le paragraphe par défaut.
4. Lire le fichier HTML source.
5. Passer la chaîne HTML à [ParagraphCollection.addFromHtml].
6. Enregistrer la présentation modifiée.

Cet exemple Python importe du HTML dans un cadre de texte :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape_width = presentation.getSlideSize().getSize().getWidth() - 20
    shape_height = presentation.getSlideSize().getSize().getHeight() - 20
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, shape_width, shape_height)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getTextFrame().getParagraphs().clear()
    try:
        html = Path("file.html").read_text(encoding="utf-8")
        shape.getTextFrame().getParagraphs().addFromHtml(html)
        presentation.save("html_text.pptx", SaveFormat.Pptx)
    except OSError as exception:
        print("The HTML file could not be read: " + str(exception))
finally:
    presentation.dispose()
```

### **Exporter le texte d’un paragraphe vers HTML**

Utiliser [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraphcollection/#exportToHtml) pour exporter une plage sélectionnée de paragraphes au format HTML.

1. Créer une instance de la classe [Presentation] et charger la présentation souhaitée.
2. Accéder à la diapositive et trouver l’[AutoShape] contenant le texte.
3. Accéder au [TextFrame] de la forme.
4. Appeler [ParagraphCollection.exportToHtml] avec l’indice du paragraphe de départ et le nombre de paragraphes à exporter.
5. Écrire la chaîne HTML retournée dans un fichier.

Cet exemple Python exporte tous les paragraphes du premier cadre de texte :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation
from pathlib import Path

presentation = Presentation("ExportingHTMLText.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, AutoShape):
        text_shape = shape
        text_frame = text_shape.getTextFrame()
        if text_frame is not None:
            paragraphs = text_frame.getParagraphs()
            html = paragraphs.exportToHtml(0, paragraphs.getCount(), None)
            try:
                Path("paragraphs.html").write_text(str(html), encoding="utf-8")
            except OSError as exception:
                print("The HTML file could not be written: " + str(exception))
        else:
            print("The first shape does not contain a text frame.")
    else:
        print("The first shape is not a text shape.")
finally:
    presentation.dispose()
```

### **Rendre un paragraphe en image**

[Paragraph.getImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraph/) rend directement un paragraphe individuel et renvoie un objet image. Enregistrez le résultat dans un fichier ou un flux avec sa méthode `save`. Vous n’avez pas besoin de rendre la forme contenant ou de recadrer un bitmap manuellement.

[Paragraph.getImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraph/) peut renvoyer `None` si le paragraphe est introuvable dans sa collection parent, n’a pas de limites de rendu valides, ou ne peut pas être rendu. Vérifiez le résultat avant de l’enregistrer et libérez l’image retournée après utilisation.

#### **Rendre un paragraphe à l’échelle par défaut**

Supposons que nous ayons un fichier de présentation nommé sample.pptx contenant une diapositive, où la première forme est une zone de texte contenant trois paragraphes.

![La zone de texte avec trois paragraphes](paragraph_to_image_input.png)

L’exemple suivant rend le second paragraphe d’une forme de texte ordinaire à l’échelle par défaut et enregistre l’image retournée au format PNG. Le bloc `finally` garantit que l’image est correctement libérée.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, ImageFormat, Presentation

presentation = Presentation("sample.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, AutoShape):
        text_shape = shape
        text_frame = text_shape.getTextFrame()
        if text_frame is not None and text_frame.getParagraphs().getCount() > 1:
            paragraph = text_frame.getParagraphs().get_Item(1)
            paragraph_image = paragraph.getImage()
            if paragraph_image is not None:
                try:
                    paragraph_image.save("paragraph.png", ImageFormat.Png)
                finally:
                    paragraph_image.dispose()
            else:
                print("The paragraph could not be rendered.")
        else:
            print("The expected paragraph was not found.")
    else:
        print("The first shape is not a text shape.")
finally:
    presentation.dispose()
```

Le résultat :

![L’image du paragraphe](paragraph_to_image_output.png)

#### **Rendre un paragraphe dans une cellule de tableau avec mise à l’échelle**

Utilisez la surcharge de [Paragraph.getImage] qui accepte les paramètres `scale_x` et `scale_y` pour définir les facteurs d’échelle horizontaux et verticaux. L’exemple suivant crée un tableau, rend le paragraphe dans sa première cellule à deux fois sa largeur et hauteur par défaut, et enregistre le résultat au format PNG.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

scale_x = 2.0
scale_y = 2.0
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().addTable(50, 50, [300.0], [80.0])
    paragraph = table.get_Item(0, 0).getTextFrame().getParagraphs().get_Item(0)
    paragraph.setText("Text in a table cell")
    paragraph_image = paragraph.getImage(scale_x, scale_y)
    if paragraph_image is not None:
        try:
            paragraph_image.save("table_paragraph.png", ImageFormat.Png)
        finally:
            paragraph_image.dispose()
    else:
        print("The paragraph could not be rendered.")
finally:
    presentation.dispose()
```

Un facteur d’échelle de `1` conserve la taille pixel par défaut pour cet axe. Par exemple, `2` pour les deux facteurs produit une image dont la largeur et la hauteur sont approximativement doubles, soit quatre fois plus de pixels. Des facteurs plus grands produisent généralement un texte plus net pour le zoom ou les sorties haute résolution, mais augmentent également la mémoire et la taille du fichier. Des facteurs inférieurs à `1` génèrent des images plus petites avec moins de détails. Utilisez des facteurs égaux pour conserver le ratio d’aspect du paragraphe ; des facteurs différents en horizontal et vertical étirent la sortie indépendamment.

Rendre une forme entière avec [Shape.getImage] reste utile lorsque la sortie doit inclure le remplissage, la bordure ou d’autres contextes visuels de la forme. Pour une image contenant uniquement le paragraphe, utilisez [Paragraph.getImage].

## **FAQ**

**Puis‑je désactiver complètement le retour à la ligne à l’intérieur d’un cadre de texte ?**

Oui. Définissez [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframeformat/#setWrapText) pour désactiver le retour à la ligne afin que les lignes ne se coupent pas aux bords du cadre de texte.

**Comment obtenir les limites exactes d’un paragraphe sur la diapositive ?**

Utilisez [Paragraph.getRect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraph/#getRect) pour récupérer le rectangle englobant du paragraphe. [Portion.getRect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/portion/#getRect) fournit les limites d’une portion individuelle.

**Où est contrôlé l’alignement du paragraphe (gauche, droite, centre ou justifié) ?**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraphformat/#setAlignment) est un paramètre au niveau du paragraphe et s’applique à l’ensemble du paragraphe, quel que soit le formatage des portions individuelles.

**Puis‑je définir la langue de révision pour une partie d’un paragraphe ?**

Oui. Définissez [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseportionformat/#setLanguageId) pour les portions individuelles, de sorte qu’un paragraphe puisse contenir du texte dans plusieurs langues.