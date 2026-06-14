---
title: "在 .NET 中自動化 PowerPoint 產生：輕鬆建立動態簡報"
linktitle: 在 .NET 中自動化 PowerPoint 產生
type: docs
weight: 20
url: /zh-hant/net/automating-powerpoint-generation-on-cloud-platforms/
keywords:
- 雲端平台
- 雲端整合
- 自動化 PowerPoint 產生
- 程式化產生簡報
- PowerPoint 自動化
- 動態投影片建立
- 自動化商業報告
- PPT 自動化
- OpenDocument
- .NET 簡報
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 在雲端平台上自動化投影片建立——快速且可靠地產生、編輯與轉換 PowerPoint 及 OpenDocument 檔案。"
---
## **介紹**

手動建立 PowerPoint 簡報可能既耗時又重複，尤其是當內容基於經常變更的動態資料時。無論是產生每週的商業報告、彙整教學素材，或是製作客戶可直接使用的業務簡報，自動化都能節省大量時間，並確保團隊之間的一致性。

對於 .NET 開發人員而言，自動化產生 PowerPoint 簡報可開啟強大的可能性。您可以將投影片產生整合至 Web 入口網站、桌面工具、後端服務或雲端平台，即時將資料轉換為專業且具品牌形象的簡報——按需生成。

在本文中，我們將探討 .NET 應用程式（包含雲端平台部署）中自動化產生 PowerPoint 的常見使用案例，以及它為何成為現代解決方案中的關鍵功能。從即時取得商業資料到將文字或圖像轉換成投影片，目標是將原始內容轉化為結構化、視覺化的格式，讓觀眾能立即理解。

## **PowerPoint 自動化在 .NET 中的常見使用案例**

自動化產生 PowerPoint 在需要動態組合、個人化或頻繁更新簡報內容的情境下特別有價值。以下是最常見的實務案例：

- **商業報告與儀表板**  
  透過從資料庫或 API 取得即時資料，產生銷售摘要、關鍵績效指標或財務績效報告。

- **個人化銷售與行銷簡報**  
  使用 CRM 或表單資料自動建立客製化的提案簡報，確保快速交付與品牌一致性。

- **教育內容**  
  將學習教材、測驗或課程概要轉換為結構化的投影片，供 e‑learning 平台使用。

- **資料與 AI 驅動的洞見**  
  以自然語言處理或分析引擎將原始資料或長篇文字轉換為摘要簡報。

- **媒體式投影片**  
  從上傳的圖片、標註螢幕截圖或影片關鍵影格組合投影片，並加入說明文字。

- **文件轉換**  
  自動將 Word 文件、PDF 或表單輸入轉為視覺化簡報，減少手動工作。

- **開發人員與技術工具**  
  從程式碼或 Markdown 直接產生技術示範、文件概覽或變更紀錄的投影片。

透過自動化這些工作流程，組織能夠擴大內容產出規模、維持一致性，並釋放時間投入更具策略性的工作。

## **讓我們撰寫程式**

在此範例中，我們選擇 **[Aspose.Slides for .NET](https://products.aspose.com/slides/zh-hant/net)** 來示範 PowerPoint 自動化，因為它的功能完整且在程式化操作簡報時相當容易上手。

相較於需要直接操作 Open XML 結構、通常會產生冗長且較難閱讀程式碼的 **[Open XML SDK](https://github.com/dotnet/Open-XML-SDK)**，Aspose.Slides 提供更高階的 API，將複雜性抽象化，使開發者可以專注於簡報邏輯—如版面配置、格式設定與資料繫結—而不必深入了解 PowerPoint 檔案格式的細節。

雖然 Aspose.Slides 為商業授權套件，但它提供的[免費試用](https://releases.aspose.com/slides/zh-hant/net/) 版已足以執行本文提供的所有範例。對於展示概念、測試功能或建立概念驗證（Proof of Concept）而言，試用版已相當充足。這讓開發者在未購買授權前即可輕鬆嘗試自動化產生 PowerPoint。

若您尋求開源或免授權的替代方案，Open XML SDK 或 [NPOI](https://github.com/dotnetcore/NPOI) 也是可考慮的選擇，只是它們通常需要撰寫更多程式碼，且需更深入了解底層檔案格式。

好，讓我們一步步使用真實範例內容建立示範簡報。

請先確定已在專案中加入 Aspose.Slides NuGet 套件的參考：

```sh
dotnet add package Aspose.Slides.NET
```

### **建立標題投影片**

我們將先建立一個新簡報，並加入包含主標題與副標題的標題投影片。

```cs
using var presentation = new Presentation();

var slide0 = presentation.Slides[0];
slide0.LayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Title);

var titleShape = slide0.Shapes[0] as IAutoShape;
var subtitleShape = slide0.Shapes[1] as IAutoShape;

titleShape.TextFrame.Text = "Quarterly Business Review – Q1 2025";
subtitleShape.TextFrame.Text = "Prepared for Executive Team";
```

![標題投影片](slide_0.png)

### **加入包含柱狀圖的投影片**

接著，我們建立一張顯示各區域銷售績效的柱狀圖投影片。

```cs
var layoutSlide1 = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
var slide1 = presentation.Slides.AddEmptySlide(layoutSlide1);

var chart = slide1.Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350, false);
chart.Legend.Position = LegendPositionType.Bottom;
chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("Data from January – March 2025");
chart.ChartTitle.Overlay = false;

var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 1, 0, "North America"));
chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 2, 0, "Europe"));
chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 3, 0, "Asia Pacific"));
chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 4, 0, "Latin America"));
chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 5, 0, "Middle East"));

var series = chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 1, "Sales ($K)"), chart.Type);
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 480));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 365));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 290));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 4, 1, 150));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 5, 1, 120));
```

![包含圖表的投影片](slide_1.png)

### **加入包含表格的投影片**

現在，我們加入一張以表格形式呈現關鍵績效指標的投影片。

```cs
var layoutSlide2 = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
var slide2 = presentation.Slides.AddEmptySlide(layoutSlide2);

var columnWidths = new double[] { 200, 100 };
var rowHeights = new double[] { 40, 40, 40, 40, 40 };

var table = slide2.Shapes.AddTable(200, 200, columnWidths, rowHeights);
table[0, 0].TextFrame.Text = "Metric";
table[1, 0].TextFrame.Text = "Value";
table[0, 1].TextFrame.Text = "Total Revenue";
table[1, 1].TextFrame.Text = "$1.4M";
table[0, 2].TextFrame.Text = "Gross Margin";
table[1, 2].TextFrame.Text = "54%";
table[0, 3].TextFrame.Text = "New Customers";
table[1, 3].TextFrame.Text = "340";
table[0, 4].TextFrame.Text = "Customer Retention";
table[1, 4].TextFrame.Text = "87%";
```

![包含表格的投影片](slide_2.png)

### **加入帶有項目符號的摘要投影片**

最後，我們使用簡單的項目符號列表，加入摘要與行動計畫投影片。

```cs
IParagraph CreateBulletParagraph(string text)
{
    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    paragraph.ParagraphFormat.Indent = 15;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    paragraph.Text = text;
    return paragraph;
}
```
```cs
var layoutSlide3 = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
var slide3 = presentation.Slides.AddEmptySlide(layoutSlide3);

var bulletList = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 50, 600, 200);
bulletList.FillFormat.FillType = FillType.NoFill;
bulletList.LineFormat.FillFormat.FillType = FillType.NoFill;

bulletList.TextFrame.Paragraphs.Clear();
bulletList.TextFrame.Paragraphs.Add(CreateBulletParagraph("Strong performance in North America; growth opportunity in Asia Pacific"));
bulletList.TextFrame.Paragraphs.Add(CreateBulletParagraph("Improve marketing outreach in underperforming regions"));
bulletList.TextFrame.Paragraphs.Add(CreateBulletParagraph("Prepare new campaign strategy for Q2"));
bulletList.TextFrame.Paragraphs.Add(CreateBulletParagraph("Schedule follow-up review in early July"));
```

![包含文字的投影片](slide_3.png)

### **儲存簡報**

最後，將簡報寫入磁碟：

```cs
presentation.Save("presentation.pptx", SaveFormat.Pptx);
```

## **結論**

在 .NET 應用程式中自動化產生 PowerPoint 簡報，可顯著節省時間並減少手動工作。透過結合圖表、表格與文字等動態內容，開發者能快速產出一致且具專業水準的簡報，無論是商業報告、客戶會議或教育教材皆適用。

本文示範了從頭開始自動建立簡報的完整流程，包括加入標題投影片、圖表與表格。此方法可廣泛套用於各種需要自動化、資料驅動簡報的情境。

善用合適的工具，.NET 開發人員即可高效自動化 PowerPoint 產出，提升生產力並確保簡報內容的一致性。