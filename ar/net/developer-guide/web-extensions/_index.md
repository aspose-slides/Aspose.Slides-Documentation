---
title: نظام تصدير HTML الجديد - Aspose.Slides.WebExtensions
type: docs
weight: 240
url: /ar/net/web-extensions/
keywords:
- ملحق ويب
- محرك القوالب
- تصدير PowerPoint
- تصدير OpenDocument
- تصدير عرض تقديمي
- تصدير شريحة
- تصدير PPT
- تصدير PPTX
- تصدير ODP
- PowerPoint إلى HTML
- OpenDocument إلى HTML
- عرض تقديمي إلى HTML
- شريحة إلى HTML
- PPT إلى HTML
- PPTX إلى HTML
- ODP إلى HTML
- .NET
- C#
- Aspose.Slides
description: "تصدير العروض التقديمية إلى HTML باستخدام القوالب وCSS وJS — دون SVG. تعلم مخرجات صفحة واحدة أو متعددة الصفحات، التحكم في الموارد، وتخصيص PPT وPPTX وODP."
---

## **المقدمة**

* في إصدارات Aspose.Slides API القديمة، عندما تقوم بتصدير PowerPoint إلى HTML، كان HTML الناتج يُمثَّل كعلامة SVG مدمجة مع HTML. كل شريحة كانت تُصدَّر كحاوية SVG.  
* في إصدارات Aspose.Slides الحديثة، عندما تستخدم نظام WebExtensions لتصدير عروض PowerPoint إلى HTML، يمكنك تخصيص إعدادات تصدير HTML للحصول على أفضل النتائج.  

باستخدام نظام WebExtensions الجديد، يمكنك تصدير عرض كامل إلى HTML مع مجموعة من فئات CSS ورسوم JavaScript (بدون SVG). يوفر نظام التصدير الجديد عددًا غير محدود من الخيارات والطرق التي تحدد عملية التصدير.  

يُستخدم نظام WebExtensions لتوليد HTML من العروض في الحالات والأحداث التالية:

* عند استخدام أنماط CSS أو رسوم متحركة مخصصة؛ تعديل العلامة لأشكال معينة.  
* عند تعديل بنية المستند، مثل استخدام تنقل مخصص بين الصفحات.  
* عند حفظ ملفات .html و .css و .js في مجلدات ذات هيكلية مخصصة، مع تضمين أنواع ملفات معينة في مجلدات مختلفة. على سبيل المثال، تصدير الشرائح إلى مجلد بناءً على اسم القسم.  
* عند حفظ ملفات CSS و JS في مجلدات منفصلة افتراضيًا ثم إضافتها إلى ملف HTML. تُحفظ الصور والخطوط المضمَّنة أيضًا في ملفات منفصلة. ومع ذلك، يمكن تضمينها في ملف HTML (بتنسيق base64). يمكنك حفظ بعض أجزاء الموارد في الملفات وتضمين موارد أخرى في HTML كـ base64.  

يمكنك الاطلاع على أمثلة PowerPoint إلى HTML في [مشروع Aspose.Slides.WebExtensions](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/) على GitHub. يحتوي هذا المشروع على جزأين: **Examples\SinglePageApp** و **Examples\MultiPageApp**. يمكن العثور على الأمثلة الأخرى المستخدمة في هذه المقالة أيضًا في مستودع GitHub.

### **القوالب**

لتوسيع قدرات تصدير HTML بشكل أكبر، نُوصي باستخدام نظام القوالب ASP.NET Razor. يمكن استخدام مثيل الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) جنبًا إلى جنب مع مجموعة من القوالب للحصول على مستند HTML كنتيجة للتصدير.

**العرض**

في هذا المثال، سنصدر النص من عرض إلى HTML. أولاً، لننشئ القالب:
``` html
<!DOCTYPE html>
<body>
    @foreach (Slide slide in Model.Object.Slides)    
    {
        foreach (Shape shape in slide.Shapes)
        {
            if(shape is AutoShape)
            {
                ITextFrame textFrame = ((AutoShape)shape).TextFrame;
                <div class="text">@textFrame.Text</div>
            }
        }
    }
</body>
</html>
```

يُحفظ هذا القالب على القرص باسم "shape-template-hello-world.html"، وسيُستخدم في الخطوة التالية.

في هذا القالب، نحن نستعرض إطارات النص في أشكال العرض لعرض النص. دعنا نولد ملف HTML باستخدام WebDocument ثم نصدر الـ Presentation إلى الملف:
```csharp
using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 150);
    shape.TextFrame.Text = "Hello World";
                
    WebDocumentOptions options = new WebDocumentOptions
    {
        TemplateEngine = new RazorTemplateEngine(), // نحن نعتزم استخدام محرك القوالب Razor. يمكن استخدام محركات قوالب أخرى عن طريق تنفيذ ITemplateEngine  
        OutputSaver = new FileOutputSaver() // يمكن استخدام موفري النتائج الآخرين عن طريق تنفيذ واجهة IOutputSaver
    };
    WebDocument document = new WebDocument(options);

    // إضافة وثيقة "input" - ما المصدر الذي سيُستخدم لتوليد مستند HTML
    document.Input
        .AddTemplate<Presentation>( // القالب سيحمل Presentation ككائن "model" (Model.Object) 
        "index", // مفتاح القالب - مطلوب من محرك القالب لمطابقة كائن (Presentation) مع القالب المحمل من القرص ("shape-template-hello-world.html")  
        @"custom-templates\shape-template-hello-world.html"); // القالب الذي أنشأناه مسبقًا
                
    // إضافة إخراج - كيف سيظهر مستند HTML الناتج عندما يُصدَّر إلى القرص
    document.Output.Add(
        "hello-world.html", // مسار ملف الإخراج
        "index", // مفتاح القالب الذي سيُستخدم لهذا الملف (حددناه في العبارة السابقة)  
        pres); // كائن Model.Object فعلي 
                
    document.Save();
}
```


على سبيل المثال، نريد إضافة أنماط CSS إلى نتيجة التصدير لتغيير لون النص إلى الأحمر. لنضيف قالب CSS:
``` css
.text {
    color: red;
}
```


الآن، نضيفه إلى المدخلات والمخرجات:
``` csharp
using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 150);
    shape.TextFrame.Text = "Hello World";
                
    WebDocumentOptions options = new WebDocumentOptions { TemplateEngine = new RazorTemplateEngine(), OutputSaver = new FileOutputSaver() };
    WebDocument document = new WebDocument(options);

    document.Input.AddTemplate<Presentation>("index", @"custom-templates\shape-template-hello-world.html");
    document.Input.AddTemplate<Presentation>("styles", @"custom-templates\styles\shape-template-hello-world.css");
    document.Output.Add("hello-world.html", "index", pres); 
    document.Output.Add("hello-world.css", "styles", pres);
                
    document.Save();
}
```


لنضيف الإشارة إلى الأنماط في القالب وعلى الفئة "text":
``` html
<!DOCTYPE html>
<head>
    <link rel="stylesheet" type="text/css" href="hello-world.css" />
</head>
...
</html>
```


### **القوالب الافتراضية**

يوفر WebExtensions مجموعتين من القوالب الأساسية لتصدير العروض إلى HTML:
* صفحة واحدة: يتم تصدير كل محتوى العرض إلى ملف HTML واحد. تُصدَّر جميع الموارد الأخرى (صور، خطوط، أنماط، إلخ) إلى ملفات منفصلة.  
* متعددة الصفحات: يتم تصدير كل شريحة من العرض إلى ملف HTML منفصل. منطق تصدير الموارد الافتراضي هو نفسه كما في صفحة واحدة.  

يمكن استخدام الفئة `PresentationExtensions` لتبسيط عملية تصدير العرض باستخدام القوالب. تحتوي فئة `PresentationExtensions` على مجموعة من طرق الامتداد لفئة Presentation. لتصدير عرض إلى صفحة واحدة، يكفي استيراد مساحة الاسم Aspose.Slides.WebExtensions واستدعاء طريقتين. الطريقة الأولى، `ToSinglePageWebDocument`، تنشئ مثيلًا من `WebDocument`. الطريقة الثانية تحفظ مستند HTML:
``` csharp
using (Presentation pres = new Presentation("demo.pptx"))
{
    WebDocument document = pres.ToSinglePageWebDocument("templates\\single-page", @"single-page-output");
    document.Save();
}
```


يمكن أن تستقبل طريقة `ToSinglePageWebDocument` معاملين: مجلد القوالب ومجلد التصدير.  

لتصدير العرض إلى عدة صفحات، استخدم طريقة `ToMultiPageWebDocument` مع نفس المعاملين:
``` csharp
using (Presentation pres = new Presentation("demo.pptx"))
{
    WebDocument document = pres.ToMultiPageWebDocument("templates\\multi-page", @"mutil-page-output");
    document.Save();
}
```


في WebExtensions، كل قالب يُستخدم لتوليد العلامة مرتبط بمفتاح. يمكن استخدام المفتاح داخل القوالب. على سبيل المثال، في توجيه @Include، يمكنك إدراج قالب معين إلى آخر باستخدام المفتاح.

يمكننا توضيح الإجراء في مثال استخدام قالب جزء النص داخل قالب الفقرة. يمكنك العثور على المثال في مشروع Aspose.Slides.WebExtensions: [Templates\common\paragraph.html](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/Templates/common/paragraph.html). لرسم الأجزاء داخل الفقرة، نستعرضها باستخدام توجيه @foreach لمحرك Razor:
``` html
@foreach (Portion portion in contextObject.Portions) 
{ 
    var subModel = Model.SubModel(portion);
    subModel.Local.Put("parentTextFrame", parentTextFrame);
    subModel.Local.Put("tableContent", tableContentFlag);
	@Raw(Include("portion", subModel).ToString().Replace(Environment.NewLine, ""));
}
```


الجزء له قالبه الخاص [portion.html](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/Templates/common/portion.html) ويتم توليد نموذج له. يضاف هذا النموذج إلى قالب output paragraph.html:
``` html
@Raw(Include("portion", subModel).ToString().Replace(Environment.NewLine, ""));
```


لكل نوع شكل، نستخدم قالبًا مخصصًا يُضاف إلى مجموعة القوالب العامة من مشروع Aspose.Slides.WebExtensions. تُدمج القوالب في طريقتي `ToSinglePageWebDocument` و `ToMultiPageWebDocument` لتوفير النتيجة النهائية. هذه قوالب مشتركة تُستخدم في كل من الصفحة الواحدة والمتعددة:

-templates  
+-common  
  ¦ +-scripts: سكريبتات JavaScript لتأثيرات انتقال الشرائح، كأمثلة.  
  ¦ +-styles: أنماط CSS المشتركة.  
  +-multi-page: فهارس، قوائم، قوالب الشرائح للإخراج متعدد الصفحات.  
  +-single-page: فهارس، قوالب الشرائح للإخراج صفحة واحدة.  

يمكنك معرفة كيفية ربط الجزء المشترك لجميع القوالب في طريقة `PresentationExtensions.AddCommonInputOutput` [هنا](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/PresentationExtensions.cs).

### **تخصيص القالب الافتراضي**

يمكنك تعديل أي عنصر في قالب النموذج المشترك. على سبيل المثال، قد ترغب في تغيير أنماط تنسيق الجدول لكن تريد أن تبقى جميع الأنماط الأخرى للصفحة الواحدة دون تغيير.

افتراضيًا، يُستخدم Templates\common\table.html، ويظهر الجدول بنفس مظهره في PowerPoint. لنغير تنسيق الجدول باستخدام أنماط CSS مخصصة:
``` css
.custom-table {
    border: 1px solid black;
}
.custom-table tr:nth-child(even) {background: #CCC}
.custom-table tr:nth-child(odd) {background: #ffb380}
```


يمكننا إنشاء نفس بنية القوالب المدخلة والملفات الناتجة (كما تُولد) عند استدعاء طريقة `PresentationExtensions.ToSinglePageWebDocument`. لنضيف طريقة `ExportCustomTableStyles_AddCommonStructure` لذلك. الفرق بين هذه الطريقة وطريقة `ToSinglePageWebDocument`—لا نحتاج إلى إضافة القالب القياسي للجدول والصفحة الرئيسية (سيتم استبداله لتضمين الإشارة إلى أنماط الجدول المخصصة):
``` csharp
private static void ExportCustomTableStyles_AddCommonStructure(
    Presentation pres, 
    WebDocument document,
    string templatesPath, 
    string outputPath, 
    bool embedImages)
{
    AddCommonStylesTemplates(document, templatesPath);
            
    document.Input.AddTemplate<Slide>("slide", Path.Combine(templatesPath, "slide.html"));
    document.Input.AddTemplate<AutoShape>("autoshape", Path.Combine(templatesPath, "autoshape.html"));
    document.Input.AddTemplate<TextFrame>("textframe", Path.Combine(templatesPath, "textframe.html"));
    document.Input.AddTemplate<Paragraph>("paragraph", Path.Combine(templatesPath, "paragraph.html"));
    document.Input.AddTemplate<Paragraph>("bullet", Path.Combine(templatesPath, "bullet.html"));
    document.Input.AddTemplate<Portion>("portion", Path.Combine(templatesPath, "portion.html"));
    document.Input.AddTemplate<VideoFrame>("videoframe", Path.Combine(templatesPath, "videoframe.html"));
    document.Input.AddTemplate<PictureFrame>("pictureframe", Path.Combine(templatesPath, "pictureframe.html")); ;
    document.Input.AddTemplate<Shape>("shape", Path.Combine(templatesPath, "shape.html"));

    AddSinglePageCommonOutput(pres, document, outputPath);
            
    AddResourcesOutput(pres, document, embedImages);
            
    AddScriptsOutput(document, templatesPath);
}
```


لنضيف قالبًا مخصصًا بدلاً من ذلك:
```csharp
using (Presentation pres = new Presentation("table.pptx"))
{
    const string templatesPath = "templates\\single-page";
    const string outputPath = "custom-table-styles";
                
    var options = new WebDocumentOptions
    {
        TemplateEngine = new RazorTemplateEngine(),
        OutputSaver = new FileOutputSaver(),
        EmbedImages = false
    };

    // إعداد قيم المستند العامة
    WebDocument document = new WebDocument(options);
    SetupGlobals(document, options, outputPath);

    // إضافة الهيكل المشترك (باستثناء قالب الجدول)
    ExportCustomTableStyles_AddCommonStructure(pres, document, templatesPath, outputPath, options.EmbedImages);
                
    // إضافة قالب جدول مخصص
    document.Input.AddTemplate<Table>("table", @"custom-templates\table-custom-style.html");
                
    // إضافة أنماط جدول مخصصة
    document.Input.AddTemplate<Presentation>("table-custom-style", @"custom-templates\styles\table-custom-style.css");
    document.Output.Add(Path.Combine(outputPath, "table-custom-style.css"), "table-custom-style", pres);
                
    // إضافة فهرس مخصص - هو مجرد نسخة من "index.html" القياسي، لكنه يتضمن إشارة إلى "table-custom-style.css"
    document.Input.AddTemplate<Presentation>("index", @"custom-templates\index-table-custom-style.html");
                
    document.Save();
}
```

``` html
@model TemplateContext<Table>

@{
	Table contextObject = Model.Object;
	
	var origin = Model.Local.Get<Point>("origin");
	var positionStyle = string.Format("left: {0}px; top: {1}px; width: {2}px; height: {3}px;",
										(int)contextObject.X + origin.X,
										(int)contextObject.Y + origin.Y,
										(int)contextObject.Width,
										(int)contextObject.Height);
}

	<table class="table custom-table" style="@positionStyle">
	@for (int i = 0; i < contextObject.Rows.Count; i++)
	{
		var rowHeight = string.Format("height: {0}px", contextObject.Rows[i].Height);
		<tr style="@rowHeight">
		@for (int j = 0; j < contextObject.Columns.Count; j++)
		{
			var cell = contextObject[j, i];
			if (cell.FirstRowIndex ==  i && cell.FirstColumnIndex == j)
			{
				var spans = cell.IsMergedCell ? string.Format("rowspan=\"{0}\" colspan=\"{1}\"", cell.RowSpan, cell.ColSpan) : "";
				<td width="@cell.Width px" @Raw(spans)>
					@{
						for(int k = 0; k < cell.TextFrame.Paragraphs.Count; k++)
						{
							var para = (Paragraph)cell.TextFrame.Paragraphs[k];
						
							var subModel = Model.SubModel(para);
							double[] margins = new double[] { cell.MarginLeft, cell.MarginTop, cell.MarginRight, cell.MarginBottom };
							subModel.Local.Put("margins", margins);
							subModel.Local.Put("parent", cell.TextFrame);
							subModel.Local.Put("parentContainerSize", new SizeF((float)cell.Width, (float)cell.Height));
                            subModel.Local.Put("tableContent", true);
							
							@Include("paragraph", subModel)
						}
					}
				</td>
			}
		}
		</tr>
	}
</table>
```


**ملاحظة**: تم إضافة قالب الجدول المخصص بنفس المفتاح “table” كالقالب القياسي. وبالتالي، يمكنك استبدال قالب افتراضي معين دون الحاجة إلى إعادة كتابته. يمكنك أيضًا استخدام القوالب من البنية الافتراضية بنفس المفاتيح. على سبيل المثال، قد تستخدم قالب الفقرة القياسي داخل قالب الجدول؛ ويمكنك أيضًا استبداله بالمفتاح. يمكنك أيضًا استخدام index.html لتضمين الإشارة إلى أنماط CSS الخاصة بالجدول داخلها:
``` html
<!DOCTYPE html>    
    
<html     
    xmlns="http://www.w3.org/1999/xhtml"    
    xmlns:svg="http://www.w3.org/2000/svg"    
    xmlns:xlink="http://www.w3.org/1999/xlink">    
<head>    
     ...
    <link rel="stylesheet" type="text/css" href="table-custom-style.css" />
    ...
</head>    
<body>    
    ...
</body>
</html>
```


## **إنشاء مشروع من الصفر: انتقالات شرائح مُتحركة**

يسمح WebExtensions بتصدير العروض مع انتقالات شرائح مُتحركة—كل ما عليك هو ضبط خاصية `AnimateTransitions` في `WebDocumentOptions` إلى `true`:
``` csharp
WebDocumentOptions options = new WebDocumentOptions
{
    // ... خيارات أخرى
    AnimateTransitions = true
};
```


لِننشئ مشروعًا جديدًا يستخدم Aspose.Slides و Aspose.Slides.WebExtensions لإنشاء عارض HTML لملف PDF مع انتقالات صفحات مُتحركة سلسة. هنا، نحتاج إلى استخدام ميزة استيراد PDF في Aspose.Slides.

لِننشئ مشروع PdfToPresentationToHtml ونضيف حزمة NuGet Aspose.Slides.WebExtensions (وسيتم إضافة حزمة Aspose.Slides كاعتماد أيضًا):
![NuGet Package](screen.png)

نبدأ باستيراد مستند PDF، الذي سيتم تحريكه وتصديره إلى عرض HTML:
``` csharp
using (Presentation pres = new Presentation())
{
    pres.Slides.RemoveAt(0);
    pres.Slides.AddFromPdf("sample.pdf");
}
```


الآن، يمكننا إعداد انتقالات الشرائح المتحركة (كل شريحة هي صفحة PDF مستوردة). استخدمنا 9 شرائح في مستند PDF النموذجي. لنضيف انتقالات الشريحة إلى كل منها (عرض توضيحي أثناء مشاهدة HTML):
``` csharp
pres.Slides[0].SlideShowTransition.Type = TransitionType.Fade;
pres.Slides[1].SlideShowTransition.Type = TransitionType.RandomBar;
pres.Slides[2].SlideShowTransition.Type = TransitionType.Cover;
pres.Slides[3].SlideShowTransition.Type = TransitionType.Dissolve;
pres.Slides[4].SlideShowTransition.Type = TransitionType.Switch;
pres.Slides[5].SlideShowTransition.Type = TransitionType.Pan;
pres.Slides[6].SlideShowTransition.Type = TransitionType.Ferris;
pres.Slides[7].SlideShowTransition.Type = TransitionType.Pull;
pres.Slides[8].SlideShowTransition.Type = TransitionType.Plus;
```


أخيرًا، لنصدره إلى HTML باستخدام `WebDocument` مع ضبط خاصية `AnimateTransitions` على `true`:
``` csharp
WebDocumentOptions options = new WebDocumentOptions
{
    TemplateEngine = new RazorTemplateEngine(),
    OutputSaver = new FileOutputSaver(),
    AnimateTransitions = true
};

WebDocument document = pres.ToSinglePageWebDocument(options, "templates\\single-page", "animated-pdf");
document.Save();
```


مثال كامل لشفرة المصدر:
``` csharp
using (Presentation pres = new Presentation())
{
    pres.Slides.RemoveAt(0);
    pres.Slides.AddFromPdf("sample.pdf");

    pres.Slides[0].SlideShowTransition.Type = TransitionType.Fade;
    pres.Slides[1].SlideShowTransition.Type = TransitionType.RandomBar;
    pres.Slides[2].SlideShowTransition.Type = TransitionType.Cover;
    pres.Slides[3].SlideShowTransition.Type = TransitionType.Dissolve;
    pres.Slides[4].SlideShowTransition.Type = TransitionType.Switch;
    pres.Slides[5].SlideShowTransition.Type = TransitionType.Pan;
    pres.Slides[6].SlideShowTransition.Type = TransitionType.Ferris;
    pres.Slides[7].SlideShowTransition.Type = TransitionType.Pull;
    pres.Slides[8].SlideShowTransition.Type = TransitionType.Plus;

    WebDocumentOptions options = new WebDocumentOptions
    {
        TemplateEngine = new RazorTemplateEngine(),
        OutputSaver = new FileOutputSaver(),
        AnimateTransitions = true
    };

    WebDocument document = pres.ToSinglePageWebDocument(options, "templates\\single-page", "animated-pdf");
    document.Save();
}
```


هذا كل ما تحتاجه لإنشاء HTML مع انتقالات صفحات متحركة مُنشأة من مستند PDF.

* [تحميل ملف HTML تجريبي](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/tree/main/Examples).  
* [تحميل المشروع التجريبي](/slides/ar/net/web-extensions/sample.zip).