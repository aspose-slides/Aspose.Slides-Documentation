---
title: JavaScript を使用したプレゼンテーションでのチャート ワークブックの管理
linktitle: チャート ワークブック
type: docs
weight: 70
url: /ja/nodejs-java/chart-workbook/
keywords:
- チャート ワークブック
- チャート データ
- ワークブック セル
- データ ラベル
- ワークシート
- データ ソース
- 外部ワークブック
- 外部データ
- チャート キャッシュ
- ワークブック 復元
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Java 用 Aspose.Slides for Node.js を発見: PowerPoint および OpenDocument 形式でチャート ワークブックを簡単に管理し、プレゼンテーション データを合理化します。"
---
## **概要**

この記事では、Aspose.Slides でチャート ワークブックを操作する方法を説明します。ワークブック ストリームを介してチャート データを読み書きする方法、ワークブック セルをチャート データ ラベルとして使用する方法、ワークシート コレクションにアクセスする方法、チャート値のデータ ソース タイプを指定する方法を示します。

また、外部ワークブックをチャート データ ソースとして使用する方法も取り上げます。サンプルでは、外部ワークブックの作成と割り当て、チャートにリンクされた外部ワークブックのパス取得、およびワークブックが利用可能な場合のチャート データ編集方法を示します。

## **ワークブックからチャートデータの読み書き**

Aspose.Slides は、[readWorkbookStream](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ChartData#readWorkbookStream--) と [writeWorkbookStream](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ChartData#writeWorkbookStream-byte:A-) メソッドを提供し、チャート データ ワークブック（Aspose.Cells で編集されたチャート データを含む）を読み書きできます。**注意**: チャート データは、元のデータと同じ形式で構成されているか、類似した構造である必要があります。

この JavaScript コードはサンプル操作を示しています:

```javascript
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var data = chart.getChartData();
    var stream = data.readWorkbookStream();
    data.getSeries().clear();
    data.getCategories().clear();
    data.writeWorkbookStream(stream);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **WorkBookセルをChartデータラベルとして設定**

1. [Presentation](https://apireference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドへの参照を取得します。  
3. データを含むバブル チャートを追加します。  
4. チャート シリーズにアクセスします。  
5. ワークブック セルをデータ ラベルとして設定します。  
6. プレゼンテーションを保存します。

この JavaScript コードは、ワークブック セルをチャート データ ラベルとして設定する方法を示しています:

```javascript
var lbl0 = "Label 0 cell value";
var lbl1 = "Label 1 cell value";
var lbl2 = "Label 2 cell value";
// プレゼンテーション ファイルを表すプレゼンテーション クラスのインスタンスを作成します
var pres = new aspose.slides.Presentation("chart2.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries();
    var dataLabelCollection = series.get_Item(0).getLabels();
    dataLabelCollection.getDefaultDataLabelFormat().setShowLabelValueFromCell(true);
    var wb = chart.getChartData().getChartDataWorkbook();
    dataLabelCollection.get_Item(0).setValueFromCell(wb.getCell(0, "A10", lbl0));
    dataLabelCollection.get_Item(1).setValueFromCell(wb.getCell(0, "A11", lbl1));
    dataLabelCollection.get_Item(2).setValueFromCell(wb.getCell(0, "A12", lbl2));
    pres.save("resultchart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ワークシートの管理**

この JavaScript コードは、[ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ChartDataWorkbook#getWorksheets--) メソッドを使用してワークシート コレクションにアクセスする操作を示しています:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 500);
    var wb = chart.getChartData().getChartDataWorkbook();
    for (var i = 0; i < wb.getWorksheets().size(); i++) {
        console.log(wb.getWorksheets().get_Item(i).getName());
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **データ ソース タイプの指定**

この JavaScript コードは、データ ソースのタイプを指定する方法を示しています:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    var val = chart.getChartData().getSeries().get_Item(0).getName();
    val.setDataSourceType(aspose.slides.DataSourceType.StringLiterals);
    val.setData("LiteralString");
    val = chart.getChartData().getSeries().get_Item(1).getName();
    val.setData(chart.getChartData().getChartDataWorkbook().getCell(0, "B1", "NewCell"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **サポートされていない埋め込みワークブック形式の検出**

Aspose.Slides は、いくつかのチャートに埋め込むことができる Excel バイナリ ワークブック（.xlsb）形式をサポートしていません。`getEmbeddedWorkbookType` メソッドを [ChartData](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdata/) と共に使用し、[WorkbookType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/workbooktype/) 列挙体でサポートされていない形式を検出してそれらのチャートをスキップできます。

```js
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shapes = slide.getShapes();

    for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
        let shape = shapes.get_Item(shapeIndex);

        if (!java.instanceOf(shape, "com.aspose.slides.IChart")) continue;

        let chart = shape;
        let chartData = chart.getChartData();

        if (chartData.getDataSourceType() == aspose.slides.ChartDataSourceType.InternalWorkbook &&
                chartData.getEmbeddedWorkbookType() == aspose.slides.WorkbookType.WorkbookBinaryMacro) {
            // 埋め込みワークブックは .xlsb 形式で、サポートされていません。
            continue;
        }

        // ここでチャートワークブックのデータを読み取るか、変更します。
    }
} finally {
    presentation.dispose();
}
```

## **外部ワークブック**

Aspose.Slides は、チャートのデータ ソースとして外部ワークブックをサポートします。

### **外部ワークブックの作成**

**`readWorkbookStream`** と **`setExternalWorkbook`** メソッドを使用すると、ゼロから外部ワークブックを作成するか、内部ワークブックを外部化できます。

この JavaScript コードは外部ワークブック作成プロセスを示しています:

```javascript
var pres = new aspose.slides.Presentation();
try {
    final var workbookPath = "externalWorkbook1.xlsx";
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600);
    var fileStream = java.newInstanceSync("java.io.FileOutputStream", workbookPath);
    try {
        var workbookData = chart.getChartData().readWorkbookStream();
        fileStream.write(workbookData, 0, workbookData.length);
    } finally {
        if (fileStream != null) {
            fileStream.close();
        }
    }
    chart.getChartData().setExternalWorkbook(workbookPath);
    pres.save("externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **外部ワークブックの設定**

**`setExternalWorkbook`** メソッドを使用して、外部ワークブックをチャートのデータ ソースとして割り当てることができます。このメソッドは、外部ワークブックのパスが移動された場合にパスを更新する際にも使用できます。

リモート場所やリソースに保存されているワークブックのデータは編集できませんが、外部データ ソースとして使用することは可能です。相対パスが指定されると、自動的にフル パスに変換されます。

この JavaScript コードは外部ワークブックの設定方法を示しています:

```javascript
// Presentation クラスのインスタンスを作成します
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, false);
    var chartData = chart.getChartData();
    chartData.setExternalWorkbook("externalWorkbook.xlsx");
    chartData.getSeries().add(chartData.getChartDataWorkbook().getCell(0, "B1"), aspose.slides.ChartType.Pie);
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B2"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B3"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B4"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A2"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A3"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A4"));
    pres.save("Presentation_with_externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

`setExternalWorkbook` メソッドの `ChartData` パラメーターは、Excel ワークブックをロードするかどうかを指定します。

* `ChartData` が `false` に設定されている場合、ワークブック パスのみが更新され、チャート データは対象ワークブックから読み込まれません。対象ワークブックが存在しない、または利用できない状況でこの設定を使用します。  
* `ChartData` が `true` に設定されている場合、チャート データは対象ワークブックから更新されます。

```javascript
// Presentation クラスのインスタンスを作成します
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, true);
    var chartData = chart.getChartData();
    chartData.setExternalWorkbook("http://path/doesnt/exists", false);
    pres.save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **チャート外部データ ソース ワークブック パスの取得**

1. [Presentation](https://apireference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドへの参照を取得します。  
3. チャート シェイプのオブジェクトを作成します。  
4. `ChartDataSourceType` 型のオブジェクトを作成し、チャートのデータ ソースを表します。  
5. 外部ワークブック データ ソース タイプと同じであることを条件として指定します。

この JavaScript コードは操作を示しています:

```javascript
// Presentation クラスのインスタンスを作成します
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var slide = pres.getSlides().get_Item(1);
    var chart = slide.getShapes().get_Item(0);
    var sourceType = chart.getChartData().getDataSourceType();
    if (sourceType == aspose.slides.ChartDataSourceType.ExternalWorkbook) {
        var path = chart.getChartData().getExternalWorkbookPath();
    }
    // プレゼンテーションを保存します
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **チャート データの編集**

外部ワークブックのデータは、内部ワークブックの内容を変更するのと同様に編集できます。外部ワークブックがロードできない場合は例外がスローされます。

この JavaScript コードは上記プロセスの実装例です:

```javascript
// Presentation クラスのインスタンスを作成します
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var chartData = chart.getChartData();
    chartData.getSeries().get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell().setValue(100);
    pres.save("presentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **チャート キャッシュからワークブックを復元**

チャートが存在しないまたは利用できない外部ワークブックを使用している場合、Aspose.Slides はプレゼンテーションにキャッシュされているデータからチャート ワークブックを再構築できます。[LoadOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/loadoptions/) を作成し、[SpreadsheetOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/spreadsheetoptions/) で構成し、プレゼンテーションを開く前に `SpreadsheetOptions.setRecoverWorkbookFromChartCache` を `true` に設定します。

次の JavaScript 例は、利用できない外部ワークブックを参照するチャートを含むプレゼンテーションを開き、[ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook) を介して復元されたデータにアクセスする方法を示しています:

```javascript
const spreadsheetOptions = new aspose.slides.SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

const presentation = new aspose.slides.Presentation("presentation.pptx", loadOptions);
try {
    const chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // ここで回復されたワークブック データを読み取るか、変更します。
} finally {
    presentation.dispose();
}
```

外部ワークブックが利用できず、復元が無効になっている場合、Aspose.Slides は例外をスローします。キャッシュされたチャート データの使用が許容できるフォールバックである場合にのみ復元を有効にしてください。キャッシュには、プレゼンテーションが最後に更新された後に外部ワークブックで行われた変更が含まれない可能性があります。

## **FAQ**

**特定のチャートが外部ワークブックにリンクされているか、埋め込みワークブックにリンクされているかを判別できますか？**

はい。チャートには [data source type](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) と [external workbook のパス](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) があり、外部ワークブックがソースの場合はフル パスを読み取って外部ファイルが使用されていることを確認できます。

**外部ワークブックへの相対パスはサポートされますか？ また、どのように保存されますか？**

はい。相対パスを指定すると自動的に絶対パスに変換されます。プロジェクトの移植性に便利ですが、PPTX ファイルには絶対パスが保存される点に注意してください。

**ネットワーク リソースや共有フォルダー上のワークブックを使用できますか？**

はい、そのようなワークブックは外部データ ソースとして使用できます。ただし、Aspose.Slides から直接リモートワークブックを編集することはサポートされていません。ソースとしてのみ使用可能です。

**プレゼンテーションを保存すると外部 XLSX が上書きされますか？**

いいえ。プレゼンテーションは [外部ファイルへのリンク](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) を保存し、データ読み取り時に使用します。保存時に外部ファイル自体は変更されません。

**外部ファイルがパスワード保護されている場合はどうすべきですか？**

Aspose.Slides はリンク時にパスワードを受け付けません。一般的な対応策は、事前に保護を解除するか、[Aspose.Cells](/cells/nodejs-java/) などで復号化したコピーを作成してそのコピーにリンクすることです。

**複数のチャートが同じ外部ワークブックを参照できますか？**

はい。各チャートはそれぞれのリンクを保持します。同じファイルを指す場合、そのファイルを更新すれば次回データがロードされるときにすべてのチャートに反映されます。