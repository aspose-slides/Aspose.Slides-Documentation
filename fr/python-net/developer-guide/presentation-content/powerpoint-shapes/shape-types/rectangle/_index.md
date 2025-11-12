---
title: Ajouter des rectangles aux présentations en Python
linktitle: Rectangle
type: docs
weight: 80
url: /fr/python-net/rectangle/
keywords:
- ajouter rectangle
- créer rectangle
- forme rectangle
- rectangle simple
- rectangle formaté
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Améliorez vos présentations PowerPoint & OpenDocument en ajoutant des rectangles avec Aspose.Slides pour Python via .NET—conception et modification faciles des formes par programme."
---

## **Créer un rectangle simple**
Comme dans les sujets précédents, celui-ci porte également sur l'ajout d'une forme et cette fois la forme que nous allons aborder est le Rectangle. Dans ce sujet, nous avons décrit comment les développeurs peuvent ajouter des rectangles simples ou formatés à leurs diapositives en utilisant Aspose.Slides pour Python via .NET. Pour ajouter un rectangle simple à une diapositive sélectionnée de la présentation, suivez les étapes ci‑dessous :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. Obtenir la référence d'une diapositive en utilisant son index.
3. Ajouter une IAutoShape de type Rectangle en utilisant la méthode AddAutoShape exposée par l'objet IShapes.
4. Enregistrer la présentation modifiée en tant que fichier PPTX.

```py
import aspose.slides as slides

# Instancier la classe Presentation qui représente le PPTX
with slides.Presentation() as pres:
    # Obtenir la première diapositive
    sld = pres.slides[0]

    # Ajouter une autoshape de type rectangle
    sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    # Enregistrer le fichier PPTX sur le disque
    pres.save("RectShp1_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Créer un rectangle formaté**
Pour ajouter un rectangle formaté à une diapositive, suivez les étapes ci‑dessous :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. Obtenir la référence d'une diapositive en utilisant son index.
3. Ajouter une IAutoShape de type Rectangle en utilisant la méthode AddAutoShape exposée par l'objet IShapes.
4. Définir le type de remplissage du Rectangle sur Solid.
5. Définir la couleur du Rectangle en utilisant la propriété SolidFillColor.Color exposée par l'objet FillFormat associé à l'objet IShape.
6. Définir la couleur des lignes du Rectangle.
7. Définir la largeur des lignes du Rectangle.
8. Enregistrer la présentation modifiée en tant que fichier PPTX.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instancier la classe Presentation qui représente le PPTX
with slides.Presentation() as pres:
    # Obtenir la première diapositive
    sld = pres.slides[0]

    # Ajouter une autoshape de type rectangle
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    # Appliquer un certain format à la forme rectangle
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # Appliquer un certain format à la ligne du rectangle
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    # Enregistrer le fichier PPTX sur le disque
    pres.save("RectShp2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Comment ajouter un rectangle avec des coins arrondis ?**  
Utilisez le type de forme à coins arrondis [shape type](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/) et ajustez le rayon des coins dans les propriétés de la forme ; le arrondi peut également être appliqué par coin via des ajustements de géométrie.

**Comment remplir un rectangle avec une image (texture) ?**  
Sélectionnez le type de remplissage d'image [fill type](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/), fournissez la source de l'image et configurez les modes d'étirement/tuile [stretching/tiling modes](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/).

**Un rectangle peut‑il avoir une ombre et un éclat ?**  
Oui. [Outer/inner shadow, glow, and soft edges](/slides/fr/python-net/shape-effect/) sont disponibles avec des paramètres réglables.

**Puis‑je transformer un rectangle en bouton avec un hyperlien ?**  
Oui. [Assign a hyperlink](/slides/fr/python-net/manage-hyperlinks/) à la forme lors du clic (aller à une diapositive, fichier, adresse web ou e‑mail).

**Comment protéger un rectangle contre le déplacement et les modifications ?**  
[Use shape locks](/slides/fr/python-net/applying-protection-to-presentation/) : vous pouvez interdire le déplacement, le redimensionnement, la sélection ou l'édition du texte pour préserver la mise en page.

**Puis‑je convertir un rectangle en image matricielle ou SVG ?**  
Oui. Vous pouvez [render the shape](http://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) en image avec une taille/échelle spécifiée ou [export it as SVG](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/) pour une utilisation vectorielle.

**Comment obtenir rapidement les propriétés réelles (effectives) d'un rectangle en tenant compte du thème et de l'héritage ?**  
[Use the shape’s effective properties](/slides/fr/python-net/shape-effective-properties/) : l'API renvoie les valeurs calculées qui tiennent compte des styles de thème, de la mise en page et des paramètres locaux, simplifiant l'analyse du formatage.