---
title: ワークシートのリサイズに対する実装済みソリューション
type: docs
weight: 20
url: /ja/nodejs-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- プレビュー画像
- 画像リサイズ
- Excel
- ワークシート
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "プレゼンテーションで Excel ワークシートの OLE サイズ変更を修正します。オブジェクトフレームを一貫させる方法は二つあり、フレームをスケーリングするかシートをスケーリングするかで、PPT と PPTX の両形式に対応します。"
---
{{% alert color="info" title="Note" %}}

Aspose コンポーネントを使用して PowerPoint プレゼンテーションに OLE オブジェクトとして埋め込まれた Excel ワークシートは、最初にアクティベートされた後にサイズが予期せず変更されることがあります。この動作により、OLE オブジェクトのアクティベート前後で視覚的な差異が顕著になります。本記事ではこの問題を説明し、対処方法を 2 つ紹介します。

{{% /alert %}}

## **背景**

[Manage OLE](/slides/ja/nodejs-java/manage-ole/) 記事では、Aspose.Slides for Node.js via Java を使用して PowerPoint プレゼンテーションに OLE フレームを追加する方法を説明しました。[object preview issue](/slides/ja/nodejs-java/object-preview-issue-when-adding-oleobjectframe/) に対処するため、選択したワークシート領域の画像を OLE オブジェクトフレームに割り当てました。出力されたプレゼンテーションで、ワークシート画像が表示された OLE オブジェクトフレームをダブルクリックすると Excel ブックがアクティブになります。エンドユーザーは実際の Excel ブックで任意の変更を行い、アクティブ化された Excel ブックの外側をクリックしてスライドに戻ります。ユーザーがスライドに戻ると OLE オブジェクトフレームのサイズが変わります。リサイズの倍率は OLE オブジェクトフレームのサイズと埋め込まれた Excel ブックのサイズに依存します。

## **リサイズの原因**

Excel ブックは独自のウィンドウサイズを持つため、最初のアクティベート時に元のサイズを保持しようとします。一方、OLE オブジェクトフレームは独自のサイズを持ちます。Microsoft によると、Excel ブックがアクティブになると、Excel と PowerPoint がサイズを協議し、埋め込みプロセスの一部として正しい比率を保つようにします。リサイズは Excel ウィンドウサイズと OLE オブジェクトフレームのサイズ・位置の差異に基づいて発生します。

## **実装済みの解決策**

リサイズ効果を回避するための 2 つの解決策があります。

- PowerPoint プレゼンテーション内の OLE フレームを、選択した行と列の総高さ・幅に合わせてスケーリングする。
- OLE フレームのサイズを一定に保ち、選択した行と列をフレームに収まるようにスケーリングする。

### **OLE フレームサイズをスケーリングする**

この方法は、埋め込まれた Excel ワークシートの選択された行と列の総高さ・幅に合わせて OLE フレームサイズを設定します。

例では既存の Excel ブックを読み込み、0 ベースのインデックスを使用して最初のワークシートの最初の 10 行と 13 列を選択します。[WorksheetCollection.setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) が表示範囲を定義します。プレビューは 96 DPI でレンダリングされ、ピクセル寸法は 1 インチあたり 72 ポイントでポイントに変換されます。[ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame) が、これらの寸法でフレームに変更されたブックを埋め込みます。プレビューは [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) を通じて割り当てられ、保存されたプレゼンテーションの「EMBEDDED OLE OBJECT」プレースホルダーを置き換えます。

`aspose.cells`、`aspose.slides.via.java`、`java` パッケージをインストールし、作業ディレクトリに `sample.xlsx` を配置してください。各アプローチについて、最初に準備スクリプトを実行し、同じディレクトリで別の Node.js プロセスとして埋め込みスクリプトを実行します。2 つの Aspose パッケージはそれぞれ Java ブリッジを別個に初期化します。

この準備スクリプトを `prepare-frame-scaled.js` として保存し、`node prepare-frame-scaled.js` で実行してください。`frame-scaled.xlsx` と `frame-scaled.png` が作成されます。

```javascript
const cells = require("aspose.cells");

function createOleImage(cellRange, imageResolution, imagePath) {
    const worksheet = cellRange.getWorksheet();
    const pageSetup = worksheet.getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    const imageOptions = new cells.ImageOrPrintOptions();
    imageOptions.setImageType(cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    const sheetRender = new cells.SheetRender(worksheet, imageOptions);
    sheetRender.toImage(0, imagePath);
}

function prepareWorkbook(outputName) {
    const workbook = new cells.Workbook("sample.xlsx");
    try {
        const startRow = 0;
        const rowCount = 10;
        const startColumn = 0;
        const columnCount = 13;
        const worksheet = workbook.getWorksheets().get(0);
        const lastRow = startRow + rowCount - 1;
        const lastColumn = startColumn + columnCount - 1;
        workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

        const cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);

        createOleImage(cellRange, 96, outputName + ".png");
        workbook.save(outputName + ".xlsx", cells.SaveFormat.XLSX);
        return true;
    } finally {
        workbook.dispose();
    }
}

prepareWorkbook("frame-scaled");

// すべての同期処理が完了しました。Java ブリッジプロセスを停止します。
process.exit(0);
```

この埋め込みスクリプトを `embed-frame-scaled.js` として保存し、`node embed-frame-scaled.js` で実行してください。これらのファイルを読み取り、`frame-scaled.pptx` を出力します。

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

function embedWorkbook(inputName, useFixedFrame) {
    const imageBuffer = fs.readFileSync(inputName + ".png");
    const imageBytes = java.newArray("byte", Array.from(imageBuffer));
    const workbookBuffer = fs.readFileSync(inputName + ".xlsx");
    const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));

    const image = slides.Images.fromData(imageBytes);
    try {
        const imageResolution = 96;
        const frameWidth = useFixedFrame ? 400 : image.getWidth() * 72 / imageResolution;
        const frameHeight = useFixedFrame ? 100 : image.getHeight() * 72 / imageResolution;

        const presentation = new slides.Presentation();
        try {
            const slide = presentation.getSlides().get_Item(0);
            const dataInfo = new slides.OleEmbeddedDataInfo(workbookBytes, "xlsx");
            const oleFrame = slide.getShapes().addOleObjectFrame(java.newFloat(10), java.newFloat(10), java.newFloat(frameWidth), java.newFloat(frameHeight), dataInfo);
            const previewImage = presentation.getImages().addImage(image);
            oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);
            oleFrame.setObjectIcon(false);

            presentation.save(inputName + ".pptx", slides.SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    } finally {
        image.dispose();
    }
}

embedWorkbook("frame-scaled", false);

// すべての同期処理が完了しました。Java ブリッジプロセスを停止します。
process.exit(0);
```

プレビューヘルパーは [PageSetup.setPrintArea](https://reference.aspose.com/cells/nodejs/aspose.cells/pagesetup/#setprintarea) を選択範囲に設定し、余白・ヘッダー・フッターを除去します。[ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/nodejs/aspose.cells/imageorprintoptions/#setonlyarea) を有効にすると、[SheetRender.toImage](https://reference.aspose.com/cells/nodejs/aspose.cells/sheetrender/#toimage) が範囲を PNG 画像としてレンダリングします。ヘルパーは PNG 画像をファイルに保存し、プレゼンテーションで使用します。

### **セル範囲サイズをスケーリングする**

この方法は、選択した行の高さと列の幅をカスタム OLE フレームサイズに合わせてスケーリングします。

例では既存の Excel ブックを読み込み、0 ベースのインデックスで最初のワークシートの最初の 10 行と 13 列を選択します。[WorksheetCollection.setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) が表示範囲を定義し、ヘルパーはその範囲を幅 400 ポイント・高さ 100 ポイントのフレームに収まるようにスケーリングします。変更されたブックをファイルに保存した後、[ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame) が指定サイズで埋め込みます。96 DPI でレンダリングされたプレビューは [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) を通じて割り当てられ、保存されたプレゼンテーションはデフォルトのプレースホルダーではなく選択セルを表示します。

この準備スクリプトを `prepare-cells-scaled.js` として保存し、`node prepare-cells-scaled.js` で実行してください。`cells-scaled.xlsx` と `cells-scaled.png` が作成されます。

```javascript
const cells = require("aspose.cells");

function scaleCellRange(cellRange, width, height) {
    const rangeWidth = cellRange.getWidth();
    const rangeHeight = cellRange.getHeight();
    if (rangeWidth <= 0 || rangeHeight <= 0) {
        console.error("The selected range must have nonzero width and height.");
        return false;
    }

    const worksheetCells = cellRange.getWorksheet().getCells();
    for (let i = 0; i < cellRange.getColumnCount(); i++) {
        const columnIndex = cellRange.getFirstColumn() + i;
        const columnWidth = worksheetCells.getColumnWidth(columnIndex, false, cells.CellsUnitType.POINT);
        const widthInInches = columnWidth * width / rangeWidth / 72;
        worksheetCells.setColumnWidthInch(columnIndex, widthInInches);
    }
    for (let i = 0; i < cellRange.getRowCount(); i++) {
        const rowIndex = cellRange.getFirstRow() + i;
        const rowHeight = worksheetCells.getRowHeight(rowIndex, false, cells.CellsUnitType.POINT);
        const heightInInches = rowHeight * height / rangeHeight / 72;
        worksheetCells.setRowHeightInch(rowIndex, heightInInches);
    }
    return true;
}

function createOleImage(cellRange, imageResolution, imagePath) {
    const worksheet = cellRange.getWorksheet();
    const pageSetup = worksheet.getPageSetup();
    pageSetup.setPrintArea(cellRange.getAddress());
    pageSetup.setLeftMargin(0);
    pageSetup.setRightMargin(0);
    pageSetup.setTopMargin(0);
    pageSetup.setBottomMargin(0);
    pageSetup.clearHeaderFooter();

    const imageOptions = new cells.ImageOrPrintOptions();
    imageOptions.setImageType(cells.ImageType.PNG);
    imageOptions.setVerticalResolution(imageResolution);
    imageOptions.setHorizontalResolution(imageResolution);
    imageOptions.setOnePagePerSheet(true);
    imageOptions.setOnlyArea(true);

    const sheetRender = new cells.SheetRender(worksheet, imageOptions);
    sheetRender.toImage(0, imagePath);
}

function prepareWorkbook(outputName, scaleCells) {
    const workbook = new cells.Workbook("sample.xlsx");
    try {
        const startRow = 0;
        const rowCount = 10;
        const startColumn = 0;
        const columnCount = 13;
        const worksheet = workbook.getWorksheets().get(0);
        const lastRow = startRow + rowCount - 1;
        const lastColumn = startColumn + columnCount - 1;
        workbook.getWorksheets().setOleSize(startRow, lastRow, startColumn, lastColumn);

        const cellRange = worksheet.getCells().createRange(startRow, startColumn, rowCount, columnCount);
        if (scaleCells && !scaleCellRange(cellRange, 400, 100)) {
            return false;
        }

        createOleImage(cellRange, 96, outputName + ".png");
        workbook.save(outputName + ".xlsx", cells.SaveFormat.XLSX);
        return true;
    } finally {
        workbook.dispose();
    }
}

const cellsPrepared = prepareWorkbook("cells-scaled", true);

// すべての同期処理が完了しました。Java ブリッジプロセスを停止します。
process.exit(cellsPrepared ? 0 : 1);
```

この埋め込みスクリプトを `embed-cells-scaled.js` として保存し、`node embed-cells-scaled.js` で実行してください。これらのファイルを読み取り、`cells-scaled.pptx` を出力します。

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

function embedWorkbook(inputName, useFixedFrame) {
    const imageBuffer = fs.readFileSync(inputName + ".png");
    const imageBytes = java.newArray("byte", Array.from(imageBuffer));
    const workbookBuffer = fs.readFileSync(inputName + ".xlsx");
    const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));

    const image = slides.Images.fromData(imageBytes);
    try {
        const imageResolution = 96;
        const frameWidth = useFixedFrame ? 400 : image.getWidth() * 72 / imageResolution;
        const frameHeight = useFixedFrame ? 100 : image.getHeight() * 72 / imageResolution;

        const presentation = new slides.Presentation();
        try {
            const slide = presentation.getSlides().get_Item(0);
            const dataInfo = new slides.OleEmbeddedDataInfo(workbookBytes, "xlsx");
            const oleFrame = slide.getShapes().addOleObjectFrame(java.newFloat(10), java.newFloat(10), java.newFloat(frameWidth), java.newFloat(frameHeight), dataInfo);
            const previewImage = presentation.getImages().addImage(image);
            oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);
            oleFrame.setObjectIcon(false);

            presentation.save(inputName + ".pptx", slides.SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    } finally {
        image.dispose();
    }
}

embedWorkbook("cells-scaled", true);

// すべての同期処理が完了しました。Java ブリッジプロセスを停止します。
process.exit(0);
```

スケーリングヘルパーは選択範囲の幅と高さの比率を個別に計算し、列の相対幅と行の相対高さを保持します。計算された寸法はポイントからインチに変換され、[Cells.setColumnWidthInch](https://reference.aspose.com/cells/nodejs/aspose.cells/cells/#setcolumnwidthinch) と [Cells.setRowHeightInch](https://reference.aspose.com/cells/nodejs/aspose.cells/cells/#setrowheightinch) で適用されます。選択範囲は幅と高さがゼロであってはなりません。

このプレビューヘルパーは [SheetRender.toImage](https://reference.aspose.com/cells/nodejs/aspose.cells/sheetrender/#toimage) を使用してリサイズされた範囲をレンダリングします。[PageSetup.setPrintArea](https://reference.aspose.com/cells/nodejs/aspose.cells/pagesetup/#setprintarea) をその範囲に限定し、余白・ヘッダー・フッターを除去し、PNG 画像をファイルに保存します。

## **結論**

{{% alert color="info" title="Note" %}}

ワークシートのリサイズ問題を解決するアプローチは 2 つあります。要件とユースケースに最適な方法を選択してください。どちらのアプローチも、テンプレートから作成したプレゼンテーションでも、ゼロから作成したプレゼンテーションでも同様に機能します。また、このソリューションでは OLE オブジェクトフレームのサイズに制限はありません。

{{% /alert %}}

## **FAQ**

**埋め込まれた Excel ワークシートが PowerPoint で最初にアクティベートされたときにサイズが変わるのはなぜですか？**

Excel がアクティベート時に元のウィンドウサイズを保持しようとし、PowerPoint の OLE オブジェクトフレームは独自の寸法を持つためです。PowerPoint と Excel がサイズを協議し、アスペクト比を保つ過程でリサイズが発生します。

**このリサイズ問題を完全に防ぐことは可能ですか？**

はい。OLE フレームを Excel のセル範囲サイズに合わせてスケーリングするか、セル範囲を目的の OLE フレームサイズに合わせてスケーリングすれば、不要なリサイズを防げます。

**どちらのスケーリング手法を使用すべきでしょうか、OLE フレーム スケーリングかセル範囲 スケーリングか？**

元の Excel の行・列サイズを保持したい場合は **OLE フレーム スケーリング** を選択してください。プレゼンテーション内で OLE フレームのサイズを固定したい場合は **セル範囲 スケーリング** を選択してください。

**テンプレートから作成したプレゼンテーションでもこれらの解決策は機能しますか？**

はい。両方の解決策はテンプレートから作成したプレゼンテーションでも、ゼロから作成したプレゼンテーションでも機能します。

**これらの方法を使用する際、OLE フレームのサイズに上限はありますか？**

いいえ。スケールを適切に設定すれば、OLE オブジェクトフレームは任意のサイズにできます。

**PowerPoint の「EMBEDDED OLE OBJECT」プレースホルダー文字列を回避する方法はありますか？**

はい。対象の Excel セル範囲のスナップショットを取得し、OLE フレームのプレースホルダー画像として設定すれば、デフォルトのプレースホルダーの代わりにカスタムプレビュー画像を表示できます。

## **関連記事**

[Creating an Excel Chart and Embedding It in a Presentation as an OLE Object](/slides/ja/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Updating OLE Objects Automatically Using an MS PowerPoint Add-In](/slides/ja/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)