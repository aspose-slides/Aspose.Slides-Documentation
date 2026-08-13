---
title: إدارة كائنات OLE في العروض التقديمية في .NET
linktitle: إدارة OLE
type: docs
weight: 40
url: /ar/net/manage-ole/
keywords:
- كائن OLE
- ربط وتضمين الكائنات
- إضافة OLE
- تضمين OLE
- إضافة كائن
- تضمين كائن
- إضافة ملف
- تضمين ملف
- كائن مرتبط
- ملف مرتبط
- تغيير OLE
- أيقونة OLE
- عنوان OLE
- استخراج OLE
- استخراج كائن
- استخراج ملف
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تحسين إدارة كائنات OLE في ملفات PowerPoint وOpenDocument باستخدام Aspose.Slides for .NET. قم بتضمين وتحديث وتصدير محتوى OLE بسلاسة."
---
## **المقدمة**

{{% alert title="Info" color="info" %}}

OLE (Object Linking & Embedding) هي تقنية من مايكروسوفت تسمح بنقل البيانات والكائنات التي تم إنشاؤها في تطبيق إلى تطبيق آخر عبر الارتباط أو الإدراج. 

{{% /alert %}} 

تخيل رسمًا بيانيًا تم إنشاؤه في MS Excel. ثم يتم وضع هذا الرسم داخل شريحة PowerPoint. يُعتبر هذا الرسم كائن OLE. 

- قد يظهر كائن OLE على شكل أيقونة. في هذه الحالة، عند النقر مزدوجًا على الأيقونة، يتم فتح الرسم في التطبيق المرتبط به (Excel)، أو يُطلب منك اختيار تطبيق لفتح أو تحرير الكائن. 
- قد يعرض كائن OLE محتواه الفعلي، مثل محتويات الرسم البياني. في هذه الحالة يتم تنشيط الرسم داخل PowerPoint، تُحمَّل واجهة الرسم، وتتمكن من تعديل بيانات الرسم داخل PowerPoint.

[Aspose.Slides for .NET](https://products.aspose.com/slides/ar/net/) يتيح لك إدراج كائنات OLE في الشرائح كإطارات كائن OLE ([OleObjectFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/oleobjectframe)).

## **إضافة إطارات كائن OLE إلى الشرائح**

على افتراض أنك أنشأت رسمًا بيانيًا في Microsoft Excel وتريد إدراجه في شريحة كإطار كائن OLE باستخدام Aspose.Slides for .NET، يمكنك القيام بذلك بهذه الطريقة:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation).  
2. الحصول على مرجع الشريحة عبر فهرسها.  
3. قراءة ملف Excel كمصفوفة بايت.  
4. إضافة الـ [OleObjectFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/oleobjectframe) إلى الشريحة مع تمرير مصفوفة البايت ومعلومات أخرى حول كائن OLE.  
5. كتابة العرض المعدل كملف PPTX.  

في المثال أدناه، أضفنا رسمًا بيانيًا من ملف Excel إلى شريحة كـ [OleObjectFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/oleobjectframe) باستخدام Aspose.Slides for .NET.  
**ملاحظة** أن منشئ الـ [OleEmbeddedDataInfo](https://reference.aspose.com/slides/ar/net/aspose.slides.dom.ole/oleembeddeddatainfo/) يتلقى امتداد الكائن القابل للإدراج كمعامل ثانٍ. يتيح هذا الامتداد لـ PowerPoint تفسير نوع الملف بشكل صحيح واختيار التطبيق المناسب لفتح كائن OLE هذا.

```csharp 
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    SizeF slideSize = presentation.SlideSize.Size;
    ISlide slide = presentation.Slides[0];

    // تحضير البيانات لكائن OLE.
    byte[] fileData = File.ReadAllBytes("book.xlsx");
    IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

    // إضافة إطار كائن OLE إلى الشريحة.
    slide.Shapes.AddOleObjectFrame(0, 0, slideSize.Width, slideSize.Height, dataInfo);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

### **إضافة إطارات كائن OLE المرتبطة**

Aspose.Slides for .NET يتيح لك إضافة [OleObjectFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/oleobjectframe) بدون إدراج البيانات ولكن فقط مع رابط إلى الملف.

يعرض الشيفرة C# أدناه طريقة إضافة [OleObjectFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/oleobjectframe) مع ملف Excel مرتبط إلى شريحة:

```csharp 
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // إضافة إطار كائن OLE مع ملف Excel مرتبط.
    slide.Shapes.AddOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **الوصول إلى إطارات كائن OLE**

إذا كان كائن OLE مدرجًا بالفعل في شريحة، يمكنك العثور عليه أو الوصول إليه بسهولة بهذه الطريقة:

1. تحميل عرض يحتوي على كائن OLE المدمج بإنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation).  
2. الحصول على مرجع الشريحة باستخدام فهرستها.  
3. الوصول إلى شكل الـ [OleObjectFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/oleobjectframe). في مثالنا، استخدمنا الـ PPTX الذي تم إنشاؤه مسبقًا والذي يحتوي على شكل واحد فقط في الشريحة الأولى. ثم *قمنا بتحويل* ذلك الكائن إلى [IOleObjectFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/ioleobjectframe). هذا هو إطار كائن OLE المطلوب الوصول إليه.  
4. بمجرد الوصول إلى إطار كائن OLE، يمكنك تنفيذ أي عملية عليه.  

في المثال أدناه، يتم الوصول إلى إطار كائن OLE (رسم Excel مدرج في شريحة) وبيانات ملفه.

```csharp 
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // احصل على الشكل الأول كإطار كائن OLE.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        // احصل على بيانات الملف المدمج.
        byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

        // احصل على امتداد الملف المدمج.
        string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

        // ...
    }
}
```

### **الوصول إلى خصائص إطار كائن OLE المرتبط**

Aspose.Slides يتيح لك الوصول إلى خصائص إطار كائن OLE المرتبط.

يعرض الشيفرة C# أدناه طريقة التحقق مما إذا كان كائن OLE مرتبطًا ثم الحصول على مسار الملف المرتبط:

```csharp
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.ppt"))
{
    ISlide slide = presentation.Slides[0];

    // احصل على الشكل الأول كإطار كائن OLE.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    // تحقق مما إذا كان كائن OLE مرتبطًا.
    if (oleFrame != null && oleFrame.IsObjectLink)
    {
        // طباعة المسار الكامل للملف المرتبط.
        Console.WriteLine("OLE object frame is linked to: " + oleFrame.LinkPathLong);

        // طباعة المسار النسبي للملف المرتبط إذا كان موجودًا.
        // يمكن فقط لعروض PPT أن تحتوي على المسار النسبي.
        if (!string.IsNullOrEmpty(oleFrame.LinkPathRelative))
        {
            Console.WriteLine("OLE object frame relative path: " + oleFrame.LinkPathRelative);
        }
    }
}
```

## **تغيير بيانات كائن OLE**

{{% alert color="info" %}} 

في هذا القسم، يستخدم المثال البرمجي أدناه [Aspose.Cells for .NET](/cells/net/).

{{% /alert %}}

إذا كان كائن OLE مدرجًا بالفعل في شريحة، يمكنك بسهولة الوصول إلى ذلك الكائن وتعديل بياناته بهذه الطريقة:

1. تحميل عرض يحتوي على كائن OLE المدمج بإنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation).  
2. الحصول على مرجع الشريحة عبر فهرستها.  
3. الوصول إلى شكل الـ [OLEObjectFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/oleobjectframe). في مثالنا، استخدمنا الـ PPTX الذي تم إنشاؤه مسبقًا والذي يحتوي على شكل واحد في الشريحة الأولى. ثم *قمنا بتحويل* ذلك الكائن إلى [IOleObjectFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/ioleobjectframe). هذا هو إطار كائن OLE المطلوب الوصول إليه.  
4. بمجرد الوصول إلى إطار كائن OLE، يمكنك تنفيذ أي عملية عليه.  
5. إنشاء كائن `Workbook` والوصول إلى بيانات OLE.  
6. الوصول إلى الـ `Worksheet` المطلوب وتعديل البيانات.  
7. حفظ الـ `Workbook` المحدث في تدفق.  
8. تغيير بيانات كائن OLE من التدفق.  

في المثال أدناه، يتم الوصول إلى إطار كائن OLE (رسم Excel مدرج في شريحة) وتعديل بيانات ملفه لتحديث بيانات الرسم.

```csharp 
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // احصل على الشكل الأول كإطار كائن OLE.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        using (MemoryStream oleStream = new MemoryStream(oleFrame.EmbeddedData.EmbeddedFileData))
        {
            // قراءة بيانات كائن OLE ككائن Workbook.
            Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook(oleStream);

            using (MemoryStream newOleStream = new MemoryStream())
            {
                // تعديل بيانات المصنف.
                workbook.Worksheets[0].Cells[0, 4].PutValue("E");
                workbook.Worksheets[0].Cells[1, 4].PutValue(12);
                workbook.Worksheets[0].Cells[2, 4].PutValue(14);
                workbook.Worksheets[0].Cells[3, 4].PutValue(15);

                Aspose.Cells.OoxmlSaveOptions fileOptions = new Aspose.Cells.OoxmlSaveOptions(Aspose.Cells.SaveFormat.Xlsx);
                workbook.Save(newOleStream, fileOptions);

                // تغيير بيانات إطار كائن OLE.
                IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.ToArray(), oleFrame.EmbeddedData.EmbeddedFileExtension);
                oleFrame.SetEmbeddedData(newData);
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **إدراج أنواع ملفات أخرى في الشرائح**

بالإضافة إلى رسوم Excel، Aspose.Slides for .NET يتيح لك إدراج أنواع ملفات أخرى في الشرائح. على سبيل المثال، يمكنك إدراج ملفات HTML وPDF وZIP ككائنات. عند النقر مزدوجًا على الكائن المُدرج، يفتح تلقائيًا في البرنامج المناسب أو يُطلب من المستخدم اختيار برنامج مناسب لفتحه.

يعرض الشيفرة C# أدناه طريقة إدراج HTML وZIP في شريحة:

```c#
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    byte[] htmlData = File.ReadAllBytes("sample.html");
    IOleEmbeddedDataInfo htmlDataInfo = new OleEmbeddedDataInfo(htmlData, "html");
    IOleObjectFrame htmlOleFrame = slide.Shapes.AddOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
    htmlOleFrame.IsObjectIcon = true;

    byte[] zipData = File.ReadAllBytes("sample.zip");
    IOleEmbeddedDataInfo zipDataInfo = new OleEmbeddedDataInfo(zipData, "zip");
    IOleObjectFrame zipOleFrame = slide.Shapes.AddOleObjectFrame(150, 220, 50, 50, zipDataInfo);
    zipOleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **تعيين أنواع الملفات للكائنات المدمجة**

عند العمل على العروض، قد تحتاج إلى استبدال كائنات OLE القديمة بأخرى جديدة أو استبدال كائن OLE غير المدعوم بآخر مدعوم. Aspose.Slides for .NET يتيح لك تعيين نوع الملف لكائن مدمج، مما يمكنك من تحديث بيانات إطار OLE أو امتداده.

يعرض الشيفرة C# أدناه طريقة تعيين نوع الملف لكائن OLE مدمج إلى `zip`:

```c#
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;
    byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

    Console.WriteLine($"Current embedded file extension is: {fileExtension}");

    // تغيير نوع الملف إلى ZIP.
    oleFrame.SetEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **تعيين صور الأيقونة والعناوين للكائنات المدمجة**

بعد إدراج كائن OLE، يتم إضافة معاينة تتكون من صورة أيقونة تلقائيًا. هذه المعاينة هي ما يراه المستخدمون قبل الوصول إلى الكائن أو فتحه. إذا أردت استخدام صورة ونص محددين كعناصر في المعاينة، يمكنك تعيين صورة الأيقونة والعنوان باستخدام Aspose.Slides for .NET.

يعرض الشيفرة C# أدناه طريقة تعيين صورة الأيقونة والعنوان لكائن مدمج:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    // إضافة صورة إلى موارد العرض التقديمي.
    byte[] imageData = File.ReadAllBytes("image.png");
    IPPImage oleImage = presentation.Images.AddImage(imageData);

    // تعيين عنوان وصورة للمعاينة OLE.
    oleFrame.SubstitutePictureTitle = "My title";
    oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
    oleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **منع إطار كائن OLE من تغيير الحجم وإعادة الوضع**

بعد إضافة كائن OLE مرتبط إلى شريحة عرض، قد ترى عند فتح العرض في PowerPoint رسالة تطلب منك تحديث الروابط. النقر على زر "Update Links" قد يغير حجم وموقع إطار كائن OLE لأن PowerPoint يحدث البيانات من الكائن المرتبط ويُعيد تحديث المعاينة. لمنع PowerPoint من طلب تحديث بيانات الكائن، قم بتعيين خاصية `UpdateAutomatic` لواجهة [IOleObjectFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/ioleobjectframe/) إلى `false`:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    IOleObjectFrame oleFrame = (IOleObjectFrame)presentation.Slides[0].Shapes[0];

    // حافظ على حجم وموضع إطار كائن OLE عندما يقوم PowerPoint بتحديث الارتباط.
    oleFrame.UpdateAutomatic = false;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **استخراج الملفات المدمجة**

Aspose.Slides for .NET يتيح لك استخراج الملفات المدمجة في الشرائح ككائنات OLE بهذه الطريقة:
1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation) التي تحتوي على كائنات OLE التي تريد استخراجها.  
2. التجول عبر جميع الأشكال في العرض والوصول إلى أشكال [OLEObjectFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/oleobjectframe).  
3. الوصول إلى بيانات الملفات المدمجة من إطارات OLE وكتابتها إلى القرص.  

يعرض الشيفرة C# أدناه طريقة استخراج الملفات المدمجة في شريحة ككائنات OLE:

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    for (int index = 0; index < slide.Shapes.Count; index++)
    {
        IShape shape = slide.Shapes[index];
        IOleObjectFrame oleFrame = shape as IOleObjectFrame;

        if (oleFrame != null)
        {
            byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;
            string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

            string filePath = $"OLE_object_{index}{fileExtension}";
            File.WriteAllBytes(filePath, fileData);
        }
    }
}
```

## **الأسئلة الشائعة**

### هل سيتم عرض محتوى OLE عند تصدير الشرائح إلى PDF/صور؟

ما يُظهر على الشريحة هو ما يتم تصييره — أي أيقونة/صورة بديلة (المعاينة). محتوى OLE "الحي" لا يُنفذ أثناء التصيير. إذا لزم الأمر، قم بتعيين صورة معاينة خاصة لضمان المظهر المتوقع في ملف PDF المصدر.

### كيف يمكن قفل كائن OLE على شريحة بحيث لا يتمكن المستخدمون من تحريكه/تحريره في PowerPoint؟

قم بقفل الشكل: Aspose.Slides يوفر [قفل على مستوى الشكل](/slides/ar/net/applying-protection-to-presentation/). هذا ليس تشفيرًا، لكنه يمنع التعديلات غير المقصودة والتحريك.

### لماذا "يقفز" كائن Excel المرتبط أو يتغير حجمه عند فتح العرض؟

قد يقوم PowerPoint بتحديث معاينة OLE المرتبط. للحصول على مظهر ثابت، اتبع ممارسات [الحل العملي لإعادة حجم ورقة العمل](/slides/ar/net/working-solution-for-worksheet-resizing/) — إما ملاءمة الإطار للنطاق، أو ضبط النطاق إلى إطار ثابت وتعيين صورة بديلة مناسبة.

### هل سيتم الحفاظ على المسارات النسبية لكائنات OLE المرتبطة في صيغة PPTX؟

في PPTX، لا تتوفر معلومات "المسار النسبي" — فقط المسار الكامل. المسارات النسبية موجودة في تنسيق PPT القديم. من أجل القابلية للنقل، يفضَّل استخدام مسارات مطلقة موثوقة/عناوين URI قابلة للوصول أو الإدراج.