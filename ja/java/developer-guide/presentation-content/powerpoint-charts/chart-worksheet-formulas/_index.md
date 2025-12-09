---
title: Java を使用してプレゼンテーションでチャート ワークシート数式を適用する
linktitle: ワークシート数式
type: docs
weight: 70
url: /ja/java/chart-worksheet-formulas/
keywords:
- チャート スプレッドシート
- チャート ワークシート
- チャート 数式
- ワークシート 数式
- スプレッドシート 数式
- データ ソース
- 論理定数
- 数値定数
- 文字列定数
- エラー定数
- 算術定数
- 比較演算子
- A1 スタイル
- R1C1 スタイル
- 事前定義関数
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: Aspose.Slides for Java のチャート ワークシートで Excel スタイルの数式を適用し、PPT および PPTX ファイル全体のレポートを自動化します。
---

## **プレゼンテーションにおけるチャートスプレッドシート数式について**
**Chart spreadsheet**（または chart worksheet）は、プレゼンテーション内のチャートのデータ ソースです。Chart spreadsheet には、チャート上にグラフィックで表されるデータが含まれます。PowerPoint でチャートを作成すると、そのチャートに関連付けられたワークシートも自動的に作成されます。Chart worksheet は、折れ線グラフ、棒グラフ、サンバースト グラフ、円グラフなど、すべてのチャートタイプに対して作成されます。PowerPoint で chart spreadsheet を表示するには、チャートをダブルクリックします：

![todo:image_alt_text](chart-worksheet-formulas_1.png)

Chart spreadsheet には、チャート要素の名前（カテゴリ名: *Category1*、シリーズ名）と、これらのカテゴリとシリーズに対応する数値データの表が含まれています。既定では、新しいチャートを作成すると、chart spreadsheet のデータはデフォルト データで設定されます。その後、ワークシート内のスプレッドシート データを手動で変更できます。

通常、チャートは複雑なデータ（例: 財務アナリスト、科学アナリスト）を表し、他のセルの値や動的データから計算されたセルを持ちます。セルの値を手動で計算してハードコードすると、将来的に変更が困難になります。特定のセルの値を変更すると、そのセルに依存するすべてのセルも更新が必要です。さらに、表データは他の表のデータに依存することがあり、簡単かつ柔軟に更新できる複雑なプレゼンテーション データ スキーマを作成します。

**Chart spreadsheet formula**（チャート スプレッドシート数式）は、チャート スプレッドシート データを自動的に計算および更新する式です。Spreadsheet formula は、特定のセルまたはセルの集合のデータ計算ロジックを定義します。Spreadsheet formula は、数式または論理式であり、セル参照、数学関数、論理演算子、算術演算子、変換関数、文字列定数などを使用します。式の定義はセルに記述され、そのセルは単純な値を含みません。Spreadsheet formula は値を計算して返し、その値がセルに割り当てられます。プレゼンテーションの chart spreadsheet formula は実際には Excel の数式と同じで、同じ既定の関数、演算子、定数がサポートされています。

In [**Aspose.Slides**](https://products.aspose.com/slides/java/) chart spreadsheet is represented with 
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartData#getChartDataWorkbook--) メソッド（[**IChartDataWorkbook**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook) 型）で表されます。 
Spreadsheet formula は、[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) メソッドで割り当ておよび変更できます。 
Aspose.Slides が数式でサポートする機能は次のとおりです:

- 論理定数
- 数値定数
- 文字列定数
- エラー定数
- 算術演算子
- 比較演算子
- A1 形式セル参照
- R1C1 形式セル参照
- 事前定義関数

Typically、スプレッドシートは最後に計算された数式の値を保存します。プレゼンテーションの読み込み後にチャート データが変更されていない場合、[**IChartDataCell.getValue**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#getValue--) メソッドは読み取り時にそれらの値を返します。 しかし、スプレッドシート データが変更されている場合、**ChartDataCell.Value** プロパティを読み取ると、サポートされていない数式に対して [**CellUnsupportedDataException**](https://reference.aspose.com/slides/java/com.aspose.slides/CellUnsupportedDataException) がスローされます。 これは、数式が正常に解析されるとセルの依存関係が決定され、最後の値の正確性が判断されるためです。 しかし、数式が解析できない場合、セル値の正確性は保証できません。

## **プレゼンテーションにチャート スプレッドシート数式を追加する**
まず、新しいプレゼンテーションの最初のスライドに [IShapeCollection.getShapes.addChart](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addChart-int-float-float-float-float-) を使用してチャートを追加します。 チャートのワークシートは自動的に作成され、次のメソッドでアクセスできます [**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartData#getChartDataWorkbook--)： ```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 150, 150, 500, 300);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    // ...
} finally {
    if (pres != null) pres.dispose();
}
```


セルに値を書き込むには、**Object** 型の [**IChartDataCell.setValue**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#setValue-java.lang.Object-) プロパティを使用します。これにより、任意の値を設定できます： ```java
workbook.getCell(0, "F2").setValue(-2.5);

workbook.getCell(0, "G3").setValue(6.3);

workbook.getCell(0, "H4").setValue(3);
```


次に、セルに数式を書き込むには、[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) メソッドを使用できます：

*注*: [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) メソッドは A1 形式セル参照を設定するために使用されます。

[R1C1Formula](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#getR1C1Formula--) のセル参照を設定するには、[**IChartDataCell.setR1C1Formula**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#setR1C1Formula-java.lang.String-) メソッドを使用できます：

次に、セル B2 と C2 の値を読み取ろうとすると、計算された結果が得られます： ```java
Object value1 = cell1.getValue(); // 7.8

Object value2 = cell2.getValue(); // 2.1
```


## **論理定数**
セル数式では、*FALSE* や *TRUE* などの論理定数を使用できます： ```java
workbook.getCell(0, "A2").setValue(false);
IChartDataCell cell = workbook.getCell(0, "B2");
cell.setFormula("A2 = TRUE");
Object value = cell.getValue(); // 値にはブール値 "false" が含まれています
```


## **数値定数**
数値は、通常表記または科学的表記で使用でき、チャート スプレッドシート数式を作成できます： ```java
workbook.getCell(0, "A2").setFormula("1 + 0.5");
workbook.getCell(0, "B2").setFormula(".3 * 1E-2");
```


## **文字列定数**
文字列（リテラル）定数は、そのまま使用され変更されない特定の値です。文字列定数には、日付、テキスト、数値などがあります： ```java
workbook.getCell(0, "A2").setFormula("\"abc\"");
workbook.getCell(0, "B2").setFormula("\"2/3/2020 12:00\"");
```


## **エラー定数**
時々、数式で結果を計算できないことがあります。その場合、セルに値の代わりにエラーコードが表示されます。各エラータイプには固有のコードがあります：

- #DIV/0! - 数式がゼロで除算しようとした。
- #GETTING_DATA - 値がまだ計算中であるセルに表示されることがある。
- #N/A - 情報が欠落している、または利用できない。原因としては、数式で使用されるセルが空、余分な空白文字、綴り間違いなど。
- #NAME? - 指定されたセルや他の数式オブジェクトが名前で見つからない。
- #NULL! - 数式に誤りがあり、例えば (,) やコロン (:) の代わりに空白文字が使用された場合に表示される。
- #NUM! - 数式内の数値が無効、長すぎる、短すぎるなど。
- #REF! - 無効なセル参照。
- #VALUE! - 想定外の値の種類。例えば、文字列値が数値セルに設定された場合。

```java
IChartDataCell cell = workbook.getCell(0, "A2");
cell.setFormula("2 / 0");
Object value = cell.getValue(); // 値には文字列 "#DIV/0!" が含まれています
```


## **算術演算子**
チャート ワークシートの数式では、すべての算術演算子を使用できます：

|**Operator**|**意味**|**例**|
| :- | :- | :- |
|+ (plus sign)|加算または単項プラス|2 + 3|
|- (minus sign)|減算または符号反転|2 - 3<br>-3|
|* (asterisk)|乗算|2 * 3|
|/ (forward slash)|除算|2 / 3|
|% (percent sign)|パーセント|30%|
|^ (caret)|指数|2 ^ 3|

*注*: 評価順序を変更するには、先に計算したい部分を丸括弧で囲みます。

## **比較演算子**
比較演算子を使用してセルの値を比較できます。これらの演算子で 2 つの値を比較すると、結果は *TRUE* または FALSE の論理値になります：

|**Operator**|**意味**|**例**|
| :- | :- | :- |
|= (equal sign)|等しい|A2 = 3|
|<> (not equal sign)|等しくない|A2 <> 3|
|> (greater than sign)|より大きい|A2 > 3|
|>= (greater than or equal to sign)|以上|A2 >= 3|
|< (less than sign)|未満|A2 < 3|
|<= (less than or equal to sign)|以下|A2 <= 3|

## **A1 形式セル参照**
**A1 形式セル参照** は、列が文字識別子（例: "*A*"）で行が数字識別子（例: "*1*"）であるワークシートで使用されます。A1 形式セル参照は次のように使用できます：

|**セル参照**|**例**|||
| :- | :- | :- | :- |
||絶対参照|相対参照|混合参照|
|セル|$A$2|A2|<p>A$2</p><p>$A2</p>|
|行|$2:$2|2:2|-|
|列|$A:$A|A:A|-|
|範囲|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

以下は、数式で A1 形式セル参照を使用する例です：
```java
workbook.getCell(0, "A2").setFormula("C3 + SUM(F2:H5)");
```


## **R1C1 形式セル参照**
**R1C1 形式セル参照** は、行と列の両方が数字識別子を持つワークシートで使用されます。R1C1 形式セル参照は次のように使用できます：

|**セル参照**|**例**|||
| :- | :- | :- | :- |
||絶対参照|相対参照|混合参照|
|セル|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|行|R2|R[2]|-|
|列|C3|C[3]|-|
|範囲|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

以下は、数式で R1C1 形式セル参照を使用する例です：
```java
workbook.getCell(0, "A2").setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");
```


## **事前定義関数**
数式で使用して実装を簡素化できる事前定義関数があります。これらの関数は、次のような最も一般的に使用される操作をカプセル化します：

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
**外部の Excel ファイルを数式付きチャートのデータ ソースとしてサポートしていますか？**

はい。Aspose.Slides は、外部ブックを [チャートのデータ ソース](https://reference.aspose.com/slides/java/com.aspose.slides/chartdatasourcetype/) としてサポートしており、プレゼンテーション外部の XLSX から数式を使用できます。

**同じブック内のシート名でチャート数式がシートを参照できますか？**

はい。数式は標準的な Excel の参照モデルに従うため、同じブック内または外部ブックの他のシートを参照できます。外部参照の場合は、Excel の構文でパスとブック名を含めます。