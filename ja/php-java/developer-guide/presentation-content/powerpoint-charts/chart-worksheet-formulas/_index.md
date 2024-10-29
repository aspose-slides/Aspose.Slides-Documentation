---
title: チャートワークシートの数式
type: docs
weight: 70
url: /ja/php-java/chart-worksheet-formulas/
keywords: "パワーポイントの方程式, パワーポイントのスプレッドシート数式"
description: "PowerPointの方程式とスプレッドシートの数式"
---


## **プレゼンテーションにおけるチャートスプレッドシート数式について**
**チャートスプレッドシート**（またはチャートワークシート）は、プレゼンテーション内のチャートのデータソースです。チャートスプレッドシートには、グラフィックな方法でチャートに表示されるデータが含まれています。PowerPointでチャートを作成すると、このチャートに関連付けられたワークシートも自動的に作成されます。チャートワークシートは、全てのタイプのチャート（線グラフ、棒グラフ、サンバーストチャート、円グラフなど）に対して作成されます。PowerPointでチャートスプレッドシートを見るには、チャートをダブルクリックしてください：

![todo:image_alt_text](chart-worksheet-formulas_1.png)


チャートスプレッドシートには、チャート要素の名前（カテゴリ名: *Category1*, シリーズ名）と、これらのカテゴリおよびシリーズに関連する数値データの表が含まれています。デフォルトでは、新しいチャートを作成すると、チャートスプレッドシートのデータはデフォルトデータに設定されます。その後、ワークシート内のスプレッドシートデータを手動で変更することができます。

通常、チャートは複雑なデータ（例: 財務分析官、科学分析官）を表し、他のセルの値や他の動的データから計算されたセルを持っています。セルの値を手動で計算してそのセルにハードコーディングすると、将来それを変更することが難しくなります。特定のセルの値を変更すると、それに依存するすべてのセルも更新する必要があります。さらに、表のデータは他の表のデータに依存する場合があり、簡単で柔軟な方法で更新する必要がある複雑なプレゼンテーションデータスキームを作成します。

**プレゼンテーション内のチャートスプレッドシート数式**は、チャートスプレッドシートデータを自動的に計算し更新する表現です。スプレッドシート数式は、特定のセルまたはセルのセットのデータ計算ロジックを定義します。スプレッドシート数式は、セル参照、数学関数、論理演算子、算術演算子、変換関数、文字列定数などを使用する数学的または論理的な数式です。数式の定義はセルに書かれ、このセルには単純な値は含まれません。スプレッドシート数式は値を計算し、それを返し、その後この値がセルに割り当てられます。プレゼンテーション内のチャートスプレッドシート数式は実際にはExcelの数式と同じであり、実装には同じデフォルトの関数、演算子、および定数がサポートされています。

[**Aspose.Slides**](https://products.aspose.com/slides/php-java/)では、チャートスプレッドシートは
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartData#getChartDataWorkbook--)メソッドを使用して
[**IChartDataWorkbook**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataWorkbook)タイプで表されます。
スプレッドシート数式は、
[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataCell#setFormula-java.lang.String-)メソッドで設定および変更できます。
Aspose.Slidesでは、数式に対して以下の機能がサポートされています：

- 論理定数
- 数値定数
- 文字列定数
- エラー定数
- 算術演算子
- 比較演算子
- A1スタイルのセル参照
- R1C1スタイルのセル参照
- 予め定義された関数


通常、スプレッドシートは最後に計算された数式の値を保存します。プレゼンテーションの読み込み後にチャートデータが変更されていなければ、[**IChartDataCell.getValue**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataCell#getValue--)メソッドは、それらの値を返します。しかし、スプレッドシートデータが変更された場合、**ChartDataCell.Value**プロパティを読むと、サポートされていない数式に対して[**CellUnsupportedDataException**](https://reference.aspose.com/slides/php-java/aspose.slides/CellUnsupportedDataException)がスローされます。これは、数式が正常に解析されると、セルの依存関係が決定され、最後の値の正しさが判断されるためです。しかし、数式が解析できない場合、セルの値の正しさは保証されません。

## **プレゼンテーションにチャートスプレッドシート数式を追加する**
まず、新しいプレゼンテーションの最初のスライドにチャートを追加します。
[IShapeCollection.getShapes.addChart](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addChart-int-float-float-float-float-)を使用します。
チャートのワークシートは自動的に作成され、[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartData#getChartDataWorkbook--)メソッドを使用してアクセスできます：

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 150, 150, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    # ...
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

ある値をセルに書き込むために、[**IChartDataCell.setValue**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataCell#setValue-java.lang.Object-)プロパティを使用します。このプロパティは**Object**型で、任意の値を設定できます：

```php
  $workbook->getCell(0, "F2")->setValue(-2.5);
  $workbook->getCell(0, "G3")->setValue(6.3);
  $workbook->getCell(0, "H4")->setValue(3);

```

次に、セルに数式を書き込むために、[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataCell#setFormula-java.lang.String-)メソッドを使用できます：

*注*: [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataCell#setFormula-java.lang.String-)メソッドはA1スタイルのセル参照を設定するために使用されます。

[R1C1Formula](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataCell#getR1C1Formula--)セル参照を設定するには、[**IChartDataCell.setR1C1Formula**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataCell#setR1C1Formula-java.lang.String-)メソッドを使用します：

その後、B2およびC2のセルから値を読み取ろうとすると、それらが計算されます：

```php
  $value1 = $cell1->getValue();// 7.8

  $value2 = $cell2->getValue();// 2.1


```

## **論理定数**
セルの数式で*FALSE*や*TRUE*のような論理定数を使用できます：

```php
  $workbook->getCell(0, "A2")->setValue(false);
  $cell = $workbook->getCell(0, "B2");
  $cell->setFormula("A2 = TRUE");
  $value = $cell->getValue();// 値はブーリアンの"false"を含む


```

## **数値定数**
数値は、チャートスプレッドシート数式を作成するために一般的または科学的表記で使用できます：

```php
  $workbook->getCell(0, "A2")->setFormula("1 + 0.5");
  $workbook->getCell(0, "B2")->setFormula(".3 * 1E-2");

```

## **文字列定数**
文字列（またはリテラル）定数は、特定の値であり、そのまま使用され、変更されません。文字列定数は、日付、テキスト、数値などが含まれます：

```php
  $workbook->getCell(0, "A2")->setFormula("\"abc\"");
  $workbook->getCell(0, "B2")->setFormula("\"2/3/2020 12:00\"");

```

## **エラー定数**
場合によっては、数式によって結果を計算できないことがあります。その場合、セルの値の代わりにエラーコードが表示されます。各タイプのエラーには特定のコードが割り当てられています：

- #DIV/0! - 数式がゼロで割ろうとしています。
- #GETTING_DATA - 値がまだ計算中の場合、セルに表示されることがあります。
- #N/A - 情報が欠落しているか、利用できません。理由としては、数式で使用されるセルが空である、余分なスペースがある、スペルミスがある、などがあります。
- #NAME? - 特定のセルまたは他の数式オブジェクトがその名前で見つかりません。
- #NULL! - 数式にエラーがある場合に表示されることがあります。例えば、(,)やコロン（:）の代わりにスペース文字が使用されている場合。
- #NUM! - 数式内の数値が無効、不適切に長すぎる、または短すぎるなど。
- #REF! - 無効なセル参照。
- #VALUE! - 予期しない値の型。例えば、数値セルに文字列値が設定されています。

```php
  $cell = $workbook->getCell(0, "A2");
  $cell->setFormula("2 / 0");
  $value = $cell->getValue();// 値は文字列"#DIV/0!"を含む


```

## **算術演算子**
チャートワークシート数式内で、すべての算術演算子を使用できます：

|**演算子** |**意味** |**例**|
| :- | :- | :- |
|+ (プラス記号) |加算または単項プラス|2 + 3|
|- (マイナス記号) |減算または否定 |2 - 3<br>-3|
|* (アスタリスク)|乗算 |2 * 3|
|/ (スラッシュ)|除算 |2 / 3|
|% (パーセント記号) |パーセント |30%|
|^ (キャレット) |累乗 |2 ^ 3|

*注*: 評価の順序を変更するには、計算する部分をかっこで囲みます。

## **比較演算子**
比較演算子を使用してセルの値を比較できます。これらの演算子を使用して2つの値を比較すると、結果は論理値*TRUE*またはFALSEになります：

|**演算子** |**意味** |**意味** |
| :- | :- | :- |
|= (イコール記号) |等しい |A2 = 3|
|<> (不等号) |等しくない|A2 <> 3|
|> (大なり記号) |大きい|A2 > 3|
|>= (大なりイコール記号)|大きいまたは等しい|A2 >= 3|
|< (小なり記号)|小さい|A2 < 3|
|<= (小なりイコール記号)|小さいまたは等しい|A2 <= 3|

## **A1スタイルのセル参照**
**A1スタイルのセル参照**は、列が文字の識別子（例: "*A*")を持ち、行が数値の識別子（例: "*1*")を持つワークシートで使用されます。A1スタイルのセル参照は次のように使用できます：

|**セル参照**|**例**|||
| :- | :- | :- | :- |
||絶対 |相対 |混合|
|セル |$A$2 |A2|<p>A$2</p><p>$A2</p>|
|行 |$2:$2 |2:2 |-|
|列 |$A:$A |A:A |-|
|範囲 |$A$2:$C$4 |A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


数式でA1スタイルのセル参照を使用する例は以下の通りです：

```php
  $workbook->getCell(0, "A2")->setFormula("C3 + SUM(F2:H5)");

```

## **R1C1スタイルのセル参照**
**R1C1スタイルのセル参照**は、行と列の両方が数値の識別子を持つワークシートで使用されます。R1C1スタイルのセル参照は次のように使用できます：

|**セル参照**|**例**|||
| :- | :- | :- | :- |
||絶対 |相対 |混合|
|セル |R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|行 |R2|R[2]|-|
|列 |C3|C[3]|-|
|範囲 |R2C3:R5C7|R[2]C[3]:R[5]C[7] |R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


数式でR1スタイルのセル参照を使用する例は以下の通りです：

```php
  $workbook->getCell(0, "A2")->setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");

```

## **予め定義された関数**
数式の実装を簡素化するために使用できる予め定義された関数があります。これらの関数は、最も一般的に使用される操作をカプセル化しています：

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