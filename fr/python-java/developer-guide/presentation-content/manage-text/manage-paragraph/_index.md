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
- texte vers HTML
- paragraphe vers HTML
- paragraphe vers image
- texte vers image
- exporter le paragraphe
- PowerPoint
- présentation
- Python
- Java
- Aspose.Slides
description: "Apprenez à créer et formater des paragraphes, des portions, des puces, des listes numérotées, des retraits, du contenu HTML et des images de paragraphes avec Aspose.Slides pour Python via Java."
---
## **Vue d'ensemble**

Aspose.Slides for Python via Java représente le texte comme une hierarchie de cadres de texte, de paragraphes et de portions :

* [TextFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframe/) représente le conteneur de texte d'une forme et fournit l'acces a sa collection de paragraphes.
* [Paragraph](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraph/) représente un paragraphe dans un cadre de texte et fournit l'acces a ses portions et au formatage au niveau du paragraphe.
* [Portion](https://reference.aspose.com/slides/fr/python-java/aspose.slides/portion/) représente une execution de texte au sein d'un paragraphe. Chaque portion peut avoir son propre texte et son formatage au niveau des caracteres.

Un paragraphe peut donc contenir du texte avec differentes polices, couleurs, tailles et autres mises en forme en utilisant plusieurs portions.

## **Creer et formater des paragraphes**

### **Creer des paragraphes avec plusieurs portions**

Les etapes suivantes creent un cadre de texte avec trois paragraphes, chacun contenant trois portions :

1. Creer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
2. Accedez a la diapositive concernee grace a son indice.
3. Ajoutez une [AutoShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/autoshape/) rectangulaire a la diapositive.
4. Accedez au [TextFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframe/) de la forme.
5. Utilisez le paragraphe par defaut et ajoutez deux autres objets [Paragraph](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraph/) au cadre de texte.
6. Ajoutez suffisamment d'objets [Portion](https://reference.aspose.com/slides/fr/python-java/aspose.slides/portion/) pour que chaque paragraphe contienne trois portions. Le paragraphe par defaut contient deja une portion vide.
7. Definissez le texte de chaque portion.
8. Appliquez le formatage au niveau des caracteres via [Portion.getPortionFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/portion/#getPortionFormat).
9. Enregistrez la presentation modifiee.

Cet exemple Python implemente les etapes :

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

## **Creer des listes a puces et numerotees**

### **Creer une liste a puces ou numerotee**

Les puces et la numerotation facilitent la lecture d'elements lies. Dans Aspose.Slides, les parametres de liste sont defines via [BulletFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/bulletformat/).

1. Creer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
2. Accedez a la diapositive concernee grace a son indice.
3. Ajoutez une [AutoShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/autoshape/) a la diapositive selectionnee.
4. Accedez au [TextFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframe/) de la forme.
5. Supprimez le paragraphe par defaut du cadre de texte.
6. Creer un [Paragraph](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraph/) pour une puce symbole.
7. Definissez [BulletFormat.setType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/bulletformat/#setType) sur [BulletType.Symbol](https://reference.aspose.com/slides/fr/python-java/aspose.slides/bullettype/#Symbol) et specifiez le caractere de puce.
8. Definissez le texte du paragraphe, le retrait, la couleur de la puce et la hauteur de la puce.
9. Ajoutez le paragraphe au cadre de texte.
10. Creer un deuxieme paragraphe et definissez [BulletFormat.setType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/bulletformat/#setType) sur [BulletType.Numbered](https://reference.aspose.com/slides/fr/python-java/aspose.slides/bullettype/#Numbered).
11. Configurez le style de puce numerotee et ajoutez le paragraphe au cadre de texte.
12. Enregistrez la presentation.

Cet exemple Python cree une puce symbole et une puce numerotee :

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

Les puces image vous permettent d'utiliser une image personnalisee au lieu d'un symbole ou d'un numero.

1. Creer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
2. Accedez a la diapositive concernee grace a son indice.
3. Ajoutez une [AutoShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/autoshape/) et accedez a son [TextFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframe/).
4. Supprimez le paragraphe par defaut du cadre de texte.
5. Chargez l'image de puce et ajoutez-la a la collection d'images de la presentation en tant que [PPImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/ppimage/).
6. Creer un [Paragraph](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraph/) et definissez son texte.
7. Definissez [BulletFormat.setType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/bulletformat/#setType) sur [BulletType.Picture](https://reference.aspose.com/slides/fr/python-java/aspose.slides/bullettype/#Picture).
8. Assignez l'image via [BulletFormat.getPicture](https://reference.aspose.com/slides/fr/python-java/aspose.slides/bulletformat/#getPicture) et definissez la hauteur de la puce.
9. Ajoutez le paragraphe au cadre de texte.
10. Enregistrez la presentation modifiee.

Cet exemple Python cree une puce image :

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

### **Creer une liste a plusieurs niveaux**

Definissez [ParagraphFormat.setDepth](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraphformat/#setDepth) pour placer les paragraphes a différents niveaux d'une liste. Le niveau superieur a une profondeur de `0`.

1. Creer une [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) et accedez a une diapositive.
2. Ajoutez une [AutoShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/autoshape/) et supprimez le paragraphe par defaut de son cadre de texte.
3. Creer quatre paragraphes et configurez leurs symboles de puce.
4. Definissez leurs valeurs [ParagraphFormat.setDepth](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraphformat/#setDepth) a `0`, `1`, `2` et `3`.
5. Ajoutez les paragraphes au cadre de texte et enregistrez la presentation.

Cet exemple Python cree une liste a puces a quatre niveaux :

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

### **Definir le demarrage des puces numerotees a des valeurs personnalisees**

Utilisez [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/fr/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) pour definir le numero initial affiche pour un paragraphe numerote.

1. Creer une [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) et ajoutez une [AutoShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/autoshape/) a une diapositive.
2. Supprimez le paragraphe par defaut du cadre de texte de la forme.
3. Creer trois paragraphes numerotes.
4. Definissez [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/fr/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) a `2`, `3` et `7` pour les paragraphes respectifs.
5. Ajoutez les paragraphes au cadre de texte et enregistrez la presentation.

Cet exemple Python assigne un numero de depart personnalise a chaque paragraphe :

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

## **Controler la mise en page du paragraphe et les proprietes de fin**

### **Definir un retrait de premiere ligne**

Utilisez [ParagraphFormat.setIndent](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraphformat/#setIndent) pour controler le retrait de la premiere ligne d'un paragraphe. Cette methode ne deplace que la premiere ligne par rapport a la marge gauche du paragraphe. Une valeur positive decale la premiere ligne vers la droite, tandis que les lignes restantes restent alignees sur le corps du paragraphe.

Utilisez [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraphformat/#setMarginLeft) lorsque vous devez deplacer tout le paragraphe. Utilisez [ParagraphFormat.setIndent](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraphformat/#setIndent) lorsque vous devez deplacer uniquement la premiere ligne.

L'exemple ci-dessous cree plusieurs paragraphes et applique differentes valeurs [ParagraphFormat.setIndent](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraphformat/#setIndent) pour demontrer comment le retrait de premiere ligne affecte la mise en page du paragraphe.

1. Creer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
2. Accedez a la diapositive cible.
3. Ajoutez une [AutoShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/autoshape/) rectangulaire a la diapositive.
4. Accedez au [TextFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframe/) de la forme et supprimez le paragraphe par defaut.
5. Creer plusieurs paragraphes et definissez differentes valeurs [ParagraphFormat.setIndent](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraphformat/#setIndent) pour ceux-ci.
6. Ajoutez les paragraphes au cadre de texte.
7. Enregistrez la presentation modifiee.

Ce code montre comment definir un retrait de paragraphe :

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

Le resultat :

![Le retrait de premiere ligne des paragraphes](first_line_indent.png)

### **Definir un retrait suspendu**

Un retrait suspendu est une mise en page de paragraphe ou la premiere ligne commence a gauche des lignes restantes. Dans Aspose.Slides, vous creez cet effet avec [ParagraphFormat.setIndent](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraphformat/#setIndent). Passez une valeur negative pour deplacer la premiere ligne vers la gauche par rapport au corps du paragraphe.

En pratique, [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraphformat/#setMarginLeft) definit la position gauche du corps du paragraphe, et [ParagraphFormat.setIndent](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraphformat/#setIndent) definit la position de la premiere ligne par rapport a cette marge. Pour creer un retrait suspendu, passez une valeur positive a [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraphformat/#setMarginLeft) et une valeur negative a [ParagraphFormat.setIndent](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraphformat/#setIndent).

Ce formatage est utile pour les bibliographies, references, entrees de glossaire et autres paragraphes ou les lignes enroulees doivent s'aligner sous le corps du paragraphe pluto que sous le premier caractere de la premiere ligne.

1. Creer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
2. Accedez a la diapositive cible.
3. Ajoutez une [AutoShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/autoshape/) rectangulaire a la diapositive.
4. Accedez au [TextFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframe/) de la forme et supprimez le paragraphe par defaut.
5. Creer des paragraphes et passez une valeur positive a [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraphformat/#setMarginLeft) pour chaque paragraphe.
6. Passez une valeur negative a [ParagraphFormat.setIndent](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraphformat/#setIndent) pour creer l'effet de retrait suspendu.
7. Ajoutez les paragraphes au cadre de texte.
8. Enregistrez la presentation modifiee.

Ce code montre comment definir un retrait suspendu pour un paragraphe :

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

Le resultat :

![Le retrait suspendu des paragraphes](hanging_indent.png)

### **Definir les proprietes de fin du paragraphe**

[Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) controle le formatage du marqueur de fin du paragraphe. L'exemple suivant affecte une taille de police et une police latine au marqueur de fin du deuxieme paragraphe :

1. Chargez une [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) et accedez a une diapositive.
2. Ajoutez une [AutoShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/autoshape/) et supprimez son paragraphe par defaut.
3. Creer deux paragraphes et ajoutez des portions de texte a chacun.
4. Creer un [PortionFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/portionformat/) pour le marqueur de fin du deuxieme paragraphe.
5. Definissez [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseportionformat/#setFontHeight) et [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseportionformat/#setLatinFont).
6. Assignez le format avec [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) et enregistrez la presentation.

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

## **Compter les lignes rendues**

Pour les regles de paragraphe qui affectent le renvoi automatique et la ponctuation en fin de ligne, voir [Control Line Breaking](/slides/fr/python-java/text-formatting/#control-line-breaking) et [Control Hanging Punctuation](/slides/fr/python-java/text-formatting/#control-hanging-punctuation).

Utilisez [Paragraph.getLinesCount](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraph/#getLinesCount) pour compter les lignes occupees par un paragraphe apres la mise en page du texte, y compris le renvoi automatique. Ceci est utile lors de la verification de la longueur du texte et de la mise en page dans les modeles de presentation.

Un paragraphe est un element de [TextFrame.getParagraphs](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframe/#getParagraphs), et il peut occuper plusieurs lignes rendues. Un saut de ligne explicite dans un paragraphe force une nouvelle ligne sans creer un autre paragraphe. Le renvoi automatique cree des lignes en fonction de la largeur disponible sans inserer de sauts de ligne explicites dans le texte. Ainsi, compter les paragraphes ou les caracteres de saut de ligne ne donne pas le nombre de lignes rendues.

L'exemple suivant cree une forme de texte, compte ses lignes, réduit la forme, puis remplace le texte par une chaine plus courte. Le renvoi est active et l'ajustement automatique desactive afin que la largeur de la forme controle le renvoi sans reduire automatiquement le texte ou redimensionner la forme. Les dimensions de la forme sont exprimees en points. Enfin, l'exemple ajoute un autre paragraphe et additionne les comptes de lignes dans le cadre de texte.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Paragraph, Presentation, ShapeType, TextAutofitType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setWrapText(NullableBool.True_)
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)

    paragraph = text_frame.getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20)
    paragraph.setText("This text demonstrates how automatic wrapping changes the number of rendered lines.")
    print("Original width:", paragraph.getLinesCount())

    shape.setWidth(150)
    print("Narrower shape:", paragraph.getLinesCount())

    paragraph.setText("Short text.")
    print("Shorter text:", paragraph.getLinesCount())

    second_paragraph = Paragraph()
    second_paragraph.setText("Another paragraph.")
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20)
    text_frame.getParagraphs().add(second_paragraph)

    total_line_count = 0
    for current_paragraph in text_frame.getParagraphs():
        total_line_count += current_paragraph.getLinesCount()
    print("Total lines in the text frame:", total_line_count)
finally:
    presentation.dispose()
```

Avec ce texte et ces dimensions, reduire la forme augmente le nombre de lignes, tandis que remplacer le texte par la chaine courte le reduit. Les comptes exacts peuvent varier selon la disponibilite et la substitution des polices, la taille de la police, les marges, le retrait, le renvoi et les parametres d'ajustement automatique. Utilisez les polices et les parametres de mise en page prevus pour l'environnement cible lors de la verification d'un modele.

Le nombre de lignes seul ne determine pas si le texte depasse son conteneur. La hauteur disponible, les hauteurs de ligne, l'espacement des paragraphes et des lignes, et le comportement d'ajustement automatique sont egalement importants; meme une seule ligne peut depasser la largeur disponible lorsque le renvoi est desactive.

## **Importer et exporter le contenu des paragraphes**

### **Importer du texte HTML dans des paragraphes**

Utilisez [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraphcollection/#addFromHtml) pour convertir le balisage HTML en paragraphes et portions dans un cadre de texte.

1. Creer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
2. Accedez a une diapositive et ajoutez une [AutoShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/autoshape/).
3. Accedez au [TextFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframe/) de la forme et supprimez son paragraphe par defaut.
4. Lisez le fichier HTML source.
5. Transmettez la chaine HTML a [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraphcollection/#addFromHtml).
6. Enregistrez la presentation modifiee.

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

### **Exporter le texte des paragraphes vers HTML**

Utilisez [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraphcollection/#exportToHtml) pour exporter une plage selectionnee de paragraphes au format HTML.

1. Creer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) et chargez la presentation souhaitee.
2. Accedez a la diapositive et trouvez l'[AutoShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/autoshape/) qui contient le texte.
3. Accedez au [TextFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframe/) de la forme.
4. Appelez [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraphcollection/#exportToHtml) avec l'indice du paragraphe de depart et le nombre de paragraphes a exporter.
5. Ecrivez la chaine HTML renvoyee dans un fichier.

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

### **Rendre un paragraphe sous forme d'image**

[Paragraph.getImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraph/) rend directement un paragraphe individuel et renvoie un objet image. Enregistrez le resultat dans un fichier ou un flux avec sa methode `save`. Vous n'avez pas besoin de rendre la forme contenant le paragraphe ni de recadrer un bitmap manuellement.

[Paragraph.getImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraph/) peut renvoyer `None` si le paragraphe est introuvable dans sa collection parente, n'a pas de limites de rendu valides ou ne peut pas etre rendu. Verifiez le resultat avant de l'enregistrer et liberez l'image renvoyee apres utilisation.

#### **Rendre un paragraphe a l'echelle par defaut**

Supposons que nous disposions d'un fichier de presentation nomme sample.pptx avec une diapositive, ou la premiere forme est une zone de texte contenant trois paragraphes.

![La zone de texte avec trois paragraphes](paragraph_to_image_input.png)

L'exemple suivant rend le deuxieme paragraphe d'une forme de texte ordinaire a l'echelle par defaut et enregistre l'image retournee au format PNG. Le bloc `finally` garantit que l'image est correctement liberee.

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

Le resultat :

![L'image du paragraphe](paragraph_to_image_output.png)

#### **Rendre un paragraphe dans une cellule de tableau avec mise a l'echelle**

Utilisez la surcharge de [Paragraph.getImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraph/) qui accepte les parametres `scale_x` et `scale_y` pour definir les facteurs d'echelle horizontaux et verticaux. L'exemple suivant cree un tableau, rend le paragraphe dans sa premiere cellule a deux fois sa largeur et hauteur par defaut, et enregistre le resultat au format PNG.

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

Un facteur d'echelle de `1` conserve cet axe a sa taille de pixel par defaut. Par exemple, `2` pour les deux facteurs produit une image dont la largeur et la hauteur sont approximativement deux fois les dimensions par defaut, ce qui donne quatre fois plus de pixels. Des facteurs plus eleves produisent généralement un texte plus net pour le zoom ou la sortie haute resolution, mais augmentent egalement la consommation de memoire et la taille du fichier. Des facteurs inferieurs a `1` produisent des images plus petites avec moins de details. Utilisez des facteurs egaux pour preserver le ratio d'aspect du paragraphe; des facteurs differents sur les axes horizontal et vertical etirent la sortie independamment.

Rendre une forme entiere avec [Shape.getImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#getImage) reste utile lorsque la sortie doit inclure le remplissage, la bordure ou d'autres contextes visuels de la forme. Pour une image uniquement du paragraphe, utilisez [Paragraph.getImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraph/).

## **FAQ**

**Puis-je desactiver completement le renvoi de texte dans un cadre de texte?**

Oui. Definissez [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframeformat/#setWrapText) pour desactiver le renvoi afin que les lignes ne se coupent pas aux bords du cadre de texte.

**Comment obtenir les limites exactes d'un paragraphe sur la diapositive?**

Utilisez [Paragraph.getRect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraph/#getRect) pour recuperer le rectangle englobant du paragraphe. [Portion.getRect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/portion/#getRect) fournit les limites d'une portion individuelle.

**Ou le reglage de l'alignement du paragraphe (gauche, droite, centre ou justifier) est-il controle?**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraphformat/#setAlignment) est un parametre au niveau du paragraphe et s'applique a l'ensemble du paragraphe quel que soit le formatage des portions individuelles.

**Puis-je definir la langue de verification pour une partie d'un paragraphe?**

Oui. Definissez [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseportionformat/#setLanguageId) pour les portions individuelles, afin qu'un paragraphe puisse contenir du texte dans plusieurs langues.