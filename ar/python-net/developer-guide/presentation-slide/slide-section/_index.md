---
title: إدارة أقسام الشرائح في العروض التقديمية باستخدام Python
linktitle: قسم الشريحة
type: docs
weight: 100
url: /ar/python-net/slide-section/
keywords:
- إنشاء قسم
- إضافة قسم
- تحرير قسم
- تغيير قسم
- اسم القسم
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "تبسيط أقسام الشرائح في PowerPoint وOpenDocument باستخدام Aspose.Slides للغة Python — تقسيم، إعادة تسمية وإعادة ترتيب لتحسين سير عمل ملفات PPTX وODP."
---

## **نظرة عامة**

مع Aspose.Slides لـ Python، يمكنك تنظيم عرض تقديمي PowerPoint إلى أقسام تقوم بتجميع شرائح محددة.

قد ترغب في إنشاء أقسام لتنظيم أو تقسيم عرض تقديمي إلى أجزاء منطقية في هذه الحالات:

- عندما تعمل على عرض تقديمي كبير مع فريق وتحتاج إلى تخصيص شرائح معينة لزملاء محددين.  
- عندما تتعامل مع عرض تقديمي يحتوي على العديد من الشرائح وتجد صعوبة في إدارة أو تحرير كل شيء في آن واحد.

من الناحية المثالية، أنشئ أقسامًا تجمع الشرائح ذات الصلة—التي تشترك في موضوع أو فكرة أو هدف—وامنح كل قسم اسمًا يعكس محتوياته بوضوح.

## **إنشاء أقسام في العروض التقديمية**

لإضافة [القسم](https://reference.aspose.com/slides/python-net/aspose.slides/section/) الذي يجمع الشرائح في عرض تقديمي، توفر Aspose.Slides طريقة [add_section](https://reference.aspose.com/slides/python-net/aspose.slides/sectioncollection/add_section/) . تتيح لك تحديد اسم القسم والشريحة التي يبدأ عندها القسم.

المثال التالي بلغة Python يوضح كيفية إنشاء قسم في عرض تقديمي:
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides[0]

    slide1 = presentation.slides.add_empty_slide(layout_slide)
    slide2 = presentation.slides.add_empty_slide(layout_slide)
    slide3 = presentation.slides.add_empty_slide(layout_slide)
    slide4 = presentation.slides.add_empty_slide(layout_slide)

    section1 = presentation.sections.add_section("Section 1", slide1)
    # القسم 1 ينتهي عند الشريحة 2؛ القسم 2 يبدأ عند الشريحة 3.
    section2 = presentation.sections.add_section("Section 2", slide3) 
      
    presentation.save("presentation_sections.pptx", slides.export.SaveFormat.PPTX)
    
    presentation.sections.reorder_section_with_slides(section2, 0)
    presentation.save("reordered_sections.pptx", slides.export.SaveFormat.PPTX)
    
    presentation.sections.remove_section_with_slides(section2)
    presentation.sections.append_empty_section("Last empty section")
    presentation.save("presentation_with_empty_section.pptx",slides.export.SaveFormat.PPTX)
```


## **تغيير أسماء الأقسام**

بعد إنشاء [القسم](https://reference.aspose.com/slides/python-net/aspose.slides/section/) في عرض PowerPoint، قد تقرر تغيير اسمه.

المثال التالي بلغة Python يوضح كيفية إعادة تسمية قسم في عرض تقديمي:
```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
   section = presentation.sections[0]
   section.name = "My section"
```


## **الأسئلة المتداولة**

**هل يتم حفظ الأقسام عند الحفظ بتنسيق PPT (PowerPoint 97–2003)؟**

لا. تنسيق PPT لا يدعم بيانات تعريف الأقسام، لذا يتم فقدان تجميع الأقسام عند الحفظ إلى .ppt.

**هل يمكن إخفاء القسم بالكامل؟**

لا. يمكن إخفاء الشرائح الفردية فقط. لا يمتلك القسم ككيان حالة "مخفي".

**هل يمكنني العثور بسرعة على قسم من خلال شريحة، والعكس، العثور على الشريحة الأولى للقسم؟**

نعم. يُعرّف القسم بوضوح من خلال شريحته الأولى؛ عند إعطائك شريحة يمكنك تحديد القسم الذي تنتمي إليه، وبالنسبة للقسم يمكنك الوصول إلى الشريحة الأولى له.