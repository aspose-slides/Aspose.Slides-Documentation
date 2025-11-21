---
title: كيفيّة إضافة رؤوس وتذييلات إلى العروض التقديمية في .NET
linktitle: إضافة رأس وتذييل
type: docs
weight: 20
url: /ar/net/how-to-add-header-footer-in-a-presentation/
keywords:
- ترحيل
- إضافة رأس
- إضافة تذييل
- كود قديم
- كود حديث
- نهج قديم
- نهج حديث
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية إضافة رؤوس وتذييلات في عروض PowerPoint PPT و PPTX و ODP في .NET باستخدام كل من واجهات برمجة التطبيقات القديمة والحديثة لـ Aspose.Slides."
---

{{% alert color="primary" %}} 

اُصدرت الآن نسخة جديدة من [Aspose.Slides for .NET API](/slides/ar/net/) وتدعم الآن هذه الأداة الوحيد القدرة على إنشاء مستندات PowerPoint من الصفر وتحرير المستندات الموجودة.

{{% /alert %}} 
## **دعم الكود القديم**
لاستخدام الكود القديم المطور باستخدام إصدارات Aspose.Slides for .NET التي تسبق 13.x، تحتاج إلى إجراء بعض التعديلات الطفيفة في الكود وسيعمل كما كان من قبل. جميع الفئات التي كانت موجودة في الإصدارات القديمة من Aspose.Slides for .NET تحت مساحات الأسماء Aspose.Slide وAspose.Slides.Pptx تم الآن دمجها في مساحة الاسم الوحيدة Aspose.Slides. يرجى إلقاء نظرة على مقتطف الكود البسيط التالي لإضافة ترويسة وتذييل في العرض التقديمي باستخدام API القديم لـ Aspose.Slides واتباع الخطوات التي تصف كيفية الانتقال إلى API المدمج الجديد.
## **نهج Aspose.Slides for .NET القديم**
```c#
PresentationEx sourcePres = new PresentationEx();

//تعيين خصائص رؤية الرأس والتذييل
sourcePres.UpdateSlideNumberFields = true;

//تحديث حقول التاريخ والوقت
sourcePres.UpdateDateTimeFields = true;

//إظهار العنصر النائب للتاريخ والوقت
sourcePres.HeaderFooterManager.IsDateTimeVisible = true;

//إظهار العنصر النائب للتذييل
sourcePres.HeaderFooterManager.IsFooterVisible = true;

//إظهار رقم الشريحة
sourcePres.HeaderFooterManager.IsSlideNumberVisible = true;

//تعيين رؤية الرأس والتذييل في شريحة العنوان
sourcePres.HeaderFooterManager.SetVisibilityOnTitleSlide(true);

//كتابة العرض التقديمي إلى القرص
sourcePres.Write("NewSource.pptx");
```

```c#
//إنشاء العرض التقديمي
Presentation pres = new Presentation();

//الحصول على الشريحة الأولى
Slide sld = pres.GetSlideByPosition(1);

//الوصول إلى الترويسة / التذييل للشريحة
HeaderFooter hf = sld.HeaderFooter;

//تعيين ظهور رقم الصفحة
hf.PageNumberVisible = true;

//تعيين ظهور التذييل
hf.FooterVisible = true;

//تعيين ظهور الترويسة
hf.HeaderVisible = true;

//تعيين ظهور التاريخ والوقت
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




## **نهج Aspose.Slides for .NET 13.x الجديد**
```csharp
using (Presentation sourcePres = new Presentation())
{
    //تعيين خصائص رؤية الرأس والتذييل
    sourcePres.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    //تحديث حقول التاريخ والوقت
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //إظهار عنصر نائب للتاريخ والوقت
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //إظهار عنصر نائب للتذييل
    sourcePres.HeaderFooterManager.SetAllFootersVisibility(true);
    
    //تعيين رؤية الرأس والتذييل في شريحة العنوان
    sourcePres.HeaderFooterManager.SetVisibilityOnAllTitleSlides(true);

    //كتابة العرض التقديمي إلى القرص
    sourcePres.Save("NewSource.pptx", SaveFormat.Pptx);
}
```
