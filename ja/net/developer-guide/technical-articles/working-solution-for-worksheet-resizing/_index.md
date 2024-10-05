---
title: ワークシートサイズ変更のための作業ソリューション
type: docs
weight: 40
url: /net/working-solution-for-worksheet-resizing/
---

{{% alert color="primary" %}}

ExcelワークシートがAsposeコンポーネントを介してPowerPointプレゼンテーションにOLEとして埋め込まれると、最初のアクティベーション後に特定のスケールにサイズが変更されることが観察されました。この動作は、プレゼンテーションの事前および事後のチャートアクティベーション状態の間にかなりの視覚的違いを生み出します。この問題について詳しく調査し、本記事で取り上げた解決策を見つけました。

{{% /alert %}} 
## **背景**
[OLEフレームの追加に関する記事]()では、Aspose.Slides for .NETを使用してPowerPointプレゼンテーションにOLEフレームを追加する方法を説明しました。[オブジェクト変更の問題](/slides/net/object-changed-issue-when-adding-oleobjectframe/)に対処するため、選択した領域のワークシート画像をチャートOLEオブジェクトフレームに割り当てました。出力プレゼンテーションでは、ワークシート画像を表示するOLEオブジェクトフレームをダブルクリックすると、Excelチャートがアクティブになります。エンドユーザーは、実際のExcelワークブックに任意の変更を加え、その後、アクティブ化されたExcelワークブックの外をクリックすることで関連スライドに戻ることができます。ユーザーがスライドに戻ると、OLEオブジェクトフレームのサイズが変更されます。OLEオブジェクトフレームと埋め込まれたExcelワークブックの異なるサイズに対して、リサイズ係数は異なります。
## **リサイズの原因**
Excelワークブックには独自のウィンドウサイズがあるため、最初のアクティベーション時に元のサイズを保持しようとします。一方、OLEオブジェクトフレームには独自のサイズが存在します。マイクロソフトによると、Excelワークブックのアクティベーション時に、ExcelとPowerPointはサイズを交渉し、埋め込み操作の一部として正しい比率に確保します。ExcelウィンドウのサイズとOLEオブジェクトフレームのサイズ/位置の違いに基づいて、リサイズが行われます。
## **作業ソリューション**
リサイズ効果を回避するための2つの可能な解決策があります。

- OLEフレームのサイズをPPTでスケーリングし、OLEフレーム内の所望の行数/列数の高さ/幅に合わせる
- OLEフレームのサイズを一定に保ち、参加する行/列のサイズをスケールして選択したOLEフレームサイズにフィットさせる
## **OLEフレームサイズをワークシートの選択行/列サイズにスケールする**
このアプローチでは、埋め込まれたExcelワークブックのOLEフレームサイズをExcelワークシートの参加行数および列数の累積サイズに相当するものとして設定する方法を学びます。
## **例**
テンプレートのExcelシートを定義し、それをOLEフレームとしてプレゼンテーションに追加することを希望するとします。このシナリオでは、OLEオブジェクトフレームのサイズは、参加するワークブックの行の累積行高と列の幅に基づいて最初に計算されます。その後、OLEフレームのサイズをその計算された値に設定します。PowerPointのOLEフレームに対して赤い**埋め込みオブジェクト**メッセージを回避するために、ワークブック内の行と列の所望の部分の画像を取得し、それをOLEフレーム画像として設定します。

```csharp
WorkbookDesigner workbookDesigner = new WorkbookDesigner();
workbookDesigner.Workbook = new Workbook("AsposeTest.xls");

Presentation presentation = new Presentation("AsposeTest.ppt");

Slide slide = (Slide)presentation.Slides[0];

AddOleFrame(slide, 0, 15, 0, 3, 0, 300, 1100, 0, 0, presentation, workbookDesigner, true, 0, 0);

String fileName = "AsposeTest_Ole.ppt";
presentation.Save(fileName, Aspose.Slides.Export.SaveFormat.Ppt);
```

```csharp
private static Size SetOleAccordingToSelectedRowsCloumns(Workbook workbook, Int32 startRow, Int32 endRow, Int32 startCol,Int32 endCol, Int32 dataSheetIdx)
{
    Worksheet work = workbook.Worksheets[dataSheetIdx];

    double actualHeight = 0, actualWidth = 0;

    for (int i = startRow; i <= endRow; i++)
        actualHeight += work.Cells.GetRowHeightInch(i);

    for (int i = startCol; i <= endCol; i++)
        actualWidth += work.Cells.GetColumnWidthInch(i);
    //新しい行と列の高さを設定

    return new Size((int)(Math.Round(actualWidth, 2) * 576), (int)(Math.Round(actualHeight, 2) * 576));
}
```
```csharp
private static void AddOleFrame(Slide slide, Int32 startRow, Int32 endRow, Int32 startCol, Int32 endCol,
    Int32 dataSheetIdx, Int32 x, Int32 y, Double OleWidth, Double OleHeight,
    Presentation presentation, WorkbookDesigner workbookDesigner,
    Boolean onePagePerSheet, Int32 outputWidth, Int32 outputHeight)
{
    String tempFileName = Path.GetTempFileName();
    if (startRow == 0)
    {
        startRow++;
        endRow++;
    }

    //ワークブックのアクティブシートインデックスを設定
    workbookDesigner.Workbook.Worksheets.ActiveSheetIndex = dataSheetIdx;

    //ワークブックと選択したワークシートを取得  
    Workbook workbook = workbookDesigner.Workbook;
    Worksheet work = workbook.Worksheets[dataSheetIdx];

    //選択した行と列に応じてOLEサイズを設定
    Size SlideOleSize = SetOleAccordingToSelectedRowsCloumns(workbook, startRow, endRow, startCol, endCol, dataSheetIdx);
    OleWidth = SlideOleSize.Width;
    OleHeight = SlideOleSize.Height;

    //ワークブックのOLEサイズを設定
    workbook.Worksheets.SetOleSize(startRow, endRow, startCol, endCol);

    workbook.Worksheets[0].IsGridlinesVisible = false;

    //ワークシート画像を取得するための画像オプションを設定
    ImageOrPrintOptions imageOrPrintOptions = new ImageOrPrintOptions();
    imageOrPrintOptions.ImageFormat = System.Drawing.Imaging.ImageFormat.Bmp;
    imageOrPrintOptions.OnePagePerSheet = onePagePerSheet;

    SheetRender render = new SheetRender(workbookDesigner.Workbook.Worksheets[dataSheetIdx], imageOrPrintOptions);
    String ext = ".bmp";
    render.ToImage(0, tempFileName + ext);
    Image image = ScaleImage(Image.FromFile(tempFileName + ext), outputWidth, outputHeight);
    String newTempFileName = tempFileName.Replace(".tmp", ".tmp1") + ext;
    image.Save(newTempFileName, System.Drawing.Imaging.ImageFormat.Bmp);

    //スライドの画像コレクションに画像を追加
    var ppImage = presentation.Images.AddImage(File.ReadAllBytes(newTempFileName));

    //ワークブックをストリームに保存し、バイト配列にコピー
    Stream mstream = workbook.SaveToStream();
    byte[] chartOleData = new byte[mstream.Length];
    mstream.Position = 0;
    mstream.Read(chartOleData, 0, chartOleData.Length);

    //OLEオブジェクトフレームを追加
    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(chartOleData, "xls");
    IOleObjectFrame oleObjectFrame = slide.Shapes.AddOleObjectFrame(x, y, Convert.ToInt32(OleWidth),
        Convert.ToInt32(OleHeight), dataInfo);

    //OLEフレームの代替テキストプロパティを設定    
    oleObjectFrame.SubstitutePictureFormat.Picture.Image = ppImage;
    oleObjectFrame.AlternativeText = "image" + ppImage;
}
```

```csharp
private static Image ScaleImage(Image image, Int32 outputWidth, Int32 outputHeight)
{
    if (outputWidth == 0 && outputHeight == 0)
    {
        outputWidth = image.Width;
        outputHeight = image.Height;
    }
    Bitmap outputImage = new Bitmap(outputWidth, outputHeight, image.PixelFormat);
    outputImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);
    Graphics graphics = Graphics.FromImage(outputImage);
    graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
    System.Drawing.Rectangle srcDestRect = new System.Drawing.Rectangle(0, 0, outputWidth, outputHeight);
    graphics.DrawImage(image, srcDestRect, srcDestRect, GraphicsUnit.Pixel);
    graphics.Dispose();

    return outputImage;
}
```


## **OLEフレームサイズに応じてワークシートの行の高さと列の幅をスケールする**
このアプローチでは、カスタム設定されたOLEフレームサイズに従って参加行の高さと参加列の幅をスケールする方法を学びます。
## **例**
テンプレートのExcelシートを定義し、それをOLEフレームとしてプレゼンテーションに追加することを希望するとします。このシナリオでは、OLEフレームのサイズを設定し、OLEフレームエリアに参加する行および列のサイズをスケールします。その後、変更を保存するためにワークブックをストリームに保存し、それをOLEフレームに追加するためのバイト配列に変換します。PowerPointのOLEフレームに対して赤い**埋め込みオブジェクト**メッセージを回避するために、ワークブック内の行と列の所望の部分の画像を取得し、それをOLEフレーム画像として設定します。

```csharp
WorkbookDesigner workbookDesigner = new WorkbookDesigner();
workbookDesigner.Workbook = new Workbook("AsposeTest.xls");

Presentation presentation = new Presentation("AsposeTest.ppt");

Slide slide = (Slide)presentation.Slides[0];

AddOleFrame(slide, 0, 15, 0, 3, 0, 300, 1100, 0, 0, presentation, workbookDesigner, true, 0, 0);

String fileName = "AsposeTest_Ole.ppt";
presentation.Save(fileName, Aspose.Slides.Export.SaveFormat.Ppt);
```

```csharp
private static void SetOleAccordingToCustomHeighWidth(Workbook workbook, Int32 startRow,
    Int32 endRow, Int32 startCol, Int32 endCol, double slideWidth, double slideHeight, Int32 dataSheetIdx)
{
    Worksheet work = workbook.Worksheets[dataSheetIdx];

    double actualHeight = 0, actualWidth = 0;

    double newHeight = slideHeight;
    double newWidth = slideWidth;
    double tem = 0;
    double newTem = 0;

    for (int i = startRow; i <= endRow; i++)
        actualHeight += work.Cells.GetRowHeightInch(i);

    for (int i = startCol; i <= endCol; i++)
        actualWidth += work.Cells.GetColumnWidthInch(i);
    ///新しい行と列の高さを設定

    for (int i = startRow; i <= endRow; i++)
    {
        tem = work.Cells.GetRowHeightInch(i);
        newTem = (tem / actualHeight) * newHeight;
        work.Cells.SetRowHeightInch(i, newTem);
    }

    for (int i = startCol; i <= endCol; i++)
    {
        tem = work.Cells.GetColumnWidthInch(i);
        newTem = (tem / actualWidth) * newWidth;
        work.Cells.SetColumnWidthInch(i, newTem);

    }
}

```

```csharp
private static void AddOleFrame(Slide slide, Int32 startRow, Int32 endRow, Int32 startCol, Int32 endCol,
    Int32 dataSheetIdx, Int32 x, Int32 y, Double OleWidth, Double OleHeight,
    Presentation presentation, WorkbookDesigner workbookDesigner,
    Boolean onePagePerSheet, Int32 outputWidth, Int32 outputHeight)
{
    String tempFileName = Path.GetTempFileName();
    if (startRow == 0)
    {
        startRow++;
        endRow++;
    }

    //ワークブックのアクティブシートインデックスを設定
    workbookDesigner.Workbook.Worksheets.ActiveSheetIndex = dataSheetIdx;

    //ワークブックと選択したワークシートを取得  
    Workbook workbook = workbookDesigner.Workbook;
    Worksheet work = workbook.Worksheets[dataSheetIdx];

    //選択した行と列に応じてOLEサイズを設定
    Size SlideOleSize = SetOleAccordingToSelectedRowsCloumns(workbook, startRow, endRow, startCol, endCol, dataSheetIdx);
    OleWidth = SlideOleSize.Width;
    OleHeight = SlideOleSize.Height;

    //ワークブックのOLEサイズを設定
    workbook.Worksheets.SetOleSize(startRow, endRow, startCol, endCol);

    workbook.Worksheets[0].IsGridlinesVisible = false;

    //ワークシート画像を取得するための画像オプションを設定
    ImageOrPrintOptions imageOrPrintOptions = new ImageOrPrintOptions();
    imageOrPrintOptions.ImageFormat = System.Drawing.Imaging.ImageFormat.Bmp;
    imageOrPrintOptions.OnePagePerSheet = onePagePerSheet;

    SheetRender render = new SheetRender(workbookDesigner.Workbook.Worksheets[dataSheetIdx], imageOrPrintOptions);
    String ext = ".bmp";
    render.ToImage(0, tempFileName + ext);
    Image image = ScaleImage(Image.FromFile(tempFileName + ext), outputWidth, outputHeight);
    String newTempFileName = tempFileName.Replace(".tmp", ".tmp1") + ext;
    image.Save(newTempFileName, System.Drawing.Imaging.ImageFormat.Bmp);

    //スライドの画像コレクションに画像を追加
    var ppImage = presentation.Images.AddImage(File.ReadAllBytes(newTempFileName));

    //ワークブックをストリームに保存し、バイト配列にコピー
    Stream mstream = workbook.SaveToStream();
    byte[] chartOleData = new byte[mstream.Length];
    mstream.Position = 0;
    mstream.Read(chartOleData, 0, chartOleData.Length);

    //OLEオブジェクトフレームを追加
    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(chartOleData, "xls");
    IOleObjectFrame oleObjectFrame = slide.Shapes.AddOleObjectFrame(x, y, Convert.ToInt32(OleWidth),
        Convert.ToInt32(OleHeight), dataInfo);

    //OLEフレームの代替テキストプロパティを設定    
    oleObjectFrame.SubstitutePictureFormat.Picture.Image = ppImage;
    oleObjectFrame.AlternativeText = "image" + ppImage;
}
```

```csharp
private static Image ScaleImage(Image image, Int32 outputWidth, Int32 outputHeight)
{
    if (outputWidth == 0 && outputHeight == 0)
    {
        outputWidth = image.Width;
        outputHeight = image.Height;
    }
    Bitmap outputImage = new Bitmap(outputWidth, outputHeight, image.PixelFormat);
    outputImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);
    Graphics graphics = Graphics.FromImage(outputImage);
    graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
    System.Drawing.Rectangle srcDestRect = new System.Drawing.Rectangle(0, 0, outputWidth, outputHeight);
    graphics.DrawImage(image, srcDestRect, srcDestRect, GraphicsUnit.Pixel);
    graphics.Dispose();

    return outputImage;
}
```


## **結論**


{{% alert color="primary" %}}  ワークシートのリサイズ問題を修正するための2つのアプローチがあります。適切なアプローチの選択は、要件とユースケースに依存します。テンプレートから作成されたプレゼンテーションでも、最初から作成されたプレゼンテーションでも、両方のアプローチは同じように機能します。また、解決策においてOLEオブジェクトフレームのサイズに制限はありません。 {{% /alert %}} 
## **関連セクション**
[ExcelチャートをOLEオブジェクトとしてプレゼンテーションに作成および埋め込む](/slides/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[OLEオブジェクトを自動的に更新する](/slides/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)