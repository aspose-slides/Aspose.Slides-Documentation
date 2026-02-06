---
title: Encre
type: docs
weight: 180
url: /fr/python-net/examples/elements/ink/
keywords:
- encre
- accès à l'encre
- supprimer l'encre
- exemples de code
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Manipulez l'encre numérique sur les diapositives en Python avec Aspose.Slides : ajoutez des traits de stylo, modifiez les chemins, définissez la couleur et la largeur, et exportez les résultats vers PowerPoint et OpenDocument."
---
Fournit des exemples d'accès aux formes d'encre existantes et de leur suppression à l'aide de **Aspose.Slides for Python via .NET**.

> ❗ **Note :** Les formes d'encre représentent les entrées utilisateur provenant d'appareils spécialisés. Aspose.Slides ne peut pas créer de nouveaux traits d'encre par programme, mais vous pouvez lire et modifier l'encre existante.

## **Accéder à l'encre**

Obtenez la première forme d'encre d'une diapositive.

```py
def access_ink():
    with slides.Presentation("ink.pptx") as presentation:
        slide = presentation.slides[0]

        first_ink = None
        for shape in slide.shapes:
            if isinstance(shape, slides.ink.Ink):
                first_ink = shape
                break
```

## **Supprimer l'encre**

Supprimez une forme d'encre de la diapositive.

```py
def remove_ink():
    with slides.Presentation("ink.pptx") as presentation:
        slide = presentation.slides[0]

        # En supposant que la première forme soit un objet Ink.
        ink = slide.shapes[0]

        slide.shapes.remove(ink)

        presentation.save("ink_removed.pptx", slides.export.SaveFormat.PPTX)
```