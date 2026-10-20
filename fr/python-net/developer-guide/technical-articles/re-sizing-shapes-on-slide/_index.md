---
title: Redimensionner les formes sur les diapositives de présentation en Python
type: docs
weight: 130
url: /fr/python-net/resizing-shapes-on-slide/
aliases:
  - /python-net/re-sizing-shapes-on-slide/
  - /fr/python-net/re-sizing-shapes-on-slide/
keywords:
- redimensionner forme
- modifier la taille de la forme
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Redimensionnez facilement les formes sur les diapositives PowerPoint et OpenDocument avec Aspose.Slides pour Python via .NET — automatisez les ajustements de mise en page des diapositives et augmentez la productivité."
---
## **Vue d'ensemble**

Lorsque vous modifiez la taille des diapositives d'une présentation, il peut également être nécessaire de redimensionner et repositionner ses formes pour les adapter aux nouvelles dimensions. Cet article montre comment mettre à l'échelle les formes manuellement et comment gérer les tableaux sur les diapositives, les maîtres et les mises en page.

## **Redimensionner les formes**

Pour conserver la position et la taille relatives de chaque forme, multipliez ses coordonnées horizontales et sa largeur par le rapport entre la nouvelle largeur de la diapositive et la largeur d'origine. Appliquez le rapport de hauteur correspondant à ses coordonnées verticales et à sa hauteur.

Le premier exemple charge une présentation dont les diapositives ne contiennent aucun tableau, change la taille de la diapositive en A4 et enregistre le résultat. Il utilise [SlideSize.set_size](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/set_size/) avec [SlideSizeScaleType.DO_NOT_SCALE](https://reference.aspose.com/slides/python-net/aspose.slides/slidesizescaletype/) afin que la boucle suivante contrôle le redimensionnement. Les rapports sont sans unité ; les positions et dimensions des formes sont mesurées en points. Des rapports de largeur et de hauteur différents peuvent déformer les formes, et modifier les dimensions d’une forme ne redimensionne pas la taille de ses polices.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # Calculer les facteurs d'échelle horizontaux et verticaux indépendants.
    original_size = presentation.slide_size.size
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)
    target_size = presentation.slide_size.size
    width_ratio = target_size.width / original_size.width
    height_ratio = target_size.height / original_size.height

    for slide in presentation.slides:
        for shape in slide.shapes:
            shape.width *= width_ratio
            shape.height *= height_ratio
            shape.x *= width_ratio
            shape.y *= height_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="info" title="Note" %}}
Les tableaux nécessitent une gestion séparée : redimensionnez leurs largeurs de colonne et hauteurs de ligne au lieu d'attribuer la largeur et la hauteur globales du tableau. Les hauteurs de ligne peuvent rester supérieures à la valeur demandée si le contenu des cellules nécessite plus d'espace.
{{% /alert %}}

Le deuxième exemple prend en charge les tableaux et traite les formes sur les maîtres et les mises en page ainsi que sur les diapositives individuelles avant d'enregistrer la présentation redimensionnée. Son assistant gère chaque [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) en redimensionnant [Column.width](https://reference.aspose.com/slides/python-net/aspose.slides/column/width/) et [Row.minimal_height](https://reference.aspose.com/slides/python-net/aspose.slides/row/minimal_height/). Il redimensionne ensuite la position du tableau sans redimensionner séparément ses dimensions globales.

```python
import aspose.slides as slides


def resize_shapes(shapes, width_ratio, height_ratio):
    for shape in shapes:
        if isinstance(shape, slides.Table):
            # Les dimensions du tableau sont contrôlées par la largeur des colonnes et la hauteur des lignes.
            for column in shape.columns:
                column.width *= width_ratio

            for row in shape.rows:
                row.minimal_height *= height_ratio
        else:
            shape.width *= width_ratio
            shape.height *= height_ratio

        shape.x *= width_ratio
        shape.y *= height_ratio


with slides.Presentation("sample.pptx") as presentation:
    # Calculer les facteurs d'échelle horizontaux et verticaux indépendants.
    original_size = presentation.slide_size.size
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)
    target_size = presentation.slide_size.size
    width_ratio = target_size.width / original_size.width
    height_ratio = target_size.height / original_size.height

    # Redimensionner les formes définies sur les maîtres et les mises en page ainsi que sur les diapositives individuelles.
    for master in presentation.masters:
        resize_shapes(master.shapes, width_ratio, height_ratio)

        for layout_slide in master.layout_slides:
            resize_shapes(layout_slide.shapes, width_ratio, height_ratio)

    for slide in presentation.slides:
        resize_shapes(slide.shapes, width_ratio, height_ratio)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Pourquoi les formes sont‑elles déformées ou tronquées après le redimensionnement d’une diapositive ?**

Si vous modifiez la taille de la diapositive sans redimensionner les formes, elles conservent leurs positions et dimensions d’origine et peuvent dépasser la diapositive. Redimensionner la largeur et la hauteur avec des rapports différents peut également déformer les formes.

**Le code fourni fonctionne‑t‑il pour tous les types de formes ?**

Le premier exemple modifie directement les limites des formes et est destiné aux diapositives sans tableaux. Le deuxième exemple gère les tableaux séparément. Vérifiez la mise en page résultante, en particulier le texte et les tableaux, car ces exemples ne redimensionnent pas les tailles de police et le contenu du tableau peut contraindre les hauteurs de ligne.

**Comment redimensionner les tableaux lors du redimensionnement d’une diapositive ?**

Redimensionnez les largeurs de colonne selon le rapport de largeur et les hauteurs minimales des lignes selon le rapport de hauteur, puis redimensionnez la position du tableau, comme le montre le deuxième exemple.

**Ce redimensionnement fonctionnera‑t‑il pour les diapositives maîtres et les diapositives de mise en page ?**

Oui. Le deuxième exemple parcourt les [Presentation.masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) et les [MasterSlide.layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/layout_slides/) de chaque maître et applique la même logique de redimensionnement à leurs formes.

**Puis‑je changer l’orientation d’une diapositive (portrait/paysage) lors du redimensionnement ?**

Oui. Définissez [SlideSize.orientation](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/orientation/) après avoir modifié la taille de la diapositive et avant de lire les dimensions cibles, afin que les facteurs d’échelle reflètent l’orientation finale.

**Existe‑t‑il une limite à la taille de diapositive que je peux définir ?**

Vous pouvez spécifier des dimensions de diapositive personnalisées avec [SlideSize.set_size](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/set_size/). Les dimensions prises en charge dépendent également du format de la présentation et de l’application utilisée pour ouvrir le fichier.

**Comment empêcher les formes à rapport d’aspect fixe de se déformer ?**

Utilisez le même facteur d’échelle pour la largeur et la hauteur. Pour adapter la mise en page d’origine aux nouvelles dimensions de la diapositive, utilisez le plus petit des deux rapports de largeur et de hauteur pour les deux dimensions et les positions. Cela préserve les proportions mais peut laisser un espace inutilisé le long d’un bord.