---
title: Aspose.Slides for .NET 的字體選擇序列
linktitle: 字體選擇
type: docs
weight: 80
url: /zh-hant/net/font-selection-sequence/
keywords:
- 字體選擇
- 字體替代
- 字體置換
- 替代規則
- 可用字體
- 缺少字體
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "了解 Aspose.Slides for .NET 如何選擇字體，確保 PPT、PPTX 與 ODP 檔案的字體清晰一致—立即提升您的投影片。"
---
## **概述**

載入、渲染或轉換為其他格式時，Aspose.Slides 會檢查簡報中使用的字體是否在作業系統中可用。如果缺少必要的字體，Aspose.Slides 會選擇一種盡可能接近 PowerPoint 所使用字體的替代字體。

Aspose.Slides 會先在作業系統中搜尋所選字體。如果找到該字體，則直接使用；如果未找到，則套用適當的替代字體。當透過 `FontSubstRule` 定義字體置換規則時，亦會考慮這些規則。

您也可以在應用程式執行期間新增字體、使用簡報中的內嵌字體，或為 PDF 等輸出文件載入外部字體。

## **字體選擇**

在載入、渲染或轉換簡報為其他格式時，會對簡報中的字體套用特定規則。例如，當您嘗試將簡報（其投影片）轉換為圖像時，會檢查簡報的字體以驗證所選字體是否在作業系統中可用。如果確認缺少字體，則會進行替換 — 請參閱[**Font Replacement**](https://docs.aspose.com/slides/zh-hant/net/font-replacement/)和[**Font Substitution**](https://docs.aspose.com/slides/zh-hant/net/font-substitution/)。

以下是 Aspose.Slides 處理字體時遵循的流程：

1. Aspose.Slides 會在作業系統中搜尋字體，以找到與簡報所選字體相匹配的字體。 
2. 如果找到所選字體，Aspose.Slides 會使用它；否則，Aspose.Slides 會使用一種盡可能接近 PowerPoint 所使用字體的替代字體。 
3. 如果透過[FontSubstRule](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontsubstrule/) 設定了字體替換規則，則會套用這些規則。 

Aspose.Slides 允許您在應用程式執行期間加入字體，然後使用這些字體。請參閱[**Custom fonts**](https://docs.aspose.com/slides/zh-hant/net/custom-font/)。 

當額外字體被放置於簡報中時，稱為[**Embedded fonts**](https://docs.aspose.com/slides/zh-hant/net/embedded-font/)。 

Aspose.Slides 允許您加入僅套用於*輸出文件*的字體。例如，若您要轉換為 PDF 的簡報中缺少系統和內嵌字體，您可以將所需字體加入或載入為**external fonts**。 

{{% alert title="Note" color="primary" %}} 
We do not distribute any fonts, either paid or free. Our API allows you to load external fonts and embed them in documents, but you do so with fonts at your discretion and responsibility.
{{% /alert %}}

## **常見問題**

**如何在轉換前確定簡報實際使用了哪些字體？**

Aspose.Slides 讓您透過[font manager](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/fontsmanager/)檢查所使用的字體，藉此決定是要[embed](/slides/zh-hant/net/embedded-font/)、[replace](/slides/zh-hant/net/font-replacement/)還是加入[external sources](/slides/zh-hant/net/custom-font/)。這可協助您在渲染與匯出時防止不必要的置換。

**我可以在不將字體安裝至作業系統的情況下新增額外的字體目錄嗎？**

可以。您可以註冊[external font sources](/slides/zh-hant/net/custom-font/)（如資料夾或記憶體串流）以供渲染與匯出使用。這樣可消除對主機系統字體的依賴，並確保版面配置的可預測性。

**當字形缺失時，我如何防止靜默地回退至不合適的字體？**

提前定義明確的[font replacement](/slides/zh-hant/net/font-replacement/)和字體[fallBack rules](/slides/zh-hant/net/fallback-font/)。透過分析使用的字體並設定受控的替代優先順序，可確保排版的一致性，避免意外結果。