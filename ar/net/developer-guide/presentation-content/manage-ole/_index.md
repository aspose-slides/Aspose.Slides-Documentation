---
title: إدارة OLE
type: docs
weight: 40
url: /ar/net/manage-ole/
keywords:
- إضافة OLE
- تضمين OLE
- إضافة كائن
- تضمين كائن
- تضمين ملف
- كائن مرتبط
- ربط الكائنات وتضمينها
- كائن OLE
- باوربوينت 
- عرض تقديمي
- C#
- Csharp
- Aspose.Slides لـ .NET
description: إضافة كائنات OLE إلى عروض باوربوينت في C# أو .NET
---

{{% alert title="معلومات" color="info" %}}

إن OLE (ربط الكائنات وتضمينها) هو تقنية من مايكروسوفت تسمح بتضمين البيانات والكائنات التي تم إنشاؤها في أحد التطبيقات داخل تطبيق آخر من خلال الربط أو التضمين. 

{{% /alert %}}

اعتبر رسمًا بيانيًا تم إنشاؤه في MS Excel. يتم بعد ذلك وضع الرسم البياني داخل شريحة باوربوينت. هذا الرسم البياني من Excel يعتبر كائن OLE. 

- قد يظهر كائن OLE كأيقونة. في هذه الحالة، عندما تنقر نقرًا مزدوجًا على الأيقونة، يُفتح الرسم البياني في تطبيقه المرتبط (Excel)، أو يُطلب منك اختيار تطبيق لفتح الكائن أو تحريره.
- قد يعرض كائن OLE المحتويات الفعلية — على سبيل المثال، محتويات رسم بياني. في هذه الحالة، يتم تفعيل الرسم البياني في باوربوينت، وتحميل واجهة الرسم البياني، ويمكنك تعديل بيانات الرسم البياني داخل تطبيق باوربوينت.

يسمح لك [Aspose.Slides لـ .NET](https://products.aspose.com/slides/net/) بإدراج كائنات OLE في الشرائح كإطارات كائن OLE ([OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)).

## **إضافة إطارات كائن OLE إلى الشرائح**
افترض أنك قد أنشأت بالفعل رسمًا بيانيًا في Microsoft Excel وترغب في تضمين هذا الرسم البياني في شريحة كإطار كائن OLE باستخدام Aspose.Slides لـ .NET، يمكنك القيام بذلك بهذه الطريقة:

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. فتح ملف Excel الذي يحتوي على كائن الرسم البياني Excel وحفظه إلى `MemoryStream`.
4. إضافة [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) إلى الشريحة التي تحتوي على مصفوفة بايتات ومعلومات أخرى حول كائن OLE.
5. كتابة العرض المعدل كملف PPTX.

في المثال أدناه، أضفنا رسمًا بيانيًا من ملف Excel إلى شريحة كإطار [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) باستخدام Aspose.Slides لـ .NET.  
**ملاحظة** أن مُنشئ [IOleEmbeddedDataInfo](https://reference.aspose.com/slides/net/aspose.slides/ioleembeddeddatainfo) يأخذ امتداد كائن يمكن تضمينه كمعامل ثاني. يسمح هذا الامتداد لباوربوينت بتفسير نوع الملف بشكل صحيح واختيار التطبيق المناسب لفتح كائن OLE.

``` csharp 
// ينشئ مثيلًا من فئة Presentation التي تمثل ملف PPTX
using (Presentation pres = new Presentation())
{
    // الوصول إلى الشريحة الأولى
    ISlide sld = pres.Slides[0];

    // تحميل ملف Excel إلى دفق
    MemoryStream mstream = new MemoryStream();
    using (FileStream fs = new FileStream("book1.xlsx", FileMode.Open, FileAccess.Read))
    {
        byte[] buf = new byte[4096];

        while (true)
        {
            int bytesRead = fs.Read(buf, 0, buf.Length);
            if (bytesRead <= 0)
                break;
            mstream.Write(buf, 0, bytesRead);
        }
    }

    // إنشاء كائن بيانات للتضمين
    IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(mstream.ToArray(), "xlsx");

    // إضافة شكل إطار كائن Ole
    IOleObjectFrame oleObjectFrame = sld.Shapes.AddOleObjectFrame(0, 0, pres.SlideSize.Size.Width,
        pres.SlideSize.Size.Height, dataInfo);

    // كتابة ملف PPTX إلى القرص
    pres.Save("OleEmbed_out.pptx", SaveFormat.Pptx);
}
```
### إضافة إطارات كائن OLE المرتبطة

يسمح لك Aspose.Slides لـ .NET بإضافة [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) دون تضمين البيانات ولكن فقط مع ارتباط إلى الملف.

هذا الرمز بلغة C# يوضح لك كيفية إضافة [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) مع ملف Excel مرتبط إلى شريحة:

``` csharp 
using (Presentation pres = new Presentation())
{
	// الوصول إلى الشريحة الأولى
	ISlide slide = pres.Slides[0];

	// إضافة إطار كائن Ole مع ملف Excel مرتبط
    IOleObjectFrame oleObjectFrame = slide.Shapes.AddOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book1.xlsx");

	// كتابة ملف PPTX إلى القرص
	pres.Save("OleLinked_out.pptx", SaveFormat.Pptx);
}
```

## **الوصول إلى إطارات كائن OLE**
إذا كان كائن OLE قد تم تضمينه بالفعل في شريحة، يمكنك العثور على ذلك الكائن أو الوصول إليه بسهولة بهذه الطريقة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. الحصول على مرجع الشريحة باستخدام فهرسها.
3. الوصول إلى شكل [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe).
   في مثالنا، استخدمنا PPTX الذي تم إنشاؤه سابقًا والذي يحتوي على شكل واحد فقط على الشريحة الأولى. ثم قمنا بتحويل ذلك الكائن إلى [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) كما هو مطلوب للوصول إليه.
4. بمجرد الوصول إلى إطار كائن OLE، يمكنك القيام بأي عملية عليه.
في المثال أدناه، يتم الوصول إلى إطار كائن OLE (كائن رسم بياني Excel مضمن في شريحة) - ثم يتم كتابة بيانات ملفه إلى ملف Excel:
``` csharp 
// تحميل PPTX إلى كائن تقديم
using (Presentation pres = new Presentation("AccessingOLEObjectFrame.pptx"))
{
    // الوصول إلى الشريحة الأولى
    ISlide sld = pres.Slides[0];

    // تحويل الشكل إلى OleObjectFrame
    OleObjectFrame oleObjectFrame = sld.Shapes[0] as OleObjectFrame;

    // قراءة كائن OLE وكتابته إلى القرص
    if (oleObjectFrame != null)
    {
        // الحصول على بيانات الملف المضمنة
        byte[] data = oleObjectFrame.EmbeddedData.EmbeddedFileData;

        // الحصول على امتداد الملف المضمن
        string fileExtention = oleObjectFrame.EmbeddedData.EmbeddedFileExtension;

        // إنشاء مسار لحفظ الملف المستخرج
        string extractedPath = "excelFromOLE_out" + fileExtention;

        // حفظ البيانات المستخرجة
        using (FileStream fstr = new FileStream(extractedPath, FileMode.Create, FileAccess.Write))
        {
            fstr.Write(data, 0, data.Length);
        }
    }
}
```

### الوصول إلى خصائص إطارات كائن OLE المرتبطة

يسمح لك Aspose.Slides بالوصول إلى خصائص إطار كائن OLE المرتبط.

هذا الرمز بلغة C# يوضح لك كيفية التحقق مما إذا كان كائن OLE مرتبطًا ثم الحصول على مسار الملف المرتبط:
```csharp
using (Presentation pres = new Presentation("OleLinked.ppt"))
{
	// الوصول إلى الشريحة الأولى
	ISlide slide = pres.Slides[0];

	// الحصول على الشكل الأول كإطار كائن Ole
	OleObjectFrame oleObjectFrame = slide.Shapes[0] as OleObjectFrame;

	// تحقق مما إذا كان كائن Ole مرتبطًا.
	if (oleObjectFrame != null && oleObjectFrame.IsObjectLink)
	{
		// طباعة المسار الكامل لملف مرتبط
		Console.WriteLine("إطار كائن Ole مرتبط بـ: " + oleObjectFrame.LinkPathLong);

		// طباعة المسار النسبي لملف مرتبط إذا كان موجودًا.
		// يمكن أن تحتوي عروض PPT فقط على المسار النسبي.
		string relativePath = oleObjectFrame.LinkPathRelative;
		if (!string.IsNullOrEmpty(relativePath))
		{
			Console.WriteLine("المسار النسبي لإطار كائن Ole: " + oleObjectFrame.LinkPathRelative);
		}
	}
}
```
## **تغيير بيانات كائن OLE**

إذا كان كائن OLE قد تم تضمينه بالفعل في شريحة، يمكنك الوصول بسهولة إلى ذلك الكائن وتعديل بياناته بهذه الطريقة:

1. فتح العرض التقديمي المرغوب الذي يحتوي على كائن OLE المضمن من خلال إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
2. الحصول على مرجع الشريحة من خلال فهرسها. 
3. الوصول إلى شكل [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe).
   في مثالنا، استخدمنا PPTX الذي تم إنشاؤه سابقًا والذي يحتوي على شكل واحد على الشريحة الأولى. ثم قمنا بتحويل ذلك الكائن إلى [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) كما هو المطلوب للوصول إليه.
4. بمجرد الوصول إلى إطار كائن OLE، يمكنك القيام بأي عملية عليه.
5. إنشاء كائن Workbook والوصول إلى بيانات OLE.
6. الوصول إلى ورقة العمل المطلوبة وتعديل البيانات.
7. حفظ Workbook المحدث في تدفقات.
8. تغيير بيانات كائن OLE من بيانات التدفق.
في المثال أدناه، يتم الوصول إلى إطار كائن OLE (كائن رسم بياني Excel مضمن في شريحة) - ثم يتم تعديل بيانات ملفه لتغيير بيانات الرسم البياني:
``` csharp 
using (Presentation pres = new Presentation("ChangeOLEObjectData.pptx"))
{
    ISlide slide = pres.Slides[0];

    OleObjectFrame ole = null;

    // يتجول في جميع الأشكال بحثًا عن إطار Ole
    foreach (IShape shape in slide.Shapes)
    {
        if (shape is OleObjectFrame)
        {
            ole = (OleObjectFrame)shape;
        }
    }

    if (ole != null)
    {
        using (MemoryStream msln = new MemoryStream(ole.EmbeddedData.EmbeddedFileData))
        {
            // قراءة بيانات الكائن في Workbook
            Workbook Wb = new Workbook(msln);

            using (MemoryStream msout = new MemoryStream())
            {
                // تعديل بيانات workbook
                Wb.Worksheets[0].Cells[0, 4].PutValue("E");
                Wb.Worksheets[0].Cells[1, 4].PutValue(12);
                Wb.Worksheets[0].Cells[2, 4].PutValue(14);
                Wb.Worksheets[0].Cells[3, 4].PutValue(15);

                OoxmlSaveOptions so1 = new OoxmlSaveOptions(Aspose.Cells.SaveFormat.Xlsx);
                Wb.Save(msout, so1);

                // تغيير بيانات كائن إطار Ole
                IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(msout.ToArray(), ole.EmbeddedData.EmbeddedFileExtension);
                ole.SetEmbeddedData(newData);
            }
        }
    }

    pres.Save("OleEdit_out.pptx", SaveFormat.Pptx);
}
```
## **تضمين أنواع ملفات أخرى في الشرائح**

بجانب الرسوم البيانية Excel، يسمح Aspose.Slides لـ .NET بتضمين أنواع أخرى من الملفات في الشرائح. على سبيل المثال، يمكنك إدراج ملفات HTML وPDF وZIP ككائنات في شريحة. عندما ينقر المستخدم نقرًا مزدوجًا على الكائن المدخل، يتم تشغيل الكائن تلقائيًا في البرنامج المناسب، أو يتم توجيه المستخدم لاختيار برنامج مناسب لفتح الكائن.

هذا الرمز بلغة C# يوضح لك كيفية تضمين HTML وZIP في شريحة:

```c#
using (Presentation pres = new Presentation())
{
  ISlide slide = pres.Slides[0];
  
  byte[] htmlBytes = File.ReadAllBytes("embedOle.html");
  IOleEmbeddedDataInfo dataInfoHtml = new OleEmbeddedDataInfo(htmlBytes, "html");
  IOleObjectFrame oleFrameHtml = slide.Shapes.AddOleObjectFrame(150, 120, 50, 50, dataInfoHtml);
  oleFrameHtml.IsObjectIcon = true;

  byte[] zipBytes = File.ReadAllBytes("embedOle.zip");
  IOleEmbeddedDataInfo dataInfoZip = new OleEmbeddedDataInfo(zipBytes, "zip");
  IOleObjectFrame oleFrameZip = slide.Shapes.AddOleObjectFrame(150, 220, 50, 50, dataInfoZip);
  oleFrameZip.IsObjectIcon = true;

  pres.Save("embeddedOle.pptx", SaveFormat.Pptx);
}
```
## **تعيين أنواع الملفات للكائنات المضمنة**

عند العمل على العروض التقديمية، قد تحتاج إلى استبدال كائنات OLE القديمة بكائنات جديدة. أو قد تحتاج إلى استبدال كائن OLE غير المدعوم بكائن مدعوم.

يسمح لك Aspose.Slides لـ .NET بتعيين نوع الملف لكائن مضمن. بهذه الطريقة، يمكنك تغيير بيانات إطار OLE أو امتداده.

هذا الرمز بلغة C# يوضح لك كيفية تعيين نوع الملف لكائن OLE المضمن:

```c#
using (Presentation pres = new Presentation("embeddedOle.pptx"))
{
    ISlide slide = pres.Slides[0];
    IOleObjectFrame oleObjectFrame = (IOleObjectFrame)slide.Shapes[0];
    Console.WriteLine($"الامتداد الحالي للبيانات المضمنة هو: {oleObjectFrame.EmbeddedData.EmbeddedFileExtension}");
   
    oleObjectFrame.SetEmbeddedData(new OleEmbeddedDataInfo(File.ReadAllBytes("embedOle.zip"), "zip"));
   
    pres.Save("embeddedChanged.pptx", SaveFormat.Pptx);
}
```
## **تعيين صور الأيقونات والعناوين للكائنات المضمنة**

بعد تضمين كائن OLE، تتم إضافة معاينة تتكون من صورة أيقونة وعنوان تلقائيًا. المعاينة هي ما يراه المستخدمون قبل وصولهم إلى الكائن OLE أو فتحه.

إذا كنت ترغب في استخدام صورة ونص محددين كعناصر في المعاينة، يمكنك تعيين صورة الأيقونة والعنوان باستخدام Aspose.Slides لـ .NET.

هذا الرمز بلغة C# يوضح لك كيفية تعيين صورة الأيقونة والعنوان لكائن مضمن: 

```c#
using (Presentation pres = new Presentation("embeddedOle.pptx"))
{
    ISlide slide = pres.Slides[0];
    IOleObjectFrame oleObjectFrame = (IOleObjectFrame)slide.Shapes[0];

    IPPImage oleImage = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    oleObjectFrame.SubstitutePictureTitle = "عنواني";
    oleObjectFrame.SubstitutePictureFormat.Picture.Image = oleImage;
    oleObjectFrame.IsObjectIcon = false;

    pres.Save("embeddedOle-newImage.pptx", SaveFormat.Pptx);
}
```

## **منع تغيير حجم إطار كائن OLE وإعادة وضعه**

بعد إضافة كائن OLE مرتبط إلى شريحة عرض تقديمي، عندما تفتح العرض في باوربوينت، قد ترى رسالة تطلب منك تحديث الروابط. قد يؤدي النقر على زر "تحديث الروابط" إلى تغيير حجم وموقع إطار كائن OLE لأن باوربوينت تحدث البيانات من كائن OLE المرتبط وتقوم بتحديث معاينة الكائن. لمنع باوربوينت من المطالبة بتحديث بيانات الكائن، قم بتعيين خاصية `UpdateAutomatic` لواجهة [IOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe/) إلى `false`:

```cs
oleObjectFrame.UpdateAutomatic = false;
```

## **استخراج الملفات المضمنة**

يسمح Aspose.Slides لـ .NET باستخراج الملفات المضمنة في الشرائح ككائنات OLE بهذه الطريقة:
1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) التي تحتوي على كائن OLE الذي تنوي استخراجه.
2. التكرار عبر جميع الأشكال في العرض والوصول إلى شكل [OLEObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe).
3. الوصول إلى بيانات الملف المضمن من إطار كائن OLE وكتابته إلى القرص. 
هذا الرمز بلغة C# يوضح لك كيفية استخراج ملف مضمن في شريحة ككائن OLE:
```c#
using (Presentation pres = new Presentation("embeddedOle.pptx"))
{
    ISlide slide = pres.Slides[0];

    for (var index = 0; index < slide.Shapes.Count; index++)
    {
        IShape shape = slide.Shapes[index];
        
        IOleObjectFrame oleFrame = shape as IOleObjectFrame;
        
        if (oleFrame != null)
        {
            byte[] data = oleFrame.EmbeddedData.EmbeddedFileData;
            string extension = oleFrame.EmbeddedData.EmbeddedFileExtension;
            
            File.WriteAllBytes($"oleFrame{index}{extension}", data);
        }
    }
}
```