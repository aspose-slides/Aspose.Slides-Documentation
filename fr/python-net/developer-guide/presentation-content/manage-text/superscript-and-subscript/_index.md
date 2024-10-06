---
title: Exposant et Indice
type: docs
weight: 80
url: /python-net/superscript-and-subscript/
keywords: "Exposant, Indice, Ajouter du texte exposant, Ajouter du texte indice, Présentation PowerPoint, Python, Aspose.Slides pour Python via .NET"
description: "Ajouter du texte exposant et indice aux présentations PowerPoint en Python"
---

## **Gérer le Texte Exposant et Indice**
Vous pouvez ajouter du texte exposant et indice à l'intérieur de n'importe quelle portion de paragraphe. Pour ajouter du texte Exposant ou Indice dans le cadre de texte d'Aspose.Slides, il faut utiliser **les propriétés d'Escapement** de la classe PortionFormat.

Cette propriété renvoie ou définit le texte exposant ou indice (valeur allant de -100% (indice) à 100% (exposant). Par exemple :

- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
- Obtenir la référence d'une diapositive en utilisant son Index.
- Ajouter une IAutoShape de type Rectangle à la diapositive.
- Accéder à l'ITextFrame associé à l'IAutoShape.
- Effacer les Paragraphes existants.
- Créer un nouvel objet paragraphe pour contenir le texte exposant et l'ajouter à la collection IParagraphs de l'ITextFrame.
- Créer un nouvel objet portion.
- Définir la propriété Escapement pour la portion entre 0 et 100 pour ajouter un exposant. (0 signifie pas d'exposant).
- Définir un texte pour la Portion et l'ajouter à la collection de portions du paragraphe.
- Créer un nouvel objet paragraphe pour contenir le texte indice et l'ajouter à la collection IParagraphs de l'ITextFrame.
- Créer un nouvel objet portion.
- Définir la propriété Escapement pour la portion entre 0 et -100 pour ajouter un indice. (0 signifie pas d'indice).
- Définir un texte pour la Portion et l'ajouter à la collection de portions du paragraphe.
- Sauvegarder la présentation en tant que fichier PPTX.

L'implémentation des étapes ci-dessus est donnée ci-dessous.

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    # Obtenir la diapositive
    slide = presentation.slides[0]

    # Créer une zone de texte
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)
    textFrame = shape.text_frame
    textFrame.paragraphs.clear()

    # Créer un paragraphe pour le texte exposant
    superPar = slides.Paragraph()

    # Créer une portion avec du texte habituel
    portion1 = slides.Portion()
    portion1.text = "SlideTitle"
    superPar.portions.add(portion1)

    # Créer une portion avec du texte exposant
    superPortion = slides.Portion()
    superPortion.portion_format.escapement = 30
    superPortion.text = "TM"
    superPar.portions.add(superPortion)

    # Créer un paragraphe pour le texte indice
    paragraph2 = slides.Paragraph()

    # Créer une portion avec du texte habituel
    portion2 = slides.Portion()
    portion2.text = "a"
    paragraph2.portions.add(portion2)

    # Créer une portion avec du texte indice
    subPortion = slides.Portion()
    subPortion.portion_format.escapement = -25
    subPortion.text = "i"
    paragraph2.portions.add(subPortion)

    # Ajouter lesParagraphes à la zone de texte
    textFrame.paragraphs.add(superPar)
    textFrame.paragraphs.add(paragraph2)

    presentation.save("TestOut.pptx", slides.export.SaveFormat.PPTX)
```