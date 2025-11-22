---
title: صورة
type: docs
weight: 10
url: /ar/net/image/
keywords:
- إضافة صورة
- إضافة صورة
- إضافة بت ماب
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
description: "تبسيط إدارة الصور في PowerPoint و OpenDocument باستخدام Aspose.Slides لـ .NET، تحسين الأداء وأتمتة سير العمل الخاص بك."
---

## **الصور في الشرائح في العروض التقديمية**

تجعل الصور العروض التقديمية أكثر جاذبية وإثارة للاهتمام. في Microsoft PowerPoint، يمكنك إدراج صور من ملف أو الإنترنت أو مواقع أخرى على الشرائح. وبالمثل، يتيح لك Aspose.Slides إضافة صور إلى الشرائح في عروضك التقديمية من خلال طرق مختلفة.

{{% alert  title="نصيحة" color="primary" %}} 
توفر Aspose محولات مجانية —[JPEG إلى PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) و[PNG إلى PowerPoint](https://products.aspose.app/slides/import/png-to-ppt) — التي تمكن الأشخاص من إنشاء عروض تقديمية بسرعة من الصور. 
{{% /alert %}} 

{{% alert title="معلومات" color="info" %}}
إذا كنت تريد إضافة صورة ككائن إطار — خاصةً إذا كنت تخطط لاستخدام خيارات تنسيق قياسية لتغيير حجمها، إضافة تأثيرات، وما إلى ذلك — راجع [إطار الصورة](https://docs.aspose.com/slides/net/picture-frame/). 
{{% /alert %}} 

{{% alert title="ملاحظة" color="warning" %}}
يمكنك معالجة عمليات الإدخال/الإخراج المتعلقة بالصور وعروض PowerPoint لتحويل صورة من تنسيق إلى آخر. راجع هذه الصفحات: تحويل [صورة إلى JPG](https://products.aspose.com/slides/net/conversion/image-to-jpg/); تحويل [JPG إلى صورة](https://products.aspose.com/slides/net/conversion/jpg-to-image/); تحويل [JPG إلى PNG](https://products.aspose.com/slides/net/conversion/jpg-to-png/), تحويل [PNG إلى JPG](https://products.aspose.com/slides/net/conversion/png-to-jpg/); تحويل [PNG إلى SVG](https://products.aspose.com/slides/net/conversion/png-to-svg/), تحويل [SVG إلى PNG](https://products.aspose.com/slides/net/conversion/svg-to-png/).
{{% /alert %}}

يدعم Aspose.Slides العمليات مع الصور بهذه الصيغ الشائعة: JPEG, PNG, BMP, GIF، وغيرها. 

## **إضافة صور مخزنة محليًا إلى الشرائح**

يمكنك إضافة صورة واحدة أو عدة صور من جهازك إلى شريحة في عرض تقديمي. يوضح لك هذا المثال البرمجي في C# كيفية إضافة صورة إلى شريحة:
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

إذا كانت الصورة التي تريد إضافتها إلى شريحة غير متوفرة على جهازك، يمكنك إضافة الصورة مباشرةً من الويب. 

هذا المثال البرمجي يوضح كيفية إضافة صورة من الويب إلى شريحة في C#:
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


## **إضافة صور إلى القالب الرئيسي للشرائح**

القالب الرئيسي للشرائح هو الشريحة العليا التي تخزن وتتحكم في المعلومات (السمة، التخطيط، إلخ) الخاصة بجميع الشرائح تحته. لذا، عندما تضيف صورة إلى القالب الرئيسي، تظهر تلك الصورة على كل شريحة تحت ذلك القالب. 

هذا المثال البرمجي في C# يوضح كيفية إضافة صورة إلى القالب الرئيسي:
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


## **إضافة صور كخلفية للشرائح**

قد تقرر استخدام صورة كخلفية لشريحة محددة أو عدة شرائح. في هذه الحالة، يجب عليك الاطلاع على *[تعيين الصور كخلفيات للشرائح](https://docs.aspose.com/slides/net/presentation-background/#setting-images-as-background-for-slides)*.

## **إضافة SVG إلى العروض التقديمية**

يمكنك إضافة أو إدراج أي صورة في عرض تقديمي باستخدام طريقة [AddPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/methods/addpictureframe) التي تنتمي إلى واجهة [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection). 

لإنشاء كائن صورة بناءً على صورة SVG، يمكنك القيام بذلك بهذه الطريقة:

1. إنشاء كائن SvgImage لإدراجه في ImageShapeCollection
2. إنشاء كائن PPImage من ISvgImage
3. إنشاء كائن PictureFrame باستخدام واجهة IPPImage

هذا المثال البرمجي يوضح كيفية تنفيذ الخطوات أعلاه لإضافة صورة SVG إلى عرض تقديمي:
```csharp
// مسار دليل المستندات
string dataDir = @"D:\Documents\";

// اسم ملف SVG المصدر
string svgFileName = dataDir + "sample.svg";

// اسم ملف العرض الناتج
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

    // حفظ العرض بتنسيق PPTX
    p.Save(outPptxPath, SaveFormat.Pptx);
}
```


## **تحويل SVG إلى مجموعة من الأشكال**

تحويل Aspose.Slides لـ SVG إلى مجموعة من الأشكال مشابه لوظيفة PowerPoint المستخدمة للعمل مع صور SVG:

![قائمة PowerPoint المنبثقة](img_01_01.png)

توفر هذه الوظيفة أحد التحميلات المزدوجة (overloads) لطريقة [AddGroupShape](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/addgroupshape/methods/1) في واجهة [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection) التي تستقبل كائن [ISvgImage](https://reference.aspose.com/slides/net/aspose.slides/isvgimage) كأول معامل.

هذا المثال البرمجي يوضح كيفية استخدام الطريقة الموصوفة لتحويل ملف SVG إلى مجموعة من الأشكال:
``` csharp 
// مسار دليل المستندات
string dataDir = @"D:\Documents\";

// اسم ملف SVG المصدر
string svgFileName = dataDir + "sample.svg";

// اسم ملف العرض الناتج
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

    // تحويل صورة SVG إلى مجموعة أشكال وتوسيعها لتناسب حجم الشريحة
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // حفظ العرض بتنسيق PPTX
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```


## **إضافة صور كـ EMF في الشرائح**

يسمح Aspose.Slides للـ .NET بإنشاء صور EMF من أوراق Excel وإضافة الصور كـ EMF في الشرائح باستخدام Aspose.Cells. 

هذا المثال البرمجي يوضح كيفية تنفيذ المهمة الموصوفة:
``` csharp 
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

Aspose.Slides يتيح لك استبدال الصور المخزنة في مجموعة الصور الخاصة بالعرض (بما في ذلك تلك المستخدمة في أشكال الشرائح). يعرض هذا القسم عدة نهج لتحديث الصور في المجموعة. توفر API طرقًا بسيطة لاستبدال صورة باستخدام بيانات بايت خام، أو كائن [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/)، أو صورة أخرى موجودة بالفعل في المجموعة.

اتبع الخطوات التالية:
1. تحميل ملف العرض الذي يحتوي على الصور باستخدام الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. تحميل صورة جديدة من ملف إلى مصفوفة بايت.
3. استبدال الصورة المستهدفة بالصورة الجديدة باستخدام مصفوفة البايت.
4. في النهج الثاني، تحميل الصورة إلى كائن [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) واستبدال الصورة المستهدفة بذلك الكائن.
5. في النهج الثالث، استبدال الصورة المستهدفة بصورة موجودة بالفعل في مجموعة صور العرض.
6. كتابة العرض المعدل كملف PPTX.
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


{{% alert title="معلومات" color="info" %}}
باستخدام محول Aspose FREE [Text to GIF](https://products.aspose.app/slides/text-to-gif) يمكنك بسهولة تحريك النصوص، إنشاء GIFs من النصوص، وما إلى ذلك. 
{{% /alert %}}

## **أسئلة شائعة**

**هل يبقى دقة الصورة الأصلية محفوظة بعد الإدراج؟**

نعم. يتم الحفاظ على بكسلات المصدر، لكن المظهر النهائي يعتمد على كيفية تحجيم [الصورة](/slides/ar/net/picture-frame/) في الشريحة وأي ضغط يتم تطبيقه عند الحفظ.

**ما هي أفضل طريقة لاستبدال الشعار نفسه عبر عشرات الشرائح دفعة واحدة؟**

ضع الشعار على الشريحة الرئيسية أو على تخطيط واستبدله في مجموعة صور العرض — ستنتقل التحديثات إلى جميع العناصر التي تستخدم هذا المورد.

**هل يمكن تحويل SVG المضمن إلى أشكال قابلة للتعديل؟**

نعم. يمكنك تحويل SVG إلى مجموعة من الأشكال، وبعد ذلك تصبح الأجزاء الفردية قابلة للتحرير باستخدام خصائص الشكل القياسية.

**كيف يمكنني تعيين صورة كخلفية لعدة شرائح في آن واحد؟**

[تعيين الصورة كخلفية](/slides/ar/net/presentation-background/) على الشريحة الرئيسية أو التخطيط المناسب — أي شريحة تستخدم ذلك القالب/التخطيط ستورث الخلفية.

**كيف يمكنني منع تضخم حجم العرض بسبب كثرة الصور؟**

أعد استخدام مصدر صورة واحد بدلاً من التكرارات، اختر دقات معقولة، طبق الضغط عند الحفظ، واحتفظ بالرسومات المتكررة على القالب الرئيسي حيثما كان ذلك مناسبًا.