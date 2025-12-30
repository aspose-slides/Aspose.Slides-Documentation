---
title: PHP を使用したプレゼンテーションでのチャートワークシート数式の適用
linktitle: ワークシート数式
type: docs
weight: 70
url: /ja/php-java/chart-worksheet-formulas/
keywords:
- チャートスプレッドシート
- チャートワークシート
- チャート数式
- ワークシート数式
- スプレッドシート数式
- データ ソース
- 論理定数
- 数値定数
- 文字列定数
- エラー定数
- 算術定数
- 比較演算子
- A1 形式
- R1C1 形式
- 事前定義関数
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Java のチャートワークシートを介して PHP 用 Aspose.Slides で Excel 形式の数式を適用し、PPT および PPTX ファイル全体のレポートを自動化します。"
---

## **プレゼンテーションのチャートスプレッドシート数式について**
**チャートスプレッドシート**（またはチャートワークシート）は、チャートのデータソースです。チャートスプレッドシートにはデータが含まれ、チャート上にグラフィックで表現されます。PowerPoint でチャートを作成すると、このチャートに関連付けられたワークシートも自動的に作成されます。チャートワークシートは、折れ線グラフ、棒グラフ、サンバースト グラフ、円グラフなど、すべての種類のチャートに対して作成されます。PowerPoint でチャートスプレッドシートを表示するには、チャートをダブルクリックします。

![todo:image_alt_text](chart-worksheet-formulas_1.png)


チャートスプレッドシートには、チャート要素の名前（カテゴリ名: *Category1*、系列名）と、これらのカテゴリと系列に対応する数値データの表が含まれます。デフォルトでは、新しいチャートを作成すると、チャートスプレッドシートのデータは既定のデータで設定されます。その後、ワークシート内のデータを手動で変更できます。

通常、チャートは複雑なデータ（例: 財務アナリスト、科学アナリストが使用するデータ）を表し、セルは他のセルの値や動的データから計算されます。セルの値を手動で計算してハードコードすると、将来的に変更しにくくなります。特定のセルの値を変更すると、それに依存するすべてのセルも更新が必要になります。さらに、表データが他の表のデータに依存する場合、プレゼンテーションのデータ構成は複雑になり、簡単かつ柔軟に更新できる必要があります。

**プレゼンテーションのチャートスプレッドシート数式** は、チャートスプレッドシートのデータを自動的に計算および更新する式です。数式は特定のセルまたはセルのセットのデータ計算ロジックを定義します。数式は、セル参照、数値関数、論理演算子、算術演算子、変換関数、文字列定数などを使用する数学式または論理式です。数式の定義はセルに記入され、そのセルは単純な値を保持しません。数式が値を計算して返し、その結果がセルに割り当てられます。プレゼンテーションのチャートスプレッドシート数式は実質的に Excel の数式と同じで、同じ既定の関数、演算子、定数がサポートされています。

[**Aspose.Slides**](https://products.aspose.com/slides/php-java/) のチャートスプレッドシートは、[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartData#getChartDataWorkbook--) メソッドで表される
[**IChartDataWorkbook**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataWorkbook) 型です。  
数式は [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataCell#setFormula-java.lang.String-) メソッドで割り当ておよび変更できます。  
Aspose.Slides でサポートされている数式の機能は次のとおりです。

- 論理定数
- 数値定数
- 文字列定数
- エラー定数
- 算術演算子
- 比較演算子
- A1 形式のセル参照
- R1C1 形式のセル参照
- 事前定義関数


通常、スプレッドシートは最後に計算された数式の値を保持します。プレゼンテーションの読み込み後にチャートデータが変更されていない場合、[**IChartDataCell.getValue**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataCell#getValue--) メソッドはそれらの値を返します。ただし、スプレッドシートデータが変更された場合、**ChartDataCell.Value** プロパティを読み取ると、サポートされていない数式に対して [**CellUnsupportedDataException**](https://reference.aspose.com/slides/php-java/aspose.slides/CellUnsupportedDataException) がスローされます。これは、数式が正常に解析されるとセルの依存関係が決定され、最後の値の正確性が判断されるためです。数式が解析できない場合、セル値の正確性は保証できません。

## **プレゼンテーションにチャートスプレッドシート数式を追加する**
まず、[IShapeCollection.getShapes.addChart](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addChart-int-float-float-float-float-) を使用して新規プレゼンテーションの最初のスライドにチャートを追加します。チャートのワークシートは自動的に作成され、次のメソッドでアクセスできます。  
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartData#getChartDataWorkbook--) メソッド：
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


次に、**Object** 型の [**IChartDataCell.setValue**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataCell#setValue-java.lang.Object-) プロパティを使用してセルに値を書き込みます。このプロパティは任意の値を設定できることを意味します：
```php
  $workbook->getCell(0, "F2")->setValue(-2.5);
  $workbook->getCell(0, "G3")->setValue(6.3);
  $workbook->getCell(0, "H4")->setValue(3);
```


数式をセルに書き込むには、[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataCell#setFormula-java.lang.String-) メソッドを使用します。

*Note*: [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataCell#setFormula-java.lang.String-) メソッドは A1 形式のセル参照を設定するために使用されます。  

R1C1 形式のセル参照を設定するには、[**IChartDataCell.setR1C1Formula**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartDataCell#setR1C1Formula-java.lang.String-) メソッドを使用します：

その後、セル B2 と C2 の値を読み取ると計算結果が得られます：
```php
  $value1 = $cell1->getValue();// 7.8

  $value2 = $cell2->getValue();// 2.1


```


## **論理定数**
セル数式で *FALSE* および *TRUE* などの論理定数を使用できます：
```php
  $workbook->getCell(0, "A2")->setValue(false);
  $cell = $workbook->getCell(0, "B2");
  $cell->setFormula("A2 = TRUE");
  $value = $cell->getValue();// 値はブール値 "false" を含んでいます
```


## **数値定数**
数式で一般的または科学的記法の数値を使用してチャートスプレッドシート数式を作成できます：
```php
  $workbook->getCell(0, "A2")->setFormula("1 + 0.5");
  $workbook->getCell(0, "B2")->setFormula(".3 * 1E-2");

```


## **文字列定数**
文字列（リテラル）定数はそのまま使用され、変更されません。文字列定数には日付、テキスト、数値などがあります：
```php
  $workbook->getCell(0, "A2")->setFormula("\"abc\"");
  $workbook->getCell(0, "B2")->setFormula("\"2/3/2020 12:00\"");

```


## **エラー定数**
数式で結果を計算できない場合、セルには値の代わりにエラーコードが表示されます。エラーの種類ごとに固有のコードがあります。

- #DIV/0! - 数式がゼロ除算を試みた場合。
- #GETTING_DATA - 値がまだ計算中のときにセルに表示されることがあります。
- #N/A - 情報が欠落または利用できない場合。原因例: 参照セルが空、余分な空白文字、スペルミスなど。
- #NAME? - 特定のセルや数式オブジェクトが名前で見つからない場合。
- #NULL! - 数式に誤りがあり、例えば (,) やコロン (:) の代わりに空白文字が使用された場合に表示されます。
- #NUM! - 数式内の数値が無効、長すぎる、あるいは小さすぎるなど。
- #REF! - 無効なセル参照。
- #VALUE! - 予期しない型の値。例: 文字列を数値セルに設定した場合。
```php
  $cell = $workbook->getCell(0, "A2");
  $cell->setFormula("2 / 0");
  $value = $cell->getValue();// 値は文字列 "#DIV/0!" を含んでいます
```


## **算術演算子**
チャートワークシート数式で使用できる算術演算子はすべて以下のとおりです。

|**演算子**|**意味**|**例**|
| :- | :- | :- |
|+ (プラス)|加算または単項プラス|2 + 3|
|- (マイナス)|減算または単項マイナス|2 - 3<br>-3|
|* (アスタリスク)|乗算|2 * 3|
|/ (スラッシュ)|除算|2 / 3|
|% (パーセント)|百分率|30%|
|^ (キャレット)|べき乗|2 ^ 3|

*Note*: 評価順序を変更するには、先に計算したい部分を丸括弧で囲んでください。

## **比較演算子**
比較演算子を使用してセルの値を比較できます。これらの演算子で比較した結果は、*TRUE* または FALSE の論理値になります。

|**演算子**|**意味**|**例**|
| :- | :- | :- |
|= (イコール)|等しい|A2 = 3|
|<> (不等号)|等しくない|A2 <> 3|
|> (大なり)|より大きい|A2 > 3|
|>= (大なりイコール)|以上|A2 >= 3|
|< (小なり)|より小さい|A2 < 3|
|<= (小なりイコール)|以下|A2 <= 3|

## **A1 形式のセル参照**
**A1 形式のセル参照** は、列が文字（例: "*A*」）で行が数字（例: "*1*」）で表されるワークシートで使用されます。A1 形式のセル参照は次のように利用できます。

|**セル参照**|**例**|||
| :- | :- | :- | :- |
||絶対参照|相対参照|混合参照|
|セル|$A$2|A2|<p>A$2</p><p>$A2</p>|
|行|$2:$2|2:2|-|
|列|$A:$A|A:A|-|
|範囲|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


A1 形式のセル参照を数式で使用する例：
```php
  $workbook->getCell(0, "A2")->setFormula("C3 + SUM(F2:H5)");
```


## **R1C1 形式のセル参照**
**R1C1 形式のセル参照** は、行も列も数値で表されるワークシートで使用されます。R1C1 形式のセル参照は次のように利用できます。

|**セル参照**|**例**|||
| :- | :- | :- | :- |
||絶対参照|相対参照|混合参照|
|セル|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|行|R2|R[2]|-|
|列|C3|C[3]|-|
|範囲|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C7<br>R[2]C3:R5C7|


A1 形式のセル参照を数式で使用する例：
```php
  $workbook->getCell(0, "A2")->setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");
```


## **事前定義関数**
数式で使用できる事前定義関数があり、実装を簡素化できます。これらの関数は最も一般的に使用される操作をカプセル化します。例:

- ABS
- AVERAGE
- CEILING
- CHOOSE
- CONCAT
- CONCATENATE
- DATE (1900 日付システム)
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

## **FAQ**

**数式付きチャートのデータ ソースとして外部 Excel ファイルはサポートされていますか？**

はい。Aspose.Slides は外部ブックを [チャートのデータ ソース](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatasourcetype/) としてサポートしており、プレゼンテーション外部の XLSX から数式を使用できます。

**チャート数式は同じブック内のシート名でシートを参照できますか？**

はい。数式は標準的な Excel 参照モデルに従うため、同じブック内または外部ブック内の他シートを参照できます。外部参照の場合は、Excel の構文でパスとブック名を含めてください。