---
title: C++ を使用してプレゼンテーションのテーブルセルを管理する
linktitle: セルを管理する
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
description: "Aspose.Slides for C++ を使用して、PowerPoint のテーブルセルを手間なく管理できます。セルへのアクセス、変更、スタイリングを迅速に習得し、スムーズなスライド自動化を実現します。"
---

## **結合されたセルを識別する**
1. Presentation クラスのインスタンスを作成します。
2. 最初のスライドからテーブルを取得します。
3. テーブルの行と列を走査して結合セルを探します。
4. 結合セルが見つかったときにメッセージを出力します。

この C++ コードは、プレゼンテーション内で結合されたテーブルセルを識別する方法を示しています：
``` cpp
auto pres = System::MakeObject<Presentation>(u"SomePresentationWithTable.pptx");
auto table = System::AsCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

// Slide#0.Shape#0 がテーブルであると仮定しています
for (int32_t i = 0; i < table->get_Rows()->get_Count(); i++)
{
    for (int32_t j = 0; j < table->get_Columns()->get_Count(); j++)
    {
        auto currentCell = table->get_Rows()->idx_get(i)->idx_get(j);
        if (currentCell->get_IsMergedCell())
        {
            Console::WriteLine(String::Format(u"Cell {0};{1} is a part of merged cell with RowSpan={2} and ColSpan={3} starting from Cell {4};{5}.", 
                i, j, currentCell->get_RowSpan(), currentCell->get_ColSpan(), currentCell->get_FirstRowIndex(), currentCell->get_FirstColumnIndex()));
        }
    }
}
```


## **テーブルセルの境界線を削除する**
1. Presentation クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. 幅を指定した列の配列を定義します。
4. 高さを指定した行の配列を定義します。
5. `AddTable` メソッドでスライドにテーブルを追加します。
6. 各セルを走査し、上・下・右・左の境界線をクリアします。
7. 変更したプレゼンテーションを PPTX ファイルとして保存します。

この C++ コードは、テーブルセルの境界線を削除する方法を示しています：
``` cpp
// PPTX ファイルを表す Presentation クラスのインスタンスを作成
auto pres = MakeObject<Presentation>();
// 最初のスライドにアクセス
auto sld = pres->get_Slides()->idx_get(0);

// 列の幅と行の高さを定義
auto dblCols = MakeArray<double>({ 50, 50, 50, 50 });
auto dblRows = MakeArray<double>({ 50, 30, 30, 30, 30 });

// スライドにテーブルシェイプを追加
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// 各セルの罫線形式を設定
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

// PPTX ファイルをディスクに保存
pres->Save(u"table_out.pptx", SaveFormat::Pptx);
```


## **結合セル内の番号付け**
2 つのセルペア (1,1)×(2,1) と (1,2)×(2,2) を結合すると、結果のテーブルは番号が振られます。この C# コードはそのプロセスをデモします：
```c++
const String outPath = u"../out/MergeCells_out.pptx";

// 目的のプレゼンテーションをロードします
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 最初のスライドにアクセスします
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// 列の幅と行の高さを定義します
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// スライドにテーブルシェイプを追加します
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// 各セルの罫線形式を設定します
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
// セル (1, 1) と (2, 1) を結合します
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// セル (1, 2) と (2, 2) を結合します
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);

// PPTX ファイルをディスクに保存します
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


その後、セル (1,1) と (1,2) をさらに結合します。結果は、中央に大きな結合セルを持つテーブルになります：
```c++
// ドキュメントディレクトリへのパスです。
const String outPath = u"../out/MergeCells_out.pptx";

// 目的のプレゼンテーションをロードします
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 最初のスライドにアクセスします
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// 列の幅と行の高さを定義します
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// スライドにテーブルシェイプを追加します
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// 各セルの罫線形式を設定します
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

// セル (1, 1) と (2, 1) を結合します
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// セル (1, 2) と (2, 2) を結合します
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// PPTX ファイルをディスクに保存します
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **分割セル内の番号付け**
前の例では、テーブルセルが結合されても他のセルの番号付けは変わりませんでした。

今回は、結合セルのない通常のテーブルを使用し、セル (1,1) を分割して特別なテーブルを作成します。このテーブルの番号付けは奇妙に見えるかもしれませんが、Microsoft PowerPoint と Aspose.Slides の両方が同じ方法で番号付けを行います。

この C++ コードは、上記の手順を実演します：
```c++
// ドキュメントディレクトリへのパスです。
const String outPath = u"../out/CellSplit_out.pptx";

// 目的のプレゼンテーションをロードします
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 最初のスライドにアクセスします
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// 列の幅と行の高さを定義します
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// スライドにテーブルシェイプを追加します
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// 各セルの罫線形式を設定します
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

// セル (1, 1) と (2, 1) を結合します
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// セル (1, 2) と (2, 2) を結合します
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);

// セル (1, 1) を分割します。 
table->idx_get(1, 1)->SplitByWidth(table->idx_get(2, 1)->get_Width() / 2);

// PPTX ファイルをディスクに保存します
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```



## **テーブルセルの背景色を変更する**

この C++ コードは、テーブルセルの背景色を変更する方法を示しています：
``` cpp

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
        
auto dblCols = System::MakeArray<double>({150, 150, 150, 150});
auto dblRows = System::MakeArray<double>({50, 50, 50, 50, 50});
        
// 新しいテーブルを作成する
auto table = slide->get_Shapes()->AddTable(50.0f, 50.0f, dblCols, dblRows);
        
// セルの背景色を設定する
System::SharedPtr<ICell> cell = table->idx_get(2, 3);
cell->get_CellFormat()->get_FillFormat()->set_FillType(Aspose::Slides::FillType::Solid);
cell->get_CellFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        
presentation->Save(u"cell_background_color.pptx", Aspose::Slides::Export::SaveFormat::Pptx);

```


## **テーブルセル内に画像を追加する**
1. `Presentation` クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. 幅を指定した列の配列を定義します。
4. 高さを指定した行の配列を定義します。
5. `AddTable` メソッドでスライドにテーブルを追加します。
6. 画像ファイルを保持するために `Bitmap` オブジェクトを作成します。
7. ビットマップ画像を `IPPImage` オブジェクトに追加します。
8. テーブルセルの `FillFormat` を `Picture` に設定します。
9. 画像をテーブルの最初のセルに追加します。
10. 変更したプレゼンテーションを PPTX ファイルとして保存します。

この C# コードは、テーブル作成時にセル内に画像を配置する方法を示しています：
```c++
// ドキュメントディレクトリへのパスです。
const String outPath = u"../out/Image_In_TableCell_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";

// 目的のプレゼンテーションをロードします
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 最初のスライドにアクセスします
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// 列の幅と行の高さを定義します
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 150);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 100);
System::ArrayPtr<double> total_for_Cat = System::MakeObject<System::Array<double>>(5, 0);

// スライドにテーブルシェイプを追加します
auto tbl = islide->get_Shapes()->AddTable(50, 50, dblCols, dblRows);

// 画像を取得します
auto img = Images::FromFile(ImagePath);

// プレゼンテーションの画像コレクションに画像を追加します
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(img);

// 画像を最初のテーブルセルに追加します
tbl->idx_get(0, 0)->get_FillFormat()->set_FillType(FillType::Picture);
tbl->idx_get(0, 0)->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
tbl->idx_get(0, 0)->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(imgx);

// PPTX ファイルをディスクに保存します
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **FAQ**

**単一セルの各側面に異なる線の太さやスタイルを設定できますか？**

はい。上([top](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_bordertop/)) / 下([bottom](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderbottom/)) / 左([left](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderleft/)) / 右([right](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderright/)) の境界線はそれぞれ個別のプロパティを持ち、各側面の太さとスタイルを別々に設定できます。この記事で示したセル単位の側面別境界線制御に基づくものです。

**画像をセルの背景として設定した後に列・行のサイズを変更すると画像はどうなりますか？**

動作は [fill mode](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/)（stretch/​tile）に依存します。ストレッチの場合、画像は新しいセルサイズに合わせて調整されます。タイルの場合、タイルが再計算されます。この記事ではセル内の画像表示モードについて説明しています。

**セル内のすべてのコンテンツにハイパーリンクを割り当てられますか？**

[Hyperlinks](/slides/ja/cpp/manage-hyperlinks/) はセルのテキストフレーム内のテキスト（portion）レベル、またはテーブル全体/シェイプレベルで設定できます。実務上は、portion にリンクを設定するか、セル内のすべてのテキストに対してリンクを設定します。

**単一セル内でフォントを複数設定できますか？**

はい。セルのテキストフレームは [portions](https://reference.aspose.com/slides/cpp/aspose.slides/portion/)（ラン）をサポートしており、フォント ファミリ、スタイル、サイズ、色などを個別にフォーマットできます。