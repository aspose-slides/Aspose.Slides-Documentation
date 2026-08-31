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
description: "了解為何 Aspose.Slides 是比免費的 Open XML SDK 更好的選擇：比較功能、免自動化轉換，以及對 PPT、PPTX 與 ODP 的廣泛支援。"
---
## **概觀**

本文說明開發人員在處理簡報文件時，何時會選擇 Open XML SDK 或 Aspose.Slides。它將 Open XML SDK 描述為一個用於操作 OOXML 套件及其底層 XML 元素的函式庫，而 Aspose.Slides 則被呈現為具備高階物件模型且支援眾多 PowerPoint 相關任務的簡報處理函式庫。

本文依支援的格式、程式模型、渲染、平台支援與常見使用情境比較兩者。亦說明 Open XML SDK 可能適用於基本的 PPTX 操作或直接存取 OOXML 元素，而 Aspose.Slides 則更適合處理複雜的簡報工作，如支援多種 PowerPoint 格式、複製或克隆圖形、取代文字、套用動畫，以及將簡報轉換為 PDF、TIFF 或 XPS。

## **什麼是 Open XML SDK？**
我們常聽到這個問題：為何要使用 Aspose 產品而不是免費的 Open XML SDK？這個問題很容易回答：功能與特性。依據[MSDN 程式庫](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk)的說明，Open XML SDK 定義為：Open XML SDK 2.0 簡化了操作 Open XML 套件及套件內部 Open XML 架構元素的工作。Open XML SDK 2.0 封裝了開發人員在 Open XML 套件上常執行的許多任務，讓您只需幾行程式碼即可完成複雜操作。OOXML 文件本質上是壓縮的 XML 檔案，而 Open XML SDK 則是一套類別，讓您以強型別方式處理 OOXML 文件的內容。換句話說，與其先解壓縮檔案以取得 XML、再將 XML 載入 DOM 樹並直接操作 XML 元素與屬性，Open XML SDK 提供了相應的類別來完成這些工作。

## **什麼是 Aspose.Slides？**
Aspose.Slides 是一個類別函式庫，讓您的應用程式能執行以下簡報處理任務：

- 使用 **Presentation** 物件模型進行程式設計。  
- 在所有常見支援的 PowerPoint 簡報格式之間進行高品質轉換，包含轉換為 PDF 與 XPS。  
- 能以 PNG、JPEG、BMP 等常見格式產生投影片縮圖，並支援投影片匯出為 SVG。  
- 能從頭建立簡報，或透過結合一個或多個文件來建構簡報。  
- 支援新增動畫、Ole 框架、表格、建立與管理圖表。  
- 提供廣泛的控制，讓您在 TextFrames、段落與 Portion 層級上管理文字格式。  

欲了解支援的功能細節，請參閱[Aspose.Slides 功能](/slides/zh-hant/cpp/product-overview/)。

## **比較 Open XML SDK 與 Aspose.Slides**
下表比較了 Open XML SDK 與 Aspose.Slides 的功能。

|**功能或功能類別**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|支援的簡報格式|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|從 PPT 轉換為 PPTX|否|是|
|<p>使用簡報文件物件模型（DOM）的高階程式設計：</p><p>- 文字的搜尋與取代。</p><p>- 在簡報中組合投影片。</p>|否|是|
|使用文件物件模型的詳細程式設計，可存取個別元素與格式，如 TextHolders、TextFrames、段落與 Portion。|是|是|
|低階直接且完整存取底層 XML 元素與屬性，例如關係識別碼、OOXML 文件的清單識別碼。|是|否|
|<p>渲染：</p><p>- 將簡報渲染為 PDF、PDF 註釋、XPS、TIFF 圖片。</p><p>- 將投影片縮圖渲染為 PNG、JPEG、BMP、SVG 與 TIFF。</p><p>- 指定影像解析度、品質、壓縮及其他選項。</p>|否|是|

## **結論**
Open XML SDK 與 Aspose.Slides 並非直接競爭的產品，因為它們針對的需求與受眾截然不同。Open XML SDK 是一個提供強型別方式操作 OOXML 文件的類別函式庫。Aspose.Slides 則是一個非常實用的簡報處理函式庫，對幾乎所有 Microsoft PowerPoint 檔案格式皆提供完善支援。如果您只需要對 PPTX 文件執行相當基礎的程式操作，Open XML SDK 可能是合適的選擇。使用 Open XML SDK，您能輕鬆完成產生簡易 PPTX 文件、移除註解、頁首/頁尾、擷取圖片等簡單任務。某些工作可以透過 Open XML SDK 完成，但在 Aspose.Slides 中無法實作。例如，若您需要直接存取 OOXML 文件的 XML 元素與屬性，應使用 Open XML SDK。然而，若您需要在文件上執行複雜操作，如以下任務，則 Aspose.Slides 為最佳選擇：

- 支援除 PPTX 之外的舊版 PowerPoint 格式。  
- 以適當方式複製或克隆投影片內的圖形，並保留物件、樣式與其他格式。  
- 取代已格式化或未格式化的文字。  
- 套用動畫與使用圖形連接器。  
- 將文件轉換為 PDF 或 XPS，使其外觀與 Microsoft PowerPoint 轉換結果完全相同。  
- 在桌面與主控台環境下開發 C++ 應用程式。