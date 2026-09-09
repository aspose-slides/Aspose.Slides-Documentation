---
title: Gérer les exposants et les indices dans les présentations en utilisant Python via Java
linktitle: Exposant et indice
type: docs
weight: 80
url: /fr/python-java/superscript-and-subscript/
keywords:
- exposant
- indice
- ajouter exposant
- ajouter indice
- PowerPoint
- OpenDocument
- présentation
- Python
- Java
- Aspose.Slides
description: "Maîtrisez les exposants et les indices dans Aspose.Slides pour Python via Java et améliorez vos présentations avec une mise en forme de texte professionnelle pour un impact maximal."
---
## **Vue d'ensemble**

Aspose.Slides propose des fonctionnalités pour intégrer du texte en exposant et en indice dans vos présentations PowerPoint (PPT, PPTX) et OpenDocument (ODP). Que vous ayez besoin de mettre en évidence des formules chimiques, des équations mathématiques ou d'annoter du contenu avec des notes de bas de page, ces options de mise en forme spécialisées aident à maintenir clarté et précision. Dans cet article, vous apprendrez comment appliquer sans effort les styles d'exposant et d'indice et garantir des résultats professionnels sur chaque diapositive.

## **Gérer le texte en exposant et en indice**

Vous pouvez ajouter du texte en exposant et en indice à n'importe quelle portion d'un paragraphe. Pour appliquer cette mise en forme dans un cadre de texte Aspose.Slides, utilisez la méthode [setEscapement](https://reference.aspose.com/slides/fr/python-java/aspose.slides/portionformat/#setEscapement) de la classe [PortionFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/portionformat/).

La valeur d'escapement varie de -100% (indice) à 100% (exposant). Par exemple :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
- Récupérez une diapositive par son indice.
- Ajoutez une [AutoShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/autoshape/) de type [ShapeType.Rectangle](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapetype/#Rectangle) à la diapositive.
- Accédez au [TextFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframe/) associé à la [AutoShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/autoshape/).
- Effacez les paragraphes existants.
- Créez un paragraphe pour contenir le texte en exposant et ajoutez-le à la [collection de paragraphes](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframe/#getParagraphs) du cadre de texte.
- Créez une portion.
- Utilisez [setEscapement](https://reference.aspose.com/slides/fr/python-java/aspose.slides/portionformat/#setEscapement) pour définir une valeur de 0 à 100 pour l'exposant (0 signifie aucun exposant).
- Définissez le texte de la [Portion](https://reference.aspose.com/slides/fr/python-java/aspose.slides/portion/) et ajoutez-le à la collection de portions du paragraphe.
- Créez un paragraphe pour contenir le texte en indice et ajoutez-le à la [collection de paragraphes](https://reference.aspose.com/slides/fr/python-java/aspose.slides/textframe/#getParagraphs) du cadre de texte.
- Créez une portion.
- Utilisez [setEscapement](https://reference.aspose.com/slides/fr/python-java/aspose.slides/portionformat/#setEscapement) pour définir une valeur de -100 à 0 pour l'indice (0 signifie aucun indice).
- Définissez le texte de la [Portion](https://reference.aspose.com/slides/fr/python-java/aspose.slides/portion/) et ajoutez-le à la collection de portions du paragraphe.
- Enregistrez la présentation au format PPTX.

L'exemple suivant met en œuvre ces étapes :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Paragraph, Portion, Presentation, SaveFormat, ShapeType

# Créer une présentation.
presentation = Presentation()
try:
    # Récupérer la diapositive.
    slide = presentation.getSlides().get_Item(0)

    # Créer une zone de texte.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()

    # Créer un paragraphe pour le texte en exposant.
    superscript_paragraph = Paragraph()

    # Créer une portion avec du texte normal.
    title_portion = Portion()
    title_portion.setText("SlideTitle")
    superscript_paragraph.getPortions().add(title_portion)

    # Créer une portion avec du texte en exposant.
    superscript_portion = Portion()
    superscript_portion.getPortionFormat().setEscapement(30)
    superscript_portion.setText("TM")
    superscript_paragraph.getPortions().add(superscript_portion)

    # Créer un paragraphe pour le texte en indice.
    subscript_paragraph = Paragraph()

    # Créer une portion avec du texte normal.
    base_portion = Portion()
    base_portion.setText("a")
    subscript_paragraph.getPortions().add(base_portion)

    # Créer une portion avec du texte en indice.
    subscript_portion = Portion()
    subscript_portion.getPortionFormat().setEscapement(-25)
    subscript_portion.setText("i")
    subscript_paragraph.getPortions().add(subscript_portion)

    # Ajouter les paragraphes à la zone de texte.
    text_frame.getParagraphs().add(superscript_paragraph)
    text_frame.getParagraphs().add(subscript_paragraph)

    presentation.save("formatText.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**L'exposant et l'indice seront-ils conservés lors de l'exportation vers PDF ou d'autres formats ?**

Oui, Aspose.Slides conserve correctement la mise en forme en exposant et en indice lors de l'exportation des présentations vers PDF, PPT/PPTX, images et autres formats pris en charge. La mise en forme spécialisée reste intacte dans tous les fichiers de sortie.

**L'exposant et l'indice peuvent-ils être combinés avec d'autres styles de mise en forme tels que gras ou italique ?**

Oui, Aspose.Slides vous permet de mélanger différents styles de texte au sein d'une même portion. Vous pouvez activer le gras, l'italique, le soulignement et appliquer simultanément l'exposant ou l'indice en configurant les propriétés correspondantes dans [PortionFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/portionformat/).

**La mise en forme en exposant et en indice fonctionne-t-elle pour le texte à l'intérieur des tableaux, des graphiques ou de SmartArt ?**

Oui, Aspose.Slides prend en charge la mise en forme dans la plupart des objets, y compris les tableaux et les éléments de graphique. Lorsqu'on travaille avec SmartArt, vous devez accéder aux éléments appropriés (comme [SmartArtNode](https://reference.aspose.com/slides/fr/python-java/aspose.slides/smartartnode/)) et à leurs conteneurs de texte, puis configurer les propriétés de [PortionFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/portionformat/) de la même manière.