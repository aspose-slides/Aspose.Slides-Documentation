---
title: Redimensionner les formes sur les diapositives de présentation en .NET
type: docs
weight: 130
url: /fr/net/resizing-shapes-on-slide/
aliases:
  - /fr/net/re-sizing-shapes-on-slide/
  /net/re-sizing-shapes-on-slide/
keywords:
- redimensionner forme
- modifier la taille de la forme
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Redimensionnez facilement les formes sur les diapositives PowerPoint et OpenDocument avec Aspose.Slides pour .NET — automatisez les ajustements de mise en page des diapositives et augmentez la productivité."
---
## **Vue d'ensemble**

Lorsque vous modifiez la taille des diapositives d’une présentation, il peut également être nécessaire de redimensionner et de repositionner ses formes pour qu’elles s’adaptent aux nouvelles dimensions. Cet article montre comment mettre à l’échelle les formes manuellement et comment gérer les tableaux sur les diapositives, les maîtres et les mises en page.

## **Redimensionner les formes**

Pour conserver la position et la taille relatives de chaque forme, multipliez ses coordonnées horizontales et sa largeur par le rapport entre la nouvelle largeur de la diapositive et la largeur d’origine. Appliquez le rapport de hauteur correspondant à ses coordonnées verticales et à sa hauteur.

Le premier exemple charge une présentation dont les diapositives ne contiennent aucun tableau, modifie la taille de la diapositive en A4 et enregistre le résultat. Il utilise [SlideSize.SetSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/) avec [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/net/aspose.slides/slidesizescaletype/) afin que la boucle suivante contrôle la mise à l’échelle. Les rapports sont sans unité ; les positions et dimensions des formes sont mesurées en points. Des rapports de largeur et de hauteur différents peuvent déformer les formes, et la modification des dimensions d’une forme ne met pas à l’échelle la taille de sa police.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Calculer les facteurs d'échelle horizontaux et verticaux indépendants.
var originalSize = presentation.SlideSize.Size;
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
var targetSize = presentation.SlideSize.Size;
var widthRatio = targetSize.Width / originalSize.Width;
var heightRatio = targetSize.Height / originalSize.Height;

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        shape.Width *= widthRatio;
        shape.Height *= heightRatio;
        shape.X *= widthRatio;
        shape.Y *= heightRatio;
    }
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert color="info" title="Note" %}}
Les tableaux nécessitent une prise en charge distincte : mettez à l’échelle leurs largeurs de colonnes et hauteurs de lignes au lieu d’attribuer la largeur et la hauteur globales du tableau. Les hauteurs de lignes peuvent rester supérieures à la valeur demandée si le contenu des cellules requiert plus d’espace.
{{% /alert %}}

Le deuxième exemple prend en charge les tableaux et traite les formes sur les maîtres et les mises en page ainsi que sur les diapositives individuelles avant d’enregistrer la présentation redimensionnée. Son assistant gère chaque [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) en mettant à l’échelle [IColumn.Width](https://reference.aspose.com/slides/net/aspose.slides/icolumn/width/) et [IRow.MinimalHeight](https://reference.aspose.com/slides/net/aspose.slides/irow/minimalheight/). Il met ensuite à l’échelle la position du tableau sans mettre séparément à l’échelle ses dimensions globales.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Calculer les facteurs d'échelle horizontaux et verticaux indépendants.
var originalSize = presentation.SlideSize.Size;
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
var targetSize = presentation.SlideSize.Size;
var widthRatio = targetSize.Width / originalSize.Width;
var heightRatio = targetSize.Height / originalSize.Height;

// Redimensionner les formes définies sur les maîtres et les mises en page ainsi que sur les diapositives individuelles.
foreach (var master in presentation.Masters)
{
    ResizeShapes(master.Shapes, widthRatio, heightRatio);

    foreach (var layoutSlide in master.LayoutSlides)
    {
        ResizeShapes(layoutSlide.Shapes, widthRatio, heightRatio);
    }
}

foreach (var slide in presentation.Slides)
{
    ResizeShapes(slide.Shapes, widthRatio, heightRatio);
}

presentation.Save("output.pptx", SaveFormat.Pptx);

static void ResizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio)
{
    foreach (var shape in shapes)
    {
        if (shape is ITable table)
        {
            // Les dimensions du tableau sont contrôlées par les largeurs des colonnes et les hauteurs des lignes.
            foreach (var column in table.Columns)
            {
                column.Width *= widthRatio;
            }

            foreach (var row in table.Rows)
            {
                row.MinimalHeight *= heightRatio;
            }
        }
        else
        {
            shape.Width *= widthRatio;
            shape.Height *= heightRatio;
        }

        shape.X *= widthRatio;
        shape.Y *= heightRatio;
    }
}
```

## **FAQ**

**Pourquoi les formes sont‑elles déformées ou coupées après le redimensionnement d’une diapositive ?**

Si vous modifiez la taille de la diapositive sans mettre à l’échelle les formes, elles conservent leurs positions et dimensions d’origine et peuvent dépasser de la diapositive. Mettre à l’échelle la largeur et la hauteur avec des rapports différents peut également déformer les formes.

**Le code fourni fonctionne‑t‑il pour tous les types de formes ?**

Le premier exemple modifie directement les limites des formes et est destiné aux diapositives sans tableaux. Le deuxième exemple gère les tableaux séparément. Vérifiez la mise en page résultante, en particulier le texte et les tableaux, car ces exemples ne mettent pas à l’échelle les tailles de police et le contenu des tableaux peut contraindre les hauteurs de lignes.

**Comment redimensionner les tableaux lors du redimensionnement d’une diapositive ?**

Mettez à l’échelle les largeurs des colonnes selon le rapport de largeur et les hauteurs minimales des lignes selon le rapport de hauteur, puis mettez à l’échelle la position du tableau comme indiqué dans le deuxième exemple.

**Ce redimensionnement fonctionnera‑t‑il pour les diapositives maîtres et les diapositives de mise en page ?**

Oui. Le deuxième exemple parcourt [Presentation.Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) et les [LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/layoutslides/) de chaque maître et applique la même logique de redimensionnement à leurs formes.

**Puis‑je changer l’orientation d’une diapositive (portrait/paysage) lors du redimensionnement ?**

Oui. Définissez [SlideSize.Orientation](https://reference.aspose.com/slides/net/aspose.slides/slidesize/orientation/) après avoir modifié la taille de la diapositive et avant de lire les dimensions cibles, afin que les facteurs d’échelle reflètent l’orientation finale.

**Existe‑t‑il une limite à la taille de diapositive que je peux définir ?**

Vous pouvez spécifier des dimensions de diapositive personnalisées avec [SlideSize.SetSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/setsize/). Les dimensions prises en charge dépendent également du format de la présentation et de l’application utilisée pour ouvrir le fichier.

**Comment empêcher les formes avec un rapport d’aspect fixe de se déformer ?**

Utilisez le même facteur d’échelle pour la largeur et la hauteur. Pour adapter la mise en page originale aux nouvelles dimensions de la diapositive, utilisez le plus petit des rapports de largeur et de hauteur pour les deux dimensions et les positions. Cela préserve les proportions mais peut laisser un espace inutilisé le long d’un bord.