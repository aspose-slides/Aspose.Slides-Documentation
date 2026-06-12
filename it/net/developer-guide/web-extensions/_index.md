---
title: Nuovo Sistema di Esportazione HTML - Aspose.Slides.WebExtensions
type: docs
weight: 240
url: /it/net/web-extensions/
keywords:
- estensione web
- motore di template
- esporta PowerPoint
- esporta OpenDocument
- esporta presentazione
- esporta diapositiva
- esporta PPT
- esporta PPTX
- esporta ODP
- PowerPoint in HTML
- OpenDocument in HTML
- presentazione in HTML
- diapositiva in HTML
- PPT in HTML
- PPTX in HTML
- ODP in HTML
- .NET
- C#
- Aspose.Slides
description: "Esporta le presentazioni in HTML con template, CSS e JS—senza SVG. Scopri l'output a pagina singola o multipagina, il controllo delle risorse e la personalizzazione per PPT, PPTX e ODP."
---
## **Introduzione**

* In vecchie versioni dell'API Aspose.Slides, quando si esporta PowerPoint in HTML, l'HTML risultante veniva rappresentato come un markup SVG combinato con HTML. Ogni diapositiva veniva esportata come un contenitore SVG. 
* Nelle nuove versioni di Aspose.Slides, quando si utilizza il sistema WebExtensions per esportare presentazioni PowerPoint in HTML, è possibile personalizzare le impostazioni di esportazione HTML per ottenere i migliori risultati. 

Utilizzando il nuovo sistema WebExtensions, è possibile esportare un'intera presentazione in HTML con un insieme di classi CSS e animazioni JavaScript (senza SVG). Il nuovo sistema di esportazione fornisce anche un numero illimitato di opzioni e metodi che definiscono il processo di esportazione. 

Il nuovo sistema WebExtensions viene utilizzato per generare HTML dalle presentazioni in questi casi ed eventi:

* quando si utilizzano stili CSS personalizzati o animazioni; sovrascrivendo il markup per determinati tipi di forme.  
* quando si sovrascrive la struttura del documento, ad esempio usando una navigazione personalizzata tra le pagine.
* quando si salvano file .html, .css, .js in cartelle con gerarchia personalizzata, includendo tipi di file specifici in cartelle diverse. Ad esempio, esportare le diapositive in una cartella basata sul nome della sezione.
* quando si salvano i file CSS e JS in cartelle separate per impostazione predefinita e poi li si aggiunge a un file HTML. Le immagini e i font incorporati vengono anch'essi salvati in file separati. Tuttavia, possono essere incorporati in un file HTML (in formato base64). È possibile salvare alcune parti delle risorse nei file e incorporare altre risorse nell'HTML come base64.

È possibile consultare gli esempi di PowerPoint a HTML nel progetto [Aspose.Slides.WebExtensions](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/) su GitHub. Questo progetto contiene 2 parti: **Examples\\SinglePageApp** e **Examples\\MultiPageApp**. Gli altri esempi utilizzati in questo articolo si trovano anch'essi nel repository GitHub.

### **Template**

Per ampliare ulteriormente le capacità di esportazione HTML, consigliamo di utilizzare il sistema di template ASP.NET Razor. L'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) può essere usata insieme a un insieme di template per ottenere un documento HTML come risultato dell'esportazione.

**Dimostrazione**

In questo esempio, esporteremo del testo da una presentazione in HTML. Per prima cosa, creiamo il template:

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
Questo template viene salvato sul disco come "shape-template-hello-world.html", che sarà usato nel passaggio successivo.

In questo template, iteriamo i frame di testo nelle forme della presentazione per visualizzare il testo. Generiamo il file HTML usando WebDocument e poi esportiamo la Presentation nel file: 

``` csharp
using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 150);
    shape.TextFrame.Text = "Hello World";
                
    WebDocumentOptions options = new WebDocumentOptions
    {
        TemplateEngine = new RazorTemplateEngine(), // Intendiamo utilizzare il motore di template Razor. Altri motori di template possono essere usati implementando ITemplateEngine  
        OutputSaver = new FileOutputSaver() // Altri salvatori di risultato possono essere usati implementando l'interfaccia IOutputSaver
    };
    WebDocument document = new WebDocument(options);

    // aggiungi documento "input" - quale origine verrà usata per generare il documento HTML
    document.Input
        .AddTemplate<Presentation>( // il template avrà Presentation come oggetto "model" (Model.Object) 
        "index", // chiave del template - necessaria al motore di template per abbinare un oggetto (Presentation) al template caricato dal disco ("shape-template-hello-world.html")  
        @"custom-templates\shape-template-hello-world.html"); // template creato in precedenza
                
    // aggiungi output - come apparirà il documento HTML risultante quando verrà esportato sul disco
    document.Output.Add(
        "hello-world.html", // percorso file di output
        "index", // chiave del template che verrà usata per questo file (impostata in una dichiarazione precedente)  
        pres); // un'istanza reale di Model.Object 
                
    document.Save();
}
```

Ad esempio, vogliamo aggiungere stili CSS al risultato dell'esportazione per cambiare il colore del testo in rosso. Aggiungiamo il template CSS:

``` css
.text {
    color: red;
}
```

Ora, lo aggiungiamo all'input e all'output:

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

Aggiungiamo il riferimento agli stili al template e alla classe "text":
``` html
<!DOCTYPE html>
<head>
    <link rel="stylesheet" type="text/css" href="hello-world.css" />
</head>
...
</html>
```

### **Template predefiniti**

WebExtensions fornisce 2 serie di template di base per esportare presentazioni in HTML:
* Single-page: tutto il contenuto della presentazione viene esportato in un unico file HTML. Tutte le altre risorse (immagini, font, stili, ecc.) vengono esportate in file separati.
* Multi-page: ogni diapositiva della presentazione viene esportata in un file HTML individuale. La logica predefinita per l'esportazione delle risorse è la stessa di una singola pagina. 

`PresentationExtensions` class can be used to simplify the presentation export process using templates. `PresentationExtensions` class contains a set of extension methods for Presentation class. To export a presentation into a single page, just include the Aspose.Slides.WebExtensions namespace and call two methods. The first method, `ToSinglePageWebDocument`, creates a `WebDocument` instance. The second method saves the HTML document: 

``` csharp
using (Presentation pres = new Presentation("demo.pptx"))
{
    WebDocument document = pres.ToSinglePageWebDocument("templates\\single-page", @"single-page-output");
    document.Save();
}
```

Il metodo ToSinglePageWebDocument può accettare due parametri: la cartella dei template e la cartella di esportazione. 

Per esportare la presentazione in più pagine, usare il metodo ToMultiPageWebDocument con gli stessi parametri:

``` csharp
using (Presentation pres = new Presentation("demo.pptx"))
{
    WebDocument document = pres.ToMultiPageWebDocument("templates\\multi-page", @"mutil-page-output");
    document.Save();
}
```

In WebExtensions, each template used for markup generation is bound to a key. The key can be used in templates. For example, in the @Include directive, you can insert a certain template to another one by the key.

Possiamo dimostrare la procedura nell'esempio di utilizzo del template di porzione di testo all'interno del template di paragrafo. È possibile trovare l'esempio nel progetto Aspose.Slides.WebExtensions: [Templates\\common\\paragraph.html](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/Templates/common/paragraph.html). Per disegnare le porzioni in un paragrafo, le iteriamo usando la direttiva @foreach del Razor Engine:

``` html
@foreach (Portion portion in contextObject.Portions) 
{ 
    var subModel = Model.SubModel(portion);
    subModel.Local.Put("parentTextFrame", parentTextFrame);
    subModel.Local.Put("tableContent", tableContentFlag);
	@Raw(Include("portion", subModel).ToString().Replace(Environment.NewLine, ""));
}
```

La porzione ha il proprio template [portion.html](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/Templates/common/portion.html) e per essa viene generato un modello. Tale modello verrà aggiunto al template di output paragraph.html:

``` html
@Raw(Include("portion", subModel).ToString().Replace(Environment.NewLine, ""));
```

Per ogni tipo di forma, utilizziamo un template personalizzato, che viene aggiunto al set generale di template del progetto Aspose.Slides.WebExtensions. I template sono combinati nei metodi ToSinglePageWebDocument e ToMultiPageWebDocument per fornire un risultato finale. Questi sono template comuni usati sia nella singola pagina sia nella multi-pagina:

- templates
+-common
  ¦ +-scripts: script javascript per le animazioni di transizione delle diapositive, come esempio.
  ¦ +-styles: stili CSS comuni.
  +-multi-page: template di indice, menu, diapositiva per l'output multi-pagina.
  +-single-page: template di indice, diapositiva per l'output a pagina singola.

È possibile scoprire come la parte comune è associata a tutti i template nel metodo `PresentationExtensions.AddCommonInputOutput` [qui](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/PresentationExtensions.cs).

### **Personalizzazione dei template predefiniti**

È possibile modificare qualsiasi elemento nel template del modello comune. Ad esempio, si può decidere di cambiare gli stili di formattazione della tabella ma mantenere invariati tutti gli altri stili della pagina singola.

Per impostazione predefinita, viene usato Templates\\common\\table.html, e la tabella ha lo stesso aspetto della tabella in PowerPoint. Cambiamo la formattazione della tabella usando stili CSS personalizzati:
``` css
.custom-table {
    border: 1px solid black;
}
.custom-table tr:nth-child(even) {background: #CCC}
.custom-table tr:nth-child(odd) {background: #ffb380}
```

Possiamo creare la stessa struttura di template di input e file di output (come viene generata) chiamando il metodo `PresentationExtensions.ToSinglePageWebDocument`. Aggiungiamo il metodo `ExportCustomTableStyles_AddCommonStructure` per questo scopo. La differenza tra questo metodo e il metodo `ToSinglePageWebDocument` — non è necessario aggiungere il template standard per la tabella e la pagina indice principale (verrà sostituito per includere il riferimento agli stili della tabella personalizzata):

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

Aggiungiamo invece un template personalizzato:

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

    // imposta i valori globali del documento
    WebDocument document = new WebDocument(options);
    SetupGlobals(document, options, outputPath);

    // aggiungi struttura comune (eccetto il template della tabella)
    ExportCustomTableStyles_AddCommonStructure(pres, document, templatesPath, outputPath, options.EmbedImages);
                
    // aggiungi template della tabella personalizzato
    document.Input.AddTemplate<Table>("table", @"custom-templates\table-custom-style.html");
                
    // aggiungi stili della tabella personalizzati
    document.Input.AddTemplate<Presentation>("table-custom-style", @"custom-templates\styles\table-custom-style.css");
    document.Output.Add(Path.Combine(outputPath, "table-custom-style.css"), "table-custom-style", pres);
                
    // aggiungi indice personalizzato - è solo una copia del "index.html" standard, ma include un riferimento a "table-custom-style.css"
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

**Nota** che il template della tabella personalizzata è stato aggiunto con la stessa chiave “table” del template standard. Pertanto, è possibile sostituire un determinato template predefinito senza riscriverlo. È inoltre possibile usare i template della struttura predefinita con le stesse chiavi. Ad esempio, si può usare un template di paragrafo standard nel template della tabella; si può anche sostituirlo con la chiave.
È possibile anche usare index.html per includere il riferimento agli stili CSS della tabella personalizzata al suo interno: 

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

## **Creare un progetto da zero: transizioni diapositive animate**

WebExtensions consente di esportare presentazioni con transizioni diapositive animate — è sufficiente impostare la proprietà `AnimateTransitions` in `WebDocumentOptions` a `true`:

``` csharp
WebDocumentOptions options = new WebDocumentOptions
{
    // ... altre opzioni
    AnimateTransitions = true
};
```

Creiamo un nuovo progetto che utilizza Aspose.Slides e Aspose.Slides.WebExtensions per creare un visualizzatore HTML per PDF con transizioni di pagina animate fluide. Qui, è necessario utilizzare la funzionalità di importazione PDF di Aspose.Slides.

Creiamo un progetto PdfToPresentationToHtml e aggiungiamo il pacchetto NuGet Aspose.Slides.WebExtensions (il pacchetto Aspose.Slides verrà aggiunto anche come dipendenza):
![NuGet Package](screen.png)

Iniziamo importando il documento PDF, che verrà animato ed esportato in una presentazione HTML:

``` csharp
using (Presentation pres = new Presentation())
{
    pres.Slides.RemoveAt(0);
    pres.Slides.AddFromPdf("sample.pdf");
}
```

Ora, possiamo impostare le transizioni diapositive animate (ogni diapositiva è la pagina PDF importata). Abbiamo usato 9 diapositive nel documento PDF di esempio. Aggiungiamo le transizioni diapositive a ciascuna di esse (dimostrazione durante la visualizzazione dell'HTML):

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

Infine, esportiamolo in HTML usando `WebDocument` con la proprietà `AnimateTransitions` impostata a `true`:

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

Esempio completo di codice sorgente:
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

Questo è tutto ciò di cui hai bisogno per creare HTML con transizioni di pagina animate generate dal documento PDF. 

* [Scarica file HTML di esempio](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/tree/main/Examples).
* [Scarica progetto di esempio](/slides/it/net/web-extensions/sample.zip).