---
title: تحويل شرائح PowerPoint إلى PNG في C++
linktitle: PowerPoint إلى PNG
type: docs
weight: 30
url: /ar/cpp/convert-powerpoint-to-png/
keywords:
- تحويل PowerPoint
- تحويل عرض تقديمي
- تحويل شريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى PNG
- العرض التقديمي إلى PNG
- الشريحة إلى PNG
- PPT إلى PNG
- PPTX إلى PNG
- حفظ PPT كـ PNG
- حفظ PPTX كـ PNG
- تصدير PPT إلى PNG
- تصدير PPTX إلى PNG
- C++
- Aspose.Slides
description: "تحويل عروض PowerPoint إلى صور PNG عالية الجودة بسرعة باستخدام Aspose.Slides للغة C++، لضمان نتائج دقيقة ومؤتمتة."
---
## **نظرة عامة**

توضح هذه المقالة كيفية تحويل شرائح العروض التقديمية إلى صور PNG باستخدام Aspose.Slides للغة C++. يمكنك تحميل العروض بتنسيقات مثل PPT و PPTX و ODP، ثم عرض كل شريحة وحفظها كصورة PNG منفصلة.

تظهر الأمثلة أدناه كيفية العرض بالمقياس الافتراضي، وزيادة المقياس، وتحديد أبعاد الإخراج بالبكسل، واختيار نمط عرض التدرج.

## **تحويل PowerPoint إلى PNG**

قم بتحميل عرض تقديمي باستخدام الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) والوصول إلى شرائحه عبر المُستخرج [Presentation::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slide/). تقوم الأمثلة بعرض كل شريحة باستخدام [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) بدون معلمات لإنشاء صورة مصغرة. ثم يتم استدعاء [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/) مع [ImageFormat::Png](https://reference.aspose.com/slides/cpp/aspose.slides/imageformat/) لحفظ كل شريحة معروضة كصورة PNG.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto slideCount = presentation->get_Slides()->get_Count();
for (auto index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage();
    image->Save(String::Format(u"slide_{0}.png", index), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
إن التحميل الزائد [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) دون معلمات يعرض بمقياس 0.2. على سبيل المثال، شريحة بحجم 720 × 540 نقطة تنتج صورة مصغرة بحجم 144 × 108 بكسل. للتحكم في أبعاد الإخراج، استخدم التحميلات الزائدة مع عوامل المقياس أو حجم الصورة الصريح الموضح أدناه.
{{% /alert %}}

## **تحويل PowerPoint إلى PNG بأبعاد مخصصة**

مرّر عوامل مقياس أفقية ورأسية إلى [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) للتحكم في أبعاد العرض. في هذا المثال، كلا العاملين يساوي 2، وبالتالي شريحة بحجم 720 × 540 نقطة تنتج صورة بحجم 1440 × 1080 بكسل. الحفاظ على عوامل مقياس متساوية يحافظ على نسبة عرض الشريحة. يتم حفظ كل صورة بتنسيق PNG باستخدام [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/).

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto scaleX = 2.f;
auto scaleY = scaleX;

auto slideCount = presentation->get_Slides()->get_Count();
for (auto index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage(scaleX, scaleY);
    image->Save(String::Format(u"slide_{0}.png", index), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

## **تحويل PowerPoint إلى PNG بحجم مخصص**

لتحديد أبعاد الإخراج بالبكسل، مرّر حجمًا إلى [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) بدلاً من عوامل المقياس. يعرض هذا المثال كل شريحة بحجم 960 × 720 بكسل ويحفظ النتيجة باستخدام [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/). اختر أبعادًا تطابق نسبة عرض الشريحة لتجنب تشويه الصورة.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>
#include <drawing/size.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto imageSize = System::Drawing::Size(960, 720);

auto slideCount = presentation->get_Slides()->get_Count();
for (auto index = 0; index < slideCount; index++)
{
    auto slide = presentation->get_Slide(index);
    auto image = slide->GetImage(imageSize);
    image->Save(String::Format(u"slide_{0}.png", index), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

## **اختيار نمط عرض التدرج**

افترض أن شريحة تحتوي على تعبئة بتدرجات لونية، لكن الانتقالات في PNG المُصدَّر تبدو أفتح أو مختلفة عن ما تراه في PowerPoint. يمكنك استخدام طريقة [SaveOptions::set_GradientStyle](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_gradientstyle/) في [RenderingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/renderingoptions/) لاختيار طريقة عرض التدرجات.

قم بتنزيل [gradient-styles.pptx](gradient-styles.pptx) وضعه في دليل عمل التطبيق. تحتوي الشريحة الأولى على تدرجين خطيين: من السيان إلى البرتقالي في الأعلى ومن الأزرق إلى الأصفر في الأسفل. لكل تدرج نقطتا توقف، عند 0% و 100%.

المثال التالي يقوم بتحميل هذا العرض ويعرض الشريحة الأولى نفسها في الوضعين باستخدام [ISlide::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/).

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/string.h>
#include <DOM/GradientStyle.h>
#include <Export/RenderingOptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"gradient-styles.pptx");
auto slide = presentation->get_Slide(0);

auto gradientStyles = { GradientStyle::Default, GradientStyle::PowerPointUI };
for (auto style : gradientStyles)
{
    auto options = MakeObject<RenderingOptions>();
    options->set_GradientStyle(style);

    auto image = slide->GetImage(options, 1.f, 1.f);
    auto styleName = style == GradientStyle::Default ? u"Default" : u"PowerPointUI";
    image->Save(String::Format(u"gradient-{0}.png", styleName), ImageFormat::Png);
    image->Dispose();
}

presentation->Dispose();
```

الصورة أدناه توضح النتيجة من الشريحة نفسها، مع كلا التدرجين في كل صورة:

| Default | PowerPointUI |
| --- | --- |
| ![تدرجات من السيان إلى البرتقالي ومن الأزرق إلى الأصفر تم عرضها باستخدام Default](gradient-Default.png) | ![نفس التدرجات تم عرضها باستخدام PowerPointUI](gradient-PowerPointUI.png) |

في هذا المثال، ينتج `Default` ألوانًا وسطية أفتح، بينما ينتج `PowerPointUI` ألوانًا وسطية أغمق. يعتمد الفرق على الألوان ونقاط التوقف في التدرج.

اختر `Default` عندما يناسبك إخراج Aspose.Slides القياسي. جرّب `PowerPointUI` عندما تكون أولويتك مطابقة المظهر في PowerPoint. قارن كلا الإخراجين مع النتيجة المطلوبة؛ لا وضعية واحدة مفضلة للجميع.

## **الأسئلة الشائعة**

**كيف يمكنني تصدير شكل معين، مثل مخطط أو صورة، بدلاً من الشريحة بأكملها؟**

يدعم Aspose.Slides [إنشاء صور مصغرة لأشكال فردية](/slides/ar/cpp/shape-thumbnails/)، مما يتيح لك عرض شكل كصورة PNG.

**هل يدعم التحويل المتوازي على الخادم؟**

نعم. استخدم نسخة عرض تقديمي منفصلة لكل خيط أو عملية؛ [لا تشارك نسخة واحدة عبر الخيوط](/slides/ar/cpp/multithreading/).

**ما هي قيود التقييم عند التصدير إلى PNG؟**

وضع التقييم يضيف علامة مائية إلى الصور الناتجة ويطبق [قيودًا أخرى](/slides/ar/cpp/licensing/) حتى يتم تطبيق ترخيص.