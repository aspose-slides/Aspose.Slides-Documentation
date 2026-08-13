---
title: ワークシートリサイズの実装ソリューション
type: docs
weight: 40
url: /ja/net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- プレビュー画像
- 画像リサイズ
- Excel
- ワークシート
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "プレゼンテーションでの Excel ワークシート OLE のリサイズを修正します：オブジェクトフレームを一貫させる2つの方法—フレームをスケールするかシートをスケールするか—PPT および PPTX 形式全体で。"
---
{{% alert color="info" %}}
Excel ワークシートを OLE オブジェクトとして PowerPoint プレゼンテーションに Aspose コンポーネントで埋め込むと、最初にアクティブ化した後に未定義のスケールにリサイズされることが確認されています。この動作により、OLE オブジェクトのアクティブ化前後でプレゼンテーションに目立つビジュアルの違いが生じます。本稿ではこの問題を詳細に調査し、解決策をご提示します。
{{% /alert %}}

## **背景**

記事 [Manage OLE](/slides/ja/net/manage-ole/) では、Aspose.Slides for .NET を使用して PowerPoint プレゼンテーションに OLE フレームを追加する方法を説明しました。 [object preview issue](/slides/ja/net/object-preview-issue-when-adding-oleobjectframe/) に対処するため、選択したワークシート領域の画像を OLE オブジェクトフレームに割り当てました。出力されたプレゼンテーションで、ワークシート画像を表示する OLE オブジェクトフレームをダブルクリックすると Excel ブックがアクティブ化されます。エンドユーザーは実際の Excel ブックを自由に編集でき、編集後に Excel ブックの外側をクリックするとスライドに戻ります。ユーザーがスライドに戻ると OLE オブジェクトフレームのサイズが変わります。リサイズ係数は OLE オブジェクトフレームのサイズと埋め込まれた Excel ブックのサイズによって異なります。

## **リサイズの原因**

Excel ブックは独自のウィンドウサイズを持っているため、最初のアクティブ化時に元のサイズを保持しようとします。一方、OLE オブジェクトフレームも独自のサイズがあります。Microsoft によると、Excel ブックがアクティブ化されると、Excel と PowerPoint がサイズを協議し、埋め込みプロセスの一部として正しい比率を保つようにします。リサイズは Excel ウィンドウサイズと OLE オブジェクトフレームのサイズ・位置の違いに基づいて発生します。

## **実装ソリューション**

リサイズ効果を回避するための 2 つの解決策があります。

- OLE フレームのサイズを PowerPoint プレゼンテーション内で、目的の行数と列数に合わせた高さと幅に合わせる。
- OLE フレームのサイズを固定し、対象となる行と列のサイズをスケーリングしてフレーム内に収める。

### **OLE フレームサイズのスケーリング**

このアプローチでは、埋め込まれた Excel ブックの OLE フレームサイズを、Excel ワークシート内の対象行と列の累積サイズに合わせて設定する方法を学びます。

テンプレート Excel シートがあり、それを OLE フレームとしてプレゼンテーションに追加したいとします。このシナリオでは、まずブック内の対象行の高さと列の幅を合計して OLE オブジェクトフレームのサイズを算出します。その後、その算出値を OLE フレームのサイズとして設定します。PowerPoint の OLE フレームで赤い「EMBEDDED OLE OBJECT」メッセージが表示されないように、ブック内の対象行と列の画像を取得し、OLE フレームの画像として設定します。

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// Set the displayed size when the workbook file is used as an OLE object in PowerPoint.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
var imageStream = CreateOleImage(cellRange, imageResolution);

// Get the width and height of the OLE image in points.
using var image = Image.FromStream(imageStream);
var imageWidth = image.Width * 72 / imageResolution;
var imageHeight = image.Height * 72 / imageResolution;

// We need to use the modified workbook.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// Add the OLE image to the presentation resources.
imageStream.Seek(0, SeekOrigin.Begin);
var oleImage = presentation.Images.AddImage(imageStream);

// Create the OLE object frame.
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

```cs
static MemoryStream CreateOleImage(Aspose.Cells.Range cellRange, int imageResolution)
{
    var pageSetup = cellRange.Worksheet.PageSetup;
    pageSetup.PrintArea = cellRange.Address;
    pageSetup.LeftMargin = 0;
    pageSetup.RightMargin = 0;
    pageSetup.TopMargin = 0;
    pageSetup.BottomMargin = 0;
    pageSetup.ClearHeaderFooter();

    var imageOptions = new Aspose.Cells.Rendering.ImageOrPrintOptions
    {
        ImageType = Aspose.Cells.Drawing.ImageType.Png,
        VerticalResolution = imageResolution,
        HorizontalResolution = imageResolution,
        OnePagePerSheet = true,
        OnlyArea = true
    };

    var sheetRender = new Aspose.Cells.Rendering.SheetRender(cellRange.Worksheet, imageOptions);
    var imageStream = new MemoryStream();

    sheetRender.ToImage(0, imageStream);
    imageStream.Seek(0, SeekOrigin.Begin);

    return imageStream;
}
```

### **セル範囲サイズのスケーリング**

このアプローチでは、対象行の高さと対象列の幅をカスタム OLE フレームサイズに合わせてスケーリングする方法を学びます。

テンプレート Excel シートがあり、それを OLE フレームとしてプレゼンテーションに追加したいとします。このシナリオでは、まず OLE フレームのサイズを設定し、フレーム領域に含まれる行と列のサイズをスケーリングします。その後、ブックをストリームに保存して変更を反映し、バイト配列に変換して OLE フレームに追加します。PowerPoint の OLE フレームで赤い「EMBEDDED OLE OBJECT」メッセージが表示されないように、ブック内の対象行と列の画像を取得し、OLE フレームの画像として設定します。

```cs
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// PowerPoint でワークブック ファイルが OLE オブジェクトとして使用されるときの表示サイズを設定します。
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

// セル範囲をフレームサイズに合わせてスケールします。
var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

var imageStream = CreateOleImage(cellRange, imageResolution);

// 変更されたワークブックを使用する必要があります。
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// OLE 画像をプレゼンテーションのリソースに追加します。
var oleImage = presentation.Images.AddImage(imageStream);

// Create the OLE object frame.
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

```cs
/// <param name="width">セル範囲の期待される幅（ポイント単位）。</param>
/// <param name="height">セル範囲の期待される高さ（ポイント単位）。</param>
static void ScaleCellRange(Aspose.Cells.Range cellRange, float width, float height)
{
    var rangeWidth = cellRange.Width;
    var rangeHeight = cellRange.Height;

    for (int i = 0; i < cellRange.ColumnCount; i++)
    {
        var columnIndex = cellRange.FirstColumn + i;
        var columnWidth = cellRange.Worksheet.Cells.GetColumnWidth(columnIndex, false, Aspose.Cells.CellsUnitType.Point);

        var newColumnWidth = columnWidth * width / rangeWidth;
        var widthInInches = newColumnWidth / 72;
        cellRange.Worksheet.Cells.SetColumnWidthInch(columnIndex, widthInInches);
    }

    for (int i = 0; i < cellRange.RowCount; i++)
    {
        var rowIndex = cellRange.FirstRow + i;
        var rowHeight = cellRange.Worksheet.Cells.GetRowHeight(rowIndex, false, Aspose.Cells.CellsUnitType.Point);

        var newRowHeight = rowHeight * height / rangeHeight;
        var heightInInches = newRowHeight / 72;
        cellRange.Worksheet.Cells.SetRowHeightInch(rowIndex, heightInInches);
    }
}
```

```cs
static Stream CreateOleImage(Aspose.Cells.Range cellRange, int imageResolution)
{
    var pageSetup = cellRange.Worksheet.PageSetup;
    pageSetup.PrintArea = cellRange.Address;
    pageSetup.LeftMargin = 0;
    pageSetup.RightMargin = 0;
    pageSetup.TopMargin = 0;
    pageSetup.BottomMargin = 0;
    pageSetup.ClearHeaderFooter();

    var imageOptions = new Aspose.Cells.Rendering.ImageOrPrintOptions
    {
        ImageType = Aspose.Cells.Drawing.ImageType.Png,
        VerticalResolution = imageResolution,
        HorizontalResolution = imageResolution,
        OnePagePerSheet = true,
        OnlyArea = true
    };

    var sheetRender = new Aspose.Cells.Rendering.SheetRender(cellRange.Worksheet, imageOptions);
    var imageStream = new MemoryStream();

    sheetRender.ToImage(0, imageStream);
    imageStream.Seek(0, SeekOrigin.Begin);

    return imageStream;
}
```

## **結論**

{{% alert color="info" %}}
ワークシートのリサイズ問題を解決する方法は 2 つあります。適切なアプローチの選択は、具体的な要件と使用ケースに依存します。どちらの方法も、テンプレートから作成したプレゼンテーションでも、ゼロから作成したプレゼンテーションでも同様に機能します。また、このソリューションでは OLE オブジェクトフレームのサイズに制限はありません。
{{% /alert %}}

## **よくある質問**

### 最初にアクティブ化したときに埋め込まれた Excel ワークシートのサイズが変わるのはなぜですか？
Excel はアクティブ化時に元のウィンドウサイズを保持しようとし、PowerPoint の OLE オブジェクトフレームは独自の寸法を持っています。PowerPoint と Excel がサイズを協議し、アスペクト比を維持するためにリサイズが発生します。

### このリサイズ問題を完全に防ぐことはできますか？
はい。OLE フレームを Excel セル範囲サイズに合わせてスケーリングするか、セル範囲を目的の OLE フレームサイズに合わせてスケーリングすれば、不要なリサイズを防げます。

### どちらのスケーリング方法を使うべきですか、OLE フレームのスケーリングですか、セル範囲のスケーリングですか？
元の Excel 行と列のサイズを維持したい場合は **OLE フレームのスケーリング** を選択し、プレゼンテーション内で固定サイズの OLE フレームが必要な場合は **セル範囲のスケーリング** を選択してください。

### プレゼンテーションがテンプレートベースでもこれらの解決策は機能しますか？
はい。どちらの解決策もテンプレートから作成したプレゼンテーションおよびゼロから作成したプレゼンテーションの両方で機能します。

### この方法を使用した場合、OLE フレームのサイズに制限はありますか？
いいえ。適切にスケールを設定すれば、OLE オブジェクトフレームは任意のサイズに設定できます。

### PowerPoint の「EMBEDDED OLE OBJECT」プレースホルダー文字列を回避する方法はありますか？
はい。対象の Excel セル範囲のスナップショットを取得し、OLE フレームのプレースホルダー画像として設定すれば、デフォルトのプレースホルダーの代わりにカスタムプレビュー画像を表示できます。

## **関連記事**

[Creating an Excel Chart and Embedding It in a Presentation as an OLE Object](/slides/ja/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Updating OLE Objects Automatically Using an MS PowerPoint Add-In](/slides/ja/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)