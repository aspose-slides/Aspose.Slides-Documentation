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
description: "Redimensionnez facilement les formes sur les diapositives PowerPoint et OpenDocument avec Aspose.Slides pour .NET - automatisez les ajustements de mise en page des diapositives et améliorez la productivité."
---

## **Vue d'ensemble**

L'une des questions les plus fréquentes des clients d'Aspose.Slides for .NET porte sur la façon de redimensionner les formes afin que, lorsque la taille de la diapositive change, les données ne soient pas tronquées. Cet article technique court montre comment procéder.

## **Redimensionner les formes**

Pour éviter que les formes ne se désalignent lorsque la taille de la diapositive change, mettez à jour la position et les dimensions de chaque forme afin qu’elles s’adaptent à la nouvelle mise en page de la diapositive.
```c#
// Charger le fichier de présentation.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Obtenir la taille d'origine de la diapositive.
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


{{% alert color="primary" %}}
Si une diapositive contient un tableau, le code ci‑dessus ne fonctionnera pas correctement. Dans ce cas, chaque cellule du tableau doit être redimensionnée.
{{% /alert %}}

Utilisez le code suivant de votre côté pour redimensionner les diapositives contenant des tableaux. Pour les tableaux, définir la largeur ou la hauteur est un cas particulier : vous devez ajuster les hauteurs des lignes individuelles et les largeurs des colonnes pour modifier la taille globale du tableau.
```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Obtenir la taille d'origine de la diapositive.
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
            // Mettre à l'échelle la taille de la forme.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // Mettre à l'échelle la position de la forme.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;

            if (shape is ITable)
            {
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
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Pourquoi les formes sont‑elles déformées ou tronquées après le redimensionnement d’une diapositive ?**

Lors du redimensionnement d’une diapositive, les formes conservent leur position et leur taille d’origine à moins que l’échelle ne soit explicitement modifiée. Cela peut entraîner le recadrage du contenu ou le désalignement des formes.

**Le code fourni fonctionne‑t‑il pour tous les types de formes ?**

L’exemple de base fonctionne pour la plupart des types de formes (zones de texte, images, graphiques, etc.). Cependant, pour les tableaux, vous devez gérer les lignes et les colonnes séparément, car la hauteur et la largeur d’un tableau sont déterminées par les dimensions des cellules individuelles.

**Comment redimensionner les tableaux lors du redimensionnement d’une diapositive ?**

Vous devez parcourir toutes les lignes et colonnes du tableau et redimensionner leur hauteur et largeur proportionnellement, comme le montre le deuxième exemple de code.

**Ce redimensionnement fonctionnera‑t‑il pour les maîtres de diapositive et les diapositives de mise en page ?**

Oui, mais vous devez également parcourir les [Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) et les [LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/presentation/layoutslides/) et appliquer la même logique de mise à l’échelle à leurs formes afin d’assurer la cohérence de l’ensemble de la présentation.

**Puis‑je changer l’orientation d’une diapositive (portrait/paysage) lors du redimensionnement ?**

Oui. Vous pouvez définir [presentation.SlideSize.Orientation](https://reference.aspose.com/slides/net/aspose.slides/islidesize/orientation/) pour modifier l’orientation. Veillez à ajuster la logique de mise à l’échelle en conséquence afin de préserver la mise en page.

**Y a‑t‑il une limite à la taille de diapositive que je peux définir ?**

Aspose.Slides prend en charge les tailles personnalisées, mais des tailles très importantes peuvent affecter les performances ou la compatibilité avec certaines versions de PowerPoint.

**Comment éviter que les formes à ratio d’aspect fixe ne se déforment ?**

Vous pouvez vérifier la propriété `AspectRatioLocked` de la forme avant de la mettre à l’échelle. Si elle est verrouillée, ajustez la largeur ou la hauteur proportionnellement plutôt que de les mettre à l’échelle séparément.