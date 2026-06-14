---
title: Aspose.Slides for PHP 中的字型選擇序列
linktitle: 字型選擇
type: docs
weight: 80
url: /zh-hant/php-java/font-selection-sequence/
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
- PHP
- Aspose.Slides
description: "了解 Aspose.Slides for PHP（透過 Java）如何選擇字型，確保 PPT、PPTX 與 ODP 檔案的字型清晰一致 — 現在就提升您的投影片。"
---
## **概述**

當載入、呈現或將簡報轉換為其他格式時，Aspose.Slides 會檢查簡報中使用的字型在作業系統中是否可用。如果缺少所需的字型，Aspose.Slides 會選擇一個盡可能接近 PowerPoint 所使用的替代字型。

Aspose.Slides 會先在作業系統中搜尋所選的字型。如果找到該字型，則直接使用；如果未找到，則套用適當的替代字型。當透過 `FontSubstRule` 定義字型替代規則時，也會將這些規則納入考量。

您也可以在應用程式執行時加入字型、使用簡報中的內嵌字型，或為輸出文件（例如 PDF 檔案）載入外部字型。

## **字型選擇**

某些規則會在載入、呈現或將簡報轉換為其他格式時套用於簡報中的字型。例如，當您嘗試將簡報（其投影片）轉換為圖像時，系統會檢查簡報的字型，以驗證所選的字型是否在作業系統中可用。如果確認字型缺失，則會進行替換——請參閱 [**字型替換**](https://docs.aspose.com/slides/zh-hant/php-java/font-replacement/) 和 [**字型替代**](https://docs.aspose.com/slides/zh-hant/php-java/font-substitution/)。

這是 Aspose.Slides 處理字型時遵循的流程：

1. Aspose.Slides 在作業系統中搜尋字型，以找到與簡報所選字型相匹配的字型。 
2. 如果找到所選字型，Aspose.Slides 會使用它。否則，Aspose.Slides 會使用一個盡可能接近 PowerPoint 所使用的替代字型。 
3. 如果透過 [FontSubstRule](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontsubstrule/) 設定了字型替換規則，則會套用這些規則。

Aspose.Slides 允許您將字型加入 Aspose 執行時，然後使用這些字型。請參閱 [**自訂字型**](https://docs.aspose.com/slides/zh-hant/php-java/custom-font/)。

當在簡報中放置額外的字型時，這些字型稱為 [**內嵌字型**](https://docs.aspose.com/slides/zh-hant/php-java/embedded-font/)。

Aspose.Slides 允許您加入僅套用於*輸出文件*的字型。例如，若您想要轉換為 PDF 的簡報中缺少系統及內嵌字型，您可以將所需的字型加入或載入為 **外部字型**。

## **常見問題**

**如何在轉換前判斷簡報實際使用了哪些字型？**

Aspose.Slides 讓您透過 [font manager](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontsmanager/) 檢查使用的字型，從而決定是否要 [嵌入](/slides/zh-hant/php-java/embedded-font/)、[替換](/slides/zh-hant/php-java/font-replacement/) 或加入 [外部來源](/slides/zh-hant/php-java/custom-font/)。這有助於防止在呈現與匯出過程中出現不想要的字型替換。

**我可以在不安裝至作業系統的情況下加入額外的字型目錄嗎？**

是的。您可以註冊 [外部字型來源](/slides/zh-hant/php-java/custom-font/)（例如資料夾或記憶體串流）以用於呈現與匯出。這可消除對主機系統字型的依賴，並保持版面配置的可預測性。

**當缺少字形時，如何防止靜默回退到不適當的字型？**

事先定義明確的 [字型替換](/slides/zh-hant/php-java/font-replacement/) 與字型 [回退規則](/slides/zh-hant/php-java/fallback-font/)。透過分析使用的字型並為替代字型設定受控的優先順序，您可確保排版一致，避免意外結果。