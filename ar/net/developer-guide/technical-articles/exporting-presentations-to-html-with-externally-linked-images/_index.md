---
title: تصدير العروض التقديمية إلى HTML مع الصور المرتبطة خارجيًا
type: docs
weight: 100
url: /net/exporting-presentations-to-html-with-externally-linked-images/
---

{{% alert color="primary" %}} 

إجراءات تصدير العروض التقديمية إلى HTML هنا تتيح لك تحديد

1. الموارد التي سيتم تضمينها في ملف HTML الناتج
2. الموارد التي سيتم حفظها خارجيًا والإشارة إليها من ملف HTML.

{{% /alert %}} 

## **الخلفية**

السلوك الافتراضي لتصدير HTML هو تضمين جميع الموارد داخل ملف HTML من خلال الترميز base64. مثل هذا النهج ينتج ملف HTML واحد، وهو مناسب للمشاهدة والتوزيع. يعاني النهج الافتراضي من هذه القيود:

* الملف الناتج أكبر بكثير من مكوناته بسبب ترميز base64.
* من الصعب استبدال الصور أو الموارد الموجودة في الملف.

### **نهج مختلف**

نهج مختلف يتضمن **[ILinkEmbedController](https://reference.aspose.com/slides/net/aspose.slides.export/ilinkembedcontroller/)** يتجنب القيود المذكورة.

تقوم فئة `LinkController` بتنفيذ واجهة `ILinkEmbedController`. ثم يتم تمرير الواجهة إلى منشئ فئة [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions/htmloptions/#constructor). تحتوي واجهة ILinkEmbedController على ثلاث طرق تتحكم في عملية تضمين الموارد وحفظها:

**[GetObjectStoringLocation](https://reference.aspose.com/slides/net/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation)(int id, byte[] entityData, string semanticName, string contentType, string recomendedExtension)**: يتم استدعاء هذه الطريقة عندما يواجه المصدر موردًا ويجب عليه تحديد كيفية تخزين المورد. *id* (معرف مورد فريد لعملية التصدير) و *contentType* (الذي يحتوي على نوع MIME للمورد) هما المعاملان الأكثر أهمية تحت هذه الطريقة. إذا كنت تريد ربط المورد، يجب عليك إرجاع قيمة [LinkEmbedDecision.Link](https://reference.aspose.com/slides/net/aspose.slides.export/linkembeddecision/) من الطريقة. خلاف ذلك (لتضمين المورد)، يجب عليك إرجاع [LinkEmbedDecision.Embed](https://reference.aspose.com/slides/net/aspose.slides.export/linkembeddecision/).

**[GetUrl](https://reference.aspose.com/slides/net/aspose.slides.export/ilinkembedcontroller/geturl)(int id, int referrer)**: يتم استدعاء هذه الطريقة للحصول على عنوان URL للمورد بالشكل نفسه الذي تم استخدامه في الملف الناتج. يتم التعرف على المورد بواسطة *id*.

**[SaveExternal](https://reference.aspose.com/slides/net/aspose.slides.export/ilinkembedcontroller/saveexternal)(int id, byte[] entityData)**: كطريقة نهائية في التسلسل، يتم استدعاؤها عندما يحين الوقت لتخزين المورد خارجيًا. نظرًا لأن معرف المورد ومحتويات المورد موجودة في مصفوفة بايت، يمكنك تنفيذ جميع أنواع المهام مع بيانات المورد.

هذا الكود C# لفئة **LinkController** ينفذ واجهة **ILinkEmbedController**:

```c#
class LinkController : ILinkEmbedController
{
    static LinkController()
    {
        s_templates.Add("image/jpeg", "image-{0}.jpg");
        s_templates.Add("image/png", "image-{0}.png");
    }

    /// <summary>
    /// الباني الافتراضي بدون معايير
    /// </summary>
    public LinkController()
    {
        m_externalImages = new Dictionary<int, string>();
    }

    /// <summary>
    /// ينشئ مثيلًا للفئة ويحدد المسار حيث سيتم حفظ ملفات الموارد المولدة.
    /// </summary>
    /// <param name="savePath">المسار إلى الموقع حيث سيتم تخزين ملفات الموارد المولدة.</param>
    public LinkController(string savePath)
        : this()
    {
        SavePath = savePath;
    }

    /// <summary>
    /// عضو في واجهة ILinkEmbedController
    /// </summary>
    public LinkEmbedDecision GetObjectStoringLocation(int id, byte[] entityData, string semanticName,
        string contentType,
        string recomendedExtension)
    {
        // هنا نتخذ القرار بشأن تخزين الصور خارجيًا.
        // id هو معرف فريد لكل كائن خلال عملية التصدير.

        string template;

        // يحتوي قاموس s_templates على أنواع المحتوى التي نعتزم تخزينها خارجيًا وقالب الاسم الملف المقابل.
        if (s_templates.TryGetValue(contentType, out template))
        {
            // تخزين هذا المورد في قائمة التصدير
            m_externalImages.Add(id, template);
            return LinkEmbedDecision.Link;
        }

        // سيتم تضمين جميع الموارد الأخرى، إن وجدت
        return LinkEmbedDecision.Embed;
    }

    /// <summary>
    /// عضو في واجهة ILinkEmbedController
    /// </summary>
    public string GetUrl(int id, int referrer)
    {
        // هنا نقوم بإنشاء سلسلة مرجعية المورد لتشكيل العلامة: <img src="%result%">
        // نحتاج إلى التحقق من القاموس لتصفية الموارد غير الضرورية.
        // جنبًا إلى جنب مع التحقق نستخرج القالب المقابل لاسم الملف.
        string template;
        if (m_externalImages.TryGetValue(id, out template))
        {
            // نفترض أننا سنقوم بتخزين ملفات الموارد قريبًا من ملف HTML.
            // سيبدو علامة الصورة مثل <img src="image-1.png"> مع معرف المورد المناسب والامتداد.
            var fileUrl = String.Format(template, id);
            return fileUrl;
        }

        // يجب إرجاع null بالنسبة للموارد المتبقية مضمنة
        return null;
    }

    /// <summary>
    /// عضو في واجهة ILinkEmbedController
    /// </summary>
    public void SaveExternal(int id, byte[] entityData)
    {
        // هنا نقوم فعليًا بحفظ ملفات المورد على القرص.
        // مرة أخرى، نتفقد القاموس. إذا لم يتم العثور على id هنا، فهذه علامة على وجود خطأ في طرق GetObjectStoringLocation أو GetUrl.
        if (m_externalImages.ContainsKey(id))
        {
            // الآن نستخدم اسم الملف المخزن في القاموس ونجمعه مع المسار حسب الحاجة.

            // إنشاء اسم الملف باستخدام القالب المخزن وId.
            var fileName = String.Format(m_externalImages[id], id);

            // الجمع مع الدليل المحلي
            var filePath = Path.Combine(SavePath ?? String.Empty, fileName);

            using (var fs = new FileStream(filePath, FileMode.Create))
                fs.Write(entityData, 0, entityData.Length);
        }
        else
            throw new Exception("هناك خطأ ما");
    }

    /// <summary>
    /// الحصول على أو تعيين المسار حيث سيتم حفظ ملفات الموارد المولدة.
    /// </summary>
    public string SavePath { get; set; }

    /// <summary>
    /// قاموس لتخزين العلاقات بين معرفات الموارد وأسماء الملفات المقابلة.
    /// </summary>
    private readonly Dictionary<int, string> m_externalImages;

    /// <summary>
    /// قاموس لتخزين العلاقات بين أنواع المحتوى للموارد التي نعتزم تخزينها خارجيًا
    /// وقوالب أسماء الملفات المقابلة.
    /// </summary>
    private static readonly Dictionary<string, string> s_templates = new Dictionary<string, string>();
}
```

بعد كتابة فئة **LinkController**، يمكننا الآن استخدامها جنبًا إلى جنب مع فئة **HtmlOptions** لتصدير العرض التقديمي إلى HTML مع صور مرتبطة خارجيًا بهذه الطريقة:

```c#
using (var pres = new Presentation(@"C:\data\input.pptx")) {

    var htmlOptions = new HtmlOptions(new LinkController(@"C:\data\out\"));
    htmlOptions.SlideImageFormat = SlideImageFormat.Svg(new SVGOptions());
    // هذه السطر مطلوب لإزالة عرض عنوان الشريحة في HTML.
    // قم بتعليقها إذا كنت تفضل عرض عنوان الشريحة.
    htmlOptions.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter(String.Empty, false);

    Console.WriteLine("بدء التصدير");
    pres.Save(@"C:\data\out\output.html", SaveFormat.Html, htmlOptions);
}
```

تم تعيين `SlideImageFormat.Svg` إلى خاصية `SlideImageFormat` بحيث يحتوي ملف HTML الناتج على بيانات SVG لعرض محتويات العرض التقديمي.

أنواع المحتوى: إذا كان العرض التقديمي يحتوي على صور نقطية، يجب أن يكون كود الفئة مستعدًا لمعالجة كل من نوعي المحتوى 'image/jpeg' و 'image/png'. قد لا يتطابق محتوى صور النقاط المصدر مع ما تم تخزينه في العرض التقديمي. تقوم خوارزميات Aspose.Slides الداخلية بأداء تحسين الحجم وتستخدم إما ترميز JPG أو PNG (اعتمادًا على أيهما ينتج حجم بيانات أصغر). الصور التي تحتوي على قناة ألفا (الشفافية) يتم ترميزها دائمًا إلى PNG.