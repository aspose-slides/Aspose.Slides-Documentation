---
title: Android でのプレゼンテーションにおけるチャート ワークシート数式の適用
linktitle: ワークシート数式
type: docs
weight: 70
url: /ja/androidjava/chart-worksheet-formulas/
keywords:
- チャート スプレッドシート
- チャート ワークシート
- チャート 数式
- ワークシート 数式
- スプレッドシート 数式
- データ ソース
- 論理 定数
- 数値 定数
- 文字列 定数
- エラー 定数
- 算術 定数
- 比較 演算子
- A1 スタイル
- R1C1 スタイル
- 事前定義 関数
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Android 用 Aspose.Slides で、Java のチャートワークシートを使用して Excel スタイルの数式を適用し、PPT および PPTX ファイル全体でレポートを自動化します。"
---

## **プレゼンテーションのチャートスプレッドシート数式について**
**Chart spreadsheet** (または chart worksheet) はプレゼンテーション内のチャートのデータ ソースです。Chart spreadsheet にはデータが含まれ、チャート上でグラフィックとして表現されます。PowerPoint でチャートを作成すると、このチャートに関連付けられたワークシートが自動的に作成されます。Chart worksheet はすべてのチャートタイプ（折れ線グラフ、棒グラフ、サンバースト グラフ、円グラフなど）に対して作成されます。PowerPoint でチャートスプレッドシートを表示するには、チャートをダブルクリックしてください：

![todo:image_alt_text](chart-worksheet-formulas_1.png)

Chart spreadsheet にはチャート要素の名前（カテゴリ名: *Category1*、シリーズ名）と、これらのカテゴリおよびシリーズに対応する数値データの表が含まれます。既定では、新しいチャートを作成するとチャートスプレッドシートのデータはデフォルトデータで設定されます。その後、ワークシート上で手動でスプレッドシート データを変更できます。

通常、チャートは複雑なデータ（例: 金融アナリスト、科学アナリスト）を表し、他のセルの値や動的データから計算されたセルを含みます。セルの値を手動で計算してハードコーディングすると、将来的に変更が困難になります。特定のセルの値を変更すると、それに依存するすべてのセルも更新が必要になります。さらに、表データが他の表のデータに依存することがあり、簡単かつ柔軟に更新できるプレゼンテーション データ構成が求められます。

**Chart spreadsheet formula** は、チャートスプレッドシート データを自動的に計算・更新する式です。スプレッドシート数式は、特定のセルまたはセルの集合のデータ計算ロジックを定義します。スプレッドシート数式は、セル参照、数式関数、論理演算子、算術演算子、変換関数、文字列定数などを使用する数式または論理式です。数式の定義はセルに書き込まれ、そのセルは単純な値を保持しません。スプレッドシート数式は値を計算して返し、その値がセルに割り当てられます。プレゼンテーション内のチャートスプレッドシート数式は実際には Excel 数式と同じで、同じデフォルト関数、演算子、定数がサポートされています。

[**Aspose.Slides**](https://products.aspose.com/slides/androidjava/) のチャートスプレッドシートは
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartData#getChartDataWorkbook--) メソッドの
[**IChartDataWorkbook**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataWorkbook) 型で表されます。
スプレッドシート数式は
[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) メソッドで割り当ておよび変更できます。
Aspose.Slides で数式に対してサポートされている機能は次のとおりです。

- 論理定数
- 数値定数
- 文字列定数
- エラー定数
- 算術演算子
- 比較演算子
- A1 形式のセル参照
- R1C1 形式のセル参照
- 事前定義関数

通常、スプレッドシートは最後に計算された数式の値を保存します。プレゼンテーションの読み込み後にチャート データが変更されていなければ、[**IChartDataCell.getValue**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataCell#getValue--) メソッドは読取り時にそれらの値を返します。しかし、スプレッドシート データが変更されている場合、**ChartDataCell.Value** プロパティを読むと、サポートされていない数式に対して [**CellUnsupportedDataException**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CellUnsupportedDataException) がスローされます。これは、数式が正常に解析されたときにセル依存関係が決定され、最後の値の正確性が確認されるためです。数式が解析できない場合、セルの値の正確性は保証できません。

## **プレゼンテーションにチャートスプレッドシート数式を追加する**
最初に、[IShapeCollection.getShapes.addChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addChart-int-float-float-float-float-) を使用して新しいプレゼンテーションの最初のスライドにチャートを追加します。チャートのワークシートは自動的に作成され、次のメソッドでアクセスできます。
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartData#getChartDataWorkbook--) 方法:
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 150, 150, 500, 300);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    // ...
} finally {
    if (pres != null) pres.dispose();
}
```


セルに値を書き込むには、**Object** 型の
[**IChartDataCell.setValue**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataCell#setValue-java.lang.Object-) プロパティを使用します。これにより任意の値を設定できます:
```java
workbook.getCell(0, "F2").setValue(-2.5);

workbook.getCell(0, "G3").setValue(6.3);

workbook.getCell(0, "H4").setValue(3);
```


数式を書き込むには、[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) メソッドを使用します。

*Note*: [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) メソッドは A1 形式のセル参照を設定するために使用されます。

R1C1 形式のセル参照を設定するには、[**IChartDataCell.setR1C1Formula**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataCell#setR1C1Formula-java.lang.String-) メソッドを使用します。

その後、セル B2 と C2 の値を読み取ろうとすると、計算された結果が得られます:
```java
Object value1 = cell1.getValue(); // 7.8

Object value2 = cell2.getValue(); // 2.1
```


## **論理定数**
セル数式で *FALSE* や *TRUE* といった論理定数を使用できます:
```java
workbook.getCell(0, "A2").setValue(false);
IChartDataCell cell = workbook.getCell(0, "B2");
cell.setFormula("A2 = TRUE");
Object value = cell.getValue(); // 値にはブール値 "false" が含まれています
```


## **数値定数**
数式で共通表記または科学的表記の数値を使用できます:
```java
workbook.getCell(0, "A2").setFormula("1 + 0.5");
workbook.getCell(0, "B2").setFormula(".3 * 1E-2");
```


## **文字列定数**
文字列（リテラル）定数はそのまま使用され、変更されません。文字列定数には日付、テキスト、数値などがあります:
```java
workbook.getCell(0, "A2").setFormula("\"abc\"");
workbook.getCell(0, "B2").setFormula("\"2/3/2020 12:00\"");
```


## **エラー定数**
数式で結果を計算できない場合、セルにはエラーコードが表示されます。各エラータイプには固有のコードがあります。

- #DIV/0! - 0 で除算しようとした場合。
- #GETTING_DATA - セルの値がまだ計算中の場合に表示されることがあります。
- #N/A - 情報が欠落または利用できません。原因例: 参照セルが空、余分なスペース文字、スペルミスなど。
- #NAME? - セルや数式オブジェクトが名前で見つからない場合。
- #NULL! - 数式に誤りがある場合（例: (,) やコロン (:) の代わりにスペース文字が使用された）。
- #NUM! - 数式内の数値が無効、長すぎる、または小さすぎる場合。
- #REF! - 無効なセル参照。
- #VALUE! - 予期しない型の値。例: 文字列を数値セルに設定した場合。
```java
IChartDataCell cell = workbook.getCell(0, "A2");
cell.setFormula("2 / 0");
Object value = cell.getValue(); // 値には文字列「#DIV/0!」が含まれています
```


## **算術演算子**
チャートワークシート数式で使用できるすべての算術演算子:

|**演算子**|**意味**|**例**|
| :- | :- | :- |
|+ (プラス)|加算または単項プラス|2 + 3|
|- (マイナス)|減算または符号反転|2 - 3<br>-3|
|* (アスタリスク)|乗算|2 * 3|
|/ (スラッシュ)|除算|2 / 3|
|% (パーセント)|パーセント|30%|
|^ (キャレット)|べき乗|2 ^ 3|

*Note*: 計算順序を変更するには、先に計算したい部分を丸括弧で囲みます。

## **比較演算子**
比較演算子を使用してセルの値を比較できます。これらの演算子で比較された結果は、*TRUE* または FALSE の論理値になります。

|**演算子**|**意味**|**例**|
| :- | :- | :- |
|= (イコール)|等しい|A2 = 3|
|<> (非等号)|等しくない|A2 <> 3|
|> (大なり)|より大きい|A2 > 3|
|>= (大なりイコール)|以上|A2 >= 3|
|< (小なり)|より小さい|A2 < 3|
|<= (小なりイコール)|以下|A2 <= 3|

## **A1 形式のセル参照**
**A1 形式のセル参照**は、列が文字識別子（例: *A*）で行が数値識別子（例: *1*）のワークシートで使用されます。A1 形式のセル参照は次のように使用できます:

|**セル参照**|**例**|||
| :- | :- | :- | :- |
||絶対参照|相対参照|混合参照|
|セル|$A$2|A2|<p>A$2</p><p>$A2</p>|
|行|$2:$2|2:2|‑|
|列|$A:$A|A:A|‑|
|範囲|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

以下は A1 形式のセル参照を数式で使用する例です:
```java
workbook.getCell(0, "A2").setFormula("C3 + SUM(F2:H5)");
```


## **R1C1 形式のセル参照**
**R1C1 形式のセル参照**は、行と列の両方が数値識別子となっているワークシートで使用されます。R1C1 形式のセル参照は次のように使用できます:

|**セル参照**|**例**|||
| :- | :- | :- | :- |
||絶対参照|相対参照|混合参照|
|セル|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|行|R2|R[2]|‑|
|列|C3|C[3]|‑|
|範囲|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|
以下は R1C1 形式のセル参照を数式で使用する例です:
```java
workbook.getCell(0, "A2").setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");
```


## **事前定義関数**
数式で使用できる事前定義関数があります。これらの関数は一般的に使用される操作をカプセル化します。例:

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

**数式付きチャートのデータ ソースとして外部 Excel ファイルはサポートされていますか？**

はい。Aspose.Slides は外部ブックを [chart's data source](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdatasourcetype/) としてサポートしており、プレゼンテーション外の XLSX から数式を使用できます。

**チャート数式は同じブック内のシート名でシートを参照できますか？**

はい。数式は標準的な Excel 参照モデルに従うため、同じブック内または外部ブックの他シートを参照できます。外部参照の場合は、Excel の構文でパスとブック名を含めます。