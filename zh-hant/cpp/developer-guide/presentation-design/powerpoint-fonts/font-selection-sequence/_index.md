---
title: Aspose.Slides for С++ 字型選擇順序
linktitle: 字型選擇
type: docs
weight: 80
url: /zh-hant/cpp/font-selection-sequence/
keywords:
- 字型選擇
- 字型取代
- 字型替換
- 取代規則
- 可用字型
- 缺少字型
- PowerPoint
- OpenDocument
- 簡報
- С++
- Aspose.Slides
description: "了解 Aspose.Slides for С++ 如何選擇字型，確保 PPT、PPTX 與 ODP 檔案的呈現清晰且一致──立即提升您的投影片。"
---
## **概述**

當載入、呈現或將簡報轉換為其他格式時，Aspose.Slides 會檢查簡報中使用的字型是否在作業系統中可用。如果缺少所需的字型，Aspose.Slides 會選擇一個與 PowerPoint 可能使用的字型盡可能接近的替代字型。

Aspose.Slides 會先在作業系統中搜尋所選的字型。如果找到該字型，則使用它；如果找不到，則套用適當的替代字型。當透過 `FontSubstRule` 定義字型替代規則時，這些規則也會被考慮在內。

您也可以在應用程式執行期間加入字型、使用簡報中的嵌入字型，或為輸出文件（如 PDF 檔案）載入外部字型。

## **字型選擇**

當簡報載入、呈現或轉換為其他格式時，會對字型套用特定規則。例如，當您嘗試將簡報（其投影片）轉換為圖像時，會檢查簡報的字型以確認所選字型在作業系統中可用。如果確認缺少字型，則會進行替換——請參閱[**Font Replacement**](https://docs.aspose.com/slides/zh-hant/cpp/font-replacement/)和[**Font Substitution**](https://docs.aspose.com/slides/zh-hant/cpp/font-substitution/)。

這是 Aspose.Slides 在處理字型時遵循的流程：

1. Aspose.Slides 會在作業系統中搜尋字型，以尋找符合簡報所選字型的字型。  
2. 如果找到所選字型，Aspose.Slides 會使用它；否則，Aspose.Slides 會使用一個盡可能接近 PowerPoint 所使用的替代字型。  
3. 如果透過[FontSubstRule](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsubstrule/) 設定了字型替換規則，則會套用這些規則。  

Aspose.Slides 允許您在應用程式執行期間加入字型，然後使用這些字型。請參閱[**Custom fonts**](https://docs.aspose.com/slides/zh-hant/cpp/custom-font/)。  

當額外的字型置於簡報內部時，稱為[**Embedded fonts**](https://docs.aspose.com/slides/zh-hant/cpp/embedded-font/)。  

Aspose.Slides 允許您加入僅套用於*輸出文件*的字型。例如，如果您要轉換為 PDF 的簡報中缺少系統與嵌入字型，您可以將所需的字型加入或載入為**external fonts**。  

{{% alert title="Note" color="primary" %}} 
我們不提供任何字型，無論是付費或免費。我們的 API 允許您載入外部字型並將其嵌入文件，但字型的使用完全取決於您自行判斷與負責。
{{% /alert %}}

## **常見問題**

**我該如何在轉換前確定簡報實際使用了哪些字型？**

Aspose.Slides 允許您透過[font manager](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/get_fontsmanager/) 檢查使用的字型，從而決定是否[embed](/slides/zh-hant/cpp/embedded-font/)、[replace](/slides/zh-hant/cpp/font-replacement/)或加入[external sources](/slides/zh-hant/cpp/custom-font/)。這可協助您防止在呈現與匯出過程中發生不必要的字型替換。

**我可以在不安裝到作業系統的情況下新增額外的字型目錄嗎？**

可以。您可以註冊[external font sources](/slides/zh-hant/cpp/custom-font/)（例如資料夾或記憶體串流）供呈現與匯出使用。這樣可消除對主機系統字型的依賴，並保持版面配置的可預測性。

**當缺少字形時，我該如何避免靜默地回退到不適當的字型？**

先事先定義明確的[font replacement](/slides/zh-hant/cpp/font-replacement/)以及字型[fallBack rules](/slides/zh-hant/cpp/fallback-font/)。透過分析使用的字型並為替代字型設定受控的優先順序，您即可確保排版的一致性，避免出現意外結果。