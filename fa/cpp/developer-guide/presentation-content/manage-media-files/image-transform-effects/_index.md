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
- مقیاس خاکستری
- دو تن
- رنگ‌زدایی
- HSL
- جایگزینی رنگ
- تاری
- شفافیت
- اثر آلفا
- زنجیرهٔ اثر
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "اعمال، زنجیره‌بندی، بررسی، حذف و تأیید اثرهای تبدیل تصویر برای فریم‌های تصویر با Aspose.Slides برای C++."
---
## **نمای کلی**

Aspose.Slides تنظیمات تصویر را به عنوان یک مجموعهٔ مرتب از عملیات تبدیل تصویر نمایش می‌دهد. برای یک فریم تصویر، با فریم‌ٔ [ISlidesPicture](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidespicture/) شروع کنید و به [ISlidesPicture::get_ImageTransform](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidespicture/get_imagetransform/) دسترسی پیدا کنید. مجموعهٔ بازگردانده‌شدهٔ [IImageTransformOperationCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides.effects/iimagetransformoperationcollection/) به شما امکان افزودن، شمارش، بازرسی، حذف و پاک‌سازی اثرها را بدون نوشتن مجدد بایت‌های تصویر اصلی می‌دهد.

این مقاله یک جریان کار کامل را برای روشنایی و کنتراست، تبدیل‌های رنگی، تاری، شفافیت، زنجیره‌های اثر مرتب، مقادیر مؤثر، حذف و بررسی دوری PPTX نشان می‌دهد.

## **درک مالکیت اثر و استفاده مجدد از تصویر**

یک منبع تصویر و تصویری که آن را نمایش می‌دهد، اشیا متفاوتی هستند:

- [IPPImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ippimage/) داده‌های تصویر منبع را که به ارائه تعلق دارد، ذخیره یا به آن ارجاع می‌دهد.
- [ISlidesPicture](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidespicture/) متعلق به یک پرکن تصویر است و به منبع تصویر ارجاع می‌دهد در حالی که مجموعهٔ تبدیل تصویر را ذخیره می‌کند.
- [IPictureFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipictureframe/) شکل اسلاید است که پرکن تصویر مرتبط، هندسه، تنظیمات برش و سایر قالب‌بندی‌های سطح فریم را در اختیار دارد.

بنابراین، عملیات تبدیل تصویر بایت‌های موجود در [IPPImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ippimage/) را تغییر نمی‌دهد. وقتی همان `IPPImage` بیش از یک بار به [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishapecollection/addpictureframe/) پاس داده شود، هر فریم تصویر جدید یک `ISlidesPicture` و مجموعهٔ تبدیل خود را دریافت می‌کند. اعمال مقیاس‌سنجی خاکستری (grayscale) بر یک فریم، فریم‌های دیگر را خاکستری نمی‌کند، حتی اگر همهٔ آن‌ها از همان منبع تصویر توکار استفاده کنند.

مدل `ISlidesPicture::get_ImageTransform` مشابه در پرکن‌های دیگر تصویر نیز به کار می‌رود، مانند شکل یا پس‌زمینهٔ اسلاید. مثال‌های زیر بر فریم‌های تصویر متمرکز هستند.

## **استفاده از بازه‌ها و واحدهای پارامتر معتبر**

متدهای نشان داده شده از بازه‌ها و واحدهای معنایی زیر استفاده می‌کنند. حتی اگر نسخهٔ خاصی از کتابخانه هر مقدار خارج از بازه را بلافاصله رد نکند، مقادیر را در این بازه‌ها نگه دارید؛ فرمت هدف ممکن است هنگام ذخیره یا باز کردن توسط PowerPoint داده‌های نامعتبر را نرمال‌سازی، حذف یا رد کند.

| عملیات | پارامترها | بازه و واحد معتبر |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/fa/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` تا `100`، درصد؛ `0` مؤلفه را بدون تغییر می‌گذارد. |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/fa/cpp/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | None | پارامتر عددی نیست. آلفا تغییر نمی‌کند. |
| [AddDuotoneEffect](https://reference.aspose.com/slides/fa/cpp/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | دو رنگ برای پیکسل‌های تاریک و روشن. مقادیر کانال‌های RGB و آلفا در `System::Drawing::Color` از `0` تا `255` استفاده می‌شود. |
| [AddTintEffect](https://reference.aspose.com/slides/fa/cpp/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | `hue` از `0` شامل تا `360` به‌جز شامل، بر حسب درجه؛ `amount` از `-100` تا `100`، درصد. |
| [AddHSLEffect](https://reference.aspose.com/slides/fa/cpp/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | `hue` از `0` شامل تا `360` به‌جز شامل، بر حسب درجه؛ `saturation` و `luminance` از `-100` تا `100`، درصد. |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/fa/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | رنگ جایگزین از مقادیر کانال `0` تا `255` استفاده می‌کند. مقادیر آلفای موجود بدون تغییر می‌مانند. |
| [AddBlurEffect](https://reference.aspose.com/slides/fa/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | `radius` عددی غیرمنفی است و بر حسب نقطه اندازه‌گیری می‌شود؛ `grow` تعیین می‌کند آیا محتوای تاری می‌تواند خارج از مرزهای اصلی گسترش یابد یا نه. |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/fa/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | درصد غیرمنفی. برای مقیاس‌پذیری شفافیت معمولی از `0` تا `100` استفاده کنید: `0` کاملاً شفاف و `100` آلفای موجود را حفظ می‌کند. |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/fa/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` تا `100`، درصد شفافیت. |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/fa/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` تا `100`، درصد آستانهٔ آلفا. مقادیری که کمتر از آن باشند شفاف می‌شوند؛ مقادیری که برابر یا بالاتر باشند تاری می‌شوند. |

برای مدولاسیون ثابت آلفا، شفافیت و کدری مکمل یکدیگرند. برای مثال، 35٪ شفافیت معادل مقدار مدولاسیون آلفا 65٪ است.

## **اعمال روشنایی و کنتراست**

[IImageTransformOperationCollection::AddBrightnessContrastEffect](https://reference.aspose.com/slides/fa/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) یک عملیات [IBrightnessContrast](https://reference.aspose.com/slides/fa/cpp/aspose.slides.effects/ibrightnesscontrast/) باز می‌گرداند. مقادیر اسکالار آن هنگام ساخت عملیات فراهم می‌شوند. متد `IBrightnessContrast::GetEffective` مقادیر محاسبه‌شدهٔ فقط‑خواندنی را برمی‌گرداند که می‌توان آن‌ها را بازرسی یا ثبت کرد.

مثال زیر روشنایی را 15٪ و کنتراست را 20٪ افزایش می‌دهد و سپس پیش‌نمایشی بدون تغییر تصویر توکار رندر می‌کند:

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

[BrightnessContrast](https://reference.aspose.com/slides/fa/cpp/aspose.slides.effects/brightnesscontrast/) یک افزونهٔ اثر تصویر Office 2010 است و نسبت به اثر استاندارد DrawingML کم‌قابلیت حمل است. هنگامی که باید روشنایی و کنتراست پس از یک دوری PPTX ویرایش‌پذیر باقی بمانند، از [IImageTransformOperationCollection::AddLuminanceEffect](https://reference.aspose.com/slides/fa/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) استفاده کنید و پس از باز کردن دوبارهٔ فایل نتیجه را بررسی کنید. بخش محدودیت‌های فرمت این تمایز را با جزئیات بیشتری توضیح می‌دهد.

## **اعمال تبدیل‌های رنگی**

اثرهای رنگی می‌توانند به‌صورت مستقل بر فریم‌های مختلفی که از یک منبع تصویر استفاده می‌کنند، اعمال شوند. مثال زیر پنج فریم ایجاد می‌کند و به ترتیب مقیاس‌سنجی خاکستری، دو‑تن، رنگ‌زدایی، تنظیم HSL و جایگزینی رنگ را اعمال می‌نماید.

[IDuotone](https://reference.aspose.com/slides/fa/cpp/aspose.slides.effects/iduotone/) دو پارامتر رنگی مستقل دارد: `get_Color1` پیکسل‌های تاریک را نقشه می‌کند، در حالی که `get_Color2` پیکسل‌های روشن را نقشه می‌کند. این مثال مفید برای اثری است که تنظیمات پیچیده‌تری نسبت به یک مقدار اسکالار دارد.

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

[AddColorReplaceEffect](https://reference.aspose.com/slides/fa/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) هر رنگ پیکسل را با یک رنگ ثابت جایگزین می‌کند ولی آلفا را حفظ می‌نمود. این متفاوت از [AddColorChangeEffect](https://reference.aspose.com/slides/fa/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/) است که یک رنگ منبع را به رنگ هدف دیگری نگاشت می‌کند و هر دو فرمت رنگ منبع و هدف را نشان می‌دهد.

## **اضافه کردن تاری، شفافیت و اثرهای آلفا**

[AddBlurEffect](https://reference.aspose.com/slides/fa/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) بر تمام کانال‌های رنگی، شامل آلفا، تأثیر می‌گذارد. وقتی لبهٔ تاری ممکن است خارج از مرزهای تصویر اصلی گسترش یابد، `grow` را برابر `true` تنظیم کنید.

برای شفافیت یکنواخت، از [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/fa/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) استفاده کنید. این اثر هر مقدار آلفای موجود را ضرب می‌کند، به‌طوری که پیکسل‌های نیمه‌شفاف نسبتاً متفاوت باقی می‌مانند. [AddAlphaReplaceEffect](https://reference.aspose.com/slides/fa/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) به‌جای آن یک مقدار آلفا یکسان را به همهٔ پیکسل‌ها اختصاص می‌دهد. [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/fa/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) آلفا را بر پایه یک آستانه به دو سطح تبدیل می‌کند.

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

دیگر عملیات‌های آلفای بدون پارامتر شامل [AddAlphaCeilingEffect](https://reference.aspose.com/slides/fa/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/) است که هر آلفای غیرصفر را به طور کامل کدری می‌کند؛ [AddAlphaFloorEffect](https://reference.aspose.com/slides/fa/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/) که هر آلفایی زیر 100٪ را به طور کامل شفاف می‌کند؛ و [AddAlphaInverseEffect](https://reference.aspose.com/slides/fa/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/) که آلفا را به `100% - alpha` تغییر می‌دهد.

## **ساخت زنجیرهٔ اثر مرتب**

هر متد `Add...Effect` یک عملیات جدید را به انتهای مجموعه اضافه می‌کند. رندرر مجموعه را به‌عنوان یک خط لولهٔ مرتب استفاده می‌کند: خروجی عملیات 0 ورودی عملیات 1 می‌شود و به همین ترتیب. بنابراین، همان عملیات‌ها در ترتیب متفاوت می‌توانند تصویر متفاوتی تولید کنند.

به‌عنوان مثال، ابتدا مقیاس‌سنجی خاکستری و سپس رنگ‌زدایی، اطلاعات رنگی را حذف می‌کند و سپس نتیجهٔ روشنایی را دوباره رنگ می‌کند. رنگ‌زدایی پس از رنگ‌زدایی دوباره رنگ را حذف می‌کند. به‌طور مشابه، جایگزینی آلفا می‌تواند مقادیر آلفای محاسبه‌شده توسط عملیات قبلی را تحت‌الشعاع قرار دهد، در حالی که مدولاسیون آلفا تفاوت‌های نسبی آن‌ها را حفظ می‌کند.

مثال زیر زنجیره‌ای چهارعملیاتی می‌سازد، آن را به‌صورت PPTX ذخیره می‌کند، ارائه را دوباره باز می‌کند، هم نوع عملیات‌ها و هم ترتیب آن‌ها را بررسی می‌کند و نتیجهٔ بازگشایی‌شده را رندر می‌کند:

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

مجموعه محدودیتی برای ترکیب عملیات‌های رنگ، آلفا و تاری به‌صورت زنجیره‌های جداگانه اعمال نمی‌کند. آن‌ها می‌توانند ترکیب شوند، اما ترکیب‌ها همیشه مفید نیستند. جایگزینی ثابت رنگ، تنوع RGB تولید‌شده توسط اثرهای رنگی قبلی را حذف می‌کند؛ مقیاس‌سنجی خاکستری پس از دو‑تن، دو رنگ انتخابی را از بین می‌برد؛ و عملیات‌های آلفا ceiling، floor، replacement یا bi‑level می‌توانند جزئیات آلفا ایجادشدهٔ قبل را نادیده بگیرند. زنجیره را بر مبنای دنبالهٔ پردازش پیکسل‌های موردنظر بسازید نه به‌عنوان پرچم‌های قالب‌بندی بدون ترتیب.

## **بازرسی مقادیر ویرایش‌پذیر و مؤثر**

یک عملیات ویرایش‌پذیر شیء‌ای است که در `ISlidesPicture::get_ImageTransform` ذخیره می‌شود. بسته به اثر، ممکن است اعضای نوشتنی را مستقیماً در دسترس بگذارد. برای مثال، [IBlur](https://reference.aspose.com/slides/fa/cpp/aspose.slides.effects/iblur/) متدهای `set_Radius` و `set_Grow` را نشان می‌دهد، [IAlphaModulateFixed](https://reference.aspose.com/slides/fa/cpp/aspose.slides.effects/ialphamodulatefixed/) متد `set_Amount` و [IAlphaBiLevel](https://reference.aspose.com/slides/fa/cpp/aspose.slides.effects/ialphabilevel/) متد `set_Threshold` را فراهم می‌کند. اثرهای رنگی مانند [IDuotone](https://reference.aspose.com/slides/fa/cpp/aspose.slides.effects/iduotone/) اشیای [IColorFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icolorformat/) قابل تغییر را نشان می‌دهند.

برخی از رابط‌های عملیات، شامل [IBrightnessContrast](https://reference.aspose.com/slides/fa/cpp/aspose.slides.effects/ibrightnesscontrast/)، [IHSL](https://reference.aspose.com/slides/fa/cpp/aspose.slides.effects/ihsl/)، [ITint](https://reference.aspose.com/slides/fa/cpp/aspose.slides.effects/itint/) و [IAlphaReplace](https://reference.aspose.com/slides/fa/cpp/aspose.slides.effects/ialphareplace/)، اسکالارهای ساخت خود را به‌عنوان ویژگی‌های نوشتنی در دسترس قرار نمی‌دهند. برای تغییر این تنظیمات، عملیات را حذف کنید و جایگزینی در موقعیت موردنظر اضافه کنید.

دادهٔ مؤثر بازگردانده‌شده توسط `GetEffective()` محاسبه‌شده و فقط‑خواندنی است. برای حل رنگ‌های وابسته به تم و خواندن مقادیر نرمال‌شده‌ای که رندرر استفاده می‌کند مفید است، اما سطح ویرایش دیگری نیست. مثال زیر زنجیره را شمارش می‌کند و مقادیر مؤثر چند عملیات رایج را بررسی می‌کند:

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

اثرهای بدون پارامتر مانند مقیاس‌سنجی خاکستری، آلفا ceiling و آلفا inverse همچنان یک شیء دادهٔ مؤثر دارند، اما اسکالارهایی برای چاپ ندارند. حضور و موقعیت آن‌ها در مجموعه اطلاعات مهم هستند.

## **حذف یا پاک‌سازی تبدیل‌های تصویر**

از [IImageTransformOperationCollection::RemoveAt](https://reference.aspose.com/slides/fa/cpp/aspose.slides.effects/iimagetransformoperationcollection/removeat/) برای حذف یک عملیات بر اساس اندیس استفاده کنید. چون اندیس‌ها پس از حذف جابجا می‌شوند، ابتدا هدف را جستجو کنید و پس از شمارش حذف نمایید. برای حذف تمام زنجیره از `Clear()` استفاده کنید.

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

حذف یا پاک‌سازی تبدیل‌ها تنها قالب‌بندی تصویر را تغییر می‌دهد. منبع [IPPImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ippimage/) که بازاستفاده می‌شود را حذف، بازفشرده یا به‌صورت دیگری تغییر نمی‌دهد.

## **در نظر گرفتن فرمت‌های ارائه و هدف‌های خروجی**

تبدیل‌های تصویر ریشه در DrawingML دارند، بنابراین PPTX فرمت ویرایش‌پذیر ترجیحی برای زنجیره‌های اثر است. حتی با PPTX، همهٔ عملیات‌ها همان قابلیت حملی را ندارند:

- عملیات‌های استاندارد DrawingML مانند luminance، grayscale، duotone، tint، HSL، blur و عملیات‌های عمومی آلفا بهترین شانس بقا در یک دوری PPTX را دارند. همیشه فایل تولیدشده را باز کنید و مجموعه را بازرسی کنید وقتی حفظ اثر یک نیاز است.
- [BrightnessContrast](https://reference.aspose.com/slides/fa/cpp/aspose.slides.effects/brightnesscontrast/) یک افزونهٔ Office 2010 است نه عملیات استاندارد luminance DrawingML. می‌توان از آن برای رندر در حافظه استفاده کرد، اما پس از ذخیره و بازگشایی PPTX تضمین نیست که به‌عنوان یک [IBrightnessContrast](https://reference.aspose.com/slides/fa/cpp/aspose.slides.effects/ibrightnesscontrast/) ویرایش‌پذیر باقی بماند. برای تنظیمات پایدار روشنایی و کنتراست، از [AddLuminanceEffect](https://reference.aspose.com/slides/fa/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) استفاده کنید.
- فرمت باینری PPT پیش از مدل کامل اثر DrawingML وجود داشته است. ذخیره به PPT می‌تواند عملیات‌های پشتیبانی‌نشده را حذف کند، زنجیره را به زیرمجموعه‌ای پشتیبانی‌شده تقلیل دهد یا ظاهر را تقریب بزند. برای یک زنجیرهٔ قابل ویرایش پیچیده، از PPT به‌عنوان فرمت تأیید استفاده نکنید.
- رندر به PNG، JPEG، TIFF، PDF، SVG، HTML یا خروجی‌های بصری دیگر زنجیره پشتیبانی‌شده را بر ظاهر رندره‌شده اعمال می‌کند. این خروجی‌ها شامل یک `IImageTransformOperationCollection` ویرایش‌پذیر نیستند؛ فرمت‌های رستر نتیجه را به پیکسل‌ها صاف می‌کنند و خروجی‌های سند یا وکتور نمایش رندر خود را ذخیره می‌کنند.
- اثرها تصویر پیوندی را خودکفا نمی‌سازند. رندر یک تصویر پیوندی هنوز به موجود بودن منبع پیوندی هنگام بارگذاری ارائه وابسته است.

مصرف‌کنندگان مختلف ارائه ممکن است موارد حاشیه‌ای را به‌صورت متفاوتی رندر کنند، بویژه زمانی که چندین عملیات آلفا یا کمّی‌سازی رنگ ترکیب شوند. برای خروجی‌ بحرانی، هر دو دوری ویرایش‌پذیر و فرمت خروجی نهایی را با همان نسخهٔ Aspose.Slides که در تولید استفاده می‌شود تست کنید.

## **پرسش‌های متداول**

**آیا اثرهای تبدیل تصویر دادهٔ تصویر توکار را تغییر می‌دهند؟**

نه. این عملیات‌ها به `ISlidesPicture` که توسط پرکن تصویر استفاده می‌شود تعلق دارند. بایت‌های زیرین `IPPImage` بدون تغییر می‌مانند.

**آیا دو فریم تصویری که از یک تصویر استفاده می‌کنند اثرهای خود را به اشتراک می‌گذارند؟**

نه. استفاده مجدد از `IPPImage` از تکرار دادهٔ تصویر جلوگیری می‌کند، اما هر فریم تصویر معمولاً یک `ISlidesPicture` و مجموعهٔ تبدیل تصویر جداگانه دارد.

**آیا می‌توان اثرهای رنگ، تاری و آلفا را ترکیب کرد؟**

بله. مجموعه این اثرها را در یک زنجیرهٔ مرتب می‌پذیرد. توجه کنید هر عملیات چه تأثیری بر خروجی عملیات قبلی دارد، چون عملیات‌های جایگزینی و آستانه ممکن است جزئیات رنگ یا آلفای قبلی را حذف کنند.

**چرا مقادیر مؤثر فقط‑خواندنی هستند؟**

دادهٔ مؤثر مقادیر محاسبه‌شده‌ای را نشان می‌دهد که برای رندر استفاده می‌شوند، از جمله رنگ‌های حل‌ شده. عملیات ذخیره‌شده در مجموعهٔ تبدیل را ویرایش کنید جایی که ویژگی‌های نوشتنی وجود دارد؛ در غیر اینصورت آن را حذف کرده و با پارامترهای جدید جایگزین کنید.

**برای حفظ یک زنجیرهٔ تبدیل کدام فرمت را باید استفاده کنم؟**

از PPTX استفاده کنید و فایل را با بازگشایی دوباره تأیید کنید. PPT قدیمی نمی‌تواند مدل کامل اثر DrawingML را پیاده‌سازی کند و فرمت‌های خروجی رندره‌شده ظاهر را حفظ می‌کنند نه عملیات تبدیل قابل ویرایش.