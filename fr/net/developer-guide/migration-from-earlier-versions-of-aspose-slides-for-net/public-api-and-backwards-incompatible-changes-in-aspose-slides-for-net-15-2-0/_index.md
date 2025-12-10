---
title: API publique et modifications incompatibles avec les versions précédentes d’Aspose.Slides pour .NET 15.2.0
linktitle: Aspose.Slides pour .NET 15.2.0
type: docs
weight: 140
url: /fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/
keywords:
- migration
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
description: "Passez en revue les mises à jour de l’API publique et les changements incompatibles d’Aspose.Slides pour .NET afin de migrer facilement vos solutions de présentation PowerPoint PPT, PPTX et ODP."
---

{{% alert color="primary" %}} 

Cette page répertorie toutes les classes, méthodes, propriétés, etc. [ajoutées](/slides/fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) ou [supprimées](/slides/fr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) et les autres changements introduits avec l'API Aspose.Slides for .NET 15.2.0.

{{% /alert %}} 
## **Modifications de l'API publique**
#### **Méthodes AddDataPointForDoughnutSeries ont été ajoutées**
Les deux surcharges de la méthode IChartDataPointCollection.AddDataPointForDoughnutSeries() ont été ajoutées pour insérer des points de données dans les séries de type de graphique Doughnut.  
#### **La classe Aspose.Slides.SmartArt.SmartArtShape a hérité de la classe Aspose.Slides.GeometryShape**
La classe Aspose.Slides.SmartArt.SmartArtShape a été héritée de la classe Aspose.Slides.GeometryShape. Cette modification améliore le modèle d'objets Aspose.Slides et ajoute de nouvelles fonctionnalités à la classe SmartArtShape.  
#### **Des méthodes pour supprimer un point de données de graphique et une catégorie de graphique par indice ont été ajoutées**
La méthode IChartDataPointCollection.RemoveAt(int index) a été ajoutée pour supprimer un point de données de graphique par son indice.  
La méthode IChartCategoryCollection.RemoveAt(int index) a été ajoutée pour supprimer une catégorie de graphique par son indice.  
#### **La valeur PptXPptY a été ajoutée à l'énumération Aspose.Slides.Animation.PropertyType**
La valeur PptXPptY a été ajoutée à l'énumération Aspose.Slides.Animation.PropertyType dans le cadre d'une correction d'un problème de sérialisation.  
#### **La méthode System.Drawing.Color GetAutomaticSeriesColor() a été ajoutée à Aspose.Slides.Charts.IChartSeries**
La méthode GetAutomaticSeriesColor renvoie une couleur automatique de la série basée sur l'indice de la série et le style du graphique. Cette couleur est utilisée par défaut si FillType est égal à NotDefined.

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