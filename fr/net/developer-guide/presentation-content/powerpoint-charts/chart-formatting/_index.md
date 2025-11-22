---
title: "Mise en forme du graphique"
type: docs
weight: 60
url: /fr/net/chart-formatting/
keywords: "Entités de graphique, propriétés du graphique, présentation PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Formater les entités de graphique dans les présentations PowerPoint en C# ou .NET"
---

## **Formater les entités du graphique**
Aspose.Slides for .NET permet aux développeurs d’ajouter des graphiques personnalisés à leurs diapositives depuis le départ. Cet article explique comment formater différentes entités du graphique, y compris les axes de catégorie et de valeur.

Aspose.Slides for .NET fournit une API simple pour gérer différentes entités du graphique et les formater à l’aide de valeurs personnalisées :

1. Créez une instance de la classe **Presentation** .
1. Obtenez la référence d’une diapositive par son indice.
1. Ajoutez un graphique avec des données par défaut ainsi que le type souhaité (dans cet exemple nous utiliserons ChartType.LineWithMarkers).
1. Accédez à l’axe des valeurs du graphique et définissez les propriétés suivantes :
   1. Définir le **Line format** pour les lignes de grille majeures de l’axe des valeurs
   1. Définir le **Line format** pour les lignes de grille mineures de l’axe des valeurs
   1. Définir le **Number Format** pour l’axe des valeurs
   1. Définir les **Min, Max, Major and Minor units** pour l’axe des valeurs
   1. Définir les **Text Properties** pour les données de l’axe des valeurs
   1. Définir le **Title** de l’axe des valeurs
   1. Définir le **Line Format** pour l’axe des valeurs
1. Accédez à l’axe de catégorie du graphique et définissez les propriétés suivantes :
   1. Définir le **Line format** pour les lignes de grille majeures de l’axe de catégorie
   1. Définir le **Line format** pour les lignes de grille mineures de l’axe de catégorie
   1. Définir les **Text Properties** pour les données de l’axe de catégorie
   1. Définir le **Title** de l’axe de catégorie
   1. Définir le **Label Positioning** de l’axe de catégorie
   1. Définir le **Rotation Angle** des libellés de l’axe de catégorie
1. Accédez à la légende du graphique et définissez les **Text Properties** pour celle‑ci
1. Affichez les légendes du graphique sans qu’elles ne se chevauchent
1. Accédez à l’**Secondary Value Axis** du graphique et définissez les propriétés suivantes :
   1. Activez l’**Value Axis** secondaire
   1. Définir le **Line Format** pour l’**Secondary Value Axis**
   1. Définir le **Number Format** pour l’**Secondary Value Axis**
   1. Définir les **Min, Max, Major and Minor units** pour l’**Secondary Value Axis**
1. Tracez maintenant la première série du graphique sur l’**Secondary Value Axis**
1. Définissez la couleur de remplissage du mur arrière du graphique
1. Définissez la couleur de remplissage de la zone de traçage du graphique
1. Enregistrez la présentation modifiée dans un fichier PPTX
```c#
// Instanciation de la présentation
Presentation pres = new Presentation();

// Accès à la première diapositive
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

// Définition du format de la ligne de l'axe des valeurs : maintenant obsolète
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

// Définition de la position des libellés de l'axe des catégories
chart.Axes.HorizontalAxis.TickLabelPosition = TickLabelPositionType.Low;

// Définition de l'angle de rotation des libellés de l'axe des catégories
chart.Axes.HorizontalAxis.TickLabelRotationAngle = 45;

// Définition des propriétés de texte de la légende
IChartPortionFormat txtleg = chart.Legend.TextFormat.PortionFormat;
txtleg.FontBold = NullableBool.True;
txtleg.FontHeight = 16;
txtleg.FontItalic = NullableBool.True;
txtleg.FillFormat.FillType = FillType.Solid; ;
txtleg.FillFormat.SolidFillColor.Color = Color.DarkRed;

// Afficher les légendes sans chevaucher le graphique
chart.Legend.Overlay = true;
            
// Tracer la première série sur l'axe des valeurs secondaire
// Chart.ChartData.Series[0].PlotOnSecondAxis = true;

// Définition de la couleur du mur arrière du graphique
chart.BackWall.Thickness = 1;
chart.BackWall.Format.Fill.FillType = FillType.Solid;
chart.BackWall.Format.Fill.SolidFillColor.Color = Color.Orange;

chart.Floor.Format.Fill.FillType = FillType.Solid;
chart.Floor.Format.Fill.SolidFillColor.Color = Color.Red;
// Définition de la couleur de la zone de traçage
chart.PlotArea.Format.Fill.FillType = FillType.Solid;
chart.PlotArea.Format.Fill.SolidFillColor.Color = Color.LightCyan;

// Enregistrer la présentation
pres.Save("FormattedChart_out.pptx", SaveFormat.Pptx);
```




## **Définir les propriétés de police du graphique**
Aspose.Slides for .NET fournit un support pour définir les propriétés liées à la police du graphique. Veuillez suivre les étapes ci‑dessous pour définir les propriétés de police du graphique.

- Instanciez un objet de classe **Presentation**.
- Ajoutez un graphique sur la diapositive.
- Définissez la hauteur de la police.
- Enregistrez la présentation modifiée.

L’exemple de code suivant est fourni.
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
Aspose.Slides for .NET fournit une API simple pour gérer le format des données du graphique :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenez la référence d’une diapositive par son indice.
1. Ajoutez un graphique avec des données par défaut et le type souhaité (cet exemple utilise **ChartType.ClusteredColumn**).
1. Définissez le format numérique prédéfini parmi les valeurs prédéfinies possibles.
1. Parcourez chaque cellule de données de graphique dans chaque série et définissez le format numérique des données du graphique.
1. Enregistrez la présentation.
1. Définissez le format numérique personnalisé.
1. Parcourez chaque cellule de données de graphique dans chaque série et définissez un format numérique différent.
1. Enregistrez la présentation.
```c#
 // Instancier la présentation// Instancier la présentation
 Presentation pres = new Presentation();

 // Accéder à la première diapositive de la présentation
 ISlide slide = pres.Slides[0];

 // Ajout d'un graphique à colonnes groupées par défaut
 IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

 // Accès à la collection de séries du graphique
 IChartSeriesCollection series = chart.ChartData.Series;

 // Définition du format numérique prédéfini
 // Parcourir chaque série du graphique
 foreach (ChartSeries ser in series)
 {
     // Parcourir chaque cellule de données de la série
     foreach (IChartDataPoint cell in ser.DataPoints)
     {
         // Définition du format numérique
         cell.Value.AsCell.PresetNumberFormat = 10; //0.00%
     }
 }

 // Enregistrement de la présentation
 pres.Save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
```


Les valeurs de format numérique prédéfini possibles avec leur indice sont présentées ci‑dessous :

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
|**46**|h :mm:ss|
|**47**|[mm:ss.0](http://mmss.0)|
|**48**|##0.0E+00|
|**49**|@|

## **Définir les coins arrondis de la zone du graphique**
Aspose.Slides for .NET fournit un support pour définir la zone du graphique. Les propriétés **IChart.HasRoundedCorners** et **Chart.HasRoundedCorners** ont été ajoutées dans Aspose.Slides.

1. Instanciez un objet de classe `Presentation`.
1. Ajoutez un graphique sur la diapositive.
1. Définissez le type de remplissage et la couleur de remplissage du graphique
1. Définissez la propriété round corner sur True.
1. Enregistrez la présentation modifiée.

L’exemple de code suivant est fourni. 
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

**Puis-je définir des remplissages semi‑transparents pour les colonnes/aires tout en conservant le bord opaque ?**

Oui. La transparence du remplissage et le contour sont configurés séparément. Ceci est utile pour améliorer la lisibilité de la grille et des données dans les visualisations denses.

**Comment gérer les libellés de données lorsqu’ils se chevauchent ?**

Réduisez la taille de la police, désactivez les composants de libellé non essentiels (par exemple, les catégories), définissez le décalage/la position du libellé, n’affichez les libellés que pour les points sélectionnés si nécessaire, ou passez au format « valeur + légende ».

**Puis‑je appliquer des remplissages en dégradé ou en motif aux séries ?**

Oui. Les remplissages plein, en dégradé ou en motif sont généralement disponibles. En pratique, utilisez les dégradés avec parcimonie et évitez les combinaisons qui réduisent le contraste avec la grille et le texte.