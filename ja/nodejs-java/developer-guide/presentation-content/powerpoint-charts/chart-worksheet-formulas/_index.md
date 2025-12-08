---
title: "チャート ワークシート数式"
type: docs
weight: 70
url: /ja/nodejs-java/chart-worksheet-formulas/
keywords: "PowerPoint 方程式, PowerPoint スプレッドシート数式"
description: "PowerPoint 方程式とスプレッドシート数式"
---

## **プレゼンテーションにおけるチャートスプレッドシート数式について**
**Chart spreadsheet**（または chart worksheet）は、プレゼンテーション内のチャートのデータ ソースです。Chart spreadsheet にはデータが含まれ、チャート上にグラフィカルに表現されます。PowerPoint でチャートを作成すると、このチャートに関連付けられたワークシートも自動的に作成されます。Chart worksheet は、折れ線グラフ、棒グラフ、サンバースト グラフ、円グラフなど、すべてのタイプのチャートに対して作成されます。PowerPoint で chart spreadsheet を表示するには、チャートをダブルクリックしてください：

![todo:image_alt_text](chart-worksheet-formulas_1.png)


Chart spreadsheet には、チャート要素の名前（カテゴリ名: *Category1*、系列名）と、これらのカテゴリおよび系列に対応する数値データの表が含まれます。デフォルトでは、新しいチャートを作成すると、chart spreadsheet のデータは既定のデータで設定されます。その後、ワークシート内のスプレッドシートデータを手動で変更できます。

通常、チャートは複雑なデータ（例: 財務アナリスト、科学アナリスト）を表し、他のセルの値や動的データから計算されたセルを含みます。セルの値を手動で計算しハードコーディングすると、将来的に変更が困難になります。特定のセルの値を変更すると、そのセルに依存するすべてのセルも更新が必要になります。さらに、表のデータが他の表のデータに依存することがあり、容易かつ柔軟に更新できる複雑なプレゼンテーション データ スキームが作成されます。

プレゼンテーションにおける **Chart spreadsheet formula** は、chart spreadsheet データを自動的に計算および更新する式です。スプレッドシート数式は、特定のセルまたはセルの集合のデータ計算ロジックを定義します。スプレッドシート数式は、セル参照、数学関数、論理演算子、算術演算子、変換関数、文字列定数などを使用する数式（数学式または論理式）です。数式の定義はセルに書き込まれ、そのセルは単純な値を保持しません。スプレッドシート数式は値を計算して返し、その値がセルに割り当てられます。プレゼンテーションの chart spreadsheet 数式は実質的に Excel の数式と同じで、同じ既定の関数、演算子、定数がサポートされています。

In [**Aspose.Slides**](https://products.aspose.com/slides/nodejs-java/) では、chart spreadsheet は [**ChartDataWorkbook**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataWorkbook) 型の [**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartData#getChartDataWorkbook--) メソッドで表されます。スプレッドシート数式は [**ChartDataCell.setFormula**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataCell#setFormula-java.lang.String-) メソッドで割り当ておよび変更できます。Aspose.Slides で数式に対してサポートされている機能は次のとおりです：
- 論理定数
- 数値定数
- 文字列定数
- エラー定数
- 算術演算子
- 比較演算子
- A1 形式のセル参照
- R1C1 形式のセル参照
- 事前定義関数

通常、スプレッドシートは最後に計算された数式の値を保存します。プレゼンテーションの読み込み後にチャートデータが変更されていない場合、[**ChartDataCell.getValue**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataCell#getValue--) メソッドは読み取り時にそれらの値を返します。但し、スプレッドシートデータが変更されている場合、**ChartDataCell.Value** プロパティを読み取ると、サポートされていない数式に対して [**CellUnsupportedDataException**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CellUnsupportedDataException) がスローされます。これは、数式が正常に解析されるとセルの依存関係が決定され、最後の値の正確性が保証されるためです。しかし、数式が解析できない場合、セル値の正確性は保証できません。

## **プレゼンテーションに Chart Spreadsheet Formula を追加する**
まず、[ShapeCollection.getShapes.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addChart-int-float-float-float-float-) メソッドを使用して、新しいプレゼンテーションの最初のスライドにチャートを追加します。チャートのワークシートは自動的に作成され、[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartData#getChartDataWorkbook--) メソッドでアクセスできます：
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 150, 150, 500, 300);
    var workbook = chart.getChartData().getChartDataWorkbook();
    // ...
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


**Object** 型のプロパティである [**ChartDataCell.setValue**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataCell#setValue-java.lang.Object-) を使用して、セルにいくつかの値を書き込みましょう。これにより、任意の値をプロパティに設定できます：
```javascript
workbook.getCell(0, "F2").setValue(-2.5);
workbook.getCell(0, "G3").setValue(6.3);
workbook.getCell(0, "H4").setValue(3);
```


セルに数式を書き込むには、[**ChartDataCell.setFormula**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataCell#setFormula-java.lang.String-) メソッドを使用できます：

*Note*: [**ChartDataCell.setFormula**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataCell#setFormula-java.lang.String-) メソッドは A1 形式のセル参照を設定するために使用されます。

[R1C1Formula](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataCell#getR1C1Formula--) セル参照を設定するには、[**ChartDataCell.setR1C1Formula**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ChartDataCell#setR1C1Formula-java.lang.String-) メソッドを使用できます：

それから、セル B2 と C2 の値を読み取ろうとすると、計算された結果が得られます：
```javascript
var value1 = cell1.getValue();// 7.8
var value2 = cell2.getValue();// 2.1
```


## **論理定数**
セル数式では *FALSE* と *TRUE* のような論理定数を使用できます：
```javascript
workbook.getCell(0, "A2").setValue(false);
var cell = workbook.getCell(0, "B2");
cell.setFormula("A2 = TRUE");
var value = cell.getValue();// 値はブール値 "false" を含みます
```


## **数値定数**
数値は通常表記または指数表記で使用でき、chart spreadsheet 数式を作成できます：
```javascript
workbook.getCell(0, "A2").setFormula("1 + 0.5");
workbook.getCell(0, "B2").setFormula(".3 * 1E-2");
```


## **文字列定数**
文字列（リテラル）定数は、そのまま使用され変更されない特定の値です。文字列定数は、日付、テキスト、数値などがあります：
```javascript
workbook.getCell(0, "A2").setFormula("\"abc\"");
workbook.getCell(0, "B2").setFormula("\"2/3/2020 12:00\"");
```


## **エラー定数**
場合によっては、数式で結果を計算できません。その場合、セルには値の代わりにエラーコードが表示されます。各エラータイプには固有のコードがあります：

- #DIV/0! - 数式がゼロで除算しようとしています。
- #GETTING_DATA - 値がまだ計算中のセルに表示されることがあります。
- #N/A - 情報が欠落しているか利用できません。理由としては、数式で使用されているセルが空、余分なスペース文字、スペルミスなどが考えられます。
- #NAME? - 特定のセルまたは他の数式オブジェクトが名前で見つかりません。
- #NULL! - 数式に誤りがある場合に発生します。例: (,) やコロン (:) の代わりにスペース文字を使用した場合など。
- #NUM! - 数式内の数値が無効、長すぎる、または小さすぎるなどの場合です。
- #REF! - 無効なセル参照です。
- #VALUE! - 予期しない値の型です。例として、文字列が数値セルに設定された場合です。
```javascript
var cell = workbook.getCell(0, "A2");
cell.setFormula("2 / 0");
var value = cell.getValue();// 値は文字列 "#DIV/0!" を含みます
```


## **算術演算子**
チャートワークシートの数式では、すべての算術演算子を使用できます：

|**演算子**|**意味**|**例**|
| :- | :- | :- |
|+ (プラス記号)|加算または単項プラス|2 + 3|
|- (マイナス記号)|減算または否定|2 - 3<br>-3|
|* (アスタリスク)|掛け算|2 * 3|
|/ (スラッシュ)|除算|2 / 3|
|% (パーセント記号)|パーセンテージ|30%|
|^ (キャレット)|累乗|2 ^ 3|

*Note*: 計算順序を変更するには、先に計算したい部分を括弧で囲んでください。

## **比較演算子**
比較演算子を使用してセルの値を比較できます。これらの演算子で 2 つの値を比較すると、結果は *TRUE* または *FALSE* の論理値になります：

|**演算子**|**意味**|**意味**|
| :- | :- | :- |
|= (等号)|等しい|A2 = 3|
|<> (不等号)|等しくない|A2 <> 3|
|> (大なり記号)|より大きい|A2 > 3|
|>= (大なりイコール記号)|大きいまたは等しい|A2 >= 3|
|< (小なり記号)|より小さい|A2 < 3|
|<= (小なりイコール記号)|小さいまたは等しい|A2 <= 3|

## **A1 形式のセル参照**
**A1 形式のセル参照** は、列が文字（例: "*A*")で、行が数字（例: "*1*")で識別されるワークシートで使用されます。A1 形式のセル参照は次のように使用できます：

|**セル参照**|**例**|||
| :- | :- | :- | :- |
||絶対参照|相対参照|混合参照|
|Cell|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Row|$2:$2|2:2|-|
|Column|$A:$A|A:A|-|
|Range|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C$4</p>|

以下は、A1 形式のセル参照を数式で使用する例です：
```javascript
workbook.getCell(0, "A2").setFormula("C3 + SUM(F2:H5)");
```


## **R1C1 形式のセル参照**
**R1C1 形式のセル参照** は、行と列の両方が数値識別子であるワークシートで使用されます。R1C1 形式のセル参照は次のように使用できます：

|**セル参照**|**例**|||
| :- | :- | :- | :- |
||絶対参照|相対参照|混合参照|
|Cell|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Row|R2|R[2]|-|
|Column|C3|C[3]|-|
|Range|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

以下は、R1C1 形式のセル参照を数式で使用する例です：
```javascript
workbook.getCell(0, "A2").setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");
```


## **事前定義関数**
数式で使用でき、実装を簡素化する事前定義関数があります。これらの関数は、以下のような最も一般的に使用される操作をカプセル化しています：

- ABS
- AVERAGE
- CEILING
- CHOOSE
- CONCAT
- CONCATENATE
- DATE (1900 date system)
- DAYS
- FIND
- FINDB
- IF
- INDEX (reference form)
- LOOKUP (vector form)
- MATCH (vector form)
- MAX
- SUM
- VLOOKUP

## **FAQ**

**外部の Excel ファイルを数式付きチャートのデータ ソースとして使用できますか？**

はい。Aspose.Slides は外部ブックを [チャートのデータ ソース](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatasourcetype/) としてサポートしており、プレゼンテーション外部の XLSX から数式を使用できます。

**チャート数式は、同じブック内のシート名でシートを参照できますか？**

はい。数式は標準的な Excel 参照モデルに従うため、同じブック内の他のシートや外部ブックを参照できます。外部参照の場合は、Excel の構文でパスとブック名を含めます。