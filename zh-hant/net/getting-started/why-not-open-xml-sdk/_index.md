---
title: 為何不使用 Open XML SDK
type: docs
weight: 180
url: /zh-hant/net/why-not-open-xml-sdk/
aliases:
  - /net/slides-on-cloud-platforms/extracting-text/open-xml-sdk/
keywords:
- Open XML SDK
- 比較
- 簡報物件模型
- 高品質轉換
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "了解為何 Aspose.Slides 比免費的 Open XML SDK 更適合：比較功能、無需自動化的轉換，以及對 PPT、PPTX 與 ODP 的廣泛支援。"
---
## **概觀**

本文說明開發人員在何種情況下會選擇 Open XML SDK 或 Aspose.Slides 來處理簡報文件。它將 Open XML SDK 描述為用於操作 OOXML 套件及其底層 XML 元素的程式庫，而 Aspose.Slides 則被呈現為具有高階物件模型且支援許多 PowerPoint 相關任務的簡報處理程式庫。

本文以支援的格式、程式模型、呈現、平台支援以及常見使用案例等面向比較兩者。它同時說明 Open XML SDK 可能適合基本的 PPTX 操作或直接存取 OOXML 元素，而 Aspose.Slides 更適合處理多種 PowerPoint 格式、複製或克隆圖形、取代文字、套用動畫，以及將簡報轉換為 PDF、TIFF 或 XPS 等複雜任務。

## **什麼是 Open XML SDK？**
有時我們會收到這樣的問題：*為什麼要使用 Aspose 產品而不是免費的 Open XML SDK？*

我們發現以功能與特性來回答這個問題相當直接。

依據 [MSDN Library](https://learn.microsoft.com/en-us/office/open-xml/open-xml-sdk) 的說明，Open XML SDK 的定義如下：

> “Open XML SDK 2.0 簡化了操作 Open XML 套件以及套件內底層 Open XML 架構元素的工作。Open XML SDK 2.0 封裝了開發人員在 Open XML 套件上執行的許多常見任務，讓您只需幾行程式碼即可完成複雜操作。OOXML 文件本質上是壓縮的 XML 檔案，Open XML SDK 是一組類別，讓您以強型別的方式處理 OOXML 文件的內容。也就是說，與其解壓縮檔案以取得 XML、載入 XML 到 DOM 樹並直接操作 XML 元素與屬性，Open XML SDK 提供了相應的類別來完成這些工作。”

## **什麼是 Aspose.Slides？**
Aspose.Slides 是一個類別程式庫，讓應用程式能執行以下簡報處理工作：

- 使用簡報物件模型進行程式設計。
- 高品質轉換，支援所有常見的 PowerPoint 簡報格式，並可轉換為 PDF、XPS 與 TIFF。
- 以 PNG、JPEG、BMP 等常見格式產生投影片縮圖，並支援投影片匯出為 SVG。
- 從頭建立簡報或將多個文件的元素結合起來。
- 新增動畫、OLE 框架、表格，建立與管理圖表。
- 在 TextFrames、Paragraph 及 Portion 層級上廣泛控制與管理文字格式。

欲了解更多可用功能，請參見 [Aspose.Slides Features](/slides/zh-hant/net/product-overview/) 頁面。

## **比較 Open XML SDK 與 Aspose.Slides**
此表格比較了 Open XML SDK 與 Aspose.Slides 的能力與功能。

|**功能或功能類別**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|支援的簡報格式|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|從 PPT 轉換為 PPTX|否|是|
|<p>使用高階的簡報文件物件模型 (DOM) 進行程式設計：</p><p>- 查找與取代文字。</p><p>- 組合簡報中的投影片。</p>|否|是|
|使用文件物件模型進行詳細程式設計；存取個別元素與格式，如 TextHolders、TextFrames、Paragraphs 與 Portions。|是|是|
|低階直接且完整存取底層 XML 元素與屬性，如關聯識別碼、OOXML 文件的清單識別碼。|是|否|
|<p>簡報呈現：</p><p>- 將簡報渲染為 PDF、PDF 註釋、XPS、TIFF 圖片。</p><p>- 將投影片縮圖渲染為 PNG、JPEG、BMP、SVG 與 TIFF。</p><p>- 指定影像解析度、品質、壓縮與其他選項。</p>|否|是|
|支援的平台|Windows, .NET|Windows, Linux, Java, .NET, Mono|

## **結論**
Open XML SDK 與 Aspose.Slides 並非直接競爭的產品，因為它們針對的需求大相徑庭，且目標受眾不同。

{{% alert color="info" title="注意" %}}
Open XML SDK 是一個提供強型別方式操作 OOXML 文件的類別程式庫，而 Aspose.Slides 是一個功能極其豐富的簡報處理程式庫，支援幾乎所有 Microsoft PowerPoint 檔案格式。
{{% /alert %}}

如果您的工作流程僅是對 PPTX 文件執行基本程式操作，則 Open XML SDK 可能是合適的選擇。使用 Open XML SDK，您可以輕鬆完成產生簡單 PPTX 文件、移除註解、標頭/頁尾、擷取影像等簡易任務。某些任務只能透過 Open XML SDK 完成，且無法使用 Aspose.Slides。例如，若需要直接存取 OOXML 文件的 XML 元素與屬性，則應選用 Open XML SDK。

若您需要在文件上執行複雜任務——例如以下清單中的工作——則 Aspose.Slides 是最佳選擇。

- 處理較舊的 PowerPoint 格式（以及 PPTX）。
- 在投影片中複製或克隆圖形，且能以恰當方式結合物件、樣式與其他格式設定。
- 取代已格式化或未格式化的文字。
- 套用動畫並使用連接線與圖形。
- 將文件轉換為 PDF、TIFF 或 XPS，使其外觀與 Microsoft PowerPoint 的轉換結果相同。
- 在桌面與 Web 環境中開發 .NET 或 Java 應用程式。