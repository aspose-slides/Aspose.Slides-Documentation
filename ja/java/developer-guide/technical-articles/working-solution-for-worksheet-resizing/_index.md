---
title: ワークシートリサイズの実装ソリューション
type: docs
weight: 20
url: /ja/java/working-solution-for-worksheet-resizing/
keywords:
  - OLE
  - プレビュー画像
  - 画像リサイズ
  - Excel
  - ワークシート
  - PowerPoint
  - プレゼンテーション
  - Java
  - Aspose.Slides
description: "プレゼンテーションでの Excel ワークシート OLE リサイズを修正します：オブジェクトフレームの一貫性を保つ方法は2つ—フレームをスケーリングするかシートをスケーリングするか—PPT と PPTX フォーマット全体で。"
---

{{% alert color="primary" %}}
Aspose コンポーネントを使用して PowerPoint プレゼンテーションに OLE オブジェクトとして埋め込まれた Excel ワークシートは、最初にアクティブ化された後、未定義のスケールにリサイズされることが確認されています。この動作により、OLE オブジェクトのアクティブ化前後でプレゼンテーションに目立つ視覚的な違いが生じます。本記事では、この問題を詳細に調査し、解決策を提供しています。
{{% /alert %}}

## **背景**

この記事[OLE の管理](/slides/ja/java/manage-ole/)では、Aspose.Slides for Java を使用して PowerPoint プレゼンテーションに OLE フレームを追加する方法を説明しました。[オブジェクト プレビューの問題](/slides/ja/java/object-preview-issue-when-adding-oleobjectframe/)に対処するため、選択したワークシート領域の画像を OLE オブジェクトフレームに割り当てました。出力されたプレゼンテーションで、ワークシート画像を表示する OLE オブジェクトフレームをダブルクリックすると Excel ブックがアクティブ化されます。エンドユーザーは実際の Excel ブックを任意に変更でき、アクティブ化された Excel ブックの外側をクリックするとスライドに戻ります。ユーザーがスライドに戻ると OLE オブジェクトフレームのサイズが変わります。リサイズ率は OLE オブジェクトフレームのサイズと埋め込まれた Excel ブックのサイズに応じて変わります。

## **リサイズの原因**

Excel ブックは独自のウィンドウサイズを持っているため、最初にアクティブ化された際に元のサイズを保持しようとします。一方、OLE オブジェクトフレームは独自のサイズを持ちます。Microsoft の説明によると、Excel ブックがアクティブ化されると、Excel と PowerPoint がサイズを協議し、埋め込みプロセスの一環として正しい比率を維持します。リサイズは Excel のウィンドウサイズと OLE オブジェクトフレームのサイズおよび位置の差に基づいて発生します。

## **実装ソリューション**

リサイズ効果を回避するための2つの解決策があります。

- PowerPoint プレゼンテーションで OLE フレームのサイズを、OLE フレーム内の目的の行数と列数の高さと幅に合わせてスケーリングする。
- OLE フレームのサイズを固定し、対象の行と列のサイズをスケーリングして選択した OLE フレームサイズに収める。

### **OLE フレームサイズのスケーリング**

このアプローチでは、埋め込まれた Excel ブックの OLE フレームサイズを、Excel ワークシート内の対象行と列の合計サイズに合わせて設定する方法を学びます。

テンプレートの Excel シートがあり、それを OLE フレームとしてプレゼンテーションに追加したいとします。このシナリオでは、OLE オブジェクトフレームのサイズは、ブック内の対象行と列の合計行高さと列幅に基づいてまず計算されます。その後、計算された値で OLE フレームのサイズを設定します。PowerPoint で OLE フレームの赤い「EMBEDDED OLE OBJECT」メッセージを回避するため、ブック内の対象行と列の希望部分の画像を取得し、OLE フレームの画像として設定します。
```java
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook( "sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// ワークブックファイルが PowerPoint の OLE オブジェクトとして使用されるときの表示サイズを設定する。
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// OLE 画像の幅と高さをポイント単位で取得する。
Image image = ImageIO.read(imageStream);
float imageWidth = image.getWidth(null) * 72f / imageResolution;
float imageHeight = image.getHeight(null) * 72f / imageResolution;

// 修正されたワークブックを使用する必要があります。
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// OLE 画像をプレゼンテーションのリソースに追加する。
imageStream.reset();
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// OLE オブジェクトフレームを作成する。
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


### **セル範囲サイズのスケーリング**

このアプローチでは、対象行の高さと対象列の幅をスケーリングして、カスタム OLE フレームサイズに合わせる方法を学びます。

テンプレートの Excel シートがあり、それを OLE フレームとしてプレゼンテーションに追加したいとします。このシナリオでは、OLE フレームのサイズを設定し、OLE フレーム領域に含まれる行と列のサイズをスケーリングします。変更を適用するためにブックをストリームに保存し、OLE フレームに追加するためにバイト配列に変換します。PowerPoint で OLE フレームの赤い「EMBEDDED OLE OBJECT」メッセージを回避するため、ブック内の対象行と列の希望部分の画像を取得し、OLE フレームの画像として設定します。
```java
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook("sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// ワークブック ファイルが PowerPoint の OLE オブジェクトとして使用されるときの表示サイズを設定する。
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// セル範囲をフレームサイズに合わせてスケーリングする。
com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// 修正されたワークブックを使用する必要があります。
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// OLE 画像をプレゼンテーションのリソースに追加する。
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// OLE オブジェクトフレームを作成する。
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
ワークシートのリサイズ問題を解決するためのアプローチは2つあります。適切なアプローチの選択は、具体的な要件や使用ケースに依存します。両方のアプローチは、テンプレートから作成したプレゼンテーションでも、ゼロから作成したプレゼンテーションでも同様に機能します。さらに、このソリューションでは OLE オブジェクトフレームのサイズに制限はありません。
{{% /alert %}}

## **FAQ**

**PowerPoint で最初にアクティブ化されたときに、埋め込まれた Excel ワークシートのサイズが変わるのはなぜですか？**

これは、Excel がアクティブ化時に元のウィンドウサイズを維持しようとし、PowerPoint の OLE オブジェクトフレームには独自の寸法があるためです。PowerPoint と Excel がサイズを協議してアスペクト比を維持するため、リサイズが発生します。

**このリサイズ問題を完全に防ぐことは可能ですか？**

はい。OLE フレームを Excel のセル範囲サイズに合わせてスケーリングするか、セル範囲を目的の OLE フレームサイズに合わせてスケーリングすれば、不要なリサイズを防げます。

**スケーリング方法は OLE フレームのスケーリングとセル範囲のスケーリング、どちらを使用すべきですか？**

元の Excel 行と列のサイズを維持したい場合は **OLE フレームのスケーリング** を選択してください。プレゼンテーションで OLE フレームのサイズを固定したい場合は **セル範囲のスケーリング** を選択してください。

**プレゼンテーションがテンプレートベースの場合でもこれらのソリューションは機能しますか？**

はい。両方のソリューションはテンプレートから作成したプレゼンテーションでも、ゼロから作成したプレゼンテーションでも機能します。

**これらの方法を使用する際、OLE フレームのサイズに制限はありますか？**

いいえ。スケールを適切に設定すれば、OLE オブジェクトフレームは任意のサイズにできます。

**PowerPoint の「EMBEDDED OLE OBJECT」プレースホルダー文字列を回避する方法はありますか？**

はい。対象の Excel セル範囲のスナップショットを取得し、OLE フレームのプレースホルダー画像として設定すれば、デフォルトのプレースホルダーの代わりにカスタムプレビュー画像を表示できます。

## **Related Articles**

[Excel チャートを作成し OLE オブジェクトとしてプレゼンテーションに埋め込む](/slides/ja/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[MS PowerPoint アドインを使用して OLE オブジェクトを自動更新する](/slides/ja/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)