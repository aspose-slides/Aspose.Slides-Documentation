---
title: تحسين إدارة الصور في العروض التقديمية في .NET
linktitle: إدارة الصور
type: docs
weight: 10
url: /ar/net/image/
keywords:
- إضافة صورة
- إضافة صورة
- إضافة bitmap
- استبدال صورة
- استبدال صورة
- من الويب
- خلفية
- إضافة PNG
- إضافة JPG
- إضافة SVG
- إضافة EMF
- إضافة WMF
- إضافة TIFF
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تحسين إدارة الصور في PowerPoint و OpenDocument باستخدام Aspose.Slides لـ .NET، مع تحسين الأداء وأتمتة سير العمل."
---

## **الصور في شرائح العرض**

تجعل الصور العروض التقديمية أكثر جاذبية وإثارة للاهتمام. في Microsoft PowerPoint، يمكنك إدراج صور من ملف أو من الإنترنت أو من مواقع أخرى على الشرائح. وبالمثل، يسمح Aspose.Slides لك بإضافة الصور إلى الشرائح في عروضك التقديمية عبر إجراءات مختلفة.

{{% alert  title="Tip" color="primary" %}} 

يوفر Aspose محولات مجانية—[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) و[PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—تمكن الأشخاص من إنشاء عروض تقديمية بسرعة من الصور. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

إذا أردت إضافة صورة ككائن إطار—خاصة إذا كنت تخطط لاستخدام خيارات تنسيق قياسية لتغيير حجمها وإضافة تأثيرات وغيرها—اطلع على [Picture Frame](https://docs.aspose.com/slides/net/picture-frame/). 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

يمكنك معالجة عمليات الإدخال/الإخراج المتعلقة بالصور وعروض PowerPoint لتحويل صورة من صيغة إلى أخرى. راجع الصفحات التالية: تحويل [image to JPG](https://products.aspose.com/slides/net/conversion/image-to-jpg/); تحويل [JPG to image](https://products.aspose.com/slides/net/conversion/jpg-to-image/); تحويل [JPG to PNG](https://products.aspose.com/slides/net/conversion/jpg-to-png/)، تحويل [PNG to JPG](https://products.aspose.com/slides/net/conversion/png-to-jpg/); تحويل [PNG to SVG](https://products.aspose.com/slides/net/conversion/png-to-svg/)، تحويل [SVG to PNG](https://products.aspose.com/slides/net/conversion/svg-to-png/).

{{% /alert %}}

يدعم Aspose.Slides عمليات التعامل مع الصور في هذه الصيغ الشائعة: JPEG، PNG، BMP، GIF، وغيرها. 

## **إضافة صور مخزنة محليًا إلى الشرائح**

يمكنك إضافة صورة واحدة أو عدة صور من جهاز الكمبيوتر إلى شريحة في عرض تقديمي. يوضح هذا المثال البرمجي بلغة C# طريقة إضافة صورة إلى شريحة:
```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **إضافة صور من الويب إلى الشرائح**

إذا كانت الصورة التي تريد إضافتها إلى شريحة غير متوفرة على جهازك، يمكنك إضافتها مباشرة من الويب. 

يعرض هذا المثال البرمجي طريقة إضافة صورة من الويب إلى شريحة بلغة C#:
```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] imageData;
    using (WebClient webClient = new WebClient()) 
    {
        imageData = webClient.DownloadData(new Uri("[REPLACE WITH URL]"));
    }
    
    IPPImage image = pres.Images.AddImage(imageData);
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **إضافة صور إلى القوالب الرئيسية للشرائح**

القالب الرئيسي للشرائح هو الشريحة العلوية التي تخزن وتتحكم في المعلومات (السمة، التخطيط، إلخ) الخاصة بجميع الشرائح تحته. لذلك، عندما تضيف صورة إلى قالب رئيسي، تظهر تلك الصورة على كل شريحة تحت هذا القالب. 

يعرض هذا المثال البرمجي بلغة C# طريقة إضافة صورة إلى قالب رئيسي للشرائح:
```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IMasterSlide masterSlide = slide.LayoutSlide.MasterSlide;
    
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    masterSlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **إضافة صور كخلفيات للشرائح**

قد تقرر استخدام صورة كخلفية لشريحة معينة أو لعدة شرائح. في هذه الحالة، عليك الاطلاع على *[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/net/presentation-background/#setting-images-as-background-for-slides)*.

## **إضافة SVG إلى العروض التقديمية**
يمكنك إضافة أو إدراج أي صورة في عرض تقديمي باستخدام طريقة [AddPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/methods/addpictureframe) التي تنتمي إلى الواجهة [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection).

لإنشاء كائن صورة بناءً على صورة SVG، يمكنك القيام بذلك بهذه الطريقة:

1. إنشاء كائن SvgImage لإدراجه في ImageShapeCollection  
2. إنشاء كائن PPImage من ISvgImage  
3. إنشاء كائن PictureFrame باستخدام واجهة IPPImage  

يعرض هذا المثال البرمجي كيفية تنفيذ الخطوات السابقة لإضافة صورة SVG إلى عرض تقديمي:
```csharp
// مسار دليل المستندات
string dataDir = @"D:\Documents\";

// اسم ملف SVG المصدر
string svgFileName = dataDir + "sample.svg";

// اسم ملف عرض التقديم الناتج
string outPptxPath = dataDir + "presentation.pptx";

// إنشاء عرض تقديمي جديد
using (var p = new Presentation())
{
    // قراءة محتوى ملف SVG
    string svgContent = File.ReadAllText(svgFileName);

    // إنشاء كائن SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // إنشاء كائن PPImage
    IPPImage ppImage = p.Images.AddImage(svgImage);

    // إنشاء PictureFrame جديد
    p.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 200, 100, ppImage.Width, ppImage.Height, ppImage);

    // حفظ العرض التقديمي بتنسيق PPTX
    p.Save(outPptxPath, SaveFormat.Pptx);
}
```


## **تحويل SVG إلى مجموعة من الأشكال**
تحويل Aspose.Slides لـ SVG إلى مجموعة من الأشكال مشابه لوظيفة PowerPoint المستخدمة للتعامل مع صور SVG:

![PowerPoint Popup Menu](img_01_01.png)

توفر هذه الوظيفة أحد التحميلات الزائدة للطريقة [AddGroupShape](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/addgroupshape/methods/1) في الواجهة [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection) التي تقبل كائن [ISvgImage](https://reference.aspose.com/slides/net/aspose.slides/isvgimage) كأول معطى.

يعرض هذا المثال البرمجي طريقة استخدام الطريقة المذكورة لتحويل ملف SVG إلى مجموعة من الأشكال:
```csharp
// مسار دليل المستندات
string dataDir = @"D:\Documents\";

// اسم ملف SVG المصدر
string svgFileName = dataDir + "sample.svg";

// اسم ملف العرض التقديمي الناتج
string outPptxPath = dataDir + "presentation.pptx";

// إنشاء عرض تقديمي جديد
using (IPresentation presentation = new Presentation())
{
    // قراءة محتوى ملف SVG
    string svgContent = File.ReadAllText(svgFileName);

    // إنشاء كائن SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // الحصول على حجم الشريحة
    SizeF slideSize = presentation.SlideSize.Size;

    // تحويل صورة SVG إلى مجموعة من الأشكال وتكبيرها لتناسب حجم الشريحة
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // حفظ العرض التقديمي بتنسيق PPTX
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```


## **إضافة صور كـ EMF إلى الشرائح**
تتيح Aspose.Slides for .NET إنشاء صور EMF من جداول Excel وإضافة الصور كـ EMF في الشرائح باستخدام Aspose.Cells.  

يعرض هذا المثال البرمجي كيفية تنفيذ المهمة المذكورة:
```csharp
using (Workbook book = new Workbook(dataDir + "chart.xlsx"))
{
    Worksheet sheet = book.Worksheets[0];
    ImageOrPrintOptions options = new ImageOrPrintOptions();
    options.HorizontalResolution = 200;
    options.VerticalResolution = 200;
    options.ImageFormat = System.Drawing.Imaging.ImageFormat.Emf;

    // حفظ المصنف إلى التدفق
    SheetRender sr = new SheetRender(sheet, options);
    using (Presentation pres = new Presentation())
    {
        pres.Slides.RemoveAt(0);

        String EmfSheetName = "";
        for (int j = 0; j < sr.PageCount; j++)
        {
            EmfSheetName = dataDir + "test" + sheet.Name + " Page" + (j + 1) + ".out.emf";
            sr.ToImage(j, EmfSheetName);

            var bytes = File.ReadAllBytes(EmfSheetName);
            var emfImage = pres.Images.AddImage(bytes);
            ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides.GetByType(SlideLayoutType.Blank));
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, pres.SlideSize.Size.Width, pres.SlideSize.Size.Height, emfImage);
        }

        pres.Save(dataDir + "Saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
```


## **استبدال الصور في مجموعة الصور**

يتيح Aspose.Slides لك استبدال الصور المخزنة في مجموعة صور العرض التقديمي (بما في ذلك تلك المستخدمة في أشكال الشرائح). يوضح هذا القسم عدة أساليب لتحديث الصور في المجموعة. توفر الواجهة طرقًا مباشرة لاستبدال صورة باستخدام بيانات بايت خام، أو كائن [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) ، أو صورة أخرى موجودة مسبقًا في المجموعة.

اتبع الخطوات التالية:

1. تحميل ملف العرض التقديمي الذي يحتوي على الصور باستخدام الصنف [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).  
2. تحميل صورة جديدة من ملف إلى مصفوفة بايت.  
3. استبدال الصورة المستهدفة بالصورة الجديدة باستخدام مصفوفة البايت.  
4. في الأسلوب الثاني، تحميل الصورة إلى كائن [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) واستبدال الصورة المستهدفة بهذا الكائن.  
5. في الأسلوب الثالث، استبدال الصورة المستهدفة بصورة موجودة بالفعل في مجموعة صور العرض التقديمي.  
6. كتابة العرض التقديمي المعدل كملف PPTX.  
```cs
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
using Presentation presentation = new Presentation("sample.pptx");

// الطريقة الأولى.
byte[] imageData = File.ReadAllBytes("image0.jpeg");
IPPImage oldImage = presentation.Images[0];
oldImage.ReplaceImage(imageData);

// الطريقة الثانية.
using IImage newImage = Images.FromFile("image1.png");
oldImage = presentation.Images[1];
oldImage.ReplaceImage(newImage);

// الطريقة الثالثة.
oldImage = presentation.Images[2];
oldImage.ReplaceImage(presentation.Images[3]);

// حفظ العرض التقديمي إلى ملف.
presentation.Save("output.pptx", SaveFormat.Pptx);
```


{{% alert title="Info" color="info" %}}

باستخدام محول Aspose FREE [Text to GIF](https://products.aspose.app/slides/text-to-gif) يمكنك بسهولة تحريك النصوص وإنشاء ملفات GIF من النصوص، إلخ. 

{{% /alert %}}

## **FAQ**

**هل يبقى دقة الصورة الأصلية دون تغيير بعد الإدراج؟**

نعم. تُحافظ على بكسلات المصدر، لكن المظهر النهائي يعتمد على كيفية تعديل حجم [picture](/slides/ar/net/picture-frame/) على الشريحة وأي ضغط يتم تطبيقه عند الحفظ.

**ما هي أفضل طريقة لاستبدال الشعار نفسه عبر العشرات من الشرائح مرة واحدة؟**

ضع الشعار على الشريحة الرئيسة أو على تخطيط، ثم استبدله في مجموعة صور العرض التقديمي—سيتداول التحديث إلى جميع العناصر التي تستخدم هذا المورد.

**هل يمكن تحويل SVG المدرج إلى أشكال قابلة للتحرير؟**

نعم. يمكنك تحويل SVG إلى مجموعة من الأشكال، وبعد ذلك تصبح الأجزاء الفردية قابلة للتحرير باستخدام خصائص الشكل القياسية.

**كيف يمكنني تعيين صورة كخلفية لعدة شرائح في آن واحد؟**

[Assign the image as the background](/slides/ar/net/presentation-background/) على الشريحة الرئيسة أو التخطيط المناسب—ستورث جميع الشرائح التي تستخدم ذلك الرئيس/التخطيط الخلفية.

**كيف أمنع تضخم حجم العرض التقديمي بسبب كثرة الصور؟**

أعد استخدام مورد صورة واحد بدلاً من النسخ المتعددة، واختر دقة معقولة، وطبق ضغطًا عند الحفظ، واحتفظ بالرسومات المتكررة على القالب الرئيس حيثما كان ذلك مناسبًا.