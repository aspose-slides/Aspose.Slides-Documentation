---
title: إدارة كائنات OLE في العروض التقديمية باستخدام .NET
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
description: "تحسين إدارة كائنات OLE في ملفات PowerPoint وOpenDocument باستخدام Aspose.Slides لـ .NET. قم بتضمين المحتوى وتحديثه وتصديره بسلاسة."
---

{{% alert title="Info" color="info" %}}

OLE (Object Linking & Embedding) هي تقنية من مايكروسوفت تسمح بضع البيانات والكائنات التي تم إنشاؤها في تطبيق واحد بوضعها في تطبيق آخر عبر الربط أو التضمين. 

{{% /alert %}} 

تخيل مخططًا تم إنشاؤه في MS Excel. يتم وضع المخطط داخل شريحة PowerPoint. يُعتبر ذلك المخطط في Excel كائن OLE. 

- قد يظهر كائن OLE كأيقونة. في هذه الحالة، عند النقر المزدوج على الأيقونة، يفتح المخطط في التطبيق المرتبط به (Excel)، أو يُطلب منك اختيار تطبيق لفتح أو تحرير الكائن. 
- قد يعرض كائن OLE محتوياته الفعلية، مثل محتوى مخطط. في هذه الحالة، يتم تنشيط المخطط في PowerPoint، يتم تحميل واجهة المخطط، ويمكنك تعديل بيانات المخطط داخل PowerPoint.

[Aspose.Slides for .NET](https://products.aspose.com/slides/net/) يسمح لك بإدراج كائنات OLE في الشرائح كإطارات كائن OLE ([OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)).

## **إضافة إطارات كائن OLE إلى الشرائح**

باستخدامك لإنشاء مخطط في Microsoft Excel وتريد تضمينه في شريحة كإطار كائن OLE باستخدام Aspose.Slides for .NET، يمكنك فعل ذلك بهذه الطريقة:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
2. الحصول على مرجع الشريحة عبر فهرستها.
3. قراءة ملف Excel كمصفوفة بايت.
4. إضافة [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) إلى الشريحة مع احتواء مصفوفة البايت ومعلومات أخرى عن كائن OLE.
5. كتابة العرض المعدل كملف PPTX.

في المثال أدناه، أضفنا مخططًا من ملف Excel إلى شريحة كـ [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) باستخدام Aspose.Slides for .NET.  
**ملاحظة** أن منشئ [OleEmbeddedDataInfo](https://reference.aspose.com/slides/net/aspose.slides.dom.ole/oleembeddeddatainfo/) يأخذ امتداد الكائن القابل للتضمين كمعامل ثانٍ. يتيح هذا الامتداد لـ PowerPoint تفسير نوع الملف بشكل صحيح واختيار التطبيق المناسب لفتح هذا الكائن OLE.
```csharp 
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


### **إضافة إطارات OLE مرتبطة**

Aspose.Slides for .NET يسمح لك بإضافة [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) دون تضمين البيانات ولكن فقط مع رابط إلى الملف.

هذا الكود C# يوضح لك كيفية إضافة [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) مع ملف Excel مرتبط إلى شريحة:
```csharp 
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // إضافة إطار كائن OLE مع ملف Excel المرتبط.
    slide.Shapes.AddOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


## **الوصول إلى إطارات كائن OLE**

إذا كان كائن OLE مدمجًا بالفعل في شريحة، يمكنك بسهولة العثور عليه أو الوصول إليه بهذه الطريقة:

1. تحميل عرض يحتوي على كائن OLE المدمج عن طريق إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
2. الحصول على مرجع الشريحة باستخدام فهرستها.
3. الوصول إلى شكل [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe). في مثالنا، استخدمنا الـ PPTX الذي تم إنشاؤه مسبقًا والذي يحتوي على شكل واحد فقط في الشريحة الأولى. ثم *حوّلنا* ذلك الكائن إلى [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe). هذا هو إطار OLE المطلوب الوصول إليه.
4. بمجرد الوصول إلى إطار كائن OLE، يمكنك تنفيذ أي عملية عليه.

في المثال أدناه، يتم الوصول إلى إطار كائن OLE (كائن مخطط Excel مدمج في شريحة) وبيانات ملفه.
```csharp 
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


### **الوصول إلى خصائص إطار OLE المرتبط**

Aspose.Slides يسمح لك بالوصول إلى خصائص إطار كائن OLE المرتبط.

هذا الكود C# يوضح لك كيفية التحقق مما إذا كان كائن OLE مرتبطًا ثم الحصول على مسار الملف المرتبط:
```csharp
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

{{% alert color="primary" %}} 

في هذا القسم، يستخدم مثال الكود أدناه [Aspose.Cells for .NET](/cells/net/).

{{% /alert %}}

إذا كان كائن OLE مدمجًا بالفعل في شريحة، يمكنك بسهولة الوصول إلى ذلك الكائن وتعديل بياناته بهذه الطريقة:

1. تحميل عرض يحتوي على كائن OLE المدمج عن طريق إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
2. الحصول على مرجع الشريحة عبر فهرستها. 
3. الوصول إلى شكل [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe). في مثالنا، استخدمنا الـ PPTX الذي تم إنشاؤه مسبقًا والذي يحتوي على شكل واحد في الشريحة الأولى. ثم *حوّلنا* ذلك الكائن إلى [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe). هذا هو إطار OLE المطلوب الوصول إليه.
4. بمجرد الوصول إلى إطار كائن OLE، يمكنك تنفيذ أي عملية عليه.
5. إنشاء كائن `Workbook` والوصول إلى بيانات OLE.
6. الوصول إلى `Worksheet` المطلوبة وتعديل البيانات.
7. حفظ الـ `Workbook` المحدث في تدفق.
8. تغيير بيانات كائن OLE من التدفق.

في المثال أدناه، يتم الوصول إلى إطار كائن OLE (كائن مخطط Excel مدمج في شريحة) وتعديل بيانات ملفه لتحديث بيانات المخطط.
```csharp 
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
            Workbook workbook = new Workbook(oleStream);

            using (MemoryStream newOleStream = new MemoryStream())
            {
                // تعديل بيانات الـ Workbook.
                workbook.Worksheets[0].Cells[0, 4].PutValue("E");
                workbook.Worksheets[0].Cells[1, 4].PutValue(12);
                workbook.Worksheets[0].Cells[2, 4].PutValue(14);
                workbook.Worksheets[0].Cells[3, 4].PutValue(15);

                OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(Aspose.Cells.SaveFormat.Xlsx);
                workbook.Save(newOleStream, fileOptions);

                // تغيير بيانات كائن إطار OLE.
                IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.ToArray(), oleFrame.EmbeddedData.EmbeddedFileExtension);
                oleFrame.SetEmbeddedData(newData);
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


## **تضمين أنواع ملفات أخرى في الشرائح**

إلى جانب مخططات Excel، يسمح لك Aspose.Slides for .NET بتضمين أنواع ملفات أخرى في الشرائح. على سبيل المثال، يمكنك إدراج ملفات HTML وPDF وZIP ككائنات. عندما ينقر المستخدم مزدوجًا على الكائن المُدرج، يفتح تلقائيًا في البرنامج المناسب، أو يُطلب من المستخدم اختيار برنامج مناسب لفتحه.

هذا الكود C# يوضح لك كيفية تضمين HTML وZIP في شريحة:
```c#
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


## **تحديد أنواع الملفات للكائنات المضمنة**

عند العمل على العروض، قد تحتاج إلى استبدال كائنات OLE القديمة بأخرى جديدة أو استبدال كائن OLE غير مدعوم بآخر مدعوم. يسمح لك Aspose.Slides for .NET بتحديد نوع الملف لكائن مدمج، مما يتيح لك تحديث بيانات إطار OLE أو امتداده.

هذا الكود C# يوضح لك كيفية تعيين نوع الملف لكائن OLE مدمج إلى `zip`:
```c#
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


## **تعيين صور الأيقونات والعناوين للكائنات المضمنة**

بعد تضمين كائن OLE، يتم إضافة معاينة تتألف من صورة أيقونة تلقائيًا. هذه المعاينة هي ما يراه المستخدمون قبل الوصول إلى كائن OLE أو فتحه. إذا رغبت في استخدام صورة ونص محددين كعناصر في المعاينة، يمكنك تعيين صورة الأيقونة والعنوان باستخدام Aspose.Slides for .NET.

هذا الكود C# يوضح لك كيفية تعيين صورة الأيقونة والعنوان لكائن مدمج: 
```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    // إضافة صورة إلى موارد العرض التقديمي.
    byte[] imageData = File.ReadAllBytes("image.png");
    IPPImage oleImage = presentation.Images.AddImage(imageData);

    // تعيين عنوان وصورة لمعاينة OLE.
    oleFrame.SubstitutePictureTitle = "My title";
    oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
    oleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


## **منع تغيير حجم وإعادة تموضع إطار كائن OLE**

بعد إضافة كائن OLE مرتبط إلى شريحة عرض، عند فتح العرض في PowerPoint قد تظهر رسالة تطلب تحديث الروابط. النقر على زر "Update Links" قد يغيّر حجم وموضع إطار كائن OLE لأن PowerPoint يُحدّث البيانات من كائن OLE المرتبط ويُعيد تحميل المعاينة. لمنع PowerPoint من طلب تحديث بيانات الكائن، عيِّن خاصية `UpdateAutomatic` لواجهة [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe/) إلى `false`:
```cs
oleFrame.UpdateAutomatic = false;
```


## **استخراج الملفات المضمنة**

يتيح لك Aspose.Slides for .NET استخراج الملفات المضمنة في الشرائح ككائنات OLE بهذه الطريقة:
1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) التي تحتوي على كائنات OLE التي تريد استخراجها.
2. التكرار عبر جميع الأشكال في العرض والوصول إلى أشكال [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe).
3. الوصول إلى بيانات الملفات المدمجة من إطارات OLE وكتابتها إلى القرص.

هذا الكود C# يوضح لك كيفية استخراج الملفات المدمجة في شريحة ككائنات OLE:
```c#
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


## **الأسئلة المتكررة**

**هل سيتم عرض محتوى OLE عند تصدير الشرائح إلى PDF/صور؟**

ما يُعرض على الشريحة هو أيقونة/الصورة البديلة (المعاينة). لا يتم تنفيذ محتوى OLE "الحي" أثناء العرض. إذا لزم الأمر، عيّن صورة معاينة خاصة لضمان المظهر المتوقع في ملف PDF المصدّر.

**كيف يمكنني قفل كائن OLE على شريحة بحيث لا يتمكن المستخدمون من تحريكه/تحريره في PowerPoint؟**

قم بقفل الشكل: يوفر Aspose.Slides [قواعد القفل على مستوى الشكل](/slides/ar/net/applying-protection-to-presentation/). هذا ليس تشفيرًا، لكنه يمنع التعديلات غير المقصودة والتحريك.

**لماذا يقفز كائن Excel المرتبط أو يتغير حجمه عندما أفتح العرض؟**

قد يقوم PowerPoint بتحديث معاينة OLE المرتبط. للحصول على مظهر ثابت، اتبع ممارسات [الحل العملي لإعادة تحجيم الورقة](/slides/ar/net/working-solution-for-worksheet-resizing/) – إما ضبط الإطار على النطاق، أو تحجيم النطاق إلى إطار ثابت وتعيين صورة بديلة مناسبة.

**هل سيتم الحفاظ على المسارات النسبية لكائنات OLE المرتبطة في تنسيق PPTX؟**

في PPTX لا تتوفر معلومات "المسار النسبي" – فقط المسار الكامل. تُوجد المسارات النسبية في تنسيق PPT الأقدم. للانتقال بسلاسة، يفضَّل استخدام مسارات مطلقة موثوقة/عناوين URI قابلة للوصول أو التضمين.