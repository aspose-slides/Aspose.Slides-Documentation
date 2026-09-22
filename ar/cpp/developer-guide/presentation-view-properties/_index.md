---
title: استرجاع وتحديث خصائص عرض العرض التقديمي في C++
linktitle: خصائص العرض
type: docs
weight: 80
url: /ar/cpp/presentation-view-properties/
keywords:
- خصائص العرض
- العرض العادي
- محتوى المخطط التفصيلي
- أيقونات المخطط التفصيلي
- تثبيت القاطع العمودي
- عرض أحادي
- حالة الشريط
- حجم البُعد
- تعديل تلقائي
- التكبير الافتراضي
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "اكتشف خصائص عرض Aspose.Slides لـ C++ لتخصيص صيغ PPT و PPTX و ODP—ضبط التخطيطات ومستويات التكبير وإعدادات العرض."
---
## **المقدمة**

العرض العادي يتكون من ثلاث مناطق محتوى: الشريحة نفسها، ومنطقة محتوى جانبية، ومنطقة محتوى سفلية. الخصائص المتعلقة بتموضع المناطق المختلفة للمحتوى. تتيح هذه المعلومات للتطبيق حفظ حالة العرض إلى الملف، بحيث عندما يُعاد الفتح يكون العرض في نفس الحالة كما كان عند حفظ العرض آخر مرة.

تم إضافة الطريقة [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) لتوفير إمكانية الوصول إلى خصائص العرض العادي للعرض التقديمي.

تم إضافة الواجهات [INormalViewProperties](https://reference.aspose.com/slides/ar/cpp/aspose.slides/inormalviewproperties/)، [INormalViewRestoredProperties](https://reference.aspose.com/slides/ar/cpp/aspose.slides/inormalviewrestoredproperties/) وواجهاتها التابعة، وكذلك تعداد [SplitterBarStateType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/splitterbarstatetype/) .

## **حول INormalViewProperties**

يمثل خصائص العرض العادي.

خاصية **ShowOutlineIcons** تحدد ما إذا كان يجب على التطبيق إظهار الأيقونات عند عرض محتوى المخطط التفصيلي في أيٍ من مناطق المحتوى في وضع العرض العادي.

خاصية **SnapVerticalSplitter** تحدد ما إذا كان يجب على القاطع العمودي الانتقال إلى حالة مصغرة عندما تكون المنطقة الجانبية صغيرة بما فيه الكفاية.

خاصية **PreferSingleView** تحدد ما إذا كان المستخدم يفضّل رؤية منطقة محتوى واحدة ممتدة على كامل النافذة بدلاً من العرض العادي القياسي الذي يحتوي على ثلاث مناطق محتوى. إذا تم تمكينها، قد يختار التطبيق عرض إحدى مناطق المحتوى في النافذة بأكملها.

الخاصيتان **VerticalBarState** و **HorizontalBarState** تحددان الحالة التي يجب أن يُظهر فيها شريط القاطع الأفقي أو العمودي. الشريط القاطع الأفقي يفصل الشريحة عن منطقة المحتوى أسفل الشريحة، والشريط القاطع العمودي يفصل الشريحة عن منطقة المحتوى الجانبية. القيم المحتملة هي: **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized** و **SplitterBarStateType.Restored**.

الخاصيتان **RestoredLeft** و **RestoredTop** تحددان حجم منطقة الشريحة العلوية أو الجانبية في العرض العادي، عندما تُطبق قيمة **SplitterBarStateType.Restored** على **VerticalBarState** و **HorizontalBarState** على التوالي.

## **حول استعادة INormalViewProperties**

تحدد حجم منطقة الشريحة (العرض عندما تكون تابعًا لـ RestoredTop، الارتفاع عندما تكون تابعًا لـ RestoredLeft) في العرض العادي، عندما تكون المنطقة بحجم مستعاد متغير (ليس مصغرًا ولا مكبرًا).

خاصية **DimensionSize** تحدد حجم منطقة الشريحة (العرض عندما تكون تابعًا لـ restoredTop، الارتفاع عندما تكون تابعًا لـ restoredLeft).

خاصية **AutoAdjust** تحدد ما إذا كان يجب على حجم منطقة المحتوى الجانبية التعويض عن الحجم الجديد عند تغيير حجم النافذة التي تحتوي العرض داخل التطبيق.

يوضح المثال أدناه كيف يمكنك الوصول إلى خصائص **ViewProperties.NormalViewProperties** لعرض تقديمي.

``` cpp
#include <DOM/INormalViewProperties.h>
#include <DOM/INormalViewRestoredProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <DOM/SplitterBarStateType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"demo.pptx");
pres->get_ViewProperties()->get_NormalViewProperties()->set_HorizontalBarState(SplitterBarStateType::Restored);
pres->get_ViewProperties()->get_NormalViewProperties()->set_VerticalBarState(SplitterBarStateType::Maximized);

// استعادة خصائص عرض العرض التقديمي
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_AutoAdjust(true);
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_DimensionSize(80.0f);
pres->get_ViewProperties()->get_NormalViewProperties()->set_ShowOutlineIcons(true);

pres->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```

## **تعيين قيمة التكبير الافتراضية**

يدعم Aspose.Slides for C++ الآن تعيين قيمة التكبير الافتراضية للعرض التقديمي بحيث عندما يُفتح العرض يتم تعيين التكبير مسبقًا. يمكن القيام بذلك عن طريق تعيين [ViewProperties](https://reference.aspose.com/slides/ar/cpp/aspose.slides/viewproperties/) لعرض تقديمي. يمكن تعيين خصائص عرض الشريحة وكذلك [get_NotesViewProperties](https://reference.aspose.com/slides/ar/cpp/aspose.slides/viewproperties/get_notesviewproperties/) برمجيًا. في هذا الموضوع، سنرى مع مثال كيفية تعيين خصائص العرض لعرض تقديمي في Aspose.Slides.

لتعيين خصائص العرض، يرجى اتباع الخطوات التالية:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) 
1. تعيين [Properties](https://reference.aspose.com/slides/ar/cpp/aspose.slides/viewproperties/) العرض للعرض التقديمي
1. كتابة العرض التقديمي كملف PPTX

في المثال أدناه، قمنا بتعيين قيمة التكبير لعرض الشريحة وكذلك عرض الملاحظات.

``` cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// تعيين خصائص عرض العرض التقديمي
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // قيمة التكبير بالنسبة المئوية لعرض الشريحة
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // قيمة التكبير بالنسبة المئوية لعرض الملاحظات

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```

## **تعيين تباعد الشبكة**

استخدم [Presentation::get_ViewProperties](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/get_viewproperties/) للوصول إلى إعدادات العرض على مستوى العرض التقديمي. طرق [IViewProperties::get_GridSpacing](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iviewproperties/get_gridspacing/) و[IViewProperties::set_GridSpacing](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iviewproperties/set_gridspacing/) تقرأ أو تغير الفاصل الزمني للشبكة التحريرية الأساسية. ينطبق هذا الإعداد على كامل العرض التقديمي، وليس على شريحة فردية. يتم تحديد تباعد الشبكة بالنقاط، حيث أن 72 نقطة تساوي بوصة واحدة. استخدم قيمة موجبة، كما هو مطلوب في وثائق API.

يفتح المثال التالي ملف `demo.pptx` موجودًا، يطبع تباعد الشبكة الحالي، يضبط فاصلًا ربع بوصة، ويحفظ النتيجة.

```cpp
#include <system/console.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto gridSpacing = presentation->get_ViewProperties()->get_GridSpacing();
System::Console::WriteLine(u"Current grid spacing: {0} points", gridSpacing);

presentation->get_ViewProperties()->set_GridSpacing(18.0f);
presentation->Save(u"grid-spacing.pptx", SaveFormat::Pptx);
```

الشبكة تختلف عن [دليل الرسم](/slides/ar/cpp/drawing-guides/). يتحكم تباعد الشبكة في فاصل منتظم، بينما تكون أدلة الرسم خطوط محاذاة أفقية أو عمودية موضعية بشكل فردي. إضافة أو نقل أو مسح أدلة الرسم لا يغيّر تباعد الشبكة.

كل من الشبكة وأدلة الرسم هي مساعدات تحرير. لا يتم عرضها كمحتوى شريحة في PDF أو الصور أو SVG أو عرض الشرائح. تخزين تباعد الشبكة لا يضمن أن يعرضه المحرر: تعتمد رؤيتها أيضًا على تفضيلات المشاهد أو المحرر.

## **الأسئلة المتكررة**

**لماذا لا تكون الشبكة مرئية بعد إعادة فتح العرض التقديمي؟**

يقوم الملف بتخزين تباعد الشبكة، لكن المحرر يتحكم فيما إذا كانت الشبكة معروضة. تحقق من إعدادات رؤية الشبكة في المحرر.

**هل يؤدي مسح أدلة الرسم إلى تغيير تباعد الشبكة؟**

لا. أدلة الرسم وتباعد الشبكة إعدادات مستقلة. مسح الأدلة يترك الفاصل المخزن للشبكة بدون تغيير.

**هل يمكنني تعيين إعدادات عرض مختلفة لأقسام مختلفة من العرض التقديمي؟**

يتم تعريف [إعدادات العرض](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/get_viewproperties/) على مستوى العرض التقديمي ([العرض العادي](https://reference.aspose.com/slides/ar/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[عرض الشريحة](https://reference.aspose.com/slides/ar/cpp/aspose.slides/viewproperties/get_slideviewproperties/))، وليس لكل قسم، لذا مجموعة واحدة من المعلمات تنطبق على كامل المستند عند فتحه.

**هل يمكنني تحديد حالات عرض مختلفة لمستخدمين مختلفين مسبقًا؟**

لا. يتم تخزين الإعدادات في الملف وتُشارك. قد تحترم تطبيقات العرض تفضيلات المستخدم، لكن الملف نفسه يحتوي على مجموعة واحدة من خصائص العرض.

**هل يمكنني إعداد قالب بخصائص عرض معرفة مسبقًا بحيث تفتح العروض التقديمية الجديدة بنفس الطريقة؟**

نعم. لأن [خصائص العرض](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/get_viewproperties/) تُخزن على مستوى العرض التقديمي، يمكنك تضمينها في قالب وإنشاء مستندات جديدة منه بنفس تكوين العرض الأولي.