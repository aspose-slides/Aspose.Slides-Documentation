---
title: Νέο Σύστημα Εξαγωγής HTML - Aspose.Slides.WebExtensions
type: docs
weight: 240
url: /el/net/web-extensions/
keywords:
- επέκταση ιστού
- μηχανή προτύπων
- εξαγωγή PowerPoint
- εξαγωγή OpenDocument
- εξαγωγή παρουσίασης
- εξαγωγή διαφάνειας
- εξαγωγή PPT
- εξαγωγή PPTX
- εξαγωγή ODP
- PowerPoint σε HTML
- OpenDocument σε HTML
- παρουσίαση σε HTML
- διαφάνεια σε HTML
- PPT σε HTML
- PPTX σε HTML
- ODP σε HTML
- .NET
- C#
- Aspose.Slides
description: "Εξάγετε παρουσιάσεις σε HTML με πρότυπα, CSS και JS—χωρίς SVG. Μάθετε για έξοδο μονής ή πολλαπλής σελίδας, έλεγχο πόρων και προσαρμογή για PPT, PPTX και ODP."
---
## **Εισαγωγή**

* Στις παλιές εκδόσεις του Aspose.Slides API, όταν εξάγετε ένα PowerPoint σε HTML, το παραγόμενο HTML εμφανιζόταν ως σήμανση SVG συνδυασμένη με HTML. Κάθε διαφάνεια εξάγονταν ως ένα κοντέινερ SVG. 
* Στις νέες εκδόσεις του Aspose.Slides, όταν χρησιμοποιείτε το σύστημα WebExtensions για την εξαγωγή παρουσιάσεων PowerPoint σε HTML, μπορείτε να προσαρμόσετε τις ρυθμίσεις εξαγωγής HTML ώστε να επιτύχετε τα καλύτερα αποτελέσματα. 

Χρησιμοποιώντας το νέο σύστημα WebExtensions, μπορείτε να εξάγετε ολόκληρη μια παρουσίαση σε HTML με ένα σύνολο κλάσεων CSS και κινήσεων JavaScript (χωρίς SVG). Το νέο σύστημα εξαγωγής προσφέρει επίσης απεριόριστο αριθμό επιλογών και μεθόδων που καθορίζουν τη διαδικασία εξαγωγής. 

Το νέο σύστημα WebExtensions χρησιμοποιείται για τη δημιουργία HTML από παρουσιάσεις στις ακόλουθες περιπτώσεις και γεγονότα:

* όταν χρησιμοποιούνται προσαρμοσμένα στυλ CSS ή κινήσεις· παραβιάζοντας τη σήμανση για ορισμένους τύπους σχήματος.  
* όταν παραβιάζεται η δομή του εγγράφου, π.χ. χρησιμοποιώντας προσαρμοσμένη πλοήγηση μεταξύ σελίδων.
* όταν αποθηκεύονται αρχεία .html, .css, .js σε φακέλους με προσαρμοσμένη ιεραρχία, συμπεριλαμβανομένων συγκεκριμένων τύπων αρχείων σε διαφορετικούς φακέλους. Για παράδειγμα, εξαγωγή διαφανειών σε φάκελο βάσει του ονόματος ενότητας.
* όταν αποθηκεύονται αρχεία CSS και JS σε ξεχωριστούς φακέλους από προεπιλογή και στη συνέχεια προστίθενται σε αρχείο HTML. Οι εικόνες και οι ενσωματωμένες γραμματοσειρές αποθηκεύονται επίσης σε ξεχωριστά αρχεία. Ωστόσο, μπορούν να ενσωματωθούν σε αρχείο HTML (σε μορφή base64). Μπορείτε να αποθηκεύσετε κάποια τμήματα των πόρων στα αρχεία και να ενσωματώσετε άλλους πόρους στο HTML ως base64.

Μπορείτε να δείτε παραδείγματα μετατροπής PowerPoint σε HTML στο [Aspose.Slides.WebExtensions project](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/) στο GitHub. Αυτό το έργο περιλαμβάνει 2 τμήματα: **Examples\SinglePageApp** και **Examples\MultiPageApp**. Τα άλλα παραδείγματα που χρησιμοποιούνται σε αυτό το άρθρο μπορούν επίσης να βρεθούν στο αποθετήριο GitHub.

### **Πρότυπα**

Για να επεκτείνετε περαιτέρω τις δυνατότητες εξαγωγής HTML, συνιστούμε να χρησιμοποιήσετε το σύστημα προτύπων ASP.NET Razor. Η κλάση [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation) μπορεί να χρησιμοποιηθεί μαζί με ένα σύνολο προτύπων για να λάβετε ένα έγγραφο HTML ως αποτέλεσμα της εξαγωγής.

**Διάδειξη**

Σε αυτό το παράδειγμα, θα εξάγουμε κείμενο από μια παρουσίαση σε HTML. Πρώτα, ας δημιουργήσουμε το πρότυπο:

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
Αυτό το πρότυπο αποθηκεύεται στον δίσκο ως "shape-template-hello-world.html", το οποίο θα χρησιμοποιηθεί στο επόμενο βήμα.

Σε αυτό το πρότυπο, επαναλαμβάνουμε πλαίσια κειμένου στα σχήματα της παρουσίασης για να εμφανίσουμε το κείμενο. Ας δημιουργήσουμε το αρχείο HTML χρησιμοποιώντας το WebDocument και στη συνέχεια να εξάγουμε την Presentation στο αρχείο:

``` csharp
using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 150);
    shape.TextFrame.Text = "Hello World";
                
    WebDocumentOptions options = new WebDocumentOptions
    {
        TemplateEngine = new RazorTemplateEngine(), // Σκοπεύουμε να χρησιμοποιήσουμε τη μηχανή προτύπων Razor. Μπορούν να χρησιμοποιηθούν και άλλες μηχανές προτύπων μέσω υλοποίησης του ITemplateEngine  
        OutputSaver = new FileOutputSaver() // Μπορούν να χρησιμοποιηθούν και άλλοι αποθηκευτές αποτελεσμάτων μέσω υλοποίησης της διεπαφής IOutputSaver
    };
    WebDocument document = new WebDocument(options);

    // προσθήκη εγγράφου "input" - ποια πηγή θα χρησιμοποιηθεί για τη δημιουργία του εγγράφου HTML
    document.Input
        .AddTemplate<Presentation>( // το πρότυπο θα έχει το Presentation ως αντικείμενο "μοντέλο" (Model.Object) 
        "index", // κλειδί προτύπου - απαιτείται από τη μηχανή προτύπων για να αντιστοιχίσει ένα αντικείμενο (Presentation) με το πρότυπο που φορτώνεται από το δίσκο ("shape-template-hello-world.html")  
        @"custom-templates\shape-template-hello-world.html"); // το πρότυπο που δημιουργήσαμε νωρίτερα
                
    // προσθήκη εξόδου - πώς θα φαίνεται το παραγόμενο έγγραφο HTML όταν εξαχθεί στο δίσκο
    document.Output.Add(
        "hello-world.html", // διαδρομή αρχείου εξόδου
        "index", // κλειδί προτύπου που θα χρησιμοποιηθεί για αυτό το αρχείο (το θέσαμε σε προηγούμενη δήλωση)  
        pres); // μια πραγματική παρουσία του Model.Object 
                
    document.Save();
}
```

Για παράδειγμα, θέλουμε να προσθέσουμε στυλ CSS στο αποτέλεσμα της εξαγωγής για να αλλάξουμε το χρώμα του κειμένου σε κόκκινο. Ας προσθέσουμε το πρότυπο CSS:

``` css
.text {
    color: red;
}
```

Τώρα, το προσθέτουμε στην είσοδο και την έξοδο:

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

Ας προσθέσουμε την αναφορά στα στυλ στο πρότυπο και στην κλάση "text":

``` html
<!DOCTYPE html>
<head>
    <link rel="stylesheet" type="text/css" href="hello-world.css" />
</head>
...
</html>
```

### **Προεπιλεγμένα Πρότυπα**

Το WebExtensions παρέχει 2 σύνολα βασικών προτύπων για την εξαγωγή παρουσιάσεων σε HTML:
* Single-page: όλο το περιεχόμενο της παρουσίασης εξάγεται σε ένα αρχείο HTML. Όλοι οι άλλοι πόροι (εικόνες, γραμματοσειρές, στυλ κ.λπ.) εξάγονται σε ξεχωριστά αρχεία.
* Multi-page: κάθε διαφάνεια της παρουσίασης εξάγεται σε ξεχωριστό αρχείο HTML. Η προεπιλεγμένη λογική εξαγωγής πόρων είναι η ίδια όπως σε μία σελίδα. 

`PresentationExtensions` class can be used to simplify the presentation export process using templates. `PresentationExtensions` class contains a set of extension methods for Presentation class. To export a presentation into a single page, just include the Aspose.Slides.WebExtensions namespace and call two methods. The first method, `ToSinglePageWebDocument`, creates a `WebDocument` instance. The second method saves the HTML document: 

``` csharp
using (Presentation pres = new Presentation("demo.pptx"))
{
    WebDocument document = pres.ToSinglePageWebDocument("templates\\single-page", @"single-page-output");
    document.Save();
}
```

ToSinglePageWebDocument method can take two parameters: templates folder and export folder. 

To export presentation to a multi page, use the ToMultiPageWebDocument method with the same parameters:

``` csharp
using (Presentation pres = new Presentation("demo.pptx"))
{
    WebDocument document = pres.ToMultiPageWebDocument("templates\\multi-page", @"mutil-page-output");
    document.Save();
}
```

In WebExtensions, each template used for markup generation is bound to a key. The key can be used in templates. For example, in the @Include directive, you can insert a certain template to another one by the key.

We can demonstrate the procedure in the example of text portion template usage inside the paragraph template. You can find the example in the Aspose.Slides.WebExtensions project: [Templates\common\paragraph.html](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/Templates/common/paragraph.html). To draw the portions in a paragraph, we iterate them using the @foreach directive of Razor Engine:

``` html
@foreach (Portion portion in contextObject.Portions) 
{ 
    var subModel = Model.SubModel(portion);
    subModel.Local.Put("parentTextFrame", parentTextFrame);
    subModel.Local.Put("tableContent", tableContentFlag);
	@Raw(Include("portion", subModel).ToString().Replace(Environment.NewLine, ""));
}
```

Portion has its own template [portion.html](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/Templates/common/portion.html) and a model is generated for it. That model will be added to the output paragraph.html template:
``` html
@Raw(Include("portion", subModel).ToString().Replace(Environment.NewLine, ""));
```

For each shape type, we use a custom template, which is added to the general set of templates from the Aspose.Slides.WebExtensions project. Templates are combined in the ToSinglePageWebDocument and ToMultiPageWebDocument methods to provide a final result. These are common templates used in both single and multi-page:

- templates
+-common
  ¦ +-scripts: σενάρια javascript για κινήσεις μετάβασης διαφανειών, ως παράδειγμα.
  ¦ +-styles: κοινά CSS στυλ.
  +-multi-page: index, menu, slide πρότυπα για την εξαγωγή multi-page.
  +-single-page: index, slide πρότυπα για την εξαγωγή single-page.

You can find out how the common part is bound for all the templates in `PresentationExtensions.AddCommonInputOutput` method [here](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/PresentationExtensions.cs).

### **Προσαρμογή Προεπιλεγμένου Προτύπου**

You can modify any element in the template of the common model. For example, you may decide to change the table formatting styles but want all the other styles of the single page to stay unchanged

By default, Templates\common\table.html is used, and the table has the same appearance as the table in PowerPoint. Let's change the table formatting using custom CSS styles:
``` css
.custom-table {
    border: 1px solid black;
}
.custom-table tr:nth-child(even) {background: #CCC}
.custom-table tr:nth-child(odd) {background: #ffb380}
```

We can create the same structure of input templates and output files (as it is generated) while calling the `PresentationExtensions.ToSinglePageWebDocument` method. Let's add the `ExportCustomTableStyles_AddCommonStructure` method for that. The difference between this method and `ToSinglePageWebDocument` method—we do not need to add the standard template for the table and the main index page (it will be replaced to include the reference on the custom table styles):

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

Let's add a custom template instead:

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

    // ρύθμιση παγκόσμιων τιμών εγγράφου
    WebDocument document = new WebDocument(options);
    SetupGlobals(document, options, outputPath);

    // προσθήκη κοινής δομής (εκτός του προτύπου πίνακα)
    ExportCustomTableStyles_AddCommonStructure(pres, document, templatesPath, outputPath, options.EmbedImages);
                
    // προσθήκη προσαρμοσμένου προτύπου πίνακα
    document.Input.AddTemplate<Table>("table", @"custom-templates\table-custom-style.html");
                
    // προσθήκη προσαρμοσμένων στυλ πίνακα
    document.Input.AddTemplate<Presentation>("table-custom-style", @"custom-templates\styles\table-custom-style.css");
    document.Output.Add(Path.Combine(outputPath, "table-custom-style.css"), "table-custom-style", pres);
                
    // προσθήκη προσαρμοσμένου index - είναι απλώς ένα αντίγραφο του τυπικού "index.html", αλλά περιλαμβάνει μια αναφορά στο "table-custom-style.css"
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

**Note** that the custom table template was added with the same “table” key as the standard table. Thus, you can replace a certain default template without rewriting it. You can also use the templates from the default structure with the same keys. For example, you may use a standard paragraph template in the table template; you may also replace it with the key.
You can also use index.html to include the reference on custom table CSS styles into it: 

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

## **Δημιουργία Έργου από την Αρχή: Κινούμενες Μεταβάσεις Διαφανειών**

WebExtensions allows you to export presentations with animated slide transitions—you just need to set the `AnimateTransitions` property in `WebDocumentOptions` to `true`:

``` csharp
WebDocumentOptions options = new WebDocumentOptions
{
    // ... άλλες επιλογές
    AnimateTransitions = true
};
```

Let's create a new project that uses Aspose.Slides and Aspose.Slides.WebExtensions for creating HTML-viewer for PDF with smooth animated page transitions. Here, we need to use the PDF import feature of Aspose.Slides.

Let's create a PdfToPresentationToHtml project and add the Aspose.Slides.WebExtensions NuGet package (the Aspose.Slides package will also be added as a dependency):
![NuGet Package](screen.png)

We start by importing the PDF document, which will be animated and exported into an HTML presentation:

``` csharp
using (Presentation pres = new Presentation())
{
    pres.Slides.RemoveAt(0);
    pres.Slides.AddFromPdf("sample.pdf");
}
```

Now, we can set up the animated slide transitions (each slide is the imported PDF page). We used 9 slides in the sample PDF document. Let's add slide transitions into each of them (demonstration while viewing HTML):

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

Finally, let's export it to HTML using `WebDocument` with the `AnimateTransitions` property set to `true`:

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

That's all you need to create HTML with the animated page transitions generated from the PDF document. 

* [Download sample HTML file](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/tree/main/Examples).
* [Download sample project](/slides/el/net/web-extensions/sample.zip).