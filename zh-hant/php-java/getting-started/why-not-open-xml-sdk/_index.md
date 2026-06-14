---
title: 為何不使用 Open XML SDK
type: docs
weight: 120
url: /zh-hant/php-java/why-not-open-xml-sdk/
keywords:
- Open XML SDK
- 比較
- 簡報物件模型
- 高品質轉換
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "了解為何 Aspose.Slides 是比免費的 Open XML SDK 更佳的選擇：比較功能、免自動化轉換，以及對 PPT、PPTX 和 ODP 的廣泛支援。"
---
## **概觀**

本文說明開發人員在何時會選擇 Open XML SDK 或 Aspose.Slides 來處理簡報文件。它將 Open XML SDK 描述為用於操作 OOXML 套件及其底層 XML 元素的函式庫，而 Aspose.Slides 則被呈現為具備高階物件模型且支援許多 PowerPoint 相關任務的簡報處理函式庫。

本文依照支援的格式、程式模型、轉譯與列印功能、平台相容性以及常見使用情境來比較兩者。也說明 Open XML SDK 可能適合用於基本的 PPTX 操作或直接存取 OOXML 元素，而 Aspose.Slides 則較適合處理複雜的簡報任務，例如處理多種 PowerPoint 格式、複製或克隆圖形、取代文字、套用動畫，以及將簡報轉換為 PDF、TIFF 或 XPS。

## **什麼是 Open XML SDK？**
根據 [MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk) 的說明，Open XML SDK 定義如下：

Open XML SDK 2.0 簡化了操作 Open XML 套件與套件內底層 Open XML 結構描述元素的工作。Open XML SDK 2.0 封裝了開發人員在 Open XML 套件上常執行的許多工作，讓您只需幾行程式碼即可執行複雜的操作。

OOXML 文件本質上是壓縮的 XML 檔案，Open XML SDK 是一組類別，讓您以強型別方式處理 OOXML 文件的內容。也就是說，您不必先解壓縮檔案取得 XML、將 XML 載入 DOM 樹再直接操作 XML 元素與屬性，Open XML SDK 提供類別協助完成這些工作。

## **什麼是 Aspose.Slides？**
Aspose.Slides 是一套類別函式庫，讓您的應用程式能執行以下簡報處理工作：

- 以 **Presentation** 物件模型進行程式設計。
- 在所有常見的 PowerPoint 簡報格式之間進行高品質轉換，包含轉換為 PDF、XPS 與 TIFF。
- 能以 PNG、JPEG、BMP 等常見格式產生投影片縮圖，並支援投影片匯出為 SVG。
- 能從頭建立簡報或由一或多個文件合併而成。
- 支援新增動畫、Ole 框架、表格，建立與管理圖表。
- 提供廣泛的控制，以在 TextFrames、段落與文字段層級管理文字格式設定。

欲瞭解支援的功能細節，請參閱 [Aspose.Slides Features](/slides/zh-hant/php-java/product-overview/)。

## **比較 Open XML SDK 與 Aspose.Slides**
{{% alert color="primary" %}} 

以下表格比較 Open XML SDK 與 Aspose.Slides 的功能。

{{% /alert %}} 

|**功能或功能類別**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|支援的簡報格式|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|將 PPT 轉換為 PPTX|No|Yes|
|<p>高階程式設計，使用簡報文件物件模型 (DOM)：</p><p>- 查找並取代文字。</p><p>- 組合簡報中的投影片。</p>|No|Yes|
|以文件物件模型進行詳細程式設計，存取個別元素與格式，如 TextHolders、TextFrames、段落與文字片段。|Yes|Yes|
|低階直接且完整存取底層 XML 元素與屬性，如關聯識別碼、OOXML 文件的清單識別碼。|Yes|No|
|<p>轉譯：</p><p>- 將簡報轉譯為 PDF、PDF 註釋、XPS、TIFF 影像。</p><p>- 將投影片縮圖轉譯為 PNG、JPEG、BMP、SVG 與 TIFF。</p><p>- 指定影像解析度、品質、壓縮與其他選項。</p>|No|Yes |
|支援的平台|Windows, .NET|Windows, Linux,UNIX, MAC, Java, PHP, Mono|

## **結論**
{{% alert color="primary" %}} 

Open XML SDK 與 Aspose.Slides 並非直接競爭，因為它們針對的需求與受眾截然不同。Open XML SDK 是提供強型別方式操作 OOXML 文件的類別函式庫；Aspose.Slides 則是功能非常完整的簡報處理函式庫，支援幾乎所有 Microsoft PowerPoint 檔案格式。

如果您只需要對 PPTX 文件執行相當基本的程式操作，Open XML SDK 可能是適合的選擇。使用 Open XML SDK，您可以輕鬆完成產生簡單 PPTX 文件、移除註解、頁首/頁尾、擷取影像等簡單任務。某些任務可以透過 Open XML SDK 完成，但 Aspose.Slides 無法實作。例如，若您需要直接存取 OOXML 文件的 XML 元素與屬性，應使用 Open XML SDK。然而，若您需要對文件執行複雜操作，例如以下任務，則 Aspose.Slides 是最佳選擇：

- 支援 PPTX 以外的舊版 PowerPoint 格式。
- 在投影片中以適當方式複製或克隆圖形，保留物件、樣式與其他格式設定。
- 取代已格式化或未格式化的文字。
- 套用動畫，並使用連接線與圖形。
- 將文件轉換為 PDF、TIFF 或 XPS，使其呈現方式完全與 Microsoft PowerPoint 轉換後相同。
- 在桌面與 Web 環境中開發 .NET 或 Java 應用程式。

{{% /alert %}}