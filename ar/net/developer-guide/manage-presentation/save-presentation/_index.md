---
title: حفظ العرض التقديمي في .NET
linktitle: حفظ العرض التقديمي
type: docs
weight: 80
url: /net/save-presentation/
keywords: "حفظ PowerPoint, PPT, PPTX, حفظ العرض التقديمي, ملف, تدفق, C#, Csharp, .NET"
description: "حفظ عرض PowerPoint كملف أو تدفق في C# أو .NET"
---

## **حفظ العرض التقديمي**
فتح عرض تقديمي وصف كيف تستخدم فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) لفتح عرض تقديمي. يشرح هذا المقال كيفية إنشاء وحفظ العروض التقديمية.
تحتوي فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) على محتوى العرض التقديمي. سواء كنت تنشئ عرضًا تقديميًا من الصفر أو تعدل أحد العروض الموجودة، عند الانتهاء، تريد حفظ العرض التقديمي. باستخدام Aspose.Slides لـ .NET، يمكن حفظه كـ **ملف** أو **تدفق**. يشرح هذا المقال كيفية حفظ عرض تقديمي بطرق مختلفة:

### **حفظ العروض التقديمية إلى ملفات**
احفظ العرض التقديمي كملف عن طريق استدعاء طريقة [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) في فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation). ببساطة مرر اسم الملف ونوع الحفظ إلى طريقة [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index). تظهر الأمثلة التالية كيفية حفظ عرض تقديمي باستخدام Aspose.Slides لـ .NET باستخدام C#.

```c#
// أنشئ كائن Presentation يمثل ملف PPT
Presentation presentation= new Presentation();

//...قم ببعض العمل هنا...

// احفظ عرضك التقديمي كملف
presentation.Save("Saved_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

### **حفظ العروض التقديمية إلى تدفقات**
من الممكن حفظ العرض التقديمي إلى تدفق عن طريق تمرير تدفق الإخراج إلى طريقة حفظ فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation). هناك العديد من أنواع التدفقات التي يمكن حفظ العرض التقديمي إليها. في المثال أدناه، أنشأنا ملف عرض تقديمي جديد، وأضفنا نصًا في شكل وحفظنا العرض التقديمي في التدفق.

```c#
// أنشئ كائن Presentation يمثل ملف PPT
using (Presentation presentation = new Presentation())
{

    IAutoShape shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 200, 200);

    // أضف نصًا إلى الشكل
    shape.TextFrame.Text = "توضح هذه التجربة كيفية إنشاء ملف PowerPoint وحفظه في تدفق.";

    FileStream toStream = new FileStream("Save_As_Stream_out.pptx", FileMode.Create);
    presentation.Save(toStream, Aspose.Slides.Export.SaveFormat.Pptx);
    toStream.Close();
}
```

### **حفظ العروض التقديمية مع نوع العرض المحدد مسبقًا**
توفر Aspose.Slides لـ .NET إمكانية تعيين نوع العرض للعروض التقديمية المولدة عندما يتم فتحها في PowerPoint من خلال فئة [ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties). يتم استخدام خاصية [LastView](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/properties/lastview) لتعيين نوع العرض باستخدام المُعداد [ViewType](https://reference.aspose.com/slides/net/aspose.slides/viewtype).

```csharp
using (Presentation pres = new Presentation())
{
    pres.ViewProperties.LastView = ViewType.SlideMasterView;
    pres.Save("pres-will-open-SlideMasterView.pptx", SaveFormat.Pptx);
}
```

### **حفظ العروض التقديمية في تنسيق Office Open XML الصارم**
يسمح لك Aspose.Slides بحفظ العرض التقديمي في تنسيق Office Open XML الصارم. لهذا الغرض، توفر فئة [**Aspose.Slides.Export.PptxOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/pptxoptions) حيث يمكنك تعيين خاصية Conformance أثناء حفظ ملف العرض التقديمي. إذا قمت بتعيين قيمتها إلى Conformance.Iso29500_2008_Strict، فسيتم حفظ ملف العرض التقديمي الناتج في تنسيق Office Open XML الصارم.

ينشئ نموذج الشيفرة التالي عرضًا تقديميًا ويحفظه في تنسيق Office Open XML الصارم. عند استدعاء طريقة الحفظ للعرض التقديمي، يتم تمرير كائن **[Aspose.Slides.Export.PptxOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pptxoptions)** معه مع تعيين خاصية [**Conformance**](https://reference.aspose.com/slides/net/aspose.slides.export/pptxoptions/properties/conformance) على [**Conformance.Iso29500_2008_Strict**](https://reference.aspose.com/slides/net/aspose.slides.export/conformance).

```csharp
   // أنشئ كائن Presentation يمثل ملف عرض تقديمي
   using (Presentation presentation = new Presentation())
   {
       // احصل على الشريحة الأولى
       ISlide slide = presentation.Slides[0];

       // أضف شكلًا تلقائيًا من نوع خط
       slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

       // احفظ العرض التقديمي في تنسيق Office Open XML الصارم
       presentation.Save(dataDir + "NewPresentation_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx,
           new PptxOptions() { Conformance = Conformance.Iso29500_2008_Strict });

   }
```

### **حفظ العروض التقديمية في تنسيق Office Open XML في وضع Zip64**
ملف Office Open XML هو أرشيف ZIP له حد يصل إلى 4 جيجا بايت (2^32 بايت) على الحجم غير المضغوط لملف، والحجم المضغوط لملف، والحجم الإجمالي للأرشيف، بالإضافة إلى حد يبلغ 65,535 (2^16-1) ملف في الأرشيف. تزيد امتدادات تنسيق ZIP64 الحدود إلى 2^64.

تسمح لك خاصية [**IPptxOptions.Zip64Mode**](https://reference.aspose.com/slides/net/aspose.slides.export/ipptxoptions/zip64mode/) باختيار متى يجب استخدام امتدادات تنسيق ZIP64 للملف Office Open XML المحفوظ.

توفر هذه الخاصية الأوضاع التالية:

- [Zip64Mode.IfNecessary](https://reference.aspose.com/slides/net/aspose.slides.export/zip64mode/) تعني أن امتدادات تنسيق ZIP64 ستستخدم فقط إذا كان العرض التقديمي يتجاوز الحدود المذكورة أعلاه. هذا هو الوضع الافتراضي.
- [Zip64Mode.Never](https://reference.aspose.com/slides/net/aspose.slides.export/zip64mode/) تعني أنه لن يتم استخدام امتدادات تنسيق ZIP64.
- [Zip64Mode.Always](https://reference.aspose.com/slides/net/aspose.slides.export/zip64mode/) تعني أنه سيتم دائمًا استخدام امتدادات تنسيق ZIP64.

توضح الشيفرة التالية كيف تحفظ العرض التقديمي في تنسيق PPTX مع امتدادات تنسيق ZIP64:

```c#
using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-zip64.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        Zip64Mode = Zip64Mode.Always
    });
}
```

{{% alert title="ملاحظة" color="warning" %}}

ستؤدي الحفظ في وضع Zip64Mode.Never إلى رفع استثناء [PptxException](https://reference.aspose.com/slides/net/aspose.slides/pptxexception/) إذا لم يكن من الممكن حفظ العرض التقديمي في تنسيق ZIP32.

{{% /alert %}}

### **تحديثات حفظ التقدم بنسب مئوية**
تمت إضافة واجهة [**IProgressCallback**](https://reference.aspose.com/slides/net/aspose.slides/iprogresscallback) جديدة إلى واجهة [**ISaveOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/isaveoptions) والفئة المجردة [**SaveOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions). تمثل واجهة **IProgressCallback** كائنًا للنداء الخلفي لتحديثات التقدم في النسبة المئوية.

تظهر مقتطفات الشيفرة التالية كيفية استخدام واجهة IProgressCallback:

```c#
using (Presentation presentation = new Presentation("ConvertToPDF.pptx"))
{
    ISaveOptions saveOptions = new PdfOptions();
    saveOptions.ProgressCallback = new ExportProgressHandler();
    presentation.Save("ConvertToPDF.pdf", SaveFormat.Pdf, saveOptions);
}

```

```c#
class ExportProgressHandler : IProgressCallback
{
    public void Reporting(double progressValue)
    {
        // استخدم قيمة النسبة المئوية هنا
        int progress = Convert.ToInt32(progressValue);
        Console.WriteLine(progress + "% الملف تم تحويله");
    }
}
```

{{% alert title="معلومات" color="info" %}}

باستخدام واجهتها البرمجية الخاصة، طورت Aspose تطبيق [مقسم PowerPoint مجاني](https://products.aspose.app/slides/splitter) يسمح للمستخدمين بتقسيم عروضهم التقديمية إلى ملفات متعددة. أساسًا، يقوم التطبيق بحفظ الشرائح المحددة من عرض تقديمي معين كملفات PowerPoint جديدة (PPTX أو PPT).

{{% /alert %}}

<h2>فتح وحفظ العرض التقديمي</h2>

<a name="csharp-open-save-presentation"><strong>الخطوات: فتح وحفظ العرض التقديمي في C#</strong></a>

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) بأي تنسيق مثل PPT، PPTX، ODP إلخ.
2. احفظ _العرض التقديمي_ في أي تنسيق مدعوم بواسطة [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/)

```c#
// قم بتحميل أي ملف مدعوم في العرض التقديمي مثل ppt، pptx، odp إلخ.
Presentation presentation = new Presentation("Sample.odp");

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```