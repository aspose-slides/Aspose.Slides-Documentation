---
title: 使用 C++ 在簡報中管理圖片框
linktitle: 圖片框
type: docs
weight: 10
url: /zh-hant/cpp/picture-frame/
keywords:
- 圖片框
- 新增圖片框
- 建立圖片框
- 新增影像
- 建立影像
- 擷取影像
- 點陣影像
- 向量影像
- 裁剪影像
- 已裁剪區域
- StretchOff 屬性
- 圖片框格式設定
- 圖片框屬性
- 相對縮放
- 影像效果
- 長寬比例
- 影像透明度
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 為 PowerPoint 與 OpenDocument 簡報新增圖片框。簡化工作流程並提升投影片設計。"
---
## **簡介**

圖片框是一種包含圖像的形狀─它就像框中的圖片。

您可以透過圖片框將圖像新增到投影片中。這樣，您可以藉由格式化圖片框來格式化圖像。

{{% alert title="Tip" color="primary" %}} 
Aspose 提供免費的轉換器──[JPEG 轉 PowerPoint](https://products.aspose.app/slides/zh-hant/import/jpg-to-ppt) 與 [PNG 轉 PowerPoint](https://products.aspose.app/slides/zh-hant/import/png-to-ppt)──讓使用者能快速從圖像建立簡報。 
{{% /alert %}} 

## **建立圖片框**

1. 建立 [Presentation 類別](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation) 的實例。  
2. 透過索引取得投影片的參考。  
3. 透過將影像加入與簡報物件關聯的 [IImagescollection](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_image_collection) 以建立 [IPPImage](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_p_p_image) 物件，該物件將用於填充形狀。  
4. 指定影像的寬度與高度。  
5. 透過參照投影片的形狀物件所提供的 `AddPictureFrame` 方法，根據影像的寬度與高度建立 [PictureFrame](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.picture_frame)。  
6. 將圖片框（包含圖片）加入投影片。  
7. 將已修改的簡報寫入為 PPTX 檔案。  

此 C++ 程式碼展示如何建立圖片框：

```c++
// 文件目錄的路徑。
const String outPath = u"../out/PictureFrameFormatting_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// 載入所需的簡報
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 取得第一張投影片
SharedPtr<ISlide> slide = pres->get_Slide(0);

// 載入將加入簡報影像集合的圖像
// 取得圖片
auto image = Images::FromFile(filePath);

// 將影像加入簡報的影像集合
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// 將圖片框加入投影片
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// 設定相對縮放的寬度與高度
pf->set_RelativeScaleHeight(0.8);
pf->set_RelativeScaleWidth(1.35);
// 對 PictureFrame 套用一些格式設定
pf->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pf->get_LineFormat()->set_Width ( 20);
pf->set_Rotation( 45);

//將 PPTX 檔案寫入磁碟
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert color="warning" %}} 
圖片框讓您能快速依據圖像建立簡報投影片。將圖片框與 Aspose.Slides 的儲存選項結合使用時，您可以操作輸入/輸出以將圖像從一種格式轉換為另一種格式。您可能想參考以下頁面：轉換 [image to JPG](https://products.aspose.com/slides/zh-hant/cpp/conversion/image-to-jpg/)；轉換 [JPG to image](https://products.aspose.com/slides/zh-hant/cpp/conversion/jpg-to-image/)；轉換 [JPG to PNG](https://products.aspose.com/slides/zh-hant/cpp/conversion/jpg-to-png/)、轉換 [PNG to JPG](https://products.aspose.com/slides/zh-hant/cpp/conversion/png-to-jpg/)；轉換 [PNG to SVG](https://products.aspose.com/slides/zh-hant/cpp/conversion/png-to-svg/)、轉換 [SVG to PNG](https://products.aspose.com/slides/zh-hant/cpp/conversion/svg-to-png/)。 
{{% /alert %}}

## **建立具有相對縮放的圖片框**

透過調整影像的相對縮放，您可以建立更為複雜的圖片框。  

1. 建立 [Presentation 類別](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation) 的實例。  
2. 透過索引取得投影片的參考。  
3. 將影像加入簡報的影像集合。  
4. 透過將影像加入與簡報物件關聯的 [IImagescollection](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_image_collection) 以建立 [IPPImage](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_p_p_image) 物件，該物件將用於填充形狀。  
5. 在圖片框中指定影像的相對寬度與高度。  
6. 將已修改的簡報寫入為 PPTX 檔案。  

此 C++ 程式碼展示如何建立具有相對縮放的圖片框：

```c++
// 文件目錄的路徑。
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// 載入所需的簡報
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 取得第一張投影片
SharedPtr<ISlide> slide = pres->get_Slide(0);

// 載入要加入簡報影像集合的圖像
// 取得圖片
auto image = Images::FromFile(filePath);

// 將影像加入簡報的影像集合
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// 將圖片框加入投影片
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// 設定相對縮放的寬度與高度
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

//將 PPTX 檔案寫入磁碟
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **從圖片框擷取點陣圖影像**

您可以從 [PictureFrame](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.picture_frame) 物件擷取點陣圖影像，並以 PNG、JPG 等格式儲存。以下程式碼示範如何從文件「sample.pptx」中擷取影像並以 PNG 格式儲存。

```c++
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstSlide = presentation->get_Slide(0);
auto firstShape = firstSlide->get_Shape(0);
    
if (ObjectExt::Is<IPictureFrame>(firstShape))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(firstShape);
    auto image = pictureFrame->get_PictureFormat()->get_Picture()->get_Image()->get_SystemImage();

    image->Save(u"slide_1_shape_1.png", ImageFormat::get_Png());
}

presentation->Dispose();
```

## **從圖片框擷取 SVG 影像**

當簡報在 [PictureFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/pictureframe/) 形狀中包含 SVG 圖形時，Aspose.Slides for C++ 可讓您以完整保真度取得原始向量影像。透過遍歷投影片的形狀集合，您可以辨識每個 [PictureFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/pictureframe/)，檢查底層的 [IPPImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ippimage/) 是否包含 SVG 內容，然後將該影像以原生 SVG 格式儲存至磁碟或串流。  

以下程式碼示範如何從圖片框擷取 SVG 影像：

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IPictureFrame>(shape))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
    auto svgImage = pictureFrame->get_PictureFormat()->get_Picture()->get_Image()->get_SvgImage();
    if (svgImage != nullptr)
    {
        File::WriteAllText(u"output.svg", svgImage->get_SvgContent());
    }
}

presentation->Dispose();
```

## **取得影像的透明度**

Aspose.Slides 允許您取得套用於影像的透明度效果。此 C++ 程式碼示範此操作：

```c++
auto presentation = System::MakeObject<Presentation>(u"Test.pptx");
auto pictureFrame = System::ExplicitCast<IPictureFrame>(presentation->get_Slide(0)->get_Shape(0));
auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
for (auto&& effect : imageTransform)
{
    if (System::ObjectExt::Is<IAlphaModulateFixed>(effect))
    {
        float transparencyValue = 100.0f - (System::ExplicitCast<IAlphaModulateFixed>(effect))->get_Amount();
        System::Console::WriteLine(System::String(u"Picture transparency: ") + transparencyValue);
    }
}
```

{{% alert color="primary" %}} 
所有套用於影像的效果皆可在 [Aspose::Slides::Effects](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.effects/) 中找到。 
{{% /alert %}}

## **取得影像的亮度與對比度**

Aspose.Slides 允許您取得套用於影像的亮度與對比度效果。[ILuminance](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.effects/iluminance/) 介面代表此影像變換效果。  

此 C++ 程式碼示範如何從圖片框取得亮度與對比度設定：

```c++
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shape(0);
auto pictureFrame = System::ExplicitCast<IPictureFrame>(shape);

auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
for (auto&& effect : imageTransform)
{
    if (System::ObjectExt::Is<ILuminance>(effect))
    {
        auto luminance = System::ExplicitCast<ILuminance>(effect)->GetEffective();
        auto brightness = luminance->get_Brightness();
        auto contrast = luminance->get_Contrast();

        Console::WriteLine(System::String(u"Brightness: ") + brightness);
        Console::WriteLine(System::String(u"Contrast: ") + contrast);
    }
}

presentation->Dispose();
```

## **圖片框格式設定**

Aspose.Slides 提供許多可套用於圖片框的格式化選項。使用這些選項，您可以調整圖片框以符合特定需求。  

1. 建立 [Presentation 類別](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation) 的實例。  
2. 透過索引取得投影片的參考。  
3. 透過將影像加入與簡報物件關聯的 [IImagescollection](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_image_collection) 以建立 [IPPImage](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_p_p_image) 物件，該物件將用於填充形狀。  
4. 指定影像的寬度與高度。  
5. 透過參照投影片的 [IShapes](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_shape_collection) 物件所提供的 [AddPictureFrame](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) 方法，根據影像的寬度與高度建立 `PictureFrame`。  
6. 將圖片框（包含圖片）加入投影片。  
7. 設定圖片框的線條顏色。  
8. 設定圖片框的線條寬度。  
9. 以正值或負值旋轉圖片框  
   * 正值會順時針旋轉影像。  
   * 負值會逆時針旋轉影像。  
10. 再次將圖片框（包含圖片）加入投影片。  
11. 將已修改的簡報寫入為 PPTX 檔案。  

此 C++ 程式碼示範圖片框格式設定流程：

```c++
// 文件目錄的路徑。
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// 載入所需的簡報
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 取得第一張投影片
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// 載入將加入簡報影像集合的圖像
// 取得圖片
auto image = Images::FromFile(filePath);

// 將影像加入簡報的影像集合
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// 將圖片框加入投影片
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// 設定相對縮放的寬度與高度
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

// 將 PPTX 檔案寫入磁碟
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert title="Tip" color="primary" %}} 
Aspose 最近開發了免費的 [Collage Maker](https://products.aspose.app/slides/zh-hant/collage)。如果您需要 [合併 JPG/JPEG](https://products.aspose.app/slides/zh-hant/collage/jpg) 或 PNG 圖片、[從照片建立格子](https://products.aspose.app/slides/zh-hant/collage/photo-grid)，可使用此服務。 
{{% /alert %}}

## **將影像作為連結加入**

為了避免簡報檔案過大，您可以透過連結方式加入影像（或影片），而非將檔案直接嵌入簡報。此 C++ 程式碼示範如何將影像與影片加入佔位元：

```cpp
auto presentation = System::MakeObject<Presentation>(u"input.pptx");
auto shapesToRemove = System::MakeObject<System::Collections::Generic::List<System::SharedPtr<IShape>>>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

for (auto& autoShape : shapes)
{
    if (autoShape->get_Placeholder() == nullptr)
        continue;

    switch (autoShape->get_Placeholder()->get_Type())
    {
        case Aspose::Slides::PlaceholderType::Picture:
        {
            auto pictureFrame = shapes->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, autoShape->get_X(), autoShape->get_Y(), autoShape->get_Width(), autoShape->get_Height(), nullptr);
            pictureFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(u"https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
            shapesToRemove->Add(autoShape);
            break;
        }

        case Aspose::Slides::PlaceholderType::Media:
        {
            auto videoFrame = shapes->AddVideoFrame(autoShape->get_X(), autoShape->get_Y(), autoShape->get_Width(), autoShape->get_Height(), u"");
            videoFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(u"https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
            videoFrame->set_LinkPathLong(u"https://youtu.be/t_1LYZ102RA");
            shapesToRemove->Add(autoShape);
            break;
        }
    }
}

for (auto& shape : shapesToRemove)
{
    shapes->Remove(shape);
}

presentation->Save(u"output.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **裁剪影像**

此 C++ 程式碼示範如何在投影片上裁剪既有影像：

``` cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;
    
auto presentation = System::MakeObject<Presentation>();
// 建立新的影像物件
auto newImage = presentation->get_Images()->AddImage(Images::FromFile(imagePath));

// 在投影片上新增圖片框
auto picFrame = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 100.0f, 100.0f, 420.0f, 250.0f, newImage);

// 裁剪影像（百分比值）
picFrame->get_PictureFormat()->set_CropLeft(23.6f);
picFrame->get_PictureFormat()->set_CropRight(21.5f);
picFrame->get_PictureFormat()->set_CropTop(3.0f);
picFrame->get_PictureFormat()->set_CropBottom(31.0f);

// 儲存結果
presentation->Save(outPptxFile, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **刪除圖片框的裁剪區域**

若您想刪除框中影像的裁剪區域，可使用 [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) 方法。若不需裁剪，該方法會返回原始影像。  

此 C++ 程式碼示範此操作：

```c++
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"PictureFrameCrop.pptx");
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// 從第一張投影片取得 PictureFrame
System::SharedPtr<IPictureFrame> picFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// 刪除 PictureFrame 影像的裁剪區域並返回裁剪後的影像
System::SharedPtr<IPPImage> croppedImage = picFrame->get_PictureFormat()->DeletePictureCroppedAreas();

// 儲存結果
presentation->Save(u"PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
```

{{% alert title="NOTE" color="warning" %}} 
[IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) 方法會將裁剪後的影像加入簡報影像集合。若該影像僅在已處理的 [PictureFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/pictureframe/) 中使用，此設定可減少簡報大小；否則，最終簡報中的影像數量會增加。

此方法在裁剪過程中會將 WMF/EMF 中繪圖檔轉換為點陣 PNG 影像。 
{{% /alert %}}

## **壓縮影像**

您可以使用 [IPictureFillFormat::CompressImage()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipicturefillformat/compressimage/) 方法壓縮簡報中的圖片。此方法會根據形狀大小與指定的解析度減少影像大小，並可選擇刪除裁剪區域。  

它的作用類似於 PowerPoint 中 **圖片格式 → 壓縮圖片 → 解析度** 的功能。  

以下 C++ 範例示範如何以目標解析度壓縮簡報中的影像，並可選擇移除裁剪區域：

```c++
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// 以 150 DPI（網頁解析度）為目標解析度壓縮影像，並移除裁剪區域。
bool result = pictureFrame->get_PictureFormat()->CompressImage(true, PicturesCompression::Dpi150);

// 檢查壓縮結果。
if (result)
{
    System::Console::WriteLine(u"Image successfully compressed.");
}
else
{
    System::Console::WriteLine(u"Image compression failed or no changes were necessary.");
}

presentation->Save(u"CompressedImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

或直接使用自訂 DPI 值：

```c++
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// 壓縮影像至 150 DPI（網頁解析度），並移除裁剪區域。
pictureFrame->get_PictureFormat()->CompressImage(true, 150.0f);

presentation->Save(u"CompressedImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="NOTE" color="warning" %}} 
此方法會根據形狀大小與提供的 DPI 將影像轉換為較低解析度。亦可刪除裁剪區域以最佳化檔案大小。若影像為 WMF/EMF 中繪圖檔或 SVG，則不會執行壓縮。JPEG 的品質會依解析度略有下降，行為與 PowerPoint 處理高解析度 JPEG 相同。 
{{% /alert %}}

## **鎖定長寬比例**

若您希望包含影像的形狀在變更影像尺寸後仍保留長寬比例，可使用 [set_AspectRatioLocked()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.ipictureframelock/set_aspectratiolocked/) 方法設定 *Lock Aspect Ratio*。  

此 C++ 程式碼示範如何鎖定形狀的長寬比例：

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ILayoutSlide> layout = pres->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
System::SharedPtr<ISlide> emptySlide = pres->get_Slides()->AddEmptySlide(layout);

System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
System::SharedPtr<IPPImage> presImage = pres->get_Images()->AddImage(image);

System::SharedPtr<IPictureFrame> pictureFrame = emptySlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 150.0f, static_cast<float>(presImage->get_Width()), static_cast<float>(presImage->get_Height()), presImage);

// 設定形狀在調整大小時保持長寬比例
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);
```

{{% alert title="NOTE" color="warning" %}} 
此 *Lock Aspect Ratio* 設定僅保留形狀的長寬比例，並不會影響其中的影像。 
{{% /alert %}}

## **使用 StretchOff 屬性**

使用 [IPictureFillFormat](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_picture_fill_format) 介面與 [PictureFillFormat](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.picture_fill_format) 類別中的 [StretchOffsetLeft](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.picture_fill_format#ad730bf8db88f47979d84643eb30d1471)、[StretchOffsetTop](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.picture_fill_format#aa512e1f022e9c7ff83e9c51ba100709a)、[StretchOffsetRight](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.picture_fill_format#ac3597692f9b7e3327d0f4a4169a53127) 以及 [StretchOffsetBottom](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.picture_fill_format#a72acf6945f372a5729c0b760f4a5dc39) 屬性，您可以指定填充矩形。  

當指定影像伸展時，來源矩形會縮放以適應指定的填充矩形。填充矩形的每一邊皆以相對於形狀邊界框相應邊的百分比偏移定義。正百分比表示內縮，負百分比表示外伸。  

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation) 類別的實例。  
2. 透過索引取得投影片的參考。  
3. 新增矩形 `AutoShape`。  
4. 建立影像。  
5. 設定形狀的填充類型。  
6. 設定形狀的圖片填充模式。  
7. 新增設定好的影像以填充形狀。  
8. 指定影像相對於形狀邊界框相應邊的偏移。  
9. 將已修改的簡報寫入為 PPTX 檔案。  

此 C++ 程式碼示範使用 StretchOff 屬性的流程：

``` cpp
auto pres = System::MakeObject<Presentation>();
auto ppImage = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
auto slide = pres->get_Slide(0);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 400.0f, 400.0f, ppImage);

// 設定影像在形狀內部從每一側伸展
auto pictureFormat = pictureFrame->get_PictureFormat();
pictureFormat->set_PictureFillMode(PictureFillMode::Stretch);
pictureFormat->set_StretchOffsetLeft(24.0f);
pictureFormat->set_StretchOffsetRight(24.0f);
pictureFormat->set_StretchOffsetTop(24.0f);
pictureFormat->set_StretchOffsetBottom(24.0f);

pres->Save(u"imageStretch.pptx", SaveFormat::Pptx);
```

## **常見問題**

**如何得知 PictureFrame 支援哪些影像格式？**  
Aspose.Slides 支援點陣圖（PNG、JPEG、BMP、GIF 等）與向量圖（例如 SVG），透過指派給 [PictureFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/pictureframe/) 的影像物件實現。支援的格式列表通常與投影片與影像轉換引擎的能力重疊。

**大量加入大尺寸影像會如何影響 PPTX 大小與效能？**  
嵌入大尺寸影像會增加檔案大小與記憶體使用量；以連結方式加入影像可減少簡報檔案大小，但需確保外部檔案仍可存取。Aspose.Slides 提供以連結方式加入影像的功能，以降低檔案大小。

**如何防止影像物件被意外移動或調整大小？**  
對 [PictureFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/pictureframe/) 使用 [shape locks](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/pictureframe/get_pictureframelock/)（例如停用移動或調整大小）。相關鎖定機制在另一篇 [保護文章](/slides/zh-hant/cpp/applying-protection-to-presentation/) 中說明，支援各種形狀類型，包括 [PictureFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/pictureframe/)。

**匯出簡報為 PDF/影像時，SVG 向量保真度是否得以保留？**  
Aspose.Slides 允許從 [PictureFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/pictureframe/) 提取原始 SVG 向量。若 [匯出為 PDF](/slides/zh-hant/cpp/convert-powerpoint-to-pdf/) 或 [點陣格式](/slides/zh-hant/cpp/convert-powerpoint-to-png/)，結果可能會依匯出設定被點陣化；但提取行為證實原始 SVG 仍以向量形式存儲。