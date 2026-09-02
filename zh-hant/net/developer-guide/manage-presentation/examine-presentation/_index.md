---
title: 在 .NET 中擷取與更新簡報資訊
linktitle: 簡報資訊
type: docs
weight: 30
url: /zh-hant/net/examine-presentation/
keywords:
- 簡報格式
- 簡報屬性
- 文件屬性
- 取得屬性
- 讀取屬性
- 變更屬性
- 修改屬性
- 更新屬性
- 檢查 PPTX
- 檢查 PPT
- 檢查 ODP
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 .NET 探索 PowerPoint 與 OpenDocument 簡報中的投影片、結構與中繼資料，以獲得更快速的洞見與更智慧的內容稽核。"
---
## **概觀**

Aspose.Slides 能夠辨識簡報的格式並在不建立完整簡報物件模型的情況下讀取文件中繼資料。這在需要分類檔案、建立清單或在決定是否載入與處理簡報內容之前檢查屬性時非常有用。

本文示範如何透過 [PresentationFactory](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentationfactory/) 與 [IPresentationInfo](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipresentationinfo/) 進行輕量級檢查，並利用 [IDocumentProperties](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/idocumentproperties/) 執行目標更新。

## **檢查簡報格式**

使用 [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentationfactory/getpresentationinfo/) 在不建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 實例的情況下檢查檔案。[IPresentationInfo.LoadFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipresentationinfo/loadformat/) 屬性會回報偵測到的格式，例如 PPTX、PPT 或 ODP。

```csharp
using System;
using Aspose.Slides;

var fileNames = new[] { "pres.pptx", "pres.ppt", "pres.odp" };

foreach (var fileName in fileNames)
{
    var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(fileName);
    Console.WriteLine($"{fileName}: {presentationInfo.LoadFormat}");
}
```

## **建立輕量化簡報清單**

當您需要處理大量簡報檔案時，可能需要一個緊湊的清單以供驗證、索引或文件管理系統使用。在此情境下，請使用 [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentationfactory/getpresentationinfo/) 取得 [IPresentationInfo](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipresentationinfo/) 物件，然後呼叫 [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipresentationinfo/readdocumentproperties/) 讀取文件中繼資料。此作法不會建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 實例，也不需要遍歷完整的簡報物件模型。

[IDocumentProperties](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/idocumentproperties/) 所公開的延伸屬性提供下列清單值：

| 屬性 | 清單值 |
| --- | --- |
| [Slides](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/idocumentproperties/slides/zh-hant/) | 投影片總數。 |
| [HiddenSlides](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/idocumentproperties/hiddenslides/) | 隱藏投影片的數量。 |
| [Notes](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/idocumentproperties/notes/) | 包含註解的投影片數量。 |
| [Paragraphs](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/idocumentproperties/paragraphs/) | 段落的總數（如有）。 |
| [Words](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/idocumentproperties/words/) | 字數總計。 |
| [MultimediaClips](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/idocumentproperties/multimediaclips/) | 音訊與視訊剪輯的總數。 |

以下範例在不建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 物件的情況下讀取這些值並輸出緊湊的清單。它同時結合 [HeadingPairs](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/idocumentproperties/headingpairs/) 與 [TitlesOfParts](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/idocumentproperties/titlesofparts/) 以顯示字型、佈景主題與投影片標題等內容群組。

```csharp
using System;
using System.IO;
using Aspose.Slides;

var filePath = "sample.pptx";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(filePath);
var documentProperties = presentationInfo.ReadDocumentProperties();

Console.WriteLine($"File: {Path.GetFileName(filePath)}");
Console.WriteLine($"Format: {presentationInfo.LoadFormat}");
Console.WriteLine($"Title: {documentProperties.Title}");
Console.WriteLine($"Author: {documentProperties.Author}");
Console.WriteLine("Statistics:");
Console.WriteLine($"  Slides: {documentProperties.Slides}");
Console.WriteLine($"  Hidden slides: {documentProperties.HiddenSlides}");
Console.WriteLine($"  Slides with notes: {documentProperties.Notes}");
Console.WriteLine($"  Paragraphs: {documentProperties.Paragraphs}");
Console.WriteLine($"  Words: {documentProperties.Words}");
Console.WriteLine($"  Multimedia clips: {documentProperties.MultimediaClips}");

var headingPairs = documentProperties.HeadingPairs ?? Array.Empty<IHeadingPair>();
var titlesOfParts = documentProperties.TitlesOfParts ?? Array.Empty<string>();
var partIndex = 0;

if (headingPairs.Length == 0 || titlesOfParts.Length == 0)
{
    Console.WriteLine("Content groups: not available");
}
else
{
    Console.WriteLine("Content groups:");

    foreach (var headingPair in headingPairs)
    {
        Console.WriteLine($"  {headingPair.Name} ({headingPair.Count})");

        for (var partOffset = 0; partOffset < headingPair.Count && partIndex < titlesOfParts.Length; partOffset++)
        {
            Console.WriteLine($"    - {titlesOfParts[partIndex]}");
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.Length)
    {
        Console.WriteLine("  Other parts:");

        while (partIndex < titlesOfParts.Length)
        {
            Console.WriteLine($"    - {titlesOfParts[partIndex]}");
            partIndex++;
        }
    }
}
```

每個 [IHeadingPair](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iheadingpair/) 都提供群組名稱以及該群組的項目數量。[IDocumentProperties.TitlesOfParts](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/idocumentproperties/titlesofparts/) 為平坦且有序的陣列，必須依每個標題配對所指定的連續標題數量來消費。

### **儲存的中繼資料與格式限制**

由 [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipresentationinfo/readdocumentproperties/) 回傳的清單屬性反映來源文件中可取得的中繼資料。Aspose.Slides 不會載入並遍歷簡報物件模型以重新計算這些值。缺少的屬性會以預設值表示，而已存儲的值若最後一次儲存檔案的應用程式未更新文件屬性，可能已過時。

- **PPTX:** 此格式提供投影片、註解、隱藏投影片、段落、單字與多媒體計數的延伸文件屬性，亦包括標題配對與部件標題。可用性取決於文件產生者寫入了哪些屬性。  
- **PPT:** 二進位格式可以儲存相對應的文件摘要屬性。若屬性缺失或未由文件產生者重新整理，Aspose.Slides 會回傳其已存儲或預設值，而非根據投影片重新計算。  
- **ODP:** OpenDocument 中繼資料提供一般文件統計資訊，如頁面、段落與單字計數，但這些值未必對應每個 PowerPoint 專屬的延伸屬性。隱藏投影片、註解投影片、多媒體、標題配對與部件標題的中繼資料可能不存在，清單屬性可能回傳預設值。請勿將零值或空陣列視為對應內容確實不存在的權威證明。

使用輕量化中繼資料方法建立清單與執行初步檢查。若結果必須反映記憶體中的變更，或需要驗證實際的簡報內容，請載入簡報並檢查其即時物件模型。

## **更新簡報屬性**

由 [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipresentationinfo/readdocumentproperties/) 回傳的屬性也可以在不建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 實例的情況下變更。使用 [IPresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipresentationinfo/updatedocumentproperties/) 套用變更，然後以 [IPresentationInfo.WriteBindedPresentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipresentationinfo/writebindedpresentation/) 寫入已綁定的簡報。

以下圖片顯示 PowerPoint 簡報的原始文件屬性。

![PowerPoint 簡報的原始文件屬性](input_properties.png)

以下範例變更標題與最後儲存時間，並將結果寫入新檔案：

```csharp
using System;
using System.IO;
using Aspose.Slides;

var sourceFile = "sample.pptx";
var outputFile = "sample_with_updated_properties.pptx";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(sourceFile);
var documentProperties = presentationInfo.ReadDocumentProperties();

documentProperties.Title = "Quarterly sales report";
documentProperties.LastSavedTime = DateTime.UtcNow;

presentationInfo.UpdateDocumentProperties(documentProperties);
using var outputStream = File.Create(outputFile);
presentationInfo.WriteBindedPresentation(outputStream);
```

以下圖片顯示 PowerPoint 簡報的已變更文件屬性。

![PowerPoint 簡報的已變更文件屬性](output_properties.png)

## **實用連結**

相關的安全檢查與保護設定請參考以下文章：

- [保護簡報的密碼](/slides/zh-hant/net/password-protected-presentation/)
- [寫入保護簡報](/slides/zh-hant/net/write-protected-presentation/)

## **常見問答**

**如何檢查字型是否已嵌入以及哪些字型被嵌入？**

載入簡報並使用 [Presentation.FontsManager](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/fontsmanager/)。呼叫 [FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontsmanager/getembeddedfonts/) 取得已嵌入的字型，並呼叫 [FontsManager.GetFonts](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontsmanager/getfonts/) 取得簡報使用的字型。將兩者結果比較，即可找出需要呈現但未嵌入的字型。

**如何快速判斷檔案是否有隱藏投影片以及有多少？**

當已存儲的文件中繼資料足夠時，透過 [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentationfactory/getpresentationinfo/) 與 [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipresentationinfo/readdocumentproperties/) 讀取 [IDocumentProperties.HiddenSlides](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/idocumentproperties/hiddenslides/)。此作法適用於輕量化清單。若簡報已在記憶體中被修改，已存儲的中繼資料可能遺失或過時，或需驗證即時值，請遍歷 [Presentation.Slides](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/slides/zh-hant/) 並檢查每張投影片的 [Slide.Hidden](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/slide/hidden/) 屬性。

**我能偵測自訂投影片尺寸與方向是否被使用，以及是否與預設不同嗎？**

可以。載入簡報並讀取 [Presentation.SlideSize](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/slidesize/)。檢查 [ISlideSize.Type](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidesize/type/)、[ISlideSize.Size](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidesize/size/) 與 [ISlideSize.Orientation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidesize/orientation/)，以將目前設定與預設的尺寸與方向進行比較。

**有沒有快速方法檢查圖表是否引用外部資料來源？**

有。尋找每個 [Chart](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/chart/) 並檢查 [ChartData.DataSourceType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/chartdata/datasourcetype/)。若為外部活頁簿，讀取 [ChartData.ExternalWorkbookPath](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/chartdata/externalworkbookpath/)。資料來源類型與路徑即可識別外部參照，但是否可取得目標需另外執行資源檢查。

**如何評估可能減慢渲染或 PDF 匯出的「沉重」投影片？**

沒有單一的複雜度屬性。遍歷 [Presentation.Slides](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/slides/zh-hant/) 以及每張投影片的 [IBaseSlide.Shapes](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ibaseslide/shapes/) 集合。利用形狀數量以及大型圖片、特效、動畫或多媒體的存在作為篩選指標，並在將投影片視為確定的效能瓶頸前，先測量代表性的渲染或匯出時間。