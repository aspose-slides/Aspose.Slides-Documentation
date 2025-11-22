---
title: قسم الشريحة
type: docs
weight: 100
url: /ar/net/slide-section/
keywords: "إنشاء قسم, إضافة قسم, تعديل اسم القسم, عرض PowerPoint, C#, Csharp, .NET, Aspose.Slides"
description: "إضافة وتعديل القسم في عرض PowerPoint باستخدام C# أو .NET"
---

مع Aspose.Slides for .NET، يمكنك تنظيم عرض PowerPoint إلى أقسام. يمكنك إنشاء أقسام تحتوي على شرائح محددة.  

قد تحتاج إلى إنشاء أقسام واستخدامها لتنظيم أو تقسيم الشرائح في عرض تقديمي إلى أجزاء منطقية في الحالات التالية:

- عندما تعمل على عرض تقديمي كبير مع أشخاص آخرين أو فريق—وتحتاج إلى تعيين شرائح معينة لزميل أو بعض أعضاء الفريق. 
- عندما تتعامل مع عرض يحتوي على العديد من الشرائح—وتكافح لإدارة محتوياته أو تعديلها دفعة واحدة.  

من المثالي أن تنشئ قسمًا يضم شرائح متشابهة—الشرائح لها شيء مشترك أو يمكن تجميعها بناءً على قاعدة—وتعطي القسم اسمًا يصف الشرائح داخله.  

## **إنشاء أقسام في العروض**

لإضافة قسم سيحوي شرائح في عرض تقديمي، يوفر Aspose.Slides for .NET طريقة AddSection التي تتيح لك تحديد اسم القسم الذي تريد إنشاؤه والشرائح التي يبدأ منها القسم.  

هذا المثال البرمجي يوضح كيفية إنشاء قسم في عرض تقديمي باستخدام C#:
```c#
using (Presentation pres = new Presentation())
{
    ISlide defaultSlide = pres.Slides[0];
    ISlide newSlide1 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide2 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide3 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide4 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

    ISection section1 = pres.Sections.AddSection("Section 1", newSlide1);
    ISection section2 = pres.Sections.AddSection("Section 2", newSlide3); // سيتم انتهاء القسم 1 عند newSlide2 وبعده سيبدأ القسم 2   
    
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

هذا المثال البرمجي يوضح كيفية تغيير اسم القسم في عرض تقديمي باستخدام C# وAspose.Slides:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ISection section = pres.Sections[0];
   section.Name = "My section";
}
```


## **الأسئلة الشائعة**

**هل يتم حفظ الأقسام عند الحفظ بصيغة PPT (PowerPoint 97–2003)؟**  

لا. لا تدعم صيغة PPT بيانات تعريف الأقسام، لذا يتم فقدان تجميع الأقسام عند الحفظ بصيغة .ppt.  

**هل يمكن إخفاء قسم كامل؟**  

لا. يمكن إخفاء شرائح فردية فقط. لا يملك القسم ككيان حالة "مخفى".  

**هل يمكنني العثور سريعًا على قسم عبر شريحة، والعكس، العثور على أول شريحة في قسم؟**  

نعم. يُعرّف القسم بشكل فريد بواسطة الشريحة التي يبدأ منها؛ عند إعطائك شريحة يمكنك تحديد القسم الذي تنتمي إليه، وعند إعطائك قسم يمكنك الوصول إلى أول شريحة فيه.