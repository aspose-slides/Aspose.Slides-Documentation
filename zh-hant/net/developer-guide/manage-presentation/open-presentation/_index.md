---
title: .NET 中開啟簡報
linktitle: 開啟簡報
type: docs
weight: 20
url: /zh-hant/net/open-presentation/
keywords:
- 打開 PowerPoint
- 打開簡報
- 打開 PPTX
- 打開 PPT
- 打開 ODP
- 載入簡報
- 載入 PPTX
- 載入 PPT
- 載入 ODP
- 受保護的簡報
- 大型簡報
- 外部資源
- 二進位物件
- .NET
- C#
- Aspose.Slides
description: "了解如何在 C# 中開啟 PowerPoint 與 OpenDocument 簡報、提供開啟密碼、控制資源載入，並使用 Aspose.Slides for .NET 減少記憶體使用。"
---
## **簡介**

[Aspose.Slides for .NET](https://products.aspose.com/slides/zh-hant/net/) 可以從檔案和串流載入 PowerPoint 與 OpenDocument 簡報。載入簡報後，您可以檢查其結構、編輯投影片、管理資源，並以原始格式或其他支援的格式儲存。

載入行為可以透過 [LoadOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/loadoptions/) 類別自訂。例如，您可以提供開啟密碼、將大型二進位物件保留在受管理記憶體之外、控制外部資源，或省略嵌入的二進位資料。

## **開啟簡報**

載入檔案或串流後，您可以[判斷其原始簡報格式](/slides/zh-hant/net/detect-presentation-source-format/)以決定應用程式如何處理它。

若要開啟現有簡報，請將其檔案路徑傳遞給[Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 建構式。使用完畢後請釋放（Dispose）簡報，以便即時釋放檔案句柄、暫存資料及其他資源。

以下 C# 範例示範如何開啟簡報並取得投影片數量：

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

## **開啟受密碼保護的簡報**

開啟密碼會加密簡報內容。若要載入完整簡報，請將正確的密碼指派給[LoadOptions.Password](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/loadoptions/password/)，並將此選項傳遞給[Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 建構式。若密碼缺失或不正確，載入會失敗。

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-presentation.pptx", loadOptions);

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

有關密碼偵測、驗證與加密工作流程，請參閱[Password-Protect Presentations](/slides/zh-hant/net/password-protected-presentation/)。如果已加密的簡報特意以公開文件屬性儲存，則即使未提供密碼也能讀取這些屬性；請參閱[Manage Presentation Properties](/slides/zh-hant/net/presentation-properties/)。

## **開啟大型簡報**

[LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/loadoptions/blobmanagementoptions/) 控制 Aspose.Slides 處理大型二進位物件（例如影像、音訊與視訊）的方式。您可以保持來源檔案被鎖定、允許使用暫存檔案，並限制保留在記憶體中的 BLOB 資料量。

以下 C# 程式碼示範載入大型簡報（例如 2 GB）：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

const string filePath = "large-presentation.pptx";

var loadOptions = new LoadOptions
{
    BlobManagementOptions =
    {
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
        IsTemporaryFilesAllowed = true,
        MaxBlobsBytesInMemory = 10 * 1024 * 1024
    }
};

using var presentation = new Presentation(filePath, loadOptions);

presentation.Slides[0].Name = "Large presentation";
presentation.Save("large-presentation-copy.pptx", SaveFormat.Pptx);
```

{{% alert color="info" title="Note" %}}
使用 `PresentationLockingBehavior.KeepLocked` 時，來源檔案會保持鎖定狀態，直至 `Presentation` 物件被釋放。物件存活期間，請勿移動、覆寫或刪除來源檔案。

Aspose.Slides 可能在載入時複製輸入串流的內容。對於大型簡報而言，檔案路徑通常比串流更有效率。請參閱[Manage BLOBs](/slides/zh-hant/net/manage-blob/)以取得其他儲存與記憶體管理選項。
{{% /alert %}}

## **控制外部資源**

[LoadOptions.ResourceLoadingCallback](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/loadoptions/resourceloadingcallback/) 接受一個 [IResourceLoadingCallback](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iresourceloadingcallback/) 實作。回呼函式可以提供替代資料、重新導向資源、使用預設載入器，或跳過資源。當簡報包含必須依照應用程式特定安全或儲存規則解析的外部影像時，這非常有用。

```csharp
using System;
using System.IO;
using Aspose.Slides;

internal static class OpenPresentationExample
{
    private static void Main()
    {
        var loadOptions = new LoadOptions
        {
            ResourceLoadingCallback = new ImageLoadingHandler()
        };

        using var presentation = new Presentation("presentation-with-external-images.pptx", loadOptions);
        Console.WriteLine("Slide count: " + presentation.Slides.Count);
    }

    private sealed class ImageLoadingHandler : IResourceLoadingCallback
    {
        public ResourceLoadingAction ResourceLoading(IResourceLoadingArgs args)
        {
            var isJpeg = args.OriginalUri.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase);
            if (!isJpeg || !File.Exists("approved-image.jpg"))
            {
                return ResourceLoadingAction.Skip;
            }

            var imageData = File.ReadAllBytes("approved-image.jpg");
            args.SetData(imageData);
            return ResourceLoadingAction.UserProvided;
        }
    }
}
```

## **載入不含嵌入二進位物件的簡報**

簡報可能包含應用程式不需要或不想保留的嵌入式二進位資料。例如包括：

- VBA 專案，可透過 [IPresentation.VbaProject](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipresentation/vbaproject/) 取得；
- 嵌入的 OLE 資料，可透過 [IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/) 取得；
- ActiveX 控制項資料，可透過 [IControl.ActiveXControlBinary](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icontrol/activexcontrolbinary/) 取得。

將 [LoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/loadoptions/deleteembeddedbinaryobjects/) 設為 `true`，即可在載入時移除這些二進位資料。將載入後的簡報儲存，即可保留已淨化的結果。

此選項可減少不需要的嵌入式負載的暴露風險，但它並非完整的惡意程式偵測或內容淨化系統。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions
{
    DeleteEmbeddedBinaryObjects = true
};

using var presentation = new Presentation("presentation-with-embedded-data.pptx", loadOptions);

presentation.Save("presentation-without-embedded-data.pptx", SaveFormat.Pptx);
```

## **常見問題**

**如何判斷檔案已損毀且無法開啟？**

Aspose.Slides 會在載入期間拋出解析或格式例外。請將此失敗與密碼錯誤的例外分開處理，以便應用程式能正確回報原因。

**如果缺少必要的字型會發生什麼情況？**

簡報仍然可以載入，但呈現與匯出時可能會使用替代字型。您可以[設定字型替代](/slides/zh-hant/net/font-substitution/)或[提供自訂字型](/slides/zh-hant/net/custom-font/)以使輸出更可預測。

**載入簡報時是否同時載入其嵌入的媒體？**

嵌入的音訊與視訊可透過簡報物件模型存取。外部資源會根據已設定的資源載入行為解析；如果無法存取其位置，則可能無法使用。