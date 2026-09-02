---
title: 在 C++ 中儲存簡報
linktitle: 儲存簡報
type: docs
weight: 80
url: /zh-hant/cpp/save-presentation/
keywords:
- 儲存 PowerPoint
- 儲存 OpenDocument
- 儲存 簡報
- 儲存 投影片
- 儲存 PPT
- 儲存 PPTX
- 儲存 ODP
- 簡報至檔案
- 簡報至串流
- 預先定義的檢視類型
- 嚴格的 Office Open XML 格式
- Zip64 模式
- 重新整理縮圖
- 儲存進度
- C++
- Aspose.Slides
description: "了解如何使用 Aspose.Slides 在 C++ 中儲存簡報—匯出至 PowerPoint 或 OpenDocument，同時保留版面配置、字型與效果。"
---
## **概觀**

[Open Presentations in C++](/slides/zh-hant/cpp/open-presentation/) 介紹了如何使用 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別開啟簡報。本篇說明如何建立與儲存簡報。[Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別包含簡報的所有內容。無論是從頭建立簡報或是修改既有簡報，完成後皆需要將其儲存。使用 Aspose.Slides for C++，您可以將簡報儲存至 **檔案** 或 **串流**。本篇說明儲存簡報的各種方式。

## **將簡報儲存為檔案**

透過呼叫 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的 `Save` 方法，將簡報儲存為檔案。將檔名與儲存格式傳入該方法。下列範例示範如何使用 Aspose.Slides 儲存簡報。

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// 實例化代表簡報檔案的 Presentation 類別。
auto presentation = MakeObject<Presentation>();

// 在此執行一些工作…
 
// 將簡報儲存至檔案。
presentation->Save(u"Output.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **將簡報儲存為串流**

您可以將輸出串流傳遞給 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的 `Save` 方法，從而將簡報儲存至串流。簡報可以寫入多種串流類型。以下範例建立新簡報並將其儲存至檔案串流。

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file_mode.h>
#include <system/io/file_stream.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

// 實例化代表簡報檔案的 Presentation 類別。
auto presentation = MakeObject<Presentation>();

auto fileStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

// 將簡報儲存至串流。
presentation->Save(fileStream, SaveFormat::Pptx);

presentation->Dispose();
fileStream->Close();
```

## **以預先定義的檢視類型儲存簡報**

Aspose.Slides 允許您透過 [ViewProperties](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/viewproperties/) 類別設定 PowerPoint 開啟產生的簡報時的初始檢視。使用 [set_LastView](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/viewproperties/set_lastview/) 方法，並傳入來自 [ViewType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/viewtype/) 列舉的值。

```cpp
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <ViewType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);

presentation->Save(u"SlideMasterView.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **以嚴格的 Office Open XML 格式儲存簡報**

Aspose.Slides 允許您以嚴格的 Office Open XML 格式儲存簡報。使用 [PptxOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/pptxoptions/) 類別，並在儲存時設定其 `Conformance` 屬性。如將其設定為 `Conformance.Iso29500_2008_Strict`，輸出檔案即會以嚴格的 Office Open XML 格式儲存。

下列範例建立簡報並以嚴格的 Office Open XML 格式儲存。

```cpp
#include <DOM/Presentation.h>
#include <Export/Conformance.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto options = MakeObject<PptxOptions>();
options->set_Conformance(Conformance::Iso29500_2008_Strict);

// 實例化代表簡報檔案的 Presentation 類別。
auto presentation = MakeObject<Presentation>();

// 以嚴格的 Office Open XML 格式儲存簡報。
presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **以 Zip64 模式儲存 Office Open XML 格式簡報**

Office Open XML 檔案實際上是一個 ZIP 壓縮檔，對任何未壓縮檔案大小、壓縮後檔案大小以及整個壓縮檔總大小皆限制在 4 GB (2^32 位元組)，且檔案數量上限為 65 535 (2^16‑1) 個。ZIP64 格式擴充可將這些限制提升至 2^64。

[IPptxOptions::set_Zip64Mode](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/ipptxoptions/set_zip64mode/) 方法讓您在儲存 Office Open XML 檔案時選擇是否使用 ZIP64 格式擴充。

此方法可搭配以下模式使用：

- `IfNecessary` 只有在簡報超過上述限制時才使用 ZIP64 格式擴充。這是預設模式。
- `Never` 絕不使用 ZIP64 格式擴充。
- `Always` 總是使用 ZIP64 格式擴充。

以下程式碼示範如何在啟用 ZIP64 格式擴充的情況下，將簡報儲存為 PPTX 檔案：

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <Export/Zip64Mode.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_Zip64Mode(Zip64Mode::Always);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="NOTE" color="warning" %}}
當您使用 `Zip64Mode.Never` 儲存時，如果簡報無法以 ZIP32 格式儲存，將拋出 [PptxException](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/pptxexception/)。
{{% /alert %}}

## **以不同壓縮等級儲存 Office Open XML 格式簡報**

處理大型簡報時，您可以調整壓縮等級，以在檔案大小與處理時間之間取得平衡。根據需求，您可能會偏好較快的處理速度或較小的輸出檔案。

Aspose.Slides 提供 [PptxOptions::set_CompressionLevel](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/pptxoptions/set_compressionlevel/) 方法，讓您在以 Office Open XML 格式儲存簡報時指定壓縮等級。

可用的壓縮等級如下：

- **None**：不進行壓縮，檔案保持原樣儲存。
- **Level1**：最快的壓縮速度，但壓縮率最低。
- **Level2**：較快的壓縮速度，壓縮率略佳於 **Level1**。
- **Level3**：在處理時間上有中等影響，提供比 **Level2** 更佳的壓縮率。
- **Level4**：提供比 **Level3** 更好的壓縮率。
- **Level5**：在 **Level4** 基礎上進一步提升壓縮率，但需額外的處理時間。
- **Level6**：標準壓縮，兼顧處理速度與檔案大小。這是 *預設壓縮等級*。
- **Level7**：提供比 **Level6** 更佳的壓縮率，處理速度較慢。
- **Level8**：提供比 **Level7** 更佳的壓縮率。
- **Level9**：最高壓縮率，產生最小檔案大小，但需最長的處理時間。

以下範例示範如何在 **不壓縮** 的情況下將簡報儲存為 PPTX 檔案：

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Export::CompressionLevel;
using Aspose::Slides::Export::PptxOptions;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::MakeObject;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_CompressionLevel(CompressionLevel::None);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");
presentation->Save(u"Sample-out.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

此範例示範如何在 **最大壓縮** 的情況下將簡報儲存為 PPTX 檔案：

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Export::CompressionLevel;
using Aspose::Slides::Export::PptxOptions;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::MakeObject;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_CompressionLevel(CompressionLevel::Level9);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");
presentation->Save(u"Sample-level9.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

## **儲存簡報時不重新整理縮圖**

[PptxOptions::set_RefreshThumbnail](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/pptxoptions/set_refreshthumbnail/) 方法控制在儲存為 PPTX 時是否重新產生縮圖：

- 設為 `true` 時，儲存過程會重新整理縮圖（預設值）。
- 設為 `false` 時，保留現有縮圖；若簡報本身沒有縮圖，則不會產生任何縮圖。

以下程式碼示範將簡報儲存為 PPTX 同時不重新整理縮圖：

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_RefreshThumbnail(false);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
此選項可減少儲存 PPTX 格式簡報所需的時間。
{{% /alert %}}

## **以百分比顯示儲存進度更新**

[IProgressCallback](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iprogresscallback/) 介面透過 [ISaveOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/isaveoptions/) 介面及抽象類別 [SaveOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/saveoptions/) 所公開的 `set_ProgressCallback` 方法使用。將實作了 IProgressCallback 的物件以 `set_ProgressCallback` 指定，即可在儲存過程中以百分比接收進度更新。

以下程式片段示範如何使用 `IProgressCallback`。

```cpp
#include <IProgressCallback.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue) override
    {
        // 在此使用進度百分比值。
        int progress = static_cast<int>(progressValue);

        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};
```
```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <IProgressCallback.h>
#include <system/console.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// 上面定義的進度回呼類別。
class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue) override
    {
        int progress = static_cast<int>(progressValue);

        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};

auto saveOptions = MakeObject<PdfOptions>();
saveOptions->set_ProgressCallback(MakeObject<ExportProgressHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pdf", SaveFormat::Pdf, saveOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
Aspose 開發了一款使用其 API 的 [免費 PowerPoint 分割工具](https://products.aspose.app/slides/zh-hant/splitter)。此應用程式可將簡報依選取的投影片分割為多個新 PPTX 或 PPT 檔案。
{{% /alert %}}

## **FAQ**

**是否支援「快速儲存」（增量儲存）只寫入變更？**

不支援。每次儲存都會重新建立完整目標檔案，未提供增量「快速儲存」功能。

**從多個執行緒同時儲存同一個 Presentation 實例是否安全？**

不安全。`Presentation` 實例 **不是執行緒安全** 的（/slides/zh-hant/cpp/multithreading/），請在單一執行緒中完成儲存。

**儲存時超連結與外部連結檔案會發生什麼事？**

[超連結](/slides/zh-hant/cpp/manage-hyperlinks/) 會被保留下來。外部連結的檔案（例如以相對路徑引用的影片）不會自動複製，請確保這些路徑在目標環境仍然可存取。

**我可以設定/儲存文件的中繼資料（作者、標題、公司、日期）嗎？**

可以。支援標準的 [文件屬性](/slides/zh-hant/cpp/presentation-properties/)，儲存時會將其寫入檔案。