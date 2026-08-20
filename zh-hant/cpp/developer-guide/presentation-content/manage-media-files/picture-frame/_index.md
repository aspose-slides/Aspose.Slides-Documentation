---
title: 使用 C++ 管理簡報中的圖片框
linktitle: 圖片框
type: docs
weight: 10
url: /zh-hant/cpp/picture-frame/
keywords:
- 圖片框
- 新增圖片框
- 建立圖片框
- 嵌入式圖像
- 鏈接圖像
- 擷取圖像
- 點陣圖像
- SVG 圖像
- 裁剪圖像
- 刪除已裁剪區域
- 壓縮圖像
- StretchOffset
- 圖片框格式設定
- 相對縮放
- 圖像效果
- 長寬比
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 在簡報中建立、格式化、鏈接、裁剪、擷取與壓縮圖片框。"
---
## **概觀**

圖片框是一種投影片形狀，用於顯示圖像。在 Aspose.Slides 中，圖像資源與顯示它的形狀是分開的物件：一個 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 透過其 [image collection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/get_images/) 擁有嵌入的圖像資源，而一個 [IPictureFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipictureframe/) 控制圖像的位置、大小、線條格式、旋轉、裁剪、圖片效果以及其他框級設定。

此分離在同一圖像需要顯示多次時很有用。將圖像加入簡報一次，保留返回的 [IPPImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ippimage/)，在建立圖片框時使用該圖像資源。

圖片框可以容納 PNG 或 JPEG 等點陣圖，以及 SVG 向量圖。它們也可以引用鏈接圖像，而不是將圖像位元組存儲在簡報中。此選擇會影響可移植性、檔案大小、擷取與匯出行為，因此在套用格式或最佳化之前，先決定圖像的存儲方式是很有幫助的。

## **新增與格式化嵌入式圖像**

對於嵌入式圖像，將圖像資料加入簡報，然後使用 [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/shapecollection/addpictureframe/) 建立圖片框。圖像會成為簡報套件的一部份，因而在搬移至其他電腦時仍保持自包含。

以下範例加入 JPEG 圖像，依圖像的原始尺寸建立框，並套用線條格式與旋轉：

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

圖片框控制顯示的幾何形狀；變更框的大小不會改變嵌入式圖像資源中儲存的原始像素尺寸。此區別在之後裁剪或壓縮圖像時變得重要。

## **使用相對縮放**

[IPictureFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipictureframe/) 提供框的相對寬度與高度縮放。值 `1.0` 代表原圖大小的 100%。相對縮放在工作流程需要保留與來源圖像尺寸之關係，而不是手動計算最終尺寸時非常有用。

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

相對縮放僅變更框的縮放設定；它不會重新取樣或壓縮嵌入式圖像。

## **嵌入式與鏈接圖像**

嵌入式圖片將圖像資料存於簡報內，因而是可移植性與可預測呈現最安全的選擇。鏈接圖片則透過 [ISlidesPicture](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidespicture/) 的連結路徑指向外部位置，而不是以相同方式嵌入圖像資料。

鏈接圖像可以減少 PPTX 中的圖像資料量，但會產生外部相依性。必須確保連結檔案在開啟或渲染簡報的應用程式可存取。若路徑變更、檔案搬移或資源不可用，鏈接圖片可能無法如預期顯示。對於必須以電子郵件傳送、歸檔或在隔離環境中渲染的簡報，嵌入式圖像通常較可靠。

### **新增鏈接圖像**

以下範例建立圖片框，並指向本機圖像檔。此範例僅處理圖像連結；影片連結屬於另一個媒體工作流程，故未混入此範例。

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

在需要外部檔案管理時使用連結。不應僅將其視為壓縮的替代方案：擁有破損圖像相依性的較小 PPTX 通常不如較大且自包含的簡報實用。

## **從圖片框中擷取圖像**

在從現有簡報擷取圖像之前，先確認形狀實際上是 [IPictureFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipictureframe/) 且包含嵌入式圖像。鏈接圖片框可能不包含可直接擷取的圖像位元組。

### **擷取點陣圖像**

現代圖像 API 直接使用 [IImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iimage/)。以下範例在投影片上找到第一個嵌入的點陣圖，並將其另存為 PNG：

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

透過 [IImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iimage/) 儲存會將擷取的圖像轉換為請求的輸出格式。如果需要簡報中儲存的編碼位元組，而不是轉換後的點陣檔，請使用圖像資源的二進位資料。

### **擷取 SVG 圖像**

對於 SVG 圖片， [IPPImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ippimage/) 會公開一個 [ISvgImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isvgimage/) 物件。這讓您可以直接取得 SVG 資料，而不必先將圖片光柵化。

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

將 SVG 內容保留為 SVG 可在簡報內保持向量來源。PNG 或 JPEG 等點陣匯出必須將該向量內容渲染為像素。PDF 或 SVG 投影片匯出同樣是渲染操作，因此匯出的圖形不應被視為原始嵌入 SVG 的逐位元拷貝；需要原始向量資源時，請使用嵌入的 [ISvgImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isvgimage/) 資料。

## **裁剪圖像**

裁剪會變更框內可見的圖像部分。[IPictureFillFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipicturefillformat/) 上的裁剪值是來源圖像尺寸的百分比。裁剪不會立即刪除嵌入圖像中被隱藏的像素；它僅改變可見區域。

以下範例安全地找到圖片框並套用裁剪值：

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

因為被隱藏的圖像資料仍然存在，之後可以變更裁剪而不失去原始像素。若檔案大小比可逆性更重要，可依下節所述實際移除裁剪區域。

## **移除已裁剪的圖像資料**

[IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) 會移除當前裁剪矩形之外的圖像資料，並返回結果圖像資源。這可以減少檔案大小，但屬於破壞性最佳化：簡報儲存後，已移除的像素將不再可供日後取消裁剪使用。

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

此方法可能會向簡報新增圖像資源。如果原始圖像同時被其他圖片框使用，這些框仍需保留其現有資源，故刪除裁剪區域不一定會減少總圖像數量。使用此方法裁剪 WMF 或 EMF 內容會將裁剪結果光柵化為 PNG。

## **壓縮點陣圖像**

[IPictureFillFormat::CompressImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipicturefillformat/compressimage/) 會根據圖片顯示的尺寸降低點陣圖解析度。它也可以在同一操作中移除裁剪區域。方法在圖像被重新調整大小或裁剪時返回 `true`，在未做變更時返回 `false`。

當標準目標解析度足以時，使用預設的 [PicturesCompression](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/picturescompression/) 值：

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

若需要特定目標，可傳入自訂的正值 DPI 而非列舉值。

壓縮僅針對點陣圖像。SVG 與圖形圖檔內容不會受到此點陣壓縮工作流程的影響。同時也請記得，較低的解析度與已刪除的裁剪區域無法從最佳化後的簡報中恢復。應根據圖像實際觀看或匯出的最大尺寸來選擇目標解析度，而非全局套用最低 DPI。

## **檢查圖像效果**

圖片效果儲存在框使用的圖片上。圖像變換集合可能包含透明度的固定 Alpha 調製以及亮度的亮度調整等效果。以下範例安全地讀取投影片上第一個圖片框的兩種效果：

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/Effects/ILuminance.h>
#include <DOM/Effects/ILuminanceEffectiveData.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
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
    auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();

    for (auto&& effect : imageTransform)
    {
        if (ObjectExt::Is<IAlphaModulateFixed>(effect))
        {
            auto alphaModulateFixed = ExplicitCast<IAlphaModulateFixed>(effect);
            auto transparency = 100.0f - alphaModulateFixed->get_Amount();
            Console::WriteLine(String(u"Transparency: ") + transparency);
        }

        if (ObjectExt::Is<ILuminance>(effect))
        {
            auto luminanceEffect = ExplicitCast<ILuminance>(effect);
            auto luminance = luminanceEffect->GetEffective();
            Console::WriteLine(String(u"Brightness: ") + luminance->get_Brightness());
            Console::WriteLine(String(u"Contrast: ") + luminance->get_Contrast());
        }
    }
}

presentation->Dispose();
```

這些效果會改變圖像在框內的呈現方式；它們不會改寫原始嵌入圖像的位元組。

## **鎖定圖片框幾何形狀**

[IPictureFrameLock](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipictureframelock/) 設定控制哪些編輯操作會對圖片框被禁用。例如，[aspect-ratio lock](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) 在調整大小時會保留形狀的比例。

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

此鎖定套用於圖片框形狀本身，並不會強制將來源圖像重新取樣或永久改變為相同的長寬比。

## **調整 StretchOffset 值**

當圖片填充模式為 stretch 時，[IPictureFillFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipicturefillformat/) 上的 stretch‑offset 值定義相對於圖片框邊界的填充矩形。正百分比會從邊緣向內縮進，負百分比則向外延伸。

這與裁剪不同。裁剪值選擇來源圖像的可見部分；stretch offset 則改變可見圖片填充被拉伸的矩形。

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

使用 stretch offset 來調整填充位置。若目標是隱藏來源圖像的邊緣，請使用裁剪屬性。

## **儲存、檔案大小與匯出考量**

將圖像儲存與圖片框格式化分開處理時，主要的取捨較易掌控：

- **嵌入式圖像** 使簡報自包含，對於共享與伺服器端渲染最可靠，但大型點陣圖會增加 PPTX 大小與記憶體使用。
- **鏈接圖像** 可讓套件較小，但簡報依賴外部檔案在指定路徑或位置保持可用。
- **裁剪** 初始為非破壞性。隱藏的像素會一直保留，直到明確刪除裁剪區域或在壓縮時移除。
- **壓縮** 可大幅減少過大點陣圖的檔案大小，但會犧牲來源解析度。應在確定投影片上最終顯示尺寸後再套用。
- **SVG 圖像** 若向量保真度重要，應保持為 SVG。需要向量資源時直接擷取嵌入的 SVG。點陣投影片匯出始終會將渲染的投影片轉換為像素。
- **重複使用的圖像** 應盡可能重用現有的 [IPPImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ippimage/) 資源，而非在工作流程中重複載入相同檔案。

對於大型簡報，圖像最佳化通常在有選擇性地執行時最有效：將標誌與圖表保留為向量內容，根據實際顯示尺寸壓縮照片，僅在不再需要後續編輯時移除裁剪像素，除非依賴管理是部署設計的一部份，否則避免使用外部鏈接。

## **常見問題**

**圖片框與圖像資源有何不同？**

[IPPImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ippimage/) 代表與簡報關聯的圖像資源。[IPictureFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipictureframe/) 則是投影片上的形狀，用於顯示圖像並儲存框級幾何與格式設定，如大小、旋轉、裁剪值、效果與鎖定。

**應該嵌入圖像還是鏈接圖像？**

當簡報必須可移植、歸檔或在無法存取外部資源的環境中渲染時，請嵌入圖像。僅在刻意將圖像檔案保留在 PPTX 之外且外部位置能可靠維護時，才使用鏈接圖像。

**裁剪會減少 PPTX 檔案大小嗎？**

單純裁剪不會。一般的裁剪設定會隱藏來源圖像的部分，但仍保留底層像素。若想永久移除這些像素，可使用 [IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) 或在壓縮時同時移除裁剪區域。

**壓縮後能恢復圖像品質嗎？**

不能。壓縮會降低儲存的點陣解析度，且移除裁剪區域會刪除圖像資料。若日後可能需要高解析度編輯，請在簡報外保留原始來源圖像。

**SVG 圖像應如何處理？**

當向量完整性重要時，請保留 SVG 內容為 SVG。可直接擷取嵌入的 [ISvgImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/isvgimage/) 資料。將投影片渲染為 PNG 或 JPEG 等點陣格式時，SVG 會被光柵化為像素。

**如何避免在讀取現有投影片時產生不安全的類型轉換？**

在使用圖片框專屬成員之前，先檢查形狀類型。使用 [IPictureFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipictureframe/) 進行測試，然後再執行執行階段轉型，並將轉型結果指派給本地變數後再存取圖片框相關成員。