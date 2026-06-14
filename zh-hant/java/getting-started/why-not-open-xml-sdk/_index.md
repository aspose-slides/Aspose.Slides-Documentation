---
title: 為何不選擇 Open XML SDK
type: docs
weight: 120
url: /zh-hant/java/why-not-open-xml-sdk/
keywords:
- Open XML SDK
- 比較
- 簡報物件模型
- 高品質轉換
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "了解為何 Aspose.Slides 比免費的 Open XML SDK 更佳：比較功能、免自動化轉換，以及對 PPT、PPTX 與 ODP 的廣泛支援。"
---
## **概述**

本文說明開發人員在處理簡報文件時，何時會選擇 Open XML SDK 或 Aspose.Slides。它把 Open XML SDK 描述為用於操作 OOXML 套件及其底層 XML 元素的函式庫，而 Aspose.Slides 則呈現為具有高階物件模型且支援眾多 PowerPoint 相關任務的簡報處理函式庫。

本文會從支援的格式、程式模型、轉譯與列印功能、平台支援以及常見使用情境等面向比較兩者。也說明 Open XML SDK 可能適合基本的 PPTX 操作或直接存取 OOXML 元素，而 Aspose.Slides 則較適合處理多種 PowerPoint 格式、複製或克隆圖形、取代文字、套用動畫，以及將簡報轉換為 PDF、TIFF 或 XPS 等複雜任務。

## **什麼是 Open XML SDK？**
根據[MSDN 資料庫](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk)，Open XML SDK 的定義如下：

Open XML SDK 2.0 簡化了操作 Open XML 套件及套件內底層 Open XML 架構元素的工作。Open XML SDK 2.0 封裝了開發人員在 Open XML 套件上執行的許多常見任務，讓您只需幾行程式碼即可完成複雜操作。

OOXML 文件本質上是壓縮的 XML 檔案，Open XML SDK 是一組類別，允許您以強型別方式處理 OOXML 文件的內容。也就是說，您不必先解壓縮檔案以抽取 XML、再將 XML 載入 DOM 樹並直接操作 XML 元素與屬性，Open XML SDK 提供了相應的類別來完成這些工作。

## **什麼是 Aspose.Slides？**
Aspose.Slides 是一套類別庫，讓您的應用程式能執行以下簡報處理工作：

- 使用 **Presentation** 物件模型進行程式設計。
- 在所有常見支援的 PowerPoint 簡報格式之間進行高品質的相互轉換，包含轉換為 PDF、XPS 與 TIFF。
- 能以 PNG、JPEG、BMP 等常見格式產生投影片縮圖，並支援將投影片匯出為 SVG。
- 能從頭建立簡報或從一或多個文件組合簡報。
- 支援加入動畫、Ole 框架、表格，建立與管理圖表。
- 提供廣泛的控制，管理 TextFrames、段落與 Portion 級別的文字格式。

如需了解支援的功能細節，請造訪[Aspose.Slides 功能](/slides/zh-hant/java/product-overview/)。

## **比較 Open XML SDK 與 Aspose.Slides**
{{% alert color="primary" %}} 

以下表格比較 Open XML SDK 與 Aspose.Slides 的功能。

{{% /alert %}} 

|**功能或功能類別**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|支援的簡報格式|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|從 PPT 轉換為 PPTX|否|是|
|<p>高層次程式設計，使用簡報文件物件模型（DOM）：</p><p>- 搜尋並取代文字。</p><p>- 組合簡報中的投影片。</p>|否|是|
|具備文件物件模型的詳細程式設計，可存取個別元素與格式，如 TextHolders、TextFrames、Paragraphs 與 Portions。|是|是|
|低階直接且完整存取底層 XML 元素與屬性，如關聯識別碼、OOXML 文件的清單識別碼。|是|否|
|<p>轉譯：</p><p>- 將簡報轉譯為 PDF、PDF 註釋、XPS、TIFF 圖像。</p><p>- 將投影片縮圖轉譯為 PNG、JPEG、BMP、SVG 與 TIFF。</p><p>- 指定影像解析度、品質、壓縮與其他選項。</p>|否|是|
|支援平台|Windows, .NET|Windows, Linux,UNIX, MAC, Java, PHP, Mono|

## **結論**
{{% alert color="primary" %}} 

Open XML SDK 與 Aspose.Slides 不是直接競爭的關係，因為它們針對的需求與受眾截然不同。Open XML SDK 是提供強型別方式操作 OOXML 文件的類別庫；Aspose.Slides 則是一套功能強大的簡報處理函式庫，幾乎支援所有 Microsoft PowerPoint 檔案格式。

如果您僅需要在 PPTX 文件上執行相當基礎的程式操作，Open XML SDK 可能是合適的選擇。使用 Open XML SDK，您可以輕鬆完成產生簡單 PPTX 文件、移除註解或頁首/頁尾、擷取影像等簡單任務。有些工作可以使用 Open XML SDK 完成，但在 Aspose.Slides 中無法實現。例如，若您需要直接存取 OOXML 文件的 XML 元素與屬性，就應使用 Open XML SDK。然而，若您需要在文件上執行複雜操作，例如以下任務，則使用 Aspose.Slides 為最佳方案：

- 支援 PPTX 之外的舊版 PowerPoint 格式。
- 在投影片中以適當方式複製或克隆圖形，保留物件、樣式與其他格式。
- 取代已格式化或未格式化的文字。
- 套用動畫並使用連接線與圖形。
- 將文件轉換為 PDF、TIFF 或 XPS，且外觀與 Microsoft PowerPoint 轉換結果完全相同。
- 在桌面與 Web 環境中開發 .NET 或 Java 應用程式。

{{% /alert %}}