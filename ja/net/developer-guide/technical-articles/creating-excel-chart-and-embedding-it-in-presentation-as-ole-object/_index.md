---
title: Excelチャートの作成とOLEオブジェクトとしてプレゼンテーションに埋め込む
type: docs
weight: 50
url: /net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
---

{{% alert color="primary" %}} 

PowerPointスライドでは、データのグラフィカルな表示のために編集可能なチャートの使用が一般的です。Asposeは、Aspose.Cells for .NETを使用してExcelチャートを作成するサポートを提供し、さらにこれらのチャートはAspose.Slides for .NETを介してPowerPointスライドにOLEオブジェクトとして埋め込むことができます。本記事では、Aspose.Cells for .NETとAspose.Slides for .NETを使用して、MS ExcelチャートをOLEオブジェクトとしてPowerPointプレゼンテーションに作成し埋め込むための必要な手順と実装をC#とVB.NETで示します。

{{% /alert %}} 
## **必要な手順**
ExcelチャートをOLEオブジェクトとしてPowerPointスライドに作成し埋め込むために必要な手順の順序は次のとおりです。

1. Aspose.Cells for .NETを使用してExcelチャートを作成します。
2. Aspose.Cells for .NETを使用してExcelチャートのOLEサイズを設定します。
3. Aspose.Cells for .NETを使用してExcelチャートの画像を取得します。
4. Aspose.Slides for .NETを使用して、PPTXプレゼンテーション内にExcelチャートをOLEオブジェクトとして埋め込みます。
5. ステップ3で取得した画像でオブジェクト変更の問題に対処するために、オブジェクト変更された画像を置き換えます。
6. 出力プレゼンテーションをPPTX形式でディスクに書き込みます。

## **必要な手順の実装**
上記の手順のC#およびVisual Basicによる実装は以下の通りです。

```c#
//ステップ1: Aspose.Cellsを使用してExcelチャートを作成
//--------------------------------------------------
//ワークブックを作成
Aspose.Cells.Workbook wb = new Aspose.Cells.Workbook();
//Excelチャートを追加
int chartRows = 55;
int chartCols = 25;
int chartSheetIndex = AddExcelChartInWorkbook(wb, chartRows, chartCols);
//ステップ2: Aspose.Cellsを使用してチャートのOLEサイズを設定
//----------------------------------------------------------- 
wb.Worksheets.SetOleSize(0, chartRows, 0, chartCols);
//ステップ3: Aspose.Cellsを使用してチャートの画像を取得
//----------------------------------------------------------- 
Bitmap imgChart = wb.Worksheets[chartSheetIndex].Charts[0].ToImage();
//ストリームにワークブックを保存
MemoryStream wbStream = wb.SaveToStream();
//ステップ4と5
//-----------------------------------------------------------
//ステップ4: Aspose.Slidesを使用して.pptプレゼンテーション内にチャートをOLEオブジェクトとして埋め込みます。
//ステップ5: ステップ3で取得した画像でオブジェクト変更の問題に対処するために、オブジェクト変更された画像を置き換えます
//----------------------------------------------------------- 
//プレゼンテーションを作成
Presentation pres = new Presentation();
ISlide sld = pres.Slides[0];
//スライドにワークブックを追加
AddExcelChartInPresentation(pres, sld, wbStream, imgChart);
//ステップ6: 出力プレゼンテーションをディスクに保存
//----------------------------------------------------------- 
pres.Save("OutputChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
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
    //データでセルを埋めるための新しいワークシートを追加
    int dataSheetIdx = wb.Worksheets.Add();
    Aspose.Cells.Worksheet dataSheet = wb.Worksheets[dataSheetIdx];
    string sheetName = "DataSheet";
    dataSheet.Name = sheetName;
    //データシートにデータを埋める
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
    //データシートからデータ系列を持つチャートをチャートシートに追加
    int chartIdx = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, chartRows, 0, chartCols);
    Aspose.Cells.Charts.Chart chart = chartSheet.Charts[chartIdx];
    chart.NSeries.Add(sheetName + "!A1:E1", false);
    chart.NSeries.Add(sheetName + "!A2:E2", false);
    chart.NSeries.Add(sheetName + "!A3:E3", false);
    chart.NSeries.Add(sheetName + "!A4:E4", false);
    //チャートシートをアクティブシートとして設定
    wb.Worksheets.ActiveSheetIndex = chartSheetIdx;
    return chartSheetIdx;
}
```

```c#
static void AddExcelChartInPresentation(Presentation pres, ISlide sld, Stream wbStream, Bitmap imgChart)
{
    float oleWidth = pres.SlideSize.Size.Width;
    float oleHeight = pres.SlideSize.Size.Height;

    byte[] chartOleData = new byte[wbStream.Length];
    wbStream.Position = 0;
    wbStream.Read(chartOleData, 0, chartOleData.Length);

    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(chartOleData, "xls");
    IOleObjectFrame oof = sld.Shapes.AddOleObjectFrame(0, 0, oleWidth, oleHeight, dataInfo);

    using (MemoryStream imageStream = new MemoryStream())
    {
        imgChart.Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);

	imageStream.Position = 0;
        IPPImage ppImage = pres.Images.AddImage(imageStream);

        oof.SubstitutePictureFormat.Picture.Image = ppImage;
    }
}
```

{{% alert color="primary" %}} 

上記の方法で作成されたプレゼンテーションは、OLEオブジェクトフレームをダブルクリックすることによりアクティブ化できるExcelチャートを含みます。

{{% /alert %}} 
## **結論**
{{% alert color="primary" %}} 

Aspose.Cells for .NETとAspose.Slides for .NETを使用することにより、Aspose.Cells for .NETがサポートするExcelチャートを作成し、作成したチャートをPowerPointスライドにOLEオブジェクトとして埋め込むことができます。また、ExcelチャートのOLEサイズも定義できます。エンドユーザーは、他のOLEオブジェクトと同様にExcelチャートをさらに編集できます。

{{% /alert %}} 
## **関連セクション**
[チャートサイズ変更のための作業ソリューション](/slides/net/working-solution-for-chart-resizing-in-pptx/)[オブジェクト変更の問題](/slides/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)