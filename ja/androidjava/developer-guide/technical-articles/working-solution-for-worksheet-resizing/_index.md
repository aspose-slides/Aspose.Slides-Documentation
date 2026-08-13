---
title: ワークシートリサイズの実用的解決策
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
description: "プレゼンテーションでの Excel ワークシート OLE リサイズを修正します：オブジェクトフレームを一定に保つための 2 つの方法—フレームをスケーリングするかシートをスケーリングするか—を PPT と PPTX 形式で提供します。"
---
{{% alert color="info" %}}
Excel ワークシートが OLE オブジェクトとして PowerPoint プレゼンテーションに埋め込まれ、Aspose コンポーネントを介して最初にアクティブ化された後、未特定のスケールにリサイズされることが確認されています。この動作により、OLE オブジェクトのアクティブ化前後でプレゼンテーションの見た目に顕著な違いが生じます。本記事ではこの問題を詳細に調査し、解決策を提示しています。
{{% /alert %}}

## **背景**

[Manage OLE](/slides/ja/androidjava/manage-ole/) 記事では、Aspose.Slides for Android via Java を使用して PowerPoint プレゼンテーションに OLE フレームを追加する方法を説明しました。[object preview issue](/slides/ja/androidjava/object-preview-issue-when-adding-oleobjectframe/) に対処するため、選択したワークシート領域の画像を OLE オブジェクトフレームに割り当てました。出力されたプレゼンテーションで、ワークシート画像を表示している OLE オブジェクトフレームをダブルクリックすると Excel ブックがアクティブ化されます。エンドユーザーは実際の Excel ブックを自由に編集でき、編集後はアクティブ化された Excel ブックの外側をクリックしてスライドに戻ります。ユーザーがスライドに戻ると OLE オブジェクトフレームのサイズが変わります。リサイズ率は OLE オブジェクトフレームと埋め込まれた Excel ブックのサイズによって変動します。

## **リサイズの原因**

Excel ブックは独自のウィンドウサイズを持っているため、最初にアクティブ化された際に元のサイズを保持しようとします。一方、OLE オブジェクトフレームは独自のサイズがあります。Microsoft によると、Excel ブックがアクティブ化されると、Excel と PowerPoint が埋め込みプロセスの一部として正しい比率を保つようサイズ交渉を行います。リサイズは Excel ウィンドウサイズと OLE オブジェクトフレームのサイズ・位置の差に基づいて発生します。

## **解決策**

リサイズ効果を回避するための 2 つの可能な解決策があります。

- PowerPoint プレゼンテーション内の OLE フレームサイズを、OLE フレーム内に配置したい行数と列数の高さ・幅に合わせてスケーリングする。
- OLE フレームサイズを固定し、対象の行と列のサイズをスケーリングしてフレーム内に収める。

### **OLE フレームサイズのスケーリング**

この方法では、埋め込まれた Excel ブックの OLE フレームサイズを、Excel ワークシート内の対象行と列の合計サイズに合わせて設定する方法を学びます。

テンプレートの Excel シートがあり、プレゼンテーションに OLE フレームとして追加したいとします。このシナリオでは、まずブック内の対象行の高さと対象列の幅の合計から OLE オブジェクトフレームのサイズを算出します。次に、算出した値を OLE フレームのサイズとして設定します。PowerPoint の OLE フレームに表示される赤い「EMBEDDED OLE OBJECT」メッセージを回避するため、ブック内の対象行と列の画像を取得し、OLE フレームのプレビュー画像として設定します。

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

// PowerPoint でブックファイルが OLE オブジェクトとして使用される場合の表示サイズを設定します。
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// OLE 画像の幅と高さをポイント単位で取得します。
Bitmap image = BitmapFactory.decodeStream(imageStream);
float imageWidth = image.getWidth() * 72f / imageResolution;
float imageHeight = image.getHeight() * 72f / imageResolution;

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

// OLE オブジェクトフレームを作成します。
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(oleStream.toByteArray(), "xlsx");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(false);
oleStream.close();

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

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

この方法では、カスタム OLE フレームサイズに合わせて対象行の高さと対象列の幅をスケーリングする方法を学びます。

テンプレートの Excel シートがあり、プレゼンテーションに OLE フレームとして追加したいとします。このシナリオでは、まず OLE フレームのサイズを設定し、フレーム領域に含まれる行と列のサイズをスケーリングしてフレームに合わせます。その後、変更を反映させるためにブックをストリームに保存し、バイト配列に変換して OLE フレームに追加します。PowerPoint の OLE フレームに表示される赤い「EMBEDDED OLE OBJECT」メッセージを回避するため、ブック内の対象行と列の画像を取得し、OLE フレームのプレビュー画像として設定します。

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

// PowerPoint でブックファイルが OLE オブジェクトとして使用される場合の表示サイズを設定します。
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// セル範囲をフレームサイズに合わせてスケーリングします。
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

// OLE オブジェクトフレームを作成します。
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
 * @param width     セル範囲の幅（ポイント単位）の期待値。
 * @param height    セル範囲の高さ（ポイント単位）の期待値。
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

{{% alert color="info" %}} 
ワークシートのリサイズ問題を解決する方法は 2 つあります。適切なアプローチの選択は、具体的な要件と使用ケースに依存します。どちらの方法も、テンプレートから作成したプレゼンテーションでも、ゼロから作成したプレゼンテーションでも同様に機能します。また、このソリューションでは OLE オブジェクトフレームのサイズに制限はありません。
{{% /alert %}}

## **FAQ**

### なぜ埋め込まれた Excel ワークシートは PowerPoint で最初にアクティブ化されたときにサイズが変わるのですか？

Excel はアクティブ化時に元のウィンドウサイズを維持しようとし、PowerPoint の OLE オブジェクトフレームは独自の寸法を持っているためです。PowerPoint と Excel がサイズ交渉を行い、アスペクト比を保つためにリサイズが発生します。

### このリサイズ問題を完全に防ぐことはできますか？

はい。OLE フレームを Excel のセル範囲サイズに合わせてスケーリングするか、セル範囲を目的の OLE フレームサイズに合わせてスケーリングすることで、不要なリサイズを防止できます。

### どのスケーリング手法を使用すべきですか、OLE フレームのスケーリングですかセル範囲のスケーリングですか？

元の Excel の行・列サイズを保持したい場合は **OLE フレームのスケーリング** を選択し、プレゼンテーション内で OLE フレームのサイズを固定したい場合は **セル範囲のスケーリング** を選択してください。

### テンプレートから作成したプレゼンテーションでもこれらの解決策は機能しますか？

はい。両方の解決策はテンプレートから作成したプレゼンテーションでも、ゼロから作成したプレゼンテーションでも同様に機能します。

### これらの方法を使用する際、OLE フレームのサイズに制限はありますか？

いいえ。スケールを適切に設定すれば、OLE オブジェクトフレームのサイズに制限はありません。

### PowerPoint の「EMBEDDED OLE OBJECT」プレースホルダー文字列を回避する方法はありますか？

はい。対象の Excel セル範囲のスナップショットを取得し、それを OLE フレームのプレースホルダー画像として設定すれば、デフォルトのプレースホルダー文字列の代わりにカスタムプレビュー画像を表示できます。