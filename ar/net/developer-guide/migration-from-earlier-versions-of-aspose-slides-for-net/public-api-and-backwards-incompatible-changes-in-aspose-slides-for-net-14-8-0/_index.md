---
title: التغييرات العامة في API والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ .NET 14.8.0
linktitle: Aspose.Slides لـ .NET 14.8.0
type: docs
weight: 100
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/
keywords:
- الهجرة
- كود قديم
- كود حديث
- نهج تقليدي
- نهج حديث
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: استعرض تحديثات API العامة والتغييرات الجذرية في Aspose.Slides لـ .NET لتتمكن من ترحيل حلول عروض PowerPoint (PPT, PPTX) وODP بسلاسة.
---
{{% alert color="info" %}} 

تُدرج هذه الصفحة جميع الفئات، الأساليب، الخصائص وما إلى ذلك التي تم [added](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) أو [removed](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) والتي تم إزالتها، بالإضافة إلى التغييرات الأخرى التي تم تقديمها مع Aspose.Slides for .NET 14.8.0 API.

{{% /alert %}} 
## **التغييرات في واجهة برمجة التطبيقات العامة**
### **الخصائص التي تم تغييرها**
#### **أضيفت واجهة IVbaProject، تم تغيير خاصية Presentation.VbaProject**

تم استبدال خاصية VbaProject في الفئة Presentation. بدلاً من تمثيل البايت الخام لمشروع VBA الموجود في خاصية VbaProject، تمت إضافة تنفيذ للواجهة الجديدة IVbaProject.

استخدم خاصية IVbaProject لإدارة مشاريع VBA المضمَّنة في العرض التقديمي. يمكنك إضافة مراجع مشاريع جديدة، تحرير الوحدات الحالية وإنشاء وحدات جديدة.

كما يمكنك إنشاء مشروع VBA جديد باستخدام الفئة VbaProject التي تنفّذ واجهة IVbaProject.

المثال التالي يوضح إنشاء مشروع VBA بسيط يحتوي على وحدة واحدة وإضافة مرجعين مطلوبين إلى المكتبات.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;


 using (Presentation pres = new Presentation())

{

    // إنشاء مشروع VBA جديد

    pres.VbaProject = new VbaProject();

    // إضافة وحدة فارغة إلى مشروع VBA

    IVbaModule module = pres.VbaProject.Modules.AddEmptyModule("Module");

    // تعيين شفرة المصدر للوحدة

    module.SourceCode =

        @"Sub Test(oShape As Shape)

            MsgBox ""Test""

        End Sub";

    // إنشاء مرجع إلى <stdole>

    VbaReferenceOleTypeLib stdoleReference =

        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // إنشاء مرجع إلى Office

    VbaReferenceOleTypeLib officeReference =

        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // إضافة مراجع إلى مشروع VBA

    pres.VbaProject.References.Add(stdoleReference);

    pres.VbaProject.References.Add(officeReference);

    pres.Save("test.pptm", SaveFormat.Pptm);

}
``` 

يوضح هذا المثال كيفية نسخ مشروع VBA من عرض تقديمي موجود إلى عرض تقديمي جديد.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Vba;


 using (Presentation pres1 = new Presentation("PresentationWithMacroses.pptm"), pres2 = new Presentation())

{

    pres2.VbaProject = new VbaProject(pres1.VbaProject.ToBinary());

}
``` 
### **Added Interfaces, Properties and Enumeration Options**
#### **أضيفت خاصية Aspose.Slides.Charts.IChartSeries.Overlap**

تحدد خاصية Aspose.Slides.Charts.IChartSeries.Overlap مقدار تداخل القضبان والأعمدة في المخططات الثنائية الأبعاد (يتراوح بين -100 إلى 100).

هذه الخاصية ليست فقط لهذه السلسلة بل لجميع السلاسل في مجموعة السلاسل الأصلية – وهي إسقاط لخاصية المجموعة المناسبة. وبالتالي فإن هذه الخاصية للقراءة فقط.

- استخدم خاصية ParentSeriesGroup للوصول إلى مجموعة السلاسل الأصلية.  
- استخدم خاصية ParentSeriesGroup.Overlap للقراءة/الكتابة لتغيير القيمة.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;


 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

   IChartSeriesCollection series = chart.ChartData.Series;

   if (series[0].Overlap == 0)

      {

            series[0].ParentSeriesGroup.Overlap = -30;

      }

}
``` 
#### **أضيفت خاصية Aspose.Slides.Charts.IChartSeriesGroup.Overlap**

تحدد خاصية Aspose.Slides.Charts.IChartSeriesGroup.Overlap مقدار تداخل القضبان والأعمدة في المخططات الثنائية الأبعاد (من -100 إلى 100).

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;




using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

   IChartSeriesCollection series = chart.ChartData.Series;

   series[0].ParentSeriesGroup.Overlap = -30;

}
``` 
#### **أضيفت قيمة Enum Aspose.Slides.Charts.ShapeThumbnailBounds.Appearance**

تسمح طريقة إنشاء مصغّر الشكل هذه بإنشاء مصغّر الشكل ضمن حدود مظهره. تأخذ جميع تأثيرات الشكل في الاعتبار. يتم تقييد مصغّر الشكل المُنشأ بحدود الشريحة.

``` csharp
using Aspose.Slides;

using (Presentation p = new Presentation("Presentation.pptx"))
{
    using (IImage image = p.Slides[0].Shapes[0].GetImage(ShapeThumbnailBounds.Appearance, 1, 1))
    {
        image.Save("ShapeThumbnail.png", ImageFormat.Png);
    }
}
```