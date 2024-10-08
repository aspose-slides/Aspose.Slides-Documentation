---
title: Tableau de Données du Graphique
type: docs
url: /fr/net/chart-data-table/
keywords: "Propriétés de police, tableau de données du graphique, présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "Définir les propriétés de police pour le tableau de données du graphique dans les présentations PowerPoint en C# ou .NET"
---

## **Définir les Propriétés de Police pour le Tableau de Données du Graphique**
Aspose.Slides pour .NET prend en charge le changement de couleur des catégories dans une couleur de série.

1. Instancier un objet de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Ajouter un graphique sur la diapositive.
1. Définir le tableau du graphique.
1. Définir la hauteur de la police.
1. Enregistrer la présentation modifiée.

Un exemple d'échantillon est donné ci-dessous.

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

	chart.HasDataTable = true;

	chart.ChartDataTable.TextFormat.PortionFormat.FontBold = NullableBool.True;
	chart.ChartDataTable.TextFormat.PortionFormat.FontHeight = 20;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```