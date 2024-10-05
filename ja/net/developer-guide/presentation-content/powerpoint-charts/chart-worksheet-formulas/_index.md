---
title: チャートワークシートの数式
type: docs
weight: 70
url: /net/chart-worksheet-formulas/
keywords: "チャート スプレッドシート, チャート数式, PowerPoint プレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C# または .NET の PowerPoint プレゼンテーションにおけるチャート スプレッドシートと数式"
---

## **プレゼンテーションにおけるチャート スプレッドシート数式について**
**チャート スプレッドシート**（またはチャート ワークシート）は、プレゼンテーションにおけるチャートのデータソースです。チャート スプレッドシートには、チャート上にグラフィック的に表示されるデータが含まれています。PowerPoint でチャートを作成すると、このチャートに関連付けられたワークシートも自動的に作成されます。チャート ワークシートは、すべてのタイプのチャート（折れ線グラフ、棒グラフ、サンバースト グラフ、円グラフなど）に対して作成されます。PowerPoint でチャート スプレッドシートを見るには、チャートをダブルクリックする必要があります：

![todo:image_alt_text](chart-worksheet-formulas_1.png)

チャート スプレッドシートには、チャート要素の名前（カテゴリ名: *Category1*、シリーズ名）と、これらのカテゴリおよびシリーズに対応する数値データを含む表が含まれています。デフォルトでは、新しいチャートを作成すると、チャート スプレッドシートデータはデフォルトデータに設定されます。その後、ワークシート内のスプレッドシートデータを手動で変更できます。

通常、チャートは複雑なデータを表します（例：財務アナリスト、科学アナリスト）で、他のセルの値または他の動的データから計算されたセルを持っています。セルの値を手動で計算し、セルにハードコーディングすると、将来的に変更するのが難しくなります。特定のセルの値を変更すると、それに依存するすべてのセルも更新する必要があります。さらに、テーブルデータは他のテーブルのデータに依存する場合があり、簡単かつ柔軟に更新する必要がある複雑なプレゼンテーションデータスキームを作成します。

プレゼンテーションにおける**チャート スプレッドシート数式**は、チャート スプレッドシートデータを自動的に計算し、更新するための式です。スプレッドシート数式は、特定のセルまたはセルのセットに対するデータ計算ロジックを定義します。スプレッドシート数式は、数式または論理式であり、以下を使用します：セル参照、数学関数、論理演算子、算術演算子、変換関数、文字列定数など。数式の定義はセルに書き込まれ、このセルは単純な値を含みません。スプレッドシート数式は値を計算して返し、その値がセルに割り当てられます。プレゼンテーションのチャート スプレッドシート数式は実際には Excel の数式と同じであり、実装には同じデフォルトの関数、演算子、および定数がサポートされています。

[**Aspose.Slides**](https://products.aspose.com/slides/net/)では、チャート スプレッドシートは
[**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/properties/chartdataworkbook)プロパティで示され 
[**IChartDataWorkbook**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook)型のプロパティです。
スプレッドシート数式は
[**IChartDataCell.Formula**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/formula)プロパティで割り当てて変更できます。 
Aspose.Slides で数式に対してサポートされる機能は次のとおりです：

- 論理定数
- 数値定数
- 文字列定数
- エラー定数
- 算術演算子
- 比較演算子
- A1 スタイルセル参照
- R1C1スタイルセル参照
- 事前定義関数

通常、スプレッドシートは最後に計算された数式値を保存します。プレゼンテーションの読み込み後にチャート データが変更されなかった場合、**IChartDataCell.Value**プロパティは、読み取り時にそれらの値を返します。しかし、スプレッドシートデータが変更された場合、**ChartDataCell.Value**プロパティを読み取ると、サポートされていない数式の場合に**CellUnsupportedDataException**がスローされます。これは、数式が正常に解析された場合に、セルの依存関係が決定され、最後の値の正確性が決定されるためです。ただし、数式が解析できない場合、セル値の正確性を保証することはできません。

## **プレゼンテーションにチャート スプレッドシート数式を追加する**
まず、新しいプレゼンテーションの最初のスライドにサンプルデータを含むチャートを追加します。
[IShapeCollection.Shapes.AddChart](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/addchart/methods/1)。 
チャートのワークシートは自動的に作成され、以下のプロパティを使用してアクセスできます：
[**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/properties/chartdataworkbook)プロパティ：

```csharp
using (var presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 150, 150, 500, 300);
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    // ...
}
```

次に、[**IChartDataCell.Value**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/value)プロパティを使用して、**Object**型の値をセルに書き込みます。これは、任意の値をプロパティに設定できることを意味します：

```csharp
workbook.GetCell(0, "F2").Value = -2.5;
workbook.GetCell(0, "G3").Value = 6.3;
workbook.GetCell(0, "H4").Value = 3;
```

次に、セルに数式を書くには、[**IChartDataCell.Formula**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/formula)プロパティを使用できます：

```csharp
workbook.GetCell(0, "B2").Formula = "F2+G3+H4+1";
```

*注意*: [**IChartDataCell.Formula**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/formula)プロパティは、A1スタイルのセル参照を設定するために使用されます。

[R1C1Formula](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/r1c1formula)セル参照を設定するには、[**IChartDataCell.R1C1Formula**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/properties/r1c1formula)プロパティを使用できます：

```csharp
workbook.GetCell(0, "C2").R1C1Formula = "R[1]C[4]/R[2]C[5]";
```

次に、[**IChartDataWorkbook.CalculateFormulas**](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdataworkbook/methods/calculateformulas)メソッドを使用して、ワークブック内のすべての数式を計算し、対応するセル値を更新します：

```csharp
workbook.CalculateFormulas();
object value1 = workbook.GetCell(0, "B2"); // 7.8
object value2 = workbook.GetCell(0, "C2"); // 2.1
```

## **論理定数**
セルの数式で *FALSE* と *TRUE* のような論理定数を使用できます：

## **数値定数**
数値は、一般的または科学的な表記でチャート スプレッドシート数式を作成するために使用できます：

## **文字列定数**
文字列（またはリテラル）定数は、使用される特定の値であり、そのまま変わりません。文字列定数は、日付、テキスト、数値などです：

## **エラー定数**
時々、数式によって結果を計算することができない場合があります。その場合、エラーコードがセルに表示され、その値の代わりに表示されます。各タイプのエラーには特定のコードがあります：

- #DIV/0! - 数式がゼロで割ろうとしています。
- #GETTING_DATA - セルに表示される場合がありますが、その値はまだ計算中です。
- #N/A - 情報が欠落しているか、利用できません。理由のいくつかは、数式で使用されるセルが空であること、余分なスペース文字、誤字などです。
- #NAME? - 特定のセルまたは他の数式オブジェクトをその名前で見つけることができません。
- #NULL! - 数式に誤りがある場合に表示される可能性があります。たとえば、(,)またはコロン(:)の代わりにスペース文字を使用しています。
- #NUM! - 数式内の数値が無効である、または長すぎるか小さすぎるなどです。
- #REF! - 無効なセル参照。
- #VALUE! - 予期しない値の型。たとえば、文字列値が数値セルに設定されます。

## **算術演算子**
チャート ワークシート数式で、すべての算術演算子を使用できます：

|**演算子** |**意味** |**例**|
| :- | :- | :- |
|+ (プラス符号) |加算または単項プラス|2 + 3|
|- (マイナス符号) |減算または否定 |2 - 3<br>-3|
|* (アスタリスク)|乗算 |2 * 3|
|/ (スラッシュ)|除算 |2 / 3|
|% (パーセント記号) |パーセント |30%|
|^ (キャレット) |累乗 |2 ^ 3|

*注意*: 評価の順序を変更するには、最初に計算される部分の数式を括弧で囲んでください。

## **比較演算子**
比較演算子を使用して、セルの値を比較できます。これらの演算子を使用して 2 つの値を比較すると、結果は論理値のいずれか *TRUE* または FALSE になります：

|**演算子** |**意味** |**意味** |
| :- | :- | :- |
|= (等号) |等しい |A2 = 3|
|<> (不等号) |等しくない|A2 <> 3|
|> (大なり) |より大きい|A2 > 3|
|>= (大なりまたは等号)|以上|A2 >= 3|
|< (小なり)|より小さい|A2 < 3|
|<= (小なりまたは等号)|以下|A2 <= 3|

## **A1スタイルセル参照**
**A1スタイルセル参照**は、列が文字識別子（例： "*A*"）で、行が数値識別子（例： "*1*"）を持つワークシートで使用されます。A1スタイルセル参照は、次のように使用できます：

|**セル参照**|**例**|||
| :- | :- | :- | :- |
||絶対 |相対 |混合|
|セル |$A$2 |A2|<p>A$2</p><p>$A2</p>|
|行 |$2:$2 |2:2 |-|
|列 |$A:$A |A:A |-|
|範囲 |$A$2:$C$4 |A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

数式で A1 スタイルセル参照を使用する方法の例を次に示します：

## **R1C1スタイルセル参照**
**R1C1スタイルセル参照**は、行と列の両方が数値識別子を持つワークシートで使用されます。R1C1スタイルセル参照は、次のように使用できます：

|**セル参照**|**例**|||
| :- | :- | :- | :- |
||絶対 |相対 |混合|
|セル |R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|行 |R2|R[2]|-|
|列 |C3|C[3]|-|
|範囲 |R2C3:R5C7|R[2]C[3]:R[5]C[7] |R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

数式で A1 スタイルセル参照を使用する方法の例を次に示します：

## **事前定義された関数**
数式の実装を簡素化するために使用できる事前定義関数があります。これらの関数は、最も一般的に使用される操作をカプセル化します。以下はその例です：

- ABS
- AVERAGE
- CEILING
- CHOOSE
- CONCAT
- CONCATENATE
- DATE (1900 年日付システム)
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