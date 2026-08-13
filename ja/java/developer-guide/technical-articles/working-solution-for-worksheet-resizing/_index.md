---
title: "ワークシートのリサイズに関する実用的な解決策"
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
description: "プレゼンテーション内の Excel ワークシート OLE リサイズを解消します。オブジェクトフレームを一定に保つための2つの方法—フレームをスケールするかシートをスケールするか—を PPT と PPTX 形式で提供します。"
---
{{% alert color="info" %}}

Aspose コンポーネントを使用して PowerPoint プレゼンテーションに OLE オブジェクトとして埋め込まれた Excel ワークシートが、最初のアクティベーション後に不明なスケールにリサイズされることが確認されています。この動作により、OLE オブジェクトのアクティベーション前後で見た目に大きな違いが生じます。本記事ではこの問題を詳細に調査し、解決策を提示します。

{{% /alert %}}

## **Background**

[Manage OLE](/slides/ja/java/manage-ole/) 記事では、Aspose.Slides for Java を使用して PowerPoint プレゼンテーションに OLE フレームを追加する方法を解説しました。[object preview issue](/slides/ja/java/object-preview-issue-when-adding-oleobjectframe/) に対処するため、選択したワークシート領域の画像を OLE オブジェクト フレームに割り当てました。出力されたプレゼンテーションで、ワークシート画像を表示している OLE オブジェクト フレームをダブルクリックすると、Excel ブックがアクティブ化されます。エンドユーザーは実際の Excel ブックで任意の変更を行い、アクティブ化された Excel ブックの外側をクリックしてスライドに戻ります。ユーザーがスライドに戻ると OLE オブジェクト フレームのサイズが変わります。リサイズ係数は OLE オブジェクト フレームのサイズと埋め込まれた Excel ブックのサイズに依存します。

## **Cause of Resizing**

Excel ブックは独自のウィンドウサイズを持っているため、最初のアクティベーション時に元のサイズを維持しようとします。一方、OLE オブジェクト フレームは独自のサイズを持っています。Microsoft によれば、Excel ブックがアクティブ化されると、Excel と PowerPoint がサイズを協議し、埋め込みプロセスの一部として正しい比率を保つようにします。リサイズは Excel ウィンドウサイズと OLE オブジェクト フレームのサイズ・位置の差異に基づいて発生します。

## **Working Solution**

リサイズ効果を回避するための 2 つの解決策があります。

- OLE フレームのサイズを PowerPoint プレゼンテーション内で、OLE フレーム内の行数と列数に対応する高さと幅に合わせてスケールする。
- OLE フレームのサイズを一定に保ち、対象となる行と列のサイズをスケールして選択した OLE フレームサイズに合わせる。

### **Scale the OLE Frame Size**

このアプローチでは、埋め込まれた Excel ブックの OLE フレームサイズを、Excel ワークシート内の対象行と列の合計サイズに合わせて設定する方法を学びます。

テンプレートの Excel シートがあり、これを OLE フレームとしてプレゼンテーションに追加したいとします。このシナリオでは、まずブック内の対象行の高さと列の幅を合計して OLE オブジェクト フレームのサイズを計算します。次に、その計算値で OLE フレームのサイズを設定します。PowerPoint で OLE フレームの赤い「EMBEDDED OLE OBJECT」メッセージを回避するため、ブック内の対象行・列の画像を取得し、OLE フレームの画像として設定します。

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

// PowerPoint でワークブック ファイルを OLE オブジェクトとして使用する際の表示サイズを設定します。
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

// プレゼンテーションのリソースに OLE 画像を追加します。
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

### **Scale the Cell Range Size**

このアプローチでは、対象となる行の高さと列の幅をカスタム OLE フレームサイズに合わせてスケールする方法を学びます。

テンプレートの Excel シートがあり、これを OLE フレームとしてプレゼンテーションに追加したいとします。このシナリオでは、まず OLE フレームのサイズを設定し、フレーム領域に含まれる行と列のサイズをスケールします。その後、ブックをストリームに保存して変更を適用し、バイト配列に変換して OLE フレームに追加します。PowerPoint の赤い「EMBEDDED OLE OBJECT」メッセージを回避するため、ブック内の対象行・列の画像を取得し、OLE フレームの画像として設定します。

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

// PowerPoint でワークブック ファイルを OLE オブジェクトとして使用する際の表示サイズを設定します。
int lastRow = startRow + rowCount - 1;
int lastColumn = startColumn + columnCount - 1;
workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

// フレームサイズに合わせてセル範囲をスケールします。
com.aspose.cells.Range cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

InputStream imageStream = CreateOleImage(cellRange, imageResolution);

// 変更されたワークブックを使用する必要があります。
ByteArrayOutputStream oleStream = new ByteArrayOutputStream();
workbook.save(oleStream, com.aspose.cells.SaveFormat.XLSX);
workbook.dispose();

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// プレゼンテーションのリソースに OLE 画像を追加します。
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
 * @param width     セル範囲の期待幅（ポイント単位）です。
 * @param height    セル範囲の期待高さ（ポイント単位）です。
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

## **Conclusion**

{{% alert color="info" %}} 

ワークシートのリサイズ問題を解決する方法は 2 つあります。適切な方法の選択は、具体的な要件やユースケースに依存します。どちらの方法も、テンプレートから作成したプレゼンテーションでも、ゼロから作成したプレゼンテーションでも同様に機能します。また、このソリューションでは OLE オブジェクト フレームのサイズに制限はありません。

{{% /alert %}}

## **FAQ**

### Why does an embedded Excel worksheet change size when first activated in PowerPoint?

Excel がアクティブ化時に元のウィンドウサイズを保持しようとする一方、PowerPoint の OLE オブジェクト フレームは独自の寸法を持つためです。PowerPoint と Excel がサイズを協議してアスペクト比を維持する過程でリサイズが発生します。

### Is it possible to prevent this resizing issue entirely?

はい。OLE フレームを Excel のセル範囲サイズに合わせてスケールするか、セル範囲を目的の OLE フレームサイズに合わせてスケールすることで、不要なリサイズを防止できます。

### Which scaling method should I use, OLE frame scaling or cell range scaling?

元の Excel の行・列サイズを維持したい場合は **OLE frame scaling** を選択してください。プレゼンテーション内で OLE フレームのサイズを固定したい場合は **cell range scaling** を選択してください。

### Will these solutions work if my presentation is based on a template?

はい。どちらのソリューションもテンプレートから作成したプレゼンテーションでも、ゼロから作成したプレゼンテーションでも機能します。

### Is there a limit to the size of the OLE frame when using these methods?

いいえ。スケールを適切に設定すれば、OLE オブジェクト フレームのサイズに制限はありません。

### Is there a way to avoid the "EMBEDDED OLE OBJECT" placeholder text in PowerPoint?

はい。対象の Excel セル範囲のスナップショットを取得し、OLE フレームのプレースホルダー画像として設定すれば、デフォルトのプレースホルダー文字列の代わりにカスタムプレビュー画像を表示できます。

## **Related Articles**

[Creating an Excel Chart and Embedding It in a Presentation as an OLE Object](/slides/ja/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Updating OLE Objects Automatically Using an MS PowerPoint Add-In](/slides/ja/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)