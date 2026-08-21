---
title: Android のプレゼンテーションでチャート ワークシート数式を適用する
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
- チャート データ ワークブック
- 数式 計算
- 優先ロケール
- ロケール固有 数式
- DBCS
- 論理定数
- 数値定数
- 文字列定数
- エラー定数
- 算術演算子
- 比較演算子
- A1 形式
- R1C1 形式
- 組み込み関数
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java のチャート ワークシートで Excel 形式の数式を適用し、値を再計算して PowerPoint のチャートで結果を使用します。"
---
## **概要**

PowerPoint のグラフは通常、埋め込みワークシートに元データを保存します。Aspose.Slides for Android via Java では、チャート データ ワークブックを介してそのワークシートにアクセスし、入力値を書き込み、セルに数式を割り当て、サポートされている数式を計算し、計算結果のセルをチャート データとして使用できます。

この記事では、完全な数式ワークフローを説明します。チャートの作成、ワークシートへのデータ入力、A1 形式または R1C1 形式の数式割り当て、再計算、計算結果の取得、セルをチャート シリーズに接続、プレゼンテーションの保存までを示します。また、サポートされている数式構文、組み込み関数のサブセット、キャッシュ値、サポート外の数式、スプレッドシート固有のエラーについても解説します。

## **チャート ワークシートと数式**

チャート ワークシートには、カテゴリ、系列名、チャートで使用される値が格納されます。PowerPoint では、チャート データ エディターを開くことでワークシートを確認できます。

![PowerPoint の埋め込みワークシートが開かれたチャート、カテゴリと系列データを表示](chart-worksheet-formulas_1.png)

Aspose.Slides では、ワークシートは [IChartDataWorkbook](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdataworkbook/) インターフェイスを介して公開されます。A1 形式の数式には [IChartDataCell.setFormula](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) を、R1C1 形式の数式には [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) を使用します。入力セルや数式を変更したら、[IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) を呼び出してサポートされている数式を再計算し、対応するセル値を更新します。

計算済みセルは依然として [IChartDataCell.getValue](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdatacell/#getValue--) を通じて結果を取得できます。コード内で数式の結果を確認したり、セルをチャート データ ポイントとして使用する場合に重要です。

## **チャートの作成とワークシート数式の計算**

以下の例はエンドツーエンドのワークフローを示します。クラスター化縦棒グラフを作成し、サンプル データをクリアし、四半期ごとの売上と費用を入力し、数式で利益を計算し、結果を読み取り、計算済みセルをチャートの値として使用し、プレゼンテーションを保存します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 350);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    workbook.clear(worksheetIndex);

    IChartDataCell category1 = workbook.getCell(worksheetIndex, "A2", "Q1");
    IChartDataCell category2 = workbook.getCell(worksheetIndex, "A3", "Q2");
    IChartDataCell category3 = workbook.getCell(worksheetIndex, "A4", "Q3");

    workbook.getCell(worksheetIndex, "B1", "Revenue");
    workbook.getCell(worksheetIndex, "C1", "Expenses");
    workbook.getCell(worksheetIndex, "D1", "Profit");

    workbook.getCell(worksheetIndex, "B2").setValue(120.0);
    workbook.getCell(worksheetIndex, "C2").setValue(80.0);
    workbook.getCell(worksheetIndex, "B3").setValue(150.0);
    workbook.getCell(worksheetIndex, "C3").setValue(95.0);
    workbook.getCell(worksheetIndex, "B4").setValue(135.0);
    workbook.getCell(worksheetIndex, "C4").setValue(110.0);

    IChartDataCell profit1 = workbook.getCell(worksheetIndex, "D2");
    IChartDataCell profit2 = workbook.getCell(worksheetIndex, "D3");
    IChartDataCell profit3 = workbook.getCell(worksheetIndex, "D4");

    profit1.setFormula("B2-C2");
    profit2.setFormula("B3-C3");
    profit3.setFormula("B4-C4");

    workbook.calculateFormulas();

    double q1Profit = ((Number) profit1.getValue()).doubleValue(); // 40
    double q2Profit = ((Number) profit2.getValue()).doubleValue(); // 55
    double q3Profit = ((Number) profit3.getValue()).doubleValue(); // 25

    System.out.println("Q1 profit: " + q1Profit);
    System.out.println("Q2 profit: " + q2Profit);
    System.out.println("Q3 profit: " + q3Profit);

    chart.getChartData().getCategories().add(category1);
    chart.getChartData().getCategories().add(category2);
    chart.getChartData().getCategories().add(category3);

    IChartSeries profitSeries = chart.getChartData().getSeries().add(workbook.getCell(worksheetIndex, "D1"), chart.getType());
    profitSeries.getDataPoints().addDataPointForBarSeries(profit1);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit2);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit3);
    profitSeries.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("chart-formulas.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

チャート データ ポイントは `D2:D4` を参照しているため、計算された利益値が使用されます。このワークフローでは個別のチャート 更新呼び出しは不要です。まずワークブックを再計算し、その後計算セルを使用または保存します。

## **A1 形式の数式を使用する**

A1 表記は列を文字、行を数字で表します。A1 形式の式は [IChartDataCell.setFormula](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) で割り当てます。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "C3").setValue(10);
    workbook.getCell(0, "F2").setValue(2);
    workbook.getCell(0, "G2").setValue(3);
    workbook.getCell(0, "H2").setValue(4);

    IChartDataCell cell = workbook.getCell(0, "A2");
    cell.setFormula("C3+SUM(F2:H2)");

    workbook.calculateFormulas();

    Object value = cell.getValue(); // 19
} finally {
    presentation.dispose();
}
```

代表的な A1 参照形式は次の通りです。

| 参照 | 相対参照 | 絶対参照 | 混合参照 |
|---|---|---|---|
| セル | `A2` | `$A$2` | `A$2`, `$A2` |
| 行 | `2:2` | `$2:$2` | — |
| 列 | `A:A` | `$A:$A` | — |
| 範囲 | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

相対参照は数式を移動またはコピーしたときに変化します。絶対参照は行・列の両方を固定し、混合参照は行または列のいずれかだけを固定します。

## **R1C1 形式の数式を使用する**

R1C1 表記は行と列の両方を数値で識別します。相対参照は角括弧内のオフセットで表します。この構文は [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) で割り当てます。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "B2").setValue(12);
    workbook.getCell(0, "C2").setValue(5);

    IChartDataCell cell = workbook.getCell(0, "D2");
    cell.setR1C1Formula("RC[-2]-RC[-1]");

    workbook.calculateFormulas();

    Object value = cell.getValue(); // 7
} finally {
    presentation.dispose();
}
```

代表的な R1C1 参照形式は次の通りです。

| 参照 | 相対参照 | 絶対参照 | 混合参照 |
|---|---|---|---|
| セル | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| 行 | `R[2]` | `R2` | — |
| 列 | `C[3]` | `C3` | — |
| 範囲 | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

例として、セル `D2` で `RC[-2]` は「同じ行で左に 2 列」すなわち `B2` を指します。

## **数式定数と演算子**

組み込み数式評価エンジンは、論理値、数値リテラル、文字列、スプレッドシート エラー値、算術演算子、比較演算子をサポートします。

### **定数とリテラル**

| 種類 | 例 | 備考 |
|---|---|---|
| 論理 | `TRUE`, `FALSE` | `A2=TRUE` のように論理式で直接使用可能 |
| 数値 | `1`, `0.5`, `.3`, `1E-2` | 標準表記と指数表記の両方をサポート |
| 文字列 | `"abc"`, `"2/3/2020 12:00"` | 文字列リテラルは二重引用符で囲む |
| エラー結果 | `#DIV/0!`, `#N/A`, `#REF!` | 有効な数式でもスプレッドシート エラー値を返すことがある |

この例は複数の定数タイプを使用しています。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "A2").setValue(false);
    workbook.getCell(0, "B2").setFormula("A2=TRUE");
    workbook.getCell(0, "C2").setFormula("1+0.5");
    workbook.getCell(0, "D2").setFormula(".3*1E-2");
    workbook.getCell(0, "E2").setFormula("\"abc\"");
    workbook.getCell(0, "F2").setFormula("2/0");

    workbook.calculateFormulas();

    Object logicalValue = workbook.getCell(0, "B2").getValue(); // 偽
    Object numericValue = workbook.getCell(0, "C2").getValue(); // 1.5
    Object scientificValue = workbook.getCell(0, "D2").getValue(); // 0.003
    Object stringValue = workbook.getCell(0, "E2").getValue(); // abc
    Object errorValue = workbook.getCell(0, "F2").getValue(); // #DIV/0!
} finally {
    presentation.dispose();
}
```

### **算術演算子**

| 演算子 | 意味 | 例 |
|---|---|---|
| `+` | 加算 または 単項プラス | `2+3` |
| `-` | 減算 または 否定 | `2-3`, `-3` |
| `*` | 乗算 | `2*3` |
| `/` | 除算 | `2/3` |
| `%` | パーセンテージ | `30%` |
| `^` | 累乗 | `2^3` |

評価順序を明示したい場合は括弧を使用します。例: `(A2+B2)*C2`.

### **比較演算子**

比較式は論理値を返します。

| 演算子 | 意味 | 例 |
|---|---|---|
| `=` | 等しい | `A2=3` |
| `<>` | 等しくない | `A2<>3` |
| `>` | 大きい | `A2>3` |
| `>=` | 以上 | `A2>=3` |
| `<` | 小さい | `A2<3` |
| `<=` | 以下 | `A2<=3` |

## **サポートされている組み込み関数**

Aspose.Slides にはチャート ワークシート用の組み込み数式評価エンジンがありますが、完全な Excel 計算エンジンではありません。ドキュメント化された関数は以下の一覧に限られます。[IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) が処理できる関数のみを想定してください。

| 関数 | 用途またはサポート形態 | 例 |
|---|---|---|
| `ABS` | 絶対値 | `ABS(A2)` |
| `AVERAGE` | 平均値 | `AVERAGE(B2:B5)` |
| `CEILING` | 指定の倍数へ切り上げ | `CEILING(A2,5)` |
| `CHOOSE` | インデックスで値を選択 | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | テキスト結合 | `CONCAT(A2,B2)` |
| `CONCATENATE` | テキスト結合 | `CONCATENATE(A2," ",B2)` |
| `DATE` | 1900 日付系で日付作成 | `DATE(2026,8,19)` |
| `DAYS` | 2 日付間の日数取得 | `DAYS(B2,A2)` |
| `FIND` | 文字列検索 | `FIND("-",A2)` |
| `FINDB` | バイト単位検索 | `FINDB("a",A2)` |
| `IF` | 条件式 | `IF(A2>0,A2,0)` |
| `INDEX` | 参照形式 | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | ベクトル形式 | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | ベクトル形式 | `MATCH(A2,B2:B5,0)` |
| `MAX` | 最大値 | `MAX(B2:B5)` |
| `SUM` | 合計 | `SUM(B2:B5)` |
| `VLOOKUP` | 縦方向検索 | `VLOOKUP(A2,B2:D10,3,FALSE)` |

表に示された制限は重要です。`INDEX` は参照形式、`LOOKUP` と `MATCH` はベクトル形式でのみサポートされます。`DATE` は 1900 系統の日付です。ここに記載されていない機能は Aspose.Slides の数式評価エンジンではサポート外とみなしてください。

## **優先ロケールで数式を計算する**

一部のワークブック関数はロケール固有の規則でテキストを解釈します。特に DBCS（倍角文字セット）を使用する言語向け関数では重要です。正しく計算するには、[LoadOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/loadoptions/) を作成し、[SpreadsheetOptions.setPreferredCulture](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/spreadsheetoptions/#setPreferredCulture-java.util.Locale-) で優先ロケールを設定し、[LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-) でワークブックに適用してからプレゼンテーションを読み込みます。

以下の例は日本語ロケールを選択し、設定したロード オプションでプレゼンテーションを開き、すべてのチャート ワークブックに対して [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) を呼び出します。

```java
import com.aspose.slides.*;
import java.util.Locale;

Locale japaneseCulture = Locale.forLanguageTag("ja-JP");

ISpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setPreferredCulture(japaneseCulture);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IChart) {
                IChart chart = (IChart) shape;
                chart.getChartData().getChartDataWorkbook().calculateFormulas();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

優先ロケールはプレゼンテーション読み込み時の設定の一部です。`Presentation` インスタンスを生成する前に指定してください。ワークブックの数式が期待するロケール（例: 日本語の場合は `ja-JP`）を使用します。

## **再計算とキャッシュ値**

スプレッドシート ファイルは通常、数式とその最終計算値の両方を格納します。Aspose.Slides は、プレゼンテーションが読み込まれ、関連するチャート データが変更されていない場合に [IChartDataCell.getValue](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdatacell/#getValue--) からキャッシュされた値を取得できます。

入力セルや数式を変更したら、古いキャッシュ結果に依存しないでください。計算済み値を取得するか、計算結果に依存するチャート データを保存する前に必ず [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) を呼び出します。

サポート外の数式については、Aspose.Slides が数式を解析できなかったり依存関係を把握できなかったりする可能性があります。ワークブックが変更された場合、以前のキャッシュ値は信頼できません。このような状況でサポート外データを含むセルの値を取得しようとすると、[CellUnsupportedDataException](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/cellunsupporteddataexception/) がスローされます。

チャートが Aspose.Slides が評価できない Excel 関数に依存している場合は、外部のスプレッドシート エンジンで計算し、結果の値をチャート ワークブックに書き戻してください。サポート外の数式を推測値で置き換えてはなりません。

## **数式エラーの処理**

区別すべき問題は 2 種類あります。

* 数式自体は有効だが、`#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, `#VALUE!` といったスプレッドシート エラー値を返す場合。この場合エラー トークンはセルの結果として扱われ、[IChartDataCell.getValue](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdatacell/#getValue--) で取得できます。
* 数式の解析、参照、依存関係、またはサポートデータのレベルで失敗する場合。Aspose.Slides は以下のスプレッドシート 固有例外を提供します: [CellInvalidFormulaException](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/cellcircularreferenceexception/), および [CellUnsupportedDataException](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/cellunsupporteddataexception/)。

テンプレートやユーザー入力から数式が供給される場合は、再計算および値取得時にこれらの例外を捕捉してください。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    IChartDataCell cell = workbook.getCell(0, "A2");
    cell.setFormula("SUM(B2:B5)");

    try {
        workbook.calculateFormulas();
        System.out.println(cell.getValue());
    } catch (CellInvalidFormulaException ex) {
        System.err.println("Invalid formula: " + ex.getMessage());
    } catch (CellInvalidReferenceException ex) {
        System.err.println("Invalid cell reference: " + ex.getMessage());
    } catch (CellCircularReferenceException ex) {
        System.err.println("Circular reference: " + ex.getMessage());
    } catch (CellUnsupportedDataException ex) {
        System.err.println("Unsupported spreadsheet data: " + ex.getMessage());
    }
} finally {
    presentation.dispose();
}
```

## **実務上の制限**

チャート ワークシートにおける数式サポートは、限定されたサブセットのスプレッドシート計算を対象としています。完全な Excel 互換性を期待しないでください。設計時に次の点を考慮してください。

* Aspose.Slides に再計算させる場合は、ドキュメント化された定数、演算子、参照、関数のみを使用してください。
* 計算結果に依存するセルを変更したら必ず再計算してください。
* 読み込んだプレゼンテーションのキャッシュ値は「スナップショット」と見なし、編集後の再計算の代替にはしないでください。
* 既存テンプレートの数式は、ドキュメント化されたリスト外の関数を使用していないか事前にテストしてください。
* 完全なスプレッドシート計算エンジンが必要な数式は外部で計算し、結果だけをチャート ワークブックに書き戻す方法を採用してください。

## **FAQ**

**[IChartDataCell.setFormula](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) と [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) の違いは何ですか？**

[IChartDataCell.setFormula](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) は `B2-C2` のような A1 形式の式を保存します。[IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) は `RC[-2]-RC[-1]` のような R1C1 形式の式を保存します。生成またはコピーする数式に合わせて表記を選択してください。

**計算後にセルそのものを読むべきですか、それとも値を読むべきですか？**

[IChartDataWorkbook.getCell](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-java.lang.String-) は [IChartDataCell](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdatacell/) を返します。計算結果を取得するには、再計算後にそのセルの [IChartDataCell.getValue](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdatacell/#getValue--) メソッドを呼び出してください。

**[IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) はいつ呼び出すべきですか？**

入力値または数式を変更した直後、計算結果に依存する処理を行う前に [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) を呼び出してください。これにより組み込み評価エンジンがサポートする数式の値が更新されます。

**Aspose.Slides はすべての Excel 関数をサポートしていますか？**

いいえ。組み込み評価エンジンはドキュメント化されたサブセットのみをサポートします。サブセット外の関数は正しく再計算できると想定しないでください。完全な Excel 互換が必要な場合は、別のスプレッドシート エンジンで計算し、最終値をチャート ワークブックに書き込んでください。

**ロードされたプレゼンテーションにサポート外の数式が含まれていたらどうなりますか？**

チャート データが変更されていなければ、ワークブックは以前に計算されたキャッシュ値を保持している可能性があります。関連データが変更された後はそのキャッシュは無効になることがあります。処理できない数式を含むセルにアクセスすると [CellUnsupportedDataException](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/cellunsupporteddataexception/) がスローされることがあります。

**数式エラー値は Java の例外と同じですか？**

違います。`#DIV/0!` などの結果は、有効な計算が行われた際にスプレッドシートが返す値です。[CellInvalidFormulaException](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/cellinvalidformulaexception/) や [CellCircularReferenceException](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/cellcircularreferenceexception/) といった例外は、数式自体を正常に処理できなかったことを示します。

**数式セルが変更されたとき、チャートは自動的に更新されますか？**

チャート 系列がワークブックのセルを参照している場合、まずワークブックを再計算し、その後プレゼンテーションを保存またはレンダリングすれば、更新されたセル値がチャートに反映されます。別途のチャート 更新メソッドは不要です。

**外部 Excel ワークブックをチャートで使用できますか？**

はい、チャート データ API を使って外部ワークブックを参照できます。ただし、本稿で説明した数式計算ワークフローはチャート データ ワークブックと Aspose.Slides が評価できる数式サブセットに限定されます。[IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) が外部 XLSX の任意の数式を完全に再計算するわけではないことに注意してください。

**別シートまたは別ブックを参照する数式を使えますか？**

Excel 形式の参照はチャート ワークブックに存在する可能性がありますが、評価はサポートされているパーサーと関数セットに制限されます。クロスシートや外部参照が必須の場合は、使用している Aspose.Slides バージョンで正確に動作するか事前に検証してください。広範な Excel 参照互換が必要な場合は、ワークブックを外部で計算し、解決済みの値をチャート データに書き戻す方法を採用してください。

**数式文字列は `=` で始める必要がありますか？**

Aspose.Slides の API サンプルでは `B2-C2` や `SUM(B2:B5)` のように先頭の `=` を付けずに式を割り当てています。この形式で記述すると、ドキュメント化された API の例と一貫性が保たれます。