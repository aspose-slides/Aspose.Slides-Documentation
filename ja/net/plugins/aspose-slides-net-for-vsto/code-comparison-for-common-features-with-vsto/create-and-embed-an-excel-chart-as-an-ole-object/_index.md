---
title: ExcelチャートをOLEオブジェクトとして作成および埋め込む
type: docs
weight: 70
url: /ja/net/create-and-embed-an-excel-chart-as-an-ole-object/
---

以下の2つのコード例は、説明しているタスクが複雑であるため、長く詳細です。Microsoft Excelのワークブックを作成し、チャートを作成し、その後チャートを埋め込むMicrosoft PowerPointプレゼンテーションを作成します。OLEオブジェクトには元の文書へのリンクが含まれているため、埋め込まれたファイルをダブルクリックすると、ファイルとそのアプリケーションが起動します。
## **VSTO**
VSTOを使用して、以下の手順が実行されます:

1. Microsoft Excel ApplicationClassオブジェクトのインスタンスを作成します。
1. 1つのシートを持つ新しいワークブックを作成します。
1. シートにチャートを追加します。
1. ワークブックを保存します。
1. チャートデータを含むワークシートがあるExcelワークブックを開きます。
1. シートのChartObjectsコレクションを取得します。
1. コピーするチャートを取得します。
1. Microsoft PowerPointプレゼンテーションを作成します。
1. プレゼンテーションに空のスライドを追加します。
1. Excelワークシートからクリップボードにチャートをコピーします。
1. PowerPointプレゼンテーションにチャートを貼り付けます。
1. スライドにチャートを配置します。
1. プレゼンテーションを保存します。

``` csharp

 public void SetCellValue(xlNS.Worksheet targetSheet, string Cell, object Value)

{

	targetSheet.get_Range(Cell, Cell).set_Value(xlNS.XlRangeValueDataType.xlRangeValueDefault, Value);

}

public void CreateNewChartInExcel()

{

	// Excel ApplicationClassインスタンスの変数を宣言します。

	Microsoft.Office.Interop.Excel.Application excelApplication = new xlNS.Application() ;//new Microsoft.Office.Interop.Excel.ApplicationClass();

	// Workbooks.Openメソッドのパラメータの変数を宣言します。

	string paramWorkbookPath = System.Windows.Forms.Application.StartupPath+@"\ChartData.xlsx";

	object paramMissing = Type.Missing;

	// Chart.ChartWizardメソッドの変数を宣言します。

	object paramChartFormat = 1;

	object paramCategoryLabels = 0;

	object paramSeriesLabels = 0;

	bool paramHasLegend = true;

	object paramTitle = "四半期ごとの売上";

	object paramCategoryTitle = "会計四半期";

	object paramValueTitle = "十億";

	try

	{

		// Excel ApplicationClassオブジェクトのインスタンスを作成します。

	   // excelApplication = new Microsoft.Office.Interop.Excel.ApplicationClass();

		// 1つのシートを持つ新しいワークブックを作成します。

		xlNS.Workbook newWorkbook = excelApplication.Workbooks.Add(xlNS.XlWBATemplate.xlWBATWorksheet);

		// シートの名前を変更します。

		xlNS.Worksheet targetSheet = (xlNS.Worksheet)(newWorkbook.Worksheets[1]);

		targetSheet.Name = "四半期ごとの売上";

		// シートにチャートのデータを挿入します。

		//              A       B       C       D       E

		//     1                Q1      Q2      Q3      Q4

		//     2    N. America  1.5     2       1.5     2.5

		//     3    S. America  2       1.75    2       2

		//     4    Europe      2.25    2       2.5     2

		//     5    Asia        2.5     2.5     2       2.75

		SetCellValue(targetSheet, "A2", "N. America");

		SetCellValue(targetSheet, "A3", "S. America");

		SetCellValue(targetSheet, "A4", "Europe");

		SetCellValue(targetSheet, "A5", "Asia");

		SetCellValue(targetSheet, "B1", "Q1");

		SetCellValue(targetSheet, "B2", 1.5);

		SetCellValue(targetSheet, "B3", 2);

		SetCellValue(targetSheet, "B4", 2.25);

		SetCellValue(targetSheet, "B5", 2.5);

		SetCellValue(targetSheet, "C1", "Q2");

		SetCellValue(targetSheet, "C2", 2);

		SetCellValue(targetSheet, "C3", 1.75);

		SetCellValue(targetSheet, "C4", 2);

		SetCellValue(targetSheet, "C5", 2.5);

		SetCellValue(targetSheet, "D1", "Q3");

		SetCellValue(targetSheet, "D2", 1.5);

		SetCellValue(targetSheet, "D3", 2);

		SetCellValue(targetSheet, "D4", 2.5);

		SetCellValue(targetSheet, "D5", 2);

		SetCellValue(targetSheet, "E1", "Q4");

		SetCellValue(targetSheet, "E2", 2.5);

		SetCellValue(targetSheet, "E3", 2);

		SetCellValue(targetSheet, "E4", 2);

		SetCellValue(targetSheet, "E5", 2.75);

		// チャートデータを保持する範囲を取得します。

		xlNS.Range dataRange = targetSheet.get_Range("A1", "E5");

		// シートのChartObjectsコレクションを取得します。

		xlNS.ChartObjects chartObjects = (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

		// コレクションにチャートを追加します。

		xlNS.ChartObject newChartObject = chartObjects.Add(0, 100, 600, 300);

		newChartObject.Name = "売上チャート";

		// データの新しいチャートを作成します。

		newChartObject.Chart.ChartWizard(dataRange, xlNS.XlChartType.xl3DColumn, paramChartFormat, xlNS.XlRowCol.xlRows,

			paramCategoryLabels, paramSeriesLabels, paramHasLegend, paramTitle, paramCategoryTitle, paramValueTitle, paramMissing);

		// ワークブックを保存します。

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

			// Excelを閉じます。

			excelApplication.Quit();

		}

	}

}

public void UseCopyPaste()

{

	// PowerPointオブジェクトへの参照を保持する変数を宣言します。

	pptNS.Application powerpointApplication = null;

	pptNS.Presentation pptPresentation = null;

	pptNS.Slide pptSlide = null;

	pptNS.ShapeRange shapeRange = null;

	// Excelオブジェクトへの参照を保持する変数を宣言します。

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

		// PowerPointのインスタンスを作成します。

		powerpointApplication =new pptNS.Application();

		// Excelのインスタンスを作成します。

		excelApplication = new xlNS.Application();

		// チャートデータを含むワークシートがあるExcelワークブックを開きます。

		excelWorkBook = excelApplication.Workbooks.Open(paramWorkbookPath,

			paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,

			paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,

			paramMissing, paramMissing, paramMissing, paramMissing);

		// チャートを含むワークシートを取得します。

		targetSheet =

			(xlNS.Worksheet)(excelWorkBook.Worksheets["四半期ごとの売上"]);

		// シートのChartObjectsコレクションを取得します。

		chartObjects =

			(xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

		// コピーするチャートを取得します。

		existingChartObject =

			(xlNS.ChartObject)(chartObjects.Item("売上チャート"));

		// PowerPointプレゼンテーションを作成します。

		pptPresentation =

			powerpointApplication.Presentations.Add(

			Microsoft.Office.Core.MsoTriState.msoTrue);

		// プレゼンテーションに空のスライドを追加します。

		pptSlide =

			pptPresentation.Slides.Add(1, pptNS.PpSlideLayout.ppLayoutBlank);

		// Excelワークシートからクリップボードにチャートをコピーします。

		existingChartObject.Copy();

		// PowerPointプレゼンテーションにチャートを貼り付けます。

		shapeRange = pptSlide.Shapes.Paste();

		// スライドにチャートを配置します。

		shapeRange.Left = 60;

		shapeRange.Top = 100;

		// プレゼンテーションを保存します。

		pptPresentation.SaveAs(paramPresentationPath, pptNS.PpSaveAsFileType.ppSaveAsOpenXMLPresentation, Microsoft.Office.Core.MsoTriState.msoTrue);

	}

	catch (Exception ex)

	{

		Console.WriteLine(ex.Message);

	}

	finally

	{

		// PowerPointスライドオブジェクトを解放します。

		shapeRange = null;

		pptSlide = null;

		// プレゼンテーションオブジェクトを閉じて解放します。

		if (pptPresentation != null)

		{

			pptPresentation.Close();

			pptPresentation = null;

		}

		// PowerPointを終了し、ApplicationClassオブジェクトを解放します。

		if (powerpointApplication != null)

		{

			powerpointApplication.Quit();

			powerpointApplication = null;

		}

		// Excelオブジェクトを解放します。

		targetSheet = null;

		chartObjects = null;

		existingChartObject = null;

		// Excel Workbookオブジェクトを閉じて解放します。

		if (excelWorkBook != null)

		{

			excelWorkBook.Close(false, paramMissing, paramMissing);

			excelWorkBook = null;

		}

		// Excelを終了し、ApplicationClassオブジェクトを解放します。

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
Aspose.Slides for .NETを使用して、以下の手順が実行されます:

1. Aspose.Cells for .NETを使用してワークブックを作成します。
1. Microsoft Excelチャートを作成します。
1. ExcelチャートのOLEサイズを設定します。
1. チャートの画像を取得します。
1. Aspose.Slides for .NETを使用してPPTXプレゼンテーションにExcelチャートをOLEオブジェクトとして埋め込みます。
1. オブジェクトが変更された問題に対処するために、ステップ3で取得した画像で変更されたオブジェクトの画像を置き換えます。
1. 出力プレゼンテーションをPPTX形式でディスクに書き込みます。

``` csharp

 static void Main(string[] args)

{

	//ワークブックを作成

	Workbook wb = new Workbook();

	//Excelチャートを追加

	int chartSheetIndex = AddExcelChartInWorkbook(wb);

	wb.Worksheets.SetOleSize(0, 5, 0, 5);

	Bitmap imgChart = wb.Worksheets[chartSheetIndex].Charts[0].ToImage();

	//ワークブックをストリームに保存

	MemoryStream wbStream = wb.SaveToStream();

	//プレゼンテーションを作成

	PresentationEx pres = new PresentationEx();

	SlideEx sld = pres.Slides[0];

	//スライドにワークブックを追加

	AddExcelChartInPresentation(pres, sld, wbStream, imgChart);

	//出力プレゼンテーションをディスクに書き込む

	pres.Write("chart.pptx");

}

static int AddExcelChartInWorkbook(Workbook wb)

{

	//データでセルを埋めるために新しいワークシートを追加

	int dataSheetIdx = wb.Worksheets.Add();

	Worksheet dataSheet = wb.Worksheets[dataSheetIdx];

	string sheetName = "DataSheet";

	dataSheet.Name = sheetName;

	//データシートにデータを埋める

	dataSheet.Cells["A2"].PutValue("N. America");

	dataSheet.Cells["A3"].PutValue("S. America");

	dataSheet.Cells["A4"].PutValue("Europe");

	dataSheet.Cells["A5"].PutValue("Asia");

	dataSheet.Cells["B1"].PutValue("Q1");

	dataSheet.Cells["B2"].PutValue(1.5);

	dataSheet.Cells["B3"].PutValue(2);

	dataSheet.Cells["B4"].PutValue(2.25);

	dataSheet.Cells["B5"].PutValue(2.5);

	dataSheet.Cells["C1"].PutValue("Q2");

	dataSheet.Cells["C2"].PutValue(2);

	dataSheet.Cells["C3"].PutValue(1.75);

	dataSheet.Cells["C4"].PutValue(2);

	dataSheet.Cells["C5"].PutValue(2.5);

	dataSheet.Cells["D1"].PutValue("Q3");

	dataSheet.Cells["D2"].PutValue(1.5);

	dataSheet.Cells["D3"].PutValue(2);

	dataSheet.Cells["D4"].PutValue(2.5);

	dataSheet.Cells["D5"].PutValue(2);

	dataSheet.Cells["E1"].PutValue("Q4");

	dataSheet.Cells["E2"].PutValue(2.5);

	dataSheet.Cells["E3"].PutValue(2);

	dataSheet.Cells["E4"].PutValue(2);

	dataSheet.Cells["E5"].PutValue(2.75);

	//チャートシートを追加

	int chartSheetIdx = wb.Worksheets.Add(SheetType.Chart);

	Worksheet chartSheet = wb.Worksheets[chartSheetIdx];

	chartSheet.Name = "ChartSheet";

	//DataSheetからデータ系列を使ってChartSheetにチャートを追加

	int chartIdx = chartSheet.Charts.Add(ChartType.Column3DClustered, 0, 5, 0, 5);

	Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIdx];

	chart.NSeries.Add(sheetName + "!A1:E5", false);

	//チャートのタイトルを設定

	chart.Title.Text = "四半期ごとの売上";

	//プロットエリアの前景色を設定

	chart.PlotArea.Area.ForegroundColor = Color.White;

	//プロットエリアの背景色を設定

	chart.PlotArea.Area.BackgroundColor = Color.White;

	//チャートエリアの前景色を設定

	chart.ChartArea.Area.BackgroundColor = Color.White;

	chart.Title.TextFont.Size = 16;

	//チャートのカテゴリ軸のタイトルを設定

	chart.CategoryAxis.Title.Text = "会計四半期";

	//チャートの値軸のタイトルを設定

	chart.ValueAxis.Title.Text = "十億";

	//ChartSheetをアクティブシートに設定

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
## **サンプルコードのダウンロード**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/772950)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Create.and.Embed.an.Excel.Chart.as.an.OLE.Object.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20and%20Embed%20an%20Excel%20Chart%20as%20an%20OLE%20Object%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Create%20and%20Embed%20an%20Excel%20Chart%20as%20an%20OLE%20Object%20\(Aspose.Slides\).zip)