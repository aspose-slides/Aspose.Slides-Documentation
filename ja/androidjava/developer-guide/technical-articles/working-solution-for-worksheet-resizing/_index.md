---
title: ワークシートのリサイズに関する実装済みソリューション
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
description: "プレゼンテーション内の Excel ワークシート OLE のリサイズを修正します。オブジェクトフレームを一貫させる方法は2つあります—フレームをスケールするかシートをスケールするか—PPT および PPTX 形式全体で。"
---
{{% alert color="info" title="Note" %}}

Aspose コンポーネントを使用して PowerPoint プレゼンテーションに OLE オブジェクトとして埋め込まれた Excel ワークシートは、最初にアクティブ化された後に予期せずサイズが変更されることがあります。この動作により、OLE オブジェクトのアクティブ化前後で目立つ視覚的違いが生じます。本記事ではこの問題を説明し、対処方法を 2 つ紹介します。

{{% /alert %}}

## **背景**

記事[OLE の管理](/slides/ja/androidjava/manage-ole/)では、Aspose.Slides for Android via Java を使用して PowerPoint プレゼンテーションに OLE フレームを追加する方法を説明しました。[オブジェクト プレビューの問題](/slides/ja/androidjava/object-preview-issue-when-adding-oleobjectframe/)に対処するため、選択したワークシート領域の画像を OLE オブジェクトフレームに割り当てました。出力されたプレゼンテーションで、ワークシート画像を表示する OLE オブジェクトフレームをダブルクリックすると、Excel ブックがアクティブ化されます。エンドユーザーは実際の Excel ブックに任意の変更を加え、アクティブ化された Excel ブックの外側をクリックしてスライドに戻ることができます。ユーザーがスライドに戻ると OLE オブジェクトフレームのサイズが変わります。リサイズ係数は OLE オブジェクトフレームと埋め込まれた Excel ブックのサイズに応じて変わります。

## **サイズ変更の原因**

Excel ブックには独自のウィンドウサイズがあるため、最初のアクティブ化時に元のサイズを保持しようとします。一方、OLE オブジェクトフレームにも独自のサイズがあります。Microsoft によると、Excel ブックがアクティブ化されると、Excel と PowerPoint がサイズを協議して、埋め込みプロセスの一部として正しい比率を保つようにします。リサイズは Excel ウィンドウサイズと OLE オブジェクトフレームのサイズおよび位置の差異に基づいて発生します。

## **実装された解決策**

リサイズ効果を回避するための 2 つの可能な解決策があります。

- PowerPoint プレゼンテーション内の OLE フレームを、選択した行と列の合計高さと幅に合わせてスケールする。
- OLE フレームのサイズを一定に保ち、選択した行と列をフレーム内に収まるようにスケールする。

### **OLE フレーム サイズのスケール**

このアプローチは、埋め込まれた Excel ワークシート内の選択した行と列の合計高さと幅に合わせて OLE フレームサイズを設定します。

例では既存の Excel ブックを読み込み、ゼロベースのインデックスを使用して最初のワークシートの最初の 10 行と 13 列を選択します。[WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) が表示範囲を定義します。プレビューは 96 DPI でレンダリングされ、ピクセル寸法は 1 インチあたり 72 ポイントでポイントに変換されます。[IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) が変更されたブックをその寸法のフレームに埋め込みます。プレビューは [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) を介して割り当てられ、保存されたプレゼンテーションの「EMBEDDED OLE OBJECT」プレースホルダーを置き換えます。

```java
import com.aspose.slides.*;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

com.aspose.cells.Workbook workbook = new com.aspose.cells.Workbook( "sample.xlsx");
com.aspose.cells.Worksheet worksheet = workbook.getWorksheets().get(worksheetIndex);

// ワークブックファイルが PowerPoint の OLE オブジェクトとして使用されるときの表示サイズを設定します。
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// OLE 画像の幅と高さをポイント単位で取得します。
Bitmap image = BitmapFactory.decodeStream(imageStream);
float imageWidth = image.getWidth() * 72f / imageResolution;
float imageHeight = image.getHeight() * 72f / imageResolution;

// 修正されたワークブックを使用する必要があります。
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

プレビュー ヘルパーは [PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) を選択範囲に設定し、余白、ヘッダー、フッターを除去します。[ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/java/com.aspose.cells/imageorprintoptions/#setOnlyArea-boolean-) を有効にすると、[SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-) が範囲を PNG 画像としてレンダリングします。ヘルパーは PNG 画像を含む新しい入力ストリームを返し、プレゼンテーションで使用できるように先頭に位置付けます。

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

### **セル範囲サイズのスケール**

このアプローチは、選択した行の高さと列の幅をカスタム OLE フレームサイズに合わせてスケールします。

例では既存の Excel ブックを読み込み、ゼロベースのインデックスを使用して最初のワークシートの最初の 10 行と 13 列を選択します。[WorksheetCollection.setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) が表示範囲を定義し、下記のヘルパーがその範囲を幅 400 ポイント、高さ 100 ポイントのフレームに収まるようにスケールします。変更されたブックをストリームに保存した後、[IShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) が指定サイズで埋め込みます。96 DPI でレンダリングされたプレビューは [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) を介して割り当てられ、保存されたプレゼンテーションはデフォルトのプレースホルダーの代わりに選択したセルを表示します。

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

// ワークブック ファイルが PowerPoint の OLE オブジェクトとして使用される際の表示サイズを設定します。
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// セル範囲をフレームサイズに合わせてスケールします。
com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// 修正されたワークブックを使用する必要があります。
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

スケーリング ヘルパーは選択範囲の幅と高さの比率を個別に計算し、列の相対幅と行の相対高さを維持します。計算された寸法はポイントからインチに変換され、[Cells.setColumnWidthInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setColumnWidthInch-int-double-) と [Cells.setRowHeightInch](https://reference.aspose.com/cells/java/com.aspose.cells/cells/#setRowHeightInch-int-double-) で適用されます。選択範囲は幅と高さがゼロでない必要があります。

```java
/**
 * @param width     セル範囲の期待される幅（ポイント単位）。
 * @param height    セル範囲の期待される高さ（ポイント単位）。
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

このプレビュー ヘルパーは [SheetRender.toImage](https://reference.aspose.com/cells/java/com.aspose.cells/sheetrender/#toImage-int-java.io.OutputStream-) を使用してリサイズされた範囲をレンダリングします。[PageSetup.setPrintArea](https://reference.aspose.com/cells/java/com.aspose.cells/pagesetup/#setPrintArea-java.lang.String-) をその範囲に限定し、余白、ヘッダー、フッターを除去し、先頭に位置付けられた PNG ストリームを返します。

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

ワークシートのリサイズ問題を解決するには 2 つのアプローチがあります。要件とユースケースに最適なアプローチを選択してください。両方のアプローチは、テンプレートから作成したプレゼンテーションでも、ゼロから作成したプレゼンテーションでも同じように機能します。また、このソリューションでは OLE オブジェクトフレームのサイズに制限はありません。

{{% /alert %}}

## **FAQ**

**PowerPoint で最初にアクティブ化された埋め込み Excel ワークシートのサイズが変わるのはなぜですか？**

Excel はアクティブ化時に元のウィンドウサイズを保持しようとし、PowerPoint の OLE オブジェクトフレームは独自の寸法を持っているためです。PowerPoint と Excel がサイズを協議してアスペクト比を保つため、リサイズが発生します。

**このリサイズ問題を完全に防ぐことは可能ですか？**

はい。OLE フレームを Excel セル範囲のサイズに合わせてスケールするか、セル範囲を目的の OLE フレームサイズに合わせてスケールすることで、不要なリサイズを防止できます。

**どちらのスケーリング手法を使用すべきですか、OLE フレームのスケーリングですかセル範囲のスケーリングですか？**

元の Excel 行と列のサイズを維持したい場合は **OLE フレームのスケーリング** を選択してください。プレゼンテーション内の OLE フレームを固定サイズにしたい場合は **セル範囲のスケーリング** を選択してください。

**テンプレートを基にしたプレゼンテーションでもこれらの解決策は機能しますか？**

はい。両方の解決策はテンプレートから作成したプレゼンテーションでも、ゼロから作成したプレゼンテーションでも機能します。

**これらの方法を使用する際に OLE フレームのサイズに制限はありますか？**

いいえ。適切にスケールを設定すれば、OLE オブジェクトフレームは任意のサイズにできます。

**PowerPoint の「EMBEDDED OLE OBJECT」プレースホルダー文字列を回避する方法はありますか？**

はい。対象の Excel セル範囲のスナップショットを取得し、それを OLE フレームのプレースホルダー画像として設定することで、デフォルトのプレースホルダーの代わりにカスタムプレビュー画像を表示できます。

## **関連記事**

[Excel グラフを作成して OLE オブジェクトとしてプレゼンテーションに埋め込む](/slides/ja/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[MS PowerPoint アドインを使用した OLE オブジェクトの自動更新](/slides/ja/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)