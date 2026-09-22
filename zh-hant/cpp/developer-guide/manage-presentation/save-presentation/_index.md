---
title: 在 C++ 中儲存簡報
linktitle: 儲存簡報
type: docs
weight: 80
url: /zh-hant/cpp/save-presentation/
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
- 嚴格的 Office Open XML 格式
- Zip64 模式
- 重新整理縮圖
- 儲存進度
- C++
- Aspose.Slides
description: "使用 Aspose.Slides 在 C++ 中將 PowerPoint 和 OpenDocument 簡報儲存至檔案或串流，並設定 PPTX 輸出與進度回報。"
---
## **概觀**

建立簡報或[開啟現有簡報](/slides/zh-hant/cpp/open-presentation/)之後，使用[Presentation::Save](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/save/)方法寫入結果。Aspose.Slides for C++ 可以將簡報儲存為檔案或串流，支援 PowerPoint、OpenDocument、PDF 以及其他格式。以下各節說明標準儲存操作以及 PPTX 輸出的可用選項。

## **將簡報儲存為檔案**

若要將簡報儲存為檔案，將輸出路徑與[SaveFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/saveformat/)值傳遞給[Presentation::Save](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/save/)方法。格式值決定 Aspose.Slides 所建立檔案的類型。

以下範例會建立一個簡報，並將其儲存為 PPTX 檔案：

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

// 在此新增或修改簡報內容。

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **以原始格式儲存簡報**

欲了解檔案與串流偵測範例、新建立簡報的行為，以及來源與輸出格式的區別，請參閱[判定原始簡報格式](/slides/zh-hant/cpp/detect-presentation-source-format/)。

在批次處理應用程式中，輸入格式可能事先未知。載入檔案後，可使用[IPresentation::get_SourceFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentation/get_sourceformat/)讀取其原始格式。將得到的[SourceFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/sourceformat/)值傳遞給[SlideUtil::ToSaveFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.util/slideutil/tosaveformat/)，以取得相對應的[SaveFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/saveformat/)值，然後使用[Presentation::Save](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/save/)寫入修改後的簡報。

以下完整範例會處理輸入目錄中的每個檔案，更新其標題，並以載入時的格式儲存至輸出目錄：

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Util/SlideUtil.h>
#include <system/console.h>
#include <system/exception.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Util;
using namespace System;
using namespace System::IO;

String inputDirectory = u"Input";
String outputDirectory = u"Output";

Directory::CreateDirectory_(outputDirectory);

auto inputPaths = Directory::GetFiles(inputDirectory);
for (const auto& inputPath : inputPaths)
{
    try
    {
        auto presentation = MakeObject<Presentation>(inputPath);

        auto sourceFormat = presentation->get_SourceFormat();
        auto saveFormat = SlideUtil::ToSaveFormat(sourceFormat);

        presentation->get_DocumentProperties()->set_Title(u"Processed by the batch application");

        auto outputPath = Path::Combine(outputDirectory, Path::GetFileName(inputPath));
        presentation->Save(outputPath, saveFormat);
        presentation->Dispose();
    }
    catch (ArgumentException& exception)
    {
        Console::get_Error()->WriteLine(String::Format(u"Cannot map the source format of '{0}': {1}", inputPath, exception->get_Message()));
    }
    catch (Exception& exception)
    {
        Console::get_Error()->WriteLine(String::Format(u"Cannot process '{0}': {1}", inputPath, exception->get_Message()));
    }
}
```

[SlideUtil::ToSaveFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.util/slideutil/tosaveformat/)將 PPT、PPTX、ODP、PPTM、PPSX、PPSM、POTX、POTM、PPS、POT、OTP、FODP 以及 PowerPoint XML 映射到相應的簡報儲存格式。它僅映射簡報來源格式；並非用於選取 PDF、HTML、TIFF 或影像等匯出格式。傳入不支援或無效的[SourceFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/sourceformat/)值會導致[ArgumentException](https://reference.aspose.com/slides/zh-hant/cpp/system/argumentexception/)。

舊版 PPT、PPS 與 POT 檔案使用相同的二進位容器。若此類簡報從未帶副檔名的串流載入，PPS 或 POT 檔案可能會被識別為 PPT。若需保留這些舊版子類型，請另行保留原始檔名或格式中繼資料，並在選擇輸出檔名與格式時使用它。

## **將簡報儲存至串流**

若不依賴最終檔案路徑寫入簡報，可將可寫入的[Stream](https://reference.aspose.com/slides/zh-hant/cpp/system.io/stream/)與[SaveFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/saveformat/)值傳遞給[Presentation::Save](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/save/)方法。此方式在必須將輸出從 Web 服務傳回、儲存於資料庫或於記憶體中處理時特別有用。

以下範例將新簡報儲存至檔案串流：

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

auto presentation = MakeObject<Presentation>();
auto outputStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

presentation->Save(outputStream, SaveFormat::Pptx);

outputStream->Close();
presentation->Dispose();
```

## **以預先定義的檢視類型儲存簡報**

您可以指定 PowerPoint 開啟已儲存簡報時的初始檢視。於儲存前呼叫帶有[ViewType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/viewtype/)值的[ViewProperties::set_LastView](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/viewproperties/set_lastview/)方法。

以下範例將投影片母片檢視設定為初始檢視：

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

若要建立符合 Office Open XML 嚴格規範的 PPTX 檔案，請建立一個[PptxOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/pptxoptions/)實例，並以 `Conformance::Iso29500_2008_Strict` 呼叫[PptxOptions::set_Conformance](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/pptxoptions/set_conformance/)。然後將此選項傳遞給[Presentation::Save](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/save/)方法。

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

auto presentation = MakeObject<Presentation>();

presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **以 Zip64 模式儲存 Office Open XML 格式的簡報**

標準 ZIP 壓縮檔對每個條目之壓縮與未壓縮大小、總檔案大小以及條目數量都有上限。由於 PPTX 檔案即為 ZIP 壓縮檔，極大的簡報可能會超出這些限制。ZIP64 延伸可提升相關的大小與條目數上限。

使用[PptxOptions::set_Zip64Mode](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/pptxoptions/set_zip64mode/)可控制 Aspose.Slides 是否寫入 ZIP64 延伸：

- `IfNecessary` 只在簡報超過標準 ZIP 限制時使用 ZIP64。這是預設模式。
- `Never` 停用 ZIP64 延伸。
- `Always` 總是寫入 ZIP64 延伸。

以下範例會在輸出簡報上始終啟用 ZIP64 延伸：

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <Export/Zip64Mode.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_Zip64Mode(Zip64Mode::Always);

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

{{% alert color="warning" title="Warning" %}}
如果將 `Zip64Mode` 設為 `Never`，且簡報無法符合標準 ZIP 限制，儲存操作會拋出 [PptxException](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/pptxexception/)。
{{% /alert %}}

## **以壓縮等級儲存 Office Open XML 格式的簡報**

對於 PPTX 輸出，您可以透過呼叫[PptxOptions::set_CompressionLevel](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/pptxoptions/set_compressionlevel/)來平衡儲存速度與檔案大小。[CompressionLevel](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/compressionlevel/) 列舉提供以下值：

- `None` 不使用壓縮儲存資料。
- `Level1` 提供最快的壓縮速度，但產生最大的壓縮檔。
- `Level2` 至 `Level5` 逐漸偏好較小的輸出，而非儲存速度。
- `Level6` 在儲存速度與檔案大小之間取得平衡。這是預設等級。
- `Level7` 與 `Level8` 更進一步偏好較小的輸出，而非儲存速度。
- `Level9` 提供最強的壓縮，且需要最多的處理時間。

以下範例在不使用壓縮的情況下儲存簡報：

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_CompressionLevel(CompressionLevel::None);

presentation->Save(u"OutputNoCompression.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

以下範例使用最高的壓縮等級：

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_CompressionLevel(CompressionLevel::Level9);

presentation->Save(u"OutputMaximumCompression.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **儲存簡報時不重新整理縮圖**

當簡報儲存為 PPTX 時，[PptxOptions::set_RefreshThumbnail](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/pptxoptions/set_refreshthumbnail/) 控制其文件縮圖：

- `true` 在儲存過程中重新產生縮圖。這是預設值。
- `false` 保留現有縮圖。若簡報沒有縮圖，Aspose.Slides 不會產生。

以下範例在儲存簡報時不重新整理縮圖：

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_RefreshThumbnail(false);

presentation->Save(u"Output.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
停用縮圖重新整理可減少儲存 PPTX 檔案所需的時間。
{{% /alert %}}

## **以百分比顯示儲存進度更新**

若要監控儲存操作，實作[IProgressCallback](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iprogresscallback/)介面，並將實作傳遞給[ISaveOptions::set_ProgressCallback](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/isaveoptions/set_progresscallback/)。在匯出過程中，Aspose.Slides 會以進度數值呼叫[IProgressCallback::Reporting](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iprogresscallback/reporting/)。

以下範例將 PDF 匯出的進度報告至主控台：

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

class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue) override
    {
        int progress = static_cast<int>(progressValue);
        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};

auto options = MakeObject<PdfOptions>();
options->set_ProgressCallback(MakeObject<ExportProgressHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pdf", SaveFormat::Pdf, options);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Aspose 提供一個免費的[PowerPoint 分割器](https://products.aspose.app/slides/zh-hant/splitter)，使用 Aspose.Slides API 建置。它可將簡報中選取的投影片儲存為獨立的 PPT 或 PPTX 檔案。
{{% /alert %}}

## **常見問題**

**Aspose.Slides 是否支援增量或「快速儲存」？**

否。每次儲存操作都會寫入完整的輸出檔案，而不是僅更新變更的部分。

**多個執行緒可以同時儲存相同的 Presentation 實例嗎？**

否。[Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 實例[不是執行緒安全](/slides/zh-hant/cpp/multithreading/)。每次僅允許單一執行緒存取與儲存該實例。

**儲存簡報時，超連結與外部連結檔案會發生什麼情況？**

[超連結](/slides/zh-hant/cpp/manage-hyperlinks/) 仍保留在簡報中。Aspose.Slides 不會複製外部連結的檔案，因此已儲存的簡報仍須能存取其位置。

**我可以儲存文件中繼資料（如作者、標題、公司與建立日期）嗎？**

可以。在儲存之前設定相應的[文件屬性](/slides/zh-hant/cpp/presentation-properties/)，Aspose.Slides 會將其寫入輸出檔案。