---
title: استرجاع وتحديث خصائص عرض العرض التقديمي في C++
linktitle: خصائص العرض
type: docs
weight: 80
url: /ar/cpp/presentation-view-properties/
keywords:
- خصائص العرض
- العرض العادي
- محتوى المخطط
- أيقونات المخطط
- تثبيت القاطع العمودي
- العرض الفردي
- حالة الشريط
- حجم البُعد
- تعديل تلقائي
- التكبير الافتراضي
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "اكتشف خصائص العرض في Aspose.Slides لـ C++ لتخصيص صيغ شرائح PPT و PPTX و ODP - ضبط التخطيطات ومستويات التكبير وإعدادات العرض."
---
## **المقدمة**

يتكون العرض العادي من ثلاث مناطق محتوى: الشريحة نفسها، ومنطقة محتوى جانبية، ومنطقة محتوى سفلية. الخصائص المتعلقة بموضع المناطق المختلفة تسمح للتطبيق بحفظ حالة عرضه في الملف، بحيث يكون العرض في الحالة نفسها عند إعادة فتح العرض.

تمت إضافة الطريقة [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) لتوفير الوصول إلى خصائص العرض العادي للعرض التقديمي.  

تمت إضافة الواجهات [INormalViewProperties](https://reference.aspose.com/slides/ar/cpp/aspose.slides/inormalviewproperties/)، [INormalViewRestoredProperties](https://reference.aspose.com/slides/ar/cpp/aspose.slides/inormalviewrestoredproperties/) وسلالتها، وكذلك تعداد [SplitterBarStateType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/splitterbarstatetype/).

## **حول INormalViewProperties**

يمثل خصائص العرض العادي.

تحدد الخاصية **ShowOutlineIcons** ما إذا كان يجب على التطبيق إظهار أيقونات المخطط التفصيلي عند عرض محتوى المخطط في أي من مناطق المحتوى في وضع العرض العادي.

تحدد الخاصية **SnapVerticalSplitter** ما إذا كان يجب أن ينتقل القاطع العمودي إلى الحالة المصغرة عندما تكون المنطقة الجانبية صغيرة بما فيه الكفاية.

تحدد الخاصية **PreferSingleView** ما إذا كان المستخدم يفضل رؤية منطقة محتوى واحدة تغطي النافذة بالكامل بدلاً من العرض العادي القياسي الذي يحتوي على ثلاث مناطق محتوى. إذا تم التمكين، قد يختار التطبيق عرض إحدى مناطق المحتوى في النافذة بأكملها.

تحدد الخصائص **VerticalBarState** و**HorizontalBarState** الحالة التي يجب أن يُظهر فيها شريط القاطع الرأسي أو الأفقي. الشريط القاطع الأفقي يفصل الشريحة عن منطقة المحتوى أسفل الشريحة، والشريط القاطع الرأسي يفصل الشريحة عن منطقة المحتوى الجانبية. القيم الممكنة هي: **SplitterBarStateType.Minimized**، **SplitterBarStateType.Maximized** و**SplitterBarStateType.Restored**.

تحدد الخصائص **RestoredLeft** و**RestoredTop** حجم منطقة الشريحة العلوية أو الجانبية في العرض العادي عندما يتم تطبيق القيمة **SplitterBarStateType.Restored** على **VerticalBarState** و**HorizontalBarState** على التوالي.

## **حول استعادة INormalViewProperties**

تحدد حجم منطقة الشريحة (العرض عندما تكون طفلاً لـ RestoredTop، الارتفاع عندما تكون طفلاً لـ RestoredLeft) في العرض العادي عندما تكون المنطقة بحجم مستعاد متغير (ليس مصغرة ولا مكبرة).

تحدد الخاصية **DimensionSize** حجم منطقة الشريحة (العرض عندما تكون طفلاً لـ RestoredTop، الارتفاع عندما تكون طفلاً لـ RestoredLeft).

تحدد الخاصية **AutoAdjust** ما إذا كان يجب أن تعوض منطقة المحتوى الجانبية الحجم الجديد عند تغيير حجم النافذة التي تحتوي على العرض داخل التطبيق.

يُظهر المثال أدناه كيفية الوصول إلى خصائص **ViewProperties.NormalViewProperties** لعروض تقديمية.

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

// استعادة خصائص العرض للعرض التقديمي
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_AutoAdjust(true);
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_DimensionSize(80.0f);
pres->get_ViewProperties()->get_NormalViewProperties()->set_ShowOutlineIcons(true);

pres->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```

## **تعيين قيمة التكبير الافتراضية**

يدعم Aspose.Slides لـ C++ الآن تعيين قيمة التكبير الافتراضية للعرض التقديمي بحيث يكون التكبير مُحددًا عند فتح العرض. يمكن تحقيق ذلك عن طريق تعيين [ViewProperties](https://reference.aspose.com/slides/ar/cpp/aspose.slides/viewproperties/) للعرض التقديمي. يمكن أيضًا تعيين خصائص عرض الشريحة و[ get_NotesViewProperties](https://reference.aspose.com/slides/ar/cpp/aspose.slides/viewproperties/get_notesviewproperties/) برمجياً. في هذا الموضوع، سنوضح مثالاً لكيفية تعيين خصائص العرض للعرض التقديمي في Aspose.Slides.

لضبط خصائص العرض، يرجى اتباع الخطوات التالية:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/)  
1. تعيين [Properties](https://reference.aspose.com/slides/ar/cpp/aspose.slides/viewproperties/) لعرض العرض التقديمي  
1. كتابة العرض التقديمي كملف PPTX  

في المثال المقدم أدناه، قمنا بتعيين قيمة التكبير لعرض الشريحة وعرض الملاحظات.

``` cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// تعيين خصائص العرض للعرض التقديمي
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // قيمة التكبير بالنسبة المئوية لعرض الشريحة
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // قيمة التكبير بالنسبة المئوية لعرض الملاحظات 

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```

## **تعيين تباعد الشبكة**

استخدم [Presentation::get_ViewProperties](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/get_viewproperties/) للوصول إلى إعدادات العرض على مستوى العرض التقديمي. تتيح الطريقتان [IViewProperties::get_GridSpacing](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iviewproperties/get_gridspacing/) و[IViewProperties::set_GridSpacing](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iviewproperties/set_gridspacing/) قراءة أو تعديل الفاصل الزمني للشبكة التحريرية الأساسية. ينطبق هذا الإعداد على كامل العرض التقديمي، وليس على شريحة واحدة. يتم تحديد تباعد الشبكة بالنقاط، حيث يساوي 72 نقطة بوصة واحدة. استخدم قيمة موجبة كما هو مطلوب في توثيق API.

المثال التالي يفتح ملف `demo.pptx` موجود مسبقًا، يطبع تباعد الشبكة الحالي، يضبط فاصل ربع بوصة، ثم يحفظ النتيجة.

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

الشبكة تختلف عن [drawing guides](/slides/ar/cpp/drawing-guides/). يتحكم تباعد الشبكة في فاصل منتظم، بينما الأدلة الرسومية هي خطوط محاذاة أفقية أو عمودية يتم وضعها يدويًا. إضافة أو نقل أو مسح الأدلة الرسومية لا يغيّر تباعد الشبكة.

كلا من الشبكة والأدلة الرسومية أدوات تحرير. لا يتم تصديرها كجزء من محتوى الشريحة في PDF أو الصور أو SVG أو عرض الشرائح. حفظ تباعد الشبكة لا يضمن أن المحرر سيظهر الشبكة: تعتمد رؤيتها أيضًا على تفضيلات المشاهد أو المحرر.

## **إظهار أو إخفاء التعليقات عند فتح عرض تقديمي**

استخدم [Presentation::get_ViewProperties](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/get_viewproperties/) للوصول إلى إعدادات العرض على مستوى العرض التقديمي. استخدم [IViewProperties::get_ShowComments](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iviewproperties/get_showcomments/) و[IViewProperties::set_ShowComments](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iviewproperties/set_showcomments/) لتخزين تفضيل ما إذا كان يجب إظهار التعليقات عند فتح العرض التقديمي في PowerPoint أو محرر متوافق آخر.

يتحكم هذا الإعداد فقط في تفضيل العرض المخزن. إنه لا يضيف أو يزيل أو يعدل أو يحل التعليقات. إخفاء التعليقات يحافظ على محتواها ومؤلفيها ومواقعها وردودها وحالاتها. راجع [Presentation Comments](/slides/ar/cpp/presentation-comments/) للعمليات التي تغير التعليقات نفسها.

المثال التالي يتطلب وجود ملف `comments.pptx` يحتوي على تعليقات. يطبع إعداد الرؤية الحالي، يطلب إخفاء التعليقات، ثم يحفظ ملف PPTX جديد دون إزالة أي تعليقات. كما يستخدم [IViewProperties::set_LastView](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iviewproperties/set_lastview/) مع [ViewType::SlideView](https://reference.aspose.com/slides/ar/cpp/aspose.slides/viewtype/) لتكوين عرض التحرير الأولي إلى جانب رؤية التعليقات.

```cpp
#include <system/console.h>
#include <DOM/IViewProperties.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <ViewType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"comments.pptx");
auto showComments = presentation->get_ViewProperties()->get_ShowComments();
System::Console::WriteLine(u"Current comment visibility: {0}", showComments);

presentation->get_ViewProperties()->set_ShowComments(NullableBool::False);
presentation->get_ViewProperties()->set_LastView(ViewType::SlideView);
presentation->Save(u"comments-hidden.pptx", SaveFormat::Pptx);
```

هذا الإعداد لا يحدد ما إذا كانت التعليقات مُدرجة في تصدير PDF أو HTML أو صورة أو ملاحظات أو نسخ مطبوعة. قم بتكوين الخيارات الخاصة بكل نوع تصدير على حدة.

## **الأسئلة الشائعة**

**لماذا لا تظهر الشبكة بعد إعادة فتح العرض التقديمي؟**

الملف يخزن تباعد الشبكة، لكن المحرر يتحكم في ما إذا كانت الشبكة معروضة. تحقق من إعدادات رؤية الشبكة في المحرر.

**هل مسح الأدلة الرسومية يغيّر تباعد الشبكة؟**

لا. الأدلة الرسومية وتباعد الشبكة إعدادات مستقلة. مسح الأدلة لا يغيّر الفاصل الزمني المخزن للشبكة.

**هل يمكنني تعيين إعدادات عرض مختلفة لأقسام مختلفة من العرض التقديمي؟**

يتم تعريف [إعدادات العرض](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/get_viewproperties/) على مستوى العرض التقديمي ([Normal View](https://reference.aspose.com/slides/ar/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/ar/cpp/aspose.slides/viewproperties/get_slideviewproperties/))، وليس لكل قسم على حدة، لذلك تُطبق مجموعة واحدة من المعلمات على المستند كله عند الفتح.

**هل يمكنني تعريف حالات عرض مختلفة لمستخدمين مختلفين؟**

لا. تُخزن الإعدادات في الملف وتُشارك بين الجميع. قد تلتزم التطبيقات التي تعرض الملف بتفضيلات المستخدم، لكن الملف نفسه يحتوي على مجموعة واحدة من خصائص العرض.

**هل يمكنني إعداد قالب يحتوي على خصائص عرض مسبقة بحيث تفتح العروض الجديدة بنفس الطريقة؟**

نعم. بما أن [خصائص العرض](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/get_viewproperties/) تُخزن على مستوى العرض التقديمي، يمكنك تضمينها في قالب وإنشاء مستندات جديدة منه بنفس تكوين العرض الأولي.