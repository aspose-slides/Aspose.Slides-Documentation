---
title: 使用 C++ 管理簡報中的影像變換效果
linktitle: 影像變換效果
type: docs
weight: 11
url: /zh-hant/cpp/image-transform-effects/
keywords:
- 影像變換
- 圖片效果
- 亮度
- 對比度
- 灰階
- 雙調
- 色調
- HSL
- 顏色替換
- 模糊
- 透明度
- Alpha 效果
- 效果鏈
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 套用、鏈接、檢查、移除並驗證圖片框的影像變換效果。"
---
## **概述**

Aspose.Slides 以有序的影像變換作業集合來表示圖片調整。對於圖片框，先取得框的 [ISlidesPicture](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidespicture/)，再存取 [ISlidesPicture::get_ImageTransform](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidespicture/get_imagetransform/)。回傳的 [IImageTransformOperationCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.effects/iimagetransformoperationcollection/) 允許您在不重新寫入原始影像位元組的情況下，追加、列舉、檢查、移除與清除效果。

本文示範了亮度與對比度、顏色轉換、模糊、透明度、有序效果鏈、有效值、移除以及 PPTX 循環驗證的完整工作流程。

## **了解效果擁有權與影像重複使用**

影像資源與顯示該影像的圖片是不同的物件：

- [IPPImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ippimage/) 儲存或參考簡報所擁有的來源影像資料。
- [ISlidesPicture](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidespicture/) 屬於圖片填充，指向影像資源，同時保存影像變換集合。
- [IPictureFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipictureframe/) 是擁有相關圖片填充、幾何形狀、裁切設定及其他框級格式的投影片形狀。

因此，影像變換作業不會修改 [IPPImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ippimage/) 中的位元組。當同一個 `IPPImage` 多次傳遞給 [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishapecollection/addpictureframe/) 時，每個新圖片框都會取得自己的 `ISlidesPicture` 與自己的變換集合。對其中一個框套用灰階不會使其他框變成灰階，即使它們都重複使用相同的內嵌影像資源。

相同的 `ISlidesPicture::get_ImageTransform` 模型也用於其他圖片填充，例如形狀或投影片背景。以下範例聚焦於圖片框。

## **使用有效的參數範圍與單位**

示範的方法使用以下語意範圍與單位。即使某些程式庫版本不立即拒絕所有超出範圍的值，也請保持在這些範圍內；目標簡報格式可能會在儲存或 PowerPoint 開啟檔案時正規化、忽略或拒絕無效資料。

| Operation | Parameters | Valid range and unit |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` 到 `100`，百分比；`0` 表示保持元件不變。 |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | None | 無數值參數。Alpha 保持不變。 |
| [AddDuotoneEffect](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | 兩個顏色分別用於暗像素與亮像素。`System::Drawing::Color` 的 RGB 與 Alpha 通道使用 `0` 到 `255`。 |
| [AddTintEffect](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Hue 為包含 `0` 不含 `360` 的度數；amount 為 `-100` 到 `100`，百分比。 |
| [AddHSLEffect](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Hue 為包含 `0` 不含 `360` 的度數；saturation 與 luminance 為 `-100` 到 `100`，百分比。 |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | 替換顏色的通道值為 `0` 到 `255`。現有的 Alpha 值保持不變。 |
| [AddBlurEffect](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | radius 為非負值，以點為單位；`grow` 控制模糊內容是否可延伸至原始邊界之外。 |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | 非負百分比。使用 `0` 到 `100` 進行普通不透明度縮放：`0` 為完全透明，`100` 保持原有 Alpha。 |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` 到 `100`，百分比不透明度。 |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` 到 `100`，百分比 Alpha 閾值。低於此值的像素變為透明；等於或高於此值的像素變為不透明。 |

對於固定 Alpha 調變，透明度與不透明度是互補的。例如，35% 透明度對應的 Alpha 調變量為 65%。

## **套用亮度與對比度**

[IImageTransformOperationCollection::AddBrightnessContrastEffect](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) 會回傳一個 [IBrightnessContrast](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.effects/ibrightnesscontrast/) 作業。其標量設定在建立作業時即提供。`IBrightnessContrast::GetEffective` 方法會回傳計算後的唯讀值，可供檢查或記錄。

以下範例將亮度提升 15%，對比度提升 20%，然後在不修改內嵌影像的情況下產生預覽：

```cpp
#include <DOM/Effects/IBrightnessContrast.h>
#include <DOM/Effects/IBrightnessContrastEffectiveData.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/console.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 50.0f, 400.0f, 260.0f, image);

auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
auto brightnessContrast = imageTransform->AddBrightnessContrastEffect(15.0f, 20.0f);

auto effectiveValues = brightnessContrast->GetEffective();
Console::WriteLine(u"Brightness: {0}%", effectiveValues->get_Brightness());
Console::WriteLine(u"Contrast: {0}%", effectiveValues->get_Contrast());

auto preview = slide->GetImage();
preview->Save(u"brightness-contrast-preview.png", ImageFormat::Png);

presentation->Dispose();
```

[BrightnessContrast](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.effects/brightnesscontrast/) 是 Office 2010 的圖片效果擴充，較不具可移植性，且不如標準 DrawingML 亮度效果通用。當亮度與對比度必須在 PPTX 循環後仍可編輯時，請使用 [IImageTransformOperationCollection::AddLuminanceEffect](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) 並在重新開啟檔案後驗證結果。格式限制章節會更詳細說明此差異。

## **套用顏色轉換**

顏色效果可以獨立套用於重複使用同一影像資源的不同圖片框。以下範例建立五個框，分別套用灰階、雙調、色調、HSL 調整與顏色替換。

[IDuotone](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.effects/iduotone/) 包含兩個可獨立編輯的顏色參數：`get_Color1` 用於暗像素，`get_Color2` 用於亮像素。這是一個設定比單一標量更複雜的效果範例。

```cpp
#include <DOM/Effects/IColorReplace.h>
#include <DOM/Effects/IDuotone.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IColorFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto grayFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 180.0f, 120.0f, image);
grayFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddGrayScaleEffect();

auto duotoneFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 220.0f, 20.0f, 180.0f, 120.0f, image);
auto duotone = duotoneFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddDuotoneEffect();
duotone->get_Color1()->set_Color(Color::get_Navy());
duotone->get_Color2()->set_Color(Color::get_Gold());

auto tintFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 420.0f, 20.0f, 180.0f, 120.0f, image);
tintFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddTintEffect(210.0f, 35.0f);

auto hslFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 120.0f, 170.0f, 180.0f, 120.0f, image);
hslFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddHSLEffect(30.0f, 20.0f, -10.0f);

auto replacementFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 320.0f, 170.0f, 180.0f, 120.0f, image);
auto colorReplacement = replacementFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddColorReplaceEffect();
colorReplacement->get_Color()->set_Color(Color::get_CornflowerBlue());

presentation->Save(u"color-transformations.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

[AddColorReplaceEffect](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) 會將每個像素的顏色全部替換為固定顏色，同時保留 Alpha。它不同於 [AddColorChangeEffect](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/)，後者會將一個來源顏色映射到另一個顏色，並同時公開來源與目標顏色格式。

## **加入模糊、透明度與 Alpha 效果**

[AddBlurEffect](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) 會影響所有顏色通道，包括 Alpha。當模糊邊緣可能超出原始圖片範圍時，將 `grow` 設為 `true`。

若需均勻透明度，請使用 [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/)。它會乘以每個現有 Alpha 值，使部分透明像素保持比例差異。[AddAlphaReplaceEffect](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) 則會將所有像素指派同一 Alpha 值。[AddAlphaBiLevelEffect](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) 會根據閾值將 Alpha 轉為兩個層級。

```cpp
#include <DOM/Effects/IAlphaBiLevel.h>
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto blurredFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 200.0f, 140.0f, image);
auto blur = blurredFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddBlurEffect(4.5, true);
blur->set_Radius(5.0);

auto transparentFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 240.0f, 20.0f, 200.0f, 140.0f, image);
auto alphaModulate = transparentFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddAlphaModulateFixedEffect(65.0f);
alphaModulate->set_Amount(60.0f);

auto uniformAlphaFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 180.0f, 200.0f, 140.0f, image);
uniformAlphaFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddAlphaReplaceEffect(55.0f);

auto binaryAlphaFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 240.0f, 180.0f, 200.0f, 140.0f, image);
auto binaryAlphaTransform = binaryAlphaFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
auto alphaBiLevel = binaryAlphaTransform->AddAlphaBiLevelEffect(50.0f);
alphaBiLevel->set_Threshold(45.0f);
binaryAlphaTransform->AddAlphaInverseEffect();

presentation->Save(u"blur-and-alpha-effects.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

其他無參數的 Alpha 作業還包括 [AddAlphaCeilingEffect](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/)，會使所有非零 Alpha 變為完全不透明；[AddAlphaFloorEffect](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/)，會使低於 100% 的 Alpha 完全透明；以及 [AddAlphaInverseEffect](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/)，會將 Alpha 變為 `100% - alpha`。

## **建立有序的效果鏈**

每個 `Add...Effect` 方法都會將新作業附加到集合的末端。渲染器將集合視為有序管線：作業 0 的輸出成為作業 1 的輸入，如此類推。因此，相同的作業若順序不同，可能產生不同的影像。

例如，先執行灰階再執行色調會先移除色彩資訊，再為亮度結果重新著色。先執行色調再執行灰階則會再次去除色調。類似地，Alpha 替換可以覆蓋先前作業計算出的 Alpha，而 Alpha 調變則會保留其相對差異。

以下範例建立四個作業的鏈，存成 PPTX，重新開啟簡報，檢查作業類型與順序，並渲染重新開啟的結果：

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IGrayScale.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/Effects/ITint.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/io/file.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 50.0f, 400.0f, 260.0f, image);

auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
imageTransform->AddGrayScaleEffect();
imageTransform->AddTintEffect(220.0f, 25.0f);
imageTransform->AddBlurEffect(2.5, false);
imageTransform->AddAlphaModulateFixedEffect(80.0f);

presentation->Save(u"image-transform-chain.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopenedPresentation = MakeObject<Presentation>(u"image-transform-chain.pptx");
auto reopenedShape = reopenedPresentation->get_Slide(0)->get_Shape(0);

if (ObjectExt::Is<IPictureFrame>(reopenedShape))
{
    auto reopenedFrame = ExplicitCast<IPictureFrame>(reopenedShape);
    auto reopenedTransform = reopenedFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
    auto orderIsPreserved = reopenedTransform->get_Count() == 4 && 
            ObjectExt::Is<IGrayScale>(reopenedTransform->idx_get(0)) && 
            ObjectExt::Is<ITint>(reopenedTransform->idx_get(1)) && 
            ObjectExt::Is<IBlur>(reopenedTransform->idx_get(2)) && 
            ObjectExt::Is<IAlphaModulateFixed>(reopenedTransform->idx_get(3));
    Console::WriteLine(orderIsPreserved ? u"The effect chain was preserved." : u"The effect chain changed during the round trip.");

    auto renderedSlide = reopenedPresentation->get_Slide(0)->GetImage();
    renderedSlide->Save(u"reopened-effect-chain.png", ImageFormat::Png);
}
else
{
    Console::WriteLine(u"The reopened shape is not a picture frame.");
}

reopenedPresentation->Dispose();
```

此集合不會施加相容性矩陣限制顏色、Alpha 與模糊作業必須分別在不同鏈中。它們可以組合使用，但組合未必有意義。固定顏色替換會移除先前顏色效果產生的 RGB 變化；灰階於雙調之後會移除兩個選定顏色；Alpha ceiling、floor、replace 或 bi‑level 作業則可能丟棄先前產生的 Alpha 細節。請依據期望的像素處理順序建立鏈，而非將其視為無序的格式旗標。

## **檢查可編輯與有效值**

可編輯的作業即存於 `ISlidesPicture::get_ImageTransform` 中的物件。依效果不同，可能直接公開可寫成員。例如，[IBlur](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.effects/iblur/) 公开 `set_Radius` 與 `set_Grow`，[IAlphaModulateFixed](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.effects/ialphamodulatefixed/) 公开 `set_Amount`，[IAlphaBiLevel](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.effects/ialphabilevel/) 公开 `set_Threshold`。像 [IDuotone](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.effects/iduotone/) 這類顏色效果則會公開可變的 [IColorFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icolorformat/) 物件。

某些作業介面（包括 [IBrightnessContrast](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.effects/ibrightnesscontrast/)、[IHSL](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.effects/ihsl/)、[ITint](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.effects/itint/)、[IAlphaReplace](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.effects/ialphareplace/)）不會將建立時的標量公開為可寫屬性。若需變更這些設定，必須先移除該作業，再在所需位置加入新的取代作業。

`GetEffective()` 回傳的有效資料是計算後的唯讀值。它對解析主題相關顏色與取得渲染器使用的正規化值很有幫助，但並非另一個可編輯的表面。以下範例列舉鏈並檢查多個常用作業的有效值：

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IAlphaModulateFixedEffectiveData.h>
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IBlurEffectiveData.h>
#include <DOM/Effects/IBrightnessContrast.h>
#include <DOM/Effects/IBrightnessContrastEffectiveData.h>
#include <DOM/Effects/IDuotone.h>
#include <DOM/Effects/IDuotoneEffectiveData.h>
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

auto presentation = MakeObject<Presentation>(u"image-transform-chain.pptx");
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

    for (auto&& operation : imageTransform)
    {
        if (ObjectExt::Is<IBrightnessContrast>(operation))
        {
            auto brightnessContrast = ExplicitCast<IBrightnessContrast>(operation);
            auto data = brightnessContrast->GetEffective();
            Console::WriteLine(u"Brightness: {0}; contrast: {1}", data->get_Brightness(), data->get_Contrast());
        }
        else if (ObjectExt::Is<ILuminance>(operation))
        {
            auto luminance = ExplicitCast<ILuminance>(operation);
            auto data = luminance->GetEffective();
            Console::WriteLine(u"Brightness: {0}; contrast: {1}", data->get_Brightness(), data->get_Contrast());
        }
        else if (ObjectExt::Is<IDuotone>(operation))
        {
            auto duotone = ExplicitCast<IDuotone>(operation);
            auto data = duotone->GetEffective();
            Console::WriteLine(u"Dark color: {0}; light color: {1}", data->get_Color1(), data->get_Color2());
        }
        else if (ObjectExt::Is<IBlur>(operation))
        {
            auto blur = ExplicitCast<IBlur>(operation);
            auto data = blur->GetEffective();
            Console::WriteLine(u"Blur radius: {0} pt", data->get_Radius());
        }
        else if (ObjectExt::Is<IAlphaModulateFixed>(operation))
        {
            auto alphaModulate = ExplicitCast<IAlphaModulateFixed>(operation);
            auto data = alphaModulate->GetEffective();
            Console::WriteLine(u"Alpha amount: {0}%", data->get_Amount());
        }
    }
}

presentation->Dispose();
```

無參數的效果（如灰階、Alpha ceiling、Alpha inverse）仍會有有效資料物件，只是沒有可列印的標量設定。它們在集合中的存在與位置即為重要資訊。

## **移除或清除影像變換**

使用 [IImageTransformOperationCollection::RemoveAt](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.effects/iimagetransformoperationcollection/removeat/) 依索引移除單一作業。因為移除後索引會改變，請先搜尋目標作業，列舉完畢後再移除。使用 `Clear()` 可移除整個鏈。

```cpp
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"image-transform-chain.pptx");
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
    auto blurIndex = -1;

    for (auto index = 0; index < imageTransform->get_Count(); ++index)
    {
        if (ObjectExt::Is<IBlur>(imageTransform->idx_get(index)))
        {
            blurIndex = index;
            break;
        }
    }

    if (blurIndex >= 0)
    {
        imageTransform->RemoveAt(blurIndex);
        Console::WriteLine(u"The blur operation was removed.");
    }

    imageTransform->Clear();
    Console::WriteLine(u"Remaining operations: {0}", imageTransform->get_Count());
    presentation->Save(u"image-transforms-cleared.pptx", SaveFormat::Pptx);
}

presentation->Dispose();
```

移除或清除變換僅會改變圖片格式，不會刪除、重新壓縮或以其他方式改變重複使用的 [IPPImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ippimage/) 資源。

## **考慮簡報格式與匯出目標**

影像變換起源於 DrawingML，因此 PPTX 是效果鏈的首選可編輯格式。即使使用 PPTX，也不是所有作業都有相同的可移植性：

- 標準 DrawingML 作業（如亮度、灰階、雙調、色調、HSL、模糊及常見 Alpha 作業）最有可能在 PPTX 循環後仍然存留。若需保留，務必重新開啟產生的檔案並檢查集合。
- [BrightnessContrast](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.effects/brightnesscontrast/) 是 Office 2010 的擴充，而非標準 DrawingML 亮度作業。它可用於記憶體中渲染，但在儲存與重新開啟 PPTX 後不保證仍為可編輯的 [IBrightnessContrast](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.effects/ibrightnesscontrast/)。請使用 [AddLuminanceEffect](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) 以獲得持久的亮度與對比度調整。
- 二進位 PPT 格式早於完整的 DrawingML 效果模型。儲存為 PPT 可能會省略不支援的作業、將鏈縮減為支援的子集，或近似呈現外觀。不要將 PPT 用作驗證複雜可編輯鏈的格式。
- 輸出為 PNG、JPEG、TIFF、PDF、SVG、HTML 或其他視覺格式時，會將支援的鏈套用於渲染結果。這些輸出不會包含可編輯的 `IImageTransformOperationCollection`；光柵格式會將結果展平成像素，文件或向量匯出會存儲自己的渲染表示。
- 效果不會使連結的影像變成自包含。對連結圖片的渲染仍然依賴於載入簡報時連結資源的可用性。

不同的簡報檢視器在處理邊緣案例時可能會有不同的呈現，尤其是當多個 Alpha 或顏色量化作業結合使用時。對於關鍵輸出，請以生產環境使用的相同 Aspose.Slides 版本，同時測試可編輯的循環與最終匯出格式。

## **常見問題**

**影像變換效果會修改內嵌影像資料嗎？**

不會。這些作業屬於圖片填充使用的 `ISlidesPicture`，底層的 `IPPImage` 位元組保持不變。

**重複使用相同影像的兩個圖片框會共享它們的效果嗎？**

不會。重複使用 `IPPImage` 可避免影像資料重複，但每個圖片框通常都有各自的 `ISlidesPicture` 與影像變換集合。

**可以同時結合顏色、模糊與 Alpha 效果嗎？**

可以。集合接受它們在同一有序鏈中。請考慮每個作業對前一個作業輸出的影響，因為替換與閾值作業可能會捨棄先前的顏色或 Alpha 細節。

**為什麼有效值是唯讀的？**

有效資料代表渲染時使用的計算值，包括已解析的顏色。請在變換集合中編輯具有可寫成員的作業；若無可寫成員，請移除該作業並以新的建立參數加入取代作業。

**要使用哪種格式才能保留變換鏈？**

使用 PPTX 並在重新開啟後驗證檔案。舊版 PPT 無法完整表示 DrawingML 效果模型，而渲染匯出格式僅保留外觀，不會保留可編輯的變換作業。