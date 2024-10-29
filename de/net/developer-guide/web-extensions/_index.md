---
title: Neues HTML-Export-System - Aspose.Slides.WebExtensions
type: docs
weight: 240
url: /de/net/web-extensions/
keywords: "Export PowerPoint HTML, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "PowerPoint HTML-Export in C# oder .NET"
---

## Einleitung

* In alten Aspose.Slides API-Versionen wurde beim Export von PowerPoint nach HTML das resultierende HTML als SVG-Markup, kombiniert mit HTML, dargestellt. Jede Folie wurde als SVG-Container exportiert.
* In neuen Aspose.Slides-Versionen können Sie mit dem WebExtensions-System beim Export von PowerPoint-Präsentationen nach HTML die HTML-Export-Einstellungen anpassen, um die besten Ergebnisse zu erzielen.

Mit dem neuen WebExtensions-System können Sie eine gesamte Präsentation in HTML mit einer Reihe von CSS-Klassen und JavaScript-Animationen (ohne SVG) exportieren. Das neue Export-System bietet außerdem eine unbegrenzte Anzahl von Optionen und Methoden, die den Exportprozess definieren.

Das neue WebExtensions-System wird verwendet, um HTML aus Präsentationen in folgenden Fällen und Ereignissen zu generieren:

* Bei der Verwendung von benutzerdefinierten CSS-Stilen oder Animationen; Überschreibung des Markups für bestimmte Arten von Formen.
* Bei der Überschreibung der Dokumentenstruktur, z.B. bei der Verwendung von benutzerdefinierter Navigation zwischen Seiten.
* Beim Speichern von .html, .css, .js-Dateien in Ordnern mit benutzerdefinierter Hierarchie, einschließlich spezifischer Dateitypen in verschiedenen Ordnern. Zum Beispiel den Export von Folien in einen Ordner basierend auf dem Abschnittsnamen.
* Beim Speichern von CSS- und JS-Dateien standardmäßig in separaten Ordnern und anschließendem Hinzufügen zu einer HTML-Datei. Bilder und eingebettete Schriftarten werden ebenfalls in separaten Dateien gespeichert. Sie können jedoch in eine HTML-Datei eingebettet werden (im base64-Format). Sie können einige Teile der Ressourcen in die Dateien speichern und andere Ressourcen als base64 in HTML einbetten.

Sie können sich PowerPoint-zu-HTML-Beispiele im [Aspose.Slides.WebExtensions-Projekt](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/) auf GitHub ansehen. Dieses Projekt enthält 2 Teile: **Examples\SinglePageApp** und **Examples\MultiPageApp**. Die anderen Beispiele, die in diesem Artikel verwendet werden, finden Sie ebenfalls im GitHub-Repo.

### **Vorlagen**

Um die Funktionen des HTML-Exports weiter zu erweitern, empfehlen wir die Verwendung des ASP.NET Razor-Vorlagensystems. Die [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)-Klasseninstanz kann zusammen mit einer Reihe von Vorlagen verwendet werden, um ein HTML-Dokument als Exportergebnis zu erhalten.

**Demonstration**

In diesem Beispiel exportieren wir Text aus einer Präsentation nach HTML. Zunächst erstellen wir die Vorlage:

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
Diese Vorlage wird auf der Festplatte als "shape-template-hello-world.html" gespeichert, die im nächsten Schritt verwendet wird.

In dieser Vorlage iterieren wir über Text-Frames in Präsentationsformen, um den Text anzuzeigen. Lassen Sie uns die HTML-Datei mit WebDocument generieren und dann die Präsentation in die Datei exportieren:

``` csharp
using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 150);
    shape.TextFrame.Text = "Hello World";
                
    WebDocumentOptions options = new WebDocumentOptions
    {
        TemplateEngine = new RazorTemplateEngine(), // Wir beabsichtigen, die Razor-Vorlagentechnik zu verwenden. Andere Vorlagentechniken können durch Implementierung von ITemplateEngine verwendet werden 
        OutputSaver = new FileOutputSaver() // Andere Ergebnisspeicher können verwendet werden, indem die IOutputSaver-Schnittstelle implementiert wird
    };
    WebDocument document = new WebDocument(options);

    // Dokument "Eingabe" hinzufügen - welche Quelle verwendet wird, um das HTML-Dokument zu generieren
    document.Input
        .AddTemplate<Presentation>( // die Vorlage hat die Präsentation als "Modell"-Objekt (Model.Object) 
        "index", // Vorlagenschlüssel - benötigt von der Vorlagenmotor, um ein Objekt (Präsentation) mit der von der Festplatte geladenen Vorlage ("shape-template-hello-world.html") abzugleichen 
        @"custom-templates\shape-template-hello-world.html"); // Vorlage, die wir zuvor erstellt haben
                
    // Ausgabe hinzufügen - wie das resultierende HTML-Dokument aussehen wird, wenn es auf die Festplatte exportiert wird
    document.Output.Add(
        "hello-world.html", // Ausgabedateipfad
        "index", // Vorlagenschlüssel, der für diese Datei verwendet wird (wir haben ihn in einer vorherigen Anweisung gesetzt)  
        pres); // echte Model.Object-Instanz 
                
    document.Save();
}
```

Zum Beispiel möchten wir CSS-Stile zum Exportergebnis hinzufügen, um die Textfarbe auf rot zu ändern. Lassen Sie uns die CSS-Vorlage hinzufügen:

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

Lassen Sie uns den Verweis auf die Stile in der Vorlage und die Klasse "text" hinzufügen:
``` html
<!DOCTYPE html>
<head>
    <link rel="stylesheet" type="text/css" href="hello-world.css" />
</head>
...
</html>
```

### **Standardvorlagen**

WebExtensions bieten 2 Sätze grundlegender Vorlagen zum Exportieren von Präsentationen nach HTML:
* Einzelfolie: Alle Präsentationsinhalte werden in eine HTML-Datei exportiert. Alle anderen Ressourcen (Bilder, Schriftarten, Stile usw.) werden in separate Dateien exportiert.
* Mehrere Seiten: Jede Präsentationsfolie wird in eine separate HTML-Datei exportiert. Die Standardlogik für den Export von Ressourcen ist die gleiche wie auf einer einzelnen Seite.

Die `PresentationExtensions`-Klasse kann verwendet werden, um den Präsentationsexportprozess mithilfe von Vorlagen zu vereinfachen. Die `PresentationExtensions`-Klasse enthält eine Reihe von Erweiterungsmethoden für die Präsentationsklasse. Um eine Präsentation in eine einzelne Seite zu exportieren, fügen Sie einfach den Aspose.Slides.WebExtensions-Namespace hinzu und rufen Sie zwei Methoden auf. Die erste Methode, `ToSinglePageWebDocument`, erstellt eine `WebDocument`-Instanz. Die zweite Methode speichert das HTML-Dokument: 

``` csharp
using (Presentation pres = new Presentation("demo.pptx"))
{
    WebDocument document = pres.ToSinglePageWebDocument("templates\\single-page", @"single-page-output");
    document.Save();
}
```

Die ToSinglePageWebDocument-Methode kann zwei Parameter annehmen: den Vorlagenordner und den Exportordner.

Um die Präsentation auf mehrere Seiten zu exportieren, verwenden Sie die ToMultiPageWebDocument-Methode mit denselben Parametern:

``` csharp
using (Presentation pres = new Presentation("demo.pptx"))
{
    WebDocument document = pres.ToMultiPageWebDocument("templates\\multi-page", @"mutil-page-output");
    document.Save();
}
```

In WebExtensions ist jede Vorlage, die für die Markup-Generierung verwendet wird, an einen Schlüssel gebunden. Der Schlüssel kann in Vorlagen verwendet werden. Zum Beispiel können Sie mit der @Include-Direktive eine bestimmte Vorlage in einer anderen nach dem Schlüssel einfügen.

Wir können das Verfahren im Beispiel der Verwendung der Textanteilvorlage innerhalb der Absatzvorlage demonstrieren. Sie finden das Beispiel im Aspose.Slides.WebExtensions-Projekt: [Templates\common\paragraph.html](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/Templates/common/paragraph.html). Um die Abschnitte in einem Absatz zu zeichnen, iterieren wir sie mithilfe der @foreach-Direktive der Razor-Engine:

``` html
@foreach (Portion portion in contextObject.Portions) 
{ 
    var subModel = Model.SubModel(portion);
    subModel.Local.Put("parentTextFrame", parentTextFrame);
    subModel.Local.Put("tableContent", tableContentFlag);
	@Raw(Include("portion", subModel).ToString().Replace(Environment.NewLine, ""));
}
```

Jede Portion hat ihre eigene Vorlage [portion.html](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/Templates/common/portion.html), und ein Modell wird dafür generiert. Dieses Modell wird zur Ausgabedatei paragraph.html hinzugefügt:
``` html
@Raw(Include("portion", subModel).ToString().Replace(Environment.NewLine, ""));
```

Für jeden Formtyp verwenden wir eine benutzerdefinierte Vorlage, die dem allgemeinen Satz von Vorlagen im Aspose.Slides.WebExtensions-Projekt hinzugefügt wird. Vorlagen werden in den Methoden ToSinglePageWebDocument und ToMultiPageWebDocument kombiniert, um ein finales Ergebnis bereitzustellen. Dies sind allgemeine Vorlagen, die sowohl in einer einzelnen als auch in mehreren Seiten verwendet werden:

-templates
+-common
  ¦ +-scripts: Javascript-Skripte für Folienübergangsanimationen, z.B.
  ¦ +-styles: allgemeine CSS-Stile.
  +-multi-page: Index-, Menü-, Folienvorlagen für den mehrseitigen Output.
  +-single-page: Index-, Folienvorlagen für den einseitigen Output.

Sie können herausfinden, wie der gemeinsame Teil für alle Vorlagen in der `PresentationExtensions.AddCommonInputOutput`-Methode [hier](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/PresentationExtensions.cs) gebunden ist.

### **Anpassung der Standardvorlagen**

Sie können jedes Element in der Vorlage des gemeinsamen Modells ändern. Beispielsweise können Sie entscheiden, die Formatierungsstile der Tabelle zu ändern, möchten aber, dass alle anderen Stile der einzelnen Seite unverändert bleiben.

Standardmäßig wird die Vorlage Templates\common\table.html verwendet, und die Tabelle hat das gleiche Aussehen wie die Tabelle in PowerPoint. Lassen Sie uns die Tabellenformatierung mithilfe benutzerdefinierter CSS-Stile ändern:
``` css
.custom-table {
    border: 1px solid black;
}
.custom-table tr:nth-child(even) {background: #CCC}
.custom-table tr:nth-child(odd) {background: #ffb380}
```

Wir können die gleiche Struktur der Eingabepositionen und Ausgabedateien (wie sie generiert wird) erstellen, während wir die Methode `PresentationExtensions.ToSinglePageWebDocument` aufrufen. Lassen Sie uns die Methode `ExportCustomTableStyles_AddCommonStructure` dafür hinzufügen. Der Unterschied zwischen dieser Methode und der Methode `ToSinglePageWebDocument` besteht darin, dass wir die Standardvorlage für die Tabelle und die Hauptindexseite nicht hinzufügen müssen (sie wird ersetzt, um den Bezug auf die benutzerdefinierten Tabellenstile einzuschließen):

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

Lassen Sie uns stattdessen eine benutzerdefinierte Vorlage hinzufügen:

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
                
    // benutzerdefinierte Indexseite hinzufügen - es ist nur eine Kopie der Standard-"index.html", aber enthält einen Verweis auf "table-custom-style.css"
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

**Hinweis** dass die benutzerdefinierte Tabellenvorlage mit dem gleichen „table“-Schlüssel wie die Standardtabelle hinzugefügt wurde. Somit können Sie eine bestimmte Standardvorlage ersetzen, ohne sie neu zu schreiben. Sie können auch die Vorlagen aus der Standardstruktur mit denselben Schlüsseln verwenden. Zum Beispiel können Sie eine Standardabsatzvorlage in der Tabellenvorlage verwenden; Sie können sie auch mit dem Schlüssel ersetzen.
Sie können auch index.html verwenden, um den Verweis auf benutzerdefinierte Tabellen-CSS-Stile einzuschließen: 

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

WebExtensions ermöglichen es Ihnen, Präsentationen mit animierten Folienübergängen zu exportieren – Sie müssen lediglich die Eigenschaft `AnimateTransitions` in `WebDocumentOptions` auf `true` setzen:

``` csharp
WebDocumentOptions options = new WebDocumentOptions
{
    // ... andere Optionen
    AnimateTransitions = true
};
```

Lassen Sie uns ein neues Projekt erstellen, das Aspose.Slides und Aspose.Slides.WebExtensions verwendet, um einen HTML-Viewer für PDFs mit sanften animierten Seitenübergängen zu erstellen. Hier müssen wir die PDF-Importfunktion von Aspose.Slides verwenden.

Lassen Sie uns ein PdfToPresentationToHtml-Projekt erstellen und das NuGet-Paket Aspose.Slides.WebExtensions hinzufügen (das Paket Aspose.Slides wird auch als Abhängigkeit hinzugefügt):
![NuGet-Paket](screen.png)

Wir beginnen mit dem Importieren des PDF-Dokuments, das animiert und in eine HTML-Präsentation exportiert werden soll:

``` csharp
using (Presentation pres = new Presentation())
{
    pres.Slides.RemoveAt(0);
    pres.Slides.AddFromPdf("sample.pdf");
}
```

Jetzt können wir die animierten Folienübergänge einrichten (jede Folie ist die importierte PDF-Seite). Wir haben 9 Folien im Beispiel-PDF-Dokument verwendet. Lassen Sie uns Folienübergänge in jede von ihnen hinzufügen (Demonstration beim Ansehen des HTML):

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

Schließlich lassen Sie uns es mit `WebDocument` im Exportformat HTML speichern, wobei die `AnimateTransitions`-Eigenschaft auf `true` gesetzt ist:

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

Volles Beispiel für den Quellcode:
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

Das ist alles, was Sie benötigen, um HTML mit den animierten Seitenübergängen zu erstellen, die aus dem PDF-Dokument generiert wurden.

* [Download Beispiel-HTML-Datei](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/tree/main/Examples).
* [Download Beispielprojekt](/slides/de/net/web-extensions/sample.zip).