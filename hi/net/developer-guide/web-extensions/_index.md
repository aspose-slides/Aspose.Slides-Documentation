---
title: नया HTML निर्यात प्रणाली - Aspose.Slides.WebExtensions
type: docs
weight: 240
url: /hi/net/web-extensions/
keywords:
- वेब एक्सटेंशन
- टेम्प्लेट इंजन
- PowerPoint निर्यात
- OpenDocument निर्यात
- प्रेजेंटेशन निर्यात
- स्लाइड निर्यात
- PPT निर्यात
- PPTX निर्यात
- ODP निर्यात
- PowerPoint से HTML
- OpenDocument से HTML
- प्रेजेंटेशन से HTML
- स्लाइड से HTML
- PPT से HTML
- PPTX से HTML
- ODP से HTML
- .NET
- C#
- Aspose.Slides
description: "टेम्प्लेट, CSS और JS के साथ प्रेजेंटेशनों को HTML में निर्यात करें—कोई SVG नहीं। एकल या बहु-पृष्ठ आउटपुट, संसाधन नियंत्रण, और PPT, PPTX तथा ODP के लिए अनुकूलन सीखें।"
---
## **परिचय**

* पुराने Aspose.Slides API बिल्ड्स में, जब आप PowerPoint को HTML में निर्यात करते हैं, तो परिणामी HTML SVG मार्कअप को HTML के साथ मिलाकर दर्शाया जाता था। प्रत्येक स्लाइड को एक SVG कंटेनर के रूप में निर्यात किया जाता था।  
* नए Aspose.Slides संस्करणों में, जब आप PowerPoint प्रेजेंटेशन को HTML में निर्यात करने के लिए WebExtensions सिस्टम का उपयोग करते हैं, तो आप सर्वश्रेष्ठ परिणाम प्राप्त करने के लिए HTML निर्यात सेटिंग्स को अनुकूलित कर सकते हैं।  

नए WebExtensions सिस्टम का उपयोग करके, आप पूरी प्रेजेंटेशन को HTML में निर्यात कर सकते हैं जिसमें CSS क्लासेस और JavaScript एनिमेशन का सेट होता है (SVG के बिना)। नया निर्यात सिस्टम अनंत विकल्पों और विधियों को भी प्रदान करता है जो निर्यात प्रक्रिया को परिभाषित करते हैं।  

नया WebExtensions सिस्टम इन मामलों और स्थितियों में प्रेजेंटेशन से HTML बनाने के लिए उपयोग किया जाता है:

* कस्टम CSS शैलियों या एनिमेशन का उपयोग करते समय; कुछ प्रकार के आकारों के लिए मार्कअप को ओवरराइड करना।  
* जब दस्तावेज़ संरचना को ओवरराइड किया जाता है, उदाहरण के लिए, पृष्ठों के बीच कस्टम नेविगेशन का उपयोग करना।  
* जब .html, .css, .js फ़ाइलों को कस्टमाइज़्ड पदानुक्रम के साथ फ़ोल्डरों में सहेजा जाता है, जिसमें विभिन्न फ़ोल्डरों में विशिष्ट फ़ाइल प्रकार शामिल होते हैं। उदाहरण के लिए, स्लाइड को सेक्शन नाम के आधार पर फ़ोल्डर में निर्यात करना।  
* जब CSS और JS फ़ाइलों को डिफ़ॉल्ट रूप से अलग फ़ोल्डरों में सहेजा जाता है और फिर उन्हें HTML फ़ाइल में जोड़ा जाता है। छवियाँ और एम्बेडेड फ़ॉन्ट भी अलग फ़ाइलों में सहेजे जाते हैं। हालाँकि, उन्हें HTML फ़ाइल में (base64 प्रारूप में) एम्बेड किया जा सकता है। आप कुछ संसाधनों के भाग को फ़ाइलों में सहेज सकते हैं और अन्य संसाधनों को HTML में base64 के रूप में एम्बेड कर सकते हैं।  

आप PowerPoint to HTML उदाहरणों को [Aspose.Slides.WebExtensions project](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/) में देख सकते हैं। इस प्रोजेक्ट में दो भाग हैं: **Examples\SinglePageApp** और **Examples\MultiPageApp**। इस लेख में उपयोग किए गए अन्य उदाहरण भी GitHub रिपोज़िटरी में पाए जा सकते हैं।  

### **टेम्प्लेट**

HTML निर्यात की क्षमताओं को और विस्तारित करने के लिए, हम अनुशंसा करते हैं कि आप ASP.NET Razor टेम्प्लेट सिस्टम का उपयोग करें। [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास की इंस्टेंस को टेम्प्लेट के सेट के साथ उपयोग करके आप निर्यात परिणाम के रूप में HTML दस्तावेज़ प्राप्त कर सकते हैं।  

**डेमोस्ट्रेशन**

इस उदाहरण में, हम एक प्रेजेंटेशन से टेक्स्ट को HTML में निर्यात करेंगे। सबसे पहले, चलिए टेम्प्लेट बनाते हैं:

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
यह टेम्प्लेट डिस्क पर `"shape-template-hello-world.html"` नाम से सेव किया गया है, जिसे अगले चरण में उपयोग किया जाएगा।  

इस टेम्प्लेट में, हम प्रेजेंटेशन के आकारों में टेक्स्ट फ्रेम को इटरिटेट करके टेक्स्ट प्रदर्शित कर रहे हैं। चलिए WebDocument का उपयोग करके HTML फ़ाइल जेनरेट करते हैं और फिर Presentation को फ़ाइल में निर्यात करते हैं:  

``` csharp
using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 150);
    shape.TextFrame.Text = "Hello World";
                
    WebDocumentOptions options = new WebDocumentOptions
    {
        TemplateEngine = new RazorTemplateEngine(), // हम Razor टेम्प्लेट इंजन का उपयोग करने का इरादा रखते हैं। अन्य टेम्प्लेट इंजन ITemplateEngine को लागू करके उपयोग किए जा सकते हैं  
        OutputSaver = new FileOutputSaver() // अन्य परिणाम सहेजने वाले IOutputSaver इंटरफ़ेस को लागू करके उपयोग किए जा सकते हैं
    };
    WebDocument document = new WebDocument(options);

    // डॉक्यूमेंट "input" जोड़ें - कौन सा स्रोत HTML डॉक्यूमेंट बनाने के लिए उपयोग होगा
    document.Input
        .AddTemplate<Presentation>( // टेम्प्लेट में Presentation को "model" ऑब्जेक्ट (Model.Object) के रूप में होगा 
        "index", // टेम्प्लेट कुंजी - टेम्प्लेट इंजन के लिए आवश्यक है ताकि ऑब्जेक्ट (Presentation) को डिस्क से लोड किए गए टेम्प्लेट ("shape-template-hello-world.html") से मिलाया जा सके  
        @"custom-templates\shape-template-hello-world.html"); // पहले बनाए गए टेम्प्लेट
                
    // आउटपुट जोड़ें - जब निर्यात किया जाए तो परिणामी HTML डॉक्यूमेंट कैसे दिखेगा
    document.Output.Add(
        "hello-world.html", // आउटपुट फ़ाइल पथ
        "index", // टेम्प्लेट कुंजी जो इस फ़ाइल के लिए उपयोग होगी (हमने इसे पहले कथन में सेट किया था)  
        pres); // एक वास्तविक Model.Object इंस्टेंस 
                
    document.Save();
}
```

उदाहरण के लिए, हम निर्यात परिणाम में टेक्स्ट का रंग लाल करने के लिए CSS शैलियाँ जोड़ना चाहते हैं। चलिए CSS टेम्प्लेट जोड़ते हैं:  

``` css
.text {
    color: red;
}
```

अब, हम इसे इनपुट और आउटपुट में जोड़ते हैं:  

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

चलिए टेम्प्लेट और क्लास `"text"` पर शैलियों के संदर्भ को जोड़ते हैं:  

``` html
<!DOCTYPE html>
<head>
    <link rel="stylesheet" type="text/css" href="hello-world.css" />
</head>
...
</html>
```

### **डिफ़ॉल्ट टेम्प्लेट**

WebExtensions प्रस्तुतियों को HTML में निर्यात करने के लिए दो सेट बेसिक टेम्प्लेट प्रदान करता है:
* Single-page: सभी प्रेजेंटेशन सामग्री को एक ही HTML फ़ाइल में निर्यात किया जाता है। अन्य सभी संसाधन (छवियाँ, फ़ॉन्ट, शैलियाँ आदि) को अलग फ़ाइलों में निर्यात किया जाता है।  
* Multi-page: प्रत्येक प्रेजेंटेशन स्लाइड को एक व्यक्तिगत HTML फ़ाइल में निर्यात किया जाता है। संसाधनों को निर्यात करने की डिफ़ॉल्ट लॉजिक single-page के समान है।  

`PresentationExtensions` क्लास टेम्प्लेट का उपयोग करके प्रेजेंटेशन निर्यात प्रक्रिया को सरल बनाने के लिए उपयोग किया जा सकता है। `PresentationExtensions` क्लास में Presentation क्लास के लिए कई एक्सटेंशन मेथड्स होते हैं। एक प्रेजेंटेशन को single-page में निर्यात करने के लिए, बस Aspose.Slides.WebExtensions नेमस्पेस को इंक्लूड करें और दो मेथड्स कॉल करें। पहला मेथड, `ToSinglePageWebDocument`, एक `WebDocument` इंस्टेंस बनाता है। दूसरा मेथड HTML दस्तावेज़ को सहेजता है:  

``` csharp
using (Presentation pres = new Presentation("demo.pptx"))
{
    WebDocument document = pres.ToSinglePageWebDocument("templates\\single-page", @"single-page-output");
    document.Save();
}
```

`ToSinglePageWebDocument` मेथड दो पैरामीटर ले सकता है: टेम्प्लेट फ़ोल्डर और निर्यात फ़ोल्डर।  

मल्टी‑पेज निर्यात के लिए, समान पैरामीटर के साथ `ToMultiPageWebDocument` मेथड का उपयोग करें:  

``` csharp
using (Presentation pres = new Presentation("demo.pptx"))
{
    WebDocument document = pres.ToMultiPageWebDocument("templates\\multi-page", @"mutil-page-output");
    document.Save();
}
```

WebExtensions में, मार्कअप जेनरेशन के लिए उपयोग किए गए प्रत्येक टेम्प्लेट को एक कुंजी से बाँधा जाता है। इस कुंजी का उपयोग टेम्प्लेट में किया जा सकता है। उदाहरण के लिए, @Include निर्देश में आप किसी कुंजी द्वारा एक टेम्प्लेट को दूसरे में सम्मिलित कर सकते हैं।  

हम इस प्रक्रिया को पैराग्राफ टेम्प्लेट के अंदर टेक्स्ट पोर्शन टेम्प्लेट उपयोग के उदाहरण से प्रदर्शित कर सकते हैं। आप इस उदाहरण को Aspose.Slides.WebExtensions प्रोजेक्ट में पा सकते हैं: [Templates\common\paragraph.html](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/Templates/common/paragraph.html)। पैराग्राफ में पोर्शन को ड्रॉ करने के लिए, हम Razor Engine के @foreach निर्देश का उपयोग करके उन्हें इटरिटेट करते हैं:  

``` html
@foreach (Portion portion in contextObject.Portions) 
{ 
    var subModel = Model.SubModel(portion);
    subModel.Local.Put("parentTextFrame", parentTextFrame);
    subModel.Local.Put("tableContent", tableContentFlag);
	@Raw(Include("portion", subModel).ToString().Replace(Environment.NewLine, ""));
}
```

पोर्शन का अपना टेम्प्लेट [portion.html](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/Templates/common/portion.html) है और इसके लिए एक मॉडल जेनरेट किया जाता है। वह मॉडल आउटपुट paragraph.html टेम्प्लेट में जोड़ा जाएगा:  

``` html
@Raw(Include("portion", subModel).ToString().Replace(Environment.NewLine, ""));
```

प्रत्येक आकार प्रकार के लिए, हम एक कस्टम टेम्प्लेट का उपयोग करते हैं, जिसे Aspose.Slides.WebExtensions प्रोजेक्ट के सामान्य टेम्प्लेट सेट में जोड़ा जाता है। टेम्प्लेट्स को `ToSinglePageWebDocument` और `ToMultiPageWebDocument` मेथड्स में मिलाकर अंतिम परिणाम प्रदान किया जाता है। यह सामान्य टेम्प्लेट्स दोनों single और multi-page में उपयोग किए जाते हैं:

- templates  
+-common  
  ¦ +-scripts: स्लाइड ट्रांज़िशन एनीमेशन के लिए जावास्क्रिप्ट स्क्रिप्ट्स।  
  ¦ +-styles: सामान्य CSS शैलियाँ।  
  +-multi-page: मल्टी‑पेज आउटपुट के लिए index, menu, slide टेम्प्लेट्स।  
  +-single-page: सिंगल‑पेज आउटपुट के लिए index, slide टेम्प्लेट्स।  

आप `PresentationExtensions.AddCommonInputOutput` मेथड में सभी टेम्प्लेट्स के लिए सामान्य भाग कैसे बंधा है, इसे [यहाँ](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/PresentationExtensions.cs) देख सकते हैं।  

### **डिफ़ॉल्ट टेम्प्लेट अनुकूलन**

आप सामान्य मॉडल के टेम्प्लेट में किसी भी तत्व को संशोधित कर सकते हैं। उदाहरण के लिए, आप तालिका फ़ॉर्मेटिंग शैलियों को बदलना चाह सकते हैं, जबकि सिंगल‑पेज की अन्य शैलियों को अपरिवर्तित रखना चाहते हैं।  

डिफ़ॉल्ट रूप से, `Templates\common\table.html` उपयोग किया जाता है, और तालिका का रूप PowerPoint की तालिका जैसा ही रहता है। चलिए कस्टम CSS शैलियों का उपयोग करके तालिका फ़ॉर्मेटिंग बदलते हैं:  

``` css
.custom-table {
    border: 1px solid black;
}
.custom-table tr:nth-child(even) {background: #CCC}
.custom-table tr:nth-child(odd) {background: #ffb380}
```

हम `PresentationExtensions.ToSinglePageWebDocument` मेथड को कॉल करते समय इनपुट टेम्प्लेट्स और आउटपुट फ़ाइलों की वही संरचना बना सकते हैं। इसके लिए `ExportCustomTableStyles_AddCommonStructure` मेथड जोड़ते हैं। यह मेथड `ToSinglePageWebDocument` मेथड से अलग है—हमें तालिका और मुख्य index पेज के मानक टेम्प्लेट को जोड़ने की आवश्यकता नहीं है (यह कस्टम तालिका शैलियों के संदर्भ को शामिल करने के लिए बदल दिया जाएगा):  

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

अब एक कस्टम टेम्प्लेट जोड़ते हैं:  

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

    // वैश्विक दस्तावेज़ मान सेट करें
    WebDocument document = new WebDocument(options);
    SetupGlobals(document, options, outputPath);

    // सामान्य संरचना जोड़ें (टेबल टेम्प्लेट को छोड़कर)
    ExportCustomTableStyles_AddCommonStructure(pres, document, templatesPath, outputPath, options.EmbedImages);
                
    // कस्टम टेबल टेम्प्लेट जोड़ें
    document.Input.AddTemplate<Table>("table", @"custom-templates\table-custom-style.html");
                
    // कस्टम टेबल शैलियाँ जोड़ें
    document.Input.AddTemplate<Presentation>("table-custom-style", @"custom-templates\styles\table-custom-style.css");
    document.Output.Add(Path.Combine(outputPath, "table-custom-style.css"), "table-custom-style", pres);
                
    // कस्टम इंडेक्स जोड़ें - यह मानक "index.html" की केवल एक प्रतिलिपि है, लेकिन
    // "table-custom-style.css" का संदर्भ शामिल करता है
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

**Note** कस्टम तालिका टेम्प्लेट को उसी “table” कुंजी के साथ जोड़ा गया है जैसा मानक तालिका में है। इसलिए आप किसी विशिष्ट डिफ़ॉल्ट टेम्प्लेट को पुनः लिखे बिना बदल सकते हैं। आप डिफ़ॉल्ट संरचना के टेम्प्लेट्स को समान कुंजियों के साथ भी उपयोग कर सकते हैं। उदाहरण के तौर पर, आप तालिका टेम्प्लेट में मानक पैराग्राफ टेम्प्लेट का उपयोग कर सकते हैं; आप इसे कुंजी द्वारा भी बदल सकते हैं।  

आप `index.html` को भी कस्टम तालिका CSS शैलियों के संदर्भ को शामिल करने के लिए उपयोग कर सकते हैं:  

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

## **शुरू से प्रोजेक्ट बनाएँ: एनिमेटेड स्लाइड ट्रांज़िशन**

WebExtensions आपको एनिमेटेड स्लाइड ट्रांज़िशन के साथ प्रेजेंटेशन निर्यात करने की अनुमति देता है—केवल आपको `WebDocumentOptions` में `AnimateTransitions` प्रॉपर्टी को `true` सेट करना है:  

``` csharp
WebDocumentOptions options = new WebDocumentOptions
{
    // ... अन्य विकल्प
    AnimateTransitions = true
};
```

चलिए एक नया प्रोजेक्ट बनाते हैं जो Aspose.Slides और Aspose.Slides.WebExtensions का उपयोग करके PDF के लिए HTML‑वैयरर बनाता है जिसमें स्मूथ एनिमेटेड पेज ट्रांज़िशन होते हैं। यहाँ हमें Aspose.Slides की PDF इम्पोर्ट फीचर का उपयोग करना होगा।  

`PdfToPresentationToHtml` प्रोजेक्ट बनाकर Aspose.Slides.WebExtensions NuGet पैकेज जोड़ें (Aspose.Slides पैकेज भी निर्भरता के रूप में जोड़ा जाएगा):  
![न्यूजेट पैकेज](screen.png)

हम PDF डॉक्यूमेंट को इम्पोर्ट करके शुरू करते हैं, जिसे एनीमेट किया जाएगा और HTML प्रेजेंटेशन में निर्यात किया जाएगा:  

``` csharp
using (Presentation pres = new Presentation())
{
    pres.Slides.RemoveAt(0);
    pres.Slides.AddFromPdf("sample.pdf");
}
```

अब, हम एनिमेटेड स्लाइड ट्रांज़िशन सेट कर सकते हैं (प्रत्येक स्लाइड आयातित PDF पेज है)। हमने सैंपल PDF दस्तावेज़ में 9 स्लाइड्स उपयोग की हैं। चलिए प्रत्येक स्लाइड में ट्रांज़िशन जोड़ते हैं (HTML देखते समय डेमॉन्स्ट्रेशन):  

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

अंत में, `WebDocument` का उपयोग करके इसे HTML में निर्यात करते हैं, जिसमें `AnimateTransitions` प्रॉपर्टी `true` पर सेट है:  

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

पूरा स्रोत कोड उदाहरण:  
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

बस इतना ही आपको PDF दस्तावेज़ से उत्पन्न एनिमेटेड पेज ट्रांज़िशन के साथ HTML बनाने के लिए चाहिए।  

* [सैंपल HTML फ़ाइल डाउनलोड करें](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/tree/main/Examples).  
* [सैंपल प्रोजेक्ट डाउनलोड करें](/slides/hi/net/web-extensions/sample.zip).