---
title: كيفية إضافة رؤوس وتذييلات إلى العروض التقديمية في .NET
linktitle: إضافة رأس وتذييل
type: docs
weight: 20
url: /ar/net/how-to-add-header-footer-in-a-presentation/
keywords:
- ترحيل
- إضافة رأس
- إضافة تذييل
- شفرة قديمة
- شفرة حديثة
- نهج قديم
- نهج حديث
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية إضافة رؤوس وتذييلات في عروض PowerPoint بصيغ PPT و PPTX و ODP في .NET باستخدام كل من واجهات Aspose.Slides القديمة والحديثة."
---

{{% alert color="primary" %}} 
تم إصدار [واجهة برمجة تطبيقات Aspose.Slides for .NET](/slides/ar/net/) جديدة الآن، وتدعم هذه المنتج الوحيد القدرة على إنشاء مستندات PowerPoint من الصفر وتعديل المستندات الموجودة.
{{% /alert %}} 
## **دعم الشيفرة القديمة**
للاستخدام الشيفرة القديمة التي تم تطويرها باستخدام إصدارات Aspose.Slides for .NET السابقة للنسخة 13.x، تحتاج إلى إجراء بعض التعديلات الطفيفة في شفرتك وسوف تعمل الشيفرة كما كانت سابقًا. جميع الفئات التي كانت موجودة في Aspose.Slides for .NET القديمة تحت مساحتي الاسم Aspose.Slide و Aspose.Slides.Pptx تم دمجها الآن في مساحة الاسم الوحيدة Aspose.Slides. يرجى إلقاء نظرة على مقتطف الشيفرة البسيط التالي لإضافة ترويسة وتذييل في العرض التقديمي باستخدام Aspose.Slides API القديمة، واتباع الخطوات التي تصف كيفية الانتقال إلى API المدمجة الجديدة.
## **النهج القديم لـ Aspose.Slides for .NET**
```c#
PresentationEx sourcePres = new PresentationEx();

//تعيين خصائص إظهار الترويسة والتذييل
sourcePres.UpdateSlideNumberFields = true;

//تحديث حقول التاريخ والوقت
sourcePres.UpdateDateTimeFields = true;

//إظهار عنصر نائب التاريخ والوقت
sourcePres.HeaderFooterManager.IsDateTimeVisible = true;

//إظهار عنصر نائب التذييل
sourcePres.HeaderFooterManager.IsFooterVisible = true;

//إظهار رقم الشريحة
sourcePres.HeaderFooterManager.IsSlideNumberVisible = true;

//تعيين إظهار الترويسة والتذييل في شريحة العنوان
sourcePres.HeaderFooterManager.SetVisibilityOnTitleSlide(true);

//كتابة العرض التقديمي إلى القرص
sourcePres.Write("NewSource.pptx");
```

```c#
//إنشاء العرض التقديمي
Presentation pres = new Presentation();

//الحصول على الشريحة الأولى
Slide sld = pres.GetSlideByPosition(1);

//الوصول إلى الترويسة / التذييل في الشريحة
HeaderFooter hf = sld.HeaderFooter;

//تعيين إظهار رقم الصفحة
hf.PageNumberVisible = true;

//تعيين إظهار التذييل
hf.FooterVisible = true;

//تعيين إظهار الترويسة
hf.HeaderVisible = true;

//تعيين إظهار التاريخ والوقت
hf.DateTimeVisible = true;

//تعيين تنسيق التاريخ والوقت
hf.DateTimeFormat = DateTimeFormat.DateTime_dMMMMyyyy;

//تعيين نص الترويسة
hf.HeaderText = "Header Text";

//تعيين نص التذييل
hf.FooterText = "Footer Text";

//كتابة العرض التقديمي إلى القرص
pres.Write("HeadFoot.ppt");
```


## **النهج الجديد لـ Aspose.Slides for .NET 13.x**
``` csharp
using (Presentation sourcePres = new Presentation())
{
    //تعيين خصائص إظهار الترويسة والتذييل
    sourcePres.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    //تحديث حقول التاريخ والوقت
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //إظهار عنصر نائب التاريخ والوقت
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //إظهار عنصر نائب التذييل
    sourcePres.HeaderFooterManager.SetAllFootersVisibility(true);
    
    //تعيين إظهار الترويسة والتذييل في شريحة العنوان
    sourcePres.HeaderFooterManager.SetVisibilityOnAllTitleSlides(true);

    //كتابة العرض التقديمي إلى القرص
    sourcePres.Save("NewSource.pptx", SaveFormat.Pptx);
}
```
