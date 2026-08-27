---
title: Gérer les formes de présentation en Python
linktitle: Manipulation de formes
type: docs
weight: 40
url: /fr/python-net/shape-manipulations/
keywords:
- forme PowerPoint
- forme de présentation
- forme sur diapositive
- trouver forme
- cloner forme
- supprimer forme
- masquer forme
- changer l'ordre des formes
- obtenir l'ID interop de forme
- texte alternatif de forme
- point d'ajustement de forme
- ajustement de forme prédéfini
- géométrie de forme
- formats de mise en page de forme
- forme en SVG
- forme vers SVG
- aligner forme
- retourner forme
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Apprenez à identifier, ajuster, cloner, supprimer, masquer, réorganiser, exporter, aligner et retourner les formes de présentation avec Aspose.Slides pour Python via .NET."
---
## **Vue d'ensemble**

Aspose.Slides for Python via .NET représente les formes sur une diapositive sous forme d'une [ShapeCollection](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shapecollection/). La collection est à la fois l'endroit où vous trouvez et modifiez les formes et la source de leur ordre d'empilement : l'index `0` correspond à la forme la plus arrière, tandis que le dernier index correspond à la forme la plus avant.

Cet article suit ce modèle. Il explique d'abord comment identifier une forme de manière fiable et modifier les points d'ajustement de forme prédéfinis, puis montre comment cloner, supprimer, masquer et réorganiser des formes. Les sections finales couvrent le formatage au niveau de la disposition, l'exportation SVG, l'alignement et les paramètres de retournement. Chaque exemple est indépendant, ainsi vous ne pouvez utiliser que les opérations requises par votre flux de travail.

## **Identifier et trouver les formes**

Les index de collection sont pratiques lors du traitement d'un fichier connu, mais ils ne sont pas des identifiants stables. Ajouter, supprimer ou réorganiser une forme peut changer son index. Choisissez un identifiant en fonction de la façon dont la présentation est créée et maintenue :

- [Shape.name](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shape/name/) est utile pour les modèles contrôlés par les développeurs et est facile à inspecter dans le volet de sélection de PowerPoint. Les noms peuvent être modifiés et ne sont pas garantis uniques, il faut donc établir une convention de nommage si le code en dépend.
- [Shape.alternative_text](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shape/alternative_text/) est utile lorsqu'une description d'accessibilité ou une balise fournie par l'auteur identifie déjà la forme. Elle est visible pour les utilisateurs, peut être localisée ou réécrite pour l'accessibilité, et n'est pas garantie unique. Ne réutilisez pas silencieusement un texte d'accessibilité signifiant comme clé de base de données.
- [Shape.office_interop_shape_id](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shape/office_interop_shape_id/) est un identifiant en lecture seule qui est unique au sein d'une diapositive et correspond à l'ID de forme utilisé par l'interopérabilité PowerPoint. Utilisez-le lors de l'intégration avec PowerPoint ou lorsque vous avez besoin d'une référence sans ambiguïté pendant la durée de vie d'une forme. Une forme clonée ou recréée est une forme différente et reçoit son propre ID.

La propriété [Shape.unique_id](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shape/unique_id/) associée a une portée de présentation, mais elle est destinée aux compléments et peut être réattribuée. Elle ne doit pas être traitée comme une clé externe permanente. Si une identité à long terme est essentielle, conservez le mappage dans les données de l'application et validez que la forme attendue existe toujours.

L'exemple suivant recherche par `name` avec une comparaison exacte et indique l'ID interop à portée de diapositive. Lorsque le modèle ne contient pas la forme attendue, le code indique ce résultat au lieu de continuer avec l'objet incorrect.

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

Lorsque une opération est spécifique à un type de forme, vérifiez le type avant d'utiliser les membres spécifiques au type. Cet exemple met à jour le texte et le texte alternatif uniquement si l'objet nommé est une [AutoShape](https://reference.aspose.com/slides/fr/python-net/aspose.slides/autoshape/).

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

## **Identifier et modifier les ajustements de forme prédéfinis**

Les formes géométriques prédéfinies peuvent exposer des points d'ajustement qui contrôlent des caractéristiques telles que la taille des coins, les proportions des flèches ou les angles d'arc. Accédez-y via la collection en lecture seule [GeometryShape.adjustments](https://reference.aspose.com/slides/fr/python-net/aspose.slides/geometryshape/adjustments/). La collection elle‑même est fournie par la forme, mais chaque [AdjustValue](https://reference.aspose.com/slides/fr/python-net/aspose.slides/adjustvalue/) contient une valeur qui peut être modifiée.

Ne vous fiez pas uniquement à un index de collection fixe. Parcourez les ajustements et inspectez la propriété en lecture seule [AdjustValue.type](https://reference.aspose.com/slides/fr/python-net/aspose.slides/adjustvalue/type/), dont la valeur [ShapeAdjustmentType](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shapeadjustmenttype/) décrit ce que contrôle l'ajustement. La propriété en lecture seule [AdjustValue.name](https://reference.aspose.com/slides/fr/python-net/aspose.slides/adjustvalue/name/) fournit des informations d'identification supplémentaires et est particulièrement utile lorsqu'un prédéfini contient plusieurs ajustements avec le même type sémantique.

Utilisez la propriété de valeur qui correspond au sens de l'ajustement :

| Type d'ajustement | Objectif | Valeur à modifier |
|---|---|---|
| `CORNER_SIZE` | Taille des coins arrondis | [raw_value](https://reference.aspose.com/slides/fr/python-net/aspose.slides/adjustvalue/raw_value/) |
| `ARROW_TAIL_THICKNESS` | Épaisseur d'une queue de flèche | `raw_value` |
| `ARROWHEAD_LENGTH` | Longueur d'une tête de flèche | `raw_value` |
| `ARROWHEAD_WIDTH` | Largeur d'une tête de flèche | `raw_value` |
| `START_ANGLE` | Angle de départ d'un secteur ou d'un arc | [angle_value](https://reference.aspose.com/slides/fr/python-net/aspose.slides/adjustvalue/angle_value/) |
| `END_ANGLE` | Angle de fin d'un secteur ou d'un arc | `angle_value` |

`type` et `name` ne peuvent pas être assignés. `raw_value` est un entier en lecture/écriture dans les unités géométriques natives du prédéfini, tandis que `angle_value` est un angle en lecture/écriture exprimé en degrés. Le nombre, l'ordre, le sens et la plage valide des ajustements dépendent du prédéfini [GeometryShape.shape_type](https://reference.aspose.com/slides/fr/python-net/aspose.slides/geometryshape/shape_type/). Une valeur valide pour un prédéfini peut être invalide ou avoir un effet différent pour un autre.

Lorsque `type` est `ShapeAdjustmentType.CUSTOM`, l'API ne reconnaît pas de signification sémantique standard. Inspectez `name`, le type du prédéfini et la valeur existante, et laissez l'ajustement inchangé à moins que la signification et la plage attendues soient connues. Même pour les types reconnus, vérifiez si le même type apparaît plusieurs fois avant de sélectionner une valeur. L'article [Connector](/slides/fr/python-net/connector/) montre cette situation avec les ajustements de courbure de connecteur.

L'exemple complet suivant crée des versions par défaut et modifiées de trois formes prédéfinies. Il parcourt chaque ajustement, indique son `name` et `type`, modifie les valeurs liées à la taille via `raw_value`, modifie les angles via `angle_value`, et enregistre le résultat. La colonne de gauche conserve la géométrie par défaut ; la colonne de droite montre le rectangle arrondi ajusté, la flèche à quatre pointes et le secteur.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Ajouter des en-têtes pour les colonnes de forme par défaut et ajustée.
    default_column_label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 20, 250, 30)
    default_column_label.text_frame.text = "Default preset geometry"
    adjusted_column_label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 390, 20, 250, 30)
    adjusted_column_label.text_frame.text = "Modified adjustment values"

    slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 80, 70, 160, 70)
    modified_rounded_rectangle = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 430, 70, 160, 70)
    modified_rounded_rectangle.name = "ModifiedRoundedRectangle"

    slide.shapes.add_auto_shape(slides.ShapeType.QUAD_ARROW, 80, 180, 160, 110)
    modified_arrow = slide.shapes.add_auto_shape(slides.ShapeType.QUAD_ARROW, 430, 180, 160, 110)
    modified_arrow.name = "ModifiedQuadArrow"

    slide.shapes.add_auto_shape(slides.ShapeType.PIE, 95, 330, 130, 130)
    modified_pie = slide.shapes.add_auto_shape(slides.ShapeType.PIE, 445, 330, 130, 130)
    modified_pie.name = "ModifiedPie"

    shapes_to_adjust = [modified_rounded_rectangle, modified_arrow, modified_pie]

    for shape in shapes_to_adjust:
        for adjustment in shape.adjustments:
            print("{} / {}: {}".format(shape.name, adjustment.name, adjustment.type.name))

            if adjustment.type == slides.ShapeAdjustmentType.CORNER_SIZE:
                adjustment.raw_value = 5000
            elif adjustment.type == slides.ShapeAdjustmentType.ARROW_TAIL_THICKNESS:
                adjustment.raw_value = 25000
            elif adjustment.type == slides.ShapeAdjustmentType.ARROWHEAD_LENGTH:
                adjustment.raw_value = 30000
            elif adjustment.type == slides.ShapeAdjustmentType.ARROWHEAD_WIDTH:
                adjustment.raw_value = 40000
            elif adjustment.type == slides.ShapeAdjustmentType.START_ANGLE:
                adjustment.angle_value = 30
            elif adjustment.type == slides.ShapeAdjustmentType.END_ANGLE:
                adjustment.angle_value = 300
            elif adjustment.type == slides.ShapeAdjustmentType.CUSTOM:
                print("Custom adjustment '{}' was not changed.".format(adjustment.name))

    presentation.save("preset-shape-adjustments.pptx", slides.export.SaveFormat.PPTX)
```

Vérifier le type sémantique avant de modifier une valeur rend le code explicite quant à son intention et évite de supposer qu'un index de collection particulier a le même sens entre différentes formes prédéfinies.

## **Modifier la collection de formes**

Les méthodes add, clone, remove et reorder opèrent sur la collection immédiatement. Si une opération modifie le nombre ou l'ordre des formes, ne continuez pas à vous fier aux index capturés avant cette opération.

### **Cloner une forme**

[ShapeCollection.add_clone](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shapecollection/add_clone/) crée une copie indépendante et l'ajoute à la fin de la collection cible. [ShapeCollection.insert_clone](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shapecollection/insert_clone/) crée également une copie mais la place à un index z‑order spécifié. Les surcharges qui acceptent des coordonnées déplacent le clone sans changer sa taille ; les surcharges avec largeur et hauteur peuvent également le redimensionner.

L'exemple crée une diapositive de destination, clone un rectangle étiqueté vers l'avant, et insère un second clone à l'arrière. Les modifications apportées à l'un ou l'autre clone ne modifient pas la forme source.

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

[ShapeCollection.remove](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shapecollection/remove/) supprime un objet forme spécifique de sa collection. Lors de la suppression de plusieurs correspondances pendant une itération indexée, parcourez la collection à rebours afin que chaque index restant reste valide.

Cet exemple supprime chaque forme avec un nom désigné. Il lit `slide.shapes[index]`, pas un élément de collection fixe, et il ne cast pas la forme de façon inutile.

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

Après la suppression, le nombre de formes et les index des formes suivantes changent. Les références aux formes non affectées restent plus fiables que les index sauvegardés. Considérez également les connecteurs, les animations et d'autres fonctionnalités de la présentation qui peuvent référencer l'objet supprimé ; supprimer une forme visible peut modifier plus que l'apparence de la diapositive.

### **Masquer une forme**

Définir [Shape.hidden](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shape/hidden/) à `True` conserve la forme dans la collection mais empêche son affichage lors du diaporama normal. Son index, son formatage et son contenu restent accessibles au code, ainsi le masquage est approprié pour des éléments optionnels qui peuvent être restaurés ultérieurement.

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

Le masquage n'est ni une suppression ni une mesure de sécurité. L'objet peut encore être découvert et rendu visible par un utilisateur ou par le code, et il reste partie du fichier de présentation.

### **Modifier l'ordre Z**

Les formes qui se chevauchent sont dessinées selon l'ordre de la collection. [ShapeCollection.reorder](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shapecollection/reorder/) déplace une forme existante vers un index cible sans la cloner. L'index `0` correspond à l'arrière ; `len(slide.shapes) - 1` correspond à l'avant.

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

Le rectangle est créé en premier et se trouve initialement derrière l'ellipse. Le déplacer vers l'index final le place à l'avant. Finalisez l'ordre Z après avoir ajouté ou cloné toutes les formes liées, car ces opérations ajoutent ou insèrent de nouveaux éléments de collection et peuvent modifier la pile prévue.

## **Inspecter les formes sur les diapositives de mise en page**

Les diapositives normales, les diapositives de mise en page et les diapositives maîtres possèdent des collections de formes séparées. Une forme dans une collection de mise en page n'est pas le même objet qu'une forme positionnée de manière similaire sur une diapositive normale. Inspectez les formes de mise en page lorsque vous devez comprendre ou modifier le formatage fourni par une mise en page.

L'exemple suivant lit le [Shape.fill_format](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shape/fill_format/) et le [Shape.line_format](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shape/line_format/) de chaque forme de mise en page sans supposer que chaque forme est une `AutoShape`.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        for shape in layout_slide.shapes:
            fill_type = shape.fill_format.fill_type
            line_width = shape.line_format.width
            print("{} / {}: fill={}, line width={}".format(layout_slide.name, shape.name, fill_type, line_width))
```

Modifier une mise en page peut affecter plusieurs diapositives qui l'utilisent. Avant de modifier une forme de mise en page, déterminez si une diapositive normale hérite de l'objet ou contient une surcharge locale, et testez chaque diapositive qui utilise cette mise en page.

## **Exporter une forme au format SVG**

[Shape.write_as_svg](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shape/write_as_svg/) écrit le contenu rendu d'une forme dans un flux. Le résultat contient la forme, pas l'arrière-plan complet de la diapositive ni les formes voisines.

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

Gardez la présentation ouverte pendant le rendu. La sortie dépend du formatage de la forme et des ressources comme les polices et les images. Si vous avez besoin de toute la composition, exportez la diapositive plutôt qu'une forme individuelle. L'appelant possède le flux et doit le fermer.

## **Aligner les formes**

Les surcharges de [SlideUtil.align_shapes](https://reference.aspose.com/slides/fr/python-net/aspose.slides.util/slideutil/align_shapes/) alignent soit toutes les formes, soit des index de collection sélectionnés. [ShapesAlignmentType](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shapesalignmenttype/) spécifie le bord, la ligne centrale ou le mode de distribution. Réglez `align_to_slide` à `True` pour utiliser les bords de la diapositive ; réglez-le à `False` pour aligner les formes sélectionnées les unes par rapport aux autres.

Cet exemple aligne trois formes sur le bord supérieur de la diapositive. Leurs index actuels sont résolus immédiatement avant l'alignement.

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

L'alignement modifie les positions, pas l'ordre Z. L'alignement relatif nécessite généralement au moins deux formes, tandis que la distribution horizontale ou verticale requiert suffisamment de formes pour définir l'espacement. Recalculez les index si vous modifiez la collection avant d'appeler la méthode.

## **Retourner une forme**

La classe [ShapeFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shapeframe/) stocke la position, la taille, les paramètres de retournement horizontal et vertical, et la rotation. Ses valeurs `flip_h` et `flip_v` utilisent [NullableBool](https://reference.aspose.com/slides/fr/python-net/aspose.slides/nullablebool/): `TRUE` active le retournement, `FALSE` le désactive, et `NOT_DEFINED` préserve l'état non spécifié ou par défaut.

La présentation d'entrée ci‑détecte contient une forme non retournée.

![La forme avant retournement](shape_to_be_flipped.png)

L'exemple conserve chaque autre valeur de cadre et ne remplace que les deux paramètres de retournement. C'est important car l'affectation d'un nouveau [Shape.frame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shape/frame/) remplace le cadre complet.

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

![La forme après retournement](flipped_shape.png)

## **FAQ**

**Dois‑je utiliser un index de collection comme identifiant de forme ?**

Uniquement pour un traitement de courte durée lorsque la collection ne changera pas avant l'utilisation de l'index. Privilégiez une convention validée `name` ou `alternative_text` pour les modèles créés, ou `office_interop_shape_id` pour le travail d'interopérabilité à portée de diapositive.

**Le masquage d'une forme la retire‑t‑elle de l'ordre Z ?**

Non. Une forme masquée reste dans la collection au même index. Elle peut être trouvée, réordonnée, modifiée ou rendue à nouveau visible.

**Pourquoi une forme clonée apparaît‑elle devant une autre forme ?**

`add_clone` ajoute le clone à la fin de la collection, ce qui correspond à l'avant de l'ordre Z. Utilisez `insert_clone` pour choisir l'index initial ou `reorder` après avoir ajouté toutes les formes.

**Puis‑je utiliser un index fixe pour identifier un ajustement de forme prédéfini ?**

Uniquement après avoir validé le prédéfini exact et la disposition de la collection. privilégiez l'itération à travers `GeometryShape.adjustments` et la vérification de `AdjustValue.type` ; utilisez `AdjustValue.name` comme information supplémentaire lorsque le même type sémantique apparaît plusieurs fois.