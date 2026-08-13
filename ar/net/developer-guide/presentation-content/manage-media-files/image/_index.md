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
- موارد SVG الخارجية
- محلّل SVG
- صور SVG المرتبطة
- خطوط SVG
- إضافة EMF
- إضافة WMF
- إضافة TIFF
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تبسيط إدارة الصور في PowerPoint و OpenDocument باستخدام Aspose.Slides لـ .NET، مع تحسين الأداء وأتمتة سير العمل."
---
## **المقدمة**

تجعل الصور العروض التقديمية أكثر جاذبية وجمالاً بصرياً. في Microsoft PowerPoint، يمكنك إدراج الصور على الشرائح من الملفات أو الإنترنت أو مصادر أخرى. بنفس الطريقة، يتيح لك Aspose.Slides إضافة صور إلى شرائح العرض التقديمي بطرق متعددة.

{{% alert title="نصيحة" color="info" %}} 

توفر Aspose محولات مجانية—[JPEG to PowerPoint](https://products.aspose.app/slides/ar/import/jpg-to-ppt) و[PNG to PowerPoint](https://products.aspose.app/slides/ar/import/png-to-ppt)—تسمح لك بإنشاء عروض تقديمية بسرعة من الصور. 

{{% /alert %}} 

{{% alert title="معلومات" color="info" %}}

إذا كنت ترغب في إضافة صورة كإطار صورة—خاصة إذا كنت تخطط لتغيير حجمها أو تطبيق تأثيرات أو استخدام خيارات تنسيق قياسية أخرى—اطلع على [Picture Frame](/slides/ar/net/picture-frame/). 

{{% /alert %}} 

{{% alert title="ملاحظة" color="warning" %}}

يمكنك تحويل الصور من تنسيق إلى آخر. راجع الصفحات التالية: تحويل [image to JPG](https://products.aspose.com/slides/ar/net/conversion/image-to-jpg/)، [JPG to image](https://products.aspose.com/slides/ar/net/conversion/jpg-to-image/)، [JPG to PNG](https://products.aspose.com/slides/ar/net/conversion/jpg-to-png/)، [PNG to JPG](https://products.aspose.com/slides/ar/net/conversion/png-to-jpg/)، [PNG to SVG](https://products.aspose.com/slides/ar/net/conversion/png-to-svg/)، و[SVG to PNG](https://products.aspose.com/slides/ar/net/conversion/svg-to-png/).

{{% /alert %}}

يدعم Aspose.Slides الصور بالتنسيقات الشائعة مثل JPEG وPNG وBMP وGIF وغيرها. 

## **إضافة صور مخزنة محليًا إلى الشرائح**

يمكنك إضافة صورة أو أكثر مخزنة على جهازك إلى شريحة عرض تقديمي. يوضح الكود النموذجي التالي بلغة C# كيفية إضافة صورة إلى شريحة:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **إضافة صور من الويب إلى الشرائح**

إذا لم تكن الصورة التي تريد إضافتها مخزنة على جهازك، يمكنك إضافتها مباشرة من الويب. 

الكود النموذجي التالي بلغة C# يوضح كيفية إضافة صورة من الويب إلى شريحة:

```c#
using System.Net;
using Aspose.Slides;
using Aspose.Slides.Export;

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

القالب الرئيسي للشرائح يخزن ويتحكم بالمعلومات مثل السمة وتخطيط الشرائح التي تستخدمه. عندما تضيف صورة إلى القالب الرئيسي، تظهر الصورة على كل شريحة تعتمد على ذلك القالب. 

الكود النموذجي التالي بلغة C# يوضح كيفية إضافة صورة إلى القالب الرئيسي للشرائح:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

يمكنك استخدام صورة كخلفية لشرائح واحدة أو أكثر. للتفاصيل، راجع *[Setting Images as Backgrounds for Slides](/slides/ar/net/presentation-background/#setting-images-as-background-for-slides)*.

## **إضافة SVG إلى العروض التقديمية**

يمكن إضافة محتوى SVG إلى عرض تقديمي باستخدام الفئة [SvgImage](https://reference.aspose.com/slides/ar/net/aspose.slides/svgimage/). يمكن بعد ذلك إضافة كائن [ISvgImage](https://reference.aspose.com/slides/ar/net/aspose.slides/isvgimage/) الناتج إلى مجموعة صور العرض التقديمي واستخدامه لإنشاء إطار صورة.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

string svgContent = @"
<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>
    <rect width='320' height='180' fill='#4F81BD'/>
    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>
</svg>";

using (Presentation presentation = new Presentation())
{
    ISvgImage svgImage = new SvgImage(svgContent);
    IPPImage image = presentation.Images.AddImage(svgImage);

    presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 20, 20, image.Width, image.Height, image);

    presentation.Save("self-contained-svg.pptx", SaveFormat.Pptx);
}
```

## **استيراد محتوى SVG مع موارد خارجية**

قد تحتوي ملفات SVG المصدرة من أدوات التصميم أو محررات المخططات أو أنظمة الأيقونات أو خطوط الأنابيب الويب على مراجع لموارد مخزنة خارج مستند SVG. على سبيل المثال، يمكن أن يحتوي SVG على رابط صورة مثل `images/photo.png`، أو قيمة CSS `url(...)`، أو عنوان URL لخط.

لاستيراد مثل هذا المحتوى، أنشئ تنفيذًا لـ[IExternalResourceResolver](https://reference.aspose.com/slides/ar/net/aspose.slides.import/iexternalresourceresolver/) ومرره مع URI أساسي إلى منشئ `SvgImage` المناسب. يحدد URI الأساسي موقع مستند SVG ويُستخدم لحل الروابط النسبية.

توفر واجهة [ISvgImage](https://reference.aspose.com/slides/ar/net/aspose.slides/isvgimage/) الوصول إلى معلومات حول SVG المستورد:

- `SvgContent` تُعيد ترميز SVG كسلسلة نصية.
- `SvgData` تُعيد محتوى SVG كمصفوفة بايت.
- `BaseUri` تُعيد الـ URI الأساسي المستخدم للروابط النسبية.
- `ExternalResourceResolver` تُعيد المُحَلِّل المُعيّن لصورة SVG.

### **تنفيذ محلل موارد خارجي**

يحتوي المحلل على طريقتين:

- [ResolveUri](https://reference.aspose.com/slides/ar/net/aspose.slides.import/iexternalresourceresolver/resolveuri/) يجمع الـ URI الأساسي ورابط المورد النسبي ويُعيد URI مطلق. إرجع `null` عندما لا يمكن حل الرابط أو يكون غير مسموح به.
- [GetEntity](https://reference.aspose.com/slides/ar/net/aspose.slides.import/iexternalresourceresolver/getentity/) يُعيد تدفقًا قابلًا للقراءة لِـ URI المورد المطلق. إرجع `null` عندما يكون المورد مفقودًا أو محجوبًا أو غير متاح. يمكن أيضًا إرجاع تدفق احتياطي عندما يكون ذلك مناسبًا.

المحلل التالي يحمل الموارد المرتبطة فقط من دليل محلي مسموح به. تُحجب الموارد الشبكية والمسارات خارج الدليل المسموح. يتم إرجاع صورة احتياطية اختيارية للروابط غير المحلولة.

```csharp
using System;
using System.IO;
using Aspose.Slides.Import;

internal sealed class LocalSvgResourceResolver : IExternalResourceResolver
{
    private readonly string _allowedRoot;
    private readonly byte[] _fallbackImageData;

    public LocalSvgResourceResolver(string allowedRoot, byte[] fallbackImageData = null)
    {
        _allowedRoot = Path.GetFullPath(allowedRoot);
        _fallbackImageData = fallbackImageData;
    }

    public string ResolveUri(string baseUri, string relativeUri)
    {
        if (string.IsNullOrWhiteSpace(baseUri) ||
            string.IsNullOrWhiteSpace(relativeUri))
        {
            return null;
        }

        if (!Uri.TryCreate(baseUri, UriKind.Absolute, out Uri baseAddress) ||
            !Uri.TryCreate(baseAddress, relativeUri, out Uri absoluteAddress))
        {
            return null;
        }

        // هذا المحلل يسمح بملفات محلية فقط عن قصد.
        if (!absoluteAddress.IsFile)
        {
            return null;
        }

        string resourcePath = Path.GetFullPath(absoluteAddress.LocalPath);
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return null;
        }

        return absoluteAddress.AbsoluteUri;
    }

    public Stream GetEntity(string absoluteUri)
    {
        if (!Uri.TryCreate(absoluteUri, UriKind.Absolute, out Uri resourceUri) ||
            !resourceUri.IsFile)
        {
            return null;
        }

        string resourcePath = Path.GetFullPath(resourceUri.LocalPath);
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return null;
        }

        if (File.Exists(resourcePath))
        {
            return File.OpenRead(resourcePath);
        }

        // استخدم بديلًا فقط لموارد الصور. إرجاع تدفق صورة
        // لموارد الخط أو ورقة النمط المفقودة لن يكون ذلك صالحًا.
        if (_fallbackImageData != null && IsImageFile(resourcePath))
        {
            return new MemoryStream(_fallbackImageData, writable: false);
        }

        return null;
    }

    private bool IsInsideAllowedRoot(string resourcePath)
    {
        string normalizedRoot = _allowedRoot.TrimEnd(
            Path.DirectorySeparatorChar,
            Path.AltDirectorySeparatorChar) + Path.DirectorySeparatorChar;

        string normalizedPath = Path.GetFullPath(resourcePath);
        StringComparison comparison = Path.DirectorySeparatorChar == '\\'
            ? StringComparison.OrdinalIgnoreCase
            : StringComparison.Ordinal;

        return normalizedPath.StartsWith(normalizedRoot, comparison) ||
               string.Equals(normalizedPath, _allowedRoot, comparison);
    }

    private static bool IsImageFile(string path)
    {
        string extension = Path.GetExtension(path);

        return extension.Equals(".png", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".jpg", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".jpeg", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".gif", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".bmp", StringComparison.OrdinalIgnoreCase);
    }
}
```

### **حل الموارد المرتبطة أثناء استيراد SVG**

افترض أن `assets/diagram.svg` يحتوي على إشارة نسبية مثل:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

الكود التالي بلغة C# يمرر URI ملف SVG كـ URI أساسي ويوفر محللًا مخصصًا. يُحوّل المحلّل رابط الصورة النسبي إلى URI مطلق ويُعيد تدفقًا يحتوي على المورد المرتبط بينما يعالج Aspose.Slides الـ SVG.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Import;

string svgFilePath = Path.GetFullPath(Path.Combine("assets", "diagram.svg"));
string assetDirectory = Path.GetDirectoryName(svgFilePath) ?? Directory.GetCurrentDirectory();
string svgContent = File.ReadAllText(svgFilePath);

// يمثل URI الأساسي موقع مستند SVG.
string baseUri = new Uri(svgFilePath).AbsoluteUri;

byte[] fallbackImageData = null;
string fallbackImagePath = Path.Combine(assetDirectory, "fallback.png");
if (File.Exists(fallbackImagePath))
{
    fallbackImageData = File.ReadAllBytes(fallbackImagePath);
}

IExternalResourceResolver resolver = new LocalSvgResourceResolver(assetDirectory, fallbackImageData);
ISvgImage svgImage = new SvgImage(svgContent, resolver, baseUri);

// ISvgImage exposes the source content, binary data, base URI, and resolver.
string importedContent = svgImage.SvgContent;
byte[] importedData = svgImage.SvgData;
string importedBaseUri = svgImage.BaseUri;
IExternalResourceResolver importedResolver = svgImage.ExternalResourceResolver;

using (Presentation presentation = new Presentation())
{
    IPPImage image = presentation.Images.AddImage(svgImage);

    presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 20, 20, image.Width, image.Height, image);

    presentation.Save("svg-with-linked-resources.pptx", SaveFormat.Pptx);
}
```

توفر فئة `SvgImage` أيضًا تحميلات زائدة تقبل بيانات SVG كمصفوفة بايت أو تدفق، إلى جانب محلل موارد خارجي وURI أساسي.

{{% alert title="مهم" color="warning" %}}

يجعل محلل الموارد الموارد الخارجية متاحة أثناء معالجة Aspose.Slides ورسم الـ SVG. لا يغيّر ترميز SVG الأصلي ولا يدمج الموارد المُحلَّلة تلقائيًا فيه.

عند إضافة `ISvgImage` إلى مجموعة صور العرض التقديمي، قد يحتوي ملف PPTX على كلٍ من تمثيل SVG الأصلي وصورة نقطية احتياطية. يمكن أن يظهر المورد المرتبط في الصورة الاحتياطية بينما يظل الرابط النسبي مثل `images/photo.png` غير متغير في SVG المخزن. قد يتجاهل التطبيق الذي يرسم تمثيل SVG الأصلي المحتوى المرتبط عندما يكون المورد الخارجي الأصلي غير متاح.

{{% /alert %}}

### **إنشاء صورة SVG محمولة**

لإنشاء صورة SVG لا تعتمد على ملفات خارجية، اجعل SVG ذاتيًا قبل إنشاء `SvgImage`. على سبيل المثال، استبدل عناوين URL للصور المرتبطة بـ URIs من النوع `data:` تحتوي على بيانات الصورة:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

بعد تضمين جميع الموارد المطلوبة في محتوى SVG، أنشئ `SvgImage`، أضفه إلى مجموعة صور العرض التقديمي، وأدرجه في إطار صورة كما هو موضح في المثال السابق.

### **معالجة الموارد المفقودة أو المحجوبة**

إرجع `null` من `ResolveUri` عندما يكون URI المورد غير صالح أو ممنوع أو لا يمكن حله. إرجع `null` من `GetEntity` عندما لا يمكن قراءة المورد. يواصل Aspose.Slides معالجة الـ SVG بدون ذلك المورد عندما يكون ذلك ممكنًا.

يمكن إرجاع تدفق احتياطي لمورد مفقود، لكن يجب أن يكون محتواه متوافقًا مع نوع المورد المطلوب. على سبيل المثال، إرجاع تدفق صورة فقط لمورد صورة مفقود، وليس لخط أو ورقة نمط.

{{% alert title="أمان" color="warning" %}}

لا تقم بحل مسارات ملفات عشوائية أو عناوين URL شبكية غير مقيدة من ملفات SVG غير موثوقة. قيد الأنماط، الأدلة، والمضيفين المسموح بها. بالنسبة للموارد الشبكية، طبّق أيضًا مهلات الاتصال، حدود حجم الاستجابة، والتحقق من المحتوى.

{{% /alert %}}

## **تحويل SVG إلى مجموعة من الأشكال**
يمكن لـ Aspose.Slides تحويل SVG إلى مجموعة من الأشكال، مشابهًا للوظيفة المقابلة في PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

توفر هذه الوظيفة من خلال تحميل زائد لطريقة [AddGroupShape](https://reference.aspose.com/slides/ar/net/aspose.slides.ishapecollection/addgroupshape/methods/1) في واجهة [IShapeCollection](https://reference.aspose.com/slides/ar/net/aspose.slides/ishapecollection) التي تأخذ كائن [ISvgImage](https://reference.aspose.com/slides/ar/net/aspose.slides/isvgimage) كوسيط أول.

الكود التالي بلغة C# يوضح كيفية استخدام هذه الطريقة لتحويل ملف SVG إلى مجموعة من الأشكال:

``` csharp 
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// اسم ملف SVG المصدر
string svgFileName = "sample.svg";

// اسم ملف العرض التقديمي الناتج
string outPptxPath = "presentation.pptx";

// إنشاء عرض تقديمي جديد
using (IPresentation presentation = new Presentation())
{
    // قراءة محتوى ملف SVG
    string svgContent = File.ReadAllText(svgFileName);

    // إنشاء كائن SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // الحصول على حجم الشريحة
    SizeF slideSize = presentation.SlideSize.Size;

    // تحويل صورة SVG إلى مجموعة من الأشكال وتحجيمها لتناسب حجم الشريحة
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // حفظ العرض التقديمي بصيغة PPTX
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **إضافة صور كـ EMF إلى الشرائح**
يسمح Aspose.Slides for .NET لك بإنشاء صور EMF من أوراق عمل Excel باستخدام Aspose.Cells وإضافتها إلى شرائح العرض التقديمي.

الكود التالي بلغة C# يوضح كيفية القيام بذلك:

``` csharp 
using Aspose.Slides;
using Aspose.Cells;
using Aspose.Cells.Rendering;


using (Workbook book = new Workbook("chart.xlsx"))
{
    Worksheet sheet = book.Worksheets[0];
    ImageOrPrintOptions options = new ImageOrPrintOptions();
    options.HorizontalResolution = 200;
    options.VerticalResolution = 200;
    options.ImageType = Aspose.Cells.Drawing.ImageType.Emf;

    // حفظ دفتر العمل إلى تدفق
    SheetRender sr = new SheetRender(sheet, options);
    using (Presentation pres = new Presentation())
    {
        pres.Slides.RemoveAt(0);

        String EmfSheetName = "";
        for (int j = 0; j < sr.PageCount; j++)
        {
            EmfSheetName = "test" + sheet.Name + " Page" + (j + 1) + ".out.emf";
            sr.ToImage(j, EmfSheetName);

            var bytes = File.ReadAllBytes(EmfSheetName);
            var emfImage = pres.Images.AddImage(bytes);
            ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides.GetByType(SlideLayoutType.Blank));
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, pres.SlideSize.Size.Width, pres.SlideSize.Size.Height, emfImage);
        }

        pres.Save("Saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
```

## **استبدال الصور في مجموعة الصور**

يتيح لك Aspose.Slides استبدال الصور المخزنة في مجموعة صور العرض التقديمي، بما في ذلك الصور المستخدمة في أشكال الشرائح. يصف هذا القسم عدة طرق لتحديث الصور في المجموعة. يمكنك استبدال صورة باستخدام بيانات بايت خام، أو كائن [IImage](https://reference.aspose.com/slides/ar/net/aspose.slides/iimage/) ، أو صورة أخرى موجودة بالفعل في المجموعة.

اتبع الخطوات أدناه:

1. حمّل ملف العرض التقديمي الذي يحتوي على الصور باستخدام فئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/).
1. حمّل صورة جديدة من ملف إلى مصفوفة بايت.
1. استبدل الصورة المستهدفة بالصورة الجديدة باستخدام مصفوفة البايت.
1. في النهج الثاني، حمّل الصورة إلى كائن [IImage](https://reference.aspose.com/slides/ar/net/aspose.slides/iimage/) واستبدل الصورة المستهدفة بذلك الكائن.
1. في النهج الثالث، استبدل الصورة المستهدفة بصورة موجودة بالفعل في مجموعة صور العرض التقديمي.
1. احفظ العرض التقديمي المعدل كملف PPTX.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// إنشاء كائن Presentation الذي يمثل ملف عرض تقديمي.
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

باستخدام محول Aspose المجاني [Text to GIF](https://products.aspose.app/slides/ar/text-to-gif) يمكنك تحريك النص بسهولة وإنشاء ملفات GIF من النص. 

{{% /alert %}}

## **الأسئلة الشائعة**

**هل تبقى دقة الصورة الأصلية محفوظة بعد الإدراج؟**

نعم. يتم الاحتفاظ ببكسلات المصدر، لكن المظهر النهائي يعتمد على كيفية تحجيم [picture](/slides/ar/net/picture-frame/) على الشريحة وأي ضغط يُطبق عند الحفظ.

**ما هي أفضل طريقة لاستبدال الشعار نفسه عبر العشرات من الشرائح مرة واحدة؟**

ضع الشعار على الشريحة الرئيسية أو التخطيط واستبدله في مجموعة صور العرض التقديمي—ستنتقل التحديثات إلى جميع العناصر التي تستخدم هذا المورد.

**هل يمكن تحويل SVG مدخلة إلى أشكال قابلة للتحرير؟**

نعم. يمكنك تحويل SVG إلى مجموعة من الأشكال، وبعد ذلك تصبح الأجزاء الفردية قابلة للتحرير باستخدام خصائص الشكل القياسية.

**كيف يمكنني تعيين صورة كخلفية لعدة شرائح في آن واحد؟**

[Assign the image as the background](/slides/ar/net/presentation-background/) على الشريحة الرئيسية أو التخطيط المناسب—ستورّث جميع الشرائح التي تستخدم ذلك القالب/التخطيط الخلفية.

**كيف أمنع أن يصبح العرض التقديمي كبيرًا جدًا بسبب عدد كبير من الصور؟**

أعد استخدام مورد صورة واحد بدلاً من النسخ المتكررة، اختر دقات مناسبة، طبّق ضغطًا عند الحفظ، واحفظ الرسومات المتكررة على القالب الرئيسي حيثما كان ذلك مناسبًا.