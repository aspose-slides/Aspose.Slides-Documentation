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
