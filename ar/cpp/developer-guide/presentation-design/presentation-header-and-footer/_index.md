---
title: إدارة رؤوس وتذييلات العرض التقديمي في C++
linktitle: الرأس والتذييل
type: docs
weight: 140
url: /ar/cpp/presentation-header-and-footer/
keywords:
- رأس
- نص الرأس
- تذييل
- نص التذييل
- تعيين الرأس
- تعيين التذييل
- نشرة
- ملاحظات
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "تعلم كيفية إدارة عناصر التذييل، التاريخ/الوقت، رقم الشريحة، والرأس في الشرائح، صفحات الملاحظات، والنشرات باستخدام Aspose.Slides للـ C++."
---
## **نظرة عامة**

يستخدم PowerPoint عناصر نائب مختلفة للرأس والتذييل بناءً على نوع الصفحة. يتيح Aspose.Slides للـ C++ التحكم في النص ورؤية هذه العناصر النائبة عبر واجهات مدير الرأس/التذييل.

العناصر النائبة المتاحة تعتمد على النطاق:

| النطاق | الرأس | التذييل | التاريخ/الوقت | رقم الشريحة/الصفحة |
|---|---|---|---|---|
| شريحة عادية | لا | نعم | نعم | نعم |
| قالب ملاحظات | نعم | نعم | نعم | نعم |
| شريحة ملاحظات | نعم | نعم | نعم | نعم |
| قالب توزيع | نعم | نعم | نعم | نعم |

الشريحة العادية في العرض التقديمي لا تحتوي على عنصر نائب للرأس. تتوفر عناصر الرأس في صفحات الملاحظات والتوزيع. بالنسبة للشرائح العادية، استخدم عناصر التذييل، التاريخ/الوقت، ورقم الشريحة بدلاً من ذلك.

نطاق التغيير يعتمد على المدير الذي تستخدمه. يتحكم واجهة [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islideheaderfootermanager/) في شريحة عادية واحدة. تتحكم واجهة [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/inotesslideheaderfootermanager/) في شريحة ملاحظات واحدة. يمكن لمديري القالب والتخطيط أيضًا نشر الإعدادات إلى الشرائح التابعة، بينما تتحكم واجهة [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imasterhandoutslideheaderfootermanager/) في قالب التوزيع.

## **تعيين التذييل، التاريخ/الوقت، وأرقام الشرائح على الشرائح العادية**

بالنسبة للشرائح العادية، سير العمل الأساسي هو الوصول إلى مدير الرأس/التذييل لكل شريحة، تعيين نص التذييل والتاريخ/الوقت، تمكين العناصر النائبة المطلوبة، ثم حفظ العرض التقديمي. يتم توليد أرقام الشرائح تلقائيًا، لذلك يلزمك فقط التحكم في ظهورها.

استخدم [`SetFooterText`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootertext/) و[`SetDateTimeText`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibaseslideheaderfootermanager/setdatetimetext/) لتعيين النص، واستخدم [`SetFooterVisibility`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootervisibility/)، [`SetDateTimeVisibility`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibaseslideheaderfootermanager/setdatetimevisibility/)، و[`SetSlideNumberVisibility`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibaseslideheaderfootermanager/setslidenumbervisibility/) لإظهار العناصر النائبة المقابلة.

المثال التالي يطبق نفس التذييل، نص التاريخ/الوقت، ورؤية رقم الشريحة على جميع الشرائح العادية:

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideHeaderFooterManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

for (const auto& slide : System::IterateOver(presentation->get_Slides()))
{
    auto headerFooterManager = slide->get_HeaderFooterManager();

    headerFooterManager->SetFooterText(u"Company Confidential");
    headerFooterManager->SetFooterVisibility(true);

    headerFooterManager->SetDateTimeText(u"Date and time text");
    headerFooterManager->SetDateTimeVisibility(true);

    headerFooterManager->SetSlideNumberVisibility(true);
}

presentation->Save(u"presentation_with_slide_footers.pptx", SaveFormat::Pptx);
```

إذا كنت بحاجة لتحديث شريحة واحدة فقط، عُد إلى تلك الشريحة مباشرة عبر [`Presentation::get_Slide`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/get_slide/) بدلاً من iterating عبر مجموعة الشرائح بالكامل.

## **تعيين الرؤوس والتذييلات على قالب الملاحظات**

يحدد قالب الملاحظات تنسيقًا مشتركًا وسلوك العناصر النائبة لصفحات الملاحظات. استخدم واجهة [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imasternotesslideheaderfootermanager/) عندما تريد تغيير قالب الملاحظات نفسه فقط.

المثال التالي يضع رأسًا، تذييلًا، ونص تاريخ/وقت على قالب الملاحظات ويجعل جميع العناصر النائبة المدعومة مرئية في ذلك القالب:

```cpp
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideHeaderFooterManager.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();

if (masterNotesSlide != nullptr)
{
    auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

    headerFooterManager->SetHeaderText(u"Notes header");
    headerFooterManager->SetHeaderVisibility(true);

    headerFooterManager->SetFooterText(u"Notes footer");
    headerFooterManager->SetFooterVisibility(true);

    headerFooterManager->SetDateTimeText(u"Date and time text");
    headerFooterManager->SetDateTimeVisibility(true);

    headerFooterManager->SetSlideNumberVisibility(true);
}

presentation->Save(u"presentation_with_notes_master_footers.pptx", SaveFormat::Pptx);
```

طريقة [`IMasterNotesSlideManager::get_MasterNotesSlide`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imasternotesslidemanager/get_masternotesslide/) تُعيد `nullptr` عندما لا يحتوي العرض التقديمي على قالب ملاحظات.

## **تطبيق إعدادات قالب الملاحظات على شرائح الملاحظات التابعة**

يمكن لقالب الملاحظات تطبيق إعدادات الرأس والتذييل على نفسه وعلى جميع شرائح الملاحظات التابعة. استخدم طرق النشر المخصصة على [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imasternotesslideheaderfootermanager/) عندما يجب تطبيق نفس الإعدادات عبر هيكل الملاحظات.

على سبيل المثال، تُحدّث كل من [`SetHeaderAndChildHeadersText`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imasternotesslideheaderfootermanager/setheaderandchildheaderstext/) و[`SetHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imasternotesslideheaderfootermanager/setheaderandchildheadersvisibility/) رأس قالب الملاحظات وجميع رؤوس الأطفال. تتوفر طرق مماثلة للتذييل، التاريخ/الوقت، وأرقام الشرائح.

```cpp
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideHeaderFooterManager.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();

if (masterNotesSlide != nullptr)
{
    auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

    headerFooterManager->SetHeaderAndChildHeadersText(u"Notes header");
    headerFooterManager->SetHeaderAndChildHeadersVisibility(true);

    headerFooterManager->SetFooterAndChildFootersText(u"Notes footer");
    headerFooterManager->SetFooterAndChildFootersVisibility(true);

    headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");
    headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
}

presentation->Save(u"presentation_with_child_notes_footers.pptx", SaveFormat::Pptx);
```

طرق النشر المستخدمة أعلاه هي [`SetFooterAndChildFootersText`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imasternotesslideheaderfootermanager/setfooterandchildfooterstext/)، [`SetFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imasternotesslideheaderfootermanager/setfooterandchildfootersvisibility/)، [`SetDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imasternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/)، [`SetDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imasternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/)، و[`SetSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imasternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/).

## **تعيين الرؤوس والتذييلات على شريحة ملاحظات فردية**

تنتمي شريحة الملاحظات إلى شريحة عادية محددة. استخدم واجهة [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/inotesslideheaderfootermanager/) عندما تريد تخصيص تلك الصفحة الملاحظة فقط.

طريقة [`INotesSlideManager::AddNotesSlide`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/inotesslidemanager/addnotesslide/) تُعيد شريحة الملاحظات للشفرة الحالية وتُنشئ واحدة إذا لم تكن موجودة. المثال التالي يضبط صفحة الملاحظات المرتبطة بأول شريحة في العرض التقديمي:

```cpp
#include <DOM/INotesSlide.h>
#include <DOM/INotesSlideHeaderFooterManager.h>
#include <DOM/INotesSlideManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto slide = presentation->get_Slide(0);
auto notesSlide = slide->get_NotesSlideManager()->AddNotesSlide();
auto headerFooterManager = notesSlide->get_HeaderFooterManager();

headerFooterManager->SetHeaderText(u"Header for the first notes page");
headerFooterManager->SetHeaderVisibility(true);

headerFooterManager->SetFooterText(u"Footer for the first notes page");
headerFooterManager->SetFooterVisibility(true);

headerFooterManager->SetDateTimeText(u"Date and time text");
headerFooterManager->SetDateTimeVisibility(true);

headerFooterManager->SetSlideNumberVisibility(true);

presentation->Save(u"presentation_with_custom_notes_footers.pptx", SaveFormat::Pptx);
```

إذا قمت أولاً بنشر الإعدادات من قالب الملاحظات ثم غيرت شريحة ملاحظات فردية، فإن إعدادات الشريحة اللاحقة تسمح لك بتخصيص تلك الصفحة بشكل مستقل.

## **تعيين الرؤوس والتذييلات على قالب التوزيع**

تستخدم صفحات التوزيع قالب التوزيع لعناصر الرأس، التذييل، التاريخ/الوقت، ورقم الصفحة. على عكس صفحات الملاحظات، تُدار إعدادات التوزيع من خلال قالب التوزيع وليس من خلال شرائح التوزيع الفردية.

استخدم [`IMasterHandoutSlideManager::get_MasterHandoutSlide`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imasterhandoutslidemanager/get_masterhandoutslide/) للوصول إلى قالب التوزيع. إذا لم يكن موجودًا، استدعِ [`IMasterHandoutSlideManager::SetDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) لإنشاء قالب التوزيع الافتراضي.

```cpp
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideHeaderFooterManager.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto masterHandoutSlideManager = presentation->get_MasterHandoutSlideManager();
auto masterHandoutSlide = masterHandoutSlideManager->get_MasterHandoutSlide();

if (masterHandoutSlide == nullptr)
{
    masterHandoutSlide = masterHandoutSlideManager->SetDefaultMasterHandoutSlide();
}

if (masterHandoutSlide != nullptr)
{
    auto headerFooterManager = masterHandoutSlide->get_HeaderFooterManager();

    headerFooterManager->SetHeaderText(u"Handout header");
    headerFooterManager->SetHeaderVisibility(true);

    headerFooterManager->SetFooterText(u"Handout footer");
    headerFooterManager->SetFooterVisibility(true);

    headerFooterManager->SetDateTimeText(u"Date and time text");
    headerFooterManager->SetDateTimeVisibility(true);

    headerFooterManager->SetSlideNumberVisibility(true);
}

presentation->Save(u"presentation_with_handout_footers.pptx", SaveFormat::Pptx);
```

## **فهم النطاق والوراثة**

اختر مدير الرأس/التذييل الذي يطابق النطاق الذي تريد تغييره:

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islideheaderfootermanager/) يغيّر إعدادات التذييل، التاريخ/الوقت، ورقم الشريحة لشريحة عادية واحدة.
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ilayoutslideheaderfootermanager/) يتحكم في شريحة تخطيط ويمكنه نشر الإعدادات المدعومة إلى الشرائح التابعة.
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imasterslideheaderfootermanager/) يتحكم في قالب شريحة عادي ويمكنه نشر الإعدادات المدعومة إلى الشرائح التابعة.
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imasternotesslideheaderfootermanager/) يتحكم في قالب الملاحظات ويمكنه نشر الإعدادات إلى جميع شرائح الملاحظات التابعة.
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/inotesslideheaderfootermanager/) يغيّر شريحة ملاحظات واحدة ويدعم عنصر نائب للرأس بالإضافة إلى التذييل، التاريخ/الوقت، ورقم الشريحة.
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imasterhandoutslideheaderfootermanager/) يغيّر قالب التوزيع ويدعم جميع الأنواع الأربعة من العناصر النائبة.

استخدم النشر من قالب أو تخطيط عندما يجب تطبيق الإعداد نفسه عبر هيكله. استخدم مدير شريحة أو شريحة ملاحظات فردية عندما تحتاج إلى إعداد محلي لصفحة واحدة.

## **الأسئلة المتداولة**

**هل يمكنني إضافة رأس إلى شريحة عادية؟**

لا. لا يُعرّف PowerPoint عنصرًا نائبًا للرأس للشرائح العادية. استخدم التذييل، التاريخ/الوقت، ورقم الشريحة على الشرائح العادية. تتوفر عناصر رأس في صفحات الملاحظات والتوزيع.

**ماذا إذا لم يكن عنصر التذييل أو التاريخ/الوقت أو رقم الشريحة مرئيًا؟**

استخدم مدير الرأس/التذييل المقابل للتحقق من رؤيته وتمكينه عند الحاجة. على سبيل المثال، يُظهر [`get_IsFooterVisible`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibaseslideheaderfootermanager/get_isfootervisible/) ما إذا كان عنصر التذييل موجودًا، وتغيّر [`SetFooterVisibility`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootervisibility/) رؤيته.

**كيف أبدأ ترقيم الشرائح من قيمة غير 1؟**

استخدم [`Presentation::set_FirstSlideNumber`](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/set_firstslidenumber/) لتعيين رقم الشريحة الأول. ثم تستخدم عناصر رقم الشريحة التسلسل المحدث.

**ماذا يحدث للرؤوس والتذييلات عند التصدير إلى PDF أو صور أو HTML؟**

العناصر المرئية للرأس والتذييل تُرسم مع باقي محتوى العرض التقديمي في تنسيق الخرج. مظهرها يعتمد على نوع الصفحة التي يتم تصديرها وإعدادات رؤية العناصر النائبة المقابلة.