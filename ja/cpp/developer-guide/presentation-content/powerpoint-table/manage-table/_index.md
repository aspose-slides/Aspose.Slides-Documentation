---
title: テーブルの管理
type: docs
weight: 10
url: /ja/cpp/manage-table/
keywords: "テーブル, テーブルの作成, テーブルへのアクセス, テーブルのアスペクト比, PowerPointプレゼンテーション, C++, Aspose.Slides for C++"
description: "C++でPowerPointプレゼンテーションのテーブルを作成および管理します"
---

PowerPointのテーブルは、情報を表示し伝える効率的な方法です。セルのグリッド内の情報（行と列で配列されています）は、明確で理解しやすいです。

Aspose.Slidesは、さまざまなプレゼンテーションでテーブルを作成、更新、管理するために、[Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/)クラス、[ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/)インターフェース、[Cell](https://reference.aspose.com/slides/cpp/aspose.slides/cell/)クラス、[ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/)インターフェース、およびその他のタイプを提供します。

## **ゼロからテーブルを作成する**

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。 
3. `columnWidth`の配列を定義します。
4. `rowHeight`の配列を定義します。
5. [AddTable()](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/)メソッドを通じてスライドに[ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/)オブジェクトを追加します。
6. 各[ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/)を繰り返して、上、下、右、左の境界にフォーマットを適用します。
7. テーブルの最初の行の最初の2つのセルをマージします。 
8. [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/)の[TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/textframe/)にアクセスします。 
9. [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/textframe/)にテキストを追加します。
10. 修正されたプレゼンテーションを保存します。

このC++コードは、プレゼンテーションにテーブルを作成する方法を示しています：

```c++
// PPTXファイルを表すPresentationクラスをインスタンス化
auto pres = System::MakeObject<Presentation>();

// 最初のスライドにアクセス
auto sld = pres->get_Slides()->idx_get(0);

// 幅のある列と高さのある行を定義
auto dblCols = System::MakeArray<double>({ 50, 50, 50 });
auto dblRows = System::MakeArray<double>({ 50, 30, 30, 30, 30 });

// スライドにテーブル形状を追加
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// 各セルの境界フォーマットを設定
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
// 行1のセル1 & 2をマージ
tbl->MergeCells(tbl->get_Rows()->idx_get(0)->idx_get(0), tbl->get_Rows()->idx_get(1)->idx_get(1), false);

// マージされたセルにテキストを追加
tbl->get_Rows()->idx_get(0)->idx_get(0)->get_TextFrame()->set_Text(u"マージされたセル");

// プレゼンテーションをディスクに保存
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **標準テーブルの番号付け**

標準テーブルでは、セルの数値はわかりやすく、ゼロベースです。テーブルの最初のセルは0,0（列0、行0）としてインデックス付けされます。 

たとえば、4列4行のテーブル内のセルは次のように番号付けされています：

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

このC++コードは、テーブル内のセルに対する番号付けを指定する方法を示しています：

```c++
// PPTXファイルを表すPresentationクラスをインスタンス化
auto pres = System::MakeObject<Presentation>();

// 最初のスライドにアクセス
auto sld = pres->get_Slides()->idx_get(0);

// 幅のある列と高さのある行を定義
auto dblCols = System::MakeArray<double>({ 70, 70, 70, 70 });
auto dblRows = System::MakeArray<double>({ 70, 70, 70, 70 });

// スライドにテーブル形状を追加
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// 各セルの境界フォーマットを設定
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

// プレゼンテーションをディスクに保存
pres->Save(u"StandardTables_out.pptx", SaveFormat::Pptx);
```

## **既存のテーブルにアクセスする**

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)クラスのインスタンスを作成します。

2. インデックスを通じてテーブルを含むスライドの参照を取得します。 

3. [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/)オブジェクトを作成し、nullに設定します。

4. テーブルが見つかるまで、すべての[IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/)オブジェクトを繰り返します。

   スライドに単一のテーブルが含まれていると疑われる場合は、そのすべての図形を確認できます。図形がテーブルとして特定された場合は、それを[Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/)オブジェクトとしてキャストできます。しかし、扱っているスライドに複数のテーブルがある場合は、[set_AlternativeText()](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_alternativetext/)を通じて必要なテーブルを検索する方が良いです。

5. [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/)オブジェクトを使用してテーブルに対処します。以下の例では、テーブルに新しい行を追加しました。

6. 修正されたプレゼンテーションを保存します。

このC++コードは、既存のテーブルにアクセスして操作する方法を示しています：

```c++
// PPTXファイルを表すPresentationクラスをインスタンス化
auto pres = System::MakeObject<Presentation>(u"UpdateExistingTable.pptx");

// 最初のスライドにアクセス
auto sld = pres->get_Slides()->idx_get(0);

// nullのテーブルを初期化
System::SharedPtr<ITable> tbl;

// 図形を繰り返し、見つかったテーブルへの参照を設定
for (const auto& shp : System::IterateOver(sld->get_Shapes()))
{
    if (System::ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// 2行目の最初の列のテキストを設定
tbl->idx_get(0, 1)->get_TextFrame()->set_Text(u"新しい");

// 修正されたプレゼンテーションをディスクに保存
pres->Save(u"table1_out.pptx", SaveFormat::Pptx);
```

## **テーブル内のテキストを整列する**

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。 
3. スライドに[ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/)オブジェクトを追加します。 
4. テーブルから[ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/)オブジェクトにアクセスします。 
5. [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/)の[IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/)にアクセスします。
6. テキストを垂直方向に整列します。
7. 修正されたプレゼンテーションを保存します。

このC++コードは、テーブル内のテキストを整列する方法を示しています：

```c++
// プレゼンテーションクラスのインスタンスを作成
auto presentation = System::MakeObject<Presentation>();

// 最初のスライドを取得 
auto slide = presentation->get_Slides()->idx_get(0);

// 幅のある列と高さのある行を定義
auto dblCols = System::MakeArray<double>({ 120, 120, 120, 120 });
auto dblRows = System::MakeArray<double>({ 100, 100, 100, 100 });

// スライドにテーブル形状を追加
auto tbl = slide->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);
tbl->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
tbl->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
tbl->idx_get(3, 0)->get_TextFrame()->set_Text(u"30");

// テキストフレームにアクセス
auto txtFrame = tbl->idx_get(0, 0)->get_TextFrame();

// テキストフレーム用の段落オブジェクトを作成
auto paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// 段落用のポーションオブジェクトを作成
auto portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"ここにテキスト");
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// テキストを垂直方向に整列
auto cell = tbl->idx_get(0, 0);
cell->set_TextAnchorType(TextAnchorType::Center);
cell->set_TextVerticalType(TextVerticalType::Vertical270);

// プレゼンテーションをディスクに保存
presentation->Save(u"Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
```

## **テーブルレベルでのテキストフォーマットの設定**

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)クラスのインスタンスを作成します。
2. インデックスを通じてスライドの参照を取得します。 
3. スライドから[ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/)オブジェクトにアクセスします。
4. テキストに対して[set_FontHeight()](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/)を設定します。 
5. [set_Alignment()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/)および[set_MarginRight()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/)を設定します。 
6. [set_TextVerticalType()](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/)を設定します。
7. 修正されたプレゼンテーションを保存します。

このC++コードは、テーブル内のテキストに好みのフォーマットオプションを適用する方法を示しています：

```c++
// プレゼンテーションクラスのインスタンスを作成
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);

// 最初のスライドの最初の図形がテーブルであると仮定します
auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

// テーブルセルのフォント高さを設定
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->SetTextFormat(portionFormat);

// テーブルセルのテキストの整列と右マージンを一度の呼び出しで設定
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->SetTextFormat(paragraphFormat);

// テーブルセルのテキストの垂直タイプを設定
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->SetTextFormat(textFrameFormat);

presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **テーブルスタイルプロパティの取得**

Aspose.Slidesを使用すると、テーブルのスタイルプロパティを取得して、他のテーブルや他の場所で使用できます。このC++コードは、テーブルのプリセットスタイルからスタイルプロパティを取得する方法を示しています：

```c++
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **テーブルのアスペクト比をロックする**

幾何学的形状のアスペクト比は、異なる次元でのサイズの比率です。Aspose.Slidesは、テーブルや他の形状のアスペクト比設定をロックするための`AspectRatioLocked()`プロパティを提供します。

このC++コードは、テーブルのアスペクト比をロックする方法を示しています：

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto table = System::ExplicitCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

Console::WriteLine(u"アスペクト比ロック設定: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

table->get_GraphicalObjectLock()->set_AspectRatioLocked(!table->get_GraphicalObjectLock()->get_AspectRatioLocked());

Console::WriteLine(u"アスペクト比ロック設定: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```