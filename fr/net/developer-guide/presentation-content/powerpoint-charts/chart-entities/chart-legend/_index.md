---
title: Personnaliser les légendes de graphiques dans les présentations en .NET
linktitle: Légende de graphique
type: docs
url: /fr/net/chart-legend/
keywords:
- légende de graphique
- position de la légende
- taille de police
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Personnalisez les légendes de graphiques avec Aspose.Slides pour .NET afin d'optimiser les présentations PowerPoint grâce à un formatage de légende adapté."
---

## **Positionnement de la légende**
Pour définir les propriétés de la légende, veuillez suivre les étapes ci‑dessous :

- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Obtenir une référence de la diapositive.
- Ajouter un graphique sur la diapositive.
- Définir les propriétés de la légende.
- Enregistrer la présentation au format PPTX.

Dans l'exemple ci‑dessous, nous avons défini la position et la taille de la légende du graphique.
```c#
// Créer une instance de la classe Presentation
Presentation presentation = new Presentation();

// Obtenir une référence de la diapositive
ISlide slide = presentation.Slides[0];

// Ajouter un graphique à colonnes groupées sur la diapositive
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

// Définir les propriétés de la légende
chart.Legend.X = 50 / chart.Width;
chart.Legend.Y = 50 / chart.Height;
chart.Legend.Width = 100 / chart.Width;
chart.Legend.Height = 100 / chart.Height;

// Enregistrer la présentation sur le disque
presentation.Save("Legend_out.pptx", SaveFormat.Pptx);
```




## **Définir la taille de police de la légende**
Aspose.Slides for .NET permet aux développeurs de définir la taille de police de la légende. Veuillez suivre les étapes ci‑dessous :

- Instancier la classe `Presentation`.
- Créer le graphique par défaut.
- Définir la taille de la police.
- Définir la valeur minimale de l'axe.
- Définir la valeur maximale de l'axe.
- Enregistrer la présentation sur le disque.
```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 600, 400);

	chart.Legend.TextFormat.PortionFormat.FontHeight = 20;
	chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
	chart.Axes.VerticalAxis.MinValue = -5;
	chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
	chart.Axes.VerticalAxis.MaxValue = 10;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```



## **Définir la taille de police des légendes individuelles**
Aspose.Slides for .NET permet aux développeurs de définir la taille de police des entrées individuelles de la légende. Veuillez suivre les étapes ci‑dessus :

- Instancier la classe `Presentation`.
- Créer le graphique par défaut.
- Accéder à l'entrée de la légende.
- Définir la taille de la police.
- Définir la valeur minimale de l'axe.
- Définir la valeur maximale de l'axe.
- Enregistrer la présentation sur le disque.
```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
	IChartTextFormat tf = chart.Legend.Entries[1].TextFormat;

	tf.PortionFormat.FontBold = NullableBool.True;
	tf.PortionFormat.FontHeight = 20;
	tf.PortionFormat.FontItalic = NullableBool.True;
	tf.PortionFormat.FillFormat.FillType = FillType.Solid; ;
	tf.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Puis-je activer la légende afin que le graphique réserve automatiquement de l'espace pour elle au lieu de la superposer ?**

Oui. Utilisez le mode sans superposition ([Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/overlay/) = `false`) ; dans ce cas, la zone de tracé se rétrécira pour accueillir la légende.

**Puis-je créer des étiquettes de légende sur plusieurs lignes ?**

Oui. Les longues étiquettes sont automatiquement renvoyées à la ligne lorsque l'espace est insuffisant ; les sauts de ligne forcés sont pris en charge via les caractères de nouvelle ligne dans le nom de la série.

**Comment faire en sorte que la légende suive le jeu de couleurs du thème de la présentation ?**

Ne définissez pas de couleurs, de remplissages ou de polices explicites pour la légende ou son texte. Ils hériteront alors du thème et seront mis à jour correctement lorsque le design changera.