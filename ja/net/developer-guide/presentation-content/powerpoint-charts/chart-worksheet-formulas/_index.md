---
title: .NET でプレゼンテーションにチャートワークシート数式を適用する
linktitle: ワークシート数式
type: docs
weight: 70
url: /ja/net/chart-worksheet-formulas/
keywords:
- チャートスプレッドシート
- チャートワークシート
- チャート数式
- ワークシート数式
- スプレッドシート数式
- データソース
- 論理定数
- 数値定数
- 文字列定数
- エラー定数
- 算術定数
- 比較演算子
- A1 スタイル
- R1C1 スタイル
- 事前定義関数
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET のチャートワークシートで Excel 形式の数式を適用し、PPT および PPTX ファイル全体でレポートを自動化します。"
---

## **プレゼンテーションにおけるチャートスプレッドシート数式について**
**Chart spreadsheet**（または chart worksheet）は、プレゼンテーション内のチャートのデータ ソースです。 Chart spreadsheet にはデータが含まれ、チャート上にグラフィカルに表現されます。PowerPoint でチャートを作成すると、このチャートに関連付けられたワークシートも自動的に作成されます。チャートワークシートは、折れ線グラフ、棒グラフ、サンバースト グラフ、円グラフなど、すべてのチャート タイプで作成されます。PowerPoint でチャートスプレッドシートを表示するには、チャートをダブルクリックします:

![todo:image_alt_text](chart-worksheet-formulas_1.png)



Chart spreadsheet には、チャート要素の名前（カテゴリ名: *Category1*、シリーズ名）と、これらのカテゴリとシリーズに対応する数値データの表が含まれます。デフォルトでは、新しいチャートを作成すると、チャートスプレッドシートのデータは既定のデータで設定されます。その後、ワークシート内のデータを手動で変更できます。

通常、チャートは複雑なデータ（例: 財務アナリスト、科学アナリスト）が対象で、他のセルの値や動的データから計算されたセルを持ちます。セルの値を手動で計算しハードコーディングすると、将来変更しにくくなります。特定のセルの値を変更すると、それに依存するすべてのセルも更新が必要になります。さらに、表データが他の表のデータに依存することがあり、更新が容易で柔軟なプレゼンテーション データ スキーマが求められます。

**Chart spreadsheet formula** は、チャートスプレッドシートのデータを自動的に計算・更新する式です。スプレッドシート数式は、特定のセルまたはセルの集合のデータ計算ロジックを定義します。スプレッドシート数式は、セル参照、数式関数、論理演算子、算術演算子、変換関数、文字列定数などを使用する数式または論理式です。数式の定義はセルに記述され、セルは単純な値を保持しません。スプレッドシート数式は値を計算して返し、その値がセルに割り当てられます。プレゼンテーション内のチャートスプレッドシート数式は実質的に Excel の数式と同じで、同じ既定の関数、演算子、定数がサポートされます。

[**Aspose.Slides**](https://products.aspose.com/slides/net/) では、チャートスプレッドシートは 
[**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/properties/chartdataworkbook) プロパティの 
[**IChartDataWorkbook**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook) 型で表されます。 
スプレッドシート数式は 
[**IChartDataCell.Formula**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/formula) プロパティで設定および変更できます。 
Aspose.Slides でサポートされる数式機能は次のとおりです:

- 論理定数
- 数値定数
- 文字列定数
- エラー定数
- 算術演算子
- 比較演算子
- A1 形式のセル参照
- R1C1 形式のセル参照
- 事前定義関数



通常、スプレッドシートは最後に計算された数式の値を保存します。プレゼンテーションのロード後にチャート データが変更されていない場合、**IChartDataCell.Value** プロパティはそれらの値を返します。ただし、スプレッドシート データが変更されている場合、**ChartDataCell.Value** プロパティの取得時にサポートされていない数式に対して **CellUnsupportedDataException** がスローされます。これは、数式が正常に解析されたときにセル依存関係が確定し、最後の値の正確性が判断されるためです。数式が解析できない場合、セル値の正確性は保証できません。
## **プレゼンテーションにチャートスプレッドシート数式を追加する**
まず、[IShapeCollection.Shapes.AddChart](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/addchart/methods/1) を使用して、新しいプレゼンテーションの最初のスライドにサンプル データを持つチャートを追加します。チャートのワークシートは自動的に作成され、次のプロパティでアクセスできます: 
[**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/properties/chartdataworkbook) プロパティ:
``` csharp

using (var presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 150, 150, 500, 300);
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    // ...
}
```




**Object** 型の [**IChartDataCell.Value**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/value) プロパティを使用して、セルに任意の値を設定できます:
``` csharp

workbook.GetCell(0, "F2").Value = -2.5;

workbook.GetCell(0, "G3").Value = 6.3;

workbook.GetCell(0, "H4").Value = 3;

```




数式をセルに書き込むには、[**IChartDataCell.Formula**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/formula) プロパティを使用します:
``` csharp
workbook.GetCell(0, "B2").Formula = "F2+G3+H4+1";
```


*注*: [**IChartDataCell.Formula**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/formula) プロパティは A1 形式のセル参照を設定するために使用されます。 



R1C1 形式のセル参照を設定するには、[**IChartDataCell.R1C1Formula**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/r1c1formula) プロパティを使用します:
``` csharp
workbook.GetCell(0, "C2").R1C1Formula = "R[1]C[4]/R[2]C[5]";
```


次に、[**IChartDataWorkbook.CalculateFormulas**](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdataworkbook/methods/calculateformulas) メソッドを呼び出して、ブック内のすべての数式を計算し、対応するセルの値を更新します:
``` csharp
workbook.CalculateFormulas();

object value1 = workbook.GetCell(0, "B2"); // 7.8

object value2 = workbook.GetCell(0, "C2"); // 2.1

```



## **論理定数**
セル数式で *FALSE* および *TRUE* などの論理定数を使用できます:




## **数値定数**
数式で使用できる数値は、通常表記または科学的表記で記述できます:




## **文字列定数**
文字列（リテラル）定数は、そのまま使用され変更されない特定の値です。文字列定数には日付、テキスト、数値などが含まれます:




## **エラー定数**
数式で結果を計算できない場合、セルにはエラーコードが表示されます。エラーの種類ごとに特定のコードがあります:

- #DIV/0! - 数式がゼロ除算を試みた場合。
- #GETTING_DATA - セルの値がまだ計算中であることを示す場合。
- #N/A - 情報が欠落または利用不能。原因例: 参照セルが空、余分なスペース文字、綴りミスなど。
- #NAME? - セルまたは他の数式オブジェクトが名前で見つからない場合。
- #NULL! - 数式に誤りがある場合（例: (,) やコロン（:）の代わりにスペース文字が使用されたとき）。
- #NUM! - 数式内の数値が無効、長すぎる、または小さすぎる場合。
- #REF! - 無効なセル参照。
- #VALUE! - 予期しない型の値。例: 文字列が数値セルに設定された場合。




## **算術演算子**
チャートワークシートの数式ではすべての算術演算子を使用できます:

|**演算子**|**意味**|**例**|
| :- | :- | :- |
|+ (プラス記号)|加算または単項プラス|2 + 3|
|- (マイナス記号)|減算または否定|2 - 3<br>-3|
|* (アスタリスク)|乗算|2 * 3|
|/ (スラッシュ)|除算|2 / 3|
|% (パーセント記号)|パーセント|30%|
|^ (キャレット)|指数|2 ^ 3|

*注*: 評価順序を変更するには、先に計算したい部分を丸括弧で囲みます。


## **比較演算子**
比較演算子を使用してセルの値を比較できます。これらの演算子で比較した結果は、*TRUE* または FALSE の論理値になります:

|**演算子**|**意味**|**例**|
| :- | :- | :- |
|= (等号)|等しい|A2 = 3|
|<> (不等号)|等しくない|A2 <> 3|
|> (大なり記号)|大きい|A2 > 3|
|>= (大なりイコール)|以上|A2 >= 3|
|< (小なり記号)|小さい|A2 < 3|
|<= (小なりイコール)|以下|A2 <= 3|

## **A1 形式セル参照**
**A1 形式セル参照**は、列が文字識別子（例: "*A*"）で行が数値識別子（例: "*1*"）のワークシートで使用されます。A1 形式セル参照は次のように使用できます:

|**セル参照**|**例**|**絶対参照**|**相対参照**|**混合参照**|
| :- | :- | :- | :- | :- |
|セル|$A$2|A2|<p>A$2</p><p>$A2</p>|
|行|$2:$2|2:2|-|
|列|$A:$A|A:A|-|
|範囲|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

以下は、A1 形式セル参照を数式で使用する例です:




## **R1C1 形式セル参照**
**R1C1 形式セル参照**は、行も列も数値識別子を持つワークシートで使用されます。R1C1 形式セル参照は次のように使用できます:

|**セル参照**|**例**|**絶対参照**|**相対参照**|**混合参照**|
| :- | :- | :- | :- | :- |
|セル|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|行|R2|R[2]|-|
|列|C3|C[3]|-|
|範囲|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

以下は、R1C1 形式セル参照を数式で使用する例です:




## **事前定義関数**
数式で使用できる事前定義関数があり、実装を簡素化します。これらの関数は、次のような最も一般的に使用される操作をカプセル化します:

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

はい。Aspose.Slides は、[チャートのデータ ソース](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatasourcetype/) として外部ブックをサポートしており、プレゼンテーション外の XLSX から数式を使用できます。

**チャート数式は、同じブック内のシート名でシートを参照できますか？**

はい。数式は標準的な Excel 参照モデルに従うため、同じブック内または外部ブックの他シートを参照できます。外部参照の場合は、Excel の構文でパスとブック名を含めます。