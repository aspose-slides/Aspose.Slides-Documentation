---
title: New HTML Export System - Aspose.Slides.WebExtensions
type: docs
weight: 240
url: /net/web-extensions/
---


## Introduction

With a new version of WebExtensions system for exporting HTML PowerPoint presentations, it's possible to flexibly customize HTML exporting settings and get any result you need. In the previous Aspose.Slides API versions, the presentation document exported to HTML is represented as an SVG markup with the combinated with an HTML. Each slide is exported as an SVG container. The new WebExtensions version allows to export the whole presentation into an HTML with a set of CSS classes and Javascript animations without using SVG.

The new WebExtensions version provides the unlimited possibilities to configure the resulting export. Here are some use cases of HTML-documents, generated with WebExtensions, based on different requirements:
* using custom CSS styles, animations or override the markup for a certain type of a shape.
* override the document structure,e.g. using custom navigation between pages.
* save .html, .css, .js files into the folders with the customized hierarchy, including the files of one type in the different folders. For example, export slides to the folder based on the section name.
* CSS and JS files are saved into separate folders by default, but it's possible to include them to an HTML file. Images and embedded fonts are also saved into separate files, however they may be included into HTML (in base64 format). It's possible to save some part of resources to the files and to embed other resources into HTML as base64.

You may find examples on HTML export in Aspose.Slides.WebExtensions project, published on GitHub. It includes two projects: "Examples\SinglePageApp" and "Examples\MultiPageApp". The examples used in the article further can be also found in the GitHub repo.

## Templates

In order to extend the possibilities of HTML export further, it is advised to use the ASP.NET Razor template system. The instance of Presentation class (Aspose.Slides API) can be used together with a set of templates to get an HTML-document as the export result.
Let us demonstrate the approach of using Aspose.Slides and WebExtensions. In the example we will export text from presentation to HTML. First, let's create the template:

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
This template will be saved on disk as "shape-template-hello-world.html" to use it in the next step.

In this template, we are iterating text frames in presentation shapes to display the text. Let us generate the HTML file using WebDocument, and export Presentation into the file: 

``` csharp
using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 150);
    shape.TextFrame.Text = "Hello World";
                
    WebDocumentOptions options = new WebDocumentOptions
    {
        TemplateEngine = new RazorTemplateEngine(), // we will use Razor template engine, other template engines can be used by implementing ITemplateEngine  
        OutputSaver = new FileOutputSaver() // other result savers can be used by implementing IOutputSaver interface
    };
    WebDocument document = new WebDocument(options);

    // add document "input" - what source will be used to generate HTML document
    document.Input
        .AddTemplate<Presentation>( // template will have Presentation as a "model" object (Model.Object) 
        "index", // template key - needed by template engine to match an object (Presentation) to the template loaded from disk ("shape-template-hello-world.html")  
        @"custom-templates\shape-template-hello-world.html"); // template we created earlier
                
    // add output - how resulting HTML document will looks like when it will be exported to the disk
    document.Output.Add(
        "hello-world.html", // output file path
        "index", // template key that will be used for this file (we set it in a previous statement)  
        pres); // an actual Model.Object instance 
                
    document.Save();
}
```

For example, we want to include CSS styles into the export in order to change text color to red. Let us add the CSS template:

``` css
.text {
    color: red;
}
```

Now, we will add it into the input and output:

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

Lets us add the reference on the styles to the template and class "text":
``` html
<!DOCTYPE html>
<head>
    <link rel="stylesheet" type="text/css" href="hello-world.css" />
</head>
...
</html>
```

## Default Templates

WebExtensions include two sets of basic templates for exporting presentations:
* single page: all presentation content is exported into one HTML file. All other resources (images, fonts, styles, etc) are exported into separate files.
* multi page: each presentation slide is exported into a separate HTML file. The default logic for exporting resources is the same as in single page. 

PresentationExtensions class can be used to simplify presentation export using templates. PresentationExtensions class includes a set of extension-methods for Presentation class. To export presentation into a single page, just include Aspose.Slides.WebExtensions namespace and call two methods. First method, ToSinglePageWebDocument, creates WebDocument instance and second one - saves HTML-document: 

``` csharp
using (Presentation pres = new Presentation("demo.pptx"))
{
    WebDocument document = pres.ToSinglePageWebDocument("templates\\single-page", @"single-page-output");
    document.Save();
}
```

ToSinglePageWebDocument method has two parameters: templates folder and export folder. 

To export presentation to a multi page, use ToMultiPageWebDocument method with the same parameters:

``` csharp
using (Presentation pres = new Presentation("demo.pptx"))
{
    WebDocument document = pres.ToMultiPageWebDocument("templates\\multi-page", @"mutil-page-output");
    document.Save();
}
```

In WebExtensions, each template used for markup generation is binded to a key. The key can be used in templates. For example, in @Include directive you may insert a certain template to another one by the key.

Let us demonstrate it in the example of text portion template usage inside the paragraph template. You can find the example in Aspose.Slides.WebExtensions project: [Templates\common\paragraph.html](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/Templates/common/paragraph.html). In order to draw each portion in paragraph, they are being iterated using @foreach directive of Razor Engine:

``` html
@foreach (Portion portion in contextObject.Portions) 
{ 
    var subModel = Model.SubModel(portion);
    subModel.Local.Put("parentTextFrame", parentTextFrame);
    subModel.Local.Put("tableContent", tableContentFlag);
	@Raw(Include("portion", subModel).ToString().Replace(Environment.NewLine, ""));
}
```

Portion has its own template [portion.html](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/Templates/common/portion.html), and the model is generated for it, which will be included to the output paragraph.html template then:
``` html
@Raw(Include("portion", subModel).ToString().Replace(Environment.NewLine, ""));
```

For each shape type is used its own template, which is included into a set of common templates from Aspose.Slides.WebExtensions project. Templates are united in ToSinglePageWebDocument and ToMultiPageWebDocument methods to get the final result. Here are common templates, used in both single and multi page:

-templates
+-common
  ¦ +-scripts: javascript scripts for slide transition animations, as instance.
  ¦ +-styles: common CSS styles.
  +-multi-page: index, menu, slide templates for the multi page output.
  +-single-page: index, slide templates for single page output.

Find how the common part is binded for all the templates in PresentationExtensions.AddCommonInputOutput method, [here](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/PresentationExtensions.cs).

## Default Template Customization

It is possible to modify any element in the template of the common model. For example, you would like to change the table formatting styles, but remain all the other styles of single page the same.

By default, Templates\common\table.html [ссылка] is used, and the table has the same appearance as the table in PowerPoint. Let us change table formatting by using custom CSS styles:
``` css
.custom-table {
    border: 1px solid black;
}
.custom-table tr:nth-child(even) {background: #CCC}
.custom-table tr:nth-child(odd) {background: #ffb380}
```

We should create the same structure of input templates and output files, as it is generated while calling PresentationExtensions.ToSinglePageWebDocument method. Let us add ExportCustomTableStyles_AddCommonStructure method for that. The difference between this method and ToSinglePageWebDocument method is that we do not need add the standard template for the table and the main index page (it will be replaced in order to include the reference on the custom table styles):

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

Let us add a custom template instead:

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

    // setup global document values
    WebDocument document = new WebDocument(options);
    SetupGlobals(document, options, outputPath);

    // add common structure (except table template)
    ExportCustomTableStyles_AddCommonStructure(pres, document, templatesPath, outputPath, options.EmbedImages);
                
    // add custom table template
    document.Input.AddTemplate<Table>("table", @"custom-templates\table-custom-style.html");
                
    // add custom table styles
    document.Input.AddTemplate<Presentation>("table-custom-style", @"custom-templates\styles\table-custom-style.css");
    document.Output.Add(Path.Combine(outputPath, "table-custom-style.css"), "table-custom-style", pres);
                
    // add custom index - it's just a copy of the standard "index.html", but includes a reference to "table-custom-style.css"
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

Note, that the custom table template was added with the same “table” key, as the standard table. Thus, it is possible to replace a certain default template without rewriting it. We may also use the templates from the default structure with the same keys. For example, we use a standard paragraph template in the table template. It is also possible to replace it by the key.
We should also use index.html to include the reference on custom table CSS styles into it: 

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

## Create Project from Scratch: Animated Slides Transitions

WebExtensions allows exporting presentations with animated slide transitions. For that, you just need to set true to AnimateTransitions property in WebDocumentOptions:

``` csharp
WebDocumentOptions options = new WebDocumentOptions
{
    // ... other options
    AnimateTransitions = true
};
```

Let us create a new project, which uses Aspose.Slides and Aspose.Slides.WebExtensions for creating HTML-viewer for PDF with a smooth animated page transitions. For that, we need to use the PDF import feature of Aspose.Slides.

Let us create a PdfToPresentationToHtml project and include the Aspose.Slides.WebExtensions nuget package (Aspose.Slides package will be also included as the dependency):
![NuGet Package](screen.png)

We will start from importing the PDF document, which should be animated and exported into an HTML presentation:

``` csharp
using (Presentation pres = new Presentation())
{
    pres.Slides.RemoveAt(0);
    pres.Slides.AddFromPdf("sample.pdf");
}
```

Now we may set up the animated slide transitions (each slide is the imported PDF page). We use 9 slides in the sample PDF document. Let us add slide transitions into each of it, to demonstrate it while viewing HTML:

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

Finally, let us export to HTML by using WebDocument with the AnimateTransitions property set to true:

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

Full source code example:
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

That's all you need to create an HTML with the animated page transitions generated from the PDF document. The sample HTML export can be downloaded [here](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/tree/main/Examples), and the sample project - here [zip](sample.zip).
