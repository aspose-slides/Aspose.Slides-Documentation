---
title: 使用 C++ 管理簡報中的圖像變換效果
linktitle: 圖像變換效果
type: docs
weight: 11
url: /zh-hant/cpp/image-transform-effects/
keywords:
- 圖像變換
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
description: "使用 Aspose.Slides for C++ 為圖片框套用、串接、檢查、移除並驗證圖像變換效果。"
---
## **概觀**

Aspose.Slides 以有序的圖像變換操作集合來表示圖片調整。對於圖片框，先取得框的 [ISlidesPicture](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/)，再存取 [ISlidesPicture::get_ImageTransform](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/get_imagetransform/)。返回的 [IImageTransformOperationCollection](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/) 允許你追加、列舉、檢查、移除以及清除效果，而不必重新寫入原始圖像位元組。

本文示範完整的工作流程，包括亮度與對比度、顏色轉換、模糊、透明度、有序效果鏈、有效值、移除，以及 PPTX 循環驗證。

## **了解效果所有權與圖像重複使用**

圖像資源與顯示該圖像的圖片是不同的物件：

- [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) 儲存或參照屬於簡報的來源圖像資料。
- [ISlidesPicture](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/) 屬於圖片填充，參照圖像資源同時保存圖像變換集合。
- [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/) 是投影片形狀，擁有相關的圖片填充、幾何、裁切設定以及其他框層級的格式設定。

因此，圖像變換操作不會修改 [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) 中的位元組。當同一個 `IPPImage` 被多次傳遞給 [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addpictureframe/) 時，每個新圖片框都會取得自己的 `ISlidesPicture` 與自己的變換集合。對其中一個框套用灰階不會讓其他框變成灰階，即使它們共用相同的嵌入圖像資源。

相同的 `ISlidesPicture::get_ImageTransform` 模型亦用於其他圖片填充，例如形狀或投影片背景。以下範例聚焦於圖片框。

## **使用有效的參數範圍與單位**

示範的方法使用以下語意範圍與單位。請保持數值在此範圍內，即使特定程式庫版本不會立即拒絕所有超出範圍的值；目標簡報格式在儲存或 PowerPoint 開啟檔案時可能會正規化、忽略或拒絕無效資料。

| 操作 | 參數 | 有效範圍和單位 |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` 到 `100`，百分比；`0` 表示元件保持不變。 |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | 無 | 無數值參數。Alpha 保持不變。 |
| [AddDuotoneEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | 兩個顏色分別對應暗像素與亮像素。`System::Drawing::Color` 的 RGB 與 Alpha 通道使用 `0` 到 `255`。 |
| [AddTintEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | 色相 `0`（含）至 `360`（未含）度；`amount` 為 `-100` 到 `100`，百分比。 |
| [AddHSLEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | 色相 `0`（含）至 `360`（未含）度；飽和度與亮度為 `-100` 到 `100`，百分比。 |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | 替換顏色的通道值為 `0` 到 `255`。既有的 Alpha 值保持不變。 |
| [AddBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | 半徑為非負值，以點為單位；`grow` 控制模糊內容是否可延伸超出原始邊界。 |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | 非負百分比。使用 `0` 到 `100` 進行普通不透明度縮放：`0` 為完全透明，`100` 保持原有 Alpha。 |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` 到 `100`，百分比不透明度。 |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` 到 `100`，百分比 Alpha 閾值。低於此值的像素變為透明；等於或高於此值的像素變為不透明。 |

對於固定的 Alpha 調節，透明度與不透明度是互補的。例如，35% 透明度對應的 Alpha 調節量為 65%。

## **套用亮度與對比度**

[IImageTransformOperationCollection::AddBrightnessContrastEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) 會返回一個 [IBrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ibrightnesscontrast/) 操作。其標量設定在建立操作時即提供。`IBrightnessContrast::GetEffective` 方法會返回計算出的唯讀值，可供檢查或記錄。

以下範例將亮度提升 15%，對比度提升 20%，然後在不修改嵌入圖像的情況下產生預覽：

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

[BrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/brightnesscontrast/) 是 Office 2010 的圖片效果延伸，較不具可移植性，與標準 DrawingML 亮度效果不同。若在 PPTX 循環後仍需保持可編輯，請改用 [IImageTransformOperationCollection::AddLuminanceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) 並在重新開啟檔案後驗證結果。格式限制章節將更詳細說明此差異。

## **套用顏色轉換**

顏色效果可獨立套用於重複使用同一圖像資源的不同圖片框。以下範例建立五個框，分別套用灰階、雙調、色調、HSL 調整與顏色替換。

[IDuotone](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iduotone/) 包含兩個可獨立編輯的顏色參數：`get_Color1` 映射暗像素，`get_Color2` 映射亮像素。這是一個設定較為複雜、超過單一標量值的範例。

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

[AddColorReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) 會將每個像素的顏色替換為固定顏色，同時保留 Alpha。它不同於 [AddColorChangeEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/)，後者將一種來源顏色映射為另一種目標顏色，並暴露來源與目標的顏色格式。

### **套用亮度閾值**

亮度閾值可使掃描頁面上淡淡的痕跡更易於與背景區分。[AddGrayScaleEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) 會保留中間的灰階層次。[AddBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbileveleffect/) 則將亮度映射為黑或白，而 [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) 則對不透明度套用閾值。

亮度閾值範圍為 0% 到 100%，包含兩端。低於閾值的像素變為黑色，等於或高於閾值的像素變為白色。提升閾值會使更多的色階變黑，因為更多像素落在閾值以下。

下載 [grayscale-swatches.png](grayscale-swatches.png) 至工作目錄。每個標籤顯示原始灰階值（0–255）。範例將原圖與兩個副本並排放置，並將每個副本的閾值儲存在簡報中。

```cpp
#include <DOM/Effects/IBiLevel.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(720, 150, SlideSizeScaleType::DoNotScale);
auto shapes = presentation->get_Slide(0)->get_Shapes();

auto imageData = File::ReadAllBytes(u"grayscale-swatches.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto addFrame = [&](float x, const String& caption)
{
    auto label = shapes->AddAutoShape(ShapeType::Rectangle, x, 12, 216, 36);
    label->get_TextFrame()->set_Text(caption);
    return shapes->AddPictureFrame(ShapeType::Rectangle, x, 60, 216, 72, image);
};

addFrame(12, u"Original");

auto lowThreshold = addFrame(252, u"Threshold 20%");
lowThreshold->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddBiLevelEffect(20.0f);

auto highThreshold = addFrame(492, u"Threshold 60%");
highThreshold->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddBiLevelEffect(60.0f);

presentation->Save(u"luminance-threshold.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

在 PowerPoint 中開啟輸出簡報以比較三個框。標示為 96 的樣本在 0–255 中約為 38% 亮度。它在 20% 閾值時變白，在 60% 閾值時變黑。

![Original grayscale swatches beside the black-and-white results at luminance thresholds of 20% and 60%](luminance-threshold.png)

## **加入模糊、透明度與 Alpha 效果**

[AddBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) 會影響所有顏色通道，包括 Alpha。當模糊邊緣可能超出原始圖片範圍時，將 `grow` 設為 `true`。

若需統一透明度，使用 [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/)。它會乘以每個現有的 Alpha 值，使部分透明像素保持相對差異。[AddAlphaReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) 會將所有像素的 Alpha 設為同一值。[AddAlphaBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) 則根據閾值將 Alpha 轉為兩級。

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

其他無參數的 Alpha 操作還包括 [AddAlphaCeilingEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/)，它會將所有非零 Alpha 設為完全不透明；[AddAlphaFloorEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/)，將低於 100% 的 Alpha 設為完全透明；以及 [AddAlphaInverseEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/)，將 Alpha 變為 `100% - alpha`。

## **建構有序的效果鏈**

每個 `Add...Effect` 方法都會將新操作追加到集合的末端。渲染器將集合視為有序的管線：第 0 個操作的輸出成為第 1 個操作的輸入，依此類推。因此，以不同順序排列相同操作可能產生不同的圖像。

舉例而言，先做灰階再做色調會先去除色彩資訊，再為亮度結果上色；而先做色調再做灰階則會再次移除色調。類似地，Alpha 替換可以覆寫先前操作計算出的 Alpha，而 Alpha 調節則保留其相對差異。

以下範例建立四個操作的鏈，儲存為 PPTX，重新開啟簡報，檢查操作類型與順序，並渲染重新開啟的結果：

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

此集合不會強制相容性矩陣將顏色、Alpha 與模糊操作限制在不同鏈中。它們可以結合使用，但組合不一定有意義。固定的顏色替換會移除先前顏色效果產生的 RGB 變化；灰階在雙調之後會去除兩個選取顏色；Alpha 天花板、地板、替換或雙級操作則可能丟棄先前創建的 Alpha 細節。請依據所需的像素處理順序構建鏈，而非將其項目視為無序的格式旗標。

<!-- visual-explanation:image-transform-effects:start -->
[![The same image passes through grayscale then tint, and tint then grayscale. The two final grayscale images have different tones.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*此示意圖為 Aspose.Slides for .NET 26.11 的渲染結果，先在灰階後套用 220°、25% 的色調不會改變灰階圖像。若先套用相同色調再做灰階，最終灰階圖像的色調會不同。*
<!-- visual-explanation:image-transform-effects:end -->

## **檢查可編輯和有效的值**

可編輯的操作即存於 `ISlidesPicture::get_ImageTransform` 的物件。視效果而定，它可能直接暴露可寫成員。例如，[IBlur](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iblur/) 暴露 `set_Radius` 與 `set_Grow`，[IAlphaModulateFixed](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ialphamodulatefixed/) 暴露 `set_Amount`，[IAlphaBiLevel](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ialphabilevel/) 暴露 `set_Threshold`。像 [IDuotone](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iduotone/) 這類顏色效果則暴露可變更的 [IColorFormat](https://reference.aspose.com/slides/cpp/aspose.slides/icolorformat/) 物件。

某些操作介面（如 [IBrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ibrightnesscontrast/)、[IHSL](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ihsl/)、[ITint](https://reference.aspose.com/slides/cpp/aspose.slides.effects/itint/)、[IAlphaReplace](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ialphareplace/)）不會將建立時的標量暴露為可寫屬性。若要變更這些設定，必須先移除該操作，再在所需位置加入新的替代操作。

`GetEffective()` 回傳的有效資料是計算後的唯讀值。它可用於解析主題相關顏色或讀取渲染器使用的正規化值，但不作為另一個編輯介面。以下範例列舉鏈並檢查幾種常見操作的有效值：

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

雖然灰階、Alpha 天花板與 Alpha 反向等無參數效果仍有有效資料物件，但沒有可列印的標量設定。它們在集合中的存在與位置即為重要資訊。

## **移除或清除圖像變換**

使用 [IImageTransformOperationCollection::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/removeat/) 依索引移除單一操作。因為移除後索引會移位，請先搜尋目標再在列舉後移除。使用 `Clear()` 可移除整個鏈。

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

移除或清除變換僅會修改圖片的格式設定。它不會刪除、重新壓縮或以其他方式改變重複使用的 [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) 資源。

## **考慮簡報格式與匯出目標**

圖像變換源自 DrawingML，故 PPTX 為效果鏈的首選可編輯格式。即使使用 PPTX，也不是所有操作在可移植性上完全相同：

- 標準 DrawingML 操作（如亮度、灰階、雙調、色調、HSL、模糊以及常見 Alpha 操作）最有可能在 PPTX 循環後仍然存活。若需保留，請重新開啟產生的檔案並檢查集合。
- [BrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/brightnesscontrast/) 為 Office 2010 的延伸，而非標準 DrawingML 亮度操作。它可用於記憶體內渲染，但儲存並重新開啟 PPTX 後不一定仍保留為可編輯的 [IBrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ibrightnesscontrast/)。請優先使用 [AddLuminanceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) 以確保亮度與對比度的持久調整。
- 二進位 PPT 格式早於完整的 DrawingML 效果模型。儲存為 PPT 時可能會省略不支援的操作、將鏈縮減為支援子集，或以近似方式呈現外觀。請勿將 PPT 用作複雜可編輯鏈的驗證格式。
- 渲染為 PNG、JPEG、TIFF、PDF、SVG、HTML 或其他視覺輸出時，會將支援的鏈套用於最終外觀。這些輸出不會包含可編輯的 `IImageTransformOperationCollection`；點陣圖格式會將結果平鋪成像素，文件或向量匯出則儲存自己的渲染表示。
- 效果不會使連結圖像變成自包含。渲染連結圖片仍然需要在簡報載入時能取得該連結資源。

不同的簡報消費者在處理邊緣案例時可能有不同的渲染結果，尤其是同時結合多個 Alpha 或顏色量化操作時。對於關鍵輸出，請同時測試可編輯的循環與最終匯出格式，且使用與生產環境相同的 Aspose.Slides 版本。

## **常見問題**

**圖像變換效果會修改嵌入的圖像資料嗎？**

不會。這些操作屬於圖片填充使用的 `ISlidesPicture`；底層的 `IPPImage` 位元組保持不變。

**兩個重複使用相同圖像的圖片框會共享它們的效果嗎？**

不會。重複使用 `IPPImage` 只避免重複儲存圖像資料，但每個圖片框通常都有各自的 `ISlidesPicture` 與圖像變換集合。

**顏色、模糊與 Alpha 效果可以一起使用嗎？**

可以。集合接受它們以單一有序鏈的形式。請考慮每個操作對前一個結果的影響，因為替換與閾值操作可能會丟棄之前的顏色或 Alpha 細節。

**為什麼有效值是唯讀的？**

有效資料代表渲染時使用的計算值，包含已解析的顏色。若操作在變換集合中具備可寫成員，請直接編輯該操作；否則請移除它並以新建立的參數加入替代操作。

**哪種格式能保留變換鏈？**

使用 PPTX 並在儲存後重新開啟以驗證。舊版 PPT 無法完整表示 DrawingML 效果模型，而渲染匯出格式僅保留外觀，未保留可編輯的變換操作。