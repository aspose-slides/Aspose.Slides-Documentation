---
title: Redimensionner les formes sur les diapositives de présentation en .NET
type: docs
weight: 130
url: /fr/net/re-sizing-shapes-on-slide/
keywords:
  - redimensionner forme
  - modifier la taille de la forme
  - PowerPoint
  - OpenDocument
  - présentation
  - .NET
  - C#
  - Aspose.Slides
description: "Redimensionnez facilement les formes sur les diapositives PowerPoint et OpenDocument avec Aspose.Slides pour .NET - automatisez les ajustements de mise en page des diapositives et augmentez la productivité."
---
## **Vue d'ensemble**

L’une des questions les plus fréquentes des clients d’Aspose.Slides for .NET est de savoir comment redimensionner les formes de façon à ce que, lorsque la taille de la diapositive change, les données ne soient pas tronquées. Cet article technique court montre comment le faire.

## **Redimensionner les formes**

Pour éviter que les formes ne se désalignent lorsque la taille de la diapositive évolue, mettez à jour la position et les dimensions de chaque forme afin qu’elles s’adaptent à la nouvelle mise en page de la diapositive.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Charger le fichier de présentation.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Obtenir la taille originale de la diapositive.
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // Modifier la taille de la diapositive sans mettre à l'échelle les formes existantes.
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // Obtenir la nouvelle taille de la diapositive.
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // Redimensionner et repositionner les formes sur chaque diapositive.
    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            // Mettre à l'échelle la taille de la forme.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // Mettre à l'échelle la position de la forme.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

{{% alert color="info" %}}
Si une diapositive contient un tableau, le code ci‑dessus ne fonctionnera pas correctement. Dans ce cas, chaque cellule du tableau doit être redimensionnée.
{{% /alert %}}

Utilisez le code suivant pour redimensionner les diapositives contenant des tableaux. Pour les tableaux, redimensionnez les hauteurs de ligne et les largeurs de colonne individuellement plutôt que la largeur et la hauteur de la forme — appliquer les deux doublerait l’échelle du tableau et le ferait sortir de la diapositive.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Obtenir la taille originale de la diapositive.
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // Modifier la taille de la diapositive sans mettre à l'échelle les formes existantes.
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // presentation.SlideSize.Orientation = SlideOrienation.Portrait;

    // Obtenir la nouvelle taille de la diapositive.
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    foreach (IMasterSlide master in presentation.Masters)
    {
        foreach (IShape shape in master.Shapes)
        {
            // Mettre à l'échelle la taille de la forme.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // Mettre à l'échelle la position de la forme.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }

        foreach (ILayoutSlide layoutSlide in master.LayoutSlides)
        {
            foreach (IShape shape in layoutSlide.Shapes)
            {
                // Mettre à l'échelle la taille de la forme.
                shape.Height *= heightRatio;
                shape.Width *= widthRatio;

                // Mettre à l'échelle la position de la forme.
                shape.Y *= heightRatio;
                shape.X *= widthRatio;
            }
        }
    }

    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            if (shape is ITable)
            {
                // Mettre à l'échelle la taille du tableau via ses lignes et colonnes.
                ITable table = (ITable)shape;
                foreach (IRow row in table.Rows)
                {
                    row.MinimalHeight *= heightRatio;
                }
                foreach (IColumn column in table.Columns)
                {
                    column.Width *= widthRatio;
                }
            }
            else
            {
                // Mettre à l'échelle la taille de la forme.
                shape.Height *= heightRatio;
                shape.Width *= widthRatio;
            }

            // Mettre à l'échelle la position de la forme.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

### Pourquoi les formes sont‑elles déformées ou tronquées après le redimensionnement d’une diapositive ?

Lorsque vous redimensionnez une diapositive, les formes conservent leur position et leur taille d’origine à moins que l’échelle ne soit explicitement modifiée. Cela peut entraîner une découpe du contenu ou un désalignement des formes.

### Le code fourni fonctionne‑t‑il pour tous les types de forme ?

L’exemple de base fonctionne pour la plupart des types de forme (zones de texte, images, graphiques, etc.). Cependant, pour les tableaux, vous devez gérer les lignes et les colonnes séparément, car la hauteur et la largeur d’un tableau sont déterminées par les dimensions des cellules individuelles.

### Comment redimensionner les tableaux lors du redimensionnement d’une diapositive ?

Vous devez parcourir toutes les lignes et toutes les colonnes du tableau et redimensionner leur hauteur et largeur proportionnellement, comme le montre le deuxième exemple de code.

### Ce redimensionnement fonctionne‑t‑il pour les diapositives maîtres et les diapositives de mise en page ?

Oui, mais vous devez également parcourir les [Masters](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/masters/) et les [LayoutSlides](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/layoutslides/) et appliquer la même logique d’échelle à leurs formes afin d’assurer la cohérence dans toute la présentation.

### Puis‑je changer l’orientation d’une diapositive (portrait/paysage) en même temps que le redimensionnement ?

Oui. Vous pouvez définir [presentation.SlideSize.Orientation](https://reference.aspose.com/slides/fr/net/aspose.slides/islidesize/orientation/) pour changer l’orientation. Assurez‑vous d’ajuster la logique d’échelle en conséquence pour préserver la mise en page.

### Existe‑t‑il une limite à la taille de diapositive que je peux définir ?

Aspose.Slides prend en charge les tailles personnalisées, mais des tailles très importantes peuvent affecter les performances ou la compatibilité avec certaines versions de PowerPoint.

### Comment éviter que les formes à proportion fixe ne soient déformées ?

Vous pouvez vérifier la propriété `AspectRatioLocked` de la forme avant de l’échelonner. Si elle est verrouillée, ajustez la largeur ou la hauteur proportionnellement plutôt que de les mettre à l’échelle individuellement.