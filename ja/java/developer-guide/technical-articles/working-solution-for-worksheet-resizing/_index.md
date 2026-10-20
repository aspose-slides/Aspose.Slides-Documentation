---
title: ワークシートのリサイズに対する実装ソリューション
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
description: "プレゼンテーションでの Excel ワークシート OLE リサイズを修正します：オブジェクトフレームを一貫させる方法は 2 つ、フレームをスケールするかシートをスケールするかです。PPT と PPTX 形式に対応しています。"
---
{{% alert color="info" title="Note" %}}
Excel ワークシートを OLE オブジェクトとして PowerPoint プレゼンテーションに埋め込む際、Aspose コンポーネントを使用すると、最初にアクティブ化した後に予期せずサイズが変わることがあります。この動作により、OLE オブジェクトのアクティブ化前後で目立った視覚的違いが生じます。本記事ではこの問題を説明し、対処方法を 2 つ紹介します。
{{% /alert %}}

## **背景**

記事 [OLE の管理](/slides/ja/java/manage-ole/) では、Aspose.Slides for Java を使用して PowerPoint プレゼンテーションに OLE フレームを追加する方法を説明しました。[オブジェクト プレビューの問題](/slides/ja/java/object-preview-issue-when-adding-oleobjectframe/) に対処するため、選択したワークシート領域の画像を OLE オブジェクトフレームに割り当てました。出力されたプレゼンテーションでは、ワークシート画像を表示する OLE オブジェクトフレームをダブルクリックすると、Excel ワークブックがアクティブ化されます。エンドユーザーは実際の Excel ワークブックに任意の変更を加え、アクティブ化された Excel ワークブックの外側をクリックしてスライドに戻ります。ユーザーがスライドに戻ると OLE オブジェクトフレームのサイズが変わります。リサイズの係数は OLE オブジェクトフレームと埋め込み Excel ワークブックのサイズに応じて変わります。

## **リサイズの原因**

Excel ワークブックは独自のウィンドウサイズを持っているため、最初のアクティブ化時に元のサイズを保持しようとします。一方、OLE オブジェクトフレームは独自のサイズを持ちます。Microsoft によれば、Excel ワークブックがアクティブ化されると、Excel と PowerPoint がサイズを調整し、埋め込みプロセスの一部として正しい比率を維持するよう交渉します。リサイズは、Excel のウィンドウサイズと OLE オブジェクトフレームのサイズおよび位置の差に基づいて発生します。

## **実装ソリューション**

リサイズ効果を回避するために、2 つの解決策があります。

- PowerPoint プレゼンテーション内の OLE フレームを、選択した行と列の総高さと幅に合わせてスケーリングする。
- OLE フレームのサイズを固定したまま、選択した行と列をそのサイズに合わせてスケーリングする。

### **OLE フレームサイズのスケーリング**

このアプローチは、埋め込み Excel ワークシートの選択された行と列の総高さと幅に合わせて OLE フレームのサイズを設定します。

この例では、既存の Excel ワークブックを読み込み、ゼロベースのインデックスを使用して最初のワークシートの最初の 10 行と 13 列を選択します。[WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) は表示範囲を定義します。プレビューは 96 DPI でレンダリングされ、ピクセル寸法は 1 インチあたり 72 ポイントを使用してポイントに変換されます。[IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) は、変更されたワークブックをその寸法のフレームに埋め込みます。プレビューは [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) を通じて割り当てられ、保存されたプレゼンテーションの「EMBEDDED OLE OBJECT」プレースホルダーを置き換えます。

```java
import com.aspose.slides.*;
import java.awt.Image;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;
import javax.imageio.ImageIO;

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

// OLE 画像の幅と高さ（ポイント単位）を取得します。
Image image = ImageIO.read(imageStream);
float imageWidth = image.getWidth(null) * 72f / imageResolution;
float imageHeight = image.getHeight(null) * 72f / imageResolution;

// 変更されたワークブックを使用する必要があります。
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// OLE 画像をプレゼンテーションのリソースに追加します。
imageStream.reset();
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// OLE オブジェクトフレームを作成します。
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

プレビュー ヘルパーは、[PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) を選択した範囲に設定し、余白、ヘッダー、フッターを削除します。[ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/java/com.aspose.cells/imageorprintoptions/#setOnlyArea-boolean-) を有効にすると、[SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-) がその範囲を PNG 画像としてレンダリングします。ヘルパーは PNG 画像を含む新しい入力ストリームを返し、プレゼンテーションで使用できるよう先頭に位置付けます。

```java
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

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

このアプローチは、選択した行の高さと列の幅をスケーリングして、カスタム OLE フレームサイズに合わせます。

この例では、既存の Excel ワークブックを読み込み、ゼロベースのインデックスを使用して最初のワークシートの最初の 10 行と 13 列を選択します。[WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) は表示範囲を定義し、以下のヘルパーはその範囲を幅 400 ポイント、高さ 100 ポイントのフレームに合わせてスケーリングします。変更されたワークブックをストリームに保存した後、[IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) が指定サイズで埋め込みます。96 DPI でレンダリングされたプレビューは [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) を通じて割り当てられ、保存されたプレゼンテーションはデフォルトのプレースホルダーの代わりに選択されたセルを表示します。

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook("sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// PowerPoint でブックファイルが OLE オブジェクトとして使用される際の表示サイズを設定します。
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// セル範囲をフレームサイズに合わせてスケーリングします。
com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// 変更されたワークブックを使用する必要があります。
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// OLE 画像をプレゼンテーションのリソースに追加します。
IPPImage oleImage = presentation.getImages().addImage(imageStream);
imageStream.close();

// OLE オブジェクトフレームを作成します。
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

スケーリングヘルパーは、選択範囲の幅と高さの比率を別々に計算し、列の相対幅と行の相対高さを保持します。計算された寸法をポイントからインチに変換し、[Cells.setColumnWidthInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setColumnWidthInch-int-double-) と [Cells.setRowHeightInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setRowHeightInch-int-double-) を使用して適用します。選択範囲は幅と高さがゼロであってはなりません。

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

このプレビューヘルパーは、[SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-) を使用してリサイズされた範囲をレンダリングします。[PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) をその範囲に限定し、余白、ヘッダー、フッターを削除し、先頭に位置付けられた PNG ストリームを返します。

```java
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

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
{{% alert color="info" title="Note" %}}
ワークシートのリサイズ問題を解決するには 2 つのアプローチがあります。要件や使用ケースに最適なアプローチを選択してください。テンプレートから作成したプレゼンテーションでも、ゼロから作成したプレゼンテーションでも、両方のアプローチは同じように機能します。また、このソリューションでは OLE オブジェクトフレームのサイズに制限はありません。
{{% /alert %}}

## **よくある質問**

**PowerPoint で最初にアクティブ化されたとき、埋め込み Excel ワークシートのサイズが変わるのはなぜですか？**

これは、Excel がアクティブ化時に元のウィンドウサイズを維持しようとする一方、PowerPoint の OLE オブジェクトフレームは独自のサイズを持っているために起こります。PowerPoint と Excel がサイズを交渉してアスペクト比を維持するため、リサイズが発生することがあります。

**このリサイズ問題を完全に防ぐことは可能ですか？**

はい。OLE フレームを Excel のセル範囲サイズに合わせてスケーリングするか、セル範囲を目的の OLE フレームサイズに合わせてスケーリングすることで、不要なリサイズを防止できます。

**どちらのスケーリング方法を使用すべきですか、OLE フレームのスケーリングですか、セル範囲のスケーリングですか？**

元の Excel の行と列のサイズを維持したい場合は **OLE フレームのスケーリング** を選択してください。プレゼンテーションで OLE フレームのサイズを固定したい場合は **セル範囲のスケーリング** を選択してください。

**プレゼンテーションがテンプレートベースの場合でも、これらの解決策は機能しますか？**

はい。テンプレートから作成したプレゼンテーションでも、ゼロから作成したプレゼンテーションでも、両方の解決策は機能します。

**これらの方法を使用する際、OLE フレームのサイズに制限はありますか？**

いいえ。スケールを適切に設定すれば、OLE オブジェクトフレームは任意のサイズにできます。

**PowerPoint の「EMBEDDED OLE OBJECT」プレースホルダー テキストを回避する方法はありますか？**

はい。対象の Excel セル範囲のスナップショットを取得し、それを OLE フレームのプレースホルダー画像として設定することで、デフォルトのプレースホルダーの代わりにカスタムプレビュー画像を表示できます。

## **関連記事**

[Excel グラフを作成し、OLE オブジェクトとしてプレゼンテーションに埋め込む](/slides/ja/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[MS PowerPoint アドインを使用して OLE オブジェクトを自動的に更新する](/slides/ja/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)