---
title: Gérer les formes de présentation en Python
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
- obtenir l'ID de forme interop
- texte alternatif de forme
- formats de mise en page de forme
- forme en SVG
- forme vers SVG
- aligner une forme
- retourner une forme
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Apprenez comment identifier, cloner, supprimer, masquer, réorganiser, exporter, aligner et retourner les formes de présentation avec Aspose.Slides pour Python via .NET."
---
## **Vue d'ensemble**

Aspose.Slides for Python via .NET représente les formes d’une diapositive comme une [ShapeCollection](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shapecollection/) ordonnée. La collection est à la fois l’endroit où vous trouvez et modifiez les formes et la source de leur ordre d empilement : l’index `0` correspond à la forme la plus en arrière, tandis que le dernier index correspond à la forme la plus en avant.

Cet article suit ce modèle. Il explique d’abord comment identifier de façon fiable une forme, puis montre comment cloner, supprimer, masquer et réordonner les formes. Les sections finales couvrent le formatage au niveau du masque, l’export SVG, l’alignement et les paramètres de retournement. Chaque exemple est indépendant, de sorte que vous ne puissiez utiliser que les opérations requises par votre flux de travail.

## **Identifier et trouver des formes**

Les index de collection sont pratiques lors du traitement d’un fichier connu, mais ils ne sont pas des identifiants stables. Ajouter, supprimer ou réorganiser une forme peut changer son index. Choisissez un identifiant en fonction de la façon dont la présentation est créée et maintenue :

- [Shape.name](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shape/name/) est utile pour les modèles contrôlés par le développeur et est facile à inspecter dans le panneau de sélection de PowerPoint. Les noms peuvent être modifiés et ne sont pas garantis uniques, il faut donc établir une convention de nommage si le code en dépend.
- [Shape.alternative_text](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shape/alternative_text/) est utile lorsqu’une description d’accessibilité ou une balise fournie par l’auteur identifie déjà la forme. Elle est visible par les utilisateurs, peut être localisée ou réécrite pour l’accessibilité, et n’est pas garantie unique. Ne réutilisez pas silencieusement un texte d’accessibilité significatif comme clé de base de données.
- [Shape.office_interop_shape_id](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shape/office_interop_shape_id/) est un identifiant en lecture seule, unique au sein d’une diapositive et correspondant à l’ID de forme utilisé par l’interop PowerPoint. Utilisez‑le lors de l’intégration avec PowerPoint ou lorsque vous avez besoin d’une référence sans ambiguïté pendant la durée de vie d’une forme. Une forme clonée ou recréée est une forme différente et reçoit son propre ID.

La propriété [Shape.unique_id](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shape/unique_id/) associée a une portée de présentation, mais elle est destinée aux compléments et peut être réassignée. Elle ne doit pas être traitée comme une clé externe permanente. Si une identité à long terme est essentielle, conservez le mappage dans les données de l’application et validez que la forme attendue existe toujours.

L’exemple suivant recherche par `name` avec une comparaison exacte et rapporte l’ID interop au niveau de la diapositive. Lorsque le modèle ne contient pas la forme attendue, le code signale ce résultat au lieu de continuer avec l’objet incorrect.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    target_shape = None
    for shape in slide.shapes:
        if shape.name == "RevenueChart":
            target_shape = shape
            break

    if target_shape is None:
        print("The shape 'RevenueChart' was not found on slide 1.")
    else:
        print("Found {}; interop ID: {}".format(target_shape.name, target_shape.office_interop_shape_id))
```

Lorsqu’une opération est spécifique à un type de forme, vérifiez le type avant d’utiliser des membres spécifiques. Cet exemple met à jour le texte et le texte alternatif uniquement si l’objet nommé est un [AutoShape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/autoshape/).

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    candidate = None
    for shape in slide.shapes:
        if shape.name == "StatusLabel":
            candidate = shape
            break

    if isinstance(candidate, slides.AutoShape):
        candidate.text_frame.text = "Approved"
        candidate.alternative_text = "Approval status: approved"
        presentation.save("identified-shape.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("'StatusLabel' is missing or is not an AutoShape.")
```

## **Modifier la collection de formes**

Les méthodes d’ajout, de clonage, de suppression et de réordonnancement s’appliquent immédiatement à la collection. Si une opération modifie le nombre ou l’ordre des formes, ne continuez pas à vous fier aux index capturés avant cette opération.

### **Cloner une forme**

[ShapeCollection.add_clone](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shapecollection/add_clone/) crée une copie indépendante et l’ajoute à la collection cible. [ShapeCollection.insert_clone](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shapecollection/insert_clone/) crée également une copie mais la place à un index de z‑order spécifié. Les surcharges qui acceptent des coordonnées déplacent le clone sans changer sa taille ; les surcharges avec largeur et hauteur peuvent également le redimensionner.

L’exemple crée une diapositive de destination, clone un rectangle nommé vers l’avant, et insère un second clone à l’arrière. Les modifications apportées à l’un ou l’autre clone ne modifient pas la forme source.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    source_slide = presentation.slides[0]
    source_shape = source_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 180, 60)
    source_shape.name = "SourceLabel"
    source_shape.text_frame.text = "Source"

    blank_layout = presentation.masters[0].layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    destination_slide = presentation.slides.add_empty_slide(blank_layout)

    front_clone_shape = destination_slide.shapes.add_clone(source_shape, 80, 80)
    front_clone_shape.name = "FrontClone"
    if isinstance(front_clone_shape, slides.AutoShape):
        front_clone_shape.text_frame.text = "Front clone"
    else:
        print("The front clone is not an AutoShape; its text was not changed.")

    back_clone_shape = destination_slide.shapes.insert_clone(0, source_shape, 80, 180)
    back_clone_shape.name = "BackClone"
    if isinstance(back_clone_shape, slides.AutoShape):
        back_clone_shape.text_frame.text = "Back clone"
    else:
        print("The back clone is not an AutoShape; its text was not changed.")

    presentation.save("cloned-shapes.pptx", slides.export.SaveFormat.PPTX)
```

Le clonage copie le contenu et le formatage de la forme, y compris son nom et son texte alternatif. Attribuez de nouveaux identifiants logiques au clone lorsque ces valeurs doivent être uniques. Les ressources utilisées par les formes complexes sont gérées par la présentation, mais un clone reste un nouvel élément de collection avec une nouvelle identité de forme.

### **Supprimer des formes**

[ShapeCollection.remove](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shapecollection/remove/) supprime un objet forme spécifique de sa collection. Lors de la suppression de plusieurs correspondances pendant une itération indexée, parcourez la collection à l’envers afin que chaque index restant reste valide.

Cet exemple supprime chaque forme portant un nom désigné. Il lit `slide.shapes[index]`, pas un élément de collection fixe, et il ne cast pas la forme inutilement.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    keep_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 140, 60)
    keep_shape.name = "Keep"

    first_temporary_shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 220, 40, 80, 80)
    first_temporary_shape.name = "Temporary"

    second_temporary_shape = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 340, 40, 100, 80)
    second_temporary_shape.name = "Temporary"

    for index in range(len(slide.shapes) - 1, -1, -1):
        shape = slide.shapes[index]
        if shape.name == "Temporary":
            slide.shapes.remove(shape)

    presentation.save("removed-shapes.pptx", slides.export.SaveFormat.PPTX)
```

Après la suppression, le nombre de formes et les index des formes suivantes changent. Les références aux formes non affectées restent plus fiables que des index sauvegardés. Pensez également aux connecteurs, aux animations et à d’autres fonctionnalités de présentation qui peuvent faire référence à l’objet supprimé ; supprimer une forme visible peut modifier plus que l’apparence de la diapositive.

### **Masquer une forme**

Définir [Shape.hidden](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shape/hidden/) à `True` conserve la forme dans la collection mais empêche son affichage lors du diaporama normal. Son index, son formatage et son contenu restent accessibles au code, de sorte que le masquage convient aux éléments optionnels pouvant être restaurés ultérieurement.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    visible_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 160, 60)
    visible_shape.name = "VisibleLabel"

    optional_shape = slide.shapes.add_auto_shape(slides.ShapeType.MOON, 240, 40, 100, 100)
    optional_shape.name = "OptionalDecoration"

    for shape in slide.shapes:
        if shape.name == "OptionalDecoration":
            shape.hidden = True

    presentation.save("hidden-shape.pptx", slides.export.SaveFormat.PPTX)
```

Masquer n’est pas supprimer ni sécuriser. L’objet peut toujours être découvert et rendu visible par un utilisateur ou par du code, et il demeure partie du fichier de présentation.

### **Modifier l’ordre Z**

Les formes qui se chevauchent sont peintes selon l’ordre de la collection. [ShapeCollection.reorder](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shapecollection/reorder/) déplace une forme existante vers un index cible sans la cloner. L’index `0` correspond à l’arrière ; `len(slide.shapes) - 1` correspond à l’avant.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    blue_rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 220, 120)
    blue_rectangle.name = "BlueRectangle"
    blue_rectangle.fill_format.fill_type = slides.FillType.SOLID
    blue_rectangle.fill_format.solid_fill_color.color = draw.Color.steel_blue

    orange_ellipse = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 180, 140, 220, 120)
    orange_ellipse.name = "OrangeEllipse"
    orange_ellipse.fill_format.fill_type = slides.FillType.SOLID
    orange_ellipse.fill_format.solid_fill_color.color = draw.Color.orange

    slide.shapes.reorder(len(slide.shapes) - 1, blue_rectangle)
    presentation.save("reordered-shapes.pptx", slides.export.SaveFormat.PPTX)
```

Le rectangle est créé en premier et se trouve initialement derrière l’ellipse. Le déplacer vers l’index final le place à l’avant. Finalisez l’ordre Z après avoir ajouté ou cloné toutes les formes concernées, car ces opérations ajoutent ou insèrent de nouveaux éléments de collection et peuvent modifier la pile prévue.

## **Examiner les formes sur les masques de diapositives**

Les diapositives normales, les masques de disposition et les masques maîtres possèdent des collections de formes distinctes. Une forme dans la collection d’un masque n’est pas le même objet qu’une forme positionnée de façon similaire sur une diapositive normale. Examinez les formes de masque lorsque vous devez comprendre ou modifier le formatage fourni par un masque.

L’exemple suivant lit chaque [Shape.fill_format](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shape/fill_format/) et [Shape.line_format](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shape/line_format/) du masque sans supposer que chaque forme est une `AutoShape`.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        for shape in layout_slide.shapes:
            fill_type = shape.fill_format.fill_type
            line_width = shape.line_format.width
            print("{} / {}: fill={}, line width={}".format(layout_slide.name, shape.name, fill_type, line_width))
```

Modifier un masque peut affecter plusieurs diapositives qui l’utilisent. Avant de changer une forme de masque, déterminez si une diapositive normale hérite de l’objet ou contient une surcharge locale, et testez chaque diapositive qui utilise ce masque.

## **Exporter une forme en SVG**

[Shape.write_as_svg](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shape/write_as_svg/) écrit le contenu rendu d’une forme dans un flux. Le résultat contient uniquement la forme, pas l’arrière‑plan complet de la diapositive ni les formes voisines.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) == 0:
        print("Slide 1 does not contain a shape to export.")
    else:
        shape = slide.shapes[0]
        with open("shape.svg", "wb") as svg_stream:
            shape.write_as_svg(svg_stream)
```

Conservez la présentation ouverte pendant le rendu. La sortie dépend du formatage de la forme ainsi que des ressources telles que les polices et les images. Si vous avez besoin de toute la composition, exportez la diapositive plutôt qu’une forme individuelle. L’appelant possède le flux et doit le fermer.

## **Aligner les formes**

Les surcharges de [SlideUtil.align_shapes](https://reference.aspose.com/slides/fr/python-net/aspose.slides.util/slideutil/align_shapes/) alignent soit toutes les formes, soit les index de collection sélectionnés. [ShapesAlignmentType](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shapesalignmenttype/) indique le bord, la ligne centrale ou le mode de distribution. Définissez `align_to_slide` à `True` pour utiliser les bords de la diapositive ; à `False` pour aligner les formes sélectionnées les unes par rapport aux autres.

Cet exemple aligne trois formes sur le bord supérieur de la diapositive. Leurs index actuels sont résolus immédiatement avant l’alignement.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    first_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 60, 80, 120, 50)
    second_shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 240, 160, 120, 50)
    third_shape = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 420, 240, 120, 50)
    first_shape.name = "FirstAlignedShape"
    second_shape.name = "SecondAlignedShape"
    third_shape.name = "ThirdAlignedShape"

    shape_indexes = [
        slide.shapes.index_of(first_shape),
        slide.shapes.index_of(second_shape),
        slide.shapes.index_of(third_shape)
    ]

    slides.util.SlideUtil.align_shapes(slides.ShapesAlignmentType.ALIGN_TOP, True, slide, shape_indexes)
    presentation.save("aligned-shapes.pptx", slides.export.SaveFormat.PPTX)
```

L’alignement modifie les positions, pas l’ordre Z. L’alignement relatif nécessite généralement au moins deux formes, tandis que la distribution horizontale ou verticale nécessite suffisamment de formes pour définir l’espacement. Recalculez les index si vous modifiez la collection avant d’appeler la méthode.

## **Retourner une forme**

La classe [ShapeFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shapeframe/) stocke la position, la taille, les paramètres de retournement horizontal et vertical, et la rotation. Ses valeurs `flip_h` et `flip_v` utilisent [NullableBool](https://reference.aspose.com/slides/fr/python-net/aspose.slides/nullablebool/) : `TRUE` active le retournement, `FALSE` le désactive, et `NOT_DEFINED` préserve l’état non spécifié ou par défaut.

La présentation d’entrée ci‑dessous contient une forme non retournée.

![La forme avant de la retourner](shape_to_be_flipped.png)

L’exemple conserve toutes les autres valeurs du cadre et ne remplace que les deux paramètres de retournement. C’est important car l’affectation d’un nouveau [Shape.frame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shape/frame/) remplace le cadre complet.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    frame = shape.frame

    print("Horizontal flip before change:", frame.flip_h)
    print("Vertical flip before change:", frame.flip_v)

    shape.frame = slides.ShapeFrame(
        frame.x, frame.y, frame.width, frame.height,
        slides.NullableBool.TRUE, slides.NullableBool.TRUE, frame.rotation)

    presentation.save("flipped-shape.pptx", slides.export.SaveFormat.PPTX)
```

La forme enregistrée est reflétée horizontalement et verticalement tout en conservant sa position, sa taille et sa rotation.

![La forme après le retournement](flipped_shape.png)

## **FAQ**

**Dois‑je utiliser un index de collection comme identifiant de forme ?**

Uniquement pour un traitement de courte durée lorsque la collection ne changera pas avant l’utilisation de l’index. Privilégiez une convention validée de `name` ou `alternative_text` pour les modèles créés, ou `office_interop_shape_id` pour les travaux d’interopération au niveau de la diapositive.

**Masquer une forme la retire‑t‑elle de l’ordre Z ?**

Non. Une forme masquée reste dans la collection au même index. Elle peut être trouvée, réordonnée, modifiée ou rendue visible à nouveau.

**Pourquoi une forme clonée apparaît‑elle devant une autre forme ?**

`add_clone` ajoute le clone à la fin de la collection, ce qui correspond à l’avant de l’ordre Z. Utilisez `insert_clone` pour choisir l’index initial ou `reorder` après avoir ajouté toutes les formes.