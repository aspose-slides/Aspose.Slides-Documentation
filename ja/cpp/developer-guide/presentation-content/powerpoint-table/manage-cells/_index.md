---
title: セルの管理
type: docs
weight: 30
url: /ja/cpp/manage-cells/
keywords: "テーブル、結合セル、分割セル、テーブルセル内の画像、C++、CPP、Aspose.Slides for C++"
description: "C++によるPowerPointプレゼンテーションのテーブルセル"
---

## **結合セルの特定**
1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)クラスのインスタンスを作成します。
2. 最初のスライドからテーブルを取得します。 
3. テーブルの行と列を繰り返して結合セルを探します。
4. 結合セルが見つかったときにメッセージを表示します。

このC++コードは、プレゼンテーション内の結合テーブルセルを特定する方法を示しています：

``` cpp
auto pres = System::MakeObject<Presentation>(u"SomePresentationWithTable.pptx");
auto table = System::AsCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

// assuming that Slide#0.Shape#0 is a table
for (int32_t i = 0; i < table->get_Rows()->get_Count(); i++)
{
    for (int32_t j = 0; j < table->get_Columns()->get_Count(); j++)
    {
        auto currentCell = table->get_Rows()->idx_get(i)->idx_get(j);
        if (currentCell->get_IsMergedCell())
        {
            Console::WriteLine(String::Format(u"セル {0};{1} は、RowSpan={2} と ColSpan={3} の結合セルの一部で、最初のセルは {4};{5} から始まります。",
                i, j, currentCell->get_RowSpan(), currentCell->get_ColSpan(), currentCell->get_FirstRowIndex(), currentCell->get_FirstColumnIndex()));
        }
    }
}
```

## **テーブルセルの罫線を削除**
1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)クラスのインスタンスを作成します。
2. インデックスを介してスライドの参照を取得します。 
3. 幅のある列の配列を定義します。
4. 高さのある行の配列を定義します。
5. `AddTable`メソッドを通じてスライドにテーブルを追加します。
6. すべてのセルを繰り返して上、下、右、左の罫線をクリアします。
7. 修正したプレゼンテーションをPPTXファイルとして保存します。

このC++コードは、テーブルセルから罫線を削除する方法を示しています：

``` cpp
// PPTXファイルを表すPresentationクラスのインスタンスを作成
auto pres = MakeObject<Presentation>();
// 最初のスライドにアクセス
auto sld = pres->get_Slides()->idx_get(0);

// 幅のある列と高さのある行を定義
auto dblCols = MakeArray<double>({ 50, 50, 50, 50 });
auto dblRows = MakeArray<double>({ 50, 30, 30, 30, 30 });

// スライドにテーブル形状を追加
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// 各セルの罫線フォーマットを設定
for (const auto& row : System::IterateOver(tbl->get_Rows()))
{
    for (const auto& cell : System::IterateOver(row))
    {
        cell->get_CellFormat()->get_BorderTop()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderRight()->get_FillFormat()->set_FillType(FillType::NoFill);
    }
}

// PPTXファイルをディスクに書き込む
pres->Save(u"table_out.pptx", SaveFormat::Pptx);
```

## **結合セルの番号付け**
もし、(1, 1) x (2, 1) および (1, 2) x (2, 2) の2ペアのセルを結合すると、結果として得られるテーブルは番号が付けられます。このC++コードはそのプロセスを示しています：

```c++
const String outPath = u"../out/MergeCells_out.pptx";

// 必要なプレゼンテーションを読み込む
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 最初のスライドにアクセス
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// 幅のある列と高さのある行を定義
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// スライドにテーブル形状を追加
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// 各セルの罫線フォーマットを設定
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
// セル (1, 1) x (2, 1) を結合
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// セル (1, 2) x (2, 2) を結合
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// PPTXファイルをディスクに保存
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

その後、セル (1, 1) と (1, 2) をさらに結合します。結果は、中央に大きな結合セルを持つテーブルです：

```c++
// ドキュメントディレクトリのパス
const String outPath = u"../out/MergeCells_out.pptx";

// 必要なプレゼンテーションを読み込む
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 最初のスライドにアクセス
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// 幅のある列と高さのある行を定義
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// スライドにテーブル形状を追加
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// 各セルの罫線フォーマットを設定
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

// セル (1, 1) x (2, 1) を結合
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// セル (1, 2) x (2, 2) を結合
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// PPTXファイルをディスクに保存
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **分割セルの番号付け**
前の例では、テーブルセルが結合されたとき、他のセルの番号付けやナンバリングシステムは変更されませんでした。 

今回は、通常のテーブル（結合セルのないテーブル）を取り、セル (1, 1) を分割して特別なテーブルを作成します。このテーブルの番号付けには注意が必要で、奇妙に見えるかもしれませんが、それがMicrosoft PowerPointによるテーブルセルの番号付け方法であり、Aspose.Slidesも同様です。 

このC++コードは、先に述べたプロセスを示しています：

```c++
// ドキュメントディレクトリのパス
const String outPath = u"../out/CellSplit_out.pptx";

// 必要なプレゼンテーションを読み込む
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 最初のスライドにアクセス
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// 幅のある列と高さのある行を定義
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// スライドにテーブル形状を追加
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// 各セルの罫線フォーマットを設定
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

// セル (1, 1) を分割
table->idx_get(1, 1)->SplitByWidth(table->idx_get(2, 1)->get_Width() / 2);

// PPTXファイルをディスクに保存
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **テーブルセルの背景色を変更**

このC++コードは、テーブルセルの背景色を変更する方法を示しています：

``` cpp

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
        
auto dblCols = System::MakeArray<double>({150, 150, 150, 150});
auto dblRows = System::MakeArray<double>({50, 50, 50, 50, 50});
        
// 新しいテーブルを作成
auto table = slide->get_Shapes()->AddTable(50.0f, 50.0f, dblCols, dblRows);
        
// セルの背景色を設定 
System::SharedPtr<ICell> cell = table->idx_get(2, 3);
cell->get_CellFormat()->get_FillFormat()->set_FillType(Aspose::Slides::FillType::Solid);
cell->get_CellFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        
presentation->Save(u"cell_background_color.pptx", Aspose::Slides::Export::SaveFormat::Pptx);

```

## **テーブルセル内に画像を追加**
1. `Presentation`クラスのインスタンスを作成します。
2. インデックスを介してスライドの参照を取得します。
3. 幅のある列の配列を定義します。
4. 高さのある行の配列を定義します。
5. `AddTable`メソッドを通じてスライドにテーブルを追加します。 
6. 画像ファイルを保持するために`Bitmap`オブジェクトを作成します。
7. ビットマップ画像を`IPPImage`オブジェクトに追加します。
8. テーブルセルの`FillFormat`を`Picture`に設定します。
9. 画像をテーブルの最初のセルに追加します。
10. 修正したプレゼンテーションをPPTXファイルとして保存します。

このC++コードは、テーブルを作成するときにテーブルセル内に画像を配置する方法を示しています：

```c++
// ドキュメントディレクトリのパス
const String outPath = u"../out/Image_In_TableCell_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";

// 必要なプレゼンテーションを読み込む
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 最初のスライドにアクセス
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// 幅のある列と高さのある行を定義
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 150);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 100);
System::ArrayPtr<double> total_for_Cat = System::MakeObject<System::Array<double>>(5, 0);

// スライドにテーブル形状を追加
auto tbl = islide->get_Shapes()->AddTable(50, 50, dblCols, dblRows);

// 画像を取得
auto img = Images::FromFile(ImagePath);

// プレゼンテーションの画像コレクションに画像を追加
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(img);


// 最初のテーブルセルに画像を追加
tbl->idx_get(0, 0)->get_FillFormat()->set_FillType(FillType::Picture);
tbl->idx_get(0, 0)->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
tbl->idx_get(0, 0)->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(imgx);

// PPTXファイルをディスクに保存
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```