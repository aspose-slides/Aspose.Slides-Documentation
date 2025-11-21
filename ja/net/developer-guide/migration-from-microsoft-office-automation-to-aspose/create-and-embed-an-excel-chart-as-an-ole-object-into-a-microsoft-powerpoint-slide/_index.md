---
title: VSTO と Aspose.Slides for .NET を使用して OLE オブジェクトとして Excel チャートを作成し埋め込む
linktitle: OLE オブジェクトとして Excel チャートを作成し埋め込む
type: docs
weight: 70
url: /ja/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
keywords:
- チャート作成
- Excel チャートの埋め込み
- OLE オブジェクト
- 移行
- VSTO
- Office 自動化
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Microsoft Office の自動化から Aspose.Slides for .NET に移行し、C# で Excel チャートを OLE オブジェクトとして PowerPoint (PPT, PPTX) スライドに埋め込む。"
---

{{% alert color="primary" %}} 

チャートはデータの視覚的表現であり、プレゼンテーション スライドで広く使用されています。この記事では、[VSTO](/slides/ja/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) と [Aspose.Slides for .NET](/slides/ja/net/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) を使用して、Excel チャートを OLE オブジェクトとして PowerPoint スライドにプログラムで作成および埋め込むコードを示します。

{{% /alert %}} 
## **Creating and Embedding an Excel Chart**
以下の 2 つのコード例は長く詳細です。これは、タスク自体が複雑であるためです。Microsoft Excel ワークブックを作成し、チャートを作成し、次にそのチャートを埋め込む Microsoft PowerPoint プレゼンテーションを作成します。OLE オブジェクトは元のドキュメントへのリンクを含むため、埋め込まれたファイルをダブルクリックしたユーザーはそのファイルとアプリケーションを起動します。
## **VSTO Example**
VSTO を使用して、次の手順が実行されます。

1. Microsoft Excel ApplicationClass オブジェクトのインスタンスを作成します。
1. シートが 1 枚だけの新しいブックを作成します。
1. シートにチャートを追加します。
1. ブックを保存します。
1. チャート データを含むワークシートがある Excel ブックを開きます。
1. シートの ChartObjects コレクションを取得します。
1. コピーするチャートを取得します。
1. Microsoft PowerPoint プレゼンテーションを作成します。
1. プレゼンテーションに空白スライドを追加します。
1. Excel ワークシートからチャートをクリップボードにコピーします。
1. チャートを PowerPoint プレゼンテーションに貼り付けます。
1. スライド上のチャートの位置を調整します。
1. プレゼンテーションを保存します。
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
    // Excel ApplicationClass インスタンス用の変数を宣言します。
    Microsoft.Office.Interop.Excel.ApplicationClass excelApplication = null;

    // Workbooks.Open メソッドのパラメータ用変数を宣言します。
    string paramWorkbookPath = Application.StartupPath + @"\ChartData.xlsx";
    object paramMissing = Type.Missing;

    // Chart.ChartWizard メソッド用の変数を宣言します。
    object paramChartFormat = 1;
    object paramCategoryLabels = 0;
    object paramSeriesLabels = 0;
    bool paramHasLegend = true;
    object paramTitle = "Sales by Quarter";
    object paramCategoryTitle = "Fiscal Quarter";
    object paramValueTitle = "Billions";

    try
    {
        // Excel ApplicationClass オブジェクトのインスタンスを作成します。
        excelApplication = new Microsoft.Office.Interop.Excel.ApplicationClass();

        // シート 1 枚だけの新しいブックを作成します。
        xlNS.Workbook newWorkbook = excelApplication.Workbooks.Add(xlNS.XlWBATemplate.xlWBATWorksheet);

        // シートの名前を変更します。
        xlNS.Worksheet targetSheet = (xlNS.Worksheet)(newWorkbook.Worksheets[1]);
        targetSheet.Name = "Quarterly Sales";

        // シートにチャート用のデータを挿入します。
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

        // チャートデータが格納されている範囲を取得します。
        xlNS.Range dataRange = targetSheet.get_Range("A1", "E5");

        // シートの ChartObjects コレクションを取得します。
        xlNS.ChartObjects chartObjects = (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

        // コレクションにチャートを追加します。
        xlNS.ChartObject newChartObject = chartObjects.Add(0, 100, 600, 300);
        newChartObject.Name = "Sales Chart";

        // データから新しいチャートを作成します。
        newChartObject.Chart.ChartWizard(dataRange, xlNS.XlChartType.xl3DColumn, paramChartFormat, xlNS.XlRowCol.xlRows,
            paramCategoryLabels, paramSeriesLabels, paramHasLegend, paramTitle, paramCategoryTitle, paramValueTitle, paramMissing);

        // ブックを保存します。
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
            // Excel を終了します。
            excelApplication.Quit();
        }
    }
}
```

```c#
static void UseCopyPaste()
{
    // PowerPoint オブジェクトへの参照を保持する変数を宣言します。
    pptNS.ApplicationClass powerpointApplication = null;
    pptNS.Presentation pptPresentation = null;
    pptNS.Slide pptSlide = null;
    pptNS.ShapeRange shapeRange = null;

    // Excel オブジェクトへの参照を保持する変数を宣言します。
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
        // PowerPoint のインスタンスを作成します。
        powerpointApplication = new pptNS.ApplicationClass();

        // Excel のインスタンスを作成します。
        excelApplication = new xlNS.ApplicationClass();

        // チャートデータが含まれるワークシートを持つ Excel ブックを開きます。
        excelWorkBook = excelApplication.Workbooks.Open(paramWorkbookPath,
            paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
            paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
            paramMissing, paramMissing, paramMissing, paramMissing);

        // チャートを含むワークシートを取得します。
        targetSheet =
            (xlNS.Worksheet)(excelWorkBook.Worksheets["Quarterly Sales"]);

        // シートの ChartObjects コレクションを取得します。
        chartObjects =
            (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));

        // コピーするチャートを取得します。
        existingChartObject =
            (xlNS.ChartObject)(chartObjects.Item("Sales Chart"));

        // PowerPoint プレゼンテーションを作成します。
        pptPresentation =
            powerpointApplication.Presentations.Add(
            Microsoft.Office.Core.MsoTriState.msoTrue);

        // プレゼンテーションに空白スライドを追加します。
        pptSlide =
            pptPresentation.Slides.Add(1, pptNS.PpSlideLayout.ppLayoutBlank);

        // Excel ワークシートからチャートをクリップボードにコピーします。
        existingChartObject.Copy();

        // チャートを PowerPoint プレゼンテーションに貼り付けます。
        shapeRange = pptSlide.Shapes.Paste();

        // スライド上のチャートの位置を設定します。
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
        // PowerPoint スライドオブジェクトを解放します。
        shapeRange = null;
        pptSlide = null;

        // Presentation オブジェクトを閉じて解放します。
        if (pptPresentation != null)
        {
            pptPresentation.Close();
            pptPresentation = null;
        }

        // PowerPoint を終了し、ApplicationClass オブジェクトを解放します。
        if (powerpointApplication != null)
        {
            powerpointApplication.Quit();
            powerpointApplication = null;
        }

        // Excel オブジェクトを解放します。
        targetSheet = null;
        chartObjects = null;
        existingChartObject = null;

        // Excel Workbook オブジェクトを閉じて解放します。
        if (excelWorkBook != null)
        {
            excelWorkBook.Close(false, paramMissing, paramMissing);
            excelWorkBook = null;
        }

        // Excel を終了し、ApplicationClass オブジェクトを解放します。
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





## **Aspose.Slides for .NET Example**
Aspose.Slides for .NET を使用して、次の手順が実行されます。

1. Aspose.Cells for .NET を使用してワークブックを作成します。
1. Microsoft Excel チャートを作成します。
1. Excel チャートの OLE サイズを設定します。
1. チャートの画像を取得します。
1. Aspose.Slides for .NET を使用して、Excel チャートを PPTX プレゼンテーション内の OLE オブジェクトとして埋め込みます。
1. オブジェクト変更問題に対応するため、ステップ 3 で取得した画像でオブジェクト変更画像を置き換えます。
1. 出力プレゼンテーションを PPTX 形式でディスクに書き込みます。
```c#
//Step - 1: Aspose.Cells を使用して Excel チャートを作成する
//--------------------------------------------------
//ワークブックを作成する
Aspose.Cells.Workbook wb = new Aspose.Cells.Workbook();
//Excel チャートを追加する
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(wb, chartRows, chartCols);
//Step - 2: Aspose.Cells を使用してチャートの OLE サイズを設定する
//-----------------------------------------------------------
wb.Worksheets.SetOleSize(0, chartRows, 0, chartCols);
//Step - 3: Aspose.Cells を使用してチャートの画像を取得する
//-----------------------------------------------------------
Bitmap imgChart = wb.Worksheets[chartSheetIndex].Charts[0].ToImage();
//ワークブックをストリームに保存する
MemoryStream wbStream = wb.SaveToStream();
//Step - 4  と 5
//-----------------------------------------------------------
//Step - 4: Aspose.Slides を使用して .ppt プレゼンテーション内にチャートを OLE オブジェクトとして埋め込む
//-----------------------------------------------------------
//Step - 5: オブジェクト変更の問題に対処するため、ステップ 3 で取得した画像でオブジェクト変更画像を置き換える
//-----------------------------------------------------------
//プレゼンテーションを作成する
Presentation pres = new Presentation();
ISlide sld = pres.Slides[0];
//スライドにワークブックを追加する
AddExcelChartInPresentation(pres, sld, wbStream, imgChart);
//Step - 6: 出力プレゼンテーションをディスクに書き込む
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
    //セル名の配列
    string[] cellsName = new string[]
      {
  "A1", "A2", "A3", "A4",
  "B1", "B2", "B3", "B4",
  "C1", "C2", "C3", "C4",
  "D1", "D2", "D3", "D4",
  "E1", "E2", "E3", "E4"
      };

    //セルデータの配列
    int[] cellsValue = new int[]
      {
 67,86,68,91,
 44,64,89,48,
 46,97,78,60,
 43,29,69,26,
 24,40,38,25
      };
    //データを入力する新しいワークシートを追加
    int dataSheetIdx = wb.Worksheets.Add();
    Aspose.Cells.Worksheet dataSheet = wb.Worksheets[dataSheetIdx];
    string sheetName = "DataSheet";
    dataSheet.Name = sheetName;
    //DataSheetにデータを入力
    for (int i = 0; i < cellsName.Length; i++)
    {
        string cellName = cellsName[i];
        int cellValue = cellsValue[i];
        dataSheet.Cells[cellName].PutValue(cellValue);
    }
    //チャートシートを追加
    int chartSheetIdx = wb.Worksheets.Add(Aspose.Cells.SheetType.Chart);
    Aspose.Cells.Worksheet chartSheet = wb.Worksheets[chartSheetIdx];
    chartSheet.Name = "ChartSheet";
    //DataSheetからデータ系列を使用してChartSheetにチャートを追加
    int chartIdx = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, chartRows, 0, chartCols);
    Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIdx];
    chart.NSeries.Add(sheetName + "!A1:E1", false);
    chart.NSeries.Add(sheetName + "!A2:E2", false);
    chart.NSeries.Add(sheetName + "!A3:E3", false);
    chart.NSeries.Add(sheetName + "!A4:E4", false);
    //ChartSheetをアクティブシートに設定
    wb.Worksheets.ActiveSheetIndex = chartSheetIdx;
    return chartSheetIdx;
}
```
