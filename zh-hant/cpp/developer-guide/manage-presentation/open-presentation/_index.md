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
description: "了解如何在 C++ 中開啟 PowerPoint 與 OpenDocument 簡報、提供開啟密碼、控制資源載入，並使用 Aspose.Slides for C++ 減少記憶體使用。"
---
## **簡介**

[Aspose.Slides for C++](https://products.aspose.com/slides/zh-hant/cpp/) 可以從檔案和串流載入 PowerPoint 與 OpenDocument 簡報。載入簡報後，您可以檢查其結構、編輯投影片、管理資源，並以原始或其他支援的格式儲存。

載入行為可透過 [LoadOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/loadoptions/) 類別自訂。例如，您可以提供開啟密碼、將大型二進位物件保留在記憶體外、控制外部資源，或省略內嵌的二進位資料。

## **開啟簡報**

若要開啟現有簡報，將其檔案路徑傳遞給 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 建構式。使用完畢後請釋放簡報，以便及時釋放檔案句柄、暫存資料及其他資源。

以下 C++ 範例顯示如何開啟簡報並取得投影片數量：

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());

presentation->Dispose();
```

## **開啟受密碼保護的簡報**

開啟密碼會加密簡報內容。若要載入完整簡報，將正確的密碼傳遞給 [LoadOptions::set_Password](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/loadoptions/set_password/) 並將該選項傳遞給 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 建構式。若密碼缺失或不正確，載入將失敗。

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = MakeObject<Presentation>(u"encrypted-presentation.pptx", loadOptions);

Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());

presentation->Dispose();
```

有關密碼偵測、驗證與加密工作流程，請參閱 [受密碼保護的簡報](/slides/zh-hant/cpp/password-protected-presentation/)。如果已加密的簡報刻意以公開文件屬性儲存，則可在不需密碼的情況下讀取這些屬性；請參閱 [管理簡報屬性](/slides/zh-hant/cpp/presentation-properties/)。

## **開啟大型簡報**

[LoadOptions::get_BlobManagementOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/loadoptions/get_blobmanagementoptions/) 控制 Aspose.Slides 如何處理二進位大型物件 (例如影像、音訊與影片)。您可以保持來源檔案被鎖定、允許使用暫存檔，並限制記憶體中保留的 BLOB 資料量。

以下 C++ 程式碼示範載入大型簡報（例如 2 GB）：

```cpp
#include <DOM/ISlide.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IBlobManagementOptions.h>
#include <PresentationLockingBehavior.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

const String filePath = u"large-presentation.pptx";

auto loadOptions = MakeObject<LoadOptions>();
auto blobOptions = loadOptions->get_BlobManagementOptions();
blobOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobOptions->set_IsTemporaryFilesAllowed(true);
blobOptions->set_MaxBlobsBytesInMemory(10 * 1024 * 1024);

auto presentation = MakeObject<Presentation>(filePath, loadOptions);

presentation->get_Slide(0)->set_Name(u"Large presentation");
presentation->Save(u"large-presentation-copy.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
使用 `PresentationLockingBehavior::KeepLocked` 時，來源檔案會保持鎖定，直至 `Presentation` 物件釋放。物件存活期間請勿移動、覆寫或刪除來源檔案。

Aspose.Slides 可能在載入時複製輸入串流的內容。對於大型簡報，檔案路徑通常較串流更有效率。請參閱 [管理 BLOB](/slides/zh-hant/cpp/manage-blob/) 以取得其他儲存與記憶體管理選項。
{{% /alert %}}

## **控制外部資源**

[LoadOptions::set_ResourceLoadingCallback](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/loadoptions/set_resourceloadingcallback/) 接受 [IResourceLoadingCallback](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iresourceloadingcallback/) 的實作。回呼可提供替代資料、重新導向資源、使用預設載入器，或跳過該資源。當簡報包含必須依照應用程式特定安全或儲存規則解析的外部影像時，此功能非常有用。

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IResourceLoadingArgs.h>
#include <IResourceLoadingCallback.h>
#include <ResourceLoadingAction.h>
#include <system/console.h>
#include <system/io/file.h>
#include <system/string_comparison.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

class ImageLoadingHandler : public IResourceLoadingCallback
{
public:
    ResourceLoadingAction ResourceLoading(SharedPtr<IResourceLoadingArgs> args) override
    {
        auto isJpeg = args->get_OriginalUri().EndsWith(u".jpg", StringComparison::OrdinalIgnoreCase);
        if (!isJpeg || !File::Exists(u"approved-image.jpg"))
        {
            return ResourceLoadingAction::Skip;
        }

        auto imageData = File::ReadAllBytes(u"approved-image.jpg");
        args->SetData(imageData);
        return ResourceLoadingAction::UserProvided;
    }
};

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_ResourceLoadingCallback(MakeObject<ImageLoadingHandler>());

auto presentation = MakeObject<Presentation>(u"presentation-with-external-images.pptx", loadOptions);
Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());

presentation->Dispose();
```

## **載入不含內嵌二進位物件的簡報**

簡報可能包含應用程式不需要或不想保留的內嵌二進位資料。例子包括：

- VBA 專案，可透過 [IPresentation::get_VbaProject](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentation/get_vbaproject/) 取得；
- 內嵌 OLE 資料，可透過 [IOleEmbeddedDataInfo::get_EmbeddedFileData](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ioleembeddeddatainfo/get_embeddedfiledata/) 取得；
- ActiveX 控制項資料，可透過 [IControl::get_ActiveXControlBinary](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icontrol/get_activexcontrolbinary/) 取得。

將 `true` 傳遞給 [LoadOptions::set_DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/loadoptions/set_deleteembeddedbinaryobjects/) 以在載入時移除這些二進位資料。將載入後的簡報儲存，以保留已清理的結果。

此選項可降低不必要內嵌載荷的風險，但它並非完整的惡意程式偵測或內容消毒系統。

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_DeleteEmbeddedBinaryObjects(true);

auto presentation = MakeObject<Presentation>(u"presentation-with-embedded-data.pptx", loadOptions);

presentation->Save(u"presentation-without-embedded-data.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **常見問題**

**如何判斷檔案已損毀且無法開啟？**

Aspose.Slides 會在載入期間拋出剖析或格式例外。請將此失敗與密碼錯誤分開處理，以便應用程式能準確回報原因。

**如果缺少必要字型會發生什麼情況？**

簡報仍可載入，但渲染與匯出時可能會替換字型。您可以 [設定字型替換](/slides/zh-hant/cpp/font-substitution/) 或 [提供自訂字型](/slides/zh-hant/cpp/custom-font/) 以使輸出更可預測。

**載入簡報時是否也會載入其內嵌媒體？**

內嵌的音訊與影片可透過簡報物件模型取得。外部資源則依照已設定的資源載入行為解析，若其位置無法存取，則可能無法取得。