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
description: "瞭解為何 Aspose.Slides 比免費的 Open XML SDK 更佳選擇：比較功能、無自動化轉換，以及對 PPT、PPTX 與 ODP 的廣泛支援。"
---
## **概觀**

本文說明開發人員在何時可能會選擇 Open XML SDK 或 Aspose.Slides 來處理簡報文件。它將 Open XML SDK 描述為用於操作 OOXML 套件及其底層 XML 元素的函式庫，而 Aspose.Slides 則被呈現為具有高階物件模型並支援許多 PowerPoint 相關任務的簡報處理函式庫。

本文以支援的格式、程式模型、呈現與列印功能、平台支援以及常見使用情境比較兩者。亦說明 Open XML SDK 可能適用於基本的 PPTX 操作或直接存取 OOXML 元素，而 Aspose.Slides 則較適合處理複雜的簡報任務，例如使用多種 PowerPoint 格式、複製或克隆形狀、取代文字、套用動畫，以及將簡報轉換為 PDF、TIFF 或 XPS。

## **什麼是 Open XML SDK？**
有時，我們會收到這樣的問題：*為什麼要使用 Aspose 產品而不是免費的 Open XML SDK？* 

我們發現以功能與特性來回答這個問題相當容易。

根據 [MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk)，Open XML SDK 的定義如下：

> "The Open XML SDK 2.0 simplifies the task of manipulating Open XML packages and the underlying Open XML schema elements within a package. The Open XML SDK 2.0 encapsulates many common tasks that developers perform on Open XML packages, so that you can perform complex operations with just a few lines of code. OOXML documents are essentially zipped XML files and Open XML SDK is a collection of classes that allows you to work with the content of OOXML documents in a strongly-typed way. That is instead of unzipping a file to extract XML, loading that XML into a DOM tree, and working with XML elements and attributes directly, Open XML SDK provides classes to do that."

## **什麼是 Aspose.Slides？**
Aspose.Slides 是一個類別函式庫，允許應用程式執行以下簡報處理工作：

- 使用簡報物件模型進行程式設計。
- 高品質轉換，支援所有常見的 PowerPoint 簡報格式，包括轉換為 PDF、XPS、TIFF 以及列印。
- 產生 PNG、 JPEG、 BMP 等常見格式的投影片縮圖，同時支援投影片匯出為 SVG。
- 從頭建立簡報，或透過結合一或多個文件的元素來建立簡報。
- 加入動畫、OLE 框架、表格，建立與管理圖表。
- 在 TextFrames、段落 (Paragraph) 與文字區塊 (Portion) 層級上進行廣泛的文字格式控制與管理。

如需取得可用功能的更多細節，請參閱 [Aspose.Slides Features](/slides/zh-hant/net/product-overview/) 頁面。

## **比較 Open XML SDK 與 Aspose.Slides**
此表比較 Open XML SDK 與 Aspose.Slides 的功能與特性。

|**功能或功能類別**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|支援的簡報格式|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|從 PPT 轉換為 PPTX|否|是|
|<p>使用 Presentation Document Object Model (DOM) 的高階程式設計：</p><p>- 找尋與取代文字。</p><p>- 組合簡報中的投影片。</p>|否|是|
|使用文件物件模型的詳細程式設計；可存取單一元素與格式，如 TextHolders、TextFrames、Paragraphs 與 Portions。|是|是|
|低階直接且完整存取底層 XML 元素與屬性，例如關係識別碼、OOXML 文件的清單識別碼。|是|否|
|<p>呈現與列印：</p><p>- 將簡報呈現為 PDF、PDF Notes、XPS、TIFF 圖片。</p><p>- 將投影片縮圖呈現為 PNG、 JPEG、 BMP、 SVG 與 TIFF。</p><p>- 指定影像解析度、品質、壓縮與其他選項。</p><p>- 使用 .NET 列印基礎結構列印簡報。此元件內建列印方法，可依 MS PowerPoint 的列印預覽列印簡報。</p>|否|是|
|支援的平台|Windows, .NET|Windows, Linux, Java, .NET, Mono|

## **結論**
Open XML SDK 與 Aspose.Slides 並不直接競爭，因為它們解決的需求相當不同，且目標受眾也不同。

{{% alert color="info" %}} 
Open XML SDK 是一個提供強型別方式操作 OOXML 文件的類別函式庫，而 Aspose.Slides 是一個功能相當完善的簡報處理函式庫，對幾乎所有 Microsoft PowerPoint 檔案格式皆提供優秀的支援。 
{{% /alert %}} 

如果您的工作流程僅需在 PPTX 文件上執行基本的程式操作，則 Open XML SDK 可能是合適的選擇。使用 Open XML SDK，您應該能輕鬆完成產生簡單 PPTX 文件、移除註解、頁首/頁尾、擷取影像等簡單任務。有些任務只能透過 Open XML SDK 完成，且無法使用 Aspose.Slides。例如，若需要直接存取 OOXML 文件的 XML 元素與屬性，則應使用 Open XML SDK。

若需要在文件上執行複雜任務—例如以下清單中的工作—則 Aspose.Slides 是最佳選擇。

- 處理較舊的 PowerPoint 格式（以及 PPTX）。
- 在投影片中複製或克隆形狀，並以適當方式結合物件、樣式與其他格式元素。
- 取代已格式化或未格式化的文字。
- 套用動畫並使用連接線與形狀。
- 將文件轉換為 PDF、TIFF 或 XPS，使其呈現效果如同 Microsoft PowerPoint 轉換後的樣子。
- 在桌面與 Web 環境中開發 .NET 或 Java 應用程式。