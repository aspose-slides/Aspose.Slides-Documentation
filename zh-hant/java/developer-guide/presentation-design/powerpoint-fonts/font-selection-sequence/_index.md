---
title: 在 Aspose.Slides for Java 中的字型選擇順序
linktitle: 字型選擇
type: docs
weight: 80
url: /zh-hant/java/font-selection-sequence/
keywords:
- 字型選擇
- 字型替代
- 字型取代
- 替代規則
- 可用字型
- 缺少字型
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "探索 Aspose.Slides for Java 如何選擇字型，確保 PPT、PPTX 與 ODP 檔案呈現清晰一致——立即提升您的投影片。"
---
## **概觀**

當載入、呈現或轉換簡報為其他格式時，Aspose.Slides 會檢查簡報中使用的字型是否在作業系統中可用。若缺少所需字型，Aspose.Slides 會選擇一個盡可能接近 PowerPoint 所使用的替代字型。

Aspose.Slides 會先在作業系統中搜尋選定的字型。若找到，則使用該字型；若找不到，則套用合適的替代字型。若透過 `FontSubstRule` 定義了字型替換規則，亦會考慮這些規則。

您也可以在應用程式執行期間加入字型、使用簡報中嵌入的字型，或為輸出文件（例如 PDF）載入外部字型。

## **字型選擇**

在載入、呈現或轉換簡報為其他格式時，會對簡報中的字型套用特定規則。例如，當您嘗試將簡報（其投影片）轉為影像時，會檢查簡報的字型是否在作業系統中可用。若確認字型缺失，則會替換——請參閱[**字型取代**](https://docs.aspose.com/slides/zh-hant/java/font-replacement/)與[**字型替代**](https://docs.aspose.com/slides/zh-hant/java/font-substitution/)。

以下是 Aspose.Slides 處理字型的流程：

1. Aspose.Slides 會在作業系統中搜尋與簡報選定字型相符的字型。 
2. 若找到選定的字型，Aspose.Slides 會使用它。否則，Aspose.Slides 會使用一個盡可能接近 PowerPoint 所使用的替代字型。
3. 若已透過[FontSubstRule](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fontsubstrule/) 設定字型替換規則，則會套用這些規則。 

Aspose.Slides 允許您在應用程式執行期間加入字型，然後使用這些字型。請參閱[**自訂字型**](https://docs.aspose.com/slides/zh-hant/java/custom-font/)。

當在簡報中放入額外字型時，這些字型稱為[**嵌入字型**](https://docs.aspose.com/slides/zh-hant/java/embedded-font/)。

Aspose.Slides 允許您加入僅套用於輸出文件的字型。例如，若您要將簡報轉換為 PDF，但系統與嵌入字型中皆缺少所需字型，您可以將所需字型作為**外部字型**加入或載入。

{{% alert title="Note" color="info" %}} 
我們不分發任何字型，無論是付費或免費。我们的 API 允許您載入外部字型並將其嵌入文件，但您必須自行自行決定和負責使用的字型。
{{% /alert %}}

## **常見問題**

### 如何在轉換前判斷實際使用的字型？

Aspose.Slides 讓您透過[字型管理員](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fontsmanager/) 檢查使用的字型，從而決定是否[嵌入](/slides/zh-hant/java/embedded-font/)、[取代](/slides/zh-hant/java/font-replacement/)或加入[外部來源](/slides/zh-hant/java/custom-font/)。這可協助您防止在呈現與匯出時出現不想要的替代。

### 我可以在不安裝於作業系統的情況下新增額外的字型目錄嗎？

可以。您可以註冊[外部字型來源](/slides/zh-hant/java/custom-font/)（例如資料夾或記憶體串流）以供呈現與匯出使用。這樣可移除對主機系統字型的依賴，保持版面配置可預測。

### 如何防止在缺少字形時靜默回退到不適當的字型？

事先定義明確的[字型取代](/slides/zh-hant/java/font-replacement/)與字型[回退規則](/slides/zh-hant/java/fallback-font/)。透過分析使用的字型並設定受控的替代優先順序，確保排版一致，避免意外結果。