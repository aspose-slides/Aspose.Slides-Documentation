---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ .NET 14.8.0
type: docs
weight: 100
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/
---

{{% alert color="primary" %}} 

تدرج هذه الصفحة جميع [الإضافات](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) أو [الإزالة](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) لفئات وأساليب وخصائص وما إلى ذلك، وأي تغييرات أخرى تم تقديمها مع واجهة برمجة التطبيقات Aspose.Slides لـ .NET 14.8.0.

{{% /alert %}} 
## **تغييرات واجهة برمجة التطبيقات العامة**
### **الخصائص المتغيرة**
#### **إضافة واجهة IVbaProject، تغيير خاصية Presentation.VbaProject**
تم استبدال خاصية VbaProject في فئة Presentation. بدلاً من التمثيل الثنائي الخام لمشروع VBA، تمت إضافة تنفيذ واجهة IVbaProject الجديدة.

استخدم خاصية IVbaProject لإدارة مشاريع VBA المدمجة في العرض التقديمي. يمكنك إضافة مراجع مشاريع جديدة، تحرير الوحدات الموجودة، وإنشاء وحدات جديدة.

أيضًا، يمكنك إنشاء مشروع VBA جديد باستخدام فئة VbaProject التي تنفذ واجهة IVbaProject.

يوضح المثال التالي كيفية إنشاء مشروع VBA بسيط يحتوي على وحدة واحدة وإضافة مرجعين مطلوبين إلى المكتبات.

``` csharp

 using (Presentation pres = new Presentation())

{

    // إنشاء مشروع VBA جديد

    pres.VbaProject = new VbaProject();

    // إضافة وحدة فارغة إلى مشروع VBA

    IVbaModule module = pres.VbaProject.Modules.AddEmptyModule("Module");

    // تعيين كود مصدر الوحدة

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

    // إضافة المراجع إلى مشروع VBA

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
### **إضافة واجهات وخصائص وخيارات تعداد**
#### **إضافة خاصية Aspose.Slides.Charts.IChartSeries.Overlap**
تحدد خاصية Aspose.Slides.Charts.IChartSeries.Overlap كمية التداخل بين الأشرطة والأعمدة على الرسوم البيانية 2D (من -100 إلى 100).

هذه الخاصية ليست فقط لهذه السلسلة ولكن لجميع السلاسل في مجموعة السلاسل الرئيسية - هذه هي إسقاط الخاصية المناسبة للمجموعة. وبالتالي، فإن هذه الخاصية للقراءة فقط.

- استخدم خاصية ParentSeriesGroup للوصول إلى مجموعة السلاسل الرئيسية.
- استخدم خاصية ParentSeriesGroup.Overlap للقراءة/الكتابة لتغيير القيمة.

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
#### **إضافة خاصية Aspose.Slides.Charts.IChartSeriesGroup.Overlap**
تحدد خاصية Aspose.Slides.Charts.IChartSeriesGroup.Overlap كمية التداخل بين الأشرطة والأعمدة على الرسوم البيانية 2D (من -100 إلى 100).

``` csharp



using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

   IChartSeriesCollection series = chart.ChartData.Series;

   series[0].ParentSeriesGroup.Overlap = -30;

}

``` 
#### **إضافة قيمة Enum لخاصية ShapeThumbnailBounds.Appearance**
تسمح لك هذه الطريقة من إنشاء مصغرات الشكل بتوليد مصغرة شكل ضمن حدود مظهرها. تأخذ في الاعتبار جميع تأثيرات الشكل. تكون المصغرة الناتجة مقيدة بحدود الشريحة.

``` csharp



using (Presentation p = new Presentation("Presentation.pptx"))

{

    Bitmap st = p.Slides[0].Shapes[0].GetThumbnail(ShapeThumbnailBounds.Appearance, 1, 1);

    st.Save("ShapeThumbnail.png", ImageFormat.Png);

}

``` 