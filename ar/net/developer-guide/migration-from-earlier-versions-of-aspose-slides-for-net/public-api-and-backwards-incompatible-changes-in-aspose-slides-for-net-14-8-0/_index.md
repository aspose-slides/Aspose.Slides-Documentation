---
title: "التغييرات غير المتوافقة للخلف وواجهة برمجة التطبيقات العامة في Aspose.Slides لـ .NET 14.8.0"
linktitle: "Aspose.Slides لـ .NET 14.8.0"
type: docs
weight: 100
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/
keywords:
- ترحيل
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
description: "استعرض تحديثات واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة في Aspose.Slides لـ .NET لتحديث حلول عروض PowerPoint PPT و PPTX و ODP بسلاسة."
---

{{% alert color="primary" %}} 

هذه الصفحة تسرد جميع الفئات، والطرق، والخصائص وما إلى ذلك التي تم *إضافتها*([added](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/)) أو *إزالتها*([removed](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/))، بالإضافة إلى التغييرات الأخرى التي تم تقديمها مع Aspose.Slides for .NET 14.8.0 API.

{{% /alert %}} 
## **تغييرات API العامة**
### **الخصائص التي تم تغييرها**
#### **إضافة الواجهة IVbaProject، وتغيير خاصية Presentation.VbaProject**
تم استبدال خاصية VbaProject في فئة Presentation. بدلاً من تمثيل البايتات الخام لمشروع VBA، تمت إضافة تنفيذ للواجهة الجديدة IVbaProject.

استخدم خاصية IVbaProject لإدارة مشاريع VBA المضمّنة في العرض التقديمي. يمكنك إضافة مراجع مشروع جديدة، تعديل الوحدات الموجودة وإنشاء وحدات جديدة.

كما يمكنك إنشاء مشروع VBA جديد باستخدام فئة VbaProject التي تنفّذ الواجهة IVbaProject.

يعرض المثال التالي إنشاء مشروع VBA بسيط يحتوي على وحدة واحدة وإضافة مرجعين مطلوبين إلى المكتبات.

``` csharp

 using (Presentation pres = new Presentation())

{

    // Create new VBA Project

    pres.VbaProject = new VbaProject();

    // Add empty module to the VBA project

    IVbaModule module = pres.VbaProject.Modules.AddEmptyModule("Module");

    // Set module source code

    module.SourceCode =

        @"Sub Test(oShape As Shape)

            MsgBox ""Test""

        End Sub";

    // Create reference to <stdole>

    VbaReferenceOleTypeLib stdoleReference =

        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // Create reference to Office

    VbaReferenceOleTypeLib officeReference =

        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // Add references to the VBA project

    pres.VbaProject.References.Add(stdoleReference);

    pres.VbaProject.References.Add(officeReference);

    pres.Save("test.pptm", SaveFormat.Pptm);

}

``` 

يعرض المثال التالي كيفية نسخ مشروع VBA من عرض تقديمي موجود إلى عرض تقديمي جديد.

``` csharp

 using (Presentation pres1 = new Presentation("PresentationWithMacroses.pptm"), pres2 = new Presentation())

{

    pres2.VbaProject = new VbaProject(pres1.VbaProject.ToBinary());

}

``` 
### **إضافة واجهات، خصائص وخيارات تعداد**
#### **إضافة الخاصية Aspose.Slides.Charts.IChartSeries.Overlap**
تحدد الخاصية Aspose.Slides.Charts.IChartSeries.Overlap مقدار تداخل الأعمدة والشريطين في المخططات الثنائية الأبعاد (من -100 إلى 100).

هذه الخاصية لا تخص هذه السلسلة فقط بل جميع السلاسل في مجموعة السلاسل الأصلية – هي إسقاط لخاصية المجموعة المناسبة. وبالتالي هذه الخاصية للقراءة فقط.

- استخدم الخاصية ParentSeriesGroup للوصول إلى مجموعة السلاسل الأصلية.
- استخدم الخاصية ParentSeriesGroup.Overlap للقراءة/الكتابة لتغيير القيمة.

``` csharp

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
#### **إضافة الخاصية Aspose.Slides.Charts.IChartSeriesGroup.Overlap**
تحدد الخاصية Aspose.Slides.Charts.IChartSeriesGroup.Overlap مقدار تداخل الأعمدة والشريطين في المخططات الثنائية الأبعاد (من -100 إلى 100).

``` csharp



using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

   IChartSeriesCollection series = chart.ChartData.Series;

   series[0].ParentSeriesGroup.Overlap = -30;

}

``` 
#### **إضافة القيمة ShapeThumbnailBounds.Appearance في التعداد**
تتيح طريقة إنشاء صورة مصغرة للشكل هذه توليد مصغّر للشكل ضمن حدود مظهره. تأخذ جميع تأثيرات الشكل في الاعتبار. يتم تقييد الصورة المصغرة المولدة بحدود الشريحة.

``` csharp



using (Presentation p = new Presentation("Presentation.pptx"))

{

    Bitmap st = p.Slides[0].Shapes[0].GetThumbnail(ShapeThumbnailBounds.Appearance, 1, 1);

    st.Save("ShapeThumbnail.png", ImageFormat.Png);

}

```