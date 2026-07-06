---
title: 在 .NET 中儲存簡報
linktitle: 儲存簡報
type: docs
weight: 80
url: /zh-hant/net/save-presentation/
keywords:
- 儲存 PowerPoint
- 儲存 OpenDocument
- 儲存簡報
- 儲存投影片
- 儲存 PPT
- 儲存 PPTX
- 儲存 ODP
- 簡報至檔案
- 簡報至串流
- 預先定義的檢視類型
- 嚴格 Office Open XML 格式
- Zip64 模式
- 重新整理縮圖
- 儲存進度
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides 在 .NET 中儲存簡報——可匯出為 PowerPoint 或 OpenDocument，同時保留版面配置、字型與效果。"
---
## **概觀**

[Open Presentations in C#](/slides/zh-hant/net/open-presentation/) 說明了如何使用 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別開啟簡報。本文說明如何建立與儲存簡報。[Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別包含簡報的內容。無論是從頭建立簡報或是修改現有簡報，完成後都需要儲存。使用 Aspose.Slides for .NET，您可以儲存至 **檔案** 或 **串流**。本文說明儲存簡報的不同方式。

## **將簡報儲存為檔案**

使用 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的 `Save` 方法，將簡報儲存為檔案。將檔名與儲存格式傳遞給該方法。以下範例說明如何使用 Aspose.Slides 儲存簡報。

```cs
// 實例化代表簡報檔案的 Presentation 類別。
using (Presentation presentation = new Presentation())
{
    // 在此執行一些工作…
    
    // 將簡報儲存至檔案。
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **將簡報儲存至串流**

您可以將輸出串流傳遞給 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的 `Save` 方法，以將簡報儲存至串流。簡報可以寫入多種串流類型。以下範例建立一個新簡報，並將其儲存至檔案串流。

```cs
// 實例化代表簡報檔案的 Presentation 類別。
using (Presentation presentation = new Presentation())
{
    using (FileStream fileStream = new FileStream("Output.pptx", FileMode.Create))
    {
        // 將簡報儲存至串流。
        presentation.Save(fileStream, SaveFormat.Pptx);
    }
}
```

## **使用預先定義的檢視類型儲存簡報**

Aspose.Slides 讓您透過 [ViewProperties](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/viewproperties/) 類別設定 PowerPoint 開啟產生的簡報時的初始檢視。將 [LastView](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/viewproperties/lastview/) 屬性設定為 [ViewType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/viewtype/) 列舉中的值。

```cs
using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```

## **以 Strict Office Open XML 格式儲存簡報**

Aspose.Slides 允許您以 Strict Office Open XML 格式儲存簡報。使用 [PptxOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/pptxoptions/) 類別，並在儲存時設定其 conformance 屬性。如果將 `Conformance.Iso29500_2008_Strict` 設為 true，輸出檔案將以 Strict Office Open XML 格式儲存。

以下範例建立簡報並以 Strict Office Open XML 格式儲存。

```cs
PptxOptions options = new PptxOptions()
{
    Conformance = Conformance.Iso29500_2008_Strict
};

// 實例化代表簡報檔案的 Presentation 類別。
using (Presentation presentation = new Presentation())
{
    // 以嚴格 Office Open XML 格式儲存簡報。
    presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
}
```

## **以 Zip64 模式儲存 Office Open XML 格式的簡報**

Office Open XML 檔案是 ZIP 壓縮檔，對未壓縮檔案大小、壓縮後檔案大小以及總檔案大小皆限制為 4 GB（2^32 位元組），且檔案數量上限為 65 535（2^16‑1）。ZIP64 格式擴充可將這些限制提升至 2^64。

[IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/ipptxoptions/zip64mode/) 屬性讓您在儲存 Office Open XML 檔案時選擇何時使用 ZIP64 格式擴充。

此屬性提供以下模式：

- `IfNecessary`：僅在簡報超過上述限制時使用 ZIP64 格式擴充。這是預設模式。
- `Never`：永不使用 ZIP64 格式擴充。
- `Always`：始終使用 ZIP64 格式擴充。

以下程式碼示範如何在啟用 ZIP64 格式擴充的情況下將簡報儲存為 PPTX 檔案：

```cs
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        Zip64Mode = Zip64Mode.Always
    });
}
```

{{% alert title="NOTE" color="warning" %}}
當您以 `Zip64Mode.Never` 儲存時，如果簡報無法以 ZIP32 格式儲存，將拋出 [PptxException](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/pptxexception/)。
{{% /alert %}}

## **以 Office Open XML 格式儲存簡報並設定壓縮等級**

處理大型簡報時，您可以調整壓縮等級，以在檔案大小與處理時間之間取得平衡。根據需求，您可能偏好較快的處理速度或較小的輸出檔案。

Aspose.Slides 提供 [IPptxOptions.CompressionLevel](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/ipptxoptions/compressionlevel/) 屬性，讓您在以 Office Open XML 格式儲存簡報時指定使用的壓縮等級。

可用的壓縮等級如下：

- **None**：未套用壓縮。檔案將原樣儲存。
- **Level1**：最快的壓縮速度，但壓縮率最低。
- **Level2**：較快的壓縮速度，壓縮率略佳於 **Level1**。
- **Level3**：在處理時間上有適度影響，提供比 **Level2** 更好的壓縮效果。
- **Level4**：提供比 **Level3** 更佳的壓縮效果。
- **Level5**：在 **Level4** 基礎上進一步提升壓縮，同時增加處理時間。
- **Level6**：標準壓縮，兼顧處理速度與檔案大小。這是*預設壓縮等級*。
- **Level7**：提供比 **Level6** 更好的壓縮，但處理速度較慢。
- **Level8**：提供比 **Level7** 更好的壓縮。
- **Level9**：最高壓縮率。可產生最小的檔案大小，但需要最長的處理時間。

以下範例示範如何在 *不壓縮* 的情況下將簡報儲存為 PPTX 檔案：

```cs
using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-out.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.None
    });
}
```

這個範例示範如何在 *最高壓縮* 的情況下將簡報儲存為 PPTX 檔案：

```cs
using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-level9.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.Level9
    });
}
```

## **儲存簡報時不重新整理縮圖**

[PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/ipptxoptions/refreshthumbnail/) 屬性控制儲存簡報為 PPTX 時是否重新產生縮圖：

- 設為 `true` 時，儲存過程中會重新整理縮圖。這是預設值。
- 設為 `false` 時，保留目前的縮圖。如果簡報沒有縮圖，則不會產生。

以下程式碼示範將簡報儲存為 PPTX，且不重新整理縮圖。

```cs
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        RefreshThumbnail = false
    });
}
```

{{% alert title="Info" color="info" %}}
此選項有助於縮短以 PPTX 格式儲存簡報所需的時間。
{{% /alert %}}

## **以百分比方式取得儲存進度更新**

[IProgressCallback](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iprogresscallback/) 介面透過 [ISaveOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/isaveoptions/) 介面的 `ProgressCallback` 屬性以及抽象的 [SaveOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/saveoptions/) 類別使用。將 IProgressCallback 的實作指派給 `ProgressCallback`，即可在儲存過程中以百分比接收進度更新。

以下程式碼片段示範如何使用 `IProgressCallback`。

```cs
ISaveOptions saveOptions = new PdfOptions();
saveOptions.ProgressCallback = new ExportProgressHandler();

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pdf", SaveFormat.Pdf, saveOptions);
}
```

```cs
class ExportProgressHandler : IProgressCallback
{
    public void Reporting(double progressValue)
    {
        // 在此使用進度百分比值。
        int progress = Convert.ToInt32(progressValue);

        Console.WriteLine(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Aspose 已開發一個使用其 API 的[免費 PowerPoint Splitter 應用程式](https://products.aspose.app/slides/zh-hant/splitter)。此應用程式可透過將選取的投影片另存為新的 PPTX 或 PPT 檔案，將簡報切分為多個檔案。
{{% /alert %}}

## **常見問題**

**是否支援「快速儲存」（增量儲存）只寫入變更？**

不支援。每次儲存都會產生完整的目標檔案，未提供增量「快速儲存」功能。

**從多個執行緒同時儲存同一個 Presentation 實例是否為執行緒安全？**

不安全。`Presentation` 實例 **不是執行緒安全** 的（/slides/zh-hant/net/multithreading/），請只在單一執行緒中儲存。

**儲存時超連結與外部連結的檔案會發生什麼事？**

[超連結](/slides/zh-hant/net/manage-hyperlinks/) 會被保留。外部連結的檔案（例如使用相對路徑的影片）不會自動複製——請確保相關路徑仍可存取。

**我可以設定/儲存文件的中繼資料（作者、標題、公司、日期）嗎？**

可以。支援標準的[文件屬性](/slides/zh-hant/net/presentation-properties/)，並會在儲存時寫入檔案。