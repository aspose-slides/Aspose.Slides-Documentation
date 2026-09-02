---
title: 在 C++ 中將 PowerPoint 簡報轉換為 Markdown
linktitle: PowerPoint 轉 Markdown
type: docs
weight: 140
url: /zh-hant/cpp/convert-powerpoint-to-markdown/
keywords:
- 轉換 PowerPoint
- 轉換簡報
- 轉換投影片
- 轉換 PPT
- 轉換 PPTX
- PowerPoint 轉 MD
- 簡報轉 MD
- 投影片轉 MD
- PPT 轉 MD
- PPTX 轉 MD
- 儲存 PowerPoint 為 Markdown
- 儲存簡報為 Markdown
- 儲存投影片為 Markdown
- 儲存 PPT 為 MD
- 儲存 PPTX 為 MD
- 匯出 PPT 為 MD
- 匯出 PPTX 為 MD
- Markdown 圖片匯出
- CDN 圖片連結
- PowerPoint
- 簡報
- Markdown
- C++
- Aspose.Slides
description: "在 C++ 中將 PPT 與 PPTX 簡報轉換為 Markdown，並控制匯出的點陣圖、圖形檔與 SVG 圖片的儲存位置與參照方式。"
---
## **概述**

Aspose.Slides for C++ 能將 PPT 和 PPTX 簡報轉換為 Markdown，用於文件編寫、靜態網站、內容遷移和版本控制工作流程。您可以選擇 Markdown 的風格，控制投影片內容的呈現方式，並決定匯出影像的存放位置以及產生的 Markdown 如何引用它們。

預設情況下，Markdown 匯出僅產生文字輸出。若要匯出視覺內容，請將 [MarkdownSaveOptions::set_ExportType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/markdownsaveoptions/set_exporttype/) 方法設為 [MarkdownExportType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/markdownexporttype/) 列舉中的 `Sequential` 或 `Visual` 值。`Sequential` 會個別且依序呈現投影片項目，而 `Visual` 則會將分組的項目保持在一起，以保留它們的視覺關係。`TextOnly` 值不會產生影像資源，因而在該模式下不會觸發影像儲存事件。

## **將簡報轉換為 Markdown**

使用 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別載入來源檔案，然後以 [Presentation::Save](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/save/) 方法傳入 [SaveFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/saveformat/) 列舉中的 `Md` 值。

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.md", SaveFormat::Md);
```

## **選擇 Markdown 風格**

[MarkdownSaveOptions::set_Flavor](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/markdownsaveoptions/set_flavor/) 方法控制輸出的 Markdown 規範。[Flavor](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/flavor/) 列舉包含 CommonMark、GitHub Flavored Markdown 以及其他受支援的變體。

以下範例將簡報匯出為 CommonMark：

```cpp
#include <DOM/Presentation.h>
#include <Export/Markdown/SaveOptions/Flavor.h>
#include <Export/Markdown/SaveOptions/MarkdownSaveOptions.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto options = System::MakeObject<MarkdownSaveOptions>();
options->set_Flavor(Flavor::CommonMark);

presentation->Save(u"presentation.md", SaveFormat::Md, options);
```

## **使用預設本機儲存行為匯出影像**

[MarkdownSaveOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/markdownsaveoptions/) 類別提供兩個方法以設定本機儲存的影像：

- [set_BasePath](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) 指定 Markdown 文件及其資源的基底目錄。
- [set_ImagesSaveFolderName](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/) 指定影像子目錄。其預設值為 `Images`。

以下範例會渲染視覺內容，將影像寫入 `output/assets`，並在 Markdown 文件中建立相對影像參照：

```cpp
#include <DOM/Presentation.h>
#include <Export/Markdown/SaveOptions/MarkdownExportType.h>
#include <Export/Markdown/SaveOptions/MarkdownSaveOptions.h>
#include <Export/SaveFormat.h>
#include <system/io/directory.h>
#include <system/io/path.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

const System::String outputDirectory = u"output";
Directory::CreateDirectory_(outputDirectory);

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto options = System::MakeObject<MarkdownSaveOptions>();
options->set_ExportType(MarkdownExportType::Visual);
options->set_BasePath(outputDirectory);
options->set_ImagesSaveFolderName(u"assets");

auto markdownPath = Path::Combine(outputDirectory, u"presentation.md");
presentation->Save(markdownPath, SaveFormat::Md, options);
```

當自訂的影像儲存處理程式回傳 `false` 時，此行為亦會作為預備方案。

## **自訂影像儲存與 Markdown 連結**

在 Markdown 匯出期間，使用 `MarkdownSaveOptions::ImageSaving` 事件處理非 SVG 位圖與圖形檔資源。其 [MarkdownImageSavingHandler](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/markdownsaveoptions/markdownimagesavinghandler/) 委派會接收 [IImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iimage/) 物件、其 [ImageFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imageformat/) 以及以 `System::String&` 形式傳入的產生之 Markdown 連結。請以提供的格式儲存或上傳影像，並以 `link` 參數取代為必須出現在 Markdown 輸出中的參照。

以 SVG 格式產生的資源則另行處理。請訂閱 `MarkdownSaveOptions::SvgImageSaving` 事件，其 [MarkdownSvgImageSavingHandler](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/markdownsaveoptions/markdownsvgimagesavinghandler/) 委派會接收 [ISvgImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isvgimage/) 物件與 `System::String& link` 參數。SVG 並無 `ImageFormat` 參數；請改由 [ISvgImage::get_SvgData](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isvgimage/get_svgdata/) 方法取得其 XML 資料並寫入或上傳。依匯出模式與視覺分組的不同，來源簡報中的 SVG 可能會被光柵化或與其他內容合併；此時產生的非 SVG 資源會傳遞給 `ImageSaving`。若每個匯出之視覺資源皆需自訂處理，請同時訂閱兩個事件。

處理程式的回傳值決定由誰負責處理影像：

- 回傳 `true` 表示處理程式已完成儲存、上傳、轉換或其他處理，並已為 `link` 指派有效值。Aspose.Slides 會將該值寫入 Markdown 文件，且不會執行預設的本機儲存。
- 回傳 `false` 讓 Aspose.Slides 依照 [MarkdownSaveOptions::set_BasePath](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) 與 [MarkdownSaveOptions::set_ImagesSaveFolderName](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/) 的設定，將影像本機儲存並產生連結。

{{% alert color="warning" title="重要" %}}
回傳 `true` 的處理程式必須自行負責影像。若回傳 `true` 卻未給予有效且非空的連結，則匯出會因 `InvalidOperationException` 失敗。
{{% /alert %}}

### **將影像儲存至 CDN 起始目錄並使用外部 URL**

以下範例將 `cdn-origin/presentations/quarterly-report` 視為已掛載或同步的 CDN 起始目錄。每個處理程式會擷取產生的檔名，將影像儲存至該自訂目錄，並以公開的 CDN URL 取代產生的本機參照。範例本身不會執行網路上傳：只有在目錄掛載為 CDN 起始或其檔案已發布至 CDN 後，URL 才會有效。若使用物件儲存，請將檔案系統寫入改為儲存 SDK 的上傳操作，並在上傳成功後才指派 `link`。

```cpp
#include <DOM/ISvgImage.h>
#include <DOM/Presentation.h>
#include <Export/Markdown/SaveOptions/MarkdownExportType.h>
#include <Export/Markdown/SaveOptions/MarkdownSaveOptions.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <functional>
#include <system/io/directory.h>
#include <system/io/file.h>
#include <system/io/path.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

const System::String outputDirectory = u"output";
const System::String publicBaseUrl = u"https://cdn.example.com/presentations/quarterly-report";
const System::String storageDirectory = Path::Combine(u"cdn-origin", u"presentations", u"quarterly-report");
Directory::CreateDirectory_(outputDirectory);
Directory::CreateDirectory_(storageDirectory);

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto options = System::MakeObject<MarkdownSaveOptions>();
options->set_ExportType(MarkdownExportType::Visual);
options->set_BasePath(outputDirectory);
options->set_ImagesSaveFolderName(u"fallback-images");

options->ImageSaving.connect(std::function<bool(System::SharedPtr<IImage>, ImageFormat, System::String&)>([storageDirectory, publicBaseUrl](System::SharedPtr<IImage> image, ImageFormat format, System::String& link) -> bool
{
    if (image->get_Width() < 128 || image->get_Height() < 128)
    {
        return false;
    }

    auto urlCompatibleLink = link.Replace(u"\\", u"/");
    auto fileName = urlCompatibleLink.Substring(urlCompatibleLink.LastIndexOf(u'/') + 1);
    auto storagePath = Path::Combine(storageDirectory, fileName);
    image->Save(storagePath, format);
    link = publicBaseUrl + u"/" + System::Uri::EscapeDataString(fileName);
    return true;
}));

options->SvgImageSaving.connect(std::function<bool(System::SharedPtr<ISvgImage>, System::String&)>([storageDirectory, publicBaseUrl](System::SharedPtr<ISvgImage> svgImage, System::String& link) -> bool
{
    auto urlCompatibleLink = link.Replace(u"\\", u"/");
    auto fileName = urlCompatibleLink.Substring(urlCompatibleLink.LastIndexOf(u'/') + 1);
    auto storagePath = Path::Combine(storageDirectory, fileName);
    File::WriteAllBytes(storagePath, svgImage->get_SvgData());
    link = publicBaseUrl + u"/" + System::Uri::EscapeDataString(fileName);
    return true;
}));

auto markdownPath = Path::Combine(outputDirectory, u"presentation.md");
presentation->Save(markdownPath, SaveFormat::Md, options);
```

位圖處理程式特意對尺寸小於 128 × 128 像素的影像回傳 `false`，因此 Aspose.Slides 會使用預設行為將這些影像儲存至 `output/fallback-images`。較大的位圖、圖形檔以及 SVG 資源則由自訂程式處理。例如，產生的本機參照 `fallback-images/image1.png` 會變成 `https://cdn.example.com/presentations/quarterly-report/image1.png`。處理程式僅在寫入檔案時使用作業系統路徑；寫入 Markdown 的連結使用正斜線 (/) 且檔名需進行 URL 編碼。建立相對連結時亦同，請使用 `/`，而非平台特定的目錄分隔符。

## **常見問題**

**是否可以用同一個處理程式同時處理點陣圖和 SVG 圖像？**  
不能。請使用 `MarkdownSaveOptions::ImageSaving` 處理產生的位圖與圖形檔資源，使用 `MarkdownSaveOptions::SvgImageSaving` 處理產生為 SVG 的資源。前者會提供 [IImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iimage/) 物件與 [ImageFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imageformat/)，後者則提供 [ISvgImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isvgimage/) 物件，可透過 [ISvgImage::get_SvgData](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isvgimage/get_svgdata/) 讀取 SVG 資料。若來源 SVG 在匯出時被光柵化，則會由 `ImageSaving` 處理。

**回傳 `false` 的影像儲存處理程式會發生什麼事？**  
Aspose.Slides 會使用其預設的本機儲存行為。影像的儲存位置與產生的參照受 [MarkdownSaveOptions::set_BasePath](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) 與 [MarkdownSaveOptions::set_ImagesSaveFolderName](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/) 控制。

**處理程式可以在不本機儲存影像的情況下提供 URL 嗎？**  
可以。處理程式可將影像上傳至物件儲存或傳遞給其他服務，將取得的 URL 指派給 `link`，並回傳 `true`。此時處理程式必須自行完成所有工作，`true` 會阻止預設的本機儲存。

**為何 Markdown 匯出會因處理程式拋出 `InvalidOperationException`？**  
當處理程式回傳 `true` 但未提供有效的連結時會發生此例外。請在回傳 `true` 之前，將應寫入 Markdown 的相對路徑或外部 URL 指派給 `link`。

**影像連結應使用哪種路徑分隔符？**  
在 Markdown 連結與 URL 中請使用正斜線 (/) 。僅在組合檔案系統路徑時使用 `Path::Combine`，Markdown 參照需另行建構或正規化。

**超連結在 Markdown 匯出時會被保留嗎？**  
會。文字 [hyperlinks](/slides/zh-hant/cpp/manage-hyperlinks/) 會保留為標準的 Markdown 連結。投影片的 [transitions](/slides/zh-hant/cpp/slide-transition/) 與 [animations](/slides/zh-hant/cpp/powerpoint-animation/) 則不會被轉換。

**簡報可以平行轉換為 Markdown 嗎？**  
可以同時處理多個簡報檔案，但請勿在多執行緒間共享同一個 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 實例。請遵循 [multithreading guidelines](/slides/zh-hant/cpp/multithreading/)，為每個檔案使用獨立的實例。