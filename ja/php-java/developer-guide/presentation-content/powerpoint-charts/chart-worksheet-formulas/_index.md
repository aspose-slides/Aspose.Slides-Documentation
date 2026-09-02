---
title: PHP でプレゼンテーションにチャート ワークシート数式を適用
linktitle: ワークシート数式
type: docs
weight: 70
url: /ja/php-java/chart-worksheet-formulas/
keywords:
- チャートスプレッドシート
- チャート ワークシート
- チャート数式
- ワークシート数式
- スプレッドシート数式
- チャート データ ワークブック
- 数式計算
- 優先ロケール
- ロケール固有の数式
- DBCS
- 論理定数
- 数値定数
- 文字列定数
- エラー定数
- 算術演算子
- 比較演算子
- A1 形式
- R1C1 形式
- 事前定義関数
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java のチャート ワークシートで Excel 形式の数式を適用し、値を再計算して PowerPoint のチャートで結果を使用します。"
---
## **概要**

PowerPoint のグラフは通常、データの元となる情報を埋め込みワークシートに保存します。Aspose.Slides for PHP via Java では、グラフ データ ワークブックを介してそのワークシートにアクセスし、入力値を書き込み、セルに数式を割り当て、サポートされている数式を計算し、計算結果のセルをグラフ データとして使用できます。

本稿では、完全な数式ワークフローを説明します。グラフの作成、ワークシートへのデータ入力、A1 形式または R1C1 形式の数式の割り当て、再計算、計算結果の取得、セルをグラフ系列に接続してプレゼンテーションを保存する手順を示します。また、サポートされている数式構文、組み込み関数のサブセット、キャッシュされた値、サポート外の数式、スプレッドシート固有のエラーについても解説します。

## **チャート ワークシートと数式**

チャート ワークシートには、チャートが使用するカテゴリ、系列名、値が含まれます。PowerPoint では、チャート データ エディターを開くことでワークシートを確認できます。

![PowerPoint の埋め込みワークシートが開かれ、カテゴリと系列データが表示されているチャート](chart-worksheet-formulas_1.png)

Aspose.Slides では、ワークシートは [ChartDataWorkbook](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdataworkbook/) クラスを通じて公開されます。A1 形式の数式には [ChartDataCell::setFormula](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdatacell/#setFormula) を、R1C1 形式の数式には [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdatacell/#setR1C1Formula) を使用します。入力セルや数式を変更した後は、[ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) を呼び出してサポートされている数式を再計算し、対応するセル値を更新します。

計算済みセルは依然として [ChartDataCell::getValue](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdatacell/#getValue) を介して結果を取得できます。コード内で数式の結果を確認したり、セルをチャート データ ポイントとして使用したりする際に重要です。

## **チャートの作成とワークシート数式の計算**

以下のサンプルはエンドツーエンドのワークフローを示しています。クラスター化された縦棒グラフを作成し、サンプル データをクリアし、四半期ごとの売上と費用を記入し、数式で利益を計算し、結果を読み取り、計算済みセルをチャートの値として使用し、プレゼンテーションを保存します。

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

チャート データ ポイントは `D2:D4` を参照しているため、計算された利益の値が使用されます。このワークフローでは個別のチャート更新呼び出しは不要です。まずワークブックを再計算し、次に計算済みセルを指すチャート データを使用または保存します。

## **A1 形式の数式を使用する**

A1 表記は列を文字、行を数字で識別します。[ChartDataCell::setFormula](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdatacell/#setFormula) で A1 形式の式を割り当てます。

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

相対参照は、スプレッドシート アプリケーションで数式を移動またはコピーしたときに変化します。絶対参照は両方の座標を固定し、混合参照は行または列のいずれかだけを固定します。

## **R1C1 形式の数式を使用する**

R1C1 表記は行と列を数値で識別します。相対参照は角括弧内のオフセットで表します。[ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdatacell/#setR1C1Formula) でこの構文を割り当てます。

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

たとえば、セル `D2` で `RC[-2]` は同じ行の左へ 2 列離れたセル (`B2`) を指します。

## **数式の定数と演算子**

組み込みの数式評価エンジンは、論理値、数値リテラル、文字列、スプレッドシート エラー値、算術演算子、比較演算子をサポートします。

### **定数とリテラル**

| 種類 | 例 | 備考 |
|---|---|---|
| 論理 | `TRUE`, `FALSE` | `A2=TRUE` のような論理式で直接使用できます。 |
| 数値 | `1`, `0.5`, `.3`, `1E-2` | 通常表記と科学技術表記の両方がサポートされます。 |
| 文字列 | `"abc"`, `"2/3/2020 12:00"` | 文字列リテラルは数式内で二重引用符で囲みます。 |
| エラー結果 | `#DIV/0!`, `#N/A`, `#REF!` | 有効な数式は通常の結果の代わりにスプレッドシートエラー値を返すことがあります。 |

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
| `%` | パーセント | `30%` |
| `^` | 累乗 | `2^3` |

評価順序を明示したい場合は丸括弧を使用します。例: `(A2+B2)*C2`.

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

Aspose.Slides にはチャート ワークシート用の組み込み数式評価エンジンがありますが、完全な Excel 計算エンジンではありません。ドキュメント化された関数は以下の一覧に限定されます。[ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) が任意の Excel 関数を再計算できると想定しないでください。

| 関数 | 用途またはサポート形式 | 例 |
|---|---|---|
| `ABS` | 絶対値 | `ABS(A2)` |
| `AVERAGE` | 算術平均 | `AVERAGE(B2:B5)` |
| `CEILING` | 指定の倍数に切り上げ | `CEILING(A2,5)` |
| `CHOOSE` | インデックスで値を選択 | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | テキスト結合 | `CONCAT(A2,B2)` |
| `CONCATENATE` | テキスト結合 | `CONCATENATE(A2," ",B2)` |
| `DATE` | 1900 日付システムで日付を作成 | `DATE(2026,8,19)` |
| `DAYS` | 2 つの日付間の日数を返す | `DAYS(B2,A2)` |
| `FIND` | テキスト内で文字列を検索 | `FIND("-",A2)` |
| `FINDB` | バイト指向のテキスト検索 | `FINDB("a",A2)` |
| `IF` | 条件式 | `IF(A2>0,A2,0)` |
| `INDEX` | 参照形式 | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | ベクトル形式 | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | ベクトル形式 | `MATCH(A2,B2:B5,0)` |
| `MAX` | 最大値 | `MAX(B2:B5)` |
| `SUM` | 合計 | `SUM(B2:B5)` |
| `VLOOKUP` | 縦方向検索 | `VLOOKUP(A2,B2:D10,3,FALSE)` |

表に示された制約は重要です。`INDEX` は参照形式で、`LOOKUP` と `MATCH` はベクトル形式でのみサポートされています。`DATE` は 1900 日付システムを使用します。ここに記載されていない機能や関数は、Aspose.Slides の数式評価エンジンではサポート外とみなしてください。

## **優先ロケールで数式を計算する**

一部のワークブック 関数はロケール固有の規則に従ってテキストを解釈します。特にダブルバイト文字セット (DBCS) を使用する言語向けの関数では重要です。正しく計算するには、[LoadOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/loadoptions/) を作成し、[SpreadsheetOptions::setPreferredCulture](https://reference.aspose.com/slides/ja/php-java/aspose.slides/spreadsheetoptions/#setPreferredCulture) で優先ロケールを設定し、[LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/loadoptions/#setSpreadsheetOptions) でスプレッドシートオプションを割り当てた上でプレゼンテーションを読み込みます。

以下のサンプルは日本語ロケールを選択し、設定したロード オプションでプレゼンテーションを開き、すべてのチャート ワークブックに対して [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) を呼び出します。

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SpreadsheetOptions;

$japaneseCulture = new Java("java.util.Locale", "ja", "JP");

$spreadsheetOptions = new SpreadsheetOptions();
$spreadsheetOptions->setPreferredCulture($japaneseCulture);

$loadOptions = new LoadOptions();
$loadOptions->setSpreadsheetOptions($spreadsheetOptions);

$chartClass = new JavaClass("com.aspose.slides.IChart");
$presentation = new Presentation("presentation.pptx", $loadOptions);
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, $chartClass)) {
                $shape->getChartData()->getChartDataWorkbook()->calculateFormulas();
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

優先ロケールはプレゼンテーション読み込み設定の一部なので、[Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) インスタンスを作成する前に指定します。ワークブック数式が期待するロケールを使用してください。例: 日本語 DBCS の計算規則に従う数式の場合は `ja-JP` を使用します。

## **再計算とキャッシュされた値**

スプレッドシート ファイルは通常、数式と最後に計算された値の両方を保存します。Aspose.Slides はプレゼンテーションが読み込まれ、対象のチャート データが変更されていない場合に、[ChartDataCell::getValue](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdatacell/#getValue) からキャッシュされた値を取得できます。

入力セルや数式を変更した後は、古いキャッシュ結果に依存しないでください。計算済み値を取得したり、計算結果に依存するチャート データを保存したりする前に、必ず [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) を呼び出します。

サポート外の数式については、Aspose.Slides が数式の解析や依存関係の確立に失敗する可能性があります。ワークブックが変更された場合、以前のキャッシュ値はもはや信頼できません。そのような状況でサポートされていないデータを含むセルの値を取得しようとすると、[CellUnsupportedDataException](https://reference.aspose.com/slides/ja/php-java/aspose.slides/cellunsupporteddataexception/) がスローされることがあります。

Excel の関数で Aspose.Slides が評価できないものがある場合は、対応するスプレッドシート エンジンで数式を計算し、結果の値をチャート ワークブックに書き戻してください。サポート外の数式を推測値で置き換えてはいけません。

## **数式エラーの処理**

区別すべき問題は 2 種類あります。

* 数式自体は有効だが、`#DIV/0!`、`#N/A`、`#NAME?`、`#NULL!`、`#NUM!`、`#REF!`、`#VALUE!` といったスプレッドシート エラー結果を返す場合。この場合、エラー トークンはセルの結果として [ChartDataCell::getValue](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdatacell/#getValue) から取得できます。
* 数式が構文解析、参照、依存関係、またはサポートデータのレベルで失敗する場合。Aspose.Slides はこれらのケースに対してスプレッドシート固有の例外を提供します: [CellInvalidFormulaException](https://reference.aspose.com/slides/ja/php-java/aspose.slides/cellinvalidformulaexception/)、[CellInvalidReferenceException](https://reference.aspose.com/slides/ja/php-java/aspose.slides/cellinvalidreferenceexception/)、[CellCircularReferenceException](https://reference.aspose.com/slides/ja/php-java/aspose.slides/cellcircularreferenceexception/)、[CellUnsupportedDataException](https://reference.aspose.com/slides/ja/php-java/aspose.slides/cellunsupporteddataexception/)。

PHP via Java では、Java の例外が `JavaException` を通じて表面化します。テンプレートやユーザー入力から数式が供給される場合は、再計算および値取得を行うコードを例外処理で囲んでください。スタックトレースに表示される Java 例外は、具体的なスプレッドシート の失敗原因を示します。

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

## **実務上の制限**

チャート ワークシートにおける数式サポートは、完全な Excel 互換性を提供するものではなく、定義されたサブセットの計算に限定されています。レポート ワークフローを設計する際は、次の点に留意してください。

* Aspose.Slides に数式を再計算させる必要がある場合は、ドキュメント化された定数、演算子、参照、関数のみを使用してください。
* 依存するセルを変更したら必ず再計算してください。
* 読み込まれたプレゼンテーションから取得したキャッシュ値は「スナップショット」として扱い、編集後の再計算の代替にはしないでください。
* 既存テンプレートの数式は、ドキュメント化されたリストに含まれない関数を使用していないか事前にテストしてください。
* 完全なスプレッドシート 計算エンジンが必要な数式は、外部で計算し、結果の値でチャート ワークブックを更新してください。

## **FAQ**

**[ChartDataCell::setFormula](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdatacell/#setFormula) と [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdatacell/#setR1C1Formula) の違いは何ですか？**

[ChartDataCell::setFormula](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdatacell/#setFormula) は `B2-C2` のような A1 形式の式を保存します。[ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdatacell/#setR1C1Formula) は `RC[-2]-RC[-1]` のような R1C1 形式の式を保存します。数式の生成やコピー方法に最適な表記を選択してください。

**再計算後にセル自体を読むべきか、値だけを読むべきか？**

[ChartDataWorkbook::getCell](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdataworkbook/#getCell) は [ChartDataCell](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdatacell/) を返します。再計算後に計算結果を取得したい場合は、そのセルの [ChartDataCell::getValue](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdatacell/#getValue) メソッドを呼び出してください。

**[ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) はいつ呼び出すべきですか？**

入力値や数式を変更した直後、計算結果に依存する前に必ず [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/ja/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) を呼び出してください。これにより、組み込み評価エンジンがサポートする数式の値が更新されます。

**Aspose.Slides はすべての Excel 関数をサポートしていますか？**

いいえ。組み込み評価エンジンはドキュメント化されたサブセットのみをサポートします。サブセット外の関数は正しく再計算できると想定しないでください。完全な Excel 数式互換性が必要な場合は、適切なスプレッドシート エンジンで計算し、最終結果をチャート ワークブックに書き込んでください。

**読み込んだプレゼンテーションにサポート外の数式が含まれていた場合はどうなりますか？**

チャート データが変更されていなければ、ワークブックは以前に計算されたキャッシュ値を保持している可能性があります。関連データが変更された後は、そのキャッシュ値は無効になる可能性があります。処理できない数式を含むセルにアクセスすると、[CellUnsupportedDataException](https://reference.aspose.com/slides/ja/php-java/aspose.slides/cellunsupporteddataexception/) がスローされることがあります。

**数式エラーの値は PHP 例外と同じですか？**

いいえ。`#DIV/0!` などの結果は、有効な計算によって生成されたスプレッドシート の値です。一方、[CellInvalidFormulaException](https://reference.aspose.com/slides/ja/php-java/aspose.slides/cellinvalidformulaexception/) や [CellCircularReferenceException](https://reference.aspose.com/slides/ja/php-java/aspose.slides/cellcircularreferenceexception/) といった例外は、スプレッドシート 処理の失敗を示す Java 例外で、`JavaException` を通じて PHP に報告されます。

**数式セルが変更されたときにチャートは自動的に更新されますか？**

チャート 系列はワークブックのセルを参照できます。まずワークブックを再計算し、次にプレゼンテーションを保存またはレンダリングしてください。系列が計算済みセルを参照していれば、チャートは自動的に更新されたセル値を使用します。別途チャート 更新メソッドを呼び出す必要はありません。

**チャートは外部 Excel ワークブックを使用できますか？**

はい、チャート データは API を通じて外部ワークブックを使用するように構成できます。ただし、本稿で説明した数式計算ワークフローはチャート データ ワークブックと Aspose.Slides が評価できる数式サブセットに限られます。外部 XLSX ファイルの任意の数式を完全に再計算できるとは想定しないでください。

**別シートや別ブックを参照する数式は使えますか？**

チャート ワークブック内で Excel 形式の参照は記述可能ですが、評価はサポートされているパーサーと関数セットに制限されます。クロスシートや外部参照が必須の場合は、対象の Aspose.Slides バージョンで正確に評価できるか事前に確認してください。広範な Excel 参照互換性が必要なワークフローは、外部でワークブックを計算し、結果をチャート データに書き戻すことを推奨します。

**数式文字列は `=` で始める必要がありますか？**

Aspose.Slides の API 例では、`B2-C2` や `SUM(B2:B5)` のように先頭に `=` を付けずに式を割り当てます。この形式を使用すると、ドキュメント化された API 例と整合性が取れます。