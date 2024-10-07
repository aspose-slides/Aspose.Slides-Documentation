---
title: قسم الشرائح
type: docs
weight: 100
url: /cpp/slide-section/
---

مع Aspose.Slides لـ C++، يمكنك تنظيم عرض PowerPoint إلى أقسام. يمكنك إنشاء أقسام تحتوي على شرائح معينة.

قد ترغب في إنشاء أقسام واستخدامها لتنظيم أو تقسيم الشرائح في عرض تقديمي إلى أجزاء منطقية في هذه الحالات:

- عندما تعمل على عرض تقديمي كبير مع أشخاص آخرين أو فريق—وتحتاج إلى تخصيص شرائح معينة لزميل أو بعض أعضاء الفريق.
- عندما تتعامل مع عرض تقديمي يحتوي على العديد من الشرائح—وتكافح لإدارة محتوياته أو تحريرها دفعة واحدة.

مثاليًا، يجب أن تنشئ قسمًا يحتوي على شرائح مشابهة—الشرائح لديها شيء مشترك أو يمكن أن توجد في مجموعة بناءً على قاعدة—وتعطي القسم اسمًا يصف الشرائح بداخله.

## إنشاء أقسام في العروض التقديمية

لإضافة قسم سيحتوي على شرائح في عرض تقديمي، يوفر Aspose.Slides لـ C++ طريقة AddSection التي تتيح لك تحديد اسم القسم الذي تنوي إنشاؤه والشريحة التي سيبدأ منها القسم.

هذا مثال للشفرة البرمجية التي تظهر لك كيفية إنشاء قسم في عرض تقديمي بلغة C++:

``` cpp
auto pres = System::MakeObject<Presentation>();

auto defaultSlide = pres->get_Slides()->idx_get(0);
auto newSlide1 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide2 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide3 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide4 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));

auto section1 = pres->get_Sections()->AddSection(u"القسم 1", newSlide1);
auto section2 = pres->get_Sections()->AddSection(u"القسم 2", newSlide3);
// سيتم إنهاء section1 عند newSlide2 وبعده سيبدأ section2   

pres->Save(u"pres-sections.pptx", SaveFormat::Pptx);

pres->get_Sections()->ReorderSectionWithSlides(section2, 0);
pres->Save(u"pres-sections-moved.pptx", SaveFormat::Pptx);

pres->get_Sections()->RemoveSectionWithSlides(section2);

pres->get_Sections()->AppendEmptySection(u"آخر قسم فارغ");

pres->Save(u"pres-section-with-empty.pptx", SaveFormat::Pptx);
```

## تغيير أسماء الأقسام

بعد أن تقوم بإنشاء قسم في عرض PowerPoint، قد تقرر تغيير اسمه.

هذا مثال للشفرة البرمجية التي تظهر لك كيفية تغيير اسم قسم في عرض تقديمي بلغة C++ باستخدام Aspose.Slides:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto section = pres->get_Sections()->idx_get(0);
section->set_Name(u"قسمي");
```