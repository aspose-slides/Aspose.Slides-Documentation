---
title: قسم الشريحة
type: docs
weight: 100
url: /ar/net/slide-section/
keywords: "إنشاء قسم، إضافة قسم، تحرير اسم القسم، عرض PowerPoint، C#، Csharp، .NET، Aspose.Slides"
description: "إضافة وتحرير قسم في عرض PowerPoint باستخدام C# أو .NET"
---

مع Aspose.Slides لـ .NET، يمكنك تنظيم عرض PowerPoint إلى أقسام. يمكنك إنشاء أقسام تحتوي على شرائح محددة.

قد ترغب في إنشاء أقسام واستخدامها لتنظيم أو تقسيم الشرائح في عرض تقديمي إلى أجزاء منطقية في هذه الحالات:

- عندما تعمل على عرض تقديمي كبير مع أشخاص آخرين أو فريق - وتحتاج إلى تعيين شرائح معينة لزميل أو بعض أعضاء الفريق.
- عندما تتعامل مع عرض تقديمي يحتوي على العديد من الشرائح - وتواجه صعوبة في إدارة محتوياته أو تحريرها دفعة واحدة.

من المثالي أن تقوم بإنشاء قسم يضم شرائح مشابهة - حيث تشترك الشرائح في شيء ما أو يمكن أن توجد في مجموعة بناءً على قاعدة - وتعطي القسم اسمًا يصف الشرائح الموجودة فيه.

## إنشاء أقسام في العروض التقديمية

لإضافة قسم سيحتوي على شرائح في عرض تقديمي، يوفر Aspose.Slides لـ .NET أسلوب AddSection الذي يتيح لك تحديد اسم القسم الذي تنوي إنشائه والشريحة التي سيبدأ منها القسم.

يوضح لك هذا الرمز المثال كيفية إنشاء قسم في عرض تقديمي باستخدام C#:

```c#
using (Presentation pres = new Presentation())
{
    ISlide defaultSlide = pres.Slides[0];
    ISlide newSlide1 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide2 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide3 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide4 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

    ISection section1 = pres.Sections.AddSection("قسم 1", newSlide1);
    ISection section2 = pres.Sections.AddSection("قسم 2", newSlide3); // سيتم إنهاء section1 عند newSlide2 وبعده سيبدأ section2   
    
    pres.Save("pres-sections.pptx", SaveFormat.Pptx);
    
    pres.Sections.ReorderSectionWithSlides(section2, 0);
    pres.Save("pres-sections-moved.pptx", SaveFormat.Pptx);
    
    pres.Sections.RemoveSectionWithSlides(section2);
    
    pres.Sections.AppendEmptySection("آخر قسم فارغ");
    
    pres.Save("pres-section-with-empty.pptx",SaveFormat.Pptx);
}
```

## تغيير أسماء الأقسام

بعد إنشاء قسم في عرض PowerPoint، قد تقرر تغيير اسمه.

يوضح لك هذا الرمز المثال كيفية تغيير اسم قسم في عرض تقديمي باستخدام C# مع Aspose.Slides:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ISection section = pres.Sections[0];
   section.Name = "قسمي";
}
```