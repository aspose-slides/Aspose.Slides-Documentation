---
title: チャートワークシートの数式
type: docs
weight: 70
url: /java/chart-worksheet-formulas/
keywords: "パワーポイントの方程式, パワーポイントのスプレッドシートの数式"
description: "パワーポイントの方程式とスプレッドシートの数式"
---


## **プレゼンテーションにおけるチャートスプレッドシートの数式について**
**チャートスプレッドシート**（またはチャートワークシート）は、プレゼンテーションにおけるチャートのデータソースです。チャートスプレッドシートには、チャートにグラフィックな方法で表示されるデータが含まれています。 PowerPointでチャートを作成すると、このチャートに関連するワークシートも自動的に作成されます。チャートワークシートは、折れ線グラフ、棒グラフ、サンバーストグラフ、円グラフなど、すべての種類のチャートに対して作成されます。 PowerPointでチャートスプレッドシートを表示するには、チャートをダブルクリックする必要があります：

![todo:image_alt_text](chart-worksheet-formulas_1.png)


チャートスプレッドシートには、チャート要素の名前（カテゴリ名：*Category1*、系列名）と、これらのカテゴリや系列に適した数値データを含むテーブルが含まれています。デフォルトでは、新しいチャートを作成すると、チャートスプレッドシートのデータはデフォルトデータで設定されます。次に、ワークシート内のスプレッドシートデータを手動で変更できます。

通常、チャートは複雑なデータ（例えば、財務分析者や科学分析者）を表し、他のセルの値から計算されたセルや他の動的データから計算されたセルを持っています。セルの値を手動で計算してそのセルにハードコーディングすると、将来的に変更が難しくなります。特定のセルの値を変更すると、それに依存するすべてのセルも更新する必要があります。さらに、テーブルデータは他のテーブルのデータに依存する場合があり、簡単かつ柔軟に更新できる複雑なプレゼンテーションデータスキームを作成します。

**プレゼンテーション内のチャートスプレッドシートの数式**は、チャートスプレッドシートデータを自動的に計算して更新するための式です。スプレッドシートの数式は、特定のセルまたはセルのセットのためのデータ計算ロジックを定義します。スプレッドシートの数式は、セル参照、数値関数、論理演算子、算術演算子、変換関数、文字列定数などを使用する数学的または論理的な数式です。数式の定義はセルに書き込まれ、このセルには単純な値が含まれません。スプレッドシートの数式は値を計算し、それを返し、その後この値がセルに割り当てられます。プレゼンテーション内のチャートスプレッドシートの数式は、実際にExcelの数式と同じであり、それに対して同じデフォルトの関数、演算子、定数がサポートされています。

[**Aspose.Slides**](https://products.aspose.com/slides/java/)内のチャートスプレッドシートは、
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartData#getChartDataWorkbook--)メソッドを使用して
[**IChartDataWorkbook**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataWorkbook)タイプで表されます。
スプレッドシートの数式は
[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-)メソッドを使用して割り当ておよび変更できます。
Aspose.Slidesで数式に対してサポートされている機能は以下の通りです：

- 論理定数
- 数値定数
- 文字列定数
- エラー定数
- 算術演算子
- 比較演算子
- A1スタイルのセル参照
- R1C1スタイルのセル参照
- 予め定義された関数


通常、スプレッドシートは最終的に計算された数式の値を保存します。プレゼンテーションの読み込み後、チャートデータが変更されていない場合は、[**IChartDataCell.getValue**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#getValue--)メソッドは、読み込み時にそれらの値を返します。しかし、スプレッドシートのデータが変更されている場合、**ChartDataCell.Value**プロパティを読み込むと、サポートされていない数式に対して[**CellUnsupportedDataException**](https://reference.aspose.com/slides/java/com.aspose.slides/CellUnsupportedDataException)がスローされます。これは、数式が正常に解析されると、セルの依存関係が決定され、最終値の正確性が決定されるためです。しかし、数式が解析できない場合は、セルの値の正確性を保証できません。

## **プレゼンテーションにチャートスプレッドシートの数式を追加する**
まず、[IShapeCollection.getShapes.addChart](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addChart-int-float-float-float-float-)メソッドを使用して、新しいプレゼンテーションの最初のスライドにチャートを追加します。
チャートのワークシートは自動的に作成され、[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartData#getChartDataWorkbook--)メソッドを使用してアクセスできます：



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

次に、**Object**型の[**IChartDataCell.setValue**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#setValue-java.lang.Object-)プロパティを使用して、セルに値を設定します。このプロパティに任意の値を設定できます：

```java
workbook.getCell(0, "F2").setValue(-2.5);

workbook.getCell(0, "G3").setValue(6.3);

workbook.getCell(0, "H4").setValue(3);
```

次に、セルに数式を書くには、[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-)メソッドを使用できます：

*注*: [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-)メソッドはA1スタイルのセル参照を設定するために使用されます。

[R1C1Formula](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#getR1C1Formula--)セル参照を設定するには、[**IChartDataCell.setR1C1Formula**](https://reference.aspose.com/slides/java/com.aspose.slides/IChartDataCell#setR1C1Formula-java.lang.String-)メソッドを使用できます：

その後、B2およびC2のセルから値を読み取ろうとすると、それらは計算されます：

```java
Object value1 = cell1.getValue(); // 7.8

Object value2 = cell2.getValue(); // 2.1
```

## **論理定数**
セルの数式に*FALSE*や*TRUE*のような論理定数を使用できます：

```java
workbook.getCell(0, "A2").setValue(false);
IChartDataCell cell = workbook.getCell(0, "B2");
cell.setFormula("A2 = TRUE");
Object value = cell.getValue(); // 値にはブール値 "false" が含まれます
```

## **数値定数**
数値は、一般的または科学的な表記でチャートスプレッドシートの数式を作成するために使用できます：

```java
workbook.getCell(0, "A2").setFormula("1 + 0.5");
workbook.getCell(0, "B2").setFormula(".3 * 1E-2");
```

## **文字列定数**
文字列（またはリテラル）定数は、そのまま使用され変わらない特定の値です。文字列定数には、日付、テキスト、数値などが含まれる場合があります：

```java
workbook.getCell(0, "A2").setFormula("\"abc\"");
workbook.getCell(0, "B2").setFormula("\"2/3/2020 12:00\"");
```

## **エラー定数**
場合によっては、数式によって結果を計算することができないことがあります。その場合、セルにはその値の代わりにエラーコードが表示されます。各エラータイプには特定のコードがあります：

- #DIV/0! - 数式がゼロで割ろうとしています。
- #GETTING_DATA - 値がまだ計算中の場合にセルに表示されることがあります。
- #N/A - 情報が欠落しているか、利用できません。理由には、数式で使用されるセルが空である、余分なスペース文字がある、スペルミスがあるなどがあります。
- #NAME? - 特定のセルや他の数式オブジェクトがその名前で見つかりません。
- #NULL! - 数式の中に：(,)を使ったりコロン（:）の代わりにスペース文字が使われているなど、誤りがあった場合に表示されることがあります。
- #NUM! - 数式内の数値が無効、長すぎる、または小さすぎるなどの理由によるものです。
- #REF! - 無効なセル参照。
- #VALUE! - 予期しない値の型。たとえば、数値セルに文字列値を設定するといった場合です。

```java
IChartDataCell cell = workbook.getCell(0, "A2");
cell.setFormula("2 / 0");
Object value = cell.getValue(); // 値には文字列 "#DIV/0!" が含まれます
```

## **算術演算子**
チャートワークシートの数式には、すべての算術演算子を使用できます：

|**演算子** |**意味** |**例**|
| :- | :- | :- |
|+ (プラス記号) |加算または単項プラス|2 + 3|
|- (マイナス記号) |減算または否定|2 - 3<br>-3|
|* (アスタリスク)|乗算|2 * 3|
|/ (スラッシュ)|除算|2 / 3|
|% (パーセント記号) |パーセント|30%|
|^ (キャレット) |べき乗|2 ^ 3|

*注*: 評価の順序を変更するには、最初に計算される数式の部分をかっこで囲みます。

## **比較演算子**
比較演算子を使用してセルの値を比較できます。これらの演算子を使用して二つの値を比較するとき、結果は論理値である*TRUE*またはFALSEになります：

|**演算子** |**意味** |**説明** |
| :- | :- | :- |
|= (等号) |等しい |A2 = 3|
|<> (不等号) |等しくない|A2 <> 3|
|> (大なり) |より大きい|A2 > 3|
|>= (以上) |より大きいか等しい|A2 >= 3|
|< (小なり)|より小さい|A2 < 3|
|<= (以下)|より小さいか等しい|A2 <= 3|

## **A1スタイルのセル参照**
**A1スタイルのセル参照**は、列に文字の識別子（例えば、"*A*") と、行に数値の識別子（例えば、"*1*"）があるワークシートで使用されます。A1スタイルのセル参照は以下の方法で使用できます：

|**セル参照**|**例**|||
| :- | :- | :- | :- |
||絶対 |相対 |混合|
|セル |$A$2 |A2|<p>A$2</p><p>$A2</p>|
|行 |$2:$2 |2:2 |-|
|列 |$A:$A |A:A |-|
|範囲 |$A$2:$C$4 |A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


数式でA1スタイルのセル参照を使用する例です：

```java
workbook.getCell(0, "A2").setFormula("C3 + SUM(F2:H5)");
```

## **R1C1スタイルのセル参照**
**R1C1スタイルのセル参照**は、両方の行と列に数値の識別子があるワークシートで使用されます。R1C1スタイルのセル参照は以下の方法で使用できます：

|**セル参照**|**例**|||
| :- | :- | :- | :- |
||絶対 |相対 |混合|
|セル |R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|行 |R2|R[2]|-|
|列 |C3|C[3]|-|
|範囲 |R2C3:R5C7|R[2]C[3]:R[5]C[7] |R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


数式でR1C1スタイルのセル参照を使用する例です：

```java
workbook.getCell(0, "A2").setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");
```

## **予め定義された関数**
数式を簡単に実装するために使用できる予め定義された関数がいくつかあります。これらの関数は、次のような一般的に使用される操作をカプセル化します：

- ABS
- AVERAGE
- CEILING
- CHOOSE
- CONCAT
- CONCATENATE
- DATE (1900年日付システム)
- DAYS
- FIND
- FINDB
- IF
- INDEX (参照形式)
- LOOKUP (ベクトル形式)
- MATCH (ベクトル形式)
- MAX
- SUM
- VLOOKUP