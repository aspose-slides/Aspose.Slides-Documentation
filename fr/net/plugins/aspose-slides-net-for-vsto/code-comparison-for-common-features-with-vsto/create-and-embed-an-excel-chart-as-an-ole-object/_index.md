---
title: Créer et intégrer un graphique Excel en tant qu'objet OLE
type: docs
weight: 70
url: /fr/net/create-and-embed-an-excel-chart-as-an-ole-object/
---

Les deux exemples de code ci-dessous sont longs et détaillés car la tâche qu'ils décrivent est complexe. Vous créez un classeur Microsoft Excel, créez un graphique puis créez la présentation Microsoft PowerPoint dans laquelle vous allez intégrer le graphique. Les objets OLE contiennent des liens vers le document original, donc un utilisateur qui double-clique sur le fichier intégré lancera le fichier et son application.
## **VSTO**
En utilisant VSTO, les étapes suivantes sont effectuées :

1. Créer une instance de l'objet Microsoft Excel ApplicationClass.
1. Créer un nouveau classeur avec une feuille dedans.
1. Ajouter un graphique à la feuille.
1. Enregistrer le classeur.
1. Ouvrir le classeur Excel contenant la feuille de calcul avec les données du graphique.
1. Obtenir la collection ChartObjects pour la feuille.
1. Obtenir le graphique à copier.
1. Créer une présentation Microsoft PowerPoint.
1. Ajouter une diapositive vierge à la présentation.
1. Copier le graphique depuis la feuille de calcul Excel vers le presse-papiers.
1. Coller le graphique dans la présentation PowerPoint.
1. Positionner le graphique sur la diapositive.
1. Enregistrer la présentation.

``` csharp

 public void SetCellValue(xlNS.Worksheet targetSheet, string Cell, object Value)

{

	targetSheet.get_Range(Cell, Cell).set_Value(xlNS.XlRangeValueDataType.xlRangeValueDefault, Value);

}

public void CreateNewChartInExcel()

{

	// Déclarer une variable pour l'instance d'ApplicationClass Excel.

	Microsoft.Office.Interop.Excel.Application excelApplication = new xlNS.Application() ;//new Microsoft.Office.Interop.Excel.ApplicationClass();

	// Déclarer des variables pour les paramètres de la méthode Workbooks.Open.

	string paramWorkbookPath = System.Windows.Forms.Application.StartupPath+@"\ChartData.xlsx";

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

	   // excelApplication = new Microsoft.Office.Interop.Excel.ApplicationClass();

		// Créer un nouveau classeur avec 1 feuille dedans.

		xlNS.Workbook newWorkbook = excelApplication.Workbooks.Add(xlNS.XlWBATemplate.xlWBATWorksheet);

		// Changer le nom de la feuille.

		xlNS.Worksheet targetSheet = (xlNS.Worksheet)(newWorkbook.Worksheets[1]);

		targetSheet.Name = "Ventes trimestrielles";

		// Insérer quelques données pour le graphique dans la feuille.

		//              A       B       C       D       E

		//     1                T1      T2      T3      T4

		//     2    Amérique du Nord  1.5     2       1.5     2.5

		//     3    Amérique du Sud  2       1.75    2       2

		//     4    Europe      2.25    2       2.5     2

		//     5    Asie        2.5     2.5     2       2.75

		SetCellValue(targetSheet, "A2", "Amérique du Nord");

		SetCellValue(targetSheet, "A3", "Amérique du Sud");

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

		// Créer un nouveau graphique des données.

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

public void UseCopyPaste()

{

	// Déclarer des variables pour tenir les références aux objets PowerPoint.

	pptNS.Application powerpointApplication = null;

	pptNS.Presentation pptPresentation = null;

	pptNS.Slide pptSlide = null;

	pptNS.ShapeRange shapeRange = null;

	// Déclarer des variables pour tenir les références aux objets Excel.

	xlNS.Application excelApplication = null;

	xlNS.Workbook excelWorkBook = null;

	xlNS.Worksheet targetSheet = null;

	xlNS.ChartObjects chartObjects = null;

	xlNS.ChartObject existingChartObject = null;

	string paramPresentationPath = System.Windows.Forms.Application.StartupPath + @"\ChartTest.pptx";

	string paramWorkbookPath = System.Windows.Forms.Application.StartupPath + @"\ChartData.xlsx";

	object paramMissing = Type.Missing;

	try

	{

		// Créer une instance de PowerPoint.

		powerpointApplication =new pptNS.Application();

		// Créer une instance Excel.

		excelApplication = new xlNS.Application();

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

		// Copier le graphique depuis la feuille de calcul Excel vers le presse-papiers.

		existingChartObject.Copy();

		// Coller le graphique dans la présentation PowerPoint.

		shapeRange = pptSlide.Shapes.Paste();

		// Positionner le graphique sur la diapositive.

		shapeRange.Left = 60;

		shapeRange.Top = 100;

		// Sauvegarder la présentation.

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

		// Fermer et libérer l'objet Presentation.

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

private void ThisAddIn_Startup(object sender, System.EventArgs e)

{

	CreateNewChartInExcel();

	UseCopyPaste();

}

``` 
## **Aspose.Slides**
En utilisant Aspose.Slides pour .NET, les étapes suivantes sont effectuées :

1. Créer un classeur en utilisant Aspose.Cells pour .NET.
1. Créer un graphique Microsoft Excel.
1. Définir la taille OLE du graphique Excel.
1. Obtenir une image du graphique.
1. Intégrer le graphique Excel en tant qu'objet OLE dans la présentation PPTX en utilisant Aspose.Slides pour .NET.
1. Remplacer l'image de l'objet modifié par l'image obtenue à l'étape 3 pour traiter le problème de l'objet modifié.
1. Écrire la présentation de sortie sur le disque au format PPTX.

``` csharp

 static void Main(string[] args)

{

	//Créer un classeur

	Workbook wb = new Workbook();

	//Ajouter un graphique Excel

	int chartSheetIndex = AddExcelChartInWorkbook(wb);

	wb.Worksheets.SetOleSize(0, 5, 0, 5);

	Bitmap imgChart = wb.Worksheets[chartSheetIndex].Charts[0].ToImage();

	//Enregistrer le classeur dans un flux

	MemoryStream wbStream = wb.SaveToStream();

	//Créer une présentation

	PresentationEx pres = new PresentationEx();

	SlideEx sld = pres.Slides[0];

	//Ajouter le classeur à la diapositive

	AddExcelChartInPresentation(pres, sld, wbStream, imgChart);

	//Écrire la présentation de sortie sur le disque

	pres.Write("chart.pptx");

}

static int AddExcelChartInWorkbook(Workbook wb)

{

	//Ajouter une nouvelle feuille de calcul pour peupler des cellules avec des données

	int dataSheetIdx = wb.Worksheets.Add();

	Worksheet dataSheet = wb.Worksheets[dataSheetIdx];

	string sheetName = "FeuilleDeDonnées";

	dataSheet.Name = sheetName;

	//Remplir la FeuilleDeDonnées avec des données

	dataSheet.Cells["A2"].PutValue("Amérique du Nord");

	dataSheet.Cells["A3"].PutValue("Amérique du Sud");

	dataSheet.Cells["A4"].PutValue("Europe");

	dataSheet.Cells["A5"].PutValue("Asie");

	dataSheet.Cells["B1"].PutValue("T1");

	dataSheet.Cells["B2"].PutValue(1.5);

	dataSheet.Cells["B3"].PutValue(2);

	dataSheet.Cells["B4"].PutValue(2.25);

	dataSheet.Cells["B5"].PutValue(2.5);

	dataSheet.Cells["C1"].PutValue("T2");

	dataSheet.Cells["C2"].PutValue(2);

	dataSheet.Cells["C3"].PutValue(1.75);

	dataSheet.Cells["C4"].PutValue(2);

	dataSheet.Cells["C5"].PutValue(2.5);

	dataSheet.Cells["D1"].PutValue("T3");

	dataSheet.Cells["D2"].PutValue(1.5);

	dataSheet.Cells["D3"].PutValue(2);

	dataSheet.Cells["D4"].PutValue(2.5);

	dataSheet.Cells["D5"].PutValue(2);

	dataSheet.Cells["E1"].PutValue("T4");

	dataSheet.Cells["E2"].PutValue(2.5);

	dataSheet.Cells["E3"].PutValue(2);

	dataSheet.Cells["E4"].PutValue(2);

	dataSheet.Cells["E5"].PutValue(2.75);

	//Ajouter une feuille de graphique

	int chartSheetIdx = wb.Worksheets.Add(SheetType.Chart);

	Worksheet chartSheet = wb.Worksheets[chartSheetIdx];

	chartSheet.Name = "FeuilleDeGraphique";

	//Ajouter un graphique dans la FeuilleDeGraphique avec des séries de données provenant de la FeuilleDeDonnées

	int chartIdx = chartSheet.Charts.Add(ChartType.Column3DClustered, 0, 5, 0, 5);

	Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIdx];

	chart.NSeries.Add(sheetName + "!A1:E5", false);

	//Définir le titre du graphique

	chart.Title.Text = "Ventes par trimestre";

	//Définir la couleur de premier plan de la zone de tracé

	chart.PlotArea.Area.ForegroundColor = Color.White;

	//Définir la couleur de fond de la zone de tracé

	chart.PlotArea.Area.BackgroundColor = Color.White;

	//Définir la couleur de premier plan de la zone de graphique

	chart.ChartArea.Area.BackgroundColor = Color.White;

	chart.Title.TextFont.Size = 16;

	//Définir le titre de l'axe des catégories du graphique

	chart.CategoryAxis.Title.Text = "Trimestre fiscal";

	//Définir le titre de l'axe des valeurs du graphique

	chart.ValueAxis.Title.Text = "Milliards";

	//Définir une feuille active pour la FeuilleDeGraphique

	wb.Worksheets.ActiveSheetIndex = chartSheetIdx;

	return chartSheetIdx;

}

private static void AddExcelChartInPresentation(PresentationEx pres, SlideEx sld, Stream wbStream, Bitmap imgChart)

{

	float oleWidth = pres.SlideSize.Size.Width;

	float oleHeight = pres.SlideSize.Size.Height;

	int x = 0;

	byte[] chartOleData = new byte[wbStream.Length];

	wbStream.Position = 0;

	wbStream.Read(chartOleData, 0, chartOleData.Length);

	OleObjectFrameEx oof = null;

	oof = sld.Shapes.AddOleObjectFrame(x, 0, oleWidth, oleHeight, "Excel.Sheet.8", chartOleData);

    using (MemoryStream imageStream = new MemoryStream())

    {

        imgChart.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);

        imageStream.Position = 0;

        IPPImage ppImage = pres.Images.AddImage(imageStream);

        oof.SubstitutePictureFormat.Picture.Image = ppImage;

    }

}

``` 
## **Télécharger le code d'exemple**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/772950)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Create.and.Embed.an.Excel.Chart.as.an.OLE.Object.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20and%20Embed%20an%20Excel%20Chart%20as%20an%20OLE%20Object%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Create%20and%20Embed%20an%20Excel%20Chart%20as%20an%20OLE%20Object%20\(Aspose.Slides\).zip)