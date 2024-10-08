---
title: Créer un graphique dans une présentation Microsoft PowerPoint
type: docs
weight: 80
url: /fr/net/create-a-chart-in-a-microsoft-powerpoint-presentation/
---

{{% alert color="primary" %}} 

 Les graphiques sont des représentations visuelles de données qui sont largement utilisées dans les présentations. Cet article montre le code pour créer un graphique dans Microsoft PowerPoint programmatiquement en utilisant [VSTO](/slides/fr/net/create-a-chart-in-a-microsoft-powerpoint-presentation/) et [Aspose.Slides pour .NET](/slides/fr/net/create-a-chart-in-a-microsoft-powerpoint-presentation/).

{{% /alert %}} 
## **Créer un graphique**
Les exemples de code ci-dessous décrivent le processus d'ajout d'un simple graphique à colonnes regroupées 3D en utilisant VSTO. Vous créez une instance de présentation, ajoutez un graphique par défaut à celle-ci. Ensuite, utilisez un classeur Microsoft Excel pour accéder et modifier les données du graphique ainsi que pour définir les propriétés du graphique. Enfin, enregistrez la présentation.
## **Exemple VSTO**
En utilisant VSTO, les étapes suivantes sont effectuées :

1. Créer une instance d'une présentation Microsoft PowerPoint.
1. Ajouter une diapositive vide à la présentation.
1. Ajouter un graphique **à colonnes regroupées 3D** et y accéder.
1. Créer une nouvelle instance de classeur Microsoft Excel et charger les données du graphique.
1. Accéder à la feuille de données du graphique à l'aide de l'instance de classeur Microsoft Excel.
1. Définir la plage du graphique dans la feuille de calcul et retirer les séries 2 et 3 du graphique.
1. Modifier les données de catégories du graphique dans la feuille de données du graphique.
1. Modifier les données de la série 1 dans la feuille de données du graphique.
1. Maintenant, accéder au titre du graphique et définir les propriétés liées à la police.
1. Accéder à l'axe des valeurs du graphique et définir l'unité majeure, les unités mineures, la valeur maximale et les valeurs minimales.
1. Accéder à l'axe de profondeur du graphique ou à l'axe des séries et le retirer, car dans cet exemple, seule une série est utilisée.
1. Maintenant, définir les angles de rotation du graphique dans les directions X et Y.
1. Enregistrer la présentation.
1. Fermer les instances de Microsoft Excel et PowerPoint.

**La présentation de sortie, créée avec VSTO** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_1.png)



```c#
EnsurePowerPointIsRunning(true, true);

//Instancier l'objet diapositive
Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;

//Accéder à la première diapositive de la présentation
objSlide = objPres.Slides[1];

//Sélectionner la première diapositive et définir sa mise en page
objSlide.Select();
objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank;

//Ajouter un graphique par défaut à la diapositive
objSlide.Shapes.AddChart(Microsoft.Office.Core.XlChartType.xl3DColumn, 20F, 30F, 400F, 300F);

//Accéder au graphique ajouté
Microsoft.Office.Interop.PowerPoint.Chart ppChart = objSlide.Shapes[1].Chart;

//Accéder aux données du graphique
Microsoft.Office.Interop.PowerPoint.ChartData chartData = ppChart.ChartData;

//Créer une instance de classeur Excel pour travailler avec les données du graphique
Microsoft.Office.Interop.Excel.Workbook dataWorkbook = (Microsoft.Office.Interop.Excel.Workbook)chartData.Workbook;

//Accès à la feuille de données pour le graphique
Microsoft.Office.Interop.Excel.Worksheet dataSheet = dataWorkbook.Worksheets[1];

//Définir la plage du graphique
Microsoft.Office.Interop.Excel.Range tRange = dataSheet.Cells.get_Range("A1", "B5");

//Appliquer la plage définie sur le tableau de données du graphique
Microsoft.Office.Interop.Excel.ListObject tbl1 = dataSheet.ListObjects["Table1"];
tbl1.Resize(tRange);

//Définir les valeurs pour les catégories et les données respectives des séries

((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A2"))).FormulaR1C1 = "Vélos";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A3"))).FormulaR1C1 = "Accessoires";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A4"))).FormulaR1C1 = "Réparations";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A5"))).FormulaR1C1 = "Vêtements";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B2"))).FormulaR1C1 = "1000";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B3"))).FormulaR1C1 = "2500";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B4"))).FormulaR1C1 = "4000";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B5"))).FormulaR1C1 = "3000";

//Définir le titre du graphique
ppChart.ChartTitle.Font.Italic = true;
ppChart.ChartTitle.Text = "Ventes 2007";
ppChart.ChartTitle.Font.Size = 18;
ppChart.ChartTitle.Font.Color = Color.Black.ToArgb();
ppChart.ChartTitle.Format.Line.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
ppChart.ChartTitle.Format.Line.ForeColor.RGB = Color.Black.ToArgb();

//Accéder à l'axe des valeurs du graphique
Microsoft.Office.Interop.PowerPoint.Axis valaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlValue, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

//Définir les unités de l'axe des valeurs
valaxis.MajorUnit = 2000.0F;
valaxis.MinorUnit = 1000.0F;
valaxis.MinimumScale = 0.0F;
valaxis.MaximumScale = 4000.0F;

//Accéder à l'axe de profondeur du graphique
Microsoft.Office.Interop.PowerPoint.Axis Depthaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlSeriesAxis, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);
Depthaxis.Delete();

//Définir la rotation du graphique
ppChart.Rotation = 20; //Valeur Y
ppChart.Elevation = 15; //Valeur X
ppChart.RightAngleAxes = false;

// Enregistrer la présentation en tant que PPTX
objPres.SaveAs("C:\\VSTOSampleChart", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);
//objPres.SaveAs(@"..\..\..\VSTOSampleChart", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);

//Fermer le classeur et la présentation
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
    //
    //Essayer d'accéder à la propriété de nom. Si cela provoque une exception, alors
    //démarrer une nouvelle instance de PowerPoint
    try
    {
        strName = objPPT.Name;
    }
    catch (Exception ex)
    {
        StartPowerPoint();
    }
    //
    //blnAddPresentation est utilisé pour s'assurer qu'il y a une présentation chargée
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
    //
    //BlnAddSlide est utilisé pour garantir qu'il y a au moins une diapositive dans la
    //présentation
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




## **Exemple Aspose.Slides pour .NET**
En utilisant Aspose.Slides pour .NET, les étapes suivantes sont effectuées :

1. Créer une instance d'une présentation Microsoft PowerPoint.
1. Ajouter une diapositive vide à la présentation.
1. Ajouter un graphique **à colonnes regroupées 3D** et y accéder.
1. Accéder à la feuille de données du graphique à l'aide d'une instance de classeur Microsoft Excel.
1. Retirer les séries inutilisées 2 et 3.
1. Accéder aux catégories du graphique et modifier les étiquettes.
1. Accéder à la série 1 et modifier les valeurs de la série.
1. Maintenant, accéder au titre du graphique et définir les propriétés de la police.
1. Accéder à l'axe des valeurs du graphique et définir l'unité majeure, les unités mineures, la valeur maximale et les valeurs minimales.
1. Maintenant, définir les angles de rotation du graphique dans les directions X et Y.
1. Enregistrer la présentation au format PPTX.

**La présentation de sortie, créée avec Aspose.Slides**

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_2.png)

```csharp
//Créer une présentation vide
using (Presentation pres = new Presentation())
{

    //Accéder à la première diapositive
    ISlide slide = pres.Slides[0];

    //Ajout d'un graphique par défaut
    IChart ppChart = slide.Shapes.AddChart(ChartType.ClusteredColumn3D, 20F, 30F, 400F, 300F);

    //Obtenir les données du graphique
    IChartData chartData = ppChart.ChartData;

    //Supprimer les séries par défaut supplémentaires
    chartData.Series.RemoveAt(1);
    chartData.Series.RemoveAt(1);

    //Modifier les noms des catégories du graphique
    chartData.Categories[0].AsCell.Value = "Vélos";
    chartData.Categories[1].AsCell.Value = "Accessoires";
    chartData.Categories[2].AsCell.Value = "Réparations";
    chartData.Categories[3].AsCell.Value = "Vêtements";

    //Définir l'index de la feuille de données du graphique
    int defaultWorksheetIndex = 0;


    //Obtenir la feuille de données du graphique
    IChartDataWorkbook fact = ppChart.ChartData.ChartDataWorkbook;

    //Modifier les valeurs des séries du graphique pour la première catégorie
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 1000));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 2500));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 4000));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 4, 1, 3000));

    //Définir le titre du graphique
    ppChart.HasTitle = true;
    ppChart.ChartTitle.AddTextFrameForOverriding("Ventes 2007");
    IPortionFormat format = ppChart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0].PortionFormat;
    format.FontItalic = NullableBool.True;
    format.FontHeight = 18;
    format.FillFormat.FillType = FillType.Solid;
    format.FillFormat.SolidFillColor.Color = Color.Black;


    ////Définir les valeurs des axes
    ppChart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
    ppChart.Axes.VerticalAxis.IsAutomaticMinValue = false;
    ppChart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
    ppChart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;

    ppChart.Axes.VerticalAxis.MaxValue = 4000.0F;
    ppChart.Axes.VerticalAxis.MinValue = 0.0F;
    ppChart.Axes.VerticalAxis.MajorUnit = 2000.0F;
    ppChart.Axes.VerticalAxis.MinorUnit = 1000.0F;
    ppChart.Axes.VerticalAxis.TickLabelPosition = TickLabelPositionType.NextTo;

    //Définir la rotation du graphique
    ppChart.Rotation3D.RotationX = 15;
    ppChart.Rotation3D.RotationY = 20;

    //Enregistrer la présentation
    pres.Save("AsposeSampleChart.pptx", SaveFormat.Pptx);
}
```



{{% alert color="primary" %}} 

## **Ressources**
Les projets et fichiers utilisés dans cet article peuvent être téléchargés depuis notre site Web :

- [Télécharger la présentation générée par VSTO](http://docs.aspose.com:8082/docs/download/attachments/87523560/VSTOSampleChart.pptx).
- [Télécharger l'exemple de graphique généré par Aspose.Slides](http://docs.aspose.com:8082/docs/download/attachments/87523560/AsposeSampleChart.pptx).

{{% /alert %}}