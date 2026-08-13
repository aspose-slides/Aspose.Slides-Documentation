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
description: "تعلم كيفية إضافة الرؤوس والتذييلات في عروض PowerPoint بصيغة PPT و PPTX و ODP في .NET باستخدام كل من واجهات برمجة التطبيقات القديمة والحديثة لـ Aspose.Slides."
---
{{% alert color="info" %}} 

تم إصدار نسخة جديدة من [Aspose.Slides for .NET API](/slides/ar/net/) الآن وتدعم هذه المنتج الواحد القدرة على إنشاء مستندات PowerPoint من الصفر وتعديل المستندات الموجودة.

{{% /alert %}} 
## **دعم الكود القديم**
لكي تستخدم الكود القديم الذي تم تطويره باستخدام إصدارات Aspose.Slides for .NET السابقة للنسخة 13.x، تحتاج إلى إجراء بعض التغييرات البسيطة في الكود الخاص بك وسيعمل الكود كما كان سابقًا. جميع الأصناف التي كانت موجودة في Aspose.Slides for .NET القديم تحت مساحات الأسماء Aspose.Slide و Aspose.Slides.Pptx تم دمجها الآن في مساحة اسم واحدة وهي Aspose.Slides. يرجى إلقاء نظرة على مقتطف الشيفرة البسيط التالي لإضافة ترويسية وتذييل في العرض التقديمي باستخدام Aspose.Slides API القديمة وتابع الخطوات التي تصف كيفية الانتقال إلى API المدمج الجديد.
## **نهج Aspose.Slides for .NET القديم**
```c#
PresentationEx sourcePres = new PresentationEx();

//تعيين خصائص رؤية الرأس والتذييل
sourcePres.UpdateSlideNumberFields = true;

//تحديث حقول التاريخ والوقت
sourcePres.UpdateDateTimeFields = true;

//إظهار عنصر نائبي التاريخ والوقت
sourcePres.HeaderFooterManager.IsDateTimeVisible = true;

//إظهار عنصر نائبي التذييل
sourcePres.HeaderFooterManager.IsFooterVisible = true;

//إظهار رقم الشريحة
sourcePres.HeaderFooterManager.IsSlideNumberVisible = true;

//تعيين رؤية الرأس والتذييل على شريحة العنوان
sourcePres.HeaderFooterManager.SetVisibilityOnTitleSlide(true);

//كتابة العرض التقديمي إلى القرص
sourcePres.Write("NewSource.pptx");
```

```c#
using Aspose.Slides;

//إنشاء العرض التقديمي
Presentation pres = new Presentation();

//الحصول على الشريحة الأولى
Slide sld = pres.GetSlideByPosition(1);

//الوصول إلى رأس / تذييل الشريحة
HeaderFooter hf = sld.HeaderFooter;

//تعيين رؤية رقم الصفحة
hf.PageNumberVisible = true;

//تعيين رؤية التذييل
hf.FooterVisible = true;

//تعيين رؤية الرأس
hf.HeaderVisible = true;

//تعيين رؤية التاريخ والوقت
hf.DateTimeVisible = true;

//تعيين تنسيق التاريخ والوقت
hf.DateTimeFormat = DateTimeFormat.DateTime_dMMMMyyyy;

//تعيين نص الرأس
hf.HeaderText = "Header Text";

//تعيين نص التذييل
hf.FooterText = "Footer Text";

//كتابة العرض التقديمي إلى القرص
pres.Write("HeadFoot.ppt");
```



## **نهج Aspose.Slides for .NET 13.x الجديد**
``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation sourcePres = new Presentation())
{
    //تعيين خصائص رؤية الرأس والتذييل
    sourcePres.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    //تحديث حقول التاريخ والوقت
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //إظهار عنصر نائبي التاريخ والوقت
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //إظهار عنصر نائبي التذييل
    sourcePres.HeaderFooterManager.SetAllFootersVisibility(true);
    
    //تعيين رؤية الرأس والتذييل على شريحة العنوان
    sourcePres.HeaderFooterManager.SetVisibilityOnAllTitleSlides(true);

    //كتابة العرض التقديمي إلى القرص
    sourcePres.Save("NewSource.pptx", SaveFormat.Pptx);
}
```