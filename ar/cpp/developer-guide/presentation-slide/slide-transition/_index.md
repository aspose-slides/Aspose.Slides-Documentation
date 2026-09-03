---
title: إدارة انتقالات الشرائح في العروض التقديمية باستخدام C++
linktitle: انتقال الشريحة
type: docs
weight: 80
url: /ar/cpp/slide-transition/
keywords:
- انتقال الشريحة
- إضافة انتقال الشريحة
- تطبيق انتقال الشريحة
- انتقال شريحة متقدم
- انتقال مورف
- نوع الانتقال
- تأثير الانتقال
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "تطبيق انتقالات الشرائح، تكوين التقدم التلقائي للشرائح، وتخصيص انتقالات Morph وغيرها من تأثيرات الانتقال باستخدام Aspose.Slides for C++."
---
## **نظرة عامة**

تتحكم انتقالات الشرائح في كيفية ظهور الشرائح أثناء العرض التقديمي. باستخدام Aspose.Slides for C++، يمكنك اختيار تأثير الانتقال لكل شريحة، وتكوين التقدم عبر النقر بالماوس أو المؤقت، وضبط الخيارات الخاصة بكل تأثير. يستخدم هذا المقال أمثلة بلغة C++ لتطبيق الانتقالات، وتحديد مدة انتقال دقيقة، وإدارة توقيت الشرائح، وإنشاء انتقال Morph بين شريحتين. كما تظهر الأمثلة كيفية حفظ الإعدادات إلى ملف PPTX.

## **إضافة انتقال شريحة**

لتطبيق انتقال، حمِّل عرضًا تقديميًا باستخدام الفئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) وواصل إلى إعدادات انتقال الشريحة عبر [get_SlideShowTransition](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibaseslide/get_slideshowtransition/). استدعِ [set_Type](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islideshowtransition/set_type/) بقيمة من تعداد [TransitionType](https://reference.aspose.com/slides/ar/cpp/aspose.slides.slideshow/transitiontype/)، ثم احفظ العرض التقديمي.

التطبيق التالي يطبق انتقال Circle على الشريحة الأولى وانتقال Comb على الشريحة الثانية. استخدم ملف `input.pptx` يحتوي على شريحتين على الأقل.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

if (presentation->get_Slides()->get_Count() >= 2)
{
    presentation->get_Slide(0)->get_SlideShowTransition()->set_Type(TransitionType::Circle);
    presentation->get_Slide(1)->get_SlideShowTransition()->set_Type(TransitionType::Comb);

    presentation->Save(u"slide-transitions.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The input presentation must contain at least two slides.");
}

presentation->Dispose();
```

## **إضافة انتقال شريحة متقدم**

يمكنك تكوين مدة بقاء الشريحة على الشاشة وما إذا كان النقر بالماوس سيؤدي إلى تقدم العرض. تتحكم الطرق التالية في هذا السلوك:

- [set_AdvanceOnClick](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) يسمح للمشاهد بالتقدم بالنقر.
- [set_AdvanceAfter](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islideshowtransition/set_advanceafter/) يفعّل التقدم التلقائي.
- [set_AdvanceAfterTime](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) يحدّد التأخير قبل التقدم التلقائي، بالمللي ثانية.

فعّل كل من النقر والتوقيت لتتيح للمشاهد الانتقال بنقرة أو الانتظار حتى المؤقت. لاستخدام المؤقت فقط، استدعِ [set_AdvanceOnClick](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) مع `false`. يتحكم التأخير في وقت تقدم العرض؛ ولا يحدّد مدة تأثير الانتقال البصري.

هذا المثال يعيّن تأثيرات مختلفة للشرائح الثلاث الأولى ويفعل التقدم التلقائي بعد 3 و5 و7 ثوانٍ على التوالي. يمكن للنقرات أيضًا تقديم هذه الشرائح. استخدم ملف `input.pptx` يحتوي على ثلاث شرائح على الأقل.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

if (presentation->get_Slides()->get_Count() >= 3)
{
    auto firstTransition = presentation->get_Slide(0)->get_SlideShowTransition();
    firstTransition->set_Type(TransitionType::Circle);
    firstTransition->set_AdvanceOnClick(true);
    firstTransition->set_AdvanceAfter(true);
    firstTransition->set_AdvanceAfterTime(3000);

    auto secondTransition = presentation->get_Slide(1)->get_SlideShowTransition();
    secondTransition->set_Type(TransitionType::Comb);
    secondTransition->set_AdvanceOnClick(true);
    secondTransition->set_AdvanceAfter(true);
    secondTransition->set_AdvanceAfterTime(5000);

    auto thirdTransition = presentation->get_Slide(2)->get_SlideShowTransition();
    thirdTransition->set_Type(TransitionType::Zoom);
    thirdTransition->set_AdvanceOnClick(true);
    thirdTransition->set_AdvanceAfter(true);
    thirdTransition->set_AdvanceAfterTime(7000);

    presentation->Save(u"advanced-transitions.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The input presentation must contain at least three slides.");
}

presentation->Dispose();
```

للتحقق مما إذا كان التقدم المُؤقت مفعَّلًا، استدعِ [get_AdvanceAfter](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islideshowtransition/get_advanceafter/). القيمة المخزّنة للتأخير وحدها لا تعني أن المؤقت نشط.

المثال التالي يفتح الملف المحفوظ أعلاه، يبلغ عن كل مؤقت مفعَّل، ويعطّل التقدم التلقائي للشرائح التي لديها تأخير أكبر من ثانيتين. يفعّل النقر بالماوس لتلك الشرائح ويحفظ الإعدادات المحدثة.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>(u"advanced-transitions.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto transition = slide->get_SlideShowTransition();

    if (transition->get_AdvanceAfter())
    {
        Console::WriteLine(u"Slide {0}: advance after {1} ms.", slide->get_SlideNumber(), transition->get_AdvanceAfterTime());

        if (transition->get_AdvanceAfterTime() > 2000)
        {
            transition->set_AdvanceAfter(false);
            transition->set_AdvanceOnClick(true);
        }
    }
}

presentation->Save(u"adjusted-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **التحكم في توقيت الانتقال بدقة**

استخدم [set_Duration](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islideshowtransition/set_duration/) لتحديد الطول الدقيق لتأثير الانتقال بالمللي ثانية. توفر طريقة [get_SlideShowTransition](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) الخاصة بالشريحة هذه الإعدادات عبر [ISlideShowTransition](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islideshowtransition/):

| الطريقة | الهدف |
| --- | --- |
| [set_Duration](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islideshowtransition/set_duration/) | يحدد مدة تأثير الانتقال نفسه، بالمللي ثانية. |
| [set_AdvanceAfterTime](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) | يحدد التأخير قبل تقدم الشريحة تلقائيًا، بالمللي ثانية. استدعِ [set_AdvanceAfter](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islideshowtransition/set_advanceafter/) مع `true` لتفعيل هذا المؤقت. |
| [set_Speed](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islideshowtransition/set_speed/) | يختار فئة سرعة مسبقة التعريف من [TransitionSpeed](https://reference.aspose.com/slides/ar/cpp/aspose.slides.slideshow/transitionspeed/): Slow, Medium, أو Fast. تُستخدم عندما لا تُحدَّد مدة دقيقة. |

[set_Duration](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islideshowtransition/set_duration/) يتحكم فقط في تأثير الانتقال؛ ولا يحدّد مدة بقاء الشريحة مرئية. قم بتكوين تأخير التقدم التلقائي بشكل منفصل. عندما لا تُحدد مدة صريحة، تحدد Aspose.Slides مدة التأثير بناءً على نوع الانتقال والقيمة التي تُرجعها [get_Speed](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islideshowtransition/get_speed/).

### **تطبيق نفس المدة على كل شريحة**

لتحقيق إيقاع ثابت، طبق نفس التأثير والمدة الدقيقة على كل شريحة. يحمل هذا المثال `input.pptx`، يختار Fade من [TransitionType](https://reference.aspose.com/slides/ar/cpp/aspose.slides.slideshow/transitiontype/)، ويعطي كل انتقال مدة 750 مللي ثانية. يفعّل كذلك التقدم التلقائي بعد 5,000 مللي ثانية ويعطّل التقدم بالنقر، ثم يحفظ النتيجة كملف PPTX.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto transition = slide->get_SlideShowTransition();
    transition->set_Type(TransitionType::Fade);
    transition->set_Duration(750);

    // تهيئة التقدم التلقائي بشكل مستقل عن مدة التأثير.
    transition->set_AdvanceAfter(true);
    transition->set_AdvanceAfterTime(5000);
    transition->set_AdvanceOnClick(false);
}

presentation->Save(u"precise-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **تحديد مدد مختلفة للشرائح الفردية**

يمكن للشرائح المختلفة أن تستخدم مدد تأثير مختلفة. على سبيل المثال، استخدم انتقالًا سريعًا لشريحة العنوان وانتقالًا أطول لمقدمة القسم. يحدد هذا المثال 500 مللي ثانية للشريحة الأولى و1,200 مللي ثانية للثانية. استخدم ملف `input.pptx` يحتوي على شريحتين على الأقل.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

if (presentation->get_Slides()->get_Count() >= 2)
{
    auto firstTransition = presentation->get_Slide(0)->get_SlideShowTransition();
    firstTransition->set_Type(TransitionType::Fade);
    firstTransition->set_Duration(500);

    auto secondTransition = presentation->get_Slide(1)->get_SlideShowTransition();
    secondTransition->set_Type(TransitionType::Push);
    secondTransition->set_Duration(1200);

    presentation->Save(u"individual-transition-durations.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The input presentation must contain at least two slides.");
}

presentation->Dispose();
```

### **تنسيق الانتقالات مع المخرجات المتحركة**

عند إعداد [animated GIF](/slides/ar/cpp/convert-powerpoint-to-animated-gif/)، [HTML5 presentation](/slides/ar/cpp/export-to-html5/)، أو [video](/slides/ar/cpp/convert-powerpoint-to-video/)، عيّن مدد الانتقالات الدقيقة قبل التصدير لتتطابق مع الإيقاع المقصود. على سبيل المثال، استخدم تلاشيًا مدته 600 مللي ثانية بين المشاهد، وضبط تأخير تقدم كل شريحة بشكل منفصل للسماح بالوقت للتعليق الصوتي أو المحتوى.

بالنسبة للـ GIF والفيديو، نسّق معدل إطارات الخرج مع مدة التأثير: 600 مللي ثانية تعادل 18 إطارًا عند 30 إطارًا في الثانية. في HTML5، فعّل الانتقالات المتحركة في إعدادات التصدير. راجع تأثيرات وتوقيتات الصيغة المختارة، وقم بمعاينة النتيجة للتأكد من التزامن.

### **قراءة مدة انتقال موجودة**

استدعِ [get_Duration](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islideshowtransition/get_duration/) قبل تعديل الانتقال لتحديد ما إذا كانت قيمة صريحة مخزّنة. القيمة `-1` تعني عدم وجود مدة صريحة؛ القيمة غير السالبة تُحدد المدة المخزّنة بالمللي ثانية. القيمة غير المحددة ليست مدة التشغيل المحسوبة: تستخدم Aspose.Slides نوع الانتقال والقيمة التي تُرجعها [get_Speed](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islideshowtransition/get_speed/) لتحديد تلك المدة. قد يهيئ تعيين نوع الانتقال مدةً مبدئية، لذا افحص الإعدادات الأصلية أولاً.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <DOM/SlideShowTransition/TransitionSpeed.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;

auto presentation = MakeObject<Presentation>(u"input.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto transition = slide->get_SlideShowTransition();
    auto duration = transition->get_Duration();

    if (duration >= 0)
    {
        Console::WriteLine(u"Slide {0}: stored transition duration is {1} ms.", slide->get_SlideNumber(), duration);
    }
    else
    {
        Console::WriteLine(u"Slide {0}: no explicit duration; timing depends on {1} and {2}.", slide->get_SlideNumber(), transition->get_Type(), transition->get_Speed());
    }
}

presentation->Dispose();
```

## **انتقال Morph**

يُحاكي انتقال Morph التغيّر بين الكائنات على شرائح متتالية. لإنشاء تأثير Morph بسيط، استنسخ شريحة، حرّك أو عدّل حجم كائن على النسخة المستنسخة، وطبق انتقال Morph على الشريحة الثانية. يمنح ذلك الانتقال الكائنات المطابقة لتتحرك بين الحالة الأصلية والمعدلة.

التطبيق التالي ينشئ شريحة تحتوي على مستطيل نص، يستنسخ الشريحة، ويغيّر موضع وحجم المستطيل في النسخة المستنسخة. ثم يختار Morph من تعداد [TransitionType](https://reference.aspose.com/slides/ar/cpp/aspose.slides.slideshow/transitiontype/) للشريحة الثانية. افتح الملف المحفوظ في عارض عروض يدعم Morph لتشاهد التأثير أثناء العرض.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>();

auto firstSlide = presentation->get_Slide(0);
auto rectangle = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 100);
rectangle->get_TextFrame()->set_Text(u"Morph transition");

auto secondSlide = presentation->get_Slides()->AddClone(firstSlide);
auto movedRectangle = secondSlide->get_Shape(0);
movedRectangle->set_X(movedRectangle->get_X() + 100);
movedRectangle->set_Y(movedRectangle->get_Y() + 50);
movedRectangle->set_Width(movedRectangle->get_Width() - 200);
movedRectangle->set_Height(movedRectangle->get_Height() - 10);

secondSlide->get_SlideShowTransition()->set_Type(TransitionType::Morph);

presentation->Save(u"morph-transition.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **أنواع انتقال Morph**

يتحكم تعداد [TransitionMorphType](https://reference.aspose.com/slides/ar/cpp/aspose.slides.slideshow/transitionmorphtype/) في طريقة مطابقة Morph وتحريك المحتوى:

- [ByObject](https://reference.aspose.com/slides/ar/cpp/aspose.slides.slideshow/transitionmorphtype/) يعامل كل شكل ككائن كامل.
- [ByWord](https://reference.aspose.com/slides/ar/cpp/aspose.slides.slideshow/transitionmorphtype/) يحرك النص بمطابقة الكلمات عندما يكون ذلك ممكنًا.
- [ByChar](https://reference.aspose.com/slides/ar/cpp/aspose.slides.slideshow/transitionmorphtype/) يحرك النص بمطابقة الأحرف عندما يكون ذلك ممكنًا.

استدعِ [set_Type](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islideshowtransition/set_type/) مع Morph قبل الوصول إلى [get_Value](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islideshowtransition/get_value/). تُقدِّم القيمة بعد ذلك واجهة [IMorphTransition](https://reference.aspose.com/slides/ar/cpp/aspose.slides.slideshow/imorphtransition/)، التي يختار منها الأسلوب [set_MorphType](https://reference.aspose.com/slides/ar/cpp/aspose.slides.slideshow/imorphtransition/set_morphtype/) وضع المطابقة.

هذا المثال يفتح العرض التقديمي الذي تم إنشاؤه في القسم السابق ويضبط الشريحة الثانية لاستخدام حركة Morph على أساس الكلمات.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/IMorphTransition.h>
#include <DOM/SlideShowTransition/ITransitionValueBase.h>
#include <DOM/SlideShowTransition/TransitionMorphType.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"morph-transition.pptx");

if (presentation->get_Slides()->get_Count() >= 2)
{
    auto transition = presentation->get_Slide(1)->get_SlideShowTransition();
    transition->set_Type(TransitionType::Morph);

    auto morphTransition = AsCast<IMorphTransition>(transition->get_Value());
    if (morphTransition != nullptr)
    {
        morphTransition->set_MorphType(TransitionMorphType::ByWord);
        presentation->Save(u"morph-by-word.pptx", SaveFormat::Pptx);
    }
    else
    {
        Console::WriteLine(u"Morph transition options are unavailable.");
    }
}
else
{
    Console::WriteLine(u"The input presentation must contain at least two slides.");
}

presentation->Dispose();
```

## **تعيين تأثيرات الانتقال**

بعض الانتقالات تكشف عن خيارات إضافية، مثل الاتجاه أو ما إذا كان التأثير يبدأ من شاشة سوداء. تعتمد الخيارات المتاحة على نوع الانتقال المحدد. عيّن النوع أولًا، ثم استخدم الواجهة المناسبة التي تُرجِعها [get_Value](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islideshowtransition/get_value/).

التطبيق التالي يطبق انتقال Cut على الشريحة الأولى من `input.pptx`. يستدعي [set_FromBlack](https://reference.aspose.com/slides/ar/cpp/aspose.slides.slideshow/ioptionalblacktransition/set_fromblack/) مع `true` عبر [IOptionalBlackTransition](https://reference.aspose.com/slides/ar/cpp/aspose.slides.slideshow/ioptionalblacktransition/) لجعل الانتقال يبدأ من شاشة سوداء.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/IOptionalBlackTransition.h>
#include <DOM/SlideShowTransition/ITransitionValueBase.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto transition = presentation->get_Slide(0)->get_SlideShowTransition();
transition->set_Type(TransitionType::Cut);

auto cutTransition = AsCast<IOptionalBlackTransition>(transition->get_Value());
if (cutTransition != nullptr)
{
    cutTransition->set_FromBlack(true);
    presentation->Save(u"cut-from-black.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"Cut transition options are unavailable.");
}

presentation->Dispose();
```

## **الأسئلة المتكررة**

**هل يمكنني التحكم في سرعة تشغيل انتقال الشريحة؟**

نعم. يُفضَّل استخدام [set_Duration](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islideshowtransition/set_duration/) عندما تحتاج إلى مدة تأثير دقيقة بالمللي ثانية. استخدم [set_Speed](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islideshowtransition/set_speed/) عندما تكون فئة [TransitionSpeed](https://reference.aspose.com/slides/ar/cpp/aspose.slides.slideshow/transitionspeed/) محددة—Slow, Medium, أو Fast—كافية ولا توجد مدة صريحة. تُتحكم هذه الإعدادات في تأثير الانتقال بشكل مستقل عن تأخير التقدم التلقائي.

**هل يمكنني إرفاق صوت بالانتقال وجعله يتكرر؟**

نعم. عيّن صوتًا مضمنًا عبر [set_Sound](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islideshowtransition/set_sound/)، استدعِ [set_SoundMode](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islideshowtransition/set_soundmode/) مع StartSound من تعداد [TransitionSoundMode](https://reference.aspose.com/slides/ar/cpp/aspose.slides.slideshow/transitionsoundmode/)، وفَعِّل التكرار عبر [set_SoundLoop](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islideshowtransition/set_soundloop/). سيستمر الصوت في التكرار حتى يحدث حدث صوتي التالي في العرض.

**ما هي أسرع طريقة لتطبيق نفس الانتقال على جميع الشرائح؟**

قم بالتكرار عبر المجموعة التي تُرجعها طريقة [get_Slides](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/get_slides/) للعرض التقديمي، واستدعِ [set_Type](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islideshowtransition/set_type/) بنفس القيمة لكل شريحة. عيّن أي خيارات توقيت وتأثير داخل نفس الحلقة للحفاظ على سلوك موحد بين الشرائح.

**كيف يمكنني التحقق من أي انتقال مُعيّن حاليًا على شريحة؟**

استدعِ [get_Type](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islideshowtransition/get_type/) على الانتقال الذي تُرجعه طريقة [get_SlideShowTransition](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) الخاصة بالشريحة. تُرجع القيمة من تعداد [TransitionType](https://reference.aspose.com/slides/ar/cpp/aspose.slides.slideshow/transitiontype/); القيمة None تعني عدم وجود تأثير انتقال مطبق.