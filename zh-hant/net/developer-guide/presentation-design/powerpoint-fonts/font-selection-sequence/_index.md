---
title: 字型選取序列於 Aspose.Slides for .NET
linktitle: 字型選取
type: docs
weight: 80
url: /zh-hant/net/font-selection-sequence/
keywords:
- 字型選取
- 字型取代
- 字型替換
- 取代規則
- 可用字型
- 缺少字型
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "了解 Aspose.Slides for .NET 如何選取字型，確保 PPT、PPTX 與 ODP 檔案的呈現清晰一致—立即改善您的投影片。"
---
## **概述**

當載入、呈現或將簡報轉換為其他格式時，Aspose.Slides 會檢查簡報中使用的字型是否在作業系統中可用。如果缺少必要的字型，Aspose.Slides 會選擇一個盡可能接近 PowerPoint 會使用的替代字型。

Aspose.Slides 會先在作業系統中搜尋所選的字型。如果找到，則直接使用；如果找不到，則套用適當的替代字型。若透過 `FontSubstRule` 定義了字型替換規則，亦會將這些規則納入考量。

您也可以在應用程式執行時加入字型、使用簡報中嵌入的字型，或為 PDF 等輸出文件載入外部字型。

## **字型選取**

當簡報被載入、呈現或轉換為其他格式時，會套用特定規則於簡報中的字型。例如，當您嘗試將簡報（投影片）轉換為影像時，會檢查簡報的字型是否在作業系統中可用。如確認缺少字型，則會進行替換——請參閱[**字型替換**](https://docs.aspose.com/slides/zh-hant/net/font-replacement/)與[**字型取代**](https://docs.aspose.com/slides/zh-hant/net/font-substitution/)。

以下是 Aspose.Slides 在處理字型時的流程：

1. Aspose.Slides 會在作業系統中搜尋與簡報所選字型相符的字型。  
2. 若找到所選字型，則使用之；否則使用盡可能接近 PowerPoint 會使用的替代字型。  
3. 若透過[FontSubstRule](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontsubstrule/)設定了字型替換規則，則套用這些規則。  

Aspose.Slides 允許您在應用程式執行時加入字型，然後使用這些字型。請參閱[**自訂字型**](https://docs.aspose.com/slides/zh-hant/net/custom-font/)。  

當在簡報中放置額外字型時，稱為[**嵌入字型**](https://docs.aspose.com/slides/zh-hant/net/embedded-font/)。  

Aspose.Slides 允許您加入僅套用於輸出文件的字型。例如，若您要將簡報轉換為 PDF，但系統及嵌入的字型皆缺少所需字型，您可以將所需字型加入或載入為**外部字型**。

{{% alert title="Note" color="info" %}} 
我們不會分發任何字型，無論是付費或免費。Our API 允許您載入外部字型並將其嵌入文件，但字型的使用須自行斟酌並自行負責。
{{% /alert %}}

## **常見問題**

### 如何在轉換之前判斷簡報實際使用了哪些字型？

Aspose.Slides 讓您透過[字型管理員](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/fontsmanager/)檢查所使用的字型，您可以決定是否[嵌入](/slides/zh-hant/net/embedded-font/)、[替換](/slides/zh-hant/net/font-replacement/)或加入[外部來源](/slides/zh-hant/net/custom-font/)。此功能可協助您避免在呈現與匯出過程中產生不必要的字型取代。

### 是否能在不安裝到作業系統的情況下，新增額外的字型目錄？

可以。您可以註冊[外部字型來源](/slides/zh-hant/net/custom-font/)（如資料夾或記憶體串流）供呈現與匯出使用。這樣即可避免依賴主機系統的字型，並保持版面配置的可預測性。

### 如何防止在缺少字形時靜默回退到不合適的字型？

事先定義明確的[字型替換](/slides/zh-hant/net/font-replacement/)與字型[回退規則](/slides/zh-hant/net/fallback-font/)。透過分析使用的字型並設定受控的替代優先順序，您可以確保排版一致，避免出現意外結果。