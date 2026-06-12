---
title: Nieuw HTML-exportsysteem - Aspose.Slides.WebExtensions
type: docs
weight: 240
url: /nl/net/web-extensions/
keywords:
- webextensie
- template-engine
- PowerPoint exporteren
- OpenDocument exporteren
- presentatie exporteren
- dia exporteren
- PPT exporteren
- PPTX exporteren
- ODP exporteren
- PowerPoint naar HTML
- OpenDocument naar HTML
- presentatie naar HTML
- dia naar HTML
- PPT naar HTML
- PPTX naar HTML
- ODP naar HTML
- .NET
- C#
- Aspose.Slides
description: "Exporteer presentaties naar HTML met templates, CSS en JS—geen SVG. Leer over enkel- of meerpagina-output, resourcebeheer en aanpassing voor PPT, PPTX en ODP."
---
## **Introductie**

* In oude Aspose.Slides API‑builds, wanneer je PowerPoint naar HTML exporteert, werd de resulterende HTML weergegeven als een SVG‑markup gecombineerd met HTML. Elke dia werd geëxporteerd als een SVG‑container. 
* In nieuwe Aspose.Slides‑versies, wanneer je het WebExtensions‑systeem gebruikt om PowerPoint‑presentaties naar HTML te exporteren, kun je de HTML‑exportinstellingen aanpassen om de beste resultaten te leveren. 

Met het nieuwe WebExtensions‑systeem kun je een volledige presentatie exporteren naar HTML met een reeks CSS‑klassen en JavaScript‑animaties (zonder SVG). Het nieuwe exportsysteem biedt bovendien een onbeperkt aantal opties en methoden die het exportproces definiëren. 

Het nieuwe WebExtensions‑systeem wordt gebruikt om HTML uit presentaties te genereren in deze gevallen en gebeurtenissen:

* bij gebruik van aangepaste CSS‑stijlen of animaties; het overschrijven van de markup voor bepaalde types vormen.  
* bij het overschrijven van de documentstructuur, bv. met aangepaste navigatie tussen pagina’s.  
* bij het opslaan van .html, .css, .js‑bestanden in mappen met een aangepaste hiërarchie, inclusief specifieke bestandstypen in verschillende mappen. Bijvoorbeeld, dia’s exporteren naar een map op basis van de sectienaam.  
* bij het standaard opslaan van CSS‑ en JS‑bestanden in afzonderlijke mappen en ze vervolgens aan een HTML‑bestand toevoegen. Afbeeldingen en ingebedde lettertypen worden ook in afzonderlijke bestanden opgeslagen. Ze kunnen echter in een HTML‑bestand worden ingebed (in base64‑formaat). Je kunt sommige resources naar bestanden opslaan en andere resources als base64 in HTML inbedden.  

U kunt de PowerPoint‑naar‑HTML‑voorbeelden bekijken in het [Aspose.Slides.WebExtensions‑project](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/) op GitHub. Dit project bevat 2 delen: **Examples\SinglePageApp** en **Examples\MultiPageApp**. De andere voorbeelden die in dit artikel worden gebruikt, zijn ook terug te vinden in de GitHub‑repo.  

### **Templates**

Om de mogelijkheden van HTML‑export verder uit te breiden, raden we aan het ASP.NET Razor‑templatesysteem te gebruiken. Een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)‑klasse kan samen met een set templates worden gebruikt om een HTML‑document als exportresultaat te krijgen.  

**Demonstratie**

In dit voorbeeld exporteren we tekst uit een presentatie naar HTML. Laten we eerst de template maken:

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
Deze template wordt op schijf opgeslagen als “shape-template-hello-world.html”, die in de volgende stap wordt gebruikt.  

In deze template itereren we over tekstframes in presentatiedriehoeken om de tekst weer te geven. Laten we het HTML‑bestand genereren met WebDocument en vervolgens de Presentation naar het bestand exporteren:

``` csharp
using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 150);
    shape.TextFrame.Text = "Hello World";
                
    WebDocumentOptions options = new WebDocumentOptions
    {
        TemplateEngine = new RazorTemplateEngine(), // We willen de Razor-template-engine gebruiken. Andere template-engines kunnen worden gebruikt door ITemplateEngine te implementeren
        OutputSaver = new FileOutputSaver() // Andere resultaatsavers kunnen worden gebruikt door de IOutputSaver-interface te implementeren
    };
    WebDocument document = new WebDocument(options);

    // voeg document "input" toe – welke bron wordt gebruikt om het HTML-document te genereren
    document.Input
        .AddTemplate<Presentation>( // template zal Presentation hebben als een "model" object (Model.Object)
        "index", // template-sleutel – nodig voor de template-engine om een object (Presentation) te koppelen aan de van schijf geladen template ("shape-template-hello-world.html")
        @"custom-templates\shape-template-hello-world.html"); // template die we eerder hebben aangemaakt
                
    // voeg output toe – hoe het resulterende HTML-document eruitziet wanneer het naar schijf wordt geëxporteerd
    document.Output.Add(
        "hello-world.html", // output-bestandspad
        "index", // template-sleutel die voor dit bestand wordt gebruikt (we hebben deze eerder ingesteld)
        pres); // een daadwerkelijke Model.Object-instantie
                
    document.Save();
}
```

Als voorbeeld willen we CSS‑stijlen toevoegen aan het exportresultaat om de tekstkleur rood te maken. Laten we de CSS‑template toevoegen:

``` css
.text {
    color: red;
}
```

Nu voegen we deze toe aan de input en output:

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

Laten we de referentie naar de stijlen toevoegen aan de template en de klasse “text”:

``` html
<!DOCTYPE html>
<head>
    <link rel="stylesheet" type="text/css" href="hello-world.css" />
</head>
...
</html>
```

### **Standaardtemplates**

WebExtensions biedt 2 sets basis‑templates voor het exporteren van presentaties naar HTML:
* Single‑page: alle presentatiedata worden geëxporteerd naar één HTML‑bestand. Alle andere resources (afbeeldingen, lettertypen, stijlen, enz.) worden naar afzonderlijke bestanden geëxporteerd.  
* Multi‑page: elke presentatiedia wordt geëxporteerd naar een individueel HTML‑bestand. De standaardlogica voor het exporteren van resources is dezelfde als bij een enkele pagina.  

`PresentationExtensions`‑klasse kan worden gebruikt om het exportproces van een presentatie te vereenvoudigen met templates. `PresentationExtensions`‑klasse bevat een set extensiemethoden voor de Presentation‑klasse. Om een presentatie naar een enkele pagina te exporteren, voeg je de Aspose.Slides.WebExtensions‑namespace toe en roep je twee methoden aan. De eerste methode, `ToSinglePageWebDocument`, maakt een `WebDocument`‑instantie. De tweede methode slaat het HTML‑document op:

``` csharp
using (Presentation pres = new Presentation("demo.pptx"))
{
    WebDocument document = pres.ToSinglePageWebDocument("templates\\single-page", @"single-page-output");
    document.Save();
}
```

De `ToSinglePageWebDocument`‑methode kan twee parameters aannemen: map met templates en exportmap.  

Om een presentatie naar meerdere pagina’s te exporteren, gebruik je de `ToMultiPageWebDocument`‑methode met dezelfde parameters:

``` csharp
using (Presentation pres = new Presentation("demo.pptx"))
{
    WebDocument document = pres.ToMultiPageWebDocument("templates\\multi-page", @"mutil-page-output");
    document.Save();
}
```

In WebExtensions is elke template die voor markup‑generatie wordt gebruikt gebonden aan een sleutel. Die sleutel kan in templates worden gebruikt. Bijvoorbeeld, in de @Include‑directive kun je een bepaalde template in een andere invoegen via de sleutel.  

We kunnen de procedure demonstreren met het voorbeeld van een tekst‑deel‑template binnen de alinea‑template. Het voorbeeld is te vinden in het Aspose.Slides.WebExtensions‑project: [Templates\common\paragraph.html](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/Templates/common/paragraph.html). Om de delen in een alinea te tekenen, itereren we erover met de @foreach‑directive van Razor Engine:

``` html
@foreach (Portion portion in contextObject.Portions) 
{ 
    var subModel = Model.SubModel(portion);
    subModel.Local.Put("parentTextFrame", parentTextFrame);
    subModel.Local.Put("tableContent", tableContentFlag);
	@Raw(Include("portion", subModel).ToString().Replace(Environment.NewLine, ""));
}
```

Een deel heeft een eigen template [portion.html](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/Templates/common/portion.html) en er wordt een model voor gegenereerd. Dat model wordt toegevoegd aan de output‑template paragraph.html:

``` html
@Raw(Include("portion", subModel).ToString().Replace(Environment.NewLine, ""));
```

Voor elk type vorm gebruiken we een aangepaste template, die wordt toegevoegd aan de algemene set templates uit het Aspose.Slides.WebExtensions‑project. Templates worden gecombineerd in de `ToSinglePageWebDocument`‑ en `ToMultiPageWebDocument`‑methoden om een eindresultaat te leveren. Dit zijn de gemeenschappelijke templates die zowel in single‑ als multi‑page‑scenario’s worden gebruikt:

- templates
+-common
  ¦ +-scripts: javascript‑scripts voor dia‑overgangsanimaties, als instantie.
  ¦ +-styles: gemeenschappelijke CSS‑stijlen.
  +-multi-page: index, menu, slide‑templates voor de multi‑page‑output.
  +-single-page: index, slide‑templates voor single‑page‑output.

Je kunt zien hoe het gemeenschappelijke deel wordt gebonden voor alle templates in de `PresentationExtensions.AddCommonInputOutput`‑methode [hier](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/PresentationExtensions.cs).  

### **Aanpassen van standaardtemplates**

Je kunt elk element in de template van het gemeenschappelijke model wijzigen. Bijvoorbeeld, je wilt de tabel‑opmaakstijlen aanpassen maar alle andere stijlen van de enkele pagina ongewijzigd laten.  

Standaard wordt Templates\common\table.html gebruikt, en de tabel ziet er hetzelfde uit als de tabel in PowerPoint. Laten we de tabelopmaak wijzigen met aangepaste CSS‑stijlen:

``` css
.custom-table {
    border: 1px solid black;
}
.custom-table tr:nth-child(even) {background: #CCC}
.custom-table tr:nth-child(odd) {background: #ffb380}
```

We kunnen dezelfde structuur van invoertemplates en uitvoerbestanden (zoals gegenereerd) maken terwijl we de `PresentationExtensions.ToSinglePageWebDocument`‑methode aanroepen. Voeg de methode `ExportCustomTableStyles_AddCommonStructure` toe. Het verschil met `ToSinglePageWebDocument` is dat we de standaardtemplate voor de tabel en de hoofd‑indexpagina niet hoeven toe te voegen (die zal worden vervangen om de referentie naar de aangepaste tabelstijlen op te nemen):

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

Laten we in plaats daarvan een aangepaste template toevoegen:

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

    // globale documentwaarden instellen
    WebDocument document = new WebDocument(options);
    SetupGlobals(document, options, outputPath);

    // voeg globale structuur toe (behalve tabel-template)
    ExportCustomTableStyles_AddCommonStructure(pres, document, templatesPath, outputPath, options.EmbedImages);
                
    // voeg aangepaste tabeltemplate toe
    document.Input.AddTemplate<Table>("table", @"custom-templates\table-custom-style.html");
                
    // voeg aangepaste tabelstijlen toe
    document.Input.AddTemplate<Presentation>("table-custom-style", @"custom-templates\styles\table-custom-style.css");
    document.Output.Add(Path.Combine(outputPath, "table-custom-style.css"), "table-custom-style", pres);
                
    // voeg aangepast indexbestand toe - het is slechts een kopie van de standaard "index.html", maar bevat een verwijzing naar "table-custom-style.css"
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

**Opmerking** dat de aangepaste tabeltemplate is toegevoegd met dezelfde “table”‑sleutel als de standaardtabel. Daardoor kun je een bepaalde standaardtemplate vervangen zonder deze opnieuw te schrijven. Je kunt ook de templates uit de standaardstructuur met dezelfde sleutels gebruiken. Bijvoorbeeld, je kunt een standaard alinea‑template in de tabeltemplate gebruiken; je kunt die ook vervangen door de sleutel.  

Je kunt ook index.html gebruiken om de referentie naar aangepaste tabel‑CSS‑stijlen erin op te nemen:

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

## **Een project vanaf nul maken: geanimeerde diaovergangen**

WebExtensions maakt het mogelijk om presentaties te exporteren met geanimeerde diaovergangen—je hoeft alleen de `AnimateTransitions`‑eigenschap in `WebDocumentOptions` op `true` te zetten:

``` csharp
WebDocumentOptions options = new WebDocumentOptions
{
    // ... andere opties
    AnimateTransitions = true
};
```

Laten we een nieuw project maken dat Aspose.Slides en Aspose.Slides.WebExtensions gebruikt om een HTML‑viewer voor PDF te maken met vloeiende geanimeerde paginatransities. Hier moeten we de PDF‑importfunctionaliteit van Aspose.Slides gebruiken.

Maak een PdfToPresentationToHtml‑project en voeg het Aspose.Slides.WebExtensions‑NuGet‑pakket toe (het Aspose.Slides‑pakket wordt ook als afhankelijkheid toegevoegd):
![NuGet Package](screen.png)

We beginnen met het importeren van het PDF‑document, dat geanimeerd wordt en wordt geëxporteerd naar een HTML‑presentatie:

``` csharp
using (Presentation pres = new Presentation())
{
    pres.Slides.RemoveAt(0);
    pres.Slides.AddFromPdf("sample.pdf");
}
```

Nu kunnen we de geanimeerde diaovergangen instellen (elke dia is de geïmporteerde PDF‑pagina). We gebruikten 9 dia’s in het voorbeeld‑PDF‑document. Voeg diaovergangen toe aan elk van hen (demonstratie tijdens het bekijken van HTML):

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

Tot slot exporteren we het naar HTML met `WebDocument` waarbij de `AnimateTransitions`‑eigenschap op `true` staat:

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

Volledig broncode‑voorbeeld:
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

Dat is alles wat je nodig hebt om HTML te maken met geanimeerde paginatransities die gegenereerd zijn vanuit het PDF‑document. 

* [Voorbeeld‑HTML‑bestand downloaden](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/tree/main/Examples)
* [Voorbeeldproject downloaden](/slides/nl/net/web-extensions/sample.zip)