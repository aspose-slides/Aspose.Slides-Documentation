---
title: C++ を使用したプレゼンテーションでチャート ワークシート数式を適用する
linktitle: ワークシート数式
type: docs
weight: 70
url: /ja/cpp/chart-worksheet-formulas/
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
- C++
- Aspose.Slides
description: "Aspose.Slides の C++ 用チャート ワークシートで Excel スタイルの数式を適用し、PPT および PPTX ファイル全体でレポートを自動化します。"
---

## **プレゼンテーションにおけるチャートスプレッドシート数式について**
**Chart spreadsheet**（または chart worksheet）は、プレゼンテーション内のチャートのデータ ソースです。Chart spreadsheet には、チャート上にグラフィカルに表示されるデータが含まれます。PowerPoint でチャートを作成すると、同時にこのチャートに関連付けられたワークシートが自動的に作成されます。Chart worksheet は、折れ線グラフ、棒グラフ、サンバースト グラフ、円グラフなど、すべての種類のチャートに対して作成されます。PowerPoint で chart spreadsheet を表示するには、チャートをダブルクリックしてください：

![todo:image_alt_text](chart-worksheet-formulas_1.png)



Chart spreadsheet には、チャート要素の名前（Category Name: *Category1*, Serie Name）と、これらのカテゴリと系列に対応する数値データの表が含まれます。デフォルトでは、新しいチャートを作成すると chart spreadsheet のデータは既定のデータで設定されます。その後、ワークシート内のスプレッドシート データを手動で変更できます。

通常、チャートは複雑なデータ（例: 財務アナリスト、科学アナリストが使用するデータ）を表し、他のセルの値や動的データから計算されたセルを持ちます。セルの値を手動で計算してハードコーディングすると、将来変更しにくくなります。特定のセルの値を変更すると、そのセルに依存するすべてのセルも更新が必要になります。さらに、表データが他の表のデータに依存することがあり、簡単かつ柔軟に更新できるプレゼンテーション データ スキーマが必要になります。

**Chart spreadsheet formula** とは、チャートスプレッドシート データを自動的に計算・更新する式です。スプレッドシート数式は、特定のセルまたはセルの集合に対するデータ計算ロジックを定義します。スプレッドシート数式は、セル参照、数学関数、論理演算子、算術演算子、変換関数、文字列定数などを使用した数式または論理式です。数式の定義はセルに書き込まれ、そのセルは単純な値を保持しません。スプレッドシート数式は値を計算し、セルにその結果を割り当てます。プレゼンテーション内の chart spreadsheet formula は実質的に Excel の数式と同じで、同じ既定の関数・演算子・定数がサポートされています。

[**Aspose.Slides**](https://products.aspose.com/slides/cpp/) では、chart spreadsheet は
[**ChartData::get_ChartDataWorkbook()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.chart_data#a32097093561723a10df0a57dc91acaea) メソッドで表される
[**IChartDataWorkbook**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_workbook) 型によって提供されます。スプレッドシート数式は
[**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692) メソッドで割り当ておよび変更できます。Aspose.Slides で数式に対してサポートされている機能は次のとおりです。

- 論理定数
- 数値定数
- 文字列定数
- エラー定数
- 算術演算子
- 比較演算子
- A1 形式のセル参照
- R1C1 形式のセル参照
- 事前定義関数



通常、スプレッドシートは最後に計算された数式の値を保存します。プレゼンテーションの読み込み後にチャート データが変更されていなければ、**IChartDataCell.get_Value()** メソッドはそれらの値を返します。しかし、スプレッドシート データが変更された場合、**ChartDataCell.get_Value()** メソッドはサポートされていない数式に対して **CellUnsupportedDataException** をスローします。これは、数式が正常に解析されたときにセルの依存関係が確定し、最終値の正確性が判断されるためです。数式が解析できない場合、セル値の正確性は保証できません。


## **プレゼンテーションにチャートスプレッドシート数式を追加する**
まず、[IShapeCollection::AddChart()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape_collection#a2cd4d47fc5c536012ee15b3a69486374) を使用して新しいプレゼンテーションの最初のスライドにチャートを追加します。チャートのワークシートは自動的に作成され、次のメソッドでアクセスできます。
[**ChartData::get_ChartDataWorkbook()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.chart_data#a32097093561723a10df0a57dc91acaea)：
``` cpp
auto presentation = System::MakeObject<Presentation>();
    
auto chart = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 150.0f, 150.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

// ...
```




**Object** 型の
[**IChartDataCell.set_Value()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_cell#ad85809f520195e09225abae9002635ec) メソッドを使用してセルにいくつかの値を書き込みます。この型は任意の値をメソッドに渡せることを意味します：
``` cpp
workbook->GetCell(0, u"F2")->set_Value(System::ObjectExt::Box<double>(-2.5));
workbook->GetCell(0, u"G3")->set_Value(System::ObjectExt::Box<double>(6.3));
workbook->GetCell(0, u"H4")->set_Value(System::ObjectExt::Box<int32_t>(3));
```




数式を書き込むには、次のメソッドを使用します。
[**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692)：





*Note*: [**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692) メソッドは A1 形式のセル参照を設定するために使用されます。  



R1C1 形式のセル参照を設定するには、[**IChartDataCell::set_R1C1Formula()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_cell#a47f5825dd38d0dddb11ecc3a43d388c7) メソッドを使用します：





その後、セル B2 と C2 の値を読み取ろうとすると、計算された結果が得られます：
``` cpp
auto value1 = cell1->get_Value(); // 7.8
auto value2 = cell2->get_Value(); // 2.1
```



## **論理定数**
セル数式で *FALSE* と *TRUE* のような論理定数を使用できます：




## **数値定数**
数式で数値定数は通常表記または指数表記で使用できます：




## **文字列定数**
文字列（リテラル）定数はそのまま使用され、変更されません。文字列定数には日付、テキスト、数値などが含まれます：




## **エラー定数**
数式で結果を計算できない場合、セルにはエラーコードが表示されます。各エラータイプには固有のコードがあります：

- #DIV/0! - 数式がゼロで除算しようとした場合。
- #GETTING_DATA - セルの値がまだ計算中であることを示す場合。
- #N/A - 情報が欠落または利用できない場合。例: 参照セルが空、余分なスペース文字、スペルミスなど。
- #NAME? - 指定された名前のセルまたは他の数式オブジェクトが見つからない場合。
- #NULL! - 数式に誤りがある場合（例: (,) やコロン (:) の代わりにスペース文字が使用された場合）。
- #NUM! - 数式中の数値が無効、桁数が多すぎる、または小さすぎる場合。
- #REF! - 無効なセル参照。
- #VALUE! - 予期しないデータ型。例: 文字列が数値セルに設定された場合。




## **算術演算子**
チャート ワークシートの数式ではすべての算術演算子を使用できます：



|**Operator**|**Meaning**|**Example**|
| :- | :- | :- |
|+ (plus sign)|加算または単項プラス|2 + 3|
|- (minus sign)|減算または単項マイナス|2 - 3<br>-3|
|* (asterisk)|乗算|2 * 3|
|/ (forward slash)|除算|2 / 3|
|% (percent sign)|パーセント|30%|
|^ (caret)|べき乗|2 ^ 3|


*Note*: 評価順序を変更するには、先に計算したい部分を丸括弧で囲んでください。


## **比較演算子**
比較演算子を使用してセルの値を比較できます。これらの演算子で比較された結果は、*TRUE* または FALSE の論理値になります：



|**Operator**|**Meaning**|**Example**|
| :- | :- | :- |
|= (equal sign)|等しい|A2 = 3|
|<> (not equal sign)|等しくない|A2 <> 3|
|> (greater than sign)|大きい|A2 > 3|
|>= (greater than or equal to sign)|以上|A2 >= 3|
|< (less than sign)|小さい|A2 < 3|
|<= (less than or equal to sign)|以下|A2 <= 3|

## **A1 形式のセル参照**
**A1 形式のセル参照** は、列がアルファベット文字（例: "*A*"）で行が数字（例: "*1*"）で表されるワークシートで使用されます。A1 形式のセル参照は次のように使用できます：



|**Cell reference**|**Absolute**|**Relative**|**Mixed**|
| :- | :- | :- | :- |
|Cell|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Row|$2:$2|2:2|-|
|Column|$A:$A|A:A|-|
|Range|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


以下は、数式で A1 形式のセル参照を使用する例です：




## **R1C1 形式のセル参照**
**R1C1 形式のセル参照** は、行と列の両方が数字で表されるワークシートで使用されます。R1C1 形式のセル参照は次のように使用できます：



|**Cell reference**|**Absolute**|**Relative**|**Mixed**|
| :- | :- | :- | :- |
|Cell|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Row|R2|R[2]|-|
|Column|C3|C[3]|-|
|Range|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


以下は、数式で A1 形式のセル参照を使用する例です：




## **事前定義関数**
数式で使用できる事前定義関数があります。これらの関数は、次のような一般的に使用される操作をカプセル化します：


- ABS
- AVERAGE
- CEILING
- CHOOSE
- CONCAT
- CONCATENATE
- DATE (1900 date system)
- DAYS
- FIND
- FINDB
- IF
- INDEX (reference form)
- LOOKUP (vector form)
- MATCH (vector form)
- MAX
- SUM
- VLOOKUP

## **FAQ**

**数式付きチャートのデータ ソースとして外部 Excel ファイルはサポートされていますか？**

はい。Aspose.Slides は、プレゼンテーション外部の XLSX から数式を使用できるように、[chart のデータ ソース](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdatasourcetype/)として外部ブックをサポートしています。

**チャート数式は、同じブック内のシート名でシートを参照できますか？**

はい。数式は標準的な Excel 参照モデルに従うため、同じブック内または外部ブックの他シートを参照できます。外部参照の場合は、Excel の構文でパスとブック名を含めてください。