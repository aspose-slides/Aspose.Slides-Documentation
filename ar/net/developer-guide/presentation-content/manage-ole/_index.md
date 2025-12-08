---
title: "إدارة OLE في العروض التقديمية باستخدام C#"
linktitle: "إدارة OLE"
type: docs
weight: 40
url: /ar/net/manage-ole/
keywords:
- "كائن OLE"
- "ربط الكائنات وتضمينها"
- "إضافة OLE"
- "تضمين OLE"
- "إضافة كائن"
- "تضمين كائن"
- "إضافة ملف"
- "تضمين ملف"
- "كائن مرتبط"
- "ملف مرتبط"
- "تغيير OLE"
- "أيقونة OLE"
- "عنوان OLE"
- "استخراج OLE"
- "استخراج كائن"
- "استخراج ملف"
- "PowerPoint"
- "عرض تقديمي"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "تحسين إدارة كائنات OLE في PowerPoint وملفات OpenDocument باستخدام Aspose.Slides لـ .NET. قم بتضمين المحتوى، تحديثه، وتصديره بسلاسة."
---

{{% alert title="Info" color="info" %}}

OLE (Object Linking & Embedding) هي تقنية من مايكروسوفت تسمح بنقل البيانات والكائنات التي تم إنشاؤها في تطبيق واحد إلى تطبيق آخر عبر الربط أو التضمين.  

{{% /alert %}} 

تخيل وجود مخطط تم إنشاؤه في MS Excel. ثم يتم وضع هذا المخطط داخل شريحة PowerPoint. يُعتبر هذا المخطط في Excel كائن OLE. 

- قد يظهر كائن OLE كأيقونة. في هذه الحالة، عند النقر المزدوج على الأيقونة، يفتح المخطط في التطبيق المرتبط به (Excel)، أو يُطلب منك اختيار تطبيق لفتح أو تعديل الكائن. 
- قد يعرض كائن OLE محتوياته الفعلية، مثل محتوى المخطط. في هذه الحالة، يتم تنشيط المخطط في PowerPoint، يتم تحميل واجهة المخطط، ويمكنك تعديل بيانات المخطط داخل PowerPoint.

[Aspose.Slides for .NET](https://products.aspose.com/slides/net/) يسمح بإدراج كائنات OLE في الشرائح كإطارات كائن OLE ([OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)).

## **إضافة إطارات كائن OLE إلى الشرائح**

افترض أنك قد أنشأت مخططًا بالفعل في Microsoft Excel وتريد تضمينه في شريحة كإطار كائن OLE باستخدام Aspose.Slides for .NET، يمكنك القيام بذلك بهذه الطريقة:

1. أنشئ مثيلاً من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).  
2. احصل على مرجع الشريحة عبر فهرسها.  
3. اقرأ ملف Excel كمصفوفة بايت.  
4. أضف الـ[OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) إلى الشريحة متضمناً مصفوفة البايت ومعلومات أخرى حول كائن OLE.  
5. احفظ العرض التقديمي المعدل كملف PPTX.  

في المثال أدناه، أضفنا مخططًا من ملف Excel إلى شريحة كـ[OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) باستخدام Aspose.Slides for .NET.  
**ملاحظة** أنّ مُنشئ [OleEmbeddedDataInfo](https://reference.aspose.com/slides/net/aspose.slides.dom.ole/oleembeddeddatainfo/) يأخذ امتداد كائن قابل للتضمين كمعامل ثانٍ. يسمح هذا الامتداد لـPowerPoint بتفسير نوع الملف بشكل صحيح واختيار التطبيق المناسب لفتح كائن OLE هذا.  
```csharp 
using (Presentation presentation = new Presentation())
{
    SizeF slideSize = presentation.SlideSize.Size;
    ISlide slide = presentation.Slides[0];

    // إعداد البيانات لكائن OLE.
    byte[] fileData = File.ReadAllBytes("book.xlsx");
    IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

    // إضافة إطار كائن OLE إلى الشريحة.
    slide.Shapes.AddOleObjectFrame(0, 0, slideSize.Width, slideSize.Height, dataInfo);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


### **إضافة إطارات OLE مرتبطة**

يسمح Aspose.Slides for .NET بإضافة [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) دون تضمين البيانات وإنما فقط عبر رابط إلى الملف.

يظهر لك هذا الكود C# كيفية إضافة [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) مع ملف Excel مرتبط إلى شريحة:  
```csharp 
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // إضافة إطار كائن OLE مع ملف Excel مرتبط.
    slide.Shapes.AddOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


## **الوصول إلى إطارات OLE**

إذا كان كائن OLE مضمّنًا مسبقًا في شريحة، يمكنك العثور عليه أو الوصول إليه بسهولة بهذه الطريقة:

1. حمّل عرضًا تقديميًا يحتوي على كائن OLE مضمّن بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).  
2. احصل على مرجع الشريحة باستخدام فهرستها.  
3. وصول إلى الشكل [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe). في مثالنا، استخدمنا ملف PPTX المنشأ مسبقًا والذي يحتوي على شكل واحد فقط في الشريحة الأولى. ثم *قمنا بالتحويل* لهذا الكائن إلى [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe). كان هذا هو إطار كائن OLE المطلوب الوصول إليه.  
4. بمجرد الوصول إلى إطار كائن OLE، يمكنك تنفيذ أي عملية عليه.  

في المثال أدناه، تم الوصول إلى إطار كائن OLE (كائن مخطط Excel مضمّن في شريحة) وبيانات ملفه.  
```csharp 
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // الحصول على الشكل الأول كإطار كائن OLE.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        // الحصول على بيانات الملف المضمّن.
        byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

        // الحصول على امتداد الملف المضمّن.
        string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

        // ...
    }
}
```


### **الوصول إلى خصائص إطار OLE المرتبط**

يسمح Aspose.Slides بالوصول إلى خصائص إطارات OLE المرتبطة.

يظهر لك هذا الكود C# كيفية التحقق مما إذا كان كائن OLE مرتبطًا ثم الحصول على مسار الملف المرتبط:  
```csharp
using (Presentation presentation = new Presentation("sample.ppt"))
{
    ISlide slide = presentation.Slides[0];

    // الحصول على الشكل الأول كإطار كائن OLE.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    // التحقق مما إذا كان كائن OLE مرتبطًا.
    if (oleFrame != null && oleFrame.IsObjectLink)
    {
        // طباعة المسار الكامل للملف المرتبط.
        Console.WriteLine("OLE object frame is linked to: " + oleFrame.LinkPathLong);

        // طباعة المسار النسبي للملف المرتبط إذا كان موجودًا.
        // يمكن لملفات PPT فقط أن تحتوي على المسار النسبي.
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

إذا كان كائن OLE مضمّنًا مسبقًا في شريحة، يمكنك بسهولة الوصول إلى ذلك الكائن وتعديل بياناته بهذه الطريقة:

1. حمّل عرضًا تقديميًا يحتوي على كائن OLE مضمّن بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).  
2. احصل على مرجع الشريحة عبر فهرستها.  
3. وصول إلى الشكل [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe). في مثالنا، استخدمنا ملف PPTX المنشأ مسبقًا والذي يحتوي على شكل واحد في الشريحة الأولى. ثم *قمنا بالتحويل* لهذا الكائن إلى [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe). كان هذا هو إطار كائن OLE المطلوب الوصول إليه.  
4. بمجرد الوصول إلى إطار كائن OLE، يمكنك تنفيذ أي عملية عليه.  
5. أنشئ كائنًا من نوع `Workbook` واطلع على بيانات OLE.  
6. احصل على `Worksheet` المطلوبة وقم بتعديل البيانات.  
7. احفظ الـ`Workbook` المحدث في تدفق (stream).  
8. غيّر بيانات كائن OLE من التدفق.  

في المثال أدناه، يتم الوصول إلى إطار كائن OLE (كائن مخطط Excel مضمّن في شريحة) وتعديل بيانات ملفه لتحديث بيانات المخطط.  
```csharp 
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // الحصول على الشكل الأول كإطار كائن OLE.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        using (MemoryStream oleStream = new MemoryStream(oleFrame.EmbeddedData.EmbeddedFileData))
        {
            // قراءة بيانات كائن OLE ككائن Workbook.
            Workbook workbook = new Workbook(oleStream);

            using (MemoryStream newOleStream = new MemoryStream())
            {
                // تعديل بيانات المصنف.
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

بالإضافة إلى مخططات Excel، يسمح Aspose.Slides for .NET بتضمين أنواع أخرى من الملفات في الشرائح. على سبيل المثال، يمكنك إدراج ملفات HTML وPDF وZIP ككائنات. عند النقر المزدوج على الكائن المدرج، يفتح تلقائيًا في البرنامج المناسب، أو يُطلب من المستخدم اختيار برنامج مناسب لفتحه.

يظهر لك هذا الكود C# كيفية تضمين HTML وZIP في شريحة:  
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

عند العمل مع العروض التقديمية، قد تحتاج إلى استبدال كائنات OLE القديمة بأخرى جديدة أو استبدال كائن OLE غير مدعوم بآخر مدعوم. يتيح Aspose.Slides for .NET تحديد نوع الملف لكائن مضمّن، مما يمكنك من تحديث بيانات إطار OLE أو امتداده.

يظهر لك هذا الكود C# كيفية تعيين نوع الملف لكائن OLE مضمّن إلى `zip`:  
```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;
    byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

    Console.WriteLine($"Current embedded file extension is: {fileExtension}");

    // غيّر نوع الملف إلى ZIP.
    oleFrame.SetEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


## **تعيين صور الأيقونة والعناوين للكائنات المضمنة**

بعد تضمين كائن OLE، يتم إضافة معاينة تتكون من صورة أيقونة تلقائيًا. هذه المعاينة هي ما يراه المستخدمون قبل الوصول إلى كائن OLE أو فتحه. إذا كنت ترغب في استخدام صورة ونص محددين كعناصر في المعاينة، يمكنك تعيين صورة الأيقونة والعنوان باستخدام Aspose.Slides for .NET.

يظهر لك هذا الكود C# كيفية تعيين صورة الأيقونة والعنوان لكائن مضمّن:  
```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    // إضافة صورة إلى موارد العرض التقديمي.
    byte[] imageData = File.ReadAllBytes("image.png");
    IPPImage oleImage = presentation.Images.AddImage(imageData);

    // تعيين عنوان وصورة معاينة OLE.
    oleFrame.SubstitutePictureTitle = "My title";
    oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
    oleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


## **منع تعديل حجم وإعادة تموضع إطار كائن OLE**

بعد إضافة كائن OLE مرتبط إلى شريحة عرض تقديمي، عند فتح العرض في PowerPoint، قد تظهر رسالة تطلب منك تحديث الروابط. الضغط على زر "Update Links" قد يغيّر حجم ووضع إطار كائن OLE لأن PowerPoint يقوم بتحديث البيانات من كائن OLE المرتبط ويعيد تحميل معاينة الكائن. لمنع PowerPoint من طلب تحديث بيانات الكائن، اضبط الخاصية `UpdateAutomatic` للواجهة [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe/) إلى `false`:  
```cs
oleFrame.UpdateAutomatic = false;
```


## **استخراج الملفات المضمَّنة**

يتيح Aspose.Slides for .NET استخراج الملفات المضمنة في الشرائح ككائنات OLE بهذه الطريقة:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) التي تحتوي على كائنات OLE التي تريد استخراجها.  
2. تجول عبر جميع الأشكال في العرض وابدأ بالوصول إلى أشكال [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe).  
3. احصل على بيانات الملفات المضمنة من إطارات OLE واكتبها إلى القرص.  

يظهر لك هذا الكود C# كيفية استخراج الملفات المضمَّنة في شريحة ككائنات OLE:  
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


## **الأسئلة الشائعة**

**هل سيتم عرض محتوى OLE عند تصدير الشرائح إلى PDF/صور؟**  
ما يُظهر على الشريحة هو ما يتم تصديره — أي الأيقونة/الصورة البديلة (المعاينة). لا يتم تنفيذ محتوى OLE "الحي" أثناء التصدير. إذا لزم الأمر، عيّن صورة معاينة خاصة لضمان الظهور المتوقع في ملف PDF المُصدّر.

**كيف يمكنني قفل كائن OLE على شريحة بحيث لا يتمكن المستخدمون من تحريكه/تعديله في PowerPoint؟**  
قفل الشكل: يوفر Aspose.Slides [قفل على مستوى الشكل](/slides/ar/net/applying-protection-to-presentation/). هذا ليس تشفيرًا، لكنه يمنع فعليًا التعديلات والحركة غير المقصودة.

**لماذا يقوم كائن Excel المرتبط "بالقفز" أو تغيير حجمه عند فتح العرض؟**  
قد يقوم PowerPoint بتحديث معاينة OLE المرتبط. للحصول على مظهر ثابت، اتبع ممارسات [حل العمل لإعادة تحجيم الأوراق](/slides/ar/net/working-solution-for-worksheet-resizing/) — إما ضبط الإطار ليتناسب مع النطاق، أو تحجيم النطاق إلى إطار ثابت وتعيين صورة بديلة مناسبة.

**هل سيتم الحفاظ على المسارات النسبية لكائنات OLE المرتبطة في تنسيق PPTX؟**  
في PPTX، لا تتوفر معلومات "المسار النسبي" — فقط المسار الكامل. تُوجد المسارات النسبية في تنسيق PPT القديم. لضمان النقل، يفضّل استخدام مسارات مطلقة موثوقة/URI يمكن الوصول إليها أو التضمين.