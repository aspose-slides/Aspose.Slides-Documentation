---
title: إدارة كائنات OLE في العروض التقديمية في .NET
linktitle: إدارة OLE
type: docs
weight: 40
url: /ar/net/manage-ole/
keywords:
- كائن OLE
- الربط والتضمين للكائنات
- إضافة OLE
- تضمين OLE
- إضافة كائن
- تضمين كائن
- إضافة ملف
- تضمين ملف
- كائن مرتبط
- ملف مرتبط
- تعديل OLE
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
description: "تحسين إدارة كائنات OLE في ملفات PowerPoint و OpenDocument باستخدام Aspose.Slides for .NET. تضمين، تحديث، وتصدير محتوى OLE بسلاسة."
---
## **المقدمة**

{{% alert color="info" title="Note" %}}

OLE (Object Linking & Embedding) هي تقنية من Microsoft تسمح بنقل البيانات والكائنات التي تم إنشاؤها في تطبيق إلى تطبيق آخر عبر الربط أو الإدراج. 

{{% /alert %}} 

تخيل مخططًا تم إنشاؤه في MS Excel. يتم بعد ذلك وضع المخطط داخل شريحة PowerPoint. يُعتبر هذا المخطط في Excel كائن OLE. 

- قد يظهر كائن OLE كأيقونة. في هذه الحالة، عند النقر مزدوجًا على الأيقونة، يتم فتح المخطط في التطبيق المرتبط به (Excel)، أو يُطلب منك اختيار تطبيق لفتح الكائن أو تحريره. 
- قد يعرض كائن OLE محتوياته الفعلية، مثل محتويات المخطط. في هذه الحالة، يتم تنشيط المخطط في PowerPoint، يُحمَّل واجهة المخطط، ويمكنك تعديل بيانات المخطط داخل PowerPoint.

[Aspose.Slides for .NET](https://products.aspose.com/slides/net/) يسمح لك بإدراج كائنات OLE في الشرائح كإطارات كائن OLE ([OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)).

## **إضافة إطارات كائن OLE إلى الشرائح**

بافتراض أنك أنشأت مخططًا بالفعل في Microsoft Excel وتريد إدراجه في شريحة كإطار كائن OLE باستخدام Aspose.Slides for .NET، يمكنك فعل ذلك بهذه الطريقة:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. الحصول على مرجع الشريحة عبر فهرستها.
3. قراءة ملف Excel كمصفوفة بايت.
4. إضافة [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) إلى الشريحة مع مصفوفة البايت ومعلومات أخرى حول كائن OLE.
5. كتابة العرض التقديمي المعدل كملف PPTX.

في المثال أدناه، أضفنا مخططًا من ملف Excel إلى شريحة كـ [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) باستخدام Aspose.Slides for .NET.  
**ملاحظة** أن منشئ [OleEmbeddedDataInfo](https://reference.aspose.com/slides/net/aspose.slides.dom.ole/oleembeddeddatainfo/) يأخذ امتداد كائن قابل للإدراج كمعامل ثانٍ. يتيح هذا الامتداد لـ PowerPoint تفسير نوع الملف بشكل صحيح واختيار التطبيق المناسب لفتح كائن OLE هذا.

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

### **إضافة إطارات OLE مرتبطة**

Aspose.Slides for .NET يسمح لك بإضافة [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) دون إدراج البيانات ولكن فقط مع ارتباط إلى الملف.

يعرض هذا الكود C# كيفية إضافة [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) بملف Excel مرتبط إلى شريحة:

```csharp 
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // إضافة إطار كائن OLE بملف Excel مرتبط.
    slide.Shapes.AddOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **الوصول إلى إطارات OLE**

إذا كان كائن OLE مُدرجًا بالفعل في شريحة، يمكنك بسهولة العثور عليه أو الوصول إليه بهذه الطريقة:

1. تحميل عرض تقديمي يحتوي على كائن OLE المضمن بإنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. الحصول على مرجع الشريحة باستخدام فهرستها.
3. الوصول إلى شكل [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe). في مثالنا، استخدمنا ملف PPTX الذي تم إنشاؤه مسبقًا ويحتوي على شكل واحد فقط في الشريحة الأولى. ثم *قمنا بتحويل* هذا الكائن إلى [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe). هذا هو إطار كائن OLE المطلوب الوصول إليه.
4. بمجرد الوصول إلى إطار كائن OLE، يمكنك تنفيذ أي عملية عليه.

في المثال أدناه، يتم الوصول إلى إطار كائن OLE (كائن مخطط Excel مدمج في شريحة) وبيانات ملفه.

```csharp 
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // احصل على الشكل الأول كإطار كائن OLE.
    IOleObjectFrame oleFrame = slide.Shapes[0] as IOleObjectFrame;

    if (oleFrame != null)
    {
        // احصل على بيانات الملف المضمن.
        byte[] fileData = oleFrame.EmbeddedData.EmbeddedFileData;

        // احصل على امتداد الملف المضمن.
        string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

        // ...
    }
}
```

### **الوصول إلى خصائص إطارات OLE المرتبطة**

Aspose.Slides يتيح لك الوصول إلى خصائص إطارات OLE المرتبطة.

يعرض هذا الكود C# كيفية التحقق مما إذا كان كائن OLE مرتبطًا ثم الحصول على مسار الملف المرتبط:

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
        // يمكن فقط لملفات PPT أن تحتوي على المسار النسبي.
        if (!string.IsNullOrEmpty(oleFrame.LinkPathRelative))
        {
            Console.WriteLine("OLE object frame relative path: " + oleFrame.LinkPathRelative);
        }
    }
}
```

## **تغيير بيانات كائن OLE**

{{% alert color="info" title="Note" %}}

في هذا القسم، يستخدم المثال البرمجي أدناه [Aspose.Cells for .NET](https://docs.aspose.com/cells/net/).

{{% /alert %}}

إذا كان كائن OLE مُدرجًا بالفعل في شريحة، يمكنك بسهولة الوصول إلى ذلك الكائن وتعديل بياناته بهذه الطريقة:

1. تحميل عرض تقديمي يحتوي على كائن OLE المضمن بإنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. الحصول على مرجع الشريحة عبر فهرستها. 
3. الوصول إلى شكل [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe). في مثالنا، استخدمنا ملف PPTX الذي يحتوي على شكل واحد في الشريحة الأولى. ثم *قمنا بتحويل* هذا الكائن إلى [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe). كان هذا هو إطار كائن OLE المطلوب الوصول إليه.
4. بمجرد الوصول إلى إطار كائن OLE، يمكنك تنفيذ أي عملية عليه.
5. إنشاء كائن `Workbook` والوصول إلى بيانات OLE.
6. الوصول إلى `Worksheet` المطلوب وتعديل البيانات.
7. حفظ `Workbook` المحدث في تدفق.
8. تغيير بيانات كائن OLE من التدفق.

في المثال أدناه، يتم الوصول إلى إطار كائن OLE (كائن مخطط Excel مدمج في شريحة) وتم تعديل بيانات ملفه لتحديث بيانات المخطط.

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

                // تغيير بيانات كائن إطار OLE.
                IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.ToArray(), oleFrame.EmbeddedData.EmbeddedFileExtension);
                oleFrame.SetEmbeddedData(newData);
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **إدراج أنواع ملفات أخرى في الشرائح**

بالإضافة إلى مخططات Excel، يتيح لك Aspose.Slides for .NET إدراج أنواع أخرى من الملفات في الشرائح. على سبيل المثال، يمكنك إدراج ملفات HTML وPDF وZIP ككائنات. عندما ينقر المستخدم مزدوجًا على الكائن المُدرج، يفتح تلقائيًا في البرنامج المناسب، أو يُطلب من المستخدم اختيار برنامج مناسب لفتحه.

يعرض هذا الكود C# كيفية إدراج HTML وZIP في شريحة:

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

عند العمل على عروض تقديمية، قد تحتاج إلى استبدال كائنات OLE القديمة بأخرى جديدة أو استبدال كائن OLE غير مدعوم بآخر مدعوم. يتيح لك Aspose.Slides for .NET تعيين نوع الملف لكائن مدمج، مما يمكنك من تحديث بيانات إطار OLE أو امتداده.

يعرض هذا الكود C# كيفية تعيين نوع الملف لكائن OLE مدمج إلى `zip`:

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

    // غيّر نوع الملف إلى ZIP.
    oleFrame.SetEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **تعيين صور الأيقونات والعناوين للكائنات المدمجة**

بعد إدراج كائن OLE، تُضاف معاينة تتكون من صورة أيقونة تلقائيًا. هذه المعاينة هي ما يراه المستخدمون قبل الوصول إلى أو فتح كائن OLE. إذا كنت تريد استخدام صورة ونص محددين كعناصر في المعاينة، يمكنك تعيين صورة الأيقونة والعنوان باستخدام Aspose.Slides for .NET.

يعرض هذا الكود C# كيفية تعيين صورة الأيقونة والعنوان لكائن مدمج: 

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IOleObjectFrame oleFrame = (IOleObjectFrame)slide.Shapes[0];

    // أضف صورة إلى موارد العرض التقديمي.
    byte[] imageData = File.ReadAllBytes("image.png");
    IPPImage oleImage = presentation.Images.AddImage(imageData);

    // اضبط العنوان والصورة لمعاينة OLE.
    oleFrame.SubstitutePictureTitle = "My title";
    oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
    oleFrame.IsObjectIcon = true;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **منع تغيير حجم إطار كائن OLE وإعادة وضعه**

بعد إضافة كائن OLE مرتبط إلى شريحة عرض تقديمي، عند فتح العرض في PowerPoint قد ترى رسالة تطلب منك تحديث الروابط. النقر على زر "Update Links" قد يغيّر حجم وموقع إطار كائن OLE لأن PowerPoint يُحدّث البيانات من كائن OLE المرتبط ويُعيد تحميل معاينة الكائن. لمنع PowerPoint من طلب تحديث بيانات الكائن، عيّن خاصية `UpdateAutomatic` للواجهة [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe/) إلى `false`:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    IOleObjectFrame oleFrame = (IOleObjectFrame)presentation.Slides[0].Shapes[0];

    // احتفظ بحجم ومكان إطار كائن OLE عندما يقوم PowerPoint بتحديث الارتباط.
    oleFrame.UpdateAutomatic = false;

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **استخراج الملفات المدمجة**

Aspose.Slides for .NET يتيح لك استخراج الملفات المدمجة في الشرائح ككائنات OLE بهذه الطريقة:
1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) التي تحتوي على كائنات OLE التي تنوي استخراجها.
2. التمرّ عبر جميع الأشكال في العرض والوصول إلى أشكال [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe).
3. الوصول إلى بيانات الملفات المدمجة من إطارات OLE وكتابتها إلى القرص.

يعرض هذا الكود C# كيفية استخراج الملفات المدمجة في شريحة ككائنات OLE:

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

**هل سيتم عرض محتوى OLE عند تصدير الشرائح إلى PDF/صور؟**

ما هو مرئي على الشريحة يتم عرضه — الأيقونة/صورة الاستبدال (المعاينة). لا يتم تنفيذ محتوى OLE "الحي" أثناء التصيير. إذا لزم الأمر، عيّن صورة معاينة خاصة بك لضمان المظهر المتوقع في ملف PDF المُصدَّر.

للحفاظ أيضًا على الملف المدمج كمرفق PDF، عيّن [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) إلى `true`. هذا الخيار مُعطَّل افتراضيًا. للحصول على مثال وتعليمات للتحقق من المرفق، راجع [Preserve Embedded OLE Files as PDF Attachments](/slides/ar/net/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**كيف يمكنني قفل كائن OLE على شريحة بحيث لا يتمكن المستخدمون من تحريكه/تحريره في PowerPoint؟**

قفل الشكل: Aspose.Slides يقدم [shape-level locks](/slides/ar/net/applying-protection-to-presentation/). هذا ليس تشفيرًا، لكنه يمنع التحرير والتحريك غير المقصود بفعالية.

**لماذا "يقفز" كائن Excel مرتبط أو يتغيّر حجمه عندما أفتح العرض التقديمي؟**

قد يقوم PowerPoint بتحديث معاينة OLE المرتبط. للحصول على مظهر ثابت، اتّبع ممارسات [Working Solution for Worksheet Resizing](/slides/ar/net/working-solution-for-worksheet-resizing/) — إما ملاءمة الإطار للنطاق، أو تحجيم النطاق إلى إطار ثابت وتعيين صورة بديلة مناسبة.

**هل سيتم الحفاظ على المسارات النسبية لكائنات OLE المرتبطة في تنسيق PPTX؟**

في PPTX، لا تتوفر معلومات "المسار النسبي" — فقط المسار الكامل. تُوجد المسارات النسبية في صيغة PPT القديمة. من أجل القابلية للنقل، يُفضَّل استخدام مسارات مطلقة موثوقة/عناوين URI قابلة للوصول أو الإدراج.