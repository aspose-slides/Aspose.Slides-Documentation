---
title: إدارة خلفيات العروض التقديمية في C++
linktitle: خلفية الشريحة
type: docs
weight: 20
url: /ar/cpp/presentation-background/
keywords:
- خلفية العرض التقديمي
- خلفية الشريحة
- لون صلب
- لون متدرج
- خلفية صورة
- شفافية الخلفية
- خصائص الخلفية
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "تعرّف على كيفية تعيين خلفيات ديناميكية في ملفات PowerPoint وOpenDocument باستخدام Aspose.Slides للغة C++، مع نصائح برمجية لتحسين عروضك التقديمية."
---
## **المقدمة**

تُستخدم الألوان الصلبة، وتدرجات الألوان، والصور عادةً كخلفيات للشرائح. يمكنك تعيين الخلفية ل**شريحة عادية** (شريحة واحدة) أو **شريحة رئيسية** (تنطبق على عدة شرائح في آن واحد).

![PowerPoint background](powerpoint-background.png)

## **تعيين خلفية بلون صلب لشريحة عادية**

تتيح لك Aspose.Slides تعيين لون صلب كخلفية لشريحة محددة في عرض تقديمي — حتى إذا كان العرض يستخدم شريحة رئيسية. ينطبق التغيير فقط على الشريحة المحددة.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/).
2. تعيين الخاصية [BackgroundType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/backgroundtype/) للشريحة إلى `OwnBackground`.
3. تعيين [FillType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/filltype/) لخلفية الشريحة إلى `Solid`.
4. استخدام الطريقة [get_SolidFillColor](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fillformat/get_solidfillcolor/) على الفئة [FillFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fillformat/) لتحديد لون الخلفية الصلب.
5. حفظ العرض التقديمي المعدل.

يعرض المثال التالي بلغة C++ كيفية تعيين لون صلب أزرق كخلفية لشريحة عادية:

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

// إنشاء كائن من فئة Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Set the background color of the slide to blue.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Save the presentation to disk.
presentation->Save(u"SolidColorBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **تعيين خلفية بلون صلب لشريحة رئيسية**

تتيح لك Aspose.Slides تعيين لون صلب كخلفية لشريحة الماستر في عرض تقديمي. تُعد شريحة الماستر قالبًا يتحكم في تنسيق جميع الشرائح، لذا عندما تختار لونًا صلبًا لخلفية شريحة الماستر، يتم تطبيقه على كل الشريحة.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/).
2. تعيين الخاصية [BackgroundType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/backgroundtype/) لشريحة الماستر (من خلال `get_Masters`) إلى `OwnBackground`.
3. تعيين [FillType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/filltype/) لخلفية شريحة الماستر إلى `Solid`.
4. استخدام الطريقة [get_SolidFillColor](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fillformat/get_solidfillcolor/) لتحديد لون الخلفية الصلب.
5. حفظ العرض التقديمي المعدل.

يعرض المثال التالي بلغة C++ كيفية تعيين لون صلب (أخضر غامق) كخلفية لشريحة الماستر:

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

// إنشاء نسخة من فئة Presentation.
auto presentation = MakeObject<Presentation>();

auto masterSlide = presentation->get_Master(0);

// Set the background color for the Master slide to Forest Green.
masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

// Save the presentation to disk.
presentation->Save(u"MasterSlideBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **تعيين خلفية متدرجة للشريحة**

التدرج هو تأثير رسومي يتم إنشاؤه عبر تغيير تدريجي في اللون. عندما يُستخدم كخلفية للشفرة، يمكن أن تجعل العروض تبدو أكثر فنية ومهنية. تتيح لك Aspose.Slides تعيين لون متدرج كخلفية للشرائح.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/).
2. تعيين الخاصية [BackgroundType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/backgroundtype/) للشفرة إلى `OwnBackground`.
3. تعيين [FillType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/filltype/) لخلفية الشريحة إلى `Gradient`.
4. استخدام الطريقة [get_GradientFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fillformat/get_gradientformat/) على الفئة [FillFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fillformat/) لتكوين إعدادات التدرج المفضلة لديك.
5. حفظ العرض التقديمي المعدل.

يعرض المثال التالي بلغة C++ كيفية تعيين لون متدرج كخلفية للشفرة:

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

// إنشاء نسخة من فئة Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Apply a gradient effect to the background.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Gradient);
slide->get_Background()->get_FillFormat()->get_GradientFormat()->set_TileFlip(TileFlip::FlipBoth);

// Save the presentation to disk.
presentation->Save(u"GradientBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **تعيين صورة كخلفية للشفرة**

بالإضافة إلى التعبئة الصلبة وتدرجات الألوان، تتيح لك Aspose.Slides استخدام الصور كخلفيات للشرائح.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/).
2. تعيين الخاصية [BackgroundType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/backgroundtype/) للشفرة إلى `OwnBackground`.
3. تعيين [FillType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/filltype/) لخلفية الشريحة إلى `Picture`.
4. تحميل الصورة التي تريد استخدامها كخلفية للشفرة.
5. إضافة الصورة إلى مجموعة صور العرض التقديمي.
6. استخدام الطريقة [get_PictureFillFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fillformat/get_picturefillformat/) على الفئة [FillFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fillformat/) لتعيين الصورة كخلفية.
7. حفظ العرض التقديمي المعدل.

يعرض المثال التالي بلغة C++ كيفية تعيين صورة كخلفية للشفرة:

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

// إنشاء نسخة من فئة Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// تعيين خصائص صورة الخلفية.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Picture);
slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

// تحميل الصورة.
auto image = Images::FromFile(u"Tulips.jpg");
// إضافة الصورة إلى مجموعة صور العرض التقديمي.
auto ppImage = presentation->get_Images()->AddImage(image);
image->Dispose();

slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(ppImage);

// حفظ العرض التقديمي إلى القرص.
presentation->Save(u"ImageAsBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

يعرض عينة الشيفرة التالية كيفية تعيين نوع تعبئة الخلفية إلى صورة متكررة وتعديل خصائص التكرار:

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
اقرأ المزيد: [**Tile Picture As Texture**](/slides/ar/cpp/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **تغيير شفافية صورة الخلفية**

قد ترغب في تعديل شفافية صورة خلفية الشريحة لجعل محتوى الشريحة يبرز. يوضح الكود التالي بلغة C++ طريقة تعديل شفافية صورة خلفية الشريحة:

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

auto transparencyValue = 30; // على سبيل المثال.

// إنشاء نسخة من فئة Presentation.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto slide = presentation->get_Slide(0);

// الحصول على مجموعة عمليات تحويل الصورة.
auto imageTransform = slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->get_ImageTransform();

// العثور على تأثير شفافية ثابت النسبة المئوية موجود.
SharedPtr<IAlphaModulateFixed> transparencyOperation;
for (auto&& operation : imageTransform)
{
    if (ObjectExt::Is<IAlphaModulateFixed>(operation))
    {
        transparencyOperation = ExplicitCast<IAlphaModulateFixed>(operation);
        break;
    }
}

// تعيين قيمة الشفافية الجديدة.
if (transparencyOperation == nullptr)
{
    imageTransform->AddAlphaModulateFixedEffect(100.0f - transparencyValue);
}
else
{
    transparencyOperation->set_Amount(100.0f - transparencyValue);
}

// حفظ العرض التقديمي إلى القرص.
presentation->Save(u"TransparentBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **الحصول على قيمة خلفية الشريحة**

توفر Aspose.Slides الواجهة [IBackgroundEffectiveData](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibackgroundeffectivedata/) لاسترجاع القيم الفعالة لخلفية الشريحة. تكشف هذه الواجهة عن قيم [FillFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibackgroundeffectivedata/get_fillformat/) و[EffectFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibackgroundeffectivedata/get_effectformat/) الفعالة.

باستخدام طريقة `get_Background` للفئة [BaseSlide](https://reference.aspose.com/slides/ar/cpp/aspose.slides/baseslide/)، يمكنك الحصول على الخلفية الفعلية لشريحة ما.

يعرض المثال التالي بلغة C++ طريقة الحصول على قيمة الخلفية الفعلية لشريحة:

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

// إنشاء نسخة من فئة Presentation.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto slide = presentation->get_Slide(0);

// استرجاع الخلفية الفعلية مع الأخذ في الاعتبار الماستر، التخطيط، والسمة.
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

## **الأسئلة المتداولة**

### هل يمكنني إعادة تعيين خلفية مخصصة واستعادة خلفية السمة/التخطيط؟

نعم. قم بإزالة التعبئة المخصصة للشفرة، وستُسترجع الخلفية مرة أخرى من شريحة [layout](/slides/ar/cpp/slide-layout/)/[master](/slides/ar/cpp/slide-master/) المقابلة (أي [theme background](/slides/ar/cpp/presentation-theme/)).

### ماذا يحدث للخلفية إذا قمت بتغيير سمة العرض التقديمي لاحقًا؟

إذا كانت الشريحة لديها تعبئة خاصة بها، فستظل دون تغيير. إذا كانت الخلفية مُستَعارَة من شريحة [layout](/slides/ar/cpp/slide-layout/)/[master](/slides/ar/cpp/slide-master/)، فستُحدَّث لتطابق [السمة الجديدة](/slides/ar/cpp/presentation-theme/).