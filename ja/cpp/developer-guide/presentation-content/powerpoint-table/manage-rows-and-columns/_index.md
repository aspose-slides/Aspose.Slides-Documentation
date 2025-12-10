---
title: C++ を使用した PowerPoint テーブルの行と列の管理
linktitle: 行と列
type: docs
weight: 20
url: /ja/cpp/manage-rows-and-columns/
keywords:
- テーブル行
- テーブル列
- 最初の行
- テーブルヘッダー
- 行のクローン
- 列のクローン
- 行のコピー
- 列のコピー
- 行の削除
- 列の削除
- 行テキスト書式設定
- 列テキスト書式設定
- テーブルスタイル
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して PowerPoint のテーブル行と列を管理し、プレゼンテーションの編集やデータ更新を高速化します。"
---

PowerPoint プレゼンテーションでテーブルの行と列を管理できるように、Aspose.Slides は [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/) クラス、[ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) インターフェイス、その他多数の型を提供します。 

## **最初の行をヘッダーとして設定**

1. Presentation クラスのインスタンスを作成し、プレゼンテーションをロードします。 
2. インデックスを使用してスライドの参照を取得します。 
3. ITable オブジェクトを作成し、null に設定します。 
4. すべての IShape オブジェクトを列挙し、対象のテーブルを見つけます。 
5. テーブルの最初の行をヘッダーとして設定します。 

この C++ コードはテーブルの最初の行をヘッダーとして設定する方法を示します:
```c++
// Presentation クラスのインスタンスを作成 
auto pres = System::MakeObject<Presentation>(u"table.pptx");

// 最初のスライドにアクセス 
auto sld = pres->get_Slides()->idx_get(0);

// null TableEx を初期化 
SharedPtr<ITable> tbl;

// シェイプを列挙し、テーブルへの参照を設定 
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

1. Presentation クラスのインスタンスを作成し、プレゼンテーションをロードします、 
2. インデックスを使用してスライドの参照を取得します。 
3. `columnWidth` の配列を定義します。 
4. `rowHeight` の配列を定義します。 
5. AddTable() メソッドを使用して、スライドに ITable オブジェクトを追加します。 
6. テーブル行をクローンします。 
7. テーブル列をクローンします。 
8. 変更されたプレゼンテーションを保存します。 

この C++ コードは PowerPoint テーブルの行または列をクローンする方法を示します:
```c++
 // ドキュメントディレクトリへのパス。
const String outPath = u"../out/CloningInTable_out.pptx";

// Presentation クラスのインスタンスを作成
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 最初のスライドにアクセス
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// 列幅と行高さを定義
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// スライドにテーブルシェイプを追加
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// 各セルの罫線書式を設定
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

// AddClone はテーブルの末尾に行を追加
table->get_Rows()->AddClone(table->get_Rows()->idx_get(0), false);

// InsertClone はテーブルの特定の位置に行を追加
table->get_Rows()->InsertClone(2, table->get_Rows()->idx_get(0), false);

// AddClone はテーブルの末尾に列を追加
table->get_Columns()->AddClone(table->get_Columns()->idx_get(0), false);

// InsertClone はテーブルの特定の位置に列を追加
table->get_Columns()->InsertClone(2, table->get_Columns()->idx_get(0), false);


// プレゼンテーションをディスクに保存
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **テーブルから行または列を削除**

1. Presentation クラスのインスタンスを作成し、プレゼンテーションをロードします、 
2. インデックスを使用してスライドの参照を取得します。 
3. `columnWidth` の配列を定義します。 
4. `rowHeight` の配列を定義します。 
5. AddTable() メソッドを使用して、スライドに ITable オブジェクトを追加します。 
6. テーブル行を削除します。 
7. テーブル列を削除します。 
8. 変更されたプレゼンテーションを保存します。 

この C++ コードはテーブルから行または列を削除する方法を示します:
```c++
// ドキュメントディレクトリへのパス。
const String outPath = u"../out/RemovingRowColumn_out.pptx";

// Presentation クラスのインスタンスを作成
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 最初のスライドにアクセス
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// 列幅と行高さを定義
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// スライドにテーブルシェイプを追加
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);

table->get_Rows()->RemoveAt(1, false);
table->get_Columns()->RemoveAt(1, false);


// セル (1, 1) と (2, 1) を結合
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// セル (1, 2) と (2, 2) を結合
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// プレゼンテーションをディスクに保存
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **テーブル行レベルでテキスト書式を設定**

1. Presentation クラスのインスタンスを作成し、プレゼンテーションをロードします、 
2. インデックスを使用してスライドの参照を取得します。 
3. スライドから対象の ITable オブジェクトにアクセスします。 
4. 最初の行のセルの set_FontHeight() を設定します。 
5. 最初の行のセルの set_Alignment() と set_MarginRight() を設定します。 
6. 2 行目のセルの set_TextVerticalType() を設定します。 
7. 変更されたプレゼンテーションを保存します。 

この C++ コードは操作を示します。
```c++
// Presentation クラスのインスタンスを作成します
auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slides()->idx_get(0);

auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
// 最初のスライドの最初のシェイプがテーブルであると仮定します
// 最初の行のセルのフォント高さを設定します
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->get_Rows()->idx_get(0)->SetTextFormat(portionFormat);

// 最初の行のセルの文字揃えと右余白を設定します
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->get_Rows()->idx_get(0)->SetTextFormat(paragraphFormat);

// 2 行目のセルのテキストの垂直方向タイプを設定します
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->get_Rows()->idx_get(1)->SetTextFormat(textFrameFormat);

// プレゼンテーションをディスクに保存します
presentation->Save(u"result.pptx", SaveFormat::Pptx);
```


## **テーブル列レベルでテキスト書式を設定**

1. Presentation クラスのインスタンスを作成し、プレゼンテーションをロードします、 
2. インデックスを使用してスライドの参照を取得します。 
3. スライドから対象の ITable オブジェクトにアクセスします。 
4. 最初の列のセルの set_FontHeight() を設定します。 
5. 最初の列のセルの set_Alignment() と set_MarginRight() を設定します。 
6. 2 列目のセルの set_TextVerticalType() を設定します。 
7. 変更されたプレゼンテーションを保存します。 

この C++ コードは操作を示します: 
```c++
// Presentation クラスのインスタンスを作成します
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);

auto someTable = System::AsCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
// 最初のスライドの最初のシェイプがテーブルであると仮定します

// 最初の列のセルのフォント高さを設定します
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->get_Columns()->idx_get(0)->SetTextFormat(portionFormat);

// 最初の列のセルの文字揃えと右余白を1回の呼び出しで設定します
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->get_Columns()->idx_get(0)->SetTextFormat(paragraphFormat);

// 2番目の列のセルのテキストの垂直方向タイプを設定します
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->get_Columns()->idx_get(1)->SetTextFormat(textFrameFormat);

pres->Save(u"result.pptx", SaveFormat::Pptx);
```


## **テーブルのスタイルプロパティを取得**

Aspose.Slides はテーブルのスタイルプロパティを取得でき、別のテーブルや他の場所でその詳細を使用できます。この C++ コードは、テーブルのプリセットスタイルからスタイルプロパティを取得する方法を示します:
```c++
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```


## **FAQ**

**既に作成されたテーブルに PowerPoint のテーマ/スタイルを適用できますか？**

はい。テーブルはスライド／レイアウト／マスターテーマを継承しますが、そのテーマの上に塗りつぶし、枠線、テキストの色を上書きすることも可能です。

**Excel のようにテーブル行をソートできますか？**

いいえ、Aspose.Slides のテーブルには組み込みのソートやフィルター機能はありません。データをメモリ内で先にソートし、その順序でテーブル行を再配置してください。

**特定のセルにカスタムカラーを保持したまま、バンド（ストライプ）列を使用できますか？**

はい。バンド化された列を有効にし、特定のセルにローカルの書式設定で上書きすれば、セルレベルの書式設定がテーブルスタイルより優先されます。