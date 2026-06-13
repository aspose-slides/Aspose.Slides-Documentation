---
title: سیستم جدید صادرات HTML - Aspose.Slides.WebExtensions
type: docs
weight: 240
url: /fa/net/web-extensions/
keywords:
- افزونه وب
- موتور قالب
- صادرات PowerPoint
- صادرات OpenDocument
- صادرات ارائه
- صادرات اسلاید
- صادرات PPT
- صادرات PPTX
- صادرات ODP
- PowerPoint به HTML
- OpenDocument به HTML
- ارائه به HTML
- اسلاید به HTML
- PPT به HTML
- PPTX به HTML
- ODP به HTML
- .NET
- C#
- Aspose.Slides
description: "ارائه‌ها را با قالب‌ها، CSS و JS به HTML صادر کنید — بدون SVG. خروجی تک‌صفحه یا چندصفحه، کنترل منابع و سفارشی‌سازی برای PPT، PPTX و ODP را بیاموزید."
---
## **معرفی**

* در ساخت‌های قدیمی Aspose.Slides API، هنگام صادر کردن PowerPoint به HTML، HTML تولید شده به صورت نشانه‌گذاری SVG ترکیب‌شده با HTML نمایش داده می‌شد. هر اسلاید به‌عنوان یک کانتینر SVG صادر می‌شد.  
* در نسخه‌های جدید Aspose.Slides، وقتی از سیستم WebExtensions برای صادر کردن ارائه‌های PowerPoint به HTML استفاده می‌کنید، می‌توانید تنظیمات صادرات HTML را برای دستیابی به بهترین نتایج سفارشی کنید.  

با استفاده از سیستم جدید WebExtensions، می‌توانید یک ارائه کامل را به HTML صادر کنید همراه با مجموعه‌ای از کلاس‌های CSS و انیمیشن‌های JavaScript (بدون SVG). سیستم جدید صادرات همچنین تعداد نامحدودی گزینه و متد را برای تعریف فرآیند صادرات فراهم می‌کند.  

سیستم WebExtensions برای تولید HTML از ارائه‌ها در موارد و رویدادهای زیر مورد استفاده قرار می‌گیرد:

* هنگام استفاده از سبک‌ها یا انیمیشن‌های CSS سفارشی؛ بازنویسی نشانه‌گذاری برای انواع خاصی از شکل‌ها.  
* هنگام بازنویسی ساختار سند، مثلاً استفاده از ناوبری سفارشی بین صفحات.  
* هنگام ذخیرهٔ فایل‌های .html، .css، .js در پوشه‌هایی با سلسله‌مراتب سفارشی، شامل قرار دادن نوع خاصی از فایل‌ها در پوشه‌های متفاوت. به عنوان مثال، صادر کردن اسلایدها به پوشه‌ای بر اساس نام بخش.  
* هنگام ذخیرهٔ فایل‌های CSS و JS به‌صورت پیش‌فرض در پوشه‌های جداگانه و سپس افزودن آن‌ها به یک فایل HTML. تصاویر و فونت‌های توکار نیز در فایل‌های جداگانه ذخیره می‌شوند. با این حال، می‌توانند به‌صورت base64 در یک فایل HTML تعبیه شوند. شما می‌توانید برخی از قسمت‌های منابع را در فایل‌ها ذخیره کنید و سایر منابع را به‌صورت base64 در HTML جاسازی کنید.  

می‌توانید مثال‌های PowerPoint به HTML را در پروژه [Aspose.Slides.WebExtensions project](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/) در GitHub ببینید. این پروژه شامل ۲ بخش است: **Examples\SinglePageApp** و **Examples\MultiPageApp**. سایر مثال‌های استفاده‌شده در این مقاله نیز در مخزن GitHub موجود هستند.  

### **قالب‌ها**

برای گسترش بیشتر قابلیت‌های صادرات HTML، توصیه می‌کنیم از سیستم قالب Razor در ASP.NET استفاده کنید. نمونهٔ کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) می‌تواند همراه با مجموعه‌ای از قالب‌ها برای دریافت یک سند HTML به‌عنوان نتیجهٔ صادرات استفاده شود.  

**نمایش**

در این مثال، متن یک ارائه را به HTML صادر می‌کنیم. ابتدا قالب را ایجاد می‌کنیم:

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
این قالب بر روی دیسک به‌نام «shape-template-hello-world.html» ذخیره می‌شود و در گام بعدی استفاده خواهد شد.  

در این قالب، فریم‌های متنی در شکل‌های ارائه را برای نمایش متن تکرار می‌کنیم. فایل HTML را با استفاده از WebDocument تولید کرده سپس Presentation را به فایل صادر می‌کنیم:

``` csharp
using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 150);
    shape.TextFrame.Text = "Hello World";
                
    WebDocumentOptions options = new WebDocumentOptions
    {
        TemplateEngine = new RazorTemplateEngine(), // ما قصد داریم از موتور قالب Razor استفاده کنیم. می‌توان از سایر موتورهای قالب با پیاده‌سازی ITemplateEngine استفاده کرد  
        OutputSaver = new FileOutputSaver() // می‌توان سایر ذخیره‌کنندگان نتایج را با پیاده‌سازی رابط IOutputSaver استفاده کرد
    };
    WebDocument document = new WebDocument(options);

    // اضافه کردن سند "input" - منبعی که برای تولید سند HTML استفاده خواهد شد
    document.Input
        .AddTemplate<Presentation>( // قالب، شیء Presentation را به عنوان شیء "model" (Model.Object) خواهد داشت 
        "index", // کلید قالب - برای موتور قالب لازم است تا یک شی (Presentation) را با قالب بارگذاری‌شده از دیسک ("shape-template-hello-world.html") مطابقت دهد  
        @"custom-templates\shape-template-hello-world.html"); // قالبی که قبلاً ایجاد کردیم
                
    // اضافه کردن خروجی - نحوهٔ نمایش سند HTML نهایی هنگام صادر شدن به دیسک
    document.Output.Add(
        "hello-world.html", // مسیر فایل خروجی
        "index", // کلید قالبی که برای این فایل استفاده خواهد شد (ما آن را در عبارت قبلی تنظیم کردیم)  
        pres); // یک نمونه واقعی از Model.Object 
                
    document.Save();
}
```

به‌عنوان مثال، می‌خواهیم سبک‌های CSS را به نتیجهٔ صادرات اضافه کنیم تا رنگ متن را به قرمز تغییر دهیم. قالب CSS را اضافه می‌کنیم:

``` css
.text {
    color: red;
}
```

سپس آن را به ورودی و خروجی می‌افزاییم:

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

مرجع سبک‌ها را به قالب و کلاس «text» اضافه می‌کنیم:
``` html
<!DOCTYPE html>
<head>
    <link rel="stylesheet" type="text/css" href="hello-world.css" />
</head>
...
</html>
```

### **قالب‌های پیش‌فرض**

WebExtensions دو مجموعه قالب پایه برای صادرات ارائه‌ها به HTML فراهم می‌کند:
* صفحهٔ تک‌صفحه‌ای: تمام محتوای ارائه به یک فایل HTML صادر می‌شود. سایر منابع (تصاویر، فونت‌ها، سبک‌ها و غیره) به فایل‌های جداگانه صادر می‌شوند.  
* چندصفحه‌ای: هر اسلاید ارائه به یک فایل HTML جداگانه صادر می‌شود. منطق پیش‌فرض برای صادرات منابع همانند حالت تک‌صفحه‌ای است.  

کلاس `PresentationExtensions` می‌تواند فرآیند صادرات ارائه را با استفاده از قالب‌ها ساده کند. این کلاس شامل مجموعه‌ای از متدهای افزونه برای کلاس Presentation است. برای صادرات یک ارائه به تک‌صفحه، کافی است فضای نام Aspose.Slides.WebExtensions را وارد کرده و دو متد را فراخوانی کنید. اولین متد، `ToSinglePageWebDocument`، یک نمونهٔ `WebDocument` ایجاد می‌کند. متد دوم سند HTML را ذخیره می‌کند:

``` csharp
using (Presentation pres = new Presentation("demo.pptx"))
{
    WebDocument document = pres.ToSinglePageWebDocument("templates\\single-page", @"single-page-output");
    document.Save();
}
```

متد ToSinglePageWebDocument می‌تواند دو پارامتر دریافت کند: پوشهٔ قالب‌ها و پوشهٔ صادرات.  

برای صادرات ارائه به چندصفحه، از متد ToMultiPageWebDocument با همان پارامترها استفاده کنید:

``` csharp
using (Presentation pres = new Presentation("demo.pptx"))
{
    WebDocument document = pres.ToMultiPageWebDocument("templates\\multi-page", @"mutil-page-output");
    document.Save();
}
```

در WebExtensions، هر قالبی که برای تولید نشانه‌گذاری استفاده می‌شود به یک کلید وابسته است. این کلید می‌تواند در قالب‌ها استفاده شود. برای مثال، در دستور @Include می‌توانید یک قالب خاص را با کلید به قالب دیگری اضافه کنید.  

می‌توانیم این فرآیند را در مثال استفاده از قالب بخش متن داخل قالب پاراگراف نشان دهیم. می‌توانید مثال را در پروژه Aspose.Slides.WebExtensions پیدا کنید: [Templates\common\paragraph.html](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/Templates/common/paragraph.html). برای رسم بخش‌ها در یک پاراگراف، آن‌ها را با دستور @foreach موتور Razor مرور می‌کنیم:

``` html
@foreach (Portion portion in contextObject.Portions) 
{ 
    var subModel = Model.SubModel(portion);
    subModel.Local.Put("parentTextFrame", parentTextFrame);
    subModel.Local.Put("tableContent", tableContentFlag);
	@Raw(Include("portion", subModel).ToString().Replace(Environment.NewLine, ""));
}
```

بخش دارای قالب اختصاصی خود به نام [portion.html](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/Templates/common/portion.html) است و یک مدل برای آن تولید می‌شود. آن مدل به قالب خروجی paragraph.html اضافه می‌شود:
``` html
@Raw(Include("portion", subModel).ToString().Replace(Environment.NewLine, ""));
```

برای هر نوع شکل، از قالب سفارشی استفاده می‌کنیم که به مجموعهٔ کلی قالب‌ها از پروژه Aspose.Slides.WebExtensions اضافه می‌شود. قالب‌ها در متدهای ToSinglePageWebDocument و ToMultiPageWebDocument ترکیب می‌شوند تا نتیجهٔ نهایی ارائه شود. این‌ها قالب‌های مشترک استفاده‌شده در هر دو حالت تک‌صفحه و چندصفحه هستند:

- templates  
+-common  
  ¦ +-scripts: اسکریپت‌های جاوااسکریپت برای انیمیشن‌های انتقال اسلاید، به‌عنوان مثال.  
  ¦ +-styles: سبک‌های CSS مشترک.  
  +-multi-page: قالب‌های index، منو، اسلاید برای خروجی چندصفحه‌ای.  
  +-single-page: قالب‌های index، اسلاید برای خروجی تک‌صفحه‌ای.  

می‌توانید ببینید بخش مشترک چگونه برای تمام قالب‌ها در متد `PresentationExtensions.AddCommonInputOutput` [اینجا](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/PresentationExtensions.cs) باند می‌شود.  

### **سفارشی‌سازی قالب پیش‌فرض**

می‌توانید هر عنصر در قالب مدل مشترک را تغییر دهید. به‌عنوان مثال، ممکن است بخواهید سبک‌های قالب‌بندی جدول را تغییر دهید اما سایر سبک‌های صفحهٔ تک‌صفحه‌ای همان‌گونه بمانند.  

به‌طور پیش‌فرض، قالب Templates\common\table.html استفاده می‌شود و جدول همان ظاهر PowerPoint را دارد. جدول را با استفاده از سبک‌های CSS سفارشی تغییر دهیم:
``` css
.custom-table {
    border: 1px solid black;
}
.custom-table tr:nth-child(even) {background: #CCC}
.custom-table tr:nth-child(odd) {background: #ffb380}
```

می‌توانیم همان ساختار قالب‌های ورودی و فایل‌های خروجی (همان‌طور که تولید می‌شود) ایجاد کنیم و متد `PresentationExtensions.ToSinglePageWebDocument` را صدا بزنیم. متد `ExportCustomTableStyles_AddCommonStructure` را برای این کار اضافه می‌کنیم. تفاوت این متد با `ToSinglePageWebDocument` این است که نیازی به افزودن قالب استاندارد جدول و صفحهٔ اصلی index نداریم (به‌جای آن مرجع سبک‌های جدول سفارشی را اضافه می‌کنیم):

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

به‌جای آن یک قالب سفارشی اضافه می‌کنیم:

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

    // تنظیم مقادیر کلی سند
    WebDocument document = new WebDocument(options);
    SetupGlobals(document, options, outputPath);

    // اضافه کردن ساختار مشترک (به جز قالب جدول)
    ExportCustomTableStyles_AddCommonStructure(pres, document, templatesPath, outputPath, options.EmbedImages);
                
    // اضافه کردن قالب سفارشی جدول
    document.Input.AddTemplate<Table>("table", @"custom-templates\table-custom-style.html");
                
    // اضافه کردن سبک‌های سفارشی جدول
    document.Input.AddTemplate<Presentation>("table-custom-style", @"custom-templates\styles\table-custom-style.css");
    document.Output.Add(Path.Combine(outputPath, "table-custom-style.css"), "table-custom-style", pres);
                
    // اضافه کردن ایندکس سفارشی - این فقط یک کپی از "index.html" استاندارد است، اما شامل مرجع به "table-custom-style.css" می‌شود
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

**نکته** این است که قالب جدول سفارشی با همان کلید «table» که قالب استاندارد داشت اضافه شد. بنابراین می‌توانید یک قالب پیش‌فرض خاص را بدون بازنویسی جایگزین کنید. همچنین می‌توانید از قالب‌های ساختار پیش‌فرض با همان کلیدها استفاده کنید. به‌عنوان مثال، می‌توانید یک قالب پاراگراف استاندارد را در قالب جدول استفاده کنید؛ یا آن را با کلید جایگزین کنید.  
همچنین می‌توانید از index.html برای افزودن مرجع به سبک‌های CSS جدول سفارشی استفاده کنید:

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

## **ایجاد پروژه از صفر: انتقال‌های اسلایدهای متحرک**

WebExtensions به شما اجازه می‌دهد ارائه‌ها را با انتقال‌های اسلاید متحرک صادر کنید—فقط کافی است خصوصیت `AnimateTransitions` در `WebDocumentOptions` را به `true` تنظیم کنید:

``` csharp
WebDocumentOptions options = new WebDocumentOptions
{
    // ... گزینه‌های دیگر
    AnimateTransitions = true
};
```

یک پروژه جدید ایجاد کنید که از Aspose.Slides و Aspose.Slides.WebExtensions برای ساخت یک مرورگر HTML برای PDF با انتقال‌های صفحهٔ نرم‌متن استفاده می‌کند. در اینجا نیاز به استفاده از قابلیت وارد کردن PDF در Aspose.Slides داریم.  

یک پروژه PdfToPresentationToHtml ایجاد کنید و بسته NuGet Aspose.Slides.WebExtensions را اضافه کنید (پکیج Aspose.Slides نیز به‌عنوان وابستگی اضافه خواهد شد):
![NuGet Package](screen.png)

با وارد کردن سند PDF شروع می‌کنیم که به‌صورت متحرک و به یک ارائهٔ HTML صادر می‌شود:

``` csharp
using (Presentation pres = new Presentation())
{
    pres.Slides.RemoveAt(0);
    pres.Slides.AddFromPdf("sample.pdf");
}
```

حالا می‌توانیم انتقال‌های اسلاید متحرک را تنظیم کنیم (هر اسلاید صفحهٔ PDF وارد شده است). در سند نمونه PDF ما ۹ اسلاید استفاده شده است. انتقال‌های اسلاید را به هر یک از آن‌ها اضافه می‌کنیم (نمایش هنگام مرور HTML):

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

در نهایت، با `WebDocument` و خصوصیت `AnimateTransitions` برابر `true` آن را به HTML صادر می‌کنیم:

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

مثال کامل کد منبع:
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

این تمام موردی است که برای ایجاد HTML با انتقال‌های صفحهٔ متحرک تولید‌شده از سند PDF نیاز دارید.  

* [Download sample HTML file](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/tree/main/Examples).  
* [Download sample project](/slides/fa/net/web-extensions/sample.zip).