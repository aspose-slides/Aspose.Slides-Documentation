---
title: "C++ でプレゼンテーション表を管理する"
linktitle: "表の管理"
type: docs
weight: 10
url: /ja/cpp/manage-table/
keywords:
- "表の追加"
- "表の作成"
- "表へのアクセス"
- "アスペクト比"
- "テキストの配置"
- "テキスト書式設定"
- "表スタイル"
- "PowerPoint"
- "プレゼンテーション"
- "C++"
- "Aspose.Slides"
description: "Aspose.Slides for C++ を使用して PowerPoint スライド内の表を作成・編集します。表の操作を効率化するシンプルなコード例をご紹介します。"
---
## **はじめに**

PowerPoint の表は情報を行と列に整理し、値の読み取りと比較を容易にします。

Aspose.Slides は、[Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/) クラス、[ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) インターフェイス、[Cell](https://reference.aspose.com/slides/cpp/aspose.slides/cell/) クラス、[ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) インターフェイス、およびその他の型を提供し、プレゼンテーション内の表を作成、更新、管理できます。

## **最初から表を作成する**

位置、列幅、行高さを指定して表を作成します。スライドに追加した後、セルの罫線を設定したり、セルを結合したり、テキストを挿入したりできます。

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. 列幅（ポイント）の配列を定義します。
4. 行高さ（ポイント）の配列を定義します。
5. [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/) メソッドを使用して、スライドに [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) オブジェクトを追加します。
6. 各 [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) を走査し、上・下・左・右の罫線に書式設定を適用します。
7. 表の最初の行の最初の 2 つのセルを結合します。
8. 結合されたセルを [get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_textframe/) メソッドで取得します。
9. 結合セルにテキストを設定します。
10. 変更したプレゼンテーションを保存します。

以下の例は、(100, 50) ポイントに幅 3 列・高さ 5 行の表を作成し、幅 5 ポイントの赤い罫線を適用し、最初の行の最初の 2 セルを結合し、結果を `table.pptx` として保存します。

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 50, 50, 50 });
auto rowHeights = System::MakeArray<double>({ 50, 30, 30, 30, 30 });
auto table = slide->get_Shapes()->AddTable(100.0f, 50.0f, columnWidths, rowHeights);

for (const auto& row : table->get_Rows())
{
    for (const auto& cell : row)
    {
        auto cellFormat = cell->get_CellFormat();

        cellFormat->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderTop()->set_Width(5);

        cellFormat->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderBottom()->set_Width(5);

        cellFormat->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderLeft()->set_Width(5);

        cellFormat->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderRight()->set_Width(5);
    }
}

table->MergeCells(table->idx_get(0, 0), table->idx_get(1, 0), false);
table->idx_get(0, 0)->get_TextFrame()->set_Text(u"Merged Cells");

presentation->Save(u"table.pptx", SaveFormat::Pptx);
```

## **標準テーブルの番号付け**

標準テーブルでは、セルインデックスは 0 から始まり、順序は (列, 行) です。最初のセルは (0, 0) とインデックス付けされます。

たとえば、4 列 4 行のテーブルのセルは次のように番号付けされます。

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

この例は、上記の 4 × 4 テーブルを作成し、列幅と行高さを 70 ポイント、罫線を幅 5 ポイントの赤に設定します。座標はセルインデックスを示しています。セルは空のままで、テーブルは `StandardTables_out.pptx` として保存されます。

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 70, 70, 70, 70 });
auto rowHeights = System::MakeArray<double>({ 70, 70, 70, 70 });
auto table = slide->get_Shapes()->AddTable(100.0f, 50.0f, columnWidths, rowHeights);

for (const auto& row : table->get_Rows())
{
    for (const auto& cell : row)
    {
        auto cellFormat = cell->get_CellFormat();
        cellFormat->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderTop()->set_Width(5);

        cellFormat->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderBottom()->set_Width(5);

        cellFormat->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderLeft()->set_Width(5);

        cellFormat->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderRight()->set_Width(5);
    }
}

presentation->Save(u"StandardTables_out.pptx", SaveFormat::Pptx);
```

## **既存の表にアクセスする**

表はスライドのシェイプコレクションに格納されています。シェイプを走査して表を見つけ、[ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) インターフェイスを使用してセルを読み取ったり更新したりします。

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスを使用してプレゼンテーションをロードします。
2. インデックスで表が含まれるスライドへの参照を取得します。
3. [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) オブジェクトを走査し、表が見つかった時点で停止します。スライドに複数の表がある場合は、[get_AlternativeText](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_alternativetext/) を使用して目的の表を特定します。
4. 対象セルのテキストを更新します。
5. 変更したプレゼンテーションを保存します。

以下の例は `UpdateExistingTable.pptx` を開き、1 枚目のスライドの最初の表を見つけます。列 0、行 1 のセルに `New` を設定し、結果を `table1_out.pptx` として保存します。入力には少なくとも 1 枚のスライドが必要で、該当スライドの最初の表は少なくとも 1 列 2 行を持っている必要があります。

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"UpdateExistingTable.pptx");
auto slide = presentation->get_Slide(0);
System::SharedPtr<ITable> table;

for (const auto& shape : System::IterateOver(slide->get_Shapes()))
{
    if (System::ObjectExt::Is<ITable>(shape))
    {
        table = System::ExplicitCast<ITable>(shape);
        break;
    }
}

if (table != nullptr)
{
    table->idx_get(0, 1)->get_TextFrame()->set_Text(u"New");
    presentation->Save(u"table1_out.pptx", SaveFormat::Pptx);
}
```

行のサイズを変更し、実際の高さが要求された最小高さを超える理由を理解するには、[Control Row Height](/slides/ja/cpp/manage-rows-and-columns/#control-row-height) を参照してください。

## **テキストフレームを所有するセルを見つける**

汎用テキスト処理コードが表から取得した [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) に対しては、[ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentcell/) を使用して所有する [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) を取得します。テーブルセルのテキストフレームの場合、[ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentcell/) は所有者を返し、[ITextFrame::get_ParentShape](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentshape/) は `nullptr` を返します（テーブル自体はシェイプです）。

セルの座標は読み取り専用の [ICell::get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) および [ICell::get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) メソッドで取得できます。[ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentcell/) は所有者を返しますが所有権は変更しません。使用前に必ず `nullptr` でないか確認してください。

テーブルセルとシェイプの所有者（SmartArt ノードに関連付けられたシェイプを含む）を特定する完全な例については、[Search and Replace Text](/slides/ja/cpp/search-and-replace-text/) を参照してください。

## **表内のテキストの配置**

個々のセルの垂直アンカリングとテキスト方向を制御できます。このセクションの例では、最初のセル内のテキストを中央揃えにし、270 度回転させます。

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスでスライドへの参照を取得します。
3. スライドに [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) オブジェクトを追加します。
4. 表から [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) オブジェクトを取得します。
5. 最初の [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/) にアクセスし、テキストと色を設定します。
6. [set_TextAnchorType](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_textanchortype/) と [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_textverticaltype/) を使用してセルの垂直アンカリングとテキスト方向を設定します。
7. 変更したプレゼンテーションを保存します。

この例は、列幅 120 ポイント、行高さ 100 ポイントの 4 × 4 テーブルを作成し、セル (0, 0) のテキストをフォーマットし、最初の行の残りのセルに値を追加し、結果を `Vertical_Align_Text_out.pptx` として保存します。

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ITable.h>
#include <DOM/TextAnchorType.h>
#include <DOM/TextVerticalType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 120, 120, 120, 120 });
auto rowHeights = System::MakeArray<double>({ 100, 100, 100, 100 });
auto table = slide->get_Shapes()->AddTable(100.0f, 50.0f, columnWidths, rowHeights);

table->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
table->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
table->idx_get(3, 0)->get_TextFrame()->set_Text(u"30");

auto cell = table->idx_get(0, 0);
auto paragraph = cell->get_TextFrame()->get_Paragraphs()->idx_get(0);

auto portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Text here");
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

cell->set_TextAnchorType(TextAnchorType::Center);
cell->set_TextVerticalType(TextVerticalType::Vertical270);

presentation->Save(u"Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
```

## **テーブルレベルでのテキスト書式設定**

[SetTextFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibulktextformattable/settextformat/) を使用して、テーブル内のすべてのセルにテキスト書式を適用できます。オーバーロードは部分、段落、テキストフレームの書式設定を受け取るため、個々のセルを走査せずにこれらのプロパティを設定できます。

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスを使用してプレゼンテーションをロードします。
2. インデックスでスライドへの参照を取得します。
3. スライドから [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) オブジェクトを取得します。
4. [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) を使用してテキストのフォントサイズを設定します。
5. [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) と [set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/) を使用して段落の配置と右余白を設定します。
6. [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/) でテキスト方向を設定します。
7. 変更したプレゼンテーションを保存します。

以下の例は `table.pptx` を開きます（少なくとも 1 枚のスライドがあり、最初のシェイプが表である必要があります）。フォントサイズを 25 ポイントに設定し、右余白 20 ポイントで段落を右揃えにし、テキストを縦向きにします。書式設定されたプレゼンテーションは `result.pptx` として保存されます。

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ParagraphFormat.h>
#include <DOM/PortionFormat.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextFrameFormat.h>
#include <DOM/TextVerticalType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));

auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
table->SetTextFormat(portionFormat);

auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
table->SetTextFormat(paragraphFormat);

auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
table->SetTextFormat(textFrameFormat);

presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **テーブルスタイルプロパティの取得**

[get_StylePreset](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_stylepreset/) を使用してテーブルのプリセットスタイルを取得し、[set_StylePreset](https://reference.aspose.com/slides/cpp/aspose.slides/itable/set_stylepreset/) で割り当てます。この例は [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/cpp/aspose.slides/tablestylepreset/) を 1 つの表に適用し、プリセット名を表示し、同じプリセットを 2 番目の表に割り当てます。両方の表は `table-style.pptx` に保存されます。

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <DOM/TableStylePreset.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 100, 150 });
auto rowHeights = System::MakeArray<double>({ 5, 5, 5 });
auto table = slide->get_Shapes()->AddTable(10, 10, columnWidths, rowHeights);
table->set_StylePreset(TableStylePreset::DarkStyle1);

auto stylePreset = table->get_StylePreset();
System::Console::WriteLine(u"Table style preset: {0}", stylePreset);

auto anotherTable = slide->get_Shapes()->AddTable(10, 100, columnWidths, rowHeights);
anotherTable->set_StylePreset(stylePreset);

presentation->Save(u"table-style.pptx", SaveFormat::Pptx);
```

## **表のアスペクト比をロックする**

表のアスペクト比は幅と高さの比率です。[set_AspectRatioLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobjectlock/set_aspectratiolocked/) を使用してこの比率をロックできます。

以下の例は `pres.pptx` を開きます（少なくとも 1 枚のスライドがあり、最初のシェイプが表である必要があります）。現在のロック状態を出力し、アスペクト比ロックを有効にして更新後の状態（`True`）を出力し、結果を `pres-out.pptx` として保存します。

```cpp
#include <DOM/IGraphicalObjectLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
auto slide = presentation->get_Slide(0);

auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

table->get_GraphicalObjectLock()->set_AspectRatioLocked(true);
Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

presentation->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**テーブル全体とセル内テキストの右から左 (RTL) 読み取り方向を有効にできますか？**

はい。テーブルは [set_RightToLeft](https://reference.aspose.com/slides/cpp/aspose.slides/table/set_righttoleft/) メソッドを公開しており、段落は [ParagraphFormat::set_RightToLeft](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphformat/set_righttoleft/) を持ちます。両方を使用すると、セル内部の正しい RTL 順序と描画が保証されます。

**最終ファイルで表の移動やサイズ変更をユーザーに禁止するにはどうすればよいですか？**

[shape locks](/slides/ja/cpp/applying-protection-to-presentation/) を使用して、移動、サイズ変更、選択などを無効にします。これらのロックは表にも適用されます。

**セル内に画像を背景として挿入することはサポートされていますか？**

はい。セルに対して [picture fill](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillformat/) を設定できます。画像は選択したモード（伸縮またはタイル）に従ってセル領域を覆います。