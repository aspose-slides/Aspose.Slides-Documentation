---
title: Redimensionner les formes sur les diapositives de présentation en Python via Java
type: docs
weight: 110
url: /fr/python-java/resizing-shapes-on-slide/
aliases:
  - /python-java/re-sizing-shapes-on-slide/
  - /fr/python-java/re-sizing-shapes-on-slide/
keywords:
- redimensionner forme
- modifier la taille de la forme
- PowerPoint
- OpenDocument
- présentation
- Python
- Java
- Aspose.Slides
description: "Redimensionnez facilement les formes sur les diapositives PowerPoint et OpenDocument avec Aspose.Slides pour Python via Java — automatisez les ajustements de mise en page des diapositives et augmentez la productivité."
---
## **Vue d'ensemble**

Lorsque vous modifiez la taille des diapositives d’une présentation, vous pouvez également devoir redimensionner et repositionner ses formes pour qu’elles correspondent aux nouvelles dimensions. Cet article montre comment mettre à l’échelle les formes manuellement et comment gérer les tableaux sur les diapositives, les maîtres et les mises en page.

## **Redimensionner les formes**

Pour conserver la position et la taille relatives de chaque forme, multipliez ses coordonnées horizontales et sa largeur par le rapport entre la nouvelle largeur de la diapositive et la largeur d'origine. Appliquez le même rapport de hauteur à ses coordonnées verticales et à sa hauteur.

La première exemple charge une présentation dont les diapositives ne contiennent aucun tableau, modifie la taille des diapositives en A4 et enregistre le résultat. Elle utilise [SlideSize.setSize](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setSize) avec [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/python-java/aspose.slides/slidesizescaletype/#DoNotScale) afin que la boucle suivante contrôle la mise à l’échelle. Les rapports sont sans unité ; les positions et dimensions des formes sont mesurées en points. Des rapports de largeur et de hauteur différents peuvent déformer les formes, et modifier les dimensions d’une forme ne met pas à l’échelle les tailles de police.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType

presentation = Presentation("sample.pptx")
try:
    # Calculer les facteurs d'échelle horizontaux et verticaux indépendants.
    original_size = presentation.getSlideSize().getSize()
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    target_size = presentation.getSlideSize().getSize()
    width_ratio = target_size.getWidth() / original_size.getWidth()
    height_ratio = target_size.getHeight() / original_size.getHeight()

    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            shape.setWidth(shape.getWidth() * width_ratio)
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setX(shape.getX() * width_ratio)
            shape.setY(shape.getY() * height_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Les tableaux nécessitent une prise en charge distincte : mettre à l’échelle leurs largeurs de colonnes et hauteurs de lignes au lieu d’assigner la largeur et la hauteur globales du tableau. Les hauteurs de lignes peuvent rester supérieures à la valeur demandée si le contenu des cellules nécessite plus d’espace.
{{% /alert %}}

Le deuxième exemple prend en charge les tableaux et traite les formes sur les maîtres et les mises en page ainsi que sur les diapositives individuelles avant d’enregistrer la présentation redimensionnée. Son utilitaire gère chaque [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) en mettant à l’échelle les largeurs de colonnes avec [Column.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/column/#setWidth) et les hauteurs minimales de lignes avec [Row.setMinimalHeight](https://reference.aspose.com/slides/python-java/aspose.slides/row/#setMinimalHeight). Il met ensuite à l’échelle la position du tableau sans mettre séparément à l’échelle ses dimensions globales.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, Table


def resize_shapes(shapes, width_ratio, height_ratio):
    for shape in shapes:
        if isinstance(shape, Table):
            # Les dimensions du tableau sont contrôlées par les largeurs des colonnes et les hauteurs des lignes.
            for column in shape.getColumns():
                column.setWidth(column.getWidth() * width_ratio)

            for row in shape.getRows():
                row.setMinimalHeight(row.getMinimalHeight() * height_ratio)
        else:
            shape.setWidth(shape.getWidth() * width_ratio)
            shape.setHeight(shape.getHeight() * height_ratio)

        shape.setX(shape.getX() * width_ratio)
        shape.setY(shape.getY() * height_ratio)


presentation = Presentation("sample.pptx")
try:
    # Calculer les facteurs d'échelle horizontaux et verticaux indépendants.
    original_size = presentation.getSlideSize().getSize()
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    target_size = presentation.getSlideSize().getSize()
    width_ratio = target_size.getWidth() / original_size.getWidth()
    height_ratio = target_size.getHeight() / original_size.getHeight()

    # Redimensionner les formes définies sur les maîtres et les mises en page ainsi que sur les diapositives individuelles.
    for master in presentation.getMasters():
        resize_shapes(master.getShapes(), width_ratio, height_ratio)

        for layout_slide in master.getLayoutSlides():
            resize_shapes(layout_slide.getShapes(), width_ratio, height_ratio)

    for slide in presentation.getSlides():
        resize_shapes(slide.getShapes(), width_ratio, height_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Pourquoi les formes sont‑elles déformées ou rognées après le redimensionnement d’une diapositive ?**

Si vous modifiez la taille de la diapositive sans mettre à l’échelle les formes, elles conservent leurs positions et dimensions d’origine et peuvent dépasser les limites de la diapositive. Mettre à l’échelle la largeur et la hauteur avec des rapports différents peut également déformer les formes.

**Le code fourni fonctionne‑t‑il pour tous les types de formes ?**

Le premier exemple modifie directement les limites des formes et est destiné aux diapositives sans tableaux. Le deuxième exemple gère les tableaux séparément. Vérifiez la mise en page résultante, en particulier le texte et les tableaux, car ces exemples ne mettent pas à l’échelle les tailles de police et le contenu des tableaux peut contraindre les hauteurs de lignes.

**Comment redimensionner les tableaux lors du redimensionnement d’une diapositive ?**

Mettez à l’échelle les largeurs de colonnes selon le rapport de largeur et les hauteurs minimales de lignes selon le rapport de hauteur, puis mettez à l’échelle la position du tableau, comme illustré dans le deuxième exemple.

**Ce redimensionnement fonctionne‑t‑il pour les diapositives maîtres et les diapositives de mise en page ?**

Oui. Le deuxième exemple parcourt [Presentation.getMasters](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasters) et les [MasterSlide.getLayoutSlides](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/#getLayoutSlides) de chaque maître et applique la même logique de redimensionnement à leurs formes.

**Puis‑je changer l’orientation d’une diapositive (portrait/paysage) lors du redimensionnement ?**

Oui. Appelez [SlideSize.setOrientation](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setOrientation) après avoir changé la taille de la diapositive et avant de lire les dimensions cibles, afin que les facteurs d’échelle reflètent l’orientation finale.

**Existe‑t‑il une limite à la taille de diapositive que je peux définir ?**

Vous pouvez spécifier des dimensions de diapositive personnalisées avec [SlideSize.setSize](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setSize). Les dimensions prises en charge dépendent également du format de la présentation et de l’application utilisée pour ouvrir le fichier.

**Comment éviter que les formes à ratio d’aspect fixe ne soient déformées ?**

Utilisez le même facteur d’échelle pour la largeur et la hauteur. Pour adapter la mise en page originale aux nouvelles dimensions de la diapositive, utilisez le plus petit des rapports de largeur et de hauteur pour les deux dimensions et les positions. Cela préserve les proportions mais peut laisser un espace inutilisé le long d’un bord.