---
title: Nový systém exportu HTML - Aspose.Slides.WebExtensions
type: docs
weight: 240
url: /cs/net/web-extensions/
keywords:
- webové rozšíření
- šablonový engine
- export PowerPointu
- export OpenDocumentu
- export prezentace
- export snímku
- export PPT
- export PPTX
- export ODP
- PowerPoint do HTML
- OpenDocument do HTML
- prezentace do HTML
- snímek do HTML
- PPT do HTML
- PPTX do HTML
- ODP do HTML
- .NET
- C#
- Aspose.Slides
description: "Exportujte prezentace do HTML pomocí šablon, CSS a JS—bez SVG. Naučte se výstup v jedné nebo více stránkách, řízení zdrojů a přizpůsobení pro PPT, PPTX a ODP."
---
## **Úvod**

* Ve starých sestaveních Aspose.Slides API, když exportujete PowerPoint do HTML, vzniklý HTML byl reprezentován jako SVG markup kombinovaný s HTML. Každý snímek byl exportován jako SVG kontejner.  
* V nových verzích Aspose.Slides, když použijete systém WebExtensions pro export prezentací PowerPoint do HTML, můžete přizpůsobit nastavení exportu HTML a dosáhnout tak nejlepších výsledků.  

Pomocí nového systému WebExtensions můžete exportovat celou prezentaci do HTML se sadou CSS tříd a JavaScriptových animací (bez SVG). Nový exportní systém také poskytuje neomezené množství možností a metod, které definují proces exportu.  

Systém WebExtensions se používá k generování HTML z prezentací v následujících případech a událostech:

* při použití vlastních CSS stylů nebo animací; přepisování markup pro určité typy tvarů.  
* při přepisování struktury dokumentu, např. pomocí vlastní navigace mezi stránkami.  
* při ukládání souborů .html, .css, .js do složek s přizpůsobenou hierarchií, včetně umístění specifických typů souborů do různých složek. Například export snímků do složky na základě názvu sekce.  
* při ukládání CSS a JS souborů do samostatných složek ve výchozím nastavení a následném přidání do HTML souboru. Obrázky a vložená písma jsou také ukládána do samostatných souborů. Mohou však být vložena do HTML souboru (v base64 formátu). Některé části zdrojů můžete uložit do souborů a ostatní vložit do HTML jako base64.  

Můžete si projít příklady PowerPoint → HTML v [Aspose.Slides.WebExtensions projektu](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/) na GitHubu. Tento projekt obsahuje 2 části: **Examples\SinglePageApp** a **Examples\MultiPageApp**. Další příklady použité v tomto článku jsou také k dispozici v repozitáři na GitHubu.  

### **Šablony**

Pro další rozšíření možností exportu HTML doporučujeme použít systém šablon ASP.NET Razor. Instance třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation) může být použita spolu s sadou šablon k získání HTML dokumentu jako výstupu exportu.  

**Ukázka**

V tomto příkladu exportujeme text z prezentace do HTML. Nejprve vytvoříme šablonu:

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
Tato šablona je uložena na disku pod názvem „shape-template-hello-world.html“, který bude použit v dalším kroku.  

V této šabloně iterujeme textové rámečky v tvarech prezentace a zobrazujeme text. Vygenerujeme HTML soubor pomocí WebDocument a následně exportujeme Presentation do souboru: 

``` csharp
using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 150);
    shape.TextFrame.Text = "Hello World";
                
    WebDocumentOptions options = new WebDocumentOptions
    {
        TemplateEngine = new RazorTemplateEngine(), // Plánujeme použít Razor šablonový engine. Ostatní šablonové enginy lze použít implementací ITemplateEngine  
        OutputSaver = new FileOutputSaver() // Další ukladače výsledků lze použít implementací rozhraní IOutputSaver
    };
    WebDocument document = new WebDocument(options);

    // přidat dokument "input" – jaký zdroj bude použit pro vygenerování HTML dokumentu
    document.Input
        .AddTemplate<Presentation>( // šablona bude mít Presentation jako objekt "modelu" (Model.Object) 
        "index", // klíč šablony – potřebný šablonovému enginu k přiřazení objektu (Presentation) ke šabloně načtené z disku ("shape-template-hello-world.html")  
        @"custom-templates\shape-template-hello-world.html"); // šablona, kterou jsme vytvořili dříve
                
    // přidat výstup – jak bude výsledný HTML dokument vypadat po exportu na disk
    document.Output.Add(
        "hello-world.html", // cesta k výstupnímu souboru
        "index", // klíč šablony, který bude pro tento soubor použit (nastavili jsme ho v předchozím příkazu)  
        pres); // skutečná instance Model.Object 
                
    document.Save();
}
```

Například chceme do výstupu exportu přidat CSS styl, který změní barvu textu na červenou. Přidáme CSS šablonu:

``` css
.text {
    color: red;
}
```

Nyní ji vložíme do vstupu a výstupu:

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

Přidáme odkaz na styly do šablony a třídu „text“:
``` html
<!DOCTYPE html>
<head>
    <link rel="stylesheet" type="text/css" href="hello-world.css" />
</head>
...
</html>
```

### **Výchozí šablony**

WebExtensions poskytuje 2 sady základních šablon pro export prezentací do HTML:
* Jednostránková: veškerý obsah prezentace je exportován do jednoho HTML souboru. Všechny ostatní zdroje (obrázky, písma, styly atd.) jsou exportovány do samostatných souborů.  
* Vícestránková: každý snímek prezentace je exportován do samostatného HTML souboru. Výchozí logika pro export zdrojů je stejná jako u jednostránkové verze.  

Třídu `PresentationExtensions` lze použít ke zjednodušení procesu exportu prezentace pomocí šablon. `PresentationExtensions` obsahuje sadu rozšiřujících metod pro třídu Presentation. Pro export prezentace do jedné stránky stačí zahrnout obor názvů Aspose.Slides.WebExtensions a zavolat dvě metody. První metoda, `ToSinglePageWebDocument`, vytvoří instanci `WebDocument`. Druhá metoda uloží HTML dokument: 

``` csharp
using (Presentation pres = new Presentation("demo.pptx"))
{
    WebDocument document = pres.ToSinglePageWebDocument("templates\\single-page", @"single-page-output");
    document.Save();
}
```

Metoda `ToSinglePageWebDocument` může přijímat dva parametry: složku šablon a složku exportu.  

Pro export prezentace do vícestránkového výstupu použijte metodu `ToMultiPageWebDocument` se stejnými parametry:

``` csharp
using (Presentation pres = new Presentation("demo.pptx"))
{
    WebDocument document = pres.ToMultiPageWebDocument("templates\\multi-page", @"mutil-page-output");
    document.Save();
}
```

V WebExtensions je každá šablona používaná pro generování markup svázána s klíčem. Klíč může být použit v šablonách. Například v direktivu @Include můžete vložit konkrétní šablonu do jiné pomocí klíče.  

Můžeme postup ukázat na příkladu použití šablony částí textu uvnitř šablony odstavce. Příklad najdete v projektu Aspose.Slides.WebExtensions: [Templates\common\paragraph.html](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/Templates/common/paragraph.html). Pro vykreslení částí v odstavci je iterujeme pomocí direktivy @foreach motoru Razor:

``` html
@foreach (Portion portion in contextObject.Portions) 
{ 
    var subModel = Model.SubModel(portion);
    subModel.Local.Put("parentTextFrame", parentTextFrame);
    subModel.Local.Put("tableContent", tableContentFlag);
	@Raw(Include("portion", subModel).ToString().Replace(Environment.NewLine, ""));
}
```

Část má vlastní šablonu [portion.html](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/Templates/common/portion.html) a pro ni je vygenerován model. Tento model bude přidán do výstupní šablony paragraph.html:
``` html
@Raw(Include("portion", subModel).ToString().Replace(Environment.NewLine, ""));
```

Pro každý typ tvaru používáme vlastní šablonu, která je přidána do obecné sady šablon z projektu Aspose.Slides.WebExtensions. Šablony jsou kombinovány v metodách `ToSinglePageWebDocument` a `ToMultiPageWebDocument` a poskytují finální výsledek. Jedná se o společné šablony používané v jednostránkové i vícestránkové verzi:

- templates  
+-common  
  ¦ +-scripts: javascriptové skripty pro animace přechodů snímků, např.  
  ¦ +-styles: společné CSS styly.  
  +-multi-page: index, menu, šablony snímků pro vícestránkový výstup.  
  +-single-page: index, šablony snímků pro jednostránkový výstup.  

Jak je společná část svázána se všemi šablonami, můžete zjistit v metodě `PresentationExtensions.AddCommonInputOutput` [zde](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/PresentationExtensions.cs).  

### **Úprava výchozí šablony**

Můžete upravit libovolný prvek ve šabloně společného modelu. Například můžete změnit styly formátování tabulky, ale chcete, aby ostatní styly jednostránkové verze zůstaly beze změny.  

Ve výchozím nastavení se používá Templates\common\table.html a tabulka má stejný vzhled jako tabulka v PowerPointu. Změníme formátování tabulky pomocí vlastních CSS stylů:
``` css
.custom-table {
    border: 1px solid black;
}
.custom-table tr:nth-child(even) {background: #CCC}
.custom-table tr:nth-child(odd) {background: #ffb380}
```

Můžeme vytvořit stejnou strukturu vstupních šablon a výstupních souborů (tak jak je generována) při volání metody `PresentationExtensions.ToSinglePageWebDocument`. Přidáme metodu `ExportCustomTableStyles_AddCommonStructure`. Rozdíl mezi touto metodou a metodou `ToSinglePageWebDocument` — nepotřebujeme přidávat standardní šablonu pro tabulku a hlavní indexovou stránku (bude nahrazena odkazem na vlastní styly tabulky):

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

Přidáme vlastní šablonu místo toho:

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

    // nastavení globálních hodnot dokumentu
    WebDocument document = new WebDocument(options);
    SetupGlobals(document, options, outputPath);

    // přidat společnou strukturu (kromě šablony tabulky)
    ExportCustomTableStyles_AddCommonStructure(pres, document, templatesPath, outputPath, options.EmbedImages);
                
    // přidat vlastní šablonu tabulky
    document.Input.AddTemplate<Table>("table", @"custom-templates\table-custom-style.html");
                
    // přidat vlastní styly tabulky
    document.Input.AddTemplate<Presentation>("table-custom-style", @"custom-templates\styles\table-custom-style.css");
    document.Output.Add(Path.Combine(outputPath, "table-custom-style.css"), "table-custom-style", pres);
                
    // přidat vlastní index – je to jen kopie standardního "index.html", ale obsahuje odkaz na "table-custom-style.css"
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

**Poznámka** že vlastní šablona tabulky byla přidána se stejným klíčem „table“ jako standardní tabulka. Tím můžete nahradit konkrétní výchozí šablonu, aniž byste ji přepisovali. Stejné klíče můžete použít i v šablonách ze standardní struktury. Například můžete použít standardní šablonu odstavce v šabloně tabulky; můžete ji také nahradit pomocí klíče.  
Můžete také použít index.html k vloženému odkazu na vlastní CSS styly tabulky:

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

## **Vytvoření projektu od začátku: animované přechody snímků**

WebExtensions umožňuje exportovat prezentace s animovanými přechody snímků — stačí nastavit vlastnost `AnimateTransitions` v `WebDocumentOptions` na `true`:

``` csharp
WebDocumentOptions options = new WebDocumentOptions
{
    // ... další možnosti
    AnimateTransitions = true
};
```

Vytvoříme nový projekt, který používá Aspose.Slides a Aspose.Slides.WebExtensions k vytvoření HTML‑vieweru pro PDF s plynulými animovanými přechody stránek. Zde potřebujeme použít funkci importu PDF v Aspose.Slides.  

Vytvoříme projekt PdfToPresentationToHtml a přidáme NuGet balíček Aspose.Slides.WebExtensions (balíček Aspose.Slides bude také přidán jako závislost):
![NuGet Package](screen.png)

Začneme importem PDF dokumentu, který bude animován a exportován do HTML prezentace:

``` csharp
using (Presentation pres = new Presentation())
{
    pres.Slides.RemoveAt(0);
    pres.Slides.AddFromPdf("sample.pdf");
}
```

Nyní můžeme nastavit animované přechody snímků (každý snímek je importovaná stránka PDF). Ve vzorovém PDF dokumentu bylo použito 9 snímků. Přidáme přechody snímků do každého z nich (ukázka při prohlížení HTML):

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

Nakonec jej exportujeme do HTML pomocí `WebDocument` s vlastností `AnimateTransitions` nastavenou na `true`:

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

Úplný ukázkový zdrojový kód:
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

To je vše, co potřebujete k vytvoření HTML s animovanými přechody stránek generovanými z PDF dokumentu.  

* [Stáhnout ukázkový HTML soubor](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/tree/main/Examples).  
* [Stáhnout ukázkový projekt](/slides/cs/net/web-extensions/sample.zip).