---
title: Java でプレゼンテーションのチャート ワークシート数式を適用する
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java のチャート ワークシートで Excel 形式の数式を適用し、値を再計算して、PowerPoint のチャートで結果を使用します。"
---
## **概要**

PowerPoint のグラフは通常、埋め込みワークシートに元データを保存します。Aspose.Slides for Java では、チャート データ ワークブックを介してそのワークシートにアクセスし、入力値を書き込み、セルに数式を割り当て、サポートされている数式を計算し、計算されたセルをチャート データとして使用できます。

この記事では、完全な数式ワークフローを説明します。グラフを作成し、ワークシートにデータを入力し、A1 形式または R1C1 形式の数式を割り当て、再計算し、計算結果を読み取り、そのセルをチャート シリーズに接続し、プレゼンテーションを保存します。また、サポートされている数式構文、組み込み関数のサブセット、キャッシュされた値、未サポートの数式、スプレッドシート固有のエラーについても説明します。

## **チャート ワークシートと数式**

チャート ワークシートには、グラフで使用されるカテゴリ、系列名、値が含まれます。PowerPoint では、チャート データ エディターを開くことでワークシートを確認できます。

![PowerPoint の埋め込みワークシートを開いたチャート。カテゴリと系列データを表示](chart-worksheet-formulas_1.png)

Aspose.Slides では、ワークシートは [IChartDataWorkbook](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdataworkbook/) インターフェイスを通じて公開されます。A1 形式の数式には [IChartDataCell.setFormula](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) を、R1C1 形式の数式には [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) を使用します。入力セルまたは数式を変更した後は、[IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) を呼び出してサポートされている数式を再計算し、対応するセル値を更新します。

計算されたセルは依然として [IChartDataCell.getValue](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdatacell/#getValue--) で結果を取得できます。これは、コードで数式の結果を確認したり、セルをチャート データ ポイントとして使用したりする場合に重要です。

## **チャートの作成とワークシート数式の計算**

以下の例はエンドツーエンドのワークフローを示します。クラスター化縦棒グラフを作成し、サンプル データをクリアし、四半期の売上と費用の値を書き込み、数式で利益を計算し、結果を読み取り、計算されたセルをチャートの値として使用し、プレゼンテーションを保存します。

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

チャート データ ポイントは `D2:D4` を参照するため、グラフは計算された利益の値を使用します。このワークフローでは別途グラフのリフレッシュ呼び出しは必要ありません。まずワークブックを再計算し、次に計算されたセルを指すチャート データを使用または保存します。

## **A1 形式の数式の使用**

A1 表記は列を文字、行を数字で識別します。A1 形式の式は [IChartDataCell.setFormula](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) で割り当てます。

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

一般的な A1 参照形態は次のとおりです。

| 参照 | 相対 | 絶対 | 混合 |
|---|---|---|---|
| セル | `A2` | `$A$2` | `A$2`, `$A2` |
| 行 | `2:2` | `$2:$2` | — |
| 列 | `A:A` | `$A:$A` | — |
| 範囲 | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

相対参照は数式がスプレッドシート アプリケーションで移動またはコピーされたときに変化します。絶対参照は両方の座標を固定し、混合参照は行または列のいずれかだけを固定します。

## **R1C1 形式の数式の使用**

R1C1 表記は行と列の両方を数値で識別します。相対参照は角括弧内のオフセットで表します。この構文は [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) を使用して割り当てます。

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

一般的な R1C1 参照形態は次のとおりです。

| 参照 | 相対 | 絶対 | 混合 |
|---|---|---|---|
| セル | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| 行 | `R[2]` | `R2` | — |
| 列 | `C[3]` | `C3` | — |
| 範囲 | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

例として、セル `D2` で `RC[-2]` は同じ行の左に 2 列あるセル (`B2`) を指します。

## **数式定数と演算子**

組み込みの数式評価エンジンは論理値、数値リテラル、文字列、スプレッドシート エラー値、算術演算子、比較演算子をサポートします。

### **定数とリテラル**

| 種類 | 例 | 注釈 |
|---|---|---|
| 論理 | `TRUE`, `FALSE` | `A2=TRUE` のような論理式で直接使用できます。 |
| 数値 | `1`, `0.5`, `.3`, `1E-2` | 通常表記と指数表記の両方がサポートされます。 |
| 文字列 | `"abc"`, `"2/3/2020 12:00"` | 文字列リテラルは式内で二重引用符で囲みます。 |
| エラー結果 | `#DIV/0!`, `#N/A`, `#REF!` | 有効な数式は通常の結果ではなくスプレッドシート エラー値に評価されることがあります。 |

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
| `-` | 減算または単項マイナス | `2-3`, `-3` |
| `*` | 乗算 | `2*3` |
| `/` | 除算 | `2/3` |
| `%` | パーセンテージ | `30%` |
| `^` | 累乗 | `2^3` |

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

Aspose.Slides にはチャート ワークシート用の組み込み数式評価エンジンが含まれていますが、完全な Excel 計算エンジンではありません。ドキュメント化された関数セットは以下に限定されています。[IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) が処理できる関数以外は再計算できないと想定してください。

| 関数 | 用途またはサポート形式 | 例 |
|---|---|---|
| `ABS` | 絶対値 | `ABS(A2)` |
| `AVERAGE` | 算術平均 | `AVERAGE(B2:B5)` |
| `CEILING` | 指定した倍数へ切り上げ | `CEILING(A2,5)` |
| `CHOOSE` | インデックスで値を選択 | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | テキスト結合 | `CONCAT(A2,B2)` |
| `CONCATENATE` | テキスト結合 | `CONCATENATE(A2," ",B2)` |
| `DATE` | 1900 日付システムで日付値を作成 | `DATE(2026,8,19)` |
| `DAYS` | 2 つの日付間の日数を返す | `DAYS(B2,A2)` |
| `FIND` | テキスト内で文字列を検索 | `FIND("-",A2)` |
| `FINDB` | バイト指向テキスト検索 | `FINDB("a",A2)` |
| `IF` | 条件付き結果 | `IF(A2>0,A2,0)` |
| `INDEX` | 参照形式 | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | ベクトル形式 | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | ベクトル形式 | `MATCH(A2,B2:B5,0)` |
| `MAX` | 最大値 | `MAX(B2:B5)` |
| `SUM` | 合計 | `SUM(B2:B5)` |
| `VLOOKUP` | 縦方向検索 | `VLOOKUP(A2,B2:D10,3,FALSE)` |

表に示された制限は重要です。`INDEX` は参照形式で、`LOOKUP` と `MATCH` はベクトル形式でのみサポートされます。`DATE` は 1900 日付システムを使用します。ここに記載されていない機能は、Aspose.Slides の数式評価エンジンでは未サポートと見なしてください。

## **再計算とキャッシュ値**

スプレッドシート ファイルは通常、数式と最後に計算された値の両方を格納します。プレゼンテーションがロードされ、該当するチャート データが変更されていない場合、Aspose.Slides は [IChartDataCell.getValue](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdatacell/#getValue--) からキャッシュされた値を読み取れます。

入力セルまたは数式を変更した後は、古いキャッシュ結果に依存しないでください。計算された値を読み取るか、数式に依存するチャート データを保存する前に、必ず [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) を呼び出してください。

サポート外の数式については、Aspose.Slides が数式を解析できなかったり依存関係を特定できなかったりする可能性があります。ワークブックが変更された場合、以前のキャッシュ値は信頼できません。そのような状況で未サポートのデータを持つセルの値を取得しようとすると、[CellUnsupportedDataException](https://reference.aspose.com/slides/ja/java/com.aspose.slides/cellunsupporteddataexception/) がスローされることがあります。

Excel の関数で Aspose.Slides が評価できないものがある場合は、対応するスプレッドシート エンジンで数式を計算し、結果の値をチャート ワークブックに書き戻してください。未サポートの数式を推測した値で置き換えてはいけません。

## **数式エラーの処理**

区別すべき問題は 2 種類あります。

* 数式自体は有効だが、`#DIV/0!`、`#N/A`、`#NAME?`、`#NULL!`、`#NUM!`、`#REF!`、`#VALUE!` といったスプレッドシート エラー結果を生成する場合。 この場合エラー トークンはセルの結果として返され、[IChartDataCell.getValue](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdatacell/#getValue--) で取得できます。
* 数式が構文エラー、参照エラー、依存関係エラー、または未サポートデータのレベルで失敗する場合。Aspose.Slides はこれらのケースに対して [CellInvalidFormulaException](https://reference.aspose.com/slides/ja/java/com.aspose.slides/cellinvalidformulaexception/)、[CellInvalidReferenceException](https://reference.aspose.com/slides/ja/java/com.aspose.slides/cellinvalidreferenceexception/)、[CellCircularReferenceException](https://reference.aspose.com/slides/ja/java/com.aspose.slides/cellcircularreferenceexception/)、[CellUnsupportedDataException](https://reference.aspose.com/slides/ja/java/com.aspose.slides/cellunsupporteddataexception/) といったスプレッドシート固有の例外を提供します。

テンプレートやユーザー入力から数式が供給される場合は、再計算と値取得の周囲でこれらの例外をハンドルしてください。

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

チャート ワークシートにおける数式サポートは、完全な Excel 互換性を提供するものではなく、定義されたサブセットの計算に限定されています。レポーティング ワークフローを設計する際は、以下の点に留意してください。

* Aspose.Slides に数式を再計算させる必要がある場合は、ドキュメント化された定数、演算子、参照、関数のみを使用してください。
* セルの変更後は必ず再計算してください。
* 読み込んだプレゼンテーションからのキャッシュ値はスナップショットとして扱い、編集後の再計算の代替としないでください。
* 既存テンプレートからの数式は、ドキュメント化されたリスト外の関数を使用している場合、計算結果を信頼する前に必ずテストしてください。
* 完全なスプレッドシート計算エンジンが必要な数式は、外部で計算し、結果の値をチャート ワークブックに書き戻してください。

## **FAQ**

**[IChartDataCell.setFormula](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) と [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) の違いは何ですか？**

[IChartDataCell.setFormula](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) は `B2-C2` のような A1 形式の式を保存し、[IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) は `RC[-2]-RC[-1]` のような R1C1 形式の式を保存します。数式を生成またはコピーする方法に最も適した表記を使用してください。

**計算後はセル自体を読むべきですか、それとも値を読むべきですか？**

[IChartDataWorkbook.getCell](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdataworkbook/#getCell-int-java.lang.String-) は [IChartDataCell](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdatacell/) を返します。再計算後に計算結果を取得するには、そのセルの [IChartDataCell.getValue](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdatacell/#getValue--) メソッドを呼び出してください。

**[IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) はいつ呼び出すべきですか？**

入力値または数式を変更した後、計算結果に依存する前に必ず [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) を呼び出してください。これにより組み込み評価エンジンがサポートする数式の値が更新されます。

**Aspose.Slides はすべての Excel 関数をサポートしていますか？**

いいえ。組み込み評価エンジンはドキュメント化されたサブセットのみをサポートします。サブセット外の関数は正しく再計算できると想定しないでください。完全な Excel 互換が必要な場合は、適切なスプレッドシート エンジンで計算し、最終的な値をチャート ワークブックに書き込んでください。

**ロードされたプレゼンテーションに未サポートの数式が含まれていた場合はどうなりますか？**

チャート データが変更されていなければ、ワークブックは以前に計算されたキャッシュ値を保持している可能性があります。関連データが変更された後は、そのキャッシュ値は無効になることがあります。処理できない数式を含むセルの値にアクセスしようとすると、[CellUnsupportedDataException](https://reference.aspose.com/slides/ja/java/com.aspose.slides/cellunsupporteddataexception/) がスローされることがあります。

**数式エラー値は Java の例外と同じですか？**

いいえ。`#DIV/0!` などの結果は、有効な数式の計算によって生成されたスプレッドシートの値です。[CellInvalidFormulaException](https://reference.aspose.com/slides/ja/java/com.aspose.slides/cellinvalidformulaexception/) や [CellCircularReferenceException](https://reference.aspose.com/slides/ja/java/com.aspose.slides/cellcircularreferenceexception/) といった例外は、数式を正常に処理できなかったことを示します。

**数式セルが変更されたときにグラフは自動的に更新されますか？**

グラフ 系列はワークブックのセルを参照できます。まずワークブックを再計算し、次にプレゼンテーションを保存またはレンダリングしてください。系列が計算されたセルを参照していれば、グラフは更新されたセル値を使用します。別途のグラフ リフレッシュ メソッドは不要です。

**外部の Excel ワークブックをグラフに使用できますか？**

はい、チャート データ API を使って外部ワークブックを使用するよう構成できます。ただし、本記事で説明する数式計算ワークフローはチャート データ ワークブックと Aspose.Slides が評価できる数式サブセットに限定されます。[IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) が外部 XLSX ファイルの任意の数式を完全に再計算するとは限らないことに注意してください。

**別シートまたは別ブックを参照する数式は使用できますか？**

チャート ワークブック内で Excel 形式の参照は可能ですが、評価はサポートされているパーサーと関数セットに制限されます。クロスシートや外部参照が必須の場合は、対象の Aspose.Slides バージョンで正確に動作するか検証してください。広範な Excel 参照互換が必要な場合は、ワークブックを外部で計算し、解決された値をチャート データに書き戻すことを推奨します。

**数式文字列は `=` で始める必要がありますか？**

Aspose.Slides の API サンプルは `B2-C2` や `SUM(B2:B5)` のように先頭の `=` を付けずに式を割り当てます。この形を使用すると、ドキュメント化された API 例と一貫性が保たれます。