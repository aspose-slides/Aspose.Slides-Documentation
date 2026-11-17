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
- انتقال Morph
- نوع الانتقال
- تأثير الانتقال
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "قم بتطبيق انتقالات الشرائح، وتكوين التقدم التلقائي للشرائح، وتخصيص انتقال Morph وغيرها من تأثيرات الانتقال باستخدام Aspose.Slides for C++."
---
## **نظرة عامة**

تتحكم انتقالات الشرائح في طريقة ظهور الشرائح أثناء عرض الشرائح. باستخدام Aspose.Slides for C++، يمكنك اختيار تأثير انتقال لكل شريحة، تكوين التقدم عن طريق النقر بالماوس أو المؤقت، وضبط الخيارات الخاصة بكل تأثير. يستخدم هذا المقال أمثلة C++ لتطبيق الانتقالات، تعيين مدد الانتقال الدقيقة، إدارة توقيت الشرائح، وإنشاء انتقال Morph بين شريحتين. تظهر الأمثلة أيضًا كيفية حفظ الإعدادات في ملف PPTX.

## **إضافة انتقال شريحة**

لتطبيق انتقال، حمّل عرضًا تقديميًا باستخدام الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) والوصول إلى إعدادات انتقال الشريحة عبر [get_SlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideshowtransition/). استدعِ [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) بقيمة من تعداد [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/)، ثم احفظ العرض التقديمي.

تطبق الشفرة التالية انتقال Circle على الشريحة الأولى وانتقال Comb على الشريحة الثانية. استخدم ملف `input.pptx` يحتوي على شريحتين على الأقل.

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

## **Wheel Transition**

طريقة [set_Spokes](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/iwheeltransition/set_spokes/) في [IWheelTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/iwheeltransition/) تتحكم في عدد القطاعات الشعاعية التي تكشف الشريحة الهدف. استدعِ [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) مع Wheel من تعداد [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) قبل الوصول إلى [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_value/) كـ [IWheelTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/iwheeltransition/).

هذه الشفرة تنشئ زوجين متماثلين من الشرائح: شريحة سوداء تليها شريحة بها مستطيل ذهبي. تستخدم الشرائح الهدف عدد أسنان 1 و 8، مع ضبط السرعة نفسها عبر [set_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_speed/) ومدة صريحة قدرها 8 000 مللي ثانية عبر [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) لجعل الفرق سهل الملاحظة.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/IBackground.h>
#include <DOM/BackgroundType.h>
#include <DOM/IFillFormat.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideShowTransition/IWheelTransition.h>
#include <DOM/SlideShowTransition/ITransitionValueBase.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <DOM/SlideShowTransition/TransitionSpeed.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <drawing/size_f.h>
#include <system/object_ext.h>
#include <cstdint>

using namespace System;
using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>();
auto slideWidth = presentation->get_SlideSize()->get_Size().get_Width();
auto slideHeight = presentation->get_SlideSize()->get_Size().get_Height();

auto blackSlide = presentation->get_Slide(0);
blackSlide->get_Shapes()->Clear();
blackSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
blackSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
blackSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

auto destinationSlide = presentation->get_Slides()->AddClone(blackSlide);
auto rectangle = destinationSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, slideWidth, slideHeight);
rectangle->get_FillFormat()->set_FillType(FillType::Solid);
rectangle->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gold());
rectangle->get_TextFrame()->set_Text(u"Wheel transition");

presentation->get_Slides()->AddClone(blackSlide);
presentation->get_Slides()->AddClone(destinationSlide);

const uint32_t spokeCounts[] = { 1, 8 };
for (auto i = 0; i < 2; i++)
{
    auto transition = presentation->get_Slide(i * 2 + 1)->get_SlideShowTransition();
    transition->set_Type(TransitionType::Wheel);
    auto wheelTransition = ExplicitCast<IWheelTransition>(transition->get_Value());
    wheelTransition->set_Spokes(spokeCounts[i]);
    transition->set_Speed(TransitionSpeed::Slow);
    transition->set_Duration(8000);
}

presentation->Save(u"wheel-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

افتح العرض الناتج في PowerPoint وشغّل عرض الشرائح. انتقل من الشريحة 1 إلى الشريحة 2، ثم من الشريحة 3 إلى الشريحة 4. في تشغيل PowerPoint، تُظهر عددة الأسنان 1 الشريحة بتمرير واحد مع عقارب الساعة؛ وتُظهر عددة 8 الشريحة عبر ثمان قطاعات شعاعية في آن واحد. المحتوى والوقت متطابقان، لذا الاختلاف هو عدد قطاعات الإظهار.

## **إضافة انتقال شريحة متقدم**

يمكنك تكوين مدة بقاء الشريحة على الشاشة وما إذا كان النقر بالماوس يتقدم بالعرض. تتحكم الطرق التالية في هذا السلوك:

- [set_AdvanceOnClick](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) يتيح للمشاهد التقدم بالنقر.
- [set_AdvanceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceafter/) يفعّل التقدم التلقائي.
- [set_AdvanceAfterTime](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) يحدد التأخير قبل التقدم التلقائي، بالمللي ثانية.

مكّن كلًا من التقدم بالنقر والوقت للسماح للمشاهد بالتحرك بالنقر أو الانتظار للمؤقت. لاستخدام المؤقت فقط، استدعِ [set_AdvanceOnClick](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) مع `false`. يتحكم التأخير فى متى يتقدم عرض الشرائح؛ ولا يحدد مدة تأثير الانتقال البصري.

تُعيّن الشفرة التالية تأثيرات مختلفة للشرائح الثلاث الأولى وتفعّل التقدم التلقائي بعد 3، 5، و 7 ثوانٍ على التوالي. يمكن للنقرات أيضًا تقدّم هذه الشرائح. استخدم ملف `input.pptx` يحتوي على ثلاث شرائح على الأقل.

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

للتحقق ما إذا كان التقدم المؤقت مفعلاً، استدعِ [get_AdvanceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_advanceafter/). التخزين المؤقت وحده لا يشير إلى أن المؤقت نشط.

الشفرة التالية تفتح الملف المحفوظ أعلاه، تُبلغ عن كل مؤقت مفعّل، وتُعطل التقدم التلقائي للشرائح التي لها تأخير أكبر من ثانيتين. تُفعّل النقرات لتلك الشرائح وتُحفظ الإعدادات المحدّثة.

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

## **التحكم بدقة في توقيت الانتقال**

استدعِ [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) لتحديد الطول الدقيق لتأثير الانتقال بالمللي ثانية. تُظهر طريقة الشريحة [get_SlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) هذه الإعدادات عبر [ISlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/):

| الطريقة | الغرض |
| --- | --- |
| [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) | يحدد مدة تأثير الانتقال نفسه، بالمللي ثانية. |
| [set_AdvanceAfterTime](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) | يحدد التأخير قبل تقدم الشريحة تلقائيًا، بالمللي ثانية. استدعِ [set_AdvanceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceafter/) مع `true` لتفعيل هذا المؤقت. |
| [set_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_speed/) | يختار فئة سرعة معرفة مسبقًا من تعداد [TransitionSpeed](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionspeed/): Slow، Medium، أو Fast. تُستخدم عندما لا يتم تحديد مدة صريحة. |

[set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) يتحكم فقط في تأثير الانتقال؛ ولا يحدد مدة بقاء الشريحة مرئية. اضبط تأخير التقدم التلقائي بشكل منفصل. عندما لا تُحدد مدة صريحة، يحدد Aspose.Slides مدة التأثير بناءً على نوع الانتقال والقيمة التي تُعيدها [get_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_speed/).

<!-- visual-explanation:slide-transition:start -->
[![Separate bars identify the 750-ms transition duration and 5,000-ms automatic advancement setting.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*المثال المشترك يعطي كل شريحة انتقال Fade مدته 750 مللي ثانية ويُمكّن التقدم التلقائي بعد 5 000 مللي ثانية. مدة الانتقال تتحكم في التأثير؛ والتقدم يتحكم متى تُغادر الشريحة. هذه الأشرطة تمثّل إعدادات تخطيطية، ليست خطًا زمنيًا مقاسًا.*
<!-- visual-explanation:slide-transition:end -->

### **تطبيق نفس المدة على كل شريحة**

لضبط وتيرة ثابتة، طبّق نفس التأثير والمدة الدقيقة على كل شريحة. تُحمّل الشفرة التالية `input.pptx`، تختار Fade من تعداد [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/)، وتُعطي كل انتقال مدة 750 مللي ثانية. تُفعّل التقدم التلقائي بعد 5 000 مللي ثانية وتُعطل التقدم بالنقر، ثم تحفظ النتيجة كملف PPTX.

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

    // تكوين التقدم التلقائي بشكل مستقل عن مدة التأثير.
    transition->set_AdvanceAfter(true);
    transition->set_AdvanceAfterTime(5000);
    transition->set_AdvanceOnClick(false);
}

presentation->Save(u"precise-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **تعيين مدد مختلفة للشرائح الفردية**

يمكن للشرائح المختلفة استخدام مدد تأثير مختلفة. على سبيل المثال، استخدم انتقالًا قصيرًا لشريحة العنوان وانتقالًا أطول لمقدمة القسم. تُعيّن الشفرة التالية 500 مللي ثانية للشريحة الأولى و 1 200 مللي ثانية للشريحة الثانية. استخدم ملف `input.pptx` يحتوي على شريحتين على الأقل.

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

عند إعداد [animated GIF](/slides/ar/cpp/convert-powerpoint-to-animated-gif/)، [HTML5 presentation](/slides/ar/cpp/export-to-html5/)، أو [video](/slides/ar/cpp/convert-powerpoint-to-video/)، حدد مدد الانتقال الدقيقة قبل التصدير لمزامنة الوتيرة المقصودة. على سبيل المثال، استخدم تلاشي 600 مللي ثانية بين المشاهد، واضبط تأخير تقدم كل شريحة بشكل منفصل للسماح بالوقت للسرد أو المحتوى.

بالنسبة للـ GIF والفيديو، تنسّق معدل الإطارات مع مدة التأثير: 600 مللي ثانية تعادل 18 إطارًا بمعدل 30 إطارًا في الثانية. في HTML5، فعّل الانتقالات المتحركة في إعدادات التصدير. تحقق من تأثيرات وتوقيتات الصيغة المستهدفة، وعاين النتيجة للتأكد من التزامن.

### **قراءة مدة انتقال موجودة**

استدعِ [get_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_duration/) قبل تعديل الانتقال لتحديد ما إذا كانت قيمة صريحة محفوظة. القيمة `-1` تعني عدم وجود مدة صريحة؛ والقيمة غير السالبة تحدد المدة المخزنة بالمللي ثانية. القيمة غير المضبوطة ليست مدة التشغيل المحسوبة: يستخدم Aspose.Slides نوع الانتقال والقيمة التي تُعيدها [get_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_speed/) لتحديد تلك المدة. قد يهيئ تعيين نوع الانتقال مدةً، لذا افحص الإعدادات الأصلية أولًا.

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

## **Morph Transition**

يُحاكي انتقال Morph تغييرات العناصر بين الشرائح المتتالية. لإنشاء تأثير Morph بسيط، انسخ شريحة، حرّك أو غيّر حجم عنصر على النسخة، وطبّق انتقال Morph على الشريحة الثانية. يمنح ذلك العناصر المطابقة إمكانية التحريك بين حالتها الأصلية والمعدلة.

الشفرة التالية تنشئ شريحة بها مستطيل نص، تُنسخ الشريحة، وتغيّر موضع وحجم المستطيل على النسخة. ثم تختار Morph من تعداد [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) للشفرة الثانية. افتح الملف المحفوظ في عارض عروض يدعم Morph لمشاهدة التأثير أثناء عرض الشرائح.

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

## **أنواع Morph Transition**

تتحكم تعداد [TransitionMorphType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) في طريقة مطابقة وتحريك المحتوى:

- [ByObject](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) يعامل كل شكل ككائن كامل.
- [ByWord](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) يُحرك النص بمطابقة الكلمات حيثما أمكن.
- [ByChar](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) يُحرك النص بمطابقة الأحرف حيثما أمكن.

استدعِ [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) مع Morph قبل الوصول إلى [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_value/). ثم توفر القيمة واجهة [IMorphTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/imorphtransition/) التي تُحدد طريقة [set_MorphType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/imorphtransition/set_morphtype/) المطابقة.

الشفرة التالية تفتح العرض الذي تم إنشاؤه في القسم السابق وتُضبط الشريحة الثانية لاستخدام تحريك Morph على أساس الكلمات.

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

بعض الانتقالات تكشف عن خيارات إضافية، مثل الاتجاه أو ما إذا كان التأثير يبدأ من شاشة سوداء. الخيارات المتاحة تعتمد على نوع الانتقال المختار. اضبط النوع أولًا، ثم استخدم الواجهة المناسبة التي تُعيدها [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_value/).

الشفرة التالية تطبق انتقال Cut على الشريحة الأولى من `input.pptx`. تستدعي [set_FromBlack](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/ioptionalblacktransition/set_fromblack/) مع `true` عبر [IOptionalBlackTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/ioptionalblacktransition/) لتبدأ الانتقال من شاشة سوداء.

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

## **FAQ**

**هل يمكنني التحكم في سرعة تشغيل انتقال الشريحة؟**

نعم. فضلًا عن استخدام [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) عندما تحتاج إلى مدة تأثير دقيقة بالمللي ثانية. استخدم [set_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_speed/) عندما تكون فئة سرعة معرفة مسبقًا من تعداد [TransitionSpeed](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionspeed/)—Slow، Medium، أو Fast—كافية ولا يتم تحديد مدة صريحة. تتحكم هذه الإعدادات في تأثير الانتقال بشكل مستقل عن تأخير التقدم التلقائي.

**هل يمكنني إرفاق صوت بالانتقال وجعله يتكرر؟**

نعم. عيّن صوتًا مضمّنًا عبر [set_Sound](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_sound/)، استدعِ [set_SoundMode](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_soundmode/) مع StartSound من تعداد [TransitionSoundMode](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionsoundmode/)، ومكّن التكرار عبر [set_SoundLoop](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_soundloop/). يتكرر الصوت حتى حدث صوتي لاحق في عرض الشرائح.

**ما هي أسرع طريقة لتطبيق نفس الانتقال على جميع الشرائح؟**

مرّر عبر المجموعة التي تُرجعها طريقة [get_Slides](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slides/) في العرض، واستدعِ [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) بنفس القيمة لكل شريحة. اضبط أي إعدادات توقيت وتأثير داخل الحلقة نفسها للحفاظ على سلوك موحد عبر جميع الشرائح.

**كيف يمكنني التحقق من الانتقال المحدد حاليًا على شريحة؟**

استدعِ [get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_type/) على الانتقال الذي تُرجعه طريقة [get_SlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) للشريحة. تُعيد قيمة من تعداد [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/); القيمة None تعني عدم تطبيق أي تأثير انتقال.