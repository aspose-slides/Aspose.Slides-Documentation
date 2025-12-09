---
title: Personnalisez les tableaux de données des graphiques dans les présentations en .NET
linktitle: Tableau de données
type: docs
url: /fr/net/chart-data-table/
keywords:
- données du graphique
- tableau de données
- propriétés de police
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Personnalisez les tableaux de données des graphiques en .NET pour PPT et PPTX avec Aspose.Slides afin d'améliorer l'efficacité et l'attrait des présentations."
---

## **Définir les propriétés de police pour le tableau de données du graphique**
Aspose.Slides pour .NET fournit la prise en charge de la modification de la couleur des catégories dans une couleur de série.  

1. Instancier l'objet de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Ajouter un graphique sur la diapositive.
1. Définir le tableau du graphique.
1. Définir la hauteur de police.
1. Enregistrer la présentation modifiée.

Un exemple d'échantillon est fourni ci-dessous.  
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


## **FAQ**

**Puis-je afficher de petites clés de légende à côté des valeurs dans le tableau de données du graphique ?**

Oui. Le tableau de données prend en charge les [clés de légende](https://reference.aspose.com/slides/net/aspose.slides.charts/datatable/showlegendkey/), et vous pouvez les activer ou les désactiver.

**Le tableau de données sera-t-il conservé lors de l'exportation de la présentation vers PDF, HTML ou images ?**

Oui. Aspose.Slides rend le graphique comme partie de la diapositive, de sorte que le [PDF](/slides/fr/net/convert-powerpoint-to-pdf/)/[HTML](/slides/fr/net/convert-powerpoint-to-html/)/[image](/slides/fr/net/convert-powerpoint-to-png/) exporté inclut le graphique avec son tableau de données.

**Les tableaux de données sont-ils pris en charge pour les graphiques provenant d'un fichier modèle ?**

Oui. Pour tout graphique chargé à partir d'une présentation ou d'un modèle existant, vous pouvez vérifier et modifier si un tableau de données [est affiché](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/hasdatatable/) à l'aide des propriétés du graphique.

**Comment puis-je rapidement identifier quels graphiques d'un fichier ont le tableau de données activé ?**

Inspectez la propriété de chaque graphique qui indique si le tableau de données [est affiché](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/hasdatatable/) et parcourez les diapositives pour identifier les graphiques où il est activé.