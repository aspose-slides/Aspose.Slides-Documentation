---
title: Gérer les polices dans les présentations avec Python via Java
linktitle: Gérer les polices
type: docs
weight: 10
url: /fr/python-java/manage-fonts/
keywords:
- gérer les polices
- propriétés de police
- paragraphe
- formatage du texte
- PowerPoint
- OpenDocument
- présentation
- Python
- Java
- Aspose.Slides
description: "Contrôlez les polices en Python via Java avec Aspose.Slides : intégrez, remplacez et chargez des polices personnalisées pour que les présentations PPT, PPTX et ODP restent nettes, conformes à la marque et cohérentes."
---
## **Vue d'ensemble**

Aspose.Slides vous permet de gérer les propriétés des polices dans le texte d'une présentation directement depuis votre code. Vous pouvez accéder au texte des diapositives via les formes, les cadres de texte, les paragraphes et les portions, puis appliquer le formatage au texte sélectionné.

Cet article explique comment configurer les propriétés liées aux polices pour du texte existant dans une présentation, y compris la famille de polices, les styles gras et italique, l’alignement du paragraphe et la couleur de la police. Il montre également comment créer une zone de texte, y ajouter du texte et définir les propriétés de police telles que la famille, le gras, l’italique, le soulignement, la taille et la couleur avant d’enregistrer le résultat dans un fichier PPTX.

## **Gérer les propriétés liées aux polices**
{{% alert color="info" title="Note" %}} 

Les présentations contiennent généralement à la fois du texte et des images. Le texte peut être formaté de différentes manières, que ce soit pour mettre en évidence des sections et des mots spécifiques ou pour se conformer aux styles corporatifs. Le formatage du texte aide les utilisateurs à varier l’aspect du contenu de la présentation. Cet article montre comment utiliser Aspose.Slides for Python via Java pour configurer les propriétés de police des paragraphes de texte sur les diapositives.

{{% /alert %}} 

Pour gérer les propriétés de police d’un paragraphe à l’aide d’Aspose.Slides for Python via Java :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive en utilisant son indice.
1. Accédez aux formes [Placeholder](https://reference.aspose.com/slides/fr/python-java/aspose.slides/placeholder/) de la diapositive en tant que [AutoShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/autoshape/).
1. Récupérez le [Paragraph](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraph/) à partir du [TextFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframe/) exposé par [AutoShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/autoshape/).
1. Justifiez le paragraphe.
1. Accédez au texte d’un [Paragraph](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraph/) via la [Portion](https://reference.aspose.com/slides/fr/python-java/aspose.slides/portion/).
1. Définissez la police à l’aide de [FontData](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontdata/) et réglez la **Font** de la [Portion](https://reference.aspose.com/slides/fr/python-java/aspose.slides/portion/) en conséquence.
   1. Mettez la police en gras.
   1. Mettez la police en italique.
1. Définissez la couleur de la police à l’aide du [FillFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fillformat/) exposé par l’objet [Portion](https://reference.aspose.com/slides/fr/python-java/aspose.slides/portion/).
1. Enregistrez la présentation modifiée dans un fichier PPTX.

L’implémentation des étapes ci‑dessus est donnée ci‑après. Elle prend une présentation non décorée et formatte les polices sur l’une des diapositives. Les captures d’écran qui suivent montrent le fichier d’entrée et la façon dont les extraits de code le modifient. Le code change la police, la couleur et le style de la police.

|![Text in the input presentation](https://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Figure : Le texte du fichier d'entrée**|


|![Text with updated font formatting](https://i.imgur.com/rY27Lt9.png)|
| :- |
|**Figure : Le même texte avec le formatage mis à jour**|

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, TextAlignment
from java.awt import Color

# Charger la présentation.
presentation = Presentation("FontProperties.pptx")
try:
    # Accéder à la première diapositive et aux cadres de texte de ses deux premiers espaces réservés.
    slide = presentation.getSlides().get_Item(0)
    title_text_frame = slide.getShapes().get_Item(0).getTextFrame()
    body_text_frame = slide.getShapes().get_Item(1).getTextFrame()

    # Accéder au premier paragraphe de chaque cadre de texte.
    title_paragraph = title_text_frame.getParagraphs().get_Item(0)
    body_paragraph = body_text_frame.getParagraphs().get_Item(0)
    body_paragraph.getParagraphFormat().setAlignment(TextAlignment.JustifyLow)

    # Accéder à la première portion de chaque paragraphe.
    title_portion = title_paragraph.getPortions().get_Item(0)
    body_portion = body_paragraph.getPortions().get_Item(0)

    # Définir et attribuer de nouvelles polices.
    title_font = FontData("Elephant")
    body_font = FontData("Castellar")
    title_portion.getPortionFormat().setLatinFont(title_font)
    body_portion.getPortionFormat().setLatinFont(body_font)

    # Mettre les polices en gras et en italique.
    title_portion.getPortionFormat().setFontBold(NullableBool.True_)
    body_portion.getPortionFormat().setFontBold(NullableBool.True_)
    title_portion.getPortionFormat().setFontItalic(NullableBool.True_)
    body_portion.getPortionFormat().setFontItalic(NullableBool.True_)

    # Définir les couleurs des polices.
    title_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    title_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    body_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    body_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN)

    # Enregistrer la présentation.
    presentation.save("WelcomeFont.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Définir les propriétés de police du texte**
{{% alert color="info" title="Note" %}} 

Comme indiqué dans **Gérer les propriétés liées aux polices**, une [Portion](https://reference.aspose.com/slides/fr/python-java/aspose.slides/portion/) est utilisée pour contenir du texte ayant le même style de formatage dans un paragraphe. Cet article montre comment utiliser Aspose.Slides for Python via Java pour créer une zone de texte contenant du texte puis définir une police particulière ainsi que diverses autres propriétés de police.

{{% /alert %}} 

Pour créer une zone de texte et définir les propriétés de police du texte qu’elle contient :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
1. Obtenez la référence d’une diapositive en utilisant son indice.
1. Ajoutez un [AutoShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/autoshape/) de type **Rectangle** à la diapositive.
1. Supprimez le style de remplissage associé au [AutoShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/autoshape/).
1. Accédez au [TextFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframe/) du [AutoShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/autoshape/).
1. Ajoutez du texte au [TextFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframe/).
1. Accédez à l’objet [Portion](https://reference.aspose.com/slides/fr/python-java/aspose.slides/portion/) associé au [TextFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframe/).
1. Définissez la police à utiliser pour la [Portion](https://reference.aspose.com/slides/fr/python-java/aspose.slides/portion/).
1. Définissez d’autres propriétés de police comme le gras, l’italique, le soulignement, la couleur et la hauteur à l’aide des propriétés correspondantes exposées par l’objet [Portion](https://reference.aspose.com/slides/fr/python-java/aspose.slides/portion/).
1. Enregistrez la présentation modifiée dans un fichier PPTX.

L’implémentation des étapes ci‑dessus est donnée ci‑après.

|![Text with font properties applied](https://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Figure : Texte avec certaines propriétés de police définies par Aspose.Slides for Python via Java**|

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextUnderlineType
from java.awt import Color

presentation = Presentation()
try:
    # Récupérez la première diapositive et ajoutez un rectangle.
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50)

    # Supprimez le remplissage de la forme.
    shape.getFillFormat().setFillType(FillType.NoFill)

    # Ajoutez du texte au cadre de texte de la forme.
    text_frame = shape.getTextFrame()
    text_frame.setText("Aspose TextBox")
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)

    # Définissez la famille de police.
    font = FontData("Times New Roman")
    portion.getPortionFormat().setLatinFont(font)

    # Définissez le gras, l'italique, le soulignement et la taille de police.
    portion.getPortionFormat().setFontBold(NullableBool.True_)
    portion.getPortionFormat().setFontItalic(NullableBool.True_)
    portion.getPortionFormat().setFontUnderline(TextUnderlineType.Single)
    portion.getPortionFormat().setFontHeight(25)

    # Définissez la couleur de la police.
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # Enregistrez la présentation.
    presentation.save("pptxFont.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```