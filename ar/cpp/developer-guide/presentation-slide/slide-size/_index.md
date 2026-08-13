---
title: تغيير حجم شريحة العرض التقديمي في C++
linktitle: حجم الشريحة
type: docs
weight: 70
url: /ar/cpp/slide-size/
keywords:
- حجم الشريحة
- نسبة الأبعاد
- قياسي
- عريض الشاشة
- 4:3
- 16:9
- تحديد حجم الشريحة
- تغيير حجم الشريحة
- حجم شريحة مخصص
- حجم شريحة خاص
- حجم شريحة فريد
- شريحة بالحجم الكامل
- نوع الشاشة
- عدم التحجيم
- ضمان الملاءمة
- تكبير
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "تعلم كيفية تغيير حجم الشرائح بسرعة في ملفات PPT و PPTX و ODP باستخدام C++ و Aspose.Slides، وحسن العروض التقديمية لأي شاشة دون فقدان الجودة."
---
## **المقدمة**

توفر Aspose.Slides أدوات شاملة لضبط حجم الشريحة ونسبة الأبعاد في عروض PowerPoint، وهو أمر حاسم لكل من الطباعة والعرض على الشاشة.

أحجام النسب الشائعة للشرائح:

- **Standard (نسبة 4:3)**: مثالي للشاشات والأجهزة القديمة.
- **Widescreen (نسبة 16:9)**: يُنصح به لأجهزة العرض الحديثة والشاشات.

تأكد من الاتساق طوال عرضك حيث يُطبق حجم الشريحة ونسبة الأبعاد الواحدة على جميع الشرائح. للحصول على أفضل النتائج، قم بتعيين أبعاد الشريحة في بداية إنشاء العرض لتجنب التعقيدات.

{{% alert color="info" %}} 
افتراضيًا، العروض التي تم إنشاؤها باستخدام Aspose.Slides تستخدم نسبة 4:3 القياسية.
{{% /alert %}}

## **تغيير حجم الشريحة في العروض التقديمية**

يعرض لك هذا المثال البرمجي كيفية تغيير حجم الشريحة في عرض تقديمي بلغة C++ باستخدام Aspose.Slides:

``` cpp
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres-4x3-aspect-ratio.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
```

## **تحديد أحجام شرائح مخصصة في العروض التقديمية**

إذا وجدت أن أحجام الشرائح الشائعة (4:3 و 16:9) غير مناسبة لعملك، قد تقرر استخدام حجم شريحة محدد أو فريد. على سبيل المثال، إذا كنت تخطط لطباعة شرائح بالحجم الكامل من عرضك على تخطيط صفحة مخصص أو إذا كنت تنوي عرض العرض على أنواع شاشات معينة، فمن المحتمل أن تستفيد من استخدام إعداد حجم مخصص لعرضك.

يعرض لك هذا المثال البرمجي كيفية استخدام Aspose.Slides للغة C++ لتحديد حجم شريحة مخصص لعرض تقديمي بلغة C++:

``` cpp
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
// حجم ورق A4
pres->get_SlideSize()->SetSize(780.0f, 540.0f, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-a4-slide-size.pptx", SaveFormat::Pptx);
```

## **معالجة محتوى الشريحة بعد تغيير الحجم**

بعد تغيير حجم الشريحة لعرض تقديمي، قد يصبح محتوى الشرائح (مثل الصور أو الكائنات) مشوهًا. افتراضيًا، يتم تغيير حجم الكائنات تلقائيًا لتناسب حجم الشريحة الجديد. ومع ذلك، عند تغيير حجم شريحة العرض، يمكنك تحديد إعداد يحدد كيفية تعامل Aspose.Slides مع المحتوى على الشرائح.

اعتمادًا على ما تنوي القيام به أو تحقيقه، يمكنك استخدام أي من هذه الإعدادات:

- `DoNotScale`

  إذا كنت لا تريد أن يتم تغيير حجم الكائنات على الشرائح، استخدم هذا الإعداد.

- `EnsureFit`

  إذا كنت تريد التحجيم إلى حجم شريحة أصغر وتحتاج إلى أن تقوم Aspose.Slides بتقليص كائنات الشرائح لضمان ملائمتها جميعًا على الشرائح (وبذلك تتجنب فقدان المحتوى)، استخدم هذا الإعداد.

- `Maximize`

  إذا كنت تريد التحجيم إلى حجم شريحة أكبر وتحتاج إلى أن تقوم Aspose.Slides بتكبير كائنات الشرائح لجعلها متناسبة مع حجم الشريحة الجديد، استخدم هذا الإعداد.

يعرض لك هذا المثال البرمجي كيفية استخدام إعداد `Maximize` عند تغيير حجم شريحة عرض تقديمي:

``` cpp
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
```

## **الأسئلة المتكررة**

### هل يمكنني تعيين حجم شريحة مخصص باستخدام وحدات غير البوصة (مثل النقاط أو المليمترات)؟

نعم. تستخدم Aspose.Slides النقاط داخليًا، حيث يساوي 1 نقطة 1/72 من البوصة. يمكنك تحويل أي وحدة (مثل المليمترات أو السنتيمترات) إلى نقاط واستخدام القيم المحوّلة لتحديد عرض وارتفاع الشريحة.

### هل سيؤثر حجم شريحة مخصص كبير جدًا على الأداء واستخدام الذاكرة أثناء التصيير؟

نعم. الأبعاد الكبيرة للشرائح (بالنقاط) مع مقياس تصيير أعلى تؤدي إلى زيادة استهلاك الذاكرة وزيادة وقت المعالجة. استهدف حجم شريحة عملي وقم بضبط مقياس التصيير فقط حسب الحاجة لتحقيق الجودة المطلوبة للمخرجات.

### هل يمكنني تعريف حجم شريحة غير قياسي ثم دمج الشرائح من عروض تقديمية ذات أحجام مختلفة؟

لا يمكنك [دمج العروض](/slides/ar/cpp/merge-presentation/) بينما لديها أحجام شرائح مختلفة — أولاً، قم بإعادة تحجيم أحد العروض لتطابق الآخر. عند تغيير حجم الشريحة، يمكنك اختيار كيفية معالجة المحتوى الموجود عبر خيار [SlideSizeScaleType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/slidesizescaletype/). بعد مطابقة الأحجام، يمكنك دمج الشرائح مع الحفاظ على التنسيق.

### هل يمكنني إنشاء صور مصغرة لأشكال فردية أو مناطق محددة من شريحة، وهل ستحترم حجم الشريحة الجديد؟

نعم. يمكن لـ Aspose.Slides إنشاء صور مصغرة لـ [الشرائح الكاملة](https://reference.aspose.com/slides/ar/cpp/aspose.slides/slide/getimage/) وكذلك لـ [الأشكال المحددة](https://reference.aspose.com/slides/ar/cpp/aspose.slides/shape/getimage/). تعكس الصور الناتجة حجم الشريحة الحالي ونسبة الأبعاد، مما يضمن إطارًا وتكوينًا متسقًا.