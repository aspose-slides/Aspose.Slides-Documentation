---
title: "إدارة أدلة الرسم في العروض التقديمية باستخدام C++"
linktitle: "أدلة الرسم"
type: docs
weight: 85
url: /ar/cpp/drawing-guides/
keywords:
- دليل رسم
- دليل أفقي
- دليل عمودي
- دليل محاذاة
- عرض الشريحة
- قالب شريحة
- تخطيط شريحة
- قالب ملاحظات
- قالب نشرة
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "إضافة، الوصول، وإزالة أدلة الرسم الأفقية والرأسية في عروض PowerPoint التقديمية باستخدام Aspose.Slides لـ C++."
---
## **نظرة عامة**

تعد أدلة الرسم خطوطًا أفقية ورأسية قابلة للتعديل تساعد المستخدمين على محاذاة الأشكال بشكل ثابت أثناء تحرير عرض تقديمي في PowerPoint. وهي مفيدة بشكل خاص عندما يولد تطبيق عرضًا تقديميًا سيُعاد صقله يدويًا لاحقًا: يمكن للتطبيق حفظ نفس أدوات المحاذاة التي يجب على المؤلفين اتباعها عند إضافة المحتوى أو تحريكه.

أدلة الرسم هي أدوات تحرير، ليست محتوىً للشرائح. لا تظهر في عرض الشرائح أو في المخرجات المُصدَّرة. تُظهر Aspose.Slides for C++ هذه الأدلة عبر واجهة [IDrawingGuidesCollection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/idrawingguidescollection/) . يُمثَّل الدليل بواسطة [IDrawingGuide](https://reference.aspose.com/slides/ar/cpp/aspose.slides/idrawingguide/) وله اتجاه، موضع، ولون.

يُقاس الموضع بالنقاط من الزاوية العليا اليسرى للشفرة أو القالب ذات الصلة. يستخدم الدليل العمودي إحداثيًا أفقيًا، عادةً بين الصفر وعرض الشريحة. يستخدم الدليل الأفقي إحداثيًا عموديًا، عادةً بين الصفر وارتفاع الشريحة.

## **إضافة أدلة إلى عرض الشريحة**

استخدم [ICommonSlideViewProperties::get_DrawingGuides](https://reference.aspose.com/slides/ar/cpp/aspose.slides/icommonslideviewproperties/get_drawingguides/) لإدارة الأدلة المعروضة أثناء تحرير الشرائح العادية. استدعِ [IDrawingGuidesCollection::Add](https://reference.aspose.com/slides/ar/cpp/aspose.slides/idrawingguidescollection/add/) مع قيمة [Orientation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/orientation/) وموضع بالنقاط.

المثال التالي يضيف دليلًا عموديًا واحدًا إلى يمين مركز الشريحة ودليلًا أفقيًا أسفله:

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/IViewProperties.h>
#include <DOM/Orientation.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto slideSize = presentation->get_SlideSize()->get_Size();
auto guides = presentation->get_ViewProperties()->get_SlideViewProperties()->get_DrawingGuides();

guides->Add(Orientation::Vertical, slideSize.get_Width() / 2 + 12.5f);
guides->Add(Orientation::Horizontal, slideSize.get_Height() / 2 + 12.5f);

presentation->Save(u"drawing-guides.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **الوصول إلى أدلة الرسم**

توفر الطريقة [IDrawingGuidesCollection::get_Count](https://reference.aspose.com/slides/ar/cpp/aspose.slides/idrawingguidescollection/get_count/) والطريقة [IDrawingGuidesCollection::idx_get](https://reference.aspose.com/slides/ar/cpp/aspose.slides/idrawingguidescollection/idx_get/) إمكانية الوصول إلى الأدلة الموجودة. تُعيد الطرق [IDrawingGuide::get_Orientation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/idrawingguide/get_orientation/)، [IDrawingGuide::get_Position](https://reference.aspose.com/slides/ar/cpp/aspose.slides/idrawingguide/get_position/)، و[IDrawingGuide::get_Color](https://reference.aspose.com/slides/ar/cpp/aspose.slides/idrawingguide/get_color/) الخصائص الحالية للدليل. يمكن لطرق الضبط المقابلة تعديل تلك الخصائص.

المثال التالي يقرأ أدلة عرض الشريحة من العرض التقديمي الذي تم إنشاؤه أعلاه:

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IDrawingGuide.h>
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"drawing-guides.pptx");
auto guides = presentation->get_ViewProperties()->get_SlideViewProperties()->get_DrawingGuides();

for (int32_t index = 0; index < guides->get_Count(); index++)
{
    auto guide = guides->idx_get(index);
    System::Console::WriteLine(
        System::String::Format(
            u"Guide {0}: orientation = {1}, position = {2}, color = {3}",
            index,
            guide->get_Orientation(),
            guide->get_Position(),
            guide->get_Color()));
}

presentation->Dispose();
```

## **إضافة أدلة إلى قوالب الشرائح وتخطيطاتها**

يمكن لقالب الشريحة وكل من تخطيطاتها أن يمتلك مجموعات أدلة رسم خاصة به. استخدم [IMasterSlide::get_DrawingGuides](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imasterslide/get_drawingguides/) لقالب الشريحة و[ILayoutSlide::get_DrawingGuides](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ilayoutslide/get_drawingguides/) لتخطيط الشريحة.

المثال التالي يضيف دليلًا عموديًا إلى أول قالب شريحة ودليلًا أفقيًا إلى أول تخطيط شريحة:

```cpp
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Orientation.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto slideSize = presentation->get_SlideSize()->get_Size();
auto masterGuides = presentation->get_Master(0)->get_DrawingGuides();
auto layoutGuides = presentation->get_LayoutSlide(0)->get_DrawingGuides();

masterGuides->Add(Orientation::Vertical, slideSize.get_Width() / 2 - 20.0f);
layoutGuides->Add(Orientation::Horizontal, slideSize.get_Height() / 2 + 20.0f);

presentation->Save(u"master-layout-drawing-guides.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **إضافة أدلة إلى قوالب الملاحظات والنشرات**

تدعم قوالب الملاحظات وقوالب النشرات أيضًا أدلة الرسم. استخدم [IMasterNotesSlide::get_DrawingGuides](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imasternotesslide/get_drawingguides/) و[IMasterHandoutSlide::get_DrawingGuides](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imasterhandoutslide/get_drawingguides/) للوصول إلى مجموعاتهم. إذا لم يحتوي العرض التقديمي على أحد هذه القوالب، فإن [IMasterNotesSlideManager::SetDefaultMasterNotesSlide](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imasternotesslidemanager/setdefaultmasternotesslide/) أو [IMasterHandoutSlideManager::SetDefaultMasterHandoutSlide](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) ينشئ القالب الافتراضي ويعيده.

المثال التالي يضيف دليلًا أفقيًا إلى قالب ملاحظات ودليلًا عموديًا إلى قالب نشرة:

```cpp
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/INotesSize.h>
#include <DOM/Orientation.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto notesSize = presentation->get_NotesSize()->get_Size();
auto notesMaster = presentation->get_MasterNotesSlideManager()->SetDefaultMasterNotesSlide();
auto handoutMaster = presentation->get_MasterHandoutSlideManager()->SetDefaultMasterHandoutSlide();

notesMaster->get_DrawingGuides()->Add(Orientation::Horizontal, notesSize.get_Height() / 2 + 50.0f);
handoutMaster->get_DrawingGuides()->Add(Orientation::Vertical, notesSize.get_Width() / 2 - 50.0f);

presentation->Save(u"notes-handout-drawing-guides.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **مسح أدلة الرسم**

استدعِ [IDrawingGuidesCollection::Clear](https://reference.aspose.com/slides/ar/cpp/aspose.slides/idrawingguidescollection/clear/) لإزالة جميع الأدلة من مجموعة معينة. مسح مجموعة واحدة لا يؤثر على الأدلة المخزنة في نطاق آخر.

المثال التالي يمسح أدلة عرض الشريحة وجميع الأدلة على قوالب الشرائح، وتخطيطات الشرائح، وقالب الملاحظات، وقالب النشرة دون إنشاء القوالب المفقودة:

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation-with-guides.pptx");

presentation->get_ViewProperties()->get_SlideViewProperties()->get_DrawingGuides()->Clear();

for (auto&& masterSlide : presentation->get_Masters())
{
    masterSlide->get_DrawingGuides()->Clear();
}

for (auto&& layoutSlide : presentation->get_LayoutSlides())
{
    layoutSlide->get_DrawingGuides()->Clear();
}

auto notesMaster = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (notesMaster != nullptr)
{
    notesMaster->get_DrawingGuides()->Clear();
}

auto handoutMaster = presentation->get_MasterHandoutSlideManager()->get_MasterHandoutSlide();
if (handoutMaster != nullptr)
{
    handoutMaster->get_DrawingGuides()->Clear();
}

presentation->Save(u"presentation-without-guides.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **الأسئلة الشائعة**

**هل تظهر أدلة الرسم في عرض الشرائح أو الصور المصدَّرة؟**

لا. أدلة الرسم هي أدوات محاذاة للتحرير ولا تُعرض كمحتوى للعرض التقديمي.

**هل يمكن إضافة دليل رسم مباشرة إلى شريحة عادية فردية؟**

تُخزن أدلة تحرير الشرائح العادية في خصائص عرض الشرائح للعرض التقديمي. تتوفر مجموعات أدلة منفصلة لقوالب الشرائح، وتخطيطات الشرائح، وقوالب الملاحظات، وقوالب النشرات.

**ما الوحدات المستخدمة لمواضع الأدلة؟**

يتم تحديد الموضع بالنقاط، حيث 72 نقطة تساوي بوصة واحدة. تُقاس المواضع الرأسية من الحافة اليسرى، وتُقاس المواضع الأفقية من الحافة العلوية.

**هل يؤدي مسح أدلة الرسم إلى إزالة الأشكال أو تغيير محتوى الشريحة؟**

لا. طريقة `Clear` تزيل فقط الأدلة في المجموعة المحددة. تبقى الأشكال وبقية محتوى الشريحة دون تعديل.