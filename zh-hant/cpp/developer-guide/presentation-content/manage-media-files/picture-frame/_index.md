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
- 新增影像
- 建立影像
- 擷取影像
- 點陣影像
- 向量影像
- 裁切影像
- 裁切區域
- StretchOff 屬性
- 圖片框格式設定
- 圖片框屬性
- 相對比例
- 影像效果
- 長寬比
- 影像透明度
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 將圖片框加入 PowerPoint 與 OpenDocument 簡報。簡化工作流程並增強投影片設計。"
---
## **簡介**

圖片框是一種包含影像的形狀——它就像是一幅放在框中的圖片。  

您可以透過圖片框將影像加入投影片，這樣就能透過格式化圖片框來格式化影像。

{{% alert  title="提示" color="primary" %}} 

Aspose 提供免費的轉換工具—[JPEG to PowerPoint](https://products.aspose.app/slides/zh-hant/import/jpg-to-ppt) 與 [PNG to PowerPoint](https://products.aspose.app/slides/zh-hant/import/png-to-ppt)—讓使用者能快速從影像建立簡報。 

{{% /alert %}} 

## **建立圖片框**

1. 建立一個 [Presentation class](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation) 的實例。  
2. 依索引取得投影片的參考。  
3. 透過將影像加入與簡報物件關聯的 [IImagescollection](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_image_collection) 來建立 [IPPImage](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_p_p_image) 物件，以填充形狀。  
4. 指定影像的寬度與高度。  
5. 透過參考投影片的形狀物件所提供的 `AddPictureFrame` 方法，依影像的寬度與高度建立 [PictureFrame](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.picture_frame)。  
6. 將圖片框（包含圖片）加入投影片。  
7. 將修改後的簡報寫入為 PPTX 檔案。

以下 C++ 程式碼示範如何建立圖片框：

```c++
// 文件目錄的路徑。
const String outPath = u"../out/PictureFrameFormatting_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// 載入所需的簡報
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 取得第一張投影片
SharedPtr<ISlide> slide = pres->get_Slide(0);

// 載入將加入簡報影像集合的影像
// 取得圖片
auto image = Images::FromFile(filePath);

// 將影像加入簡報的影像集合
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// 在投影片上新增圖片框
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// 設定相對比例的寬度與高度
pf->set_RelativeScaleHeight(0.8);
pf->set_RelativeScaleWidth(1.35);
// 對圖片框套用一些格式設定
pf->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pf->get_LineFormat()->set_Width ( 20);
pf->set_Rotation( 45);

//將 PPTX 檔案寫入磁碟
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert color="warning" %}} 

圖片框讓您能快速以影像建立簡報投影片。結合 Aspose.Slides 的儲存選項，您可以操作輸入/輸出以將影像從一種格式轉換為另一種格式。您可能想參考以下頁面：轉換 [image to JPG](https://products.aspose.com/slides/zh-hant/cpp/conversion/image-to-jpg/)；轉換 [JPG to image](https://products.aspose.com/slides/zh-hant/cpp/conversion/jpg-to-image/)；轉換 [JPG to PNG](https://products.aspose.com/slides/zh-hant/cpp/conversion/jpg-to-png/)、轉換 [PNG to JPG](https://products.aspose.com/slides/zh-hant/cpp/conversion/png-to-jpg/)；轉換 [PNG to SVG](https://products.aspose.com/slides/zh-hant/cpp/conversion/png-to-svg/)、轉換 [SVG to PNG](https://products.aspose.com/slides/zh-hant/cpp/conversion/svg-to-png/)。 

{{% /alert %}}

## **建立具有相對比例的圖片框**

透過調整影像的相對縮放，您可以建立更複雜的圖片框。 

1. 建立一個 [Presentation class](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation) 的實例。  
2. 依索引取得投影片的參考。  
3. 將影像加入簡報的影像集合。  
4. 透過將影像加入與簡報物件關聯的 [IImagescollection](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_image_collection) 來建立 [IPPImage](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_p_p_image) 物件，以填充形狀。  
5. 在圖片框中指定影像的相對寬度與高度。  
6. 將修改後的簡報寫入為 PPTX 檔案。

以下 C++ 程式碼示範如何建立具有相對比例的圖片框：

```c++
// 文件目錄的路徑。
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// 載入所需的簡報
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 取得第一張投影片
SharedPtr<ISlide> slide = pres->get_Slide(0);

// 載入將加入簡報影像集合的影像
// 取得圖片
auto image = Images::FromFile(filePath);

// 將影像加入簡報的影像集合
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// 在投影片上新增圖片框
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// 設定相對比例的寬度與高度
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

// 將 PPTX 檔案寫入磁碟
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **從圖片框中提取點陣圖影像**

您可以從 [PictureFrame](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.picture_frame) 物件提取點陣圖影像，並以 PNG、JPG 等格式儲存。以下程式碼範例示範如何從「sample.pptx」文件中提取影像並以 PNG 格式儲存。

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

## **從圖片框中提取 SVG 影像**

當簡報在 [PictureFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/pictureframe/) 形狀內放置 SVG 圖形時，Aspose.Slides for C++ 可讓您以完整保真度取得原始向量影像。透過遍歷投影片的形狀集合，您可以辨識每個 [PictureFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/pictureframe/)，檢查底層的 [IPPImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ippimage/) 是否含有 SVG 內容，然後以原生 SVG 格式將該影像儲存至磁碟或串流。

以下程式碼範例示範如何從圖片框中提取 SVG 影像：

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

Aspose.Slides 允許您取得套用於影像的透明度效果。以下 C++ 程式碼示範此操作：

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

## **圖片框格式設定**

Aspose.Slides 提供多種格式設定選項，可套用於圖片框。使用這些選項，您可以調整圖片框以符合特定需求。

1. 建立一個 [Presentation class](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation) 的實例。  
2. 依索引取得投影片的參考。  
3. 透過將影像加入與簡報物件關聯的 [IImagescollection](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_image_collection) 來建立 [IPPImage](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_p_p_image) 物件，以填充形狀。  
4. 指定影像的寬度與高度。  
5. 透過 [IShapes](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_shape_collection) 物件所提供的 [AddPictureFrame](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) 方法，依影像的寬度與高度建立 `PictureFrame`。  
6. 將圖片框（包含圖片）加入投影片。  
7. 設定圖片框的線條顏色。  
8. 設定圖片框的線條寬度。  
9. 透過正值或負值旋轉圖片框  
   * 正值會順時針旋轉影像。  
   * 負值會逆時針旋轉影像。  
10. 再次將圖片框（包含圖片）加入投影片。  
11. 將修改後的簡報寫入為 PPTX 檔案。

以下 C++ 程式碼示範圖片框的格式設定流程：

```c++
// 文件目錄的路徑。
const String outPath = u"../out/AddRelativeScaleHeightPictureFrame_out.pptx";
const String filePath = u"../templates/Tulips.jpg";

// 載入所需的簡報
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 取得第一張投影片
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// 載入要加入簡報影像集合的影像
// 取得圖片
auto image = Images::FromFile(filePath);

// 將影像加入簡報的影像集合
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

// 在投影片上新增圖片框
SharedPtr<IPictureFrame> pf = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, imgx);

// 設定相對比例的寬度與高度
pf->set_RelativeScaleHeight (0.8);
pf->set_RelativeScaleWidth(1.35);

//Writes the PPTX file to disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert title="提示" color="primary" %}}

Aspose 最近開發了免費的 [Collage Maker](https://products.aspose.app/slides/zh-hant/collage)。若您需要 [合併 JPG/JPEG](https://products.aspose.app/slides/zh-hant/collage/jpg) 或 PNG 影像、[從相片建立格子](https://products.aspose.app/slides/zh-hant/collage/photo-grid)，可使用此服務。 

{{% /alert %}}

## **將影像設為連結**

為了避免簡報檔案過大，您可以透過連結方式加入影像（或影片），而非將檔案直接嵌入簡報。以下 C++ 程式碼示範如何將影像與影片加入佔位符：

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

## **裁切影像**

以下 C++ 程式碼示範如何裁切投影片上已有的影像：

``` CPP
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;
    
auto presentation = System::MakeObject<Presentation>();
// 建立新影像物件
auto newImage = presentation->get_Images()->AddImage(Images::FromFile(imagePath));

// 在投影片上新增 PictureFrame
auto picFrame = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 100.0f, 100.0f, 420.0f, 250.0f, newImage);

// 裁剪影像（百分比值）
picFrame->get_PictureFormat()->set_CropLeft(23.6f);
picFrame->get_PictureFormat()->set_CropRight(21.5f);
picFrame->get_PictureFormat()->set_CropTop(3.0f);
picFrame->get_PictureFormat()->set_CropBottom(31.0f);

// 儲存結果
presentation->Save(outPptxFile, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **刪除圖片框的裁切區域**

若要刪除框內影像的裁切區域，可使用 [IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) 方法。若不需要裁切，該方法會回傳原始影像。

以下 C++ 程式碼示範此操作：

```c++
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"PictureFrameCrop.pptx");
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Gets the PictureFrame from the first slide
System::SharedPtr<IPictureFrame> picFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// Deletes cropped areas of the PictureFrame image and returns the cropped image
System::SharedPtr<IPPImage> croppedImage = picFrame->get_PictureFormat()->DeletePictureCroppedAreas();

// Saves the result
presentation->Save(u"PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
```

{{% alert title="注意" color="warning" %}} 

[IPictureFillFormat::DeletePictureCroppedAreas()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) 會將裁切後的影像加入簡報的影像集合。若該影像僅在已處理的 [PictureFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/pictureframe/) 中使用，此設定可減少簡報大小；否則，最終簡報中的影像數量會增加。  

此方法在裁切過程中會將 WMF/EMF 中繪圖檔轉換為點陣 PNG 影像。 

{{% /alert %}}

## **壓縮影像**

您可以使用 [IPictureFillFormat::CompressImage()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipicturefillformat/compressimage/) 方法壓縮簡報中的圖片。此方法會根據形狀大小與指定的解析度縮小影像大小，並可選擇刪除裁切區域。

它的運作方式類似 PowerPoint 的 **圖片格式 -> 壓縮圖片 -> 解析度** 功能。

以下 C++ 範例示範如何透過指定目標解析度並選擇性刪除裁切區域來壓縮簡報中的影像：

```c++
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(0);
auto pictureFrame = System::AsCast<IPictureFrame>(slide->get_Shape(0));

// 使用目標解析度 150 DPI（Web 解析度）壓縮影像並移除裁切區域。
bool result = pictureFrame->get_PictureFormat()->CompressImage(true, PicturesCompression::Dpi150);

// 檢查壓縮的結果。
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

// 壓縮影像至 150 DPI（網頁解析度），並移除裁切區域。
pictureFrame->get_PictureFormat()->CompressImage(true, 150.0f);

presentation->Save(u"CompressedImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="注意" color="warning" %}}

此方法會根據形狀大小與提供的 DPI 降低影像解析度。裁切區域亦可被刪除以最佳化檔案大小。  
若影像為中繪圖檔 (WMF/EMF) 或 SVG，則不會套用壓縮。JPEG 的品質會依解析度略為降低，與 PowerPoint 處理高解析度 JPEG 的方式相同。 

{{% /alert %}}

## **鎖定長寬比**

若您希望包含影像的形狀在變更影像尺寸後仍保留長寬比，可使用 [set_AspectRatioLocked()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) 方法設定 *Lock Aspect Ratio*。 

以下 C++ 程式碼示範如何鎖定形狀的長寬比：

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ILayoutSlide> layout = pres->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
System::SharedPtr<ISlide> emptySlide = pres->get_Slides()->AddEmptySlide(layout);

System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
System::SharedPtr<IPPImage> presImage = pres->get_Images()->AddImage(image);

System::SharedPtr<IPictureFrame> pictureFrame = emptySlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 150.0f, static_cast<float>(presImage->get_Width()), static_cast<float>(presImage->get_Height()), presImage);

// 設定形狀在調整大小時保留長寬比
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);
```

{{% alert title="注意" color="warning" %}} 

此 *Lock Aspect Ratio* 設定僅保留形狀本身的長寬比，並不會影響其內含的影像。 

{{% /alert %}}

## **使用 StretchOff 屬性**

使用來自 [IPictureFillFormat](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_picture_fill_format) 介面與 [PictureFillFormat](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.picture_fill_format) 類別的 [StretchOffsetLeft](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.picture_fill_format#ad730bf8db88f47979d84643eb30d1471)、[StretchOffsetTop](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.picture_fill_format#aa512e1f022e9c7ff83e9c51ba100709a)、[StretchOffsetRight](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.picture_fill_format#ac3597692f9b7e3327d0f4a4169a53127) 與 [StretchOffsetBottom](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.picture_fill_format#a72acf6945f372a5729c0b760f4a5dc39) 屬性，您可以指定填充矩形。  

當指定影像伸展時，來源矩形會依填充矩形的百分比偏移進行縮放。填充矩形的每一邊皆以相對於形狀邊界框相應邊緣的百分比偏移定義。正百分比表示內縮，負百分比表示外伸。

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation) 類別的實例。  
2. 依索引取得投影片的參考。  
3. 新增一個矩形 `AutoShape`。  
4. 建立影像。  
5. 設定形狀的填充類型。  
6. 設定形狀的圖片填充模式。  
7. 新增用於填充形狀的影像集合。  
8. 指定影像相對於形狀邊界框相應邊緣的偏移。  
9. 將修改後的簡報寫入為 PPTX 檔案。

以下 C++ 程式碼示範使用 StretchOff 屬性的流程：

``` cpp
auto pres = System::MakeObject<Presentation>();
auto ppImage = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
auto slide = pres->get_Slide(0);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 400.0f, 400.0f, ppImage);

// Sets the image stretched from each side in the shape body
auto pictureFormat = pictureFrame->get_PictureFormat();
pictureFormat->set_PictureFillMode(PictureFillMode::Stretch);
pictureFormat->set_StretchOffsetLeft(24.0f);
pictureFormat->set_StretchOffsetRight(24.0f);
pictureFormat->set_StretchOffsetTop(24.0f);
pictureFormat->set_StretchOffsetBottom(24.0f);

pres->Save(u"imageStretch.pptx", SaveFormat::Pptx);
```

## **常見問題**

**如何查詢 PictureFrame 支援的影像格式？**  

Aspose.Slides 透過指派給 [PictureFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/pictureframe/) 的影像物件，支援點陣圖 (PNG、JPEG、BMP、GIF 等) 與向量圖 (例如 SVG)。支援的格式清單通常與投影片與影像轉換引擎的功能相互重疊。

**大量加入大型影像會如何影響 PPTX 檔案大小與效能？**  

嵌入大型影像會增加檔案大小與記憶體使用量；使用連結方式加入影像可減少簡報檔案大小，但需要確保外部檔案仍可存取。Aspose.Slides 提供透過連結加入影像的功能，以降低檔案大小。

**如何防止影像物件意外移動或調整大小？**  

使用 [shape locks](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/pictureframe/get_pictureframelock/) 於 [PictureFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/pictureframe/)（例如停用移動或調整大小）。鎖定機制在形狀的[保護文章](/slides/zh-hant/cpp/applying-protection-to-presentation/) 中有說明，並支援各種形狀類型，包括 [PictureFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/pictureframe/)。

**在將簡報匯出為 PDF/影像時，SVG 向量的保真度是否會被保留？**  

Aspose.Slides 允許從 [PictureFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/pictureframe/) 中提取原始 SVG 向量。若[匯出為 PDF](/slides/zh-hant/cpp/convert-powerpoint-to-pdf/)或[點陣格式](/slides/zh-hant/cpp/convert-powerpoint-to-png/)，結果可能會根據匯出設定被點陣化；提取行為證明原始 SVG 仍以向量形式儲存。