---
title: "使用 Open XML SDK 在 .NET 中從 PPT、PPTX 和 ODP 檔案擷取文字的方法"
linktitle: "Open XML SDK"
type: docs
weight: 20
url: /zh-hant/net/extracting-text-on-cloud-platforms-using-open-xml-sdk/
keywords:
- 雲端平台
- 雲端整合
- Open XML SDK
- PPTX 文字擷取
- .NET 投影片處理
- 簡報文字擷取
- 母片
- 講者備註
- 從投影片擷取文字
- C#
description: "了解如何在 .NET 中使用 Open XML SDK 從 PPT、PPTX 與 ODP 檔案擷取文字，透過基於 XML 的存取、效能技巧，以及雲端應用的轉換應變方案。"
---
## **概述**

本文說明如何使用 .NET 中的 Open XML SDK 從簡報檔案中擷取文字。重點在於對 PPTX 檔案的直接 XML 存取，能夠從結構化的投影片元素中取得文字，而無需渲染投影片或安裝 Microsoft PowerPoint。文章亦描述了效能優勢，例如更快的處理速度與較低的記憶體使用量。

對於 PPT 與 ODP 檔案，本文說明無法直接使用 Open XML SDK 擷取文字。必須先將這些格式轉換為 PPTX，之後才能從產生的檔案中擷取文字。

## **Open XML SDK**

**Open XML SDK** 提供高度結構化且有效率的方式來從簡報檔案中擷取文字，尤其是符合 Open XML 標準的 **PPTX**。透過直接存取底層 XML，此 SDK 相較於傳統方法能更快速且更彈性地處理投影片內容。

## **直接 XML 存取**

- **直接分析文字**: Open XML SDK 允許您從 XML 部分擷取文字，而無需渲染投影片。
- **結構化元素**: 由於文字儲存在明確定義的 XML 標籤中，檢索與處理更為簡單。

### **範例：直接從投影片 XML 內容擷取文字**
```csharp
using (PresentationDocument presentation = PresentationDocument.Open("presentation.pptx", false))
{
    var slidePart = presentation.PresentationPart.SlideParts.FirstOrDefault();
    if (slidePart != null)
    {
        var textElements = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>();
        foreach (var text in textElements)
        {
            Console.WriteLine(text.Text);
        }
    }
}
```

## **效能優勢**
- **更快的擷取**: 省去開啟 PowerPoint 或其他高階 API 的額外開銷。
- **較低的記憶體使用**: 僅存取相關的 XML 部分，減少資源消耗。
- **不需要 Microsoft PowerPoint**: 免除額外的安裝需求。

### **範例：在不載入整個簡報的情況下高效擷取文字**
```csharp
using (PresentationDocument presentation = PresentationDocument.Open("presentation.pptx", false))
{
    foreach (var slidePart in presentation.PresentationPart.SlideParts)
    {
        var texts = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>().Select(t => t.Text);
        Console.WriteLine(string.Join(" ", texts));
    }
}
```

## **識別文字元素**

### **從簡報中擷取文字的細節**
在從簡報中擷取文字時，請考慮以下因素：

- **文字可能位於不同區段**: 正常投影片、母片、版面配置或講者備註。
- **預設佔位符**: 母片與版面配置可能包含佔位符（例如「Click to edit Master title style」），這些並非實際的簡報內容。
- **過濾空白或隱藏文字**: 某些元素可能為空或不打算顯示。

### **包含文字的標籤**
在 **PPTX** 檔案中，文字通常儲存在：

- `<a:t>` 元素，位於 `<a:p>`（段落）內
- `<a:r>` 元素（段落內的文字片段）

### **範例：從投影片擷取所有文字元素**
```csharp
var textElements = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>();
foreach (var text in textElements)
{
    Console.WriteLine(text.Text);
}
```

## **ODP 與 PPT**

### **無法直接擷取文字**
- 與 **PPTX** 不同，Open XML SDK 不支援 **PPT**（二進位格式）與 **ODP**（OpenDocument 簡報）。
- **PPT** 以封閉的二進位格式儲存內容，使文字擷取變得複雜。
- **ODP** 依賴 **OpenDocument XML**，其結構與 PPTX 不同。

### **解決方法：轉換為 PPTX**
要從 **PPT** 或 **ODP** 擷取文字，建議的做法如下：

1. **將 PPT 轉換為 PPTX**，使用 PowerPoint 或第三方工具。  
2. **將 ODP 轉換為 PPTX**，透過 LibreOffice 或 PowerPoint。  
3. 使用 Open XML SDK 從新的 PPTX **擷取文字**。

### **範例：透過 LibreOffice 命令列將 ODP 轉換為 PPTX**
```sh
soffice --headless --convert-to pptx presentation.odp
```

## **支援的平台與框架**
- **Windows**：.NET Framework 4.6.1 以上、.NET Core 2.1+、.NET 5/6/7。
- **Linux/macOS**：.NET Core 2.1+、.NET 5/6/7。
- **雲端環境**：Microsoft Azure Functions、AWS Lambda（.NET Core）、Docker 容器。
- **與 Office 應用程式的相容性**：不需安裝 Microsoft Office。
- **支援的程式語言**：Open XML SDK 可與 **C#**、**VB.NET**、**F#** 及其他 .NET 支援的語言一起使用。

## **結論**
利用 **Open XML SDK** 進行 **PPTX 文字擷取** 可同時達到高效率與清晰度，而 **PPT** 與 **ODP** 則需先進行轉換才能順利處理。採用此方法可確保 **高效能**、**彈性** 以及與現代 .NET 應用程式的 **廣泛相容性**。