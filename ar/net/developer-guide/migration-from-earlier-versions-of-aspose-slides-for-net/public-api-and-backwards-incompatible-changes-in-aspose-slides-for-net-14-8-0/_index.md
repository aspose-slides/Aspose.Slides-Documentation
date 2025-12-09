---
title: التغييرات العامة في واجهة برمجة التطبيقات والتغييرات غير المتوافقة إلى الوراء في Aspose.Slides لـ .NET 14.8.0
linktitle: Aspose.Slides لـ .NET 14.8.0
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
description: "مراجعة تحديثات واجهة برمجة التطبيقات العامة والتغييرات المتعارضة في Aspose.Slides لـ .NET لتسهيل ترحيل حلول عروض PowerPoint (PPT, PPTX) و ODP الخاصة بك."
---

{{% alert color="primary" %}} 

تُدرج هذه الصفحة جميع الفئات، الأساليب، الخصائص وما إلى ذلك التي تم [مضافة](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) أو التي تم [إزالة](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) ، وغيرها من التغييرات التي تم تقديمها مع Aspose.Slides for .NET 14.8.0 API.

{{% /alert %}} 
## **تغييرات API العامة**
### **الخصائص التي تم تغييرها**
#### **تم إضافة الواجهة IVbaProject، وتغيير خاصية Presentation.VbaProject**
تم استبدال خاصية VbaProject في فئة Presentation. بدلاً من تمثيل البايت الخام لمشروع VBA في خاصية VbaProject، تمت إضافة تنفيذ جديد للواجهة IVbaProject.

استخدم خاصية IVbaProject لإدارة مشاريع VBA المدمجة في العرض التقديمي. يمكنك إضافة مراجع مشاريع جديدة، تعديل الوحدات الحالية وإنشاء وحدات جديدة.

كما يمكنك إنشاء مشروع VBA جديد باستخدام الفئة VbaProject التي تنفّذ الواجهة IVbaProject.

يوضح المثال التالي إنشاء مشروع VBA بسيط يحتوي على وحدة واحدة وإضافة مرجعين مطلوبين إلى المكتبات.

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

يوضح هذا المثال كيفية نسخ مشروع VBA من عرض تقديمي موجود إلى عرض تقديمي جديد.

``` csharp

 using (Presentation pres1 = new Presentation("PresentationWithMacroses.pptm"), pres2 = new Presentation())

{

    pres2.VbaProject = new VbaProject(pres1.VbaProject.ToBinary());

}

``` 
### **الواجهات والخصائص وخيارات التعداد التي تم إضافتها**
#### **تم إضافة الخاصية Aspose.Slides.Charts.IChartSeries.Overlap**
تحدد الخاصية Aspose.Slides.Charts.IChartSeries.Overlap مقدار التداخل بين الأعمدة والشرائح في المخططات ثنائية الأبعاد (يتراوح من -100 إلى 100).

هذه الخاصية ليست فقط لهذه السلسلة بل لجميع السلاسل في مجموعة السلسلة الأم - وهي تمثيل للخاصية المناسبة في المجموعة. وبالتالي فإن هذه الخاصية للقراءة فقط.

- استخدم الخاصية ParentSeriesGroup للوصول إلى مجموعة السلسلة الأم.
- استخدم الخاصية ParentSeriesGroup.Overlap القابلة للقراءة والكتابة لتغيير القيمة.

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
#### **تم إضافة الخاصية Aspose.Slides.Charts.IChartSeriesGroup.Overlap**
تحدد الخاصية Aspose.Slides.Charts.IChartSeriesGroup.Overlap مقدار التداخل بين الأعمدة والشرائح في المخططات ثنائية الأبعاد (من -100 إلى 100).

``` csharp



using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

   IChartSeriesCollection series = chart.ChartData.Series;

   series[0].ParentSeriesGroup.Overlap = -30;

}

``` 
#### **تم إضافة قيمة التعداد ShapeThumbnailBounds.Appearance**
تتيح لك هذه الطريقة لإنشاء صورة مصغرة للشكل توليد صورة مصغرة داخل حدود مظهره. تأخذ في الاعتبار جميع تأثيرات الشكل. تُقيد الصورة المصغرة المولدة بحدود الشريحة.

``` csharp



using (Presentation p = new Presentation("Presentation.pptx"))

{

    Bitmap st = p.Slides[0].Shapes[0].GetThumbnail(ShapeThumbnailBounds.Appearance, 1, 1);

    st.Save("ShapeThumbnail.png", ImageFormat.Png);

}

```