---
title: 在 C++ 中開啟簡報
linktitle: 開啟簡報
type: docs
weight: 20
url: /zh-hant/cpp/open-presentation/
keywords:
- 開啟 PowerPoint
- 開啟 OpenDocument
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
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 輕鬆開啟 PowerPoint（.pptx、.ppt）和 OpenDocument（.odp）簡報—快速、可靠、功能完整。"
---
## **簡介**

除了從頭建立 PowerPoint 簡報之外，Aspose.Slides 也允許您開啟現有的簡報。載入簡報後，您可以取得其資訊、編輯投影片內容、新增投影片、移除現有投影片，以及其他操作。

## **開啟簡報**

若要開啟現有的簡報，請實例化 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別，並將檔案路徑傳遞給其建構函式。

以下 C++ 範例示範如何開啟簡報並取得投影片數量：

```cpp
// 實例化 Presentation 類別，並將檔案路徑傳遞給其建構函式。
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// 列印簡報中的投影片總數。
Console::WriteLine(presentation->get_Slides()->get_Count());

presentation->Dispose();
```

## **開啟受密碼保護的簡報**

當需要開啟受密碼保護的簡報時，請透過 [LoadOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/loadoptions/) 類別的 [set_Password](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/loadoptions/set_password/) 方法傳入密碼，以解密並載入簡報。以下 C++ 程式碼示範此操作：

```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_Password(u"YOUR_PASSWORD");

auto presentation = MakeObject<Presentation>(u"Sample.pptx", loadOptions);
    
// 在已解密的簡報上執行操作。

presentation->Dispose();
```

## **開啟大型簡報**

Aspose.Slides 提供選項，尤其是 [LoadOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/loadoptions/) 類別中的 [get_BlobManagementOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/loadoptions/get_blobmanagementoptions/) 方法，可協助您載入大型簡報。

以下 C++ 程式碼示範載入大型簡報（例如 2 GB）：

```cpp
auto filePath = u"LargePresentation.pptx";

auto loadOptions = MakeObject<LoadOptions>();
// 選擇 KeepLocked 行為—簡報檔案在整個物件生命週期內會保持鎖定
// 但不需要載入至記憶體或複製到暫存檔案。
loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
loadOptions->get_BlobManagementOptions()->set_IsTemporaryFilesAllowed(true);
loadOptions->get_BlobManagementOptions()->set_MaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

auto presentation = MakeObject<Presentation>(filePath, loadOptions);

// 已載入大型簡報，可直接使用，且記憶體消耗保持低。

// 對簡報進行修改。
presentation->get_Slide(0)->set_Name(u"Large presentation");

// 將簡報儲存為另一個檔案。此操作期間記憶體消耗保持低。
presentation->Save(u"LargePresentation-copy.pptx", SaveFormat::Pptx);

// 不要這麼做！會拋出 I/O 例外，因為檔案在簡報物件釋放前仍被鎖定。
File::Delete(filePath);

presentation->Dispose();

// 這裡可以這麼做。來源檔案已不再被簡報物件鎖定。
File::Delete(filePath);
```

{{% alert color="info" title="Info" %}}
為了解決在處理串流時的某些限制，Aspose.Slides 可能會複製串流的內容。從串流載入大型簡報會導致簡報被複製，進而降低載入速度。因此，當您需要載入大型簡報時，我們強烈建議使用簡報檔案路徑而非串流。

在建立包含大型物件（影片、音訊、高解析度影像等）的簡報時，您可以使用 [BLOB management](/slides/zh-hant/cpp/manage-blob/) 以降低記憶體使用量。
{{%/alert %}}

## **控制外部資源**

Aspose.Slides 提供 [IResourceLoadingCallback](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iresourceloadingcallback/) 介面，讓您管理外部資源。以下 C++ 程式碼示範如何使用 `IResourceLoadingCallback` 介面：

```cpp
class ImageLoadingHandler : public IResourceLoadingCallback
{
public:
    ResourceLoadingAction ResourceLoading(SharedPtr<IResourceLoadingArgs> args) override
    {
        if (args->get_OriginalUri().EndsWith(u".jpg"))
        {
            try
            {
                // 載入替代影像。
                auto imageData = File::ReadAllBytes(u"aspose-logo.jpg");
                args->SetData(imageData);
                return ResourceLoadingAction::UserProvided;
            }
            catch (Exception&)
            {
                return ResourceLoadingAction::Skip;
            }
        }
        else if (args->get_OriginalUri().EndsWith(u".png"))
        {
            // 設定替代 URL。
            args->set_Uri(u"http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction::Default;
        }

        // 跳過所有其他影像。
        return ResourceLoadingAction::Skip;
    }
};
```

```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_ResourceLoadingCallback(MakeObject<ImageLoadingHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx", loadOptions);
```

## **載入不含嵌入二進位物件的簡報**

PowerPoint 簡報可能包含以下類型的嵌入二進位物件：

- VBA 專案（可透過 [IPresentation::get_VbaProject](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentation/get_vbaproject/) 存取）；
- OLE 物件嵌入資料（可透過 [IOleEmbeddedDataInfo::get_EmbeddedFileData](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ioleembeddeddatainfo/get_embeddedfiledata/) 存取）；
- ActiveX 控制項二進位資料（可透過 [IControl::get_ActiveXControlBinary](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icontrol/get_activexcontrolbinary/) 存取）。

使用 [ILoadOptions::set_DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iloadoptions/set_deleteembeddedbinaryobjects/) 方法，您可以載入不含任何嵌入二進位物件的簡報。

此方法可用於移除潛在惡意的二進位內容。以下 C++ 程式碼示範如何載入不含任何嵌入二進位內容的簡報：

```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_DeleteEmbeddedBinaryObjects(true);

auto presentation = MakeObject<Presentation>(u"malware.ppt", loadOptions);

// Perform operations on the presentation.

presentation->Dispose();
```

## **常見問題**

**如何判斷檔案已損毀且無法開啟？**

載入時會拋出解析/格式驗證例外。此類錯誤通常會提及 ZIP 結構無效或 PowerPoint 記錄損毀。

**開啟時如果缺少必要字型會發生什麼情況？**

檔案仍會開啟，但之後的 [rendering/export](/slides/zh-hant/cpp/convert-presentation/) 可能會使用替代字型。請於執行時環境中 [Configure font substitutions](/slides/zh-hant/cpp/font-substitution/) 或 [add the required fonts](/slides/zh-hant/cpp/custom-font/)。

**開啟時嵌入的媒體（影片/音訊）會如何處理？**

它們會作為簡報資源可供使用。若媒體是透過外部路徑引用，請確認這些路徑在您的環境中可存取；否則在 [rendering/export](/slides/zh-hant/cpp/convert-presentation/) 時可能會省略該媒體。