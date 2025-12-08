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
description: "Améliorez vos présentations PowerPoint et OpenDocument en ajoutant des rectangles avec Aspose.Slides for Python via .NET--concevez et modifiez facilement des formes par programmation."
---

## **Créer un rectangle simple**
Comme les sujets précédents, celui‑ci porte également sur l’ajout d’une forme et, cette fois, la forme dont nous allons parler est le Rectangle. Dans ce sujet, nous avons décrit comment les développeurs peuvent ajouter des rectangles simples ou formatés à leurs diapositives en utilisant Aspose.Slides for Python via .NET. Pour ajouter un rectangle simple à une diapositive sélectionnée de la présentation, veuillez suivre les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenez la référence d’une diapositive en utilisant son Index.
3. Ajoutez un IAutoShape de type Rectangle en utilisant la méthode AddAutoShape exposée par l’objet IShapes.
4. Enregistrez la présentation modifiée en tant que fichier PPTX.

Dans l’exemple ci‑dessous, nous avons ajouté un rectangle simple à la première diapositive de la présentation.
```py
import aspose.slides as slides

# Instancier la classe Presentation qui représente le PPTX
with slides.Presentation() as pres:
    # Obtenir la première diapositive
    sld = pres.slides[0]

    # Ajouter une forme auto de type rectangle
    sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    #Écrire le fichier PPTX sur le disque
    pres.save("RectShp1_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Créer un rectangle formaté**
Pour ajouter un rectangle formaté à une diapositive, veuillez suivre les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenez la référence d’une diapositive en utilisant son Index.
3. Ajoutez un IAutoShape de type Rectangle en utilisant la méthode AddAutoShape exposée par l’objet IShapes.
4. Définissez le type de remplissage du Rectangle sur Solid.
5. Définissez la couleur du Rectangle en utilisant la propriété SolidFillColor.Color exposée par l’objet FillFormat associé à l’objet IShape.
6. Définissez la couleur des lignes du Rectangle.
7. Définissez la largeur des lignes du Rectangle.
8. Enregistrez la présentation modifiée en tant que fichier PPTX.

Les étapes ci‑dessus sont implémentées dans l’exemple ci‑dessous.
```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instancier la classe Presentation qui représente le PPTX
with slides.Presentation() as pres:
    # Obtenir la première diapositive
    sld = pres.slides[0]

    # Ajouter une forme auto de type rectangle
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    # Appliquer un formatage à la forme rectangle
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # Appliquer un formatage à la ligne du rectangle
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    #Écrire le fichier PPTX sur le disque
    pres.save("RectShp2_out.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Comment ajouter un rectangle avec des coins arrondis ?**

Utilisez le [type de forme](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/) à coins arrondis et ajustez le rayon des coins dans les propriétés de la forme ; l’arrondissement peut également être appliqué coin par coin via des ajustements de géométrie.

**Comment remplir un rectangle avec une image (texture) ?**

Sélectionnez le [type de remplissage d’image](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/), fournissez la source de l’image, et configurez les [modes d’étirement/tuile](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/).

**Un rectangle peut‑il avoir une ombre et une lueur ?**

Oui. Les [ombres externes/intérieures, la lueur et les bords doux](/slides/fr/python-net/shape-effect/) sont disponibles avec des paramètres réglables.

**Puis‑je transformer un rectangle en bouton avec un hyperlien ?**

Oui. [Attribuez un hyperlien](/slides/fr/python-net/manage-hyperlinks/) au clic de la forme (vers une diapositive, un fichier, une adresse web ou un e‑mail).

**Comment protéger un rectangle contre le déplacement et les modifications ?**

[Utilisez les verrous de forme](/slides/fr/python-net/applying-protection-to-presentation/) : vous pouvez interdire le déplacement, le redimensionnement, la sélection ou la modification du texte afin de préserver la mise en page.

**Puis‑je convertir un rectangle en image matricielle ou en SVG ?**

Oui. Vous pouvez [rendre la forme](http://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) en image avec une taille/échelle spécifiée ou [l’exporter en SVG](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/) pour une utilisation vectorielle.

**Comment obtenir rapidement les propriétés réelles (effectives) d’un rectangle en tenant compte du thème et de l’héritage ?**

[Utilisez les propriétés effectives de la forme](/slides/fr/python-net/shape-effective-properties/) : l’API renvoie les valeurs calculées qui tiennent compte des styles du thème, de la disposition et des paramètres locaux, simplifiant l’analyse du formatage.