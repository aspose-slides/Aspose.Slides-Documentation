---
title: JavaScript を使用してプレゼンテーションでチャート ワークシート数式を適用する
linktitle: ワークシート数式
type: docs
weight: 70
url: /ja/nodejs-java/chart-worksheet-formulas/
keywords:
- チャート スプレッドシート
- チャート ワークシート
- チャート 数式
- ワークシート 数式
- スプレッドシート 数式
- チャート データ ワークブック
- 数式 計算
- 論理定数
- 数値定数
- 文字列定数
- エラー定数
- 算術演算子
- 比較演算子
- A1 形式
- R1C1 形式
- 組み込み関数
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Java 経由のチャート ワークシートを使用して、Node.js 用 Aspose.Slides で Excel 形式の数式を適用し、値を再計算して PowerPoint のチャートで結果を使用します。"
---
## **概要**

PowerPoint のグラフは通常、データ ソースを埋め込みワークシートに格納します。Aspose.Slides for Node.js via Java では、チャート データ ワークブックを通じてそのワークシートにアクセスし、入力値を書き込み、セルに数式を割り当て、サポートされている数式を計算し、計算されたセルをチャート データとして使用できます。

この記事では、完全な数式ワークフローを説明します。グラフを作成し、ワークシートにデータを入力し、A1 形式または R1C1 形式の数式を割り当て、再計算し、計算結果を読み取り、これらのセルをチャート シリーズに接続し、プレゼンテーションを保存します。また、サポートされている数式構文、組み込み関数のサブセット、キャッシュ値、サポート外の数式、スプレッドシート固有のエラーについても説明します。

## **チャート ワークシートと数式**

チャート ワークシートには、チャートで使用されるカテゴリ、系列名、値が含まれます。PowerPoint では、チャート データ エディタを開くことでワークシートを確認できます。

![PowerPoint の埋め込みワークシートが開かれ、カテゴリと系列データが表示されているチャート](chart-worksheet-formulas_1.png)

Aspose.Slides では、ワークシートは[ChartDataWorkbook](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdataworkbook/)クラスを通じて公開されます。A1 形式の数式には[ChartDataCell.setFormula](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-)を、R1C1 形式の数式には[ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-)を使用します。入力セルや数式を変更した後は、[ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) を呼び出してサポートされている数式を再計算し、対応するセルの値を更新します。

計算されたセルは依然として[ChartDataCell.getValue](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdatacell/#getValue--) を通じて結果を取得できます。これは、コードで数式の結果を確認したり、セルをチャート データ ポイントとして使用したりする場合に重要です。

## **グラフの作成とワークシート数式の計算**

以下の例はエンドツーエンドのワークフローを示しています。クラスター化列グラフを作成し、サンプル データをクリアし、四半期ごとの収益と費用の値を書き込み、数式で利益を計算し、結果を読み取り、計算されたセルをチャート 値として使用し、プレゼンテーションを保存します。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 350);
    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    workbook.clear(worksheetIndex);

    const category1 = workbook.getCell(worksheetIndex, "A2", "Q1");
    const category2 = workbook.getCell(worksheetIndex, "A3", "Q2");
    const category3 = workbook.getCell(worksheetIndex, "A4", "Q3");

    workbook.getCell(worksheetIndex, "B1", "Revenue");
    workbook.getCell(worksheetIndex, "C1", "Expenses");
    workbook.getCell(worksheetIndex, "D1", "Profit");

    workbook.getCell(worksheetIndex, "B2").setValue(120.0);
    workbook.getCell(worksheetIndex, "C2").setValue(80.0);
    workbook.getCell(worksheetIndex, "B3").setValue(150.0);
    workbook.getCell(worksheetIndex, "C3").setValue(95.0);
    workbook.getCell(worksheetIndex, "B4").setValue(135.0);
    workbook.getCell(worksheetIndex, "C4").setValue(110.0);

    const profit1 = workbook.getCell(worksheetIndex, "D2");
    const profit2 = workbook.getCell(worksheetIndex, "D3");
    const profit3 = workbook.getCell(worksheetIndex, "D4");

    profit1.setFormula("B2-C2");
    profit2.setFormula("B3-C3");
    profit3.setFormula("B4-C4");

    workbook.calculateFormulas();

    const q1Profit = profit1.getValue(); // 40
    const q2Profit = profit2.getValue(); // 55
    const q3Profit = profit3.getValue(); // 25

    console.log("Q1 profit: " + q1Profit);
    console.log("Q2 profit: " + q2Profit);
    console.log("Q3 profit: " + q3Profit);

    chart.getChartData().getCategories().add(category1);
    chart.getChartData().getCategories().add(category2);
    chart.getChartData().getCategories().add(category3);

    const profitSeries = chart.getChartData().getSeries().add(workbook.getCell(worksheetIndex, "D1"), chart.getType());
    profitSeries.getDataPoints().addDataPointForBarSeries(profit1);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit2);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit3);
    profitSeries.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("chart-formulas.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

チャート データ ポイントは `D2:D4` を参照するため、チャートは計算された利益値を使用します。このワークフローでは別途チャート更新呼び出しは不要です。まずワークブックを再計算し、次に計算されたセルを指すチャート データを使用または保存します。

## **A1 形式の数式を使用する**

A1 表記は列を文字で、行を数字で識別します。A1 形式の式は[ChartDataCell.setFormula](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-)で割り当てます。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 300);
    const workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "C3").setValue(10);
    workbook.getCell(0, "F2").setValue(2);
    workbook.getCell(0, "G2").setValue(3);
    workbook.getCell(0, "H2").setValue(4);

    const cell = workbook.getCell(0, "A2");
    cell.setFormula("C3+SUM(F2:H2)");

    workbook.calculateFormulas();

    const value = cell.getValue(); // 19
} finally {
    presentation.dispose();
}
```

一般的な A1 参照形式は次のとおりです。

| 参照 | 相対 | 絶対 | 混合 |
|---|---|---|---|
| セル | `A2` | `$A$2` | `A$2`, `$A2` |
| 行 | `2:2` | `$2:$2` | — |
| 列 | `A:A` | `$A:$A` | — |
| 範囲 | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

相対参照は、スプレッドシート アプリケーションで数式を移動またはコピーしたときに変化します。絶対参照は両方の座標を固定し、混合参照は行または列のみを固定します。

## **R1C1 形式の数式を使用する**

R1C1 表記は行と列を数値で識別します。相対参照は角括弧でオフセットを指定します。この構文は[ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-)で割り当てます。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 300);
    const workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "B2").setValue(12);
    workbook.getCell(0, "C2").setValue(5);

    const cell = workbook.getCell(0, "D2");
    cell.setR1C1Formula("RC[-2]-RC[-1]");

    workbook.calculateFormulas();

    const value = cell.getValue(); // 7
} finally {
    presentation.dispose();
}
```

一般的な R1C1 参照形式は次のとおりです。

| 参照 | 相対 | 絶対 | 混合 |
|---|---|---|---|
| セル | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| 行 | `R[2]` | `R2` | — |
| 列 | `C[3]` | `C3` | — |
| 範囲 | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

たとえば、セル `D2` では `RC[-2]` は同じ行の左に 2 列あるセル (`B2`) を意味します。

## **数式の定数と演算子**

組み込みの数式評価エンジンは、論理値、数値リテラル、文字列、スプレッドシート エラー値、算術演算子、比較演算子をサポートします。

### **定数とリテラル**

| 種類 | 例 | 注釈 |
|---|---|---|
| 論理 | `TRUE`, `FALSE` | `A2=TRUE` のように論理式で直接使用できます。 |
| 数値 | `1`, `0.5`, `.3`, `1E-2` | 通常表記と指数表記の両方がサポートされています。 |
| 文字列 | `"abc"`, `"2/3/2020 12:00"` | 文字列リテラルは数式内で二重引用符で囲みます。 |
| エラー結果 | `#DIV/0!`, `#N/A`, `#REF!` | 有効な数式は通常の結果ではなくスプレッドシート エラー値に評価されることがあります。 |

この例は複数の定数タイプを使用しています。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 300);
    const workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "A2").setValue(false);
    workbook.getCell(0, "B2").setFormula("A2=TRUE");
    workbook.getCell(0, "C2").setFormula("1+0.5");
    workbook.getCell(0, "D2").setFormula(".3*1E-2");
    workbook.getCell(0, "E2").setFormula("\"abc\"");
    workbook.getCell(0, "F2").setFormula("2/0");

    workbook.calculateFormulas();

    const logicalValue = workbook.getCell(0, "B2").getValue(); // false
    const numericValue = workbook.getCell(0, "C2").getValue(); // 1.5
    const scientificValue = workbook.getCell(0, "D2").getValue(); // 0.003
    const stringValue = workbook.getCell(0, "E2").getValue(); // abc
    const errorValue = workbook.getCell(0, "F2").getValue(); // #DIV/0!
} finally {
    presentation.dispose();
}
```

### **算術演算子**

| 演算子 | 意味 | 例 |
|---|---|---|
| `+` | 加算または単項プラス | `2+3` |
| `-` | 減算または単項マイナス | `2-3`, `-3` |
| `*` | 乗算 | `2*3` |
| `/` | 除算 | `2/3` |
| `%` | パーセント | `30%` |
| `^` | 累乗 | `2^3` |

評価順序を明示したい場合は括弧を使用します。例: `(A2+B2)*C2`。

### **比較演算子**

比較式は論理値を返します。

| 演算子 | 意味 | 例 |
|---|---|---|
| `=` | 等しい | `A2=3` |
| `<>` | 等しくない | `A2<>3` |
| `>` | より大きい | `A2>3` |
| `>=` | 以上 | `A2>=3` |
| `<` | より小さい | `A2<3` |
| `<=` | 以下 | `A2<=3` |

## **サポートされている組み込み関数**

Aspose.Slides にはチャート ワークシート用の組み込み数式評価エンジンが含まれていますが、完全な Excel 計算エンジンではありません。ドキュメントで記載されている関数だけがサポート対象です。[ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) が処理できるかどうかは保証できません。

| 関数 | 用途またはサポート形態 | 例 |
|---|---|---|
| `ABS` | 絶対値 | `ABS(A2)` |
| `AVERAGE` | 算術平均 | `AVERAGE(B2:B5)` |
| `CEILING` | 指定の倍数に切り上げ | `CEILING(A2,5)` |
| `CHOOSE` | インデックスで値を選択 | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | 文字列結合 | `CONCAT(A2,B2)` |
| `CONCATENATE` | 文字列結合 | `CONCATENATE(A2," ",B2)` |
| `DATE` | 1900 日付系で日付を作成 | `DATE(2026,8,19)` |
| `DAYS` | 2つの日付間の日数を返す | `DAYS(B2,A2)` |
| `FIND` | 文字列内の検索 | `FIND("-",A2)` |
| `FINDB` | バイト単位の文字列検索 | `FINDB("a",A2)` |
| `IF` | 条件式 | `IF(A2>0,A2,0)` |
| `INDEX` | 参照形式 | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | ベクトル形式 | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | ベクトル形式 | `MATCH(A2,B2:B5,0)` |
| `MAX` | 最大値 | `MAX(B2:B5)` |
| `SUM` | 合計 | `SUM(B2:B5)` |
| `VLOOKUP` | 縦方向検索 | `VLOOKUP(A2,B2:D10,3,FALSE)` |

表に示された制限は重要です。`INDEX` は参照形式で、`LOOKUP` と `MATCH` はベクトル形式でのみサポートされます。`DATE` は 1900 日付系を使用します。ここに記載されていない機能や関数は、別途ドキュメントで明示されていない限り Aspose.Slides の数式評価エンジンではサポートされません。

## **再計算とキャッシュ値**

スプレッドシート ファイルは通常、数式と最後に計算された値の両方を保存します。Aspose.Slides はプレゼンテーションが読み込まれ、対象のチャート データが変更されていない場合、[ChartDataCell.getValue](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdatacell/#getValue--) からキャッシュされた値を取得できます。

入力セルや数式を変更した後は、古いキャッシュ結果に依存しないでください。計算された値を読み取る前や、計算結果に依存するチャート データを保存する前に、必ず[ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) を呼び出してください。

サポート外の数式については、Aspose.Slides が数式を解析できなかったり依存関係を確立できなかったりする可能性があります。ワークブックが変更された場合、以前のキャッシュ値は信頼できなくなります。そのような状況でサポート外データを持つセルの値を取得しようとすると、[CellUnsupportedDataException](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/cellunsupporteddataexception/) がスローされることがあります。

チャートが Aspose.Slides で評価されない Excel 関数に依存している場合は、対応するスプレッドシート エンジンで数式を計算し、結果の値を書き戻してください。サポート外の数式を推測した値で置き換えてはいけません。

## **数式エラーの処理**

区別すべき問題は 2 種類あります。

数式自体は有効だが `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, `#VALUE!` などのスプレッドシート エラー結果を返す場合があります。この場合、エラー トークンはセルの結果として扱われ、[ChartDataCell.getValue](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdatacell/#getValue--) で取得できます。

数式が構文エラー、参照エラー、依存関係エラー、またはサポート外データに起因して失敗することもあります。Aspose.Slides はこれらの場合に次のスプレッドシート固有例外を提供します: [CellInvalidFormulaException](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/cellcircularreferenceexception/), および [CellUnsupportedDataException](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/cellunsupporteddataexception/)。

テンプレートやユーザー入力から数式が供給される場合は、再計算および値取得時にエラーを捕捉してください。エラーの詳細は基礎となるスプレッドシート の問題を示します。

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 300);
    const workbook = chart.getChartData().getChartDataWorkbook();
    const cell = workbook.getCell(0, "A2");
    cell.setFormula("SUM(B2:B5)");

    try {
        workbook.calculateFormulas();
        console.log(cell.getValue());
    } catch (error) {
        console.error("Formula processing error: " + error.message);
    }
} finally {
    presentation.dispose();
}
```

## **実務上の制限**

チャート ワークシートにおける数式サポートは、完全な Excel 互換性ではなく、定義されたサブセットの計算を対象としています。レポーティング ワークフローを設計する際は、次の点に留意してください。

- Aspose.Slides に再計算させたい場合は、ドキュメント化された定数、演算子、参照、関数のみを使用してください。
- 数式結果が依存するセルを変更した後は必ず再計算してください。
- 読み込んだプレゼンテーションから取得したキャッシュ値はスナップショットであり、編集後の再計算の代替とはみなさないでください。
- 既存テンプレートの数式は、ドキュメント化されたリスト外の関数を使用している場合、計算結果に依存する前に必ずテストしてください。
- 完全なスプレッドシート計算エンジンが必要な数式は、外部で計算し、結果の値でチャート ワークブックを更新してください。

## **よくある質問**

**[ChartDataCell.setFormula](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) と [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) の違いは何ですか？**

[ChartDataCell.setFormula](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) は `B2-C2` のような A1 形式の式を格納します。[ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) は `RC[-2]-RC[-1]` のような R1C1 形式の式を格納します。生成またはコピーする数式の形式に合わせて選択してください。

**計算後はセル自体を読むべきですか、それとも値を読むべきですか？**

[ChartDataWorkbook.getCell](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdataworkbook/#getCell-int-java.lang.String-) は [ChartDataCell](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdatacell/) を返します。再計算後に計算結果を取得するには、そのセルの [ChartDataCell.getValue](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdatacell/#getValue--) メソッドを呼び出してください。

**[ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) はいつ呼び出すべきですか？**

入力値または数式を変更した後、計算結果に依存する前に必ず [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) を呼び出してください。これにより組み込み評価エンジンがサポートする数式の値が更新されます。

**Aspose.Slides はすべての Excel 関数をサポートしていますか？**

いいえ。組み込み評価エンジンはドキュメント化されたサブセットのみをサポートします。そのサブセット外の関数は正しく再計算できると想定しないでください。完全な Excel 互換が必要な場合は、適切なスプレッドシート エンジンで計算し、最終結果をチャート ワークブックに書き込んでください。

**読み込んだプレゼンテーションにサポート外の数式が含まれていたらどうなりますか？**

チャート データが変更されていなければ、ワークブックは以前に計算されたキャッシュ値を保持している可能性があります。関連データが変更された後は、そのキャッシュ値は無効になることがあります。処理できない数式を含むセルにアクセスすると、[CellUnsupportedDataException](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/cellunsupporteddataexception/) がスローされることがあります。

**数式エラー値は例外と同じですか？**

違います。`#DIV/0!` などの結果は有効な計算によって生成されたスプレッドシートの値です。一方、[CellInvalidFormulaException](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/cellinvalidformulaexception/) や [CellCircularReferenceException](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/cellcircularreferenceexception/) などの例外は、数式が正常に処理できないことを示します。

**数式セルが変更されたときにチャートは自動的に更新されますか？**

チャート 系列はワークブックのセルを参照できます。まずワークブックを再計算し、次にプレゼンテーションを保存またはレンダリングしてください。系列が計算されたセルを参照していれば、チャートは更新されたセルの値を使用します。このワークフローでは別途チャート更新メソッドは不要です。

**チャートは外部 Excel ワークブックを使用できますか？**

はい、チャート データは API を介して外部ワークブックを使用するよう構成できます。ただし、本記事で説明する数式計算ワークフローはチャート データ ワークブックと Aspose.Slides が評価できる数式サブセットに限定されています。[ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) が外部 XLSX ファイルの任意の数式を完全に再計算することは想定されていません。

**別シートや別ブックを参照する数式は使用できますか？**

チャート ワークブック内で Excel 形式の参照が存在することはありますが、評価はサポートされているパーサーと関数セットに制限されます。クロスシートまたは外部参照が必須の場合は、対象の Aspose.Slides バージョンで正確に動作するか検証してください。広範な Excel 参照互換性が必要なワークフローでは、ワークブックを外部で計算し、解決済みの値をチャート データに書き戻すことを推奨します。

**数式文字列は `=` で始める必要がありますか？**

Aspose.Slides の API 例では `B2-C2` や `SUM(B2:B5)` のように先頭の `=` を省略しています。この形式で数式を指定すると、ドキュメント化された API 例と一致します。