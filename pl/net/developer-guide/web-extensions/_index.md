---
title: Nowy system eksportu HTML - Aspose.Slides.WebExtensions
type: docs
weight: 240
url: /pl/net/web-extensions/
keywords:
- rozszerzenie sieciowe
- silnik szablonów
- eksport PowerPoint
- eksport OpenDocument
- eksport prezentacji
- eksport slajdu
- eksport PPT
- eksport PPTX
- eksport ODP
- PowerPoint do HTML
- OpenDocument do HTML
- prezentacja do HTML
- slajd do HTML
- PPT do HTML
- PPTX do HTML
- ODP do HTML
- .NET
- C#
- Aspose.Slides
description: "Eksportuj prezentacje do HTML przy użyciu szablonów, CSS i JS—bez SVG. Dowiedz się o wyjściu jednostronicowym lub wielostronicowym, kontroli zasobów i dostosowywaniu dla PPT, PPTX i ODP."
---
## **Wprowadzenie**

* W starszych wersjach API Aspose.Slides, podczas eksportu PowerPoint do HTML, otrzymany HTML był reprezentowany jako znacznik SVG połączony z HTML. Każdy slajd był eksportowany jako kontener SVG. 
* W nowych wersjach Aspose.Slides, przy użyciu systemu WebExtensions do eksportu prezentacji PowerPoint do HTML, można dostosować ustawienia eksportu HTML, aby uzyskać najlepsze rezultaty. 

Korzystając z nowego systemu WebExtensions, można wyeksportować całą prezentację do HTML z zestawem klas CSS i animacji JavaScript (bez SVG). Nowy system eksportu zapewnia nieograniczoną liczbę opcji i metod definiujących proces eksportu. 

System WebExtensions jest używany do generowania HTML z prezentacji w następujących przypadkach i zdarzeniach:

* przy użyciu własnych stylów CSS lub animacji; nadpisywanie znacznika dla określonych typów kształtów.  
* przy nadpisywaniu struktury dokumentu, np. przy użyciu własnej nawigacji między stronami.
* przy zapisywaniu plików .html, .css, .js do folderów o spersonalizowanej hierarchii, w tym określonych typów plików w różnych folderach. Na przykład eksport slajdów do folderu na podstawie nazwy sekcji.
* przy domyślnym zapisywaniu plików CSS i JS do osobnych folderów, a następnie dodawaniu ich do pliku HTML. Obrazy i osadzone czcionki są również zapisywane jako osobne pliki. Mogą jednak być osadzone w pliku HTML (w formacie base64). Można zapisać niektóre części zasobów w plikach, a inne zasoby osadzić w HTML jako base64.

Możesz przejrzeć przykłady PowerPoint do HTML w projekcie [Aspose.Slides.WebExtensions project](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/) na GitHubie. Projekt ten zawiera 2 części: **Examples\SinglePageApp** i **Examples\MultiPageApp**. Pozostałe przykłady użyte w tym artykule można również znaleźć w repozytorium GitHub.

### **Szablony**

Aby jeszcze bardziej rozszerzyć możliwości eksportu HTML, zalecamy użycie systemu szablonów ASP.NET Razor. Instancja klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation) może być użyta razem z zestawem szablonów, aby otrzymać dokument HTML jako wynik eksportu.

**Demonstracja**

W tym przykładzie wyeksportujemy tekst z prezentacji do HTML. Najpierw utwórzmy szablon:

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
Ten szablon jest zapisany na dysku jako "shape-template-hello-world.html", który będzie użyty w następnym kroku.

W tym szablonie iterujemy ramki tekstowe w kształtach prezentacji, aby wyświetlić tekst. Wygenerujmy plik HTML przy użyciu WebDocument, a następnie wyeksportujmy Presentation do tego pliku: 

``` csharp
using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 150);
    shape.TextFrame.Text = "Hello World";
                
    WebDocumentOptions options = new WebDocumentOptions
    {
        TemplateEngine = new RazorTemplateEngine(), // Chcemy użyć silnika szablonów Razor. Inne silniki szablonów można używać, implementując ITemplateEngine  
        OutputSaver = new FileOutputSaver() // Inne zapisywacze wyników można używać, implementując interfejs IOutputSaver
    };
    WebDocument document = new WebDocument(options);

    // dodaj dokument "input" - jakie źródło będzie użyte do wygenerowania dokumentu HTML
    document.Input
        .AddTemplate<Presentation>( // szablon będzie miał Presentation jako obiekt "model" (Model.Object) 
        "index", // klucz szablonu - potrzebny silnikowi szablonów do dopasowania obiektu (Presentation) do szablonu wczytanego z dysku ("shape-template-hello-world.html")  
        @"custom-templates\shape-template-hello-world.html"); // szablon utworzony wcześniej
                
    // dodaj output - jak będzie wyglądał wygenerowany dokument HTML po wyeksportowaniu na dysk
    document.Output.Add(
        "hello-world.html", // ścieżka pliku wyjściowego
        "index", // klucz szablonu, który będzie użyty dla tego pliku (ustawiliśmy go w poprzednim stwierdzeniu)  
        pres); // rzeczywista instancja Model.Object 
                
    document.Save();
}
```

Na przykład chcemy dodać style CSS do wyniku eksportu, aby zmienić kolor tekstu na czerwony. Dodajmy szablon CSS:

``` css
.text {
    color: red;
}
```

Teraz dodajmy go do wejścia i wyjścia:

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

Dodajmy odwołanie do stylów w szablonie i klasę "text":
``` html
<!DOCTYPE html>
<head>
    <link rel="stylesheet" type="text/css" href="hello-world.css" />
</head>
...
</html>
```

### **Domyślne szablony**

WebExtensions udostępnia 2 zestawy podstawowych szablonów do eksportu prezentacji do HTML:
* Jednostronicowy: cała zawartość prezentacji jest eksportowana do jednego pliku HTML. Wszystkie pozostałe zasoby (obrazy, czcionki, style itp.) są eksportowane do osobnych plików.
* Wielostronicowy: każdy slajd prezentacji jest eksportowany do osobnego pliku HTML. Domyślna logika eksportu zasobów jest taka sama jak w wersji jednostronicowej. 

Klasa `PresentationExtensions` może być użyta do uproszczenia procesu eksportu prezentacji przy użyciu szablonów. Klasa `PresentationExtensions` zawiera zestaw metod rozszerzeń dla klasy Presentation. Aby wyeksportować prezentację do jednej strony, wystarczy dodać przestrzeń nazw Aspose.Slides.WebExtensions i wywołać dwie metody. Pierwsza metoda, `ToSinglePageWebDocument`, tworzy instancję `WebDocument`. Druga metoda zapisuje dokument HTML: 

``` csharp
using (Presentation pres = new Presentation("demo.pptx"))
{
    WebDocument document = pres.ToSinglePageWebDocument("templates\\single-page", @"single-page-output");
    document.Save();
}
```

Metoda ToSinglePageWebDocument może przyjmować dwa parametry: folder szablonów i folder docelowy.

Aby wyeksportować prezentację do wielu stron, użyj metody ToMultiPageWebDocument z tymi samymi parametrami:

``` csharp
using (Presentation pres = new Presentation("demo.pptx"))
{
    WebDocument document = pres.ToMultiPageWebDocument("templates\\multi-page", @"mutil-page-output");
    document.Save();
}
```

W WebExtensions każdy szablon używany do generowania znacznika jest powiązany z kluczem. Klucz może być używany w szablonach. Na przykład w dyrektywie @Include można wstawić określony szablon do innego za pomocą klucza.

Możemy zilustrować tę procedurę na przykładzie użycia szablonu fragmentu tekstu wewnątrz szablonu akapitu. Przykład znajduje się w projekcie Aspose.Slides.WebExtensions: [Templates\common\paragraph.html](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/Templates/common/paragraph.html). Aby narysować fragmenty w akapicie, iterujemy je przy użyciu dyrektywy @foreach silnika Razor:

``` html
@foreach (Portion portion in contextObject.Portions) 
{ 
    var subModel = Model.SubModel(portion);
    subModel.Local.Put("parentTextFrame", parentTextFrame);
    subModel.Local.Put("tableContent", tableContentFlag);
	@Raw(Include("portion", subModel).ToString().Replace(Environment.NewLine, ""));
}
```

Fragment ma własny szablon [portion.html](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/Templates/common/portion.html) i generowany jest dla niego model. Ten model zostanie dodany do szablonu output paragraph.html:
``` html
@Raw(Include("portion", subModel).ToString().Replace(Environment.NewLine, ""));
```

Dla każdego typu kształtu używamy własnego szablonu, który jest dodawany do ogólnego zestawu szablonów z projektu Aspose.Slides.WebExtensions. Szablony są łączone w metodach ToSinglePageWebDocument i ToMultiPageWebDocument, aby dostarczyć ostateczny wynik. Są to wspólne szablony używane zarówno w wersji jednostronicowej, jak i wielostronicowej:

- templates
+-common
  ¦ +-scripts: skrypty JavaScript dla animacji przejść slajdów, jako przykład.
  ¦ +-styles: wspólne style CSS.
  +-multi-page: index, menu, szablony slajdów dla wyjścia wielostronicowego.
  +-single-page: index, szablony slajdów dla wyjścia jednostronicowego.

Możesz sprawdzić, jak część wspólna jest powiązana ze wszystkimi szablonami w metodzie `PresentationExtensions.AddCommonInputOutput` [tutaj](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/PresentationExtensions.cs).

### **Dostosowywanie domyślnego szablonu**

Możesz zmodyfikować dowolny element w szablonie wspólnego modelu. Na przykład możesz zdecydować się zmienić style formatowania tabeli, ale chcesz, aby wszystkie pozostałe style jednostronicowe pozostały niezmienione.

Domyślnie używany jest Templates\common\table.html, a tabela wygląda tak samo jak tabela w PowerPoint. Zmienmy formatowanie tabeli przy użyciu własnych stylów CSS:
``` css
.custom-table {
    border: 1px solid black;
}
.custom-table tr:nth-child(even) {background: #CCC}
.custom-table tr:nth-child(odd) {background: #ffb380}
```

Możemy utworzyć taką samą strukturę szablonów wejściowych i plików wyjściowych (tak jak jest generowana), wywołując metodę `PresentationExtensions.ToSinglePageWebDocument`. Dodajmy metodę `ExportCustomTableStyles_AddCommonStructure`. Różnica między tą metodą a `ToSinglePageWebDocument` – nie musimy dodawać standardowego szablonu dla tabeli i głównej strony indeksu (zostanie on zastąpiony, aby zawierał odwołanie do własnych stylów tabeli):

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

Dodajmy własny szablon zamiast tego:

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

    // ustaw globalne wartości dokumentu
    WebDocument document = new WebDocument(options);
    SetupGlobals(document, options, outputPath);

    // dodaj wspólną strukturę (z wyjątkiem szablonu tabeli)
    ExportCustomTableStyles_AddCommonStructure(pres, document, templatesPath, outputPath, options.EmbedImages);
                
    // dodaj własny szablon tabeli
    document.Input.AddTemplate<Table>("table", @"custom-templates\table-custom-style.html");
                
    // dodaj własne style tabeli
    document.Input.AddTemplate<Presentation>("table-custom-style", @"custom-templates\styles\table-custom-style.css");
    document.Output.Add(Path.Combine(outputPath, "table-custom-style.css"), "table-custom-style", pres);
                
    // dodaj własny indeks - to tylko kopia standardowego "index.html", ale zawiera odwołanie do "table-custom-style.css"
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

**Uwaga**, że własny szablon tabeli został dodany z tym samym kluczem "table" co standardowy szablon tabeli. Dzięki temu można zastąpić określony domyślny szablon bez jego przepisywania. Można również używać szablonów z domyślnej struktury z tymi samymi kluczami. Na przykład, możesz użyć standardowego szablonu akapitu w szablonie tabeli; możesz go także zamienić przy użyciu klucza.
Możesz również użyć pliku index.html, aby dodać odwołanie do własnych stylów CSS tabeli:

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

## **Utworzenie projektu od podstaw: animowane przejścia slajdów**

WebExtensions pozwala eksportować prezentacje z animowanymi przejściami slajdów – wystarczy ustawić właściwość `AnimateTransitions` w `WebDocumentOptions` na `true`:

``` csharp
WebDocumentOptions options = new WebDocumentOptions
{
    // ... inne opcje
    AnimateTransitions = true
};
```

Utwórzmy nowy projekt, który używa Aspose.Slides i Aspose.Slides.WebExtensions do tworzenia przeglądarki HTML dla PDF z płynnymi animowanymi przejściami stron. Tutaj potrzebujemy funkcji importu PDF w Aspose.Slides.

Utwórzmy projekt PdfToPresentationToHtml i dodajmy pakiet NuGet Aspose.Slides.WebExtensions (pakiet Aspose.Slides zostanie również dodany jako zależność):
![NuGet Package](screen.png)

Zaczynamy od zaimportowania dokumentu PDF, który zostanie animowany i wyeksportowany do prezentacji HTML:

``` csharp
using (Presentation pres = new Presentation())
{
    pres.Slides.RemoveAt(0);
    pres.Slides.AddFromPdf("sample.pdf");
}
```

Teraz możemy skonfigurować animowane przejścia slajdów (każdy slajd to zaimportowana strona PDF). W przykładowym dokumencie PDF użyto 9 slajdów. Dodajmy przejścia slajdów do każdego z nich (demonstracja podczas przeglądania HTML):

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

Na koniec wyeksportujmy ją do HTML przy użyciu `WebDocument` z właściwością `AnimateTransitions` ustawioną na `true`:

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

Pełny przykład kodu:
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

To wszystko, co jest potrzebne, aby utworzyć HTML z animowanymi przejściami stron generowanymi z dokumentu PDF. 

* [Download sample HTML file](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/tree/main/Examples).
* [Download sample project](/slides/pl/net/web-extensions/sample.zip).