---
title: C++ でプレゼンテーションテーブルを管理する
linktitle: テーブル管理
type: docs
weight: 10
url: /ja/cpp/manage-table/
keywords:
- テーブルを追加
- テーブルを作成
- テーブルにアクセス
- アスペクト比
- テキストの配置
- テキスト書式設定
- テーブルスタイル
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "C++ 用 Aspose.Slides で PowerPoint スライド内のテーブルを作成および編集します。テーブルのワークフローを効率化するシンプルなコード例をご紹介します。"
---
## **はじめに**

PowerPoint のテーブルは、情報を表示および表現する効率的な方法です。行と列に配置されたセルのグリッド内の情報は、シンプルで理解しやすいです。

Aspose.Slides は、[Table](https://reference.aspose.com/slides/ja/cpp/aspose.slides/table/) クラス、[ITable](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itable/) インターフェイス、[Cell](https://reference.aspose.com/slides/ja/cpp/aspose.slides/cell/) クラス、[ICell](https://reference.aspose.com/slides/ja/cpp/aspose.slides/icell/) インターフェイスなどの型を提供し、さまざまなプレゼンテーションでテーブルの作成、更新、管理が可能です。 

## **テーブルをゼロから作成**

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. `columnWidth` の配列を定義します。  
4. `rowHeight` の配列を定義します。  
5. [AddTable()](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishapecollection/addtable/) メソッドを使用して、スライドに [ITable](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itable/) オブジェクトを追加します。  
6. 各 [ICell](https://reference.aspose.com/slides/ja/cpp/aspose.slides/icell/) を反復処理し、上・下・右・左の罫線に書式設定を適用します。  
7. テーブルの最初の行の最初の 2 つのセルを結合します。  
8. [ICell](https://reference.aspose.com/slides/ja/cpp/aspose.slides/icell/) の [TextFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/textframe/) にアクセスします。  
9. [TextFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/textframe/) にテキストを追加します。  
10. 変更したプレゼンテーションを保存します。

この C++ コードは、プレゼンテーションでテーブルを作成する方法を示しています。

```c++
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
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

// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
auto pres = System::MakeObject<Presentation>();

// 最初のスライドにアクセスします
auto sld = pres->get_Slides()->idx_get(0);

// 列の幅と行の高さを定義します
auto dblCols = System::MakeArray<double>({ 50, 50, 50 });
auto dblRows = System::MakeArray<double>({ 50, 30, 30, 30, 30 });

// スライドにテーブルシェイプを追加します
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// 各セルの罫線書式を設定します
for (int32_t row = 0; row < tbl->get_Rows()->get_Count(); row++)
{
    for (int32_t cell = 0; cell < tbl->get_Rows()->idx_get(row)->get_Count(); cell++)
    {
        auto cellFormat = tbl->get_Rows()->idx_get(row)->idx_get(cell)->get_CellFormat();

        cellFormat->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderTop()->set_Width(5);

        cellFormat->get_BorderBottom()->get_FillFormat()->set_FillType((FillType::Solid));
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
// 1 行目のセル 1 と 2 を結合します
tbl->MergeCells(tbl->get_Rows()->idx_get(0)->idx_get(0), tbl->get_Rows()->idx_get(1)->idx_get(1), false);

// 結合されたセルにテキストを追加します
tbl->get_Rows()->idx_get(0)->idx_get(0)->get_TextFrame()->set_Text(u"Merged Cells");

// プレゼンテーションをディスクに保存します
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **標準テーブルの番号付け**

標準テーブルでは、セルの番号付けはシンプルでゼロベースです。テーブルの最初のセルは 0,0 (列 0、行 0) とインデックス付けされます。

たとえば、4 列 4 行のテーブルのセルは以下のように番号付けされます。

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

この C++ コードは、テーブル内のセルの番号付けを指定する方法を示しています。

```c++
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
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

// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
auto pres = System::MakeObject<Presentation>();

// 最初のスライドにアクセスします
auto sld = pres->get_Slides()->idx_get(0);

// 列の幅と行の高さを定義します
auto dblCols = System::MakeArray<double>({ 70, 70, 70, 70 });
auto dblRows = System::MakeArray<double>({ 70, 70, 70, 70 });

// スライドにテーブルシェイプを追加します
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// 各セルの罫線書式を設定します
for (const auto& row : tbl->get_Rows())
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

// プレゼンテーションをディスクに保存します
pres->Save(u"StandardTables_out.pptx", SaveFormat::Pptx);
```

## **既存のテーブルにアクセス**

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。  

2. インデックスを使用して、テーブルが含まれるスライドへの参照を取得します。  

3. [ITable](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itable/) オブジェクトを作成し、null に設定します。  

4. テーブルが見つかるまで、すべての [IShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishape/) オブジェクトを反復処理します。  
   テーブルが 1 つだけ含まれていると疑われる場合は、含まれるすべてのシェイプをチェックすればよいです。シェイプがテーブルとして識別されたら、[Table](https://reference.aspose.com/slides/ja/cpp/aspose.slides/table/) オブジェクトに型キャストできます。複数のテーブルが含まれている場合は、[set_AlternativeText()](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishape/set_alternativetext/) を使用して目的のテーブルを検索した方が良いでしょう。  

5. [ITable](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itable/) オブジェクトを使用してテーブルを操作します。以下の例では、テーブルに新しい行を追加しました。  

6. 変更したプレゼンテーションを保存します。

この C++ コードは、既存のテーブルにアクセスして操作する方法を示しています。

```c++
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
auto pres = System::MakeObject<Presentation>(u"UpdateExistingTable.pptx");

// 最初のスライドにアクセスします
auto sld = pres->get_Slides()->idx_get(0);

// null の Table を初期化します
System::SharedPtr<ITable> tbl;

// シェイプを反復処理し、見つかったテーブルへの参照を設定します
for (const auto& shp : System::IterateOver(sld->get_Shapes()))
{
    if (System::ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// 2 行目の最初の列のテキストを設定します
tbl->idx_get(0, 1)->get_TextFrame()->set_Text(u"New");

// 変更したプレゼンテーションをディスクに保存します
pres->Save(u"table1_out.pptx", SaveFormat::Pptx);
```

## **テキストフレームを所有するセルを見つける**

テーブルから [ITextFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/) を受け取った汎用テキスト処理コードでは、[ITextFrame::get_ParentCell](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/get_parentcell/) を使用して所有する [ICell](https://reference.aspose.com/slides/ja/cpp/aspose.slides/icell/) を取得します。テーブルセルのテキストフレームの場合、[ITextFrame::get_ParentCell](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/get_parentcell/) は所有者を返し、[ITextFrame::get_ParentShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/get_parentshape/) は `nullptr` を返します（テーブル自体はシェイプです）。

セルの座標は、読み取り専用の [ICell::get_FirstColumnIndex](https://reference.aspose.com/slides/ja/cpp/aspose.slides/icell/get_firstcolumnindex/) と [ICell::get_FirstRowIndex](https://reference.aspose.com/slides/ja/cpp/aspose.slides/icell/get_firstrowindex/) メソッドで取得できます。[ITextFrame::get_ParentCell](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/get_parentcell/) も読み取り専用のナビゲーションを提供し、所有者を返しますが所有権は変更しません。使用する前に必ず返されたセルが `nullptr` でないか確認してください。

テーブルセルおよびシェイプの所有者（SmartArt ノードに関連付けられたシェイプを含む）を特定する完全な例については、[Search and Replace Text](/slides/ja/cpp/search-and-replace-text/) を参照してください。

## **テーブル内のテキストを揃える**

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. スライドに [ITable](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itable/) オブジェクトを追加します。  
4. テーブルから [ITextFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/) オブジェクトにアクセスします。  
5. [ITextFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/) の [IParagraph](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraph/) にアクセスします。  
6. テキストを垂直方向に揃えます。  
7. 変更したプレゼンテーションを保存します。

この C++ コードは、テーブル内のテキストを揃える方法を示しています。

```c++
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
#include <DOM/ISlideCollection.h>
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

// Presentation クラスのインスタンスを作成します
auto presentation = System::MakeObject<Presentation>();

// 最初のスライドを取得します
auto slide = presentation->get_Slides()->idx_get(0);

// 列の幅と行の高さを定義します
auto dblCols = System::MakeArray<double>({ 120, 120, 120, 120 });
auto dblRows = System::MakeArray<double>({ 100, 100, 100, 100 });

// スライドにテーブルシェイプを追加します
auto tbl = slide->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);
tbl->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
tbl->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
tbl->idx_get(3, 0)->get_TextFrame()->set_Text(u"30");

// テキストフレームにアクセスします
auto txtFrame = tbl->idx_get(0, 0)->get_TextFrame();

// テキストフレーム用の Paragraph オブジェクトを作成します
auto paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// Paragraph 用の Portion オブジェクトを作成します
auto portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Text here");
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// テキストを垂直方向に揃えます
auto cell = tbl->idx_get(0, 0);
cell->set_TextAnchorType(TextAnchorType::Center);
cell->set_TextVerticalType(TextVerticalType::Vertical270);

// プレゼンテーションをディスクに保存します
presentation->Save(u"Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
```

## **テーブルレベルでのテキスト書式設定**

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. スライドから [ITable](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itable/) オブジェクトにアクセスします。  
4. テキストのフォント高さを [set_FontHeight()](https://reference.aspose.com/slides/ja/cpp/aspose.slides/baseportionformat/set_fontheight/) で設定します。  
5. [set_Alignment()](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraphformat/set_alignment/) と [set_MarginRight()](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraphformat/set_marginright/) を設定します。  
6. [set_TextVerticalType()](https://reference.aspose.com/slides/ja/cpp/aspose.slides/textframeformat/set_textverticaltype/) を設定します。  
7. 変更したプレゼンテーションを保存します。

この C++ コードは、テーブル内のテキストに好みの書式設定オプションを適用する方法を示しています。

```c++
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
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

// Presentation クラスのインスタンスを作成します
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);

// 最初のスライドの最初のシェイプがテーブルであると仮定します
auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

// テーブルセルのフォント高さを設定します
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->SetTextFormat(portionFormat);

// テーブルセルのテキスト配置と右余白を一度に設定します
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->SetTextFormat(paragraphFormat);

// テーブルセルのテキスト垂直方向タイプを設定します
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->SetTextFormat(textFrameFormat);

presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **テーブルのスタイルプロパティを取得**

Aspose.Slides を使用すると、テーブルのスタイルプロパティを取得できるため、その詳細を別のテーブルや他の場所で利用できます。この C++ コードは、テーブルのプリセットスタイルからスタイルプロパティを取得する方法を示しています。

```c++
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <DOM/TableStylePreset.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **テーブルのアスペクト比をロックする**

幾何学的形状のアスペクト比は、異なる次元におけるサイズの比率です。Aspose.Slides は `AspectRatioLocked()` プロパティを提供し、テーブルや他のシェイプのアスペクト比設定をロックできるようにしました。

この C++ コードは、テーブルのアスペクト比をロックする方法を示しています。

```c++
#include <DOM/IGraphicalObjectLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto table = System::ExplicitCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());


table->get_GraphicalObjectLock()->set_AspectRatioLocked(!table->get_GraphicalObjectLock()->get_AspectRatioLocked());

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **よくある質問**

**テーブル全体とセル内のテキストに右から左（RTL）の読み方向を有効にできますか？**

はい。テーブルは [set_RightToLeft](https://reference.aspose.com/slides/ja/cpp/aspose.slides/table/set_righttoleft/) メソッドを公開しており、段落には [ParagraphFormat::set_RightToLeft](https://reference.aspose.com/slides/ja/cpp/aspose.slides/paragraphformat/set_righttoleft/) があります。両方を使用すると、セル内で正しい RTL 順序と描画が保証されます。

**最終ファイルでユーザーがテーブルを移動またはサイズ変更できないようにするにはどうすればよいですか？**

[shape locks](/slides/ja/cpp/applying-protection-to-presentation/) を使用して、移動、サイズ変更、選択などを無効にします。これらのロックはテーブルにも適用されます。

**セル内に画像を背景として挿入することはサポートされていますか？**

はい。セルに対して [picture fill](https://reference.aspose.com/slides/ja/cpp/aspose.slides/picturefillformat/) を設定できます。選択したモード（伸張またはタイル）に従って、画像がセル領域全体をカバーします。