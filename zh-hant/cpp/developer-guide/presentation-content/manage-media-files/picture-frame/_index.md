---
title: 使用 C++ 管理簡報中的圖片框架
linktitle: 圖片框架
type: docs
weight: 10
url: /zh-hant/cpp/picture-frame/
keywords:
- 圖片框架
- 新增圖片框架
- 建立圖片框架
- 嵌入影像
- 連結影像
- 擷取影像
- 點陣影像
- SVG 影像
- 裁剪影像
- 刪除裁剪區域
- 壓縮影像
- StretchOffset
- 圖片框架格式設定
- 相對比例
- 影像效果
- 長寬比
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 在簡報中建立、格式化、連結、裁剪、擷取與壓縮圖片框架。"
---
## **概述**

圖片框架是一種投影片形狀，用於顯示影像。在 Aspose.Slides 中，影像資源與顯示它的形狀是分開的物件：一個 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 透過其 [image collection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/get_images/) 擁有嵌入的影像資源，而 [IPictureFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipictureframe/) 控制影像的位置、大小、線條格式、旋轉、裁剪、圖片效果以及其他框架層級設定。

當同一張影像需要顯示多次時，此分離非常有用。只需將影像加入簡報一次，保留回傳的 [IPPImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ippimage/)，在建立圖片框架時重複使用該影像資源。

圖片框架可包含 PNG、JPEG 等點陣圖，也可包含向量 SVG 圖片。它們也可以參照連結影像，而不是將影像位元組儲存在簡報中。此選擇會影響可移植性、檔案大小、擷取與匯出行為，因此在套用格式或最佳化之前，先決定影像應如何儲存是很有幫助的。

## **新增並格式化嵌入影像**

對於嵌入影像，先將影像資料加入簡報，然後使用 [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/shapecollection/addpictureframe/) 建立圖片框架。影像會成為簡報封裝的一部份，因而在搬移到其他電腦時仍保持自包含。

以下範例加入 JPEG 影像，以影像的原始尺寸建立框架，並套用線條格式與旋轉：

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.jpg");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 100, image->get_Width(), image->get_Height(), image);
pictureFrame->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pictureFrame->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pictureFrame->get_LineFormat()->set_Width(3.0);
pictureFrame->set_Rotation(15.0f);

presentation->Save(u"picture-frame.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

圖片框架控制顯示的幾何形狀；變更框架尺寸不會改變嵌入影像資源中儲存的原始像素尺寸。此區別在之後裁剪或壓縮影像時變得重要。

## **使用相對比例**

[IPictureFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipictureframe/) 提供相對寬高縮放功能。`1.0` 代表原始圖片大小的 100%。相對比例在工作流程需要保留與來源影像尺寸之關係，而非手動計算最終尺寸時非常有用。

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.jpg");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, image);
pictureFrame->set_RelativeScaleWidth(1.35f);
pictureFrame->set_RelativeScaleHeight(0.8f);

presentation->Save(u"relative-scale.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

相對比例會變更框架的縮放設定；它不會重新取樣或壓縮嵌入影像。

## **嵌入與連結影像**

嵌入圖片將影像資料儲存在簡報內，因此是最安全的可移植性與可預測渲染選擇。連結圖片則透過 [ISlidesPicture](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidespicture/) 的連結路徑儲存外部位置，而不是以相同方式嵌入影像資料。

連結影像可以減少 PPTX 中的影像資料量，但會引入外部相依性。開啟或渲染簡報的應用程式必須能存取該連結檔案。若路徑變更、檔案移動或資源不可用，連結圖片可能無法如預期顯示。對於必須透過電子郵件傳送、封存或在隔離環境中渲染的簡報，嵌入影像通常較為可靠。

### **新增連結影像**

以下範例建立圖片框架，並指向本機影像檔。此範例僅處理影像連結；影片連結屬於不同的媒體工作流程，故未混入此範例。

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/path.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 320, 180, nullptr);
auto linkPath = Path::GetFullPath(u"linked-image.jpg");
pictureFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(linkPath);

presentation->Save(u"linked-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

當外部檔案管理是有意為之時才使用連結。不要僅將其作為壓縮的替代方案：一個破損影像相依性的較小 PPTX，通常不如較大且自包含的簡報有用。

## **從圖片框架擷取影像**

在從現有簡報擷取影像之前，請先確認形狀實際上是 [IPictureFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipictureframe/)，且其中包含嵌入影像。連結圖片框架可能不包含可以相同方式擷取的影像位元組。

### **擷取點陣圖影像**

現代影像 API 直接使用 [IImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iimage/)。以下範例在投影片上找到第一個嵌入的點陣圖，並將其儲存為 PNG：

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IPictureFrame>(shape))
    {
        continue;
    }

    auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
    auto embeddedImage = pictureFrame->get_PictureFormat()->get_Picture()->get_Image();
    if (embeddedImage == nullptr || embeddedImage->get_SvgImage() != nullptr)
    {
        continue;
    }

    auto rasterImage = embeddedImage->get_Image();
    rasterImage->Save(u"extracted-image.png", ImageFormat::Png);
    break;
}

presentation->Dispose();
```

透過 [IImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iimage/) 儲存會將擷取的影像轉換為所要求的輸出格式。如果需要儲存在簡報中的編碼位元組，而不是轉換後的點陣檔，請使用影像資源的二進位資料。

### **擷取 SVG 影像**

對於 SVG 圖片，[IPPImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ippimage/) 會公開一個 [ISvgImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isvgimage/) 物件。這讓您能直接取得 SVG 資料，而不必先將圖片光柵化。

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ISvgImage.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IPictureFrame>(shape))
    {
        continue;
    }

    auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
    auto embeddedImage = pictureFrame->get_PictureFormat()->get_Picture()->get_Image();
    if (embeddedImage == nullptr)
    {
        continue;
    }

    auto svgImage = embeddedImage->get_SvgImage();
    if (svgImage == nullptr)
    {
        continue;
    }

    File::WriteAllBytes(u"extracted-image.svg", svgImage->get_SvgData());
    break;
}

presentation->Dispose();
```

將 SVG 內容保留為 SVG 可以在簡報中保留向量來源。PNG、JPEG 等點陣匯出必然將向量內容轉換為像素。PDF 或 SVG 投影片匯出同樣是渲染動作，因此匯出的圖形不應被視為原始嵌入 SVG 的逐位元複製；當需要原始向量資源時，請使用嵌入的 [ISvgImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isvgimage/) 資料。

## **裁剪影像**

裁剪會改變在框架內可見的影像部分。[IPictureFillFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipicturefillformat/) 的裁剪值以來源影像尺寸的百分比表示。裁剪不會立即刪除嵌入影像中的隱藏像素；它僅改變可見區域。

以下範例安全地找到圖片框架並套用裁剪值：

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    pictureFrame->get_PictureFormat()->set_CropLeft(23.6f);
    pictureFrame->get_PictureFormat()->set_CropRight(21.5f);
    pictureFrame->get_PictureFormat()->set_CropTop(3.0f);
    pictureFrame->get_PictureFormat()->set_CropBottom(31.0f);
    presentation->Save(u"cropped-image.pptx", SaveFormat::Pptx);
}

presentation->Dispose();
```

因為隱藏的影像資料仍然存在，之後仍可更改裁剪而不失去原始像素。若檔案大小比可逆性更重要，下一節說明的裁剪區域可實體移除。

## **移除裁剪的影像資料**

[IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) 會移除當前裁剪矩形外的影像資料，並回傳結果影像資源。這可以減少檔案大小，但屬於破壞性最佳化：簡報儲存後，已移除的像素將無法再進行取消裁剪。

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"cropped-image.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto croppedImage = pictureFrame->get_PictureFormat()->DeletePictureCroppedAreas();
    if (croppedImage != nullptr)
    {
        presentation->Save(u"cropped-data-removed.pptx", SaveFormat::Pptx);
    }
}

presentation->Dispose();
```

此方法可能會在簡報中加入新的影像資源。如果原始影像同時被其他圖片框架使用，這些框架仍需要其既有資源，因此刪除裁剪區域不一定會減少影像總數。使用此方法裁剪 WMF 或 EMF 內容時，會將裁剪結果光柵化為 PNG。

## **壓縮點陣圖影像**

[IPictureFillFormat::CompressImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipicturefillformat/compressimage/) 會根據圖片實際顯示的大小降低點陣圖解析度。它也可以在同一次操作中移除裁剪區域。當影像被重新調整大小或裁剪時，方法會回傳 `true`；若無需變更則回傳 `false`。

當標準目標解析度足夠時，使用預先定義的 [PicturesCompression](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/picturescompression/) 值：

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/PicturesCompression.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto compressed = pictureFrame->get_PictureFormat()->CompressImage(true, PicturesCompression::Dpi150);
    Console::WriteLine(compressed ? String(u"The image was compressed.") : String(u"No compression was necessary."));
    presentation->Save(u"compressed-image.pptx", SaveFormat::Pptx);
}

presentation->Dispose();
```

若需要特定目標，亦可傳入自訂的正 DPI 數值，代替列舉值。

壓縮僅適用於點陣圖。SVG 與圖式檔案不會因此光柵壓縮流程而減少。亦請記得，較低的解析度與已刪除的裁剪區域無法從最佳化後的簡報中復原。請根據影像實際檢視或匯出的最大尺寸選擇目標解析度，而非全局套用最低 DPI。

## **管理影像變換效果**

欲取得涵蓋亮度、對比度、顏色變換、模糊、透明度效果、排序鏈、檢查、移除與往返驗證的完整工作流程，請參閱 [Image Transform Effects](/slides/zh-hant/cpp/image-transform-effects/)。

## **鎖定圖片框架幾何**

[IPictureFrameLock](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipictureframelock/) 設定控制哪些編輯操作會被禁用於圖片框架。例如，[aspect-ratio lock](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) 會在調整大小時保留形狀的比例。

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.jpg");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 100, image->get_Width(), image->get_Height(), image);
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);

presentation->Save(u"locked-picture-frame.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

此鎖定套用於圖片框架形狀本身，並不會強制來源影像重新取樣或永久改變為相同的長寬比。

## **調整 StretchOffset 值**

當圖片填滿模式為 stretch 時，[IPictureFillFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipicturefillformat/) 上的 stretch‑offset 值會相對於圖片框架的邊界盒定義填滿矩形。正百分比會從邊緣內縮，而負百分比則會向外延伸。

這與裁剪不同。裁剪值決定來源影像哪一部分可見；stretch offset 則改變可見的圖片填滿被拉伸到的矩形。

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.png");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10, 10, 400, 300, image);
pictureFrame->get_PictureFormat()->set_PictureFillMode(PictureFillMode::Stretch);
pictureFrame->get_PictureFormat()->set_StretchOffsetLeft(12.0f);
pictureFrame->get_PictureFormat()->set_StretchOffsetRight(12.0f);
pictureFrame->get_PictureFormat()->set_StretchOffsetTop(8.0f);
pictureFrame->get_PictureFormat()->set_StretchOffsetBottom(8.0f);

presentation->Save(u"stretch-offsets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

使用 stretch offset 來放置填充。若目標是隱藏來源影像的邊緣，請使用裁剪屬性。

## **儲存、檔案大小與匯出考量**

在將影像儲存與圖片框架格式化分開處理時，主要的權衡較易管理：

- **嵌入影像** 使簡報自包含，是共享與伺服器端渲染最可靠的選擇，但大型點陣圖會增加 PPTX 檔案大小與記憶體使用量。
- **連結影像** 可以讓封裝較小，但簡報依賴外部檔案在其儲存路徑或位置仍可取得。
- **裁剪** 初始為非破壞性。隱藏的像素會保留，直至明確刪除裁剪區域或在壓縮時移除。
- **壓縮** 可大幅減少過大點陣圖的檔案大小，但會犧牲來源解析度。應在確定投影片上實際顯示尺寸後再套用。
- **SVG 影像** 在需要保留向量的情況下應保留為 SVG。當需要向量資源本身時，直接擷取嵌入的 SVG。點陣投影片匯出始終會將渲染的投影片轉為像素。
- **重複影像** 應盡可能重複使用已有的 [IPPImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ippimage/) 資源，而不是在簡報工作流程中一再載入相同檔案。

對於大型簡報，影像最佳化通常在有選擇性地執行時最有效：將標誌與圖表保留為向量內容，依實際顯示大小壓縮照片，僅在不需日後編輯時移除裁剪像素，除非相依性管理是部署設計的一部分，否則避免使用外部連結。

## **常見問題**

**圖片框架與影像資源之間的差異是什麼？**

[IPPImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ippimage/) 代表與簡報關聯的影像資源。[IPictureFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipictureframe/) 則是投影片上的形狀，用來顯示影像並儲存框架層級的幾何與格式，例如大小、旋轉、裁剪值、效果與鎖定。

**我應該嵌入還是連結影像？**

當簡報必須可移植、封存或在沒有外部資源的情況下渲染時，請嵌入影像。只有在有意將影像檔案保留在 PPTX 之外，且能可靠維護外部位置時，才使用連結。

**裁剪會減少 PPTX 檔案大小嗎？**

單純的裁剪不會。一般的裁剪設定會隱藏來源影像的部分，但仍保留底層像素。若要永久移除這些像素，請使用 [IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) 或在壓縮時一併移除裁剪區域。

**壓縮後能恢復影像品質嗎？**

不能。壓縮會降低儲存的點陣解析度，移除裁剪區域則會丟棄影像資料。如日後需要高解析度編輯，請在簡報外保留原始來源影像。

**SVG 影像應如何處理？**

當向量保真度重要時，請將 SVG 內容保留為 SVG。可直接擷取嵌入的 [ISvgImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isvgimage/) 資料。將投影片渲染為 PNG、JPEG 等點陣格式時，SVG 會被光柵化。

**閱讀現有投影片時，如何避免不安全的轉型？**

在使用圖片框架專屬成員之前，先檢查形狀類型。使用 [IPictureFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipictureframe/) 進行類型測試，再執行執行時轉型，並將轉型結果指派給局部變數後才存取圖片框架的特定成員。