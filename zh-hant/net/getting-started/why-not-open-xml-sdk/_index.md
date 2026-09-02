---
title: 為什麼不使用 Open XML SDK
type: docs
weight: 50
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
description: "了解為何 Aspose.Slides 是比免費的 Open XML SDK 更佳的選擇：比較功能、免自動化轉換，以及對 PPT、PPTX 與 ODP 的廣泛支援。"
---
## **概觀**

本文說明開發人員在處理簡報文件時，何時可能會選擇 Open XML SDK 或 Aspose.Slides。它將 Open XML SDK 描述為一個用於操作 OOXML 套件及其底層 XML 元素的函式庫，而 Aspose.Slides 則被呈現為具備高階物件模型且支援眾多 PowerPoint 相關任務的簡報處理函式庫。

本文依照支援的格式、程式模型、呈現、平台支援以及常見使用案例，比較兩者的差異。也說明 Open XML SDK 可能適用於基本的 PPTX 操作或直接存取 OOXML 元素，而 Aspose.Slides 則更適合處理複雜的簡報任務，例如處理多種 PowerPoint 格式、複製或複製形狀、取代文字、套用動畫，以及將簡報轉換為 PDF、TIFF 或 XPS。

## **什麼是 Open XML SDK？**
有時，我們會收到這樣的問題：*為什麼要使用 Aspose 產品，而不是免費的 Open XML SDK？*

我們發現以功能和特性來回答這個問題相當容易。

根據 [MSDN 資料庫](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk) 的說明，Open XML SDK 如下定義：

> 「Open XML SDK 2.0 簡化了操作 Open XML 套件以及套件內底層 Open XML 架構元素的任務。Open XML SDK 2.0 封裝了開發人員在 Open XML 套件上執行的許多常見工作，讓您僅以少量程式碼即可執行複雜操作。OOXML 文件本質上是壓縮的 XML 檔案，Open XML SDK 是一組類別，讓您能以強型別方式處理 OOXML 文件的內容。也就是說，與其先解壓縮檔案以提取 XML、將 XML 載入 DOM 樹，再直接操作 XML 元素與屬性，Open XML SDK 提供類別來完成這些工作。」 

## **什麼是 Aspose.Slides？**
Aspose.Slides 是一個類別函式庫，允許應用程式執行以下簡報處理工作：

- 以簡報物件模型進行程式設計。
- 高品質的轉換，支援所有常見的 PowerPoint 簡報格式，包括轉換為 PDF、XPS 與 TIFF。
- 以 PNG、JPEG、BMP 等常見格式產生投影片縮圖，並支援投影片匯出為 SVG。
- 從頭建立簡報或結合一或多個文件的元素來組合簡報。
- 新增動畫、OLE 框架、表格，建立與管理圖表。
- 在 TextFrames、Paragraph 與 Portion 級別上進行（廣泛的）文字格式控制與管理。

欲瞭解可用功能的更多細節，請參閱 [Aspose.Slides 功能](/slides/zh-hant/net/product-overview/) 頁面。

## **比較 Open XML SDK 與 Aspose.Slides**
此表格比較 Open XML SDK 與 Aspose.Slides 的功能與特性。

|**功能或功能類別**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|支援的簡報格式|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|從 PPT 轉換為 PPTX|否|是|
|<p>高階程式設計，使用簡報文件物件模型 (DOM)：</p><p>- 找尋與取代文字。</p><p>- 在簡報中組合投影片。</p>|否|是|
|使用文件物件模型的詳細程式設計；存取個別元素與格式，如 TextHolders、TextFrames、Paragraphs 與 Portions。|是|是|
|低階直接且完整存取底層 XML 元素與屬性，例如關聯識別碼、OOXML 文件的清單識別碼。|是|否|
|<p>簡報呈現：</p><p>- 將簡報渲染為 PDF、PDF 註釋、XPS、TIFF 圖像。</p><p>- 將投影片縮圖渲染為 PNG、JPEG、BMP、SVG 與 TIFF。</p><p>- 指定影像解析度、品質、壓縮與其他選項。</p>|否|是|
|支援的平台|Windows, .NET|Windows, Linux, Java, .NET, Mono|

## **結論**
Open XML SDK 與 Aspose.Slides 並非直接競爭的產品，因為它們針對的需求相當不同，且目標受眾也不同。

{{% alert color="info" %}} 

Open XML SDK 是一個提供強型別方式操作 OOXML 文件的類別函式庫，而 Aspose.Slides 是一個功能強大的簡報處理函式庫，對幾乎所有 Microsoft PowerPoint 檔案格式提供極佳支援。 

{{% /alert %}} 

如果您的工作流程只是對 PPTX 文件執行基本程式操作，則 Open XML SDK 可能是合適的選擇。使用 Open XML SDK，您應能輕鬆完成產生簡易 PPTX 文件、移除註解、頁首/頁尾、提取圖像等簡單任務。某些任務只能透過 Open XML SDK 完成，而無法使用 Aspose.Slides。例如，若需直接存取 OOXML 文件的 XML 元素與屬性，則應使用 Open XML SDK。

若需要在文件上執行複雜任務──如下列清單所示──則 Aspose.Slides 是您的最佳選擇。

- 處理舊版 PowerPoint 格式（以及 PPTX）。
- 在投影片中複製或克隆形狀，並以適當方式結合物件、樣式與其他格式元素。
- 取代已格式化或未格式化的文字。
- 套用動畫並使用連接線與形狀。
- 將文件轉換為 PDF、TIFF 或 XPS，讓結果看起來像是由 Microsoft PowerPoint 進行的轉換。
- 在桌面與 Web 環境中開發 .NET 或 Java 應用程式。