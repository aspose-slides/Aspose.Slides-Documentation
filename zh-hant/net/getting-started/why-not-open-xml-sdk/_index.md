---
title: 為何不使用 Open XML SDK
type: docs
weight: 50
url: /zh-hant/net/why-not-open-xml-sdk/
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
description: "了解為何 Aspose.Slides 是比免費 Open XML SDK 更好的選擇：比較功能、免自動化轉換，以及對 PPT、PPTX 和 ODP 的廣泛支援。"
---
## **概觀**

本文說明開發者在處理簡報文件時，何時可能會選擇 Open XML SDK 或 Aspose.Slides。文章將 Open XML SDK 描述為一個用來操作 OOXML 套件及其底層 XML 元素的函式庫，而 Aspose.Slides 則被呈現為具備高階物件模型、支援許多 PowerPoint 相關任務的簡報處理函式庫。

文章透過支援的格式、程式模型、呈現與列印功能、平台相容性以及常見使用情境等面向，比較兩者的差異。也說明 Open XML SDK 可能適合用於基本的 PPTX 操作或直接存取 OOXML 元素，而 Aspose.Slides 則較適合需要處理多種 PowerPoint 格式、複製或克隆圖形、取代文字、套用動畫，以及將簡報轉換為 PDF、TIFF 或 XPS 等較複雜的簡報工作。

## **什麼是 Open XML SDK？**
有時，我們會收到這樣的問題：*為什麼要使用 Aspose 產品，而不是免費的 Open XML SDK？*

我們發現以功能與特性來說，這個問題很容易回答。

根據 [MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk)，Open XML SDK 的定義如下：

> "Open XML SDK 2.0 簡化了操作 Open XML 套件及套件內底層 Open XML 結構元素的任務。Open XML SDK 2.0 封裝了開發人員在 Open XML 套件上執行的許多常見工作，讓您只需少量程式碼即可完成複雜的操作。OOXML 文件本質上是已壓縮的 XML 檔案，而 Open XML SDK 是一組類別，允許您以強型別方式處理 OOXML 文件的內容。也就是說，您不必先解壓縮檔案以取得 XML、將 XML 載入 DOM 樹，然後直接操作 XML 元素與屬性，Open XML SDK 提供了相應的類別來完成這些工作。"

## **什麼是 Aspose.Slides？**
Aspose.Slides 是一個類別函式庫，讓應用程式可以執行以下簡報處理工作：

- 以簡報物件模型進行程式設計。
- 高品質的轉換，支援所有常見的 PowerPoint 簡報格式，並可轉換為 PDF、XPS、TIFF，且支援列印。
- 產生 PNG、JPEG、BMP 等常見格式的投影片縮圖，並支援投影片匯出為 SVG。
- 從頭建立簡報，或透過合併單一或多個文件的元素來建構簡報。
- 新增動畫、OLE 框、表格，建立與管理圖表。
- 在 TextFrames、Paragraph 以及 Portion 級別上進行廣泛的文字格式控制與管理。

如需了解可用功能的詳細資訊，請參閱 [Aspose.Slides Features](/slides/zh-hant/net/product-overview/) 頁面。

## **比較 Open XML SDK 與 Aspose.Slides**
此表格比較 Open XML SDK 與 Aspose.Slides 的功能與特性。

|**功能或功能類別**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|支援的簡報格式|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|從 PPT 轉換為 PPTX|No|Yes|
|<p>以簡報文件物件模型 (DOM) 進行高階程式設計：</p><p>- 文字搜尋與取代。</p><p>- 組合簡報中的投影片。</p>|No|Yes|
|以文件物件模型進行詳細程式設計；可存取個別元素與格式，如 TextHolders、TextFrames、Paragraphs 與 Portions。|Yes|Yes|
|低階直接且完整存取底層 XML 元素與屬性，如關係識別碼、OOXML 文件的清單識別碼。|Yes|No|
|<p>呈現與列印：</p><p>- 將簡報呈現為 PDF、PDF 附註、XPS、TIFF 影像。</p><p>- 將投影片縮圖呈現為 PNG、JPEG、BMP、SVG 與 TIFF。</p><p>- 指定影像解析度、品質、壓縮與其他選項。</p><p>- 使用 .NET 列印基礎架構列印簡報。元件內建列印方法，可依照 Microsoft PowerPoint 的列印預覽結果列印簡報。</p>|No|Yes|
|支援的平台|Windows, .NET|Windows, Linux, Java, .NET, Mono|

## **結論**
Open XML SDK 與 Aspose.Slides 並非直接競爭，因為它們針對的需求相差甚遠，且面向的使用者也不同。

{{% alert color="primary" %}} 

Open XML SDK 是一個提供強型別方式操作 OOXML 文件的類別函式庫，而 Aspose.Slides 是一個極具實用性的簡報處理函式庫，對幾乎所有 Microsoft PowerPoint 檔案格式皆提供完善支援。 

{{% /alert %}} 

如果您的工作流程僅是對 PPTX 文件執行基本程式操作，那麼 Open XML SDK 可能是合適的選擇。使用 Open XML SDK，您可以輕鬆完成產生簡易 PPTX 文件、移除批註、頁首/頁尾、擷取影像等簡單任務。某些任務只能透過 Open XML SDK 完成，而無法使用 Aspose.Slides。例如，若您需要直接存取 OOXML 文件的 XML 元素與屬性，則應使用 Open XML SDK。

若您需要在文件上執行複雜任務——例如下列清單中的工作——則 Aspose.Slides 是最佳選擇。

- 處理較舊的 PowerPoint 格式（以及 PPTX）。
- 在投影片內複製或克隆圖形，並以適當方式結合物件、樣式與其他格式元素。
- 取代已格式化或未格式化的文字。
- 套用動畫並使用連接線與圖形。
- 將文件轉換為 PDF、TIFF 或 XPS，使其呈現效果與 Microsoft PowerPoint 相同。
- 在桌面與 Web 環境中開發 .NET 或 Java 應用程式。