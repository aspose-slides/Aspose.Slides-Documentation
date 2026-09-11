---
title: Ajouter des rectangles aux présentations en Python via Java
linktitle: Rectangle
type: docs
weight: 80
url: /fr/python-java/rectangle/
keywords:
- ajouter un rectangle
- créer un rectangle
- forme de rectangle
- rectangle simple
- rectangle formaté
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Améliorez vos présentations PowerPoint en ajoutant des rectangles avec Aspose.Slides pour Python via Java — concevez et modifiez facilement les formes de manière programmatique."
---
## **Aperçu**

Cet article montre comment ajouter des formes de rectangle aux diapositives PowerPoint en utilisant Aspose.Slides. Il couvre la création d'un rectangle simple, la création d'un rectangle formaté et l'enregistrement de la présentation mise à jour au format PPTX.

Vous verrez également comment appliquer un formatage de base aux rectangles, tels qu'une couleur de remplissage unie, la couleur du contour et l'épaisseur du trait. De plus, la FAQ de l'article renvoie aux tâches liées aux rectangles, notamment les coins arrondis, le remplissage d'images, les effets visuels, les hyperliens, les verrous de forme, les options d'exportation et les propriétés effectives.

## **Ajouter un rectangle à une diapositive**

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
- Obtenez une référence à une diapositive par son index.
- Ajoutez une [AutoShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/autoshape/) de type rectangle en utilisant la méthode [addAutoShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapecollection/#addAutoShape) exposée par l'objet [ShapeCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapecollection/).
- Enregistrez la présentation modifiée en fichier PPTX.

Dans l'exemple ci-dessous, nous avons ajouté un rectangle simple à la première diapositive de la présentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Instanciez la classe Presentation qui représente le fichier PPTX.
presentation = Presentation()
try:
    # Obtenez la première diapositive.
    slide = presentation.getSlides().get_Item(0)

    # Ajoutez une forme de rectangle.
    slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50)

    # Enregistrez le fichier PPTX sur le disque.
    presentation.save("RecShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ajouter un rectangle formaté à une diapositive**

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
- Obtenez une référence à une diapositive par son index.
- Ajoutez une [AutoShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/autoshape/) de type rectangle en utilisant la méthode [addAutoShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapecollection/#addAutoShape) exposée par l'objet [ShapeCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapecollection/).
- Définissez le [fill type](https://reference.aspose.com/slides/fr/python-java/aspose.slides/filltype/) du rectangle sur solide.
- Définissez la couleur du rectangle en utilisant la méthode [setColor](https://reference.aspose.com/slides/fr/python-java/aspose.slides/colorformat/#setColor) sur la couleur de remplissage solide de l'objet [FillFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fillformat/) associé à l'objet [Shape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/).
- Définissez la couleur du contour du rectangle.
- Définissez l'épaisseur du contour du rectangle.
- Enregistrez la présentation modifiée en fichier PPTX.

Les étapes ci‑dessus sont implémentées dans l'exemple ci‑bas.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Instanciez la classe Presentation qui représente le fichier PPTX.
presentation = Presentation()
try:
    # Obtenez la première diapositive.
    slide = presentation.getSlides().get_Item(0)

    # Ajoutez une forme de rectangle.
    rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50)

    # Formatez le remplissage du rectangle.
    rectangle.getFillFormat().setFillType(FillType.Solid)
    rectangle.getFillFormat().getSolidFillColor().setColor(Color.GRAY)

    # Formatez le contour du rectangle.
    rectangle.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    rectangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    rectangle.getLineFormat().setWidth(5)

    # Enregistrez le fichier PPTX sur le disque.
    presentation.save("RecShp2.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Comment ajouter un rectangle avec des coins arrondis ?**

Utilisez le [shape type](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapetype/) à coins arrondis et ajustez le rayon des coins dans les propriétés de la forme ; l’arrondissement peut également être appliqué coin par coin via des ajustements géométriques.

**Comment remplir un rectangle avec une image (texture) ?**

Sélectionnez le [fill type](https://reference.aspose.com/slides/fr/python-java/aspose.slides/filltype/) image, fournissez la source de l’image et configurez les [modes d'étirement/tuile](https://reference.aspose.com/slides/fr/python-java/aspose.slides/picturefillmode/).

**Un rectangle peut‑il avoir une ombre et une lueur ?**

Oui. Les [ombres externes/intérieures, la lueur et les bords doux](/slides/fr/python-java/shape-effect/) sont disponibles avec des paramètres réglables.

**Puis‑je transformer un rectangle en bouton avec un hyperlien ?**

Oui. [Attribuez un hyperlien](/slides/fr/python-java/manage-hyperlinks/) au clic sur la forme (aller à une diapositive, un fichier, une adresse web ou un e‑mail).

**Comment protéger un rectangle contre les déplacements et les modifications ?**

[Utilisez les verrous de forme](/slides/fr/python-java/applying-protection-to-presentation/) : vous pouvez interdire le déplacement, le redimensionnement, la sélection ou la modification du texte afin de préserver la mise en page.

**Puis‑je convertir un rectangle en image raster ou SVG ?**

Oui. Vous pouvez [rendre la forme](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#getImage) en image avec une taille/échelle spécifiée ou [l’exporter en SVG](/slides/fr/python-java/create-shape-thumbnails/) pour une utilisation vectorielle.

**Comment obtenir rapidement les propriétés réelles (effectives) d'un rectangle en tenant compte du thème et de l'héritage ?**

[Utilisez les propriétés effectives de la forme](/slides/fr/python-java/shape-effective-properties/) : l’API renvoie des valeurs calculées qui tiennent compte des styles du thème, de la disposition et des paramètres locaux, simplifiant l’analyse du formatage.