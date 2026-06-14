---
title: 在 .NET 中開啟簡報
linktitle: 開啟簡報
type: docs
weight: 20
url: /zh-hant/net/open-presentation/
keywords:
- 開啟 PowerPoint
- 開啟簡報
- 開啟 PPTX
- 開啟 PPT
- 開啟 ODP
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
description: "使用 Aspose.Slides for .NET 輕鬆開啟 PowerPoint（.pptx、.ppt）和 OpenDocument（.odp）簡報—快速、可靠、功能完整。"
---
## **簡介**

除了從頭建立 PowerPoint 簡報之外，Aspose.Slides 也允許您開啟現有的簡報。載入簡報後，您可以取得其資訊，編輯投影片內容，新增投影片，移除現有投影片，等等。

## **開啟簡報**

若要開啟既有簡報，請實例化 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別，並將檔案路徑傳遞給其建構函式。

以下 C# 範例示範如何開啟簡報並取得投影片數量：

```cs
// 實例化 Presentation 類別並將檔案路徑傳遞給其建構函式。
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    // 列印簡報中的投影片總數。
    System.Console.WriteLine(presentation.Slides.Count);
}
```

## **開啟受密碼保護的簡報**

若需開啟受密碼保護的簡報，請將密碼傳入 [LoadOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/loadoptions/) 類別的 [Password](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/loadoptions/password/) 屬性，以進行解密與載入。以下 C# 程式碼示範此操作：

```cs
LoadOptions loadOptions = new LoadOptions {Password = "YOUR_PASSWORD"};
using (Presentation presentation = new Presentation("Sample.pptx", loadOptions))
{
    // 執行對已解密簡報的操作。
}
```

## **開啟大型簡報**

Aspose.Slides 提供選項—尤其是 [LoadOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/loadoptions/) 類別中的 [BlobManagementOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/loadoptions/blobmanagementoptions/) 屬性—以協助您載入大型簡報。

以下 C# 程式碼示範載入大型簡報（例如 2 GB）：

```cs
const string filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions
{
    BlobManagementOptions = 
    {
        // 選擇 KeepLocked 行為——簡報檔案在 Presentation 實例的生命週期內將保持鎖定， 
        // 但不需要載入記憶體或複製到暫存檔。
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
        IsTemporaryFilesAllowed = true,
        MaxBlobsBytesInMemory = 10 * 1024 * 1024 // 10 MB
    }
};

using (Presentation presentation = new Presentation(filePath, loadOptions))
{
    // 已載入大型簡報，可供使用，且記憶體消耗保持低水平。

    // 對簡報進行修改。
    presentation.Slides[0].Name = "Large presentation";

    // 將簡報另存為新檔案。在此操作期間，記憶體消耗仍保持低。
    presentation.Save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // 不要這麼做！會拋出 I/O 例外，因為檔案在釋放 Presentation 物件之前會被鎖定。
    File.Delete(filePath);
}

// 在此執行是可以的。來源檔案已不再被 Presentation 物件鎖定。
File.Delete(filePath);
```

{{% alert color="info" title="資訊" %}}
為了解決使用串流時的某些限制，Aspose.Slides 可能會複製串流內容。從串流載入大型簡報會導致簡報被複製，從而減慢載入速度。因此，若需載入大型簡報，我們強烈建議使用簡報檔案路徑而非串流。

在建立包含大型物件（影片、音訊、高解析度影像等）的簡報時，您可以使用 [BLOB management](/slides/zh-hant/net/manage-blob/) 以降低記憶體使用量。
{{%/alert %}}

## **控制外部資源**

Aspose.Slides 提供 [IResourceLoadingCallback](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iresourceloadingcallback/) 介面，讓您管理外部資源。以下 C# 程式碼顯示如何使用 `IResourceLoadingCallback` 介面：

```cs
LoadOptions loadOptions = new LoadOptions();
loadOptions.ResourceLoadingCallback = new ImageLoadingHandler();

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
```

```cs
public class ImageLoadingHandler : IResourceLoadingCallback
{
    public ResourceLoadingAction ResourceLoading(IResourceLoadingArgs args)
    {
        if (args.OriginalUri.EndsWith(".jpg"))
        {
            try
            {
                // 載入替代圖像。
                byte[] imageData = File.ReadAllBytes("aspose-logo.jpg");
                args.SetData(imageData);
                return ResourceLoadingAction.UserProvided;
            }
            catch (Exception)
            {
                return ResourceLoadingAction.Skip;
            }
        }
        else if (args.OriginalUri.EndsWith(".png"))
        {
            // 設定替代 URL。
            args.Uri = "http://www.google.com/images/logos/ps_logo2.png";
            return ResourceLoadingAction.Default;
        }

        // 略過所有其他圖像。
        return ResourceLoadingAction.Skip;
    }
}
```

## **載入不含嵌入式二進位物件的簡報**

PowerPoint 簡報可能包含以下類型的嵌入式二進位物件：

- VBA 專案（可透過 [IPresentation.VbaProject](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipresentation/vbaproject/) 取得）；
- OLE 物件嵌入資料（可透過 [IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/) 取得）；
- ActiveX 控制項二進位資料（可透過 [IControl.ActiveXControlBinary](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icontrol/activexcontrolbinary/) 取得）。

使用 [ILoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iloadoptions/deleteembeddedbinaryobjects/) 屬性，您可以在不載入任何嵌入式二進位物件的情況下載入簡報。

此屬性對於移除可能具惡意的二進位內容非常有用。以下 C# 程式碼示範如何在不載入任何嵌入式二進位內容的情況下載入簡報：

```cs
LoadOptions loadOptions = new LoadOptions()
{
    DeleteEmbeddedBinaryObjects = true
}

using (Presentation presentation = new Presentation("malware.ppt", loadOptions))
{
    // 對簡報執行操作。
}
```

## **常見問題**

**如何判斷檔案已損毀且無法開啟？**

載入時會拋出解析/格式驗證例外。此類錯誤常會提及 ZIP 結構無效或 PowerPoint 記錄損毀。

**開啟時如果缺少必要的字型會發生什麼情況？**

檔案仍會開啟，但之後的 [rendering/export](/slides/zh-hant/net/convert-presentation/) 可能會替換字型。請在執行環境中 [Configure font substitutions](/slides/zh-hant/net/font-substitution/) 或 [add the required fonts](/slides/zh-hant/net/custom-font/)。

**開啟時嵌入的媒體（影片/音訊）會如何處理？**

它們會作為簡報資源可供使用。如果媒體是透過外部路徑引用，請確保這些路徑在您的環境中可存取；否則在 [rendering/export](/slides/zh-hant/net/convert-presentation/) 時可能會遺漏媒體。