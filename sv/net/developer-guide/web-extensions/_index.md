---
title: Nytt HTML-exportsystem - Aspose.Slides.WebExtensions
type: docs
weight: 240
url: /sv/net/web-extensions/
keywords:
- webbtillägg
- mallmotor
- exportera PowerPoint
- exportera OpenDocument
- exportera presentation
- exportera bild
- exportera PPT
- exportera PPTX
- exportera ODP
- PowerPoint till HTML
- OpenDocument till HTML
- presentation till HTML
- bild till HTML
- PPT till HTML
- PPTX till HTML
- ODP till HTML
- .NET
- C#
- Aspose.Slides
description: "Exportera presentationer till HTML med mallar, CSS och JS—utan SVG. Lär dig om enkelsidig eller flersidig utdata, resurskontroll och anpassning för PPT, PPTX och ODP."
---
## **Introduktion**

* I gamla Aspose.Slides API-byggnader, när du exporterar PowerPoint till HTML, representerades den resulterande HTML:n som en SVG-markup kombinerad med HTML. Varje bild exporteras som en SVG-behållare. 
* I nya Aspose.Slides-versioner, när du använder WebExtensions-systemet för att exportera PowerPoint-presentationer till HTML, kan du anpassa HTML-exportinställningarna för att leverera bästa resultat. 

Med det nya WebExtensions-systemet kan du exportera en hel presentation till HTML med en uppsättning CSS-klasser och JavaScript-animationer (utan SVG). Det nya exportsystemet erbjuder också ett obegränsat antal alternativ och metoder som definierar exportprocessen. 

Det nya WebExtensions-systemet används för att generera HTML från presentationer i följande fall och händelser:

* när du använder anpassade CSS-stilar eller animationer; överskrider markupen för vissa typer av former.  
* när du överskrider dokumentstrukturen, t.ex. genom att använda anpassad navigation mellan sidor.
* när du sparar .html, .css, .js-filer i mappar med anpassad hierarki, inklusive specifika filtyper i olika mappar. Till exempel, exportera bilder till en mapp baserad på avsnittsnamnet.
* när du sparar CSS- och JS-filer i separata mappar som standard och sedan lägger till dem i en HTML-fil. Bilder och inbäddade teckensnitt sparas också i separata filer. De kan dock inbäddas i en HTML-fil (i base64-format). Du kan spara vissa delar av resurserna till filerna och bädda in andra resurser i HTML som base64.

Du kan gå igenom PowerPoint till HTML-exempel i [Aspose.Slides.WebExtensions project](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/) på GitHub. Det här projektet innehåller 2 delar: **Examples\\SinglePageApp** och **Examples\\MultiPageApp**. De andra exemplen som används i den här artikeln finns också i GitHub-repot.

### **Mallar**

För att ytterligare utöka möjligheterna för HTML-export rekommenderar vi att du använder ASP.NET Razor-mallsystemet. [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation)-klassinstansen kan användas tillsammans med en uppsättning mallar för att få ett HTML-dokument som exportresultat.

**Demonstration**

I det här exemplet kommer vi att exportera text från en presentation till HTML. Först, låt oss skapa mallen:

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
Denna mall sparas på disken som "shape-template-hello-world.html", som kommer att användas i nästa steg.

I den här mallen itererar vi textramar i presentationsformer för att visa texten. Låt oss generera HTML-filen med WebDocument och sedan exportera Presentation till filen: 

``` csharp
using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 150);
    shape.TextFrame.Text = "Hello World";
                
    WebDocumentOptions options = new WebDocumentOptions
    {
        TemplateEngine = new RazorTemplateEngine(), // Vi avser att använda Razor-mallmotorn. Andra mallmotorer kan användas genom att implementera ITemplateEngine  
        OutputSaver = new FileOutputSaver() // Andra resultatsparare kan användas genom att implementera IOutputSaver-gränssnittet
    };
    WebDocument document = new WebDocument(options);

    // lägg till dokument "input" – vilken källa som kommer att användas för att generera HTML-dokumentet
    document.Input
        .AddTemplate<Presentation>( // mallen kommer att ha Presentation som ett "model" objekt (Model.Object) 
        "index", // mallnyckel – behövs av mallmotorn för att matcha ett objekt (Presentation) med mallen som lästs från disk ("shape-template-hello-world.html")  
        @"custom-templates\shape-template-hello-world.html"); // mallen vi skapade tidigare
                
    // lägg till output – hur det resulterande HTML-dokumentet kommer att se ut när det exporteras till disken
    document.Output.Add(
        "hello-world.html", // sökväg för utdatafil
        "index", // mallnyckel som kommer att användas för den här filen (vi satte den i ett tidigare uttalande)  
        pres); // ett faktiskt Model.Object-instans 
                
    document.Save();
}
```

Till exempel vill vi lägga till CSS-stilar till exportresultatet för att ändra textfärgen till röd. Låt oss lägga till CSS-mallen:

``` css
.text {
    color: red;
}
```

Nu lägger vi till den i indata och utdata:

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

Låt oss lägga till referensen till stilarna i mallen och klassen "text":
``` html
<!DOCTYPE html>
<head>
    <link rel="stylesheet" type="text/css" href="hello-world.css" />
</head>
...
</html>
```

### **Standardmallar**

WebExtensions tillhandahåller 2 uppsättningar grundläggande mallar för att exportera presentationer till HTML:
* En-sida: allt presentationsinnehåll exporteras till en HTML-fil. Alla andra resurser (bilder, teckensnitt, stilar osv.) exporteras till separata filer.
* Flera-sidor: varje presentationsbild exporteras till en individuell HTML-fil. Standardlogiken för att exportera resurser är densamma som i en en-sida. 

`PresentationExtensions`-klassen kan användas för att förenkla presentationsexportprocessen med mallar. `PresentationExtensions`-klassen innehåller en uppsättning förlängningsmetoder för Presentation-klassen. För att exportera en presentation till en en-sida, inkludera bara Aspose.Slides.WebExtensions-namnområdet och anropa två metoder. Den första metoden, `ToSinglePageWebDocument`, skapar en `WebDocument`-instans. Den andra metoden sparar HTML-dokumentet: 

``` csharp
using (Presentation pres = new Presentation("demo.pptx"))
{
    WebDocument document = pres.ToSinglePageWebDocument("templates\\single-page", @"single-page-output");
    document.Save();
}
```
`ToSinglePageWebDocument`-metoden kan ta två parametrar: mallmapp och exportmapp. 

För att exportera presentation till flera sidor, använd `ToMultiPageWebDocument`-metoden med samma parametrar:

``` csharp
using (Presentation pres = new Presentation("demo.pptx"))
{
    WebDocument document = pres.ToMultiPageWebDocument("templates\\multi-page", @"mutil-page-output");
    document.Save();
}
```

I WebExtensions är varje mall som används för markup-generering bunden till en nyckel. Nyckeln kan användas i mallar. Till exempel, i @Include-direktivet kan du infoga en viss mall i en annan genom nyckeln.

Vi kan demonstrera proceduren i exemplet med textdelmall som används i stycke-mallen. Du kan hitta exemplet i Aspose.Slides.WebExtensions-projektet: [Templates\\common\\paragraph.html](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/Templates/common/paragraph.html). För att rita delarna i ett stycke itererar vi dem med @foreach-direktivet i Razor Engine:

``` html
@foreach (Portion portion in contextObject.Portions) 
{ 
    var subModel = Model.SubModel(portion);
    subModel.Local.Put("parentTextFrame", parentTextFrame);
    subModel.Local.Put("tableContent", tableContentFlag);
	@Raw(Include("portion", subModel).ToString().Replace(Environment.NewLine, ""));
}
```
Del har sin egen mall [portion.html](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/Templates/common/portion.html) och en modell genereras för den. Den modellen kommer att läggas till i utdata paragraph.html-mallen:

``` html
@Raw(Include("portion", subModel).ToString().Replace(Environment.NewLine, ""));
```

För varje formtyp använder vi en anpassad mall, som läggs till i den allmänna mälluppsättningen från Aspose.Slides.WebExtensions-projektet. Mallar kombineras i `ToSinglePageWebDocument`- och `ToMultiPageWebDocument`-metoderna för att ge ett slutresultat. Detta är gemensamma mallar som används både för en-sida och flera-sidor:

- templates
+-common
  ¦ +-scripts: javascript-skript för bildövergångsanimationer, som exempel.
  ¦ +-styles: gemensamma CSS-stilar.
  +-multi-page: index, meny, bildmallar för multi-page-utdata.
  +-single-page: index, bildmallar för single-page-utdata.

Du kan ta reda på hur den gemensamma delen är bunden för alla mallar i `PresentationExtensions.AddCommonInputOutput`-metoden [här](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/PresentationExtensions.cs).

### **Standardmallanpassning**

Du kan ändra vilket element som helst i mallen för den gemensamma modellen. Till exempel kan du bestämma dig för att ändra tabellformateringsstilar men vill att alla andra stilar för en-sidan förblir oförändrade.

Som standard används Templates\\common\\table.html, och tabellen har samma utseende som tabellen i PowerPoint. Låt oss ändra tabellformateringen med anpassade CSS-stilar:
``` css
.custom-table {
    border: 1px solid black;
}
.custom-table tr:nth-child(even) {background: #CCC}
.custom-table tr:nth-child(odd) {background: #ffb380}
```

Vi kan skapa samma struktur av inputmallar och output-filer (som den genereras) när vi anropar `PresentationExtensions.ToSinglePageWebDocument`-metoden. Låt oss lägga till `ExportCustomTableStyles_AddCommonStructure`-metoden för det. Skillnaden mellan denna metod och `ToSinglePageWebDocument`-metoden — vi behöver inte lägga till standardmallen för tabellen och huvindexsidan (den kommer att ersättas för att inkludera referensen till de anpassade tabellstilarna):

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

Låt oss lägga till en anpassad mall istället:

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

    // konfigurera globala dokumentvärden
    WebDocument document = new WebDocument(options);
    SetupGlobals(document, options, outputPath);

    // lägg till gemensam struktur (förutom tabellmall)
    ExportCustomTableStyles_AddCommonStructure(pres, document, templatesPath, outputPath, options.EmbedImages);
                
    // lägg till anpassad tabellmall
    document.Input.AddTemplate<Table>("table", @"custom-templates\table-custom-style.html");
                
    // lägg till anpassade tabellstilar
    document.Input.AddTemplate<Presentation>("table-custom-style", @"custom-templates\styles\table-custom-style.css");
    document.Output.Add(Path.Combine(outputPath, "table-custom-style.css"), "table-custom-style", pres);
                
    // lägg till anpassad index - det är bara en kopia av standard-"index.html", men inkluderar en referens till "table-custom-style.css"
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

**Note** att den anpassade tabellmallen lades till med samma “table”-nyckel som standardtabellen. Således kan du ersätta en viss standardmall utan att skriva om den. Du kan också använda mallarna från standardstrukturen med samma nycklar. Till exempel kan du använda en standardstycke-mall i tabellmallen; du kan också ersätta den med nyckeln.
Du kan också använda index.html för att inkludera referensen till anpassade tabell-CSS-stilar i den: 

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

## **Skapa ett projekt från början: Animera bildövergångar**

WebExtensions låter dig exportera presentationer med animerade bildövergångar — du behöver bara sätta `AnimateTransitions`-egenskapen i `WebDocumentOptions` till `true`:

``` csharp
WebDocumentOptions options = new WebDocumentOptions
{
    // ... andra alternativ
    AnimateTransitions = true
};
```

Låt oss skapa ett nytt projekt som använder Aspose.Slides och Aspose.Slides.WebExtensions för att skapa en HTML-visare för PDF med smidiga animerade sidövergångar. Här behöver vi använda PDF-importfunktionen i Aspose.Slides.

Låt oss skapa ett PdfToPresentationToHtml-projekt och lägga till Aspose.Slides.WebExtensions NuGet-paketet (Aspose.Slides-paketet kommer också att läggas till som beroende):
![NuGet Package](screen.png)

Vi börjar med att importera PDF-dokumentet, som kommer att animeras och exporteras till en HTML-presentation:

``` csharp
using (Presentation pres = new Presentation())
{
    pres.Slides.RemoveAt(0);
    pres.Slides.AddFromPdf("sample.pdf");
}
```

Nu kan vi ställa in de animerade bildövergångarna (varje bild är en importerad PDF-sida). Vi använde 9 bilder i exempel-PDF-dokumentet. Låt oss lägga till bildövergångar i var och en av dem (demonstration medan HTML visas):

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

Slutligen, låt oss exportera den till HTML med `WebDocument` med `AnimateTransitions`-egenskapen satt till `true`:

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

Fullständigt källkodsexempel:
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

Det är allt du behöver för att skapa HTML med animerade sidövergångar genererade från PDF-dokumentet. 

* [Ladda ner exempel‑HTML‑fil](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/tree/main/Examples).
* [Ladda ner exempelprojekt](/slides/sv/net/web-extensions/sample.zip).