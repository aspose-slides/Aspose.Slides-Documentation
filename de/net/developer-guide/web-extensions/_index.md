---
title: Neues HTML-Export-System - Aspose.Slides.WebExtensions
type: docs
weight: 240
url: /de/net/web-extensions/
keywords:
- Web-Erweiterung
- Template-Engine
- PowerPoint-Export
- OpenDocument-Export
- Präsentations-Export
- Folien-Export
- PPT-Export
- PPTX-Export
- ODP-Export
- PowerPoint zu HTML
- OpenDocument zu HTML
- Präsentation zu HTML
- Folie zu HTML
- PPT zu HTML
- PPTX zu HTML
- ODP zu HTML
- .NET
- C#
- Aspose.Slides
description: "Exportieren Sie Präsentationen nach HTML mit Vorlagen, CSS und JS—keine SVG. Erfahren Sie mehr über Einzelseiten- oder Mehrseitenausgabe, Ressourcenverwaltung und Anpassungen für PPT, PPTX und ODP."
---

## **Einführung**

* In alten Aspose.Slides API‑Builds, wenn Sie PowerPoint nach HTML exportieren, wird das resultierende HTML als SVG‑Markup kombiniert mit HTML dargestellt. Jede Folie wird als SVG‑Container exportiert.  
* In den neuen Aspose.Slides‑Versionen, wenn Sie das WebExtensions‑System zum Exportieren von PowerPoint‑Präsentationen nach HTML verwenden, können Sie die HTML‑Exporteinstellungen anpassen, um die besten Ergebnisse zu erzielen.  

Mit dem neuen WebExtensions‑System können Sie eine gesamte Präsentation nach HTML exportieren, wobei ein Satz von CSS‑Klassen und JavaScript‑Animationen (ohne SVG) verwendet wird. Das neue Export‑System bietet zudem eine unbegrenzte Anzahl von Optionen und Methoden, die den Exportvorgang definieren.  

In den folgenden Fällen und Situationen wird das neue WebExtensions‑System zur Generierung von HTML aus Präsentationen eingesetzt:

* beim Einsatz benutzerdefinierter CSS‑Stile oder Animationen; beim Überschreiben des Markups für bestimmte Formenarten.  
* beim Überschreiben der Dokumentstruktur, z. B. durch benutzerdefinierte Navigation zwischen Seiten.  
* beim Speichern von .html, .css, .js‑Dateien in Ordnern mit benutzerdefinierter Hierarchie, wobei bestimmte Dateitypen in verschiedenen Ordnern abgelegt werden. Zum Beispiel das Exportieren von Folien in einen Ordner basierend auf dem Abschnittsnamen.  
* beim Standard‑Speichern von CSS‑ und JS‑Dateien in separaten Ordnern und anschließendem Einbinden in eine HTML‑Datei. Bilder und eingebettete Schriftarten werden ebenfalls in separaten Dateien gespeichert. Sie können jedoch in eine HTML‑Datei eingebettet werden (im Base64‑Format). Sie können einige Ressourcen in Dateien speichern und andere Ressourcen als Base64 in HTML einbetten.  

Sie können die PowerPoint‑zu‑HTML‑Beispiele im [Aspose.Slides.WebExtensions project](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/) auf GitHub ansehen. Dieses Projekt enthält 2 Teile: **Examples\SinglePageApp** und **Examples\MultiPageApp**. Die in diesem Artikel verwendeten weiteren Beispiele finden Sie ebenfalls im GitHub‑Repository.  

### **Vorlagen**

Um die Möglichkeiten des HTML‑Exports weiter zu erweitern, empfehlen wir die Verwendung des ASP.NET Razor‑Template‑Systems. Die [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasseninstanz kann zusammen mit einem Satz von Vorlagen verwendet werden, um ein HTML‑Dokument als Export‑Ergebnis zu erhalten.  

**Demonstration**

In diesem Beispiel exportieren wir Text aus einer Präsentation nach HTML. Zuerst erstellen wir die Vorlage:
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

Diese Vorlage wird auf dem Datenträger unter dem Namen „shape-template-hello-world.html“ gespeichert und im nächsten Schritt verwendet.  

In dieser Vorlage iterieren wir Textfelder in den Präsentationsformen, um den Text anzuzeigen. Lassen Sie uns die HTML‑Datei mit WebDocument erzeugen und anschließend die Presentation in die Datei exportieren: 
``` csharp
using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 150);
    shape.TextFrame.Text = "Hello World";
                
    WebDocumentOptions options = new WebDocumentOptions
    {
        TemplateEngine = new RazorTemplateEngine(), // Wir beabsichtigen, die Razor-Template-Engine zu verwenden. Andere Template-Engines können durch Implementierung von ITemplateEngine verwendet werden.
        OutputSaver = new FileOutputSaver() // Andere Ergebnis‑Saver können durch Implementierung des IOutputSaver‑Interfaces verwendet werden.
    };
    WebDocument document = new WebDocument(options);

    // Dokument "input" hinzufügen – welche Quelle zum Erzeugen des HTML-Dokuments verwendet wird
    document.Input
        .AddTemplate<Presentation>( // Template verwendet Presentation als "Model"-Objekt (Model.Object) 
        "index", // Template‑Schlüssel – wird von der Template-Engine benötigt, um ein Objekt (Presentation) dem von der Festplatte geladenen Template („shape-template-hello-world.html“) zuzuordnen  
        @"custom-templates\shape-template-hello-world.html"); // Template, das wir früher erstellt haben
                
    // Ausgabe hinzufügen – wie das resultierende HTML-Dokument nach dem Export auf die Festplatte aussehen wird
    document.Output.Add(
        "hello-world.html", // Ausgabedateipfad
        "index", // Template‑Schlüssel, der für diese Datei verwendet wird (wir haben ihn in einer vorherigen Anweisung gesetzt)  
        pres); // eine tatsächliche Model.Object-Instanz 
                
    document.Save();
}
```


Zum Beispiel möchten wir dem Export Ergebnis CSS‑Stile hinzufügen, um die Textfarbe auf Rot zu ändern. Fügen wir die CSS‑Vorlage hinzu:
``` css
.text {
    color: red;
}
```


Jetzt fügen wir sie in die Eingabe und Ausgabe ein:
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


Fügen wir den Verweis auf die Stile zur Vorlage und zur Klasse "text" hinzu:
``` html
<!DOCTYPE html>
<head>
    <link rel="stylesheet" type="text/css" href="hello-world.css" />
</head>
...
</html>
```


### **Standardvorlagen**

WebExtensions bietet 2 Grundvorlagensätze für den Export von Präsentationen nach HTML:
* Single‑Page: Der gesamte Präsentationsinhalt wird in eine HTML‑Datei exportiert. Alle anderen Ressourcen (Bilder, Schriftarten, Stile usw.) werden in separate Dateien exportiert.  
* Multi‑Page: Jede Präsentationsfolie wird in eine einzelne HTML‑Datei exportiert. Die Standardlogik für das Exportieren von Ressourcen entspricht der einer Single‑Page.  

Die Klasse `PresentationExtensions` kann verwendet werden, um den Präsentations‑Exportprozess mithilfe von Vorlagen zu vereinfachen. Die Klasse `PresentationExtensions` enthält eine Reihe von Erweiterungsmethoden für die Klasse Presentation. Um eine Präsentation in eine einzelne Seite zu exportieren, fügen Sie einfach den Namespace Aspose.Slides.WebExtensions hinzu und rufen zwei Methoden auf. Die erste Methode, `ToSinglePageWebDocument`, erstellt eine `WebDocument`‑Instanz. Die zweite Methode speichert das HTML‑Dokument: 
``` csharp
using (Presentation pres = new Presentation("demo.pptx"))
{
    WebDocument document = pres.ToSinglePageWebDocument("templates\\single-page", @"single-page-output");
    document.Save();
}
```


Die Methode ToSinglePageWebDocument kann zwei Parameter entgegennehmen: das Vorlagen‑Verzeichnis und das Export‑Verzeichnis.  

Um eine Präsentation in mehrere Seiten zu exportieren, verwenden Sie die Methode ToMultiPageWebDocument mit denselben Parametern:
``` csharp
using (Presentation pres = new Presentation("demo.pptx"))
{
    WebDocument document = pres.ToMultiPageWebDocument("templates\\multi-page", @"mutil-page-output");
    document.Save();
}
```


In WebExtensions ist jede für die Markup‑Erstellung verwendete Vorlage an einen Schlüssel gebunden. Der Schlüssel kann in Vorlagen verwendet werden. Zum Beispiel können Sie im @Include‑Direktiv eine bestimmte Vorlage mithilfe des Schlüssels in eine andere einfügen.  

Wir können das Verfahren am Beispiel der Verwendung einer Text‑Abschnitts‑Vorlage innerhalb der Absatz‑Vorlage demonstrieren. Das Beispiel finden Sie im Aspose.Slides.WebExtensions‑Projekt: [Templates\common\paragraph.html](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/Templates/common/paragraph.html). Um die Abschnitte in einem Absatz zu zeichnen, iterieren wir sie mit dem @foreach‑Direktiv der Razor‑Engine:
``` html
@foreach (Portion portion in contextObject.Portions) 
{ 
    var subModel = Model.SubModel(portion);
    subModel.Local.Put("parentTextFrame", parentTextFrame);
    subModel.Local.Put("tableContent", tableContentFlag);
	@Raw(Include("portion", subModel).ToString().Replace(Environment.NewLine, ""));
}
```


Ein Abschnitt hat seine eigene Vorlage [portion.html](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/Templates/common/portion.html) und dafür wird ein Modell erzeugt. Dieses Modell wird zur Ausgabe‑Vorlage paragraph.html hinzugefügt:
``` html
@Raw(Include("portion", subModel).ToString().Replace(Environment.NewLine, ""));
```


Für jeden Formtyp verwenden wir eine benutzerdefinierte Vorlage, die dem allgemeinen Satz von Vorlagen aus dem Aspose.Slides.WebExtensions‑Projekt hinzugefügt wird. Die Vorlagen werden in den Methoden ToSinglePageWebDocument und ToMultiPageWebDocument kombiniert, um ein Endergebnis zu erzeugen. Dies sind gemeinsame Vorlagen, die sowohl in Single‑ als auch in Multi‑Page‑Szenarien verwendet werden:

-templates
+-common
  ¦ +-scripts: JavaScript‑Skripte für Folien‑Übergangsanimationen, als Beispiel.
  ¦ +-styles: gemeinsame CSS‑Stile.
  +-multi-page: index, menu, slide‑Vorlagen für die Multi‑Page‑Ausgabe.
  +-single-page: index, slide‑Vorlagen für die Single‑Page‑Ausgabe.

Sie können nachlesen, wie der gemeinsame Teil für alle Vorlagen in der Methode `PresentationExtensions.AddCommonInputOutput` gebunden wird, [hier](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/PresentationExtensions.cs).  

### **Anpassung der Standardvorlage**

Sie können jedes Element in der Vorlage des gemeinsamen Modells ändern. Zum Beispiel könnten Sie die Tabellenformatierungs‑Stile anpassen, während alle anderen Stile der Single‑Page unverändert bleiben sollen.  

Standardmäßig wird Templates\common\table.html verwendet, und die Tabelle sieht genauso aus wie die Tabelle in PowerPoint. Ändern wir die Tabellenformatierung mithilfe benutzerdefinierter CSS‑Stile:
``` css
.custom-table {
    border: 1px solid black;
}
.custom-table tr:nth-child(even) {background: #CCC}
.custom-table tr:nth-child(odd) {background: #ffb380}
```


Wir können die gleiche Struktur von Eingabe‑Vorlagen und Ausgabedateien (wie sie erzeugt werden) erstellen, wenn wir die Methode `PresentationExtensions.ToSinglePageWebDocument` aufrufen. Fügen wir dafür die Methode `ExportCustomTableStyles_AddCommonStructure` hinzu. Der Unterschied zu `ToSinglePageWebDocument` besteht darin, dass wir die Standard‑Vorlage für die Tabelle und die Haupt‑Index‑Seite nicht hinzufügen müssen (sie wird ersetzt, um den Verweis auf die benutzerdefinierten Tabellen‑Stile einzufügen):
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


Fügen wir stattdessen eine benutzerdefinierte Vorlage hinzu:
```csharp
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

    // globale Dokumentwerte einrichten
    WebDocument document = new WebDocument(options);
    SetupGlobals(document, options, outputPath);

    // gemeinsame Struktur hinzufügen (außer Tabellenvorlage)
    ExportCustomTableStyles_AddCommonStructure(pres, document, templatesPath, outputPath, options.EmbedImages);
                
    // benutzerdefinierte Tabellenvorlage hinzufügen
    document.Input.AddTemplate<Table>("table", @"custom-templates\table-custom-style.html");
                
    // benutzerdefinierte Tabellenstile hinzufügen
    document.Input.AddTemplate<Presentation>("table-custom-style", @"custom-templates\styles\table-custom-style.css");
    document.Output.Add(Path.Combine(outputPath, "table-custom-style.css"), "table-custom-style", pres);
                
    // benutzerdefinierten Index hinzufügen – es ist lediglich eine Kopie des Standard "index.html", enthält jedoch einen Verweis auf "table-custom-style.css"
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


**Hinweis**: Die benutzerdefinierte Tabellenvorlage wurde mit demselben Schlüssel „table“ wie die Standard‑Tabelle hinzugefügt. Damit können Sie eine bestimmte Standardvorlage ersetzen, ohne sie neu zu schreiben. Sie können auch die Vorlagen aus der Standardstruktur mit denselben Schlüsseln verwenden. Beispielsweise können Sie eine Standard‑Absatzvorlage in der Tabellenvorlage nutzen; Sie können sie ebenfalls durch den Schlüssel ersetzen.  
Sie können auch index.html verwenden, um den Verweis auf die benutzerdefinierten Tabellen‑CSS‑Stile einzubinden:
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


## **Projekt von Grund auf erstellen: Animierte Folienübergänge**

WebExtensions ermöglicht den Export von Präsentationen mit animierten Folienübergängen – Sie müssen lediglich die Eigenschaft `AnimateTransitions` in `WebDocumentOptions` auf `true` setzen:
``` csharp
WebDocumentOptions options = new WebDocumentOptions
{
    // ... andere Optionen
    AnimateTransitions = true
};
```


Erstellen wir ein neues Projekt, das Aspose.Slides und Aspose.Slides.WebExtensions verwendet, um einen HTML‑Viewer für PDF mit sanften animierten Seitenübergängen zu erstellen. Hier benötigen wir die PDF‑Import‑Funktion von Aspose.Slides.  

Erstellen wir ein PdfToPresentationToHtml‑Projekt und fügen das NuGet‑Paket Aspose.Slides.WebExtensions hinzu (das Aspose.Slides‑Paket wird ebenfalls als Abhängigkeit hinzugefügt):
![NuGet Package](screen.png)

Wir beginnen mit dem Import des PDF‑Dokuments, das animiert und in eine HTML‑Präsentation exportiert wird:
``` csharp
using (Presentation pres = new Presentation())
{
    pres.Slides.RemoveAt(0);
    pres.Slides.AddFromPdf("sample.pdf");
}
```


Nun können wir die animierten Folienübergänge einrichten (jede Folie ist die importierte PDF‑Seite). Im Beispiel‑PDF‑Dokument haben wir 9 Folien verwendet. Fügen wir den Folienübergang zu jeder von ihnen hinzu (Demonstration beim Betrachten von HTML):
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


Abschließend exportieren wir die Präsentation nach HTML mithilfe von `WebDocument` mit der auf `true` gesetzten Eigenschaft `AnimateTransitions`:
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


Vollständiges Quellcode‑Beispiel:
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


Damit haben Sie alles, was Sie benötigen, um HTML mit animierten Seitenübergängen zu erstellen, die aus dem PDF‑Dokument generiert wurden.  

* [Beispiel‑HTML‑Datei herunterladen](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/tree/main/Examples).
* [Beispielprojekt herunterladen](/slides/de/net/web-extensions/sample.zip).