---
title: "在 PHP 中自動化 PowerPoint 產生：輕鬆建立動態簡報"
linktitle: 在 PHP 中自動化 PowerPoint 產生
type: docs
weight: 20
url: /zh-hant/php-java/automating-powerpoint-generation-on-cloud-platforms/
keywords:
- 雲端平台
- 雲端整合
- 自動化 PowerPoint 產生
- 程式化產生簡報
- PowerPoint 自動化
- 動態投影片製作
- 自動化業務報告
- PPT 自動化
- PHP 簡報
- PHP
- Aspose.Slides
description: "在雲端平台使用 Aspose.Slides for PHP 自動化投影片建立——快速且可靠地產生、編輯與轉換 PowerPoint 與 OpenDocument 檔案。"
---
## **簡介**

手動建立 PowerPoint 簡報可能是一項耗時且重覆的工作——尤其是當內容基於經常變動的動態資料時。無論是產生每週業務報告、組合教學教材，或製作可直接交付客戶的銷售簡報，自動化都能節省無數小時，並確保團隊之間的一致性。

對於 PHP 開發人員而言，自動化建立 PowerPoint 簡報開啟了強大的可能性。您可以將投影片生成整合到 Web 入口網站、桌面工具、後端服務或雲端平台，動態地將資料轉換為專業且具品牌的簡報——隨時隨地。

在本篇文章中，我們將探討 PHP 應用程式（含雲端平台部署）自動化產生 PowerPoint 的常見使用情境，以及為何它正成為現代解決方案的關鍵功能。從抓取即時業務資料到將文字或圖像轉換為投影片，目標是將原始內容轉化為結構化、視覺化的格式，讓觀眾能立即理解。

## **在 PHP 中 PowerPoint 自動化的常見使用情境**

自動化產生 PowerPoint 特別適用於需要動態組合、個人化或頻繁更新簡報內容的情境。以下是最常見的實務使用案例：

- **Business Reports & Dashboards**
  透過從資料庫或 API 抓取即時資料，產生銷售摘要、KPI 或財務績效報告。

- **Personalized Sales & Marketing Decks**
  自動使用 CRM 或表單資料建立針對客戶的簡報，提高交付速度並確保品牌一致性。

- **Educational Content**
  將學習教材、測驗或課程摘要轉換為結構化的投影片，以供 e‑learning 平台使用。

- **Data & AI-Powered Insights**
  利用自然語言處理或分析引擎，將原始資料或長篇文字轉換為摘要簡報。

- **Media-Based Slides**
  從上傳的圖片、註解螢幕擷圖，或影片關鍵畫格結合說明文字組合簡報。

- **Document Conversion**
  自動將 Word 文件、PDF 或表單輸入轉換為視覺化簡報，減少手動操作。

- **Developer and Technical Tools**
  直接從程式碼或 markdown 內容產生技術示範、文件概覽或變更日誌投影片。

透過自動化這些工作流程，組織能擴大內容產出規模、維持一致性，並釋放時間投入更具策略性的工作。

## **讓我們編寫程式**

在本範例中，我們選擇 **[Aspose.Slides for PHP](https://products.aspose.com/slides/zh-hant/php-java/)** 來示範 PowerPoint 自動化，因為它具備完整功能且在以程式方式處理簡報時使用簡便。  
與較低階的函式庫不同，後者需要開發人員直接操作 Open XML 結構（往往導致程式碼冗長且難以閱讀），Aspose.Slides 提供了更高層次的 API。它抽象化了複雜性，讓開發者能專注於簡報邏輯——如版面配置、格式設定與資料繫結——而無需深入了解 PowerPoint 檔案格式。  
雖然 Aspose.Slides 是商業函式庫，但它提供可完整執行本文範例的 [免費試用](https://releases.aspose.com/slides/zh-hant/php-java/) 版。為了展示概念、測試功能或建構概念驗證，只要使用試用版即可，足以滿足需求。這使得開發者能在未先行購買授權的情況下，方便地嘗試自動化 PowerPoint 產生。  

好，讓我們一步步建立一個使用真實內容的範例簡報。

### **建立標題投影片**

我們將先建立新的簡報，並加入包含主標題與副標題的標題投影片。

```php
$presentation = new Presentation();

$slide0 = $presentation->getSlides()->get_Item(0);

$layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Title);
$slide0->setLayoutSlide($layoutSlide);

$titleShape = $slide0->getShapes()->get_Item(0);
$subtitleShape = $slide0->getShapes()->get_Item(1);

$titleShape->getTextFrame()->setText("Quarterly Business Review – Q1 2025");
$subtitleShape->getTextFrame()->setText("Prepared for Executive Team");
```

![標題投影片](slide_0.png)

### **加入含柱狀圖的投影片**

接著，我們將建立一張以柱狀圖顯示區域銷售績效的投影片。

```php
$layoutSlide1 = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
$slide1 = $presentation->getSlides()->addEmptySlide($layoutSlide1);

$chart = $slide1->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 350, false);
$chart->getLegend()->setPosition(LegendPositionType::Bottom);
$chart->setTitle(true);
$chart->getChartTitle()->addTextFrameForOverriding("Data from January – March 2025");
$chart->getChartTitle()->setOverlay(false);

$workbook = $chart->getChartData()->getChartDataWorkbook();
$worksheetIndex = 0;

$chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 1, 0, "North America"));
$chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 2, 0, "Europe"));
$chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 3, 0, "Asia Pacific"));
$chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 4, 0, "Latin America"));
$chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 5, 0, "Middle East"));

$series = $chart->getChartData()->getSeries()->add($workbook->getCell($worksheetIndex, 0, 1, "Sales (\$K)"), $chart->getType());
$series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 1, 1, 480));
$series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 2, 1, 365));
$series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 3, 1, 290));
$series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 4, 1, 150));
$series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 5, 1, 120));
```

![含圖表的投影片](slide_1.png)

### **加入含表格的投影片**

現在，我們將加入一張以表格形式呈現關鍵績效指標的投影片。

```php
$layoutSlide2 = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
$slide2 = $presentation->getSlides()->addEmptySlide($layoutSlide2);

$columnWidths = [200, 100];
$rowHeights = [40, 40, 40, 40, 40];

$table = $slide2->getShapes()->addTable(200, 200, $columnWidths, $rowHeights);
$table->getColumns()->get_Item(0)->get_Item(0)->getTextFrame()->setText("Metric");
$table->getColumns()->get_Item(1)->get_Item(0)->getTextFrame()->setText("Value");
$table->getColumns()->get_Item(0)->get_Item(1)->getTextFrame()->setText("Total Revenue");
$table->getColumns()->get_Item(1)->get_Item(1)->getTextFrame()->setText("\$1.4M");
$table->getColumns()->get_Item(0)->get_Item(2)->getTextFrame()->setText("Gross Margin");
$table->getColumns()->get_Item(1)->get_Item(2)->getTextFrame()->setText("54%");
$table->getColumns()->get_Item(0)->get_Item(3)->setText("New Customers");
$table->getColumns()->get_Item(1)->get_Item(3)->setText("340");
$table->getColumns()->get_Item(0)->get_Item(4)->setText("Customer Retention");
$table->getColumns()->get_Item(1)->get_Item(4)->setText("87%");
```

![含表格的投影片](slide_2.png)

### **加入含項目符號的摘要投影片**

最後，我們將使用簡單的項目符號清單加入摘要與行動計畫。

```php
function createBulletParagraph($text) {
    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $paragraph->getParagraphFormat()->setIndent(15);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $paragraph->setText($text);
    return $paragraph;
}
```
```php
$layoutSlide3 = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
$slide3 = $presentation->getSlides()->addEmptySlide($layoutSlide3);

$bulletList = $slide3->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 50, 600, 200);
$bulletList->getFillFormat()->setFillType(FillType::NoFill);
$bulletList->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

$bulletList->getTextFrame()->getParagraphs()->clear();
$bulletList->getTextFrame()->getParagraphs()->add(createBulletParagraph("Strong performance in North America; growth opportunity in Asia Pacific"));
$bulletList->getTextFrame()->getParagraphs()->add(createBulletParagraph("Improve marketing outreach in underperforming regions"));
$bulletList->getTextFrame()->getParagraphs()->add(createBulletParagraph("Prepare new campaign strategy for Q2"));
$bulletList->getTextFrame()->getParagraphs()->add(createBulletParagraph("Schedule follow-up review in early July"));
```

![含文字的投影片](slide_3.png)

### **儲存簡報**

最後，我們將簡報儲存至磁碟：

```php
$presentation->save("presentation.pptx", SaveFormat::Pptx);
```

## **結論**

在 PHP 應用程式中自動化產生 PowerPoint 能顯著節省時間並減少手動工作。透過整合圖表、表格與文字等動態內容，開發者能快速產出一致且專業的簡報，適用於業務報告、客戶會議或教學內容。  
本文示範了如何從零自動建立簡報，包括加入標題投影片、圖表與表格。此方法可應用於各種需要自動化、資料驅動簡報的情境。  
藉由運用合適的工具，PHP 開發者能有效自動化 PowerPoint 的產生，提升生產力並確保簡報的一致性。