---
title: مدیریت پس‌زمینه‌های ارائه در C++
linktitle: پس‌زمینه اسلاید
type: docs
weight: 20
url: /fa/cpp/presentation-background/
keywords:
- پس‌زمینه ارائه
- پس‌زمینه اسلاید
- رنگ ثابت
- رنگ گرادیان
- پس‌زمینه تصویر
- شفافیت پس‌زمینه
- ویژگی‌های پس‌زمینه
- پاورپوینت
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "یاد بگیرید چگونه با استفاده از Aspose.Slides برای C++ پس‌زمینه‌های پویا را در فایل‌های PowerPoint و OpenDocument تنظیم کنید و با نکات کد، ارائه‌های خود را ارتقا دهید."
---
## **مقدمه**

رنگ‌های ثابت، گرادیان‌ها و تصاویر معمولاً برای پس‌زمینه اسلایدها استفاده می‌شوند. می‌توانید پس‌زمینه یک **اسلاید عادی** (یک اسلاید تک) یا یک **اسلاید اصلی** (برای چندین اسلاید به‌صورت همزمان) را تنظیم کنید.

![پس‌زمینه PowerPoint](powerpoint-background.png)

## **تنظیم پس‌زمینه رنگ ثابت برای یک اسلاید عادی**

Aspose.Slides به شما امکان می‌دهد تا یک رنگ ثابت را به‌عنوان پس‌زمینه یک اسلاید خاص در یک ارائه تنظیم کنید — حتی اگر ارائه از اسلاید اصلی استفاده کند. این تغییر فقط بر روی اسلاید انتخاب‌شده اعمال می‌شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
2. مقدار ویژگی [BackgroundType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/backgroundtype/) اسلاید را به `OwnBackground` تنظیم کنید.
3. مقدار ویژگی [FillType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/filltype/) پس‌زمینه اسلاید را به `Solid` تنظیم کنید.
4. از متد [get_SolidFillColor](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fillformat/get_solidfillcolor/) در [FillFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fillformat/) برای تعیین رنگ پس‌زمینه ثابت استفاده کنید.
5. ارائه‌ی تغییر یافته را ذخیره کنید.

مثال زیر به زبان C++ نشان می‌دهد چگونه یک رنگ ثابت آبی را به‌عنوان پس‌زمینه یک اسلاید عادی تنظیم کنید:

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

// یک نمونه از کلاس Presentation ایجاد کنید.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// رنگ پس‌زمینه اسلاید را به آبی تنظیم کنید.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// ارائه را روی دیسک ذخیره کنید.
presentation->Save(u"SolidColorBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **تنظیم پس‌زمینه رنگ ثابت برای یک اسلاید اصلی**

Aspose.Slides به شما امکان می‌دهد تا یک رنگ ثابت را به‌عنوان پس‌زمینه اسلاید اصلی در یک ارائه تنظیم کنید. اسلاید اصلی به‌عنوان قالبی عمل می‌کند که قالب‌بندی تمام اسلایدها را کنترل می‌کند، بنابراین وقتی یک رنگ ثابت را برای پس‌زمینه اسلاید اصلی انتخاب می‌کنید، بر تمام اسلایدها اعمال می‌شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
2. مقدار ویژگی [BackgroundType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/backgroundtype/) اسلاید اصلی (از طریق `get_Masters`) را به `OwnBackground` تنظیم کنید.
3. مقدار ویژگی [FillType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/filltype/) پس‌زمینه اسلاید اصلی را به `Solid` تنظیم کنید.
4. از متد [get_SolidFillColor](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fillformat/get_solidfillcolor/) برای تعیین رنگ پس‌زمینه ثابت استفاده کنید.
5. ارائه‌ی تغییر یافته را ذخیره کنید.

مثال زیر به زبان C++ نشان می‌دهد چگونه یک رنگ ثابت سبز جنگلی را به‌عنوان پس‌زمینه اسلاید اصلی تنظیم کنید:

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

// یک نمونه از کلاس Presentation ایجاد کنید.
auto presentation = MakeObject<Presentation>();

auto masterSlide = presentation->get_Master(0);

// رنگ پس‌زمینه اسلاید Master را به سبز جنگل تنظیم کنید.
masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

// ارائه را روی دیسک ذخیره کنید.
presentation->Save(u"MasterSlideBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **تنظیم پس‌زمینه گرادیان برای اسلاید**

گرادیان یک اثر گرافیکی است که با تغییر تدریجی رنگ ایجاد می‌شود. هنگامی که به‌عنوان پس‌زمینه اسلاید استفاده می‌شود، می‌تواند نمایش ارائه را هنری‌تر و حرفه‌ای‌تر کند. Aspose.Slides به شما امکان می‌دهد تا یک رنگ گرادیان را به‌عنوان پس‌زمینه اسلایدها تنظیم کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
2. مقدار ویژگی [BackgroundType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/backgroundtype/) اسلاید را به `OwnBackground` تنظیم کنید.
3. مقدار ویژگی [FillType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/filltype/) پس‌زمینه اسلاید را به `Gradient` تنظیم کنید.
4. از متد [get_GradientFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fillformat/get_gradientformat/) در [FillFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fillformat/) برای پیکربندی تنظیمات دلخواه گرادیان استفاده کنید.
5. ارائه‌ی تغییر یافته را ذخیره کنید.

مثال زیر به زبان C++ نشان می‌دهد چگونه یک رنگ گرادیان را به‌عنوان پس‌زمینه یک اسلاید تنظیم کنید:

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

// یک نمونه از کلاس Presentation ایجاد کنید.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// یک اثر گرادیان را به پس‌زمینه اعمال کنید.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Gradient);
slide->get_Background()->get_FillFormat()->get_GradientFormat()->set_TileFlip(TileFlip::FlipBoth);

// ارائه را روی دیسک ذخیره کنید.
presentation->Save(u"GradientBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **تنظیم تصویر به‌عنوان پس‌زمینه اسلاید**

علاوه بر پرکردن‌های ثابت و گرادیان، Aspose.Slides به شما امکان می‌دهد از تصاویر به‌عنوان پس‌زمینه اسلایدها استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
2. مقدار ویژگی [BackgroundType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/backgroundtype/) اسلاید را به `OwnBackground` تنظیم کنید.
3. مقدار ویژگی [FillType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/filltype/) پس‌زمینه اسلاید را به `Picture` تنظیم کنید.
4. تصویری که می‌خواهید به‌عنوان پس‌زمینه اسلاید استفاده شود را بارگذاری کنید.
5. تصویر را به‌کالج تصویرهای ارائه اضافه کنید.
6. از متد [get_PictureFillFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fillformat/get_picturefillformat/) در [FillFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fillformat/) برای تخصیص تصویر به‌عنوان پس‌زمینه استفاده کنید.
7. ارائه‌ی تغییر یافته را ذخیره کنید.

مثال زیر به زبان C++ نشان می‌دهد چگونه یک تصویر را به‌عنوان پس‌زمینه یک اسلاید تنظیم کنید:

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

// یک نمونه از کلاس Presentation ایجاد کنید.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// ویژگی‌های تصویر پس‌زمینه را تنظیم کنید.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Picture);
slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

// بارگذاری تصویر.
auto image = Images::FromFile(u"Tulips.jpg");
// تصویر را به مجموعه تصاویر ارائه اضافه کنید.
auto ppImage = presentation->get_Images()->AddImage(image);
image->Dispose();

slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(ppImage);

// ارائه را روی دیسک ذخیره کنید.
presentation->Save(u"ImageAsBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نمونه کد زیر نشان می‌دهد چگونه نوع پر کردن پس‌زمینه را به تصویر کاشی‌شده تغییر داده و خصوصیات کاشی را اصلاح کنید:

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

بیشتر بخوانید: [**Tile Picture As Texture**](/slides/fa/cpp/shape-formatting/#tile-picture-as-texture).

{{% /alert %}}

### **تغییر شفافیت تصویر پس‌زمینه**

ممکن است بخواهید شفافیت تصویر پس‌زمینه اسلاید را تنظیم کنید تا محتویات اسلاید برجسته‌تر شوند. کد C++ زیر نشان می‌دهد چگونه شفافیت تصویر پس‌زمینه اسلاید را تغییر دهید:

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

auto transparencyValue = 30; // به عنوان مثال.

// یک نمونه از کلاس Presentation ایجاد کنید.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto slide = presentation->get_Slide(0);

// مجموعهٔ عملیات تبدیل تصویر را دریافت کنید.
auto imageTransform = slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->get_ImageTransform();

// یک اثر شفافیت ثابت-درصد موجود را پیدا کنید.
SharedPtr<IAlphaModulateFixed> transparencyOperation;
for (auto&& operation : imageTransform)
{
    if (ObjectExt::Is<IAlphaModulateFixed>(operation))
    {
        transparencyOperation = ExplicitCast<IAlphaModulateFixed>(operation);
        break;
    }
}

// مقدار شفافیت جدید را تنظیم کنید.
if (transparencyOperation == nullptr)
{
    imageTransform->AddAlphaModulateFixedEffect(100.0f - transparencyValue);
}
else
{
    transparencyOperation->set_Amount(100.0f - transparencyValue);
}

// ارائه را روی دیسک ذخیره کنید.
presentation->Save(u"TransparentBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **دریافت مقدار پس‌زمینه اسلاید**

Aspose.Slides رابط [IBackgroundEffectiveData](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibackgroundeffectivedata/) را برای بازیابی مقادیر موثر پس‌زمینه اسلاید فراهم می‌کند. این رابط اطلاعات موثر [FillFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibackgroundeffectivedata/get_fillformat/) و [EffectFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibackgroundeffectivedata/get_effectformat/) را نمایش می‌دهد.

با استفاده از متد `get_Background` کلاس [BaseSlide](https://reference.aspose.com/slides/fa/cpp/aspose.slides/baseslide/) می‌توانید پس‌زمینه مؤثر یک اسلاید را به دست آورید.

مثال زیر به زبان C++ نشان می‌دهد چگونه مقدار پس‌زمینه مؤثر یک اسلاید را دریافت کنید:

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

// یک نمونه از کلاس Presentation ایجاد کنید.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto slide = presentation->get_Slide(0);

// پس‌زمینهٔ مؤثر را دریافت کنید، با در نظر گرفتن master، layout و theme.
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

## **سوالات متداول**

### آیا می‌توانم پس‌زمینهٔ سفارشی را بازنشانی کرده و پس‌زمینهٔ تم/طرح‌بندی را بازگردانم؟

بله. پرکردن سفارشی اسلاید را حذف کنید و پس‌زمینه دوباره از اسلاید [layout](/slides/fa/cpp/slide-layout/)/[master](/slides/fa/cpp/slide-master/) مربوطه (یعنی [تم پس‌زمینه](/slides/fa/cpp/presentation-theme/)) به ارث برده می‌شود.

### چه اتفاقی برای پس‌زمینه می‌افتد اگر پس از آن تم ارائه را تغییر دهم؟

اگر یک اسلاید پرکردن خود را داشته باشد، بدون تغییر باقی می‌ماند. اگر پس‌زمینه از [layout](/slides/fa/cpp/slide-layout/)/[master](/slides/fa/cpp/slide-master/) به ارث برده شده باشد، با تم جدید هم‌خوانی پیدا می‌کند.