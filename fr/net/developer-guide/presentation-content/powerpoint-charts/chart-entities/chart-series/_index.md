---
title: Gérer les séries de données de graphique dans les présentations en .NET
linktitle: Séries de données
type: docs
url: /fr/net/chart-series/
keywords:
- séries de graphique
- chevauchement des séries
- couleur de la série
- couleur de la catégorie
- nom de la série
- point de données
- écart de série
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Apprenez à gérer les séries de graphique en C# pour PowerPoint (PPT/PPTX) grâce à des exemples de code pratiques et aux meilleures pratiques pour améliorer vos présentations de données."
---

## **Vue d'ensemble**

Cet article décrit le rôle de [ChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseries/) dans Aspose.Slides for .NET, en se concentrant sur la façon dont les données sont structurées et visualisées dans les présentations. Ces objets fournissent les éléments fondamentaux qui définissent les ensembles de points de données, les catégories et les paramètres d'apparence d'un graphique. En travaillant avec [ChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseries/), les développeurs peuvent intégrer de manière fluide les sources de données sous-jacentes et garder le contrôle total sur la façon dont l'information est affichée, offrant ainsi des présentations dynamiques, axées sur les données, qui transmettent clairement les idées et les analyses.

Une série est une ligne ou une colonne de nombres tracés dans un graphique.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Définir le chevauchement des séries de graphique**

La propriété [IChartSeriesOverlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/properties/overlap) contrôle la façon dont les barres et les colonnes se chevauchent dans un graphique 2D en spécifiant une plage de -100 à 100. Cette propriété est associée au groupe de séries plutôt qu'à une série de graphique individuelle, elle est donc en lecture seule au niveau de la série. Pour configurer les valeurs de chevauchement, utilisez la propriété `ParentSeriesGroup.Overlap` en lecture/écriture, qui applique le chevauchement spécifié à toutes les séries du groupe.

Voici un exemple C# qui montre comment créer une présentation, ajouter un graphique à colonnes groupées, accéder à la première série du graphique, configurer le paramètre de chevauchement, puis enregistrer le résultat au format PPTX :
```cs
sbyte overlap = 30;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Ajoutez un graphique à colonnes groupées avec des données par défaut.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.ChartData.Series[0];
    if (series.Overlap == 0)
    {
        // Définissez le chevauchement des séries.
        series.ParentSeriesGroup.Overlap = overlap;
    }

    // Enregistrez le fichier de présentation sur le disque.
    presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
}
```


Le résultat :

![The series overlap](series_overlap.png)

## **Modifier la couleur de remplissage d’une série**

Aspose.Slides simplifie la personnalisation des couleurs de remplissage des séries de graphique, vous permettant de mettre en évidence des points de données spécifiques et de créer des graphiques attrayants. Cela se fait via l’objet [IFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iformat/), qui prend en charge divers types de remplissage, configurations de couleur et autres options de style avancées. Après avoir ajouté un graphique à une diapositive et accédé à la série souhaitée, il suffit d’obtenir la série et d’appliquer la couleur de remplissage appropriée. Au‑delà des remplissages unis, vous pouvez également exploiter des remplissages en dégradé ou en motif pour une flexibilité de conception accrue. Une fois les couleurs définies selon vos besoins, enregistrez la présentation pour finaliser la mise à jour.

L’exemple de code C# suivant montre comment modifier la couleur de la première série :
```cs
Color seriesColor = Color.Blue;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Ajoutez un graphique à colonnes groupées avec des données par défaut.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // Définissez la couleur de la première série.
    IChartSeries series = chart.ChartData.Series[0];
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColor;

    // Enregistrez le fichier de présentation sur le disque.
    presentation.Save("series_color.pptx", SaveFormat.Pptx);
}
```


Le résultat :

![The color of the series](series_color.png)

## **Modifier le nom d’une série** 

Aspose.Slides offre un moyen simple de modifier les noms des séries de graphique, facilitant ainsi l’étiquetage des données de façon claire et significative. En accédant à la cellule de feuille de calcul correspondante dans les données du graphique, les développeurs peuvent personnaliser la manière dont les données sont présentées. Cette modification est particulièrement utile lorsque les noms des séries doivent être mis à jour ou clarifiés en fonction du contexte des données. Après avoir renommé la série, la présentation peut être enregistrée pour conserver les changements. 

Voici un extrait de code C# illustrant ce processus en action.
```cs
string seriesName = "New name";

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Ajoutez un graphique à colonnes groupées avec des données par défaut.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // Définissez le nom de la première série.
    IChartDataCell seriesCell = chart.ChartData.ChartDataWorkbook.GetCell(0, 0, 1);
    seriesCell.Value = seriesName;

    // Enregistrez le fichier de présentation sur le disque.
    presentation.Save("series_name.pptx", SaveFormat.Pptx);
}
```


Le code C# suivant montre une autre façon de modifier le nom de la série :
```cs
string seriesName = "New name";

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Ajoutez un graphique à colonnes groupées avec des données par défaut.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // Définissez le nom de la première série.
    IChartSeries series = chart.ChartData.Series[0];
    series.Name.AsCells[0].Value = seriesName;

    // Enregistrez le fichier de présentation sur le disque.
    presentation.Save("series_name.pptx", SaveFormat.Pptx);
}
```


Le résultat :

![The series name](series_name.png)

## **Obtenir la couleur de remplissage automatique d’une série**

Aspose.Slides for .NET vous permet d’obtenir la couleur de remplissage automatique d’une série de graphique dans une zone de traçage. Après avoir créé une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), vous pouvez obtenir une référence à la diapositive souhaitée par indice, puis ajouter un graphique en utilisant le type de votre choix (par exemple `ChartType.ClusteredColumn`). En accédant aux séries du graphique, vous pouvez obtenir la couleur de remplissage automatique.

Le code C# ci‑dessous détaille ce processus.
```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Ajoutez un graphique à colonnes groupées avec des données par défaut.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        // Obtenez la couleur de remplissage de la série.
        Color color = chart.ChartData.Series[i].GetAutomaticSeriesColor();
        Console.WriteLine($"Series {i} color: {color.Name}");
    }
}
```


Sortie :
```text
Series 0 color: ff4f81bd
Series 1 color: ffc0504d
Series 2 color: ff9bbb59
```


## **Définir la couleur de remplissage inversée pour une série de graphique**

Lorsque votre série de données contient à la fois des valeurs positives et négatives, appliquer la même couleur à chaque colonne ou barre peut rendre le graphique difficile à lire. Aspose.Slides for .NET vous permet d’assigner une couleur de remplissage inversée — un remplissage séparé appliqué automatiquement aux points de données situés en dessous de zéro — afin que les valeurs négatives ressortent immédiatement. Dans cette section, vous apprendrez comment activer cette option, choisir une couleur appropriée et enregistrer la présentation mise à jour.

L’exemple de code suivant montre l’opération :
```cs
Color inverColor = Color.Red;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
    IChartDataWorkbook workBook = chart.ChartData.ChartDataWorkbook;

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // Ajouter de nouvelles catégories.
    chart.ChartData.Categories.Add(workBook.GetCell(0, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 3, 0, "Category 3"));

    // Ajouter une nouvelle série.
    IChartSeries series = chart.ChartData.Series.Add(workBook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    // Remplir les données de la série.
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 1, 1, -20));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 3, 1, -30));

    // Définir les paramètres de couleur pour la série.
    var seriesColor = series.GetAutomaticSeriesColor();
    series.InvertIfNegative = true;
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColor;
    series.InvertedSolidFillColor.Color = inverColor;

    presentation.Save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
}
```


Le résultat :

![The inverted solid fill color](inverted_solid_fill_color.png)

Vous pouvez inverser la couleur de remplissage pour un seul point de données au lieu de toute la série. Il suffit d’accéder au `IChartDataPoint` souhaité et de définir sa propriété `InvertIfNegative` à true.

L’exemple de code suivant montre comment faire cela :
```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200, true);

    chart.ChartData.Series.Clear();
    IChartSeries series = chart.ChartData.Series.Add(chart.ChartData.ChartDataWorkbook.GetCell(0, "B1"), chart.Type);

    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B2", -5));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B3", 3));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B4", -3));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B5", 1));

    // Inverser la couleur si le point de données à l'index 2 est négatif.
    series.InvertIfNegative = false;
    series.DataPoints[2].InvertIfNegative = true;
                
    presentation.Save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
}
```


## **Effacer les valeurs de points de données spécifiques**

Parfois, un graphique contient des valeurs de test, des valeurs aberrantes ou des entrées obsolètes que vous devez supprimer sans reconstruire l’ensemble de la série. Aspose.Slides for .NET vous permet de cibler n’importe quel point de données par indice, d’en effacer le contenu et d’actualiser instantanément le tracé afin que les points restants se déplacent et que les axes se redimensionnent automatiquement.

L’exemple de code suivant montre l’opération :
```cs
using (Presentation presentation = new Presentation("test_chart.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IChart chart = (IChart)slide.Shapes[0];
    IChartSeries series = chart.ChartData.Series[0];

    foreach (IChartDataPoint dataPoint in series.DataPoints)
    {
        dataPoint.XValue.AsCell.Value = null;
        dataPoint.YValue.AsCell.Value = null;
    }

    series.DataPoints.Clear();

    presentation.Save("clear_data_points.pptx", SaveFormat.Pptx);
}
```


## **Définir la largeur d’écart d’une série**

La largeur d’écart contrôle la quantité d’espace vide entre des colonnes ou barres adjacentes — des écarts plus larges mettent en évidence les catégories individuelles, tandis que des écarts plus étroits créent un aspect plus dense et compact. Grâce à Aspose.Slides for .NET, vous pouvez ajuster finement ce paramètre pour une série entière, obtenant ainsi l’équilibre visuel exact dont votre présentation a besoin sans modifier les données sous‑jacent.

L’exemple de code suivant montre comment définir la largeur d’écart pour une série :
```cs
ushort gapWidth = 30;

// Crée une présentation vide.
using (Presentation presentation = new Presentation())
{
    // Accède à la première diapo.
    ISlide slide = presentation.Slides[0];

    // Ajoute un graphique avec les données par défaut.
    IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 500, 200);

    // Enregistre la présentation sur le disque.
    presentation.Save("default_gap_width.pptx", SaveFormat.Pptx);

    // Définit la valeur GapWidth.
    IChartSeries series = chart.ChartData.Series[0];
    series.ParentSeriesGroup.GapWidth = gapWidth;

    // Enregistre la présentation sur le disque.
    presentation.Save("gap_width_30.pptx", SaveFormat.Pptx);
}
```


Le résultat :

![The gap width](gap_width.png)

## **FAQ**

**Existe‑t‑il une limite au nombre de séries qu’un graphique unique peut contenir ?**

Aspose.Slides n’impose aucune limite fixe au nombre de séries que vous ajoutez. La contrainte pratique est déterminée par la lisibilité du graphique et par la mémoire disponible pour votre application.

**Que faire si les colonnes d’un groupe sont trop proches ou trop éloignées ?**

Ajustez le paramètre `GapWidth` pour cette série (ou son groupe de séries parent). Augmenter la valeur élargit l’espace entre les colonnes, tandis que la diminuer les rapproche.