---
title: إدارة أقسام الشرائح في العروض باستخدام C++
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
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "تحسين أقسام الشرائح في PowerPoint و OpenDocument باستخدام Aspose.Slides لـ C++ — تقسيم، إعادة تسمية، وإعادة ترتيب لتحسين سير عمل ملفات PPTX و ODP."
---

مع Aspose.Slides for C++، يمكنك تنظيم عرض PowerPoint إلى أقسام. يمكنك إنشاء أقسام تحتوي على شرائح محددة. 

قد ترغب في إنشاء أقسام واستخدامها لتنظيم أو تقسيم الشرائح في عرض تقديمي إلى أجزاء منطقية في الحالات التالية:

- عندما تعمل على عرض تقديمي كبير مع أشخاص آخرين أو فريق — وتحتاج إلى إسناد شرائح معينة إلى زميل أو بعض أعضاء الفريق. 
- عندما تواجه عرضًا تقديميًا يحتوي على عدد كبير من الشرائح — وتكافح لإدارة أو تعديل محتوياته دفعة واحدة.

من الناحية المثالية، ينبغي إنشاء قسم يحتوي على شرائح متشابهة — حيث تشترك الشرائح في شيء ما أو يمكن جمعها في مجموعة بناءً على قاعدة — ومنح هذا القسم اسمًا يصف الشرائح التي يحتويها. 

## **إنشاء أقسام في العروض التقديمية**

لإضافة قسم سيحتوي على الشرائح في عرض تقديمي، توفر Aspose.Slides for C++ طريقة AddSection التي تسمح لك بتحديد اسم القسم الذي ترغب في إنشائه والشرائح التي يبدأ منها القسم. 

يعرض لك هذا الكود مثالًا على إنشاء قسم في عرض تقديمي باستخدام C++:
``` cpp
auto pres = System::MakeObject<Presentation>();

auto defaultSlide = pres->get_Slides()->idx_get(0);
auto newSlide1 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide2 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide3 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));
auto newSlide4 = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->idx_get(0));

auto section1 = pres->get_Sections()->AddSection(u"Section 1", newSlide1);
auto section2 = pres->get_Sections()->AddSection(u"Section 2", newSlide3);
// section1 ستنتهي عند newSlide2 وبعدها سيبدأ section2   

pres->Save(u"pres-sections.pptx", SaveFormat::Pptx);

pres->get_Sections()->ReorderSectionWithSlides(section2, 0);
pres->Save(u"pres-sections-moved.pptx", SaveFormat::Pptx);

pres->get_Sections()->RemoveSectionWithSlides(section2);

pres->get_Sections()->AppendEmptySection(u"Last empty section");

pres->Save(u"pres-section-with-empty.pptx", SaveFormat::Pptx);
```


## **تغيير أسماء الأقسام**

بعد إنشاء قسم في عرض PowerPoint، قد تقرر تغيير اسمه. 

يُظهر لك هذا الكود مثالًا على كيفية تغيير اسم القسم في عرض تقديمي باستخدام C++ وAspose.Slides:
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto section = pres->get_Sections()->idx_get(0);
section->set_Name(u"My section");
```


## **الأسئلة المتكررة**

**هل يتم حفظ الأقسام عند الحفظ بتنسيق PPT (PowerPoint 97–2003)؟**

لا. لا يدعم تنسيق PPT بيانات تعريف الأقسام، لذا يتم فقدان تجميع الأقسام عند الحفظ إلى .ppt.

**هل يمكن إخفاء القسم بالكامل؟**

لا. يمكن إخفاء الشرائح الفردية فقط. لا يمتلك القسم ككيان حالة "مخفي".

**هل يمكنني العثور بسرعة على القسم عبر شريحة معينة، وعلى العكس، العثور على أول شريحة في قسم؟**

نعم. يُعرّف القسم بشكل فريد بواسطة شريحته البداية؛ بتحديد شريحة يمكنك معرفة القسم الذي تنتمي إليه، وبالنسبة للقسم يمكنك الوصول إلى أول شريحة فيه.