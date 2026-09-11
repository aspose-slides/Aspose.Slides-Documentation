---
title: Gérer les formes de présentation en Python via Java
linktitle: Manipulation des formes
type: docs
weight: 40
url: /fr/python-java/shape-manipulations/
keywords:
- Forme PowerPoint
- Forme de présentation
- Forme sur diapositive
- Trouver une forme
- Cloner une forme
- Supprimer une forme
- Masquer une forme
- Modifier l'ordre des formes
- Obtenir l'ID de forme interop
- Texte alternatif de forme
- Point d'ajustement de forme
- Ajustement de forme prédéfini
- Géométrie de forme
- Formats de mise en page de forme
- Forme en tant que SVG
- Forme vers SVG
- Aligner une forme
- Retourner une forme
- PowerPoint
- Présentation
- Python
- Java
- Aspose.Slides
description: "Apprenez à identifier, ajuster, cloner, supprimer, masquer, réorganiser, exporter, aligner et retourner les formes de présentation avec Aspose.Slides pour Python via Java."
---
## **Aperçu**

Aspose.Slides for Python via Java représente les formes d’une diapositive sous forme d’une [ShapeCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapecollection/) ordonnée. La collection est à la fois l’endroit où vous trouvez et modifiez les formes et la source de leur ordre d’empilement : l’index `0` correspond à la forme la plus en arrière, tandis que le dernier index correspond à la forme la plus en avant.

Cet article suit ce modèle. Il explique d’abord comment identifier une forme de manière fiable et modifier les points d’ajustement prédéfinis, puis montre comment cloner, supprimer, masquer et réorganiser les formes. Les sections finales couvrent le formatage au niveau de la disposition, l’exportation SVG, l’alignement et les réglages de retournement. Chaque exemple est indépendant, vous pouvez donc n’utiliser que les opérations requises par votre flux de travail.

## **Identifier et rechercher des formes**

Les index de collection sont pratiques lors du traitement d’un fichier connu, mais ils ne sont pas des identifiants stables. Ajouter, supprimer ou réorganiser une forme peut changer son index. Choisissez un identifiant en fonction de la façon dont la présentation est créée et maintenue :

- [Name](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#getName) est utile pour les modèles contrôlés par les développeurs et est facile à inspecter dans le volet de sélection de PowerPoint. Les noms peuvent être modifiés et ne sont pas garantis uniques, il faut donc établir une convention de nommage si le code en dépend.
- [AlternativeText](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#getAlternativeText) est utile lorsqu’une description d’accessibilité ou une balise fournie par l’auteur identifie déjà la forme. Elle est visible des utilisateurs, peut être localisée ou réécrite pour l’accessibilité, et n’est pas garantie unique. Ne réutilisez pas silencieusement un texte d’accessibilité significatif comme clé de base de données.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#getOfficeInteropShapeId) est un identifiant en lecture seule unique au sein d’une diapositive et correspond à l’ID de forme utilisé par l’interop PowerPoint. Utilisez‑le lors de l’intégration avec PowerPoint ou lorsque vous avez besoin d’une référence sans ambiguïté pendant la durée de vie d’une forme. Une forme clonée ou recréée est une forme différente et reçoit son propre ID.

La méthode [getUniqueId](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#getUniqueId) associée renvoie un identifiant à portée de présentation, mais cet identifiant est destiné aux compléments et peut être réassigné. Il ne doit pas être considéré comme une clé externe permanente. Si une identité à long terme est essentielle, conservez le mappage dans les données d’application et validez que la forme attendue existe toujours.

L’exemple suivant recherche par nom avec une comparaison exacte et rapporte l’ID interop à portée de diapositive. Lorsque le modèle ne contient pas la forme attendue, le code signale ce résultat au lieu de continuer avec le mauvais objet.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    target_shape = None
    for shape in slide.getShapes():
        if shape.getName() == "RevenueChart":
            target_shape = shape
            break

    if target_shape is None:
        print("The shape 'RevenueChart' was not found on slide 1.")
    else:
        print(f"Found {target_shape.getName()}; interop ID: {target_shape.getOfficeInteropShapeId()}")
finally:
    presentation.dispose()
```

Lorsqu’une opération est spécifique à un type de forme, vérifiez le type avant d’utiliser les membres spécifiques. Cet exemple met à jour le texte et le texte alternatif uniquement si l’objet nommé est un [AutoShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/autoshape/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    candidate = None
    for shape in slide.getShapes():
        if shape.getName() == "StatusLabel":
            candidate = shape
            break

    if isinstance(candidate, AutoShape):
        candidate.getTextFrame().setText("Approved")
        candidate.setAlternativeText("Approval status: approved")
        presentation.save("identified-shape.pptx", SaveFormat.Pptx)
    else:
        print("'StatusLabel' is missing or is not an AutoShape.")
finally:
    presentation.dispose()
```

## **Identifier et modifier les ajustements de forme prédéfinis**

Les formes de géométrie prédéfinie peuvent exposer des points d’ajustement qui contrôlent des caractéristiques telles que la taille des coins, les proportions des flèches ou les angles d’arc. Accédez‑y via la collection en lecture seule [GeometryShape.getAdjustments](https://reference.aspose.com/slides/fr/python-java/aspose.slides/geometryshape/#getAdjustments). La collection elle‑même est fournie par la forme, mais chaque [AdjustValue](https://reference.aspose.com/slides/fr/python-java/aspose.slides/adjustvalue/) contient une valeur qui peut être modifiée.

Ne vous fiez pas uniquement à un index de collection fixe. Parcourez les ajustements et inspectez la méthode en lecture seule [getType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/adjustvalue/#getType), dont la valeur [ShapeAdjustmentType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapeadjustmenttype/) décrit ce que contrôle l’ajustement. La méthode en lecture seule [getName](https://reference.aspose.com/slides/fr/python-java/aspose.slides/adjustvalue/#getName) fournit des informations d’identification supplémentaires et est particulièrement utile lorsqu’un preset contient plusieurs ajustements du même type sémantique.

Utilisez la méthode de valeur qui correspond à la signification de l’ajustement :

| Type d’ajustement | Objectif | Valeur à modifier |
|---|---|---|
| [CornerSize](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapeadjustmenttype/#CornerSize) | Taille des coins arrondis | [setRawValue](https://reference.aspose.com/slides/fr/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowTailThickness](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapeadjustmenttype/#ArrowTailThickness) | Épaisseur d’une queue de flèche | [setRawValue](https://reference.aspose.com/slides/fr/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowheadLength](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapeadjustmenttype/#ArrowheadLength) | Longueur d’une pointe de flèche | [setRawValue](https://reference.aspose.com/slides/fr/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowheadWidth](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapeadjustmenttype/#ArrowheadWidth) | Largeur d’une pointe de flèche | [setRawValue](https://reference.aspose.com/slides/fr/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [StartAngle](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapeadjustmenttype/#StartAngle) | Angle de départ d’un secteur ou d’un arc | [setAngleValue](https://reference.aspose.com/slides/fr/python-java/aspose.slides/adjustvalue/#setAngleValue) |
| [EndAngle](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapeadjustmenttype/#EndAngle) | Angle de fin d’un secteur ou d’un arc | [setAngleValue](https://reference.aspose.com/slides/fr/python-java/aspose.slides/adjustvalue/#setAngleValue) |

[getType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/adjustvalue/#getType) et [getName](https://reference.aspose.com/slides/fr/python-java/aspose.slides/adjustvalue/#getName) renvoient des informations en lecture seule. [getRawValue](https://reference.aspose.com/slides/fr/python-java/aspose.slides/adjustvalue/#getRawValue) et [setRawValue](https://reference.aspose.com/slides/fr/python-java/aspose.slides/adjustvalue/#setRawValue) travaillent avec un entier dans les unités géométriques natives du preset, tandis que [getAngleValue](https://reference.aspose.com/slides/fr/python-java/aspose.slides/adjustvalue/#getAngleValue) et [setAngleValue](https://reference.aspose.com/slides/fr/python-java/aspose.slides/adjustvalue/#setAngleValue) travaillent avec un angle en degrés. Le nombre, l’ordre, la signification et la plage valide des ajustements dépendent du [ShapeType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/geometryshape/#getShapeType) du preset. Une valeur valide pour un preset peut être invalide ou avoir un effet différent pour un autre.

Lorsque [getType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/adjustvalue/#getType) renvoie [ShapeAdjustmentType.Custom](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapeadjustmenttype/#Custom), l’API ne reconnaît pas de signification sémantique standard. Inspectez [getName](https://reference.aspose.com/slides/fr/python-java/aspose.slides/adjustvalue/#getName), le type du preset et la valeur existante, et laissez l’ajustement inchangé à moins que la signification et la plage attendues soient connues. Même pour les types reconnus, vérifiez si le même type apparaît plusieurs fois avant de sélectionner une valeur. L’article [Connector](/slides/fr/python-java/connector/) montre cette situation avec les ajustements de courbure des connecteurs.

L’exemple complet suivant crée des versions par défaut et modifiées de trois formes prédéfinies. Il parcourt chaque ajustement, rapporte son nom et son type, modifie les valeurs liées à la taille via [setRawValue](https://reference.aspose.com/slides/fr/python-java/aspose.slides/adjustvalue/#setRawValue), modifie les angles via [setAngleValue](https://reference.aspose.com/slides/fr/python-java/aspose.slides/adjustvalue/#setAngleValue) et enregistre le résultat. La colonne de gauche conserve la géométrie par défaut ; la colonne de droite montre le rectangle arrondi, la flèche à quatre extrémités et le secteur ajustés.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeAdjustmentType, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Ajoute des en-têtes pour les colonnes de formes par défaut et ajustées.
    default_column_label = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 20, 250, 30)
    default_column_label.getTextFrame().setText("Default preset geometry")
    adjusted_column_label = slide.getShapes().addAutoShape(ShapeType.Rectangle, 390, 20, 250, 30)
    adjusted_column_label.getTextFrame().setText("Modified adjustment values")

    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 80, 70, 160, 70)
    modified_rounded_rectangle = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 430, 70, 160, 70)
    modified_rounded_rectangle.setName("ModifiedRoundedRectangle")

    slide.getShapes().addAutoShape(ShapeType.QuadArrow, 80, 180, 160, 110)
    modified_arrow = slide.getShapes().addAutoShape(ShapeType.QuadArrow, 430, 180, 160, 110)
    modified_arrow.setName("ModifiedQuadArrow")

    slide.getShapes().addAutoShape(ShapeType.Pie, 95, 330, 130, 130)
    modified_pie = slide.getShapes().addAutoShape(ShapeType.Pie, 445, 330, 130, 130)
    modified_pie.setName("ModifiedPie")

    shapes_to_adjust = [modified_rounded_rectangle, modified_arrow, modified_pie]

    for shape in shapes_to_adjust:
        for adjustment_index in range(shape.getAdjustments().size()):
            adjustment = shape.getAdjustments().get_Item(adjustment_index)
            print(f"{shape.getName()} / {adjustment.getName()}: {adjustment.getType()}")

            if adjustment.getType() == ShapeAdjustmentType.CornerSize:
                adjustment.setRawValue(5000)
            elif adjustment.getType() == ShapeAdjustmentType.ArrowTailThickness:
                adjustment.setRawValue(25000)
            elif adjustment.getType() == ShapeAdjustmentType.ArrowheadLength:
                adjustment.setRawValue(30000)
            elif adjustment.getType() == ShapeAdjustmentType.ArrowheadWidth:
                adjustment.setRawValue(40000)
            elif adjustment.getType() == ShapeAdjustmentType.StartAngle:
                adjustment.setAngleValue(30)
            elif adjustment.getType() == ShapeAdjustmentType.EndAngle:
                adjustment.setAngleValue(300)
            elif adjustment.getType() == ShapeAdjustmentType.Custom:
                print(f"Custom adjustment '{adjustment.getName()}' was not changed.")

    presentation.save("preset-shape-adjustments.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Vérifier le type sémantique avant de changer une valeur rend le code explicite quant à son intention et évite de supposer qu’un index de collection a la même signification entre différents presets.

## **Modifier la collection de formes**

Les méthodes d’ajout, de clonage, de suppression et de réorganisation agissent immédiatement sur la collection. Si une opération change le nombre ou l’ordre des formes, ne continuez pas à vous fier aux index capturés avant cette opération.

### **Cloner une forme**

[addClone](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapecollection/#addClone) crée une copie indépendante et l’ajoute à la collection cible. [insertClone](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapecollection/#insertClone) crée également une copie mais la place à un index de z‑order spécifié. Les surcharges qui acceptent des coordonnées déplacent le clone sans changer sa taille ; celles avec largeur et hauteur peuvent également le redimensionner.

L’exemple crée une diapositive de destination, clone un rectangle étiqueté à l’avant et insère un second clone à l’arrière. Les modifications apportées à l’un ou l’autre clone ne modifient pas la forme source.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, SaveFormat, ShapeType, SlideLayoutType

presentation = Presentation()
try:
    source_slide = presentation.getSlides().get_Item(0)
    source_shape = source_slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 180, 60)
    source_shape.setName("SourceLabel")
    source_shape.getTextFrame().setText("Source")

    blank_layout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank)
    destination_slide = presentation.getSlides().addEmptySlide(blank_layout)

    front_clone_shape = destination_slide.getShapes().addClone(source_shape, 80, 80)
    front_clone_shape.setName("FrontClone")
    if isinstance(front_clone_shape, AutoShape):
        front_clone_shape.getTextFrame().setText("Front clone")
    else:
        print("The front clone is not an AutoShape; its text was not changed.")

    back_clone_shape = destination_slide.getShapes().insertClone(0, source_shape, 80, 180)
    back_clone_shape.setName("BackClone")
    if isinstance(back_clone_shape, AutoShape):
        back_clone_shape.getTextFrame().setText("Back clone")
    else:
        print("The back clone is not an AutoShape; its text was not changed.")

    presentation.save("cloned-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le clonage copie le contenu et le formatage de la forme, y compris son nom et son texte alternatif. Attribuez de nouveaux identifiants logiques au clone lorsque ces valeurs doivent être uniques. Les ressources utilisées par les formes complexes sont gérées par la présentation, mais un clone reste un nouvel élément de collection avec une nouvelle identité de forme.

### **Supprimer des formes**

[remove](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapecollection/#remove) supprime un objet forme spécifique de sa collection. Lors de la suppression de plusieurs correspondances pendant une itération indexée, parcourez la collection à rebours afin que chaque index restant reste valide.

Cet exemple supprime chaque forme ayant un nom désigné. Il lit la forme à l’index courant, pas un élément de collection fixe, et ne cast pas inutilement la forme.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    keep_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 140, 60)
    keep_shape.setName("Keep")

    first_temporary_shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 220, 40, 80, 80)
    first_temporary_shape.setName("Temporary")

    second_temporary_shape = slide.getShapes().addAutoShape(ShapeType.Triangle, 340, 40, 100, 80)
    second_temporary_shape.setName("Temporary")

    for i in range(slide.getShapes().size() - 1, -1, -1):
        shape = slide.getShapes().get_Item(i)
        if shape.getName() == "Temporary":
            slide.getShapes().remove(shape)

    presentation.save("removed-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Après la suppression, le nombre de formes et les index des formes suivantes changent. Les références aux formes non affectées restent plus fiables que des index enregistrés. Pensez également aux connecteurs, animations et autres fonctionnalités de présentation qui peuvent faire référence à l’objet supprimé ; la suppression d’une forme visible peut modifier plus que l’apparence de la diapositive.

### **Masquer une forme**

Définir [Hidden](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#setHidden) à `True` conserve la forme dans la collection mais empêche son affichage lors du diaporama normal. Son index, son formatage et son contenu restent accessibles au code, il est donc approprié de masquer des éléments optionnels qui peuvent être restaurés ultérieurement.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    visible_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 160, 60)
    visible_shape.setName("VisibleLabel")

    optional_shape = slide.getShapes().addAutoShape(ShapeType.Moon, 240, 40, 100, 100)
    optional_shape.setName("OptionalDecoration")

    for shape in slide.getShapes():
        if shape.getName() == "OptionalDecoration":
            shape.setHidden(True)

    presentation.save("hidden-shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Masquer n’est pas une suppression ni une mesure de sécurité. L’objet peut toujours être découvert et rendu visible à nouveau par un utilisateur ou par du code, et il reste présent dans le fichier de présentation.

### **Modifier l’ordre Z**

Les formes qui se chevauchent sont peintes dans l’ordre de la collection. [reorder](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapecollection/#reorder) déplace une forme existante vers un index cible sans la cloner. L’index `0` correspond à l’arrière ; la [size](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapecollection/#size) de la collection moins un correspond à l’avant.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    blue_rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 220, 120)
    blue_rectangle.setName("BlueRectangle")
    blue_rectangle.getFillFormat().setFillType(FillType.Solid)
    blue_rectangle.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    orange_ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 180, 140, 220, 120)
    orange_ellipse.setName("OrangeEllipse")
    orange_ellipse.getFillFormat().setFillType(FillType.Solid)
    orange_ellipse.getFillFormat().getSolidFillColor().setColor(Color.ORANGE)

    slide.getShapes().reorder(slide.getShapes().size() - 1, blue_rectangle)
    presentation.save("reordered-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le rectangle est créé en premier et se trouve initialement derrière l’ellipse. Le déplacer vers l’index final le place devant. Finalisez l’ordre Z après avoir ajouté ou cloné toutes les formes liées, car ces opérations ajoutent ou insèrent de nouveaux éléments de collection et peuvent modifier la pile prévue.

## **Examiner les formes sur les diapositives de disposition**

Les diapositives normales, les diapositives de disposition et les diapositives maîtres possèdent des collections de formes séparées. Une forme dans une collection de disposition n’est pas le même objet qu’une forme positionnée de façon similaire sur une diapositive normale. Examinez les formes de disposition lorsque vous devez comprendre ou modifier le formatage fourni par une disposition.

L’exemple suivant lit le [FillFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#getFillFormat) et le [LineFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#getLineFormat) de chaque forme de disposition sans supposer que chaque forme soit un [AutoShape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/autoshape/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    for layout_slide in presentation.getLayoutSlides():
        for shape in layout_slide.getShapes():
            fill_type = shape.getFillFormat().getFillType()
            line_width = shape.getLineFormat().getWidth()
            print(f"{layout_slide.getName()} / {shape.getName()}: fill={fill_type}, line width={line_width}")
finally:
    presentation.dispose()
```

Modifier une mise en page peut affecter plusieurs diapositives qui l’utilisent. Avant de changer une forme de mise en page, déterminez si une diapositive normale hérite de l’objet ou contient un remplacement local, et testez chaque diapositive qui utilise cette mise en page.

## **Exporter une forme au format SVG**

La méthode `writeAsSvg` de [Shape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/) écrit le contenu rendu d’une forme dans un flux. Le résultat contient la forme, pas l’arrière‑plan complet de la diapositive ni les formes voisines.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from pathlib import Path
from java.io import ByteArrayOutputStream

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    if slide.getShapes().size() == 0:
        print("Slide 1 does not contain a shape to export.")
    else:
        shape = slide.getShapes().get_Item(0)
        svg_stream = ByteArrayOutputStream()
        try:
            shape.writeAsSvg(svg_stream)
            svg_bytes = bytes(svg_stream.toByteArray())
            Path("shape.svg").write_bytes(svg_bytes)
        except OSError as exception:
            print(f"The SVG file could not be written: {exception}")
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

Gardez la présentation ouverte pendant le rendu. La sortie dépend du formatage de la forme ainsi que des ressources telles que les polices et les images. Si vous avez besoin de la composition complète, exportez la diapositive plutôt que la forme individuelle. L’appelant possède le flux et doit le fermer.

## **Aligner des formes**

Les surcharges de [SlideUtil.alignShapes](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slideutil/#alignShapes) alignent soit toutes les formes, soit les index de collection sélectionnés. [ShapesAlignmentType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapesalignmenttype/) spécifie le bord, la ligne centrale ou le mode de distribution. Définissez `align_to_slide` à `True` pour utiliser les bords de la diapositive ; à `False` pour aligner les formes sélectionnées les unes par rapport aux autres.

Cet exemple aligne trois formes sur le bord supérieur de la diapositive. Les références de forme renvoyées sont converties en leurs index actuels immédiatement avant l’alignement.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType, ShapesAlignmentType, SlideUtil

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    first_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 60, 80, 120, 50)
    second_shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 240, 160, 120, 50)
    third_shape = slide.getShapes().addAutoShape(ShapeType.Triangle, 420, 240, 120, 50)
    first_shape.setName("FirstAlignedShape")
    second_shape.setName("SecondAlignedShape")
    third_shape.setName("ThirdAlignedShape")

    shape_indexes = jpype.JArray(jpype.JInt)([slide.getShapes().indexOf(first_shape), slide.getShapes().indexOf(second_shape), slide.getShapes().indexOf(third_shape)])

    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, True, slide, shape_indexes)
    presentation.save("aligned-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

L’alignement change les positions, pas l’ordre Z. L’alignement relatif nécessite normalement au moins deux formes, tandis que la distribution horizontale ou verticale nécessite suffisamment de formes pour définir l’espacement. Recalculez les index si vous modifiez la collection avant d’appeler la méthode.

## **Retourner une forme**

La classe [ShapeFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapeframe/) stocke la position, la taille, les paramètres de retournement horizontal et vertical, et la rotation. Ses valeurs [getFlipH](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapeframe/#getFlipH) et [getFlipV](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapeframe/#getFlipV) utilisent [NullableBool](https://reference.aspose.com/slides/fr/python-java/aspose.slides/nullablebool/) : `True` active le retournement, `False` le désactive, et `NotDefined` préserve l’état non spécifié/par défaut.

La présentation d’entrée ci‑dessous contient une forme non retournée.

![The shape before flipping](shape_to_be_flipped.png)

L’exemple conserve toutes les autres valeurs du cadre et ne remplace que les deux paramètres de retournement. Ceci est important car l’affectation d’un nouveau [Frame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#setFrame) remplace le cadre complet.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ShapeFrame

presentation = Presentation("sample.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    frame = shape.getFrame()

    print(f"Horizontal flip before change: {frame.getFlipH()}")
    print(f"Vertical flip before change: {frame.getFlipV()}")

    flipped_frame = ShapeFrame(frame.getX(), frame.getY(), frame.getWidth(), frame.getHeight(), NullableBool.True_, NullableBool.True_, frame.getRotation())
    shape.setFrame(flipped_frame)

    presentation.save("flipped-shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La forme enregistrée est reflétée horizontalement et verticalement tout en conservant sa position, sa taille et sa rotation.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Dois‑je utiliser un index de collection comme identifiant de forme ?**

Uniquement pour un traitement de courte durée lorsque la collection ne changera pas avant l’utilisation de l’index. Privilégiez une convention validée basée sur [Name](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#getName) ou [AlternativeText](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#getAlternativeText) pour les modèles créés, ou [OfficeInteropShapeId](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#getOfficeInteropShapeId) pour le travail d’interop à portée de diapositive.

**Masquer une forme la supprime‑t‑elle de l’ordre Z ?**

Non. Une forme masquée reste dans la collection au même index. Elle peut être trouvée, réordonnée, modifiée ou rendue visible à nouveau.

**Pourquoi une forme clonée apparaît‑elle devant une autre forme ?**

[addClone](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapecollection/#addClone) ajoute le clone à la fin de la collection, qui correspond à l’avant de l’ordre Z. Utilisez [insertClone](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapecollection/#insertClone) pour choisir l’index initial ou [reorder](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapecollection/#reorder) après avoir ajouté toutes les formes.

**Puis‑je utiliser un index fixe pour identifier un ajustement de forme prédéfini ?**

Seulement après avoir validé le preset exact et la disposition de la collection. Privilégiez l’itération via [GeometryShape.getAdjustments](https://reference.aspose.com/slides/fr/python-java/aspose.slides/geometryshape/#getAdjustments) et la vérification de [AdjustValue.getType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/adjustvalue/#getType) ; utilisez [AdjustValue.getName](https://reference.aspose.com/slides/fr/python-java/aspose.slides/adjustvalue/#getName) comme information supplémentaire lorsque le même type sémantique apparaît plusieurs fois.