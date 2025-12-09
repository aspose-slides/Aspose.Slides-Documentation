---
title: نظام تصدير HTML الجديد - Aspose.Slides.WebExtensions
type: docs
weight: 240
url: /ar/net/web-extensions/
keywords:
- امتداد ويب
- محرك القوالب
- تصدير PowerPoint
- تصدير OpenDocument
- تصدير العرض التقديمي
- تصدير الشريحة
- تصدير PPT
- تصدير PPTX
- تصدير ODP
- PowerPoint إلى HTML
- OpenDocument إلى HTML
- العرض التقديمي إلى HTML
- الشريحة إلى HTML
- PPT إلى HTML
- PPTX إلى HTML
- ODP إلى HTML
- .NET
- C#
- Aspose.Slides
description: "تصدير العروض التقديمية إلى HTML باستخدام القوالب وCSS وJS — بدون SVG. تعلم كيفية الحصول على مخرجات صفحة واحدة أو متعددة الصفحات، والتحكم في الموارد، والتخصيص لـ PPT وPPTX وODP."
---

## مقدمة

* في إصدارات Aspose.Slides API القديمة، عند تصدير PowerPoint إلى HTML، تم تمثيل HTML الناتج كعلامة SVG مدمجة مع HTML. تم تصدير كل شريحة كحاوية SVG.  
* في إصدارات Aspose.Slides الحديثة، عند استخدام نظام WebExtensions لتصدير عروض PowerPoint إلى HTML، يمكنك تخصيص إعدادات تصدير HTML للحصول على أفضل النتائج.  

باستخدام نظام WebExtensions الجديد، يمكنك تصدير عرض كامل إلى HTML مع مجموعة من فئات CSS وتحريكات JavaScript (بدون SVG). كما يوفر نظام التصدير الجديد عددًا غير محدود من الخيارات والطرق التي تحدد عملية التصدير.  

يُستخدم نظام WebExtensions لتوليد HTML من العروض في الحالات والأحداث التالية:

* عند استخدام أنماط CSS مخصصة أو تحريكات؛ وتجاوز العلامات لأشكال معينة.  
* عند تجاوز بنية المستند، على سبيل المثال باستخدام تنقل مخصص بين الصفحات.  
* عند حفظ ملفات .html و .css و .js في مجلدات ذات تسلسل هرمي مخصص، بما في ذلك أنواع ملفات محددة في مجلدات مختلفة. على سبيل المثال، تصدير الشرائح إلى مجلد يعتمد على اسم القسم.  
* عند حفظ ملفات CSS و JS في مجلدات منفصلة بشكل افتراضي ثم إضافتها إلى ملف HTML. تُحفَظ الصور والخطوط المدمجة أيضًا في ملفات منفصلة. ومع ذلك، يمكن تضمينها في ملف HTML (بتنسيق base64). يمكنك حفظ بعض أجزاء الموارد في الملفات وتضمين موارد أخرى في HTML كـ base64.  

يمكنك استكشاف أمثلة PowerPoint إلى HTML في [مشروع Aspose.Slides.WebExtensions](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/) على GitHub. يحتوي هذا المشروع على جزأين: **Examples\SinglePageApp** و **Examples\MultiPageApp**. يمكن أيضًا العثور على الأمثلة الأخرى المستخدمة في هذه المقالة في المستودع على GitHub.  

### **قوالب**

لتمديد قدرات تصدير HTML أكثر، نوصي باستخدام نظام القوالب ASP.NET Razor. يمكن استخدام كائن الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) جنبًا إلى جنب مع مجموعة من القوالب للحصول على مستند HTML كنتيجة للتصدير.  

**عرض توضيحي**

في هذا المثال، سنقوم بتصدير النص من عرض إلى HTML. أولاً، لننشئ القالب:
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

يتم حفظ هذا القالب على القرص باسم `"shape-template-hello-world.html"`، والذي سيُستخدم في الخطوة التالية.  

في هذا القالب، نقوم بتدوير إطارات النص في أشكال العرض لعرض النص. لنُنشئ ملف HTML باستخدام WebDocument ثم نصدّر الـ Presentation إلى الملف:  
``` csharp
using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 150);
    shape.TextFrame.Text = "Hello World";
                
    WebDocumentOptions options = new WebDocumentOptions
    {
        TemplateEngine = new RazorTemplateEngine(), // نعتزم استخدام محرك القوالب Razor. يمكن استخدام محركات قوالب أخرى عن طريق تنفيذ ITemplateEngine  
        OutputSaver = new FileOutputSaver() // يمكن استخدام حافظي النتائج الآخرين عن طريق تنفيذ واجهة IOutputSaver
    };
    WebDocument document = new WebDocument(options);

    // إضافة وثيقة "input" - ما المصدر الذي سيستخدم لتوليد وثيقة HTML
    document.Input
        .AddTemplate<Presentation>( // القالب سيحمل Presentation ككائن "model" (Model.Object) 
        "index", // مفتاح القالب - مطلوب من محرك القالب لمطابقة كائن (Presentation) مع القالب المحمَّل من القرص ("shape-template-hello-world.html")  
        @"custom-templates\shape-template-hello-world.html"); // القالب الذي أنشأناه مسبقًا
                
    // إضافة المخرجات - كيف سيظهر مستند HTML الناتج عند تصديره إلى القرص
    document.Output.Add(
        "hello-world.html", // مسار ملف الإخراج
        "index", // مفتاح القالب الذي سيُستخدم لهذا الملف (تم ضبطه في بيان سابق)  
        pres); // كائن Model.Object الفعلي 
                
    document.Save();
}
```


على سبيل المثال، نريد إضافة أنماط CSS إلى نتيجة التصدير لتغيير لون النص إلى الأحمر. لنضيف قالب CSS:  
``` css
.text {
    color: red;
}
```


الآن، نضيفه إلى الإدخال والإخراج:  
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


لنضيف المرجع إلى الأنماط في القالب والفئة `"text"`:  
``` html
<!DOCTYPE html>
<head>
    <link rel="stylesheet" type="text/css" href="hello-world.css" />
</head>
...
</html>
```


### **القوالب الافتراضية**

توفر WebExtensions مجموعتين من القوالب الأساسية لتصدير العروض إلى HTML:
* **Single-page**: يتم تصدير جميع محتويات العرض إلى ملف HTML واحد. تُحفظ جميع الموارد الأخرى (الصور، الخطوط، الأنماط، إلخ) في ملفات منفصلة.  
* **Multi-page**: يتم تصدير كل شريحة من العرض إلى ملف HTML منفرد. منطق تصدير الموارد الافتراضي هو نفسه كما في الصفحة الواحدة.  

يمكن استخدام الفئة `PresentationExtensions` لتبسيط عملية تصدير العرض باستخدام القوالب. تحتوي فئة `PresentationExtensions` على مجموعة من طرق التوسيع لفئة Presentation. لتصدير عرض إلى صفحة واحدة، يكفي استيراد مساحة الأسماء Aspose.Slides.WebExtensions واستدعاء طريقتين. الطريقة الأولى، `ToSinglePageWebDocument`، تُنشئ كائن `WebDocument`. الطريقة الثانية تحفظ مستند HTML:  
``` csharp
using (Presentation pres = new Presentation("demo.pptx"))
{
    WebDocument document = pres.ToSinglePageWebDocument("templates\\single-page", @"single-page-output");
    document.Save();
}
```


يمكن لطريقة `ToSinglePageWebDocument` أخذ معلمين: مجلد القوالب ومجلد التصدير.  

لتصدير العرض إلى صفحات متعددة، استخدم الطريقة `ToMultiPageWebDocument` مع نفس المعلمات:  
``` csharp
using (Presentation pres = new Presentation("demo.pptx"))
{
    WebDocument document = pres.ToMultiPageWebDocument("templates\\multi-page", @"mutil-page-output");
    document.Save();
}
```


في WebExtensions، يُربط كل قالب يُستخدم لتوليد العلامات بمفتاح. يمكن استخدام المفتاح داخل القوالب. على سبيل المثال، في توجيه @Include، يمكنك إدراج قالب معين في قالب آخر عبر المفتاح.  

يمكننا توضيح الإجراء من خلال مثال استخدام قالب جزء النص داخل قالب الفقرة. يمكنك العثور على المثال في مشروع Aspose.Slides.WebExtensions: [Templates\common\paragraph.html](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/Templates/common/paragraph.html). لرسم الأجزاء داخل الفقرة، نقوم بتدويرها باستخدام توجيه @foreach في محرك Razor:  
``` html
@foreach (Portion portion in contextObject.Portions) 
{ 
    var subModel = Model.SubModel(portion);
    subModel.Local.Put("parentTextFrame", parentTextFrame);
    subModel.Local.Put("tableContent", tableContentFlag);
	@Raw(Include("portion", subModel).ToString().Replace(Environment.NewLine, ""));
}
```


للجزء قالب خاص به [portion.html](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/Templates/common/portion.html) ويُولَّد نموذج له. سيُضاف هذا النموذج إلى قالب المخرج paragraph.html:  
``` html
@Raw(Include("portion", subModel).ToString().Replace(Environment.NewLine, ""));
```


لكل نوع شكل، نستخدم قالبًا مخصصًا يُضاف إلى مجموعة القوالب العامة من مشروع Aspose.Slides.WebExtensions. تُدمج القوالب في طريقتي `ToSinglePageWebDocument` و `ToMultiPageWebDocument` لتوفير النتيجة النهائية. هذه قوالب مشتركة تُستخدم في كل من الصفحة الواحدة والمتعددة:

-templates  
+-common  
  ¦ +-scripts: نصوص جافاسكريبت لتطبيقات انتقالات الشرائح.  
  ¦ +-styles: أنماط CSS المشتركة.  
  +-multi-page: index، menu، slide قوالب للمخرجات متعددة الصفحات.  
  +-single-page: index، slide قوالب للمخرجات صفحة واحدة.  

يمكنك معرفة كيفية ربط الجزء المشترك لجميع القوالب في طريقة `PresentationExtensions.AddCommonInputOutput` [هنا](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/PresentationExtensions.cs).  

### **تخصيص القالب الافتراضي**

يمكنك تعديل أي عنصر في قالب النموذج المشترك. على سبيل المثال، قد ترغب في تغيير أنماط تنسيق الجدول وتريد أن تظل جميع الأنماط الأخرى للصفحة الواحدة دون تغيير.  

بشكل افتراضي، يُستخدم `Templates\common\table.html`، ويظهر الجدول بنفس مظهر جدول PowerPoint. لنُغيِّر تنسيق الجدول باستخدام أنماط CSS مخصصة:  
``` css
.custom-table {
    border: 1px solid black;
}
.custom-table tr:nth-child(even) {background: #CCC}
.custom-table tr:nth-child(odd) {background: #ffb380}
```


يمكننا إنشاء نفس بنية القوالب الإدخالية وملفات المخرجات (كما تُولَّد) عند استدعاء طريقة `PresentationExtensions.ToSinglePageWebDocument`. لنضيف طريقة `ExportCustomTableStyles_AddCommonStructure` لهذا الغرض. الفرق بين هذه الطريقة وطريقة `ToSinglePageWebDocument`—ليس من الضروري إضافة القالب القياسي للجدول والصفحة الرئيسية (سيتم استبدالهما لتضمين المرجع إلى أنماط الجدول المخصصة):  
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


لنضيف قالبًا مخصصًا بدلًا من ذلك:  
``` csharp
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

    // إضافة البنية العامة (باستثناء قالب الجدول)
    ExportCustomTableStyles_AddCommonStructure(pres, document, templatesPath, outputPath, options.EmbedImages);
                
    // إضافة قالب جدول مخصص
    document.Input.AddTemplate<Table>("table", @"custom-templates\table-custom-style.html");
                
    // إضافة أنماط جدول مخصص
    document.Input.AddTemplate<Presentation>("table-custom-style", @"custom-templates\styles\table-custom-style.css");
    document.Output.Add(Path.Combine(outputPath, "table-custom-style.css"), "table-custom-style", pres);
                
    // إضافة فهرس مخصص - هو مجرد نسخة من "index.html" القياسي، لكنه يتضمن مرجعًا إلى "table-custom-style.css"
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


**ملاحظة** أن قالب الجدول المخصص أُضيف بالمفتاح `"table"` نفسه كالجدول القياسي. وبالتالي يمكنك استبدال قالب افتراضي معين دون إعادة كتابته. يمكنك أيضًا استخدام القوالب من البنية الافتراضية بنفس المفاتيح. على سبيل المثال، يمكنك استخدام قالب فقرة قياسي داخل قالب الجدول؛ أو استبداله بالمفتاح. يمكنك أيضًا استخدام `index.html` لتضمين المرجع إلى أنماط CSS الخاصة بالجدول فيه:  
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


## **إنشاء مشروع من الصفر: انتقالات الشرائح المتحركة**

تسمح WebExtensions بتصدير العروض مع انتقالات شرائح متحركة—فقط عليك ضبط الخاصية `AnimateTransitions` في `WebDocumentOptions` إلى `true`:  
``` csharp
WebDocumentOptions options = new WebDocumentOptions
{
    // ... خيارات أخرى
    AnimateTransitions = true
};
```


لنُنشئ مشروعًا جديدًا يستخدم Aspose.Slides و Aspose.Slides.WebExtensions لإنشاء عارض HTML لملف PDF مع انتقالات صفحات سلسة ومتحركة. هنا نحتاج إلى استخدام ميزة استيراد PDF في Aspose.Slides.  

لنُنشئ مشروع `PdfToPresentationToHtml` ونضيف حزمة NuGet الخاصة بـ Aspose.Slides.WebExtensions (ستُضاف حزمة Aspose.Slides أيضًا كاعتماد):  
![حزمة NuGet](screen.png)

نبدأ باستيراد مستند PDF، الذي سيُصبح متحركًا ويُصدَّر إلى عرض HTML:  
``` csharp
using (Presentation pres = new Presentation())
{
    pres.Slides.RemoveAt(0);
    pres.Slides.AddFromPdf("sample.pdf");
}
```


الآن، يمكننا إعداد انتقالات الشرائح المتحركة (كل شريحة هي صفحة PDF المستوردة). استخدمنا 9 شرائح في مستند PDF التجريبي. لنُضيف انتقالات شرائح إلى كل منها (عرض توضيحي أثناء مشاهدة HTML):  
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


أخيرًا، لنُصدِّرها إلى HTML باستخدام `WebDocument` مع ضبط الخاصية `AnimateTransitions` إلى `true`:  
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


مثال كامل على شفرة المصدر:  
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


هذا كل ما تحتاجه لإنشاء HTML مع انتقالات صفحات متحركة مُولدة من مستند PDF.  

* [تحميل ملف HTML التجريبي](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/tree/main/Examples).  
* [تحميل مشروع تجريبي](/slides/ar/net/web-extensions/sample.zip).