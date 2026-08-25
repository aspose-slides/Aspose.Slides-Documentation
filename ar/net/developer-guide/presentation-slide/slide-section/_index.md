---
title: إدارة أقسام الشرائح في العروض التقديمية في .NET
linktitle: قسم الشريحة
type: docs
weight: 100
url: /ar/net/slide-section/
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
- .NET
- C#
- Aspose.Slides
description: "إدارة أقسام الشرائح باستخدام Aspose.Slides for .NET: إنشاء، إعادة تسمية، إعادة ترتيب، استرجاع، ومعالجة شرائح الأقسام في عروض PPTX التقديمية."
---
## **مقدمة**

تنظم الأقسام الشرائح المتتالية في مجموعات مسماة دون تغيير محتوى الشريحة. باستخدام Aspose.Slides for .NET، يمكنك إنشاء الأقسام وإعادة ترتيبها وإعادة تسميتها وفحصها وإزالتها عبر الخاصية [Presentation.Sections](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/sections/) .

تكون الأقسام مفيدة بشكل خاص عندما:
- يحتاج عرض تقديمي كبير إلى تقسيمه إلى مواضيع أو فصول منطقية؛
- يتم تعيين مجموعات مختلفة من الشرائح إلى متعاونين مختلفين؛
- تحتاج الشرائح إلى المعالجة أو النقل أو الدمج كمجموعات.

## **إنشاء وإدارة الأقسام**

استخدم [ISectionCollection.AddSection](https://reference.aspose.com/slides/ar/net/aspose.slides/sectioncollection/addsection/) لإنشاء قسم عن طريق تحديد اسمه والشريحة الابتدائية. تقوم Aspose.Slides بتحديد الشرائح التي تنتمي إلى القسم بناءً على هيكل القسم الحالي للعرض.

تتيح لك نفس [ISectionCollection](https://reference.aspose.com/slides/ar/net/aspose.slides/isectioncollection/) أيضًا:
- نقل قسم مع شرائحه باستخدام [ISectionCollection.ReorderSectionWithSlides](https://reference.aspose.com/slides/ar/net/aspose.slides/sectioncollection/reordersectionwithslides/) ;
- إزالة تعريف القسم فقط باستخدام [ISectionCollection.RemoveSection](https://reference.aspose.com/slides/ar/net/aspose.slides/sectioncollection/removesection/)، مع الحفاظ على شرائحه ;
- إزالة قسم مع شرائحه باستخدام [ISectionCollection.RemoveSectionWithSlides](https://reference.aspose.com/slides/ar/net/aspose.slides/sectioncollection/removesectionwithslides/) ;
- إضافة قسم فارغ في النهاية باستخدام [ISectionCollection.AppendEmptySection](https://reference.aspose.com/slides/ar/net/aspose.slides/sectioncollection/appendemptysection/) .

المثال التالي ينشئ قسمين، ينقل أحدهما، يزيله مع شرائحه، ويضيف قسمًا فارغًا في النهاية:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var titleSlide = presentation.Slides[0];
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var resultsSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

presentation.Sections.AddSection("Introduction", titleSlide);
var resultsSection = presentation.Sections.AddSection("Results", resultsSlide);

presentation.Sections.ReorderSectionWithSlides(resultsSection, 0);
presentation.Sections.RemoveSectionWithSlides(resultsSection);
presentation.Sections.AppendEmptySection("Appendix");
```

بعد هذه العمليات، يحتوي العرض التقديمي على قسم `Introduction` مع شرائحه وقسم فارغ `Appendix`. تم إزالة قسم `Results` وشرائحه.

## **إعادة تسمية الأقسام**

لإعادة تسمية قسم، اضبط خاصية [ISection.Name](https://reference.aspose.com/slides/ar/net/aspose.slides/isection/name/) الخاصة به. تبقى شرائح القسم وموقعه دون تغيير.

المثال التالي ينشئ قسمًا ويغير اسمه:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var section = presentation.Sections.AddSection("Overview", slide);
section.Name = "Introduction";
```

## **استخراج الشرائح من الأقسام**

خاصية [Presentation.Sections](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/sections/) تعيد كائنًا من نوع [ISectionCollection](https://reference.aspose.com/slides/ar/net/aspose.slides/isectioncollection/) يمكنك تعداده. لكل [ISection](https://reference.aspose.com/slides/ar/net/aspose.slides/isection/)، استدعِ [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/ar/net/aspose.slides/isection/getslideslistofsection/) للحصول على الشرائح التي تنتمي إليه حاليًا. تُعيد الطريقة كائنًا من نوع [ISectionSlideCollection](https://reference.aspose.com/slides/ar/net/aspose.slides/isectionslidecollection/)، الذي يوفر عددًا، وصولًا بالفهرس، وتعدادًا.

المثال التالي ينشئ قسمين مملئين وقسمًا فارغًا، ثم يطبع لكل قسم [name](https://reference.aspose.com/slides/ar/net/aspose.slides/isection/name/)، [identifier](https://reference.aspose.com/slides/ar/net/aspose.slides/isection/sectionid/)، [starting slide](https://reference.aspose.com/slides/ar/net/aspose.slides/isection/startedfromslide/)، عدد الشرائح، وأرقام الشرائح. يستخدم فهرس المجموعة لقراءة الشريحة الأولى و`foreach` لمعالجة كل شريحة. بالنسبة للقسم الفارغ، تكون المجموعة المرتجعة عددها صفر، ولا يتم الوصول إلى الفهرس، ولا يجري أي تكرار خلال التعداد.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var firstSlide = presentation.Slides[0];
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var thirdSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

presentation.Sections.AddSection("Introduction", firstSlide);
presentation.Sections.AddSection("Details", thirdSlide);
presentation.Sections.AppendEmptySection("Appendix");

foreach (var section in presentation.Sections)
{
    var sectionSlides = section.GetSlidesListOfSection();
    var startingSlide = section.StartedFromSlide == null ? "none" : section.StartedFromSlide.SlideNumber.ToString();

    Console.WriteLine($"Section: {section.Name}");
    Console.WriteLine($"ID: {section.SectionId}");
    Console.WriteLine($"Starting slide: {startingSlide}");
    Console.WriteLine($"Slide count: {sectionSlides.Count}");

    if (sectionSlides.Count > 0)
    {
        Console.WriteLine($"First slide via indexer: {sectionSlides[0].SlideNumber}");
    }

    Console.Write("Slide numbers:");
    foreach (var slide in sectionSlides)
    {
        Console.Write($" {slide.SlideNumber}");
    }
    Console.WriteLine();
}
```

يتم تحديد عضوية القسم بناءً على هيكل أقسام العرض التقديمي. لا تقم بحساب نطاق القسم يدويًا من خلال [ISection.StartedFromSlide](https://reference.aspose.com/slides/ar/net/aspose.slides/isection/startedfromslide/)، وفهارس الشرائح، والشريحة الابتدائية للقسم التالي.

يمكن للتعديلات الهيكلية أن تغير كلًا من الشرائح المرتجعة لقسم معين وأرقام شرائحه. يتضمن ذلك إعادة ترتيب الشرائح، استنساخ شريحة داخل قسم، نقل قسم مع شرائحه، إزالة شرائح، وإزالة أقسام. المثال التالي يستدعي [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/ar/net/aspose.slides/isection/getslideslistofsection/) بعد كل تغيير من هذه التغييرات بدلاً من الاعتماد على افتراضات حول حدود القسم السابقة.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var firstSlide = presentation.Slides[0];
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var thirdSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);
var firstSection = presentation.Sections.AddSection("First", firstSlide);
var secondSection = presentation.Sections.AddSection("Second", thirdSlide);

static void PrintSectionSlides(string label, ISection section)
{
    var sectionSlides = section.GetSlidesListOfSection();
    Console.Write($"{label} ({sectionSlides.Count} slides):");
    foreach (var slide in sectionSlides)
    {
        Console.Write($" {slide.SlideNumber}");
    }
    Console.WriteLine();
}

PrintSectionSlides("Initially", firstSection);

var slidesBeforeClone = firstSection.GetSlidesListOfSection();
presentation.Slides.AddClone(slidesBeforeClone[0], firstSection);
PrintSectionSlides("After cloning into the section", firstSection);

var slidesBeforeReorder = firstSection.GetSlidesListOfSection();
var firstSectionPosition = slidesBeforeReorder[0].SlideNumber - 1;
presentation.Slides.Reorder(firstSectionPosition, slidesBeforeReorder[slidesBeforeReorder.Count - 1]);
PrintSectionSlides("After reordering slides", firstSection);

presentation.Sections.ReorderSectionWithSlides(firstSection, 1);
PrintSectionSlides("After moving the section", firstSection);

var slidesBeforeRemoval = firstSection.GetSlidesListOfSection();
presentation.Slides.Remove(slidesBeforeRemoval[0]);
PrintSectionSlides("After removing a slide", firstSection);

presentation.Sections.RemoveSectionWithSlides(secondSection);
foreach (var section in presentation.Sections)
{
    PrintSectionSlides("Remaining section", section);
}
```

استدعِ [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/ar/net/aspose.slides/isection/getslideslistofsection/) مرة أخرى كلما تم إعادة ترتيب الشرائح أو الأقسام أو استنساخها أو نقلها أو إزالتها. هذا يحافظ على توافق المعالجة اللاحقة مع هيكل العرض التقديمي الحالي.

تنسيق PPT (PowerPoint 97–2003) لا يحافظ على بيانات تعريف الأقسام. استخدم سير العمل هذا مع تنسيق يدعم الأقسام، مثل PPTX؛ التحويل إلى PPT يزيل هيكل الأقسام المطلوب للتعداد لاحقًا.

## **الأسئلة المتكررة**

**هل يتم الحفاظ على الأقسام عند الحفظ بتنسيق PPT (PowerPoint 97–2003)؟**

لا. تنسيق PPT لا يدعم بيانات تعريف الأقسام، لذا يتم فقدان تجميع الأقسام عند الحفظ بصيغة .ppt.

**هل يمكن إخفاء قسم كامل؟**

لا. لا يمتلك القسم حالة رؤية. لإخفاء محتوياته، اضبط خاصية [ISlide.Hidden](https://reference.aspose.com/slides/ar/net/aspose.slides/islide/hidden/) لكل شريحة في القسم.

**كيف يمكنني العثور على القسم الذي يحتوي على شريحة معينة؟**

قم بتعداد [Presentation.Sections](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/sections/)، استدعِ [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/ar/net/aspose.slides/isection/getslideslistofsection/) لكل قسم، وقارن الشرائح المرتجعة مع الشريحة المستهدفة. بالنسبة لقسم غير فارغ، تُعيد [ISection.StartedFromSlide](https://reference.aspose.com/slides/ar/net/aspose.slides/isection/startedfromslide/) شريحته الأولى؛ بالنسبة لقسم فارغ، تُعيد `null`.