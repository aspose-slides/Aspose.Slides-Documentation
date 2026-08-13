---
title: 管理 C++ 簡報背景
linktitle: 投影片背景
type: docs
weight: 20
url: /zh-hant/cpp/presentation-background/
keywords:
- 簡報背景
- 投影片背景
- 純色
- 漸層顏色
- 影像背景
- 背景透明度
- 背景屬性
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for C++ 在 PowerPoint 與 OpenDocument 檔案中設定動態背景，並提供程式碼技巧提升您的簡報。"
---
## **簡介**

純色、漸層和影像通常用於投影片背景。您可以為 **普通投影片**（單一投影片）或 **母片**（一次套用至多張投影片）設定背景。

![PowerPoint 背景](powerpoint-background.png)

## **為普通投影片設定純色背景**

Aspose.Slides 允許您在簡報中為特定投影片設定純色背景，即使簡報使用了母片。此變更僅套用於所選投影片。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。
2. 將投影片的 [BackgroundType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/backgroundtype/) 設為 `OwnBackground`。
3. 將投影片背景的 [FillType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/filltype/) 設為 `Solid`。
4. 使用 [FillFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fillformat/) 上的 [get_SolidFillColor](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fillformat/get_solidfillcolor/) 方法指定純色背景。
5. 儲存修改後的簡報。

下列 C++ 範例示範如何將藍色純色設定為普通投影片的背景：

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// 建立 Presentation 類別的實例。
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// 設定投影片的背景顏色為藍色。
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// 將簡報儲存至磁碟。
presentation->Save(u"SolidColorBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **為母片設定純色背景**

Aspose.Slides 允許您為簡報中的母片設定純色背景。母片作為範本，控制所有投影片的格式，當您為母片的背景選擇純色時，會套用至每一張投影片。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。
2. 將母片的 [BackgroundType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/backgroundtype/)（透過 `get_Masters`）設為 `OwnBackground`。
3. 將母片背景的 [FillType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/filltype/) 設為 `Solid`。
4. 使用 [get_SolidFillColor](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fillformat/get_solidfillcolor/) 方法指定純色背景。
5. 儲存修改後的簡報。

下列 C++ 範例示範如何將森林綠設定為母片的背景：

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// 建立 Presentation 類別的實例。
auto presentation = MakeObject<Presentation>();

auto masterSlide = presentation->get_Master(0);

// 設定母片的背景顏色為森林綠。
masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

// 將簡報儲存至磁碟。
presentation->Save(u"MasterSlideBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **為投影片設定漸層背景**

漸層是一種透過顏色逐漸變化產生的圖形效果。作為投影片背景時，漸層能讓簡報更具藝術感與專業感。Aspose.Slides 允許您為投影片設定漸層顏色作為背景。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。
2. 將投影片的 [BackgroundType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/backgroundtype/) 設為 `OwnBackground`。
3. 將投影片背景的 [FillType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/filltype/) 設為 `Gradient`。
4. 使用 [FillFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fillformat/) 上的 [get_GradientFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fillformat/get_gradientformat/) 方法設定您偏好的漸層參數。
5. 儲存修改後的簡報。

下列 C++ 範例示範如何將漸層顏色設定為投影片的背景：

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/TileFlip.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// 建立 Presentation 類別的實例。
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// 為背景套用漸層效果。
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Gradient);
slide->get_Background()->get_FillFormat()->get_GradientFormat()->set_TileFlip(TileFlip::FlipBoth);

// 將簡報儲存至磁碟。
presentation->Save(u"GradientBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **將影像設定為投影片背景**

除了純色和漸層填充外，Aspose.Slides 也允許您使用影像作為投影片背景。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。
2. 將投影片的 [BackgroundType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/backgroundtype/) 設為 `OwnBackground`。
3. 將投影片背景的 [FillType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/filltype/) 設為 `Picture`。
4. 載入您想作為投影片背景的影像。
5. 將影像加入簡報的影像集合。
6. 使用 [FillFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fillformat/) 上的 [get_PictureFillFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fillformat/get_picturefillformat/) 方法將影像指派為背景。
7. 儲存修改後的簡報。

下列 C++ 範例示範如何將影像設定為投影片的背景：

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// 建立 Presentation 類別的實例。
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// 設定背景影像屬性。
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Picture);
slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

// 載入影像。
auto image = Images::FromFile(u"Tulips.jpg");
// 將影像加入簡報的影像集合。
auto ppImage = presentation->get_Images()->AddImage(image);
image->Dispose();

slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(ppImage);

// 將簡報儲存至磁碟。
presentation->Save(u"ImageAsBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

下列程式碼範例示範如何將背景填充類型設定為平鋪圖片，並修改平鋪屬性：

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/TileFlip.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto firstSlide = presentation->get_Slide(0);

auto background = firstSlide->get_Background();

background->set_Type(BackgroundType::OwnBackground);
background->get_FillFormat()->set_FillType(FillType::Picture);

auto newImage = Images::FromFile(u"image.png");
auto ppImage = presentation->get_Images()->AddImage(newImage);
newImage->Dispose();

// Set the image used for the background fill.
auto backPictureFillFormat = background->get_FillFormat()->get_PictureFillFormat();
backPictureFillFormat->get_Picture()->set_Image(ppImage);

// Set the picture fill mode to Tile and adjust the tile properties.
backPictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
backPictureFillFormat->set_TileOffsetX(15.0);
backPictureFillFormat->set_TileOffsetY(15.0);
backPictureFillFormat->set_TileScaleX(46.0);
backPictureFillFormat->set_TileScaleY(87.0);
backPictureFillFormat->set_TileAlignment(RectangleAlignment::Center);
backPictureFillFormat->set_TileFlip(TileFlip::FlipY);

presentation->Save(u"TileBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="info" %}}
閱讀更多： [**將圖片平鋪作為紋理**](/slides/zh-hant/cpp/shape-formatting/#tile-picture-as-texture)。
{{% /alert %}}

### **變更背景影像透明度**

您可能想調整投影片背景影像的透明度，以突顯投影片內容。下列 C++ 程式碼示範如何變更投影片背景影像的透明度：

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace Aspose::Slides::Export;
using namespace System;

auto transparencyValue = 30; // 例如。

// 建立 Presentation 類別的實例。
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto slide = presentation->get_Slide(0);

// 取得圖片變換操作的集合。
auto imageTransform = slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->get_ImageTransform();

// 尋找現有的固定百分比透明度效果。
SharedPtr<IAlphaModulateFixed> transparencyOperation;
for (auto&& operation : imageTransform)
{
    if (ObjectExt::Is<IAlphaModulateFixed>(operation))
    {
        transparencyOperation = ExplicitCast<IAlphaModulateFixed>(operation);
        break;
    }
}

// 設定新的透明度值。
if (transparencyOperation == nullptr)
{
    imageTransform->AddAlphaModulateFixedEffect(100.0f - transparencyValue);
}
else
{
    transparencyOperation->set_Amount(100.0f - transparencyValue);
}

// 將簡報儲存至磁碟。
presentation->Save(u"TransparentBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **取得投影片背景值**

Aspose.Slides 提供 [IBackgroundEffectiveData](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ibackgroundeffectivedata/) 介面，以取得投影片的有效背景值。此介面揭露有效的 [FillFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ibackgroundeffectivedata/get_fillformat/) 與 [EffectFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ibackgroundeffectivedata/get_effectformat/)。

使用 [BaseSlide](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/baseslide/) 類別的 `get_Background` 方法，您可以取得投影片的有效背景。

下列 C++ 範例示範如何取得投影片的有效背景值：

```cpp
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IBackgroundEffectiveData.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

// 建立 Presentation 類別的實例。
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto slide = presentation->get_Slide(0);

// Retrieve the effective background, taking into account master, layout, and theme.
auto effBackground = slide->get_Background()->GetEffective();

if (effBackground->get_FillFormat()->get_FillType() == FillType::Solid)
{
    Console::WriteLine(u"Fill color: {0}", effBackground->get_FillFormat()->get_SolidFillColor());
}
else
{
    Console::WriteLine(u"Fill type: {0}", ObjectExt::ToString(effBackground->get_FillFormat()->get_FillType()));
}
```

## **常見問題**

### 我可以重設自訂背景並還原佈景主題/版面配置背景嗎？

可以。移除投影片的自訂填色，背景將會再次從對應的 [版面配置](/slides/zh-hant/cpp/slide-layout/)/[母片](/slides/zh-hant/cpp/slide-master/) 投影片（即 [佈景主題背景](/slides/zh-hant/cpp/presentation-theme/)）繼承。

### 如果稍後變更簡報的佈景主題，背景會發生什麼情形？

如果投影片有自己的填色，則保持不變。若背景是從 [版面配置](/slides/zh-hant/cpp/slide-layout/)/[母片](/slides/zh-hant/cpp/slide-master/) 繼承，則會更新以符合 [新佈景主題](/slides/zh-hant/cpp/presentation-theme/)。