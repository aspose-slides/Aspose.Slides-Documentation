---
title: صورة
type: docs
weight: 10
url: /ar/net/image/
keywords: "إضافة صورة, إضافة صورة, عرض PowerPoint, EMF, SVG, C#, Csharp, Aspose.Slides لـ .NET"
description: "إضافة صورة إلى شريحة PowerPoint أو عرض تقديمي في C# أو .NET"
---

## **الصور في الشرائح في العروض التقديمية**

الصور تجعل العروض التقديمية أكثر جاذبية واهتمامًا. في Microsoft PowerPoint، يمكنك إدراج صور من ملف أو من الإنترنت أو من مواقع أخرى على الشرائح. بالمثل، يتيح لك Aspose.Slides إضافة الصور إلى الشرائح في عروضك التقديمية من خلال إجراءات مختلفة.

{{% alert  title="نصيحة" color="primary" %}} 

تقدم Aspose محولات مجانية—[JPEG إلى PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) و [PNG إلى PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—تتيح للناس إنشاء عروض تقديمية بسرعة من الصور. 

{{% /alert %}} 

{{% alert title="معلومات" color="info" %}}

إذا كنت ترغب في إضافة صورة ككائن إطار—خصوصًا إذا كنت تخطط لاستخدام خيارات التنسيق القياسية عليها لتغيير حجمها، وإضافة تأثيرات، وما إلى ذلك—انظر إلى [إطار الصورة](https://docs.aspose.com/slides/net/picture-frame/). 

{{% /alert %}} 

{{% alert title="ملحوظة" color="warning" %}}

يمكنك التعامل مع عمليات الإدخال/الإخراج المتعلقة بالصور وعروض PowerPoint لتحويل صورة من تنسيق إلى آخر. انظر هذه الصفحات: تحويل [صورة إلى JPG](https://products.aspose.com/slides/net/conversion/image-to-jpg/); تحويل [JPG إلى صورة](https://products.aspose.com/slides/net/conversion/jpg-to-image/); تحويل [JPG إلى PNG](https://products.aspose.com/slides/net/conversion/jpg-to-png/)، تحويل [PNG إلى JPG](https://products.aspose.com/slides/net/conversion/png-to-jpg/); تحويل [PNG إلى SVG](https://products.aspose.com/slides/net/conversion/png-to-svg/)، تحويل [SVG إلى PNG](https://products.aspose.com/slides/net/conversion/svg-to-png/).

{{% /alert %}}

يدعم Aspose.Slides عمليات مع الصور في هذه الصيغ الشائعة: JPEG، PNG، BMP، GIF، وغيرها. 

## **إضافة صور مخزنة محليًا إلى الشرائح**

يمكنك إضافة صورة واحدة أو عدة صور من الكمبيوتر إلى شريحة في عرض تقديمي. يعرض لك هذا الرمز التجريبي في C# كيفية إضافة صورة إلى شريحة:

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

إذا كانت الصورة التي تريد إضافتها إلى شريحة غير متاحة على جهاز الكمبيوتر الخاص بك، يمكنك إضافة الصورة مباشرة من الويب. 

يعرض لك هذا الرمز التجريبي كيفية إضافة صورة من الويب إلى شريحة في C#:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] imageData;
    using (WebClient webClient = new WebClient()) 
    {
        imageData = webClient.DownloadData(new Uri("[استبدل بالرابط]"));
    }
    
    IPPImage image = pres.Images.AddImage(imageData);
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **إضافة صور إلى شريحة الرئيسية**

الشريحة الرئيسية هي الشريحة العلوية التي تخزن وتتحكم في المعلومات (الموضوع، التخطيط، إلخ) حول جميع الشرائح تحتها. لذلك، عند إضافة صورة إلى شريحة رئيسية، ستظهر تلك الصورة على كل شريحة تحت تلك الشريحة الرئيسية. 

يعرض لك هذا الرمز التجريبي في C# كيفية إضافة صورة إلى شريحة رئيسية:

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

يمكن أن تقرر استخدام صورة كخلفية لشريحة معينة أو عدة شرائح. في هذه الحالة، عليك الاطلاع على *[تعيين الصور كخلفيات للشرائح](https://docs.aspose.com/slides/net/presentation-background/#setting-images-as-background-for-slides)*.

## **إضافة SVG إلى العروض التقديمية**
يمكنك إضافة أو إدراج أي صورة إلى عرض تقديمي باستخدام طريقة [AddPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/methods/addpictureframe) التي تنتمي إلى واجهة [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection).

لإنشاء كائن صورة بناءً على صورة SVG، يمكنك القيام بذلك بهذه الطريقة:

1. إنشاء كائن SvgImage لإدراجه في ImageShapeCollection
2. إنشاء كائن PPImage من ISvgImage
3. إنشاء كائن PictureFrame باستخدام واجهة IPPImage

يعرض لك هذا الرمز التجريبي كيف يمكنك تنفيذ الخطوات أعلاه لإضافة صورة SVG إلى عرض تقديمي:
``` csharp 
// المسار إلى دليل الوثائق
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

    // حفظ العرض التقديمي بتنسيق PPTX
    p.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **تحويل SVG إلى مجموعة من الأشكال**
إن تحويل Aspose.Slides من SVG إلى مجموعة من الأشكال مشابه لوظيفة PowerPoint المستخدمة للعمل مع صور SVG:


![قائمة منبثقة في PowerPoint](img_01_01.png)

تقدم الوظيفة بواسطة أحد الأعباء الزائدة من طريقة [AddGroupShape](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/addgroupshape/methods/1) الخاصة بواجهة [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection) والتي تأخذ كائن [ISvgImage](https://reference.aspose.com/slides/net/aspose.slides/isvgimage) كأول معطى.

يعرض لك هذا الرمز التجريبي كيف يمكنك استخدام الطريقة الموصوفة لتحويل ملف SVG إلى مجموعة من الأشكال:

``` csharp 
// المسار إلى دليل الوثائق
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

    // تحويل صورة SVG إلى مجموعة من الأشكال مع تغيير مقاسها إلى حجم الشريحة
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // حفظ العرض التقديمي بتنسيق PPTX
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **إضافة صور كـ EMF إلى الشرائح**
يسمح لك Aspose.Slides لـ .NET بإنشاء صور EMF من أوراق Excel وإضافة الصور كـ EMF إلى الشرائح باستخدام Aspose.Cells. 

يعرض لك هذا الرمز التجريبي كيف يمكنك تنفيذ المهمة الموصوفة:

``` csharp 
using (Workbook book = new Workbook(dataDir + "chart.xlsx"))
{
    Worksheet sheet = book.Worksheets[0];
    ImageOrPrintOptions options = new ImageOrPrintOptions();
    options.HorizontalResolution = 200;
    options.VerticalResolution = 200;
    options.ImageFormat = System.Drawing.Imaging.ImageFormat.Emf;

    // حفظ دفتر العمل إلى تدفق
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

{{% alert title="معلومات" color="info" %}}

باستخدام محول Aspose المجاني [نص إلى GIF](https://products.aspose.app/slides/text-to-gif)، يمكنك بسهولة تحريك النصوص، وإنشاء GIFs من النصوص، إلخ. 

{{% /alert %}}