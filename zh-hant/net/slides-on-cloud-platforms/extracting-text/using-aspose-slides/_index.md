---
title: "如何使用 Aspose.Slides 從 PPT、PPTX 與 ODP 擷取文字"
linktitle: "簡報"
type: docs
weight: 30
url: /zh-hant/net/extracting-text-on-cloud-platforms-using-aspose-slides/
keywords:
- "雲端平台"
- "雲端整合"
- "文字擷取"
- "擷取文字"
- "PPT"
- "PPTX"
- "ODP"
- "簡報檔案"
- "跨平台"
- "獨立於 Office"
- "備註與評論"
- "企業索引"
- "資料增益"
- ".NET"
- "Aspose.Slides"
description: "使用 Aspose.Slides API 從流行的雲端平台上的簡報擷取文字，並自動化搜尋、分析與匯出 PPT、PPTX 與 ODP。"
---
## **簡介**

Aspose.Slides 提供一個 **功能強大且高階的 API**，用於從簡報檔案（包括 **PPT、PPTX 和 ODP**）中擷取文字。與只能支援 PPTX 且需進行複雜 XML 解析的 Open XML SDK 不同，Aspose.Slides 簡化了文字擷取流程，讓您可以專注於將擷取的內容整合到工作流程中。

## **使用 PresentationFactory.Instance.GetPresentationText 快速擷取文字**

若要從簡報中擷取文字，**Aspose.Slides API** 提供靜態方法 `PresentationFactory.Instance.GetPresentationText`。此方法有多種重載，可處理簡報檔案或資料流，並擷取來自 **投影片、母片、版面配置、備註與評論** 的文字。擷取的文字可透過 `IPresentationText` 介面取得。

範例使用方式：

```csharp
string filePath = "presentation.pptx";
TextExtractionArrangingMode mode = TextExtractionArrangingMode.Unarranged;

IPresentationText presentationText = PresentationFactory.Instance.GetPresentationText(filePath, mode);
ISlideText[] slideTexts = presentationText.SlidesText;

foreach (var slideText in slideTexts)
{
    Console.WriteLine("Slide Text: " + slideText.Text);
    Console.WriteLine("Notes Text: " + slideText.NotesText);
    Console.WriteLine("Comments Text: " + slideText.CommentsText);
}
```

## **GetPresentationText 的運作模式**

`PresentationFactory` 中的 `GetPresentationText` 方法允許您使用 `TextExtractionArrangingMode` 參數微調文字擷取方式，該參數控制輸出文字的排列方式。

### **可用模式**

- **TextExtractionArrangingMode.Unarranged** – 以自由形式擷取文字，忽略原始投影片版面配置。  
- **TextExtractionArrangingMode.Arranged** – 依照每張投影片上的位置保留文字順序。

使用範例：

```csharp
TextExtractionArrangingMode mode = TextExtractionArrangingMode.Arranged;
IPresentationText presentationText = PresentationFactory.Instance.GetPresentationText("presentation.pptx", mode);
ISlideText[] slideTexts = presentationText.SlidesText;

foreach (var slideText in slideTexts)
{
    Console.WriteLine("Slide Text (preserving order): " + slideText.Text);
}
```

## **PresentationFactory 方法的主要優勢**

- **無需載入完整簡報**：減少記憶體使用，提升處理速度。  
- **針對大型檔案最佳化**：即使是大型簡報也能高效擷取文字。  
- **擷取備註與評論**：包含使用者註解，確保內容完整。  
- **適用於索引與內容分析**：非常適合需要自動化處理與資料增益的企業系統。  
- **獨立於 Office**：不需安裝 Microsoft PowerPoint，即可獨立運作。  
- **多格式支援**：無縫支援 **PPT、PPTX 和 ODP**。  
- **彈性且功能強大的 API**：提供多樣化方法，以結構化方式擷取文字。  
- **完整投影片覆蓋**：從 **版面配置、母片、一般投影片、背景、演講者備註與評論** 中擷取文字。  
- **跨平台相容性**：可在 **Windows、Linux、macOS** 以及雲端環境執行。  
- **高效能與可擴充性**：適用於 **SaaS 應用程式** 與大型企業部署。

## **支援的作業系統**

Aspose.Slides 可在多種作業系統上執行：

- **Windows**（如 Windows 7、8、10、11 以及 Server 版）  
- **Linux**（各種發行版，包括 Ubuntu、Debian、Fedora、CentOS 等）  
- **macOS**（包括 10.15 Catalina 及更新版本）  

## **支援的程式語言**

Aspose.Slides 可與多種平台與語言整合：

- **C#** – 主要透過 Aspose.Slides for .NET 支援。  
- **Java** – 提供完整功能的 Aspose.Slides for Java API。  
- **C++** – 在效能關鍵的 C++ 應用程式中使用 Aspose.Slides。  
- **Python via .NET** – 透過 .NET 互通性在 Python 中使用 Aspose.Slides 功能。  
- **其他 .NET 相容語言** – 可在任何支援 .NET 的環境中使用此函式庫。

## **結論**

Aspose.Slides 為 PowerPoint 與 OpenDocument 簡報提供 **完整的文字擷取** 能力，支援 **多種檔案格式、直觀的文字結構化以及相較於 Open XML SDK 更簡易的實作方式**。無論是 **投影片、備註或範本內容**，**Aspose.Slides** 都是一套高效率、功能豐富的解決方案，適用於擷取與管理簡報文字。