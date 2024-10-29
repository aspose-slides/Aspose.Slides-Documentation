---
title: 行と列の管理
type: docs
weight: 20
url: /ja/cpp/manage-rows-and-columns/
keywords: "テーブル, テーブルの行と列, PowerPointプレゼンテーション, C++, CPP, Aspose.Slides for C++"
description: "C++でPowerPointプレゼンテーションのテーブルの行と列を管理する"

---

PowerPointプレゼンテーションのテーブルの行と列を管理できるように、Aspose.Slidesは[Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/)クラス、[ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/)インターフェース、その他多くの型を提供します。

## **最初の行をヘッダーとして設定**

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)クラスのインスタンスを作成し、プレゼンテーションをロードします。
2. インデックスを使用してスライドの参照を取得します。
3. [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/)オブジェクトを作成し、nullに設定します。
4. すべての[IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/)オブジェクトをイテレートして、関連するテーブルを見つけます。
5. テーブルの最初の行をヘッダーとして設定します。

このC++コードは、テーブルの最初の行をヘッダーとして設定する方法を示しています：

```c++
// Presentationクラスのインスタンスを作成
auto pres = System::MakeObject<Presentation>(u"table.pptx");

// 最初のスライドにアクセス
auto sld = pres->get_Slides()->idx_get(0);

// nullのTableExを初期化
SharedPtr<ITable> tbl;

// シェイプをイテレートし、テーブルへの参照を設定
for (const auto& shp : sld->get_Shapes())
{
    if (ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// テーブルの最初の行をヘッダーとして設定
tbl->set_FirstRow(true);
```

## **テーブルの行または列をクローン**

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)クラスのインスタンスを作成し、プレゼンテーションをロードします。
2. インデックスを使用してスライドの参照を取得します。
3. `columnWidth`の配列を定義します。
4. `rowHeight`の配列を定義します。
5. [AddTable()](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/)メソッドを介してスライドに[ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/)オブジェクトを追加します。
6. テーブルの行をクローンします。
7. テーブルの列をクローンします。
8. 修正されたプレゼンテーションを保存します。

このC++コードは、PowerPointテーブルの行または列をクローンする方法を示しています：

```c++
// ドキュメントディレクトリへのパス
const String outPath = u"../out/CloningInTable_out.pptx";

// Presentationクラスのインスタンスを作成
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 最初のスライドにアクセス
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// 幅を持つ列と高さを持つ行を定義
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// スライドにテーブルシェイプを追加
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);

// 各セルのボーダーフォーマットを設定
for (int x = 0; x < table->get_Rows()->get_Count(); x++)
{
	SharedPtr<IRow> row = table->get_Rows()->idx_get(x);
	for (int y = 0; y < row->get_Count(); y++)
	{
		SharedPtr<ICell> cell = row->idx_get(y);

		cell->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
		cell->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
		cell->get_BorderTop()->set_Width(5);

		cell->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::Solid);
		cell->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
		cell->get_BorderBottom()->set_Width(5);

		cell->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
		cell->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
		cell->get_BorderLeft()->set_Width(5);

		cell->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
		cell->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
		cell->get_BorderRight()->set_Width(5);
	}
}

table->idx_get(0, 0)->get_TextFrame()->set_Text(u"00");
table->idx_get(0, 1)->get_TextFrame()->set_Text(u"01");
table->idx_get(0, 2)->get_TextFrame()->set_Text(u"02");
table->idx_get(0, 3)->get_TextFrame()->set_Text(u"03");
table->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
table->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
table->idx_get(1, 1)->get_TextFrame()->set_Text(u"11");
table->idx_get(2, 1)->get_TextFrame()->set_Text(u"21");

// AddCloneはテーブルの最後に行を追加します
table->get_Rows()->AddClone(table->get_Rows()->idx_get(0), false);

// InsertCloneはテーブルの指定した位置に行を追加します
table->get_Rows()->InsertClone(2, table->get_Rows()->idx_get(0), false);

// AddCloneはテーブルの最後に列を追加します
table->get_Columns()->AddClone(table->get_Columns()->idx_get(0), false);

// InsertCloneはテーブルの指定した位置に列を追加します
table->get_Columns()->InsertClone(2, table->get_Columns()->idx_get(0), false);

// プレゼンテーションをディスクに保存
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **テーブルから行または列を削除**

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)クラスのインスタンスを作成し、プレゼンテーションをロードします。
2. インデックスを使用してスライドの参照を取得します。
3. `columnWidth`の配列を定義します。
4. `rowHeight`の配列を定義します。
5. [AddTable()](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/)メソッドを介してスライドに[ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/)オブジェクトを追加します。
6. テーブルの行を削除します。
7. テーブルの列を削除します。
8. 修正されたプレゼンテーションを保存します。

このC++コードは、テーブルから行または列を削除する方法を示しています：

```c++
// ドキュメントディレクトリへのパス
const String outPath = u"../out/RemovingRowColumn_out.pptx";

// Presentationクラスのインスタンスを作成
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 最初のスライドにアクセス
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// 幅を持つ列と高さを持つ行を定義
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// スライドにテーブルシェイプを追加
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);

table->get_Rows()->RemoveAt(1, false);
table->get_Columns()->RemoveAt(1, false);

// セル(1, 1) x (2, 1)をマージ
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// セル(1, 2) x (2, 2)をマージ
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);

// プレゼンテーションをディスクに保存
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **テーブル行レベルでのテキストフォーマット設定**

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)クラスのインスタンスを作成し、プレゼンテーションをロードします。
2. インデックスを使用してスライドの参照を取得します。
3. スライドから関連する[ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/)オブジェクトにアクセスします。
4. 最初の行のセルの[set_FontHeight()](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/)を設定します。
5. 最初の行のセルの[set_Alignment()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/)および[set_MarginRight()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/)を設定します。
6. 二行目のセルの[set_TextVerticalType()](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/)を設定します。
7. 修正されたプレゼンテーションを保存します。

このC++コードは、操作を示しています：

```c++
// Presentationクラスのインスタンスを作成
auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slides()->idx_get(0);

auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
// 最初のスライドの最初のシェイプがテーブルであると仮定します
// 最初の行のセルのフォント高さを設定
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->get_Rows()->idx_get(0)->SetTextFormat(portionFormat);

// 最初の行のセルのテキストの整列と右のマージンを設定
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->get_Rows()->idx_get(0)->SetTextFormat(paragraphFormat);

// 二行目のセルのテキストの垂直タイプを設定
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->get_Rows()->idx_get(1)->SetTextFormat(textFrameFormat);

// プレゼンテーションをディスクに保存
presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **テーブル列レベルでのテキストフォーマット設定**

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)クラスのインスタンスを作成し、プレゼンテーションをロードします。
2. インデックスを使用してスライドの参照を取得します。
3. スライドから関連する[ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/)オブジェクトにアクセスします。
4. 最初の列のセルの[set_FontHeight()](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/)を設定します。
5. 最初の列のセルの[set_Alignment()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/)および[set_MarginRight()](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/)を設定します。
6. 二列目のセルの[set_TextVerticalType()](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/)を設定します。
7. 修正されたプレゼンテーションを保存します。

このC++コードは、操作を示しています：

```c++
// Presentationクラスのインスタンスを作成
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);

auto someTable = System::AsCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
// 最初のスライドの最初のシェイプがテーブルであると仮定します

// 最初の列のセルのフォント高さを設定
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->get_Columns()->idx_get(0)->SetTextFormat(portionFormat);

// 最初の列のセルのテキストの整列と右のマージンを一度の呼び出しで設定
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->get_Columns()->idx_get(0)->SetTextFormat(paragraphFormat);

// 二列目のセルのテキストの垂直タイプを設定
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->get_Columns()->idx_get(1)->SetTextFormat(textFrameFormat);

pres->Save(u"result.pptx", SaveFormat::Pptx);
```

## **テーブルスタイルプロパティの取得**

Aspose.Slidesは、テーブルのスタイルプロパティを取得して、その詳細を別のテーブルや他の場所で使用できるようにします。このC++コードは、テーブルのプリセットスタイルからスタイルプロパティを取得する方法を示しています：

```c++
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```