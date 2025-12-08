---
title: Tableau de données du graphique
type: docs
url: /fr/net/chart-data-table/
keywords: "Propriétés de police, tableau de données du graphique, présentation PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Définir les propriétés de police pour le tableau de données du graphique dans les présentations PowerPoint en C# ou .NET"
---

## **Définir les propriétés de police pour le tableau de données du graphique**
Aspose.Slides for .NET prend en charge la modification de la couleur des catégories dans une série de couleurs.

1. Instancier l'objet de classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Ajouter un graphique sur la diapositive.
1. Définir le tableau du graphique.
1. Définir la hauteur de la police.
1. Enregistrer la présentation modifiée.

Exemple d’échantillon ci‑dessous est fourni.  
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

**Puis‑je afficher de petites clés de légende à côté des valeurs dans le tableau de données du graphique ?**

Oui. Le tableau de données prend en charge les [legend keys](https://reference.aspose.com/slides/net/aspose.slides.charts/datatable/showlegendkey/), et vous pouvez les activer ou les désactiver.

**Le tableau de données sera‑t‑il conservé lors de l’exportation de la présentation au format PDF, HTML ou images ?**

Oui. Aspose.Slides rend le graphique comme partie de la diapositive, de sorte que le [PDF](/slides/fr/net/convert-powerpoint-to-pdf/)/[HTML](/slides/fr/net/convert-powerpoint-to-html/)/[image](/slides/fr/net/convert-powerpoint-to-png/) exporté inclut le graphique avec son tableau de données.

**Les tableaux de données sont‑ils pris en charge pour les graphiques provenant d’un fichier de modèle ?**

Oui. Pour tout graphique chargé à partir d’une présentation ou d’un modèle existant, vous pouvez vérifier et modifier si un tableau de données [is shown](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/hasdatatable/) à l’aide des propriétés du graphique.

**Comment puis‑je rapidement trouver quels graphiques d’un fichier ont le tableau de données activé ?**

Inspectez la propriété de chaque graphique qui indique si le tableau de données [is shown](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/hasdatatable/) est activée et parcourez les diapositives pour identifier les graphiques où il est activé.