---
title: 使用 C++ 管理簡報中的表格儲存格
linktitle: 管理儲存格
type: docs
weight: 30
url: /zh-hant/cpp/manage-cells/
keywords:
- 表格儲存格
- 合併儲存格
- 移除邊框
- 拆分儲存格
- 儲存格內圖像
- 背景顏色
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 輕鬆管理 PowerPoint 中的表格儲存格。快速掌握存取、修改與樣式設定，實現無縫的投影片自動化。"
---
## **概觀**

Aspose.Slides 讓您能在 PowerPoint 簡報中存取和修改表格儲存格。本文章說明如何識別合併的表格儲存格、移除儲存格邊框、在合併或拆分儲存格後處理儲存格編號、變更儲存格的背景色，以及在表格儲存格內加入圖像。範例展示了如何建立或開啟簡報、從投影片取得表格、透過儲存格屬性更新儲存格格式，並將修改後的簡報儲存為 PPTX 檔案。

## **識別合併儲存格**

1. 建立[Presentation](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation)類別的實例。
2. 從第一張投影片取得表格。
3. 遍歷表格的行與列以尋找合併的儲存格。
4. 當發現合併的儲存格時列印訊息。

以下 C++ 程式碼示範如何在簡報中識別合併的表格儲存格：

``` cpp
auto pres = System::MakeObject<Presentation>(u"SomePresentationWithTable.pptx");
auto table = System::AsCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

// 假設 Slide#0.Shape#0 為表格
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

## **移除表格儲存格邊框**

1. 建立[Presentation](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation)類別的實例。
2. 透過索引取得投影片的參照。
3. 定義寬度的欄位陣列。
4. 定義高度的列陣列。
5. 使用 `AddTable` 方法將表格新增至投影片。
6. 遍歷每個儲存格以清除上、下、左、右邊框。
7. 將修改後的簡報儲存為 PPTX 檔案。

以下 C++ 程式碼示範如何移除表格儲存格的邊框：

``` cpp
// 實例化代表 PPTX 檔案的 Presentation 類別
auto pres = MakeObject<Presentation>();
// 存取第一張投影片
auto sld = pres->get_Slides()->idx_get(0);

// 定義具有寬度的欄位與具有高度的列
auto dblCols = MakeArray<double>({ 50, 50, 50, 50 });
auto dblRows = MakeArray<double>({ 50, 30, 30, 30, 30 });

// 將表格形狀新增至投影片
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// 為每個儲存格設定邊框格式
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

// 將 PPTX 檔案寫入磁碟
pres->Save(u"table_out.pptx", SaveFormat::Pptx);
```

## **合併儲存格的編號**

如果我們合併兩對儲存格 (1, 1) x (2, 1) 和 (1, 2) x (2, 2)，則產生的表格會編號。以下 C# 程式碼示範此過程：

```c++
const String outPath = u"../out/MergeCells_out.pptx";

// 載入所需的簡報
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 取得第一張投影片
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// 定義欄寬與列高
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// 在投影片上新增表格形狀
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// 為每個儲存格設定邊框格式
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
// 合併儲存格 (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// 合併儲存格 (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// 將 PPTX 檔案儲存至磁碟
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

接著我們再將 (1, 1) 與 (1, 2) 合併。結果是表格中心出現一個大型合併儲存格：

```c++
// 文件目錄的路徑。
const String outPath = u"../out/MergeCells_out.pptx";

// 載入所需的簡報
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 取得第一張投影片
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// 定義欄寬與列高
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// 在投影片上新增表格形狀
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// 為每個儲存格設定邊框格式
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

// 合併儲存格 (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// 合併儲存格 (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// 將 PPTX 檔案儲存至磁碟
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **拆分儲存格的編號**

在先前的範例中，當表格儲存格被合併時，其他儲存格的編號系統不會變更。這次，我們使用一個普通表格（未合併儲存格的表格），然後嘗試拆分儲存格 (1,1) 以得到特殊的表格。您可能會注意到此表格的編號看起來有些奇怪。然而，這正是 Microsoft PowerPoint 為表格儲存格編號的方式，Aspose.Slides 亦同樣如此。

以下 C++ 程式碼示範上述過程：

```c++
// 文件目錄的路徑。
const String outPath = u"../out/CellSplit_out.pptx";

// 載入所需的簡報
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 取得第一張投影片
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// 定義欄寬與列高
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// 在投影片上新增表格形狀
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// 為每個儲存格設定邊框格式
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

// 合併儲存格 (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// 合併儲存格 (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);

// 拆分儲存格 (1, 1)。
table->idx_get(1, 1)->SplitByWidth(table->idx_get(2, 1)->get_Width() / 2);

// 將 PPTX 檔案儲存至磁碟
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **變更表格儲存格背景色**

以下 C++ 程式碼示範如何變更表格儲存格的背景色：

``` cpp

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
        
auto dblCols = System::MakeArray<double>({150, 150, 150, 150});
auto dblRows = System::MakeArray<double>({50, 50, 50, 50, 50});
        
        // 建立新表格
auto table = slide->get_Shapes()->AddTable(50.0f, 50.0f, dblCols, dblRows);
        
        // 設定儲存格的背景顏色 
System::SharedPtr<ICell> cell = table->idx_get(2, 3);
cell->get_CellFormat()->get_FillFormat()->set_FillType(Aspose::Slides::FillType::Solid);
cell->get_CellFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        
presentation->Save(u"cell_background_color.pptx", Aspose::Slides::Export::SaveFormat::Pptx);

```

## **在表格儲存格內加入圖像**

1. 建立 `Presentation` 類別的實例。
2. 透過索引取得投影片的參照。
3. 定義寬度的欄位陣列。
4. 定義高度的列陣列。
5. 使用 `AddTable` 方法將表格新增至投影片。
6. 建立 `Bitmap` 物件以保存圖像檔案。
7. 將 bitmap 圖像加入 `IPPImage` 物件。
8. 將表格儲存格的 `FillFormat` 設為 `Picture`。
9. 將圖像加入表格的第一個儲存格。
10. 將修改後的簡報儲存為 PPTX 檔案

以下 C# 程式碼示範在建立表格時如何將圖像放入表格儲存格內：

```c++
// 文件目錄的路徑。
const String outPath = u"../out/Image_In_TableCell_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";

// 載入所需的簡報
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 取得第一張投影片
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// 定義欄寬與列高
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 150);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 100);
System::ArrayPtr<double> total_for_Cat = System::MakeObject<System::Array<double>>(5, 0);

// 在投影片上新增表格形狀
auto tbl = islide->get_Shapes()->AddTable(50, 50, dblCols, dblRows);

// 取得圖片
auto img = Images::FromFile(ImagePath);

// 將圖像加入簡報的影像集合
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(img);


// 將圖像加入第一個表格儲存格
tbl->idx_get(0, 0)->get_FillFormat()->set_FillType(FillType::Picture);
tbl->idx_get(0, 0)->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
tbl->idx_get(0, 0)->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(imgx);

// 將 PPTX 檔案儲存至磁碟
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **常見問題**

**我可以為單一儲存格的不同邊設定不同的線條粗細與樣式嗎？**

是的。[top](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/cellformat/get_bordertop/)/[bottom](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/cellformat/get_borderbottom/)/[left](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/cellformat/get_borderleft/)/[right](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/cellformat/get_borderright/) 邊框都有各自的屬性，因此每一側的粗細與樣式可以不同。此說法與本文示範的儲存格邊框按側別控制相符。

**如果在將圖片設為儲存格背景後，變更欄/列尺寸，圖像會發生什麼變化？**

行為取決於[fill mode](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/picturefillmode/)。若使用 stretch（拉伸），圖像會依新儲存格調整大小；若使用 tile（平鋪），平鋪圖塊會重新計算。本文已說明儲存格內圖像的顯示模式。

**我可以為儲存格內的全部內容設定超連結嗎？**

[Hyperlinks](/slides/zh-hant/cpp/manage-hyperlinks/) 會在儲存格文字框的文字（段落）層級或整個表格/圖形層級設定。實務上，您可以將連結指派給文字的某個段落或整個儲存格的文字。

**我可以在單一儲存格內設定不同字體嗎？**

是的。儲存格的文字框支援[portions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/portion/)（即文字執行序）可獨立設定格式──字型、樣式、大小與顏色。