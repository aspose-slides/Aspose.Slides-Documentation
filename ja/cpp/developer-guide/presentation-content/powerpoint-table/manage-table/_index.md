---
title: C++でプレゼンテーションのテーブルを管理する
linktitle: テーブルを管理
type: docs
weight: 10
url: /ja/cpp/manage-table/
keywords:
- テーブルの追加
- テーブルの作成
- テーブルへのアクセス
- アスペクト比
- テキストの配置
- テキストの書式設定
- テーブルスタイル
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint スライド内のテーブルを作成および編集します。テーブル作業を効率化するシンプルなコード例をご紹介します。"
---

PowerPoint のテーブルは、情報を表示・表現する効率的な方法です。行と列で構成されたセルのグリッド内の情報は、シンプルで理解しやすいです。

Aspose.Slides は、[Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/) クラス、[ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) インターフェイス、[Cell](https://reference.aspose.com/slides/cpp/aspose.slides/cell/) クラス、[ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) インターフェイス、およびその他の型を提供し、さまざまなプレゼンテーションでテーブルを作成、更新、管理できるようにします。 

## **テーブルを最初から作成する**

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスでスライドの参照を取得します。  
3. `columnWidth` の配列を定義します。  
4. `rowHeight` の配列を定義します。  
5. [AddTable()](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/) メソッドを使用して、スライドに [ITable] オブジェクトを追加します。  
6. 各 [ICell] を反復処理し、上部、下部、右部、左部の境界線に書式設定を適用します。  
7. テーブルの最初の行の最初の 2 つのセルを結合します。  
8. [ICell] の [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/textframe/) にアクセスします。  
9. [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/textframe/) にテキストを追加します。  
10. 変更されたプレゼンテーションを保存します。

この C++ コードは、プレゼンテーションでテーブルを作成する方法を示しています：
```c++
// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
auto pres = System::MakeObject<Presentation>();

// 最初のスライドにアクセスします
auto sld = pres->get_Slides()->idx_get(0);

// 列の幅と行の高さを定義します
auto dblCols = System::MakeArray<double>({ 50, 50, 50 });
auto dblRows = System::MakeArray<double>({ 50, 30, 30, 30, 30 });

// スライドにテーブル形状を追加します
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

標準テーブルでは、セルの番号付けはシンプルで0ベースです。テーブルの最初のセルは 0,0（列0、行0）とインデックス付けされます。

例えば、4 列 4 行のテーブルのセルは次のように番号付けされます：

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

この C++ コードは、テーブル内のセルの番号付けを指定する方法を示しています：
```c++
// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
auto pres = System::MakeObject<Presentation>();

// 最初のスライドにアクセスします
auto sld = pres->get_Slides()->idx_get(0);

// 列の幅と行の高さを定義します
auto dblCols = System::MakeArray<double>({ 70, 70, 70, 70 });
auto dblRows = System::MakeArray<double>({ 70, 70, 70, 70 });

// スライドにテーブル形状を追加します
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


## **既存のテーブルにアクセスする**

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスでテーブルを含むスライドへの参照を取得します。  
3. [ITable] オブジェクトを作成し、null に設定します。  
4. テーブルが見つかるまで、すべての [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) オブジェクトを反復処理します。  
   スライドに単一のテーブルが含まれていると疑われる場合は、含まれるすべてのシェイプを単純にチェックできます。シェイプがテーブルとして識別されたら、[Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/) オブジェクトに型キャストできます。ただし、スライドに複数のテーブルが含まれている場合は、[set_AlternativeText()](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_alternativetext/) を使用して目的のテーブルを検索した方がよいでしょう。  
5. テーブルを操作するには [ITable] オブジェクトを使用します。以下の例では、テーブルに新しい行を追加しました。  
6. 変更されたプレゼンテーションを保存します。

この C++ コードは、既存のテーブルにアクセスして操作する方法を示しています：
```c++
// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
auto pres = System::MakeObject<Presentation>(u"UpdateExistingTable.pptx");

// 最初のスライドにアクセスします
auto sld = pres->get_Slides()->idx_get(0);

// null の Table を初期化します
System::SharedPtr<ITable> tbl;

// 形状を走査し、見つかったテーブルへの参照を設定します
for (const auto& shp : System::IterateOver(sld->get_Shapes()))
{
    if (System::ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// 第2行の第1列のテキストを設定します
tbl->idx_get(0, 1)->get_TextFrame()->set_Text(u"New");

// 変更されたプレゼンテーションをディスクに保存します
pres->Save(u"table1_out.pptx", SaveFormat::Pptx);
```


## **テーブル内のテキストを揃える**

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスでスライドの参照を取得します。  
3. スライドに [ITable] オブジェクトを追加します。  
4. テーブルから [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) オブジェクトにアクセスします。  
5. [ITextFrame] の [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/) にアクセスします。  
6. テキストを垂直方向に揃えます。  
7. 変更されたプレゼンテーションを保存します。

この C++ コードは、テーブル内のテキストを揃える方法を示しています：
```c++
// Presentation クラスのインスタンスを作成します
auto presentation = System::MakeObject<Presentation>();

// 最初のスライドを取得します
auto slide = presentation->get_Slides()->idx_get(0);

// 列の幅と行の高さを定義します
auto dblCols = System::MakeArray<double>({ 120, 120, 120, 120 });
auto dblRows = System::MakeArray<double>({ 100, 100, 100, 100 });

// スライドにテーブル形状を追加します
auto tbl = slide->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);
tbl->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
tbl->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
tbl->idx_get(3, 0)->get_TextFrame()->set_Text(u"30");

// テキスト フレームにアクセスします
auto txtFrame = tbl->idx_get(0, 0)->get_TextFrame();

// テキスト フレーム用の Paragraph オブジェクトを作成します
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


## **テーブルレベルでテキスト書式設定を行う**

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. インデックスでスライドの参照を取得します。  
3. スライドから [ITable] オブジェクトにアクセスします。  
4. テキストの [set_FontHeight()](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) を設定します。  
5. [set_Alignment()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) と [set_MarginRight()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/) を設定します。  
6. [set_TextVerticalType()](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/) を設定します。  
7. 変更されたプレゼンテーションを保存します。

この C++ コードは、テーブルのテキストに希望の書式設定を適用する方法を示しています：
```c++
// Presentation クラスのインスタンスを作成します
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);

// 最初のスライドの最初のシェイプがテーブルであると仮定します
auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

// テーブルセルのフォント高さを設定します
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->SetTextFormat(portionFormat);

// テーブルセルのテキスト配置と右マージンを一度に設定します
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->SetTextFormat(paragraphFormat);

// テーブルセルのテキスト縦方向タイプを設定します
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->SetTextFormat(textFrameFormat);

presentation->Save(u"result.pptx", SaveFormat::Pptx);
```


## **テーブルのスタイルプロパティを取得する**

Aspose.Slides を使用すると、テーブルのスタイルプロパティを取得でき、取得した詳細を別のテーブルや他の場所で使用できます。この C++ コードは、テーブルのプリセットスタイルからスタイルプロパティを取得する方法を示しています：
```c++
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```


## **テーブルのアスペクト比をロックする**

幾何学的形状のアスペクト比は、異なる次元におけるサイズの比率です。Aspose.Slides は、テーブルやその他のシェイプのアスペクト比設定をロックできる `AspectRatioLocked()` プロパティを提供しています。この C++ コードは、テーブルのアスペクト比をロックする方法を示しています：
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto table = System::ExplicitCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());


table->get_GraphicalObjectLock()->set_AspectRatioLocked(!table->get_GraphicalObjectLock()->get_AspectRatioLocked());

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```


## **FAQ**

**テーブル全体とセル内のテキストに右から左 (RTL) の読み方向を有効にできますか？**

はい。テーブルは [set_RightToLeft](https://reference.aspose.com/slides/cpp/aspose.slides/table/set_righttoleft/) メソッドを公開しており、段落には [ParagraphFormat::set_RightToLeft](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphformat/set_righttoleft/) が用意されています。両方を使用することで、セル内の正しい RTL 順序とレンダリングが保証されます。

**最終ファイルでユーザーがテーブルを移動またはサイズ変更できないようにするにはどうすればよいですか？**

テーブルに対しても適用できる、[shape locks](/slides/ja/cpp/applying-protection-to-presentation/) を使用して、移動、サイズ変更、選択などを無効化します。

**セル内に画像を背景として挿入することはサポートされていますか？**

はい。セルに [picture fill](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillformat/) を設定できます。画像は選択したモード（伸縮またはタイル）に従ってセル領域を覆います。