---
title: Formatage des Graphiques
type: docs
weight: 60
url: /net/chart-formatting/
keywords: "Entités de graphique, propriétés de graphique, présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "Formater les entités de graphique dans les présentations PowerPoint en C# ou .NET"
---

## **Format des Entités de Graphique**
Aspose.Slides pour .NET permet aux développeurs d'ajouter des graphiques personnalisés à leurs diapositives à partir de zéro. Cet article explique comment formater différentes entités de graphique, y compris l'axe des catégories et l'axe des valeurs.

Aspose.Slides pour .NET fournit une API simple pour gérer différentes entités de graphique et les formater en utilisant des valeurs personnalisées :

1. Créer une instance de la classe **Presentation**.
1. Obtenir une référence à la diapositive par son index.
1. Ajouter un graphique avec des données par défaut ainsi que tout type désiré (dans cet exemple nous utiliserons ChartType.LineWithMarkers).
1. Accéder à l'Axe des Valeurs du graphique et définir les propriétés suivantes :
   1. Définir le **Format de ligne** pour les lignes de grille majeures de l'Axe des Valeurs
   1. Définir le **Format de ligne** pour les lignes de grille mineures de l'Axe des Valeurs
   1. Définir le **Format numérique** pour l'Axe des Valeurs
   1. Définir les **Unités Minimales, Maximales, Majeures et Mineures** pour l'Axe des Valeurs
   1. Définir les **Propriétés de texte** pour les données de l'Axe des Valeurs
   1. Définir le **Titre** pour l'Axe des Valeurs
   1. Définir le **Format de ligne** pour l'Axe des Valeurs
1. Accéder à l'Axe des Catégories du graphique et définir les propriétés suivantes :
   1. Définir le **Format de ligne** pour les lignes de grille majeures de l'Axe des Catégories
   1. Définir le **Format de ligne** pour les lignes de grille mineures de l'Axe des Catégories
   1. Définir les **Propriétés de texte** pour les données de l'Axe des Catégories
   1. Définir le **Titre** pour l'Axe des Catégories
   1. Définir le **Positionnement des Étiquettes** pour l'Axe des Catégories
   1. Définir l'**Angle de Rotation** pour les étiquettes de l'Axe des Catégories
1. Accéder à la Légende du graphique et définir les **Propriétés de texte** pour celles-ci
1. Afficher les légendes du graphique sans chevauchement du graphique
1. Accéder à l'**Axe des Valeurs Secondaires** du graphique et définir les propriétés suivantes :
   1. Activer l'**Axe des Valeurs Secondaires**
   1. Définir le **Format de ligne** pour l'Axe des Valeurs Secondaires
   1. Définir le **Format numérique** pour l'Axe des Valeurs Secondaires
   1. Définir les **Unités Minimales, Maximales, Majeures et Mineures** pour l'Axe des Valeurs Secondaires
1. Maintenant, tracer la première série de graphique sur l'Axe des Valeurs Secondaires
1. Définir la couleur de remplissage du mur arrière du graphique
1. Définir la couleur de remplissage de la zone de tracé du graphique
1. Écrire la présentation modifiée dans un fichier PPTX

```c#
// Instantiation de la présentation
Presentation pres = new Presentation();

// Accès à la première diapositive
ISlide slide = pres.Slides[0];

// Ajout du graphique d'exemple
IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

// Définition du Titre du Graphique
chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("");
IPortion chartTitle = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0];
chartTitle.Text = "Graphique d'Exemple";
chartTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
chartTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
chartTitle.PortionFormat.FontHeight = 20;
chartTitle.PortionFormat.FontBold = NullableBool.True;
chartTitle.PortionFormat.FontItalic = NullableBool.True;

// Définition du format des lignes de grille majeures pour l'axe des valeurs
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Blue;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.Width = 5;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.DashStyle = LineDashStyle.DashDot;

// Définition du format des lignes de grille mineures pour l'axe des valeurs
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Red;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.Width = 3;

// Définition du format numérique de l'axe des valeurs
chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Thousands;
chart.Axes.VerticalAxis.NumberFormat = "0.0%";

// Définition des valeurs maximales et minimales du graphique
chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;

chart.Axes.VerticalAxis.MaxValue = 15f;
chart.Axes.VerticalAxis.MinValue = -2f;
chart.Axes.VerticalAxis.MinorUnit = 0.5f;
chart.Axes.VerticalAxis.MajorUnit = 2.0f;

// Définition des Propriétés de Texte de l'Axe des Valeurs
IChartPortionFormat txtVal = chart.Axes.VerticalAxis.TextFormat.PortionFormat;
txtVal.FontBold = NullableBool.True;
txtVal.FontHeight = 16;
txtVal.FontItalic = NullableBool.True;
txtVal.FillFormat.FillType = FillType.Solid; ;
txtVal.FillFormat.SolidFillColor.Color = Color.DarkGreen;
txtVal.LatinFont = new FontData("Times New Roman");

// Définition du titre de l'axe des valeurs
chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("");
IPortion valtitle = chart.Axes.VerticalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
valtitle.Text = "Axe Principal";
valtitle.PortionFormat.FillFormat.FillType = FillType.Solid;
valtitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
valtitle.PortionFormat.FontHeight = 20;
valtitle.PortionFormat.FontBold = NullableBool.True;
valtitle.PortionFormat.FontItalic = NullableBool.True;

// Définition du format de ligne de l'axe des valeurs : Maintenant obsolète
// chart.Axes.VerticalAxis.aVerticalAxis.l.AxisLine.Width = 10;
// chart.Axes.VerticalAxis.AxisLine.FillFormat.FillType = FillType.Solid;
// Chart.Axes.VerticalAxis.AxisLine.FillFormat.SolidFillColor.Color = Color.Red;

// Définition du format des lignes de grille majeures pour l'axe des catégories
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Green;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.Width = 5;

// Définition du format des lignes de grille mineures pour l'axe des catégories
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Yellow;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.Width = 3;

// Définition des Propriétés de Texte de l'Axe des Catégories
IChartPortionFormat txtCat = chart.Axes.HorizontalAxis.TextFormat.PortionFormat;
txtCat.FontBold = NullableBool.True;
txtCat.FontHeight = 16;
txtCat.FontItalic = NullableBool.True;
txtCat.FillFormat.FillType = FillType.Solid; ;
txtCat.FillFormat.SolidFillColor.Color = Color.Blue;
txtCat.LatinFont = new FontData("Arial");

// Définition du Titre de l'Axe des Catégories
chart.Axes.HorizontalAxis.HasTitle = true;
chart.Axes.HorizontalAxis.Title.AddTextFrameForOverriding("");

IPortion catTitle = chart.Axes.HorizontalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
catTitle.Text = "Catégorie d'Exemple";
catTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
catTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
catTitle.PortionFormat.FontHeight = 20;
catTitle.PortionFormat.FontBold = NullableBool.True;
catTitle.PortionFormat.FontItalic = NullableBool.True;

// Définition de la position des étiquettes de l'axe des catégories
chart.Axes.HorizontalAxis.TickLabelPosition = TickLabelPositionType.Low;

// Définition de l'angle de rotation des étiquettes de l'axe des catégories
chart.Axes.HorizontalAxis.TickLabelRotationAngle = 45;

// Définition des Propriétés de Texte des Légendes
IChartPortionFormat txtleg = chart.Legend.TextFormat.PortionFormat;
txtleg.FontBold = NullableBool.True;
txtleg.FontHeight = 16;
txtleg.FontItalic = NullableBool.True;
txtleg.FillFormat.FillType = FillType.Solid; ;
txtleg.FillFormat.SolidFillColor.Color = Color.DarkRed;

// Afficher les légendes du graphique sans chevauchement du graphique

chart.Legend.Overlay = true;
            
// Tracer la première série sur l'axe des valeurs secondaires
// Chart.ChartData.Series[0].PlotOnSecondAxis = true;

// Définition de la couleur de remplissage du mur arrière du graphique
chart.BackWall.Thickness = 1;
chart.BackWall.Format.Fill.FillType = FillType.Solid;
chart.BackWall.Format.Fill.SolidFillColor.Color = Color.Orange;

chart.Floor.Format.Fill.FillType = FillType.Solid;
chart.Floor.Format.Fill.SolidFillColor.Color = Color.Red;
// Définition de la couleur de la zone de tracé
chart.PlotArea.Format.Fill.FillType = FillType.Solid;
chart.PlotArea.Format.Fill.SolidFillColor.Color = Color.LightCyan;

// Sauvegarder la Présentation
pres.Save("FormattedChart_out.pptx", SaveFormat.Pptx);
```



## **Définir les Propriétés de la Police pour le Graphique**
Aspose.Slides pour .NET fournit un support pour définir les propriétés liées à la police pour le graphique. Veuillez suivre les étapes ci-dessous pour définir les propriétés de la police pour le graphique.

- Instancier un objet de classe Presentation.
- Ajouter un graphique à la diapositive.
- Définir la hauteur de la police.
- Enregistrer la présentation modifiée.

Un exemple de code est donné ci-dessous.

```c#
using (Presentation pres = new Presentation())
{               
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.TextFormat.PortionFormat.FontHeight = 20;
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
    pres.Save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
}
```




## **Définir le Format des Nombres**
Aspose.Slides pour .NET fournit une API simple pour gérer le format des données de graphique :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenir une référence à la diapositive par son index.
1. Ajouter un graphique avec des données par défaut ainsi que tout type désiré (cet exemple utilise **ChartType.ClusteredColumn**).
1. Définir le format numérique prédéfini à partir des valeurs prédéfinies possibles.
1. Parcourir chaque cellule de données dans chaque série de graphique et définir le format numérique des données du graphique.
1. Enregistrer la présentation.
1. Définir le format numérique personnalisé.
1. Parcourir chaque cellule de données à l'intérieur de chaque série de graphique et définir un format numérique de graphique différent.
1. Enregistrer la présentation.

```c#
// Instantiation de la présentation
Presentation pres = new Presentation();

// Accès à la première diapositive de la présentation
ISlide slide = pres.Slides[0];

// Ajout d'un graphique à barres groupées par défaut
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

// Accès à la collection de séries de graphique
IChartSeriesCollection series = chart.ChartData.Series;

// Définition du format numérique prédéfini
// Parcourir chaque série de graphique
foreach (ChartSeries ser in series)
{
    // Parcourir chaque cellule de données dans la série
    foreach (IChartDataPoint cell in ser.DataPoints)
    {
        // Définir le format numérique
        cell.Value.AsCell.PresetNumberFormat = 10; //0.00%
    }
}

// Enregistrement de la présentation
pres.Save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
```

Les valeurs possibles de format numérique prédéfini ainsi que leur index prédéfini qui peuvent être utilisées sont données ci-dessous :

|**0**|Général|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Rouge$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Rouge$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/j/aa|
|**15**|j-mmm-aa|
|**16**|j-mmm|
|**17**|mmm-aa|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/j/aa h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Rouge-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Rouge-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**|[mm:ss.0](http://mmss.0)|
|**48**|##0.0E+00|
|**49**|@|

## **Définir les Bordures Arrondies de la Zone du Graphique**
Aspose.Slides pour .NET fournit un support pour définir la zone du graphique. Les propriétés **IChart.HasRoundedCorners** et **Chart.HasRoundedCorners** ont été ajoutées dans Aspose.Slides.

1. Instancier un objet de classe `Presentation`.
1. Ajouter un graphique à la diapositive.
1. Définir le type de remplissage et la couleur de remplissage du graphique.
1. Définir la propriété des coins arrondis sur True.
1. Enregistrer la présentation modifiée.

Un exemple de code est donné ci-dessous.

```c#
using (Presentation presentation = new Presentation())
{
	ISlide slide = presentation.Slides[0];
	IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
	chart.LineFormat.FillFormat.FillType = FillType.Solid;
	chart.LineFormat.Style = LineStyle.Single;
	chart.HasRoundedCorners = true;

	presentation.Save("out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```