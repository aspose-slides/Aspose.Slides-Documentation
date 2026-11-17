---
title: مدیریت اثرهای تبدیل تصویر در ارائه‌ها با C++
linktitle: اثرهای تبدیل تصویر
type: docs
weight: 11
url: /fa/cpp/image-transform-effects/
keywords:
- تبدیل تصویر
- اثر تصویر
- روشنایی
- کنتراست
- سیاه-سفید
- دو-تن
- رنگ-پندار
- HSL
- جایگزینی رنگ
- تاری
- شفافیت
- اثر آلفا
- زنجیره اثر
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "اعمال، زنجیره‌سازی، بازرسی، حذف و تأیید اثرهای تبدیل تصویر برای فریم‌های تصویر با Aspose.Slides برای C++."
---
## **بررسی کلی**

Aspose.Slides تنظیمات تصویر را به‌عنوان یک مجموعهٔ مرتب از عملیات تبدیل تصویر نشان می‌دهد. برای یک فریم تصویر، با [ISlidesPicture](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/) شروع کنید و به [ISlidesPicture::get_ImageTransform](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/get_imagetransform/) دسترسی پیدا کنید. مجموعهٔ بازگردانده‌شدهٔ [IImageTransformOperationCollection](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/) به شما امکان اضافه‌کردن، شمارش، بازبینی، حذف و پاک‌سازی اثرها را بدون بازنویسی بایت‌های تصویر اصلی می‌دهد.

این مقاله یک جریان کاری کامل برای روشنایی و کنتراست، تبدیل‌های رنگ، تاری، شفافیت، زنجیرهٔ اثرات مرتب، مقادیر مؤثر، حذف و تأیید دورانی PPTX را نشان می‌دهد.

## **درک مالکیت اثر و استفاده مجدد از تصویر**

یک منبع تصویر و عکسی که آن را نمایش می‌دهد، اشیائی متفاوت هستند:

- [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) داده‌های تصویر منبع را که توسط ارائه‌نامه مالکیت دارد، ذخیره یا ارجاع می‌دهد.
- [ISlidesPicture](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/) به یک پرکنندهٔ تصویر تعلق دارد و به منبع تصویر ارجاع می‌دهد در حالی که مجموعهٔ تبدیل تصویر را ذخیره می‌کند.
- [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/) شکل اسلاید است که پرکنندهٔ تصویر مربوطه، هندسه، تنظیمات برش و سایر قالب‌بندی‌های سطح فریم را دارا است.

بنابراین، عملیات تبدیل تصویر بایت‌های موجود در [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) را تغییر نمی‌دهند. وقتی همان `IPPImage` بیش از یک بار به [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addpictureframe/) پاس داده شود، هر فریم تصویر جدید یک `ISlidesPicture` و مجموعهٔ تبدیل خود را دریافت می‌کند. اعمال تبدیل خاکستری به یک فریم، فریم‌های دیگر را خاکستری نمی‌کند، حتی اگر همهٔ آن‌ها از همان منبع تصویر توکار استفاده کنند.

مدل `ISlidesPicture::get_ImageTransform` همچنین توسط پرکننده‌های تصویر دیگر، مانند شکل یا پس‌زمینهٔ اسلاید، استفاده می‌شود. مثال‌های زیر بر فریم‌های تصویر متمرکز هستند.

## **استفاده از بازه‌ها و واحدهای معتبر پارامترها**

روش‌های نشان داده‌شده از بازه‌ها و واحدهای معنایی زیر استفاده می‌کنند. حتی اگر نسخهٔ خاصی از کتابخانه هر مقدار خارج از بازه را فوراً رد نکند، مقادیر را در این بازه‌ها نگه دارید؛ فرمت هدف ارائه‌نامه ممکن است داده‌های نامعتبر را هنگام ذخیره‌سازی یا بازکردن توسط PowerPoint نرمال‌سازی، حذف یا رد کند.

| عملیات | پارامترها | بازه معتبر و واحد |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` تا `100`، درصد؛ `0` مؤلفه را بدون تغییر می‌گذارد. |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | ندارد | پارامتر عددی ندارد. آلفا تغییر نمی‌کند. |
| [AddDuotoneEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | دو رنگ برای پیکسل‌های تیره و روشن. مقادیر کانال‌های RGB و آلفا در `System::Drawing::Color` از `0` تا `255`. |
| [AddTintEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | `hue` شامل `0` تا کمتر از `360`، به درجه؛ `amount` از `-100` تا `100`، درصد. |
| [AddHSLEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | `hue` شامل `0` تا کمتر از `360`، به درجه؛ `saturation` و `luminance` از `-100` تا `100`، درصد. |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | رنگ جایگزین مقادیر کانال‌ها را از `0` تا `255` می‌گیرد. مقادیر آلفای موجود بدون تغییر می‌مانند. |
| [AddBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | `radius` مقدار غیرمنفی است و به نقطه اندازه‌گیری می‌شود؛ `grow` تعیین می‌کند که محتویات محو‌شده ممکن است خارج از مرزهای اصلی گسترش یابد. |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | درصد غیرمنفی. برای مقیاس‌گذاری معمولی شفافیت از `0` تا `100` استفاده کنید: `0` کاملاً شفاف و `100` آلفای موجود را حفظ می‌کند. |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` تا `100`، درصد شفافیت. |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` تا `100`، درصد آستانهٔ آلفا. مقادیر زیر این آستانه شفاف می‌شوند؛ مقادیر برابر یا بالاتر کاملاً مات می‌شوند. |

برای مدولاتاسیون ثابت آلفا، شفافیت و مات بودن مکمل یکدیگرند. به عنوان مثال، 35٪ شفافیت معادل مقدار مدولاتاسیون آلفا 65٪ است.

## **اعمال روشنایی و کنتراست**

[IImageTransformOperationCollection::AddBrightnessContrastEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) یک عملیات [IBrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ibrightnesscontrast/) برمی‌گرداند. تنظیمات اسکالر آن هنگام ایجاد عملیات تامین می‌شود. متد `IBrightnessContrast::GetEffective` مقادیر فقط‑خواندنی محاسبه‌شده را برمی‌گرداند که می‌توان آن‌ها را بررسی یا ثبت کرد.

مثال زیر روشنایی را 15٪ و کنتراست را 20٪ افزایش می‌دهد، سپس پیش‌نمایشی را بدون تغییر تصویر توکار رندر می‌کند:

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

[BrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/brightnesscontrast/) یک افزونهٔ اثر تصویر Office 2010 است و نسبت به اثر luminance استاندارد DrawingML کمتر قابل حمل است. وقتی روشنایی و کنتراست باید پس از دورانی PPTX قابل ویرایش بمانند، از [IImageTransformOperationCollection::AddLuminanceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) استفاده کنید و پس از باز کردن مجدد فایل نتیجه را تأیید کنید. بخش محدودیت‌های قالب این تمایز را با جزئیات بیشتر توضیح می‌دهد.

## **اعمال تبدیل‌های رنگی**

اثرات رنگ می‌توانند به‌صورت مستقل بر فریم‌های تصویر مختلفی که یک منبع تصویر را به‌کار می‌برند، اعمال شوند. مثال زیر پنج فریم ایجاد می‌کند و به ترتیب خاکستری، دو‑تن، رنگ‌پندار، تنظیم HSL و جایگزینی رنگ را اعمال می‌نماید.

[IDuotone](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iduotone/) دو پارامتر رنگی مستقل قابل ویرایش دارد: `get_Color1` پیکسل‌های تیره را نگاشت می‌کند، در حالی که `get_Color2` پیکسل‌های روشن را نگاشت می‌کند. این باعث می‌شود مثال مفیدی برای اثری باشد که تنظیمات پیچیده‌تری نسبت به یک مقدار اسکالر واحد دارد.

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

[AddColorReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) رنگ هر پیکسل را با یک رنگ ثابت جایگزین می‌کند در حالی که آلفا را حفظ می‌کند. این متفاوت از [AddColorChangeEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/) است که یک رنگ منبع را به رنگ هدفی دیگر نگاشت می‌کند و هر دو قالب رنگ منبع و هدف را نمایان می‌سازد.

### **اعمال آستانهٔ روشنایی**

یک آستانهٔ روشنایی می‌تواند علائم کم‌رنگ روی صفحهٔ اسکن‌شده را نسبت به پس‌زمینهٔ آن شفاف‌تر کند. [AddGrayScaleEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) سایه‌های خاکستری میانی را حفظ می‌کند. [AddBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbileveleffect/) روشنایی را به سیاه یا سفید نگاشت می‌کند، در حالی که [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) آستانه‌ای بر شفافیت اعمال می‌نماید.

آستانهٔ روشنایی از 0٪ تا 100٪، شامل هر دو انتها، متغیر است. پیکسل‌های زیر آستانه سیاه می‌شوند. پیکسل‌های برابر یا بالای آستانه سفید می‌شوند. افزایش آستانه باعث می‌شود سایه‌های بیشتری سیاه شوند چون بیشترشان زیر حد برش قرار می‌گیرند.

فایل [grayscale-swatches.png](grayscale-swatches.png) را در پوشهٔ کاری بارگیری کنید. هر برچسب سطح خاکستری اصلی را بر مقیاس 0 تا 255 نشان می‌دهد. مثال اصلی را کنار دو نسخهٔ کپی می‌گذارد و آستانهٔ هر کپی را در ارائه‌نامه ذخیره می‌کند.

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

ارائه‌نامه خروجی را در PowerPoint باز کنید تا سه فریم را مقایسه کنید. سوئچ برچسب‌خوردهٔ 96 تقریباً 38٪ روشنایی (96 از 255) دارد. در آستانهٔ 20٪ سفید می‌شود و در آستانهٔ 60٪ سیاه.

![نمونه‌های خاکستری اصلی در کنار نتایج سیاه‑و‑سفید در آستانه‌های روشنایی 20٪ و 60٪](luminance-threshold.png)

## **اضافه‌کردن تاری، شفافیت و اثرات آلفا**

[AddBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) تمام کانال‌های رنگی، شامل آلفا، را تحت تاثیر قرار می‌دهد. وقتی لبهٔ محو‌شده ممکن است خارج از مرزهای تصویر اصلی گسترش یابد، `grow` را به `true` تنظیم کنید.

برای شفافیت یکنواخت، از [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) استفاده کنید. این اثر هر مقدار آلفای موجود را ضرب می‌کند، بنابراین پیکسل‌های نیمه‑شفاف به نسبت متفاوت باقی می‌مانند. [AddAlphaReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) به‌جای آن یک مقدار آلفا واحد را به تمام پیکسل‌ها اختصاص می‌دهد. [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) آلفا را بر پایهٔ یک آستانه به دو سطح تبدیل می‌کند.

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

سایر عملیات آلفای بدون پارامتر شامل [AddAlphaCeilingEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/) است که هر آلفای غیرصفر را کاملاً مات می‌سازد؛ [AddAlphaFloorEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/) که هر آلفای زیر 100٪ را کاملاً شفاف می‌کند؛ و [AddAlphaInverseEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/) که آلفا را به `100% - alpha` تغییر می‌دهد.

## **ساخت زنجیرهٔ اثرات مرتب**

هر متد `Add...Effect` عملیاتی جدید را به انتهای مجموعه اضافه می‌کند. رندر کننده مجموعه را به‌عنوان یک خط لولهٔ مرتب استفاده می‌کند: خروجی عملیات 0 به‌عنوان ورودی عملیات 1 و همین طور ادامه می‌یابد. بنابراین، همان عملیات‌ها در ترتیب متفاوت می‌توانند تصویری متفاوت تولید کنند.

به عنوان مثال، خاکستری سپس رنگ‌پندار ابتدا اطلاعات رنگی را حذف می‌کند و سپس نتایج روشنایی را رنگ‌گذاری می‌کند. رنگ‌پندار سپس خاکستری دوباره رنگ‌پندار را حذف می‌کند. به‌طور مشابه، جایگزینی آلفا می‌تواند مقادیر آلفا را که توسط عملیات‌های پیشین محاسبه شده‌اند، بازنویسی کند، در حالی که مدولاتاسیون آلفا تفاوت‌های نسبی آن‌ها را حفظ می‌کند.

مثال زیر زنجیره‌ای متشکل از چهار عملیات می‌سازد، آن را به‌صورت PPTX ذخیره می‌کند، ارائه‌نامه را مجدداً باز می‌کند، نوع و ترتیب عملیات‌ها را بررسی می‌کند و نتیجهٔ باز شده را رندر می‌کند:

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

مجموعه محدودیتی برای ترکیب رنگ، آلفا و عملیات تاری در زنجیره‌های جداگانه اعمال نمی‌کند. می‌توان آن‌ها را ترکیب کرد، اما ترکیب‌ها همیشه مفید نیستند. یک جایگزینی رنگ ثابت، تغییرات RGB تولیدشده توسط اثرات رنگی قبلی را حذف می‌کند؛ خاکستری پس از دو‑تن، دو رنگ انتخاب شده را حذف می‌کند؛ و عملیات‌های سقف، کف، جایگزینی یا دو‑سطح آلفا می‌توانند جزئیات آلفای ایجادشده پیش‌تر را نادیده بگیرند. زنجیره را بر اساس توالی پردازش پیکسل موردنظر بسازید نه به‌عنوان پرچم‌های قالب‌بندی نامرتب.

<!-- visual-explanation:image-transform-effects:start -->
[![همان تصویر ابتدا از طریق خاکستری سپس رنگ‌پندار، و سپس رنگ‌پندار سپس خاکستری عبور می‌کند. دو تصویر نهایی خاکستری دارای تن‌های متفاوتی هستند.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*در این رندر نمونهٔ Aspose.Slides for .NET 26.11، یک رنگ‌پندار 220° با 25٪ خاکستری را تغییر نمی‌دهد. اعمال همان رنگ‌پندار قبل از خاکستری تن‌های متفاوتی تولید می‌کند.*
<!-- visual-explanation:image-transform-effects:end -->

## **بازرسی مقادیر قابل ویرایش و مؤثر**

یک عملیات قابل ویرایش شیء ذخیره‌شده در `ISlidesPicture::get_ImageTransform` است. بسته به اثر، ممکن است اعضای قابل نوشتن را به‌طور مستقیم نمایان کند. برای مثال، [IBlur](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iblur/) متدهای `set_Radius` و `set_Grow` را نمایان می‌کند، [IAlphaModulateFixed](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ialphamodulatefixed/) متد `set_Amount` را، و [IAlphaBiLevel](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ialphabilevel/) متد `set_Threshold` را. اثرات رنگی مانند [IDuotone](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iduotone/) اشیاء [IColorFormat](https://reference.aspose.com/slides/cpp/aspose.slides/icolorformat/) قابل تغییر را نمایان می‌کنند.

برخی رابط‌های عملیات، از جمله [IBrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ibrightnesscontrast/)، [IHSL](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ihsl/)، [ITint](https://reference.aspose.com/slides/cpp/aspose.slides.effects/itint/)، و [IAlphaReplace](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ialphareplace/)، پارامترهای ساخت خود را به‌عنوان ویژگی‌های قابل نوشتن باز نمی‌کنند. برای تغییر این تنظیمات، عملیات را حذف کنید و یک جایگزین در موقعیت موردنظر اضافه کنید.

دادهٔ مؤثر که توسط `GetEffective()` بازگردانده می‌شود، محاسبه‌شده و فقط‑خواندنی است. برای حل رنگ‌های وابسته به تم و خواندن مقادیر نرمال‌شده‌ای که رندر کننده استفاده می‌کند، مفید است، اما سطح ویرایش دیگری نیست. مثال زیر زنجیره را مرور می‌کند و مقادیر مؤثر چند عملیات رایج را بررسی می‌کند:

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

اثرهای بدون پارامتر مانند خاکستری، سقف آلفا و معکوس آلفا هنوز یک شیء دادهٔ مؤثر دارند، اما تنظیمات اسکالر برای چاپ ندارند. حضور و موقعیت آن‌ها در مجموعه اطلاعات مهم است.

## **حذف یا پاک‌سازی تبدیل‌های تصویر**

از [IImageTransformOperationCollection::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/removeat/) برای حذف یک عملیات بر اساس شاخص استفاده کنید. چون شاخص‌ها پس از حذف جابجا می‌شوند، ابتدا هدف را جستجو کنید و سپس پس از مرور آن را حذف کنید. برای حذف کل زنجیره از `Clear()` استفاده کنید.

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

حذف یا پاک‌سازی تبدیل‌ها فقط قالب‌بندی تصویر را تغییر می‌دهد. این کار منبع [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) توکار را حذف، فشرده‌سازی یا به‌گونه‌ای دیگر تغییر نمی‌دهد.

## **در نظر گرفتن قالب‌های ارائه و هدف‌های خروجی**

تبدیل‌های تصویر در DrawingML منشا می‌گیرند، بنابراین PPTX قالب ویرایشی ترجیحی برای زنجیره‌های اثر است. حتی در PPTX، همهٔ عملیات‌ها یک قابلیت حملی یکسان ندارند:

- عملیات‌های استاندارد DrawingML مانند luminance، خاکستری، دو‑تن، رنگ‌پندار، HSL، تاری و عملیات‌های رایج آلفا بیشترین شانس بقا پس از دورانی PPTX را دارند. همیشه فایل تولیدشده را باز کنید و مجموعه را هنگام نیاز به حفظ بررسی کنید.
- [BrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/brightnesscontrast/) یک افزونهٔ Office 2010 است نه عملیات luminance استاندارد DrawingML. می‌تواند برای رندر در حافظه استفاده شود، اما پس از ذخیره و بازکردن PPTX تضمین نمی‌شود که به‌عنوان یک [IBrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ibrightnesscontrast/) قابل ویرایش باقی بماند. برای تنظیمات دائمی روشنایی و کنتراست، [AddLuminanceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) را ترجیح دهید.
- قالب باینری PPT پیش از مدل کامل اثر DrawingML وجود داشت. ذخیره به PPT می‌تواند عملیات‌های پشتیبانی‌نشده را حذف کند، زنجیره را به زیرمجموعه‌ای پشتیبانی‌شده کاهش دهد یا ظاهر را تقریب بزند. از PPT به‌عنوان قالب تأیید برای زنجیرهٔ ویرایشی پیچیده استفاده نکنید.
- رندر به PNG، JPEG، TIFF، PDF، SVG، HTML یا سایر خروجی‌های بصری، زنجیرهٔ پشتیبانی‌شده را بر روی ظاهر رندر اعمال می‌کند. این خروجی‌ها یک `IImageTransformOperationCollection` قابل ویرایش ندارند؛ قالب‌های رستر نتیجه را به پیکسل‌ها فلت می‌کند و صادرات اسناد یا برداری نمایهٔ رندر خود را ذخیره می‌کند.
- اثرها تصویر پیوندی را خودکفا نمی‌کنند. رندر یک تصویر پیوندی همچنان به در دسترس بودن منبع پیوندی هنگام بارگذاری ارائه‌نامه وابسته است.

مصرف‌کنندگان مختلف ارائه ممکن است موارد حدی را متفاوت رندر کنند، به‌ویژه زمانی که چندین عملیات آلفا یا کوانتیزه‌کردن رنگ ترکیب شوند. برای خروجی حساس، هم دورانی ویرایشی و هم قالب نهایی صادراتی را با همان نسخهٔ Aspose.Slides مورد استفاده در تولید تست کنید.

## **سؤالات متداول**

**آیا اثرهای تبدیل تصویر دادهٔ تصویر توکار را تغییر می‌دهند؟**

نه. این عملیات‌ها به `ISlidesPicture` که توسط پرکنندهٔ تصویر استفاده می‌شود تعلق دارند. بایت‌های زیرین `IPPImage` بدون تغییر می‌مانند.

**آیا دو فریم تصویر که همان تصویر را دوباره استفاده می‌کنند، اثرهای یکسانی خواهند داشت؟**

نه. استفادهٔ مجدد از یک `IPPImage` از داده‌های تصویر تکراری جلوگیری می‌کند، اما هر فریم تصویر به‌طور معمول یک `ISlidesPicture` و مجموعهٔ تبدیل تصویر جداگانه دارد.

**آیا می‌توان اثرهای رنگ، تاری و آلفا را ترکیب کرد؟**

بله. مجموعه آن‌ها را در یک زنجیرهٔ مرتب می‌پذیرد. توجه داشته باشید هر عملیات چه‌طور بر خروجی عملیات قبلی تاثیر می‌گذارد، زیرا عملیات جایگزینی و آستانه ممکن است جزئیات رنگ یا آلفا قبلی را حذف کنند.

**چرا مقادیر مؤثر فقط‑خواندنی هستند؟**

دادهٔ مؤثر مقدارهای محاسبه‌شده‌ای را که برای رندر استفاده می‌شوند، از جمله رنگ‌های حل‌شده، نشان می‌دهد. عملیات ذخیره‌شده در مجموعهٔ تبدیل را که اعضای قابل نوشتن دارد ویرایش کنید؛ در غیر این صورت آن را حذف کنید و با پارامترهای ساخت جدید جایگزین کنید.

**برای حفظ زنجیرهٔ تبدیل چه قالبی را باید استفاده کنم؟**

از PPTX استفاده کنید و فایل را با باز کردن مجدد تأیید کنید. قالب قدیمی PPT نمی‌تواند مدل کامل اثر DrawingML را نشان دهد و قالب‌های صادراتی رندری فقط ظاهر را حفظ می‌کنند، نه عملیات تبدیل قابل ویرایش.