---
title: Localisation de la Présentation
type: docs
weight: 100
url: /fr/python-net/presentation-localization/
keywords: "Changer la langue, Vérification orthographique, Vérifier l'orthographe, Correcteur orthographique, Présentation PowerPoint, Python, Aspose.Slides pour Python via .NET"
description: "Changer ou vérifier la langue dans une présentation PowerPoint. Vérifier l'orthographe du texte en Python"
---
## **Changer la Langue pour la Présentation et le Texte des Formes**
- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
- Obtenir la référence d'une diapositive en utilisant son Index.
- Ajouter une AutoShape de type Rectangle à la diapositive.
- Ajouter du texte au TextFrame.
- Définir l'ID de langue pour le texte.
- Écrire la présentation en tant que fichier PPTX.

L'implémentation des étapes ci-dessus est démontrée ci-dessous dans un exemple.

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 50)
    shape.add_text_frame("Texte pour appliquer la langue de vérification orthographique")
    shape.text_frame.paragraphs[0].portions[0].portion_format.language_id = "en-EN"

    pres.save("test1.pptx", slides.export.SaveFormat.PPTX)
```