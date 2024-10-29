---
title: Créer et intégrer un graphique Excel en tant qu'objet OLE dans une diapositive Microsoft PowerPoint
type: docs
weight: 70
url: /fr/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
---

{{% alert color="primary" %}} 

 Les graphiques sont des représentations visuelles de vos données et sont largement utilisés dans les diapositives de présentation. Cet article vous montrera le code pour créer et intégrer un graphique Excel en tant qu'objet OLE dans la diapositive PowerPoint par programmation en utilisant [VSTO](/slides/fr/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) et [Aspose.Slides pour .NET](/slides/fr/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/).

{{% /alert %}} 
## **Création et intégration d'un graphique Excel**
Les deux exemples de code ci-dessous sont longs et détaillés car la tâche qu'ils décrivent est complexe. Vous créez un classeur Microsoft Excel, créez un graphique puis créez la présentation Microsoft PowerPoint dans laquelle vous allez intégrer le graphique. Les objets OLE contiennent des liens vers le document d'origine, donc un utilisateur qui double-clique sur le fichier intégré lancera le fichier et son application.
## **Exemple VSTO**
En utilisant VSTO, les étapes suivantes sont effectuées :

1. Créer une instance de l'objet Microsoft Excel ApplicationClass.
1. Créer un nouveau classeur avec une feuille.
1. Ajouter un graphique à la feuille.
1. Enregistrer le classeur.
1. Ouvrir le classeur Excel contenant la feuille de calcul avec les données du graphique.
1. Obtenir la collection ChartObjects pour la feuille.
1. Obtenir le graphique à copier.
1. Créer une présentation Microsoft PowerPoint.
1. Ajouter une diapositive vierge à la présentation.
1. Copier le graphique de la feuille de calcul Excel dans le presse-papiers.
1. Coller le graphique dans la présentation PowerPoint.
1. Positionner le graphique sur la diapositive.
1. Enregistrer la présentation.

```c#
CreateNewChartInExcel();
UseCopyPaste();
```

```c#
static void SetCellValue(xlNS.Worksheet targetSheet, string Cell, object Value)
{
    targetSheet.get_Range(Cell, Cell).set_Value(xlNS.XlRangeValueDataType.xlRangeValueDefault, Value);
}
```

```c#
static void CreateNewChartInExcel()
{
    // Déclarer une variable pour l'instance Excel ApplicationClass.
    Microsoft.Office.Interop.Excel.ApplicationClass excelApplication = null;

    // Déclarer des variables pour les paramètres de la méthode Workbooks.Open.
    string paramWorkbookPath = Application.StartupPath + @"\ChartData.xlsx";
    object paramMissing = Type.Missing;

    // Déclarer des variables pour la méthode Chart.ChartWizard.
    object paramChartFormat = 1;
    object paramCategoryLabels = 0;
    object paramSeriesLabels = 0;
    bool paramHasLegend = true;
    object paramTitle = "Ventes par trimestre";
    object paramCategoryTitle = "Trimestre fiscal";
    object paramValueTitle = "Milliards";

    try
    {
        // Créer une instance de l'objet Excel ApplicationClass.
        excelApplication = new Microsoft.Office.Interop.Excel.ApplicationClass();

        // Créer un nouveau classeur avec 1 feuille.
        xlNS.Workbook newWorkbook = excelApplication.Workbooks.Add(xlNS.XlWBATemplate.xlWBATWorksheet);

        // Changer le nom de la feuille.
        xlNS.Worksheet targetSheet = (xlNS.Worksheet)(newWorkbook.Worksheets[1]);
        targetSheet.Name = "Ventes trimestrielles";

        // Insérer quelques données pour le graphique dans la feuille.
        //              A       B       C       D       E
        //     1                T1      T2      T3      T4
        //     2    Am. N.    1.5     2       1.5     2.5
        //     3    Am. S.    2       1.75    2       2
        //     4    Europe     2.25    2       2.5     2
        //     5    Asie       2.5     2.5     2       2.75

        SetCellValue(targetSheet, "A2", "Am. N.");
        SetCellValue(targetSheet, "A3", "Am. S.");
        SetCellValue(targetSheet, "A4", "Europe");
        SetCellValue(targetSheet, "A5", "Asie");

        SetCellValue(targetSheet, "B1", "T1");
        SetCellValue(targetSheet, "B2", 1.5);
        SetCellValue(targetSheet, "B3", 2);
        SetCellValue(targetSheet, "B4", 2.25);
        SetCellValue(targetSheet, "B5", 2.5);

        SetCellValue(targetSheet, "C1", "T2");
        SetCellValue(targetSheet, "C2", 2);
        SetCellValue(targetSheet, "C3", 1.75);
        SetCellValue(targetSheet, "C4", 2);
        SetCellValue(targetSheet, "C5", 2.5);

        SetCellValue(targetSheet, "D1", "T3");
        SetCellValue(targetSheet, "D2", 1.5);
        SetCellValue(targetSheet, "D3", 2);
        SetCellValue(targetSheet, "D4", 2.5);
        SetCellValue(targetSheet, "D5", 2);

        SetCellValue(targetSheet, "E1", "T4");
        SetCellValue(targetSheet, "E2", 2.5);
        SetCellValue(targetSheet, "E3", 2);
        SetCellValue(targetSheet, "E4", 2);
        SetCellValue(targetSheet, "E5", 2.75);

        // Obtenir la plage contenant les données du graphique.
        xlNS.Range dataRange = targetSheet.get_Range("A1", "E5");

        // Obtenir la collection ChartObjects pour la feuille.
        xlNS.ChartObjects chartObjects = (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

        // Ajouter un graphique à la collection.
        xlNS.ChartObject newChartObject = chartObjects.Add(0, 100, 600, 300);
        newChartObject.Name = "Graphique des ventes";

        // Créer un nouveau graphique à partir des données.
        newChartObject.Chart.ChartWizard(dataRange, xlNS.XlChartType.xl3DColumn, paramChartFormat, xlNS.XlRowCol.xlRows,
            paramCategoryLabels, paramSeriesLabels, paramHasLegend, paramTitle, paramCategoryTitle, paramValueTitle, paramMissing);

        // Enregistrer le classeur.
        newWorkbook.SaveAs(paramWorkbookPath, paramMissing, paramMissing, paramMissing, paramMissing,
            paramMissing, xlNS.XlSaveAsAccessMode.xlNoChange, paramMissing, paramMissing, paramMissing, paramMissing, paramMissing);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        if (excelApplication != null)
        {
            // Fermer Excel.
            excelApplication.Quit();
        }
    }
}
```

```c#
static void UseCopyPaste()
{
    // Déclarer des variables pour contenir des références aux objets PowerPoint.
    pptNS.ApplicationClass powerpointApplication = null;
    pptNS.Presentation pptPresentation = null;
    pptNS.Slide pptSlide = null;
    pptNS.ShapeRange shapeRange = null;

    // Déclarer des variables pour contenir des références aux objets Excel.
    xlNS.ApplicationClass excelApplication = null;
    xlNS.Workbook excelWorkBook = null;
    xlNS.Worksheet targetSheet = null;
    xlNS.ChartObjects chartObjects = null;
    xlNS.ChartObject existingChartObject = null;

    string paramPresentationPath = Application.StartupPath + @"\ChartTest.pptx";
    string paramWorkbookPath = Application.StartupPath + @"\ChartData.xlsx";
    object paramMissing = Type.Missing;

    try
    {
        // Créer une instance de PowerPoint.
        powerpointApplication = new pptNS.ApplicationClass();

        // Créer une instance d'Excel.
        excelApplication = new xlNS.ApplicationClass();

        // Ouvrir le classeur Excel contenant la feuille de calcul avec les données du graphique.
        excelWorkBook = excelApplication.Workbooks.Open(paramWorkbookPath,
            paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
            paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
            paramMissing, paramMissing, paramMissing, paramMissing);

        // Obtenir la feuille de calcul contenant le graphique.
        targetSheet =
            (xlNS.Worksheet)(excelWorkBook.Worksheets["Ventes trimestrielles"]);

        // Obtenir la collection ChartObjects pour la feuille.
        chartObjects =
            (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

        // Obtenir le graphique à copier.
        existingChartObject =
            (xlNS.ChartObject)(chartObjects.Item("Graphique des ventes"));

        // Créer une présentation PowerPoint.
        pptPresentation =
            powerpointApplication.Presentations.Add(
            Microsoft.Office.Core.MsoTriState.msoTrue);

        // Ajouter une diapositive vierge à la présentation.
        pptSlide =
            pptPresentation.Slides.Add(1, pptNS.PpSlideLayout.ppLayoutBlank);

        // Copier le graphique de la feuille de calcul Excel dans le presse-papiers.
        existingChartObject.Copy();

        // Coller le graphique dans la présentation PowerPoint.
        shapeRange = pptSlide.Shapes.Paste();

        // Positionner le graphique sur la diapositive.
        shapeRange.Left = 60;
        shapeRange.Top = 100;

        // Enregistrer la présentation.
        pptPresentation.SaveAs(paramPresentationPath, pptNS.PpSaveAsFileType.ppSaveAsOpenXMLPresentation, Microsoft.Office.Core.MsoTriState.msoTrue);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        // Libérer l'objet diapositive PowerPoint.
        shapeRange = null;
        pptSlide = null;

        // Fermer et libérer l'objet Présentation.
        if (pptPresentation != null)
        {
            pptPresentation.Close();
            pptPresentation = null;
        }

        // Quitter PowerPoint et libérer l'objet ApplicationClass.
        if (powerpointApplication != null)
        {
            powerpointApplication.Quit();
            powerpointApplication = null;
        }

        // Libérer les objets Excel.
        targetSheet = null;
        chartObjects = null;
        existingChartObject = null;

        // Fermer et libérer l'objet Workbook Excel.
        if (excelWorkBook != null)
        {
            excelWorkBook.Close(false, paramMissing, paramMissing);
            excelWorkBook = null;
        }

        // Quitter Excel et libérer l'objet ApplicationClass.
        if (excelApplication != null)
        {
            excelApplication.Quit();
            excelApplication = null;
        }

        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }
}
```

## **Exemple Aspose.Slides pour .NET**
En utilisant Aspose.Slides pour .NET, les étapes suivantes sont effectuées :

1. Créer un classeur en utilisant Aspose.Cells pour .NET.
1. Créer un graphique Microsoft Excel.
1. Définir la taille OLE du graphique Excel.
1. Obtenir une image du graphique.
1. Intégrer le graphique Excel en tant qu'objet OLE à l'intérieur de la présentation PPTX en utilisant Aspose.Slides pour .NET.
1. Remplacer l'image d'objet modifié par l'image obtenue à l'étape 3 pour tenir compte du problème d'objet modifié.
1. Écrire la présentation de sortie sur le disque au format PPTX.

```c#
//Étape - 1: Créer un graphique Excel en utilisant Aspose.Cells
//--------------------------------------------------
//Créer un classeur
Aspose.Cells.Workbook wb = new Aspose.Cells.Workbook();
//Ajouter un graphique Excel
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(wb, chartRows, chartCols);
//Étape - 2: Définir la taille OLE du graphique. en utilisant Aspose.Cells
//-----------------------------------------------------------
wb.Worksheets.SetOleSize(0, chartRows, 0, chartCols);
//Étape - 3: Obtenir l'image du graphique avec Aspose.Cells
//-----------------------------------------------------------
Bitmap imgChart = wb.Worksheets[chartSheetIndex].Charts[0].ToImage();
//Enregistrer le classeur dans un flux
MemoryStream wbStream = wb.SaveToStream();
//Étape - 4  ET 5
//-----------------------------------------------------------
//Étape - 4: Intégrer le graphique en tant qu'objet OLE à l'intérieur de la présentation .ppt en utilisant Aspose.Slides
//-----------------------------------------------------------
//Étape - 5: Remplacer l'image d'objet modifié par l'image obtenue à l'étape 3 pour tenir compte du problème d'objet modifié
//-----------------------------------------------------------
//Créer une présentation
Presentation pres = new Presentation();
ISlide sld = pres.Slides[0];
//Ajouter le classeur à la diapositive
AddExcelChartInPresentation(pres, sld, wbStream, imgChart);
//Étape - 6: Écrire la présentation de sortie sur le disque
//-----------------------------------------------------------
pres.Save("OutputChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

```c#
static void AddExcelChartInPresentation(Presentation presentation, ISlide slide, Stream workbookStream, Bitmap chartImage)
{
    float oleWidth = presentation.SlideSize.Size.Width;
    float oleHeight = presentation.SlideSize.Size.Height;

    byte[] chartOleData = new byte[workbookStream.Length];
    workbookStream.Position = 0;
    workbookStream.Read(chartOleData, 0, chartOleData.Length);

    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(chartOleData, "xls");
    IOleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(0, 0, oleWidth, oleHeight, dataInfo);

    using (MemoryStream imageStream = new MemoryStream())
    {
        chartImage.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);

        imageStream.Position = 0;
        IPPImage image = presentation.Images.AddImage(imageStream);

        oleFrame.SubstitutePictureFormat.Picture.Image = image;
    }
}
```

```c#
static int AddExcelChartInWorkbook(Aspose.Cells.Workbook wb, int chartRows, int chartCols)
{
    //Tableau des noms de cellules
    string[] cellsName = new string[]
      {
  "A1", "A2", "A3", "A4",
  "B1", "B2", "B3", "B4",
  "C1", "C2", "C3", "C4",
  "D1", "D2", "D3", "D4",
  "E1", "E2", "E3", "E4"
      };

    //Tableau des données des cellules
    int[] cellsValue = new int[]
      {
 67,86,68,91,
 44,64,89,48,
 46,97,78,60,
 43,29,69,26,
 24,40,38,25
      };
    //Ajouter une nouvelle feuille de calcul pour peupler les cellules avec les données
    int dataSheetIdx = wb.Worksheets.Add();
    Aspose.Cells.Worksheet dataSheet = wb.Worksheets[dataSheetIdx];
    string sheetName = "FeuilleDeDonnées";
    dataSheet.Name = sheetName;
    //Peupler la FeuilleDeDonnées avec des données
    for (int i = 0; i < cellsName.Length; i++)
    {
        string cellName = cellsName[i];
        int cellValue = cellsValue[i];
        dataSheet.Cells[cellName].PutValue(cellValue);
    }
    //Ajouter une feuille de graphique
    int chartSheetIdx = wb.Worksheets.Add(Aspose.Cells.SheetType.Chart);
    Aspose.Cells.Worksheet chartSheet = wb.Worksheets[chartSheetIdx];
    chartSheet.Name = "FeuilleDeGraphique";
    //Ajouter un graphique dans la FeuilleDeGraphique avec des séries de données de FeuilleDeDonnées
    int chartIdx = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, chartRows, 0, chartCols);
    Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIdx];
    chart.NSeries.Add(sheetName + "!A1:E1", false);
    chart.NSeries.Add(sheetName + "!A2:E2", false);
    chart.NSeries.Add(sheetName + "!A3:E3", false);
    chart.NSeries.Add(sheetName + "!A4:E4", false);
    //Définir ChartSheet comme feuille active
    wb.Worksheets.ActiveSheetIndex = chartSheetIdx;
    return chartSheetIdx;
}
```