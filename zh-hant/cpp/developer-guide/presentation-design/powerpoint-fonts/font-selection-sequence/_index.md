---
title: Aspose.Slides for C++ 中的字型選擇順序
linktitle: 字型選擇
type: docs
weight: 80
url: /zh-hant/cpp/font-selection-sequence/
keywords:
- 字型選擇
- 字型替換
- 字型取代
- 替換規則
- 可用字型
- 缺失字型
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "了解 Aspose.Slides for C++ 如何選擇字型，確保 PPT、PPTX 與 ODP 檔案的簡報呈現清晰且一致 — 立即提升您的投影片。"
---
## **概觀**

當簡報被載入、呈現或轉換為其他格式時，Aspose.Slides 會檢查簡報中使用的字型是否在作業系統中可用。若所需字型缺失，Aspose.Slides 會選擇一個盡可能接近 PowerPoint 會使用的替代字型。

Aspose.Slides 會先在作業系統中搜尋選取的字型。若找到該字型，則直接使用；若未找到，則套用合適的替代字型。當透過 `FontSubstRule` 定義字型替換規則時，這些規則也會被考慮在內。

您也可以在應用程式執行期間加入字型、使用簡報內嵌的字型，或為 PDF 等輸出文件載入外部字型。

## **字型選擇**

當簡報被載入、呈現或轉換為其他格式時，簡報中的字型會套用特定規則。例如，當您嘗試將簡報（其投影片）轉換為影像時，會檢查簡報的字型以確認所選字型在作業系統中是否可用。若確認字型缺失，則會被取代 ─ 參見[**字型取代**](https://docs.aspose.com/slides/zh-hant/cpp/font-replacement/)與[**字型替換**](https://docs.aspose.com/slides/zh-hant/cpp/font-substitution/)。

以下是 Aspose.Slides 處理字型時的流程：

1. Aspose.Slides 會在作業系統中搜尋字型，以找出與簡報所選字型相匹配的字型。 
2. 若找到所選字型，Aspose.Slides 會使用它；否則，Aspose.Slides 會使用一個盡可能接近 PowerPoint 所使用的替代字型。 
3. 若透過[FontSubstRule](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsubstrule/)設定了字型取代規則，則會套用這些規則。 

Aspose.Slides 允許您在應用程式執行期間加入字型，然後使用這些字型。參見[**自訂字型**](https://docs.aspose.com/slides/zh-hant/cpp/custom-font/)。 

當額外字型嵌入於簡報內時，稱為[**內嵌字型**](https://docs.aspose.com/slides/zh-hant/cpp/embedded-font/)。 

Aspose.Slides 允許您加入僅套用於*輸出文件*的字型。例如，若您欲轉換為 PDF 的簡報包含系統及內嵌字型缺失的字型，您可以將所需字型加入或載入為**外部字型**。 

{{% alert title="Note" color="info" %}} 
我們不提供任何字型，無論是付費或免費。我們的 API 允許您載入外部字型並將其嵌入文件，但使用字型的決定與責任由您自行承擔。 
{{% /alert %}}

## **常見問題**

### 如何在轉換前確定簡報實際使用了哪些字型？

Aspose.Slides 讓您透過[字型管理員](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/get_fontsmanager/)檢查使用的字型，進而決定是[嵌入](/slides/zh-hant/cpp/embedded-font/)、[取代](/slides/zh-hant/cpp/font-replacement/)或新增[外部來源](/slides/zh-hant/cpp/custom-font/)。此功能可協助您避免在呈現與匯出時發生不希望的字型替換。

### 我能否在不將字型安裝至作業系統的情況下，新增額外的字型目錄？

可以。您可以註冊[外部字型來源](/slides/zh-hant/cpp/custom-font/)，例如資料夾或記憶體串流，以供呈現與匯出使用。此方式可消除對主機系統字型的依賴，並確保版面配置可預測。

### 如何防止在缺少字形時靜默回退到不適合的字型？

事先定義明確的[字型取代](/slides/zh-hant/cpp/font-replacement/)與字型[回退規則](/slides/zh-hant/cpp/fallback-font/)。透過分析使用的字型並設定受控的替代優先順序，您可以確保排版一致，避免意外結果。