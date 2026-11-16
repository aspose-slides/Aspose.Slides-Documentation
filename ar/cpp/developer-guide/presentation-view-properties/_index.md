---
title: استخراج وتحديث خصائص عرض العرض التقديمي في C++
linktitle: خصائص العرض
type: docs
weight: 80
url: /ar/cpp/presentation-view-properties/
keywords:
- خصائص العرض
- العرض العادي
- محتوى المخطط
- أيقونات المخطط
- قسامة عمودية قابلة للإقفال
- عرض أحادي
- حالة الشريط
- حجم البُعد
- تعديل تلقائي
- تكبير افتراضي
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "استخدم Aspose.Slides للغة C++ لتكوين تخطيط العرض العادي، وتكبير الشرائح والملاحظات، وتباعد الشبكة، وإظهار التعليقات في عروض PowerPoint."
---
## **المقدمة**

في طريقة العرض العادية لبرنامج PowerPoint، تظهر الشريحة بين لوحة جانبية للصور المصغرة أو المخطط و لوحة ملاحظات أسفلها. تُتيح مكتبة Aspose.Slides للغة C++ تفضيلات التحرير المحفوظة للعرض عبر [Presentation::get_ViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/). تشمل هذه التفضيلات تخطيط اللوحات، مستويات التكبير، تباعد الشبكة، وإ visiblity التعليقات.

## **حول INormalViewProperties**

استخدم [get_NormalViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) للوصول إلى واجهة [INormalViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/). يتحكم [set_ShowOutlineIcons](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_showoutlineicons/) فيما إذا كانت الأيقونات تظهر بجانب عناوين الشرائح في المخطط. يسمح [set_SnapVerticalSplitter](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_snapverticalsplitter/) للوحة الجانبية بالانقضاض إلى حالتها المصغرة عندما يضيق المستخدم حجمها. يشير [set_PreferSingleView](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_prefersingleview/) إلى تفضيل عرض لوحة واحدة في النافذة الكاملة.

يتحكم [set_VerticalBarState](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_verticalbarstate/) بالمقسم بين اللوحة الجانبية والشريحة. يتحكم [set_HorizontalBarState](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_horizontalbarstate/) بالمقسم فوق لوحة الملاحظات. كلاهما يقبل قيمة من نوع [SplitterBarStateType](https://reference.aspose.com/slides/cpp/aspose.slides/splitterbarstatetype/) إما `Minimized` أو `Maximized` أو `Restored`.

## **حول استعادة INormalViewProperties**

عند استعادة المقسم، يوفر [get_RestoredLeft](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredleft/) الحجم المحفوظ للوحة الجانبية و[get_RestoredTop](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredtop/) الحجم المحفوظ للمنطقة العليا من الشريحة. كلاهما يُظهر [INormalViewRestoredProperties](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/). تقبل طريقة [set_DimensionSize](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/set_dimensionsize/) نسبة مئوية من 0 إلى 100، وتتحكم [set_AutoAdjust](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/set_autoadjust/) فيما إذا كان المحرر يضبط الحجم عندما يُعاد تحجيم النافذة.

هذا المثال يحدّث عرضاً تقديمياً موجوداً. يستعيد المقسم الأفقي، يضبط حجم المنطقة العليا من الشريحة التي يعرضها [get_RestoredTop](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredtop/) إلى 80% مع تمكين الضبط التلقائي، ويكبر المقسم العمودي. كما يُفعّل أيقونات المخطط عبر [set_ShowOutlineIcons](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_showoutlineicons/) لعرض المخطط.

```cpp
#include <DOM/INormalViewProperties.h>
#include <DOM/INormalViewRestoredProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <DOM/SplitterBarStateType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto normalView = presentation->get_ViewProperties()->get_NormalViewProperties();
normalView->set_HorizontalBarState(SplitterBarStateType::Restored);
normalView->set_VerticalBarState(SplitterBarStateType::Maximized);
auto restoredTop = normalView->get_RestoredTop();
restoredTop->set_AutoAdjust(true);
restoredTop->set_DimensionSize(80.0f);
normalView->set_ShowOutlineIcons(true);

presentation->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```

## **تعيين قيمة التكبير الافتراضية**

تخزن [get_SlideViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_slideviewproperties/) و[get_NotesViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_notesviewproperties/) إعدادات تكبير مستقلة للمحرر. هذه الإعدادات لا تؤثر على أبعاد الشرائح، تشغيل عرض الشرائح، أو دقة تصدير الصور.

هذا المثال يفتح عرضاً تقديمياً موجوداً ويُفعّل التحجيم التلقائي عبر [set_VariableScale](https://reference.aspose.com/slides/cpp/aspose.slides/icommonslideviewproperties/set_variablescale/) لتناسب الشريحة نافذة التحرير. بالنسبة لصفحة الملاحظات، يُعطّل التحجيم التلقائي ويستخدم [set_Scale](https://reference.aspose.com/slides/cpp/aspose.slides/icommonslideviewproperties/set_scale/) لتحديد تكبير ثابت بنسبة 80%.

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto viewProperties = presentation->get_ViewProperties();
viewProperties->get_SlideViewProperties()->set_VariableScale(true);
auto notesView = viewProperties->get_NotesViewProperties();
notesView->set_VariableScale(false);
notesView->set_Scale(80);

presentation->Save(u"zoom.pptx", SaveFormat::Pptx);
```

## **تعيين تباعد الشبكة**

تحدد [set_GridSpacing](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_gridspacing/) المسافة بين خطوط شبكة التحرير عبر العرض التقديمي بأكمله. تأخذ قيمة موجبة بالنقاط، مع 72 نقطة في البوصة. هذا المثال يطبع التباعد الحالي في عرض تقديمي موجود ويُحفظ شبكة ربع بوصة عبر ضبط الفاصل إلى 18 نقطة.

```cpp
#include <system/console.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto viewProperties = presentation->get_ViewProperties();
auto gridSpacing = viewProperties->get_GridSpacing();
System::Console::WriteLine(u"Current grid spacing: {0} points", gridSpacing);

viewProperties->set_GridSpacing(18.0f);

presentation->Save(u"grid-spacing.pptx", SaveFormat::Pptx);
```

تتكرر الشبكة على فاصل ثابت. تُظهر [Drawing guides](/slides/ar/cpp/drawing-guides/) مواقع أفقية أو عمودية منفردة. كلاهما مساعدات تحرير وتظهر فقط في المحررات التي تعرضهما. لا تُظهر عروض الشرائح وتصديرات PDF أو الصور أو SVG هذه الأدلة.

## **إظهار أو إخفاء التعليقات عند فتح عرض تقديمي**

يخزن [set_ShowComments](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_showcomments/) تفضيلاً تستخدمه المحررات المتوافقة عند فتح العرض التقديمي. لعرض تقديمي موجود يحتوي على تعليقات، يطبع هذا المثال الإعداد الحالي ويحفظ نسخة مع إخفاء التعليقات. كما يستدعي [set_LastView](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_lastview/) مع [ViewType::SlideView](https://reference.aspose.com/slides/cpp/aspose.slides/viewtype/) لتفتح النسخة في عرض الشريحة.

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

auto viewProperties = presentation->get_ViewProperties();
auto showComments = viewProperties->get_ShowComments();
System::Console::WriteLine(u"Current comment visibility: {0}", showComments);

viewProperties->set_ShowComments(NullableBool::False);
viewProperties->set_LastView(ViewType::SlideView);

presentation->Save(u"comments-hidden.pptx", SaveFormat::Pptx);
```

إخفاء التعليقات يحافظ على نصها، مؤلفيها، مواقعها، ردودها، وحالاتها. لتغيير التعليقات نفسها، راجع [Presentation Comments](/slides/ar/cpp/presentation-comments/). تتحكم إعدادات التصدير فيما إذا كانت التعليقات تظهر في PDF أو HTML أو الصور أو الملاحظات أو النشرات.

## **الأسئلة المتداولة**

**لماذا تُخفى الشبكة عند إعادة فتح العرض التقديمي؟**

يخزن العرض التقديمي فاصل الشبكة. لعرض الشبكة، فعّل رؤية الشبكة في المحرر.

**هل يؤدي مسح الأدلة المرسومة إلى تغيير تباعد الشبكة؟**

لا. إضافة دليل أو تحريكها أو مسحها لا يغيّر فاصل الشبكة.

**هل يمكن لأقسام مختلفة من العرض التقديمي أن تحتوي على إعدادات عرض مختلفة؟**

لا. يطبق [Presentation::get_ViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/) على العرض التقديمي بأكمله.

**هل يمكنني حفظ إعدادات عرض مختلفة لمستخدمين مختلفين؟**

يحفظ الملف مجموعة واحدة من خصائص العرض للجميع. قد يطبق المحرر أيضًا تفضيلات محلية للمستخدم.

**هل يمكنني حفظ إعدادات العرض في قالب؟**

نعم. العروض التقديمية المنشأة من القالب ترث إعدادات العرض المحفوظة.