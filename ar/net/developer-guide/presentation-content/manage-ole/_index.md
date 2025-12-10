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
description: "تحسين إدارة كائنات OLE في ملفات PowerPoint وOpenDocument باستخدام Aspose.Slides لـ .NET. تضمين، تحديث، وتصدير محتوى OLE بسلاسة."
---

{{% alert title="Info" color="info" %}}
OLE (Object Linking & Embedding) هي تقنية من Microsoft تسمح بنقل البيانات والكائنات التي تم إنشاؤها في تطبيق إلى تطبيق آخر عبر الربط أو الإدراج. 
{{% /alert %}} 

Consider a chart created in MS Excel. The chart is then placed inside a PowerPoint slide. That Excel chart is considered an OLE object. 

- قد يظهر كائن OLE كأيقونة. في هذه الحالة، عند النقر المزدوج على الأيقونة، يُفتح المخطط في التطبيق المرتبط به (Excel)، أو يُطلب منك اختيار تطبيق لفتح الكائن أو تحريره. 
- قد يعرض كائن OLE محتواه الفعلي، مثل محتويات المخطط. في هذه الحالة، يتم تنشيط المخطط في PowerPoint، يتم تحميل واجهة المخطط، ويمكنك تعديل بيانات المخطط داخل PowerPoint.

[Aspose.Slides for .NET](https://products.aspose.com/slides/net/) يتيح لك إدراج كائنات OLE في الشرائح كإطارات كائن OLE ([OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)).

## **إضافة إطارات كائن OLE إلى الشرائح**

بافتراض أنك قد أنشأت مخططًا بالفعل في Microsoft Excel وترغب في تضمينه في شريحة كإطار كائن OLE باستخدام Aspose.Slides for .NET، يمكنك القيام بذلك بهذه الطريقة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
2. الحصول على مرجع الشريحة عبر فهرستها.
3. قراءة ملف Excel كمصفوفة بايت.
4. إضافة [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) إلى الشريحة مع مصفوفة البايت ومعلومات أخرى عن كائن OLE.
5. كتابة العرض التقديمي المعدل كملف PPTX.

في المثال أدناه، أضفنا مخططًا من ملف Excel إلى شريحة كـ[OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) باستخدام Aspose.Slides for .NET.  **ملاحظة** أن مُنشئ [OleEmbeddedDataInfo](https://reference.aspose.com/slides/net/aspose.slides.dom.ole/oleembeddeddatainfo/) يأخذ امتداد الكائن القابل للتضمين كمعامل ثانٍ. يتيح هذا الامتداد لـ PowerPoint تفسير نوع الملف بشكل صحيح واختيار التطبيق المناسب لفتح كائن OLE هذا.
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

Aspose.Slides for .NET يتيح لك إضافة [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) دون تضمين البيانات ولكن فقط مع ارتباط إلى الملف.

This C# code shows you how to add an [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) with a linked Excel file to a slide:
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

If an OLE object is already embedded in a slide, you can easily find or access it this way:

1. تحميل عرض تقديمي يحتوي على كائن OLE مضمّن عن طريق إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
2. الحصول على مرجع الشريحة باستخدام فهرستها.
3. الوصول إلى شكل [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe). في مثالنا، استخدمنا الـ PPTX الذي تم إنشاؤه مسبقًا والذي يحتوي على شكل واحد فقط في الشريحة الأولى. ثم *cast* ذلك الكائن إلى [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe). كان هذا هو إطار OLE المطلوب الوصول إليه.
4. بمجرد الوصول إلى إطار كائن OLE، يمكنك تنفيذ أي عملية عليه.

In the example below, an OLE object frame (an Excel chart object embedded in a slide) and its file data are accessed.
```csharp 
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // احصل على الشكل الأول كإطار كائن OLE.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        // احصل على بيانات الملف المضمّن.
        byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

        // احصل على امتداد الملف المضمّن.
        string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

        // ...
    }
}
```


### **الوصول إلى خصائص إطار OLE المرتبط**

Aspose.Slides يتيح لك الوصول إلى خصائص إطار OLE المرتبط.

This C# code shows you how to check if an OLE object is linked and then obtain the path to the linked file:
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
        // يمكن لعروض PPT فقط أن تحتوي على المسار النسبي.
        if (!string.IsNullOrEmpty(oleFrame.LinkPathRelative))
        {
            Console.WriteLine("OLE object frame relative path: " + oleFrame.LinkPathRelative);
        }
    }
}
```


## **تغيير بيانات كائن OLE**

{{% alert color="primary" %}} 
في هذا القسم، يستخدم مثال التعليمات البرمجية أدناه [Aspose.Cells for .NET](/cells/net/).
{{% /alert %}}

If an OLE object is already embedded in a slide, you can easily access that object and modify its data this way:

1. تحميل عرض تقديمي يحتوي على كائن OLE مضمّن عن طريق إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
2. الحصول على مرجع الشريحة عبر فهرستها. 
3. الوصول إلى شكل [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe). في مثالنا، استخدمنا الـ PPTX الذي تم إنشاؤه مسبقًا والذي يحتوي على شكل واحد في الشريحة الأولى. ثم *cast* ذلك الكائن إلى [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe). كان هذا هو الإطار المطلوب الوصول إليه.
4. بمجرد الوصول إلى إطار كائن OLE، يمكنك تنفيذ أي عملية عليه.
5. إنشاء كائن `Workbook` والوصول إلى بيانات OLE.
6. الوصول إلى الـ `Worksheet` المطلوب وتعديل البيانات.
7. حفظ الـ `Workbook` المحدث في تدفق.
8. تغيير بيانات كائن OLE من التدفق.

In the example below, an OLE object frame (an Excel chart object embedded in a slide) is accessed, and its file data is modified to update the chart data.
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

بالإضافة إلى مخططات Excel، يتيح لك Aspose.Slides for .NET تضمين أنواع ملفات أخرى في الشرائح. على سبيل المثال، يمكنك إدراج ملفات HTML وPDF وZIP ككائنات. عندما ينقر المستخدم مرتين على الكائن المُدرج، يتم فتحه تلقائيًا في البرنامج المناسب، أو يُطلب من المستخدم اختيار برنامج مناسب لفتحه.

This C# code shows you how to embed HTML and ZIP into a slide:
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


## **تعيين أنواع الملفات للكائنات المضمنة**

عند العمل مع العروض التقديمية، قد تحتاج إلى استبدال كائنات OLE القديمة بأخرى جديدة أو استبدال كائن OLE غير المدعوم بآخر مدعوم. يتيح لك Aspose.Slides for .NET تعيين نوع الملف لكائن مضمّن، مما يمكنك من تحديث بيانات إطار OLE أو امتداده.

This C# code shows you how to set the file type for an embedded OLE object to `zip`:
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

بعد تضمين كائن OLE، يتم إضافة معاينة تتكون من صورة أيقونة تلقائيًا. هذه المعاينة هي ما يراه المستخدمون قبل الوصول إلى كائن OLE أو فتحه. إذا أردت استخدام صورة ونص محددين كعناصر في المعاينة، يمكنك تعيين صورة الأيقونة والعنوان باستخدام Aspose.Slides for .NET.

This C# code shows you how to set the icon image and title for an embedded object: 
```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    // إضافة صورة إلى موارد العرض التقديمي.
    byte[] imageData = File.ReadAllBytes("image.png");
    IPPImage oleImage = presentation.Images.AddImage(imageData);

    // تعيين عنوان والصورة لمعاينة OLE.
    oleFrame.SubstitutePictureTitle = "My title";
    oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
    oleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


## **منع تغيير حجم وإعادة تموضع إطار OLE**

بعد إضافة كائن OLE مرتبط إلى شريحة عرض تقديمي، عند فتح العرض في PowerPoint قد يظهر لك رسالة تطلب تحديث الروابط. قد يؤدي النقر على زر "Update Links" إلى تغيير حجم وموقع إطار OLE لأن PowerPoint يحدث البيانات من كائن OLE المرتبط ويُعيد تحديث معاينة الكائن. لمنع PowerPoint من طلب تحديث بيانات الكائن، عيّن خاصية `UpdateAutomatic` لواجهة [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe/) إلى `false`:
```cs
oleFrame.UpdateAutomatic = false;
```


## **استخراج الملفات المضمنة**

Aspose.Slides for .NET يتيح لك استخراج الملفات المضمنة في الشرائح ككائنات OLE بهذه الطريقة:
1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) التي تحتوي على كائنات OLE التي تريد استخراجها.
2. التجول عبر جميع الأشكال في العرض والوصول إلى أشكال [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe).
3. الوصول إلى بيانات الملفات المضمنة من إطارات OLE وكتابتها إلى القرص.

This C# code shows you how to extract files embedded in a slide as OLE objects:
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


## **FAQ**

**هل سيتم عرض محتوى OLE عند تصدير الشرائح إلى ملفات PDF/صور؟**

ما يُعرض على الشريحة هو أيقونة/صورة المعاينة. لا يتم تنفيذ محتوى OLE "الحي" أثناء التصدير. إذا لزم الأمر، عيّن صورة معاينة خاصة لضمان المظهر المتوقع في الـ PDF المصدّر.

**كيف يمكنني قفل كائن OLE على الشريحة بحيث لا يستطيع المستخدمون تحريكه/تحريره في PowerPoint؟**

قفل الشكل: يوفر Aspose.Slides [قواعد قفل على مستوى الشكل](/slides/ar/net/applying-protection-to-presentation/). هذا ليس تشفيرًا، لكنه يمنع التعديلات أو النقل غير المقصود.

**لماذا "يقفز" كائن Excel المرتبط أو يتغير حجمه عند فتح العرض؟**

قد يقوم PowerPoint بتحديث معاينة OLE المرتبط. للحصول على مظهر ثابت، اتبع ممارسات [حل النموذج لإعادة تحجيم ورقة العمل](/slides/ar/net/working-solution-for-worksheet-resizing/) — إما ملاءمة الإطار للنطاق، أو مقياس النطاق إلى إطار ثابت وتعيين صورة بديلة مناسبة.

**هل يتم الحفاظ على المسارات النسبية لكائنات OLE المرتبطة في صيغة PPTX؟**

في PPTX لا تتوفر معلومات "المسار النسبي" — فقط المسار الكامل. المسارات النسبية موجودة في الصيغة القديمة PPT. لتقليل الاعتماد على المسارات، يفضَّل استخدام مسارات مطلقة موثوقة أو عناوين URI يمكن الوصول إليها أو تضمين الملفات.