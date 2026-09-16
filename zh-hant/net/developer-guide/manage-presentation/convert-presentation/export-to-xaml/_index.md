---
title: 在 .NET 中將簡報匯出為 XAML
linktitle: 簡報至 XAML
type: docs
weight: 30
url: /zh-hant/net/export-to-xaml/
keywords:
- 匯出 PowerPoint
- 匯出 OpenDocument
- 匯出 簡報
- 轉換 PowerPoint
- 轉換 OpenDocument
- 轉換 簡報
- PowerPoint 轉 XAML
- OpenDocument 轉 XAML
- 簡報 轉 XAML
- PPT 轉 XAML
- PPTX 轉 XAML
- ODP 轉 XAML
- 將 PPT 儲存為 XAML
- 將 PPTX 儲存為 XAML
- 將 ODP 儲存為 XAML
- 匯出 PPT 為 XAML
- 匯出 PPTX 為 XAML
- 匯出 ODP 為 XAML
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides 在 .NET 中將 PowerPoint 與 OpenDocument 投影片轉換為 XAML——快速、無需 Office、保持版面不變的解決方案。"
---
## **概觀**

本文說明如何使用 Aspose.Slides 將 PowerPoint 簡報匯出為 XAML。它包含 XAML 的簡要介紹，展示如何使用預設設定將簡報儲存為 XAML，並示範如何透過 [XamlOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export.xaml/xamloptions/) 自訂匯出，包括匯出隱藏的投影片。本文亦回答有關備用字型、XAML 堆疊相容性以及隱藏投影片匯出行為的幾個常見問題。

## **關於 XAML**

XAML 是一種基於 XML 的標記語言，用於在 WPF（Windows Presentation Foundation）、UWP（Universal Windows Platform）與 Xamarin.Forms 等框架中描述使用者介面。

您可以在視覺設計師中使用 XAML 檔案，或直接撰寫與編輯標記。

## **使用預設選項將簡報匯出為 XAML**

以下 C# 範例說明如何使用預設設定將簡報匯出為 XAML：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

using var presentation = new Presentation("pres.pptx");
var xamlOptions = new XamlOptions();
presentation.Save(xamlOptions);
```

預設情況下，匯出的投影片會儲存於程式執行目錄的 `pres` 子資料夾中，該目錄由 [Directory.GetCurrentDirectory](https://learn.microsoft.com/en-us/dotnet/api/system.io.directory.getcurrentdirectory) 取得。資料夾會自動建立，所需的圖片也會一起儲存於該處。

輸出資料夾名稱取自來源檔案名稱（不含副檔名）。對於 `pres.pptx`，輸出檔案名稱為 `pres/Slide_1.xaml`、`pres/Slide_2.xaml`，依此類推。即使您傳入簡報的絕對路徑，輸出資料夾仍會相對於目前工作目錄建立，而不會與輸入檔案同目錄。

## **使用自訂選項將簡報匯出為 XAML**

使用 [IXamlOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export.xaml/ixamloptions/) 介面來控制 Aspose.Slides 如何將簡報匯出為 XAML。

若要將輸出儲存至自訂位置，請實作 [IXamlOutputSaver](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export.xaml/ixamloutputsaver/)，並將您的實作實例指派給 [XamlOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export.xaml/xamloptions/) 的 [OutputSaver](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export.xaml/xamloptions/outputsaver/) 屬性。

若要在 XAML 輸出中包含隱藏投影片，將 [ExportHiddenSlides](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) 屬性設定為 `true`，如以下 C# 範例所示：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

using var presentation = new Presentation("pres.pptx");
var xamlOptions = new XamlOptions { ExportHiddenSlides = true };
presentation.Save(xamlOptions);
```

## **擷取所有產生的 XAML 成果物**

XAML 匯出可能為每張匯出的投影片產生一個 XAML 文件，此外還會產生獨立的圖片與支援資源。將自訂的 [IXamlOutputSaver](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export.xaml/ixamloutputsaver/) 指派給 [XamlOptions.OutputSaver](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export.xaml/xamloptions/outputsaver/)，即可接收這些成果物，而非使用預設的檔案系統儲存器。使用接受 XAML 選項的 [Presentation.Save](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/save/) 方法開始匯出。

### **了解回呼生命週期**

匯出器會針對每個產生的成果物分別呼叫 [IXamlOutputSaver.Save](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export.xaml/ixamloutputsaver/save/)：

- `path` 用來辨識成果物，可能包含相對目錄。請保留此資訊，因為 XAML 可能使用相對路徑來參照資源。
- `data` 包含成果物的位元組。圖片與其他二進位資源不要解碼為文字。
- 儲存器須在回傳前保留或永久寫入這些資料。範例會將每個位元組陣列複製至應用程式自行管理的記憶體中。
- 只有當簡報儲存操作回傳且每個回呼皆成功完成時，才視為匯出成功。請勿吞噬儲存錯誤或啟動未觀察的背景寫入。若持久化在之後才發生，必須等該步驟成功後才報告整體成功。

[XamlOptions.ExportHiddenSlides](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) 亦適用於自訂儲存器。其預設值 `false` 會排除隱藏投影片的 XAML 文件。將其設為 `true` 則會包含隱藏投影片以及匯出所需的所有資源。資源數量取決於簡報本身，請勿假設每張投影片只有一次回呼或回呼順序固定。

### **匯出至記憶體並檢查成果物**

以下完整範例會載入 `pres.pptx`，將每個成果物收集到 [Dictionary<string, byte[]>](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2) 中，並輸出其名稱、類型與位元組數。名稱會完整保留。若出現重複名稱，集合會失敗而不會靜默覆寫。

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

public static class InMemoryXamlExample
{
    public static void Run()
    {
        var saver = new MemoryXamlSaver();
        using var presentation = new Presentation("pres.pptx");
        var options = new XamlOptions { OutputSaver = saver, ExportHiddenSlides = true };
        presentation.Save(options);

        bool inspectXamlText = false;
        foreach (var artifact in saver.Artifacts)
        {
            var extension = Path.GetExtension(artifact.Key).ToLowerInvariant();
            bool isXaml = extension == ".xaml";
            bool isImage = extension is ".png" or ".jpg" or ".jpeg" or ".gif" or ".bmp" or ".tif" or ".tiff" or ".svg";
            var kind = isXaml ? "slide XAML" : isImage ? "image" : "supporting resource";
            Console.WriteLine($"{artifact.Key}: {artifact.Value.Length} bytes ({kind})");

            // 僅解碼 XAML，且僅在需要文字檢查時。
            if (isXaml && inspectXamlText)
            {
                var markup = Encoding.UTF8.GetString(artifact.Value);
                Console.WriteLine(markup);
            }
        }
    }

    private sealed class MemoryXamlSaver : IXamlOutputSaver
    {
        public Dictionary<string, byte[]> Artifacts { get; } = new Dictionary<string, byte[]>(StringComparer.Ordinal);

        public void Save(string path, byte[] data)
        {
            var retainedData = (byte[])data.Clone();
            Artifacts.Add(path, retainedData);
        }
    }
}
```

從您的應用程式呼叫 `InMemoryXamlExample.Run`。檢查時可使用副檔名判斷；請保留所有成果物，包括不熟悉的資源類型。儲存或傳輸時請保持位元組不變。僅在需要文字處理的 XAML 上使用 [Encoding.UTF8.GetString](https://learn.microsoft.com/en-us/dotnet/api/system.text.encoding.getstring)。

### **將收集的成果物打包為 ZIP 壓縮檔**

此獨立範例會收集匯出結果、驗證名稱，並將原始位元組寫入 ZIP 壓縮檔。唯一的壓縮檔名稱可區分同時執行的匯出工作。ZIP 條目使用正斜線並保留相對目錄。若名稱不安全或正規化後發生衝突，會在寫入前拒絕整個封包。

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

public static class ZipXamlExample
{
    public static void Run()
    {
        var saver = new CollectedXamlSaver();
        using var presentation = new Presentation("pres.pptx");
        var options = new XamlOptions { OutputSaver = saver, ExportHiddenSlides = false };
        presentation.Save(options);

        var entries = new Dictionary<string, byte[]>(StringComparer.OrdinalIgnoreCase);
        foreach (var artifact in saver.Artifacts)
        {
            var entryName = artifact.Key.Replace('\\', '/');
            var segments = entryName.Split('/');
            bool unsafeName = entryName.StartsWith("/", StringComparison.Ordinal) || entryName.Contains(':');
            foreach (var segment in segments)
            {
                unsafeName |= string.IsNullOrWhiteSpace(segment) || segment == "." || segment == "..";
            }

            if (unsafeName || !entries.TryAdd(entryName, artifact.Value))
            {
                Console.WriteLine($"Export rejected: unsafe or duplicate artifact name: {artifact.Key}");
                return;
            }
        }

        var archivePath = $"xaml-{Guid.NewGuid():N}.zip";
        using (var output = new FileStream(archivePath, FileMode.CreateNew, FileAccess.Write))
        using (var archive = new ZipArchive(output, ZipArchiveMode.Create))
        {
            foreach (var artifact in entries)
            {
                var entry = archive.CreateEntry(artifact.Key, CompressionLevel.Optimal);
                using var entryStream = entry.Open();
                entryStream.Write(artifact.Value, 0, artifact.Value.Length);
            }
        }

        // ZIP 目錄已在回報成功前透過釋放完成。
        Console.WriteLine($"Saved {entries.Count} artifacts to {archivePath}");
    }

    private sealed class CollectedXamlSaver : IXamlOutputSaver
    {
        public Dictionary<string, byte[]> Artifacts { get; } = new Dictionary<string, byte[]>(StringComparer.Ordinal);

        public void Save(string path, byte[] data)
        {
            var retainedData = (byte[])data.Clone();
            Artifacts.Add(path, retainedData);
        }
    }
}
```

從您的應用程式呼叫 `ZipXamlExample.Run`。範例使用 [ZipArchive](https://learn.microsoft.com/en-us/dotnet/api/system.io.compression.ziparchive) 寫入單一本地壓縮檔；匯出器本身不會寫入散落的 XAML 或圖片檔案。若要儲存至遠端，請將寫入壓縮檔的階段改為上傳收集的位元組陣列。使用匯出工作識別碼加上完整相對成果物名稱作為 Blob 金鑰，或在資料庫中以工作識別碼、相對名稱與二進位資料為欄位。只有在所有上傳完成或資料庫交易提交後才發布工作。若持久化失敗，請清除部分輸出。

對於大型簡報，自訂儲存器可以直接將每個成果物寫入應用程式儲存空間，以避免在記憶體中保留整個匯出的額外副本。匯出器仍會在呼叫儲存器前先將所有產生的成果物暫存於記憶體。從匯出器的觀點來看，請保持每個回呼同步：僅在目的地接受位元組後才回傳，並讓失敗傳回呼叫端。

### **保留資源名稱並驗證參照**

- 當目的地需要時正規化路徑分隔符，但仍保留相對目錄。除非每個產生的名稱皆唯一且資源參照仍有效，否則不要僅使用 [Path.GetFileName](https://learn.microsoft.com/en-us/dotnet/api/system.io.path.getfilename)。
- 套用目的地特定的名稱驗證。寫入散落檔案時，拒絕根目錄路徑與目錄遍歷段落，使用 [Path.GetFullPath](https://learn.microsoft.com/en-us/dotnet/api/system.io.path.getfullpath) 解析目的地，並確認其仍位於預期的匯出目錄之下（在包含檢查時也要比較目錄分隔符）。使用不含符號連結的應用程式受控目錄，以免重定向寫入。
- 為每個匯出工作使用獨立的儲存器與命名空間。依照分隔符正規化後以及目的地的大小寫敏感規則偵測衝突。
- 發布前，將每個 XAML 文件解析為 XML，檢查其檔案基礎的資源參照（例如 image `Source` 或 `ImageSource` 屬性）。將每個相對 URI 以包含該 XAML 成果物的目錄為基礎進行解析，正規化得到的儲存名稱，並確認對應的字典鍵、ZIP 條目或儲存物件是否存在。將外部 URI 與 XAML 標記表達式與相對檔名分開處理。

例如，若 `pres/Slide_1.xaml` 參照 `images/image1.png`，則必須以 `pres/images/image1.png` 的路徑儲存該資源。僅保留 `image1.png` 會導致關聯失效。若使用物件儲存，請在工作前置詞下保持相同的目錄結構，並讓這些資源 URL 可被 XAML 使用者存取。重新打開已完成的 ZIP，驗證條目名稱與資源位元組，並在目標 XAML 環境中載入代表性投影片，以確認圖片正確解析。

## **常見問題解答**

**如果原始字型在機器上不存在，如何確保字型可預測？**

在 [XamlOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export.xaml/xamloptions/) 中設定 [DefaultRegularFont](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/saveoptions/defaultregularfont/)，匯出時若找不到原始字型會使用此備用字型。這並不保證產生的 XAML 會引用備用字型，或該字型在目標機器上可用。請確保 XAML 所參照的字型在顯示環境中已安裝。

**匯出的 XAML 僅限於 WPF，還是也可用於其他 XAML 堆疊？**

Aspose.Slides 透過公開 API 匯出 WPF XAML。對其他 XAML 堆疊（如 UWP、Xamarin.Forms）的相容性不保證。請在目標環境中測試產生的標記。

**是否支援隱藏投影片，且如何避免預設匯出它們？**

預設情況下不會包含隱藏投影片。您可以透過在 [XamlOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export.xaml/xamloptions/) 中的 [ExportHiddenSlides](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) 屬性進行控制；如果不需要匯出，請保持此屬性為未啟用狀態。