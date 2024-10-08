---
title: Barre d'Erreur
type: docs
url: /fr/net/error-bar/
keywords: "Barre d'erreur, valeurs de barre d'erreur présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "Ajouter une barre d'erreur aux présentations PowerPoint en C# ou .NET"
---

## **Ajouter une Barre d'Erreur**
Aspose.Slides pour .NET fournit une API simple pour gérer les valeurs des barres d'erreur. Le code d'exemple s'applique lors de l'utilisation d'un type de valeur personnalisé. Pour spécifier une valeur, utilisez la propriété **ErrorBarCustomValues** d'un point de données spécifique dans la collection **DataPoints** de la série :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Ajoutez un graphique à bulles sur la diapositive désirée.
1. Accédez à la première série de graphiques et définissez le format de la barre d'erreur X.
1. Accédez à la première série de graphiques et définissez le format de la barre d'erreur Y.
1. Définir les valeurs des barres et le format.
1. Écrivez la présentation modifiée dans un fichier PPTX.

```c#
// Création d'une présentation vide
using (Presentation presentation = new Presentation())
{
    // Création d'un graphique à bulles
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Ajout de barres d'erreur et définition de son format
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

    // Sauvegarde de la présentation
    presentation.Save("ErrorBars_out.pptx", SaveFormat.Pptx);
}
```



## **Ajouter une Valeur de Barre d'Erreur Personnalisée**
Aspose.Slides pour .NET fournit une API simple pour gérer les valeurs personnalisées des barres d'erreur. Le code d'exemple s'applique lorsque la propriété **IErrorBarsFormat.ValueType** est égale à **Custom**. Pour spécifier une valeur, utilisez la propriété **ErrorBarCustomValues** d'un point de données spécifique dans la collection **DataPoints** de la série :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Ajoutez un graphique à bulles sur la diapositive désirée.
1. Accédez à la première série de graphiques et définissez le format de la barre d'erreur X.
1. Accédez à la première série de graphiques et définissez le format de la barre d'erreur Y.
1. Accédez aux points de données individuels de la série de graphiques et définissez les valeurs de la barre d'erreur pour le point de données individuel de la série.
1. Définir les valeurs des barres et le format.
1. Écrivez la présentation modifiée dans un fichier PPTX.

```c#
// Création d'une présentation vide
using (Presentation presentation = new Presentation())
{
    // Création d'un graphique à bulles
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Ajout de barres d'erreur personnalisées et définition de son format
    IChartSeries series = chart.ChartData.Series[0];
    IErrorBarsFormat errBarX = series.ErrorBarsXFormat;
    IErrorBarsFormat errBarY = series.ErrorBarsYFormat;
    errBarX.IsVisible = true;
    errBarY.IsVisible = true;
    errBarX.ValueType = ErrorBarValueType.Custom;
    errBarY.ValueType = ErrorBarValueType.Custom;

    // Accéder aux points de données de la série de graphiques et définir les valeurs des barres d'erreur pour chaque point
    IChartDataPointCollection points = series.DataPoints;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXPlusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXMinusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYPlusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYMinusValues = DataSourceType.DoubleLiterals;

    // Définir les barres d'erreur pour les points de la série de graphiques
    for (int i = 0; i < points.Count; i++)
    {
        points[i].ErrorBarsCustomValues.XMinus.AsLiteralDouble = i + 1;
        points[i].ErrorBarsCustomValues.XPlus.AsLiteralDouble = i + 1;
        points[i].ErrorBarsCustomValues.YMinus.AsLiteralDouble = i + 1;
        points[i].ErrorBarsCustomValues.YPlus.AsLiteralDouble = i + 1;
    }

    // Sauvegarde de la présentation
    presentation.Save("ErrorBarsCustomValues_out.pptx", SaveFormat.Pptx);
}
```