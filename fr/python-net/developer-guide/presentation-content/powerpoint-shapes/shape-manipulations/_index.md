---
title: Gérer les formes dans les présentations avec Python
linktitle: Manipulation des formes
type: docs
weight: 40
url: /fr/python-net/shape-manipulations/
keywords:
- forme PowerPoint
- forme de présentation
- forme sur la diapositive
- trouver une forme
- cloner une forme
- supprimer une forme
- masquer une forme
- changer l’ordre des formes
- obtenir l’identifiant interop de la forme
- texte alternatif de la forme
- formats de disposition des formes
- forme en SVG
- convertir une forme en SVG
- aligner une forme
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Apprenez à créer, modifier et optimiser des formes dans Aspose.Slides for Python via .NET et à produire des présentations PowerPoint et OpenDocument performantes."
---

## **Trouver une Forme dans la Diapositive**
Ce sujet décrira une technique simple pour faciliter aux développeurs la recherche d'une forme spécifique sur une diapositive sans utiliser son Id interne. Il est important de savoir que les fichiers de présentation PowerPoint n'ont aucun moyen d'identifier les formes sur une diapositive, sauf un Id unique interne. Il semble difficile pour les développeurs de trouver une forme en utilisant son Id unique interne. Toutes les formes ajoutées aux diapositives ont un texte alternatif. Nous suggérons aux développeurs d'utiliser du texte alternatif pour trouver une forme spécifique. Vous pouvez utiliser MS PowerPoint pour définir le texte alternatif pour les objets que vous prévoyez de modifier à l'avenir.

Après avoir défini le texte alternatif de la forme souhaitée, vous pouvez ensuite ouvrir cette présentation en utilisant Aspose.Slides pour Python via .NET et parcourir toutes les formes ajoutées à une diapositive. Lors de chaque itération, vous pouvez vérifier le texte alternatif de la forme et la forme avec le texte alternatif correspondant serait celle requise par vous. Pour démontrer cette technique de manière plus efficace, nous avons créé une méthode, [FindShape](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/) qui effectue la recherche d'une forme spécifique dans une diapositive et retourne simplement cette forme.

```py
import aspose.slides as slides

# Implémentation de la méthode pour trouver une forme dans une diapositive en utilisant son texte alternatif
def find_shape(slide, alttext):
    for i in range(len(slide.shapes)):
        if slide.shapes[i].alternative_text == alttext:
            return slide.shapes[i]
    return None
    
# Instanciez une classe Presentation qui représente le fichier de présentation
with slides.Presentation(path + "FindingShapeInSlide.pptx") as p:
    slide = p.slides[0]
    # Texte alternatif de la forme à trouver
    shape = find_shape(slide, "Shape1")
    if shape != None:
        print("Nom de la Forme: " + shape.name)
```



## **Cloner une Forme**
Pour cloner une forme sur une diapositive en utilisant Aspose.Slides pour Python via .NET :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenez la référence d'une diapositive en utilisant son index.
1. Accédez à la collection de formes de la diapositive source.
1. Ajoutez une nouvelle diapositive à la présentation.
1. Clonez les formes de la collection de formes de la diapositive source vers la nouvelle diapositive.
1. Enregistrez la présentation modifiée en tant que fichier PPTX.

L'exemple ci-dessous ajoute une forme de groupe à une diapositive.

```py
import aspose.slides as slides

# Instanciez la classe Presentation
with slides.Presentation(path + "Source Frame.pptx") as srcPres:
	sourceShapes = srcPres.slides[0].shapes
	blankLayout = srcPres.masters[0].layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
	destSlide = srcPres.slides.add_empty_slide(blankLayout)
	destShapes = destSlide.shapes
	destShapes.add_clone(sourceShapes[1], 50, 150 + sourceShapes[0].height)
	destShapes.add_clone(sourceShapes[2])                 
	destShapes.insert_clone(0, sourceShapes[0], 50, 150)

	# Écrivez le fichier PPTX sur le disque
	srcPres.save("CloneShape_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Supprimer une Forme**
Aspose.Slides pour Python via .NET permet aux développeurs de supprimer n'importe quelle forme. Pour supprimer la forme de n'importe quelle diapositive, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe `Presentation`.
1. Accédez à la première diapositive.
1. Trouvez la forme avec un AlternativeText spécifique.
1. Supprimez la forme.
1. Enregistrez le fichier sur le disque.

```py
import aspose.slides as slides

# Créez un objet Presentation
with slides.Presentation() as pres:
    # Obtenez la première diapositive
    sld = pres.slides[0]

    # Ajoutez une autoshape de type rectangle
    shp1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 40, 150, 50)
    shp2 = sld.shapes.add_auto_shape(slides.ShapeType.MOON, 160, 40, 150, 50)
    alttext = "Utilisateur Défini"
    for i in range(len(sld.shapes)):
        ashp = sld.shapes[0]
        if ashp.alternative_text == alttext:
            sld.shapes.remove(ashp)

    # Enregistrez la présentation sur le disque
    pres.save("RemoveShape_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Cacher une Forme**
Aspose.Slides pour Python via .NET permet aux développeurs de cacher n'importe quelle forme. Pour cacher la forme de n'importe quelle diapositive, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe `Presentation`.
1. Accédez à la première diapositive.
1. Trouvez la forme avec un AlternativeText spécifique.
1. Cacher la forme.
1. Enregistrez le fichier sur le disque.

```py
import aspose.slides as slides

# Instanciez la classe Presentation qui représente le PPTX
with slides.Presentation() as pres:
    # Obtenez la première diapositive
    sld = pres.slides[0]

    # Ajoutez une autoshape de type rectangle
    shp1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 40, 150, 50)
    shp2 = sld.shapes.add_auto_shape(slides.ShapeType.MOON, 160, 40, 150, 50)
    alttext = "Utilisateur Défini"
    for i in range(len(sld.shapes)):
        ashp = sld.shapes[i]
        if ashp.alternative_text == alttext:
            ashp.hidden = True

    # Enregistrez la présentation sur le disque
    pres.save("Hiding_Shapes_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Changer l'Ordre des Formes**
Aspose.Slides pour Python via .NET permet aux développeurs de réorganiser les formes. Réorganiser la forme spécifie quelle forme est devant ou quelle forme est derrière. Pour réorganiser la forme de n'importe quelle diapositive, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe `Presentation`.
1. Accédez à la première diapositive.
1. Ajoutez une forme.
1. Ajoutez du texte dans le cadre de texte de la forme.
1. Ajoutez une autre forme avec les mêmes coordonnées.
1. Réorganisez les formes.
1. Enregistrez le fichier sur le disque.

```py
import aspose.slides as slides

with slides.Presentation(path + "HelloWorld.pptx") as presentation1:
    slide = presentation1.slides[0]
    shp3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 365, 400, 150)
    shp3.fill_format.fill_type = slides.FillType.NO_FILL
    shp3.add_text_frame(" ")

    txtFrame = shp3.text_frame
    para = txtFrame.paragraphs[0]
    portion = para.portions[0]
    portion.text="Texte de Filigrane Texte de Filigrane Texte de Filigrane"
    shp3 = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 200, 365, 400, 150)
    slide.shapes.reorder(2, shp3)
    presentation1.save("Reshape_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Obtenir l'ID de Forme Interop**
Aspose.Slides pour Python via .NET permet aux développeurs d'obtenir un identifiant unique de forme dans le scope de la diapositive par opposition à la propriété UniqueId, qui permet d'obtenir un identifiant unique dans le scope de la présentation. La propriété OfficeInteropShapeId a été ajoutée aux interfaces IShape et à la classe Shape respectivement. La valeur retournée par la propriété OfficeInteropShapeId correspond à la valeur de l'Id de l'objet Microsoft.Office.Interop.PowerPoint.Shape. Ci-dessous un exemple de code est donné.

```py
import aspose.slides as slides

with slides.Presentation(path + "Presentation.pptx") as presentation:
    # Obtention de l'identifiant unique de forme dans le scope de la diapositive
    officeInteropShapeId = presentation.slides[0].shapes[0].office_interop_shape_id
```



## **Définir le Texte Alternatif pour une Forme**
Aspose.Slides pour Python via .NET permet aux développeurs de définir l'AlternateText de n'importe quelle forme. 
Les formes dans une présentation peuvent être distinguées par le texte alternatif ou la propriété Nom de Forme. 
La propriété AlternativeText peut être lue ou définie en utilisant Aspose.Slides ainsi que Microsoft PowerPoint. 
En utilisant cette propriété, vous pouvez taguer une forme et effectuer différentes opérations telles que la suppression d'une forme, 
le masquage d'une forme ou la réorganisation des formes sur une diapositive.
Pour définir l'AlternateText d'une forme, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe `Presentation`.
1. Accédez à la première diapositive.
1. Ajoutez n'importe quelle forme à la diapositive.
1. Faites un certain travail avec la forme nouvellement ajoutée.
1. Parcourez les formes pour trouver une forme.
1. Définissez le Texte Alternatif.
1. Enregistrez le fichier sur le disque.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanciez la classe Presentation qui représente le PPTX
with slides.Presentation() as pres:
    # Obtenez la première diapositive
    sld = pres.slides[0]

    # Ajoutez une autoshape de type rectangle
    shp1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 40, 150, 50)
    shp2 = sld.shapes.add_auto_shape(slides.ShapeType.MOON, 160, 40, 150, 50)
    shp2.fill_format.fill_type = slides.FillType.SOLID
    shp2.fill_format.solid_fill_color.color = draw.Color.gray

    for i in range(len(sld.shapes)):
        shape = sld.shapes[i]
        if shape != None:
            shape.alternative_text = "Utilisateur Défini"

    # Enregistrez la présentation sur le disque
    pres.save("Set_AlternativeText_out.pptx", slides.export.SaveFormat.PPTX)
```




## **Accéder aux Formats de Mise en Page pour une Forme**
Aspose.Slides pour Python via .NET fournit une API simple pour accéder aux formats de mise en page pour une forme. Cet article montre comment vous pouvez accéder aux formats de mise en page.

Le code d'exemple ci-dessous est donné.

```py
import aspose.slides as slides

with slides.Presentation("Set_AlternativeText_out.pptx") as pres:
    for layoutSlide in pres.layout_slides:
        fillFormats = list(map(lambda shape: shape.fill_format, layoutSlide.shapes))
        lineFormats = list(map(lambda shape: shape.line_format, layoutSlide.shapes))
```

## **Rendre une Forme en tant que SVG**
Maintenant, Aspose.Slides pour Python via .NET supporte le rendu d'une forme en tant que SVG. La méthode WriteAsSvg (et ses surcharges) a été ajoutée à la classe Shape et à l'interface IShape. Cette méthode permet de sauvegarder le contenu de la forme en tant que fichier SVG. L'extrait de code ci-dessous montre comment exporter la forme d'une diapositive vers un fichier SVG.

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    with open("SingleShape.svg", "wb") as stream:
        pres.slides[0].shapes[0].write_as_svg(stream)
```

## Aligner une Forme

Grâce à la méthode surchargée [SlidesUtil.AlignShape()](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/), vous pouvez 

* aligner les formes par rapport aux marges d'une diapositive. Voir Exemple 1. 
* aligner les formes les unes par rapport aux autres. Voir Exemple 2. 

L'énumération [ShapesAlignmentType](https://reference.aspose.com/slides/python-net/aspose.slides/shapesalignmenttype/) définit les options d'alignement disponibles.

### Exemple 1

Ce code Python vous montre comment aligner les formes avec les indices 1, 2 et 4 le long de la bordure supérieure d'une diapositive :
Le code source ci-dessous aligne les formes avec les indices 1, 2 et 4 le long de la bordure supérieure de la diapositive. 

```py
import aspose.slides as slides

with slides.Presentation("OutputPresentation.pptx") as pres:
     slide = pres.slides[0]
     shape1 = slide.shapes[1]
     shape2 = slide.shapes[2]
     shape3 = slide.shapes[4]
     slides.util.SlideUtil.align_shapes(slides.ShapesAlignmentType.ALIGN_TOP, True, pres.slides[0], [
            slide.shapes.index_of(shape1),
            slide.shapes.index_of(shape2),
            slide.shapes.index_of(shape3)])
```

### Exemple 2

Ce code Python vous montre comment aligner toute une collection de formes par rapport à la forme inférieure dans la collection :

```py
import aspose.slides as slides

with slides.Presentation("example.pptx") as pres:
    slides.util.SlideUtil.align_shapes(slides.ShapesAlignmentType.ALIGN_BOTTOM, False, pres.slides[0].shapes)
```