---
title: Aspose.Slides for Java 中的字型選取序列
linktitle: 字型選取
type: docs
weight: 80
url: /zh-hant/java/font-selection-sequence/
keywords:
- 字型選取
- 字型替換
- 字型取代
- 替換規則
- 可用字型
- 缺失字型
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "探索 Aspose.Slides for Java 如何選取字型，確保 PPT、PPTX 與 ODP 檔案的清晰、一致簡報——立即提升您的投影片。"
---
## **概觀**

當載入、呈現或轉換投影片為其他格式時，Aspose.Slides 會檢查投影片中使用的字型是否在作業系統中可用。若缺少必要的字型，Aspose.Slides 會選擇一個盡可能與 PowerPoint 所使用的字型相近的替代字型。

Aspose.Slides 會先在作業系統中搜尋所選字型。若找到則直接使用；若未找到，則套用適當的替代字型。若透過 `FontSubstRule` 定義了字型替換規則，這些規則也會被考慮。

您亦可在應用程式執行期間加入字型、使用投影片中內嵌的字型，或為輸出文件（如 PDF）載入外部字型。

## **字型選取**

在載入、呈現或轉換投影片為其他格式時，投影片中的字型會套用特定規則。例如，當您嘗試將投影片（其投影片）轉換為影像時，會檢查投影片的字型是否在作業系統中可用。若確認缺少字型，則會進行取代 ——請參閱[**字型取代**](https://docs.aspose.com/slides/zh-hant/java/font-replacement/)和[**字型替換**](https://docs.aspose.com/slides/zh-hant/java/font-substitution/)。

Aspose.Slides 處理字型的流程如下：

1. Aspose.Slides 會在作業系統中搜尋與投影片所選字型相符的字型。  
2. 若找到所選字型，Aspose.Slides 直接使用；否則，會使用盡可能接近 PowerPoint 會使用的替代字型。  
3. 若已透過[FontSubstRule](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fontsubstrule/) 設定字型取代規則，則會套用這些規則。

Aspose.Slides 允許您在應用程式執行期間加入字型，然後使用這些字型。請參閱[**自訂字型**](https://docs.aspose.com/slides/zh-hant/java/custom-font/)。

當額外字型放入投影片中時，稱為[**內嵌字型**](https://docs.aspose.com/slides/zh-hant/java/embedded-font/)。

Aspose.Slides 允許您加入僅套用於*輸出文件*的字型。例如，若您要將投影片轉換為 PDF，且該投影片缺少系統與內嵌字型，您可將所需字型加入或載入為**外部字型**。

{{% alert title="Note" color="primary" %}} 
我們不提供任何字型（無論是付費或免費）。我們的 API 允許您載入外部字型並將其嵌入文件，但字型的使用須由您自行決定並自行負責。
{{% /alert %}}

## **常見問題**

**如何在轉換前判斷投影片實際使用了哪些字型？**

Aspose.Slides 讓您透過[字型管理員](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fontsmanager/)檢查使用的字型，從而決定是否[**嵌入**](/slides/zh-hant/java/embedded-font/)、[**取代**](/slides/zh-hant/java/font-replacement/)或加入[**外部來源**](/slides/zh-hant/java/custom-font/)。此功能可協助您在呈現與匯出時防止不必要的字型替換。

**我可以在不將字型安裝到作業系統的情況下新增額外的字型目錄嗎？**

可以。您可以註冊[外部字型來源](/slides/zh-hant/java/custom-font/)（例如資料夾或記憶體串流）供呈現與匯出使用。這樣可消除對主機系統字型的依賴，保持版面配置的可預測性。

**如何避免在缺少字形時靜默回退到不合適的字型？**

事先定義明確的[字型取代](/slides/zh-hant/java/font-replacement/)與字型[回退規則](/slides/zh-hant/java/fallback-font/)。透過分析使用的字型並設定受控的替代優先順序，您可以確保排版一致，避免意外結果。