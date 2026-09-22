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
- 簡報存檔
- 簡報串流
- 預先定義的檢視類型
- 嚴格的 Office Open XML 格式
- Zip64 模式
- 重新整理縮圖
- 儲存進度
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 於 C# 中將 PowerPoint 與 OpenDocument 簡報儲存為檔案或串流，並設定 PPTX 輸出與進度回報。"
---
## **概觀**

在您建立簡報或[開啟現有簡報](/slides/zh-hant/net/open-presentation/)之後，使用[Presentation.Save](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/save/) 方法寫入結果。Aspose.Slides for .NET 可以將簡報儲存為檔案或串流，支援 PowerPoint、OpenDocument、PDF 以及其他格式。以下各節說明標準的儲存操作以及 PPTX 輸出的可用選項。

## **將簡報儲存至檔案**

若要將簡報儲存為檔案，請將輸出路徑和一個[SaveFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/saveformat/) 值傳遞給 [Presentation.Save](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/save/) 方法。格式值決定 Aspose.Slides 產生的檔案類型。

下面的範例建立一個簡報並將其儲存為 PPTX 檔案：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

// Add or modify presentation content here.

presentation.Save("Output.pptx", SaveFormat.Pptx);
```

## **以原始格式儲存簡報**

欲了解檔案與串流偵測範例、新建立簡報的行為，以及來源與輸出格式之差異，請參閱[確定原始簡報格式](/slides/zh-hant/net/detect-presentation-source-format/)。

在批次處理應用程式中，輸入格式可能事先未知。載入檔案後，從 [IPresentation.SourceFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipresentation/sourceformat/) 屬性讀取其原始格式。將取得的 [SourceFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/sourceformat/) 值傳遞給 [SlideUtil.ToSaveFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.util/slideutil/tosaveformat/)，以取得相對應的 [SaveFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/saveformat/) 值，然後使用 [Presentation.Save](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/save/) 來寫入修改後的簡報。

以下完整範例會處理輸入目錄中的每個檔案，更新其標題，並以載入時的格式儲存至輸出目錄：

```cs
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Util;

var inputDirectory = "Input";
var outputDirectory = "Output";

Directory.CreateDirectory(outputDirectory);

foreach (var inputPath in Directory.EnumerateFiles(inputDirectory))
{
    try
    {
        using var presentation = new Presentation(inputPath);

        var sourceFormat = presentation.SourceFormat;
        var saveFormat = SlideUtil.ToSaveFormat(sourceFormat);

        presentation.DocumentProperties.Title = "Processed by the batch application";

        var outputPath = Path.Combine(outputDirectory, Path.GetFileName(inputPath));
        presentation.Save(outputPath, saveFormat);
    }
    catch (ArgumentException exception)
    {
        Console.Error.WriteLine($"Cannot map the source format of '{inputPath}': {exception.Message}");
    }
    catch (Exception exception)
    {
        Console.Error.WriteLine($"Cannot process '{inputPath}': {exception.Message}");
    }
}
```

[SlideUtil.ToSaveFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.util/slideutil/tosaveformat/) 能將 PPT、PPTX、ODP、PPTM、PPSX、PPSM、POTX、POTM、PPS、POT、OTP、FODP 以及 PowerPoint XML 映射到其對應的簡報儲存格式。它僅映射簡報來源格式；不適用於選擇 PDF、HTML、TIFF 或影像等匯出格式。傳遞不受支援或無效的 [SourceFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/sourceformat/) 值會導致拋出 [ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception)。

舊版的 PPT、PPS 與 POT 檔案使用相同的二進位容器。若此類簡報從未帶副檔名的串流載入，PPS 或 POT 檔案可能會被辨識為 PPT。若需要保留這些舊版子類型，請另行保留原始檔名或格式中繼資料，並在選擇輸出檔名與格式時使用它們。

## **將簡報儲存至串流**

若要在不依賴最終檔案路徑的情況下寫入簡報，請傳遞可寫入的 [Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream) 和一個 [SaveFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/saveformat/) 值給 [Presentation.Save](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/save/) 方法。此方法在需從 Web 服務返回輸出、儲存於資料庫或在記憶體中處理時特別有用。

以下範例將新簡報儲存至檔案串流：

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
using var outputStream = new FileStream("Output.pptx", FileMode.Create);

presentation.Save(outputStream, SaveFormat.Pptx);
```

## **以預先定義的檢視類型儲存簡報**

您可以指定 PowerPoint 首次開啟已儲存簡報時的檢視模式。於儲存之前，將 [ViewProperties.LastView](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/viewproperties/lastview/) 屬性設定為 [ViewType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/viewtype/) 值。

以下範例將投影片母片檢視設定為初始檢視：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
```

## **以嚴格的 Office Open XML 格式儲存簡報**

若要建立符合 Office Open XML 嚴格 (Strict) 設定檔的 PPTX 檔案，請建立一個 [PptxOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/pptxoptions/) 實例，並將其 [Conformance](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/pptxoptions/conformance/) 屬性設為 `Conformance.Iso29500_2008_Strict`。之後將此選項傳遞給 [Presentation.Save](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/save/) 方法。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var options = new PptxOptions
{
    Conformance = Conformance.Iso29500_2008_Strict
};

using var presentation = new Presentation();

presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
```

## **以 Zip64 模式儲存 Office Open XML 格式的簡報**

標準的 ZIP 壓縮檔會限制每個項目的壓縮與未壓縮大小、整體壓縮檔大小以及項目數量。由於 PPTX 檔案本身即為 ZIP 壓縮檔，過大的簡報可能會超過這些限制。ZIP64 延伸可提升相關的大小與項目數限制。

使用 [PptxOptions.Zip64Mode](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/pptxoptions/zip64mode/) 屬性來控制 Aspose.Slides 是否寫入 ZIP64 延伸：

- `IfNecessary` 只有在簡報超過標準 ZIP 限制時才使用 ZIP64。這是預設模式。
- `Never` 停用 ZIP64 延伸。
- `Always` 總是寫入 ZIP64 延伸。

以下範例在輸出簡報時始終啟用 ZIP64 延伸：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    Zip64Mode = Zip64Mode.Always
};

presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, options);
```

{{% alert color="warning" title="Warning" %}}
如果將 `Zip64Mode` 設為 `Never`，且簡報無法符合標準 ZIP 限制，儲存操作會拋出 [PptxException](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/pptxexception/)。
{{% /alert %}}

## **以壓縮等級儲存 Office Open XML 格式的簡報**

對於 PPTX 輸出，您可以透過設定 [PptxOptions.CompressionLevel](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/pptxoptions/compressionlevel/) 來在儲存速度與檔案大小之間取得平衡。[CompressionLevel](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/compressionlevel/) 列舉提供以下值：

- `None`：不進行壓縮地儲存資料。
- `Level1`：提供最快的壓縮速度且產生最大的壓縮檔。
- `Level2` 到 `Level5`：逐漸偏好較小的輸出而非儲存速度。
- `Level6`：在儲存速度與檔案大小之間取得平衡。這是預設等級。
- `Level7` 與 `Level8`：更進一步偏好較小的輸出而非儲存速度。
- `Level9`：提供最強的壓縮，且需要最多的處理時間。

以下範例在不使用壓縮的情況下儲存簡報：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    CompressionLevel = CompressionLevel.None
};

presentation.Save("OutputNoCompression.pptx", SaveFormat.Pptx, options);
```

以下範例使用最高壓縮等級：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    CompressionLevel = CompressionLevel.Level9
};

presentation.Save("OutputMaximumCompression.pptx", SaveFormat.Pptx, options);
```

## **儲存簡報時不重新整理縮圖**

當簡報以 PPTX 格式儲存時，[PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/pptxoptions/refreshthumbnail/) 屬性會控制其文件縮圖：

- `true`：在儲存過程中重新產生縮圖。這是預設值。
- `false`：保留現有縮圖。若簡報沒有縮圖，Aspose.Slides 不會產生新的縮圖。

以下範例在儲存簡報時不重新整理縮圖：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    RefreshThumbnail = false
};

presentation.Save("Output.pptx", SaveFormat.Pptx, options);
```

{{% alert color="info" title="Note" %}}
停用縮圖重新整理可減少儲存 PPTX 檔案所需的時間。
{{% /alert %}}

## **以百分比顯示儲存進度更新**

若要監控儲存操作，請實作 [IProgressCallback](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iprogresscallback/) 介面，並將實作指派給 [ISaveOptions.ProgressCallback](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/isaveoptions/progresscallback/) 屬性。Aspose.Slides 會在匯出期間呼叫 [IProgressCallback.Reporting](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iprogresscallback/reporting/) 方法，傳回進度值。

以下範例將 PDF 匯出的進度報告至主控台：

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

var options = new PdfOptions
{
    ProgressCallback = new ExportProgressHandler()
};

using var presentation = new Presentation("Sample.pptx");

presentation.Save("Output.pdf", SaveFormat.Pdf, options);

class ExportProgressHandler : IProgressCallback
{
    public void Reporting(double progressValue)
    {
        var progress = Convert.ToInt32(progressValue);
        Console.WriteLine($"{progress}% of the file has been converted.");
    }
}
```

{{% alert color="info" title="Note" %}}
Aspose 提供免費的 [PowerPoint Splitter](https://products.aspose.app/slides/zh-hant/splitter)，此工具是以 Aspose.Slides API 建置，可將簡報中選取的投影片儲存為個別的 PPT 或 PPTX 檔案。
{{% /alert %}}

## **常見問題**

**Aspose.Slides 是否支援增量或「快速儲存」？**

不支援。每次儲存操作都會寫入完整的輸出檔案，而不是僅更新變更的部分。

**多執行緒能儲存同一個 Presentation 實例嗎？**

不行。[Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 實例[不是執行緒安全](/slides/zh-hant/net/multithreading/)。每次只能由單一執行緒存取與儲存該實例。

**儲存簡報時，超連結與外部連結檔案會發生什麼？**

[Hyperlinks](/slides/zh-hant/net/manage-hyperlinks/) 仍會保留在簡報中。Aspose.Slides 不會複製外部連結的檔案，因此儲存後的簡報仍必須能存取這些檔案的位置。

**我能儲存文件的中繼資料（例如作者、標題、公司與建立日期）嗎？**

可以。於儲存前設定相應的[文件屬性](/slides/zh-hant/net/presentation-properties/)，Aspose.Slides 會將它們寫入輸出檔案。