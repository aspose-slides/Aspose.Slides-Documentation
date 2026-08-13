---
title: 使用 C++ 優化簡報中的圖像管理
linktitle: 管理圖像
type: docs
weight: 10
url: /zh-hant/cpp/image/
keywords:
- 新增圖像
- 新增圖片
- 新增點陣圖
- 取代圖像
- 取代圖片
- 來自網路
- 背景
- 新增 PNG
- 新增 JPG
- 新增 SVG
- 外部 SVG 資源
- SVG 解析器
- 連結的 SVG 圖像
- SVG 字型
- 新增 EMF
- 新增 WMF
- 新增 TIFF
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 在 PowerPoint 與 OpenDocument 中精簡圖像管理，優化效能並自動化工作流程。"
---
## **簡介**

圖像使簡報更具吸引力和視覺效果。 在 Microsoft PowerPoint 中，您可以從檔案、網際網路或其他來源將圖片插入投影片。 同樣，Aspose.Slides 允許您以多種方式將圖像添加到簡報投影片中。

{{% alert title="Tip" color="info" %}} 
Aspose 提供免費的轉換器—[JPEG to PowerPoint](https://products.aspose.app/slides/zh-hant/import/jpg-to-ppt) 和 [PNG to PowerPoint](https://products.aspose.app/slides/zh-hant/import/png-to-ppt)—讓您能夠快速從圖像建立簡報。 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}

如果您想將圖像作為圖片框添加——尤其是當您打算調整大小、套用效果或使用其他標準格式化選項時——請參閱 [Picture Frame](/slides/zh-hant/cpp/picture-frame/)。 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

您可以將圖像從一種格式轉換為另一種格式。請參閱以下頁面：convert [image to JPG](https://products.aspose.com/slides/zh-hant/cpp/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/zh-hant/cpp/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/zh-hant/cpp/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/zh-hant/cpp/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/zh-hant/cpp/conversion/png-to-svg/), and [SVG to PNG](https://products.aspose.com/slides/zh-hant/cpp/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides 支援 JPEG、PNG、BMP、GIF 等常見格式的圖像。 

## **將本機儲存的圖像新增至投影片**

您可以將儲存在電腦上的一個或多個圖像新增至簡報投影片。以下 C++ 範例程式碼示範如何將圖像新增至投影片：

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```



## **從網路新增圖像至投影片**

如果您想新增至投影片的圖像未儲存在電腦上，您可以直接從網路加入。 

以下 C++ 範例程式碼示範如何從網路將圖像新增至投影片：

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <net/web_client.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);

auto webClient = System::MakeObject<System::Net::WebClient>();
auto imageData = webClient->DownloadData(System::MakeObject<Uri>(u"[REPLACE WITH URL]"));

auto image = pres->get_Images()->AddImage(imageData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **將圖像新增至投影片母片**

投影片母片會儲存並控制使用該母片的投影片之主題與版面配置等資訊。當您將圖像新增至投影片母片時，該圖像會出現在所有以該母片為基礎的投影片上。 

以下 C++ 範例程式碼示範如何將圖像新增至投影片母片：

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto masterSlide = slide->get_LayoutSlide()->get_MasterSlide();

auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
masterSlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **將圖像設為投影片背景**

您可以將圖片作為一或多張投影片的背景。更多細節，請參閱 *[Setting Images as Backgrounds for Slides](/slides/zh-hant/cpp/presentation-background/#setting-images-as-background-for-slides)*。

## **將 SVG 新增至簡報**

可以使用 [SvgImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/svgimage/) 類別將 SVG 內容新增至簡報。產生的 [ISvgImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isvgimage/) 物件之後可加入簡報的圖像集合，並用於建立圖片框。

以下 C++ 範例匯入一個自包含的 SVG 字串。此 SVG 所使用的所有圖像、樣式及其他資源皆直接嵌入於 SVG 內容中。

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto svgContent = String(uR"(
<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>
    <rect width='320' height='180' fill='#4F81BD'/>
    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>
</svg>)");

auto presentation = MakeObject<Presentation>();
auto svgImage = MakeObject<SvgImage>(svgContent);
auto image = presentation->get_Images()->AddImage(svgImage);

presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(
    ShapeType::Rectangle, 20.0f, 20.0f,
    static_cast<float>(image->get_Width()),
    static_cast<float>(image->get_Height()),
    image);

presentation->Save(u"self-contained-svg.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **匯入含外部資源的 SVG 內容**

從設計工具、圖表編輯器、圖示系統及網路管線匯出的 SVG 檔案可能會引用儲存在 SVG 文件之外的資源。例如，SVG 可能包含圖像連結，如 `images/photo.png`、CSS `url(...)` 值，或字型 URL。

要匯入此類 SVG 內容，請建立 [IExternalResourceResolver](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.import/iexternalresourceresolver/) 的實作，並將其與基礎 URI 一起傳遞給適當的 `SvgImage` 建構函式。基礎 URI 用於識別 SVG 文件的位置，並用來解析相對連結。

[ISvgImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isvgimage/) 介面提供取得已匯入 SVG 相關資訊的功能：

- `get_SvgContent()` 會回傳 SVG 標記的字串。
- `get_SvgData()` 會回傳 SVG 內容的位元組陣列。
- `get_BaseUri()` 會回傳用於相對連結的基礎 URI。
- `get_ExternalResourceResolver()` 會回傳指派給 SVG 圖像的資源解析器。

### **實作外部資源解析器**

解析器有兩個方法：

- [ResolveUri](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.import/iexternalresourceresolver/resolveuri/) 結合基礎 URI 與相對資源連結，並回傳絕對 URI。若連結無法解析或不允許，請回傳空字串。
- [GetEntity](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.import/iexternalresourceresolver/getentity/) 為絕對資源 URI 回傳可讀取的串流。若資源缺失、被阻擋或無法取得，請回傳 `nullptr`。適當時也可回傳備援串流。

以下解析器僅從允許的本機目錄載入連結資源。網路資源以及位於允許目錄之外的路徑將被阻擋。對於無法解析的圖像連結，會回傳可選的備援圖像。

```cpp
#include <Import/IExternalResourceResolver.h>
#include <system/array.h>
#include <system/io/file.h>
#include <system/io/memory_stream.h>
#include <system/io/path.h>
#include <system/io/stream.h>
#include <system/string.h>
#include <system/smart_ptr.h>
#include <system/string_comparison.h>
#include <system/uri.h>

using namespace Aspose::Slides::Import;
using namespace System;
using namespace System::IO;

class LocalSvgResourceResolver : public IExternalResourceResolver
{
public:
    LocalSvgResourceResolver(String allowedRoot, ArrayPtr<uint8_t> fallbackImageData = nullptr)
        : _allowedRoot(Path::GetFullPath(allowedRoot)),
          _fallbackImageData(fallbackImageData)
    {
    }

    String ResolveUri(String baseUri, String relativeUri) override
    {
        if (String::IsNullOrWhiteSpace(baseUri) ||
            String::IsNullOrWhiteSpace(relativeUri))
        {
            return String::Null;
        }

        auto baseAddress = SharedPtr<Uri>();
        auto absoluteAddress = SharedPtr<Uri>();
        if (!Uri::TryCreate(baseUri, UriKind::Absolute, baseAddress) ||
            !Uri::TryCreate(baseAddress, relativeUri, absoluteAddress))
        {
            return String::Null;
        }

        // 此解析器刻意僅允許本機檔案。
        if (!absoluteAddress->get_IsFile())
        {
            return String::Null;
        }

        auto resourcePath = Path::GetFullPath(absoluteAddress->get_LocalPath());
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return String::Null;
        }

        return absoluteAddress->get_AbsoluteUri();
    }

    SharedPtr<Stream> GetEntity(String absoluteUri) override
    {
        auto resourceUri = SharedPtr<Uri>();
        if (!Uri::TryCreate(absoluteUri, UriKind::Absolute, resourceUri) ||
            !resourceUri->get_IsFile())
        {
            return nullptr;
        }

        auto resourcePath = Path::GetFullPath(resourceUri->get_LocalPath());
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return nullptr;
        }

        if (File::Exists(resourcePath))
        {
            return File::OpenRead(resourcePath);
        }

        // 僅對圖像資源使用備援。回傳圖像串流
        // 對缺少的字型或樣式表則無效。
        if (_fallbackImageData != nullptr && IsImageFile(resourcePath))
        {
            return MakeObject<MemoryStream>(_fallbackImageData, false);
        }

        return nullptr;
    }

private:
    String _allowedRoot;
    ArrayPtr<uint8_t> _fallbackImageData;

    bool IsInsideAllowedRoot(String resourcePath)
    {
        auto normalizedRoot = _allowedRoot;
        auto directorySeparator = String(Path::DirectorySeparatorChar, 1);
        if (!normalizedRoot.EndsWith(directorySeparator))
        {
            normalizedRoot += directorySeparator;
        }

        auto normalizedPath = Path::GetFullPath(resourcePath);
        auto comparison = Path::DirectorySeparatorChar == u'\\'
            ? StringComparison::OrdinalIgnoreCase
            : StringComparison::Ordinal;

        return normalizedPath.StartsWith(normalizedRoot, comparison) ||
               String::Equals(normalizedPath, _allowedRoot, comparison);
    }

    static bool IsImageFile(String path)
    {
        auto extension = Path::GetExtension(path);

        return String::Equals(extension, u".png", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".jpg", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".jpeg", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".gif", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".bmp", StringComparison::OrdinalIgnoreCase);
    }
};
```

### **在 SVG 匯入期間解析連結資源**

假設 `assets/diagram.svg` 包含如下相對參考：

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

以下 C++ 範例將 SVG 檔案 URI 作為基礎 URI，並提供自訂解析器。解析器會將相對圖像連結轉換為絕對 URI，並在 Aspose.Slides 處理 SVG 時回傳包含該連結資源的串流。

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <Import/IExternalResourceResolver.h>
#include <system/array.h>
#include <system/environment.h>
#include <system/io/file.h>
#include <system/io/path.h>
#include <system/string.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Import;
using namespace System;
using namespace System::IO;

auto svgFilePath = Path::GetFullPath(Path::Combine(u"assets", u"diagram.svg"));
auto assetDirectory = Path::GetDirectoryName(svgFilePath);
if (String::IsNullOrEmpty(assetDirectory))
{
    assetDirectory = Environment::get_CurrentDirectory();
}

auto svgContent = File::ReadAllText(svgFilePath);

// 基礎 URI 代表 SVG 文件的位置。
auto baseUri = MakeObject<Uri>(svgFilePath)->get_AbsoluteUri();

auto fallbackImageData = ArrayPtr<uint8_t>();
auto fallbackImagePath = Path::Combine(assetDirectory, u"fallback.png");
if (File::Exists(fallbackImagePath))
{
    fallbackImageData = File::ReadAllBytes(fallbackImagePath);
}

auto resolver = MakeObject<LocalSvgResourceResolver>(assetDirectory, fallbackImageData);
auto svgImage = MakeObject<SvgImage>(svgContent, resolver, baseUri);

// ISvgImage 會公開來源內容、二進位資料、基礎 URI 與解析器。
auto importedContent = svgImage->get_SvgContent();
auto importedData = svgImage->get_SvgData();
auto importedBaseUri = svgImage->get_BaseUri();
auto importedResolver = svgImage->get_ExternalResourceResolver();

auto presentation = MakeObject<Presentation>();
auto image = presentation->get_Images()->AddImage(svgImage);

presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(
    ShapeType::Rectangle, 20.0f, 20.0f,
    static_cast<float>(image->get_Width()),
    static_cast<float>(image->get_Height()),
    image);

presentation->Save(u"svg-with-linked-resources.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

`SvgImage` 類別亦提供接受 SVG 資料（位元組陣列或串流）以及外部資源解析器與基礎 URI 的多載方法。

{{% alert title="Important" color="warning" %}}

資源解析器在 Aspose.Slides 處理與渲染 SVG 時，使外部資源可用。它不會修改原始 SVG 標記，也不會自動將已解析的資源嵌入其中。

當 `ISvgImage` 被加入簡報的圖像集合時，PPTX 檔案可能同時包含原始 SVG 表示以及點陣圖備援圖像。連結資源可能會出現在產生的備援圖像中，而儲存的 SVG 中相對連結（如 `images/photo.png`）則保持不變。因此，若原始外部資源不可用，渲染原生 SVG 表示的應用程式可能會省略該連結內容。

{{% /alert %}}

### **建立可攜帶的 SVG 圖片**

若要建立不依賴外部檔案的 SVG 圖片，請在建立 `SvgImage` 前先使 SVG 成為自包含。舉例來說，將連結的圖像 URL 替換為包含圖像資料的 `data:` URI：

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

在所有必要資源嵌入 SVG 內容後，建立 `SvgImage`，將其加入簡報的圖像集合，並如前例所示插入至圖片框中。

### **處理缺少或被阻擋的資源**

當資源 URI 無效、被禁止或無法解析時，`ResolveUri` 應回傳空字串。當資源無法讀取時，`GetEntity` 應回傳 `nullptr`。若可能，Aspose.Slides 會在缺少該資源的情況下繼續處理 SVG。

對於缺少的資源，可回傳備援串流，但其內容必須與請求的資源類型相容。例如，僅在缺少圖像時回傳圖像串流，而非字型或樣式表。

{{% alert title="Security" color="warning" %}}

請勿解析來自不受信任 SVG 檔案的任意檔案路徑或不受限制的網路 URL。應限制允許的協定、目錄與主機。對於網路資源，亦需套用連線逾時、回應大小上限與內容驗證。

{{% /alert %}}

## **將 SVG 轉換為一組形狀**
Aspose.Slides 能將 SVG 轉換為一組形狀，類似於 PowerPoint 中的相應功能：

![PowerPoint Popup Menu](img_01_01.png)

此功能由 [IShapeCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishapecollection/) 介面的 [AddGroupShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishapecollection/) 方法的多載提供，該方法以 [ISvgImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isvgimage/) 物件作為第一個參數。

以下 C++ 範例程式碼示範如何使用此方法將 SVG 檔案轉換為一組形狀：

``` cpp 
#include <DOM/IPresentation.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISvgImage.h>
#include <DOM/Presentation.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

// 原始 SVG 檔案名稱
auto svgFileName = System::String(u"sample.svg");

// 輸出簡報檔案名稱
auto outPptxPath = System::String(u"presentation.pptx");

// 建立新簡報
auto presentation = System::MakeObject<Presentation>();

// 讀取 SVG 檔案內容
auto svgContent = File::ReadAllText(svgFileName);

// 建立 SvgImage 物件
auto svgImage = System::MakeObject<SvgImage>(svgContent);

// 取得投影片尺寸
auto slideSize = presentation->get_SlideSize()->get_Size();

// 將 SVG 圖像轉換為形狀群組並依投影片尺寸縮放
presentation->get_Slides()->idx_get(0)->get_Shapes()->AddGroupShape(svgImage, 0.f, 0.f, slideSize.get_Width(), slideSize.get_Height());

// 以 PPTX 格式儲存簡報
presentation->Save(outPptxPath, SaveFormat::Pptx);
```

## **將圖像以 EMF 形式新增至投影片**
Aspose.Slides for C++ 允許您使用 Aspose.Cells 從 Excel 工作表產生 EMF 圖像，並將其新增至簡報投影片。 

以下 C++ 範例程式碼示範如何操作：

``` cpp 
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/array.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/ImageOrPrintOptions.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/SheetRender.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// 必須在使用任何 Aspose.Cells 類型之前啟動 Aspose.Cells for C++。
Aspose::Cells::Startup();

auto workbook = Aspose::Cells::Workbook(u"chart.xls");
auto sheet = workbook.GetWorksheets().Get(0);

// 將工作表渲染為 EMF。
auto options = Aspose::Cells::ImageOrPrintOptions();
options.SetHorizontalResolution(200);
options.SetVerticalResolution(200);
options.SetImageType(Aspose::Cells::Drawing::ImageType::Emf);

auto sheetRender = Aspose::Cells::SheetRender(sheet, options);

auto presentation = System::MakeObject<Presentation>();
presentation->get_Slides()->RemoveAt(0);

for (auto pageIndex = 0; pageIndex < sheetRender.GetPageCount(); pageIndex++)
{
    // Aspose.Cells 以緩衝區形式返回渲染的頁面，Aspose.Slides 將其作為圖像加入。
    auto emfData = sheetRender.ToImage(pageIndex);
    auto emfBytes = System::MakeArray<uint8_t>(emfData.GetLength(), emfData.GetData());
    auto emfImage = presentation->get_Images()->AddImage(emfBytes);

    auto slide = presentation->get_Slides()->AddEmptySlide(
        presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank));
    auto slideSize = presentation->get_SlideSize()->get_Size();
    slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, slideSize.get_Width(), slideSize.get_Height(), emfImage);
}

presentation->Save(u"Saved.pptx", SaveFormat::Pptx);
presentation->Dispose();
workbook.Dispose();

Aspose::Cells::Cleanup();
```

## **取代圖像集合中的圖像**

Aspose.Slides 讓您取代儲存在簡報圖像集合中的圖像，包括投影片形狀使用的圖像。本節說明了更新集合中圖像的多種方式。您可以使用原始位元組資料、[IImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iimage/) 執行個體，或是集合中已存在的其他圖像來取代圖像。

依照以下步驟執行：

1. 使用 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別載入包含圖像的簡報檔案。
2. 從檔案載入新圖像至位元組陣列。
3. 使用位元組陣列將目標圖像取代為新圖像。
4. 在第二種方法中，將圖像載入 [IImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iimage/) 物件，並以該物件取代目標圖像。
5. 在第三種方法中，使用簡報圖像集合中已存在的圖像取代目標圖像。
6. 將修改後的簡報寫入為 PPTX 檔案。

```cpp
#include <DOM/IPPImage.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

// 實例化表示簡報檔案的 Presentation 類別。
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// 第一種方式。
auto imageData = File::ReadAllBytes(u"image0.jpeg");
auto oldImage = presentation->get_Image(0);
oldImage->ReplaceImage(imageData);

// 第二種方式。
auto newImage = Images::FromFile(u"image1.png");
oldImage = presentation->get_Image(1);
oldImage->ReplaceImage(newImage);
newImage->Dispose();

// 第三種方式。
oldImage = presentation->get_Image(2);
oldImage->ReplaceImage(presentation->get_Image(3));

// 將簡報儲存至檔案。
presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}

使用 Aspose 免費的 [Text to GIF](https://products.aspose.app/slides/zh-hant/text-to-gif) 轉換器，您可以輕鬆為文字添加動畫並從文字建立 GIF。 

{{% /alert %}}

## **常見問題**

**插入後原始圖像解析度是否保持不變？**

是。會保留來源像素，但最終外觀取決於投影片上 [picture](/slides/zh-hant/cpp/picture-frame/) 的縮放方式以及儲存時的壓縮情況。

**一次性在數十張投影片上取代相同商標的最佳方法是什麼？**

將商標放在母片或版面配置上，並在簡報的圖像集合中取代——更新會傳播至所有使用該資源的元件。

**插入的 SVG 能轉換為可編輯的形狀嗎？**

可以。您可以將 SVG 轉換為一組形狀，之後各個部件即可使用標準形狀屬性進行編輯。

**如何一次性將圖片設定為多張投影片的背景？**

在母片或相關版面配置上 [Assign the image as the background](/slides/zh-hant/cpp/presentation-background/)，使用該母片/版面的投影片皆會繼承此背景。

**如何防止因為大量圖片導致簡報檔案過大？**

重複使用同一圖像資源而非多份副本，選擇合理的解析度，儲存時套用壓縮，並在適當情況下將重複的圖形放在母片上。