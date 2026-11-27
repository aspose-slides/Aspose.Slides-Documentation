---
title: Formater les graphiques de présentation en .NET
linktitle: Mise en forme du graphique
type: docs
weight: 60
url: /fr/net/chart-formatting/
keywords:
- format de graphique
- mise en forme du graphique
- entité du graphique
- propriétés du graphique
- paramètres du graphique
- options du graphique
- propriétés de police
- bord arrondi
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Apprenez la mise en forme des graphiques avec Aspose.Slides pour .NET et améliorez votre présentation PowerPoint grâce à des axes personnalisés, des polices, des formats numériques et des bordures de graphique arrondies."
---
## **Vue d'ensemble**

Cet article explique comment mettre en forme les graphiques dans les présentations PowerPoint en utilisant Aspose.Slides. Il montre comment personnaliser les éléments clés du graphique tels que les axes, les lignes de quadrillage, les titres, les légendes, la zone de tracé et les remplissages de mur afin d’améliorer l’apparence et la lisibilité des données du graphique.

Il montre également comment définir les propriétés de police pour le texte du graphique, appliquer des formats numériques prédéfinis aux données du graphique et activer les coins arrondis pour la zone du graphique. Ensemble, ces exemples montrent comment contrôler à la fois le style visuel et la présentation des données des graphiques dans une présentation.

Pour des remplissages et des contours séparés sur les intervalles haussiers et baissiers, voir l'[exemple de graphique boursier](/slides/fr/net/create-chart/#create-stock-charts).

## **Formater les entités du graphique**

Utilisez [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/) pour formater les titres de graphique, les axes, les lignes de quadrillage, les légendes et la zone de tracé. Cet exemple crée un graphique en ligne avec des repères et des données par défaut, puis applique des styles de texte et de ligne séparés à ses axes de valeur et de catégorie. Les tailles de police et les épaisseurs de ligne sont spécifiées en points ; les libellés de catégorie sont inclinés de 45 degrés.

L'axe de valeur utilise [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/numberformat/) de manière indépendante des cellules sources. Son étendue va de -2 à 15, avec des intervalles majeurs de 2 et des intervalles mineurs de 0,5. L'exemple combine également le formatage de pourcentage avec [DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/displayunit/) réglé sur des milliers, adaptez donc ces paramètres à la signification et à l'amplitude de vos données. La légende reste à l'extérieur de la zone de tracé parce que [Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/ilegend/overlay/) est désactivé. Les remplissages du mur arrière et du plancher sont configurés via [BackWall](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/backwall/) et [Floor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/floor/), mais ces surfaces ne sont visibles que dans les graphiques 3D.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("");
var chartTitle = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0];
chartTitle.Text = "Sample Chart";
chartTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
chartTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
chartTitle.PortionFormat.FontHeight = 20;
chartTitle.PortionFormat.FontBold = NullableBool.True;
chartTitle.PortionFormat.FontItalic = NullableBool.True;

chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Blue;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.Width = 5;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.DashStyle = LineDashStyle.DashDot;

chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Red;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.Width = 3;

chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Thousands;
chart.Axes.VerticalAxis.NumberFormat = "0.0%";

chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;

chart.Axes.VerticalAxis.MaxValue = 15f;
chart.Axes.VerticalAxis.MinValue = -2f;
chart.Axes.VerticalAxis.MinorUnit = 0.5f;
chart.Axes.VerticalAxis.MajorUnit = 2.0f;

var valueAxisText = chart.Axes.VerticalAxis.TextFormat.PortionFormat;
valueAxisText.FontBold = NullableBool.True;
valueAxisText.FontHeight = 16;
valueAxisText.FontItalic = NullableBool.True;
valueAxisText.FillFormat.FillType = FillType.Solid;
valueAxisText.FillFormat.SolidFillColor.Color = Color.DarkGreen;
valueAxisText.LatinFont = new FontData("Times New Roman");

chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("");
var valueAxisTitle = chart.Axes.VerticalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
valueAxisTitle.Text = "Primary Axis";
valueAxisTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
valueAxisTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
valueAxisTitle.PortionFormat.FontHeight = 20;
valueAxisTitle.PortionFormat.FontBold = NullableBool.True;
valueAxisTitle.PortionFormat.FontItalic = NullableBool.True;

chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Green;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.Width = 5;

chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Yellow;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.Width = 3;

var categoryAxisText = chart.Axes.HorizontalAxis.TextFormat.PortionFormat;
categoryAxisText.FontBold = NullableBool.True;
categoryAxisText.FontHeight = 16;
categoryAxisText.FontItalic = NullableBool.True;
categoryAxisText.FillFormat.FillType = FillType.Solid;
categoryAxisText.FillFormat.SolidFillColor.Color = Color.Blue;
categoryAxisText.LatinFont = new FontData("Arial");

chart.Axes.HorizontalAxis.HasTitle = true;
chart.Axes.HorizontalAxis.Title.AddTextFrameForOverriding("");

var categoryAxisTitle = chart.Axes.HorizontalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
categoryAxisTitle.Text = "Sample Category";
categoryAxisTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
categoryAxisTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
categoryAxisTitle.PortionFormat.FontHeight = 20;
categoryAxisTitle.PortionFormat.FontBold = NullableBool.True;
categoryAxisTitle.PortionFormat.FontItalic = NullableBool.True;

chart.Axes.HorizontalAxis.TickLabelPosition = TickLabelPositionType.Low;
chart.Axes.HorizontalAxis.TickLabelRotationAngle = 45;

var legendText = chart.Legend.TextFormat.PortionFormat;
legendText.FontBold = NullableBool.True;
legendText.FontHeight = 16;
legendText.FontItalic = NullableBool.True;
legendText.FillFormat.FillType = FillType.Solid;
legendText.FillFormat.SolidFillColor.Color = Color.DarkRed;

chart.Legend.Overlay = false;

chart.BackWall.Thickness = 1;
chart.BackWall.Format.Fill.FillType = FillType.Solid;
chart.BackWall.Format.Fill.SolidFillColor.Color = Color.Orange;

chart.Floor.Format.Fill.FillType = FillType.Solid;
chart.Floor.Format.Fill.SolidFillColor.Color = Color.Red;

chart.PlotArea.Format.Fill.FillType = FillType.Solid;
chart.PlotArea.Format.Fill.SolidFillColor.Color = Color.LightCyan;

presentation.Save("FormattedChart_out.pptx", SaveFormat.Pptx);
```

## **Définir les propriétés de police pour un graphique**

Définissez la taille de police par défaut pour le texte du graphique via [Chart.TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/textformat/). L'exemple crée un histogramme groupé avec une police de 20 points et active les libellés de valeur pour la première série via [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/). Les éléments de texte avec leurs propres paramètres de police explicites peuvent remplacer la valeur par défaut du graphique.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
chart.TextFormat.PortionFormat.FontHeight = 20;
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
```

## **Réutiliser le formatage du cadre de texte pour la légende d'un graphique**

Pour faire correspondre une légende à l'en-tête d'une diapositive, définissez la police dans le [DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) du premier paragraphe. Appelez [CopyFrom](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextformat/copyfrom/) sur le [TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iformattedtextcontainer/textformat/) de la légende. Il lit les paramètres du cadre de texte, le formatage du premier paragraphe et les propriétés de police par défaut de ce paragraphe. Le formatage appliqué directement à des portions individuelles ou à des paragraphes ultérieurs reste local à la source.

L'exemple utilise un en-tête Calibri gras de 26 points en bleu marine comme modèle. Après la mise en forme de la légende, il utilise [CopyTo](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextformat/copyto/) pour appliquer le même formatage à une légende séparée.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shapes = presentation.Slides[0].Shapes;

var heading = shapes.AddAutoShape(ShapeType.Rectangle, 40, 20, 640, 40, false);
var sourceTextFrame = heading.AddTextFrame("Quarterly sales");
var font = sourceTextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
font.LatinFont = new FontData("Calibri");
font.FontHeight = 26;
font.FontBold = NullableBool.True;
font.FillFormat.FillType = FillType.Solid;
font.FillFormat.SolidFillColor.Color = Color.FromArgb(32, 64, 96);

var chart = shapes.AddChart(ChartType.ClusteredColumn, 40, 75, 640, 360);
chart.Style = StyleType.Style3;
var workbook = chart.ChartData.ChartDataWorkbook;
workbook.GetCell(0, 0, 1).Value = "Retail";
workbook.GetCell(0, 0, 2).Value = "Online";
workbook.GetCell(0, 0, 3).Value = "Wholesale";
for (var quarter = 1; quarter <= 4; quarter++)
    workbook.GetCell(0, quarter, 0).Value = $"Q{quarter}";

chart.HasLegend = true;
chart.Legend.Position = LegendPositionType.Bottom;
chart.Legend.TextFormat.CopyFrom(sourceTextFrame);

var caption = shapes.AddAutoShape(ShapeType.Rectangle, 40, 460, 640, 40, false);
var captionTextFrame = caption.AddTextFrame("Sales in millions of dollars");
chart.Legend.TextFormat.CopyTo(captionTextFrame);

presentation.Save("legend-formatting.pptx", SaveFormat.Pptx);
```

Dans la présentation enregistrée, la légende et la légende séparée correspondent à l'en-tête en taille, poids et couleur. La légende affiche toujours les noms des séries, et la légende séparée conserve son propre texte. Si une portion de la légende possède déjà une taille de police explicite, cette taille prend le pas sur le paragraphe par défaut copié.

| Avant la copie | Après la copie |
| --- | --- |
| ![Graphique des ventes trimestrielles avec des libellés de légende noirs réguliers et une légende noire](legend-formatting-before.png) | ![Le même graphique avec des libellés de légende marine gras et plus grands et une légende correspondante](legend-formatting.png) |

## **Définir le format numérique**

Utilisez [IChartDataCell.PresetNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/presetnumberformat/) pour appliquer un format numérique intégré aux cellules du classeur du graphique. Cet exemple crée un histogramme groupé avec des données par défaut stockées dans les cellules et applique l'indice de format 10 (`0.00%`) à chaque cellule de valeur de série. Cela modifie la façon dont les valeurs sont affichées dans le classeur sans changer les nombres sous‑jacents ; par exemple, 0,25 s'affiche sous la forme 25,00 %. Les formats des axes et des libellés de données peuvent être configurés séparément.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);
var series = chart.ChartData.Series;

foreach (var chartSeries in series)
{
    foreach (var dataPoint in chartSeries.DataPoints)
    {
        dataPoint.Value.AsCell.PresetNumberFormat = 10; //0,00%
    }
}

presentation.Save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
```

Le tableau suivant répertorie les indices de formats numériques intégrés avec les formats Excel représentatifs pour la locale anglais (États‑Unis). Les chaînes de format exactes et leur affichage peuvent varier selon l'application et la locale, notamment pour les monnaies et les dates. Certains formats Excel diffèrent également des valeurs par défaut de la norme OOXML, comme indiqué dans les [notes d’implémentation des formats numériques de Microsoft](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

| Indice | Format |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **Définir des coins arrondis pour la zone du graphique**

Activez [IChart.HasRoundedCorners](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/hasroundedcorners/) pour arrondir les coins de la zone du graphique. L'exemple crée un histogramme groupé et utilise [LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) pour donner à son contour une couleur grise unie et un style à ligne unique avant d’enregistrer la présentation.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
chart.LineFormat.FillFormat.FillType = FillType.Solid;
chart.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;
chart.LineFormat.Style = LineStyle.Single;
chart.HasRoundedCorners = true;

presentation.Save("out.pptx", SaveFormat.Pptx);
```

## **Modifier les annotations de graphique existantes**

Un graphique peut contenir des formes personnalisées, comme une annotation texte expliquant l’état d’un rapport. Accédez à ces formes via [IChart.UserShapes](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/usershapes/), également listées sous [Chart.UserShapes](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/usershapes/) dans la référence API du graphique. Sa collection [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) contient les formes détenues par le graphique.

Une zone de texte ordinaire placée sur un graphique appartient à la diapositive, même si elle ressemble à une partie du graphique. Parcourir [Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/) trouve le graphique ainsi que les formes ordinaires de la diapositive, mais n’énumère pas les formes individuelles à l’intérieur du graphique. Les titres de graphique et les libellés de données sont des éléments de graphique distincts, pas des annotations personnalisées dans cette collection.

Téléchargez [chart-annotations.pptx](chart-annotations.pptx) et placez‑le dans le répertoire de travail de l’application. Sa première diapositive contient un graphique avec une annotation non groupée affichant « Preliminary results », une ligne appartenant au graphique et une zone de texte ordinaire de diapositive affichant « Slide overlay ». L’exemple trouve le premier graphique de cette diapositive et change l’annotation en « Final results » lorsque le rapport est prêt à être publié. Il vérifie une collection vide et ne modifie qu’une [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) ayant un [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/) non nul et le texte attendu.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("chart-annotations.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.OfType<IChart>().FirstOrDefault();

if (chart == null || chart.UserShapes.Shapes.Count == 0)
{
    Console.WriteLine("No chart or chart-owned shapes found.");
    return;
}

var updated = false;
foreach (var shape in chart.UserShapes.Shapes)
{
    if (shape is IAutoShape annotation && 
        annotation.TextFrame != null && 
        annotation.TextFrame.Text == "Preliminary results")
    {
        annotation.TextFrame.Text = "Final results";
        updated = true;
        break;
    }
}

if (updated)
{
    presentation.Save("chart-annotations-updated.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("No matching text annotation found.");
}
```

La ligne et la zone de texte de la diapositive restent inchangées. Les images suivantes montrent l’entrée et le résultat enregistré, rouvert :

| Avant la modification | Après la modification |
| --- | --- |
| ![Annotation de graphique affichant Preliminary results](chart-annotations-before.png) | ![Annotation de graphique affichant Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
L’exemple n’inspecte que les formes détenues directement par le graphique. Si une annotation se trouve à l’intérieur d’un [IGroupShape](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/), inspectez également la collection [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) de ce groupe. Répétez cela de façon récursive pour les groupes imbriqués, en appliquant les mêmes vérifications de texte à leurs formes enfants. Un groupe est lui‑même un conteneur ; ne le traitez pas comme une zone de texte.
{{% /alert %}}

## **FAQ**

**Puis-je définir des remplissages semi-transparents pour les colonnes/zones tout en conservant le bord opaque ?**

Oui. La transparence du remplissage et le contour sont configurés séparément. Cela est utile pour améliorer la lisibilité de la grille et des données dans des visualisations denses.

**Comment gérer les libellés de données lorsqu'ils se chevauchent ?**

Réduisez la taille de la police, désactivez les composants de libellé non essentiels (par exemple, les catégories), ajustez la position du libellé, affichez les libellés uniquement pour les points sélectionnés si nécessaire, ou passez au format « valeur + légende ».

**Puis-je appliquer des remplissages en dégradé ou en motif aux séries ?**

Oui. Les séries prennent en charge les remplissages unis, en dégradé et en motif. En pratique, utilisez les dégradés avec parcimonie et évitez les combinaisons qui réduisent le contraste avec la grille et le texte.