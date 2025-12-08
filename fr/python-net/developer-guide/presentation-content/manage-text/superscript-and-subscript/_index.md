---
title: Gérer les exposants et indices en Python
linktitle: Exposant et indice
type: docs
weight: 80
url: /fr/python-net/superscript-and-subscript/
keywords:
- exposant
- indice
- ajouter un exposant
- ajouter un indice
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Maîtrisez les exposants et indices dans Aspose.Slides pour Python via .NET et améliorez vos présentations avec un formatage de texte professionnel pour un impact maximal."
---

## **Ajouter du texte en exposant et indice**

Vous pouvez ajouter du texte en exposant ou en indice à n'importe quelle portion de paragraphe. Dans Aspose.Slides, utilisez la propriété `escapement` de la classe [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/) pour contrôler cela.

`escapement` est un pourcentage compris entre **-100% et 100%** :

- **> 0** → exposant (par ex., 25% = légère élévation ; 100% = exposant complet)
- **0** → ligne de base (pas d'exposant/indice)
- **< 0** → indice (par ex., -25% = légère descente ; -100% = indice complet)

Étapes :

1. Créez une [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) et récupérez une diapositive.  
1. Ajoutez un rectangle [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) et accédez à son [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).  
1. Effacez les paragraphes existants.  
1. Pour l'exposant : créez un paragraphe et une portion, définissez `portion.portion_format.escapement` sur une valeur comprise entre **0 et 100**, définissez le texte, puis ajoutez la portion.  
1. Pour l'indice : créez un autre paragraphe et une portion, définissez `escapement` sur une valeur comprise entre **-100 et 0**, définissez le texte, puis ajoutez la portion.  
1. Enregistrez la présentation au format PPTX.  
```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    # Obtenir une diapositive.
    slide = presentation.slides[0]

    # Créer une zone de texte.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)
    shape.text_frame.paragraphs.clear()

    # Créer un paragraphe pour le texte en exposant.
    superscript_paragraph = slides.Paragraph()

    # Créer une portion de texte avec du texte normal.
    portion1 = slides.Portion()
    portion1.text = "SlideTitle"
    superscript_paragraph.portions.add(portion1)

    # Créer une portion de texte avec du texte en exposant.
    superscript_portion = slides.Portion()
    superscript_portion.portion_format.escapement = 30
    superscript_portion.text = "TM"
    superscript_paragraph.portions.add(superscript_portion)

    # Créer un paragraphe pour le texte en indice.
    subscript_paragraph = slides.Paragraph()

    # Créer une portion de texte avec du texte normal.
    portion2 = slides.Portion()
    portion2.text = "a"
    subscript_paragraph.portions.add(portion2)

    # Créer une portion de texte avec du texte en indice.
    subscript_portion = slides.Portion()
    subscript_portion.portion_format.escapement = -25
    subscript_portion.text = "i"
    subscript_paragraph.portions.add(subscript_portion)

    # Ajouter les paragraphes à la zone de texte.
    shape.text_frame.paragraphs.add(superscript_paragraph)
    shape.text_frame.paragraphs.add(subscript_paragraph)

    presentation.save("TestOut.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Puis-je appliquer l'exposant/l'indice dans les tableaux et autres conteneurs, et pas seulement dans les zones de texte classiques ?**

Oui. Vous pouvez formater le texte en exposant ou en indice dans tout objet qui expose un [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) (y compris les cellules de tableau). Le formatage s’applique aux portions de texte à l’intérieur de ce cadre.

**Les exposants/indices seront-ils conservés lors de l’exportation vers PDF, HTML ou images ?**

Oui. Aspose.Slides conserve le formatage exposant/indice lors de l’exportation vers des formats courants comme [PDF](/slides/fr/python-net/convert-powerpoint-to-pdf/), [HTML](/slides/fr/python-net/convert-powerpoint-to-html/) et [images raster](/slides/fr/python-net/convert-powerpoint-to-png/) car le pipeline de rendu respecte le formatage du texte au niveau des portions.

**Puis-je combiner exposant/indice avec des hyperliens dans le même fragment de texte ?**

Oui. Les [Hyperlinks](/slides/fr/python-net/manage-hyperlinks/) sont attribués au niveau de la portion (fragment), de sorte qu’une portion peut simultanément contenir un hyperlien et être formatée en exposant ou en indice.