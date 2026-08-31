---
title: 為何不使用 Open XML SDK
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
description: "了解為何 Aspose.Slides 是比免費的 Open XML SDK 更好的選擇：比較功能、無需自動化的轉換，以及對 PPT、PPTX 和 ODP 的廣泛支援。"
---
## **概觀**

本文說明開發人員在何種情況下可能會選擇 Open XML SDK 或 Aspose.Slides 來處理簡報文件。它將 Open XML SDK 描述為用於操作 OOXML 套件及其底層 XML 元素的函式庫，而 Aspose.Slides 則被呈現為具備高階物件模型且支援眾多 PowerPoint 相關任務的簡報處理函式庫。

本文依據支援的格式、程式模型、轉譯、平台支援與常見使用情境比較兩者。亦說明 Open XML SDK 可能適合進行基本的 PPTX 操作或直接存取 OOXML 元素，而 Aspose.Slides 更適合處理複雜的簡報工作，如處理多種 PowerPoint 格式、複製或克隆圖形、取代文字、套用動畫，以及將簡報轉換為 PDF、TIFF 或 XPS。

## **什麼是 Open XML SDK？**
依據[MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk)的說明，Open XML SDK 定義如下：

Open XML SDK 2.0 簡化了操作 Open XML 套件與套件內底層 Open XML 架構元件的工作。Open XML SDK 2.0 封裝了開發人員在 Open XML 套件上執行的許多常見任務，讓您只需幾行程式碼即可執行複雜操作。

OOXML 文件本質上是壓縮的 XML 檔案，Open XML SDK 是一組類別，讓您以強型別方式處理 OOXML 文件的內容。也就是說，您不必先解壓縮檔案以提取 XML，將 XML 載入 DOM 樹並直接操作 XML 元素與屬性，Open XML SDK 提供了相應的類別來完成此工作。

## **什麼是 Aspose.Slides？**
Aspose.Slides 是一套類別庫，讓您的應用程式能執行以下簡報處理任務：

- 使用 **Presentation** 物件模型進行程式設計。
- 在所有常見支援的 PowerPoint 簡報格式之間進行高品質轉換，包含轉換為 PDF、XPS 與 TIFF。
- 能以 PNG、JPEG、BMP 等常見格式產生投影片縮圖，並支援投影片匯出為 SVG。
- 能從頭建立簡報或透過合併一個或多個文件來建立簡報。
- 支援加入動畫、Ole 框架、表格，建立與管理圖表。
- 提供廣泛的控制，以在 TextFrames、段落與 Portion 級別管理文字格式。

欲了解支援的功能細節，請造訪[Aspose.Slides Features](/slides/zh-hant/java/product-overview/)。

## **比較 Open XML SDK 與 Aspose.Slides**
{{% alert color="info" %}} 

以下表格比較 Open XML SDK 與 Aspose.Slides 的功能。

{{% /alert %}} 

|**功能或功能類別**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|支援的簡報格式|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|從 PPT 轉換為 PPTX|No|Yes|
|<p>使用高階 Presentation Document Object Model（DOM）程式設計：</p><p>- 找尋並取代文字。</p><p>- 組合投影片於簡報中。</p>|No|Yes|
|使用文件物件模型進行詳細程式設計，存取個別元素與格式，如 TextHolders、TextFrames、Paragraphs 與 Portions。|Yes|Yes|
|低階直接且完整存取底層 XML 元素與屬性，如關聯識別碼、OOXML 文件的清單識別碼。|Yes|No|
|<p>轉譯：</p><p>- 將簡報轉譯為 PDF、PDF 註釋、XPS、TIFF 圖像。</p><p>- 將投影片縮圖轉譯為 PNG、JPEG、BMP、SVG 與 TIFF。</p><p>- 指定影像解析度、品質、壓縮與其他選項。</p>|No|Yes |
|支援的平台|Windows, .NET|Windows, Linux,UNIX, MAC, Java, PHP, Mono|

## **結論**
{{% alert color="info" %}} 

Open XML SDK 與 Aspose.Slides 並非直接競爭，因為它們針對的需求與受眾截然不同。Open XML SDK 是提供強型別方式操作 OOXML 文件的類別庫。Aspose.Slides 則是一個功能非常完善的簡報處理函式庫，對幾乎所有 Microsoft PowerPoint 檔案格式提供極佳支援。

如果您只需要對 PPTX 文件執行相當基礎的程式操作，Open XML SDK 可能是一個合適的選擇。使用 Open XML SDK，您可以輕鬆完成產生簡易 PPTX 文件、移除註解、頁首/頁尾、提取影像等簡單任務。有些任務可以藉由 Open XML SDK 完成，但 Aspose.Slides 無法做到。例如，若需直接存取 OOXML 文件的 XML 元素與屬性，應使用 Open XML SDK。然而，若需在文件上執行複雜操作，如以下任務，則使用 Aspose.Slides 為最佳選擇：

- 支援 PPTX 之外的舊版 PowerPoint 格式。
- 以適當方式複製或克隆投影片中的圖形，結合物件、樣式與其他格式設定。
- 取代已格式化或未格式化的文字。
- 套用動畫與使用圖形連接器。
- 將文件轉換為 PDF、TIFF 或 XPS，使其外觀與 Microsoft PowerPoint 轉換結果完全相同。
- 在桌面與 Web 環境中開發 .NET 或 Java 應用程式。

{{% /alert %}}