---
title: "C++ を使用して PowerPoint テーブルの行と列を管理する"
linktitle: "行と列"
type: docs
weight: 20
url: /ja/cpp/manage-rows-and-columns/
keywords:
- "テーブル行"
- "テーブル列"
- "最初の行"
- "テーブルヘッダー"
- "行のクローン"
- "列のクローン"
- "行のコピー"
- "列のコピー"
- "行の削除"
- "列の削除"
- "行テキスト書式設定"
- "列テキスト書式設定"
- "テーブルスタイル"
- "PowerPoint"
- "プレゼンテーション"
- "C++"
- "Aspose.Slides"
description: "Aspose.Slides for C++ を使用して PowerPoint のテーブル行と列を管理し、プレゼンテーションの編集とデータ更新を高速化します。"
---
## **はじめに**

Aspose.Slides for C++ を使用すると、PowerPoint プレゼンテーションのテーブル構造と書式設定を [Table クラス](https://reference.aspose.com/slides/cpp/aspose.slides/table/) および [ITable インターフェイス](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) を介して管理できます。ヘッダー行を指定したり、行や列をクローンまたは削除したり、行または列全体にテキスト書式を適用したりできます。

この記事では、これらの操作を C++ の例とともに説明します。また、テーブルのスタイルプリセットを取得して再利用する方法も示します。テーブルの行と列のインデックスは 0 から始まります。

## **行の高さの制御**

[IRow::set_MinimalHeight](https://reference.aspose.com/slides/cpp/aspose.slides/irow/set_minimalheight/) を使用して、行の最小高さ（ポイント）を設定します。これは下限であり、固定高さではありません。[IRow::get_Height](https://reference.aspose.com/slides/cpp/aspose.slides/irow/get_height/) は実際の高さを返します。この値は直接設定できません。行は [ITable::get_Rows](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_rows/) から取得します。

この例は、最初のスライドの最初のシェイプとしてテーブルが配置された [row-height-input.pptx](row-height-input.pptx) をロードします。最初の行は 70 ポイントで始まります。セルは 18 ポイント Arial のテキスト、折り返し、上下 6 ポイントの余白を使用しています。2 列目の長いテキストは複数行に折り返されます。この例では最小高さを 100 ポイントに増やし、次に 20 ポイントに減らし、各変更後に実際の高さを表示し、両方の結果を保存します。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IRow.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"row-height-input.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));
auto row = table->get_Rows()->idx_get(0);

row->set_MinimalHeight(100);
Console::WriteLine(u"Increased: minimum = {0:F1}, actual = {1:F1} pt", row->get_MinimalHeight(), row->get_Height());
presentation->Save(u"row-height-increased.pptx", SaveFormat::Pptx);

row->set_MinimalHeight(20);
Console::WriteLine(u"Decreased: minimum = {0:F1}, actual = {1:F1} pt", row->get_MinimalHeight(), row->get_Height());
presentation->Save(u"row-height-decreased.pptx", SaveFormat::Pptx);
```

提供されたプレゼンテーションでは、最小高さを増やすと行に余白が追加されます。最小高さを減らすとその余分なスペースは削除されますが、テキストとセル余白が必要とする領域のため実際の高さは 20 ポイントより大きくなります。最小高さだけを減らしても、内容が必要とするスペース以下に行を強制することはできません。

実際の高さに影響する要因は次のとおりです。

- **テキストとフォントサイズ:** テキストが長い、明示的な改行がある、またはフォントが大きいと、より多くの垂直スペースが必要になります。
- **折り返しと列幅:** 折り返しが有効な場合、[IColumn::set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/icolumn/set_width/) で列幅を狭めると行数が増えます。列幅が広いと垂直方向の必要スペースが減ります。
- **セル余白:** [ICell::set_MarginTop](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_margintop/) と [ICell::set_MarginBottom](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginbottom/) は垂直余白を制御します。[ICell::set_MarginLeft](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginleft/) と [ICell::set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginright/) はテキストに使用できる幅を減らし、追加の折り返しを引き起こすことがあります。

結合セルのないこのテーブルでは、最も垂直スペースを必要とするセルが行全体のコンテンツ主導の下限を決定します。行を短くするには、テキストを短くするか、フォントサイズや余白を減らすか、列幅を広げる必要があります。

以下の画像は同じテーブルを同一スケールで示しています。ここに示した .NET の参照実行では、実際の高さはそれぞれ 70、100、55.2 ポイントでした。最終行は 20 ポイントの最小値よりも高くなりました。テキスト測定は環境にインストールされたフォントにより異なる場合があります。保存された結果は、[minimum を増やしたもの](row-height-increased.pptx) と [minimum を減らしたもの](row-height-decreased.pptx) をダウンロードしてください。

| 元の設定: 最小 70 pt、実際 70 pt | 増加: 最小 100 pt、実際 100 pt | 減少: 最小 20 pt、実際 55.2 pt |
| --- | --- | --- |
| ![70 ポイントの最初の行を持つ元のテーブル。](row-height-before.png) | ![最初の行の最小高さを 100 ポイントに増やした後のテーブル。](row-height-increased.png) | ![最初の行の最小高さを 20 ポイントに減らした後のテーブル。折り返しテキストにより行は最小値よりも高くなります。](row-height-decreased.png) |

## **最初の行をヘッダーとして設定する**

[set_FirstRow](https://reference.aspose.com/slides/cpp/aspose.slides/itable/set_firstrow/) メソッドを使用して、最初の行をヘッダー書式としてマークします。外観はテーブルに適用されたテーブルスタイルによって決まります。

1. [Presentation クラス](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) を使用してプレゼンテーションをロードします。  
2. 最初のスライドにアクセスします。  
3. スライド上の最初のシェイプとして格納されているテーブルにアクセスします。  
4. 最初の行にヘッダー書式を有効にします。  
5. 変更されたプレゼンテーションを保存します。

この例は、最初のスライドの最初のシェイプとしてテーブルが配置された `table.pptx` を必要とします。最初の行にヘッダー書式を適用し、`First_row_header.pptx` として保存します。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));
table->set_FirstRow(true);

presentation->Save(u"First_row_header.pptx", SaveFormat::Pptx);
```

## **テーブル行または列をクローンする**

行や列をクローンして、内容と書式を再利用できます。クローンはテーブルの末端に追加するか、特定の位置に挿入できます。

1. [Presentation クラス](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) でプレゼンテーションをロードします。  
2. 最初のスライドにアクセスします。  
3. 列幅と行高さを定義します。  
4. [AddTable メソッド](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/) でテーブルを追加します。  
5. 必要な行をクローンします。  
6. 必要な列をクローンします。  
7. 変更されたプレゼンテーションを保存します。

この例は、少なくとも 1 つのスライドがある `Test.pptx` を必要とします。3 列 5 行のテーブルをポイント単位で作成し、最初の行と列のコピーを末尾に追加し、2 行目と列のコピーをインデックス 3（4 番目の位置）に挿入します。結果として 7 行 5 列のテーブルが得られます。`false` 引数は隣接する結合行・列へのクローンを無効にします。このテーブルには結合セルはありません。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Table/ICell.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Test.pptx");
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({ 50, 50, 50 });
auto rowHeights = MakeArray<double>({ 50, 30, 30, 30, 30 });
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

table->idx_get(0, 0)->get_TextFrame()->set_Text(u"Row 1 Cell 1");
table->idx_get(1, 0)->get_TextFrame()->set_Text(u"Row 1 Cell 2");
table->get_Rows()->AddClone(table->get_Rows()->idx_get(0), false);

table->idx_get(0, 1)->get_TextFrame()->set_Text(u"Row 2 Cell 1");
table->idx_get(1, 1)->get_TextFrame()->set_Text(u"Row 2 Cell 2");
table->get_Rows()->InsertClone(3, table->get_Rows()->idx_get(1), false);

table->get_Columns()->AddClone(table->get_Columns()->idx_get(0), false);
table->get_Columns()->InsertClone(3, table->get_Columns()->idx_get(1), false);

presentation->Save(u"table_out.pptx", SaveFormat::Pptx);
```

## **テーブルから行または列を削除する**

テーブルで不要になった行や列を削除します。項目を削除すると、その後の行または列のインデックスがシフトします。

1. [Presentation クラス](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) でプレゼンテーションを作成します。  
2. 最初のスライドにアクセスします。  
3. 列幅と行高さを定義します。  
4. [AddTable メソッド](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/) でテーブルを追加します。  
5. 2 番目の行と 2 番目の列を削除します。  
6. 変更されたプレゼンテーションを保存します。

この例は、3×3 のテーブルを作成し、インデックス 1 の行と列を削除して 2×2 のテーブルを `TestTable_out.pptx` に残します。寸法はポイント単位です。`false` 引数は隣接する結合行・列の削除を無効にします。このテーブルには結合セルはありません。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IColumnCollection.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({ 100, 50, 30 });
auto rowHeights = MakeArray<double>({ 30, 50, 30 });
auto table = slide->get_Shapes()->AddTable(100, 100, columnWidths, rowHeights);

table->get_Rows()->RemoveAt(1, false);
table->get_Columns()->RemoveAt(1, false);

presentation->Save(u"TestTable_out.pptx", SaveFormat::Pptx);
```

## **テーブル行レベルでテキスト書式を設定する**

行全体にテキスト書式を適用して、セルの一貫性を保ちます。各セルを個別に書式設定することなく、フォント属性、段落書式、テキスト方向を設定できます。

1. [Presentation クラス](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) でプレゼンテーションをロードします。  
2. 最初のスライド上のテーブルにアクセスします。  
3. 最初の行のフォント高さを [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) で設定します。  
4. 最初の行の配置と右段落余白を [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) と [set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/) で設定します。  
5. 2 行目のテキスト方向を [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/) で設定します。  
6. 変更されたプレゼンテーションを保存します。

この例は、最初のスライドの最初のシェイプとしてテーブルが配置された `table.pptx` と、少なくとも 2 行があることを前提とします。最初の行に 25 ポイントのテキスト、右揃え、右段落余白 20 ポイントを適用し、2 行目に縦書きテキストを設定します。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/PortionFormat.h>
#include <DOM/ParagraphFormat.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextFrameFormat.h>
#include <DOM/TextVerticalType.h>
#include <DOM/Table/IRow.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto portionFormat = MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25);
table->get_Rows()->idx_get(0)->SetTextFormat(portionFormat);

auto paragraphFormat = MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20);
table->get_Rows()->idx_get(0)->SetTextFormat(paragraphFormat);

auto textFrameFormat = MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
table->get_Rows()->idx_get(1)->SetTextFormat(textFrameFormat);

presentation->Save(u"row_formatting.pptx", SaveFormat::Pptx);
```

## **テーブル列レベルでテキスト書式を設定する**

列全体にテキスト書式を適用して、セルの一貫性を保ちます。各セルを個別に書式設定することなく、フォント属性、段落書式、テキスト方向を設定できます。

1. [Presentation クラス](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) でプレゼンテーションをロードします。  
2. 最初のスライド上のテーブルにアクセスします。  
3. 最初の列のフォント高さを [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) で設定します。  
4. 最初の列の配置と右段落余白を [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) と [set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/) で設定します。  
5. 2 列目のテキスト方向を [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/) で設定します。  
6. 変更されたプレゼンテーションを保存します。

この例は、最初のスライドの最初のシェイプとしてテーブルが配置された `table.pptx` と、少なくとも 2 列があることを前提とします。最初の列に 25 ポイントのテキスト、右揃え、右段落余白 20 ポイントを適用し、2 列目に縦書きテキストを設定します。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/PortionFormat.h>
#include <DOM/ParagraphFormat.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextFrameFormat.h>
#include <DOM/TextVerticalType.h>
#include <DOM/Table/IColumn.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto portionFormat = MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25);
table->get_Columns()->idx_get(0)->SetTextFormat(portionFormat);

auto paragraphFormat = MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20);
table->get_Columns()->idx_get(0)->SetTextFormat(paragraphFormat);

auto textFrameFormat = MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
table->get_Columns()->idx_get(1)->SetTextFormat(textFrameFormat);

presentation->Save(u"column_formatting.pptx", SaveFormat::Pptx);
```

## **テーブルスタイルプロパティの取得**

[get_StylePreset](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_stylepreset/) メソッドを使用してテーブルに適用されたプリセットを取得し、別のテーブルで再利用できます。これにより、個々のセル書式オーバーライドではなく、プリセット全体が識別されます。

この例ではテーブルを作成し、[TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/cpp/aspose.slides/tablestylepreset/) を適用してから、プリセットを読み戻します。`DarkStyle1` が出力され、テーブルは `table.pptx` に保存されます。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <DOM/TableStylePreset.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({ 100, 150 });
auto rowHeights = MakeArray<double>({ 5, 5, 5 });
auto table = slide->get_Shapes()->AddTable(10, 10, columnWidths, rowHeights);
table->set_StylePreset(TableStylePreset::DarkStyle1);

Console::WriteLine(u"{0}", table->get_StylePreset());

presentation->Save(u"table.pptx", SaveFormat::Pptx);
```

## **FAQ**

**既に作成されたテーブルに PowerPoint のテーマ/スタイルを適用できますか？**

はい。テーブルはスライド/レイアウト/マスタのテーマを継承します。その上で、塗りつぶし、枠線、テキストカラーを個別に上書きすることも可能です。

**Excel のようにテーブル行をソートできますか？**

できません。Aspose.Slides のテーブルには組み込みのソートやフィルター機能がありません。まずメモリ内でデータをソートし、その順序でテーブル行を再配置してください。

**カスタムカラーを特定のセルに保持しながら、帯状（ストライプ）列を設定できますか？**

できます。帯状列を有効にした後、特定のセルにローカル書式を上書きすれば、セルレベルの書式がテーブルスタイルよりも優先されます。