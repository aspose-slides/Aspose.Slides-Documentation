---
title: 為什麼不選擇 Open XML SDK
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
description: "了解為什麼 Aspose.Slides 是比免費的 Open XML SDK 更好的選擇：比較功能、免自動化轉換以及對 PPT、PPTX 和 ODP 的廣泛支援。"
---
## **概觀**

本篇文章說明開發人員在何時可能會選擇 Open XML SDK 或 Aspose.Slides 來處理簡報文件。它將 Open XML SDK 描述為用於操作 OOXML 套件及其底層 XML 元素的函式庫，而 Aspose.Slides 則被呈現為具備高階物件模型並支援多種 PowerPoint 相關任務的簡報處理函式庫。

本文依照支援的格式、程式設計模型、呈現與列印功能、平台支援以及常見使用情境比較兩者。文章亦說明 Open XML SDK 可能適用於基本的 PPTX 操作或直接存取 OOXML 元素，而 Aspose.Slides 更適合進行複雜的簡報任務，例如處理多種 PowerPoint 格式、複製或克隆形狀、替換文字、套用動畫，以及將簡報轉換為 PDF、TIFF 或 XPS。

## **什麼是 Open XML SDK？**
有時，我們會收到這樣的問題：*為什麼要使用 Aspose 產品而不是免費的 Open XML SDK？*  

我們發現以功能和特性來回答這個問題相當簡單。  

根據 [MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk)，Open XML SDK 的定義如下：

> "Open XML SDK 2.0 簡化了操作 Open XML 套件及套件內底層 Open XML 架構元素的工作。Open XML SDK 2.0 封裝了開發人員在 Open XML 套件上執行的許多常見任務，使您只需幾行程式碼就能完成複雜操作。OOXML 文件本質上是已壓縮的 XML 檔案，Open XML SDK 是一組類別，允許您以強型別的方式操作 OOXML 文件的內容。也就是說，與其解壓縮檔案以取得 XML、將 XML 載入 DOM 樹，並直接操作 XML 元素與屬性，Open XML SDK 提供類別來完成這些工作。"

## **什麼是 Aspose.Slides？**
Aspose.Slides 是一個類別庫，允許應用程式執行以下簡報處理任務：

- 使用簡報物件模型進行程式設計。  
- 高品質的轉換，支援所有常見的 PowerPoint 簡報格式，包括轉換為 PDF、XPS、TIFF 以及列印。  
- 產生 PNG、JPEG、BMP 等常見格式的簡報縮圖，同時支援將簡報匯出為 SVG。  
- 從頭建立簡報或透過結合一個或多個文件的元素來建構簡報。  
- 新增動畫、OLE 框架、表格，建立與管理圖表。  
- 在 TextFrames、段落與 Portion 層級上全面控制與管理文字格式。  

欲了解更多可用功能，請參閱 [Aspose.Slides Features](/slides/zh-hant/net/product-overview/) 頁面。

## **比較 Open XML SDK 與 Aspose.Slides**
以下表格比較了 Open XML SDK 與 Aspose.Slides 的功能與特性。

|**功能或功能類別**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|支援的簡報格式|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|從 PPT 轉換為 PPTX|No|Yes|
|<p>使用簡報文件物件模型（DOM）的高階程式設計：</p><p>- 尋找並取代文字。</p><p>- 在簡報中組合投影片。</p>|No|Yes|
|使用文件物件模型的詳細程式設計；存取個別元素與格式，例如 TextHolders、TextFrames、段落與 Portion。|Yes|Yes|
|低階直接且完整存取底層 XML 元素與屬性，例如 OOXML 文件的關係識別碼、清單識別碼。|Yes|No|
|<p>呈現與列印：</p><p>- 將簡報渲染為 PDF、PDF 註釋、XPS、TIFF 影像。</p><p>- 將投影片縮圖渲染為 PNG、JPEG、BMP、SVG 與 TIFF。</p><p>- 指定影像解析度、品質、壓縮及其他選項。</p><p>- 使用 .NET 列印基礎結構列印簡報。此元件內建列印方法，可依 Microsoft PowerPoint 列印預覽的方式列印簡報。</p>|No|Yes|
|支援的平台|Windows, .NET|Windows, Linux, Java, .NET, Mono|

## **結論**
Open XML SDK 與 Aspose.Slides 並非直接競爭，因為它們針對的需求截然不同，且目標讀者也不同。

{{% alert color="primary" %}} 

Open XML SDK 是一個類別庫，提供以強型別方式處理 OOXML 文件的功能，而 Aspose.Slides 則是一個功能極為強大的簡報處理庫，對幾乎所有 Microsoft PowerPoint 檔案格式皆提供完善的支援。 

{{% /alert %}} 

如果您的工作流程僅是對 PPTX 文件執行基本的程式操作，那麼 Open XML SDK 可能是個不錯的選擇。使用 Open XML SDK，您可以輕鬆完成如產生簡單 PPTX 文件、移除註解、頁首/頁尾、擷取影像等簡單任務。某些任務可以透過 Open XML SDK 完成，但無法使用 Aspose.Slides 執行。例如，若您需要直接存取 OOXML 文件的 XML 元素與屬性，則應使用 Open XML SDK。  

如果您需要在文件上執行複雜任務—例如下列清單中的工作—則 Aspose.Slides 是您的最佳選擇。

- 涉及舊版 PowerPoint 格式（以及 PPTX）的操作。  
- 以適當的方式在投影片內複製或克隆形狀，並結合物件、樣式及其他格式元素。  
- 取代已格式化或未格式化的文字。  
- 套用動畫並在形狀間使用連接線。  
- 將文件轉換為 PDF、TIFF 或 XPS，使其呈現方式如同 Microsoft PowerPoint 進行轉換的結果。  
- 在桌面與 Web 環境中開發 .NET 或 Java 應用程式。