---
title: チャート ワークシートの数式
type: docs
weight: 70
url: /ja/cpp/chart-worksheet-formulas/
keywords: "powerpoint の数式, powerpoint スプレッドシート数式"
description: "PowerPoint の数式とスプレッドシート数式"
---


## **プレゼンテーションにおけるチャート スプレッドシート数式について**
**チャート スプレッドシート**（またはチャート ワークシート）は、プレゼンテーションのチャートのデータ ソースです。チャート スプレッドシートには、グラフィック的に表現されたデータが含まれています。PowerPoint でチャートを作成すると、そのチャートに関連付けられたワークシートも自動的に作成されます。チャート ワークシートは、すべての種類のチャート（折れ線グラフ、棒グラフ、サンバーストグラフ、円グラフなど）のために作成されます。PowerPoint でチャート スプレッドシートを表示するには、チャートをダブルクリックしてください：

![todo:image_alt_text](chart-worksheet-formulas_1.png)



チャート スプレッドシートには、チャート要素の名前（カテゴリ名: *Category1*、シリーズ名）と、これらのカテゴリおよびシリーズに適した数値データのテーブルが含まれています。デフォルトでは、新しいチャートを作成すると、チャート スプレッドシート データがデフォルト データで設定されます。その後、ワークシート内のスプレッドシート データを手動で変更することができます。

通常、チャートは複雑なデータ（例: 財務アナリスト、科学アナリスト）を表し、他のセルや他の動的データの値から計算されるセルを持っています。セルの値を手動で計算し、そのセルにハードコーディングすると、将来的に変更することが難しくなります。特定のセルの値を変更すると、そのセルに依存するすべてのセルも更新する必要があります。さらに、テーブルデータは他のテーブルのデータに依存することがあり、簡単かつ柔軟に更新する必要のある複雑なプレゼンテーション データ スキーマを作成します。

**プレゼンテーションにおけるチャート スプレッドシート数式**は、チャート スプレッドシート データを自動的に計算および更新するための式です。スプレッドシート数式は、特定のセルまたはセルのセットに対するデータ計算ロジックを定義します。スプレッドシート数式は、セル参照、数学関数、論理演算子、算術演算子、変換関数、文字列定数などを使用した数式または論理式です。数式の定義はセルに書き込まれ、このセルには単純な値は含まれていません。スプレッドシート数式は値を計算して返し、その後この値がセルに割り当てられます。プレゼンテーションのチャート スプレッドシート数式は、実際には Excel 数式と同じであり、その実装には同じデフォルトの関数、演算子、定数がサポートされています。

[**Aspose.Slides**](https://products.aspose.com/slides/cpp/) では、チャート スプレッドシートは、[**ChartData::get_ChartDataWorkbook()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.chart_data#a32097093561723a10df0a57dc91acaea) メソッドの [**IChartDataWorkbook**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_workbook) 型で表されます。 スプレッドシート数式は、[**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692) メソッドで設定および変更できます。 Aspose.Slides における数式のための以下の機能がサポートされています：

- 論理定数
- 数値定数
- 文字列定数
- エラー定数
- 算術演算子
- 比較演算子
- A1スタイルのセル参照
- R1C1スタイルのセル参照
- 事前定義された関数



通常、スプレッドシートは最後に計算された数式の値を保持します。プレゼンテーションを読み込んだ後、チャート データが変更されていない場合、**IChartDataCell.get_Value()** メソッドは、その値を読み取ります。しかし、スプレッドシート データが変更されている場合、**ChartDataCell.get_Value()** メソッドを読み取ると、サポートされていない数式に対して **CellUnsupportedDataException** をスローします。これは、数式が正常に解析されるとセルの依存関係が決定され、最後の値の正しさが確認されるからです。しかし、数式が解析できない場合、そのセルの値の正しさは保証されません。


## **プレゼンテーションにチャート スプレッドシート数式を追加する**
最初に、新しいプレゼンテーションの最初のスライドにチャートを追加します。これは、[IShapeCollection::AddChart()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection#a2cd4d47fc5c536012ee15b3a69486374) を使用します。 チャートのワークシートは自動的に作成され、[**ChartData::get_ChartDataWorkbook()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.chart_data#a32097093561723a10df0a57dc91acaea) メソッドでアクセスできます：



``` cpp
auto presentation = System::MakeObject<Presentation>();
    
auto chart = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 150.0f, 150.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

// ...
```



次に、[**IChartDataCell.set_Value()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_cell#ad85809f520195e09225abae9002635ec) メソッドを使用してセルに値を書き込みます。**Object** 型であるため、メソッドに任意の値を渡すことができます：

``` cpp
workbook->GetCell(0, u"F2")->set_Value(System::ObjectExt::Box<double>(-2.5));
workbook->GetCell(0, u"G3")->set_Value(System::ObjectExt::Box<double>(6.3));
workbook->GetCell(0, u"H4")->set_Value(System::ObjectExt::Box<int32_t>(3));
```



セルに数式を書き込むには、[**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692) メソッドを使用できます：

*注*: [**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692) メソッドは A1 スタイルのセル参照を設定するために使用されます。



R1C1Formula セル参照を設定するには、[**IChartDataCell::set_R1C1Formula()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_cell#a47f5825dd38d0dddb11ecc3a43d388c7) メソッドを使用できます：



その後、B2 および C2 セルから値を読み取ると、それらは計算されます：

``` cpp
auto value1 = cell1->get_Value(); // 7.8
auto value2 = cell2->get_Value(); // 2.1
```


## **論理定数**
セル数式では、*FALSE* や *TRUE* などの論理定数を使用できます：




## **数値定数**
数字は、一般的または科学的な表記法でチャート スプレッドシート数式を作成するために使用できます：




## **文字列定数**
文字列（またはリテラル）定数は、そのまま使用され、変更されない特定の値です。文字列定数には、日付、テキスト、数値などが含まれる場合があります：




## **エラー定数**
数式によって結果を計算することができない場合があります。その場合、値の代わりにセルにエラーコードが表示されます。各エラーの種類には特定のコードがあります：

- #DIV/0！ - 数式がゼロで割ろうとしています。
- #GETTING_DATA - 値がまだ計算中の間、セルに表示されることがあります。
- #N/A - 情報が不足しているか、利用できません。原因には、数式で使用されているセルが空である、余分なスペース文字、スペルミスなどが含まれます。
- #NAME？ - 特定のセルまたは他の数式オブジェクトがその名前で見つからない場合。
- #NULL！ - 数式に間違いがある場合に表示されることがあります（例: (,) またはコロン(:) の代わりにスペース文字が使用されているなど）。
- #NUM！ - 数式内の数値が無効、長すぎる、または短すぎる場合など。
- #REF！ - 無効なセル参照。
- #VALUE！ - 予期しない値の型。たとえば、文字列値が数値セルに設定されている場合。




## **算術演算子**
チャート ワークシートの数式では、すべての算術演算子を使用できます：



|**演算子** |**意味** |**例**|
| :- | :- | :- |
|+（プラス記号） |加算または単項プラス|2 + 3|
|-（マイナス記号） |減算または否定 |2 - 3<br>-3|
|*（アスタリスク）|乗算 |2 * 3|
|/（スラッシュ）|除算 |2 / 3|
|%（パーセント記号） |パーセント |30%|
|^（キャレット） |累乗 |2 ^ 3|


*注*: 評価の順序を変更するには、計算する部分を括弧で囲みます。


## **比較演算子**
比較演算子を使用してセルの値を比較できます。これらの演算子を使用して二つの値を比較すると、その結果は論理値 (TRUE または FALSE) になります：



|**演算子** |**意味** |**意味** |
| :- | :- | :- |
|=（等号） |等しい |A2 = 3|
|<>（不等号） |等しくない|A2 <> 3|
|>（大なり記号） |より大きい|A2 > 3|
|>=（以上記号）|以上|A2 >= 3|
|<（小なり記号）|より小さい|A2 < 3|
|<=（以下記号）|以下|A2 <= 3|

## **A1スタイルのセル参照**
**A1スタイルのセル参照**は、列が文字の識別子（例: "*A*"）であり、行が数値の識別子（例: "*1*"）であるワークシートで使用されます。A1スタイルのセル参照は次のように使用できます：



|**セル参照**|**例**|||
| :- | :- | :- | :- |
||絶対 |相対 |混合|
|セル |$A$2 |A2|<p>A$2</p><p>$A2</p>|
|行 |$2:$2 |2:2 |-|
|列 |$A:$A |A:A |-|
|範囲 |$A$2:$C$4 |A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


数式で A1 スタイルのセル参照を使用する例は次のとおりです：




## **R1C1スタイルのセル参照**
**R1C1スタイルのセル参照**は、行と列の両方に数値の識別子があるワークシートで使用されます。 R1C1スタイルのセル参照は次のように使用できます：



|**セル参照**|**例**|||
| :- | :- | :- | :- |
||絶対 |相対 |混合|
|セル |R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|行 |R2|R[2]|-|
|列 |C3|C[3]|-|
|範囲 |R2C3:R5C7|R[2]C[3]:R[5]C[7] |R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


数式で A1 スタイルのセル参照を使用する例は次のとおりです：




## **事前定義された関数**
数式の実装を簡素化するために、事前定義された関数が用意されています。これらの関数は、一般的に使用される操作をカプセル化しています。たとえば：

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