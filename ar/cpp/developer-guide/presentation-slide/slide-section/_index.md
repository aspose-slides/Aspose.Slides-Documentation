---
title: إدارة أقسام الشرائح في العروض التقديمية باستخدام C++
linktitle: قسم الشريحة
type: docs
weight: 100
url: /ar/cpp/slide-section/
keywords:
- إنشاء قسم
- إضافة قسم
- تحرير قسم
- تغيير قسم
- اسم القسم
- استرجاع شرائح القسم
- معالجة شرائح القسم
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "إدارة أقسام الشرائح باستخدام Aspose.Slides لـ C++: إنشاء، إعادة تسمية، إعادة ترتيب، استرجاع، ومعالجة شرائح الأقسام في عروض PPTX التقديمية."
---
## **مقدمة**

تنظم الأقسام الشرائح المتتالية في مجموعات مسماة دون تغيير محتوى الشريحة. باستخدام Aspose.Slides لـ C++، يمكنك إنشاء، وإعادة ترتيب، وإعادة تسمية، وفحص، وإزالة الأقسام من خلال طريقة [Presentation::get_Sections](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/get_sections/) .

تكون الأقسام مفيدة بشكل خاص عندما:

- يحتاج عرض تقديمي كبير إلى تقسيمه إلى مواضيع أو فصول منطقية؛
- تُخصص مجموعات مختلفة من الشرائح لمتعاونين مختلفين؛
- تحتاج الشرائح إلى المعالجة أو النقل أو الدمج كمجموعات.

اختر أسماء أقسام مختصرة تصف هدف الشرائح المجمعّة. لأن الأقسام جزء من بنية العرض التقديمي، استخدم واجهات برمجة التطبيقات الخاصة بالأقسام لتحديد العضوية بدلاً من استخراجها من مواضع الشرائح.

## **إنشاء وإدارة الأقسام**

استخدم [ISectionCollection::AddSection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isectioncollection/addsection/) لإنشاء قسم عن طريق تحديد اسمه والشريحة البداية. يحدد Aspose.Slides أي الشرائح تنتمي إلى القسم بناءً على بنية الأقسام الحالية للعرض التقديمي.

نفس [ISectionCollection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isectioncollection/) يتيح لك أيضًا:

- نقل قسم مع شرائحه باستخدام [ISectionCollection::ReorderSectionWithSlides](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isectioncollection/reordersectionwithslides/)؛
- إزالة تعريف القسم فقط باستخدام [ISectionCollection::RemoveSection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isectioncollection/removesection/)، مع الاحتفاظ بشرائحه؛
- إزالة قسم وشرائحه باستخدام [ISectionCollection::RemoveSectionWithSlides](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isectioncollection/removesectionwithslides/)؛
- إضافة قسم فارغ في النهاية باستخدام [ISectionCollection::AppendEmptySection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isectioncollection/appendemptysection/) .

المثال التالي ينشئ قسمين، ينقل أحدهما، يزيله مع شرائحه، ويضيف قسمًا فارغًا:

```cpp
#include <DOM/ISectionCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto layoutSlide = presentation->get_LayoutSlide(0);
auto titleSlide = presentation->get_Slide(0);
presentation->get_Slides()->AddEmptySlide(layoutSlide);
auto resultsSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);
presentation->get_Slides()->AddEmptySlide(layoutSlide);

auto sections = presentation->get_Sections();
sections->AddSection(u"Introduction", titleSlide);
auto resultsSection = sections->AddSection(u"Results", resultsSlide);

sections->ReorderSectionWithSlides(resultsSection, 0);
sections->RemoveSectionWithSlides(resultsSection);
sections->AppendEmptySection(u"Appendix");
```

بعد هذه العمليات، يحتوي العرض التقديمي على قسم `Introduction` مع شرائحه وقسم فارغ `Appendix`. تم إزالة قسم `Results` وشرائحه.

## **إعادة تسمية الأقسام**

لإعادة تسمية قسم، استدعِ [ISection::set_Name](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isection/set_name/). تظل شرائح القسم وموقعه دون تغيير.

المثال التالي ينشئ قسمًا ويغيّر اسمه:

```cpp
#include <DOM/ISection.h>
#include <DOM/ISectionCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto section = presentation->get_Sections()->AddSection(u"Overview", slide);
section->set_Name(u"Introduction");
```

## **استرجاع الشرائح من الأقسام**

طريقة [Presentation::get_Sections](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/get_sections/) تُرجع مجموعة [ISectionCollection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isectioncollection/) يمكنك تعدادها. لكل [ISection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isection/)، استدعِ [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isection/getslideslistofsection/) للحصول على الشرائح التي تنتمي إليه حاليًا. تُرجع الطريقة مجموعة [ISectionSlideCollection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isectionslidecollection/)، التي توفر عددًا، وصولًا بالفهرس، وتعدادًا.

المثال التالي ينشئ قسمين ممتلئين وقسمًا فارغًا، ثم يطبع لكل قسم [الاسم](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isection/get_name/)، [المعرّف](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isection/get_sectionid/)، [الشريحة البداية](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isection/get_startedfromslide/)، عدد الشرائح، وأرقام الشرائح. يستخدم وصولًا بالفهرس لقراءة الشريحة الأولى وحلقة `for` مبنية على النطاق لمعالجة كل شريحة. بالنسبة للقسم الفارغ، تكون المجموعة المُرجعة عددها صفر، ولا يُستخدم الوصول بالفهرس، ولا تُجرى أي تكرارات في التعداد.

```cpp
#include <DOM/ISection.h>
#include <DOM/ISectionCollection.h>
#include <DOM/ISectionSlideCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto layoutSlide = presentation->get_LayoutSlide(0);
auto firstSlide = presentation->get_Slide(0);
presentation->get_Slides()->AddEmptySlide(layoutSlide);
auto thirdSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);

auto sections = presentation->get_Sections();
sections->AddSection(u"Introduction", firstSlide);
sections->AddSection(u"Details", thirdSlide);
sections->AppendEmptySection(u"Appendix");

for (const auto& section : sections)
{
    auto sectionSlides = section->GetSlidesListOfSection();
    auto startingSlide = section->get_StartedFromSlide();

    System::Console::WriteLine(u"Section: {0}", section->get_Name());
    System::Console::WriteLine(u"ID: {0}", section->get_SectionId().ToString());
    if (startingSlide == nullptr)
    {
        System::Console::WriteLine(u"Starting slide: none");
    }
    else
    {
        System::Console::WriteLine(u"Starting slide: {0}", startingSlide->get_SlideNumber());
    }
    System::Console::WriteLine(u"Slide count: {0}", sectionSlides->get_Count());

    if (sectionSlides->get_Count() > 0)
    {
        System::Console::WriteLine(u"First slide via index: {0}", sectionSlides->idx_get(0)->get_SlideNumber());
    }

    System::Console::Write(u"Slide numbers:");
    for (const auto& slide : sectionSlides)
    {
        System::Console::Write(u" {0}", slide->get_SlideNumber());
    }
    System::Console::WriteLine();
}
```

تُحدد عضوية القسم بواسطة بنية الأقسام في العرض التقديمي. لا تحسب نطاق القسم يدويًا استنادًا إلى [ISection::get_StartedFromSlide](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isection/get_startedfromslide/)، فهارس الشرائح، وشريحة البداية للقسم التالي.

يمكن للتعديلات الهيكلية أن تغير كلًا من الشرائح المُرجعة لقسم معين وأرقامها. يشمل ذلك إعادة ترتيب الشرائح، استنساخ شريحة إلى قسم، نقل قسم مع شرائحه، إزالة شرائح، وإزالة أقسام. المثال التالي يستدعي [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isection/getslideslistofsection/) بعد كل تغيير من هذا النوع بدلاً من الاعتماد على افتراضات حول حدود القسم السابقة.

```cpp
#include <DOM/ISection.h>
#include <DOM/ISectionCollection.h>
#include <DOM/ISectionSlideCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto layoutSlide = presentation->get_LayoutSlide(0);
auto firstSlide = presentation->get_Slide(0);
presentation->get_Slides()->AddEmptySlide(layoutSlide);
auto thirdSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);
presentation->get_Slides()->AddEmptySlide(layoutSlide);

auto sections = presentation->get_Sections();
auto firstSection = sections->AddSection(u"First", firstSlide);
auto secondSection = sections->AddSection(u"Second", thirdSlide);

auto printSectionSlides = [](const System::String& label, const System::SharedPtr<ISection>& section)
{
    auto sectionSlides = section->GetSlidesListOfSection();
    System::Console::Write(u"{0} ({1} slides):", label, sectionSlides->get_Count());
    for (const auto& slide : sectionSlides)
    {
        System::Console::Write(u" {0}", slide->get_SlideNumber());
    }
    System::Console::WriteLine();
};

printSectionSlides(u"Initially", firstSection);

auto slidesBeforeClone = firstSection->GetSlidesListOfSection();
presentation->get_Slides()->AddClone(slidesBeforeClone->idx_get(0), firstSection);
printSectionSlides(u"After cloning into the section", firstSection);

auto slidesBeforeReorder = firstSection->GetSlidesListOfSection();
auto firstSlideInSection = slidesBeforeReorder->idx_get(0);
auto lastSlideInSection = slidesBeforeReorder->idx_get(slidesBeforeReorder->get_Count() - 1);
auto firstSectionPosition = firstSlideInSection->get_SlideNumber() - 1;
presentation->get_Slides()->Reorder(firstSectionPosition, lastSlideInSection);
printSectionSlides(u"After reordering slides", firstSection);

sections->ReorderSectionWithSlides(firstSection, 1);
printSectionSlides(u"After moving the section", firstSection);

auto slidesBeforeRemoval = firstSection->GetSlidesListOfSection();
presentation->get_Slides()->Remove(slidesBeforeRemoval->idx_get(0));
printSectionSlides(u"After removing a slide", firstSection);

sections->RemoveSectionWithSlides(secondSection);
for (const auto& section : sections)
{
    printSectionSlides(u"Remaining section", section);
}
```

استدعِ [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isection/getslideslistofsection/) مرة أخرى كلما أعيد ترتيب الشرائح أو الأقسام، أو تم استنساخها، أو نقلها، أو إزالتها. هذا يحافظ على توافق المعالجة اللاحقة مع بنية العرض التقديمي الحالية.

تنسيق PPT (PowerPoint 97–2003) لا يحفظ بيانات تعريف الأقسام. استخدم سير العمل هذا مع تنسيق يدعم الأقسام، مثل PPTX؛ التحويل إلى PPT يزيل بنية الأقسام المطلوبة للتعداد لاحقًا.

## **الأسئلة المتداولة**

**هل يتم حفظ الأقسام عند الحفظ بتنسيق PPT (PowerPoint 97–2003)؟**

لا. لا يدعم تنسيق PPT بيانات تعريف الأقسام، لذا يتم فقدان تجميع الأقسام عند الحفظ إلى .ppt.

**هل يمكن إخفاء قسم بالكامل؟**

لا. لا يمتلك القسم حالة رؤية. لإخفاء محتوياته، استدعِ [ISlide::set_Hidden](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islide/set_hidden/) لكل شريحة في القسم.

**كيف يمكنني العثور على القسم الذي يحتوي على شريحة معينة؟**

قم بتعداد [Presentation::get_Sections](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/get_sections/)، استدعِ [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isection/getslideslistofsection/) لكل قسم، وقارن الشرائح المُرجعة مع الشريحة المستهدفة. بالنسبة لقسم غير فارغ، تُرجع [ISection::get_StartedFromSlide](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isection/get_startedfromslide/) شريحته الأولى؛ أما القسم الفارغ، فتُرجع قيمة `nullptr`.