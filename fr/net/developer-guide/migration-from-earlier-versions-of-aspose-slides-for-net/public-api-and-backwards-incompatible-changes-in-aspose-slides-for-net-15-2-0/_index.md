---
title: API Public et Changements Incompatibles avec les Versions Précédentes dans Aspose.Slides pour .NET 15.2.0
type: docs
weight: 140
url: /fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/
---

{{% alert color="primary" %}} 

Cette page liste toutes les classes, méthodes, propriétés, etc., [ajoutées](/slides/fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) ou [supprimées](/slides/fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/), ainsi que d'autres changements introduits avec l'API Aspose.Slides pour .NET 15.2.0.

{{% /alert %}} 
## **Changemente de l'API Public**
#### **Les méthodes AddDataPointForDoughnutSeries ont été ajoutées**
Les deux surcharges de la méthode IChartDataPointCollection.AddDataPointForDoughnutSeries() ont été ajoutées pour ajouter des points de données dans les séries de type graphique Doughnut.
#### **La classe Aspose.Slides.SmartArt.SmartArtShape a hérité de la classe Aspose.Slides.GeometryShape**
La classe Aspose.Slides.SmartArt.SmartArtShape a hérité de la classe Aspose.Slides.GeometryShape. Ce changement améliore le modèle d'objet Aspose.Slides et ajoute de nouvelles fonctionnalités à la classe SmartArtShape.
#### **Des méthodes pour supprimer des points de données de graphique et des catégories de graphique par index ont été ajoutées**
La méthode IChartDataPointCollection.RemoveAt(int index) a été ajoutée pour supprimer un point de données de graphique par son index.
La méthode IChartCategoryCollection.RemoveAt(int index) a été ajoutée pour supprimer une catégorie de graphique par son index.
#### **La valeur PptXPptY a été ajoutée à l'énumération Aspose.Slides.Animation.PropertyType**
La valeur PptXPptY a été ajoutée à l'énumération Aspose.Slides.Animation.PropertyType dans le cadre d'un correctif de problème de sérialisation.
#### **La méthode System.Drawing.Color GetAutomaticSeriesColor() a été ajoutée à Aspose.Slides.Charts.IChartSeries**
La méthode GetAutomaticSeriesColor renvoie une couleur automatique de série basée sur l'index de série et le style de graphique. Cette couleur est utilisée par défaut si FillType est égal à NotDefined.

``` csharp



using (Presentation pres = new Presentation())

{

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    for (int i = 0; i < chart.ChartData.Series.Count; i++)

    {

        chart.ChartData.Series[i].GetAutomaticSeriesColor();

    }

}

``` 