---
title: 為何不使用 Open XML SDK
type: docs
weight: 100
url: /zh-hant/cpp/why-not-open-xml-sdk/
keywords:
- Open XML SDK
- 比較
- 簡報物件模型
- 高品質轉換
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "了解為何 Aspose.Slides 比免費的 Open XML SDK 更適合：比較功能、免自動化轉換，以及對 PPT、PPTX 和 ODP 的廣泛支援。"
---
## **概觀**

本文說明開發人員在何時可能會選擇 Open XML SDK 或 Aspose.Slides 來處理簡報文件。它將 Open XML SDK 描述為用於操作 OOXML 套件及其底層 XML 元素的函式庫，而 Aspose.Slides 則被呈現為具備高階物件模型且支援多種 PowerPoint 相關任務的簡報處理函式庫。

本文依照支援的格式、程式設計模型、渲染與列印功能、平台支援以及常見使用情境比較兩者。亦說明 Open XML SDK 可能適用於基本的 PPTX 操作或直接存取 OOXML 元素，而 Aspose.Slides 則更適合處理複雜的簡報任務，例如使用多種 PowerPoint 格式、複製或克隆圖形、取代文字、套用動畫，以及將簡報轉換為 PDF、TIFF 或 XPS。

## **什麼是 Open XML SDK？**

我們時常聽到這個問題：為何要使用 Aspose 產品而不是免費的 Open XML SDK？這個問題很容易回答：功能與特性。根據[MSDN 資料庫](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk)，Open XML SDK 的定義如下：Open XML SDK 2.0 簡化了操作 Open XML 套件以及套件內底層 Open XML 結構元素的工作。Open XML SDK 2.0 封裝了許多開發人員在 Open XML 套件上執行的常見任務，讓您只需少量程式碼即可完成複雜操作。OOXML 文件本質上是壓縮的 XML 檔案，而 Open XML SDK 是一組類別，允許您以強型別方式處理 OOXML 文件的內容。也就是說，您不必先解壓縮檔案以提取 XML、將 XML 載入 DOM 樹並直接操作 XML 元素與屬性，Open XML SDK 提供了相應的類別來完成這些工作。

## **什麼是 Aspose.Slides？**

Aspose.Slides 是一個類別函式庫，讓您的應用程式能執行以下簡報處理任務：

- 使用 **Presentation** 物件模型進行程式設計。
- 在所有支援的流行 PowerPoint 簡報格式之間進行高品質轉換，包括轉換為 PDF 與 XPS。
- 能夠以 PNG、JPEG、BMP 等常見格式產生投影片縮圖，並將投影片匯出為 SVG。
- 能夠從頭建立簡報或透過結合一個或多個文件來建構簡報。
- 支援加入動畫、Ole 框架、表格以及建立與管理圖表。
- 提供廣泛的控制，管理 TextFrames、段落與 Portion 級別的文字格式。
- 欲了解更多支援的功能細節，請造訪 [Aspose.Slides 功能](/slides/zh-hant/cpp/product-overview/)。

## **比較 Open XML SDK 與 Aspose.Slides**

|**功能或功能類別**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|支援的簡報格式|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|從 PPT 轉換為 PPTX|No|Yes|
|<p>使用 Presentation Document Object Model (DOM) 的高階程式設計：</p><p>- 尋找與取代文字。</p><p>- 組合簡報中的投影片。</p>|No|Yes|
|使用文件物件模型進行詳細程式設計，存取個別元素與格式，例如 TextHolders、TextFrames、Paragraphs 與 Portions。|Yes|Yes|
|對底層 XML 元素與屬性（例如關係識別碼、OOXML 文件的清單識別碼）進行低階直接且完整的存取。|Yes|No|
|<p>呈現：</p><p>- 將簡報渲染為 PDF、PDF 註釋、XPS、TIFF 圖像。</p><p>- 將投影片縮圖渲染為 PNG、JPEG、BMP、SVG 與 TIFF。</p><p>- 指定圖像解析度、品質、壓縮以及其他選項。</p>|No|Yes|

## **結論**

Open XML SDK 與 Aspose.Slides 並非直接競爭，因為它們針對的需求與受眾相當不同。Open XML SDK 是一個類別函式庫，提供以強型別方式操作 OOXML 文件的功能。Aspose.Slides 是一個非常實用的簡報處理函式庫，對幾乎所有 Microsoft PowerPoint 檔案格式皆提供完善的支援。如果您只需要對 PPTX 文件執行相對簡單的程式操作，Open XML SDK 可能是一個合適的選擇。使用 Open XML SDK，您可以輕鬆完成產生簡易 PPTX 文件、移除註解、頁首/頁尾、擷取影像等簡單任務。有些工作可以透過 Open XML SDK 完成，但無法以 Aspose.Slides 完成。例如，若需直接存取 OOXML 文件的 XML 元素與屬性，應使用 Open XML SDK。然而，若需對文件執行複雜操作，例如以下任務，則使用 Aspose.Slides 為最佳選擇：

- 支援除 PPTX 之外的舊版 PowerPoint 格式。
- 在投影片內複製或克隆圖形，並以適當方式結合物件、樣式與其他格式設定。
- 取代已格式化或未格式化的文字。
- 套用動畫並使用圖形的連接線。
- 將文件轉換為 PDF 或 XPS，使其外觀與 Microsoft PowerPoint 轉換結果完全相同。
- 在桌面與主控台環境中開發 C++ 應用程式。