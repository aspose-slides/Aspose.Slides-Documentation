---
title: "كيفية إضافة رؤوس وتذييلات إلى العروض التقديمية في .NET"
linktitle: "إضافة رأس وتذييل"
type: docs
weight: 20
url: /ar/net/how-to-add-header-footer-in-a-presentation/
keywords:
- الترحيل
- إضافة رأس
- إضافة تذييل
- الكود القديم
- الكود الحديث
- نهج قديم
- نهج حديث
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعرف على كيفية إضافة رؤوس وتذييلات في عروض PowerPoint بصيغة PPT و PPTX و ODP في .NET باستخدام كل من API القديمة والحديثة لـ Aspose.Slides."
---

{{% alert color="primary" %}} 
تم إصدار [Aspose.Slides for .NET API](/slides/ar/net/) جديدة الآن، ويتيح هذا المنتج الواحد إمكانية إنشاء مستندات PowerPoint من الصفر وتعديل المستندات الموجودة.
{{% /alert %}} 
## **دعم الكود القديم**
لكي تستخدم الكود القديم المطور باستخدام إصدارات Aspose.Slides for .NET السابقة للـ 13.x، تحتاج إلى إجراء بعض التعديلات الطفيفة في كودك بحيث يعمل كما كان سابقًا. جميع الفئات التي كانت موجودة في Aspose.Slides for .NET القديم تحت مساحات الاسم Aspose.Slide و Aspose.Slides.Pptx تم دمجها الآن في مساحة الاسم Aspose.Slides الموحدة. يرجى إلقاء نظرة على المقتطف البرمجي البسيط التالي لإضافة رأس وتذييل في العرض التقديمي باستخدام واجهة Aspose.Slides القديمة واتبع الخطوات التي تصف كيفية الترقي إلى الواجهة المدمجة الجديدة.
## **نهج Aspose.Slides for .NET القديم**
```c#
PresentationEx sourcePres = new PresentationEx();

//إعداد خصائص رؤية رأس وتذييل الصفحة
sourcePres.UpdateSlideNumberFields = true;

//تحديث حقول التاريخ والوقت
sourcePres.UpdateDateTimeFields = true;

//إظهار العنصر النائب للتاريخ والوقت
sourcePres.HeaderFooterManager.IsDateTimeVisible = true;

//إظهار العنصر النائب للتذييل
sourcePres.HeaderFooterManager.IsFooterVisible = true;

//إظهار رقم الشريحة
sourcePres.HeaderFooterManager.IsSlideNumberVisible = true;

//ضبط رؤية رأس وتذييل الصفحة على شريحة العنوان
sourcePres.HeaderFooterManager.SetVisibilityOnTitleSlide(true);

//كتابة العرض التقديمي إلى القرص
sourcePres.Write("NewSource.pptx");
```

```c#
//إنشاء العرض التقديمي
Presentation pres = new Presentation();

//الحصول على الشريحة الأولى
Slide sld = pres.GetSlideByPosition(1);

//الوصول إلى رأس / تذييل الشريحة
HeaderFooter hf = sld.HeaderFooter;

//تعيين إظهار رقم الصفحة
hf.PageNumberVisible = true;

//تعيين إظهار التذييل
hf.FooterVisible = true;

//تعيين إظهار الرأس
hf.HeaderVisible = true;

//تعيين إظهار التاريخ والوقت
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
using (Presentation sourcePres = new Presentation())
{
    //إعداد خصائص رؤية رأس وتذييل الصفحة
    sourcePres.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    //تحديث حقول التاريخ والوقت
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //إظهار العنصر النائب للتاريخ والوقت
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //إظهار العنصر النائب للتذييل
    sourcePres.HeaderFooterManager.SetAllFootersVisibility(true);
    
    //ضبط رؤية رأس وتذييل الصفحة على شريحة العنوان
    sourcePres.HeaderFooterManager.SetVisibilityOnAllTitleSlides(true);

    //كتابة العرض التقديمي إلى القرص
    sourcePres.Save("NewSource.pptx", SaveFormat.Pptx);
}
```
