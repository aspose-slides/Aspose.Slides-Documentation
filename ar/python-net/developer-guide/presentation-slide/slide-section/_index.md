---
title: إدارة أقسام الشرائح في العروض التقديمية باستخدام بايثون
linktitle: قسم الشريحة
type: docs
weight: 100
url: /ar/python-net/developer-guide/presentation-slide/slide-section/
keywords:
- إنشاء قسم
- إضافة قسم
- تعديل قسم
- تغيير قسم
- اسم القسم
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "تبسيط أقسام الشرائح في PowerPoint وOpenDocument باستخدام Aspose.Slides للبايثون — تقسيم، إعادة تسمية، وإعادة ترتيب لتحسين سير عمل PPTX وODP."
---

## **نظرة عامة**

مع Aspose.Slides للبايثون، يمكنك تنظيم عرض PowerPoint إلى أقسام تجميع شرائح معينة.

قد ترغب في إنشاء أقسام لتنظيم أو تقسيم العرض إلى أجزاء منطقية في الحالات التالية:

- عندما تعمل على عرض تقديمي كبير مع فريق وتحتاج إلى تعيين شرائح معينة لزملاء محددين.
- عندما تتعامل مع عرض يحتوي على عدد كبير من الشرائح وتجد صعوبة في إدارة أو تعديل كل شيء في آنٍ واحد.

من المثالي إنشاء أقسام تجمع الشرائح ذات الصلة—التي تشترك في موضوع أو فكرة أو هدف—ومنح كل قسم اسمًا يعكس محتوياته بوضوح.

## **إنشاء أقسام في العروض التقديمية**

لإضافة [القسم](https://reference.aspose.com/slides/python-net/aspose.slides/section/) الذي يجمع الشرائح في عرض تقديمي، توفر Aspose.Slides الطريقة [add_section](https://reference.aspose.com/slides/python-net/aspose.slides/sectioncollection/add_section/). تتيح لك تحديد اسم القسم والشريحة التي يبدأ فيها القسم.

يظهر المثال التالي بلغة بايثون كيفية إنشاء قسم في عرض تقديمي:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides[0]

    slide1 = presentation.slides.add_empty_slide(layout_slide)
    slide2 = presentation.slides.add_empty_slide(layout_slide)
    slide3 = presentation.slides.add_empty_slide(layout_slide)
    slide4 = presentation.slides.add_empty_slide(layout_slide)

    section1 = presentation.sections.add_section("Section 1", slide1)
    # Section 1 ends at slide2; Section 2 starts at slide3.
    section2 = presentation.sections.add_section("Section 2", slide3) 
      
    presentation.save("presentation_sections.pptx", slides.export.SaveFormat.PPTX)
    
    presentation.sections.reorder_section_with_slides(section2, 0)
    presentation.save("reordered_sections.pptx", slides.export.SaveFormat.PPTX)
    
    presentation.sections.remove_section_with_slides(section2)
    presentation.sections.append_empty_section("Last empty section")
    presentation.save("presentation_with_empty_section.pptx",slides.export.SaveFormat.PPTX)
```

## **تغيير أسماء الأقسام**

بعد إنشاء [القسم](https://reference.aspose.com/slides/python-net/aspose.slides/section/) في عرض PowerPoint، قد تقرر تعديل اسمه.

يظهر المثال التالي بلغة بايثون كيفية إعادة تسمية قسم في عرض تقديمي:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
   section = presentation.sections[0]
   section.name = "My section"
```

## **الأسئلة الشائعة**

**هل يتم الحفاظ على الأقسام عند الحفظ بصيغة PPT (PowerPoint 97–2003)؟**

لا. صيغة PPT لا تدعم بيانات تعريف الأقسام، لذا يتم فقدان تجميع الأقسام عند الحفظ بامتداد .ppt.

**هل يمكن إخفاء قسم كامل؟**

لا. لا يمكن إخفاء الأقسام ككيان؛ يمكن إخفاء الشرائح الفردية فقط.

**هل يمكن العثور سريعًا على قسم بواسطة شريحة، وعلى العكس، معرفة الشريحة الأولى للقسم؟**

نعم. يتم تعريف كل قسم بشكل فريد بواسطة شريحته البداية؛ إذا علمت الشريحة، يمكنك تحديد القسم الذي تنتمي إليه، وبالنسبة للقسم يمكنك الوصول إلى شريحته الأولى.