---
title: كيفية إضافة ترويسة وتذييل في عرض تقديمي
type: docs
weight: 20
url: /net/how-to-add-header-footer-in-a-presentation/
---

{{% alert color="primary" %}} 

تم إصدار [Aspose.Slides for .NET API](/slides/net/) جديدة والآن يدعم هذا المنتج الوحيد إمكانية إنشاء مستندات PowerPoint من الصفر وتحرير المستندات الحالية.

{{% /alert %}} 
## **دعم الكود القديم**
لاستخدام الكود القديم الذي تم تطويره مع إصدارات Aspose.Slides for .NET السابقة للإصدار 13.x، تحتاج إلى إجراء بعض التغييرات الطفيفة في كودك وسيعمل الكود كما كان سابقًا. جميع الفئات التي كانت موجودة في Aspose.Slides for .NET القديمة تحت أسماء الفضاء Aspose.Slide و Aspose.Slides.Pptx قد تم دمجها الآن في مساحة اسم Aspose.Slides واحدة. يرجى إلقاء نظرة على مقتطف الكود البسيط التالي لإضافة ترويسة وتذييل في العرض التقديمي في واجهة برمجة التطبيقات القديمة لـ Aspose.Slides واتباع الخطوات التي تصف كيفية الانتقال إلى واجهة برمجة التطبيقات الجديدة المدمجة.
## **طرق Aspose.Slides for .NET القديمة**
```c#
PresentationEx sourcePres = new PresentationEx();

//تعيين خصائص رؤية ترويسة وتذييل
sourcePres.UpdateSlideNumberFields = true;

//تحديث حقول التاريخ والوقت
sourcePres.UpdateDateTimeFields = true;

//عرض عنصر نائب التاريخ والوقت
sourcePres.HeaderFooterManager.IsDateTimeVisible = true;

//عرض عنصر نائب التذييل
sourcePres.HeaderFooterManager.IsFooterVisible = true;

//عرض رقم الشريحة
sourcePres.HeaderFooterManager.IsSlideNumberVisible = true;

//تعيين رؤية الترويسة والتذييل على الشريحة العنوان
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

//تعيين رؤية رقم الصفحة
hf.PageNumberVisible = true;

//تعيين رؤية التذييل
hf.FooterVisible = true;

//تعيين رؤية الترويسة
hf.HeaderVisible = true;

//تعيين رؤية التاريخ والوقت
hf.DateTimeVisible = true;

//تعيين تنسيق التاريخ والوقت
hf.DateTimeFormat = DateTimeFormat.DateTime_dMMMMyyyy;

//تعيين نص الترويسة
hf.HeaderText = "نص الترويسة";

//تعيين نص التذييل
hf.FooterText = "نص التذييل";

//كتابة العرض التقديمي إلى القرص
pres.Write("HeadFoot.ppt");
```



## **طرق Aspose.Slides for .NET 13.x الجديدة**
``` csharp
using (Presentation sourcePres = new Presentation())
{
    //تعيين خصائص رؤية ترويسة وتذييل
    sourcePres.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    //تحديث حقول التاريخ والوقت
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //عرض عنصر نائب التاريخ والوقت
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //عرض عنصر نائب التذييل
    sourcePres.HeaderFooterManager.SetAllFootersVisibility(true);
    
    //تعيين رؤية الترويسة والتذييل على الشريحة العنوان
    sourcePres.HeaderFooterManager.SetVisibilityOnAllTitleSlides(true);

    //كتابة العرض التقديمي إلى القرص
    sourcePres.Save("NewSource.pptx", SaveFormat.Pptx);
}
```