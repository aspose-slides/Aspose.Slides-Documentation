---
title: "投影片文字擷取：PPT、PPTX、ODP 基礎"
type: docs
weight: 10
url: /zh-hant/python-java/slide-text-extraction-ppt-pptx-odp-essentials/
keywords:
- 雲端平台
- 簡報文字擷取
- 投影片文字擷取
- 從 PPT 擷取文字
- 從 PPTX 擷取文字
- 從 ODP 擷取文字
- Microsoft PowerPoint
- OpenDocument
- LibreOffice Impress
- Office Open XML
- 搜尋索引
- 文件自動化
- 資料分析
- 無障礙
- Python
- Aspose.Slides
description: "了解 PPT、PPTX 與 ODP 如何儲存投影片文字，並使用 Aspose.Slides for Python via Java 計畫搜尋、流程自動化與本地化的擷取作業。"
---
## **簡介**

擷取簡報文字可讓投影片內容可用於搜尋、分析、無障礙功能以及本地化。在 Python 應用程式中，擷取的文字可供索引、文件管理系統或語言處理流水線使用。雲端工作者可以將相同的工作流程套用於從上傳或物件儲存收到的檔案。

本文說明 PPT、PPTX 與 ODP 如何儲存文字，以及這些差異如何影響擷取。Aspose.Slides for Python via Java 支援載入全部三種格式；請參閱[Supported File Formats](/slides/zh-hant/python-java/supported-file-formats/).

## **文字擷取的實際應用**

- **文件工作流程：**將簡報內容匯入文件管理系統，並與來源檔案的中繼資料關聯。
- **搜尋索引：**在索引投影片文字時，保留簡報名稱與投影片編號作為每筆結果。
- **內容分析：**識別簡報檔案庫中的主題、術語與重複出現的概念。
- **無障礙與本地化：**為輔助工具或翻譯工作流程提供文字，並額外檢查閱讀順序與情境。
- **版面分析：**在檢查投影片結構或準備結構化匯出時，將文字與物件位置結合。

## **簡報格式概覽**

### **PPT：舊版 PowerPoint 格式**

PPT 是與 PowerPoint 97–2003 相關的二進位格式。其記錄無法以 XML 文件方式處理。解析器必須了解二進位結構及其關聯，才能重建投影片內容。  
文字可能出現在投影片物件、註解與批註中。擷取工作流程應定義要納入哪些來源，而不是將整個簡報視為單一連續的文字串流。

### **PPTX：Office Open XML**

PPTX 是一個包含 XML 部件與其他資源的 ZIP 封裝。投影片文字通常出現在 `ppt/slides/zh-hant/slideX.xml` 裡的 `a:t` 元素中。註解儲存在獨立的 notes‑slide 部件，批註則有自己的部件，透過套件關聯相連。  
僅讀取投影片 XML 中的文字元素可能會遺漏封裝內其他位置的內容。此做法亦不會重建格式或閱讀順序。完整的工作流程可能需要考慮版面、群組形狀、表格、圖表以及相關部件。

### **ODP：OpenDocument 簡報**

ODP 是由 LibreOffice Impress 等應用程式使用的封裝式 OpenDocument 簡報格式。與 PPTX 類似，它在 ZIP 封裝內包含 XML，但使用 OpenDocument 的詞彙與結構。  
簡報內容主要儲存在 `content.xml`。段落文字使用如 `text:p` 的元素，並在其中巢狀其他元素以表示字串與其他文字特性。因此，針對 PPTX 的 XML 查詢無法直接重新用於 ODP。

## **在 Python 中使用通用簡報模型**

[Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別可載入支援的簡報檔案，使應用程式碼能夠操作投影片及其物件，而無需為每種格式實作獨立的套件或二進位解析器。  
在將擷取整合至雲端工作者之前，請遵循[安裝](/slides/zh-hant/python-java/installation/)。有關部署與 JVM 生命週期的考量，請參閱[雲端平台上的 Slides](/slides/zh-hant/python-java/slides-on-cloud-platforms/)。  

在擷取設計中，請明確保留以下決策：

- **內容範圍：**決定如何處理投影片文字、註解、批註、表格與圖表標籤。
- **閱讀順序：**保留投影片邊界，當物件順序不足時使用版面資訊。
- **影像內文字：**當文字嵌入螢幕截圖或掃描投影片時，使用獨立的 OCR 工作流程。
- **輸出結構：**保留來源識別碼，並使用能支援所需語言的編碼（例如 UTF-8）寫入文字。

## **結論**

PPT 需要二進位格式的處理，而 PPTX 與 ODP 使用不同的 XML 封裝結構。簡報函式庫提供了在 Python 中處理這些格式的通用起點。定義內容範圍與閱讀順序有助於使產生的文字對索引、分析與本地化更具實用性。

## **常見問題**

**我可以透過解壓縮檔案來擷取 PPT 文字嗎？**

不能。PPT 使用二進位結構。ZIP 加 XML 的方法僅適用於像 PPTX 與 ODP 這類封裝格式。

**PPTX 中的註解與批註是否與主要投影片文字一起儲存？**

它們使用獨立的套件部件。僅讀取投影片 XML 不會自動包含它們。

**純文字擷取能捕捉螢幕截圖中的文字嗎？**

不能。螢幕截圖中的文字屬於影像的一部分，並非可編輯的投影片文字，需使用 OCR。