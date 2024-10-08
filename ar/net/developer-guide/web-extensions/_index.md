---
title: نظام تصدير HTML جديد - Aspose.Slides.WebExtensions
type: docs
weight: 240
url: /ar/net/web-extensions/
keywords: "تصدير PowerPoint HTML، عرض PowerPoint، C#، Csharp، Aspose.Slides لـ .NET"
description: "تصدير PowerPoint HTML في C# أو .NET"
---


## مقدمة

* في الإصدارات القديمة من واجهة برمجة تطبيقات Aspose.Slides، عند تصدير PowerPoint إلى HTML، تم تمثيل HTML الناتج كعلامة SVG ممزوجة بـ HTML. تم تصدير كل شريحة كوعاء SVG.
* في الإصدارات الجديدة من Aspose.Slides، عند استخدام نظام WebExtensions لتصدير عروض PowerPoint إلى HTML، يمكنك تخصيص إعدادات تصدير HTML لتحقيق أفضل النتائج.

باستخدام نظام WebExtensions الجديد، يمكنك تصدير عرض كامل إلى HTML مع مجموعة من فئات CSS وتحريكات JavaScript (دون SVG). يوفر نظام التصدير الجديد أيضًا عددًا غير محدود من الخيارات والأساليب التي تحدد عملية التصدير.

يتم استخدام نظام WebExtensions الجديد لتوليد HTML من العروض في هذه الحالات والأحداث:

* عند استخدام أنماط CSS أو تحريكات مخصصة؛ تجاوز العلامة لأنواع معينة من الأشكال.
* عند تجاوز هيكل الوثيقة، على سبيل المثال، باستخدام تنقل مخصص بين الصفحات.
* عند حفظ ملفات .html و .css و .js في مجلدات مع هيكل هرمي مخصص، بما في ذلك أنواع ملفات محددة في مجلدات مختلفة. على سبيل المثال، تصدير الشرائح إلى مجلد يعتمد على اسم القسم.
* عند حفظ ملفات CSS و JS في مجلدات منفصلة بشكل افتراضي ثم إضافتها إلى ملف HTML. يتم أيضًا حفظ الصور والخطوط المضمّنة في ملفات منفصلة. ومع ذلك، يمكن تضمينها في ملف HTML (بتنسيق base64). يمكنك حفظ بعض أجزاء الموارد في الملفات وتضمين موارد أخرى في HTML كـ base64.

يمكنك تمامًا الاطلاع على أمثلة PowerPoint إلى HTML في مشروع [Aspose.Slides.WebExtensions](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/) على GitHub. يحتوي هذا المشروع على جزئين: **Examples\SinglePageApp** و **Examples\MultiPageApp**. يمكن العثور على الأمثلة الأخرى المستخدمة في هذه المقالة أيضًا في مستودع GitHub.

### **القوالب**

لتمديد قدرات تصدير HTML بشكل أكبر، نوصي باستخدام نظام قوالب ASP.NET Razor. يمكن استخدام مثيل فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) جنبًا إلى جنب مع مجموعة من القوالب للحصول على مستند HTML كنتيجة للتصدير.

**عرض توضيحي**

في هذا المثال، سنقوم بتصدير النص من عرض إلى HTML. أولًا، دعونا ننشئ القالب:

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
تم حفظ هذا القالب على القرص كـ "shape-template-hello-world.html"، والذي سيتم استخدامه في الخطوة التالية.

في هذا القالب، نقوم بالتكرار على إطارات النص في أشكال العرض لعرض النص. دعونا نولد ملف HTML باستخدام WebDocument ثم نصدر العرض إلى الملف:

``` csharp
using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 150);
    shape.TextFrame.Text = "Hello World";
                
    WebDocumentOptions options = new WebDocumentOptions
    {
        TemplateEngine = new RazorTemplateEngine(), // نحن نعتزم استخدام محرك قوالب Razor. يمكن استخدام محركات قوالب أخرى عن طريق تنفيذ ITemplateEngine  
        OutputSaver = new FileOutputSaver() // يمكن استخدام حفظ نتائج آخر عبر تنفيذ واجهة IOutputSaver
    };
    WebDocument document = new WebDocument(options);

    // إضافة "الإدخال" للوثيقة - ما المصدر الذي سيستخدم لتوليد مستند HTML
    document.Input
        .AddTemplate<Presentation>( // القالب سيكون لديه Presentation ككائن "نموذج" (Model.Object) 
        "index", // مفتاح القالب - مطلوب من قبل محرك القالب لمطابقة الكائن (Presentation) مع القالب المحمل من القرص ("shape-template-hello-world.html")  
        @"custom-templates\shape-template-hello-world.html"); // القالب الذي أنشأناه سابقًا
                
    // إضافة الإخراج - كيف سيبدو مستند HTML الناتج عند تصديره إلى القرص
    document.Output.Add(
        "hello-world.html", // مسار ملف الإخراج
        "index", // مفتاح القالب الذي سيتم استخدامه لهذا الملف (قمنا بتعيينه في عبارة سابقة)  
        pres); // مثيل Model.Object الفعلي 
                
    document.Save();
}
```

على سبيل المثال، نريد إضافة أنماط CSS إلى نتيجة التصدير لتغيير لون النص إلى الأحمر. دعونا نضيف قالب CSS:

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

دعونا نضيف الإشارة إلى الأنماط داخل القالب وفئة "text":
``` html
<!DOCTYPE html>
<head>
    <link rel="stylesheet" type="text/css" href="hello-world.css" />
</head>
...
</html>
```

### **قوالب افتراضية**

يوفر WebExtensions مجموعتين من القوالب الأساسية لتصدير العروض إلى HTML:
* صفحة واحدة: يتم تصدير كل محتوى العرض إلى ملف HTML واحد. يتم تصدير جميع الموارد الأخرى (الصور، الخطوط، الأنماط، إلخ) إلى ملفات منفصلة.
* صفحات متعددة: يتم تصدير كل شريحة عرض إلى ملف HTML فردي. المنطق الافتراضي لتصدير الموارد هو نفسه كما في الصفحة الواحدة.

يمكن استخدام فصل `PresentationExtensions` لتبسيط عملية تصدير العرض باستخدام القوالب. يحتوي فصل `PresentationExtensions` على مجموعة من طرق التمديد لفصل Presentation. لتصدير عرض إلى صفحة واحدة، ما عليك سوى تضمين مساحة أسماء Aspose.Slides.WebExtensions واستدعاء طريقتين. الطريقة الأولى، `ToSinglePageWebDocument`، تنشئ مثيل `WebDocument`. الطريقة الثانية تحفظ مستند HTML:

``` csharp
using (Presentation pres = new Presentation("demo.pptx"))
{
    WebDocument document = pres.ToSinglePageWebDocument("templates\\single-page", @"single-page-output");
    document.Save();
}
```

يمكن أن تأخذ طريقة ToSinglePageWebDocument معلمتين: مجلد القوالب ومجلد التصدير.

لتصدير العرض إلى صفحة متعددة، استخدم طريقة ToMultiPageWebDocument مع نفس المعلمات:

``` csharp
using (Presentation pres = new Presentation("demo.pptx"))
{
    WebDocument document = pres.ToMultiPageWebDocument("templates\\multi-page", @"mutil-page-output");
    document.Save();
}
```

في WebExtensions، يتم ربط كل قالب مستخدم لتوليد العلامات بمفتاح. يمكن استخدام المفتاح في القوالب. على سبيل المثال، في توجيه @Include، يمكنك إدراج قالب معين إلى آخر عن طريق المفتاح.

يمكننا توضيح الإجراء في مثال استخدام قالب جزء النص داخل قالب الفقرة. يمكنك العثور على المثال في مشروع Aspose.Slides.WebExtensions: [Templates\common\paragraph.html](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/Templates/common/paragraph.html). لرسم الأجزاء في فقرة، نقوم بالتكرار عليها باستخدام توجيه @foreach لمحرك Razor:

``` html
@foreach (Portion portion in contextObject.Portions) 
{ 
    var subModel = Model.SubModel(portion);
    subModel.Local.Put("parentTextFrame", parentTextFrame);
    subModel.Local.Put("tableContent", tableContentFlag);
	@Raw(Include("portion", subModel).ToString().Replace(Environment.NewLine, ""));
}
```

يمتلك الجزء قالباً خاص به [portion.html](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/Templates/common/portion.html) ويتم توليد نموذج له. سيتم إضافة ذلك النموذج إلى القالب الناتج paragraph.html:
``` html
@Raw(Include("portion", subModel).ToString().Replace(Environment.NewLine, ""));
```

لكل نوع شكل، نستخدم قالبًا مخصصًا، يتم إضافته إلى مجموعة القوالب العامة من مشروع Aspose.Slides.WebExtensions. يتم دمج القوالب في طرق ToSinglePageWebDocument و ToMultiPageWebDocument لتقديم النتيجة النهائية. هذه هي القوالب الشائعة المستخدمة في كل من الصفحات المفردة والمتعددة:

-templates
+-common
  ¦ +-scripts: نصوص JavaScript لتحريك انتقالات الشريحة، على سبيل المثال.
  ¦ +-styles: أنماط CSS الشائعة.
  +-multi-page: قوالب الفهرس، والقائمة، والشرائح للإخراج متعدد الصفحات.
  +-single-page: قوالب الفهرس، والشرائح للإخراج صفحة واحدة.

يمكنك معرفة كيفية ربط الجزء الشائع لجميع القوالب في طريقة `PresentationExtensions.AddCommonInputOutput` [هنا](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/PresentationExtensions.cs).

### **تخصيص القالب الافتراضي**

يمكنك تعديل أي عنصر في قالب النموذج الشائع. على سبيل المثال، قد تقرر تغيير أنماط تنسيق الجدول ولكن ترغب في أن تظل جميع الأنماط الأخرى في الصفحة المفردة بدون تغيير.

بشكل افتراضي، يتم استخدام Templates\common\table.html، ويشبه الجدول مظهر الجدول في PowerPoint. دعونا نغير تنسيق الجدول باستخدام أنماط CSS مخصصة:
``` css
.custom-table {
    border: 1px solid black;
}
.custom-table tr:nth-child(even) {background: #CCC}
.custom-table tr:nth-child(odd) {background: #ffb380}
```

يمكننا إنشاء نفس هيكل القوالب المدخلة وملفات الإخراج (كما يتم إنشاؤه) أثناء استدعاء طريقة `PresentationExtensions.ToSinglePageWebDocument`. دعونا نضيف طريقة `ExportCustomTableStyles_AddCommonStructure` لتحقيق ذلك. الفرق بين هذه الطريقة وطريقة `ToSinglePageWebDocument`—لا نحتاج إلى إضافة القالب القياسي للجدول والصفحة الفهرسية الرئيسية (سيتم استبداله لتضمين الإشارة إلى أنماط الجدول المخصصة):

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

دعونا نضيف قالبًا مخصصًا بدلاً من ذلك:

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

    // إعداد القيم العالمية للمستند
    WebDocument document = new WebDocument(options);
    SetupGlobals(document, options, outputPath);

    // إضافة الهيكل الشائع (باستثناء قالب الجدول)
    ExportCustomTableStyles_AddCommonStructure(pres, document, templatesPath, outputPath, options.EmbedImages);
                
    // إضافة قالب الجدول المخصص
    document.Input.AddTemplate<Table>("table", @"custom-templates\table-custom-style.html");
                
    // إضافة أنماط الجدول المخصصة
    document.Input.AddTemplate<Presentation>("table-custom-style", @"custom-templates\styles\table-custom-style.css");
    document.Output.Add(Path.Combine(outputPath, "table-custom-style.css"), "table-custom-style", pres);
                
    // إضافة فهرس مخصص - إنه مجرد نسخة من "index.html" القياسي، لكنه يتضمن إشارة إلى "table-custom-style.css"
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

**ملاحظة** أن قالب الجدول المخصص قد أضيف بنفس المفتاح "table" مثل الجدول القياسي. وبالتالي، يمكنك استبدال قالب افتراضي معين دون إعادة كتابته. يمكنك أيضًا استخدام القوالب من الهيكل الافتراضي بنفس المفاتيح. على سبيل المثال، يمكنك استخدام قالب الفقرة القياسي في قالب الجدول؛ يمكنك أيضًا استبداله بنفس المفتاح.
يمكنك أيضًا استخدام index.html لتضمين الإشارة على أنماط CSS الجدول المخصصة فيه: 

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

يتيح لك WebExtensions تصدير العروض مع انتقالات شرائح متحركة—ما عليك إلا تعيين خاصية `AnimateTransitions` في `WebDocumentOptions` إلى `true`:

``` csharp
WebDocumentOptions options = new WebDocumentOptions
{
    // ... خيارات أخرى
    AnimateTransitions = true
};
```

دعونا ننشئ مشروعًا جديدًا يستخدم Aspose.Slides و Aspose.Slides.WebExtensions لإنشاء عارض HTML لملف PDF مع انتقالات صفحات سلسة متحركة. هنا، نحتاج إلى استخدام ميزة استيراد PDF من Aspose.Slides.

دعونا ننشئ مشروع PdfToPresentationToHtml ونضيف حزمة Aspose.Slides.WebExtensions من NuGet (ستتم إضافة حزمة Aspose.Slides أيضًا كاعتماد):
![حزمة NuGet](screen.png)

نبدأ باستيراد مستند PDF، والذي سيتم تحريكه وتصديره إلى عرض HTML:

``` csharp
using (Presentation pres = new Presentation())
{
    pres.Slides.RemoveAt(0);
    pres.Slides.AddFromPdf("sample.pdf");
}
```

الآن، يمكننا إعداد انتقالات شرائح متحركة (كل شريحة هي صفحة PDF المستوردة). استخدمنا 9 شرائح في مستند PDF النموذجي. دعونا نضيف انتقالات شريحة إلى كل منها (عرض توضيحي أثناء عرض HTML):

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

وأخيرًا، دعونا نصدره إلى HTML باستخدام `WebDocument` مع تعيين خاصية `AnimateTransitions` إلى `true`:

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

مثال كامل على الشيفرة المصدرية:
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

هذا كل ما تحتاجه لإنشاء HTML مع انتقالات صفحات متحركة تم إنشاؤها من مستند PDF. 

* [تحميل ملف HTML النموذجي](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/tree/main/Examples).
* [تحميل المشروع النموذجي](/slides/ar/net/web-extensions/sample.zip).