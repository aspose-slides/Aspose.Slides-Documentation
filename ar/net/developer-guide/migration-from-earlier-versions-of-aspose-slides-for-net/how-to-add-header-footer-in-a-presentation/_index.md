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
description: "تعلم كيفية إضافة رؤوس وتذييلات إلى عروض PowerPoint بصيغ PPT و PPTX و ODP في .NET باستخدام كلٍ من واجهات Aspose.Slides القديمة والحديثة."
---

{{% alert color="primary" %}} 
تم إصدار [Aspose.Slides for .NET API](/slides/ar/net/) جديد الآن ويدعم هذا المنتج القدرة على إنشاء مستندات PowerPoint من الصفر وتعديل المستندات الموجودة.
{{% /alert %}} 
## **الدعم للشفرة القديمة**
من أجل استخدام الشفرة القديمة التي تم تطويرها باستخدام إصدارات Aspose.Slides for .NET التي تسبق 13.x، تحتاج إلى إجراء بعض التغييرات الطفيفة في الكود وسيعمل الكود كما كان مسبقًا. جميع الفئات التي كانت موجودة في Aspose.Slides for .NET القديم تحت مساحات الأسماء Aspose.Slide و Aspose.Slides.Pptx تم الآن دمجها في مساحة الاسم الواحدة Aspose.Slides. يرجى إلقاء نظرة على المقتطف البسيط التالي لإضافة رأس وتذييل في العرض التقديمي باستخدام Aspose.Slides API القديمة واتبع الخطوات التي تصف كيفية التحويل إلى الواجهة المدمجة الجديدة.
## **النهج القديم لـ Aspose.Slides for .NET**
```c#
PresentationEx sourcePres = new PresentationEx();

//تعيين خصائص رؤية رأس وتذييل الشريحة
//تحديث حقول التاريخ والوقت
//إظهار عنصر نائب للتاريخ والوقت
//إظهار عنصر نائب للتذييل
//إظهار رقم الشريحة
//تعيين رؤية رأس وتذييل الشريحة في شريحة العنوان
//كتابة العرض التقديمي إلى القرص
sourcePres.UpdateSlideNumberFields = true;

//Update the Date Time Fields
sourcePres.UpdateDateTimeFields = true;

//Show date time placeholder
sourcePres.HeaderFooterManager.IsDateTimeVisible = true;

//Show the footer place holder
sourcePres.HeaderFooterManager.IsFooterVisible = true;

//Show Slide Number
sourcePres.HeaderFooterManager.IsSlideNumberVisible = true;

//Set the  header footer visibility on Title Slide
sourcePres.HeaderFooterManager.SetVisibilityOnTitleSlide(true);

//Write the presentation to the disk
sourcePres.Write("NewSource.pptx");
```

```c#
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


## **النهج الجديد لـ Aspose.Slides for .NET 13.x**
``` csharp
using (Presentation sourcePres = new Presentation())
{
    //تعيين خصائص رؤية رأس وتذييل الشريحة
    sourcePres.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    //تحديث حقول التاريخ والوقت
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //إظهار عنصر نائب للتاريخ والوقت
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //إظهار عنصر نائب للتذييل
    sourcePres.HeaderFooterManager.SetAllFootersVisibility(true);
    
    //تعيين  رؤية رأس وتذييل الشريحة في شريحة العنوان
    sourcePres.HeaderFooterManager.SetVisibilityOnAllTitleSlides(true);

    //كتابة العرض التقديمي إلى القرص
    sourcePres.Save("NewSource.pptx", SaveFormat.Pptx);
}
```
