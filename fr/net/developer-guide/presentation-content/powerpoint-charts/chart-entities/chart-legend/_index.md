---
title: Légende du graphique
type: docs
url: /fr/net/chart-legend/
keywords: "Légende du graphique, taille de police de légende, présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "Définir le positionnement et la taille de police de la légende du graphique dans les présentations PowerPoint en C# ou .NET"
---

## **Positionnement de la légende**
Pour définir les propriétés de la légende. Veuillez suivre les étapes ci-dessous :

- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Obtenir la référence de la diapositive.
- Ajouter un graphique sur la diapositive.
- Définir les propriétés de la légende.
- Écrire la présentation en tant que fichier PPTX.

Dans l'exemple ci-dessous, nous avons défini la position et la taille pour la légende du graphique.

```c#
// Créer une instance de la classe Presentation
Presentation presentation = new Presentation();

// Obtenir la référence de la diapositive
ISlide slide = presentation.Slides[0];

// Ajouter un graphique à colonnes groupées sur la diapositive
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

// Définir les propriétés de la légende
chart.Legend.X = 50 / chart.Width;
chart.Legend.Y = 50 / chart.Height;
chart.Legend.Width = 100 / chart.Width;
chart.Legend.Height = 100 / chart.Height;

// Écrire la présentation sur disque
presentation.Save("Legend_out.pptx", SaveFormat.Pptx);
```


## **Définir la taille de police de la légende**
Aspose.Slides pour .NET permet aux développeurs de définir la taille de police de la légende. Veuillez suivre les étapes ci-dessous :

- Instancier la classe `Presentation`.
- Créer le graphique par défaut.
- Définir la taille de police.
- Définir la valeur min de l'axe.
- Définir la valeur max de l'axe.
- Écrire la présentation sur disque.

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


## **Définir la taille de police de la légende individuelle**
Aspose.Slides pour .NET permet aux développeurs de définir la taille de police des entrées de légende individuelles. Veuillez suivre les étapes ci-dessous :

- Instancier la classe `Presentation`.
- Créer le graphique par défaut.
- Accéder à l'entrée de légende.
- Définir la taille de police.
- Définir la valeur min de l'axe.
- Définir la valeur max de l'axe.
- Écrire la présentation sur disque.

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