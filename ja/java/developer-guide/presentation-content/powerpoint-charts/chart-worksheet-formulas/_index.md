---
title: Javaでプレゼンテーションにチャート ワークシート数式を適用
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
- チャート データ ワークブック
- 数式 計算
- 優先 カルチャー
- カルチャー固有 数式
- DBCS
- 論理 定数
- 数値 定数
- 文字列 定数
- エラー 定数
- 算術 演算子
- 比較 演算子
- A1 スタイル
- R1C1 スタイル
- 事前定義 関数
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java のチャート ワークシートで Excel 形式の数式を適用し、値を再計算して PowerPoint のチャートで結果を使用します。"
---
## **概要**

PowerPoint のチャートは通常、埋め込みワークシートに元データを保存します。Aspose.Slides for Java では、チャート データ ワークブックを介してそのワークシートにアクセスし、入力値を書き込み、セルに数式を割り当て、サポートされている数式を計算し、計算されたセルをチャート データとして使用できます。

本記事では、完全な数式ワークフローを説明します。チャートを作成し、ワークシートにデータを入力し、A1 形式または R1C1 形式の数式を割り当て、再計算し、計算結果を読み取り、セルをチャート系列に接続してプレゼンテーションを保存します。また、サポートされている数式構文、組み込み関数サブセット、キャッシュされた値、サポート外の数式、およびスプレッドシート固有のエラーについても解説します。

## **チャート ワークシートと数式**

チャート ワークシートには、チャートで使用されるカテゴリ、系列名、値が含まれます。PowerPoint では、チャート データ エディターを開くことでワークシートを確認できます。

![埋め込みワークシートが開かれたPowerPointのチャート（カテゴリとシリーズのデータを表示）](chart-worksheet-formulas_1.png)

Aspose.Slides では、ワークシートは[IChartDataWorkbook](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdataworkbook/)インターフェイスを介して公開されます。[IChartDataCell.setFormula](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) を使用して A1 形式の数式を、[IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) を使用して R1C1 形式の数式を割り当てます。入力セルや数式を変更した後は、[IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) を呼び出してサポートされている数式を再計算し、対応するセル値を更新します。

計算されたセルは[IChartDataCell.getValue](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdatacell/#getValue--) を通じて結果を取得できます。コードで数式結果を確認したり、セルをチャート データ ポイントとして使用する場合に重要です。

## **チャートの作成とワークシート数式の計算**

以下の例はエンドツーエンドのワークフローを示しています。クラスタ化された縦棒グラフを作成し、サンプル データをクリアして四半期ごとの売上と費用の値を書き込み、数式で利益を計算し、結果を読み取り、計算されたセルをチャート値として使用し、プレゼンテーションを保存します。

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

チャート データ ポイントは `D2:D4` を参照しているため、チャートは計算された利益の値を使用します。このワークフローでは別途チャート更新の呼び出しは不要です。まずワークブックを再計算し、計算されたセルを指すチャート データを使用または保存します。

## **A1 形式の数式の使用**

A1 表記は列を文字、行を数字で識別します。[IChartDataCell.setFormula](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) を介して A1 形式の式を割り当てます。

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

一般的な A1 参照形式は次のとおりです。

| 参照 | 相対 | 絶対 | 混合 |
|---|---|---|---|
| セル | `A2` | `$A$2` | `A$2`, `$A2` |
| 行 | `2:2` | `$2:$2` | — |
| 列 | `A:A` | `$A:$A` | — |
| 範囲 | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

相対参照は数式を移動またはコピーしたときに変更される可能性があります。絶対参照は両方の座標を固定し、混合参照は行または列のいずれかだけを固定します。

## **R1C1 形式の数式の使用**

R1C1 表記は行と列を数値で識別します。相対参照は角括弧内のオフセットで表します。[IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) を使用してこの構文を割り当てます。

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

一般的な R1C1 参照形式は次のとおりです。

| 参照 | 相対 | 絶対 | 混合 |
|---|---|---|---|
| セル | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| 行 | `R[2]` | `R2` | — |
| 列 | `C[3]` | `C3` | — |
| 範囲 | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

たとえばセル `D2` で `RC[-2]` は同じ行の左 2 列目のセル（`B2`）を意味します。

## **数式の定数と演算子**

組み込み数式評価エンジンは論理値、数値リテラル、文字列、スプレッドシートエラー値、算術演算子、および比較演算子をサポートします。

### **定数とリテラル**

| 種類 | 例 | 備考 |
|---|---|---|
| 論理 | `TRUE`, `FALSE` | 論理式に直接使用できます（例: `A2=TRUE`）。 |
| 数値 | `1`, `0.5`, `.3`, `1E-2` | 一般的および指数表記がサポートされています。 |
| 文字列 | `"abc"`, `"2/3/2020 12:00"` | 文字列リテラルは式内で二重引用符で囲まれます。 |
| エラー結果 | `#DIV/0!`, `#N/A`, `#REF!` | 有効な数式は通常の結果の代わりにスプレッドシートエラー値を返すことがあります。 |

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
| `+` | 加算または単項プラス | `2+3` |
| `-` | 減算または符号反転 | `2-3`, `-3` |
| `*` | 乗算 | `2*3` |
| `/` | 除算 | `2/3` |
| `%` | パーセント | `30%` |
| `^` | 指数 | `2^3` |

評価順序を明示するには丸括弧を使用します。例: `(A2+B2)*C2`。

### **比較演算子**

比較式は論理値を返します。

| 演算子 | 意味 | 例 |
|---|---|---|
| `=` | 等しい | `A2=3` |
| `<>` | 等しくない | `A2<>3` |
| `>` | より大きい | `A2>3` |
| `>=` | 以上 | `A2>=3` |
| `<` | 未満 | `A2<3` |
| `<=` | 以下 | `A2<=3` |

## **サポートされている組み込み関数**

Aspose.Slides にはチャート ワークシート用の組み込み数式評価エンジンが含まれていますが、完全な Excel 計算エンジンではありません。ドキュメント化された関数は以下の一覧に限定されています。任意の Excel 関数が[IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--)で再計算できると想定しないでください。

| 関数 | 目的またはサポート形式 | 例 |
|---|---|---|
| `ABS` | 絶対値 | `ABS(A2)` |
| `AVERAGE` | 算術平均 | `AVERAGE(B2:B5)` |
| `CEILING` | 数値を指定した倍数に切り上げ | `CEILING(A2,5)` |
| `CHOOSE` | インデックスで値を選択 | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | テキスト値を結合 | `CONCAT(A2,B2)` |
| `CONCATENATE` | テキスト値を結合 | `CONCATENATE(A2," ",B2)` |
| `DATE` | 1900 日付システムを使用して日付値を作成 | `DATE(2026,8,19)` |
| `DAYS` | 日付間の日数を返す | `DAYS(B2,A2)` |
| `FIND` | テキスト内で別のテキストを検索 | `FIND("-",A2)` |
| `FINDB` | バイト単位のテキスト検索 | `FINDB("a",A2)` |
| `IF` | 条件結果 | `IF(A2>0,A2,0)` |
| `INDEX` | 参照形式 | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | ベクトル形式 | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | ベクトル形式 | `MATCH(A2,B2:B5,0)` |
| `MAX` | 最大値 | `MAX(B2:B5)` |
| `SUM` | 合計 | `SUM(B2:B5)` |
| `VLOOKUP` | 縦方向検索 | `VLOOKUP(A2,B2:D10,3,FALSE)` |

表に示された制限は重要です。`INDEX` は参照形式でドキュメント化されており、`LOOKUP` と `MATCH` はベクトル形式でドキュメント化されています。`DATE` は 1900 日付システムを使用します。ここに記載されていない機能は Aspose.Slides の数式評価エンジンではサポートされていないとみなしてください。

## **優先カルチャーで数式を計算**

一部のチャート ワークブック関数はカルチャ固有のルールに従って文字列を解釈します。これは特にダブルバイト文字セット（DBCS）を使用する言語向け関数で重要です。正しく計算するには、[LoadOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/loadoptions/) を作成し、[SpreadsheetOptions.setPreferredCulture](https://reference.aspose.com/slides/ja/java/com.aspose.slides/spreadsheetoptions/#setPreferredCulture-java.util.Locale-) で優先カルチャーを設定し、[LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-) でスプレッドシートオプションを割り当ててからプレゼンテーションをロードします。

以下の例は日本語カルチャーを選択し、設定したロード オプションでプレゼンテーションを開き、すべてのチャート ワークブックに対して[IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) を呼び出します。

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

優先カルチャーはプレゼンテーションのロード構成の一部であるため、[Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) インスタンスを作成する前に指定してください。ワークブックの数式で期待されるカルチャーを使用します。例として、日本語 DBCS 計算規則に従う数式には `ja-JP` を使用します。

## **再計算とキャッシュされた値**

スプレッドシート ファイルは通常、数式とその最後に計算された値の両方を保存します。したがって、プレゼンテーションがロードされ、該当するチャート データが変更されていない場合、Aspose.Slides は[IChartDataCell.getValue](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdatacell/#getValue--) からキャッシュされた値を読み取ることができます。

入力セルや数式を変更した後は、古いキャッシュ結果に依存しないでください。計算された値を読み取るか、依存するチャート データを保存する前に[IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) を呼び出します。

サポートサブセット外の数式については、Aspose.Slides は数式の解析や依存関係の確立ができない場合があります。ワークブックが変更された場合、以前のキャッシュ値は信頼できなくなります。その状況でサポート外データを含むセルの値を取得しようとすると[CellUnsupportedDataException](https://reference.aspose.com/slides/ja/java/com.aspose.slides/cellunsupporteddataexception/) がスローされる可能性があります。

チャートが Aspose.Slides が評価しない Excel 関数に依存している場合は、外部のスプレッドシート エンジンでその数式を計算し、結果の値をチャート ワークブックに書き戻してください。サポート外の数式を推測した値で置き換えないでください。

## **数式エラーの処理**

区別すべき問題は 2 種類あります。

数式が有効であっても、`#DIV/0!`、`#N/A`、`#NAME?`、`#NULL!`、`#NUM!`、`#REF!`、`#VALUE!` などのスプレッドシートエラー結果を返すことがあります。この場合、エラー トークンはセルの結果であり、[IChartDataCell.getValue](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdatacell/#getValue--) を通じて取得できます。

数式が構文解析、参照、依存関係、またはサポートデータのレベルで失敗することもあります。Aspose.Slides はこれらの場合に対して次のスプレッドシート固有例外を提供します: [CellInvalidFormulaException](https://reference.aspose.com/slides/ja/java/com.aspose.slides/cellinvalidformulaexception/)、[CellInvalidReferenceException](https://reference.aspose.com/slides/ja/java/com.aspose.slides/cellinvalidreferenceexception/)、[CellCircularReferenceException](https://reference.aspose.com/slides/ja/java/com.aspose.slides/cellcircularreferenceexception/)、[CellUnsupportedDataException](https://reference.aspose.com/slides/ja/java/com.aspose.slides/cellunsupporteddataexception/)。

テンプレートやユーザー入力から数式が供給される場合は、再計算および値アクセス時にこれらの例外を捕捉してください。

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

## **実用的な制限**

チャート ワークシートの数式サポートは、完全な Excel 互換性を目指すものではなく、定義されたサブセットのスプレッドシート計算を対象としています。設計時に次の点に留意してください。

- ドキュメント化された定数、演算子、参照、関数のみを使用して Aspose.Slides に数式の再計算を任せます。
- 数式結果が依存するセルを変更した後は必ず再計算します。
- ロードされたプレゼンテーションからのキャッシュ値はスナップショットであり、編集後の再計算の代替にはなりません。
- 既存テンプレートの数式は、ドキュメント化されたリストに含まれない関数を使用していないか事前にテストします。
- 完全なスプレッドシート計算エンジンが必要な数式は外部で計算し、結果の値でチャート ワークブックを更新します。

## **FAQ**

**[IChartDataCell.setFormula](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) と [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) の違いは何ですか？**

[IChartDataCell.setFormula](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) は `B2-C2` のような A1 形式の式を格納します。[IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) は `RC[-2]-RC[-1]` のような R1C1 形式の式を格納します。生成またはコピーする数式の形式に合わせて表記を選択してください。

**計算後にセルそのものを読むべきですか、値を読むべきですか？**

[IChartDataWorkbook.getCell](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdataworkbook/#getCell-int-java.lang.String-) は[IChartDataCell](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdatacell/) を返します。再計算後に計算結果を取得するには、そのセルの[IChartDataCell.getValue](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdatacell/#getValue--) メソッドを呼び出してください。

**[IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) はいつ呼び出すべきですか？**

入力値または数式を変更した後、計算結果に依存する前に[IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) を呼び出してください。これにより、組み込み評価エンジンがサポートする数式の値が更新されます。

**Aspose.Slides はすべての Excel 関数をサポートしていますか？**

いいえ。組み込み評価エンジンはドキュメント化されたサブセットの関数のみをサポートします。サブセット外の関数は正しく再計算できると想定しないでください。完全な Excel 数式互換性が必要な場合は、適切なスプレッドシート エンジンで計算し、最終的な値をチャート ワークブックに書き込んでください。

**ロードされたプレゼンテーションにサポート外の数式が含まれている場合はどうなりますか？**

チャート データが変更されていない場合、ワークブックには以前に計算されたキャッシュ値が残っていることがあります。関連データが変更されると、そのキャッシュ値は無効になる可能性があります。処理できない数式を含むセルにアクセスすると[CellUnsupportedDataException](https://reference.aspose.com/slides/ja/java/com.aspose.slides/cellunsupporteddataexception/) がスローされることがあります。

**数式エラー値は Java の例外と同じですか？**

いいえ。`#DIV/0!` のような結果は、有効な計算から生成されたスプレッドシート値です。[CellInvalidFormulaException](https://reference.aspose.com/slides/ja/java/com.aspose.slides/cellinvalidformulaexception/) や [CellCircularReferenceException](https://reference.aspose.com/slides/ja/java/com.aspose.slides/cellcircularreferenceexception/) などの例外は、数式を通常どおり処理できないことを示します。

**数式セルが変更されるとチャートは自動的に更新されますか？**

チャート 系列はワークブックのセルを参照できます。まずワークブックを再計算し、その後プレゼンテーションを保存またはレンダリングしてください。計算されたセルを参照している場合、チャートは更新されたセル値を使用します。別途チャート更新メソッドは必要ありません。

**チャートは外部の Excel ワークブックを使用できますか？**

はい、チャート データはチャート データ API を介して外部ワークブックを使用するように構成できます。ただし、本記事で説明した数式計算ワークフローはチャート データ ワークブックと Aspose.Slides が評価する数式サブセットに限定されています。[IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) が外部 XLSX ファイルの任意の数式を完全に再計算するとは想定しないでください。

**別のワークシートまたはワークブックを参照する数式を使用できますか？**

Excel 形式の参照はチャート ワークブックに存在する可能性がありますが、数式評価はサポートされるパーサーと関数セットに制限されています。クロスシートまたは外部参照が必須の場合は、対象の Aspose.Slides バージョンで正確な数式を検証してください。広範な Excel 参照互換性が必要なワークフローでは、ワークブックを外部で計算し、解決した値をチャート データに書き戻すことを検討してください。

**数式文字列は `=` で始める必要がありますか？**

Aspose.Slides の API 例では、`B2-C2` や `SUM(B2:B5)` のように先頭に `=` を付けずに式を割り当てます。この形式を使用すると、ドキュメント化された API 例と一貫した数式が生成されます。