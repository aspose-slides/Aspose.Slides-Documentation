---
title: 在 C++ 中管理簡報表格
linktitle: 管理表格
type: docs
weight: 10
url: /zh-hant/cpp/manage-table/
keywords:
- 新增表格
- 建立表格
- 存取表格
- 長寬比
- 對齊文字
- 文字格式設定
- 表格樣式
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 在 PowerPoint 投影片中建立與編輯表格。探索簡單的程式範例，以簡化您的表格工作流程。"
---
## **簡介**

PowerPoint 中的表格是顯示和呈現資訊的有效方式。以行列排列的格子網格中的資訊簡潔明瞭，易於理解。

Aspose.Slides 提供 [Table](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/table/) 類別、[ITable](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itable/) 介面、[Cell](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/cell/) 類別、[ICell](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icell/) 介面，以及其他類型，讓您能在各種簡報中建立、更新和管理表格。

## **從頭建立表格**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。  
2. 透過索引取得投影片的參照。  
3. 定義 `columnWidth` 陣列。  
4. 定義 `rowHeight` 陣列。  
5. 使用 [AddTable()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishapecollection/addtable/) 方法將 [ITable](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itable/) 物件新增至投影片。  
6. 遍歷每個 [ICell](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icell/)，為其上、下、左、右邊框套用格式設定。  
7. 合併表格第一行的前兩個儲存格。  
8. 取得 [ICell](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icell/) 的 [TextFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/textframe/)。  
9. 在 [TextFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/textframe/) 中加入文字。  
10. 儲存已修改的簡報。

此 C++ 程式碼示範如何在簡報中建立表格：

```c++
// 實例化代表 PPTX 檔案的 Presentation 類別
auto pres = System::MakeObject<Presentation>();

// 取得第一張投影片
auto sld = pres->get_Slides()->idx_get(0);

// 定義欄寬與列高
auto dblCols = System::MakeArray<double>({ 50, 50, 50 });
auto dblRows = System::MakeArray<double>({ 50, 30, 30, 30, 30 });

// 在投影片上新增表格形狀
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// 為每個儲存格設定邊框格式
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
// 合併第 1 列的第 1 與第 2 個儲存格
tbl->MergeCells(tbl->get_Rows()->idx_get(0)->idx_get(0), tbl->get_Rows()->idx_get(1)->idx_get(1), false);

// 在合併的儲存格中加入文字
tbl->get_Rows()->idx_get(0)->idx_get(0)->get_TextFrame()->set_Text(u"Merged Cells");

// 將簡報儲存至磁碟
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **標準表格的編號方式**

在標準表格中，儲存格的編號方式簡單且以零為起點。表格的第一個儲存格索引為 0,0（第 0 欄，第 0 列）。

例如，具有 4 欄 4 列的表格，其儲存格編號如下：

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

此 C++ 程式碼示範如何為表格中的儲存格指定編號：

```c++
// 實例化代表 PPTX 檔案的 Presentation 類別
auto pres = System::MakeObject<Presentation>();

// 取得第一張投影片
auto sld = pres->get_Slides()->idx_get(0);

// 定義欄寬與列高
auto dblCols = System::MakeArray<double>({ 70, 70, 70, 70 });
auto dblRows = System::MakeArray<double>({ 70, 70, 70, 70 });

// 在投影片上加入表格形狀
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// 為每個儲存格設定邊框格式
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

// 將簡報儲存至磁碟
pres->Save(u"StandardTables_out.pptx", SaveFormat::Pptx);
```

## **存取現有表格**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。  
2. 透過索引取得包含表格之投影片的參照。  
3. 建立 [ITable](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itable/) 物件，並將其設為 null。  
4. 遍歷所有 [IShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/) 物件，直至找到表格。  
   如果您懷疑當前投影片只有一個表格，您只需檢查其所有形狀。當形狀被辨識為表格時，您可以將其型別轉換為 [Table](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/table/) 物件。但若投影片包含多個表格，則建議透過其 [set_AlternativeText()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/set_alternativetext/) 方法搜尋所需的表格。  
5. 使用 [ITable](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itable/) 物件操作表格。以下範例中，我們向表格新增了一列。  
6. 儲存已修改的簡報。

此 C++ 程式碼示範如何存取並操作現有表格：

```c++
// 實例化代表 PPTX 檔案的 Presentation 類別
auto pres = System::MakeObject<Presentation>(u"UpdateExistingTable.pptx");

// 取得第一張投影片
auto sld = pres->get_Slides()->idx_get(0);

// 初始化為 null 的 Table
System::SharedPtr<ITable> tbl;

// 遍歷形狀並設定找到的表格參考
for (const auto& shp : System::IterateOver(sld->get_Shapes()))
{
    if (System::ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// 設定第二列第一欄的文字
tbl->idx_get(0, 1)->get_TextFrame()->set_Text(u"New");

// 將已修改的簡報儲存至磁碟
pres->Save(u"table1_out.pptx", SaveFormat::Pptx);
```

## **對齊表格文字**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。  
2. 透過索引取得投影片的參照。  
3. 將 [ITable](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itable/) 物件新增至投影片。  
4. 從表格取得 [ITextFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/) 物件。  
5. 取得 [ITextFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/) 的 [IParagraph](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraph/)。  
6. 垂直對齊文字。  
7. 儲存已修改的簡報。

此 C++ 程式碼示範如何在表格中對齊文字：

```c++
// 建立 Presentation 類別的實例
auto presentation = System::MakeObject<Presentation>();

// 取得第一張投影片 
auto slide = presentation->get_Slides()->idx_get(0);

// 定義欄寬與列高
auto dblCols = System::MakeArray<double>({ 120, 120, 120, 120 });
auto dblRows = System::MakeArray<double>({ 100, 100, 100, 100 });

// 將表格形狀加入投影片
auto tbl = slide->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);
tbl->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
tbl->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
tbl->idx_get(3, 0)->get_TextFrame()->set_Text(u"30");

// 取得文字框架
auto txtFrame = tbl->idx_get(0, 0)->get_TextFrame();

// 為文字框建立 Paragraph 物件
auto paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// 為段落建立 Portion 物件
auto portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Text here");
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// 垂直對齊文字
auto cell = tbl->idx_get(0, 0);
cell->set_TextAnchorType(TextAnchorType::Center);
cell->set_TextVerticalType(TextVerticalType::Vertical270);

// 將簡報儲存至磁碟
presentation->Save(u"Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
```

## **在表格層級設定文字格式**

1. 建立 the [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。  
2. 透過索引取得投影片的參照。  
3. 從投影片取得 [ITable](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itable/) 物件。  
4. 設定文字的 [set_FontHeight()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/baseportionformat/set_fontheight/)。  
5. 設定 [set_Alignment()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraphformat/set_alignment/) 與 [set_MarginRight()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraphformat/set_marginright/)。  
6. 設定 [set_TextVerticalType()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/textframeformat/set_textverticaltype/)。  
7. 儲存已修改的簡報。

此 C++ 程式碼示範如何對表格文字套用首選格式選項：

```c++
// 建立 Presentation 類別的實例
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);

// 假設第一張投影片上的第一個形狀是一個表格
auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

// 設定表格儲存格的字體高度
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->SetTextFormat(portionFormat);

// 一次設定表格儲存格的文字對齊方式與右邊距
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->SetTextFormat(paragraphFormat);

// 設定表格儲存格的文字垂直類型
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->SetTextFormat(textFrameFormat);

presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **取得表格樣式屬性**

Aspose.Slides 允許您取得表格的樣式屬性，以便在其他表格或其他地方使用這些資訊。以下 C++ 程式碼示範如何從表格預設樣式取得樣式屬性：

```c++
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **鎖定表格的長寬比**

幾何形狀的長寬比是其各維度尺寸的比例。Aspose.Slides 提供 `AspectRatioLocked()` 屬性，讓您能為表格及其他形狀鎖定長寬比設定。

此 C++ 程式碼示範如何為表格鎖定長寬比：

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto table = System::ExplicitCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());


table->get_GraphicalObjectLock()->set_AspectRatioLocked(!table->get_GraphicalObjectLock()->get_AspectRatioLocked());

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**我可以為整個表格及其儲存格內的文字啟用從右至左 (RTL) 讀取方向嗎？**

是的。表格提供 [set_RightToLeft](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/table/set_righttoleft/) 方法，段落則有 [ParagraphFormat::set_RightToLeft](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/paragraphformat/set_righttoleft/)。兩者皆使用即可確保儲存格內的 RTL 順序與顯示正確。

**如何防止使用者在最終檔案中移動或調整表格大小？**

使用 [shape locks](/slides/zh-hant/cpp/applying-protection-to-presentation/) 以停用移動、調整大小、選取等功能。此鎖定同樣適用於表格。

**是否支援在儲存格內插入圖片作為背景？**

是的。您可以為儲存格設定 [picture fill](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/picturefillformat/)，圖片會依所選模式（拉伸或並排）覆蓋儲存格區域。