---
title: Groupe
type: docs
weight: 40
url: /python-net/group/
keywords: "Groupe forme, forme PowerPoint, présentation PowerPoint, Python, Aspose.Slides pour Python via .NET"
description: "Ajouter une forme de groupe à une présentation PowerPoint en Python"
---

## **Ajouter une forme de groupe**
Aspose.Slides prend en charge le travail avec des formes de groupe sur les diapositives. Cette fonctionnalité aide les développeurs à prendre en charge des présentations plus riches. Aspose.Slides pour Python via .NET prend en charge l'ajout ou l'accès à des formes de groupe. Il est possible d'ajouter des formes à une forme de groupe ajoutée pour la remplir ou accéder à toute propriété de la forme de groupe. Pour ajouter une forme de groupe à une diapositive à l'aide d'Aspose.Slides pour Python via .NET :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenez la référence d'une diapositive en utilisant son index.
1. Ajoutez une forme de groupe à la diapositive.
1. Ajoutez les formes à la forme de groupe ajoutée.
1. Enregistrez la présentation modifiée sous forme de fichier PPTX.

L'exemple ci-dessous ajoute une forme de groupe à une diapositive.

```py
import aspose.slides as slides

# Instancier la classe Presentation 
with slides.Presentation() as pres:
    # Obtenir la première diapositive 
    sld = pres.slides[0]

    # Accéder à la collection de formes de diapositives 
    slideShapes = sld.shapes

    # Ajouter une forme de groupe à la diapositive 
    groupShape = slideShapes.add_group_shape()

    # Ajouter des formes à l'intérieur de la forme de groupe ajoutée 
    groupShape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 100, 100, 100)
    groupShape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 100, 100)
    groupShape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 300, 100, 100)
    groupShape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 300, 100, 100)

    # Ajouter un cadre à la forme de groupe 
    groupShape.frame = slides.ShapeFrame(100, 300, 500, 40, -1, -1, 0)

    # Écrire le fichier PPTX sur le disque 
    pres.save("GroupShape_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Accéder à la propriété AltText**
Ce sujet montre des étapes simples, complètes avec des exemples de code, pour ajouter une forme de groupe et accéder à la propriété AltText des formes de groupe sur les diapositives. Pour accéder à l'AltText d'une forme de groupe dans une diapositive à l'aide d'Aspose.Slides pour Python via .NET :

1. Instancier la classe `Presentation` qui représente le fichier PPTX.
1. Obtenir la référence d'une diapositive en utilisant son index.
1. Accéder à la collection de formes de diapositives.
1. Accéder à la forme de groupe.
1. Accéder à la propriété AltText.

L'exemple ci-dessous accède au texte alternatif de la forme de groupe.

```py
import aspose.slides as slides

# Instancier la classe Presentation qui représente le fichier PPTX
with slides.Presentation(path + "AltText.pptx") as pres:

    # Obtenir la première diapositive
    sld = pres.slides[0]

    for i in range(len(sld.shapes)):
        # Accéder à la collection de formes de diapositives
        shape = sld.shapes[i]

        if type(shape) is slides.GroupShape:
            # Accéder à la forme de groupe.
            for j in range(len(shape.shapes)):
                # Accéder à la propriété AltText
                print(shape.shapes[j].alternative_text)
```