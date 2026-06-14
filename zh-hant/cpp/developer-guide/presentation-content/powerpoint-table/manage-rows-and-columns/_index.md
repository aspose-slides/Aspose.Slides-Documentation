---
title: 使用 C++ 在 PowerPoint 表格中管理列與欄
linktitle: 列與欄
type: docs
weight: 20
url: /zh-hant/cpp/manage-rows-and-columns/
keywords:
- 表格列
- 表格欄
- 第一列
- 表格標題列
- 複製列
- 複製欄
- 拷貝列
- 拷貝欄
- 移除列
- 移除欄
- 列文字格式設定
- 欄文字格式設定
- 表格樣式
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 在 PowerPoint 中管理表格的列與欄，並加速簡報的編輯與資料更新。"
---
## **簡介**

為了讓您能在 PowerPoint 簡報中管理表格的列與欄，Aspose.Slides 提供了 [Table](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/table/) 類別、[ITable](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itable/) 介面，以及許多其他型別。 

## **設定第一列為標題列**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation) 類別的實例並載入簡報。 
2. 透過索引取得投影片的參考。 
3. 建立一個 [ITable](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itable/) 物件並將其設為 null。 
4. 遍歷所有 [IShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/) 物件以尋找相關的表格。 
5. 將表格的第一列設為標題列。 

以下 C++ 程式碼示範如何將表格的第一列設為標題列：

```c++
// 實例化 Presentation 類別 
auto pres = System::MakeObject<Presentation>(u"table.pptx");

// 存取第一張投影片
auto sld = pres->get_Slides()->idx_get(0);

// 初始化為 null 的 TableEx
SharedPtr<ITable> tbl;

// 遍歷形狀並設置表格的參考
for (const auto& shp : sld->get_Shapes())
{
    if (ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// 將表格的第一列設為標題列 
tbl->set_FirstRow(true);
```


## **複製表格列或欄**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation) 類別的實例並載入簡報， 
2. 透過索引取得投影片的參考。 
3. 定義 `columnWidth` 陣列。 
4. 定義 `rowHeight` 陣列。 
5. 透過 [AddTable()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishapecollection/addtable/) 方法將 [ITable](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itable/) 物件加入投影片。 
6. 複製表格列。 
7. 複製表格欄。 
8. 儲存已修改的簡報。 

以下 C++ 程式碼示範如何複製 PowerPoint 表格的列或欄：

```c++
 // 文件目錄的路徑。
const String outPath = u"../out/CloningInTable_out.pptx";

// 實例化 Presentation 類別
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 存取第一張投影片
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

table->idx_get(0, 0)->get_TextFrame()->set_Text(u"00");
table->idx_get(0, 1)->get_TextFrame()->set_Text(u"01");
table->idx_get(0, 2)->get_TextFrame()->set_Text(u"02");
table->idx_get(0, 3)->get_TextFrame()->set_Text(u"03");
table->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
table->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
table->idx_get(1, 1)->get_TextFrame()->set_Text(u"11");
table->idx_get(2, 1)->get_TextFrame()->set_Text(u"21");

// AddClone 在表格末尾新增一列
table->get_Rows()->AddClone(table->get_Rows()->idx_get(0), false);

// InsertClone 在表格的特定位置新增一列
table->get_Rows()->InsertClone(2, table->get_Rows()->idx_get(0), false);

// AddClone 在表格末尾新增一欄
table->get_Columns()->AddClone(table->get_Columns()->idx_get(0), false);

// InsertClone 在表格的特定位置新增一欄
table->get_Columns()->InsertClone(2, table->get_Columns()->idx_get(0), false);


// 將簡報儲存至磁碟
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **從表格中移除列或欄**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation) 類別的實例並載入簡報， 
2. 透過索引取得投影片的參考。 
3. 定義 `columnWidth` 陣列。 
4. 定義 `rowHeight` 陣列。 
5. 透過 [AddTable()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishapecollection/addtable/) 方法將 [ITable](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itable/) 物件加入投影片。 
6. 移除表格列。 
7. 移除表格欄。 
8. 儲存已修改的簡報。 

以下 C++ 程式碼示範如何從表格中移除列或欄：

```c++
// 文件目錄的路徑。
const String outPath = u"../out/RemovingRowColumn_out.pptx";

// 實例化 Presentation 類別
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 存取第一張投影片
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// 定義欄寬與列高
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// 在投影片上新增表格形狀
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);

table->get_Rows()->RemoveAt(1, false);
table->get_Columns()->RemoveAt(1, false);


// 合併儲存格 (1, 1) x (2, 1)
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// 合併儲存格 (1, 2) x (2, 2)
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// 將簡報儲存至磁碟
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **設定表格列層級的文字格式**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation) 類別的實例並載入簡報， 
2. 透過索引取得投影片的參考。 
3. 從投影片取得相關的 [ITable](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itable/) 物件。 
4. 設定第一列儲存格的 [set_FontHeight()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/baseportionformat/set_fontheight/)。 
5. 設定第一列儲存格的 [set_Alignment()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraphformat/set_alignment/) 以及 [set_MarginRight()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraphformat/set_marginright/)。 
6. 設定第二列儲存格的 [set_TextVerticalType()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/textframeformat/set_textverticaltype/)。 
7. 儲存已修改的簡報。 

以下 C++ 程式碼示範此操作。

```c++
// 建立 Presentation 類別的實例
auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slides()->idx_get(0);

auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
// 假設第一張投影片的第一個形狀是表格
// 設定第一列儲存格的字體高度
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->get_Rows()->idx_get(0)->SetTextFormat(portionFormat);

// 設定第一列儲存格的文字對齊方式與右邊距
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->get_Rows()->idx_get(0)->SetTextFormat(paragraphFormat);

// 設定第二列儲存格的文字垂直方向類型
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->get_Rows()->idx_get(1)->SetTextFormat(textFrameFormat);

// 將簡報儲存至磁碟
presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **設定表格欄層級的文字格式**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation) 類別的實例並載入簡報， 
2. 透過索引取得投影片的參考。 
3. 從投影片取得相關的 [ITable](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itable/) 物件。 
4. 設定第一欄儲存格的 [set_FontHeight()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/baseportionformat/set_fontheight/)。 
5. 設定第一欄儲存格的 [set_Alignment()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraphformat/set_alignment/) 以及 [set_MarginRight()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iparagraphformat/set_marginright/)。 
6. 設定第二欄儲存格的 [set_TextVerticalType()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/textframeformat/set_textverticaltype/)。 
7. 儲存已修改的簡報。 

以下 C++ 程式碼示範此操作： 

```c++
// 建立 Presentation 類別的實例
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);

auto someTable = System::AsCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
// 假設第一張投影片的第一個形狀是表格

// 設定第一欄儲存格的字體高度
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->get_Columns()->idx_get(0)->SetTextFormat(portionFormat);

// 一次呼叫設定第一欄儲存格的文字對齊方式與右邊距
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->get_Columns()->idx_get(0)->SetTextFormat(paragraphFormat);

// 設定第二欄儲存格的文字垂直類型
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->get_Columns()->idx_get(1)->SetTextFormat(textFrameFormat);

pres->Save(u"result.pptx", SaveFormat::Pptx);
```

## **取得表格樣式屬性**

Aspose.Slides 讓您取得表格的樣式屬性，以便將這些細節用於其他表格或其他位置。以下 C++ 程式碼示範如何從表格預設樣式取得樣式屬性：

```c++
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **常見問題**

**我可以將 PowerPoint 主題/樣式套用到已建立的表格嗎？**

可以。表格會繼承投影片/版面配置/母片的主題，您仍然可以在此基礎上覆寫填滿、邊框與文字顏色。

**我可以像在 Excel 中一樣對表格列進行排序嗎？**

不能，Aspose.Slides 的表格沒有內建的排序或篩選功能。請先在記憶體中排序資料，然後依排序結果重新填入表格列。

**我可以在保留特定儲存格自訂顏色的同時使用條紋欄嗎？**

可以。開啟條紋欄後，對特定儲存格套用本地格式，即可覆寫表格樣式；儲存格層級的格式會優先於表格樣式。