---
title: C++ を使用したプレゼンテーションでテーブルセルを管理
linktitle: セルの管理
type: docs
weight: 30
url: /ja/cpp/manage-cells/
keywords:
- テーブルセル
- セルの結合
- 枠線の削除
- セルの分割
- セル内の画像
- 背景色
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "C++ で PowerPoint のテーブルセルを管理します：結合セルの識別、枠線の削除、セルの分割、背景色と画像の設定を Aspose.Slides for C++ を使用して行います。"
---
## **概要**

Aspose.Slides は PowerPoint プレゼンテーションのテーブルセルにアクセスし、変更することができます。この記事では、結合されたテーブルセルの識別、セルの枠線の削除、結合または分割後のセル番号の扱い、セルの背景色の変更、およびテーブルセル内への画像の追加方法について説明します。例では、プレゼンテーションの作成またはオープン、スライドからテーブルを取得、セルプロパティを介したセルの書式設定の更新、そして変更されたプレゼンテーションを PPTX ファイルとして保存する方法を示します。

Aspose.Slides はゼロベースのインデックスを使用し、`(column, row)` の順序でテーブルセルにアクセスします。

## **結合されたテーブルセルの識別**

この例は既存のプレゼンテーションを開き、最初のスライド上の最初のシェイプをテーブルとして取得します。スライドとシェイプが存在し、シェイプがテーブルであることを前提としています。次に、すべての行と列を反復し、[get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) を使用して結合領域のセルを識別します。マッチする各セルについて、`row;column` の順序でセル座標、[get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/)、[get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/)、および領域の開始座標である [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) と [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) を出力します。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IColumnCollection.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation_with_table.pptx");
auto slide = presentation->get_Slide(0);
auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto rowCount = table->get_Rows()->get_Count();
for (auto rowIndex = 0; rowIndex < rowCount; rowIndex++)
{
    auto columnCount = table->get_Columns()->get_Count();
    for (auto columnIndex = 0; columnIndex < columnCount; columnIndex++)
    {
        auto cell = table->idx_get(columnIndex, rowIndex);
        if (cell->get_IsMergedCell())
        {
            Console::WriteLine(u"Cell {0};{1} belongs to a merged region with RowSpan={2} and ColSpan={3} starting at {4};{5}.", rowIndex, columnIndex, cell->get_RowSpan(), cell->get_ColSpan(), cell->get_FirstRowIndex(), cell->get_FirstColumnIndex());
        }
    }
}
```

## **テーブルセルの枠線を削除**

[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) を作成し、[AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/) を使用して最初のスライドにテーブルを追加します。列幅、行高さ、テーブルの位置はポイントで指定します。例では、4 つすべてのセル枠線を [FillType::NoFill](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) に設定し、非表示にします。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/FillType.h>
#include <DOM/ILineFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <system/enumerator_adapter.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({50, 50, 50, 50});
auto rowHeights = MakeArray<double>({50, 30, 30, 30, 30});
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

for (const auto& row : IterateOver(table->get_Rows()))
    for (const auto& cell : IterateOver(row))
    {
        cell->get_CellFormat()->get_BorderTop()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderRight()->get_FillFormat()->set_FillType(FillType::NoFill);
    }

presentation->Save(u"table.pptx", SaveFormat::Pptx);
```

## **対角線のセル枠線を追加**

[get_BorderDiagonalDown](https://reference.aspose.com/slides/cpp/aspose.slides/icellformat/get_borderdiagonaldown/) を使用して左上隅から右下隅へ線を描画し、[get_BorderDiagonalUp](https://reference.aspose.com/slides/cpp/aspose.slides/icellformat/get_borderdiagonalup/) を使用して左下隅から右上隅へ線を描画します。対角線はコーナーヘッダーを示すことができ、両方の対角線を組み合わせてセルが適用外であることを示す X を形成できます。

各対角線は [ILineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/) です。[get_FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/get_fillformat/) を使用して塗りつぶしにアクセスし、[set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ilinefillformat/set_filltype/) に [FillType::Solid](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) を指定して [get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ilinefillformat/get_solidfillcolor/) で色を選択します。線幅はポイント単位で [set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_width/) で設定します。

例では 1 行に 3 つのセルを作成します：赤い下向き対角線、青い上向き対角線、そして両方の対角線です。上下左右のセル枠線は変更しません。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <system/array.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({210, 210, 210});
auto rowHeights = MakeArray<double>({160});
auto table = slide->get_Shapes()->AddTable(45, 130, columnWidths, rowHeights);

auto downwardBorder = table->idx_get(0, 0)->get_CellFormat()->get_BorderDiagonalDown();
downwardBorder->get_FillFormat()->set_FillType(FillType::Solid);
downwardBorder->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
downwardBorder->set_Width(3);

auto upwardBorder = table->idx_get(1, 0)->get_CellFormat()->get_BorderDiagonalUp();
upwardBorder->get_FillFormat()->set_FillType(FillType::Solid);
upwardBorder->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
upwardBorder->set_Width(5);

auto crossDownwardBorder = table->idx_get(2, 0)->get_CellFormat()->get_BorderDiagonalDown();
crossDownwardBorder->get_FillFormat()->set_FillType(FillType::Solid);
crossDownwardBorder->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
crossDownwardBorder->set_Width(3);

auto crossUpwardBorder = table->idx_get(2, 0)->get_CellFormat()->get_BorderDiagonalUp();
crossUpwardBorder->get_FillFormat()->set_FillType(FillType::Solid);
crossUpwardBorder->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
crossUpwardBorder->set_Width(5);

presentation->Save(u"diagonal_cell_borders.pptx", SaveFormat::Pptx);
```

対角線は書式設定プロパティであり、セルの分割ではありません。各セルは [get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_textframe/) で取得できる単一のテキストフレームを保持します。対角線の両側の領域は独立して編集できません。

保存されたテーブルは Microsoft PowerPoint でレンダリングされます：

![左上から右下への赤い対角線、左下から右上への青い対角線、そして両方の対角線で X を形成する 3 つのテーブルセル](diagonal-cell-borders.png)

*左から右へ: 下向き対角線（赤、3 pt）、上向き対角線（青、5 pt）、および両方の対角線*。

## **テーブルセルの結合**

[MergeCells](https://reference.aspose.com/slides/cpp/aspose.slides/itable/mergecells/) を使用してテーブルセルの矩形範囲を 1 つのセルに結合します。範囲の左上隅と右下隅のセルを指定します。最後の引数は、結合が指定範囲外のセルを含むかどうかを制御します。`false` は範囲内に結合を保ちます。

例では 70 ポイントの列幅と行高を持つ 4×4 テーブルを作成し、`(1, 1)` から `(2, 2)` の 4 つの中央セルを結合します。結果として得られるセルは 2 列と 2 行にまたがりますが、テーブルの基礎グリッドは依然として 4 列 4 行のままです。結合されたセルの内容や書式にアクセスするには、左上位置 `table->idx_get(1, 1)` を使用します。結合範囲内の他の位置はテーブルグリッドの一部として残り、範囲外のセルのインデックスは変更されません。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({70, 70, 70, 70});
auto rowHeights = MakeArray<double>({70, 70, 70, 70});
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 2), false);

presentation->Save(u"merged_cells.pptx", SaveFormat::Pptx);
```

## **テーブルセルの分割**

前の例でセルを結合するとテーブルのグリッドは維持されます。セルを分割すると新しいグリッド列が導入され、右側のセルの列インデックスが変わることがあります。Aspose.Slides は PowerPoint のテーブルグリッドモデルに従います。

この例では 70 ポイントの列幅と行高を持つ 4×4 テーブルを作成し、セル `(1, 1)` に対して [SplitByWidth](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbywidth/) を呼び出します。セルの 70 ポイント幅の半分を渡して、同じ幅の 2 つのセルを作成します。

この分割後、2 つの半分は `table->idx_get(1, 1)` と `table->idx_get(2, 1)` でアクセスできます。テーブルグリッドは現在 5 列になり、元々列 2 と 3 にあったセルはそれぞれ列 3 と 4 に移動します。行インデックスは変更されません。分割後にセルにアクセスする際は、これら更新された列インデックスを使用してください。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({70, 70, 70, 70});
auto rowHeights = MakeArray<double>({70, 70, 70, 70});
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

table->idx_get(1, 1)->SplitByWidth(table->idx_get(1, 1)->get_Width() / 2);

presentation->Save(u"split_cells.pptx", SaveFormat::Pptx);
```

<!-- visual-explanation:manage-cells:start -->
[![結合されていない 70 ポイントのセルが 2 つの 35 ポイントセルに分割され、5 番目のグリッド列が追加され、右側のインデックスがシフトします。](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*幅の分割はセル (1, 1) に影響し、ゼロベースの (column, row) インデックスを使用します。他の行は両方の新しい列位置にまたがるセルを保持します。*
<!-- visual-explanation:manage-cells:end -->

### **行または列のスパンで結合セルを分割**

データ入力のために結合テンプレートセルを準備するには、既存の行境界に沿って分割するために [SplitByRowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyrowspan/) を使用し、列境界に沿って分割するには [SplitByColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbycolspan/) を使用します。

`index` 引数は分割の上部の行数または左側の列数をカウントし、結合領域に対して相対的です：

- 行分割: `0 < index <` [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/).
- 列分割: `0 < index <` [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/).

この例では、プレゼンテーションの最初のスライドの最初のシェイプがテーブルであり、`(1, 2)` と `(1, 3)` が縦方向に結合されていることを前提としています。下側の位置から開始し、[get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) と [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) を使用して起点を特定し、両方のスパンを確認します。`SplitByRowSpan(1)` は製品名のために行 2 と 3 を分離します。横方向の 2 列結合の場合は、代わりに `SplitByColSpan(1)` を使用します。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/ITextFrame.h>
#include <system/console.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table_template.pptx");
auto slide = presentation->get_Slide(0);
auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto selectedCell = table->idx_get(1, 3);
auto firstColumnIndex = selectedCell->get_FirstColumnIndex();
auto firstRowIndex = selectedCell->get_FirstRowIndex();
auto mergedCell = table->idx_get(firstColumnIndex, firstRowIndex);

if (mergedCell->get_IsMergedCell() && mergedCell->get_RowSpan() == 2 && mergedCell->get_ColSpan() == 1)
{
    mergedCell->SplitByRowSpan(1);

    // 分割後にテーブルから得られるセルを取得します。
    auto upperCell = table->idx_get(firstColumnIndex, firstRowIndex);
    auto lowerCell = table->idx_get(firstColumnIndex, firstRowIndex + 1);
    Console::WriteLine(u"Upper cell merged: {0}", upperCell->get_IsMergedCell());
    Console::WriteLine(u"Lower cell merged: {0}", lowerCell->get_IsMergedCell());

    upperCell->get_TextFrame()->set_Text(u"Product A");
    lowerCell->get_TextFrame()->set_Text(u"Product B");

    presentation->Save(u"split_template.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"Select a merged region spanning exactly two rows and one column.");
}
```

テーブルグリッドおよび周囲のセルインデックスは変更されません。結果のセルは座標で取得します。ここでは両方ともスパンが 1 で、[get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) は `False` を出力します。より大きな領域は、1 回の分割後も部分的に結合されたままになることがあります。

元のテキストと書式は上部（または左側）のセルに残り、新しいセルは空ですが、塗りつぶし、枠線、余白などのセル書式を継承します。分割後にセルにデータを入力し、必要なテキスト書式を明示的に設定してください。

保存されたプレゼンテーションには、テンプレートのセル書式が保持された状態で、別々の「Product A」および「Product B」セルが含まれます。詳細は [Cell API Reference](https://reference.aspose.com/slides/cpp/aspose.slides/cell/) を参照してください。

### **特定の高さでセルを分割**

[SplitByHeight](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyheight/) は上部の高さをポイントで受け取ります。[SplitByRowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyrowspan/) は上部の既存グリッド行数を受け取ります。右側の列で 40 ポイントのセルを中央に配置するには、セルの実際の高さから 40 を減算し、残りのスペースを上下に均等に分割します。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <DOM/ITextFrame.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({160, 160});
auto rowHeights = MakeArray<double>({140});

auto table = slide->get_Shapes()->AddTable(50, 50, columnWidths, rowHeights);
table->idx_get(0, 0)->get_TextFrame()->set_Text(u"Left");

auto height = table->idx_get(1, 0)->get_Height();
auto margin = (height - 40) / 2;

table->idx_get(1, 0)->SplitByHeight(margin);
table->idx_get(1, 1)->SplitByHeight(40);
table->idx_get(1, 1)->get_TextFrame()->set_Text(u"Middle");

presentation->Save(u"split_by_height.pptx", SaveFormat::Pptx);
```

最初の分割によりグリッド行が追加され、下部の 90 ポイントが `(1, 1)` に残ります。2 回目の分割はそのセルを対象とし、下にもう 1 行を追加します。右側の列は現在、`(1, 0)` が 50 ポイント（`margin`）、`(1, 1)` が 40 ポイント、`(1, 2)` が 50 ポイント（`margin`）となります。左側のセルは元の高さ 140 ポイントで 3 行すべてに跨ります。

![左側のセルがテーブル全体の高さに跨り、中央に Middle がある 3 つのセルの横に配置されています](split-by-height.png)

## **テーブルセルの背景色を変更**

この例では 150 ポイントの列幅と 50 ポイントの行高を持つテーブルを作成します。[set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) を使用して単色塗りつぶしを選択し、[get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_solidfillcolor/) で塗りつぶし色にアクセスして、3 列目・4 行目のセル `(2, 3)` を赤に設定します。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/Table/ICellFormat.h>
#include <drawing/color.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({150, 150, 150, 150});
auto rowHeights = MakeArray<double>({50, 50, 50, 50, 50});
auto table = slide->get_Shapes()->AddTable(50, 50, columnWidths, rowHeights);

auto cell = table->idx_get(2, 3);
cell->get_CellFormat()->get_FillFormat()->set_FillType(FillType::Solid);
cell->get_CellFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

presentation->Save(u"cell_background_color.pptx", SaveFormat::Pptx);
```

## **テーブルセル内に画像を追加**

この例を実行する前に、入力画像を作業ディレクトリに配置してください。画像は [Images::FromFile](https://reference.aspose.com/slides/cpp/aspose.slides/images/fromfile/) で読み込み、[AddImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimagecollection/addimage/) でプレゼンテーションの画像コレクションに追加します。その後、テーブルの最初のセル `(0, 0)` のピクチャーフィルに画像を割り当てます。

[PictureFillMode::Stretch](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/) は画像をセル全体に伸ばし、アスペクト比が変わる可能性があります。列幅と行高さはポイント単位です。読み込んだ画像はプレゼンテーションに追加された後に破棄されます。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/FillType.h>
#include <DOM/IImageCollection.h>
#include <IImage.h>
#include <DOM/IPPImage.h>
#include <DOM/IFillFormat.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Table/ICellFormat.h>
#include <Util/Images.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({150, 150, 150, 150});
auto rowHeights = MakeArray<double>({100, 100, 100, 100, 90});
auto table = slide->get_Shapes()->AddTable(50, 50, columnWidths, rowHeights);

auto image = Images::FromFile(u"aspose_logo.jpg");
auto ppImage = presentation->get_Images()->AddImage(image);
image->Dispose();

table->idx_get(0, 0)->get_CellFormat()->get_FillFormat()->set_FillType(FillType::Picture);
table->idx_get(0, 0)->get_CellFormat()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
table->idx_get(0, 0)->get_CellFormat()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(ppImage);

presentation->Save(u"table_cell_with_image.pptx", SaveFormat::Pptx);
```

## **FAQ**

**単一のセルの各側に異なる線の太さやスタイルを設定できますか？**

はい。[上](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_bordertop/)/[下](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderbottom/)/[左](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderleft/)/[右](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderright/) の枠線は個別のプロパティを持つため、各側の太さやスタイルを異ならせることができます。

**セルの背景に画像を設定した後、列/行のサイズを変更すると画像はどうなりますか？**

動作は[塗りつぶしモード](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/)（stretch/タイル）に依存します。stretch を使用すると、画像は新しいセルサイズに合わせて調整されます。タイルを使用すると、タイルが再計算されます。

**セル内のすべてのコンテンツにハイパーリンクを割り当てることはできますか？**

[ハイパーリンク](/slides/ja/cpp/manage-hyperlinks/) はセルのテキストフレーム内のテキスト（部分）レベル、またはテーブル/シェイプ全体のレベルで設定されます。実際には、リンクを部分に割り当てるか、セル内のすべてのテキストに割り当てます。

**単一のセル内で異なるフォントを設定できますか？**

はい。セルのテキストフレームは、独立した書式設定（フォントファミリー、スタイル、サイズ、色）を持つ[部分](https://reference.aspose.com/slides/cpp/aspose.slides/portion/)（ラン）をサポートします。