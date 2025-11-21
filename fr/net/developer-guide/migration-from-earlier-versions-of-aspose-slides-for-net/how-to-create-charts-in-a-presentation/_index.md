---
title: Comment créer des graphiques dans les présentations en .NET
linktitle: Créer un graphique
type: docs
weight: 30
url: /fr/net/how-to-create-charts-in-a-presentation/
keywords:
- migration
- créer un graphique
- code hérité
- code moderne
- approche héritée
- approche moderne
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Apprenez à créer des graphiques dans les présentations PowerPoint PPT, PPTX et ODP en .NET avec Aspose.Slides en utilisant les API de graphiques héritées et modernes."
---

{{% alert color="primary" %}} 

Un nouveau [Aspose.Slides for .NET API](/slides/fr/net/) a été publié et ce produit unique prend désormais en charge la génération de documents PowerPoint à partir de zéro ainsi que la modification des présentations existantes.

{{% /alert %}} 
## **Prise en charge du code hérité**
Afin d’utiliser le code hérité développé avec les versions d’Aspose.Slides pour .NET antérieures à la 13.x, vous devez apporter quelques modifications mineures à votre code et il fonctionnera comme auparavant. Toutes les classes qui étaient présentes dans les anciens espaces de noms Aspose.Slides pour .NET sous les espaces de noms Aspose.Slide et Aspose.Slides.Pptx sont maintenant fusionnées dans un seul espace de noms Aspose.Slides. Veuillez consulter le fragment de code simple suivant pour créer un graphique normal à partir de zéro dans une présentation en utilisant l’API Aspose.Slides héritée et suivre les étapes décrivant comment migrer vers la nouvelle API fusionnée.
## **Approche legacy d’Aspose.Slides pour .NET**
```c#
 //Instancier la classe PresentationEx qui représente un fichier PPTX
using (PresentationEx pres = new PresentationEx())
{
	 //Accéder à la première diapositive
	SlideEx sld = pres.Slides[0];

	 // Ajouter un graphique avec des données par défaut
	ChartEx chart = sld.Shapes.AddChart(ChartTypeEx.ClusteredColumn, 0, 0, 500, 500);

	 //Définir le titre du graphique
	chart.ChartTitle.Text.Text = "Sample Title";
	chart.ChartTitle.Text.CenterText = true;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	 //Définir la première série pour afficher les valeurs
	chart.ChartData.Series[0].Labels.ShowValue = true;

	 //Définir l'index de la feuille de données du graphique 
	int defaultWorksheetIndex = 0;

	 //Obtenir la feuille de données du graphique
	ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

	 //Supprimer les séries et catégories générées par défaut
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Clear();
	int s = chart.ChartData.Series.Count;
	s = chart.ChartData.Categories.Count;

	 //Ajouter de nouvelles séries
	chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
	chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

	 //Ajouter de nouvelles catégories
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

	 //Prendre la première série du graphique
	ChartSeriesEx series = chart.ChartData.Series[0];

	 //Maintenant, peupler les données de la série
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	 //Définir la couleur de remplissage pour la série
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Red;


	 //Prendre la deuxième série du graphique
	series = chart.ChartData.Series[1];

	 //Maintenant, peupler les données de la série
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

	 //Définir la couleur de remplissage pour la série
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Green;


	 //Créer des libellés personnalisés pour chaque catégorie de la nouvelle série

	 //Le premier libellé affichera le nom de la catégorie
	DataLabelEx lbl = new DataLabelEx(series);
	lbl.ShowCategoryName = true;
	lbl.Id = 0;
	series.Labels.Add(lbl);

	 //Afficher le nom de la série pour le deuxième libellé
	lbl = new DataLabelEx(series);
	lbl.ShowSeriesName = true;
	lbl.Id = 1;
	series.Labels.Add(lbl);

	 //Afficher la valeur pour le troisième libellé
	lbl = new DataLabelEx(series);
	lbl.ShowValue = true;
	lbl.ShowSeriesName = true;
	lbl.Separator = "/";
	lbl.Id = 2;
	series.Labels.Add(lbl);

	 //Afficher la valeur et le texte personnalisé
	lbl = new DataLabelEx(series);
	lbl.TextFrame.Text = "My text";
	lbl.Id = 3;
	series.Labels.Add(lbl);

	 //Enregistrer la présentation avec le graphique
	pres.Write(@"D:\AsposeChart.pptx");
}
```




## **Nouvelle approche Aspose.Slides pour .NET 13.x**
```csharp
//Instancier la classe Presentation qui représente un fichier PPTX//Instancier la classe Presentation qui représente un fichier PPTX
Presentation pres = new Presentation();

//Accéder à la première diapositive
ISlide sld = pres.Slides[0];

// Ajouter un graphique avec des données par défaut
IChart chart = sld.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 500);

//Définir le titre du graphique
//chart.ChartTitle.TextFrameForOverriding.Text = "Sample Title";
chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

//Définir la première série pour afficher les valeurs
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

//Définir l'index de la feuille de données du graphique
int defaultWorksheetIndex = 0;

//Obtenir la feuille de données du graphique
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//Supprimer les séries et catégories générées par défaut
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
int s = chart.ChartData.Series.Count;
s = chart.ChartData.Categories.Count;

//Ajouter de nouvelles séries
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

//Ajouter de nouvelles catégories
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

//Prendre la première série du graphique
IChartSeries series = chart.ChartData.Series[0];

//Maintenant, peupler les données de la série

series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

//Définir la couleur de remplissage pour la série
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;


//Prendre la deuxième série du graphique
series = chart.ChartData.Series[1];

//Maintenant, peupler les données de la série
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

//Définir la couleur de remplissage pour la série
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Green;


//Créer des libellés personnalisés pour chaque catégorie de la nouvelle série

//Le premier libellé affichera le nom de la catégorie
IDataLabel lbl = series.DataPoints[0].Label;
lbl.DataLabelFormat.ShowCategoryName = true;

lbl = series.DataPoints[1].Label;
lbl.DataLabelFormat.ShowSeriesName = true;

//Afficher la valeur pour le troisième libellé
lbl = series.DataPoints[2].Label;
lbl.DataLabelFormat.ShowValue = true;
lbl.DataLabelFormat.ShowSeriesName = true;
lbl.DataLabelFormat.Separator = "/";

//Enregistrer la présentation avec le graphique
pres.Save("AsposeChart.pptx", SaveFormat.Pptx);
```


Veuillez consulter le fragment de code simple suivant pour créer un graphique en nuage de points à partir de zéro dans une présentation en utilisant l’API Aspose.Slides héritée et voir comment le réaliser avec la nouvelle API fusionnée.

## **Approche legacy d’Aspose.Slides pour .NET**
```c#
using (PresentationEx pres = new PresentationEx())
{
    SlideEx slide = pres.Slides[0];

    //Créer le graphique par défaut
    ChartEx chart = slide.Shapes.AddChart(ChartTypeEx.ScatterWithSmoothLines, 0, 0, 400, 400);

    //Récupérer l'index de la feuille de données du graphique par défaut
    int defaultWorksheetIndex = 0;

    //Accéder à la feuille de données du graphique
    ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

    //Supprimer les séries de démonstration
    chart.ChartData.Series.Clear();

    //Ajouter de nouvelles séries
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

    //Prendre la première série du graphique
    ChartSeriesEx series = chart.ChartData.Series[0];

    //Ajouter un nouveau point (1:3) ici.
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 1));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

    //Ajouter un nouveau point (2:10)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

    //Modifier le type de la série
    series.Type = ChartTypeEx.ScatterWithStraightLinesAndMarkers;

    //Modifier le marqueur de la série du graphique
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Star;

    //Prendre la deuxième série du graphique
    series = chart.ChartData.Series[1];

    //Ajouter un nouveau point (5:2) ici.
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 3, 5));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

    //Ajouter un nouveau point (3:1)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 3, 3));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

    //Ajouter un nouveau point (2:2)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 4, 3, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

    //Ajouter un nouveau point (5:1)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 5, 3, 5));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

    //Modifier le marqueur de la série du graphique
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Circle;

    pres.Write("D:\\AsposeSeriesChart.pptx");
}
```



## **Nouvelle approche Aspose.Slides pour .NET 13.x**
```csharp
Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];

//Création du graphique par défaut
IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);

//Obtention de l'index de la feuille de données du graphique par défaut
int defaultWorksheetIndex = 0;

//Accès à la feuille de données du graphique
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//Supprimer les séries de démonstration
chart.ChartData.Series.Clear();

//Ajouter de nouvelles séries
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

//Prendre la première série du graphique
IChartSeries series = chart.ChartData.Series[0];

//Ajouter un nouveau point (1:3) ici.
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 1), fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

//Ajouter un nouveau point (2:10)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 2), fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

//Modifier le type de la série
series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

//Modification du marqueur de la série du graphique
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Star;

//Prendre la deuxième série du graphique
series = chart.ChartData.Series[1];

//Ajouter un nouveau point (5:2) ici.
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 3, 5), fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

//Ajouter un nouveau point (3:1)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 3, 3), fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

//Ajouter un nouveau point (2:2)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 4, 3, 2), fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

//Ajouter un nouveau point (5:1)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 5, 3, 5), fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

//Modification du marqueur de la série du graphique
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Circle;

pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
```
