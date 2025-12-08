---
title: Légende du graphique
type: docs
url: /fr/net/chart-legend/
keywords: "Légende de graphique, taille de police de légende, présentation PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Définir le positionnement et la taille de police de la légende du graphique dans les présentations PowerPoint en C# ou .NET"
---

## **Positionnement de la légende**
Pour définir les propriétés de la légende, veuillez suivre les étapes ci‑dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Obtenez la référence de la diapositive.
- Ajoutez un graphique sur la diapositive.
- Définissez les propriétés de la légende.
- Enregistrez la présentation au format PPTX.

Dans l'exemple ci‑dessous, nous avons défini la position et la taille de la légende du graphique.
```c#
// Créez une instance de la classe Presentation
Presentation presentation = new Presentation();

// Obtenez la référence de la diapositive
ISlide slide = presentation.Slides[0];

// Ajoutez un graphique en colonnes groupées sur la diapositive
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

// Définir les propriétés de la légende
chart.Legend.X = 50 / chart.Width;
chart.Legend.Y = 50 / chart.Height;
chart.Legend.Width = 100 / chart.Width;
chart.Legend.Height = 100 / chart.Height;

// Enregistrez la présentation sur le disque
presentation.Save("Legend_out.pptx", SaveFormat.Pptx);
```


## **Définir la taille de police de la légende**
Aspose.Slides for .NET permet aux développeurs de définir la taille de police de la légende. Veuillez suivre les étapes ci‑dessous :

- Instanciez la classe `Presentation`.
- Créez le graphique par défaut.
- Définissez la taille de la police.
- Définissez la valeur minimale de l'axe.
- Définissez la valeur maximale de l'axe.
- Enregistrez la présentation sur le disque.
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


## **Définir la taille de police d'une entrée de légende individuelle**
Aspose.Slides for .NET permet aux développeurs de définir la taille de police des entrées individuelles de la légende. Veuillez suivre les étapes ci‑dessous :

- Instanciez la classe `Presentation`.
- Créez le graphique par défaut.
- Accédez à l'entrée de légende.
- Définissez la taille de la police.
- Définissez la valeur minimale de l'axe.
- Définissez la valeur maximale de l'axe.
- Enregistrez la présentation sur le disque.
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

**Puis-je activer la légende afin que le graphique réserve automatiquement de l'espace pour celle-ci au lieu de la superposer ?**

Oui. Utilisez le mode non-superposition ([Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/overlay/) = `false`); dans ce cas, la zone de traçage sera réduite pour accueillir la légende.

**Puis-je créer des libellés de légende sur plusieurs lignes ?**

Oui. Les libellés longs passent automatiquement à la ligne lorsque l'espace est insuffisant; les sauts de ligne forcés sont pris en charge via les caractères de nouvelle ligne dans le nom de la série.

**Comment faire en sorte que la légende suive le schéma de couleurs du thème de la présentation ?**

Ne définissez pas de couleurs/fills/polices explicites pour la légende ou son texte. Ils hériteront alors du thème et seront mis à jour correctement lorsque le design changera.