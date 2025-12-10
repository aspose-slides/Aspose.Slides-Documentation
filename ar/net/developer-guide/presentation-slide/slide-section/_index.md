---
title: إدارة أقسام الشرائح في العروض التقديمية في .NET
linktitle: قسم الشريحة
type: docs
weight: 100
url: /ar/net/slide-section/
keywords:
- إنشاء قسم
- إضافة قسم
- تحرير القسم
- تغيير القسم
- اسم القسم
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تبسيط أقسام الشرائح في PowerPoint و OpenDocument باستخدام Aspose.Slides for .NET — تقسيم، إعادة تسمية، وإعادة ترتيب لتحسين سير عمل ملفات PPTX و ODP."
---

مع Aspose.Slides for .NET، يمكنك تنظيم عرض PowerPoint إلى أقسام. يمكنك إنشاء أقسام تحتوي على شرائح معينة. 

قد ترغب في إنشاء أقسام واستخدامها لتنظيم أو تقسيم الشرائح في عرض تقديمي إلى أجزاء منطقية في الحالات التالية:

- عندما تعمل على عرض تقديمي كبير مع أشخاص آخرين أو فريق—وتحتاج إلى تعيين شرائح معينة لزميل أو بعض أعضاء الفريق. 
- عندما تتعامل مع عرض تقديمي يحتوي على عدد كبير من الشرائح—وتجد صعوبة في إدارة محتوياته أو تعديلها دفعة واحدة.

من المثالي أن تنشئ قسماً يضم شرائح متشابهة—الشرائح لها شيء مشترك أو يمكن أن توجد في مجموعة بناءً على قاعدة—وتعطي القسم اسماً يصف الشرائح الموجودة داخله. 

## **إنشاء أقسام في العروض التقديمية**

لإضافة قسم يضم شرائح في عرض تقديمي، توفر مكتبة Aspose.Slides for .NET الطريقة AddSection التي تسمح لك بتحديد اسم القسم الذي تريد إنشائه والشرائح التي يبدأ منها القسم. 

يعرض هذا المثال كيفية إنشاء قسم في عرض تقديمي باستخدام C#:
```c#
using (Presentation pres = new Presentation())
{
    ISlide defaultSlide = pres.Slides[0];
    ISlide newSlide1 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide2 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide3 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide4 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

    ISection section1 = pres.Sections.AddSection("Section 1", newSlide1);
    ISection section2 = pres.Sections.AddSection("Section 2", newSlide3); // سيتم إنهاء section1 عند newSlide2 وبعد ذلك سيبدأ section2
    
    pres.Save("pres-sections.pptx", SaveFormat.Pptx);
    
    pres.Sections.ReorderSectionWithSlides(section2, 0);
    pres.Save("pres-sections-moved.pptx", SaveFormat.Pptx);
    
    pres.Sections.RemoveSectionWithSlides(section2);
    
    pres.Sections.AppendEmptySection("Last empty section");
    
    pres.Save("pres-section-with-empty.pptx",SaveFormat.Pptx);
}
```


## **تغيير أسماء الأقسام**

بعد إنشاء قسم في عرض PowerPoint، قد تقرر تغيير اسمه. 

يعرض هذا المثال كيفية تغيير اسم قسم في عرض تقديمي باستخدام C# و Aspose.Slides:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ISection section = pres.Sections[0];
   section.Name = "My section";
}
```


## **الأسئلة الشائعة**

**هل يتم الحفاظ على الأقسام عند الحفظ بصيغة PPT (PowerPoint 97–2003)؟**

لا. لا تدعم صيغة PPT بيانات تعريف الأقسام، لذا يتم فقدان تجميع الأقسام عند الحفظ بامتداد .ppt.

**هل يمكن إخفاء قسم بالكامل؟**

لا. يمكن إخفاء الشرائح الفردية فقط. لا يمتلك القسم ككيان حالة “مخفي”.

**هل يمكنني العثور بسرعة على قسم باستخدام شريحة، والعكس، العثور على الشريحة الأولى للقسم؟**

نعم. يتم تعريف كل قسم بشكل فريد بواسطة شريحته البداية؛ بناءً على شريحة معينة يمكنك تحديد القسم الذي تنتمي إليه، وبالنسبة لأي قسم يمكنك الوصول إلى شريحته الأولى.