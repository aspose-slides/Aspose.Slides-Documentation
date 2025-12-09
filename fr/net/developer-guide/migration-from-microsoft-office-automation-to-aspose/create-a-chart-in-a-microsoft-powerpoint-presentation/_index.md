---
title: Créer des graphiques avec VSTO et Aspose.Slides pour .NET
linktitle: Créer un graphique
type: docs
weight: 80
url: /fr/net/create-a-chart-in-a-microsoft-powerpoint-presentation/
keywords:
- créer un graphique
- migration
- VSTO
- automatisation Office
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Apprenez à automatiser la création de graphiques PowerPoint en C#. Ce guide étape par étape montre pourquoi Aspose.Slides pour .NET est une alternative plus rapide et plus puissante à Microsoft.Office.Interop."
---

## **Vue d'ensemble**

Cet article montre comment créer et personnaliser des graphiques dans des présentations Microsoft PowerPoint de manière programmatique en utilisant C#. Avec Aspose.Slides pour .NET, vous pouvez automatiser la génération de graphiques professionnels basés sur les données sans dépendre de Microsoft Office ou des bibliothèques Interop. L'API offre un ensemble riche de fonctionnalités pour créer des graphiques à colonnes, des graphiques circulaires, des graphiques en courbes, et plus encore — le tout avec un contrôle total sur l'apparence, les données et la disposition. Que vous génériez des rapports, des tableaux de bord ou des présentations professionnelles, Aspose.Slides vous aide à fournir des visualisations de haute qualité directement depuis vos applications .NET.

## **Exemple VSTO**

Cette section montre comment créer un graphique dans une présentation Microsoft PowerPoint en utilisant **VSTO (Visual Studio Tools for Office)**. Avec VSTO, vous pouvez générer et personnaliser des graphiques de manière programmatique en combinant l'automatisation de PowerPoint et d'Excel. L'exemple fourni montre comment ajouter un **graphique à colonnes groupées 3D**, le remplir avec des données provenant d'une feuille de calcul Excel, ajuster le formatage et la mise en page, et enregistrer la présentation finale — le tout depuis une application .NET.

1. Créer une instance d'une présentation Microsoft PowerPoint.
1. Ajouter une diapositive vierge à la présentation.
1. Ajouter un graphique à colonnes groupées 3D et y accéder.
1. Créer une nouvelle instance d'un classeur Microsoft Excel et charger les données du graphique.
1. Accéder à la feuille de données du graphique en utilisant l'instance du classeur Excel.
1. Définir la plage du graphique dans la feuille de calcul et supprimer les séries 2 et 3 du graphique.
1. Modifier les données de catégorie du graphique dans la feuille de données du graphique.
1. Modifier les données de la série 1 dans la feuille de données du graphique.
1. Accéder au titre du graphique et définir ses propriétés de police.
1. Accéder à l'axe des valeurs du graphique et définir l'unité majeure, l'unité mineure, la valeur maximale et la valeur minimale.
1. Accéder à l'axe de profondeur (séries) du graphique et le supprimer — une seule série est utilisée dans cet exemple.
1. Définir les angles de rotation du graphique selon les axes X et Y.
1. Enregistrer la présentation.
1. Fermer les instances de Microsoft Excel et PowerPoint.
```c#
EnsurePowerPointIsRunning(true, true);

// Instancier un objet diapositive.
Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;

// Accéder à la première diapositive de la présentation.
objSlide = objPres.Slides[1];

// Sélectionner la première diapositive et définir sa mise en page.
objSlide.Select();
objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank;

// Ajouter un graphique par défaut à la diapositive.
objSlide.Shapes.AddChart(Microsoft.Office.Core.XlChartType.xl3DColumn, 20, 30, 400, 300);

// Accéder au graphique ajouté.
Microsoft.Office.Interop.PowerPoint.Chart ppChart = objSlide.Shapes[1].Chart;

// Accéder aux données du graphique.
Microsoft.Office.Interop.PowerPoint.ChartData chartData = ppChart.ChartData;

// Créer une instance du classeur Excel pour travailler avec les données du graphique.
Microsoft.Office.Interop.Excel.Workbook dataWorkbook = (Microsoft.Office.Interop.Excel.Workbook)chartData.Workbook;

// Accéder à la feuille de calcul des données du graphique.
Microsoft.Office.Interop.Excel.Worksheet dataSheet = dataWorkbook.Worksheets[1];

// Définir la plage de données pour le graphique.
Microsoft.Office.Interop.Excel.Range tRange = dataSheet.Cells.get_Range("A1", "B5");

// Appliquer la plage spécifiée à la table de données du graphique.
Microsoft.Office.Interop.Excel.ListObject tbl1 = dataSheet.ListObjects["Table1"];
tbl1.Resize(tRange);

// Définir les valeurs pour les catégories et les données des séries respectives.
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A2"))).FormulaR1C1 = "Bikes";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A3"))).FormulaR1C1 = "Accessories";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A4"))).FormulaR1C1 = "Repairs";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A5"))).FormulaR1C1 = "Clothing";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B2"))).FormulaR1C1 = "1000";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B3"))).FormulaR1C1 = "2500";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B4"))).FormulaR1C1 = "4000";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B5"))).FormulaR1C1 = "3000";

// Définir le titre du graphique.
ppChart.ChartTitle.Font.Italic = true;
ppChart.ChartTitle.Text = "2007 Sales";
ppChart.ChartTitle.Font.Size = 18;
ppChart.ChartTitle.Font.Color = Color.Black.ToArgb();
ppChart.ChartTitle.Format.Line.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
ppChart.ChartTitle.Format.Line.ForeColor.RGB = Color.Black.ToArgb();

// Accéder à l'axe des valeurs du graphique.
Microsoft.Office.Interop.PowerPoint.Axis valaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlValue, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

// Définir les valeurs pour les unités de l'axe.
valaxis.MajorUnit = 2000.0F;
valaxis.MinorUnit = 1000.0F;
valaxis.MinimumScale = 0.0F;
valaxis.MaximumScale = 4000.0F;

// Accéder à l'axe de profondeur du graphique.
Microsoft.Office.Interop.PowerPoint.Axis Depthaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlSeriesAxis, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);
Depthaxis.Delete();

// Définir la rotation du graphique.
ppChart.Rotation = 20;   // Valeur Y
ppChart.Elevation = 15;  // Valeur X
ppChart.RightAngleAxes = false;

// Enregistrer la présentation au format PPTX.
objPres.SaveAs("VSTO_Sample_Chart.pptx", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);

// Fermer le classeur et la présentation.
dataWorkbook.Application.Quit();
objPres.Application.Quit();
```

```c#
public static void EnsurePowerPointIsRunning(bool blnAddPresentation)
{
    EnsurePowerPointIsRunning(blnAddPresentation, false);
}

public static void EnsurePowerPointIsRunning()
{
    EnsurePowerPointIsRunning(false, false);
}

public static void EnsurePowerPointIsRunning(bool blnAddPresentation, bool blnAddSlide)
{
    string strName = null;

    // Essayer d'accéder à la propriété Name. Si une exception est levée, démarrer une nouvelle instance de PowerPoint.
    try
    {
        strName = objPPT.Name;
    }
    catch (Exception ex)
    {
        StartPowerPoint();
    }

    // blnAddPresentation est utilisé pour s'assurer qu'une présentation est chargée.
    if (blnAddPresentation == true)
    {
        try
        {
            strName = objPres.Name;
        }
        catch (Exception ex)
        {
            objPres = objPPT.Presentations.Add(MsoTriState.msoTrue);
        }
    }

    // blnAddSlide est utilisé pour s'assurer qu'il y a au moins une diapositive dans la présentation.
    if (blnAddSlide)
    {
        try
        {
            strName = objPres.Slides[1].Name;
        }
        catch (Exception ex)
        {
            Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;
            Microsoft.Office.Interop.PowerPoint.CustomLayout objCustomLayout = null;
            objCustomLayout = objPres.SlideMaster.CustomLayouts[1];
            objSlide = objPres.Slides.AddSlide(1, objCustomLayout);
            objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutText;
            objCustomLayout = null;
            objSlide = null;
        }
    }
}
```


Le résultat :

![Le graphique créé avec VSTO](chart-created-using-VSTO.png)

## **Exemple Aspose.Slides pour .NET**

L'exemple suivant montre comment créer un graphique simple dans une présentation PowerPoint en utilisant Aspose.Slides pour .NET. Ce code montre comment ajouter un **graphique à colonnes groupées 3D**, le remplir avec des données d'exemple et personnaliser son apparence. En quelques lignes de code seulement, vous pouvez générer des graphiques dynamiquement et les intégrer à vos présentations sans utiliser Microsoft Office.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Obtenir une référence à la première diapositive.
1. Ajouter un graphique à colonnes groupées 3D et y accéder.
1. Accéder aux données du graphique.
1. Supprimer les séries inutilisées 2 et 3.
1. Modifier les catégories du graphique en mettant à jour les étiquettes.
1. Mettre à jour les valeurs de la série 1.
1. Accéder au titre du graphique et définir ses propriétés de police.
1. Configurer l'axe des valeurs du graphique, y compris l'unité majeure, l'unité mineure, les valeurs maximale et minimale.
1. Définir les angles de rotation du graphique sur les axes X et Y.
1. Enregistrer la présentation au format PPTX.
```cs
// Créer une présentation vide.
using (Presentation presentation = new Presentation())
{
    // Accéder à la première diapositive.
    ISlide slide = presentation.Slides[0];

    // Ajouter un graphique par défaut.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn3D, 20, 30, 400, 300);

    // Récupérer les données du graphique.
    IChartData chartData = chart.ChartData;

    // Supprimer les séries par défaut supplémentaires.
    chartData.Series.RemoveAt(1);
    chartData.Series.RemoveAt(1);

    // Modifier les noms des catégories du graphique.
    chartData.Categories[0].AsCell.Value = "Bikes";
    chartData.Categories[1].AsCell.Value = "Accessories";
    chartData.Categories[2].AsCell.Value = "Repairs";
    chartData.Categories[3].AsCell.Value = "Clothing";

    // Définir l'index de la feuille de calcul des données du graphique.
    int worksheetIndex = 0;

    // Récupérer le classeur de données du graphique.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Modifier les valeurs des séries du graphique.
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 1000));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 2500));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 4000));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 4, 1, 3000));

    // Définir le titre du graphique.
    chart.HasTitle = true;
    chart.ChartTitle.AddTextFrameForOverriding("2007 Sales");
    IPortionFormat format = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0].PortionFormat;
    format.FontItalic = NullableBool.True;
    format.FontHeight = 18;
    format.FillFormat.FillType = FillType.Solid;
    format.FillFormat.SolidFillColor.Color = Color.Black;

    // Définir les options des axes.
    chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
    chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
    chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
    chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;

    chart.Axes.VerticalAxis.MaxValue = 4000.0F;
    chart.Axes.VerticalAxis.MinValue = 0.0F;
    chart.Axes.VerticalAxis.MajorUnit = 2000.0F;
    chart.Axes.VerticalAxis.MinorUnit = 1000.0F;
    chart.Axes.VerticalAxis.TickLabelPosition = TickLabelPositionType.NextTo;

    // Définir la rotation du graphique.
    chart.Rotation3D.RotationX = 15;
    chart.Rotation3D.RotationY = 20;

    // Enregistrer la présentation au format PPTX.
    presentation.Save("Aspose_Sample_Chart.pptx", SaveFormat.Pptx);
}
```


Le résultat :

![Le graphique créé avec Aspose.Slides pour .NET](chart-created-using-aspose-slides.png)

## **FAQ**

**Puis-je créer d'autres types de graphiques tels que des graphiques circulaires, en courbes ou en barres avec Aspose.Slides ?**

Oui. Aspose.Slides pour .NET prend en charge une large gamme de [types de graphiques](https://docs.aspose.com/slides/net/create-chart/), y compris les graphiques circulaires, les graphiques en courbes, les graphiques à barres, les nuages de points, les graphiques à bulles, et plus encore. Vous pouvez spécifier le type de graphique souhaité en utilisant l'énumération [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) lors de l'ajout d'un graphique.

**Puis-je appliquer des styles ou des thèmes personnalisés au graphique ?**

Oui. Vous pouvez personnaliser entièrement l'apparence du graphique, y compris les couleurs, les polices, les remplissages, les contours, les lignes de grille et la mise en page. Cependant, appliquer exactement les thèmes Office tels qu'ils apparaissent dans PowerPoint nécessite de définir manuellement chaque style.

**Puis-je exporter le graphique en tant qu'image séparément de la diapositive ?**

Oui, Aspose.Slides vous permet d'exporter n'importe quelle forme — y compris les graphiques — sous forme d'image séparée (par ex., PNG, JPEG) en utilisant la méthode `GetImage` sur la [forme](https://reference.aspose.com/slides/net/aspose.slides/ishape/) du graphique.