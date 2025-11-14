---
title: قسم الشريحة
type: docs
weight: 100
url: /ar/python-net/slide-section/
keywords: "إنشاء قسم، إضافة قسم، تعديل اسم القسم، عرض بوربوينت، بايثون، Aspose.Slides"
description: "إضافة وتعديل قسم في عرض بوربوينت باستخدام بايثون"
---

مع Aspose.Slides لبايثون عبر .NET، يمكنك تنظيم عرض بوربوينت إلى أقسام. يمكنك إنشاء أقسام تحتوي على شرائح محددة.

قد ترغب في إنشاء أقسام واستخدامها لتنظيم أو تقسيم الشرائح في عرض ما إلى أجزاء منطقية في هذه الحالات:

- عندما تعمل على عرض كبير مع أشخاص آخرين أو فريق—و تحتاج إلى تخصيص بعض الشرائح لزميل أو بعض أعضاء الفريق.
- عندما تتعامل مع عرض يحتوي على العديد من الشرائح—و تجد صعوبة في إدارة أو تعديل محتوياته دفعة واحدة.

من المثالي أن تقوم بإنشاء قسم يحتفظ بشرائح متشابهة—حيث أن الشرائح لها شيء مشترك أو يمكن أن توجد في مجموعة بناءً على قاعدة—وإعطاء القسم اسمًا يصف الشرائح بداخله.

## إنشاء أقسام في العروض

لإضافة قسم يحتوي على شرائح في عرض ما، توفر Aspose.Slides لبايثون عبر .NET طريقة AddSection التي تسمح لك بتحديد اسم القسم الذي تعتزم إنشاؤه والشفافه التي يبدأ منها القسم.

يعرض هذا الكود العينة كيفية إنشاء قسم في عرض بايثون:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    defaultSlide = pres.slides[0]
    newSlide1 = pres.slides.add_empty_slide(pres.layout_slides[0])
    newSlide2 = pres.slides.add_empty_slide(pres.layout_slides[0])
    newSlide3 = pres.slides.add_empty_slide(pres.layout_slides[0])
    newSlide4 = pres.slides.add_empty_slide(pres.layout_slides[0])

    section1 = pres.sections.add_section("قسم 1", newSlide1)
    # سيتم إنهاء section1 عند newSlide2 وبعده سيبدأ section2 
    section2 = pres.sections.add_section("قسم 2", newSlide3) 
      
    
    pres.save("pres-sections.pptx", slides.export.SaveFormat.PPTX)
    
    pres.sections.reorder_section_with_slides(section2, 0)
    pres.save("pres-sections-moved.pptx", slides.export.SaveFormat.PPTX)
    
    pres.sections.remove_section_with_slides(section2)
    
    pres.sections.append_empty_section("آخر قسم فارغ")
    
    pres.save("pres-section-with-empty.pptx",slides.export.SaveFormat.PPTX)
```

## تغيير أسماء الأقسام

بعد إنشاء قسم في عرض بوربوينت، قد تقرر تغيير اسمه.

يعرض هذا الكود العينة كيفية تغيير اسم قسم في عرض باستخدام بايثون عبر Aspose.Slides:

```py
import aspose.slides as slides

with slides.Presentation("pres-sections.pptx") as pres:
   section = pres.sections[0]
   section.name = "قسمي"
```