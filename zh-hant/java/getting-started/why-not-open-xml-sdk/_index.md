---
title: 為何不選 Open XML SDK
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
description: "了解為什麼 Aspose.Slides 是比免費的 Open XML SDK 更好的選擇：比較功能、免自動化轉換以及對 PPT、PPTX 與 ODP 的廣泛支援。"
---
## **概述**

本文說明開發人員在何種情況下會選擇 Open XML SDK 或 Aspose.Slides 來處理簡報文件。文章將 Open XML SDK 描述為用於操控 OOXML 套件及其底層 XML 元素的函式庫，而 Aspose.Slides 被呈現為具備高階物件模型且支援許多 PowerPoint 相關任務的簡報處理函式庫。

本文依據支援的格式、程式模型、渲染與列印功能、平台相容性以及常見使用情境來比較兩者。亦說明 Open XML SDK 適合進行基本的 PPTX 操作或直接存取 OOXML 元素，而 Aspose.Slides 則較適用於需要處理多種 PowerPoint 格式、複製或克隆圖形、取代文字、套用動畫，以及將簡報轉換為 PDF、TIFF 或 XPS 等較複雜的簡報任務。

## **什麼是 Open XML SDK？**
依據[MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk)，Open XML SDK 定義為：

Open XML SDK 2.0 簡化了操控 Open XML 套件及套件內底層 Open XML 綱要元素的工作。Open XML SDK 2.0 封裝了開發人員在 Open XML 套件上執行的許多常見任務，讓您僅以數行程式碼即可完成複雜操作。

OOXML 文件本質上是壓縮的 XML 檔案，Open XML SDK 是一組類別，可讓您以強型別方式處理 OOXML 文件的內容。這表示您不必先解壓縮檔案取得 XML、再載入 XML 成為 DOM 樹並直接操作 XML 元素與屬性；Open XML SDK 提供相應的類別來完成這些工作。

## **什麼是 Aspose.Slides？**
Aspose.Slides 是一個類別函式庫，讓您的應用程式能執行以下簡報處理工作：

- 以 **Presentation** 物件模型進行程式設計。
- 在所有熱門支援的 PowerPoint 簡報格式之間進行高品質轉換，包含轉換為 PDF、XPS 與 TIFF。
- 能以 PNG、JPEG、BMP 等常見格式產生投影片縮圖，並支援投影片匯出為 SVG。
- 能從頭建立簡報，或由一或多個文件組合而成。
- 支援加入動畫、Ole 框架、表格、建立與管理圖表。
- 提供廣泛的控制，管理 TextFrames、段落與 Portion 層級的文字格式。

欲了解更多支援的功能，請造訪[Aspose.Slides Features](/slides/zh-hant/java/product-overview/)。

## **比較 Open XML SDK 與 Aspose.Slides**
{{% alert color="info" %}} 

以下表格比較 Open XML SDK 與 Aspose.Slides 的功能。

{{% /alert %}} 

|**功能或功能類別**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|支援的簡報格式|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|從 PPT 轉換為 PPTX|否|是|
|<p>以簡報文件物件模型 (DOM) 進行高階程式設計：</p><p>- 找尋並取代文字。</p><p>- 組合簡報中的投影片。</p>|否|是|
|以文件物件模型進行細部程式設計，存取個別元素與格式，例如 TextHolders、TextFrames、Paragraphs 與 Portions。|是|是|
|以低階方式直接完整存取底層 XML 元素與屬性，例如關聯識別碼、OOXML 文件的清單識別碼。|是|否|
|<p>渲染：</p><p>- 將簡報渲染為 PDF、PDF 註釋、XPS、TIFF 圖像。</p><p>- 將投影片縮圖渲染為 PNG、JPEG、BMP、SVG 與 TIFF。</p><p>- 指定影像解析度、品質、壓縮與其他選項。</p>|否|是|
|支援平台|Windows，.NET|Windows，Linux，UNIX，MAC，Java，PHP，Mono|

## **結論**
{{% alert color="info" %}} 

Open XML SDK 與 Aspose.Slides 並非正面競爭的產品，因為它們針對的需求與受眾截然不同。Open XML SDK 是提供強型別方式操作 OOXML 文件的類別函式庫。Aspose.Slides 則是一套功能強大的簡報處理函式庫，對幾乎所有 Microsoft PowerPoint 檔案格式都有完善支援。

如果您只需要對 PPTX 文件執行相對基礎的程式操作，Open XML SDK 可能是合適的選擇。使用 Open XML SDK，您可以輕鬆完成產生簡單 PPTX 文件、移除批註、頁首/頁尾、擷取影像等工作。有些任務可以透過 Open XML SDK 完成，但 Aspose.Slides 無法做到。例如，若您必須直接存取 OOXML 文件的 XML 元素與屬性，應使用 Open XML SDK。然而，若您需要對文件執行複雜操作，如下列任務，則使用 Aspose.Slides 是最佳方案：

- 支援 PPTX 之外的舊版 PowerPoint 格式。
- 在投影片中以適當方式複製或克隆圖形，保留物件、樣式與其他格式設定。
- 取代已格式化或未格式化的文字。
- 套用動畫，並使用圖形連接線。
- 將文件轉換為 PDF、TIFF 或 XPS，確保呈現效果與 Microsoft PowerPoint 轉換結果相同。
- 在桌面與 Web 環境中開發 .NET 或 Java 應用程式。

{{% /alert %}}