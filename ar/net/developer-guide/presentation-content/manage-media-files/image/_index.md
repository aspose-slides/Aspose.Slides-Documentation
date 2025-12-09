---
title: تحسين إدارة الصور في العروض التقديمية باستخدام .NET
linktitle: إدارة الصور
type: docs
weight: 10
url: /ar/net/image/
keywords:
- إضافة صورة
- إضافة صورة
- إضافة Bitmap
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
description: "تبسيط إدارة الصور في PowerPoint وOpenDocument باستخدام Aspose.Slides لـ .NET، وتحسين الأداء وأتمتة سير العمل الخاص بك."
---

## **الصور في الشرائح في العروض التقديمية**

تجعل الصور العروض التقديمية أكثر جاذبية وإثارة للاهتمام. في Microsoft PowerPoint، يمكنك إدراج صور من ملف أو الإنترنت أو مواقع أخرى على الشرائح. بالمثل، يتيح لك Aspose.Slides إضافة صور إلى الشرائح في عروضك التقديمية عبر إجراءات مختلفة.

{{% alert  title="نصيحة" color="primary" %}} 
توفر Aspose محولات مجانية—[JPEG إلى PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) و[PNG إلى PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—تمكن الأشخاص من إنشاء عروض تقديمية بسرعة من الصور. 
{{% /alert %}} 

{{% alert title="معلومات" color="info" %}}
إذا كنت تريد إضافة صورة ككائن إطار—خاصة إذا كنت تخطط لاستخدام خيارات تنسيق قياسية لتغيير حجمها، وإضافة التأثيرات، وما إلى ذلك—اطلع على [إطار الصورة](https://docs.aspose.com/slides/net/picture-frame/). 
{{% /alert %}} 

{{% alert title="ملاحظة" color="warning" %}}
يمكنك معالجة عمليات الإدخال/الإخراج المتعلقة بالصور وعروض PowerPoint لتحويل صورة من تنسيق إلى آخر. راجع هذه الصفحات: تحويل [صورة إلى JPG](https://products.aspose.com/slides/net/conversion/image-to-jpg/); تحويل [JPG إلى صورة](https://products.aspose.com/slides/net/conversion/jpg-to-image/); تحويل [JPG إلى PNG](https://products.aspose.com/slides/net/conversion/jpg-to-png/)، تحويل [PNG إلى JPG](https://products.aspose.com/slides/net/conversion/png-to-jpg/); تحويل [PNG إلى SVG](https://products.aspose.com/slides/net/conversion/png-to-svg/)، تحويل [SVG إلى PNG](https://products.aspose.com/slides/net/conversion/svg-to-png/).
{{% /alert %}}

يدعم Aspose.Slides عمليات الصور بهذه الصيغ الشائعة: JPEG, PNG, BMP, GIF، وغيرها. 

## **إضافة الصور المخزنة محليًا إلى الشرائح**

يمكنك إضافة صورة واحدة أو عدة صور من جهاز الكمبيوتر الخاص بك إلى شريحة في عرض تقديمي. يوضح لك هذا المثال البرمجي بلغة C# كيفية إضافة صورة إلى شريحة:
```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **إضافة الصور من الويب إلى الشرائح**

إذا كانت الصورة التي تريد إضافتها إلى شريحة غير متوفرة على جهازك، يمكنك إضافة الصورة مباشرة من الويب. 

يظهر لك هذا المثال البرمجي كيفية إضافة صورة من الويب إلى شريحة بلغة C#:
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


## **إضافة الصور إلى القوالب الرئيسية للشرائح**

قالب الشريحة الرئيسي هو الشريحة العليا التي تخزن وتتحكم بالمعلومات (السمة، التخطيط، إلخ) لجميع الشرائح تحته. لذلك، عندما تضيف صورة إلى قالب الشريحة الرئيسي، تظهر تلك الصورة على كل شريحة تحت هذا القالب. 

يظهر لك هذا المثال البرمجي بلغة C# كيفية إضافة صورة إلى قالب الشريحة الرئيسي:
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


## **إضافة الصور كخلفية للشرائح**

قد تقرر استخدام صورة كخلفية لشريحة معينة أو عدة شرائح. في هذه الحالة، يجب عليك الاطلاع على *[ضبط الصور كخلفيات للشرائح](https://docs.aspose.com/slides/net/presentation-background/#setting-images-as-background-for-slides)*.

## **إضافة SVG إلى العروض التقديمية**

يمكنك إضافة أو إدراج أي صورة في عرض تقديمي باستخدام طريقة [AddPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/methods/addpictureframe) التي تنتمي إلى واجهة [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection). 

لإنشاء كائن صورة يعتمد على صورة SVG، يمكنك القيام بذلك بهذه الطريقة:

1. إنشاء كائن SvgImage لإدراجه في ImageShapeCollection
2. إنشاء كائن PPImage من ISvgImage
3. إنشاء كائن PictureFrame باستخدام واجهة IPPImage

يعرض لك هذا المثال البرمجي كيفية تنفيذ الخطوات أعلاه لإضافة صورة SVG إلى عرض تقديمي:
```csharp
// مسار دليل المستندات
string dataDir = @"D:\Documents\";

// اسم ملف SVG المصدر
string svgFileName = dataDir + "sample.svg";

// اسم ملف العرض التقديمي الناتج
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

    // إنشاء إطار صورة جديد 
    p.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 200, 100, ppImage.Width, ppImage.Height, ppImage);

    // حفظ العرض التقديمي بتنسيق PPTX
    p.Save(outPptxPath, SaveFormat.Pptx);
}
```


## **تحويل SVG إلى مجموعة من الأشكال**

تحويل Aspose.Slides لـ SVG إلى مجموعة من الأشكال مشابه للوظيفة في PowerPoint المستخدمة للعمل مع صور SVG:

![PowerPoint Popup Menu](img_01_01.png)

توفر هذه الوظيفة أحد التحميلات الزائدة لطريقة [AddGroupShape](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/addgroupshape/methods/1) في واجهة [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection) التي تأخذ كائن [ISvgImage](https://reference.aspose.com/slides/net/aspose.slides/isvgimage) كمعامل أول.

يعرض لك هذا المثال البرمجي كيفية استخدام الطريقة الموصوفة لتحويل ملف SVG إلى مجموعة من الأشكال:
``` csharp 
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

    // تحويل صورة SVG إلى مجموعة من الأشكال وتوسيعها لتتناسب مع حجم الشريحة
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // حفظ العرض التقديمي بتنسيق PPTX
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```


## **إضافة الصور كـ EMF في الشرائح**

يتيح لك Aspose.Slides لـ .NET إنشاء صور EMF من جداول Excel وإضافة الصور كـ EMF في الشرائح باستخدام Aspose.Cells. 

يعرض لك هذا المثال البرمجي كيفية تنفيذ المهمة الموصوفة:
``` csharp 
using (Workbook book = new Workbook(dataDir + "chart.xlsx"))
{
    Worksheet sheet = book.Worksheets[0];
    ImageOrPrintOptions options = new ImageOrPrintOptions();
    options.HorizontalResolution = 200;
    options.VerticalResolution = 200;
    options.ImageFormat = System.Drawing.Imaging.ImageFormat.Emf;

    //احفظ دفتر العمل إلى التدفق
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

يتيح لك Aspose.Slides استبدال الصور المخزنة في مجموعة صور العرض التقديمي (بما في ذلك المستخدمة في أشكال الشرائح). يوضح هذا القسم عدة طرق لتحديث الصور في المجموعة. توفر واجهة برمجة التطبيقات طرقًا بسيطة لاستبدال صورة باستخدام بيانات بايت خام، أو كائن [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/)، أو صورة أخرى موجودة بالفعل في المجموعة. 

اتبع الخطوات التالية:

1. تحميل ملف العرض التقديمي الذي يحتوي على الصور باستخدام فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. تحميل صورة جديدة من ملف إلى مصفوفة بايت.
3. استبدال الصورة المستهدفة بالصورة الجديدة باستخدام مصفوفة البايت.
4. في النهج الثاني، حمّل الصورة إلى كائن [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) واستبدل الصورة المستهدفة بذلك الكائن.
5. في النهج الثالث، استبدل الصورة المستهدفة بصورة موجودة بالفعل في مجموعة صور العرض التقديمي.
6. احفظ العرض التقديمي المعدل كملف PPTX.
```cs
// إنشاء مثيل للفئة Presentation التي تمثل ملف عرض تقديمي.
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

// حفظ العرض التقديمي في ملف.
presentation.Save("output.pptx", SaveFormat.Pptx);
```


{{% alert title="معلومات" color="info" %}}
باستخدام محول Aspose FREE [Text to GIF](https://products.aspose.app/slides/text-to-gif) converter، يمكنك بسهولة تحريك النصوص، إنشاء GIFs من النصوص، وما إلى ذلك. 
{{% /alert %}}

## **الأسئلة المتكررة**

**هل يبقى دقة الصورة الأصلية دون تغيير بعد الإدراج؟**

نعم. يتم الحفاظ على بكسلات المصدر، لكن المظهر النهائي يعتمد على كيفية تحجيم [الصورة](/slides/ar/net/picture-frame/) على الشريحة وأي ضغط يتم تطبيقه عند الحفظ.

**ما هي أفضل طريقة لاستبدال الشعار نفسه عبر العشرات من الشرائح دفعة واحدة؟**

ضع الشعار على الشريحة الرئيسية أو على تخطيط، واستبدله في مجموعة صور العرض التقديمي—ستنتقل التحديثات إلى جميع العناصر التي تستخدم هذا المورد.

**هل يمكن تحويل SVG المدخل إلى أشكال قابلة للتحرير؟**

نعم. يمكنك تحويل SVG إلى مجموعة من الأشكال، ثم تصبح الأجزاء الفردية قابلة للتحرير باستخدام خصائص الشكل القياسية.

**كيف يمكنني ضبط صورة كخلفية لعدة شرائح في آن واحد؟**

[عيّن الصورة كخلفية](/slides/ar/net/presentation-background/) على الشريحة الرئيسية أو التخطيط المناسب—ستورث أي شرائح تستخدم ذلك القالب الخلفية.

**كيف يمكنني منع حجم العرض التقديمي من الارتفاع بشكل كبير بسبب كثرة الصور؟**

أعد استخدام مورد صورة واحد بدلاً من التكرارات، اختر دقات معقولة، طبق ضغطًا عند الحفظ، واحفظ الرسومات المتكررة على القالب الرئيسي عند الحاجة.