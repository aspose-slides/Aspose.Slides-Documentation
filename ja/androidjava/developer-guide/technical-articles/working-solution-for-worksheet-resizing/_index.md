---
title: ワークシートのリサイズに対する実装済みソリューション
type: docs
weight: 20
url: /ja/androidjava/working-solution-for-worksheet-resizing/
keywords:
- OLE
- プレビュー画像
- 画像リサイズ
- Excel
- ワークシート
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "プレゼンテーションでの Excel ワークシート OLE リサイズを修正します。オブジェクトフレームを一貫させる方法は2つあり、フレームをスケールするかシートをスケールすることで、PPT と PPTX 形式の両方で対応できます。"
---

{{% alert color="primary" %}}
Aspose コンポーネントを使用して PowerPoint プレゼンテーションに OLE オブジェクトとして埋め込まれた Excel ワークシートは、最初のアクティベーション後に不明なスケールにリサイズされることが確認されています。この動作により、OLE オブジェクトのアクティベーション前後でプレゼンテーションに目立つ視覚的差違が生じます。本稿ではこの問題を詳細に調査し、解決策を提供しています。
{{% /alert %}}

## **背景**

この記事[Manage OLE](/slides/ja/androidjava/manage-ole/)では、Aspose.Slides for Android via Java を使用して PowerPoint プレゼンテーションに OLE フレームを追加する方法を説明しました。[object preview issue](/slides/ja/androidjava/object-preview-issue-when-adding-oleobjectframe/) に対処するため、選択したワークシート領域の画像を OLE オブジェクトフレームに割り当てました。出力されたプレゼンテーションで、ワークシート画像を表示している OLE オブジェクトフレームをダブルクリックすると、Excel ブックがアクティブ化されます。エンドユーザーは実際の Excel ブックに任意の変更を加え、アクティブ化された Excel ブックの外側をクリックしてスライドに戻ることができます。ユーザーがスライドに戻ると OLE オブジェクトフレームのサイズが変わります。リサイズ率は OLE オブジェクトフレームと埋め込まれた Excel ブックのサイズに応じて変わります。

## **リサイズの原因**

Excel ブックには独自のウィンドウサイズがあるため、最初のアクティベーション時に元のサイズを保持しようとします。一方、OLE オブジェクトフレームにも独自のサイズがあります。Microsoft によれば、Excel ブックがアクティブになると、Excel と PowerPoint がサイズを協議し、埋め込みプロセスの一部として正しい比率を保つようにします。リサイズは Excel ウィンドウサイズと OLE オブジェクトフレームのサイズおよび位置の違いに基づいて発生します。

## **実装ソリューション**

リサイズ効果を回避するための2つの解決策があります。

- PowerPoint プレゼンテーション内の OLE フレームサイズをスケーリングし、OLE フレーム内の目的の行数と列数の高さと幅に合わせます。
- OLE フレームサイズを固定したまま、対象となる行と列のサイズをスケーリングして、選択した OLE フレームサイズ内に収めます。

### **OLE フレームサイズのスケーリング**

このアプローチでは、埋め込まれた Excel ワークブックの OLE フレームサイズを、Excel ワークシート内の対象行と列の合計サイズに合わせて設定する方法を学びます。

テンプレート Excel シートがあり、これを OLE フレームとしてプレゼンテーションに追加したいとします。このシナリオでは、まずブック内の対象行と列の合計行高さと列幅に基づいて OLE オブジェクトフレームのサイズを計算します。次に、その計算値で OLE フレームのサイズを設定します。PowerPoint の OLE フレームで赤い「EMBEDDED OLE OBJECT」メッセージが表示されないように、ブック内の対象行と列の必要な部分の画像を取得し、OLE フレーム画像として設定します。
```java
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook( "sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// PowerPoint でブックファイルが OLE オブジェクトとして使用される際の表示サイズを設定します。
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// OLE 画像の幅と高さをポイント単位で取得します。
Bitmap image = BitmapFactory.decodeStream(imageStream);
float imageWidth = image.getWidth(null) * 72f / imageResolution;
float imageHeight = image.getHeight(null) * 72f / imageResolution;

// 変更されたブックを使用する必要があります。
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// OLE 画像をプレゼンテーションのリソースに追加します。
imageStream.reset();
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// OLE オブジェクト フレームを作成します。
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

```java
static InputStream CreateOleImage(com.aspose.cells.Range cellRange, int imageResolution) throws Exception {
    com.aspose.cells.PageSetup pageSetup = cellRange.getWorksheet().getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    com.aspose.cells.ImageOrPrintOptions imageOptions = new com.aspose.cells.ImageOrPrintOptions();
    imageOptions.setImageType(com.aspose.cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    com.aspose.cells.SheetRender sheetRender = new com.aspose.cells.SheetRender(cellRange.getWorksheet(), imageOptions);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();

    sheetRender.toImage(0, imageStream);
    return new ByteArrayInputStream(imageStream.toByteArray());
}
```


### **セル範囲のスケーリング**

このアプローチでは、対象となる行の高さと列の幅をスケーリングして、カスタム OLE フレームサイズに合わせる方法を学びます。

テンプレート Excel シートがあり、これを OLE フレームとしてプレゼンテーションに追加したいとします。このシナリオでは、OLE フレームのサイズを設定し、OLE フレーム領域に含まれる行と列のサイズをスケーリングします。その後、変更を適用するためにブックをストリームに保存し、OLE フレームに追加するためにバイト配列に変換します。PowerPoint の OLE フレームで赤い「EMBEDDED OLE OBJECT」メッセージが表示されないように、ブック内の対象行と列の必要な部分の画像を取得し、OLE フレーム画像として設定します。
```java
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook("sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// PowerPoint でブック ファイルが OLE オブジェクトとして使用される際の表示サイズを設定します。
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// フレームサイズに合わせてセル範囲をスケーリングします。
com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// 変更されたブックを使用する必要があります。
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// OLE 画像をプレゼンテーションのリソースに追加します。
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// OLE オブジェクト フレームを作成します。
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

```java
/**
 * @param width     セル範囲の期待幅（ポイント単位）。
 * @param height    セル範囲の期待高さ（ポイント単位）。
 */
static void ScaleCellRange(com.aspose.cells.Range cellRange, float width, float height) {
    double rangeWidth = cellRange.getWidth();
    double rangeHeight = cellRange.getHeight();

    for (int i = 0; i < cellRange.getColumnCount(); i++) {
        int columnIndex = cellRange.getFirstColumn() + i;
        double columnWidth = cellRange.getWorksheet()
                .getCells()
                .getColumnWidth(columnIndex, false, com.aspose.cells.CellsUnitType.POINT);

        double newColumnWidth = columnWidth * width / rangeWidth;
        double widthInInches = newColumnWidth / 72.0;
        cellRange.getWorksheet()
                .getCells()
                .setColumnWidthInch(columnIndex, widthInInches);
    }

    for (int i = 0; i < cellRange.getRowCount(); i++) {
        int rowIndex = cellRange.getFirstRow() + i;
        double rowHeight = cellRange.getWorksheet()
                .getCells()
                .getRowHeight(rowIndex, false, com.aspose.cells.CellsUnitType.POINT);

        double newRowHeight = rowHeight * height / rangeHeight;
        double heightInInches = newRowHeight / 72.0;
        cellRange.getWorksheet()
                .getCells()
                .setRowHeightInch(rowIndex, heightInInches);
    }
}
```

```java
static InputStream CreateOleImage(com.aspose.cells.Range cellRange, int imageResolution) throws Exception {
    com.aspose.cells.PageSetup pageSetup = cellRange.getWorksheet().getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    com.aspose.cells.ImageOrPrintOptions imageOptions = new com.aspose.cells.ImageOrPrintOptions();
    imageOptions.setImageType(com.aspose.cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    com.aspose.cells.SheetRender sheetRender = new com.aspose.cells.SheetRender(cellRange.getWorksheet(), imageOptions);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();

    sheetRender.toImage(0, imageStream);
    return new ByteArrayInputStream(imageStream.toByteArray());
}
```


## **結論**

{{% alert color="primary" %}} 
ワークシートのリサイズ問題を解決するためには2つのアプローチがあります。適切なアプローチの選択は、具体的な要件と使用ケースに依存します。どちらのアプローチも、テンプレートから作成したプレゼンテーションでも、ゼロから作成したプレゼンテーションでも同様に機能します。さらに、このソリューションでは OLE オブジェクトフレームのサイズに制限はありません。
{{% /alert %}}

## **よくある質問**

**PowerPoint で最初にアクティブ化されたとき、埋め込まれた Excel ワークシートのサイズが変わるのはなぜですか？**

これは、Excel がアクティブ化時に元のウィンドウサイズを保持しようとし、PowerPoint の OLE オブジェクトフレームが独自のサイズを持つためです。PowerPoint と Excel がサイズを協議し、アスペクト比を維持するため、リサイズが発生することがあります。

**このリサイズ問題を完全に防ぐことは可能ですか？**

はい。OLE フレームを Excel のセル範囲サイズに合わせてスケーリングするか、セル範囲を目的の OLE フレームサイズに合わせてスケーリングすることで、不要なリサイズを防止できます。

**どちらのスケーリング方法を使用すべきですか、OLE フレームのスケーリングですか、セル範囲のスケーリングですか？**

元の Excel 行と列のサイズを維持したい場合は **OLE フレームのスケーリング** を選択してください。プレゼンテーションで OLE フレームを固定サイズにしたい場合は **セル範囲のスケーリング** を選択してください。

**プレゼンテーションがテンプレートベースの場合でもこれらの解決策は機能しますか？**

はい。テンプレートから作成したプレゼンテーションでも、ゼロから作成したプレゼンテーションでも、両方の解決策は機能します。

**これらの方法を使用する際に OLE フレームのサイズに制限はありますか？**

いいえ。スケールを適切に設定すれば、OLE オブジェクトフレームは任意のサイズにできます。

**PowerPoint で「EMBEDDED OLE OBJECT」プレースホルダーのテキストを回避する方法はありますか？**

はい。対象の Excel セル範囲のスナップショットを取得し、OLE フレームのプレースホルダー画像として設定することで、デフォルトのプレースホルダーの代わりにカスタムプレビュー画像を表示できます。