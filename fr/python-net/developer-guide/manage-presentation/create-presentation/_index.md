---
title: Créer une Présentation
type: docs
weight: 10
url: /python-net/create-presentation/
keywords: "Créer PowerPoint, PPTX, PPT, Créer Présentation, Initialiser Présentation, Python, .NET"
description: "Ouvrir une Présentation PowerPoint en Python"
---

## **Créer une Présentation PowerPoint**
Pour ajouter une simple ligne droite à une diapositive sélectionnée de la présentation, veuillez suivre les étapes ci-dessous :

1. Créer une instance de la classe Presentation.
1. Obtenir la référence d'une diapositive en utilisant son Index.
1. Ajouter une AutoShape de type `LINE` en utilisant la méthode `add_auto_shape` exposée par l'objet `shapes`.
1. Écrire la présentation modifiée en tant que fichier PPTX.

Dans l'exemple donné ci-dessous, nous avons ajouté une ligne à la première diapositive de la présentation.

```py
import aspose.slides as slides

# Instancier un objet Presentation qui représente un fichier de présentation
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)
    presentation.save("NewPresentation_out.pptx", slides.export.SaveFormat.PPTX)
```