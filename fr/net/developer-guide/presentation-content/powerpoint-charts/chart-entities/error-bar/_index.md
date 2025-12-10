---
title: Personnaliser les barres d'erreur dans les graphiques de présentation en .NET
linktitle: Barre d'erreur
type: docs
url: /fr/net/error-bar/
keywords:
- barre d'erreur
- valeur personnalisée
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Découvrez comment ajouter et personnaliser les barres d'erreur dans les graphiques avec Aspose.Slides pour .NET — optimisez les visualisations de données dans les présentations PowerPoint."
---

## **Ajouter des barres d'erreur**
Aspose.Slides for .NET fournit une API simple pour gérer les valeurs de barres d'erreur. Le code d'exemple s'applique lors de l'utilisation d'un type de valeur personnalisé. Pour spécifier une valeur, utilisez la propriété **ErrorBarCustomValues** d'un point de données spécifique dans la collection **DataPoints** de la série :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Ajoutez un graphique à bulles sur la diapositive souhaitée.
1. Accédez à la première série du graphique et définissez le format de la barre d'erreur X.
1. Accédez à la première série du graphique et définissez le format de la barre d'erreur Y.
1. Définissez les valeurs et le format des barres.
1. Enregistrez la présentation modifiée dans un fichier PPTX.
```c#
// Création d'une présentation vide
using (Presentation presentation = new Presentation())
{
    // Création d'un graphique à bulles
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Ajout de barres d'erreur et définition de leur format
    IErrorBarsFormat errBarX = chart.ChartData.Series[0].ErrorBarsXFormat;
    IErrorBarsFormat errBarY = chart.ChartData.Series[0].ErrorBarsYFormat;
    errBarX.IsVisible = true;
    errBarY.IsVisible = true;
    errBarX.ValueType = ErrorBarValueType.Fixed;
    errBarX.Value = 0.1f;
    errBarY.ValueType = ErrorBarValueType.Percentage;
    errBarY.Value = 5;
    errBarX.Type = ErrorBarType.Plus;
    errBarY.Format.Line.Width = 2;
    errBarX.HasEndCap = true;

    // Enregistrement de la présentation
    presentation.Save("ErrorBars_out.pptx", SaveFormat.Pptx);
}
```




## **Ajouter des valeurs de barres d'erreur personnalisées**
Aspose.Slides for .NET fournit une API simple pour gérer les valeurs de barres d'erreur personnalisées. Le code d'exemple s'applique lorsque la propriété **IErrorBarsFormat.ValueType** est égale à **Custom**. Pour spécifier une valeur, utilisez la propriété **ErrorBarCustomValues** d'un point de données spécifique dans la collection **DataPoints** de la série :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Ajoutez un graphique à bulles sur la diapositive souhaitée.
1. Accédez à la première série du graphique et définissez le format de la barre d'erreur X.
1. Accédez à la première série du graphique et définissez le format de la barre d'erreur Y.
1. Accédez aux points de données individuels de la série du graphique et définissez les valeurs de la barre d'erreur pour chaque point de données de la série.
1. Définissez les valeurs et le format des barres.
1. Enregistrez la présentation modifiée dans un fichier PPTX.
```c#
    // Création d'une présentation vide
    using (Presentation presentation = new Presentation())
    {
        // Création d'un graphique à bulles
        IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

        // Ajout de barres d'erreur personnalisées et définition de leur format
        IChartSeries series = chart.ChartData.Series[0];
        IErrorBarsFormat errBarX = series.ErrorBarsXFormat;
        IErrorBarsFormat errBarY = series.ErrorBarsYFormat;
        errBarX.IsVisible = true;
        errBarY.IsVisible = true;
        errBarX.ValueType = ErrorBarValueType.Custom;
        errBarY.ValueType = ErrorBarValueType.Custom;

        // Accès au point de données de la série du graphique et définition des valeurs des barres d'erreur pour le point individuel
        IChartDataPointCollection points = series.DataPoints;
        points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXPlusValues = DataSourceType.DoubleLiterals;
        points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXMinusValues = DataSourceType.DoubleLiterals;
        points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYPlusValues = DataSourceType.DoubleLiterals;
        points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYMinusValues = DataSourceType.DoubleLiterals;

        // Définition des barres d'erreur pour les points de la série du graphique
        for (int i = 0; i < points.Count; i++)
        {
            points[i].ErrorBarsCustomValues.XMinus.AsLiteralDouble = i + 1;
            points[i].ErrorBarsCustomValues.XPlus.AsLiteralDouble = i + 1;
            points[i].ErrorBarsCustomValues.YMinus.AsLiteralDouble = i + 1;
            points[i].ErrorBarsCustomValues.YPlus.AsLiteralDouble = i + 1;
        }

        // Enregistrement de la présentation
        presentation.Save("ErrorBarsCustomValues_out.pptx", SaveFormat.Pptx);
    }
```


## **FAQ**

**Que se passe-t-il avec les barres d'erreur lors de l'exportation d'une présentation vers PDF ou des images ?**

Elles sont rendues comme partie du graphique et conservées lors de la conversion avec le reste du formatage du graphique, en supposant une version ou un moteur compatible.

**Les barres d'erreur peuvent-elles être combinées avec des repères et des étiquettes de données ?**

Oui. Les barres d'erreur sont un élément séparé et sont compatibles avec les repères et les étiquettes de données ; si les éléments se chevauchent, il peut être nécessaire d'ajuster le formatage.

**Où puis-je trouver la liste des propriétés et des énumérations pour travailler avec les barres d'erreur dans l'API ?**

Dans la référence de l'API : la classe [ErrorBarsFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/errorbarsformat/) et les énumérations associées [ErrorBarType](https://reference.aspose.com/slides/net/aspose.slides.charts/errorbartype/) et [ErrorBarValueType](https://reference.aspose.com/slides/net/aspose.slides.charts/errorbarvaluetype/).