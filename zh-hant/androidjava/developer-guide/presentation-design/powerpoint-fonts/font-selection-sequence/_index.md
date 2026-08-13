---
title: Aspose.Slides for Android (Java) 中的字型選擇順序
linktitle: 字型選擇
type: docs
weight: 80
url: /zh-hant/androidjava/font-selection-sequence/
keywords:
- 字型選擇
- 字型替換
- 字型取代
- 替換規則
- 可用字型
- 缺少字型
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "探索 Aspose.Slides for Android (Java) 如何選擇字型，確保 PPT、PPTX 與 ODP 檔案的清晰一致呈現，立即提升您的簡報。"
---
## **概觀**

載入、呈現或轉換為其他格式時，Aspose.Slides 會檢查簡報中使用的字型是否存在於作業系統中。如果缺少必需的字型，Aspose.Slides 會選擇一個盡可能接近 PowerPoint 所使用的替代字型。

Aspose.Slides 會首先在作業系統中搜尋所選的字型。若找到該字型，則直接使用；若未找到，則套用適當的替代字型。當透過 `FontSubstRule` 定義字型替換規則時，也會將這些規則納入考量。

您也可以在應用程式執行時加入字型、使用簡報中嵌入的字型，或為 PDF 等輸出文件載入外部字型。

## **字型選擇**

當簡報載入、呈現或轉換為其他格式時，會套用特定的字型規則。例如，將簡報（其投影片）轉換為圖片時，會檢查簡報的字型是否在作業系統中可用。若確認缺少字型，則會進行替換──請參閱 [**字型取代**](https://docs.aspose.com/slides/zh-hant/androidjava/font-replacement/) 與 [**字型替換**](https://docs.aspose.com/slides/zh-hant/androidjava/font-substitution/)。

以下是 Aspose.Slides 處理字型時的流程：

1. Aspose.Slides 會在作業系統中搜尋字型，以尋找與簡報所選字型相符的字型。 
2. 若找到所選字型，Aspose.Slides 會直接使用；否則，Aspose.Slides 會使用一個盡可能接近 PowerPoint 所使用的替代字型。 
3. 若已透過 [FontSubstRule](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fontsubstrule/) 設定字型替換規則，則會套用這些規則。

Aspose.Slides 允許您在應用程式執行時加入字型，然後使用這些字型。請參閱 [**自訂字型**](https://docs.aspose.com/slides/zh-hant/androidjava/custom-font/)。

當在簡報中放入額外字型時，這些字型稱為 [**嵌入字型**](https://docs.aspose.com/slides/zh-hant/androidjava/embedded-font/)。

Aspose.Slides 允許您加入僅套用於輸出文件的字型。例如，若您想將簡報轉換為 PDF 時，簡報中包含系統與嵌入字型缺失的字型，您可以將所需的字型加入或載入為 **外部字型**。 

{{% alert title="Note" color="info" %}} 
我們不分發任何字型，無論是付費或免費。我們的 API 允許您載入外部字型並將其嵌入文件，但字型的使用需由您自行決定並自行負責。 
{{% /alert %}}

## **常見問題**

### 如何在轉換前確定簡報實際使用了哪些字型？

Aspose.Slides 讓您透過 [字型管理員](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fontsmanager/) 檢查使用的字型，從而決定是否要 [嵌入](/slides/zh-hant/androidjava/embedded-font/)、[取代](/slides/zh-hant/androidjava/font-replacement/) 或加入 [外部來源](/slides/zh-hant/androidjava/custom-font/)。此功能可協助您在呈現與匯出過程中避免不必要的字型替換。

### 是否能在不安裝於作業系統的情況下新增額外的字型目錄？

可以。您可以註冊 [外部字型來源](/slides/zh-hant/androidjava/custom-font/)（如資料夾或記憶體串流）以供呈現與匯出使用。此方式可消除對主機系統字型的依賴，保持版面配置的可預測性。

### 如何防止在缺少字形時悶聲回退至不適當的字型？

先行定義明確的 [字型取代](/slides/zh-hant/androidjava/font-replacement/) 與字型 [回退規則](/slides/zh-hant/androidjava/fallback-font/)。透過分析使用的字型並設定可控的替代優先順序，您可確保字體排版的一致性，避免意外結果。