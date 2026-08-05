---
title: Aspose.Slides for C++ 的字型選擇順序
linktitle: 字型選擇
type: docs
weight: 80
url: /zh-hant/cpp/font-selection-sequence/
keywords:
- 字型選擇
- 字型替代
- 字型取代
- 替代規則
- 可用字型
- 缺失字型
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "探索 Aspose.Slides for C++ 如何選取字型，確保 PPT、PPTX 與 ODP 檔案的呈現清晰一致——立即提升您的簡報。"
---
## **概述**

當投影片載入、呈現或轉換為其他格式時，Aspose.Slides 會檢查投影片中使用的字型是否在作業系統中可用。如果缺少必要的字型，Aspose.Slides 會選擇一個儘可能接近 PowerPoint 所使用的替代字型。

Aspose.Slides 會先在作業系統中搜尋所選字型。若找到，則直接使用；若找不到，則套用適當的替代字型。若透過 `FontSubstRule` 定義了字型替代規則，這些規則也會被考慮。

您亦可在應用程式執行期間加入字型、使用投影片內嵌的字型，或為輸出文件（例如 PDF）載入外部字型。

## **字型選擇**

在投影片載入、呈現或轉換為其他格式時，會對投影片中的字型套用特定規則。例如，當您嘗試將投影片（其投影片）轉換為影像時，系統會檢查投影片的字型是否在作業系統中可用。若確認缺少字型，則會進行取代——請參閱[**字型取代**](https://docs.aspose.com/slides/zh-hant/cpp/font-replacement/)與[**字型替代**](https://docs.aspose.com/slides/zh-hant/cpp/font-substitution/)。

以下是 Aspose.Slides 處理字型的流程：

1. Aspose.Slides 會在作業系統中搜尋與投影片所選字型相符的字型。  
2. 若找到所選字型，Aspose.Slides 會使用它；否則，Aspose.Slides 會使用一個儘可能接近 PowerPoint 所使用的替代字型。  
3. 若透過[FontSubstRule](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsubstrule/) 設定了字型取代規則，則會套用這些規則。  

Aspose.Slides 允許您在應用程式執行期間加入字型，然後使用這些字型。請參閱[**自訂字型**](https://docs.aspose.com/slides/zh-hant/cpp/custom-font/)。  

當額外字型被放入投影片中時，稱為[**內嵌字型**](https://docs.aspose.com/slides/zh-hant/cpp/embedded-font/)。  

Aspose.Slides 允許您加入僅套用於輸出文件的字型。例如，若您欲將投影片轉換為 PDF，而該投影片使用的字型在您的系統及內嵌字型中皆不存在，您可以將所需的字型加入或載入為**外部字型**。

{{% alert title="Note" color="primary" %}} 
我們不提供任何字型（無論是付費或免費）。我們的 API 允許您載入外部字型並將其嵌入文件，使用者需自行負責取得及使用字型。
{{% /alert %}}

## **常見問題**

**如何在轉換前判斷投影片實際使用了哪些字型？**

Aspose.Slides 讓您透過[字型管理員](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/get_fontsmanager/)檢查使用的字型，從而決定是否[嵌入](/slides/zh-hant/cpp/embedded-font/)、[取代](/slides/zh-hant/cpp/font-replacement/)或加入[外部來源](/slides/zh-hant/cpp/custom-font/)。這有助於避免在呈現與匯出過程中發生不希望的字型替代。

**我可以在不安裝字型到作業系統的情況下加入額外的字型目錄嗎？**

可以。您可以註冊[外部字型來源](/slides/zh-hant/cpp/custom-font/)（例如資料夾或記憶體串流）供呈現與匯出使用。這樣可減少對主機系統字型的依賴，確保版面配置可預測。

**如何防止在缺少字形時靜默回退到不適當的字型？**

事先定義明確的[字型取代](/slides/zh-hant/cpp/font-replacement/)與字型[回退規則](/slides/zh-hant/cpp/fallback-font/)。透過分析已使用的字型並設定受控的替代優先順序，您可以確保排版一致，避免意外結果。