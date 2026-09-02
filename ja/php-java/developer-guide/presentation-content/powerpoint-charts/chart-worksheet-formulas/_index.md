---
title: PHPでプレゼンテーションのチャート ワークシート数式を適用する
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
- チャート データ ワークブック
- 数式 計算
- 論理 定数
- 数値 定数
- 文字列 定数
- エラー 定数
- 算術 演算子
- 比較 演算子
- A1 形式
- R1C1 形式
- 事前定義 関数
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java のチャート ワークシートで Excel 形式の数式を適用し、値を再計算して PowerPoint のチャートで結果を使用する。"
---
## **概要**

PowerPoint のチャートは通常、埋め込みワークシートに元データを格納します。Aspose.Slides for PHP via Java では、チャート データ ワークブックを介してそのワークシートにアクセスし、入力値を書き込み、セルに数式を割り当て、サポートされている数式を計算し、計算結果のセルをチャート データとして使用できます。

この記事では、完全な数式ワークフローを説明します。チャートの作成、ワークシートへのデータ入力、A1 形式または R1C1 形式の数式割り当て、再計算、計算結果の取得、セルをチャート シリーズに接続、プレゼンテーションの保存、さらにサポートされている数式構文、組み込み関数サブセット、キャッシュ値、サポート外の数式、スプレッドシート固有のエラーについても解説します。

## **チャート ワークシートと数式**

チャート ワークシートには、チャートで使用されるカテゴリ、系列名、値が含まれます。PowerPoint では、チャート データ エディタを開くことでワークシートを確認できます。

![PowerPoint chart with its embedded worksheet open, showing category and series data](chart-worksheet-formulas_1.png)

Aspose.Slides では、ワークシートは [ChartDataWorkbook](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdataworkbook/) クラスを通じて公開されます。A1 形式の数式には [ChartDataCell::setFormula](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdatacell/#setFormula)、R1C1 形式の数式には [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdatacell/#setR1C1Formula) を使用します。入力セルまたは数式を変更した後、[ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) を呼び出してサポートされている数式を再計算し、対応するセル値を更新します。

計算済みセルは依然として [ChartDataCell::getValue](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdatacell/#getValue) で結果を取得できます。コード内で数式結果を確認したり、セルをチャート データ ポイントとして使用したりする際に重要です。

## **チャートの作成とワークシート数式の計算**

以下のサンプルはエンドツーエンドのワークフローを示します。クラスター化された縦棒グラフを作成し、サンプル データをクリアし、四半期ごとの売上と費用を記入し、数式で利益を計算し、結果を読み取り、計算結果のセルをチャート値として使用し、プレゼンテーションを保存します。

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 350);
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $workbook->clear($worksheetIndex);

    $category1 = $workbook->getCell($worksheetIndex, "A2", "Q1");
    $category2 = $workbook->getCell($worksheetIndex, "A3", "Q2");
    $category3 = $workbook->getCell($worksheetIndex, "A4", "Q3");

    $workbook->getCell($worksheetIndex, "B1", "Revenue");
    $workbook->getCell($worksheetIndex, "C1", "Expenses");
    $workbook->getCell($worksheetIndex, "D1", "Profit");

    $workbook->getCell($worksheetIndex, "B2")->setValue(120.0);
    $workbook->getCell($worksheetIndex, "C2")->setValue(80.0);
    $workbook->getCell($worksheetIndex, "B3")->setValue(150.0);
    $workbook->getCell($worksheetIndex, "C3")->setValue(95.0);
    $workbook->getCell($worksheetIndex, "B4")->setValue(135.0);
    $workbook->getCell($worksheetIndex, "C4")->setValue(110.0);

    $profit1 = $workbook->getCell($worksheetIndex, "D2");
    $profit2 = $workbook->getCell($worksheetIndex, "D3");
    $profit3 = $workbook->getCell($worksheetIndex, "D4");

    $profit1->setFormula("B2-C2");
    $profit2->setFormula("B3-C3");
    $profit3->setFormula("B4-C4");

    $workbook->calculateFormulas();

    $q1Profit = java_values($profit1->getValue()); // 40
    $q2Profit = java_values($profit2->getValue()); // 55
    $q3Profit = java_values($profit3->getValue()); // 25

    echo "Q1 profit: " . $q1Profit . PHP_EOL;
    echo "Q2 profit: " . $q2Profit . PHP_EOL;
    echo "Q3 profit: " . $q3Profit . PHP_EOL;

    $chart->getChartData()->getCategories()->add($category1);
    $chart->getChartData()->getCategories()->add($category2);
    $chart->getChartData()->getCategories()->add($category3);

    $profitSeries = $chart->getChartData()->getSeries()->add($workbook->getCell($worksheetIndex, "D1"), $chart->getType());
    $profitSeries->getDataPoints()->addDataPointForBarSeries($profit1);
    $profitSeries->getDataPoints()->addDataPointForBarSeries($profit2);
    $profitSeries->getDataPoints()->addDataPointForBarSeries($profit3);
    $profitSeries->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);

    $presentation->save("chart-formulas.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

チャート データ ポイントは `D2:D4` を参照しているため、計算された利益値が使用されます。このワークフローでは個別のチャート更新呼び出しは不要です。まずワークブックを再計算し、その後計算済みセルを使用または保存します。

## **A1 形式の数式を使用する**

A1 表記は列を文字、行を数字で識別します。A1 形式の式は [ChartDataCell::setFormula](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdatacell/#setFormula) で割り当てます。

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $workbook->getCell(0, "C3")->setValue(10);
    $workbook->getCell(0, "F2")->setValue(2);
    $workbook->getCell(0, "G2")->setValue(3);
    $workbook->getCell(0, "H2")->setValue(4);

    $cell = $workbook->getCell(0, "A2");
    $cell->setFormula("C3+SUM(F2:H2)");

    $workbook->calculateFormulas();

    $value = java_values($cell->getValue()); // 19
} finally {
    $presentation->dispose();
}
```

一般的な A1 参照形式は次のとおりです。

| 参照 | 相対 | 絶対 | 混合 |
|---|---|---|---|
| セル | `A2` | `$A$2` | `A$2`, `$A2` |
| 行 | `2:2` | `$2:$2` | — |
| 列 | `A:A` | `$A:$A` | — |
| 範囲 | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

相対参照は数式がスプレッドシートで移動またはコピーされたときに変化します。絶対参照は両方の座標を固定し、混合参照は行または列のいずれかだけを固定します。

## **R1C1 形式の数式を使用する**

R1C1 表記は行と列を数値で識別します。相対参照は角括弧でオフセットを示します。この構文は [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdatacell/#setR1C1Formula) で割り当てます。

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $workbook->getCell(0, "B2")->setValue(12);
    $workbook->getCell(0, "C2")->setValue(5);

    $cell = $workbook->getCell(0, "D2");
    $cell->setR1C1Formula("RC[-2]-RC[-1]");

    $workbook->calculateFormulas();

    $value = java_values($cell->getValue()); // 7
} finally {
    $presentation->dispose();
}
```

一般的な R1C1 参照形式は次のとおりです。

| 参照 | 相対 | 絶対 | 混合 |
|---|---|---|---|
| セル | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| 行 | `R[2]` | `R2` | — |
| 列 | `C[3]` | `C3` | — |
| 範囲 | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

たとえば、セル `D2` で `RC[-2]` は同じ行の左に 2 列あるセル (`B2`) を指します。

## **式の定数と演算子**

組み込みの数式評価エンジンは論理値、数値リテラル、文字列、スプレッドシート エラー値、算術演算子、比較演算子をサポートします。

### **定数とリテラル**

| 種類 | 例 | 補足 |
|---|---|---|
| 論理 | `TRUE`, `FALSE` | `A2=TRUE` などの論理式で直接使用できます。 |
| 数値 | `1`, `0.5`, `.3`, `1E-2` | 通常表記と指数表記の両方がサポートされています。 |
| 文字列 | `"abc"`, `"2/3/2020 12:00"` | 文字列リテラルは式内で二重引用符で囲みます。 |
| エラー結果 | `#DIV/0!`, `#N/A`, `#REF!` | 有効な数式は通常の結果ではなくスプレッドシート エラー値を返すことがあります。 |

この例は複数の定数タイプを使用しています。

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $workbook->getCell(0, "A2")->setValue(false);
    $workbook->getCell(0, "B2")->setFormula("A2=TRUE");
    $workbook->getCell(0, "C2")->setFormula("1+0.5");
    $workbook->getCell(0, "D2")->setFormula(".3*1E-2");
    $workbook->getCell(0, "E2")->setFormula("\"abc\"");
    $workbook->getCell(0, "F2")->setFormula("2/0");

    $workbook->calculateFormulas();

    $logicalValue = java_values($workbook->getCell(0, "B2")->getValue()); // false
    $numericValue = java_values($workbook->getCell(0, "C2")->getValue()); // 1.5
    $scientificValue = java_values($workbook->getCell(0, "D2")->getValue()); // 0.003
    $stringValue = java_values($workbook->getCell(0, "E2")->getValue()); // abc
    $errorValue = java_values($workbook->getCell(0, "F2")->getValue()); // #DIV/0!
} finally {
    $presentation->dispose();
}
```

### **算術演算子**

| 演算子 | 意味 | 例 |
|---|---|---|
| `+` | 加算または単項プラス | `2+3` |
| `-` | 減算または単項マイナス | `2-3`, `-3` |
| `*` | 乗算 | `2*3` |
| `/` | 除算 | `2/3` |
| `%` | パーセンテージ | `30%` |
| `^` | べき乗 | `2^3` |

評価順序を明示するには括弧を使用します。例: `(A2+B2)*C2`.

### **比較演算子**

比較式は論理値を返します。

| 演算子 | 意味 | 例 |
|---|---|---|
| `=` | 等しい | `A2=3` |
| `<>` | 等しくない | `A2<>3` |
| `>` | 大きい | `A2>3` |
| `>=` | 大きいまたは等しい | `A2>=3` |
| `<` | 小さい | `A2<3` |
| `<=` | 小さいまたは等しい | `A2<=3` |

## **サポートされている組み込み関数**

Aspose.Slides にはチャート ワークシート用の組み込み数式評価エンジンがありますが、完全な Excel 計算エンジンではありません。ドキュメント化された関数は以下の一覧に限られます。[ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) が任意の Excel 関数を再計算できると想定しないでください。

| 関数 | 用途またはサポート形態 | 例 |
|---|---|---|
| `ABS` | 絶対値 | `ABS(A2)` |
| `AVERAGE` | 算術平均 | `AVERAGE(B2:B5)` |
| `CEILING` | 数値を切り上げて倍数に | `CEILING(A2,5)` |
| `CHOOSE` | インデックスで値を選択 | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | テキスト結合 | `CONCAT(A2,B2)` |
| `CONCATENATE` | テキスト結合 | `CONCATENATE(A2," ",B2)` |
| `DATE` | 1900 日付システムで日付値を作成 | `DATE(2026,8,19)` |
| `DAYS` | 2 日付間の日数を返す | `DAYS(B2,A2)` |
| `FIND` | テキスト内で文字列検索 | `FIND("-",A2)` |
| `FINDB` | バイト単位のテキスト検索 | `FINDB("a",A2)` |
| `IF` | 条件結果 | `IF(A2>0,A2,0)` |
| `INDEX` | 参照形式 | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | ベクトル形式 | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | ベクトル形式 | `MATCH(A2,B2:B5,0)` |
| `MAX` | 最大値 | `MAX(B2:B5)` |
| `SUM` | 合計 | `SUM(B2:B5)` |
| `VLOOKUP` | 縦方向検索 | `VLOOKUP(A2,B2:D10,3,FALSE)` |

表に示された制限は重要です。`INDEX` は参照形式で、`LOOKUP` と `MATCH` はベクトル形式でサポートされます。`DATE` は 1900 日付システムを使用します。ここに記載されていない機能や関数は、別途文書化されていない限り Aspose.Slides の数式評価エンジンではサポートされないとみなしてください。

## **再計算とキャッシュ値**

スプレッドシート ファイルは通常、数式と最後に計算された値の両方を保存します。プレゼンテーションを読み込むとき、関連するチャート データが変更されていなければ、Aspose.Slides は [ChartDataCell::getValue](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdatacell/#getValue) からキャッシュされた値を取得できます。

入力セルまたは数式を変更した場合、古いキャッシュ結果に依存しないでください。計算結果を読み取る前、またはそれに依存するチャート データを保存する前に必ず [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) を呼び出します。

サポート外の数式については、Aspose.Slides が数式の解析や依存関係の特定に失敗することがあります。ワークブックが変更された場合、以前のキャッシュ値は信頼できなくなります。このような状況でサポート外データのセルの値を取得しようとすると、[CellUnsupportedDataException](https://reference.aspose.com/slides/ja/php-java/aspose.slides/cellunsupporteddataexception/) がスローされることがあります。

Excel の関数で Aspose.Slides が評価できないものがある場合は、対応するスプレッドシート エンジンで数式を計算し、結果の値をチャート ワークブックに書き戻してください。サポート外の数式を推測値で置き換えてはいけません。

## **数式エラーの処理**

区別すべき問題は 2 種類あります。

* 数式自体は有効だが、`#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, `#VALUE!` などのスプレッドシート エラー結果を返す場合です。この場合、エラー トークンはセルの結果として [ChartDataCell::getValue](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdatacell/#getValue) から取得できます。
* 数式が解析、参照、依存関係、またはサポートデータのレベルで失敗する場合です。Aspose.Slides はこれらのケースに対して [CellInvalidFormulaException](https://reference.aspose.com/slides/ja/php-java/aspose.slides/cellinvalidformulaexception/)、[CellInvalidReferenceException](https://reference.aspose.com/slides/ja/php-java/aspose.slides/cellinvalidreferenceexception/)、[CellCircularReferenceException](https://reference.aspose.com/slides/ja/php-java/aspose.slides/cellcircularreferenceexception/)、[CellUnsupportedDataException](https://reference.aspose.com/slides/ja/php-java/aspose.slides/cellunsupporteddataexception/) といったスプレッドシート固有の例外を提供します。

PHP via Java では、Java の例外は `JavaException` を通じて表面化します。テンプレートやユーザー入力から数式が供給される場合は、再計算および値取得の周辺で例外処理を行ってください。スタックトレースに表示される Java 例外は、具体的なスプレッドシート エラーを示します。

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $cell = $workbook->getCell(0, "A2");
    $cell->setFormula("SUM(B2:B5)");

    try {
        $workbook->calculateFormulas();
        echo java_values($cell->getValue()) . PHP_EOL;
    } catch (JavaException $ex) {
        $ex->printStackTrace();
    }
} finally {
    $presentation->dispose();
}
```

## **実用上の制限**

チャート ワークシートでの数式サポートは、完全な Excel 互換性を目指したものではなく、定義されたサブセットの計算に限定されています。レポート ワークフローを設計する際は次点を考慮してください。

* Aspose.Slides に再計算させる必要がある場合は、ドキュメント化された定数、演算子、参照、関数のみを使用してください。
* 数式結果が依存するセルを変更したら必ず再計算してください。
* 読み込んだプレゼンテーションから取得したキャッシュ値は「スナップショット」とみなし、編集後の再計算の代替として使用しないでください。
* 既存テンプレートの数式は、ドキュメント化されたリスト外の関数を使用している場合に備えて事前にテストしてください。
* 完全なスプレッドシート計算エンジンが必要な数式は外部で計算し、結果だけをチャート ワークブックに書き戻してください。

## **FAQ**

**[ChartDataCell::setFormula](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdatacell/#setFormula) と [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdatacell/#setR1C1Formula) の違いは何ですか？**

[ChartDataCell::setFormula](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdatacell/#setFormula) は `B2-C2` のような A1 形式の式を格納します。[ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdatacell/#setR1C1Formula) は `RC[-2]-RC[-1]` のような R1C1 形式の式を格納します。生成またはコピーする数式の形式に合わせて選択してください。

**計算後はセル自体を読むべきですか、値を読むべきですか？**

[ChartDataWorkbook::getCell](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdataworkbook/#getCell) は [ChartDataCell](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdatacell/) を返します。再計算後に計算結果を取得するには、そのセルの [ChartDataCell::getValue](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdatacell/#getValue) メソッドを呼び出してください。

**[ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) はいつ呼び出すべきですか？**

入力値または数式を変更した直後、計算結果に依存する前に必ず [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) を呼び出してください。これにより組み込み評価エンジンがサポートする数式の値が更新されます。

**Aspose.Slides はすべての Excel 関数をサポートしていますか？**

いいえ。組み込み評価エンジンはドキュメント化されたサブセットのみをサポートします。サブセット外の関数は正しく再計算できると想定しないでください。完全な Excel 互換が必要な場合は、別のスプレッドシート エンジンで計算し、最終値をチャート ワークブックに書き込んでください。

**読み込んだプレゼンテーションにサポート外の数式が含まれていた場合はどうなりますか？**

チャート データが変更されていなければ、ワークブックは以前に計算されたキャッシュ値を保持している可能性があります。関連データが変更された後は、そのキャッシュ値は無効になることがあります。サポート外の数式を含むセルにアクセスすると [CellUnsupportedDataException](https://reference.aspose.com/slides/ja/php-java/aspose.slides/cellunsupporteddataexception/) がスローされることがあります。

**数式エラー値は PHP の例外と同じですか？**

いいえ。`#DIV/0!` などの結果は有効な計算から得られるスプレッドシートの値です。一方、[CellInvalidFormulaException](https://reference.aspose.com/slides/ja/php-java/aspose.slides/cellinvalidformulaexception/) や [CellCircularReferenceException](https://reference.aspose.com/slides/ja/php-java/aspose.slides/cellcircularreferenceexception/) などの失敗は Java 例外として `JavaException` を介して PHP に表面化します。

**数式セルが変更されたときにチャートは自動的に更新されますか？**

チャート 系列はワークブックのセルを参照できます。まずワークブックを再計算し、次にプレゼンテーションを保存またはレンダリングしてください。計算済みセルを参照している場合、チャートはその更新されたセル値を使用します。別途チャート更新メソッドは必要ありません。

**外部 Excel ワークブックをチャートで使用できますか？**

はい、チャート データ API を使用して外部ワークブックを参照できます。ただし、本記事で説明する数式計算ワークフローはチャート データ ワークブックと Aspose.Slides が評価できる数式サブセットに限定されています。[ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) が外部 XLSX ファイル内の任意の数式を完全に再計算するとは想定しないでください。

**別シートや別ブックを参照する数式は使用できますか？**

チャート ワークブック内で Excel 形式の参照は可能ですが、評価はサポートされているパーサーと関数セットに制限されます。クロスシートまたは外部参照が不可欠な場合は、対象の Aspose.Slides バージョンで正確に動作するか検証してください。広範な Excel 参照互換が必要なワークフローでは、ワークブックを外部で計算し、解決済みの値をチャート データに書き込むことを推奨します。

**数式文字列は `=` から始める必要がありますか？**

Aspose.Slides の API サンプルは `B2-C2` や `SUM(B2:B5)` のように先頭の `=` を付けずに式を割り当てます。この形式を使用すると、ドキュメント化された API 例と整合性が取れます。