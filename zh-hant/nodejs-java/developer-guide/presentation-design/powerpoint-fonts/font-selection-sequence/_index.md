---
title: Aspose.Slides for Node.js via Java 的字型選擇序列
linktitle: 字型選擇
type: docs
weight: 80
url: /zh-hant/nodejs-java/font-selection-sequence/
keywords:
- 字型選擇
- 字型置換
- 字型替換
- 置換規則
- 可用字型
- 缺失字型
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "探索 Aspose.Slides for Node.js via Java 如何選擇字型，確保 PPT、PPTX 與 ODP 檔案的呈現清晰且一致——立即提升您的簡報。"
---
## **概觀**

當載入、渲染或將簡報轉換為其他格式時，Aspose.Slides 會檢查簡報中使用的字型是否在作業系統中可用。若缺少必要的字型，Aspose.Slides 會選擇一個與 PowerPoint 所使用的字型盡可能接近的替代字型。

Aspose.Slides 會先在作業系統中搜尋所選字型。若找到，就使用該字型；若找不到，則套用適當的替代字型。當透過 `FontSubstRule` 定義字型替代規則時，這些規則也會被考慮。

您也可以在應用程式執行期間加入字型、使用簡報內嵌的字型，或為 PDF 等輸出文件載入外部字型。

## **字型選擇**

在載入、渲染或將簡報轉換為其他格式時，簡報中的字型會受到特定規則的約束。例如，當您嘗試將簡報（其投影片）轉換為影像時，系統會檢查簡報的字型是否在作業系統中可用。若確認字型缺失，系統會進行替換——請參閱[**字型替換**](https://docs.aspose.com/slides/zh-hant/nodejs-java/font-replacement/)與[**字型置換**](https://docs.aspose.com/slides/zh-hant/nodejs-java/font-substitution/)。

以下是 Aspose.Slides 處理字型的流程：

1. Aspose.Slides 會在作業系統中搜尋與簡報所選字型相匹配的字型。  
2. 若找到所選字型，則使用該字型；否則 Aspose.Slides 會使用一個盡可能接近 PowerPoint 所使用的替代字型。  
3. 若已透過[FontSubstRule](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontsubstrule/) 設定字型替換規則，則會套用這些規則。

Aspose.Slides 允許您在應用程式執行期間加入字型，然後使用這些字型。請參閱[**自訂字型**](https://docs.aspose.com/slides/zh-hant/nodejs-java/custom-font/)。

當在簡報中放置額外字型時，它們稱為[**內嵌字型**](https://docs.aspose.com/slides/zh-hant/nodejs-java/embedded-font/)。

Aspose.Slides 允許您加入僅套用於輸出文件的字型。例如，若您要將包含系統與內嵌字型缺失的簡報轉換為 PDF，您可以將所需字型加入或載入為**外部字型**。

{{% alert title="Note" color="primary" %}} 
我們不會分發任何字型（無論是付費或免費）。我們的 API 允許您載入外部字型並將其嵌入文件，但使用字型的選擇與責任完全由您自行承擔。
{{% /alert %}}

## **常見問題**

**如何在轉換前判斷簡報實際使用了哪些字型？**

Aspose.Slides 讓您透過[字型管理員](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/getfontsmanager/) 檢查使用的字型，從而決定是否要[嵌入](/slides/zh-hant/nodejs-java/embedded-font/)、[替換](/slides/zh-hant/nodejs-java/font-replacement/)或新增[外部來源](/slides/zh-hant/nodejs-java/custom-font/)。這可協助您避免在渲染與匯出時產生不希望的字型置換。

**我可以在不安裝到作業系統的情況下新增額外的字型目錄嗎？**

可以。您可以註冊[外部字型來源](/slides/zh-hant/nodejs-java/custom-font/)，例如資料夾或記憶體串流，用於渲染與匯出。這樣可移除對主機系統字型的依賴，保持版面配置的可預測性。

**如何防止在缺少字形時靜默回退到不適當的字型？**

提前定義明確的[字型替換](/slides/zh-hant/nodejs-java/font-replacement/)與字型[回退規則](/slides/zh-hant/nodejs-java/fallback-font/)。透過分析使用的字型並設置受控的替代字型優先順序，可確保排版一致，避免意外結果。