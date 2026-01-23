---
title: プレゼンテーションでPHPを使用してチャート ワークシート数式を適用する
linktitle: ワークシート数式
type: docs
weight: 70
url: /ja/php-java/chart-worksheet-formulas/
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
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP の Java チャート ワークシートを使用して Excel スタイルの数式を適用し、PPT および PPTX ファイル全体でレポートを自動化します。"
---

## **プレゼンテーションにおけるチャートスプレッドシート数式について**
**Chart spreadsheet** (または chart worksheet) はプレゼンテーション内のチャートのデータ ソースです。Chart spreadsheet にはデータが含まれ、チャート上にグラフィックで表されます。PowerPointでチャートを作成すると、このチャートに関連付けられたワークシートが自動的に作成されます。Chart worksheet はすべてのチャートタイプ (折れ線グラフ、棒グラフ、サンバースト グラフ、円グラフ など) で作成されます。PowerPoint で chart spreadsheet を表示するには、チャートをダブルクリックします：

![todo:image_alt_text](chart-worksheet-formulas_1.png)

Chart spreadsheet にはチャート要素の名前 (カテゴリ名: *Category1*、系列名) と、これらのカテゴリと系列に対応する数値データのテーブルが含まれています。デフォルトでは、新しいチャートを作成すると chart spreadsheet のデータは既定のデータで設定されます。その後、ワークシート上で手動でデータを変更できます。

通常、チャートは複雑なデータ (例: 金融アナリスト、科学アナリスト) を表し、他のセルの値や動的データから計算されたセルを持ちます。セルの値を手動で計算してハードコードすると、将来の変更が困難になります。特定のセルの値を変更すると、そのセルに依存するすべてのセルも更新する必要があります。さらに、テーブル データは他のテーブルのデータに依存することがあり、簡単かつ柔軟に更新できる複雑なプレゼンテーション データ スキームを作成します。

**Chart spreadsheet formula** はプレゼンテーション内で chart spreadsheet データを自動的に計算および更新する式です。スプレッドシート数式は特定のセルまたはセルの集合のデータ計算ロジックを定義します。数式はセル参照、数学関数、論理演算子、算術演算子、変換関数、文字列定数などを使用する数式または論理式です。数式の定義はセルに記述され、そのセルは単純な値を含みません。スプレッドシート数式は値を計算して返し、その値がセルに割り当てられます。プレゼンテーションの chart spreadsheet 数式は実際には Excel の数式と同じで、同じ既定の関数、演算子、定数がサポートされています。

[**Aspose.Slides**](https://products.aspose.com/slides/php-java/) の chart spreadsheet は
[**ChartData::getChartDataWorkbook**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/#getChartDataWorkbook) メソッドで
[**ChartDataWorkbook**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/) 型として表されます。
スプレッドシート数式は
[**ChartDataCell::setFormula**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/#setFormula) メソッドで割り当ておよび変更できます。
Aspose.Slides でサポートされている数式機能は次のとおりです。

- 論理定数
- 数値定数
- 文字列定数
- エラー定数
- 算術演算子
- 比較演算子
- A1 形式のセル参照
- R1C1 形式のセル参照
- 事前定義関数

通常、スプレッドシートは最後に計算された数式の値を保存します。プレゼンテーションの読み込み後にチャート データが変更されていない場合、[**ChartDataCell::getValue**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/#getValue) メソッドはそれらの値を返します。ただし、スプレッドシート データが変更された場合、読み取り時にサポートされていない数式に対して [**CellUnsupportedDataException**](https://reference.aspose.com/slides/php-java/aspose.slides/CellUnsupportedDataException) がスローされます。これは、数式が正常に解析されるとセルの依存関係が決定され、最後の値の正確性が確認されるためです。数式が解析できない場合、セル値の正確性は保証できません。

## **プレゼンテーションにチャート スプレッドシート数式を追加する**
最初に、[ShapeCollection::addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addChart) を使用して新しいプレゼンテーションの最初のスライドにチャートを追加します。チャートのワークシートは自動的に作成され、[**ChartData::getChartDataWorkbook**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/#getChartDataWorkbook) メソッドでアクセスできます:
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


次に、[**ChartDataCell::setValue**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/#setValue) メソッド (Object 型) を使用してセルにいくつかの値を書き込みます。Object 型なので任意の値を設定できます:
```php
  $workbook->getCell(0, "F2")->setValue(-2.5);
  $workbook->getCell(0, "G3")->setValue(6.3);
  $workbook->getCell(0, "H4")->setValue(3);
```


数式を書き込むには、[**ChartDataCell::setFormula**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/#setFormula) メソッドを使用します。

*Note*: [**ChartDataCell::setFormula**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/#setFormula) メソッドは A1 形式のセル参照を設定するために使用されます。

R1C1 形式の数式を設定するには、[**ChartDataCell::setR1C1Formula**](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/#setR1C1Formula) メソッドを使用します。

その後、セル B2 と C2 の値を読み取ろうとすると、計算された結果が得られます:
```php
  $value1 = $cell1->getValue();// 7.8

  $value2 = $cell2->getValue();// 2.1


```


## **論理定数**
セル数式で *FALSE* および *TRUE* などの論理定数を使用できます:
```php
  $workbook->getCell(0, "A2")->setValue(false);
  $cell = $workbook->getCell(0, "B2");
  $cell->setFormula("A2 = TRUE");
  $value = $cell->getValue();// 値はブール値 "false" を含みます
```


## **数値定数**
数式では一般的な表記または科学的表記の数値を使用できます:
```php
  $workbook->getCell(0, "A2")->setFormula("1 + 0.5");
  $workbook->getCell(0, "B2")->setFormula(".3 * 1E-2");
```


## **文字列定数**
文字列 (リテラル) 定数はそのまま使用され、変更されません。文字列定数には日付、テキスト、数値などが含まれます:
```php
  $workbook->getCell(0, "A2")->setFormula("\"abc\"");
  $workbook->getCell(0, "B2")->setFormula("\"2/3/2020 12:00\"");

```


## **エラー定数**
数式で結果を計算できない場合、セルにはエラーコードが表示されます。各エラーには特定のコードがあります。

- #DIV/0! - 数式がゼロで除算しようとした場合。
- #GETTING_DATA - 値の計算中にセルに表示されることがあります。
- #N/A - 情報が不足しているか利用できません。原因としては、数式で使用されるセルが空、余分なスペース文字、綴りミスなどがあります。
- #NAME? - 指定されたセルまたは数式オブジェクトが名前で見つかりません。
- #NULL! - 数式に誤りがある場合に発生します (例: (,) またはコロン (:) の代わりにスペース文字を使用)。
- #NUM! - 数式内の数値が無効、桁数が多すぎる、または小さすぎるなど。
- #REF! - 無効なセル参照。
- #VALUE! - 予期しない型の値。例: 文字列を数値セルに設定した場合。
```php
  $cell = $workbook->getCell(0, "A2");
  $cell->setFormula("2 / 0");
  $value = $cell->getValue();// 値は文字列 "#DIV/0!" を含みます
```


## **算術演算子**
チャート ワークシート数式で使用できるすべての算術演算子:

|**演算子**|**意味**|**例**|
| :- | :- | :- |
|+ (プラス記号)|加算または単項プラス|2 + 3|
|- (マイナス記号)|減算または符号反転|2 - 3<br>-3|
|* (アスタリスク)|乗算|2 * 3|
|/ (スラッシュ)|除算|2 / 3|
|% (パーセント記号)|パーセント|30%|
|^ (キャレット)|指数|2 ^ 3|

*Note*: 評価順序を変更するには、先に計算したい部分を丸括弧で囲みます。

## **比較演算子**
セルの値を比較する際に比較演算子を使用できます。これらの演算子で比較すると、結果は *TRUE* または FALSE の論理値になります:

|**演算子**|**意味**|**例**|
| :- | :- | :- |
|= (イコール)|等しい|A2 = 3|
|<> (不等号)|等しくない|A2 <> 3|
|> (大なり)|より大きい|A2 > 3|
|>= (大なりイコール)|以上|A2 >= 3|
|< (小なり)|より小さい|A2 < 3|
|<= (小なりイコール)|以下|A2 <= 3|

## **A1 形式のセル参照**
**A1 形式のセル参照** は、列が文字識別子 (例: "*A*")、行が数字識別子 (例: "*1*") のワークシートで使用されます。使用例は次のとおりです:

|**セル参照**|**例**| | |
| :- | :- | :- | :- |
| |絶対参照|相対参照|混合参照|
|セル|$A$2|A2|<p>A$2</p><p>$A2</p>|
|行|$2:$2|2:2|-|
|列|$A:$A|A:A|-|
|範囲|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C$4</p>|

A1 形式のセル参照を数式で使用する例:
```php
  $workbook->getCell(0, "A2")->setFormula("C3 + SUM(F2:H5)");
```


## **R1C1 形式のセル参照**
**R1C1 形式のセル参照** は、行と列の両方が数字識別子のワークシートで使用されます。使用例は次のとおりです:

|**セル参照**|**例**| | |
| :- | :- | :- | :- |
| |絶対参照|相対参照|混合参照|
|セル|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|行|R2|R[2]|-|
|列|C3|C[3]|-|
|範囲|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

R1C1 形式のセル参照を数式で使用する例:
```php
  $workbook->getCell(0, "A2")->setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");
```


## **事前定義関数**
数式で使用できる事前定義関数があります。これらの関数は次のような一般的な操作を簡略化します:

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

**外部 Excel ファイルを数式付きチャートのデータ ソースとして使用できますか？**

はい。Aspose.Slides は外部ブックを [chart のデータ ソース](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatasourcetype/) としてサポートしており、プレゼンテーション外部の XLSX から数式を使用できます。

**チャート数式は同じブック内のシート名でシートを参照できますか？**

はい。数式は標準的な Excel 参照モデルに従うため、同じブック内または外部ブック内の他のシートを参照できます。外部参照の場合は、Excel の構文でパスとブック名を含めます。