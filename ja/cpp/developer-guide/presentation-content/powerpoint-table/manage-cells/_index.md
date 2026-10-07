---
title: C++ を使用してプレゼンテーションの表セルを管理
linktitle: セルの管理
type: docs
weight: 30
url: /ja/cpp/manage-cells/
keywords:
- 表セル
- セルの結合
- 境界線の削除
- セルの分割
- セル内の画像
- 背景色
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "C++ で PowerPoint の表セルを管理します。結合されたセルの特定、境界線の削除、セルの分割、背景色や画像の設定を Aspose.Slides for C++ で行います。"
---
## **概要**

Aspose.Slides は PowerPoint プレゼンテーションの表セルにアクセスし、変更することができます。この記事では、結合された表セルを特定する方法、セルの境界線を削除する方法、結合または分割後のセル番号の取り扱い、セルの背景色を変更する方法、そして表セル内に画像を追加する方法を説明します。サンプルは、プレゼンテーションを作成または開き、スライドから表を取得し、セルプロパティを通じてセルの書式設定を更新し、変更されたプレゼンテーションを PPTX ファイルとして保存する手順を示しています。

Aspose.Slides はゼロベースのインデックスを使用し、`(column, row)` の順序で表セルにアクセスします。

## **結合された表セルの特定**

この例では、既存のプレゼンテーションを開き、最初のスライドの最初のシェイプを表として取得します。スライドとシェイプが存在し、シェイプが表であることを前提としています。その後、すべての行と列を反復し、[get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) を使用して結合領域内のセルを特定します。マッチした各セルについて、`row;column` の順序でセル座標を出力し、[get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/)、[get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/)、および領域の開始座標である [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) と [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) を出力します。

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

## **表セルの境界線を削除**

[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) を作成し、[AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/) を使用して最初のスライドに表を追加します。列幅、行高さ、および表の位置はポイントで指定されます。この例では、すべてのセル境界線を [FillType::NoFill](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) に設定し、境界線を非表示にします。

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

## **表セルの結合**

[MergeCells](https://reference.aspose.com/slides/cpp/aspose.slides/itable/mergecells/) を使用して、矩形領域の表セルを 1 つのセルに結合します。範囲の左上隅と右下隅のセルを指定します。最後の引数は、結合が指定範囲外のセルを含むかどうかを制御します。`false` にすると、結合はその範囲内にとどまります。

この例では、列幅と行高さが 70 ポイントの 4×4 の表を作成し、`(1, 1)` から `(2, 2)` までの 4 つの中心セルを結合します。結果として得られるセルは 2 列と 2 行にまたがりますが、表の基礎となるグリッドは 4 列 4 行のままです。結合されたセルの内容や書式設定にアクセスするには、左上の位置 `table->idx_get(1, 1)` を使用します。この例では他の位置は表のグリッドの一部であり、範囲外のセルのインデックスは変更されません。

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

## **表セルの分割**

前の例でセルを結合すると、表のグリッドは保持されます。セルを分割すると、新しいグリッド列が導入され、右側のセルの列インデックスが変更されることがあります。Aspose.Slides は PowerPoint の表グリッドモデルに従います。

この例では、列幅と行高さが 70 ポイントの 4×4 の表を作成し、セル `(1, 1)` に対して [SplitByWidth](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbywidth/) を呼び出します。セルの 70 ポイント幅の半分を指定して、幅が等しい 2 つのセルを作成します。

この分割後、2 つの半分は `table->idx_get(1, 1)` と `table->idx_get(2, 1)` でアクセスできます。表のグリッドは現在 5 列になり、元々列 2 と列 3 にあったセルはそれぞれ列 3 と列 4 に移動します。行インデックスは変わりません。分割後にセルにアクセスする際は、これら更新された列インデックスを使用してください。

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

### **行または列のスパンで結合セルを分割**

データ入力のために結合されたテンプレートセルを準備するには、既存の行境界に沿って分割するために [SplitByRowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyrowspan/) を使用し、列境界に沿って分割するには [SplitByColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbycolspan/) を使用します。

`index` 引数は、分割された上部の行または左側の列の数をカウントします。これは結合領域に対して相対的です：

- 行分割: `0 < index <` [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/).
- 列分割: `0 < index <` [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/).

この例では、プレゼンテーションの最初のスライドの最初のシェイプが表であり、`(1, 2)` と `(1, 3)` が縦方向に結合されていることを想定しています。下部の位置から始めて、[get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) と [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) を使用して起点を特定し、両方のスパンを確認します。`SplitByRowSpan(1)` は製品名用に行 2 と行 3 を分割します。横方向の 2 列結合の場合は、代わりに `SplitByColSpan(1)` を使用します。

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

表のグリッドおよび周囲のセルインデックスは変更されません。結果のセルは座標で取得します。ここでは両方ともスパンが 1 で、[get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) は `False` を出力します。より大きな領域は、1 回の分割後も部分的に結合されたままにできることがあります。

元のテキストと書式設定は上部（または左側）のセルに残り、新しいセルは空ですが、塗りつぶし、境界線、余白などのセル書式設定を継承します。分割後にセルにデータを入力し、必要なテキスト書式設定を明示的に設定してください。

保存されたプレゼンテーションには、テンプレートのセル書式設定が保持されたまま、別々の「Product A」および「Product B」セルが含まれます。詳細は [Cell API Reference](https://reference.aspose.com/slides/cpp/aspose.slides/cell/) を参照してください。

## **表セルの背景色を変更**

この例では、列幅 150 ポイント、行高さ 50 ポイントの表を作成します。[set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) を使用して単色塗りつぶしを選択し、[get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_solidfillcolor/) で塗りつぶしカラーにアクセスし、セル `(2, 3)`（3 列目、4 行目）の色を赤に設定します。

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

## **表セル内に画像を追加**

この例を実行する前に、入力画像を作業ディレクトリに配置してください。画像は [Images::FromFile](https://reference.aspose.com/slides/cpp/aspose.slides/images/fromfile/) で読み込み、[AddImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimagecollection/addimage/) を使用してプレゼンテーションの画像コレクションに追加します。その後、画像を表の最初のセルである `(0, 0)` のピクチャーフィルに割り当てます。

[PictureFillMode::Stretch](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/) は画像を伸張してセルを埋めますが、アスペクト比が変わる可能性があります。列幅と行高さはポイントで指定されます。読み込んだ画像はプレゼンテーションに追加された後に破棄されます。

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

**単一セルの各辺に対して異なる線の太さやスタイルを設定できますか？**

はい。[top](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_bordertop/)/[bottom](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderbottom/)/[left](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderleft/)/[right](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderright/) の境界線は個別のプロパティを持っているため、各辺の太さやスタイルを異なるように設定できます。

**セルの背景に画像を設定した後に列や行のサイズを変更するとどうなりますか？**

動作は[フィルモード](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/)に依存します。stretch（伸張）を使用すると、画像は新しいセルサイズに合わせて調整されます。tile（タイル）を使用すると、タイルが再計算されます。

**セルの内容全体にハイパーリンクを割り当てられますか？**

[Hyperlinks](/slides/ja/cpp/manage-hyperlinks/) は、セルのテキストフレーム内のテキスト（ポーション）レベル、またはテーブル/シェイプ全体のレベルで設定されます。実際には、リンクはポーションに対して、またはセル内のすべてのテキストに対して割り当てます。

**単一セル内で異なるフォントを設定できますか？**

はい。セルのテキストフレームは、[portions](https://reference.aspose.com/slides/cpp/aspose.slides/portion/)（ラン）をサポートしており、フォント ファミリー、スタイル、サイズ、カラーなどを個別に書式設定できます。