---
title: Formater les graphiques de présentation en .NET
linktitle: Mise en forme des graphiques
type: docs
weight: 60
url: /fr/net/chart-formatting/
keywords:
- format de graphique
- mise en forme du graphique
- entité de graphique
- propriétés du graphique
- paramètres du graphique
- options du graphique
- propriétés de police
- bordure arrondie
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Apprenez la mise en forme des graphiques dans Aspose.Slides pour .NET et améliorez votre présentation PowerPoint avec un style professionnel et attrayant."
---

## **Format des entités du graphique**
Aspose.Slides for .NET permet aux développeurs d’ajouter des graphiques personnalisés à leurs diapositives à partir de zéro. Cet article explique comment formater différentes entités de graphique, y compris l’axe des catégories et l’axe des valeurs.

Aspose.Slides for .NET fournit une API simple pour gérer différentes entités de graphique et les formater à l’aide de valeurs personnalisées :

1. Créer une instance de la classe **Presentation**.
1. Obtenir la référence d’une diapositive par son indice.
1. Ajouter un graphique avec des données par défaut ainsi que le type souhaité (dans cet exemple nous utiliserons ChartType.LineWithMarkers).
1. Accéder à l’axe des valeurs du graphique et définir les propriétés suivantes :
   1. Définir le **format de ligne** pour les lignes de la grille principale de l’axe des valeurs
   1. Définir le **format de ligne** pour les lignes de la grille secondaire de l’axe des valeurs
   1. Définir le **format de nombre** pour l’axe des valeurs
   1. Définir les unités **Min, Max, principales et secondaires** pour l’axe des valeurs
   1. Définir les **propriétés de texte** pour les données de l’axe des valeurs
   1. Définir le **titre** de l’axe des valeurs
   1. Définir le **format de ligne** de l’axe des valeurs
1. Accéder à l’axe des catégories du graphique et définir les propriétés suivantes :
   1. Définir le **format de ligne** pour les lignes de la grille principale de l’axe des catégories
   1. Définir le **format de ligne** pour les lignes de la grille secondaire de l’axe des catégories
   1. Définir les **propriétés de texte** pour les données de l’axe des catégories
   1. Définir le **titre** de l’axe des catégories
   1. Définir le **positionnement des étiquettes** pour l’axe des catégories
   1. Définir l’**angle de rotation** des étiquettes de l’axe des catégories
1. Accéder à la légende du graphique et définir les **propriétés de texte** pour celle‑ci
1. Afficher les légendes du graphique sans chevaucher le graphique
1. Accéder à l’**axe des valeurs secondaire** du graphique et définir les propriétés suivantes :
   1. Activer l’**axe des valeurs secondaire**
   1. Définir le **format de ligne** pour l’axe des valeurs secondaire
   1. Définir le **format de nombre** pour l’axe des valeurs secondaire
   1. Définir les unités **Min, Max, principales et secondaires** pour l’axe des valeurs secondaire
1. Tracer maintenant la première série du graphique sur l’axe des valeurs secondaire
1. Définir la couleur de remplissage du mur arrière du graphique
1. Définir la couleur de remplissage de la zone de tracé du graphique
1. Enregistrer la présentation modifiée dans un fichier PPTX
```c#
 // Instanciation de la présentation// Instanciation de la présentation
 Presentation pres = new Presentation();

 // Accéder à la première diapositive
 ISlide slide = pres.Slides[0];

 // Ajout du graphique d'exemple
 IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

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

 // Définition du format des lignes de grille principales pour l'axe des valeurs
 chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
 chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Blue;
 chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.Width = 5;
 chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.DashStyle = LineDashStyle.DashDot;

 // Définition du format des lignes de grille secondaires pour l'axe des valeurs
 chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
 chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Red;
 chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.Width = 3;

 // Définition du format numérique de l'axe des valeurs
 chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
 chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Thousands;
 chart.Axes.VerticalAxis.NumberFormat = "0.0%";

 // Définition des valeurs maximale et minimale du graphique
 chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
 chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
 chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;
 chart.Axes.VerticalAxis.IsAutomaticMinValue = false;

 chart.Axes.VerticalAxis.MaxValue = 15f;
 chart.Axes.VerticalAxis.MinValue = -2f;
 chart.Axes.VerticalAxis.MinorUnit = 0.5f;
 chart.Axes.VerticalAxis.MajorUnit = 2.0f;

 // Définition des propriétés de texte de l'axe des valeurs
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
 valtitle.Text = "Primary Axis";
 valtitle.PortionFormat.FillFormat.FillType = FillType.Solid;
 valtitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
 valtitle.PortionFormat.FontHeight = 20;
 valtitle.PortionFormat.FontBold = NullableBool.True;
 valtitle.PortionFormat.FontItalic = NullableBool.True;

 // Définition du format de ligne de l'axe des valeurs : maintenant obsolète
 // chart.Axes.VerticalAxis.aVerticalAxis.l.AxisLine.Width = 10;
 // chart.Axes.VerticalAxis.AxisLine.FillFormat.FillType = FillType.Solid;
 // Chart.Axes.VerticalAxis.AxisLine.FillFormat.SolidFillColor.Color = Color.Red;

 // Définition du format des lignes de grille principales pour l'axe des catégories
 chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
 chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Green;
 chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.Width = 5;

 // Définition du format des lignes de grille secondaires pour l'axe des catégories
 chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
 chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Yellow;
 chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.Width = 3;

 // Définition des propriétés de texte de l'axe des catégories
 IChartPortionFormat txtCat = chart.Axes.HorizontalAxis.TextFormat.PortionFormat;
 txtCat.FontBold = NullableBool.True;
 txtCat.FontHeight = 16;
 txtCat.FontItalic = NullableBool.True;
 txtCat.FillFormat.FillType = FillType.Solid; ;
 txtCat.FillFormat.SolidFillColor.Color = Color.Blue;
 txtCat.LatinFont = new FontData("Arial");

 // Définition du titre de l'axe des catégories
 chart.Axes.HorizontalAxis.HasTitle = true;
 chart.Axes.HorizontalAxis.Title.AddTextFrameForOverriding("");

 IPortion catTitle = chart.Axes.HorizontalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
 catTitle.Text = "Sample Category";
 catTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
 catTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
 catTitle.PortionFormat.FontHeight = 20;
 catTitle.PortionFormat.FontBold = NullableBool.True;
 catTitle.PortionFormat.FontItalic = NullableBool.True;

 // Définition de la position des étiquettes de l'axe des catégories
 chart.Axes.HorizontalAxis.TickLabelPosition = TickLabelPositionType.Low;

 // Définition de l'angle de rotation des étiquettes de l'axe des catégories
 chart.Axes.HorizontalAxis.TickLabelRotationAngle = 45;

 // Définition des propriétés de texte des légendes
 IChartPortionFormat txtleg = chart.Legend.TextFormat.PortionFormat;
 txtleg.FontBold = NullableBool.True;
 txtleg.FontHeight = 16;
 txtleg.FontItalic = NullableBool.True;
 txtleg.FillFormat.FillType = FillType.Solid; ;
 txtleg.FillFormat.SolidFillColor.Color = Color.DarkRed;

 // Définir l'affichage des légendes du graphique sans chevaucher le graphique

 chart.Legend.Overlay = true;
             
 // Tracer la première série sur l'axe des valeurs secondaire
 // Chart.ChartData.Series[0].PlotOnSecondAxis = true;

 // Définition de la couleur du mur arrière du graphique
 chart.BackWall.Thickness = 1;
 chart.BackWall.Format.Fill.FillType = FillType.Solid;
 chart.BackWall.Format.Fill.SolidFillColor.Color = Color.Orange;

 chart.Floor.Format.Fill.FillType = FillType.Solid;
 chart.Floor.Format.Fill.SolidFillColor.Color = Color.Red;
 // Définition de la couleur de la zone de tracé
 chart.PlotArea.Format.Fill.FillType = FillType.Solid;
 chart.PlotArea.Format.Fill.SolidFillColor.Color = Color.LightCyan;

 // Enregistrer la présentation
 pres.Save("FormattedChart_out.pptx", SaveFormat.Pptx);
```


## **Définir les propriétés de police pour le graphique**
Aspose.Slides for .NET prend en charge la définition des propriétés liées à la police pour le graphique. Veuillez suivre les étapes ci‑dessous pour définir les propriétés de police du graphique.

- Instancier l’objet de classe **Presentation**.
- Ajouter un graphique sur la diapositive.
- Définir la hauteur de la police.
- Enregistrer la présentation modifiée.

L’exemple suivant est fourni.  
```c#
using (Presentation pres = new Presentation())
{               
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.TextFormat.PortionFormat.FontHeight = 20;
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
    pres.Save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
}
```


## **Définir le format des numériques**
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

// Ajouter un graphique à colonnes groupées par défaut
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

// Accéder à la collection des séries du graphique
IChartSeriesCollection series = chart.ChartData.Series;

// Définir le format numérique prédéfini
// Parcourir chaque série du graphique
foreach (ChartSeries ser in series)
{
    // Parcourir chaque cellule de données de la série
    foreach (IChartDataPoint cell in ser.DataPoints)
    {
        // Définir le format numérique
        cell.Value.AsCell.PresetNumberFormat = 10; //0.00%
    }
}

// Enregistrer la présentation
pres.Save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
```


Les valeurs de format numérique prédéfini possibles ainsi que leur indice sont présentées ci‑dessous :

|**0**|Général|
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
|**46**|h :mm:ss|
|**47**|[mm:ss.0](http://mmss.0)|
|**48**|##0.0E+00|
|**49**|@|

## **Définir les bordures arrondies de la zone du graphique**
Aspose.Slides for .NET prend en charge la définition de la zone du graphique. Les propriétés **IChart.HasRoundedCorners** et **Chart.HasRoundedCorners** ont été ajoutées dans Aspose.Slides.  

1. Instancier l’objet de classe `Presentation`.
1. Ajouter un graphique sur la diapositive.
1. Définir le type de remplissage et la couleur de remplissage du graphique
1. Définir la propriété d’angle arrondi sur True.
1. Enregistrer la présentation modifiée.

L’exemple suivant est fourni.  
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

**Puis-je appliquer des remplissages semi‑transparents aux colonnes/zones tout en gardant la bordure opaque ?**

Oui. La transparence du remplissage et le contour sont configurés séparément. Cela est utile pour améliorer la lisibilité de la grille et des données dans des visualisations denses.

**Comment puis‑je gérer les étiquettes de données lorsqu’elles se chevauchent ?**

Réduisez la taille de la police, désactivez les composants d’étiquette non essentiels (par exemple, les catégories), définissez le décalage/position de l’étiquette, affichez les étiquettes uniquement pour les points sélectionnés si nécessaire, ou passez au format « valeur + légende ».

**Puis‑je appliquer des remplissages en dégradé ou en motif aux séries ?**

Oui. Les remplissages plein et en dégradé/motif sont généralement disponibles. En pratique, utilisez les dégradés avec parcimonie et évitez les combinaisons qui réduisent le contraste avec la grille et le texte.