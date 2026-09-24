---
title: "JavaScript を使用したプレゼンテーションでのチャート ワークブックの管理"
linktitle: "チャート ワークブック"
type: docs
weight: 70
url: /ja/nodejs-java/chart-workbook/
keywords:
- "チャート ワークブック"
- "チャート データ"
- "ワークブック セル"
- "データ ラベル"
- "ワークシート"
- "データ ソース"
- "外部ワークブック"
- "外部データ"
- "チャート キャッシュ"
- "ワークブック 復元"
- "PowerPoint"
- "プレゼンテーション"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Java を介した Node.js 用 Aspose.Slides を発見し、PowerPoint および OpenDocument 形式でチャート ワークブックを簡単に管理して、プレゼンテーション データを効率化します。"
---
## **概要**

この記事では、Aspose.Slides でチャート ワークブックを操作する方法を説明します。ワークブック ストリームを介してチャート データを読み書きする方法、ワークブック セルをチャート データ ラベルとして使用する方法、ワークシート コレクションにアクセスする方法、チャート 値のデータ ソース タイプを指定する方法を示します。

また、外部ワークブックをチャート データ ソースとして使用する方法も取り上げます。例では、外部ワークブックの作成と割り当て、チャートにリンクされた外部ワークブックのパス取得、ワークブックが利用可能な場合のチャート データ編集をデモンストレーションしています。

欠損データを表すワークブック セルについては、空セルと 0 の違い、および利用可能な表示モードの折れ線グラフ比較については[空セルの表示制御](/slides/ja/nodejs-java/chart-series/)をご参照ください。

## **ワークブックからチャートデータを読み書き**

Aspose.Slides は、[readWorkbookStream](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ChartData#readWorkbookStream--) および [writeWorkbookStream](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ChartData#writeWorkbookStream-byte:A-) メソッドを提供し、チャート データ ワークブック（Aspose.Cells で編集されたチャート データを含む）を読み書きできます。**注**: チャート データは、元の構造と同じ方式で整理されているか、類似した構造である必要があります。

この JavaScript コードはサンプル操作を示しています:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

### **ワークブックの変更後のチャートレイアウトの検証**

埋め込みワークブックを変更済みのものに差し替えると、チャートは元の系列とカテゴリ コレクションを保持します。この不整合により、[Chart.validateChartLayout](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Chart#validateChartLayout--) がインデックス範囲外エラーで失敗することがあります。更新されたワークブックを書き戻す前に、既存の系列とカテゴリをクリアしてください。

```javascript
// ワークブック ストリームを変更した後（例: Aspose.Cells を使用）
var updatedWorkbook = chartData.readWorkbookStream();

// 既存のデータ参照をクリアします。
chartData.getSeries().clear();
chartData.getCategories().clear();

chartData.writeWorkbookStream(updatedWorkbook);

chart.validateChartLayout();
```

コレクションをクリアすると、チャート データ構造が新しいワークブックと一致し、`validateChartLayout` がエラーなく完了します。

## **ワークブックセルをチャートデータラベルとして設定**

1. [Presentation](https://apireference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation) クラスのインスタンスを作成します。  
1. スライドをインデックスで取得します。  
1. いくつかのデータを含むバブル チャートを追加します。  
1. チャート 系列にアクセスします。  
1. ワークブック セルをデータ ラベルとして設定します。  
1. プレゼンテーションを保存します。

この JavaScript コードは、ワークブック セルをチャート データ ラベルとして設定する方法を示しています:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var lbl0 = "Label 0 cell value";
var lbl1 = "Label 1 cell value";
var lbl2 = "Label 2 cell value";
// プレゼンテーション ファイルを表すプレゼンテーションクラスのインスタンスを作成します
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
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

## **データソースタイプの指定**

この JavaScript コードは、データ ソースのタイプを指定する方法を示しています:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

Aspose.Slides は、一部のチャートに埋め込める Excel バイナリ ワークブック（.xlsb）形式をサポートしていません。`getEmbeddedWorkbookType` メソッドを [ChartData](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdata/) と共に使用し、[WorkbookType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/workbooktype/) 列挙体でサポート外形式を検出して該当チャートをスキップできます。

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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
            // .xlsb 形式の埋め込みワークブックはサポートされていません。
            continue;
        }

        // ここでチャート ワークブック データを読み取りまたは変更します。
    }
} finally {
    presentation.dispose();
}
```

## **外部ワークブック**

Aspose.Slides は、チャートのデータ ソースとして外部ワークブックをサポートしています。

### **外部ワークブックの作成**

**`readWorkbookStream`** と **`setExternalWorkbook`** メソッドを使用すると、外部ワークブックをゼロから作成するか、内部ワークブックを外部化できます。

この JavaScript コードは外部ワークブック作成プロセスをデモンストレーションしています:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fileSystem = require("fs");

var pres = new aspose.slides.Presentation();
try {
    var workbookPath = "externalWorkbook1.xlsx";
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600);
    // readWorkbookStream はワークブックのバイトを Node Buffer として返します。
    var workbookData = chart.getChartData().readWorkbookStream();
    fileSystem.writeFileSync(workbookPath, Buffer.from(workbookData));
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

**`setExternalWorkbook`** メソッドを使用して、外部ワークブックをチャートのデータ ソースとして割り当てられます。このメソッドは、外部ワークブックのパスが変更された場合の更新にも利用できます。

リモート ロケーションやリソースに保存されたワークブックのデータを直接編集することはできませんが、外部データ ソースとして使用できます。相対パスが指定された場合は、フル パスに自動変換されます。

この JavaScript コードは外部ワークブックを設定する方法を示しています:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

`setExternalWorkbook` メソッドの第2 パラメータ `updateChartData` は、Excel ワークブックをロードするかどうかを指定します。

* `updateChartData` を `false` に設定すると、ワークブック パスだけが更新され、チャート データは対象ワークブックからロードまたは更新されません。対象ワークブックが存在しない、または利用できない状況でこの設定を使用します。  
* `updateChartData` を `true` に設定すると、チャート データが対象ワークブックから更新されます。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

### **チャート外部データソースワークブックパスの取得**

1. [Presentation](https://apireference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation) クラスのインスタンスを作成します。  
1. スライドをインデックスで取得します。  
1. チャート シェイプのオブジェクトを作成します。  
1. チャートのデータ ソースを表す `ChartDataSourceType` オブジェクトを作成します。  
1. 外部ワークブック データ ソース タイプと同じであるかどうかに基づき、該当条件を指定します。

この JavaScript コードは操作をデモンストレーションしています:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

### **チャートデータの編集**

外部ワークブックのデータは、内部ワークブックの内容を変更するのと同様に編集できます。外部ワークブックをロードできない場合は例外がスローされます。

この JavaScript コードは上記プロセスの実装例です:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

### **チャートキャッシュからワークブックを復元**

チャートが欠損または利用不可の外部ワークブックを使用している場合、Aspose.Slides はプレゼンテーションにキャッシュされたデータからチャート ワークブックを再構築できます。[LoadOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/loadoptions/) を作成し、[SpreadsheetOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/spreadsheetoptions/) で構成し、プレゼンテーションを開く前に `true` を指定して [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) を呼び出します。

以下の JavaScript 例は、利用できない外部ワークブックを参照しているプレゼンテーションを開き、[ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook) を通じて復元されたデータにアクセスします:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const spreadsheetOptions = new aspose.slides.SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

const presentation = new aspose.slides.Presentation("presentation.pptx", loadOptions);
try {
    const chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // ここで復元されたワークブック データを読み取りまたは変更します。
} finally {
    presentation.dispose();
}
```

外部ワークブックが利用できず、復元が無効化されている場合、Aspose.Slides は例外をスローします。キャッシュされたチャート データをフォールバックとして受け入れ可能な場合にのみ復元を有効にしてください。キャッシュには、プレゼンテーションが最後に更新された後に外部ワークブックで行われた変更が含まれない可能性があります。

## **よくある質問**

**特定のチャートが外部ワークブックにリンクされているか、埋め込みワークブックにリンクされているかを判断できますか？**

はい。チャートには[data source type](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) と[外部ワークブックへのパス](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) があり、ソースが外部ワークブックの場合はフルパスを読み取って外部ファイルが使用されていることを確認できます。

**外部ワークブックへの相対パスはサポートされていますか？また、どのように保存されますか？**

はい。相対パスを指定すると自動的に絶対パスに変換されます。これはプロジェクトのポータビリティに便利ですが、プレゼンテーションは PPTX ファイル内に絶対パスを保存する点に留意してください。

**ネットワーク リソース/共有上のワークブックを使用できますか？**

はい、そのようなワークブックは外部データ ソースとして使用可能です。ただし、Aspose.Slides からリモート ワークブックを直接編集することはサポートされていません。ソースとしてのみ使用できます。

**プレゼンテーションを保存すると、外部 XLSX が上書きされますか？**

いいえ。プレゼンテーションは[外部ファイルへのリンク](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) を保存し、データの読み取りに使用します。保存時に外部ファイル自体は変更されません。

**外部ファイルがパスワードで保護されている場合はどうすればよいですか？**

Aspose.Slides はリンク時にパスワードを受け付けません。一般的な対策として、事前に保護を解除するか、[Aspose.Cells](/cells/nodejs-java/) などで復号化したコピーを用意し、そのコピーにリンクします。

**複数のチャートが同じ外部ワークブックを参照できますか？**

はい。各チャートは独自のリンクを保持します。すべてが同一ファイルを指す場合、そのファイルを更新すると次回データがロードされる際に各チャートに反映されます。