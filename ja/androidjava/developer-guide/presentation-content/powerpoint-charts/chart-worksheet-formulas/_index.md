---
title: チャート ワークシートの数式
type: docs
weight: 70
url: /androidjava/chart-worksheet-formulas/
keywords: "パワーポイントの数式, パワーポイントのスプレッドシートの数式"
description: "PowerPointの数式とスプレッドシートの数式"
---

## **プレゼンテーションにおけるチャート スプレッドシート 数式について**
**チャート スプレッドシート**（またはチャート ワークシート）は、プレゼンテーションにおけるチャートのデータソースです。チャート スプレッドシートには、グラフィック的に表示されるデータが含まれています。PowerPointでチャートを作成すると、このチャートに関連付けられたワークシートも自動的に作成されます。チャート ワークシートは、すべての種類のチャート（折れ線グラフ、棒グラフ、サンバーストチャート、円グラフなど）に作成されます。PowerPointでチャート スプレッドシートを表示するには、チャートをダブルクリックします。

![todo:image_alt_text](chart-worksheet-formulas_1.png)

チャート スプレッドシートには、チャート要素の名前（カテゴリ名：*Category1*、シリーズ名）と、これらのカテゴリおよびシリーズに適した数値データのテーブルが含まれています。デフォルトでは、新しいチャートを作成すると、チャート スプレッドシートのデータはデフォルトデータで設定されます。その後、ワークシート内のスプレッドシートデータを手動で変更することができます。

通常、チャートは複雑なデータ（たとえば、財務アナリストや科学アナリスト）を表し、他のセルの値や他の動的データから計算されたセルを持っています。セルの値を手動で計算し、セルにハードコーディングすると、将来変更が難しくなります。特定のセルの値を変更すると、そのセルに依存するすべてのセルも更新する必要があります。さらに、テーブルデータは他のテーブルのデータに依存する場合があり、簡単かつ柔軟に更新する必要のある複雑なプレゼンテーションデータスキームを作成します。

プレゼンテーションにおける**チャート スプレッドシートの数式**は、チャート スプレッドシートデータを自動的に計算および更新するための表現です。スプレッドシート数式は、特定のセルまたはセルの集合に対するデータ計算ロジックを定義します。スプレッドシート数式は、セル参照、数学関数、論理演算子、算術演算子、変換関数、文字列定数などを使用する数式または論理式です。数式の定義はセルに書き込まれ、このセルは単純な値を含みません。スプレッドシート数式は値を計算して返し、その後この値がセルに割り当てられます。プレゼンテーションにおけるチャート スプレッドシートの数式は、実際にはExcelの数式と同じであり、それらの実装に対して同じデフォルト関数、演算子、および定数がサポートされています。

[**Aspose.Slides**](https://products.aspose.com/slides/androidjava/)では、チャートのスプレッドシートは
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartData#getChartDataWorkbook--)メソッドを用いた
[**IChartDataWorkbook**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataWorkbook)型で表されます。
スプレッドシート数式は
[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-)メソッドを使用して設定および変更できます。
Aspose.Slidesでサポートされている数式の機能は次のとおりです。

- 論理定数
- 数値定数
- 文字列定数
- エラー定数
- 算術演算子
- 比較演算子
- A1スタイルのセル参照
- R1C1スタイルのセル参照
- 定義済み関数

通常、スプレッドシートは最後に計算された数式の値を保存します。プレゼンテーションの読み込み後、チャートデータが変更されていない場合、[**IChartDataCell.getValue**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataCell#getValue--)メソッドは、それらの値を返します。ただし、スプレッドシートのデータが変更されている場合、**ChartDataCell.Value**プロパティを読み取ると、サポートされていない数式のために[**CellUnsupportedDataException**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/CellUnsupportedDataException) がスローされます。これは、数式が正常に解析されると、セルの依存関係が決定され、最後の値の正確性が決定されるためです。しかし、数式が解析できない場合は、セルの値の正確性を保証できません。

## **プレゼンテーションにチャート スプレッドシート 数式を追加する**
まず、新しいプレゼンテーションの最初のスライドにチャートを追加します。
[IShapeCollection.getShapes.addChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addChart-int-float-float-float-float-)メソッドを使用します。
チャートのワークシートは自動的に作成され、[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartData#getChartDataWorkbook--)メソッドでアクセスできます。



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

次に、**Object**型のプロパティを使用して、
[**IChartDataCell.setValue**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataCell#setValue-java.lang.Object-)メソッドでセルに値を書き込みます。つまり、任意の値をプロパティに設定できます。

```java
workbook.getCell(0, "F2").setValue(-2.5);

workbook.getCell(0, "G3").setValue(6.3);

workbook.getCell(0, "H4").setValue(3);
```

次に、セルに数式を書き込むには、[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-)メソッドを使用できます。

*注*: [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-)メソッドは、A1スタイルのセル参照を設定するために使用されます。

[R1C1Formula](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataCell#getR1C1Formula--)セル参照を設定するには、[**IChartDataCell.setR1C1Formula**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IChartDataCell#setR1C1Formula-java.lang.String-)メソッドを使用できます。

その後、セルB2およびC2から値を読み取ると、それらが計算されます。

```java
Object value1 = cell1.getValue(); // 7.8

Object value2 = cell2.getValue(); // 2.1
```

## **論理定数**
セルの数式に*FALSE*および*TRUE*のような論理定数を使用できます。

```java
workbook.getCell(0, "A2").setValue(false);
IChartDataCell cell = workbook.getCell(0, "B2");
cell.setFormula("A2 = TRUE");
Object value = cell.getValue(); // 値はブーリアンの "false" を含む
```

## **数値定数**
数値は、チャート スプレッドシートの数式を作成するために通常のまたは科学的な表記で使用することができます。

```java
workbook.getCell(0, "A2").setFormula("1 + 0.5");
workbook.getCell(0, "B2").setFormula(".3 * 1E-2");
```

## **文字列定数**
文字列（またはリテラル）定数は、特定の値であり、そのまま使用され、変更されない値です。文字列定数には、日付、テキスト、数値などがあります。

```java
workbook.getCell(0, "A2").setFormula("\"abc\"");
workbook.getCell(0, "B2").setFormula("\"2/3/2020 12:00\"");
```

## **エラー定数**
数式によって結果を計算することができない場合もあります。その場合、セルにはその値の代わりにエラーコードが表示されます。エラーの各タイプには特定のコードがあります。

- #DIV/0! - 数式がゼロで割ろうとしています。
- #GETTING_DATA - セルに表示される場合があり、その値はまだ計算中です。
- #N/A - 情報が欠落しているか、利用できません。理由としては、数式で使用されるセルが空である、余分なスペース文字、誤字などがあります。
- #NAME? - 特定のセルまたは他の数式オブジェクトが名前で見つかりません。
- #NULL! - 数式に誤りがある場合に表示されることがあります（たとえば: (,) またはコロン(:)の代わりにスペース文字を使用）。
- #NUM! - 数式の数値が無効である、長すぎる、または短すぎるなど。
- #REF! - 無効なセル参照です。
- #VALUE! - 予期しない値の型です。たとえば、文字列値が数値セルに設定されます。

```java
IChartDataCell cell = workbook.getCell(0, "A2");
cell.setFormula("2 / 0");
Object value = cell.getValue(); // 値は文字列 "#DIV/0!" を含む
```

## **算術演算子**
チャート ワークシートの数式では、すべての算術演算子を使用できます：

|**演算子**|**意味**|**例**|
| :- | :- | :- |
|+ (プラス記号)|加算または単項プラス|2 + 3|
|- (マイナス記号)|減算または negation|2 - 3<br>-3|
|* (アスタリスク)|乗算|2 * 3|
|/ (スラッシュ)|除算|2 / 3|
|% (パーセント記号)|パーセント|30%|
|^ (キャレット)|指数|2 ^ 3|

*注*: 評価の順序を変更するには、最初に計算する部分を括弧で囲みます。

## **比較演算子**
比較演算子を使用してセルの値を比較できます。これらの演算子を使用して2つの値を比較すると、結果は論理値の*TRUE*またはFALSEになります。

|**演算子**|**意味**|**意味**|
| :- | :- | :- |
|= (イコール記号)|等しい|A2 = 3|
|<> (ノットイコール記号)|等しくない|A2 <> 3|
|> (グレーターザン記号)|より大きい|A2 > 3|
|>= (グレーターザンオアイコール記号)|より大きいか等しい|A2 >= 3|
|< (レスザン記号)|より小さい|A2 < 3|
|<= (レスザンオアイコール記号)|より小さいか等しい|A2 <= 3|

## **A1スタイルのセル参照**
**A1スタイルのセル参照**は、列が文字の識別子（例：*A*）を持ち、行が数値の識別子（例：*1*）を持つワークシートで使用されます。A1スタイルのセル参照は、次のように使用できます：

|**セル参照**|**例**|||
| :- | :- | :- | :- |
||絶対|相対|混合|
|セル|$A$2|A2|<p>A$2</p><p>$A2</p>|
|行|$2:$2|2:2|-|
|列|$A:$A|A:A|-|
|範囲|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

数式でA1スタイルのセル参照を使用する例は以下の通りです：

```java
workbook.getCell(0, "A2").setFormula("C3 + SUM(F2:H5)");
```

## **R1C1スタイルのセル参照**
**R1C1スタイルのセル参照**は、行と列の両方が数値の識別子を持つワークシートで使用されます。R1C1スタイルのセル参照は、次のように使用できます：

|**セル参照**|**例**|||
| :- | :- | :- | :- |
||絶対|相対|混合|
|セル|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|行|R2|R[2]|-|
|列|C3|C[3]|-|
|範囲|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

数式でA1スタイルのセル参照を使用する例は以下の通りです：

```java
workbook.getCell(0, "A2").setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");
```

## **定義済み関数**
数式内で使用できる定義済み関数があり、それによりその実装が簡素化されます。これらの関数は、共通の操作をまとめたもので、以下のようなものがあります：

- ABS
- AVERAGE
- CEILING
- CHOOSE
- CONCAT
- CONCATENATE
- DATE（1900日付システム）
- DAYS
- FIND
- FINDB
- IF
- INDEX（参照形式）
- LOOKUP（ベクタ形式）
- MATCH（ベクタ形式）
- MAX
- SUM
- VLOOKUP