---
title: Formater les graphiques de présentation en .NET
linktitle: Formatage de graphiques
type: docs
weight: 60
url: /fr/net/chart-formatting/
keywords:
- format de graphique
- formatage de graphique
- entité de graphique
- propriétés de graphique
- paramètres de graphique
- options de graphique
- propriétés de police
- bordure arrondie
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Apprenez le formatage des graphiques dans Aspose.Slides pour .NET et améliorez votre présentation PowerPoint avec un style professionnel et accrocheur."
---

## **Formater les entités de graphique**
Aspose.Slides for .NET permet aux développeurs d'ajouter des graphiques personnalisés à leurs diapositives depuis le départ. Cet article explique comment formater différentes entités de graphique, y compris les axes de catégorie et de valeur.

Aspose.Slides for .NET fournit une API simple pour gérer différentes entités de graphique et les formater en utilisant des valeurs personnalisées :

1. Créer une instance de la classe **Presentation**.
1. Obtenir la référence d’une diapositive par son indice.
1. Ajouter un graphique avec des données par défaut ainsi que le type souhaité (dans cet exemple nous utiliserons ChartType.LineWithMarkers).
1. Accéder à l'axe des valeurs du graphique et définir les propriétés suivantes :
   1. Définir le **Line format** pour les lignes de la grille principale de l'axe des valeurs
   1. Définir le **Line format** pour les lignes de la grille secondaire de l'axe des valeurs
   1. Définir le **Number Format** pour l'axe des valeurs
   1. Définir les **Min, Max, Major and Minor units** pour l'axe des valeurs
   1. Définir les **Text Properties** pour les données de l'axe des valeurs
   1. Définir le **Title** pour l'axe des valeurs
   1. Définir le **Line Format** pour l'axe des valeurs
1. Accéder à l'axe des catégories du graphique et définir les propriétés suivantes :
   1. Définir le **Line format** pour les lignes de la grille principale de l'axe des catégories
   1. Définir le **Line format** pour les lignes de la grille secondaire de l'axe des catégories
   1. Définir les **Text Properties** pour les données de l'axe des catégories
   1. Définir le **Title** pour l'axe des catégories
   1. Définir le **Label Positioning** pour l'axe des catégories
   1. Définir le **Rotation Angle** pour les libellés de l'axe des catégories
1. Accéder à la légende du graphique et définir les **Text Properties** correspondantes
1. Afficher les légendes du graphique sans qu'elles ne se chevauchent avec le graphique
1. Accéder à l'**Secondary Value Axis** du graphique et définir les propriétés suivantes :
   1. Activer l'**Value Axis** secondaire
   1. Définir le **Line Format** pour l'axe des valeurs secondaire
   1. Définir le **Number Format** pour l'axe des valeurs secondaire
   1. Définir les **Min, Max, Major and Minor units** pour l'axe des valeurs secondaire
1. Tracer maintenant la première série du graphique sur l'axe des valeurs secondaire
1. Définir la couleur de remplissage du mur arrière du graphique
1. Définir la couleur de remplissage de la zone de tracé du graphique
1. Enregistrer la présentation modifiée dans un fichier PPTX
```c#
// Instanciation de la présentation// Instanciation de la présentation
Presentation pres = new Presentation();

// Accessing the first slide
// Accès à la première diapositive
ISlide slide = pres.Slides[0];

// Adding the sample chart
// Ajout du graphique d'exemple
IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

// Setting Chart Titile
// Définition du titre du graphique
chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("");
IPortion chartTitle = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0];
chartTitle.Text = "Sample Chart";
chartTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
chartTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
chartTitle.PortionFormat.FontHeight = 20;
chartTitle.PortionFormat.FontBold = NullableBool.True;
chartTitle.PortionFormat.FontItalic = NullableBool.True;

// Setting Major grid lines format for value axis
// Définition du format des lignes de grille majeures pour l'axe des valeurs
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Blue;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.Width = 5;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.DashStyle = LineDashStyle.DashDot;

// Setting Minor grid lines format for value axis
// Définition du format des lignes de grille mineures pour l'axe des valeurs
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Red;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.Width = 3;

// Setting value axis number format
// Définition du format numérique de l'axe des valeurs
chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Thousands;
chart.Axes.VerticalAxis.NumberFormat = "0.0%";

// Setting chart maximum, minimum values
// Définition des valeurs maximale et minimale du graphique
chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;

chart.Axes.VerticalAxis.MaxValue = 15f;
chart.Axes.VerticalAxis.MinValue = -2f;
chart.Axes.VerticalAxis.MinorUnit = 0.5f;
chart.Axes.VerticalAxis.MajorUnit = 2.0f;

// Setting Value Axis Text Properties
// Définition des propriétés du texte de l'axe des valeurs
IChartPortionFormat txtVal = chart.Axes.VerticalAxis.TextFormat.PortionFormat;
txtVal.FontBold = NullableBool.True;
txtVal.FontHeight = 16;
txtVal.FontItalic = NullableBool.True;
txtVal.FillFormat.FillType = FillType.Solid; ;
txtVal.FillFormat.SolidFillColor.Color = Color.DarkGreen;
txtVal.LatinFont = new FontData("Times New Roman");

// Setting value axis title
// Définition du titre de l'axe des valeurs
chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("");
IPortion valtitle = chart.Axes.VerticalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
valtitle.Text = "Primary Axis";
valtitle.PortionFormat.FillFormat.FillType = FillType.Solid;
valtitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
valtitle.PortionFormat.FontHeight = 20;
valtitle.PortionFormat.FontBold = NullableBool.True;
valtitle.PortionFormat.FontItalic = NullableBool.True;

// Setting value axis line format : Now Obselete
// Définition du format de ligne de l'axe des valeurs : maintenant obsolète
// chart.Axes.VerticalAxis.aVerticalAxis.l.AxisLine.Width = 10;
// chart.Axes.VerticalAxis.AxisLine.FillFormat.FillType = FillType.Solid;
// Chart.Axes.VerticalAxis.AxisLine.FillFormat.SolidFillColor.Color = Color.Red;

// Setting Major grid lines format for Category axis
// Définition du format des lignes de grille majeures pour l'axe des catégories
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Green;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.Width = 5;

// Setting Minor grid lines format for Category axis
// Définition du format des lignes de grille mineures pour l'axe des catégories
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Yellow;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.Width = 3;

// Setting Category Axis Text Properties
// Définition des propriétés du texte de l'axe des catégories
IChartPortionFormat txtCat = chart.Axes.HorizontalAxis.TextFormat.PortionFormat;
txtCat.FontBold = NullableBool.True;
txtCat.FontHeight = 16;
txtCat.FontItalic = NullableBool.True;
txtCat.FillFormat.FillType = FillType.Solid; ;
txtCat.FillFormat.SolidFillColor.Color = Color.Blue;
txtCat.LatinFont = new FontData("Arial");

// Setting Category Titile
// Définition du titre de la catégorie
chart.Axes.HorizontalAxis.HasTitle = true;
chart.Axes.HorizontalAxis.Title.AddTextFrameForOverriding("");

IPortion catTitle = chart.Axes.HorizontalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
catTitle.Text = "Sample Category";
catTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
catTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
catTitle.PortionFormat.FontHeight = 20;
catTitle.PortionFormat.FontBold = NullableBool.True;
catTitle.PortionFormat.FontItalic = NullableBool.True;

// Setting category axis lable position
// Définition de la position des libellés de l'axe des catégories
chart.Axes.HorizontalAxis.TickLabelPosition = TickLabelPositionType.Low;

// Setting category axis lable rotation angle
// Définition de l'angle de rotation des libellés de l'axe des catégories
chart.Axes.HorizontalAxis.TickLabelRotationAngle = 45;

// Setting Legends Text Properties
// Définition des propriétés du texte des légendes
IChartPortionFormat txtleg = chart.Legend.TextFormat.PortionFormat;
txtleg.FontBold = NullableBool.True;
txtleg.FontHeight = 16;
txtleg.FontItalic = NullableBool.True;
txtleg.FillFormat.FillType = FillType.Solid; ;
txtleg.FillFormat.SolidFillColor.Color = Color.DarkRed;

// Set show chart legends without overlapping chart
// Définir l'affichage des légendes du graphique sans chevaucher le graphique

chart.Legend.Overlay = true;
            
// Ploting first series on secondary value axis
// Tracé de la première série sur l'axe des valeurs secondaire
// Chart.ChartData.Series[0].PlotOnSecondAxis = true;

// Setting chart back wall color
// Définition de la couleur du mur arrière du graphique
chart.BackWall.Thickness = 1;
chart.BackWall.Format.Fill.FillType = FillType.Solid;
chart.BackWall.Format.Fill.SolidFillColor.Color = Color.Orange;

chart.Floor.Format.Fill.FillType = FillType.Solid;
chart.Floor.Format.Fill.SolidFillColor.Color = Color.Red;
// Setting Plot area color
// Définition de la couleur de la zone de tracé
chart.PlotArea.Format.Fill.FillType = FillType.Solid;
chart.PlotArea.Format.Fill.SolidFillColor.Color = Color.LightCyan;

// Save Presentation
// Enregistrer la présentation
pres.Save("FormattedChart_out.pptx", SaveFormat.Pptx);
```


## **Définir les propriétés de police pour un graphique**
Aspose.Slides for .NET prend en charge la définition des propriétés liées à la police pour le graphique. Veuillez suivre les étapes ci-dessous pour définir les propriétés de police du graphique.

- Instancier l’objet de la classe Presentation.
- Ajouter un graphique à la diapositive.
- Définir la hauteur de la police.
- Enregistrer la présentation modifiée.

```c#
using (Presentation pres = new Presentation())
{               
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.TextFormat.PortionFormat.FontHeight = 20;
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
    pres.Save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
}
```


## **Définir le format numérique**
Aspose.Slides for .NET fournit une API simple pour gérer le format des données de graphique :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenir la référence d’une diapositive par son indice.
1. Ajouter un graphique avec des données par défaut ainsi que le type souhaité (cet exemple utilise **ChartType.ClusteredColumn**).
1. Définir le format numérique prédéfini parmi les valeurs prédéfinies possibles.
1. Parcourir les cellules de données du graphique dans chaque série et définir le format numérique des données du graphique.
1. Enregistrer la présentation.
1. Définir le format numérique personnalisé.
1. Parcourir les cellules de données du graphique dans chaque série et définir un format numérique différent pour les données du graphique.
1. Enregistrer la présentation.
```c#
// Instancier la présentation// Instancier la présentation
Presentation pres = new Presentation();

// Accéder à la première diapositive de la présentation
ISlide slide = pres.Slides[0];

// Ajout d'un graphique à colonnes groupées par défaut
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

// Accès à la collection des séries du graphique
IChartSeriesCollection series = chart.ChartData.Series;

// Définition du format numérique prédéfini
// Parcourir chaque série du graphique
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


Les valeurs de format numérique prédéfini possibles, ainsi que leur index prédéfini, sont indiquées ci-dessous :

|**0**|General|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **Définir les bordures arrondies de la zone du graphique**
Aspose.Slides for .NET prend en charge la définition de la zone du graphique. Les propriétés **IChart.HasRoundedCorners** et **Chart.HasRoundedCorners** ont été ajoutées dans Aspose.Slides. 

1. Instancier l’objet de la classe `Presentation`.
1. Ajouter un graphique à la diapositive.
1. Définir le type de remplissage et la couleur de remplissage du graphique
1. Définir la propriété round corner sur True.
1. Enregistrer la présentation modifiée.

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


## **FAQ**

**Puis-je définir des remplissages semi-transparents pour les colonnes/zones tout en conservant le contour opaque ?**

Oui. La transparence du remplissage et le contour sont configurés séparément. Ceci est utile pour améliorer la lisibilité de la grille et des données dans des visualisations denses.

**Comment gérer les libellés de données lorsqu'ils se chevauchent ?**

Réduisez la taille de la police, désactivez les composants de libellé non essentiels (par exemple, les catégories), définissez le décalage/la position du libellé, affichez les libellés uniquement pour les points sélectionnés si nécessaire, ou passez au format « valeur + légende ».

**Puis-je appliquer des remplissages en dégradé ou en motif aux séries ?**

Oui. Les remplissages plein et en dégradé/motif sont généralement disponibles. En pratique, utilisez les dégradés avec parcimonie et évitez les combinaisons qui réduisent le contraste avec la grille et le texte.