---
title: 在 .NET 中判斷原始簡報格式
linktitle: 來源格式
type: docs
weight: 35
url: /zh-hant/net/detect-presentation-source-format/
keywords:
- 來源格式
- 偵測簡報格式
- PowerPoint
- OpenDocument
- 簡報
- PPT
- PPTX
- C#
- .NET
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 在 C# 中讀取已載入簡報的原始格式、比較偵測 API，並處理檔案、串流與舊版格式。"
---
## **概觀**

載入簡報後，請讀取唯讀的 [Presentation.SourceFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/sourceformat/) 屬性以確定其原始格式。此屬性亦可透過 [IPresentation.SourceFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipresentation/sourceformat/) 取得。當後續處理取決於載入此實例的格式時，請使用它。

來源格式與為輸出檔案選擇的 [SaveFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/saveformat/) 不同。將檔案儲存為其他格式不會變更現有實例的來源格式。

## **讀取檔案的來源格式**

此範例需要現有的 `sample.pptx` 檔案。它載入該檔案，並使用 [Presentation.SourceFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/sourceformat/) 來選擇應用程式的處理政策，而非依檔名。變更輸入路徑以測試其他格式。範例會印出選取的政策；請以您的應用程式邏輯取代這些訊息。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

switch (presentation.SourceFormat)
{
    case SourceFormat.Ppt:
    case SourceFormat.Pps:
    case SourceFormat.Pot:
        Console.WriteLine("Use the legacy PowerPoint processing policy.");
        break;
    case SourceFormat.Pptx:
        Console.WriteLine("Use the standard PPTX processing policy.");
        break;
    default:
        Console.WriteLine($"Use the general policy for {presentation.SourceFormat}.");
        break;
}
```

## **識別支援的值**

[SourceFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/sourceformat/) 列舉區分以下簡報格式。下列副檔名為慣用的副檔名，並非重新建構原始檔名。

| SourceFormat 值 | 副檔名 | 格式 |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint 97–2003 簡報 |
| `Pptx` | `.pptx` | Office Open XML 簡報 |
| `Pptm` | `.pptm` | 支援巨集的 Office Open XML 簡報 |
| `Pps` | `.pps` | PowerPoint 97–2003 投影片放映 |
| `Ppsx` | `.ppsx` | Office Open XML 投影片放映 |
| `Ppsm` | `.ppsm` | 支援巨集的 Office Open XML 投影片放映 |
| `Pot` | `.pot` | PowerPoint 97–2003 範本 |
| `Potx` | `.potx` | Office Open XML 範本 |
| `Potm` | `.potm` | 支援巨集的 Office Open XML 範本 |
| `Odp` | `.odp` | OpenDocument 簡報 |
| `Otp` | `.otp` | OpenDocument 簡報範本 |
| `Fodp` | `.fodp` | Flat XML ODF 簡報 |
| `Xml` | `.xml` | PowerPoint XML 簡報 |

## **讀取串流的來源格式**

此範例需要現有的 `sample.pps` 檔案。將其位元組讀入記憶體串流，以模擬未提供檔名的輸入，例如資料庫值或上傳的位元組陣列。[Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 建構函式僅接受串流。

```csharp
using System;
using System.IO;
using Aspose.Slides;

var bytes = File.ReadAllBytes("sample.pps");
using var stream = new MemoryStream(bytes);
using var presentation = new Presentation(stream);

Console.WriteLine($"Source format: {presentation.SourceFormat}");
```

PPT、PPS 與 POT 使用相同的底層二進位格式。以檔案路徑載入時，副檔名可協助區分投影片放映或範本。若無檔名，舊版的 PPS 與 POT 內容可能會被報告為 `SourceFormat.Ppt`；上述的 PPS 範例會報告 `Ppt`。

若您的應用程式必須保留此區分，請另行保留原始檔名或子類型中繼資料。副檔名對於這些舊版子類型是一個有用的提示，但不應成為辨識任意簡報內容的唯一依據。

## **比較載入前後的偵測**

當需要在載入完整簡報物件模型前檢查檔案時，請使用 [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentationfactory/getpresentationinfo/) 與 [IPresentationInfo.LoadFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipresentationinfo/loadformat/)。當實例已存在時，請使用 [Presentation.SourceFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/sourceformat/)。

此範例需要 `sample.pptx`，並對兩次檢查皆印出 `Pptx`。在正式環境中，請根據處理階段選擇適當的 API；已載入的簡報不需要再次檢查僅為取得其來源格式。

```csharp
using System;
using Aspose.Slides;

var path = "sample.pptx";
var information = PresentationFactory.Instance.GetPresentationInfo(path);
Console.WriteLine($"Before loading: {information.LoadFormat}");

using var presentation = new Presentation(path);
Console.WriteLine($"After loading: {presentation.SourceFormat}");
```

結果使用不同的列舉類型：[LoadFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/loadformat/) 與 [SourceFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/sourceformat/)。請勿透過轉換其數值來比較，亦不要假設每種格式皆有相同的偵測結果。在下方描述的儲存後重新開啟檢查中，PowerPoint XML 於載入前被報告為 `LoadFormat.Unknown`，載入後則為 `SourceFormat.Xml`。

## **分離來源與輸出格式**

此範例需要 `sample.pptx`，並寫入 `converted.odp`。它在儲存原始實例前後皆印出 `Pptx`。只有從 ODP 輸出載入的新實例會報告 `Odp`。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
Console.WriteLine($"Before saving: {presentation.SourceFormat}");

presentation.Save("converted.odp", SaveFormat.Odp);
Console.WriteLine($"After saving: {presentation.SourceFormat");

using var reopened = new Presentation("converted.odp");
Console.WriteLine($"Reopened output: {reopened.SourceFormat}");
```

使用 `new Presentation()` 從頭建立的簡報會報告 `SourceFormat.Pptx`。它沒有輸入檔案：這是新建立實例的預設值，並不表示已載入 PPTX 檔案。如果此區分重要，請另行追蹤您的應用程式是建立還是載入該實例。

## **將來源格式對應至副檔名**

以下範例需要 `sample.pptx`。它將每個目前支援的 [SourceFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/sourceformat/) 值對應到慣用的副檔名，且不解析輸入檔名。備援機制避免對未辨識的值默默指派副檔名。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var extension = presentation.SourceFormat switch
{
    SourceFormat.Ppt => ".ppt",
    SourceFormat.Pptx => ".pptx",
    SourceFormat.Pptm => ".pptm",
    SourceFormat.Pps => ".pps",
    SourceFormat.Ppsx => ".ppsx",
    SourceFormat.Ppsm => ".ppsm",
    SourceFormat.Pot => ".pot",
    SourceFormat.Potx => ".potx",
    SourceFormat.Potm => ".potm",
    SourceFormat.Odp => ".odp",
    SourceFormat.Otp => ".otp",
    SourceFormat.Fodp => ".fodp",
    SourceFormat.Xml => ".xml",
    _ => null
};

Console.WriteLine(extension ?? "No extension mapping is available.");
```

此對應不會轉換檔案或恢復在串流載入時遺失的舊版 PPS/POT 子類型。實際儲存時，請明確選擇 [SaveFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/saveformat/)，或使用於 [Save Presentations in Their Original Format](/slides/zh-hant/net/save-presentation/#save-presentations-in-their-original-format) 中示範的轉換方式。

## **透過儲存與重新開啟驗證格式**

此完整範例會建立簡報並在工作目錄寫入三個檔案，若同名檔案已存在則覆寫。它會以路徑及記憶體串流兩種方式重新開啟每個輸出。對於 PPTX 與 ODP，兩條路徑皆報告儲存的格式。對於 PPS，使用路徑載入會報告 `Pps`，而在未提供檔名的情況下載入相同位元組則報告 `Ppt`。

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var formats = new[] { SaveFormat.Pptx, SaveFormat.Odp, SaveFormat.Pps };

foreach (var format in formats)
{
    var path = $"roundtrip.{format.ToString().ToLowerInvariant()}";
    presentation.Save(path, format);

    using var fromFile = new Presentation(path);
    var bytes = File.ReadAllBytes(path);
    using var stream = new MemoryStream(bytes);
    using var fromStream = new Presentation(stream);

    Console.WriteLine($"{format}: file={fromFile.SourceFormat}, stream={fromStream.SourceFormat}");
}
```

對上述所有列出的格式進行相同檢查，對於使用相符副檔名產生的簡報，得到以下結果：

| 已儲存格式 | 從檔案路徑取得的 SourceFormat | 從無檔名串流取得的 SourceFormat |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | 分別為 `Pptx`、`Pptm` | 與檔案路徑相同 |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | 分別為 `Ppsx`、`Ppsm` | 與檔案路徑相同 |
| POT | `Pot` | `Ppt` |
| POTX, POTM | 分別為 `Potx`、`Potm` | 與檔案路徑相同 |
| ODP, OTP | 分別為 `Odp`、`Otp` | 與檔案路徑相同 |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

在這些檢查中，唯一的來源格式正規化是將無檔名串流的 PPS/POT 轉為 `Ppt`。此表說明格式辨識，而非在轉換過程中保留每項簡報功能。

## **常見問題**

**將已從 PPTX 載入的簡報儲存為 ODP 會改變來源格式嗎？**

不會。現有的實例仍會報告 `Pptx`。從儲存的 ODP 檔案載入的實例則報告 `Odp`。

**串流能否永遠區分舊版簡報、投影片放映與範本？**

不能。PPT、PPS 與 POT 共享相同的二進位格式。若需要此區分，請另行保留檔名或子類型中繼資料。

**如果簡報已載入，我應該使用哪個 API？**

請讀取 [Presentation.SourceFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/sourceformat/)。在載入前檢查時，請使用 [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentationfactory/getpresentationinfo/)。