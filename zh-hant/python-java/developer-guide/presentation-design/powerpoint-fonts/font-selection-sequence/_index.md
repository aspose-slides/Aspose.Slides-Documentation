---
title: Aspose.Slides for Python via Java 中的字型選擇順序
linktitle: 字型選擇
type: docs
weight: 80
url: /zh-hant/python-java/font-selection-sequence/
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
- Python
- Java
- Aspose.Slides
description: "了解 Aspose.Slides for Python via Java 如何選擇字型，確保 PPT、PPTX 與 ODP 檔案的清晰一致呈現──立即提升您的投影片效果。"
---
## **概述**

當載入、呈現或轉換簡報為其他格式時，Aspose.Slides 會檢查簡報中使用的字型是否在作業系統中可用。若缺少必要的字型，Aspose.Slides 會選擇一個盡可能接近 PowerPoint 會使用的替代字型。

Aspose.Slides 會首先在作業系統中搜尋所選的字型。若找到該字型，則直接使用；若未找到，則套用適當的替代字型。當透過 [FontSubstRule](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontsubstrule/) 定義字型取代規則時，這些規則也會被考慮。

您亦可以在應用程式執行時新增字型、使用簡報中嵌入的字型，或為輸出文件（例如 PDF 檔案）載入外部字型。

## **字型選擇**

在載入、呈現或轉換簡報為其他格式時，字型會受到特定規則的限制。例如，當您嘗試將簡報（投影片）轉換為圖像時，系統會檢查簡報的字型，以確認所選字型是否在作業系統中可用。若確定字型缺失，則會被取代 ─ 請參閱 [Font Replacement](/slides/zh-hant/python-java/font-replacement/) 與 [Font Substitution](/slides/zh-hant/python-java/font-substitution/)。

以下是 Aspose.Slides 處理字型時的流程：

1. Aspose.Slides 在作業系統中搜尋字型，以找到與簡報所選字型相符的字型。
2. 若找到所選字型，Aspose.Slides 會使用它；否則，Aspose.Slides 會使用一個盡可能接近 PowerPoint 會使用的替代字型。
3. 若透過 [FontSubstRule](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontsubstrule/) 設定了字型取代規則，則會套用這些規則。

Aspose.Slides 允許您在應用程式執行時新增字型，然後使用這些字型。請參閱 [Custom fonts](/slides/zh-hant/python-java/custom-font/)。

當在簡報中放置額外字型時，這些字型稱為 [Embedded fonts](/slides/zh-hant/python-java/embedded-font/)。

Aspose.Slides 允許您新增僅套用於輸出文件的字型。例如，若您要轉換為 PDF 的簡報使用了既未安裝於系統也未嵌入於簡報的字型，您可以將所需字型新增或載入為 **external fonts**。

{{% alert title="Note" color="info" %}}
我們不提供任何字型，不論付費或免費。我們的 API 允許您載入外部字型並將其嵌入文件，但此操作須自行斟酌並自行負責。
{{% /alert %}}

## **FAQ**

**如何在轉換前判斷簡報實際使用了哪些字型？**

Aspose.Slides 讓您透過 [font manager](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontsmanager/) 檢查使用的字型，從而決定是否要 [embed](/slides/zh-hant/python-java/embedded-font/)、[replace](/slides/zh-hant/python-java/font-replacement/) 或加入 [external sources](/slides/zh-hant/python-java/custom-font/)。這有助於防止在呈現與匯出過程中發生不想要的字型取代。

**我可以在不將字型安裝至作業系統的情況下，新增額外的字型目錄嗎？**

可以。您可以註冊 [external font sources](/slides/zh-hant/python-java/custom-font/)（如資料夾或記憶體串流）供呈現與匯出使用。如此可移除對主機系統字型的依賴，並使版面配置保持可預測。

**當缺少字形時，如何避免系統悶悶不聲的回退到不適當的字型？**

事先定義明確的 [font replacement](/slides/zh-hant/python-java/font-replacement/) 與字型 [fallback rules](/slides/zh-hant/python-java/fallback-font/)。透過分析使用的字型並設定替代字型的受控優先順序，您可確保排版一致，避免出現意外結果。