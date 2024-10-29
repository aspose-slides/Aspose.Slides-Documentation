---
title: Rectangle
type: docs
weight: 80
url: /fr/python-net/rectangle/
keywords: "Créer un rectangle, forme PowerPoint, présentation PowerPoint, Python, Aspose.Slides pour Python via .NET"
description: "Créer un rectangle dans une présentation PowerPoint en Python"
---


## **Créer un Rectangle Simple**
Comme les sujets précédents, celui-ci concerne également l'ajout d'une forme et cette fois la forme dont nous allons discuter est le Rectangle. Dans ce sujet, nous avons décrit comment les développeurs peuvent ajouter des rectangles simples ou formatés à leurs diapositives en utilisant Aspose.Slides pour Python via .NET. Pour ajouter un rectangle simple à une diapositive sélectionnée de la présentation, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenez la référence d'une diapositive en utilisant son Index.
1. Ajoutez une IAutoShape de type Rectangle en utilisant la méthode AddAutoShape exposée par l'objet IShapes.
1. Écrivez la présentation modifiée en tant que fichier PPTX.

Dans l'exemple ci-dessous, nous avons ajouté un rectangle simple à la première diapositive de la présentation.

```py
import aspose.slides as slides

# Instancier la classe Prseetation qui représente le PPTX
with slides.Presentation() as pres:
    # Obtenez la première diapositive
    sld = pres.slides[0]

    # Ajoutez une autoshape de type rectangle
    sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    #Écrivez le fichier PPTX sur le disque
    pres.save("RectShp1_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Créer un Rectangle Formaté**
Pour ajouter un rectangle formaté à une diapositive, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenez la référence d'une diapositive en utilisant son Index.
1. Ajoutez une IAutoShape de type Rectangle en utilisant la méthode AddAutoShape exposée par l'objet IShapes.
1. Réglez le type de remplissage du Rectangle sur Solide.
1. Réglez la couleur du Rectangle en utilisant la propriété SolidFillColor.Color exposée par l'objet FillFormat associé à l'objet IShape.
1. Réglez la couleur des lignes du Rectangle.
1. Réglez la largeur des lignes du Rectangle.
1. Écrivez la présentation modifiée en tant que fichier PPTX.
   Les étapes ci-dessus sont mises en œuvre dans l'exemple ci-dessous.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instancier la classe Prseetation qui représente le PPTX
with slides.Presentation() as pres:
    # Obtenez la première diapositive
    sld = pres.slides[0]

    # Ajoutez une autoshape de type rectangle
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    # Appliquez un certain formatage à la forme rectangle
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # Appliquez un certain formatage à la ligne du rectangle
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    #Écrivez le fichier PPTX sur le disque
    pres.save("RectShp2_out.pptx", slides.export.SaveFormat.PPTX)
```