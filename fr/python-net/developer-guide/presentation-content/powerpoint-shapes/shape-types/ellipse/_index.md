---
title: Ajouter des ellipses aux présentations en Python
linktitle: Ellipse
type: docs
weight: 30
url: /fr/python-net/ellipse/
keywords:
- ellipse
- forme
- ajouter ellipse
- créer ellipse
- dessiner ellipse
- ellipse formatée
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Apprenez à créer, formater et manipuler des formes d'ellipse dans Aspose.Slides pour Python via .NET pour les présentations PPT, PPTX et ODP — exemples de code inclus."
---

## **Créer une ellipse**
Dans ce sujet, nous présenterons aux développeurs comment ajouter des formes d'ellipse à leurs diapositives en utilisant Aspose.Slides pour Python via .NET. Aspose.Slides pour Python via .NET fournit un ensemble d'API plus simple pour dessiner différents types de formes en quelques lignes de code seulement. Pour ajouter une ellipse simple à une diapositive sélectionnée de la présentation, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)
2. Obtenez la référence d'une diapositive en utilisant son Index
3. Ajoutez une AutoShape de type Ellipse en utilisant la méthode AddAutoShape exposée par l'objet IShapes
4. Enregistrez la présentation modifiée sous forme de fichier PPTX

Dans l'exemple ci‑dessous, nous avons ajouté une ellipse à la première diapositive.
```py
import aspose.slides as slides

# Instancier la classe Presentation qui représente le PPTX
with slides.Presentation() as pres:
    # Obtenir la première diapositive
    sld = pres.slides[0]

    # Ajouter une autoshape de type ellipse
    sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 150, 50)

    #Écrire le fichier PPTX sur le disque
    pres.save("EllipseShp1_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Créer une ellipse formatée**
Pour ajouter une ellipse mieux formatée à une diapositive, veuillez suivre les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)
2. Obtenez la référence d'une diapositive en utilisant son Index.
3. Ajoutez une AutoShape de type Ellipse en utilisant la méthode AddAutoShape exposée par l'objet IShapes.
4. Définissez le type de remplissage de l'ellipse sur Solid.
5. Définissez la couleur de l'ellipse en utilisant la propriété SolidFillColor.Color exposée par l'objet FillFormat associé à l'objet IShape.
6. Définissez la couleur des lignes de l'ellipse.
7. Définissez la largeur des lignes de l'ellipse.
8. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Dans l'exemple ci‑dessus, nous avons ajouté une ellipse formatée à la première diapositive de la présentation.
```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instancier la classe Presentation qui représente le PPTX
with slides.Presentation() as pres:
    # Obtenir la première diapositive
    sld = pres.slides[0]

    # Ajouter une autoshape de type ellipse
    shp = sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 150, 50)

    # Appliquer un certain format à la forme ellipse
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # Appliquer un certain format à la ligne de l'ellipse
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    #Écrire le fichier PPTX sur le disque
    pres.save("EllipseShp2_out.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Comment définir la position exacte et la taille d'une ellipse par rapport aux unités de la diapositive ?**

Les coordonnées et les tailles sont généralement spécifiées **en points**. Pour obtenir des résultats prévisibles, basez vos calculs sur la taille de la diapositive et convertissez les millimètres ou pouces requis en points avant d'attribuer les valeurs.

**Comment placer une ellipse au-dessus ou en dessous d'autres objets (contrôler l'ordre d'empilement) ?**

Ajustez l'ordre de dessin de l'objet en le plaçant au premier plan ou en l'envoyant à l'arrière. Cela permet à l'ellipse de chevaucher d'autres objets ou de révéler ceux qui se trouvent en dessous.

**Comment animer l'apparition ou l'emphase d'une ellipse ?**

[Apply](/slides/fr/python-net/shape-animation/) des effets d'entrée, d'emphase ou de sortie à la forme, et configurez les déclencheurs et le timing pour orchestrer quand et comment l'animation se lance.