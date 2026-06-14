---
title: "Aspose.Slides for Python 中的字型選擇序列"
linktitle: "字型選擇"
type: docs
weight: 80
url: /zh-hant/python-net/font-selection-sequence/
keywords:
- "字型選擇"
- "字型替換"
- "字型取代"
- "替換規則"
- "可用字型"
- "缺失字型"
- "PowerPoint"
- "OpenDocument"
- "簡報"
- "Python"
- "Aspose.Slides"
description: "了解 Aspose.Slides for Python（透過 .NET）如何選擇字型，確保 PPT、PPTX 與 ODP 檔案的清晰、一致呈現——立即提升您的投影片。"
---
## **概覽**

當載入、算繪或轉換簡報為其他格式時，Aspose.Slides 會檢查簡報中使用的字型是否存在於作業系統中。若缺少必要的字型，Aspose.Slides 會選擇一個盡可能接近 PowerPoint 所使用的替代字型。

Aspose.Slides 會先在作業系統中搜尋所選的字型。若找到該字型，就直接使用；若未找到，則套用合適的替代字型。當透過 `FontSubstRule` 定義字型替換規則時，這些規則也會被考慮在內。

您也可以在應用程式執行時加入字型、使用簡報內嵌的字型，或為 PDF 等輸出文件載入外部字型。

## **字型選擇**

在載入、算繪或轉換簡報為其他格式時，簡報中的字型會受到特定規則的影響。例如，當您嘗試將簡報（其投影片）轉換為影像時，系統會檢查簡報的字型，確認所選字型是否存在於作業系統中。若字型確實缺失，則會被取代 — 參見[**字型取代**](https://docs.aspose.com/slides/zh-hant/python-net/font-replacement/)和[**字型替換**](https://docs.aspose.com/slides/zh-hant/python-net/font-substitution/)。

以下是 Aspose.Slides 處理字型時的流程：

1. Aspose.Slides 會在作業系統中搜尋字型，以找到與簡報所選字型相符的字型。 
2. 若找到所選字型，Aspose.Slides 會使用它；否則，Aspose.Slides 會使用一個盡可能接近 PowerPoint 所使用的替代字型。 
3. 若已透過 [FontSubstRule](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fontsubstrule/) 設定字型取代規則，則會套用這些規則。 

Aspose.Slides 允許您在應用程式執行期間加入字型，然後使用這些字型。請參閱[**自訂字型**](https://docs.aspose.com/slides/zh-hant/python-net/custom-font/)。 

當在簡報中加入其他字型時，這些字型稱為[**內嵌字型**](https://docs.aspose.com/slides/zh-hant/python-net/embedded-font/)。

Aspose.Slides 允許您加入僅套用於*輸出文件*的字型。例如，若您要轉換為 PDF 的簡報缺少系統及內嵌字型，您可以將所需的字型新增或載入為**外部字型**。 

{{% alert title="注意" color="primary" %}} 
我們不提供任何字型的發行，無論是付費或免費。我們的 API 允許您載入外部字型並將其嵌入文件，但您必須自行斟酌與負責所使用的字型。 
{{% /alert %}}

## **常見問題**

**如何在轉換前判斷簡報實際使用了哪些字型？**

Aspose.Slides 讓您透過[font manager](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/fonts_manager/) 檢查使用的字型，從而決定是要[嵌入](/slides/zh-hant/python-net/embedded-font/)、[取代](/slides/zh-hant/python-net/font-replacement/)或新增[外部來源](/slides/zh-hant/python-net/custom-font/)。這有助於在算繪與匯出過程中防止不需要的字型替換。

**我能在不安裝至作業系統的情況下新增額外的字型目錄嗎？**

可以。您可以註冊[外部字型來源](/slides/zh-hant/python-net/custom-font/)（例如資料夾或記憶體串流）以供算繪與匯出使用。這樣可消除對主機系統字型的依賴，並保持版面配置的可預測性。

**當字形缺失時，我該如何防止悄悄回退到不適當的字型？**

請事先定義明確的[字型取代](/slides/zh-hant/python-net/font-replacement/)與字型[回退規則](/slides/zh-hant/python-net/fallback-font/)。透過分析使用的字型並為替代字型設定受控的優先順序，您即可確保排版一致性，避免意外結果。