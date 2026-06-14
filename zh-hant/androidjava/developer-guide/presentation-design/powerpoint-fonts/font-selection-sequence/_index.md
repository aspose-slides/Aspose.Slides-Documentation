---
title: Aspose.Slides for Android via Java 的字型選擇順序
linktitle: 字型選擇
type: docs
weight: 80
url: /zh-hant/androidjava/font-selection-sequence/
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
- Android
- Java
- Aspose.Slides
description: "了解 Aspose.Slides for Android via Java 如何選擇字型，確保 PPT、PPTX 與 ODP 檔案的字型清晰且一致——立即提升您的投影片品質。"
---
## **概覽**

當載入、呈現或轉換簡報至其他格式時，Aspose.Slides 會檢查簡報中使用的字型在作業系統中是否可用。若缺少必要的字型，Aspose.Slides 會選擇一個盡可能接近 PowerPoint 會使用的替代字型。

Aspose.Slides 會先在作業系統中搜尋所選字型。若找到該字型，則直接使用；若未找到，則套用合適的替代字型。當透過 `FontSubstRule` 定義字型替換規則時，這些規則也會被考慮在內。

您也可以在應用程式執行時加入字型、使用簡報內嵌的字型，或為 PDF 等輸出文件載入外部字型。

## **字型選擇**

在載入、呈現或轉換簡報至其他格式時，會對簡報中的字型套用特定規則。例如，當您嘗試將簡報（其投影片）轉換為影像時，會檢查簡報的字型是否在作業系統中可用。若確認缺少字型，則會進行替換 — 參見[**字型取代**](https://docs.aspose.com/slides/zh-hant/androidjava/font-replacement/)和[**字型替代**](https://docs.aspose.com/slides/zh-hant/androidjava/font-substitution/)。

以下是 Aspose.Slides 處理字型時遵循的流程：

1. Aspose.Slides 在作業系統中搜尋字型，以找出與簡報所選字型相符的字型。  
2. 若找到所選字型，Aspose.Slides 會使用它；否則，Aspose.Slides 會採用一個盡可能接近 PowerPoint 所使用的替代字型。  
3. 如果透過[FontSubstRule](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fontsubstrule/) 設定了字型替換規則，則會套用這些規則。

Aspose.Slides 允許您在應用程式執行時加入字型，然後使用這些字型。請參閱[**自訂字型**](https://docs.aspose.com/slides/zh-hant/androidjava/custom-font/)。

當在簡報中放入額外字型時，稱為[**內嵌字型**](https://docs.aspose.com/slides/zh-hant/androidjava/embedded-font/)。

Aspose.Slides 允許您加入僅套用於*輸出文件*的字型。例如，若您要轉換為 PDF 的簡報中缺少系統與內嵌字型，您可以將所需的字型加入或載入為**外部字型**。

{{% alert title="Note" color="primary" %}} 
我們不分發任何字型，無論是付費或免費。我們的 API 允許您載入外部字型並將其嵌入文件，但字型的使用完全由您自行決定並自行負責。
{{% /alert %}}

## **常見問題**

**如何在轉換前確定簡報實際使用了哪些字型？**

Aspose.Slides 讓您透過[字型管理員](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fontsmanager/)檢查使用的字型，從而決定是要[嵌入](/slides/zh-hant/androidjava/embedded-font/)、[取代](/slides/zh-hant/androidjava/font-replacement/)或新增[外部來源](/slides/zh-hant/androidjava/custom-font/)。這可協助您在渲染與匯出時避免不必要的字型替換。

**我可以在不將字型安裝到作業系統的情況下新增額外的字型目錄嗎？**

可以。您可以註冊[外部字型來源](/slides/zh-hant/androidjava/custom-font/)（例如資料夾或記憶體串流）以用於渲染與匯出。這樣可消除對主機系統字型的依賴，並使版面配置保持可預測。

**當缺少字形時，如何防止靜默回退到不合適的字型？**

事先定義明確的[字型取代](/slides/zh-hant/androidjava/font-replacement/)與字型[回退規則](/slides/zh-hant/androidjava/fallback-font/)。透過分析使用的字型並為替代字型設定受控的優先順序，您即可確保版面排版一致，避免意外結果。