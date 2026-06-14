---
title: "在 C++ 中自動化 PowerPoint 產生：輕鬆建立動態簡報"
linktitle: 在 C++ 中自動化 PowerPoint 產生
type: docs
weight: 20
url: /zh-hant/cpp/automating-powerpoint-generation-on-cloud-platforms/
keywords:
- 雲端平台
- 自動化 PowerPoint 產生
- 程式化產生簡報
- PowerPoint 自動化
- 動態投影片建立
- 自動化商業報告
- PPT 自動化
- C++ 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 在雲端平台上自動建立投影片——快速且可靠地產生、編輯與轉換 PowerPoint 與 OpenDocument 檔案。"
---
## **簡介**

手動建立 PowerPoint 簡報可能既耗時又重複，尤其是內容基於經常變動的動態資料時。無論是產生每週商業報告、組合教學素材，或是製作客戶可直接使用的銷售簡報，透過自動化都能節省大量時間，同時確保團隊間的一致性。

對於 C++ 開發人員而言，自動化建立 PowerPoint 簡報可開啟強大的可能性。您可以將投影片產生整合至 web 入口、桌面工具、後端服務或雲端平台，動態地把資料轉換成專業且具品牌識別的簡報，隨時按需產出。

在本篇文章中，我們將探討在 C++ 應用程式（包含雲端部署）中自動產生 PowerPoint 的常見使用情境，以及它為何成為現代解決方案的關鍵功能。從即時擷取商業資料到將文字或圖像轉換為投影片，目標是將原始內容轉化為結構化、視覺化的格式，讓觀眾即時了解。

## **在 C++ 中使用 PowerPoint 自動化的常見案例**

在需要動態組合、個人化或頻繁更新簡報內容的情境中，自動化 PowerPoint 產生尤為有用。以下是最常見的實務案例：

- **商業報告與儀表板**  
  透過從資料庫或 API 取得即時資料，產生銷售摘要、關鍵績效指標或財務績效報告。

- **客製化銷售與行銷簡報**  
  使用 CRM 或表單資料自動建立針對客戶的提案簡報，確保快速交付與品牌一致性。

- **教育內容**  
  將學習教材、測驗或課程摘要轉換為結構化投影片，供 e‑learning 平台使用。

- **資料與 AI 驅動的洞察**  
  利用自然語言處理或分析引擎，將原始資料或長篇文字轉換為摘要簡報。

- **媒體型投影片**  
  結合上傳的圖像、標註的螢幕截圖或影片關鍵畫面，並加上說明文字組成投影片。

- **文件轉換**  
  自動把 Word 文件、PDF 或表單輸入轉換為視覺化簡報，減少手動工作。

- **開發者與技術工具**  
  直接從程式碼或 markdown 內容產生技術示範、文件概覽或變更紀錄投影片。

透過自動化這些工作流程，組織能夠擴大內容產出規模、維持一致性，並將時間釋放給更具策略性的任務。

## **讓我們寫程式**

在本示範中，我們選擇 **[Aspose.Slides for C++](https://products.aspose.com/slides/zh-hant/cpp/)** 來展示 PowerPoint 自動化，因為它功能完整且使用簡便，適合以程式方式操作簡報。

相較於需要直接操作 Open XML 結構（往往導致程式碼冗長且難以閱讀）的低階函式庫，Aspose.Slides 提供較高層的 API，抽象掉底層複雜度，讓開發人員只需關注簡報邏輯—例如版面配置、格式設定與資料繫結—而不必深入了解 PowerPoint 檔案格式的細節。

雖然 Aspose.Slides 為商業函式庫，但它提供了 **[免費試用](https://releases.aspose.com/slides/zh-hant/cpp/)** 版本，足以執行本文中的所有範例。對於展示概念、測試功能或建立概念驗證（Proof‑of‑Concept），此試用版已相當充分，讓您無需先行購買授權即可嘗試自動化 PowerPoint 產生。

好，現在讓我們一步步建立一個實務內容的範例簡報。

### **建立標題投影片**

我們先建立新簡報，並新增一張包含主標題與副標題的標題投影片。

```cpp
auto presentation = MakeObject<Presentation>();

auto slide0 = presentation->get_Slide(0);

auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Title);
slide0->set_LayoutSlide(layoutSlide);

auto titleShape = ExplicitCast<IAutoShape>(slide0->get_Shape(0));
auto subtitleShape = ExplicitCast<IAutoShape>(slide0->get_Shape(1));

titleShape->get_TextFrame()->set_Text(u"Quarterly Business Review – Q1 2025");
subtitleShape->get_TextFrame()->set_Text(u"Prepared for Executive Team");
```

![標題投影片](slide_0.png)

### **新增含柱狀圖的投影片**

接下來，我們建立一張以柱狀圖顯示各地區銷售績效的投影片。

```cpp
auto layoutSlide1 = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
auto slide1 = presentation->get_Slides()->AddEmptySlide(layoutSlide1);

auto chart = slide1->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100, 100, 500, 350, false);
chart->get_Legend()->set_Position(LegendPositionType::Bottom);
chart->set_HasTitle(true);
chart->get_ChartTitle()->AddTextFrameForOverriding(u"Data from January – March 2025");
chart->get_ChartTitle()->set_Overlay(false);

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheetIndex = 0;

chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 1, 0, ObjectExt::Box<String>(u"North America")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 2, 0, ObjectExt::Box<String>(u"Europe")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 3, 0, ObjectExt::Box<String>(u"Asia Pacific")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 4, 0, ObjectExt::Box<String>(u"Latin America")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 5, 0, ObjectExt::Box<String>(u"Middle East")));

auto series = chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 1, ObjectExt::Box<String>(u"Sales ($K)")), chart->get_Type());
series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 1, ObjectExt::Box<int32_t>(480)));
series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 1, ObjectExt::Box<int32_t>(365)));
series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 1, ObjectExt::Box<int32_t>(290)));
series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 4, 1, ObjectExt::Box<int32_t>(150)));
series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 5, 1, ObjectExt::Box<int32_t>(120)));
```

![包含圖表的投影片](slide_1.png)

### **新增含表格的投影片**

現在加入一張以表格方式呈現關鍵績效指標的投影片。

```cpp
auto layoutSlide2 = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
auto slide2 = presentation->get_Slides()->AddEmptySlide(layoutSlide2);

auto columnWidths = MakeArray<double>({ 200, 100 });
auto rowHeights = MakeArray<double>({ 40, 40, 40, 40, 40 });

auto table = slide2->get_Shapes()->AddTable(200, 200, columnWidths, rowHeights);
table->get_Column(0)->idx_get(0)->get_TextFrame()->set_Text(u"Metric");
table->get_Column(1)->idx_get(0)->get_TextFrame()->set_Text(u"Value");
table->get_Column(0)->idx_get(1)->get_TextFrame()->set_Text(u"Total Revenue");
table->get_Column(1)->idx_get(1)->get_TextFrame()->set_Text(u"$1.4M");
table->get_Column(0)->idx_get(2)->get_TextFrame()->set_Text(u"Gross Margin");
table->get_Column(1)->idx_get(2)->get_TextFrame()->set_Text(u"54%");
table->get_Column(0)->idx_get(3)->get_TextFrame()->set_Text(u"New Customers");
table->get_Column(1)->idx_get(3)->get_TextFrame()->set_Text(u"340");
table->get_Column(0)->idx_get(4)->get_TextFrame()->set_Text(u"Customer Retention");
table->get_Column(1)->idx_get(4)->get_TextFrame()->set_Text(u"87%");
```

![包含表格的投影片](slide_2.png)

### **新增含項目符號的總結投影片**

最後，我們加入一張以簡單項目符號列出總結與行動計畫的投影片。

```cpp
static SharedPtr<IParagraph> CreateBulletParagraph(String text) {
    auto paragraph = MakeObject<Paragraph>();
    paragraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
    paragraph->get_ParagraphFormat()->set_Indent(15);
    paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
    paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
    paragraph->set_Text(text);
    return paragraph;
}
```
```cpp
auto layoutSlide3 = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
auto slide3 = presentation->get_Slides()->AddEmptySlide(layoutSlide3);

auto bulletList = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 50, 600, 200);
bulletList->get_FillFormat()->set_FillType(FillType::NoFill);
bulletList->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

bulletList->get_TextFrame()->get_Paragraphs()->Clear();
bulletList->get_TextFrame()->get_Paragraphs()->Add(CreateBulletParagraph(u"Strong performance in North America; growth opportunity in Asia Pacific"));
bulletList->get_TextFrame()->get_Paragraphs()->Add(CreateBulletParagraph(u"Improve marketing outreach in underperforming regions"));
bulletList->get_TextFrame()->get_Paragraphs()->Add(CreateBulletParagraph(u"Prepare new campaign strategy for Q2"));
bulletList->get_TextFrame()->get_Paragraphs()->Add(CreateBulletParagraph(u"Schedule follow-up review in early July"));
```

![包含文字的投影片](slide_3.png)

### **儲存投影片**

最後，我們將簡報儲存至磁碟：

```java
presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
```

## **結論**

在 C++ 應用程式中自動化 PowerPoint 產生，可明顯節省時間並減少手動工作。透過整合圖表、表格與文字等動態內容，開發人員能快速產出一致且專業的簡報，適用於商業報告、客戶會議或教育教材等情境。

本文示範了如何從頭開始自動建立簡報，包括加入標題投影片、圖表與表格。此方法可廣泛套用於各種需要自動、資料驅動簡報的使用案例。

利用合適的工具，C++ 開發人員即可高效自動化 PowerPoint 建立，提升生產力並確保簡報的一致性。