---
title: Gérer les formes dans les présentations avec Python
linktitle: Manipulation des formes
type: docs
weight: 40
url: /fr/python-net/shape-manipulations/
keywords:
- forme PowerPoint
- forme de présentation
- forme sur diapositive
- trouver une forme
- cloner une forme
- supprimer une forme
- masquer une forme
- modifier l'ordre des formes
- obtenir l'ID Interop de la forme
- texte alternatif de forme
- formats de mise en page de forme
- forme en SVG
- forme vers SVG
- aligner une forme
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Apprenez à créer, modifier et optimiser les formes dans Aspose.Slides pour Python via .NET et à livrer des présentations PowerPoint et OpenDocument haute performance."
---

## **Vue d'ensemble**

Ce guide présente la manipulation des formes dans Aspose.Slides pour Python via .NET. Apprenez des modèles pratiques pour trouver des formes (y compris par texte alternatif), dupliquer, supprimer ou masquer, réorganiser, aligner et retourner, lire les ID et le formatage basé sur la mise en page, et exporter des formes individuelles en SVG à l'aide des API [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) et [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/).

## **Trouver des formes sur les diapositives**

PowerPoint identifie les formes uniquement par des ID internes. Assignez un texte alternatif unique à la forme cible dans PowerPoint, puis ouvrez la présentation avec Aspose.Slides pour Python, parcourez les formes de la diapositive et sélectionnez celle dont le texte alternatif correspond. La méthode `find_shape` implémente cette approche et renvoie la forme correspondante.
```py
import aspose.slides as slides

# Trouve une forme sur une diapositive par son texte alternatif.
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


    # Instancie la classe Presentation qui représente un fichier de présentation.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Trouve la forme avec le texte alternatif "Shape1".
    shape = find_shape(slide, "Shape1")
    if shape is not None:
        print("Shape name:", shape.name)
```


## **Cloner des formes**

Pour cloner des formes d’une diapositive source vers une nouvelle diapositive dans Aspose.Slides, suivez ces étapes :

1. Créez une [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) à partir du fichier source.
1. Obtenez la diapositive source par indice et sa collection de formes.
1. Récupérez une mise en page vierge depuis la diapositive maître.
1. Ajoutez une diapositive vide en utilisant cette mise en page et obtenez ses formes.
1. Clonez les formes dans la diapositive cible.
1. Enregistrez la présentation au format PPTX.

L’exemple de code suivant clone les formes d’une diapositive à une autre.
```py
import aspose.slides as slides

# Instancie la classe Presentation.
with slides.Presentation("sample.pptx") as presentation:
    source_shapes = presentation.slides[0].shapes
    blank_layout = presentation.masters[0].layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    target_slide = presentation.slides.add_empty_slide(blank_layout)
    target_shapes = target_slide.shapes
	
    target_shapes.add_clone(source_shapes[1], 50, 150 + source_shapes[0].height)
    target_shapes.add_clone(source_shapes[2])
    target_shapes.insert_clone(0, source_shapes[0], 50, 150)

    # Enregistre la présentation sur le disque.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Supprimer des formes**

Aspose.Slides vous permet de supprimer n’importe quelle forme d’une diapositive. Par exemple, pour supprimer une forme de la première diapositive par son texte alternatif, suivez ces étapes :

1. Créez une instance de [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) et chargez le fichier.
1. Accédez à la première diapositive de la collection de diapositives.
1. Trouvez la forme par la valeur du texte alternatif.
1. Retirez la forme de la collection de formes de la diapositive.
1. Enregistrez la présentation sur disque au format PPTX.
```py
import aspose.slides as slides

# Trouve une forme sur une diapositive par son texte alternatif.
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# Instancie la classe Presentation qui représente un fichier de présentation.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Trouve la forme avec le texte alternatif "User Defined".
    shape = find_shape(slide, "User Defined")
    # Supprime la forme.
    slide.shapes.remove(shape)
    # Enregistre la présentation sur le disque.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Masquer des formes**

Aspose.Slides vous permet de masquer n’importe quelle forme sur une diapositive. Par exemple, pour masquer une forme de la première diapositive par son texte alternatif, suivez ces étapes :

1. Créez une instance de [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) et chargez le fichier.
1. Accédez à la première diapositive de la collection de diapositives.
1. Trouvez la forme par la valeur du texte alternatif.
1. Masquez la forme.
1. Enregistrez la présentation sur disque au format PPTX.
```py
# Trouve une forme sur une diapositive par son texte alternatif.
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# Instancie la classe Presentation qui représente un fichier de présentation.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Trouve la forme avec le texte alternatif "User Defined".
    shape = find_shape(slide, "User Defined")
    # Masque la forme.
    shape.hidden = True
    # Enregistre la présentation sur le disque.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Modifier l’ordre des formes**

Aspose.Slides permet aux développeurs de réorganiser les formes (modifier leur z‑order). Le réordonnancement détermine quelle forme apparaît au premier plan ou en arrière‑plan. Par exemple, pour réorganiser deux formes sur la première diapositive, suivez les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Accédez à la première diapositive.
1. Ajoutez la première forme (par exemple, un rectangle).
1. Ajoutez la seconde forme (par exemple, un triangle).
1. Réorganisez les formes en déplaçant la seconde forme à la première position de la collection.
1. Enregistrez la présentation sur disque.
```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Ajoute deux formes à la diapositive.
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 150)
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 20, 200, 200, 150)
    # Déplace la deuxième forme à la première position.
    slide.shapes.reorder(0, shape2)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Obtenir l’ID Interop de la forme**

Aspose.Slides vous permet d’obtenir l’identifiant unique d’une forme au niveau de la diapositive, contrairement à la propriété `unique_id`, qui est unique sur l’ensemble de la présentation. La propriété `office_interop_shape_id` est disponible sur la classe [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/). Sa valeur correspond à l’`Id` de l’objet `Microsoft.Office.Interop.PowerPoint.Shape`. Un extrait de code d’exemple est présenté ci‑dessous.
```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # Obtenir l'identifiant unique de la forme dans la diapositive.
    officeInteropShapeId = presentation.slides[0].shapes[0].office_interop_shape_id
```


## **Définir le texte alternatif des formes**

Aspose.Slides permet aux développeurs de définir le texte alternatif pour n’importe quelle forme. Vous pouvez utiliser le texte alternatif pour identifier et localiser les formes dans une présentation. La propriété de texte alternatif peut être lue et écrite à la fois via Aspose.Slides et Microsoft PowerPoint. En balisant les formes avec cette propriété, vous pourrez ensuite les supprimer, les masquer ou les réorganiser sur une diapositive.

Pour définir le texte alternatif d’une forme, suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Accédez à la première diapositive.
1. Ajoutez une forme à la diapositive.
1. Définissez le texte alternatif.
1. Enregistrez la présentation sur disque.
```py
import aspose.slides as slides

# Instancie la classe Presentation qui représente un fichier PPTX.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    # Ajoute une forme.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 40, 150, 50)
    # Définit le texte alternatif de la forme.
    shape.alternative_text = "User Defined"
    # Enregistre la présentation sur le disque.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Accéder aux formats de mise en page des formes**

Aspose.Slides fournit une API simple pour accéder aux formats de mise en page des formes. Cette section montre comment accéder aux formats de mise en page.
```py
import aspose.slides as slides

with slides.Presentation(folder_path + "sample.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        fill_formats = list(map(lambda shape: shape.fill_format, layout_slide.shapes))
        line_formats = list(map(lambda shape: shape.line_format, layout_slide.shapes))
```


## **Rendre les formes en SVG**

Aspose.Slides prend en charge le rendu des formes en SVG. La méthode `write_as_svg` (et ses surcharges) sur la classe [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) vous permet d’enregistrer le contenu d’une forme sous forme d’image SVG. L’extrait de code ci‑dessous montre comment exporter une forme vers un fichier SVG.
```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    with open("output.svg", "wb") as image_stream:
        # Obtenir la première forme de la première diapositive.
        shape = presentation.slides[0].shapes[0]
        shape.write_as_svg(image_stream)
```


## **Aligner la forme**

En utilisant la méthode `align_shape` de la classe [SlidesUtil](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/), vous pouvez :

* Aligner les formes par rapport aux marges d’une diapositive (voir Exemple 1).
* Aligner les formes les unes par rapport aux autres (voir Exemple 2).

L’énumération [ShapesAlignmentType](https://reference.aspose.com/slides/python-net/aspose.slides/shapesalignmenttype/) définit les options d’alignement disponibles.

**Exemple 1**

Ce code Python montre comment aligner les formes aux indices 1, 2 et 4 avec le bord supérieur de la diapositive :
```py
import aspose.slides as slides

align_type = slides.ShapesAlignmentType.ALIGN_TOP
slide_indices = [1, 2, 4]

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    slides.util.SlideUtil.align_shapes(align_type, True, slide, slide_indices)
```


**Exemple 2**

Cet exemple Python montre comment aligner toutes les formes d’une collection par rapport à la forme la plus basse de cette collection :
```py
import aspose.slides as slides

align_type = slides.ShapesAlignmentType.ALIGN_BOTTOM

with slides.Presentation("sample.pptx") as presentation:
    slides.util.SlideUtil.align_shapes(align_type, False, presentation.slides[0])
```


## **Propriétés de retournement**

Dans Aspose.Slides, la classe [ShapeFrame](https://reference.aspose.com/slides/python-net/aspose.slides/shapeframe/) offre un contrôle sur le miroir horizontal et vertical des formes via ses propriétés `flip_h` et `flip_v`. Les deux propriétés sont de type [NullableBool](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/), permettant les valeurs `TRUE` pour indiquer un retournement, `FALSE` pour aucun retournement, ou `NOT_DEFINED` pour utiliser le comportement par défaut. Ces valeurs sont accessibles depuis le [Frame](https://reference.aspose.com/slides/python-net/aspose.slides/shape/frame/) d’une forme.

Pour modifier les paramètres de retournement, une nouvelle instance de [ShapeFrame](https://reference.aspose.com/slides/python-net/aspose.slides/shapeframe/) est construite avec la position et la taille actuelles de la forme, les valeurs souhaitées pour `flip_h` et `flip_v`, et l’angle de rotation. L’affectation de cette instance au [Frame](https://reference.aspose.com/slides/python-net/aspose.slides/shape/frame/) de la forme et l’enregistrement de la présentation appliquent les transformations de miroir et les enregistrent dans le fichier de sortie.

Supposons que nous ayons un fichier sample.pptx dans lequel la première diapositive contient une seule forme aux paramètres de retournement par défaut, comme illustré ci‑dessous.

![The shape to be flipped](shape_to_be_flipped.png)

L’exemple de code suivant récupère les propriétés de retournement actuelles de la forme et la retourne à la fois horizontalement et verticalement.
```py
with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    # Obtenir la propriété de retournement horizontal de la forme.
    horizontal_flip = shape.frame.flip_h
    print("Horizontal flip:", horizontal_flip)

    # Obtenir la propriété de retournement vertical de la forme.
    vertical_flip = shape.frame.flip_v
    print("Vertical flip:", vertical_flip)

    x, y = shape.frame.x, shape.frame.y
    width, height = shape.frame.width, shape.frame.height
    flip_h, flip_v = slides.NullableBool.TRUE, slides.NullableBool.TRUE  # Retourner horizontalement et verticalement.
    rotation = shape.frame.rotation

    shape.frame = slides.ShapeFrame(x, y, width, height, flip_h, flip_v, rotation)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


Le résultat :

![The flipped shape](flipped_shape.png)

## **FAQ**

**Puis‑je combiner des formes (union/intersection/soustraction) sur une diapositive comme dans un éditeur de bureau ?**

Il n’existe pas d’API d’opération booléenne intégrée. Vous pouvez vous en approcher en construisant vous‑même le contour souhaité — par exemple, calculez la géométrie résultante (via [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/)) et créez une nouvelle forme avec ce contour, en supprimant éventuellement les originales.

**Comment contrôler l’ordre d’empilement (z‑order) afin qu’une forme reste toujours « au‑premier‑plan » ?**

Modifiez l’ordre d’insertion/déplacement au sein de la collection [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/slide/shapes/) de la diapositive. Pour des résultats prévisibles, finalisez le z‑order après toutes les autres modifications de la diapositive.

**Puis‑je « verrouiller » une forme pour empêcher les utilisateurs de la modifier dans PowerPoint ?**

Oui. Définissez les [drapeaux de protection au niveau de la forme](/slides/fr/python-net/applying-protection-to-presentation/) (par ex., verrouiller la sélection, le déplacement, le redimensionnement, les modifications de texte). Si besoin, appliquez les mêmes restrictions au maître ou à la mise en page. Notez qu’il s’agit d’une protection au niveau de l’interface utilisateur, pas d’une fonction de sécurité ; pour une protection plus forte, combinez‑la avec des restrictions au niveau du fichier telles que les recommandations en lecture seule ou les mots de passe [/slides/python-net/password-protected-presentation/].